using System;
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

				bool isFlags = (tb == RacialFlags_text);

				if (isFlags)
				{
					if (InfoVersionChange_racial(ref val))
					{
						RacialFlags_text.Text = val.ToString();
						return; // refire this funct.
					}

					btn    = RacialFlags_reset;
					tb_hex = RacialFlags_hex;
					tb_bin = RacialFlags_bin;
					bit    = bit_flags;
				}
				else if (tb == RacialFeat1_text)
				{
					btn    = RacialFeat1_reset;
					tb_hex = RacialFeat1_hex;
					tb_bin = RacialFeat1_bin;
					bit    = bit_feat1;
				}
				else if (tb == RacialFeat2_text)
				{
					btn    = RacialFeat2_reset;
					tb_hex = RacialFeat2_hex;
					tb_bin = RacialFeat2_bin;
					bit    = bit_feat2;
				}
				else if (tb == RacialFeat3_text)
				{
					btn    = RacialFeat3_reset;
					tb_hex = RacialFeat3_hex;
					tb_bin = RacialFeat3_bin;
					bit    = bit_feat3;
				}
				else if (tb == RacialFeat4_text)
				{
					btn    = RacialFeat4_reset;
					tb_hex = RacialFeat4_hex;
					tb_bin = RacialFeat4_bin;
					bit    = bit_feat4;
				}
				else //if (tb == RacialFeat5_text)
				{
					btn    = RacialFeat5_reset;
					tb_hex = RacialFeat5_hex;
					tb_bin = RacialFeat5_bin;
					bit    = bit_feat5;
				}

				int differ;

				if (!bypassDiffer)
				{
					Race race = Races[Id];

					RaceChanged racechanged;

					if (race.differ != bit_clear)
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

					if (isFlags)
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
					differ = RaceDiffer(race, racechanged);
					race.differ = differ;
					Races[Id] = race;

					Color color;
					if (differ != bit_clear)
					{
						RacesChanged[Id] = racechanged;
						color = Color.Crimson;
					}
					else
					{
						RacesChanged.Remove(Id);

						if (race.isChanged) // this is set by the Apply btn only.
						{
							color = Color.Blue;
						}
						else
							color = DefaultForeColor;
					}
					Tree.SelectedNode.ForeColor = color;
				}

				PrintCurrent(val, tb_hex, tb_bin);

				differ = Races[Id].differ;

				if ((differ & bit) != 0)
				{
					btn.ForeColor = Color.Crimson;
				}
				else
					btn.ForeColor = DefaultForeColor;

				if (isFlags)
				{
					CheckRacialFlagsCheckers(val);
					PrintInfoVersion_race(val);
				}
				else
					CheckRacialFeatsCheckers(tb);


				apply          .Enabled = (differ != bit_clear);
				applyGlobal    .Enabled = (differ != bit_clear) || (RacesChanged.Count != 0);
				gotoNextChanged.Enabled = (differ != bit_clear) || (RacesChanged.Count != 0) || SpareChange();
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Updates InfoVersion for the current race.
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		bool InfoVersionChange_racial(ref int val)
		{
			// ensure that racial-flags has a CoreAI version
			// NOTE that RacialFlags always has a Version (unlike spellinfo)
			if ((val & HENCH_SPELL_INFO_VERSION_MASK) == 0)
			{
				val |= HENCH_SPELL_INFO_VERSION; // insert the default version #

				Race race = Races[Id];

				RaceChanged racechanged;

				if (race.differ != bit_clear)
				{
					racechanged = RacesChanged[Id];
				}
				else
				{
					racechanged = new RaceChanged();

					racechanged.feat1 = race.feat1;
					racechanged.feat2 = race.feat2;
					racechanged.feat3 = race.feat3;
					racechanged.feat4 = race.feat4;
					racechanged.feat5 = race.feat5;
				}

				racechanged.flags = val;

				// check it
				int differ = RaceDiffer(race, racechanged);
				race.differ = differ;
				Races[Id] = race;

				Color color;
				if (differ != bit_clear)
				{
					RacesChanged[Id] = racechanged;
					color = Color.Crimson;
				}
				else
				{
					RacesChanged.Remove(Id);

					if (race.isChanged) // this is set by the Apply btn only.
					{
						color = Color.Blue;
					}
					else
						color = DefaultForeColor;
				}
				Tree.SelectedNode.ForeColor = color;

				return true;
			}
			return false;
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
				int bit, info;
				TextBox tb;

				Race race = Races[Id];

				var btn = sender as Button;
				if (btn == RacialFlags_reset)
				{
					bit  = bit_flags;
					info = race.flags;
					tb   = RacialFlags_text;
				}
				else if (btn == RacialFeat1_reset)
				{
					bit  = bit_feat1;
					info = race.feat1;
					tb   = RacialFeat1_text;
				}
				else if (btn == RacialFeat2_reset)
				{
					bit  = bit_feat2;
					info = race.feat2;
					tb   = RacialFeat2_text;
				}
				else if (btn == RacialFeat3_reset)
				{
					bit  = bit_feat3;
					info = race.feat3;
					tb   = RacialFeat3_text;
				}
				else if (btn == RacialFeat4_reset)
				{
					bit  = bit_feat4;
					info = race.feat4;
					tb   = RacialFeat4_text;
				}
				else //if (btn == RacialFeat5_reset)
				{
					bit  = bit_feat5;
					info = race.feat5;
					tb   = RacialFeat5_text;
				}

				race.differ &= ~bit;
				Races[Id] = race;

				if (race.differ == bit_clear)
				{
					RacesChanged.Remove(Id);

					if (race.isChanged) // this is set by the Apply btn only.
					{
						Tree.SelectedNode.ForeColor = Color.Blue;
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
					else //if (tb_spell == rf5_SpellId)
					{
						tb = RacialFeat5_text;
					}

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb.Text = (feaT | spell).ToString();
				}
			}
		}


		/// <summary>
		/// Prints the info-version of the currently selected race ID.
		/// <param name="flags"></param>
		/// </summary>
		void PrintInfoVersion_race(int flags)
		{
			flags &= HENCH_SPELL_INFO_VERSION_MASK;
			flags >>= HENCH_SPELL_INFO_VERSION_SHIFT;

			rf_infoversion.Text = flags.ToString();
		}


		/// <summary>
		/// Sets the checkers on the RacialFlags page to reflect the current
		/// flags value.
		/// <param name="flags"></param>
		/// </summary>
		void CheckRacialFlagsCheckers(int flags)
		{
			rf_HasFeatSpells.Checked = (flags & HENCH_RACIAL_FEAT_SPELLS) != 0;
		}

		/// <summary>
		/// Sets the checkers on the RacialFeats pages to reflect the current
		/// feat value.
		/// </summary>
		/// <param name="tb"></param>
		void CheckRacialFeatsCheckers(Control tb)
		{
			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				CheckBox cb;
				TextBox tb_feat, tb_spell;
				Label lbl_feat, lbl_spell;

				if (tb == RacialFeat1_text)
				{
					cb        = rf1_cheatCast;
					tb_feat   = rf1_FeatId;
					tb_spell  = rf1_SpellId;
					lbl_feat  = rf1_FeatLabel;
					lbl_spell = rf1_SpellLabel;
				}
				else if (tb == RacialFeat2_text)
				{
					cb        = rf2_cheatCast;
					tb_feat   = rf2_FeatId;
					tb_spell  = rf2_SpellId;
					lbl_feat  = rf2_FeatLabel;
					lbl_spell = rf2_SpellLabel;
				}
				else if (tb == RacialFeat3_text)
				{
					cb        = rf3_cheatCast;
					tb_feat   = rf3_FeatId;
					tb_spell  = rf3_SpellId;
					lbl_feat  = rf3_FeatLabel;
					lbl_spell = rf3_SpellLabel;
				}
				else if (tb == RacialFeat4_text)
				{
					cb        = rf4_cheatCast;
					tb_feat   = rf4_FeatId;
					tb_spell  = rf4_SpellId;
					lbl_feat  = rf4_FeatLabel;
					lbl_spell = rf4_SpellLabel;
				}
				else //if (tb == RacialFeat5_text)
				{
					cb        = rf5_cheatCast;
					tb_feat   = rf5_FeatId;
					tb_spell  = rf5_SpellId;
					lbl_feat  = rf5_FeatLabel;
					lbl_spell = rf5_SpellLabel;
				}

				cb.Checked = (feat & HENCH_FEAT_SPELL_CHEAT_CAST) != 0;

				int val = (feat & HENCH_FEAT_SPELL_MASK_FEAT);
				tb_feat.Text = val.ToString();

				if (featsLabels.Count != 0
					&& val < featsLabels.Count)
				{
					lbl_feat.Text = featsLabels[val];
				}

				val = (feat & HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
				tb_spell.Text = val.ToString();

				if (spellLabels.Count != 0
					&& val < spellLabels.Count)
				{
					lbl_spell.Text = spellLabels[val];
				}
			}
		}


		const int HENCH_FEAT_SPELL_SHIFT_SPELL = 16;
	}
}
