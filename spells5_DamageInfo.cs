using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// TODO:
	//
	// If spell uses an AttributeType then damageinfo will contain only the AttributeTypeBonus power.
	// SpellInfo SpellType - hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTR_BUFF
	// eg. HenchCheckAttributeBuff() 'hench_i0_buff'
	//
	// If spell uses a DamageType then damageinfo will contain only the DamageType nwscript-constant.
	// SpellInfo SpellType - hc.HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
	// eg. HenchCheckWeaponBuff() 'hench_i0_buff


	/// <summary>
	/// Functions for the DamageInfo page.
	/// </summary>
	partial class tabcontrol_Spells
	{
		const int HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_SHIFT   =  8;
		const int HENCH_SPELL_INFO_BUFF_LEVEL_DIV_SHIFT     = 16;
		const int HENCH_SPELL_INFO_BUFF_LEVEL_DECR_SHIFT    = 20;

		const int HENCH_SPELL_INFO_DAMAGE_AMOUNT_SHIFT      = 12;
		const int HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_SHIFT = 20;
		const int HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_SHIFT   = 26;
		const int HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT_SHIFT = 24;

		/// <summary>
		/// Handles TextChanged event on the DamageInfo page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_di() bypassTextChanged= " + bypassTextChanged);

			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields. Technically however
			// this does not need to go through creating and deleting each
			// SpellChanged-struct (since nothing has changed yet OnLoad of the
			// 2da-file)
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
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
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.damageinfo = damageinfo;

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

				MainForm.PrintCurrent(damageinfo, DamageInfo_hex, DamageInfo_bin);

				differ = MainForm.Spells[MainForm.Id].differ;

				if ((differ & bit_damageinfo) != 0)
				{
					DamageInfo_reset.ForeColor = Color.Crimson;
				}
				else
					DamageInfo_reset.ForeColor = DefaultForeColor;

				CheckDamageInfoCheckers(damageinfo);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					// But it does clamp the value before it gets shot back here.
					si_Child3.Text = DamageInfo_text.Text;
				}

				MainForm.that.SetEnabled(differ != bit_clear);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's damageinfo.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_di_reset(object sender, EventArgs e)
		{
			Spell spell = MainForm.Spells[MainForm.Id];
			if ((spell.differ & bit_damageinfo) != 0)
			{
				spell.differ &= ~bit_damageinfo;
				MainForm.Spells[MainForm.Id] = spell;

				if (spell.differ == bit_clear)
				{
					MainForm.SpellsChanged.Remove(MainForm.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;
					MainForm.that.SetNodeColor(color);
				}

				DamageInfo_reset.ForeColor = DefaultForeColor;

				DamageInfo_text.Text = spell.damageinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by combobox on the DamageInfo page - beneficial PowerBase group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_cbo_ben_Powerbase(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_di_cbo_ben_Powerbase() selectedId= " + cbo_di_BenPowerbase.SelectedIndex);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_MASK; // 0x0f000000 - clear specific bits

				int val;
				switch (cbo_di_BenPowerbase.SelectedIndex)
				{
					// TODO: case -1 for all comboboxes in the editor.

					default: val = 0;                                  break;
					case 1:  val = hc.HENCH_SPELL_INFO_BUFF_CASTER_LEVEL; break; // 0x01000000
					case 2:  val = hc.HENCH_SPELL_INFO_BUFF_HD_LEVEL;     break; // 0x02000000
					case 3:  val = hc.HENCH_SPELL_INFO_BUFF_FIXED;        break; // 0x03000000
					case 4:  val = hc.HENCH_SPELL_INFO_BUFF_CHARISMA;     break; // 0x0b000000
					case 5:  val = hc.HENCH_SPELL_INFO_BUFF_BARD_LEVEL;   break; // 0x0c000000 - not used in CoreAI.
					case 6:  val = hc.HENCH_SPELL_INFO_BUFF_DRAGON;       break; // 0x0d000000
				}
				DamageInfo_text.Text = (damageinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the DamageInfo page - beneficial LevelType group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_cbo_ben_Leveltype(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_di_cbo_ben_Leveltype() selectedId= " + cbo_di_BenLeveltype.SelectedIndex);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_MASK; // 0x0000c000 - clear specific bits

				int val;
				switch (cbo_di_BenLeveltype.SelectedIndex)
				{
					default: val = hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_DICE;  break; // 0x00000000
					case 1:  val = hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_ADJ;   break; // 0x00004000
					case 2:  val = hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_COUNT; break; // 0x00008000 - not used in CoreAI.
					case 3:  val = hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_CONST; break; // 0x0000c000
				}
				DamageInfo_text.Text = (damageinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the DamageInfo page - detrimental DamageBase group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_cbo_det_Damagebase(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_di_cbo_det_Damagebase() selectedId= " + cbo_di_DetDamagebase.SelectedIndex);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_MASK; // 0xf0000000 - clear specific bits

				int val;
				switch (cbo_di_DetDamagebase.SelectedIndex)
				{
					default: val = hc.HENCH_SPELL_INFO_DAMAGE_CASTER_LEVEL;  break; // 0x00000000
					case  1: val = hc.HENCH_SPELL_INFO_DAMAGE_HD_LEVEL;      break; // 0x10000000
					case  2: val = hc.HENCH_SPELL_INFO_DAMAGE_FIXED;         break; // 0x20000000
					case  3: val = hc.HENCH_SPELL_INFO_DAMAGE_CURE;          break; // 0x30000000
					case  4: val = hc.HENCH_SPELL_INFO_DAMAGE_DRAGON;        break; // 0x40000000
					case  5: val = hc.HENCH_SPELL_INFO_DAMAGE_SPECIAL_COUNT; break; // 0x50000000
					case  6: val = hc.HENCH_SPELL_INFO_DAMAGE_CUSTOM;        break; // 0x60000000
					case  7: val = hc.HENCH_SPELL_INFO_DAMAGE_DRAG_DISC;     break; // 0x70000000
					case  8: val = hc.HENCH_SPELL_INFO_DAMAGE_AA_LEVEL;      break; // 0x80000000
					case  9: val = hc.HENCH_SPELL_INFO_DAMAGE_WP_LEVEL;      break; // 0x90000000 - not used in CoreAI.
					case 10: val = hc.HENCH_SPELL_INFO_DAMAGE_LAY_ON_HANDS;  break; // 0xa0000000
					case 11: val = hc.HENCH_SPELL_INFO_DAMAGE_CHARISMA;      break; // 0xb0000000
					case 12: val = hc.HENCH_SPELL_INFO_DAMAGE_BARD_PERFORM;  break; // 0xc0000000
					case 13: val = hc.HENCH_SPELL_INFO_DAMAGE_WARLOCK;       break; // 0xd0000000
				}
				DamageInfo_text.Text = (damageinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the DamageInfo page - detrimental LevelType group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_cbo_det_Leveltype(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_di_cbo_det_Leveltype() selectedId= " + cbo_di_DetLeveltype.SelectedIndex);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_MASK; // 0x03000000 - clear specific bits - overlaps FixedCount

				int val;
				switch (cbo_di_DetLeveltype.SelectedIndex)
				{
					default: val = hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_DICE;  break; // 0x00000000
					case 1:  val = hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_ADJ;   break; // 0x01000000
					case 2:  val = hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_COUNT; break; // 0x02000000
					case 3:  val = hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_CONST; break; // 0x03000000
				}
				DamageInfo_text.Text = (damageinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the DamageInfo page - DispelTypes group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_di_Dispeltype(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_di_Dispeltype()");
			//logfile.Log(". text= " + DamageInfo_text.Text);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				//logfile.Log(". . is valid Int32= " + damageinfo);

				int bit;

				var cb = sender as CheckBox;
				if (cb == di_Breach)
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_BREACH; // 0x00000001;
				}
				else if (cb == di_Dispel)
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_DISPEL; // 0x00000002;
				}
				else //if (cb == di_Resist)
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_RESIST; // 0x00000004;
				}

				if (cb.Checked)
				{
					damageinfo |= bit;
				}
				else
					damageinfo &= ~bit;

				DamageInfo_text.Text = damageinfo.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the DamageInfo page - DamageTypes group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_di_det_Damagetype(object sender, MouseEventArgs e)
		{
			// checkboxes for DamageInfo - detrimental DamageTypes
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellDamage()
			// NOTE: These cases are considered in 'hench_i0_buff'   HenchGetEnergyImmunityWeight()
			// NOTE: These cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()

			//logfile.Log("MouseClick_di_Damagetype()");
			//logfile.Log(". text= " + DamageInfo_text.Text);

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				//logfile.Log(". . is valid Int32= " + damageinfo);

				// TODO: I think the CoreAI can deal with only (max) 2 DamageTypes ...
				// If so then implement a routine that deselects a Type if a 3rd is clicked.

				int bit;

				var cb = sender as CheckBox;
				if (cb == di_Bludgeoning)
				{
					bit = hc.DAMAGE_TYPE_BLUDGEONING;
				}
				else if (cb == di_Piercing)
				{
					bit = hc.DAMAGE_TYPE_PIERCING;
				}
				else if (cb == di_Slashing)
				{
					bit = hc.DAMAGE_TYPE_SLASHING;
				}
				else if (cb == di_Magical)
				{
					bit = hc.DAMAGE_TYPE_MAGICAL;
				}
				else if (cb == di_Acid)
				{
					bit = hc.DAMAGE_TYPE_ACID;
				}
				else if (cb == di_Cold)
				{
					bit = hc.DAMAGE_TYPE_COLD;
				}
				else if (cb == di_Divine)
				{
					bit = hc.DAMAGE_TYPE_DIVINE;
				}
				else if (cb == di_Electrical)
				{
					bit = hc.DAMAGE_TYPE_ELECTRICAL;
				}
				else if (cb == di_Fire)
				{
					bit = hc.DAMAGE_TYPE_FIRE;
				}
				else if (cb == di_Negative)
				{
					bit = hc.DAMAGE_TYPE_NEGATIVE;
				}
				else if (cb == di_Positive)
				{
					bit = hc.DAMAGE_TYPE_POSITIVE;
				}
				else //if (cb == di_Sonic)
				{
					bit = hc.DAMAGE_TYPE_SONIC;
				}

				if (cb.Checked)
				{
					damageinfo |= bit;
				}
				else
					damageinfo &= ~bit;

				DamageInfo_text.Text = damageinfo.ToString();
			}
		}

		/// <summary>
		/// Handles changing beneficial Power in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Power(object sender, EventArgs e)
		{
			int power;
			if (Int32.TryParse(di_BenPower.Text, out power))
			{
				if (power < 0)
				{
					power = 0;
					di_BenPower.Text = power.ToString(); // re-trigger this funct.
					di_BenPower.SelectionStart = di_BenPower.Text.Length;
				}
				else if (power > 255) // 8 bits
				{
					power = 255;
					di_BenPower.Text = power.ToString(); // re-trigger this funct.
					di_BenPower.SelectionStart = di_BenPower.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_AMOUNT_MASK; // 0x000000ff

					DamageInfo_text.Text = (damageinfo | power).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing beneficial LevelLimit in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Levellimit(object sender, EventArgs e)
		{
			int levellimit;
			if (Int32.TryParse(di_BenLevellimit.Text, out levellimit))
			{
				if (levellimit < 0)
				{
					levellimit = 0;
					di_BenLevellimit.Text = levellimit.ToString(); // re-trigger this funct.
					di_BenLevellimit.SelectionStart = di_BenLevellimit.Text.Length;
				}
				else if (levellimit > 63) // 6 bits
				{
					levellimit = 63;
					di_BenLevellimit.Text = levellimit.ToString(); // re-trigger this funct.
					di_BenLevellimit.SelectionStart = di_BenLevellimit.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_MASK; // 0x00003f00

					levellimit <<= HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_SHIFT;
					DamageInfo_text.Text = (damageinfo | levellimit).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing beneficial LevelDivisor in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Leveldivisor(object sender, EventArgs e)
		{
			int leveldivisor;
			if (Int32.TryParse(di_BenLeveldivisor.Text, out leveldivisor))
			{
				if (leveldivisor < 0)
				{
					leveldivisor = 0;
					di_BenLeveldivisor.Text = leveldivisor.ToString(); // re-trigger this funct.
					di_BenLeveldivisor.SelectionStart = di_BenLeveldivisor.Text.Length;
				}
				else if (leveldivisor > 15) // 4 bits
				{
					leveldivisor = 15;
					di_BenLeveldivisor.Text = leveldivisor.ToString(); // re-trigger this funct.
					di_BenLeveldivisor.SelectionStart = di_BenLeveldivisor.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_LEVEL_DIV_MASK; // 0x000f0000

					leveldivisor <<= HENCH_SPELL_INFO_BUFF_LEVEL_DIV_SHIFT;
					DamageInfo_text.Text = (damageinfo | leveldivisor).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing beneficial LevelDecrease in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Leveldecrease(object sender, EventArgs e)
		{
			int leveldecrease;
			if (Int32.TryParse(di_BenLeveldecrease.Text, out leveldecrease))
			{
				if (leveldecrease < 0)
				{
					leveldecrease = 0;
					di_BenLeveldecrease.Text = leveldecrease.ToString(); // re-trigger this funct.
					di_BenLeveldecrease.SelectionStart = di_BenLeveldecrease.Text.Length;
				}
				else if (leveldecrease > 15) // 4 bits
				{
					leveldecrease = 15;
					di_BenLeveldecrease.Text = leveldecrease.ToString(); // re-trigger this funct.
					di_BenLeveldecrease.SelectionStart = di_BenLeveldecrease.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_LEVEL_DECR_MASK; // 0x00f00000

					leveldecrease <<= HENCH_SPELL_INFO_BUFF_LEVEL_DECR_SHIFT;
					DamageInfo_text.Text = (damageinfo | leveldecrease).ToString();
				}
			}
		}


		/// <summary>
		/// Handles changing detrimental Damage in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Damage(object sender, EventArgs e)
		{
			int damage;
			if (Int32.TryParse(di_DetDamage.Text, out damage))
			{
				if (damage < 0)
				{
					damage = 0;
					di_DetDamage.Text = damage.ToString(); // re-trigger this funct.
					di_DetDamage.SelectionStart = di_DetDamage.Text.Length;
				}
				else if (damage > 255) // 8 bits
				{
					damage = 255;
					di_DetDamage.Text = damage.ToString(); // re-trigger this funct.
					di_DetDamage.SelectionStart = di_DetDamage.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_AMOUNT_MASK; // 0x000ff000

					damage <<= HENCH_SPELL_INFO_DAMAGE_AMOUNT_SHIFT;
					DamageInfo_text.Text = (damageinfo | damage).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing detrimental LevelLimit in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Levellimit(object sender, EventArgs e)
		{
			int levellimit;
			if (Int32.TryParse(di_DetLevellimit.Text, out levellimit))
			{
				if (levellimit < 0)
				{
					levellimit = 0;
					di_DetLevellimit.Text = levellimit.ToString(); // re-trigger this funct.
					di_DetLevellimit.SelectionStart = di_DetLevellimit.Text.Length;
				}
				else if (levellimit > 15) // 4 bits
				{
					levellimit = 15;
					di_DetLevellimit.Text = levellimit.ToString(); // re-trigger this funct.
					di_DetLevellimit.SelectionStart = di_DetLevellimit.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_MASK; // 0x00f00000

					levellimit <<= HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_SHIFT;
					DamageInfo_text.Text = (damageinfo | levellimit).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing detrimental LevelDivisor in its textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Leveldivisor(object sender, EventArgs e)
		{
			int leveldivisor;
			if (Int32.TryParse(di_DetLeveldivisor.Text, out leveldivisor))
			{
				if (leveldivisor < 0)
				{
					leveldivisor = 0;
					di_DetLeveldivisor.Text = leveldivisor.ToString(); // re-trigger this funct.
					di_DetLeveldivisor.SelectionStart = di_DetLeveldivisor.Text.Length;
				}
				else if (leveldivisor > 3) // 2 bits
				{
					leveldivisor = 3;
					di_DetLeveldivisor.Text = leveldivisor.ToString(); // re-trigger this funct.
					di_DetLeveldivisor.SelectionStart = di_DetLeveldivisor.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_MASK; // 0x0c000000 - overlaps FixedCount

					leveldivisor <<= HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_SHIFT;
					DamageInfo_text.Text = (damageinfo | leveldivisor).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing detrimental FixedCount in its textbox.
		/// WARNING: These bits overlap detrimental LevelType and LevelDivisor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Fixedcount(object sender, EventArgs e)
		{
			int fixedcount;
			if (Int32.TryParse(di_DetFixedcount.Text, out fixedcount))
			{
				if (fixedcount < 0)
				{
					fixedcount = 0;
					di_DetFixedcount.Text = fixedcount.ToString(); // re-trigger this funct.
					di_DetFixedcount.SelectionStart = di_DetFixedcount.Text.Length;
				}
				else if (fixedcount > 15) // 4 bits
				{
					fixedcount = 15;
					di_DetFixedcount.Text = fixedcount.ToString(); // re-trigger this funct.
					di_DetFixedcount.SelectionStart = di_DetFixedcount.Text.Length;
				}
				else
				{
					int damageinfo = Int32.Parse(DamageInfo_text.Text);
					damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT; // 0x0f000000 - overlaps LevelType and LevelDivisor

					fixedcount <<= HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT_SHIFT;
					DamageInfo_text.Text = (damageinfo | fixedcount).ToString();
				}
			}
		}


		/// <summary>
		/// Sets the checkers on the DamageInfo page to reflect the current
		/// damageinfo value.
		/// </summary>
		/// <param name="damageinfo"></param>
		void CheckDamageInfoCheckers(int damageinfo)
		{
// DispelTypes checkboxes
			di_Breach.Checked = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_BREACH) != 0;
			di_Dispel.Checked = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_DISPEL) != 0;
			di_Resist.Checked = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_RESIST) != 0;

// DamageTypes checkboxes
			di_Bludgeoning.Checked = (damageinfo & hc.DAMAGE_TYPE_BLUDGEONING) != 0;
			di_Piercing   .Checked = (damageinfo & hc.DAMAGE_TYPE_PIERCING)    != 0;
			di_Slashing   .Checked = (damageinfo & hc.DAMAGE_TYPE_SLASHING)    != 0;
			di_Magical    .Checked = (damageinfo & hc.DAMAGE_TYPE_MAGICAL)     != 0;
			di_Acid       .Checked = (damageinfo & hc.DAMAGE_TYPE_ACID)        != 0;
			di_Cold       .Checked = (damageinfo & hc.DAMAGE_TYPE_COLD)        != 0;
			di_Divine     .Checked = (damageinfo & hc.DAMAGE_TYPE_DIVINE)      != 0;
			di_Electrical .Checked = (damageinfo & hc.DAMAGE_TYPE_ELECTRICAL)  != 0;
			di_Fire       .Checked = (damageinfo & hc.DAMAGE_TYPE_FIRE)        != 0;
			di_Negative   .Checked = (damageinfo & hc.DAMAGE_TYPE_NEGATIVE)    != 0;
			di_Positive   .Checked = (damageinfo & hc.DAMAGE_TYPE_POSITIVE)    != 0;
			di_Sonic      .Checked = (damageinfo & hc.DAMAGE_TYPE_SONIC)       != 0;

			int val;

// beneficial PowerBase dropdown
			switch (damageinfo & hc.HENCH_SPELL_INFO_BUFF_MASK) // 0x0f000000
			{
				case 0:                                  val = 0; break;
				case hc.HENCH_SPELL_INFO_BUFF_CASTER_LEVEL: val = 1; break;
				case hc.HENCH_SPELL_INFO_BUFF_HD_LEVEL:     val = 2; break;
				case hc.HENCH_SPELL_INFO_BUFF_FIXED:        val = 3; break;
				case hc.HENCH_SPELL_INFO_BUFF_CHARISMA:     val = 4; break;
				case hc.HENCH_SPELL_INFO_BUFF_BARD_LEVEL:   val = 5; break; // not used in CoreAI.
				case hc.HENCH_SPELL_INFO_BUFF_DRAGON:       val = 6; break;

				default:
					val = -1;
					break;
			}

			if (val >= cbo_di_BenPowerbase.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				cbo_di_BenPowerbase.ForeColor = Color.Crimson;
			}
			else
				cbo_di_BenPowerbase.ForeColor = DefaultForeColor;

			cbo_di_BenPowerbase.SelectedIndex = val;

// beneficial LevelType dropdown
			switch (val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_MASK)) // 0x0000c000
			{
				case hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_DICE:  val = 0; break;
				case hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_ADJ:   val = 1; break;
				case hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_COUNT: val = 2; break; // not used in CoreAI.
				case hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_CONST: val = 3; break;

				default:
					val = -1;
					break;
			}

			if (val >= cbo_di_BenLeveltype.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				cbo_di_BenLeveltype.ForeColor = Color.Crimson;
			}
			else
				cbo_di_BenLeveltype.ForeColor = DefaultForeColor;

			cbo_di_BenLeveltype.SelectedIndex = val;

// detrimental DamageBase dropdown
			switch (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_MASK) // 0xf0000000
			{
				case hc.HENCH_SPELL_INFO_DAMAGE_CASTER_LEVEL:  val =  0; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_HD_LEVEL:      val =  1; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_FIXED:         val =  2; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_CURE:          val =  3; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_DRAGON:        val =  4; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_SPECIAL_COUNT: val =  5; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_CUSTOM:        val =  6; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_DRAG_DISC:     val =  7; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_AA_LEVEL:      val =  8; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_WP_LEVEL:      val =  9; break; // not used in CoreAI.
				case hc.HENCH_SPELL_INFO_DAMAGE_LAY_ON_HANDS:  val = 10; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_CHARISMA:      val = 11; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_BARD_PERFORM:  val = 12; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_WARLOCK:       val = 13; break;

				default:
					val = -1;
					break;
			}

			if (val >= cbo_di_DetDamagebase.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				cbo_di_DetDamagebase.ForeColor = Color.Crimson;
			}
			else
				cbo_di_DetDamagebase.ForeColor = DefaultForeColor;

			cbo_di_DetDamagebase.SelectedIndex = val;

// detrimental LevelType dropdown
			switch (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_MASK) // 0x03000000 - overlaps FixedCount
			{
				case hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_DICE:  val = 0; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_ADJ:   val = 1; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_COUNT: val = 2; break;
				case hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_CONST: val = 3; break;

				default:
					val = -1;
					break;
			}

			if (val >= cbo_di_DetLeveltype.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				cbo_di_DetLeveltype.ForeColor = Color.Crimson;
			}
			else
				cbo_di_DetLeveltype.ForeColor = DefaultForeColor;

			cbo_di_DetLeveltype.SelectedIndex = val;

// ben Power texbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_AMOUNT_MASK);			// 0x000000ff
			di_BenPower.Text = val.ToString();

// ben LevelLimit textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_MASK);	// 0x00003f00
			val >>= HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_SHIFT;
			di_BenLevellimit.Text = val.ToString();

// ben LevelDivisor textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_DIV_MASK);		// 0x000f0000
			val >>= HENCH_SPELL_INFO_BUFF_LEVEL_DIV_SHIFT;
			di_BenLeveldivisor.Text = val.ToString();

// ben LevelDecrease textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_DECR_MASK);		// 0x00f00000
			val >>= HENCH_SPELL_INFO_BUFF_LEVEL_DECR_SHIFT;
			di_BenLeveldecrease.Text = val.ToString();

// det Damage textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_AMOUNT_MASK);		// 0x000ff000
			val >>= HENCH_SPELL_INFO_DAMAGE_AMOUNT_SHIFT;
			di_DetDamage.Text = val.ToString();

// det LevelLimit textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_MASK);	// 0x00f00000
			val >>= HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_SHIFT;
			di_DetLevellimit.Text = val.ToString();

// det LevelDivisor textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_MASK);	// 0x0c000000 - overlaps FixedCount
			val >>= HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_SHIFT;
			di_DetLeveldivisor.Text = val.ToString();

// det FixedCount textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT);		// 0x0f000000 - overlaps LevelType and LevelDivisor
			val >>= HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT_SHIFT;
			di_DetFixedcount.Text = val.ToString();
		}
	}
}
