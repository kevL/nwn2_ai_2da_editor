namespace nwn2_ai_2da_editor
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl cols_HenchSpells;
		private System.Windows.Forms.TabPage page_SpellInfo;
		private System.Windows.Forms.TabPage page_TargetInfo;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem file;
		private System.Windows.Forms.ToolStripMenuItem Quit;
		private System.Windows.Forms.TabPage page_EffectWeight;
		private System.Windows.Forms.TabPage page_EffectTypes;
		private System.Windows.Forms.TabPage page_DamageInfo;
		private System.Windows.Forms.TabPage page_SaveType;
		private System.Windows.Forms.TabPage page_SaveDCType;
		private System.Windows.Forms.TreeView Tree;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem Open;
		private System.Windows.Forms.TextBox EffectWeight_text;
		private System.Windows.Forms.Button SpellInfo_reset;
		private System.Windows.Forms.Button TargetInfo_reset;
		private System.Windows.Forms.Button EffectWeight_reset;
		private System.Windows.Forms.Button EffectTypes_reset;
		private System.Windows.Forms.Button DamageInfo_reset;
		private System.Windows.Forms.Button SaveType_reset;
		private System.Windows.Forms.Button SaveDCType_reset;
		private System.Windows.Forms.Label f2;
		private System.Windows.Forms.Label f1;
		private System.Windows.Forms.Button apply;
		private System.Windows.Forms.Label savedctype_label;
		private System.Windows.Forms.GroupBox dc_WeaponBonusGrp;
		private System.Windows.Forms.GroupBox dc_SaveDCGrp;
		private System.Windows.Forms.ComboBox cbo_dc_SaveDC;
		private System.Windows.Forms.TextBox SaveDCType_text;
		private System.Windows.Forms.Button savedc_dn;
		private System.Windows.Forms.Button savedc_up;
		private System.Windows.Forms.Label savedc_adjustor_info;
		private System.Windows.Forms.Label savedc_info;
		private System.Windows.Forms.ComboBox cbo_dc_WeaponBonus;
		private System.Windows.Forms.TextBox SaveType_text;
		private System.Windows.Forms.CheckBox savedc_ac3;
		private System.Windows.Forms.CheckBox savedc_ac2;
		private System.Windows.Forms.CheckBox savedc_ac1;
		private System.Windows.Forms.GroupBox dc_ArmorCheckGrp;
		private System.Windows.Forms.Label armorcheck_info;
		private System.Windows.Forms.GroupBox st_SpecificGrp;
		private System.Windows.Forms.GroupBox st_FlagsGrp;
		private System.Windows.Forms.CheckBox st_SpellResistance;
		private System.Windows.Forms.CheckBox st_MindAffecting;
		private System.Windows.Forms.CheckBox st_AffectsFriendlies;
		private System.Windows.Forms.CheckBox st_TouchRanged;
		private System.Windows.Forms.CheckBox st_NotCaster;
		private System.Windows.Forms.CheckBox st_TouchMelee;
		private System.Windows.Forms.GroupBox st_Save2Grp;
		private System.Windows.Forms.GroupBox st_Save1Grp;
		private System.Windows.Forms.GroupBox st_Impact2Grp;
		private System.Windows.Forms.GroupBox st_Impact1Grp;
		private System.Windows.Forms.RadioButton st_Save1rb_none;
		private System.Windows.Forms.RadioButton st_Save2rb_will;
		private System.Windows.Forms.RadioButton st_Save2rb_refl;
		private System.Windows.Forms.RadioButton st_Save2rb_fort;
		private System.Windows.Forms.RadioButton st_Save2rb_none;
		private System.Windows.Forms.RadioButton st_Save1rb_will;
		private System.Windows.Forms.RadioButton st_Save1rb_refl;
		private System.Windows.Forms.RadioButton st_Save1rb_fort;
		private System.Windows.Forms.RadioButton st_Impact1rb_damagehalf;
		private System.Windows.Forms.RadioButton st_Impact1rb_effectonly;
		private System.Windows.Forms.RadioButton st_Impact1rb_damageevasion;
		private System.Windows.Forms.RadioButton st_Impact1rb_effectdamage;
		private System.Windows.Forms.RadioButton st_Impact2rb_damageevasion;
		private System.Windows.Forms.RadioButton st_Impact2rb_effectdamage;
		private System.Windows.Forms.RadioButton st_Impact2rb_damagehalf;
		private System.Windows.Forms.RadioButton st_Impact2rb_effectonly;
		private System.Windows.Forms.ComboBox cbo_st_Specific;
		private System.Windows.Forms.GroupBox st_Immunity1Grp;
		private System.Windows.Forms.ComboBox cbo_st_Immunity1;
		private System.Windows.Forms.GroupBox st_AcBonusGrp;
		private System.Windows.Forms.ComboBox cbo_st_AcBonus;
		private System.Windows.Forms.GroupBox st_TargetRestrictionGrp;
		private System.Windows.Forms.ComboBox cbo_st_TargetRestriction;
		private System.Windows.Forms.GroupBox st_Immunity2Grp;
		private System.Windows.Forms.ComboBox cbo_st_Immunity2;
		private System.Windows.Forms.ToolStripMenuItem edit;
		private System.Windows.Forms.ToolStripMenuItem Copy_decimal;
		private System.Windows.Forms.ToolStripMenuItem Copy_hexadecimal;
		private System.Windows.Forms.ToolStripMenuItem Copy_binary;
		private System.Windows.Forms.TextBox SaveType_bin;
		private System.Windows.Forms.TextBox SaveType_hex;
		private System.Windows.Forms.TextBox SaveDCType_bin;
		private System.Windows.Forms.TextBox SaveDCType_hex;
		private System.Windows.Forms.Button st_Clear;
		private System.Windows.Forms.Label st_bin;
		private System.Windows.Forms.Label st_hex;
		private System.Windows.Forms.Label dc_bin;
		private System.Windows.Forms.Label dc_hex;
		private System.Windows.Forms.Button dc_Clear;
		private System.Windows.Forms.Label si_bin;
		private System.Windows.Forms.Label si_hex;
		private System.Windows.Forms.Button si_Clear;
		private System.Windows.Forms.TextBox SpellInfo_bin;
		private System.Windows.Forms.TextBox SpellInfo_hex;
		private System.Windows.Forms.TextBox SpellInfo_text;
		private System.Windows.Forms.Label ti_bin;
		private System.Windows.Forms.Label ti_hex;
		private System.Windows.Forms.Button ti_Clear;
		private System.Windows.Forms.TextBox TargetInfo_bin;
		private System.Windows.Forms.TextBox TargetInfo_hex;
		private System.Windows.Forms.TextBox TargetInfo_text;
		private System.Windows.Forms.Button ew_Clear;
		private System.Windows.Forms.Label et_bin;
		private System.Windows.Forms.Label et_hex;
		private System.Windows.Forms.Button et_Clear;
		private System.Windows.Forms.TextBox EffectTypes_bin;
		private System.Windows.Forms.TextBox EffectTypes_hex;
		private System.Windows.Forms.TextBox EffectTypes_text;
		private System.Windows.Forms.Label di_bin;
		private System.Windows.Forms.Label di_hex;
		private System.Windows.Forms.Button di_Clear;
		private System.Windows.Forms.TextBox DamageInfo_bin;
		private System.Windows.Forms.TextBox DamageInfo_hex;
		private System.Windows.Forms.TextBox DamageInfo_text;
		private System.Windows.Forms.GroupBox si_SpelltypeGrp;
		private System.Windows.Forms.ComboBox cbo_si_Spelltype;
		private System.Windows.Forms.CheckBox si_LongDurBuff;
		private System.Windows.Forms.CheckBox si_MediumDurBuff;
		private System.Windows.Forms.CheckBox si_ShortDurBuff;
		private System.Windows.Forms.CheckBox si_HealOrCure;
		private System.Windows.Forms.CheckBox si_Unlimited;
		private System.Windows.Forms.CheckBox si_Concentration;
		private System.Windows.Forms.CheckBox si_Ignore;
		private System.Windows.Forms.CheckBox si_IsMaster;
		private System.Windows.Forms.GroupBox si_SpelllevelGrp;
		private System.Windows.Forms.ComboBox cbo_si_Spelllevel;
		private System.Windows.Forms.CheckBox si_ItemCast;
		private System.Windows.Forms.GroupBox si_FlagsGrp;
		private System.Windows.Forms.GroupBox et_BenEffectsGrp;
		private System.Windows.Forms.CheckBox et_AcIncrease;
		private System.Windows.Forms.CheckBox et_Regenerate;
		private System.Windows.Forms.CheckBox et_ImmunityNecromancy;
		private System.Windows.Forms.CheckBox et_SpellShield;
		private System.Windows.Forms.CheckBox et_SeeInvisible;
		private System.Windows.Forms.CheckBox et_AbilityIncrease;
		private System.Windows.Forms.CheckBox et_ElementalShield;
		private System.Windows.Forms.CheckBox et_GreaterInvisibility;
		private System.Windows.Forms.CheckBox et_Wildshape;
		private System.Windows.Forms.CheckBox et_TrueSeeing;
		private System.Windows.Forms.CheckBox et_Ultravision;
		private System.Windows.Forms.CheckBox et_Polymorph;
		private System.Windows.Forms.CheckBox et_Invisibility;
		private System.Windows.Forms.CheckBox et_Ethereal;
		private System.Windows.Forms.CheckBox et_AbsorbDamage;
		private System.Windows.Forms.CheckBox et_DamageIncrease;
		private System.Windows.Forms.CheckBox et_Concealment;
		private System.Windows.Forms.CheckBox et_SavingThrowIncrease;
		private System.Windows.Forms.CheckBox et_SpellAbsorption;
		private System.Windows.Forms.CheckBox et_Timestop;
		private System.Windows.Forms.CheckBox et_Sanctuary;
		private System.Windows.Forms.CheckBox et_TempHitpoints;
		private System.Windows.Forms.CheckBox et_Haste;
		private System.Windows.Forms.CheckBox et_DamageReduction;
		private System.Windows.Forms.CheckBox et_AttackIncrease;
		private System.Windows.Forms.Label si_hostile;
		private System.Windows.Forms.GroupBox et_DetEffectsGrp;
		private System.Windows.Forms.CheckBox et_AcDecrease;
		private System.Windows.Forms.CheckBox et_NegativeLevel;
		private System.Windows.Forms.CheckBox et_Death;
		private System.Windows.Forms.CheckBox et_SpeedDecrease;
		private System.Windows.Forms.CheckBox et_Petrify;
		private System.Windows.Forms.CheckBox et_Stun;
		private System.Windows.Forms.CheckBox et_SkillDecrease;
		private System.Windows.Forms.CheckBox et_AttackDecrease;
		private System.Windows.Forms.CheckBox et_DamageDecrease;
		private System.Windows.Forms.CheckBox et_AbilityDecrease;
		private System.Windows.Forms.CheckBox et_Slow;
		private System.Windows.Forms.CheckBox et_Silence;
		private System.Windows.Forms.CheckBox et_Disease;
		private System.Windows.Forms.CheckBox et_Poison;
		private System.Windows.Forms.CheckBox et_Daze;
		private System.Windows.Forms.CheckBox et_Dominate;
		private System.Windows.Forms.CheckBox et_Frighten;
		private System.Windows.Forms.CheckBox et_Confuse;
		private System.Windows.Forms.CheckBox et_Charm;
		private System.Windows.Forms.CheckBox et_Sleep;
		private System.Windows.Forms.CheckBox et_Curse;
		private System.Windows.Forms.CheckBox et_Blindness;
		private System.Windows.Forms.CheckBox et_Deafness;
		private System.Windows.Forms.CheckBox et_Paralyze;
		private System.Windows.Forms.CheckBox et_Entangle;
		private System.Windows.Forms.CheckBox et_CutsceneParalyze;
		private System.Windows.Forms.CheckBox et_Mesmerize;
		private System.Windows.Forms.CheckBox et_Dying;
		private System.Windows.Forms.CheckBox et_Knockdown;
		private System.Windows.Forms.CheckBox et_SavingThrowDecrease;
		private System.Windows.Forms.GroupBox si_ChildIDGrp;
		private System.Windows.Forms.TextBox si_Child5;
		private System.Windows.Forms.TextBox si_Child4;
		private System.Windows.Forms.TextBox si_Child3;
		private System.Windows.Forms.TextBox si_Child2;
		private System.Windows.Forms.TextBox si_Child1;
		private System.Windows.Forms.ToolStripMenuItem options;
		private System.Windows.Forms.ToolStripMenuItem setCoreAIver;
		private System.Windows.Forms.GroupBox ti_FlagsGrp;
		private System.Windows.Forms.CheckBox ti_Regular;
		private System.Windows.Forms.CheckBox ti_Necromancy;
		private System.Windows.Forms.CheckBox ti_ScaledEffect;
		private System.Windows.Forms.CheckBox ti_PersistentAoe;
		private System.Windows.Forms.CheckBox ti_RangedSelectedArea;
		private System.Windows.Forms.CheckBox ti_SeenRequired;
		private System.Windows.Forms.CheckBox ti_SecondaryHalfDamage;
		private System.Windows.Forms.CheckBox ti_SecondaryTargets;
		private System.Windows.Forms.CheckBox ti_MissileTargets;
		private System.Windows.Forms.CheckBox ti_CheckCount;
		private System.Windows.Forms.CheckBox ti_ShapeLoop;
		private System.Windows.Forms.GroupBox ti_RadiusGrp;
		private System.Windows.Forms.GroupBox ti_RangeGrp;
		private System.Windows.Forms.ComboBox cbo_ti_Range;
		private System.Windows.Forms.GroupBox ti_ShapeGrp;
		private System.Windows.Forms.ComboBox cbo_ti_Shape;
		private System.Windows.Forms.TextBox ti_Radius;
		private System.Windows.Forms.GroupBox di_DispelTypesGrp;
		private System.Windows.Forms.CheckBox di_Breach;
		private System.Windows.Forms.CheckBox di_Resist;
		private System.Windows.Forms.CheckBox di_Dispel;
		private System.Windows.Forms.GroupBox di_DetrimentalGrp;
		private System.Windows.Forms.GroupBox di_BeneficialGrp;
		private System.Windows.Forms.GroupBox di_BenLeveltypeGrp;
		private System.Windows.Forms.ComboBox cbo_di_BenLeveltype;
		private System.Windows.Forms.GroupBox di_DetDamagebaseGrp;
		private System.Windows.Forms.ComboBox cbo_di_DetDamagebase;
		private System.Windows.Forms.GroupBox di_DetLeveltypeGrp;
		private System.Windows.Forms.ComboBox cbo_di_DetLeveltype;
		private System.Windows.Forms.GroupBox di_BenPowerbaseGrp;
		private System.Windows.Forms.ComboBox cbo_di_BenPowerbase;
		private System.Windows.Forms.GroupBox di_DetFixedCountGrp;
		private System.Windows.Forms.TextBox di_DetFixedcount;
		private System.Windows.Forms.Label di_lbl_FixedCountPlusOne;
		private System.Windows.Forms.GroupBox di_BenLeveldecreaseGrp;
		private System.Windows.Forms.TextBox di_BenLeveldecrease;
		private System.Windows.Forms.GroupBox di_BenLeveldivisorGrp;
		private System.Windows.Forms.TextBox di_BenLeveldivisor;
		private System.Windows.Forms.GroupBox di_BenLevellimitGrp;
		private System.Windows.Forms.TextBox di_BenLevellimit;
		private System.Windows.Forms.GroupBox di_BenPowerGrp;
		private System.Windows.Forms.TextBox di_BenPower;
		private System.Windows.Forms.GroupBox di_DetDamagetypeGrp;
		private System.Windows.Forms.GroupBox di_DetLeveldivisorGrp;
		private System.Windows.Forms.TextBox di_DetLeveldivisor;
		private System.Windows.Forms.GroupBox di_DetLevellimitGrp;
		private System.Windows.Forms.TextBox di_DetLevellimit;
		private System.Windows.Forms.GroupBox di_DetDamageGrp;
		private System.Windows.Forms.TextBox di_DetDamage;
		private System.Windows.Forms.CheckBox di_Bludgeoning;
		private System.Windows.Forms.CheckBox di_Sonic;
		private System.Windows.Forms.CheckBox di_Positive;
		private System.Windows.Forms.CheckBox di_Negative;
		private System.Windows.Forms.CheckBox di_Fire;
		private System.Windows.Forms.CheckBox di_Electrical;
		private System.Windows.Forms.CheckBox di_Divine;
		private System.Windows.Forms.CheckBox di_Cold;
		private System.Windows.Forms.CheckBox di_Acid;
		private System.Windows.Forms.CheckBox di_Magical;
		private System.Windows.Forms.CheckBox di_Slashing;
		private System.Windows.Forms.CheckBox di_Piercing;
		private System.Windows.Forms.ToolStripMenuItem Save;
		private System.Windows.Forms.ToolStripMenuItem Saveas;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btn_Search_d;
		private System.Windows.Forms.TextBox tb_Search;
		private System.Windows.Forms.Button btn_Search_u;
		private System.Windows.Forms.GroupBox st_ExclusiveGrp;
		private System.Windows.Forms.GroupBox st_Excl_DamagetypesGrp;
		private System.Windows.Forms.CheckBox st_Excl_Sonic;
		private System.Windows.Forms.CheckBox st_Excl_Positive;
		private System.Windows.Forms.CheckBox st_Excl_Negative;
		private System.Windows.Forms.CheckBox st_Excl_Fire;
		private System.Windows.Forms.CheckBox st_Excl_Electrical;
		private System.Windows.Forms.CheckBox st_Excl_Divine;
		private System.Windows.Forms.CheckBox st_Excl_Cold;
		private System.Windows.Forms.CheckBox st_Excl_Acid;
		private System.Windows.Forms.CheckBox st_Excl_Magical;
		private System.Windows.Forms.CheckBox st_Excl_Slashing;
		private System.Windows.Forms.CheckBox st_Excl_Piercing;
		private System.Windows.Forms.CheckBox st_Excl_Bludgeoning;
		private System.Windows.Forms.GroupBox st_Excl_WeightGrp;
		private System.Windows.Forms.TextBox st_Excl_Weight;
		private System.Windows.Forms.GroupBox st_Excl_FlagsGrp;
		private System.Windows.Forms.CheckBox st_Excl_General;
		private System.Windows.Forms.CheckBox st_Excl_Onlyone;
		private System.Windows.Forms.GroupBox st_DetrimentalGrp;
		private System.Windows.Forms.RadioButton st_Excl_rbResistance;
		private System.Windows.Forms.RadioButton st_Excl_rbImmunity;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem FindNextChanged;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem help;
		private System.Windows.Forms.ToolStripMenuItem About;
		private System.Windows.Forms.TabControl cols_HenchRacial;
		private System.Windows.Forms.TabPage page_RacialFlags;
		private System.Windows.Forms.TabPage page_RacialFeat1;
		private System.Windows.Forms.TabPage page_RacialFeat2;
		private System.Windows.Forms.TabPage page_RacialFeat3;
		private System.Windows.Forms.TabPage page_RacialFeat4;
		private System.Windows.Forms.TabPage page_RacialFeat5;
		private System.Windows.Forms.TabControl cols_HenchClasses;
		private System.Windows.Forms.TabPage page_ClassFlags;
		private System.Windows.Forms.TabPage page_ClassFeat1;
		private System.Windows.Forms.TabPage page_ClassFeat2;
		private System.Windows.Forms.TabPage page_ClassFeat3;
		private System.Windows.Forms.TabPage page_ClassFeat4;
		private System.Windows.Forms.TabPage page_ClassFeat5;
		private System.Windows.Forms.TabPage page_ClassFeat6;
		private System.Windows.Forms.TabPage page_ClassFeat7;
		private System.Windows.Forms.TabPage page_ClassFeat8;
		private System.Windows.Forms.TabPage page_ClassFeat9;
		private System.Windows.Forms.TabPage page_ClassFeat10;
		private System.Windows.Forms.TabPage page_ClassFeat11;
		private System.Windows.Forms.Label rf_bin;
		private System.Windows.Forms.Label rf_hex;
		private System.Windows.Forms.Button rf_Clear;
		private System.Windows.Forms.TextBox RacialFlags_bin;
		private System.Windows.Forms.TextBox RacialFlags_hex;
		private System.Windows.Forms.TextBox RacialFlags_text;
		private System.Windows.Forms.Button RacialFlags_reset;
		private System.Windows.Forms.Label rf1_bin;
		private System.Windows.Forms.Label rf1_hex;
		private System.Windows.Forms.Button rf1_Clear;
		private System.Windows.Forms.TextBox RacialFeat1_bin;
		private System.Windows.Forms.TextBox RacialFeat1_hex;
		private System.Windows.Forms.TextBox RacialFeat1_text;
		private System.Windows.Forms.Button RacialFeat1_reset;
		private System.Windows.Forms.Label rf2_bin;
		private System.Windows.Forms.Label rf2_hex;
		private System.Windows.Forms.Button rf2_Clear;
		private System.Windows.Forms.TextBox RacialFeat2_bin;
		private System.Windows.Forms.TextBox RacialFeat2_hex;
		private System.Windows.Forms.TextBox RacialFeat2_text;
		private System.Windows.Forms.Button RacialFeat2_reset;
		private System.Windows.Forms.Label rf3_bin;
		private System.Windows.Forms.Label rf3_hex;
		private System.Windows.Forms.Button rf3_Clear;
		private System.Windows.Forms.TextBox RacialFeat3_bin;
		private System.Windows.Forms.TextBox RacialFeat3_hex;
		private System.Windows.Forms.TextBox RacialFeat3_text;
		private System.Windows.Forms.Button RacialFeat3_reset;
		private System.Windows.Forms.Label rf4_bin;
		private System.Windows.Forms.Label rf4_hex;
		private System.Windows.Forms.Button rf4_Clear;
		private System.Windows.Forms.TextBox RacialFeat4_bin;
		private System.Windows.Forms.TextBox RacialFeat4_hex;
		private System.Windows.Forms.TextBox RacialFeat4_text;
		private System.Windows.Forms.Button RacialFeat4_reset;
		private System.Windows.Forms.Label rf5_bin;
		private System.Windows.Forms.Label rf5_hex;
		private System.Windows.Forms.Button rf5_Clear;
		private System.Windows.Forms.TextBox RacialFeat5_bin;
		private System.Windows.Forms.TextBox RacialFeat5_hex;
		private System.Windows.Forms.TextBox RacialFeat5_text;
		private System.Windows.Forms.Button RacialFeat5_reset;
		private System.Windows.Forms.Label cf_bin;
		private System.Windows.Forms.Label cf_hex;
		private System.Windows.Forms.Button cf_Clear;
		private System.Windows.Forms.TextBox ClassFlags_bin;
		private System.Windows.Forms.TextBox ClassFlags_hex;
		private System.Windows.Forms.TextBox ClassFlags_text;
		private System.Windows.Forms.Button ClassFlags_reset;
		private System.Windows.Forms.Label cf1_bin;
		private System.Windows.Forms.Label cf1_hex;
		private System.Windows.Forms.Button cf1_Clear;
		private System.Windows.Forms.TextBox ClassFeat1_bin;
		private System.Windows.Forms.TextBox ClassFeat1_hex;
		private System.Windows.Forms.TextBox ClassFeat1_text;
		private System.Windows.Forms.Button ClassFeat1_reset;
		private System.Windows.Forms.Label cf2_bin;
		private System.Windows.Forms.Label cf2_hex;
		private System.Windows.Forms.Button cf2_Clear;
		private System.Windows.Forms.TextBox ClassFeat2_bin;
		private System.Windows.Forms.TextBox ClassFeat2_hex;
		private System.Windows.Forms.TextBox ClassFeat2_text;
		private System.Windows.Forms.Button ClassFeat2_reset;
		private System.Windows.Forms.Label cf3_bin;
		private System.Windows.Forms.Label cf3_hex;
		private System.Windows.Forms.Button cf3_Clear;
		private System.Windows.Forms.TextBox ClassFeat3_bin;
		private System.Windows.Forms.TextBox ClassFeat3_hex;
		private System.Windows.Forms.TextBox ClassFeat3_text;
		private System.Windows.Forms.Button ClassFeat3_reset;
		private System.Windows.Forms.Label cf4_bin;
		private System.Windows.Forms.Label cf4_hex;
		private System.Windows.Forms.Button cf4_Clear;
		private System.Windows.Forms.TextBox ClassFeat4_bin;
		private System.Windows.Forms.TextBox ClassFeat4_hex;
		private System.Windows.Forms.TextBox ClassFeat4_text;
		private System.Windows.Forms.Button ClassFeat4_reset;
		private System.Windows.Forms.Label cf5_bin;
		private System.Windows.Forms.Label cf5_hex;
		private System.Windows.Forms.Button cf5_Clear;
		private System.Windows.Forms.TextBox ClassFeat5_bin;
		private System.Windows.Forms.TextBox ClassFeat5_hex;
		private System.Windows.Forms.TextBox ClassFeat5_text;
		private System.Windows.Forms.Button ClassFeat5_reset;
		private System.Windows.Forms.Label cf6_bin;
		private System.Windows.Forms.Label cf6_hex;
		private System.Windows.Forms.Button cf6_Clear;
		private System.Windows.Forms.TextBox ClassFeat6_bin;
		private System.Windows.Forms.TextBox ClassFeat6_hex;
		private System.Windows.Forms.TextBox ClassFeat6_text;
		private System.Windows.Forms.Button ClassFeat6_reset;
		private System.Windows.Forms.Label cf7_bin;
		private System.Windows.Forms.Label cf7_hex;
		private System.Windows.Forms.Button cf7_Clear;
		private System.Windows.Forms.TextBox ClassFeat7_bin;
		private System.Windows.Forms.TextBox ClassFeat7_hex;
		private System.Windows.Forms.TextBox ClassFeat7_text;
		private System.Windows.Forms.Button ClassFeat7_reset;
		private System.Windows.Forms.Label cf8_bin;
		private System.Windows.Forms.Label cf8_hex;
		private System.Windows.Forms.Button cf8_Clear;
		private System.Windows.Forms.TextBox ClassFeat8_bin;
		private System.Windows.Forms.TextBox ClassFeat8_hex;
		private System.Windows.Forms.TextBox ClassFeat8_text;
		private System.Windows.Forms.Button ClassFeat8_reset;
		private System.Windows.Forms.Label cf9_bin;
		private System.Windows.Forms.Label cf9_hex;
		private System.Windows.Forms.Button cf9_Clear;
		private System.Windows.Forms.TextBox ClassFeat9_bin;
		private System.Windows.Forms.TextBox ClassFeat9_hex;
		private System.Windows.Forms.TextBox ClassFeat9_text;
		private System.Windows.Forms.Button ClassFeat9_reset;
		private System.Windows.Forms.Label cf10_bin;
		private System.Windows.Forms.Label cf10_hex;
		private System.Windows.Forms.Button cf10_Clear;
		private System.Windows.Forms.TextBox ClassFeat10_bin;
		private System.Windows.Forms.TextBox ClassFeat10_hex;
		private System.Windows.Forms.TextBox ClassFeat10_text;
		private System.Windows.Forms.Button ClassFeat10_reset;
		private System.Windows.Forms.Label cf11_bin;
		private System.Windows.Forms.Label cf11_hex;
		private System.Windows.Forms.Button cf11_Clear;
		private System.Windows.Forms.TextBox ClassFeat11_bin;
		private System.Windows.Forms.TextBox ClassFeat11_hex;
		private System.Windows.Forms.TextBox ClassFeat11_text;
		private System.Windows.Forms.Button ClassFeat11_reset;
		private System.Windows.Forms.Label rf_infoversion;
		private System.Windows.Forms.Label rf_infoversion_label;
		private System.Windows.Forms.CheckBox rf_HasFeatSpells;
		private System.Windows.Forms.TextBox rf1_SpellId;
		private System.Windows.Forms.TextBox rf1_FeatId;
		private System.Windows.Forms.CheckBox rf1_cheatCast;
		private System.Windows.Forms.Label rf1_spellId_label;
		private System.Windows.Forms.Label rf1_featId_label;
		private System.Windows.Forms.TextBox rf2_SpellId;
		private System.Windows.Forms.TextBox rf2_FeatId;
		private System.Windows.Forms.CheckBox rf2_cheatCast;
		private System.Windows.Forms.Label rf2_spellId_label;
		private System.Windows.Forms.Label rf2_featId_label;
		private System.Windows.Forms.TextBox rf3_SpellId;
		private System.Windows.Forms.TextBox rf3_FeatId;
		private System.Windows.Forms.CheckBox rf3_cheatCast;
		private System.Windows.Forms.Label rf3_spellId_label;
		private System.Windows.Forms.Label rf3_featId_label;
		private System.Windows.Forms.TextBox rf4_SpellId;
		private System.Windows.Forms.TextBox rf4_FeatId;
		private System.Windows.Forms.CheckBox rf4_cheatCast;
		private System.Windows.Forms.Label rf4_spellId_label;
		private System.Windows.Forms.Label rf4_featId_label;
		private System.Windows.Forms.TextBox rf5_SpellId;
		private System.Windows.Forms.TextBox rf5_FeatId;
		private System.Windows.Forms.CheckBox rf5_cheatCast;
		private System.Windows.Forms.Label rf5_spellId_label;
		private System.Windows.Forms.Label rf5_featId_label;
		private System.Windows.Forms.TextBox cf1_SpellId;
		private System.Windows.Forms.TextBox cf1_FeatId;
		private System.Windows.Forms.CheckBox cf1_cheatCast;
		private System.Windows.Forms.Label cf1_spellId_label;
		private System.Windows.Forms.Label cf1_featId_label;
		private System.Windows.Forms.TextBox cf2_SpellId;
		private System.Windows.Forms.TextBox cf2_FeatId;
		private System.Windows.Forms.CheckBox cf2_cheatCast;
		private System.Windows.Forms.Label cf2_spellId_label;
		private System.Windows.Forms.Label cf2_featId_label;
		private System.Windows.Forms.TextBox cf3_SpellId;
		private System.Windows.Forms.TextBox cf3_FeatId;
		private System.Windows.Forms.CheckBox cf3_cheatCast;
		private System.Windows.Forms.Label cf3_spellId_label;
		private System.Windows.Forms.Label cf3_featId_label;
		private System.Windows.Forms.TextBox cf4_SpellId;
		private System.Windows.Forms.TextBox cf4_FeatId;
		private System.Windows.Forms.CheckBox cf4_cheatCast;
		private System.Windows.Forms.Label cf4_spellId_label;
		private System.Windows.Forms.Label cf4_featId_label;
		private System.Windows.Forms.TextBox cf5_SpellId;
		private System.Windows.Forms.TextBox cf5_FeatId;
		private System.Windows.Forms.CheckBox cf5_cheatCast;
		private System.Windows.Forms.Label cf5_spellId_label;
		private System.Windows.Forms.Label cf5_featId_label;
		private System.Windows.Forms.TextBox cf6_SpellId;
		private System.Windows.Forms.TextBox cf6_FeatId;
		private System.Windows.Forms.CheckBox cf6_cheatCast;
		private System.Windows.Forms.Label cf6_spellId_label;
		private System.Windows.Forms.Label cf6_featId_label;
		private System.Windows.Forms.TextBox cf7_SpellId;
		private System.Windows.Forms.TextBox cf7_FeatId;
		private System.Windows.Forms.CheckBox cf7_cheatCast;
		private System.Windows.Forms.Label cf7_spellId_label;
		private System.Windows.Forms.Label cf7_featId_label;
		private System.Windows.Forms.TextBox cf8_SpellId;
		private System.Windows.Forms.TextBox cf8_FeatId;
		private System.Windows.Forms.CheckBox cf8_cheatCast;
		private System.Windows.Forms.Label cf8_spellId_label;
		private System.Windows.Forms.Label cf8_featId_label;
		private System.Windows.Forms.TextBox cf9_SpellId;
		private System.Windows.Forms.TextBox cf9_FeatId;
		private System.Windows.Forms.CheckBox cf9_cheatCast;
		private System.Windows.Forms.Label cf9_spellId_label;
		private System.Windows.Forms.Label cf9_featId_label;
		private System.Windows.Forms.TextBox cf10_SpellId;
		private System.Windows.Forms.TextBox cf10_FeatId;
		private System.Windows.Forms.CheckBox cf10_cheatCast;
		private System.Windows.Forms.Label cf10_spellId_label;
		private System.Windows.Forms.Label cf10_featId_label;
		private System.Windows.Forms.TextBox cf11_SpellId;
		private System.Windows.Forms.TextBox cf11_FeatId;
		private System.Windows.Forms.CheckBox cf11_cheatCast;
		private System.Windows.Forms.Label cf11_spellId_label;
		private System.Windows.Forms.Label cf11_featId_label;
		private System.Windows.Forms.CheckBox cf_HasFeatSpells;
		private System.Windows.Forms.Label cf_infoversion;
		private System.Windows.Forms.Label cf_infoversion_label;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor.
		/// The Forms designer might not be able to load this method if it was
		/// changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.cols_HenchSpells = new System.Windows.Forms.TabControl();
			this.page_SpellInfo = new System.Windows.Forms.TabPage();
			this.si_ChildIDGrp = new System.Windows.Forms.GroupBox();
			this.si_Child5 = new System.Windows.Forms.TextBox();
			this.si_Child4 = new System.Windows.Forms.TextBox();
			this.si_Child3 = new System.Windows.Forms.TextBox();
			this.si_Child2 = new System.Windows.Forms.TextBox();
			this.si_Child1 = new System.Windows.Forms.TextBox();
			this.si_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.si_IsMaster = new System.Windows.Forms.CheckBox();
			this.si_Ignore = new System.Windows.Forms.CheckBox();
			this.si_ItemCast = new System.Windows.Forms.CheckBox();
			this.si_Concentration = new System.Windows.Forms.CheckBox();
			this.si_LongDurBuff = new System.Windows.Forms.CheckBox();
			this.si_Unlimited = new System.Windows.Forms.CheckBox();
			this.si_MediumDurBuff = new System.Windows.Forms.CheckBox();
			this.si_HealOrCure = new System.Windows.Forms.CheckBox();
			this.si_ShortDurBuff = new System.Windows.Forms.CheckBox();
			this.si_SpelllevelGrp = new System.Windows.Forms.GroupBox();
			this.cbo_si_Spelllevel = new System.Windows.Forms.ComboBox();
			this.si_SpelltypeGrp = new System.Windows.Forms.GroupBox();
			this.si_hostile = new System.Windows.Forms.Label();
			this.cbo_si_Spelltype = new System.Windows.Forms.ComboBox();
			this.si_bin = new System.Windows.Forms.Label();
			this.si_hex = new System.Windows.Forms.Label();
			this.si_Clear = new System.Windows.Forms.Button();
			this.SpellInfo_bin = new System.Windows.Forms.TextBox();
			this.SpellInfo_hex = new System.Windows.Forms.TextBox();
			this.SpellInfo_text = new System.Windows.Forms.TextBox();
			this.SpellInfo_reset = new System.Windows.Forms.Button();
			this.page_TargetInfo = new System.Windows.Forms.TabPage();
			this.ti_RadiusGrp = new System.Windows.Forms.GroupBox();
			this.ti_Radius = new System.Windows.Forms.TextBox();
			this.ti_RangeGrp = new System.Windows.Forms.GroupBox();
			this.cbo_ti_Range = new System.Windows.Forms.ComboBox();
			this.ti_ShapeGrp = new System.Windows.Forms.GroupBox();
			this.cbo_ti_Shape = new System.Windows.Forms.ComboBox();
			this.ti_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.ti_Regular = new System.Windows.Forms.CheckBox();
			this.ti_Necromancy = new System.Windows.Forms.CheckBox();
			this.ti_ScaledEffect = new System.Windows.Forms.CheckBox();
			this.ti_PersistentAoe = new System.Windows.Forms.CheckBox();
			this.ti_RangedSelectedArea = new System.Windows.Forms.CheckBox();
			this.ti_SeenRequired = new System.Windows.Forms.CheckBox();
			this.ti_SecondaryHalfDamage = new System.Windows.Forms.CheckBox();
			this.ti_SecondaryTargets = new System.Windows.Forms.CheckBox();
			this.ti_MissileTargets = new System.Windows.Forms.CheckBox();
			this.ti_CheckCount = new System.Windows.Forms.CheckBox();
			this.ti_ShapeLoop = new System.Windows.Forms.CheckBox();
			this.ti_bin = new System.Windows.Forms.Label();
			this.ti_hex = new System.Windows.Forms.Label();
			this.ti_Clear = new System.Windows.Forms.Button();
			this.TargetInfo_bin = new System.Windows.Forms.TextBox();
			this.TargetInfo_hex = new System.Windows.Forms.TextBox();
			this.TargetInfo_text = new System.Windows.Forms.TextBox();
			this.TargetInfo_reset = new System.Windows.Forms.Button();
			this.page_EffectWeight = new System.Windows.Forms.TabPage();
			this.ew_Clear = new System.Windows.Forms.Button();
			this.f2 = new System.Windows.Forms.Label();
			this.f1 = new System.Windows.Forms.Label();
			this.EffectWeight_reset = new System.Windows.Forms.Button();
			this.EffectWeight_text = new System.Windows.Forms.TextBox();
			this.page_EffectTypes = new System.Windows.Forms.TabPage();
			this.et_DetEffectsGrp = new System.Windows.Forms.GroupBox();
			this.et_CutsceneParalyze = new System.Windows.Forms.CheckBox();
			this.et_Mesmerize = new System.Windows.Forms.CheckBox();
			this.et_Dying = new System.Windows.Forms.CheckBox();
			this.et_Knockdown = new System.Windows.Forms.CheckBox();
			this.et_SavingThrowDecrease = new System.Windows.Forms.CheckBox();
			this.et_AcDecrease = new System.Windows.Forms.CheckBox();
			this.et_NegativeLevel = new System.Windows.Forms.CheckBox();
			this.et_Death = new System.Windows.Forms.CheckBox();
			this.et_SpeedDecrease = new System.Windows.Forms.CheckBox();
			this.et_Petrify = new System.Windows.Forms.CheckBox();
			this.et_Stun = new System.Windows.Forms.CheckBox();
			this.et_SkillDecrease = new System.Windows.Forms.CheckBox();
			this.et_AttackDecrease = new System.Windows.Forms.CheckBox();
			this.et_DamageDecrease = new System.Windows.Forms.CheckBox();
			this.et_AbilityDecrease = new System.Windows.Forms.CheckBox();
			this.et_Slow = new System.Windows.Forms.CheckBox();
			this.et_Silence = new System.Windows.Forms.CheckBox();
			this.et_Disease = new System.Windows.Forms.CheckBox();
			this.et_Poison = new System.Windows.Forms.CheckBox();
			this.et_Daze = new System.Windows.Forms.CheckBox();
			this.et_Dominate = new System.Windows.Forms.CheckBox();
			this.et_Frighten = new System.Windows.Forms.CheckBox();
			this.et_Confuse = new System.Windows.Forms.CheckBox();
			this.et_Charm = new System.Windows.Forms.CheckBox();
			this.et_Sleep = new System.Windows.Forms.CheckBox();
			this.et_Curse = new System.Windows.Forms.CheckBox();
			this.et_Blindness = new System.Windows.Forms.CheckBox();
			this.et_Deafness = new System.Windows.Forms.CheckBox();
			this.et_Paralyze = new System.Windows.Forms.CheckBox();
			this.et_Entangle = new System.Windows.Forms.CheckBox();
			this.et_BenEffectsGrp = new System.Windows.Forms.GroupBox();
			this.et_ImmunityNecromancy = new System.Windows.Forms.CheckBox();
			this.et_SpellShield = new System.Windows.Forms.CheckBox();
			this.et_SeeInvisible = new System.Windows.Forms.CheckBox();
			this.et_AbilityIncrease = new System.Windows.Forms.CheckBox();
			this.et_ElementalShield = new System.Windows.Forms.CheckBox();
			this.et_GreaterInvisibility = new System.Windows.Forms.CheckBox();
			this.et_Wildshape = new System.Windows.Forms.CheckBox();
			this.et_TrueSeeing = new System.Windows.Forms.CheckBox();
			this.et_Ultravision = new System.Windows.Forms.CheckBox();
			this.et_Polymorph = new System.Windows.Forms.CheckBox();
			this.et_Invisibility = new System.Windows.Forms.CheckBox();
			this.et_Ethereal = new System.Windows.Forms.CheckBox();
			this.et_AbsorbDamage = new System.Windows.Forms.CheckBox();
			this.et_DamageIncrease = new System.Windows.Forms.CheckBox();
			this.et_Concealment = new System.Windows.Forms.CheckBox();
			this.et_SavingThrowIncrease = new System.Windows.Forms.CheckBox();
			this.et_SpellAbsorption = new System.Windows.Forms.CheckBox();
			this.et_Timestop = new System.Windows.Forms.CheckBox();
			this.et_Sanctuary = new System.Windows.Forms.CheckBox();
			this.et_TempHitpoints = new System.Windows.Forms.CheckBox();
			this.et_Haste = new System.Windows.Forms.CheckBox();
			this.et_DamageReduction = new System.Windows.Forms.CheckBox();
			this.et_AttackIncrease = new System.Windows.Forms.CheckBox();
			this.et_Regenerate = new System.Windows.Forms.CheckBox();
			this.et_AcIncrease = new System.Windows.Forms.CheckBox();
			this.et_bin = new System.Windows.Forms.Label();
			this.et_hex = new System.Windows.Forms.Label();
			this.et_Clear = new System.Windows.Forms.Button();
			this.EffectTypes_bin = new System.Windows.Forms.TextBox();
			this.EffectTypes_hex = new System.Windows.Forms.TextBox();
			this.EffectTypes_text = new System.Windows.Forms.TextBox();
			this.EffectTypes_reset = new System.Windows.Forms.Button();
			this.page_DamageInfo = new System.Windows.Forms.TabPage();
			this.di_DetrimentalGrp = new System.Windows.Forms.GroupBox();
			this.di_DetDamageGrp = new System.Windows.Forms.GroupBox();
			this.di_DetDamage = new System.Windows.Forms.TextBox();
			this.di_DetDamagetypeGrp = new System.Windows.Forms.GroupBox();
			this.di_Sonic = new System.Windows.Forms.CheckBox();
			this.di_Positive = new System.Windows.Forms.CheckBox();
			this.di_Negative = new System.Windows.Forms.CheckBox();
			this.di_Fire = new System.Windows.Forms.CheckBox();
			this.di_Electrical = new System.Windows.Forms.CheckBox();
			this.di_Divine = new System.Windows.Forms.CheckBox();
			this.di_Cold = new System.Windows.Forms.CheckBox();
			this.di_Acid = new System.Windows.Forms.CheckBox();
			this.di_Magical = new System.Windows.Forms.CheckBox();
			this.di_Slashing = new System.Windows.Forms.CheckBox();
			this.di_Piercing = new System.Windows.Forms.CheckBox();
			this.di_Bludgeoning = new System.Windows.Forms.CheckBox();
			this.di_DetLeveldivisorGrp = new System.Windows.Forms.GroupBox();
			this.di_DetLeveldivisor = new System.Windows.Forms.TextBox();
			this.di_DetLevellimitGrp = new System.Windows.Forms.GroupBox();
			this.di_DetLevellimit = new System.Windows.Forms.TextBox();
			this.di_DetFixedCountGrp = new System.Windows.Forms.GroupBox();
			this.di_lbl_FixedCountPlusOne = new System.Windows.Forms.Label();
			this.di_DetFixedcount = new System.Windows.Forms.TextBox();
			this.di_DetDamagebaseGrp = new System.Windows.Forms.GroupBox();
			this.cbo_di_DetDamagebase = new System.Windows.Forms.ComboBox();
			this.di_DetLeveltypeGrp = new System.Windows.Forms.GroupBox();
			this.cbo_di_DetLeveltype = new System.Windows.Forms.ComboBox();
			this.di_BeneficialGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLeveldecreaseGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLeveldecrease = new System.Windows.Forms.TextBox();
			this.di_BenPowerbaseGrp = new System.Windows.Forms.GroupBox();
			this.cbo_di_BenPowerbase = new System.Windows.Forms.ComboBox();
			this.di_BenPowerGrp = new System.Windows.Forms.GroupBox();
			this.di_BenPower = new System.Windows.Forms.TextBox();
			this.di_BenLeveldivisorGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLeveldivisor = new System.Windows.Forms.TextBox();
			this.di_BenLevellimitGrp = new System.Windows.Forms.GroupBox();
			this.di_BenLevellimit = new System.Windows.Forms.TextBox();
			this.di_BenLeveltypeGrp = new System.Windows.Forms.GroupBox();
			this.cbo_di_BenLeveltype = new System.Windows.Forms.ComboBox();
			this.di_DispelTypesGrp = new System.Windows.Forms.GroupBox();
			this.di_Resist = new System.Windows.Forms.CheckBox();
			this.di_Dispel = new System.Windows.Forms.CheckBox();
			this.di_Breach = new System.Windows.Forms.CheckBox();
			this.di_bin = new System.Windows.Forms.Label();
			this.di_hex = new System.Windows.Forms.Label();
			this.di_Clear = new System.Windows.Forms.Button();
			this.DamageInfo_bin = new System.Windows.Forms.TextBox();
			this.DamageInfo_hex = new System.Windows.Forms.TextBox();
			this.DamageInfo_text = new System.Windows.Forms.TextBox();
			this.DamageInfo_reset = new System.Windows.Forms.Button();
			this.page_SaveType = new System.Windows.Forms.TabPage();
			this.st_DetrimentalGrp = new System.Windows.Forms.GroupBox();
			this.st_SpecificGrp = new System.Windows.Forms.GroupBox();
			this.cbo_st_Specific = new System.Windows.Forms.ComboBox();
			this.st_Immunity2Grp = new System.Windows.Forms.GroupBox();
			this.cbo_st_Immunity2 = new System.Windows.Forms.ComboBox();
			this.st_Immunity1Grp = new System.Windows.Forms.GroupBox();
			this.cbo_st_Immunity1 = new System.Windows.Forms.ComboBox();
			this.st_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.st_SpellResistance = new System.Windows.Forms.CheckBox();
			this.st_MindAffecting = new System.Windows.Forms.CheckBox();
			this.st_AffectsFriendlies = new System.Windows.Forms.CheckBox();
			this.st_TouchRanged = new System.Windows.Forms.CheckBox();
			this.st_TouchMelee = new System.Windows.Forms.CheckBox();
			this.st_Impact1Grp = new System.Windows.Forms.GroupBox();
			this.st_Impact1rb_damageevasion = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_effectdamage = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_damagehalf = new System.Windows.Forms.RadioButton();
			this.st_Impact1rb_effectonly = new System.Windows.Forms.RadioButton();
			this.st_Impact2Grp = new System.Windows.Forms.GroupBox();
			this.st_Impact2rb_damageevasion = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_effectdamage = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_damagehalf = new System.Windows.Forms.RadioButton();
			this.st_Impact2rb_effectonly = new System.Windows.Forms.RadioButton();
			this.st_Save2Grp = new System.Windows.Forms.GroupBox();
			this.st_Save2rb_will = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_refl = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_fort = new System.Windows.Forms.RadioButton();
			this.st_Save2rb_none = new System.Windows.Forms.RadioButton();
			this.st_Save1Grp = new System.Windows.Forms.GroupBox();
			this.st_Save1rb_will = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_refl = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_fort = new System.Windows.Forms.RadioButton();
			this.st_Save1rb_none = new System.Windows.Forms.RadioButton();
			this.st_ExclusiveGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_FlagsGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_rbResistance = new System.Windows.Forms.RadioButton();
			this.st_Excl_rbImmunity = new System.Windows.Forms.RadioButton();
			this.st_Excl_General = new System.Windows.Forms.CheckBox();
			this.st_Excl_Onlyone = new System.Windows.Forms.CheckBox();
			this.st_Excl_WeightGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_Weight = new System.Windows.Forms.TextBox();
			this.st_Excl_DamagetypesGrp = new System.Windows.Forms.GroupBox();
			this.st_Excl_Sonic = new System.Windows.Forms.CheckBox();
			this.st_Excl_Positive = new System.Windows.Forms.CheckBox();
			this.st_Excl_Negative = new System.Windows.Forms.CheckBox();
			this.st_Excl_Fire = new System.Windows.Forms.CheckBox();
			this.st_Excl_Electrical = new System.Windows.Forms.CheckBox();
			this.st_Excl_Divine = new System.Windows.Forms.CheckBox();
			this.st_Excl_Cold = new System.Windows.Forms.CheckBox();
			this.st_Excl_Acid = new System.Windows.Forms.CheckBox();
			this.st_Excl_Magical = new System.Windows.Forms.CheckBox();
			this.st_Excl_Slashing = new System.Windows.Forms.CheckBox();
			this.st_Excl_Piercing = new System.Windows.Forms.CheckBox();
			this.st_Excl_Bludgeoning = new System.Windows.Forms.CheckBox();
			this.st_bin = new System.Windows.Forms.Label();
			this.st_hex = new System.Windows.Forms.Label();
			this.st_NotCaster = new System.Windows.Forms.CheckBox();
			this.st_Clear = new System.Windows.Forms.Button();
			this.SaveType_bin = new System.Windows.Forms.TextBox();
			this.SaveType_hex = new System.Windows.Forms.TextBox();
			this.st_AcBonusGrp = new System.Windows.Forms.GroupBox();
			this.cbo_st_AcBonus = new System.Windows.Forms.ComboBox();
			this.st_TargetRestrictionGrp = new System.Windows.Forms.GroupBox();
			this.cbo_st_TargetRestriction = new System.Windows.Forms.ComboBox();
			this.SaveType_text = new System.Windows.Forms.TextBox();
			this.SaveType_reset = new System.Windows.Forms.Button();
			this.page_SaveDCType = new System.Windows.Forms.TabPage();
			this.dc_bin = new System.Windows.Forms.Label();
			this.dc_hex = new System.Windows.Forms.Label();
			this.dc_Clear = new System.Windows.Forms.Button();
			this.SaveDCType_bin = new System.Windows.Forms.TextBox();
			this.SaveDCType_hex = new System.Windows.Forms.TextBox();
			this.dc_ArmorCheckGrp = new System.Windows.Forms.GroupBox();
			this.armorcheck_info = new System.Windows.Forms.Label();
			this.savedc_ac3 = new System.Windows.Forms.CheckBox();
			this.savedc_ac1 = new System.Windows.Forms.CheckBox();
			this.savedc_ac2 = new System.Windows.Forms.CheckBox();
			this.SaveDCType_text = new System.Windows.Forms.TextBox();
			this.dc_WeaponBonusGrp = new System.Windows.Forms.GroupBox();
			this.cbo_dc_WeaponBonus = new System.Windows.Forms.ComboBox();
			this.dc_SaveDCGrp = new System.Windows.Forms.GroupBox();
			this.savedc_info = new System.Windows.Forms.Label();
			this.savedc_adjustor_info = new System.Windows.Forms.Label();
			this.savedc_dn = new System.Windows.Forms.Button();
			this.savedc_up = new System.Windows.Forms.Button();
			this.cbo_dc_SaveDC = new System.Windows.Forms.ComboBox();
			this.savedctype_label = new System.Windows.Forms.Label();
			this.SaveDCType_reset = new System.Windows.Forms.Button();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.file = new System.Windows.Forms.ToolStripMenuItem();
			this.Open = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Save = new System.Windows.Forms.ToolStripMenuItem();
			this.Saveas = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Quit = new System.Windows.Forms.ToolStripMenuItem();
			this.edit = new System.Windows.Forms.ToolStripMenuItem();
			this.FindNextChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Copy_decimal = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_hexadecimal = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_binary = new System.Windows.Forms.ToolStripMenuItem();
			this.options = new System.Windows.Forms.ToolStripMenuItem();
			this.setCoreAIver = new System.Windows.Forms.ToolStripMenuItem();
			this.help = new System.Windows.Forms.ToolStripMenuItem();
			this.About = new System.Windows.Forms.ToolStripMenuItem();
			this.Tree = new System.Windows.Forms.TreeView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btn_Search_u = new System.Windows.Forms.Button();
			this.btn_Search_d = new System.Windows.Forms.Button();
			this.tb_Search = new System.Windows.Forms.TextBox();
			this.cols_HenchClasses = new System.Windows.Forms.TabControl();
			this.page_ClassFlags = new System.Windows.Forms.TabPage();
			this.cf_infoversion = new System.Windows.Forms.Label();
			this.cf_infoversion_label = new System.Windows.Forms.Label();
			this.cf_HasFeatSpells = new System.Windows.Forms.CheckBox();
			this.cf_bin = new System.Windows.Forms.Label();
			this.cf_hex = new System.Windows.Forms.Label();
			this.cf_Clear = new System.Windows.Forms.Button();
			this.ClassFlags_bin = new System.Windows.Forms.TextBox();
			this.ClassFlags_hex = new System.Windows.Forms.TextBox();
			this.ClassFlags_text = new System.Windows.Forms.TextBox();
			this.ClassFlags_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat1 = new System.Windows.Forms.TabPage();
			this.cf1_SpellId = new System.Windows.Forms.TextBox();
			this.cf1_FeatId = new System.Windows.Forms.TextBox();
			this.cf1_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf1_spellId_label = new System.Windows.Forms.Label();
			this.cf1_featId_label = new System.Windows.Forms.Label();
			this.cf1_bin = new System.Windows.Forms.Label();
			this.cf1_hex = new System.Windows.Forms.Label();
			this.cf1_Clear = new System.Windows.Forms.Button();
			this.ClassFeat1_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat1_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat1_text = new System.Windows.Forms.TextBox();
			this.ClassFeat1_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat2 = new System.Windows.Forms.TabPage();
			this.cf2_SpellId = new System.Windows.Forms.TextBox();
			this.cf2_FeatId = new System.Windows.Forms.TextBox();
			this.cf2_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf2_spellId_label = new System.Windows.Forms.Label();
			this.cf2_featId_label = new System.Windows.Forms.Label();
			this.cf2_bin = new System.Windows.Forms.Label();
			this.cf2_hex = new System.Windows.Forms.Label();
			this.cf2_Clear = new System.Windows.Forms.Button();
			this.ClassFeat2_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat2_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat2_text = new System.Windows.Forms.TextBox();
			this.ClassFeat2_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat3 = new System.Windows.Forms.TabPage();
			this.cf3_SpellId = new System.Windows.Forms.TextBox();
			this.cf3_FeatId = new System.Windows.Forms.TextBox();
			this.cf3_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf3_spellId_label = new System.Windows.Forms.Label();
			this.cf3_featId_label = new System.Windows.Forms.Label();
			this.cf3_bin = new System.Windows.Forms.Label();
			this.cf3_hex = new System.Windows.Forms.Label();
			this.cf3_Clear = new System.Windows.Forms.Button();
			this.ClassFeat3_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat3_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat3_text = new System.Windows.Forms.TextBox();
			this.ClassFeat3_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat4 = new System.Windows.Forms.TabPage();
			this.cf4_SpellId = new System.Windows.Forms.TextBox();
			this.cf4_FeatId = new System.Windows.Forms.TextBox();
			this.cf4_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf4_spellId_label = new System.Windows.Forms.Label();
			this.cf4_featId_label = new System.Windows.Forms.Label();
			this.cf4_bin = new System.Windows.Forms.Label();
			this.cf4_hex = new System.Windows.Forms.Label();
			this.cf4_Clear = new System.Windows.Forms.Button();
			this.ClassFeat4_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat4_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat4_text = new System.Windows.Forms.TextBox();
			this.ClassFeat4_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat5 = new System.Windows.Forms.TabPage();
			this.cf5_SpellId = new System.Windows.Forms.TextBox();
			this.cf5_FeatId = new System.Windows.Forms.TextBox();
			this.cf5_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf5_spellId_label = new System.Windows.Forms.Label();
			this.cf5_featId_label = new System.Windows.Forms.Label();
			this.cf5_bin = new System.Windows.Forms.Label();
			this.cf5_hex = new System.Windows.Forms.Label();
			this.cf5_Clear = new System.Windows.Forms.Button();
			this.ClassFeat5_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat5_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat5_text = new System.Windows.Forms.TextBox();
			this.ClassFeat5_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat6 = new System.Windows.Forms.TabPage();
			this.cf6_SpellId = new System.Windows.Forms.TextBox();
			this.cf6_FeatId = new System.Windows.Forms.TextBox();
			this.cf6_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf6_spellId_label = new System.Windows.Forms.Label();
			this.cf6_featId_label = new System.Windows.Forms.Label();
			this.cf6_bin = new System.Windows.Forms.Label();
			this.cf6_hex = new System.Windows.Forms.Label();
			this.cf6_Clear = new System.Windows.Forms.Button();
			this.ClassFeat6_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat6_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat6_text = new System.Windows.Forms.TextBox();
			this.ClassFeat6_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat7 = new System.Windows.Forms.TabPage();
			this.cf7_SpellId = new System.Windows.Forms.TextBox();
			this.cf7_FeatId = new System.Windows.Forms.TextBox();
			this.cf7_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf7_spellId_label = new System.Windows.Forms.Label();
			this.cf7_featId_label = new System.Windows.Forms.Label();
			this.cf7_bin = new System.Windows.Forms.Label();
			this.cf7_hex = new System.Windows.Forms.Label();
			this.cf7_Clear = new System.Windows.Forms.Button();
			this.ClassFeat7_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat7_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat7_text = new System.Windows.Forms.TextBox();
			this.ClassFeat7_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat8 = new System.Windows.Forms.TabPage();
			this.cf8_SpellId = new System.Windows.Forms.TextBox();
			this.cf8_FeatId = new System.Windows.Forms.TextBox();
			this.cf8_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf8_spellId_label = new System.Windows.Forms.Label();
			this.cf8_featId_label = new System.Windows.Forms.Label();
			this.cf8_bin = new System.Windows.Forms.Label();
			this.cf8_hex = new System.Windows.Forms.Label();
			this.cf8_Clear = new System.Windows.Forms.Button();
			this.ClassFeat8_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat8_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat8_text = new System.Windows.Forms.TextBox();
			this.ClassFeat8_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat9 = new System.Windows.Forms.TabPage();
			this.cf9_SpellId = new System.Windows.Forms.TextBox();
			this.cf9_FeatId = new System.Windows.Forms.TextBox();
			this.cf9_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf9_spellId_label = new System.Windows.Forms.Label();
			this.cf9_featId_label = new System.Windows.Forms.Label();
			this.cf9_bin = new System.Windows.Forms.Label();
			this.cf9_hex = new System.Windows.Forms.Label();
			this.cf9_Clear = new System.Windows.Forms.Button();
			this.ClassFeat9_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat9_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat9_text = new System.Windows.Forms.TextBox();
			this.ClassFeat9_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat10 = new System.Windows.Forms.TabPage();
			this.cf10_SpellId = new System.Windows.Forms.TextBox();
			this.cf10_FeatId = new System.Windows.Forms.TextBox();
			this.cf10_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf10_spellId_label = new System.Windows.Forms.Label();
			this.cf10_featId_label = new System.Windows.Forms.Label();
			this.cf10_bin = new System.Windows.Forms.Label();
			this.cf10_hex = new System.Windows.Forms.Label();
			this.cf10_Clear = new System.Windows.Forms.Button();
			this.ClassFeat10_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat10_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat10_text = new System.Windows.Forms.TextBox();
			this.ClassFeat10_reset = new System.Windows.Forms.Button();
			this.page_ClassFeat11 = new System.Windows.Forms.TabPage();
			this.cf11_SpellId = new System.Windows.Forms.TextBox();
			this.cf11_FeatId = new System.Windows.Forms.TextBox();
			this.cf11_cheatCast = new System.Windows.Forms.CheckBox();
			this.cf11_spellId_label = new System.Windows.Forms.Label();
			this.cf11_featId_label = new System.Windows.Forms.Label();
			this.cf11_bin = new System.Windows.Forms.Label();
			this.cf11_hex = new System.Windows.Forms.Label();
			this.cf11_Clear = new System.Windows.Forms.Button();
			this.ClassFeat11_bin = new System.Windows.Forms.TextBox();
			this.ClassFeat11_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat11_text = new System.Windows.Forms.TextBox();
			this.ClassFeat11_reset = new System.Windows.Forms.Button();
			this.cols_HenchRacial = new System.Windows.Forms.TabControl();
			this.page_RacialFlags = new System.Windows.Forms.TabPage();
			this.rf_HasFeatSpells = new System.Windows.Forms.CheckBox();
			this.rf_infoversion = new System.Windows.Forms.Label();
			this.rf_infoversion_label = new System.Windows.Forms.Label();
			this.rf_bin = new System.Windows.Forms.Label();
			this.rf_hex = new System.Windows.Forms.Label();
			this.rf_Clear = new System.Windows.Forms.Button();
			this.RacialFlags_bin = new System.Windows.Forms.TextBox();
			this.RacialFlags_hex = new System.Windows.Forms.TextBox();
			this.RacialFlags_text = new System.Windows.Forms.TextBox();
			this.RacialFlags_reset = new System.Windows.Forms.Button();
			this.page_RacialFeat1 = new System.Windows.Forms.TabPage();
			this.rf1_SpellId = new System.Windows.Forms.TextBox();
			this.rf1_FeatId = new System.Windows.Forms.TextBox();
			this.rf1_cheatCast = new System.Windows.Forms.CheckBox();
			this.rf1_spellId_label = new System.Windows.Forms.Label();
			this.rf1_featId_label = new System.Windows.Forms.Label();
			this.rf1_bin = new System.Windows.Forms.Label();
			this.rf1_hex = new System.Windows.Forms.Label();
			this.rf1_Clear = new System.Windows.Forms.Button();
			this.RacialFeat1_bin = new System.Windows.Forms.TextBox();
			this.RacialFeat1_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat1_text = new System.Windows.Forms.TextBox();
			this.RacialFeat1_reset = new System.Windows.Forms.Button();
			this.page_RacialFeat2 = new System.Windows.Forms.TabPage();
			this.rf2_SpellId = new System.Windows.Forms.TextBox();
			this.rf2_FeatId = new System.Windows.Forms.TextBox();
			this.rf2_cheatCast = new System.Windows.Forms.CheckBox();
			this.rf2_spellId_label = new System.Windows.Forms.Label();
			this.rf2_featId_label = new System.Windows.Forms.Label();
			this.rf2_bin = new System.Windows.Forms.Label();
			this.rf2_hex = new System.Windows.Forms.Label();
			this.rf2_Clear = new System.Windows.Forms.Button();
			this.RacialFeat2_bin = new System.Windows.Forms.TextBox();
			this.RacialFeat2_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat2_text = new System.Windows.Forms.TextBox();
			this.RacialFeat2_reset = new System.Windows.Forms.Button();
			this.page_RacialFeat3 = new System.Windows.Forms.TabPage();
			this.rf3_SpellId = new System.Windows.Forms.TextBox();
			this.rf3_FeatId = new System.Windows.Forms.TextBox();
			this.rf3_cheatCast = new System.Windows.Forms.CheckBox();
			this.rf3_spellId_label = new System.Windows.Forms.Label();
			this.rf3_featId_label = new System.Windows.Forms.Label();
			this.rf3_bin = new System.Windows.Forms.Label();
			this.rf3_hex = new System.Windows.Forms.Label();
			this.rf3_Clear = new System.Windows.Forms.Button();
			this.RacialFeat3_bin = new System.Windows.Forms.TextBox();
			this.RacialFeat3_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat3_text = new System.Windows.Forms.TextBox();
			this.RacialFeat3_reset = new System.Windows.Forms.Button();
			this.page_RacialFeat4 = new System.Windows.Forms.TabPage();
			this.rf4_SpellId = new System.Windows.Forms.TextBox();
			this.rf4_FeatId = new System.Windows.Forms.TextBox();
			this.rf4_cheatCast = new System.Windows.Forms.CheckBox();
			this.rf4_spellId_label = new System.Windows.Forms.Label();
			this.rf4_featId_label = new System.Windows.Forms.Label();
			this.rf4_bin = new System.Windows.Forms.Label();
			this.rf4_hex = new System.Windows.Forms.Label();
			this.rf4_Clear = new System.Windows.Forms.Button();
			this.RacialFeat4_bin = new System.Windows.Forms.TextBox();
			this.RacialFeat4_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat4_text = new System.Windows.Forms.TextBox();
			this.RacialFeat4_reset = new System.Windows.Forms.Button();
			this.page_RacialFeat5 = new System.Windows.Forms.TabPage();
			this.rf5_SpellId = new System.Windows.Forms.TextBox();
			this.rf5_FeatId = new System.Windows.Forms.TextBox();
			this.rf5_cheatCast = new System.Windows.Forms.CheckBox();
			this.rf5_spellId_label = new System.Windows.Forms.Label();
			this.rf5_featId_label = new System.Windows.Forms.Label();
			this.rf5_bin = new System.Windows.Forms.Label();
			this.rf5_hex = new System.Windows.Forms.Label();
			this.rf5_Clear = new System.Windows.Forms.Button();
			this.RacialFeat5_bin = new System.Windows.Forms.TextBox();
			this.RacialFeat5_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat5_text = new System.Windows.Forms.TextBox();
			this.RacialFeat5_reset = new System.Windows.Forms.Button();
			this.apply = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cols_HenchSpells.SuspendLayout();
			this.page_SpellInfo.SuspendLayout();
			this.si_ChildIDGrp.SuspendLayout();
			this.si_FlagsGrp.SuspendLayout();
			this.si_SpelllevelGrp.SuspendLayout();
			this.si_SpelltypeGrp.SuspendLayout();
			this.page_TargetInfo.SuspendLayout();
			this.ti_RadiusGrp.SuspendLayout();
			this.ti_RangeGrp.SuspendLayout();
			this.ti_ShapeGrp.SuspendLayout();
			this.ti_FlagsGrp.SuspendLayout();
			this.page_EffectWeight.SuspendLayout();
			this.page_EffectTypes.SuspendLayout();
			this.et_DetEffectsGrp.SuspendLayout();
			this.et_BenEffectsGrp.SuspendLayout();
			this.page_DamageInfo.SuspendLayout();
			this.di_DetrimentalGrp.SuspendLayout();
			this.di_DetDamageGrp.SuspendLayout();
			this.di_DetDamagetypeGrp.SuspendLayout();
			this.di_DetLeveldivisorGrp.SuspendLayout();
			this.di_DetLevellimitGrp.SuspendLayout();
			this.di_DetFixedCountGrp.SuspendLayout();
			this.di_DetDamagebaseGrp.SuspendLayout();
			this.di_DetLeveltypeGrp.SuspendLayout();
			this.di_BeneficialGrp.SuspendLayout();
			this.di_BenLeveldecreaseGrp.SuspendLayout();
			this.di_BenPowerbaseGrp.SuspendLayout();
			this.di_BenPowerGrp.SuspendLayout();
			this.di_BenLeveldivisorGrp.SuspendLayout();
			this.di_BenLevellimitGrp.SuspendLayout();
			this.di_BenLeveltypeGrp.SuspendLayout();
			this.di_DispelTypesGrp.SuspendLayout();
			this.page_SaveType.SuspendLayout();
			this.st_DetrimentalGrp.SuspendLayout();
			this.st_SpecificGrp.SuspendLayout();
			this.st_Immunity2Grp.SuspendLayout();
			this.st_Immunity1Grp.SuspendLayout();
			this.st_FlagsGrp.SuspendLayout();
			this.st_Impact1Grp.SuspendLayout();
			this.st_Impact2Grp.SuspendLayout();
			this.st_Save2Grp.SuspendLayout();
			this.st_Save1Grp.SuspendLayout();
			this.st_ExclusiveGrp.SuspendLayout();
			this.st_Excl_FlagsGrp.SuspendLayout();
			this.st_Excl_WeightGrp.SuspendLayout();
			this.st_Excl_DamagetypesGrp.SuspendLayout();
			this.st_AcBonusGrp.SuspendLayout();
			this.st_TargetRestrictionGrp.SuspendLayout();
			this.page_SaveDCType.SuspendLayout();
			this.dc_ArmorCheckGrp.SuspendLayout();
			this.dc_WeaponBonusGrp.SuspendLayout();
			this.dc_SaveDCGrp.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.cols_HenchClasses.SuspendLayout();
			this.page_ClassFlags.SuspendLayout();
			this.page_ClassFeat1.SuspendLayout();
			this.page_ClassFeat2.SuspendLayout();
			this.page_ClassFeat3.SuspendLayout();
			this.page_ClassFeat4.SuspendLayout();
			this.page_ClassFeat5.SuspendLayout();
			this.page_ClassFeat6.SuspendLayout();
			this.page_ClassFeat7.SuspendLayout();
			this.page_ClassFeat8.SuspendLayout();
			this.page_ClassFeat9.SuspendLayout();
			this.page_ClassFeat10.SuspendLayout();
			this.page_ClassFeat11.SuspendLayout();
			this.cols_HenchRacial.SuspendLayout();
			this.page_RacialFlags.SuspendLayout();
			this.page_RacialFeat1.SuspendLayout();
			this.page_RacialFeat2.SuspendLayout();
			this.page_RacialFeat3.SuspendLayout();
			this.page_RacialFeat4.SuspendLayout();
			this.page_RacialFeat5.SuspendLayout();
			this.SuspendLayout();
			// 
			// cols_HenchSpells
			// 
			this.cols_HenchSpells.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.cols_HenchSpells.Controls.Add(this.page_SpellInfo);
			this.cols_HenchSpells.Controls.Add(this.page_TargetInfo);
			this.cols_HenchSpells.Controls.Add(this.page_EffectWeight);
			this.cols_HenchSpells.Controls.Add(this.page_EffectTypes);
			this.cols_HenchSpells.Controls.Add(this.page_DamageInfo);
			this.cols_HenchSpells.Controls.Add(this.page_SaveType);
			this.cols_HenchSpells.Controls.Add(this.page_SaveDCType);
			this.cols_HenchSpells.Location = new System.Drawing.Point(0, 0);
			this.cols_HenchSpells.Margin = new System.Windows.Forms.Padding(0);
			this.cols_HenchSpells.Name = "cols_HenchSpells";
			this.cols_HenchSpells.Padding = new System.Drawing.Point(5, 2);
			this.cols_HenchSpells.SelectedIndex = 0;
			this.cols_HenchSpells.Size = new System.Drawing.Size(820, 455);
			this.cols_HenchSpells.TabIndex = 0;
			this.cols_HenchSpells.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_tab);
			// 
			// page_SpellInfo
			// 
			this.page_SpellInfo.Controls.Add(this.si_ChildIDGrp);
			this.page_SpellInfo.Controls.Add(this.si_FlagsGrp);
			this.page_SpellInfo.Controls.Add(this.si_SpelllevelGrp);
			this.page_SpellInfo.Controls.Add(this.si_SpelltypeGrp);
			this.page_SpellInfo.Controls.Add(this.si_bin);
			this.page_SpellInfo.Controls.Add(this.si_hex);
			this.page_SpellInfo.Controls.Add(this.si_Clear);
			this.page_SpellInfo.Controls.Add(this.SpellInfo_bin);
			this.page_SpellInfo.Controls.Add(this.SpellInfo_hex);
			this.page_SpellInfo.Controls.Add(this.SpellInfo_text);
			this.page_SpellInfo.Controls.Add(this.SpellInfo_reset);
			this.page_SpellInfo.Location = new System.Drawing.Point(4, 24);
			this.page_SpellInfo.Margin = new System.Windows.Forms.Padding(2);
			this.page_SpellInfo.Name = "page_SpellInfo";
			this.page_SpellInfo.Padding = new System.Windows.Forms.Padding(2);
			this.page_SpellInfo.Size = new System.Drawing.Size(812, 427);
			this.page_SpellInfo.TabIndex = 0;
			this.page_SpellInfo.Text = "SpellInfo";
			this.page_SpellInfo.UseVisualStyleBackColor = true;
			// 
			// si_ChildIDGrp
			// 
			this.si_ChildIDGrp.Controls.Add(this.si_Child5);
			this.si_ChildIDGrp.Controls.Add(this.si_Child4);
			this.si_ChildIDGrp.Controls.Add(this.si_Child3);
			this.si_ChildIDGrp.Controls.Add(this.si_Child2);
			this.si_ChildIDGrp.Controls.Add(this.si_Child1);
			this.si_ChildIDGrp.Location = new System.Drawing.Point(305, 150);
			this.si_ChildIDGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_ChildIDGrp.Name = "si_ChildIDGrp";
			this.si_ChildIDGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_ChildIDGrp.Size = new System.Drawing.Size(105, 155);
			this.si_ChildIDGrp.TabIndex = 54;
			this.si_ChildIDGrp.TabStop = false;
			this.si_ChildIDGrp.Text = "Child IDs";
			this.si_ChildIDGrp.Visible = false;
			// 
			// si_Child5
			// 
			this.si_Child5.Location = new System.Drawing.Point(5, 120);
			this.si_Child5.Margin = new System.Windows.Forms.Padding(0);
			this.si_Child5.Name = "si_Child5";
			this.si_Child5.Size = new System.Drawing.Size(95, 20);
			this.si_Child5.TabIndex = 4;
			this.si_Child5.TextChanged += new System.EventHandler(this.TextChanged_si_ChildFields);
			// 
			// si_Child4
			// 
			this.si_Child4.Location = new System.Drawing.Point(5, 95);
			this.si_Child4.Margin = new System.Windows.Forms.Padding(0);
			this.si_Child4.Name = "si_Child4";
			this.si_Child4.Size = new System.Drawing.Size(95, 20);
			this.si_Child4.TabIndex = 3;
			this.si_Child4.TextChanged += new System.EventHandler(this.TextChanged_si_ChildFields);
			// 
			// si_Child3
			// 
			this.si_Child3.Location = new System.Drawing.Point(5, 70);
			this.si_Child3.Margin = new System.Windows.Forms.Padding(0);
			this.si_Child3.Name = "si_Child3";
			this.si_Child3.Size = new System.Drawing.Size(95, 20);
			this.si_Child3.TabIndex = 2;
			this.si_Child3.TextChanged += new System.EventHandler(this.TextChanged_si_ChildFields);
			// 
			// si_Child2
			// 
			this.si_Child2.Location = new System.Drawing.Point(5, 45);
			this.si_Child2.Margin = new System.Windows.Forms.Padding(0);
			this.si_Child2.Name = "si_Child2";
			this.si_Child2.Size = new System.Drawing.Size(95, 20);
			this.si_Child2.TabIndex = 1;
			this.si_Child2.TextChanged += new System.EventHandler(this.TextChanged_si_ChildFields);
			// 
			// si_Child1
			// 
			this.si_Child1.Location = new System.Drawing.Point(5, 20);
			this.si_Child1.Margin = new System.Windows.Forms.Padding(0);
			this.si_Child1.Name = "si_Child1";
			this.si_Child1.Size = new System.Drawing.Size(95, 20);
			this.si_Child1.TabIndex = 0;
			this.si_Child1.TextChanged += new System.EventHandler(this.TextChanged_si_ChildFields);
			// 
			// si_FlagsGrp
			// 
			this.si_FlagsGrp.Controls.Add(this.si_IsMaster);
			this.si_FlagsGrp.Controls.Add(this.si_Ignore);
			this.si_FlagsGrp.Controls.Add(this.si_ItemCast);
			this.si_FlagsGrp.Controls.Add(this.si_Concentration);
			this.si_FlagsGrp.Controls.Add(this.si_LongDurBuff);
			this.si_FlagsGrp.Controls.Add(this.si_Unlimited);
			this.si_FlagsGrp.Controls.Add(this.si_MediumDurBuff);
			this.si_FlagsGrp.Controls.Add(this.si_HealOrCure);
			this.si_FlagsGrp.Controls.Add(this.si_ShortDurBuff);
			this.si_FlagsGrp.Location = new System.Drawing.Point(5, 105);
			this.si_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_FlagsGrp.Name = "si_FlagsGrp";
			this.si_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_FlagsGrp.Size = new System.Drawing.Size(300, 200);
			this.si_FlagsGrp.TabIndex = 53;
			this.si_FlagsGrp.TabStop = false;
			this.si_FlagsGrp.Text = "009E 0F00 flags";
			// 
			// si_IsMaster
			// 
			this.si_IsMaster.Location = new System.Drawing.Point(10, 15);
			this.si_IsMaster.Margin = new System.Windows.Forms.Padding(0);
			this.si_IsMaster.Name = "si_IsMaster";
			this.si_IsMaster.Size = new System.Drawing.Size(285, 20);
			this.si_IsMaster.TabIndex = 42;
			this.si_IsMaster.Text = "is Master Spell ID";
			this.si_IsMaster.UseVisualStyleBackColor = true;
			this.si_IsMaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_Ignore
			// 
			this.si_Ignore.Location = new System.Drawing.Point(10, 35);
			this.si_Ignore.Margin = new System.Windows.Forms.Padding(0);
			this.si_Ignore.Name = "si_Ignore";
			this.si_Ignore.Size = new System.Drawing.Size(285, 20);
			this.si_Ignore.TabIndex = 43;
			this.si_Ignore.Text = "ignore";
			this.si_Ignore.UseVisualStyleBackColor = true;
			this.si_Ignore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_ItemCast
			// 
			this.si_ItemCast.Location = new System.Drawing.Point(10, 175);
			this.si_ItemCast.Margin = new System.Windows.Forms.Padding(0);
			this.si_ItemCast.Name = "si_ItemCast";
			this.si_ItemCast.Size = new System.Drawing.Size(285, 20);
			this.si_ItemCast.TabIndex = 50;
			this.si_ItemCast.Text = "is cast by an Item";
			this.si_ItemCast.UseVisualStyleBackColor = true;
			this.si_ItemCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_Concentration
			// 
			this.si_Concentration.Location = new System.Drawing.Point(10, 55);
			this.si_Concentration.Margin = new System.Windows.Forms.Padding(0);
			this.si_Concentration.Name = "si_Concentration";
			this.si_Concentration.Size = new System.Drawing.Size(285, 20);
			this.si_Concentration.TabIndex = 44;
			this.si_Concentration.Text = "does a Concentration check";
			this.si_Concentration.UseVisualStyleBackColor = true;
			this.si_Concentration.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_LongDurBuff
			// 
			this.si_LongDurBuff.Location = new System.Drawing.Point(10, 155);
			this.si_LongDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_LongDurBuff.Name = "si_LongDurBuff";
			this.si_LongDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_LongDurBuff.TabIndex = 49;
			this.si_LongDurBuff.Text = "long Duration buff";
			this.si_LongDurBuff.UseVisualStyleBackColor = true;
			this.si_LongDurBuff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_Unlimited
			// 
			this.si_Unlimited.Location = new System.Drawing.Point(10, 75);
			this.si_Unlimited.Margin = new System.Windows.Forms.Padding(0);
			this.si_Unlimited.Name = "si_Unlimited";
			this.si_Unlimited.Size = new System.Drawing.Size(285, 20);
			this.si_Unlimited.TabIndex = 45;
			this.si_Unlimited.Text = "has Unlimited casts";
			this.si_Unlimited.UseVisualStyleBackColor = true;
			this.si_Unlimited.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_MediumDurBuff
			// 
			this.si_MediumDurBuff.Location = new System.Drawing.Point(10, 135);
			this.si_MediumDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_MediumDurBuff.Name = "si_MediumDurBuff";
			this.si_MediumDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_MediumDurBuff.TabIndex = 48;
			this.si_MediumDurBuff.Text = "medium Duration buff";
			this.si_MediumDurBuff.UseVisualStyleBackColor = true;
			this.si_MediumDurBuff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_HealOrCure
			// 
			this.si_HealOrCure.Location = new System.Drawing.Point(10, 95);
			this.si_HealOrCure.Margin = new System.Windows.Forms.Padding(0);
			this.si_HealOrCure.Name = "si_HealOrCure";
			this.si_HealOrCure.Size = new System.Drawing.Size(285, 20);
			this.si_HealOrCure.TabIndex = 46;
			this.si_HealOrCure.Text = "is Heal or Cure";
			this.si_HealOrCure.UseVisualStyleBackColor = true;
			this.si_HealOrCure.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_ShortDurBuff
			// 
			this.si_ShortDurBuff.Location = new System.Drawing.Point(10, 115);
			this.si_ShortDurBuff.Margin = new System.Windows.Forms.Padding(0);
			this.si_ShortDurBuff.Name = "si_ShortDurBuff";
			this.si_ShortDurBuff.Size = new System.Drawing.Size(285, 20);
			this.si_ShortDurBuff.TabIndex = 47;
			this.si_ShortDurBuff.Text = "short Duration buff";
			this.si_ShortDurBuff.UseVisualStyleBackColor = true;
			this.si_ShortDurBuff.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_si_Flags);
			// 
			// si_SpelllevelGrp
			// 
			this.si_SpelllevelGrp.Controls.Add(this.cbo_si_Spelllevel);
			this.si_SpelllevelGrp.Location = new System.Drawing.Point(305, 105);
			this.si_SpelllevelGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_SpelllevelGrp.Name = "si_SpelllevelGrp";
			this.si_SpelllevelGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_SpelllevelGrp.Size = new System.Drawing.Size(165, 45);
			this.si_SpelllevelGrp.TabIndex = 52;
			this.si_SpelllevelGrp.TabStop = false;
			this.si_SpelllevelGrp.Text = "0001 E000 spelllevel";
			// 
			// cbo_si_Spelllevel
			// 
			this.cbo_si_Spelllevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_si_Spelllevel.FormattingEnabled = true;
			this.cbo_si_Spelllevel.Location = new System.Drawing.Point(5, 15);
			this.cbo_si_Spelllevel.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_si_Spelllevel.Name = "cbo_si_Spelllevel";
			this.cbo_si_Spelllevel.Size = new System.Drawing.Size(155, 22);
			this.cbo_si_Spelllevel.TabIndex = 51;
			this.cbo_si_Spelllevel.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_si_cbo_Spelllevel);
			// 
			// si_SpelltypeGrp
			// 
			this.si_SpelltypeGrp.Controls.Add(this.si_hostile);
			this.si_SpelltypeGrp.Controls.Add(this.cbo_si_Spelltype);
			this.si_SpelltypeGrp.Location = new System.Drawing.Point(5, 60);
			this.si_SpelltypeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.si_SpelltypeGrp.Name = "si_SpelltypeGrp";
			this.si_SpelltypeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.si_SpelltypeGrp.Size = new System.Drawing.Size(405, 45);
			this.si_SpelltypeGrp.TabIndex = 41;
			this.si_SpelltypeGrp.TabStop = false;
			this.si_SpelltypeGrp.Text = "0000 00FF spelltype";
			// 
			// si_hostile
			// 
			this.si_hostile.Location = new System.Drawing.Point(305, 15);
			this.si_hostile.Margin = new System.Windows.Forms.Padding(0);
			this.si_hostile.Name = "si_hostile";
			this.si_hostile.Size = new System.Drawing.Size(95, 25);
			this.si_hostile.TabIndex = 54;
			this.si_hostile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbo_si_Spelltype
			// 
			this.cbo_si_Spelltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_si_Spelltype.FormattingEnabled = true;
			this.cbo_si_Spelltype.Location = new System.Drawing.Point(5, 15);
			this.cbo_si_Spelltype.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_si_Spelltype.Name = "cbo_si_Spelltype";
			this.cbo_si_Spelltype.Size = new System.Drawing.Size(290, 22);
			this.cbo_si_Spelltype.TabIndex = 0;
			this.cbo_si_Spelltype.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_si_cbo_Spelltype);
			// 
			// si_bin
			// 
			this.si_bin.Location = new System.Drawing.Point(395, 35);
			this.si_bin.Margin = new System.Windows.Forms.Padding(0);
			this.si_bin.Name = "si_bin";
			this.si_bin.Size = new System.Drawing.Size(45, 15);
			this.si_bin.TabIndex = 40;
			this.si_bin.Text = "- bin";
			this.si_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_hex
			// 
			this.si_hex.Location = new System.Drawing.Point(395, 15);
			this.si_hex.Margin = new System.Windows.Forms.Padding(0);
			this.si_hex.Name = "si_hex";
			this.si_hex.Size = new System.Drawing.Size(45, 15);
			this.si_hex.TabIndex = 39;
			this.si_hex.Text = "- hex";
			this.si_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// si_Clear
			// 
			this.si_Clear.Location = new System.Drawing.Point(450, 5);
			this.si_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.si_Clear.Name = "si_Clear";
			this.si_Clear.Size = new System.Drawing.Size(65, 50);
			this.si_Clear.TabIndex = 38;
			this.si_Clear.Text = "zero\r\nall\r\nbits";
			this.si_Clear.UseVisualStyleBackColor = true;
			this.si_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.SpellInfo_bin.TabIndex = 36;
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
			this.SpellInfo_hex.TabIndex = 37;
			// 
			// SpellInfo_text
			// 
			this.SpellInfo_text.Location = new System.Drawing.Point(5, 35);
			this.SpellInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_text.Name = "SpellInfo_text";
			this.SpellInfo_text.Size = new System.Drawing.Size(100, 20);
			this.SpellInfo_text.TabIndex = 14;
			this.SpellInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SpellInfo_text.TextChanged += new System.EventHandler(this.TextChanged_si);
			// 
			// SpellInfo_reset
			// 
			this.SpellInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.SpellInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SpellInfo_reset.Name = "SpellInfo_reset";
			this.SpellInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.SpellInfo_reset.TabIndex = 0;
			this.toolTip1.SetToolTip(this.SpellInfo_reset, "reset");
			this.SpellInfo_reset.UseVisualStyleBackColor = true;
			this.SpellInfo_reset.Click += new System.EventHandler(this.Click_si_reset);
			// 
			// page_TargetInfo
			// 
			this.page_TargetInfo.Controls.Add(this.ti_RadiusGrp);
			this.page_TargetInfo.Controls.Add(this.ti_RangeGrp);
			this.page_TargetInfo.Controls.Add(this.ti_ShapeGrp);
			this.page_TargetInfo.Controls.Add(this.ti_FlagsGrp);
			this.page_TargetInfo.Controls.Add(this.ti_bin);
			this.page_TargetInfo.Controls.Add(this.ti_hex);
			this.page_TargetInfo.Controls.Add(this.ti_Clear);
			this.page_TargetInfo.Controls.Add(this.TargetInfo_bin);
			this.page_TargetInfo.Controls.Add(this.TargetInfo_hex);
			this.page_TargetInfo.Controls.Add(this.TargetInfo_text);
			this.page_TargetInfo.Controls.Add(this.TargetInfo_reset);
			this.page_TargetInfo.Location = new System.Drawing.Point(4, 23);
			this.page_TargetInfo.Margin = new System.Windows.Forms.Padding(2);
			this.page_TargetInfo.Name = "page_TargetInfo";
			this.page_TargetInfo.Padding = new System.Windows.Forms.Padding(2);
			this.page_TargetInfo.Size = new System.Drawing.Size(812, 428);
			this.page_TargetInfo.TabIndex = 1;
			this.page_TargetInfo.Text = "TargetInfo";
			this.page_TargetInfo.UseVisualStyleBackColor = true;
			// 
			// ti_RadiusGrp
			// 
			this.ti_RadiusGrp.Controls.Add(this.ti_Radius);
			this.ti_RadiusGrp.Location = new System.Drawing.Point(350, 150);
			this.ti_RadiusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_RadiusGrp.Name = "ti_RadiusGrp";
			this.ti_RadiusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_RadiusGrp.Size = new System.Drawing.Size(225, 40);
			this.ti_RadiusGrp.TabIndex = 49;
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
			this.ti_Radius.TextChanged += new System.EventHandler(this.TextChanged_ti_Radius);
			// 
			// ti_RangeGrp
			// 
			this.ti_RangeGrp.Controls.Add(this.cbo_ti_Range);
			this.ti_RangeGrp.Location = new System.Drawing.Point(350, 105);
			this.ti_RangeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_RangeGrp.Name = "ti_RangeGrp";
			this.ti_RangeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_RangeGrp.Size = new System.Drawing.Size(225, 45);
			this.ti_RangeGrp.TabIndex = 48;
			this.ti_RangeGrp.TabStop = false;
			this.ti_RangeGrp.Text = "0000 0038 range";
			// 
			// cbo_ti_Range
			// 
			this.cbo_ti_Range.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_ti_Range.FormattingEnabled = true;
			this.cbo_ti_Range.Location = new System.Drawing.Point(5, 15);
			this.cbo_ti_Range.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_ti_Range.Name = "cbo_ti_Range";
			this.cbo_ti_Range.Size = new System.Drawing.Size(215, 22);
			this.cbo_ti_Range.TabIndex = 1;
			this.cbo_ti_Range.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_ti_cbo_Range);
			// 
			// ti_ShapeGrp
			// 
			this.ti_ShapeGrp.Controls.Add(this.cbo_ti_Shape);
			this.ti_ShapeGrp.Location = new System.Drawing.Point(350, 60);
			this.ti_ShapeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_ShapeGrp.Name = "ti_ShapeGrp";
			this.ti_ShapeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_ShapeGrp.Size = new System.Drawing.Size(225, 45);
			this.ti_ShapeGrp.TabIndex = 47;
			this.ti_ShapeGrp.TabStop = false;
			this.ti_ShapeGrp.Text = "0000 0007 shape";
			// 
			// cbo_ti_Shape
			// 
			this.cbo_ti_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_ti_Shape.FormattingEnabled = true;
			this.cbo_ti_Shape.Location = new System.Drawing.Point(5, 15);
			this.cbo_ti_Shape.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_ti_Shape.Name = "cbo_ti_Shape";
			this.cbo_ti_Shape.Size = new System.Drawing.Size(215, 22);
			this.cbo_ti_Shape.TabIndex = 0;
			this.cbo_ti_Shape.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_ti_cbo_Shape);
			// 
			// ti_FlagsGrp
			// 
			this.ti_FlagsGrp.Controls.Add(this.ti_Regular);
			this.ti_FlagsGrp.Controls.Add(this.ti_Necromancy);
			this.ti_FlagsGrp.Controls.Add(this.ti_ScaledEffect);
			this.ti_FlagsGrp.Controls.Add(this.ti_PersistentAoe);
			this.ti_FlagsGrp.Controls.Add(this.ti_RangedSelectedArea);
			this.ti_FlagsGrp.Controls.Add(this.ti_SeenRequired);
			this.ti_FlagsGrp.Controls.Add(this.ti_SecondaryHalfDamage);
			this.ti_FlagsGrp.Controls.Add(this.ti_SecondaryTargets);
			this.ti_FlagsGrp.Controls.Add(this.ti_MissileTargets);
			this.ti_FlagsGrp.Controls.Add(this.ti_CheckCount);
			this.ti_FlagsGrp.Controls.Add(this.ti_ShapeLoop);
			this.ti_FlagsGrp.Location = new System.Drawing.Point(5, 60);
			this.ti_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.ti_FlagsGrp.Name = "ti_FlagsGrp";
			this.ti_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.ti_FlagsGrp.Size = new System.Drawing.Size(345, 240);
			this.ti_FlagsGrp.TabIndex = 46;
			this.ti_FlagsGrp.TabStop = false;
			this.ti_FlagsGrp.Text = "07FF 0000 flags";
			// 
			// ti_Regular
			// 
			this.ti_Regular.Location = new System.Drawing.Point(10, 215);
			this.ti_Regular.Name = "ti_Regular";
			this.ti_Regular.Size = new System.Drawing.Size(330, 20);
			this.ti_Regular.TabIndex = 10;
			this.ti_Regular.Text = "regular";
			this.ti_Regular.UseVisualStyleBackColor = true;
			this.ti_Regular.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_Necromancy
			// 
			this.ti_Necromancy.Location = new System.Drawing.Point(10, 195);
			this.ti_Necromancy.Name = "ti_Necromancy";
			this.ti_Necromancy.Size = new System.Drawing.Size(330, 20);
			this.ti_Necromancy.TabIndex = 9;
			this.ti_Necromancy.Text = "check immunity to necromancy";
			this.ti_Necromancy.UseVisualStyleBackColor = true;
			this.ti_Necromancy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_ScaledEffect
			// 
			this.ti_ScaledEffect.Location = new System.Drawing.Point(10, 175);
			this.ti_ScaledEffect.Name = "ti_ScaledEffect";
			this.ti_ScaledEffect.Size = new System.Drawing.Size(330, 20);
			this.ti_ScaledEffect.TabIndex = 8;
			this.ti_ScaledEffect.Text = "scale effectweight by DamageInfo buff power";
			this.toolTip1.SetToolTip(this.ti_ScaledEffect, "Forces an attack spell to use the beneficial bit-group on the DamageInfo page. Us" +
		"ed by some attack spells that decrease attributes (and bardic Curse Song)");
			this.ti_ScaledEffect.UseVisualStyleBackColor = true;
			this.ti_ScaledEffect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_PersistentAoe
			// 
			this.ti_PersistentAoe.Location = new System.Drawing.Point(10, 155);
			this.ti_PersistentAoe.Name = "ti_PersistentAoe";
			this.ti_PersistentAoe.Size = new System.Drawing.Size(330, 20);
			this.ti_PersistentAoe.TabIndex = 7;
			this.ti_PersistentAoe.Text = "persistent aoe";
			this.ti_PersistentAoe.UseVisualStyleBackColor = true;
			this.ti_PersistentAoe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_RangedSelectedArea
			// 
			this.ti_RangedSelectedArea.Location = new System.Drawing.Point(10, 135);
			this.ti_RangedSelectedArea.Name = "ti_RangedSelectedArea";
			this.ti_RangedSelectedArea.Size = new System.Drawing.Size(330, 20);
			this.ti_RangedSelectedArea.TabIndex = 6;
			this.ti_RangedSelectedArea.Text = "ranged selected area";
			this.ti_RangedSelectedArea.UseVisualStyleBackColor = true;
			this.ti_RangedSelectedArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_SeenRequired
			// 
			this.ti_SeenRequired.Location = new System.Drawing.Point(10, 115);
			this.ti_SeenRequired.Name = "ti_SeenRequired";
			this.ti_SeenRequired.Size = new System.Drawing.Size(330, 20);
			this.ti_SeenRequired.TabIndex = 5;
			this.ti_SeenRequired.Text = "perception seen required";
			this.ti_SeenRequired.UseVisualStyleBackColor = true;
			this.ti_SeenRequired.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_SecondaryHalfDamage
			// 
			this.ti_SecondaryHalfDamage.Location = new System.Drawing.Point(10, 95);
			this.ti_SecondaryHalfDamage.Name = "ti_SecondaryHalfDamage";
			this.ti_SecondaryHalfDamage.Size = new System.Drawing.Size(330, 20);
			this.ti_SecondaryHalfDamage.TabIndex = 4;
			this.ti_SecondaryHalfDamage.Text = "secondary targets take half damage";
			this.ti_SecondaryHalfDamage.UseVisualStyleBackColor = true;
			this.ti_SecondaryHalfDamage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_SecondaryTargets
			// 
			this.ti_SecondaryTargets.Location = new System.Drawing.Point(10, 75);
			this.ti_SecondaryTargets.Name = "ti_SecondaryTargets";
			this.ti_SecondaryTargets.Size = new System.Drawing.Size(330, 20);
			this.ti_SecondaryTargets.TabIndex = 3;
			this.ti_SecondaryTargets.Text = "secondary targets";
			this.ti_SecondaryTargets.UseVisualStyleBackColor = true;
			this.ti_SecondaryTargets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_MissileTargets
			// 
			this.ti_MissileTargets.Location = new System.Drawing.Point(10, 55);
			this.ti_MissileTargets.Name = "ti_MissileTargets";
			this.ti_MissileTargets.Size = new System.Drawing.Size(330, 20);
			this.ti_MissileTargets.TabIndex = 2;
			this.ti_MissileTargets.Text = "missile targets";
			this.ti_MissileTargets.UseVisualStyleBackColor = true;
			this.ti_MissileTargets.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_CheckCount
			// 
			this.ti_CheckCount.Location = new System.Drawing.Point(10, 35);
			this.ti_CheckCount.Name = "ti_CheckCount";
			this.ti_CheckCount.Size = new System.Drawing.Size(330, 20);
			this.ti_CheckCount.TabIndex = 1;
			this.ti_CheckCount.Text = "check count";
			this.ti_CheckCount.UseVisualStyleBackColor = true;
			this.ti_CheckCount.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_ShapeLoop
			// 
			this.ti_ShapeLoop.Location = new System.Drawing.Point(10, 15);
			this.ti_ShapeLoop.Name = "ti_ShapeLoop";
			this.ti_ShapeLoop.Size = new System.Drawing.Size(330, 20);
			this.ti_ShapeLoop.TabIndex = 0;
			this.ti_ShapeLoop.Text = "shape loop";
			this.ti_ShapeLoop.UseVisualStyleBackColor = true;
			this.ti_ShapeLoop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_ti_Flags);
			// 
			// ti_bin
			// 
			this.ti_bin.Location = new System.Drawing.Point(395, 35);
			this.ti_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ti_bin.Name = "ti_bin";
			this.ti_bin.Size = new System.Drawing.Size(45, 15);
			this.ti_bin.TabIndex = 45;
			this.ti_bin.Text = "- bin";
			this.ti_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ti_hex
			// 
			this.ti_hex.Location = new System.Drawing.Point(395, 15);
			this.ti_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ti_hex.Name = "ti_hex";
			this.ti_hex.Size = new System.Drawing.Size(45, 15);
			this.ti_hex.TabIndex = 44;
			this.ti_hex.Text = "- hex";
			this.ti_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ti_Clear
			// 
			this.ti_Clear.Location = new System.Drawing.Point(450, 5);
			this.ti_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.ti_Clear.Name = "ti_Clear";
			this.ti_Clear.Size = new System.Drawing.Size(65, 50);
			this.ti_Clear.TabIndex = 43;
			this.ti_Clear.Text = "zero\r\nall\r\nbits";
			this.ti_Clear.UseVisualStyleBackColor = true;
			this.ti_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.TargetInfo_bin.TabIndex = 41;
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
			this.TargetInfo_hex.TabIndex = 42;
			// 
			// TargetInfo_text
			// 
			this.TargetInfo_text.Location = new System.Drawing.Point(5, 35);
			this.TargetInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_text.Name = "TargetInfo_text";
			this.TargetInfo_text.Size = new System.Drawing.Size(100, 20);
			this.TargetInfo_text.TabIndex = 15;
			this.TargetInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.TargetInfo_text.TextChanged += new System.EventHandler(this.TextChanged_ti);
			// 
			// TargetInfo_reset
			// 
			this.TargetInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.TargetInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.TargetInfo_reset.Name = "TargetInfo_reset";
			this.TargetInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.TargetInfo_reset.TabIndex = 1;
			this.toolTip1.SetToolTip(this.TargetInfo_reset, "reset");
			this.TargetInfo_reset.UseVisualStyleBackColor = true;
			this.TargetInfo_reset.Click += new System.EventHandler(this.Click_ti_reset);
			// 
			// page_EffectWeight
			// 
			this.page_EffectWeight.Controls.Add(this.ew_Clear);
			this.page_EffectWeight.Controls.Add(this.f2);
			this.page_EffectWeight.Controls.Add(this.f1);
			this.page_EffectWeight.Controls.Add(this.EffectWeight_reset);
			this.page_EffectWeight.Controls.Add(this.EffectWeight_text);
			this.page_EffectWeight.Location = new System.Drawing.Point(4, 23);
			this.page_EffectWeight.Margin = new System.Windows.Forms.Padding(2);
			this.page_EffectWeight.Name = "page_EffectWeight";
			this.page_EffectWeight.Padding = new System.Windows.Forms.Padding(2);
			this.page_EffectWeight.Size = new System.Drawing.Size(812, 428);
			this.page_EffectWeight.TabIndex = 2;
			this.page_EffectWeight.Text = "EffectWeight";
			this.page_EffectWeight.UseVisualStyleBackColor = true;
			// 
			// ew_Clear
			// 
			this.ew_Clear.Location = new System.Drawing.Point(135, 5);
			this.ew_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.ew_Clear.Name = "ew_Clear";
			this.ew_Clear.Size = new System.Drawing.Size(65, 50);
			this.ew_Clear.TabIndex = 44;
			this.ew_Clear.Text = "zero";
			this.ew_Clear.UseVisualStyleBackColor = true;
			this.ew_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.EffectWeight_reset.TabIndex = 2;
			this.toolTip1.SetToolTip(this.EffectWeight_reset, "reset");
			this.EffectWeight_reset.UseVisualStyleBackColor = true;
			this.EffectWeight_reset.Click += new System.EventHandler(this.Click_ew_reset);
			// 
			// EffectWeight_text
			// 
			this.EffectWeight_text.Location = new System.Drawing.Point(5, 35);
			this.EffectWeight_text.Margin = new System.Windows.Forms.Padding(0);
			this.EffectWeight_text.Name = "EffectWeight_text";
			this.EffectWeight_text.Size = new System.Drawing.Size(100, 20);
			this.EffectWeight_text.TabIndex = 0;
			this.EffectWeight_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.EffectWeight_text.TextChanged += new System.EventHandler(this.TextChanged_ew);
			// 
			// page_EffectTypes
			// 
			this.page_EffectTypes.Controls.Add(this.et_DetEffectsGrp);
			this.page_EffectTypes.Controls.Add(this.et_BenEffectsGrp);
			this.page_EffectTypes.Controls.Add(this.et_bin);
			this.page_EffectTypes.Controls.Add(this.et_hex);
			this.page_EffectTypes.Controls.Add(this.et_Clear);
			this.page_EffectTypes.Controls.Add(this.EffectTypes_bin);
			this.page_EffectTypes.Controls.Add(this.EffectTypes_hex);
			this.page_EffectTypes.Controls.Add(this.EffectTypes_text);
			this.page_EffectTypes.Controls.Add(this.EffectTypes_reset);
			this.page_EffectTypes.Location = new System.Drawing.Point(4, 23);
			this.page_EffectTypes.Margin = new System.Windows.Forms.Padding(2);
			this.page_EffectTypes.Name = "page_EffectTypes";
			this.page_EffectTypes.Padding = new System.Windows.Forms.Padding(2);
			this.page_EffectTypes.Size = new System.Drawing.Size(812, 428);
			this.page_EffectTypes.TabIndex = 3;
			this.page_EffectTypes.Text = "EffectTypes";
			this.page_EffectTypes.UseVisualStyleBackColor = true;
			// 
			// et_DetEffectsGrp
			// 
			this.et_DetEffectsGrp.Controls.Add(this.et_CutsceneParalyze);
			this.et_DetEffectsGrp.Controls.Add(this.et_Mesmerize);
			this.et_DetEffectsGrp.Controls.Add(this.et_Dying);
			this.et_DetEffectsGrp.Controls.Add(this.et_Knockdown);
			this.et_DetEffectsGrp.Controls.Add(this.et_SavingThrowDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_AcDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_NegativeLevel);
			this.et_DetEffectsGrp.Controls.Add(this.et_Death);
			this.et_DetEffectsGrp.Controls.Add(this.et_SpeedDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Petrify);
			this.et_DetEffectsGrp.Controls.Add(this.et_Stun);
			this.et_DetEffectsGrp.Controls.Add(this.et_SkillDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_AttackDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_DamageDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_AbilityDecrease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Slow);
			this.et_DetEffectsGrp.Controls.Add(this.et_Silence);
			this.et_DetEffectsGrp.Controls.Add(this.et_Disease);
			this.et_DetEffectsGrp.Controls.Add(this.et_Poison);
			this.et_DetEffectsGrp.Controls.Add(this.et_Daze);
			this.et_DetEffectsGrp.Controls.Add(this.et_Dominate);
			this.et_DetEffectsGrp.Controls.Add(this.et_Frighten);
			this.et_DetEffectsGrp.Controls.Add(this.et_Confuse);
			this.et_DetEffectsGrp.Controls.Add(this.et_Charm);
			this.et_DetEffectsGrp.Controls.Add(this.et_Sleep);
			this.et_DetEffectsGrp.Controls.Add(this.et_Curse);
			this.et_DetEffectsGrp.Controls.Add(this.et_Blindness);
			this.et_DetEffectsGrp.Controls.Add(this.et_Deafness);
			this.et_DetEffectsGrp.Controls.Add(this.et_Paralyze);
			this.et_DetEffectsGrp.Controls.Add(this.et_Entangle);
			this.et_DetEffectsGrp.Location = new System.Drawing.Point(5, 60);
			this.et_DetEffectsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.et_DetEffectsGrp.Name = "et_DetEffectsGrp";
			this.et_DetEffectsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.et_DetEffectsGrp.Size = new System.Drawing.Size(385, 320);
			this.et_DetEffectsGrp.TabIndex = 52;
			this.et_DetEffectsGrp.TabStop = false;
			this.et_DetEffectsGrp.Text = "FFF7 FFFF detrimental";
			// 
			// et_CutsceneParalyze
			// 
			this.et_CutsceneParalyze.Location = new System.Drawing.Point(200, 295);
			this.et_CutsceneParalyze.Margin = new System.Windows.Forms.Padding(0);
			this.et_CutsceneParalyze.Name = "et_CutsceneParalyze";
			this.et_CutsceneParalyze.Size = new System.Drawing.Size(180, 20);
			this.et_CutsceneParalyze.TabIndex = 29;
			this.et_CutsceneParalyze.Text = "cutscene paralyze";
			this.et_CutsceneParalyze.UseVisualStyleBackColor = true;
			this.et_CutsceneParalyze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Mesmerize
			// 
			this.et_Mesmerize.Location = new System.Drawing.Point(200, 275);
			this.et_Mesmerize.Margin = new System.Windows.Forms.Padding(0);
			this.et_Mesmerize.Name = "et_Mesmerize";
			this.et_Mesmerize.Size = new System.Drawing.Size(180, 20);
			this.et_Mesmerize.TabIndex = 28;
			this.et_Mesmerize.Text = "mesmerize";
			this.et_Mesmerize.UseVisualStyleBackColor = true;
			this.et_Mesmerize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Dying
			// 
			this.et_Dying.Location = new System.Drawing.Point(200, 255);
			this.et_Dying.Margin = new System.Windows.Forms.Padding(0);
			this.et_Dying.Name = "et_Dying";
			this.et_Dying.Size = new System.Drawing.Size(180, 20);
			this.et_Dying.TabIndex = 27;
			this.et_Dying.Text = "dying";
			this.et_Dying.UseVisualStyleBackColor = true;
			this.et_Dying.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Knockdown
			// 
			this.et_Knockdown.Location = new System.Drawing.Point(200, 235);
			this.et_Knockdown.Margin = new System.Windows.Forms.Padding(0);
			this.et_Knockdown.Name = "et_Knockdown";
			this.et_Knockdown.Size = new System.Drawing.Size(180, 20);
			this.et_Knockdown.TabIndex = 26;
			this.et_Knockdown.Text = "knockdown";
			this.et_Knockdown.UseVisualStyleBackColor = true;
			this.et_Knockdown.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_SavingThrowDecrease
			// 
			this.et_SavingThrowDecrease.Location = new System.Drawing.Point(200, 215);
			this.et_SavingThrowDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SavingThrowDecrease.Name = "et_SavingThrowDecrease";
			this.et_SavingThrowDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SavingThrowDecrease.TabIndex = 25;
			this.et_SavingThrowDecrease.Text = "saving throw decrease";
			this.et_SavingThrowDecrease.UseVisualStyleBackColor = true;
			this.et_SavingThrowDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_AcDecrease
			// 
			this.et_AcDecrease.Location = new System.Drawing.Point(200, 195);
			this.et_AcDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AcDecrease.Name = "et_AcDecrease";
			this.et_AcDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AcDecrease.TabIndex = 24;
			this.et_AcDecrease.Text = "ac decrease";
			this.et_AcDecrease.UseVisualStyleBackColor = true;
			this.et_AcDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_NegativeLevel
			// 
			this.et_NegativeLevel.Location = new System.Drawing.Point(200, 175);
			this.et_NegativeLevel.Margin = new System.Windows.Forms.Padding(0);
			this.et_NegativeLevel.Name = "et_NegativeLevel";
			this.et_NegativeLevel.Size = new System.Drawing.Size(180, 20);
			this.et_NegativeLevel.TabIndex = 23;
			this.et_NegativeLevel.Text = "negative level";
			this.et_NegativeLevel.UseVisualStyleBackColor = true;
			this.et_NegativeLevel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Death
			// 
			this.et_Death.Location = new System.Drawing.Point(200, 155);
			this.et_Death.Margin = new System.Windows.Forms.Padding(0);
			this.et_Death.Name = "et_Death";
			this.et_Death.Size = new System.Drawing.Size(180, 20);
			this.et_Death.TabIndex = 22;
			this.et_Death.Text = "death";
			this.et_Death.UseVisualStyleBackColor = true;
			this.et_Death.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_SpeedDecrease
			// 
			this.et_SpeedDecrease.Location = new System.Drawing.Point(200, 135);
			this.et_SpeedDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpeedDecrease.Name = "et_SpeedDecrease";
			this.et_SpeedDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SpeedDecrease.TabIndex = 21;
			this.et_SpeedDecrease.Text = "speed decrease";
			this.et_SpeedDecrease.UseVisualStyleBackColor = true;
			this.et_SpeedDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Petrify
			// 
			this.et_Petrify.Location = new System.Drawing.Point(200, 115);
			this.et_Petrify.Margin = new System.Windows.Forms.Padding(0);
			this.et_Petrify.Name = "et_Petrify";
			this.et_Petrify.Size = new System.Drawing.Size(180, 20);
			this.et_Petrify.TabIndex = 20;
			this.et_Petrify.Text = "petrify";
			this.et_Petrify.UseVisualStyleBackColor = true;
			this.et_Petrify.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Stun
			// 
			this.et_Stun.Location = new System.Drawing.Point(200, 95);
			this.et_Stun.Margin = new System.Windows.Forms.Padding(0);
			this.et_Stun.Name = "et_Stun";
			this.et_Stun.Size = new System.Drawing.Size(180, 20);
			this.et_Stun.TabIndex = 19;
			this.et_Stun.Text = "stun";
			this.et_Stun.UseVisualStyleBackColor = true;
			this.et_Stun.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_SkillDecrease
			// 
			this.et_SkillDecrease.Location = new System.Drawing.Point(200, 75);
			this.et_SkillDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SkillDecrease.Name = "et_SkillDecrease";
			this.et_SkillDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_SkillDecrease.TabIndex = 18;
			this.et_SkillDecrease.Text = "skill decrease";
			this.et_SkillDecrease.UseVisualStyleBackColor = true;
			this.et_SkillDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_AttackDecrease
			// 
			this.et_AttackDecrease.Location = new System.Drawing.Point(200, 55);
			this.et_AttackDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AttackDecrease.Name = "et_AttackDecrease";
			this.et_AttackDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AttackDecrease.TabIndex = 17;
			this.et_AttackDecrease.Text = "attack decrease";
			this.et_AttackDecrease.UseVisualStyleBackColor = true;
			this.et_AttackDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_DamageDecrease
			// 
			this.et_DamageDecrease.Location = new System.Drawing.Point(200, 35);
			this.et_DamageDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageDecrease.Name = "et_DamageDecrease";
			this.et_DamageDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_DamageDecrease.TabIndex = 16;
			this.et_DamageDecrease.Text = "damage decrease";
			this.et_DamageDecrease.UseVisualStyleBackColor = true;
			this.et_DamageDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_AbilityDecrease
			// 
			this.et_AbilityDecrease.Location = new System.Drawing.Point(200, 15);
			this.et_AbilityDecrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbilityDecrease.Name = "et_AbilityDecrease";
			this.et_AbilityDecrease.Size = new System.Drawing.Size(180, 20);
			this.et_AbilityDecrease.TabIndex = 15;
			this.et_AbilityDecrease.Text = "ability decrease";
			this.et_AbilityDecrease.UseVisualStyleBackColor = true;
			this.et_AbilityDecrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Slow
			// 
			this.et_Slow.Location = new System.Drawing.Point(10, 295);
			this.et_Slow.Margin = new System.Windows.Forms.Padding(0);
			this.et_Slow.Name = "et_Slow";
			this.et_Slow.Size = new System.Drawing.Size(180, 20);
			this.et_Slow.TabIndex = 14;
			this.et_Slow.Text = "slow";
			this.et_Slow.UseVisualStyleBackColor = true;
			this.et_Slow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Silence
			// 
			this.et_Silence.Location = new System.Drawing.Point(10, 275);
			this.et_Silence.Margin = new System.Windows.Forms.Padding(0);
			this.et_Silence.Name = "et_Silence";
			this.et_Silence.Size = new System.Drawing.Size(180, 20);
			this.et_Silence.TabIndex = 13;
			this.et_Silence.Text = "silence";
			this.et_Silence.UseVisualStyleBackColor = true;
			this.et_Silence.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
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
			this.et_Disease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Poison
			// 
			this.et_Poison.Location = new System.Drawing.Point(10, 235);
			this.et_Poison.Margin = new System.Windows.Forms.Padding(0);
			this.et_Poison.Name = "et_Poison";
			this.et_Poison.Size = new System.Drawing.Size(180, 20);
			this.et_Poison.TabIndex = 11;
			this.et_Poison.Text = "poison";
			this.et_Poison.UseVisualStyleBackColor = true;
			this.et_Poison.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Daze
			// 
			this.et_Daze.Location = new System.Drawing.Point(10, 215);
			this.et_Daze.Margin = new System.Windows.Forms.Padding(0);
			this.et_Daze.Name = "et_Daze";
			this.et_Daze.Size = new System.Drawing.Size(180, 20);
			this.et_Daze.TabIndex = 10;
			this.et_Daze.Text = "daze";
			this.et_Daze.UseVisualStyleBackColor = true;
			this.et_Daze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Dominate
			// 
			this.et_Dominate.Location = new System.Drawing.Point(10, 195);
			this.et_Dominate.Margin = new System.Windows.Forms.Padding(0);
			this.et_Dominate.Name = "et_Dominate";
			this.et_Dominate.Size = new System.Drawing.Size(180, 20);
			this.et_Dominate.TabIndex = 9;
			this.et_Dominate.Text = "dominate";
			this.et_Dominate.UseVisualStyleBackColor = true;
			this.et_Dominate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Frighten
			// 
			this.et_Frighten.Location = new System.Drawing.Point(10, 175);
			this.et_Frighten.Margin = new System.Windows.Forms.Padding(0);
			this.et_Frighten.Name = "et_Frighten";
			this.et_Frighten.Size = new System.Drawing.Size(180, 20);
			this.et_Frighten.TabIndex = 8;
			this.et_Frighten.Text = "frighten";
			this.et_Frighten.UseVisualStyleBackColor = true;
			this.et_Frighten.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Confuse
			// 
			this.et_Confuse.Location = new System.Drawing.Point(10, 155);
			this.et_Confuse.Margin = new System.Windows.Forms.Padding(0);
			this.et_Confuse.Name = "et_Confuse";
			this.et_Confuse.Size = new System.Drawing.Size(180, 20);
			this.et_Confuse.TabIndex = 7;
			this.et_Confuse.Text = "confuse";
			this.et_Confuse.UseVisualStyleBackColor = true;
			this.et_Confuse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Charm
			// 
			this.et_Charm.Location = new System.Drawing.Point(10, 135);
			this.et_Charm.Margin = new System.Windows.Forms.Padding(0);
			this.et_Charm.Name = "et_Charm";
			this.et_Charm.Size = new System.Drawing.Size(180, 20);
			this.et_Charm.TabIndex = 6;
			this.et_Charm.Text = "charm";
			this.et_Charm.UseVisualStyleBackColor = true;
			this.et_Charm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Sleep
			// 
			this.et_Sleep.Location = new System.Drawing.Point(10, 115);
			this.et_Sleep.Margin = new System.Windows.Forms.Padding(0);
			this.et_Sleep.Name = "et_Sleep";
			this.et_Sleep.Size = new System.Drawing.Size(180, 20);
			this.et_Sleep.TabIndex = 5;
			this.et_Sleep.Text = "sleep";
			this.et_Sleep.UseVisualStyleBackColor = true;
			this.et_Sleep.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Curse
			// 
			this.et_Curse.Location = new System.Drawing.Point(10, 95);
			this.et_Curse.Margin = new System.Windows.Forms.Padding(0);
			this.et_Curse.Name = "et_Curse";
			this.et_Curse.Size = new System.Drawing.Size(180, 20);
			this.et_Curse.TabIndex = 4;
			this.et_Curse.Text = "curse";
			this.et_Curse.UseVisualStyleBackColor = true;
			this.et_Curse.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
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
			this.et_Blindness.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Deafness
			// 
			this.et_Deafness.Location = new System.Drawing.Point(10, 55);
			this.et_Deafness.Margin = new System.Windows.Forms.Padding(0);
			this.et_Deafness.Name = "et_Deafness";
			this.et_Deafness.Size = new System.Drawing.Size(180, 20);
			this.et_Deafness.TabIndex = 2;
			this.et_Deafness.Text = "deafness";
			this.et_Deafness.UseVisualStyleBackColor = true;
			this.et_Deafness.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Paralyze
			// 
			this.et_Paralyze.Location = new System.Drawing.Point(10, 35);
			this.et_Paralyze.Margin = new System.Windows.Forms.Padding(0);
			this.et_Paralyze.Name = "et_Paralyze";
			this.et_Paralyze.Size = new System.Drawing.Size(180, 20);
			this.et_Paralyze.TabIndex = 1;
			this.et_Paralyze.Text = "paralyze";
			this.et_Paralyze.UseVisualStyleBackColor = true;
			this.et_Paralyze.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_Entangle
			// 
			this.et_Entangle.Location = new System.Drawing.Point(10, 15);
			this.et_Entangle.Margin = new System.Windows.Forms.Padding(0);
			this.et_Entangle.Name = "et_Entangle";
			this.et_Entangle.Size = new System.Drawing.Size(180, 20);
			this.et_Entangle.TabIndex = 0;
			this.et_Entangle.Text = "entangle";
			this.et_Entangle.UseVisualStyleBackColor = true;
			this.et_Entangle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_negativeeffects);
			// 
			// et_BenEffectsGrp
			// 
			this.et_BenEffectsGrp.Controls.Add(this.et_ImmunityNecromancy);
			this.et_BenEffectsGrp.Controls.Add(this.et_SpellShield);
			this.et_BenEffectsGrp.Controls.Add(this.et_SeeInvisible);
			this.et_BenEffectsGrp.Controls.Add(this.et_AbilityIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_ElementalShield);
			this.et_BenEffectsGrp.Controls.Add(this.et_GreaterInvisibility);
			this.et_BenEffectsGrp.Controls.Add(this.et_Wildshape);
			this.et_BenEffectsGrp.Controls.Add(this.et_TrueSeeing);
			this.et_BenEffectsGrp.Controls.Add(this.et_Ultravision);
			this.et_BenEffectsGrp.Controls.Add(this.et_Polymorph);
			this.et_BenEffectsGrp.Controls.Add(this.et_Invisibility);
			this.et_BenEffectsGrp.Controls.Add(this.et_Ethereal);
			this.et_BenEffectsGrp.Controls.Add(this.et_AbsorbDamage);
			this.et_BenEffectsGrp.Controls.Add(this.et_DamageIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_Concealment);
			this.et_BenEffectsGrp.Controls.Add(this.et_SavingThrowIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_SpellAbsorption);
			this.et_BenEffectsGrp.Controls.Add(this.et_Timestop);
			this.et_BenEffectsGrp.Controls.Add(this.et_Sanctuary);
			this.et_BenEffectsGrp.Controls.Add(this.et_TempHitpoints);
			this.et_BenEffectsGrp.Controls.Add(this.et_Haste);
			this.et_BenEffectsGrp.Controls.Add(this.et_DamageReduction);
			this.et_BenEffectsGrp.Controls.Add(this.et_AttackIncrease);
			this.et_BenEffectsGrp.Controls.Add(this.et_Regenerate);
			this.et_BenEffectsGrp.Controls.Add(this.et_AcIncrease);
			this.et_BenEffectsGrp.Location = new System.Drawing.Point(390, 60);
			this.et_BenEffectsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.et_BenEffectsGrp.Name = "et_BenEffectsGrp";
			this.et_BenEffectsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.et_BenEffectsGrp.Size = new System.Drawing.Size(385, 320);
			this.et_BenEffectsGrp.TabIndex = 51;
			this.et_BenEffectsGrp.TabStop = false;
			this.et_BenEffectsGrp.Text = "C0FF FFFF beneficial";
			// 
			// et_ImmunityNecromancy
			// 
			this.et_ImmunityNecromancy.Location = new System.Drawing.Point(200, 195);
			this.et_ImmunityNecromancy.Margin = new System.Windows.Forms.Padding(0);
			this.et_ImmunityNecromancy.Name = "et_ImmunityNecromancy";
			this.et_ImmunityNecromancy.Size = new System.Drawing.Size(180, 20);
			this.et_ImmunityNecromancy.TabIndex = 24;
			this.et_ImmunityNecromancy.Text = "immunity vs necromancy";
			this.et_ImmunityNecromancy.UseVisualStyleBackColor = true;
			this.et_ImmunityNecromancy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_SpellShield
			// 
			this.et_SpellShield.Location = new System.Drawing.Point(200, 175);
			this.et_SpellShield.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpellShield.Name = "et_SpellShield";
			this.et_SpellShield.Size = new System.Drawing.Size(180, 20);
			this.et_SpellShield.TabIndex = 23;
			this.et_SpellShield.Text = "spell shield";
			this.et_SpellShield.UseVisualStyleBackColor = true;
			this.et_SpellShield.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_SeeInvisible
			// 
			this.et_SeeInvisible.Location = new System.Drawing.Point(200, 155);
			this.et_SeeInvisible.Margin = new System.Windows.Forms.Padding(0);
			this.et_SeeInvisible.Name = "et_SeeInvisible";
			this.et_SeeInvisible.Size = new System.Drawing.Size(180, 20);
			this.et_SeeInvisible.TabIndex = 22;
			this.et_SeeInvisible.Text = "see invisible";
			this.et_SeeInvisible.UseVisualStyleBackColor = true;
			this.et_SeeInvisible.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_AbilityIncrease
			// 
			this.et_AbilityIncrease.Location = new System.Drawing.Point(200, 135);
			this.et_AbilityIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbilityIncrease.Name = "et_AbilityIncrease";
			this.et_AbilityIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AbilityIncrease.TabIndex = 21;
			this.et_AbilityIncrease.Text = "ability increase";
			this.et_AbilityIncrease.UseVisualStyleBackColor = true;
			this.et_AbilityIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_ElementalShield
			// 
			this.et_ElementalShield.Location = new System.Drawing.Point(200, 115);
			this.et_ElementalShield.Margin = new System.Windows.Forms.Padding(0);
			this.et_ElementalShield.Name = "et_ElementalShield";
			this.et_ElementalShield.Size = new System.Drawing.Size(180, 20);
			this.et_ElementalShield.TabIndex = 20;
			this.et_ElementalShield.Text = "elemental shield";
			this.et_ElementalShield.UseVisualStyleBackColor = true;
			this.et_ElementalShield.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_GreaterInvisibility
			// 
			this.et_GreaterInvisibility.Location = new System.Drawing.Point(200, 95);
			this.et_GreaterInvisibility.Margin = new System.Windows.Forms.Padding(0);
			this.et_GreaterInvisibility.Name = "et_GreaterInvisibility";
			this.et_GreaterInvisibility.Size = new System.Drawing.Size(180, 20);
			this.et_GreaterInvisibility.TabIndex = 19;
			this.et_GreaterInvisibility.Text = "greater invisibility";
			this.et_GreaterInvisibility.UseVisualStyleBackColor = true;
			this.et_GreaterInvisibility.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Wildshape
			// 
			this.et_Wildshape.Location = new System.Drawing.Point(200, 75);
			this.et_Wildshape.Margin = new System.Windows.Forms.Padding(0);
			this.et_Wildshape.Name = "et_Wildshape";
			this.et_Wildshape.Size = new System.Drawing.Size(180, 20);
			this.et_Wildshape.TabIndex = 18;
			this.et_Wildshape.Text = "wildshape";
			this.et_Wildshape.UseVisualStyleBackColor = true;
			this.et_Wildshape.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_TrueSeeing
			// 
			this.et_TrueSeeing.Location = new System.Drawing.Point(200, 55);
			this.et_TrueSeeing.Margin = new System.Windows.Forms.Padding(0);
			this.et_TrueSeeing.Name = "et_TrueSeeing";
			this.et_TrueSeeing.Size = new System.Drawing.Size(180, 20);
			this.et_TrueSeeing.TabIndex = 17;
			this.et_TrueSeeing.Text = "true seeing";
			this.et_TrueSeeing.UseVisualStyleBackColor = true;
			this.et_TrueSeeing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Ultravision
			// 
			this.et_Ultravision.Location = new System.Drawing.Point(200, 35);
			this.et_Ultravision.Margin = new System.Windows.Forms.Padding(0);
			this.et_Ultravision.Name = "et_Ultravision";
			this.et_Ultravision.Size = new System.Drawing.Size(180, 20);
			this.et_Ultravision.TabIndex = 16;
			this.et_Ultravision.Text = "ultravision";
			this.et_Ultravision.UseVisualStyleBackColor = true;
			this.et_Ultravision.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Polymorph
			// 
			this.et_Polymorph.Location = new System.Drawing.Point(200, 15);
			this.et_Polymorph.Margin = new System.Windows.Forms.Padding(0);
			this.et_Polymorph.Name = "et_Polymorph";
			this.et_Polymorph.Size = new System.Drawing.Size(180, 20);
			this.et_Polymorph.TabIndex = 15;
			this.et_Polymorph.Text = "polymorph";
			this.et_Polymorph.UseVisualStyleBackColor = true;
			this.et_Polymorph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Invisibility
			// 
			this.et_Invisibility.Location = new System.Drawing.Point(10, 295);
			this.et_Invisibility.Margin = new System.Windows.Forms.Padding(0);
			this.et_Invisibility.Name = "et_Invisibility";
			this.et_Invisibility.Size = new System.Drawing.Size(180, 20);
			this.et_Invisibility.TabIndex = 14;
			this.et_Invisibility.Text = "invisibility";
			this.et_Invisibility.UseVisualStyleBackColor = true;
			this.et_Invisibility.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Ethereal
			// 
			this.et_Ethereal.Location = new System.Drawing.Point(10, 275);
			this.et_Ethereal.Margin = new System.Windows.Forms.Padding(0);
			this.et_Ethereal.Name = "et_Ethereal";
			this.et_Ethereal.Size = new System.Drawing.Size(180, 20);
			this.et_Ethereal.TabIndex = 13;
			this.et_Ethereal.Text = "ethereal";
			this.et_Ethereal.UseVisualStyleBackColor = true;
			this.et_Ethereal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_AbsorbDamage
			// 
			this.et_AbsorbDamage.Location = new System.Drawing.Point(10, 255);
			this.et_AbsorbDamage.Margin = new System.Windows.Forms.Padding(0);
			this.et_AbsorbDamage.Name = "et_AbsorbDamage";
			this.et_AbsorbDamage.Size = new System.Drawing.Size(180, 20);
			this.et_AbsorbDamage.TabIndex = 12;
			this.et_AbsorbDamage.Text = "absorb damage";
			this.et_AbsorbDamage.UseVisualStyleBackColor = true;
			this.et_AbsorbDamage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_DamageIncrease
			// 
			this.et_DamageIncrease.Location = new System.Drawing.Point(10, 235);
			this.et_DamageIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageIncrease.Name = "et_DamageIncrease";
			this.et_DamageIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_DamageIncrease.TabIndex = 11;
			this.et_DamageIncrease.Text = "damage increase";
			this.et_DamageIncrease.UseVisualStyleBackColor = true;
			this.et_DamageIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Concealment
			// 
			this.et_Concealment.Location = new System.Drawing.Point(10, 215);
			this.et_Concealment.Margin = new System.Windows.Forms.Padding(0);
			this.et_Concealment.Name = "et_Concealment";
			this.et_Concealment.Size = new System.Drawing.Size(180, 20);
			this.et_Concealment.TabIndex = 10;
			this.et_Concealment.Text = "concealment";
			this.et_Concealment.UseVisualStyleBackColor = true;
			this.et_Concealment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_SavingThrowIncrease
			// 
			this.et_SavingThrowIncrease.Location = new System.Drawing.Point(10, 195);
			this.et_SavingThrowIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_SavingThrowIncrease.Name = "et_SavingThrowIncrease";
			this.et_SavingThrowIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_SavingThrowIncrease.TabIndex = 9;
			this.et_SavingThrowIncrease.Text = "saving throw increase";
			this.et_SavingThrowIncrease.UseVisualStyleBackColor = true;
			this.et_SavingThrowIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_SpellAbsorption
			// 
			this.et_SpellAbsorption.Location = new System.Drawing.Point(10, 175);
			this.et_SpellAbsorption.Margin = new System.Windows.Forms.Padding(0);
			this.et_SpellAbsorption.Name = "et_SpellAbsorption";
			this.et_SpellAbsorption.Size = new System.Drawing.Size(180, 20);
			this.et_SpellAbsorption.TabIndex = 8;
			this.et_SpellAbsorption.Text = "spell absorption";
			this.et_SpellAbsorption.UseVisualStyleBackColor = true;
			this.et_SpellAbsorption.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Timestop
			// 
			this.et_Timestop.Location = new System.Drawing.Point(10, 155);
			this.et_Timestop.Margin = new System.Windows.Forms.Padding(0);
			this.et_Timestop.Name = "et_Timestop";
			this.et_Timestop.Size = new System.Drawing.Size(180, 20);
			this.et_Timestop.TabIndex = 7;
			this.et_Timestop.Text = "timestop";
			this.et_Timestop.UseVisualStyleBackColor = true;
			this.et_Timestop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Sanctuary
			// 
			this.et_Sanctuary.Location = new System.Drawing.Point(10, 135);
			this.et_Sanctuary.Margin = new System.Windows.Forms.Padding(0);
			this.et_Sanctuary.Name = "et_Sanctuary";
			this.et_Sanctuary.Size = new System.Drawing.Size(180, 20);
			this.et_Sanctuary.TabIndex = 6;
			this.et_Sanctuary.Text = "sanctuary";
			this.et_Sanctuary.UseVisualStyleBackColor = true;
			this.et_Sanctuary.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_TempHitpoints
			// 
			this.et_TempHitpoints.Location = new System.Drawing.Point(10, 115);
			this.et_TempHitpoints.Margin = new System.Windows.Forms.Padding(0);
			this.et_TempHitpoints.Name = "et_TempHitpoints";
			this.et_TempHitpoints.Size = new System.Drawing.Size(180, 20);
			this.et_TempHitpoints.TabIndex = 5;
			this.et_TempHitpoints.Text = "temporary hitpoints";
			this.et_TempHitpoints.UseVisualStyleBackColor = true;
			this.et_TempHitpoints.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Haste
			// 
			this.et_Haste.Location = new System.Drawing.Point(10, 95);
			this.et_Haste.Margin = new System.Windows.Forms.Padding(0);
			this.et_Haste.Name = "et_Haste";
			this.et_Haste.Size = new System.Drawing.Size(180, 20);
			this.et_Haste.TabIndex = 4;
			this.et_Haste.Text = "haste";
			this.et_Haste.UseVisualStyleBackColor = true;
			this.et_Haste.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_DamageReduction
			// 
			this.et_DamageReduction.Location = new System.Drawing.Point(10, 75);
			this.et_DamageReduction.Margin = new System.Windows.Forms.Padding(0);
			this.et_DamageReduction.Name = "et_DamageReduction";
			this.et_DamageReduction.Size = new System.Drawing.Size(180, 20);
			this.et_DamageReduction.TabIndex = 3;
			this.et_DamageReduction.Text = "damage reduction";
			this.et_DamageReduction.UseVisualStyleBackColor = true;
			this.et_DamageReduction.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_AttackIncrease
			// 
			this.et_AttackIncrease.Location = new System.Drawing.Point(10, 55);
			this.et_AttackIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AttackIncrease.Name = "et_AttackIncrease";
			this.et_AttackIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AttackIncrease.TabIndex = 2;
			this.et_AttackIncrease.Text = "attack increase";
			this.et_AttackIncrease.UseVisualStyleBackColor = true;
			this.et_AttackIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_Regenerate
			// 
			this.et_Regenerate.Location = new System.Drawing.Point(10, 35);
			this.et_Regenerate.Margin = new System.Windows.Forms.Padding(0);
			this.et_Regenerate.Name = "et_Regenerate";
			this.et_Regenerate.Size = new System.Drawing.Size(180, 20);
			this.et_Regenerate.TabIndex = 1;
			this.et_Regenerate.Text = "regenerate";
			this.et_Regenerate.UseVisualStyleBackColor = true;
			this.et_Regenerate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_AcIncrease
			// 
			this.et_AcIncrease.Location = new System.Drawing.Point(10, 15);
			this.et_AcIncrease.Margin = new System.Windows.Forms.Padding(0);
			this.et_AcIncrease.Name = "et_AcIncrease";
			this.et_AcIncrease.Size = new System.Drawing.Size(180, 20);
			this.et_AcIncrease.TabIndex = 0;
			this.et_AcIncrease.Text = "ac increase";
			this.et_AcIncrease.UseVisualStyleBackColor = true;
			this.et_AcIncrease.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_et_positiveeffects);
			// 
			// et_bin
			// 
			this.et_bin.Location = new System.Drawing.Point(395, 35);
			this.et_bin.Margin = new System.Windows.Forms.Padding(0);
			this.et_bin.Name = "et_bin";
			this.et_bin.Size = new System.Drawing.Size(45, 15);
			this.et_bin.TabIndex = 50;
			this.et_bin.Text = "- bin";
			this.et_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// et_hex
			// 
			this.et_hex.Location = new System.Drawing.Point(395, 15);
			this.et_hex.Margin = new System.Windows.Forms.Padding(0);
			this.et_hex.Name = "et_hex";
			this.et_hex.Size = new System.Drawing.Size(45, 15);
			this.et_hex.TabIndex = 49;
			this.et_hex.Text = "- hex";
			this.et_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// et_Clear
			// 
			this.et_Clear.Location = new System.Drawing.Point(450, 5);
			this.et_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.et_Clear.Name = "et_Clear";
			this.et_Clear.Size = new System.Drawing.Size(65, 50);
			this.et_Clear.TabIndex = 48;
			this.et_Clear.Text = "zero\r\nall\r\nbits";
			this.et_Clear.UseVisualStyleBackColor = true;
			this.et_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.EffectTypes_bin.TabIndex = 46;
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
			this.EffectTypes_hex.TabIndex = 47;
			// 
			// EffectTypes_text
			// 
			this.EffectTypes_text.Location = new System.Drawing.Point(5, 35);
			this.EffectTypes_text.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_text.Name = "EffectTypes_text";
			this.EffectTypes_text.Size = new System.Drawing.Size(100, 20);
			this.EffectTypes_text.TabIndex = 15;
			this.EffectTypes_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.EffectTypes_text.TextChanged += new System.EventHandler(this.TextChanged_et);
			// 
			// EffectTypes_reset
			// 
			this.EffectTypes_reset.Location = new System.Drawing.Point(5, 5);
			this.EffectTypes_reset.Margin = new System.Windows.Forms.Padding(0);
			this.EffectTypes_reset.Name = "EffectTypes_reset";
			this.EffectTypes_reset.Size = new System.Drawing.Size(100, 25);
			this.EffectTypes_reset.TabIndex = 3;
			this.toolTip1.SetToolTip(this.EffectTypes_reset, "reset");
			this.EffectTypes_reset.UseVisualStyleBackColor = true;
			this.EffectTypes_reset.Click += new System.EventHandler(this.Click_et_reset);
			// 
			// page_DamageInfo
			// 
			this.page_DamageInfo.Controls.Add(this.di_DetrimentalGrp);
			this.page_DamageInfo.Controls.Add(this.di_BeneficialGrp);
			this.page_DamageInfo.Controls.Add(this.di_DispelTypesGrp);
			this.page_DamageInfo.Controls.Add(this.di_bin);
			this.page_DamageInfo.Controls.Add(this.di_hex);
			this.page_DamageInfo.Controls.Add(this.di_Clear);
			this.page_DamageInfo.Controls.Add(this.DamageInfo_bin);
			this.page_DamageInfo.Controls.Add(this.DamageInfo_hex);
			this.page_DamageInfo.Controls.Add(this.DamageInfo_text);
			this.page_DamageInfo.Controls.Add(this.DamageInfo_reset);
			this.page_DamageInfo.Location = new System.Drawing.Point(4, 23);
			this.page_DamageInfo.Margin = new System.Windows.Forms.Padding(2);
			this.page_DamageInfo.Name = "page_DamageInfo";
			this.page_DamageInfo.Padding = new System.Windows.Forms.Padding(2);
			this.page_DamageInfo.Size = new System.Drawing.Size(812, 428);
			this.page_DamageInfo.TabIndex = 4;
			this.page_DamageInfo.Text = "DamageInfo";
			this.page_DamageInfo.UseVisualStyleBackColor = true;
			// 
			// di_DetrimentalGrp
			// 
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamageGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamagetypeGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLeveldivisorGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLevellimitGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetFixedCountGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetDamagebaseGrp);
			this.di_DetrimentalGrp.Controls.Add(this.di_DetLeveltypeGrp);
			this.di_DetrimentalGrp.Location = new System.Drawing.Point(5, 60);
			this.di_DetrimentalGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetrimentalGrp.Name = "di_DetrimentalGrp";
			this.di_DetrimentalGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetrimentalGrp.Size = new System.Drawing.Size(380, 280);
			this.di_DetrimentalGrp.TabIndex = 48;
			this.di_DetrimentalGrp.TabStop = false;
			this.di_DetrimentalGrp.Text = "detrimental";
			// 
			// di_DetDamageGrp
			// 
			this.di_DetDamageGrp.Controls.Add(this.di_DetDamage);
			this.di_DetDamageGrp.Location = new System.Drawing.Point(5, 60);
			this.di_DetDamageGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamageGrp.Name = "di_DetDamageGrp";
			this.di_DetDamageGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetDamageGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetDamageGrp.TabIndex = 9;
			this.di_DetDamageGrp.TabStop = false;
			this.di_DetDamageGrp.Text = "000F F000 damage";
			// 
			// di_DetDamage
			// 
			this.di_DetDamage.Location = new System.Drawing.Point(5, 15);
			this.di_DetDamage.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamage.Name = "di_DetDamage";
			this.di_DetDamage.Size = new System.Drawing.Size(85, 20);
			this.di_DetDamage.TabIndex = 5;
			this.di_DetDamage.TextChanged += new System.EventHandler(this.TextChanged_di_det_Damage);
			// 
			// di_DetDamagetypeGrp
			// 
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Sonic);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Positive);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Negative);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Fire);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Electrical);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Divine);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Cold);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Acid);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Magical);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Slashing);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Piercing);
			this.di_DetDamagetypeGrp.Controls.Add(this.di_Bludgeoning);
			this.di_DetDamagetypeGrp.Location = new System.Drawing.Point(245, 15);
			this.di_DetDamagetypeGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetDamagetypeGrp.Name = "di_DetDamagetypeGrp";
			this.di_DetDamagetypeGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetDamagetypeGrp.Size = new System.Drawing.Size(130, 260);
			this.di_DetDamagetypeGrp.TabIndex = 8;
			this.di_DetDamagetypeGrp.TabStop = false;
			this.di_DetDamagetypeGrp.Text = "0000 0FFF types";
			// 
			// di_Sonic
			// 
			this.di_Sonic.Location = new System.Drawing.Point(10, 235);
			this.di_Sonic.Margin = new System.Windows.Forms.Padding(0);
			this.di_Sonic.Name = "di_Sonic";
			this.di_Sonic.Size = new System.Drawing.Size(105, 20);
			this.di_Sonic.TabIndex = 12;
			this.di_Sonic.Text = "sonic";
			this.di_Sonic.UseVisualStyleBackColor = true;
			this.di_Sonic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Positive
			// 
			this.di_Positive.Location = new System.Drawing.Point(10, 215);
			this.di_Positive.Margin = new System.Windows.Forms.Padding(0);
			this.di_Positive.Name = "di_Positive";
			this.di_Positive.Size = new System.Drawing.Size(105, 20);
			this.di_Positive.TabIndex = 11;
			this.di_Positive.Text = "positive";
			this.di_Positive.UseVisualStyleBackColor = true;
			this.di_Positive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Negative
			// 
			this.di_Negative.Location = new System.Drawing.Point(10, 195);
			this.di_Negative.Margin = new System.Windows.Forms.Padding(0);
			this.di_Negative.Name = "di_Negative";
			this.di_Negative.Size = new System.Drawing.Size(105, 20);
			this.di_Negative.TabIndex = 10;
			this.di_Negative.Text = "negative";
			this.di_Negative.UseVisualStyleBackColor = true;
			this.di_Negative.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Fire
			// 
			this.di_Fire.Location = new System.Drawing.Point(10, 175);
			this.di_Fire.Margin = new System.Windows.Forms.Padding(0);
			this.di_Fire.Name = "di_Fire";
			this.di_Fire.Size = new System.Drawing.Size(105, 20);
			this.di_Fire.TabIndex = 9;
			this.di_Fire.Text = "fire";
			this.di_Fire.UseVisualStyleBackColor = true;
			this.di_Fire.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Electrical
			// 
			this.di_Electrical.Location = new System.Drawing.Point(10, 155);
			this.di_Electrical.Margin = new System.Windows.Forms.Padding(0);
			this.di_Electrical.Name = "di_Electrical";
			this.di_Electrical.Size = new System.Drawing.Size(105, 20);
			this.di_Electrical.TabIndex = 8;
			this.di_Electrical.Text = "electrical";
			this.di_Electrical.UseVisualStyleBackColor = true;
			this.di_Electrical.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Divine
			// 
			this.di_Divine.Location = new System.Drawing.Point(10, 135);
			this.di_Divine.Margin = new System.Windows.Forms.Padding(0);
			this.di_Divine.Name = "di_Divine";
			this.di_Divine.Size = new System.Drawing.Size(105, 20);
			this.di_Divine.TabIndex = 7;
			this.di_Divine.Text = "divine";
			this.di_Divine.UseVisualStyleBackColor = true;
			this.di_Divine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Cold
			// 
			this.di_Cold.Location = new System.Drawing.Point(10, 115);
			this.di_Cold.Margin = new System.Windows.Forms.Padding(0);
			this.di_Cold.Name = "di_Cold";
			this.di_Cold.Size = new System.Drawing.Size(105, 20);
			this.di_Cold.TabIndex = 6;
			this.di_Cold.Text = "cold";
			this.di_Cold.UseVisualStyleBackColor = true;
			this.di_Cold.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Acid
			// 
			this.di_Acid.Location = new System.Drawing.Point(10, 95);
			this.di_Acid.Margin = new System.Windows.Forms.Padding(0);
			this.di_Acid.Name = "di_Acid";
			this.di_Acid.Size = new System.Drawing.Size(105, 20);
			this.di_Acid.TabIndex = 5;
			this.di_Acid.Text = "acid";
			this.di_Acid.UseVisualStyleBackColor = true;
			this.di_Acid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Magical
			// 
			this.di_Magical.Location = new System.Drawing.Point(10, 75);
			this.di_Magical.Margin = new System.Windows.Forms.Padding(0);
			this.di_Magical.Name = "di_Magical";
			this.di_Magical.Size = new System.Drawing.Size(105, 20);
			this.di_Magical.TabIndex = 4;
			this.di_Magical.Text = "magical";
			this.di_Magical.UseVisualStyleBackColor = true;
			this.di_Magical.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Slashing
			// 
			this.di_Slashing.Location = new System.Drawing.Point(10, 55);
			this.di_Slashing.Margin = new System.Windows.Forms.Padding(0);
			this.di_Slashing.Name = "di_Slashing";
			this.di_Slashing.Size = new System.Drawing.Size(105, 20);
			this.di_Slashing.TabIndex = 3;
			this.di_Slashing.Text = "slashing";
			this.di_Slashing.UseVisualStyleBackColor = true;
			this.di_Slashing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Piercing
			// 
			this.di_Piercing.Location = new System.Drawing.Point(10, 35);
			this.di_Piercing.Margin = new System.Windows.Forms.Padding(0);
			this.di_Piercing.Name = "di_Piercing";
			this.di_Piercing.Size = new System.Drawing.Size(105, 20);
			this.di_Piercing.TabIndex = 2;
			this.di_Piercing.Text = "piercing";
			this.di_Piercing.UseVisualStyleBackColor = true;
			this.di_Piercing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_Bludgeoning
			// 
			this.di_Bludgeoning.Location = new System.Drawing.Point(10, 15);
			this.di_Bludgeoning.Margin = new System.Windows.Forms.Padding(0);
			this.di_Bludgeoning.Name = "di_Bludgeoning";
			this.di_Bludgeoning.Size = new System.Drawing.Size(105, 20);
			this.di_Bludgeoning.TabIndex = 1;
			this.di_Bludgeoning.Text = "bludgeoning";
			this.di_Bludgeoning.UseVisualStyleBackColor = true;
			this.di_Bludgeoning.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_det_Damagetype);
			// 
			// di_DetLeveldivisorGrp
			// 
			this.di_DetLeveldivisorGrp.Controls.Add(this.di_DetLeveldivisor);
			this.di_DetLeveldivisorGrp.Location = new System.Drawing.Point(5, 185);
			this.di_DetLeveldivisorGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisorGrp.Name = "di_DetLeveldivisorGrp";
			this.di_DetLeveldivisorGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisorGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetLeveldivisorGrp.TabIndex = 7;
			this.di_DetLeveldivisorGrp.TabStop = false;
			this.di_DetLeveldivisorGrp.Text = "0C00 0000 leveldivisor";
			// 
			// di_DetLeveldivisor
			// 
			this.di_DetLeveldivisor.Location = new System.Drawing.Point(5, 15);
			this.di_DetLeveldivisor.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLeveldivisor.Name = "di_DetLeveldivisor";
			this.di_DetLeveldivisor.Size = new System.Drawing.Size(85, 20);
			this.di_DetLeveldivisor.TabIndex = 5;
			this.di_DetLeveldivisor.TextChanged += new System.EventHandler(this.TextChanged_di_det_Leveldivisor);
			// 
			// di_DetLevellimitGrp
			// 
			this.di_DetLevellimitGrp.Controls.Add(this.di_DetLevellimit);
			this.di_DetLevellimitGrp.Location = new System.Drawing.Point(5, 145);
			this.di_DetLevellimitGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimitGrp.Name = "di_DetLevellimitGrp";
			this.di_DetLevellimitGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimitGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetLevellimitGrp.TabIndex = 6;
			this.di_DetLevellimitGrp.TabStop = false;
			this.di_DetLevellimitGrp.Text = "00F0 0000 levellimit";
			// 
			// di_DetLevellimit
			// 
			this.di_DetLevellimit.Location = new System.Drawing.Point(5, 15);
			this.di_DetLevellimit.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetLevellimit.Name = "di_DetLevellimit";
			this.di_DetLevellimit.Size = new System.Drawing.Size(85, 20);
			this.di_DetLevellimit.TabIndex = 5;
			this.di_DetLevellimit.TextChanged += new System.EventHandler(this.TextChanged_di_det_Levellimit);
			// 
			// di_DetFixedCountGrp
			// 
			this.di_DetFixedCountGrp.Controls.Add(this.di_lbl_FixedCountPlusOne);
			this.di_DetFixedCountGrp.Controls.Add(this.di_DetFixedcount);
			this.di_DetFixedCountGrp.Location = new System.Drawing.Point(5, 225);
			this.di_DetFixedCountGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetFixedCountGrp.Name = "di_DetFixedCountGrp";
			this.di_DetFixedCountGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DetFixedCountGrp.Size = new System.Drawing.Size(240, 40);
			this.di_DetFixedCountGrp.TabIndex = 5;
			this.di_DetFixedCountGrp.TabStop = false;
			this.di_DetFixedCountGrp.Text = "0F00 0000 fixedcount";
			// 
			// di_lbl_FixedCountPlusOne
			// 
			this.di_lbl_FixedCountPlusOne.Location = new System.Drawing.Point(95, 15);
			this.di_lbl_FixedCountPlusOne.Margin = new System.Windows.Forms.Padding(0);
			this.di_lbl_FixedCountPlusOne.Name = "di_lbl_FixedCountPlusOne";
			this.di_lbl_FixedCountPlusOne.Size = new System.Drawing.Size(30, 20);
			this.di_lbl_FixedCountPlusOne.TabIndex = 5;
			this.di_lbl_FixedCountPlusOne.Text = "+ 1";
			this.di_lbl_FixedCountPlusOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_DetFixedcount
			// 
			this.di_DetFixedcount.Location = new System.Drawing.Point(5, 15);
			this.di_DetFixedcount.Margin = new System.Windows.Forms.Padding(0);
			this.di_DetFixedcount.Name = "di_DetFixedcount";
			this.di_DetFixedcount.Size = new System.Drawing.Size(85, 20);
			this.di_DetFixedcount.TabIndex = 4;
			this.di_DetFixedcount.TextChanged += new System.EventHandler(this.TextChanged_di_det_Fixedcount);
			// 
			// di_DetDamagebaseGrp
			// 
			this.di_DetDamagebaseGrp.Controls.Add(this.cbo_di_DetDamagebase);
			this.di_DetDamagebaseGrp.Location = new System.Drawing.Point(5, 15);
			this.di_DetDamagebaseGrp.Name = "di_DetDamagebaseGrp";
			this.di_DetDamagebaseGrp.Size = new System.Drawing.Size(240, 45);
			this.di_DetDamagebaseGrp.TabIndex = 3;
			this.di_DetDamagebaseGrp.TabStop = false;
			this.di_DetDamagebaseGrp.Text = "F000 0000 damagebase";
			// 
			// cbo_di_DetDamagebase
			// 
			this.cbo_di_DetDamagebase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_di_DetDamagebase.FormattingEnabled = true;
			this.cbo_di_DetDamagebase.Location = new System.Drawing.Point(5, 15);
			this.cbo_di_DetDamagebase.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_di_DetDamagebase.Name = "cbo_di_DetDamagebase";
			this.cbo_di_DetDamagebase.Size = new System.Drawing.Size(230, 22);
			this.cbo_di_DetDamagebase.TabIndex = 1;
			this.cbo_di_DetDamagebase.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_di_cbo_det_Damagebase);
			// 
			// di_DetLeveltypeGrp
			// 
			this.di_DetLeveltypeGrp.Controls.Add(this.cbo_di_DetLeveltype);
			this.di_DetLeveltypeGrp.Location = new System.Drawing.Point(5, 100);
			this.di_DetLeveltypeGrp.Name = "di_DetLeveltypeGrp";
			this.di_DetLeveltypeGrp.Size = new System.Drawing.Size(240, 45);
			this.di_DetLeveltypeGrp.TabIndex = 2;
			this.di_DetLeveltypeGrp.TabStop = false;
			this.di_DetLeveltypeGrp.Text = "0300 0000 leveltype";
			// 
			// cbo_di_DetLeveltype
			// 
			this.cbo_di_DetLeveltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_di_DetLeveltype.FormattingEnabled = true;
			this.cbo_di_DetLeveltype.Location = new System.Drawing.Point(5, 15);
			this.cbo_di_DetLeveltype.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_di_DetLeveltype.Name = "cbo_di_DetLeveltype";
			this.cbo_di_DetLeveltype.Size = new System.Drawing.Size(230, 22);
			this.cbo_di_DetLeveltype.TabIndex = 0;
			this.cbo_di_DetLeveltype.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_di_cbo_det_Leveltype);
			// 
			// di_BeneficialGrp
			// 
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveldecreaseGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenPowerbaseGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenPowerGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveldivisorGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLevellimitGrp);
			this.di_BeneficialGrp.Controls.Add(this.di_BenLeveltypeGrp);
			this.di_BeneficialGrp.Location = new System.Drawing.Point(385, 60);
			this.di_BeneficialGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BeneficialGrp.Name = "di_BeneficialGrp";
			this.di_BeneficialGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BeneficialGrp.Size = new System.Drawing.Size(250, 280);
			this.di_BeneficialGrp.TabIndex = 47;
			this.di_BeneficialGrp.TabStop = false;
			this.di_BeneficialGrp.Text = "beneficial";
			// 
			// di_BenLeveldecreaseGrp
			// 
			this.di_BenLeveldecreaseGrp.Controls.Add(this.di_BenLeveldecrease);
			this.di_BenLeveldecreaseGrp.Location = new System.Drawing.Point(5, 225);
			this.di_BenLeveldecreaseGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecreaseGrp.Name = "di_BenLeveldecreaseGrp";
			this.di_BenLeveldecreaseGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecreaseGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLeveldecreaseGrp.TabIndex = 6;
			this.di_BenLeveldecreaseGrp.TabStop = false;
			this.di_BenLeveldecreaseGrp.Text = "00F0 0000 leveldecrease";
			// 
			// di_BenLeveldecrease
			// 
			this.di_BenLeveldecrease.Location = new System.Drawing.Point(5, 15);
			this.di_BenLeveldecrease.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldecrease.Name = "di_BenLeveldecrease";
			this.di_BenLeveldecrease.Size = new System.Drawing.Size(85, 20);
			this.di_BenLeveldecrease.TabIndex = 5;
			this.di_BenLeveldecrease.TextChanged += new System.EventHandler(this.TextChanged_di_ben_Leveldecrease);
			// 
			// di_BenPowerbaseGrp
			// 
			this.di_BenPowerbaseGrp.Controls.Add(this.cbo_di_BenPowerbase);
			this.di_BenPowerbaseGrp.Location = new System.Drawing.Point(5, 15);
			this.di_BenPowerbaseGrp.Name = "di_BenPowerbaseGrp";
			this.di_BenPowerbaseGrp.Size = new System.Drawing.Size(240, 45);
			this.di_BenPowerbaseGrp.TabIndex = 2;
			this.di_BenPowerbaseGrp.TabStop = false;
			this.di_BenPowerbaseGrp.Text = "0F00 0000 powerbase";
			// 
			// cbo_di_BenPowerbase
			// 
			this.cbo_di_BenPowerbase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_di_BenPowerbase.FormattingEnabled = true;
			this.cbo_di_BenPowerbase.Location = new System.Drawing.Point(5, 15);
			this.cbo_di_BenPowerbase.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_di_BenPowerbase.Name = "cbo_di_BenPowerbase";
			this.cbo_di_BenPowerbase.Size = new System.Drawing.Size(230, 22);
			this.cbo_di_BenPowerbase.TabIndex = 1;
			this.cbo_di_BenPowerbase.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_di_cbo_ben_Powerbase);
			// 
			// di_BenPowerGrp
			// 
			this.di_BenPowerGrp.Controls.Add(this.di_BenPower);
			this.di_BenPowerGrp.Location = new System.Drawing.Point(5, 60);
			this.di_BenPowerGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenPowerGrp.Name = "di_BenPowerGrp";
			this.di_BenPowerGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenPowerGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenPowerGrp.TabIndex = 3;
			this.di_BenPowerGrp.TabStop = false;
			this.di_BenPowerGrp.Text = "0000 00FF power";
			// 
			// di_BenPower
			// 
			this.di_BenPower.Location = new System.Drawing.Point(5, 15);
			this.di_BenPower.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenPower.Name = "di_BenPower";
			this.di_BenPower.Size = new System.Drawing.Size(85, 20);
			this.di_BenPower.TabIndex = 5;
			this.di_BenPower.TextChanged += new System.EventHandler(this.TextChanged_di_ben_Power);
			// 
			// di_BenLeveldivisorGrp
			// 
			this.di_BenLeveldivisorGrp.Controls.Add(this.di_BenLeveldivisor);
			this.di_BenLeveldivisorGrp.Location = new System.Drawing.Point(5, 185);
			this.di_BenLeveldivisorGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisorGrp.Name = "di_BenLeveldivisorGrp";
			this.di_BenLeveldivisorGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisorGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLeveldivisorGrp.TabIndex = 5;
			this.di_BenLeveldivisorGrp.TabStop = false;
			this.di_BenLeveldivisorGrp.Text = "000F 0000 leveldivisor";
			// 
			// di_BenLeveldivisor
			// 
			this.di_BenLeveldivisor.Location = new System.Drawing.Point(5, 15);
			this.di_BenLeveldivisor.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLeveldivisor.Name = "di_BenLeveldivisor";
			this.di_BenLeveldivisor.Size = new System.Drawing.Size(85, 20);
			this.di_BenLeveldivisor.TabIndex = 5;
			this.di_BenLeveldivisor.TextChanged += new System.EventHandler(this.TextChanged_di_ben_Leveldivisor);
			// 
			// di_BenLevellimitGrp
			// 
			this.di_BenLevellimitGrp.Controls.Add(this.di_BenLevellimit);
			this.di_BenLevellimitGrp.Location = new System.Drawing.Point(5, 145);
			this.di_BenLevellimitGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimitGrp.Name = "di_BenLevellimitGrp";
			this.di_BenLevellimitGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimitGrp.Size = new System.Drawing.Size(240, 40);
			this.di_BenLevellimitGrp.TabIndex = 4;
			this.di_BenLevellimitGrp.TabStop = false;
			this.di_BenLevellimitGrp.Text = "0000 3F00 levellimit";
			// 
			// di_BenLevellimit
			// 
			this.di_BenLevellimit.Location = new System.Drawing.Point(5, 15);
			this.di_BenLevellimit.Margin = new System.Windows.Forms.Padding(0);
			this.di_BenLevellimit.Name = "di_BenLevellimit";
			this.di_BenLevellimit.Size = new System.Drawing.Size(85, 20);
			this.di_BenLevellimit.TabIndex = 5;
			this.di_BenLevellimit.TextChanged += new System.EventHandler(this.TextChanged_di_ben_Levellimit);
			// 
			// di_BenLeveltypeGrp
			// 
			this.di_BenLeveltypeGrp.Controls.Add(this.cbo_di_BenLeveltype);
			this.di_BenLeveltypeGrp.Location = new System.Drawing.Point(5, 100);
			this.di_BenLeveltypeGrp.Name = "di_BenLeveltypeGrp";
			this.di_BenLeveltypeGrp.Size = new System.Drawing.Size(240, 45);
			this.di_BenLeveltypeGrp.TabIndex = 1;
			this.di_BenLeveltypeGrp.TabStop = false;
			this.di_BenLeveltypeGrp.Text = "0000 C000 leveltype";
			// 
			// cbo_di_BenLeveltype
			// 
			this.cbo_di_BenLeveltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_di_BenLeveltype.FormattingEnabled = true;
			this.cbo_di_BenLeveltype.Location = new System.Drawing.Point(5, 15);
			this.cbo_di_BenLeveltype.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_di_BenLeveltype.Name = "cbo_di_BenLeveltype";
			this.cbo_di_BenLeveltype.Size = new System.Drawing.Size(230, 22);
			this.cbo_di_BenLeveltype.TabIndex = 0;
			this.cbo_di_BenLeveltype.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_di_cbo_ben_Leveltype);
			// 
			// di_DispelTypesGrp
			// 
			this.di_DispelTypesGrp.Controls.Add(this.di_Resist);
			this.di_DispelTypesGrp.Controls.Add(this.di_Dispel);
			this.di_DispelTypesGrp.Controls.Add(this.di_Breach);
			this.di_DispelTypesGrp.Location = new System.Drawing.Point(5, 340);
			this.di_DispelTypesGrp.Margin = new System.Windows.Forms.Padding(0);
			this.di_DispelTypesGrp.Name = "di_DispelTypesGrp";
			this.di_DispelTypesGrp.Padding = new System.Windows.Forms.Padding(0);
			this.di_DispelTypesGrp.Size = new System.Drawing.Size(170, 80);
			this.di_DispelTypesGrp.TabIndex = 46;
			this.di_DispelTypesGrp.TabStop = false;
			this.di_DispelTypesGrp.Text = "0000 0007 dispeltypes";
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
			this.di_Resist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_Dispeltype);
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
			this.di_Dispel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_Dispeltype);
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
			this.di_Breach.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_di_Dispeltype);
			// 
			// di_bin
			// 
			this.di_bin.Location = new System.Drawing.Point(395, 35);
			this.di_bin.Margin = new System.Windows.Forms.Padding(0);
			this.di_bin.Name = "di_bin";
			this.di_bin.Size = new System.Drawing.Size(45, 15);
			this.di_bin.TabIndex = 45;
			this.di_bin.Text = "- bin";
			this.di_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_hex
			// 
			this.di_hex.Location = new System.Drawing.Point(395, 15);
			this.di_hex.Margin = new System.Windows.Forms.Padding(0);
			this.di_hex.Name = "di_hex";
			this.di_hex.Size = new System.Drawing.Size(45, 15);
			this.di_hex.TabIndex = 44;
			this.di_hex.Text = "- hex";
			this.di_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// di_Clear
			// 
			this.di_Clear.Location = new System.Drawing.Point(450, 5);
			this.di_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.di_Clear.Name = "di_Clear";
			this.di_Clear.Size = new System.Drawing.Size(65, 50);
			this.di_Clear.TabIndex = 43;
			this.di_Clear.Text = "zero\r\nall\r\nbits";
			this.di_Clear.UseVisualStyleBackColor = true;
			this.di_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.DamageInfo_bin.TabIndex = 41;
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
			this.DamageInfo_hex.TabIndex = 42;
			// 
			// DamageInfo_text
			// 
			this.DamageInfo_text.Location = new System.Drawing.Point(5, 35);
			this.DamageInfo_text.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_text.Name = "DamageInfo_text";
			this.DamageInfo_text.Size = new System.Drawing.Size(100, 20);
			this.DamageInfo_text.TabIndex = 15;
			this.DamageInfo_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.DamageInfo_text.TextChanged += new System.EventHandler(this.TextChanged_di);
			// 
			// DamageInfo_reset
			// 
			this.DamageInfo_reset.Location = new System.Drawing.Point(5, 5);
			this.DamageInfo_reset.Margin = new System.Windows.Forms.Padding(0);
			this.DamageInfo_reset.Name = "DamageInfo_reset";
			this.DamageInfo_reset.Size = new System.Drawing.Size(100, 25);
			this.DamageInfo_reset.TabIndex = 4;
			this.toolTip1.SetToolTip(this.DamageInfo_reset, "reset");
			this.DamageInfo_reset.UseVisualStyleBackColor = true;
			this.DamageInfo_reset.Click += new System.EventHandler(this.Click_di_reset);
			// 
			// page_SaveType
			// 
			this.page_SaveType.Controls.Add(this.st_DetrimentalGrp);
			this.page_SaveType.Controls.Add(this.st_ExclusiveGrp);
			this.page_SaveType.Controls.Add(this.st_bin);
			this.page_SaveType.Controls.Add(this.st_hex);
			this.page_SaveType.Controls.Add(this.st_NotCaster);
			this.page_SaveType.Controls.Add(this.st_Clear);
			this.page_SaveType.Controls.Add(this.SaveType_bin);
			this.page_SaveType.Controls.Add(this.SaveType_hex);
			this.page_SaveType.Controls.Add(this.st_AcBonusGrp);
			this.page_SaveType.Controls.Add(this.st_TargetRestrictionGrp);
			this.page_SaveType.Controls.Add(this.SaveType_text);
			this.page_SaveType.Controls.Add(this.SaveType_reset);
			this.page_SaveType.Location = new System.Drawing.Point(4, 23);
			this.page_SaveType.Margin = new System.Windows.Forms.Padding(2);
			this.page_SaveType.Name = "page_SaveType";
			this.page_SaveType.Padding = new System.Windows.Forms.Padding(2);
			this.page_SaveType.Size = new System.Drawing.Size(812, 428);
			this.page_SaveType.TabIndex = 5;
			this.page_SaveType.Text = "SaveType";
			this.page_SaveType.UseVisualStyleBackColor = true;
			// 
			// st_DetrimentalGrp
			// 
			this.st_DetrimentalGrp.Controls.Add(this.st_SpecificGrp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Immunity2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Immunity1Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_FlagsGrp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Impact1Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Impact2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Save2Grp);
			this.st_DetrimentalGrp.Controls.Add(this.st_Save1Grp);
			this.st_DetrimentalGrp.Location = new System.Drawing.Point(5, 60);
			this.st_DetrimentalGrp.Name = "st_DetrimentalGrp";
			this.st_DetrimentalGrp.Size = new System.Drawing.Size(535, 275);
			this.st_DetrimentalGrp.TabIndex = 37;
			this.st_DetrimentalGrp.TabStop = false;
			this.st_DetrimentalGrp.Text = "attack";
			// 
			// st_SpecificGrp
			// 
			this.st_SpecificGrp.Controls.Add(this.cbo_st_Specific);
			this.st_SpecificGrp.Location = new System.Drawing.Point(5, 225);
			this.st_SpecificGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_SpecificGrp.Name = "st_SpecificGrp";
			this.st_SpecificGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_SpecificGrp.Size = new System.Drawing.Size(475, 45);
			this.st_SpecificGrp.TabIndex = 32;
			this.st_SpecificGrp.TabStop = false;
			this.st_SpecificGrp.Text = "0000 003F specific";
			// 
			// cbo_st_Specific
			// 
			this.cbo_st_Specific.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_st_Specific.FormattingEnabled = true;
			this.cbo_st_Specific.Location = new System.Drawing.Point(5, 15);
			this.cbo_st_Specific.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_st_Specific.Name = "cbo_st_Specific";
			this.cbo_st_Specific.Size = new System.Drawing.Size(465, 22);
			this.cbo_st_Specific.TabIndex = 0;
			this.cbo_st_Specific.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_st_cbo_Specific);
			// 
			// st_Immunity2Grp
			// 
			this.st_Immunity2Grp.Controls.Add(this.cbo_st_Immunity2);
			this.st_Immunity2Grp.Location = new System.Drawing.Point(295, 180);
			this.st_Immunity2Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Immunity2Grp.Name = "st_Immunity2Grp";
			this.st_Immunity2Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Immunity2Grp.Size = new System.Drawing.Size(235, 45);
			this.st_Immunity2Grp.TabIndex = 31;
			this.st_Immunity2Grp.TabStop = false;
			this.st_Immunity2Grp.Text = "0003 F000 immunity2";
			// 
			// cbo_st_Immunity2
			// 
			this.cbo_st_Immunity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_st_Immunity2.FormattingEnabled = true;
			this.cbo_st_Immunity2.Location = new System.Drawing.Point(5, 15);
			this.cbo_st_Immunity2.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_st_Immunity2.Name = "cbo_st_Immunity2";
			this.cbo_st_Immunity2.Size = new System.Drawing.Size(225, 22);
			this.cbo_st_Immunity2.TabIndex = 0;
			this.cbo_st_Immunity2.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_st_cbo_Immunity2);
			// 
			// st_Immunity1Grp
			// 
			this.st_Immunity1Grp.Controls.Add(this.cbo_st_Immunity1);
			this.st_Immunity1Grp.Location = new System.Drawing.Point(295, 135);
			this.st_Immunity1Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Immunity1Grp.Name = "st_Immunity1Grp";
			this.st_Immunity1Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Immunity1Grp.Size = new System.Drawing.Size(235, 45);
			this.st_Immunity1Grp.TabIndex = 30;
			this.st_Immunity1Grp.TabStop = false;
			this.st_Immunity1Grp.Text = "0000 0FC0 immunity1";
			// 
			// cbo_st_Immunity1
			// 
			this.cbo_st_Immunity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_st_Immunity1.FormattingEnabled = true;
			this.cbo_st_Immunity1.Location = new System.Drawing.Point(5, 15);
			this.cbo_st_Immunity1.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_st_Immunity1.Name = "cbo_st_Immunity1";
			this.cbo_st_Immunity1.Size = new System.Drawing.Size(225, 22);
			this.cbo_st_Immunity1.TabIndex = 0;
			this.cbo_st_Immunity1.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_st_cbo_Immunity1);
			// 
			// st_FlagsGrp
			// 
			this.st_FlagsGrp.Controls.Add(this.st_SpellResistance);
			this.st_FlagsGrp.Controls.Add(this.st_MindAffecting);
			this.st_FlagsGrp.Controls.Add(this.st_AffectsFriendlies);
			this.st_FlagsGrp.Controls.Add(this.st_TouchRanged);
			this.st_FlagsGrp.Controls.Add(this.st_TouchMelee);
			this.st_FlagsGrp.Location = new System.Drawing.Point(295, 15);
			this.st_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_FlagsGrp.Name = "st_FlagsGrp";
			this.st_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_FlagsGrp.Size = new System.Drawing.Size(235, 120);
			this.st_FlagsGrp.TabIndex = 28;
			this.st_FlagsGrp.TabStop = false;
			this.st_FlagsGrp.Text = "FC00 0000 flags";
			// 
			// st_SpellResistance
			// 
			this.st_SpellResistance.Location = new System.Drawing.Point(5, 15);
			this.st_SpellResistance.Margin = new System.Windows.Forms.Padding(0);
			this.st_SpellResistance.Name = "st_SpellResistance";
			this.st_SpellResistance.Size = new System.Drawing.Size(225, 20);
			this.st_SpellResistance.TabIndex = 14;
			this.st_SpellResistance.Text = "has spell resistance";
			this.st_SpellResistance.UseVisualStyleBackColor = true;
			this.st_SpellResistance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_MindAffecting
			// 
			this.st_MindAffecting.Location = new System.Drawing.Point(5, 35);
			this.st_MindAffecting.Margin = new System.Windows.Forms.Padding(0);
			this.st_MindAffecting.Name = "st_MindAffecting";
			this.st_MindAffecting.Size = new System.Drawing.Size(225, 20);
			this.st_MindAffecting.TabIndex = 15;
			this.st_MindAffecting.Text = "is mind-affecting";
			this.st_MindAffecting.UseVisualStyleBackColor = true;
			this.st_MindAffecting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_AffectsFriendlies
			// 
			this.st_AffectsFriendlies.Location = new System.Drawing.Point(5, 55);
			this.st_AffectsFriendlies.Margin = new System.Windows.Forms.Padding(0);
			this.st_AffectsFriendlies.Name = "st_AffectsFriendlies";
			this.st_AffectsFriendlies.Size = new System.Drawing.Size(225, 20);
			this.st_AffectsFriendlies.TabIndex = 16;
			this.st_AffectsFriendlies.Text = "can affect allies";
			this.st_AffectsFriendlies.UseVisualStyleBackColor = true;
			this.st_AffectsFriendlies.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_TouchRanged
			// 
			this.st_TouchRanged.Location = new System.Drawing.Point(5, 95);
			this.st_TouchRanged.Margin = new System.Windows.Forms.Padding(0);
			this.st_TouchRanged.Name = "st_TouchRanged";
			this.st_TouchRanged.Size = new System.Drawing.Size(225, 20);
			this.st_TouchRanged.TabIndex = 19;
			this.st_TouchRanged.Text = "requires ranged touch attack";
			this.st_TouchRanged.UseVisualStyleBackColor = true;
			this.st_TouchRanged.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_TouchMelee
			// 
			this.st_TouchMelee.Location = new System.Drawing.Point(5, 75);
			this.st_TouchMelee.Margin = new System.Windows.Forms.Padding(0);
			this.st_TouchMelee.Name = "st_TouchMelee";
			this.st_TouchMelee.Size = new System.Drawing.Size(225, 20);
			this.st_TouchMelee.TabIndex = 18;
			this.st_TouchMelee.Text = "requires melee touch attack";
			this.st_TouchMelee.UseVisualStyleBackColor = true;
			this.st_TouchMelee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_Impact1Grp
			// 
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_damageevasion);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_effectdamage);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_damagehalf);
			this.st_Impact1Grp.Controls.Add(this.st_Impact1rb_effectonly);
			this.st_Impact1Grp.Location = new System.Drawing.Point(145, 15);
			this.st_Impact1Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1Grp.Name = "st_Impact1Grp";
			this.st_Impact1Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Impact1Grp.Size = new System.Drawing.Size(140, 105);
			this.st_Impact1Grp.TabIndex = 26;
			this.st_Impact1Grp.TabStop = false;
			this.st_Impact1Grp.Text = "0030 0000 damage1";
			// 
			// st_Impact1rb_damageevasion
			// 
			this.st_Impact1rb_damageevasion.Location = new System.Drawing.Point(5, 75);
			this.st_Impact1rb_damageevasion.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_damageevasion.Name = "st_Impact1rb_damageevasion";
			this.st_Impact1rb_damageevasion.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_damageevasion.TabIndex = 4;
			this.st_Impact1rb_damageevasion.TabStop = true;
			this.st_Impact1rb_damageevasion.Text = "evasion";
			this.st_Impact1rb_damageevasion.UseVisualStyleBackColor = true;
			this.st_Impact1rb_damageevasion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Damage);
			// 
			// st_Impact1rb_effectdamage
			// 
			this.st_Impact1rb_effectdamage.Location = new System.Drawing.Point(5, 55);
			this.st_Impact1rb_effectdamage.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_effectdamage.Name = "st_Impact1rb_effectdamage";
			this.st_Impact1rb_effectdamage.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_effectdamage.TabIndex = 3;
			this.st_Impact1rb_effectdamage.TabStop = true;
			this.st_Impact1rb_effectdamage.Text = "regular";
			this.st_Impact1rb_effectdamage.UseVisualStyleBackColor = true;
			this.st_Impact1rb_effectdamage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Damage);
			// 
			// st_Impact1rb_damagehalf
			// 
			this.st_Impact1rb_damagehalf.Location = new System.Drawing.Point(5, 35);
			this.st_Impact1rb_damagehalf.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_damagehalf.Name = "st_Impact1rb_damagehalf";
			this.st_Impact1rb_damagehalf.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_damagehalf.TabIndex = 2;
			this.st_Impact1rb_damagehalf.TabStop = true;
			this.st_Impact1rb_damagehalf.Text = "half";
			this.st_Impact1rb_damagehalf.UseVisualStyleBackColor = true;
			this.st_Impact1rb_damagehalf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Damage);
			// 
			// st_Impact1rb_effectonly
			// 
			this.st_Impact1rb_effectonly.Location = new System.Drawing.Point(5, 15);
			this.st_Impact1rb_effectonly.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact1rb_effectonly.Name = "st_Impact1rb_effectonly";
			this.st_Impact1rb_effectonly.Size = new System.Drawing.Size(75, 20);
			this.st_Impact1rb_effectonly.TabIndex = 1;
			this.st_Impact1rb_effectonly.TabStop = true;
			this.st_Impact1rb_effectonly.Text = "none";
			this.st_Impact1rb_effectonly.UseVisualStyleBackColor = true;
			this.st_Impact1rb_effectonly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Damage);
			// 
			// st_Impact2Grp
			// 
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_damageevasion);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_effectdamage);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_damagehalf);
			this.st_Impact2Grp.Controls.Add(this.st_Impact2rb_effectonly);
			this.st_Impact2Grp.Location = new System.Drawing.Point(145, 120);
			this.st_Impact2Grp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2Grp.Name = "st_Impact2Grp";
			this.st_Impact2Grp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Impact2Grp.Size = new System.Drawing.Size(140, 105);
			this.st_Impact2Grp.TabIndex = 27;
			this.st_Impact2Grp.TabStop = false;
			this.st_Impact2Grp.Text = "0300 0000 damage2";
			// 
			// st_Impact2rb_damageevasion
			// 
			this.st_Impact2rb_damageevasion.Location = new System.Drawing.Point(5, 75);
			this.st_Impact2rb_damageevasion.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_damageevasion.Name = "st_Impact2rb_damageevasion";
			this.st_Impact2rb_damageevasion.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_damageevasion.TabIndex = 8;
			this.st_Impact2rb_damageevasion.TabStop = true;
			this.st_Impact2rb_damageevasion.Text = "evasion";
			this.st_Impact2rb_damageevasion.UseVisualStyleBackColor = true;
			this.st_Impact2rb_damageevasion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Damage);
			// 
			// st_Impact2rb_effectdamage
			// 
			this.st_Impact2rb_effectdamage.Location = new System.Drawing.Point(5, 55);
			this.st_Impact2rb_effectdamage.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_effectdamage.Name = "st_Impact2rb_effectdamage";
			this.st_Impact2rb_effectdamage.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_effectdamage.TabIndex = 7;
			this.st_Impact2rb_effectdamage.TabStop = true;
			this.st_Impact2rb_effectdamage.Text = "regular";
			this.st_Impact2rb_effectdamage.UseVisualStyleBackColor = true;
			this.st_Impact2rb_effectdamage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Damage);
			// 
			// st_Impact2rb_damagehalf
			// 
			this.st_Impact2rb_damagehalf.Location = new System.Drawing.Point(5, 35);
			this.st_Impact2rb_damagehalf.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_damagehalf.Name = "st_Impact2rb_damagehalf";
			this.st_Impact2rb_damagehalf.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_damagehalf.TabIndex = 6;
			this.st_Impact2rb_damagehalf.TabStop = true;
			this.st_Impact2rb_damagehalf.Text = "half";
			this.st_Impact2rb_damagehalf.UseVisualStyleBackColor = true;
			this.st_Impact2rb_damagehalf.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Damage);
			// 
			// st_Impact2rb_effectonly
			// 
			this.st_Impact2rb_effectonly.Location = new System.Drawing.Point(5, 15);
			this.st_Impact2rb_effectonly.Margin = new System.Windows.Forms.Padding(0);
			this.st_Impact2rb_effectonly.Name = "st_Impact2rb_effectonly";
			this.st_Impact2rb_effectonly.Size = new System.Drawing.Size(75, 20);
			this.st_Impact2rb_effectonly.TabIndex = 5;
			this.st_Impact2rb_effectonly.TabStop = true;
			this.st_Impact2rb_effectonly.Text = "none";
			this.st_Impact2rb_effectonly.UseVisualStyleBackColor = true;
			this.st_Impact2rb_effectonly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Damage);
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
			this.st_Save2Grp.TabIndex = 23;
			this.st_Save2Grp.TabStop = false;
			this.st_Save2Grp.Text = "00C0 0000 save2";
			// 
			// st_Save2rb_will
			// 
			this.st_Save2rb_will.Location = new System.Drawing.Point(5, 75);
			this.st_Save2rb_will.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_will.Name = "st_Save2rb_will";
			this.st_Save2rb_will.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_will.TabIndex = 7;
			this.st_Save2rb_will.TabStop = true;
			this.st_Save2rb_will.Text = "will";
			this.st_Save2rb_will.UseVisualStyleBackColor = true;
			this.st_Save2rb_will.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Save);
			// 
			// st_Save2rb_refl
			// 
			this.st_Save2rb_refl.Location = new System.Drawing.Point(5, 55);
			this.st_Save2rb_refl.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_refl.Name = "st_Save2rb_refl";
			this.st_Save2rb_refl.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_refl.TabIndex = 6;
			this.st_Save2rb_refl.TabStop = true;
			this.st_Save2rb_refl.Text = "reflex";
			this.st_Save2rb_refl.UseVisualStyleBackColor = true;
			this.st_Save2rb_refl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Save);
			// 
			// st_Save2rb_fort
			// 
			this.st_Save2rb_fort.Location = new System.Drawing.Point(5, 35);
			this.st_Save2rb_fort.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_fort.Name = "st_Save2rb_fort";
			this.st_Save2rb_fort.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_fort.TabIndex = 5;
			this.st_Save2rb_fort.TabStop = true;
			this.st_Save2rb_fort.Text = "fortitude";
			this.st_Save2rb_fort.UseVisualStyleBackColor = true;
			this.st_Save2rb_fort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Save);
			// 
			// st_Save2rb_none
			// 
			this.st_Save2rb_none.Location = new System.Drawing.Point(5, 15);
			this.st_Save2rb_none.Margin = new System.Windows.Forms.Padding(0);
			this.st_Save2rb_none.Name = "st_Save2rb_none";
			this.st_Save2rb_none.Size = new System.Drawing.Size(90, 20);
			this.st_Save2rb_none.TabIndex = 4;
			this.st_Save2rb_none.TabStop = true;
			this.st_Save2rb_none.Text = "none";
			this.st_Save2rb_none.UseVisualStyleBackColor = true;
			this.st_Save2rb_none.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type2Save);
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
			this.st_Save1Grp.TabIndex = 22;
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
			this.st_Save1rb_will.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Save);
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
			this.st_Save1rb_refl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Save);
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
			this.st_Save1rb_fort.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Save);
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
			this.st_Save1rb_none.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Type1Save);
			// 
			// st_ExclusiveGrp
			// 
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_FlagsGrp);
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_WeightGrp);
			this.st_ExclusiveGrp.Controls.Add(this.st_Excl_DamagetypesGrp);
			this.st_ExclusiveGrp.Location = new System.Drawing.Point(540, 60);
			this.st_ExclusiveGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_ExclusiveGrp.Name = "st_ExclusiveGrp";
			this.st_ExclusiveGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_ExclusiveGrp.Size = new System.Drawing.Size(270, 280);
			this.st_ExclusiveGrp.TabIndex = 36;
			this.st_ExclusiveGrp.TabStop = false;
			this.st_ExclusiveGrp.Text = "buff - energy resistance/immunity";
			// 
			// st_Excl_FlagsGrp
			// 
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_rbResistance);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_rbImmunity);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_General);
			this.st_Excl_FlagsGrp.Controls.Add(this.st_Excl_Onlyone);
			this.st_Excl_FlagsGrp.Location = new System.Drawing.Point(135, 55);
			this.st_Excl_FlagsGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_FlagsGrp.Name = "st_Excl_FlagsGrp";
			this.st_Excl_FlagsGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_FlagsGrp.Size = new System.Drawing.Size(130, 100);
			this.st_Excl_FlagsGrp.TabIndex = 11;
			this.st_Excl_FlagsGrp.TabStop = false;
			this.st_Excl_FlagsGrp.Text = "0070 0000 flags";
			// 
			// st_Excl_rbResistance
			// 
			this.st_Excl_rbResistance.Location = new System.Drawing.Point(5, 35);
			this.st_Excl_rbResistance.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_rbResistance.Name = "st_Excl_rbResistance";
			this.st_Excl_rbResistance.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_rbResistance.TabIndex = 4;
			this.st_Excl_rbResistance.TabStop = true;
			this.st_Excl_rbResistance.Text = "is Resistance";
			this.st_Excl_rbResistance.UseVisualStyleBackColor = true;
			this.st_Excl_rbResistance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Flags);
			// 
			// st_Excl_rbImmunity
			// 
			this.st_Excl_rbImmunity.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_rbImmunity.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_rbImmunity.Name = "st_Excl_rbImmunity";
			this.st_Excl_rbImmunity.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_rbImmunity.TabIndex = 3;
			this.st_Excl_rbImmunity.TabStop = true;
			this.st_Excl_rbImmunity.Text = "is Immunity";
			this.st_Excl_rbImmunity.UseVisualStyleBackColor = true;
			this.st_Excl_rbImmunity.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Flags);
			// 
			// st_Excl_General
			// 
			this.st_Excl_General.Location = new System.Drawing.Point(5, 75);
			this.st_Excl_General.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_General.Name = "st_Excl_General";
			this.st_Excl_General.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_General.TabIndex = 2;
			this.st_Excl_General.Text = "general";
			this.toolTip1.SetToolTip(this.st_Excl_General, "base the spell-weight on the threat-weight rather than (adjusted) effect-weight");
			this.st_Excl_General.UseVisualStyleBackColor = true;
			this.st_Excl_General.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Flags);
			// 
			// st_Excl_Onlyone
			// 
			this.st_Excl_Onlyone.Location = new System.Drawing.Point(5, 55);
			this.st_Excl_Onlyone.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Onlyone.Name = "st_Excl_Onlyone";
			this.st_Excl_Onlyone.Size = new System.Drawing.Size(120, 20);
			this.st_Excl_Onlyone.TabIndex = 1;
			this.st_Excl_Onlyone.Text = "only one type";
			this.toolTip1.SetToolTip(this.st_Excl_Onlyone, "is NOT Multi-energy damage Resistance/Immunity buff");
			this.st_Excl_Onlyone.UseVisualStyleBackColor = true;
			this.st_Excl_Onlyone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Flags);
			// 
			// st_Excl_WeightGrp
			// 
			this.st_Excl_WeightGrp.Controls.Add(this.st_Excl_Weight);
			this.st_Excl_WeightGrp.Location = new System.Drawing.Point(135, 15);
			this.st_Excl_WeightGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_WeightGrp.Name = "st_Excl_WeightGrp";
			this.st_Excl_WeightGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_WeightGrp.Size = new System.Drawing.Size(130, 40);
			this.st_Excl_WeightGrp.TabIndex = 10;
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
			this.st_Excl_Weight.TextChanged += new System.EventHandler(this.TextChanged_st_excl_Weight);
			// 
			// st_Excl_DamagetypesGrp
			// 
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Sonic);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Positive);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Negative);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Fire);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Electrical);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Divine);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Cold);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Acid);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Magical);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Slashing);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Piercing);
			this.st_Excl_DamagetypesGrp.Controls.Add(this.st_Excl_Bludgeoning);
			this.st_Excl_DamagetypesGrp.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_DamagetypesGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_DamagetypesGrp.Name = "st_Excl_DamagetypesGrp";
			this.st_Excl_DamagetypesGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_Excl_DamagetypesGrp.Size = new System.Drawing.Size(130, 260);
			this.st_Excl_DamagetypesGrp.TabIndex = 9;
			this.st_Excl_DamagetypesGrp.TabStop = false;
			this.st_Excl_DamagetypesGrp.Text = "0000 0FFF type";
			// 
			// st_Excl_Sonic
			// 
			this.st_Excl_Sonic.Location = new System.Drawing.Point(5, 235);
			this.st_Excl_Sonic.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Sonic.Name = "st_Excl_Sonic";
			this.st_Excl_Sonic.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Sonic.TabIndex = 12;
			this.st_Excl_Sonic.Text = "sonic";
			this.st_Excl_Sonic.UseVisualStyleBackColor = true;
			this.st_Excl_Sonic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Positive
			// 
			this.st_Excl_Positive.Location = new System.Drawing.Point(5, 215);
			this.st_Excl_Positive.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Positive.Name = "st_Excl_Positive";
			this.st_Excl_Positive.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Positive.TabIndex = 11;
			this.st_Excl_Positive.Text = "positive";
			this.st_Excl_Positive.UseVisualStyleBackColor = true;
			this.st_Excl_Positive.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Negative
			// 
			this.st_Excl_Negative.Location = new System.Drawing.Point(5, 195);
			this.st_Excl_Negative.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Negative.Name = "st_Excl_Negative";
			this.st_Excl_Negative.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Negative.TabIndex = 10;
			this.st_Excl_Negative.Text = "negative";
			this.st_Excl_Negative.UseVisualStyleBackColor = true;
			this.st_Excl_Negative.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Fire
			// 
			this.st_Excl_Fire.Location = new System.Drawing.Point(5, 175);
			this.st_Excl_Fire.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Fire.Name = "st_Excl_Fire";
			this.st_Excl_Fire.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Fire.TabIndex = 9;
			this.st_Excl_Fire.Text = "fire";
			this.st_Excl_Fire.UseVisualStyleBackColor = true;
			this.st_Excl_Fire.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Electrical
			// 
			this.st_Excl_Electrical.Location = new System.Drawing.Point(5, 155);
			this.st_Excl_Electrical.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Electrical.Name = "st_Excl_Electrical";
			this.st_Excl_Electrical.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Electrical.TabIndex = 8;
			this.st_Excl_Electrical.Text = "electrical";
			this.st_Excl_Electrical.UseVisualStyleBackColor = true;
			this.st_Excl_Electrical.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Divine
			// 
			this.st_Excl_Divine.Location = new System.Drawing.Point(5, 135);
			this.st_Excl_Divine.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Divine.Name = "st_Excl_Divine";
			this.st_Excl_Divine.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Divine.TabIndex = 7;
			this.st_Excl_Divine.Text = "divine";
			this.st_Excl_Divine.UseVisualStyleBackColor = true;
			this.st_Excl_Divine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Cold
			// 
			this.st_Excl_Cold.Location = new System.Drawing.Point(5, 115);
			this.st_Excl_Cold.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Cold.Name = "st_Excl_Cold";
			this.st_Excl_Cold.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Cold.TabIndex = 6;
			this.st_Excl_Cold.Text = "cold";
			this.st_Excl_Cold.UseVisualStyleBackColor = true;
			this.st_Excl_Cold.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Acid
			// 
			this.st_Excl_Acid.Location = new System.Drawing.Point(5, 95);
			this.st_Excl_Acid.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Acid.Name = "st_Excl_Acid";
			this.st_Excl_Acid.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Acid.TabIndex = 5;
			this.st_Excl_Acid.Text = "acid";
			this.st_Excl_Acid.UseVisualStyleBackColor = true;
			this.st_Excl_Acid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Magical
			// 
			this.st_Excl_Magical.Location = new System.Drawing.Point(5, 75);
			this.st_Excl_Magical.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Magical.Name = "st_Excl_Magical";
			this.st_Excl_Magical.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Magical.TabIndex = 4;
			this.st_Excl_Magical.Text = "magical";
			this.st_Excl_Magical.UseVisualStyleBackColor = true;
			this.st_Excl_Magical.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Slashing
			// 
			this.st_Excl_Slashing.Location = new System.Drawing.Point(5, 55);
			this.st_Excl_Slashing.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Slashing.Name = "st_Excl_Slashing";
			this.st_Excl_Slashing.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Slashing.TabIndex = 3;
			this.st_Excl_Slashing.Text = "slashing";
			this.st_Excl_Slashing.UseVisualStyleBackColor = true;
			this.st_Excl_Slashing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Piercing
			// 
			this.st_Excl_Piercing.Location = new System.Drawing.Point(5, 35);
			this.st_Excl_Piercing.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Piercing.Name = "st_Excl_Piercing";
			this.st_Excl_Piercing.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Piercing.TabIndex = 2;
			this.st_Excl_Piercing.Text = "piercing";
			this.st_Excl_Piercing.UseVisualStyleBackColor = true;
			this.st_Excl_Piercing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_Excl_Bludgeoning
			// 
			this.st_Excl_Bludgeoning.Location = new System.Drawing.Point(5, 15);
			this.st_Excl_Bludgeoning.Margin = new System.Windows.Forms.Padding(0);
			this.st_Excl_Bludgeoning.Name = "st_Excl_Bludgeoning";
			this.st_Excl_Bludgeoning.Size = new System.Drawing.Size(105, 20);
			this.st_Excl_Bludgeoning.TabIndex = 1;
			this.st_Excl_Bludgeoning.Text = "bludgeoning";
			this.st_Excl_Bludgeoning.UseVisualStyleBackColor = true;
			this.st_Excl_Bludgeoning.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_excl_Damagetype);
			// 
			// st_bin
			// 
			this.st_bin.Location = new System.Drawing.Point(395, 35);
			this.st_bin.Margin = new System.Windows.Forms.Padding(0);
			this.st_bin.Name = "st_bin";
			this.st_bin.Size = new System.Drawing.Size(45, 15);
			this.st_bin.TabIndex = 35;
			this.st_bin.Text = "- bin";
			this.st_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// st_hex
			// 
			this.st_hex.Location = new System.Drawing.Point(395, 15);
			this.st_hex.Margin = new System.Windows.Forms.Padding(0);
			this.st_hex.Name = "st_hex";
			this.st_hex.Size = new System.Drawing.Size(45, 15);
			this.st_hex.TabIndex = 34;
			this.st_hex.Text = "- hex";
			this.st_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// st_NotCaster
			// 
			this.st_NotCaster.Location = new System.Drawing.Point(10, 340);
			this.st_NotCaster.Margin = new System.Windows.Forms.Padding(0);
			this.st_NotCaster.Name = "st_NotCaster";
			this.st_NotCaster.Size = new System.Drawing.Size(225, 20);
			this.st_NotCaster.TabIndex = 17;
			this.st_NotCaster.Text = "does not affect caster";
			this.st_NotCaster.UseVisualStyleBackColor = true;
			this.st_NotCaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_st_Flags);
			// 
			// st_Clear
			// 
			this.st_Clear.Location = new System.Drawing.Point(450, 5);
			this.st_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.st_Clear.Name = "st_Clear";
			this.st_Clear.Size = new System.Drawing.Size(65, 50);
			this.st_Clear.TabIndex = 33;
			this.st_Clear.Text = "zero\r\nall\r\nbits";
			this.st_Clear.UseVisualStyleBackColor = true;
			this.st_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.SaveType_bin.TabIndex = 32;
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
			this.SaveType_hex.TabIndex = 32;
			// 
			// st_AcBonusGrp
			// 
			this.st_AcBonusGrp.Controls.Add(this.cbo_st_AcBonus);
			this.st_AcBonusGrp.Location = new System.Drawing.Point(525, 360);
			this.st_AcBonusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_AcBonusGrp.Name = "st_AcBonusGrp";
			this.st_AcBonusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_AcBonusGrp.Size = new System.Drawing.Size(195, 45);
			this.st_AcBonusGrp.TabIndex = 28;
			this.st_AcBonusGrp.TabStop = false;
			this.st_AcBonusGrp.Text = "001C 0000 ac";
			// 
			// cbo_st_AcBonus
			// 
			this.cbo_st_AcBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_st_AcBonus.FormattingEnabled = true;
			this.cbo_st_AcBonus.Location = new System.Drawing.Point(5, 15);
			this.cbo_st_AcBonus.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_st_AcBonus.Name = "cbo_st_AcBonus";
			this.cbo_st_AcBonus.Size = new System.Drawing.Size(185, 22);
			this.cbo_st_AcBonus.TabIndex = 0;
			this.cbo_st_AcBonus.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_st_cbo_AcBonus);
			// 
			// st_TargetRestrictionGrp
			// 
			this.st_TargetRestrictionGrp.Controls.Add(this.cbo_st_TargetRestriction);
			this.st_TargetRestrictionGrp.Location = new System.Drawing.Point(5, 360);
			this.st_TargetRestrictionGrp.Margin = new System.Windows.Forms.Padding(0);
			this.st_TargetRestrictionGrp.Name = "st_TargetRestrictionGrp";
			this.st_TargetRestrictionGrp.Padding = new System.Windows.Forms.Padding(0);
			this.st_TargetRestrictionGrp.Size = new System.Drawing.Size(520, 45);
			this.st_TargetRestrictionGrp.TabIndex = 27;
			this.st_TargetRestrictionGrp.TabStop = false;
			this.st_TargetRestrictionGrp.Text = "0000 101F targetrestriction";
			// 
			// cbo_st_TargetRestriction
			// 
			this.cbo_st_TargetRestriction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_st_TargetRestriction.DropDownWidth = 510;
			this.cbo_st_TargetRestriction.FormattingEnabled = true;
			this.cbo_st_TargetRestriction.Location = new System.Drawing.Point(5, 15);
			this.cbo_st_TargetRestriction.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_st_TargetRestriction.Name = "cbo_st_TargetRestriction";
			this.cbo_st_TargetRestriction.Size = new System.Drawing.Size(510, 22);
			this.cbo_st_TargetRestriction.TabIndex = 0;
			this.cbo_st_TargetRestriction.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_st_cbo_Weapon);
			// 
			// SaveType_text
			// 
			this.SaveType_text.Location = new System.Drawing.Point(5, 35);
			this.SaveType_text.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_text.Name = "SaveType_text";
			this.SaveType_text.Size = new System.Drawing.Size(100, 20);
			this.SaveType_text.TabIndex = 13;
			this.SaveType_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SaveType_text.TextChanged += new System.EventHandler(this.TextChanged_st);
			// 
			// SaveType_reset
			// 
			this.SaveType_reset.Location = new System.Drawing.Point(5, 5);
			this.SaveType_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SaveType_reset.Name = "SaveType_reset";
			this.SaveType_reset.Size = new System.Drawing.Size(100, 25);
			this.SaveType_reset.TabIndex = 5;
			this.toolTip1.SetToolTip(this.SaveType_reset, "reset");
			this.SaveType_reset.UseVisualStyleBackColor = true;
			this.SaveType_reset.Click += new System.EventHandler(this.Click_st_reset);
			// 
			// page_SaveDCType
			// 
			this.page_SaveDCType.Controls.Add(this.dc_bin);
			this.page_SaveDCType.Controls.Add(this.dc_hex);
			this.page_SaveDCType.Controls.Add(this.dc_Clear);
			this.page_SaveDCType.Controls.Add(this.SaveDCType_bin);
			this.page_SaveDCType.Controls.Add(this.SaveDCType_hex);
			this.page_SaveDCType.Controls.Add(this.dc_ArmorCheckGrp);
			this.page_SaveDCType.Controls.Add(this.SaveDCType_text);
			this.page_SaveDCType.Controls.Add(this.dc_WeaponBonusGrp);
			this.page_SaveDCType.Controls.Add(this.dc_SaveDCGrp);
			this.page_SaveDCType.Controls.Add(this.savedctype_label);
			this.page_SaveDCType.Controls.Add(this.SaveDCType_reset);
			this.page_SaveDCType.Location = new System.Drawing.Point(4, 23);
			this.page_SaveDCType.Margin = new System.Windows.Forms.Padding(2);
			this.page_SaveDCType.Name = "page_SaveDCType";
			this.page_SaveDCType.Padding = new System.Windows.Forms.Padding(2);
			this.page_SaveDCType.Size = new System.Drawing.Size(812, 428);
			this.page_SaveDCType.TabIndex = 6;
			this.page_SaveDCType.Text = "SaveDCType";
			this.page_SaveDCType.UseVisualStyleBackColor = true;
			// 
			// dc_bin
			// 
			this.dc_bin.Location = new System.Drawing.Point(395, 35);
			this.dc_bin.Margin = new System.Windows.Forms.Padding(0);
			this.dc_bin.Name = "dc_bin";
			this.dc_bin.Size = new System.Drawing.Size(45, 15);
			this.dc_bin.TabIndex = 38;
			this.dc_bin.Text = "- bin";
			this.dc_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dc_hex
			// 
			this.dc_hex.Location = new System.Drawing.Point(395, 15);
			this.dc_hex.Margin = new System.Windows.Forms.Padding(0);
			this.dc_hex.Name = "dc_hex";
			this.dc_hex.Size = new System.Drawing.Size(45, 15);
			this.dc_hex.TabIndex = 37;
			this.dc_hex.Text = "- hex";
			this.dc_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dc_Clear
			// 
			this.dc_Clear.Location = new System.Drawing.Point(450, 5);
			this.dc_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.dc_Clear.Name = "dc_Clear";
			this.dc_Clear.Size = new System.Drawing.Size(65, 50);
			this.dc_Clear.TabIndex = 36;
			this.dc_Clear.Text = "zero\r\nall\r\nbits";
			this.dc_Clear.UseVisualStyleBackColor = true;
			this.dc_Clear.Click += new System.EventHandler(this.Click_clear);
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
			this.SaveDCType_bin.TabIndex = 34;
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
			this.SaveDCType_hex.TabIndex = 33;
			// 
			// dc_ArmorCheckGrp
			// 
			this.dc_ArmorCheckGrp.Controls.Add(this.armorcheck_info);
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac3);
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac1);
			this.dc_ArmorCheckGrp.Controls.Add(this.savedc_ac2);
			this.dc_ArmorCheckGrp.Location = new System.Drawing.Point(345, 105);
			this.dc_ArmorCheckGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_ArmorCheckGrp.Name = "dc_ArmorCheckGrp";
			this.dc_ArmorCheckGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_ArmorCheckGrp.Size = new System.Drawing.Size(315, 270);
			this.dc_ArmorCheckGrp.TabIndex = 13;
			this.dc_ArmorCheckGrp.TabStop = false;
			this.dc_ArmorCheckGrp.Text = "1000 0003 armorcheck";
			// 
			// armorcheck_info
			// 
			this.armorcheck_info.Location = new System.Drawing.Point(5, 85);
			this.armorcheck_info.Margin = new System.Windows.Forms.Padding(0);
			this.armorcheck_info.Name = "armorcheck_info";
			this.armorcheck_info.Size = new System.Drawing.Size(305, 140);
			this.armorcheck_info.TabIndex = 5;
			this.armorcheck_info.Text = resources.GetString("armorcheck_info.Text");
			// 
			// savedc_ac3
			// 
			this.savedc_ac3.Location = new System.Drawing.Point(10, 55);
			this.savedc_ac3.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac3.Name = "savedc_ac3";
			this.savedc_ac3.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac3.TabIndex = 4;
			this.savedc_ac3.Text = "target must be immune to speed decrease";
			this.savedc_ac3.UseVisualStyleBackColor = true;
			this.savedc_ac3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_dc_armorchecktype);
			// 
			// savedc_ac1
			// 
			this.savedc_ac1.Location = new System.Drawing.Point(10, 15);
			this.savedc_ac1.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac1.Name = "savedc_ac1";
			this.savedc_ac1.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac1.TabIndex = 2;
			this.savedc_ac1.Text = "target must be wearing armor";
			this.savedc_ac1.UseVisualStyleBackColor = true;
			this.savedc_ac1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_dc_armorchecktype);
			// 
			// savedc_ac2
			// 
			this.savedc_ac2.Location = new System.Drawing.Point(10, 35);
			this.savedc_ac2.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_ac2.Name = "savedc_ac2";
			this.savedc_ac2.Size = new System.Drawing.Size(300, 20);
			this.savedc_ac2.TabIndex = 3;
			this.savedc_ac2.Text = "target must be using a shield";
			this.savedc_ac2.UseVisualStyleBackColor = true;
			this.savedc_ac2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_dc_armorchecktype);
			// 
			// SaveDCType_text
			// 
			this.SaveDCType_text.Location = new System.Drawing.Point(5, 35);
			this.SaveDCType_text.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_text.Name = "SaveDCType_text";
			this.SaveDCType_text.Size = new System.Drawing.Size(100, 20);
			this.SaveDCType_text.TabIndex = 12;
			this.SaveDCType_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.SaveDCType_text.TextChanged += new System.EventHandler(this.TextChanged_dc);
			// 
			// dc_WeaponBonusGrp
			// 
			this.dc_WeaponBonusGrp.Controls.Add(this.cbo_dc_WeaponBonus);
			this.dc_WeaponBonusGrp.Location = new System.Drawing.Point(345, 60);
			this.dc_WeaponBonusGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_WeaponBonusGrp.Name = "dc_WeaponBonusGrp";
			this.dc_WeaponBonusGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_WeaponBonusGrp.Size = new System.Drawing.Size(315, 45);
			this.dc_WeaponBonusGrp.TabIndex = 11;
			this.dc_WeaponBonusGrp.TabStop = false;
			this.dc_WeaponBonusGrp.Text = "0000 0067 weaponbonus";
			// 
			// cbo_dc_WeaponBonus
			// 
			this.cbo_dc_WeaponBonus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_dc_WeaponBonus.FormattingEnabled = true;
			this.cbo_dc_WeaponBonus.Location = new System.Drawing.Point(5, 15);
			this.cbo_dc_WeaponBonus.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_dc_WeaponBonus.Name = "cbo_dc_WeaponBonus";
			this.cbo_dc_WeaponBonus.Size = new System.Drawing.Size(305, 22);
			this.cbo_dc_WeaponBonus.TabIndex = 1;
			this.cbo_dc_WeaponBonus.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_dc_weaponbonustype);
			// 
			// dc_SaveDCGrp
			// 
			this.dc_SaveDCGrp.Controls.Add(this.savedc_info);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_adjustor_info);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_dn);
			this.dc_SaveDCGrp.Controls.Add(this.savedc_up);
			this.dc_SaveDCGrp.Controls.Add(this.cbo_dc_SaveDC);
			this.dc_SaveDCGrp.Location = new System.Drawing.Point(5, 60);
			this.dc_SaveDCGrp.Margin = new System.Windows.Forms.Padding(0);
			this.dc_SaveDCGrp.Name = "dc_SaveDCGrp";
			this.dc_SaveDCGrp.Padding = new System.Windows.Forms.Padding(0);
			this.dc_SaveDCGrp.Size = new System.Drawing.Size(340, 315);
			this.dc_SaveDCGrp.TabIndex = 10;
			this.dc_SaveDCGrp.TabStop = false;
			this.dc_SaveDCGrp.Text = "FFFF FFFF savedc";
			// 
			// savedc_info
			// 
			this.savedc_info.Location = new System.Drawing.Point(5, 180);
			this.savedc_info.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_info.Name = "savedc_info";
			this.savedc_info.Size = new System.Drawing.Size(330, 130);
			this.savedc_info.TabIndex = 4;
			this.savedc_info.Text = resources.GetString("savedc_info.Text");
			// 
			// savedc_adjustor_info
			// 
			this.savedc_adjustor_info.Location = new System.Drawing.Point(40, 45);
			this.savedc_adjustor_info.Margin = new System.Windows.Forms.Padding(0);
			this.savedc_adjustor_info.Name = "savedc_adjustor_info";
			this.savedc_adjustor_info.Size = new System.Drawing.Size(295, 130);
			this.savedc_adjustor_info.TabIndex = 3;
			this.savedc_adjustor_info.Text = resources.GetString("savedc_adjustor_info.Text");
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
			this.savedc_dn.Click += new System.EventHandler(this.Click_dc_adjustors);
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
			this.savedc_up.Click += new System.EventHandler(this.Click_dc_adjustors);
			// 
			// cbo_dc_SaveDC
			// 
			this.cbo_dc_SaveDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_dc_SaveDC.FormattingEnabled = true;
			this.cbo_dc_SaveDC.Location = new System.Drawing.Point(5, 15);
			this.cbo_dc_SaveDC.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_dc_SaveDC.Name = "cbo_dc_SaveDC";
			this.cbo_dc_SaveDC.Size = new System.Drawing.Size(330, 22);
			this.cbo_dc_SaveDC.TabIndex = 0;
			this.cbo_dc_SaveDC.SelectionChangeCommitted += new System.EventHandler(this.SelectionChangeCommitted_dc_savedctype);
			// 
			// savedctype_label
			// 
			this.savedctype_label.Location = new System.Drawing.Point(5, 380);
			this.savedctype_label.Margin = new System.Windows.Forms.Padding(0);
			this.savedctype_label.Name = "savedctype_label";
			this.savedctype_label.Size = new System.Drawing.Size(655, 45);
			this.savedctype_label.TabIndex = 9;
			this.savedctype_label.Text = resources.GetString("savedctype_label.Text");
			// 
			// SaveDCType_reset
			// 
			this.SaveDCType_reset.Location = new System.Drawing.Point(5, 5);
			this.SaveDCType_reset.Margin = new System.Windows.Forms.Padding(0);
			this.SaveDCType_reset.Name = "SaveDCType_reset";
			this.SaveDCType_reset.Size = new System.Drawing.Size(100, 25);
			this.SaveDCType_reset.TabIndex = 6;
			this.toolTip1.SetToolTip(this.SaveDCType_reset, "reset");
			this.SaveDCType_reset.UseVisualStyleBackColor = true;
			this.SaveDCType_reset.Click += new System.EventHandler(this.Click_dc_reset);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.file,
			this.edit,
			this.options,
			this.help});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(1352, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip";
			// 
			// file
			// 
			this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.Open,
			this.toolStripSeparator1,
			this.Save,
			this.Saveas,
			this.toolStripSeparator2,
			this.Quit});
			this.file.Name = "file";
			this.file.Size = new System.Drawing.Size(37, 20);
			this.file.Text = "File";
			// 
			// Open
			// 
			this.Open.Name = "Open";
			this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.Open.Size = new System.Drawing.Size(160, 22);
			this.Open.Text = "Open ...";
			this.Open.Click += new System.EventHandler(this.Click_open);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
			// 
			// Save
			// 
			this.Save.Name = "Save";
			this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.Save.Size = new System.Drawing.Size(160, 22);
			this.Save.Text = "Save";
			this.Save.Click += new System.EventHandler(this.Click_save);
			// 
			// Saveas
			// 
			this.Saveas.Name = "Saveas";
			this.Saveas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.Saveas.Size = new System.Drawing.Size(160, 22);
			this.Saveas.Text = "Save As ...";
			this.Saveas.Click += new System.EventHandler(this.Click_saveas);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
			// 
			// Quit
			// 
			this.Quit.Name = "Quit";
			this.Quit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.Quit.Size = new System.Drawing.Size(160, 22);
			this.Quit.Text = "Quit";
			this.Quit.Click += new System.EventHandler(this.Click_quit);
			// 
			// edit
			// 
			this.edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.FindNextChanged,
			this.toolStripSeparator3,
			this.Copy_decimal,
			this.Copy_hexadecimal,
			this.Copy_binary});
			this.edit.Name = "edit";
			this.edit.Size = new System.Drawing.Size(37, 20);
			this.edit.Text = "Edit";
			// 
			// FindNextChanged
			// 
			this.FindNextChanged.Name = "FindNextChanged";
			this.FindNextChanged.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.FindNextChanged.Size = new System.Drawing.Size(190, 22);
			this.FindNextChanged.Text = "Find next changed";
			this.FindNextChanged.Click += new System.EventHandler(this.Click_findnextchanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
			// 
			// Copy_decimal
			// 
			this.Copy_decimal.Name = "Copy_decimal";
			this.Copy_decimal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.Copy_decimal.Size = new System.Drawing.Size(190, 22);
			this.Copy_decimal.Text = "Copy decimal";
			this.Copy_decimal.Click += new System.EventHandler(this.Click_copy_decimal);
			// 
			// Copy_hexadecimal
			// 
			this.Copy_hexadecimal.Name = "Copy_hexadecimal";
			this.Copy_hexadecimal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.Copy_hexadecimal.Size = new System.Drawing.Size(190, 22);
			this.Copy_hexadecimal.Text = "Copy hexadecimal";
			this.Copy_hexadecimal.Click += new System.EventHandler(this.Click_copy_hexadecimal);
			// 
			// Copy_binary
			// 
			this.Copy_binary.Name = "Copy_binary";
			this.Copy_binary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.Copy_binary.Size = new System.Drawing.Size(190, 22);
			this.Copy_binary.Text = "Copy binary";
			this.Copy_binary.Click += new System.EventHandler(this.Click_copy_binary);
			// 
			// options
			// 
			this.options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.setCoreAIver});
			this.options.Name = "options";
			this.options.Size = new System.Drawing.Size(52, 20);
			this.options.Text = "Options";
			// 
			// setCoreAIver
			// 
			this.setCoreAIver.Name = "setCoreAIver";
			this.setCoreAIver.Size = new System.Drawing.Size(160, 22);
			this.setCoreAIver.Text = "Set CoreAI version";
			this.setCoreAIver.Click += new System.EventHandler(this.Click_setCoreAiVersion);
			// 
			// help
			// 
			this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.About});
			this.help.Name = "help";
			this.help.Size = new System.Drawing.Size(37, 20);
			this.help.Text = "Help";
			// 
			// About
			// 
			this.About.Name = "About";
			this.About.Size = new System.Drawing.Size(95, 22);
			this.About.Text = "About";
			this.About.Click += new System.EventHandler(this.Click_about);
			// 
			// Tree
			// 
			this.Tree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.Tree.FullRowSelect = true;
			this.Tree.HideSelection = false;
			this.Tree.Indent = 15;
			this.Tree.Location = new System.Drawing.Point(0, 20);
			this.Tree.Name = "Tree";
			this.Tree.Size = new System.Drawing.Size(275, 947);
			this.Tree.TabIndex = 2;
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelect_node);
			this.Tree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_search);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btn_Search_u);
			this.splitContainer1.Panel1.Controls.Add(this.btn_Search_d);
			this.splitContainer1.Panel1.Controls.Add(this.tb_Search);
			this.splitContainer1.Panel1.Controls.Add(this.Tree);
			this.splitContainer1.Panel1MinSize = 20;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.cols_HenchClasses);
			this.splitContainer1.Panel2.Controls.Add(this.cols_HenchRacial);
			this.splitContainer1.Panel2.Controls.Add(this.apply);
			this.splitContainer1.Panel2.Controls.Add(this.cols_HenchSpells);
			this.splitContainer1.Size = new System.Drawing.Size(1352, 969);
			this.splitContainer1.SplitterDistance = 275;
			this.splitContainer1.SplitterWidth = 3;
			this.splitContainer1.TabIndex = 3;
			// 
			// btn_Search_u
			// 
			this.btn_Search_u.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Search_u.Location = new System.Drawing.Point(245, 0);
			this.btn_Search_u.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Search_u.Name = "btn_Search_u";
			this.btn_Search_u.Size = new System.Drawing.Size(30, 20);
			this.btn_Search_u.TabIndex = 5;
			this.btn_Search_u.Text = "u";
			this.btn_Search_u.UseVisualStyleBackColor = true;
			this.btn_Search_u.Click += new System.EventHandler(this.Click_search);
			// 
			// btn_Search_d
			// 
			this.btn_Search_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Search_d.Location = new System.Drawing.Point(215, 0);
			this.btn_Search_d.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Search_d.Name = "btn_Search_d";
			this.btn_Search_d.Size = new System.Drawing.Size(30, 20);
			this.btn_Search_d.TabIndex = 4;
			this.btn_Search_d.Text = "d";
			this.btn_Search_d.UseVisualStyleBackColor = true;
			this.btn_Search_d.Click += new System.EventHandler(this.Click_search);
			// 
			// tb_Search
			// 
			this.tb_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tb_Search.Location = new System.Drawing.Point(0, 0);
			this.tb_Search.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Search.Name = "tb_Search";
			this.tb_Search.Size = new System.Drawing.Size(215, 20);
			this.tb_Search.TabIndex = 3;
			this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_search);
			// 
			// cols_HenchClasses
			// 
			this.cols_HenchClasses.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.cols_HenchClasses.Controls.Add(this.page_ClassFlags);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat1);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat2);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat3);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat4);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat5);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat6);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat7);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat8);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat9);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat10);
			this.cols_HenchClasses.Controls.Add(this.page_ClassFeat11);
			this.cols_HenchClasses.Location = new System.Drawing.Point(0, 730);
			this.cols_HenchClasses.Margin = new System.Windows.Forms.Padding(0);
			this.cols_HenchClasses.Name = "cols_HenchClasses";
			this.cols_HenchClasses.Padding = new System.Drawing.Point(5, 2);
			this.cols_HenchClasses.SelectedIndex = 0;
			this.cols_HenchClasses.Size = new System.Drawing.Size(1070, 210);
			this.cols_HenchClasses.TabIndex = 3;
			this.cols_HenchClasses.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_tab);
			// 
			// page_ClassFlags
			// 
			this.page_ClassFlags.Controls.Add(this.cf_infoversion);
			this.page_ClassFlags.Controls.Add(this.cf_infoversion_label);
			this.page_ClassFlags.Controls.Add(this.cf_HasFeatSpells);
			this.page_ClassFlags.Controls.Add(this.cf_bin);
			this.page_ClassFlags.Controls.Add(this.cf_hex);
			this.page_ClassFlags.Controls.Add(this.cf_Clear);
			this.page_ClassFlags.Controls.Add(this.ClassFlags_bin);
			this.page_ClassFlags.Controls.Add(this.ClassFlags_hex);
			this.page_ClassFlags.Controls.Add(this.ClassFlags_text);
			this.page_ClassFlags.Controls.Add(this.ClassFlags_reset);
			this.page_ClassFlags.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFlags.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFlags.Name = "page_ClassFlags";
			this.page_ClassFlags.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFlags.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFlags.TabIndex = 0;
			this.page_ClassFlags.Text = "Flags";
			this.page_ClassFlags.UseVisualStyleBackColor = true;
			// 
			// cf_infoversion
			// 
			this.cf_infoversion.Location = new System.Drawing.Point(520, 35);
			this.cf_infoversion.Margin = new System.Windows.Forms.Padding(0);
			this.cf_infoversion.Name = "cf_infoversion";
			this.cf_infoversion.Size = new System.Drawing.Size(95, 15);
			this.cf_infoversion.TabIndex = 57;
			this.cf_infoversion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// cf_infoversion_label
			// 
			this.cf_infoversion_label.Location = new System.Drawing.Point(520, 15);
			this.cf_infoversion_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf_infoversion_label.Name = "cf_infoversion_label";
			this.cf_infoversion_label.Size = new System.Drawing.Size(95, 15);
			this.cf_infoversion_label.TabIndex = 56;
			this.cf_infoversion_label.Text = "Info Version";
			// 
			// cf_HasFeatSpells
			// 
			this.cf_HasFeatSpells.Location = new System.Drawing.Point(15, 65);
			this.cf_HasFeatSpells.Margin = new System.Windows.Forms.Padding(0);
			this.cf_HasFeatSpells.Name = "cf_HasFeatSpells";
			this.cf_HasFeatSpells.Size = new System.Drawing.Size(125, 19);
			this.cf_HasFeatSpells.TabIndex = 55;
			this.cf_HasFeatSpells.Text = "has FeatSpells";
			this.cf_HasFeatSpells.UseVisualStyleBackColor = true;
			this.cf_HasFeatSpells.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFlags);
			// 
			// cf_bin
			// 
			this.cf_bin.Location = new System.Drawing.Point(395, 35);
			this.cf_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf_bin.Name = "cf_bin";
			this.cf_bin.Size = new System.Drawing.Size(45, 15);
			this.cf_bin.TabIndex = 54;
			this.cf_bin.Text = "- bin";
			this.cf_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf_hex
			// 
			this.cf_hex.Location = new System.Drawing.Point(395, 15);
			this.cf_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf_hex.Name = "cf_hex";
			this.cf_hex.Size = new System.Drawing.Size(45, 15);
			this.cf_hex.TabIndex = 53;
			this.cf_hex.Text = "- hex";
			this.cf_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf_Clear
			// 
			this.cf_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf_Clear.Name = "cf_Clear";
			this.cf_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf_Clear.TabIndex = 52;
			this.cf_Clear.Text = "zero\r\nall\r\nbits";
			this.cf_Clear.UseVisualStyleBackColor = true;
			this.cf_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFlags_bin
			// 
			this.ClassFlags_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFlags_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFlags_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFlags_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_bin.Name = "ClassFlags_bin";
			this.ClassFlags_bin.ReadOnly = true;
			this.ClassFlags_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFlags_bin.TabIndex = 50;
			// 
			// ClassFlags_hex
			// 
			this.ClassFlags_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFlags_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFlags_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFlags_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_hex.Name = "ClassFlags_hex";
			this.ClassFlags_hex.ReadOnly = true;
			this.ClassFlags_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFlags_hex.TabIndex = 51;
			// 
			// ClassFlags_text
			// 
			this.ClassFlags_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFlags_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_text.Name = "ClassFlags_text";
			this.ClassFlags_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFlags_text.TabIndex = 49;
			this.ClassFlags_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFlags_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFlags_reset
			// 
			this.ClassFlags_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFlags_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_reset.Name = "ClassFlags_reset";
			this.ClassFlags_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFlags_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFlags_reset, "reset");
			this.ClassFlags_reset.UseVisualStyleBackColor = true;
			this.ClassFlags_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat1
			// 
			this.page_ClassFeat1.Controls.Add(this.cf1_SpellId);
			this.page_ClassFeat1.Controls.Add(this.cf1_FeatId);
			this.page_ClassFeat1.Controls.Add(this.cf1_cheatCast);
			this.page_ClassFeat1.Controls.Add(this.cf1_spellId_label);
			this.page_ClassFeat1.Controls.Add(this.cf1_featId_label);
			this.page_ClassFeat1.Controls.Add(this.cf1_bin);
			this.page_ClassFeat1.Controls.Add(this.cf1_hex);
			this.page_ClassFeat1.Controls.Add(this.cf1_Clear);
			this.page_ClassFeat1.Controls.Add(this.ClassFeat1_bin);
			this.page_ClassFeat1.Controls.Add(this.ClassFeat1_hex);
			this.page_ClassFeat1.Controls.Add(this.ClassFeat1_text);
			this.page_ClassFeat1.Controls.Add(this.ClassFeat1_reset);
			this.page_ClassFeat1.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat1.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat1.Name = "page_ClassFeat1";
			this.page_ClassFeat1.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat1.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat1.TabIndex = 1;
			this.page_ClassFeat1.Text = "FeatSpell1";
			this.page_ClassFeat1.UseVisualStyleBackColor = true;
			// 
			// cf1_SpellId
			// 
			this.cf1_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf1_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_SpellId.Name = "cf1_SpellId";
			this.cf1_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf1_SpellId.TabIndex = 64;
			this.cf1_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf1_FeatId
			// 
			this.cf1_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf1_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_FeatId.Name = "cf1_FeatId";
			this.cf1_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf1_FeatId.TabIndex = 63;
			this.cf1_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf1_cheatCast
			// 
			this.cf1_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf1_cheatCast.Name = "cf1_cheatCast";
			this.cf1_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf1_cheatCast.TabIndex = 62;
			this.cf1_cheatCast.Text = "cheat cast";
			this.cf1_cheatCast.UseVisualStyleBackColor = true;
			this.cf1_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf1_spellId_label
			// 
			this.cf1_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf1_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_spellId_label.Name = "cf1_spellId_label";
			this.cf1_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf1_spellId_label.TabIndex = 61;
			this.cf1_spellId_label.Text = "ID Spell";
			this.cf1_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_featId_label
			// 
			this.cf1_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf1_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_featId_label.Name = "cf1_featId_label";
			this.cf1_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf1_featId_label.TabIndex = 60;
			this.cf1_featId_label.Text = "ID Feat";
			this.cf1_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_bin
			// 
			this.cf1_bin.Location = new System.Drawing.Point(395, 35);
			this.cf1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_bin.Name = "cf1_bin";
			this.cf1_bin.Size = new System.Drawing.Size(45, 15);
			this.cf1_bin.TabIndex = 54;
			this.cf1_bin.Text = "- bin";
			this.cf1_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_hex
			// 
			this.cf1_hex.Location = new System.Drawing.Point(395, 15);
			this.cf1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_hex.Name = "cf1_hex";
			this.cf1_hex.Size = new System.Drawing.Size(45, 15);
			this.cf1_hex.TabIndex = 53;
			this.cf1_hex.Text = "- hex";
			this.cf1_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_Clear
			// 
			this.cf1_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf1_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_Clear.Name = "cf1_Clear";
			this.cf1_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf1_Clear.TabIndex = 52;
			this.cf1_Clear.Text = "zero\r\nall\r\nbits";
			this.cf1_Clear.UseVisualStyleBackColor = true;
			this.cf1_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat1_bin
			// 
			this.ClassFeat1_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat1_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat1_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_bin.Name = "ClassFeat1_bin";
			this.ClassFeat1_bin.ReadOnly = true;
			this.ClassFeat1_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat1_bin.TabIndex = 50;
			// 
			// ClassFeat1_hex
			// 
			this.ClassFeat1_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat1_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat1_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_hex.Name = "ClassFeat1_hex";
			this.ClassFeat1_hex.ReadOnly = true;
			this.ClassFeat1_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat1_hex.TabIndex = 51;
			// 
			// ClassFeat1_text
			// 
			this.ClassFeat1_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat1_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_text.Name = "ClassFeat1_text";
			this.ClassFeat1_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat1_text.TabIndex = 49;
			this.ClassFeat1_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat1_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat1_reset
			// 
			this.ClassFeat1_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat1_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_reset.Name = "ClassFeat1_reset";
			this.ClassFeat1_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat1_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat1_reset, "reset");
			this.ClassFeat1_reset.UseVisualStyleBackColor = true;
			this.ClassFeat1_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat2
			// 
			this.page_ClassFeat2.Controls.Add(this.cf2_SpellId);
			this.page_ClassFeat2.Controls.Add(this.cf2_FeatId);
			this.page_ClassFeat2.Controls.Add(this.cf2_cheatCast);
			this.page_ClassFeat2.Controls.Add(this.cf2_spellId_label);
			this.page_ClassFeat2.Controls.Add(this.cf2_featId_label);
			this.page_ClassFeat2.Controls.Add(this.cf2_bin);
			this.page_ClassFeat2.Controls.Add(this.cf2_hex);
			this.page_ClassFeat2.Controls.Add(this.cf2_Clear);
			this.page_ClassFeat2.Controls.Add(this.ClassFeat2_bin);
			this.page_ClassFeat2.Controls.Add(this.ClassFeat2_hex);
			this.page_ClassFeat2.Controls.Add(this.ClassFeat2_text);
			this.page_ClassFeat2.Controls.Add(this.ClassFeat2_reset);
			this.page_ClassFeat2.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat2.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat2.Name = "page_ClassFeat2";
			this.page_ClassFeat2.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat2.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat2.TabIndex = 2;
			this.page_ClassFeat2.Text = "FeatSpell2";
			this.page_ClassFeat2.UseVisualStyleBackColor = true;
			// 
			// cf2_SpellId
			// 
			this.cf2_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf2_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_SpellId.Name = "cf2_SpellId";
			this.cf2_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf2_SpellId.TabIndex = 64;
			this.cf2_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf2_FeatId
			// 
			this.cf2_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf2_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_FeatId.Name = "cf2_FeatId";
			this.cf2_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf2_FeatId.TabIndex = 63;
			this.cf2_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf2_cheatCast
			// 
			this.cf2_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf2_cheatCast.Name = "cf2_cheatCast";
			this.cf2_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf2_cheatCast.TabIndex = 62;
			this.cf2_cheatCast.Text = "cheat cast";
			this.cf2_cheatCast.UseVisualStyleBackColor = true;
			this.cf2_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf2_spellId_label
			// 
			this.cf2_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf2_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_spellId_label.Name = "cf2_spellId_label";
			this.cf2_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf2_spellId_label.TabIndex = 61;
			this.cf2_spellId_label.Text = "ID Spell";
			this.cf2_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_featId_label
			// 
			this.cf2_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf2_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_featId_label.Name = "cf2_featId_label";
			this.cf2_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf2_featId_label.TabIndex = 60;
			this.cf2_featId_label.Text = "ID Feat";
			this.cf2_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_bin
			// 
			this.cf2_bin.Location = new System.Drawing.Point(395, 35);
			this.cf2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_bin.Name = "cf2_bin";
			this.cf2_bin.Size = new System.Drawing.Size(45, 15);
			this.cf2_bin.TabIndex = 54;
			this.cf2_bin.Text = "- bin";
			this.cf2_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_hex
			// 
			this.cf2_hex.Location = new System.Drawing.Point(395, 15);
			this.cf2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_hex.Name = "cf2_hex";
			this.cf2_hex.Size = new System.Drawing.Size(45, 15);
			this.cf2_hex.TabIndex = 53;
			this.cf2_hex.Text = "- hex";
			this.cf2_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_Clear
			// 
			this.cf2_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf2_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_Clear.Name = "cf2_Clear";
			this.cf2_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf2_Clear.TabIndex = 52;
			this.cf2_Clear.Text = "zero\r\nall\r\nbits";
			this.cf2_Clear.UseVisualStyleBackColor = true;
			this.cf2_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat2_bin
			// 
			this.ClassFeat2_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat2_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat2_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_bin.Name = "ClassFeat2_bin";
			this.ClassFeat2_bin.ReadOnly = true;
			this.ClassFeat2_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat2_bin.TabIndex = 50;
			// 
			// ClassFeat2_hex
			// 
			this.ClassFeat2_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat2_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat2_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_hex.Name = "ClassFeat2_hex";
			this.ClassFeat2_hex.ReadOnly = true;
			this.ClassFeat2_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat2_hex.TabIndex = 51;
			// 
			// ClassFeat2_text
			// 
			this.ClassFeat2_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat2_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_text.Name = "ClassFeat2_text";
			this.ClassFeat2_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat2_text.TabIndex = 49;
			this.ClassFeat2_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat2_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat2_reset
			// 
			this.ClassFeat2_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat2_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_reset.Name = "ClassFeat2_reset";
			this.ClassFeat2_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat2_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat2_reset, "reset");
			this.ClassFeat2_reset.UseVisualStyleBackColor = true;
			this.ClassFeat2_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat3
			// 
			this.page_ClassFeat3.Controls.Add(this.cf3_SpellId);
			this.page_ClassFeat3.Controls.Add(this.cf3_FeatId);
			this.page_ClassFeat3.Controls.Add(this.cf3_cheatCast);
			this.page_ClassFeat3.Controls.Add(this.cf3_spellId_label);
			this.page_ClassFeat3.Controls.Add(this.cf3_featId_label);
			this.page_ClassFeat3.Controls.Add(this.cf3_bin);
			this.page_ClassFeat3.Controls.Add(this.cf3_hex);
			this.page_ClassFeat3.Controls.Add(this.cf3_Clear);
			this.page_ClassFeat3.Controls.Add(this.ClassFeat3_bin);
			this.page_ClassFeat3.Controls.Add(this.ClassFeat3_hex);
			this.page_ClassFeat3.Controls.Add(this.ClassFeat3_text);
			this.page_ClassFeat3.Controls.Add(this.ClassFeat3_reset);
			this.page_ClassFeat3.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat3.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat3.Name = "page_ClassFeat3";
			this.page_ClassFeat3.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat3.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat3.TabIndex = 3;
			this.page_ClassFeat3.Text = "FeatSpell3";
			this.page_ClassFeat3.UseVisualStyleBackColor = true;
			// 
			// cf3_SpellId
			// 
			this.cf3_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf3_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_SpellId.Name = "cf3_SpellId";
			this.cf3_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf3_SpellId.TabIndex = 64;
			this.cf3_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf3_FeatId
			// 
			this.cf3_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf3_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_FeatId.Name = "cf3_FeatId";
			this.cf3_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf3_FeatId.TabIndex = 63;
			this.cf3_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf3_cheatCast
			// 
			this.cf3_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf3_cheatCast.Name = "cf3_cheatCast";
			this.cf3_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf3_cheatCast.TabIndex = 62;
			this.cf3_cheatCast.Text = "cheat cast";
			this.cf3_cheatCast.UseVisualStyleBackColor = true;
			this.cf3_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf3_spellId_label
			// 
			this.cf3_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf3_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_spellId_label.Name = "cf3_spellId_label";
			this.cf3_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf3_spellId_label.TabIndex = 61;
			this.cf3_spellId_label.Text = "ID Spell";
			this.cf3_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_featId_label
			// 
			this.cf3_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf3_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_featId_label.Name = "cf3_featId_label";
			this.cf3_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf3_featId_label.TabIndex = 60;
			this.cf3_featId_label.Text = "ID Feat";
			this.cf3_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_bin
			// 
			this.cf3_bin.Location = new System.Drawing.Point(395, 35);
			this.cf3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_bin.Name = "cf3_bin";
			this.cf3_bin.Size = new System.Drawing.Size(45, 15);
			this.cf3_bin.TabIndex = 54;
			this.cf3_bin.Text = "- bin";
			this.cf3_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_hex
			// 
			this.cf3_hex.Location = new System.Drawing.Point(395, 15);
			this.cf3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_hex.Name = "cf3_hex";
			this.cf3_hex.Size = new System.Drawing.Size(45, 15);
			this.cf3_hex.TabIndex = 53;
			this.cf3_hex.Text = "- hex";
			this.cf3_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_Clear
			// 
			this.cf3_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf3_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_Clear.Name = "cf3_Clear";
			this.cf3_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf3_Clear.TabIndex = 52;
			this.cf3_Clear.Text = "zero\r\nall\r\nbits";
			this.cf3_Clear.UseVisualStyleBackColor = true;
			this.cf3_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat3_bin
			// 
			this.ClassFeat3_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat3_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat3_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_bin.Name = "ClassFeat3_bin";
			this.ClassFeat3_bin.ReadOnly = true;
			this.ClassFeat3_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat3_bin.TabIndex = 50;
			// 
			// ClassFeat3_hex
			// 
			this.ClassFeat3_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat3_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat3_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_hex.Name = "ClassFeat3_hex";
			this.ClassFeat3_hex.ReadOnly = true;
			this.ClassFeat3_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat3_hex.TabIndex = 51;
			// 
			// ClassFeat3_text
			// 
			this.ClassFeat3_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat3_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_text.Name = "ClassFeat3_text";
			this.ClassFeat3_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat3_text.TabIndex = 49;
			this.ClassFeat3_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat3_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat3_reset
			// 
			this.ClassFeat3_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat3_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_reset.Name = "ClassFeat3_reset";
			this.ClassFeat3_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat3_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat3_reset, "reset");
			this.ClassFeat3_reset.UseVisualStyleBackColor = true;
			this.ClassFeat3_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat4
			// 
			this.page_ClassFeat4.Controls.Add(this.cf4_SpellId);
			this.page_ClassFeat4.Controls.Add(this.cf4_FeatId);
			this.page_ClassFeat4.Controls.Add(this.cf4_cheatCast);
			this.page_ClassFeat4.Controls.Add(this.cf4_spellId_label);
			this.page_ClassFeat4.Controls.Add(this.cf4_featId_label);
			this.page_ClassFeat4.Controls.Add(this.cf4_bin);
			this.page_ClassFeat4.Controls.Add(this.cf4_hex);
			this.page_ClassFeat4.Controls.Add(this.cf4_Clear);
			this.page_ClassFeat4.Controls.Add(this.ClassFeat4_bin);
			this.page_ClassFeat4.Controls.Add(this.ClassFeat4_hex);
			this.page_ClassFeat4.Controls.Add(this.ClassFeat4_text);
			this.page_ClassFeat4.Controls.Add(this.ClassFeat4_reset);
			this.page_ClassFeat4.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat4.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat4.Name = "page_ClassFeat4";
			this.page_ClassFeat4.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat4.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat4.TabIndex = 4;
			this.page_ClassFeat4.Text = "FeatSpell4";
			this.page_ClassFeat4.UseVisualStyleBackColor = true;
			// 
			// cf4_SpellId
			// 
			this.cf4_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf4_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_SpellId.Name = "cf4_SpellId";
			this.cf4_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf4_SpellId.TabIndex = 64;
			this.cf4_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf4_FeatId
			// 
			this.cf4_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf4_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_FeatId.Name = "cf4_FeatId";
			this.cf4_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf4_FeatId.TabIndex = 63;
			this.cf4_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf4_cheatCast
			// 
			this.cf4_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf4_cheatCast.Name = "cf4_cheatCast";
			this.cf4_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf4_cheatCast.TabIndex = 62;
			this.cf4_cheatCast.Text = "cheat cast";
			this.cf4_cheatCast.UseVisualStyleBackColor = true;
			this.cf4_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf4_spellId_label
			// 
			this.cf4_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf4_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_spellId_label.Name = "cf4_spellId_label";
			this.cf4_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf4_spellId_label.TabIndex = 61;
			this.cf4_spellId_label.Text = "ID Spell";
			this.cf4_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_featId_label
			// 
			this.cf4_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf4_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_featId_label.Name = "cf4_featId_label";
			this.cf4_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf4_featId_label.TabIndex = 60;
			this.cf4_featId_label.Text = "ID Feat";
			this.cf4_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_bin
			// 
			this.cf4_bin.Location = new System.Drawing.Point(395, 35);
			this.cf4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_bin.Name = "cf4_bin";
			this.cf4_bin.Size = new System.Drawing.Size(45, 15);
			this.cf4_bin.TabIndex = 54;
			this.cf4_bin.Text = "- bin";
			this.cf4_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_hex
			// 
			this.cf4_hex.Location = new System.Drawing.Point(395, 15);
			this.cf4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_hex.Name = "cf4_hex";
			this.cf4_hex.Size = new System.Drawing.Size(45, 15);
			this.cf4_hex.TabIndex = 53;
			this.cf4_hex.Text = "- hex";
			this.cf4_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_Clear
			// 
			this.cf4_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf4_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_Clear.Name = "cf4_Clear";
			this.cf4_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf4_Clear.TabIndex = 52;
			this.cf4_Clear.Text = "zero\r\nall\r\nbits";
			this.cf4_Clear.UseVisualStyleBackColor = true;
			this.cf4_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat4_bin
			// 
			this.ClassFeat4_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat4_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat4_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_bin.Name = "ClassFeat4_bin";
			this.ClassFeat4_bin.ReadOnly = true;
			this.ClassFeat4_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat4_bin.TabIndex = 50;
			// 
			// ClassFeat4_hex
			// 
			this.ClassFeat4_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat4_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat4_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_hex.Name = "ClassFeat4_hex";
			this.ClassFeat4_hex.ReadOnly = true;
			this.ClassFeat4_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat4_hex.TabIndex = 51;
			// 
			// ClassFeat4_text
			// 
			this.ClassFeat4_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat4_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_text.Name = "ClassFeat4_text";
			this.ClassFeat4_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat4_text.TabIndex = 49;
			this.ClassFeat4_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat4_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat4_reset
			// 
			this.ClassFeat4_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat4_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_reset.Name = "ClassFeat4_reset";
			this.ClassFeat4_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat4_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat4_reset, "reset");
			this.ClassFeat4_reset.UseVisualStyleBackColor = true;
			this.ClassFeat4_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat5
			// 
			this.page_ClassFeat5.Controls.Add(this.cf5_SpellId);
			this.page_ClassFeat5.Controls.Add(this.cf5_FeatId);
			this.page_ClassFeat5.Controls.Add(this.cf5_cheatCast);
			this.page_ClassFeat5.Controls.Add(this.cf5_spellId_label);
			this.page_ClassFeat5.Controls.Add(this.cf5_featId_label);
			this.page_ClassFeat5.Controls.Add(this.cf5_bin);
			this.page_ClassFeat5.Controls.Add(this.cf5_hex);
			this.page_ClassFeat5.Controls.Add(this.cf5_Clear);
			this.page_ClassFeat5.Controls.Add(this.ClassFeat5_bin);
			this.page_ClassFeat5.Controls.Add(this.ClassFeat5_hex);
			this.page_ClassFeat5.Controls.Add(this.ClassFeat5_text);
			this.page_ClassFeat5.Controls.Add(this.ClassFeat5_reset);
			this.page_ClassFeat5.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat5.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat5.Name = "page_ClassFeat5";
			this.page_ClassFeat5.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat5.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat5.TabIndex = 5;
			this.page_ClassFeat5.Text = "FeatSpell5";
			this.page_ClassFeat5.UseVisualStyleBackColor = true;
			// 
			// cf5_SpellId
			// 
			this.cf5_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf5_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_SpellId.Name = "cf5_SpellId";
			this.cf5_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf5_SpellId.TabIndex = 64;
			this.cf5_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf5_FeatId
			// 
			this.cf5_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf5_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_FeatId.Name = "cf5_FeatId";
			this.cf5_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf5_FeatId.TabIndex = 63;
			this.cf5_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf5_cheatCast
			// 
			this.cf5_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf5_cheatCast.Name = "cf5_cheatCast";
			this.cf5_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf5_cheatCast.TabIndex = 62;
			this.cf5_cheatCast.Text = "cheat cast";
			this.cf5_cheatCast.UseVisualStyleBackColor = true;
			this.cf5_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf5_spellId_label
			// 
			this.cf5_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf5_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_spellId_label.Name = "cf5_spellId_label";
			this.cf5_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf5_spellId_label.TabIndex = 61;
			this.cf5_spellId_label.Text = "ID Spell";
			this.cf5_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_featId_label
			// 
			this.cf5_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf5_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_featId_label.Name = "cf5_featId_label";
			this.cf5_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf5_featId_label.TabIndex = 60;
			this.cf5_featId_label.Text = "ID Feat";
			this.cf5_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_bin
			// 
			this.cf5_bin.Location = new System.Drawing.Point(395, 35);
			this.cf5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_bin.Name = "cf5_bin";
			this.cf5_bin.Size = new System.Drawing.Size(45, 15);
			this.cf5_bin.TabIndex = 54;
			this.cf5_bin.Text = "- bin";
			this.cf5_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_hex
			// 
			this.cf5_hex.Location = new System.Drawing.Point(395, 15);
			this.cf5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_hex.Name = "cf5_hex";
			this.cf5_hex.Size = new System.Drawing.Size(45, 15);
			this.cf5_hex.TabIndex = 53;
			this.cf5_hex.Text = "- hex";
			this.cf5_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_Clear
			// 
			this.cf5_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf5_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_Clear.Name = "cf5_Clear";
			this.cf5_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf5_Clear.TabIndex = 52;
			this.cf5_Clear.Text = "zero\r\nall\r\nbits";
			this.cf5_Clear.UseVisualStyleBackColor = true;
			this.cf5_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat5_bin
			// 
			this.ClassFeat5_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat5_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat5_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_bin.Name = "ClassFeat5_bin";
			this.ClassFeat5_bin.ReadOnly = true;
			this.ClassFeat5_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat5_bin.TabIndex = 50;
			// 
			// ClassFeat5_hex
			// 
			this.ClassFeat5_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat5_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat5_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_hex.Name = "ClassFeat5_hex";
			this.ClassFeat5_hex.ReadOnly = true;
			this.ClassFeat5_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat5_hex.TabIndex = 51;
			// 
			// ClassFeat5_text
			// 
			this.ClassFeat5_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat5_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_text.Name = "ClassFeat5_text";
			this.ClassFeat5_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat5_text.TabIndex = 49;
			this.ClassFeat5_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat5_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat5_reset
			// 
			this.ClassFeat5_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat5_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_reset.Name = "ClassFeat5_reset";
			this.ClassFeat5_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat5_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat5_reset, "reset");
			this.ClassFeat5_reset.UseVisualStyleBackColor = true;
			this.ClassFeat5_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat6
			// 
			this.page_ClassFeat6.Controls.Add(this.cf6_SpellId);
			this.page_ClassFeat6.Controls.Add(this.cf6_FeatId);
			this.page_ClassFeat6.Controls.Add(this.cf6_cheatCast);
			this.page_ClassFeat6.Controls.Add(this.cf6_spellId_label);
			this.page_ClassFeat6.Controls.Add(this.cf6_featId_label);
			this.page_ClassFeat6.Controls.Add(this.cf6_bin);
			this.page_ClassFeat6.Controls.Add(this.cf6_hex);
			this.page_ClassFeat6.Controls.Add(this.cf6_Clear);
			this.page_ClassFeat6.Controls.Add(this.ClassFeat6_bin);
			this.page_ClassFeat6.Controls.Add(this.ClassFeat6_hex);
			this.page_ClassFeat6.Controls.Add(this.ClassFeat6_text);
			this.page_ClassFeat6.Controls.Add(this.ClassFeat6_reset);
			this.page_ClassFeat6.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat6.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat6.Name = "page_ClassFeat6";
			this.page_ClassFeat6.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat6.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat6.TabIndex = 6;
			this.page_ClassFeat6.Text = "FeatSpell6";
			this.page_ClassFeat6.UseVisualStyleBackColor = true;
			// 
			// cf6_SpellId
			// 
			this.cf6_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf6_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_SpellId.Name = "cf6_SpellId";
			this.cf6_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf6_SpellId.TabIndex = 64;
			this.cf6_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf6_FeatId
			// 
			this.cf6_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf6_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_FeatId.Name = "cf6_FeatId";
			this.cf6_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf6_FeatId.TabIndex = 63;
			this.cf6_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf6_cheatCast
			// 
			this.cf6_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf6_cheatCast.Name = "cf6_cheatCast";
			this.cf6_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf6_cheatCast.TabIndex = 62;
			this.cf6_cheatCast.Text = "cheat cast";
			this.cf6_cheatCast.UseVisualStyleBackColor = true;
			this.cf6_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf6_spellId_label
			// 
			this.cf6_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf6_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_spellId_label.Name = "cf6_spellId_label";
			this.cf6_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf6_spellId_label.TabIndex = 61;
			this.cf6_spellId_label.Text = "ID Spell";
			this.cf6_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_featId_label
			// 
			this.cf6_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf6_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_featId_label.Name = "cf6_featId_label";
			this.cf6_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf6_featId_label.TabIndex = 60;
			this.cf6_featId_label.Text = "ID Feat";
			this.cf6_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_bin
			// 
			this.cf6_bin.Location = new System.Drawing.Point(395, 35);
			this.cf6_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_bin.Name = "cf6_bin";
			this.cf6_bin.Size = new System.Drawing.Size(45, 15);
			this.cf6_bin.TabIndex = 54;
			this.cf6_bin.Text = "- bin";
			this.cf6_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_hex
			// 
			this.cf6_hex.Location = new System.Drawing.Point(395, 15);
			this.cf6_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_hex.Name = "cf6_hex";
			this.cf6_hex.Size = new System.Drawing.Size(45, 15);
			this.cf6_hex.TabIndex = 53;
			this.cf6_hex.Text = "- hex";
			this.cf6_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_Clear
			// 
			this.cf6_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf6_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_Clear.Name = "cf6_Clear";
			this.cf6_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf6_Clear.TabIndex = 52;
			this.cf6_Clear.Text = "zero\r\nall\r\nbits";
			this.cf6_Clear.UseVisualStyleBackColor = true;
			this.cf6_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat6_bin
			// 
			this.ClassFeat6_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat6_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat6_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat6_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_bin.Name = "ClassFeat6_bin";
			this.ClassFeat6_bin.ReadOnly = true;
			this.ClassFeat6_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat6_bin.TabIndex = 50;
			// 
			// ClassFeat6_hex
			// 
			this.ClassFeat6_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat6_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat6_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat6_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_hex.Name = "ClassFeat6_hex";
			this.ClassFeat6_hex.ReadOnly = true;
			this.ClassFeat6_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat6_hex.TabIndex = 51;
			// 
			// ClassFeat6_text
			// 
			this.ClassFeat6_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat6_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_text.Name = "ClassFeat6_text";
			this.ClassFeat6_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat6_text.TabIndex = 49;
			this.ClassFeat6_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat6_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat6_reset
			// 
			this.ClassFeat6_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat6_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_reset.Name = "ClassFeat6_reset";
			this.ClassFeat6_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat6_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat6_reset, "reset");
			this.ClassFeat6_reset.UseVisualStyleBackColor = true;
			this.ClassFeat6_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat7
			// 
			this.page_ClassFeat7.Controls.Add(this.cf7_SpellId);
			this.page_ClassFeat7.Controls.Add(this.cf7_FeatId);
			this.page_ClassFeat7.Controls.Add(this.cf7_cheatCast);
			this.page_ClassFeat7.Controls.Add(this.cf7_spellId_label);
			this.page_ClassFeat7.Controls.Add(this.cf7_featId_label);
			this.page_ClassFeat7.Controls.Add(this.cf7_bin);
			this.page_ClassFeat7.Controls.Add(this.cf7_hex);
			this.page_ClassFeat7.Controls.Add(this.cf7_Clear);
			this.page_ClassFeat7.Controls.Add(this.ClassFeat7_bin);
			this.page_ClassFeat7.Controls.Add(this.ClassFeat7_hex);
			this.page_ClassFeat7.Controls.Add(this.ClassFeat7_text);
			this.page_ClassFeat7.Controls.Add(this.ClassFeat7_reset);
			this.page_ClassFeat7.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat7.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat7.Name = "page_ClassFeat7";
			this.page_ClassFeat7.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat7.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat7.TabIndex = 7;
			this.page_ClassFeat7.Text = "FeatSpell7";
			this.page_ClassFeat7.UseVisualStyleBackColor = true;
			// 
			// cf7_SpellId
			// 
			this.cf7_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf7_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_SpellId.Name = "cf7_SpellId";
			this.cf7_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf7_SpellId.TabIndex = 64;
			this.cf7_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf7_FeatId
			// 
			this.cf7_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf7_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_FeatId.Name = "cf7_FeatId";
			this.cf7_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf7_FeatId.TabIndex = 63;
			this.cf7_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf7_cheatCast
			// 
			this.cf7_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf7_cheatCast.Name = "cf7_cheatCast";
			this.cf7_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf7_cheatCast.TabIndex = 62;
			this.cf7_cheatCast.Text = "cheat cast";
			this.cf7_cheatCast.UseVisualStyleBackColor = true;
			this.cf7_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf7_spellId_label
			// 
			this.cf7_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf7_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_spellId_label.Name = "cf7_spellId_label";
			this.cf7_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf7_spellId_label.TabIndex = 61;
			this.cf7_spellId_label.Text = "ID Spell";
			this.cf7_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_featId_label
			// 
			this.cf7_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf7_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_featId_label.Name = "cf7_featId_label";
			this.cf7_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf7_featId_label.TabIndex = 60;
			this.cf7_featId_label.Text = "ID Feat";
			this.cf7_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_bin
			// 
			this.cf7_bin.Location = new System.Drawing.Point(395, 35);
			this.cf7_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_bin.Name = "cf7_bin";
			this.cf7_bin.Size = new System.Drawing.Size(45, 15);
			this.cf7_bin.TabIndex = 54;
			this.cf7_bin.Text = "- bin";
			this.cf7_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_hex
			// 
			this.cf7_hex.Location = new System.Drawing.Point(395, 15);
			this.cf7_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_hex.Name = "cf7_hex";
			this.cf7_hex.Size = new System.Drawing.Size(45, 15);
			this.cf7_hex.TabIndex = 53;
			this.cf7_hex.Text = "- hex";
			this.cf7_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_Clear
			// 
			this.cf7_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf7_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_Clear.Name = "cf7_Clear";
			this.cf7_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf7_Clear.TabIndex = 52;
			this.cf7_Clear.Text = "zero\r\nall\r\nbits";
			this.cf7_Clear.UseVisualStyleBackColor = true;
			this.cf7_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat7_bin
			// 
			this.ClassFeat7_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat7_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat7_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat7_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_bin.Name = "ClassFeat7_bin";
			this.ClassFeat7_bin.ReadOnly = true;
			this.ClassFeat7_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat7_bin.TabIndex = 50;
			// 
			// ClassFeat7_hex
			// 
			this.ClassFeat7_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat7_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat7_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat7_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_hex.Name = "ClassFeat7_hex";
			this.ClassFeat7_hex.ReadOnly = true;
			this.ClassFeat7_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat7_hex.TabIndex = 51;
			// 
			// ClassFeat7_text
			// 
			this.ClassFeat7_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat7_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_text.Name = "ClassFeat7_text";
			this.ClassFeat7_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat7_text.TabIndex = 49;
			this.ClassFeat7_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat7_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat7_reset
			// 
			this.ClassFeat7_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat7_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_reset.Name = "ClassFeat7_reset";
			this.ClassFeat7_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat7_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat7_reset, "reset");
			this.ClassFeat7_reset.UseVisualStyleBackColor = true;
			this.ClassFeat7_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat8
			// 
			this.page_ClassFeat8.Controls.Add(this.cf8_SpellId);
			this.page_ClassFeat8.Controls.Add(this.cf8_FeatId);
			this.page_ClassFeat8.Controls.Add(this.cf8_cheatCast);
			this.page_ClassFeat8.Controls.Add(this.cf8_spellId_label);
			this.page_ClassFeat8.Controls.Add(this.cf8_featId_label);
			this.page_ClassFeat8.Controls.Add(this.cf8_bin);
			this.page_ClassFeat8.Controls.Add(this.cf8_hex);
			this.page_ClassFeat8.Controls.Add(this.cf8_Clear);
			this.page_ClassFeat8.Controls.Add(this.ClassFeat8_bin);
			this.page_ClassFeat8.Controls.Add(this.ClassFeat8_hex);
			this.page_ClassFeat8.Controls.Add(this.ClassFeat8_text);
			this.page_ClassFeat8.Controls.Add(this.ClassFeat8_reset);
			this.page_ClassFeat8.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat8.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat8.Name = "page_ClassFeat8";
			this.page_ClassFeat8.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat8.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat8.TabIndex = 8;
			this.page_ClassFeat8.Text = "FeatSpell8";
			this.page_ClassFeat8.UseVisualStyleBackColor = true;
			// 
			// cf8_SpellId
			// 
			this.cf8_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf8_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_SpellId.Name = "cf8_SpellId";
			this.cf8_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf8_SpellId.TabIndex = 64;
			this.cf8_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf8_FeatId
			// 
			this.cf8_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf8_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_FeatId.Name = "cf8_FeatId";
			this.cf8_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf8_FeatId.TabIndex = 63;
			this.cf8_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf8_cheatCast
			// 
			this.cf8_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf8_cheatCast.Name = "cf8_cheatCast";
			this.cf8_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf8_cheatCast.TabIndex = 62;
			this.cf8_cheatCast.Text = "cheat cast";
			this.cf8_cheatCast.UseVisualStyleBackColor = true;
			this.cf8_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf8_spellId_label
			// 
			this.cf8_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf8_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_spellId_label.Name = "cf8_spellId_label";
			this.cf8_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf8_spellId_label.TabIndex = 61;
			this.cf8_spellId_label.Text = "ID Spell";
			this.cf8_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_featId_label
			// 
			this.cf8_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf8_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_featId_label.Name = "cf8_featId_label";
			this.cf8_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf8_featId_label.TabIndex = 60;
			this.cf8_featId_label.Text = "ID Feat";
			this.cf8_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_bin
			// 
			this.cf8_bin.Location = new System.Drawing.Point(395, 35);
			this.cf8_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_bin.Name = "cf8_bin";
			this.cf8_bin.Size = new System.Drawing.Size(45, 15);
			this.cf8_bin.TabIndex = 54;
			this.cf8_bin.Text = "- bin";
			this.cf8_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_hex
			// 
			this.cf8_hex.Location = new System.Drawing.Point(395, 15);
			this.cf8_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_hex.Name = "cf8_hex";
			this.cf8_hex.Size = new System.Drawing.Size(45, 15);
			this.cf8_hex.TabIndex = 53;
			this.cf8_hex.Text = "- hex";
			this.cf8_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_Clear
			// 
			this.cf8_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf8_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_Clear.Name = "cf8_Clear";
			this.cf8_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf8_Clear.TabIndex = 52;
			this.cf8_Clear.Text = "zero\r\nall\r\nbits";
			this.cf8_Clear.UseVisualStyleBackColor = true;
			this.cf8_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat8_bin
			// 
			this.ClassFeat8_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat8_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat8_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat8_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_bin.Name = "ClassFeat8_bin";
			this.ClassFeat8_bin.ReadOnly = true;
			this.ClassFeat8_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat8_bin.TabIndex = 50;
			// 
			// ClassFeat8_hex
			// 
			this.ClassFeat8_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat8_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat8_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat8_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_hex.Name = "ClassFeat8_hex";
			this.ClassFeat8_hex.ReadOnly = true;
			this.ClassFeat8_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat8_hex.TabIndex = 51;
			// 
			// ClassFeat8_text
			// 
			this.ClassFeat8_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat8_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_text.Name = "ClassFeat8_text";
			this.ClassFeat8_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat8_text.TabIndex = 49;
			this.ClassFeat8_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat8_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat8_reset
			// 
			this.ClassFeat8_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat8_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_reset.Name = "ClassFeat8_reset";
			this.ClassFeat8_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat8_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat8_reset, "reset");
			this.ClassFeat8_reset.UseVisualStyleBackColor = true;
			this.ClassFeat8_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat9
			// 
			this.page_ClassFeat9.Controls.Add(this.cf9_SpellId);
			this.page_ClassFeat9.Controls.Add(this.cf9_FeatId);
			this.page_ClassFeat9.Controls.Add(this.cf9_cheatCast);
			this.page_ClassFeat9.Controls.Add(this.cf9_spellId_label);
			this.page_ClassFeat9.Controls.Add(this.cf9_featId_label);
			this.page_ClassFeat9.Controls.Add(this.cf9_bin);
			this.page_ClassFeat9.Controls.Add(this.cf9_hex);
			this.page_ClassFeat9.Controls.Add(this.cf9_Clear);
			this.page_ClassFeat9.Controls.Add(this.ClassFeat9_bin);
			this.page_ClassFeat9.Controls.Add(this.ClassFeat9_hex);
			this.page_ClassFeat9.Controls.Add(this.ClassFeat9_text);
			this.page_ClassFeat9.Controls.Add(this.ClassFeat9_reset);
			this.page_ClassFeat9.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat9.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat9.Name = "page_ClassFeat9";
			this.page_ClassFeat9.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat9.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat9.TabIndex = 9;
			this.page_ClassFeat9.Text = "FeatSpell9";
			this.page_ClassFeat9.UseVisualStyleBackColor = true;
			// 
			// cf9_SpellId
			// 
			this.cf9_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf9_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_SpellId.Name = "cf9_SpellId";
			this.cf9_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf9_SpellId.TabIndex = 64;
			this.cf9_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf9_FeatId
			// 
			this.cf9_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf9_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_FeatId.Name = "cf9_FeatId";
			this.cf9_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf9_FeatId.TabIndex = 63;
			this.cf9_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf9_cheatCast
			// 
			this.cf9_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf9_cheatCast.Name = "cf9_cheatCast";
			this.cf9_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf9_cheatCast.TabIndex = 62;
			this.cf9_cheatCast.Text = "cheat cast";
			this.cf9_cheatCast.UseVisualStyleBackColor = true;
			this.cf9_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf9_spellId_label
			// 
			this.cf9_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf9_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_spellId_label.Name = "cf9_spellId_label";
			this.cf9_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf9_spellId_label.TabIndex = 61;
			this.cf9_spellId_label.Text = "ID Spell";
			this.cf9_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_featId_label
			// 
			this.cf9_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf9_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_featId_label.Name = "cf9_featId_label";
			this.cf9_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf9_featId_label.TabIndex = 60;
			this.cf9_featId_label.Text = "ID Feat";
			this.cf9_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_bin
			// 
			this.cf9_bin.Location = new System.Drawing.Point(395, 35);
			this.cf9_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_bin.Name = "cf9_bin";
			this.cf9_bin.Size = new System.Drawing.Size(45, 15);
			this.cf9_bin.TabIndex = 54;
			this.cf9_bin.Text = "- bin";
			this.cf9_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_hex
			// 
			this.cf9_hex.Location = new System.Drawing.Point(395, 15);
			this.cf9_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_hex.Name = "cf9_hex";
			this.cf9_hex.Size = new System.Drawing.Size(45, 15);
			this.cf9_hex.TabIndex = 53;
			this.cf9_hex.Text = "- hex";
			this.cf9_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_Clear
			// 
			this.cf9_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf9_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_Clear.Name = "cf9_Clear";
			this.cf9_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf9_Clear.TabIndex = 52;
			this.cf9_Clear.Text = "zero\r\nall\r\nbits";
			this.cf9_Clear.UseVisualStyleBackColor = true;
			this.cf9_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat9_bin
			// 
			this.ClassFeat9_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat9_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat9_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat9_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_bin.Name = "ClassFeat9_bin";
			this.ClassFeat9_bin.ReadOnly = true;
			this.ClassFeat9_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat9_bin.TabIndex = 50;
			// 
			// ClassFeat9_hex
			// 
			this.ClassFeat9_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat9_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat9_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat9_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_hex.Name = "ClassFeat9_hex";
			this.ClassFeat9_hex.ReadOnly = true;
			this.ClassFeat9_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat9_hex.TabIndex = 51;
			// 
			// ClassFeat9_text
			// 
			this.ClassFeat9_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat9_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_text.Name = "ClassFeat9_text";
			this.ClassFeat9_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat9_text.TabIndex = 49;
			this.ClassFeat9_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat9_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat9_reset
			// 
			this.ClassFeat9_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat9_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_reset.Name = "ClassFeat9_reset";
			this.ClassFeat9_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat9_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat9_reset, "reset");
			this.ClassFeat9_reset.UseVisualStyleBackColor = true;
			this.ClassFeat9_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat10
			// 
			this.page_ClassFeat10.Controls.Add(this.cf10_SpellId);
			this.page_ClassFeat10.Controls.Add(this.cf10_FeatId);
			this.page_ClassFeat10.Controls.Add(this.cf10_cheatCast);
			this.page_ClassFeat10.Controls.Add(this.cf10_spellId_label);
			this.page_ClassFeat10.Controls.Add(this.cf10_featId_label);
			this.page_ClassFeat10.Controls.Add(this.cf10_bin);
			this.page_ClassFeat10.Controls.Add(this.cf10_hex);
			this.page_ClassFeat10.Controls.Add(this.cf10_Clear);
			this.page_ClassFeat10.Controls.Add(this.ClassFeat10_bin);
			this.page_ClassFeat10.Controls.Add(this.ClassFeat10_hex);
			this.page_ClassFeat10.Controls.Add(this.ClassFeat10_text);
			this.page_ClassFeat10.Controls.Add(this.ClassFeat10_reset);
			this.page_ClassFeat10.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat10.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat10.Name = "page_ClassFeat10";
			this.page_ClassFeat10.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat10.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat10.TabIndex = 10;
			this.page_ClassFeat10.Text = "FeatSpell10";
			this.page_ClassFeat10.UseVisualStyleBackColor = true;
			// 
			// cf10_SpellId
			// 
			this.cf10_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf10_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_SpellId.Name = "cf10_SpellId";
			this.cf10_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf10_SpellId.TabIndex = 64;
			this.cf10_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf10_FeatId
			// 
			this.cf10_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf10_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_FeatId.Name = "cf10_FeatId";
			this.cf10_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf10_FeatId.TabIndex = 63;
			this.cf10_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf10_cheatCast
			// 
			this.cf10_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf10_cheatCast.Name = "cf10_cheatCast";
			this.cf10_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf10_cheatCast.TabIndex = 62;
			this.cf10_cheatCast.Text = "cheat cast";
			this.cf10_cheatCast.UseVisualStyleBackColor = true;
			this.cf10_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf10_spellId_label
			// 
			this.cf10_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf10_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_spellId_label.Name = "cf10_spellId_label";
			this.cf10_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf10_spellId_label.TabIndex = 61;
			this.cf10_spellId_label.Text = "ID Spell";
			this.cf10_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_featId_label
			// 
			this.cf10_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf10_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_featId_label.Name = "cf10_featId_label";
			this.cf10_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf10_featId_label.TabIndex = 60;
			this.cf10_featId_label.Text = "ID Feat";
			this.cf10_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_bin
			// 
			this.cf10_bin.Location = new System.Drawing.Point(395, 35);
			this.cf10_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_bin.Name = "cf10_bin";
			this.cf10_bin.Size = new System.Drawing.Size(45, 15);
			this.cf10_bin.TabIndex = 54;
			this.cf10_bin.Text = "- bin";
			this.cf10_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_hex
			// 
			this.cf10_hex.Location = new System.Drawing.Point(395, 15);
			this.cf10_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_hex.Name = "cf10_hex";
			this.cf10_hex.Size = new System.Drawing.Size(45, 15);
			this.cf10_hex.TabIndex = 53;
			this.cf10_hex.Text = "- hex";
			this.cf10_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_Clear
			// 
			this.cf10_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf10_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_Clear.Name = "cf10_Clear";
			this.cf10_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf10_Clear.TabIndex = 52;
			this.cf10_Clear.Text = "zero\r\nall\r\nbits";
			this.cf10_Clear.UseVisualStyleBackColor = true;
			this.cf10_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat10_bin
			// 
			this.ClassFeat10_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat10_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat10_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat10_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_bin.Name = "ClassFeat10_bin";
			this.ClassFeat10_bin.ReadOnly = true;
			this.ClassFeat10_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat10_bin.TabIndex = 50;
			// 
			// ClassFeat10_hex
			// 
			this.ClassFeat10_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat10_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat10_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat10_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_hex.Name = "ClassFeat10_hex";
			this.ClassFeat10_hex.ReadOnly = true;
			this.ClassFeat10_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat10_hex.TabIndex = 51;
			// 
			// ClassFeat10_text
			// 
			this.ClassFeat10_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat10_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_text.Name = "ClassFeat10_text";
			this.ClassFeat10_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat10_text.TabIndex = 49;
			this.ClassFeat10_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat10_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat10_reset
			// 
			this.ClassFeat10_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat10_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_reset.Name = "ClassFeat10_reset";
			this.ClassFeat10_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat10_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat10_reset, "reset");
			this.ClassFeat10_reset.UseVisualStyleBackColor = true;
			this.ClassFeat10_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// page_ClassFeat11
			// 
			this.page_ClassFeat11.Controls.Add(this.cf11_SpellId);
			this.page_ClassFeat11.Controls.Add(this.cf11_FeatId);
			this.page_ClassFeat11.Controls.Add(this.cf11_cheatCast);
			this.page_ClassFeat11.Controls.Add(this.cf11_spellId_label);
			this.page_ClassFeat11.Controls.Add(this.cf11_featId_label);
			this.page_ClassFeat11.Controls.Add(this.cf11_bin);
			this.page_ClassFeat11.Controls.Add(this.cf11_hex);
			this.page_ClassFeat11.Controls.Add(this.cf11_Clear);
			this.page_ClassFeat11.Controls.Add(this.ClassFeat11_bin);
			this.page_ClassFeat11.Controls.Add(this.ClassFeat11_hex);
			this.page_ClassFeat11.Controls.Add(this.ClassFeat11_text);
			this.page_ClassFeat11.Controls.Add(this.ClassFeat11_reset);
			this.page_ClassFeat11.Location = new System.Drawing.Point(4, 24);
			this.page_ClassFeat11.Margin = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat11.Name = "page_ClassFeat11";
			this.page_ClassFeat11.Padding = new System.Windows.Forms.Padding(2);
			this.page_ClassFeat11.Size = new System.Drawing.Size(1062, 182);
			this.page_ClassFeat11.TabIndex = 11;
			this.page_ClassFeat11.Text = "FeatSpell11";
			this.page_ClassFeat11.UseVisualStyleBackColor = true;
			// 
			// cf11_SpellId
			// 
			this.cf11_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf11_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_SpellId.Name = "cf11_SpellId";
			this.cf11_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf11_SpellId.TabIndex = 64;
			this.cf11_SpellId.TextChanged += new System.EventHandler(this.TextChanged_cSpell);
			// 
			// cf11_FeatId
			// 
			this.cf11_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf11_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_FeatId.Name = "cf11_FeatId";
			this.cf11_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf11_FeatId.TabIndex = 63;
			this.cf11_FeatId.TextChanged += new System.EventHandler(this.TextChanged_cFeat);
			// 
			// cf11_cheatCast
			// 
			this.cf11_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf11_cheatCast.Name = "cf11_cheatCast";
			this.cf11_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.cf11_cheatCast.TabIndex = 62;
			this.cf11_cheatCast.Text = "cheat cast";
			this.cf11_cheatCast.UseVisualStyleBackColor = true;
			this.cf11_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_cFeats);
			// 
			// cf11_spellId_label
			// 
			this.cf11_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf11_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_spellId_label.Name = "cf11_spellId_label";
			this.cf11_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf11_spellId_label.TabIndex = 61;
			this.cf11_spellId_label.Text = "ID Spell";
			this.cf11_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_featId_label
			// 
			this.cf11_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf11_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_featId_label.Name = "cf11_featId_label";
			this.cf11_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf11_featId_label.TabIndex = 60;
			this.cf11_featId_label.Text = "ID Feat";
			this.cf11_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_bin
			// 
			this.cf11_bin.Location = new System.Drawing.Point(395, 35);
			this.cf11_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_bin.Name = "cf11_bin";
			this.cf11_bin.Size = new System.Drawing.Size(45, 15);
			this.cf11_bin.TabIndex = 54;
			this.cf11_bin.Text = "- bin";
			this.cf11_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_hex
			// 
			this.cf11_hex.Location = new System.Drawing.Point(395, 15);
			this.cf11_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_hex.Name = "cf11_hex";
			this.cf11_hex.Size = new System.Drawing.Size(45, 15);
			this.cf11_hex.TabIndex = 53;
			this.cf11_hex.Text = "- hex";
			this.cf11_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_Clear
			// 
			this.cf11_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf11_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_Clear.Name = "cf11_Clear";
			this.cf11_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf11_Clear.TabIndex = 52;
			this.cf11_Clear.Text = "zero\r\nall\r\nbits";
			this.cf11_Clear.UseVisualStyleBackColor = true;
			this.cf11_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// ClassFeat11_bin
			// 
			this.ClassFeat11_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat11_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat11_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat11_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_bin.Name = "ClassFeat11_bin";
			this.ClassFeat11_bin.ReadOnly = true;
			this.ClassFeat11_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat11_bin.TabIndex = 50;
			// 
			// ClassFeat11_hex
			// 
			this.ClassFeat11_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat11_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat11_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat11_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_hex.Name = "ClassFeat11_hex";
			this.ClassFeat11_hex.ReadOnly = true;
			this.ClassFeat11_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat11_hex.TabIndex = 51;
			// 
			// ClassFeat11_text
			// 
			this.ClassFeat11_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat11_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_text.Name = "ClassFeat11_text";
			this.ClassFeat11_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat11_text.TabIndex = 49;
			this.ClassFeat11_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ClassFeat11_text.TextChanged += new System.EventHandler(this.TextChanged_classes);
			// 
			// ClassFeat11_reset
			// 
			this.ClassFeat11_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat11_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_reset.Name = "ClassFeat11_reset";
			this.ClassFeat11_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat11_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.ClassFeat11_reset, "reset");
			this.ClassFeat11_reset.UseVisualStyleBackColor = true;
			this.ClassFeat11_reset.Click += new System.EventHandler(this.Click_classes_reset);
			// 
			// cols_HenchRacial
			// 
			this.cols_HenchRacial.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.cols_HenchRacial.Controls.Add(this.page_RacialFlags);
			this.cols_HenchRacial.Controls.Add(this.page_RacialFeat1);
			this.cols_HenchRacial.Controls.Add(this.page_RacialFeat2);
			this.cols_HenchRacial.Controls.Add(this.page_RacialFeat3);
			this.cols_HenchRacial.Controls.Add(this.page_RacialFeat4);
			this.cols_HenchRacial.Controls.Add(this.page_RacialFeat5);
			this.cols_HenchRacial.Location = new System.Drawing.Point(0, 460);
			this.cols_HenchRacial.Margin = new System.Windows.Forms.Padding(0);
			this.cols_HenchRacial.Name = "cols_HenchRacial";
			this.cols_HenchRacial.Padding = new System.Drawing.Point(5, 2);
			this.cols_HenchRacial.SelectedIndex = 0;
			this.cols_HenchRacial.Size = new System.Drawing.Size(820, 265);
			this.cols_HenchRacial.TabIndex = 2;
			this.cols_HenchRacial.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged_tab);
			// 
			// page_RacialFlags
			// 
			this.page_RacialFlags.Controls.Add(this.rf_HasFeatSpells);
			this.page_RacialFlags.Controls.Add(this.rf_infoversion);
			this.page_RacialFlags.Controls.Add(this.rf_infoversion_label);
			this.page_RacialFlags.Controls.Add(this.rf_bin);
			this.page_RacialFlags.Controls.Add(this.rf_hex);
			this.page_RacialFlags.Controls.Add(this.rf_Clear);
			this.page_RacialFlags.Controls.Add(this.RacialFlags_bin);
			this.page_RacialFlags.Controls.Add(this.RacialFlags_hex);
			this.page_RacialFlags.Controls.Add(this.RacialFlags_text);
			this.page_RacialFlags.Controls.Add(this.RacialFlags_reset);
			this.page_RacialFlags.Location = new System.Drawing.Point(4, 24);
			this.page_RacialFlags.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFlags.Name = "page_RacialFlags";
			this.page_RacialFlags.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFlags.Size = new System.Drawing.Size(812, 237);
			this.page_RacialFlags.TabIndex = 0;
			this.page_RacialFlags.Text = "Flags";
			this.page_RacialFlags.UseVisualStyleBackColor = true;
			// 
			// rf_HasFeatSpells
			// 
			this.rf_HasFeatSpells.Location = new System.Drawing.Point(15, 70);
			this.rf_HasFeatSpells.Margin = new System.Windows.Forms.Padding(0);
			this.rf_HasFeatSpells.Name = "rf_HasFeatSpells";
			this.rf_HasFeatSpells.Size = new System.Drawing.Size(125, 19);
			this.rf_HasFeatSpells.TabIndex = 50;
			this.rf_HasFeatSpells.Text = "has FeatSpells";
			this.rf_HasFeatSpells.UseVisualStyleBackColor = true;
			this.rf_HasFeatSpells.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFlags);
			// 
			// rf_infoversion
			// 
			this.rf_infoversion.Location = new System.Drawing.Point(520, 35);
			this.rf_infoversion.Margin = new System.Windows.Forms.Padding(0);
			this.rf_infoversion.Name = "rf_infoversion";
			this.rf_infoversion.Size = new System.Drawing.Size(95, 15);
			this.rf_infoversion.TabIndex = 49;
			this.rf_infoversion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// rf_infoversion_label
			// 
			this.rf_infoversion_label.Location = new System.Drawing.Point(520, 15);
			this.rf_infoversion_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf_infoversion_label.Name = "rf_infoversion_label";
			this.rf_infoversion_label.Size = new System.Drawing.Size(95, 15);
			this.rf_infoversion_label.TabIndex = 48;
			this.rf_infoversion_label.Text = "Info Version";
			// 
			// rf_bin
			// 
			this.rf_bin.Location = new System.Drawing.Point(395, 35);
			this.rf_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf_bin.Name = "rf_bin";
			this.rf_bin.Size = new System.Drawing.Size(45, 15);
			this.rf_bin.TabIndex = 47;
			this.rf_bin.Text = "- bin";
			this.rf_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf_hex
			// 
			this.rf_hex.Location = new System.Drawing.Point(395, 15);
			this.rf_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf_hex.Name = "rf_hex";
			this.rf_hex.Size = new System.Drawing.Size(45, 15);
			this.rf_hex.TabIndex = 46;
			this.rf_hex.Text = "- hex";
			this.rf_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf_Clear
			// 
			this.rf_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf_Clear.Name = "rf_Clear";
			this.rf_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf_Clear.TabIndex = 45;
			this.rf_Clear.Text = "zero\r\nall\r\nbits";
			this.rf_Clear.UseVisualStyleBackColor = true;
			this.rf_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFlags_bin
			// 
			this.RacialFlags_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFlags_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFlags_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFlags_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_bin.Name = "RacialFlags_bin";
			this.RacialFlags_bin.ReadOnly = true;
			this.RacialFlags_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFlags_bin.TabIndex = 43;
			// 
			// RacialFlags_hex
			// 
			this.RacialFlags_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFlags_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFlags_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFlags_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_hex.Name = "RacialFlags_hex";
			this.RacialFlags_hex.ReadOnly = true;
			this.RacialFlags_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFlags_hex.TabIndex = 44;
			// 
			// RacialFlags_text
			// 
			this.RacialFlags_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFlags_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_text.Name = "RacialFlags_text";
			this.RacialFlags_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFlags_text.TabIndex = 42;
			this.RacialFlags_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFlags_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFlags_reset
			// 
			this.RacialFlags_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFlags_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_reset.Name = "RacialFlags_reset";
			this.RacialFlags_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFlags_reset.TabIndex = 41;
			this.toolTip1.SetToolTip(this.RacialFlags_reset, "reset");
			this.RacialFlags_reset.UseVisualStyleBackColor = true;
			this.RacialFlags_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// page_RacialFeat1
			// 
			this.page_RacialFeat1.Controls.Add(this.rf1_SpellId);
			this.page_RacialFeat1.Controls.Add(this.rf1_FeatId);
			this.page_RacialFeat1.Controls.Add(this.rf1_cheatCast);
			this.page_RacialFeat1.Controls.Add(this.rf1_spellId_label);
			this.page_RacialFeat1.Controls.Add(this.rf1_featId_label);
			this.page_RacialFeat1.Controls.Add(this.rf1_bin);
			this.page_RacialFeat1.Controls.Add(this.rf1_hex);
			this.page_RacialFeat1.Controls.Add(this.rf1_Clear);
			this.page_RacialFeat1.Controls.Add(this.RacialFeat1_bin);
			this.page_RacialFeat1.Controls.Add(this.RacialFeat1_hex);
			this.page_RacialFeat1.Controls.Add(this.RacialFeat1_text);
			this.page_RacialFeat1.Controls.Add(this.RacialFeat1_reset);
			this.page_RacialFeat1.Location = new System.Drawing.Point(4, 23);
			this.page_RacialFeat1.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat1.Name = "page_RacialFeat1";
			this.page_RacialFeat1.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat1.Size = new System.Drawing.Size(812, 238);
			this.page_RacialFeat1.TabIndex = 1;
			this.page_RacialFeat1.Text = "FeatSpell1";
			this.page_RacialFeat1.UseVisualStyleBackColor = true;
			// 
			// rf1_SpellId
			// 
			this.rf1_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf1_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_SpellId.Name = "rf1_SpellId";
			this.rf1_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf1_SpellId.TabIndex = 59;
			this.rf1_SpellId.TextChanged += new System.EventHandler(this.TextChanged_rSpell);
			// 
			// rf1_FeatId
			// 
			this.rf1_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf1_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_FeatId.Name = "rf1_FeatId";
			this.rf1_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf1_FeatId.TabIndex = 58;
			this.rf1_FeatId.TextChanged += new System.EventHandler(this.TextChanged_rFeat);
			// 
			// rf1_cheatCast
			// 
			this.rf1_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf1_cheatCast.Name = "rf1_cheatCast";
			this.rf1_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.rf1_cheatCast.TabIndex = 57;
			this.rf1_cheatCast.Text = "cheat cast";
			this.rf1_cheatCast.UseVisualStyleBackColor = true;
			this.rf1_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFeats);
			// 
			// rf1_spellId_label
			// 
			this.rf1_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf1_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_spellId_label.Name = "rf1_spellId_label";
			this.rf1_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf1_spellId_label.TabIndex = 56;
			this.rf1_spellId_label.Text = "ID Spell";
			this.rf1_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_featId_label
			// 
			this.rf1_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf1_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_featId_label.Name = "rf1_featId_label";
			this.rf1_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf1_featId_label.TabIndex = 55;
			this.rf1_featId_label.Text = "ID Feat";
			this.rf1_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_bin
			// 
			this.rf1_bin.Location = new System.Drawing.Point(395, 35);
			this.rf1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_bin.Name = "rf1_bin";
			this.rf1_bin.Size = new System.Drawing.Size(45, 15);
			this.rf1_bin.TabIndex = 54;
			this.rf1_bin.Text = "- bin";
			this.rf1_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_hex
			// 
			this.rf1_hex.Location = new System.Drawing.Point(395, 15);
			this.rf1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_hex.Name = "rf1_hex";
			this.rf1_hex.Size = new System.Drawing.Size(45, 15);
			this.rf1_hex.TabIndex = 53;
			this.rf1_hex.Text = "- hex";
			this.rf1_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_Clear
			// 
			this.rf1_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf1_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_Clear.Name = "rf1_Clear";
			this.rf1_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf1_Clear.TabIndex = 52;
			this.rf1_Clear.Text = "zero\r\nall\r\nbits";
			this.rf1_Clear.UseVisualStyleBackColor = true;
			this.rf1_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFeat1_bin
			// 
			this.RacialFeat1_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat1_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat1_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFeat1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_bin.Name = "RacialFeat1_bin";
			this.RacialFeat1_bin.ReadOnly = true;
			this.RacialFeat1_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat1_bin.TabIndex = 50;
			// 
			// RacialFeat1_hex
			// 
			this.RacialFeat1_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat1_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat1_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFeat1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_hex.Name = "RacialFeat1_hex";
			this.RacialFeat1_hex.ReadOnly = true;
			this.RacialFeat1_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat1_hex.TabIndex = 51;
			// 
			// RacialFeat1_text
			// 
			this.RacialFeat1_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat1_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_text.Name = "RacialFeat1_text";
			this.RacialFeat1_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat1_text.TabIndex = 49;
			this.RacialFeat1_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFeat1_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFeat1_reset
			// 
			this.RacialFeat1_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat1_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_reset.Name = "RacialFeat1_reset";
			this.RacialFeat1_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat1_reset.TabIndex = 48;
			this.toolTip1.SetToolTip(this.RacialFeat1_reset, "reset");
			this.RacialFeat1_reset.UseVisualStyleBackColor = true;
			this.RacialFeat1_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// page_RacialFeat2
			// 
			this.page_RacialFeat2.Controls.Add(this.rf2_SpellId);
			this.page_RacialFeat2.Controls.Add(this.rf2_FeatId);
			this.page_RacialFeat2.Controls.Add(this.rf2_cheatCast);
			this.page_RacialFeat2.Controls.Add(this.rf2_spellId_label);
			this.page_RacialFeat2.Controls.Add(this.rf2_featId_label);
			this.page_RacialFeat2.Controls.Add(this.rf2_bin);
			this.page_RacialFeat2.Controls.Add(this.rf2_hex);
			this.page_RacialFeat2.Controls.Add(this.rf2_Clear);
			this.page_RacialFeat2.Controls.Add(this.RacialFeat2_bin);
			this.page_RacialFeat2.Controls.Add(this.RacialFeat2_hex);
			this.page_RacialFeat2.Controls.Add(this.RacialFeat2_text);
			this.page_RacialFeat2.Controls.Add(this.RacialFeat2_reset);
			this.page_RacialFeat2.Location = new System.Drawing.Point(4, 23);
			this.page_RacialFeat2.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat2.Name = "page_RacialFeat2";
			this.page_RacialFeat2.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat2.Size = new System.Drawing.Size(812, 238);
			this.page_RacialFeat2.TabIndex = 2;
			this.page_RacialFeat2.Text = "FeatSpell2";
			this.page_RacialFeat2.UseVisualStyleBackColor = true;
			// 
			// rf2_SpellId
			// 
			this.rf2_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf2_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_SpellId.Name = "rf2_SpellId";
			this.rf2_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf2_SpellId.TabIndex = 66;
			this.rf2_SpellId.TextChanged += new System.EventHandler(this.TextChanged_rSpell);
			// 
			// rf2_FeatId
			// 
			this.rf2_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf2_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_FeatId.Name = "rf2_FeatId";
			this.rf2_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf2_FeatId.TabIndex = 65;
			this.rf2_FeatId.TextChanged += new System.EventHandler(this.TextChanged_rFeat);
			// 
			// rf2_cheatCast
			// 
			this.rf2_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf2_cheatCast.Name = "rf2_cheatCast";
			this.rf2_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.rf2_cheatCast.TabIndex = 64;
			this.rf2_cheatCast.Text = "cheat cast";
			this.rf2_cheatCast.UseVisualStyleBackColor = true;
			this.rf2_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFeats);
			// 
			// rf2_spellId_label
			// 
			this.rf2_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf2_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_spellId_label.Name = "rf2_spellId_label";
			this.rf2_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf2_spellId_label.TabIndex = 63;
			this.rf2_spellId_label.Text = "ID Spell";
			this.rf2_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_featId_label
			// 
			this.rf2_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf2_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_featId_label.Name = "rf2_featId_label";
			this.rf2_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf2_featId_label.TabIndex = 62;
			this.rf2_featId_label.Text = "ID Feat";
			this.rf2_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_bin
			// 
			this.rf2_bin.Location = new System.Drawing.Point(395, 35);
			this.rf2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_bin.Name = "rf2_bin";
			this.rf2_bin.Size = new System.Drawing.Size(45, 15);
			this.rf2_bin.TabIndex = 61;
			this.rf2_bin.Text = "- bin";
			this.rf2_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_hex
			// 
			this.rf2_hex.Location = new System.Drawing.Point(395, 15);
			this.rf2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_hex.Name = "rf2_hex";
			this.rf2_hex.Size = new System.Drawing.Size(45, 15);
			this.rf2_hex.TabIndex = 60;
			this.rf2_hex.Text = "- hex";
			this.rf2_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_Clear
			// 
			this.rf2_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf2_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_Clear.Name = "rf2_Clear";
			this.rf2_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf2_Clear.TabIndex = 59;
			this.rf2_Clear.Text = "zero\r\nall\r\nbits";
			this.rf2_Clear.UseVisualStyleBackColor = true;
			this.rf2_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFeat2_bin
			// 
			this.RacialFeat2_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat2_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat2_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFeat2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_bin.Name = "RacialFeat2_bin";
			this.RacialFeat2_bin.ReadOnly = true;
			this.RacialFeat2_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat2_bin.TabIndex = 57;
			// 
			// RacialFeat2_hex
			// 
			this.RacialFeat2_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat2_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat2_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFeat2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_hex.Name = "RacialFeat2_hex";
			this.RacialFeat2_hex.ReadOnly = true;
			this.RacialFeat2_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat2_hex.TabIndex = 58;
			// 
			// RacialFeat2_text
			// 
			this.RacialFeat2_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat2_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_text.Name = "RacialFeat2_text";
			this.RacialFeat2_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat2_text.TabIndex = 56;
			this.RacialFeat2_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFeat2_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFeat2_reset
			// 
			this.RacialFeat2_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat2_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_reset.Name = "RacialFeat2_reset";
			this.RacialFeat2_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat2_reset.TabIndex = 55;
			this.toolTip1.SetToolTip(this.RacialFeat2_reset, "reset");
			this.RacialFeat2_reset.UseVisualStyleBackColor = true;
			this.RacialFeat2_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// page_RacialFeat3
			// 
			this.page_RacialFeat3.Controls.Add(this.rf3_SpellId);
			this.page_RacialFeat3.Controls.Add(this.rf3_FeatId);
			this.page_RacialFeat3.Controls.Add(this.rf3_cheatCast);
			this.page_RacialFeat3.Controls.Add(this.rf3_spellId_label);
			this.page_RacialFeat3.Controls.Add(this.rf3_featId_label);
			this.page_RacialFeat3.Controls.Add(this.rf3_bin);
			this.page_RacialFeat3.Controls.Add(this.rf3_hex);
			this.page_RacialFeat3.Controls.Add(this.rf3_Clear);
			this.page_RacialFeat3.Controls.Add(this.RacialFeat3_bin);
			this.page_RacialFeat3.Controls.Add(this.RacialFeat3_hex);
			this.page_RacialFeat3.Controls.Add(this.RacialFeat3_text);
			this.page_RacialFeat3.Controls.Add(this.RacialFeat3_reset);
			this.page_RacialFeat3.Location = new System.Drawing.Point(4, 23);
			this.page_RacialFeat3.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat3.Name = "page_RacialFeat3";
			this.page_RacialFeat3.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat3.Size = new System.Drawing.Size(812, 238);
			this.page_RacialFeat3.TabIndex = 3;
			this.page_RacialFeat3.Text = "FeatSpell3";
			this.page_RacialFeat3.UseVisualStyleBackColor = true;
			// 
			// rf3_SpellId
			// 
			this.rf3_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf3_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_SpellId.Name = "rf3_SpellId";
			this.rf3_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf3_SpellId.TabIndex = 73;
			this.rf3_SpellId.TextChanged += new System.EventHandler(this.TextChanged_rSpell);
			// 
			// rf3_FeatId
			// 
			this.rf3_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf3_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_FeatId.Name = "rf3_FeatId";
			this.rf3_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf3_FeatId.TabIndex = 72;
			this.rf3_FeatId.TextChanged += new System.EventHandler(this.TextChanged_rFeat);
			// 
			// rf3_cheatCast
			// 
			this.rf3_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf3_cheatCast.Name = "rf3_cheatCast";
			this.rf3_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.rf3_cheatCast.TabIndex = 71;
			this.rf3_cheatCast.Text = "cheat cast";
			this.rf3_cheatCast.UseVisualStyleBackColor = true;
			this.rf3_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFeats);
			// 
			// rf3_spellId_label
			// 
			this.rf3_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf3_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_spellId_label.Name = "rf3_spellId_label";
			this.rf3_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf3_spellId_label.TabIndex = 70;
			this.rf3_spellId_label.Text = "ID Spell";
			this.rf3_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_featId_label
			// 
			this.rf3_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf3_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_featId_label.Name = "rf3_featId_label";
			this.rf3_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf3_featId_label.TabIndex = 69;
			this.rf3_featId_label.Text = "ID Feat";
			this.rf3_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_bin
			// 
			this.rf3_bin.Location = new System.Drawing.Point(395, 35);
			this.rf3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_bin.Name = "rf3_bin";
			this.rf3_bin.Size = new System.Drawing.Size(45, 15);
			this.rf3_bin.TabIndex = 68;
			this.rf3_bin.Text = "- bin";
			this.rf3_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_hex
			// 
			this.rf3_hex.Location = new System.Drawing.Point(395, 15);
			this.rf3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_hex.Name = "rf3_hex";
			this.rf3_hex.Size = new System.Drawing.Size(45, 15);
			this.rf3_hex.TabIndex = 67;
			this.rf3_hex.Text = "- hex";
			this.rf3_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_Clear
			// 
			this.rf3_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf3_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_Clear.Name = "rf3_Clear";
			this.rf3_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf3_Clear.TabIndex = 66;
			this.rf3_Clear.Text = "zero\r\nall\r\nbits";
			this.rf3_Clear.UseVisualStyleBackColor = true;
			this.rf3_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFeat3_bin
			// 
			this.RacialFeat3_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat3_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat3_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFeat3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_bin.Name = "RacialFeat3_bin";
			this.RacialFeat3_bin.ReadOnly = true;
			this.RacialFeat3_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat3_bin.TabIndex = 64;
			// 
			// RacialFeat3_hex
			// 
			this.RacialFeat3_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat3_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat3_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFeat3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_hex.Name = "RacialFeat3_hex";
			this.RacialFeat3_hex.ReadOnly = true;
			this.RacialFeat3_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat3_hex.TabIndex = 65;
			// 
			// RacialFeat3_text
			// 
			this.RacialFeat3_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat3_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_text.Name = "RacialFeat3_text";
			this.RacialFeat3_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat3_text.TabIndex = 63;
			this.RacialFeat3_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFeat3_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFeat3_reset
			// 
			this.RacialFeat3_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat3_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_reset.Name = "RacialFeat3_reset";
			this.RacialFeat3_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat3_reset.TabIndex = 62;
			this.toolTip1.SetToolTip(this.RacialFeat3_reset, "reset");
			this.RacialFeat3_reset.UseVisualStyleBackColor = true;
			this.RacialFeat3_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// page_RacialFeat4
			// 
			this.page_RacialFeat4.Controls.Add(this.rf4_SpellId);
			this.page_RacialFeat4.Controls.Add(this.rf4_FeatId);
			this.page_RacialFeat4.Controls.Add(this.rf4_cheatCast);
			this.page_RacialFeat4.Controls.Add(this.rf4_spellId_label);
			this.page_RacialFeat4.Controls.Add(this.rf4_featId_label);
			this.page_RacialFeat4.Controls.Add(this.rf4_bin);
			this.page_RacialFeat4.Controls.Add(this.rf4_hex);
			this.page_RacialFeat4.Controls.Add(this.rf4_Clear);
			this.page_RacialFeat4.Controls.Add(this.RacialFeat4_bin);
			this.page_RacialFeat4.Controls.Add(this.RacialFeat4_hex);
			this.page_RacialFeat4.Controls.Add(this.RacialFeat4_text);
			this.page_RacialFeat4.Controls.Add(this.RacialFeat4_reset);
			this.page_RacialFeat4.Location = new System.Drawing.Point(4, 23);
			this.page_RacialFeat4.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat4.Name = "page_RacialFeat4";
			this.page_RacialFeat4.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat4.Size = new System.Drawing.Size(812, 238);
			this.page_RacialFeat4.TabIndex = 4;
			this.page_RacialFeat4.Text = "FeatSpell4";
			this.page_RacialFeat4.UseVisualStyleBackColor = true;
			// 
			// rf4_SpellId
			// 
			this.rf4_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf4_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_SpellId.Name = "rf4_SpellId";
			this.rf4_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf4_SpellId.TabIndex = 73;
			this.rf4_SpellId.TextChanged += new System.EventHandler(this.TextChanged_rSpell);
			// 
			// rf4_FeatId
			// 
			this.rf4_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf4_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_FeatId.Name = "rf4_FeatId";
			this.rf4_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf4_FeatId.TabIndex = 72;
			this.rf4_FeatId.TextChanged += new System.EventHandler(this.TextChanged_rFeat);
			// 
			// rf4_cheatCast
			// 
			this.rf4_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf4_cheatCast.Name = "rf4_cheatCast";
			this.rf4_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.rf4_cheatCast.TabIndex = 71;
			this.rf4_cheatCast.Text = "cheat cast";
			this.rf4_cheatCast.UseVisualStyleBackColor = true;
			this.rf4_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFeats);
			// 
			// rf4_spellId_label
			// 
			this.rf4_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf4_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_spellId_label.Name = "rf4_spellId_label";
			this.rf4_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf4_spellId_label.TabIndex = 70;
			this.rf4_spellId_label.Text = "ID Spell";
			this.rf4_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_featId_label
			// 
			this.rf4_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf4_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_featId_label.Name = "rf4_featId_label";
			this.rf4_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf4_featId_label.TabIndex = 69;
			this.rf4_featId_label.Text = "ID Feat";
			this.rf4_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_bin
			// 
			this.rf4_bin.Location = new System.Drawing.Point(395, 35);
			this.rf4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_bin.Name = "rf4_bin";
			this.rf4_bin.Size = new System.Drawing.Size(45, 15);
			this.rf4_bin.TabIndex = 68;
			this.rf4_bin.Text = "- bin";
			this.rf4_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_hex
			// 
			this.rf4_hex.Location = new System.Drawing.Point(395, 15);
			this.rf4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_hex.Name = "rf4_hex";
			this.rf4_hex.Size = new System.Drawing.Size(45, 15);
			this.rf4_hex.TabIndex = 67;
			this.rf4_hex.Text = "- hex";
			this.rf4_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_Clear
			// 
			this.rf4_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf4_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_Clear.Name = "rf4_Clear";
			this.rf4_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf4_Clear.TabIndex = 66;
			this.rf4_Clear.Text = "zero\r\nall\r\nbits";
			this.rf4_Clear.UseVisualStyleBackColor = true;
			this.rf4_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFeat4_bin
			// 
			this.RacialFeat4_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat4_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat4_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFeat4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_bin.Name = "RacialFeat4_bin";
			this.RacialFeat4_bin.ReadOnly = true;
			this.RacialFeat4_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat4_bin.TabIndex = 64;
			// 
			// RacialFeat4_hex
			// 
			this.RacialFeat4_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat4_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat4_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFeat4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_hex.Name = "RacialFeat4_hex";
			this.RacialFeat4_hex.ReadOnly = true;
			this.RacialFeat4_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat4_hex.TabIndex = 65;
			// 
			// RacialFeat4_text
			// 
			this.RacialFeat4_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat4_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_text.Name = "RacialFeat4_text";
			this.RacialFeat4_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat4_text.TabIndex = 63;
			this.RacialFeat4_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFeat4_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFeat4_reset
			// 
			this.RacialFeat4_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat4_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_reset.Name = "RacialFeat4_reset";
			this.RacialFeat4_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat4_reset.TabIndex = 62;
			this.toolTip1.SetToolTip(this.RacialFeat4_reset, "reset");
			this.RacialFeat4_reset.UseVisualStyleBackColor = true;
			this.RacialFeat4_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// page_RacialFeat5
			// 
			this.page_RacialFeat5.Controls.Add(this.rf5_SpellId);
			this.page_RacialFeat5.Controls.Add(this.rf5_FeatId);
			this.page_RacialFeat5.Controls.Add(this.rf5_cheatCast);
			this.page_RacialFeat5.Controls.Add(this.rf5_spellId_label);
			this.page_RacialFeat5.Controls.Add(this.rf5_featId_label);
			this.page_RacialFeat5.Controls.Add(this.rf5_bin);
			this.page_RacialFeat5.Controls.Add(this.rf5_hex);
			this.page_RacialFeat5.Controls.Add(this.rf5_Clear);
			this.page_RacialFeat5.Controls.Add(this.RacialFeat5_bin);
			this.page_RacialFeat5.Controls.Add(this.RacialFeat5_hex);
			this.page_RacialFeat5.Controls.Add(this.RacialFeat5_text);
			this.page_RacialFeat5.Controls.Add(this.RacialFeat5_reset);
			this.page_RacialFeat5.Location = new System.Drawing.Point(4, 23);
			this.page_RacialFeat5.Margin = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat5.Name = "page_RacialFeat5";
			this.page_RacialFeat5.Padding = new System.Windows.Forms.Padding(2);
			this.page_RacialFeat5.Size = new System.Drawing.Size(812, 238);
			this.page_RacialFeat5.TabIndex = 5;
			this.page_RacialFeat5.Text = "FeatSpell5";
			this.page_RacialFeat5.UseVisualStyleBackColor = true;
			// 
			// rf5_SpellId
			// 
			this.rf5_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf5_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_SpellId.Name = "rf5_SpellId";
			this.rf5_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf5_SpellId.TabIndex = 73;
			this.rf5_SpellId.TextChanged += new System.EventHandler(this.TextChanged_rSpell);
			// 
			// rf5_FeatId
			// 
			this.rf5_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf5_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_FeatId.Name = "rf5_FeatId";
			this.rf5_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf5_FeatId.TabIndex = 72;
			this.rf5_FeatId.TextChanged += new System.EventHandler(this.TextChanged_rFeat);
			// 
			// rf5_cheatCast
			// 
			this.rf5_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf5_cheatCast.Name = "rf5_cheatCast";
			this.rf5_cheatCast.Size = new System.Drawing.Size(100, 19);
			this.rf5_cheatCast.TabIndex = 71;
			this.rf5_cheatCast.Text = "cheat cast";
			this.rf5_cheatCast.UseVisualStyleBackColor = true;
			this.rf5_cheatCast.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick_rFeats);
			// 
			// rf5_spellId_label
			// 
			this.rf5_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf5_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_spellId_label.Name = "rf5_spellId_label";
			this.rf5_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf5_spellId_label.TabIndex = 70;
			this.rf5_spellId_label.Text = "ID Spell";
			this.rf5_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_featId_label
			// 
			this.rf5_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf5_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_featId_label.Name = "rf5_featId_label";
			this.rf5_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf5_featId_label.TabIndex = 69;
			this.rf5_featId_label.Text = "ID Feat";
			this.rf5_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_bin
			// 
			this.rf5_bin.Location = new System.Drawing.Point(395, 35);
			this.rf5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_bin.Name = "rf5_bin";
			this.rf5_bin.Size = new System.Drawing.Size(45, 15);
			this.rf5_bin.TabIndex = 68;
			this.rf5_bin.Text = "- bin";
			this.rf5_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_hex
			// 
			this.rf5_hex.Location = new System.Drawing.Point(395, 15);
			this.rf5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_hex.Name = "rf5_hex";
			this.rf5_hex.Size = new System.Drawing.Size(45, 15);
			this.rf5_hex.TabIndex = 67;
			this.rf5_hex.Text = "- hex";
			this.rf5_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_Clear
			// 
			this.rf5_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf5_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_Clear.Name = "rf5_Clear";
			this.rf5_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf5_Clear.TabIndex = 66;
			this.rf5_Clear.Text = "zero\r\nall\r\nbits";
			this.rf5_Clear.UseVisualStyleBackColor = true;
			this.rf5_Clear.Click += new System.EventHandler(this.Click_clear);
			// 
			// RacialFeat5_bin
			// 
			this.RacialFeat5_bin.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat5_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat5_bin.Location = new System.Drawing.Point(115, 35);
			this.RacialFeat5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_bin.Name = "RacialFeat5_bin";
			this.RacialFeat5_bin.ReadOnly = true;
			this.RacialFeat5_bin.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat5_bin.TabIndex = 64;
			// 
			// RacialFeat5_hex
			// 
			this.RacialFeat5_hex.BackColor = System.Drawing.SystemColors.Window;
			this.RacialFeat5_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.RacialFeat5_hex.Location = new System.Drawing.Point(115, 15);
			this.RacialFeat5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_hex.Name = "RacialFeat5_hex";
			this.RacialFeat5_hex.ReadOnly = true;
			this.RacialFeat5_hex.Size = new System.Drawing.Size(275, 13);
			this.RacialFeat5_hex.TabIndex = 65;
			// 
			// RacialFeat5_text
			// 
			this.RacialFeat5_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat5_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_text.Name = "RacialFeat5_text";
			this.RacialFeat5_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat5_text.TabIndex = 63;
			this.RacialFeat5_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.RacialFeat5_text.TextChanged += new System.EventHandler(this.TextChanged_racial);
			// 
			// RacialFeat5_reset
			// 
			this.RacialFeat5_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat5_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_reset.Name = "RacialFeat5_reset";
			this.RacialFeat5_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat5_reset.TabIndex = 62;
			this.toolTip1.SetToolTip(this.RacialFeat5_reset, "reset");
			this.RacialFeat5_reset.UseVisualStyleBackColor = true;
			this.RacialFeat5_reset.Click += new System.EventHandler(this.Click_racial_reset);
			// 
			// apply
			// 
			this.apply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.apply.Location = new System.Drawing.Point(0, 944);
			this.apply.Name = "apply";
			this.apply.Size = new System.Drawing.Size(1074, 25);
			this.apply.TabIndex = 1;
			this.apply.Text = "apply this tree-node\'s data";
			this.apply.UseVisualStyleBackColor = true;
			this.apply.Click += new System.EventHandler(this.Click_apply);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1352, 993);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "nwn2_ai_2da_editor";
			this.cols_HenchSpells.ResumeLayout(false);
			this.page_SpellInfo.ResumeLayout(false);
			this.page_SpellInfo.PerformLayout();
			this.si_ChildIDGrp.ResumeLayout(false);
			this.si_ChildIDGrp.PerformLayout();
			this.si_FlagsGrp.ResumeLayout(false);
			this.si_SpelllevelGrp.ResumeLayout(false);
			this.si_SpelltypeGrp.ResumeLayout(false);
			this.page_TargetInfo.ResumeLayout(false);
			this.page_TargetInfo.PerformLayout();
			this.ti_RadiusGrp.ResumeLayout(false);
			this.ti_RadiusGrp.PerformLayout();
			this.ti_RangeGrp.ResumeLayout(false);
			this.ti_ShapeGrp.ResumeLayout(false);
			this.ti_FlagsGrp.ResumeLayout(false);
			this.page_EffectWeight.ResumeLayout(false);
			this.page_EffectWeight.PerformLayout();
			this.page_EffectTypes.ResumeLayout(false);
			this.page_EffectTypes.PerformLayout();
			this.et_DetEffectsGrp.ResumeLayout(false);
			this.et_BenEffectsGrp.ResumeLayout(false);
			this.page_DamageInfo.ResumeLayout(false);
			this.page_DamageInfo.PerformLayout();
			this.di_DetrimentalGrp.ResumeLayout(false);
			this.di_DetDamageGrp.ResumeLayout(false);
			this.di_DetDamageGrp.PerformLayout();
			this.di_DetDamagetypeGrp.ResumeLayout(false);
			this.di_DetLeveldivisorGrp.ResumeLayout(false);
			this.di_DetLeveldivisorGrp.PerformLayout();
			this.di_DetLevellimitGrp.ResumeLayout(false);
			this.di_DetLevellimitGrp.PerformLayout();
			this.di_DetFixedCountGrp.ResumeLayout(false);
			this.di_DetFixedCountGrp.PerformLayout();
			this.di_DetDamagebaseGrp.ResumeLayout(false);
			this.di_DetLeveltypeGrp.ResumeLayout(false);
			this.di_BeneficialGrp.ResumeLayout(false);
			this.di_BenLeveldecreaseGrp.ResumeLayout(false);
			this.di_BenLeveldecreaseGrp.PerformLayout();
			this.di_BenPowerbaseGrp.ResumeLayout(false);
			this.di_BenPowerGrp.ResumeLayout(false);
			this.di_BenPowerGrp.PerformLayout();
			this.di_BenLeveldivisorGrp.ResumeLayout(false);
			this.di_BenLeveldivisorGrp.PerformLayout();
			this.di_BenLevellimitGrp.ResumeLayout(false);
			this.di_BenLevellimitGrp.PerformLayout();
			this.di_BenLeveltypeGrp.ResumeLayout(false);
			this.di_DispelTypesGrp.ResumeLayout(false);
			this.page_SaveType.ResumeLayout(false);
			this.page_SaveType.PerformLayout();
			this.st_DetrimentalGrp.ResumeLayout(false);
			this.st_SpecificGrp.ResumeLayout(false);
			this.st_Immunity2Grp.ResumeLayout(false);
			this.st_Immunity1Grp.ResumeLayout(false);
			this.st_FlagsGrp.ResumeLayout(false);
			this.st_Impact1Grp.ResumeLayout(false);
			this.st_Impact2Grp.ResumeLayout(false);
			this.st_Save2Grp.ResumeLayout(false);
			this.st_Save1Grp.ResumeLayout(false);
			this.st_ExclusiveGrp.ResumeLayout(false);
			this.st_Excl_FlagsGrp.ResumeLayout(false);
			this.st_Excl_WeightGrp.ResumeLayout(false);
			this.st_Excl_WeightGrp.PerformLayout();
			this.st_Excl_DamagetypesGrp.ResumeLayout(false);
			this.st_AcBonusGrp.ResumeLayout(false);
			this.st_TargetRestrictionGrp.ResumeLayout(false);
			this.page_SaveDCType.ResumeLayout(false);
			this.page_SaveDCType.PerformLayout();
			this.dc_ArmorCheckGrp.ResumeLayout(false);
			this.dc_WeaponBonusGrp.ResumeLayout(false);
			this.dc_SaveDCGrp.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.cols_HenchClasses.ResumeLayout(false);
			this.page_ClassFlags.ResumeLayout(false);
			this.page_ClassFlags.PerformLayout();
			this.page_ClassFeat1.ResumeLayout(false);
			this.page_ClassFeat1.PerformLayout();
			this.page_ClassFeat2.ResumeLayout(false);
			this.page_ClassFeat2.PerformLayout();
			this.page_ClassFeat3.ResumeLayout(false);
			this.page_ClassFeat3.PerformLayout();
			this.page_ClassFeat4.ResumeLayout(false);
			this.page_ClassFeat4.PerformLayout();
			this.page_ClassFeat5.ResumeLayout(false);
			this.page_ClassFeat5.PerformLayout();
			this.page_ClassFeat6.ResumeLayout(false);
			this.page_ClassFeat6.PerformLayout();
			this.page_ClassFeat7.ResumeLayout(false);
			this.page_ClassFeat7.PerformLayout();
			this.page_ClassFeat8.ResumeLayout(false);
			this.page_ClassFeat8.PerformLayout();
			this.page_ClassFeat9.ResumeLayout(false);
			this.page_ClassFeat9.PerformLayout();
			this.page_ClassFeat10.ResumeLayout(false);
			this.page_ClassFeat10.PerformLayout();
			this.page_ClassFeat11.ResumeLayout(false);
			this.page_ClassFeat11.PerformLayout();
			this.cols_HenchRacial.ResumeLayout(false);
			this.page_RacialFlags.ResumeLayout(false);
			this.page_RacialFlags.PerformLayout();
			this.page_RacialFeat1.ResumeLayout(false);
			this.page_RacialFeat1.PerformLayout();
			this.page_RacialFeat2.ResumeLayout(false);
			this.page_RacialFeat2.PerformLayout();
			this.page_RacialFeat3.ResumeLayout(false);
			this.page_RacialFeat3.PerformLayout();
			this.page_RacialFeat4.ResumeLayout(false);
			this.page_RacialFeat4.PerformLayout();
			this.page_RacialFeat5.ResumeLayout(false);
			this.page_RacialFeat5.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
