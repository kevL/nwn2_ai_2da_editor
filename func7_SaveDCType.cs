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
						SpellTree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						SpellsChanged.Remove(Id);

						if (!spell.isChanged) // this is set by the Apply btn only.
						{
							SpellTree.SelectedNode.ForeColor = DefaultForeColor;
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


//				var type = spell.savedctypetype;
//
//				dc_SaveDCGrp.Visible = (savedctype1.Checked = (type == SaveDcTypeType.SDTT_OFFENSIVE));
//				dc_WeaponBonusGrp.Visible =
//				dc_ArmorCheckGrp.Visible = (savedctype2.Checked = (type == SaveDcTypeType.SDTT_DEFENSIVE));

				DisplayDcAdjustors(savedctype);
				CheckArmorCheckTypeCheckers(savedctype);

				dc_ArmorCheckGrp.Enabled = EnableArmorCheckType(savedctype);

				cbo_dc_SaveDC.SelectedIndex      = -1;	// clear the combobox fields. Just do it.
				cbo_dc_WeaponBonus.SelectedIndex = -1;	// leaving the text in place when the dc-value can be changed
														// other ways would be misleading ... and I don't want to weave
				if (si_IsMaster.Checked)				// in yet more extra code to sort out the mess they made by.
				{										// triple-purposing the SaveDCType field. So just clear the text
					// NOTE: this doesn't result in an infinite loop.
					si_Child5.Text = SaveDCType_text.Text;
				}
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
						SpellTree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else
						SpellTree.SelectedNode.ForeColor = DefaultForeColor;
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
		/// Handler for SaveDCType radiobuttons.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void CheckedChanged_dc_type(object sender, EventArgs e)
		{
			var rb = sender as RadioButton;
			if (rb.Equals(savedctype1)) // SaveDCType (group 1)
			{
				if (rb.Checked)
				{
					dc_SaveDCGrp.Visible      = true;
					dc_WeaponBonusGrp.Visible =
					dc_ArmorCheckGrp.Visible  = false;
	
					var spell = Spells[Id];
					spell.savedctypetype = SaveDcTypeType.SDTT_OFFENSIVE;
					Spells[Id] = spell;
				}
			}
			else //if (rb.Equals(savedctype2)) // WeaponBonusType and ArmorCheckType (group 2/3 - buffs)
			{
				if (rb.Checked)
				{
					dc_SaveDCGrp.Visible      = false;
					dc_WeaponBonusGrp.Visible =
					dc_ArmorCheckGrp.Visible  = true;
	
					var spell = Spells[Id];
					spell.savedctypetype = SaveDcTypeType.SDTT_DEFENSIVE;
					Spells[Id] = spell;
				}
			}
		}

		/// <summary>
		/// Handler for SaveDCType-type (group 1) combobox.
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

			bypassCheckedChecker = true;
			SaveDCType_text.Text = text;
		}

		/// <summary>
		/// Decides whether to display the DC-adjustors (group 1).
		/// note: The DC must be less than 1000 for the buttons to appear. 1000+
		/// thar be AI-constants that can be set using the DC-combobox.
		/// </summary>
		/// <param name="savedctype"></param>
		void DisplayDcAdjustors(int savedctype)
		{
			bool vis = (savedctype < 1000); // show +/- adjustor iff val < 1000

			savedc_up.Visible =
			savedc_dn.Visible = vis;

			savedc_adjustor_info.Visible = vis;
		}

		/// <summary>
		/// Handler for the +/- buttons on the SaveDCType page (group 1).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_dc_adjustors(object sender, EventArgs e)
		{
			int savedctype;
			if (Int32.TryParse(SaveDCType_text.Text, out savedctype))
			{
				var btn = sender as Button;
				if (btn.Equals(savedc_up)) // increment
				{
					if (savedctype != 999)	// disallow incrementing up to 1000 (1000 is a CoreAI
						++savedctype;		// constant that can be accessed in the dropdown)
				}
				else //if (rb.Equals(savedc_dn)) // decrement
				{
					--savedctype;
				}

				// NOTE: allow the text-changed event to update checkers
				SaveDCType_text.Text = savedctype.ToString();
			}
		}

		/// <summary>
		/// Handler for the WeaponBonusType (group 2) combobox.
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

			bypassCheckedChecker = true;
			SaveDCType_text.Text = text;
		}

		/// <summary>
		/// Handler for the SaveDCType - ArmorCheckType (group 3) checkboxes.
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
				int bit;

				var cb = sender as CheckBox;
				if (cb.Equals(savedc_ac1))
				{
					bit = HENCH_AC_CHECK_ARMOR;
				}
				else if (cb.Equals(savedc_ac2))
				{
					bit = HENCH_AC_CHECK_SHIELD;
				}
				else //if (cb.Equals(savedc_ac3))
				{
					bit = HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE;
				}

				if (cb.Checked)
				{
					savedctype |= bit;
				}
				else
					savedctype &= ~bit;

				bypassCheckedChecker = true;
				SaveDCType_text.Text = savedctype.ToString();
			}
		}

		/// <summary>
		/// Sets the checkboxes on the SaveDCType page (group3) to reflect the
		/// current savedctype value.
		/// </summary>
		/// <param name="savedctype"></param>
		void CheckArmorCheckTypeCheckers(int savedctype)
		{
			//logfile.Log("CheckArmorCheckTypeCheckers() savedctype= " + savedctype);

			if (!bypassCheckedChecker)
			{
				bool b = (savedctype > -1); // a negative value wreaks havoc on the speed-decrease bit ...
				savedc_ac1.Checked = b && (savedctype & HENCH_AC_CHECK_ARMOR)                   != 0;
				savedc_ac2.Checked = b && (savedctype & HENCH_AC_CHECK_SHIELD)                  != 0;
				savedc_ac3.Checked = b && (savedctype & HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE) != 0;
			}
			else
				bypassCheckedChecker = false;
		}

		/// <summary>
		/// Checks if the ArmorCheckType checkboxes should be enabled.
		/// </summary>
		/// <param name="savedctype"></param>
		/// <returns></returns>
		bool EnableArmorCheckType(int savedctype)
		{
			// TODO: should probably disable if savedctype is negative.

			const int actypes = 0x10000003; // mask of all allowable ArmorCheckType bits.
			return (savedctype & ~actypes) == 0;
		}
	}
}
