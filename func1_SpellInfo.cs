using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the SpellInfo page.
	/// </summary>
	partial class MainForm
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
				if (!bypassTextChanged)
				{
					// ensure that spellinfo has a CoreAI version
					// although strictly speaking I believe that GetSpellInfo()
					// will gracefully handle spell-data that has no version set.
					if (spellinfo != 0)
					{
						if ((spellinfo & HENCH_SPELL_INFO_VERSION_MASK) == 0) // insert the default spell-version if it doesn't exist
						{
							spellinfo |= HENCH_SPELL_INFO_VERSION; // def'n 'hench_i0_generic'
							SpellInfo_text.Text = spellinfo.ToString();
							return; // re-fire this funct.
						}

						if (spellinfo == (spellinfo & HENCH_SPELL_INFO_VERSION_MASK)) // clear the spell-version if that's the only data in spellinfo
						{
							// TODO: I suppose the spell-version should be stored (if not the default version #) ...
							// so it can be re-inserted identically (if/after user clears all spellinfo bits).
							spellinfo = 0;
							SpellInfo_text.Text = spellinfo.ToString();
							return; // re-fire this funct.
						}
					}
					// TODO: Those need to update the fields when loading the 2da
					// ... especially the Text-field/reset-color. And the spell-tree's node-color


					var spell = Spells[Id];

					SpellChanged spellchanged;

					if (SpellsChanged.ContainsKey(Id))
					{
						spellchanged = SpellsChanged[Id];
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

					PrintCurrent(spellinfo, null, SpellInfo_hex, SpellInfo_bin);
				}

				if ((Spells[Id].differ & bit_spellinfo) != 0)
				{
					SpellInfo_reset.ForeColor = Color.Crimson;
				}
				else
					SpellInfo_reset.ForeColor = DefaultForeColor;

				CheckSpellInfoCheckers(spellinfo);

				SetDetrimentalBeneficial(spellinfo);
				SetGroupVisibility(spellinfo);
				ShowChildFields(spellinfo);
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
			//logfile.Log("Click_si_reset");

			if (SpellsChanged.ContainsKey(Id))
			{
				//logfile.Log(". is in SpellsChanged");

				Spell spell = Spells[Id];
				spell.differ &= ~bit_spellinfo;
				Spells[Id] = spell;

				//logfile.Log(". differ= " + spell.differ);

				if (spell.differ == bit_clear)
				{
					//logfile.Log(". . bit_clear");
					SpellsChanged.Remove(Id);

					if (spell.isChanged) // this is set by the Apply btn only.
					{
						//logfile.Log(". . . isChanged TRUE - set node to Blue");
						SpellTree.SelectedNode.ForeColor = Color.Blue;
					}
					else
					{
						//logfile.Log(". . . isChanged FALSE - set node to DefaultColor");
						SpellTree.SelectedNode.ForeColor = DefaultForeColor;
					}
				}
				//else logfile.Log(". . NOT bit_clear");

				SpellInfo_reset.ForeColor = DefaultForeColor;

				SpellInfo_text.Text = spell.spellinfo.ToString();
			}
			//else logfile.Log(". is NOT in SpellsChanged");
		}


		/// <summary>
		/// Populates the SpellInfo dropdown-lists.
		/// </summary>
		void PopulateSpellInfoComboboxes()
		{
			// populate the dropdown list for SpellInfo - SpellType
			// NOTE: These cases are considered in 'hench_i0_itemsp' DispatchSpell()
			cbo_si_Spelltype.Items.Add("none or Master");			//  0
			cbo_si_Spelltype.Items.Add("attack");					//  1
			cbo_si_Spelltype.Items.Add("ac buff");					//  2
			cbo_si_Spelltype.Items.Add("buff");						//  3
			cbo_si_Spelltype.Items.Add("persistent aoe");			//  4
			cbo_si_Spelltype.Items.Add("polymorph");				//  5
			cbo_si_Spelltype.Items.Add("dispel");					//  6
			cbo_si_Spelltype.Items.Add("invisibility");				//  7
			cbo_si_Spelltype.Items.Add("cure condition");			//  8
			cbo_si_Spelltype.Items.Add("summon");					//  9
			cbo_si_Spelltype.Items.Add("heal");						// 10
			cbo_si_Spelltype.Items.Add("harm");						// 11
			cbo_si_Spelltype.Items.Add("attribute buff");			// 12
			cbo_si_Spelltype.Items.Add("energy protection");		// 13
			cbo_si_Spelltype.Items.Add("melee attack");				// 14
			cbo_si_Spelltype.Items.Add("arcane archer");			// 15
			cbo_si_Spelltype.Items.Add("spell protection");			// 16
			cbo_si_Spelltype.Items.Add("dragon breath");			// 17
			cbo_si_Spelltype.Items.Add("detect invisible");			// 18
			cbo_si_Spelltype.Items.Add("warlock [not used]");		// 19
			cbo_si_Spelltype.Items.Add("dominate");					// 20
			cbo_si_Spelltype.Items.Add("weapon buff");				// 21
			cbo_si_Spelltype.Items.Add("animal companion buff");	// 22
			cbo_si_Spelltype.Items.Add("protection vs evil");		// 23
			cbo_si_Spelltype.Items.Add("protection vs good");		// 24
			cbo_si_Spelltype.Items.Add("regenerate");				// 25
			cbo_si_Spelltype.Items.Add("gust of wind");				// 26
			cbo_si_Spelltype.Items.Add("elemental shield");			// 27
			cbo_si_Spelltype.Items.Add("turn undead");				// 28
			cbo_si_Spelltype.Items.Add("dr buff");					// 29
			cbo_si_Spelltype.Items.Add("melee attack buff");		// 30
			cbo_si_Spelltype.Items.Add("raise dead");				// 31
			cbo_si_Spelltype.Items.Add("concealment");				// 32
			cbo_si_Spelltype.Items.Add("attack special");			// 33
			cbo_si_Spelltype.Items.Add("heal special");				// 34

			// populate the dropdown list for SpellInfo - SpellLevel
			cbo_si_Spelllevel.Items.Add("0");
			cbo_si_Spelllevel.Items.Add("1");
			cbo_si_Spelllevel.Items.Add("2");
			cbo_si_Spelllevel.Items.Add("3");
			cbo_si_Spelllevel.Items.Add("4");
			cbo_si_Spelllevel.Items.Add("5");
			cbo_si_Spelllevel.Items.Add("6");
			cbo_si_Spelllevel.Items.Add("7");
			cbo_si_Spelllevel.Items.Add("8");
			cbo_si_Spelllevel.Items.Add("9");
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
				bypassCheckedChecker = true;

				spellinfo &= ~HENCH_SPELL_INFO_SPELL_TYPE_MASK; // 0x000000ff
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
				bypassCheckedChecker = true;

				spellinfo &= ~HENCH_SPELL_INFO_SPELL_LEVEL_MASK; // 0x0001e000
				int val = cbo_si_Spelllevel.SelectedIndex << HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
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
				if (cb.Equals(si_IsMaster))
				{
					bit = HENCH_SPELL_INFO_MASTER_FLAG;			// 0x00000100
				}
				else if (cb.Equals(si_Ignore))
				{
					bit = HENCH_SPELL_INFO_IGNORE_FLAG;			// 0x00000200
				}
				else if (cb.Equals(si_Concentration))
				{
					bit = HENCH_SPELL_INFO_CONCENTRATION_FLAG;	// 0x00000400
				}
				else if (cb.Equals(si_Unlimited))
				{
					bit = HENCH_SPELL_INFO_UNLIMITED_FLAG;		// 0x00000800
				}
				else if (cb.Equals(si_HealOrCure))
				{
					bit = HENCH_SPELL_INFO_HEAL_OR_CURE;		// 0x00020000
				}
				else if (cb.Equals(si_ShortDurBuff))
				{
					bit = HENCH_SPELL_INFO_SHORT_DUR_BUFF;		// 0x00040000
				}
				else if (cb.Equals(si_MediumDurBuff))
				{
					bit = HENCH_SPELL_INFO_MEDIUM_DUR_BUFF;		// 0x00080000
				}
				else if (cb.Equals(si_LongDurBuff))
				{
					bit = HENCH_SPELL_INFO_LONG_DUR_BUFF;		// 0x00100000
				}
				else //if (cb.Equals(si_ItemCast))
				{
					bit = HENCH_SPELL_INFO_ITEM_FLAG;			// 0x00800000
				}

				if (cb.Checked)
				{
					spellinfo |= bit;
				}
				else
					spellinfo &= ~bit;

				bypassCheckedChecker = true;
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
			// NOTE: this doesn't result in an infinite loop.
			var tb = sender as TextBox;
			if (tb.Equals(si_Child1))
			{
				TargetInfo_text.Text = tb.Text;
			}
			else if (tb.Equals(si_Child2))
			{
				EffectTypes_text.Text = tb.Text;
			}
			else if (tb.Equals(si_Child3))
			{
				DamageInfo_text.Text = tb.Text;
			}
			else if (tb.Equals(si_Child4))
			{
				SaveType_text.Text = tb.Text;
			}
			else //if (tb.Equals(si_Child5))
			{
				SaveDCType_text.Text = tb.Text;
			}
		}


		/// <summary>
		/// Sets the checkers on the SpellInfo page to reflect the current
		/// spellinfo value.
		/// </summary>
		/// <param name="spellinfo"></param>
		void CheckSpellInfoCheckers(int spellinfo)
		{
			//logfile.Log("CheckSpellInfoCheckers()");

			if (!bypassCheckedChecker)
			{
				//logfile.Log(". spellinfo= " + spellinfo);

// Flags checkboxes
				si_IsMaster     .Checked = (spellinfo & HENCH_SPELL_INFO_MASTER_FLAG)        != 0;
				si_Ignore       .Checked = (spellinfo & HENCH_SPELL_INFO_IGNORE_FLAG)        != 0;
				si_Concentration.Checked = (spellinfo & HENCH_SPELL_INFO_CONCENTRATION_FLAG) != 0;
				si_Unlimited    .Checked = (spellinfo & HENCH_SPELL_INFO_UNLIMITED_FLAG)     != 0;
				si_HealOrCure   .Checked = (spellinfo & HENCH_SPELL_INFO_HEAL_OR_CURE)       != 0;
				si_ShortDurBuff .Checked = (spellinfo & HENCH_SPELL_INFO_SHORT_DUR_BUFF)     != 0;
				si_MediumDurBuff.Checked = (spellinfo & HENCH_SPELL_INFO_MEDIUM_DUR_BUFF)    != 0;
				si_LongDurBuff  .Checked = (spellinfo & HENCH_SPELL_INFO_LONG_DUR_BUFF)      != 0;
				si_ItemCast     .Checked = (spellinfo & HENCH_SPELL_INFO_ITEM_FLAG)          != 0;

// Spelltype dropdown-list
				int val = spellinfo;
				val &= HENCH_SPELL_INFO_SPELL_TYPE_MASK;
				if (val >= cbo_si_Spelltype.Items.Count)
				{
					val = -1;
					cbo_si_Spelltype.ForeColor = Color.Crimson;
//					cbo_si_Spelltype.Text = "invalid";
				}
				else
					cbo_si_Spelltype.ForeColor = DefaultForeColor;

				cbo_si_Spelltype.SelectedIndex = val;

// Spelllevel dropdown-list
				val = spellinfo;
				val &= HENCH_SPELL_INFO_SPELL_LEVEL_MASK;
				val >>= HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
				if (val >= cbo_si_Spelllevel.Items.Count)
				{
					val = -1;
					cbo_si_Spelllevel.ForeColor = Color.Crimson;
//					cbo_si_Spelllevel.Text = "invalid";
				}
				else
					cbo_si_Spelllevel.ForeColor = DefaultForeColor;

				cbo_si_Spelllevel.SelectedIndex = val;
			}
			else
			{
				//logfile.Log(". bypassed");
				bypassCheckedChecker = false;
			}
		}


		/// <summary>
		/// Sets the spell-display as hostile or beneficial based on the
		/// spell-type field.
		/// </summary>
		/// <param name="spellinfo"></param>
		void SetDetrimentalBeneficial(int spellinfo)
		{
			string text;
			switch (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK)
			{
				case 0:
					text = "INVALID";
					si_hostile.ForeColor = Color.Crimson;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:	// TODO: Look into these and how they trace through
				case HENCH_SPELL_INFO_SPELL_TYPE_HARM:		// to the effect-types etc in the CoreAI scripts.
				case HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
				case HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
				case HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK:
				case HENCH_SPELL_INFO_SPELL_TYPE_ATTACK_SPECIAL:
					text = "DETRIMENTAL";
					si_hostile.ForeColor = DefaultForeColor;
					break;

				default:									// TODO: Investigate exactly which spelltypes
					text = "BENEFICIAL";					// should show the PositiveEffects group.
					si_hostile.ForeColor = DefaultForeColor;
					break;
			}

			si_hostile.Text = text;
		}

		/// <summary>
		/// Toggles the bit-groupings on the various pages between visible/non-
		/// visible.
		/// NOTE: Set all groups false then toggle the one(s) that's supposed to
		/// show on. This works around a .NET anomaly in which assigning a
		/// true-value to a group can leave its visibility false regardless
		/// (see commented code below).
		/// </summary>
		/// <param name="spellinfo"></param>
		void SetGroupVisibility(int spellinfo)
		{
			int spelltype = (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK);


// EffectTypes groups
			et_PosEffectsGrp.Visible =
			et_NegEffectsGrp.Visible = false;

			switch (spelltype)
			{
				default:
					et_PosEffectsGrp.Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:
				case HENCH_SPELL_INFO_SPELL_TYPE_HARM:
				case HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
				case HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
				case HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK:
				case HENCH_SPELL_INFO_SPELL_TYPE_ATTACK_SPECIAL:
					et_NegEffectsGrp.Visible = true;
					break;

				case 0:
				case HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
				case HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
					// hide all groups
					break;
			}


// DamageInfo groups
			di_DispelTypesGrp.Visible =
			di_BeneficialGrp .Visible =
			di_DetrimentalGrp.Visible = false;

			switch (spelltype)
			{
				default: // TODO: sort these two out ...
					di_BeneficialGrp .Visible =
					di_DetrimentalGrp.Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
					di_DispelTypesGrp.Visible = true;
					break;

				case 0:
				case HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					// hide all groups
					break;
			}


// SaveType groups
			st_ExclusiveGrp  .Visible =
			st_WeaponGrp     .Visible =
			st_AcBonusGrp    .Visible =
			st_DetrimentalGrp.Visible = false;

			st_NotCaster.Visible = false; // this is not in a group since it can be used by several types.

			switch (spelltype)
			{
				default:
					st_DetrimentalGrp.Visible =
					st_NotCaster     .Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_ELEMENTAL_SHIELD:
				case HENCH_SPELL_INFO_SPELL_TYPE_ENGR_PROT: // "engry" - coders sheesh.
					st_ExclusiveGrp.Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF:
					st_WeaponGrp.Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF:
					st_AcBonusGrp.Visible =
					st_NotCaster .Visible = true;
					break;

				case HENCH_SPELL_INFO_SPELL_TYPE_BUFF:
					st_NotCaster.Visible = true;
					break;

				case 0:
				case HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
				case HENCH_SPELL_INFO_SPELL_TYPE_DISPEL:
					// hide all groups
					break;
			}


// SaveDCType groups
/*			dc_SaveDCGrp     .Visible = // TODO: The SaveDCType page's visibility is
			dc_WeaponBonusGrp.Visible = // handled elsewhere but needs to be redone.
			dc_ArmorCheckGrp .Visible =
			savedctype1      .Visible =
			savedctype2      .Visible =
			savedctype_label .Visible = false;

			switch (spelltype)
			{
				default:
					dc_SaveDCGrp     .Visible =
					dc_WeaponBonusGrp.Visible =
					dc_ArmorCheckGrp .Visible =
					savedctype1      .Visible =
					savedctype2      .Visible =
					savedctype_label .Visible = true;
					break;

//				case :
//					break;

				case 0:
				case HENCH_SPELL_INFO_SPELL_TYPE_SUMMON:
					// hide all groups
					break;
			} */
		}


// DOES NOT (always) WORK AS ADVERTISED:
//		logfile.Log(". (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF)= "
//				+ (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF));				// This can be True
//		st_WeaponGrp.Visible = (spelltype == HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF);
//		logfile.Log(". st_WeaponGrp.Visible= " + st_WeaponGrp.Visible);					// But this can be False
// note: It has been observed to bork after program start. After clicking through
// a few tree-nodes it will then work fine. But that's not good enough is it.



		/// <summary>
		/// Shows the ChildIDs group if the MasterID bit is flagged.
		/// </summary>
		/// <param name="spellinfo"></param>
		void ShowChildFields(int spellinfo)
		{
			si_ChildIDGrp.Visible = (spellinfo & HENCH_SPELL_INFO_MASTER_FLAG) != 0;

//			bool vis = (spellinfo & HENCH_SPELL_INFO_MASTER_FLAG) != 0;

//			page_TargetInfo  .Visible = // doesn't work.
//			page_EffectWeight.Visible =
//			page_EffectTypes .Visible =
//			page_DamageInfo  .Visible =
//			page_SaveType    .Visible =
//			page_SaveDCType  .Visible = !vis;

//			Color color;
//			if (vis)
//			{
//				color = Color.Crimson;
//			}
//			else
//				color = DefaultForeColor;

//			page_TargetInfo  .ForeColor = // doesn't work.
//			page_EffectWeight.ForeColor =
//			page_EffectTypes .ForeColor =
//			page_DamageInfo  .ForeColor =
//			page_SaveType    .ForeColor =
//			page_SaveDCType  .ForeColor = color;

			// basically it looks like you'd have to iterate through the controls
			// on each tab-page and toggle their visibilities individually.
		}
	}
}
