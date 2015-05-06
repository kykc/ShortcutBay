using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace MainKykc
{
	class DetectFullScreen
	{
		[DllImport("user32.dll")]
		protected static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		protected static extern int GetSystemMetrics(int smIndex);

		protected const int SM_CXSCREEN = 0;
		protected const int SM_CYSCREEN = 1;

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		protected static extern bool GetWindowRect(IntPtr hWnd, out W32RECT lpRect);

		[DllImport("user32.dll", SetLastError = true)]
		protected static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		protected static extern void GetClassName(System.IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

		[StructLayout(LayoutKind.Sequential)]
		protected struct W32RECT
		{
			public int Left;
			public int Top;
			public int Right;
			public int Bottom;
		}

		protected static string GetWindowClass(IntPtr hWnd)
		{
			StringBuilder className = new StringBuilder(255);
			GetClassName(hWnd, className, 255);
			return className.ToString();
		}

		public static bool IsForegroundWwindowFullScreen()
		{
			int scrX = GetSystemMetrics(SM_CXSCREEN);
			int	scrY = GetSystemMetrics(SM_CYSCREEN);
			W32RECT wRect;
			IntPtr handle = GetForegroundWindow();
			
			if (handle == IntPtr.Zero)
			{
				return false;
			}
			else if (handle.Equals(FindWindow("Progman", null)))
			{
				return false;
			}
			else if (!GetWindowRect(handle, out wRect))
			{
				return false;
			}
			else
			{
				//System.Windows.Forms.MessageBox.Show(wRect.Left.ToString() + " " + wRect.Top.ToString() + " " + wRect.Right.ToString() + " " + wRect.Bottom.ToString());
				return scrX == (wRect.Right - wRect.Left) && scrY == (wRect.Bottom - wRect.Top);
			}
		}
	}
}