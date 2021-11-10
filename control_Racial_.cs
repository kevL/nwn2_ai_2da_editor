using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Functions for the Racial pages.
	partial class control_Racial
	{
		#region Fields (static)
		const int HENCH_FEAT_SPELL_SHIFT_SPELL = 16;
		#endregion Fields (static)


		#region eventhandlers
		/// <summary>
		/// Handles <c>TextChanged</c> event on the Racial pages.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="RacialFlags_text"/></c></item>
		/// <item><c><see cref="RacialFeat1_text"/></c></item>
		/// <item><c><see cref="RacialFeat2_text"/></c></item>
		/// <item><c><see cref="RacialFeat3_text"/></c></item>
		/// <item><c><see cref="RacialFeat4_text"/></c></item>
		/// <item><c><see cref="RacialFeat5_text"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void TextChanged_racial(object sender, EventArgs e)
		{
			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields.
			//
			// 'BypassDiffer' is set true since this does not need to go through
			// creating and deleting each SpellChanged-struct (since nothing has
			// changed yet OnLoad of the 2da-file).
			//
			// 'BypassDiffer' is also set true by AfterSelect_node() since the
			// Spell-structs already contain proper diff-data.

			int val;
			if (Int32.TryParse((sender as TextBox).Text, out val))
			{
				Button bu;
				TextBox tb_hex, tb_bin;
				int bit;

				bool isFlags = (sender == RacialFlags_text);

				if (isFlags)
				{
//					if (InfoVersionChange_racial(ref val)) // TonyAI 2.3+ allow racial InfoVersion to be 0.
//					{
//						RacialFlags_text.Text = val.ToString();
//						return; // refire this funct.
//					}

					bu     = RacialFlags_reset;
					tb_hex = RacialFlags_hex;
					tb_bin = RacialFlags_bin;
					bit    = bit_flags;
				}
				else if (sender == RacialFeat1_text)
				{
					bu     = RacialFeat1_reset;
					tb_hex = RacialFeat1_hex;
					tb_bin = RacialFeat1_bin;
					bit    = bit_feat1;
				}
				else if (sender == RacialFeat2_text)
				{
					bu     = RacialFeat2_reset;
					tb_hex = RacialFeat2_hex;
					tb_bin = RacialFeat2_bin;
					bit    = bit_feat2;
				}
				else if (sender == RacialFeat3_text)
				{
					bu     = RacialFeat3_reset;
					tb_hex = RacialFeat3_hex;
					tb_bin = RacialFeat3_bin;
					bit    = bit_feat3;
				}
				else if (sender == RacialFeat4_text)
				{
					bu     = RacialFeat4_reset;
					tb_hex = RacialFeat4_hex;
					tb_bin = RacialFeat4_bin;
					bit    = bit_feat4;
				}
				else // sender == RacialFeat5_text
				{
					bu     = RacialFeat5_reset;
					tb_hex = RacialFeat5_hex;
					tb_bin = RacialFeat5_bin;
					bit    = bit_feat5;
				}

				int differ;

				if (!he.BypassDiffer)
				{
					Race race = he.Races[he.Id];

					RaceChanged racechanged;

					if (race.differ != bit_clean)
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
					else if (sender == RacialFeat1_text)
					{
						racechanged.feat1 = val;
					}
					else if (sender == RacialFeat2_text)
					{
						racechanged.feat2 = val;
					}
					else if (sender == RacialFeat3_text)
					{
						racechanged.feat3 = val;
					}
					else if (sender == RacialFeat4_text)
					{
						racechanged.feat4 = val;
					}
					else // sender == RacialFeat5_text
					{
						racechanged.feat5 = val;
					}

					// check it
					differ = RaceDiffer(race, racechanged);
					race.differ = differ;
					he.Races[he.Id] = race;

					Color color;
					if (differ != bit_clean)
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
					bu.ForeColor = Color.Crimson;
				}
				else
					bu.ForeColor = DefaultForeColor;

				if (isFlags)
				{
					state_RacialFlags(val);
//					PrintInfoVersion_race(val);
				}
				else
					state_RacialFeats(sender as Control);

				_he.EnableApplys(differ != bit_clean);
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
//				if (race.differ != bit_clean)
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
//				if (differ != bit_clean)
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
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="RacialFlags_reset"/></c></item>
		/// <item><c><see cref="RacialFeat1_reset"/></c></item>
		/// <item><c><see cref="RacialFeat2_reset"/></c></item>
		/// <item><c><see cref="RacialFeat3_reset"/></c></item>
		/// <item><c><see cref="RacialFeat4_reset"/></c></item>
		/// <item><c><see cref="RacialFeat5_reset"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		/// <remarks>If the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.</remarks>
		void Click_racial_reset(object sender, EventArgs e)
		{
			if (he.RacesChanged.ContainsKey(he.Id))
			{
				int bit, info;
				TextBox tb;

				Race race = he.Races[he.Id];

				if (sender == RacialFlags_reset)
				{
					bit  = bit_flags;
					info = race.flags;
					tb   = RacialFlags_text;
				}
				else if (sender == RacialFeat1_reset)
				{
					bit  = bit_feat1;
					info = race.feat1;
					tb   = RacialFeat1_text;
				}
				else if (sender == RacialFeat2_reset)
				{
					bit  = bit_feat2;
					info = race.feat2;
					tb   = RacialFeat2_text;
				}
				else if (sender == RacialFeat3_reset)
				{
					bit  = bit_feat3;
					info = race.feat3;
					tb   = RacialFeat3_text;
				}
				else if (sender == RacialFeat4_reset)
				{
					bit  = bit_feat4;
					info = race.feat4;
					tb   = RacialFeat4_text;
				}
				else // sender == RacialFeat5_reset
				{
					bit  = bit_feat5;
					info = race.feat5;
					tb   = RacialFeat5_text;
				}

				race.differ &= ~bit;
				he.Races[he.Id] = race;

				if (race.differ == bit_clean)
				{
					he.RacesChanged.Remove(he.Id);

					Color color;
					if (race.isChanged) color = Color.Blue;
					else                color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				(sender as Button).ForeColor = DefaultForeColor;

				tb.Text = info.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the RacialFlags page.
		/// </summary>
		/// <param name="sender"><c><see cref="rf_HasFeatSpells"/></c></param>
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
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="rf1_cheatCast"/></c></item>
		/// <item><c><see cref="rf2_cheatCast"/></c></item>
		/// <item><c><see cref="rf3_cheatCast"/></c></item>
		/// <item><c><see cref="rf4_cheatCast"/></c></item>
		/// <item><c><see cref="rf5_cheatCast"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_rFeats(object sender, MouseEventArgs e)
		{
			TextBox tb;
			if (sender == rf1_cheatCast)
			{
				tb = RacialFeat1_text;
			}
			else if (sender == rf2_cheatCast)
			{
				tb = RacialFeat2_text;
			}
			else if (sender == rf3_cheatCast)
			{
				tb = RacialFeat3_text;
			}
			else if (sender == rf4_cheatCast)
			{
				tb = RacialFeat4_text;
			}
			else // sender == rf5_cheatCast
			{
				tb = RacialFeat5_text;
			}

			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				if ((sender as CheckBox).Checked)
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
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="rf1_FeatId"/></c></item>
		/// <item><c><see cref="rf2_FeatId"/></c></item>
		/// <item><c><see cref="rf3_FeatId"/></c></item>
		/// <item><c><see cref="rf4_FeatId"/></c></item>
		/// <item><c><see cref="rf5_FeatId"/></c></item>
		/// </list></param>
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
					if      (sender == rf1_FeatId) tb = RacialFeat1_text;
					else if (sender == rf2_FeatId) tb = RacialFeat2_text;
					else if (sender == rf3_FeatId) tb = RacialFeat3_text;
					else if (sender == rf4_FeatId) tb = RacialFeat4_text;
					else                           tb = RacialFeat5_text; // sender == rf5_FeatId

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_FEAT;

					tb.Text = (feaT | feat).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing RacialFeat spells in their textboxes.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="rf1_SpellId"/></c></item>
		/// <item><c><see cref="rf2_SpellId"/></c></item>
		/// <item><c><see cref="rf3_SpellId"/></c></item>
		/// <item><c><see cref="rf4_SpellId"/></c></item>
		/// <item><c><see cref="rf5_SpellId"/></c></item>
		/// </list></param>
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
					if      (sender == rf1_SpellId) tb = RacialFeat1_text;
					else if (sender == rf2_SpellId) tb = RacialFeat2_text;
					else if (sender == rf3_SpellId) tb = RacialFeat3_text;
					else if (sender == rf4_SpellId) tb = RacialFeat4_text;
					else                            tb = RacialFeat5_text; // sender == rf5_SpellId

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb.Text = (feaT | spell).ToString();
				}
			}
		}
		#endregion eventhandlers


		#region HenchControl (override)
		/// <summary>
		/// Sets spell-labels in various <c>Labels</c>.
		/// </summary>
		internal override void SetSpellLabelTexts()
		{
			int id;

			// NOTE: Texts shall not be negative.
			// TODO: Texts shall parse to ints.

			if (Int32.TryParse(rf1_SpellId.Text, out id)
				&& id < he.spellLabels.Count)
			{
				rf1_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf1_SpellLabel.Text = String.Empty;

			if (Int32.TryParse(rf2_SpellId.Text, out id)
				&& id < he.spellLabels.Count)
			{
				rf2_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf2_SpellLabel.Text = String.Empty;

			if (Int32.TryParse(rf3_SpellId.Text, out id)
				&& id < he.spellLabels.Count)
			{
				rf3_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf3_SpellLabel.Text = String.Empty;

			if (Int32.TryParse(rf4_SpellId.Text, out id)
				&& id < he.spellLabels.Count)
			{
				rf4_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf4_SpellLabel.Text = String.Empty;

			if (Int32.TryParse(rf5_SpellId.Text, out id)
				&& id < he.spellLabels.Count)
			{
				rf5_SpellLabel.Text = he.spellLabels[id];
			}
			else
				rf5_SpellLabel.Text = String.Empty;
		}

		/// <summary>
		/// Clears spell-labels.
		/// </summary>
		internal override void ClearSpellLabelTexts()
		{
			rf1_SpellLabel.Text =
			rf2_SpellLabel.Text =
			rf3_SpellLabel.Text =
			rf4_SpellLabel.Text =
			rf5_SpellLabel.Text = String.Empty;
		}

		/// <summary>
		/// Sets feat-labels in various <c>Labels</c>.
		/// </summary>
		internal override void SetFeatLabelTexts()
		{
			int id;

			// NOTE: Texts shall not be negative.
			// TODO: Texts shall parse to ints.

			if (Int32.TryParse(rf1_FeatId.Text, out id)
				&& id < he.featLabels.Count)
			{
				rf1_FeatLabel.Text = he.featLabels[id];
			}
			else
				rf1_FeatLabel.Text = String.Empty;

			if (Int32.TryParse(rf2_FeatId.Text, out id)
				&& id < he.featLabels.Count)
			{
				rf2_FeatLabel.Text = he.featLabels[id];
			}
			else
				rf2_FeatLabel.Text = String.Empty;

			if (Int32.TryParse(rf3_FeatId.Text, out id)
				&& id < he.featLabels.Count)
			{
				rf3_FeatLabel.Text = he.featLabels[id];
			}
			else
				rf3_FeatLabel.Text = String.Empty;

			if (Int32.TryParse(rf4_FeatId.Text, out id)
				&& id < he.featLabels.Count)
			{
				rf4_FeatLabel.Text = he.featLabels[id];
			}
			else
				rf4_FeatLabel.Text = String.Empty;

			if (Int32.TryParse(rf5_FeatId.Text, out id)
				&& id < he.featLabels.Count)
			{
				rf5_FeatLabel.Text = he.featLabels[id];
			}
			else
				rf5_FeatLabel.Text = String.Empty;
		}

		/// <summary>
		/// Clears feat-labels.
		/// </summary>
		internal override void ClearFeatLabelTexts()
		{
			rf1_FeatLabel.Text =
			rf2_FeatLabel.Text =
			rf3_FeatLabel.Text =
			rf4_FeatLabel.Text =
			rf5_FeatLabel.Text = String.Empty;
		}
		#endregion HenchControl (override)


//		/// <summary>
//		/// Prints the info-version of the currently selected race ID.
//		/// </summary>
//		/// <param name="flags"></param>
//		void PrintInfoVersion_race(int flags)
//		{
//			flags &= hc.HENCH_SPELL_INFO_VERSION_MASK;
//			flags >>= he.HENCH_SPELL_INFO_VERSION_SHIFT;
//
//			rf_infoversion.Text = flags.ToString();
//		}


		#region setstate
		/// <summary>
		/// Sets the checkers on the RacialFlags page to reflect the current
		/// flags value.
		/// </summary>
		/// <param name="flags"></param>
		void state_RacialFlags(int flags)
		{
			rf_HasFeatSpells.Checked = (flags & hc.HENCH_RACIAL_FEAT_SPELLS) != 0;
		}

		/// <summary>
		/// Sets the checkers on the RacialFeats pages to reflect the current
		/// feat value.
		/// </summary>
		/// <param name="tb"></param>
		void state_RacialFeats(Control tb)
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
				else // tb == RacialFeat5_text
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

				if (he.featLabels.Count != 0
					&& val < he.featLabels.Count)
				{
					lbl_feat.Text = he.featLabels[val];
				}

				val = (feat & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
				tb_spell.Text = val.ToString();

				if (he.spellLabels.Count != 0 && val < he.spellLabels.Count)
				{
					lbl_spell.Text = he.spellLabels[val];
				}
			}
		}
		#endregion setstate
	}
}
