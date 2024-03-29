﻿using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Functions for the TargetInfo page.
	partial class control_Spells
	{
		#region Fields (static)
		const int HENCH_SPELL_TARGET_RADIUS_SHIFT = 6;
		#endregion Fields (static)


		#region eventhandlers
		/// <summary>
		/// Handles <c>TextChanged</c> event on the TargetInfo page.
		/// </summary>
		/// <param name="sender"><c><see cref="TargetInfo_text"/></c></param>
		/// <param name="e"></param>
		void TextChanged_ti(object sender, EventArgs e)
		{
			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields.
			//
			// 'BypassDiffer' is set true since this does not need to go through
			// creating and deleting each SpellChanged-struct (since nothing has
			// changed yet OnLoad of the 2da-file).
			//
			// 'BypassDiffer' is also set true by AfterSelect_node() since the
			// Spell-structs already contain proper diff-data.

			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
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

						spellchanged.spellinfo    = spell.spellinfo;
						spellchanged.effectweight = spell.effectweight;
						spellchanged.effecttypes  = spell.effecttypes;
						spellchanged.damageinfo   = spell.damageinfo;
						spellchanged.savetype     = spell.savetype;
						spellchanged.savedctype   = spell.savedctype;
					}

					spellchanged.targetinfo = targetinfo;

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

				he.PrintCurrent(targetinfo, TargetInfo_hex, TargetInfo_bin);

				int differ = he.Spells[he.Id].differ;

				if ((differ & bit_targetinfo) != 0)
				{
					TargetInfo_reset.ForeColor = Color.Crimson;
				}
				else
					TargetInfo_reset.ForeColor = DefaultForeColor;

				state_TargetInfo(targetinfo);


				if (si_IsMaster.Checked)
				{
					// the 'si_Subspell1' textchanged handler can change the value
					// and shoot it back here
					si_Subspell1.Text = TargetInfo_text.Text;
				}
				else
				{
					// else let the value pass unhindered
					BypassSubspell = true;
					si_Subspell1.Text = TargetInfo_text.Text;
					BypassSubspell = false;
					SetSpellLabelText(si_SubspellLabel1, targetinfo);
				}


				// set DamageInfo colors based on SpellInfo spelltype and TargetInfo scaledeffect
				switch (si_co_Spelltype.SelectedIndex) // (spellinfo & hc.HENCH_SPELL_INFO_SPELL_TYPE_MASK)
				{
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_HEAL:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_HARM:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
					case hc.HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE:
						if (ti_ScaledEffect.Checked)
						{
							GroupColor(di_BeneficialGrp,  Color.LimeGreen);
							GroupColor(di_DetrimentalGrp, Color.Crimson);
						}
						else
						{
							GroupColor(di_BeneficialGrp,  Color.Crimson);
							GroupColor(di_DetrimentalGrp, Color.LimeGreen);
						}
						break;
				}

				_he.EnableApplys(differ != bit_clean);
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's targetinfo.
		/// </summary>
		/// <param name="sender"><c><see cref="TargetInfo_reset"/></c></param>
		/// <param name="e"></param>
		/// <remarks>If the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.</remarks>
		void Click_ti_reset(object sender, EventArgs e)
		{
			Spell spell = he.Spells[he.Id];
			if ((spell.differ & bit_targetinfo) != 0)
			{
				spell.differ &= ~bit_targetinfo;
				he.Spells[he.Id] = spell;

				if (spell.differ == bit_clean)
				{
					he.SpellsChanged.Remove(he.Id);

					Color color;
					if (spell.isChanged) color = Color.Blue;
					else                 color = DefaultForeColor;

					_he.SetNodeColor(color);
				}

				TargetInfo_reset.ForeColor = DefaultForeColor;

				TargetInfo_text.Text = spell.targetinfo.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by combobox on the TargetInfo page - Shape
		/// group.
		/// </summary>
		/// <param name="sender"><c><see cref="ti_co_Shape"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_ti_co_Shape(object sender, EventArgs e)
		{
			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
				targetinfo &= ~hc.HENCH_SPELL_TARGET_SHAPE_MASK; // clear specific bits
				TargetInfo_text.Text = (targetinfo | ti_co_Shape.SelectedIndex).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the TargetInfo page - Range
		/// group.
		/// </summary>
		/// <param name="sender"><c><see cref="ti_co_Range"/></c></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_ti_co_Range(object sender, EventArgs e)
		{
			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
				targetinfo &= ~hc.HENCH_SPELL_TARGET_RANGE_MASK; // clear specific bits

				int val;
				switch (ti_co_Range.SelectedIndex)
				{
					default: val = hc.HENCH_SPELL_TARGET_RANGE_PERSONAL; break;
					case 1:  val = hc.HENCH_SPELL_TARGET_RANGE_TOUCH;    break;
					case 2:  val = hc.HENCH_SPELL_TARGET_RANGE_SHORT;    break;
					case 3:  val = hc.HENCH_SPELL_TARGET_RANGE_MEDIUM;   break;
					case 4:  val = hc.HENCH_SPELL_TARGET_RANGE_LONG;     break;
					case 5:  val = hc.HENCH_SPELL_TARGET_RANGE_INFINITE; break;
				}
				TargetInfo_text.Text = (targetinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the TargetInfo page - Flags
		/// group.
		/// </summary>
		/// <param name="sender">
		/// <list type="bullet">
		/// <item><c><see cref="ti_ShapeLoop"/></c></item>
		/// <item><c><see cref="ti_CheckCount"/></c></item>
		/// <item><c><see cref="ti_MissileTargets"/></c></item>
		/// <item><c><see cref="ti_SecondaryTargets"/></c></item>
		/// <item><c><see cref="ti_SecondaryHalfDamage"/></c></item>
		/// <item><c><see cref="ti_SeenRequired"/></c></item>
		/// <item><c><see cref="ti_RangedSelectedArea"/></c></item>
		/// <item><c><see cref="ti_PersistentAoe"/></c></item>
		/// <item><c><see cref="ti_ScaledEffect"/></c></item>
		/// <item><c><see cref="ti_Necromancy"/></c></item>
		/// <item><c><see cref="ti_Regular"/></c></item>
		/// </list></param>
		/// <param name="e"></param>
		void MouseClick_ti_Flags(object sender, MouseEventArgs e)
		{
			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
				int bit;
				if (sender == ti_ShapeLoop)
				{
					bit = hc.HENCH_SPELL_TARGET_SHAPE_LOOP;
				}
				else if (sender == ti_CheckCount)
				{
					bit = hc.HENCH_SPELL_TARGET_CHECK_COUNT;
				}
				else if (sender == ti_MissileTargets)
				{
					bit = hc.HENCH_SPELL_TARGET_MISSILE_TARGETS;
				}
				else if (sender == ti_SecondaryTargets)
				{
					bit = hc.HENCH_SPELL_TARGET_SECONDARY_TARGETS;
				}
				else if (sender == ti_SecondaryHalfDamage)
				{
					bit = hc.HENCH_SPELL_TARGET_SECONDARY_HALF_DAM;
				}
				else if (sender == ti_SeenRequired)
				{
					bit = hc.HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG;
				}
				else if (sender == ti_RangedSelectedArea)
				{
					bit = hc.HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG;
				}
				else if (sender == ti_PersistentAoe)
				{
					bit = hc.HENCH_SPELL_TARGET_PERSISTENT_SPELL;
				}
				else if (sender == ti_ScaledEffect)
				{
					bit = hc.HENCH_SPELL_TARGET_SCALE_EFFECT;
				}
				else if (sender == ti_Necromancy)
				{
					bit = hc.HENCH_SPELL_TARGET_NECROMANCY_SPELL;
				}
				else // sender == ti_Regular
				{
					bit = hc.HENCH_SPELL_TARGET_REGULAR_SPELL;
				}

				if ((sender as CheckBox).Checked)
				{
					targetinfo |= bit;
				}
				else
					targetinfo &= ~bit;

				TargetInfo_text.Text = targetinfo.ToString();
			}
		}

		/// <summary>
		/// Handles changing the radius in the Radius textbox.
		/// </summary>
		/// <param name="sender"><c><see cref="ti_Radius"/></c></param>
		/// <param name="e"></param>
		void TextChanged_ti_Radius(object sender, EventArgs e)
		{
			float radius;
			if (Single.TryParse(ti_Radius.Text, out radius))
			{
				if (radius < 0.0f)
				{
					ti_Radius.Text = "0.0"; // recurse this funct.
					ti_Radius.SelectionStart = ti_Radius.Text.Length;
				}
				else if (radius > 102.3f)	// NOTE: This can throw on Convert.ToInt32()
				{							// if the input goes too high. So just stop it.
					ti_Radius.Text = "102.3"; // recurse this funct.
					ti_Radius.SelectionStart = ti_Radius.Text.Length;
				}
				else
				{
					radius *= 10.0f;

					int iradius = Convert.ToInt32(radius);
					if (iradius < 0) // make sure this doesn't nobble its way below 0 on the conversion.
					{
						iradius = 0;
					}
					else if (iradius > 1023) // 10 bits.
					{
						iradius = 1023;
					}

					int targetinfo = Int32.Parse(TargetInfo_text.Text);
					targetinfo &= ~hc.HENCH_SPELL_TARGET_RADIUS_MASK;

					iradius <<= HENCH_SPELL_TARGET_RADIUS_SHIFT;
					TargetInfo_text.Text = (targetinfo | iradius).ToString();
				}
			}
		}
		#endregion eventhandlers


		#region setstate
		/// <summary>
		/// Sets the checkers on the TargetInfo page to reflect the current
		/// targetinfo value.
		/// </summary>
		/// <param name="targetinfo"></param>
		void state_TargetInfo(int targetinfo)
		{
// Flags checkboxes
			ti_ShapeLoop          .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_SHAPE_LOOP)           != 0;
			ti_CheckCount         .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_CHECK_COUNT)          != 0;
			ti_MissileTargets     .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_MISSILE_TARGETS)      != 0;
			ti_SecondaryTargets   .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_SECONDARY_TARGETS)    != 0;
			ti_SecondaryHalfDamage.Checked = (targetinfo & hc.HENCH_SPELL_TARGET_SECONDARY_HALF_DAM)   != 0;
			ti_SeenRequired       .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG)    != 0;
			ti_RangedSelectedArea .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG) != 0;
			ti_PersistentAoe      .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_PERSISTENT_SPELL)     != 0;
			ti_ScaledEffect       .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_SCALE_EFFECT)         != 0;
			ti_Necromancy         .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_NECROMANCY_SPELL)     != 0;
			ti_Regular            .Checked = (targetinfo & hc.HENCH_SPELL_TARGET_REGULAR_SPELL)        != 0;

// Shape dropdown
			int val = (targetinfo & hc.HENCH_SPELL_TARGET_SHAPE_MASK); // 0x00000007
			if (val >= ti_co_Shape.Items.Count)
			{
				val = -1;
				ti_co_Shape.ForeColor = Color.Crimson;
			}
			else
				ti_co_Shape.ForeColor = DefaultForeColor;

			ti_co_Shape.SelectedIndex = val;

// Range dropdown
			ti_co_Range.ForeColor = DefaultForeColor;

			switch (targetinfo & hc.HENCH_SPELL_TARGET_RANGE_MASK) // 0x00000038
			{
				case hc.HENCH_SPELL_TARGET_RANGE_PERSONAL: val = 0; break;
				case hc.HENCH_SPELL_TARGET_RANGE_TOUCH:    val = 1; break;
				case hc.HENCH_SPELL_TARGET_RANGE_SHORT:    val = 2; break;
				case hc.HENCH_SPELL_TARGET_RANGE_MEDIUM:   val = 3; break;
				case hc.HENCH_SPELL_TARGET_RANGE_LONG:     val = 4; break;
				case hc.HENCH_SPELL_TARGET_RANGE_INFINITE: val = 5; break;

				default:
					val = -1;
					ti_co_Range.ForeColor = Color.Crimson;
					break;
			}
			ti_co_Range.SelectedIndex = val;

// Radius textbox
			val = (targetinfo & hc.HENCH_SPELL_TARGET_RADIUS_MASK)
								>> HENCH_SPELL_TARGET_RADIUS_SHIFT;
			ti_Radius.Text = util.Float2daFormat((float)val * 0.1f);

			// test ->
			int roguebits = (targetinfo & ~ti_legitbits);
			if (roguebits != 0)
			{
				ti_RogueBits.Text = roguebits.ToString("X8");
				ti_RogueBits   .Visible =
				ti_la_RogueBits.Visible = true;
			}
			else
				ti_RogueBits   .Visible =
				ti_la_RogueBits.Visible = false;
		}

		const int ti_legitbits = hc.HENCH_SPELL_TARGET_SHAPE_MASK			// 0x00000007
							   | hc.HENCH_SPELL_TARGET_RANGE_MASK			// 0x00000038
							   | hc.HENCH_SPELL_TARGET_RADIUS_MASK			// 0x0000ffc0

							   | hc.HENCH_SPELL_TARGET_SHAPE_LOOP			// 0x00010000
							   | hc.HENCH_SPELL_TARGET_CHECK_COUNT			// 0x00020000
							   | hc.HENCH_SPELL_TARGET_MISSILE_TARGETS		// 0x00040000
							   | hc.HENCH_SPELL_TARGET_SECONDARY_TARGETS	// 0x00080000
							   | hc.HENCH_SPELL_TARGET_SECONDARY_HALF_DAM	// 0x00100000
							   | hc.HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG	// 0x00200000
							   | hc.HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG	// 0x00400000
							   | hc.HENCH_SPELL_TARGET_PERSISTENT_SPELL		// 0x00800000
							   | hc.HENCH_SPELL_TARGET_SCALE_EFFECT			// 0x01000000
							   | hc.HENCH_SPELL_TARGET_NECROMANCY_SPELL		// 0x02000000
							   | hc.HENCH_SPELL_TARGET_REGULAR_SPELL;		// 0x04000000

																			// 0x08000000 <-
																			// 0x10000000 <-
																			// 0x20000000 <-
																			// 0x40000000 <-
																			// 0x80000000 <-
		#endregion setstate
	}
}
