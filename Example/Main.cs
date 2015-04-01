using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using openvassharp;

namespace Example
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (OpenVASSession session = new OpenVASSession ("admin", "passfword", "192.168.1.99")) {
				using (OpenVASManager manager = new OpenVASManager (session)) {
					Console.WriteLine (manager.GetVersion ().ToString ());
				}
			}
		}
	}
}
