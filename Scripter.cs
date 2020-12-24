using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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

				if (fields[i] != he.blank)
				{
					while (line.Length < 20) line += " ";
					line += fields[i];
				}

				int result;
				switch (i)
				{
					case 3: // MetaMagic
						if (fields[i].Length > 2 && fields[i].Substring(0,2) == "0x"
							&& Int32.TryParse(fields[i].Substring(2),
											  NumberStyles.AllowHexSpecifier, // <- that treats the string as hexadecimal notation
											  CultureInfo.InvariantCulture,   //    but does *not* allow the hex-specifier "0x"
											  out result))
						{
							// standard ->
							if ((result & META_EMPOWER)            != 0) line += Environment.NewLine + "  empower";
							if ((result & META_EXTEND)             != 0) line += Environment.NewLine + "  extend";
							if ((result & META_MAXIMIZE)           != 0) line += Environment.NewLine + "  maximize";
							if ((result & META_QUICKEN)            != 0) line += Environment.NewLine + "  quicken";
							if ((result & META_SILENT)             != 0) line += Environment.NewLine + "  silent";
							if ((result & META_STILL)              != 0) line += Environment.NewLine + "  still";
							if ((result & META_PERSISTENT)         != 0) line += Environment.NewLine + "  persistent";
							if ((result & META_PERMANENT)          != 0) line += Environment.NewLine + "  permanent";

							// Eldritch Essences ->
							if ((result & META_I_BESHADOWED_BLAST) != 0) line += Environment.NewLine + "  beshadowed blast";
							if ((result & META_I_BEWITCHING_BLAST) != 0) line += Environment.NewLine + "  bewitching blast";
							if ((result & META_I_BINDING_BLAST)    != 0) line += Environment.NewLine + "  binding blast";
							if ((result & META_I_BRIMSTONE_BLAST)  != 0) line += Environment.NewLine + "  brimstone blast";
							if ((result & META_I_DRAINING_BLAST)   != 0) line += Environment.NewLine + "  draining blast";
							if ((result & META_I_FRIGHTFUL_BLAST)  != 0) line += Environment.NewLine + "  frightful blast";
							if ((result & META_I_HELLRIME_BLAST)   != 0) line += Environment.NewLine + "  hellrime blast";
							if ((result & META_I_HINDERING_BLAST)  != 0) line += Environment.NewLine + "  hindering blast";
							if ((result & META_I_NOXIOUS_BLAST)    != 0) line += Environment.NewLine + "  noxious blast";
							if ((result & META_I_UTTERDARK_BLAST)  != 0) line += Environment.NewLine + "  utterdark blast";
							if ((result & META_I_VITRIOLIC_BLAST)  != 0) line += Environment.NewLine + "  vitriolic blast";

							// Blast Shapes ->
							if ((result & META_I_ELDRITCH_CHAIN)   != 0) line += Environment.NewLine + "  eldritch chain";
							if ((result & META_I_ELDRITCH_CONE)    != 0) line += Environment.NewLine + "  eldritch cone";
							if ((result & META_I_ELDRITCH_DOOM)    != 0) line += Environment.NewLine + "  eldritch doom";
							if ((result & META_I_ELDRITCH_SPEAR)   != 0) line += Environment.NewLine + "  eldritch spear";
							if ((result & META_I_HIDEOUS_BLOW)     != 0) line += Environment.NewLine + "  hideous blow";
						}
						break;

//					case 4: // TargetType
//						break;

					case 20: // Category
						if (Int32.TryParse(fields[i], out result)
							&& result > -1 && result < 26)
						{
							line += Environment.NewLine;
							switch (result)
							{
								case  0: line += "  none";                              break;
								case  1: line += "  HARMFUL_AREAEFFECT_DISCRIMINANT";   break;
								case  2: line += "  HARMFUL_RANGED";                    break;
								case  3: line += "  HARMFUL_TOUCH";                     break;
								case  4: line += "  BENEFICIAL_HEALING_AREAEFFECT";     break;
								case  5: line += "  BENEFICIAL_HEALING_TOUCH";          break;
								case  6: line += "  BENEFICIAL_CONDITIONAL_AREAEFFECT"; break;
								case  7: line += "  BENEFICIAL_CONDITIONAL_SINGLE";     break;
								case  8: line += "  BENEFICIAL_ENHANCEMENT_AREAEFFECT"; break;
								case  9: line += "  BENEFICIAL_ENHANCEMENT_SINGLE";     break;
								case 10: line += "  BENEFICIAL_ENHANCEMENT_SELF";       break;
								case 11: line += "  HARMFUL_AREAEFFECT_INDISCRIMINANT"; break;
								case 12: line += "  BENEFICIAL_PROTECTION_SELF";        break;
								case 13: line += "  BENEFICIAL_PROTECTION_SINGLE";      break;
								case 14: line += "  BENEFICIAL_PROTECTION_AREAEFFECT";  break;
								case 15: line += "  BENEFICIAL_OBTAIN_ALLIES";          break;
								case 16: line += "  PERSISTENT_AREA_OF_EFFECT";         break;
								case 17: line += "  BENEFICIAL_HEALING_POTION";         break;
								case 18: line += "  BENEFICIAL_CONDITIONAL_POTION";     break;
								case 19: line += "  DRAGONS_BREATH";                    break;
								case 20: line += "  BENEFICIAL_PROTECTION_POTION";      break;
								case 21: line += "  BENEFICIAL_ENHANCEMENT_POTION";     break;
								case 22: line += "  HARMFUL_MELEE";                     break;
								case 23: line += "  DISPEL";                            break;
								case 24: line += "  SPELLBREACH";                       break;
								case 25: line += "  CANTRIP";                           break;
							}
						}
						break;

					case 22: // UserType
						if (Int32.TryParse(fields[i], out result)
							&& result > 0 && result < 5)
						{
							line += Environment.NewLine;
							switch (result)
							{
								case 1: line += "  spell";           break;
								case 2: line += "  special ability"; break;
								case 3: line += "  feat";            break;
								case 4: line += "  item power";      break;
							}
						}
						break;
				}

				if (text != String.Empty) text += Environment.NewLine;
				text += line;
			}
			tb_Fields.Text = text;
		}

		// MetaMagic
		internal const int META_NONE               = 0x00000000; //        0
		internal const int META_EMPOWER            = 0x00000001; //        1
		internal const int META_EXTEND             = 0x00000002; //        2
		internal const int META_MAXIMIZE           = 0x00000004; //        4
		internal const int META_QUICKEN            = 0x00000008; //        8
		internal const int META_SILENT             = 0x00000010; //       16
		internal const int META_STILL              = 0x00000020; //       32
		internal const int META_PERSISTENT         = 0x00000040; //       64
		internal const int META_PERMANENT          = 0x00000080; //      128

		internal const int META_I_DRAINING_BLAST   = 0x00000100; //      256
		internal const int META_I_ELDRITCH_SPEAR   = 0x00000200; //      512
		internal const int META_I_FRIGHTFUL_BLAST  = 0x00000400; //     1024
		internal const int META_I_HIDEOUS_BLOW     = 0x00000800; //     2048
		internal const int META_I_BESHADOWED_BLAST = 0x00001000; //     4096
		internal const int META_I_BRIMSTONE_BLAST  = 0x00002000; //     8192
		internal const int META_I_ELDRITCH_CHAIN   = 0x00004000; //    16384
		internal const int META_I_HELLRIME_BLAST   = 0x00008000; //    32768
		internal const int META_I_BEWITCHING_BLAST = 0x00010000; //    65536
		internal const int META_I_ELDRITCH_CONE    = 0x00020000; //   131072
		internal const int META_I_NOXIOUS_BLAST    = 0x00040000; //   262144
		internal const int META_I_VITRIOLIC_BLAST  = 0x00080000; //   524288
		internal const int META_I_ELDRITCH_DOOM    = 0x00100000; //  1048576
		internal const int META_I_UTTERDARK_BLAST  = 0x00200000; //  2097152
		internal const int META_I_HINDERING_BLAST  = 0x00400000; //  4194304
		internal const int META_I_BINDING_BLAST    = 0x00800000; //  8388608


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
			_fieldcols.Add("[School]");				//  0
			_fieldcols.Add("[Range]");				//  1
			_fieldcols.Add("[VS]");					//  2
			_fieldcols.Add("[MetaMagic]");			//  3
//			_fieldcols.Add("[TargetType]");			//  4
			_fieldcols.Add("[Bard]");				//  5
			_fieldcols.Add("[Cleric]");				//  6
			_fieldcols.Add("[Druid]");				//  7
			_fieldcols.Add("[Paladin]");			//  8
			_fieldcols.Add("[Ranger]");				//  9
			_fieldcols.Add("[Wiz_Sorc]");			// 10
			_fieldcols.Add("[Warlock]");			// 11
			_fieldcols.Add("[Innate]");				// 12
			_fieldcols.Add("[ImmunityType]");		// 13
			_fieldcols.Add("[ItemImmunity]");		// 14
			_fieldcols.Add("[SubRadSpell1]");		// 15
			_fieldcols.Add("[SubRadSpell2]");		// 16
			_fieldcols.Add("[SubRadSpell3]");		// 17
			_fieldcols.Add("[SubRadSpell4]");		// 18
			_fieldcols.Add("[SubRadSpell5]");		// 19
			_fieldcols.Add("[Category]");			// 20
			_fieldcols.Add("[Master]");				// 21
			_fieldcols.Add("[UserType]");			// 22
			_fieldcols.Add("[UsesConcentration]");	// 23
			_fieldcols.Add("[SpontaneouslyCast]");	// 24
			_fieldcols.Add("[SpontCastClassReq]");	// 25
			_fieldcols.Add("[HostileSetting]");		// 26
			_fieldcols.Add("[FeatID]");				// 27
			_fieldcols.Add("[AsMetaMagic]");		// 28
			_fieldcols.Add("[REMOVED]");			// 30
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
			this.tb_Fields.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
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
