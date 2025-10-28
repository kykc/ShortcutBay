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
            preferencesTabControl = new System.Windows.Forms.TabControl();
            generalPreferencesTab = new System.Windows.Forms.TabPage();
            hotkeySettingsBox = new System.Windows.Forms.GroupBox();
            shortcutKeySelect = new System.Windows.Forms.ComboBox();
            uiSettingsBox = new System.Windows.Forms.GroupBox();
            ignoreFullScreen = new System.Windows.Forms.CheckBox();
            hideOnLostFocus = new System.Windows.Forms.CheckBox();
            alwaysOnTop = new System.Windows.Forms.CheckBox();
            advancedPreferencesTab = new System.Windows.Forms.TabPage();
            cacheRefreshGroup = new System.Windows.Forms.GroupBox();
            resetPositionButton = new System.Windows.Forms.Button();
            clearCacheButton = new System.Windows.Forms.Button();
            refreshListButton = new System.Windows.Forms.Button();
            preferencesOk = new System.Windows.Forms.Button();
            preferencesCancel = new System.Windows.Forms.Button();
            preferencesApply = new System.Windows.Forms.Button();
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
            preferencesTabControl.Location = new System.Drawing.Point(14, 14);
            preferencesTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            preferencesTabControl.Name = "preferencesTabControl";
            preferencesTabControl.SelectedIndex = 0;
            preferencesTabControl.Size = new System.Drawing.Size(462, 367);
            preferencesTabControl.TabIndex = 0;
            // 
            // generalPreferencesTab
            // 
            generalPreferencesTab.Controls.Add(hotkeySettingsBox);
            generalPreferencesTab.Controls.Add(uiSettingsBox);
            generalPreferencesTab.Location = new System.Drawing.Point(4, 24);
            generalPreferencesTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            generalPreferencesTab.Name = "generalPreferencesTab";
            generalPreferencesTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            generalPreferencesTab.Size = new System.Drawing.Size(454, 339);
            generalPreferencesTab.TabIndex = 0;
            generalPreferencesTab.Text = "General";
            generalPreferencesTab.UseVisualStyleBackColor = true;
            // 
            // hotkeySettingsBox
            // 
            hotkeySettingsBox.Controls.Add(shortcutKeySelect);
            hotkeySettingsBox.Location = new System.Drawing.Point(7, 118);
            hotkeySettingsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hotkeySettingsBox.Name = "hotkeySettingsBox";
            hotkeySettingsBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hotkeySettingsBox.Size = new System.Drawing.Size(439, 59);
            hotkeySettingsBox.TabIndex = 1;
            hotkeySettingsBox.TabStop = false;
            hotkeySettingsBox.Text = "Shortcut Key Settings";
            // 
            // shortcutKeySelect
            // 
            shortcutKeySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            shortcutKeySelect.FormattingEnabled = true;
            shortcutKeySelect.Location = new System.Drawing.Point(7, 22);
            shortcutKeySelect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            shortcutKeySelect.Name = "shortcutKeySelect";
            shortcutKeySelect.Size = new System.Drawing.Size(139, 23);
            shortcutKeySelect.TabIndex = 0;
            shortcutKeySelect.SelectedValueChanged += shortcutKeySelect_SelectedValueChanged;
            // 
            // uiSettingsBox
            // 
            uiSettingsBox.Controls.Add(ignoreFullScreen);
            uiSettingsBox.Controls.Add(hideOnLostFocus);
            uiSettingsBox.Controls.Add(alwaysOnTop);
            uiSettingsBox.Location = new System.Drawing.Point(7, 7);
            uiSettingsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            uiSettingsBox.Name = "uiSettingsBox";
            uiSettingsBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            uiSettingsBox.Size = new System.Drawing.Size(442, 104);
            uiSettingsBox.TabIndex = 0;
            uiSettingsBox.TabStop = false;
            uiSettingsBox.Text = "UI Settings";
            // 
            // ignoreFullScreen
            // 
            ignoreFullScreen.AutoSize = true;
            ignoreFullScreen.Location = new System.Drawing.Point(7, 75);
            ignoreFullScreen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ignoreFullScreen.Name = "ignoreFullScreen";
            ignoreFullScreen.Size = new System.Drawing.Size(355, 19);
            ignoreFullScreen.TabIndex = 2;
            ignoreFullScreen.Text = "Ignore hotkey when fullscreen mode (video or game) detected";
            ignoreFullScreen.UseVisualStyleBackColor = true;
            ignoreFullScreen.CheckedChanged += ignoreFullScreen_CheckedChanged;
            // 
            // hideOnLostFocus
            // 
            hideOnLostFocus.AutoSize = true;
            hideOnLostFocus.Location = new System.Drawing.Point(7, 48);
            hideOnLostFocus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hideOnLostFocus.Name = "hideOnLostFocus";
            hideOnLostFocus.Size = new System.Drawing.Size(129, 19);
            hideOnLostFocus.TabIndex = 1;
            hideOnLostFocus.Text = "Hide On Lost Focus";
            hideOnLostFocus.UseVisualStyleBackColor = true;
            hideOnLostFocus.CheckedChanged += hideOnLostFocus_CheckedChanged;
            // 
            // alwaysOnTop
            // 
            alwaysOnTop.AutoSize = true;
            alwaysOnTop.Location = new System.Drawing.Point(7, 22);
            alwaysOnTop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            alwaysOnTop.Name = "alwaysOnTop";
            alwaysOnTop.Size = new System.Drawing.Size(105, 19);
            alwaysOnTop.TabIndex = 0;
            alwaysOnTop.Text = "Always On Top";
            alwaysOnTop.UseVisualStyleBackColor = true;
            alwaysOnTop.CheckedChanged += alwaysOnTop_CheckedChanged;
            // 
            // advancedPreferencesTab
            // 
            advancedPreferencesTab.Controls.Add(cacheRefreshGroup);
            advancedPreferencesTab.Location = new System.Drawing.Point(4, 24);
            advancedPreferencesTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            advancedPreferencesTab.Name = "advancedPreferencesTab";
            advancedPreferencesTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            advancedPreferencesTab.Size = new System.Drawing.Size(454, 339);
            advancedPreferencesTab.TabIndex = 1;
            advancedPreferencesTab.Text = "Advanced";
            advancedPreferencesTab.UseVisualStyleBackColor = true;
            // 
            // cacheRefreshGroup
            // 
            cacheRefreshGroup.Controls.Add(resetPositionButton);
            cacheRefreshGroup.Controls.Add(clearCacheButton);
            cacheRefreshGroup.Controls.Add(refreshListButton);
            cacheRefreshGroup.Location = new System.Drawing.Point(7, 7);
            cacheRefreshGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cacheRefreshGroup.Name = "cacheRefreshGroup";
            cacheRefreshGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cacheRefreshGroup.Size = new System.Drawing.Size(439, 58);
            cacheRefreshGroup.TabIndex = 2;
            cacheRefreshGroup.TabStop = false;
            cacheRefreshGroup.Text = "Troubleshooting";
            // 
            // resetPositionButton
            // 
            resetPositionButton.Location = new System.Drawing.Point(252, 22);
            resetPositionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            resetPositionButton.Name = "resetPositionButton";
            resetPositionButton.Size = new System.Drawing.Size(180, 27);
            resetPositionButton.TabIndex = 2;
            resetPositionButton.Text = "Reset Main Window Position";
            resetPositionButton.UseVisualStyleBackColor = true;
            resetPositionButton.Click += resetPositionButton_Click;
            // 
            // clearCacheButton
            // 
            clearCacheButton.Location = new System.Drawing.Point(7, 22);
            clearCacheButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            clearCacheButton.Name = "clearCacheButton";
            clearCacheButton.Size = new System.Drawing.Size(126, 27);
            clearCacheButton.TabIndex = 0;
            clearCacheButton.Text = "Clear Cache";
            clearCacheButton.UseVisualStyleBackColor = true;
            clearCacheButton.Click += clearCacheButton_Click;
            // 
            // refreshListButton
            // 
            refreshListButton.Location = new System.Drawing.Point(140, 22);
            refreshListButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            refreshListButton.Name = "refreshListButton";
            refreshListButton.Size = new System.Drawing.Size(105, 27);
            refreshListButton.TabIndex = 1;
            refreshListButton.Text = "Refresh List";
            refreshListButton.UseVisualStyleBackColor = true;
            refreshListButton.Click += refreshListButton_Click;
            // 
            // preferencesOk
            // 
            preferencesOk.Location = new System.Drawing.Point(200, 388);
            preferencesOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            preferencesOk.Name = "preferencesOk";
            preferencesOk.Size = new System.Drawing.Size(88, 27);
            preferencesOk.TabIndex = 1;
            preferencesOk.Text = "OK";
            preferencesOk.UseVisualStyleBackColor = true;
            preferencesOk.Click += preferencesOk_Click;
            // 
            // preferencesCancel
            // 
            preferencesCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            preferencesCancel.Location = new System.Drawing.Point(294, 388);
            preferencesCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            preferencesCancel.Name = "preferencesCancel";
            preferencesCancel.Size = new System.Drawing.Size(88, 27);
            preferencesCancel.TabIndex = 2;
            preferencesCancel.Text = "Cancel";
            preferencesCancel.UseVisualStyleBackColor = true;
            preferencesCancel.Click += preferencesCancel_Click;
            // 
            // preferencesApply
            // 
            preferencesApply.Enabled = false;
            preferencesApply.Location = new System.Drawing.Point(388, 388);
            preferencesApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            preferencesApply.Name = "preferencesApply";
            preferencesApply.Size = new System.Drawing.Size(88, 27);
            preferencesApply.TabIndex = 3;
            preferencesApply.Text = "Apply";
            preferencesApply.UseVisualStyleBackColor = true;
            preferencesApply.Click += preferencesApply_Click;
            // 
            // PreferencesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = preferencesCancel;
            ClientSize = new System.Drawing.Size(490, 421);
            ControlBox = false;
            Controls.Add(preferencesApply);
            Controls.Add(preferencesCancel);
            Controls.Add(preferencesOk);
            Controls.Add(preferencesTabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PreferencesForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

	}
}