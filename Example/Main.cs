using System;
using System.Collections.Generic;
using System.Xml;
using openvassharp;
using AutoAssess.Data.OpenVAS.Objects;

namespace Example
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (OpenVASManagerSession session = new OpenVASManagerSession("openvas", "openvas", "192.168.1.11"))
			{
				using (OpenVASObjectManager manager = new OpenVASObjectManager(session))
				{
					XmlDocument resp = manager.GetTasks(string.Empty, false, false, false, string.Empty, string.Empty);

					OpenVASTarget target = new OpenVASTarget ();
					target.Hosts = "192.168.1.0/24";
					target.Name = "The namfdsaefdsa";
					target.SMBCredentials = new OpenVASLSCCredential ();
					target.SSHCredentials = new OpenVASLSCCredential ();

					target = manager.CreateTarget(target);

					OpenVASConfig config = manager.GetAllConfigs ()[0];
					OpenVASTask task = new OpenVASTask ();

					task.Name = "named!";
					task.Comment = "commented!";
					task.Target = target;
					task.Config = config;
					
					task = manager.CreateTask (task);
					
					XmlDocument taskResponse = manager.StartTask (task.RemoteTaskID.ToString ());
					
					if (!taskResponse.FirstChild.Attributes ["status"].Value.StartsWith ("20"))
						throw new Exception ("Creating OpenVAS scan failed: " + 
						                     taskResponse.FirstChild.Attributes ["status_text"].Value);
					
					string openvasReportID = taskResponse.FirstChild.FirstChild.InnerText;
					Console.WriteLine("The report id is: " + openvasReportID);

					bool done = false;
					while (!done)
					{
						XmlDocument taskInfo = manager.GetTasks (task.RemoteTaskID.ToString(), true, false, false, string.Empty, string.Empty);
						
						foreach (XmlNode child in taskInfo.FirstChild.ChildNodes) {
							if (child.Name != "task")
								continue;
							
							foreach (XmlNode c in child.ChildNodes) {
								if (c.Name != "status")
									continue;
								
								if (c.InnerText == "Done")
									done = true;
							}
						}
					}

					XmlDocument report = manager.GetReportByID(openvasReportID);

				}
			}
		}
	}
}
