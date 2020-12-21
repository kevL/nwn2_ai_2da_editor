using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class tabcontrol_Spells
	{
//		tp_SpellInfo.Controls.Add(si_infoversion);
//		tp_SpellInfo.Controls.Add(si_infoversion_lbl);

		CompositedTabControl tc_Spells;

		TabPage tp_SpellInfo;
		TabPage tp_TargetInfo;
		TabPage tp_EffectWeight;
		TabPage tp_EffectTypes;
		TabPage tp_DamageInfo;
		TabPage tp_SaveType;
		TabPage tp_SaveDCType;

// 'tp_SpellInfo' controls
		Button     SpellInfo_reset; // TODO: ToolTip "reset"
		TextboxInt SpellInfo_text;
		TextBox    SpellInfo_hex;
		TextBox    SpellInfo_bin;

		Button si_Clear;
		Label  si_hex;
		Label  si_bin;

		GroupBox si_SpelltypeGrp;
		GroupBox si_FlagsGrp;
		GroupBox si_SpelllevelGrp;
		GroupBox si_SubspellsGrp;

		// 'si_SpelltypeGrp' controls
		Label    si_hostile;
		ComboBox si_co_Spelltype;

		// 'si_FlagsGrp' controls
		CheckBox si_Ignore;
		CheckBox si_IsMaster;
		CheckBox si_Concentration;
		CheckBox si_HealOrCure;
		CheckBox si_ItemCast;
		CheckBox si_Unlimited;
		CheckBox si_ShortDurBuff;
		CheckBox si_MediumDurBuff;
		CheckBox si_LongDurBuff;

		// 'si_SpelllevelGrp' controls
		ComboBox si_co_Spelllevel;

		// 'si_SubspellsGrp' controls
		Label      si_SubspellTi;
		Label      si_SubspellEt;
		Label      si_SubspellDi;
		Label      si_SubspellSt;
		Label      si_SubspellDc;
		TextboxInt si_Subspell1;
		TextboxInt si_Subspell2;
		TextboxInt si_Subspell3;
		TextboxInt si_Subspell4;
		TextboxInt si_Subspell5;

		Label si_SubspellLabel1; // to right of 'si_SubspellsGrp' ->
		Label si_SubspellLabel2;
		Label si_SubspellLabel3;
		Label si_SubspellLabel4;
		Label si_SubspellLabel5;

// 'tp_TargetInfo' controls
		Button     TargetInfo_reset; // TODO: ToolTip "reset"
		TextboxInt TargetInfo_text;
		TextBox    TargetInfo_hex;
		TextBox    TargetInfo_bin;

		Button ti_Clear;
		Label  ti_hex;
		Label  ti_bin;

		GroupBox ti_FlagsGrp;
		GroupBox ti_ShapeGrp;
		GroupBox ti_RangeGrp;
		GroupBox ti_RadiusGrp;

		// 'ti_FlagsGrp' controls
		CheckBox ti_ShapeLoop;
		CheckBox ti_CheckCount;
		CheckBox ti_MissileTargets;
		CheckBox ti_SecondaryTargets;
		CheckBox ti_SecondaryHalfDamage;
		CheckBox ti_SeenRequired;
		CheckBox ti_RangedSelectedArea;
		CheckBox ti_PersistentAoe;
		CheckBox ti_ScaledEffect; // TODO: ToolTip
		CheckBox ti_Necromancy;
		CheckBox ti_Regular;

		// 'ti_ShapeGrp' controls
		ComboBox ti_co_Shape;

		// 'ti_RangeGrp' controls
		ComboBox ti_co_Range;

		// 'ti_RadiusGrp' controls
		TextboxFloat ti_Radius;

// 'tp_EffectWeight' controls
		Button       EffectWeight_reset; // TODO: ToolTip "reset"
		TextboxFloat EffectWeight_text;

		Button ew_Clear;
		Label  f1;
		Label  f2;

// 'tp_EffectTypes' controls
		Button     EffectTypes_reset; // TODO: ToolTip "reset"
		TextboxInt EffectTypes_text;
		TextBox    EffectTypes_hex;
		TextBox    EffectTypes_bin;

		Button et_Clear;
		Label  et_hex;
		Label  et_bin;

		GroupBox et_DetEffectsGrp;
		GroupBox et_BenEffectsGrp;

		// 'et_DetEffectsGrp' controls
		CheckBox et_AbilityDecrease;
		CheckBox et_AcDecrease;
		CheckBox et_AttackDecrease;
		CheckBox et_Blindness;
		CheckBox et_Charm;
		CheckBox et_Confuse;
		CheckBox et_Curse;
		CheckBox et_CutsceneParalyze;
		CheckBox et_DamageDecrease;
		CheckBox et_Daze;
		CheckBox et_Deafness;
		CheckBox et_Death;
		CheckBox et_Disease;
		CheckBox et_Dominate;
		CheckBox et_Dying;
		CheckBox et_Entangle;
		CheckBox et_Frighten;
		CheckBox et_Knockdown;
		CheckBox et_Mesmerize;
		CheckBox et_NegativeLevel;
		CheckBox et_Paralyze;
		CheckBox et_Petrify;
		CheckBox et_Poison;
		CheckBox et_SavingThrowDecrease;
		CheckBox et_Silence;
		CheckBox et_SkillDecrease;
		CheckBox et_Sleep;
		CheckBox et_Slow;
		CheckBox et_SpeedDecrease;
		CheckBox et_Stun;

		// 'et_BenEffectsGrp' controls
		CheckBox et_AbilityIncrease;
		CheckBox et_AbsorbDamage;
		CheckBox et_AcIncrease;
		CheckBox et_AttackIncrease;
		CheckBox et_Concealment;
		CheckBox et_DamageIncrease;
		CheckBox et_DamageReduction;
		CheckBox et_ElementalShield;
		CheckBox et_Ethereal;
		CheckBox et_GreaterInvisibility;
		CheckBox et_Haste;
		CheckBox et_ImmunityNecromancy;
		CheckBox et_Invisibility;
		CheckBox et_Polymorph;
		CheckBox et_Regenerate;
		CheckBox et_Sanctuary;
		CheckBox et_SavingThrowIncrease;
		CheckBox et_SeeInvisible;
		CheckBox et_SpellAbsorption;
		CheckBox et_SpellShield;
		CheckBox et_TempHitpoints;
		CheckBox et_Timestop;
		CheckBox et_TrueSeeing;
		CheckBox et_Ultravision;
		CheckBox et_Wildshape;


// 'tp_DamageInfo' controls
		Button     DamageInfo_reset; // TODO: ToolTip "reset"
		TextboxInt DamageInfo_text;
		TextBox    DamageInfo_hex;
		TextBox    DamageInfo_bin;

		Button di_Clear;
		Label  di_hex;
		Label  di_bin;

		GroupBox di_DetrimentalGrp;
		GroupBox di_BeneficialGrp;
		GroupBox di_DispelTypesGrp;

		// 'di_DetrimentalGrp' controls
		GroupBox di_DetDamagebaseGrp;
		GroupBox di_DetDamageGrp;
		GroupBox di_DetLeveltypeGrp;
		GroupBox di_DetLevellimitGrp;
		GroupBox di_DetLeveldivisorGrp;
		GroupBox di_DetFixedCountGrp;
		GroupBox di_DetDamagetypeGrp;

		ComboBox   di_co_DetDamagebase;		// 'di_DetDamagebaseGrp' controls
		TextboxInt di_DetDamage;			// 'di_DetDamageGrp' controls
		ComboBox   di_co_DetLeveltype;		// 'di_DetLeveltypeGrp' controls
		TextboxInt di_DetLevellimit;		// 'di_DetLevellimitGrp' controls
		TextboxInt di_DetLeveldivisor;		// 'di_DetLeveldivisorGrp' controls
		TextboxInt di_DetFixedcount;		// 'di_DetFixedCountGrp' controls
		Label      di_lbl_FixedCountPlusOne;
		CheckBox   di_Magical;				// 'di_DetDamagetypeGrp' controls
		CheckBox   di_Divine;
		CheckBox   di_Acid;
		CheckBox   di_Cold;
		CheckBox   di_Electrical;
		CheckBox   di_Fire;
		CheckBox   di_Sonic;
		CheckBox   di_Negative;
		CheckBox   di_Positive;
		CheckBox   di_Bludgeoning;
		CheckBox   di_Piercing;
		CheckBox   di_Slashing;

		// 'di_BeneficialGrp' controls
		GroupBox di_BenPowerbaseGrp;
		GroupBox di_BenPowerGrp;
		GroupBox di_BenLeveltypeGrp;
		GroupBox di_BenLevellimitGrp;
		GroupBox di_BenLeveldivisorGrp;
		GroupBox di_BenLeveldecreaseGrp;

		ComboBox   di_co_BenPowerbase;	// 'di_BenPowerbaseGrp' controls
		TextboxInt di_BenPower;			// 'di_BenPowerGrp' controls
		ComboBox   di_co_BenLeveltype;	// 'di_BenLeveltypeGrp' controls
		TextboxInt di_BenLevellimit;	// 'di_BenLevellimitGrp' controls
		TextboxInt di_BenLeveldivisor;	// 'di_BenLeveldivisorGrp' controls
		TextboxInt di_BenLeveldecrease;	// 'di_BenLeveldecreaseGrp' controls

		// 'di_DispelTypesGrp' controls
		CheckBox di_Breach;
		CheckBox di_Dispel;
		CheckBox di_Resist;

// 'tp_SaveType' controls
		Button     SaveType_reset; // TODO: ToolTip "reset"
		TextboxInt SaveType_text;
		TextBox    SaveType_hex;
		TextBox    SaveType_bin;

		Button st_Clear;
		Label  st_hex;
		Label  st_bin;

		GroupBox st_DetrimentalGrp;
		GroupBox st_ExclusiveGrp;
		CheckBox st_NotCaster; // this is actually flag in 'st_DetrimentalGrp'<-'st_FlagsGrp' ...
		GroupBox st_TargetRestrictionGrp;
		GroupBox st_AcBonusGrp;

		// 'st_DetrimentalGrp' controls
		GroupBox st_Save1Grp;
		GroupBox st_Save2Grp;
		GroupBox st_Impact1Grp;
		GroupBox st_Impact2Grp;
		GroupBox st_FlagsGrp;
		GroupBox st_Immunity1Grp;
		GroupBox st_Immunity2Grp;
		GroupBox st_SpecificGrp;

		RadioButton st_Save1rb_none;			// 'st_Save1Grp' controls
		RadioButton st_Save2rb_fort;
		RadioButton st_Save2rb_refl;
		RadioButton st_Save2rb_will;
		RadioButton st_Save2rb_none;			// 'st_Save2Grp' controls
		RadioButton st_Save1rb_fort;
		RadioButton st_Save1rb_refl;
		RadioButton st_Save1rb_will;
		RadioButton st_Impact1rb_effectonly;	// 'st_Impact1Grp' controls
		RadioButton st_Impact1rb_damagehalf;
		RadioButton st_Impact1rb_effectdamage;
		RadioButton st_Impact1rb_damageevasion;
		RadioButton st_Impact2rb_effectonly;	// 'st_Impact2Grp' controls
		RadioButton st_Impact2rb_damagehalf;
		RadioButton st_Impact2rb_effectdamage;
		RadioButton st_Impact2rb_damageevasion;
		CheckBox    st_AffectsFriendlies;		// 'st_FlagsGrp' controls
		CheckBox    st_MindAffecting;
		CheckBox    st_SpellResistance;
		CheckBox    st_TouchMelee;
		CheckBox    st_TouchRanged;
		ComboBox    st_co_Immunity1;			// 'st_Immunity1Grp' controls
		ComboBox    st_co_Immunity2;			// 'st_Immunity2Grp' controls
		ComboBox    st_co_Specific;				// 'st_SpecificGrp' controls

		// 'st_ExclusiveGrp' controls
		GroupBox st_Excl_DamagetypesGrp;
		GroupBox st_Excl_WeightGrp;
		GroupBox st_Excl_FlagsGrp;

		CheckBox    st_Excl_Magical;			// 'st_Excl_DamagetypesGrp' controls
		CheckBox    st_Excl_Divine;
		CheckBox    st_Excl_Acid;
		CheckBox    st_Excl_Cold;
		CheckBox    st_Excl_Electrical;
		CheckBox    st_Excl_Fire;
		CheckBox    st_Excl_Sonic;
		CheckBox    st_Excl_Negative;
		CheckBox    st_Excl_Positive;
		CheckBox    st_Excl_Bludgeoning;
		CheckBox    st_Excl_Piercing;
		CheckBox    st_Excl_Slashing;
		TextboxInt  st_Excl_Weight;				// 'st_Excl_WeightGrp' controls
		RadioButton st_Excl_rbResistance;		// 'st_Excl_FlagsGrp' controls
		RadioButton st_Excl_rbImmunity;
		CheckBox    st_Excl_Onlyone; // TODO: ToolTip
		CheckBox    st_Excl_General; // TODO: ToolTip

		// 'st_TargetRestrictionGrp' controls
		ComboBox st_co_TargetRestriction;

		// 'st_AcBonusGrp' controls
		ComboBox st_co_AcBonus;

// 'tp_SaveDCType' controls
		Button     SaveDCType_reset; // TODO: ToolTip "reset"
		TextboxInt SaveDCType_text;
		TextBox    SaveDCType_hex;
		TextBox    SaveDCType_bin;

		Button dc_Clear;
		Label  dc_hex;
		Label  dc_bin;

		GroupBox dc_SaveDCGrp;
		GroupBox dc_WeaponBonusGrp;
		GroupBox dc_ArmorCheckGrp;
		Label    savedctype_label;

		// 'dc_SaveDCGrp' controls
		ComboBox dc_co_SaveDC;
		Button   savedc_up;
		Button   savedc_dn;
		Label    savedc_adjustor_info;
		Label    savedc_info;

		// 'dc_WeaponBonusGrp' controls
		ComboBox dc_co_WeaponBonus;

		// 'dc_ArmorCheckGrp' controls
		CheckBox savedc_ac3;
		CheckBox savedc_ac2;
		CheckBox savedc_ac1;
		Label    armorcheck_info;


		/// <summary>
		/// *si effin designer bs
		/// </summary>
		void InitializeComponent()
		{
			this.tc_Spells = new nwn2_ai_2da_editor.CompositedTabControl();
			this.tp_SpellInfo = new System.Windows.Forms.TabPage();
			this.SpellInfo_reset = new System.Windows.Forms.Button();
			this.SpellInfo_text = new nwn2_ai_2da_editor.TextboxInt();
			this.SpellInfo_hex = new System.Windows.Forms.TextBox();
			this.SpellInfo_bin = new System.Windows.Forms.TextBox();
			this.si_Clear = new System.Windows.Forms.Button();
			this.si_hex = new System.Windows.Forms.Label();
			this.si_bin = new System.Windows.Forms.Label();
			this.si_SpelltypeGrp = new System.Windows.Forms.GroupBox();
			this.si_hostile = new System.Windows.Forms.Label();
			this.si_co_Spelltype = new System.Windows.Forms.ComboBox();
			this.si_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.si_Ignore = new System.Windows.Forms.CheckBox();
			this.si_IsMaster = new System.Windows.Forms.CheckBox();
			this.si_Concentration = new System.Windows.Forms.CheckBox();
			this.si_HealOrCure = new System.Windows.Forms.CheckBox();
			this.si_ItemCast = new System.Windows.Forms.CheckBox();
			this.si_Unlimited = new System.Windows.Forms.CheckBox();
			this.si_ShortDurBuff = new System.Windows.Forms.CheckBox();
			this.si_MediumDurBuff = new System.Windows.Forms.CheckBox();
			this.si_LongDurBuff = new System.Windows.Forms.CheckBox();
			this.si_SpelllevelGrp = new System.Windows.Forms.GroupBox();
			this.si_co_Spelllevel = new System.Windows.Forms.ComboBox();
			this.si_SubspellsGrp = new System.Windows.Forms.GroupBox();
			this.si_SubspellTi = new System.Windows.Forms.Label();
			this.si_SubspellEt = new System.Windows.Forms.Label();
			this.si_SubspellDi = new System.Windows.Forms.Label();
			this.si_SubspellSt = new System.Windows.Forms.Label();
			this.si_SubspellDc = new System.Windows.Forms.Label();
			this.si_Subspell1 = new nwn2_ai_2da_editor.TextboxInt();
			this.si_Subspell2 = new nwn2_ai_2da_editor.TextboxInt();
			this.si_Subspell3 = new nwn2_ai_2da_editor.TextboxInt();
			this.si_Subspell4 = new nwn2_ai_2da_editor.TextboxInt();
			this.si_Subspell5 = new nwn2_ai_2da_editor.TextboxInt();
			this.si_SubspellLabel1 = new System.Windows.Forms.Label();
			this.si_SubspellLabel2 = new System.Windows.Forms.Label();
			this.si_SubspellLabel3 = new System.Windows.Forms.Label();
			this.si_SubspellLabel4 = new System.Windows.Forms.Label();
			this.si_SubspellLabel5 = new System.Windows.Forms.Label();
			this.tp_TargetInfo = new System.Windows.Forms.TabPage();
			this.TargetInfo_reset = new System.Windows.Forms.Button();
			this.TargetInfo_text = new nwn2_ai_2da_editor.TextboxInt();
			this.TargetInfo_hex = new System.Windows.Forms.TextBox();
			this.TargetInfo_bin = new System.Windows.Forms.TextBox();
			this.ti_Clear = new System.Windows.Forms.Button();
			this.ti_hex = new System.Windows.Forms.Label();
			this.ti_bin = new System.Windows.Forms.Label();
			this.ti_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.ti_ShapeLoop = new System.Windows.Forms.CheckBox();
			this.ti_CheckCount = new System.Windows.Forms.CheckBox();
			this.ti_MissileTargets = new System.Windows.Forms.CheckBox();
			this.ti_SecondaryTargets = new System.Windows.Forms.CheckBox();
			this.ti_SecondaryHalfDamage = new System.Windows.Forms.CheckBox();
			this.ti_SeenRequired = new System.Windows.Forms.CheckBox();
			this.ti_RangedSelectedArea = new System.Windows.Forms.CheckBox();
			this.ti_PersistentAoe = new System.Windows.Forms.CheckBox();
			this.ti_ScaledEffect = new System.Windows.Forms.CheckBox();
			this.ti_Necromancy = new System.Windows.Forms.CheckBox();
			this.ti_Regular = new System.Windows.Forms.CheckBox();
			this.ti_ShapeGrp = new System.Windows.Forms.GroupBox();
			this.ti_co_Shape = new System.Windows.Forms.ComboBox();
			this.ti_RangeGrp = new System.Windows.Forms.GroupBox();
			this.ti_co_Range = new System.Windows.Forms.ComboBox();
			this.ti_RadiusGrp = new System.Windows.Forms.GroupBox();
			this.ti_Radius = new nwn2_ai_2da_editor.TextboxFloat();
			this.tp_EffectWeight = new System.Windows.Forms.TabPage();
			this.ew_Clear = new System.Windows.Forms.Button();
			this.f2 = new System.Windows.Forms.Label();
			this.f1 = new System.Windows.Forms.Label();
			this.EffectWeight_reset = new System.Windows.Forms.Button();
			this.EffectWeight_text = new nwn2_ai_2da_editor.TextboxFloat();
			this.tp_EffectTypes = new System.Windows.Forms.TabPage();
			this.EffectTypes_reset = new System.Windows.Forms.Button();
			this.EffectTypes_text = new nwn2_ai_2da_editor.TextboxInt();
			this.EffectTypes_hex = new System.Windows.Forms.TextBox();
			this.EffectTypes_bin = new System.Windows.Forms.TextBox();
			this.et_Clear = new System.Windows.Forms.Button();
			this.et_hex = new System.Windows.Forms.Label();
			this.et_bin = new System.Windows.Forms.Label();
			this.et_DetEffectsGrp = new System.Windows.Forms.GroupBox();
			this.et_AbilityDecrease = new System.Windows.Forms.CheckBox();
			this.et_AcDecrease = new System.Windows.Forms.CheckBox();
			this.et_AttackDecrease = new System.Windows.Forms.CheckBox();
			this.et_Blindness = new System.Windows.Forms.CheckBox();
			this.et_Charm = new System.Windows.Forms.CheckBox();
			this.et_Confuse = new System.Windows.Forms.CheckBox();
			this.et_Curse = new System.Windows.Forms.CheckBox();
			this.et_CutsceneParalyze = new System.Windows.Forms.CheckBox();
			this.et_DamageDecrease = new System.Windows.Forms.CheckBox();
			this.et_Daze = new System.Windows.Forms.CheckBox();
			this.et_Deafness = new System.Windows.Forms.CheckBox();
			this.et_Death = new System.Windows.Forms.CheckBox();
			this.et_Disease = new System.Windows.Forms.CheckBox();
			this.et_Dominate = new System.Windows.Forms.CheckBox();
			this.et_Dying = new System.Windows.Forms.CheckBox();
			this.et_Entangle = new System.Windows.Forms.CheckBox();
			this.et_Frighten = new System.Windows.Forms.CheckBox();
			this.et_Knockdown = new System.Windows.Forms.CheckBox();
			this.et_Mesmerize = new System.Windows.Forms.CheckBox();
			this.et_NegativeLevel = new System.Windows.Forms.CheckBox();
			this.et_Paralyze = new System.Windows.Forms.CheckBox();
			this.et_Petrify = new System.Windows.Forms.CheckBox();
			this.et_Poison = new System.Windows.Forms.CheckBox();
			this.et_SavingThrowDecrease = new System.Windows.Forms.CheckBox();
			this.et_Silence = new System.Windows.Forms.CheckBox();
			this.et_SkillDecrease = new System.Windows.Forms.CheckBox();
			this.et_Sleep = new System.Windows.Forms.CheckBox();
			this.et_Slow = new System.Windows.Forms.CheckBox();
			this.et_SpeedDecrease = new System.Windows.Forms.CheckBox();
			this.et_Stun = new System.Windows.Forms.CheckBox();
			this.et_BenEffectsGrp = new System.Windows.Forms.GroupBox();
			this.et_AbilityIncrease = new System.Windows.Forms.CheckBox();
			this.et_AbsorbDamage = new System.Windows.Forms.CheckBox();
			this.et_AcIncrease = new System.Windows.Forms.CheckBox();
			this.et_AttackIncrease = new System.Windows.Forms.CheckBox();
			this.et_Concealment = new System.Windows.Forms.CheckBox();
			this.et_DamageIncrease = new System.Windows.Forms.CheckBox();
			this.et_DamageReduction = new System.Windows.Forms.CheckBox();
			this.et_ElementalShield = new System.Windows.Forms.CheckBox();
			this.et_Ethereal = new System.Windows.Forms.CheckBox();
			this.et_GreaterInvisibility = new System.Windows.Forms.CheckBox();
			this.et_Haste = new System.Windows.Forms.CheckBox();
			this.et_ImmunityNecromancy = new System.Windows.Forms.CheckBox();
			this.et_Invisibility = new System.Windows.Forms.CheckBox();
			this.et_Polymorph = new System.Windows.Forms.CheckBox();
			this.et_Regenerate = new System.Windows.Forms.CheckBox();
			this.et_Sanctuary = new System.Windows.Forms.CheckBox();
			this.et_SavingThrowIncrease = new System.Windows.Forms.CheckBox();
			this.et_SeeInvisible = new System.Windows.Forms.CheckBox();
			this.et_SpellAbsorption = new System.Windows.Forms.CheckBox();
			this.et_SpellShield = new System.Windows.Forms.CheckBox();
			this.et_TempHitpoints = new System.Windows.Forms.CheckBox();
			this.et_Timestop = new System.Windows.Forms.CheckBox();
			this.et_TrueSeeing = new System.Windows.Forms.CheckBox();
			this.et_Ultravision = new System.Windows.Forms.CheckBox();
			this.et_Wildshape = new System.Windows.Forms.CheckBox();
			this.tp_DamageInfo = new System.Windows.Forms.TabPage();
			this.DamageInfo_reset = new System.Windows.Forms.Button();
			this.DamageInfo_text = new nwn2_ai_2da_editor.TextboxInt();
			this.DamageInfo_hex = new System.Windows.Forms.TextBox();
			this.DamageInfo_bin = new System.Windows.Forms.TextBox();
			this.di_Clear = new System.Windows.Forms.Button();
			this.di_hex = new System.Windows.Forms.Label();
			this.di_bin = new System.Windows.Forms.Label();
			this.di_DetrimentalGrp = new System.Windows.Forms.GroupBox();
			this.di_DetDamagebaseGrp = new System.Windows.Forms.GroupBox();
			this.di_co_DetDamagebase = new System.Windows.Forms.ComboBox();
			this.di_DetDamageGrp = new System.Windows.Forms.GroupBox();
			this.di_DetDamage = new nwn2_ai_2da_editor.TextboxInt();
			this.di_DetLeveltypeGrp = new System.Windows.Forms.GroupBox();
			this.di_co_DetLeveltype = new System.Windows.Forms.ComboBox();
			this.di_DetLevellimitGrp = new System.Windows.Forms.GroupBox();
			this.di_DetLevellimit = new nwn2_ai_2da_editor.TextboxInt();
			this.di_DetLeveldivisorGrp = new System.Windows.Forms.GroupBox();
			this.di_DetLeveldivisor = new nwn2_ai_2da_editor.TextboxInt();
			this.di_DetFixedCountGrp = new System.Windows.Forms.GroupBox();
			this.di_DetFixedcount = new nwn2_ai_2da_editor.TextboxInt();
			this.di_lbl_FixedCountPlusOne = new System.Windows.Forms.Label();
			this.di_DetDamagetypeGrp = new System.Windows.Forms.GroupBox();
			this.di_Magical = new System.Windows.Forms.CheckBox();
			this.di_Divine = new System.Windows.Forms.CheckBox();
			this.di_Acid = new System.Windows.Forms.CheckBox();
			this.di_Cold = new System.Windows.Forms.CheckBox();
			this.di_Electrical = new System.Windows.Forms.CheckBox();
			this.di_Fire = new System.Windows.Forms.CheckBox();
			this.di_Sonic = new System.Windows.Forms.CheckBox();
			this.di_Negative = new System.Windows.Forms.CheckBox();
			this.di_Positive = new System.Windows.Forms.CheckBox();
			this.di_Bludgeoning = new System.Windows.Forms.CheckBox();
			this.di_Piercing = new System.Windows.Forms.CheckBox();
			this.di_Slashing = new System.Windows.Forms.CheckBox();
			this.di_BeneficialGrp = new System.Windows.Forms.GroupBox();
			this.di_BenPowerbaseGrp = new System.Windows.Forms.GroupBox();
			this.di_co_BenPowerbase = new System.Windows.Forms.ComboBox();
			this.di_BenPowerGrp = new System.Windows.Forms.GroupBox();
			this.di_BenPower = new nwn2_ai_2da_editor.TextboxInt();
			this.di_BenLeveltypeGrp = new System.Windows.Forms.GroupBox();
			this.di_co_BenLeveltype = new System.Windows.Forms.ComboBox();
			this.di_BenLevellimitGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLevellimit = new nwn2_ai_2da_editor.TextboxInt();
			this.di_BenLeveldivisorGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLeveldivisor = new nwn2_ai_2da_editor.TextboxInt();
			this.di_BenLeveldecreaseGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLeveldecrease = new nwn2_ai_2da_editor.TextboxInt();
			this.di_DispelTypesGrp = new System.Windows.Forms.GroupBox();
			this.di_Breach = new System.Windows.Forms.CheckBox();
			this.di_Dispel = new System.Windows.Forms.CheckBox();
			this.di_Resist = new System.Windows.Forms.CheckBox();
			this.tp_SaveType = new System.Windows.Forms.TabPage();
			this.SaveType_reset = new System.Windows.Forms.Button();
			this.SaveType_text = new nwn2_ai_2da_editor.TextboxInt();
			this.SaveType_hex = new System.Windows.Forms.TextBox();
			this.SaveType_bin = new System.Windows.Forms.TextBox();
			this.st_Clear = new System.Windows.Forms.Button();
			this.st_hex = new System.Windows.Forms.Label();
			this.st_bin = new System.Windows.Forms.Label();
			this.st_DetrimentalGrp = new System.Windows.Forms.GroupBox();
			this.st_Save1Grp = new System.Windows.Forms.GroupBox();
			this.st_Save1rb_will = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_refl = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_fort = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_none = new System.Windows.Forms.RadioButton();
			this.st_Save2Grp = new System.Windows.Forms.GroupBox();
			this.st_Save2rb_will = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_refl = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_fort = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_none = new System.Windows.Forms.RadioButton();
			this.st_Impact1Grp = new System.Windows.Forms.GroupBox();
			this.st_Impact1rb_effectonly = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_damagehalf = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_effectdamage = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_damageevasion = new System.Windows.Forms.RadioButton();
			this.st_Impact2Grp = new System.Windows.Forms.GroupBox();
			this.st_Impact2rb_effectonly = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_damagehalf = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_effectdamage = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_damageevasion = new System.Windows.Forms.RadioButton();
			this.st_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.st_AffectsFriendlies = new System.Windows.Forms.CheckBox();
			this.st_MindAffecting = new System.Windows.Forms.CheckBox();
			this.st_SpellResistance = new System.Windows.Forms.CheckBox();
			this.st_TouchMelee = new System.Windows.Forms.CheckBox();
			this.st_TouchRanged = new System.Windows.Forms.CheckBox();
			this.st_Immunity1Grp = new System.Windows.Forms.GroupBox();
			this.st_co_Immunity1 = new System.Windows.Forms.ComboBox();
			this.st_Immunity2Grp = new System.Windows.Forms.GroupBox();
			this.st_co_Immunity2 = new System.Windows.Forms.ComboBox();
			this.st_SpecificGrp = new System.Windows.Forms.GroupBox();
			this.st_co_Specific = new System.Windows.Forms.ComboBox();
			this.st_ExclusiveGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_DamagetypesGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_Magical = new System.Windows.Forms.CheckBox();
			this.st_Excl_Divine = new System.Windows.Forms.CheckBox();
			this.st_Excl_Acid = new System.Windows.Forms.CheckBox();
			this.st_Excl_Cold = new System.Windows.Forms.CheckBox();
			this.st_Excl_Electrical = new System.Windows.Forms.CheckBox();
			this.st_Excl_Fire = new System.Windows.Forms.CheckBox();
			this.st_Excl_Sonic = new System.Windows.Forms.CheckBox();
			this.st_Excl_Negative = new System.Windows.Forms.CheckBox();
			this.st_Excl_Positive = new System.Windows.Forms.CheckBox();
			this.st_Excl_Bludgeoning = new System.Windows.Forms.CheckBox();
			this.st_Excl_Piercing = new System.Windows.Forms.CheckBox();
			this.st_Excl_Slashing = new System.Windows.Forms.CheckBox();
			this.st_Excl_WeightGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_Weight = new nwn2_ai_2da_editor.TextboxInt();
			this.st_Excl_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_rbResistance = new System.Windows.Forms.RadioButton();
			this.st_Excl_rbImmunity = new System.Windows.Forms.RadioButton();
			this.st_Excl_Onlyone = new System.Windows.Forms.CheckBox();
			this.st_Excl_General = new System.Windows.Forms.CheckBox();
			this.st_TargetRestrictionGrp = new System.Windows.Forms.GroupBox();
			this.st_co_TargetRestriction = new System.Windows.Forms.ComboBox();
			this.st_NotCaster = new System.Windows.Forms.CheckBox();
			this.st_AcBonusGrp = new System.Windows.Forms.GroupBox();
			this.st_co_AcBonus = new System.Windows.Forms.ComboBox();
			this.tp_SaveDCType = new System.Windows.Forms.TabPage();
			this.SaveDCType_reset = new System.Windows.Forms.Button();
			this.SaveDCType_text = new nwn2_ai_2da_editor.TextboxInt();
			this.SaveDCType_hex = new System.Windows.Forms.TextBox();
			this.SaveDCType_bin = new System.Windows.Forms.TextBox();
			this.dc_Clear = new System.Windows.Forms.Button();
			this.dc_hex = new System.Windows.Forms.Label();
			this.dc_bin = new System.Windows.Forms.Label();
			this.dc_SaveDCGrp = new System.Windows.Forms.GroupBox();
			this.dc_co_SaveDC = new System.Windows.Forms.ComboBox();
			this.savedc_up = new System.Windows.Forms.Button();
			this.savedc_dn = new System.Windows.Forms.Button();
			this.savedc_adjustor_info = new System.Windows.Forms.Label();
			this.savedc_info = new System.Windows.Forms.Label();
			this.dc_WeaponBonusGrp = new System.Windows.Forms.GroupBox();
			this.dc_co_WeaponBonus = new System.Windows.Forms.ComboBox();
			this.dc_ArmorCheckGrp = new System.Windows.Forms.GroupBox();
			this.savedc_ac1 = new System.Windows.Forms.CheckBox();
			this.savedc_ac2 = new System.Windows.Forms.CheckBox();
			this.savedc_ac3 = new System.Windows.Forms.CheckBox();
			this.armorcheck_info = new System.Windows.Forms.Label();
			this.savedctype_label = new System.Windows.Forms.Label();
			this.tc_Spells.SuspendLayout();
			this.tp_SpellInfo.SuspendLayout();
			this.si_SpelltypeGrp.SuspendLayout();
			this.si_FlagsGrp.SuspendLayout();
			this.si_SpelllevelGrp.SuspendLayout();
			this.si_SubspellsGrp.SuspendLayout();
			this.tp_TargetInfo.SuspendLayout();
			this.ti_FlagsGrp.SuspendLayout();
			this.ti_ShapeGrp.SuspendLayout();
			this.ti_RangeGrp.SuspendLayout();
			this.ti_RadiusGrp.SuspendLayout();
			this.tp_EffectWeight.SuspendLayout();
			this.tp_EffectTypes.SuspendLayout();
			this.et_DetEffectsGrp.SuspendLayout();
			this.et_BenEffectsGrp.SuspendLayout();
			this.tp_DamageInfo.SuspendLayout();
			this.di_DetrimentalGrp.SuspendLayout();
			this.di_DetDamagebaseGrp.SuspendLayout();
			this.di_DetDamageGrp.SuspendLayout();
			this.di_DetLeveltypeGrp.SuspendLayout();
			this.di_DetLevellimitGrp.SuspendLayout();
			this.di_DetLeveldivisorGrp.SuspendLayout();
			this.di_DetFixedCountGrp.SuspendLayout();
			this.di_DetDamagetypeGrp.SuspendLayout();
			this.di_BeneficialGrp.SuspendLayout();
			this.di_BenPowerbaseGrp.SuspendLayout();
			this.di_BenPowerGrp.SuspendLayout();
			this.di_BenLeveltypeGrp.SuspendLayout();
			this.di_BenLevellimitGrp.SuspendLayout();
			this.di_BenLeveldivisorGrp.SuspendLayout();
			this.di_BenLeveldecreaseGrp.SuspendLayout();
			this.di_DispelTypesGrp.SuspendLayout();
			this.tp_SaveType.SuspendLayout();
			this.st_DetrimentalGrp.SuspendLayout();
			this.st_Save1Grp.SuspendLayout();
			this.st_Save2Grp.SuspendLayout();
			this.st_Impact1Grp.SuspendLayout();
			this.st_Impact2Grp.SuspendLayout();
			this.st_FlagsGrp.SuspendLayout();
			this.st_Immunity1Grp.SuspendLayout();
			this.st_Immunity2Grp.SuspendLayout();
			this.st_SpecificGrp.SuspendLayout();
			this.st_ExclusiveGrp.SuspendLayout();
			this.st_Excl_DamagetypesGrp.SuspendLayout();
			this.st_Excl_WeightGrp.SuspendLayout();
			this.st_Excl_FlagsGrp.SuspendLayout();
			this.st_TargetRestrictionGrp.SuspendLayout();
			this.st_AcBonusGrp.SuspendLayout();
			this.tp_SaveDCType.SuspendLayout();
			this.dc_SaveDCGrp.SuspendLayout();
			this.dc_WeaponBonusGrp.SuspendLayout();
			this.dc_ArmorCheckGrp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tc_Spells
			// 
			this.tc_Spells.Controls.Add(this.tp_SpellInfo);
			this.tc_Spells.Controls.Add(this.tp_TargetInfo);
			this.tc_Spells.Controls.Add(this.tp_EffectWeight);
			this.tc_Spells.Controls.Add(this.tp_EffectTypes);
			this.tc_Spells.Controls.Add(this.tp_DamageInfo);
			this.tc_Spells.Controls.Add(this.tp_SaveType);
			this.tc_Spells.Controls.Add(this.tp_SaveDCType);
			this.tc_Spells.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tc_Spells.Location = new System.Drawing.Point(0, 0);
			this.tc_Spells.Margin = new System.Windows.Forms.Padding(0);
			this.tc_Spells.Name = "tc_Spells";
			this.tc_Spells.Padding = new System.Drawing.Point(0, 0);
			this.tc_Spells.SelectedIndex = 0;
			this.tc_Spells.Size = new System.Drawing.Size(823, 449);
			this.tc_Spells.TabIndex = 0;
			// 
			// tp_SpellInfo
			// 
			this.tp_SpellInfo.BackColor = System.Drawing.Color.OldLace;
			this.tp_SpellInfo.Controls.Add(this.SpellInfo_reset);
			this.tp_SpellInfo.Controls.Add(this.SpellInfo_text);
			this.tp_SpellInfo.Controls.Add(this.SpellInfo_hex);
			this.tp_SpellInfo.Controls.Add(this.SpellInfo_bin);
			this.tp_SpellInfo.Controls.Add(this.si_Clear);
			this.tp_SpellInfo.Controls.Add(this.si_hex);
			this.tp_SpellInfo.Controls.Add(this.si_bin);
			this.tp_SpellInfo.Controls.Add(this.si_SpelltypeGrp);
			this.tp_SpellInfo.Controls.Add(this.si_FlagsGrp);
			this.tp_SpellInfo.Controls.Add(this.si_SpelllevelGrp);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellsGrp);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellLabel1);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellLabel2);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellLabel3);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellLabel4);
			this.tp_SpellInfo.Controls.Add(this.si_SubspellLabel5);
			this.tp_SpellInfo.Location = new System.Drawing.Point(4, 22);
			this.tp_SpellInfo.Margin = new System.Windows.Forms.Padding(0);
			this.tp_SpellInfo.Name = "tp_SpellInfo";
			this.tp_SpellInfo.Size = new System.Drawing.Size(815, 423);
			this.tp_SpellInfo.TabIndex = 0;
			this.tp_SpellInfo.Text = "SpellInfo";
			// 
			// SpellInfo_reset
			// 
			this.SpellInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.SpellInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_reset.Name = "SpellInfo_reset";
			this.SpellInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.SpellInfo_reset.TabIndex = 0;
			this.SpellInfo_reset.UseVisualStyleBackColor = true;
			// 
			// SpellInfo_text
			// 
			this.SpellInfo_text.Location = new System.Drawing.Point(5, 35);
			this.SpellInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_text.Name = "SpellInfo_text";
			this.SpellInfo_text.Size = new System.Drawing.Size(100, 20);
			this.SpellInfo_text.TabIndex = 1;
			this.SpellInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SpellInfo_hex
			// 
			this.SpellInfo_hex.BackColor = System.Drawing.SystemColors.Window;
			this.SpellInfo_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SpellInfo_hex.Location = new System.Drawing.Point(115, 15);
			this.SpellInfo_hex.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_hex.Name = "SpellInfo_hex";
			this.SpellInfo_hex.ReadOnly = true;
			this.SpellInfo_hex.Size = new System.Drawing.Size(275, 13);
			this.SpellInfo_hex.TabIndex = 2;
			// 
			// SpellInfo_bin
			// 
			this.SpellInfo_bin.BackColor = System.Drawing.SystemColors.Window;
			this.SpellInfo_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SpellInfo_bin.Location = new System.Drawing.Point(115, 35);
			this.SpellInfo_bin.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_bin.Name = "SpellInfo_bin";
			this.SpellInfo_bin.ReadOnly = true;
			this.SpellInfo_bin.Size = new System.Drawing.Size(275, 13);
			this.SpellInfo_bin.TabIndex = 3;
			// 
			// si_Clear
			// 
			this.si_Clear.Location = new System.Drawing.Point(450, 5);
			this.si_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.si_Clear.Name = "si_Clear";
			this.si_Clear.Size = new System.Drawing.Size(65, 50);
			this.si_Clear.TabIndex = 4;
			this.si_Clear.Text = "zero\r\nall\r\nbits";
			this.si_Clear.UseVisualStyleBackColor = true;
			// 
			// si_hex
			// 
			this.si_hex.Location = new System.Drawing.Point(400, 15);
			this.si_hex.Margin = new System.Windows.Forms.Padding(0);
			this.si_hex.Name = "si_hex";
			this.si_hex.Size = new System.Drawing.Size(40, 15);
			this.si_hex.TabIndex = 5;
			this.si_hex.Text = "hex";
			this.si_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_bin
			// 
			this.si_bin.Location = new System.Drawing.Point(400, 35);
			this.si_bin.Margin = new System.Windows.Forms.Padding(0);
			this.si_bin.Name = "si_bin";
			this.si_bin.Size = new System.Drawing.Size(40, 15);
			this.si_bin.TabIndex = 6;
			this.si_bin.Text = "bin";
			this.si_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SpelltypeGrp
			// 
			this.si_SpelltypeGrp.Controls.Add(this.si_hostile);
			this.si_SpelltypeGrp.Controls.Add(this.si_co_Spelltype);
			this.si_SpelltypeGrp.Location = new System.Drawing.Point(5, 60);
			this.si_SpelltypeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_SpelltypeGrp.Name = "si_SpelltypeGrp";
			this.si_SpelltypeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_SpelltypeGrp.Size = new System.Drawing.Size(405, 45);
			this.si_SpelltypeGrp.TabIndex = 7;
			this.si_SpelltypeGrp.TabStop = false;
			this.si_SpelltypeGrp.Text = "0000 00FF spelltype";
			// 
			// si_hostile
			// 
			this.si_hostile.Location = new System.Drawing.Point(305, 15);
			this.si_hostile.Margin = new System.Windows.Forms.Padding(0);
			this.si_hostile.Name = "si_hostile";
			this.si_hostile.Size = new System.Drawing.Size(95, 25);
			this.si_hostile.TabIndex = 0;
			this.si_hostile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_co_Spelltype
			// 
			this.si_co_Spelltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.si_co_Spelltype.FormattingEnabled = true;
			this.si_co_Spelltype.Location = new System.Drawing.Point(5, 15);
			this.si_co_Spelltype.Margin = new System.Windows.Forms.Padding(0);
			this.si_co_Spelltype.Name = "si_co_Spelltype";
			this.si_co_Spelltype.Size = new System.Drawing.Size(290, 21);
			this.si_co_Spelltype.TabIndex = 1;
			// 
			// si_FlagsGrp
			// 
			this.si_FlagsGrp.Controls.Add(this.si_Ignore);
			this.si_FlagsGrp.Controls.Add(this.si_IsMaster);
			this.si_FlagsGrp.Controls.Add(this.si_Concentration);
			this.si_FlagsGrp.Controls.Add(this.si_HealOrCure);
			this.si_FlagsGrp.Controls.Add(this.si_ItemCast);
			this.si_FlagsGrp.Controls.Add(this.si_Unlimited);
			this.si_FlagsGrp.Controls.Add(this.si_ShortDurBuff);
			this.si_FlagsGrp.Controls.Add(this.si_MediumDurBuff);
			this.si_FlagsGrp.Controls.Add(this.si_LongDurBuff);
			this.si_FlagsGrp.Location = new System.Drawing.Point(5, 105);
			this.si_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_FlagsGrp.Name = "si_FlagsGrp";
			this.si_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_FlagsGrp.Size = new System.Drawing.Size(300, 200);
			this.si_FlagsGrp.TabIndex = 8;
			this.si_FlagsGrp.TabStop = false;
			this.si_FlagsGrp.Text = "009E 0F00 flags";
			// 
			// si_Ignore
			// 
			this.si_Ignore.Location = new System.Drawing.Point(10, 15);
			this.si_Ignore.Margin = new System.Windows.Forms.Padding(0);
			this.si_Ignore.Name = "si_Ignore";
			this.si_Ignore.Size = new System.Drawing.Size(285, 20);
			this.si_Ignore.TabIndex = 0;
			this.si_Ignore.Text = "ignore";
			this.si_Ignore.UseVisualStyleBackColor = true;
			// 
			// si_IsMaster
			// 
			this.si_IsMaster.Location = new System.Drawing.Point(10, 35);
			this.si_IsMaster.Margin = new System.Windows.Forms.Padding(0);
			this.si_IsMaster.Name = "si_IsMaster";
			this.si_IsMaster.Size = new System.Drawing.Size(285, 20);
			this.si_IsMaster.TabIndex = 1;
			this.si_IsMaster.Text = "is Master Spell ID";
			this.si_IsMaster.UseVisualStyleBackColor = true;
			// 
			// si_Concentration
			// 
			this.si_Concentration.Location = new System.Drawing.Point(10, 55);
			this.si_Concentration.Margin = new System.Windows.Forms.Padding(0);
			this.si_Concentration.Name = "si_Concentration";
			this.si_Concentration.Size = new System.Drawing.Size(285, 20);
			this.si_Concentration.TabIndex = 2;
			this.si_Concentration.Text = "does a Concentration check";
			this.si_Concentration.UseVisualStyleBackColor = true;
			// 
			// si_HealOrCure
			// 
			this.si_HealOrCure.Location = new System.Drawing.Point(10, 75);
			this.si_HealOrCure.Margin = new System.Windows.Forms.Padding(0);
			this.si_HealOrCure.Name = "si_HealOrCure";
			this.si_HealOrCure.Size = new System.Drawing.Size(285, 20);
			this.si_HealOrCure.TabIndex = 3;
			this.si_HealOrCure.Text = "is Heal or Cure";
			this.si_HealOrCure.UseVisualStyleBackColor = true;
			// 
			// si_ItemCast
			// 
			this.si_ItemCast.Location = new System.Drawing.Point(10, 95);
			this.si_ItemCast.Margin = new System.Windows.Forms.Padding(0);
			this.si_ItemCast.Name = "si_ItemCast";
			this.si_ItemCast.Size = new System.Drawing.Size(285, 20);
			this.si_ItemCast.TabIndex = 4;
			this.si_ItemCast.Text = "is cast by an Item";
			this.si_ItemCast.UseVisualStyleBackColor = true;
			// 
			// si_Unlimited
			// 
			this.si_Unlimited.Location = new System.Drawing.Point(10, 115);
			this.si_Unlimited.Margin = new System.Windows.Forms.Padding(0);
			this.si_Unlimited.Name = "si_Unlimited";
			this.si_Unlimited.Size = new System.Drawing.Size(285, 20);
			this.si_Unlimited.TabIndex = 5;
			this.si_Unlimited.Text = "has Unlimited casts";
			this.si_Unlimited.UseVisualStyleBackColor = true;
			// 
			// si_ShortDurBuff
			// 
			this.si_ShortDurBuff.Location = new System.Drawing.Point(10, 135);
			this.si_ShortDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_ShortDurBuff.Name = "si_ShortDurBuff";
			this.si_ShortDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_ShortDurBuff.TabIndex = 6;
			this.si_ShortDurBuff.Text = "short Duration buff";
			this.si_ShortDurBuff.UseVisualStyleBackColor = true;
			// 
			// si_MediumDurBuff
			// 
			this.si_MediumDurBuff.Location = new System.Drawing.Point(10, 155);
			this.si_MediumDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_MediumDurBuff.Name = "si_MediumDurBuff";
			this.si_MediumDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_MediumDurBuff.TabIndex = 7;
			this.si_MediumDurBuff.Text = "medium Duration buff";
			this.si_MediumDurBuff.UseVisualStyleBackColor = true;
			// 
			// si_LongDurBuff
			// 
			this.si_LongDurBuff.Location = new System.Drawing.Point(10, 175);
			this.si_LongDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_LongDurBuff.Name = "si_LongDurBuff";
			this.si_LongDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_LongDurBuff.TabIndex = 8;
			this.si_LongDurBuff.Text = "long Duration buff";
			this.si_LongDurBuff.UseVisualStyleBackColor = true;
			// 
			// si_SpelllevelGrp
			// 
			this.si_SpelllevelGrp.Controls.Add(this.si_co_Spelllevel);
			this.si_SpelllevelGrp.Location = new System.Drawing.Point(305, 105);
			this.si_SpelllevelGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_SpelllevelGrp.Name = "si_SpelllevelGrp";
			this.si_SpelllevelGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_SpelllevelGrp.Size = new System.Drawing.Size(165, 45);
			this.si_SpelllevelGrp.TabIndex = 9;
			this.si_SpelllevelGrp.TabStop = false;
			this.si_SpelllevelGrp.Text = "0001 E000 spelllevel";
			// 
			// si_co_Spelllevel
			// 
			this.si_co_Spelllevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.si_co_Spelllevel.FormattingEnabled = true;
			this.si_co_Spelllevel.Location = new System.Drawing.Point(5, 15);
			this.si_co_Spelllevel.Margin = new System.Windows.Forms.Padding(0);
			this.si_co_Spelllevel.Name = "si_co_Spelllevel";
			this.si_co_Spelllevel.Size = new System.Drawing.Size(155, 21);
			this.si_co_Spelllevel.TabIndex = 0;
			// 
			// si_SubspellsGrp
			// 
			this.si_SubspellsGrp.Controls.Add(this.si_SubspellTi);
			this.si_SubspellsGrp.Controls.Add(this.si_SubspellEt);
			this.si_SubspellsGrp.Controls.Add(this.si_SubspellDi);
			this.si_SubspellsGrp.Controls.Add(this.si_SubspellSt);
			this.si_SubspellsGrp.Controls.Add(this.si_SubspellDc);
			this.si_SubspellsGrp.Controls.Add(this.si_Subspell1);
			this.si_SubspellsGrp.Controls.Add(this.si_Subspell2);
			this.si_SubspellsGrp.Controls.Add(this.si_Subspell3);
			this.si_SubspellsGrp.Controls.Add(this.si_Subspell4);
			this.si_SubspellsGrp.Controls.Add(this.si_Subspell5);
			this.si_SubspellsGrp.Enabled = false;
			this.si_SubspellsGrp.Location = new System.Drawing.Point(305, 150);
			this.si_SubspellsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellsGrp.Name = "si_SubspellsGrp";
			this.si_SubspellsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_SubspellsGrp.Size = new System.Drawing.Size(115, 155);
			this.si_SubspellsGrp.TabIndex = 10;
			this.si_SubspellsGrp.TabStop = false;
			this.si_SubspellsGrp.Text = " Subspells ";
			// 
			// si_SubspellTi
			// 
			this.si_SubspellTi.Location = new System.Drawing.Point(5, 20);
			this.si_SubspellTi.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellTi.Name = "si_SubspellTi";
			this.si_SubspellTi.Size = new System.Drawing.Size(25, 20);
			this.si_SubspellTi.TabIndex = 0;
			this.si_SubspellTi.Text = "ti";
			this.si_SubspellTi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellEt
			// 
			this.si_SubspellEt.Location = new System.Drawing.Point(5, 45);
			this.si_SubspellEt.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellEt.Name = "si_SubspellEt";
			this.si_SubspellEt.Size = new System.Drawing.Size(25, 20);
			this.si_SubspellEt.TabIndex = 1;
			this.si_SubspellEt.Text = "et";
			this.si_SubspellEt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellDi
			// 
			this.si_SubspellDi.Location = new System.Drawing.Point(5, 70);
			this.si_SubspellDi.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellDi.Name = "si_SubspellDi";
			this.si_SubspellDi.Size = new System.Drawing.Size(25, 20);
			this.si_SubspellDi.TabIndex = 2;
			this.si_SubspellDi.Text = "di";
			this.si_SubspellDi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellSt
			// 
			this.si_SubspellSt.Location = new System.Drawing.Point(5, 95);
			this.si_SubspellSt.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellSt.Name = "si_SubspellSt";
			this.si_SubspellSt.Size = new System.Drawing.Size(25, 20);
			this.si_SubspellSt.TabIndex = 3;
			this.si_SubspellSt.Text = "st";
			this.si_SubspellSt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellDc
			// 
			this.si_SubspellDc.Location = new System.Drawing.Point(5, 120);
			this.si_SubspellDc.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellDc.Name = "si_SubspellDc";
			this.si_SubspellDc.Size = new System.Drawing.Size(25, 20);
			this.si_SubspellDc.TabIndex = 4;
			this.si_SubspellDc.Text = "dc";
			this.si_SubspellDc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_Subspell1
			// 
			this.si_Subspell1.Location = new System.Drawing.Point(30, 20);
			this.si_Subspell1.Margin = new System.Windows.Forms.Padding(0);
			this.si_Subspell1.Name = "si_Subspell1";
			this.si_Subspell1.Size = new System.Drawing.Size(80, 20);
			this.si_Subspell1.TabIndex = 5;
			// 
			// si_Subspell2
			// 
			this.si_Subspell2.Location = new System.Drawing.Point(30, 45);
			this.si_Subspell2.Margin = new System.Windows.Forms.Padding(0);
			this.si_Subspell2.Name = "si_Subspell2";
			this.si_Subspell2.Size = new System.Drawing.Size(80, 20);
			this.si_Subspell2.TabIndex = 6;
			// 
			// si_Subspell3
			// 
			this.si_Subspell3.Location = new System.Drawing.Point(30, 70);
			this.si_Subspell3.Margin = new System.Windows.Forms.Padding(0);
			this.si_Subspell3.Name = "si_Subspell3";
			this.si_Subspell3.Size = new System.Drawing.Size(80, 20);
			this.si_Subspell3.TabIndex = 7;
			// 
			// si_Subspell4
			// 
			this.si_Subspell4.Location = new System.Drawing.Point(30, 95);
			this.si_Subspell4.Margin = new System.Windows.Forms.Padding(0);
			this.si_Subspell4.Name = "si_Subspell4";
			this.si_Subspell4.Size = new System.Drawing.Size(80, 20);
			this.si_Subspell4.TabIndex = 8;
			// 
			// si_Subspell5
			// 
			this.si_Subspell5.Location = new System.Drawing.Point(30, 120);
			this.si_Subspell5.Margin = new System.Windows.Forms.Padding(0);
			this.si_Subspell5.Name = "si_Subspell5";
			this.si_Subspell5.Size = new System.Drawing.Size(80, 20);
			this.si_Subspell5.TabIndex = 9;
			// 
			// si_SubspellLabel1
			// 
			this.si_SubspellLabel1.Location = new System.Drawing.Point(425, 170);
			this.si_SubspellLabel1.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellLabel1.Name = "si_SubspellLabel1";
			this.si_SubspellLabel1.Size = new System.Drawing.Size(385, 20);
			this.si_SubspellLabel1.TabIndex = 11;
			this.si_SubspellLabel1.Text = "si_SubspellLabel1";
			this.si_SubspellLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellLabel2
			// 
			this.si_SubspellLabel2.Location = new System.Drawing.Point(425, 195);
			this.si_SubspellLabel2.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellLabel2.Name = "si_SubspellLabel2";
			this.si_SubspellLabel2.Size = new System.Drawing.Size(385, 20);
			this.si_SubspellLabel2.TabIndex = 12;
			this.si_SubspellLabel2.Text = "si_SubspellLabel2";
			this.si_SubspellLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellLabel3
			// 
			this.si_SubspellLabel3.Location = new System.Drawing.Point(425, 220);
			this.si_SubspellLabel3.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellLabel3.Name = "si_SubspellLabel3";
			this.si_SubspellLabel3.Size = new System.Drawing.Size(385, 20);
			this.si_SubspellLabel3.TabIndex = 13;
			this.si_SubspellLabel3.Text = "si_SubspellLabel3";
			this.si_SubspellLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellLabel4
			// 
			this.si_SubspellLabel4.Location = new System.Drawing.Point(425, 245);
			this.si_SubspellLabel4.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellLabel4.Name = "si_SubspellLabel4";
			this.si_SubspellLabel4.Size = new System.Drawing.Size(385, 20);
			this.si_SubspellLabel4.TabIndex = 14;
			this.si_SubspellLabel4.Text = "si_SubspellLabel4";
			this.si_SubspellLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_SubspellLabel5
			// 
			this.si_SubspellLabel5.Location = new System.Drawing.Point(425, 270);
			this.si_SubspellLabel5.Margin = new System.Windows.Forms.Padding(0);
			this.si_SubspellLabel5.Name = "si_SubspellLabel5";
			this.si_SubspellLabel5.Size = new System.Drawing.Size(385, 20);
			this.si_SubspellLabel5.TabIndex = 15;
			this.si_SubspellLabel5.Text = "si_SubspellLabel5";
			this.si_SubspellLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tp_TargetInfo
			// 
			this.tp_TargetInfo.BackColor = System.Drawing.Color.OldLace;
			this.tp_TargetInfo.Controls.Add(this.TargetInfo_reset);
			this.tp_TargetInfo.Controls.Add(this.TargetInfo_text);
			this.tp_TargetInfo.Controls.Add(this.TargetInfo_hex);
			this.tp_TargetInfo.Controls.Add(this.TargetInfo_bin);
			this.tp_TargetInfo.Controls.Add(this.ti_Clear);
			this.tp_TargetInfo.Controls.Add(this.ti_hex);
			this.tp_TargetInfo.Controls.Add(this.ti_bin);
			this.tp_TargetInfo.Controls.Add(this.ti_FlagsGrp);
			this.tp_TargetInfo.Controls.Add(this.ti_ShapeGrp);
			this.tp_TargetInfo.Controls.Add(this.ti_RangeGrp);
			this.tp_TargetInfo.Controls.Add(this.ti_RadiusGrp);
			this.tp_TargetInfo.Location = new System.Drawing.Point(4, 22);
			this.tp_TargetInfo.Margin = new System.Windows.Forms.Padding(0);
			this.tp_TargetInfo.Name = "tp_TargetInfo";
			this.tp_TargetInfo.Size = new System.Drawing.Size(815, 423);
			this.tp_TargetInfo.TabIndex = 1;
			this.tp_TargetInfo.Text = "TargetInfo";
			// 
			// TargetInfo_reset
			// 
			this.TargetInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.TargetInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_reset.Name = "TargetInfo_reset";
			this.TargetInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.TargetInfo_reset.TabIndex = 0;
			this.TargetInfo_reset.UseVisualStyleBackColor = true;
			// 
			// TargetInfo_text
			// 
			this.TargetInfo_text.Location = new System.Drawing.Point(5, 35);
			this.TargetInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_text.Name = "TargetInfo_text";
			this.TargetInfo_text.Size = new System.Drawing.Size(100, 20);
			this.TargetInfo_text.TabIndex = 1;
			this.TargetInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// TargetInfo_hex
			// 
			this.TargetInfo_hex.BackColor = System.Drawing.SystemColors.Window;
			this.TargetInfo_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TargetInfo_hex.Location = new System.Drawing.Point(115, 15);
			this.TargetInfo_hex.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_hex.Name = "TargetInfo_hex";
			this.TargetInfo_hex.ReadOnly = true;
			this.TargetInfo_hex.Size = new System.Drawing.Size(275, 13);
			this.TargetInfo_hex.TabIndex = 2;
			// 
			// TargetInfo_bin
			// 
			this.TargetInfo_bin.BackColor = System.Drawing.SystemColors.Window;
			this.TargetInfo_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.TargetInfo_bin.Location = new System.Drawing.Point(115, 35);
			this.TargetInfo_bin.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_bin.Name = "TargetInfo_bin";
			this.TargetInfo_bin.ReadOnly = true;
			this.TargetInfo_bin.Size = new System.Drawing.Size(275, 13);
			this.TargetInfo_bin.TabIndex = 3;
			// 
			// ti_Clear
			// 
			this.ti_Clear.Location = new System.Drawing.Point(450, 5);
			this.ti_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.ti_Clear.Name = "ti_Clear";
			this.ti_Clear.Size = new System.Drawing.Size(65, 50);
			this.ti_Clear.TabIndex = 4;
			this.ti_Clear.Text = "zero\r\nall\r\nbits";
			this.ti_Clear.UseVisualStyleBackColor = true;
			// 
			// ti_hex
			// 
			this.ti_hex.Location = new System.Drawing.Point(400, 15);
			this.ti_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ti_hex.Name = "ti_hex";
			this.ti_hex.Size = new System.Drawing.Size(40, 15);
			this.ti_hex.TabIndex = 5;
			this.ti_hex.Text = "hex";
			this.ti_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ti_bin
			// 
			this.ti_bin.Location = new System.Drawing.Point(400, 35);
			this.ti_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ti_bin.Name = "ti_bin";
			this.ti_bin.Size = new System.Drawing.Size(40, 15);
			this.ti_bin.TabIndex = 6;
			this.ti_bin.Text = "bin";
			this.ti_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ti_FlagsGrp
			// 
			this.ti_FlagsGrp.Controls.Add(this.ti_ShapeLoop);
			this.ti_FlagsGrp.Controls.Add(this.ti_CheckCount);
			this.ti_FlagsGrp.Controls.Add(this.ti_MissileTargets);
			this.ti_FlagsGrp.Controls.Add(this.ti_SecondaryTargets);
			this.ti_FlagsGrp.Controls.Add(this.ti_SecondaryHalfDamage);
			this.ti_FlagsGrp.Controls.Add(this.ti_SeenRequired);
			this.ti_FlagsGrp.Controls.Add(this.ti_RangedSelectedArea);
			this.ti_FlagsGrp.Controls.Add(this.ti_PersistentAoe);
			this.ti_FlagsGrp.Controls.Add(this.ti_ScaledEffect);
			this.ti_FlagsGrp.Controls.Add(this.ti_Necromancy);
			this.ti_FlagsGrp.Controls.Add(this.ti_Regular);
			this.ti_FlagsGrp.Location = new System.Drawing.Point(5, 60);
			this.ti_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_FlagsGrp.Name = "ti_FlagsGrp";
			this.ti_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_FlagsGrp.Size = new System.Drawing.Size(345, 240);
			this.ti_FlagsGrp.TabIndex = 7;
			this.ti_FlagsGrp.TabStop = false;
			this.ti_FlagsGrp.Text = "07FF 0000 flags";
			// 
			// ti_ShapeLoop
			// 
			this.ti_ShapeLoop.Location = new System.Drawing.Point(10, 15);
			this.ti_ShapeLoop.Name = "ti_ShapeLoop";
			this.ti_ShapeLoop.Size = new System.Drawing.Size(330, 20);
			this.ti_ShapeLoop.TabIndex = 0;
			this.ti_ShapeLoop.Text = "shape loop";
			this.ti_ShapeLoop.UseVisualStyleBackColor = true;
			// 
			// ti_CheckCount
			// 
			this.ti_CheckCount.Location = new System.Drawing.Point(10, 35);
			this.ti_CheckCount.Name = "ti_CheckCount";
			this.ti_CheckCount.Size = new System.Drawing.Size(330, 20);
			this.ti_CheckCount.TabIndex = 1;
			this.ti_CheckCount.Text = "check count";
			this.ti_CheckCount.UseVisualStyleBackColor = true;
			// 
			// ti_MissileTargets
			// 
			this.ti_MissileTargets.Location = new System.Drawing.Point(10, 55);
			this.ti_MissileTargets.Name = "ti_MissileTargets";
			this.ti_MissileTargets.Size = new System.Drawing.Size(330, 20);
			this.ti_MissileTargets.TabIndex = 2;
			this.ti_MissileTargets.Text = "missile targets";
			this.ti_MissileTargets.UseVisualStyleBackColor = true;
			// 
			// ti_SecondaryTargets
			// 
			this.ti_SecondaryTargets.Location = new System.Drawing.Point(10, 75);
			this.ti_SecondaryTargets.Name = "ti_SecondaryTargets";
			this.ti_SecondaryTargets.Size = new System.Drawing.Size(330, 20);
			this.ti_SecondaryTargets.TabIndex = 3;
			this.ti_SecondaryTargets.Text = "secondary targets";
			this.ti_SecondaryTargets.UseVisualStyleBackColor = true;
			// 
			// ti_SecondaryHalfDamage
			// 
			this.ti_SecondaryHalfDamage.Location = new System.Drawing.Point(10, 95);
			this.ti_SecondaryHalfDamage.Name = "ti_SecondaryHalfDamage";
			this.ti_SecondaryHalfDamage.Size = new System.Drawing.Size(330, 20);
			this.ti_SecondaryHalfDamage.TabIndex = 4;
			this.ti_SecondaryHalfDamage.Text = "secondary targets take half damage";
			this.ti_SecondaryHalfDamage.UseVisualStyleBackColor = true;
			// 
			// ti_SeenRequired
			// 
			this.ti_SeenRequired.Location = new System.Drawing.Point(10, 115);
			this.ti_SeenRequired.Name = "ti_SeenRequired";
			this.ti_SeenRequired.Size = new System.Drawing.Size(330, 20);
			this.ti_SeenRequired.TabIndex = 5;
			this.ti_SeenRequired.Text = "perception seen required";
			this.ti_SeenRequired.UseVisualStyleBackColor = true;
			// 
			// ti_RangedSelectedArea
			// 
			this.ti_RangedSelectedArea.Location = new System.Drawing.Point(10, 135);
			this.ti_RangedSelectedArea.Name = "ti_RangedSelectedArea";
			this.ti_RangedSelectedArea.Size = new System.Drawing.Size(330, 20);
			this.ti_RangedSelectedArea.TabIndex = 6;
			this.ti_RangedSelectedArea.Text = "ranged selected area";
			this.ti_RangedSelectedArea.UseVisualStyleBackColor = true;
			// 
			// ti_PersistentAoe
			// 
			this.ti_PersistentAoe.Location = new System.Drawing.Point(10, 155);
			this.ti_PersistentAoe.Name = "ti_PersistentAoe";
			this.ti_PersistentAoe.Size = new System.Drawing.Size(330, 20);
			this.ti_PersistentAoe.TabIndex = 7;
			this.ti_PersistentAoe.Text = "persistent aoe";
			this.ti_PersistentAoe.UseVisualStyleBackColor = true;
			// 
			// ti_ScaledEffect
			// 
			this.ti_ScaledEffect.Location = new System.Drawing.Point(10, 175);
			this.ti_ScaledEffect.Name = "ti_ScaledEffect";
			this.ti_ScaledEffect.Size = new System.Drawing.Size(330, 20);
			this.ti_ScaledEffect.TabIndex = 8;
			this.ti_ScaledEffect.Text = "scale effectweight by DamageInfo buff power";
			this.ti_ScaledEffect.UseVisualStyleBackColor = true;
			// 
			// ti_Necromancy
			// 
			this.ti_Necromancy.Location = new System.Drawing.Point(10, 195);
			this.ti_Necromancy.Name = "ti_Necromancy";
			this.ti_Necromancy.Size = new System.Drawing.Size(330, 20);
			this.ti_Necromancy.TabIndex = 9;
			this.ti_Necromancy.Text = "check immunity to necromancy";
			this.ti_Necromancy.UseVisualStyleBackColor = true;
			// 
			// ti_Regular
			// 
			this.ti_Regular.Location = new System.Drawing.Point(10, 215);
			this.ti_Regular.Name = "ti_Regular";
			this.ti_Regular.Size = new System.Drawing.Size(330, 20);
			this.ti_Regular.TabIndex = 10;
			this.ti_Regular.Text = "regular";
			this.ti_Regular.UseVisualStyleBackColor = true;
			// 
			// ti_ShapeGrp
			// 
			this.ti_ShapeGrp.Controls.Add(this.ti_co_Shape);
			this.ti_ShapeGrp.Location = new System.Drawing.Point(350, 60);
			this.ti_ShapeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_ShapeGrp.Name = "ti_ShapeGrp";
			this.ti_ShapeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_ShapeGrp.Size = new System.Drawing.Size(225, 45);
			this.ti_ShapeGrp.TabIndex = 8;
			this.ti_ShapeGrp.TabStop = false;
			this.ti_ShapeGrp.Text = "0000 0007 shape";
			// 
			// ti_co_Shape
			// 
			this.ti_co_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ti_co_Shape.FormattingEnabled = true;
			this.ti_co_Shape.Location = new System.Drawing.Point(5, 15);
			this.ti_co_Shape.Margin = new System.Windows.Forms.Padding(0);
			this.ti_co_Shape.Name = "ti_co_Shape";
			this.ti_co_Shape.Size = new System.Drawing.Size(215, 21);
			this.ti_co_Shape.TabIndex = 0;
			// 
			// ti_RangeGrp
			// 
			this.ti_RangeGrp.Controls.Add(this.ti_co_Range);
			this.ti_RangeGrp.Location = new System.Drawing.Point(350, 105);
			this.ti_RangeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_RangeGrp.Name = "ti_RangeGrp";
			this.ti_RangeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_RangeGrp.Size = new System.Drawing.Size(225, 45);
			this.ti_RangeGrp.TabIndex = 9;
			this.ti_RangeGrp.TabStop = false;
			this.ti_RangeGrp.Text = "0000 0038 range";
			// 
			// ti_co_Range
			// 
			this.ti_co_Range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ti_co_Range.FormattingEnabled = true;
			this.ti_co_Range.Location = new System.Drawing.Point(5, 15);
			this.ti_co_Range.Margin = new System.Windows.Forms.Padding(0);
			this.ti_co_Range.Name = "ti_co_Range";
			this.ti_co_Range.Size = new System.Drawing.Size(215, 21);
			this.ti_co_Range.TabIndex = 0;
			// 
			// ti_RadiusGrp
			// 
			this.ti_RadiusGrp.Controls.Add(this.ti_Radius);
			this.ti_RadiusGrp.Location = new System.Drawing.Point(350, 150);
			this.ti_RadiusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_RadiusGrp.Name = "ti_RadiusGrp";
			this.ti_RadiusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_RadiusGrp.Size = new System.Drawing.Size(225, 40);
			this.ti_RadiusGrp.TabIndex = 10;
			this.ti_RadiusGrp.TabStop = false;
			this.ti_RadiusGrp.Text = "0000 FFC0 radius";
			// 
			// ti_Radius
			// 
			this.ti_Radius.Location = new System.Drawing.Point(5, 15);
			this.ti_Radius.Margin = new System.Windows.Forms.Padding(0);
			this.ti_Radius.Name = "ti_Radius";
			this.ti_Radius.Size = new System.Drawing.Size(215, 20);
			this.ti_Radius.TabIndex = 0;
			// 
			// tp_EffectWeight
			// 
			this.tp_EffectWeight.BackColor = System.Drawing.Color.OldLace;
			this.tp_EffectWeight.Controls.Add(this.ew_Clear);
			this.tp_EffectWeight.Controls.Add(this.f2);
			this.tp_EffectWeight.Controls.Add(this.f1);
			this.tp_EffectWeight.Controls.Add(this.EffectWeight_reset);
			this.tp_EffectWeight.Controls.Add(this.EffectWeight_text);
			this.tp_EffectWeight.Location = new System.Drawing.Point(4, 22);
			this.tp_EffectWeight.Margin = new System.Windows.Forms.Padding(0);
			this.tp_EffectWeight.Name = "tp_EffectWeight";
			this.tp_EffectWeight.Size = new System.Drawing.Size(815, 423);
			this.tp_EffectWeight.TabIndex = 2;
			this.tp_EffectWeight.Text = "EffectWeight";
			// 
			// ew_Clear
			// 
			this.ew_Clear.Location = new System.Drawing.Point(135, 5);
			this.ew_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.ew_Clear.Name = "ew_Clear";
			this.ew_Clear.Size = new System.Drawing.Size(65, 50);
			this.ew_Clear.TabIndex = 2;
			this.ew_Clear.Text = "zero";
			this.ew_Clear.UseVisualStyleBackColor = true;
			// 
			// f2
			// 
			this.f2.Location = new System.Drawing.Point(110, 30);
			this.f2.Name = "f2";
			this.f2.Size = new System.Drawing.Size(10, 25);
			this.f2.TabIndex = 4;
			this.f2.Text = "f";
			this.f2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// f1
			// 
			this.f1.Location = new System.Drawing.Point(110, 5);
			this.f1.Name = "f1";
			this.f1.Size = new System.Drawing.Size(10, 25);
			this.f1.TabIndex = 3;
			this.f1.Text = "f";
			this.f1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// EffectWeight_reset
			// 
			this.EffectWeight_reset.Location = new System.Drawing.Point(5, 5);
			this.EffectWeight_reset.Margin = new System.Windows.Forms.Padding(0);
			this.EffectWeight_reset.Name = "EffectWeight_reset";
			this.EffectWeight_reset.Size = new System.Drawing.Size(100, 25);
			this.EffectWeight_reset.TabIndex = 0;
			this.EffectWeight_reset.UseVisualStyleBackColor = true;
			// 
			// EffectWeight_text
			// 
			this.EffectWeight_text.Location = new System.Drawing.Point(5, 35);
			this.EffectWeight_text.Margin = new System.Windows.Forms.Padding(0);
			this.EffectWeight_text.Name = "EffectWeight_text";
			this.EffectWeight_text.Size = new System.Drawing.Size(100, 20);
			this.EffectWeight_text.TabIndex = 1;
			this.EffectWeight_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tp_EffectTypes
			// 
			this.tp_EffectTypes.BackColor = System.Drawing.Color.OldLace;
			this.tp_EffectTypes.Controls.Add(this.EffectTypes_reset);
			this.tp_EffectTypes.Controls.Add(this.EffectTypes_text);
			this.tp_EffectTypes.Controls.Add(this.EffectTypes_hex);
			this.tp_EffectTypes.Controls.Add(this.EffectTypes_bin);
			this.tp_EffectTypes.Controls.Add(this.et_Clear);
			this.tp_EffectTypes.Controls.Add(this.et_hex);
			this.tp_EffectTypes.Controls.Add(this.et_bin);
			this.tp_EffectTypes.Controls.Add(this.et_DetEffectsGrp);
			this.tp_EffectTypes.Controls.Add(this.et_BenEffectsGrp);
			this.tp_EffectTypes.Location = new System.Drawing.Point(4, 22);
			this.tp_EffectTypes.Margin = new System.Windows.Forms.Padding(0);
			this.tp_EffectTypes.Name = "tp_EffectTypes";
			this.tp_EffectTypes.Size = new System.Drawing.Size(815, 423);
			this.tp_EffectTypes.TabIndex = 3;
			this.tp_EffectTypes.Text = "EffectTypes";
			// 
			// EffectTypes_reset
			// 
			this.EffectTypes_reset.Location = new System.Drawing.Point(5, 5);
			this.EffectTypes_reset.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_reset.Name = "EffectTypes_reset";
			this.EffectTypes_reset.Size = new System.Drawing.Size(100, 25);
			this.EffectTypes_reset.TabIndex = 0;
			this.EffectTypes_reset.UseVisualStyleBackColor = true;
			// 
			// EffectTypes_text
			// 
			this.EffectTypes_text.Location = new System.Drawing.Point(5, 35);
			this.EffectTypes_text.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_text.Name = "EffectTypes_text";
			this.EffectTypes_text.Size = new System.Drawing.Size(100, 20);
			this.EffectTypes_text.TabIndex = 1;
			this.EffectTypes_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// EffectTypes_hex
			// 
			this.EffectTypes_hex.BackColor = System.Drawing.SystemColors.Window;
			this.EffectTypes_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.EffectTypes_hex.Location = new System.Drawing.Point(115, 15);
			this.EffectTypes_hex.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_hex.Name = "EffectTypes_hex";
			this.EffectTypes_hex.ReadOnly = true;
			this.EffectTypes_hex.Size = new System.Drawing.Size(275, 13);
			this.EffectTypes_hex.TabIndex = 2;
			// 
			// EffectTypes_bin
			// 
			this.EffectTypes_bin.BackColor = System.Drawing.SystemColors.Window;
			this.EffectTypes_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.EffectTypes_bin.Location = new System.Drawing.Point(115, 35);
			this.EffectTypes_bin.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_bin.Name = "EffectTypes_bin";
			this.EffectTypes_bin.ReadOnly = true;
			this.EffectTypes_bin.Size = new System.Drawing.Size(275, 13);
			this.EffectTypes_bin.TabIndex = 3;
			// 
			// et_Clear
			// 
			this.et_Clear.Location = new System.Drawing.Point(450, 5);
			this.et_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.et_Clear.Name = "et_Clear";
			this.et_Clear.Size = new System.Drawing.Size(65, 50);
			this.et_Clear.TabIndex = 4;
			this.et_Clear.Text = "zero\r\nall\r\nbits";
			this.et_Clear.UseVisualStyleBackColor = true;
			// 
			// et_hex
			// 
			this.et_hex.Location = new System.Drawing.Point(400, 15);
			this.et_hex.Margin = new System.Windows.Forms.Padding(0);
			this.et_hex.Name = "et_hex";
			this.et_hex.Size = new System.Drawing.Size(40, 15);
			this.et_hex.TabIndex = 5;
			this.et_hex.Text = "hex";
			this.et_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// et_bin
			// 
			this.et_bin.Location = new System.Drawing.Point(400, 35);
			this.et_bin.Margin = new System.Windows.Forms.Padding(0);
			this.et_bin.Name = "et_bin";
			this.et_bin.Size = new System.Drawing.Size(40, 15);
			this.et_bin.TabIndex = 6;
			this.et_bin.Text = "bin";
			this.et_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// et_DetEffectsGrp
			// 
			this.et_DetEffectsGrp.Controls.Add(this.et_AbilityDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_AcDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_AttackDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Blindness);
			this.et_DetEffectsGrp.Controls.Add(this.et_Charm);
			this.et_DetEffectsGrp.Controls.Add(this.et_Confuse);
			this.et_DetEffectsGrp.Controls.Add(this.et_Curse);
			this.et_DetEffectsGrp.Controls.Add(this.et_CutsceneParalyze);
			this.et_DetEffectsGrp.Controls.Add(this.et_DamageDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Daze);
			this.et_DetEffectsGrp.Controls.Add(this.et_Deafness);
			this.et_DetEffectsGrp.Controls.Add(this.et_Death);
			this.et_DetEffectsGrp.Controls.Add(this.et_Disease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Dominate);
			this.et_DetEffectsGrp.Controls.Add(this.et_Dying);
			this.et_DetEffectsGrp.Controls.Add(this.et_Entangle);
			this.et_DetEffectsGrp.Controls.Add(this.et_Frighten);
			this.et_DetEffectsGrp.Controls.Add(this.et_Knockdown);
			this.et_DetEffectsGrp.Controls.Add(this.et_Mesmerize);
			this.et_DetEffectsGrp.Controls.Add(this.et_NegativeLevel);
			this.et_DetEffectsGrp.Controls.Add(this.et_Paralyze);
			this.et_DetEffectsGrp.Controls.Add(this.et_Petrify);
			this.et_DetEffectsGrp.Controls.Add(this.et_Poison);
			this.et_DetEffectsGrp.Controls.Add(this.et_SavingThrowDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Silence);
			this.et_DetEffectsGrp.Controls.Add(this.et_SkillDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Sleep);
			this.et_DetEffectsGrp.Controls.Add(this.et_Slow);
			this.et_DetEffectsGrp.Controls.Add(this.et_SpeedDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Stun);
			this.et_DetEffectsGrp.Location = new System.Drawing.Point(5, 60);
			this.et_DetEffectsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.et_DetEffectsGrp.Name = "et_DetEffectsGrp";
			this.et_DetEffectsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.et_DetEffectsGrp.Size = new System.Drawing.Size(385, 320);
			this.et_DetEffectsGrp.TabIndex = 7;
			this.et_DetEffectsGrp.TabStop = false;
			this.et_DetEffectsGrp.Text = "FFF7 FFFF detrimental";
			// 
			// et_AbilityDecrease
			// 
			this.et_AbilityDecrease.Location = new System.Drawing.Point(10, 15);
			this.et_AbilityDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbilityDecrease.Name = "et_AbilityDecrease";
			this.et_AbilityDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AbilityDecrease.TabIndex = 0;
			this.et_AbilityDecrease.Text = "ability decrease";
			this.et_AbilityDecrease.UseVisualStyleBackColor = true;
			// 
			// et_AcDecrease
			// 
			this.et_AcDecrease.Location = new System.Drawing.Point(10, 35);
			this.et_AcDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AcDecrease.Name = "et_AcDecrease";
			this.et_AcDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AcDecrease.TabIndex = 1;
			this.et_AcDecrease.Text = "ac decrease";
			this.et_AcDecrease.UseVisualStyleBackColor = true;
			// 
			// et_AttackDecrease
			// 
			this.et_AttackDecrease.Location = new System.Drawing.Point(10, 55);
			this.et_AttackDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AttackDecrease.Name = "et_AttackDecrease";
			this.et_AttackDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AttackDecrease.TabIndex = 2;
			this.et_AttackDecrease.Text = "attack decrease";
			this.et_AttackDecrease.UseVisualStyleBackColor = true;
			// 
			// et_Blindness
			// 
			this.et_Blindness.Location = new System.Drawing.Point(10, 75);
			this.et_Blindness.Margin = new System.Windows.Forms.Padding(0);
			this.et_Blindness.Name = "et_Blindness";
			this.et_Blindness.Size = new System.Drawing.Size(180, 20);
			this.et_Blindness.TabIndex = 3;
			this.et_Blindness.Text = "blindness";
			this.et_Blindness.UseVisualStyleBackColor = true;
			// 
			// et_Charm
			// 
			this.et_Charm.Location = new System.Drawing.Point(10, 95);
			this.et_Charm.Margin = new System.Windows.Forms.Padding(0);
			this.et_Charm.Name = "et_Charm";
			this.et_Charm.Size = new System.Drawing.Size(180, 20);
			this.et_Charm.TabIndex = 4;
			this.et_Charm.Text = "charm";
			this.et_Charm.UseVisualStyleBackColor = true;
			// 
			// et_Confuse
			// 
			this.et_Confuse.Location = new System.Drawing.Point(10, 115);
			this.et_Confuse.Margin = new System.Windows.Forms.Padding(0);
			this.et_Confuse.Name = "et_Confuse";
			this.et_Confuse.Size = new System.Drawing.Size(180, 20);
			this.et_Confuse.TabIndex = 5;
			this.et_Confuse.Text = "confuse";
			this.et_Confuse.UseVisualStyleBackColor = true;
			// 
			// et_Curse
			// 
			this.et_Curse.Location = new System.Drawing.Point(10, 135);
			this.et_Curse.Margin = new System.Windows.Forms.Padding(0);
			this.et_Curse.Name = "et_Curse";
			this.et_Curse.Size = new System.Drawing.Size(180, 20);
			this.et_Curse.TabIndex = 6;
			this.et_Curse.Text = "curse";
			this.et_Curse.UseVisualStyleBackColor = true;
			// 
			// et_CutsceneParalyze
			// 
			this.et_CutsceneParalyze.Location = new System.Drawing.Point(10, 155);
			this.et_CutsceneParalyze.Margin = new System.Windows.Forms.Padding(0);
			this.et_CutsceneParalyze.Name = "et_CutsceneParalyze";
			this.et_CutsceneParalyze.Size = new System.Drawing.Size(180, 20);
			this.et_CutsceneParalyze.TabIndex = 7;
			this.et_CutsceneParalyze.Text = "cutscene paralyze";
			this.et_CutsceneParalyze.UseVisualStyleBackColor = true;
			// 
			// et_DamageDecrease
			// 
			this.et_DamageDecrease.Location = new System.Drawing.Point(10, 175);
			this.et_DamageDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageDecrease.Name = "et_DamageDecrease";
			this.et_DamageDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_DamageDecrease.TabIndex = 8;
			this.et_DamageDecrease.Text = "damage decrease";
			this.et_DamageDecrease.UseVisualStyleBackColor = true;
			// 
			// et_Daze
			// 
			this.et_Daze.Location = new System.Drawing.Point(10, 195);
			this.et_Daze.Margin = new System.Windows.Forms.Padding(0);
			this.et_Daze.Name = "et_Daze";
			this.et_Daze.Size = new System.Drawing.Size(180, 20);
			this.et_Daze.TabIndex = 9;
			this.et_Daze.Text = "daze";
			this.et_Daze.UseVisualStyleBackColor = true;
			// 
			// et_Deafness
			// 
			this.et_Deafness.Location = new System.Drawing.Point(10, 215);
			this.et_Deafness.Margin = new System.Windows.Forms.Padding(0);
			this.et_Deafness.Name = "et_Deafness";
			this.et_Deafness.Size = new System.Drawing.Size(180, 20);
			this.et_Deafness.TabIndex = 10;
			this.et_Deafness.Text = "deafness";
			this.et_Deafness.UseVisualStyleBackColor = true;
			// 
			// et_Death
			// 
			this.et_Death.Location = new System.Drawing.Point(10, 235);
			this.et_Death.Margin = new System.Windows.Forms.Padding(0);
			this.et_Death.Name = "et_Death";
			this.et_Death.Size = new System.Drawing.Size(180, 20);
			this.et_Death.TabIndex = 11;
			this.et_Death.Text = "death";
			this.et_Death.UseVisualStyleBackColor = true;
			// 
			// et_Disease
			// 
			this.et_Disease.Location = new System.Drawing.Point(10, 255);
			this.et_Disease.Margin = new System.Windows.Forms.Padding(0);
			this.et_Disease.Name = "et_Disease";
			this.et_Disease.Size = new System.Drawing.Size(180, 20);
			this.et_Disease.TabIndex = 12;
			this.et_Disease.Text = "disease";
			this.et_Disease.UseVisualStyleBackColor = true;
			// 
			// et_Dominate
			// 
			this.et_Dominate.Location = new System.Drawing.Point(10, 275);
			this.et_Dominate.Margin = new System.Windows.Forms.Padding(0);
			this.et_Dominate.Name = "et_Dominate";
			this.et_Dominate.Size = new System.Drawing.Size(180, 20);
			this.et_Dominate.TabIndex = 13;
			this.et_Dominate.Text = "dominate";
			this.et_Dominate.UseVisualStyleBackColor = true;
			// 
			// et_Dying
			// 
			this.et_Dying.Location = new System.Drawing.Point(10, 295);
			this.et_Dying.Margin = new System.Windows.Forms.Padding(0);
			this.et_Dying.Name = "et_Dying";
			this.et_Dying.Size = new System.Drawing.Size(180, 20);
			this.et_Dying.TabIndex = 14;
			this.et_Dying.Text = "dying";
			this.et_Dying.UseVisualStyleBackColor = true;
			// 
			// et_Entangle
			// 
			this.et_Entangle.Location = new System.Drawing.Point(200, 15);
			this.et_Entangle.Margin = new System.Windows.Forms.Padding(0);
			this.et_Entangle.Name = "et_Entangle";
			this.et_Entangle.Size = new System.Drawing.Size(180, 20);
			this.et_Entangle.TabIndex = 15;
			this.et_Entangle.Text = "entangle";
			this.et_Entangle.UseVisualStyleBackColor = true;
			// 
			// et_Frighten
			// 
			this.et_Frighten.Location = new System.Drawing.Point(200, 35);
			this.et_Frighten.Margin = new System.Windows.Forms.Padding(0);
			this.et_Frighten.Name = "et_Frighten";
			this.et_Frighten.Size = new System.Drawing.Size(180, 20);
			this.et_Frighten.TabIndex = 16;
			this.et_Frighten.Text = "frighten";
			this.et_Frighten.UseVisualStyleBackColor = true;
			// 
			// et_Knockdown
			// 
			this.et_Knockdown.Location = new System.Drawing.Point(200, 55);
			this.et_Knockdown.Margin = new System.Windows.Forms.Padding(0);
			this.et_Knockdown.Name = "et_Knockdown";
			this.et_Knockdown.Size = new System.Drawing.Size(180, 20);
			this.et_Knockdown.TabIndex = 17;
			this.et_Knockdown.Text = "knockdown";
			this.et_Knockdown.UseVisualStyleBackColor = true;
			// 
			// et_Mesmerize
			// 
			this.et_Mesmerize.Location = new System.Drawing.Point(200, 75);
			this.et_Mesmerize.Margin = new System.Windows.Forms.Padding(0);
			this.et_Mesmerize.Name = "et_Mesmerize";
			this.et_Mesmerize.Size = new System.Drawing.Size(180, 20);
			this.et_Mesmerize.TabIndex = 18;
			this.et_Mesmerize.Text = "mesmerize";
			this.et_Mesmerize.UseVisualStyleBackColor = true;
			// 
			// et_NegativeLevel
			// 
			this.et_NegativeLevel.Location = new System.Drawing.Point(200, 95);
			this.et_NegativeLevel.Margin = new System.Windows.Forms.Padding(0);
			this.et_NegativeLevel.Name = "et_NegativeLevel";
			this.et_NegativeLevel.Size = new System.Drawing.Size(180, 20);
			this.et_NegativeLevel.TabIndex = 19;
			this.et_NegativeLevel.Text = "negative level";
			this.et_NegativeLevel.UseVisualStyleBackColor = true;
			// 
			// et_Paralyze
			// 
			this.et_Paralyze.Location = new System.Drawing.Point(200, 115);
			this.et_Paralyze.Margin = new System.Windows.Forms.Padding(0);
			this.et_Paralyze.Name = "et_Paralyze";
			this.et_Paralyze.Size = new System.Drawing.Size(180, 20);
			this.et_Paralyze.TabIndex = 20;
			this.et_Paralyze.Text = "paralyze";
			this.et_Paralyze.UseVisualStyleBackColor = true;
			// 
			// et_Petrify
			// 
			this.et_Petrify.Location = new System.Drawing.Point(200, 135);
			this.et_Petrify.Margin = new System.Windows.Forms.Padding(0);
			this.et_Petrify.Name = "et_Petrify";
			this.et_Petrify.Size = new System.Drawing.Size(180, 20);
			this.et_Petrify.TabIndex = 21;
			this.et_Petrify.Text = "petrify";
			this.et_Petrify.UseVisualStyleBackColor = true;
			// 
			// et_Poison
			// 
			this.et_Poison.Location = new System.Drawing.Point(200, 155);
			this.et_Poison.Margin = new System.Windows.Forms.Padding(0);
			this.et_Poison.Name = "et_Poison";
			this.et_Poison.Size = new System.Drawing.Size(180, 20);
			this.et_Poison.TabIndex = 22;
			this.et_Poison.Text = "poison";
			this.et_Poison.UseVisualStyleBackColor = true;
			// 
			// et_SavingThrowDecrease
			// 
			this.et_SavingThrowDecrease.Location = new System.Drawing.Point(200, 175);
			this.et_SavingThrowDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SavingThrowDecrease.Name = "et_SavingThrowDecrease";
			this.et_SavingThrowDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SavingThrowDecrease.TabIndex = 23;
			this.et_SavingThrowDecrease.Text = "saving throw decrease";
			this.et_SavingThrowDecrease.UseVisualStyleBackColor = true;
			// 
			// et_Silence
			// 
			this.et_Silence.Location = new System.Drawing.Point(200, 195);
			this.et_Silence.Margin = new System.Windows.Forms.Padding(0);
			this.et_Silence.Name = "et_Silence";
			this.et_Silence.Size = new System.Drawing.Size(180, 20);
			this.et_Silence.TabIndex = 24;
			this.et_Silence.Text = "silence";
			this.et_Silence.UseVisualStyleBackColor = true;
			// 
			// et_SkillDecrease
			// 
			this.et_SkillDecrease.Location = new System.Drawing.Point(200, 215);
			this.et_SkillDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SkillDecrease.Name = "et_SkillDecrease";
			this.et_SkillDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SkillDecrease.TabIndex = 25;
			this.et_SkillDecrease.Text = "skill decrease";
			this.et_SkillDecrease.UseVisualStyleBackColor = true;
			// 
			// et_Sleep
			// 
			this.et_Sleep.Location = new System.Drawing.Point(200, 235);
			this.et_Sleep.Margin = new System.Windows.Forms.Padding(0);
			this.et_Sleep.Name = "et_Sleep";
			this.et_Sleep.Size = new System.Drawing.Size(180, 20);
			this.et_Sleep.TabIndex = 26;
			this.et_Sleep.Text = "sleep";
			this.et_Sleep.UseVisualStyleBackColor = true;
			// 
			// et_Slow
			// 
			this.et_Slow.Location = new System.Drawing.Point(200, 255);
			this.et_Slow.Margin = new System.Windows.Forms.Padding(0);
			this.et_Slow.Name = "et_Slow";
			this.et_Slow.Size = new System.Drawing.Size(180, 20);
			this.et_Slow.TabIndex = 27;
			this.et_Slow.Text = "slow";
			this.et_Slow.UseVisualStyleBackColor = true;
			// 
			// et_SpeedDecrease
			// 
			this.et_SpeedDecrease.Location = new System.Drawing.Point(200, 275);
			this.et_SpeedDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpeedDecrease.Name = "et_SpeedDecrease";
			this.et_SpeedDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SpeedDecrease.TabIndex = 28;
			this.et_SpeedDecrease.Text = "speed decrease";
			this.et_SpeedDecrease.UseVisualStyleBackColor = true;
			// 
			// et_Stun
			// 
			this.et_Stun.Location = new System.Drawing.Point(200, 295);
			this.et_Stun.Margin = new System.Windows.Forms.Padding(0);
			this.et_Stun.Name = "et_Stun";
			this.et_Stun.Size = new System.Drawing.Size(180, 20);
			this.et_Stun.TabIndex = 29;
			this.et_Stun.Text = "stun";
			this.et_Stun.UseVisualStyleBackColor = true;
			// 
			// et_BenEffectsGrp
			// 
			this.et_BenEffectsGrp.Controls.Add(this.et_AbilityIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_AbsorbDamage);
			this.et_BenEffectsGrp.Controls.Add(this.et_AcIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_AttackIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_Concealment);
			this.et_BenEffectsGrp.Controls.Add(this.et_DamageIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_DamageReduction);
			this.et_BenEffectsGrp.Controls.Add(this.et_ElementalShield);
			this.et_BenEffectsGrp.Controls.Add(this.et_Ethereal);
			this.et_BenEffectsGrp.Controls.Add(this.et_GreaterInvisibility);
			this.et_BenEffectsGrp.Controls.Add(this.et_Haste);
			this.et_BenEffectsGrp.Controls.Add(this.et_ImmunityNecromancy);
			this.et_BenEffectsGrp.Controls.Add(this.et_Invisibility);
			this.et_BenEffectsGrp.Controls.Add(this.et_Polymorph);
			this.et_BenEffectsGrp.Controls.Add(this.et_Regenerate);
			this.et_BenEffectsGrp.Controls.Add(this.et_Sanctuary);
			this.et_BenEffectsGrp.Controls.Add(this.et_SavingThrowIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_SeeInvisible);
			this.et_BenEffectsGrp.Controls.Add(this.et_SpellAbsorption);
			this.et_BenEffectsGrp.Controls.Add(this.et_SpellShield);
			this.et_BenEffectsGrp.Controls.Add(this.et_TempHitpoints);
			this.et_BenEffectsGrp.Controls.Add(this.et_Timestop);
			this.et_BenEffectsGrp.Controls.Add(this.et_TrueSeeing);
			this.et_BenEffectsGrp.Controls.Add(this.et_Ultravision);
			this.et_BenEffectsGrp.Controls.Add(this.et_Wildshape);
			this.et_BenEffectsGrp.Location = new System.Drawing.Point(390, 60);
			this.et_BenEffectsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.et_BenEffectsGrp.Name = "et_BenEffectsGrp";
			this.et_BenEffectsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.et_BenEffectsGrp.Size = new System.Drawing.Size(385, 320);
			this.et_BenEffectsGrp.TabIndex = 8;
			this.et_BenEffectsGrp.TabStop = false;
			this.et_BenEffectsGrp.Text = "C0FF FFFF beneficial";
			// 
			// et_AbilityIncrease
			// 
			this.et_AbilityIncrease.Location = new System.Drawing.Point(10, 15);
			this.et_AbilityIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbilityIncrease.Name = "et_AbilityIncrease";
			this.et_AbilityIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AbilityIncrease.TabIndex = 0;
			this.et_AbilityIncrease.Text = "ability increase";
			this.et_AbilityIncrease.UseVisualStyleBackColor = true;
			// 
			// et_AbsorbDamage
			// 
			this.et_AbsorbDamage.Location = new System.Drawing.Point(10, 35);
			this.et_AbsorbDamage.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbsorbDamage.Name = "et_AbsorbDamage";
			this.et_AbsorbDamage.Size = new System.Drawing.Size(180, 20);
			this.et_AbsorbDamage.TabIndex = 1;
			this.et_AbsorbDamage.Text = "absorb damage";
			this.et_AbsorbDamage.UseVisualStyleBackColor = true;
			// 
			// et_AcIncrease
			// 
			this.et_AcIncrease.Location = new System.Drawing.Point(10, 55);
			this.et_AcIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AcIncrease.Name = "et_AcIncrease";
			this.et_AcIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AcIncrease.TabIndex = 2;
			this.et_AcIncrease.Text = "ac increase";
			this.et_AcIncrease.UseVisualStyleBackColor = true;
			// 
			// et_AttackIncrease
			// 
			this.et_AttackIncrease.Location = new System.Drawing.Point(10, 75);
			this.et_AttackIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AttackIncrease.Name = "et_AttackIncrease";
			this.et_AttackIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AttackIncrease.TabIndex = 3;
			this.et_AttackIncrease.Text = "attack increase";
			this.et_AttackIncrease.UseVisualStyleBackColor = true;
			// 
			// et_Concealment
			// 
			this.et_Concealment.Location = new System.Drawing.Point(10, 95);
			this.et_Concealment.Margin = new System.Windows.Forms.Padding(0);
			this.et_Concealment.Name = "et_Concealment";
			this.et_Concealment.Size = new System.Drawing.Size(180, 20);
			this.et_Concealment.TabIndex = 4;
			this.et_Concealment.Text = "concealment";
			this.et_Concealment.UseVisualStyleBackColor = true;
			// 
			// et_DamageIncrease
			// 
			this.et_DamageIncrease.Location = new System.Drawing.Point(10, 115);
			this.et_DamageIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageIncrease.Name = "et_DamageIncrease";
			this.et_DamageIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_DamageIncrease.TabIndex = 5;
			this.et_DamageIncrease.Text = "damage increase";
			this.et_DamageIncrease.UseVisualStyleBackColor = true;
			// 
			// et_DamageReduction
			// 
			this.et_DamageReduction.Location = new System.Drawing.Point(10, 135);
			this.et_DamageReduction.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageReduction.Name = "et_DamageReduction";
			this.et_DamageReduction.Size = new System.Drawing.Size(180, 20);
			this.et_DamageReduction.TabIndex = 6;
			this.et_DamageReduction.Text = "damage reduction";
			this.et_DamageReduction.UseVisualStyleBackColor = true;
			// 
			// et_ElementalShield
			// 
			this.et_ElementalShield.Location = new System.Drawing.Point(10, 155);
			this.et_ElementalShield.Margin = new System.Windows.Forms.Padding(0);
			this.et_ElementalShield.Name = "et_ElementalShield";
			this.et_ElementalShield.Size = new System.Drawing.Size(180, 20);
			this.et_ElementalShield.TabIndex = 7;
			this.et_ElementalShield.Text = "elemental shield";
			this.et_ElementalShield.UseVisualStyleBackColor = true;
			// 
			// et_Ethereal
			// 
			this.et_Ethereal.Location = new System.Drawing.Point(10, 175);
			this.et_Ethereal.Margin = new System.Windows.Forms.Padding(0);
			this.et_Ethereal.Name = "et_Ethereal";
			this.et_Ethereal.Size = new System.Drawing.Size(180, 20);
			this.et_Ethereal.TabIndex = 8;
			this.et_Ethereal.Text = "ethereal";
			this.et_Ethereal.UseVisualStyleBackColor = true;
			// 
			// et_GreaterInvisibility
			// 
			this.et_GreaterInvisibility.Location = new System.Drawing.Point(10, 195);
			this.et_GreaterInvisibility.Margin = new System.Windows.Forms.Padding(0);
			this.et_GreaterInvisibility.Name = "et_GreaterInvisibility";
			this.et_GreaterInvisibility.Size = new System.Drawing.Size(180, 20);
			this.et_GreaterInvisibility.TabIndex = 9;
			this.et_GreaterInvisibility.Text = "greater invisibility";
			this.et_GreaterInvisibility.UseVisualStyleBackColor = true;
			// 
			// et_Haste
			// 
			this.et_Haste.Location = new System.Drawing.Point(10, 215);
			this.et_Haste.Margin = new System.Windows.Forms.Padding(0);
			this.et_Haste.Name = "et_Haste";
			this.et_Haste.Size = new System.Drawing.Size(180, 20);
			this.et_Haste.TabIndex = 10;
			this.et_Haste.Text = "haste";
			this.et_Haste.UseVisualStyleBackColor = true;
			// 
			// et_ImmunityNecromancy
			// 
			this.et_ImmunityNecromancy.Location = new System.Drawing.Point(10, 235);
			this.et_ImmunityNecromancy.Margin = new System.Windows.Forms.Padding(0);
			this.et_ImmunityNecromancy.Name = "et_ImmunityNecromancy";
			this.et_ImmunityNecromancy.Size = new System.Drawing.Size(180, 20);
			this.et_ImmunityNecromancy.TabIndex = 11;
			this.et_ImmunityNecromancy.Text = "immunity vs necromancy";
			this.et_ImmunityNecromancy.UseVisualStyleBackColor = true;
			// 
			// et_Invisibility
			// 
			this.et_Invisibility.Location = new System.Drawing.Point(10, 255);
			this.et_Invisibility.Margin = new System.Windows.Forms.Padding(0);
			this.et_Invisibility.Name = "et_Invisibility";
			this.et_Invisibility.Size = new System.Drawing.Size(180, 20);
			this.et_Invisibility.TabIndex = 12;
			this.et_Invisibility.Text = "invisibility";
			this.et_Invisibility.UseVisualStyleBackColor = true;
			// 
			// et_Polymorph
			// 
			this.et_Polymorph.Location = new System.Drawing.Point(200, 15);
			this.et_Polymorph.Margin = new System.Windows.Forms.Padding(0);
			this.et_Polymorph.Name = "et_Polymorph";
			this.et_Polymorph.Size = new System.Drawing.Size(180, 20);
			this.et_Polymorph.TabIndex = 13;
			this.et_Polymorph.Text = "polymorph";
			this.et_Polymorph.UseVisualStyleBackColor = true;
			// 
			// et_Regenerate
			// 
			this.et_Regenerate.Location = new System.Drawing.Point(200, 35);
			this.et_Regenerate.Margin = new System.Windows.Forms.Padding(0);
			this.et_Regenerate.Name = "et_Regenerate";
			this.et_Regenerate.Size = new System.Drawing.Size(180, 20);
			this.et_Regenerate.TabIndex = 14;
			this.et_Regenerate.Text = "regenerate";
			this.et_Regenerate.UseVisualStyleBackColor = true;
			// 
			// et_Sanctuary
			// 
			this.et_Sanctuary.Location = new System.Drawing.Point(200, 55);
			this.et_Sanctuary.Margin = new System.Windows.Forms.Padding(0);
			this.et_Sanctuary.Name = "et_Sanctuary";
			this.et_Sanctuary.Size = new System.Drawing.Size(180, 20);
			this.et_Sanctuary.TabIndex = 15;
			this.et_Sanctuary.Text = "sanctuary";
			this.et_Sanctuary.UseVisualStyleBackColor = true;
			// 
			// et_SavingThrowIncrease
			// 
			this.et_SavingThrowIncrease.Location = new System.Drawing.Point(200, 75);
			this.et_SavingThrowIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SavingThrowIncrease.Name = "et_SavingThrowIncrease";
			this.et_SavingThrowIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_SavingThrowIncrease.TabIndex = 16;
			this.et_SavingThrowIncrease.Text = "saving throw increase";
			this.et_SavingThrowIncrease.UseVisualStyleBackColor = true;
			// 
			// et_SeeInvisible
			// 
			this.et_SeeInvisible.Location = new System.Drawing.Point(200, 95);
			this.et_SeeInvisible.Margin = new System.Windows.Forms.Padding(0);
			this.et_SeeInvisible.Name = "et_SeeInvisible";
			this.et_SeeInvisible.Size = new System.Drawing.Size(180, 20);
			this.et_SeeInvisible.TabIndex = 17;
			this.et_SeeInvisible.Text = "see invisible";
			this.et_SeeInvisible.UseVisualStyleBackColor = true;
			// 
			// et_SpellAbsorption
			// 
			this.et_SpellAbsorption.Location = new System.Drawing.Point(200, 115);
			this.et_SpellAbsorption.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpellAbsorption.Name = "et_SpellAbsorption";
			this.et_SpellAbsorption.Size = new System.Drawing.Size(180, 20);
			this.et_SpellAbsorption.TabIndex = 18;
			this.et_SpellAbsorption.Text = "spell absorption";
			this.et_SpellAbsorption.UseVisualStyleBackColor = true;
			// 
			// et_SpellShield
			// 
			this.et_SpellShield.Location = new System.Drawing.Point(200, 135);
			this.et_SpellShield.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpellShield.Name = "et_SpellShield";
			this.et_SpellShield.Size = new System.Drawing.Size(180, 20);
			this.et_SpellShield.TabIndex = 19;
			this.et_SpellShield.Text = "spell shield";
			this.et_SpellShield.UseVisualStyleBackColor = true;
			// 
			// et_TempHitpoints
			// 
			this.et_TempHitpoints.Location = new System.Drawing.Point(200, 155);
			this.et_TempHitpoints.Margin = new System.Windows.Forms.Padding(0);
			this.et_TempHitpoints.Name = "et_TempHitpoints";
			this.et_TempHitpoints.Size = new System.Drawing.Size(180, 20);
			this.et_TempHitpoints.TabIndex = 20;
			this.et_TempHitpoints.Text = "temporary hitpoints";
			this.et_TempHitpoints.UseVisualStyleBackColor = true;
			// 
			// et_Timestop
			// 
			this.et_Timestop.Location = new System.Drawing.Point(200, 175);
			this.et_Timestop.Margin = new System.Windows.Forms.Padding(0);
			this.et_Timestop.Name = "et_Timestop";
			this.et_Timestop.Size = new System.Drawing.Size(180, 20);
			this.et_Timestop.TabIndex = 21;
			this.et_Timestop.Text = "timestop";
			this.et_Timestop.UseVisualStyleBackColor = true;
			// 
			// et_TrueSeeing
			// 
			this.et_TrueSeeing.Location = new System.Drawing.Point(200, 195);
			this.et_TrueSeeing.Margin = new System.Windows.Forms.Padding(0);
			this.et_TrueSeeing.Name = "et_TrueSeeing";
			this.et_TrueSeeing.Size = new System.Drawing.Size(180, 20);
			this.et_TrueSeeing.TabIndex = 22;
			this.et_TrueSeeing.Text = "true seeing";
			this.et_TrueSeeing.UseVisualStyleBackColor = true;
			// 
			// et_Ultravision
			// 
			this.et_Ultravision.Location = new System.Drawing.Point(200, 215);
			this.et_Ultravision.Margin = new System.Windows.Forms.Padding(0);
			this.et_Ultravision.Name = "et_Ultravision";
			this.et_Ultravision.Size = new System.Drawing.Size(180, 20);
			this.et_Ultravision.TabIndex = 23;
			this.et_Ultravision.Text = "ultravision";
			this.et_Ultravision.UseVisualStyleBackColor = true;
			// 
			// et_Wildshape
			// 
			this.et_Wildshape.Location = new System.Drawing.Point(200, 235);
			this.et_Wildshape.Margin = new System.Windows.Forms.Padding(0);
			this.et_Wildshape.Name = "et_Wildshape";
			this.et_Wildshape.Size = new System.Drawing.Size(180, 20);
			this.et_Wildshape.TabIndex = 24;
			this.et_Wildshape.Text = "wildshape";
			this.et_Wildshape.UseVisualStyleBackColor = true;
			// 
			// tp_DamageInfo
			// 
			this.tp_DamageInfo.BackColor = System.Drawing.Color.OldLace;
			this.tp_DamageInfo.Controls.Add(this.DamageInfo_reset);
			this.tp_DamageInfo.Controls.Add(this.DamageInfo_text);
			this.tp_DamageInfo.Controls.Add(this.DamageInfo_hex);
			this.tp_DamageInfo.Controls.Add(this.DamageInfo_bin);
			this.tp_DamageInfo.Controls.Add(this.di_Clear);
			this.tp_DamageInfo.Controls.Add(this.di_hex);
			this.tp_DamageInfo.Controls.Add(this.di_bin);
			this.tp_DamageInfo.Controls.Add(this.di_DetrimentalGrp);
			this.tp_DamageInfo.Controls.Add(this.di_BeneficialGrp);
			this.tp_DamageInfo.Controls.Add(this.di_DispelTypesGrp);
			this.tp_DamageInfo.Location = new System.Drawing.Point(4, 22);
			this.tp_DamageInfo.Margin = new System.Windows.Forms.Padding(0);
			this.tp_DamageInfo.Name = "tp_DamageInfo";
			this.tp_DamageInfo.Size = new System.Drawing.Size(815, 423);
			this.tp_DamageInfo.TabIndex = 25;
			this.tp_DamageInfo.Text = "DamageInfo";
			// 
			// DamageInfo_reset
			// 
			this.DamageInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.DamageInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_reset.Name = "DamageInfo_reset";
			this.DamageInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.DamageInfo_reset.TabIndex = 0;
			this.DamageInfo_reset.UseVisualStyleBackColor = true;
			// 
			// DamageInfo_text
			// 
			this.DamageInfo_text.Location = new System.Drawing.Point(5, 35);
			this.DamageInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_text.Name = "DamageInfo_text";
			this.DamageInfo_text.Size = new System.Drawing.Size(100, 20);
			this.DamageInfo_text.TabIndex = 1;
			this.DamageInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// DamageInfo_hex
			// 
			this.DamageInfo_hex.BackColor = System.Drawing.SystemColors.Window;
			this.DamageInfo_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DamageInfo_hex.Location = new System.Drawing.Point(115, 15);
			this.DamageInfo_hex.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_hex.Name = "DamageInfo_hex";
			this.DamageInfo_hex.ReadOnly = true;
			this.DamageInfo_hex.Size = new System.Drawing.Size(275, 13);
			this.DamageInfo_hex.TabIndex = 2;
			// 
			// DamageInfo_bin
			// 
			this.DamageInfo_bin.BackColor = System.Drawing.SystemColors.Window;
			this.DamageInfo_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.DamageInfo_bin.Location = new System.Drawing.Point(115, 35);
			this.DamageInfo_bin.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_bin.Name = "DamageInfo_bin";
			this.DamageInfo_bin.ReadOnly = true;
			this.DamageInfo_bin.Size = new System.Drawing.Size(275, 13);
			this.DamageInfo_bin.TabIndex = 3;
			// 
			// di_Clear
			// 
			this.di_Clear.Location = new System.Drawing.Point(450, 5);
			this.di_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.di_Clear.Name = "di_Clear";
			this.di_Clear.Size = new System.Drawing.Size(65, 50);
			this.di_Clear.TabIndex = 4;
			this.di_Clear.Text = "zero\r\nall\r\nbits";
			this.di_Clear.UseVisualStyleBackColor = true;
			// 
			// di_hex
			// 
			this.di_hex.Location = new System.Drawing.Point(400, 15);
			this.di_hex.Margin = new System.Windows.Forms.Padding(0);
			this.di_hex.Name = "di_hex";
			this.di_hex.Size = new System.Drawing.Size(40, 15);
			this.di_hex.TabIndex = 5;
			this.di_hex.Text = "hex";
			this.di_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_bin
			// 
			this.di_bin.Location = new System.Drawing.Point(400, 35);
			this.di_bin.Margin = new System.Windows.Forms.Padding(0);
			this.di_bin.Name = "di_bin";
			this.di_bin.Size = new System.Drawing.Size(40, 15);
			this.di_bin.TabIndex = 6;
			this.di_bin.Text = "bin";
			this.di_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_DetrimentalGrp
			// 
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamagebaseGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamageGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLeveltypeGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLevellimitGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLeveldivisorGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetFixedCountGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamagetypeGrp);
			this.di_DetrimentalGrp.Location = new System.Drawing.Point(5, 60);
			this.di_DetrimentalGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetrimentalGrp.Name = "di_DetrimentalGrp";
			this.di_DetrimentalGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetrimentalGrp.Size = new System.Drawing.Size(380, 280);
			this.di_DetrimentalGrp.TabIndex = 7;
			this.di_DetrimentalGrp.TabStop = false;
			this.di_DetrimentalGrp.Text = "detrimental";
			// 
			// di_DetDamagebaseGrp
			// 
			this.di_DetDamagebaseGrp.Controls.Add(this.di_co_DetDamagebase);
			this.di_DetDamagebaseGrp.Location = new System.Drawing.Point(5, 15);
			this.di_DetDamagebaseGrp.Name = "di_DetDamagebaseGrp";
			this.di_DetDamagebaseGrp.Size = new System.Drawing.Size(240, 45);
			this.di_DetDamagebaseGrp.TabIndex = 0;
			this.di_DetDamagebaseGrp.TabStop = false;
			this.di_DetDamagebaseGrp.Text = "F000 0000 damagebase";
			// 
			// di_co_DetDamagebase
			// 
			this.di_co_DetDamagebase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.di_co_DetDamagebase.FormattingEnabled = true;
			this.di_co_DetDamagebase.Location = new System.Drawing.Point(5, 15);
			this.di_co_DetDamagebase.Margin = new System.Windows.Forms.Padding(0);
			this.di_co_DetDamagebase.Name = "di_co_DetDamagebase";
			this.di_co_DetDamagebase.Size = new System.Drawing.Size(230, 21);
			this.di_co_DetDamagebase.TabIndex = 0;
			// 
			// di_DetDamageGrp
			// 
			this.di_DetDamageGrp.Controls.Add(this.di_DetDamage);
			this.di_DetDamageGrp.Location = new System.Drawing.Point(5, 60);
			this.di_DetDamageGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamageGrp.Name = "di_DetDamageGrp";
			this.di_DetDamageGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetDamageGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetDamageGrp.TabIndex = 1;
			this.di_DetDamageGrp.TabStop = false;
			this.di_DetDamageGrp.Text = "000F F000 damage";
			// 
			// di_DetDamage
			// 
			this.di_DetDamage.Location = new System.Drawing.Point(5, 15);
			this.di_DetDamage.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamage.Name = "di_DetDamage";
			this.di_DetDamage.Size = new System.Drawing.Size(85, 20);
			this.di_DetDamage.TabIndex = 0;
			// 
			// di_DetLeveltypeGrp
			// 
			this.di_DetLeveltypeGrp.Controls.Add(this.di_co_DetLeveltype);
			this.di_DetLeveltypeGrp.Location = new System.Drawing.Point(5, 100);
			this.di_DetLeveltypeGrp.Name = "di_DetLeveltypeGrp";
			this.di_DetLeveltypeGrp.Size = new System.Drawing.Size(240, 45);
			this.di_DetLeveltypeGrp.TabIndex = 2;
			this.di_DetLeveltypeGrp.TabStop = false;
			this.di_DetLeveltypeGrp.Text = "0300 0000 leveltype";
			// 
			// di_co_DetLeveltype
			// 
			this.di_co_DetLeveltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.di_co_DetLeveltype.FormattingEnabled = true;
			this.di_co_DetLeveltype.Location = new System.Drawing.Point(5, 15);
			this.di_co_DetLeveltype.Margin = new System.Windows.Forms.Padding(0);
			this.di_co_DetLeveltype.Name = "di_co_DetLeveltype";
			this.di_co_DetLeveltype.Size = new System.Drawing.Size(230, 21);
			this.di_co_DetLeveltype.TabIndex = 0;
			// 
			// di_DetLevellimitGrp
			// 
			this.di_DetLevellimitGrp.Controls.Add(this.di_DetLevellimit);
			this.di_DetLevellimitGrp.Location = new System.Drawing.Point(5, 145);
			this.di_DetLevellimitGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimitGrp.Name = "di_DetLevellimitGrp";
			this.di_DetLevellimitGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimitGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetLevellimitGrp.TabIndex = 3;
			this.di_DetLevellimitGrp.TabStop = false;
			this.di_DetLevellimitGrp.Text = "00F0 0000 levellimit";
			// 
			// di_DetLevellimit
			// 
			this.di_DetLevellimit.Location = new System.Drawing.Point(5, 15);
			this.di_DetLevellimit.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimit.Name = "di_DetLevellimit";
			this.di_DetLevellimit.Size = new System.Drawing.Size(85, 20);
			this.di_DetLevellimit.TabIndex = 0;
			// 
			// di_DetLeveldivisorGrp
			// 
			this.di_DetLeveldivisorGrp.Controls.Add(this.di_DetLeveldivisor);
			this.di_DetLeveldivisorGrp.Location = new System.Drawing.Point(5, 185);
			this.di_DetLeveldivisorGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisorGrp.Name = "di_DetLeveldivisorGrp";
			this.di_DetLeveldivisorGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisorGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetLeveldivisorGrp.TabIndex = 4;
			this.di_DetLeveldivisorGrp.TabStop = false;
			this.di_DetLeveldivisorGrp.Text = "0C00 0000 leveldivisor";
			// 
			// di_DetLeveldivisor
			// 
			this.di_DetLeveldivisor.Location = new System.Drawing.Point(5, 15);
			this.di_DetLeveldivisor.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisor.Name = "di_DetLeveldivisor";
			this.di_DetLeveldivisor.Size = new System.Drawing.Size(85, 20);
			this.di_DetLeveldivisor.TabIndex = 0;
			// 
			// di_DetFixedCountGrp
			// 
			this.di_DetFixedCountGrp.Controls.Add(this.di_DetFixedcount);
			this.di_DetFixedCountGrp.Controls.Add(this.di_lbl_FixedCountPlusOne);
			this.di_DetFixedCountGrp.Location = new System.Drawing.Point(5, 225);
			this.di_DetFixedCountGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetFixedCountGrp.Name = "di_DetFixedCountGrp";
			this.di_DetFixedCountGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetFixedCountGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetFixedCountGrp.TabIndex = 5;
			this.di_DetFixedCountGrp.TabStop = false;
			this.di_DetFixedCountGrp.Text = "0F00 0000 fixedcount";
			// 
			// di_DetFixedcount
			// 
			this.di_DetFixedcount.Location = new System.Drawing.Point(5, 15);
			this.di_DetFixedcount.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetFixedcount.Name = "di_DetFixedcount";
			this.di_DetFixedcount.Size = new System.Drawing.Size(85, 20);
			this.di_DetFixedcount.TabIndex = 0;
			// 
			// di_lbl_FixedCountPlusOne
			// 
			this.di_lbl_FixedCountPlusOne.Location = new System.Drawing.Point(95, 15);
			this.di_lbl_FixedCountPlusOne.Margin = new System.Windows.Forms.Padding(0);
			this.di_lbl_FixedCountPlusOne.Name = "di_lbl_FixedCountPlusOne";
			this.di_lbl_FixedCountPlusOne.Size = new System.Drawing.Size(30, 20);
			this.di_lbl_FixedCountPlusOne.TabIndex = 2;
			this.di_lbl_FixedCountPlusOne.Text = "+1";
			this.di_lbl_FixedCountPlusOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_DetDamagetypeGrp
			// 
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Magical);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Divine);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Acid);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Cold);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Electrical);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Fire);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Sonic);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Negative);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Positive);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Bludgeoning);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Piercing);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Slashing);
			this.di_DetDamagetypeGrp.Location = new System.Drawing.Point(245, 15);
			this.di_DetDamagetypeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamagetypeGrp.Name = "di_DetDamagetypeGrp";
			this.di_DetDamagetypeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetDamagetypeGrp.Size = new System.Drawing.Size(130, 260);
			this.di_DetDamagetypeGrp.TabIndex = 6;
			this.di_DetDamagetypeGrp.TabStop = false;
			this.di_DetDamagetypeGrp.Text = "0000 0FFF types";
			// 
			// di_Magical
			// 
			this.di_Magical.Location = new System.Drawing.Point(10, 15);
			this.di_Magical.Margin = new System.Windows.Forms.Padding(0);
			this.di_Magical.Name = "di_Magical";
			this.di_Magical.Size = new System.Drawing.Size(105, 20);
			this.di_Magical.TabIndex = 0;
			this.di_Magical.Text = "magical";
			this.di_Magical.UseVisualStyleBackColor = true;
			// 
			// di_Divine
			// 
			this.di_Divine.Location = new System.Drawing.Point(10, 35);
			this.di_Divine.Margin = new System.Windows.Forms.Padding(0);
			this.di_Divine.Name = "di_Divine";
			this.di_Divine.Size = new System.Drawing.Size(105, 20);
			this.di_Divine.TabIndex = 1;
			this.di_Divine.Text = "divine";
			this.di_Divine.UseVisualStyleBackColor = true;
			// 
			// di_Acid
			// 
			this.di_Acid.Location = new System.Drawing.Point(10, 55);
			this.di_Acid.Margin = new System.Windows.Forms.Padding(0);
			this.di_Acid.Name = "di_Acid";
			this.di_Acid.Size = new System.Drawing.Size(105, 20);
			this.di_Acid.TabIndex = 2;
			this.di_Acid.Text = "acid";
			this.di_Acid.UseVisualStyleBackColor = true;
			// 
			// di_Cold
			// 
			this.di_Cold.Location = new System.Drawing.Point(10, 75);
			this.di_Cold.Margin = new System.Windows.Forms.Padding(0);
			this.di_Cold.Name = "di_Cold";
			this.di_Cold.Size = new System.Drawing.Size(105, 20);
			this.di_Cold.TabIndex = 3;
			this.di_Cold.Text = "cold";
			this.di_Cold.UseVisualStyleBackColor = true;
			// 
			// di_Electrical
			// 
			this.di_Electrical.Location = new System.Drawing.Point(10, 95);
			this.di_Electrical.Margin = new System.Windows.Forms.Padding(0);
			this.di_Electrical.Name = "di_Electrical";
			this.di_Electrical.Size = new System.Drawing.Size(105, 20);
			this.di_Electrical.TabIndex = 4;
			this.di_Electrical.Text = "electrical";
			this.di_Electrical.UseVisualStyleBackColor = true;
			// 
			// di_Fire
			// 
			this.di_Fire.Location = new System.Drawing.Point(10, 115);
			this.di_Fire.Margin = new System.Windows.Forms.Padding(0);
			this.di_Fire.Name = "di_Fire";
			this.di_Fire.Size = new System.Drawing.Size(105, 20);
			this.di_Fire.TabIndex = 5;
			this.di_Fire.Text = "fire";
			this.di_Fire.UseVisualStyleBackColor = true;
			// 
			// di_Sonic
			// 
			this.di_Sonic.Location = new System.Drawing.Point(10, 135);
			this.di_Sonic.Margin = new System.Windows.Forms.Padding(0);
			this.di_Sonic.Name = "di_Sonic";
			this.di_Sonic.Size = new System.Drawing.Size(105, 20);
			this.di_Sonic.TabIndex = 6;
			this.di_Sonic.Text = "sonic";
			this.di_Sonic.UseVisualStyleBackColor = true;
			// 
			// di_Negative
			// 
			this.di_Negative.Location = new System.Drawing.Point(10, 155);
			this.di_Negative.Margin = new System.Windows.Forms.Padding(0);
			this.di_Negative.Name = "di_Negative";
			this.di_Negative.Size = new System.Drawing.Size(105, 20);
			this.di_Negative.TabIndex = 7;
			this.di_Negative.Text = "negative";
			this.di_Negative.UseVisualStyleBackColor = true;
			// 
			// di_Positive
			// 
			this.di_Positive.Location = new System.Drawing.Point(10, 175);
			this.di_Positive.Margin = new System.Windows.Forms.Padding(0);
			this.di_Positive.Name = "di_Positive";
			this.di_Positive.Size = new System.Drawing.Size(105, 20);
			this.di_Positive.TabIndex = 8;
			this.di_Positive.Text = "positive";
			this.di_Positive.UseVisualStyleBackColor = true;
			// 
			// di_Bludgeoning
			// 
			this.di_Bludgeoning.Location = new System.Drawing.Point(10, 195);
			this.di_Bludgeoning.Margin = new System.Windows.Forms.Padding(0);
			this.di_Bludgeoning.Name = "di_Bludgeoning";
			this.di_Bludgeoning.Size = new System.Drawing.Size(105, 20);
			this.di_Bludgeoning.TabIndex = 9;
			this.di_Bludgeoning.Text = "bludgeoning";
			this.di_Bludgeoning.UseVisualStyleBackColor = true;
			// 
			// di_Piercing
			// 
			this.di_Piercing.Location = new System.Drawing.Point(10, 215);
			this.di_Piercing.Margin = new System.Windows.Forms.Padding(0);
			this.di_Piercing.Name = "di_Piercing";
			this.di_Piercing.Size = new System.Drawing.Size(105, 20);
			this.di_Piercing.TabIndex = 10;
			this.di_Piercing.Text = "piercing";
			this.di_Piercing.UseVisualStyleBackColor = true;
			// 
			// di_Slashing
			// 
			this.di_Slashing.Location = new System.Drawing.Point(10, 235);
			this.di_Slashing.Margin = new System.Windows.Forms.Padding(0);
			this.di_Slashing.Name = "di_Slashing";
			this.di_Slashing.Size = new System.Drawing.Size(105, 20);
			this.di_Slashing.TabIndex = 11;
			this.di_Slashing.Text = "slashing";
			this.di_Slashing.UseVisualStyleBackColor = true;
			// 
			// di_BeneficialGrp
			// 
			this.di_BeneficialGrp.Controls.Add(this.di_BenPowerbaseGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenPowerGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveltypeGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLevellimitGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveldivisorGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveldecreaseGrp);
			this.di_BeneficialGrp.Location = new System.Drawing.Point(385, 60);
			this.di_BeneficialGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BeneficialGrp.Name = "di_BeneficialGrp";
			this.di_BeneficialGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BeneficialGrp.Size = new System.Drawing.Size(250, 280);
			this.di_BeneficialGrp.TabIndex = 8;
			this.di_BeneficialGrp.TabStop = false;
			this.di_BeneficialGrp.Text = "beneficial";
			// 
			// di_BenPowerbaseGrp
			// 
			this.di_BenPowerbaseGrp.Controls.Add(this.di_co_BenPowerbase);
			this.di_BenPowerbaseGrp.Location = new System.Drawing.Point(5, 15);
			this.di_BenPowerbaseGrp.Name = "di_BenPowerbaseGrp";
			this.di_BenPowerbaseGrp.Size = new System.Drawing.Size(240, 45);
			this.di_BenPowerbaseGrp.TabIndex = 0;
			this.di_BenPowerbaseGrp.TabStop = false;
			this.di_BenPowerbaseGrp.Text = "0F00 0000 powerbase";
			// 
			// di_co_BenPowerbase
			// 
			this.di_co_BenPowerbase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.di_co_BenPowerbase.FormattingEnabled = true;
			this.di_co_BenPowerbase.Location = new System.Drawing.Point(5, 15);
			this.di_co_BenPowerbase.Margin = new System.Windows.Forms.Padding(0);
			this.di_co_BenPowerbase.Name = "di_co_BenPowerbase";
			this.di_co_BenPowerbase.Size = new System.Drawing.Size(230, 21);
			this.di_co_BenPowerbase.TabIndex = 0;
			// 
			// di_BenPowerGrp
			// 
			this.di_BenPowerGrp.Controls.Add(this.di_BenPower);
			this.di_BenPowerGrp.Location = new System.Drawing.Point(5, 60);
			this.di_BenPowerGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenPowerGrp.Name = "di_BenPowerGrp";
			this.di_BenPowerGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenPowerGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenPowerGrp.TabIndex = 1;
			this.di_BenPowerGrp.TabStop = false;
			this.di_BenPowerGrp.Text = "0000 00FF power";
			// 
			// di_BenPower
			// 
			this.di_BenPower.Location = new System.Drawing.Point(5, 15);
			this.di_BenPower.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenPower.Name = "di_BenPower";
			this.di_BenPower.Size = new System.Drawing.Size(85, 20);
			this.di_BenPower.TabIndex = 0;
			// 
			// di_BenLeveltypeGrp
			// 
			this.di_BenLeveltypeGrp.Controls.Add(this.di_co_BenLeveltype);
			this.di_BenLeveltypeGrp.Location = new System.Drawing.Point(5, 100);
			this.di_BenLeveltypeGrp.Name = "di_BenLeveltypeGrp";
			this.di_BenLeveltypeGrp.Size = new System.Drawing.Size(240, 45);
			this.di_BenLeveltypeGrp.TabIndex = 2;
			this.di_BenLeveltypeGrp.TabStop = false;
			this.di_BenLeveltypeGrp.Text = "0000 C000 leveltype";
			// 
			// di_co_BenLeveltype
			// 
			this.di_co_BenLeveltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.di_co_BenLeveltype.FormattingEnabled = true;
			this.di_co_BenLeveltype.Location = new System.Drawing.Point(5, 15);
			this.di_co_BenLeveltype.Margin = new System.Windows.Forms.Padding(0);
			this.di_co_BenLeveltype.Name = "di_co_BenLeveltype";
			this.di_co_BenLeveltype.Size = new System.Drawing.Size(230, 21);
			this.di_co_BenLeveltype.TabIndex = 0;
			// 
			// di_BenLevellimitGrp
			// 
			this.di_BenLevellimitGrp.Controls.Add(this.di_BenLevellimit);
			this.di_BenLevellimitGrp.Location = new System.Drawing.Point(5, 145);
			this.di_BenLevellimitGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimitGrp.Name = "di_BenLevellimitGrp";
			this.di_BenLevellimitGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimitGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLevellimitGrp.TabIndex = 3;
			this.di_BenLevellimitGrp.TabStop = false;
			this.di_BenLevellimitGrp.Text = "0000 3F00 levellimit";
			// 
			// di_BenLevellimit
			// 
			this.di_BenLevellimit.Location = new System.Drawing.Point(5, 15);
			this.di_BenLevellimit.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimit.Name = "di_BenLevellimit";
			this.di_BenLevellimit.Size = new System.Drawing.Size(85, 20);
			this.di_BenLevellimit.TabIndex = 0;
			// 
			// di_BenLeveldivisorGrp
			// 
			this.di_BenLeveldivisorGrp.Controls.Add(this.di_BenLeveldivisor);
			this.di_BenLeveldivisorGrp.Location = new System.Drawing.Point(5, 185);
			this.di_BenLeveldivisorGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisorGrp.Name = "di_BenLeveldivisorGrp";
			this.di_BenLeveldivisorGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisorGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLeveldivisorGrp.TabIndex = 4;
			this.di_BenLeveldivisorGrp.TabStop = false;
			this.di_BenLeveldivisorGrp.Text = "000F 0000 leveldivisor";
			// 
			// di_BenLeveldivisor
			// 
			this.di_BenLeveldivisor.Location = new System.Drawing.Point(5, 15);
			this.di_BenLeveldivisor.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisor.Name = "di_BenLeveldivisor";
			this.di_BenLeveldivisor.Size = new System.Drawing.Size(85, 20);
			this.di_BenLeveldivisor.TabIndex = 0;
			// 
			// di_BenLeveldecreaseGrp
			// 
			this.di_BenLeveldecreaseGrp.Controls.Add(this.di_BenLeveldecrease);
			this.di_BenLeveldecreaseGrp.Location = new System.Drawing.Point(5, 225);
			this.di_BenLeveldecreaseGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecreaseGrp.Name = "di_BenLeveldecreaseGrp";
			this.di_BenLeveldecreaseGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecreaseGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLeveldecreaseGrp.TabIndex = 5;
			this.di_BenLeveldecreaseGrp.TabStop = false;
			this.di_BenLeveldecreaseGrp.Text = "00F0 0000 leveldecrease";
			// 
			// di_BenLeveldecrease
			// 
			this.di_BenLeveldecrease.Location = new System.Drawing.Point(5, 15);
			this.di_BenLeveldecrease.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecrease.Name = "di_BenLeveldecrease";
			this.di_BenLeveldecrease.Size = new System.Drawing.Size(85, 20);
			this.di_BenLeveldecrease.TabIndex = 0;
			// 
			// di_DispelTypesGrp
			// 
			this.di_DispelTypesGrp.Controls.Add(this.di_Breach);
			this.di_DispelTypesGrp.Controls.Add(this.di_Dispel);
			this.di_DispelTypesGrp.Controls.Add(this.di_Resist);
			this.di_DispelTypesGrp.Location = new System.Drawing.Point(5, 340);
			this.di_DispelTypesGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DispelTypesGrp.Name = "di_DispelTypesGrp";
			this.di_DispelTypesGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DispelTypesGrp.Size = new System.Drawing.Size(170, 80);
			this.di_DispelTypesGrp.TabIndex = 9;
			this.di_DispelTypesGrp.TabStop = false;
			this.di_DispelTypesGrp.Text = "0000 0007 dispeltypes";
			// 
			// di_Breach
			// 
			this.di_Breach.Location = new System.Drawing.Point(10, 15);
			this.di_Breach.Margin = new System.Windows.Forms.Padding(0);
			this.di_Breach.Name = "di_Breach";
			this.di_Breach.Size = new System.Drawing.Size(70, 20);
			this.di_Breach.TabIndex = 0;
			this.di_Breach.Text = "Breach";
			this.di_Breach.UseVisualStyleBackColor = true;
			// 
			// di_Dispel
			// 
			this.di_Dispel.Location = new System.Drawing.Point(10, 35);
			this.di_Dispel.Margin = new System.Windows.Forms.Padding(0);
			this.di_Dispel.Name = "di_Dispel";
			this.di_Dispel.Size = new System.Drawing.Size(70, 20);
			this.di_Dispel.TabIndex = 1;
			this.di_Dispel.Text = "Dispel";
			this.di_Dispel.UseVisualStyleBackColor = true;
			// 
			// di_Resist
			// 
			this.di_Resist.Location = new System.Drawing.Point(10, 55);
			this.di_Resist.Margin = new System.Windows.Forms.Padding(0);
			this.di_Resist.Name = "di_Resist";
			this.di_Resist.Size = new System.Drawing.Size(70, 20);
			this.di_Resist.TabIndex = 2;
			this.di_Resist.Text = "Resist";
			this.di_Resist.UseVisualStyleBackColor = true;
			// 
			// tp_SaveType
			// 
			this.tp_SaveType.BackColor = System.Drawing.Color.OldLace;
			this.tp_SaveType.Controls.Add(this.SaveType_reset);
			this.tp_SaveType.Controls.Add(this.SaveType_text);
			this.tp_SaveType.Controls.Add(this.SaveType_hex);
			this.tp_SaveType.Controls.Add(this.SaveType_bin);
			this.tp_SaveType.Controls.Add(this.st_Clear);
			this.tp_SaveType.Controls.Add(this.st_hex);
			this.tp_SaveType.Controls.Add(this.st_bin);
			this.tp_SaveType.Controls.Add(this.st_DetrimentalGrp);
			this.tp_SaveType.Controls.Add(this.st_ExclusiveGrp);
			this.tp_SaveType.Controls.Add(this.st_TargetRestrictionGrp);
			this.tp_SaveType.Controls.Add(this.st_NotCaster);
			this.tp_SaveType.Controls.Add(this.st_AcBonusGrp);
			this.tp_SaveType.Location = new System.Drawing.Point(4, 22);
			this.tp_SaveType.Margin = new System.Windows.Forms.Padding(0);
			this.tp_SaveType.Name = "tp_SaveType";
			this.tp_SaveType.Size = new System.Drawing.Size(815, 423);
			this.tp_SaveType.TabIndex = 5;
			this.tp_SaveType.Text = "SaveType";
			// 
			// SaveType_reset
			// 
			this.SaveType_reset.Location = new System.Drawing.Point(5, 5);
			this.SaveType_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_reset.Name = "SaveType_reset";
			this.SaveType_reset.Size = new System.Drawing.Size(100, 25);
			this.SaveType_reset.TabIndex = 0;
			this.SaveType_reset.UseVisualStyleBackColor = true;
			// 
			// SaveType_text
			// 
			this.SaveType_text.Location = new System.Drawing.Point(5, 35);
			this.SaveType_text.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_text.Name = "SaveType_text";
			this.SaveType_text.Size = new System.Drawing.Size(100, 20);
			this.SaveType_text.TabIndex = 1;
			this.SaveType_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SaveType_hex
			// 
			this.SaveType_hex.BackColor = System.Drawing.SystemColors.Window;
			this.SaveType_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SaveType_hex.Location = new System.Drawing.Point(115, 15);
			this.SaveType_hex.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_hex.Name = "SaveType_hex";
			this.SaveType_hex.ReadOnly = true;
			this.SaveType_hex.Size = new System.Drawing.Size(275, 13);
			this.SaveType_hex.TabIndex = 2;
			// 
			// SaveType_bin
			// 
			this.SaveType_bin.BackColor = System.Drawing.SystemColors.Window;
			this.SaveType_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SaveType_bin.Location = new System.Drawing.Point(115, 35);
			this.SaveType_bin.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_bin.Name = "SaveType_bin";
			this.SaveType_bin.ReadOnly = true;
			this.SaveType_bin.Size = new System.Drawing.Size(275, 13);
			this.SaveType_bin.TabIndex = 3;
			// 
			// st_Clear
			// 
			this.st_Clear.Location = new System.Drawing.Point(450, 5);
			this.st_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.st_Clear.Name = "st_Clear";
			this.st_Clear.Size = new System.Drawing.Size(65, 50);
			this.st_Clear.TabIndex = 4;
			this.st_Clear.Text = "zero\r\nall\r\nbits";
			this.st_Clear.UseVisualStyleBackColor = true;
			// 
			// st_hex
			// 
			this.st_hex.Location = new System.Drawing.Point(400, 15);
			this.st_hex.Margin = new System.Windows.Forms.Padding(0);
			this.st_hex.Name = "st_hex";
			this.st_hex.Size = new System.Drawing.Size(40, 15);
			this.st_hex.TabIndex = 5;
			this.st_hex.Text = "hex";
			this.st_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// st_bin
			// 
			this.st_bin.Location = new System.Drawing.Point(400, 35);
			this.st_bin.Margin = new System.Windows.Forms.Padding(0);
			this.st_bin.Name = "st_bin";
			this.st_bin.Size = new System.Drawing.Size(40, 15);
			this.st_bin.TabIndex = 6;
			this.st_bin.Text = "bin";
			this.st_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// st_DetrimentalGrp
			// 
			this.st_DetrimentalGrp.Controls.Add(this.st_Save1Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Save2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Impact1Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Impact2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_FlagsGrp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Immunity1Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Immunity2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_SpecificGrp);
			this.st_DetrimentalGrp.Location = new System.Drawing.Point(5, 60);
			this.st_DetrimentalGrp.Name = "st_DetrimentalGrp";
			this.st_DetrimentalGrp.Size = new System.Drawing.Size(535, 275);
			this.st_DetrimentalGrp.TabIndex = 7;
			this.st_DetrimentalGrp.TabStop = false;
			this.st_DetrimentalGrp.Text = "attack";
			// 
			// st_Save1Grp
			// 
			this.st_Save1Grp.Controls.Add(this.st_Save1rb_will);
			this.st_Save1Grp.Controls.Add(this.st_Save1rb_refl);
			this.st_Save1Grp.Controls.Add(this.st_Save1rb_fort);
			this.st_Save1Grp.Controls.Add(this.st_Save1rb_none);
			this.st_Save1Grp.Location = new System.Drawing.Point(5, 15);
			this.st_Save1Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save1Grp.Name = "st_Save1Grp";
			this.st_Save1Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Save1Grp.Size = new System.Drawing.Size(130, 105);
			this.st_Save1Grp.TabIndex = 0;
			this.st_Save1Grp.TabStop = false;
			this.st_Save1Grp.Text = "000C 0000 save1";
			// 
			// st_Save1rb_will
			// 
			this.st_Save1rb_will.Location = new System.Drawing.Point(5, 75);
			this.st_Save1rb_will.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save1rb_will.Name = "st_Save1rb_will";
			this.st_Save1rb_will.Size = new System.Drawing.Size(90, 20);
			this.st_Save1rb_will.TabIndex = 3;
			this.st_Save1rb_will.TabStop = true;
			this.st_Save1rb_will.Text = "will";
			this.st_Save1rb_will.UseVisualStyleBackColor = true;
			// 
			// st_Save1rb_refl
			// 
			this.st_Save1rb_refl.Location = new System.Drawing.Point(5, 55);
			this.st_Save1rb_refl.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save1rb_refl.Name = "st_Save1rb_refl";
			this.st_Save1rb_refl.Size = new System.Drawing.Size(90, 20);
			this.st_Save1rb_refl.TabIndex = 2;
			this.st_Save1rb_refl.TabStop = true;
			this.st_Save1rb_refl.Text = "reflex";
			this.st_Save1rb_refl.UseVisualStyleBackColor = true;
			// 
			// st_Save1rb_fort
			// 
			this.st_Save1rb_fort.Location = new System.Drawing.Point(5, 35);
			this.st_Save1rb_fort.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save1rb_fort.Name = "st_Save1rb_fort";
			this.st_Save1rb_fort.Size = new System.Drawing.Size(90, 20);
			this.st_Save1rb_fort.TabIndex = 1;
			this.st_Save1rb_fort.TabStop = true;
			this.st_Save1rb_fort.Text = "fortitude";
			this.st_Save1rb_fort.UseVisualStyleBackColor = true;
			// 
			// st_Save1rb_none
			// 
			this.st_Save1rb_none.Location = new System.Drawing.Point(5, 15);
			this.st_Save1rb_none.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save1rb_none.Name = "st_Save1rb_none";
			this.st_Save1rb_none.Size = new System.Drawing.Size(90, 20);
			this.st_Save1rb_none.TabIndex = 0;
			this.st_Save1rb_none.TabStop = true;
			this.st_Save1rb_none.Text = "none";
			this.st_Save1rb_none.UseVisualStyleBackColor = true;
			// 
			// st_Save2Grp
			// 
			this.st_Save2Grp.Controls.Add(this.st_Save2rb_will);
			this.st_Save2Grp.Controls.Add(this.st_Save2rb_refl);
			this.st_Save2Grp.Controls.Add(this.st_Save2rb_fort);
			this.st_Save2Grp.Controls.Add(this.st_Save2rb_none);
			this.st_Save2Grp.Location = new System.Drawing.Point(5, 120);
			this.st_Save2Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2Grp.Name = "st_Save2Grp";
			this.st_Save2Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Save2Grp.Size = new System.Drawing.Size(130, 105);
			this.st_Save2Grp.TabIndex = 1;
			this.st_Save2Grp.TabStop = false;
			this.st_Save2Grp.Text = "00C0 0000 save2";
			// 
			// st_Save2rb_will
			// 
			this.st_Save2rb_will.Location = new System.Drawing.Point(5, 75);
			this.st_Save2rb_will.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_will.Name = "st_Save2rb_will";
			this.st_Save2rb_will.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_will.TabIndex = 3;
			this.st_Save2rb_will.TabStop = true;
			this.st_Save2rb_will.Text = "will";
			this.st_Save2rb_will.UseVisualStyleBackColor = true;
			// 
			// st_Save2rb_refl
			// 
			this.st_Save2rb_refl.Location = new System.Drawing.Point(5, 55);
			this.st_Save2rb_refl.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_refl.Name = "st_Save2rb_refl";
			this.st_Save2rb_refl.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_refl.TabIndex = 2;
			this.st_Save2rb_refl.TabStop = true;
			this.st_Save2rb_refl.Text = "reflex";
			this.st_Save2rb_refl.UseVisualStyleBackColor = true;
			// 
			// st_Save2rb_fort
			// 
			this.st_Save2rb_fort.Location = new System.Drawing.Point(5, 35);
			this.st_Save2rb_fort.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_fort.Name = "st_Save2rb_fort";
			this.st_Save2rb_fort.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_fort.TabIndex = 1;
			this.st_Save2rb_fort.TabStop = true;
			this.st_Save2rb_fort.Text = "fortitude";
			this.st_Save2rb_fort.UseVisualStyleBackColor = true;
			// 
			// st_Save2rb_none
			// 
			this.st_Save2rb_none.Location = new System.Drawing.Point(5, 15);
			this.st_Save2rb_none.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_none.Name = "st_Save2rb_none";
			this.st_Save2rb_none.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_none.TabIndex = 0;
			this.st_Save2rb_none.TabStop = true;
			this.st_Save2rb_none.Text = "none";
			this.st_Save2rb_none.UseVisualStyleBackColor = true;
			// 
			// st_Impact1Grp
			// 
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_effectonly);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_damagehalf);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_effectdamage);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_damageevasion);
			this.st_Impact1Grp.Location = new System.Drawing.Point(145, 15);
			this.st_Impact1Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1Grp.Name = "st_Impact1Grp";
			this.st_Impact1Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Impact1Grp.Size = new System.Drawing.Size(140, 105);
			this.st_Impact1Grp.TabIndex = 2;
			this.st_Impact1Grp.TabStop = false;
			this.st_Impact1Grp.Text = "0030 0000 damage1";
			// 
			// st_Impact1rb_effectonly
			// 
			this.st_Impact1rb_effectonly.Location = new System.Drawing.Point(5, 15);
			this.st_Impact1rb_effectonly.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_effectonly.Name = "st_Impact1rb_effectonly";
			this.st_Impact1rb_effectonly.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_effectonly.TabIndex = 0;
			this.st_Impact1rb_effectonly.TabStop = true;
			this.st_Impact1rb_effectonly.Text = "none";
			this.st_Impact1rb_effectonly.UseVisualStyleBackColor = true;
			// 
			// st_Impact1rb_damagehalf
			// 
			this.st_Impact1rb_damagehalf.Location = new System.Drawing.Point(5, 35);
			this.st_Impact1rb_damagehalf.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_damagehalf.Name = "st_Impact1rb_damagehalf";
			this.st_Impact1rb_damagehalf.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_damagehalf.TabIndex = 1;
			this.st_Impact1rb_damagehalf.TabStop = true;
			this.st_Impact1rb_damagehalf.Text = "half";
			this.st_Impact1rb_damagehalf.UseVisualStyleBackColor = true;
			// 
			// st_Impact1rb_effectdamage
			// 
			this.st_Impact1rb_effectdamage.Location = new System.Drawing.Point(5, 55);
			this.st_Impact1rb_effectdamage.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_effectdamage.Name = "st_Impact1rb_effectdamage";
			this.st_Impact1rb_effectdamage.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_effectdamage.TabIndex = 2;
			this.st_Impact1rb_effectdamage.TabStop = true;
			this.st_Impact1rb_effectdamage.Text = "regular";
			this.st_Impact1rb_effectdamage.UseVisualStyleBackColor = true;
			// 
			// st_Impact1rb_damageevasion
			// 
			this.st_Impact1rb_damageevasion.Location = new System.Drawing.Point(5, 75);
			this.st_Impact1rb_damageevasion.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_damageevasion.Name = "st_Impact1rb_damageevasion";
			this.st_Impact1rb_damageevasion.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_damageevasion.TabIndex = 3;
			this.st_Impact1rb_damageevasion.TabStop = true;
			this.st_Impact1rb_damageevasion.Text = "evasion";
			this.st_Impact1rb_damageevasion.UseVisualStyleBackColor = true;
			// 
			// st_Impact2Grp
			// 
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_effectonly);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_damagehalf);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_effectdamage);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_damageevasion);
			this.st_Impact2Grp.Location = new System.Drawing.Point(145, 120);
			this.st_Impact2Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2Grp.Name = "st_Impact2Grp";
			this.st_Impact2Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Impact2Grp.Size = new System.Drawing.Size(140, 105);
			this.st_Impact2Grp.TabIndex = 3;
			this.st_Impact2Grp.TabStop = false;
			this.st_Impact2Grp.Text = "0300 0000 damage2";
			// 
			// st_Impact2rb_effectonly
			// 
			this.st_Impact2rb_effectonly.Location = new System.Drawing.Point(5, 15);
			this.st_Impact2rb_effectonly.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_effectonly.Name = "st_Impact2rb_effectonly";
			this.st_Impact2rb_effectonly.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_effectonly.TabIndex = 0;
			this.st_Impact2rb_effectonly.TabStop = true;
			this.st_Impact2rb_effectonly.Text = "none";
			this.st_Impact2rb_effectonly.UseVisualStyleBackColor = true;
			// 
			// st_Impact2rb_damagehalf
			// 
			this.st_Impact2rb_damagehalf.Location = new System.Drawing.Point(5, 35);
			this.st_Impact2rb_damagehalf.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_damagehalf.Name = "st_Impact2rb_damagehalf";
			this.st_Impact2rb_damagehalf.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_damagehalf.TabIndex = 1;
			this.st_Impact2rb_damagehalf.TabStop = true;
			this.st_Impact2rb_damagehalf.Text = "half";
			this.st_Impact2rb_damagehalf.UseVisualStyleBackColor = true;
			// 
			// st_Impact2rb_effectdamage
			// 
			this.st_Impact2rb_effectdamage.Location = new System.Drawing.Point(5, 55);
			this.st_Impact2rb_effectdamage.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_effectdamage.Name = "st_Impact2rb_effectdamage";
			this.st_Impact2rb_effectdamage.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_effectdamage.TabIndex = 2;
			this.st_Impact2rb_effectdamage.TabStop = true;
			this.st_Impact2rb_effectdamage.Text = "regular";
			this.st_Impact2rb_effectdamage.UseVisualStyleBackColor = true;
			// 
			// st_Impact2rb_damageevasion
			// 
			this.st_Impact2rb_damageevasion.Location = new System.Drawing.Point(5, 75);
			this.st_Impact2rb_damageevasion.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_damageevasion.Name = "st_Impact2rb_damageevasion";
			this.st_Impact2rb_damageevasion.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_damageevasion.TabIndex = 3;
			this.st_Impact2rb_damageevasion.TabStop = true;
			this.st_Impact2rb_damageevasion.Text = "evasion";
			this.st_Impact2rb_damageevasion.UseVisualStyleBackColor = true;
			// 
			// st_FlagsGrp
			// 
			this.st_FlagsGrp.Controls.Add(this.st_AffectsFriendlies);
			this.st_FlagsGrp.Controls.Add(this.st_MindAffecting);
			this.st_FlagsGrp.Controls.Add(this.st_SpellResistance);
			this.st_FlagsGrp.Controls.Add(this.st_TouchMelee);
			this.st_FlagsGrp.Controls.Add(this.st_TouchRanged);
			this.st_FlagsGrp.Location = new System.Drawing.Point(295, 15);
			this.st_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_FlagsGrp.Name = "st_FlagsGrp";
			this.st_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_FlagsGrp.Size = new System.Drawing.Size(235, 120);
			this.st_FlagsGrp.TabIndex = 4;
			this.st_FlagsGrp.TabStop = false;
			this.st_FlagsGrp.Text = "FC00 0000 flags";
			// 
			// st_AffectsFriendlies
			// 
			this.st_AffectsFriendlies.Location = new System.Drawing.Point(5, 15);
			this.st_AffectsFriendlies.Margin = new System.Windows.Forms.Padding(0);
			this.st_AffectsFriendlies.Name = "st_AffectsFriendlies";
			this.st_AffectsFriendlies.Size = new System.Drawing.Size(225, 20);
			this.st_AffectsFriendlies.TabIndex = 0;
			this.st_AffectsFriendlies.Text = "affects allies";
			this.st_AffectsFriendlies.UseVisualStyleBackColor = true;
			// 
			// st_MindAffecting
			// 
			this.st_MindAffecting.Location = new System.Drawing.Point(5, 35);
			this.st_MindAffecting.Margin = new System.Windows.Forms.Padding(0);
			this.st_MindAffecting.Name = "st_MindAffecting";
			this.st_MindAffecting.Size = new System.Drawing.Size(225, 20);
			this.st_MindAffecting.TabIndex = 1;
			this.st_MindAffecting.Text = "mind-affecting";
			this.st_MindAffecting.UseVisualStyleBackColor = true;
			// 
			// st_SpellResistance
			// 
			this.st_SpellResistance.Location = new System.Drawing.Point(5, 55);
			this.st_SpellResistance.Margin = new System.Windows.Forms.Padding(0);
			this.st_SpellResistance.Name = "st_SpellResistance";
			this.st_SpellResistance.Size = new System.Drawing.Size(225, 20);
			this.st_SpellResistance.TabIndex = 2;
			this.st_SpellResistance.Text = "spell resistance";
			this.st_SpellResistance.UseVisualStyleBackColor = true;
			// 
			// st_TouchMelee
			// 
			this.st_TouchMelee.Location = new System.Drawing.Point(5, 75);
			this.st_TouchMelee.Margin = new System.Windows.Forms.Padding(0);
			this.st_TouchMelee.Name = "st_TouchMelee";
			this.st_TouchMelee.Size = new System.Drawing.Size(225, 20);
			this.st_TouchMelee.TabIndex = 3;
			this.st_TouchMelee.Text = "melee touch attack";
			this.st_TouchMelee.UseVisualStyleBackColor = true;
			// 
			// st_TouchRanged
			// 
			this.st_TouchRanged.Location = new System.Drawing.Point(5, 95);
			this.st_TouchRanged.Margin = new System.Windows.Forms.Padding(0);
			this.st_TouchRanged.Name = "st_TouchRanged";
			this.st_TouchRanged.Size = new System.Drawing.Size(225, 20);
			this.st_TouchRanged.TabIndex = 4;
			this.st_TouchRanged.Text = "ranged touch attack";
			this.st_TouchRanged.UseVisualStyleBackColor = true;
			// 
			// st_Immunity1Grp
			// 
			this.st_Immunity1Grp.Controls.Add(this.st_co_Immunity1);
			this.st_Immunity1Grp.Location = new System.Drawing.Point(295, 135);
			this.st_Immunity1Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Immunity1Grp.Name = "st_Immunity1Grp";
			this.st_Immunity1Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Immunity1Grp.Size = new System.Drawing.Size(235, 45);
			this.st_Immunity1Grp.TabIndex = 5;
			this.st_Immunity1Grp.TabStop = false;
			this.st_Immunity1Grp.Text = "0000 0FC0 immunity1";
			// 
			// st_co_Immunity1
			// 
			this.st_co_Immunity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.st_co_Immunity1.FormattingEnabled = true;
			this.st_co_Immunity1.Location = new System.Drawing.Point(5, 15);
			this.st_co_Immunity1.Margin = new System.Windows.Forms.Padding(0);
			this.st_co_Immunity1.Name = "st_co_Immunity1";
			this.st_co_Immunity1.Size = new System.Drawing.Size(225, 21);
			this.st_co_Immunity1.TabIndex = 0;
			// 
			// st_Immunity2Grp
			// 
			this.st_Immunity2Grp.Controls.Add(this.st_co_Immunity2);
			this.st_Immunity2Grp.Location = new System.Drawing.Point(295, 180);
			this.st_Immunity2Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Immunity2Grp.Name = "st_Immunity2Grp";
			this.st_Immunity2Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Immunity2Grp.Size = new System.Drawing.Size(235, 45);
			this.st_Immunity2Grp.TabIndex = 6;
			this.st_Immunity2Grp.TabStop = false;
			this.st_Immunity2Grp.Text = "0003 F000 immunity2";
			// 
			// st_co_Immunity2
			// 
			this.st_co_Immunity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.st_co_Immunity2.FormattingEnabled = true;
			this.st_co_Immunity2.Location = new System.Drawing.Point(5, 15);
			this.st_co_Immunity2.Margin = new System.Windows.Forms.Padding(0);
			this.st_co_Immunity2.Name = "st_co_Immunity2";
			this.st_co_Immunity2.Size = new System.Drawing.Size(225, 21);
			this.st_co_Immunity2.TabIndex = 0;
			// 
			// st_SpecificGrp
			// 
			this.st_SpecificGrp.Controls.Add(this.st_co_Specific);
			this.st_SpecificGrp.Location = new System.Drawing.Point(5, 225);
			this.st_SpecificGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_SpecificGrp.Name = "st_SpecificGrp";
			this.st_SpecificGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_SpecificGrp.Size = new System.Drawing.Size(475, 45);
			this.st_SpecificGrp.TabIndex = 7;
			this.st_SpecificGrp.TabStop = false;
			this.st_SpecificGrp.Text = "0000 003F specific";
			// 
			// st_co_Specific
			// 
			this.st_co_Specific.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.st_co_Specific.FormattingEnabled = true;
			this.st_co_Specific.Location = new System.Drawing.Point(5, 15);
			this.st_co_Specific.Margin = new System.Windows.Forms.Padding(0);
			this.st_co_Specific.Name = "st_co_Specific";
			this.st_co_Specific.Size = new System.Drawing.Size(465, 21);
			this.st_co_Specific.TabIndex = 0;
			// 
			// st_ExclusiveGrp
			// 
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_DamagetypesGrp);
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_WeightGrp);
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_FlagsGrp);
			this.st_ExclusiveGrp.Location = new System.Drawing.Point(540, 60);
			this.st_ExclusiveGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_ExclusiveGrp.Name = "st_ExclusiveGrp";
			this.st_ExclusiveGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_ExclusiveGrp.Size = new System.Drawing.Size(270, 280);
			this.st_ExclusiveGrp.TabIndex = 8;
			this.st_ExclusiveGrp.TabStop = false;
			this.st_ExclusiveGrp.Text = "buff - energy resistance/immunity";
			// 
			// st_Excl_DamagetypesGrp
			// 
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Magical);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Divine);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Acid);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Cold);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Electrical);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Fire);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Sonic);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Negative);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Positive);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Bludgeoning);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Piercing);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Slashing);
			this.st_Excl_DamagetypesGrp.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_DamagetypesGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_DamagetypesGrp.Name = "st_Excl_DamagetypesGrp";
			this.st_Excl_DamagetypesGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_DamagetypesGrp.Size = new System.Drawing.Size(130, 260);
			this.st_Excl_DamagetypesGrp.TabIndex = 0;
			this.st_Excl_DamagetypesGrp.TabStop = false;
			this.st_Excl_DamagetypesGrp.Text = "0000 0FFF type";
			// 
			// st_Excl_Magical
			// 
			this.st_Excl_Magical.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_Magical.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Magical.Name = "st_Excl_Magical";
			this.st_Excl_Magical.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Magical.TabIndex = 0;
			this.st_Excl_Magical.Text = "magical";
			this.st_Excl_Magical.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Divine
			// 
			this.st_Excl_Divine.Location = new System.Drawing.Point(5, 35);
			this.st_Excl_Divine.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Divine.Name = "st_Excl_Divine";
			this.st_Excl_Divine.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Divine.TabIndex = 1;
			this.st_Excl_Divine.Text = "divine";
			this.st_Excl_Divine.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Acid
			// 
			this.st_Excl_Acid.Location = new System.Drawing.Point(5, 55);
			this.st_Excl_Acid.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Acid.Name = "st_Excl_Acid";
			this.st_Excl_Acid.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Acid.TabIndex = 2;
			this.st_Excl_Acid.Text = "acid";
			this.st_Excl_Acid.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Cold
			// 
			this.st_Excl_Cold.Location = new System.Drawing.Point(5, 75);
			this.st_Excl_Cold.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Cold.Name = "st_Excl_Cold";
			this.st_Excl_Cold.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Cold.TabIndex = 3;
			this.st_Excl_Cold.Text = "cold";
			this.st_Excl_Cold.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Electrical
			// 
			this.st_Excl_Electrical.Location = new System.Drawing.Point(5, 95);
			this.st_Excl_Electrical.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Electrical.Name = "st_Excl_Electrical";
			this.st_Excl_Electrical.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Electrical.TabIndex = 4;
			this.st_Excl_Electrical.Text = "electrical";
			this.st_Excl_Electrical.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Fire
			// 
			this.st_Excl_Fire.Location = new System.Drawing.Point(5, 115);
			this.st_Excl_Fire.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Fire.Name = "st_Excl_Fire";
			this.st_Excl_Fire.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Fire.TabIndex = 5;
			this.st_Excl_Fire.Text = "fire";
			this.st_Excl_Fire.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Sonic
			// 
			this.st_Excl_Sonic.Location = new System.Drawing.Point(5, 135);
			this.st_Excl_Sonic.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Sonic.Name = "st_Excl_Sonic";
			this.st_Excl_Sonic.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Sonic.TabIndex = 6;
			this.st_Excl_Sonic.Text = "sonic";
			this.st_Excl_Sonic.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Negative
			// 
			this.st_Excl_Negative.Location = new System.Drawing.Point(5, 155);
			this.st_Excl_Negative.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Negative.Name = "st_Excl_Negative";
			this.st_Excl_Negative.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Negative.TabIndex = 7;
			this.st_Excl_Negative.Text = "negative";
			this.st_Excl_Negative.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Positive
			// 
			this.st_Excl_Positive.Location = new System.Drawing.Point(5, 175);
			this.st_Excl_Positive.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Positive.Name = "st_Excl_Positive";
			this.st_Excl_Positive.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Positive.TabIndex = 8;
			this.st_Excl_Positive.Text = "positive";
			this.st_Excl_Positive.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Bludgeoning
			// 
			this.st_Excl_Bludgeoning.Location = new System.Drawing.Point(5, 195);
			this.st_Excl_Bludgeoning.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Bludgeoning.Name = "st_Excl_Bludgeoning";
			this.st_Excl_Bludgeoning.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Bludgeoning.TabIndex = 9;
			this.st_Excl_Bludgeoning.Text = "bludgeoning";
			this.st_Excl_Bludgeoning.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Piercing
			// 
			this.st_Excl_Piercing.Location = new System.Drawing.Point(5, 215);
			this.st_Excl_Piercing.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Piercing.Name = "st_Excl_Piercing";
			this.st_Excl_Piercing.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Piercing.TabIndex = 10;
			this.st_Excl_Piercing.Text = "piercing";
			this.st_Excl_Piercing.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Slashing
			// 
			this.st_Excl_Slashing.Location = new System.Drawing.Point(5, 235);
			this.st_Excl_Slashing.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Slashing.Name = "st_Excl_Slashing";
			this.st_Excl_Slashing.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Slashing.TabIndex = 11;
			this.st_Excl_Slashing.Text = "slashing";
			this.st_Excl_Slashing.UseVisualStyleBackColor = true;
			// 
			// st_Excl_WeightGrp
			// 
			this.st_Excl_WeightGrp.Controls.Add(this.st_Excl_Weight);
			this.st_Excl_WeightGrp.Location = new System.Drawing.Point(135, 15);
			this.st_Excl_WeightGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_WeightGrp.Name = "st_Excl_WeightGrp";
			this.st_Excl_WeightGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_WeightGrp.Size = new System.Drawing.Size(130, 40);
			this.st_Excl_WeightGrp.TabIndex = 1;
			this.st_Excl_WeightGrp.TabStop = false;
			this.st_Excl_WeightGrp.Text = "000F F000 power";
			// 
			// st_Excl_Weight
			// 
			this.st_Excl_Weight.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_Weight.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Weight.Name = "st_Excl_Weight";
			this.st_Excl_Weight.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_Weight.TabIndex = 0;
			// 
			// st_Excl_FlagsGrp
			// 
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_rbResistance);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_rbImmunity);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_Onlyone);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_General);
			this.st_Excl_FlagsGrp.Location = new System.Drawing.Point(135, 55);
			this.st_Excl_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_FlagsGrp.Name = "st_Excl_FlagsGrp";
			this.st_Excl_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_FlagsGrp.Size = new System.Drawing.Size(130, 100);
			this.st_Excl_FlagsGrp.TabIndex = 2;
			this.st_Excl_FlagsGrp.TabStop = false;
			this.st_Excl_FlagsGrp.Text = "0070 0000 flags";
			// 
			// st_Excl_rbResistance
			// 
			this.st_Excl_rbResistance.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_rbResistance.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_rbResistance.Name = "st_Excl_rbResistance";
			this.st_Excl_rbResistance.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_rbResistance.TabIndex = 0;
			this.st_Excl_rbResistance.TabStop = true;
			this.st_Excl_rbResistance.Text = "is Resistance";
			this.st_Excl_rbResistance.UseVisualStyleBackColor = true;
			// 
			// st_Excl_rbImmunity
			// 
			this.st_Excl_rbImmunity.Location = new System.Drawing.Point(5, 35);
			this.st_Excl_rbImmunity.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_rbImmunity.Name = "st_Excl_rbImmunity";
			this.st_Excl_rbImmunity.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_rbImmunity.TabIndex = 1;
			this.st_Excl_rbImmunity.TabStop = true;
			this.st_Excl_rbImmunity.Text = "is Immunity";
			this.st_Excl_rbImmunity.UseVisualStyleBackColor = true;
			// 
			// st_Excl_Onlyone
			// 
			this.st_Excl_Onlyone.Location = new System.Drawing.Point(5, 55);
			this.st_Excl_Onlyone.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Onlyone.Name = "st_Excl_Onlyone";
			this.st_Excl_Onlyone.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_Onlyone.TabIndex = 2;
			this.st_Excl_Onlyone.Text = "only one type";
			this.st_Excl_Onlyone.UseVisualStyleBackColor = true;
			// 
			// st_Excl_General
			// 
			this.st_Excl_General.Location = new System.Drawing.Point(5, 75);
			this.st_Excl_General.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_General.Name = "st_Excl_General";
			this.st_Excl_General.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_General.TabIndex = 3;
			this.st_Excl_General.Text = "general";
			this.st_Excl_General.UseVisualStyleBackColor = true;
			// 
			// st_TargetRestrictionGrp
			// 
			this.st_TargetRestrictionGrp.Controls.Add(this.st_co_TargetRestriction);
			this.st_TargetRestrictionGrp.Location = new System.Drawing.Point(5, 360);
			this.st_TargetRestrictionGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_TargetRestrictionGrp.Name = "st_TargetRestrictionGrp";
			this.st_TargetRestrictionGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_TargetRestrictionGrp.Size = new System.Drawing.Size(520, 45);
			this.st_TargetRestrictionGrp.TabIndex = 10;
			this.st_TargetRestrictionGrp.TabStop = false;
			this.st_TargetRestrictionGrp.Text = "0000 101F targetrestriction";
			// 
			// st_co_TargetRestriction
			// 
			this.st_co_TargetRestriction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.st_co_TargetRestriction.DropDownWidth = 510;
			this.st_co_TargetRestriction.FormattingEnabled = true;
			this.st_co_TargetRestriction.Location = new System.Drawing.Point(5, 15);
			this.st_co_TargetRestriction.Margin = new System.Windows.Forms.Padding(0);
			this.st_co_TargetRestriction.Name = "st_co_TargetRestriction";
			this.st_co_TargetRestriction.Size = new System.Drawing.Size(510, 21);
			this.st_co_TargetRestriction.TabIndex = 0;
			// 
			// st_NotCaster
			// 
			this.st_NotCaster.Location = new System.Drawing.Point(10, 340);
			this.st_NotCaster.Margin = new System.Windows.Forms.Padding(0);
			this.st_NotCaster.Name = "st_NotCaster";
			this.st_NotCaster.Size = new System.Drawing.Size(225, 20);
			this.st_NotCaster.TabIndex = 9;
			this.st_NotCaster.Text = "does not affect caster";
			this.st_NotCaster.UseVisualStyleBackColor = true;
			// 
			// st_AcBonusGrp
			// 
			this.st_AcBonusGrp.Controls.Add(this.st_co_AcBonus);
			this.st_AcBonusGrp.Location = new System.Drawing.Point(525, 360);
			this.st_AcBonusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_AcBonusGrp.Name = "st_AcBonusGrp";
			this.st_AcBonusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_AcBonusGrp.Size = new System.Drawing.Size(195, 45);
			this.st_AcBonusGrp.TabIndex = 11;
			this.st_AcBonusGrp.TabStop = false;
			this.st_AcBonusGrp.Text = "001C 0000 ac";
			// 
			// st_co_AcBonus
			// 
			this.st_co_AcBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.st_co_AcBonus.FormattingEnabled = true;
			this.st_co_AcBonus.Location = new System.Drawing.Point(5, 15);
			this.st_co_AcBonus.Margin = new System.Windows.Forms.Padding(0);
			this.st_co_AcBonus.Name = "st_co_AcBonus";
			this.st_co_AcBonus.Size = new System.Drawing.Size(185, 21);
			this.st_co_AcBonus.TabIndex = 0;
			// 
			// tp_SaveDCType
			// 
			this.tp_SaveDCType.BackColor = System.Drawing.Color.OldLace;
			this.tp_SaveDCType.Controls.Add(this.SaveDCType_reset);
			this.tp_SaveDCType.Controls.Add(this.SaveDCType_text);
			this.tp_SaveDCType.Controls.Add(this.SaveDCType_hex);
			this.tp_SaveDCType.Controls.Add(this.SaveDCType_bin);
			this.tp_SaveDCType.Controls.Add(this.dc_Clear);
			this.tp_SaveDCType.Controls.Add(this.dc_hex);
			this.tp_SaveDCType.Controls.Add(this.dc_bin);
			this.tp_SaveDCType.Controls.Add(this.dc_SaveDCGrp);
			this.tp_SaveDCType.Controls.Add(this.dc_WeaponBonusGrp);
			this.tp_SaveDCType.Controls.Add(this.dc_ArmorCheckGrp);
			this.tp_SaveDCType.Controls.Add(this.savedctype_label);
			this.tp_SaveDCType.Location = new System.Drawing.Point(4, 22);
			this.tp_SaveDCType.Margin = new System.Windows.Forms.Padding(0);
			this.tp_SaveDCType.Name = "tp_SaveDCType";
			this.tp_SaveDCType.Size = new System.Drawing.Size(815, 423);
			this.tp_SaveDCType.TabIndex = 6;
			this.tp_SaveDCType.Text = "SaveDCType";
			// 
			// SaveDCType_reset
			// 
			this.SaveDCType_reset.Location = new System.Drawing.Point(5, 5);
			this.SaveDCType_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_reset.Name = "SaveDCType_reset";
			this.SaveDCType_reset.Size = new System.Drawing.Size(100, 25);
			this.SaveDCType_reset.TabIndex = 0;
			this.SaveDCType_reset.UseVisualStyleBackColor = true;
			// 
			// SaveDCType_text
			// 
			this.SaveDCType_text.Location = new System.Drawing.Point(5, 35);
			this.SaveDCType_text.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_text.Name = "SaveDCType_text";
			this.SaveDCType_text.Size = new System.Drawing.Size(100, 20);
			this.SaveDCType_text.TabIndex = 1;
			this.SaveDCType_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SaveDCType_hex
			// 
			this.SaveDCType_hex.BackColor = System.Drawing.SystemColors.Window;
			this.SaveDCType_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SaveDCType_hex.Location = new System.Drawing.Point(115, 15);
			this.SaveDCType_hex.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_hex.Name = "SaveDCType_hex";
			this.SaveDCType_hex.ReadOnly = true;
			this.SaveDCType_hex.Size = new System.Drawing.Size(275, 13);
			this.SaveDCType_hex.TabIndex = 2;
			// 
			// SaveDCType_bin
			// 
			this.SaveDCType_bin.BackColor = System.Drawing.SystemColors.Window;
			this.SaveDCType_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.SaveDCType_bin.Location = new System.Drawing.Point(115, 35);
			this.SaveDCType_bin.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_bin.Name = "SaveDCType_bin";
			this.SaveDCType_bin.ReadOnly = true;
			this.SaveDCType_bin.Size = new System.Drawing.Size(275, 13);
			this.SaveDCType_bin.TabIndex = 3;
			// 
			// dc_Clear
			// 
			this.dc_Clear.Location = new System.Drawing.Point(450, 5);
			this.dc_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.dc_Clear.Name = "dc_Clear";
			this.dc_Clear.Size = new System.Drawing.Size(65, 50);
			this.dc_Clear.TabIndex = 4;
			this.dc_Clear.Text = "zero\r\nall\r\nbits";
			this.dc_Clear.UseVisualStyleBackColor = true;
			// 
			// dc_hex
			// 
			this.dc_hex.Location = new System.Drawing.Point(400, 15);
			this.dc_hex.Margin = new System.Windows.Forms.Padding(0);
			this.dc_hex.Name = "dc_hex";
			this.dc_hex.Size = new System.Drawing.Size(40, 15);
			this.dc_hex.TabIndex = 5;
			this.dc_hex.Text = "hex";
			this.dc_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dc_bin
			// 
			this.dc_bin.Location = new System.Drawing.Point(400, 35);
			this.dc_bin.Margin = new System.Windows.Forms.Padding(0);
			this.dc_bin.Name = "dc_bin";
			this.dc_bin.Size = new System.Drawing.Size(40, 15);
			this.dc_bin.TabIndex = 6;
			this.dc_bin.Text = "bin";
			this.dc_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dc_SaveDCGrp
			// 
			this.dc_SaveDCGrp.Controls.Add(this.dc_co_SaveDC);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_up);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_dn);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_adjustor_info);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_info);
			this.dc_SaveDCGrp.Location = new System.Drawing.Point(5, 60);
			this.dc_SaveDCGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_SaveDCGrp.Name = "dc_SaveDCGrp";
			this.dc_SaveDCGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_SaveDCGrp.Size = new System.Drawing.Size(340, 315);
			this.dc_SaveDCGrp.TabIndex = 7;
			this.dc_SaveDCGrp.TabStop = false;
			this.dc_SaveDCGrp.Text = "FFFF FFFF savedc";
			// 
			// dc_co_SaveDC
			// 
			this.dc_co_SaveDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dc_co_SaveDC.FormattingEnabled = true;
			this.dc_co_SaveDC.Location = new System.Drawing.Point(5, 15);
			this.dc_co_SaveDC.Margin = new System.Windows.Forms.Padding(0);
			this.dc_co_SaveDC.Name = "dc_co_SaveDC";
			this.dc_co_SaveDC.Size = new System.Drawing.Size(330, 21);
			this.dc_co_SaveDC.TabIndex = 0;
			// 
			// savedc_up
			// 
			this.savedc_up.Enabled = false;
			this.savedc_up.Location = new System.Drawing.Point(5, 45);
			this.savedc_up.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_up.Name = "savedc_up";
			this.savedc_up.Size = new System.Drawing.Size(30, 25);
			this.savedc_up.TabIndex = 1;
			this.savedc_up.Text = "+";
			this.savedc_up.UseVisualStyleBackColor = true;
			// 
			// savedc_dn
			// 
			this.savedc_dn.Enabled = false;
			this.savedc_dn.Location = new System.Drawing.Point(5, 75);
			this.savedc_dn.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_dn.Name = "savedc_dn";
			this.savedc_dn.Size = new System.Drawing.Size(30, 25);
			this.savedc_dn.TabIndex = 2;
			this.savedc_dn.Text = "-";
			this.savedc_dn.UseVisualStyleBackColor = true;
			// 
			// savedc_adjustor_info
			// 
			this.savedc_adjustor_info.Location = new System.Drawing.Point(40, 45);
			this.savedc_adjustor_info.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_adjustor_info.Name = "savedc_adjustor_info";
			this.savedc_adjustor_info.Size = new System.Drawing.Size(295, 130);
			this.savedc_adjustor_info.TabIndex = 3;
			this.savedc_adjustor_info.Text = "savedc_adjustor_info";
			// 
			// savedc_info
			// 
			this.savedc_info.Location = new System.Drawing.Point(5, 180);
			this.savedc_info.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_info.Name = "savedc_info";
			this.savedc_info.Size = new System.Drawing.Size(330, 130);
			this.savedc_info.TabIndex = 4;
			this.savedc_info.Text = "savedc_info";
			// 
			// dc_WeaponBonusGrp
			// 
			this.dc_WeaponBonusGrp.Controls.Add(this.dc_co_WeaponBonus);
			this.dc_WeaponBonusGrp.Location = new System.Drawing.Point(345, 60);
			this.dc_WeaponBonusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_WeaponBonusGrp.Name = "dc_WeaponBonusGrp";
			this.dc_WeaponBonusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_WeaponBonusGrp.Size = new System.Drawing.Size(315, 45);
			this.dc_WeaponBonusGrp.TabIndex = 8;
			this.dc_WeaponBonusGrp.TabStop = false;
			this.dc_WeaponBonusGrp.Text = "0000 0067 weaponbonus";
			// 
			// dc_co_WeaponBonus
			// 
			this.dc_co_WeaponBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dc_co_WeaponBonus.FormattingEnabled = true;
			this.dc_co_WeaponBonus.Location = new System.Drawing.Point(5, 15);
			this.dc_co_WeaponBonus.Margin = new System.Windows.Forms.Padding(0);
			this.dc_co_WeaponBonus.Name = "dc_co_WeaponBonus";
			this.dc_co_WeaponBonus.Size = new System.Drawing.Size(305, 21);
			this.dc_co_WeaponBonus.TabIndex = 0;
			// 
			// dc_ArmorCheckGrp
			// 
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac1);
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac2);
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac3);
			this.dc_ArmorCheckGrp.Controls.Add(this.armorcheck_info);
			this.dc_ArmorCheckGrp.Location = new System.Drawing.Point(345, 105);
			this.dc_ArmorCheckGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_ArmorCheckGrp.Name = "dc_ArmorCheckGrp";
			this.dc_ArmorCheckGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_ArmorCheckGrp.Size = new System.Drawing.Size(315, 270);
			this.dc_ArmorCheckGrp.TabIndex = 9;
			this.dc_ArmorCheckGrp.TabStop = false;
			this.dc_ArmorCheckGrp.Text = "1000 0003 armorcheck";
			// 
			// savedc_ac1
			// 
			this.savedc_ac1.Location = new System.Drawing.Point(10, 15);
			this.savedc_ac1.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac1.Name = "savedc_ac1";
			this.savedc_ac1.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac1.TabIndex = 0;
			this.savedc_ac1.Text = "target must be wearing armor";
			this.savedc_ac1.UseVisualStyleBackColor = true;
			// 
			// savedc_ac2
			// 
			this.savedc_ac2.Location = new System.Drawing.Point(10, 35);
			this.savedc_ac2.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac2.Name = "savedc_ac2";
			this.savedc_ac2.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac2.TabIndex = 1;
			this.savedc_ac2.Text = "target must be using a shield";
			this.savedc_ac2.UseVisualStyleBackColor = true;
			// 
			// savedc_ac3
			// 
			this.savedc_ac3.Location = new System.Drawing.Point(10, 55);
			this.savedc_ac3.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac3.Name = "savedc_ac3";
			this.savedc_ac3.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac3.TabIndex = 2;
			this.savedc_ac3.Text = "target must be immune to speed decrease";
			this.savedc_ac3.UseVisualStyleBackColor = true;
			// 
			// armorcheck_info
			// 
			this.armorcheck_info.Location = new System.Drawing.Point(5, 85);
			this.armorcheck_info.Margin = new System.Windows.Forms.Padding(0);
			this.armorcheck_info.Name = "armorcheck_info";
			this.armorcheck_info.Size = new System.Drawing.Size(305, 140);
			this.armorcheck_info.TabIndex = 3;
			this.armorcheck_info.Text = "armorcheck_info";
			// 
			// savedctype_label
			// 
			this.savedctype_label.Location = new System.Drawing.Point(5, 380);
			this.savedctype_label.Margin = new System.Windows.Forms.Padding(0);
			this.savedctype_label.Name = "savedctype_label";
			this.savedctype_label.Size = new System.Drawing.Size(655, 45);
			this.savedctype_label.TabIndex = 10;
			// 
			// tabcontrol_Spells
			// 
			this.Controls.Add(this.tc_Spells);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "tabcontrol_Spells";
			this.Size = new System.Drawing.Size(823, 449);
			this.tc_Spells.ResumeLayout(false);
			this.tp_SpellInfo.ResumeLayout(false);
			this.tp_SpellInfo.PerformLayout();
			this.si_SpelltypeGrp.ResumeLayout(false);
			this.si_FlagsGrp.ResumeLayout(false);
			this.si_SpelllevelGrp.ResumeLayout(false);
			this.si_SubspellsGrp.ResumeLayout(false);
			this.si_SubspellsGrp.PerformLayout();
			this.tp_TargetInfo.ResumeLayout(false);
			this.tp_TargetInfo.PerformLayout();
			this.ti_FlagsGrp.ResumeLayout(false);
			this.ti_ShapeGrp.ResumeLayout(false);
			this.ti_RangeGrp.ResumeLayout(false);
			this.ti_RadiusGrp.ResumeLayout(false);
			this.ti_RadiusGrp.PerformLayout();
			this.tp_EffectWeight.ResumeLayout(false);
			this.tp_EffectWeight.PerformLayout();
			this.tp_EffectTypes.ResumeLayout(false);
			this.tp_EffectTypes.PerformLayout();
			this.et_DetEffectsGrp.ResumeLayout(false);
			this.et_BenEffectsGrp.ResumeLayout(false);
			this.tp_DamageInfo.ResumeLayout(false);
			this.tp_DamageInfo.PerformLayout();
			this.di_DetrimentalGrp.ResumeLayout(false);
			this.di_DetDamagebaseGrp.ResumeLayout(false);
			this.di_DetDamageGrp.ResumeLayout(false);
			this.di_DetDamageGrp.PerformLayout();
			this.di_DetLeveltypeGrp.ResumeLayout(false);
			this.di_DetLevellimitGrp.ResumeLayout(false);
			this.di_DetLevellimitGrp.PerformLayout();
			this.di_DetLeveldivisorGrp.ResumeLayout(false);
			this.di_DetLeveldivisorGrp.PerformLayout();
			this.di_DetFixedCountGrp.ResumeLayout(false);
			this.di_DetFixedCountGrp.PerformLayout();
			this.di_DetDamagetypeGrp.ResumeLayout(false);
			this.di_BeneficialGrp.ResumeLayout(false);
			this.di_BenPowerbaseGrp.ResumeLayout(false);
			this.di_BenPowerGrp.ResumeLayout(false);
			this.di_BenPowerGrp.PerformLayout();
			this.di_BenLeveltypeGrp.ResumeLayout(false);
			this.di_BenLevellimitGrp.ResumeLayout(false);
			this.di_BenLevellimitGrp.PerformLayout();
			this.di_BenLeveldivisorGrp.ResumeLayout(false);
			this.di_BenLeveldivisorGrp.PerformLayout();
			this.di_BenLeveldecreaseGrp.ResumeLayout(false);
			this.di_BenLeveldecreaseGrp.PerformLayout();
			this.di_DispelTypesGrp.ResumeLayout(false);
			this.tp_SaveType.ResumeLayout(false);
			this.tp_SaveType.PerformLayout();
			this.st_DetrimentalGrp.ResumeLayout(false);
			this.st_Save1Grp.ResumeLayout(false);
			this.st_Save2Grp.ResumeLayout(false);
			this.st_Impact1Grp.ResumeLayout(false);
			this.st_Impact2Grp.ResumeLayout(false);
			this.st_FlagsGrp.ResumeLayout(false);
			this.st_Immunity1Grp.ResumeLayout(false);
			this.st_Immunity2Grp.ResumeLayout(false);
			this.st_SpecificGrp.ResumeLayout(false);
			this.st_ExclusiveGrp.ResumeLayout(false);
			this.st_Excl_DamagetypesGrp.ResumeLayout(false);
			this.st_Excl_WeightGrp.ResumeLayout(false);
			this.st_Excl_WeightGrp.PerformLayout();
			this.st_Excl_FlagsGrp.ResumeLayout(false);
			this.st_TargetRestrictionGrp.ResumeLayout(false);
			this.st_AcBonusGrp.ResumeLayout(false);
			this.tp_SaveDCType.ResumeLayout(false);
			this.tp_SaveDCType.PerformLayout();
			this.dc_SaveDCGrp.ResumeLayout(false);
			this.dc_WeaponBonusGrp.ResumeLayout(false);
			this.dc_ArmorCheckGrp.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
