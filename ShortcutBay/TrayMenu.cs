using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ShortcutBay
{
    class TrayMenu : ContextMenuStrip
    {
        public TrayMenu()
        {
            this.Init();
        }

        protected void Init()
        {
            //this.Items.Add(Util.createToolStripMenuItem("&Clear Cache", new EventHandler(handleClearCache)));
            this.Items.Add(Util.CreateToolStripMenuItem("&Help", new EventHandler(HandleHelp)));
            this.Items.Add(Util.CreateToolStripMenuItem("&Preferences", new EventHandler(HandlePreferences)));
            //this.Items.Add(Util.createToolStripMenuItem("&Refresh", new EventHandler(handleRefresh)));
            this.Items.Add(Util.CreateToolStripMenuItem("&Exit", new EventHandler(HandleExit)));
        }

        public void HandlePreferences(object? sender, EventArgs e)
        {
            var preferencesForm = Program.MainForm.preferencesForm;

            if (preferencesForm == null)
            {
                Program.MainForm.IsLocked = true;
                Program.MainForm.preferencesForm = preferencesForm = new PreferencesForm();
                preferencesForm.ShowDialog();
            }
            else
            {
                preferencesForm.BringToFront();
            }
        }

        public void HandleHelp(object? sender, EventArgs e)
        {
            var helpForm = Program.MainForm.helpForm;

            if (helpForm == null)
            {
                Program.MainForm.IsLocked = true;
                Program.MainForm.helpForm = helpForm = new HelpForm();
                helpForm.ShowDialog();
            }
            else
            {
                helpForm.BringToFront();
            }
        }

        public void HandleExit(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        public void HandleRefresh(object? sender, EventArgs e)
        {
            Program.MainForm.Init();
        }

        public void HandleClearCache(object? sender, EventArgs e)
        {
            ShellLinkIconCache.ClearCache();
            Program.MainForm.Init();
        }
    }
}
