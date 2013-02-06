using System;
using System.Collections.Generic;
using System.Xml;

namespace AutoAssess.Data.OpenVAS.Objects
{
	public interface IOpenVASObject
	{
		List<IOpenVASObject> Parse(XmlDocument response);
	}
}

