using System;
using System.Collections;
using System.Collections.Generic;

// Minimal WinForms compatibility layer for cross-platform support.
// These stubs allow the business logic (decompiled from WinForms) to compile
// on macOS without requiring actual Windows Forms.

namespace System.Windows.Forms
{
    public class Control
    {
        public string Name { get; set; } = "";
        public string Text { get; set; } = "";
        public bool IsDisposed { get; set; }
        public bool HasChildren => false;
        public bool InvokeRequired => false;
        public bool Visible { get; set; } = true;
        public object? Tag { get; set; }
        public ControlCollection Controls { get; } = new ControlCollection();

        public object? Invoke(Delegate method) => method.DynamicInvoke();
        public object? Invoke(Delegate method, params object[] args) => method.DynamicInvoke(args);

        public class ControlCollection : IEnumerable<Control>
        {
            private readonly List<Control> _controls = new();
            public void Add(Control c) => _controls.Add(c);
            public IEnumerator<Control> GetEnumerator() => _controls.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }

    public class Label : Control { }

    public class CheckBox : Control
    {
        public bool Checked { get; set; }
        public event EventHandler? CheckedChanged;
        public event EventHandler? CheckStateChanged;
    }

    public class TextBox : Control { }

    public class ComboBox : Control
    {
        public ObjectCollection Items { get; } = new();
        public int SelectedIndex { get; set; } = -1;
        public object? DataSource { get; set; }
        public event EventHandler? SelectedIndexChanged;

        public class ObjectCollection : List<object> { }
    }

    public class ListControl : Control
    {
        public int SelectedIndex { get; set; }
    }

    public class Button : Control
    {
        public event EventHandler? Click;
    }

    public class Panel : Control { }

    public class PictureBox : Control
    {
        public object? Image { get; set; }
    }

    public class WebBrowser : Control
    {
        public HtmlDocument? Document { get; set; }
    }

    public class HtmlDocument
    {
        public HtmlElement? Body { get; set; }
        public HtmlElement CreateElement(string tag) => new HtmlElement { TagName = tag };
    }

    public class HtmlElement
    {
        public string TagName { get; set; } = "";
        public string InnerHtml { get; set; } = "";
        public void InsertAdjacentElement(HtmlElementInsertionOrientation orient, HtmlElement element) { }
    }

    public enum HtmlElementInsertionOrientation
    {
        BeforeBegin = 0,
        AfterBegin = 1,
        BeforeEnd = 2,
        AfterEnd = 3
    }

    public class Form : Control
    {
        public System.Drawing.Icon? Icon { get; set; }
        public bool Visible { get; set; }
        public event FormClosingEventHandler? FormClosing;
        public event EventHandler? Load;
        public void Close() { }
        protected virtual void Dispose(bool disposing) { }
    }

    public delegate void FormClosingEventHandler(object sender, FormClosingEventArgs e);

    public class FormClosingEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
    }

    public class BindingSource
    {
        public object? DataSource { get; set; }
    }

    public delegate void MethodInvoker();

    public class ToolTip
    {
        public void SetToolTip(Control control, string caption) { }
    }

    public class NotifyIcon : IDisposable
    {
        public string Text { get; set; } = "";
        public bool Visible { get; set; }
        public object? Icon { get; set; }
        public ContextMenuStrip? ContextMenuStrip { get; set; }
        public event EventHandler? DoubleClick;
        public void Dispose() { }
    }

    public class ContextMenuStrip : Control
    {
        public ToolStripItemCollection Items { get; } = new();
    }

    public class ToolStripItemCollection : List<ToolStripItem> { }

    public class ToolStripItem
    {
        public string Text { get; set; } = "";
        public event EventHandler? Click;
    }

    public class ToolStripMenuItem : ToolStripItem { }
    public class ToolStripSeparator : ToolStripItem { }

    public class MouseEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public static class Application
    {
        public static FormCollection OpenForms { get; } = new();
        public static void Exit() { }
        public static void Run(Form form) { }
    }

    public class FormCollection : IEnumerable
    {
        private readonly List<Form> _forms = new();
        public Form this[int index] => index < _forms.Count ? _forms[index] : new Form();
        public int Count => _forms.Count;
        public void Add(Form f) => _forms.Add(f);
        public IEnumerator GetEnumerator() => _forms.GetEnumerator();
    }

    public class BackgroundWorker
    {
        public bool WorkerSupportsCancellation { get; set; }
        public event DoWorkEventHandler? DoWork;
        public void RunWorkerAsync() => DoWork?.Invoke(this, new DoWorkEventArgs(null));
        public void CancelAsync() { }
    }

    public delegate void DoWorkEventHandler(object sender, DoWorkEventArgs e);

    public class DoWorkEventArgs : EventArgs
    {
        public object? Argument { get; }
        public object? Result { get; set; }
        public bool Cancel { get; set; }
        public DoWorkEventArgs(object? argument) => Argument = argument;
    }

    public class Screen
    {
        public System.Drawing.Rectangle WorkingArea { get; set; }
        public static Screen[] AllScreens => new[] { new Screen { WorkingArea = new System.Drawing.Rectangle(0, 0, 1920, 1080) } };
    }

    public class ComponentResourceManager
    {
        public ComponentResourceManager(Type type) { }
        public void ApplyResources(object value, string name) { }
    }

    public class IContainer : IDisposable
    {
        public void Dispose() { }
    }

    public static class MessageBox
    {
        public static DialogResult Show(string text) => DialogResult.OK;
        public static DialogResult Show(string text, string caption) => DialogResult.OK;
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons) => DialogResult.OK;
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) => DialogResult.OK;
    }

    public enum DialogResult { None, OK, Cancel, Abort, Retry, Ignore, Yes, No }
    public enum MessageBoxButtons { OK, OKCancel, AbortRetryIgnore, YesNoCancel, YesNo, RetryCancel }
    public enum MessageBoxIcon { None, Hand, Stop, Error, Question, Exclamation, Warning, Asterisk, Information }
}

namespace System.Windows.Forms.Layout
{
    public class ArrangedElementCollection : IEnumerable
    {
        public IEnumerator GetEnumerator() => new List<object>().GetEnumerator();
    }
}

// System.Drawing types are provided by the .NET runtime (System.Drawing.Primitives)
// We only need to add types that are NOT in the base .NET library

namespace System.Drawing
{
    // Image class stub (not in System.Drawing.Primitives)
    public class Image { }
    public class Bitmap : Image { }
    public class Icon { }

    public class Font
    {
        public Font(string familyName, float emSize) { }
        public Font(string familyName, float emSize, FontStyle style) { }
    }

    public enum FontStyle { Regular, Bold, Italic }
    public enum ContentAlignment { MiddleLeft, MiddleCenter, MiddleRight, TopLeft }
}
