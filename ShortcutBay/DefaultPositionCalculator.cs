using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ShortcutBay
{
	class DefaultPositionCalculator
	{
		public static Point getDefaultLocation(Form form)
		{
			Point retVal = new Point(0, 0);
			Rectangle? desktopSize = Screen.PrimaryScreen?.WorkingArea;

			if (desktopSize.HasValue)
			{
				retVal.X = desktopSize.Value.Width - form.Width + desktopSize.Value.X;
				retVal.Y = desktopSize.Value.Height - form.Height + desktopSize.Value.Y;
			}

			return retVal;
		}
	}
}
