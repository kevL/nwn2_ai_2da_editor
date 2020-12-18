using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	#region he
	/// <summary>
	/// The he is the only form.
	/// </summary>
	public partial class he // short for "HenchEditor"
		:
			Form
	{
		#region class Vars
		/// <summary>
		/// The control added to 'splitContainer1.Panel2' that displays a
		/// TabControl for spells, races, or classes. It will be created and
		/// disposed dynamically.
		/// </summary>
		UserControl HenchControl;

		/// <summary>
		/// The 'blank' 2da-string.
		/// </summary>
		const string blank = "****";

		/// <summary>
		/// Tracks which 2da-type is currently loaded:
		/// - henchspells
		/// - henchracial
		/// - henchclasses
		/// </summary>
		enum Type2da
		{
			TYPE_NONE,   // 0 - default on startup.
			TYPE_SPELLS, // 1
			TYPE_RACIAL, // 2
			TYPE_CLASSES // 3
		}

		/// <summary>
		/// Gets/sets the currently loaded 2da-type.
		/// </summary>
		Type2da Type
		{ get; set; }

		/// <summary>
		/// A list-object that contains structs of all spells currently in
		/// HenchSpells.2da.
		/// </summary>
		internal static List<Spell> Spells = new List<Spell>();

		/// <summary>
		/// A dictionary-object that contains structs of any spell that has been
		/// changed by the editor.
		/// </summary>
		internal static Dictionary<int, SpellChanged> SpellsChanged = new Dictionary<int, SpellChanged>();

		/// <summary>
		/// A list-object that contains structs of all races currently in
		/// HenchRacial.2da.
		/// </summary>
		internal static List<Race> Races = new List<Race>();

		/// <summary>
		/// A dictionary-object that contains structs of any race that has been
		/// changed by the editor.
		/// </summary>
		internal static Dictionary<int, RaceChanged> RacesChanged = new Dictionary<int, RaceChanged>();

		/// <summary>
		/// A list-object that contains structs of all classes currently in
		/// HenchClasses.2da.
		/// </summary>
		internal static List<Class> Classes = new List<Class>();

		/// <summary>
		/// A dictionary-object that contains structs of any class that has been
		/// changed by the editor.
		/// </summary>
		internal static Dictionary<int, ClassChanged> ClassesChanged = new Dictionary<int, ClassChanged>();

		/// <summary>
		/// The currently selected node in the Tree.
		/// </summary>
		internal static int Id
		{ get; set; }

		/// <summary>
		/// A boolean that prevents firing the TextChanged handlers when true.
		/// That is don't fire the text-changed event when the tree is initially
		/// populated or is being re-populated.
		/// </summary>
		internal static bool BypassDiffer;

		/// <summary>
		/// A boolean that bypasses forcibly inserting an InfoVersion into
		/// struct-data. This needs to be set to cope with 2das that are
		/// compatible with Tony AI 2.3+
		/// </summary>
		internal static bool BypassInfoVersion;

		/// <summary>
		/// A boolean indicating that the currently loaded 2da has a "Label" col.
		/// </summary>
		bool hasLabels;

		/// <summary>
		/// A boolean to track whether to inform the user if any InfoVersions
		/// have been updated once a 2da finishes loading.
		/// </summary>
		bool InfoVersionUpdate
		{ get; set; }


		/// <summary>
		/// The fullpath of the currently opened 2da file.
		/// </summary>
		string _pfe  = String.Empty;
		string _pfeT = String.Empty;
		#endregion class Vars


		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		public he()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			// Add constructor code after the InitializeComponent() call.

			logfile.CreateLog(); // NOTE: The logfile works in debug-builds only.
			// To write a line to the logfile:
			// logfile.Log("what you want to know here");
			//
			// The logfile ought appear in the directory with the executable.

			// set unicode text on the up/down Search btns.
			btn_Search_d.Text = "\u25bc"; // down triangle
			btn_Search_u.Text = "\u25b2"; // up triangle

			ActiveControl = tb_Search; // focus the Search-box

			Size = new Size(800, 480);

			// NOTE: quickload a 2da for testing ONLY.
//			_pfe = @"C:\GIT\nwn2_ai_2da_editor\2da\henchspells.2da";
//			_pfe = @"C:\GIT\nwn2_ai_2da_editor\2da\henchracial.2da";
//			_pfe = @"C:\GIT\nwn2_ai_2da_editor\2da\henchclasses.2da";
//			Load_file();
		}
		#endregion cTor


		#region Load
		/// <summary>
		/// Determines which file to load: HenchSpells, HenchRacial, or
		/// HenchClasses.
		/// The fullpath of the file must already be stored in '_pfe'.
		/// NOTE: "pfe" stands for "path_file_extension"
		/// </summary>
		void Load_file()
		{
			if (File.Exists(_pfe)) // safety.
			{
				string[] rows = File.ReadAllLines(_pfe);

				// WARNING: This editor does *not* handle quotation marks around 2da fields.
				foreach (string row in rows) // test for double-quote character and exit if found.
				{
					foreach (char character in row)
					{
						if (character == '"')
						{
							const string info = "The 2da-file contains double-quotes. Although that can be"
											  + " valid in a 2da-file this editor is not coded to cope."
											  + " Format the 2da-file to not use double-quotes if you want"
											  + " to open it here.";
							MessageBox.Show(info,
											"  ERROR",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error,
											MessageBoxDefaultButton.Button1);
							return;
						}
					}
				}


				SuspendLayout();

				for (int i = 0; i != rows.Length; ++i)
					rows[i] = rows[i].Trim();

				string[] fields;
				foreach (string row in rows)
				{
					if (!String.IsNullOrEmpty(row))
					{
						fields = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

						if (fields.Length > 5) // bypass 2da version header
						{
							// resolve what 2da is being loaded ->

							// HenchSpells.2da colheads
							// Label SpellInfo TargetInfo EffectWeight EffectTypes DamageInfo SaveType SaveDCType

							// HenchRacial.2da colheads
							// Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5

							// HenchClasses.2da colheads
							// Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5 FeatSpell6 FeatSpell7 FeatSpell8 FeatSpell9 FeatSpell10 FeatSpell11

							if (fields.Length == 7								// henchspells w/out "Label" col
								&& fields[0].ToLowerInvariant() == "spellinfo"
								&& fields[1].ToLowerInvariant() == "targetinfo"
								&& fields[2].ToLowerInvariant() == "effectweight"
								&& fields[3].ToLowerInvariant() == "effecttypes"
								&& fields[4].ToLowerInvariant() == "damageinfo"
								&& fields[5].ToLowerInvariant() == "savetype"
								&& fields[6].ToLowerInvariant() == "savedctype")
							{
								hasLabels = false;
								Load_HenchSpells(rows);
							}
							else if (fields.Length == 8							// henchspells w/ "Label" col
								&& fields[0].ToLowerInvariant() == "label"
								&& fields[1].ToLowerInvariant() == "spellinfo"
								&& fields[2].ToLowerInvariant() == "targetinfo"
								&& fields[3].ToLowerInvariant() == "effectweight"
								&& fields[4].ToLowerInvariant() == "effecttypes"
								&& fields[5].ToLowerInvariant() == "damageinfo"
								&& fields[6].ToLowerInvariant() == "savetype"
								&& fields[7].ToLowerInvariant() == "savedctype")
							{
								hasLabels = true;
								Load_HenchSpells(rows);
							}
							else if (fields.Length == 6							// henchracial w/out "Label" col
								&& fields[0].ToLowerInvariant() == "flags"
								&& fields[1].ToLowerInvariant() == "featspell1"
								&& fields[2].ToLowerInvariant() == "featspell2"
								&& fields[3].ToLowerInvariant() == "featspell3"
								&& fields[4].ToLowerInvariant() == "featspell4"
								&& fields[5].ToLowerInvariant() == "featspell5")
							{
								hasLabels = false;
								Load_HenchRacial(rows);
							}
							else if (fields.Length == 7							// henchracial w/ "Label" col
								&& fields[0].ToLowerInvariant() == "label"
								&& fields[1].ToLowerInvariant() == "flags"
								&& fields[2].ToLowerInvariant() == "featspell1"
								&& fields[3].ToLowerInvariant() == "featspell2"
								&& fields[4].ToLowerInvariant() == "featspell3"
								&& fields[5].ToLowerInvariant() == "featspell4"
								&& fields[6].ToLowerInvariant() == "featspell5")
							{
								hasLabels = true;
								Load_HenchRacial(rows);
							}
							else if (fields.Length == 12						// henchclasses w/out "Label" col
								&& fields[ 0].ToLowerInvariant() == "flags"
								&& fields[ 1].ToLowerInvariant() == "featspell1"
								&& fields[ 2].ToLowerInvariant() == "featspell2"
								&& fields[ 3].ToLowerInvariant() == "featspell3"
								&& fields[ 4].ToLowerInvariant() == "featspell4"
								&& fields[ 5].ToLowerInvariant() == "featspell5"
								&& fields[ 6].ToLowerInvariant() == "featspell6"
								&& fields[ 7].ToLowerInvariant() == "featspell7"
								&& fields[ 8].ToLowerInvariant() == "featspell8"
								&& fields[ 9].ToLowerInvariant() == "featspell9"
								&& fields[10].ToLowerInvariant() == "featspell10"
								&& fields[11].ToLowerInvariant() == "featspell11")
							{
								hasLabels = false;
								Load_HenchClasses(rows);
							}
							else if (fields.Length == 13						// henchclasses w/ "Label" col
								&& fields[ 0].ToLowerInvariant() == "label"
								&& fields[ 1].ToLowerInvariant() == "flags"
								&& fields[ 2].ToLowerInvariant() == "featspell1"
								&& fields[ 3].ToLowerInvariant() == "featspell2"
								&& fields[ 4].ToLowerInvariant() == "featspell3"
								&& fields[ 5].ToLowerInvariant() == "featspell4"
								&& fields[ 6].ToLowerInvariant() == "featspell5"
								&& fields[ 7].ToLowerInvariant() == "featspell6"
								&& fields[ 8].ToLowerInvariant() == "featspell7"
								&& fields[ 9].ToLowerInvariant() == "featspell8"
								&& fields[10].ToLowerInvariant() == "featspell9"
								&& fields[11].ToLowerInvariant() == "featspell10"
								&& fields[12].ToLowerInvariant() == "featspell11")
							{
								hasLabels = true;
								Load_HenchClasses(rows);
							}
							else
							{
								ResumeLayout();

								MessageBox.Show("That file does not appear to be HenchSpells, HenchRacial, or HenchClasses.2da",
												"  ERROR",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error,
												MessageBoxDefaultButton.Button1);
								return;
							}


							Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of current file)

							// NOTE: Tree.SelectedNode=Tree.Nodes[0] is done auto.
							// Not necessarily ...
							Tree.SelectedNode = Tree.Nodes[0];

//							if (InfoVersionUpdate) // no InfoVersion in TonyAI 2.3+
//							{
//								InfoVersionUpdate = false;
//								MessageBox.Show("InfoVersion(s) have been updated.",
//												"  InfoVersion update",
//												MessageBoxButtons.OK,
//												MessageBoxIcon.Information,
//												MessageBoxDefaultButton.Button1);
//							}
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Clears all lists and dictionaries.
		/// </summary>
		void ClearData()
		{
			Spells        .Clear();
			SpellsChanged .Clear();
			Races         .Clear();
			RacesChanged  .Clear();
			Classes       .Clear();
			ClassesChanged.Clear();
		}

		/// <summary>
		/// Loads a HenchSpells.2da file.
		/// If the file is not a valid HenchSpells.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		/// <param name="rows"></param>
		void Load_HenchSpells(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new tabcontrol_Spells(this);
			splitContainer1.Panel2.Controls.Add(HenchControl);

			// TODO: size the form appropriately

			Type = Type2da.TYPE_SPELLS;

			ClearData();


			string[] fields;
			string field;

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					fields = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(fields[0], out id)) // is a valid 2da row
					{
						var spell = new Spell();

						spell.id        = id;
						spell.isChanged = false;
						spell.differ    = tabcontrol_Spells.bit_clear;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != blank)
							spell.label = field;
						else
							spell.label = String.Empty;

						if ((field = fields[++col]) != blank)
							spell.spellinfo = Int32.Parse(field);
						else
							spell.spellinfo = 0;

						if ((field = fields[++col]) != blank)
							spell.targetinfo = Int32.Parse(field);
						else
							spell.targetinfo = 0;

						if ((field = fields[++col]) != blank)
							spell.effectweight = Single.Parse(field);
						else
							spell.effectweight = 0.0f;

						if ((field = fields[++col]) != blank)
							spell.effecttypes = Int32.Parse(field);
						else
							spell.effecttypes = 0;

						if ((field = fields[++col]) != blank)
							spell.damageinfo = Int32.Parse(field);
						else
							spell.damageinfo = 0;

						if ((field = fields[++col]) != blank)
							spell.savetype = Int32.Parse(field);
						else
							spell.savetype = 0;

						if ((field = fields[++col]) != blank)
							spell.savedctype = Int32.Parse(field);
						else
							spell.savedctype = 0;

						Spells.Add(spell);	// spell-structs can now be referenced in the 'Spells' list by their
					}						// - Spells[id]
				}							// - HenchSpells.2da row#
			}								// - SpellID (Spells.2da row#)

			GrowTree();

			EnableCopy(true);

			// check if any info-version(s) need to be updated in spellinfo-int.
//			InfoVersionLoad_spells();

			// Groups on SpellInfo and TargetInfo generally stay green
			// unless SpellInfo is flagged as a MasterID
			(HenchControl as tabcontrol_Spells).SetDefaultGroupColors();

			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width < 1105) Width = 1105;
			if (Height < 530) Height = 530;

			btn_Apply     .Text = "apply this spell\'s data";
			tree_Highlight.Text = "highlight blank SpellInfo nodes";
//			addNode       .Text = "add node: spell";

			tree_Highlight.Checked = false;
		}

		/* <summary>
		/// Updates any InfoVersion for the spells when the 2da loads. Ensures
		/// that spell-info does not have a CoreAI version if there's no other
		/// data and that it does have a CoreAI version if there is.
		/// NOTE: There won't be any SpellChanged structs at this point although
		/// this can create such changed-structs - which is the point.
		/// </summary>
		void InfoVersionLoad_spells()
		{
			Spell spell;

			int spellinfo, ver;

			int total = Spells.Count;
			for (int id = 0; id != total; ++id)
			{
				spell = Spells[id];
				spellinfo = spell.spellinfo;

				if (spellinfo != 0)
				{
					ver = (spellinfo & HENCH_SPELL_INFO_VERSION_MASK);

					if (ver == 0) // insert the default spell-version if it doesn't exist
					{
						ver = HENCH_SPELL_INFO_VERSION;
					}
					else if (ver == spellinfo) // clear the spell-version if that's the only data in spellinfo
					{
						ver = 0;
					}
					else
						continue;


					spellinfo &= ~HENCH_SPELL_INFO_VERSION_MASK;
					spellinfo |= ver;

					var spellchanged = new SpellChanged();

					spellchanged.targetinfo   = spell.targetinfo;
					spellchanged.effectweight = spell.effectweight;
					spellchanged.effecttypes  = spell.effecttypes;
					spellchanged.damageinfo   = spell.damageinfo;
					spellchanged.savetype     = spell.savetype;
					spellchanged.savedctype   = spell.savedctype;

					spellchanged.spellinfo = spellinfo;

					SpellsChanged[id] = spellchanged;

					spell.differ = bit_spellinfo;
					Spells[id] = spell;

					Tree.Nodes[id].ForeColor = Color.Crimson;
				}
			}

			InfoVersionUpdate       =
			applyGlobal    .Enabled =
			gotoNextChanged.Enabled = (SpellsChanged.Count != 0);
		} */


		/// <summary>
		/// Loads a HenchRacial.2da file.
		/// If the file is not a valid HenchRacial.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		/// <param name="rows"></param>
		void Load_HenchRacial(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new tabcontrol_Racial(this);
			splitContainer1.Panel2.Controls.Add(HenchControl);

			// TODO: size the form appropriately

			Type = Type2da.TYPE_RACIAL;

			ClearData();


			string[] fields;
			string field;

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					fields = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(fields[0], out id)) // is a valid 2da row
					{
						var race = new Race();

						race.id        = id;
						race.isChanged = false;
						race.differ    = tabcontrol_Racial.bit_clear;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != blank)
							race.label = field;
						else
							race.label = String.Empty;

						if ((field = fields[++col]) != blank)
							race.flags = Int32.Parse(field);
						else
							race.flags = 0;

						if ((field = fields[++col]) != blank)
							race.feat1 = Int32.Parse(field);
						else
							race.feat1 = 0;

						if ((field = fields[++col]) != blank)
							race.feat2 = Int32.Parse(field);
						else
							race.feat2 = 0;

						if ((field = fields[++col]) != blank)
							race.feat3 = Int32.Parse(field);
						else
							race.feat3 = 0;

						if ((field = fields[++col]) != blank)
							race.feat4 = Int32.Parse(field);
						else
							race.feat4 = 0;

						if ((field = fields[++col]) != blank)
							race.feat5 = Int32.Parse(field);
						else
							race.feat5 = 0;

						Races.Add(race);	// race-structs can now be referenced in the 'Races' list by their
					}						// - Races[id]
				}							// - HenchRacial.2da row#
			}								// - SubRaceID (RacialSubtypes.2da row#)

			GrowTree();

			EnableCopy(true);

			// check if any info-version(s) need to be updated in flags-int.
//			InfoVersionLoad_racial();


			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width  < 905) Width  = 905;
			if (Height < 350) Height = 350;

			btn_Apply     .Text = "apply this race\'s data";
			tree_Highlight.Text = "highlight blank Racial flags nodes";
//			addNode       .Text = "add node: race";

			tree_Highlight.Checked = false;
		}

		/* <summary>
		/// Updates any InfoVersion for the races when the 2da loads. Ensures
		/// that racial-flags has a CoreAI version - RacialFlags always has a
		/// Version (unlike spellinfo).
		/// NOTE: There won't be any RaceChanged structs at this point although
		/// this can create such changed-structs - which is the point.
		/// </summary>
		void InfoVersionLoad_racial()
		{
			Race race;

			int total = Races.Count;
			for (int id = 0; id != total; ++id)
			{
				race = Races[id];
				if ((race.flags & HENCH_SPELL_INFO_VERSION_MASK) == 0)
				{
					var racechanged = new RaceChanged();

					racechanged.feat1 = race.feat1;
					racechanged.feat2 = race.feat2;
					racechanged.feat3 = race.feat3;
					racechanged.feat4 = race.feat4;
					racechanged.feat5 = race.feat5;

					racechanged.flags = (race.flags | HENCH_SPELL_INFO_VERSION); // insert the default version #

					RacesChanged[id] = racechanged;

					race.differ = bit_flags;
					Races[id] = race;

					Tree.Nodes[id].ForeColor = Color.Crimson;
				}
			}

			InfoVersionUpdate       =
			applyGlobal    .Enabled =
			gotoNextChanged.Enabled = (RacesChanged.Count != 0);
		} */


		/// <summary>
		/// Loads a HenchClasses.2da file.
		/// If the file is not a valid HenchClasses.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		/// <param name="rows"></param>
		void Load_HenchClasses(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new tabcontrol_Classes(this);
			splitContainer1.Panel2.Controls.Add(HenchControl);

			// TODO: size the form appropriately

			Type = Type2da.TYPE_CLASSES;

			ClearData();


			string[] fields;
			string field;

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					fields = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(fields[0], out id)) // is a valid 2da row
					{
						var @class = new Class();

						@class.id        = id;
						@class.isChanged = false;
						@class.differ    = tabcontrol_Classes.bit_clear;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != blank)
							@class.label = field;
						else
							@class.label = String.Empty;

						if ((field = fields[++col]) != blank)
							@class.flags = Int32.Parse(field);
						else
							@class.flags = 0;

						if ((field = fields[++col]) != blank)
							@class.feat1 = Int32.Parse(field);
						else
							@class.feat1 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat2 = Int32.Parse(field);
						else
							@class.feat2 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat3 = Int32.Parse(field);
						else
							@class.feat3 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat4 = Int32.Parse(field);
						else
							@class.feat4 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat5 = Int32.Parse(field);
						else
							@class.feat5 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat6 = Int32.Parse(field);
						else
							@class.feat6 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat7 = Int32.Parse(field);
						else
							@class.feat7 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat8 = Int32.Parse(field);
						else
							@class.feat8 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat9 = Int32.Parse(field);
						else
							@class.feat9 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat10 = Int32.Parse(field);
						else
							@class.feat10 = 0;

						if ((field = fields[++col]) != blank)
							@class.feat11 = Int32.Parse(field);
						else
							@class.feat11 = 0;

						Classes.Add(@class);	// class-structs can now be referenced in the 'Classes' list by their
					}							// - Classes[id]
				}								// - HenchClasses.2da row#
			}									// - ClassID (Classes.2da row#)

			GrowTree();

			EnableCopy(true);

			// check if any info-version(s) need to be updated in flags-int.
//			InfoVersionLoad_classes();

			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width  < 1355) Width  = 1355;
			if (Height <  400) Height = 400;

			btn_Apply     .Text = "apply this class\' data";
			tree_Highlight.Text = "highlight blank Class flags nodes";
//			addNode       .Text = "add node: class";

			tree_Highlight.Checked = false;
		}

		/* <summary>
		/// Updates any InfoVersion for the classes when the 2da loads. Ensures
		/// that class-flags has a CoreAI version - ClassFlags always has a
		/// Version (unlike spellinfo).
		/// NOTE: There won't be any ClassChanged structs at this point although
		/// this can create such changed-structs - which is the point.
		/// </summary>
		void InfoVersionLoad_classes()
		{
			Class @class;

			int total = Classes.Count;
			for (int id = 0; id != total; ++id)
			{
				@class = Classes[id];
				if ((@class.flags & HENCH_SPELL_INFO_VERSION_MASK) == 0)
				{
					var classchanged = new ClassChanged();

					classchanged.feat1  = @class.feat1;
					classchanged.feat2  = @class.feat2;
					classchanged.feat3  = @class.feat3;
					classchanged.feat4  = @class.feat4;
					classchanged.feat5  = @class.feat5;
					classchanged.feat6  = @class.feat6;
					classchanged.feat7  = @class.feat7;
					classchanged.feat8  = @class.feat8;
					classchanged.feat9  = @class.feat9;
					classchanged.feat10 = @class.feat10;
					classchanged.feat11 = @class.feat11;

					classchanged.flags = (@class.flags | HENCH_SPELL_INFO_VERSION); // insert the default version #

					ClassesChanged[id] = classchanged;

					@class.differ = bit_flags;
					Classes[id] = @class;

					Tree.Nodes[id].ForeColor = Color.Crimson;
				}
			}

			InfoVersionUpdate       =
			applyGlobal    .Enabled =
			gotoNextChanged.Enabled = (ClassesChanged.Count != 0);
		} */


		/// <summary>
		/// Populates nodes in the tree.
		/// </summary>
		void GrowTree()
		{
			MenuEnable();

			Tree.BeginUpdate();

			Tree.Nodes.Clear();


			TreeNode node;
			string text;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
				{
					var pb = new ProgBar(); // populating the spells-tree takes a second or 3.
					pb.ValTop = Spells.Count;
					pb.Show();

					int preLength = (Spells.Count - 1).ToString().Length + 1;

					foreach (var spell in Spells)
					{
						text = spell.id.ToString();
						if (hasLabels)
						{
							if (!String.IsNullOrEmpty(spell.label))
							{
								while (text.Length != preLength)
									text += " ";

								text += spell.label;
							}
						}
						else if (spellLabels.Count != 0 && spellLabels.Count > spell.id)
						{
							if (!String.IsNullOrEmpty(spellLabels[spell.id]))
							{
								while (text.Length != preLength)
									text += " ";

								text += spellLabels[spell.id];
							}
						}
						node = Tree.Nodes.Add(text);

						if (spell.isChanged) // for Click_insertSpellLabels()
							node.ForeColor = Color.Blue;

						pb.Step();
					}
					break;
				}

				case Type2da.TYPE_RACIAL:
				{
					int preLength = (Races.Count - 1).ToString().Length + 1;

					foreach (var race in Races)
					{
						text = race.id.ToString();
						if (hasLabels)
						{
							if (!String.IsNullOrEmpty(race.label))
							{
								while (text.Length != preLength)
									text += " ";

								text += race.label;
							}
						}
						else if (raceLabels.Count != 0 && raceLabels.Count > race.id)
						{
							if (!String.IsNullOrEmpty(raceLabels[race.id]))
							{
								while (text.Length != preLength)
									text += " ";

								text += raceLabels[race.id];
							}
						}
						node = Tree.Nodes.Add(text);

						if (race.isChanged) // for Click_insertRaceLabels()
							node.ForeColor = Color.Blue;
					}
					break;
				}

				case Type2da.TYPE_CLASSES:
				{
					int preLength = (Classes.Count - 1).ToString().Length + 1;

					foreach (var @class in Classes)
					{
						text = @class.id.ToString();
						if (hasLabels)
						{
							if (!String.IsNullOrEmpty(@class.label))
							{
								while (text.Length != preLength)
									text += " ";

								text += @class.label;
							}
						}
						else if (classLabels.Count != 0 && classLabels.Count > @class.id)
						{
							if (!String.IsNullOrEmpty(classLabels[@class.id]))
							{
								while (text.Length != preLength)
									text += " ";

								text += classLabels[@class.id];
							}
						}
						node = Tree.Nodes.Add(text);

						if (@class.isChanged) // for Click_insertClassLabels()
							node.ForeColor = Color.Blue;
					}
					break;
				}
			}


			text = String.Empty;
			int width = 0;
			for (int i = 0; i != Tree.Nodes.Count; ++i)
			{
				if ((node = Tree.Nodes[i]).Text.Length > width)
				{
					text  = node.Text;
					width = node.Text.Length;
				}
			}
			width = Math.Max(225, TextRenderer.MeasureText(text, Font).Width + 22);
			splitContainer1.SplitterDistance = width;


			Tree.EndUpdate();

			ResumeLayout();
		}

		/// <summary>
		/// Enables several menu-items.
		/// NOTE: Calls to this need to be adjusted if a Close 2da function is
		/// added - and perhaps if a 2da fails to load leaving a blank tree.
		/// </summary>
		void MenuEnable()
		{
			Save            .Enabled = // file ->
			Saveas          .Enabled =

			Copy_decimal    .Enabled = // edit ->
			Copy_hexadecimal.Enabled =
			Copy_binary     .Enabled =

			clearCoreAIver  .Enabled = true; // TODO: Refine. TonyAI 2.2 SpellInfo bits are totally incompatible w/ 2.3+

			tree_Highlight  .Visible = true;
		}
		#endregion Load


		#region SpellTree node-select
		/// <summary>
		/// Handles AfterSelect event for nodes in the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AfterSelect_node(object sender, TreeViewEventArgs e)
		{
			Id = Tree.SelectedNode.Index;

			BypassDiffer = true;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					(HenchControl as tabcontrol_Spells).SelectSpell(Spells[Id], SpellsChanged, Id);
					break;

				case Type2da.TYPE_RACIAL:
					(HenchControl as tabcontrol_Racial).SelectRace(Races[Id], RacesChanged, Id);
					break;

				case Type2da.TYPE_CLASSES:
					(HenchControl as tabcontrol_Classes).SelectClass(Classes[Id], ClassesChanged, Id);
					break;
			}

			BypassDiffer = false;
		}
		#endregion SpellTree node-select


		internal void EnableCopy(bool enabled)
		{
			Copy_hexadecimal.Enabled =
			Copy_binary     .Enabled = enabled;
		}

		internal void SetNodeColor(Color color)
		{
			Tree.SelectedNode.ForeColor = color;
		}

		internal void SetEnabled(bool differs)
		{
			bool changes = false;
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:  changes = (SpellsChanged .Count != 0); break;
				case Type2da.TYPE_RACIAL:  changes = (RacesChanged  .Count != 0); break;
				case Type2da.TYPE_CLASSES: changes = (ClassesChanged.Count != 0); break;
			}
			btn_Apply     .Enabled = differs;
			it_ApplyGlobal.Enabled = differs || changes;
			it_GotoChanged.Enabled = differs || changes || SpareChange();
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
		/// Handler for the "apply changed data to currently selected
		/// spell/race/class" button. See also <see cref="ApplyDirtyData"/>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_apply(object sender, EventArgs e)
		{
			Text = "nwn2_ai_2da_editor - " + _pfe + " *"; // titlebar text (append path of saved file + asterisk)

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
				{
					Spell spell = Spells[Id];
					if (spell.differ != tabcontrol_Spells.bit_clear)
					{
						spell.differ = tabcontrol_Spells.bit_clear;
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

						(HenchControl as tabcontrol_Spells).SetResetColor(DefaultForeColor);
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

				case Type2da.TYPE_RACIAL:
				{
					Race race = Races[Id];
					if (race.differ != tabcontrol_Racial.bit_clear)
					{
						race.differ = tabcontrol_Racial.bit_clear;
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

						(HenchControl as tabcontrol_Racial).SetResetColor(DefaultForeColor);

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

				case Type2da.TYPE_CLASSES:
				{
					Class @class = Classes[Id];
					if (@class.differ != tabcontrol_Classes.bit_clear)
					{
						@class.differ = tabcontrol_Classes.bit_clear;
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

						(HenchControl as tabcontrol_Classes).SetResetColor(DefaultForeColor);
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


		#region Utilities
		/// <summary>
		/// Value of epsilon.
		/// </summary>
		const float epsilon = 0.0001f;

		/// <summary>
		/// Checks if two floats are within epsilon.
		/// note: Does not handle NaNs, infinities or whathaveya.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>true if equal enough</returns>
		internal static bool FloatsEqual(float a, float b)
		{
			return Math.Abs(b - a) < epsilon;
		}

		/// <summary>
		/// Formats a float to a string that is consistent with a 2da-field.
		/// </summary>
		/// <param name="f"></param>
		/// <returns>string of a float</returns>
		internal static string Float2daFormat(float f)
		{
			string str = f.ToString();
			return (str.IndexOf('.') == -1) ? str.Insert(str.Length, ".0")
											: str;
		}
		#endregion Utilities


		#region Search
		/// <summary>
		/// Handler for pressing the Enter-key when either the search-textbox or
		/// the spell-tree is focused.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void KeyPress_search(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				Click_search(null, EventArgs.Empty);
				e.Handled = true;
			}
		}

		/// <summary>
		/// Handler for clicking the Search btns.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_search(object sender, EventArgs e)
		{
			int total = Tree.Nodes.Count;
			if (total > 1)
			{
				string text = tb_Search.Text;
				if (!String.IsNullOrEmpty(text))
				{
					text = text.ToLower();

					int id;

					var btn = sender as Button;
					if (btn == btn_Search_d || btn == null)
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
								System.Media.SystemSounds.Beep.Play();
								break;
							}

							if (++id == total) // wrap to first node
							{
								id = 0;
							}
						}
					}
					else //if (btn == btn_Search_u)
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
								System.Media.SystemSounds.Beep.Play();
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
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_treeHighlight(object sender, EventArgs e)
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
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
							if      (spell.differ != tabcontrol_Spells.bit_clear) color = Color.Crimson;
							else if (spell.isChanged)                             color = Color.Blue;
							else                                                  color = DefaultForeColor;

							Tree.Nodes[id].ForeColor = color;
						}
					}
					break;
				}

				case Type2da.TYPE_RACIAL:
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
							if      (race.differ != tabcontrol_Racial.bit_clear) color = Color.Crimson;
							else if (race.isChanged)                             color = Color.Blue;
							else                                                 color = DefaultForeColor;

							Tree.Nodes[id].ForeColor = color;
						}
					}
					break;
				}

				case Type2da.TYPE_CLASSES:
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
							if      (@class.differ != tabcontrol_Classes.bit_clear) color = Color.Crimson;
							else if (@class.isChanged)                              color = Color.Blue;
							else                                                    color = DefaultForeColor;

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
		// Load_Hench*() functs. And uncomment Type2da.TYPE_NONE
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
			if (Type != Type2da.TYPE_NONE)
			{
				int id = Tree.Nodes.Count;
				switch (Type)
				{
					case Type2da.TYPE_SPELLS:
						AddSpell(id);
						break;

					case Type2da.TYPE_RACIAL:
						AddRace(id);
						break;

					case Type2da.TYPE_CLASSES:
						AddClass(id);
						break;
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
			spell.differ    = bit_clear;

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
			race.differ    = bit_clear;

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
