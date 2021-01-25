using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class he
	{
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
		ToolStripMenuItem Open;
		ToolStripMenuItem it_Recent;
		ToolStripSeparator toolStripSeparator1;
		ToolStripMenuItem Save;
		ToolStripMenuItem Saveas;
		ToolStripSeparator toolStripSeparator2;
		ToolStripMenuItem Quit;
		ToolStripMenuItem tsmi_edit;
		ToolStripMenuItem it_ApplyGlobal;
		ToolStripSeparator toolStripSeparator5;
		ToolStripMenuItem it_GotoChanged;
		ToolStripSeparator toolStripSeparator3;
		ToolStripMenuItem Copy_decimal;
		ToolStripMenuItem Copy_hexadecimal;
		ToolStripMenuItem Copy_binary;
		ToolStripSeparator toolStripSeparator6;
		ToolStripMenuItem clearCoreAIver;
		ToolStripMenuItem tsmi_labels;
		ToolStripMenuItem pathSpells;
		ToolStripMenuItem pathRacialSubtypes;
		ToolStripMenuItem pathClasses;
		ToolStripMenuItem pathFeat;
		ToolStripSeparator toolStripSeparator4;
		ToolStripMenuItem it_insertSpellLabels;
		ToolStripMenuItem it_insertRaceLabels;
		ToolStripMenuItem it_insertClassLabels;
		ToolStripMenuItem tsmi_help;
		ToolStripMenuItem About;

		SplitContainer splitContainer;

		CompositedTreeView Tree;
		ContextMenuStrip treeMenu;
		ToolStripMenuItem tree_Highlight;

		Panel panel1_top;
		TextBox tb_Search;
		Button btn_Search_d;
		Button btn_Search_u;

		Button btn_Apply;


		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menubar = new System.Windows.Forms.MenuStrip();
			this.tsmi_file = new System.Windows.Forms.ToolStripMenuItem();
			this.Open = new System.Windows.Forms.ToolStripMenuItem();
			this.it_Recent = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.Save = new System.Windows.Forms.ToolStripMenuItem();
			this.Saveas = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.Quit = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_edit = new System.Windows.Forms.ToolStripMenuItem();
			this.it_ApplyGlobal = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.it_GotoChanged = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.Copy_decimal = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_hexadecimal = new System.Windows.Forms.ToolStripMenuItem();
			this.Copy_binary = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.clearCoreAIver = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_labels = new System.Windows.Forms.ToolStripMenuItem();
			this.pathSpells = new System.Windows.Forms.ToolStripMenuItem();
			this.pathRacialSubtypes = new System.Windows.Forms.ToolStripMenuItem();
			this.pathClasses = new System.Windows.Forms.ToolStripMenuItem();
			this.pathFeat = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.it_insertSpellLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.it_insertRaceLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.it_insertClassLabels = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_help = new System.Windows.Forms.ToolStripMenuItem();
			this.About = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.Tree = new nwn2_ai_2da_editor.CompositedTreeView();
			this.treeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.tree_Highlight = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1_top = new System.Windows.Forms.Panel();
			this.tb_Search = new System.Windows.Forms.TextBox();
			this.btn_Search_d = new System.Windows.Forms.Button();
			this.btn_Search_u = new System.Windows.Forms.Button();
			this.btn_Apply = new System.Windows.Forms.Button();
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
			this.Open,
			this.it_Recent,
			this.toolStripSeparator1,
			this.Save,
			this.Saveas,
			this.toolStripSeparator2,
			this.Quit});
			this.tsmi_file.Name = "tsmi_file";
			this.tsmi_file.Size = new System.Drawing.Size(37, 24);
			this.tsmi_file.Text = "&File";
			this.tsmi_file.DropDownOpening += new System.EventHandler(this.dropdownopening_File);
			// 
			// Open
			// 
			this.Open.Name = "Open";
			this.Open.Padding = new System.Windows.Forms.Padding(0);
			this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.Open.Size = new System.Drawing.Size(160, 20);
			this.Open.Text = "&Open ...";
			this.Open.Click += new System.EventHandler(this.Click_open);
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
			// Save
			// 
			this.Save.Enabled = false;
			this.Save.Name = "Save";
			this.Save.Padding = new System.Windows.Forms.Padding(0);
			this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.Save.Size = new System.Drawing.Size(160, 20);
			this.Save.Text = "&Save";
			this.Save.Click += new System.EventHandler(this.Click_save);
			// 
			// Saveas
			// 
			this.Saveas.Enabled = false;
			this.Saveas.Name = "Saveas";
			this.Saveas.Padding = new System.Windows.Forms.Padding(0);
			this.Saveas.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.Saveas.Size = new System.Drawing.Size(160, 20);
			this.Saveas.Text = "Sav&e As ...";
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
			this.Quit.Padding = new System.Windows.Forms.Padding(0);
			this.Quit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.Quit.Size = new System.Drawing.Size(160, 20);
			this.Quit.Text = "&Quit";
			this.Quit.Click += new System.EventHandler(this.Click_quit);
			// 
			// tsmi_edit
			// 
			this.tsmi_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.it_ApplyGlobal,
			this.toolStripSeparator5,
			this.it_GotoChanged,
			this.toolStripSeparator3,
			this.Copy_decimal,
			this.Copy_hexadecimal,
			this.Copy_binary,
			this.toolStripSeparator6,
			this.clearCoreAIver});
			this.tsmi_edit.Name = "tsmi_edit";
			this.tsmi_edit.Size = new System.Drawing.Size(37, 24);
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
			// Copy_decimal
			// 
			this.Copy_decimal.Enabled = false;
			this.Copy_decimal.Name = "Copy_decimal";
			this.Copy_decimal.Padding = new System.Windows.Forms.Padding(0);
			this.Copy_decimal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.Copy_decimal.Size = new System.Drawing.Size(190, 20);
			this.Copy_decimal.Text = "Copy &decimal";
			this.Copy_decimal.Click += new System.EventHandler(this.Click_copy_decimal);
			// 
			// Copy_hexadecimal
			// 
			this.Copy_hexadecimal.Enabled = false;
			this.Copy_hexadecimal.Name = "Copy_hexadecimal";
			this.Copy_hexadecimal.Padding = new System.Windows.Forms.Padding(0);
			this.Copy_hexadecimal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.Copy_hexadecimal.Size = new System.Drawing.Size(190, 20);
			this.Copy_hexadecimal.Text = "Copy &hexadecimal";
			this.Copy_hexadecimal.Click += new System.EventHandler(this.Click_copy_hexadecimal);
			// 
			// Copy_binary
			// 
			this.Copy_binary.Enabled = false;
			this.Copy_binary.Name = "Copy_binary";
			this.Copy_binary.Padding = new System.Windows.Forms.Padding(0);
			this.Copy_binary.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
			this.Copy_binary.Size = new System.Drawing.Size(190, 20);
			this.Copy_binary.Text = "Copy &binary";
			this.Copy_binary.Click += new System.EventHandler(this.Click_copy_binary);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(187, 6);
			// 
			// clearCoreAIver
			// 
			this.clearCoreAIver.Enabled = false;
			this.clearCoreAIver.Name = "clearCoreAIver";
			this.clearCoreAIver.Padding = new System.Windows.Forms.Padding(0);
			this.clearCoreAIver.Size = new System.Drawing.Size(190, 20);
			this.clearCoreAIver.Text = "Clear CoreA&I version";
			this.clearCoreAIver.Click += new System.EventHandler(this.Click_clearCoreAiVersion);
			// 
			// tsmi_labels
			// 
			this.tsmi_labels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.pathSpells,
			this.pathRacialSubtypes,
			this.pathClasses,
			this.pathFeat,
			this.toolStripSeparator4,
			this.it_insertSpellLabels,
			this.it_insertRaceLabels,
			this.it_insertClassLabels});
			this.tsmi_labels.Name = "tsmi_labels";
			this.tsmi_labels.Size = new System.Drawing.Size(47, 24);
			this.tsmi_labels.Text = "&Labels";
			this.tsmi_labels.DropDownOpening += new System.EventHandler(this.dropdownopening_Labels);
			// 
			// pathSpells
			// 
			this.pathSpells.Name = "pathSpells";
			this.pathSpells.Padding = new System.Windows.Forms.Padding(0);
			this.pathSpells.Size = new System.Drawing.Size(185, 20);
			this.pathSpells.Text = "path &Spells.2da";
			this.pathSpells.Click += new System.EventHandler(this.Click_pathSpells);
			// 
			// pathRacialSubtypes
			// 
			this.pathRacialSubtypes.Name = "pathRacialSubtypes";
			this.pathRacialSubtypes.Padding = new System.Windows.Forms.Padding(0);
			this.pathRacialSubtypes.Size = new System.Drawing.Size(185, 20);
			this.pathRacialSubtypes.Text = "path &RacialSubtypes.2da";
			this.pathRacialSubtypes.Click += new System.EventHandler(this.Click_pathRacialSubtypes);
			// 
			// pathClasses
			// 
			this.pathClasses.Name = "pathClasses";
			this.pathClasses.Padding = new System.Windows.Forms.Padding(0);
			this.pathClasses.Size = new System.Drawing.Size(185, 20);
			this.pathClasses.Text = "path &Classes.2da";
			this.pathClasses.Click += new System.EventHandler(this.Click_pathClasses);
			// 
			// pathFeat
			// 
			this.pathFeat.Name = "pathFeat";
			this.pathFeat.Padding = new System.Windows.Forms.Padding(0);
			this.pathFeat.Size = new System.Drawing.Size(185, 20);
			this.pathFeat.Text = "path &Feat.2da";
			this.pathFeat.Click += new System.EventHandler(this.Click_pathFeat);
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
			this.About});
			this.tsmi_help.Name = "tsmi_help";
			this.tsmi_help.Size = new System.Drawing.Size(37, 24);
			this.tsmi_help.Text = "&Help";
			// 
			// About
			// 
			this.About.Name = "About";
			this.About.Padding = new System.Windows.Forms.Padding(0);
			this.About.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.About.Size = new System.Drawing.Size(130, 20);
			this.About.Text = "&About";
			this.About.Click += new System.EventHandler(this.Click_about);
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
			this.splitContainer.Panel2.Controls.Add(this.btn_Apply);
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
			this.panel1_top.Controls.Add(this.btn_Search_d);
			this.panel1_top.Controls.Add(this.btn_Search_u);
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
			// btn_Search_d
			// 
			this.btn_Search_d.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_Search_d.Location = new System.Drawing.Point(225, 0);
			this.btn_Search_d.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Search_d.Name = "btn_Search_d";
			this.btn_Search_d.Size = new System.Drawing.Size(25, 20);
			this.btn_Search_d.TabIndex = 1;
			this.btn_Search_d.Text = "d";
			this.btn_Search_d.UseVisualStyleBackColor = true;
			this.btn_Search_d.Click += new System.EventHandler(this.Click_search);
			// 
			// btn_Search_u
			// 
			this.btn_Search_u.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_Search_u.Location = new System.Drawing.Point(250, 0);
			this.btn_Search_u.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Search_u.Name = "btn_Search_u";
			this.btn_Search_u.Size = new System.Drawing.Size(25, 20);
			this.btn_Search_u.TabIndex = 2;
			this.btn_Search_u.Text = "u";
			this.btn_Search_u.UseVisualStyleBackColor = true;
			this.btn_Search_u.Click += new System.EventHandler(this.Click_search);
			// 
			// btn_Apply
			// 
			this.btn_Apply.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btn_Apply.Enabled = false;
			this.btn_Apply.Location = new System.Drawing.Point(0, 405);
			this.btn_Apply.Margin = new System.Windows.Forms.Padding(0);
			this.btn_Apply.Name = "btn_Apply";
			this.btn_Apply.Size = new System.Drawing.Size(514, 25);
			this.btn_Apply.TabIndex = 0;
			this.btn_Apply.UseVisualStyleBackColor = true;
			this.btn_Apply.Click += new System.EventHandler(this.Click_apply);
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
