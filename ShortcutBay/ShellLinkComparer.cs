using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace MainKykc
{
	public enum SortDirection
	{
		Asc,
		Desc
	}

	public class ListViewItemComparer : IComparer
	{
		private SortDirection m_direction = SortDirection.Asc;

		public ListViewItemComparer() : base() { }

		public ListViewItemComparer(SortDirection direction)
		{
			this.m_direction = direction;
		}

		int IComparer.Compare(object x, object y)
		{
			ListViewItem xx = (ListViewItem)x;
			ListViewItem yy = (ListViewItem)y;
			return xx.Name.CompareTo(yy.Name);
		}
	}
}
