using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the Racial pages.
	/// </summary>
	partial class tabcontrol_Racial
	{
		const int HENCH_FEAT_SPELL_SHIFT_SPELL = 16;

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
//					if (InfoVersionChange_racial(ref val)) // TonyAI 2.3+ allow racial InfoVersion to be 0.
//					{
//						RacialFlags_text.Text = val.ToString();
//						return; // refire this funct.
//					}

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

				if (!he.BypassDiffer)
				{
					Race race = he.Races[he.Id];

					RaceChanged racechanged;

					if (race.differ != bit_clear)
					{
						racechanged = he.RacesChanged[he.Id];
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
					he.Races[he.Id] = race;

					Color color;
					if (differ != bit_clear)
					{
						he.RacesChanged[he.Id] = racechanged;
						color = Color.Crimson;
					}
					else
					{
						he.RacesChanged.Remove(he.Id);

						if (race.isChanged) color = Color.Blue;
						else                color = DefaultForeColor;
					}
					_he.SetNodeColor(color);
				}

				he.PrintCurrent(val, tb_hex, tb_bin);

				differ = he.Races[he.Id].differ;

				if ((differ & bit) != 0)
				{
					btn.ForeColor = Color.Crimson;
				}
				else
					btn.ForeColor = DefaultForeColor;

				if (isFlags)
				{
					CheckRacialFlagsCheckers(val);
//					PrintInfoVersion_race(val);
				}
				else
					CheckRacialFeatsCheckers(tb);


				_he.SetEnabled(differ != bit_clear);
			}
			// else TODO: error dialog here.
		}

//		/// <summary>
//		/// Updates InfoVersion for the current race.
//		/// </summary>
//		/// <param name="val"></param>
//		/// <returns></returns>
//		bool InfoVersionChange_racial(ref int val)
//		{
//			// ensure that racial-flags has a CoreAI version
//			// NOTE that RacialFlags always has a Version (unlike spellinfo)
//			if ((val & hc.HENCH_SPELL_INFO_VERSION_MASK) == 0)
//			{
//				val |= hc.HENCH_SPELL_INFO_VERSION; // insert the default version #
//
//				Race race = he.Races[he.Id];
//
//				RaceChanged racechanged;
//
//				if (race.differ != bit_clear)
//				{
//					racechanged = he.RacesChanged[he.Id];
//				}
//				else
//				{
//					racechanged = new RaceChanged();
//
//					racechanged.feat1 = race.feat1;
//					racechanged.feat2 = race.feat2;
//					racechanged.feat3 = race.feat3;
//					racechanged.feat4 = race.feat4;
//					racechanged.feat5 = race.feat5;
//				}
//
//				racechanged.flags = val;
//
//				// check it
//				int differ = RaceDiffer(race, racechanged);
//				race.differ = differ;
//				he.Races[he.Id] = race;
//
//				Color color;
//				if (differ != bit_clear)
//				{
//					he.RacesChanged[he.Id] = racechanged;
//					color = Color.Crimson;
//				}
//				else
//				{
//					he.RacesChanged.Remove(he.Id);
//
//					if (race.isChanged) color = Color.Blue;
//					else                color = DefaultForeColor;
//				}
//				_he.SetNodeColor(color);
//
//				return true;
//			}
//			return false;
//		}

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
			if (he.RacesChanged.ContainsKey(he.Id))
			{
				int bit, info;
				TextBox tb;

				Race race = he.Races[he.Id];

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
				he.Races[he.Id] = race;

				if (race.differ == bit_clear)
				{
					he.RacesChanged.Remove(he.Id);

					Color color;
					if (race.isChanged) color = Color.Blue;
					else                color = DefaultForeColor;

					_he.SetNodeColor(color);
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
					flags |= hc.HENCH_RACIAL_FEAT_SPELLS;
				}
				else
					flags &= ~hc.HENCH_RACIAL_FEAT_SPELLS;

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
					feat |= hc.HENCH_FEAT_SPELL_CHEAT_CAST;
				}
				else
					feat &= ~hc.HENCH_FEAT_SPELL_CHEAT_CAST;

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
			var tb = sender as TextBox;

			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				if (feat < 0)
				{
					tb.Text = "0"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else if (feat > 65535) // 16 bits
				{
					tb.Text = "65535"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else
				{
					TextBox tb_feat;
					if (tb == rf1_FeatId)
					{
						tb_feat = RacialFeat1_text;
					}
					else if (tb == rf2_FeatId)
					{
						tb_feat = RacialFeat2_text;
					}
					else if (tb == rf3_FeatId)
					{
						tb_feat = RacialFeat3_text;
					}
					else if (tb == rf4_FeatId)
					{
						tb_feat = RacialFeat4_text;
					}
					else //if (tb_feat == rf5_FeatId)
					{
						tb_feat = RacialFeat5_text;
					}

					int feaT = Int32.Parse(tb_feat.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_FEAT;

					tb_feat.Text = (feaT | feat).ToString();
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
			var tb = sender as TextBox;

			int spell;
			if (Int32.TryParse(tb.Text, out spell))
			{
				if (spell < 0)
				{
					tb.Text = "0"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else if (spell > 16383) // 14 bits
				{
					tb.Text = "16383"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else
				{
					TextBox tb_feat;
					if (tb == rf1_SpellId)
					{
						tb_feat = RacialFeat1_text;
					}
					else if (tb == rf2_SpellId)
					{
						tb_feat = RacialFeat2_text;
					}
					else if (tb == rf3_SpellId)
					{
						tb_feat = RacialFeat3_text;
					}
					else if (tb == rf4_SpellId)
					{
						tb_feat = RacialFeat4_text;
					}
					else //if (tb_spell == rf5_SpellId)
					{
						tb_feat = RacialFeat5_text;
					}

					int feaT = Int32.Parse(tb_feat.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb_feat.Text = (feaT | spell).ToString();
				}
			}
		}

		internal void SetSpellLabelTexts(Race race)
		{
			int id;
			id = (race.feat1 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				rf1_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf1_SpellLabel.Text = String.Empty;

			id = (race.feat2 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				rf2_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf2_SpellLabel.Text = String.Empty;

			id = (race.feat3 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				rf3_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf3_SpellLabel.Text = String.Empty;

			id = (race.feat4 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				rf4_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf4_SpellLabel.Text = String.Empty;

			id = (race.feat5 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				rf5_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf5_SpellLabel.Text = String.Empty;
		}

		internal override void ClearSpellLabelTexts()
		{
			rf1_SpellLabel.Text =
			rf2_SpellLabel.Text =
			rf3_SpellLabel.Text =
			rf4_SpellLabel.Text =
			rf5_SpellLabel.Text = String.Empty;
		}


//		/// <summary>
//		/// Prints the info-version of the currently selected race ID.
//		/// <param name="flags"></param>
//		/// </summary>
//		void PrintInfoVersion_race(int flags)
//		{
//			flags &= hc.HENCH_SPELL_INFO_VERSION_MASK;
//			flags >>= he.HENCH_SPELL_INFO_VERSION_SHIFT;
//
//			rf_infoversion.Text = flags.ToString();
//		}


		/// <summary>
		/// Sets the checkers on the RacialFlags page to reflect the current
		/// flags value.
		/// <param name="flags"></param>
		/// </summary>
		void CheckRacialFlagsCheckers(int flags)
		{
			rf_HasFeatSpells.Checked = (flags & hc.HENCH_RACIAL_FEAT_SPELLS) != 0;
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

				cb.Checked = (feat & hc.HENCH_FEAT_SPELL_CHEAT_CAST) != 0;

				int val = (feat & hc.HENCH_FEAT_SPELL_MASK_FEAT);
				tb_feat.Text = val.ToString();

				if (he.featsLabels.Count != 0
					&& val < he.featsLabels.Count)
				{
					lbl_feat.Text = he.featsLabels[val];
				}

				val = (feat & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
				tb_spell.Text = val.ToString();

				if (he.spellLabels.Count != 0
					&& val < he.spellLabels.Count)
				{
					lbl_spell.Text = he.spellLabels[val];
				}
			}
		}
	}
}
