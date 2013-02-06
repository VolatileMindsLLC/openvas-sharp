using System;
using System.Collections.Generic;
using System.Xml;

namespace AutoAssess.Data.OpenVAS.Objects
{
	[Serializable]
	public class OpenVASNote : IOpenVASObject
	{
		public OpenVASNote ()
		{
		}
		
		public virtual Guid RemoteNoteID { get; set; }
		
		public virtual string Content { get; set; }
		
		public virtual OpenVASNVT NVT { get; set; }
		
		public virtual string Comment { get; set; }
		
		public virtual string Hosts { get; set; }
		
		public virtual int Port { get; set; }
		
		public virtual OpenVASScan Report { get; set; }
		
		public virtual OpenVASTask Task { get; set; }
		
		public virtual string ThreatLevel { get; set; }
	
		
		public virtual List<IOpenVASObject> Parse(XmlDocument response)
		{
			List<IOpenVASObject> objects = new List<IOpenVASObject>();
			
			return objects;
		}
	}
}

