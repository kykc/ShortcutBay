using MainKykc;

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
			this.components = new System.ComponentModel.Container();
			this.shellLinkListView = new ShortcutBay.ShellLinkListView();
			this.listViewItemMenu = new ShortcutBay.ListViewItemMenu();
			this.searhBox = new CodeProject.SearhTextBox();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new ShortcutBay.TrayMenu();
			this.SuspendLayout();
			// 
			// shellLinkListView
			// 
			this.shellLinkListView.AllowDrop = true;
			this.shellLinkListView.ContextMenuStrip = this.listViewItemMenu;
			this.shellLinkListView.FullRowSelect = true;
			this.shellLinkListView.HideSelection = false;
			this.shellLinkListView.Location = new System.Drawing.Point(12, 12);
			this.shellLinkListView.MultiSelect = false;
			this.shellLinkListView.Name = "shellLinkListView";
			this.shellLinkListView.Size = new System.Drawing.Size(310, 425);
			this.shellLinkListView.TabIndex = 0;
			this.shellLinkListView.UseCompatibleStateImageBehavior = false;
			this.shellLinkListView.View = System.Windows.Forms.View.Details;
			this.shellLinkListView.SelectedIndexChanged += new System.EventHandler(this.shellLinkListView_SelectedIndexChanged);
			this.shellLinkListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.shellLinkListView_DragDrop);
			this.shellLinkListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.shellLinkListView_DragEnter);
			this.shellLinkListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shellLinkListView_KeyDown);
			this.shellLinkListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.shellLinkListView_KeyPress);
			this.shellLinkListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.shellLinkListView_MouseDoubleClick);
			// 
			// listViewItemMenu
			// 
			this.listViewItemMenu.Name = "listViewItemMenu";
			this.listViewItemMenu.Size = new System.Drawing.Size(135, 92);
			// 
			// searhBox
			// 
			this.searhBox.BackColor = System.Drawing.Color.White;
			this.searhBox.Enabled = false;
			this.searhBox.ForeColor = System.Drawing.Color.Gray;
			this.searhBox.Location = new System.Drawing.Point(12, 443);
			this.searhBox.Name = "searhBox";
			this.searhBox.Size = new System.Drawing.Size(310, 20);
			this.searhBox.TabIndex = 1;
			this.searhBox.TabStop = false;
			this.searhBox.Text = "search...";
			this.searhBox.TextChanged += new System.EventHandler(this.searhBox_TextChanged);
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayMenu;
			this.trayIcon.Text = this.Text;
			this.trayIcon.Visible = true;
			this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
			// 
			// trayMenu
			// 
			this.trayMenu.Name = "trayMenu";
			this.trayMenu.Size = new System.Drawing.Size(136, 70);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 475);
			this.Controls.Add(this.shellLinkListView);
			this.Controls.Add(this.searhBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = this.trayIcon.Icon;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.Text = "ShortcutBay";
			this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ShellLinkListView shellLinkListView;
		private CodeProject.SearhTextBox searhBox;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private TrayMenu trayMenu;
		private ListViewItemMenu listViewItemMenu;

	}
}

