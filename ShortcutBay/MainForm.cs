using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ShellLink = IWshRuntimeLibrary.IWshShortcut;

// TODO: Assign custom hotkey user friendly names of shortcuts.
// TODO: file already exists handling.
// TODO: Add item: remember last dialog directory.
// TODO: Create some sample shortcuts(like explorer, calculator, etc) on first start if db is empty.

// FUTURE: grouping, recently opened.

namespace ShortcutBay
{
    public partial class MainForm : Form
    {
        protected SystemHotkey? globalKeyboardHook;
        protected List<ShellLink>? mainLinkList;
        public PreferencesForm? preferencesForm = null;
        public HelpForm? helpForm = null;

        [DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLocked { get; set; } = false;

        [DefaultValue(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool WasShown { get; set; } = false;

        public MainForm()
        {
            this.ToggleVisibility(this, EventArgs.Empty);
            InitializeComponent();
            this.Text = Program.Settings.AppName + " " + Program.Settings.Version;
            this.trayIcon.Text = this.Text;
            this.trayIcon.Icon = ImageCollection.TrayIcon;
            this.Icon = ImageCollection.MainIcon;
        }

        public ShellLinkListView GetListView()
        {
            return this.shellLinkListView;
        }

        public void ToggleVisibility(object? sender, System.EventArgs e)
        {
            if (!this.IsLocked)
            {
                if (!(Util.IsInFullScreenMode() && Program.Settings.ExcludeFullScreen))
                {
                    bool wasVisible = this.Visible;
                    //qthis.Size = Program.Settings.MainFormSize;
                    Util.ToggleVisibility(this);
                    if (wasVisible && !this.Visible)
                    {
                        this.searhBox.ClearText();
                    }
                    this.UpdateZOrder();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Init();
            if (!Program.Settings.WasStartedBefore)
            {
                this.trayIcon.ShowBalloonTip(30, "Tips", Program.GetTipsText(), new ToolTipIcon());
                Program.Settings.WasStartedBefore = true;
                Program.Settings.Save();
            }
        }

        public void Init()
        {
            string path = Path.GetFullPath(Program.Settings.DbPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            this.mainLinkList = DirectoryCrawler.FindShellLinks(path);
            string q = this.shellLinkListView.LastFilter;
            int i = this.shellLinkListView.LastIndex;
            this.shellLinkListView.Init(this.mainLinkList);
            this.searhBox.ClearText();
            this.searhBox.appendText(q);
            this.shellLinkListView.SelectItemByIndex(i);
            this.TopMost = Program.Settings.AlwaysOnTop;
            Enum.TryParse(Program.Settings.ShortcutKey, out Shortcut shortcut);
            this.globalKeyboardHook = new SystemHotkey(this.components, ToggleVisibility, shortcut);
        }

        private void searhBox_TextChanged(object sender, EventArgs e)
        {
            string filter = this.searhBox.Text;
            if (this.searhBox.IsEmpty)
            {
                filter = "";
            }

            shellLinkListView.Fill(filter);
        }

        private void shellLinkListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.searhBox.BackspaceEmulate();
                e.Handled = true;
            }
            else if (e.KeyCode is Keys.Up or Keys.Down)
            {
                this.shellLinkListView.HandleArrows(e.KeyCode);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.shellLinkListView.HandleExecute();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {

                this.shellLinkListView.HandleDelete();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.Init();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.ToggleVisibility(this, EventArgs.Empty);
                e.Handled = true;
            }
        }

        private void shellLinkListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 0x20 && e.KeyChar <= 0x7E)
            {
                this.searhBox.appendText(e.KeyChar.ToString());
                this.searhBox.Select(this.searhBox.Text.Length, 0);
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.ToggleVisibility(this, EventArgs.Empty);
                e.Cancel = true;
            }
            else
            {
                if (this.Location.X > 0 && this.Location.Y > 0)
                {
                    PositionCalculator.StorePosition(this.Location.X, this.Location.Y);
                }
            }
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ToggleVisibility(this, EventArgs.Empty);
        }

        private void shellLinkListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e?.Data?.GetDataPresent(DataFormats.FileDrop, false) is true)
            {
                e.Effect = DragDropEffects.Link;
            }
            else if (e != null)
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void shellLinkListView_DragDrop(object sender, DragEventArgs e)
        {
            var maybeFileList = e?.Data?.GetData(DataFormats.FileDrop);
            string[] files = maybeFileList as string[] ?? [];

            foreach (string file in files)
            {
                Util.AddListItem(file);
                this.Init();
            }
        }

        private void shellLinkListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.shellLinkListView.HandleExecute();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (Program.Settings.HideOnLostFocus && !this.IsLocked && this.WasShown)
            {
                Util.ProperHide(this);
            }
        }
    }
}
