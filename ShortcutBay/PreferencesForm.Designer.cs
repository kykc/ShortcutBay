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
            preferencesTabControl = new TabControl();
            generalPreferencesTab = new TabPage();
            hotkeySettingsBox = new GroupBox();
            shortcutKeySelect = new ComboBox();
            uiSettingsBox = new GroupBox();
            ignoreDuplicates = new CheckBox();
            ignoreFullScreen = new CheckBox();
            hideOnLostFocus = new CheckBox();
            alwaysOnTop = new CheckBox();
            advancedPreferencesTab = new TabPage();
            cacheRefreshGroup = new GroupBox();
            resetPositionButton = new Button();
            clearCacheButton = new Button();
            refreshListButton = new Button();
            preferencesOk = new Button();
            preferencesCancel = new Button();
            preferencesApply = new Button();
            preferencesTabControl.SuspendLayout();
            generalPreferencesTab.SuspendLayout();
            hotkeySettingsBox.SuspendLayout();
            uiSettingsBox.SuspendLayout();
            advancedPreferencesTab.SuspendLayout();
            cacheRefreshGroup.SuspendLayout();
            SuspendLayout();
            // 
            // preferencesTabControl
            // 
            preferencesTabControl.Controls.Add(generalPreferencesTab);
            preferencesTabControl.Controls.Add(advancedPreferencesTab);
            preferencesTabControl.Location = new Point(14, 14);
            preferencesTabControl.Margin = new Padding(4, 3, 4, 3);
            preferencesTabControl.Name = "preferencesTabControl";
            preferencesTabControl.SelectedIndex = 0;
            preferencesTabControl.Size = new Size(462, 367);
            preferencesTabControl.TabIndex = 0;
            // 
            // generalPreferencesTab
            // 
            generalPreferencesTab.Controls.Add(hotkeySettingsBox);
            generalPreferencesTab.Controls.Add(uiSettingsBox);
            generalPreferencesTab.Location = new Point(4, 24);
            generalPreferencesTab.Margin = new Padding(4, 3, 4, 3);
            generalPreferencesTab.Name = "generalPreferencesTab";
            generalPreferencesTab.Padding = new Padding(4, 3, 4, 3);
            generalPreferencesTab.Size = new Size(454, 339);
            generalPreferencesTab.TabIndex = 0;
            generalPreferencesTab.Text = "General";
            generalPreferencesTab.UseVisualStyleBackColor = true;
            // 
            // hotkeySettingsBox
            // 
            hotkeySettingsBox.Controls.Add(shortcutKeySelect);
            hotkeySettingsBox.Location = new Point(7, 139);
            hotkeySettingsBox.Margin = new Padding(4, 3, 4, 3);
            hotkeySettingsBox.Name = "hotkeySettingsBox";
            hotkeySettingsBox.Padding = new Padding(4, 3, 4, 3);
            hotkeySettingsBox.Size = new Size(442, 59);
            hotkeySettingsBox.TabIndex = 1;
            hotkeySettingsBox.TabStop = false;
            hotkeySettingsBox.Text = "Shortcut Key Settings";
            // 
            // shortcutKeySelect
            // 
            shortcutKeySelect.DropDownStyle = ComboBoxStyle.DropDownList;
            shortcutKeySelect.FormattingEnabled = true;
            shortcutKeySelect.Location = new Point(7, 22);
            shortcutKeySelect.Margin = new Padding(4, 3, 4, 3);
            shortcutKeySelect.Name = "shortcutKeySelect";
            shortcutKeySelect.Size = new Size(139, 23);
            shortcutKeySelect.TabIndex = 0;
            shortcutKeySelect.SelectedValueChanged += shortcutKeySelect_SelectedValueChanged;
            // 
            // uiSettingsBox
            // 
            uiSettingsBox.Controls.Add(ignoreDuplicates);
            uiSettingsBox.Controls.Add(ignoreFullScreen);
            uiSettingsBox.Controls.Add(hideOnLostFocus);
            uiSettingsBox.Controls.Add(alwaysOnTop);
            uiSettingsBox.Location = new Point(7, 7);
            uiSettingsBox.Margin = new Padding(4, 3, 4, 3);
            uiSettingsBox.Name = "uiSettingsBox";
            uiSettingsBox.Padding = new Padding(4, 3, 4, 3);
            uiSettingsBox.Size = new Size(442, 126);
            uiSettingsBox.TabIndex = 0;
            uiSettingsBox.TabStop = false;
            uiSettingsBox.Text = "UI Settings";
            // 
            // ignoreDuplicates
            // 
            ignoreDuplicates.AutoSize = true;
            ignoreDuplicates.Location = new Point(7, 100);
            ignoreDuplicates.Name = "ignoreDuplicates";
            ignoreDuplicates.Size = new Size(164, 19);
            ignoreDuplicates.TabIndex = 3;
            ignoreDuplicates.Text = "Ignore duplicate shortcuts";
            ignoreDuplicates.UseVisualStyleBackColor = true;
            ignoreDuplicates.CheckedChanged += ignoreDuplicates_CheckedChanged;
            // 
            // ignoreFullScreen
            // 
            ignoreFullScreen.AutoSize = true;
            ignoreFullScreen.Location = new Point(7, 75);
            ignoreFullScreen.Margin = new Padding(4, 3, 4, 3);
            ignoreFullScreen.Name = "ignoreFullScreen";
            ignoreFullScreen.Size = new Size(355, 19);
            ignoreFullScreen.TabIndex = 2;
            ignoreFullScreen.Text = "Ignore hotkey when fullscreen mode (video or game) detected";
            ignoreFullScreen.UseVisualStyleBackColor = true;
            ignoreFullScreen.CheckedChanged += ignoreFullScreen_CheckedChanged;
            // 
            // hideOnLostFocus
            // 
            hideOnLostFocus.AutoSize = true;
            hideOnLostFocus.Location = new Point(7, 48);
            hideOnLostFocus.Margin = new Padding(4, 3, 4, 3);
            hideOnLostFocus.Name = "hideOnLostFocus";
            hideOnLostFocus.Size = new Size(129, 19);
            hideOnLostFocus.TabIndex = 1;
            hideOnLostFocus.Text = "Hide On Lost Focus";
            hideOnLostFocus.UseVisualStyleBackColor = true;
            hideOnLostFocus.CheckedChanged += hideOnLostFocus_CheckedChanged;
            // 
            // alwaysOnTop
            // 
            alwaysOnTop.AutoSize = true;
            alwaysOnTop.Location = new Point(7, 22);
            alwaysOnTop.Margin = new Padding(4, 3, 4, 3);
            alwaysOnTop.Name = "alwaysOnTop";
            alwaysOnTop.Size = new Size(105, 19);
            alwaysOnTop.TabIndex = 0;
            alwaysOnTop.Text = "Always On Top";
            alwaysOnTop.UseVisualStyleBackColor = true;
            alwaysOnTop.CheckedChanged += alwaysOnTop_CheckedChanged;
            // 
            // advancedPreferencesTab
            // 
            advancedPreferencesTab.Controls.Add(cacheRefreshGroup);
            advancedPreferencesTab.Location = new Point(4, 24);
            advancedPreferencesTab.Margin = new Padding(4, 3, 4, 3);
            advancedPreferencesTab.Name = "advancedPreferencesTab";
            advancedPreferencesTab.Padding = new Padding(4, 3, 4, 3);
            advancedPreferencesTab.Size = new Size(454, 339);
            advancedPreferencesTab.TabIndex = 1;
            advancedPreferencesTab.Text = "Advanced";
            advancedPreferencesTab.UseVisualStyleBackColor = true;
            // 
            // cacheRefreshGroup
            // 
            cacheRefreshGroup.Controls.Add(resetPositionButton);
            cacheRefreshGroup.Controls.Add(clearCacheButton);
            cacheRefreshGroup.Controls.Add(refreshListButton);
            cacheRefreshGroup.Location = new Point(7, 7);
            cacheRefreshGroup.Margin = new Padding(4, 3, 4, 3);
            cacheRefreshGroup.Name = "cacheRefreshGroup";
            cacheRefreshGroup.Padding = new Padding(4, 3, 4, 3);
            cacheRefreshGroup.Size = new Size(439, 58);
            cacheRefreshGroup.TabIndex = 2;
            cacheRefreshGroup.TabStop = false;
            cacheRefreshGroup.Text = "Troubleshooting";
            // 
            // resetPositionButton
            // 
            resetPositionButton.Location = new Point(252, 22);
            resetPositionButton.Margin = new Padding(4, 3, 4, 3);
            resetPositionButton.Name = "resetPositionButton";
            resetPositionButton.Size = new Size(180, 27);
            resetPositionButton.TabIndex = 2;
            resetPositionButton.Text = "Reset Main Window Position";
            resetPositionButton.UseVisualStyleBackColor = true;
            resetPositionButton.Click += resetPositionButton_Click;
            // 
            // clearCacheButton
            // 
            clearCacheButton.Location = new Point(7, 22);
            clearCacheButton.Margin = new Padding(4, 3, 4, 3);
            clearCacheButton.Name = "clearCacheButton";
            clearCacheButton.Size = new Size(126, 27);
            clearCacheButton.TabIndex = 0;
            clearCacheButton.Text = "Clear Cache";
            clearCacheButton.UseVisualStyleBackColor = true;
            clearCacheButton.Click += clearCacheButton_Click;
            // 
            // refreshListButton
            // 
            refreshListButton.Location = new Point(140, 22);
            refreshListButton.Margin = new Padding(4, 3, 4, 3);
            refreshListButton.Name = "refreshListButton";
            refreshListButton.Size = new Size(105, 27);
            refreshListButton.TabIndex = 1;
            refreshListButton.Text = "Refresh List";
            refreshListButton.UseVisualStyleBackColor = true;
            refreshListButton.Click += refreshListButton_Click;
            // 
            // preferencesOk
            // 
            preferencesOk.Location = new Point(200, 388);
            preferencesOk.Margin = new Padding(4, 3, 4, 3);
            preferencesOk.Name = "preferencesOk";
            preferencesOk.Size = new Size(88, 27);
            preferencesOk.TabIndex = 1;
            preferencesOk.Text = "OK";
            preferencesOk.UseVisualStyleBackColor = true;
            preferencesOk.Click += preferencesOk_Click;
            // 
            // preferencesCancel
            // 
            preferencesCancel.DialogResult = DialogResult.Cancel;
            preferencesCancel.Location = new Point(294, 388);
            preferencesCancel.Margin = new Padding(4, 3, 4, 3);
            preferencesCancel.Name = "preferencesCancel";
            preferencesCancel.Size = new Size(88, 27);
            preferencesCancel.TabIndex = 2;
            preferencesCancel.Text = "Cancel";
            preferencesCancel.UseVisualStyleBackColor = true;
            preferencesCancel.Click += preferencesCancel_Click;
            // 
            // preferencesApply
            // 
            preferencesApply.Enabled = false;
            preferencesApply.Location = new Point(388, 388);
            preferencesApply.Margin = new Padding(4, 3, 4, 3);
            preferencesApply.Name = "preferencesApply";
            preferencesApply.Size = new Size(88, 27);
            preferencesApply.TabIndex = 3;
            preferencesApply.Text = "Apply";
            preferencesApply.UseVisualStyleBackColor = true;
            preferencesApply.Click += preferencesApply_Click;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = preferencesCancel;
            ClientSize = new Size(490, 421);
            ControlBox = false;
            Controls.Add(preferencesApply);
            Controls.Add(preferencesCancel);
            Controls.Add(preferencesOk);
            Controls.Add(preferencesTabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferencesForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PreferencesForm";
            FormClosing += PreferencesForm_FormClosing;
            FormClosed += PreferencesForm_FormClosed;
            Load += PreferencesForm_Load;
            preferencesTabControl.ResumeLayout(false);
            generalPreferencesTab.ResumeLayout(false);
            hotkeySettingsBox.ResumeLayout(false);
            uiSettingsBox.ResumeLayout(false);
            uiSettingsBox.PerformLayout();
            advancedPreferencesTab.ResumeLayout(false);
            cacheRefreshGroup.ResumeLayout(false);
            ResumeLayout(false);

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
        private CheckBox ignoreDuplicates;
    }
}