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


	// Functions for the DamageInfo page.
	partial class control_Spells
	{
		#region Fields (static)
		const int HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_SHIFT   =  8;
		const int HENCH_SPELL_INFO_BUFF_LEVEL_DIV_SHIFT     = 16;
		const int HENCH_SPELL_INFO_BUFF_LEVEL_DECR_SHIFT    = 20;

		const int HENCH_SPELL_INFO_DAMAGE_AMOUNT_SHIFT      = 12;
		const int HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_SHIFT = 20;
		const int HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_SHIFT   = 26;
		const int HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT_SHIFT = 24;
		#endregion Fields (static)


		#region eventhandlers
		/// <summary>
		/// Handles <c>TextChanged</c> event on the DamageInfo page.
		/// </summary>
		/// <param name="sender"><c><see cref="DamageInfo_text"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di(object sender, EventArgs e)
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

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				int differ;

				if (!he.BypassDiffer)
				{
					Spell spell = he.Spells[he.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clean)
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
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.damageinfo = damageinfo;

					spell.differ = SpellDiffer(spell, spellchanged);
					he.Spells[he.Id] = spell;

					Color color;
					if (spell.differ != bit_clean)
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
					_he.SetNodeColor(color);
				}

				he.PrintCurrent(damageinfo, DamageInfo_hex, DamageInfo_bin);

				differ = he.Spells[he.Id].differ;

				if ((differ & bit_damageinfo) != 0)
				{
					DamageInfo_reset.ForeColor = Color.Crimson;
				}
				else
					DamageInfo_reset.ForeColor = DefaultForeColor;

				state_DamageInfo(damageinfo);


				if (si_IsMaster.Checked)
				{
					// the 'si_Subspell3' textchanged handler can change the value
					// and shoot it back here
					si_Subspell3.Text = DamageInfo_text.Text;
				}
				else
				{
					// else let the value pass unhindered
					BypassSubspell = true;
					si_Subspell3.Text = DamageInfo_text.Text;
					BypassSubspell = false;
					SetSpellLabelText(si_SubspellLabel3, damageinfo);
				}


				_he.EnableApplys(differ != bit_clean);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's damageinfo.
		/// </summary>
		/// <param name="sender"><c><see cref="DamageInfo_reset"/></c></param>
		/// <param name="e"></param>
		/// <remarks>If the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.</remarks>
		void Click_di_reset(object sender, EventArgs e)
		{
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_damageinfo) != 0)
			{
				spell.differ &= ~bit_damageinfo;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clean)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				DamageInfo_reset.ForeColor = DefaultForeColor;

				DamageInfo_text.Text = spell.damageinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by combobox on the DamageInfo page -
		/// beneficial PowerBase group.
		/// </summary>
		/// <param name="sender"><c><see cref="di_co_BenPowerbase"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_co_ben_Powerbase(object sender, EventArgs e)
		{
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_MASK; // 0x0f000000 - clear specific bits

				int val;
				switch (di_co_BenPowerbase.SelectedIndex)
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
		/// Handles toggling bits by combobox on the DamageInfo page -
		/// beneficial LevelType group.
		/// </summary>
		/// <param name="sender"><c><see cref="di_co_BenLeveltype"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_co_ben_Leveltype(object sender, EventArgs e)
		{
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_MASK; // 0x0000c000 - clear specific bits

				int val;
				switch (di_co_BenLeveltype.SelectedIndex)
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
		/// Handles toggling bits by combobox on the DamageInfo page -
		/// detrimental DamageBase group.
		/// </summary>
		/// <param name="sender"><c><see cref="di_co_DetDamagebase"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_co_det_Damagebase(object sender, EventArgs e)
		{
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_MASK; // 0xf0000000 - clear specific bits

				int val;
				switch (di_co_DetDamagebase.SelectedIndex)
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
		/// Handles toggling bits by combobox on the DamageInfo page -
		/// detrimental LevelType group.
		/// </summary>
		/// <param name="sender"><c><see cref="di_co_DetLeveltype"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_di_co_det_Leveltype(object sender, EventArgs e)
		{
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				damageinfo &= ~hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_MASK; // 0x03000000 - clear specific bits - overlaps FixedCount

				int val;
				switch (di_co_DetLeveltype.SelectedIndex)
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
		/// Handles toggling bits by checkboxes on the DamageInfo page -
		/// DispelTypes group.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="di_Breach"/></c></item>
		/// <item><c><see cref="di_Dispel"/></c></item>
		/// <item><c><see cref="di_Resist"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_di_Dispeltype(object sender, MouseEventArgs e)
		{
			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				int bit;
				if (sender == di_Breach)
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_BREACH; // 0x00000001;
				}
				else if (sender == di_Dispel)
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_DISPEL; // 0x00000002;
				}
				else // sender == di_Resist
				{
					bit = hc.HENCH_SPELL_INFO_DAMAGE_RESIST; // 0x00000004;
				}

				if ((sender as CheckBox).Checked)
				{
					damageinfo |= bit;
				}
				else
					damageinfo &= ~bit;

				DamageInfo_text.Text = damageinfo.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the DamageInfo page -
		/// DamageTypes group.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="di_Magical"/></c></item>
		/// <item><c><see cref="di_Divine"/></c></item>
		/// <item><c><see cref="di_Acid"/></c></item>
		/// <item><c><see cref="di_Cold"/></c></item>
		/// <item><c><see cref="di_Electrical"/></c></item>
		/// <item><c><see cref="di_Fire"/></c></item>
		/// <item><c><see cref="di_Sonic"/></c></item>
		/// <item><c><see cref="di_Negative"/></c></item>
		/// <item><c><see cref="di_Positive"/></c></item>
		/// <item><c><see cref="di_Bludgeoning"/></c></item>
		/// <item><c><see cref="di_Piercing"/></c></item>
		/// <item><c><see cref="di_Slashing"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_di_det_Damagetype(object sender, MouseEventArgs e)
		{
			// checkboxes for DamageInfo - detrimental DamageTypes
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellDamage()
			// NOTE: These cases are considered in 'hench_i0_buff'   HenchGetEnergyImmunityWeight()
			// NOTE: These cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()

			int damageinfo;
			if (Int32.TryParse(DamageInfo_text.Text, out damageinfo))
			{
				// TODO: I think the CoreAI can deal with only (max) 2 DamageTypes ...
				// If so then implement a routine that deselects a Type if a 3rd is clicked.

				int bit;
				if (sender == di_Bludgeoning)
				{
					bit = hc.DAMAGE_TYPE_BLUDGEONING;
				}
				else if (sender == di_Piercing)
				{
					bit = hc.DAMAGE_TYPE_PIERCING;
				}
				else if (sender == di_Slashing)
				{
					bit = hc.DAMAGE_TYPE_SLASHING;
				}
				else if (sender == di_Magical)
				{
					bit = hc.DAMAGE_TYPE_MAGICAL;
				}
				else if (sender == di_Acid)
				{
					bit = hc.DAMAGE_TYPE_ACID;
				}
				else if (sender == di_Cold)
				{
					bit = hc.DAMAGE_TYPE_COLD;
				}
				else if (sender == di_Divine)
				{
					bit = hc.DAMAGE_TYPE_DIVINE;
				}
				else if (sender == di_Electrical)
				{
					bit = hc.DAMAGE_TYPE_ELECTRICAL;
				}
				else if (sender == di_Fire)
				{
					bit = hc.DAMAGE_TYPE_FIRE;
				}
				else if (sender == di_Negative)
				{
					bit = hc.DAMAGE_TYPE_NEGATIVE;
				}
				else if (sender == di_Positive)
				{
					bit = hc.DAMAGE_TYPE_POSITIVE;
				}
				else // sender == di_Sonic
				{
					bit = hc.DAMAGE_TYPE_SONIC;
				}

				if ((sender as CheckBox).Checked)
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
		/// <param name="sender"><c><see cref="di_BenPower"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Power(object sender, EventArgs e)
		{
			int power;
			if (Int32.TryParse(di_BenPower.Text, out power))
			{
				if (power < 0)
				{
					di_BenPower.Text = "0"; // recurse this funct.
					di_BenPower.SelectionStart = di_BenPower.Text.Length;
				}
				else if (power > 255) // 8 bits
				{
					di_BenPower.Text = "255"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_BenLevellimit"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Levellimit(object sender, EventArgs e)
		{
			int levellimit;
			if (Int32.TryParse(di_BenLevellimit.Text, out levellimit))
			{
				if (levellimit < 0)
				{
					di_BenLevellimit.Text = "0"; // recurse this funct.
					di_BenLevellimit.SelectionStart = di_BenLevellimit.Text.Length;
				}
				else if (levellimit > 63) // 6 bits
				{
					di_BenLevellimit.Text = "63"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_BenLeveldivisor"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Leveldivisor(object sender, EventArgs e)
		{
			int leveldivisor;
			if (Int32.TryParse(di_BenLeveldivisor.Text, out leveldivisor))
			{
				if (leveldivisor < 0)
				{
					di_BenLeveldivisor.Text = "0"; // recurse this funct.
					di_BenLeveldivisor.SelectionStart = di_BenLeveldivisor.Text.Length;
				}
				else if (leveldivisor > 15) // 4 bits
				{
					di_BenLeveldivisor.Text = "15"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_BenLeveldecrease"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_ben_Leveldecrease(object sender, EventArgs e)
		{
			int leveldecrease;
			if (Int32.TryParse(di_BenLeveldecrease.Text, out leveldecrease))
			{
				if (leveldecrease < 0)
				{
					di_BenLeveldecrease.Text = "0"; // recurse this funct.
					di_BenLeveldecrease.SelectionStart = di_BenLeveldecrease.Text.Length;
				}
				else if (leveldecrease > 15) // 4 bits
				{
					di_BenLeveldecrease.Text = "15"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_DetDamage"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Damage(object sender, EventArgs e)
		{
			int damage;
			if (Int32.TryParse(di_DetDamage.Text, out damage))
			{
				if (damage < 0)
				{
					di_DetDamage.Text = "0"; // recurse this funct.
					di_DetDamage.SelectionStart = di_DetDamage.Text.Length;
				}
				else if (damage > 255) // 8 bits
				{
					di_DetDamage.Text = "255"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_DetLevellimit"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Levellimit(object sender, EventArgs e)
		{
			int levellimit;
			if (Int32.TryParse(di_DetLevellimit.Text, out levellimit))
			{
				if (levellimit < 0)
				{
					di_DetLevellimit.Text = "0"; // recurse this funct.
					di_DetLevellimit.SelectionStart = di_DetLevellimit.Text.Length;
				}
				else if (levellimit > 15) // 4 bits
				{
					di_DetLevellimit.Text = "15"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_DetLeveldivisor"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Leveldivisor(object sender, EventArgs e)
		{
			int leveldivisor;
			if (Int32.TryParse(di_DetLeveldivisor.Text, out leveldivisor))
			{
				if (leveldivisor < 0)
				{
					di_DetLeveldivisor.Text = "0"; // recurse this funct.
					di_DetLeveldivisor.SelectionStart = di_DetLeveldivisor.Text.Length;
				}
				else if (leveldivisor > 3) // 2 bits
				{
					di_DetLeveldivisor.Text = "3"; // recurse this funct.
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
		/// <param name="sender"><c><see cref="di_DetFixedcount"/></c></param>
		/// <param name="e"></param>
		void TextChanged_di_det_Fixedcount(object sender, EventArgs e)
		{
			int fixedcount;
			if (Int32.TryParse(di_DetFixedcount.Text, out fixedcount))
			{
				if (fixedcount < 0)
				{
					di_DetFixedcount.Text = "0"; // recurse this funct.
					di_DetFixedcount.SelectionStart = di_DetFixedcount.Text.Length;
				}
				else if (fixedcount > 15) // 4 bits
				{
					di_DetFixedcount.Text = "15"; // recurse this funct.
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
		#endregion eventhandlers


		#region setstate
		/// <summary>
		/// Sets the checkers on the DamageInfo page to reflect the current
		/// damageinfo value.
		/// </summary>
		/// <param name="damageinfo"></param>
		void state_DamageInfo(int damageinfo)
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
				case 0:                                     val = 0; break;
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

			if (val >= di_co_BenPowerbase.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				di_co_BenPowerbase.ForeColor = Color.Crimson;
			}
			else
				di_co_BenPowerbase.ForeColor = DefaultForeColor;

			di_co_BenPowerbase.SelectedIndex = val;

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

			if (val >= di_co_BenLeveltype.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				di_co_BenLeveltype.ForeColor = Color.Crimson;
			}
			else
				di_co_BenLeveltype.ForeColor = DefaultForeColor;

			di_co_BenLeveltype.SelectedIndex = val;

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

			if (val >= di_co_DetDamagebase.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				di_co_DetDamagebase.ForeColor = Color.Crimson;
			}
			else
				di_co_DetDamagebase.ForeColor = DefaultForeColor;

			di_co_DetDamagebase.SelectedIndex = val;

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

			if (val >= di_co_DetLeveltype.Items.Count)
			{
				val = -1;
			}

			if (val == -1)
			{
				di_co_DetLeveltype.ForeColor = Color.Crimson;
			}
			else
				di_co_DetLeveltype.ForeColor = DefaultForeColor;

			di_co_DetLeveltype.SelectedIndex = val;

// ben Power texbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_AMOUNT_MASK);			// 0x000000ff
			di_BenPower.Text = val.ToString();

// ben LevelLimit textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_MASK)		// 0x00003f00
								>> HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_SHIFT;
			di_BenLevellimit.Text = val.ToString();

// ben LevelDivisor textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_DIV_MASK)		// 0x000f0000
								>> HENCH_SPELL_INFO_BUFF_LEVEL_DIV_SHIFT;
			di_BenLeveldivisor.Text = val.ToString();

// ben LevelDecrease textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_BUFF_LEVEL_DECR_MASK)		// 0x00f00000
								>> HENCH_SPELL_INFO_BUFF_LEVEL_DECR_SHIFT;
			di_BenLeveldecrease.Text = val.ToString();

// det Damage textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_AMOUNT_MASK)			// 0x000ff000
								>> HENCH_SPELL_INFO_DAMAGE_AMOUNT_SHIFT;
			di_DetDamage.Text = val.ToString();

// det LevelLimit textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_MASK)	// 0x00f00000
								>> HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_SHIFT;
			di_DetLevellimit.Text = val.ToString();

// det LevelDivisor textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_MASK)		// 0x0c000000 - overlaps FixedCount
								>> HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_SHIFT;
			di_DetLeveldivisor.Text = val.ToString();

// det FixedCount textbox
			val = (damageinfo & hc.HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT)			// 0x0f000000 - overlaps LevelType and LevelDivisor
								>> HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT_SHIFT;
			di_DetFixedcount.Text = val.ToString();

			// test ->
			int roguebits = (damageinfo & ~di_legitbits);
			if (roguebits != 0)
			{
				di_RogueBits.Text = roguebits.ToString("X8");
				di_RogueBits   .Visible =
				di_la_RogueBits.Visible = true;
			}
			else
				di_RogueBits   .Visible =
				di_la_RogueBits.Visible = false;
		}

		const int di_legitbits = hc.HENCH_SPELL_INFO_DAMAGE_BREACH				// 0x00000001 // all bits are legal -> (which are illegal depends on spelltype etc.)
							   | hc.HENCH_SPELL_INFO_DAMAGE_DISPEL				// 0x00000002
							   | hc.HENCH_SPELL_INFO_DAMAGE_RESIST				// 0x00000004

							   | hc.DAMAGE_TYPE_BLUDGEONING						// 0x00000001
							   | hc.DAMAGE_TYPE_PIERCING						// 0x00000002
							   | hc.DAMAGE_TYPE_SLASHING						// 0x00000004
							   | hc.DAMAGE_TYPE_MAGICAL							// 0x00000008
							   | hc.DAMAGE_TYPE_ACID							// 0x00000010
							   | hc.DAMAGE_TYPE_COLD							// 0x00000020
							   | hc.DAMAGE_TYPE_DIVINE							// 0x00000040
							   | hc.DAMAGE_TYPE_ELECTRICAL						// 0x00000080
							   | hc.DAMAGE_TYPE_FIRE							// 0x00000100
							   | hc.DAMAGE_TYPE_NEGATIVE						// 0x00000200
							   | hc.DAMAGE_TYPE_POSITIVE						// 0x00000400
							   | hc.DAMAGE_TYPE_SONIC							// 0x00000800

							   | hc.HENCH_SPELL_INFO_DAMAGE_AMOUNT_MASK			// 0x000ff000
							   | hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_MASK	// 0x00f00000
							   | hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_MASK		// 0x03000000
							   | hc.HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_MASK		// 0x0c000000
							   | hc.HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT			// 0x0f000000
							   | hc.HENCH_SPELL_INFO_DAMAGE_MASK				// 0xf0000000

							   | hc.HENCH_SPELL_INFO_BUFF_AMOUNT_MASK			// 0x000000ff
							   | hc.HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_MASK		// 0x00003f00
																				// 0x0000c000 <-
							   | hc.HENCH_SPELL_INFO_BUFF_LEVEL_DIV_MASK		// 0x000f0000
							   | hc.HENCH_SPELL_INFO_BUFF_LEVEL_DECR_MASK		// 0x00f00000
							   | hc.HENCH_SPELL_INFO_BUFF_MASK;					// 0x0f000000
		#endregion setstate
	}
}
