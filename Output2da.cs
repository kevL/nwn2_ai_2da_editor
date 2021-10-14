using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	static class Output2da
	{
		#region Write file
		// const strings for writing the 2da files
		const string HEAD_2DA          =  "2DA V2.0";
		const string HEAD_COLS_SPELLS  = " Label SpellInfo TargetInfo EffectWeight EffectTypes DamageInfo SaveType SaveDCType";
		const string HEAD_COLS_RACIAL  = " Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5";
		const string HEAD_COLS_CLASSES = " Label Flags FeatSpell1 FeatSpell2 FeatSpell3 FeatSpell4 FeatSpell5 FeatSpell6 FeatSpell7 FeatSpell8 FeatSpell9 FeatSpell10 FeatSpell11";


		/// <summary>
		/// Writes HenchSpells.2da.
		/// </summary>
		internal static void WriteHenchSpells(string pfe, IList<Spell> spells, TreeNodeCollection nodes)
		{
			Spell clear;

			for (int id = 0; id != spells.Count; ++id) // clear any 'isChanged' flags
			{
				clear = spells[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					spells[id] = clear;

					nodes[id].ForeColor = Control.DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(pfe))
			{
				sw.WriteLine(HEAD_2DA);
				sw.WriteLine(String.Empty);
				sw.WriteLine(HEAD_COLS_SPELLS);

				string line;

				foreach (var spell in spells) // this writes Applied data only.
				{
					line = spell.id + " ";

					if (!String.IsNullOrEmpty(spell.label))
					{
						line += spell.label;
					}
					else
						line += he.stars;

					line += " ";

					if (spell.spellinfo != 0)
					{
						line += spell.spellinfo.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (spell.targetinfo != 0)
					{
						line += spell.targetinfo.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (!he.FloatsEqual(spell.effectweight, 0.0f))
					{
						line += he.Float2daFormat(spell.effectweight);
					}
					else
						line += he.stars;

					line += " ";

					if (spell.effecttypes != 0)
					{
						line += spell.effecttypes.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (spell.damageinfo != 0)
					{
						line += spell.damageinfo.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (spell.savetype != 0)
					{
						line += spell.savetype.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (spell.savedctype != 0)
					{
						line += spell.savedctype.ToString();
					}
					else
						line += he.stars;

					sw.WriteLine(line);
				}
			}
		}

		/// <summary>
		/// Writes HenchRacial.2da.
		/// </summary>
		internal static void WriteHenchRacial(string pfe, IList<Race> races, TreeNodeCollection nodes)
		{
			Race clear;

			for (int id = 0; id != races.Count; ++id) // clear any 'isChanged' flags
			{
				clear = races[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					races[id] = clear;

					nodes[id].ForeColor = Control.DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(pfe))
			{
				sw.WriteLine(HEAD_2DA);
				sw.WriteLine(String.Empty);
				sw.WriteLine(HEAD_COLS_RACIAL);

				string line;

				foreach (var race in races) // this writes Applied data only.
				{
					line = race.id + " ";

					if (!String.IsNullOrEmpty(race.label))
					{
						line += race.label;
					}
					else
						line += he.stars;

					line += " ";

					if (race.flags != 0)
					{
						line += race.flags.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (race.feat1 != 0)
					{
						line += race.feat1.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (race.feat2 != 0)
					{
						line += race.feat2.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (race.feat3 != 0)
					{
						line += race.feat3.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (race.feat4 != 0)
					{
						line += race.feat4.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (race.feat5 != 0)
					{
						line += race.feat5.ToString();
					}
					else
						line += he.stars;

					sw.WriteLine(line);
				}
			}
		}

		/// <summary>
		/// Writes HenchClasses.2da.
		/// </summary>
		internal static void WriteHenchClasses(string pfe, IList<Class> classes, TreeNodeCollection nodes)
		{
			Class clear;

			for (int id = 0; id != classes.Count; ++id) // clear any 'isChanged' flags
			{
				clear = classes[id];
				if (clear.isChanged)
				{
					clear.isChanged = false;
					classes[id] = clear;

					nodes[id].ForeColor = Control.DefaultForeColor;
				}
			}


			using (var sw = new StreamWriter(pfe))
			{
				sw.WriteLine(HEAD_2DA);
				sw.WriteLine(String.Empty);
				sw.WriteLine(HEAD_COLS_CLASSES);

				string line;

				foreach (var @class in classes) // this writes Applied data only.
				{
					line = @class.id + " ";

					if (!String.IsNullOrEmpty(@class.label))
					{
						line += @class.label;
					}
					else
						line += he.stars;

					line += " ";

					if (@class.flags != 0)
					{
						line += @class.flags.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat1 != 0)
					{
						line += @class.feat1.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat2 != 0)
					{
						line += @class.feat2.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat3 != 0)
					{
						line += @class.feat3.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat4 != 0)
					{
						line += @class.feat4.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat5 != 0)
					{
						line += @class.feat5.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat6 != 0)
					{
						line += @class.feat6.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat7 != 0)
					{
						line += @class.feat7.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat8 != 0)
					{
						line += @class.feat8.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat9 != 0)
					{
						line += @class.feat9.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat10 != 0)
					{
						line += @class.feat10.ToString();
					}
					else
						line += he.stars;

					line += " ";

					if (@class.feat11 != 0)
					{
						line += @class.feat11.ToString();
					}
					else
						line += he.stars;

					sw.WriteLine(line);
				}
			}
		}
		#endregion Write file
	}
}
