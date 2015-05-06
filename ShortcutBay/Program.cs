using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortcutBay
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.ApplicationExit += new EventHandler(onExit);
			Application.Run(new MainForm());
		}

		static void onExit(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
		}
	}
}
