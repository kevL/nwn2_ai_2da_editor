using System;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Constants with vars and vals that are equivalent to those in the Core AI
	/// scripts.
	/// </summary>
	/// <remarks>The vars could be different in your CoreAI scripts (because I
	/// could change identifiers to make things readable) but the appropriate
	/// values ought stay equivalent.</remarks>
	static class hc // -> short for "HenchConstants"
	{
		#region SpellInfo
		// 'hench_i0_generic'
		// NOTE: InfoVersion has been taken out of TonyAI 2.3+
		// The mask (and shift) in the HenchEditor here is used only if the user
		// chooses to delete all old InfoVersion bits from their 2das. But
		// that's not recommended for those who don't know what they're doing
		// since the bits have been repurposed for spontaneous metamagic by
		// those spells that are capable of being spontaneously cast.
		//
		// The recommended route is to start with the HenchSpells.2da that's in
		// the latest TonyAI and do any customizations from there. That is, do
		// diffs of your custom HenchSpells.2da against the TonyAI 2.2
		// HenchSpells.2da and judiciously merge that diff into the TonyAI 2.3+
		// HenchSpells.2da ...

//		internal const int HENCH_SPELL_INFO_VERSION                      = 0x16000000; // not needed in TonyAI 2.3+
		internal const int HENCH_SPELL_INFO_VERSION_MASK                 = unchecked((int)0xff000000); // -16777216 fu.net

		// 'hench_i0_itemsp'
		internal const int HENCH_SPELL_INFO_SPELL_LEVEL_MASK             = 0x0001e000; // shift >> 13
		internal const int HENCH_SPELL_INFO_SPELL_LEVEL_SHIFT            = 13;         // NOTE: spelllevel is set auto in TonyAI 2.3+

		internal const int HENCH_SPELL_INFO_MASTER_FLAG                  = 0x00000100;
		internal const int HENCH_SPELL_INFO_IGNORE_FLAG                  = 0x00000200;
		internal const int HENCH_SPELL_INFO_CONCENTRATION_FLAG           = 0x00000400; // NOTE: is set auto in TonyAI 2.3+
		internal const int HENCH_SPELL_INFO_UNLIMITED_FLAG               = 0x00000800;
//		internal const int HENCH_SPELL_INFO_NO_VERBAL                    = 0x00001000; // TonyAI 2.3+ add - NOTE: is set auto

		internal const int HENCH_SPELL_INFO_HEAL_OR_CURE                 = 0x00020000;
		internal const int HENCH_SPELL_INFO_SHORT_DUR_BUFF               = 0x00040000;
		internal const int HENCH_SPELL_INFO_MEDIUM_DUR_BUFF              = 0x00080000;
		internal const int HENCH_SPELL_INFO_LONG_DUR_BUFF                = 0x00100000;

		internal const int HENCH_SPELL_INFO_ITEM_FLAG                    = 0x00800000;

		internal const int HENCH_SPELL_INFO_EXTEND_OK                    = 0x01000000; // TonyAI 2.3+ add ->
		internal const int HENCH_SPELL_INFO_PERSIST_OK                   = 0x02000000;
		internal const int HENCH_SPELL_INFO_EMPOWER_OK                   = 0x04000000;
		internal const int HENCH_SPELL_INFO_MAXIMIZE_OK                  = 0x08000000;


		internal const int HENCH_SPELL_INFO_SPELL_TYPE_MASK              = 0x000000ff; // actually 0x0000003f

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ATTACK            = 0x00000001; //  1 (detrimental-type) on EffectTypes page ->
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_HARM              = 0x0000000b; // 11
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER     = 0x0000000f; // 15
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH     = 0x00000011; // 17
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK           = 0x00000013; // 19 - not used by the AI. Cf SaveType HENCH_ATTACK_CHECK_WARLOCK
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ATTACK_SPECIAL    = 0x00000021; // 33

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_DISPEL            = 0x00000006; //  6 (dispel-type) on DamageInfo page

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ENGR_PROT         = 0x0000000d; // 13 (energy immunity/resistance type) on SaveType page ->
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ELEMENTAL_SHIELD  = 0x0000001b; // 27

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF       = 0x00000015; // 21

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF           = 0x00000002; //  2
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_BUFF              = 0x00000003; //  3

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_SUMMON            = 0x00000009; //  9

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_SPELL_PROT        = 0x00000010; // 16

		internal const int HENCH_SPELL_INFO_SPELL_TYPE_HEAL              = 0x0000000a; // 10
		internal const int HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE          = 0x00000014; // 20

		// 'hench_i0_itemsp'
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_PERSISTENTAREA    = 0x00000004; //  4
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_POLYMORPH         = 0x00000005; //  5
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_INVISIBLE         = 0x00000007; //  7
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_CURECONDITION     = 0x00000008; //  8
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_ATTR_BUFF         = 0x0000000c; // 12
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_MELEE_ATTACK      = 0x0000000e; // 14
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_DETECT_INVIS      = 0x00000012; // 18
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_BUFF_ANIMAL_COMP  = 0x00000016; // 22
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_PROT_EVIL         = 0x00000017; // 23
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_PROT_GOOD         = 0x00000018; // 24
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_REGENERATE        = 0x00000019; // 25
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_GUST_OF_WIND      = 0x0000001a; // 26
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_TURN_UNDEAD       = 0x0000001c; // 28
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_DR_BUFF           = 0x0000001d; // 29
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_MELEE_ATTACK_BUFF = 0x0000001e; // 30
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_RAISE_DEAD        = 0x0000001f; // 31
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_CONCEALMENT       = 0x00000020; // 32
//		internal const int HENCH_SPELL_INFO_SPELL_TYPE_HEAL_SPECIAL      = 0x00000022; // 34

		// TODO: 'hench_i0_itemsp' CheckAOEForSelf() uses the following construction:
//		int iSpellInfo = GetSpellInfo(iAoeInfo & HENCH_PERSIST_SPELL_MASK);
//		if ((iSpellInfo & HENCH_SPELL_TARGET_RANGE_MASK) == HENCH_SPELL_TARGET_RANGE_PERSONAL)
		//
		// but it looks absolutely bogus. Range-type info is a property of TargetInfo not SpellInfo.
		#endregion SpellInfo



		#region TargetInfo
		internal const int HENCH_SPELL_TARGET_SHAPE_LOOP           = 0x00010000;
		internal const int HENCH_SPELL_TARGET_CHECK_COUNT          = 0x00020000;
		internal const int HENCH_SPELL_TARGET_MISSILE_TARGETS      = 0x00040000;
		internal const int HENCH_SPELL_TARGET_SECONDARY_TARGETS    = 0x00080000;
		internal const int HENCH_SPELL_TARGET_SECONDARY_HALF_DAM   = 0x00100000;
		internal const int HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG    = 0x00200000;
		internal const int HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG = 0x00400000;
		internal const int HENCH_SPELL_TARGET_PERSISTENT_SPELL     = 0x00800000;
		internal const int HENCH_SPELL_TARGET_SCALE_EFFECT         = 0x01000000;
		internal const int HENCH_SPELL_TARGET_NECROMANCY_SPELL     = 0x02000000;
		internal const int HENCH_SPELL_TARGET_REGULAR_SPELL        = 0x04000000;

		internal const int HENCH_SPELL_TARGET_SHAPE_MASK           = 0x00000007;

		internal const int HENCH_SPELL_TARGET_RANGE_MASK           = 0x00000038; // shift >> 3 (psst. no need)
		internal const int HENCH_SPELL_TARGET_RANGE_PERSONAL       = 0x00000000;
		internal const int HENCH_SPELL_TARGET_RANGE_TOUCH          = 0x00000008;
		internal const int HENCH_SPELL_TARGET_RANGE_SHORT          = 0x00000010;
		internal const int HENCH_SPELL_TARGET_RANGE_MEDIUM         = 0x00000018;
		internal const int HENCH_SPELL_TARGET_RANGE_LONG           = 0x00000020;
		internal const int HENCH_SPELL_TARGET_RANGE_INFINITE       = 0x00000028;

		internal const int HENCH_SPELL_TARGET_RADIUS_MASK          = 0x0000ffc0; // shift >> 6 / 10 bits, radius * 10

		// 'hench_i0_spells'
		// stock NwScript constants:
//		int SHAPE_SPELLCYLINDER                                    = 0; // standard spell shapes in nwscript.nss ->
//		int SHAPE_CONE                                             = 1;
//		int SHAPE_CUBE                                             = 2;
//		int SHAPE_SPELLCONE                                        = 3;
//		int SHAPE_SPHERE                                           = 4;

//		internal const int HENCH_SHAPE_FACTION                     = 6; // indicates faction targets
//		internal const int HENCH_SHAPE_NONE                        = 7; // indicates no shape
		#endregion TargetInfo



		#region EffectTypes
//		internal const int HENCH_EFFECT_TYPE_NONE                    = 0x00000000;

		// Beneficial effects
		internal const int HENCH_EFFECT_TYPE_AC_INCREASE             = 0x00000001;
		internal const int HENCH_EFFECT_TYPE_REGENERATE              = 0x00000002;
		internal const int HENCH_EFFECT_TYPE_ATTACK_INCREASE         = 0x00000004;
		internal const int HENCH_EFFECT_TYPE_DAMAGE_REDUCTION        = 0x00000008;
		internal const int HENCH_EFFECT_TYPE_HASTE                   = 0x00000010;
		internal const int HENCH_EFFECT_TYPE_TEMPORARY_HITPOINTS     = 0x00000020;
		internal const int HENCH_EFFECT_TYPE_SANCTUARY               = 0x00000040;
		internal const int HENCH_EFFECT_TYPE_TIMESTOP                = 0x00000080;
		internal const int HENCH_EFFECT_TYPE_SPELLLEVELABSORPTION    = 0x00000100;
		internal const int HENCH_EFFECT_TYPE_SAVING_THROW_INCREASE   = 0x00000200;
		internal const int HENCH_EFFECT_TYPE_CONCEALMENT             = 0x00000400;
//		internal const int HENCH_EFFECT_TYPE_SUMMON                  = 0x00000800; // not used in CoreAI
		internal const int HENCH_EFFECT_TYPE_DAMAGE_INCREASE         = 0x00001000;
		internal const int HENCH_EFFECT_TYPE_ABSORBDAMAGE            = 0x00002000;
		internal const int HENCH_EFFECT_TYPE_ETHEREAL                = 0x00004000;
		internal const int HENCH_EFFECT_TYPE_INVISIBILITY            = 0x00008000;
		internal const int HENCH_EFFECT_TYPE_POLYMORPH               = 0x00010000;
		internal const int HENCH_EFFECT_TYPE_ULTRAVISION             = 0x00020000;
		internal const int HENCH_EFFECT_TYPE_TRUESEEING              = 0x00040000;
		internal const int HENCH_EFFECT_TYPE_WILDSHAPE               = 0x00080000;
		internal const int HENCH_EFFECT_TYPE_GREATER_INVIS           = 0x00100000;
		internal const int HENCH_EFFECT_TYPE_ELEMENTALSHIELD         = 0x00200000;
		internal const int HENCH_EFFECT_TYPE_ABILITY_INCREASE        = 0x00400000;
		internal const int HENCH_EFFECT_TYPE_SEEINVISIBLE            = 0x00800000;

		internal const int HENCH_EFFECT_TYPE_SPELL_SHIELD            = 0x40000000;
		internal const int HENCH_EFFECT_TYPE_IMMUNE_NECROMANCY       = unchecked((int)0x80000000); // -2147483648 fu.net


		// Detrimental effects
		internal const int HENCH_EFFECT_TYPE_ENTANGLE                = 0x00000001;
		internal const int HENCH_EFFECT_TYPE_PARALYZE                = 0x00000002;
		internal const int HENCH_EFFECT_TYPE_DEAF                    = 0x00000004;
		internal const int HENCH_EFFECT_TYPE_BLINDNESS               = 0x00000008;
		internal const int HENCH_EFFECT_TYPE_CURSE                   = 0x00000010;
		internal const int HENCH_EFFECT_TYPE_SLEEP                   = 0x00000020;
		internal const int HENCH_EFFECT_TYPE_CHARMED                 = 0x00000040;
		internal const int HENCH_EFFECT_TYPE_CONFUSED                = 0x00000080;
		internal const int HENCH_EFFECT_TYPE_FRIGHTENED              = 0x00000100;
		internal const int HENCH_EFFECT_TYPE_DOMINATED               = 0x00000200;
		internal const int HENCH_EFFECT_TYPE_DAZED                   = 0x00000400;
		internal const int HENCH_EFFECT_TYPE_POISON                  = 0x00000800;
		internal const int HENCH_EFFECT_TYPE_DISEASE                 = 0x00001000;
		internal const int HENCH_EFFECT_TYPE_SILENCE                 = 0x00002000;
		internal const int HENCH_EFFECT_TYPE_SLOW                    = 0x00004000;
		internal const int HENCH_EFFECT_TYPE_ABILITY_DECREASE        = 0x00008000;
		internal const int HENCH_EFFECT_TYPE_DAMAGE_DECREASE         = 0x00010000;
		internal const int HENCH_EFFECT_TYPE_ATTACK_DECREASE         = 0x00020000;
		internal const int HENCH_EFFECT_TYPE_SKILL_DECREASE          = 0x00040000;

		internal const int HENCH_EFFECT_TYPE_STUNNED                 = 0x00100000;
		internal const int HENCH_EFFECT_TYPE_PETRIFY                 = 0x00200000;
		internal const int HENCH_EFFECT_TYPE_MOVEMENT_SPEED_DECREASE = 0x00400000;
		internal const int HENCH_EFFECT_TYPE_DEATH                   = 0x00800000;
		internal const int HENCH_EFFECT_TYPE_NEGATIVELEVEL           = 0x01000000;
		internal const int HENCH_EFFECT_TYPE_AC_DECREASE             = 0x02000000;
		internal const int HENCH_EFFECT_TYPE_SAVING_THROW_DECREASE   = 0x04000000;
		internal const int HENCH_EFFECT_TYPE_KNOCKDOWN               = 0x08000000;
		internal const int HENCH_EFFECT_TYPE_DYING                   = 0x10000000;
		internal const int HENCH_EFFECT_TYPE_MESMERIZE               = 0x20000000;
//		internal const int HENCH_EFFECT_TYPE_SPELL_FAILURE           = 0x40000000;
		internal const int HENCH_EFFECT_TYPE_CUTSCENE_PARALYZE       = unchecked((int)0x80000000); // -2147483648 fu.net
		#endregion EffectTypes



		#region DamageInfo
		// Group 1 - dispel type
		// These are used by 'hench_i0_dispel' HenchCheckDispel()
		// by
		// DispatchSpell() 'hench_i0_itemsp' SpellInfo spelltype - HENCH_SPELL_INFO_SPELL_TYPE_DISPEL

		internal const int HENCH_SPELL_INFO_DAMAGE_BREACH           = 0x00000001;
		internal const int HENCH_SPELL_INFO_DAMAGE_DISPEL           = 0x00000002;
		internal const int HENCH_SPELL_INFO_DAMAGE_RESIST           = 0x00000004;

		// Group 2 - BENEFICIAL-type (Buff)
		// These are used by 'hench_i0_spells' GetCurrentSpellBuffAmount()
		// by
		//
		// DispatchSpell() 'hench_i0_itemsp'
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_ATTACK
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_HEAL
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_HARM
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE
		//   HenchSpellAttack() 'hench_i0_attack' TargetInfo (iTargetInfo & HENCH_SPELL_TARGET_SCALE_EFFECT)
		//
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF
		//   HenchCheckACBuff() 'hench_i0_buff'

		// InitializeSpellTalents() 'hench_i0_itemsp'
		//   CheckSpontaneousCureOrInflictSpell() 'hench_i0_itemsp'
		//   CheckSpontaneousMassCureOrInflictSpell() 'hench_i0_itemsp'

		// InitializeWarlockAttackSpells() 'hench_i0_itemsp'
		//   InitializeWarlockAttackSpell() 'hench_i0_itemsp'

		internal const int HENCH_SPELL_INFO_BUFF_AMOUNT_MASK        = 0x000000ff;
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_LIMIT_MASK   = 0x00003f00;
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_MASK    = 0x0000c000;

		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_DICE    = 0x00000000;
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_ADJ     = 0x00004000;
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_COUNT   = 0x00008000; // not used in CoreAI.
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_TYPE_CONST   = 0x0000c000;

		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_DIV_MASK     = 0x000f0000;
		internal const int HENCH_SPELL_INFO_BUFF_LEVEL_DECR_MASK    = 0x00f00000;
		internal const int HENCH_SPELL_INFO_BUFF_MASK               = 0x0f000000;

		internal const int HENCH_SPELL_INFO_BUFF_CASTER_LEVEL       = 0x01000000;
		internal const int HENCH_SPELL_INFO_BUFF_HD_LEVEL           = 0x02000000;
		internal const int HENCH_SPELL_INFO_BUFF_FIXED              = 0x03000000;
		internal const int HENCH_SPELL_INFO_BUFF_CHARISMA           = 0x0b000000;
		internal const int HENCH_SPELL_INFO_BUFF_BARD_LEVEL         = 0x0c000000; // not used in CoreAI.
		internal const int HENCH_SPELL_INFO_BUFF_DRAGON             = 0x0d000000;

		// Group 3 - DETRIMENTAL-type (Damage)
		// These are used by 'hench_i0_spells' GetCurrentSpellDamage()
		// by
		//
		// DispatchSpell() 'hench_i0_itemsp'
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_ATTACK
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_HEAL
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_HARM
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE
		//   HenchSpellAttack() 'hench_i0_attack' TargetInfo !(iTargetInfo & HENCH_SPELL_TARGET_SCALE_EFFECT)
		//       [see above ..]
		//
		//     spelltype - HENCH_SPELL_INFO_SPELL_TYPE_ELEMENTAL_SHIELD
		//   HenchCheckElementalShield() 'hench_i0_buff'
		//

//		internal const int HENCH_SPELL_INFO_DAMAGE_TYPE_MASK        = 0x00000fff;

		// NwScript DAMAGE_TYPE_* constants: (also used by SaveType - Exclusive)
//		internal const int DAMAGE_TYPE_ALL                          = 0;          //    Deprecated.
		internal const int DAMAGE_TYPE_BLUDGEONING                  = 0x00000001; //    1
		internal const int DAMAGE_TYPE_PIERCING                     = 0x00000002; //    2
		internal const int DAMAGE_TYPE_SLASHING                     = 0x00000004; //    4
		internal const int DAMAGE_TYPE_MAGICAL                      = 0x00000008; //    8
		internal const int DAMAGE_TYPE_ACID                         = 0x00000010; //   16
		internal const int DAMAGE_TYPE_COLD                         = 0x00000020; //   32
		internal const int DAMAGE_TYPE_DIVINE                       = 0x00000040; //   64
		internal const int DAMAGE_TYPE_ELECTRICAL                   = 0x00000080; //  128
		internal const int DAMAGE_TYPE_FIRE                         = 0x00000100; //  256
		internal const int DAMAGE_TYPE_NEGATIVE                     = 0x00000200; //  512
		internal const int DAMAGE_TYPE_POSITIVE                     = 0x00000400; // 1024
		internal const int DAMAGE_TYPE_SONIC                        = 0x00000800; // 2048

		internal const int HENCH_SPELL_INFO_DAMAGE_AMOUNT_MASK      = 0x000ff000;
		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_LIMIT_MASK = 0x00f00000;
		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_MASK  = 0x03000000; // NOTE: Overlaps FixedCount

		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_DICE  = 0x00000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_ADJ   = 0x01000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_COUNT = 0x02000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_TYPE_CONST = 0x03000000;

		internal const int HENCH_SPELL_INFO_DAMAGE_LEVEL_DIV_MASK   = 0x0c000000; // NOTE: Overlaps FixedCount
		internal const int HENCH_SPELL_INFO_DAMAGE_FIXED_COUNT      = 0x0f000000; // NOTE: Overlaps LevelType and LevelDivisor

		internal const int HENCH_SPELL_INFO_DAMAGE_MASK             = unchecked((int)0xf0000000);

		internal const int HENCH_SPELL_INFO_DAMAGE_CASTER_LEVEL     = 0x00000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_HD_LEVEL         = 0x10000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_FIXED            = 0x20000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_CURE             = 0x30000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_DRAGON           = 0x40000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_SPECIAL_COUNT    = 0x50000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_CUSTOM           = 0x60000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_DRAG_DISC        = 0x70000000;
		internal const int HENCH_SPELL_INFO_DAMAGE_AA_LEVEL         = unchecked((int)0x80000000);
		internal const int HENCH_SPELL_INFO_DAMAGE_WP_LEVEL         = unchecked((int)0x90000000); // not used in CoreAI.
		internal const int HENCH_SPELL_INFO_DAMAGE_LAY_ON_HANDS     = unchecked((int)0xa0000000);
		internal const int HENCH_SPELL_INFO_DAMAGE_CHARISMA         = unchecked((int)0xb0000000);
		internal const int HENCH_SPELL_INFO_DAMAGE_BARD_PERFORM     = unchecked((int)0xc0000000);
		internal const int HENCH_SPELL_INFO_DAMAGE_WARLOCK          = unchecked((int)0xd0000000);
		#endregion DamageInfo



		#region SaveType
		// Immunity types
//		internal const int HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK       =                       0x00000fc0;
//		internal const int HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK       =                                     0x0003f000;
		// stock NwScript constants:
//		internal const int IMMUNITY_TYPE_NONE                         = 0x00000000; //  0; // shift >> 6 // shift >> 12
//		internal const int IMMUNITY_TYPE_MIND_SPELLS                  = 0x00000001; //  1; // 0x00000040 // 0x00001000 // this overlaps the bit for HENCH_WEAPON_DRUID_FLAG
//		internal const int IMMUNITY_TYPE_POISON                       = 0x00000002; //  2; // 0x00000080 // 0x00002000
//		internal const int IMMUNITY_TYPE_DISEASE                      = 0x00000003; //  3; // 0x000000c0 // 0x00003000
//		internal const int IMMUNITY_TYPE_FEAR                         = 0x00000004; //  4; // 0x00000100 // 0x00004000
//		internal const int IMMUNITY_TYPE_TRAP                         = 0x00000005; //  5; // 0x00000140 // 0x00005000
//		internal const int IMMUNITY_TYPE_PARALYSIS                    = 0x00000006; //  6; // 0x00000180 // 0x00006000
//		internal const int IMMUNITY_TYPE_BLINDNESS                    = 0x00000007; //  7; // 0x000001c0 // 0x00007000
//		internal const int IMMUNITY_TYPE_DEAFNESS                     = 0x00000008; //  8; // 0x00000200 // 0x00008000
//		internal const int IMMUNITY_TYPE_SLOW                         = 0x00000009; //  9; // 0x00000240 // 0x00009000
//		internal const int IMMUNITY_TYPE_ENTANGLE                     = 0x0000000a; // 10; // 0x00000280 // 0x0000a000
//		internal const int IMMUNITY_TYPE_SILENCE                      = 0x0000000b; // 11; // 0x000002c0 // 0x0000b000
//		internal const int IMMUNITY_TYPE_STUN                         = 0x0000000c; // 12; // 0x00000300 // 0x0000c000
//		internal const int IMMUNITY_TYPE_SLEEP                        = 0x0000000d; // 13; // 0x00000340 // 0x0000d000
//		internal const int IMMUNITY_TYPE_CHARM                        = 0x0000000e; // 14; // 0x00000380 // 0x0000e000
//		internal const int IMMUNITY_TYPE_DOMINATE                     = 0x0000000f; // 15; // 0x000003c0 // 0x0000f000
//		internal const int IMMUNITY_TYPE_CONFUSED                     = 0x00000010; // 16; // 0x00000400 // 0x00010000
//		internal const int IMMUNITY_TYPE_CURSED                       = 0x00000011; // 17; // 0x00000440 // 0x00011000
//		internal const int IMMUNITY_TYPE_DAZED                        = 0x00000012; // 18; // 0x00000480 // 0x00012000
//		internal const int IMMUNITY_TYPE_ABILITY_DECREASE             = 0x00000013; // 19; // 0x000004c0 // 0x00013000
//		internal const int IMMUNITY_TYPE_ATTACK_DECREASE              = 0x00000014; // 20; // 0x00000500 // 0x00014000
//		internal const int IMMUNITY_TYPE_DAMAGE_DECREASE              = 0x00000015; // 21; // 0x00000540 // 0x00015000
//		internal const int IMMUNITY_TYPE_DAMAGE_IMMUNITY_DECREASE     = 0x00000016; // 22; // 0x00000580 // 0x00016000
//		internal const int IMMUNITY_TYPE_AC_DECREASE                  = 0x00000017; // 23; // 0x000005c0 // 0x00017000
//		internal const int IMMUNITY_TYPE_MOVEMENT_SPEED_DECREASE      = 0x00000018; // 24; // 0x00000600 // 0x00018000
//		internal const int IMMUNITY_TYPE_SAVING_THROW_DECREASE        = 0x00000019; // 25; // 0x00000640 // 0x00019000
//		internal const int IMMUNITY_TYPE_SPELL_RESISTANCE_DECREASE    = 0x0000001a; // 26; // 0x00000680 // 0x0001a000
//		internal const int IMMUNITY_TYPE_SKILL_DECREASE               = 0x0000001b; // 27; // 0x000006c0 // 0x0001b000
//		internal const int IMMUNITY_TYPE_KNOCKDOWN                    = 0x0000001c; // 28; // 0x00000700 // 0x0001c000
//		internal const int IMMUNITY_TYPE_NEGATIVE_LEVEL               = 0x0000001d; // 29; // 0x00000740 // 0x0001d000
//		internal const int IMMUNITY_TYPE_SNEAK_ATTACK                 = 0x0000001e; // 30; // 0x00000780 // 0x0001e000
//		internal const int IMMUNITY_TYPE_CRITICAL_HIT                 = 0x0000001f; // 31; // 0x000007c0 // 0x0001f000
//		internal const int IMMUNITY_TYPE_DEATH                        = 0x00000020; // 32; // 0x00000800 // 0x00020000

		// Specific types - CoreAI constants
		// 'hench_i0_attack'
//		internal const int HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK          = 0x0000003f;

//		internal const int HENCH_ATTACK_NO_CHECK                      = 0x00000000; //  0 // These 50 are iSaveType constants ->
//		internal const int HENCH_ATTACK_CHECK_HEAL                    = 0x00000001; //  1 // Lovely. It looks like they did it again.
//		internal const int HENCH_ATTACK_CHECK_NEG_HEALING             = 0x00000002; //  2 // iSaveType appears to be dual-purposed
//		internal const int HENCH_ATTACK_CHECK_HUMANOID                = 0x00000003; //  3 // with overlapping values between these
//		internal const int HENCH_ATTACK_CHECK_NOT_ALREADY_EFFECTED    = 0x00000004; //  4 // and SaveType (Weapon-type) values.
//		internal const int HENCH_ATTACK_CHECK_INCORPOREAL             = 0x00000005; //  5 // cf. HENCH_WEAPON_* in 'hench_i0_buff'
//		internal const int HENCH_ATTACK_CHECK_DARKNESS                = 0x00000006; //  6
//		internal const int HENCH_ATTACK_CHECK_PETRIFY                 = 0x00000007; //  7
//		internal const int HENCH_ATTACK_CHECK_ANIMAL                  = 0x00000008; //  8
//		internal const int HENCH_ATTACK_CHECK_NOT_CONSTRUCT_OR_UNDEAD = 0x00000009; //  9
//		internal const int HENCH_ATTACK_CHECK_DROWN                   = 0x0000000a; // 10
//		internal const int HENCH_ATTACK_CHECK_SLEEP                   = 0x0000000b; // 11
//		internal const int HENCH_ATTACK_CHECK_BIGBY                   = 0x0000000c; // 12
//		internal const int HENCH_ATTACK_CHECK_UNDEAD                  = 0x0000000d; // 13
//		internal const int HENCH_ATTACK_CHECK_NOT_UNDEAD              = 0x0000000e; // 14
//		internal const int HENCH_ATTACK_CHECK_IMMUNITY_PHANTASMS      = 0x0000000f; // 15
//		internal const int HENCH_ATTACK_CHECK_MAGIC_MISSLE            = 0x00000010; // 16
//		internal const int HENCH_ATTACK_CHECK_INFERNO_OR_COMBUST      = 0x00000011; // 17
//		internal const int HENCH_ATTACK_CHECK_DISMISSAL_OR_BANISHMENT = 0x00000012; // 18
//		internal const int HENCH_ATTACK_CHECK_SPELLCASTER             = 0x00000013; // 19
//		internal const int HENCH_ATTACK_CHECK_NOT_ELF                 = 0x00000014; // 20
//		internal const int HENCH_ATTACK_CHECK_CONSTRUCT               = 0x00000015; // 21
//		internal const int HENCH_ATTACK_CHECK_SEARING_LIGHT           = 0x00000016; // 22
//		internal const int HENCH_ATTACK_CHECK_MINDBLAST               = 0x00000017; // 23
//		internal const int HENCH_ATTACK_CHECK_EVARDS_TENTACLES        = 0x00000018; // 24
//		internal const int HENCH_ATTACK_CHECK_IRONHORN                = 0x00000019; // 25
//		internal const int HENCH_ATTACK_CHECK_PRISM                   = 0x0000001a; // 26
//		internal const int HENCH_ATTACK_CHECK_SPIRIT                  = 0x0000001b; // 27
//		internal const int HENCH_ATTACK_CHECK_WORDOFFAITH             = 0x0000001c; // 28
//		internal const int HENCH_ATTACK_CHECK_CLOUDKILL               = 0x0000001d; // 29
//		internal const int HENCH_ATTACK_CHECK_HUMANOID_OR_ANIMAL      = 0x0000001e; // 30
//		internal const int HENCH_ATTACK_CHECK_DAZE                    = 0x0000001f; // 31
//		internal const int HENCH_ATTACK_CHECK_TASHAS                  = 0x00000020; // 32
//		internal const int HENCH_ATTACK_CHECK_CAUSE_FEAR              = 0x00000021; // 33
//		internal const int HENCH_ATTACK_CHECK_PERCENTAGE              = 0x00000022; // 34
//		internal const int HENCH_ATTACK_CHECK_CREEPING_DOOM           = 0x00000023; // 35
//		internal const int HENCH_ATTACK_CHECK_DEATH_KNELL             = 0x00000024; // 36
//		internal const int HENCH_ATTACK_CHECK_WARLOCK                 = 0x00000025; // 37 Cf SpellInfo HENCH_SPELL_INFO_SPELL_TYPE_WARLOCK
//		internal const int HENCH_ATTACK_CHECK_MOONBOLT                = 0x00000026; // 38
//		internal const int HENCH_ATTACK_CHECK_SWAMPLUNG               = 0x00000027; // 39
//		internal const int HENCH_ATTACK_CHECK_SEEN                    = 0x00000028; // 40
//		internal const int HENCH_ATTACK_CHECK_COLOR_SPRAY             = 0x00000029; // 41
//		internal const int HENCH_ATTACK_CHECK_SUNBEAM                 = 0x0000002a; // 42
//		internal const int HENCH_ATTACK_CHECK_SUNBURST                = 0x0000002b; // 43
//		internal const int HENCH_ATTACK_CHECK_MEDIUM                  = 0x0000002c; // 44
//		internal const int HENCH_ATTACK_CHECK_CASTIGATE               = 0x0000002d; // 45
//		internal const int HENCH_ATTACK_CHECK_FIGHTER                 = 0x0000002e; // 46
//		internal const int HENCH_ATTACK_CHECK_NOT_DEAF                = 0x0000002f; // 47
//		internal const int HENCH_ATTACK_CHECK_HOLY_BLAS               = 0x00000030; // 48
//		internal const int HENCH_ATTACK_CHECK_EVIL                    = 0x00000031; // 49

		// AcBonus types
//		int iAcType = (iSaveType & HENCH_SPELL_SAVE_TYPE_SAVES_MASK) >> 18;
		// stock NwScript constants:
		// These are in 'hench_i0_buff' HenchCheckACBuff()
		// spelltype - HENCH_SPELL_INFO_SPELL_TYPE_AC_BUFF
//		internal const int AC_DODGE_BONUS                       = 0; // shift >> 18
//		internal const int AC_NATURAL_BONUS                     = 1; // 0x00040000 // these overlap the bits for Type1Save ->
//		internal const int AC_ARMOUR_ENCHANTMENT_BONUS          = 2; // 0x00080000
//		internal const int AC_SHIELD_ENCHANTMENT_BONUS          = 3; // 0x000c0000
//		internal const int AC_DEFLECTION_BONUS                  = 4; // 0x00100000 // this overlaps the bit for Type1Damage:half

		// These say they are in SaveType - 'hench_i0_buff' HenchGetEnergyImmunityWeight()
		internal const int HENCH_IMMUNITY_WEIGHT_AMOUNT_MASK          = 0x000ff000; // NOTE: The first 12 bits are nwscript DamageTypes.
		internal const int HENCH_IMMUNITY_WEIGHT_RESISTANCE           = 0x00100000; // overlaps type1damage:half
		internal const int HENCH_IMMUNITY_ONLY_ONE                    = 0x00200000; // overlaps type1damage:regular
		internal const int HENCH_IMMUNITY_GENERAL                     = 0x00400000; // overlaps type2save:fort

		// Weapon types - CoreAI constants
		// 'hench_i0_buffs'
		// These are used in 'hench_i0_buff' HenchCheckWeaponBuff()
		// spelltype - HENCH_SPELL_INFO_SPELL_TYPE_WEAPON_BUFF
		internal const int HENCH_WEAPON_STAFF_FLAG                    = 0x00000001; //    1	// Lovely. It looks like they did it again.
		internal const int HENCH_WEAPON_SLASH_FLAG                    = 0x00000002; //    2	// iSaveType appears to be dual-purposed
		internal const int HENCH_WEAPON_HOLY_SWORD                    = 0x00000004; //    4	// with overlapping values between these
		internal const int HENCH_WEAPON_BLUNT_FLAG                    = 0x00000008; //    8	// and SaveType (Specific-type) values.
		internal const int HENCH_WEAPON_UNDEAD_FLAG                   = 0x00000010; //   16	// Unless the getter for these is just a bug ....
		internal const int HENCH_WEAPON_DRUID_FLAG                    = 0x00001000; // 4096	// cf. HENCH_ATTACK_CHECK_* in 'hench_i0_attack' // this overlaps the bit for IMMUNITY_TYPE_MIND_SPELLS (type1)

		// 'hench_i0_spells'
		internal const int HENCH_SPELL_SAVE_TYPE_CUSTOM_MASK          = 0x0000003f;

		internal const int HENCH_SPELL_SAVE_TYPE_IMMUNITY1_MASK       = 0x00000fc0; // mask for immunity1-types
		internal const int HENCH_SPELL_SAVE_TYPE_IMMUNITY2_MASK       = 0x0003f000; // mask for immunity2-types

		internal const int HENCH_SPELL_SAVE_TYPE_SAVES_MASK           = 0x03fc0000; // mask for all save-types and damage-types


		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_FORT           = 0x00040000; // these overlap bits for AcBonus ->
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_REFLEX         = 0x00080000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_WILL           = 0x000c0000; // doubles as Type1Save mask

		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_HALF    = 0x00100000; // this overlaps the bit for AC_DEFLECTION_BONUS
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_EFFECT_DAMAGE  = 0x00200000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE1_DAMAGE_EVASION = 0x00300000; // doubles as Type1Damage mask

		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_FORT           = 0x00400000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_REFLEX         = 0x00800000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_WILL           = 0x00c00000; // doubles as Type2Save mask

		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_HALF    = 0x01000000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_EFFECT_DAMAGE  = 0x02000000;
		internal const int HENCH_SPELL_SAVE_TYPE_SAVE2_DAMAGE_EVASION = 0x03000000; // doubles as Type2Damage mask

		internal const int HENCH_SPELL_SAVE_TYPE_MIND_SPELL_FLAG      = 0x04000000;
		internal const int HENCH_SPELL_SAVE_TYPE_TOUCH_RANGE_FLAG     = 0x08000000;
		internal const int HENCH_SPELL_SAVE_TYPE_TOUCH_MELEE_FLAG     = 0x10000000;
		internal const int HENCH_SPELL_SAVE_TYPE_NOTSELF_FLAG         = 0x20000000;
		internal const int HENCH_SPELL_SAVE_TYPE_CHECK_FRIENDLY_FLAG  = 0x40000000;
		internal const int HENCH_SPELL_SAVE_TYPE_SR_FLAG              = unchecked((int)0x80000000); // -2147483648 fu.net
		#endregion SaveType



		#region SaveDCType
		// 'hench_i0_spells'
		internal const int HENCH_SAVEDC_SPELL                     = -1000;

		internal const int HENCH_SAVEDC_NONE                      = 0;

		internal const int HENCH_SAVEDC_HD_1                      = 1000;
		internal const int HENCH_SAVEDC_HD_2                      = 1001;
		internal const int HENCH_SAVEDC_HD_4                      = 1002;
		internal const int HENCH_SAVEDC_HD_2_CONST                = 1003;
		internal const int HENCH_SAVEDC_HD_2_CONST_MINUS_5        = 1004;
		internal const int HENCH_SAVEDC_HD_2_WIS                  = 1005;
		internal const int HENCH_SAVEDC_HD_2_PLUS_5               = 1006;
		internal const int HENCH_SAVEDC_HD_2_CHA                  = 1007;

		internal const int HENCH_SAVEDC_DISEASE_BOLT              = 1010;
		internal const int HENCH_SAVEDC_DISEASE_CONE              = 1011;
		internal const int HENCH_SAVEDC_DISEASE_PULSE             = 1012;
		internal const int HENCH_SAVEDC_POISON                    = 1013;
		internal const int HENCH_SAVEDC_EPIC                      = 1014;

		internal const int HENCH_SAVEDC_DEATHLESS_MASTER_TOUCH    = 1020;
		internal const int HENCH_SAVEDC_UNDEAD_GRAFT              = 1021;
		internal const int HENCH_SAVEDC_SPELL_NO_SPELL_LEVEL      = 1022;

		internal const int HENCH_SAVEDC_BARD_SLOWING              = 1024;
		internal const int HENCH_SAVEDC_BARD_FASCINATE            = 1025;

		// 'hench_i0_buff'
		internal const int HENCH_AC_CHECK_ARMOR                   = 0x00000001;
		internal const int HENCH_AC_CHECK_SHIELD                  = 0x00000002;
		internal const int HENCH_AC_CHECK_MOVEMENT_SPEED_DECREASE = 0x10000000;
		#endregion SaveDCType



		#region Racial
		internal const int HENCH_RACIAL_FEAT_SPELLS    = 0x00000008;

		internal const int HENCH_FEAT_SPELL_MASK_FEAT  = 0x0000ffff;
		internal const int HENCH_FEAT_SPELL_MASK_SPELL = 0x3fff0000;
		internal const int HENCH_FEAT_SPELL_CHEAT_CAST = 0x40000000;
		#endregion Racial


		#region Classes
//		internal const int HENCH_CLASS_SPELL_PROG_MASK              = 0x00000007;
		internal const int HENCH_NO_SPELL_PROGRESSION               = 0x00000000;
		internal const int HENCH_SKIP_SECOND_SPELL_PROGRESSION      = 0x00000001; // 2.3 add
		internal const int HENCH_SKIP_FIRST_THIRD_SPELL_PROGRESSION = 0x00000002;
		internal const int HENCH_EVERY_OTHER_EVEN_SPELL_PROGRESSION = 0x00000003;
		internal const int HENCH_EVERY_OTHER_ODD_SPELL_PROGRESSION  = 0x00000004;
		internal const int HENCH_SKIP_FOURTH_SPELL_PROGRESSION      = 0x00000005;
		internal const int HENCH_SKIP_FIRST_SPELL_PROGRESSION       = 0x00000006;
		internal const int HENCH_FULL_SPELL_PROGRESSION             = 0x00000007;

		internal const int HENCH_CLASS_FEAT_SPELLS                  = 0x00000008;

		internal const int HENCH_CLASS_PRC_FLAG                     = 0x00000010;
		internal const int HENCH_CLASS_DIVINE_FLAG                  = 0x00000020;
		internal const int HENCH_CLASS_DC_BONUS_FLAG                = 0x00000040;
		internal const int HENCH_CLASS_FOURTH_LEVEL_NEEDED          = 0x00000080;

		internal const int HENCH_CLASS_ABILITY_MODIFIER_MASK        = 0x00000300;
		internal const int HENCH_CLASS_ABILITY_MODIFIER_SHIFT       = 8;

//		internal const int HENCH_CLASS_BUFF_OTHERS_MASK             = 0x00000c00;
		internal const int HENCH_CLASS_BUFF_OTHERS_FULL             = 0x00000000;
		internal const int HENCH_CLASS_BUFF_OTHERS_HIGH             = 0x00000400;
		internal const int HENCH_CLASS_BUFF_OTHERS_MEDIUM           = 0x00000800;
		internal const int HENCH_CLASS_BUFF_OTHERS_LOW              = 0x00000c00;

//		internal const int HENCH_CLASS_ATTACK_MASK                  = 0x00003000;
		internal const int HENCH_CLASS_ATTACK_FULL                  = 0x00000000;
		internal const int HENCH_CLASS_ATTACK_HIGH                  = 0x00001000;
		internal const int HENCH_CLASS_ATTACK_MEDIUM                = 0x00002000;
		internal const int HENCH_CLASS_ATTACK_LOW                   = 0x00003000;

//		internal const int HENCH_CLASS_SA_MASK                      = 0x0001c000; // sneak attack info
		internal const int HENCH_CLASS_SA_NONE                      = 0x00000000;
		internal const int HENCH_CLASS_SA_EVERY_OTHER_ODD           = 0x00004000;
		internal const int HENCH_CLASS_SA_EVERY_OTHER_EVEN          = 0x00008000;
		internal const int HENCH_CLASS_SA_EVERY_THIRD_SKIP_FIRST    = 0x0000c000;
		internal const int HENCH_CLASS_SA_EVERY_THIRD               = 0x00010000;
		internal const int HENCH_CLASS_SA_EVERY_THIRD_FROM_TWO      = 0x00014000;
		internal const int HENCH_CLASS_SA_EVERY_THIRD_FROM_ONE      = 0x00018000;
		internal const int HENCH_CLASS_SA_EVERY_FORTH               = 0x0001c000;

//		internal const int HENCH_CLASS_TURN_UNDEAD_STACKS           = 0x00020000;
//		internal const int HENCH_CLASS_IGNORE_SILENCE               = 0x00040000;
		#endregion Classes
	}
}
