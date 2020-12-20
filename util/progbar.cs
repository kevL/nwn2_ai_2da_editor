using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A progress bar.
	/// </summary>
	class ProgBar
		: Form
	{
		int _val;

		internal int Stop
		{ private get; set; }


		/// <summary>
		/// cTor.
		/// </summary>
		internal ProgBar()
		{
			Size = new Size(320, 32);
			ControlBox = false;
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			TopMost = true;
		}


		/// <summary>
		/// Steps the bar.
		/// </summary>
		internal void Step()
		{
			if (++_val != Stop)
			{
				using (var graphics = CreateGraphics())
				{
					var rect = new Rectangle(ClientRectangle.X,
											 ClientRectangle.Y,
											 ClientRectangle.Width * _val / Stop,
											 ClientRectangle.Height);
					ProgressBarRenderer.DrawHorizontalChunks(graphics, rect);
				}
			}
			else
				Close();
		}
	}
}
