using System;
using System.Drawing;


namespace nwn2_ai_2da_editor
{
	// Functions for the EffectWeight page.
	partial class control_Spells
	{
		#region eventhandlers
		/// <summary>
		/// Handles <c>TextChanged</c> event on the EffectWeight page.
		/// </summary>
		/// <param name="sender"><c><see cref="EffectWeight_text"/></c></param>
		/// <param name="e"></param>
		void TextChanged_ew(object sender, EventArgs e)
		{
			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields.
			//
			// EffectWeight doesn't have checkboxes or dropdown-fields ...
			//
			// 'BypassDiffer' is set true since this does not need to go through
			// creating and deleting each SpellChanged-struct (since nothing has
			// changed yet OnLoad of the 2da-file).
			//
			// 'BypassDiffer' is also set true by AfterSelect_node() since the
			// Spell-structs already contain proper diff-data.

			float effectweight;
			if (Single.TryParse(EffectWeight_text.Text, out effectweight))
			{
				if (!he.BypassDiffer)
				{
					Spell spell = he.Spells[he.Id];

					SpellChanged spellchanged;

					if (spell.differ != bit_clean)
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

					spell.differ = SpellDiffer(spell, spellchanged);
					he.Spells[he.Id] = spell;

					Color color;
					if (spell.differ != bit_clean)
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

				int differ = he.Spells[he.Id].differ;

				if ((differ & bit_effectweight) != 0)
				{
					EffectWeight_reset.ForeColor = Color.Crimson;
				}
				else
					EffectWeight_reset.ForeColor = DefaultForeColor;

				_he.EnableApplys(differ != bit_clean);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's effectweight.
		/// </summary>
		/// <param name="sender"><c><see cref="EffectWeight_reset"/></c></param>
		/// <param name="e"></param>
		/// <remarks>If the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.</remarks>
		void Click_ew_reset(object sender, EventArgs e)
		{
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_effectweight) != 0)
			{
				spell.differ &= ~bit_effectweight;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clean)
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
		#endregion eventhandlers
	}
}
