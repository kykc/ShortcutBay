using System.Diagnostics;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

namespace ShortcutBay
{
    public static class ShellLinkIconCache
    {
        private static Dictionary<string, Image> Cache { get; } = new();

        public static Image GetIcon(IWshShortcut shortcut)
        {
            if (!Cache.ContainsKey(shortcut.GetUniqueHash()))
            {
                Cache[shortcut.GetUniqueHash()] = LoadIcon(shortcut);
            }

            return Cache[shortcut.GetUniqueHash()];
        }

        public static void PreloadIcons(List<IWshShortcut> shortcuts)
        {
            foreach (var shortcut in shortcuts)
            {
                if (!Cache.ContainsKey(shortcut.GetUniqueHash()))
                {
                    Cache[shortcut.GetUniqueHash()] = LoadIcon(shortcut);
                }
            }
        }

        private static Image LoadIcon(IWshShortcut shortcut)
        {
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

            return retVal;
        }

        public static void ClearCache()
        {
            Cache.Clear();
        }
    }
}