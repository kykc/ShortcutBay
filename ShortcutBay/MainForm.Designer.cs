

namespace ShortcutBay
{
	partial class MainForm
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
            components = new System.ComponentModel.Container();
            shellLinkListView = new ShellLinkListView();
            listViewItemMenu = new ListViewItemMenu();
            searhBox = new SearchTextBox();
            trayIcon = new System.Windows.Forms.NotifyIcon(components);
            trayMenu = new TrayMenu();
            SuspendLayout();
            // 
            // shellLinkListView
            // 
            shellLinkListView.AllowDrop = true;
            shellLinkListView.ContextMenuStrip = listViewItemMenu;
            shellLinkListView.FullRowSelect = true;
            shellLinkListView.Location = new System.Drawing.Point(14, 14);
            shellLinkListView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            shellLinkListView.MultiSelect = false;
            shellLinkListView.Name = "shellLinkListView";
            shellLinkListView.Size = new System.Drawing.Size(361, 490);
            shellLinkListView.TabIndex = 0;
            shellLinkListView.UseCompatibleStateImageBehavior = false;
            shellLinkListView.View = System.Windows.Forms.View.Details;
            shellLinkListView.DragDrop += shellLinkListView_DragDrop;
            shellLinkListView.DragEnter += shellLinkListView_DragEnter;
            shellLinkListView.KeyDown += shellLinkListView_KeyDown;
            shellLinkListView.KeyPress += shellLinkListView_KeyPress;
            shellLinkListView.MouseDoubleClick += shellLinkListView_MouseDoubleClick;
            // 
            // listViewItemMenu
            // 
            listViewItemMenu.Name = "listViewItemMenu";
            listViewItemMenu.Size = new System.Drawing.Size(135, 92);
            // 
            // searhBox
            // 
            searhBox.BackColor = System.Drawing.SystemColors.Window;
            searhBox.Enabled = false;
            searhBox.ForeColor = System.Drawing.SystemColors.WindowText;
            searhBox.Location = new System.Drawing.Point(14, 511);
            searhBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searhBox.Name = "searhBox";
            searhBox.Size = new System.Drawing.Size(361, 23);
            searhBox.TabIndex = 1;
            searhBox.TabStop = false;
            searhBox.Text = "search...";
            searhBox.TextChanged += searhBox_TextChanged;
            // 
            // trayIcon
            // 
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
            trayIcon.DoubleClick += trayIcon_DoubleClick;
            // 
            // trayMenu
            // 
            trayMenu.Name = "trayMenu";
            trayMenu.Size = new System.Drawing.Size(136, 70);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(391, 551);
            Controls.Add(shellLinkListView);
            Controls.Add(searhBox);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Opacity = 0D;
            ShowInTaskbar = false;
            Text = "ShortcutBay";
            Deactivate += MainForm_Deactivate;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ShellLinkListView shellLinkListView;
		private ShortcutBay.SearchTextBox searhBox;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private TrayMenu trayMenu;
		private ListViewItemMenu listViewItemMenu;
    }
}

