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
            closeButton = new System.Windows.Forms.Button();
            tabControl2 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            logoPictureBox = new System.Windows.Forms.PictureBox();
            copyrightLabel = new System.Windows.Forms.Label();
            versionLabel = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            advancedTipsBox = new System.Windows.Forms.GroupBox();
            basicTipsGroup = new System.Windows.Forms.GroupBox();
            tipsTextBox = new System.Windows.Forms.TextBox();
            tabControl2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            tabPage2.SuspendLayout();
            basicTipsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Location = new System.Drawing.Point(215, 348);
            closeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new System.Drawing.Size(88, 27);
            closeButton.TabIndex = 1;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Location = new System.Drawing.Point(6, 6);
            tabControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new System.Drawing.Size(511, 336);
            tabControl2.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(richTextBox1);
            tabPage1.Controls.Add(linkLabel1);
            tabPage1.Controls.Add(logoPictureBox);
            tabPage1.Controls.Add(copyrightLabel);
            tabPage1.Controls.Add(versionLabel);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Size = new System.Drawing.Size(503, 308);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "About";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new System.Drawing.Point(10, 125);
            richTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(483, 174);
            richTextBox1.TabIndex = 6;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            linkLabel1.Location = new System.Drawing.Point(7, 106);
            linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(387, 13);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "ShortcutBay is a FREE program licensed under a Creative Commons 3.0 License";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = ImageCollection.LargeLogo;
            logoPictureBox.Location = new System.Drawing.Point(420, 7);
            logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new System.Drawing.Size(75, 74);
            logoPictureBox.TabIndex = 3;
            logoPictureBox.TabStop = false;
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            copyrightLabel.Location = new System.Drawing.Point(7, 36);
            copyrightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new System.Drawing.Size(116, 26);
            copyrightLabel.TabIndex = 2;
            copyrightLabel.Text = "©2010 Aleksandr Kykc\r\nAll Rights Reserved.";
            // 
            // versionLabel
            // 
            versionLabel.AutoSize = true;
            versionLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            versionLabel.Location = new System.Drawing.Point(4, 7);
            versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new System.Drawing.Size(158, 16);
            versionLabel.TabIndex = 1;
            versionLabel.Text = "ShortcutBay version blabla";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(advancedTipsBox);
            tabPage2.Controls.Add(basicTipsGroup);
            tabPage2.Location = new System.Drawing.Point(4, 24);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Size = new System.Drawing.Size(503, 308);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tips";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // advancedTipsBox
            // 
            advancedTipsBox.Location = new System.Drawing.Point(7, 130);
            advancedTipsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            advancedTipsBox.Name = "advancedTipsBox";
            advancedTipsBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            advancedTipsBox.Size = new System.Drawing.Size(488, 168);
            advancedTipsBox.TabIndex = 2;
            advancedTipsBox.TabStop = false;
            advancedTipsBox.Text = "Advanced";
            // 
            // basicTipsGroup
            // 
            basicTipsGroup.Controls.Add(tipsTextBox);
            basicTipsGroup.Location = new System.Drawing.Point(7, 7);
            basicTipsGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basicTipsGroup.Name = "basicTipsGroup";
            basicTipsGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            basicTipsGroup.Size = new System.Drawing.Size(489, 123);
            basicTipsGroup.TabIndex = 1;
            basicTipsGroup.TabStop = false;
            basicTipsGroup.Text = "Basic";
            // 
            // tipsTextBox
            // 
            tipsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tipsTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            tipsTextBox.Location = new System.Drawing.Point(7, 22);
            tipsTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tipsTextBox.Multiline = true;
            tipsTextBox.Name = "tipsTextBox";
            tipsTextBox.ReadOnly = true;
            tipsTextBox.Size = new System.Drawing.Size(475, 95);
            tipsTextBox.TabIndex = 0;
            // 
            // HelpForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(520, 381);
            Controls.Add(closeButton);
            Controls.Add(tabControl2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Help";
            FormClosing += HelpForm_FormClosing;
            Load += HelpForm_Load;
            tabControl2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            tabPage2.ResumeLayout(false);
            basicTipsGroup.ResumeLayout(false);
            basicTipsGroup.PerformLayout();
            ResumeLayout(false);

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