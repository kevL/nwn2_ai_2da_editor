﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A UserControl with a TabControl set to Dock.Fill.
	/// </summary>
	sealed partial class tabcontrol_Racial
		: UserControl
	{
		/// <summary>
		/// Bitflags for spell-fields that have changed.
		/// @note: The master-int 'differ' is tracked in each racial-struct but
		/// is not saved to file.
		/// </summary>
		internal const int bit_clear = 0x00;
		internal const int bit_flags = 0x01;
		internal const int bit_feat1 = 0x02;
		internal const int bit_feat2 = 0x04;
		internal const int bit_feat3 = 0x08;
		internal const int bit_feat4 = 0x10;
		internal const int bit_feat5 = 0x20;

		he _he;


		#region cTor
		internal tabcontrol_Racial(he he)
		{
			InitializeComponent();

			_he = he;

			RacialFlags_hex.BackColor =
			RacialFlags_bin.BackColor =
			RacialFeat1_hex.BackColor =
			RacialFeat1_bin.BackColor =
			RacialFeat2_hex.BackColor =
			RacialFeat2_bin.BackColor =
			RacialFeat3_hex.BackColor =
			RacialFeat3_bin.BackColor =
			RacialFeat4_hex.BackColor =
			RacialFeat4_bin.BackColor =
			RacialFeat5_hex.BackColor =
			RacialFeat5_bin.BackColor = tp_Flags.BackColor;


// handlers for Flags ->
			RacialFlags_reset.Click       += Click_racial_reset;
			RacialFlags_text .TextChanged += TextChanged_racial;

			rf_Clear.Click += Click_clear;

			rf_HasFeatSpells.MouseClick += MouseClick_rFlags;

// handlers for Feats ->
			RacialFeat1_reset.Click       += Click_racial_reset;
			RacialFeat2_reset.Click       += Click_racial_reset;
			RacialFeat3_reset.Click       += Click_racial_reset;
			RacialFeat4_reset.Click       += Click_racial_reset;
			RacialFeat5_reset.Click       += Click_racial_reset;

			RacialFeat1_text .TextChanged += TextChanged_racial;
			RacialFeat2_text .TextChanged += TextChanged_racial;
			RacialFeat3_text .TextChanged += TextChanged_racial;
			RacialFeat4_text .TextChanged += TextChanged_racial;
			RacialFeat5_text .TextChanged += TextChanged_racial;

			rf1_Clear.Click += Click_clear;
			rf2_Clear.Click += Click_clear;
			rf3_Clear.Click += Click_clear;
			rf4_Clear.Click += Click_clear;
			rf5_Clear.Click += Click_clear;

			rf1_FeatId   .TextChanged += TextChanged_rFeat;
			rf2_FeatId   .TextChanged += TextChanged_rFeat;
			rf3_FeatId   .TextChanged += TextChanged_rFeat;
			rf4_FeatId   .TextChanged += TextChanged_rFeat;
			rf5_FeatId   .TextChanged += TextChanged_rFeat;

			rf1_SpellId  .TextChanged += TextChanged_rSpell;
			rf2_SpellId  .TextChanged += TextChanged_rSpell;
			rf3_SpellId  .TextChanged += TextChanged_rSpell;
			rf4_SpellId  .TextChanged += TextChanged_rSpell;
			rf5_SpellId  .TextChanged += TextChanged_rSpell;

			rf1_cheatCast.MouseClick  += MouseClick_rFeats;
			rf2_cheatCast.MouseClick  += MouseClick_rFeats;
			rf3_cheatCast.MouseClick  += MouseClick_rFeats;
			rf4_cheatCast.MouseClick  += MouseClick_rFeats;
			rf5_cheatCast.MouseClick  += MouseClick_rFeats;
		}
		#endregion cTor


		#region Events
		internal void Click_clear(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if      (btn ==  rf_Clear) RacialFlags_text.Text = "0";
			else if (btn == rf1_Clear) RacialFeat1_text.Text = "0";
			else if (btn == rf2_Clear) RacialFeat2_text.Text = "0";
			else if (btn == rf3_Clear) RacialFeat3_text.Text = "0";
			else if (btn == rf4_Clear) RacialFeat4_text.Text = "0";
			else                       RacialFeat5_text.Text = "0"; //if (btn == rf5_Clear)
		}
		#endregion Events


		#region Methods
		internal void SetResetColor(Color color)
		{
			RacialFlags_reset.ForeColor =
			RacialFeat1_reset.ForeColor =
			RacialFeat2_reset.ForeColor =
			RacialFeat3_reset.ForeColor =
			RacialFeat4_reset.ForeColor =
			RacialFeat5_reset.ForeColor = color;
		}


		/// <summary>
		/// Fills displayed fields w/ data from the race's Id.
		/// </summary>
		internal void SelectRace(Race race, IDictionary<int, RaceChanged> raceschanged, int id)
		{
			RacialFlags_text.Clear(); // clear the info-fields to force TextChanged events ->
			RacialFeat1_text.Clear();
			RacialFeat2_text.Clear();
			RacialFeat3_text.Clear();
			RacialFeat4_text.Clear();
			RacialFeat5_text.Clear();


			bool dirty = (race.differ != bit_clear);

// Flags
			int val = race.flags;
			RacialFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].flags;
			}
			RacialFlags_text.Text = val.ToString();

// Feat1
			val = race.feat1;
			RacialFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].feat1;
			}
			RacialFeat1_text.Text = val.ToString();

// Feat2
			val = race.feat2;
			RacialFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].feat2;
			}
			RacialFeat2_text.Text = val.ToString();

// Feat3
			val = race.feat3;
			RacialFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].feat3;
			}
			RacialFeat3_text.Text = val.ToString();

// Feat4
			val = race.feat4;
			RacialFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].feat4;
			}
			RacialFeat4_text.Text = val.ToString();

// Feat5
			val = race.feat5;
			RacialFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = raceschanged[id].feat5;
			}
			RacialFeat5_text.Text = val.ToString();
		}


		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="race">a Race struct</param>
		/// <param name="racechanged">a RaceChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		internal static int RaceDiffer(Race race, RaceChanged racechanged)
		{
			int differ = tabcontrol_Racial.bit_clear;

			if (race.flags != racechanged.flags)
				differ |= tabcontrol_Racial.bit_flags;

			if (race.feat1 != racechanged.feat1)
				differ |= tabcontrol_Racial.bit_feat1;

			if (race.feat2 != racechanged.feat2)
				differ |= tabcontrol_Racial.bit_feat2;

			if (race.feat3 != racechanged.feat3)
				differ |= tabcontrol_Racial.bit_feat3;

			if (race.feat4 != racechanged.feat4)
				differ |= tabcontrol_Racial.bit_feat4;

			if (race.feat5 != racechanged.feat5)
				differ |= tabcontrol_Racial.bit_feat5;

			return differ;
		}


		/// <summary>
		/// Gets the master-int of the currently selected page as a string.
		/// </summary>
		/// <returns></returns>
		internal string GetMasterText()
		{
			string info = String.Empty;
			switch (tc_Racial.SelectedIndex)
			{
				case 0: info = RacialFlags_text.Text; break;
				case 1: info = RacialFeat1_text.Text; break;
				case 2: info = RacialFeat2_text.Text; break;
				case 3: info = RacialFeat3_text.Text; break;
				case 4: info = RacialFeat4_text.Text; break;
				case 5: info = RacialFeat5_text.Text; break;
			}

			int i;
			if (Int32.TryParse(info, out i))
				return info;

			return String.Empty;
		}

		internal void SetMasterText(string text)
		{
			RacialFlags_text.Text = text;
		}
		#endregion Methods
	}
}
