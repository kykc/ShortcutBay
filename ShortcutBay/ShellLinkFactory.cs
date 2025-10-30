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
        private static IWshRuntimeLibrary.WshShellClass ShellObj => new();

        public static IWshRuntimeLibrary.IWshShortcut Create(string path)
        {
            return (ShellObj.CreateShortcut(path) as IWshRuntimeLibrary.IWshShortcut)!;
        }

        public static string GetUniqueHash(this IWshShortcut subj)
        {
            return Util.CalcMd5(subj.IconLocation + subj.FullName + subj.TargetPath);
        }

        public static string GetCaption(this IWshShortcut subj)
        {
            return Path.GetFileNameWithoutExtension(subj.FullName);
        }

        public static Image GetIcon(this IWshShortcut subj)
        {
            return ShellLinkIconCache.GetIcon(subj);
        }
    }
}
