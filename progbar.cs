using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// TODO: Do I have to dispose this.

	/// <summary>
	/// A progress bar.
	/// </summary>
	class ProgBar
		:
			Form
	{
		int _valCur;

		public int ValTop
		{ get; set; }

		/// <summary>
		/// cTor.
		/// </summary>
		internal ProgBar()
		{
			Size = new Size(300, 50);
			ControlBox = false;
//			Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)(0));
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
//			Name = "ProgBar";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			TopMost = true;

			_valCur = 0;
		}


		internal void SetTotal(int total)
		{
			ValTop = total;
		}


		const int margin = 1;

		internal void Step()
		{
			if (++_valCur != ValTop)
			{
				using (var graphics = CreateGraphics())
				{
					var rectangle = new Rectangle(ClientRectangle.X + margin,
												  ClientRectangle.Y + margin,
												  ClientRectangle.Width * _valCur / ValTop - margin * 2,
												  ClientRectangle.Height - margin * 2);

					ProgressBarRenderer.DrawHorizontalChunks(graphics, rectangle);
				}
			}
			else
				Close();
		}


/*
		#region Windows Form Designer generated code
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();

			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify the contents of
		/// this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
		}
		#endregion
*/
	}
}
