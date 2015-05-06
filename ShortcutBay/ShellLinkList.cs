using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.IO;

namespace MainKykc
{
	public class ShellLinkList : Hashtable
	{
		public void Add(ShellLink value)
		{
			string key = value.FullName;
			base.Add(key, value);
		}

		public XmlDocument getCache()
		{
			XmlDocument doc = new XmlDocument();
			XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
			doc.AppendChild(dec);
			
			XmlElement rootNode  = doc.CreateElement("Cache");
			doc.InsertBefore(dec, doc.DocumentElement); 
			doc.AppendChild(rootNode);

			foreach (ShellLink item in this.Values)
			{
				string xml = item.XmlRepresentation.OuterXml;
				XmlDocumentFragment docFragment = doc.CreateDocumentFragment();
				docFragment.InnerXml = xml;
				doc.DocumentElement.AppendChild(docFragment);
			}
			
			return doc;
		}

		public ShellLinkList find(string filter)
		{
			ShellLinkList retVal = new ShellLinkList();

			foreach (string key in this.Keys)
			{
				ShellLink item = this[key] as ShellLink;
				if (Path.GetFileNameWithoutExtension(item.FullName).ToLower().Contains(filter.ToLower()))
				{
					retVal.Add(item);
				}
			}

			return retVal;
		}
	}
}
