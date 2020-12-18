using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Event handlers for menu-items and related stuff.
	/// </summary>
	partial class he
	{
		#region Fields (static)
		/// <summary>
		/// A list that holds labels for spells in Spells.2da.
		/// - optional
		/// </summary>
		internal static List<string> spellLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for races in Races.2da.
		/// - optional
		/// </summary>
		internal static List<string> raceLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for classes in Classes.2da.
		/// - optional
		/// </summary>
		internal static List<string> classLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for feats in Feat.2da.
		/// - optional
		/// </summary>
		internal static List<string> featsLabels = new List<string>();
		#endregion Fields (static)


		#region Events (override)
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.WindowsShutDown)
			{
				e.Cancel = GetChanged()
						&& MessageBox.Show("Data has changed." + Environment.NewLine + "Okay to exit ...",
										   "  Warning",
										   MessageBoxButtons.OKCancel,
										   MessageBoxIcon.Warning,
										   MessageBoxDefaultButton.Button2) == DialogResult.Cancel;
			}
			base.OnFormClosing(e);
		}
		#endregion Events (override)


		#region File
		/// <summary>
		/// Handles FileMenu close program event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_quit(object sender, EventArgs e)
		{
			if (!GetChanged()
				|| MessageBox.Show("Data has changed." + Environment.NewLine + "Okay to exit ...",
								   "  Warning",
								   MessageBoxButtons.OKCancel,
								   MessageBoxIcon.Warning,
								   MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				Close();
			}
		}

		/// <summary>
		/// Handles FileMenu open file event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_open(object sender, EventArgs e)
		{
			if (!GetChanged()
				|| MessageBox.Show("Data has changed." + Environment.NewLine + "Okay to exit ...",
								   "  Warning",
								   MessageBoxButtons.OKCancel,
								   MessageBoxIcon.Warning,
								   MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.Title  = "Select a Hench*.2da file";
					ofd.Filter = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
	
					if (ofd.ShowDialog() == DialogResult.OK)
					{
						_pfe = ofd.FileName;
						Load_file();
					}
				}
			}
		}

		/// <summary>
		/// Handles FileMenu save file event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_save(object sender, EventArgs e)
		{
			if (!DirtyData())
			{
				if (sender == null) // is Saveas
				{
					_pfe = _pfeT;
					_pfeT = String.Empty;
				}

				Write2daFile();
			}
			else
			{
				string info = "There is data that has been modified but not applied."
							+ Environment.NewLine + Environment.NewLine
							+ "\tabort\t Cancel the operation"
							+ Environment.NewLine
							+ "\tretry\t Apply all modified data and Save"
							+ Environment.NewLine
							+ "\tignore\t Save currently applied data only";

				switch (MessageBox.Show(info,
										"  Attention",
										MessageBoxButtons.AbortRetryIgnore,
										MessageBoxIcon.Asterisk,
										MessageBoxDefaultButton.Button1))
				{
					case DialogResult.Abort:
						_pfeT = String.Empty;
						break;

					case DialogResult.Retry:
						if (sender == null) // is Saveas
						{
							_pfe = _pfeT;
							_pfeT = String.Empty;
						}

						ApplyDirtyData();
						Write2daFile();
						break;

					case DialogResult.Ignore:
						if (sender == null) // is Saveas
						{
							_pfe = _pfeT;
							_pfeT = String.Empty;
						}

						Write2daFile();
						break;
				}
			}
		}

		/// <summary>
		/// Handles FileMenu saveas file event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_saveas(object sender, EventArgs e)
		{
			using (var sfd = new SaveFileDialog())
			{
				sfd.Title    = "Save as ...";
				sfd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
				sfd.FileName = Path.GetFileName(_pfe);

				if (sfd.ShowDialog() == DialogResult.OK)
				{
					_pfeT = sfd.FileName; // the fullpath still needs user-confirmation (if there's dirty data)

					Click_save(null, EventArgs.Empty);
				}
				else
					_pfeT = String.Empty;
			}
		}
		#endregion File


		#region Edit
		/// <summary>
		/// Handles the GlobalApply menu-item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_applyGlobal(object sender, EventArgs e)
		{
			ApplyDirtyData();
		}


		/// <summary>
		/// Handles the GotoNextChanged menu-item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_gotonextchanged(object sender, EventArgs e)
		{
			int total = Tree.Nodes.Count;
			if (total > 1)
			{
				int id;
				if (Id == total - 1)
				{
					id = 0;
				}
				else
					id = Id + 1;

				switch (Type)
				{
					case Type2da.TYPE_SPELLS:
						while (!Spells[id].isChanged && Spells[id].differ == tabcontrol_Spells.bit_clear)
						{
							if (id == Id) // not found.
							{
								System.Media.SystemSounds.Beep.Play();
								break;
							}

							if (++id == total) // wrap to first node
								id = 0;
						}
						break;

					case Type2da.TYPE_RACIAL:
						while (!Races[id].isChanged && Races[id].differ == tabcontrol_Racial.bit_clear)
						{
							if (id == Id) // not found.
							{
								System.Media.SystemSounds.Beep.Play();
								break;
							}

							if (++id == total) // wrap to first node
								id = 0;
						}
						break;

					case Type2da.TYPE_CLASSES:
						while (!Classes[id].isChanged && Classes[id].differ == tabcontrol_Classes.bit_clear)
						{
							if (id == Id) // not found.
							{
								System.Media.SystemSounds.Beep.Play();
								break;
							}

							if (++id == total) // wrap to first node
								id = 0;
						}
						break;
				}

				Tree.SelectedNode = Tree.Nodes[id];
				Tree.SelectedNode.EnsureVisible();
			}
		}

		/// <summary>
		/// Handles the Copy decimal info menu-item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_copy_decimal(object sender, EventArgs e)
		{
			string info = GetTextInfo();

			if (!String.IsNullOrEmpty(info))
			{
				Clipboard.SetText(info);
			}
			else
				Clipboard.Clear();
		}

		/// <summary>
		/// Handles the Copy hexadecimal info menu-item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_copy_hexadecimal(object sender, EventArgs e)
		{
			string info = GetTextInfo();

			if (!String.IsNullOrEmpty(info))
			{
				info = Int32.Parse(info).ToString("x8").Insert(0, "0x");
				Clipboard.SetText(info);
			}
			else
				Clipboard.Clear();
		}

		/// <summary>
		/// Handles the Copy binary info menu-item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_copy_binary(object sender, EventArgs e)
		{
			string info = GetTextInfo();

			if (!String.IsNullOrEmpty(info))
			{
				info = Convert.ToString(Int32.Parse(info), 2).PadLeft(32, '0');
				Clipboard.SetText(info);
			}
			else
				Clipboard.Clear();
		}

		/// <summary>
		/// Gets the master-int of the currently selected page as a string.
		/// </summary>
		/// <returns></returns>
		string GetTextInfo()
		{
			string info = String.Empty;
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					return (HenchControl as tabcontrol_Spells).GetMasterText();

				case Type2da.TYPE_RACIAL:
					return (HenchControl as tabcontrol_Racial).GetMasterText();

				case Type2da.TYPE_CLASSES:
					return (HenchControl as tabcontrol_Classes).GetMasterText();
			}
			return String.Empty;
		}
		#endregion Edit


		#region Labels
		void dropdownopening_Labels(object sender, EventArgs e)
		{
			it_insertSpellLabels.Enabled = pathSpells.Checked
										&& Type == Type2da.TYPE_SPELLS;

			it_insertRaceLabels .Enabled = pathRacialSubtypes.Checked
										&& Type == Type2da.TYPE_RACIAL;

			it_insertClassLabels.Enabled = pathClasses.Checked
										&& Type == Type2da.TYPE_CLASSES;
		}

		/// <summary>
		/// Handles clicking the PathSpells menuitem.
		/// Intended to add labels from Spells.2da to the 'spellLabels' list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathSpells(object sender, EventArgs e)
		{
			if (!pathSpells.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.Title    = "Select Spells.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "spells.2da";

					if (ofd.ShowDialog() == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, spellLabels, pathSpells);

						if (!hasLabels
							&& Type == Type2da.TYPE_SPELLS
							&& spellLabels.Count != 0)
						{
							LabelTreenodes(spellLabels);
						}
					}
				}
			}
			else
			{
				pathSpells.Checked = false;
				spellLabels.Clear();

				if (!hasLabels && Type == Type2da.TYPE_SPELLS)
					ClearTreenodeLabels();
			}
		}

		/// <summary>
		/// Handles clicking the PathRacialSubtypes menuitem.
		/// Intended to add labels from RacialSubtypes.2da to the 'raceLabels'
		/// list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathRacialSubtypes(object sender, EventArgs e)
		{
			if (!pathRacialSubtypes.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.Title    = "Select RacialSubtypes.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "racialsubtypes.2da";

					if (ofd.ShowDialog() == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, raceLabels, pathRacialSubtypes);

						if (!hasLabels
							&& Type == Type2da.TYPE_RACIAL
							&& raceLabels.Count != 0)
						{
							LabelTreenodes(raceLabels);
						}
					}
				}
			}
			else
			{
				pathRacialSubtypes.Checked = false;
				raceLabels.Clear();

				if (!hasLabels && Type == Type2da.TYPE_RACIAL)
					ClearTreenodeLabels();
			}
		}

		/// <summary>
		/// Handles clicking the PathClasses menuitem.
		/// Intended to add labels from Classes.2da to the 'classLabels' list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathClasses(object sender, EventArgs e)
		{
			if (!pathClasses.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.Title    = "Select Classes.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "classes.2da";

					if (ofd.ShowDialog() == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, classLabels, pathClasses);

						if (!hasLabels
							&& Type == Type2da.TYPE_CLASSES
							&& classLabels.Count != 0)
						{
							LabelTreenodes(classLabels);
						}
					}
				}
			}
			else
			{
				pathClasses.Checked = false;
				classLabels.Clear();

				if (!hasLabels && Type == Type2da.TYPE_CLASSES)
					ClearTreenodeLabels();
			}
		}

		/// <summary>
		/// Labels the treenodes after groping a 2da for labels.
		/// </summary>
		/// <param name="labels">a list of labels to assign to treenodes</param>
		void LabelTreenodes(List<string> labels)
		{
			int total = Tree.Nodes.Count;

			int preLength = (total - 1).ToString().Length + 1;
			string pre;

			int id = -1;
			foreach (var label in labels)
			{
				if (++id < total)
				{
					if (!String.IsNullOrEmpty(label))
					{
						pre = id.ToString();
						while (pre.Length != preLength)
							pre += " ";
					}
					else
						pre = String.Empty;

					Tree.Nodes[id].Text = pre + label;
				}
				else
					break;
			}
		}

		/// <summary>
		/// Clears the treenode labels after degroping a pathed 2da.
		/// </summary>
		void ClearTreenodeLabels()
		{
			int total = Tree.Nodes.Count;
			for (int id = 0; id != total; ++id)
			{
				Tree.Nodes[id].Text = id.ToString();
			}
		}

		/// <summary>
		/// Handles clicking the PathFeat menuitem.
		/// Intended to add labels from Feat.2da to the 'featsLabels' list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathFeat(object sender, EventArgs e)
		{
			if (!pathFeat.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.Title    = "Select Feat.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "feat.2da";

					if (ofd.ShowDialog() == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, featsLabels, pathFeat);
					}
				}
			}
			else
			{
				pathFeat.Checked = false;
				featsLabels.Clear();
			}
		}

		/// <summary>
		/// Gets the label-string from Classes.2da or RacialSubtypes.2da or
		/// Spells.2da or Feat.2da.
		/// </summary>
		/// <param name="pfe2da"></param>
		/// <param name="labels"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		void GropeLabels(string pfe2da, ICollection<string> labels, ToolStripMenuItem item)
		{
			if (File.Exists(pfe2da))
			{
				string[] rows = File.ReadAllLines(pfe2da);

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
											  + " to access it here.";
							MessageBox.Show(info,
											"  ERROR",
											MessageBoxButtons.OK,
											MessageBoxIcon.Error,
											MessageBoxDefaultButton.Button1);
							return;
						}
					}
				}


				labels.Clear();

				for (int i = 0; i != rows.Length; ++i)
					rows[i] = rows[i].Trim();

				string[] fields;
				foreach (string row in rows)
				{
					if (!String.IsNullOrEmpty(row))
					{
						fields = row.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

						int id;
						if (Int32.TryParse(fields[0], out id)) // is a valid 2da row
						{
							labels.Add(fields[1]); // and hope for the best.
						}
					}
				}

				item.Checked = (labels.Count != 0);
			}
		}


//		/// <summary>
//		/// Invokes and handles the SetCoreAiVersion inputbox via the Edit.
//		/// NOTE: The version is not really the version of the CoreAI. It's the
//		/// version of the data of each entry. Apparently it can be updated IG
//		/// (after info-data has already been cached to the module-object) such
//		/// that that stale data will be bypassed in favor of the new data. But
//		/// I haven't looked into it thoroughly.
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="e"></param>
//		void Click_setCoreAiVersion(object sender, EventArgs e)
//		{
//			switch (Type)
//			{
//				case Type2da.TYPE_SPELLS:
//					SetInfoVersion_spells();
//
//					it_ApplyGlobal.Enabled = SpellsChanged.Count != 0;
//					it_GotoChanged.Enabled = SpellsChanged.Count != 0 || SpareChange();
//					break;
//
//				case Type2da.TYPE_RACIAL:
//					SetInfoVersion_racial();
//
//					it_ApplyGlobal.Enabled = RacesChanged.Count != 0;
//					it_GotoChanged.Enabled = RacesChanged.Count != 0 || SpareChange();
//					break;
//
//				case Type2da.TYPE_CLASSES:
//					SetInfoVersion_classes();
//
//					it_ApplyGlobal.Enabled = ClassesChanged.Count != 0;
//					it_GotoChanged.Enabled = ClassesChanged.Count != 0 || SpareChange();
//					break;
//			}
//		}

		/// <summary>
		/// IMPORTANT: This is an interim function that forcefully clears the
		/// InfoVersion bits. InfoVersion is obsolete in TonyAI 2.3+ - the bits
		/// have been repurposed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_clearCoreAiVersion(object sender, EventArgs e)
		{
			BypassInfoVersion = true;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					SetInfoVersion_spells("0", true);

					it_ApplyGlobal.Enabled = SpellsChanged.Count != 0;
					it_GotoChanged.Enabled = SpellsChanged.Count != 0 || SpareChange();
					break;

				case Type2da.TYPE_RACIAL:
					SetInfoVersion_racial("0", true);

					it_ApplyGlobal.Enabled = RacesChanged.Count != 0;
					it_GotoChanged.Enabled = RacesChanged.Count != 0 || SpareChange();
					break;

				case Type2da.TYPE_CLASSES:
					SetInfoVersion_classes("0", true);

					it_ApplyGlobal.Enabled = ClassesChanged.Count != 0;
					it_GotoChanged.Enabled = ClassesChanged.Count != 0 || SpareChange();
					break;
			}

			BypassInfoVersion = false;
		}

		/// <summary>
		/// Inserts labels of a groped Spells.2da into the 'Spells' list and the
		/// tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_insertSpellLabels(object sender, EventArgs e)
		{
			if (spellLabels.Count != 0)
			{
				Text = "nwn2_ai_2da_editor - " + _pfe + " *"; // titlebar text (append path of saved file + asterisk)

				hasLabels = true;

				Spell spell;

				int j = -1;
				int total = spellLabels.Count;
				for (int i = 0; i != Spells.Count; ++i)
				{
					if (++j < total)
					{
						spell = Spells[i];
						spell.label = spellLabels[j];
						spell.isChanged = true;
						Spells[i] = spell;
					}
					else
						break;
				}
				GrowTree();
			}
		}

		/// <summary>
		/// Inserts labels of a groped RacialSubtypes.2da into the 'Races' list
		/// and the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_insertRaceLabels(object sender, EventArgs e)
		{
			if (raceLabels.Count != 0)
			{
				Text = "nwn2_ai_2da_editor - " + _pfe + " *"; // titlebar text (append path of saved file + asterisk)

				hasLabels = true;

				Race race;

				int j = -1;
				int total = raceLabels.Count;
				for (int i = 0; i != Races.Count; ++i)
				{
					if (++j < total)
					{
						race = Races[i];
						race.label = raceLabels[j];
						race.isChanged = true;
						Races[i] = race;
					}
					else
						break;
				}
				GrowTree();
			}
		}

		/// <summary>
		/// Inserts labels of a groped Classes.2da into the 'Classes' list and
		/// the tree.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_insertClassLabels(object sender, EventArgs e)
		{
			if (classLabels.Count != 0)
			{
				Text = "nwn2_ai_2da_editor - " + _pfe + " *"; // titlebar text (append path of saved file + asterisk)

				hasLabels = true;

				Class @class;

				int j = -1;
				int total = classLabels.Count;
				for (int i = 0; i != Classes.Count; ++i)
				{
					if (++j < total)
					{
						@class = Classes[i];
						@class.label = classLabels[j];
						@class.isChanged = true;
						Classes[i] = @class;
					}
					else
						break;
				}
				GrowTree();
			}
		}
		#endregion Labels


		#region Help
		void Click_about(object sender, EventArgs e)
		{
			DateTime dt = Assembly.GetExecutingAssembly().GetLinkerTime();
			string info = String.Format(System.Globalization.CultureInfo.CurrentCulture,
										"{0:yyyy MMM d}  {0:HH}:{0:mm}:{0:ss} {0:zzz}",
										dt);
			// what a fucking pain in the ass.

			var an = Assembly.GetExecutingAssembly().GetName();
			string ver = "Ver "
					   + an.Version.Major + "."
					   + an.Version.Minor + "."
					   + an.Version.Build + "."
					   + an.Version.Revision;
#if DEBUG
			ver += " - debug";
#else
			ver += " - release";
#endif

			MessageBox.Show(info + Environment.NewLine + ver,
							"  About - nwn2_ai_2da_editor",
							MessageBoxButtons.OK,
							MessageBoxIcon.None,
							MessageBoxDefaultButton.Button1);
		}
		#endregion Help


		#region Changes functs
		/// <summary>
		/// Gets if there is unsaved modifications.
		/// </summary>
		/// <returns></returns>
		bool GetChanged()
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					foreach (var spell in Spells)
					{
						if (spell.isChanged || spell.differ != tabcontrol_Spells.bit_clear)
							return true;
					}
					break;

				case Type2da.TYPE_RACIAL:
					foreach (var race in Races)
					{
						if (race.isChanged || race.differ != tabcontrol_Racial.bit_clear)
							return true;
					}
					break;

				case Type2da.TYPE_CLASSES:
					foreach (var @class in Classes)
					{
						if (@class.isChanged || @class.differ != tabcontrol_Classes.bit_clear)
							return true;
					}
					break;
			}

			return false;
		}

		/// <summary>
		/// Checks if there are any Applied structs.
		/// </summary>
		/// <returns>true if basic structs have yet to be saved</returns>
		bool SpareChange()
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					foreach (var spell in Spells)
					{
						if (spell.isChanged)
							return true;
					}
					break;

				case Type2da.TYPE_RACIAL:
					foreach (var race in Races)
					{
						if (race.isChanged)
							return true;
					}
					break;

				case Type2da.TYPE_CLASSES:
					foreach (var @class in Classes)
					{
						if (@class.isChanged)
							return true;
					}
					break;
			}
			return false;
		}

		/// <summary>
		/// Checks if there is any dirty data - data that's been modified but
		/// has yet to be Applied.
		/// </summary>
		/// <returns>true if there are dirty structs</returns>
		bool DirtyData()
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					if (SpellsChanged.Count != 0)
						return true;

					break;

				case Type2da.TYPE_RACIAL:
					if (RacesChanged.Count != 0)
						return true;

					break;

				case Type2da.TYPE_CLASSES:
					if (ClassesChanged.Count != 0)
						return true;

					break;
			}
			return false;
		}
		#endregion Changes functs


		/// <summary>
		/// Applies modified data to any struct that has changed. See also
		/// <see cref="Click_apply"/>
		/// </summary>
		void ApplyDirtyData()
		{
			Text = "nwn2_ai_2da_editor - " + _pfe + " *"; // titlebar text (append path of saved file + asterisk)

			it_ApplyGlobal.Enabled = false;

			int total;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
				{
					Spell spell;

					total = Spells.Count;
					for (int id = 0; id != total; ++id)
					{
						spell = Spells[id];

						if (spell.differ != tabcontrol_Spells.bit_clear)
						{
							spell.differ = tabcontrol_Spells.bit_clear;
							spell.isChanged = true; // this flag will be cleared by Write2daFile()

							SpellChanged spellchanged = SpellsChanged[id];

							spell.spellinfo    = spellchanged.spellinfo;
							spell.targetinfo   = spellchanged.targetinfo;
							spell.effectweight = spellchanged.effectweight;
							spell.effecttypes  = spellchanged.effecttypes;
							spell.damageinfo   = spellchanged.damageinfo;
							spell.savetype     = spellchanged.savetype;
							spell.savedctype   = spellchanged.savedctype;

							Spells[id] = spell;

							SpellsChanged.Remove(id);

							if (id == Id) // is currently selected tree-node
							{
								(HenchControl as tabcontrol_Spells).SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current spell jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}

				case Type2da.TYPE_RACIAL:
				{
					Race race;

					total = Races.Count;
					for (int id = 0; id != total; ++id)
					{
						race = Races[id];

						if (race.differ != tabcontrol_Racial.bit_clear)
						{
							race.differ = tabcontrol_Racial.bit_clear;
							race.isChanged = true; // this flag will be cleared by Write2daFile()

							RaceChanged racechanged = RacesChanged[id];

							race.flags = racechanged.flags;
							race.feat1 = racechanged.feat1;
							race.feat2 = racechanged.feat2;
							race.feat3 = racechanged.feat3;
							race.feat4 = racechanged.feat4;
							race.feat5 = racechanged.feat5;

							Races[id] = race;

							RacesChanged.Remove(id);

							if (id == Id) // is currently selected tree-node
							{
								(HenchControl as tabcontrol_Racial).SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current race jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}

				case Type2da.TYPE_CLASSES:
				{
					Class @class;

					total = Classes.Count;
					for (int id = 0; id != total; ++id)
					{
						@class = Classes[id];

						if (@class.differ != tabcontrol_Classes.bit_clear)
						{
							@class.differ = tabcontrol_Classes.bit_clear;
							@class.isChanged = true; // this flag will be cleared by Write2daFile()

							ClassChanged classchanged = ClassesChanged[id];

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

							Classes[id] = @class;

							ClassesChanged.Remove(id);

							if (id == Id) // is currently selected tree-node
							{
								(HenchControl as tabcontrol_Classes).SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current class jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}
			}
		}


		#region Write
		/// <summary>
		/// Writes all Applied data to 2da-file.
		/// </summary>
		void Write2daFile()
		{
			Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of saved file)

			it_GotoChanged.Enabled = false;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					WriteHenchSpells();
					break;

				case Type2da.TYPE_RACIAL:
					WriteHenchRacial();
					break;

				case Type2da.TYPE_CLASSES:
					WriteHenchClasses();
					break;
			}
		}

		/// <summary>
		/// Writes HenchSpells.2da
		/// </summary>
		void WriteHenchSpells()
		{
			Spell clear;

			int total = Spells.Count; // clear any 'isChanged' flags
			for (int id = 0; id != total; ++id)
			{
				clear = Spells[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					Spells[id] = clear;

					Tree.Nodes[id].ForeColor = DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(_pfe))
			{
				sw.WriteLine("2DA V2.0");
				sw.WriteLine("");
				sw.WriteLine(" Label SpellInfo TargetInfo EffectWeight EffectTypes DamageInfo SaveType SaveDCType");

				string line;

				foreach (var spell in Spells) // this writes Applied data only.
				{
					line = spell.id + " ";

					if (!String.IsNullOrEmpty(spell.label))
					{
						line += spell.label;
					}
					else
						line += blank;

					line += " ";

					if (spell.spellinfo != 0)
					{
						line += spell.spellinfo.ToString();
					}
					else
						line += blank;

					line += " ";

					if (spell.targetinfo != 0)
					{
						line += spell.targetinfo.ToString();
					}
					else
						line += blank;

					line += " ";

					if (!FloatsEqual(spell.effectweight, 0.0f))
					{
						line += Float2daFormat(spell.effectweight);
					}
					else
						line += blank;

					line += " ";

					if (spell.effecttypes != 0)
					{
						line += spell.effecttypes.ToString();
					}
					else
						line += blank;

					line += " ";

					if (spell.damageinfo != 0)
					{
						line += spell.damageinfo.ToString();
					}
					else
						line += blank;

					line += " ";

					if (spell.savetype != 0)
					{
						line += spell.savetype.ToString();
					}
					else
						line += blank;

					line += " ";

					if (spell.savedctype != 0)
					{
						line += spell.savedctype.ToString();
					}
					else
						line += blank;

					sw.WriteLine(line);
				}
			}
		}

		/// <summary>
		/// Writes HenchRacial.2da
		/// </summary>
		void WriteHenchRacial()
		{
			Race clear;

			int total = Races.Count; // clear any 'isChanged' flags
			for (int id = 0; id != total; ++id)
			{
				clear = Races[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					Races[id] = clear;

					Tree.Nodes[id].ForeColor = DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(_pfe))
			{
				sw.WriteLine("2DA V2.0");
				sw.WriteLine("");
				sw.WriteLine(" Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5");

				string line;

				foreach (var race in Races) // this writes Applied data only.
				{
					line = race.id + " ";

					if (!String.IsNullOrEmpty(race.label))
					{
						line += race.label;
					}
					else
						line += blank;

					line += " ";

					if (race.flags != 0)
					{
						line += race.flags.ToString();
					}
					else
						line += blank;

					line += " ";

					if (race.feat1 != 0)
					{
						line += race.feat1.ToString();
					}
					else
						line += blank;

					line += " ";

					if (race.feat2 != 0)
					{
						line += race.feat2.ToString();
					}
					else
						line += blank;

					line += " ";

					if (race.feat3 != 0)
					{
						line += race.feat3.ToString();
					}
					else
						line += blank;

					line += " ";

					if (race.feat4 != 0)
					{
						line += race.feat4.ToString();
					}
					else
						line += blank;

					line += " ";

					if (race.feat5 != 0)
					{
						line += race.feat5.ToString();
					}
					else
						line += blank;

					sw.WriteLine(line);
				}
			}
		}

		/// <summary>
		/// Writes HenchClasses.2da
		/// </summary>
		void WriteHenchClasses()
		{
			Class clear;

			int total = Classes.Count; // clear any 'isChanged' flags
			for (int id = 0; id != total; ++id)
			{
				clear = Classes[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					Classes[id] = clear;

					Tree.Nodes[id].ForeColor = DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(_pfe))
			{
				sw.WriteLine("2DA V2.0");
				sw.WriteLine("");
				sw.WriteLine(" Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5 FeatSpell6 FeatSpell7 FeatSpell8 FeatSpell9 FeatSpell10 FeatSpell11");

				string line;

				foreach (var @class in Classes) // this writes Applied data only.
				{
					line = @class.id + " ";

					if (!String.IsNullOrEmpty(@class.label))
					{
						line += @class.label;
					}
					else
						line += blank;

					line += " ";

					if (@class.flags != 0)
					{
						line += @class.flags.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat1 != 0)
					{
						line += @class.feat1.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat2 != 0)
					{
						line += @class.feat2.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat3 != 0)
					{
						line += @class.feat3.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat4 != 0)
					{
						line += @class.feat4.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat5 != 0)
					{
						line += @class.feat5.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat6 != 0)
					{
						line += @class.feat6.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat7 != 0)
					{
						line += @class.feat7.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat8 != 0)
					{
						line += @class.feat8.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat9 != 0)
					{
						line += @class.feat9.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat10 != 0)
					{
						line += @class.feat10.ToString();
					}
					else
						line += blank;

					line += " ";

					if (@class.feat11 != 0)
					{
						line += @class.feat11.ToString();
					}
					else
						line += blank;

					sw.WriteLine(line);
				}
			}
		}
		#endregion Write
	}



	/// <summary>
	/// Lifted from StackOverflow.com:
	/// https://stackoverflow.com/questions/1600962/displaying-the-build-date#answer-1600990
	/// </summary>
	public static class DateTimeExtension
	{
		public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
		{
			var filePath = assembly.Location;
			const int c_PeHeaderOffset = 60;
			const int c_LinkerTimestampOffset = 8;

			var buffer = new byte[2048];

			using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				stream.Read(buffer, 0, 2048);

			var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
			var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

			var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

			var tz = target ?? TimeZoneInfo.Local;
			var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

			return localTime;
		}
	}
}
