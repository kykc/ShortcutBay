using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using ShortcutBay;

namespace ShortcutBay
{
    class Util
    {
        public static string CalcMd5(string Value)
        {
#pragma warning disable SYSLIB0021
            var x = new System.Security.Cryptography.MD5CryptoServiceProvider();
#pragma warning restore SYSLIB0021
            byte[] data = System.Text.Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
            {
                ret += data[i].ToString("x2").ToLower();
            }
            return ret;
        }

        public static void ToggleVisibility(MainForm form)
        {
            if (form.Opacity > 0)
            {
                if (form.WasShown)
                {
                    PositionCalculator.StorePosition(form.Location.X, form.Location.Y);
                }
                Util.ProperHide(form);
            }
            else
            {
                form.WasShown = true;
                Util.ProperShow(form);
            }
        }

        public static void ProperShow(Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.Show();
            form.Activate();
            form.BringToFront();
            form.Visible = true;
            form.Location = PositionCalculator.GetPosition(form);
            form.Opacity = 0.99;
        }

        public static void ProperHide(Form form)
        {
            form.Visible = false;
            form.WindowState = FormWindowState.Minimized;
            form.Hide();
            form.Opacity = 0;
        }

        public static bool ExecuteProcess(string path, bool asAdmin = false)
        {
            Process myProcess = new Process();
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(path);
            myProcessStartInfo.UseShellExecute = true;
            myProcess.StartInfo = myProcessStartInfo;

            if (asAdmin)
            {
                myProcess.StartInfo.Verb = "runas";
            }

            try
            {
                myProcess.Start();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public static void DeleteListItem(string path)
        {
            try
            {
                path = Path.GetFullPath(path);
                File.Delete(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show(e.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Program.MainForm.Init();
        }

        public static bool IsInFullScreenMode()
        {
            return DetectFullScreen.CheckForegroundWindowIsFullscreen();
        }

        public static void AddListItem(string file)
        {
            if (Util.IsShellLink(file))
            {
                string path = Path.GetFullPath(Program.Settings.DbPath) +
                    Path.DirectorySeparatorChar +
                    Path.GetFileNameWithoutExtension(file) +
                    ".lnk";

                // File already exists handling
                File.Copy(file, path);
            }
            else
            {
                string path = Path.GetFullPath(Program.Settings.DbPath) +
                    Path.DirectorySeparatorChar +
                    Path.GetFileNameWithoutExtension(file) +
                    ".lnk";

                var link = ShellLinkFactory.Create(path);
                link.TargetPath = file;
                link.Save();
            }

        }

        public static bool IsShellLink(string path)
        {
            try
            {
                var link = ShellLinkFactory.Create(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        public static ToolStripMenuItem CreateToolStripMenuItem(string text, EventHandler handler)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Click += handler;
            return item;
        }

        public static bool IsSubdirectory(string? path, string? parent)
        {
            if (path != null && parent != null)
            {
                var fullPath = Path.GetFullPath(path);
                var fullParent = Path.GetFullPath(parent);

                return fullPath.StartsWith(fullParent, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
