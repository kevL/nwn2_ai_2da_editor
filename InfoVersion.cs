using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Contains functions for changing the InfoVersion of spells/races/classes.
	/// </summary>
	partial class MainForm
	{
		const int HENCH_SPELL_INFO_VERSION_SHIFT = 24;

		/// <summary>
		/// An inputbox with which to set CoreAI version information.
		/// </summary>
		/// <param name="type"></param>
		/// <param name="str"></param>
		/// <returns></returns>
		static DialogResult InfoVersion(Type2da type, ref string str)
		{
			string title, text_1, text_2, text_3;
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

			DialogResult dr = DialogResult.Cancel;

			using (var ib = new Form())
			{
				var size = new Size(350, 125);

				ib.FormBorderStyle = FormBorderStyle.FixedToolWindow;
				ib.StartPosition = FormStartPosition.CenterParent;
				ib.ClientSize = size;
				ib.Text = title;
				ib.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);


				const int pad = 5;

				var infoText = new Label();
				infoText.Size = new Size(size.Width - pad * 2, 20);
				infoText.Location = new Point(pad, pad + 2);
				infoText.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
				infoText.ForeColor = Color.Crimson;
				infoText.TextAlign = ContentAlignment.TopCenter;
				infoText.Text = "Do NOT change this!";
				ib.Controls.Add(infoText);

				var textBox = new TextBox();
				textBox.Size = new Size(size.Width - pad * 10, 20);
				textBox.Location = new Point(pad * 5, 30);
				textBox.Text = str;
				textBox.TextChanged += TextChanged_ver;
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

				dr = ib.ShowDialog();

				str = textBox.Text;
			}
			return dr;
		}


		/// <summary>
		/// Handles the text-changed of the inputbox to ensure a valid version #.
		/// NOTE: version is held in only 8 bits of the master-int (do not allow 0)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void TextChanged_ver(object sender, EventArgs e)
		{
			var tb = sender as TextBox;

			int ver;
			if (!Int32.TryParse(tb.Text, out ver)
				|| ver < 1 || ver > 255)
			{
				tb.Text = (HENCH_SPELL_INFO_VERSION >> HENCH_SPELL_INFO_VERSION_SHIFT).ToString();
				tb.SelectionStart = tb.Text.Length;

				MessageBox.Show("Integer must be in range 1 to 255",
								"  are you sure you know what you're doing",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error,
								MessageBoxDefaultButton.Button1);
			}
		}


		/// <summary>
		/// Sets the InfoVersion of spell IDs.
		/// </summary>
		void SetInfoVersion_spells()
		{
			Spell spell = Spells[Id];											// use the current spell's ver as a basis

			int spellinfo;
			if ((spell.differ & bit_spellinfo) != 0)
			{
				spellinfo = SpellsChanged[Id].spellinfo;
			}
			else
				spellinfo = spell.spellinfo;

			int ver0 = (spellinfo & HENCH_SPELL_INFO_VERSION_MASK);
			if (ver0 == 0)
			{
				ver0 = HENCH_SPELL_INFO_VERSION;
			}
			ver0 >>= HENCH_SPELL_INFO_VERSION_SHIFT;


			string str = ver0.ToString();
			switch (InfoVersion(Type2da.TYPE_SPELLS, ref str))					// get user-input w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current spell's version only
					if ((spellinfo & ~HENCH_SPELL_INFO_VERSION_MASK) == 0)		// force-clear the version if the rest of spellinfo is blank
					{
						if (spellinfo != 0)
						{
							spellinfo = 0;
							SpellInfo_text.Text = spellinfo.ToString();			// firing the TextChanged event takes care of it.
						}
					}
					else
					{
						int ver = Int32.Parse(str);								// the return from the dialog.
						if (ver != ver0)										// check that user actually changed the value
						{
							spellinfo &= ~HENCH_SPELL_INFO_VERSION_MASK;
							spellinfo |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);
							SpellInfo_text.Text = spellinfo.ToString();			// firing the TextChanged event takes care of it.
						}
					}
					break;

				case DialogResult.Yes:											// change the version of any currently changed spell
					SetInfoVersion_spells(str, false);
					break;

				case DialogResult.Retry:										// change the version of all spells currently loaded
					SetInfoVersion_spells(str, true);
					break;

				case DialogResult.Cancel: // do a jig.
					break;
			}
		}

		/// <summary>
		/// Helper for SetInfoVersion_spells().
		/// </summary>
		/// <param name="str"></param>
		/// <param name="all"></param>
		void SetInfoVersion_spells(string str, bool all)
		{
			Spell spell;
			SpellChanged spellchanged;

			int spellinfo0, spellinfo, differ;
			bool dirty;

			int ver = Int32.Parse(str) << HENCH_SPELL_INFO_VERSION_SHIFT;		// the return from the dialog.


			int total = Spells.Count;
			for (int id = 0; id != total; ++id)
			{
				spell = Spells[id];

				if (dirty = ((spell.differ & bit_spellinfo) != 0))
				{
					spellinfo0 = SpellsChanged[id].spellinfo;
				}
				else if (all || spell.isChanged)
				{
					spellinfo0 = spell.spellinfo;
				}
				else
					continue;													// ignore clean spell-structs if !all

				if (spellinfo0 == 0)
				{
					continue;													// if spellinfo is blank leave it blank
				}


				if ((spellinfo0 & ~HENCH_SPELL_INFO_VERSION_MASK) == 0)			// force-clear the version if the rest of spellinfo is blank
				{
					spellinfo = 0;
				}
				else
					spellinfo = ((spellinfo0 & ~HENCH_SPELL_INFO_VERSION_MASK) | ver);


				if (spellinfo != spellinfo0)
				{
					if (id == Id)
					{
						SpellInfo_text.Text = spellinfo.ToString();				// firing the TextChanged event takes care of it.
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
						differ = SpellDiffer(spell, spellchanged);
						spell.differ = differ;
						Spells[id] = spell;

						Color color;
						if (differ != bit_clear)
						{
							SpellsChanged[id] = spellchanged;
							color = Color.Crimson;
						}
						else
						{
							SpellsChanged.Remove(id);
	
							if (spell.isChanged)
							{
								color = Color.Blue;
							}
							else
								color = DefaultForeColor;
						}
						Tree.Nodes[id].ForeColor = color;
					}
				}
			}
		}


		/// <summary>
		/// Sets the InfoVersion of race IDs.
		/// </summary>
		void SetInfoVersion_racial()
		{
			Race race = Races[Id];												// use the current race's ver as a basis

			int racialflags;
			if ((race.differ & bit_flags) != 0)
			{
				racialflags = RacesChanged[Id].flags;
			}
			else
				racialflags = race.flags;

			int ver0 = (racialflags & HENCH_SPELL_INFO_VERSION_MASK) >> HENCH_SPELL_INFO_VERSION_SHIFT;

			string str = ver0.ToString();
			switch (InfoVersion(Type2da.TYPE_RACIAL, ref str))					// get user-input w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current race's version only
				{
					int ver = Int32.Parse(str);									// the return from the dialog.
					if (ver != ver0)											// check that user actually changed the value
					{
						racialflags &= ~HENCH_SPELL_INFO_VERSION_MASK;
						racialflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);
						RacialFlags_text.Text = racialflags.ToString();			// firing the TextChanged event takes care of it.
					}
					break;
				}

				case DialogResult.Yes:											// change the version of any currently changed race
					SetInfoVersion_racial(str, false);
					break;

				case DialogResult.Retry:										// change the version of all races currently loaded
					SetInfoVersion_racial(str, true);
					break;

				case DialogResult.Cancel: // do a jig.
					break;
			}
		}

		/// <summary>
		/// Helper for SetInfoVersion_racial().
		/// </summary>
		/// <param name="str"></param>
		/// <param name="all"></param>
		void SetInfoVersion_racial(string str, bool all)
		{
			// NOTE: This will iterate through all changed races even
			// if an invalid version # is input via the dialog since it
			// inserts the default version even if there is no other
			// data in the racialflags-int.

			Race race;
			RaceChanged racechanged;

			int racialflags0, racialflags, differ;
			bool dirty;

			int ver = (Int32.Parse(str) << HENCH_SPELL_INFO_VERSION_SHIFT);		// the return from the dialog.


			int total = Races.Count;
			for (int id = 0; id != total; ++id)
			{
				race = Races[id];

				if (dirty = ((race.differ & bit_flags) != 0))
				{
					racialflags0 = RacesChanged[id].flags;
				}
				else if (all || race.isChanged)
				{
					racialflags0 = race.flags;
				}
				else
					continue;													// ignore clean racial-structs if !all


				if ((racialflags0 & HENCH_SPELL_INFO_VERSION_MASK) != ver)
				{
					if (!bypassInfoVersion)
					{
						racialflags = ((racialflags0 & ~HENCH_SPELL_INFO_VERSION_MASK) | ver);
					}
					else
						racialflags =  (racialflags0 & ~HENCH_SPELL_INFO_VERSION_MASK); // wipe version info for TonyAI 2.3+


					if (id == Id)
					{
						RacialFlags_text.Text = racialflags.ToString();			// firing the TextChanged event takes care of it.
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
						differ = RaceDiffer(race, racechanged);
						race.differ = differ;
						Races[id] = race;

						Color color;
						if (differ != bit_clear)
						{
							RacesChanged[id] = racechanged;
							color = Color.Crimson;
						}
						else
						{
							RacesChanged.Remove(id);

							if (race.isChanged)
							{
								color = Color.Blue;
							}
							else
								color = DefaultForeColor;
						}
						Tree.Nodes[id].ForeColor = color;
					}
				}
			}
		}


		/// <summary>
		/// Sets the InfoVersion of class IDs.
		/// </summary>
		void SetInfoVersion_classes()
		{
			Class clas = Classes[Id];											// use the current class' ver as a basis

			int clasflags;
			if ((clas.differ & bit_flags) != 0)
			{
				clasflags = ClassesChanged[Id].flags;
			}
			else
				clasflags = clas.flags;

			int ver0 = (clasflags & HENCH_SPELL_INFO_VERSION_MASK) >> HENCH_SPELL_INFO_VERSION_SHIFT;

			string str = ver0.ToString();
			switch (InfoVersion(Type2da.TYPE_CLASSES, ref str))					// get user-input w/ InfoVersion dialog
			{
				case DialogResult.OK:											// change the current class' version only
				{
					int ver = Int32.Parse(str);									// the return from the dialog.
					if (ver != ver0)											// check that user actually changed the value
					{
						clasflags &= ~HENCH_SPELL_INFO_VERSION_MASK;
						clasflags |= (ver << HENCH_SPELL_INFO_VERSION_SHIFT);
						ClassFlags_text.Text = clasflags.ToString();			// firing the TextChanged event takes care of it.
					}
					break;
				}

				case DialogResult.Yes:											// change the version of any currently changed class
					SetInfoVersion_classes(str, false);
					break;

				case DialogResult.Retry:										// change the version of all classes currently loaded
					SetInfoVersion_classes(str, true);
					break;

				case DialogResult.Cancel: // do a jig.
					break;
			}
		}

		/// <summary>
		/// Helper for SetInfoVersion_classes().
		/// </summary>
		/// <param name="str"></param>
		/// <param name="all"></param>
		void SetInfoVersion_classes(string str, bool all)
		{
			Class clas;
			ClassChanged claschanged;

			int clasflags0, clasflags, differ;
			bool dirty;

			int ver = (Int32.Parse(str) << HENCH_SPELL_INFO_VERSION_SHIFT);		// the return from the dialog.


			int total = Classes.Count;
			for (int id = 0; id != total; ++id)
			{
				clas = Classes[id];

				if (dirty = ((clas.differ & bit_flags) != 0))
				{
					clasflags0 = ClassesChanged[id].flags;
				}
				else if (all || clas.isChanged)
				{
					clasflags0 = clas.flags;
				}
				else
					continue;													// ignore clean class-structs if !all


				if ((clasflags0 & HENCH_SPELL_INFO_VERSION_MASK) != ver)
				{
					if (!bypassInfoVersion)
					{
						clasflags = ((clasflags0 & ~HENCH_SPELL_INFO_VERSION_MASK) | ver);
					}
					else
						clasflags =  (clasflags0 & ~HENCH_SPELL_INFO_VERSION_MASK); // wipe version info for TonyAI 2.3+

					if (id == Id)
					{
						ClassFlags_text.Text = clasflags.ToString();			// firing the TextChanged event takes care of it.
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
						differ = ClassDiffer(clas, claschanged);
						clas.differ = differ;
						Classes[id] = clas;

						Color color;
						if (differ != bit_clear)
						{
							ClassesChanged[id] = claschanged;
							color = Color.Crimson;
						}
						else
						{
							ClassesChanged.Remove(id);
	
							if (clas.isChanged)
							{
								color = Color.Blue;
							}
							else
								color = DefaultForeColor;
						}
						Tree.Nodes[id].ForeColor = color;
					}
				}
			}
		}
	}
}
