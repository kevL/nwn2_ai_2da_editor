﻿using System;
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
	partial class MainForm
	{
		/// <summary>
		/// A list that holds labels for classes in Classes.2da.
		/// - optional
		/// </summary>
		List<string> classLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for races in Races.2da.
		/// - optional
		/// </summary>
		List<string> raceLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for spells in Spells.2da.
		/// - optional
		/// </summary>
		List<string> spellLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for feats in Feat.2da.
		/// - optional
		/// </summary>
		List<string> featsLabels = new List<string>();



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
							+ "\tabort : Cancel the operation"
							+ Environment.NewLine
							+ "\tretry : Apply all modified data and Save"
							+ Environment.NewLine
							+ "\tignore : Save currently applied data only";

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
				sfd.Title = "Save as ...";
				sfd.Filter = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
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
						while (!Spells[id].isChanged && Spells[id].differ == bit_clear)
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
						while (!Races[id].isChanged && Races[id].differ == bit_clear)
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
						while (!Classes[id].isChanged && Classes[id].differ == bit_clear)
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
			int i;
			float f;

			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					switch (cols_HenchSpells.SelectedIndex)
					{
						case 2: // NOTE: The menuitem shall be enabled for Copy_decimal only.
							info = EffectWeight_text.Text;
							if (Single.TryParse(info, out f))
								return info;

							return String.Empty;

						case 0: info = SpellInfo_text  .Text; break;
						case 1: info = TargetInfo_text .Text; break;
						case 3: info = EffectTypes_text.Text; break;
						case 4: info = DamageInfo_text .Text; break;
						case 5: info = SaveType_text   .Text; break;
						case 6: info = SaveDCType_text .Text; break;
					}
					break;

				case Type2da.TYPE_RACIAL:
					switch (cols_HenchRacial.SelectedIndex)
					{
						case 0: info = RacialFlags_text.Text; break;
						case 1: info = RacialFeat1_text.Text; break;
						case 2: info = RacialFeat2_text.Text; break;
						case 3: info = RacialFeat3_text.Text; break;
						case 4: info = RacialFeat4_text.Text; break;
						case 5: info = RacialFeat5_text.Text; break;
					}
					break;

				case Type2da.TYPE_CLASSES:
					switch (cols_HenchClasses.SelectedIndex)
					{
						case  0: info = ClassFlags_text .Text; break;
						case  1: info = ClassFeat1_text .Text; break;
						case  2: info = ClassFeat2_text .Text; break;
						case  3: info = ClassFeat3_text .Text; break;
						case  4: info = ClassFeat4_text .Text; break;
						case  5: info = ClassFeat5_text .Text; break;
						case  6: info = ClassFeat6_text .Text; break;
						case  7: info = ClassFeat7_text .Text; break;
						case  8: info = ClassFeat8_text .Text; break;
						case  9: info = ClassFeat9_text .Text; break;
						case 10: info = ClassFeat10_text.Text; break;
						case 11: info = ClassFeat11_text.Text; break;
					}
					break;
			}

			if (Int32.TryParse(info, out i))
				return info;

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


		/// <summary>
		/// Invokes and handles the SetCoreAiVersion inputbox via the Edit.
		/// NOTE: The version is not really the version of the CoreAI. It's the
		/// version of the data of each entry. Apparently it can be updated IG
		/// (after info-data has already been cached to the module-object) such
		/// that that stale data will be bypassed in favor of the new data. But
		/// I haven't looked into it thoroughly.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_setCoreAiVersion(object sender, EventArgs e)
		{
			switch (Type)
			{
				case Type2da.TYPE_SPELLS:
					SetInfoVersion_spells();

					applyGlobal    .Enabled = SpellsChanged.Count != 0;
					gotoNextChanged.Enabled = SpellsChanged.Count != 0 || SpareChange();
					break;

				case Type2da.TYPE_RACIAL:
					SetInfoVersion_racial();

					applyGlobal    .Enabled = RacesChanged.Count != 0;
					gotoNextChanged.Enabled = RacesChanged.Count != 0 || SpareChange();
					break;

				case Type2da.TYPE_CLASSES:
					SetInfoVersion_classes();

					applyGlobal    .Enabled = ClassesChanged.Count != 0;
					gotoNextChanged.Enabled = ClassesChanged.Count != 0 || SpareChange();
					break;
			}
		}

		void Click_clearCoreAiVersion(object sender, EventArgs e)
		{
			
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

				Class clas;

				int j = -1;
				int total = classLabels.Count;
				for (int i = 0; i != Classes.Count; ++i)
				{
					if (++j < total)
					{
						clas = Classes[i];
						clas.label = classLabels[j];
						clas.isChanged = true;
						Classes[i] = clas;
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
						if (spell.isChanged || spell.differ != bit_clear)
							return true;
					}
					break;

				case Type2da.TYPE_RACIAL:
					foreach (var race in Races)
					{
						if (race.isChanged || race.differ != bit_clear)
							return true;
					}
					break;

				case Type2da.TYPE_CLASSES:
					foreach (var clas in Classes)
					{
						if (clas.isChanged || clas.differ != bit_clear)
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
					foreach (var clas in Classes)
					{
						if (clas.isChanged)
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

			applyGlobal.Enabled = false;

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

						if (spell.differ != bit_clear)
						{
							spell.differ = bit_clear;
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
								SpellInfo_reset   .ForeColor = DefaultForeColor;
								TargetInfo_reset  .ForeColor = DefaultForeColor;
								EffectWeight_reset.ForeColor = DefaultForeColor;
								EffectTypes_reset .ForeColor = DefaultForeColor;
								DamageInfo_reset  .ForeColor = DefaultForeColor;
								SaveType_reset    .ForeColor = DefaultForeColor;
								SaveDCType_reset  .ForeColor = DefaultForeColor;

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

						if (race.differ != bit_clear)
						{
							race.differ = bit_clear;
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
								RacialFlags_reset.ForeColor = DefaultForeColor;
								RacialFeat1_reset.ForeColor = DefaultForeColor;
								RacialFeat2_reset.ForeColor = DefaultForeColor;
								RacialFeat3_reset.ForeColor = DefaultForeColor;
								RacialFeat4_reset.ForeColor = DefaultForeColor;
								RacialFeat5_reset.ForeColor = DefaultForeColor;

								AfterSelect_node(null, null); // refresh all displayed data for the current race jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}

				case Type2da.TYPE_CLASSES:
				{
					Class clas;

					total = Classes.Count;
					for (int id = 0; id != total; ++id)
					{
						clas = Classes[id];

						if (clas.differ != bit_clear)
						{
							clas.differ = bit_clear;
							clas.isChanged = true; // this flag will be cleared by Write2daFile()

							ClassChanged claschanged = ClassesChanged[id];

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

							Classes[id] = clas;

							ClassesChanged.Remove(id);

							if (id == Id) // is currently selected tree-node
							{
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

								AfterSelect_node(null, null); // refresh all displayed data for the current class jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}
			}
		}


		/// <summary>
		/// Writes all Applied data to 2da-file.
		/// </summary>
		void Write2daFile()
		{
			Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of saved file)

			gotoNextChanged.Enabled = false;

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
						line += FormatFloat(spell.effectweight);
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

				foreach (var clas in Classes) // this writes Applied data only.
				{
					line = clas.id + " ";

					if (!String.IsNullOrEmpty(clas.label))
					{
						line += clas.label;
					}
					else
						line += blank;

					line += " ";

					if (clas.flags != 0)
					{
						line += clas.flags.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat1 != 0)
					{
						line += clas.feat1.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat2 != 0)
					{
						line += clas.feat2.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat3 != 0)
					{
						line += clas.feat3.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat4 != 0)
					{
						line += clas.feat4.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat5 != 0)
					{
						line += clas.feat5.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat6 != 0)
					{
						line += clas.feat6.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat7 != 0)
					{
						line += clas.feat7.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat8 != 0)
					{
						line += clas.feat8.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat9 != 0)
					{
						line += clas.feat9.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat10 != 0)
					{
						line += clas.feat10.ToString();
					}
					else
						line += blank;

					line += " ";

					if (clas.feat11 != 0)
					{
						line += clas.feat11.ToString();
					}
					else
						line += blank;

					sw.WriteLine(line);
				}
			}
		}
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
