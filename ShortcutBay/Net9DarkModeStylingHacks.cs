using ShortcutBay.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutBay
{
    internal class Net9DarkModeStylingHacks
    {
        public static readonly Color FormBackground = Color.FromArgb(255, 32, 32, 32);

        public static void ApplyColorsToSearchBox(SearchTextBox instance)
        {
            instance.BackColor = Color.FromArgb(255, 49, 49, 49);
            instance.ForeColor = Color.FromArgb(255, 255, 255, 255);
        }

        public static void RedrawSearchBoxBorder(SearchTextBox instance, ref Message m)
        {
            if (m.Msg == User32.WM_NCPAINT)
            {
                var dc = User32.GetWindowDC(instance.Handle);

                int borderWidth = 2;
                var borderColor = Color.DarkGray;

                using (Graphics g = Graphics.FromHdc(dc))
                using (Pen borderPen = new Pen(borderColor, borderWidth))
                using (Pen maskingPen = new Pen(Color.FromArgb(255, 49, 49, 49), borderWidth + 1))
                {
                    int correction = 2;
                    g.DrawRectangle(maskingPen, 0 + correction, 0 + correction, instance.Width - 1 - correction, instance.Height - 1 - correction);
                    g.DrawRectangle(borderPen, 0, 0, instance.Width, instance.Height);
                }
            }
        }

        public static void ApplyTabColor(TabControl tabControl)
        {
            for (int t = 0; t < tabControl.TabPages.Count; ++t)
            {
                tabControl.TabPages[t].BackColor = FormBackground;
            }

            SetWindowTheme(tabControl);
        }

        public static void FixReadOnlyTextBox(TextBox textBox)
        {
            textBox.BackColor = SystemColors.Window;
            textBox.ForeColor = SystemColors.WindowText;
        }

        public static void SetWindowTheme(Control control)
        {
            UxTheme.SetWindowTheme(control.Handle, null, "DarkMode::FileExplorerBannerContainer");
        }
    }
}
