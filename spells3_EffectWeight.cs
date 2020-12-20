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

				if (!he.BypassDiffer)
				{
					Spell spell = he.Spells[he.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clear)
					{
						spellchanged = he.SpellsChanged[he.Id];
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
					he.Spells[he.Id] = spell;

					Color color;
					if (differ != bit_clear)
					{
						he.SpellsChanged[he.Id] = spellchanged;
						color = Color.Crimson;
					}
					else
					{
						he.SpellsChanged.Remove(he.Id);

						if (spell.isChanged) color = Color.Blue;
						else                 color = DefaultForeColor;
					}
					_he.SetNodeColor(color);
				}

				differ = he.Spells[he.Id].differ;

				if ((differ & bit_effectweight) != 0)
				{
					EffectWeight_reset.ForeColor = Color.Crimson;
				}
				else
					EffectWeight_reset.ForeColor = DefaultForeColor;

				_he.EnableApplys(differ != bit_clear);
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
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_effectweight) != 0)
			{
				spell.differ &= ~bit_effectweight;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clear)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				EffectWeight_reset.ForeColor = DefaultForeColor;

				EffectWeight_text.Text = he.Float2daFormat(spell.effectweight);
			}
		}
	}
}
