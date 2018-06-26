using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Event handlers for menu-items.
	/// </summary>
	partial class MainForm
	{
		#region File
		/// <summary>
		/// Handles FileMenu close program event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_quit(object sender, EventArgs e)
		{
			bool warn = false;

			foreach (var spell in Spells)
			{
				if (spell.isChanged || spell.differ != bit_clear)
				{
					warn = true;
					break;
				}
			}

			if (!warn || MessageBox.Show("Data has changed." + Environment.NewLine + "Okay to exit ...",
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
			using (var ofd = new OpenFileDialog())
			{
				ofd.Title  = "Select a HenchSpells.2da";
				ofd.Filter = "2da files (*.2da)|*.2da|All files (*.*)|*.*";

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					_pfe = ofd.FileName;
					Load_file();
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
			if (DirtyDataApplied())
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
				string info = "There is spell-data that has been modified but not applied."
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
		void Click_findnextchanged(object sender, EventArgs e)
		{
			int totalnodes = Tree.Nodes.Count;
			if (totalnodes > 1)
			{
				int id;
				if (Id == totalnodes - 1)
				{
					id = 0;
				}
				else
					id = Id + 1;

				while (!Spells[id].isChanged && Spells[id].differ == bit_clear)
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

				Tree.SelectedNode = Tree.Nodes[id];
			}
		}


		void Click_copy_decimal(object sender, EventArgs e)
		{
//			if (cols_HenchSpells.SelectedTab == cols_HenchSpells.TabPages["page_SpellInfo"])

			string val = String.Empty;
			int i;
			float f;

			switch (cols_HenchSpells.SelectedIndex)
			{
				case 0:
					val = SpellInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 1:
					val = TargetInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 2:
					val = EffectWeight_text.Text;
					if (!float.TryParse(val, out f))
						val = String.Empty;
					break;
				case 3:
					val = EffectTypes_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 4:
					val = DamageInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 5:
					val = SaveType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 6:
					val = SaveDCType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
			}

			if (!String.IsNullOrEmpty(val))
			{
				Clipboard.SetText(val);
			}
			else
				Clipboard.Clear();
		}

		void Click_copy_hexadecimal(object sender, EventArgs e)
		{
			string val = String.Empty;
			int i = 0;

			switch (cols_HenchSpells.SelectedIndex)
			{
				case 0:
					val = SpellInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 1:
					val = TargetInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
//				case 2: // invalid
//					val = EffectWeight_text.Text;
//					if (!float.TryParse(val, out f))
//						val = String.Empty;
//					break;
				case 3:
					val = EffectTypes_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 4:
					val = DamageInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 5:
					val = SaveType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 6:
					val = SaveDCType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
			}

			if (!String.IsNullOrEmpty(val))
			{
				val = i.ToString("x8");
				val = val.Insert(0, "0x");
				Clipboard.SetText(val);
			}
			else
				Clipboard.Clear();
		}

		void Click_copy_binary(object sender, EventArgs e)
		{
			string val = String.Empty;
			int i = 0;

			switch (cols_HenchSpells.SelectedIndex)
			{
				case 0:
					val = SpellInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 1:
					val = TargetInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
//				case 2: // invalid
//					val = EffectWeight_text.Text;
//					if (!float.TryParse(val, out f))
//						val = String.Empty;
//					break;
				case 3:
					val = EffectTypes_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 4:
					val = DamageInfo_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 5:
					val = SaveType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
				case 6:
					val = SaveDCType_text.Text;
					if (!Int32.TryParse(val, out i))
						val = String.Empty;
					break;
			}

			if (!String.IsNullOrEmpty(val))
			{
				val = Convert.ToString(i, 2).PadLeft(32, '0');
				Clipboard.SetText(val);
			}
			else
				Clipboard.Clear();
		}
		#endregion Edit


		#region Options
		const int HENCH_SPELL_INFO_VERSION_SHIFT = 24;

		/// <summary>
		/// Invokes and handles the SetCoreAiVersion inputbox via the Options.
		/// NOTE: The version is not really the version of the CoreAI. It's the
		/// version of the data of each spell. Apparently it can be updated IG
		/// (after spell-data has already been cached to the module-object) such
		/// that that stale data will be bypassed in favor of the new data. But
		/// I haven't looked into it thoroughly.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_setCoreAiVersion(object sender, EventArgs e)
		{
			int spellinfo;
			if (SpellsChanged.ContainsKey(Id))
			{
				spellinfo = SpellsChanged[Id].spellinfo;
			}
			else
				spellinfo = Spells[Id].spellinfo;

			int ver = (spellinfo & HENCH_SPELL_INFO_VERSION_MASK) >> HENCH_SPELL_INFO_VERSION_SHIFT;

			//logfile.Log("input= " + ver);

			string input = ver.ToString();
			switch (ShowInputDialog("  SpellInfo version",
									ref input,
									"current spell only",
									"all spells in 2da",
									"Do NOT change this."))
			{
				case DialogResult.OK: // change the current spell's version only
					//logfile.Log("Ok result= " + input);

					if (spellinfo != 0 // don't bother setting version if the SpellInfo field is blank.
						&& Int32.TryParse(input, out ver))
					{
						spellinfo &= ~HENCH_SPELL_INFO_VERSION_MASK;
						spellinfo |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

						SpellInfo_text.Text = spellinfo.ToString();
					}
					break;

				case DialogResult.Retry: // change the version of all spells currently loaded
					//logfile.Log("Retry result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256) // version is held in only 8 bits of spellinfo (do not allow 0).
					{
//						foreach (var spell in spells) // <- the iterator in foreach() is readonly. So can't change the differ ...

						//logfile.Log(". ver= " + ver);

						bool changed;

						SpellChanged spellchanged;
						Spell spell;

						int spellinfo0;

						int totalspells = Spells.Count;
						for (int id = 0; id != totalspells; ++id)
						{
							if (changed = SpellsChanged.ContainsKey(id))
							{
								spellinfo0 = SpellsChanged[id].spellinfo;
							}
							else
								spellinfo0 = Spells[id].spellinfo;

							if (spellinfo0 != 0) // don't bother setting version if the SpellInfo field is blank.
							{
								spellinfo = (spellinfo0 & ~HENCH_SPELL_INFO_VERSION_MASK);
								spellinfo |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

								if (spellinfo != spellinfo0)
								{
									if (id == Id)
									{
										SpellInfo_text.Text = spellinfo.ToString();
									}
									else
									{
										spell = Spells[id];

										if (changed)
										{
											spellchanged = SpellsChanged[id];
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
										}

										spellchanged.spellinfo = spellinfo;

										// check it
										int differ = SpellDiffer(spell, spellchanged);
										spell.differ = differ;
										Spells[id] = spell;

										//logfile.Log(". differ= " + differ);

										if (differ != bit_clear)
										{
											SpellsChanged[id] = spellchanged;
											Tree.Nodes[id].ForeColor = Color.Crimson;
										}
										else
										{
											SpellsChanged.Remove(id);

											if (!spell.isChanged) // this is set by the Apply btn only.
											{
												Tree.Nodes[id].ForeColor = DefaultForeColor;
											}
										}
									}
								}
							}
						}
					}
					//else logfile.Log(". invalid");
					break;

				case DialogResult.Cancel: // do a jig.
					//logfile.Log("cancelled");
					break;
			}
		}
		#endregion Options


		#region Help
		void Click_about(object sender, EventArgs e)
		{
/*			DateTime dt = DateTime.Now;
			DateTime dt = Assembly.GetExecutingAssembly().GetLinkerTime();
			string info = "build date" + Environment.NewLine + Environment.NewLine
						+ String.Format(System.Globalization.CultureInfo.CurrentCulture,
										"{0:yyyy MMM d}  {0:HH}:{0:mm}:{0:ss} {0:zzz}",
										dt);
*/
			// what a fucking pain in the ass.
			const string info = "built - 2018 jun 24";

			MessageBox.Show(info,
							"  About",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information,
							MessageBoxDefaultButton.Button1);
		}
		#endregion Help


		/// <summary>
		/// Checks if all modified spell-data has been Applied with the Apply-btn.
		/// </summary>
		/// <returns></returns>
		bool DirtyDataApplied()
		{
			foreach (var spell in Spells)
			{
				if (spell.differ != 0)
					return false;
			}
			return true;
		}

		/// <summary>
		/// Applies modified data to any Spell that has changed.
		/// NOTE: This should be called only before saving to file. That is it
		/// clears things that should otherwise be left intact.
		/// Cf. Click_apply()
		/// </summary>
		void ApplyDirtyData()
		{
			int spellstotal = Spells.Count;
			for (int id = 0; id != spellstotal; ++id)
			{
				if (SpellsChanged.ContainsKey(id))
				{
					var spellchanged = SpellsChanged[id];

					Spell spell = Spells[id];

					spell.isChanged = true; // this flag causes Write2daFile() to reset the node-color
					spell.differ = bit_clear;

					spell.spellinfo    = spellchanged.spellinfo;
					spell.targetinfo   = spellchanged.targetinfo;
					spell.effectweight = spellchanged.effectweight;
					spell.effecttypes  = spellchanged.effecttypes;
					spell.damageinfo   = spellchanged.damageinfo;
					spell.savetype     = spellchanged.savetype;
					spell.savedctype   = spellchanged.savedctype;

					// NOTE: keep 'savedctypetype' intact. It's basically a user-setting. // TODO: Obsolete that.

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
				}
			}
		}


		/// <summary>
		/// Writes all Applied data to HenchSpells.2da file.
		/// </summary>
		void Write2daFile()
		{
			//logfile.Log("Write2daFile() " + _pfe);

			Text = "nwn2_ai_2da_editor - " + _pfe; // titlebar text (append path of saved file)

			Spell spellclear;

			int spellstotal = Spells.Count; // clear any isChanged flags
			for (int id = 0; id != spellstotal; ++id)
			{
				spellclear = Spells[id];
				if (spellclear.isChanged)
				{
					spellclear.isChanged = false;
					Spells[id] = spellclear;

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

					if (!CheckFloats(spell.effectweight, 0.0f))
					{
						line += FormatFloat(spell.effectweight.ToString());
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
	}



/*	public static class DateTimeExtension
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
	} */
}
