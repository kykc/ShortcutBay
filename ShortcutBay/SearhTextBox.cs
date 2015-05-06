using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CodeProject
{
	class SearhTextBox : TextBox
	{
		public SearhTextBox()
		{
			this.SetStyle(ControlStyles.UserPaint, true);
			this.Text = "";
			this.isEmpty = true;
			this.OnLeave(new EventArgs());
			this.BackColor = System.Drawing.Color.White;
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
					this.ForeColor = System.Drawing.Color.Black;
				}
				else
				{
					this.Text += text;
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
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
				; // You can think that this is usless. You're wrong.
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
					this.ForeColor = System.Drawing.Color.Gray;
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
