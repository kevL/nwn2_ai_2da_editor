using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SaveType page.
	/// </summary>
	partial class tabcontrol_Spells
	{
		const int HENCH_SPELL_SAVE_TYPE_IMMUNITY1_SHIFT = 6;
		const int HENCH_SPELL_SAVE_TYPE_IMMUNITY2_SHIFT = 12;
		const int HENCH_SPELL_SAVE_TYPE_ACBONUS_MASK    = 0x001c0000;
		const int HENCH_SPELL_SAVE_TYPE_ACBONUS_SHIFT   = 18;
		const int HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT    = 12;

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
				int differ;

				if (!he.BypassDiffer)
				{
					Spell spell = he.Spells[he.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = he.SpellsChanged[he.Id];
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
					differ = SpellDiffer(spell, spellchanged);
					spell.differ = differ;
					he.Spells[he.Id] = spell;

					Color color;
					if (differ != bit_clear)
					{
						he.SpellsChanged[he.Id] = spellchanged;
						color = Color.Crimson;
					}
					else
					{
						he.SpellsChanged.Remove(he.Id);

						if (spell.isChanged) color = Color.Blue;
						else                 color = DefaultForeColor;
					}
					he.that.SetNodeColor(color);
				}

				he.PrintCurrent(savetype, SaveType_hex, SaveType_bin);

				differ = he.Spells[he.Id].differ;

				if ((differ & bit_savetype) != 0)
				{
					SaveType_reset.ForeColor = Color.Crimson;
				}
				else
					SaveType_reset.ForeColor = DefaultForeColor;

				CheckSaveTypeCheckers(savetype);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					// But it does clamp the value before it gets shot back here.
					si_Child4.Text = SaveType_text.Text;
				}

				he.that.SetEnabled(differ != bit_clear);
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
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_savetype) != 0)
			{
				spell.differ &= ~bit_savetype;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clear)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;
					he.that.SetNodeColor(color);
				}

				SaveType_reset.ForeColor = DefaultForeColor;

				SaveType_text.Text = spell.savetype.ToString();
			}
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
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK; // 0x0000003f
				SaveType_text.Text = (savetype | cbo_st_Specific.SelectedIndex).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Immunity1(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK; // 0x00000fc0

				int val = (cbo_st_Immunity1.SelectedIndex << HENCH_SPELL_SAVE_TYPE_IMMUNITY1_SHIFT);
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Immunity2(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK; // 0x0003f000

				int val = cbo_st_Immunity2.SelectedIndex << HENCH_SPELL_SAVE_TYPE_IMMUNITY2_SHIFT;
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_Weapon(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				// TODO: could also clear all type1 and type2 save- and damage-types incl/ AcBonus-types

				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK;	// clear bits for Immunity1- and Immunity2-types ...
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK;
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK;		// and specific-types

				int val = cbo_st_TargetRestriction.SelectedIndex;
				switch (val)
				{
//					default: val = 0;                       break; // let "0" fallthrough

					case 1: val = hc.HENCH_WEAPON_STAFF_FLAG;  break; // 1
					case 2: val = hc.HENCH_WEAPON_SLASH_FLAG;  break; // 2
					case 3: val = hc.HENCH_WEAPON_HOLY_SWORD;  break; // 4
					case 4: val = hc.HENCH_WEAPON_BLUNT_FLAG;  break; // 8
					case 5: val = hc.HENCH_WEAPON_UNDEAD_FLAG; break; // 16
					case 6: val = hc.HENCH_WEAPON_DRUID_FLAG;  break; // 4096 // this overlaps the bit for IMMUNITY_TYPE_MIND_SPELLS (immunity2type)
				}
				SaveType_text.Text = (savetype | val).ToString();
			}
		}

		void SelectionChangeCommitted_st_cbo_AcBonus(object sender, EventArgs e)
		{
			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				// TODO: could also clear bits for Immunity1- and Immunity2-types ...

				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_SAVES_MASK; // clear all type1 and type2 save- and damage-types incl/ AcBonus-types

				int val = (cbo_st_AcBonus.SelectedIndex << HENCH_SPELL_SAVE_TYPE_ACBONUS_SHIFT);
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
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_SAVE1_WILL; // 0x000c0000 - acts as mask also

				var rb = sender as RadioButton;
				if (rb == st_Save1rb_fort)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_FORT; // NOTE: This bit overlaps AC_NATURAL_BONUS
				}
				else if (rb == st_Save1rb_refl)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_REFLEX; // NOTE: This bit overlaps AC_ARMOUR_ENCHANTMENT_BONUS
				}
				else if (rb == st_Save1rb_will)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_WILL; // NOTE: This bit overlaps AC_SHIELD_ENCHANTMENT_BONUS
				}
//				else if (rb == st_Save1rb_none)
//				{}

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
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_SAVE2_WILL; // 0x00c00000 - acts as mask also

				var rb = sender as RadioButton;
				if (rb == st_Save2rb_fort)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_FORT;
				}
				else if (rb == st_Save2rb_refl)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_REFLEX;
				}
				else if (rb == st_Save2rb_will)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_WILL;
				}
//				else if (rb == st_Save2rb_none)
//				{}

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
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION; // 0x00300000 - acts as mask also

				var rb = sender as RadioButton;
				if (rb == st_Impact1rb_damagehalf)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_HALF; // NOTE: This bit overlaps AC_DEFLECTION_BONUS
				}
				else if (rb == st_Impact1rb_effectdamage)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_EFFECT_DAMAGE;
				}
				else if (rb == st_Impact1rb_damageevasion)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION;
				}
//				else if (rb == st_Impact1rb_effectonly)
//				{}

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
				savetype &= ~hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION; // 0x03000000 - acts as mask also

				var rb = sender as RadioButton;
				if (rb == st_Impact2rb_damagehalf)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_HALF;
				}
				else if (rb == st_Impact2rb_effectdamage)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_EFFECT_DAMAGE;
				}
				else if (rb == st_Impact2rb_damageevasion)
				{
					savetype |= hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION;
				}
//				else if (rb == st_Impact2rb_effectonly)
//				{}

				SaveType_text.Text = savetype.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the SaveType page - Flags group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_st_Flags(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_st_General()");
			//logfile.Log(". text= " + SaveType_text.Text);

			int savetype;
			if (Int32.TryParse(SaveType_text.Text, out savetype))
			{
				//logfile.Log(". . is valid Int32= " + savetype);

				int bit;

				var cb = sender as CheckBox;
				if (cb == st_SpellResistance)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_SR_FLAG;
				}
				else if (cb == st_MindAffecting)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG;
				}
				else if (cb == st_AffectsFriendlies)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG;
				}
				else if (cb == st_NotCaster)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG;
				}
				else if (cb == st_TouchMelee)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG;
				}
				else //if (cb == st_TouchRanged)
				{
					bit = hc.HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG;
				}

				if (cb.Checked)
				{
					savetype |= bit;
				}
				else
					savetype &= ~bit;

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
				if (cb == st_Excl_Bludgeoning)
				{
					bit = hc.DAMAGE_TYPE_BLUDGEONING;
				}
				else if (cb == st_Excl_Piercing)
				{
					bit = hc.DAMAGE_TYPE_PIERCING;
				}
				else if (cb == st_Excl_Slashing)
				{
					bit = hc.DAMAGE_TYPE_SLASHING;
				}
				else if (cb == st_Excl_Magical)
				{
					bit = hc.DAMAGE_TYPE_MAGICAL;
				}
				else if (cb == st_Excl_Acid)
				{
					bit = hc.DAMAGE_TYPE_ACID;
				}
				else if (cb == st_Excl_Cold)
				{
					bit = hc.DAMAGE_TYPE_COLD;
				}
				else if (cb == st_Excl_Divine)
				{
					bit = hc.DAMAGE_TYPE_DIVINE;
				}
				else if (cb == st_Excl_Electrical)
				{
					bit = hc.DAMAGE_TYPE_ELECTRICAL;
				}
				else if (cb == st_Excl_Fire)
				{
					bit = hc.DAMAGE_TYPE_FIRE;
				}
				else if (cb == st_Excl_Negative)
				{
					bit = hc.DAMAGE_TYPE_NEGATIVE;
				}
				else if (cb == st_Excl_Positive)
				{
					bit = hc.DAMAGE_TYPE_POSITIVE;
				}
				else //if (cb == st_Excl_Sonic)
				{
					bit = hc.DAMAGE_TYPE_SONIC;
				}

				if (cb.Checked)
				{
					savetype |= bit;
				}
				else
					savetype &= ~bit;

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

				var rb = sender as RadioButton;
				if (rb != null)
				{
					if (rb == st_Excl_rbImmunity)
					{
						savetype &= ~hc.HENCH_IMMUNITY_WEIGHT_RESISTANCE; // 0x00100000
					}
					else //if (rb == st_Excl_Flags_rbResistance)
					{
						savetype |= hc.HENCH_IMMUNITY_WEIGHT_RESISTANCE;
					}
				}
				else
				{
					int bit;

					var cb = sender as CheckBox;
					if (cb == st_Excl_Onlyone)
					{
						bit = hc.HENCH_IMMUNITY_ONLY_ONE; // 0x00200000
					}
					else //if (cb == st_Excl_General)
					{
						bit = hc.HENCH_IMMUNITY_GENERAL; // 0x00400000
					}

					if (cb.Checked)
					{
						savetype |= bit;
					}
					else
						savetype &= ~bit;
				}

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
					st_Excl_Weight.SelectionStart = st_Excl_Weight.Text.Length;
				}
				else if (weight > 255) // 8 bits
				{
					weight = 255;
					st_Excl_Weight.Text = weight.ToString(); // re-trigger this funct.
					st_Excl_Weight.SelectionStart = st_Excl_Weight.Text.Length;
				}
				else
				{
					int savetype = Int32.Parse(SaveType_text.Text);
					savetype &= ~hc.HENCH_IMMUNITY_WEIGHT_AMOUNT_MASK; // 0x000ff000

					weight <<= HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT;
					SaveType_text.Text = (savetype | weight).ToString();
				}
			}
		}


		/// <summary>
		/// Sets the checkers on the SaveType page to reflect the current
		/// savetype value.
		/// </summary>
		/// <param name="savetype"></param>
		void CheckSaveTypeCheckers(int savetype)
		{
			int val;

// Type 1 Save radiobuttons
			val = (savetype & hc.HENCH_SPELL_SAVE_TYPE_SAVE1_WILL);
			st_Save1rb_none.Checked = (val == 0);
			st_Save1rb_fort.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_FORT);
			st_Save1rb_refl.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_REFLEX);
			st_Save1rb_will.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_WILL);

// Type 2 Save radiobuttons
			val = (savetype & hc.HENCH_SPELL_SAVE_TYPE_SAVE2_WILL);
			st_Save2rb_none.Checked = (val == 0);
			st_Save2rb_fort.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_FORT);
			st_Save2rb_refl.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_REFLEX);
			st_Save2rb_will.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_WILL);

// Type 1 Damage radiobuttons
			val = (savetype & hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION);
			st_Impact1rb_effectonly   .Checked = (val == 0);
			st_Impact1rb_damagehalf   .Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_HALF);
			st_Impact1rb_effectdamage .Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_EFFECT_DAMAGE);
			st_Impact1rb_damageevasion.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION);

// Type 2 Damage radiobuttons
			val = (savetype & hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION);
			st_Impact2rb_effectonly   .Checked = (val == 0);
			st_Impact2rb_damagehalf   .Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_HALF);
			st_Impact2rb_effectdamage .Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_EFFECT_DAMAGE);
			st_Impact2rb_damageevasion.Checked = (val == hc.HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION);

// General checkboxes
			st_SpellResistance  .Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_SR_FLAG)             != 0;
			st_MindAffecting    .Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG)     != 0;
			st_AffectsFriendlies.Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG) != 0;
			st_NotCaster        .Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG)        != 0;
			st_TouchMelee       .Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG)    != 0;
			st_TouchRanged      .Checked = (savetype & hc.HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG)    != 0;

// Specific dropdown-list
			val = savetype;
			val &= hc.HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK;
			if (val >= cbo_st_Specific.Items.Count)
			{
				val = -1;
				cbo_st_Specific.ForeColor = Color.Crimson;
			}
			else
				cbo_st_Specific.ForeColor = DefaultForeColor;

			cbo_st_Specific.SelectedIndex = val;

// Immunity1 dropdown-list
			val = savetype;
			val &= hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK;
			val >>= HENCH_SPELL_SAVE_TYPE_IMMUNITY1_SHIFT;
			if (val >= cbo_st_Immunity1.Items.Count)
			{
				val = -1;
				cbo_st_Immunity1.ForeColor = Color.Crimson;
			}
			else
				cbo_st_Immunity1.ForeColor = DefaultForeColor;

			cbo_st_Immunity1.SelectedIndex = val;

// Immunity2 dropdown-list
			val = savetype;
			val &= hc.HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK;
			val >>= HENCH_SPELL_SAVE_TYPE_IMMUNITY2_SHIFT;
			if (val >= cbo_st_Immunity2.Items.Count)
			{
				val = -1;
				cbo_st_Immunity2.ForeColor = Color.Crimson;
			}
			else
				cbo_st_Immunity2.ForeColor = DefaultForeColor;

			cbo_st_Immunity2.SelectedIndex = val;


// AcBonus dropdown-list
			val = savetype;
			val &= HENCH_SPELL_SAVE_TYPE_ACBONUS_MASK;
			val >>= HENCH_SPELL_SAVE_TYPE_ACBONUS_SHIFT;
			if (val >= cbo_st_AcBonus.Items.Count)
			{
				val = -1;
				cbo_st_AcBonus.ForeColor = Color.Crimson;
			}
			else
				cbo_st_AcBonus.ForeColor = DefaultForeColor;

			cbo_st_AcBonus.SelectedIndex = val;

// Weapon dropdown-list
			val = savetype;
			val &= 0x0001fff;

			if      ((savetype & hc.HENCH_WEAPON_STAFF_FLAG)  != 0) // 1
			{
				val = 1;
			}
			else if ((savetype & hc.HENCH_WEAPON_SLASH_FLAG)  != 0) // 2
			{
				val = 2;
			}
			else if ((savetype & hc.HENCH_WEAPON_HOLY_SWORD)  != 0) // 4
			{
				val = 3;
			}
			else if ((savetype & hc.HENCH_WEAPON_BLUNT_FLAG)  != 0) // 8
			{
				val = 4;
			}
			else if ((savetype & hc.HENCH_WEAPON_UNDEAD_FLAG) != 0) // 16
			{
				val = 5;
			}
			else if ((savetype & hc.HENCH_WEAPON_DRUID_FLAG)  != 0) // 4096
			{
				val = 6;
			}
			else if (val != 0) // ie. let val==0 fallthrough
			{
				val = -1;
				cbo_st_TargetRestriction.ForeColor = Color.Crimson;
			}

			if (val != -1)
			{
				cbo_st_TargetRestriction.ForeColor = DefaultForeColor;
			}

			cbo_st_TargetRestriction.SelectedIndex = val;

// Exclusive Group
// DamageType checkboxes
			st_Excl_Bludgeoning.Checked = (savetype & hc.DAMAGE_TYPE_BLUDGEONING) != 0;
			st_Excl_Piercing   .Checked = (savetype & hc.DAMAGE_TYPE_PIERCING)    != 0;
			st_Excl_Slashing   .Checked = (savetype & hc.DAMAGE_TYPE_SLASHING)    != 0;
			st_Excl_Magical    .Checked = (savetype & hc.DAMAGE_TYPE_MAGICAL)     != 0;
			st_Excl_Acid       .Checked = (savetype & hc.DAMAGE_TYPE_ACID)        != 0;
			st_Excl_Cold       .Checked = (savetype & hc.DAMAGE_TYPE_COLD)        != 0;
			st_Excl_Divine     .Checked = (savetype & hc.DAMAGE_TYPE_DIVINE)      != 0;
			st_Excl_Electrical .Checked = (savetype & hc.DAMAGE_TYPE_ELECTRICAL)  != 0;
			st_Excl_Fire       .Checked = (savetype & hc.DAMAGE_TYPE_FIRE)        != 0;
			st_Excl_Negative   .Checked = (savetype & hc.DAMAGE_TYPE_NEGATIVE)    != 0;
			st_Excl_Positive   .Checked = (savetype & hc.DAMAGE_TYPE_POSITIVE)    != 0;
			st_Excl_Sonic      .Checked = (savetype & hc.DAMAGE_TYPE_SONIC)       != 0;

// Flags radiobuttons
			bool isResist = (savetype & hc.HENCH_IMMUNITY_WEIGHT_RESISTANCE) != 0;
			st_Excl_rbImmunity  .Checked = !isResist;
			st_Excl_rbResistance.Checked =  isResist;

// Flags checkboxes
			st_Excl_Onlyone.Checked = (savetype & hc.HENCH_IMMUNITY_ONLY_ONE) != 0;
			st_Excl_General.Checked = (savetype & hc.HENCH_IMMUNITY_GENERAL)  != 0;

// Weight textbox
			val = (savetype & hc.HENCH_IMMUNITY_WEIGHT_AMOUNT_MASK); // 0x000ff000
			val >>= HENCH_IMMUNITY_WEIGHT_AMOUNT_SHIFT;
			st_Excl_Weight.Text = val.ToString();
		}
	}
}
