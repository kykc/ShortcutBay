using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MainKykc;

namespace ShortcutBay
{
	class DefaultPositionCalculator
	{
		public static Point getDefaultLocation()
		{
			MainForm form = Util.getMainForm();
			Point retVal = new Point();
			Rectangle desktopSize = Screen.PrimaryScreen.WorkingArea;

			retVal.X = desktopSize.Width - Properties.Settings.Default.MainFormSize.Width + desktopSize.X;
			retVal.Y = desktopSize.Height - Properties.Settings.Default.MainFormSize.Height + desktopSize.Y;

			return retVal;
		}
	}
}
