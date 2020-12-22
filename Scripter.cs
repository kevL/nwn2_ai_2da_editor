using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	sealed class Scripter
		: Form
	{
		#region Fields (static)
		static int _x = -1, _y, _w, _h;
		#endregion Fields (static)


		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		internal Scripter(he he)
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.UserPaint
				   | ControlStyles.DoubleBuffer, true);

			if (_x != -1)
			{
				Location   = new Point(_x,_y); // TODO: check isOnScreen
				ClientSize = new Size (_w,_h);
			}
			else
				Location = new Point(he.Location.X + 20, he.Location.Y + 20);
		}
		#endregion cTor


		#region eventhandlers (override)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.WindowsShutDown)
			{
				_x = Location.X;
				_y = Location.Y;
				_w = ClientSize.Width;
				_h = ClientSize.Height;
			}
			base.OnFormClosing(e);
		}

		/// <summary>
		/// Requires 'KeyPreview' true.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.KeyData == Keys.Escape)
			{
				Close();
			}
			else
				base.OnKeyDown(e);
		}
		#endregion eventhandlers (override)


		#region eventhandlers
		/// <summary>
		/// Prevents the nose from taking focus. Don't look at the nose.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void enter_Nos(object sender, EventArgs e)
		{
			tb_Script.Select();
		}
		#endregion eventhandlers


		#region Methods
		/// <summary>
		/// Sets the titlebar text.
		/// </summary>
		/// <param name="title"></param>
		internal void SetTitleText(string title)
		{
			Text = title;
		}
		#endregion Methods


		#region Designer
		SplitContainer splitContainer;
		internal TextboxMasterSyncher tb_Script;
		internal TextBox tb_nos;

		/// <summary>
		/// 
		/// </summary>
		void InitializeComponent()
		{
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tb_Script = new nwn2_ai_2da_editor.TextboxMasterSyncher();
			this.tb_nos = new System.Windows.Forms.TextBox();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Panel1MinSize = 0;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tb_Script);
			this.splitContainer.Panel2.Controls.Add(this.tb_nos);
			this.splitContainer.Panel2MinSize = 0;
			this.splitContainer.Size = new System.Drawing.Size(792, 774);
			this.splitContainer.SplitterDistance = 150;
			this.splitContainer.SplitterWidth = 3;
			this.splitContainer.TabIndex = 0;
			// 
			// tb_Script
			// 
			this.tb_Script.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_Script.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_Script.Location = new System.Drawing.Point(35, 0);
			this.tb_Script.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Script.Multiline = true;
			this.tb_Script.Name = "tb_Script";
			this.tb_Script.ReadOnly = true;
			this.tb_Script.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tb_Script.Size = new System.Drawing.Size(604, 774);
			this.tb_Script.Slave = this.tb_nos;
			this.tb_Script.TabIndex = 0;
			this.tb_Script.WordWrap = false;
			// 
			// tb_nos
			// 
			this.tb_nos.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_nos.Dock = System.Windows.Forms.DockStyle.Left;
			this.tb_nos.Location = new System.Drawing.Point(0, 0);
			this.tb_nos.Margin = new System.Windows.Forms.Padding(0);
			this.tb_nos.Multiline = true;
			this.tb_nos.Name = "tb_nos";
			this.tb_nos.ReadOnly = true;
			this.tb_nos.Size = new System.Drawing.Size(35, 774);
			this.tb_nos.TabIndex = 1;
			this.tb_nos.TabStop = false;
			this.tb_nos.WordWrap = false;
			this.tb_nos.Enter += new System.EventHandler(this.enter_Nos);
			// 
			// Scripter
			// 
			this.ClientSize = new System.Drawing.Size(792, 774);
			this.Controls.Add(this.splitContainer);
			this.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Name = "Scripter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
