﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the Racial pages.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the Racial pages.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_racial(object sender, EventArgs e)
		{
			var tb = sender as TextBox;

			// NOTE: TextChanged needs to fire when HenchRacial loads in order
			// to set the checkers. Technically however this does not need to go
			// through creating and deleting each Racial-struct (since nothing
			// has changed yet OnLoad of the 2da-file)

			int val;
			if (Int32.TryParse(tb.Text, out val))
			{
				Button btn;
				TextBox tb_hex, tb_bin;
				int bit;

				if (tb == RacialFlags_text)
				{
					btn = RacialFlags_reset;
					tb_hex = RacialFlags_hex;
					tb_bin = RacialFlags_bin;
					bit = bit_flags;
				}
				else if (tb == RacialFeat1_text)
				{
					btn = RacialFeat1_reset;
					tb_hex = RacialFeat1_hex;
					tb_bin = RacialFeat1_bin;
					bit = bit_feat1;
				}
				else if (tb == RacialFeat2_text)
				{
					btn = RacialFeat2_reset;
					tb_hex = RacialFeat2_hex;
					tb_bin = RacialFeat2_bin;
					bit = bit_feat2;
				}
				else if (tb == RacialFeat3_text)
				{
					btn = RacialFeat3_reset;
					tb_hex = RacialFeat3_hex;
					tb_bin = RacialFeat3_bin;
					bit = bit_feat3;
				}
				else if (tb == RacialFeat4_text)
				{
					btn = RacialFeat4_reset;
					tb_hex = RacialFeat4_hex;
					tb_bin = RacialFeat4_bin;
					bit = bit_feat4;
				}
				else //if (tb == RacialFeat5_text)
				{
					btn = RacialFeat5_reset;
					tb_hex = RacialFeat5_hex;
					tb_bin = RacialFeat5_bin;
					bit = bit_feat5;
				}

				if (!bypassTextChanged)
				{
/*
					// ensure that spellinfo has a CoreAI version
					// although strictly speaking I believe that GetSpellInfo()
					// will gracefully handle spell-data that has no version set.
					if (val != 0)
					{
						if ((val & HENCH_SPELL_INFO_VERSION_MASK) == 0) // insert the default spell-version if it doesn't exist
						{
							val |= HENCH_SPELL_INFO_VERSION; // def'n 'hench_i0_generic'
							tb.Text = val.ToString();
							return; // re-fire this funct.
						}

						if (val == (val & HENCH_SPELL_INFO_VERSION_MASK)) // clear the spell-version if that's the only data in spellinfo
						{
							// TODO: I suppose the spell-version should be stored (if not the default version #) ...
							// so it can be re-inserted identically (if/after user clears all spellinfo bits).
							val = 0;
							tb.Text = val.ToString();
							return; // re-fire this funct.
						}
					}
					// TODO: Those need to update the fields when loading the 2da
					// ... especially the Text-field/reset-color. And the spell-tree's node-color
*/

					Race race = Races[Id];

					RaceChanged racechanged;

					if (RacesChanged.ContainsKey(Id))
					{
						racechanged = RacesChanged[Id];
					}
					else
					{
						racechanged = new RaceChanged();

						racechanged.flags = race.flags;
						racechanged.feat1 = race.feat1;
						racechanged.feat2 = race.feat2;
						racechanged.feat3 = race.feat3;
						racechanged.feat4 = race.feat4;
						racechanged.feat5 = race.feat5;
					}

					if (tb == RacialFlags_text)
					{
						racechanged.flags = val;
					}
					else if (tb == RacialFeat1_text)
					{
						racechanged.feat1 = val;
					}
					else if (tb == RacialFeat2_text)
					{
						racechanged.feat2 = val;
					}
					else if (tb == RacialFeat3_text)
					{
						racechanged.feat3 = val;
					}
					else if (tb == RacialFeat4_text)
					{
						racechanged.feat4 = val;
					}
					else if (tb == RacialFeat5_text)
					{
						racechanged.feat5 = val;
					}

					// check it
					int differ = RaceDiffer(race, racechanged);
					race.differ = differ;
					Races[Id] = race;

					if (differ != bit_clear)
					{
						RacesChanged[Id] = racechanged;
						Tree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						RacesChanged.Remove(Id);

						if (!race.isChanged) // this is set by the Apply btn only.
						{
							Tree.SelectedNode.ForeColor = DefaultForeColor;
						}
					}

					PrintCurrent(val, null, tb_hex, tb_bin);
				}

				if ((Races[Id].differ & bit) != 0)
				{
					btn.ForeColor = Color.Crimson;
				}
				else
					btn.ForeColor = DefaultForeColor;

				if (tb == RacialFlags_text)
				{
					CheckRacialFlagsCheckers();
				}
				else
					CheckRacialFeatsCheckers(tb);


				PrintInfoVersion();
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current race's info.
		/// Note that if the Apply-btn has been clicked for the race then that
		/// data will be used instead of the data from the originally loaded
		/// HenchRacial.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_racial_reset(object sender, EventArgs e)
		{
			if (RacesChanged.ContainsKey(Id))
			{
				TextBox tb;
				int info, bit;

				Race race = Races[Id];

				var btn = sender as Button;
				if (btn == RacialFlags_reset)
				{
					tb = RacialFlags_text;
					info = race.flags;
					bit = bit_flags;
				}
				else if (btn == RacialFeat1_reset)
				{
					tb = RacialFeat1_text;
					info = race.feat1;
					bit = bit_feat1;
				}
				else if (btn == RacialFeat2_reset)
				{
					tb = RacialFeat2_text;
					info = race.feat2;
					bit = bit_feat2;
				}
				else if (btn == RacialFeat3_reset)
				{
					tb = RacialFeat3_text;
					info = race.feat3;
					bit = bit_feat3;
				}
				else if (btn == RacialFeat4_reset)
				{
					tb = RacialFeat4_text;
					info = race.feat4;
					bit = bit_feat4;
				}
				else //if (btn == RacialFeat5_reset)
				{
					tb = RacialFeat5_text;
					info = race.feat5;
					bit = bit_feat5;
				}

				race.differ &= ~bit;
				Races[Id] = race;

				if (race.differ == bit_clear)
				{
					RacesChanged.Remove(Id);

					if (race.isChanged) // this is set by the Apply btn only.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else
						Tree.SelectedNode.ForeColor = DefaultForeColor;
				}

				btn.ForeColor = DefaultForeColor;

				tb.Text = info.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the RacialFlags page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_rFlags(object sender, MouseEventArgs e)
		{
			int flags;
			if (Int32.TryParse(RacialFlags_text.Text, out flags))
			{
				if (rf_HasFeatSpells.Checked)
				{
					flags |= HENCH_RACIAL_FEAT_SPELLS;
				}
				else
					flags &= ~HENCH_RACIAL_FEAT_SPELLS;

				bypassCheckedChecker = true;
				RacialFlags_text.Text = flags.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the RacialFeats pages.
		/// </summary>
		void MouseClick_rFeats(object sender, MouseEventArgs e)
		{
			TextBox tb;

			var cb = sender as CheckBox;
			if (cb == rf1_cheatCast)
			{
				tb = RacialFeat1_text;
			}
			else if (cb == rf2_cheatCast)
			{
				tb = RacialFeat2_text;
			}
			else if (cb == rf3_cheatCast)
			{
				tb = RacialFeat3_text;
			}
			else if (cb == rf4_cheatCast)
			{
				tb = RacialFeat4_text;
			}
			else //if (cb == rf5_cheatCast)
			{
				tb = RacialFeat5_text;
			}

			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				if (cb.Checked)
				{
					feat |= HENCH_FEAT_SPELL_CHEAT_CAST;
				}
				else
					feat &= ~HENCH_FEAT_SPELL_CHEAT_CAST;

				bypassCheckedChecker = true;
				tb.Text = feat.ToString();
			}
		}

		/// <summary>
		/// Handles changing RacialFeat feats in their textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_rFeat(object sender, EventArgs e)
		{
			var tb_feat = sender as TextBox;

			int feat;
			if (Int32.TryParse(tb_feat.Text, out feat))
			{
				if (feat < 0)
				{
					feat = 0;
					tb_feat.Text = feat.ToString(); // re-trigger this funct.
				}
				else if (feat > 65535) // 16 bits
				{
					feat = 65535;
					tb_feat.Text = feat.ToString(); // re-trigger this funct.
				}
				else
				{
					TextBox tb;
					if (tb_feat == rf1_FeatId)
					{
						tb = RacialFeat1_text;
					}
					else if (tb_feat == rf2_FeatId)
					{
						tb = RacialFeat2_text;
					}
					else if (tb_feat == rf3_FeatId)
					{
						tb = RacialFeat3_text;
					}
					else if (tb_feat == rf4_FeatId)
					{
						tb = RacialFeat4_text;
					}
					else //if (tb_feat == rf5_FeatId)
					{
						tb = RacialFeat5_text;
					}

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~HENCH_FEAT_SPELL_MASK_FEAT;

					tb.Text = (feaT | feat).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing RacialFeat spells in their textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_rSpell(object sender, EventArgs e)
		{
			var tb_spell = sender as TextBox;

			int spell;
			if (Int32.TryParse(tb_spell.Text, out spell))
			{
				if (spell < 0)
				{
					spell = 0;
					tb_spell.Text = spell.ToString(); // re-trigger this funct.
				}
				else if (spell > 16383) // 14 bits
				{
					spell = 16383;
					tb_spell.Text = spell.ToString(); // re-trigger this funct.
				}
				else
				{
					TextBox tb;
					if (tb_spell == rf1_SpellId)
					{
						tb = RacialFeat1_text;
					}
					else if (tb_spell == rf2_SpellId)
					{
						tb = RacialFeat2_text;
					}
					else if (tb_spell == rf3_SpellId)
					{
						tb = RacialFeat3_text;
					}
					else if (tb_spell == rf4_SpellId)
					{
						tb = RacialFeat4_text;
					}
					else //if (tb_feat == rf5_SpellId)
					{
						tb = RacialFeat5_text;
					}

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= 16;
					tb.Text = (feaT | spell).ToString();
				}
			}
		}


		/// <summary>
		/// Prints the info-version of the currently selected race ID.
		/// </summary>
		void PrintInfoVersion()
		{
			int ver;
			if (RacesChanged.ContainsKey(Id))
			{
				ver = RacesChanged[Id].flags;
			}
			else
				ver = Races[Id].flags;

			ver &= HENCH_SPELL_INFO_VERSION_MASK;
			ver >>= 24;

			rf_infoversion.Text = ver.ToString();
		}


		/// <summary>
		/// Sets the checkers on the RacialFlags page to reflect the current
		/// flags value.
		/// </summary>
		void CheckRacialFlagsCheckers()
		{
			if (!bypassCheckedChecker)
			{
				int info;
				if (RacesChanged.ContainsKey(Id))
				{
					info = RacesChanged[Id].flags;
				}
				else
					info = Races[Id].flags;

				rf_HasFeatSpells.Checked = (info & HENCH_RACIAL_FEAT_SPELLS) != 0;
			}
			else
				bypassCheckedChecker = false;
		}

		/// <summary>
		/// Sets the checkers on the RacialFeats pages to reflect the current
		/// feat value.
		/// </summary>
		/// <param name="tb"></param>
		void CheckRacialFeatsCheckers(Control tb)
		{
			if (!bypassCheckedChecker)
			{
				CheckBox cb;
				TextBox tb_feat, tb_spell;

				int feat;
				if (Int32.TryParse(tb.Text, out feat))
				{
					if (tb == RacialFeat1_text)
					{
						cb = rf1_cheatCast;
						tb_feat = rf1_FeatId;
						tb_spell = rf1_SpellId;
					}
					else if (tb == RacialFeat2_text)
					{
						cb = rf2_cheatCast;
						tb_feat = rf2_FeatId;
						tb_spell = rf2_SpellId;
					}
					else if (tb == RacialFeat3_text)
					{
						cb = rf3_cheatCast;
						tb_feat = rf3_FeatId;
						tb_spell = rf3_SpellId;
					}
					else if (tb == RacialFeat4_text)
					{
						cb = rf4_cheatCast;
						tb_feat = rf4_FeatId;
						tb_spell = rf4_SpellId;
					}
					else //if (tb == RacialFeat5_text)
					{
						cb = rf5_cheatCast;
						tb_feat = rf5_FeatId;
						tb_spell = rf5_SpellId;
					}

					cb.Checked = (feat & HENCH_FEAT_SPELL_CHEAT_CAST) != 0;

					int val = (feat & HENCH_FEAT_SPELL_MASK_FEAT);
					tb_feat.Text = val.ToString();

					val = (feat & HENCH_FEAT_SPELL_MASK_SPELL) >> 16;
					tb_spell.Text = val.ToString();
				}
			}
			else
				bypassCheckedChecker = false;
		}
	}
}