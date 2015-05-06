using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using ShortcutListGuiTest;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using ShortcutBay;

namespace MainKykc
{
	class Util
	{
		public static string md5(string Value)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
			data = x.ComputeHash(data);
			string ret = "";
			for (int i = 0; i < data.Length; i++)
			{
				ret += data[i].ToString("x2").ToLower();
			}
			return ret;
		}

		public static string encodeIcon(Icon icon)
		{
			return Util.encodeIcon(icon.ToBitmap());
		}

		public static string encodeIcon(Image icon)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, icon);
			return System.Convert.ToBase64String(ms.ToArray());
		}

		public static Image decodeIcon(string iconString)
		{
			byte[] cachedIconByteArr = System.Convert.FromBase64String(iconString);
			BinaryFormatter bf = new BinaryFormatter();
			MemoryStream ms = new MemoryStream(cachedIconByteArr);
			return bf.Deserialize(ms) as Image;
		}

		public static void toggleVisibility(object obj)
		{
			MainForm form = obj as MainForm;
			//if (form.WindowState == FormWindowState.Normal)
			if (form.Opacity > 0)
			{
				if (form.WasShown)
				{
					PositionCalculator.storePosition(form.Location.X, form.Location.Y);
				}
				Util.properHide(form);
			}
			else
			{
				form.WasShown = true;
				Util.properShow(form);
			}
		}

		public static void properShow(Form form)
		{
			form.WindowState = FormWindowState.Normal;
			form.Show();
			form.Activate();
			form.BringToFront();
			form.Visible = true;
			form.Location = PositionCalculator.getPosition();
			form.Opacity = 0.99;
		}

		public static void properHide(Form form)
		{
			form.Visible = false;
			form.WindowState = FormWindowState.Minimized;
			form.Hide();
			form.Opacity = 0;
		}

		public static bool execute(string path)
		{
			//MessageBox.Show(path);
			Process myProcess = new Process();
			ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(path);
			myProcessStartInfo.UseShellExecute = true;
			myProcess.StartInfo = myProcessStartInfo;
			try
			{
				myProcess.Start();
				return true;
			}
			catch (Exception e)
			{
				//MessageBox.Show(e.GetType().ToString());
				MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
		}

		public static void deleteListItem(string path)
		{
			try
			{
				path = Path.GetFullPath(path);
				File.Delete(path);
			}
			catch (Exception e)
			{
				Util.writeDebugInfo(e.Message);
				MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			Util.getMainForm().initForm();
		}

		public static void renameListItem(string from, string to)
		{
			try
			{
				from = Path.GetFullPath(from);
				to = Path.GetFullPath(to);
				File.Move(from, to);
			}
			catch (Exception e)
			{
				Util.writeDebugInfo(e.Message);
				MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			Util.getMainForm().initForm();
		}

		public static bool isInFullScreenMode()
		{
			return DetectFullScreen.IsForegroundWwindowFullScreen();
		}

		public static void addListItem(string file)
		{
			if (Util.isShellLink(file))
			{
				string path = Path.GetFullPath(ShortcutBay.Properties.Settings.Default.DbPath) +
					Path.DirectorySeparatorChar +
					Path.GetFileNameWithoutExtension(file) +
					".lnk";

				// File already exists handling
				File.Copy(file, path);
			}
			else
			{
				string path = Path.GetFullPath(ShortcutBay.Properties.Settings.Default.DbPath) +
					Path.DirectorySeparatorChar +
					Path.GetFileNameWithoutExtension(file) +
					".lnk";

				ShellLink link = new ShellLink(path);
				link.TargetPath = file;
				link.Save();
			}

		}

		public static MainForm getMainForm()
		{
			return Application.OpenForms[0] as MainForm;
		}

		public static void writeDebugInfo(string str)
		{
			//MessageBox.Show(str);
			;
		}

		public static bool isShellLink(string path)
		{
			
			try
			{
				ShellLink link = new ShellLink(path);
			}
			catch (Exception e)
			{
				Util.writeDebugInfo(e.Message);
				return false;
			}
			
			return true;
		}

		public static ToolStripMenuItem createToolStripMenuItem(string text, EventHandler handler)
		{
			ToolStripMenuItem item = new ToolStripMenuItem();
			item.Text = text;
			item.Click += handler;
			return item;
		}
	}
}
