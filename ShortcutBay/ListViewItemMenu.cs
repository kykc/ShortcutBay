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
            Items.Add(Util.createToolStripMenuItem("Run", HandleRun));
            Items.Add(Util.createToolStripMenuItem("Run as Admin", HandleRunAsAdmin));
            Items.Add(Util.createToolStripMenuItem("Open File Location", HandleOpenFileLocation));
            Items.Add(Util.createToolStripMenuItem("Open Link Location", HandleOpenLinkLocation));
            Items.Add(Util.createToolStripMenuItem("&Add Item", HandleAdd));
            Items.Add(Util.createToolStripMenuItem("&Delete Item", HandleDelete));
            Items.Add(Util.createToolStripMenuItem("Refresh &List", HandleRefresh));
        }

        public void HandleRefresh(object? sender, EventArgs e)
        {
            Program.MainForm.initForm();
        }

        public void HandleDelete(object? sender, EventArgs e)
        {
            Program.MainForm.getListView().handleDelete();
        }

        public void HandleAdd(object? sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";
            //dialog.InitialDirectory = initialDirectory;
            dialog.Title = "Select Item";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Util.addListItem(dialog.FileName);
                Program.MainForm.initForm();
            }
        }

        public void HandleRunAsAdmin(object? sender, EventArgs e)
        {
            Program.MainForm.getListView().handleExecute(true);
        }

        public void HandleRun(object? sender, EventArgs e)
        {
            Program.MainForm.getListView().handleExecute();
        }

        public void HandleOpenFileLocation(object? sender, EventArgs e)
        {
            Program.MainForm.getListView().handleOpenFileLocation();
        }

        public void HandleOpenLinkLocation(object? sender, EventArgs e)
        {
            Program.MainForm.getListView().handleOpenLinkLocation();
        }
    }
}
