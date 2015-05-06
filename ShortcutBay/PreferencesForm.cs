using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MainKykc;

namespace ShortcutBay
{
	public partial class PreferencesForm : Form
	{
		public bool PreferencesChanged
		{
			get
			{
				return this.preferencesApply.Enabled;
			}
			set
			{
				this.preferencesApply.Enabled = value;
			}
		}

		public PreferencesForm()
		{
			InitializeComponent();
			Util.properShow(Util.getMainForm());
		}

		private void preferencesOk_Click(object sender, EventArgs e)
		{
			this.fromForm();
			this.Close();
		}

		private void PreferencesForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Util.getMainForm().unlockForm();
		}

		private void clearCacheButton_Click(object sender, EventArgs e)
		{
			this.PreferencesChanged = true;
			ShellLinkCache.clearCache();
			Util.getMainForm().initForm();
		}

		private void preferencesApply_Click(object sender, EventArgs e)
		{
			this.fromForm();
		}

		private void preferencesCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void refreshListButton_Click(object sender, EventArgs e)
		{
			Util.getMainForm().initForm();
			this.PreferencesChanged = true;
		}

		private void resetPositionButton_Click(object sender, EventArgs e)
		{
			// Works only if form is shown..
			Util.getMainForm().Location = new Point(0, 0);
			this.PreferencesChanged = true;
		}

		private void PreferencesForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Util.getMainForm().preferencesForm = null;
		}

		private void PreferencesForm_Load(object sender, EventArgs e)
		{
			this.shortcutKeySelect.DataSource = Enum.GetValues(typeof(Shortcut));
			this.toForm();
		}

		private void toForm()
		{
			this.alwaysOnTop.Checked = Properties.Settings.Default.AlwaysOnTop;
			this.hideOnLostFocus.Checked = Properties.Settings.Default.HideOnLostFocus;
			this.ignoreFullScreen.Checked = Properties.Settings.Default.ExcludeFullScreen;
			this.shortcutKeySelect.SelectedItem = Properties.Settings.Default.ShortcutKey;
			this.PreferencesChanged = false;
		}

		private void fromForm()
		{
			Properties.Settings.Default.AlwaysOnTop = this.alwaysOnTop.Checked;
			Properties.Settings.Default.HideOnLostFocus = this.hideOnLostFocus.Checked;
			Properties.Settings.Default.ExcludeFullScreen = this.ignoreFullScreen.Checked;
			Properties.Settings.Default.ShortcutKey = (Shortcut) shortcutKeySelect.SelectedValue;
			Util.getMainForm().initForm();
			this.PreferencesChanged = false;
		}

		private void alwaysOnTop_CheckedChanged(object sender, EventArgs e)
		{
			this.PreferencesChanged = true;
		}

		private void hideOnLostFocus_CheckedChanged(object sender, EventArgs e)
		{
			this.PreferencesChanged = true;
		}

		private void ignoreFullScreen_CheckedChanged(object sender, EventArgs e)
		{
			this.PreferencesChanged = true;
		}

		private void shortcutKeySelect_SelectedValueChanged(object sender, EventArgs e)
		{
			this.PreferencesChanged = true;
		}
	}
}
