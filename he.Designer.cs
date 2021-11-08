using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class he
	{
		Button bu_Script;

		/// <summary>
		/// Creates and initializes a <c>Button</c> to show a spell's script.
		/// </summary>
		void CreateScript_button()
		{
			bu_Script = new Button();

			bu_Script.Text = "script";
			bu_Script.Font = new Font("Courier New", 7f);

			bu_Script.Name     = "bu_Script";
			bu_Script.TabIndex = 2;

			bu_Script.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			bu_Script.UseVisualStyleBackColor = true;

			bu_Script.Location = new Point(ClientSize.Width - 60,0);
			bu_Script.Size     = new Size(60,20);
			bu_Script.Margin   = new Padding(0);

			bu_Script.MouseClick += click_Script;

			Controls.Add(bu_Script);

			bu_Script.BringToFront();
		}

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();

			base.Dispose(disposing);
		}


		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		IContainer components;

		MenuStrip menubar;
		ToolStripMenuItem tsmi_file;
		ToolStripMenuItem it_Open;
		ToolStripMenuItem it_Recent;
		ToolStripSeparator toolStripSeparator1;
		ToolStripMenuItem it_Save;
		ToolStripMenuItem it_Saveas;
		ToolStripSeparator toolStripSeparator2;
		ToolStripMenuItem it_Quit;
		ToolStripMenuItem tsmi_edit;
		ToolStripMenuItem it_ApplyGlobal;
		ToolStripSeparator toolStripSeparator5;
		ToolStripMenuItem it_GotoChanged;
		ToolStripSeparator toolStripSeparator3;
		ToolStripMenuItem it_Copy_dec;
		ToolStripMenuItem it_Copy_hex;
		ToolStripMenuItem it_Copy_bin;
		ToolStripSeparator toolStripSeparator6;
		ToolStripMenuItem it_ClearCoreAI;
		ToolStripMenuItem tsmi_edition;
		ToolStripMenuItem it_Edition_stock;
		ToolStripMenuItem it_Edition_tony22;
		ToolStripMenuItem it_Edition_tony25;
		ToolStripSeparator toolStripSeparator7;
		ToolStripMenuItem it_Edition_convert;
		ToolStripMenuItem tsmi_labels;
		ToolStripMenuItem it_pathSpells;
		ToolStripMenuItem it_pathRacialSubtypes;
		ToolStripMenuItem it_pathClasses;
		ToolStripMenuItem it_pathFeat;
		ToolStripSeparator toolStripSeparator4;
		ToolStripMenuItem it_insertSpellLabels;
		ToolStripMenuItem it_insertRaceLabels;
		ToolStripMenuItem it_insertClassLabels;
		ToolStripMenuItem tsmi_help;
		ToolStripMenuItem it_About;

		SplitContainer splitContainer;

		CompositedTreeView Tree;
		ContextMenuStrip treeMenu;
		ToolStripMenuItem tree_Highlight;

		Panel panel1_top;
		TextBox tb_Search;
		Button bu_Search_d;
		Button bu_Search_u;

		Button bu_Apply;


		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menubar = new System.Windows.Forms.MenuStrip();
			this.tsmi_file = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Open = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Recent = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.it_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Saveas = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.it_Quit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_edit = new System.Windows.Forms.ToolStripMenuItem();
			this.it_ApplyGlobal = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.it_GotoChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.it_Copy_dec = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Copy_hex = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Copy_bin = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.it_ClearCoreAI = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_edition = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Edition_stock = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Edition_tony22 = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Edition_tony25 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.it_Edition_convert = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_labels = new System.Windows.Forms.ToolStripMenuItem();
			this.it_pathSpells = new System.Windows.Forms.ToolStripMenuItem();
			this.it_pathRacialSubtypes = new System.Windows.Forms.ToolStripMenuItem();
			this.it_pathClasses = new System.Windows.Forms.ToolStripMenuItem();
			this.it_pathFeat = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.it_insertSpellLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.it_insertRaceLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.it_insertClassLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_help = new System.Windows.Forms.ToolStripMenuItem();
			this.it_About = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.Tree = new nwn2_ai_2da_editor.CompositedTreeView();
			this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tree_Highlight = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1_top = new System.Windows.Forms.Panel();
			this.tb_Search = new System.Windows.Forms.TextBox();
			this.bu_Search_d = new System.Windows.Forms.Button();
			this.bu_Search_u = new System.Windows.Forms.Button();
			this.bu_Apply = new System.Windows.Forms.Button();
			this.menubar.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.treeMenu.SuspendLayout();
			this.panel1_top.SuspendLayout();
			this.SuspendLayout();
			// 
			// menubar
			// 
			this.menubar.GripMargin = new System.Windows.Forms.Padding(0);
			this.menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsmi_file,
			this.tsmi_edit,
			this.tsmi_edition,
			this.tsmi_labels,
			this.tsmi_help});
			this.menubar.Location = new System.Drawing.Point(0, 0);
			this.menubar.Name = "menubar";
			this.menubar.Padding = new System.Windows.Forms.Padding(0);
			this.menubar.Size = new System.Drawing.Size(792, 24);
			this.menubar.TabIndex = 0;
			this.menubar.Text = "menubar";
			// 
			// tsmi_file
			// 
			this.tsmi_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_Open,
			this.it_Recent,
			this.toolStripSeparator1,
			this.it_Save,
			this.it_Saveas,
			this.toolStripSeparator2,
			this.it_Quit});
			this.tsmi_file.Name = "tsmi_file";
			this.tsmi_file.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tsmi_file.Size = new System.Drawing.Size(35, 24);
			this.tsmi_file.Text = "&File";
			this.tsmi_file.DropDownOpening += new System.EventHandler(this.dropdownopening_File);
			// 
			// it_Open
			// 
			this.it_Open.Name = "it_Open";
			this.it_Open.Padding = new System.Windows.Forms.Padding(0);
			this.it_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.it_Open.Size = new System.Drawing.Size(160, 20);
			this.it_Open.Text = "&Open ...";
			this.it_Open.Click += new System.EventHandler(this.Click_open);
			// 
			// it_Recent
			// 
			this.it_Recent.Name = "it_Recent";
			this.it_Recent.Padding = new System.Windows.Forms.Padding(0);
			this.it_Recent.Size = new System.Drawing.Size(160, 20);
			this.it_Recent.Text = "&Recent";
			this.it_Recent.DropDownOpening += new System.EventHandler(this.dropdownopening_Recent);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
			// 
			// it_Save
			// 
			this.it_Save.Enabled = false;
			this.it_Save.Name = "it_Save";
			this.it_Save.Padding = new System.Windows.Forms.Padding(0);
			this.it_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.it_Save.Size = new System.Drawing.Size(160, 20);
			this.it_Save.Text = "&Save";
			this.it_Save.Click += new System.EventHandler(this.Click_save);
			// 
			// it_Saveas
			// 
			this.it_Saveas.Enabled = false;
			this.it_Saveas.Name = "it_Saveas";
			this.it_Saveas.Padding = new System.Windows.Forms.Padding(0);
			this.it_Saveas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.it_Saveas.Size = new System.Drawing.Size(160, 20);
			this.it_Saveas.Text = "Sav&e As ...";
			this.it_Saveas.Click += new System.EventHandler(this.Click_saveas);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
			// 
			// it_Quit
			// 
			this.it_Quit.Name = "it_Quit";
			this.it_Quit.Padding = new System.Windows.Forms.Padding(0);
			this.it_Quit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.it_Quit.Size = new System.Drawing.Size(160, 20);
			this.it_Quit.Text = "&Quit";
			this.it_Quit.Click += new System.EventHandler(this.Click_quit);
			// 
			// tsmi_edit
			// 
			this.tsmi_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_ApplyGlobal,
			this.toolStripSeparator5,
			this.it_GotoChanged,
			this.toolStripSeparator3,
			this.it_Copy_dec,
			this.it_Copy_hex,
			this.it_Copy_bin,
			this.toolStripSeparator6,
			this.it_ClearCoreAI});
			this.tsmi_edit.Name = "tsmi_edit";
			this.tsmi_edit.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tsmi_edit.Size = new System.Drawing.Size(35, 24);
			this.tsmi_edit.Text = "&Edit";
			// 
			// it_ApplyGlobal
			// 
			this.it_ApplyGlobal.Enabled = false;
			this.it_ApplyGlobal.Name = "it_ApplyGlobal";
			this.it_ApplyGlobal.Padding = new System.Windows.Forms.Padding(0);
			this.it_ApplyGlobal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
			this.it_ApplyGlobal.Size = new System.Drawing.Size(190, 20);
			this.it_ApplyGlobal.Text = "global &Apply";
			this.it_ApplyGlobal.Click += new System.EventHandler(this.Click_applyGlobal);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
			// 
			// it_GotoChanged
			// 
			this.it_GotoChanged.Enabled = false;
			this.it_GotoChanged.Name = "it_GotoChanged";
			this.it_GotoChanged.Padding = new System.Windows.Forms.Padding(0);
			this.it_GotoChanged.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.it_GotoChanged.Size = new System.Drawing.Size(190, 20);
			this.it_GotoChanged.Text = "goto &next changed";
			this.it_GotoChanged.Click += new System.EventHandler(this.Click_gotonextchanged);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
			// 
			// it_Copy_dec
			// 
			this.it_Copy_dec.Enabled = false;
			this.it_Copy_dec.Name = "it_Copy_dec";
			this.it_Copy_dec.Padding = new System.Windows.Forms.Padding(0);
			this.it_Copy_dec.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.it_Copy_dec.Size = new System.Drawing.Size(190, 20);
			this.it_Copy_dec.Text = "Copy &decimal";
			this.it_Copy_dec.Click += new System.EventHandler(this.Click_copy_decimal);
			// 
			// it_Copy_hex
			// 
			this.it_Copy_hex.Enabled = false;
			this.it_Copy_hex.Name = "it_Copy_hex";
			this.it_Copy_hex.Padding = new System.Windows.Forms.Padding(0);
			this.it_Copy_hex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.it_Copy_hex.Size = new System.Drawing.Size(190, 20);
			this.it_Copy_hex.Text = "Copy &hexadecimal";
			this.it_Copy_hex.Click += new System.EventHandler(this.Click_copy_hexadecimal);
			// 
			// it_Copy_bin
			// 
			this.it_Copy_bin.Enabled = false;
			this.it_Copy_bin.Name = "it_Copy_bin";
			this.it_Copy_bin.Padding = new System.Windows.Forms.Padding(0);
			this.it_Copy_bin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.it_Copy_bin.Size = new System.Drawing.Size(190, 20);
			this.it_Copy_bin.Text = "Copy &binary";
			this.it_Copy_bin.Click += new System.EventHandler(this.Click_copy_binary);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(187, 6);
			// 
			// it_ClearCoreAI
			// 
			this.it_ClearCoreAI.Enabled = false;
			this.it_ClearCoreAI.Name = "it_ClearCoreAI";
			this.it_ClearCoreAI.Padding = new System.Windows.Forms.Padding(0);
			this.it_ClearCoreAI.Size = new System.Drawing.Size(190, 20);
			this.it_ClearCoreAI.Text = "Clear CoreA&I version ...";
			this.it_ClearCoreAI.Click += new System.EventHandler(this.Click_clearCoreAiVersion);
			// 
			// tsmi_edition
			// 
			this.tsmi_edition.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_Edition_stock,
			this.it_Edition_tony22,
			this.it_Edition_tony25,
			this.toolStripSeparator7,
			this.it_Edition_convert});
			this.tsmi_edition.Name = "tsmi_edition";
			this.tsmi_edition.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tsmi_edition.Size = new System.Drawing.Size(50, 24);
			this.tsmi_edition.Text = "Edition";
			// 
			// it_Edition_stock
			// 
			this.it_Edition_stock.Name = "it_Edition_stock";
			this.it_Edition_stock.Padding = new System.Windows.Forms.Padding(0);
			this.it_Edition_stock.Size = new System.Drawing.Size(175, 20);
			this.it_Edition_stock.Text = "stock";
			// 
			// it_Edition_tony22
			// 
			this.it_Edition_tony22.Name = "it_Edition_tony22";
			this.it_Edition_tony22.Padding = new System.Windows.Forms.Padding(0);
			this.it_Edition_tony22.Size = new System.Drawing.Size(175, 20);
			this.it_Edition_tony22.Text = "tonyAI 2.2";
			// 
			// it_Edition_tony25
			// 
			this.it_Edition_tony25.Name = "it_Edition_tony25";
			this.it_Edition_tony25.Padding = new System.Windows.Forms.Padding(0);
			this.it_Edition_tony25.Size = new System.Drawing.Size(175, 20);
			this.it_Edition_tony25.Text = "tonyAI 2.5";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(172, 6);
			// 
			// it_Edition_convert
			// 
			this.it_Edition_convert.Name = "it_Edition_convert";
			this.it_Edition_convert.Padding = new System.Windows.Forms.Padding(0);
			this.it_Edition_convert.Size = new System.Drawing.Size(175, 20);
			this.it_Edition_convert.Text = "Convert to tonyAI 2.5";
			// 
			// tsmi_labels
			// 
			this.tsmi_labels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_pathSpells,
			this.it_pathRacialSubtypes,
			this.it_pathClasses,
			this.it_pathFeat,
			this.toolStripSeparator4,
			this.it_insertSpellLabels,
			this.it_insertRaceLabels,
			this.it_insertClassLabels});
			this.tsmi_labels.Name = "tsmi_labels";
			this.tsmi_labels.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tsmi_labels.Size = new System.Drawing.Size(45, 24);
			this.tsmi_labels.Text = "&Labels";
			this.tsmi_labels.DropDownOpening += new System.EventHandler(this.dropdownopening_Labels);
			// 
			// it_pathSpells
			// 
			this.it_pathSpells.Name = "it_pathSpells";
			this.it_pathSpells.Padding = new System.Windows.Forms.Padding(0);
			this.it_pathSpells.Size = new System.Drawing.Size(185, 20);
			this.it_pathSpells.Text = "path &Spells.2da";
			this.it_pathSpells.Click += new System.EventHandler(this.Click_pathSpells);
			// 
			// it_pathRacialSubtypes
			// 
			this.it_pathRacialSubtypes.Name = "it_pathRacialSubtypes";
			this.it_pathRacialSubtypes.Padding = new System.Windows.Forms.Padding(0);
			this.it_pathRacialSubtypes.Size = new System.Drawing.Size(185, 20);
			this.it_pathRacialSubtypes.Text = "path &RacialSubtypes.2da";
			this.it_pathRacialSubtypes.Click += new System.EventHandler(this.Click_pathRacialSubtypes);
			// 
			// it_pathClasses
			// 
			this.it_pathClasses.Name = "it_pathClasses";
			this.it_pathClasses.Padding = new System.Windows.Forms.Padding(0);
			this.it_pathClasses.Size = new System.Drawing.Size(185, 20);
			this.it_pathClasses.Text = "path &Classes.2da";
			this.it_pathClasses.Click += new System.EventHandler(this.Click_pathClasses);
			// 
			// it_pathFeat
			// 
			this.it_pathFeat.Name = "it_pathFeat";
			this.it_pathFeat.Padding = new System.Windows.Forms.Padding(0);
			this.it_pathFeat.Size = new System.Drawing.Size(185, 20);
			this.it_pathFeat.Text = "path &Feat.2da";
			this.it_pathFeat.Click += new System.EventHandler(this.Click_pathFeat);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(182, 6);
			// 
			// it_insertSpellLabels
			// 
			this.it_insertSpellLabels.Enabled = false;
			this.it_insertSpellLabels.Name = "it_insertSpellLabels";
			this.it_insertSpellLabels.Padding = new System.Windows.Forms.Padding(0);
			this.it_insertSpellLabels.Size = new System.Drawing.Size(185, 20);
			this.it_insertSpellLabels.Text = "insert s&pell labels";
			this.it_insertSpellLabels.Click += new System.EventHandler(this.Click_insertSpellLabels);
			// 
			// it_insertRaceLabels
			// 
			this.it_insertRaceLabels.Enabled = false;
			this.it_insertRaceLabels.Name = "it_insertRaceLabels";
			this.it_insertRaceLabels.Padding = new System.Windows.Forms.Padding(0);
			this.it_insertRaceLabels.Size = new System.Drawing.Size(185, 20);
			this.it_insertRaceLabels.Text = "insert r&ace labels";
			this.it_insertRaceLabels.Click += new System.EventHandler(this.Click_insertRaceLabels);
			// 
			// it_insertClassLabels
			// 
			this.it_insertClassLabels.Enabled = false;
			this.it_insertClassLabels.Name = "it_insertClassLabels";
			this.it_insertClassLabels.Padding = new System.Windows.Forms.Padding(0);
			this.it_insertClassLabels.Size = new System.Drawing.Size(185, 20);
			this.it_insertClassLabels.Text = "insert c&lass labels";
			this.it_insertClassLabels.Click += new System.EventHandler(this.Click_insertClassLabels);
			// 
			// tsmi_help
			// 
			this.tsmi_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_About});
			this.tsmi_help.Name = "tsmi_help";
			this.tsmi_help.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
			this.tsmi_help.Size = new System.Drawing.Size(35, 24);
			this.tsmi_help.Text = "&Help";
			// 
			// it_About
			// 
			this.it_About.Name = "it_About";
			this.it_About.Padding = new System.Windows.Forms.Padding(0);
			this.it_About.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.it_About.Size = new System.Drawing.Size(130, 20);
			this.it_About.Text = "&About";
			this.it_About.Click += new System.EventHandler(this.Click_about);
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 24);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.Tree);
			this.splitContainer.Panel1.Controls.Add(this.panel1_top);
			this.splitContainer.Panel1MinSize = 0;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.bu_Apply);
			this.splitContainer.Size = new System.Drawing.Size(792, 430);
			this.splitContainer.SplitterDistance = 275;
			this.splitContainer.SplitterWidth = 3;
			this.splitContainer.TabIndex = 1;
			// 
			// Tree
			// 
			this.Tree.BackColor = System.Drawing.Color.AliceBlue;
			this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Tree.ContextMenuStrip = this.treeMenu;
			this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Tree.FullRowSelect = true;
			this.Tree.HideSelection = false;
			this.Tree.Indent = 15;
			this.Tree.Location = new System.Drawing.Point(0, 20);
			this.Tree.Margin = new System.Windows.Forms.Padding(0);
			this.Tree.Name = "Tree";
			this.Tree.ShowLines = false;
			this.Tree.ShowPlusMinus = false;
			this.Tree.Size = new System.Drawing.Size(275, 410);
			this.Tree.TabIndex = 1;
			this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelect_node);
			this.Tree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_search);
			// 
			// treeMenu
			// 
			this.treeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tree_Highlight});
			this.treeMenu.Name = "treeMenu";
			this.treeMenu.ShowCheckMargin = true;
			this.treeMenu.ShowImageMargin = false;
			this.treeMenu.Size = new System.Drawing.Size(106, 24);
			this.treeMenu.Text = "treeMenu";
			// 
			// tree_Highlight
			// 
			this.tree_Highlight.Name = "tree_Highlight";
			this.tree_Highlight.Padding = new System.Windows.Forms.Padding(0);
			this.tree_Highlight.Size = new System.Drawing.Size(105, 20);
			this.tree_Highlight.Text = "turtles";
			this.tree_Highlight.Visible = false;
			this.tree_Highlight.Click += new System.EventHandler(this.Click_treeHighlight);
			// 
			// panel1_top
			// 
			this.panel1_top.Controls.Add(this.tb_Search);
			this.panel1_top.Controls.Add(this.bu_Search_d);
			this.panel1_top.Controls.Add(this.bu_Search_u);
			this.panel1_top.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1_top.Location = new System.Drawing.Point(0, 0);
			this.panel1_top.Margin = new System.Windows.Forms.Padding(0);
			this.panel1_top.Name = "panel1_top";
			this.panel1_top.Size = new System.Drawing.Size(275, 20);
			this.panel1_top.TabIndex = 0;
			// 
			// tb_Search
			// 
			this.tb_Search.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_Search.Location = new System.Drawing.Point(0, 0);
			this.tb_Search.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Search.Name = "tb_Search";
			this.tb_Search.Size = new System.Drawing.Size(225, 20);
			this.tb_Search.TabIndex = 0;
			this.tb_Search.WordWrap = false;
			this.tb_Search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_search);
			// 
			// bu_Search_d
			// 
			this.bu_Search_d.Dock = System.Windows.Forms.DockStyle.Right;
			this.bu_Search_d.Location = new System.Drawing.Point(225, 0);
			this.bu_Search_d.Margin = new System.Windows.Forms.Padding(0);
			this.bu_Search_d.Name = "bu_Search_d";
			this.bu_Search_d.Size = new System.Drawing.Size(25, 20);
			this.bu_Search_d.TabIndex = 1;
			this.bu_Search_d.Text = "d";
			this.bu_Search_d.UseVisualStyleBackColor = true;
			this.bu_Search_d.Click += new System.EventHandler(this.Click_search);
			// 
			// bu_Search_u
			// 
			this.bu_Search_u.Dock = System.Windows.Forms.DockStyle.Right;
			this.bu_Search_u.Location = new System.Drawing.Point(250, 0);
			this.bu_Search_u.Margin = new System.Windows.Forms.Padding(0);
			this.bu_Search_u.Name = "bu_Search_u";
			this.bu_Search_u.Size = new System.Drawing.Size(25, 20);
			this.bu_Search_u.TabIndex = 2;
			this.bu_Search_u.Text = "u";
			this.bu_Search_u.UseVisualStyleBackColor = true;
			this.bu_Search_u.Click += new System.EventHandler(this.Click_search);
			// 
			// bu_Apply
			// 
			this.bu_Apply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.bu_Apply.Enabled = false;
			this.bu_Apply.Location = new System.Drawing.Point(0, 405);
			this.bu_Apply.Margin = new System.Windows.Forms.Padding(0);
			this.bu_Apply.Name = "bu_Apply";
			this.bu_Apply.Size = new System.Drawing.Size(514, 25);
			this.bu_Apply.TabIndex = 0;
			this.bu_Apply.UseVisualStyleBackColor = true;
			this.bu_Apply.Click += new System.EventHandler(this.Click_apply);
			// 
			// he
			// 
			this.ClientSize = new System.Drawing.Size(792, 454);
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.menubar);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menubar;
			this.Name = "he";
			this.Text = "nwn2_ai_2da_editor";
			this.menubar.ResumeLayout(false);
			this.menubar.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			this.treeMenu.ResumeLayout(false);
			this.panel1_top.ResumeLayout(false);
			this.panel1_top.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
