using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using ShellLink = IWshRuntimeLibrary.IWshShortcut;

namespace ShortcutBay
{
    static class DirectoryCrawler
    {
        public static List<ShellLink> FindShellLinks(string path)
        {
            var foundFiles = new DirectoryInfo(path)
                .GetFiles("*.lnk", SearchOption.AllDirectories).ToList();

            List<ShellLink> retVal = new();

            var banwordFilter = (ShellLink link) =>
            {
                var words = link.GetCaption().Split(' ').Select(x => x.ToLower());

                if (words.Intersect(Program.Settings.IgnoreWords).Any())
                {
                    return false;
                }

                return true;
            };

            foreach (FileInfo file in foundFiles)
            {
                try
                {
                    ShellLink item = ShellLinkFactory.Create(file.FullName);

                    if (banwordFilter(item))
                    {
                        retVal.Add(item);
                    }
                }
                catch (System.Runtime.InteropServices.COMException e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            if (Program.Settings.IgnoreDuplicates)
            {
                retVal = retVal.GroupBy(x => x.GetCaption()).Select(x => x.First()).ToList();
            }

            ShellLinkIconCache.PreloadIcons(retVal);

            return retVal;
        }
    }
}
