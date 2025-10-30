using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ShortcutBay
{
    static class DetectFullScreen
    {
        public static bool CheckForegroundWindowIsFullscreen()
        {
            int scrX = Win32.User32.GetSystemMetrics(Win32.User32.SM_CXSCREEN);
            int	scrY = Win32.User32.GetSystemMetrics(Win32.User32.SM_CYSCREEN);
            IntPtr handle = Win32.User32.GetForegroundWindow();

            if (handle == IntPtr.Zero)
            {
                return false;
            }
            else if (handle.Equals(Win32.User32.FindWindow("Progman", null)))
            {
                return false;
            }
            else if (!Win32.User32.GetWindowRect(handle, out var wRect))
            {
                return false;
            }
            else
            {
                return scrX == (wRect.Right - wRect.Left) && scrY == (wRect.Bottom - wRect.Top);
            }
        }
    }
}