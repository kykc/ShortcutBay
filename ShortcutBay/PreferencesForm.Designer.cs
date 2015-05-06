namespace ShortcutBay
{
	partial class PreferencesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.preferencesTabControl = new System.Windows.Forms.TabControl();
			this.generalPreferencesTab = new System.Windows.Forms.TabPage();
			this.hotkeySettingsBox = new System.Windows.Forms.GroupBox();
			this.shortcutKeySelect = new System.Windows.Forms.ComboBox();
			this.uiSettingsBox = new System.Windows.Forms.GroupBox();
			this.ignoreFullScreen = new System.Windows.Forms.CheckBox();
			this.hideOnLostFocus = new System.Windows.Forms.CheckBox();
			this.alwaysOnTop = new System.Windows.Forms.CheckBox();
			this.advancedPreferencesTab = new System.Windows.Forms.TabPage();
			this.cacheRefreshGroup = new System.Windows.Forms.GroupBox();
			this.resetPositionButton = new System.Windows.Forms.Button();
			this.clearCacheButton = new System.Windows.Forms.Button();
			this.refreshListButton = new System.Windows.Forms.Button();
			this.preferencesOk = new System.Windows.Forms.Button();
			this.preferencesCancel = new System.Windows.Forms.Button();
			this.preferencesApply = new System.Windows.Forms.Button();
			this.preferencesTabControl.SuspendLayout();
			this.generalPreferencesTab.SuspendLayout();
			this.hotkeySettingsBox.SuspendLayout();
			this.uiSettingsBox.SuspendLayout();
			this.advancedPreferencesTab.SuspendLayout();
			this.cacheRefreshGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// preferencesTabControl
			// 
			this.preferencesTabControl.Controls.Add(this.generalPreferencesTab);
			this.preferencesTabControl.Controls.Add(this.advancedPreferencesTab);
			this.preferencesTabControl.Location = new System.Drawing.Point(12, 12);
			this.preferencesTabControl.Name = "preferencesTabControl";
			this.preferencesTabControl.SelectedIndex = 0;
			this.preferencesTabControl.Size = new System.Drawing.Size(396, 318);
			this.preferencesTabControl.TabIndex = 0;
			// 
			// generalPreferencesTab
			// 
			this.generalPreferencesTab.Controls.Add(this.hotkeySettingsBox);
			this.generalPreferencesTab.Controls.Add(this.uiSettingsBox);
			this.generalPreferencesTab.Location = new System.Drawing.Point(4, 22);
			this.generalPreferencesTab.Name = "generalPreferencesTab";
			this.generalPreferencesTab.Padding = new System.Windows.Forms.Padding(3);
			this.generalPreferencesTab.Size = new System.Drawing.Size(388, 292);
			this.generalPreferencesTab.TabIndex = 0;
			this.generalPreferencesTab.Text = "General";
			this.generalPreferencesTab.UseVisualStyleBackColor = true;
			// 
			// hotkeySettingsBox
			// 
			this.hotkeySettingsBox.Controls.Add(this.shortcutKeySelect);
			this.hotkeySettingsBox.Location = new System.Drawing.Point(6, 102);
			this.hotkeySettingsBox.Name = "hotkeySettingsBox";
			this.hotkeySettingsBox.Size = new System.Drawing.Size(376, 51);
			this.hotkeySettingsBox.TabIndex = 1;
			this.hotkeySettingsBox.TabStop = false;
			this.hotkeySettingsBox.Text = "Shortcut Key Settings";
			// 
			// shortcutKeySelect
			// 
			this.shortcutKeySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.shortcutKeySelect.FormattingEnabled = true;
			this.shortcutKeySelect.Location = new System.Drawing.Point(6, 19);
			this.shortcutKeySelect.Name = "shortcutKeySelect";
			this.shortcutKeySelect.Size = new System.Drawing.Size(120, 21);
			this.shortcutKeySelect.TabIndex = 0;
			this.shortcutKeySelect.SelectedValueChanged += new System.EventHandler(this.shortcutKeySelect_SelectedValueChanged);
			// 
			// uiSettingsBox
			// 
			this.uiSettingsBox.Controls.Add(this.ignoreFullScreen);
			this.uiSettingsBox.Controls.Add(this.hideOnLostFocus);
			this.uiSettingsBox.Controls.Add(this.alwaysOnTop);
			this.uiSettingsBox.Location = new System.Drawing.Point(6, 6);
			this.uiSettingsBox.Name = "uiSettingsBox";
			this.uiSettingsBox.Size = new System.Drawing.Size(379, 90);
			this.uiSettingsBox.TabIndex = 0;
			this.uiSettingsBox.TabStop = false;
			this.uiSettingsBox.Text = "UI Settings";
			// 
			// ignoreFullScreen
			// 
			this.ignoreFullScreen.AutoSize = true;
			this.ignoreFullScreen.Location = new System.Drawing.Point(6, 65);
			this.ignoreFullScreen.Name = "ignoreFullScreen";
			this.ignoreFullScreen.Size = new System.Drawing.Size(318, 17);
			this.ignoreFullScreen.TabIndex = 2;
			this.ignoreFullScreen.Text = "Ignore hotkey when fullscreen mode (video or game) detected";
			this.ignoreFullScreen.UseVisualStyleBackColor = true;
			this.ignoreFullScreen.CheckedChanged += new System.EventHandler(this.ignoreFullScreen_CheckedChanged);
			// 
			// hideOnLostFocus
			// 
			this.hideOnLostFocus.AutoSize = true;
			this.hideOnLostFocus.Location = new System.Drawing.Point(6, 42);
			this.hideOnLostFocus.Name = "hideOnLostFocus";
			this.hideOnLostFocus.Size = new System.Drawing.Size(120, 17);
			this.hideOnLostFocus.TabIndex = 1;
			this.hideOnLostFocus.Text = "Hide On Lost Focus";
			this.hideOnLostFocus.UseVisualStyleBackColor = true;
			this.hideOnLostFocus.CheckedChanged += new System.EventHandler(this.hideOnLostFocus_CheckedChanged);
			// 
			// alwaysOnTop
			// 
			this.alwaysOnTop.AutoSize = true;
			this.alwaysOnTop.Location = new System.Drawing.Point(6, 19);
			this.alwaysOnTop.Name = "alwaysOnTop";
			this.alwaysOnTop.Size = new System.Drawing.Size(98, 17);
			this.alwaysOnTop.TabIndex = 0;
			this.alwaysOnTop.Text = "Always On Top";
			this.alwaysOnTop.UseVisualStyleBackColor = true;
			this.alwaysOnTop.CheckedChanged += new System.EventHandler(this.alwaysOnTop_CheckedChanged);
			// 
			// advancedPreferencesTab
			// 
			this.advancedPreferencesTab.Controls.Add(this.cacheRefreshGroup);
			this.advancedPreferencesTab.Location = new System.Drawing.Point(4, 22);
			this.advancedPreferencesTab.Name = "advancedPreferencesTab";
			this.advancedPreferencesTab.Padding = new System.Windows.Forms.Padding(3);
			this.advancedPreferencesTab.Size = new System.Drawing.Size(388, 292);
			this.advancedPreferencesTab.TabIndex = 1;
			this.advancedPreferencesTab.Text = "Advanced";
			this.advancedPreferencesTab.UseVisualStyleBackColor = true;
			// 
			// cacheRefreshGroup
			// 
			this.cacheRefreshGroup.Controls.Add(this.resetPositionButton);
			this.cacheRefreshGroup.Controls.Add(this.clearCacheButton);
			this.cacheRefreshGroup.Controls.Add(this.refreshListButton);
			this.cacheRefreshGroup.Location = new System.Drawing.Point(6, 6);
			this.cacheRefreshGroup.Name = "cacheRefreshGroup";
			this.cacheRefreshGroup.Size = new System.Drawing.Size(376, 50);
			this.cacheRefreshGroup.TabIndex = 2;
			this.cacheRefreshGroup.TabStop = false;
			this.cacheRefreshGroup.Text = "Troubleshooting";
			// 
			// resetPositionButton
			// 
			this.resetPositionButton.Location = new System.Drawing.Point(216, 19);
			this.resetPositionButton.Name = "resetPositionButton";
			this.resetPositionButton.Size = new System.Drawing.Size(154, 23);
			this.resetPositionButton.TabIndex = 2;
			this.resetPositionButton.Text = "Reset Main Window Position";
			this.resetPositionButton.UseVisualStyleBackColor = true;
			this.resetPositionButton.Click += new System.EventHandler(this.resetPositionButton_Click);
			// 
			// clearCacheButton
			// 
			this.clearCacheButton.Location = new System.Drawing.Point(6, 19);
			this.clearCacheButton.Name = "clearCacheButton";
			this.clearCacheButton.Size = new System.Drawing.Size(108, 23);
			this.clearCacheButton.TabIndex = 0;
			this.clearCacheButton.Text = "Clear Cache";
			this.clearCacheButton.UseVisualStyleBackColor = true;
			this.clearCacheButton.Click += new System.EventHandler(this.clearCacheButton_Click);
			// 
			// refreshListButton
			// 
			this.refreshListButton.Location = new System.Drawing.Point(120, 19);
			this.refreshListButton.Name = "refreshListButton";
			this.refreshListButton.Size = new System.Drawing.Size(90, 23);
			this.refreshListButton.TabIndex = 1;
			this.refreshListButton.Text = "Refresh List";
			this.refreshListButton.UseVisualStyleBackColor = true;
			this.refreshListButton.Click += new System.EventHandler(this.refreshListButton_Click);
			// 
			// preferencesOk
			// 
			this.preferencesOk.Location = new System.Drawing.Point(171, 336);
			this.preferencesOk.Name = "preferencesOk";
			this.preferencesOk.Size = new System.Drawing.Size(75, 23);
			this.preferencesOk.TabIndex = 1;
			this.preferencesOk.Text = "OK";
			this.preferencesOk.UseVisualStyleBackColor = true;
			this.preferencesOk.Click += new System.EventHandler(this.preferencesOk_Click);
			// 
			// preferencesCancel
			// 
			this.preferencesCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.preferencesCancel.Location = new System.Drawing.Point(252, 336);
			this.preferencesCancel.Name = "preferencesCancel";
			this.preferencesCancel.Size = new System.Drawing.Size(75, 23);
			this.preferencesCancel.TabIndex = 2;
			this.preferencesCancel.Text = "Cancel";
			this.preferencesCancel.UseVisualStyleBackColor = true;
			this.preferencesCancel.Click += new System.EventHandler(this.preferencesCancel_Click);
			// 
			// preferencesApply
			// 
			this.preferencesApply.Enabled = false;
			this.preferencesApply.Location = new System.Drawing.Point(333, 336);
			this.preferencesApply.Name = "preferencesApply";
			this.preferencesApply.Size = new System.Drawing.Size(75, 23);
			this.preferencesApply.TabIndex = 3;
			this.preferencesApply.Text = "Apply";
			this.preferencesApply.UseVisualStyleBackColor = true;
			this.preferencesApply.Click += new System.EventHandler(this.preferencesApply_Click);
			// 
			// PreferencesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.preferencesCancel;
			this.ClientSize = new System.Drawing.Size(420, 365);
			this.ControlBox = false;
			this.Controls.Add(this.preferencesApply);
			this.Controls.Add(this.preferencesCancel);
			this.Controls.Add(this.preferencesOk);
			this.Controls.Add(this.preferencesTabControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreferencesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PreferencesForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesForm_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
			this.Load += new System.EventHandler(this.PreferencesForm_Load);
			this.preferencesTabControl.ResumeLayout(false);
			this.generalPreferencesTab.ResumeLayout(false);
			this.hotkeySettingsBox.ResumeLayout(false);
			this.uiSettingsBox.ResumeLayout(false);
			this.uiSettingsBox.PerformLayout();
			this.advancedPreferencesTab.ResumeLayout(false);
			this.cacheRefreshGroup.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl preferencesTabControl;
		private System.Windows.Forms.TabPage generalPreferencesTab;
		private System.Windows.Forms.TabPage advancedPreferencesTab;
		private System.Windows.Forms.Button preferencesOk;
		private System.Windows.Forms.Button preferencesCancel;
		private System.Windows.Forms.Button preferencesApply;
		private System.Windows.Forms.Button clearCacheButton;
		private System.Windows.Forms.Button refreshListButton;
		private System.Windows.Forms.GroupBox cacheRefreshGroup;
		private System.Windows.Forms.Button resetPositionButton;
		private System.Windows.Forms.GroupBox uiSettingsBox;
		private System.Windows.Forms.CheckBox hideOnLostFocus;
		private System.Windows.Forms.CheckBox alwaysOnTop;
		private System.Windows.Forms.CheckBox ignoreFullScreen;
		private System.Windows.Forms.GroupBox hotkeySettingsBox;
		private System.Windows.Forms.ComboBox shortcutKeySelect;

	}
}