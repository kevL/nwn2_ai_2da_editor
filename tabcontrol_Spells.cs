using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A UserControl with a TabControl set to Dock.Fill.
	/// </summary>
	sealed partial class tabcontrol_Spells
		: HenchControl
	{
		#region Fields (static)
		/// <summary>
		/// Bitflags for spell-fields that have changed.
		/// @note: The master-int 'differ' is tracked in each spell-struct but
		/// is not saved to file.
		/// </summary>
		internal const int bit_clean        = 0x00;
		internal const int bit_spellinfo    = 0x01;
				 const int bit_targetinfo   = 0x02;
				 const int bit_effectweight = 0x04;
				 const int bit_effecttypes  = 0x08;
				 const int bit_damageinfo   = 0x10;
				 const int bit_savetype     = 0x20;
				 const int bit_savedctype   = 0x40;
		#endregion Fields (static)


		#region Fields
		he _he;

		bool BypassSubspell;
		#endregion Fields


		#region cTor
		internal tabcontrol_Spells(he he)
		{
			InitializeComponent();

			_he = he;

			si_SubspellLabel1.Text =
			si_SubspellLabel2.Text =
			si_SubspellLabel3.Text =
			si_SubspellLabel4.Text =
			si_SubspellLabel5.Text = String.Empty;

			SpellInfo_hex  .BackColor = // set the backgrounds of the hexadecimal and binary
			SpellInfo_bin  .BackColor = // textboxes to blend in with the background
			TargetInfo_hex .BackColor =
			TargetInfo_bin .BackColor =
			EffectTypes_hex.BackColor =
			EffectTypes_bin.BackColor =
			DamageInfo_hex .BackColor =
			DamageInfo_bin .BackColor =
			SaveType_hex   .BackColor =
			SaveType_bin   .BackColor =
			SaveDCType_hex .BackColor =
			SaveDCType_bin .BackColor = tp_SpellInfo.BackColor;

			SpellInfo_hex  .Font =
			SpellInfo_bin  .Font =
			TargetInfo_hex .Font =
			TargetInfo_bin .Font =
			EffectTypes_hex.Font =
			EffectTypes_bin.Font =
			DamageInfo_hex .Font =
			DamageInfo_bin .Font =
			SaveType_hex   .Font =
			SaveType_bin   .Font =
			SaveDCType_hex .Font =
			SaveDCType_bin .Font = he.FixedFont;

			// Groups on SpellInfo and TargetInfo generally stay green unless
			// SpellInfo is flagged as a MasterID
			SetDefaultGroupColors();

			initCos();


			tc_Spells.SelectedIndexChanged += SelectedIndexChanged_tab;

// handlers for SpellInfo ->
			SpellInfo_reset.Click       += Click_si_reset;
			SpellInfo_text .TextChanged += TextChanged_si;

			si_Clear.Click += Click_clear;

			si_co_Spelltype.SelectionChangeCommitted += SelectionChangeCommitted_si_co_Spelltype;

			si_Ignore       .MouseClick += MouseClick_si_Flags;
			si_IsMaster     .MouseClick += MouseClick_si_Flags;
			si_Concentration.MouseClick += MouseClick_si_Flags;
			si_HealOrCure   .MouseClick += MouseClick_si_Flags;
			si_ItemCast     .MouseClick += MouseClick_si_Flags;
			si_Unlimited    .MouseClick += MouseClick_si_Flags;
			si_ShortDurBuff .MouseClick += MouseClick_si_Flags;
			si_MediumDurBuff.MouseClick += MouseClick_si_Flags;
			si_LongDurBuff  .MouseClick += MouseClick_si_Flags;
//			si_NonVerbal    .MouseClick += MouseClick_si_Flags;

			si_co_Spelllevel.SelectionChangeCommitted += SelectionChangeCommitted_si_co_Spelllevel;

			si_Subspell1.TextChanged += TextChanged_si_Subspell;
			si_Subspell2.TextChanged += TextChanged_si_Subspell;
			si_Subspell3.TextChanged += TextChanged_si_Subspell;
			si_Subspell4.TextChanged += TextChanged_si_Subspell;
			si_Subspell5.TextChanged += TextChanged_si_Subspell;

			si_Extend    .MouseClick += MouseClick_si_Metamagic;
			si_Empower   .MouseClick += MouseClick_si_Metamagic;
			si_Maximize  .MouseClick += MouseClick_si_Metamagic;
			si_Persistent.MouseClick += MouseClick_si_Metamagic;

// handlers for TargetInfo ->
			TargetInfo_reset.Click       += Click_ti_reset;
			TargetInfo_text .TextChanged += TextChanged_ti;

			ti_Clear.Click += Click_clear;

			ti_ShapeLoop          .MouseClick += MouseClick_ti_Flags;
			ti_CheckCount         .MouseClick += MouseClick_ti_Flags;
			ti_MissileTargets     .MouseClick += MouseClick_ti_Flags;
			ti_SecondaryTargets   .MouseClick += MouseClick_ti_Flags;
			ti_SecondaryHalfDamage.MouseClick += MouseClick_ti_Flags;
			ti_SeenRequired       .MouseClick += MouseClick_ti_Flags;
			ti_RangedSelectedArea .MouseClick += MouseClick_ti_Flags;
			ti_PersistentAoe      .MouseClick += MouseClick_ti_Flags;
			ti_ScaledEffect       .MouseClick += MouseClick_ti_Flags;
			ti_Necromancy         .MouseClick += MouseClick_ti_Flags;
			ti_Regular            .MouseClick += MouseClick_ti_Flags;

			ti_co_Shape.SelectionChangeCommitted += SelectionChangeCommitted_ti_co_Shape;

			ti_co_Range.SelectionChangeCommitted += SelectionChangeCommitted_ti_co_Range;

			ti_Radius.TextChanged += TextChanged_ti_Radius;

// handlers for EffectWeight ->
			EffectWeight_reset.Click       += Click_ew_reset;
			EffectWeight_text .TextChanged += TextChanged_ew;

			ew_Clear.Click += Click_clear;

// handlers for EffectTypes ->
			EffectTypes_reset.Click       += Click_et_reset;
			EffectTypes_text .TextChanged += TextChanged_et;

			et_Clear.Click += Click_clear;

			et_AbilityDecrease    .MouseClick += MouseClick_et_negativeeffects;
			et_AcDecrease         .MouseClick += MouseClick_et_negativeeffects;
			et_AttackDecrease     .MouseClick += MouseClick_et_negativeeffects;
			et_Blindness          .MouseClick += MouseClick_et_negativeeffects;
			et_Charm              .MouseClick += MouseClick_et_negativeeffects;
			et_Confuse            .MouseClick += MouseClick_et_negativeeffects;
			et_Curse              .MouseClick += MouseClick_et_negativeeffects;
			et_CutsceneParalyze   .MouseClick += MouseClick_et_negativeeffects;
			et_DamageDecrease     .MouseClick += MouseClick_et_negativeeffects;
			et_Daze               .MouseClick += MouseClick_et_negativeeffects;
			et_Deafness           .MouseClick += MouseClick_et_negativeeffects;
			et_Death              .MouseClick += MouseClick_et_negativeeffects;
			et_Disease            .MouseClick += MouseClick_et_negativeeffects;
			et_Dominate           .MouseClick += MouseClick_et_negativeeffects;
			et_Dying              .MouseClick += MouseClick_et_negativeeffects;
			et_Entangle           .MouseClick += MouseClick_et_negativeeffects;
			et_Frighten           .MouseClick += MouseClick_et_negativeeffects;
			et_Knockdown          .MouseClick += MouseClick_et_negativeeffects;
			et_Mesmerize          .MouseClick += MouseClick_et_negativeeffects;
			et_NegativeLevel      .MouseClick += MouseClick_et_negativeeffects;
			et_Paralyze           .MouseClick += MouseClick_et_negativeeffects;
			et_Petrify            .MouseClick += MouseClick_et_negativeeffects;
			et_Poison             .MouseClick += MouseClick_et_negativeeffects;
			et_SavingThrowDecrease.MouseClick += MouseClick_et_negativeeffects;
			et_Silence            .MouseClick += MouseClick_et_negativeeffects;
			et_SkillDecrease      .MouseClick += MouseClick_et_negativeeffects;
			et_Sleep              .MouseClick += MouseClick_et_negativeeffects;
			et_Slow               .MouseClick += MouseClick_et_negativeeffects;
			et_SpeedDecrease      .MouseClick += MouseClick_et_negativeeffects;
			et_Stun               .MouseClick += MouseClick_et_negativeeffects;

			et_AbilityIncrease    .MouseClick += MouseClick_et_positiveeffects;
			et_AbsorbDamage       .MouseClick += MouseClick_et_positiveeffects;
			et_AcIncrease         .MouseClick += MouseClick_et_positiveeffects;
			et_AttackIncrease     .MouseClick += MouseClick_et_positiveeffects;
			et_Concealment        .MouseClick += MouseClick_et_positiveeffects;
			et_DamageIncrease     .MouseClick += MouseClick_et_positiveeffects;
			et_DamageReduction    .MouseClick += MouseClick_et_positiveeffects;
			et_ElementalShield    .MouseClick += MouseClick_et_positiveeffects;
			et_Ethereal           .MouseClick += MouseClick_et_positiveeffects;
			et_GreaterInvisibility.MouseClick += MouseClick_et_positiveeffects;
			et_Haste              .MouseClick += MouseClick_et_positiveeffects;
			et_ImmunityNecromancy .MouseClick += MouseClick_et_positiveeffects;
			et_Invisibility       .MouseClick += MouseClick_et_positiveeffects;
			et_Polymorph          .MouseClick += MouseClick_et_positiveeffects;
			et_Regenerate         .MouseClick += MouseClick_et_positiveeffects;
			et_Sanctuary          .MouseClick += MouseClick_et_positiveeffects;
			et_SavingThrowIncrease.MouseClick += MouseClick_et_positiveeffects;
			et_SeeInvisible       .MouseClick += MouseClick_et_positiveeffects;
			et_SpellAbsorption    .MouseClick += MouseClick_et_positiveeffects;
			et_SpellShield        .MouseClick += MouseClick_et_positiveeffects;
			et_TempHitpoints      .MouseClick += MouseClick_et_positiveeffects;
			et_Timestop           .MouseClick += MouseClick_et_positiveeffects;
			et_TrueSeeing         .MouseClick += MouseClick_et_positiveeffects;
			et_Ultravision        .MouseClick += MouseClick_et_positiveeffects;
			et_Wildshape          .MouseClick += MouseClick_et_positiveeffects;

// handlers for DamageInfo ->
			DamageInfo_reset.Click       += Click_di_reset;
			DamageInfo_text .TextChanged += TextChanged_di;

			di_Clear.Click += Click_clear;

			di_co_DetDamagebase.SelectionChangeCommitted += SelectionChangeCommitted_di_co_det_Damagebase;

			di_DetDamage       .TextChanged              += TextChanged_di_det_Damage;

			di_co_DetLeveltype .SelectionChangeCommitted += SelectionChangeCommitted_di_co_det_Leveltype;

			di_DetLevellimit   .TextChanged              += TextChanged_di_det_Levellimit;

			di_DetLeveldivisor .TextChanged              += TextChanged_di_det_Leveldivisor;

			di_DetFixedcount   .TextChanged              += TextChanged_di_det_Fixedcount;

			di_Magical    .MouseClick += MouseClick_di_det_Damagetype;
			di_Divine     .MouseClick += MouseClick_di_det_Damagetype;
			di_Acid       .MouseClick += MouseClick_di_det_Damagetype;
			di_Cold       .MouseClick += MouseClick_di_det_Damagetype;
			di_Electrical .MouseClick += MouseClick_di_det_Damagetype;
			di_Fire       .MouseClick += MouseClick_di_det_Damagetype;
			di_Sonic      .MouseClick += MouseClick_di_det_Damagetype;
			di_Negative   .MouseClick += MouseClick_di_det_Damagetype;
			di_Positive   .MouseClick += MouseClick_di_det_Damagetype;
			di_Bludgeoning.MouseClick += MouseClick_di_det_Damagetype;
			di_Piercing   .MouseClick += MouseClick_di_det_Damagetype;
			di_Slashing   .MouseClick += MouseClick_di_det_Damagetype;

			di_co_BenPowerbase .SelectionChangeCommitted += SelectionChangeCommitted_di_co_ben_Powerbase;

			di_BenPower        .TextChanged              += TextChanged_di_ben_Power;

			di_co_BenLeveltype .SelectionChangeCommitted += SelectionChangeCommitted_di_co_ben_Leveltype;

			di_BenLevellimit   .TextChanged              += TextChanged_di_ben_Levellimit;

			di_BenLeveldivisor .TextChanged              += TextChanged_di_ben_Leveldivisor;

			di_BenLeveldecrease.TextChanged              += TextChanged_di_ben_Leveldecrease;

			di_Breach.MouseClick += MouseClick_di_Dispeltype;
			di_Dispel.MouseClick += MouseClick_di_Dispeltype;
			di_Resist.MouseClick += MouseClick_di_Dispeltype;

// handlers for SaveType ->
			SaveType_reset.Click       += Click_st_reset;
			SaveType_text .TextChanged += TextChanged_st;

			st_Clear.Click += Click_clear;

			st_Save1rb_none.MouseClick += MouseClick_st_Type1Save;
			st_Save1rb_fort.MouseClick += MouseClick_st_Type1Save;
			st_Save1rb_refl.MouseClick += MouseClick_st_Type1Save;
			st_Save1rb_will.MouseClick += MouseClick_st_Type1Save;

			st_Save2rb_none.MouseClick += MouseClick_st_Type2Save;
			st_Save2rb_fort.MouseClick += MouseClick_st_Type2Save;
			st_Save2rb_refl.MouseClick += MouseClick_st_Type2Save;
			st_Save2rb_will.MouseClick += MouseClick_st_Type2Save;

			st_Impact1rb_effectonly   .MouseClick += MouseClick_st_Type1Damage;
			st_Impact1rb_damagehalf   .MouseClick += MouseClick_st_Type1Damage;
			st_Impact1rb_effectdamage .MouseClick += MouseClick_st_Type1Damage;
			st_Impact1rb_damageevasion.MouseClick += MouseClick_st_Type1Damage;

			st_Impact2rb_effectonly   .MouseClick += MouseClick_st_Type2Damage;
			st_Impact2rb_damagehalf   .MouseClick += MouseClick_st_Type2Damage;
			st_Impact2rb_effectdamage .MouseClick += MouseClick_st_Type2Damage;
			st_Impact2rb_damageevasion.MouseClick += MouseClick_st_Type2Damage;

			st_AffectsFriendlies.MouseClick += MouseClick_st_Flags;
			st_MindAffecting    .MouseClick += MouseClick_st_Flags;
			st_SpellResistance  .MouseClick += MouseClick_st_Flags;
			st_TouchMelee       .MouseClick += MouseClick_st_Flags;
			st_TouchRanged      .MouseClick += MouseClick_st_Flags;
			st_NotCaster        .MouseClick += MouseClick_st_Flags;

			st_co_Immunity1.SelectionChangeCommitted += SelectionChangeCommitted_st_co_Immunity1;

			st_co_Immunity2.SelectionChangeCommitted += SelectionChangeCommitted_st_co_Immunity2;

			st_co_Specific .SelectionChangeCommitted += SelectionChangeCommitted_st_co_Specific;

			st_Excl_Magical    .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Divine     .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Acid       .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Cold       .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Electrical .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Fire       .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Sonic      .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Negative   .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Positive   .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Bludgeoning.MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Piercing   .MouseClick += MouseClick_st_excl_Damagetype;
			st_Excl_Slashing   .MouseClick += MouseClick_st_excl_Damagetype;

			st_Excl_Weight.TextChanged += TextChanged_st_excl_Weight;

			st_Excl_rbResistance.MouseClick += MouseClick_st_excl_Flags;
			st_Excl_rbImmunity  .MouseClick += MouseClick_st_excl_Flags;
			st_Excl_Onlyone     .MouseClick += MouseClick_st_excl_Flags;
			st_Excl_General     .MouseClick += MouseClick_st_excl_Flags;

			st_co_AcBonus.SelectionChangeCommitted += SelectionChangeCommitted_st_co_AcBonus;

			st_ReduceNotEnlarge.MouseClick += MouseClick_st_SizeEffect;
			st_AnimalOnly      .MouseClick += MouseClick_st_SizeEffect;
			st_NotHumanoid     .MouseClick += MouseClick_st_SizeEffect;

			st_co_TargetRestriction.SelectionChangeCommitted += SelectionChangeCommitted_st_co_Weapon;

// handlers for SaveDCType ->
			SaveDCType_reset.Click       += Click_dc_reset;
			SaveDCType_text .TextChanged += TextChanged_dc;

			dc_Clear.Click += Click_clear;

			dc_co_SaveDC.SelectionChangeCommitted += SelectionChangeCommitted_dc_savedctype;
			savedc_up   .Click                    += Click_dc_adjustors;
			savedc_dn   .Click                    += Click_dc_adjustors;

			dc_co_WeaponBonus.SelectionChangeCommitted += SelectionChangeCommitted_dc_weaponbonustype;

			savedc_ac1.MouseClick += MouseClick_dc_armorchecktype;
			savedc_ac2.MouseClick += MouseClick_dc_armorchecktype;
			savedc_ac3.MouseClick += MouseClick_dc_armorchecktype;

			_he.SelectSearch();
		}
		#endregion cTor


		#region eventhandlers
		/// <summary>
		/// Handler for selecting a tab-page.
		/// Disables the "Copy" menu-items for hexadecimal and binary if the
		/// current page is EffectWeight since its field is a float.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectedIndexChanged_tab(object sender, EventArgs e)
		{
			_he.EnableCopy(tc_Spells.SelectedIndex != 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_clear(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if      (btn == si_Clear) SpellInfo_text   .Text = "0";
			else if (btn == ti_Clear) TargetInfo_text  .Text = "0";
			else if (btn == ew_Clear) EffectWeight_text.Text = "0.0";
			else if (btn == et_Clear) EffectTypes_text .Text = "0";
			else if (btn == di_Clear) DamageInfo_text  .Text = "0";
			else if (btn == st_Clear) SaveType_text    .Text = "0";
			else                      SaveDCType_text  .Text = "0"; //if (btn == dc_Clear)
		}
		#endregion eventhandlers


		#region Methods
		/// <summary>
		/// Populates the dropdown-lists.
		/// </summary>
		void initCos()
		{
// SpellInfo ->
			// populate the dropdown list for SpellInfo - SpellType
			// NOTE: These cases are considered in 'hench_i0_itemsp' DispatchSpell()
			si_co_Spelltype.Items.Add("none or Master");		//  0
			si_co_Spelltype.Items.Add("attack");				//  1
			si_co_Spelltype.Items.Add("ac buff");				//  2
			si_co_Spelltype.Items.Add("buff");					//  3
			si_co_Spelltype.Items.Add("persistent aoe");		//  4
			si_co_Spelltype.Items.Add("polymorph");				//  5
			si_co_Spelltype.Items.Add("dispel");				//  6
			si_co_Spelltype.Items.Add("invisibility");			//  7
			si_co_Spelltype.Items.Add("cure condition");		//  8
			si_co_Spelltype.Items.Add("summon");				//  9
			si_co_Spelltype.Items.Add("heal");					// 10
			si_co_Spelltype.Items.Add("harm");					// 11
			si_co_Spelltype.Items.Add("attribute buff");		// 12
			si_co_Spelltype.Items.Add("energy protection");		// 13
			si_co_Spelltype.Items.Add("melee attack");			// 14
			si_co_Spelltype.Items.Add("arcane archer");			// 15
			si_co_Spelltype.Items.Add("spell protection");		// 16
			si_co_Spelltype.Items.Add("dragon breath");			// 17
			si_co_Spelltype.Items.Add("detect invisible");		// 18
			si_co_Spelltype.Items.Add("warlock [not used]");	// 19
			si_co_Spelltype.Items.Add("dominate");				// 20
			si_co_Spelltype.Items.Add("weapon buff");			// 21
			si_co_Spelltype.Items.Add("animal companion buff");	// 22
			si_co_Spelltype.Items.Add("protection vs evil");	// 23
			si_co_Spelltype.Items.Add("protection vs good");	// 24
			si_co_Spelltype.Items.Add("regenerate");			// 25
			si_co_Spelltype.Items.Add("gust of wind");			// 26
			si_co_Spelltype.Items.Add("elemental shield");		// 27
			si_co_Spelltype.Items.Add("turn undead");			// 28
			si_co_Spelltype.Items.Add("dr buff");				// 29
			si_co_Spelltype.Items.Add("melee attack buff");		// 30
			si_co_Spelltype.Items.Add("raise dead");			// 31
			si_co_Spelltype.Items.Add("concealment");			// 32
			si_co_Spelltype.Items.Add("attack special");		// 33
			si_co_Spelltype.Items.Add("heal special");			// 34

			// populate the dropdown list for SpellInfo - SpellLevel
			si_co_Spelllevel.Items.Add("0");
			si_co_Spelllevel.Items.Add("1");
			si_co_Spelllevel.Items.Add("2");
			si_co_Spelllevel.Items.Add("3");
			si_co_Spelllevel.Items.Add("4");
			si_co_Spelllevel.Items.Add("5");
			si_co_Spelllevel.Items.Add("6");
			si_co_Spelllevel.Items.Add("7");
			si_co_Spelllevel.Items.Add("8");
			si_co_Spelllevel.Items.Add("9");

// TargetInfo ->
			// NOTE: See 'hench_i0_itemsp' DispatchSpell()

			// populate the dropdown list for TargetInfo - Shape
			ti_co_Shape.Items.Add("spellcylinder");	// 0
			ti_co_Shape.Items.Add("cone");			// 1
			ti_co_Shape.Items.Add("cube");			// 2
			ti_co_Shape.Items.Add("spellcone");		// 3
			ti_co_Shape.Items.Add("sphere");		// 4
			ti_co_Shape.Items.Add("[not used]");	// 5
			ti_co_Shape.Items.Add("faction");		// 6
			ti_co_Shape.Items.Add("none");			// 7

			// populate the dropdown list for TargetInfo - Range
			ti_co_Range.Items.Add("personal");	// 0
			ti_co_Range.Items.Add("touch");		// 1
			ti_co_Range.Items.Add("short");		// 2
			ti_co_Range.Items.Add("medium");	// 3
			ti_co_Range.Items.Add("long");		// 4
			ti_co_Range.Items.Add("infinite");	// 5

// DamageInfo ->
			// populate the dropdown list for DamageInfo - beneficial PowerBase
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellBuffAmount()
			di_co_BenPowerbase.Items.Add("none");					// 0
			di_co_BenPowerbase.Items.Add("casterlevel");			// 1
			di_co_BenPowerbase.Items.Add("hd");						// 2
			di_co_BenPowerbase.Items.Add("fixed");					// 3
			di_co_BenPowerbase.Items.Add("charisma");				// 4
			di_co_BenPowerbase.Items.Add("bard level [not used]");	// 5
			di_co_BenPowerbase.Items.Add("dragon");					// 6

			// populate the dropdown list for DamageInfo - beneficial LevelType
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellBuffAmount()
			// NOTE: These are bit-exclusive and so could be checkboxes but ....
			di_co_BenLeveltype.Items.Add("dice");				// 0
			di_co_BenLeveltype.Items.Add("adjust");				// 1
			di_co_BenLeveltype.Items.Add("count [not used]");	// 2
			di_co_BenLeveltype.Items.Add("const");				// 3


			// populate the dropdown list for DamageInfo - detrimental DamageBase
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellDamage()
			di_co_DetDamagebase.Items.Add("casterlevel");			//  0
			di_co_DetDamagebase.Items.Add("hd");					//  1
			di_co_DetDamagebase.Items.Add("fixed");					//  2
			di_co_DetDamagebase.Items.Add("cure");					//  3
			di_co_DetDamagebase.Items.Add("dragon");				//  4
			di_co_DetDamagebase.Items.Add("special count");			//  5
			di_co_DetDamagebase.Items.Add("custom");				//  6
			di_co_DetDamagebase.Items.Add("dragon disciple");		//  7
			di_co_DetDamagebase.Items.Add("arcane archer");			//  8
			di_co_DetDamagebase.Items.Add("warpriest [not used]");	//  9
			di_co_DetDamagebase.Items.Add("lay on hands");			// 10
			di_co_DetDamagebase.Items.Add("charisma");				// 11
			di_co_DetDamagebase.Items.Add("bard perform");			// 12
			di_co_DetDamagebase.Items.Add("warlock");				// 13

			// populate the dropdown list for DamageInfo - detrimental LevelType
			// NOTE: These cases are considered in 'hench_i0_spells' GetCurrentSpellDamage()
			// NOTE: These are bit-exclusive and so could be checkboxes but ....
			di_co_DetLeveltype.Items.Add("dice");	// 0
			di_co_DetLeveltype.Items.Add("adjust");	// 1
			di_co_DetLeveltype.Items.Add("count");	// 2
			di_co_DetLeveltype.Items.Add("const");	// 3

// SaveType ->
			// populate the dropdown list for SaveType - Special type
			// NOTE: These special cases are considered in 'hench_i0_attack' HenchSpellAttack()
			st_co_Specific.Items.Add("none");											//  0
			st_co_Specific.Items.Add("heal");											//  1
			st_co_Specific.Items.Add("negative heal");									//  2
			st_co_Specific.Items.Add("targets humanoid");								//  3
			st_co_Specific.Items.Add("not already affected");							//  4
			st_co_Specific.Items.Add("does not affect incorporeal");					//  5
			st_co_Specific.Items.Add("darkness");										//  6
			st_co_Specific.Items.Add("petrify");										//  7
			st_co_Specific.Items.Add("targets animal");									//  8
			st_co_Specific.Items.Add("does not affect construct or undead");			//  9
			st_co_Specific.Items.Add("drown");											// 10
			st_co_Specific.Items.Add("sleep");											// 11
			st_co_Specific.Items.Add("bigby's hand");									// 12
			st_co_Specific.Items.Add("targets undead");									// 13
			st_co_Specific.Items.Add("does not affect undead");							// 14
			st_co_Specific.Items.Add("does not affect creatures immune to phantasms");	// 15
			st_co_Specific.Items.Add("magic missile");									// 16
			st_co_Specific.Items.Add("inferno or combust");								// 17
			st_co_Specific.Items.Add("dismissal or banishment");						// 18
			st_co_Specific.Items.Add("targets spellcasters");							// 19
			st_co_Specific.Items.Add("does not affect elf");							// 20
			st_co_Specific.Items.Add("targets construct");								// 21
			st_co_Specific.Items.Add("searing light");									// 22
			st_co_Specific.Items.Add("mindflayer's mindblast");							// 23
			st_co_Specific.Items.Add("evard's tentacles");								// 24
			st_co_Specific.Items.Add("ironhorn");										// 25
			st_co_Specific.Items.Add("prism");											// 26
			st_co_Specific.Items.Add("targets spirit");									// 27
			st_co_Specific.Items.Add("word of faith");									// 28
			st_co_Specific.Items.Add("cloudkill");										// 29
			st_co_Specific.Items.Add("targets humanoid or animal");						// 30
			st_co_Specific.Items.Add("daze");											// 31
			st_co_Specific.Items.Add("tasha's");										// 32
			st_co_Specific.Items.Add("cause fear");										// 33
			st_co_Specific.Items.Add("reduce damage-weight by target's hp%");			// 34
			st_co_Specific.Items.Add("creeping doom");									// 35
			st_co_Specific.Items.Add("deathknell");										// 36
			st_co_Specific.Items.Add("caster is warlock");								// 37
			st_co_Specific.Items.Add("moonbolt");										// 38
			st_co_Specific.Items.Add("swamplung");										// 39
			st_co_Specific.Items.Add("targets seen only");								// 40
			st_co_Specific.Items.Add("color spray");									// 41
			st_co_Specific.Items.Add("sunbeam");										// 42
			st_co_Specific.Items.Add("sunburst");										// 43
			st_co_Specific.Items.Add("targets medium or smaller creatures");			// 44
			st_co_Specific.Items.Add("castigate");										// 45
			st_co_Specific.Items.Add("target is doing fighter-like actions");			// 46
			st_co_Specific.Items.Add("does not affect deaf creatures");					// 47
			st_co_Specific.Items.Add("holy blas");										// 48
			st_co_Specific.Items.Add("targets evil");									// 49

			// populate the dropdown list for SaveType - Immunity1 type
			// NOTE: These immunity cases are considered in 'hench_i0_attack' HenchSpellAttack()
			// NOTE: These immunity cases are considered in 'hench_i0_buff'   HenchCheckBuff()
			// NOTE: These immunity cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()
			// NOTE: These immunity cases are considered in 'hench_i0_heal'   HenchCheckCureCondition()
			st_co_Immunity1.Items.Add("none");						//  0
			st_co_Immunity1.Items.Add("mind-affecting");			//  1 // these need to be shifted << 6
			st_co_Immunity1.Items.Add("poison");					//  2
			st_co_Immunity1.Items.Add("disease");					//  3
			st_co_Immunity1.Items.Add("fear");						//  4
			st_co_Immunity1.Items.Add("trap");						//  5
			st_co_Immunity1.Items.Add("paralysis");					//  6
			st_co_Immunity1.Items.Add("blindness");					//  7
			st_co_Immunity1.Items.Add("deafness");					//  8
			st_co_Immunity1.Items.Add("slow");						//  9
			st_co_Immunity1.Items.Add("entangle");					// 10
			st_co_Immunity1.Items.Add("silence");					// 11
			st_co_Immunity1.Items.Add("stun");						// 12
			st_co_Immunity1.Items.Add("sleep");						// 13
			st_co_Immunity1.Items.Add("charm");						// 14
			st_co_Immunity1.Items.Add("dominate");					// 15
			st_co_Immunity1.Items.Add("confused");					// 16
			st_co_Immunity1.Items.Add("cursed");					// 17
			st_co_Immunity1.Items.Add("dazed");						// 18
			st_co_Immunity1.Items.Add("ability decrease");			// 19
			st_co_Immunity1.Items.Add("attack decrease");			// 20
			st_co_Immunity1.Items.Add("damage decrease");			// 21
			st_co_Immunity1.Items.Add("damage immunity decrease");	// 22
			st_co_Immunity1.Items.Add("ac decrease");				// 23
			st_co_Immunity1.Items.Add("movement speed decrease");	// 24
			st_co_Immunity1.Items.Add("saving throw decrease");		// 25
			st_co_Immunity1.Items.Add("spell resistance decrease");	// 26
			st_co_Immunity1.Items.Add("skill decrease");			// 27
			st_co_Immunity1.Items.Add("knockdown");					// 28
			st_co_Immunity1.Items.Add("negative level");			// 29
			st_co_Immunity1.Items.Add("sneak attack");				// 30
			st_co_Immunity1.Items.Add("critical hit");				// 31
			st_co_Immunity1.Items.Add("death");						// 32

			// populate the dropdown list for SaveType - Immunity2 type
			// NOTE: These immunity cases are considered in 'hench_i0_attack' HenchSpellAttack()
			// NOTE: These immunity cases are considered in 'hench_i0_dispel' HenchGetAOEProblem()
			st_co_Immunity2.Items.Add("none");						//  0
			st_co_Immunity2.Items.Add("mind-affecting");			//  1 // these need to be shifted << 12
			st_co_Immunity2.Items.Add("poison");					//  2
			st_co_Immunity2.Items.Add("disease");					//  3
			st_co_Immunity2.Items.Add("fear");						//  4
			st_co_Immunity2.Items.Add("trap");						//  5
			st_co_Immunity2.Items.Add("paralysis");					//  6
			st_co_Immunity2.Items.Add("blindness");					//  7
			st_co_Immunity2.Items.Add("deafness");					//  8
			st_co_Immunity2.Items.Add("slow");						//  9
			st_co_Immunity2.Items.Add("entangle");					// 10
			st_co_Immunity2.Items.Add("silence");					// 11
			st_co_Immunity2.Items.Add("stun");						// 12
			st_co_Immunity2.Items.Add("sleep");						// 13
			st_co_Immunity2.Items.Add("charm");						// 14
			st_co_Immunity2.Items.Add("dominate");					// 15
			st_co_Immunity2.Items.Add("confused");					// 16
			st_co_Immunity2.Items.Add("cursed");					// 17
			st_co_Immunity2.Items.Add("dazed");						// 18
			st_co_Immunity2.Items.Add("ability decrease");			// 19
			st_co_Immunity2.Items.Add("attack decrease");			// 20
			st_co_Immunity2.Items.Add("damage decrease");			// 21
			st_co_Immunity2.Items.Add("damage immunity decrease");	// 22
			st_co_Immunity2.Items.Add("ac decrease");				// 23
			st_co_Immunity2.Items.Add("movement speed decrease");	// 24
			st_co_Immunity2.Items.Add("saving throw decrease");		// 25
			st_co_Immunity2.Items.Add("spell resistance decrease");	// 26
			st_co_Immunity2.Items.Add("skill decrease");			// 27
			st_co_Immunity2.Items.Add("knockdown");					// 28
			st_co_Immunity2.Items.Add("negative level");			// 29
			st_co_Immunity2.Items.Add("sneak attack");				// 30
			st_co_Immunity2.Items.Add("critical hit");				// 31
			st_co_Immunity2.Items.Add("death");						// 32

			// populate the dropdown list for SaveType - Weapon type
			// NOTE: These weapon cases are considered in 'hench_i0_buff' HenchCheckWeaponBuff()
			st_co_TargetRestriction.Items.Add("none");																		//    0
			st_co_TargetRestriction.Items.Add("target must be a staff");													//    1
			st_co_TargetRestriction.Items.Add("target must be a slashing weapon");											//    2
			st_co_TargetRestriction.Items.Add("target must be usable by a Paladin (holy sword)");							//    4
			st_co_TargetRestriction.Items.Add("target must be a bludgeoning weapon");										//    8
			st_co_TargetRestriction.Items.Add("damage increase vs undead only");											//   16
			st_co_TargetRestriction.Items.Add("target must be an animal-like creature (self or animal companion only)");	// 4096

			// populate the dropdown list for SaveType - AcBonus type
			// NOTE: These ac-bonus cases are considered in 'hench_i0_buff' HenchCheckACBuff()
			st_co_AcBonus.Items.Add("dodge or none");	// 0
			st_co_AcBonus.Items.Add("natural");			// 1 // these need to be shifted << 18
			st_co_AcBonus.Items.Add("armor");			// 2
			st_co_AcBonus.Items.Add("shield");			// 3
			st_co_AcBonus.Items.Add("deflection");		// 4

			// TODO: There are further issues in 'hench_i0_buff'.

// SaveDCType ->
			// populate the dropdown list for SaveDCType
			dc_co_SaveDC.Items.Add("spell dc standard");			// -1000
			dc_co_SaveDC.Items.Add("no save");						// 0
			dc_co_SaveDC.Items.Add("dc = 10 + hd");					// 1000
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2");				// 1001
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 4");				// 1002
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2 + Con");		// 1003
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2 + Con - 5");	// 1004
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2 + Wis");		// 1005
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2 + 5");			// 1006
			dc_co_SaveDC.Items.Add("dc = 10 + hd / 2 + Cha");		// 1007
			dc_co_SaveDC.Items.Add("disease bolt");					// 1010
			dc_co_SaveDC.Items.Add("disease cone");					// 1011
			dc_co_SaveDC.Items.Add("disease pulse");				// 1012
			dc_co_SaveDC.Items.Add("poison");						// 1013
			dc_co_SaveDC.Items.Add("epic dc");						// 1014
			dc_co_SaveDC.Items.Add("deathless master touch");		// 1020
			dc_co_SaveDC.Items.Add("undead graft");					// 1021
			dc_co_SaveDC.Items.Add("caster dc (n/a spell-level)");	// 1022
			dc_co_SaveDC.Items.Add("bardic slow");					// 1024
			dc_co_SaveDC.Items.Add("bardic fascinate");				// 1025

			// populate the dropdown list for SaveDCType - WeaponBonusType
			dc_co_WeaponBonus.Items.Add("none");									// 0
			dc_co_WeaponBonus.Items.Add("weapon bonus - (casterlevel / 4)");		// 100
			dc_co_WeaponBonus.Items.Add("weapon bonus - (casterlevel + 1) / 3");	// 101
			dc_co_WeaponBonus.Items.Add("weapon bonus - (casterlevel / 3) - 1");	// 102
		}

		/// <summary>
		/// 
		/// </summary>
		void SetDefaultGroupColors()
		{
			GroupColor(si_SpelltypeGrp,  Color.LimeGreen);
			GroupColor(si_FlagsGrp,      Color.LimeGreen);
			GroupColor(si_SpelllevelGrp, Color.LimeGreen);
			GroupColor(si_SubspellsGrp,  Color.LimeGreen);

			GroupColor(ti_FlagsGrp,      Color.LimeGreen);
			GroupColor(ti_ShapeGrp,      Color.LimeGreen);
			GroupColor(ti_RangeGrp,      Color.LimeGreen);
			GroupColor(ti_RadiusGrp,     Color.LimeGreen);
		}

		/// <summary>
		/// Sets color for the child-controls of a parent-control.
		/// NOTE: Helper for SetGroupColors()
		/// </summary>
		/// <param name="group"></param>
		/// <param name="color"></param>
		void GroupColor(Control @group, Color color)
		{
			@group.ForeColor = color;

			foreach (Control control in @group.Controls)
			{
				control.ForeColor = color;
			}
		}
		#endregion Methods


		#region HenchControl (override)
		/// <summary>
		/// 
		/// </summary>
		internal override void SelectId()
		{
			SpellInfo_text   .Clear(); // clear the info-fields to force TextChanged events ->
			TargetInfo_text  .Clear();
			EffectWeight_text.Clear();
			EffectTypes_text .Clear();
			DamageInfo_text  .Clear();
			SaveType_text    .Clear();
			SaveDCType_text  .Clear();


			Spell spell = he.Spells[he.Id];

			bool dirty = (spell.differ != bit_clean);

			SpellChanged spellchanged;
			if (dirty)
			{
				spellchanged = he.SpellsChanged[he.Id];
			}
			else
				spellchanged = new SpellChanged(); // not used.

// SpellInfo
			int val = spell.spellinfo;
			SpellInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.spellinfo;
			}
			SpellInfo_text.Text = val.ToString();

// TargetInfo
			val = spell.targetinfo;
			TargetInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.targetinfo;
			}
			TargetInfo_text.Text = val.ToString();

// EffectWeight
			string text = he.Float2daFormat(spell.effectweight);
			EffectWeight_reset.Text = text;

			if (dirty)
			{
				text = he.Float2daFormat(spellchanged.effectweight);
			}
			EffectWeight_text.Text = text;

// EffectTypes
			val = spell.effecttypes;
			EffectTypes_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.effecttypes;
			}
			EffectTypes_text.Text = val.ToString();

// DamageInfo
			val = spell.damageinfo;
			DamageInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.damageinfo;
			}
			DamageInfo_text.Text = val.ToString();

// SaveType
			val = spell.savetype;
			SaveType_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.savetype;
			}
			SaveType_text.Text = val.ToString();

// SaveDCType
			val = spell.savedctype;
			SaveDCType_reset.Text = val.ToString();

			if (dirty)
			{
				val = spellchanged.savedctype;
			}
			SaveDCType_text.Text = val.ToString();
		}

		/// <summary>
		/// Gets the master-int of the currently selected page as a string.
		/// </summary>
		/// <returns></returns>
		internal override string GetMasterText()
		{
			string info = String.Empty;
			switch (tc_Spells.SelectedIndex)
			{
				case 2: // Click_copy_decimal() only.
				{
					info = EffectWeight_text.Text;
					float f;
					if (Single.TryParse(info, out f))
						return info;

					return String.Empty;
				}

				case 0: info = SpellInfo_text  .Text; break;
				case 1: info = TargetInfo_text .Text; break;
				case 3: info = EffectTypes_text.Text; break;
				case 4: info = DamageInfo_text .Text; break;
				case 5: info = SaveType_text   .Text; break;
				case 6: info = SaveDCType_text .Text; break;
			}

			int result;
			if (Int32.TryParse(info, out result))
				return info;

			return String.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		internal override void SetMasterText(string text)
		{
			SpellInfo_text.Text = text;
		}

		/// <summary>
		/// 
		/// </summary>
		internal override void SelectResetButton()
		{
			switch (tc_Spells.SelectedIndex)
			{
				case 0: SpellInfo_reset   .Select(); break;
				case 1: TargetInfo_reset  .Select(); break;
				case 2: EffectWeight_reset.Select(); break;
				case 3: EffectTypes_reset .Select(); break;
				case 4: DamageInfo_reset  .Select(); break;
				case 5: SaveType_reset    .Select(); break;
				case 6: SaveDCType_reset  .Select(); break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="color"></param>
		internal override void SetResetColor(Color color)
		{
			SpellInfo_reset   .ForeColor =
			TargetInfo_reset  .ForeColor =
			EffectWeight_reset.ForeColor =
			EffectTypes_reset .ForeColor =
			DamageInfo_reset  .ForeColor =
			SaveType_reset    .ForeColor =
			SaveDCType_reset  .ForeColor = color;
		}

		/// <summary>
		/// The TonyAI 2.3+ sets bits of data by reading it directly from
		/// Spells.2da - such data is no longer stored in HenchSpells.2da. This
		/// funct clears those bits auto right after HenchSpells.2da loads.
		/// @note The controls are disabled on the tabpage.
		/// @note Is based on SetInfoVersion_spells(). This funct, however,
		/// ASSUMES that nothing in the spell-list has changed yet; this funct
		/// bypasses a bunch of differ-stuff that SetInfoVersion_spells()
		/// doesn't.
		/// </summary>
		internal override void UpdateSpellInfo()
		{
			Spell spell;
			SpellChanged spellchanged;

			int spellinfo0, spellinfo, differ;

			int total = he.Spells.Count;
			for (int id = 0; id != total; ++id)
			{
				spell = he.Spells[id];

				spellinfo0 = spell.spellinfo;

				spellinfo = spellinfo0 & ~(hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG
										 | hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK);

				if (spellinfo != spellinfo0)
				{
					if (id == he.Id)
					{
						he.HenchControl.SetMasterText(spellinfo.ToString()); // firing the TextChanged event takes care of it.
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

						spellchanged.spellinfo = spellinfo;

						// check it
						differ = tabcontrol_Spells.SpellDiffer(spell, spellchanged);
						spell.differ = differ;
						he.Spells[id] = spell;

						he.SpellsChanged[id] = spellchanged;
						_he.SetNodeColor(Color.Crimson, id);
					}
				}
			}
		}
		#endregion HenchControl (override)


		#region Methods (static)
		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="spell">a Spell struct</param>
		/// <param name="spellchanged">a SpellChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		internal static int SpellDiffer(Spell spell, SpellChanged spellchanged)
		{
			int differ = tabcontrol_Spells.bit_clean;

			if (spell.spellinfo != spellchanged.spellinfo)
				differ |= tabcontrol_Spells.bit_spellinfo;

			if (spell.targetinfo != spellchanged.targetinfo)
				differ |= tabcontrol_Spells.bit_targetinfo;

			if (!he.FloatsEqual(spell.effectweight, spellchanged.effectweight))
				differ |= tabcontrol_Spells.bit_effectweight;

			if (spell.effecttypes != spellchanged.effecttypes)
				differ |= tabcontrol_Spells.bit_effecttypes;

			if (spell.damageinfo != spellchanged.damageinfo)
				differ |= tabcontrol_Spells.bit_damageinfo;

			if (spell.savetype != spellchanged.savetype)
				differ |= tabcontrol_Spells.bit_savetype;

			if (spell.savedctype != spellchanged.savedctype)
				differ |= tabcontrol_Spells.bit_savedctype;

			return differ;
		}
		#endregion Methods (static)
	}
}
