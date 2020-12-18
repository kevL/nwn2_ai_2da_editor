﻿using System;
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
		int _valCur; // inits to 0

		public int ValTop
		{ get; set; }

		/// <summary>
		/// cTor.
		/// </summary>
		internal ProgBar()
		{
			Size = new Size(300, 50);
			ControlBox = false;
			FormBorderStyle = FormBorderStyle.SizableToolWindow;
			MaximizeBox = false;
			MinimizeBox = false;
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			StartPosition = FormStartPosition.CenterScreen;
			TopMost = true;

//			Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, (byte)(0));
//			Name = "ProgBar";
		}


		const int margin = 1;

		internal void Step()
		{
			if (++_valCur != ValTop)
			{
				using (var graphics = CreateGraphics())
				{
					var rect = new Rectangle(ClientRectangle.X + margin,
											 ClientRectangle.Y + margin,
											 ClientRectangle.Width * _valCur / ValTop - margin * 2,
											 ClientRectangle.Height - margin * 2);

					ProgressBarRenderer.DrawHorizontalChunks(graphics, rect);
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