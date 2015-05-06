using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MainKykc;

namespace ShortcutBay
{
	public class ListViewItemMenu : ContextMenuStrip
	{
		public ListViewItemMenu()
		{
			this.init();
		}

		protected void init()
		{
			this.Items.Add(Util.createToolStripMenuItem("&Add Item", new EventHandler(handleAdd)));
			this.Items.Add(Util.createToolStripMenuItem("&Delete Item", new EventHandler(handleDelete)));
			this.Items.Add(Util.createToolStripMenuItem("&Rename", new EventHandler(handleRename)));
			this.Items.Add(Util.createToolStripMenuItem("Refresh &List", new EventHandler(handleRefresh)));
			
		}

		public void handleRefresh(object sender, EventArgs e)
		{
			Util.getMainForm().initForm();
		}

		public void handleRename(object sender, EventArgs e)
		{
			Util.getMainForm().getListView().handleRename();
		}

		public void handleDelete(object sender, EventArgs e)
		{
			Util.getMainForm().getListView().handleDelete();
		}

		public void handleAdd(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All files (*.*)|*.*";
			//dialog.InitialDirectory = initialDirectory;
			dialog.Title = "Select Item";
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				Util.addListItem(dialog.FileName);
				Util.getMainForm().initForm();
			}
		}
	}
}
