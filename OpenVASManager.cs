using System;
using System.Xml;
using System.Xml.Linq;

namespace openvassharp
{
	public class OpenVASManager : IDisposable
	{
		private OpenVASSession _session;

		public OpenVASManager ()
		{
			_session = null;
		}

		public OpenVASManager(OpenVASSession session)
		{
			if (session != null)
				_session = session;
		}

		public XDocument GetVersion() {
			return _session.ExecuteCommand (XDocument.Parse ("<get_version />"));
		}

		private bool CheckSession()
		{
			if (!_session.Stream.CanRead)
				throw new Exception("Bad session");
			
			return true;
		}
		
		public void Dispose()
		{
			_session = null;
		}
		
	}
}
