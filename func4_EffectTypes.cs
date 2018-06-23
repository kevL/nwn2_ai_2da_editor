using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// TODO:
	//
	// If spell needs to check ItemProperties then effecttypes will contain only the ItemProperty nwscript-constant.
	// SpellInfo SpellType - HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
	// eg. HenchCheckWeaponBuff() 'hench_i0_buff


	/// <summary>
	/// Functions for the EffectTypes page.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the EffectTypes page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_et(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_et() bypassTextChanged= " + bypassTextChanged);

			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
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
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.effecttypes = effecttypes;

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

					PrintCurrent(effecttypes, null, EffectTypes_hex, EffectTypes_bin);
				}

				if ((Spells[Id].differ & bit_effecttypes) != 0)
				{
					EffectTypes_reset.ForeColor = Color.Crimson;
				}
				else
					EffectTypes_reset.ForeColor = DefaultForeColor;

				CheckEffectTypesCheckers(effecttypes);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					si_Child2.Text = EffectTypes_text.Text;
				}
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
			if (SpellsChanged.ContainsKey(Id))
			{
				Spell spell = Spells[Id];
				spell.differ &= ~bit_effecttypes;
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

				EffectTypes_reset.ForeColor = DefaultForeColor;

				EffectTypes_text.Text = spell.spellinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the EffectTypes page - PositiveEffects group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_et_positiveeffects(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_et_positiveeffects()");
			//logfile.Log(". text= " + EffectTypes_text.Text);

			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
			{
				//logfile.Log(". . is valid Int32= " + effecttypes);

				int bit;

				var cb = sender as CheckBox;
				if (cb.Equals(et_AcIncrease))
				{
					bit = HENCH_EFFECT_TYPE_AC_INCREASE;
				}
				else if (cb.Equals(et_Regenerate))
				{
					bit = HENCH_EFFECT_TYPE_REGENERATE;
				}
				else if (cb.Equals(et_AttackIncrease))
				{
					bit = HENCH_EFFECT_TYPE_ATTACK_INCREASE;
				}
				else if (cb.Equals(et_DamageReduction))
				{
					bit = HENCH_EFFECT_TYPE_DAMAGE_REDUCTION;
				}
				else if (cb.Equals(et_Haste))
				{
					bit = HENCH_EFFECT_TYPE_HASTE;
				}
				else if (cb.Equals(et_TempHitpoints))
				{
					bit = HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS;
				}
				else if (cb.Equals(et_Sanctuary))
				{
					bit = HENCH_EFFECT_TYPE_SANCTUARY;
				}
				else if (cb.Equals(et_Timestop))
				{
					bit = HENCH_EFFECT_TYPE_TIMESTOP;
				}
				else if (cb.Equals(et_SpellAbsorption))
				{
					bit = HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION;
				}
				else if (cb.Equals(et_SavingThrowIncrease))
				{
					bit = HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE;
				}
				else if (cb.Equals(et_Concealment))
				{
					bit = HENCH_EFFECT_TYPE_CONCEALMENT;
				}
				else if (cb.Equals(et_DamageIncrease))
				{
					bit = HENCH_EFFECT_TYPE_DAMAGE_INCREASE;
				}
				else if (cb.Equals(et_AbsorbDamage))
				{
					bit = HENCH_EFFECT_TYPE_ABSORBDAMAGE;
				}
				else if (cb.Equals(et_Ethereal))
				{
					bit = HENCH_EFFECT_TYPE_ETHEREAL;
				}
				else if (cb.Equals(et_Invisibility))
				{
					bit = HENCH_EFFECT_TYPE_INVISIBILITY;
				}
				else if (cb.Equals(et_Polymorph))
				{
					bit = HENCH_EFFECT_TYPE_POLYMORPH;
				}
				else if (cb.Equals(et_Ultravision))
				{
					bit = HENCH_EFFECT_TYPE_ULTRAVISION;
				}
				else if (cb.Equals(et_TrueSeeing))
				{
					bit = HENCH_EFFECT_TYPE_TRUESEEING;
				}
				else if (cb.Equals(et_Wildshape))
				{
					bit = HENCH_EFFECT_TYPE_WILDSHAPE;
				}
				else if (cb.Equals(et_GreaterInvisibility))
				{
					bit = HENCH_EFFECT_TYPE_GREATER_INVIS;
				}
				else if (cb.Equals(et_ElementalShield))
				{
					bit = HENCH_EFFECT_TYPE_ELEMENTALSHIELD;
				}
				else if (cb.Equals(et_AbilityIncrease))
				{
					bit = HENCH_EFFECT_TYPE_ABILITY_INCREASE;
				}
				else if (cb.Equals(et_SeeInvisible))
				{
					bit = HENCH_EFFECT_TYPE_SEEINVISIBLE;
				}
				else if (cb.Equals(et_SpellShield))
				{
					bit = HENCH_EFFECT_TYPE_SPELL_SHIELD;
				}
				else //if (cb.Equals(et_ImmunityNecromancy))
				{
					bit = HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY;
				}

				if (cb.Checked)
				{
					effecttypes |= bit;
				}
				else
					effecttypes &= ~bit;

//				bypassCheckedChecker = true; // TODO: not sure about that - NegativeEffects should change also.
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
			//logfile.Log("MouseClick_et_negativeeffects()");
			//logfile.Log(". text= " + EffectTypes_text.Text);

			int effecttypes;
			if (Int32.TryParse(EffectTypes_text.Text, out effecttypes))
			{
				//logfile.Log(". . is valid Int32= " + effecttypes);

				int bit;

				var cb = sender as CheckBox;
				if (cb.Equals(et_Entangle))
				{
					bit = HENCH_EFFECT_TYPE_ENTANGLE;
				}
				else if (cb.Equals(et_Paralyze))
				{
					bit = HENCH_EFFECT_TYPE_PARALYZE;
				}
				else if (cb.Equals(et_Deafness))
				{
					bit = HENCH_EFFECT_TYPE_DEAF;
				}
				else if (cb.Equals(et_Blindness))
				{
					bit = HENCH_EFFECT_TYPE_BLINDNESS;
				}
				else if (cb.Equals(et_Curse))
				{
					bit = HENCH_EFFECT_TYPE_CURSE;
				}
				else if (cb.Equals(et_Sleep))
				{
					bit = HENCH_EFFECT_TYPE_SLEEP;
				}
				else if (cb.Equals(et_Charm))
				{
					bit = HENCH_EFFECT_TYPE_CHARMED;
				}
				else if (cb.Equals(et_Confuse))
				{
					bit = HENCH_EFFECT_TYPE_CONFUSED;
				}
				else if (cb.Equals(et_Frighten))
				{
					bit = HENCH_EFFECT_TYPE_FRIGHTENED;
				}
				else if (cb.Equals(et_Dominate))
				{
					bit = HENCH_EFFECT_TYPE_DOMINATED;
				}
				else if (cb.Equals(et_Daze))
				{
					bit = HENCH_EFFECT_TYPE_DAZED;
				}
				else if (cb.Equals(et_Poison))
				{
					bit = HENCH_EFFECT_TYPE_POISON;
				}
				else if (cb.Equals(et_Disease))
				{
					bit = HENCH_EFFECT_TYPE_DISEASE;
				}
				else if (cb.Equals(et_Silence))
				{
					bit = HENCH_EFFECT_TYPE_SILENCE;
				}
				else if (cb.Equals(et_Slow))
				{
					bit = HENCH_EFFECT_TYPE_SLOW;
				}
				else if (cb.Equals(et_AbilityDecrease))
				{
					bit = HENCH_EFFECT_TYPE_ABILITY_DECREASE;
				}
				else if (cb.Equals(et_DamageDecrease))
				{
					bit = HENCH_EFFECT_TYPE_DAMAGE_DECREASE;
				}
				else if (cb.Equals(et_AttackDecrease))
				{
					bit = HENCH_EFFECT_TYPE_ATTACK_DECREASE;
				}
				else if (cb.Equals(et_SkillDecrease))
				{
					bit = HENCH_EFFECT_TYPE_SKILL_DECREASE;
				}
				else if (cb.Equals(et_Stun))
				{
					bit = HENCH_EFFECT_TYPE_STUNNED;
				}
				else if (cb.Equals(et_Petrify))
				{
					bit = HENCH_EFFECT_TYPE_PETRIFY;
				}
				else if (cb.Equals(et_SpeedDecrease))
				{
					bit = HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE;
				}
				else if (cb.Equals(et_Death))
				{
					bit = HENCH_EFFECT_TYPE_DEATH;
				}
				else if (cb.Equals(et_NegativeLevel))
				{
					bit = HENCH_EFFECT_TYPE_NEGATIVELEVEL;
				}
				else if (cb.Equals(et_AcDecrease))
				{
					bit = HENCH_EFFECT_TYPE_AC_DECREASE;
				}
				else if (cb.Equals(et_SavingThrowDecrease))
				{
					bit = HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE;
				}
				else if (cb.Equals(et_Knockdown))
				{
					bit = HENCH_EFFECT_TYPE_KNOCKDOWN;
				}
				else if (cb.Equals(et_Dying))
				{
					bit = HENCH_EFFECT_TYPE_DYING;
				}
				else if (cb.Equals(et_Mesmerize))
				{
					bit = HENCH_EFFECT_TYPE_MESMERIZE;
				}
				else //if (cb.Equals(et_CutsceneParalyze))
				{
					bit = HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE;
				}

				// TODO: Implement subsequently added effects like Wounded -
				// and teach the CoreAI to use them.

				if (cb.Checked)
				{
					effecttypes |= bit;
				}
				else
					effecttypes &= ~bit;

//				bypassCheckedChecker = true; // TODO: not sure about that - PositiveEffects should change also.
				EffectTypes_text.Text = effecttypes.ToString();
			}
		}


		/// <summary>
		/// Sets the checkers on the EffectTypes page to reflect the current
		/// effecttypes value.
		/// </summary>
		/// <param name="effecttypes"></param>
		void CheckEffectTypesCheckers(int effecttypes)
		{
			//logfile.Log("CheckEffectTypesCheckers()");

			if (!bypassCheckedChecker)
			{
				//logfile.Log(". effecttypes= " + effecttypes);

				// PositiveEffects checkboxes
				et_AcIncrease         .Checked = (effecttypes & HENCH_EFFECT_TYPE_AC_INCREASE)           != 0;
				et_Regenerate         .Checked = (effecttypes & HENCH_EFFECT_TYPE_REGENERATE)            != 0;
				et_AttackIncrease     .Checked = (effecttypes & HENCH_EFFECT_TYPE_ATTACK_INCREASE)       != 0;
				et_DamageReduction    .Checked = (effecttypes & HENCH_EFFECT_TYPE_DAMAGE_REDUCTION)      != 0;
				et_Haste              .Checked = (effecttypes & HENCH_EFFECT_TYPE_HASTE)                 != 0;
				et_TempHitpoints      .Checked = (effecttypes & HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS)   != 0;
				et_Sanctuary          .Checked = (effecttypes & HENCH_EFFECT_TYPE_SANCTUARY)             != 0;
				et_Timestop           .Checked = (effecttypes & HENCH_EFFECT_TYPE_TIMESTOP)              != 0;
				et_SpellAbsorption    .Checked = (effecttypes & HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION)  != 0;
				et_SavingThrowIncrease.Checked = (effecttypes & HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE) != 0;
				et_Concealment        .Checked = (effecttypes & HENCH_EFFECT_TYPE_CONCEALMENT)           != 0;
				et_DamageIncrease     .Checked = (effecttypes & HENCH_EFFECT_TYPE_DAMAGE_INCREASE)       != 0;
				et_AbsorbDamage       .Checked = (effecttypes & HENCH_EFFECT_TYPE_ABSORBDAMAGE)          != 0;
				et_Ethereal           .Checked = (effecttypes & HENCH_EFFECT_TYPE_ETHEREAL)              != 0;
				et_Invisibility       .Checked = (effecttypes & HENCH_EFFECT_TYPE_INVISIBILITY)          != 0;
				et_Polymorph          .Checked = (effecttypes & HENCH_EFFECT_TYPE_POLYMORPH)             != 0;
				et_Ultravision        .Checked = (effecttypes & HENCH_EFFECT_TYPE_ULTRAVISION)           != 0;
				et_TrueSeeing         .Checked = (effecttypes & HENCH_EFFECT_TYPE_TRUESEEING)            != 0;
				et_Wildshape          .Checked = (effecttypes & HENCH_EFFECT_TYPE_WILDSHAPE)             != 0;
				et_GreaterInvisibility.Checked = (effecttypes & HENCH_EFFECT_TYPE_GREATER_INVIS)         != 0;
				et_ElementalShield    .Checked = (effecttypes & HENCH_EFFECT_TYPE_ELEMENTALSHIELD)       != 0;
				et_AbilityIncrease    .Checked = (effecttypes & HENCH_EFFECT_TYPE_ABILITY_INCREASE)      != 0;
				et_SeeInvisible       .Checked = (effecttypes & HENCH_EFFECT_TYPE_SEEINVISIBLE)          != 0;
				et_SpellShield        .Checked = (effecttypes & HENCH_EFFECT_TYPE_SPELL_SHIELD)          != 0;
				et_ImmunityNecromancy .Checked = (effecttypes & HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY)     != 0;

				// NegativeEffects checkboxes
				et_Entangle           .Checked = (effecttypes & HENCH_EFFECT_TYPE_ENTANGLE)                != 0;
				et_Paralyze           .Checked = (effecttypes & HENCH_EFFECT_TYPE_PARALYZE)                != 0;
				et_Deafness           .Checked = (effecttypes & HENCH_EFFECT_TYPE_DEAF)                    != 0;
				et_Blindness          .Checked = (effecttypes & HENCH_EFFECT_TYPE_BLINDNESS)               != 0;
				et_Curse              .Checked = (effecttypes & HENCH_EFFECT_TYPE_CURSE)                   != 0;
				et_Sleep              .Checked = (effecttypes & HENCH_EFFECT_TYPE_SLEEP)                   != 0;
				et_Charm              .Checked = (effecttypes & HENCH_EFFECT_TYPE_CHARMED)                 != 0;
				et_Confuse            .Checked = (effecttypes & HENCH_EFFECT_TYPE_CONFUSED)                != 0;
				et_Frighten           .Checked = (effecttypes & HENCH_EFFECT_TYPE_FRIGHTENED)              != 0;
				et_Dominate           .Checked = (effecttypes & HENCH_EFFECT_TYPE_DOMINATED)               != 0;
				et_Daze               .Checked = (effecttypes & HENCH_EFFECT_TYPE_DAZED)                   != 0;
				et_Poison             .Checked = (effecttypes & HENCH_EFFECT_TYPE_POISON)                  != 0;
				et_Disease            .Checked = (effecttypes & HENCH_EFFECT_TYPE_DISEASE)                 != 0;
				et_Silence            .Checked = (effecttypes & HENCH_EFFECT_TYPE_SILENCE)                 != 0;
				et_Slow               .Checked = (effecttypes & HENCH_EFFECT_TYPE_SLOW)                    != 0;
				et_AbilityDecrease    .Checked = (effecttypes & HENCH_EFFECT_TYPE_ABILITY_DECREASE)        != 0;
				et_DamageDecrease     .Checked = (effecttypes & HENCH_EFFECT_TYPE_DAMAGE_DECREASE)         != 0;
				et_AttackDecrease     .Checked = (effecttypes & HENCH_EFFECT_TYPE_ATTACK_DECREASE)         != 0;
				et_SkillDecrease      .Checked = (effecttypes & HENCH_EFFECT_TYPE_SKILL_DECREASE)          != 0;
				et_Stun               .Checked = (effecttypes & HENCH_EFFECT_TYPE_STUNNED)                 != 0;
				et_Petrify            .Checked = (effecttypes & HENCH_EFFECT_TYPE_PETRIFY)                 != 0;
				et_SpeedDecrease      .Checked = (effecttypes & HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE) != 0;
				et_Death              .Checked = (effecttypes & HENCH_EFFECT_TYPE_DEATH)                   != 0;
				et_NegativeLevel      .Checked = (effecttypes & HENCH_EFFECT_TYPE_NEGATIVELEVEL)           != 0;
				et_AcDecrease         .Checked = (effecttypes & HENCH_EFFECT_TYPE_AC_DECREASE)             != 0;
				et_SavingThrowDecrease.Checked = (effecttypes & HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE)   != 0;
				et_Knockdown          .Checked = (effecttypes & HENCH_EFFECT_TYPE_KNOCKDOWN)               != 0;
				et_Dying              .Checked = (effecttypes & HENCH_EFFECT_TYPE_DYING)                   != 0;
				et_Mesmerize          .Checked = (effecttypes & HENCH_EFFECT_TYPE_MESMERIZE)               != 0;
				et_CutsceneParalyze   .Checked = (effecttypes & HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE)       != 0;
			}
			else
			{
				//logfile.Log(". bypassed");
				bypassCheckedChecker = false;
			}
		}
	}
}
