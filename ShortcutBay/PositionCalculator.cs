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

		protected static string getScreenIdentifier()
		{
			return Screen.PrimaryScreen.Bounds.Size.ToString().Replace(PositionCalculator.SEPARATOR, PositionCalculator.SEPARATOR_REPLACEMENT);
		}

		protected static string[] parseItem(string item)
		{
			return item.Split(PositionCalculator.SEPARATOR.ToString().ToCharArray());
		}

		protected static string genItem(string key, int x, int y)
		{
			return key + PositionCalculator.SEPARATOR + x.ToString() + PositionCalculator.SEPARATOR + y.ToString();
		}

		public static void storePosition(int x, int y)
		{
			string desktopSize = PositionCalculator.getScreenIdentifier();

			Program.Settings.MainFormPositions[desktopSize] = new Point(x, y);
		}

		public static Point getPosition(Form form)
		{
			string desktopSize = PositionCalculator.getScreenIdentifier();

			return Program.Settings.MainFormPositions.TryGetValue(desktopSize, out var position)
				? position
				: DefaultPositionCalculator.getDefaultLocation(form);
		}
	}
}
