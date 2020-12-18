﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SpellInfo page.
	/// </summary>
	partial class tabcontrol_Spells
	{
		/// <summary>
		/// Handles TextChanged event on the SpellInfo page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_si(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_si() bypassTextChanged= " + bypassTextChanged);

			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields. Technically however
			// this does not need to go through creating and deleting each
			// SpellChanged-struct (since nothing has changed yet OnLoad of the
			// 2da-file)
			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				int differ;

				if (!MainForm.BypassDiffer)
				{
					// ensure that spellinfo has a CoreAI version
					// although strictly speaking I believe that GetSpellInfo()
					// will gracefully handle spell-data that has no version set.
					if (!MainForm.BypassInfoVersion && spellinfo != 0)
					{
						int ver = (spellinfo & hc.HENCH_SPELL_INFO_VERSION_MASK);

						if (ver == 0) // insert the default spell-version if a version # doesn't exist
						{
							spellinfo |= hc.HENCH_SPELL_INFO_VERSION; // default info-version in 'hench_i0_generic'
							SpellInfo_text.Text = spellinfo.ToString();
							return; // re-fire this funct.
						}

						if (ver == spellinfo) // clear the spell-version if that's the only data in spellinfo
						{
							// TODO: I suppose the spell-version should be stored (if not the default version #) ...
							// so it can be re-inserted identically (if/after user clears all spellinfo bits).

							spellinfo = 0;
							SpellInfo_text.Text = spellinfo.ToString();
							return; // re-fire this funct.
						}
					}


					Spell spell = MainForm.Spells[MainForm.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = MainForm.SpellsChanged[MainForm.Id];
					}
					else
					{
						spellchanged = new SpellChanged();

						spellchanged.targetinfo   = spell.targetinfo;
						spellchanged.effectweight = spell.effectweight;
						spellchanged.effecttypes  = spell.effecttypes;
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.spellinfo = spellinfo;

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

				MainForm.PrintCurrent(spellinfo, SpellInfo_hex, SpellInfo_bin);

				differ = MainForm.Spells[MainForm.Id].differ;

				if ((differ & bit_spellinfo) != 0)
				{
					SpellInfo_reset.ForeColor = Color.Crimson;
				}
				else
					SpellInfo_reset.ForeColor = DefaultForeColor;

				CheckSpellInfoCheckers(spellinfo);


				SetDetrimentalBeneficial();
				SetGroupColors();

				si_ChildIDGrp .Visible =
				si_ChildLabel1.Visible =
				si_ChildLabel2.Visible =
				si_ChildLabel3.Visible =
				si_ChildLabel4.Visible =
				si_ChildLabel5.Visible = si_IsMaster.Checked;

//				PrintInfoVersion_spell(spellinfo);

				MainForm.that.SetEnabled(differ != bit_clear);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's spellinfo.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_si_reset(object sender, EventArgs e)
		{
			Spell spell = MainForm.Spells[MainForm.Id];
			if ((spell.differ & bit_spellinfo) != 0)
			{
				spell.differ &= ~bit_spellinfo;
				MainForm.Spells[MainForm.Id] = spell;

				if (spell.differ == bit_clear)
				{
					MainForm.SpellsChanged.Remove(MainForm.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;
					MainForm.that.SetNodeColor(color);
				}

				SpellInfo_reset.ForeColor = DefaultForeColor;

				SpellInfo_text.Text = spell.spellinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by combobox on the SpellInfo page - SpellType group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_si_cbo_Spelltype(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_si_cbo_Spelltype() selectedId= " + cbo_si_Spelltype.SelectedIndex);

			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				spellinfo &= ~hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK; // 0x000000ff
				SpellInfo_text.Text = (spellinfo | cbo_si_Spelltype.SelectedIndex).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the SpellInfo page - SpellLevel group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_si_cbo_Spelllevel(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_si_cbo_Spelllevel() selectedId= " + cbo_si_Spelllevel.SelectedIndex);

			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				spellinfo &= ~hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK; // 0x0001e000
				int val = cbo_si_Spelllevel.SelectedIndex << hc.HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
				SpellInfo_text.Text = (spellinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the SpellInfo page - Flags group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_si_Flags(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_si_Flags()");
			//logfile.Log(". text= " + SpellInfo_text.Text);

			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				//logfile.Log(". . is valid Int32= " + spellinfo);

				int bit;

				var cb = sender as CheckBox;
				if (cb == si_IsMaster)
				{
					bit = hc.HENCH_SPELL_INFO_MASTER_FLAG;			// 0x00000100
				}
				else if (cb == si_Ignore)
				{
					bit = hc.HENCH_SPELL_INFO_IGNORE_FLAG;			// 0x00000200
				}
				else if (cb == si_Concentration)
				{
					bit = hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG;	// 0x00000400
				}
				else if (cb == si_Unlimited)
				{
					bit = hc.HENCH_SPELL_INFO_UNLIMITED_FLAG;		// 0x00000800
				}
				else if (cb == si_HealOrCure)
				{
					bit = hc.HENCH_SPELL_INFO_HEAL_OR_CURE;		// 0x00020000
				}
				else if (cb == si_ShortDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_SHORT_DUR_BUFF;		// 0x00040000
				}
				else if (cb == si_MediumDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_MEDIUM_DUR_BUFF;		// 0x00080000
				}
				else if (cb == si_LongDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_LONG_DUR_BUFF;		// 0x00100000
				}
				else //if (cb == si_ItemCast)
				{
					bit = hc.HENCH_SPELL_INFO_ITEM_FLAG;			// 0x00800000
				}

				if (cb.Checked)
				{
					spellinfo |= bit;
				}
				else
					spellinfo &= ~bit;

				SpellInfo_text.Text = spellinfo.ToString();
			}
		}

		/// <summary>
		/// Sends the text in the ChildID boxes to where they should go.
		/// Note that the EffectWeight field is skipped since it ought be a
		/// float-value while the ChildIDs convert to ints.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_si_ChildFields(object sender, EventArgs e)
		{
			var tb = sender as TextBox;

			int childId;
			if (Int32.TryParse(tb.Text, out childId))
			{
				if (childId < 0)
				{
					childId = 0;
					tb.Text = childId.ToString(); // re-trigger this funct.
					tb.SelectionStart = tb.Text.Length;
				}
//				else if (childId > 16383) // 14 bits
//				{
//					childId = 16383;
//					tb.Text = childId.ToString(); // re-trigger this funct.
//					tb.SelectionStart = tb.Text.Length;
//				}
				else
				{
					Label lbl_child;

					// NOTE: this doesn't result in an infinite loop.
					if (tb == si_Child1)
					{
						TargetInfo_text.Text = tb.Text;
						lbl_child = si_ChildLabel1;
					}
					else if (tb == si_Child2)
					{
						EffectTypes_text.Text = tb.Text;
						lbl_child = si_ChildLabel2;
					}
					else if (tb == si_Child3)
					{
						DamageInfo_text.Text = tb.Text;
						lbl_child = si_ChildLabel3;
					}
					else if (tb == si_Child4)
					{
						SaveType_text.Text = tb.Text;
						lbl_child = si_ChildLabel4;
					}
					else //if (tb == si_Child5)
					{
						SaveDCType_text.Text = tb.Text;
						lbl_child = si_ChildLabel5;
					}

					if (MainForm.spellLabels.Count != 0
						&& childId < MainForm.spellLabels.Count)
					{
						lbl_child.Text = MainForm.spellLabels[childId];
					}
				}
			}
		}


//		/// <summary>
//		/// Prints the info-version of the currently selected spell ID.
//		/// <param name="spellinfo"></param>
//		/// </summary>
//		void PrintInfoVersion_spell(int spellinfo)
//		{
//			spellinfo &= hc.HENCH_SPELL_INFO_VERSION_MASK;
//			spellinfo >>= MainForm.HENCH_SPELL_INFO_VERSION_SHIFT;
//
//			si_infoversion.Text = spellinfo.ToString();
//		}


		/// <summary>
		/// Sets the checkers on the SpellInfo page to reflect the current
		/// spellinfo value.
		/// </summary>
		/// <param name="spellinfo"></param>
		void CheckSpellInfoCheckers(int spellinfo)
		{
// Flags checkboxes
			si_IsMaster     .Checked = (spellinfo & hc.HENCH_SPELL_INFO_MASTER_FLAG)        != 0;
			si_Ignore       .Checked = (spellinfo & hc.HENCH_SPELL_INFO_IGNORE_FLAG)        != 0;
			si_Concentration.Checked = (spellinfo & hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG) != 0;
			si_Unlimited    .Checked = (spellinfo & hc.HENCH_SPELL_INFO_UNLIMITED_FLAG)     != 0;
			si_HealOrCure   .Checked = (spellinfo & hc.HENCH_SPELL_INFO_HEAL_OR_CURE)       != 0;
			si_ShortDurBuff .Checked = (spellinfo & hc.HENCH_SPELL_INFO_SHORT_DUR_BUFF)     != 0;
			si_MediumDurBuff.Checked = (spellinfo & hc.HENCH_SPELL_INFO_MEDIUM_DUR_BUFF)    != 0;
			si_LongDurBuff  .Checked = (spellinfo & hc.HENCH_SPELL_INFO_LONG_DUR_BUFF)      != 0;
			si_ItemCast     .Checked = (spellinfo & hc.HENCH_SPELL_INFO_ITEM_FLAG)          != 0;

// Spelltype dropdown-list
			int val = spellinfo;
			val &= hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK;
			if (val >= cbo_si_Spelltype.Items.Count)
			{
				val = -1;
				cbo_si_Spelltype.ForeColor = Color.Crimson;
			}
			else
				cbo_si_Spelltype.ForeColor = DefaultForeColor;

			cbo_si_Spelltype.SelectedIndex = val;

// Spelllevel dropdown-list
			val = spellinfo;
			val &= hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK;
			val >>= hc.HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
			if (val >= cbo_si_Spelllevel.Items.Count)
			{
				val = -1;
				cbo_si_Spelllevel.ForeColor = Color.Crimson;
			}
			else
				cbo_si_Spelllevel.ForeColor = DefaultForeColor;

			cbo_si_Spelllevel.SelectedIndex = val;
		}


		/// <summary>
		/// Sets the spell-display as detrimental or beneficial based on the
		/// spell-type field.
		/// </summary>
		void SetDetrimentalBeneficial()
		{
			string text;
			switch (cbo_si_Spelltype.SelectedIndex) // (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK);
			{
				case -1: // safety.
				case  0:
					text = ""; // "INVALID"
					break;

				case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:	// TODO: Look into these and how they trace through
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_HARM:		// to the effect-types etc in the CoreAI scripts.
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK:
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK_SPECIAL:
					text = "DETRIMENTAL";
					break;

				default:									// TODO: Investigate exactly which spelltypes
					text = "BENEFICIAL";					// should show the PositiveEffects group.
					break;
			}

			si_hostile.Text = text;
		}

		/// <summary>
		/// Toggles the colors of bit-groupings on the various pages between
		/// green and red (roughly: isUsed by the current spelltype or isNotUsed
		/// by the current spelltype).
		/// </summary>
		void SetGroupColors()
		{
			int spelltype = cbo_si_Spelltype.SelectedIndex; // (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK);

// TargetInfo groups
			Color color;
			if (si_IsMaster.Checked)
			{
				color = Color.Crimson;
			}
			else
				color = Color.LimeGreen;

			GroupColor(ti_FlagsGrp,  color);
			GroupColor(ti_ShapeGrp,  color);
			GroupColor(ti_RangeGrp,  color);
			GroupColor(ti_RadiusGrp, color);

// EffectTypes groups
			GroupColor(et_BenEffectsGrp, Color.Crimson);
			GroupColor(et_DetEffectsGrp, Color.Crimson);

			if (!si_IsMaster.Checked)
			{
				switch (spelltype)
				{
					default:
//					case HENCH_SPELL_INFO_SPELL_TYPE_SPELL_PROT:
						GroupColor(et_BenEffectsGrp, Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_HARM:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK_SPECIAL:
						GroupColor(et_DetEffectsGrp, Color.LimeGreen);
						break;

					case -1: // safety.
					case  0:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
						break;
				}
			}

// DamageInfo groups
			GroupColor(di_DispelTypesGrp, Color.Crimson);
			GroupColor(di_BeneficialGrp,  Color.Crimson);
			GroupColor(di_DetrimentalGrp, Color.Crimson);

			if (!si_IsMaster.Checked)
			{
				switch (spelltype)
				{
					default: // TODO: sort these two out ...
						GroupColor(di_BeneficialGrp,  Color.LimeGreen);
						GroupColor(di_DetrimentalGrp, Color.LimeGreen);
						break;

//					case :
//						GroupColor(di_BeneficialGrp,  Color.LimeGreen);
//						break;

					// set DamageInfo colors based on SpellInfo spelltype and TargetInfo scaledeffect
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_HEAL:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_HARM:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE:
					{
						int targetinfo; // (targetinfo & HENCH_SPELL_TARGET_SCALE_EFFECT)
						if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))	// bypass if the 2da is initially loading ...
						{															// there's code on the TargetInfo-page that catches
							if (ti_ScaledEffect.Checked)							// DamageInfo group-colors there also.
							{
								GroupColor(di_BeneficialGrp,  Color.LimeGreen);
							}
							else
								GroupColor(di_DetrimentalGrp, Color.LimeGreen);
						}
						break;
					}

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF:
						GroupColor(di_BeneficialGrp,  Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ELEMENTAL_SHIELD:
						GroupColor(di_DetrimentalGrp, Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
						GroupColor(di_DispelTypesGrp, Color.LimeGreen);
						break;

					case -1: // safety.
					case  0:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SPELL_PROT:
						break;
				}
			}

// SaveType groups
			GroupColor(st_ExclusiveGrp,         Color.Crimson);
			GroupColor(st_TargetRestrictionGrp, Color.Crimson);
			GroupColor(st_AcBonusGrp,           Color.Crimson);
			GroupColor(st_DetrimentalGrp,       Color.Crimson);
			GroupColor(st_NotCaster,            Color.Crimson);

			if (!si_IsMaster.Checked)
			{
				switch (spelltype)
				{
					default:
						GroupColor(st_DetrimentalGrp, Color.LimeGreen);
						GroupColor(st_NotCaster,      Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ELEMENTAL_SHIELD:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ENGR_PROT: // "engry" - coders sheesh.
						GroupColor(st_ExclusiveGrp, Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF:
						GroupColor(st_TargetRestrictionGrp, Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF:
						GroupColor(st_AcBonusGrp, Color.LimeGreen);
						GroupColor(st_NotCaster,  Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_BUFF:
						GroupColor(st_NotCaster, Color.LimeGreen);
						break;

					case -1: // safety.
					case  0:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SPELL_PROT:
						break;
				}
			}

// SaveDCType groups
			GroupColor(dc_SaveDCGrp,      Color.Crimson);
			GroupColor(dc_WeaponBonusGrp, Color.Crimson);
			GroupColor(dc_ArmorCheckGrp,  Color.Crimson);

			if (!si_IsMaster.Checked)
			{
				switch (spelltype)
				{
					default:
						GroupColor(dc_SaveDCGrp, Color.LimeGreen);
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF:	// TODO: Check this in the CoreAI scripts.
						GroupColor(dc_WeaponBonusGrp, Color.LimeGreen);	// Ie. what exactly uses the weaponbonus group
						break;

					case hc.HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF:		// TODO: Check this in the CoreAI scripts.
						GroupColor(dc_ArmorCheckGrp, Color.LimeGreen);	// Ie. what exactly uses the armorcheck group
						break;

					case -1: // safety.
					case  0:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_SPELL_PROT:
						break;
				}
			}
		}

		// OBSOLETE: Set all groups false then toggle the one(s) that's
		// supposed to show on. This works around a .NET anomaly in which
		// assigning a true-value to a group can leave its visibility false
		// regardless (see commented code below).
// DOES NOT (always) WORK AS ADVERTISED:
//		logfile.Log(". (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF)= "
//				+ (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF));				// This can be True
//		st_WeaponGrp.Visible = (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF);
//		logfile.Log(". st_WeaponGrp.Visible= " + st_WeaponGrp.Visible);					// But this can be False
// note: It has been observed to bork after program start. After clicking through
// a few tree-nodes it will then work fine. But that's not good enough is it.
	}
}