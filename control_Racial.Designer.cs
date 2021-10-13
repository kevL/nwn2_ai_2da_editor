using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class control_Racial
	{
//		tp_Flags.Controls.Add(this.rf_infoversion);
//		tp_Flags.Controls.Add(this.rf_infoversion_lbl);

		#region Designer
		CompositedTabControl tc_Racial;

		TabPage tp_Flags;
		TabPage tp_Feat1;
		TabPage tp_Feat2;
		TabPage tp_Feat3;
		TabPage tp_Feat4;
		TabPage tp_Feat5;

// 'tp_Flags' controls
		Button     RacialFlags_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFlags_text;
		TextBox    RacialFlags_hex;
		TextBox    RacialFlags_bin;

		Button rf_Clear;
		Label  rf_hex;
		Label  rf_bin;

		CheckBox rf_HasFeatSpells;

// 'tp_Feat1' controls
		Button     RacialFeat1_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFeat1_text;
		TextBox    RacialFeat1_hex;
		TextBox    RacialFeat1_bin;

		Button rf1_Clear;
		Label  rf1_hex;
		Label  rf1_bin;

		Label      rf1_featId_label;
		TextboxInt rf1_FeatId;
		Label      rf1_FeatLabel;
		Label      rf1_spellId_label;
		TextboxInt rf1_SpellId;
		Label      rf1_SpellLabel;
		CheckBox   rf1_cheatCast;

// 'tp_Feat2' controls
		Button     RacialFeat2_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFeat2_text;
		TextBox    RacialFeat2_hex;
		TextBox    RacialFeat2_bin;

		Button rf2_Clear;
		Label  rf2_hex;
		Label  rf2_bin;

		Label      rf2_featId_label;
		TextboxInt rf2_FeatId;
		Label      rf2_FeatLabel;
		Label      rf2_spellId_label;
		TextboxInt rf2_SpellId;
		Label      rf2_SpellLabel;
		CheckBox   rf2_cheatCast;

// 'tp_Feat3' controls
		Button     RacialFeat3_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFeat3_text;
		TextBox    RacialFeat3_hex;
		TextBox    RacialFeat3_bin;

		Button rf3_Clear;
		Label  rf3_hex;
		Label  rf3_bin;

		Label      rf3_featId_label;
		TextboxInt rf3_FeatId;
		Label      rf3_FeatLabel;
		Label      rf3_spellId_label;
		TextboxInt rf3_SpellId;
		Label      rf3_SpellLabel;
		CheckBox   rf3_cheatCast;

// 'tp_Feat4' controls
		Button     RacialFeat4_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFeat4_text;
		TextBox    RacialFeat4_hex;
		TextBox    RacialFeat4_bin;

		Button rf4_Clear;
		Label  rf4_hex;
		Label  rf4_bin;

		Label      rf4_featId_label;
		TextboxInt rf4_FeatId;
		Label      rf4_FeatLabel;
		Label      rf4_spellId_label;
		TextboxInt rf4_SpellId;
		Label      rf4_SpellLabel;
		CheckBox   rf4_cheatCast;

// 'tp_Feat5' controls
		Button     RacialFeat5_reset; // TODO: ToolTip "reset"
		TextboxInt RacialFeat5_text;
		TextBox    RacialFeat5_hex;
		TextBox    RacialFeat5_bin;

		Button rf5_Clear;
		Label  rf5_hex;
		Label  rf5_bin;

		Label      rf5_featId_label;
		TextboxInt rf5_FeatId;
		Label      rf5_FeatLabel;
		Label      rf5_spellId_label;
		TextboxInt rf5_SpellId;
		Label      rf5_SpellLabel;
		CheckBox   rf5_cheatCast;


		/// <summary>
		/// *si effin designer bs
		/// </summary>
		void InitializeComponent()
		{
			this.tc_Racial = new nwn2_ai_2da_editor.CompositedTabControl();
			this.tp_Flags = new System.Windows.Forms.TabPage();
			this.RacialFlags_reset = new System.Windows.Forms.Button();
			this.RacialFlags_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFlags_hex = new System.Windows.Forms.TextBox();
			this.RacialFlags_bin = new System.Windows.Forms.TextBox();
			this.rf_Clear = new System.Windows.Forms.Button();
			this.rf_hex = new System.Windows.Forms.Label();
			this.rf_bin = new System.Windows.Forms.Label();
			this.rf_HasFeatSpells = new System.Windows.Forms.CheckBox();
			this.tp_Feat1 = new System.Windows.Forms.TabPage();
			this.RacialFeat1_reset = new System.Windows.Forms.Button();
			this.RacialFeat1_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFeat1_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat1_bin = new System.Windows.Forms.TextBox();
			this.rf1_Clear = new System.Windows.Forms.Button();
			this.rf1_hex = new System.Windows.Forms.Label();
			this.rf1_bin = new System.Windows.Forms.Label();
			this.rf1_featId_label = new System.Windows.Forms.Label();
			this.rf1_FeatId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf1_FeatLabel = new System.Windows.Forms.Label();
			this.rf1_spellId_label = new System.Windows.Forms.Label();
			this.rf1_SpellId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf1_SpellLabel = new System.Windows.Forms.Label();
			this.rf1_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat2 = new System.Windows.Forms.TabPage();
			this.RacialFeat2_reset = new System.Windows.Forms.Button();
			this.RacialFeat2_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFeat2_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat2_bin = new System.Windows.Forms.TextBox();
			this.rf2_Clear = new System.Windows.Forms.Button();
			this.rf2_hex = new System.Windows.Forms.Label();
			this.rf2_bin = new System.Windows.Forms.Label();
			this.rf2_featId_label = new System.Windows.Forms.Label();
			this.rf2_FeatId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf2_FeatLabel = new System.Windows.Forms.Label();
			this.rf2_spellId_label = new System.Windows.Forms.Label();
			this.rf2_SpellId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf2_SpellLabel = new System.Windows.Forms.Label();
			this.rf2_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat3 = new System.Windows.Forms.TabPage();
			this.RacialFeat3_reset = new System.Windows.Forms.Button();
			this.RacialFeat3_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFeat3_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat3_bin = new System.Windows.Forms.TextBox();
			this.rf3_Clear = new System.Windows.Forms.Button();
			this.rf3_hex = new System.Windows.Forms.Label();
			this.rf3_bin = new System.Windows.Forms.Label();
			this.rf3_featId_label = new System.Windows.Forms.Label();
			this.rf3_FeatId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf3_FeatLabel = new System.Windows.Forms.Label();
			this.rf3_spellId_label = new System.Windows.Forms.Label();
			this.rf3_SpellId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf3_SpellLabel = new System.Windows.Forms.Label();
			this.rf3_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat4 = new System.Windows.Forms.TabPage();
			this.RacialFeat4_reset = new System.Windows.Forms.Button();
			this.RacialFeat4_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFeat4_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat4_bin = new System.Windows.Forms.TextBox();
			this.rf4_Clear = new System.Windows.Forms.Button();
			this.rf4_hex = new System.Windows.Forms.Label();
			this.rf4_bin = new System.Windows.Forms.Label();
			this.rf4_featId_label = new System.Windows.Forms.Label();
			this.rf4_FeatId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf4_FeatLabel = new System.Windows.Forms.Label();
			this.rf4_spellId_label = new System.Windows.Forms.Label();
			this.rf4_SpellId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf4_SpellLabel = new System.Windows.Forms.Label();
			this.rf4_cheatCast = new System.Windows.Forms.CheckBox();
			this.tp_Feat5 = new System.Windows.Forms.TabPage();
			this.RacialFeat5_reset = new System.Windows.Forms.Button();
			this.RacialFeat5_text = new nwn2_ai_2da_editor.TextboxInt();
			this.RacialFeat5_hex = new System.Windows.Forms.TextBox();
			this.RacialFeat5_bin = new System.Windows.Forms.TextBox();
			this.rf5_Clear = new System.Windows.Forms.Button();
			this.rf5_hex = new System.Windows.Forms.Label();
			this.rf5_bin = new System.Windows.Forms.Label();
			this.rf5_featId_label = new System.Windows.Forms.Label();
			this.rf5_FeatId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf5_FeatLabel = new System.Windows.Forms.Label();
			this.rf5_spellId_label = new System.Windows.Forms.Label();
			this.rf5_SpellId = new nwn2_ai_2da_editor.TextboxInt();
			this.rf5_SpellLabel = new System.Windows.Forms.Label();
			this.rf5_cheatCast = new System.Windows.Forms.CheckBox();
			this.tc_Racial.SuspendLayout();
			this.tp_Flags.SuspendLayout();
			this.tp_Feat1.SuspendLayout();
			this.tp_Feat2.SuspendLayout();
			this.tp_Feat3.SuspendLayout();
			this.tp_Feat4.SuspendLayout();
			this.tp_Feat5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tc_Racial
			// 
			this.tc_Racial.Controls.Add(this.tp_Flags);
			this.tc_Racial.Controls.Add(this.tp_Feat1);
			this.tc_Racial.Controls.Add(this.tp_Feat2);
			this.tc_Racial.Controls.Add(this.tp_Feat3);
			this.tc_Racial.Controls.Add(this.tp_Feat4);
			this.tc_Racial.Controls.Add(this.tp_Feat5);
			this.tc_Racial.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tc_Racial.Location = new System.Drawing.Point(0, 0);
			this.tc_Racial.Margin = new System.Windows.Forms.Padding(0);
			this.tc_Racial.Name = "tc_Racial";
			this.tc_Racial.Padding = new System.Drawing.Point(0, 0);
			this.tc_Racial.SelectedIndex = 0;
			this.tc_Racial.Size = new System.Drawing.Size(527, 159);
			this.tc_Racial.TabIndex = 0;
			// 
			// tp_Flags
			// 
			this.tp_Flags.BackColor = System.Drawing.Color.OldLace;
			this.tp_Flags.Controls.Add(this.RacialFlags_reset);
			this.tp_Flags.Controls.Add(this.RacialFlags_text);
			this.tp_Flags.Controls.Add(this.RacialFlags_hex);
			this.tp_Flags.Controls.Add(this.RacialFlags_bin);
			this.tp_Flags.Controls.Add(this.rf_Clear);
			this.tp_Flags.Controls.Add(this.rf_hex);
			this.tp_Flags.Controls.Add(this.rf_bin);
			this.tp_Flags.Controls.Add(this.rf_HasFeatSpells);
			this.tp_Flags.Location = new System.Drawing.Point(4, 22);
			this.tp_Flags.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Flags.Name = "tp_Flags";
			this.tp_Flags.Size = new System.Drawing.Size(519, 133);
			this.tp_Flags.TabIndex = 0;
			this.tp_Flags.Text = "flags";
			// 
			// RacialFlags_reset
			// 
			this.RacialFlags_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFlags_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_reset.Name = "RacialFlags_reset";
			this.RacialFlags_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFlags_reset.TabIndex = 0;
			this.RacialFlags_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFlags_text
			// 
			this.RacialFlags_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFlags_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFlags_text.Name = "RacialFlags_text";
			this.RacialFlags_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFlags_text.TabIndex = 1;
			this.RacialFlags_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFlags_hex.TabIndex = 2;
			this.RacialFlags_hex.TabStop = false;
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
			this.RacialFlags_bin.TabIndex = 3;
			this.RacialFlags_bin.TabStop = false;
			// 
			// rf_Clear
			// 
			this.rf_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf_Clear.Name = "rf_Clear";
			this.rf_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf_Clear.TabIndex = 4;
			this.rf_Clear.Text = "zero\r\nall\r\nbits";
			this.rf_Clear.UseVisualStyleBackColor = true;
			// 
			// rf_hex
			// 
			this.rf_hex.Location = new System.Drawing.Point(400, 15);
			this.rf_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf_hex.Name = "rf_hex";
			this.rf_hex.Size = new System.Drawing.Size(40, 15);
			this.rf_hex.TabIndex = 5;
			this.rf_hex.Text = "hex";
			this.rf_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf_bin
			// 
			this.rf_bin.Location = new System.Drawing.Point(400, 35);
			this.rf_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf_bin.Name = "rf_bin";
			this.rf_bin.Size = new System.Drawing.Size(40, 15);
			this.rf_bin.TabIndex = 6;
			this.rf_bin.Text = "bin";
			this.rf_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf_HasFeatSpells
			// 
			this.rf_HasFeatSpells.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf_HasFeatSpells.Location = new System.Drawing.Point(15, 110);
			this.rf_HasFeatSpells.Margin = new System.Windows.Forms.Padding(0);
			this.rf_HasFeatSpells.Name = "rf_HasFeatSpells";
			this.rf_HasFeatSpells.Size = new System.Drawing.Size(80, 20);
			this.rf_HasFeatSpells.TabIndex = 7;
			this.rf_HasFeatSpells.Text = "has Feats";
			this.rf_HasFeatSpells.UseVisualStyleBackColor = true;
			// 
			// tp_Feat1
			// 
			this.tp_Feat1.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat1.Controls.Add(this.RacialFeat1_reset);
			this.tp_Feat1.Controls.Add(this.RacialFeat1_text);
			this.tp_Feat1.Controls.Add(this.RacialFeat1_hex);
			this.tp_Feat1.Controls.Add(this.RacialFeat1_bin);
			this.tp_Feat1.Controls.Add(this.rf1_Clear);
			this.tp_Feat1.Controls.Add(this.rf1_hex);
			this.tp_Feat1.Controls.Add(this.rf1_bin);
			this.tp_Feat1.Controls.Add(this.rf1_featId_label);
			this.tp_Feat1.Controls.Add(this.rf1_FeatId);
			this.tp_Feat1.Controls.Add(this.rf1_FeatLabel);
			this.tp_Feat1.Controls.Add(this.rf1_spellId_label);
			this.tp_Feat1.Controls.Add(this.rf1_SpellId);
			this.tp_Feat1.Controls.Add(this.rf1_SpellLabel);
			this.tp_Feat1.Controls.Add(this.rf1_cheatCast);
			this.tp_Feat1.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat1.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat1.Name = "tp_Feat1";
			this.tp_Feat1.Size = new System.Drawing.Size(519, 133);
			this.tp_Feat1.TabIndex = 1;
			this.tp_Feat1.Text = "feat1";
			// 
			// RacialFeat1_reset
			// 
			this.RacialFeat1_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat1_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_reset.Name = "RacialFeat1_reset";
			this.RacialFeat1_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat1_reset.TabIndex = 0;
			this.RacialFeat1_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFeat1_text
			// 
			this.RacialFeat1_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat1_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat1_text.Name = "RacialFeat1_text";
			this.RacialFeat1_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat1_text.TabIndex = 1;
			this.RacialFeat1_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFeat1_hex.TabIndex = 2;
			this.RacialFeat1_hex.TabStop = false;
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
			this.RacialFeat1_bin.TabIndex = 3;
			this.RacialFeat1_bin.TabStop = false;
			// 
			// rf1_Clear
			// 
			this.rf1_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf1_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_Clear.Name = "rf1_Clear";
			this.rf1_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf1_Clear.TabIndex = 4;
			this.rf1_Clear.Text = "zero\r\nall\r\nbits";
			this.rf1_Clear.UseVisualStyleBackColor = true;
			// 
			// rf1_hex
			// 
			this.rf1_hex.Location = new System.Drawing.Point(400, 15);
			this.rf1_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_hex.Name = "rf1_hex";
			this.rf1_hex.Size = new System.Drawing.Size(40, 15);
			this.rf1_hex.TabIndex = 5;
			this.rf1_hex.Text = "hex";
			this.rf1_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_bin
			// 
			this.rf1_bin.Location = new System.Drawing.Point(400, 35);
			this.rf1_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_bin.Name = "rf1_bin";
			this.rf1_bin.Size = new System.Drawing.Size(40, 15);
			this.rf1_bin.TabIndex = 6;
			this.rf1_bin.Text = "bin";
			this.rf1_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_featId_label
			// 
			this.rf1_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf1_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_featId_label.Name = "rf1_featId_label";
			this.rf1_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf1_featId_label.TabIndex = 7;
			this.rf1_featId_label.Text = "ID Feat";
			this.rf1_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_FeatId
			// 
			this.rf1_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf1_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_FeatId.Name = "rf1_FeatId";
			this.rf1_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf1_FeatId.TabIndex = 8;
			// 
			// rf1_FeatLabel
			// 
			this.rf1_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.rf1_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_FeatLabel.Name = "rf1_FeatLabel";
			this.rf1_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.rf1_FeatLabel.TabIndex = 9;
			this.rf1_FeatLabel.Text = "rf1_FeatLabel";
			this.rf1_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_spellId_label
			// 
			this.rf1_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf1_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_spellId_label.Name = "rf1_spellId_label";
			this.rf1_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf1_spellId_label.TabIndex = 10;
			this.rf1_spellId_label.Text = "ID Spell";
			this.rf1_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_SpellId
			// 
			this.rf1_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf1_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_SpellId.Name = "rf1_SpellId";
			this.rf1_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf1_SpellId.TabIndex = 11;
			// 
			// rf1_SpellLabel
			// 
			this.rf1_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.rf1_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_SpellLabel.Name = "rf1_SpellLabel";
			this.rf1_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.rf1_SpellLabel.TabIndex = 12;
			this.rf1_SpellLabel.Text = "rf1_SpellLabel";
			this.rf1_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf1_cheatCast
			// 
			this.rf1_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf1_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf1_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.rf1_cheatCast.Name = "rf1_cheatCast";
			this.rf1_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.rf1_cheatCast.TabIndex = 13;
			this.rf1_cheatCast.Text = "cheat cast";
			this.rf1_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat2
			// 
			this.tp_Feat2.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat2.Controls.Add(this.RacialFeat2_reset);
			this.tp_Feat2.Controls.Add(this.RacialFeat2_text);
			this.tp_Feat2.Controls.Add(this.RacialFeat2_hex);
			this.tp_Feat2.Controls.Add(this.RacialFeat2_bin);
			this.tp_Feat2.Controls.Add(this.rf2_Clear);
			this.tp_Feat2.Controls.Add(this.rf2_hex);
			this.tp_Feat2.Controls.Add(this.rf2_bin);
			this.tp_Feat2.Controls.Add(this.rf2_featId_label);
			this.tp_Feat2.Controls.Add(this.rf2_FeatId);
			this.tp_Feat2.Controls.Add(this.rf2_FeatLabel);
			this.tp_Feat2.Controls.Add(this.rf2_spellId_label);
			this.tp_Feat2.Controls.Add(this.rf2_SpellId);
			this.tp_Feat2.Controls.Add(this.rf2_SpellLabel);
			this.tp_Feat2.Controls.Add(this.rf2_cheatCast);
			this.tp_Feat2.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat2.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat2.Name = "tp_Feat2";
			this.tp_Feat2.Size = new System.Drawing.Size(519, 133);
			this.tp_Feat2.TabIndex = 2;
			this.tp_Feat2.Text = "feat2";
			// 
			// RacialFeat2_reset
			// 
			this.RacialFeat2_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat2_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_reset.Name = "RacialFeat2_reset";
			this.RacialFeat2_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat2_reset.TabIndex = 0;
			this.RacialFeat2_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFeat2_text
			// 
			this.RacialFeat2_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat2_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat2_text.Name = "RacialFeat2_text";
			this.RacialFeat2_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat2_text.TabIndex = 1;
			this.RacialFeat2_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFeat2_hex.TabIndex = 2;
			this.RacialFeat2_hex.TabStop = false;
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
			this.RacialFeat2_bin.TabIndex = 3;
			this.RacialFeat2_bin.TabStop = false;
			// 
			// rf2_Clear
			// 
			this.rf2_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf2_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_Clear.Name = "rf2_Clear";
			this.rf2_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf2_Clear.TabIndex = 4;
			this.rf2_Clear.Text = "zero\r\nall\r\nbits";
			this.rf2_Clear.UseVisualStyleBackColor = true;
			// 
			// rf2_hex
			// 
			this.rf2_hex.Location = new System.Drawing.Point(400, 15);
			this.rf2_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_hex.Name = "rf2_hex";
			this.rf2_hex.Size = new System.Drawing.Size(40, 15);
			this.rf2_hex.TabIndex = 5;
			this.rf2_hex.Text = "hex";
			this.rf2_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_bin
			// 
			this.rf2_bin.Location = new System.Drawing.Point(400, 35);
			this.rf2_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_bin.Name = "rf2_bin";
			this.rf2_bin.Size = new System.Drawing.Size(40, 15);
			this.rf2_bin.TabIndex = 6;
			this.rf2_bin.Text = "bin";
			this.rf2_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_featId_label
			// 
			this.rf2_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf2_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_featId_label.Name = "rf2_featId_label";
			this.rf2_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf2_featId_label.TabIndex = 7;
			this.rf2_featId_label.Text = "ID Feat";
			this.rf2_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_FeatId
			// 
			this.rf2_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf2_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_FeatId.Name = "rf2_FeatId";
			this.rf2_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf2_FeatId.TabIndex = 8;
			// 
			// rf2_FeatLabel
			// 
			this.rf2_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.rf2_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_FeatLabel.Name = "rf2_FeatLabel";
			this.rf2_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.rf2_FeatLabel.TabIndex = 9;
			this.rf2_FeatLabel.Text = "rf2_FeatLabel";
			this.rf2_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_spellId_label
			// 
			this.rf2_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf2_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_spellId_label.Name = "rf2_spellId_label";
			this.rf2_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf2_spellId_label.TabIndex = 10;
			this.rf2_spellId_label.Text = "ID Spell";
			this.rf2_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_SpellId
			// 
			this.rf2_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf2_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_SpellId.Name = "rf2_SpellId";
			this.rf2_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf2_SpellId.TabIndex = 11;
			// 
			// rf2_SpellLabel
			// 
			this.rf2_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.rf2_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_SpellLabel.Name = "rf2_SpellLabel";
			this.rf2_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.rf2_SpellLabel.TabIndex = 12;
			this.rf2_SpellLabel.Text = "rf2_SpellLabel";
			this.rf2_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf2_cheatCast
			// 
			this.rf2_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf2_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf2_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.rf2_cheatCast.Name = "rf2_cheatCast";
			this.rf2_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.rf2_cheatCast.TabIndex = 13;
			this.rf2_cheatCast.Text = "cheat cast";
			this.rf2_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat3
			// 
			this.tp_Feat3.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat3.Controls.Add(this.RacialFeat3_reset);
			this.tp_Feat3.Controls.Add(this.RacialFeat3_text);
			this.tp_Feat3.Controls.Add(this.RacialFeat3_hex);
			this.tp_Feat3.Controls.Add(this.RacialFeat3_bin);
			this.tp_Feat3.Controls.Add(this.rf3_Clear);
			this.tp_Feat3.Controls.Add(this.rf3_hex);
			this.tp_Feat3.Controls.Add(this.rf3_bin);
			this.tp_Feat3.Controls.Add(this.rf3_featId_label);
			this.tp_Feat3.Controls.Add(this.rf3_FeatId);
			this.tp_Feat3.Controls.Add(this.rf3_FeatLabel);
			this.tp_Feat3.Controls.Add(this.rf3_spellId_label);
			this.tp_Feat3.Controls.Add(this.rf3_SpellId);
			this.tp_Feat3.Controls.Add(this.rf3_SpellLabel);
			this.tp_Feat3.Controls.Add(this.rf3_cheatCast);
			this.tp_Feat3.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat3.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat3.Name = "tp_Feat3";
			this.tp_Feat3.Size = new System.Drawing.Size(519, 133);
			this.tp_Feat3.TabIndex = 3;
			this.tp_Feat3.Text = "feat3";
			// 
			// RacialFeat3_reset
			// 
			this.RacialFeat3_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat3_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_reset.Name = "RacialFeat3_reset";
			this.RacialFeat3_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat3_reset.TabIndex = 0;
			this.RacialFeat3_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFeat3_text
			// 
			this.RacialFeat3_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat3_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat3_text.Name = "RacialFeat3_text";
			this.RacialFeat3_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat3_text.TabIndex = 1;
			this.RacialFeat3_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFeat3_hex.TabIndex = 2;
			this.RacialFeat3_hex.TabStop = false;
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
			this.RacialFeat3_bin.TabIndex = 3;
			this.RacialFeat3_bin.TabStop = false;
			// 
			// rf3_Clear
			// 
			this.rf3_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf3_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_Clear.Name = "rf3_Clear";
			this.rf3_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf3_Clear.TabIndex = 4;
			this.rf3_Clear.Text = "zero\r\nall\r\nbits";
			this.rf3_Clear.UseVisualStyleBackColor = true;
			// 
			// rf3_hex
			// 
			this.rf3_hex.Location = new System.Drawing.Point(400, 15);
			this.rf3_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_hex.Name = "rf3_hex";
			this.rf3_hex.Size = new System.Drawing.Size(40, 15);
			this.rf3_hex.TabIndex = 5;
			this.rf3_hex.Text = "hex";
			this.rf3_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_bin
			// 
			this.rf3_bin.Location = new System.Drawing.Point(400, 35);
			this.rf3_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_bin.Name = "rf3_bin";
			this.rf3_bin.Size = new System.Drawing.Size(40, 15);
			this.rf3_bin.TabIndex = 6;
			this.rf3_bin.Text = "bin";
			this.rf3_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_featId_label
			// 
			this.rf3_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf3_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_featId_label.Name = "rf3_featId_label";
			this.rf3_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf3_featId_label.TabIndex = 7;
			this.rf3_featId_label.Text = "ID Feat";
			this.rf3_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_FeatId
			// 
			this.rf3_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf3_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_FeatId.Name = "rf3_FeatId";
			this.rf3_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf3_FeatId.TabIndex = 8;
			// 
			// rf3_FeatLabel
			// 
			this.rf3_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.rf3_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_FeatLabel.Name = "rf3_FeatLabel";
			this.rf3_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.rf3_FeatLabel.TabIndex = 9;
			this.rf3_FeatLabel.Text = "rf3_FeatLabel";
			this.rf3_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_spellId_label
			// 
			this.rf3_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf3_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_spellId_label.Name = "rf3_spellId_label";
			this.rf3_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf3_spellId_label.TabIndex = 10;
			this.rf3_spellId_label.Text = "ID Spell";
			this.rf3_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_SpellId
			// 
			this.rf3_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf3_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_SpellId.Name = "rf3_SpellId";
			this.rf3_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf3_SpellId.TabIndex = 11;
			// 
			// rf3_SpellLabel
			// 
			this.rf3_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.rf3_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_SpellLabel.Name = "rf3_SpellLabel";
			this.rf3_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.rf3_SpellLabel.TabIndex = 12;
			this.rf3_SpellLabel.Text = "rf3_SpellLabel";
			this.rf3_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf3_cheatCast
			// 
			this.rf3_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf3_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf3_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.rf3_cheatCast.Name = "rf3_cheatCast";
			this.rf3_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.rf3_cheatCast.TabIndex = 13;
			this.rf3_cheatCast.Text = "cheat cast";
			this.rf3_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat4
			// 
			this.tp_Feat4.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat4.Controls.Add(this.RacialFeat4_reset);
			this.tp_Feat4.Controls.Add(this.RacialFeat4_text);
			this.tp_Feat4.Controls.Add(this.RacialFeat4_hex);
			this.tp_Feat4.Controls.Add(this.RacialFeat4_bin);
			this.tp_Feat4.Controls.Add(this.rf4_Clear);
			this.tp_Feat4.Controls.Add(this.rf4_hex);
			this.tp_Feat4.Controls.Add(this.rf4_bin);
			this.tp_Feat4.Controls.Add(this.rf4_featId_label);
			this.tp_Feat4.Controls.Add(this.rf4_FeatId);
			this.tp_Feat4.Controls.Add(this.rf4_FeatLabel);
			this.tp_Feat4.Controls.Add(this.rf4_spellId_label);
			this.tp_Feat4.Controls.Add(this.rf4_SpellId);
			this.tp_Feat4.Controls.Add(this.rf4_SpellLabel);
			this.tp_Feat4.Controls.Add(this.rf4_cheatCast);
			this.tp_Feat4.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat4.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat4.Name = "tp_Feat4";
			this.tp_Feat4.Size = new System.Drawing.Size(519, 133);
			this.tp_Feat4.TabIndex = 4;
			this.tp_Feat4.Text = "feat4";
			// 
			// RacialFeat4_reset
			// 
			this.RacialFeat4_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat4_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_reset.Name = "RacialFeat4_reset";
			this.RacialFeat4_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat4_reset.TabIndex = 0;
			this.RacialFeat4_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFeat4_text
			// 
			this.RacialFeat4_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat4_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat4_text.Name = "RacialFeat4_text";
			this.RacialFeat4_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat4_text.TabIndex = 1;
			this.RacialFeat4_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFeat4_hex.TabIndex = 2;
			this.RacialFeat4_hex.TabStop = false;
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
			this.RacialFeat4_bin.TabIndex = 3;
			this.RacialFeat4_bin.TabStop = false;
			// 
			// rf4_Clear
			// 
			this.rf4_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf4_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_Clear.Name = "rf4_Clear";
			this.rf4_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf4_Clear.TabIndex = 4;
			this.rf4_Clear.Text = "zero\r\nall\r\nbits";
			this.rf4_Clear.UseVisualStyleBackColor = true;
			// 
			// rf4_hex
			// 
			this.rf4_hex.Location = new System.Drawing.Point(400, 15);
			this.rf4_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_hex.Name = "rf4_hex";
			this.rf4_hex.Size = new System.Drawing.Size(40, 15);
			this.rf4_hex.TabIndex = 5;
			this.rf4_hex.Text = "hex";
			this.rf4_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_bin
			// 
			this.rf4_bin.Location = new System.Drawing.Point(400, 35);
			this.rf4_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_bin.Name = "rf4_bin";
			this.rf4_bin.Size = new System.Drawing.Size(40, 15);
			this.rf4_bin.TabIndex = 6;
			this.rf4_bin.Text = "bin";
			this.rf4_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_featId_label
			// 
			this.rf4_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf4_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_featId_label.Name = "rf4_featId_label";
			this.rf4_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf4_featId_label.TabIndex = 7;
			this.rf4_featId_label.Text = "ID Feat";
			this.rf4_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_FeatId
			// 
			this.rf4_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf4_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_FeatId.Name = "rf4_FeatId";
			this.rf4_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf4_FeatId.TabIndex = 8;
			// 
			// rf4_FeatLabel
			// 
			this.rf4_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.rf4_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_FeatLabel.Name = "rf4_FeatLabel";
			this.rf4_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.rf4_FeatLabel.TabIndex = 9;
			this.rf4_FeatLabel.Text = "rf4_FeatLabel";
			this.rf4_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_spellId_label
			// 
			this.rf4_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf4_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_spellId_label.Name = "rf4_spellId_label";
			this.rf4_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf4_spellId_label.TabIndex = 10;
			this.rf4_spellId_label.Text = "ID Spell";
			this.rf4_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_SpellId
			// 
			this.rf4_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf4_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_SpellId.Name = "rf4_SpellId";
			this.rf4_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf4_SpellId.TabIndex = 11;
			// 
			// rf4_SpellLabel
			// 
			this.rf4_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.rf4_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_SpellLabel.Name = "rf4_SpellLabel";
			this.rf4_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.rf4_SpellLabel.TabIndex = 12;
			this.rf4_SpellLabel.Text = "rf4_SpellLabel";
			this.rf4_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf4_cheatCast
			// 
			this.rf4_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf4_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf4_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.rf4_cheatCast.Name = "rf4_cheatCast";
			this.rf4_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.rf4_cheatCast.TabIndex = 13;
			this.rf4_cheatCast.Text = "cheat cast";
			this.rf4_cheatCast.UseVisualStyleBackColor = true;
			// 
			// tp_Feat5
			// 
			this.tp_Feat5.BackColor = System.Drawing.Color.OldLace;
			this.tp_Feat5.Controls.Add(this.RacialFeat5_reset);
			this.tp_Feat5.Controls.Add(this.RacialFeat5_text);
			this.tp_Feat5.Controls.Add(this.RacialFeat5_hex);
			this.tp_Feat5.Controls.Add(this.RacialFeat5_bin);
			this.tp_Feat5.Controls.Add(this.rf5_Clear);
			this.tp_Feat5.Controls.Add(this.rf5_hex);
			this.tp_Feat5.Controls.Add(this.rf5_bin);
			this.tp_Feat5.Controls.Add(this.rf5_featId_label);
			this.tp_Feat5.Controls.Add(this.rf5_FeatId);
			this.tp_Feat5.Controls.Add(this.rf5_FeatLabel);
			this.tp_Feat5.Controls.Add(this.rf5_spellId_label);
			this.tp_Feat5.Controls.Add(this.rf5_SpellId);
			this.tp_Feat5.Controls.Add(this.rf5_SpellLabel);
			this.tp_Feat5.Controls.Add(this.rf5_cheatCast);
			this.tp_Feat5.Location = new System.Drawing.Point(4, 22);
			this.tp_Feat5.Margin = new System.Windows.Forms.Padding(0);
			this.tp_Feat5.Name = "tp_Feat5";
			this.tp_Feat5.Size = new System.Drawing.Size(519, 133);
			this.tp_Feat5.TabIndex = 5;
			this.tp_Feat5.Text = "feat5";
			// 
			// RacialFeat5_reset
			// 
			this.RacialFeat5_reset.Location = new System.Drawing.Point(5, 5);
			this.RacialFeat5_reset.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_reset.Name = "RacialFeat5_reset";
			this.RacialFeat5_reset.Size = new System.Drawing.Size(100, 25);
			this.RacialFeat5_reset.TabIndex = 0;
			this.RacialFeat5_reset.UseVisualStyleBackColor = true;
			// 
			// RacialFeat5_text
			// 
			this.RacialFeat5_text.Location = new System.Drawing.Point(5, 35);
			this.RacialFeat5_text.Margin = new System.Windows.Forms.Padding(0);
			this.RacialFeat5_text.Name = "RacialFeat5_text";
			this.RacialFeat5_text.Size = new System.Drawing.Size(100, 20);
			this.RacialFeat5_text.TabIndex = 1;
			this.RacialFeat5_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
			this.RacialFeat5_hex.TabIndex = 2;
			this.RacialFeat5_hex.TabStop = false;
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
			this.RacialFeat5_bin.TabIndex = 3;
			this.RacialFeat5_bin.TabStop = false;
			// 
			// rf5_Clear
			// 
			this.rf5_Clear.Location = new System.Drawing.Point(450, 5);
			this.rf5_Clear.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_Clear.Name = "rf5_Clear";
			this.rf5_Clear.Size = new System.Drawing.Size(65, 50);
			this.rf5_Clear.TabIndex = 4;
			this.rf5_Clear.Text = "zero\r\nall\r\nbits";
			this.rf5_Clear.UseVisualStyleBackColor = true;
			// 
			// rf5_hex
			// 
			this.rf5_hex.Location = new System.Drawing.Point(400, 15);
			this.rf5_hex.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_hex.Name = "rf5_hex";
			this.rf5_hex.Size = new System.Drawing.Size(40, 15);
			this.rf5_hex.TabIndex = 5;
			this.rf5_hex.Text = "hex";
			this.rf5_hex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_bin
			// 
			this.rf5_bin.Location = new System.Drawing.Point(400, 35);
			this.rf5_bin.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_bin.Name = "rf5_bin";
			this.rf5_bin.Size = new System.Drawing.Size(40, 15);
			this.rf5_bin.TabIndex = 6;
			this.rf5_bin.Text = "bin";
			this.rf5_bin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_featId_label
			// 
			this.rf5_featId_label.Location = new System.Drawing.Point(10, 65);
			this.rf5_featId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_featId_label.Name = "rf5_featId_label";
			this.rf5_featId_label.Size = new System.Drawing.Size(65, 15);
			this.rf5_featId_label.TabIndex = 7;
			this.rf5_featId_label.Text = "ID Feat";
			this.rf5_featId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_FeatId
			// 
			this.rf5_FeatId.Location = new System.Drawing.Point(80, 60);
			this.rf5_FeatId.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_FeatId.Name = "rf5_FeatId";
			this.rf5_FeatId.Size = new System.Drawing.Size(90, 20);
			this.rf5_FeatId.TabIndex = 8;
			// 
			// rf5_FeatLabel
			// 
			this.rf5_FeatLabel.Location = new System.Drawing.Point(175, 65);
			this.rf5_FeatLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_FeatLabel.Name = "rf5_FeatLabel";
			this.rf5_FeatLabel.Size = new System.Drawing.Size(340, 15);
			this.rf5_FeatLabel.TabIndex = 9;
			this.rf5_FeatLabel.Text = "rf5_FeatLabel";
			this.rf5_FeatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_spellId_label
			// 
			this.rf5_spellId_label.Location = new System.Drawing.Point(10, 85);
			this.rf5_spellId_label.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_spellId_label.Name = "rf5_spellId_label";
			this.rf5_spellId_label.Size = new System.Drawing.Size(65, 15);
			this.rf5_spellId_label.TabIndex = 10;
			this.rf5_spellId_label.Text = "ID Spell";
			this.rf5_spellId_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_SpellId
			// 
			this.rf5_SpellId.Location = new System.Drawing.Point(80, 80);
			this.rf5_SpellId.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_SpellId.Name = "rf5_SpellId";
			this.rf5_SpellId.Size = new System.Drawing.Size(90, 20);
			this.rf5_SpellId.TabIndex = 11;
			// 
			// rf5_SpellLabel
			// 
			this.rf5_SpellLabel.Location = new System.Drawing.Point(175, 85);
			this.rf5_SpellLabel.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_SpellLabel.Name = "rf5_SpellLabel";
			this.rf5_SpellLabel.Size = new System.Drawing.Size(340, 15);
			this.rf5_SpellLabel.TabIndex = 12;
			this.rf5_SpellLabel.Text = "rf5_SpellLabel";
			this.rf5_SpellLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// rf5_cheatCast
			// 
			this.rf5_cheatCast.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
			this.rf5_cheatCast.Location = new System.Drawing.Point(15, 110);
			this.rf5_cheatCast.Margin = new System.Windows.Forms.Padding(0);
			this.rf5_cheatCast.Name = "rf5_cheatCast";
			this.rf5_cheatCast.Size = new System.Drawing.Size(90, 20);
			this.rf5_cheatCast.TabIndex = 13;
			this.rf5_cheatCast.Text = "cheat cast";
			this.rf5_cheatCast.UseVisualStyleBackColor = true;
			// 
			// control_Racial
			// 
			this.Controls.Add(this.tc_Racial);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "control_Racial";
			this.Size = new System.Drawing.Size(527, 159);
			this.tc_Racial.ResumeLayout(false);
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
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
