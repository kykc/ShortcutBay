using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using MainKykc;

namespace ShortcutBay
{
	public class ShellLinkListView : ListView
	{
		protected ArrayList itemList;
		protected string lastFilter;
		protected int lastIndex = 0;

		public string getLastFilter()
		{
			if (this.lastFilter == null)
			{
				return "";
			}
			else
			{
				return this.lastFilter;
			}
		}

		public int getLastIndex()
		{
			return this.lastIndex;
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if (this.SelectedIndices.Count > 0)
			{
				this.lastIndex = this.SelectedIndices[0];
				this.FocusedItem = this.SelectedItems[0];
			}
			base.OnSelectedIndexChanged(e);
		}

		public void init(ShellLinkList list)
		{
			ColumnHeader header = new ColumnHeader();
			header.Name = "Name";
			header.Width = this.Width - 25;
			this.HeaderStyle = ColumnHeaderStyle.None;
			this.Columns.Clear();
			this.Columns.Add(header);
			this.itemList = new ArrayList();

			ImageList imageList = new ImageList();
			imageList.ColorDepth = ColorDepth.Depth32Bit;
			imageList.ImageSize = new Size(32, 32);
			int i = 0;
			foreach (string key in list.Keys)
			{
				ShellLink item = list[key] as ShellLink;
				imageList.Images.Add(item.IconImage);
				ListViewItem listViewItem = new ListViewItem(item.Name);
				listViewItem.ImageIndex = i;
				listViewItem.Name = item.Name;
				listViewItem.SubItems.Add(item.FullName);
				this.itemList.Add(listViewItem);
				i++;	
			}
			this.itemList.Sort(new ListViewItemComparer());
			this.LargeImageList = this.SmallImageList = imageList;
		}

		public void fill(string filter)
		{
			//MessageBox.Show(filter);
			if (filter != this.lastFilter)
			{
				this.Items.Clear();
				foreach (object item2 in this.itemList)
				{
					ListViewItem item = item2 as ListViewItem;
					if (item.Name.ToLower().Contains(filter.ToLower()))
					{
						this.Items.Add(item);
					}
				}
				this.lastFilter = filter;
				//this.FullRowSelect = true;
				if (this.Items.Count > 0)
				{
					this.selectItemByIndex(0);
				}
			}
		}

		public void selectItemByIndex(int index)
		{
			if (this.Items.Count > index && index >= 0)
			{
				this.Items[index].Selected = true;
				this.Items[index].Focused = true;
				this.Items[index].EnsureVisible();
			}
		}

		public void handleArrows(Keys key)
		{
			if (this.SelectedItems.Count > 0)
			{
				ListViewItem focusedItem = this.SelectedItems[0];
				int index = focusedItem.Index;

				if (key == Keys.Up)
				{
					index -= 1;
				}
				else if (key == Keys.Down)
				{
					index += 1;
				}

				if (index >= 0 && index < this.Items.Count)
				{
					this.selectItemByIndex(index);
				}
			}
			else if (this.Items.Count > 0)
			{
				this.selectItemByIndex(0);
			}
		}

		public void handleExecute()
		{
			if (this.SelectedItems.Count > 0)
			{
				if (Util.execute(this.SelectedItems[0].SubItems[1].Text))
				{
					MainForm form = this.FindForm() as MainForm;
					form.toggleVisibility(this, new EventArgs());
				}
			}
		}

		public void handleDelete()
		{
			DialogResult res = MessageBox.Show("Are you sure?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (res == DialogResult.Yes)
			{
				if (this.SelectedItems.Count > 0)
				{
					string path = this.SelectedItems[0].SubItems[1].Text;
					Util.deleteListItem(path);
				}
			}
		}

		public ListViewItem getSelectedItem()
		{
			ShellLinkListView control = this;
			if (control.SelectedItems.Count > 0)
			{
				return control.SelectedItems[0];
			}
			else
			{
				return null;
			}
		}

		public void handleRename()
		{
			ListViewItem item = this.getSelectedItem();
			if (item != null)
			{
				string ololo = item.SubItems[0].Text;
				DialogResult res = MainKykc.InputBox.Show("Rename", "Input new name:", ref ololo);
				if (res == DialogResult.OK)
				{
					string from = item.SubItems[1].Text;
					string to = Path.GetDirectoryName(from) + Path.DirectorySeparatorChar + ololo + Path.GetExtension(from);
					Util.renameListItem(from, to);
				}
			}
		}
	}
}
