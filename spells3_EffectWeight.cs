using System;
using System.Drawing;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the EffectWeight page.
	/// </summary>
	partial class tabcontrol_Spells
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

				if (!MainForm.BypassDiffer)
				{
					Spell spell = MainForm.Spells[MainForm.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = MainForm.SpellsChanged[MainForm.Id];
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
					MainForm.Spells[MainForm.Id] = spell;

					Color color;
					if (differ != bit_clear)
					{
						MainForm.SpellsChanged[MainForm.Id] = spellchanged;
						color = Color.Crimson;
					}
					else
					{
						MainForm.SpellsChanged.Remove(MainForm.Id);

						if (spell.isChanged) color = Color.Blue;
						else                 color = DefaultForeColor;
					}
					MainForm.that.SetNodeColor(color);
				}

				differ = MainForm.Spells[MainForm.Id].differ;

				if ((differ & bit_effectweight) != 0)
				{
					EffectWeight_reset.ForeColor = Color.Crimson;
				}
				else
					EffectWeight_reset.ForeColor = DefaultForeColor;

				MainForm.that.SetEnabled(differ != bit_clear);
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
			Spell spell = MainForm.Spells[MainForm.Id];
			if ((spell.differ & bit_effectweight) != 0)
			{
				spell.differ &= ~bit_effectweight;
				MainForm.Spells[MainForm.Id] = spell;

				if (spell.differ == bit_clear)
				{
					MainForm.SpellsChanged.Remove(MainForm.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;
					MainForm.that.SetNodeColor(color);
				}

				EffectWeight_reset.ForeColor = DefaultForeColor;

				EffectWeight_text.Text = MainForm.Float2daFormat(spell.effectweight);
			}
		}
	}
}
