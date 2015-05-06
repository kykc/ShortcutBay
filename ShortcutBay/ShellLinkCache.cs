using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MainKykc;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace MainKykc
{
	class ShellLinkCache : Hashtable
	{
		protected const string CACHE_FILENAME = "cache.xml";
		protected string path;
		public string getPath()
		{
			return this.path;
		}

		protected void setPath(string path)
		{
			this.path = path;
		}

		public ShellLinkCache(string path)
		{
			string fullName = ShellLinkCache.getCacheFullname(path);
			this.setPath(path);
			if (File.Exists(fullName))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(fullName);

				foreach (XmlNode node in doc.DocumentElement.ChildNodes)
				{
					if (node.Name == "ShellLink")
					{
						Hashtable cached = new Hashtable();
						string key = null;

						foreach (XmlNode propNode in node.ChildNodes)
						{
							if (propNode.Name == "hashValue")
							{
								key = propNode.InnerText;
							}
							else
							{
								cached.Add(propNode.Name, propNode.InnerText);
							}
						}

						this.Add(key, cached);
					}
				}
				this.decodeAfterXml();
			}
		}

		protected void decodeAfterXml()
		{
			foreach (string key in this.Keys)
			{
				Hashtable item = this[key] as Hashtable;
				string iconString = item["cachedIcon"] as string;
				item["cachedIcon"] = Util.decodeIcon(iconString);
			}
		}

		protected static string getCacheFullname(string path)
		{
			return path + "/" + ShellLinkCache.CACHE_FILENAME;
		}

		public Hashtable getCachedItem(string hash)
		{
			Hashtable retVal = this[hash] as Hashtable;
			return retVal;
		}

		public void storeCache(string xml)
		{
			File.WriteAllText(ShellLinkCache.getCacheFullname(this.getPath()), xml);
		}

		public Image getCachedIcon(string hash)
		{
			Hashtable item = this[hash] as Hashtable;
			try
			{
				return item["cachedIcon"] as Image;
			}
			catch (NullReferenceException e)
			{
				Util.writeDebugInfo(e.Message);
				return null;
			}
		}

		public static void clearCache()
		{
			try
			{
				string path = 
					Path.GetFullPath(ShortcutBay.Properties.Settings.Default.DbPath) + 
					Path.DirectorySeparatorChar + 
					ShellLinkCache.CACHE_FILENAME;

				File.Delete(path);
			}
			catch (Exception e)
			{
				Util.writeDebugInfo(e.Message);
			}
		}
	}
}
