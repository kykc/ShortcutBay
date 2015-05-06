using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using MainKykc;

namespace MainKykc
{
	class DirectoryCrawler
	{
		private string path;
		protected const string FILE_FILTER = "*.lnk";
		protected ArrayList foundFiles;

		public ArrayList getFoundFiles()
		{
			return this.foundFiles;
		}

		protected void setFoundFiles(ArrayList foundFiles)
		{
			this.foundFiles = foundFiles;
		}

		public string getPath()
		{
			return path;
		}

		private void setPath(string path)
		{
			this.path = path;
			this.omNomNom();
		}

		public DirectoryCrawler(string path)
		{
			this.setPath(path);
		}

		protected void omNomNom()
		{
			DirectoryInfo di = new DirectoryInfo(this.getPath());
			ArrayList rgFiles = new ArrayList();
			rgFiles.AddRange(di.GetFiles(DirectoryCrawler.FILE_FILTER, SearchOption.AllDirectories));
			this.setFoundFiles(rgFiles);
		}

		public ShellLinkList getList()
		{
			ShellLinkList retVal = new ShellLinkList();
			ShellLinkCache cache = new ShellLinkCache(this.getPath());
			
			ArrayList foundFiles = this.getFoundFiles();

			foreach (FileInfo file in foundFiles)
			{
				try
				{
					ShellLink item = new ShellLink(file.FullName);
					Image cachedIcon = cache.getCachedIcon(item.UniqueHash);
					//System.Windows.Forms.MessageBox.Show(cachedIcon.ToString());
					item.IconImage = cachedIcon;

					retVal.Add(item);
				}
				catch (System.Runtime.InteropServices.COMException e)
				{
					Util.writeDebugInfo(e.Message);
				}
			}

			cache.storeCache(retVal.getCache().OuterXml);

			return retVal;
		}
	}
}
