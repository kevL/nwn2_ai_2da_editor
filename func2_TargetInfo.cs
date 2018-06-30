using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the TargetInfo page.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the TargetInfo page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_ti(object sender, EventArgs e)
		{
			//logfile.Log("TextChanged_ti() bypassTextChanged= " + bypassTextChanged);

			// NOTE: TextChanged needs to fire when HenchSpells loads in order
			// to set the checkboxes and dropdown-fields. Technically however
			// this does not need to go through creating and deleting each
			// SpellChanged-struct (since nothing has changed yet OnLoad of the
			// 2da-file)
			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
				if (!bypassTextChanged)
				{
					var spell = Spells[Id];

					SpellChanged spellchanged;

					if (SpellsChanged.ContainsKey(Id))
					{
						spellchanged = SpellsChanged[Id];
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

					// check it
					int differ = SpellDiffer(spell, spellchanged);
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

				PrintCurrent(targetinfo, TargetInfo_hex, TargetInfo_bin);

				if ((Spells[Id].differ & bit_targetinfo) != 0)
				{
					TargetInfo_reset.ForeColor = Color.Crimson;
				}
				else
					TargetInfo_reset.ForeColor = DefaultForeColor;

				CheckTargetInfoCheckers(targetinfo);

				if (si_IsMaster.Checked)
				{
					// NOTE: this doesn't result in an infinite loop.
					si_Child1.Text = TargetInfo_text.Text;
				}


				// set DamageInfo colors based on SpellInfo spelltype and TargetInfo scaledeffect
				switch (cbo_si_Spelltype.SelectedIndex) // (spellinfo & HENCH_SPELL_INFO_SPELL_TYPE_MASK)
				{
					case HENCH_SPELL_INFO_SPELL_TYPE_ATTACK:
					case HENCH_SPELL_INFO_SPELL_TYPE_HEAL:
					case HENCH_SPELL_INFO_SPELL_TYPE_HARM:
					case HENCH_SPELL_INFO_SPELL_TYPE_ARCANE_ARCHER:
					case HENCH_SPELL_INFO_SPELL_TYPE_DRAGON_BREATH:
					case HENCH_SPELL_INFO_SPELL_TYPE_DOMINATE:
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

				apply          .Enabled = SpellsChanged.ContainsKey(Id);
				applyGlobal    .Enabled =
				gotoNextChanged.Enabled = !DirtyDataApplied();
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current spell's targetinfo.
		/// Note that if the Apply-btn has been clicked for the spell then that
		/// data will be used instead of the data from the originally loaded
		/// HenchSpells.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_ti_reset(object sender, EventArgs e)
		{
			if (SpellsChanged.ContainsKey(Id))
			{
				Spell spell = Spells[Id];
				spell.differ &= ~bit_targetinfo;
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

				TargetInfo_reset.ForeColor = DefaultForeColor;

				TargetInfo_text.Text = spell.targetinfo.ToString();
			}
		}


		/// <summary>
		/// Populates the TargetInfo dropdown-lists.
		/// </summary>
		void PopulateTargetInfoComboboxes()
		{
			// NOTE: See 'hench_i0_itemsp' DispatchSpell()

			// populate the dropdown list for TargetInfo - Shape
			cbo_ti_Shape.Items.Add("spellcylinder");	// 0
			cbo_ti_Shape.Items.Add("cone");				// 1
			cbo_ti_Shape.Items.Add("cube");				// 2
			cbo_ti_Shape.Items.Add("spellcone");		// 3
			cbo_ti_Shape.Items.Add("sphere");			// 4
			cbo_ti_Shape.Items.Add("[not used]");		// 5
			cbo_ti_Shape.Items.Add("faction");			// 6
			cbo_ti_Shape.Items.Add("none");				// 7

			// populate the dropdown list for TargetInfo - Range
			cbo_ti_Range.Items.Add("personal");	// 0
			cbo_ti_Range.Items.Add("touch");	// 1
			cbo_ti_Range.Items.Add("short");	// 2
			cbo_ti_Range.Items.Add("medium");	// 3
			cbo_ti_Range.Items.Add("long");		// 4
			cbo_ti_Range.Items.Add("infinite");	// 5
		}


		/// <summary>
		/// Handles toggling bits by combobox on the TargetInfo page - Shape group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_ti_cbo_Shape(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_ti_cbo_Shape() selectedId= " + cbo_ti_Shape.SelectedIndex);

			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
//				bypassCheckedChecker = true;

				targetinfo &= ~HENCH_SPELL_TARGET_SHAPE_MASK; // clear specific bits
				TargetInfo_text.Text = (targetinfo | cbo_ti_Shape.SelectedIndex).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the TargetInfo page - Range group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_ti_cbo_Range(object sender, EventArgs e)
		{
			//logfile.Log("SelectionChangeCommitted_ti_cbo_Range() selectedId= " + cbo_ti_Range.SelectedIndex);

			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
//				bypassCheckedChecker = true;

				targetinfo &= ~HENCH_SPELL_TARGET_RANGE_MASK; // clear specific bits

				int val;
				switch (cbo_ti_Range.SelectedIndex)
				{
					default: val = HENCH_SPELL_TARGET_RANGE_PERSONAL; break;
					case 1:  val = HENCH_SPELL_TARGET_RANGE_TOUCH;    break;
					case 2:  val = HENCH_SPELL_TARGET_RANGE_SHORT;    break;
					case 3:  val = HENCH_SPELL_TARGET_RANGE_MEDIUM;   break;
					case 4:  val = HENCH_SPELL_TARGET_RANGE_LONG;     break;
					case 5:  val = HENCH_SPELL_TARGET_RANGE_INFINITE; break;
				}
				TargetInfo_text.Text = (targetinfo | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the TargetInfo page - Flags group.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_ti_Flags(object sender, MouseEventArgs e)
		{
			//logfile.Log("MouseClick_ti_Flags()");
			//logfile.Log(". text= " + TargetInfo_text.Text);

			int targetinfo;
			if (Int32.TryParse(TargetInfo_text.Text, out targetinfo))
			{
				//logfile.Log(". . is valid Int32= " + targetinfo);

				int bit;

				var cb = sender as CheckBox;
				if (cb == ti_ShapeLoop)
				{
					bit = HENCH_SPELL_TARGET_SHAPE_LOOP;
				}
				else if (cb == ti_CheckCount)
				{
					bit = HENCH_SPELL_TARGET_CHECK_COUNT;
				}
				else if (cb == ti_MissileTargets)
				{
					bit = HENCH_SPELL_TARGET_MISSILE_TARGETS;
				}
				else if (cb == ti_SecondaryTargets)
				{
					bit = HENCH_SPELL_TARGET_SECONDARY_TARGETS;
				}
				else if (cb == ti_SecondaryHalfDamage)
				{
					bit = HENCH_SPELL_TARGET_SECONDARY_HALF_DAM;
				}
				else if (cb == ti_SeenRequired)
				{
					bit = HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG;
				}
				else if (cb == ti_RangedSelectedArea)
				{
					bit = HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG;
				}
				else if (cb == ti_PersistentAoe)
				{
					bit = HENCH_SPELL_TARGET_PERSISTENT_SPELL;
				}
				else if (cb == ti_ScaledEffect)
				{
					bit = HENCH_SPELL_TARGET_SCALE_EFFECT;
				}
				else if (cb == ti_Necromancy)
				{
					bit = HENCH_SPELL_TARGET_NECROMANCY_SPELL;
				}
				else //if (cb == ti_Regular)
				{
					bit = HENCH_SPELL_TARGET_REGULAR_SPELL;
				}

				if (cb.Checked)
				{
					targetinfo |= bit;
				}
				else
					targetinfo &= ~bit;

//				bypassCheckedChecker = true;
				TargetInfo_text.Text = targetinfo.ToString();
			}
		}

		/// <summary>
		/// Handles changing the radius in the Radius textbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_ti_Radius(object sender, EventArgs e)
		{
			float radius;
			if (float.TryParse(ti_Radius.Text, out radius))
			{
				if (radius < 0.0f)
				{
					radius = 0.0f;
					ti_Radius.Text = FormatFloat(radius.ToString()); // re-trigger this funct.
				}
				else if (radius > 102.3f)	// NOTE: This can throw on Convert.ToInt32()
				{							// if the input goes too high. So just stop it.
					radius = 102.3f;
					ti_Radius.Text = FormatFloat(radius.ToString()); // re-trigger this funct.
				}
				else
				{
					radius *= 10.0f;
//					radius +=  0.5f;

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
					targetinfo &= ~HENCH_SPELL_TARGET_RADIUS_MASK;

					iradius <<= HENCH_SPELL_TARGET_RADIUS_SHIFT;
					TargetInfo_text.Text = (targetinfo | iradius).ToString();
				}
			}
		}


		const int HENCH_SPELL_TARGET_RADIUS_SHIFT = 6;

		/// <summary>
		/// Sets the checkers on the TargetInfo page to reflect the current
		/// targetinfo value.
		/// </summary>
		/// <param name="targetinfo"></param>
		void CheckTargetInfoCheckers(int targetinfo)
		{
//			if (!bypassCheckedChecker)
			{
// Flags checkboxes
				ti_ShapeLoop          .Checked = (targetinfo & HENCH_SPELL_TARGET_SHAPE_LOOP)           != 0;
				ti_CheckCount         .Checked = (targetinfo & HENCH_SPELL_TARGET_CHECK_COUNT)          != 0;
				ti_MissileTargets     .Checked = (targetinfo & HENCH_SPELL_TARGET_MISSILE_TARGETS)      != 0;
				ti_SecondaryTargets   .Checked = (targetinfo & HENCH_SPELL_TARGET_SECONDARY_TARGETS)    != 0;
				ti_SecondaryHalfDamage.Checked = (targetinfo & HENCH_SPELL_TARGET_SECONDARY_HALF_DAM)   != 0;
				ti_SeenRequired       .Checked = (targetinfo & HENCH_SPELL_TARGET_VIS_REQUIRED_FLAG)    != 0;
				ti_RangedSelectedArea .Checked = (targetinfo & HENCH_SPELL_TARGET_RANGED_SEL_AREA_FLAG) != 0;
				ti_PersistentAoe      .Checked = (targetinfo & HENCH_SPELL_TARGET_PERSISTENT_SPELL)     != 0;
				ti_ScaledEffect       .Checked = (targetinfo & HENCH_SPELL_TARGET_SCALE_EFFECT)         != 0;
				ti_Necromancy         .Checked = (targetinfo & HENCH_SPELL_TARGET_NECROMANCY_SPELL)     != 0;
				ti_Regular            .Checked = (targetinfo & HENCH_SPELL_TARGET_REGULAR_SPELL)        != 0;

// Shape dropdown
				int val = (targetinfo & HENCH_SPELL_TARGET_SHAPE_MASK); // 0x00000007
				if (val >= cbo_ti_Shape.Items.Count)
				{
					val = -1;
					cbo_ti_Shape.ForeColor = Color.Crimson;
				}
				else
					cbo_ti_Shape.ForeColor = DefaultForeColor;

				cbo_ti_Shape.SelectedIndex = val;

// Range dropdown
				cbo_ti_Range.ForeColor = DefaultForeColor;

				switch (targetinfo & HENCH_SPELL_TARGET_RANGE_MASK) // 0x00000038
				{
					case HENCH_SPELL_TARGET_RANGE_PERSONAL: val = 0; break;
					case HENCH_SPELL_TARGET_RANGE_TOUCH:    val = 1; break;
					case HENCH_SPELL_TARGET_RANGE_SHORT:    val = 2; break;
					case HENCH_SPELL_TARGET_RANGE_MEDIUM:   val = 3; break;
					case HENCH_SPELL_TARGET_RANGE_LONG:     val = 4; break;
					case HENCH_SPELL_TARGET_RANGE_INFINITE: val = 5; break;

					default:
						val = -1;
						cbo_ti_Range.ForeColor = Color.Crimson;
						break;
				}
				cbo_ti_Range.SelectedIndex = val;

// Radius textbox
				val = targetinfo;
				val &= HENCH_SPELL_TARGET_RADIUS_MASK;
				val >>= HENCH_SPELL_TARGET_RADIUS_SHIFT;
				float fval = ((float)val) * 0.1f;
				ti_Radius.Text = FormatFloat(fval.ToString());
			}
//			else
//				bypassCheckedChecker = false;
		}
	}
}
