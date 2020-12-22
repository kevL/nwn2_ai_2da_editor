using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Derived class for TreeView.
	/// </summary>
	sealed class CompositedTreeView
		: TreeView
	{
		#region Properties (override)
		/// <summary>
		/// Prevents flicker.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000; // enable 'WS_EX_COMPOSITED'
				return cp;
			}
		}
		#endregion Properties (override)
	}


	/// <summary>
	/// Derived class for TabControl.
	/// </summary>
	sealed class CompositedTabControl
		: TabControl
	{
		#region Properties (override)
		/// <summary>
		/// Prevents flicker.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000; // enable 'WS_EX_COMPOSITED'
				return cp;
			}
		}
		#endregion Properties (override)
	}


	/// <summary>
	/// Derived class for TextBox. Allows integers only entered in the textbox.
	/// And ensures a decent format on Leave event.
	/// </summary>
	sealed class TextboxInt
		: TextBox
	{
		#region Fields
		string _pre = String.Empty;
		#endregion Fields


		#region eventhandlers (override)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged(EventArgs e)
		{
			bool retry = !String.IsNullOrEmpty(Text)	// allow blank string
					  && Text != "-";					// allow "-"

			if (retry)
			{
				int result;
				retry = !Int32.TryParse(Text, out result);
			}

			if (retry)
			{
				Text = _pre; // revert & recurse
				SelectionLength = 0;
				SelectionStart = Text.Length;
			}
			else
			{
				_pre = Text;
				base.OnTextChanged(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			string text = Text.Trim().TrimStart('0');

			int result;
			if (!Int32.TryParse(text, out result)
				|| result == 0) // handle unusual cases incl/ "", "-", "-0", "00", etc.
			{
				text = "0";
			}

			if (text != Text)
				Text = text;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Enter:
				case Keys.Escape:
					he.HenchControl.SelectResetButton();
					e.Handled = e.SuppressKeyPress = true;
					break;
			}
			base.OnKeyDown(e);
		}
		#endregion eventhandlers (override)
	}


	/// <summary>
	/// Derived class for TextBox. Allows floats only entered in the textbox.
	/// And ensures a decent format on Leave event.
	/// </summary>
	sealed class TextboxFloat
		: TextBox
	{
		string _pre = String.Empty;

		#region eventhandlers (override)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged(EventArgs e)
		{
			bool retry = !String.IsNullOrEmpty(Text)	// allow blank string
					  && Text != "-"					// allow "-"
					  && Text != "."					// allow "."
					  && Text != "-.";					// allow "-."

			if (retry)
			{
				float result;
				retry = !Single.TryParse(Text, out result);
			}

			if (retry)
			{
				Text = _pre; // revert & recurse
				SelectionLength = 0;
				SelectionStart = Text.Length;
			}
			else
			{
				_pre = Text;
				base.OnTextChanged(e);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnLeave(EventArgs e)
		{
			string text = Text.Trim().Trim('0');

			bool n = text.StartsWith("-", StringComparison.Ordinal);
			if (n)
				text = text.TrimStart('-');

			if (text.StartsWith(".", StringComparison.Ordinal))
				text = "0" + text;

			if (text.EndsWith(".", StringComparison.Ordinal))
				text += "0";

			float result;
			if (!Single.TryParse(text, out result)
				|| he.FloatsEqual(result, 0f)) // handle unusual cases incl/ "", "-", "-0", "00", etc.
			{
				text = "0.0";
			}
			else if (n)
				text = "-" + text;

			if (text.IndexOf('.') == -1)
				text += ".0";
			else if (text.EndsWith(".", StringComparison.Ordinal))
				text += "0";

			if (text != Text)
				Text = text;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Enter:
				case Keys.Escape:
					he.HenchControl.SelectResetButton();
					e.Handled = e.SuppressKeyPress = true;
					break;
			}
			base.OnKeyDown(e);
		}
		#endregion eventhandlers (override)
	}


	/// <summary>
	/// Synchronizes scrolling a slave-control with this derived TextBox.
	/// https://stackoverflow.com/questions/3823188/how-can-i-sync-the-scrolling-of-two-multiline-textboxes
	/// Issues
	/// - does not scroll by key-input when the caret forces the text to scroll
	/// - does not work when key-input on the slave-control forces its text to
	///   scroll (although that can be worked around by not allowing the slave
	///   to take focus)
	/// - mousedown (repeats) on the up/down scrollbar-arrows can cause the
	///   boxes to go out of synch at the bot if the slave has more lines than
	///   the master has (workaround: don't add more lines to the slave)
	/// </summary>
	class TextboxMasterSyncher
		: TextBox
	{
		public Control Slave { get; set; }

#if !__MonoCS__ // bypass on Mono builds - uses DllImport("user32.dll")
// NOTE: My IDE (#develop) renders the following text as disabled but it's not.
// It is working as expected ...

		const int WM_VSCROLL    = 0x115;
		const int WM_MOUSEWHEEL = 0x20a;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			// Trap WM_VSCROLL and WM_MOUSEWHEEL message and pass to 'Slave'
			if (Slave != null)
			{
				switch (m.Msg)
				{
					case WM_VSCROLL:
						if (Slave != null && Slave.IsHandleCreated)
						{
							//logfile.Log("mMsg= " + m.Msg + " m.WParam= " + m.WParam + " m.LParam= " + m.LParam); // does not print.
							SendMessage(Slave.Handle, m.Msg, m.WParam, m.LParam);
						}
						break;

					case WM_MOUSEWHEEL:
						// m.WParam: 1 - scroll down, 0 - scroll up
						if ((int)m.WParam < 0)
						{
							SendMessage(Handle, WM_VSCROLL, new IntPtr(1), new IntPtr(0));
						}
						else if ((int)m.WParam > 0)
						{
							SendMessage(Handle, WM_VSCROLL, new IntPtr(0), new IntPtr(0));
						}
						return; // prevent base.WndProc() from messing synchronization up
				}
			}
			base.WndProc(ref m); // do the usual
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
#endif
	}
}
