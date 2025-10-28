using ShortcutBay.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
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
				}
				else
				{
					this.Text += text;
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			var instance = this;
			
			if (!Net9DarkModeStylingHacks.RedrawSearchBoxBorder(this, ref m))
			{
				RedrawBorders(ref m);
			}
		}

		private void RedrawBorders(ref Message m)
		{
			if (m.Msg == User32.WM_NCPAINT)
			{
				var dc = User32.GetWindowDC(Handle);

				int borderWidth = 2;
				var borderColor = Color.Gray;

				using (Graphics g = Graphics.FromHdc(dc))
				using (Pen borderPen = new Pen(borderColor, borderWidth))
				{
					int correction = 0;
					g.DrawRectangle(borderPen, 0 + correction, 0 + correction, Width - correction, Height - correction);
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (!Net9DarkModeStylingHacks.ApplyColorsToSearchBox(this))
			{
				// Otherwise text will always be gray as this control is disabled to prevent focus
				this.ForeColor = this.isEmpty ? Color.Gray : SystemColors.ControlText;
			}

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
