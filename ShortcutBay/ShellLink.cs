using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ShortcutBay
{
	public class ShellLink : IWshRuntimeLibrary.IWshShortcut
	{
		private class Native
		{
			[DllImport("shell32.dll", CharSet = CharSet.Auto)]
			public static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

			[DllImport("user32.dll")]
			public static extern bool DestroyIcon(IntPtr hIcon);
		}

		protected static IWshRuntimeLibrary.WshShellClass shellObj = new IWshRuntimeLibrary.WshShellClass();
		protected IWshRuntimeLibrary.IWshShortcut linkObj;

		public ShellLink(string path)
		{
			Load(path);
		}

		protected Image? cachedIcon;

		public Image IconImage
		{
			get
			{
				this.cachedIcon ??= this.getIcon();
				return this.cachedIcon;
			}
			set
			{
				this.cachedIcon = value;
			}
		}

		public Image getIcon()
		{
			string[] strArr = this.IconLocation.Split(new string[] { "," }, StringSplitOptions.None);

			string iconPath = strArr[0];
			int iconIndex = Int32.Parse(strArr[1]);

			if (iconPath == "")
			{
				iconPath = this.TargetPath;
			}

			Image retVal;

			IntPtr hInst = Marshal.GetHINSTANCE(this.GetType().Module);
			IntPtr hIcon = Native.ExtractIcon(hInst, iconPath, iconIndex);

			if (hIcon == IntPtr.Zero)
			{
				retVal = ShortcutBay.ImageCollection.GenericApp.ToBitmap();
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
					retVal = ShortcutBay.ImageCollection.GenericApp.ToBitmap();
					Util.writeDebugInfo(""); //  TODO:
				}
				ico.Dispose();
				Native.DestroyIcon(hIcon);
			}

			return retVal;
		}

		public string Arguments
		{
			get
			{
				return this.linkObj.Arguments;
			}
			set
			{
				this.linkObj.Arguments = value;
			}
		}

		public string Description
		{
			get
			{
				return this.linkObj.Description;
			}
			set
			{
				this.linkObj.Description = value;
			}
		}

		public string FullName
		{
			get
			{
				return this.linkObj.FullName;
			}
		}

		public string Name
		{
			get
			{
				return System.IO.Path.GetFileNameWithoutExtension(this.FullName);
			}
		}

		public string UniqueHash
		{
			get
			{
				return Util.md5(this.IconLocation + this.FullName + this.TargetPath);
			}
		}

		public string Hotkey
		{
			get
			{
				return this.linkObj.Hotkey;
			}
			set
			{
				this.linkObj.Hotkey = value;
			}
		}

		public string IconLocation
		{
			get
			{
				return this.linkObj.IconLocation;
			}
			set
			{
				this.linkObj.IconLocation = value;
			}
		}

		public string RelativePath
		{
			set
			{
				this.linkObj.RelativePath = value;
			}
		}

		public void Load(string path)
		{
			linkObj = (shellObj.CreateShortcut(path) as IWshRuntimeLibrary.IWshShortcut)!;
		}

		public void Save()
		{
			this.linkObj.Save();
		}

		public string TargetPath
		{
			get
			{
				return this.linkObj.TargetPath;
			}
			set
			{
				this.linkObj.TargetPath = value;
			}
		}

		public int WindowStyle
		{
			get
			{
				return this.linkObj.WindowStyle;
			}
			set
			{
				this.linkObj.WindowStyle = value;
			}
		}

		public string WorkingDirectory
		{
			get
			{
				return this.linkObj.WorkingDirectory;
			}
			set
			{
				this.linkObj.WorkingDirectory = value;
			}
		}

		public XmlElement? XmlRepresentation
		{
			get
			{
				XmlDocument doc = new XmlDocument();

				XmlElement? element = doc.AppendChild(doc.CreateElement("ShellLink")) as XmlElement;

				XmlElement? linkFilePathElement = element?.AppendChild(doc.CreateElement("linkFilePath")) as XmlElement;
				XmlElement? cachedIconElement = element?.AppendChild(doc.CreateElement("cachedIcon")) as XmlElement;
				XmlElement? hashElement = element?.AppendChild(doc.CreateElement("hashValue")) as XmlElement;

				if (linkFilePathElement != null && cachedIconElement != null && hashElement != null)
				{
					linkFilePathElement.InnerText = this.FullName;

					string iconString = Util.encodeIcon(this.IconImage);

					cachedIconElement.InnerText = iconString;
					hashElement.InnerText = this.UniqueHash;
				}

				return element;
			}
		}
	}
}
