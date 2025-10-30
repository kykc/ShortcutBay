using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ShortcutBay
{
    public sealed class ListViewItemMenu : ContextMenuStrip
    {
        public ListViewItemMenu()
        {
            Items.Add(Util.CreateToolStripMenuItem("Run", HandleRun));
            Items.Add(Util.CreateToolStripMenuItem("Run as Admin", HandleRunAsAdmin));
            Items.Add(Util.CreateToolStripMenuItem("Open File Location", HandleOpenFileLocation));
            Items.Add(Util.CreateToolStripMenuItem("Open Link Location", HandleOpenLinkLocation));
            Items.Add(Util.CreateToolStripMenuItem("&Add Item", HandleAdd));
            Items.Add(Util.CreateToolStripMenuItem("&Delete Item", HandleDelete));
            Items.Add(Util.CreateToolStripMenuItem("Refresh &List", HandleRefresh));
        }

        public void HandleRefresh(object? sender, EventArgs e)
        {
            Program.MainForm.Init();
        }

        public void HandleDelete(object? sender, EventArgs e)
        {
            Program.MainForm.GetListView().HandleDelete();
        }

        public void HandleAdd(object? sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select Item";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Util.AddListItem(dialog.FileName);
                Program.MainForm.Init();
            }
        }

        public void HandleRunAsAdmin(object? sender, EventArgs e)
        {
            Program.MainForm.GetListView().HandleExecute(true);
        }

        public void HandleRun(object? sender, EventArgs e)
        {
            Program.MainForm.GetListView().HandleExecute();
        }

        public void HandleOpenFileLocation(object? sender, EventArgs e)
        {
            Program.MainForm.GetListView().HandleOpenFileLocation();
        }

        public void HandleOpenLinkLocation(object? sender, EventArgs e)
        {
            Program.MainForm.GetListView().HandleOpenLinkLocation();
        }
    }
}
