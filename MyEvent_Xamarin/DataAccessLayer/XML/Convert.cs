using System;
using AppData;
using System.Xml.Linq;

namespace DataAccessLayer.XML
{
    public class Convert
    {
        public Convert()
        {
        }

		public static XElement ToXElement(AppData.Session oSession, string sElementName = "Session")
		{
			XElement oElement = new XElement(sElementName);

			oElement.Add(new XElement("Title", oSession.m_sTitle));
			oElement.Add(new XElement("Description", oSession.m_sDescription));

			return oElement;
		}
		public static string ToXML(AppData.Session oSession, SaveOptions eSaveOptions = SaveOptions.None)
        {
			return ToXElement(oSession).ToString(eSaveOptions);
        }
    }
}
