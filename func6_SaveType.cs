using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SaveType page.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the SaveType page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_st(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_st() bypassTextChanged= " + bypassTextChanged);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
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
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.savetype = savetype;

					// check it
					int differ = SpellDiffer(spell, spellchanged);
					spell.differ = differ;
					Spells[Id] = spell;

					//logfile.Log(". differ= " + differ);

					if (differ != bit_clear)
					{
						SpellsChanged[Id] = spellchanged;

						if ((differ & bit_savetype) != 0)
						{
							SaveType_reset.ForeColor = Color.Crimson;
						}

						SpellTree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						SpellsChanged.Remove(Id);

						SaveType_reset.ForeColor = DefaultForeColor;

						if (!spell.isChanged) // this is set by the Apply btn only.
						{
							SpellTree.SelectedNode.ForeColor = DefaultForeColor;
						}
					}

					PrintCurrent(savetype, null, SaveType_hex, SaveType_bin);
				}

				CheckSaveTypeCheckers(savetype);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					si_Child4.Text = SaveType_text.Text;
				}
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's savetype.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_st_reset(object sender, EventArgs e)
		{
			if (SpellsChanged.ContainsKey(Id))
			{
				Spell spell = Spells[Id];
				spell.differ &= ~bit_savetype;
				Spells[Id] = spell;

				if (spell.differ == bit_clear)
				{
					SpellsChanged.Remove(Id);

					if (spell.isChanged) // this is set by the Apply btn only.
					{
						SpellTree.SelectedNode.ForeColor = Color.Blue;
					}
					else
						SpellTree.SelectedNode.ForeColor = DefaultForeColor;
				}

				SaveType_reset.ForeColor = DefaultForeColor;

				SaveType_text.Text = spell.savetype.ToString();
			}
		}

		/// <summary>
		/// Populates the SaveType dropdown-lists.
		/// </summary>
		void PopulateSaveTypeComboboxes()
		{
			// populate the dropdown list for SaveType - Special type
			// NOTE: These special cases are considered in 'hench_i0_attack' HenchSpellAttack()
			cbo_st_Specific.Items.Add("none");										//  0
			cbo_st_Specific.Items.Add("heal");										//  1
			cbo_st_Specific.Items.Add("negative heal");								//  2
			cbo_st_Specific.Items.Add("target must be humanoid");					//  3
			cbo_st_Specific.Items.Add("not already affected");						//  4
			cbo_st_Specific.Items.Add("target must be incorporeal");				//  5
			cbo_st_Specific.Items.Add("darkness");									//  6
			cbo_st_Specific.Items.Add("petrify");									//  7
			cbo_st_Specific.Items.Add("target must be animal");						//  8
			cbo_st_Specific.Items.Add("target must not be construct or undead");	//  9
			cbo_st_Specific.Items.Add("drown");										// 10
			cbo_st_Specific.Items.Add("sleep");										// 11
			cbo_st_Specific.Items.Add("bigby's hand");								// 12
			cbo_st_Specific.Items.Add("target must be undead");						// 13
			cbo_st_Specific.Items.Add("target must not be undead");					// 14
			cbo_st_Specific.Items.Add("target must not be immune to phantasms");	// 15
			cbo_st_Specific.Items.Add("magic missile");								// 16
			cbo_st_Specific.Items.Add("inferno or combust");						// 17
			cbo_st_Specific.Items.Add("dismissal or banishment");					// 18
			cbo_st_Specific.Items.Add("target must be spellcaster");				// 19
			cbo_st_Specific.Items.Add("does not affect elf");						// 20
			cbo_st_Specific.Items.Add("target must be construct");					// 21
			cbo_st_Specific.Items.Add("searing light");								// 22
			cbo_st_Specific.Items.Add("mindflayer's mindblast");					// 23
			cbo_st_Specific.Items.Add("evard's tentacles");							// 24
			cbo_st_Specific.Items.Add("ironhorn");									// 25
			cbo_st_Specific.Items.Add("prism");										// 26
			cbo_st_Specific.Items.Add("target must be spirit");						// 27
			cbo_st_Specific.Items.Add("word of faith");								// 28
			cbo_st_Specific.Items.Add("cloudkill");									// 29
			cbo_st_Specific.Items.Add("target must be humanoid or animal");			// 30
			cbo_st_Specific.Items.Add("daze");										// 31
			cbo_st_Specific.Items.Add("tasha's");									// 32
			cbo_st_Specific.Items.Add("cause fear");								// 33
			cbo_st_Specific.Items.Add("reduce damage-weight by target's hp%");		// 34
			cbo_st_Specific.Items.Add("creeping doom");								// 35
			cbo_st_Specific.Items.Add("deathknell");								// 36
			cbo_st_Specific.Items.Add("caster is warlock");							// 37
			cbo_st_Specific.Items.Add("moonbolt");									// 38
			cbo_st_Specific.Items.Add("swamplung");									// 39
			cbo_st_Specific.Items.Add("target must be seen");						// 40
			cbo_st_Specific.Items.Add("color spray");								// 41
			cbo_st_Specific.Items.Add("sunbeam");									// 42
			cbo_st_Specific.Items.Add("sunburst");									// 43
			cbo_st_Specific.Items.Add("target must be medium or smaller");			// 44
			cbo_st_Specific.Items.Add("castigate");									// 45
			cbo_st_Specific.Items.Add("target is doing fighter-like actions");		// 46
			cbo_st_Specific.Items.Add("target must not be deaf");					// 47
			cbo_st_Specific.Items.Add("holy blas");									// 48
			cbo_st_Specific.Items.Add("target must be evil");						// 49

			// populate the dropdown list for SaveType - Immunity1 type
			// NOTE: These immunity cases are considered in 'hench_i0_attack' HenchSpellAttack()
			// NOTE: These immunity cases are considered in 'hench_i0_buff'   HenchCheckBuff()
			// NOTE: These immunity cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()
			// NOTE: These immunity cases are considered in 'hench_i0_heal'   HenchCheckCureCondition()
			cbo_st_Immunity1.Items.Add("none");							//  0
			cbo_st_Immunity1.Items.Add("mind-affecting");				//  1 // these need to be shifted << 6
			cbo_st_Immunity1.Items.Add("poison");						//  2
			cbo_st_Immunity1.Items.Add("disease");						//  3
			cbo_st_Immunity1.Items.Add("fear");							//  4
			cbo_st_Immunity1.Items.Add("trap");							//  5
			cbo_st_Immunity1.Items.Add("paralysis");					//  6
			cbo_st_Immunity1.Items.Add("blindness");					//  7
			cbo_st_Immunity1.Items.Add("deafness");						//  8
			cbo_st_Immunity1.Items.Add("slow");							//  9
			cbo_st_Immunity1.Items.Add("entangle");						// 10
			cbo_st_Immunity1.Items.Add("silence");						// 11
			cbo_st_Immunity1.Items.Add("stun");							// 12
			cbo_st_Immunity1.Items.Add("sleep");						// 13
			cbo_st_Immunity1.Items.Add("charm");						// 14
			cbo_st_Immunity1.Items.Add("dominate");						// 15
			cbo_st_Immunity1.Items.Add("confused");						// 16
			cbo_st_Immunity1.Items.Add("cursed");						// 17
			cbo_st_Immunity1.Items.Add("dazed");						// 18
			cbo_st_Immunity1.Items.Add("ability decrease");				// 19
			cbo_st_Immunity1.Items.Add("attack decrease");				// 20
			cbo_st_Immunity1.Items.Add("damage decrease");				// 21
			cbo_st_Immunity1.Items.Add("damage immunity decrease");		// 22
			cbo_st_Immunity1.Items.Add("ac decrease");					// 23
			cbo_st_Immunity1.Items.Add("movement speed decrease");		// 24
			cbo_st_Immunity1.Items.Add("saving throw decrease");		// 25
			cbo_st_Immunity1.Items.Add("spell resistance decrease");	// 26
			cbo_st_Immunity1.Items.Add("skill decrease");				// 27
			cbo_st_Immunity1.Items.Add("knockdown");					// 28
			cbo_st_Immunity1.Items.Add("negative level");				// 29
			cbo_st_Immunity1.Items.Add("sneak attack");					// 30
			cbo_st_Immunity1.Items.Add("critical hit");					// 31
			cbo_st_Immunity1.Items.Add("death");						// 32

			// populate the dropdown list for SaveType - Immunity2 type
			// NOTE: These immunity cases are considered in 'hench_i0_attack' HenchSpellAttack()
			// NOTE: These immunity cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()
			cbo_st_Immunity2.Items.Add("none");							//  0
			cbo_st_Immunity2.Items.Add("mind-affecting");				//  1 // these need to be shifted << 12
			cbo_st_Immunity2.Items.Add("poison");						//  2
			cbo_st_Immunity2.Items.Add("disease");						//  3
			cbo_st_Immunity2.Items.Add("fear");							//  4
			cbo_st_Immunity2.Items.Add("trap");							//  5
			cbo_st_Immunity2.Items.Add("paralysis");					//  6
			cbo_st_Immunity2.Items.Add("blindness");					//  7
			cbo_st_Immunity2.Items.Add("deafness");						//  8
			cbo_st_Immunity2.Items.Add("slow");							//  9
			cbo_st_Immunity2.Items.Add("entangle");						// 10
			cbo_st_Immunity2.Items.Add("silence");						// 11
			cbo_st_Immunity2.Items.Add("stun");							// 12
			cbo_st_Immunity2.Items.Add("sleep");						// 13
			cbo_st_Immunity2.Items.Add("charm");						// 14
			cbo_st_Immunity2.Items.Add("dominate");						// 15
			cbo_st_Immunity2.Items.Add("confused");						// 16
			cbo_st_Immunity2.Items.Add("cursed");						// 17
			cbo_st_Immunity2.Items.Add("dazed");						// 18
			cbo_st_Immunity2.Items.Add("ability decrease");				// 19
			cbo_st_Immunity2.Items.Add("attack decrease");				// 20
			cbo_st_Immunity2.Items.Add("damage decrease");				// 21
			cbo_st_Immunity2.Items.Add("damage immunity decrease");		// 22
			cbo_st_Immunity2.Items.Add("ac decrease");					// 23
			cbo_st_Immunity2.Items.Add("movement speed decrease");		// 24
			cbo_st_Immunity2.Items.Add("saving throw decrease");		// 25
			cbo_st_Immunity2.Items.Add("spell resistance decrease");	// 26
			cbo_st_Immunity2.Items.Add("skill decrease");				// 27
			cbo_st_Immunity2.Items.Add("knockdown");					// 28
			cbo_st_Immunity2.Items.Add("negative level");				// 29
			cbo_st_Immunity2.Items.Add("sneak attack");					// 30
			cbo_st_Immunity2.Items.Add("critical hit");					// 31
			cbo_st_Immunity2.Items.Add("death");						// 32

			// populate the dropdown list for SaveType - Weapon type
			// NOTE: These weapon cases are considered in 'hench_i0_buff' HenchCheckWeaponBuff()
			cbo_st_Weapon.Items.Add("none");		//    0
			cbo_st_Weapon.Items.Add("staff");		//    1
			cbo_st_Weapon.Items.Add("slashing");	//    2
			cbo_st_Weapon.Items.Add("holy sword");	//    4
			cbo_st_Weapon.Items.Add("bludgeoning");	//    8
			cbo_st_Weapon.Items.Add("undead");		//   16
			cbo_st_Weapon.Items.Add("druid");		// 4096

			// populate the dropdown list for SaveType - AcBonus type
			// NOTE: These ac-bonus cases are considered in 'hench_i0_buff' HenchCheckACBuff()
			cbo_st_AcBonus.Items.Add("dodge (or none)");	// 0
			cbo_st_AcBonus.Items.Add("natural");			// 1 // these need to be shifted << 18
			cbo_st_AcBonus.Items.Add("armor");				// 2
			cbo_st_AcBonus.Items.Add("shield");				// 3
			cbo_st_AcBonus.Items.Add("deflection");			// 4

			// TODO: There are further issues in 'hench_i0_buff'.
		}

		/// <summary>
		/// Handles toggling bits by combobox on the SaveType page - Specific group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_st_cbo_Specific(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_st_cbo_Specific() selectedId= " + cbo_st_Specific.SelectedIndex);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
//				bypassCheckedChecker = true; // don't do that since this can change other bits

				savetype &= ~HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK; // 0x0000003f
				SaveType_text.Text = (savetype | cbo_st_Specific.SelectedIndex).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Immunity1(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
//				bypassCheckedChecker = true; // don't do that since this can change other bits

				savetype &= ~HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK; // 0x00000fc0
				int val = cbo_st_Immunity1.SelectedIndex << 6;
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Immunity2(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
//				bypassCheckedChecker = true; // don't do that since this can change other bits

				savetype &= ~HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK; // 0x0003f000
				int val = cbo_st_Immunity2.SelectedIndex << 12;
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Weapon(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
//				bypassCheckedChecker = true; // don't do that since this can change other bits

				// TODO: could also clear all type1 and type2 save- and damage-types incl/ AcBonus-types

				savetype &= ~HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK;	// clear bits for Immunity1- and Immunity2-types ...
				savetype &= ~HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK;
				savetype &= ~HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK;		// and specific-types

				int val = cbo_st_Weapon.SelectedIndex;
				switch (val)
				{
					default: val = 0;                       break;

					case 1: val = HENCH_WEAPON_STAFF_FLAG;  break; // 1
					case 2: val = HENCH_WEAPON_SLASH_FLAG;  break; // 2
					case 3: val = HENCH_WEAPON_HOLY_SWORD;  break; // 4
					case 4: val = HENCH_WEAPON_BLUNT_FLAG;  break; // 8
					case 5: val = HENCH_WEAPON_UNDEAD_FLAG; break; // 16
					case 6: val = HENCH_WEAPON_DRUID_FLAG;  break; // 4096 // this overlaps the bit for IMMUNITY_TYPE_MIND_SPELLS (immunity2type)
				}
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_AcBonus(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
//				bypassCheckedChecker = true; // don't do that since this can change other bits

				// TODO: could also clear bits for Immunity1- and Immunity2-types ...

				savetype &= ~HENCH_SPELL_SAVE_TYPE_SAVES_MASK; // clear all type1 and type2 save- and damage-types incl/ AcBonus-types
				int val = cbo_st_AcBonus.SelectedIndex << 18;
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by radiobuttons on the SaveType page - Type1Save group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_Type1Save(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_Type1Save()");

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~HENCH_SPELL_SAVE_TYPE_SAVE1_WILL; // mask

				var rb = sender as RadioButton;
				if (rb.Equals(st_Save1rb_fort))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_FORT; // NOTE: This bit overlaps AC_NATURAL_BONUS
				}
				else if (rb.Equals(st_Save1rb_refl))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_REFLEX; // NOTE: This bit overlaps AC_ARMOUR_ENCHANTMENT_BONUS
				}
				else if (rb.Equals(st_Save1rb_will))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_WILL; // NOTE: This bit overlaps AC_SHIELD_ENCHANTMENT_BONUS
				}
//				else if (rb.Equals(st_Save1rb_none))
//				{}

//				bypassCheckedChecker = true; // don't do that since this can change other bits
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by radiobuttons on the SaveType page - Type1Damage group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_Type1Damage(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_Type1Damage()");

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION; // mask

				var rb = sender as RadioButton;
				if (rb.Equals(st_Impact1rb_damagehalf))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_HALF; // NOTE: This bit overlaps AC_DEFLECTION_BONUS
				}
				else if (rb.Equals(st_Impact1rb_effectdamage))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_EFFECT_DAMAGE;
				}
				else if (rb.Equals(st_Impact1rb_damageevasion))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION;
				}
//				else if (rb.Equals(st_Impact1rb_effectonly))
//				{}

//				bypassCheckedChecker = true; // don't do that since this can change other bits
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by radiobuttons on the SaveType page - Type2Save group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_Type2Save(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_Type2Save()");

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~HENCH_SPELL_SAVE_TYPE_SAVE2_WILL; // mask

				var rb = sender as RadioButton;
				if (rb.Equals(st_Save2rb_fort))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_FORT;
				}
				else if (rb.Equals(st_Save2rb_refl))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_REFLEX;
				}
				else if (rb.Equals(st_Save2rb_will))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_WILL;
				}
//				else if (rb.Equals(st_Save2rb_none))
//				{}

//				bypassCheckedChecker = true; // don't do that since this can change other bits
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by radiobuttons on the SaveType page - Type2Damage group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_Type2Damage(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_Type1Damage()");

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION; // mask

				var rb = sender as RadioButton;
				if (rb.Equals(st_Impact2rb_damagehalf))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_HALF;
				}
				else if (rb.Equals(st_Impact2rb_effectdamage))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_EFFECT_DAMAGE;
				}
				else if (rb.Equals(st_Impact2rb_damageevasion))
				{
					savetype |= HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION;
				}
//				else if (rb.Equals(st_Impact2rb_effectonly))
//				{}

//				bypassCheckedChecker = true; // don't do that since this can change other bits
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the SaveType page - General group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_General(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_General()");
			//logfile.Log(". text= " + SaveType_text.Text);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				//logfile.Log(". . is valid Int32= " + savetype);

				var cb = sender as CheckBox;
				if (cb.Equals(st_SpellResistance))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_SR_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_SR_FLAG;
				}
				else if (cb.Equals(st_MindAffecting))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG;
				}
				else if (cb.Equals(st_AffectsFriendlies))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG;
				}
				else if (cb.Equals(st_NotCaster))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG;
				}
				else if (cb.Equals(st_TouchMelee))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG;
				}
				else if (cb.Equals(st_TouchRanged))
				{
					if (cb.Checked)
					{
						savetype |= HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG;
					}
					else
						savetype &= ~HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG;
				}

//				bypassCheckedChecker = true; // don't do that since this can change other bits
				SaveType_text.Text = savetype.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the SaveType page - exclusive DamageTypes group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_excl_Damagetype(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_excl_Damagetype()");
			//logfile.Log(". text= " + SaveType_text.Text);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				//logfile.Log(". . is valid Int32= " + savetype);

				int bit;

				var cb = sender as CheckBox;
				if (cb.Equals(st_Excl_Bludgeoning))
				{
					bit = DAMAGE_TYPE_BLUDGEONING;
				}
				else if (cb.Equals(st_Excl_Piercing))
				{
					bit = DAMAGE_TYPE_PIERCING;
				}
				else if (cb.Equals(st_Excl_Slashing))
				{
					bit = DAMAGE_TYPE_SLASHING;
				}
				else if (cb.Equals(st_Excl_Magical))
				{
					bit = DAMAGE_TYPE_MAGICAL;
				}
				else if (cb.Equals(st_Excl_Acid))
				{
					bit = DAMAGE_TYPE_ACID;
				}
				else if (cb.Equals(st_Excl_Cold))
				{
					bit = DAMAGE_TYPE_COLD;
				}
				else if (cb.Equals(st_Excl_Divine))
				{
					bit = DAMAGE_TYPE_DIVINE;
				}
				else if (cb.Equals(st_Excl_Electrical))
				{
					bit = DAMAGE_TYPE_ELECTRICAL;
				}
				else if (cb.Equals(st_Excl_Fire))
				{
					bit = DAMAGE_TYPE_FIRE;
				}
				else if (cb.Equals(st_Excl_Negative))
				{
					bit = DAMAGE_TYPE_NEGATIVE;
				}
				else if (cb.Equals(st_Excl_Positive))
				{
					bit = DAMAGE_TYPE_POSITIVE;
				}
				else //if (cb.Equals(st_Excl_Sonic))
				{
					bit = DAMAGE_TYPE_SONIC;
				}

				if (cb.Checked)
				{
					savetype |= bit;
				}
				else
					savetype &= ~bit;

//				bypassCheckedChecker = true; // don't do it. This can toggle other checkers.
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes/radiobuttons on the SaveType
		/// page - exclusive Flags group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_excl_Flags(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_excl_Flags()");
			//logfile.Log(". text= " + SaveType_text.Text);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				//logfile.Log(". . is valid Int32= " + savetype);

				int bit;

				var rb = sender as RadioButton;
				if (rb != null)
				{
					if (rb.Equals(st_Excl_rbImmunity))
					{
						savetype &= ~HENCH_IMMUNITY_WEIGHT_RESISTANCE; // 0x00100000
					}
					else //if (rb.Equals(st_Excl_Flags_rbResistance))
					{
						savetype |= HENCH_IMMUNITY_WEIGHT_RESISTANCE;
					}
				}
				else
				{
					var cb = sender as CheckBox;
					if (cb.Equals(st_Excl_Onlyone))
					{
						bit = HENCH_IMMUNITY_ONLY_ONE; // 0x00200000
					}
					else //if (cb.Equals(st_Excl_General))
					{
						bit = HENCH_IMMUNITY_GENERAL; // 0x00400000
					}

					if (cb.Checked)
					{
						savetype |= bit;
					}
					else
						savetype &= ~bit;
				}

//				bypassCheckedChecker = true; // don't do it. This can toggle other checkers.
				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles changing exclusive Weight in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_st_excl_Weight(object sender, EventArgs e)
		{
			int weight;
			if (Int32.TryParse(st_Excl_Weight.Text, out weight))
			{
				if (weight < 0)
				{
					weight = 0;
					st_Excl_Weight.Text = weight.ToString(); // re-trigger this funct.
				}
				else if (weight > 255) // 8 bits
				{
					weight = 255;
					st_Excl_Weight.Text = weight.ToString(); // re-trigger this funct.
				}
				else
				{
					int savetype = Int32.Parse(SaveType_text.Text);
					savetype &= ~HENCH_IMMUNITY_WEIGHT_AMOUNT_MASK; // 0x000ff000

					weight <<= HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT;
					SaveType_text.Text = (savetype | weight).ToString();
				}
			}
		}


		const int HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT = 12;

		/// <summary>
		/// Sets the checkers on the SaveType page to reflect the current
		/// savetype value.
		/// </summary>
		/// <param name="savetype"></param>
		void CheckSaveTypeCheckers(int savetype)
		{
			//logfile.Log("CheckSaveTypeCheckers()");

			if (!bypassCheckedChecker)
			{
				//logfile.Log(". savetype= " + savetype);

				// Type 1 Save radiobuttons
				st_Save1rb_none.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_WILL)   == 0;
				st_Save1rb_fort.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_FORT)   != 0;
				st_Save1rb_refl.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_REFLEX) != 0;
				st_Save1rb_will.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_WILL)   == HENCH_SPELL_SAVE_TYPE_SAVE1_WILL;

				// Type 2 Save radiobuttons
				st_Save2rb_none.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_WILL)   == 0;
				st_Save2rb_fort.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_FORT)   != 0;
				st_Save2rb_refl.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_REFLEX) != 0;
				st_Save2rb_will.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_WILL)   == HENCH_SPELL_SAVE_TYPE_SAVE2_WILL;

				// Type 1 Damage radiobuttons
				st_Impact1rb_effectonly.Checked    = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION) == 0;
				st_Impact1rb_damagehalf.Checked    = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_HALF)    != 0;
				st_Impact1rb_effectdamage.Checked  = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_EFFECT_DAMAGE)  != 0;
				st_Impact1rb_damageevasion.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION) == HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION;

				// Type 2 Damage radiobuttons
				st_Impact2rb_effectonly.Checked    = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION) == 0;
				st_Impact2rb_damagehalf.Checked    = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_HALF)    != 0;
				st_Impact2rb_effectdamage.Checked  = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_EFFECT_DAMAGE)  != 0;
				st_Impact2rb_damageevasion.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION) == HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION;

				// General checkboxes
				st_SpellResistance.Checked   = (savetype & HENCH_SPELL_SAVE_TYPE_SR_FLAG)             != 0;
				st_MindAffecting.Checked     = (savetype & HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG)     != 0;
				st_AffectsFriendlies.Checked = (savetype & HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG) != 0;
				st_NotCaster.Checked         = (savetype & HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG)        != 0;
				st_TouchMelee.Checked        = (savetype & HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG)    != 0;
				st_TouchRanged.Checked       = (savetype & HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG)    != 0;


				// Specific dropdown-list
				int val = savetype;
				val &= HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK;
				if (val >= cbo_st_Specific.Items.Count)
				{
					val = -1;
				}
				//logfile.Log(". specific= " + val);
				cbo_st_Specific.SelectedIndex = val;

				// Immunity1 dropdown-list
				val = savetype;
				val &= HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK;
				val >>= 6;
				if (val >= cbo_st_Immunity1.Items.Count)
				{
					val = -1;
				}
				//logfile.Log(". immunity1= " + val);
				cbo_st_Immunity1.SelectedIndex = val;

				// Immunity2 dropdown-list
				val = savetype;
				val &= HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK;
				val >>= 12;
				if (val >= cbo_st_Immunity2.Items.Count)
				{
					val = -1;
				}
				//logfile.Log(". immunity2= " + val);
				cbo_st_Immunity2.SelectedIndex = val;


				// AcBonus dropdown-list
				val = savetype;
				val &= 0x001c0000; // mask for AcBonus-types
				val >>= 18;
				if (val >= cbo_st_AcBonus.Items.Count)
				{
					val = -1;
				}
				//logfile.Log(". acbonus= " + val);
				cbo_st_AcBonus.SelectedIndex = val;

				// Weapon dropdown-list - TODO: better this
				if      ((savetype & HENCH_WEAPON_STAFF_FLAG)  != 0) // 1
					val = 1;
				else if ((savetype & HENCH_WEAPON_SLASH_FLAG)  != 0) // 2
					val = 2;
				else if ((savetype & HENCH_WEAPON_HOLY_SWORD)  != 0) // 4
					val = 3;
				else if ((savetype & HENCH_WEAPON_BLUNT_FLAG)  != 0) // 8
					val = 4;
				else if ((savetype & HENCH_WEAPON_UNDEAD_FLAG) != 0) // 16
					val = 5;
				else if ((savetype & HENCH_WEAPON_DRUID_FLAG)  != 0) // 4096
					val = 6;
				else
					val = 0;

				//logfile.Log(". weapon= " + val);
				cbo_st_Weapon.SelectedIndex = val;


				// Exclusive Group
				// DamageType checkboxes
				st_Excl_Bludgeoning.Checked = (savetype & DAMAGE_TYPE_BLUDGEONING) != 0;
				st_Excl_Piercing   .Checked = (savetype & DAMAGE_TYPE_PIERCING)    != 0;
				st_Excl_Slashing   .Checked = (savetype & DAMAGE_TYPE_SLASHING)    != 0;
				st_Excl_Magical    .Checked = (savetype & DAMAGE_TYPE_MAGICAL)     != 0;
				st_Excl_Acid       .Checked = (savetype & DAMAGE_TYPE_ACID)        != 0;
				st_Excl_Cold       .Checked = (savetype & DAMAGE_TYPE_COLD)        != 0;
				st_Excl_Divine     .Checked = (savetype & DAMAGE_TYPE_DIVINE)      != 0;
				st_Excl_Electrical .Checked = (savetype & DAMAGE_TYPE_ELECTRICAL)  != 0;
				st_Excl_Fire       .Checked = (savetype & DAMAGE_TYPE_FIRE)        != 0;
				st_Excl_Negative   .Checked = (savetype & DAMAGE_TYPE_NEGATIVE)    != 0;
				st_Excl_Positive   .Checked = (savetype & DAMAGE_TYPE_POSITIVE)    != 0;
				st_Excl_Sonic      .Checked = (savetype & DAMAGE_TYPE_SONIC)       != 0;

				// Flags radiobuttons
				bool isResist = (savetype & HENCH_IMMUNITY_WEIGHT_RESISTANCE) != 0;
				st_Excl_rbImmunity  .Checked = !isResist;
				st_Excl_rbResistance.Checked =  isResist;

				// Flags checkboxes
				st_Excl_Onlyone.Checked = (savetype & HENCH_IMMUNITY_ONLY_ONE) != 0;
				st_Excl_General.Checked = (savetype & HENCH_IMMUNITY_GENERAL)  != 0;

				// Weight textbox
				val = (savetype & HENCH_IMMUNITY_WEIGHT_AMOUNT_MASK); // 0x000ff000
				val >>= HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT;
				st_Excl_Weight.Text = val.ToString();
			}
			else
			{
				//logfile.Log(". bypassed");
				bypassCheckedChecker = false;
			}
		}
	}
}
