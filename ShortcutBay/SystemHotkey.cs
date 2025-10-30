using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace ShortcutBay
{
    public class SystemHotkey : System.ComponentModel.Component, IDisposable
    {
        private IContainer _components;
        private Win32.DummyWindowWithEvent _window = new();
        private Shortcut _hotkey = Shortcut.None;
        private bool IsRegistered { get; set; } = false;
        private event EventHandler Pressed;

        public SystemHotkey(IContainer container, EventHandler pressedHandler, Shortcut shortcut)
        {
            container.Add(this);
            _components = container;
            _window.ProcessMessage += MessageEvent;
            Shortcut = shortcut;
            Pressed += pressedHandler;
        }

        public new void Dispose()
        {
            if (IsRegistered)
            {
                if (UnregisterHotkey())
                    Debug.WriteLine("Unreg: OK");
            }

            Debug.WriteLine("Disposed");
        }

        protected void MessageEvent(object sender, ref Message m, ref bool handled)
        {
            if ((m.Msg == (int)Win32.Msgs.WM_HOTKEY) && (m.WParam == (IntPtr)this.GetType().GetHashCode()))
            {
                handled = true;
                Debug.WriteLine("HOTKEY pressed!");
                if (Pressed != null) Pressed(this, EventArgs.Empty);
            }
        }

        protected bool UnregisterHotkey()
        {
            return Win32.User32.UnregisterHotKey(_window.Handle, this.GetType().GetHashCode());
        }

        protected bool RegisterHotkey(Shortcut key)
        {
            int mod = 0;
            Keys k2 = Keys.None;
            if (((int)key & (int)Keys.Alt) == (int)Keys.Alt) { mod += (int)Win32.Modifiers.MOD_ALT; k2 = Keys.Alt; }
            if (((int)key & (int)Keys.Shift) == (int)Keys.Shift) { mod += (int)Win32.Modifiers.MOD_SHIFT; k2 = Keys.Shift; }
            if (((int)key & (int)Keys.Control) == (int)Keys.Control) { mod += (int)Win32.Modifiers.MOD_CONTROL; k2 = Keys.Control; }

            Debug.Write(mod.ToString() + " ");
            Debug.WriteLine((((int)key) - ((int)k2)).ToString());

            return Win32.User32.RegisterHotKey(_window.Handle, this.GetType().GetHashCode(), (int)mod, ((int)key) - ((int)k2));
        }

        [DefaultValue(Shortcut.None)]
        public Shortcut Shortcut
        {
            get { return _hotkey; }
            set
            {
                if (DesignMode)
                {
                    _hotkey = value; return;
                }
                if ((IsRegistered) && (_hotkey != value))
                {
                    if (UnregisterHotkey())
                    {
                        Debug.WriteLine("Unreg: OK");
                        IsRegistered = false;
                    }
                    else
                    {
                        Debug.WriteLine("Unreg: ERR");
                    }
                }
                if (value == Shortcut.None)
                {
                    _hotkey = value; return;
                }
                if (RegisterHotkey(value))
                {
                    Debug.WriteLine("Reg: OK");
                    IsRegistered = true;
                }
                else
                {
                    Debug.WriteLine("Reg: ERR");
                }
                _hotkey = value;
            }
        }
    }
}
