using System;
using System.Drawing;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the EffectWeight page.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the EffectWeight page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_ew(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_effectweight() bypassTextChanged= " + bypassTextChanged);

			float effectweight;
			if (float.TryParse(EffectWeight_text.Text, out effectweight))
			{
				int differ;

				if (!bypassTextChanged)
				{
					Spell spell = Spells[Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = SpellsChanged[Id];
					}
					else
					{
						spellchanged = new SpellChanged();

						spellchanged.spellinfo   = spell.spellinfo;
						spellchanged.targetinfo  = spell.targetinfo;
						spellchanged.effecttypes = spell.effecttypes;
						spellchanged.damageinfo  = spell.damageinfo;
						spellchanged.savetype    = spell.savetype;
						spellchanged.savedctype  = spell.savedctype;
					}

					spellchanged.effectweight = effectweight;

					// check it
					differ = SpellDiffer(spell, spellchanged);
					spell.differ = differ;
					Spells[Id] = spell;

					if (differ != bit_clear)
					{
						SpellsChanged[Id] = spellchanged;
						Tree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						SpellsChanged.Remove(Id);

						if (!spell.isChanged) // this is set by the Apply btn only.
						{
							Tree.SelectedNode.ForeColor = DefaultForeColor;
						}
					}
				}

				differ = Spells[Id].differ;

				if ((differ & bit_effectweight) != 0)
				{
					EffectWeight_reset.ForeColor = Color.Crimson;
				}
				else
					EffectWeight_reset.ForeColor = DefaultForeColor;

				apply          .Enabled = (differ != bit_clear);
				applyGlobal    .Enabled = (differ != bit_clear) || (SpellsChanged.Count != 0);
				gotoNextChanged.Enabled = (differ != bit_clear) || (SpellsChanged.Count != 0) || SpareChange();
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's effectweight.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_ew_reset(object sender, EventArgs e)
		{
			Spell spell = Spells[Id];
			if ((spell.differ & bit_effectweight) != 0)
			{
				spell.differ &= ~bit_effectweight;
				Spells[Id] = spell;

				if (spell.differ == bit_clear)
				{
					SpellsChanged.Remove(Id);

					if (spell.isChanged) // this is set by the Apply btn only.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else
						Tree.SelectedNode.ForeColor = DefaultForeColor;
				}

				EffectWeight_reset.ForeColor = DefaultForeColor;

				EffectWeight_text.Text = FormatFloat(spell.effectweight.ToString());
			}
		}
	}
}
