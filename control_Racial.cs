﻿using System;
using System.Drawing;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A <c><see cref="HenchControl"/></c> with a <c>TabControl</c> set to
	/// <c>Dock.Fill</c>.
	/// </summary>
	sealed partial class control_Racial
		: HenchControl
	{
		#region Fields (static)
		/// <summary>
		/// Bitflags for spell-fields that have changed.
		/// </summary>
		/// <remarks>The master-int
		/// <c><see cref="Race.differ">Race.differ</see></c> is tracked in each
		/// <c><see cref="Race"/></c> struct but is not saved to file.</remarks>
		internal const int bit_clean = 0x00;
		internal const int bit_flags = 0x01;
				 const int bit_feat1 = 0x02;
				 const int bit_feat2 = 0x04;
				 const int bit_feat3 = 0x08;
				 const int bit_feat4 = 0x10;
				 const int bit_feat5 = 0x20;
		#endregion Fields (static)


		#region Fields
		he _he;
		#endregion Fields


		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		/// <param name="he"></param>
		internal control_Racial(he he)
		{
			InitializeComponent();

			_he = he;

			rf1_FeatLabel .Text =
			rf2_FeatLabel .Text =
			rf3_FeatLabel .Text =
			rf4_FeatLabel .Text =
			rf5_FeatLabel .Text =
			rf1_SpellLabel.Text =
			rf2_SpellLabel.Text =
			rf3_SpellLabel.Text =
			rf4_SpellLabel.Text =
			rf5_SpellLabel.Text = String.Empty;

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

			RacialFlags_hex.Font =
			RacialFlags_bin.Font =
			RacialFeat1_hex.Font =
			RacialFeat1_bin.Font =
			RacialFeat2_hex.Font =
			RacialFeat2_bin.Font =
			RacialFeat3_hex.Font =
			RacialFeat3_bin.Font =
			RacialFeat4_hex.Font =
			RacialFeat4_bin.Font =
			RacialFeat5_hex.Font =
			RacialFeat5_bin.Font = he.FixedFont;


// handlers for Flags ->
			RacialFlags_reset.Click       += Click_racial_reset;
			RacialFlags_text .TextChanged += TextChanged_racial;

			rf_Clear.Click += Click_clear;

			rf_HasFeatSpells.MouseClick += MouseClick_rFlags;

// handlers for Feats ->
			RacialFeat1_reset.Click += Click_racial_reset;
			RacialFeat2_reset.Click += Click_racial_reset;
			RacialFeat3_reset.Click += Click_racial_reset;
			RacialFeat4_reset.Click += Click_racial_reset;
			RacialFeat5_reset.Click += Click_racial_reset;

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

			_he.SelectSearch();
		}
		#endregion cTor


		#region eventhandlers
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_clear(object sender, EventArgs e)
		{
			if      (sender ==  rf_Clear) RacialFlags_text.Text = "0";
			else if (sender == rf1_Clear) RacialFeat1_text.Text = "0";
			else if (sender == rf2_Clear) RacialFeat2_text.Text = "0";
			else if (sender == rf3_Clear) RacialFeat3_text.Text = "0";
			else if (sender == rf4_Clear) RacialFeat4_text.Text = "0";
			else                          RacialFeat5_text.Text = "0"; // sender == rf5_Clear
		}
		#endregion eventhandlers


		#region HenchControl (override)
		/// <summary>
		/// Fills displayed fields w/ data from the race's Id.
		/// </summary>
		internal override void SelectId()
		{
			RacialFlags_text.Clear(); // clear the info-fields to force TextChanged events ->
			RacialFeat1_text.Clear();
			RacialFeat2_text.Clear();
			RacialFeat3_text.Clear();
			RacialFeat4_text.Clear();
			RacialFeat5_text.Clear();


			Race race = he.Races[he.Id];

			bool dirty = (race.differ != bit_clean);

			RaceChanged racechanged;
			if (dirty)
			{
				racechanged = he.RacesChanged[he.Id];
			}
			else
				racechanged = new RaceChanged(); // not used.

			int val = race.flags;
			RacialFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.flags;
			}
			RacialFlags_text.Text = val.ToString();

			val = race.feat1;
			RacialFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.feat1;
			}
			RacialFeat1_text.Text = val.ToString();

			val = race.feat2;
			RacialFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.feat2;
			}
			RacialFeat2_text.Text = val.ToString();

			val = race.feat3;
			RacialFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.feat3;
			}
			RacialFeat3_text.Text = val.ToString();

			val = race.feat4;
			RacialFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.feat4;
			}
			RacialFeat4_text.Text = val.ToString();

			val = race.feat5;
			RacialFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = racechanged.feat5;
			}
			RacialFeat5_text.Text = val.ToString();
		}

		/// <summary>
		/// Gets the master-int of the currently selected page as a string.
		/// </summary>
		/// <returns></returns>
		internal override string GetMasterText()
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

			int result;
			if (Int32.TryParse(info, out result))
				return info;

			return String.Empty;
		}

		/// <summary>
		/// Sets the master-int in <c><see cref="RacialFlags_text"/></c>.
		/// </summary>
		/// <param name="text"></param>
		internal override void SetMasterText(string text)
		{
			RacialFlags_text.Text = text;
		}

		/// <summary>
		/// Selects a Reset <c>Button</c> as the (default or fallback) control
		/// to take focus.
		/// </summary>
		internal override void SelectResetButton()
		{
			switch (tc_Racial.SelectedIndex)
			{
				case 0: RacialFlags_reset.Select(); break;
				case 1: RacialFeat1_reset.Select(); break;
				case 2: RacialFeat2_reset.Select(); break;
				case 3: RacialFeat3_reset.Select(); break;
				case 4: RacialFeat4_reset.Select(); break;
				case 5: RacialFeat5_reset.Select(); break;
			}
		}

		/// <summary>
		/// Sets the Reset <c>Buttons'</c> text-color.
		/// </summary>
		/// <param name="color"></param>
		internal override void SetResetColor(Color color)
		{
			RacialFlags_reset.ForeColor =
			RacialFeat1_reset.ForeColor =
			RacialFeat2_reset.ForeColor =
			RacialFeat3_reset.ForeColor =
			RacialFeat4_reset.ForeColor =
			RacialFeat5_reset.ForeColor = color;
		}
		#endregion HenchControl (override)


		#region Methods (static)
		/// <summary>
		/// Gets a bitwise <c>int</c> containing flags for fields that have
		/// changed.
		/// </summary>
		/// <param name="race">a <c>Race</c> <c>struct</c></param>
		/// <param name="racechanged">a <c>RaceChanged</c> <c>struct</c></param>
		/// <returns>bitwise <c>int</c> containing flags for fields that have
		/// changed</returns>
		internal static int RaceDiffer(Race race, RaceChanged racechanged)
		{
			int differ = control_Racial.bit_clean;

			if (race.flags != racechanged.flags)
				differ |= control_Racial.bit_flags;

			if (race.feat1 != racechanged.feat1)
				differ |= control_Racial.bit_feat1;

			if (race.feat2 != racechanged.feat2)
				differ |= control_Racial.bit_feat2;

			if (race.feat3 != racechanged.feat3)
				differ |= control_Racial.bit_feat3;

			if (race.feat4 != racechanged.feat4)
				differ |= control_Racial.bit_feat4;

			if (race.feat5 != racechanged.feat5)
				differ |= control_Racial.bit_feat5;

			return differ;
		}
		#endregion Methods (static)
	}
}
