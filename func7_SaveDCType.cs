using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SaveDCType page.
	/// </summary>
	partial class MainForm
	{
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
				if (!bypassTextChanged)
				{
					var spell = Spells[Id];

					SpellChanged spellchanged;

					if (SpellsChanged.ContainsKey(Id))
					{
						spellchanged = SpellsChanged[Id];
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
					int differ = SpellDiffer(spell, spellchanged);
					spell.differ = differ;
					Spells[Id] = spell;

					//logfile.Log(". differ= " + differ);

					if (differ != bit_clear)
					{
						SpellsChanged[Id] = spellchanged;
						Tree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						SpellsChanged.Remove(Id);

						if (!spell.isChanged) // this is set by the Apply btn only.
						{
							Tree.SelectedNode.ForeColor = DefaultForeColor;
						}
					}

					PrintCurrent(savedctype, null, SaveDCType_hex, SaveDCType_bin);
				}

				if ((Spells[Id].differ & bit_savedctype) != 0)
				{
					SaveDCType_reset.ForeColor = Color.Crimson;
				}
				else
					SaveDCType_reset.ForeColor = DefaultForeColor;

				CheckSaveDcTypeCheckers(savedctype);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					si_Child5.Text = SaveDCType_text.Text;
				}


				// The DC must be less than 1000 for the adjustor-buttons to appear.
				// 1000+ thar be AI-constants that are set using the DC-combobox.
				savedc_up.Enabled = (savedctype <  999); // disallow incrementing up to 1000
				savedc_dn.Enabled = (savedctype < 1000); // 1000 is a CoreAI constant that shall be accessed in the dropdown

				// TODO: should probably disable if savedctype is negative.
				dc_ArmorCheckGrp.Enabled = (savedctype & ~HENCH_SAVEDCTYPE_ARMORCHECK_MASK) == 0;
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
			//logfile.Log("Click_dc_reset()");

			if (SpellsChanged.ContainsKey(Id))
			{
				Spell spell = Spells[Id];
				spell.differ &= ~bit_savedctype;
				Spells[Id] = spell;

				if (spell.differ == bit_clear)
				{
					SpellsChanged.Remove(Id);

					if (spell.isChanged) // this is set by the Apply btn only.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else
						Tree.SelectedNode.ForeColor = DefaultForeColor;
				}

				SaveDCType_reset.ForeColor = DefaultForeColor;

				SaveDCType_text.Text = spell.savedctype.ToString();
			}
		}


		/// <summary>
		/// Populates the SaveDCType dropdown-lists.
		/// </summary>
		void PopulateSaveDcTypeComboboxes()
		{
			// populate the dropdown list for SaveDCType
			cbo_dc_SaveDC.Items.Add("spell dc standard");			// -1000
			cbo_dc_SaveDC.Items.Add("no save");						// 0
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd");				// 1000
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2");			// 1001
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 4");			// 1002
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2 + Con");		// 1003
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2 + Con - 5");	// 1004
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2 + Wis");		// 1005
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2 + 5");		// 1006
			cbo_dc_SaveDC.Items.Add("dc = 10 + hd / 2 + Cha");		// 1007
			cbo_dc_SaveDC.Items.Add("disease bolt");				// 1010
			cbo_dc_SaveDC.Items.Add("disease cone");				// 1011
			cbo_dc_SaveDC.Items.Add("disease pulse");				// 1012
			cbo_dc_SaveDC.Items.Add("poison");						// 1013
			cbo_dc_SaveDC.Items.Add("epic dc");						// 1014
			cbo_dc_SaveDC.Items.Add("deathless master touch");		// 1020
			cbo_dc_SaveDC.Items.Add("undead graft");				// 1021
			cbo_dc_SaveDC.Items.Add("caster dc (n/a spell-level)");	// 1022
			cbo_dc_SaveDC.Items.Add("bardic slow");					// 1024
			cbo_dc_SaveDC.Items.Add("bardic fascinate");			// 1025

			// populate the dropdown list for SaveDCType - WeaponBonusType
			cbo_dc_WeaponBonus.Items.Add("none");									// 0
			cbo_dc_WeaponBonus.Items.Add("weapon bonus - (casterlevel / 4)");		// 100
			cbo_dc_WeaponBonus.Items.Add("weapon bonus - (casterlevel + 1) / 3");	// 101
			cbo_dc_WeaponBonus.Items.Add("weapon bonus - (casterlevel / 3) - 1");	// 102
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
				case  0: text = HENCH_SAVEDC_SPELL.ToString();                  break; // -1000

				case  1: text = HENCH_SAVEDC_NONE.ToString();                   break; // 0

				case  2: text = HENCH_SAVEDC_HD_1.ToString();                   break; // 1000
				case  3: text = HENCH_SAVEDC_HD_2.ToString();                   break; // 1001
				case  4: text = HENCH_SAVEDC_HD_4.ToString();                   break; // 1002
				case  5: text = HENCH_SAVEDC_HD_2_CONST.ToString();             break; // 1003
				case  6: text = HENCH_SAVEDC_HD_2_CONST_MINUS_5.ToString();     break; // 1004
				case  7: text = HENCH_SAVEDC_HD_2_WIS.ToString();               break; // 1005
				case  8: text = HENCH_SAVEDC_HD_2_PLUS_5.ToString();            break; // 1006
				case  9: text = HENCH_SAVEDC_HD_2_CHA.ToString();               break; // 1007

				case 10: text = HENCH_SAVEDC_DISEASE_BOLT.ToString();           break; // 1010
				case 11: text = HENCH_SAVEDC_DISEASE_CONE.ToString();           break; // 1011
				case 12: text = HENCH_SAVEDC_DISEASE_PULSE.ToString();          break; // 1012
				case 13: text = HENCH_SAVEDC_POISON.ToString();                 break; // 1013
				case 14: text = HENCH_SAVEDC_EPIC.ToString();                   break; // 1014

				case 15: text = HENCH_SAVEDC_DEATHLESS_MASTER_TOUCH.ToString(); break; // 1020
				case 16: text = HENCH_SAVEDC_UNDEAD_GRAFT.ToString();           break; // 1021
				case 17: text = HENCH_SAVEDC_SPELL_NO_SPELL_LEVEL.ToString();   break; // 1022

				case 18: text = HENCH_SAVEDC_BARD_SLOWING.ToString();           break; // 1024
				case 19: text = HENCH_SAVEDC_BARD_FASCINATE.ToString();         break; // 1025
			}

//			bypassCheckedChecker = true;
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
				if (btn.Equals(savedc_up))
				{
					++savedctype;
				}
				else //if (rb.Equals(savedc_dn))
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
				case 3: text = "102"; break; // spelltype - HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
			}

//			bypassCheckedChecker = true;
			SaveDCType_text.Text = text;
		}


		/// <summary>
		/// Mask for all allowable ArmorCheckType bits.
		/// </summary>
		const int HENCH_SAVEDCTYPE_ARMORCHECK_MASK = 0x10000003;

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
				if (cb.Equals(savedc_ac1))
				{
					bit = HENCH_AC_CHECK_ARMOR; // 0x00000001
				}
				else if (cb.Equals(savedc_ac2))
				{
					bit = HENCH_AC_CHECK_SHIELD; // 0x00000002
				}
				else //if (cb.Equals(savedc_ac3))
				{
					bit = HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE; // 0x10000000
				}

				if (cb.Checked)
				{
					savedctype |= bit;
				}
				else
					savedctype &= ~bit;

//				bypassCheckedChecker = true;
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
			if (!bypassCheckedChecker)
			{
// ArmorCheck checkboxes
				bool b = (savedctype > -1); // a negative value wreaks havoc on the speed-decrease bit ...

				savedc_ac1.Checked = b && (savedctype & HENCH_AC_CHECK_ARMOR)                   != 0;
				savedc_ac2.Checked = b && (savedctype & HENCH_AC_CHECK_SHIELD)                  != 0;
				savedc_ac3.Checked = b && (savedctype & HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE) != 0;

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
			else
				bypassCheckedChecker = false;
		}
	}
}
