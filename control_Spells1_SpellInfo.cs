﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Functions for the SpellInfo page.
	partial class control_Spells
	{
		#region eventhandlers
		/// <summary>
		/// Handles <c>TextChanged</c> event on the SpellInfo page.
		/// </summary>
		/// <param name="sender"><c><see cref="SpellInfo_text"/></c></param>
		/// <param name="e"></param>
		void TextChanged_si(object sender, EventArgs e)
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

			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				if (!he.BypassDiffer)
				{
					// ensure that spellinfo has a CoreAI version
					// although strictly speaking I believe that GetSpellInfo()
					// will gracefully handle spell-data that has no version set.
//					if (!he.BypassInfoVersion && spellinfo != 0)
//					{
//						int ver = (spellinfo & hc.HENCH_SPELL_INFO_VERSION_MASK);
//
//						if (ver == 0) // insert the default spell-version if a version # doesn't exist
//						{
//							spellinfo |= hc.HENCH_SPELL_INFO_VERSION; // default info-version in 'hench_i0_generic'
//							SpellInfo_text.Text = spellinfo.ToString();
//							return; // re-fire this funct.
//						}
//
//						if (ver == spellinfo) // clear the spell-version if that's the only data in spellinfo
//						{
//							// TODO: I suppose the spell-version should be stored (if not the default version #) ...
//							// so it can be re-inserted identically (if/after user clears all spellinfo bits).
//
//							spellinfo = 0;
//							SpellInfo_text.Text = spellinfo.ToString();
//							return; // re-fire this funct.
//						}
//					}


					Spell spell = he.Spells[he.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clean)
					{
						spellchanged = he.SpellsChanged[he.Id];
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

				he.PrintCurrent(spellinfo, SpellInfo_hex, SpellInfo_bin);

				int differ = he.Spells[he.Id].differ;

				if ((differ & bit_spellinfo) != 0)
				{
					SpellInfo_reset.ForeColor = Color.Crimson;
				}
				else
					SpellInfo_reset.ForeColor = DefaultForeColor;

				state_SpellInfo(spellinfo);


				SetDetrimentalBeneficial();

				si_SubspellsGrp.Enabled = si_IsMaster.Checked;

//				PrintInfoVersion_spell(spellinfo);

				_he.EnableApplys(differ != bit_clean);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's spellinfo.
		/// </summary>
		/// <param name="sender"><c><see cref="SpellInfo_reset"/></c></param>
		/// <param name="e"></param>
		/// <remarks>If the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.</remarks>
		void Click_si_reset(object sender, EventArgs e)
		{
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_spellinfo) != 0)
			{
				spell.differ &= ~bit_spellinfo;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clean)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				SpellInfo_reset.ForeColor = DefaultForeColor;

				SpellInfo_text.Text = spell.spellinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by combobox on the SpellInfo page - SpellType
		/// group.
		/// </summary>
		/// <param name="sender"><c><see cref="si_co_Spelltype"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_si_co_Spelltype(object sender, EventArgs e)
		{
			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				spellinfo &= ~hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK; // 0x000000ff
				SpellInfo_text.Text = (spellinfo | si_co_Spelltype.SelectedIndex).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the SpellInfo page - SpellLevel
		/// group.
		/// </summary>
		/// <param name="sender"><c><see cref="si_co_Spelllevel"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_si_co_Spelllevel(object sender, EventArgs e)
		{
			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				spellinfo &= ~hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK; // 0x0001e000
				int val = si_co_Spelllevel.SelectedIndex << hc.HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
				SpellInfo_text.Text = (spellinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the SpellInfo page - Flags
		/// group.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="si_Ignore"/></c></item>
		/// <item><c><see cref="si_IsMaster"/></c></item>
		/// <item><c><see cref="si_Concentration"/></c></item>
		/// <item><c><see cref="si_HealOrCure"/></c></item>
		/// <item><c><see cref="si_ItemCast"/></c></item>
		/// <item><c><see cref="si_Unlimited"/></c></item>
		/// <item><c><see cref="si_ShortDurBuff"/></c></item>
		/// <item><c><see cref="si_MediumDurBuff"/></c></item>
		/// <item><c><see cref="si_LongDurBuff"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_si_Flags(object sender, MouseEventArgs e)
		{
			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				int bit;
				if (sender == si_IsMaster)
				{
					bit = hc.HENCH_SPELL_INFO_MASTER_FLAG;			// 0x00000100
				}
				else if (sender == si_Ignore)
				{
					bit = hc.HENCH_SPELL_INFO_IGNORE_FLAG;			// 0x00000200
				}
				else if (sender == si_Concentration)
				{
					bit = hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG;	// 0x00000400
				}
				else if (sender == si_Unlimited)
				{
					bit = hc.HENCH_SPELL_INFO_UNLIMITED_FLAG;		// 0x00000800
				}
//				else if (sender == si_NonVerbal) // TonyAI 2.3+ add ->
//				{
//					bit = hc.HENCH_SPELL_INFO_NO_VERBAL;			// 0x00001000
//				}
				else if (sender == si_HealOrCure)
				{
					bit = hc.HENCH_SPELL_INFO_HEAL_OR_CURE;			// 0x00020000
				}
				else if (sender == si_ShortDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_SHORT_DUR_BUFF;		// 0x00040000
				}
				else if (sender == si_MediumDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_MEDIUM_DUR_BUFF;		// 0x00080000
				}
				else if (sender == si_LongDurBuff)
				{
					bit = hc.HENCH_SPELL_INFO_LONG_DUR_BUFF;		// 0x00100000
				}
				else // sender == si_ItemCast
				{
					bit = hc.HENCH_SPELL_INFO_ITEM_FLAG;			// 0x00800000
				}

				if ((sender as CheckBox).Checked)
				{
					spellinfo |= bit;
				}
				else
					spellinfo &= ~bit;

				SpellInfo_text.Text = spellinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the SpellInfo page -
		/// Metamagic group.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="si_Extend"/></c></item>
		/// <item><c><see cref="si_Empower"/></c></item>
		/// <item><c><see cref="si_Maximize"/></c></item>
		/// <item><c><see cref="si_Persistent"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_si_Metamagic(object sender, MouseEventArgs e)
		{
			int spellinfo;
			if (Int32.TryParse(SpellInfo_text.Text, out spellinfo))
			{
				int bit;
				if (sender == si_Extend)
				{
					bit = hc.HENCH_SPELL_INFO_EXTEND_OK;	// 0x01000000
				}
				else if (sender == si_Persistent)
				{
					bit = hc.HENCH_SPELL_INFO_PERSIST_OK;	// 0x02000000
				}
				else if (sender == si_Empower)
				{
					bit = hc.HENCH_SPELL_INFO_EMPOWER_OK;	// 0x04000000
				}
				else // sender == si_Maximize
				{
					bit = hc.HENCH_SPELL_INFO_MAXIMIZE_OK;	// 0x08000000
				}

				if ((sender as CheckBox).Checked)
				{
					spellinfo |= bit;
				}
				else
					spellinfo &= ~bit;

				SpellInfo_text.Text = spellinfo.ToString();
			}
		}
		/// <summary>
		/// Sends the text in the Subspell boxes to where they should go.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="si_Subspell1"/></c></item>
		/// <item><c><see cref="si_Subspell2"/></c></item>
		/// <item><c><see cref="si_Subspell3"/></c></item>
		/// <item><c><see cref="si_Subspell4"/></c></item>
		/// <item><c><see cref="si_Subspell5"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		/// <remarks>The EffectWeight field is skipped since it is a
		/// <c>float</c> while the Subspell ids convert to <c>ints</c>.</remarks>
		void TextChanged_si_Subspell(object sender, EventArgs e)
		{
			if (!BypassSubspell)
			{
				var tb = sender as TextBox;

				int id;
				if (Int32.TryParse(tb.Text, out id))
				{
					if (id < 0)
					{
						tb.Text = "0"; // recurse this funct.
						tb.SelectionStart = tb.Text.Length;
					}
//					else if (id > 16383) // 14 bits // TODO: Implement that
//					{
//						tb.Text = "16383"; // recurse this funct.
//						tb.SelectionStart = tb.Text.Length;
//					}
					else
					{
						Label lbl_subspell;

						if (sender == si_Subspell1)
						{
							TargetInfo_text.Text = tb.Text;
							lbl_subspell = si_SubspellLabel1;
						}
						else if (sender == si_Subspell2)
						{
							EffectTypes_text.Text = tb.Text;
							lbl_subspell = si_SubspellLabel2;
						}
						else if (sender == si_Subspell3)
						{
							DamageInfo_text.Text = tb.Text;
							lbl_subspell = si_SubspellLabel3;
						}
						else if (sender == si_Subspell4)
						{
							SaveType_text.Text = tb.Text;
							lbl_subspell = si_SubspellLabel4;
						}
						else // sender == si_Subspell5
						{
							SaveDCType_text.Text = tb.Text;
							lbl_subspell = si_SubspellLabel5;
						}

						SetSpellLabelText(lbl_subspell, id);
					}
				}
			}
		}
		#endregion eventhandlers


		/// <summary>
		/// Sets a <c>Label's</c> text by referencing a specified
		/// <paramref name="id"/> in
		/// <c><see cref="he.spellLabels">he.spellLabels</see></c>.
		/// </summary>
		/// <param name="label">the <c>Control</c> to set the text for</param>
		/// <param name="id">the required <paramref name="id"/> in
		/// <c>he.spellLabels</c></param>
		void SetSpellLabelText(Control label, int id)
		{
			if (he.spellLabels.Count != 0
				&& id > -1 && id < he.spellLabels.Count)
			{
				label.Text = he.spellLabels[id];
			}
			else
				label.Text = String.Empty;
		}


		#region HenchControl (override)
		/// <summary>
		/// Sets spell-labels in various <c>Labels</c>.
		/// </summary>
		internal override void SetSpellLabelTexts()
		{
			int id;

			// NOTE: Texts shall not be negative.
			// TODO: Texts shall parse to ints.

			if (Int32.TryParse(TargetInfo_text.Text, out id)
				&& id > -1 && id < he.spellLabels.Count)
			{
				si_SubspellLabel1.Text = he.spellLabels[id];
			}
			else
				si_SubspellLabel1.Text = String.Empty;

			if (Int32.TryParse(EffectTypes_text.Text, out id)
				&& id > -1 && id < he.spellLabels.Count)
			{
				si_SubspellLabel2.Text = he.spellLabels[id];
			}
			else
				si_SubspellLabel2.Text = String.Empty;

			if (Int32.TryParse(DamageInfo_text.Text, out id)
				&& id > -1 && id < he.spellLabels.Count)
			{
				si_SubspellLabel3.Text = he.spellLabels[id];
			}
			else
				si_SubspellLabel3.Text = String.Empty;

			if (Int32.TryParse(SaveType_text.Text, out id)
				&& id > -1 && id < he.spellLabels.Count)
			{
				si_SubspellLabel4.Text = he.spellLabels[id];
			}
			else
				si_SubspellLabel4.Text = String.Empty;

			if (Int32.TryParse(SaveDCType_text.Text, out id)
				&& id > -1 && id < he.spellLabels.Count)
			{
				si_SubspellLabel5.Text = he.spellLabels[id];
			}
			else
				si_SubspellLabel5.Text = String.Empty;
		}

		/// <summary>
		/// Clears spell-labels.
		/// </summary>
		internal override void ClearSpellLabelTexts()
		{
			si_SubspellLabel1.Text =
			si_SubspellLabel2.Text =
			si_SubspellLabel3.Text =
			si_SubspellLabel4.Text =
			si_SubspellLabel5.Text = String.Empty;
		}
		#endregion HenchControl (override)


//		/// <summary>
//		/// Prints the info-version of the currently selected spell ID.
//		/// </summary>
//		/// <param name="spellinfo"></param>
//		void PrintInfoVersion_spell(int spellinfo)
//		{
//			spellinfo &= hc.HENCH_SPELL_INFO_VERSION_MASK;
//			spellinfo >>= he.HENCH_SPELL_INFO_VERSION_SHIFT;
//
//			si_infoversion.Text = spellinfo.ToString();
//		}


		#region setstate
		/// <summary>
		/// Sets the checkers on the SpellInfo page to reflect the current
		/// spellinfo value.
		/// </summary>
		/// <param name="spellinfo"></param>
		void state_SpellInfo(int spellinfo)
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
//			si_NonVerbal    .Checked = (spellinfo & hc.HENCH_SPELL_INFO_NO_VERBAL)          != 0; // TonyAI 2.3+ add

// Spelltype dropdown-list
			int val = (spellinfo & hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK);
			if (val >= si_co_Spelltype.Items.Count)
			{
				val = -1;
				si_co_Spelltype.ForeColor = Color.Crimson;
			}
			else
				si_co_Spelltype.ForeColor = DefaultForeColor;

			si_co_Spelltype.SelectedIndex = val;

// Spelllevel dropdown-list
			val = (spellinfo & hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK)
							>> hc.HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT;
			if (val >= si_co_Spelllevel.Items.Count)
			{
				val = -1;
				si_co_Spelllevel.ForeColor = Color.Crimson;
			}
			else
				si_co_Spelllevel.ForeColor = DefaultForeColor;

			si_co_Spelllevel.SelectedIndex = val;

// Metamagic checkboxes (actually just more Flags - but they're kinda special so put them in their own groupbox)
			si_Extend    .Checked = (spellinfo & hc.HENCH_SPELL_INFO_EXTEND_OK)   != 0; // TonyAI 2.3+ add ->
			si_Empower   .Checked = (spellinfo & hc.HENCH_SPELL_INFO_EMPOWER_OK)  != 0;
			si_Maximize  .Checked = (spellinfo & hc.HENCH_SPELL_INFO_MAXIMIZE_OK) != 0;
			si_Persistent.Checked = (spellinfo & hc.HENCH_SPELL_INFO_PERSIST_OK)  != 0;

			// test ->
			int roguebits = (spellinfo & ~si_legitbits);
			if (roguebits != 0)
			{
				si_RogueBits.Text = roguebits.ToString("X8");
				si_RogueBits   .Visible =
				si_la_RogueBits.Visible = true;
			}
			else
				si_RogueBits   .Visible =
				si_la_RogueBits.Visible = false;
		}

		const int si_legitbits = hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK	// 0x000000ff

							   | hc.HENCH_SPELL_INFO_MASTER_FLAG		// 0x00000100
							   | hc.HENCH_SPELL_INFO_IGNORE_FLAG		// 0x00000200
							   | hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG	// 0x00000400
							   | hc.HENCH_SPELL_INFO_UNLIMITED_FLAG		// 0x00000800
//							   | hc.HENCH_SPELL_INFO_NO_VERBAL			// 0x00001000

							   | hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK	// 0x0001e000

							   | hc.HENCH_SPELL_INFO_HEAL_OR_CURE		// 0x00020000
							   | hc.HENCH_SPELL_INFO_SHORT_DUR_BUFF		// 0x00040000
							   | hc.HENCH_SPELL_INFO_MEDIUM_DUR_BUFF	// 0x00080000
							   | hc.HENCH_SPELL_INFO_LONG_DUR_BUFF		// 0x00100000

																		// 0x00200000 - eg. Golem_Breath_Gas in tonyAi 2.5 HenchSpells.2da
																		// 0x00400000

							   | hc.HENCH_SPELL_INFO_ITEM_FLAG			// 0x00800000

							   | hc.HENCH_SPELL_INFO_EXTEND_OK			// 0x01000000
							   | hc.HENCH_SPELL_INFO_PERSIST_OK			// 0x02000000
							   | hc.HENCH_SPELL_INFO_EMPOWER_OK			// 0x04000000
							   | hc.HENCH_SPELL_INFO_MAXIMIZE_OK;		// 0x08000000

																		// 0x10000000 <-
																		// 0x20000000 <-
																		// 0x40000000 <-
																		// 0x80000000 <-


		/// <summary>
		/// Sets the spell-display as detrimental or beneficial based on the
		/// spell-type field.
		/// </summary>
		void SetDetrimentalBeneficial()
		{
			string text;
			switch (si_co_Spelltype.SelectedIndex) // (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK);
			{
				case -1: // safety.
				case  0:
					text = String.Empty; // "INVALID"
					break;

				case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:	// TODO: Look into these and how they trace through
				case hc.HENCH_SPELL_INFO_SPELL_TYPE_HARM:	// to the effect-types etc in the CoreAI scripts.
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
			SetGroupColors();
		}

		/// <summary>
		/// Toggles the colors of bit-groupings on the various pages between
		/// green and red (roughly: isUsed by the current spelltype or isNotUsed
		/// by the current spelltype).
		/// </summary>
		void SetGroupColors()
		{
			int spelltype = si_co_Spelltype.SelectedIndex; // (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK);

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
		#endregion setstate

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
