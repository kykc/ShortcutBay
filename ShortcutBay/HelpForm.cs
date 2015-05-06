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
			this.versionLabel.Text = Properties.Settings.Default.AppName + " " + Properties.Settings.Default.Version;
			this.copyrightLabel.Text = "©2010 Aleksandr Kykc\nAll Rights Reserved.";

			string preText = "ShortcutBay is a FREE program licensed under a ";
			string linkText = "Creative Commons 3.0 License";
			string postText = "";
			string linkHref = "http://creativecommons.org/licenses/by-nc-nd/3.0/";
			string wholeText = preText + linkText + postText;

			this.linkLabel1.Text = wholeText;
			this.linkLabel1.Links.Add(preText.Length, (preText + linkText).Length, linkHref);

			this.tipsTextBox.Text = TextCollection.Tips;
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
		}
	}
}
