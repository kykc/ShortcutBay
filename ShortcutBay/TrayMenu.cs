using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MainKykc;

namespace ShortcutBay
{
	class TrayMenu : ContextMenuStrip
	{
		public TrayMenu()
		{
			this.init();
		}

		protected void init()
		{
			//this.Items.Add(Util.createToolStripMenuItem("&Clear Cache", new EventHandler(handleClearCache)));
			this.Items.Add(Util.createToolStripMenuItem("&Help", new EventHandler(handleHelp)));
			this.Items.Add(Util.createToolStripMenuItem("&Preferences", new EventHandler(handlePreferences)));
			//this.Items.Add(Util.createToolStripMenuItem("&Refresh", new EventHandler(handleRefresh)));
			this.Items.Add(Util.createToolStripMenuItem("&Exit", new EventHandler(handleExit)));
		}

		public void handlePreferences(object sender, EventArgs e)
		{
			if (Util.getMainForm().preferencesForm == null)
			{
				Util.getMainForm().lockForm();
				Util.getMainForm().preferencesForm = new PreferencesForm();
				Util.getMainForm().preferencesForm.ShowDialog();
			}
			else
			{
				Util.getMainForm().preferencesForm.BringToFront();
			}
		}

		public void handleHelp(object sender, EventArgs e)
		{
			if (Util.getMainForm().helpForm == null)
			{
				Util.getMainForm().lockForm();
				Util.getMainForm().helpForm = new HelpForm();
				Util.getMainForm().helpForm.ShowDialog();
			}
			else
			{
				Util.getMainForm().helpForm.BringToFront();
			}
		}

		public void handleExit(object sender, EventArgs e)
		{
			Application.Exit();
		}

		public void handleRefresh(object sender, EventArgs e)
		{
			Util.getMainForm().initForm();
		}

		public void handleClearCache(object sender, EventArgs e)
		{
			ShellLinkCache.clearCache();
			Util.getMainForm().initForm();
		}
	}
}
