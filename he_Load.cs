using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Functions called when loading a 2da-file.
	partial class he
	{
		#region Methods (static)
		/// <summary>
		/// Checks 2da rows for double-quote <c>chars</c> and displays an error
		/// if any are found.
		/// </summary>
		/// <param name="rows">an array of 2da rows</param>
		/// <param name="he">parent for the <c><see cref="infobox"/></c></param>
		/// <returns><c>true</c> if a double-quote char is found</returns>
		/// <remarks>WARNING: This editor does *not* handle quotation marks
		/// around 2da fields.</remarks>
		static bool hasDoubleQuote(string[] rows, IWin32Window he)
		{
			foreach (string row in rows)
			{
				foreach (char character in row)
				{
					if (character == '"')
					{
						const string info = "The 2da-file contains double-quotes. Although that can be"
										  + " valid in a 2da-file this editor is not coded to cope."
										  + " Format the 2da-file to not use double-quotes if you want"
										  + " to open it here.";

						using (var ib = new infobox(" Error", info, "drat"))
							ib.ShowDialog(he);

						return true;
					}
				}
			}
			return false;
		}
		#endregion Methods (static)


		#region Methods
		/// <summary>
		/// Determines which file to load:
		/// <list type="bullet">
		/// <item>HenchSpells</item>
		/// <item>HenchRacial</item>
		/// <item>HenchClasses</item>
		/// </list>
		/// </summary>
		/// <remarks>The fullpath of the file must already be stored in
		/// <c><see cref="_pfe"/></c>.
		/// 
		/// 
		/// <c>pfe</c> stands for path_file_extension.</remarks>
		void Load_file()
		{
			if (File.Exists(_pfe)) // safety.
			{
				// deal with recent-files first
				// Recents won't be written to disk unless a file "recent.cfg"
				// already exists in the appdir.
				recent_add();

				// read and load the 2da second
				string[] rows = File.ReadAllLines(_pfe);

				if (!hasDoubleQuote(rows, this))
				{
					SuspendLayout();

					BypassDiffer = true;

					bool error = true;

					for (int i = 0; i != rows.Length; ++i)
						rows[i] = rows[i].Trim();

					// resolve what 2da is being loaded ->
					//
					// HenchSpells.2da colheads
					// Label SpellInfo TargetInfo EffectWeight EffectTypes DamageInfo SaveType SaveDCType
					//
					// HenchRacial.2da colheads
					// Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5
					//
					// HenchClasses.2da colheads
					// Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5 FeatSpell6 FeatSpell7 FeatSpell8 FeatSpell9 FeatSpell10 FeatSpell11

					string[] fields = rows[2].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

					if (fields.Length > 5)
					{
						if (fields[0].ToLowerInvariant() != "label")
						{
							switch (fields.Length)
							{
								case 7: // henchspells w/out "Label" col
									if (   fields[0].ToLowerInvariant() == "spellinfo"
										&& fields[1].ToLowerInvariant() == "targetinfo"
										&& fields[2].ToLowerInvariant() == "effectweight"
										&& fields[3].ToLowerInvariant() == "effecttypes"
										&& fields[4].ToLowerInvariant() == "damageinfo"
										&& fields[5].ToLowerInvariant() == "savetype"
										&& fields[6].ToLowerInvariant() == "savedctype")
									{
										hasLabels = false;
										Load_HenchSpells(rows);
										error = false;
									}
									break;

								case 6: // henchracial w/out "Label" col
									if (   fields[0].ToLowerInvariant() == "flags"
										&& fields[1].ToLowerInvariant() == "featspell1"
										&& fields[2].ToLowerInvariant() == "featspell2"
										&& fields[3].ToLowerInvariant() == "featspell3"
										&& fields[4].ToLowerInvariant() == "featspell4"
										&& fields[5].ToLowerInvariant() == "featspell5")
									{
										hasLabels = false;
										Load_HenchRacial(rows);
										error = false;
									}
									break;

								case 12: // henchclasses w/out "Label" col
									if (   fields[ 0].ToLowerInvariant() == "flags"
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
										error = false;
									}
									break;
							}
						}
						else // fields[0] == "label"
						{
							switch (fields.Length)
							{
								case 7: // henchracial w/ "Label" col
									if (   fields[1].ToLowerInvariant() == "flags"
										&& fields[2].ToLowerInvariant() == "featspell1"
										&& fields[3].ToLowerInvariant() == "featspell2"
										&& fields[4].ToLowerInvariant() == "featspell3"
										&& fields[5].ToLowerInvariant() == "featspell4"
										&& fields[6].ToLowerInvariant() == "featspell5")
									{
										hasLabels = true;
										Load_HenchRacial(rows);
										error = false;
									}
									break;

								case 8: // henchspells w/ "Label" col
									if (   fields[1].ToLowerInvariant() == "spellinfo"
										&& fields[2].ToLowerInvariant() == "targetinfo"
										&& fields[3].ToLowerInvariant() == "effectweight"
										&& fields[4].ToLowerInvariant() == "effecttypes"
										&& fields[5].ToLowerInvariant() == "damageinfo"
										&& fields[6].ToLowerInvariant() == "savetype"
										&& fields[7].ToLowerInvariant() == "savedctype")
									{
										hasLabels = true;
										Load_HenchSpells(rows);
										error = false;
									}
									break;

								case 13: // henchclasses w/ "Label" col
									if (   fields[ 1].ToLowerInvariant() == "flags"
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
										error = false;
									}
									break;
							}
						}
					}

					if (!error) // TODO: That should be predicated on Load_Hench*() not throwing an exception.
					{
						SetTitleText(true);

						Tree.SelectedNode = Tree.Nodes[0]; // that should be done auto but doesn't always happen.

//						if (InfoVersionUpdate) // no InfoVersion in TonyAI 2.3+
//						{
//							InfoVersionUpdate = false;
//							MessageBox.Show("InfoVersion(s) have been updated.",
//											"  InfoVersion update",
//											MessageBoxButtons.OK,
//											MessageBoxIcon.Information,
//											MessageBoxDefaultButton.Button1);
//						}

						BypassDiffer = false;

						// if (HenchSpells.2da) clear bits for
						// - Concentration
						// - SpellLevel
						// because TonyAI 2.3+ sets those auto.
						if (!error && Type == Type2da.Spells)
						{
							UpdateSpellInfo(); // that needs to be done after 'BypassDiffer' ...
						}
					}
					else
					{
						ResumeLayout();

						const string info = "That file does not appear to be HenchSpells, HenchRacial, or HenchClasses.2da";
						using (var ib = new infobox(" Error", info, "err"))
							ib.ShowDialog(this);

						BypassDiffer = false;
					}
				}
			}
		}

		/// <summary>
		/// Clears all <c>Lists</c> and <c>Dictionaries</c>.
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
		/// </summary>
		/// <param name="rows"></param>
		/// <remarks>If the file is not a valid HenchSpells.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.</remarks>
		void Load_HenchSpells(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new control_Spells(this);
			panel2width  = HenchControl.Width;  // cache that
			panel2height = HenchControl.Height; // cache that
			splitContainer.Panel2.Controls.Add(HenchControl);

			Type = Type2da.Spells;

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
						spell.differ    = control_Spells.bit_clean;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != stars)
							spell.label = field;
						else
							spell.label = String.Empty;

						if ((field = fields[++col]) != stars)
							spell.spellinfo = Int32.Parse(field);
						else
							spell.spellinfo = 0;

						if ((field = fields[++col]) != stars)
							spell.targetinfo = Int32.Parse(field);
						else
							spell.targetinfo = 0;

						if ((field = fields[++col]) != stars)
							spell.effectweight = Single.Parse(field);
						else
							spell.effectweight = 0.0f;

						if ((field = fields[++col]) != stars)
							spell.effecttypes = Int32.Parse(field);
						else
							spell.effecttypes = 0;

						if ((field = fields[++col]) != stars)
							spell.damageinfo = Int32.Parse(field);
						else
							spell.damageinfo = 0;

						if ((field = fields[++col]) != stars)
							spell.savetype = Int32.Parse(field);
						else
							spell.savetype = 0;

						if ((field = fields[++col]) != stars)
							spell.savedctype = Int32.Parse(field);
						else
							spell.savedctype = 0;

						Spells.Add(spell);	// spell-structs can now be referenced in the 'Spells' list by their
					}						// - Spells[id]
				}							// - HenchSpells.2da row#
			}								// - SpellID (Spells.2da row#)

			GrowTree(true);

			// check if any info-version(s) need to be updated in spellinfo-int.
//			InfoVersionLoad_spells();

			bu_Apply      .Text = "apply this spell\'s data";
			tree_Highlight.Text = "highlight blank SpellInfo nodes";
		}

		/// <summary>
		/// The TonyAI 2.3+ sets bits of data by reading it directly from
		/// Spells.2da - such data is no longer stored in HenchSpells.2da. This
		/// funct clears those bits auto right after HenchSpells.2da loads.
		/// </summary>
		/// <remarks>The controls are disabled on the tabpage.
		/// 
		///
		/// Is based on
		/// <c><see cref="SetInfoVersion_spells()">SetInfoVersion_spells()</see></c>.
		/// This funct, however, ASSUMES that nothing in the spell-list has
		/// changed yet; this funct bypasses a bunch of differ-stuff that
		/// <c>SetInfoVersion_spells()</c> doesn't.</remarks>
		void UpdateSpellInfo()
		{
			Spell spell;
			SpellChanged spellchanged;

			int spellinfo0, spellinfo;

			int total = Spells.Count;
			for (int id = 0; id != total; ++id)
			{
				spell = Spells[id];

				spellinfo0 = spell.spellinfo;

				spellinfo = spellinfo0 & ~(hc.HENCH_SPELL_INFO_CONCENTRATION_FLAG
										 | hc.HENCH_SPELL_INFO_SPELL_LEVEL_MASK);

				if (spellinfo != spellinfo0)
				{
					if (id == Id)
					{
						HenchControl.SetMasterText(spellinfo.ToString()); // firing the TextChanged event takes care of it.
					}
					else
					{
						spellchanged = new SpellChanged();

						spellchanged.targetinfo   = spell.targetinfo;
						spellchanged.effectweight = spell.effectweight;
						spellchanged.effecttypes  = spell.effecttypes;
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;

						spellchanged.spellinfo = spellinfo;
						SpellsChanged[id] = spellchanged;

						// check it
						spell.differ = control_Spells.SpellDiffer(spell, spellchanged);
						Spells[id] = spell;

						Tree.Nodes[id].ForeColor = Color.Crimson;
					}
				}
			}
		}

/*		/// <summary>
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
		/// </summary>
		/// <param name="rows"></param>
		/// <remarks>If the file is not a valid HenchRacial.2da then this should
		/// hopefully throw an exception at the user. If it doesn't all bets are
		/// off.</remarks>
		void Load_HenchRacial(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new control_Racial(this);
			panel2width  = HenchControl.Width;  // cache that
			panel2height = HenchControl.Height; // cache that
			splitContainer.Panel2.Controls.Add(HenchControl);

			Type = Type2da.Racial;

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
						race.differ    = control_Racial.bit_clean;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != stars)
							race.label = field;
						else
							race.label = String.Empty;

						if ((field = fields[++col]) != stars)
							race.flags = Int32.Parse(field);
						else
							race.flags = 0;

						if ((field = fields[++col]) != stars)
							race.feat1 = Int32.Parse(field);
						else
							race.feat1 = 0;

						if ((field = fields[++col]) != stars)
							race.feat2 = Int32.Parse(field);
						else
							race.feat2 = 0;

						if ((field = fields[++col]) != stars)
							race.feat3 = Int32.Parse(field);
						else
							race.feat3 = 0;

						if ((field = fields[++col]) != stars)
							race.feat4 = Int32.Parse(field);
						else
							race.feat4 = 0;

						if ((field = fields[++col]) != stars)
							race.feat5 = Int32.Parse(field);
						else
							race.feat5 = 0;

						Races.Add(race);	// race-structs can now be referenced in the 'Races' list by their
					}						// - Races[id]
				}							// - HenchRacial.2da row#
			}								// - SubRaceID (RacialSubtypes.2da row#)

			GrowTree(true);

			// check if any info-version(s) need to be updated in flags-int.
//			InfoVersionLoad_racial();

			bu_Apply      .Text = "apply this race\'s data";
			tree_Highlight.Text = "highlight blank Racial flags nodes";
		}

/*		/// <summary>
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
		/// </summary>
		/// <param name="rows"></param>
		/// <remarks>If the file is not a valid HenchClasses.2da then this
		/// should hopefully throw an exception at the user. If it doesn't all
		/// bets are off.</remarks>
		void Load_HenchClasses(string[] rows)
		{
			if (HenchControl != null)
				HenchControl.Dispose(); // <- also removes the control from its collection

			HenchControl = new control_Classes(this);
			panel2width  = HenchControl.Width;  // cache that
			panel2height = HenchControl.Height; // cache that
			splitContainer.Panel2.Controls.Add(HenchControl);

			Type = Type2da.Classes;

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
						@class.differ    = control_Classes.bit_clean;

						int col = 0;

						if (hasLabels && (field = fields[++col]) != stars)
							@class.label = field;
						else
							@class.label = String.Empty;

						if ((field = fields[++col]) != stars)
							@class.flags = Int32.Parse(field);
						else
							@class.flags = 0;

						if ((field = fields[++col]) != stars)
							@class.feat1 = Int32.Parse(field);
						else
							@class.feat1 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat2 = Int32.Parse(field);
						else
							@class.feat2 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat3 = Int32.Parse(field);
						else
							@class.feat3 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat4 = Int32.Parse(field);
						else
							@class.feat4 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat5 = Int32.Parse(field);
						else
							@class.feat5 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat6 = Int32.Parse(field);
						else
							@class.feat6 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat7 = Int32.Parse(field);
						else
							@class.feat7 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat8 = Int32.Parse(field);
						else
							@class.feat8 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat9 = Int32.Parse(field);
						else
							@class.feat9 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat10 = Int32.Parse(field);
						else
							@class.feat10 = 0;

						if ((field = fields[++col]) != stars)
							@class.feat11 = Int32.Parse(field);
						else
							@class.feat11 = 0;

						Classes.Add(@class);	// class-structs can now be referenced in the 'Classes' list by their
					}							// - Classes[id]
				}								// - HenchClasses.2da row#
			}									// - ClassID (Classes.2da row#)

			GrowTree(true);

			// check if any info-version(s) need to be updated in flags-int.
//			InfoVersionLoad_classes();

			bu_Apply      .Text = "apply this class\' data";
			tree_Highlight.Text = "highlight blank Class flags nodes";
		}

/*		/// <summary>
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
		/// Populates nodes in the <c><see cref="Tree"/></c>.
		/// </summary>
		/// <param name="init"><c>true</c> when loading a 2da-file -
		/// <c>false</c> when inserting spell/race/class labels</param>
		void GrowTree(bool init = false)
		{
			if (init)
			{
				EnableMenu();
				EnableCopy(true);

				tree_Highlight.Checked = false;
			}


			Tree.BeginUpdate();

			Tree.Nodes.Clear();


			TreeNode node;
			string text;

			switch (Type)
			{
				case Type2da.Spells:
				{
					var pb = new ProgBar(); // populating the spells-tree takes a second or 3.
					pb.Stop = Spells.Count;
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

				case Type2da.Racial:
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

				case Type2da.Classes:
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


			text = String.Empty; // set Tree width ->
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
			splitContainer.SplitterDistance = width;


			Tree.EndUpdate();

			int height; // set ClientSize ->
			width  = splitContainer.Panel1.Width + splitContainer.SplitterWidth + panel2width + 1;
			height = Math.Max(userHeight, menubar.Height + bu_Apply.Height + panel2height);
			ClientSize = new Size(width, height);

			ResumeLayout();
		}

		/// <summary>
		/// Enables several menu-items.
		/// </summary>
		/// <remarks>Calls to this need to be adjusted if a Close 2da function
		/// is added - and perhaps if a 2da fails to load leaving a blank tree.</remarks>
		void EnableMenu()
		{
			it_Save       .Enabled = // file ->
			it_Saveas     .Enabled =

			it_Copy_dec   .Enabled = // edit ->
			it_Copy_hex   .Enabled =
			it_Copy_bin   .Enabled =
			it_ClearCoreAI.Enabled = true;

			tree_Highlight.Visible = true;
		}
		#endregion Methods
	}
}
