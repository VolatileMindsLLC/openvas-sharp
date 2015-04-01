using System;
using System.Xml;
using System.Xml.Linq;

namespace openvassharp
{
	public class OpenVASManager : IDisposable
	{
		private OpenVASSession _session;

		public OpenVASManager(OpenVASSession session)
		{
			if (session != null)
				_session = session;
		}

		public XDocument GetVersion() {
			return _session.ExecuteCommand (XDocument.Parse ("<get_version />"));
		}
		
		public void Dispose()
		{
			_session = null;
		}
		
	}
}
