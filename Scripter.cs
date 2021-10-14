using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	sealed partial class Scripter
		: Form
	{
		#region Fields (static)
		static int _x = -1, _y, _w, _h;
		static int _p = -1;

		// MetaMagic
//		const int META_NONE               = 0x00000000; //        0
		const int META_EMPOWER            = 0x00000001; //        1
		const int META_EXTEND             = 0x00000002; //        2
		const int META_MAXIMIZE           = 0x00000004; //        4
		const int META_QUICKEN            = 0x00000008; //        8
		const int META_SILENT             = 0x00000010; //       16
		const int META_STILL              = 0x00000020; //       32
		const int META_PERSISTENT         = 0x00000040; //       64
		const int META_PERMANENT          = 0x00000080; //      128

		const int META_I_DRAINING_BLAST   = 0x00000100; //      256
		const int META_I_ELDRITCH_SPEAR   = 0x00000200; //      512
		const int META_I_FRIGHTFUL_BLAST  = 0x00000400; //     1024
		const int META_I_HIDEOUS_BLOW     = 0x00000800; //     2048
		const int META_I_BESHADOWED_BLAST = 0x00001000; //     4096
		const int META_I_BRIMSTONE_BLAST  = 0x00002000; //     8192
		const int META_I_ELDRITCH_CHAIN   = 0x00004000; //    16384
		const int META_I_HELLRIME_BLAST   = 0x00008000; //    32768
		const int META_I_BEWITCHING_BLAST = 0x00010000; //    65536
		const int META_I_ELDRITCH_CONE    = 0x00020000; //   131072
		const int META_I_NOXIOUS_BLAST    = 0x00040000; //   262144
		const int META_I_VITRIOLIC_BLAST  = 0x00080000; //   524288
		const int META_I_ELDRITCH_DOOM    = 0x00100000; //  1048576
		const int META_I_UTTERDARK_BLAST  = 0x00200000; //  2097152
		const int META_I_HINDERING_BLAST  = 0x00400000; //  4194304
		const int META_I_BINDING_BLAST    = 0x00800000; //  8388608
		#endregion Fields (static)


		#region Fields
		List<string> _fieldcols = new List<string>();

		int FIELD_School            = -1;
		int FIELD_Range             = -1;
		int FIELD_VS                = -1;
		int FIELD_MetaMagic         = -1;
//		int FIELD_TargetType        = -1;
		int FIELD_Bard              = -1;
		int FIELD_Cleric            = -1;
		int FIELD_Druid             = -1;
		int FIELD_Paladin           = -1;
		int FIELD_Ranger            = -1;
		int FIELD_Wiz_Sorc          = -1;
		int FIELD_Warlock           = -1;
		int FIELD_Innate            = -1;
		int FIELD_ImmunityType      = -1;
		int FIELD_ItemImmunity      = -1;
		int FIELD_SubRadSpell1      = -1;
		int FIELD_SubRadSpell2      = -1;
		int FIELD_SubRadSpell3      = -1;
		int FIELD_SubRadSpell4      = -1;
		int FIELD_SubRadSpell5      = -1;
		int FIELD_Category          = -1;
		int FIELD_Master            = -1;
		int FIELD_UserType          = -1;
		int FIELD_UsesConcentration = -1;
		int FIELD_SpontaneouslyCast = -1;
		int FIELD_SpontCastClassReq = -1;
		int FIELD_HostileSetting    = -1;
		int FIELD_FeatID            = -1;
		int FIELD_AsMetaMagic       = -1;
		int FIELD_REMOVED           = -1;
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

				if (fields[i] != he.stars)
				{
					while (line.Length < 20) line += " ";
					line += fields[i];
				}

				int result;
				if (i == FIELD_MetaMagic) // NOTE: switch() uses constant vals only.
				{
					if (fields[i].Length > 2 && fields[i].Substring(0,2) == "0x"
						&& Int32.TryParse(fields[i].Substring(2),
										  NumberStyles.AllowHexSpecifier, // <- that treats the string as hexadecimal notation
										  CultureInfo.InvariantCulture,   //    but does *not* allow the hex-specifier "0x"
										  out result))
					{
						// standard ->
						if ((result & META_EMPOWER)            != 0) line += Environment.NewLine + " empower";
						if ((result & META_EXTEND)             != 0) line += Environment.NewLine + " extend";
						if ((result & META_MAXIMIZE)           != 0) line += Environment.NewLine + " maximize";
						if ((result & META_QUICKEN)            != 0) line += Environment.NewLine + " quicken";
						if ((result & META_SILENT)             != 0) line += Environment.NewLine + " silent";
						if ((result & META_STILL)              != 0) line += Environment.NewLine + " still";
						if ((result & META_PERSISTENT)         != 0) line += Environment.NewLine + " persistent";
						if ((result & META_PERMANENT)          != 0) line += Environment.NewLine + " permanent";

						// Eldritch Essences ->
						if ((result & META_I_BESHADOWED_BLAST) != 0) line += Environment.NewLine + " beshadowed blast";
						if ((result & META_I_BEWITCHING_BLAST) != 0) line += Environment.NewLine + " bewitching blast";
						if ((result & META_I_BINDING_BLAST)    != 0) line += Environment.NewLine + " binding blast";
						if ((result & META_I_BRIMSTONE_BLAST)  != 0) line += Environment.NewLine + " brimstone blast";
						if ((result & META_I_DRAINING_BLAST)   != 0) line += Environment.NewLine + " draining blast";
						if ((result & META_I_FRIGHTFUL_BLAST)  != 0) line += Environment.NewLine + " frightful blast";
						if ((result & META_I_HELLRIME_BLAST)   != 0) line += Environment.NewLine + " hellrime blast";
						if ((result & META_I_HINDERING_BLAST)  != 0) line += Environment.NewLine + " hindering blast";
						if ((result & META_I_NOXIOUS_BLAST)    != 0) line += Environment.NewLine + " noxious blast";
						if ((result & META_I_UTTERDARK_BLAST)  != 0) line += Environment.NewLine + " utterdark blast";
						if ((result & META_I_VITRIOLIC_BLAST)  != 0) line += Environment.NewLine + " vitriolic blast";

						// Blast Shapes ->
						if ((result & META_I_ELDRITCH_CHAIN)   != 0) line += Environment.NewLine + " eldritch chain";
						if ((result & META_I_ELDRITCH_CONE)    != 0) line += Environment.NewLine + " eldritch cone";
						if ((result & META_I_ELDRITCH_DOOM)    != 0) line += Environment.NewLine + " eldritch doom";
						if ((result & META_I_ELDRITCH_SPEAR)   != 0) line += Environment.NewLine + " eldritch spear";
						if ((result & META_I_HIDEOUS_BLOW)     != 0) line += Environment.NewLine + " hideous blow";
					}
				}
				else if (i == FIELD_Category)
				{
					if (Int32.TryParse(fields[i], out result)
						&& result > -1 && result < 26)
					{
						line += Environment.NewLine;
						switch (result)
						{
							case  0: line += " none";                              break;
							case  1: line += " HARMFUL_AREAEFFECT_DISCRIMINANT";   break;
							case  2: line += " HARMFUL_RANGED";                    break;
							case  3: line += " HARMFUL_TOUCH";                     break;
							case  4: line += " BENEFICIAL_HEALING_AREAEFFECT";     break;
							case  5: line += " BENEFICIAL_HEALING_TOUCH";          break;
							case  6: line += " BENEFICIAL_CONDITIONAL_AREAEFFECT"; break;
							case  7: line += " BENEFICIAL_CONDITIONAL_SINGLE";     break;
							case  8: line += " BENEFICIAL_ENHANCEMENT_AREAEFFECT"; break;
							case  9: line += " BENEFICIAL_ENHANCEMENT_SINGLE";     break;
							case 10: line += " BENEFICIAL_ENHANCEMENT_SELF";       break;
							case 11: line += " HARMFUL_AREAEFFECT_INDISCRIMINANT"; break;
							case 12: line += " BENEFICIAL_PROTECTION_SELF";        break;
							case 13: line += " BENEFICIAL_PROTECTION_SINGLE";      break;
							case 14: line += " BENEFICIAL_PROTECTION_AREAEFFECT";  break;
							case 15: line += " BENEFICIAL_OBTAIN_ALLIES";          break;
							case 16: line += " PERSISTENT_AREA_OF_EFFECT";         break;
							case 17: line += " BENEFICIAL_HEALING_POTION";         break;
							case 18: line += " BENEFICIAL_CONDITIONAL_POTION";     break;
							case 19: line += " DRAGONS_BREATH";                    break;
							case 20: line += " BENEFICIAL_PROTECTION_POTION";      break;
							case 21: line += " BENEFICIAL_ENHANCEMENT_POTION";     break;
							case 22: line += " HARMFUL_MELEE";                     break;
							case 23: line += " DISPEL";                            break;
							case 24: line += " SPELLBREACH";                       break;
							case 25: line += " CANTRIP";                           break;
						}
					}
				}
				else if (i == FIELD_UserType)
				{
					if (Int32.TryParse(fields[i], out result)
						&& result > 0 && result < 5)
					{
						line += Environment.NewLine;
						switch (result)
						{
							case 1: line += " spell";           break;
							case 2: line += " special ability"; break;
							case 3: line += " feat";            break;
							case 4: line += " item power";      break;
						}
					}
				}

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
			int i = -1;

			_fieldcols.Add("[School]");            FIELD_School            = ++i;
			_fieldcols.Add("[Range]");             FIELD_Range             = ++i;
			_fieldcols.Add("[VS]");                FIELD_VS                = ++i;
			_fieldcols.Add("[MetaMagic]");         FIELD_MetaMagic         = ++i;
//			_fieldcols.Add("[TargetType]");        FIELD_TargetType        = ++i;
			_fieldcols.Add("[Bard]");              FIELD_Bard              = ++i;
			_fieldcols.Add("[Cleric]");            FIELD_Cleric            = ++i;
			_fieldcols.Add("[Druid]");             FIELD_Druid             = ++i;
			_fieldcols.Add("[Paladin]");           FIELD_Paladin           = ++i;
			_fieldcols.Add("[Ranger]");            FIELD_Ranger            = ++i;
			_fieldcols.Add("[Wiz_Sorc]");          FIELD_Wiz_Sorc          = ++i;
			_fieldcols.Add("[Warlock]");           FIELD_Warlock           = ++i;
			_fieldcols.Add("[Innate]");            FIELD_Innate            = ++i;
			_fieldcols.Add("[ImmunityType]");      FIELD_ImmunityType      = ++i;
			_fieldcols.Add("[ItemImmunity]");      FIELD_ItemImmunity      = ++i;
			_fieldcols.Add("[SubRadSpell1]");      FIELD_SubRadSpell1      = ++i;
			_fieldcols.Add("[SubRadSpell2]");      FIELD_SubRadSpell2      = ++i;
			_fieldcols.Add("[SubRadSpell3]");      FIELD_SubRadSpell3      = ++i;
			_fieldcols.Add("[SubRadSpell4]");      FIELD_SubRadSpell4      = ++i;
			_fieldcols.Add("[SubRadSpell5]");      FIELD_SubRadSpell5      = ++i;
			_fieldcols.Add("[Category]");          FIELD_Category          = ++i;
			_fieldcols.Add("[Master]");            FIELD_Master            = ++i;
			_fieldcols.Add("[UserType]");          FIELD_UserType          = ++i;
			_fieldcols.Add("[UsesConcentration]"); FIELD_UsesConcentration = ++i;
			_fieldcols.Add("[SpontaneouslyCast]"); FIELD_SpontaneouslyCast = ++i;
			_fieldcols.Add("[SpontCastClassReq]"); FIELD_SpontCastClassReq = ++i;
			_fieldcols.Add("[HostileSetting]");    FIELD_HostileSetting    = ++i;
			_fieldcols.Add("[FeatID]");            FIELD_FeatID            = ++i;
			_fieldcols.Add("[AsMetaMagic]");       FIELD_AsMetaMagic       = ++i;
			_fieldcols.Add("[REMOVED]");           FIELD_REMOVED           = ++i;
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
	}
}
