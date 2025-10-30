using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

namespace ShortcutBay
{
    public static class ShellLinkFactory
    {
        private const string CacheFilename = "cache.xml";
        private static readonly string CacheLocation = Path.Join(Settings.DetermineStateLocation(), CacheFilename);
        private static IWshRuntimeLibrary.WshShellClass ShellObj => new();
        private static readonly Dictionary<string, Image> IconCache = new();
        private static bool FileCacheLoaded { get; set; } = false;

        public static IWshRuntimeLibrary.IWshShortcut Create(string path)
        {
            return (ShellObj.CreateShortcut(path) as IWshRuntimeLibrary.IWshShortcut)!;
        }

        private static void SetCachedIcon(string hash, Image icon)
        {
            IconCache[hash] = icon;
        }

        public static void ClearFileCache()
        {
            System.IO.File.Delete(CacheLocation);
        }

        private static void LoadFileCache()
        {
            if (System.IO.File.Exists(CacheLocation))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(CacheLocation);

                System.Collections.IEnumerable? list = doc.DocumentElement?.ChildNodes;

                Dictionary<string, Dictionary<string, string>> parsed = new();

                foreach (XmlNode node in list ?? new List<XmlNode>())
                {
                    if (node.Name == "ShellLink")
                    {
                        Dictionary<string, string> cached = new();
                        string? key = null;

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

                        if (key != null)
                        {
                            parsed.Add(key, cached);
                        }
                    }
                }

                foreach (string key in parsed.Keys)
                {
                    var item = parsed[key];
                    string iconString = item["cachedIcon"];

                    if (Util.decodeIcon(iconString) is { } iconImage)
                    {
                        IconCache[key] = iconImage;
                    }
                }

                FileCacheLoaded = true;
            }
        }

        public static void UpdateAndStoreFileCache(List<IWshShortcut> shortcuts)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", null, null);
            doc.AppendChild(dec);

            XmlElement rootNode  = doc.CreateElement("Cache");
            doc.InsertBefore(dec, doc.DocumentElement);
            doc.AppendChild(rootNode);

            foreach (IWshShortcut item in shortcuts)
            {
                string? xml = item.ToXml()?.OuterXml;

                if (xml != null)
                {
                    XmlDocumentFragment docFragment = doc.CreateDocumentFragment();
                    docFragment.InnerXml = xml;
                    doc.DocumentElement?.AppendChild(docFragment);
                }
            }

            System.IO.File.WriteAllText(CacheLocation, doc.OuterXml);
        }

        private static Image GetCachedIcon(IWshRuntimeLibrary.IWshShortcut shortcut)
        {
            if (!FileCacheLoaded)
            {
                LoadFileCache();
            }

            if (IconCache.TryGetValue(shortcut.GetUniqueHash(), out var icon))
            {
                return icon;
            }

            string[] strArr = shortcut.IconLocation.Split([","], StringSplitOptions.None);

            string iconPath = strArr[0];
            int iconIndex = Int32.Parse(strArr[1]);

            if (iconPath == "")
            {
                iconPath = shortcut.TargetPath;
            }

            Image retVal;

            IntPtr hInst = Marshal.GetHINSTANCE(shortcut.GetType().Module);
            IntPtr hIcon = Win32.Shell32.ExtractIcon(hInst, iconPath, iconIndex);

            if (hIcon == IntPtr.Zero)
            {
                retVal = ImageCollection.GenericApp.ToBitmap();
            }
            else
            {
                Icon ico = Icon.FromHandle(hIcon);
                try
                {
                    retVal = ico.ToBitmap();
                }
                catch (ArgumentException)
                {
                    retVal = ImageCollection.GenericApp.ToBitmap();
                    Debug.WriteLine(""); //  TODO:
                }
                ico.Dispose();
                Win32.User32.DestroyIcon(hIcon);
            }

            IconCache.Add(shortcut.GetUniqueHash(), retVal);
            return retVal;
        }

        private static string GetUniqueHash(this IWshShortcut subj)
        {
            return Util.md5(subj.IconLocation + subj.FullName + subj.TargetPath);
        }

        public static string GetCaption(this IWshShortcut subj)
        {
            return Path.GetFileNameWithoutExtension(subj.FullName);
        }

        public static Image GetIcon(this IWshShortcut subj)
        {
            return GetCachedIcon(subj);
        }

        private static XmlElement? ToXml(this IWshShortcut subj)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement? element = doc.AppendChild(doc.CreateElement("ShellLink")) as XmlElement;

            XmlElement? linkFilePathElement = element?.AppendChild(doc.CreateElement("linkFilePath")) as XmlElement;
            XmlElement? cachedIconElement = element?.AppendChild(doc.CreateElement("cachedIcon")) as XmlElement;
            XmlElement? hashElement = element?.AppendChild(doc.CreateElement("hashValue")) as XmlElement;

            if (linkFilePathElement != null && cachedIconElement != null && hashElement != null)
            {
                linkFilePathElement.InnerText = subj.FullName;

                string iconString = Util.encodeIcon(GetCachedIcon(subj));

                cachedIconElement.InnerText = iconString;
                hashElement.InnerText = subj.GetUniqueHash();
            }

            return element;
        }
    }
}
