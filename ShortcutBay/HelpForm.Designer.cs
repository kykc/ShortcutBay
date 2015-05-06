namespace ShortcutBay
{
	partial class HelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
			this.closeButton = new System.Windows.Forms.Button();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.copyrightLabel = new System.Windows.Forms.Label();
			this.versionLabel = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.advancedTipsBox = new System.Windows.Forms.GroupBox();
			this.basicTipsGroup = new System.Windows.Forms.GroupBox();
			this.tipsTextBox = new System.Windows.Forms.TextBox();
			this.tabControl2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.basicTipsGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(184, 302);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(75, 23);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Location = new System.Drawing.Point(5, 5);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(438, 291);
			this.tabControl2.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.richTextBox1);
			this.tabPage1.Controls.Add(this.linkLabel1);
			this.tabPage1.Controls.Add(this.logoPictureBox);
			this.tabPage1.Controls.Add(this.copyrightLabel);
			this.tabPage1.Controls.Add(this.versionLabel);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(430, 265);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "About";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(9, 108);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(415, 151);
			this.richTextBox1.TabIndex = 6;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.linkLabel1.Location = new System.Drawing.Point(6, 92);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(387, 13);
			this.linkLabel1.TabIndex = 4;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "ShortcutBay is a FREE program licensed under a Creative Commons 3.0 License";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Image = global::ShortcutBay.ImageCollection.LargeLogo;
			this.logoPictureBox.Location = new System.Drawing.Point(360, 6);
			this.logoPictureBox.Name = "logoPictureBox";
			this.logoPictureBox.Size = new System.Drawing.Size(64, 64);
			this.logoPictureBox.TabIndex = 3;
			this.logoPictureBox.TabStop = false;
			// 
			// copyrightLabel
			// 
			this.copyrightLabel.AutoSize = true;
			this.copyrightLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.copyrightLabel.Location = new System.Drawing.Point(6, 31);
			this.copyrightLabel.Name = "copyrightLabel";
			this.copyrightLabel.Size = new System.Drawing.Size(116, 26);
			this.copyrightLabel.TabIndex = 2;
			this.copyrightLabel.Text = "©2010 Aleksandr Kykc\r\nAll Rights Reserved.";
			// 
			// versionLabel
			// 
			this.versionLabel.AutoSize = true;
			this.versionLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.versionLabel.Location = new System.Drawing.Point(3, 6);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(159, 16);
			this.versionLabel.TabIndex = 1;
			this.versionLabel.Text = "ShortcutBay version blabla";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.advancedTipsBox);
			this.tabPage2.Controls.Add(this.basicTipsGroup);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(430, 265);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Tips";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// advancedTipsBox
			// 
			this.advancedTipsBox.Location = new System.Drawing.Point(6, 113);
			this.advancedTipsBox.Name = "advancedTipsBox";
			this.advancedTipsBox.Size = new System.Drawing.Size(418, 146);
			this.advancedTipsBox.TabIndex = 2;
			this.advancedTipsBox.TabStop = false;
			this.advancedTipsBox.Text = "Advanced";
			// 
			// basicTipsGroup
			// 
			this.basicTipsGroup.Controls.Add(this.tipsTextBox);
			this.basicTipsGroup.Location = new System.Drawing.Point(6, 6);
			this.basicTipsGroup.Name = "basicTipsGroup";
			this.basicTipsGroup.Size = new System.Drawing.Size(419, 107);
			this.basicTipsGroup.TabIndex = 1;
			this.basicTipsGroup.TabStop = false;
			this.basicTipsGroup.Text = "Basic";
			// 
			// tipsTextBox
			// 
			this.tipsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tipsTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tipsTextBox.Location = new System.Drawing.Point(6, 19);
			this.tipsTextBox.Multiline = true;
			this.tipsTextBox.Name = "tipsTextBox";
			this.tipsTextBox.ReadOnly = true;
			this.tipsTextBox.Size = new System.Drawing.Size(407, 82);
			this.tipsTextBox.TabIndex = 0;
			// 
			// HelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 330);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.tabControl2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HelpForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Help";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelpForm_FormClosing);
			this.Load += new System.EventHandler(this.HelpForm_Load);
			this.tabControl2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.basicTipsGroup.ResumeLayout(false);
			this.basicTipsGroup.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label versionLabel;
		private System.Windows.Forms.Label copyrightLabel;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox tipsTextBox;
		private System.Windows.Forms.GroupBox basicTipsGroup;
		private System.Windows.Forms.GroupBox advancedTipsBox;
	}
}