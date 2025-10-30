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

        public void handlePreferences(object? sender, EventArgs e)
        {
            var preferencesForm = Program.MainForm.preferencesForm;

            if (preferencesForm == null)
            {
                Program.MainForm.lockForm();
                Program.MainForm.preferencesForm = preferencesForm = new PreferencesForm();
                preferencesForm.ShowDialog();
            }
            else
            {
                preferencesForm.BringToFront();
            }
        }

        public void handleHelp(object? sender, EventArgs e)
        {
            var helpForm = Program.MainForm.helpForm;

            if (helpForm == null)
            {
                Program.MainForm.lockForm();
                Program.MainForm.helpForm = helpForm = new HelpForm();
                helpForm.ShowDialog();
            }
            else
            {
                helpForm.BringToFront();
            }
        }

        public void handleExit(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        public void handleRefresh(object? sender, EventArgs e)
        {
            Program.MainForm.initForm();
        }

        public void handleClearCache(object? sender, EventArgs e)
        {

            ShellLinkFactory.ClearFileCache();
            Program.MainForm.initForm();
        }
    }
}
