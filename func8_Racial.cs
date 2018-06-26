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

//				CheckRacialCheckers(val);
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
	}
}
