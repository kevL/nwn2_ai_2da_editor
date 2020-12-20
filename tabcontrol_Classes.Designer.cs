using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class tabcontrol_Classes
	{
//		tp_Flags.Controls.Add(this.cf_infoversion);
//		tp_Flags.Controls.Add(this.cf_infoversion_lbl);

		#region Designer
		CompositedTabControl tc_Classes;

		TabPage tp_Flags;
		TabPage tp_Feat1;
		TabPage tp_Feat2;
		TabPage tp_Feat3;
		TabPage tp_Feat4;
		TabPage tp_Feat5;
		TabPage tp_Feat6;
		TabPage tp_Feat7;
		TabPage tp_Feat8;
		TabPage tp_Feat9;
		TabPage tp_Feat10;
		TabPage tp_Feat11;

// 'tp_Flags' controls
		Button  ClassFlags_reset; // TODO: ToolTip "reset"
		TextBox ClassFlags_text;
		TextBox ClassFlags_hex;
		TextBox ClassFlags_bin;

		Button cf_Clear;
		Label  cf_hex;
		Label  cf_bin;

		Label       cf_Attack_lbl;
		ComboBox    cbo_cf_Attack;
		Label       cf_SneakAttack_lbl;
		ComboBox    cbo_cf_SneakAttack;
		Label       cf_Ability_lbl;
		ComboBox    cbo_cf_Ability;
		Label       cf_SpellProg_lbl;
		ComboBox    cbo_cf_SpellProg;
		Label       cf_BuffOthers_lbl;
		ComboBox    cbo_cf_BuffOthers;
		RadioButton cf_rbArcane;
		RadioButton cf_rbDivine;
		CheckBox    cf_isPrestigeClass;
		CheckBox    cf_DcBonus;
		CheckBox    cf_L4Required;

		CheckBox cf_HasFeatSpells;

// 'tp_Feat1' controls
		Button  ClassFeat1_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat1_text;
		TextBox ClassFeat1_hex;
		TextBox ClassFeat1_bin;

		Button cf1_Clear;
		Label  cf1_hex;
		Label  cf1_bin;

		Label    cf1_featId_label;
		TextBox  cf1_FeatId;
		Label    cf1_FeatLabel;
		Label    cf1_spellId_label;
		TextBox  cf1_SpellId;
		Label    cf1_SpellLabel;
		CheckBox cf1_cheatCast;

// 'tp_Feat2' controls
		Button  ClassFeat2_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat2_text;
		TextBox ClassFeat2_hex;
		TextBox ClassFeat2_bin;

		Button cf2_Clear;
		Label  cf2_hex;
		Label  cf2_bin;

		Label    cf2_featId_label;
		TextBox  cf2_FeatId;
		Label    cf2_FeatLabel;
		Label    cf2_spellId_label;
		TextBox  cf2_SpellId;
		Label    cf2_SpellLabel;
		CheckBox cf2_cheatCast;

// 'tp_Feat3' controls
		Button  ClassFeat3_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat3_text;
		TextBox ClassFeat3_hex;
		TextBox ClassFeat3_bin;

		Button cf3_Clear;
		Label  cf3_hex;
		Label  cf3_bin;

		Label    cf3_featId_label;
		TextBox  cf3_FeatId;
		Label    cf3_FeatLabel;
		Label    cf3_spellId_label;
		TextBox  cf3_SpellId;
		Label    cf3_SpellLabel;
		CheckBox cf3_cheatCast;

// 'tp_Feat4' controls
		Button  ClassFeat4_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat4_text;
		TextBox ClassFeat4_hex;
		TextBox ClassFeat4_bin;

		Button cf4_Clear;
		Label  cf4_hex;
		Label  cf4_bin;

		Label    cf4_featId_label;
		TextBox  cf4_FeatId;
		Label    cf4_FeatLabel;
		Label    cf4_spellId_label;
		TextBox  cf4_SpellId;
		Label    cf4_SpellLabel;
		CheckBox cf4_cheatCast;

// 'tp_Feat5' controls
		Button  ClassFeat5_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat5_text;
		TextBox ClassFeat5_hex;
		TextBox ClassFeat5_bin;

		Button cf5_Clear;
		Label  cf5_hex;
		Label  cf5_bin;

		Label    cf5_featId_label;
		TextBox  cf5_FeatId;
		Label    cf5_FeatLabel;
		Label    cf5_spellId_label;
		TextBox  cf5_SpellId;
		Label    cf5_SpellLabel;
		CheckBox cf5_cheatCast;

// 'tp_Feat6' controls
		Button  ClassFeat6_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat6_text;
		TextBox ClassFeat6_hex;
		TextBox ClassFeat6_bin;

		Button cf6_Clear;
		Label  cf6_hex;
		Label  cf6_bin;

		Label    cf6_featId_label;
		TextBox  cf6_FeatId;
		Label    cf6_FeatLabel;
		Label    cf6_spellId_label;
		TextBox  cf6_SpellId;
		Label    cf6_SpellLabel;
		CheckBox cf6_cheatCast;

// 'tp_Feat7' controls
		Button  ClassFeat7_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat7_text;
		TextBox ClassFeat7_hex;
		TextBox ClassFeat7_bin;

		Button cf7_Clear;
		Label  cf7_hex;
		Label  cf7_bin;

		Label    cf7_featId_label;
		TextBox  cf7_FeatId;
		Label    cf7_FeatLabel;
		Label    cf7_spellId_label;
		TextBox  cf7_SpellId;
		Label    cf7_SpellLabel;
		CheckBox cf7_cheatCast;

// 'tp_Feat8' controls
		Button  ClassFeat8_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat8_text;
		TextBox ClassFeat8_hex;
		TextBox ClassFeat8_bin;

		Button cf8_Clear;
		Label  cf8_hex;
		Label  cf8_bin;

		Label    cf8_featId_label;
		TextBox  cf8_FeatId;
		Label    cf8_FeatLabel;
		Label    cf8_spellId_label;
		TextBox  cf8_SpellId;
		Label    cf8_SpellLabel;
		CheckBox cf8_cheatCast;

// 'tp_Feat9' controls
		Button  ClassFeat9_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat9_text;
		TextBox ClassFeat9_hex;
		TextBox ClassFeat9_bin;

		Button cf9_Clear;
		Label  cf9_hex;
		Label  cf9_bin;

		Label    cf9_featId_label;
		TextBox  cf9_FeatId;
		Label    cf9_FeatLabel;
		Label    cf9_spellId_label;
		TextBox  cf9_SpellId;
		Label    cf9_SpellLabel;
		CheckBox cf9_cheatCast;

// 'tp_Feat10' controls
		Button  ClassFeat10_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat10_text;
		TextBox ClassFeat10_hex;
		TextBox ClassFeat10_bin;

		Button cf10_Clear;
		Label  cf10_hex;
		Label  cf10_bin;

		Label    cf10_featId_label;
		TextBox  cf10_FeatId;
		Label    cf10_FeatLabel;
		Label    cf10_spellId_label;
		TextBox  cf10_SpellId;
		Label    cf10_SpellLabel;
		CheckBox cf10_cheatCast;

// 'tp_Feat11' controls
		Button  ClassFeat11_reset; // TODO: ToolTip "reset"
		TextBox ClassFeat11_text;
		TextBox ClassFeat11_hex;
		TextBox ClassFeat11_bin;

		Button cf11_Clear;
		Label  cf11_hex;
		Label  cf11_bin;

		Label    cf11_featId_label;
		TextBox  cf11_FeatId;
		Label    cf11_FeatLabel;
		Label    cf11_spellId_label;
		TextBox  cf11_SpellId;
		Label    cf11_SpellLabel;
		CheckBox cf11_cheatCast;


		/// <summary>
		/// *si effin designer bs
		/// </summary>
		void InitializeComponent()
		{
			this.tc_Classes = new nwn2_ai_2da_editor.CompositedTabControl();
			this.tp_Flags = new System.Windows.Forms.TabPage();
			this.ClassFlags_reset = new System.Windows.Forms.Button();
			this.ClassFlags_text = new System.Windows.Forms.TextBox();
			this.ClassFlags_hex = new System.Windows.Forms.TextBox();
			this.ClassFlags_bin = new System.Windows.Forms.TextBox();
			this.cf_Clear = new System.Windows.Forms.Button();
			this.cf_hex = new System.Windows.Forms.Label();
			this.cf_bin = new System.Windows.Forms.Label();
			this.cf_Attack_lbl = new System.Windows.Forms.Label();
			this.cbo_cf_Attack = new System.Windows.Forms.ComboBox();
			this.cf_SneakAttack_lbl = new System.Windows.Forms.Label();
			this.cbo_cf_SneakAttack = new System.Windows.Forms.ComboBox();
			this.cf_Ability_lbl = new System.Windows.Forms.Label();
			this.cbo_cf_Ability = new System.Windows.Forms.ComboBox();
			this.cf_SpellProg_lbl = new System.Windows.Forms.Label();
			this.cbo_cf_SpellProg = new System.Windows.Forms.ComboBox();
			this.cf_BuffOthers_lbl = new System.Windows.Forms.Label();
			this.cbo_cf_BuffOthers = new System.Windows.Forms.ComboBox();
			this.cf_rbArcane = new System.Windows.Forms.RadioButton();
			this.cf_rbDivine = new System.Windows.Forms.RadioButton();
			this.cf_isPrestigeClass = new System.Windows.Forms.CheckBox();
			this.cf_DcBonus = new System.Windows.Forms.CheckBox();
			this.cf_L4Required = new System.Windows.Forms.CheckBox();
			this.cf_HasFeatSpells = new System.Windows.Forms.CheckBox();
			this.tp_Feat1 = new System.Windows.Forms.TabPage();
			this.ClassFeat1_reset = new System.Windows.Forms.Button();
			this.ClassFeat1_text = new System.Windows.Forms.TextBox();
			this.ClassFeat1_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat1_bin = new System.Windows.Forms.TextBox();
			this.cf1_Clear = new System.Windows.Forms.Button();
			this.cf1_hex = new System.Windows.Forms.Label();
			this.cf1_bin = new System.Windows.Forms.Label();
			this.cf1_featId_label = new System.Windows.Forms.Label();
			this.cf1_FeatId = new System.Windows.Forms.TextBox();
			this.cf1_FeatLabel = new System.Windows.Forms.Label();
			this.cf1_spellId_label = new System.Windows.Forms.Label();
			this.cf1_SpellId = new System.Windows.Forms.TextBox();
			this.cf1_SpellLabel = new System.Windows.Forms.Label();
			this.cf1_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat2 = new System.Windows.Forms.TabPage();
			this.ClassFeat2_reset = new System.Windows.Forms.Button();
			this.ClassFeat2_text = new System.Windows.Forms.TextBox();
			this.ClassFeat2_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat2_bin = new System.Windows.Forms.TextBox();
			this.cf2_Clear = new System.Windows.Forms.Button();
			this.cf2_hex = new System.Windows.Forms.Label();
			this.cf2_bin = new System.Windows.Forms.Label();
			this.cf2_featId_label = new System.Windows.Forms.Label();
			this.cf2_FeatId = new System.Windows.Forms.TextBox();
			this.cf2_FeatLabel = new System.Windows.Forms.Label();
			this.cf2_spellId_label = new System.Windows.Forms.Label();
			this.cf2_SpellId = new System.Windows.Forms.TextBox();
			this.cf2_SpellLabel = new System.Windows.Forms.Label();
			this.cf2_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat3 = new System.Windows.Forms.TabPage();
			this.ClassFeat3_reset = new System.Windows.Forms.Button();
			this.ClassFeat3_text = new System.Windows.Forms.TextBox();
			this.ClassFeat3_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat3_bin = new System.Windows.Forms.TextBox();
			this.cf3_Clear = new System.Windows.Forms.Button();
			this.cf3_hex = new System.Windows.Forms.Label();
			this.cf3_bin = new System.Windows.Forms.Label();
			this.cf3_featId_label = new System.Windows.Forms.Label();
			this.cf3_FeatId = new System.Windows.Forms.TextBox();
			this.cf3_FeatLabel = new System.Windows.Forms.Label();
			this.cf3_spellId_label = new System.Windows.Forms.Label();
			this.cf3_SpellId = new System.Windows.Forms.TextBox();
			this.cf3_SpellLabel = new System.Windows.Forms.Label();
			this.cf3_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat4 = new System.Windows.Forms.TabPage();
			this.ClassFeat4_reset = new System.Windows.Forms.Button();
			this.ClassFeat4_text = new System.Windows.Forms.TextBox();
			this.ClassFeat4_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat4_bin = new System.Windows.Forms.TextBox();
			this.cf4_Clear = new System.Windows.Forms.Button();
			this.cf4_hex = new System.Windows.Forms.Label();
			this.cf4_bin = new System.Windows.Forms.Label();
			this.cf4_featId_label = new System.Windows.Forms.Label();
			this.cf4_FeatId = new System.Windows.Forms.TextBox();
			this.cf4_FeatLabel = new System.Windows.Forms.Label();
			this.cf4_spellId_label = new System.Windows.Forms.Label();
			this.cf4_SpellId = new System.Windows.Forms.TextBox();
			this.cf4_SpellLabel = new System.Windows.Forms.Label();
			this.cf4_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat5 = new System.Windows.Forms.TabPage();
			this.ClassFeat5_reset = new System.Windows.Forms.Button();
			this.ClassFeat5_text = new System.Windows.Forms.TextBox();
			this.ClassFeat5_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat5_bin = new System.Windows.Forms.TextBox();
			this.cf5_Clear = new System.Windows.Forms.Button();
			this.cf5_hex = new System.Windows.Forms.Label();
			this.cf5_bin = new System.Windows.Forms.Label();
			this.cf5_featId_label = new System.Windows.Forms.Label();
			this.cf5_FeatId = new System.Windows.Forms.TextBox();
			this.cf5_FeatLabel = new System.Windows.Forms.Label();
			this.cf5_spellId_label = new System.Windows.Forms.Label();
			this.cf5_SpellId = new System.Windows.Forms.TextBox();
			this.cf5_SpellLabel = new System.Windows.Forms.Label();
			this.cf5_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat6 = new System.Windows.Forms.TabPage();
			this.ClassFeat6_reset = new System.Windows.Forms.Button();
			this.ClassFeat6_text = new System.Windows.Forms.TextBox();
			this.ClassFeat6_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat6_bin = new System.Windows.Forms.TextBox();
			this.cf6_Clear = new System.Windows.Forms.Button();
			this.cf6_hex = new System.Windows.Forms.Label();
			this.cf6_bin = new System.Windows.Forms.Label();
			this.cf6_featId_label = new System.Windows.Forms.Label();
			this.cf6_FeatId = new System.Windows.Forms.TextBox();
			this.cf6_FeatLabel = new System.Windows.Forms.Label();
			this.cf6_spellId_label = new System.Windows.Forms.Label();
			this.cf6_SpellId = new System.Windows.Forms.TextBox();
			this.cf6_SpellLabel = new System.Windows.Forms.Label();
			this.cf6_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat7 = new System.Windows.Forms.TabPage();
			this.ClassFeat7_reset = new System.Windows.Forms.Button();
			this.ClassFeat7_text = new System.Windows.Forms.TextBox();
			this.ClassFeat7_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat7_bin = new System.Windows.Forms.TextBox();
			this.cf7_Clear = new System.Windows.Forms.Button();
			this.cf7_hex = new System.Windows.Forms.Label();
			this.cf7_bin = new System.Windows.Forms.Label();
			this.cf7_featId_label = new System.Windows.Forms.Label();
			this.cf7_FeatId = new System.Windows.Forms.TextBox();
			this.cf7_FeatLabel = new System.Windows.Forms.Label();
			this.cf7_spellId_label = new System.Windows.Forms.Label();
			this.cf7_SpellId = new System.Windows.Forms.TextBox();
			this.cf7_SpellLabel = new System.Windows.Forms.Label();
			this.cf7_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat8 = new System.Windows.Forms.TabPage();
			this.ClassFeat8_reset = new System.Windows.Forms.Button();
			this.ClassFeat8_text = new System.Windows.Forms.TextBox();
			this.ClassFeat8_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat8_bin = new System.Windows.Forms.TextBox();
			this.cf8_Clear = new System.Windows.Forms.Button();
			this.cf8_hex = new System.Windows.Forms.Label();
			this.cf8_bin = new System.Windows.Forms.Label();
			this.cf8_featId_label = new System.Windows.Forms.Label();
			this.cf8_FeatId = new System.Windows.Forms.TextBox();
			this.cf8_FeatLabel = new System.Windows.Forms.Label();
			this.cf8_spellId_label = new System.Windows.Forms.Label();
			this.cf8_SpellId = new System.Windows.Forms.TextBox();
			this.cf8_SpellLabel = new System.Windows.Forms.Label();
			this.cf8_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat9 = new System.Windows.Forms.TabPage();
			this.ClassFeat9_reset = new System.Windows.Forms.Button();
			this.ClassFeat9_text = new System.Windows.Forms.TextBox();
			this.ClassFeat9_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat9_bin = new System.Windows.Forms.TextBox();
			this.cf9_Clear = new System.Windows.Forms.Button();
			this.cf9_hex = new System.Windows.Forms.Label();
			this.cf9_bin = new System.Windows.Forms.Label();
			this.cf9_featId_label = new System.Windows.Forms.Label();
			this.cf9_FeatId = new System.Windows.Forms.TextBox();
			this.cf9_FeatLabel = new System.Windows.Forms.Label();
			this.cf9_spellId_label = new System.Windows.Forms.Label();
			this.cf9_SpellId = new System.Windows.Forms.TextBox();
			this.cf9_SpellLabel = new System.Windows.Forms.Label();
			this.cf9_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat10 = new System.Windows.Forms.TabPage();
			this.ClassFeat10_reset = new System.Windows.Forms.Button();
			this.ClassFeat10_text = new System.Windows.Forms.TextBox();
			this.ClassFeat10_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat10_bin = new System.Windows.Forms.TextBox();
			this.cf10_Clear = new System.Windows.Forms.Button();
			this.cf10_hex = new System.Windows.Forms.Label();
			this.cf10_bin = new System.Windows.Forms.Label();
			this.cf10_featId_label = new System.Windows.Forms.Label();
			this.cf10_FeatId = new System.Windows.Forms.TextBox();
			this.cf10_FeatLabel = new System.Windows.Forms.Label();
			this.cf10_spellId_label = new System.Windows.Forms.Label();
			this.cf10_SpellId = new System.Windows.Forms.TextBox();
			this.cf10_SpellLabel = new System.Windows.Forms.Label();
			this.cf10_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat11 = new System.Windows.Forms.TabPage();
			this.ClassFeat11_reset = new System.Windows.Forms.Button();
			this.ClassFeat11_text = new System.Windows.Forms.TextBox();
			this.ClassFeat11_hex = new System.Windows.Forms.TextBox();
			this.ClassFeat11_bin = new System.Windows.Forms.TextBox();
			this.cf11_Clear = new System.Windows.Forms.Button();
			this.cf11_hex = new System.Windows.Forms.Label();
			this.cf11_bin = new System.Windows.Forms.Label();
			this.cf11_featId_label = new System.Windows.Forms.Label();
			this.cf11_FeatId = new System.Windows.Forms.TextBox();
			this.cf11_FeatLabel = new System.Windows.Forms.Label();
			this.cf11_spellId_label = new System.Windows.Forms.Label();
			this.cf11_SpellId = new System.Windows.Forms.TextBox();
			this.cf11_SpellLabel = new System.Windows.Forms.Label();
			this.cf11_cheatCast = new System.Windows.Forms.CheckBox();
			this.tc_Classes.SuspendLayout();
			this.tp_Flags.SuspendLayout();
			this.tp_Feat1.SuspendLayout();
			this.tp_Feat2.SuspendLayout();
			this.tp_Feat3.SuspendLayout();
			this.tp_Feat4.SuspendLayout();
			this.tp_Feat5.SuspendLayout();
			this.tp_Feat6.SuspendLayout();
			this.tp_Feat7.SuspendLayout();
			this.tp_Feat8.SuspendLayout();
			this.tp_Feat9.SuspendLayout();
			this.tp_Feat10.SuspendLayout();
			this.tp_Feat11.SuspendLayout();
			this.SuspendLayout();
			// 
			// tc_Classes
			// 
			this.tc_Classes.Controls.Add(this.tp_Flags);
			this.tc_Classes.Controls.Add(this.tp_Feat1);
			this.tc_Classes.Controls.Add(this.tp_Feat2);
			this.tc_Classes.Controls.Add(this.tp_Feat3);
			this.tc_Classes.Controls.Add(this.tp_Feat4);
			this.tc_Classes.Controls.Add(this.tp_Feat5);
			this.tc_Classes.Controls.Add(this.tp_Feat6);
			this.tc_Classes.Controls.Add(this.tp_Feat7);
			this.tc_Classes.Controls.Add(this.tp_Feat8);
			this.tc_Classes.Controls.Add(this.tp_Feat9);
			this.tc_Classes.Controls.Add(this.tp_Feat10);
			this.tc_Classes.Controls.Add(this.tp_Feat11);
			this.tc_Classes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tc_Classes.Location = new System.Drawing.Point(0, 0);
			this.tc_Classes.Margin = new System.Windows.Forms.Padding(0);
			this.tc_Classes.Name = "tc_Classes";
			this.tc_Classes.Padding = new System.Drawing.Point(0, 0);
			this.tc_Classes.SelectedIndex = 0;
			this.tc_Classes.Size = new System.Drawing.Size(980, 159);
			this.tc_Classes.TabIndex = 0;
			// 
			// tp_Flags
			// 
			this.tp_Flags.BackColor = System.Drawing.Color.OldLace;
			this.tp_Flags.Controls.Add(this.ClassFlags_reset);
			this.tp_Flags.Controls.Add(this.ClassFlags_text);
			this.tp_Flags.Controls.Add(this.ClassFlags_hex);
			this.tp_Flags.Controls.Add(this.ClassFlags_bin);
			this.tp_Flags.Controls.Add(this.cf_Clear);
			this.tp_Flags.Controls.Add(this.cf_hex);
			this.tp_Flags.Controls.Add(this.cf_bin);
			this.tp_Flags.Controls.Add(this.cf_Attack_lbl);
			this.tp_Flags.Controls.Add(this.cbo_cf_Attack);
			this.tp_Flags.Controls.Add(this.cf_SneakAttack_lbl);
			this.tp_Flags.Controls.Add(this.cbo_cf_SneakAttack);
			this.tp_Flags.Controls.Add(this.cf_Ability_lbl);
			this.tp_Flags.Controls.Add(this.cbo_cf_Ability);
			this.tp_Flags.Controls.Add(this.cf_SpellProg_lbl);
			this.tp_Flags.Controls.Add(this.cbo_cf_SpellProg);
			this.tp_Flags.Controls.Add(this.cf_BuffOthers_lbl);
			this.tp_Flags.Controls.Add(this.cbo_cf_BuffOthers);
			this.tp_Flags.Controls.Add(this.cf_rbArcane);
			this.tp_Flags.Controls.Add(this.cf_rbDivine);
			this.tp_Flags.Controls.Add(this.cf_isPrestigeClass);
			this.tp_Flags.Controls.Add(this.cf_DcBonus);
			this.tp_Flags.Controls.Add(this.cf_L4Required);
			this.tp_Flags.Controls.Add(this.cf_HasFeatSpells);
			this.tp_Flags.Location = new System.Drawing.Point(4, 22);
			this.tp_Flags.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Flags.Name = "tp_Flags";
			this.tp_Flags.Size = new System.Drawing.Size(972, 133);
			this.tp_Flags.TabIndex = 0;
			this.tp_Flags.Text = "flags";
			// 
			// ClassFlags_reset
			// 
			this.ClassFlags_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFlags_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_reset.Name = "ClassFlags_reset";
			this.ClassFlags_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFlags_reset.TabIndex = 0;
			this.ClassFlags_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFlags_text
			// 
			this.ClassFlags_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFlags_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_text.Name = "ClassFlags_text";
			this.ClassFlags_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFlags_text.TabIndex = 1;
			this.ClassFlags_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFlags_hex
			// 
			this.ClassFlags_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFlags_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFlags_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFlags_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFlags_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_hex.Name = "ClassFlags_hex";
			this.ClassFlags_hex.ReadOnly = true;
			this.ClassFlags_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFlags_hex.TabIndex = 2;
			// 
			// ClassFlags_bin
			// 
			this.ClassFlags_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFlags_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFlags_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFlags_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFlags_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFlags_bin.Name = "ClassFlags_bin";
			this.ClassFlags_bin.ReadOnly = true;
			this.ClassFlags_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFlags_bin.TabIndex = 3;
			// 
			// cf_Clear
			// 
			this.cf_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf_Clear.Name = "cf_Clear";
			this.cf_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf_Clear.TabIndex = 4;
			this.cf_Clear.Text = "zero\r\nall\r\nbits";
			this.cf_Clear.UseVisualStyleBackColor = true;
			// 
			// cf_hex
			// 
			this.cf_hex.Location = new System.Drawing.Point(400, 15);
			this.cf_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf_hex.Name = "cf_hex";
			this.cf_hex.Size = new System.Drawing.Size(40, 15);
			this.cf_hex.TabIndex = 5;
			this.cf_hex.Text = "hex";
			this.cf_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf_bin
			// 
			this.cf_bin.Location = new System.Drawing.Point(400, 35);
			this.cf_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf_bin.Name = "cf_bin";
			this.cf_bin.Size = new System.Drawing.Size(40, 15);
			this.cf_bin.TabIndex = 6;
			this.cf_bin.Text = "bin";
			this.cf_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf_Attack_lbl
			// 
			this.cf_Attack_lbl.Location = new System.Drawing.Point(15, 60);
			this.cf_Attack_lbl.Margin = new System.Windows.Forms.Padding(0);
			this.cf_Attack_lbl.Name = "cf_Attack_lbl";
			this.cf_Attack_lbl.Size = new System.Drawing.Size(130, 15);
			this.cf_Attack_lbl.TabIndex = 7;
			this.cf_Attack_lbl.Text = "Attack";
			// 
			// cbo_cf_Attack
			// 
			this.cbo_cf_Attack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_cf_Attack.FormattingEnabled = true;
			this.cbo_cf_Attack.Location = new System.Drawing.Point(10, 80);
			this.cbo_cf_Attack.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_cf_Attack.Name = "cbo_cf_Attack";
			this.cbo_cf_Attack.Size = new System.Drawing.Size(145, 21);
			this.cbo_cf_Attack.TabIndex = 8;
			// 
			// cf_SneakAttack_lbl
			// 
			this.cf_SneakAttack_lbl.Location = new System.Drawing.Point(165, 60);
			this.cf_SneakAttack_lbl.Margin = new System.Windows.Forms.Padding(0);
			this.cf_SneakAttack_lbl.Name = "cf_SneakAttack_lbl";
			this.cf_SneakAttack_lbl.Size = new System.Drawing.Size(130, 15);
			this.cf_SneakAttack_lbl.TabIndex = 9;
			this.cf_SneakAttack_lbl.Text = "Sneak Attack";
			// 
			// cbo_cf_SneakAttack
			// 
			this.cbo_cf_SneakAttack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_cf_SneakAttack.FormattingEnabled = true;
			this.cbo_cf_SneakAttack.Location = new System.Drawing.Point(160, 80);
			this.cbo_cf_SneakAttack.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_cf_SneakAttack.Name = "cbo_cf_SneakAttack";
			this.cbo_cf_SneakAttack.Size = new System.Drawing.Size(145, 21);
			this.cbo_cf_SneakAttack.TabIndex = 10;
			// 
			// cf_Ability_lbl
			// 
			this.cf_Ability_lbl.Location = new System.Drawing.Point(315, 60);
			this.cf_Ability_lbl.Margin = new System.Windows.Forms.Padding(0);
			this.cf_Ability_lbl.Name = "cf_Ability_lbl";
			this.cf_Ability_lbl.Size = new System.Drawing.Size(130, 15);
			this.cf_Ability_lbl.TabIndex = 11;
			this.cf_Ability_lbl.Text = "Caster Ability";
			// 
			// cbo_cf_Ability
			// 
			this.cbo_cf_Ability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_cf_Ability.FormattingEnabled = true;
			this.cbo_cf_Ability.Location = new System.Drawing.Point(310, 80);
			this.cbo_cf_Ability.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_cf_Ability.Name = "cbo_cf_Ability";
			this.cbo_cf_Ability.Size = new System.Drawing.Size(145, 21);
			this.cbo_cf_Ability.TabIndex = 12;
			// 
			// cf_SpellProg_lbl
			// 
			this.cf_SpellProg_lbl.Location = new System.Drawing.Point(465, 60);
			this.cf_SpellProg_lbl.Margin = new System.Windows.Forms.Padding(0);
			this.cf_SpellProg_lbl.Name = "cf_SpellProg_lbl";
			this.cf_SpellProg_lbl.Size = new System.Drawing.Size(130, 15);
			this.cf_SpellProg_lbl.TabIndex = 13;
			this.cf_SpellProg_lbl.Text = "Spell Progression";
			// 
			// cbo_cf_SpellProg
			// 
			this.cbo_cf_SpellProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_cf_SpellProg.FormattingEnabled = true;
			this.cbo_cf_SpellProg.Location = new System.Drawing.Point(460, 80);
			this.cbo_cf_SpellProg.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_cf_SpellProg.Name = "cbo_cf_SpellProg";
			this.cbo_cf_SpellProg.Size = new System.Drawing.Size(145, 21);
			this.cbo_cf_SpellProg.TabIndex = 14;
			// 
			// cf_BuffOthers_lbl
			// 
			this.cf_BuffOthers_lbl.Location = new System.Drawing.Point(615, 60);
			this.cf_BuffOthers_lbl.Margin = new System.Windows.Forms.Padding(0);
			this.cf_BuffOthers_lbl.Name = "cf_BuffOthers_lbl";
			this.cf_BuffOthers_lbl.Size = new System.Drawing.Size(130, 15);
			this.cf_BuffOthers_lbl.TabIndex = 15;
			this.cf_BuffOthers_lbl.Text = "Buff Others";
			// 
			// cbo_cf_BuffOthers
			// 
			this.cbo_cf_BuffOthers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbo_cf_BuffOthers.FormattingEnabled = true;
			this.cbo_cf_BuffOthers.Location = new System.Drawing.Point(610, 80);
			this.cbo_cf_BuffOthers.Margin = new System.Windows.Forms.Padding(0);
			this.cbo_cf_BuffOthers.Name = "cbo_cf_BuffOthers";
			this.cbo_cf_BuffOthers.Size = new System.Drawing.Size(145, 21);
			this.cbo_cf_BuffOthers.TabIndex = 16;
			// 
			// cf_rbArcane
			// 
			this.cf_rbArcane.Location = new System.Drawing.Point(770, 10);
			this.cf_rbArcane.Margin = new System.Windows.Forms.Padding(0);
			this.cf_rbArcane.Name = "cf_rbArcane";
			this.cf_rbArcane.Size = new System.Drawing.Size(165, 15);
			this.cf_rbArcane.TabIndex = 17;
			this.cf_rbArcane.TabStop = true;
			this.cf_rbArcane.Text = "Arcane Caster (or none)";
			this.cf_rbArcane.UseVisualStyleBackColor = true;
			// 
			// cf_rbDivine
			// 
			this.cf_rbDivine.Location = new System.Drawing.Point(770, 30);
			this.cf_rbDivine.Margin = new System.Windows.Forms.Padding(0);
			this.cf_rbDivine.Name = "cf_rbDivine";
			this.cf_rbDivine.Size = new System.Drawing.Size(165, 15);
			this.cf_rbDivine.TabIndex = 18;
			this.cf_rbDivine.TabStop = true;
			this.cf_rbDivine.Text = "Divine Caster";
			this.cf_rbDivine.UseVisualStyleBackColor = true;
			// 
			// cf_isPrestigeClass
			// 
			this.cf_isPrestigeClass.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf_isPrestigeClass.Location = new System.Drawing.Point(770, 60);
			this.cf_isPrestigeClass.Margin = new System.Windows.Forms.Padding(0);
			this.cf_isPrestigeClass.Name = "cf_isPrestigeClass";
			this.cf_isPrestigeClass.Size = new System.Drawing.Size(195, 20);
			this.cf_isPrestigeClass.TabIndex = 19;
			this.cf_isPrestigeClass.Text = "Prestige Class";
			this.cf_isPrestigeClass.UseVisualStyleBackColor = true;
			// 
			// cf_DcBonus
			// 
			this.cf_DcBonus.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf_DcBonus.Location = new System.Drawing.Point(770, 80);
			this.cf_DcBonus.Margin = new System.Windows.Forms.Padding(0);
			this.cf_DcBonus.Name = "cf_DcBonus";
			this.cf_DcBonus.Size = new System.Drawing.Size(195, 20);
			this.cf_DcBonus.TabIndex = 20;
			this.cf_DcBonus.Text = "DC Bonus (eg. red wizard)";
			this.cf_DcBonus.UseVisualStyleBackColor = true;
			// 
			// cf_L4Required
			// 
			this.cf_L4Required.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf_L4Required.Location = new System.Drawing.Point(770, 100);
			this.cf_L4Required.Margin = new System.Windows.Forms.Padding(0);
			this.cf_L4Required.Name = "cf_L4Required";
			this.cf_L4Required.Size = new System.Drawing.Size(195, 20);
			this.cf_L4Required.TabIndex = 21;
			this.cf_L4Required.Text = "not a caster until 4th Level";
			this.cf_L4Required.UseVisualStyleBackColor = true;
			// 
			// cf_HasFeatSpells
			// 
			this.cf_HasFeatSpells.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf_HasFeatSpells.Location = new System.Drawing.Point(15, 110);
			this.cf_HasFeatSpells.Margin = new System.Windows.Forms.Padding(0);
			this.cf_HasFeatSpells.Name = "cf_HasFeatSpells";
			this.cf_HasFeatSpells.Size = new System.Drawing.Size(80, 20);
			this.cf_HasFeatSpells.TabIndex = 22;
			this.cf_HasFeatSpells.Text = "has Feats";
			this.cf_HasFeatSpells.UseVisualStyleBackColor = true;
			// 
			// tp_Feat1
			// 
			this.tp_Feat1.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat1.Controls.Add(this.ClassFeat1_reset);
			this.tp_Feat1.Controls.Add(this.ClassFeat1_text);
			this.tp_Feat1.Controls.Add(this.ClassFeat1_hex);
			this.tp_Feat1.Controls.Add(this.ClassFeat1_bin);
			this.tp_Feat1.Controls.Add(this.cf1_Clear);
			this.tp_Feat1.Controls.Add(this.cf1_hex);
			this.tp_Feat1.Controls.Add(this.cf1_bin);
			this.tp_Feat1.Controls.Add(this.cf1_featId_label);
			this.tp_Feat1.Controls.Add(this.cf1_FeatId);
			this.tp_Feat1.Controls.Add(this.cf1_FeatLabel);
			this.tp_Feat1.Controls.Add(this.cf1_spellId_label);
			this.tp_Feat1.Controls.Add(this.cf1_SpellId);
			this.tp_Feat1.Controls.Add(this.cf1_SpellLabel);
			this.tp_Feat1.Controls.Add(this.cf1_cheatCast);
			this.tp_Feat1.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat1.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat1.Name = "tp_Feat1";
			this.tp_Feat1.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat1.TabIndex = 1;
			this.tp_Feat1.Text = "feat1";
			// 
			// ClassFeat1_reset
			// 
			this.ClassFeat1_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat1_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_reset.Name = "ClassFeat1_reset";
			this.ClassFeat1_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat1_reset.TabIndex = 0;
			this.ClassFeat1_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat1_text
			// 
			this.ClassFeat1_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat1_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_text.Name = "ClassFeat1_text";
			this.ClassFeat1_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat1_text.TabIndex = 1;
			this.ClassFeat1_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat1_hex
			// 
			this.ClassFeat1_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat1_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat1_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat1_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_hex.Name = "ClassFeat1_hex";
			this.ClassFeat1_hex.ReadOnly = true;
			this.ClassFeat1_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat1_hex.TabIndex = 2;
			// 
			// ClassFeat1_bin
			// 
			this.ClassFeat1_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat1_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat1_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat1_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat1_bin.Name = "ClassFeat1_bin";
			this.ClassFeat1_bin.ReadOnly = true;
			this.ClassFeat1_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat1_bin.TabIndex = 3;
			// 
			// cf1_Clear
			// 
			this.cf1_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf1_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_Clear.Name = "cf1_Clear";
			this.cf1_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf1_Clear.TabIndex = 4;
			this.cf1_Clear.Text = "zero\r\nall\r\nbits";
			this.cf1_Clear.UseVisualStyleBackColor = true;
			// 
			// cf1_hex
			// 
			this.cf1_hex.Location = new System.Drawing.Point(400, 15);
			this.cf1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_hex.Name = "cf1_hex";
			this.cf1_hex.Size = new System.Drawing.Size(40, 15);
			this.cf1_hex.TabIndex = 5;
			this.cf1_hex.Text = "hex";
			this.cf1_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_bin
			// 
			this.cf1_bin.Location = new System.Drawing.Point(400, 35);
			this.cf1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_bin.Name = "cf1_bin";
			this.cf1_bin.Size = new System.Drawing.Size(40, 15);
			this.cf1_bin.TabIndex = 6;
			this.cf1_bin.Text = "bin";
			this.cf1_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_featId_label
			// 
			this.cf1_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf1_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_featId_label.Name = "cf1_featId_label";
			this.cf1_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf1_featId_label.TabIndex = 7;
			this.cf1_featId_label.Text = "ID Feat";
			this.cf1_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_FeatId
			// 
			this.cf1_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf1_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_FeatId.Name = "cf1_FeatId";
			this.cf1_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf1_FeatId.TabIndex = 8;
			// 
			// cf1_FeatLabel
			// 
			this.cf1_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf1_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_FeatLabel.Name = "cf1_FeatLabel";
			this.cf1_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf1_FeatLabel.TabIndex = 9;
			this.cf1_FeatLabel.Text = "cf1_FeatLabel";
			this.cf1_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_spellId_label
			// 
			this.cf1_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf1_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_spellId_label.Name = "cf1_spellId_label";
			this.cf1_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf1_spellId_label.TabIndex = 10;
			this.cf1_spellId_label.Text = "ID Spell";
			this.cf1_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_SpellId
			// 
			this.cf1_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf1_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_SpellId.Name = "cf1_SpellId";
			this.cf1_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf1_SpellId.TabIndex = 11;
			// 
			// cf1_SpellLabel
			// 
			this.cf1_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf1_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_SpellLabel.Name = "cf1_SpellLabel";
			this.cf1_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf1_SpellLabel.TabIndex = 12;
			this.cf1_SpellLabel.Text = "cf1_SpellLabel";
			this.cf1_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf1_cheatCast
			// 
			this.cf1_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf1_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf1_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf1_cheatCast.Name = "cf1_cheatCast";
			this.cf1_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf1_cheatCast.TabIndex = 13;
			this.cf1_cheatCast.Text = "cheat cast";
			this.cf1_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat2
			// 
			this.tp_Feat2.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat2.Controls.Add(this.ClassFeat2_reset);
			this.tp_Feat2.Controls.Add(this.ClassFeat2_text);
			this.tp_Feat2.Controls.Add(this.ClassFeat2_hex);
			this.tp_Feat2.Controls.Add(this.ClassFeat2_bin);
			this.tp_Feat2.Controls.Add(this.cf2_Clear);
			this.tp_Feat2.Controls.Add(this.cf2_hex);
			this.tp_Feat2.Controls.Add(this.cf2_bin);
			this.tp_Feat2.Controls.Add(this.cf2_featId_label);
			this.tp_Feat2.Controls.Add(this.cf2_FeatId);
			this.tp_Feat2.Controls.Add(this.cf2_FeatLabel);
			this.tp_Feat2.Controls.Add(this.cf2_spellId_label);
			this.tp_Feat2.Controls.Add(this.cf2_SpellId);
			this.tp_Feat2.Controls.Add(this.cf2_SpellLabel);
			this.tp_Feat2.Controls.Add(this.cf2_cheatCast);
			this.tp_Feat2.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat2.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat2.Name = "tp_Feat2";
			this.tp_Feat2.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat2.TabIndex = 2;
			this.tp_Feat2.Text = "feat2";
			// 
			// ClassFeat2_reset
			// 
			this.ClassFeat2_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat2_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_reset.Name = "ClassFeat2_reset";
			this.ClassFeat2_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat2_reset.TabIndex = 0;
			this.ClassFeat2_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat2_text
			// 
			this.ClassFeat2_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat2_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_text.Name = "ClassFeat2_text";
			this.ClassFeat2_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat2_text.TabIndex = 1;
			this.ClassFeat2_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat2_hex
			// 
			this.ClassFeat2_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat2_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat2_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat2_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_hex.Name = "ClassFeat2_hex";
			this.ClassFeat2_hex.ReadOnly = true;
			this.ClassFeat2_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat2_hex.TabIndex = 2;
			// 
			// ClassFeat2_bin
			// 
			this.ClassFeat2_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat2_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat2_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat2_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat2_bin.Name = "ClassFeat2_bin";
			this.ClassFeat2_bin.ReadOnly = true;
			this.ClassFeat2_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat2_bin.TabIndex = 3;
			// 
			// cf2_Clear
			// 
			this.cf2_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf2_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_Clear.Name = "cf2_Clear";
			this.cf2_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf2_Clear.TabIndex = 4;
			this.cf2_Clear.Text = "zero\r\nall\r\nbits";
			this.cf2_Clear.UseVisualStyleBackColor = true;
			// 
			// cf2_hex
			// 
			this.cf2_hex.Location = new System.Drawing.Point(400, 15);
			this.cf2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_hex.Name = "cf2_hex";
			this.cf2_hex.Size = new System.Drawing.Size(40, 15);
			this.cf2_hex.TabIndex = 5;
			this.cf2_hex.Text = "hex";
			this.cf2_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_bin
			// 
			this.cf2_bin.Location = new System.Drawing.Point(400, 35);
			this.cf2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_bin.Name = "cf2_bin";
			this.cf2_bin.Size = new System.Drawing.Size(40, 15);
			this.cf2_bin.TabIndex = 6;
			this.cf2_bin.Text = "bin";
			this.cf2_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_featId_label
			// 
			this.cf2_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf2_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_featId_label.Name = "cf2_featId_label";
			this.cf2_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf2_featId_label.TabIndex = 7;
			this.cf2_featId_label.Text = "ID Feat";
			this.cf2_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_FeatId
			// 
			this.cf2_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf2_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_FeatId.Name = "cf2_FeatId";
			this.cf2_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf2_FeatId.TabIndex = 8;
			// 
			// cf2_FeatLabel
			// 
			this.cf2_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf2_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_FeatLabel.Name = "cf2_FeatLabel";
			this.cf2_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf2_FeatLabel.TabIndex = 9;
			this.cf2_FeatLabel.Text = "cf2_FeatLabel";
			this.cf2_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_spellId_label
			// 
			this.cf2_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf2_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_spellId_label.Name = "cf2_spellId_label";
			this.cf2_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf2_spellId_label.TabIndex = 10;
			this.cf2_spellId_label.Text = "ID Spell";
			this.cf2_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_SpellId
			// 
			this.cf2_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf2_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_SpellId.Name = "cf2_SpellId";
			this.cf2_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf2_SpellId.TabIndex = 11;
			// 
			// cf2_SpellLabel
			// 
			this.cf2_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf2_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_SpellLabel.Name = "cf2_SpellLabel";
			this.cf2_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf2_SpellLabel.TabIndex = 12;
			this.cf2_SpellLabel.Text = "cf2_SpellLabel";
			this.cf2_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf2_cheatCast
			// 
			this.cf2_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf2_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf2_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf2_cheatCast.Name = "cf2_cheatCast";
			this.cf2_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf2_cheatCast.TabIndex = 13;
			this.cf2_cheatCast.Text = "cheat cast";
			this.cf2_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat3
			// 
			this.tp_Feat3.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat3.Controls.Add(this.ClassFeat3_reset);
			this.tp_Feat3.Controls.Add(this.ClassFeat3_text);
			this.tp_Feat3.Controls.Add(this.ClassFeat3_hex);
			this.tp_Feat3.Controls.Add(this.ClassFeat3_bin);
			this.tp_Feat3.Controls.Add(this.cf3_Clear);
			this.tp_Feat3.Controls.Add(this.cf3_hex);
			this.tp_Feat3.Controls.Add(this.cf3_bin);
			this.tp_Feat3.Controls.Add(this.cf3_featId_label);
			this.tp_Feat3.Controls.Add(this.cf3_FeatId);
			this.tp_Feat3.Controls.Add(this.cf3_FeatLabel);
			this.tp_Feat3.Controls.Add(this.cf3_spellId_label);
			this.tp_Feat3.Controls.Add(this.cf3_SpellId);
			this.tp_Feat3.Controls.Add(this.cf3_SpellLabel);
			this.tp_Feat3.Controls.Add(this.cf3_cheatCast);
			this.tp_Feat3.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat3.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat3.Name = "tp_Feat3";
			this.tp_Feat3.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat3.TabIndex = 3;
			this.tp_Feat3.Text = "feat3";
			// 
			// ClassFeat3_reset
			// 
			this.ClassFeat3_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat3_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_reset.Name = "ClassFeat3_reset";
			this.ClassFeat3_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat3_reset.TabIndex = 0;
			this.ClassFeat3_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat3_text
			// 
			this.ClassFeat3_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat3_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_text.Name = "ClassFeat3_text";
			this.ClassFeat3_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat3_text.TabIndex = 1;
			this.ClassFeat3_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat3_hex
			// 
			this.ClassFeat3_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat3_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat3_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat3_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_hex.Name = "ClassFeat3_hex";
			this.ClassFeat3_hex.ReadOnly = true;
			this.ClassFeat3_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat3_hex.TabIndex = 2;
			// 
			// ClassFeat3_bin
			// 
			this.ClassFeat3_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat3_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat3_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat3_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat3_bin.Name = "ClassFeat3_bin";
			this.ClassFeat3_bin.ReadOnly = true;
			this.ClassFeat3_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat3_bin.TabIndex = 3;
			// 
			// cf3_Clear
			// 
			this.cf3_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf3_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_Clear.Name = "cf3_Clear";
			this.cf3_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf3_Clear.TabIndex = 4;
			this.cf3_Clear.Text = "zero\r\nall\r\nbits";
			this.cf3_Clear.UseVisualStyleBackColor = true;
			// 
			// cf3_hex
			// 
			this.cf3_hex.Location = new System.Drawing.Point(400, 15);
			this.cf3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_hex.Name = "cf3_hex";
			this.cf3_hex.Size = new System.Drawing.Size(40, 15);
			this.cf3_hex.TabIndex = 5;
			this.cf3_hex.Text = "hex";
			this.cf3_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_bin
			// 
			this.cf3_bin.Location = new System.Drawing.Point(400, 35);
			this.cf3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_bin.Name = "cf3_bin";
			this.cf3_bin.Size = new System.Drawing.Size(40, 15);
			this.cf3_bin.TabIndex = 6;
			this.cf3_bin.Text = "bin";
			this.cf3_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_featId_label
			// 
			this.cf3_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf3_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_featId_label.Name = "cf3_featId_label";
			this.cf3_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf3_featId_label.TabIndex = 7;
			this.cf3_featId_label.Text = "ID Feat";
			this.cf3_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_FeatId
			// 
			this.cf3_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf3_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_FeatId.Name = "cf3_FeatId";
			this.cf3_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf3_FeatId.TabIndex = 8;
			// 
			// cf3_FeatLabel
			// 
			this.cf3_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf3_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_FeatLabel.Name = "cf3_FeatLabel";
			this.cf3_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf3_FeatLabel.TabIndex = 9;
			this.cf3_FeatLabel.Text = "cf3_FeatLabel";
			this.cf3_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_spellId_label
			// 
			this.cf3_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf3_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_spellId_label.Name = "cf3_spellId_label";
			this.cf3_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf3_spellId_label.TabIndex = 10;
			this.cf3_spellId_label.Text = "ID Spell";
			this.cf3_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_SpellId
			// 
			this.cf3_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf3_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_SpellId.Name = "cf3_SpellId";
			this.cf3_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf3_SpellId.TabIndex = 11;
			// 
			// cf3_SpellLabel
			// 
			this.cf3_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf3_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_SpellLabel.Name = "cf3_SpellLabel";
			this.cf3_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf3_SpellLabel.TabIndex = 12;
			this.cf3_SpellLabel.Text = "cf3_SpellLabel";
			this.cf3_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf3_cheatCast
			// 
			this.cf3_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf3_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf3_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf3_cheatCast.Name = "cf3_cheatCast";
			this.cf3_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf3_cheatCast.TabIndex = 13;
			this.cf3_cheatCast.Text = "cheat cast";
			this.cf3_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat4
			// 
			this.tp_Feat4.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat4.Controls.Add(this.ClassFeat4_reset);
			this.tp_Feat4.Controls.Add(this.ClassFeat4_text);
			this.tp_Feat4.Controls.Add(this.ClassFeat4_hex);
			this.tp_Feat4.Controls.Add(this.ClassFeat4_bin);
			this.tp_Feat4.Controls.Add(this.cf4_Clear);
			this.tp_Feat4.Controls.Add(this.cf4_hex);
			this.tp_Feat4.Controls.Add(this.cf4_bin);
			this.tp_Feat4.Controls.Add(this.cf4_featId_label);
			this.tp_Feat4.Controls.Add(this.cf4_FeatId);
			this.tp_Feat4.Controls.Add(this.cf4_FeatLabel);
			this.tp_Feat4.Controls.Add(this.cf4_spellId_label);
			this.tp_Feat4.Controls.Add(this.cf4_SpellId);
			this.tp_Feat4.Controls.Add(this.cf4_SpellLabel);
			this.tp_Feat4.Controls.Add(this.cf4_cheatCast);
			this.tp_Feat4.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat4.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat4.Name = "tp_Feat4";
			this.tp_Feat4.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat4.TabIndex = 4;
			this.tp_Feat4.Text = "feat4";
			// 
			// ClassFeat4_reset
			// 
			this.ClassFeat4_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat4_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_reset.Name = "ClassFeat4_reset";
			this.ClassFeat4_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat4_reset.TabIndex = 0;
			this.ClassFeat4_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat4_text
			// 
			this.ClassFeat4_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat4_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_text.Name = "ClassFeat4_text";
			this.ClassFeat4_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat4_text.TabIndex = 1;
			this.ClassFeat4_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat4_hex
			// 
			this.ClassFeat4_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat4_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat4_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat4_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_hex.Name = "ClassFeat4_hex";
			this.ClassFeat4_hex.ReadOnly = true;
			this.ClassFeat4_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat4_hex.TabIndex = 2;
			// 
			// ClassFeat4_bin
			// 
			this.ClassFeat4_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat4_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat4_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat4_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat4_bin.Name = "ClassFeat4_bin";
			this.ClassFeat4_bin.ReadOnly = true;
			this.ClassFeat4_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat4_bin.TabIndex = 3;
			// 
			// cf4_Clear
			// 
			this.cf4_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf4_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_Clear.Name = "cf4_Clear";
			this.cf4_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf4_Clear.TabIndex = 4;
			this.cf4_Clear.Text = "zero\r\nall\r\nbits";
			this.cf4_Clear.UseVisualStyleBackColor = true;
			// 
			// cf4_hex
			// 
			this.cf4_hex.Location = new System.Drawing.Point(400, 15);
			this.cf4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_hex.Name = "cf4_hex";
			this.cf4_hex.Size = new System.Drawing.Size(40, 15);
			this.cf4_hex.TabIndex = 5;
			this.cf4_hex.Text = "hex";
			this.cf4_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_bin
			// 
			this.cf4_bin.Location = new System.Drawing.Point(400, 35);
			this.cf4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_bin.Name = "cf4_bin";
			this.cf4_bin.Size = new System.Drawing.Size(40, 15);
			this.cf4_bin.TabIndex = 6;
			this.cf4_bin.Text = "bin";
			this.cf4_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_featId_label
			// 
			this.cf4_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf4_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_featId_label.Name = "cf4_featId_label";
			this.cf4_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf4_featId_label.TabIndex = 7;
			this.cf4_featId_label.Text = "ID Feat";
			this.cf4_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_FeatId
			// 
			this.cf4_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf4_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_FeatId.Name = "cf4_FeatId";
			this.cf4_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf4_FeatId.TabIndex = 8;
			// 
			// cf4_FeatLabel
			// 
			this.cf4_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf4_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_FeatLabel.Name = "cf4_FeatLabel";
			this.cf4_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf4_FeatLabel.TabIndex = 9;
			this.cf4_FeatLabel.Text = "cf4_FeatLabel";
			this.cf4_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_spellId_label
			// 
			this.cf4_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf4_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_spellId_label.Name = "cf4_spellId_label";
			this.cf4_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf4_spellId_label.TabIndex = 10;
			this.cf4_spellId_label.Text = "ID Spell";
			this.cf4_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_SpellId
			// 
			this.cf4_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf4_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_SpellId.Name = "cf4_SpellId";
			this.cf4_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf4_SpellId.TabIndex = 11;
			// 
			// cf4_SpellLabel
			// 
			this.cf4_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf4_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_SpellLabel.Name = "cf4_SpellLabel";
			this.cf4_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf4_SpellLabel.TabIndex = 12;
			this.cf4_SpellLabel.Text = "cf4_SpellLabel";
			this.cf4_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf4_cheatCast
			// 
			this.cf4_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf4_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf4_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf4_cheatCast.Name = "cf4_cheatCast";
			this.cf4_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf4_cheatCast.TabIndex = 13;
			this.cf4_cheatCast.Text = "cheat cast";
			this.cf4_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat5
			// 
			this.tp_Feat5.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat5.Controls.Add(this.ClassFeat5_reset);
			this.tp_Feat5.Controls.Add(this.ClassFeat5_text);
			this.tp_Feat5.Controls.Add(this.ClassFeat5_hex);
			this.tp_Feat5.Controls.Add(this.ClassFeat5_bin);
			this.tp_Feat5.Controls.Add(this.cf5_Clear);
			this.tp_Feat5.Controls.Add(this.cf5_hex);
			this.tp_Feat5.Controls.Add(this.cf5_bin);
			this.tp_Feat5.Controls.Add(this.cf5_featId_label);
			this.tp_Feat5.Controls.Add(this.cf5_FeatId);
			this.tp_Feat5.Controls.Add(this.cf5_FeatLabel);
			this.tp_Feat5.Controls.Add(this.cf5_spellId_label);
			this.tp_Feat5.Controls.Add(this.cf5_SpellId);
			this.tp_Feat5.Controls.Add(this.cf5_SpellLabel);
			this.tp_Feat5.Controls.Add(this.cf5_cheatCast);
			this.tp_Feat5.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat5.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat5.Name = "tp_Feat5";
			this.tp_Feat5.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat5.TabIndex = 5;
			this.tp_Feat5.Text = "feat5";
			// 
			// ClassFeat5_reset
			// 
			this.ClassFeat5_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat5_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_reset.Name = "ClassFeat5_reset";
			this.ClassFeat5_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat5_reset.TabIndex = 0;
			this.ClassFeat5_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat5_text
			// 
			this.ClassFeat5_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat5_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_text.Name = "ClassFeat5_text";
			this.ClassFeat5_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat5_text.TabIndex = 1;
			this.ClassFeat5_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat5_hex
			// 
			this.ClassFeat5_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat5_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat5_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat5_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_hex.Name = "ClassFeat5_hex";
			this.ClassFeat5_hex.ReadOnly = true;
			this.ClassFeat5_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat5_hex.TabIndex = 2;
			// 
			// ClassFeat5_bin
			// 
			this.ClassFeat5_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat5_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat5_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat5_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat5_bin.Name = "ClassFeat5_bin";
			this.ClassFeat5_bin.ReadOnly = true;
			this.ClassFeat5_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat5_bin.TabIndex = 3;
			// 
			// cf5_Clear
			// 
			this.cf5_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf5_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_Clear.Name = "cf5_Clear";
			this.cf5_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf5_Clear.TabIndex = 4;
			this.cf5_Clear.Text = "zero\r\nall\r\nbits";
			this.cf5_Clear.UseVisualStyleBackColor = true;
			// 
			// cf5_hex
			// 
			this.cf5_hex.Location = new System.Drawing.Point(400, 15);
			this.cf5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_hex.Name = "cf5_hex";
			this.cf5_hex.Size = new System.Drawing.Size(40, 15);
			this.cf5_hex.TabIndex = 5;
			this.cf5_hex.Text = "hex";
			this.cf5_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_bin
			// 
			this.cf5_bin.Location = new System.Drawing.Point(400, 35);
			this.cf5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_bin.Name = "cf5_bin";
			this.cf5_bin.Size = new System.Drawing.Size(40, 15);
			this.cf5_bin.TabIndex = 6;
			this.cf5_bin.Text = "bin";
			this.cf5_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_featId_label
			// 
			this.cf5_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf5_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_featId_label.Name = "cf5_featId_label";
			this.cf5_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf5_featId_label.TabIndex = 7;
			this.cf5_featId_label.Text = "ID Feat";
			this.cf5_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_FeatId
			// 
			this.cf5_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf5_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_FeatId.Name = "cf5_FeatId";
			this.cf5_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf5_FeatId.TabIndex = 8;
			// 
			// cf5_FeatLabel
			// 
			this.cf5_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf5_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_FeatLabel.Name = "cf5_FeatLabel";
			this.cf5_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf5_FeatLabel.TabIndex = 9;
			this.cf5_FeatLabel.Text = "cf5_FeatLabel";
			this.cf5_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_spellId_label
			// 
			this.cf5_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf5_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_spellId_label.Name = "cf5_spellId_label";
			this.cf5_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf5_spellId_label.TabIndex = 10;
			this.cf5_spellId_label.Text = "ID Spell";
			this.cf5_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_SpellId
			// 
			this.cf5_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf5_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_SpellId.Name = "cf5_SpellId";
			this.cf5_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf5_SpellId.TabIndex = 11;
			// 
			// cf5_SpellLabel
			// 
			this.cf5_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf5_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_SpellLabel.Name = "cf5_SpellLabel";
			this.cf5_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf5_SpellLabel.TabIndex = 12;
			this.cf5_SpellLabel.Text = "cf5_SpellLabel";
			this.cf5_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf5_cheatCast
			// 
			this.cf5_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf5_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf5_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf5_cheatCast.Name = "cf5_cheatCast";
			this.cf5_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf5_cheatCast.TabIndex = 13;
			this.cf5_cheatCast.Text = "cheat cast";
			this.cf5_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat6
			// 
			this.tp_Feat6.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat6.Controls.Add(this.ClassFeat6_reset);
			this.tp_Feat6.Controls.Add(this.ClassFeat6_text);
			this.tp_Feat6.Controls.Add(this.ClassFeat6_hex);
			this.tp_Feat6.Controls.Add(this.ClassFeat6_bin);
			this.tp_Feat6.Controls.Add(this.cf6_Clear);
			this.tp_Feat6.Controls.Add(this.cf6_hex);
			this.tp_Feat6.Controls.Add(this.cf6_bin);
			this.tp_Feat6.Controls.Add(this.cf6_featId_label);
			this.tp_Feat6.Controls.Add(this.cf6_FeatId);
			this.tp_Feat6.Controls.Add(this.cf6_FeatLabel);
			this.tp_Feat6.Controls.Add(this.cf6_spellId_label);
			this.tp_Feat6.Controls.Add(this.cf6_SpellId);
			this.tp_Feat6.Controls.Add(this.cf6_SpellLabel);
			this.tp_Feat6.Controls.Add(this.cf6_cheatCast);
			this.tp_Feat6.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat6.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat6.Name = "tp_Feat6";
			this.tp_Feat6.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat6.TabIndex = 5;
			this.tp_Feat6.Text = "feat6";
			// 
			// ClassFeat6_reset
			// 
			this.ClassFeat6_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat6_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_reset.Name = "ClassFeat6_reset";
			this.ClassFeat6_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat6_reset.TabIndex = 0;
			this.ClassFeat6_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat6_text
			// 
			this.ClassFeat6_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat6_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_text.Name = "ClassFeat6_text";
			this.ClassFeat6_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat6_text.TabIndex = 1;
			this.ClassFeat6_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat6_hex
			// 
			this.ClassFeat6_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat6_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat6_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat6_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat6_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_hex.Name = "ClassFeat6_hex";
			this.ClassFeat6_hex.ReadOnly = true;
			this.ClassFeat6_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat6_hex.TabIndex = 2;
			// 
			// ClassFeat6_bin
			// 
			this.ClassFeat6_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat6_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat6_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat6_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat6_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat6_bin.Name = "ClassFeat6_bin";
			this.ClassFeat6_bin.ReadOnly = true;
			this.ClassFeat6_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat6_bin.TabIndex = 3;
			// 
			// cf6_Clear
			// 
			this.cf6_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf6_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_Clear.Name = "cf6_Clear";
			this.cf6_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf6_Clear.TabIndex = 4;
			this.cf6_Clear.Text = "zero\r\nall\r\nbits";
			this.cf6_Clear.UseVisualStyleBackColor = true;
			// 
			// cf6_hex
			// 
			this.cf6_hex.Location = new System.Drawing.Point(400, 15);
			this.cf6_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_hex.Name = "cf6_hex";
			this.cf6_hex.Size = new System.Drawing.Size(40, 15);
			this.cf6_hex.TabIndex = 5;
			this.cf6_hex.Text = "hex";
			this.cf6_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_bin
			// 
			this.cf6_bin.Location = new System.Drawing.Point(400, 35);
			this.cf6_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_bin.Name = "cf6_bin";
			this.cf6_bin.Size = new System.Drawing.Size(40, 15);
			this.cf6_bin.TabIndex = 6;
			this.cf6_bin.Text = "bin";
			this.cf6_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_featId_label
			// 
			this.cf6_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf6_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_featId_label.Name = "cf6_featId_label";
			this.cf6_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf6_featId_label.TabIndex = 7;
			this.cf6_featId_label.Text = "ID Feat";
			this.cf6_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_FeatId
			// 
			this.cf6_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf6_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_FeatId.Name = "cf6_FeatId";
			this.cf6_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf6_FeatId.TabIndex = 8;
			// 
			// cf6_FeatLabel
			// 
			this.cf6_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf6_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_FeatLabel.Name = "cf6_FeatLabel";
			this.cf6_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf6_FeatLabel.TabIndex = 9;
			this.cf6_FeatLabel.Text = "cf6_FeatLabel";
			this.cf6_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_spellId_label
			// 
			this.cf6_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf6_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_spellId_label.Name = "cf6_spellId_label";
			this.cf6_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf6_spellId_label.TabIndex = 10;
			this.cf6_spellId_label.Text = "ID Spell";
			this.cf6_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_SpellId
			// 
			this.cf6_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf6_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_SpellId.Name = "cf6_SpellId";
			this.cf6_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf6_SpellId.TabIndex = 11;
			// 
			// cf6_SpellLabel
			// 
			this.cf6_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf6_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_SpellLabel.Name = "cf6_SpellLabel";
			this.cf6_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf6_SpellLabel.TabIndex = 12;
			this.cf6_SpellLabel.Text = "cf6_SpellLabel";
			this.cf6_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf6_cheatCast
			// 
			this.cf6_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf6_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf6_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf6_cheatCast.Name = "cf6_cheatCast";
			this.cf6_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf6_cheatCast.TabIndex = 13;
			this.cf6_cheatCast.Text = "cheat cast";
			this.cf6_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat7
			// 
			this.tp_Feat7.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat7.Controls.Add(this.ClassFeat7_reset);
			this.tp_Feat7.Controls.Add(this.ClassFeat7_text);
			this.tp_Feat7.Controls.Add(this.ClassFeat7_hex);
			this.tp_Feat7.Controls.Add(this.ClassFeat7_bin);
			this.tp_Feat7.Controls.Add(this.cf7_Clear);
			this.tp_Feat7.Controls.Add(this.cf7_hex);
			this.tp_Feat7.Controls.Add(this.cf7_bin);
			this.tp_Feat7.Controls.Add(this.cf7_featId_label);
			this.tp_Feat7.Controls.Add(this.cf7_FeatId);
			this.tp_Feat7.Controls.Add(this.cf7_FeatLabel);
			this.tp_Feat7.Controls.Add(this.cf7_spellId_label);
			this.tp_Feat7.Controls.Add(this.cf7_SpellId);
			this.tp_Feat7.Controls.Add(this.cf7_SpellLabel);
			this.tp_Feat7.Controls.Add(this.cf7_cheatCast);
			this.tp_Feat7.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat7.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat7.Name = "tp_Feat7";
			this.tp_Feat7.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat7.TabIndex = 5;
			this.tp_Feat7.Text = "feat7";
			// 
			// ClassFeat7_reset
			// 
			this.ClassFeat7_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat7_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_reset.Name = "ClassFeat7_reset";
			this.ClassFeat7_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat7_reset.TabIndex = 0;
			this.ClassFeat7_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat7_text
			// 
			this.ClassFeat7_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat7_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_text.Name = "ClassFeat7_text";
			this.ClassFeat7_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat7_text.TabIndex = 1;
			this.ClassFeat7_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat7_hex
			// 
			this.ClassFeat7_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat7_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat7_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat7_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat7_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_hex.Name = "ClassFeat7_hex";
			this.ClassFeat7_hex.ReadOnly = true;
			this.ClassFeat7_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat7_hex.TabIndex = 2;
			// 
			// ClassFeat7_bin
			// 
			this.ClassFeat7_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat7_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat7_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat7_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat7_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat7_bin.Name = "ClassFeat7_bin";
			this.ClassFeat7_bin.ReadOnly = true;
			this.ClassFeat7_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat7_bin.TabIndex = 3;
			// 
			// cf7_Clear
			// 
			this.cf7_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf7_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_Clear.Name = "cf7_Clear";
			this.cf7_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf7_Clear.TabIndex = 4;
			this.cf7_Clear.Text = "zero\r\nall\r\nbits";
			this.cf7_Clear.UseVisualStyleBackColor = true;
			// 
			// cf7_hex
			// 
			this.cf7_hex.Location = new System.Drawing.Point(400, 15);
			this.cf7_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_hex.Name = "cf7_hex";
			this.cf7_hex.Size = new System.Drawing.Size(40, 15);
			this.cf7_hex.TabIndex = 5;
			this.cf7_hex.Text = "hex";
			this.cf7_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_bin
			// 
			this.cf7_bin.Location = new System.Drawing.Point(400, 35);
			this.cf7_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_bin.Name = "cf7_bin";
			this.cf7_bin.Size = new System.Drawing.Size(40, 15);
			this.cf7_bin.TabIndex = 6;
			this.cf7_bin.Text = "bin";
			this.cf7_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_featId_label
			// 
			this.cf7_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf7_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_featId_label.Name = "cf7_featId_label";
			this.cf7_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf7_featId_label.TabIndex = 7;
			this.cf7_featId_label.Text = "ID Feat";
			this.cf7_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_FeatId
			// 
			this.cf7_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf7_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_FeatId.Name = "cf7_FeatId";
			this.cf7_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf7_FeatId.TabIndex = 8;
			// 
			// cf7_FeatLabel
			// 
			this.cf7_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf7_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_FeatLabel.Name = "cf7_FeatLabel";
			this.cf7_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf7_FeatLabel.TabIndex = 9;
			this.cf7_FeatLabel.Text = "cf7_FeatLabel";
			this.cf7_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_spellId_label
			// 
			this.cf7_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf7_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_spellId_label.Name = "cf7_spellId_label";
			this.cf7_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf7_spellId_label.TabIndex = 10;
			this.cf7_spellId_label.Text = "ID Spell";
			this.cf7_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_SpellId
			// 
			this.cf7_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf7_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_SpellId.Name = "cf7_SpellId";
			this.cf7_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf7_SpellId.TabIndex = 11;
			// 
			// cf7_SpellLabel
			// 
			this.cf7_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf7_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_SpellLabel.Name = "cf7_SpellLabel";
			this.cf7_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf7_SpellLabel.TabIndex = 12;
			this.cf7_SpellLabel.Text = "cf7_SpellLabel";
			this.cf7_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf7_cheatCast
			// 
			this.cf7_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf7_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf7_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf7_cheatCast.Name = "cf7_cheatCast";
			this.cf7_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf7_cheatCast.TabIndex = 13;
			this.cf7_cheatCast.Text = "cheat cast";
			this.cf7_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat8
			// 
			this.tp_Feat8.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat8.Controls.Add(this.ClassFeat8_reset);
			this.tp_Feat8.Controls.Add(this.ClassFeat8_text);
			this.tp_Feat8.Controls.Add(this.ClassFeat8_hex);
			this.tp_Feat8.Controls.Add(this.ClassFeat8_bin);
			this.tp_Feat8.Controls.Add(this.cf8_Clear);
			this.tp_Feat8.Controls.Add(this.cf8_hex);
			this.tp_Feat8.Controls.Add(this.cf8_bin);
			this.tp_Feat8.Controls.Add(this.cf8_featId_label);
			this.tp_Feat8.Controls.Add(this.cf8_FeatId);
			this.tp_Feat8.Controls.Add(this.cf8_FeatLabel);
			this.tp_Feat8.Controls.Add(this.cf8_spellId_label);
			this.tp_Feat8.Controls.Add(this.cf8_SpellId);
			this.tp_Feat8.Controls.Add(this.cf8_SpellLabel);
			this.tp_Feat8.Controls.Add(this.cf8_cheatCast);
			this.tp_Feat8.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat8.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat8.Name = "tp_Feat8";
			this.tp_Feat8.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat8.TabIndex = 5;
			this.tp_Feat8.Text = "feat8";
			// 
			// ClassFeat8_reset
			// 
			this.ClassFeat8_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat8_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_reset.Name = "ClassFeat8_reset";
			this.ClassFeat8_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat8_reset.TabIndex = 0;
			this.ClassFeat8_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat8_text
			// 
			this.ClassFeat8_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat8_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_text.Name = "ClassFeat8_text";
			this.ClassFeat8_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat8_text.TabIndex = 1;
			this.ClassFeat8_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat8_hex
			// 
			this.ClassFeat8_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat8_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat8_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat8_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat8_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_hex.Name = "ClassFeat8_hex";
			this.ClassFeat8_hex.ReadOnly = true;
			this.ClassFeat8_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat8_hex.TabIndex = 2;
			// 
			// ClassFeat8_bin
			// 
			this.ClassFeat8_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat8_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat8_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat8_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat8_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat8_bin.Name = "ClassFeat8_bin";
			this.ClassFeat8_bin.ReadOnly = true;
			this.ClassFeat8_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat8_bin.TabIndex = 3;
			// 
			// cf8_Clear
			// 
			this.cf8_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf8_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_Clear.Name = "cf8_Clear";
			this.cf8_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf8_Clear.TabIndex = 4;
			this.cf8_Clear.Text = "zero\r\nall\r\nbits";
			this.cf8_Clear.UseVisualStyleBackColor = true;
			// 
			// cf8_hex
			// 
			this.cf8_hex.Location = new System.Drawing.Point(400, 15);
			this.cf8_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_hex.Name = "cf8_hex";
			this.cf8_hex.Size = new System.Drawing.Size(40, 15);
			this.cf8_hex.TabIndex = 5;
			this.cf8_hex.Text = "hex";
			this.cf8_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_bin
			// 
			this.cf8_bin.Location = new System.Drawing.Point(400, 35);
			this.cf8_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_bin.Name = "cf8_bin";
			this.cf8_bin.Size = new System.Drawing.Size(40, 15);
			this.cf8_bin.TabIndex = 6;
			this.cf8_bin.Text = "bin";
			this.cf8_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_featId_label
			// 
			this.cf8_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf8_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_featId_label.Name = "cf8_featId_label";
			this.cf8_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf8_featId_label.TabIndex = 7;
			this.cf8_featId_label.Text = "ID Feat";
			this.cf8_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_FeatId
			// 
			this.cf8_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf8_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_FeatId.Name = "cf8_FeatId";
			this.cf8_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf8_FeatId.TabIndex = 8;
			// 
			// cf8_FeatLabel
			// 
			this.cf8_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf8_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_FeatLabel.Name = "cf8_FeatLabel";
			this.cf8_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf8_FeatLabel.TabIndex = 9;
			this.cf8_FeatLabel.Text = "cf8_FeatLabel";
			this.cf8_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_spellId_label
			// 
			this.cf8_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf8_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_spellId_label.Name = "cf8_spellId_label";
			this.cf8_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf8_spellId_label.TabIndex = 10;
			this.cf8_spellId_label.Text = "ID Spell";
			this.cf8_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_SpellId
			// 
			this.cf8_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf8_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_SpellId.Name = "cf8_SpellId";
			this.cf8_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf8_SpellId.TabIndex = 11;
			// 
			// cf8_SpellLabel
			// 
			this.cf8_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf8_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_SpellLabel.Name = "cf8_SpellLabel";
			this.cf8_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf8_SpellLabel.TabIndex = 12;
			this.cf8_SpellLabel.Text = "cf8_SpellLabel";
			this.cf8_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf8_cheatCast
			// 
			this.cf8_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf8_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf8_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf8_cheatCast.Name = "cf8_cheatCast";
			this.cf8_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf8_cheatCast.TabIndex = 13;
			this.cf8_cheatCast.Text = "cheat cast";
			this.cf8_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat9
			// 
			this.tp_Feat9.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat9.Controls.Add(this.ClassFeat9_reset);
			this.tp_Feat9.Controls.Add(this.ClassFeat9_text);
			this.tp_Feat9.Controls.Add(this.ClassFeat9_hex);
			this.tp_Feat9.Controls.Add(this.ClassFeat9_bin);
			this.tp_Feat9.Controls.Add(this.cf9_Clear);
			this.tp_Feat9.Controls.Add(this.cf9_hex);
			this.tp_Feat9.Controls.Add(this.cf9_bin);
			this.tp_Feat9.Controls.Add(this.cf9_featId_label);
			this.tp_Feat9.Controls.Add(this.cf9_FeatId);
			this.tp_Feat9.Controls.Add(this.cf9_FeatLabel);
			this.tp_Feat9.Controls.Add(this.cf9_spellId_label);
			this.tp_Feat9.Controls.Add(this.cf9_SpellId);
			this.tp_Feat9.Controls.Add(this.cf9_SpellLabel);
			this.tp_Feat9.Controls.Add(this.cf9_cheatCast);
			this.tp_Feat9.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat9.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat9.Name = "tp_Feat9";
			this.tp_Feat9.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat9.TabIndex = 5;
			this.tp_Feat9.Text = "feat9";
			// 
			// ClassFeat9_reset
			// 
			this.ClassFeat9_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat9_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_reset.Name = "ClassFeat9_reset";
			this.ClassFeat9_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat9_reset.TabIndex = 0;
			this.ClassFeat9_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat9_text
			// 
			this.ClassFeat9_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat9_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_text.Name = "ClassFeat9_text";
			this.ClassFeat9_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat9_text.TabIndex = 1;
			this.ClassFeat9_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat9_hex
			// 
			this.ClassFeat9_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat9_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat9_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat9_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat9_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_hex.Name = "ClassFeat9_hex";
			this.ClassFeat9_hex.ReadOnly = true;
			this.ClassFeat9_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat9_hex.TabIndex = 2;
			// 
			// ClassFeat9_bin
			// 
			this.ClassFeat9_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat9_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat9_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat9_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat9_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat9_bin.Name = "ClassFeat9_bin";
			this.ClassFeat9_bin.ReadOnly = true;
			this.ClassFeat9_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat9_bin.TabIndex = 3;
			// 
			// cf9_Clear
			// 
			this.cf9_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf9_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_Clear.Name = "cf9_Clear";
			this.cf9_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf9_Clear.TabIndex = 4;
			this.cf9_Clear.Text = "zero\r\nall\r\nbits";
			this.cf9_Clear.UseVisualStyleBackColor = true;
			// 
			// cf9_hex
			// 
			this.cf9_hex.Location = new System.Drawing.Point(400, 15);
			this.cf9_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_hex.Name = "cf9_hex";
			this.cf9_hex.Size = new System.Drawing.Size(40, 15);
			this.cf9_hex.TabIndex = 5;
			this.cf9_hex.Text = "hex";
			this.cf9_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_bin
			// 
			this.cf9_bin.Location = new System.Drawing.Point(400, 35);
			this.cf9_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_bin.Name = "cf9_bin";
			this.cf9_bin.Size = new System.Drawing.Size(40, 15);
			this.cf9_bin.TabIndex = 6;
			this.cf9_bin.Text = "bin";
			this.cf9_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_featId_label
			// 
			this.cf9_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf9_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_featId_label.Name = "cf9_featId_label";
			this.cf9_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf9_featId_label.TabIndex = 7;
			this.cf9_featId_label.Text = "ID Feat";
			this.cf9_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_FeatId
			// 
			this.cf9_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf9_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_FeatId.Name = "cf9_FeatId";
			this.cf9_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf9_FeatId.TabIndex = 8;
			// 
			// cf9_FeatLabel
			// 
			this.cf9_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf9_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_FeatLabel.Name = "cf9_FeatLabel";
			this.cf9_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf9_FeatLabel.TabIndex = 9;
			this.cf9_FeatLabel.Text = "cf9_FeatLabel";
			this.cf9_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_spellId_label
			// 
			this.cf9_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf9_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_spellId_label.Name = "cf9_spellId_label";
			this.cf9_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf9_spellId_label.TabIndex = 10;
			this.cf9_spellId_label.Text = "ID Spell";
			this.cf9_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_SpellId
			// 
			this.cf9_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf9_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_SpellId.Name = "cf9_SpellId";
			this.cf9_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf9_SpellId.TabIndex = 11;
			// 
			// cf9_SpellLabel
			// 
			this.cf9_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf9_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_SpellLabel.Name = "cf9_SpellLabel";
			this.cf9_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf9_SpellLabel.TabIndex = 12;
			this.cf9_SpellLabel.Text = "cf9_SpellLabel";
			this.cf9_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf9_cheatCast
			// 
			this.cf9_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf9_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf9_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf9_cheatCast.Name = "cf9_cheatCast";
			this.cf9_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf9_cheatCast.TabIndex = 13;
			this.cf9_cheatCast.Text = "cheat cast";
			this.cf9_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat10
			// 
			this.tp_Feat10.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat10.Controls.Add(this.ClassFeat10_reset);
			this.tp_Feat10.Controls.Add(this.ClassFeat10_text);
			this.tp_Feat10.Controls.Add(this.ClassFeat10_hex);
			this.tp_Feat10.Controls.Add(this.ClassFeat10_bin);
			this.tp_Feat10.Controls.Add(this.cf10_Clear);
			this.tp_Feat10.Controls.Add(this.cf10_hex);
			this.tp_Feat10.Controls.Add(this.cf10_bin);
			this.tp_Feat10.Controls.Add(this.cf10_featId_label);
			this.tp_Feat10.Controls.Add(this.cf10_FeatId);
			this.tp_Feat10.Controls.Add(this.cf10_FeatLabel);
			this.tp_Feat10.Controls.Add(this.cf10_spellId_label);
			this.tp_Feat10.Controls.Add(this.cf10_SpellId);
			this.tp_Feat10.Controls.Add(this.cf10_SpellLabel);
			this.tp_Feat10.Controls.Add(this.cf10_cheatCast);
			this.tp_Feat10.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat10.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat10.Name = "tp_Feat10";
			this.tp_Feat10.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat10.TabIndex = 5;
			this.tp_Feat10.Text = "feat10";
			// 
			// ClassFeat10_reset
			// 
			this.ClassFeat10_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat10_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_reset.Name = "ClassFeat10_reset";
			this.ClassFeat10_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat10_reset.TabIndex = 0;
			this.ClassFeat10_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat10_text
			// 
			this.ClassFeat10_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat10_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_text.Name = "ClassFeat10_text";
			this.ClassFeat10_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat10_text.TabIndex = 1;
			this.ClassFeat10_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat10_hex
			// 
			this.ClassFeat10_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat10_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat10_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat10_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat10_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_hex.Name = "ClassFeat10_hex";
			this.ClassFeat10_hex.ReadOnly = true;
			this.ClassFeat10_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat10_hex.TabIndex = 2;
			// 
			// ClassFeat10_bin
			// 
			this.ClassFeat10_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat10_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat10_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat10_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat10_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat10_bin.Name = "ClassFeat10_bin";
			this.ClassFeat10_bin.ReadOnly = true;
			this.ClassFeat10_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat10_bin.TabIndex = 3;
			// 
			// cf10_Clear
			// 
			this.cf10_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf10_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_Clear.Name = "cf10_Clear";
			this.cf10_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf10_Clear.TabIndex = 4;
			this.cf10_Clear.Text = "zero\r\nall\r\nbits";
			this.cf10_Clear.UseVisualStyleBackColor = true;
			// 
			// cf10_hex
			// 
			this.cf10_hex.Location = new System.Drawing.Point(400, 15);
			this.cf10_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_hex.Name = "cf10_hex";
			this.cf10_hex.Size = new System.Drawing.Size(40, 15);
			this.cf10_hex.TabIndex = 5;
			this.cf10_hex.Text = "hex";
			this.cf10_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_bin
			// 
			this.cf10_bin.Location = new System.Drawing.Point(400, 35);
			this.cf10_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_bin.Name = "cf10_bin";
			this.cf10_bin.Size = new System.Drawing.Size(40, 15);
			this.cf10_bin.TabIndex = 6;
			this.cf10_bin.Text = "bin";
			this.cf10_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_featId_label
			// 
			this.cf10_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf10_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_featId_label.Name = "cf10_featId_label";
			this.cf10_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf10_featId_label.TabIndex = 7;
			this.cf10_featId_label.Text = "ID Feat";
			this.cf10_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_FeatId
			// 
			this.cf10_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf10_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_FeatId.Name = "cf10_FeatId";
			this.cf10_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf10_FeatId.TabIndex = 8;
			// 
			// cf10_FeatLabel
			// 
			this.cf10_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf10_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_FeatLabel.Name = "cf10_FeatLabel";
			this.cf10_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf10_FeatLabel.TabIndex = 9;
			this.cf10_FeatLabel.Text = "cf10_FeatLabel";
			this.cf10_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_spellId_label
			// 
			this.cf10_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf10_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_spellId_label.Name = "cf10_spellId_label";
			this.cf10_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf10_spellId_label.TabIndex = 10;
			this.cf10_spellId_label.Text = "ID Spell";
			this.cf10_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_SpellId
			// 
			this.cf10_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf10_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_SpellId.Name = "cf10_SpellId";
			this.cf10_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf10_SpellId.TabIndex = 11;
			// 
			// cf10_SpellLabel
			// 
			this.cf10_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf10_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_SpellLabel.Name = "cf10_SpellLabel";
			this.cf10_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf10_SpellLabel.TabIndex = 12;
			this.cf10_SpellLabel.Text = "cf10_SpellLabel";
			this.cf10_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf10_cheatCast
			// 
			this.cf10_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf10_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf10_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf10_cheatCast.Name = "cf10_cheatCast";
			this.cf10_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf10_cheatCast.TabIndex = 13;
			this.cf10_cheatCast.Text = "cheat cast";
			this.cf10_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat11
			// 
			this.tp_Feat11.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat11.Controls.Add(this.ClassFeat11_reset);
			this.tp_Feat11.Controls.Add(this.ClassFeat11_text);
			this.tp_Feat11.Controls.Add(this.ClassFeat11_hex);
			this.tp_Feat11.Controls.Add(this.ClassFeat11_bin);
			this.tp_Feat11.Controls.Add(this.cf11_Clear);
			this.tp_Feat11.Controls.Add(this.cf11_hex);
			this.tp_Feat11.Controls.Add(this.cf11_bin);
			this.tp_Feat11.Controls.Add(this.cf11_featId_label);
			this.tp_Feat11.Controls.Add(this.cf11_FeatId);
			this.tp_Feat11.Controls.Add(this.cf11_FeatLabel);
			this.tp_Feat11.Controls.Add(this.cf11_spellId_label);
			this.tp_Feat11.Controls.Add(this.cf11_SpellId);
			this.tp_Feat11.Controls.Add(this.cf11_SpellLabel);
			this.tp_Feat11.Controls.Add(this.cf11_cheatCast);
			this.tp_Feat11.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat11.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat11.Name = "tp_Feat11";
			this.tp_Feat11.Size = new System.Drawing.Size(972, 133);
			this.tp_Feat11.TabIndex = 5;
			this.tp_Feat11.Text = "feat11";
			// 
			// ClassFeat11_reset
			// 
			this.ClassFeat11_reset.Location = new System.Drawing.Point(5, 5);
			this.ClassFeat11_reset.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_reset.Name = "ClassFeat11_reset";
			this.ClassFeat11_reset.Size = new System.Drawing.Size(100, 25);
			this.ClassFeat11_reset.TabIndex = 0;
			this.ClassFeat11_reset.UseVisualStyleBackColor = true;
			// 
			// ClassFeat11_text
			// 
			this.ClassFeat11_text.Location = new System.Drawing.Point(5, 35);
			this.ClassFeat11_text.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_text.Name = "ClassFeat11_text";
			this.ClassFeat11_text.Size = new System.Drawing.Size(100, 20);
			this.ClassFeat11_text.TabIndex = 1;
			this.ClassFeat11_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ClassFeat11_hex
			// 
			this.ClassFeat11_hex.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat11_hex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat11_hex.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat11_hex.Location = new System.Drawing.Point(115, 15);
			this.ClassFeat11_hex.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_hex.Name = "ClassFeat11_hex";
			this.ClassFeat11_hex.ReadOnly = true;
			this.ClassFeat11_hex.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat11_hex.TabIndex = 2;
			// 
			// ClassFeat11_bin
			// 
			this.ClassFeat11_bin.BackColor = System.Drawing.SystemColors.Window;
			this.ClassFeat11_bin.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ClassFeat11_bin.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ClassFeat11_bin.Location = new System.Drawing.Point(115, 35);
			this.ClassFeat11_bin.Margin = new System.Windows.Forms.Padding(0);
			this.ClassFeat11_bin.Name = "ClassFeat11_bin";
			this.ClassFeat11_bin.ReadOnly = true;
			this.ClassFeat11_bin.Size = new System.Drawing.Size(275, 13);
			this.ClassFeat11_bin.TabIndex = 3;
			// 
			// cf11_Clear
			// 
			this.cf11_Clear.Location = new System.Drawing.Point(450, 5);
			this.cf11_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_Clear.Name = "cf11_Clear";
			this.cf11_Clear.Size = new System.Drawing.Size(65, 50);
			this.cf11_Clear.TabIndex = 4;
			this.cf11_Clear.Text = "zero\r\nall\r\nbits";
			this.cf11_Clear.UseVisualStyleBackColor = true;
			// 
			// cf11_hex
			// 
			this.cf11_hex.Location = new System.Drawing.Point(400, 15);
			this.cf11_hex.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_hex.Name = "cf11_hex";
			this.cf11_hex.Size = new System.Drawing.Size(40, 15);
			this.cf11_hex.TabIndex = 5;
			this.cf11_hex.Text = "hex";
			this.cf11_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_bin
			// 
			this.cf11_bin.Location = new System.Drawing.Point(400, 35);
			this.cf11_bin.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_bin.Name = "cf11_bin";
			this.cf11_bin.Size = new System.Drawing.Size(40, 15);
			this.cf11_bin.TabIndex = 6;
			this.cf11_bin.Text = "bin";
			this.cf11_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_featId_label
			// 
			this.cf11_featId_label.Location = new System.Drawing.Point(10, 65);
			this.cf11_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_featId_label.Name = "cf11_featId_label";
			this.cf11_featId_label.Size = new System.Drawing.Size(65, 15);
			this.cf11_featId_label.TabIndex = 7;
			this.cf11_featId_label.Text = "ID Feat";
			this.cf11_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_FeatId
			// 
			this.cf11_FeatId.Location = new System.Drawing.Point(80, 60);
			this.cf11_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_FeatId.Name = "cf11_FeatId";
			this.cf11_FeatId.Size = new System.Drawing.Size(90, 20);
			this.cf11_FeatId.TabIndex = 8;
			// 
			// cf11_FeatLabel
			// 
			this.cf11_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.cf11_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_FeatLabel.Name = "cf11_FeatLabel";
			this.cf11_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.cf11_FeatLabel.TabIndex = 9;
			this.cf11_FeatLabel.Text = "cf11_FeatLabel";
			this.cf11_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_spellId_label
			// 
			this.cf11_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.cf11_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_spellId_label.Name = "cf11_spellId_label";
			this.cf11_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.cf11_spellId_label.TabIndex = 10;
			this.cf11_spellId_label.Text = "ID Spell";
			this.cf11_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_SpellId
			// 
			this.cf11_SpellId.Location = new System.Drawing.Point(80, 80);
			this.cf11_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_SpellId.Name = "cf11_SpellId";
			this.cf11_SpellId.Size = new System.Drawing.Size(90, 20);
			this.cf11_SpellId.TabIndex = 11;
			// 
			// cf11_SpellLabel
			// 
			this.cf11_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.cf11_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_SpellLabel.Name = "cf11_SpellLabel";
			this.cf11_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.cf11_SpellLabel.TabIndex = 12;
			this.cf11_SpellLabel.Text = "cf11_SpellLabel";
			this.cf11_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cf11_cheatCast
			// 
			this.cf11_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.cf11_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.cf11_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.cf11_cheatCast.Name = "cf11_cheatCast";
			this.cf11_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.cf11_cheatCast.TabIndex = 13;
			this.cf11_cheatCast.Text = "cheat cast";
			this.cf11_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tabcontrol_Classes
			// 
			this.Controls.Add(this.tc_Classes);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "tabcontrol_Classes";
			this.Size = new System.Drawing.Size(980, 159);
			this.tc_Classes.ResumeLayout(false);
			this.tp_Flags.ResumeLayout(false);
			this.tp_Flags.PerformLayout();
			this.tp_Feat1.ResumeLayout(false);
			this.tp_Feat1.PerformLayout();
			this.tp_Feat2.ResumeLayout(false);
			this.tp_Feat2.PerformLayout();
			this.tp_Feat3.ResumeLayout(false);
			this.tp_Feat3.PerformLayout();
			this.tp_Feat4.ResumeLayout(false);
			this.tp_Feat4.PerformLayout();
			this.tp_Feat5.ResumeLayout(false);
			this.tp_Feat5.PerformLayout();
			this.tp_Feat6.ResumeLayout(false);
			this.tp_Feat6.PerformLayout();
			this.tp_Feat7.ResumeLayout(false);
			this.tp_Feat7.PerformLayout();
			this.tp_Feat8.ResumeLayout(false);
			this.tp_Feat8.PerformLayout();
			this.tp_Feat9.ResumeLayout(false);
			this.tp_Feat9.PerformLayout();
			this.tp_Feat10.ResumeLayout(false);
			this.tp_Feat10.PerformLayout();
			this.tp_Feat11.ResumeLayout(false);
			this.tp_Feat11.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
