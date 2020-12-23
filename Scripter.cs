using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	sealed class Scripter
		: Form
	{
		#region Fields (static)
		static int _x = -1, _y, _w, _h;
		static int _p = -1;
		#endregion Fields (static)


		#region Fields
		List<string> _fieldcols = new List<string>();
		#endregion Fields


		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		internal Scripter(int x, int y)
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				   | ControlStyles.UserPaint
				   | ControlStyles.DoubleBuffer, true);

			tb_Fields.BackColor = Color.Honeydew;
			tb_Script.BackColor =
			tb_nos   .BackColor = Color.GhostWhite;

			SetFieldCols();

			if (_x != -1)
			{
				Location   = new Point(_x,_y); // TODO: check isOnScreen
				ClientSize = new Size (_w,_h);
			}
			else
				Location = new Point(x,y);

			if (_p != -1)
				splitContainer.SplitterDistance = _p;
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

				_p = splitContainer.SplitterDistance;
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="fields"></param>
		internal void SetFieldsText(IList<string> fields)
		{
			string text = String.Empty;
			string line;

			for (int i = 0; i != fields.Count; ++i)
			{
				line = _fieldcols[i];
				while (line.Length < 20) line += " ";
				line += fields[i];

				if (text != String.Empty) text += Environment.NewLine;
				text += line;
			}
			tb_Fields.Text = text;
		}

		/// <summary>
		/// 
		/// </summary>
		internal void ClearFieldsText()
		{
			tb_Fields.Text = String.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		void SetFieldCols()
		{
			_fieldcols.Add("[School]");
			_fieldcols.Add("[Range]");
			_fieldcols.Add("[VS]");
			_fieldcols.Add("[MetaMagic]");
			_fieldcols.Add("[TargetType]");
			_fieldcols.Add("[Bard]");
			_fieldcols.Add("[Cleric]");
			_fieldcols.Add("[Druid]");
			_fieldcols.Add("[Paladin]");
			_fieldcols.Add("[Ranger]");
			_fieldcols.Add("[Wiz_Sorc]");
			_fieldcols.Add("[Warlock]");
			_fieldcols.Add("[Innate]");
			_fieldcols.Add("[ImmunityType]");
			_fieldcols.Add("[ItemImmunity]");
			_fieldcols.Add("[SubRadSpell1]");
			_fieldcols.Add("[SubRadSpell2]");
			_fieldcols.Add("[SubRadSpell3]");
			_fieldcols.Add("[SubRadSpell4]");
			_fieldcols.Add("[SubRadSpell5]");
			_fieldcols.Add("[Category]");
			_fieldcols.Add("[Master]");
			_fieldcols.Add("[UserType]");
			_fieldcols.Add("[UsesConcentration]");
			_fieldcols.Add("[SpontaneouslyCast]");
			_fieldcols.Add("[SpontCastClassReq]");
			_fieldcols.Add("[HostileSetting]");
			_fieldcols.Add("[FeatID]");
			_fieldcols.Add("[AsMetaMagic]");
			_fieldcols.Add("[TargetingUI]");
			_fieldcols.Add("[CastableOnDead]");
			_fieldcols.Add("[REMOVED]");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="lines"></param>
		internal void SetScriptText(string[] lines)
		{
			string text0 = String.Empty;
			string text1 = String.Empty;
			for (int i = 0; i != lines.Length; ++i)
			{
				lines[i] = lines[i].TrimEnd();
				text1 += TabsToSpaces(lines[i]) + Environment.NewLine;

				text0 += (i + 1) + Environment.NewLine;
			}
//			text0 += (i + 1) + Environment.NewLine; // don't do that - linecounts equal.

			tb_nos   .Text = text0;
			tb_Script.Text = text1;

			tb_Script.Select();
			tb_Script.SelectionStart  = 0;
			tb_Script.SelectionLength = 0;
		}

		/// <summary>
		/// Replaces tabs in a string with spaces.
		/// </summary>
		/// <param name="line"></param>
		/// <returns></returns>
		static string TabsToSpaces(string line)
		{
			var list = new List<string>();
	
			var texts = line.Split('\t');

			foreach (var text in texts)
			{
				int spacecount = 4 - text.Length % 4;
				if (spacecount == 0)
					spacecount  = 4;

				list.Add(text + new string(' ', spacecount));
			}

			list[list.Count - 1] = list[list.Count - 1].TrimEnd();

			return String.Join("", list.ToArray());
		}
		#endregion Methods


		#region Designer
		SplitContainer splitContainer;
		TextBox tb_Fields;
		TextboxMasterSyncher tb_Script;
		TextBox tb_nos;

		/// <summary>
		/// 
		/// </summary>
		void InitializeComponent()
		{
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tb_Fields = new System.Windows.Forms.TextBox();
			this.tb_Script = new nwn2_ai_2da_editor.TextboxMasterSyncher();
			this.tb_nos = new System.Windows.Forms.TextBox();
			this.splitContainer.Panel1.SuspendLayout();
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
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tb_Fields);
			this.splitContainer.Panel1MinSize = 0;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tb_Script);
			this.splitContainer.Panel2.Controls.Add(this.tb_nos);
			this.splitContainer.Panel2MinSize = 1;
			this.splitContainer.Size = new System.Drawing.Size(992, 774);
			this.splitContainer.SplitterDistance = 180;
			this.splitContainer.SplitterWidth = 3;
			this.splitContainer.TabIndex = 0;
			// 
			// tb_Fields
			// 
			this.tb_Fields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_Fields.Location = new System.Drawing.Point(0, 0);
			this.tb_Fields.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Fields.Multiline = true;
			this.tb_Fields.Name = "tb_Fields";
			this.tb_Fields.ReadOnly = true;
			this.tb_Fields.Size = new System.Drawing.Size(180, 774);
			this.tb_Fields.TabIndex = 0;
			this.tb_Fields.WordWrap = false;
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
			this.tb_Script.Size = new System.Drawing.Size(774, 774);
			this.tb_Script.Slave = this.tb_nos;
			this.tb_Script.TabIndex = 0;
			this.tb_Script.WordWrap = false;
			// 
			// tb_nos
			// 
			this.tb_nos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			this.ClientSize = new System.Drawing.Size(992, 774);
			this.Controls.Add(this.splitContainer);
			this.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Name = "Scripter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
