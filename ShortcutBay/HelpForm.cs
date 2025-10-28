using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShortcutBay
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Util.getMainForm().helpForm = null;
            Util.getMainForm().unlockForm();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            this.richTextBox1.Text = new[]
            {
                "The MIT License (MIT)",
                "",
                "Permission is hereby granted, free of charge, to any person obtaining a copy",
                "of this software and associated documentation files (the \"Software\"), to deal",
                "in the Software without restriction, including without limitation the rights",
                "to use, copy, modify, merge, publish, distribute, sublicense, and/or sell",
                "copies of the Software, and to permit persons to whom the Software is",
                "furnished to do so, subject to the following conditions:",
                "",
                "The above copyright notice and this permission notice shall be included in all",
                "copies or substantial portions of the Software.",
                "",
                "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR",
                "IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,",
                "FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE",
                "AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER",
                "OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE",
                "SOFTWARE."
            }.Aggregate((x, y) => $"{x}{Environment.NewLine}{y}");

            this.versionLabel.Text = Program.Settings.AppName + " " + Program.Settings.Version;
            this.copyrightLabel.Text = "©2025 Aleksandr Kykc\nAll Rights Reserved.";
            Net9DarkModeStylingHacks.ApplyTabColor(this.tabControl2);

            string preText = "ShortcutBay is a FREE MIT licensed software: ";
            string linkText = "https://github.com/kykc/ShortcutBay";
            string postText = "";
            string linkHref = "https://github.com/kykc/ShortcutBay";
            string wholeText = preText + linkText + postText;

            this.linkLabel1.Text = wholeText;
            this.linkLabel1.Links.Add(preText.Length, (preText + linkText).Length, linkHref);

            this.tipsTextBox.Text = Program.GetTipsText();
            Net9DarkModeStylingHacks.FixReadOnlyTextBox(tipsTextBox);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string? link = e?.Link?.LinkData?.ToString();

            if (link != null)
            {
                Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
            }
        }
    }
}
