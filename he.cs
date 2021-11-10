using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	#region he
	/// <summary>
	/// The <c>he</c> - HenchEditor - is the application.
	/// </summary>
	sealed partial class he
		: Form
	{
		#region class Vars
		/// <summary>
		/// The <c>UserControl</c> added to
		/// <c><see cref="splitContainer"></see>.Panel2</c> that displays a
		/// <c>TabControl</c> for spells, races, or classes. It will be created
		/// and disposed dynamically.
		/// </summary>
		internal static HenchControl HenchControl;

		/// <summary>
		/// The blank 2da-string: <c>****</c>.
		/// </summary>
		internal const string stars = "****";

		/// <summary>
		/// Tracks which 2da-type is currently loaded.
		/// <list type="bullet">
		/// <item>henchspells</item>
		/// <item>henchracial</item>
		/// <item>henchclasses</item>
		/// </list>
		/// </summary>
		enum Type2da
		{
			None,   // 0 - default on startup.
			Spells, // 1
			Racial, // 2
			Classes // 3
		}

		/// <summary>
		/// Gets/sets the currently loaded 2da-type.
		/// </summary>
		Type2da Type
		{ get; set; }

		/// <summary>
		/// A <c>List</c> that contains <c>structs</c> of all spells currently
		/// in HenchSpells.2da.
		/// </summary>
		internal static IList<Spell> Spells = new List<Spell>();

		/// <summary>
		/// A <c>Dictionary</c> that contains <c>structs</c> of any spell that
		/// has been changed by the editor.
		/// </summary>
		internal static IDictionary<int, SpellChanged> SpellsChanged = new Dictionary<int, SpellChanged>();

		/// <summary>
		/// A <c>List</c> that contains <c>structs</c> of all races currently in
		/// HenchRacial.2da.
		/// </summary>
		internal static IList<Race> Races = new List<Race>();

		/// <summary>
		/// A <c>Dictionary</c> that contains <c>structs</c> of any race that
		/// has been changed by the editor.
		/// </summary>
		internal static IDictionary<int, RaceChanged> RacesChanged = new Dictionary<int, RaceChanged>();

		/// <summary>
		/// A <c>List</c> that contains <c>structs</c> of all classes currently
		/// in HenchClasses.2da.
		/// </summary>
		internal static IList<Class> Classes = new List<Class>();

		/// <summary>
		/// A <c>Dictionary</c> that contains <c>structs</c> of any class that
		/// has been changed by the editor.
		/// </summary>
		internal static IDictionary<int, ClassChanged> ClassesChanged = new Dictionary<int, ClassChanged>();

		/// <summary>
		/// The currently selected node in the <c><see cref="Tree"/></c>.
		/// </summary>
		internal static int Id
		{ get; set; }

		/// <summary>
		/// A <c>bool</c> that prevents firing the <c>TextChanged</c> handlers
		/// when <c>true</c>. That is don't fire the <c>event</c> when the
		/// <c><see cref="Tree"/></c> is initially populated or is being
		/// re-populated.
		/// </summary>
		internal static bool BypassDiffer;

		/// <summary>
		/// A <c>bool</c> that bypasses forcibly inserting an InfoVersion into
		/// struct-data. This needs to be set to cope with 2das that are
		/// compatible with Tony AI 2.3+
		/// </summary>
		internal static bool BypassInfoVersion;

//		/// <summary>
//		/// A <c>bool</c> to track whether to inform the user if any
//		/// InfoVersions have been updated once a 2da-file finishes loading.
//		/// </summary>
//		bool InfoVersionUpdate
//		{ get; set; }

		/// <summary>
		/// A <c>bool</c> indicating that the currently loaded 2da-file has a
		/// "Label" col.
		/// </summary>
		bool hasLabels;

		/// <summary>
		/// The fullpath of the currently opened 2da-file.
		/// </summary>
		string _pfe  = String.Empty;
		string _pfeT = String.Empty;

		int userHeight = 480;
		int panel2width, panel2height;

		const string RF_CFG        = "recent_files.cfg";
		const string RD_LABELS_CFG = "recent_dir_labels.cfg";
		const string RD_SCRIPS_CFG = "recent_dir_scripts.cfg";

		/// <summary>
		/// A fixed-width <c>Font</c> for all the hex and bin textboxes.
		/// </summary>
		internal static readonly Font FixedFont = new Font("Courier New", 8F);

		/// <summary>
		/// A <c>Form</c> that displays spellscripts.
		/// </summary>
		Scripter Scripter;
		#endregion class Vars


		#region cTor
		/// <summary>
		/// cTor. Instantiates the HenchEditor application.
		/// </summary>
		public he()
		{
			InitializeComponent();

			CreateScript_button();

			logfile.CreateLog(); // NOTE: The logfile works in debug-builds only.
			// To write a line to the logfile:
			// logfile.Log("what you want to know here");
			//
			// The logfile ought appear in the directory with the executable.

			// set unicode text on the up/down Search btns.
			bu_Search_d.Text = "\u25bc"; // down triangle
			bu_Search_u.Text = "\u25b2"; // up triangle

			ActiveControl = tb_Search; // focus the Search-box

			Size = new Size(800, userHeight);

			recent_init(); // init recents before (potentially) loading a table from FileExplorer
		}
		#endregion cTor


		#region eventhandlers (override)
		/// <summary>
		/// Overrides the <c>FormClosing</c> handler.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (Scripter != null && !Scripter.IsDisposed)
				Scripter.Close();

			if (e.CloseReason != CloseReason.WindowsShutDown)
			{
				if (isChanged())
				{
					string info = "Data has changed."
								+ Environment.NewLine + Environment.NewLine
								+ "Okay to exit ...";
					using (var ib = new infobox(" Warning", info, "yessir", "no"))
						e.Cancel = ib.ShowDialog(this) != DialogResult.OK;
				}

				if (!e.Cancel) recent_write();
			}
			base.OnFormClosing(e);
		}

		/// <summary>
		/// Overrides the <c>Resize</c> handler.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			if (WindowState == FormWindowState.Normal)
				userHeight = ClientSize.Height;

			base.OnResize(e);
		}
		#endregion eventhandlers (override)


		#region SpellTree node-select
		/// <summary>
		/// Handles <c>AfterSelect</c> event for nodes in the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AfterSelect_node(object sender, TreeViewEventArgs e)
		{
			Id = Tree.SelectedNode.Index;

			BypassDiffer = true;
			HenchControl.SelectId();
			BypassDiffer = false;
		}
		#endregion SpellTree node-select


		/// <summary>
		/// Sets the titlebar text.
		/// </summary>
		/// <param name="saved"><c>true</c> if saved, <c>false</c> if changed</param>
		internal void SetTitleText(bool saved = false)
		{
			string title = "nwn2_ai_2da_editor - " + _pfe;
			if (!saved) title += " *";
			Text = title;
		}

		/// <summary>
		/// Sets the color of the currently selected node.
		/// </summary>
		/// <param name="color"></param>
		internal void SetNodeColor(Color color)
		{
			Tree.SelectedNode.ForeColor = color;
		}

		/// <summary>
		/// Selects the search-box after a file loads.
		/// </summary>
		internal void SelectSearch()
		{
			tb_Search.Focus();
		}

		/// <summary>
		/// Enables or disables the Copy hex and Copy bin its.
		/// </summary>
		/// <param name="enabled"></param>
		internal void EnableCopy(bool enabled)
		{
			it_Copy_hex.Enabled =
			it_Copy_bin.Enabled = enabled;
		}

		/// <summary>
		/// Prints current value of current page's text-field to its hex-field
		/// and bin-field.
		/// </summary>
		/// <param name="val"></param>
		/// <param name="hexbox"></param>
		/// <param name="binbox"></param>
		internal static void PrintCurrent(int val, Control hexbox, Control binbox)
		{
			string text = val.ToString("X8");
			text = text.Insert(7, "    ");
			text = text.Insert(6, "    ");
			text = text.Insert(5, "    ");
			text = text.Insert(4, "    ");
			text = text.Insert(3, "    ");
			text = text.Insert(2, "    ");
			text = text.Insert(1, "    ");
			text = text.Insert(0, "   ");
			hexbox.Text = text;

			text = Convert.ToString(val, 2).PadLeft(32, '0');
			text = text.Insert(28, " ");
			text = text.Insert(24, " ");
			text = text.Insert(20, " ");
			text = text.Insert(16, " ");
			text = text.Insert(12, " ");
			text = text.Insert( 8, " ");
			text = text.Insert( 4, " ");
			binbox.Text = text;
		}


		/// <summary>
		/// Enables or disables the Apply button as well as the GlobalApply and
		/// GotoChanged its.
		/// </summary>
		/// <param name="differs"></param>
		internal void EnableApplys(bool differs)
		{
			bool changes;
			switch (Type)
			{
				case Type2da.Spells:  changes = (SpellsChanged .Count != 0); break;
				case Type2da.Racial:  changes = (RacesChanged  .Count != 0); break;
				case Type2da.Classes: changes = (ClassesChanged.Count != 0); break;

				default: changes = false;
					break;
			}
			bu_Apply      .Enabled = differs;
			it_ApplyGlobal.Enabled = differs || changes;
			it_GotoChanged.Enabled = differs || changes || hasSpareChange();
		}

		/// <summary>
		/// Handler for the "apply changed data to currently selected
		/// spell/race/class" button.
		/// </summary>
		/// <param name="sender">bu_Apply</param>
		/// <param name="e"></param>
		/// <remarks>See
		/// <c><see cref="Click_applyGlobal()">Click_applyGlobal()</see></c> to
		/// apply all altered data globally.</remarks>
		void Click_apply(object sender, EventArgs e)
		{
			SetTitleText();

			switch (Type)
			{
				case Type2da.Spells:
				{
					Spell spell = Spells[Id];
					if (spell.differ != control_Spells.bit_clean)
					{
						spell.differ = control_Spells.bit_clean;
						spell.isChanged = true;

						SpellChanged spellchanged = SpellsChanged[Id];

						spell.spellinfo    = spellchanged.spellinfo;
						spell.targetinfo   = spellchanged.targetinfo;
						spell.effectweight = spellchanged.effectweight;
						spell.effecttypes  = spellchanged.effecttypes;
						spell.damageinfo   = spellchanged.damageinfo;
						spell.savetype     = spellchanged.savetype;
						spell.savedctype   = spellchanged.savedctype;

						Spells[Id] = spell;

						SpellsChanged.Remove(Id);

						HenchControl.SetResetColor(DefaultForeColor);
						AfterSelect_node(null, null); // refresh all displayed data for the current spell jic
					}

					if (Spells[Id].isChanged) // this goes outside the SpellsChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.Blue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;
				}

				case Type2da.Racial:
				{
					Race race = Races[Id];
					if (race.differ != control_Racial.bit_clean)
					{
						race.differ = control_Racial.bit_clean;
						race.isChanged = true;

						RaceChanged racechanged = RacesChanged[Id];

						race.flags = racechanged.flags;
						race.feat1 = racechanged.feat1;
						race.feat2 = racechanged.feat2;
						race.feat3 = racechanged.feat3;
						race.feat4 = racechanged.feat4;
						race.feat5 = racechanged.feat5;

						Races[Id] = race;

						RacesChanged.Remove(Id);

						HenchControl.SetResetColor(DefaultForeColor);

						AfterSelect_node(null, null); // refresh all displayed data for the current node jic
					}

					if (Races[Id].isChanged) // this goes outside the RacesChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.Blue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;
				}

				case Type2da.Classes:
				{
					Class @class = Classes[Id];
					if (@class.differ != control_Classes.bit_clean)
					{
						@class.differ = control_Classes.bit_clean;
						@class.isChanged = true;

						ClassChanged classchanged = ClassesChanged[Id];

						@class.flags  = classchanged.flags;
						@class.feat1  = classchanged.feat1;
						@class.feat2  = classchanged.feat2;
						@class.feat3  = classchanged.feat3;
						@class.feat4  = classchanged.feat4;
						@class.feat5  = classchanged.feat5;
						@class.feat6  = classchanged.feat6;
						@class.feat7  = classchanged.feat7;
						@class.feat8  = classchanged.feat8;
						@class.feat9  = classchanged.feat9;
						@class.feat10 = classchanged.feat10;
						@class.feat11 = classchanged.feat11;

						Classes[Id] = @class;

						ClassesChanged.Remove(Id);

						HenchControl.SetResetColor(DefaultForeColor);
						AfterSelect_node(null, null); // refresh all displayed data for the current node jic
					}

					if (Classes[Id].isChanged) // this goes outside the ClassesChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.Blue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;
				}
			}
		}


		#region Utilities (static)
		/// <summary>
		/// Value of <c>epsilon</c>.
		/// </summary>
		const float epsilon = 0.0001f;

		/// <summary>
		/// Checks if two <c>floats</c> are within <c><see cref="epsilon"/></c>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>true if equal enough</returns>
		/// <remarks>Does not handle NaNs, infinities or whathaveya.</remarks>
		internal static bool FloatsEqual(float a, float b)
		{
			return Math.Abs(b - a) < epsilon;
		}

		/// <summary>
		/// Formats a <c>float</c> to a <c>string</c> that is consistent with a
		/// 2da-field.
		/// </summary>
		/// <param name="f"></param>
		/// <returns><c>string</c> of a <c>float</c></returns>
		internal static string Float2daFormat(float f)
		{
			string val = f.ToString();

			if (val.IndexOf('.') == -1)
				return val + ".0";

			return val;
		}
		#endregion Utilities (static)


		#region Search
		/// <summary>
		/// Handler for pressing the <c>Enter</c> key when either the
		/// search-textbox or the spell-tree is focused.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="tb_Search"/></c></item>
		/// <item><c><see cref="Tree"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		/// <remarks>Searches downward only.</remarks>
		void KeyPress_search(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				Click_search(bu_Search_d, EventArgs.Empty);
				e.Handled = true;
			}
		}

		/// <summary>
		/// Handler for clicking the Search btns.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="bu_Search_d"/></c></item>
		/// <item><c><see cref="bu_Search_u"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void Click_search(object sender, EventArgs e)
		{
			if (tb_Search.Text.Length != 0)
			{
				int total = Tree.Nodes.Count;
				if (total > 1)
				{
					string text = tb_Search.Text.ToLower();

					int id;

					if (sender == bu_Search_d)
					{
						if (Id == total - 1)
						{
							id = 0;
						}
						else
							id = Id + 1;

						while (!Tree.Nodes[id].Text.ToLower().Contains(text))
						{
							if (id == Id) // not found.
							{
								SystemSounds.Beep.Play();
								break;
							}

							if (++id == total) // wrap to first node
							{
								id = 0;
							}
						}
					}
					else // sender == bu_Search_u
					{
						if (Id == 0)
						{
							id = total - 1;
						}
						else
							id = Id - 1;

						while (!Tree.Nodes[id].Text.ToLower().Contains(text))
						{
							if (id == Id) // not found.
							{
								SystemSounds.Beep.Play();
								break;
							}

							if (--id == -1) // wrap to last node
							{
								id = total - 1;
							}
						}
					}

					Tree.SelectedNode = Tree.Nodes[id];
				}
			}
		}
		#endregion Search


		#region treeview ContextMenu
		/// <summary>
		/// Highlights nodes on the tree that don't have page1 info.
		/// </summary>
		/// <param name="sender"><c><see cref="tree_Highlight"/></c></param>
		/// <param name="e"></param>
		void Click_treeHighlight(object sender, EventArgs e)
		{
			switch (Type)
			{
				case Type2da.Spells:
				{
					int total = Spells.Count;
					if (tree_Highlight.Checked = !tree_Highlight.Checked)
					{
						for (int id = 0; id != total; ++id)
						{
							if (Spells[id].spellinfo == 0)
								Tree.Nodes[id].ForeColor = Color.DarkTurquoise;
						}
					}
					else
					{
						Color color;
						Spell spell;
						for (int id = 0; id != total; ++id)
						{
							spell = Spells[id];
							if      (spell.differ != control_Spells.bit_clean) color = Color.Crimson;
							else if (spell.isChanged)                          color = Color.Blue;
							else                                               color = DefaultForeColor;

							Tree.Nodes[id].ForeColor = color;
						}
					}
					break;
				}

				case Type2da.Racial:
				{
					int total = Races.Count;
					if (tree_Highlight.Checked = !tree_Highlight.Checked)
					{
						for (int id = 0; id != total; ++id)
						{
							if (Races[id].flags == 0)
								Tree.Nodes[id].ForeColor = Color.DarkTurquoise;
						}
					}
					else
					{
						Color color;
						Race race;
						for (int id = 0; id != total; ++id)
						{
							race = Races[id];
							if      (race.differ != control_Racial.bit_clean) color = Color.Crimson;
							else if (race.isChanged)                          color = Color.Blue;
							else                                              color = DefaultForeColor;

							Tree.Nodes[id].ForeColor = color;
						}
					}
					break;
				}

				case Type2da.Classes:
				{
					int total = Classes.Count;
					if (tree_Highlight.Checked = !tree_Highlight.Checked)
					{
						for (int id = 0; id != total; ++id)
						{
							if (Classes[id].flags == 0)
								Tree.Nodes[id].ForeColor = Color.DarkTurquoise;
						}
					}
					else
					{
						Color color;
						Class @class;
						for (int id = 0; id != total; ++id)
						{
							@class = Classes[id];
							if      (@class.differ != control_Classes.bit_clean) color = Color.Crimson;
							else if (@class.isChanged)                           color = Color.Blue;
							else                                                 color = DefaultForeColor;

							Tree.Nodes[id].ForeColor = color;
						}
					}
					break;
				}
			}
		}


		// kL_note: I started to implement AddNode functionality (RMB-click on
		// the Tree) below but ... long story short: this isn't a 2da row-editor.
		// Therefore User needs to add or remove rows with a regular 2da editor.
		//
		// I'm leaving the ContextMenu in, however. It can be enabled by
		// assigning 'treeMenu' to the TreeView's ContextMenuStrip. And
		// Click_addnode() to its "addNode" menu-item. And uncomment the functs
		// in 'inputbox.cs' along with the "addNode.Text = " lines in the
		// Load_Hench*() functs.
		//
		// ps. "addNode" has been repurposed to "tree_Highlight". So you'd have
		// to create a new menu-item.
		//
		// But the whole idea would need a large amount of effort; it should
		// jive with the path-options (to so-called external 2das) as well as
		// be able to create and delete ranges of rows in the Hench*.2das - this
		// could easily cause nontrivial inconsistencies between HenchSpells.2da
		// and Spells.2da eg ....
		//
		// Policy #138: Let the user deal with adding/deleting 2da-rows.

/*		/// <summary>
		/// Handles click on the tree's context-menu: AddNode.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_addnode(object sender, EventArgs e)
		{
			if (Type != Type2da.None)
			{
				int id = Tree.Nodes.Count;
				switch (Type)
				{
					case Type2da.Spells:  AddSpell(id); break;
					case Type2da.Racial:  AddRace(id);  break;
					case Type2da.Classes: AddClass(id); break;
				}
			}
		} */

/*		/// <summary>
		/// Adds a spell to the tree.
		/// </summary>
		/// <param name="id"></param>
		void AddSpell(int id)
		{
			string label = String.Empty;

			if (spellLabels.Count >= id)
			{
				label = spellLabels[id];
			}
			else
			{
				string str = "";
				switch (InputBox("Spell label", ref str))
				{
					case DialogResult.OK:
						label = str;
						break;

					case DialogResult.Cancel:
						return;
				}
			}


			var spell = new Spell();

			spell.label     = label;
			spell.id        = id;
			spell.isChanged = true;
			spell.differ    = bit_clean;

			spell.spellinfo    = 0;
			spell.targetinfo   = 0;
			spell.effectweight = 0.0f;
			spell.effecttypes  = 0;
			spell.damageinfo   = 0;
			spell.savetype     = 0;
			spell.savedctype   = 0;

			Spells.Add(spell);


			string pad = String.Empty;
			int digits = id.ToString().Length;
			while (digits++ < PAD_SPELLLABEL)
			{
				pad += " ";
			}

			label = id + pad + " " + label;

//			Tree.BeginUpdate();

			Tree.Nodes.Add(label);
			Tree.SelectedNode = Tree.Nodes[id];

//			Tree.EndUpdate();
//			Tree.SelectedNode.EnsureVisible();
		} */

/*		/// <summary>
		/// Adds a race to the tree.
		/// </summary>
		/// <param name="id"></param>
		void AddRace(int id)
		{
			string label = String.Empty;

			if (raceLabels.Count >= id)
			{
				label = raceLabels[id];
			}
			else
			{
				string str = "";
				switch (InputBox("Subrace label", ref str))
				{
					case DialogResult.OK:
						label = str;
						break;

					case DialogResult.Cancel:
						return;
				}
			}


			var race = new Race();

			race.id        = id;
			race.isChanged = true;
			race.differ    = bit_clean;

			race.flags = 0;
			race.feat1 = 0;
			race.feat2 = 0;
			race.feat3 = 0;
			race.feat4 = 0;
			race.feat5 = 0;

			Races.Add(race);


			label = id + " " + label;

//			Tree.BeginUpdate();

			Tree.Nodes.Add(label);
			Tree.SelectedNode = Tree.Nodes[id];

//			Tree.EndUpdate();
//			Tree.SelectedNode.EnsureVisible();
		} */

/*		/// <summary>
		/// Adds a class to the tree.
		/// </summary>
		/// <param name="id"></param>
		void AddClass(int id)
		{} */
		#endregion treeview ContextMenu
	}
	#endregion he
}
