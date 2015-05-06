using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MainKykc;
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
			
			StringCollection retVal = new StringCollection();

			StringCollection col = Properties.Settings.Default.MainFormPositionArr;

			foreach (string item in col)
			{
				string[] split = PositionCalculator.parseItem(item);
				if (split[0] == desktopSize)
				{
					continue;
				}
				else
				{
					retVal.Add(item);
				}
			}

			retVal.Add(PositionCalculator.genItem(desktopSize, x, y));

			Properties.Settings.Default.MainFormPositionArr = retVal;
		}

		public static Point getPosition()
		{			
			Point retVal;

			//MessageBox.Show("ololo");
			StringCollection col = Properties.Settings.Default.MainFormPositionArr;
			//MessageBox.Show("ololo2");
			string desktopSize = PositionCalculator.getScreenIdentifier();
			
			foreach (string item in col)
			{
				string[] split = PositionCalculator.parseItem(item);
				if (split[0] == desktopSize)
				{
					retVal = new Point(Int32.Parse(split[1]), Int32.Parse(split[2]));
					return retVal;
				}
			}
			
			return DefaultPositionCalculator.getDefaultLocation();
		}
	}
}
