using System;
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
	/// Derived class for TextBox. Allows integers only in the textbox.
	/// </summary>
	sealed class TextboxInt
		: TextBox
	{
		string _pre = String.Empty;

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
	}
}
