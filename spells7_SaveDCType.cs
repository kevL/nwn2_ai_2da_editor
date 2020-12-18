using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SaveDCType page.
	/// </summary>
	partial class tabcontrol_Spells
	{
		/// <summary>
		/// Mask for all allowable ArmorCheckType bits.
		/// </summary>
		const int HENCH_SAVEDCTYPE_ARMORCHECK_MASK = 0x10000003;

		/// <summary>
		/// Handles TextChanged event on the SaveDCType page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_dc(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_dc() bypassTextChanged= " + bypassTextChanged);

			int savedctype;
			if (Int32.TryParse(SaveDCType_text.Text, out savedctype))
			{
				int differ;

				if (!MainForm.BypassDiffer)
				{
					Spell spell = MainForm.Spells[MainForm.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = MainForm.SpellsChanged[MainForm.Id];
					}
					else
					{
						spellchanged = new SpellChanged();

						spellchanged.spellinfo    = spell.spellinfo;
						spellchanged.targetinfo   = spell.targetinfo;
						spellchanged.effectweight = spell.effectweight;
						spellchanged.effecttypes  = spell.effecttypes;
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
					}

					spellchanged.savedctype = savedctype;

					// check it
					differ = SpellDiffer(spell, spellchanged);
					spell.differ = differ;
					MainForm.Spells[MainForm.Id] = spell;

					Color color;
					if (differ != bit_clear)
					{
						MainForm.SpellsChanged[MainForm.Id] = spellchanged;
						color = Color.Crimson;
					}
					else
					{
						MainForm.SpellsChanged.Remove(MainForm.Id);

						if (spell.isChanged) color = Color.Blue;
						else                 color = DefaultForeColor;
					}
					MainForm.that.SetNodeColor(color);
				}

				MainForm.PrintCurrent(savedctype, SaveDCType_hex, SaveDCType_bin);

				differ = MainForm.Spells[MainForm.Id].differ;

				if ((differ & bit_savedctype) != 0)
				{
					SaveDCType_reset.ForeColor = Color.Crimson;
				}
				else
					SaveDCType_reset.ForeColor = DefaultForeColor;

				CheckSaveDcTypeCheckers(savedctype);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					// But it does clamp the value before it gets shot back here.
					si_Child5.Text = SaveDCType_text.Text;
				}

				// The DC must be less than 1000 for the adjustor-buttons to appear.
				// 1000+ thar be AI-constants that are set using the DC-combobox.
				savedc_up.Enabled = (savedctype <  999); // disallow incrementing up to 1000
				savedc_dn.Enabled = (savedctype < 1000); // 1000 is a CoreAI constant that shall be accessed in the dropdown

				// TODO: should probably disable if savedctype is negative.
				dc_ArmorCheckGrp.Enabled = (savedctype & ~HENCH_SAVEDCTYPE_ARMORCHECK_MASK) == 0;

				MainForm.that.SetEnabled(differ != bit_clear);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's savedctype.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_dc_reset(object sender, EventArgs e)
		{
			Spell spell = MainForm.Spells[MainForm.Id];
			if ((spell.differ & bit_savedctype) != 0)
			{
				spell.differ &= ~bit_savedctype;
				MainForm.Spells[MainForm.Id] = spell;

				if (spell.differ == bit_clear)
				{
					MainForm.SpellsChanged.Remove(MainForm.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;
					MainForm.that.SetNodeColor(color);
				}

				SaveDCType_reset.ForeColor = DefaultForeColor;

				SaveDCType_text.Text = spell.savedctype.ToString();
			}
		}


		/// <summary>
		/// Handler for SaveDCType-type combobox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_dc_savedctype(object sender, EventArgs e)
		{
			// NOTE: current val doesn't have to be tested for validity since
			// this is a direct assignment.

			int sel = cbo_dc_SaveDC.SelectedIndex;

			//logfile.Log("SelectionChangeCommitted_dc_savedctype() selectedId= " + sel);

			string text = String.Empty;
			switch (sel)
			{
				case  0: text = hc.HENCH_SAVEDC_SPELL.ToString();                  break; // -1000

				case  1: text = hc.HENCH_SAVEDC_NONE.ToString();                   break; // 0

				case  2: text = hc.HENCH_SAVEDC_HD_1.ToString();                   break; // 1000
				case  3: text = hc.HENCH_SAVEDC_HD_2.ToString();                   break; // 1001
				case  4: text = hc.HENCH_SAVEDC_HD_4.ToString();                   break; // 1002
				case  5: text = hc.HENCH_SAVEDC_HD_2_CONST.ToString();             break; // 1003
				case  6: text = hc.HENCH_SAVEDC_HD_2_CONST_MINUS_5.ToString();     break; // 1004
				case  7: text = hc.HENCH_SAVEDC_HD_2_WIS.ToString();               break; // 1005
				case  8: text = hc.HENCH_SAVEDC_HD_2_PLUS_5.ToString();            break; // 1006
				case  9: text = hc.HENCH_SAVEDC_HD_2_CHA.ToString();               break; // 1007

				case 10: text = hc.HENCH_SAVEDC_DISEASE_BOLT.ToString();           break; // 1010
				case 11: text = hc.HENCH_SAVEDC_DISEASE_CONE.ToString();           break; // 1011
				case 12: text = hc.HENCH_SAVEDC_DISEASE_PULSE.ToString();          break; // 1012
				case 13: text = hc.HENCH_SAVEDC_POISON.ToString();                 break; // 1013
				case 14: text = hc.HENCH_SAVEDC_EPIC.ToString();                   break; // 1014

				case 15: text = hc.HENCH_SAVEDC_DEATHLESS_MASTER_TOUCH.ToString(); break; // 1020
				case 16: text = hc.HENCH_SAVEDC_UNDEAD_GRAFT.ToString();           break; // 1021
				case 17: text = hc.HENCH_SAVEDC_SPELL_NO_SPELL_LEVEL.ToString();   break; // 1022

				case 18: text = hc.HENCH_SAVEDC_BARD_SLOWING.ToString();           break; // 1024
				case 19: text = hc.HENCH_SAVEDC_BARD_FASCINATE.ToString();         break; // 1025
			}

			SaveDCType_text.Text = text;
		}

		/// <summary>
		/// Handler for the +/- buttons on the SaveDCType page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_dc_adjustors(object sender, EventArgs e)
		{
			int savedctype;
			if (Int32.TryParse(SaveDCType_text.Text, out savedctype))
			{
				var btn = sender as Button;
				if (btn == savedc_up)
				{
					++savedctype;
				}
				else //if (rb == savedc_dn)
				{
					--savedctype;
				}

				// NOTE: allow the text-changed event to update checkers
				SaveDCType_text.Text = savedctype.ToString();
			}
		}

		/// <summary>
		/// Handler for the WeaponBonusType combobox.
		/// The values represent specific formula in the CoreAI for calculating
		/// casterlevel for a weapon-bonus.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_dc_weaponbonustype(object sender, EventArgs e)
		{
			// NOTE: current val doesn't have to be tested for validity since
			// this is a direct assignment.

			string text = String.Empty;
			switch (cbo_dc_WeaponBonus.SelectedIndex)
			{
				case 0: text = "0";   break;
				case 1: text = "100"; break; // no constants defined in CoreAI ->
				case 2: text = "101"; break; // See 'hench_i0_buff' HenchCheckWeaponBuff()
				case 3: text = "102"; break; // spelltype - hc.HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
			}

			SaveDCType_text.Text = text;
		}


		/// <summary>
		/// Handler for the SaveDCType - ArmorCheckType checkboxes.
		/// NOTE: Had to change this from the CheckChanged events to the
		/// MouseClick events. Else the repeated firings are a nightmare when
		/// trying to keep state straight. Fortunately any CheckChanged happens
		/// before this MouseClick event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_dc_armorchecktype(object sender, MouseEventArgs e)
		{
			int savedctype;
			if (Int32.TryParse(SaveDCType_text.Text, out savedctype))
			{
				savedctype &= HENCH_SAVEDCTYPE_ARMORCHECK_MASK; // clear the other bit-groups.

				int bit;

				var cb = sender as CheckBox;
				if (cb == savedc_ac1)
				{
					bit = hc.HENCH_AC_CHECK_ARMOR; // 0x00000001
				}
				else if (cb == savedc_ac2)
				{
					bit = hc.HENCH_AC_CHECK_SHIELD; // 0x00000002
				}
				else //if (cb == savedc_ac3)
				{
					bit = hc.HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE; // 0x10000000
				}

				if (cb.Checked)
				{
					savedctype |= bit;
				}
				else
					savedctype &= ~bit;

				SaveDCType_text.Text = savedctype.ToString();
			}
		}


		/// <summary>
		/// Sets the checkers on the SaveDCType page to reflect the current
		/// savedctype value.
		/// </summary>
		/// <param name="savedctype"></param>
		void CheckSaveDcTypeCheckers(int savedctype)
		{
// ArmorCheck checkboxes
			bool b = (savedctype > -1); // a negative value wreaks havoc on the speed-decrease bit ...

			savedc_ac1.Checked = b && (savedctype & hc.HENCH_AC_CHECK_ARMOR)                   != 0;
			savedc_ac2.Checked = b && (savedctype & hc.HENCH_AC_CHECK_SHIELD)                  != 0;
			savedc_ac3.Checked = b && (savedctype & hc.HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE) != 0;

			int val;

// WeaponBonus dropdown-list
			switch (savedctype)
			{
				case   0: val = 0; break;
				case 100: val = 1; break;
				case 101: val = 2; break;
				case 102: val = 3; break;

				default:
					val = -1;
					cbo_dc_WeaponBonus.ForeColor = Color.Crimson;
					break;
			}

			if (val != -1)
			{
				cbo_dc_WeaponBonus.ForeColor = DefaultForeColor;
			}

			cbo_dc_WeaponBonus.SelectedIndex = val;

// SaveDc dropdown-list
			switch (savedctype)
			{
				case -1000: val = 0; break;
				case     0: val = 1; break;

				case  1000:
				case  1001:
				case  1002:
				case  1003:
				case  1004:
				case  1005:
				case  1006:
				case  1007: val = savedctype -  998; break;

				case  1010:
				case  1011:
				case  1012:
				case  1013:
				case  1014: val = savedctype - 1000; break;

				case  1020:
				case  1021:
				case  1022: val = savedctype - 1005; break;

				case  1024:
				case  1025: val = savedctype - 1006; break;

				default:
					val = -1;
					cbo_dc_SaveDC.ForeColor = Color.Crimson;
					break;
			}

			if (val != -1)
			{
				cbo_dc_SaveDC.ForeColor = DefaultForeColor;
			}

			cbo_dc_SaveDC.SelectedIndex = val;
		}
	}
}
