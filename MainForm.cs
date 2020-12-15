using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	#region MainForm
	/// <summary>
	/// The MainForm is the only form.
	/// </summary>
	public partial class MainForm
		:
			Form
	{
		#region class Vars
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
		List<Spell> Spells = new List<Spell>();

		/// <summary>
		/// A dictionary-object that contains structs of any spell that has been
		/// changed by the editor.
		/// </summary>
		Dictionary<int, SpellChanged> SpellsChanged = new Dictionary<int, SpellChanged>();

		/// <summary>
		/// A list-object that contains structs of all races currently in
		/// HenchRacial.2da.
		/// </summary>
		List<Race> Races = new List<Race>();

		/// <summary>
		/// A dictionary-object that contains structs of any race that has been
		/// changed by the editor.
		/// </summary>
		Dictionary<int, RaceChanged> RacesChanged = new Dictionary<int, RaceChanged>();

		/// <summary>
		/// A list-object that contains structs of all classes currently in
		/// HenchClasses.2da.
		/// </summary>
		List<Class> Classes = new List<Class>();

		/// <summary>
		/// A dictionary-object that contains structs of any class that has been
		/// changed by the editor.
		/// </summary>
		Dictionary<int, ClassChanged> ClassesChanged = new Dictionary<int, ClassChanged>();

		/// <summary>
		/// The currently selected node in the Tree.
		/// </summary>
		int Id
		{ get; set; }

		/// <summary>
		/// A boolean that prevents firing the TextChanged handlers when true.
		/// That is don't fire the text-changed event when the tree is initially
		/// populated or is being re-populated.
		/// </summary>
		bool bypassDiffer;

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
		public MainForm()
		{
			// The InitializeComponent() call is required for Windows Forms designer support.
			InitializeComponent();
			// Add constructor code after the InitializeComponent() call.


			logfile.CreateLog(); // NOTE: The logfile works in debug-builds only.
			// To write a line to the logfile:
			// logfile.Log("what you want to know here");
			//
			// The logfile ought appear in the directory with the executable.


// HenchSpells
			SpellInfo_hex  .BackColor = // set the backgrounds of the hexadecimal and binary
			SpellInfo_bin  .BackColor = // textboxes to blend in with the Form's background
			TargetInfo_hex .BackColor =
			TargetInfo_bin .BackColor =
			EffectTypes_hex.BackColor =
			EffectTypes_bin.BackColor =
			DamageInfo_hex .BackColor =
			DamageInfo_bin .BackColor =
			SaveType_hex   .BackColor =
			SaveType_bin   .BackColor =
			SaveDCType_hex .BackColor =
			SaveDCType_bin .BackColor =

// HenchRacial
			RacialFlags_hex.BackColor =
			RacialFlags_bin.BackColor =
			RacialFeat1_hex.BackColor =
			RacialFeat1_bin.BackColor =
			RacialFeat2_hex.BackColor =
			RacialFeat2_bin.BackColor =
			RacialFeat3_hex.BackColor =
			RacialFeat3_bin.BackColor =
			RacialFeat4_hex.BackColor =
			RacialFeat4_bin.BackColor =
			RacialFeat5_hex.BackColor =
			RacialFeat5_bin.BackColor =

// HenchClasses
			ClassFlags_hex .BackColor =
			ClassFlags_bin .BackColor =
			ClassFeat1_hex .BackColor =
			ClassFeat1_bin .BackColor =
			ClassFeat2_hex .BackColor =
			ClassFeat2_bin .BackColor =
			ClassFeat3_hex .BackColor =
			ClassFeat3_bin .BackColor =
			ClassFeat4_hex .BackColor =
			ClassFeat4_bin .BackColor =
			ClassFeat5_hex .BackColor =
			ClassFeat5_bin .BackColor =
			ClassFeat6_hex .BackColor =
			ClassFeat6_bin .BackColor =
			ClassFeat7_hex .BackColor =
			ClassFeat7_bin .BackColor =
			ClassFeat8_hex .BackColor =
			ClassFeat8_bin .BackColor =
			ClassFeat9_hex .BackColor =
			ClassFeat9_bin .BackColor =
			ClassFeat10_hex.BackColor =
			ClassFeat10_bin.BackColor =
			ClassFeat11_hex.BackColor =
			ClassFeat11_bin.BackColor = BackColor;


			PopulateSpellInfoComboboxes();
			PopulateTargetInfoComboboxes();
			PopulateDamageInfoComboboxes();
			PopulateSaveTypeComboboxes();
			PopulateSaveDcTypeComboboxes();

			PopulateClassComboboxes();


			// set unicode text on the up/down Search btns.
			btn_Search_d.Text = "\u25bc"; // down triangle
			btn_Search_u.Text = "\u25b2"; // up triangle

			ActiveControl = tb_Search; // focus the Search-box


			Size = new Size(800, 480);

			// position the Racial and Classes tab-pages to their appropriate location
			cols_HenchRacial .Location =
			cols_HenchClasses.Location = cols_HenchSpells.Location;


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

							if (InfoVersionUpdate)
							{
								InfoVersionUpdate = false;
								MessageBox.Show("InfoVersion(s) have been updated.",
												"  InfoVersion update",
												MessageBoxButtons.OK,
												MessageBoxIcon.Information,
												MessageBoxDefaultButton.Button1);
							}
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
			Type = Type2da.TYPE_SPELLS;

			ClearData();

			cols_HenchSpells .Visible = true;
			cols_HenchRacial .Visible =
			cols_HenchClasses.Visible = false;

			SpellInfo_reset   .ForeColor =
			TargetInfo_reset  .ForeColor =
			EffectWeight_reset.ForeColor =
			EffectTypes_reset .ForeColor =
			DamageInfo_reset  .ForeColor =
			SaveType_reset    .ForeColor =
			SaveDCType_reset  .ForeColor = DefaultForeColor;


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
						spell.differ    = bit_clear;

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

			// check if any info-version(s) need to be updated in spellinfo-int.
			InfoVersionLoad_spells();

			// Groups on SpellInfo and TargetInfo generally stay green
			// unless SpellInfo is flagged as a MasterID
			GroupColor(si_SpelltypeGrp,  Color.LimeGreen);
			GroupColor(si_FlagsGrp,      Color.LimeGreen);
			GroupColor(si_SpelllevelGrp, Color.LimeGreen);
			GroupColor(si_ChildIDGrp,    Color.LimeGreen);

			GroupColor(ti_FlagsGrp,  Color.LimeGreen);
			GroupColor(ti_ShapeGrp,  Color.LimeGreen);
			GroupColor(ti_RangeGrp,  Color.LimeGreen);
			GroupColor(ti_RadiusGrp, Color.LimeGreen);

			si_hostile.ForeColor = DefaultForeColor; // set the DETRIMENTAL/BENEFICIAL label back to default-color.

			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width < 1105) Width = 1105;
			if (Height < 530) Height = 530;

			apply         .Text = "apply this spell\'s data";
			tree_Highlight.Text = "highlight blank SpellInfo nodes";
//			addNode       .Text = "add node: spell";

			tree_Highlight.Checked = false;
		}

		/// <summary>
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
		}


		/// <summary>
		/// Loads a HenchRacial.2da file.
		/// If the file is not a valid HenchRacial.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		/// <param name="rows"></param>
		void Load_HenchRacial(string[] rows)
		{
			Type = Type2da.TYPE_RACIAL;

			ClearData();

			cols_HenchSpells .Visible = false;
			cols_HenchRacial .Visible = true;
			cols_HenchClasses.Visible = false;

			RacialFlags_reset.ForeColor =
			RacialFeat1_reset.ForeColor =
			RacialFeat2_reset.ForeColor =
			RacialFeat3_reset.ForeColor =
			RacialFeat4_reset.ForeColor =
			RacialFeat5_reset.ForeColor = DefaultForeColor;


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
						race.differ    = bit_clear;

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

			// check if any info-version(s) need to be updated in flags-int.
			InfoVersionLoad_racial();


			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width  < 905) Width  = 905;
			if (Height < 350) Height = 350;

			apply         .Text = "apply this race\'s data";
			tree_Highlight.Text = "highlight blank Racial flags nodes";
//			addNode       .Text = "add node: race";

			tree_Highlight.Checked = false;
		}

		/// <summary>
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
		}


		/// <summary>
		/// Loads a HenchClasses.2da file.
		/// If the file is not a valid HenchClasses.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		/// <param name="rows"></param>
		void Load_HenchClasses(string[] rows)
		{
			Type = Type2da.TYPE_CLASSES;

			ClearData();

			cols_HenchSpells .Visible =
			cols_HenchRacial .Visible = false;
			cols_HenchClasses.Visible = true;

			ClassFlags_reset .ForeColor =
			ClassFeat1_reset .ForeColor =
			ClassFeat2_reset .ForeColor =
			ClassFeat3_reset .ForeColor =
			ClassFeat4_reset .ForeColor =
			ClassFeat5_reset .ForeColor =
			ClassFeat6_reset .ForeColor =
			ClassFeat7_reset .ForeColor =
			ClassFeat8_reset .ForeColor =
			ClassFeat9_reset .ForeColor =
			ClassFeat10_reset.ForeColor =
			ClassFeat11_reset.ForeColor = DefaultForeColor;


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
						var clas = new Class();

						clas.id        = id;
						clas.isChanged = false;
						clas.differ    = bit_clear;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != blank)
							clas.label = field;
						else
							clas.label = String.Empty;

						if ((field = fields[++col]) != blank)
							clas.flags = Int32.Parse(field);
						else
							clas.flags = 0;

						if ((field = fields[++col]) != blank)
							clas.feat1 = Int32.Parse(field);
						else
							clas.feat1 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat2 = Int32.Parse(field);
						else
							clas.feat2 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat3 = Int32.Parse(field);
						else
							clas.feat3 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat4 = Int32.Parse(field);
						else
							clas.feat4 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat5 = Int32.Parse(field);
						else
							clas.feat5 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat6 = Int32.Parse(field);
						else
							clas.feat6 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat7 = Int32.Parse(field);
						else
							clas.feat7 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat8 = Int32.Parse(field);
						else
							clas.feat8 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat9 = Int32.Parse(field);
						else
							clas.feat9 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat10 = Int32.Parse(field);
						else
							clas.feat10 = 0;

						if ((field = fields[++col]) != blank)
							clas.feat11 = Int32.Parse(field);
						else
							clas.feat11 = 0;

						Classes.Add(clas);	// class-structs can now be referenced in the 'Classes' list by their
					}						// - Classes[id]
				}							// - HenchClasses.2da row#
			}								// - ClassID (Classes.2da row#)

			GrowTree();

			// check if any info-version(s) need to be updated in flags-int.
			InfoVersionLoad_classes();

			// TODO: this doesn't work as intended if the window is currently
			// maximized.
			if (Width  < 1355) Width  = 1355;
			if (Height <  400) Height = 400;

			apply         .Text = "apply this class\' data";
			tree_Highlight.Text = "highlight blank Class flags nodes";
//			addNode       .Text = "add node: class";

			tree_Highlight.Checked = false;
		}

		/// <summary>
		/// Updates any InfoVersion for the classes when the 2da loads. Ensures
		/// that class-flags has a CoreAI version - ClassFlags always has a
		/// Version (unlike spellinfo).
		/// NOTE: There won't be any ClassChanged structs at this point although
		/// this can create such changed-structs - which is the point.
		/// </summary>
		void InfoVersionLoad_classes()
		{
			Class clas;

			int total = Classes.Count;
			for (int id = 0; id != total; ++id)
			{
				clas = Classes[id];
				if ((clas.flags & HENCH_SPELL_INFO_VERSION_MASK) == 0)
				{
					var claschanged = new ClassChanged();

					claschanged.feat1  = clas.feat1;
					claschanged.feat2  = clas.feat2;
					claschanged.feat3  = clas.feat3;
					claschanged.feat4  = clas.feat4;
					claschanged.feat5  = clas.feat5;
					claschanged.feat6  = clas.feat6;
					claschanged.feat7  = clas.feat7;
					claschanged.feat8  = clas.feat8;
					claschanged.feat9  = clas.feat9;
					claschanged.feat10 = clas.feat10;
					claschanged.feat11 = clas.feat11;

					claschanged.flags = (clas.flags | HENCH_SPELL_INFO_VERSION); // insert the default version #

					ClassesChanged[id] = claschanged;

					clas.differ = bit_flags;
					Classes[id] = clas;

					Tree.Nodes[id].ForeColor = Color.Crimson;
				}
			}

			InfoVersionUpdate       =
			applyGlobal    .Enabled =
			gotoNextChanged.Enabled = (ClassesChanged.Count != 0);
		}


		/// <summary>
		/// Populates nodes in the tree.
		/// </summary>
		void GrowTree()
		{
			MenuEnable();

			Tree.BeginUpdate();

			Tree.Nodes.Clear();

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
				{
					var pb = new ProgBar(); // populating the spells-tree takes a second or 3.
					pb.ValTop = Spells.Count;
					pb.Show();

					TreeNode node;
					string text;

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
					TreeNode node;
					string text;

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
					TreeNode node;
					string text;

					int preLength = (Classes.Count - 1).ToString().Length + 1;

					foreach (var clas in Classes)
					{
						text = clas.id.ToString();
						if (hasLabels)
						{
							if (!String.IsNullOrEmpty(clas.label))
							{
								while (text.Length != preLength)
									text += " ";

								text += clas.label;
							}
						}
						else if (classLabels.Count != 0 && classLabels.Count > clas.id)
						{
							if (!String.IsNullOrEmpty(classLabels[clas.id]))
							{
								while (text.Length != preLength)
									text += " ";

								text += classLabels[clas.id];
							}
						}
						node = Tree.Nodes.Add(text);

						if (clas.isChanged) // for Click_insertClassLabels()
							node.ForeColor = Color.Blue;
					}
					break;
				}
			}

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

			setCoreAIver    .Enabled = true;
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

			bypassDiffer = true;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					SelectSpell();
					break;

				case Type2da.TYPE_RACIAL:
					SelectRace();
					break;

				case Type2da.TYPE_CLASSES:
					SelectClass();
					break;
			}

			bypassDiffer = false;
		}

		/// <summary>
		/// Fills displayed fields w/ data from the spell's Id.
		/// </summary>
		void SelectSpell()
		{
			SpellInfo_text   .Clear(); // clear the info-fields to force TextChanged events ->
			TargetInfo_text  .Clear();
			EffectWeight_text.Clear();
			EffectTypes_text .Clear();
			DamageInfo_text  .Clear();
			SaveType_text    .Clear();
			SaveDCType_text  .Clear();


			Spell spell = Spells[Id];

			bool dirty = (spell.differ != bit_clear);

// SpellInfo
			int val = spell.spellinfo;
			SpellInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].spellinfo;
			}
			SpellInfo_text.Text = val.ToString();

// TargetInfo
			val = spell.targetinfo;
			TargetInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].targetinfo;
			}
			TargetInfo_text.Text = val.ToString();

// EffectWeight
			string text = FormatFloat(spell.effectweight);
			EffectWeight_reset.Text = text;

			if (dirty)
			{
				text = FormatFloat(SpellsChanged[Id].effectweight);
			}
			EffectWeight_text.Text = text;

// EffectTypes
			val = spell.effecttypes;
			EffectTypes_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].effecttypes;
			}
			EffectTypes_text.Text = val.ToString();

// DamageInfo
			val = spell.damageinfo;
			DamageInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].damageinfo;
			}
			DamageInfo_text.Text = val.ToString();

// SaveType
			val = spell.savetype;
			SaveType_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].savetype;
			}
			SaveType_text.Text = val.ToString();

// SaveDCType
			val = spell.savedctype;
			SaveDCType_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].savedctype;
			}
			SaveDCType_text.Text = val.ToString();
		}

		/// <summary>
		/// Fills displayed fields w/ data from the race's Id.
		/// </summary>
		void SelectRace()
		{
			RacialFlags_text.Clear(); // clear the info-fields to force TextChanged events ->
			RacialFeat1_text.Clear();
			RacialFeat2_text.Clear();
			RacialFeat3_text.Clear();
			RacialFeat4_text.Clear();
			RacialFeat5_text.Clear();


			Race race = Races[Id];

			bool dirty = (race.differ != bit_clear);

// Flags
			int val = race.flags;
			RacialFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].flags;
			}
			RacialFlags_text.Text = val.ToString();

// Feat1
			val = race.feat1;
			RacialFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat1;
			}
			RacialFeat1_text.Text = val.ToString();

// Feat2
			val = race.feat2;
			RacialFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat2;
			}
			RacialFeat2_text.Text = val.ToString();

// Feat3
			val = race.feat3;
			RacialFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat3;
			}
			RacialFeat3_text.Text = val.ToString();

// Feat4
			val = race.feat4;
			RacialFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat4;
			}
			RacialFeat4_text.Text = val.ToString();

// Feat5
			val = race.feat5;
			RacialFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat5;
			}
			RacialFeat5_text.Text = val.ToString();
		}

		/// <summary>
		/// Fills displayed fields w/ data from the class' Id.
		/// </summary>
		void SelectClass()
		{
			ClassFlags_text .Clear(); // clear the info-fields to force TextChanged events ->
			ClassFeat1_text .Clear();
			ClassFeat2_text .Clear();
			ClassFeat3_text .Clear();
			ClassFeat4_text .Clear();
			ClassFeat5_text .Clear();
			ClassFeat6_text .Clear();
			ClassFeat7_text .Clear();
			ClassFeat8_text .Clear();
			ClassFeat9_text .Clear();
			ClassFeat10_text.Clear();
			ClassFeat11_text.Clear();


			Class clas = Classes[Id];

			bool dirty = (clas.differ != bit_clear);

// Flags
			int val = clas.flags;
			ClassFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].flags;
			}
			ClassFlags_text.Text = val.ToString();

// Feat1
			val = clas.feat1;
			ClassFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat1;
			}
			ClassFeat1_text.Text = val.ToString();

// Feat2
			val = clas.feat2;
			ClassFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat2;
			}
			ClassFeat2_text.Text = val.ToString();

// Feat3
			val = clas.feat3;
			ClassFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat3;
			}
			ClassFeat3_text.Text = val.ToString();

// Feat4
			val = clas.feat4;
			ClassFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat4;
			}
			ClassFeat4_text.Text = val.ToString();

// Feat5
			val = clas.feat5;
			ClassFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat5;
			}
			ClassFeat5_text.Text = val.ToString();

// Feat6
			val = clas.feat6;
			ClassFeat6_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat6;
			}
			ClassFeat6_text.Text = val.ToString();

// Feat7
			val = clas.feat7;
			ClassFeat7_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat7;
			}
			ClassFeat7_text.Text = val.ToString();

// Feat8
			val = clas.feat8;
			ClassFeat8_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat8;
			}
			ClassFeat8_text.Text = val.ToString();

// Feat9
			val = clas.feat9;
			ClassFeat9_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat9;
			}
			ClassFeat9_text.Text = val.ToString();

// Feat10
			val = clas.feat10;
			ClassFeat10_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat10;
			}
			ClassFeat10_text.Text = val.ToString();

// Feat11
			val = clas.feat11;
			ClassFeat11_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat11;
			}
			ClassFeat11_text.Text = val.ToString();
		}
		#endregion SpellTree node-select


		/// <summary>
		/// Handler for selecting a tab-page.
		/// Disables the "Copy" menu-items for hexadecimal and binary if the
		/// current page is EffectWeight since its field is a float.
		/// Note: This does not fire when the program starts (and the SpellInfo
		/// tab is auto-selected) but the defaults are appropriate.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectedIndexChanged_tab(object sender, EventArgs e)
		{
			Copy_hexadecimal.Enabled =
			Copy_binary     .Enabled = Type != Type2da.TYPE_SPELLS
									|| (cols_HenchSpells.SelectedIndex != 2);
//									|| (cols_HenchSpells.SelectedTab == cols_HenchSpells.TabPages["page_EffectWeight"]);
		}

		/// <summary>
		/// Prints current value of current page's text-field to its hex-field
		/// and bin-field.
		/// </summary>
		/// <param name="val"></param>
		/// <param name="hexbox"></param>
		/// <param name="binbox"></param>
		void PrintCurrent(int val, Control hexbox, Control binbox)
		{
			string text = val.ToString("x8");
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
		/// Handler for any of the Clear-buttons.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_clear(object sender, EventArgs e)
		{
			var btn = sender as Button;
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					if      (btn == si_Clear) SpellInfo_text   .Text = "0";
					else if (btn == ti_Clear) TargetInfo_text  .Text = "0";
					else if (btn == ew_Clear) EffectWeight_text.Text = "0.0";
					else if (btn == et_Clear) EffectTypes_text .Text = "0";
					else if (btn == di_Clear) DamageInfo_text  .Text = "0";
					else if (btn == st_Clear) SaveType_text    .Text = "0";
					else                      SaveDCType_text  .Text = "0"; //if (btn == dc_Clear)
					break;

				case Type2da.TYPE_RACIAL:
					if      (btn ==  rf_Clear) RacialFlags_text.Text = "0";
					else if (btn == rf1_Clear) RacialFeat1_text.Text = "0";
					else if (btn == rf2_Clear) RacialFeat2_text.Text = "0";
					else if (btn == rf3_Clear) RacialFeat3_text.Text = "0";
					else if (btn == rf4_Clear) RacialFeat4_text.Text = "0";
					else                       RacialFeat5_text.Text = "0"; //if (btn == rf5_Clear)
					break;

				case Type2da.TYPE_CLASSES:
					if      (btn ==   cf_Clear) ClassFlags_text .Text = "0";
					else if (btn ==  cf1_Clear) ClassFeat1_text .Text = "0";
					else if (btn ==  cf2_Clear) ClassFeat2_text .Text = "0";
					else if (btn ==  cf3_Clear) ClassFeat3_text .Text = "0";
					else if (btn ==  cf4_Clear) ClassFeat4_text .Text = "0";
					else if (btn ==  cf5_Clear) ClassFeat5_text .Text = "0";
					else if (btn ==  cf6_Clear) ClassFeat6_text .Text = "0";
					else if (btn ==  cf7_Clear) ClassFeat7_text .Text = "0";
					else if (btn ==  cf8_Clear) ClassFeat8_text .Text = "0";
					else if (btn ==  cf9_Clear) ClassFeat9_text .Text = "0";
					else if (btn == cf10_Clear) ClassFeat10_text.Text = "0";
					else                        ClassFeat11_text.Text = "0"; //if (btn == cf11_Clear)
					break;
			}
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
					if (spell.differ != bit_clear)
					{
						spell.differ = bit_clear;
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

						SpellInfo_reset   .ForeColor =
						TargetInfo_reset  .ForeColor =
						EffectWeight_reset.ForeColor =
						EffectTypes_reset .ForeColor =
						DamageInfo_reset  .ForeColor =
						SaveType_reset    .ForeColor =
						SaveDCType_reset  .ForeColor = DefaultForeColor;

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
					if (race.differ != bit_clear)
					{
						race.differ = bit_clear;
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

						RacialFlags_reset.ForeColor =
						RacialFeat1_reset.ForeColor =
						RacialFeat2_reset.ForeColor =
						RacialFeat3_reset.ForeColor =
						RacialFeat4_reset.ForeColor =
						RacialFeat5_reset.ForeColor = DefaultForeColor;

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
					Class clas = Classes[Id];
					if (clas.differ != bit_clear)
					{
						clas.differ = bit_clear;
						clas.isChanged = true;

						ClassChanged claschanged = ClassesChanged[Id];

						clas.flags  = claschanged.flags;
						clas.feat1  = claschanged.feat1;
						clas.feat2  = claschanged.feat2;
						clas.feat3  = claschanged.feat3;
						clas.feat4  = claschanged.feat4;
						clas.feat5  = claschanged.feat5;
						clas.feat6  = claschanged.feat6;
						clas.feat7  = claschanged.feat7;
						clas.feat8  = claschanged.feat8;
						clas.feat9  = claschanged.feat9;
						clas.feat10 = claschanged.feat10;
						clas.feat11 = claschanged.feat11;

						Classes[Id] = clas;

						ClassesChanged.Remove(Id);

						ClassFlags_reset .ForeColor =
						ClassFeat1_reset .ForeColor =
						ClassFeat2_reset .ForeColor =
						ClassFeat3_reset .ForeColor =
						ClassFeat4_reset .ForeColor =
						ClassFeat5_reset .ForeColor =
						ClassFeat6_reset .ForeColor =
						ClassFeat7_reset .ForeColor =
						ClassFeat8_reset .ForeColor =
						ClassFeat9_reset .ForeColor =
						ClassFeat10_reset.ForeColor =
						ClassFeat11_reset.ForeColor = DefaultForeColor;

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
		/// Bitflags for spell-fields that have changed.
		/// note: The master-int 'differ' is tracked in each spell-struct but is
		/// not saved to file.
		/// </summary>
		const int bit_clear        = 0x00;
		const int bit_spellinfo    = 0x01;
		const int bit_targetinfo   = 0x02;
		const int bit_effectweight = 0x04;
		const int bit_effecttypes  = 0x08;
		const int bit_damageinfo   = 0x10;
		const int bit_savetype     = 0x20;
		const int bit_savedctype   = 0x40;

		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="spell">a Spell struct</param>
		/// <param name="spellchanged">a SpellChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		static int SpellDiffer(Spell spell, SpellChanged spellchanged)
		{
			int differ = bit_clear;

			if (spell.spellinfo != spellchanged.spellinfo)
				differ |= bit_spellinfo;

			if (spell.targetinfo != spellchanged.targetinfo)
				differ |= bit_targetinfo;

			if (!CompareFloats(spell.effectweight, spellchanged.effectweight))
				differ |= bit_effectweight;

			if (spell.effecttypes != spellchanged.effecttypes)
				differ |= bit_effecttypes;

			if (spell.damageinfo != spellchanged.damageinfo)
				differ |= bit_damageinfo;

			if (spell.savetype != spellchanged.savetype)
				differ |= bit_savetype;

			if (spell.savedctype != spellchanged.savedctype)
				differ |= bit_savedctype;

			return differ;
		}

		/// <summary>
		/// Bitflags for race- and class-fields that have changed.
		/// note: The master-int 'differ' is tracked in each struct but is not
		/// saved to file.
		/// </summary>
		const int bit_flags  = 0x001;
		const int bit_feat1  = 0x002;
		const int bit_feat2  = 0x004;
		const int bit_feat3  = 0x008;
		const int bit_feat4  = 0x010;
		const int bit_feat5  = 0x020;
		const int bit_feat6  = 0x040;
		const int bit_feat7  = 0x080;
		const int bit_feat8  = 0x100;
		const int bit_feat9  = 0x200;
		const int bit_feat10 = 0x400;
		const int bit_feat11 = 0x800;

		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="race">a Race struct</param>
		/// <param name="racechanged">a RaceChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		static int RaceDiffer(Race race, RaceChanged racechanged)
		{
			int differ = bit_clear;

			if (race.flags != racechanged.flags)
				differ |= bit_flags;

			if (race.feat1 != racechanged.feat1)
				differ |= bit_feat1;

			if (race.feat2 != racechanged.feat2)
				differ |= bit_feat2;

			if (race.feat3 != racechanged.feat3)
				differ |= bit_feat3;

			if (race.feat4 != racechanged.feat4)
				differ |= bit_feat4;

			if (race.feat5 != racechanged.feat5)
				differ |= bit_feat5;

			return differ;
		}

		/// <summary>
		/// Gets a bitwise value containing flags for fields that have changed.
		/// </summary>
		/// <param name="clas">a Class struct</param>
		/// <param name="claschanged">a ClassChanged struct</param>
		/// <returns>bitwise value containing flags for fields that have changed</returns>
		static int ClassDiffer(Class clas, ClassChanged claschanged)
		{
			int differ = bit_clear;

			if (clas.flags != claschanged.flags)
				differ |= bit_flags;

			if (clas.feat1 != claschanged.feat1)
				differ |= bit_feat1;

			if (clas.feat2 != claschanged.feat2)
				differ |= bit_feat2;

			if (clas.feat3 != claschanged.feat3)
				differ |= bit_feat3;

			if (clas.feat4 != claschanged.feat4)
				differ |= bit_feat4;

			if (clas.feat5 != claschanged.feat5)
				differ |= bit_feat5;

			if (clas.feat6 != claschanged.feat6)
				differ |= bit_feat6;

			if (clas.feat7 != claschanged.feat7)
				differ |= bit_feat7;

			if (clas.feat8 != claschanged.feat8)
				differ |= bit_feat8;

			if (clas.feat9 != claschanged.feat9)
				differ |= bit_feat9;

			if (clas.feat10 != claschanged.feat10)
				differ |= bit_feat10;

			if (clas.feat11 != claschanged.feat11)
				differ |= bit_feat11;

			return differ;
		}


		/// <summary>
		/// Value of epsilon.
		/// </summary>
		const float epsilon = 0.000001f;

		/// <summary>
		/// Checks if two floats are within epsilon.
		/// note: Does not handle NaNs, infinities or whathaveya.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>true if equal enough</returns>
		static bool CompareFloats(float a, float b)
		{
			return Math.Abs(b - a) < epsilon;
		}

		/// <summary>
		/// Formats a float to a string that is consistent with a 2da-field.
		/// </summary>
		/// <param name="f"></param>
		/// <returns>string of a float</returns>
		static string FormatFloat(float f)
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
		/// Highlights nodes on the tree that don't have info.
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
							if (spell.differ != bit_clear) color = Color.Crimson;
							else if (spell.isChanged)      color = Color.Blue;
							else                           color = DefaultForeColor;

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
							if (race.differ != bit_clear) color = Color.Crimson;
							else if (race.isChanged)      color = Color.Blue;
							else                          color = DefaultForeColor;

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
						Class clas;
						for (int id = 0; id != total; ++id)
						{
							clas = Classes[id];
							if (clas.differ != bit_clear) color = Color.Crimson;
							else if (clas.isChanged)      color = Color.Blue;
							else                          color = DefaultForeColor;

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
	#endregion MainForm



	/// <summary>
	/// Struct that holds data of each spell in HenchSpells.2da.
	/// NOTE: This data can change when the Apply-btn is clicked (but only if
	/// the spell-data has in fact been changed of c).
	/// NOTE: This is the data that gets saved to file on File|Save.
	/// </summary>
	struct Spell
	{
		public int id;
		public string label;

		public int   spellinfo;
		public int   targetinfo;
		public float effectweight;
		public int   effecttypes;
		public int   damageinfo;
		public int   savetype;
		public int   savedctype;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local spell or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchSpells.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any spell that has been modified in
	/// the editor.
	/// NOTE: These structs get created and deleted on-the-fly as stuff changes
	/// in the editor.
	/// </summary>
	struct SpellChanged
	{
		public int   spellinfo;
		public int   targetinfo;
		public float effectweight;
		public int   effecttypes;
		public int   damageinfo;
		public int   savetype;
		public int   savedctype;
	}


	/// <summary>
	/// Struct that holds data of each race in HenchRacial.2da.
	/// NOTE: This data can change when the Apply-btn is clicked (but only if
	/// the race-data has in fact been changed of c).
	/// NOTE: This is the data that gets saved to file on File|Save.
	/// </summary>
	struct Race
	{
		public int id;
		public string label;

		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local race or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchRacial.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any race that has been modified in
	/// the editor.
	/// NOTE: These structs get created and deleted on-the-fly as stuff changes
	/// in the editor.
	/// </summary>
	struct RaceChanged
	{
		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
	}


	/// <summary>
	/// Struct that holds data of each class in HenchClasses.2da.
	/// NOTE: This data can change when the Apply-btn is clicked (but only if
	/// the class-data has in fact been changed of c).
	/// NOTE: This is the data that gets saved to file on File|Save.
	/// </summary>
	struct Class
	{
		public int id;
		public string label;

		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
		public int feat6;
		public int feat7;
		public int feat8;
		public int feat9;
		public int feat10;
		public int feat11;

		// NOTE: The following fields are not saved to file ->

		/// <summary>
		/// bitwise int that holds flags for changed fields (also colors the
		/// tree-node red if not 0)
		/// </summary>
		public int differ;

		/// <summary>
		/// boolean used (along with the differ) to warn if there is modified
		/// data when exiting the app (also colors the tree-node blue if true).
		/// Set true by the Apply buttons (on local class or by global
		/// edit-operation) or by inserting labels; cleared by saving
		/// HenchClasses.2da
		/// </summary>
		public bool isChanged;
	}

	/// <summary>
	/// Struct that holds changed data of any class that has been modified in
	/// the editor.
	/// NOTE: These structs get created and deleted on-the-fly as stuff changes
	/// in the editor.
	/// </summary>
	struct ClassChanged
	{
		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;
		public int feat6;
		public int feat7;
		public int feat8;
		public int feat9;
		public int feat10;
		public int feat11;
	}



	/// <summary>
	/// Derived class for TreeView.
	/// </summary>
	sealed class CompositedTreeView
		:
			TreeView
	{
		#region Properties (override)
		/// <summary>
		/// Prevents flicker.
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000; // enable 'WS_EX_COMPOSITED'
				return cp;
			}
		}
		#endregion Properties (override)
	}
}
