﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// TODO:
	//
	// If spell needs to check ItemProperties then effecttypes will contain only the ItemProperty nwscript-constant.
	// SpellInfo SpellType - hc.HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
	// eg. HenchCheckWeaponBuff() 'hench_i0_buff


	/// <summary>
	/// Functions for the EffectTypes page.
	/// </summary>
	partial class tabcontrol_Spells
	{
		#region eventhandlers
		/// <summary>
		/// Handles TextChanged event on the EffectTypes page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_et(object sender, EventArgs e)
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

			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
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
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.effecttypes = effecttypes;

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

				he.PrintCurrent(effecttypes, EffectTypes_hex, EffectTypes_bin);

				differ = he.Spells[he.Id].differ;

				if ((differ & bit_effecttypes) != 0)
				{
					EffectTypes_reset.ForeColor = Color.Crimson;
				}
				else
					EffectTypes_reset.ForeColor = DefaultForeColor;

				state_EffectTypes(effecttypes);


				if (si_IsMaster.Checked)
				{
					// the 'si_Subspell2' textchanged handler can change the value
					// and shoot it back here
					si_Subspell2.Text = EffectTypes_text.Text;
				}
				else
				{
					// else let the value pass unhindered
					BypassSubspell = true;
					si_Subspell2.Text = EffectTypes_text.Text;
					BypassSubspell = false;
					SetSpellLabelText(si_SubspellLabel2, effecttypes);
				}

				_he.EnableApplys(differ != bit_clean);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's effecttypes.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_et_reset(object sender, EventArgs e)
		{
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_effecttypes) != 0)
			{
				spell.differ &= ~bit_effecttypes;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clean)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				EffectTypes_reset.ForeColor = DefaultForeColor;

				EffectTypes_text.Text = spell.effecttypes.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the EffectTypes page - PositiveEffects group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_et_positiveeffects(object sender, MouseEventArgs e)
		{
			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
			{
				int bit;

				var cb = sender as CheckBox;
				if (cb == et_AcIncrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_AC_INCREASE;
				}
				else if (cb == et_Regenerate)
				{
					bit = hc.HENCH_EFFECT_TYPE_REGENERATE;
				}
				else if (cb == et_AttackIncrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_ATTACK_INCREASE;
				}
				else if (cb == et_DamageReduction)
				{
					bit = hc.HENCH_EFFECT_TYPE_DAMAGE_REDUCTION;
				}
				else if (cb == et_Haste)
				{
					bit = hc.HENCH_EFFECT_TYPE_HASTE;
				}
				else if (cb == et_TempHitpoints)
				{
					bit = hc.HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS;
				}
				else if (cb == et_Sanctuary)
				{
					bit = hc.HENCH_EFFECT_TYPE_SANCTUARY;
				}
				else if (cb == et_Timestop)
				{
					bit = hc.HENCH_EFFECT_TYPE_TIMESTOP;
				}
				else if (cb == et_SpellAbsorption)
				{
					bit = hc.HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION;
				}
				else if (cb == et_SavingThrowIncrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE;
				}
				else if (cb == et_Concealment)
				{
					bit = hc.HENCH_EFFECT_TYPE_CONCEALMENT;
				}
				else if (cb == et_DamageIncrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_DAMAGE_INCREASE;
				}
				else if (cb == et_AbsorbDamage)
				{
					bit = hc.HENCH_EFFECT_TYPE_ABSORBDAMAGE;
				}
				else if (cb == et_Ethereal)
				{
					bit = hc.HENCH_EFFECT_TYPE_ETHEREAL;
				}
				else if (cb == et_Invisibility)
				{
					bit = hc.HENCH_EFFECT_TYPE_INVISIBILITY;
				}
				else if (cb == et_Polymorph)
				{
					bit = hc.HENCH_EFFECT_TYPE_POLYMORPH;
				}
				else if (cb == et_Ultravision)
				{
					bit = hc.HENCH_EFFECT_TYPE_ULTRAVISION;
				}
				else if (cb == et_TrueSeeing)
				{
					bit = hc.HENCH_EFFECT_TYPE_TRUESEEING;
				}
				else if (cb == et_Wildshape)
				{
					bit = hc.HENCH_EFFECT_TYPE_WILDSHAPE;
				}
				else if (cb == et_GreaterInvisibility)
				{
					bit = hc.HENCH_EFFECT_TYPE_GREATER_INVIS;
				}
				else if (cb == et_ElementalShield)
				{
					bit = hc.HENCH_EFFECT_TYPE_ELEMENTALSHIELD;
				}
				else if (cb == et_AbilityIncrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_ABILITY_INCREASE;
				}
				else if (cb == et_SeeInvisible)
				{
					bit = hc.HENCH_EFFECT_TYPE_SEEINVISIBLE;
				}
				else if (cb == et_SpellShield)
				{
					bit = hc.HENCH_EFFECT_TYPE_SPELL_SHIELD;
				}
				else //if (cb == et_ImmunityNecromancy)
				{
					bit = hc.HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY;
				}

				if (cb.Checked)
				{
					effecttypes |= bit;
				}
				else
					effecttypes &= ~bit;

				EffectTypes_text.Text = effecttypes.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the EffectTypes page - NegativeEffects group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_et_negativeeffects(object sender, MouseEventArgs e)
		{
			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
			{
				int bit;

				var cb = sender as CheckBox;
				if (cb == et_Entangle)
				{
					bit = hc.HENCH_EFFECT_TYPE_ENTANGLE;
				}
				else if (cb == et_Paralyze)
				{
					bit = hc.HENCH_EFFECT_TYPE_PARALYZE;
				}
				else if (cb == et_Deafness)
				{
					bit = hc.HENCH_EFFECT_TYPE_DEAF;
				}
				else if (cb == et_Blindness)
				{
					bit = hc.HENCH_EFFECT_TYPE_BLINDNESS;
				}
				else if (cb == et_Curse)
				{
					bit = hc.HENCH_EFFECT_TYPE_CURSE;
				}
				else if (cb == et_Sleep)
				{
					bit = hc.HENCH_EFFECT_TYPE_SLEEP;
				}
				else if (cb == et_Charm)
				{
					bit = hc.HENCH_EFFECT_TYPE_CHARMED;
				}
				else if (cb == et_Confuse)
				{
					bit = hc.HENCH_EFFECT_TYPE_CONFUSED;
				}
				else if (cb == et_Frighten)
				{
					bit = hc.HENCH_EFFECT_TYPE_FRIGHTENED;
				}
				else if (cb == et_Dominate)
				{
					bit = hc.HENCH_EFFECT_TYPE_DOMINATED;
				}
				else if (cb == et_Daze)
				{
					bit = hc.HENCH_EFFECT_TYPE_DAZED;
				}
				else if (cb == et_Poison)
				{
					bit = hc.HENCH_EFFECT_TYPE_POISON;
				}
				else if (cb == et_Disease)
				{
					bit = hc.HENCH_EFFECT_TYPE_DISEASE;
				}
				else if (cb == et_Silence)
				{
					bit = hc.HENCH_EFFECT_TYPE_SILENCE;
				}
				else if (cb == et_Slow)
				{
					bit = hc.HENCH_EFFECT_TYPE_SLOW;
				}
				else if (cb == et_AbilityDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_ABILITY_DECREASE;
				}
				else if (cb == et_DamageDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_DAMAGE_DECREASE;
				}
				else if (cb == et_AttackDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_ATTACK_DECREASE;
				}
				else if (cb == et_SkillDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_SKILL_DECREASE;
				}
				else if (cb == et_Stun)
				{
					bit = hc.HENCH_EFFECT_TYPE_STUNNED;
				}
				else if (cb == et_Petrify)
				{
					bit = hc.HENCH_EFFECT_TYPE_PETRIFY;
				}
				else if (cb == et_SpeedDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE;
				}
				else if (cb == et_Death)
				{
					bit = hc.HENCH_EFFECT_TYPE_DEATH;
				}
				else if (cb == et_NegativeLevel)
				{
					bit = hc.HENCH_EFFECT_TYPE_NEGATIVELEVEL;
				}
				else if (cb == et_AcDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_AC_DECREASE;
				}
				else if (cb == et_SavingThrowDecrease)
				{
					bit = hc.HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE;
				}
				else if (cb == et_Knockdown)
				{
					bit = hc.HENCH_EFFECT_TYPE_KNOCKDOWN;
				}
				else if (cb == et_Dying)
				{
					bit = hc.HENCH_EFFECT_TYPE_DYING;
				}
				else if (cb == et_Mesmerize)
				{
					bit = hc.HENCH_EFFECT_TYPE_MESMERIZE;
				}
				else //if (cb == et_CutsceneParalyze)
				{
					bit = hc.HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE;
				}

				// TODO: Implement subsequently added effects like Wounded -
				// and teach the CoreAI to use them.

				if (cb.Checked)
				{
					effecttypes |= bit;
				}
				else
					effecttypes &= ~bit;

				EffectTypes_text.Text = effecttypes.ToString();
			}
		}
		#endregion eventhandlers


		#region setstate
		/// <summary>
		/// Sets the checkers on the EffectTypes page to reflect the current
		/// effecttypes value.
		/// </summary>
		/// <param name="effecttypes"></param>
		void state_EffectTypes(int effecttypes)
		{
// Beneficial Effects checkboxes
			et_AcIncrease         .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_AC_INCREASE)             != 0;
			et_Regenerate         .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_REGENERATE)              != 0;
			et_AttackIncrease     .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ATTACK_INCREASE)         != 0;
			et_DamageReduction    .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DAMAGE_REDUCTION)        != 0;
			et_Haste              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_HASTE)                   != 0;
			et_TempHitpoints      .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS)     != 0;
			et_Sanctuary          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SANCTUARY)               != 0;
			et_Timestop           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_TIMESTOP)                != 0;
			et_SpellAbsorption    .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION)    != 0;
			et_SavingThrowIncrease.Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE)   != 0;
			et_Concealment        .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_CONCEALMENT)             != 0;
			et_DamageIncrease     .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DAMAGE_INCREASE)         != 0;
			et_AbsorbDamage       .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ABSORBDAMAGE)            != 0;
			et_Ethereal           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ETHEREAL)                != 0;
			et_Invisibility       .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_INVISIBILITY)            != 0;
			et_Polymorph          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_POLYMORPH)               != 0;
			et_Ultravision        .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ULTRAVISION)             != 0;
			et_TrueSeeing         .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_TRUESEEING)              != 0;
			et_Wildshape          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_WILDSHAPE)               != 0;
			et_GreaterInvisibility.Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_GREATER_INVIS)           != 0;
			et_ElementalShield    .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ELEMENTALSHIELD)         != 0;
			et_AbilityIncrease    .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ABILITY_INCREASE)        != 0;
			et_SeeInvisible       .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SEEINVISIBLE)            != 0;
			et_SpellShield        .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SPELL_SHIELD)            != 0;
			et_ImmunityNecromancy .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY)       != 0;

// Detrimental Effects checkboxes
			et_Entangle           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ENTANGLE)                != 0;
			et_Paralyze           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_PARALYZE)                != 0;
			et_Deafness           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DEAF)                    != 0;
			et_Blindness          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_BLINDNESS)               != 0;
			et_Curse              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_CURSE)                   != 0;
			et_Sleep              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SLEEP)                   != 0;
			et_Charm              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_CHARMED)                 != 0;
			et_Confuse            .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_CONFUSED)                != 0;
			et_Frighten           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_FRIGHTENED)              != 0;
			et_Dominate           .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DOMINATED)               != 0;
			et_Daze               .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DAZED)                   != 0;
			et_Poison             .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_POISON)                  != 0;
			et_Disease            .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DISEASE)                 != 0;
			et_Silence            .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SILENCE)                 != 0;
			et_Slow               .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SLOW)                    != 0;
			et_AbilityDecrease    .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ABILITY_DECREASE)        != 0;
			et_DamageDecrease     .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DAMAGE_DECREASE)         != 0;
			et_AttackDecrease     .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_ATTACK_DECREASE)         != 0;
			et_SkillDecrease      .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SKILL_DECREASE)          != 0;
			et_Stun               .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_STUNNED)                 != 0;
			et_Petrify            .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_PETRIFY)                 != 0;
			et_SpeedDecrease      .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE) != 0;
			et_Death              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DEATH)                   != 0;
			et_NegativeLevel      .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_NEGATIVELEVEL)           != 0;
			et_AcDecrease         .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_AC_DECREASE)             != 0;
			et_SavingThrowDecrease.Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE)   != 0;
			et_Knockdown          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_KNOCKDOWN)               != 0;
			et_Dying              .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_DYING)                   != 0;
			et_Mesmerize          .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_MESMERIZE)               != 0;
			et_CutsceneParalyze   .Checked = (effecttypes & hc.HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE)       != 0;

			// test ->
			int roguebits = (effecttypes & ~et_legitbits);
			if (roguebits != 0)
			{
				et_RogueBits.Text = roguebits.ToString("X8");
				et_RogueBits   .Visible =
				et_la_RogueBits.Visible = true;
			}
			else
				et_RogueBits   .Visible =
				et_la_RogueBits.Visible = false;
		}

		const int et_legitbits = hc.HENCH_EFFECT_TYPE_AC_INCREASE				// 0x00000001 // all bits are legal -> (which are illegal depends on spelltype etc.)
							   | hc.HENCH_EFFECT_TYPE_REGENERATE				// 0x00000002
							   | hc.HENCH_EFFECT_TYPE_ATTACK_INCREASE			// 0x00000004
							   | hc.HENCH_EFFECT_TYPE_DAMAGE_REDUCTION			// 0x00000008
							   | hc.HENCH_EFFECT_TYPE_HASTE						// 0x00000010
							   | hc.HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS		// 0x00000020
							   | hc.HENCH_EFFECT_TYPE_SANCTUARY					// 0x00000040
							   | hc.HENCH_EFFECT_TYPE_TIMESTOP					// 0x00000080
							   | hc.HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION		// 0x00000100
							   | hc.HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE		// 0x00000200
							   | hc.HENCH_EFFECT_TYPE_CONCEALMENT				// 0x00000400
//							   | hc.HENCH_EFFECT_TYPE_SUMMON					// 0x00000800 <-
							   | hc.HENCH_EFFECT_TYPE_DAMAGE_INCREASE			// 0x00001000
							   | hc.HENCH_EFFECT_TYPE_ABSORBDAMAGE				// 0x00002000
							   | hc.HENCH_EFFECT_TYPE_ETHEREAL					// 0x00004000
							   | hc.HENCH_EFFECT_TYPE_INVISIBILITY				// 0x00008000
							   | hc.HENCH_EFFECT_TYPE_POLYMORPH					// 0x00010000
							   | hc.HENCH_EFFECT_TYPE_ULTRAVISION				// 0x00020000
							   | hc.HENCH_EFFECT_TYPE_TRUESEEING				// 0x00040000
							   | hc.HENCH_EFFECT_TYPE_WILDSHAPE					// 0x00080000
							   | hc.HENCH_EFFECT_TYPE_GREATER_INVIS				// 0x00100000
							   | hc.HENCH_EFFECT_TYPE_ELEMENTALSHIELD			// 0x00200000
							   | hc.HENCH_EFFECT_TYPE_ABILITY_INCREASE			// 0x00400000
							   | hc.HENCH_EFFECT_TYPE_SEEINVISIBLE				// 0x00800000

																				// 0x01000000 <-
																				// 0x02000000 <-
																				// 0x04000000 <-
																				// 0x08000000 <-
																				// 0x10000000 <-
																				// 0x20000000 <-

							   | hc.HENCH_EFFECT_TYPE_SPELL_SHIELD				// 0x40000000
							   | hc.HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY			// 0x80000000

							   | hc.HENCH_EFFECT_TYPE_ENTANGLE					// 0x00000001
							   | hc.HENCH_EFFECT_TYPE_PARALYZE					// 0x00000002
							   | hc.HENCH_EFFECT_TYPE_DEAF						// 0x00000004
							   | hc.HENCH_EFFECT_TYPE_BLINDNESS					// 0x00000008
							   | hc.HENCH_EFFECT_TYPE_CURSE						// 0x00000010
							   | hc.HENCH_EFFECT_TYPE_SLEEP						// 0x00000020
							   | hc.HENCH_EFFECT_TYPE_CHARMED					// 0x00000040
							   | hc.HENCH_EFFECT_TYPE_CONFUSED					// 0x00000080
							   | hc.HENCH_EFFECT_TYPE_FRIGHTENED				// 0x00000100
							   | hc.HENCH_EFFECT_TYPE_DOMINATED					// 0x00000200
							   | hc.HENCH_EFFECT_TYPE_DAZED						// 0x00000400
							   | hc.HENCH_EFFECT_TYPE_POISON					// 0x00000800
							   | hc.HENCH_EFFECT_TYPE_DISEASE					// 0x00001000
							   | hc.HENCH_EFFECT_TYPE_SILENCE					// 0x00002000
							   | hc.HENCH_EFFECT_TYPE_SLOW						// 0x00004000
							   | hc.HENCH_EFFECT_TYPE_ABILITY_DECREASE			// 0x00008000
							   | hc.HENCH_EFFECT_TYPE_DAMAGE_DECREASE			// 0x00010000
							   | hc.HENCH_EFFECT_TYPE_ATTACK_DECREASE			// 0x00020000
							   | hc.HENCH_EFFECT_TYPE_SKILL_DECREASE			// 0x00040000

																				// 0x00080000 <-

							   | hc.HENCH_EFFECT_TYPE_STUNNED					// 0x00100000
							   | hc.HENCH_EFFECT_TYPE_PETRIFY					// 0x00200000
							   | hc.HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE	// 0x00400000
							   | hc.HENCH_EFFECT_TYPE_DEATH						// 0x00800000
							   | hc.HENCH_EFFECT_TYPE_NEGATIVELEVEL				// 0x01000000
							   | hc.HENCH_EFFECT_TYPE_AC_DECREASE				// 0x02000000
							   | hc.HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE		// 0x04000000
							   | hc.HENCH_EFFECT_TYPE_KNOCKDOWN					// 0x08000000
							   | hc.HENCH_EFFECT_TYPE_DYING						// 0x10000000
							   | hc.HENCH_EFFECT_TYPE_MESMERIZE					// 0x20000000
//							   | hc.HENCH_EFFECT_TYPE_SPELL_FAILURE				// 0x40000000 <-
							   | hc.HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE;		// 0x80000000
		#endregion setstate
	}
}
