using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A UserControl with a TabControl set to Dock.Fill.
	/// </summary>
	sealed partial class tabcontrol_Classes
		: UserControl
	{
		/// <summary>
		/// Bitflags for spell-fields that have changed.
		/// @note: The master-int 'differ' is tracked in each class-struct but
		/// is not saved to file.
		/// </summary>
		internal const int bit_clear  = 0x000;
		internal const int bit_flags  = 0x001;
		internal const int bit_feat1  = 0x002;
		internal const int bit_feat2  = 0x004;
		internal const int bit_feat3  = 0x008;
		internal const int bit_feat4  = 0x010;
		internal const int bit_feat5  = 0x020;
		internal const int bit_feat6  = 0x040;
		internal const int bit_feat7  = 0x080;
		internal const int bit_feat8  = 0x100;
		internal const int bit_feat9  = 0x200;
		internal const int bit_feat10 = 0x400;
		internal const int bit_feat11 = 0x800;


		#region cTor
		internal tabcontrol_Classes()
		{
			InitializeComponent();

			ClassFlags_hex .BackColor =
			ClassFlags_bin .BackColor =
			ClassFeat1_hex .BackColor =
			ClassFeat1_bin .BackColor =
			ClassFeat2_hex .BackColor =
			ClassFeat2_bin .BackColor =
			ClassFeat3_hex .BackColor =
			ClassFeat3_bin .BackColor =
			ClassFeat4_hex .BackColor =
			ClassFeat4_bin .BackColor =
			ClassFeat5_hex .BackColor =
			ClassFeat5_bin .BackColor =
			ClassFeat6_hex .BackColor =
			ClassFeat6_bin .BackColor =
			ClassFeat7_hex .BackColor =
			ClassFeat7_bin .BackColor =
			ClassFeat8_hex .BackColor =
			ClassFeat8_bin .BackColor =
			ClassFeat9_hex .BackColor =
			ClassFeat9_bin .BackColor =
			ClassFeat10_hex.BackColor =
			ClassFeat10_bin.BackColor =
			ClassFeat11_hex.BackColor =
			ClassFeat11_bin.BackColor = tp_Flags.BackColor;

			PopulateComboboxes();


// handlers for Flags ->
			ClassFlags_reset.Click       += Click_classes_reset;
			ClassFlags_text .TextChanged += TextChanged_classes;

			cf_Clear.Click += Click_clear;

			cbo_cf_Ability    .SelectionChangeCommitted += SelectionChangeCommitted_cf_cbo_CasterAbility;
			cbo_cf_BuffOthers .SelectionChangeCommitted += SelectionChangeCommitted_cf_cbo_BuffOthers;
			cbo_cf_Attack     .SelectionChangeCommitted += SelectionChangeCommitted_cf_cbo_Attack;
			cbo_cf_SpellProg  .SelectionChangeCommitted += SelectionChangeCommitted_cf_cbo_SpellProg;
			cbo_cf_SneakAttack.SelectionChangeCommitted += SelectionChangeCommitted_cf_cbo_SneakAttack;
			cf_rbArcane       .MouseClick               += MouseClick_cFlags;
			cf_rbDivine       .MouseClick               += MouseClick_cFlags;
			cf_isPrestigeClass.MouseClick               += MouseClick_cFlags;
			cf_DcBonus        .MouseClick               += MouseClick_cFlags;
			cf_L4Required     .MouseClick               += MouseClick_cFlags;

			cf_HasFeatSpells.MouseClick += MouseClick_cFlags;

// handlers for Feats ->
			ClassFeat1_reset .Click       += Click_classes_reset;
			ClassFeat2_reset .Click       += Click_classes_reset;
			ClassFeat3_reset .Click       += Click_classes_reset;
			ClassFeat4_reset .Click       += Click_classes_reset;
			ClassFeat5_reset .Click       += Click_classes_reset;
			ClassFeat6_reset .Click       += Click_classes_reset;
			ClassFeat7_reset .Click       += Click_classes_reset;
			ClassFeat8_reset .Click       += Click_classes_reset;
			ClassFeat9_reset .Click       += Click_classes_reset;
			ClassFeat10_reset.Click       += Click_classes_reset;
			ClassFeat11_reset.Click       += Click_classes_reset;

			ClassFeat1_text  .TextChanged += TextChanged_classes;
			ClassFeat2_text  .TextChanged += TextChanged_classes;
			ClassFeat3_text  .TextChanged += TextChanged_classes;
			ClassFeat4_text  .TextChanged += TextChanged_classes;
			ClassFeat5_text  .TextChanged += TextChanged_classes;
			ClassFeat6_text  .TextChanged += TextChanged_classes;
			ClassFeat7_text  .TextChanged += TextChanged_classes;
			ClassFeat8_text  .TextChanged += TextChanged_classes;
			ClassFeat9_text  .TextChanged += TextChanged_classes;
			ClassFeat10_text .TextChanged += TextChanged_classes;
			ClassFeat11_text .TextChanged += TextChanged_classes;

			cf1_Clear .Click += Click_clear;
			cf2_Clear .Click += Click_clear;
			cf3_Clear .Click += Click_clear;
			cf4_Clear .Click += Click_clear;
			cf5_Clear .Click += Click_clear;
			cf6_Clear .Click += Click_clear;
			cf7_Clear .Click += Click_clear;
			cf8_Clear .Click += Click_clear;
			cf9_Clear .Click += Click_clear;
			cf10_Clear.Click += Click_clear;
			cf11_Clear.Click += Click_clear;

			cf1_FeatId    .TextChanged += TextChanged_cFeat;
			cf2_FeatId    .TextChanged += TextChanged_cFeat;
			cf3_FeatId    .TextChanged += TextChanged_cFeat;
			cf4_FeatId    .TextChanged += TextChanged_cFeat;
			cf5_FeatId    .TextChanged += TextChanged_cFeat;
			cf6_FeatId    .TextChanged += TextChanged_cFeat;
			cf7_FeatId    .TextChanged += TextChanged_cFeat;
			cf8_FeatId    .TextChanged += TextChanged_cFeat;
			cf9_FeatId    .TextChanged += TextChanged_cFeat;
			cf10_FeatId   .TextChanged += TextChanged_cFeat;
			cf11_FeatId   .TextChanged += TextChanged_cFeat;

			cf1_SpellId   .TextChanged += TextChanged_cSpell;
			cf2_SpellId   .TextChanged += TextChanged_cSpell;
			cf3_SpellId   .TextChanged += TextChanged_cSpell;
			cf4_SpellId   .TextChanged += TextChanged_cSpell;
			cf5_SpellId   .TextChanged += TextChanged_cSpell;
			cf6_SpellId   .TextChanged += TextChanged_cSpell;
			cf7_SpellId   .TextChanged += TextChanged_cSpell;
			cf8_SpellId   .TextChanged += TextChanged_cSpell;
			cf9_SpellId   .TextChanged += TextChanged_cSpell;
			cf10_SpellId  .TextChanged += TextChanged_cSpell;
			cf11_SpellId  .TextChanged += TextChanged_cSpell;

			cf1_cheatCast .MouseClick  += MouseClick_cFeats;
			cf2_cheatCast .MouseClick  += MouseClick_cFeats;
			cf3_cheatCast .MouseClick  += MouseClick_cFeats;
			cf4_cheatCast .MouseClick  += MouseClick_cFeats;
			cf5_cheatCast .MouseClick  += MouseClick_cFeats;
			cf6_cheatCast .MouseClick  += MouseClick_cFeats;
			cf7_cheatCast .MouseClick  += MouseClick_cFeats;
			cf8_cheatCast .MouseClick  += MouseClick_cFeats;
			cf9_cheatCast .MouseClick  += MouseClick_cFeats;
			cf10_cheatCast.MouseClick  += MouseClick_cFeats;
			cf11_cheatCast.MouseClick  += MouseClick_cFeats;
		}
		#endregion cTor


		#region Events
		internal void Click_clear(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if      (btn ==   cf_Clear) ClassFlags_text .Text = "0";
			else if (btn ==  cf1_Clear) ClassFeat1_text .Text = "0";
			else if (btn ==  cf2_Clear) ClassFeat2_text .Text = "0";
			else if (btn ==  cf3_Clear) ClassFeat3_text .Text = "0";
			else if (btn ==  cf4_Clear) ClassFeat4_text .Text = "0";
			else if (btn ==  cf5_Clear) ClassFeat5_text .Text = "0";
			else if (btn ==  cf6_Clear) ClassFeat6_text .Text = "0";
			else if (btn ==  cf7_Clear) ClassFeat7_text .Text = "0";
			else if (btn ==  cf8_Clear) ClassFeat8_text .Text = "0";
			else if (btn ==  cf9_Clear) ClassFeat9_text .Text = "0";
			else if (btn == cf10_Clear) ClassFeat10_text.Text = "0";
			else                        ClassFeat11_text.Text = "0"; //if (btn == cf11_Clear)
		}
		#endregion Events


		#region Methods
		/// <summary>
		/// Populates the ClassFlags dropdown-lists.
		/// </summary>
		void PopulateComboboxes()
		{
			// populate the dropdown list for Casting Ability
			cbo_cf_Ability.Items.Add("none");			// 0
			cbo_cf_Ability.Items.Add("intelligence");	// 1
			cbo_cf_Ability.Items.Add("wisdom");			// 2
			cbo_cf_Ability.Items.Add("charisma");		// 3

			// populate the dropdown list for Buff Others
			cbo_cf_BuffOthers.Items.Add("full");	// 0
			cbo_cf_BuffOthers.Items.Add("high");	// 1
			cbo_cf_BuffOthers.Items.Add("medium");	// 2
			cbo_cf_BuffOthers.Items.Add("low");		// 3

			// populate the dropdown list for Attack
			cbo_cf_Attack.Items.Add("full");	// 0
			cbo_cf_Attack.Items.Add("high");	// 1
			cbo_cf_Attack.Items.Add("medium");	// 2
			cbo_cf_Attack.Items.Add("low");		// 3

			// populate the dropdown list for Spell Progression
			cbo_cf_SpellProg.Items.Add("none");				// 0
			cbo_cf_SpellProg.Items.Add("[not used]");		// 1 - not used.
			cbo_cf_SpellProg.Items.Add("skip 1st & 3rd");	// 2
			cbo_cf_SpellProg.Items.Add("even levels");		// 3
			cbo_cf_SpellProg.Items.Add("odd levels");		// 4
			cbo_cf_SpellProg.Items.Add("skip 4th");			// 5
			cbo_cf_SpellProg.Items.Add("skip 1st");			// 6
			cbo_cf_SpellProg.Items.Add("full");				// 7

			// populate the dropdown list for Sneak Attack
			cbo_cf_SneakAttack.Items.Add("none");					// 0
			cbo_cf_SneakAttack.Items.Add("odd levels");				// 1
			cbo_cf_SneakAttack.Items.Add("even levels");			// 2
			cbo_cf_SneakAttack.Items.Add("every 3rd, skip 1st");	// 3
			cbo_cf_SneakAttack.Items.Add("every 3rd");				// 4
			cbo_cf_SneakAttack.Items.Add("every 3rd after 2nd");	// 5
			cbo_cf_SneakAttack.Items.Add("every 3rd after 1st");	// 6
			cbo_cf_SneakAttack.Items.Add("every 4th");				// 7
		}


		internal void SetResetColor(Color color)
		{
			ClassFlags_reset .ForeColor =
			ClassFeat1_reset .ForeColor =
			ClassFeat2_reset .ForeColor =
			ClassFeat3_reset .ForeColor =
			ClassFeat4_reset .ForeColor =
			ClassFeat5_reset .ForeColor =
			ClassFeat6_reset .ForeColor =
			ClassFeat7_reset .ForeColor =
			ClassFeat8_reset .ForeColor =
			ClassFeat9_reset .ForeColor =
			ClassFeat10_reset.ForeColor =
			ClassFeat11_reset.ForeColor = color;
		}


		/// <summary>
		/// Fills displayed fields w/ data from the class' Id.
		/// </summary>
		internal void SelectClass(Class @class, IDictionary<int, ClassChanged> classeschanged, int id)
		{
			ClassFlags_text .Clear(); // clear the info-fields to force TextChanged events ->
			ClassFeat1_text .Clear();
			ClassFeat2_text .Clear();
			ClassFeat3_text .Clear();
			ClassFeat4_text .Clear();
			ClassFeat5_text .Clear();
			ClassFeat6_text .Clear();
			ClassFeat7_text .Clear();
			ClassFeat8_text .Clear();
			ClassFeat9_text .Clear();
			ClassFeat10_text.Clear();
			ClassFeat11_text.Clear();


			bool dirty = (@class.differ != bit_clear);

// Flags
			int val = @class.flags;
			ClassFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].flags;
			}
			ClassFlags_text.Text = val.ToString();

// Feat1
			val = @class.feat1;
			ClassFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat1;
			}
			ClassFeat1_text.Text = val.ToString();

// Feat2
			val = @class.feat2;
			ClassFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat2;
			}
			ClassFeat2_text.Text = val.ToString();

// Feat3
			val = @class.feat3;
			ClassFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat3;
			}
			ClassFeat3_text.Text = val.ToString();

// Feat4
			val = @class.feat4;
			ClassFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat4;
			}
			ClassFeat4_text.Text = val.ToString();

// Feat5
			val = @class.feat5;
			ClassFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat5;
			}
			ClassFeat5_text.Text = val.ToString();

// Feat6
			val = @class.feat6;
			ClassFeat6_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat6;
			}
			ClassFeat6_text.Text = val.ToString();

// Feat7
			val = @class.feat7;
			ClassFeat7_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat7;
			}
			ClassFeat7_text.Text = val.ToString();

// Feat8
			val = @class.feat8;
			ClassFeat8_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat8;
			}
			ClassFeat8_text.Text = val.ToString();

// Feat9
			val = @class.feat9;
			ClassFeat9_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat9;
			}
			ClassFeat9_text.Text = val.ToString();

// Feat10
			val = @class.feat10;
			ClassFeat10_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat10;
			}
			ClassFeat10_text.Text = val.ToString();

// Feat11
			val = @class.feat11;
			ClassFeat11_reset.Text = val.ToString();

			if (dirty)
			{
				val = classeschanged[id].feat11;
			}
			ClassFeat11_text.Text = val.ToString();
		}


		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="class">a Class struct</param>
		/// <param name="classchanged">a ClassChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		internal static int ClassDiffer(Class @class, ClassChanged classchanged)
		{
			int differ = tabcontrol_Classes.bit_clear;

			if (@class.flags != classchanged.flags)
				differ |= tabcontrol_Classes.bit_flags;

			if (@class.feat1 != classchanged.feat1)
				differ |= tabcontrol_Classes.bit_feat1;

			if (@class.feat2 != classchanged.feat2)
				differ |= tabcontrol_Classes.bit_feat2;

			if (@class.feat3 != classchanged.feat3)
				differ |= tabcontrol_Classes.bit_feat3;

			if (@class.feat4 != classchanged.feat4)
				differ |= tabcontrol_Classes.bit_feat4;

			if (@class.feat5 != classchanged.feat5)
				differ |= tabcontrol_Classes.bit_feat5;

			if (@class.feat6 != classchanged.feat6)
				differ |= tabcontrol_Classes.bit_feat6;

			if (@class.feat7 != classchanged.feat7)
				differ |= tabcontrol_Classes.bit_feat7;

			if (@class.feat8 != classchanged.feat8)
				differ |= tabcontrol_Classes.bit_feat8;

			if (@class.feat9 != classchanged.feat9)
				differ |= tabcontrol_Classes.bit_feat9;

			if (@class.feat10 != classchanged.feat10)
				differ |= tabcontrol_Classes.bit_feat10;

			if (@class.feat11 != classchanged.feat11)
				differ |= tabcontrol_Classes.bit_feat11;

			return differ;
		}


		/// <summary>
		/// Gets the master-int of the currently selected page as a string.
		/// </summary>
		/// <returns></returns>
		internal string GetMasterText()
		{
			string info = String.Empty;
			switch (tc_Classes.SelectedIndex)
			{
				case  0: info = ClassFlags_text .Text; break;
				case  1: info = ClassFeat1_text .Text; break;
				case  2: info = ClassFeat2_text .Text; break;
				case  3: info = ClassFeat3_text .Text; break;
				case  4: info = ClassFeat4_text .Text; break;
				case  5: info = ClassFeat5_text .Text; break;
				case  6: info = ClassFeat6_text .Text; break;
				case  7: info = ClassFeat7_text .Text; break;
				case  8: info = ClassFeat8_text .Text; break;
				case  9: info = ClassFeat9_text .Text; break;
				case 10: info = ClassFeat10_text.Text; break;
				case 11: info = ClassFeat11_text.Text; break;
			}

			int i;
			if (Int32.TryParse(info, out i))
				return info;

			return String.Empty;
		}

		internal void SetMasterText(string text)
		{
			ClassFlags_text.Text = text;
		}
		#endregion Methods
	}
}
