using ShortcutBay.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutBay
{
    internal class Net9DarkModeStylingHacks
    {
        public static readonly Color FormBackground = Color.FromArgb(255, 32, 32, 32);

        public static bool ApplyColorsToSearchBox(SearchTextBox instance)
        {
            if (Program.Net9DarkColorModeEnabled)
            {
                instance.BackColor = Color.FromArgb(255, 49, 49, 49);
                instance.ForeColor = instance.IsEmpty ? Color.LightGray : Color.White;

                return true;
            }

            return false;
        }

        public static bool RedrawSearchBoxBorder(SearchTextBox instance, ref Message m)
        {
            if (Program.Net9DarkColorModeEnabled && m.Msg == User32.WM_NCPAINT)
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

                return true;
            }

            return false;
        }

        public static void ApplyTabColor(TabControl tabControl)
        {
            if (Program.Net9DarkColorModeEnabled)
            {
                for (int t = 0; t < tabControl.TabPages.Count; ++t)
                {
                    tabControl.TabPages[t].BackColor = FormBackground;
                }

                SetWindowTheme(tabControl);
            }
        }

        public static void FixReadOnlyTextBox(TextBox textBox)
        {
            if (Program.Net9DarkColorModeEnabled)
            {
                textBox.BackColor = SystemColors.Window;
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

        public static void SetWindowTheme(Control control)
        {
            if (Program.Net9DarkColorModeEnabled)
            {
                UxTheme.SetWindowTheme(control.Handle, null, "DarkMode::FileExplorerBannerContainer");
            }
        }
    }
}
