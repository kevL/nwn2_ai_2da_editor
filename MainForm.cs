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
		/// The version as a build-date. This appears in the About.
		/// </summary>
		const string _version = "built - 2018 jun 26";


		/// <summary>
		/// The 'blank' 2da-string.
		/// </summary>
		const string blank = "****";

		enum Type2da
		{
			TYPE_SPELLS, // 0
			TYPE_RACIAL, // 1
			TYPE_CLASSES // 2
		}

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
		bool bypassTextChanged;

		/// <summary>
		/// A boolean that prevents firing the Checkbox Setters when true. That
		/// is don't try to force a checkbox-setting if the control is actually
		/// being clicked. It happens auto.
		/// UPDATE: But as it turns out there are bits that overlap with bits
		/// for other fields ....
		/// 
		/// This should be set TRUE only on mouse-clicks (checkboxes,
		/// radiobuttons) and text-changes (of subfields only). But leave it
		/// FALSE if a bit or bit-group shares its bits with other groups or
		/// constants - that happens only on the spell-pages.
		/// NOTE: There appears to be no harm in leaving this FALSE de facto.
		/// </summary>
//		bool bypassCheckedChecker;
		// uh The way that I coded the Racial and Classes text-changed
		// handler(s) (field(s): current) has relegated this to oblivion.


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
			SpellInfo_hex  .BackColor = BackColor; // set the backgrounds of the hexadecimal and binary
			SpellInfo_bin  .BackColor = BackColor; // textboxes to blend in with the Form's background
			TargetInfo_hex .BackColor = BackColor;
			TargetInfo_bin .BackColor = BackColor;
			EffectTypes_hex.BackColor = BackColor;
			EffectTypes_bin.BackColor = BackColor;
			DamageInfo_hex .BackColor = BackColor;
			DamageInfo_bin .BackColor = BackColor;
			SaveType_hex   .BackColor = BackColor;
			SaveType_bin   .BackColor = BackColor;
			SaveDCType_hex .BackColor = BackColor;
			SaveDCType_bin .BackColor = BackColor;

// HenchRacial
			RacialFlags_hex.BackColor = BackColor;
			RacialFlags_bin.BackColor = BackColor;
			RacialFeat1_hex.BackColor = BackColor;
			RacialFeat1_bin.BackColor = BackColor;
			RacialFeat2_hex.BackColor = BackColor;
			RacialFeat2_bin.BackColor = BackColor;
			RacialFeat3_hex.BackColor = BackColor;
			RacialFeat3_bin.BackColor = BackColor;
			RacialFeat4_hex.BackColor = BackColor;
			RacialFeat4_bin.BackColor = BackColor;
			RacialFeat5_hex.BackColor = BackColor;
			RacialFeat5_bin.BackColor = BackColor;

// HenchClasses
			ClassFlags_hex .BackColor = BackColor;
			ClassFlags_bin .BackColor = BackColor;
			ClassFeat1_hex .BackColor = BackColor;
			ClassFeat1_bin .BackColor = BackColor;
			ClassFeat2_hex .BackColor = BackColor;
			ClassFeat2_bin .BackColor = BackColor;
			ClassFeat3_hex .BackColor = BackColor;
			ClassFeat3_bin .BackColor = BackColor;
			ClassFeat4_hex .BackColor = BackColor;
			ClassFeat4_bin .BackColor = BackColor;
			ClassFeat5_hex .BackColor = BackColor;
			ClassFeat5_bin .BackColor = BackColor;
			ClassFeat6_hex .BackColor = BackColor;
			ClassFeat6_bin .BackColor = BackColor;
			ClassFeat7_hex .BackColor = BackColor;
			ClassFeat7_bin .BackColor = BackColor;
			ClassFeat8_hex .BackColor = BackColor;
			ClassFeat8_bin .BackColor = BackColor;
			ClassFeat9_hex .BackColor = BackColor;
			ClassFeat9_bin .BackColor = BackColor;
			ClassFeat10_hex.BackColor = BackColor;
			ClassFeat10_bin.BackColor = BackColor;
			ClassFeat11_hex.BackColor = BackColor;
			ClassFeat11_bin.BackColor = BackColor;


			PopulateSpellInfoComboboxes();
			PopulateTargetInfoComboboxes();
			PopulateDamageInfoComboboxes();
			PopulateSaveTypeComboboxes();
			PopulateSaveDcTypeComboboxes();


			// set unicode text on the up/down Search btns.
			btn_Search_d.Text = "\u25bc"; // down triangle
			btn_Search_u.Text = "\u25b2"; // up triangle

			ActiveControl = tb_Search; // focus the Search-box


			// disable menu-items till they become legitimate
			// TODO: Set these false in the designer.
			ToggleMenuitems(false);


			Size = new Size(800, 480);

			cols_HenchRacial .Location =
			cols_HenchClasses.Location = cols_HenchSpells.Location;

			cols_HenchSpells .Visible =
			cols_HenchRacial .Visible =
			cols_HenchClasses.Visible = false;


			// NOTE: quickload the 2da for testing ONLY.
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
		/// The fullpath of the file must be stored in '_pfe'.
		/// NOTE: "pfe" stands for "path_file_extension"
		/// </summary>
		void Load_file()
		{
			//logfile.Log(_pfe);

			if (File.Exists(_pfe))
			{
				string[] rows = File.ReadAllLines(_pfe);

				// WARNING: This editor does *not* handle quotation marks around 2da fields.
				foreach (string row in rows) // test for double-quote character and exit if found.
				{
					foreach(char character in row)
					{
						if (character == '"')
						{
							const string info = "The 2da-file contains double-quotes. Although that can be"
											  + " valid in a 2da-file this editor is not coded to cope."
											  + " Format the 2da-file to not use double-quotes if you want"
											  + " to open it here.";
							if (MessageBox.Show(info,
												"  ERROR",
												MessageBoxButtons.OK,
												MessageBoxIcon.Error,
												MessageBoxDefaultButton.Button1) == DialogResult.OK)
							{
								return;
							}
						}
					}
				}


				bool stop = false;
				foreach (string row in rows)
				{
					if (stop) break;

					if (!String.IsNullOrEmpty(row))
					{
						string[] cols = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

						int id;
						if (Int32.TryParse(cols[0], out id)) // is a valid 2da row
						{
							switch (cols.Length)
							{
								case 9: // henchspells
									//logfile.Log("load henchspells");
									Load_HenchSpells(rows);
									stop = true;
									break;

								case 7: // henchracial
									//logfile.Log("load henchracial");
									Load_HenchRacial(rows);
									stop = true;
									break;

								case 13: // henchclasses
									//logfile.Log("load henchclasses");
									Load_HenchClasses(rows);
									stop = true;
									break;

								default:
									//logfile.Log("load ERROR");
									if (MessageBox.Show("That file does not appear to be HenchSpells, HenchRacial, or HenchClasses.2da",
														"  ERROR",
														MessageBoxButtons.OK,
														MessageBoxIcon.Error,
														MessageBoxDefaultButton.Button1) == DialogResult.OK)
									{
										return;
									}
									break;
							}

							Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of current file)
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
			Spells.Clear();
			SpellsChanged.Clear();

			Races.Clear();
			RacesChanged.Clear();

			Classes.Clear();
			ClassesChanged.Clear();
		}

		/// <summary>
		/// Loads a HenchSpells.2da file.
		/// If the file is not a valid HenchSpells.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		void Load_HenchSpells(string[] rows)
		{
			SuspendLayout();

			Type = Type2da.TYPE_SPELLS;

			Size = new Size(1105, 525);

			cols_HenchSpells .Visible = true;
			cols_HenchRacial .Visible =
			cols_HenchClasses.Visible = false;


			ClearData();

			SpellInfo_reset   .ForeColor = DefaultForeColor;
			TargetInfo_reset  .ForeColor = DefaultForeColor;
			EffectWeight_reset.ForeColor = DefaultForeColor;
			EffectTypes_reset .ForeColor = DefaultForeColor;
			DamageInfo_reset  .ForeColor = DefaultForeColor;
			SaveType_reset    .ForeColor = DefaultForeColor;
			SaveDCType_reset  .ForeColor = DefaultForeColor;


//			var pb = ProgBarF.Instance;	// the ProgressBar slows loading on my Win7 machine.
//			pb.SetInfo("loading ...");	// It appears to be an issue on Win7 generally.
//			pb.SetTotal(rows.Length);	// TODO: write a progress-bar w/ custom graphic

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					string[] cols = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(cols[0], out id)) // is a valid 2da row
					{
						var spell = new Spell();

						spell.id = id;


						string field = cols[1];
						if (field != blank)
							spell.label = field;
						else
							spell.label = String.Empty;

						field = cols[2];
						if (field != blank)
							spell.spellinfo = Int32.Parse(field);
						else
							spell.spellinfo = 0;

						field = cols[3];
						if (field != blank)
							spell.targetinfo = Int32.Parse(field);
						else
							spell.targetinfo = 0;

						field = cols[4];
						if (field != blank)
							spell.effectweight = float.Parse(field);
						else
							spell.effectweight = 0.0f;

						field = cols[5];
						if (field != blank)
							spell.effecttypes = Int32.Parse(field);
						else
							spell.effecttypes = 0;

						field = cols[6];
						if (field != blank)
							spell.damageinfo = Int32.Parse(field);
						else
							spell.damageinfo = 0;

						field = cols[7];
						if (field != blank)
							spell.savetype = Int32.Parse(field);
						else
							spell.savetype = 0;

						field = cols[8];
						if (field != blank)
							spell.savedctype = Int32.Parse(field);
						else
							spell.savedctype = 0;

						spell.differ = bit_clear;
						spell.isChanged = false;


						Spells.Add(spell);	// spell-structs can now be referenced in the list by their
					}						// - Spells[id]
				}							// - HenchSpells.2da row#
											// - SpellID (Spells.2da row#)
//				pb.Step();
			}

			PopTree();

			ToggleMenuitems(true);

			// Groups on SpellInfo and TargetInfo generally stay green
			// (unless SpellInfo is flagged as a MasterID)
			GroupColor(si_SpelltypeGrp,  Color.LimeGreen);
			GroupColor(si_FlagsGrp,      Color.LimeGreen);
			GroupColor(si_SpelllevelGrp, Color.LimeGreen);
			GroupColor(si_ChildIDGrp,    Color.LimeGreen);

			GroupColor(ti_FlagsGrp,  Color.LimeGreen);
			GroupColor(ti_ShapeGrp,  Color.LimeGreen);
			GroupColor(ti_RangeGrp,  Color.LimeGreen);
			GroupColor(ti_RadiusGrp, Color.LimeGreen);

			ResumeLayout();
		}

		/// <summary>
		/// Loads a HenchRacial.2da file.
		/// If the file is not a valid HenchRacial.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		void Load_HenchRacial(string[] rows)
		{
			SuspendLayout();

			Type = Type2da.TYPE_RACIAL;

			Size = new Size(905, 350);

			cols_HenchSpells .Visible = false;
			cols_HenchRacial .Visible = true;
			cols_HenchClasses.Visible = false;

			ClearData();

			RacialFlags_reset.ForeColor = DefaultForeColor;
			RacialFeat1_reset.ForeColor = DefaultForeColor;
			RacialFeat2_reset.ForeColor = DefaultForeColor;
			RacialFeat3_reset.ForeColor = DefaultForeColor;
			RacialFeat4_reset.ForeColor = DefaultForeColor;
			RacialFeat5_reset.ForeColor = DefaultForeColor;

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					string[] cols = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(cols[0], out id)) // is a valid 2da row
					{
						var race = new Race();

						race.id = id;


						string field = cols[1];
						if (field != blank)
							race.flags = Int32.Parse(field);
						else
							race.flags = 0;

						field = cols[2];
						if (field != blank)
							race.feat1 = Int32.Parse(field);
						else
							race.feat1 = 0;

						field = cols[3];
						if (field != blank)
							race.feat2 = Int32.Parse(field);
						else
							race.feat2 = 0;

						field = cols[4];
						if (field != blank)
							race.feat3 = Int32.Parse(field);
						else
							race.feat3 = 0;

						field = cols[5];
						if (field != blank)
							race.feat4 = Int32.Parse(field);
						else
							race.feat4 = 0;

						field = cols[6];
						if (field != blank)
							race.feat5 = Int32.Parse(field);
						else
							race.feat5 = 0;

						race.differ = bit_clear;
						race.isChanged = false;


						Races.Add(race);	// race-structs can now be referenced in the list by their
					}						// - Races[id]
				}							// - HenchRacial.2da row#
											// - RaceID (Subraces.2da row#)
//				pb.Step();
			}

			PopTree();

			ToggleMenuitems(true);

			ResumeLayout();
		}

		/// <summary>
		/// Loads a HenchClasses.2da file.
		/// If the file is not a valid HenchClasses.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// </summary>
		void Load_HenchClasses(string[] rows)
		{
			SuspendLayout();

			Type = Type2da.TYPE_CLASSES;

			Size = new Size(1355, 400);

			cols_HenchSpells .Visible =
			cols_HenchRacial .Visible = false;
			cols_HenchClasses.Visible = true;

			ClearData();

			ClassFlags_reset .ForeColor = DefaultForeColor;
			ClassFeat1_reset .ForeColor = DefaultForeColor;
			ClassFeat2_reset .ForeColor = DefaultForeColor;
			ClassFeat3_reset .ForeColor = DefaultForeColor;
			ClassFeat4_reset .ForeColor = DefaultForeColor;
			ClassFeat5_reset .ForeColor = DefaultForeColor;
			ClassFeat6_reset .ForeColor = DefaultForeColor;
			ClassFeat7_reset .ForeColor = DefaultForeColor;
			ClassFeat8_reset .ForeColor = DefaultForeColor;
			ClassFeat9_reset .ForeColor = DefaultForeColor;
			ClassFeat10_reset.ForeColor = DefaultForeColor;
			ClassFeat11_reset.ForeColor = DefaultForeColor;

			foreach (string row in rows)
			{
				if (!String.IsNullOrEmpty(row))
				{
					string[] cols = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					int id;
					if (Int32.TryParse(cols[0], out id)) // is a valid 2da row
					{
						var clas = new Class();

						clas.id = id;


						string field = cols[1];
						if (field != blank)
							clas.flags = Int32.Parse(field);
						else
							clas.flags = 0;

						field = cols[2];
						if (field != blank)
							clas.feat1 = Int32.Parse(field);
						else
							clas.feat1 = 0;

						field = cols[3];
						if (field != blank)
							clas.feat2 = Int32.Parse(field);
						else
							clas.feat2 = 0;

						field = cols[4];
						if (field != blank)
							clas.feat3 = Int32.Parse(field);
						else
							clas.feat3 = 0;

						field = cols[5];
						if (field != blank)
							clas.feat4 = Int32.Parse(field);
						else
							clas.feat4 = 0;

						field = cols[6];
						if (field != blank)
							clas.feat5 = Int32.Parse(field);
						else
							clas.feat5 = 0;

						field = cols[7];
						if (field != blank)
							clas.feat6 = Int32.Parse(field);
						else
							clas.feat6 = 0;

						field = cols[8];
						if (field != blank)
							clas.feat7 = Int32.Parse(field);
						else
							clas.feat7 = 0;

						field = cols[9];
						if (field != blank)
							clas.feat8 = Int32.Parse(field);
						else
							clas.feat8 = 0;

						field = cols[10];
						if (field != blank)
							clas.feat9 = Int32.Parse(field);
						else
							clas.feat9 = 0;

						field = cols[11];
						if (field != blank)
							clas.feat10 = Int32.Parse(field);
						else
							clas.feat10 = 0;

						field = cols[12];
						if (field != blank)
							clas.feat11 = Int32.Parse(field);
						else
							clas.feat11 = 0;

						clas.differ = bit_clear;
						clas.isChanged = false;


						Classes.Add(clas);	// class-structs can now be referenced in the list by their
					}						// - Classes[id]
				}							// - HenchClasses.2da row#
											// - ClassID (Classes.2da row#)
//				pb.Step();
			}

			PopTree();

			ToggleMenuitems(true);

			ResumeLayout();
		}

		/// <summary>
		/// Populates nodes in the tree.
		/// </summary>
		void PopTree()
		{
//			var pb = ProgBarF.Instance;
//			pb.SetInfo("populating ...");
//			pb.SetTotal(Spells.Count);

			Tree.Nodes.Clear();

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
				{
					int digits;
					string pad;

					foreach (var spell in Spells)
					{
						pad = String.Empty;
						digits = spell.id.ToString().Length;
						while (digits++ < 4) // good to id# 9999
						{
							pad += " ";
						}

						Tree.Nodes.Add(spell.id + pad + " " + spell.label);
//						pb.Step();
					}
					break;
				}

				case Type2da.TYPE_RACIAL:
					foreach (var race in Races)
					{
						Tree.Nodes.Add(race.id.ToString());
//						pb.Step();
					}
					break;

				case Type2da.TYPE_CLASSES:
					foreach (var clas in Classes)
					{
						Tree.Nodes.Add(clas.id.ToString());
//						pb.Step();
					}
					break;
			}

			// NOTE: Tree.SelectedNode=Tree.Nodes[0] is done auto.
			// Not necessarily ...
			Tree.SelectedNode = Tree.Nodes[0];
		}

		/// <summary>
		/// Enables/disables several menu-items.
		/// NOTE: Calls to this need to be adjusted if a Close 2da function is
		/// added - and perhaps if a 2da fails to load leaving a blank tree.
		/// </summary>
		/// <param name="enable"></param>
		void ToggleMenuitems(bool enable)
		{
			Save            .Enabled =			// file ->
			Saveas          .Enabled =

			FindNextChanged .Enabled =			// edit ->
			Copy_decimal    .Enabled =
			Copy_hexadecimal.Enabled =
			Copy_binary     .Enabled =

			setCoreAIver    .Enabled = enable;	// options.
		}
		#endregion Load


		#region SpellTree node-select
		/// <summary>
		/// Handles AfterSelect event for nodes in the spell-tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AfterSelect_node(object sender, TreeViewEventArgs e)
		{
			bypassTextChanged = true;

			Id = Tree.SelectedNode.Index;

			//logfile.Log("AfterSelect_spellnode() selectedNode= " + Id);

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					SpellSelect();
					break;

				case Type2da.TYPE_RACIAL:
					RaceSelect();
					break;

				case Type2da.TYPE_CLASSES:
					ClassSelect();
					break;
			}

			bypassTextChanged = false;
		}

		/// <summary>
		/// Fills displayed fields w/ data from the spell's Id.
		/// </summary>
		void SpellSelect()
		{
			Spell spell = Spells[Id];

			bool dirty = SpellsChanged.ContainsKey(Id);

// SpellInfo
			int val = spell.spellinfo;
			SpellInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].spellinfo;
			}

			PrintCurrent(val, SpellInfo_text, SpellInfo_hex, SpellInfo_bin);

// TargetInfo
			val = spell.targetinfo;
			TargetInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].targetinfo;
			}

			PrintCurrent(val, TargetInfo_text, TargetInfo_hex, TargetInfo_bin);

// EffectWeight
			string text = FormatFloat(spell.effectweight.ToString());
			EffectWeight_reset.Text = text;

			if (dirty)
			{
				text = FormatFloat(SpellsChanged[Id].effectweight.ToString());
			}
			EffectWeight_text.Text = text; // NOTE: This will fire TextChanged_ew().

// EffectTypes
			val = spell.effecttypes;
			EffectTypes_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].effecttypes;
			}

			PrintCurrent(val, EffectTypes_text, EffectTypes_hex, EffectTypes_bin);

// DamageInfo
			val = spell.damageinfo;
			DamageInfo_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].damageinfo;
			}

			PrintCurrent(val, DamageInfo_text, DamageInfo_hex, DamageInfo_bin);

// SaveType
			val = spell.savetype;
			SaveType_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].savetype;
			}

			PrintCurrent(val, SaveType_text, SaveType_hex, SaveType_bin);

// SaveDCType
			val = spell.savedctype;
			SaveDCType_reset.Text = val.ToString();

			if (dirty)
			{
				val = SpellsChanged[Id].savedctype;
			}

			PrintCurrent(val, SaveDCType_text, SaveDCType_hex, SaveDCType_bin);
		}

		/// <summary>
		/// Fills displayed fields w/ data from the race's Id.
		/// </summary>
		void RaceSelect()
		{
			Race race = Races[Id];

			bool dirty = RacesChanged.ContainsKey(Id);

// Flags
			int val = race.flags;
			RacialFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].flags;
			}

			PrintCurrent(val, RacialFlags_text, RacialFlags_hex, RacialFlags_bin);

// Feat1
			val = race.feat1;
			RacialFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat1;
			}

			PrintCurrent(val, RacialFeat1_text, RacialFeat1_hex, RacialFeat1_bin);

// Feat2
			val = race.feat2;
			RacialFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat2;
			}

			PrintCurrent(val, RacialFeat2_text, RacialFeat2_hex, RacialFeat2_bin);

// Feat3
			val = race.feat3;
			RacialFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat3;
			}

			PrintCurrent(val, RacialFeat3_text, RacialFeat3_hex, RacialFeat3_bin);

// Feat4
			val = race.feat4;
			RacialFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat4;
			}

			PrintCurrent(val, RacialFeat4_text, RacialFeat4_hex, RacialFeat4_bin);

// Feat5
			val = race.feat5;
			RacialFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = RacesChanged[Id].feat5;
			}

			PrintCurrent(val, RacialFeat5_text, RacialFeat5_hex, RacialFeat5_bin);
		}

		/// <summary>
		/// Fills displayed fields w/ data from the class' Id.
		/// </summary>
		void ClassSelect()
		{
			Class clas = Classes[Id];

			bool dirty = ClassesChanged.ContainsKey(Id);

// Flags
			int val = clas.flags;
			ClassFlags_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].flags;
			}

			PrintCurrent(val, ClassFlags_text, ClassFlags_hex, ClassFlags_bin);

// Feat1
			val = clas.feat1;
			ClassFeat1_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat1;
			}

			PrintCurrent(val, ClassFeat1_text, ClassFeat1_hex, ClassFeat1_bin);

// Feat2
			val = clas.feat2;
			ClassFeat2_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat2;
			}

			PrintCurrent(val, ClassFeat2_text, ClassFeat2_hex, ClassFeat2_bin);

// Feat3
			val = clas.feat3;
			ClassFeat3_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat3;
			}

			PrintCurrent(val, ClassFeat3_text, ClassFeat3_hex, ClassFeat3_bin);

// Feat4
			val = clas.feat4;
			ClassFeat4_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat4;
			}

			PrintCurrent(val, ClassFeat4_text, ClassFeat4_hex, ClassFeat4_bin);

// Feat5
			val = clas.feat5;
			ClassFeat5_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat5;
			}

			PrintCurrent(val, ClassFeat5_text, ClassFeat5_hex, ClassFeat5_bin);

// Feat6
			val = clas.feat6;
			ClassFeat6_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat6;
			}

			PrintCurrent(val, ClassFeat6_text, ClassFeat6_hex, ClassFeat6_bin);

// Feat7
			val = clas.feat7;
			ClassFeat7_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat7;
			}

			PrintCurrent(val, ClassFeat7_text, ClassFeat7_hex, ClassFeat7_bin);

// Feat8
			val = clas.feat8;
			ClassFeat8_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat8;
			}

			PrintCurrent(val, ClassFeat8_text, ClassFeat8_hex, ClassFeat8_bin);

// Feat9
			val = clas.feat9;
			ClassFeat9_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat9;
			}

			PrintCurrent(val, ClassFeat9_text, ClassFeat9_hex, ClassFeat9_bin);

// Feat10
			val = clas.feat10;
			ClassFeat10_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat10;
			}

			PrintCurrent(val, ClassFeat10_text, ClassFeat10_hex, ClassFeat10_bin);

// Feat11
			val = clas.feat11;
			ClassFeat11_reset.Text = val.ToString();

			if (dirty)
			{
				val = ClassesChanged[Id].feat11;
			}

			PrintCurrent(val, ClassFeat11_text, ClassFeat11_hex, ClassFeat11_bin);
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
		/// Prints current value of current page's field to the page's TextBoxes.
		/// </summary>
		/// <param name="val"></param>
		/// <param name="textbox">editable</param>
		/// <param name="hexbox">readonly</param>
		/// <param name="binbox">readonly</param>
		void PrintCurrent(int val, Control textbox, Control hexbox, Control binbox)
		{
			if (textbox != null)				// bypass setting the textbox text if this was called by setting the textbox text.
				textbox.Text = val.ToString();	// NOTE: This will fire TextChanged_*().

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
			TextBox tb = null;
			var btn = sender as Button;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					if (btn == ew_Clear)
					{
						EffectWeight_text.Text = "0.0"; // EffectWeight is the only float-val - the rest are ints.
					}
					else
					{
						if      (btn == si_Clear) tb = SpellInfo_text;
						else if (btn == ti_Clear) tb = TargetInfo_text;
						else if (btn == et_Clear) tb = EffectTypes_text;
						else if (btn == di_Clear) tb = DamageInfo_text;
						else if (btn == st_Clear) tb = SaveType_text;
						else                      tb = SaveDCType_text; //if (btn == dc_Clear)
					}
					break;

				case Type2da.TYPE_RACIAL:
					if      (btn ==  rf_Clear) tb = RacialFlags_text;
					else if (btn == rf1_Clear) tb = RacialFeat1_text;
					else if (btn == rf2_Clear) tb = RacialFeat2_text;
					else if (btn == rf3_Clear) tb = RacialFeat3_text;
					else if (btn == rf4_Clear) tb = RacialFeat4_text;
					else                       tb = RacialFeat5_text; //if (btn == rf5_Clear)
					break;

				case Type2da.TYPE_CLASSES:
					if      (btn ==   cf_Clear) tb = ClassFlags_text;
					else if (btn ==  cf1_Clear) tb = ClassFeat1_text;
					else if (btn ==  cf2_Clear) tb = ClassFeat2_text;
					else if (btn ==  cf3_Clear) tb = ClassFeat3_text;
					else if (btn ==  cf4_Clear) tb = ClassFeat4_text;
					else if (btn ==  cf5_Clear) tb = ClassFeat5_text;
					else if (btn ==  cf6_Clear) tb = ClassFeat6_text;
					else if (btn ==  cf7_Clear) tb = ClassFeat7_text;
					else if (btn ==  cf8_Clear) tb = ClassFeat8_text;
					else if (btn ==  cf9_Clear) tb = ClassFeat9_text;
					else if (btn == cf10_Clear) tb = ClassFeat10_text;
					else                        tb = ClassFeat11_text; //if (btn == cf11_Clear)
					break;
			}

			if (tb != null) // safety.
				tb.Text = "0";
		}

		/// <summary>
		/// Handler for the "apply changed data to currently selected
		/// spell-struct" button.
		/// Cf. ApplyDirtyData()
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_apply(object sender, EventArgs e)
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					if (SpellsChanged.ContainsKey(Id))
					{
						var spellchanged = SpellsChanged[Id];

						Spell spell = Spells[Id];

						spell.isChanged = true;
						spell.differ = bit_clear;

						spell.spellinfo    = spellchanged.spellinfo;
						spell.targetinfo   = spellchanged.targetinfo;
						spell.effectweight = spellchanged.effectweight;
						spell.effecttypes  = spellchanged.effecttypes;
						spell.damageinfo   = spellchanged.damageinfo;
						spell.savetype     = spellchanged.savetype;
						spell.savedctype   = spellchanged.savedctype;

						Spells[Id] = spell;

						SpellsChanged.Remove(Id);

						SpellInfo_reset   .ForeColor = DefaultForeColor;
						TargetInfo_reset  .ForeColor = DefaultForeColor;
						EffectWeight_reset.ForeColor = DefaultForeColor;
						EffectTypes_reset .ForeColor = DefaultForeColor;
						DamageInfo_reset  .ForeColor = DefaultForeColor;
						SaveType_reset    .ForeColor = DefaultForeColor;
						SaveDCType_reset  .ForeColor = DefaultForeColor;

						AfterSelect_node(null, null); // refresh all displayed data for the current spell jic
					}

					if (Spells[Id].isChanged) // this goes outside the SpellsChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;

				case Type2da.TYPE_RACIAL:
					if (RacesChanged.ContainsKey(Id))
					{
						var racechanged = RacesChanged[Id];

						Race race = Races[Id];

						race.isChanged = true;
						race.differ = bit_clear;

						race.flags = racechanged.flags;
						race.feat1 = racechanged.feat1;
						race.feat2 = racechanged.feat2;
						race.feat3 = racechanged.feat3;
						race.feat4 = racechanged.feat4;
						race.feat5 = racechanged.feat5;

						Races[Id] = race;

						RacesChanged.Remove(Id);

						RacialFlags_reset.ForeColor = DefaultForeColor;
						RacialFeat1_reset.ForeColor = DefaultForeColor;
						RacialFeat2_reset.ForeColor = DefaultForeColor;
						RacialFeat3_reset.ForeColor = DefaultForeColor;
						RacialFeat4_reset.ForeColor = DefaultForeColor;
						RacialFeat5_reset.ForeColor = DefaultForeColor;

						AfterSelect_node(null, null); // refresh all displayed data for the current node jic
					}

					if (Races[Id].isChanged) // this goes outside the RacesChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;

				case Type2da.TYPE_CLASSES:
					if (ClassesChanged.ContainsKey(Id))
					{
						var claschanged = ClassesChanged[Id];

						Class clas = Classes[Id];

						clas.isChanged = true;
						clas.differ = bit_clear;

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

						ClassFlags_reset .ForeColor = DefaultForeColor;
						ClassFeat1_reset .ForeColor = DefaultForeColor;
						ClassFeat2_reset .ForeColor = DefaultForeColor;
						ClassFeat3_reset .ForeColor = DefaultForeColor;
						ClassFeat4_reset .ForeColor = DefaultForeColor;
						ClassFeat5_reset .ForeColor = DefaultForeColor;
						ClassFeat6_reset .ForeColor = DefaultForeColor;
						ClassFeat7_reset .ForeColor = DefaultForeColor;
						ClassFeat8_reset .ForeColor = DefaultForeColor;
						ClassFeat9_reset .ForeColor = DefaultForeColor;
						ClassFeat10_reset.ForeColor = DefaultForeColor;
						ClassFeat11_reset.ForeColor = DefaultForeColor;

						AfterSelect_node(null, null); // refresh all displayed data for the current node jic
					}

					if (Classes[Id].isChanged) // this goes outside the ClassesChanged check above because uh color goes screwy if not.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else // I doubt this ever *needs* to run ... but safety.
					{
						Tree.SelectedNode.ForeColor = DefaultForeColor;
					}
					break;
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

			if (!CheckFloats(spell.effectweight, spellchanged.effectweight))
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
		static bool CheckFloats(float a, float b)
		{
			return Math.Abs(b - a) < epsilon;
		}

		/// <summary>
		/// Formats a string that is a float in a way that is consistent with
		/// a 2da-field.
		/// </summary>
		/// <param name="f"></param>
		/// <returns>formatted string representing a float</returns>
		static string FormatFloat(string f)
		{
			if (f.IndexOf('.') == -1)
				return f.Insert(f.Length, ".0");

			return f;
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
			int totalnodes = Tree.Nodes.Count;
			if (totalnodes > 1)
			{
				string text = tb_Search.Text;
				if (!String.IsNullOrEmpty(text))
				{
					text = text.ToLower();

					int id;

					var btn = sender as Button;
					if (btn == btn_Search_d || btn == null)
					{
						if (Id == totalnodes - 1)
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

							if (++id == totalnodes) // wrap to first node
							{
								id = 0;
							}
						}
					}
					else //if (btn == btn_Search_u)
					{
						if (Id == 0)
						{
							id = totalnodes - 1;
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
								id = totalnodes - 1;
							}
						}
					}

					Tree.SelectedNode = Tree.Nodes[id];
				}
			}
		}
		#endregion Search
	}
	#endregion MainForm



	/// <summary>
	/// Struct that holds data of each spell in HenchSpells.2da.
	/// note: This data can change when the Apply-btn is clicked (but only if
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

		public int differ;		// bitwise int that holds flags for changed fields
		public bool isChanged;	// boolean used to warn if there is modified data when exiting the app.
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
	/// note: This data can change when the Apply-btn is clicked (but only if
	/// the race-data has in fact been changed of c).
	/// NOTE: This is the data that gets saved to file on File|Save.
	/// </summary>
	struct Race
	{
		public int id;

		public int flags;
		public int feat1;
		public int feat2;
		public int feat3;
		public int feat4;
		public int feat5;

		// NOTE: The following fields are not saved to file ->

		public int differ;		// bitwise int that holds flags for changed fields
		public bool isChanged;	// boolean used to warn if there is modified data when exiting the app.
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
	/// note: This data can change when the Apply-btn is clicked (but only if
	/// the class-data has in fact been changed of c).
	/// NOTE: This is the data that gets saved to file on File|Save.
	/// </summary>
	struct Class
	{
		public int id;

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

		public int differ;		// bitwise int that holds flags for changed fields
		public bool isChanged;	// boolean used to warn if there is modified data when exiting the app.
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
}
