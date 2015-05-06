using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using MainKykc;

// TODO: Assign custom hotkey user friendly names of shortcuts.
// TODO: file already exists handling.
// TODO: Add item: remember last dialog directory.
// TODO: Create some sample shortcuts(like explorer, calculator, etc) on first start if db is empty.
// TODO: RC1 block: icons, advanced tips.

// FUTURE: grouping, recently opened.

namespace ShortcutBay
{
	public partial class MainForm : Form
	{
		protected SystemHotkey globalKeyboardHook;
		protected ShellLinkList mainLinkList;
		protected bool wasShown = false;
		public PreferencesForm preferencesForm = null;
		public HelpForm helpForm = null;
		protected bool locked = false;

		public void lockForm()
		{
			this.locked = true;
		}

		public void unlockForm()
		{
			this.locked = false;
		}

		protected bool isLockedForm()
		{
			return this.locked;
		}

		public bool WasShown
		{
			get
			{
				return this.wasShown;
			}
			set
			{
				this.wasShown = true;
			}
		}

		public MainForm()
		{
			this.toggleVisibility(this, new System.EventArgs());
			InitializeComponent();
			this.Text = Properties.Settings.Default.AppName + " " + Properties.Settings.Default.Version;
			this.trayIcon.Text = this.Text;
			this.trayIcon.Icon = ImageCollection.TrayIcon;
			this.Icon = ImageCollection.MainIcon;

			// First access to this property takes some time. So let's do this on load.
			System.Collections.Specialized.StringCollection dummy = Properties.Settings.Default.MainFormPositionArr;
		}

		public ShellLinkListView getListView()
		{
			return this.shellLinkListView;
		}

		public void toggleVisibility(object sender, System.EventArgs e)
		{
			if (!this.isLockedForm())
			{
				if (!(Util.isInFullScreenMode() && Properties.Settings.Default.ExcludeFullScreen))
				{
					bool wasVisible = this.Visible;
					this.Size = Properties.Settings.Default.MainFormSize;
					Util.toggleVisibility(this);
					if (wasVisible && !this.Visible)
					{
						this.searhBox.clearText();
					}
					this.UpdateZOrder();
				}
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.initForm();
			if (!Properties.Settings.Default.WasStartedBefore)
			{
				this.trayIcon.ShowBalloonTip(30, "Tips", TextCollection.Tips, new ToolTipIcon());
				Properties.Settings.Default.WasStartedBefore = true;
				Properties.Settings.Default.Save();
			}
		}

		public void initForm()
		{
			string path = Path.GetFullPath(Properties.Settings.Default.DbPath);
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			DirectoryCrawler crawler = new DirectoryCrawler(path);
			this.mainLinkList = crawler.getList();
			string q = this.shellLinkListView.getLastFilter();
			int i = this.shellLinkListView.getLastIndex();
			this.shellLinkListView.init(this.mainLinkList);
			this.searhBox.clearText();
			this.searhBox.appendText(q);
			this.shellLinkListView.selectItemByIndex(i);
			this.TopMost = Properties.Settings.Default.AlwaysOnTop;
			this.globalKeyboardHook = new MainKykc.SystemHotkey(this.components);
			//MessageBox.Show(Properties.Settings.Default.ShortcutKey.ToString());
			this.globalKeyboardHook.Shortcut = Properties.Settings.Default.ShortcutKey;
			this.globalKeyboardHook.Pressed += new System.EventHandler(this.toggleVisibility);
		}

		private void searhBox_TextChanged(object sender, EventArgs e)
		{
			string filter = this.searhBox.Text;
			if (this.searhBox.IsEmpty)
			{
				filter = "";
			}

			shellLinkListView.fill(filter);
		}

		private void shellLinkListView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Back)
			{
				this.searhBox.backspaceEmulate();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
			{
				this.shellLinkListView.handleArrows(e.KeyCode);
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Enter)
			{
				this.shellLinkListView.handleExecute();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Delete)
			{
				
				this.shellLinkListView.handleDelete();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.F5)
			{
				this.initForm();
				e.Handled = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.toggleVisibility(this, new EventArgs());
				e.Handled = true;
			}
		}

		private void shellLinkListView_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar >= 0x21 && e.KeyChar <= 0x7E)
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
				this.toggleVisibility(this, new EventArgs());
				e.Cancel = true;
			}
			else
			{
				if (this.Location.X > 0 && this.Location.Y > 0)
				{
					PositionCalculator.storePosition(this.Location.X, this.Location.Y);
				}
			}
		}

		private void trayIcon_DoubleClick(object sender, EventArgs e)
		{
			this.toggleVisibility(this, new EventArgs());
		}

		private void shellLinkListView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
			{
				e.Effect = DragDropEffects.Link;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void shellLinkListView_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

			foreach (string file in files)
			{
				Util.addListItem(file);
				this.initForm();
			}
		}

		private void shellLinkListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.shellLinkListView.handleExecute();
		}

		private void MainForm_Deactivate(object sender, EventArgs e)
		{
			if (Properties.Settings.Default.HideOnLostFocus && !this.isLockedForm() && this.WasShown)
			{
				Util.properHide(this);
			}
		}

		private void shellLinkListView_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
