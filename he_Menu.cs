using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Event handlers for menu-items and related stuff.
	partial class he
	{
		#region Fields (static)
		/// <summary>
		/// A list that holds labels for the spells in Spells.2da.
		/// - optional
		/// </summary>
		internal static List<string> spellLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for the races in Races.2da.
		/// - optional
		/// </summary>
		internal static List<string> raceLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for the classes in Classes.2da.
		/// - optional
		/// </summary>
		internal static List<string> classLabels = new List<string>();

		/// <summary>
		/// A list that holds labels for the feats in Feat.2da.
		/// - optional
		/// </summary>
		internal static List<string> featLabels = new List<string>();


		/// <summary>
		/// A list that holds labels for spellscripts in Spells.2da.
		/// - optional
		/// </summary>
		/// <remarks>For the Scripter.</remarks>
		static List<string> spellScripts = new List<string>();

		/// <summary>
		/// Stores relevant AI field-data in Spells.2da. A list of rows that
		/// contains a list of cell-fields.
		/// </summary>
		/// <remarks>For the Scripter.</remarks>
		static List<List<string>> spellTable = new List<List<string>>();
		#endregion Fields (static)


		#region File
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void dropdownopening_File(object sender, EventArgs e)
		{
			it_Recent.Visible = it_Recent.DropDownItems.Count != 0;
		}

		/// <summary>
		/// Handles FileMenu close program event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_quit(object sender, EventArgs e)
		{
			if (isChanged())
			{
				string info = "Data has changed."
							+ Environment.NewLine + Environment.NewLine
							+ "Okay to exit ...";
				using (var ib = new infobox(" Warning", info, "yessir", "no"))
				{
					if (ib.ShowDialog(this) != DialogResult.OK)
						return;
				}
			}
			Close();
		}

		/// <summary>
		/// Handles FileMenu open file event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_open(object sender, EventArgs e)
		{
			if (isChanged())
			{
				string info = "Data has changed."
							+ Environment.NewLine + Environment.NewLine
							+ "Okay to exit ...";
				using (var ib = new infobox(" Warning", info, "yessir", "no"))
				{
					if (ib.ShowDialog(this) != DialogResult.OK)
						return;
				}
			}

			using (var ofd = new OpenFileDialog())
			{
				ofd.AutoUpgradeEnabled = false; // loL fu.net

				ofd.Title  = "Select a Hench*.2da file";
				ofd.Filter = "2da files (*.2da)|*.2da|All files (*.*)|*.*";

				if (ofd.ShowDialog(this) == DialogResult.OK)
				{
					_pfe = ofd.FileName;
					Load_file();
				}
			}
		}

		/// <summary>
		/// Checks recents when the dropdown opens and deletes the paths of
		/// files that don't exist on disk.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void dropdownopening_Recent(object sender, EventArgs e)
		{
			ToolStripItemCollection recents = it_Recent.DropDownItems;
			ToolStripItem it;

			for (int i = recents.Count - 1; i != -1; --i)
			{
				if (!File.Exists((it = recents[i]).Text))
					recents.Remove(it);
			}
		}

		/// <summary>
		/// Opens a 2da-file from the Recent-files list. Removes the item from
		/// the list if it was not found on disk.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_recent(object sender, EventArgs e)
		{
			if (isChanged())
			{
				string info = "Data has changed."
							+ Environment.NewLine + Environment.NewLine
							+ "Okay to exit ...";
				using (var ib = new infobox(" Warning", info, "yessir", "no"))
				{
					if (ib.ShowDialog(this) != DialogResult.OK)
						return;
				}
			}

			_pfe = (sender as ToolStripMenuItem).Text;
			Load_file();
		}

		/// <summary>
		/// Handles FileMenu save file event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_save(object sender, EventArgs e)
		{
			if (!hasDirtyData())
			{
				if (sender == null) // is Saveas
				{
					_pfe = _pfeT;
					_pfeT = String.Empty;
					recent_add();
				}

				Write2daFile();
			}
			else
			{
				const string info = "There is data that has been altered but not applied.";
				using (var ib = new infobox(" Attention", info, "just save", "cancel", "apply + save"))
				{
					switch (ib.ShowDialog(this))
					{
						case DialogResult.Cancel:
							_pfeT = String.Empty;
							break;

						case DialogResult.Retry:
							applyall();
							goto case DialogResult.OK;

						case DialogResult.OK:
							if (sender == null) // is Saveas
							{
								_pfe = _pfeT;
								_pfeT = String.Empty;
								recent_add();
							}

							Write2daFile();
							break;
					}
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
				sfd.AutoUpgradeEnabled = false; // loL fu.net

				sfd.Title    = "Save as ...";
				sfd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
				sfd.FileName = Path.GetFileName(_pfe);

				string dir = Path.GetDirectoryName(_pfe);
				if (Directory.Exists(dir))
					sfd.InitialDirectory = dir;

				if (sfd.ShowDialog(this) == DialogResult.OK)
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
			applyall();
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
					case Type2da.Spells:
						while (!Spells[id].isChanged && Spells[id].differ == control_Spells.bit_clean)
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

					case Type2da.Racial:
						while (!Races[id].isChanged && Races[id].differ == control_Racial.bit_clean)
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

					case Type2da.Classes:
						while (!Classes[id].isChanged && Classes[id].differ == control_Classes.bit_clean)
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
			string info = HenchControl.GetMasterText();

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
			string info = HenchControl.GetMasterText();

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
			string info = HenchControl.GetMasterText();

			if (!String.IsNullOrEmpty(info))
			{
				info = Convert.ToString(Int32.Parse(info), 2).PadLeft(32, '0');
				Clipboard.SetText(info);
			}
			else
				Clipboard.Clear();
		}
		#endregion Edit


		#region Edition
		#endregion Edition


		#region Labels
		void dropdownopening_Labels(object sender, EventArgs e)
		{
			it_insertSpellLabels.Enabled = it_pathSpells.Checked
										&& Type == Type2da.Spells;

			it_insertRaceLabels .Enabled = it_pathRacialSubtypes.Checked
										&& Type == Type2da.Racial;

			it_insertClassLabels.Enabled = it_pathClasses.Checked
										&& Type == Type2da.Classes;
		}

		/// <summary>
		/// Handles clicking the PathSpells menuitem.
		/// Intended to add labels from Spells.2da to the 'spellLabels' list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathSpells(object sender, EventArgs e)
		{
			if (!it_pathSpells.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.AutoUpgradeEnabled = false; // loL fu.net

					ofd.Title    = "Select Spells.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "spells.2da";

					string dir = null;
					string pfe = Path.Combine(Application.StartupPath, RD_LABELS_CFG);
					if (File.Exists(pfe))
					{
						dir = File.ReadAllText(pfe);
						if (Directory.Exists(dir))
							ofd.InitialDirectory = dir;
					}

					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, spellLabels, it_pathSpells);

						if (Type != Type2da.None && spellLabels.Count != 0)
						{
							if (!hasLabels && Type == Type2da.Spells)
								LabelTreenodes(spellLabels);

							HenchControl.SetSpellLabelTexts();
						}

						if (dir != null)
						{
							dir = Path.GetDirectoryName(ofd.FileName);
							File.WriteAllText(pfe, dir);
						}
					}
				}
			}
			else
			{
				it_pathSpells.Checked = false;

				spellLabels .Clear();
				spellScripts.Clear();
				spellTable  .Clear();

				if (Type != Type2da.None)
				{
					if (!hasLabels && Type == Type2da.Spells)
						ClearTreeLabels();

					HenchControl.ClearSpellLabelTexts();
				}
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
			if (!it_pathRacialSubtypes.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.AutoUpgradeEnabled = false; // loL fu.net

					ofd.Title    = "Select RacialSubtypes.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "racialsubtypes.2da";

					string dir = null;
					string pfe = Path.Combine(Application.StartupPath, RD_LABELS_CFG);
					if (File.Exists(pfe))
					{
						dir = File.ReadAllText(pfe);
						if (Directory.Exists(dir))
							ofd.InitialDirectory = dir;
					}

					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, raceLabels, it_pathRacialSubtypes);

						if (!hasLabels
							&& Type == Type2da.Racial
							&& raceLabels.Count != 0)
						{
							LabelTreenodes(raceLabels);
						}

						if (dir != null)
						{
							dir = Path.GetDirectoryName(ofd.FileName);
							File.WriteAllText(pfe, dir);
						}
					}
				}
			}
			else
			{
				it_pathRacialSubtypes.Checked = false;
				raceLabels.Clear();

				if (!hasLabels && Type == Type2da.Racial)
					ClearTreeLabels();
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
			if (!it_pathClasses.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.AutoUpgradeEnabled = false; // loL fu.net

					ofd.Title    = "Select Classes.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "classes.2da";

					string dir = null;
					string pfe = Path.Combine(Application.StartupPath, RD_LABELS_CFG);
					if (File.Exists(pfe))
					{
						dir = File.ReadAllText(pfe);
						if (Directory.Exists(dir))
							ofd.InitialDirectory = dir;
					}

					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, classLabels, it_pathClasses);

						if (!hasLabels
							&& Type == Type2da.Classes
							&& classLabels.Count != 0)
						{
							LabelTreenodes(classLabels);
						}

						if (dir != null)
						{
							dir = Path.GetDirectoryName(ofd.FileName);
							File.WriteAllText(pfe, dir);
						}
					}
				}
			}
			else
			{
				it_pathClasses.Checked = false;
				classLabels.Clear();

				if (!hasLabels && Type == Type2da.Classes)
					ClearTreeLabels();
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
		void ClearTreeLabels()
		{
			int total = Tree.Nodes.Count;
			for (int id = 0; id != total; ++id)
			{
				Tree.Nodes[id].Text = id.ToString();
			}
		}

		/// <summary>
		/// Handles clicking the PathFeat menuitem.
		/// Intended to add labels from Feat.2da to the 'featLabels' list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_pathFeat(object sender, EventArgs e)
		{
			if (!it_pathFeat.Checked)
			{
				using (var ofd = new OpenFileDialog())
				{
					ofd.AutoUpgradeEnabled = false; // loL fu.net

					ofd.Title    = "Select Feat.2da";
					ofd.Filter   = "2da files (*.2da)|*.2da|All files (*.*)|*.*";
					ofd.FileName = "feat.2da";

					string dir = null;
					string pfe = Path.Combine(Application.StartupPath, RD_LABELS_CFG);
					if (File.Exists(pfe))
					{
						dir = File.ReadAllText(pfe);
						if (Directory.Exists(dir))
							ofd.InitialDirectory = dir;
					}

					if (ofd.ShowDialog(this) == DialogResult.OK)
					{
						GropeLabels(ofd.FileName, featLabels, it_pathFeat);

						if (Type != Type2da.None && featLabels.Count != 0)
						{
							HenchControl.SetFeatLabelTexts();
						}

						if (dir != null)
						{
							dir = Path.GetDirectoryName(ofd.FileName);
							File.WriteAllText(pfe, dir);
						}
					}
				}
			}
			else
			{
				it_pathFeat.Checked = false;
				featLabels.Clear();

				if (Type != Type2da.None)
				{
					HenchControl.ClearFeatLabelTexts();
				}
			}
		}

		/// <summary>
		/// Gets the label-string from Classes.2da or RacialSubtypes.2da or
		/// Spells.2da or Feat.2da.
		/// </summary>
		/// <param name="pfe2da"></param>
		/// <param name="labels"></param>
		/// <param name="it"></param>
		/// <returns></returns>
		void GropeLabels(string pfe2da, ICollection<string> labels, ToolStripMenuItem it)
		{
			if (File.Exists(pfe2da))
			{
				string[] rows = File.ReadAllLines(pfe2da);

				if (!DoubleQuoteCondition(rows, this))
				{
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

								if (labels == spellLabels)
								{
									spellScripts.Add(fields[9]);
									GrabSpellFields(id, fields);
								}
							}
						}
					}

					it.Checked = (labels.Count != 0);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="fields"></param>
		void GrabSpellFields(int id, IList<string> fields)
		{
			var list = new List<string>();

			list.Add(fields[ 4]); // School
			list.Add(fields[ 5]); // Range
			list.Add(fields[ 6]); // VS
			list.Add(fields[ 7]); // MetaMagic
//			list.Add(fields[ 8]); // TargetType
			list.Add(fields[10]); // Bard
			list.Add(fields[11]); // Cleric
			list.Add(fields[12]); // Druid
			list.Add(fields[13]); // Paladin
			list.Add(fields[14]); // Ranger
			list.Add(fields[15]); // Wiz_Sorc
			list.Add(fields[16]); // Warlock
			list.Add(fields[17]); // Innate
			list.Add(fields[45]); // ImmunityType
			list.Add(fields[46]); // ItemImmunity
			list.Add(fields[47]); // SubRadSpell1
			list.Add(fields[48]); // SubRadSpell2
			list.Add(fields[49]); // SubRadSpell3
			list.Add(fields[50]); // SubRadSpell4
			list.Add(fields[51]); // SubRadSpell5
			list.Add(fields[52]); // Category
			list.Add(fields[53]); // Master
			list.Add(fields[54]); // UserType
			list.Add(fields[56]); // UsesConcentration
			list.Add(fields[57]); // SpontaneouslyCast
			list.Add(fields[58]); // SpontCastClassReq
			list.Add(fields[60]); // HostileSetting
			list.Add(fields[61]); // FeatID
			list.Add(fields[65]); // AsMetaMagic
			list.Add(fields[68]); // REMOVED

			spellTable.Add(list);
		}

//		/// <summary>
//		/// Invokes and handles the SetCoreAiVersion inputbox via the Edit.
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="e"></param>
//		/// <remarks>The version is not really the version of the CoreAI. It's
//		/// the version of the data of each entry. Apparently it can be updated
//		/// IG (after info-data has already been cached to the module-object)
//		/// such that that stale data will be bypassed in favor of the new data.
//		/// But I haven't looked into it thoroughly.</remarks>
//		void Click_setCoreAiVersion(object sender, EventArgs e)
//		{
//			switch (Type)
//			{
//				case Type2da.Spells:
//					SetInfoVersion_spells();
//
//					it_ApplyGlobal.Enabled = SpellsChanged.Count != 0;
//					it_GotoChanged.Enabled = SpellsChanged.Count != 0 || SpareChange();
//					break;
//
//				case Type2da.Racial:
//					SetInfoVersion_racial();
//
//					it_ApplyGlobal.Enabled = RacesChanged.Count != 0;
//					it_GotoChanged.Enabled = RacesChanged.Count != 0 || SpareChange();
//					break;
//
//				case Type2da.Classes:
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
		/// <remarks>This is implemented only to allow a user to pseudo-update
		/// his/her TonyAI 2.2 Hench*.2das to be compatible with 2.3+. But the
		/// repurposed bits would still need to be accounted for ....</remarks>
		void Click_clearCoreAiVersion(object sender, EventArgs e)
		{
			string info2da;
			switch (Type)
			{
				case Type2da.Spells: info2da = "SpellInfo"; break;
				default:             info2da = "Flags";     break;
			}

			string info = "This clears the bits @ 0xFF000000 on the " + info2da + " page."
						+ Environment.NewLine + Environment.NewLine
						+ "Are you sure you know what you're doing ...";

			using (var ib = new infobox(" Alert", info, "yessir", "no"))
			{
				if (ib.ShowDialog(this) == DialogResult.OK)
				{
					BypassInfoVersion = true;

					switch (Type)
					{
						case Type2da.Spells:
							SetInfoVersion_spells("0", true);

							it_ApplyGlobal.Enabled = SpellsChanged.Count != 0;
							it_GotoChanged.Enabled = SpellsChanged.Count != 0 || hasSpareChange();
							break;

						case Type2da.Racial:
							SetInfoVersion_racial("0", true);

							it_ApplyGlobal.Enabled = RacesChanged.Count != 0;
							it_GotoChanged.Enabled = RacesChanged.Count != 0 || hasSpareChange();
							break;

						case Type2da.Classes:
							SetInfoVersion_classes("0", true);

							it_ApplyGlobal.Enabled = ClassesChanged.Count != 0;
							it_GotoChanged.Enabled = ClassesChanged.Count != 0 || hasSpareChange();
							break;
					}

					BypassInfoVersion = false;
				}
			}

			HenchControl.SelectResetButton();
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
				SetTitleText();

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
				SetTitleText();

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
				SetTitleText();

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
		/// <summary>
		/// Shows the About box.
		/// </summary>
		/// <param name="sender"><c><see cref="it_About"/></c></param>
		/// <param name="e"></param>
		void Click_about(object sender, EventArgs e)
		{
			DateTime dt = Assembly.GetExecutingAssembly().GetLinkerTime();
			string info = String.Format(System.Globalization.CultureInfo.CurrentCulture,
										"{0:yyyy MMM d}  {0:HH}:{0:mm}:{0:ss} {0:zzz}",
										dt);
			// what a fucking pain in the ass!

			AssemblyName an = Assembly.GetExecutingAssembly().GetName();
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
			ver += Environment.NewLine + Environment.NewLine + info;
			using (var ib = new infobox(" About - nwn2_ai_2da_editor", ver, "yarr"))
				ib.ShowDialog(this);
		}
		#endregion Help


		#region Scripter
		/// <summary>
		/// Handles a click on the script-button.
		/// </summary>
		/// <param name="sender"><c><see cref="bu_Script"/></c></param>
		/// <param name="e"></param>
		void click_Script(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.AutoUpgradeEnabled = false; // loL fu.net

				ofd.Title  = "Select a spellscript file";
				ofd.Filter = "NwScript files (*.nss)|*.nss|All files (*.*)|*.*";

				if (Type == Type2da.Spells && Id < spellScripts.Count)
				{
					string spellscript = spellScripts[Id];
					if (spellscript != stars)
						ofd.FileName = spellscript + ".nss";
				}
				string file = ofd.FileName;

				string pfe_recentscriptsfile = Path.Combine(Application.StartupPath, RD_SCRIPS_CFG);
				if (File.Exists(pfe_recentscriptsfile))
				{
					string dir_scripts = File.ReadAllText(pfe_recentscriptsfile);
					if (Directory.Exists(dir_scripts))
						ofd.InitialDirectory = dir_scripts;
				}
				else
					pfe_recentscriptsfile = null;


				if (ofd.ShowDialog(this) == DialogResult.OK)
				{
					if (pfe_recentscriptsfile != null)
					{
						string dir_scripts = Path.GetDirectoryName(ofd.FileName);
						if (Directory.Exists(dir_scripts))
						{
							File.WriteAllText(pfe_recentscriptsfile, dir_scripts);
						}
					}

					if (Scripter == null || Scripter.IsDisposed)
						Scripter = new Scripter(Location.X + 20, Location.Y + 20);

					Scripter.SetTitleText(ofd.SafeFileName);

					Scripter.SetScriptText(File.ReadAllLines(ofd.FileName));

					if (Type == Type2da.Spells && Id < spellTable.Count
						&& file.ToLower() == ofd.SafeFileName.ToLower())
					{
						// NOTE: Do not search for a match between the chosen
						// script and the scripts in 'spellScripts' because the
						// id of the script in 'spellScripts' is not necessarily
						// the id of the spell that user wants to look at; ie,
						// spellscripts in Spells.2da can be (and are) slotted
						// in more than one spellid.
						//
						// Ergo rely only on a specific id that user has
						// selected in HenchSpells.2da. Else bail and clear the
						// fields-text.
						Scripter.SetFieldsText(spellTable[Id]);
					}
					else
						Scripter.ClearFieldsText();

					Scripter.Show();

					Scripter.TopMost = true;
					Scripter.TopMost = false;
				}
			}
		}
		#endregion Scripter


		#region Changes functs
		/// <summary>
		/// Checks if there is any altered data or unsaved structs.
		/// </summary>
		/// <returns><c>true</c> if there any dirty structs or any have yet to
		/// to be saved</returns>
		bool isChanged()
		{
			switch (Type)
			{
				case Type2da.Spells:
					foreach (var spell in Spells)
					{
						if (spell.isChanged || spell.differ != control_Spells.bit_clean)
							return true;
					}
					break;

				case Type2da.Racial:
					foreach (var race in Races)
					{
						if (race.isChanged || race.differ != control_Racial.bit_clean)
							return true;
					}
					break;

				case Type2da.Classes:
					foreach (var @class in Classes)
					{
						if (@class.isChanged || @class.differ != control_Classes.bit_clean)
							return true;
					}
					break;
			}

			return false;
		}

		/// <summary>
		/// Checks if there are any unsaved structs.
		/// </summary>
		/// <returns><c>true</c> if basic structs have yet to be saved</returns>
		bool hasSpareChange()
		{
			switch (Type)
			{
				case Type2da.Spells:
					foreach (var spell in Spells)
					{
						if (spell.isChanged)
							return true;
					}
					break;

				case Type2da.Racial:
					foreach (var race in Races)
					{
						if (race.isChanged)
							return true;
					}
					break;

				case Type2da.Classes:
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
		/// Checks if there is any altered data - data that's been modified but
		/// has yet to be applied to their structs.
		/// </summary>
		/// <returns><c>true</c> if there are dirty structs</returns>
		bool hasDirtyData()
		{
			switch (Type)
			{
				case Type2da.Spells:
					if (SpellsChanged.Count != 0)
						return true;
					break;

				case Type2da.Racial:
					if (RacesChanged.Count != 0)
						return true;
					break;

				case Type2da.Classes:
					if (ClassesChanged.Count != 0)
						return true;
					break;
			}
			return false;
		}

		/// <summary>
		/// Applies all altered data to their structs. See <see cref="Click_apply"/>
		/// to apply altered data to only the selected struct.
		/// </summary>
		void applyall()
		{
			SetTitleText(); // TitleText will be written again (properly) by Write2daFile() if saved.

			it_ApplyGlobal.Enabled = false;

			int total;

			switch (Type)
			{
				case Type2da.Spells:
				{
					Spell spell;

					total = Spells.Count;
					for (int id = 0; id != total; ++id)
					{
						spell = Spells[id];

						if (spell.differ != control_Spells.bit_clean)
						{
							spell.differ = control_Spells.bit_clean;
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
								HenchControl.SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current spell jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}

				case Type2da.Racial:
				{
					Race race;

					total = Races.Count;
					for (int id = 0; id != total; ++id)
					{
						race = Races[id];

						if (race.differ != control_Racial.bit_clean)
						{
							race.differ = control_Racial.bit_clean;
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
								HenchControl.SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current race jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}

				case Type2da.Classes:
				{
					Class @class;

					total = Classes.Count;
					for (int id = 0; id != total; ++id)
					{
						@class = Classes[id];

						if (@class.differ != control_Classes.bit_clean)
						{
							@class.differ = control_Classes.bit_clean;
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
								HenchControl.SetResetColor(DefaultForeColor);
								AfterSelect_node(null, null); // refresh all displayed data for the current class jic
							}

							Tree.Nodes[id].ForeColor = Color.Blue;
						}
					}
					break;
				}
			}
		}
		#endregion Changes functs


		#region Write file
		/// <summary>
		/// Writes all Applied data to 2da-file.
		/// </summary>
		void Write2daFile()
		{
			SetTitleText(true);

			it_GotoChanged.Enabled = false;

			switch (Type)
			{
				case Type2da.Spells:  Output2da.WriteHenchSpells( _pfe, Spells,  Tree.Nodes); break;
				case Type2da.Racial:  Output2da.WriteHenchRacial( _pfe, Races,   Tree.Nodes); break;
				case Type2da.Classes: Output2da.WriteHenchClasses(_pfe, Classes, Tree.Nodes); break;
			}
		}
		#endregion Write file
	}
}
