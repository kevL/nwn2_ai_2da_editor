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
		/// The currently selected node in the SpellTree.
		/// </summary>
		int Id
		{ get; set; }

		/// <summary>
		/// A boolean that prevents firing the TextChanged handlers when true.
		/// That is don't fire the text-changed event when the spell-tree needs
		/// to be re/populated.
		/// </summary>
		bool bypassTextChanged;

		/// <summary>
		/// A boolean that prevents firing the Checkbox Setter when true. That
		/// is don't try to force a checkbox-setting if the control is actually
		/// being clicked. It happens auto.
		/// UPDATE: But as it turns out there are bits that overlap with bits
		/// for other fields ....
		/// </summary>
		bool bypassCheckedChecker;

		/// <summary>
		/// The fullpath of the currently opened HenchSpells.2da file.
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


			// NOTE: quickload the 2da for testing ONLY.
			_pfe = @"C:\GIT\nwn2_ai_2da_editor\2da\henchspells.2da";
			Load_HenchSpells();
		}
		#endregion cTor


		#region Load
		/// <summary>
		/// Loads a HenchSpells.2da file.
		/// If the file is not a valid HenchSpells.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.
		/// The fullpath of the file must be stored in '_pfe'.
		/// NOTE: "pfe" stands for "path_file_extension"
		/// </summary>
		void Load_HenchSpells()
		{
			//logfile.Log(_pfe);

			if (File.Exists(_pfe))
			{
				Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of current file)

				SpellsChanged.Clear();

				SpellInfo_reset   .ForeColor = DefaultForeColor;
				TargetInfo_reset  .ForeColor = DefaultForeColor;
				EffectWeight_reset.ForeColor = DefaultForeColor;
				EffectTypes_reset .ForeColor = DefaultForeColor;
				DamageInfo_reset  .ForeColor = DefaultForeColor;
				SaveType_reset    .ForeColor = DefaultForeColor;
				SaveDCType_reset  .ForeColor = DefaultForeColor;


				Spells.Clear();

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


//				var pb = ProgBarF.Instance;	// the ProgressBar slows loading on my Win7 machine.
//				pb.SetInfo("loading ...");	// It appears to be an issue on Win7 generally.
//				pb.SetTotal(rows.Length);	// TODO: write a progress-bar w/ custom graphic

				foreach (string row in rows)
				{
					if (!String.IsNullOrEmpty(row))
					{
						//logfile.Log(row);

						string[] cols = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

						//logfile.Log(cols[0]);

						int id;
						if (Int32.TryParse(cols[0], out id)) // is a valid 2da row
						{
//							for (int i = 1; i != 9; ++i) // 9 cols in HenchSpells.2da
//							{
								//logfile.Log(cols[i]);
//							}

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

//					pb.Step();
				}

				if (Spells.Count != 0)
				{
					PopulateSpellTree();

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
				}
				else
					MessageBox.Show("The 2da-file contains no valid rows.",
									"  ERROR",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error,
									MessageBoxDefaultButton.Button1);
			}
		}

		/// <summary>
		/// Enables/disables several menu-items.
		/// NOTE: Calls to this need to be adjusted if a Close 2da function is
		/// added - and perhaps if a 2da fails to load leaving a blank spell-tree.
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


		/// <summary>
		/// Populates nodes in the spell-tree.
		/// </summary>
		void PopulateSpellTree()
		{
//			var pb = ProgBarF.Instance;
//			pb.SetInfo("populating ...");
//			pb.SetTotal(Spells.Count);

			SpellTree.Nodes.Clear();

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

				SpellTree.Nodes.Add(spell.id + pad + " " + spell.label);

//				pb.Step();
			}

			// NOTE: SpellTree.SelectedNode=SpellTree.Nodes[0] is done auto.
			// Not necessarily ...
			SpellTree.SelectedNode = SpellTree.Nodes[0];
		}
		#endregion Load



		#region SpellTree node-select
		/// <summary>
		/// Handles AfterSelect event for nodes in the spell-tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AfterSelect_spellnode(object sender, TreeViewEventArgs e)
		{
			bypassTextChanged = true;

			Id = SpellTree.SelectedNode.Index;

			//logfile.Log("AfterSelect_spellnode() selectedNode= " + Id);
			
			Spell spell = Spells[Id];

			bool dirty = SpellsChanged.ContainsKey(Id);

// SpellInfo
			int val = spell.spellinfo;
			string text = val.ToString();
			SpellInfo_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].spellinfo;
			}

			PrintCurrent(val, SpellInfo_text, SpellInfo_hex, SpellInfo_bin);

// TargetInfo
			val = spell.targetinfo;
			text = val.ToString();
			TargetInfo_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].targetinfo;
			}

			PrintCurrent(val, TargetInfo_text, TargetInfo_hex, TargetInfo_bin);

// EffectWeight
			text = FormatFloat(spell.effectweight.ToString());
			EffectWeight_reset.Text = text;

			if (dirty)
			{
				text = FormatFloat(SpellsChanged[Id].effectweight.ToString());
			}
			EffectWeight_text.Text = text; // NOTE: This will fire TextChanged_ew().

// EffectTypes
			val = spell.effecttypes;
			text = val.ToString();
			EffectTypes_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].effecttypes;
			}

			PrintCurrent(val, EffectTypes_text, EffectTypes_hex, EffectTypes_bin);

// DamageInfo
			val = spell.damageinfo;
			text = val.ToString();
			DamageInfo_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].damageinfo;
			}

			PrintCurrent(val, DamageInfo_text, DamageInfo_hex, DamageInfo_bin);

// SaveType
			val = spell.savetype;
			text = val.ToString();
			SaveType_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].savetype;
			}

			PrintCurrent(val, SaveType_text, SaveType_hex, SaveType_bin);

// SaveDCType
			val = spell.savedctype;
			text = val.ToString();
			SaveDCType_reset.Text = text;

			if (dirty)
			{
				val = SpellsChanged[Id].savedctype;
			}

			PrintCurrent(val, SaveDCType_text, SaveDCType_hex, SaveDCType_bin);


			bypassTextChanged = false;
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
			Copy_binary     .Enabled = (cols_HenchSpells.SelectedIndex != 2); // ie. not 'page_EffectWeight'
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
			var btn = sender as Button;
			if (btn == ew_Clear)
			{
				EffectWeight_text.Text = "0.0"; // EffectWeight is the only float-val - the rest are ints.
			}
			else
			{
				TextBox tb;
				if      (btn == si_Clear) tb = SpellInfo_text;
				else if (btn == ti_Clear) tb = TargetInfo_text;
				else if (btn == et_Clear) tb = EffectTypes_text;
				else if (btn == di_Clear) tb = DamageInfo_text;
				else if (btn == st_Clear) tb = SaveType_text;
				else                      tb = SaveDCType_text; //if (btn == dc_Clear)

				tb.Text = "0";
			}
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
			//logfile.Log("Click_apply()");

			if (SpellsChanged.ContainsKey(Id))
			{
				//logfile.Log(". is in SpellsChanged");

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

				// NOTE: keep 'savedctypetype' intact. It's basically a user-setting. // TODO: Obsolete that.

				Spells[Id] = spell;

				SpellsChanged.Remove(Id);

				SpellInfo_reset   .ForeColor = DefaultForeColor;
				TargetInfo_reset  .ForeColor = DefaultForeColor;
				EffectWeight_reset.ForeColor = DefaultForeColor;
				EffectTypes_reset .ForeColor = DefaultForeColor;
				DamageInfo_reset  .ForeColor = DefaultForeColor;
				SaveType_reset    .ForeColor = DefaultForeColor;
				SaveDCType_reset  .ForeColor = DefaultForeColor;

				AfterSelect_spellnode(null, null); // refresh all displayed data for the current spell jic
			}
			//else logfile.Log(". is NOT in SpellsChanged");

			if (Spells[Id].isChanged) // this goes outside the SpellsChanged check above because uh color goes screwy if not.
			{
				//logfile.Log(". isChanged TRUE - set node to Blue");
				SpellTree.SelectedNode.ForeColor = Color.MediumBlue;
			}
			else // I doubt this ever *needs* to run ... but safety.
			{
				//logfile.Log(". isChanged FALSE - set node to DefaultColor");
				SpellTree.SelectedNode.ForeColor = DefaultForeColor;
			}
		}


		#region Utilities
		/// <summary>
		/// Bitflags for fields that have changed.
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
			int totalnodes = SpellTree.Nodes.Count;
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

						while (!SpellTree.Nodes[id].Text.ToLower().Contains(text))
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

						while (!SpellTree.Nodes[id].Text.ToLower().Contains(text))
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

					SpellTree.SelectedNode = SpellTree.Nodes[id];
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
}
