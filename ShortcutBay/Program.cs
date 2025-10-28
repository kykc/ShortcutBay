using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace ShortcutBay
{
	static class Program
	{
		public static MainForm MainForm { get; private set; } = null!;
		public static Settings Settings { get; private set; } = new();
		public static bool Net9DarkColorModeEnabled { get; private set; } = false;

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
			Program.Settings = Settings.Load() ?? Settings;

			Application.EnableVisualStyles();
			Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
			Application.SetCompatibleTextRenderingDefault(false);
#if NET9_0_OR_GREATER
			if (Application.SystemColorMode == SystemColorMode.Dark)
			{
				Application.SetColorMode(SystemColorMode.Dark);
				Net9DarkColorModeEnabled = true;
			}
#endif
			Application.ApplicationExit += new EventHandler(onExit);
			MainForm = new MainForm();
			Application.Run(MainForm);
		}

		static void onExit(object? sender, EventArgs e)
		{
			Program.Settings.Save();
		}
    }
}
