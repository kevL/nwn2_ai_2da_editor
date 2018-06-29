using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// An inputbox with which to set CoreAI version information.
	/// </summary>
	partial class MainForm
	{
		static DialogResult InfoVersion(Type2da type,
										ref string input)
		{
			string title;
			string text_1;
			string text_2;
			string text_3;

			switch (type)
			{
				default:
//				case Type2da.TYPE_SPELLS:
					title = "  Spell Info version";
					text_1 = "current spell only";
					text_2 = "any changed spells";
					text_3 = "all spells in 2da";
					break;

				case Type2da.TYPE_RACIAL:
					title = "  Racial Info version";
					text_1 = "current race only";
					text_2 = "any changed race";
					text_3 = "all races in 2da";
					break;

				case Type2da.TYPE_CLASSES:
					title = "  Class Info version";
					text_1 = "current class only";
					text_2 = "any changed class";
					text_3 = "all classes in 2da";
					break;
			}


			var ib = new Form();

			var size = new Size(350, 125);

			ib.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			ib.StartPosition = FormStartPosition.CenterParent;
			ib.ClientSize = size;
			ib.Text = title;
			ib.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);


			const int pad  = 5;

			var infoText = new Label();
			infoText.Size = new Size(size.Width - pad * 2, 20);
			infoText.Location = new Point(pad, pad + 2);
			infoText.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			infoText.ForeColor = Color.Crimson;
			infoText.TextAlign = ContentAlignment.TopCenter;
			infoText.Text = "Do NOT change this.";
			ib.Controls.Add(infoText);

			var textBox = new TextBox();
			textBox.Size = new Size(size.Width - pad * 10, 20);
			textBox.Location = new Point(pad * 5, 30);
			textBox.Text = input;
			ib.Controls.Add(textBox);

			const int wBtn = 80;
			const int hBtn = 55;
			int yBtn = size.Height - hBtn - pad;


			var cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(wBtn, hBtn);
			cancelButton.Text = "&Cancel";
			cancelButton.Location = new Point((size.Width - pad) * 4 / 4 - wBtn, yBtn);
			ib.Controls.Add(cancelButton);

			var okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Size = new Size(wBtn, hBtn);
			okButton.Text = text_1;
			okButton.Location = new Point((size.Width - pad) * 3 / 4 - wBtn, yBtn);
			ib.Controls.Add(okButton);

			var anyButton = new Button();
			anyButton.DialogResult = DialogResult.Yes;
			anyButton.Name = "anyButton";
			anyButton.Size = new Size(wBtn, hBtn);
			anyButton.Text = text_2;
			anyButton.Location = new Point((size.Width - pad) * 2 / 4 - wBtn, yBtn);
			ib.Controls.Add(anyButton);

			var allButton = new Button();
			allButton.DialogResult = DialogResult.Retry;
			allButton.Name = "allButton";
			allButton.Size = new Size(wBtn, hBtn);
			allButton.Text = text_3;
			allButton.Location = new Point((size.Width - pad) * 1 / 4 - wBtn, yBtn);
			ib.Controls.Add(allButton);


			ib.AcceptButton = okButton;		// [Enter]
			ib.CancelButton = cancelButton;	// [Esc]

			DialogResult result = ib.ShowDialog();
			input = textBox.Text;
			return result;
		}


		const int HENCH_SPELL_INFO_VERSION_SHIFT = 24;

		/// <summary>
		/// Sets the InfoVersion of spell IDs.
		/// </summary>
		void SetInfoVersion_spells()
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
			switch (InfoVersion(Type2da.TYPE_SPELLS, ref input))				// prompt user w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current spell's version only
					//logfile.Log("Ok (current spell) result= " + input);

					if (spellinfo != 0											// don't bother setting version if the SpellInfo field is blank.
						&& Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of spellinfo (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						spellinfo &= ~HENCH_SPELL_INFO_VERSION_MASK;
						spellinfo |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

						SpellInfo_text.Text = spellinfo.ToString();
					}
					//else logfile.Log(". invalid");
					break;

				case DialogResult.Yes:											// change the version of any currently changed spell
					//logfile.Log("Yes (any spell) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of spellinfo (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						SpellChanged spellchanged;
						Spell spell;

						int spellinfo0;

						int total = Spells.Count;
						for (int id = 0; id != total; ++id)
						{
							spell = Spells[id];

							if (dirty = SpellsChanged.ContainsKey(id))
							{
								spellinfo0 = SpellsChanged[id].spellinfo;
							}
							else if (spell.isChanged)
							{
								spellinfo0 = spell.spellinfo;
							}
							else
								continue;

							if (spellinfo0 != 0)								// don't bother setting version if the SpellInfo field is blank.
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
										if (dirty)
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

				case DialogResult.Retry:										// change the version of all spells currently loaded
					//logfile.Log("Retry (all spells) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of spellinfo (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						SpellChanged spellchanged;
						Spell spell;

						int spellinfo0;

						int total = Spells.Count;
						for (int id = 0; id != total; ++id)
						{
							if (dirty = SpellsChanged.ContainsKey(id))
							{
								spellinfo0 = SpellsChanged[id].spellinfo;
							}
							else
								spellinfo0 = Spells[id].spellinfo;

							if (spellinfo0 != 0)								// don't bother setting version if the SpellInfo field is blank.
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

										if (dirty)
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

		/// <summary>
		/// Sets the InfoVersion of race IDs.
		/// </summary>
		void SetInfoVersion_racial()
		{
			int racialflags;
			if (RacesChanged.ContainsKey(Id))
			{
				racialflags = RacesChanged[Id].flags;
			}
			else
				racialflags = Races[Id].flags;

			int ver = (racialflags & HENCH_SPELL_INFO_VERSION_MASK) >> HENCH_SPELL_INFO_VERSION_SHIFT;

			//logfile.Log("input= " + ver);

			string input = ver.ToString();
			switch (InfoVersion(Type2da.TYPE_RACIAL, ref input))				// prompt user w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current race's version only
					//logfile.Log("Ok (current race) result= " + input);

					if (Int32.TryParse(input, out ver)							// set the version even if the RacialFlags field is blank.
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of racialflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						racialflags &= ~HENCH_SPELL_INFO_VERSION_MASK;
						racialflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

						RacialFlags_text.Text = racialflags.ToString();
					}
					//else logfile.Log(". invalid");
					break;

				case DialogResult.Yes:											// change the version of any currently changed race
					//logfile.Log("Yes (any race) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of racialflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						RaceChanged racechanged;
						Race race;

						int racialflags0;

						int total = Races.Count;
						for (int id = 0; id != total; ++id)
						{
							race = Races[id];

							if (dirty = RacesChanged.ContainsKey(id))
							{
								racialflags0 = RacesChanged[id].flags;
							}
							else if (race.isChanged)
							{
								racialflags0 = race.flags;
							}
							else
								continue;

//							if (racialflags0 != 0)								// set the version even if the RacialFlags field is blank.
							{
								racialflags = (racialflags0 & ~HENCH_SPELL_INFO_VERSION_MASK);
								racialflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

								if (racialflags != racialflags0)
								{
									if (id == Id)
									{
										RacialFlags_text.Text = racialflags.ToString();
									}
									else
									{
										if (dirty)
										{
											racechanged = RacesChanged[id];
										}
										else
										{
											racechanged = new RaceChanged();

											racechanged.feat1 = race.feat1;
											racechanged.feat2 = race.feat2;
											racechanged.feat3 = race.feat3;
											racechanged.feat4 = race.feat4;
											racechanged.feat5 = race.feat5;
										}

										racechanged.flags = racialflags;

										// check it
										int differ = RaceDiffer(race, racechanged);
										race.differ = differ;
										Races[id] = race;

										if (differ != bit_clear)
										{
											RacesChanged[id] = racechanged;
											Tree.Nodes[id].ForeColor = Color.Crimson;
										}
										else
										{
											RacesChanged.Remove(id);

											if (!race.isChanged) // this is set by the Apply btn only.
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

				case DialogResult.Retry:										// change the version of all races currently loaded
					//logfile.Log("Retry (all races) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of racialflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						RaceChanged racechanged;
						Race race;

						int racialflags0;

						int total = Races.Count;
						for (int id = 0; id != total; ++id)
						{
							if (dirty = RacesChanged.ContainsKey(id))
							{
								racialflags0 = RacesChanged[id].flags;
							}
							else
								racialflags0 = Races[id].flags;

//							if (racialflags0 != 0)								// set the version even if the RacialFlags field is blank.
							{
								racialflags = (racialflags0 & ~HENCH_SPELL_INFO_VERSION_MASK);
								racialflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

								if (racialflags != racialflags0)
								{
									if (id == Id)
									{
										RacialFlags_text.Text = racialflags.ToString();
									}
									else
									{
										race = Races[id];

										if (dirty)
										{
											racechanged = RacesChanged[id];
										}
										else
										{
											racechanged = new RaceChanged();

											racechanged.feat1 = race.feat1;
											racechanged.feat2 = race.feat2;
											racechanged.feat3 = race.feat3;
											racechanged.feat4 = race.feat4;
											racechanged.feat5 = race.feat5;
										}

										racechanged.flags = racialflags;

										// check it
										int differ = RaceDiffer(race, racechanged);
										race.differ = differ;
										Races[id] = race;

										if (differ != bit_clear)
										{
											RacesChanged[id] = racechanged;
											Tree.Nodes[id].ForeColor = Color.Crimson;
										}
										else
										{
											RacesChanged.Remove(id);

											if (!race.isChanged) // this is set by the Apply btn only.
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

		/// <summary>
		/// Sets the InfoVersion of class IDs.
		/// </summary>
		void SetInfoVersion_classes()
		{
			int clasflags;
			if (ClassesChanged.ContainsKey(Id))
			{
				clasflags = ClassesChanged[Id].flags;
			}
			else
				clasflags = Classes[Id].flags;

			int ver = (clasflags & HENCH_SPELL_INFO_VERSION_MASK) >> HENCH_SPELL_INFO_VERSION_SHIFT;

			//logfile.Log("input= " + ver);

			string input = ver.ToString();
			switch (InfoVersion(Type2da.TYPE_CLASSES, ref input))				// prompt user w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current class' version only
					//logfile.Log("Ok (current class) result= " + input);

					if (Int32.TryParse(input, out ver)							// set the version even if the ClassFlags field is blank.
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of clasflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						clasflags &= ~HENCH_SPELL_INFO_VERSION_MASK;
						clasflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

						ClassFlags_text.Text = clasflags.ToString();
					}
					//else logfile.Log(". invalid");
					break;

				case DialogResult.Yes:											// change the version of any currently changed class
					//logfile.Log("Yes (any class) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of clasflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						ClassChanged claschanged;
						Class clas;

						int clasflags0;

						int total = Classes.Count;
						for (int id = 0; id != total; ++id)
						{
							clas = Classes[id];

							if (dirty = ClassesChanged.ContainsKey(id))
							{
								clasflags0 = ClassesChanged[id].flags;
							}
							else if (clas.isChanged)
							{
								clasflags0 = clas.flags;
							}
							else
								continue;

//							if (clasflags0 != 0)								// set the version even if the ClassFlags field is blank.
							{
								clasflags = (clasflags0 & ~HENCH_SPELL_INFO_VERSION_MASK);
								clasflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

								if (clasflags != clasflags0)
								{
									if (id == Id)
									{
										ClassFlags_text.Text = clasflags.ToString();
									}
									else
									{
										if (dirty)
										{
											claschanged = ClassesChanged[id];
										}
										else
										{
											claschanged = new ClassChanged();

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
										}

										claschanged.flags = clasflags;

										// check it
										int differ = ClassDiffer(clas, claschanged);
										clas.differ = differ;
										Classes[id] = clas;

										if (differ != bit_clear)
										{
											ClassesChanged[id] = claschanged;
											Tree.Nodes[id].ForeColor = Color.Crimson;
										}
										else
										{
											ClassesChanged.Remove(id);

											if (!clas.isChanged) // this is set by the Apply btn only.
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

				case DialogResult.Retry:										// change the version of all classes currently loaded
					//logfile.Log("Retry (all classes) result= " + input);

					if (Int32.TryParse(input, out ver)
						&& ver > 0 && ver < 256)								// version is held in only 8 bits of clasflags (do not allow 0).
					{
						//logfile.Log(". ver= " + ver);

						bool dirty;

						ClassChanged claschanged;
						Class clas;

						int clasflags0;

						int total = Classes.Count;
						for (int id = 0; id != total; ++id)
						{
							if (dirty = ClassesChanged.ContainsKey(id))
							{
								clasflags0 = ClassesChanged[id].flags;
							}
							else
								clasflags0 = Classes[id].flags;

//							if (clasflags0 != 0)								// set the version even if the ClassFlags field is blank.
							{
								clasflags = (clasflags0 & ~HENCH_SPELL_INFO_VERSION_MASK);
								clasflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);

								if (clasflags != clasflags0)
								{
									if (id == Id)
									{
										ClassFlags_text.Text = clasflags.ToString();
									}
									else
									{
										clas = Classes[id];

										if (dirty)
										{
											claschanged = ClassesChanged[id];
										}
										else
										{
											claschanged = new ClassChanged();

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
										}

										claschanged.flags = clasflags;

										// check it
										int differ = ClassDiffer(clas, claschanged);
										clas.differ = differ;
										Classes[id] = clas;

										if (differ != bit_clear)
										{
											ClassesChanged[id] = claschanged;
											Tree.Nodes[id].ForeColor = Color.Crimson;
										}
										else
										{
											ClassesChanged.Remove(id);

											if (!clas.isChanged) // this is set by the Apply btn only.
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
	}
}
