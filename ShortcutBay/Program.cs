using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ShortcutBay
{
	static class Program
	{
		public static MainForm MainForm { get; } = new();

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.SetCompatibleTextRenderingDefault(false);
            Application.SetColorMode(SystemColorMode.Dark);
            Application.ApplicationExit += new EventHandler(onExit);
			Application.Run(MainForm);
		}

		static void onExit(object? sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
		}
    }
}
