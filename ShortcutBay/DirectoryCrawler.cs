using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Drawing;
using MainKykc;
using System.Linq;

namespace MainKykc
{
	class DirectoryCrawler
	{
		private string path;
		protected const string FILE_FILTER = "*.lnk";
		protected List<FileInfo> foundFiles;

		public List<FileInfo> getFoundFiles()
		{
			return this.foundFiles;
		}

		protected void setFoundFiles(List<FileInfo> foundFiles)
		{
			this.foundFiles = foundFiles;
		}

		public string getPath()
		{
			return path;
		}

		private void setPath(string newPath)
		{
			this.path = newPath;
			this.omNomNom();
		}

		public DirectoryCrawler(string path)
		{
			this.setPath(path);
		}

		protected void omNomNom()
		{
			DirectoryInfo di = new DirectoryInfo(this.getPath());
			
			this.setFoundFiles(di.GetFiles(DirectoryCrawler.FILE_FILTER, SearchOption.AllDirectories).ToList());
		}

		public ShellLinkList getList()
		{
			ShellLinkList retVal = new ShellLinkList();
			ShellLinkCache cache = new ShellLinkCache(this.getPath());

            List<FileInfo> foundFiles = this.getFoundFiles();

			// TODO: configurable
			var banwords = new List<string> { "manual", "readme", "uninstall", "documentation", "donate", "help", "удалить" };

			var banwordFilter = (ShellLink link) =>
			{
				var words = link.Name.Split(' ').Select(x => x.ToLower());

				if (words.Intersect(banwords).Any())
				{
					return false;
				}

				return true;
			};

			foreach (FileInfo file in foundFiles)
			{
				try
				{
					ShellLink item = new ShellLink(file.FullName);
					Image cachedIcon = cache.getCachedIcon(item.UniqueHash);
					//System.Windows.Forms.MessageBox.Show(cachedIcon.ToString());
					item.IconImage = cachedIcon;

					if (banwordFilter(item))
					{
						retVal.Add(item);
					}
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
