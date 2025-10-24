using MainKykc.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ShortcutBay
{
	class SearchTextBox : TextBox
	{
		public SearchTextBox()
		{
			this.SetStyle(ControlStyles.UserPaint, true);
			this.Text = "";
			this.isEmpty = true;
			this.OnLeave(new EventArgs());
			Net9DarkModeStylingHacks.ApplyColorsToSearchBox(this);
			this.clearText();
		}

		public void appendText(string text)
		{
			if (text.Length > 0)
			{
				if (this.IsEmpty)
				{
					this.isEmpty = false;
					this.Text = text;
					this.ForeColor = System.Drawing.Color.LightGray;
				}
				else
				{
					this.ForeColor = Color.LightGray;
					this.Text += text;
				}
			}
		}

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
			var instance = this;
			
			Net9DarkModeStylingHacks.RedrawSearchBoxBorder(this, ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
			// Otherwise text will always be gray as this control is disabled to prevent focus
            SolidBrush drawBrush = new SolidBrush(ForeColor);
            e.Graphics.DrawString(Text, Font, drawBrush, 0f, 0f);
        }

        public void clearText()
		{
			this.appendText("a");
			while (!this.IsEmpty)
			{
				this.backspaceEmulate();
			}
		}

		public void backspaceEmulate()
		{
			if (this.IsEmpty)
			{
				; // You can think that this is useless. You're wrong.
			}
			else
			{
				string text = this.Text;

				if (text.Length == 1 || text.Length == 0)
				{
					text = "";
				}
				else
				{
					text = text.Substring(0, text.Length - 1);
				}
				this.Text = text;

				if (text.Length <= 0)
				{
					this.isEmpty = true;
					this.Text = "search...";
				}
			}
		}

		protected bool isEmpty;
		public bool IsEmpty
		{
			get
			{
				if (this.Text == "" || isEmpty)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
}
