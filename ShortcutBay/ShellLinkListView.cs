using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ShellLink = IWshRuntimeLibrary.IWshShortcut;

namespace ShortcutBay
{
    public class ShellLinkListView : ListView
    {
        private List<ListViewItem> ItemList { get; set; } = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastFilter { get; private set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LastIndex { get; private set; } = 0;

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (this.SelectedIndices.Count > 0)
            {
                LastIndex = this.SelectedIndices[0];
                FocusedItem = this.SelectedItems[0];
            }
            base.OnSelectedIndexChanged(e);
        }

        protected override void OnDpiChangedAfterParent(EventArgs e)
        {
            base.OnDpiChangedAfterParent(e);

            if (this.Columns.Count > 0)
            {
                this.Columns[0].Width = this.Width - 25;
            }
        }

        public void Init(List<ShellLink> list)
        {
            ColumnHeader header = new ColumnHeader();
            header.Name = "Name";
            header.Width = this.Width - 25;
            this.HeaderStyle = ColumnHeaderStyle.None;
            this.Columns.Clear();
            this.Columns.Add(header);
            ItemList = new();

            ImageList imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(32, 32);
            int i = 0;
            foreach (var item in list)
            {
                imageList.Images.Add(item.GetIcon());
                ListViewItem listViewItem = new ListViewItem(item.GetCaption());
                listViewItem.ImageIndex = i;
                listViewItem.Name = item.GetCaption();
                listViewItem.SubItems.Add(item.FullName);
                ItemList.Add(listViewItem);
                i++;
            }
            ItemList = ItemList.OrderBy(x => x.Name).ToList();
            this.LargeImageList = this.SmallImageList = imageList;
        }

        public void Fill(string filter)
        {
            //MessageBox.Show(filter);
            if (filter != LastFilter)
            {
                this.Items.Clear();
                foreach (object item2 in ItemList)
                {
                    ListViewItem? item = item2 as ListViewItem;
                    if (item?.Name.ToLower().Contains(filter.ToLower()) is true)
                    {
                        this.Items.Add(item);
                    }
                }
                LastFilter = filter;
                //this.FullRowSelect = true;
                if (this.Items.Count > 0)
                {
                    this.SelectItemByIndex(0);
                }
            }
        }

        public void SelectItemByIndex(int index)
        {
            if (this.Items.Count > index && index >= 0)
            {
                this.Items[index].Selected = true;
                this.Items[index].Focused = true;
                this.Items[index].EnsureVisible();
            }
        }

        public void HandleArrows(Keys key)
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
                    this.SelectItemByIndex(index);
                }
            }
            else if (this.Items.Count > 0)
            {
                this.SelectItemByIndex(0);
            }
        }

        public void HandleExecute(bool asAdmin = false)
        {
            if (this.SelectedItems.Count > 0)
            {
                if (Util.ExecuteProcess(this.SelectedItems[0].SubItems[1].Text, asAdmin))
                {
                    Program.MainForm.ToggleVisibility(this, EventArgs.Empty);
                }
            }
        }

        public void HandleDelete()
        {
            DialogResult res = MessageBox.Show("Are you sure?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                if (this.SelectedItems.Count > 0)
                {
                    string path = this.SelectedItems[0].SubItems[1].Text;
                    Util.DeleteListItem(path);
                }
            }
        }

        public void HandleOpenFileLocation()
        {
            if (GetSelectedItem() is var selectedItem)
            {
                string path = this.SelectedItems[0].SubItems[1].Text;
                var shellLink = ShellLinkFactory.Create(path);

                Process.Start("explorer.exe", $"/select,\"{shellLink.TargetPath}\"");
            }
        }

        public void HandleOpenLinkLocation()
        {
            if (GetSelectedItem() is var selectedItem)
            {
                string path = this.SelectedItems[0].SubItems[1].Text;
                var shellLink = ShellLinkFactory.Create(path);

                Process.Start("explorer.exe", $"/select,\"{shellLink.FullName}\"");
            }
        }

        public ListViewItem? GetSelectedItem()
        {
            ShellLinkListView control = this;
            return control.SelectedItems.Count > 0 ? control.SelectedItems[0] : null;
        }
    }
}
