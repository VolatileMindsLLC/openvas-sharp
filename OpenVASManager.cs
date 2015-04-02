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

		public XDocument GetScanConfigurations() {
			return _session.ExecuteCommand (XDocument.Parse ("<get_configs />"), true);
		}

		public XDocument CreateSimpleTarget(string cidrRange, string targetName) {
			return null;
		}

		public XDocument CreateSimpleTask(string name, string comment, Guid configID, Guid targetID) {
			return null;
		}

		public XDocument StartTask(Guid taskID) {
			return null;
		}

		public XDocument GetTasks() {
			return null;
		}

		public XDocument GetTaskResults(Guid taskID) {
			return null;
		}

		public void Dispose()
		{
			_session = null;
		}
		
	}
}
