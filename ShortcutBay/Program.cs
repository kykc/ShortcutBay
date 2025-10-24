using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ShortcutBay
{
	static class Program
	{
		public static MainForm MainForm { get; } = new();

		public static string GetTipsText()
		{
			return new[]
			{
				"1. You can add shortcuts to list by simple dragging programs or shortcuts into list.",
				"2. Default keyboard shortcut is set to Ctrl+Q.",
				"3. Keyboard shortcut can be changed in preferences dialog.",
				"4. Preferences dialog can be accessed from tray menu."
			}.Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");
		}

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
