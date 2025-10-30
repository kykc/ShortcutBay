using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace ShortcutBay
{
    class PositionCalculator
    {
        protected const char SEPARATOR = ' ';
        protected const char SEPARATOR_REPLACEMENT = '_';

        protected static string? GetScreenIdentifier()
        {
            if (Screen.PrimaryScreen != null)
            {
                return Screen.PrimaryScreen.Bounds.Size.ToString().Replace(PositionCalculator.SEPARATOR,
                    PositionCalculator.SEPARATOR_REPLACEMENT);
            }

            return null;
        }

        public static void StorePosition(int x, int y)
        {
            string? desktopSize = PositionCalculator.GetScreenIdentifier();

            if (desktopSize != null)
            {
                Program.Settings.MainFormPositions[desktopSize] = new Point(x, y);
            }
        }

        public static Point GetPosition(Form form)
        {
            string? desktopSize = PositionCalculator.GetScreenIdentifier();

            return Program.Settings.MainFormPositions.TryGetValue(desktopSize ?? "", out var position)
                ? position
                : DefaultPositionCalculator.CalcDefaultPosition(form);
        }
    }
}
