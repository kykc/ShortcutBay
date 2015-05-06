using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace MainKykc
{
	public class SystemHotkey : System.ComponentModel.Component, IDisposable
	{
		private System.ComponentModel.Container components = null;
		protected Win32.DummyWindowWithEvent m_Window = new Win32.DummyWindowWithEvent();
		protected Shortcut m_HotKey = Shortcut.None;
		protected bool isRegistered = false;
		public event System.EventHandler Pressed;
		public event System.EventHandler Error;

		public SystemHotkey(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			m_Window.ProcessMessage += new Win32.MessageEventHandler(MessageEvent);
		}

		public SystemHotkey()
		{
			InitializeComponent();
			if (!DesignMode)
			{
				m_Window.ProcessMessage += new Win32.MessageEventHandler(MessageEvent);
			}
		}

		public new void Dispose()
		{
			if (isRegistered)
			{
				if (UnregisterHotkey())
					System.Diagnostics.Debug.WriteLine("Unreg: OK");
			}
			System.Diagnostics.Debug.WriteLine("Disposed");
		}
		
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}

		protected void MessageEvent(object sender, ref Message m, ref bool Handled)
		{	
			if ((m.Msg == (int)Win32.Msgs.WM_HOTKEY) && (m.WParam == (IntPtr)this.GetType().GetHashCode()))
			{
				Handled = true;
				System.Diagnostics.Debug.WriteLine("HOTKEY pressed!");
				if (Pressed != null) Pressed(this, EventArgs.Empty);
			}
		}

		protected bool UnregisterHotkey()
		{
			return Win32.User32.UnregisterHotKey(m_Window.Handle, this.GetType().GetHashCode());
		}

		protected bool RegisterHotkey(Shortcut key)
		{
			int mod = 0;
			Keys k2 = Keys.None;
			if (((int)key & (int)Keys.Alt) == (int)Keys.Alt) { mod += (int)Win32.Modifiers.MOD_ALT; k2 = Keys.Alt; }
			if (((int)key & (int)Keys.Shift) == (int)Keys.Shift) { mod += (int)Win32.Modifiers.MOD_SHIFT; k2 = Keys.Shift; }
			if (((int)key & (int)Keys.Control) == (int)Keys.Control) { mod += (int)Win32.Modifiers.MOD_CONTROL; k2 = Keys.Control; }

			System.Diagnostics.Debug.Write(mod.ToString() + " ");
			System.Diagnostics.Debug.WriteLine((((int)key) - ((int)k2)).ToString());

			return Win32.User32.RegisterHotKey(m_Window.Handle, this.GetType().GetHashCode(), (int)mod, ((int)key) - ((int)k2));
		}

		public bool IsRegistered
		{
			get { return isRegistered; }
		}


		[DefaultValue(Shortcut.None)]
		public Shortcut Shortcut
		{
			get { return m_HotKey; }
			set
			{
				if (DesignMode) 
				{ 
					m_HotKey = value; return; 
				}
				if ((isRegistered) && (m_HotKey != value))
				{
					if (UnregisterHotkey())
					{
						System.Diagnostics.Debug.WriteLine("Unreg: OK");
						isRegistered = false;
					}
					else
					{
						if (Error != null) Error(this, EventArgs.Empty);
						System.Diagnostics.Debug.WriteLine("Unreg: ERR");
					}
				}
				if (value == Shortcut.None) 
				{ 
					m_HotKey = value; return; 
				}
				if (RegisterHotkey(value))
				{
					System.Diagnostics.Debug.WriteLine("Reg: OK");
					isRegistered = true;
				}
				else
				{
					if (Error != null) Error(this, EventArgs.Empty);
					System.Diagnostics.Debug.WriteLine("Reg: ERR");
				}
				m_HotKey = value;
			}
		}
	}
}
