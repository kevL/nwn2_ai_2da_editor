using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the Classes pages.
	/// </summary>
	partial class MainForm
	{
		/// <summary>
		/// Handles TextChanged event on the Classes pages.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_classes(object sender, EventArgs e)
		{
			var tb = sender as TextBox;

			// NOTE: TextChanged needs to fire when HenchClasses loads in order
			// to set the checkers. Technically however this does not need to go
			// through creating and deleting each Class-struct (since nothing
			// has changed yet OnLoad of the 2da-file)

			int val;
			if (Int32.TryParse(tb.Text, out val))
			{
				Button btn;
				TextBox tb_hex, tb_bin;
				int bit;

				if (tb == ClassFlags_text)
				{
					btn = ClassFlags_reset;
					tb_hex = ClassFlags_hex;
					tb_bin = ClassFlags_bin;
					bit = bit_flags;
				}
				else if (tb == ClassFeat1_text)
				{
					btn = ClassFeat1_reset;
					tb_hex = ClassFeat1_hex;
					tb_bin = ClassFeat1_bin;
					bit = bit_feat1;
				}
				else if (tb == ClassFeat2_text)
				{
					btn = ClassFeat2_reset;
					tb_hex = ClassFeat2_hex;
					tb_bin = ClassFeat2_bin;
					bit = bit_feat2;
				}
				else if (tb == ClassFeat3_text)
				{
					btn = ClassFeat3_reset;
					tb_hex = ClassFeat3_hex;
					tb_bin = ClassFeat3_bin;
					bit = bit_feat3;
				}
				else if (tb == ClassFeat4_text)
				{
					btn = ClassFeat4_reset;
					tb_hex = ClassFeat4_hex;
					tb_bin = ClassFeat4_bin;
					bit = bit_feat4;
				}
				else if (tb == ClassFeat5_text)
				{
					btn = ClassFeat5_reset;
					tb_hex = ClassFeat5_hex;
					tb_bin = ClassFeat5_bin;
					bit = bit_feat5;
				}
				else if (tb == ClassFeat6_text)
				{
					btn = ClassFeat6_reset;
					tb_hex = ClassFeat6_hex;
					tb_bin = ClassFeat6_bin;
					bit = bit_feat6;
				}
				else if (tb == ClassFeat7_text)
				{
					btn = ClassFeat7_reset;
					tb_hex = ClassFeat7_hex;
					tb_bin = ClassFeat7_bin;
					bit = bit_feat7;
				}
				else if (tb == ClassFeat8_text)
				{
					btn = ClassFeat8_reset;
					tb_hex = ClassFeat8_hex;
					tb_bin = ClassFeat8_bin;
					bit = bit_feat8;
				}
				else if (tb == ClassFeat9_text)
				{
					btn = ClassFeat9_reset;
					tb_hex = ClassFeat9_hex;
					tb_bin = ClassFeat9_bin;
					bit = bit_feat9;
				}
				else if (tb == ClassFeat10_text)
				{
					btn = ClassFeat10_reset;
					tb_hex = ClassFeat10_hex;
					tb_bin = ClassFeat10_bin;
					bit = bit_feat10;
				}
				else //if (tb == ClassFeat11_text)
				{
					btn = ClassFeat11_reset;
					tb_hex = ClassFeat11_hex;
					tb_bin = ClassFeat11_bin;
					bit = bit_feat11;
				}

				if (!bypassTextChanged)
				{
/*
					// ensure that spellinfo has a CoreAI version
					// although strictly speaking I believe that GetSpellInfo()
					// will gracefully handle spell-data that has no version set.
					if (val != 0)
					{
						if ((val & HENCH_SPELL_INFO_VERSION_MASK) == 0) // insert the default spell-version if it doesn't exist
						{
							val |= HENCH_SPELL_INFO_VERSION; // def'n 'hench_i0_generic'
							tb.Text = val.ToString();
							return; // re-fire this funct.
						}

						if (val == (val & HENCH_SPELL_INFO_VERSION_MASK)) // clear the spell-version if that's the only data in spellinfo
						{
							// TODO: I suppose the spell-version should be stored (if not the default version #) ...
							// so it can be re-inserted identically (if/after user clears all spellinfo bits).
							val = 0;
							tb.Text = val.ToString();
							return; // re-fire this funct.
						}
					}
					// TODO: Those need to update the fields when loading the 2da
					// ... especially the Text-field/reset-color. And the spell-tree's node-color
*/

					Class clas = Classes[Id];

					ClassChanged claschanged;

					if (ClassesChanged.ContainsKey(Id))
					{
						claschanged = ClassesChanged[Id];
					}
					else
					{
						claschanged = new ClassChanged();

						claschanged.flags  = clas.flags;
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

					if (tb == ClassFlags_text)
					{
						claschanged.flags = val;
					}
					else if (tb == ClassFeat1_text)
					{
						claschanged.feat1 = val;
					}
					else if (tb == ClassFeat2_text)
					{
						claschanged.feat2 = val;
					}
					else if (tb == ClassFeat3_text)
					{
						claschanged.feat3 = val;
					}
					else if (tb == ClassFeat4_text)
					{
						claschanged.feat4 = val;
					}
					else if (tb == ClassFeat5_text)
					{
						claschanged.feat5 = val;
					}
					else if (tb == ClassFeat6_text)
					{
						claschanged.feat6 = val;
					}
					else if (tb == ClassFeat7_text)
					{
						claschanged.feat7 = val;
					}
					else if (tb == ClassFeat8_text)
					{
						claschanged.feat8 = val;
					}
					else if (tb == ClassFeat9_text)
					{
						claschanged.feat9 = val;
					}
					else if (tb == ClassFeat10_text)
					{
						claschanged.feat10 = val;
					}
					else //if (tb == ClassFeat11_text)
					{
						claschanged.feat11 = val;
					}

					// check it
					int differ = ClassDiffer(clas, claschanged);
					clas.differ = differ;
					Classes[Id] = clas;

					if (differ != bit_clear)
					{
						ClassesChanged[Id] = claschanged;
						Tree.SelectedNode.ForeColor = Color.Crimson;
					}
					else
					{
						ClassesChanged.Remove(Id);

						if (!clas.isChanged) // this is set by the Apply btn only.
						{
							Tree.SelectedNode.ForeColor = DefaultForeColor;
						}
					}

					PrintCurrent(val, null, tb_hex, tb_bin);
				}

				if ((Classes[Id].differ & bit) != 0)
				{
					btn.ForeColor = Color.Crimson;
				}
				else
					btn.ForeColor = DefaultForeColor;

				if (tb == ClassFlags_text)
				{
					CheckClassFlagsCheckers();
				}
				else
					CheckClassFeatsCheckers(tb);

//				bypassCheckedChecker = false; // TODO: This funct will fire multiple times OnLoad ...


				PrintInfoVersion_class();
			}
			// else TODO: error dialog here.
		}

		/// <summary>
		/// Handles resetting the current class' info.
		/// Note that if the Apply-btn has been clicked for the class then that
		/// data will be used instead of the data from the originally loaded
		/// HenchClasses.2da file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Click_classes_reset(object sender, EventArgs e)
		{
			if (ClassesChanged.ContainsKey(Id))
			{
				TextBox tb;
				int info, bit;

				Class clas = Classes[Id];

				var btn = sender as Button;
				if (btn == ClassFlags_reset)
				{
					tb = ClassFlags_text;
					info = clas.flags;
					bit = bit_flags;
				}
				else if (btn == ClassFeat1_reset)
				{
					tb = ClassFeat1_text;
					info = clas.feat1;
					bit = bit_feat1;
				}
				else if (btn == ClassFeat2_reset)
				{
					tb = ClassFeat2_text;
					info = clas.feat2;
					bit = bit_feat2;
				}
				else if (btn == ClassFeat3_reset)
				{
					tb = ClassFeat3_text;
					info = clas.feat3;
					bit = bit_feat3;
				}
				else if (btn == ClassFeat4_reset)
				{
					tb = ClassFeat4_text;
					info = clas.feat4;
					bit = bit_feat4;
				}
				else //if (btn == ClassFeat5_reset)
				{
					tb = ClassFeat5_text;
					info = clas.feat5;
					bit = bit_feat5;
				}

				clas.differ &= ~bit;
				Classes[Id] = clas;

				if (clas.differ == bit_clear)
				{
					ClassesChanged.Remove(Id);

					if (clas.isChanged) // this is set by the Apply btn only.
					{
						Tree.SelectedNode.ForeColor = Color.MediumBlue;
					}
					else
						Tree.SelectedNode.ForeColor = DefaultForeColor;
				}

				btn.ForeColor = DefaultForeColor;

				tb.Text = info.ToString();
			}
		}


		/// <summary>
		/// Handles toggling bits by checkboxes on the ClassFlags page.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MouseClick_cFlags(object sender, MouseEventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				if (cf_HasFeatSpells.Checked)
				{
					flags |= HENCH_CLASS_FEAT_SPELLS;
				}
				else
					flags &= ~HENCH_CLASS_FEAT_SPELLS;

//				bypassCheckedChecker = true;
				ClassFlags_text.Text = flags.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by checkboxes on the ClassFeats pages.
		/// </summary>
		void MouseClick_cFeats(object sender, MouseEventArgs e)
		{
			TextBox tb;

			var cb = sender as CheckBox;
			if (cb == cf1_cheatCast)
			{
				tb = ClassFeat1_text;
			}
			else if (cb == cf2_cheatCast)
			{
				tb = ClassFeat2_text;
			}
			else if (cb == cf3_cheatCast)
			{
				tb = ClassFeat3_text;
			}
			else if (cb == cf4_cheatCast)
			{
				tb = ClassFeat4_text;
			}
			else if (cb == cf5_cheatCast)
			{
				tb = ClassFeat5_text;
			}
			else if (cb == cf6_cheatCast)
			{
				tb = ClassFeat6_text;
			}
			else if (cb == cf7_cheatCast)
			{
				tb = ClassFeat7_text;
			}
			else if (cb == cf8_cheatCast)
			{
				tb = ClassFeat8_text;
			}
			else if (cb == cf9_cheatCast)
			{
				tb = ClassFeat9_text;
			}
			else if (cb == cf10_cheatCast)
			{
				tb = ClassFeat10_text;
			}
			else //if (cb == cf11_cheatCast)
			{
				tb = ClassFeat11_text;
			}

			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				if (cb.Checked)
				{
					feat |= HENCH_FEAT_SPELL_CHEAT_CAST;
				}
				else
					feat &= ~HENCH_FEAT_SPELL_CHEAT_CAST;

//				bypassCheckedChecker = true;
				tb.Text = feat.ToString();
			}
		}

		/// <summary>
		/// Handles changing ClassFeat feats in their textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_cFeat(object sender, EventArgs e)
		{
			var tb_feat = sender as TextBox;

			int feat;
			if (Int32.TryParse(tb_feat.Text, out feat))
			{
				if (feat < 0)
				{
					feat = 0;
					tb_feat.Text = feat.ToString(); // re-trigger this funct.
				}
				else if (feat > 65535) // 16 bits
				{
					feat = 65535;
					tb_feat.Text = feat.ToString(); // re-trigger this funct.
				}
				else
				{
					TextBox tb;
					if (tb_feat == cf1_FeatId)
					{
						tb = ClassFeat1_text;
					}
					else if (tb_feat == cf2_FeatId)
					{
						tb = ClassFeat2_text;
					}
					else if (tb_feat == cf3_FeatId)
					{
						tb = ClassFeat3_text;
					}
					else if (tb_feat == cf4_FeatId)
					{
						tb = ClassFeat4_text;
					}
					else if (tb_feat == cf5_FeatId)
					{
						tb = ClassFeat5_text;
					}
					else if (tb_feat == cf6_FeatId)
					{
						tb = ClassFeat6_text;
					}
					else if (tb_feat == cf7_FeatId)
					{
						tb = ClassFeat7_text;
					}
					else if (tb_feat == cf8_FeatId)
					{
						tb = ClassFeat8_text;
					}
					else if (tb_feat == cf9_FeatId)
					{
						tb = ClassFeat9_text;
					}
					else if (tb_feat == cf10_FeatId)
					{
						tb = ClassFeat10_text;
					}
					else //if (tb_feat == cf11_FeatId)
					{
						tb = ClassFeat11_text;
					}

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~HENCH_FEAT_SPELL_MASK_FEAT;

					tb.Text = (feaT | feat).ToString();
				}
			}
		}

		/// <summary>
		/// Handles changing ClassFeat spells in their textboxes.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TextChanged_cSpell(object sender, EventArgs e)
		{
			var tb_spell = sender as TextBox;

			int spell;
			if (Int32.TryParse(tb_spell.Text, out spell))
			{
				if (spell < 0)
				{
					spell = 0;
					tb_spell.Text = spell.ToString(); // re-trigger this funct.
				}
				else if (spell > 16383) // 14 bits
				{
					spell = 16383;
					tb_spell.Text = spell.ToString(); // re-trigger this funct.
				}
				else
				{
					TextBox tb;
					if (tb_spell == cf1_SpellId)
					{
						tb = ClassFeat1_text;
					}
					else if (tb_spell == cf2_SpellId)
					{
						tb = ClassFeat2_text;
					}
					else if (tb_spell == cf3_SpellId)
					{
						tb = ClassFeat3_text;
					}
					else if (tb_spell == cf4_SpellId)
					{
						tb = ClassFeat4_text;
					}
					else if (tb_spell == cf5_SpellId)
					{
						tb = ClassFeat5_text;
					}
					else if (tb_spell == cf6_SpellId)
					{
						tb = ClassFeat6_text;
					}
					else if (tb_spell == cf7_SpellId)
					{
						tb = ClassFeat7_text;
					}
					else if (tb_spell == cf8_SpellId)
					{
						tb = ClassFeat8_text;
					}
					else if (tb_spell == cf9_SpellId)
					{
						tb = ClassFeat9_text;
					}
					else if (tb_spell == cf10_SpellId)
					{
						tb = ClassFeat10_text;
					}
					else //if (tb_spell == cf11_SpellId)
					{
						tb = ClassFeat11_text;
					}

					int feaT = Int32.Parse(tb.Text);
					feaT &= ~HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb.Text = (feaT | spell).ToString();
				}
			}
		}


		/// <summary>
		/// Prints the info-version of the currently selected class ID.
		/// </summary>
		void PrintInfoVersion_class()
		{
			int ver;
			if (ClassesChanged.ContainsKey(Id))
			{
				ver = ClassesChanged[Id].flags;
			}
			else
				ver = Classes[Id].flags;

			ver &= HENCH_SPELL_INFO_VERSION_MASK;
			ver >>= HENCH_SPELL_INFO_VERSION_SHIFT;

			cf_infoversion.Text = ver.ToString();
		}


		/// <summary>
		/// Sets the checkers on the ClassFlags page to reflect the current
		/// flags value.
		/// </summary>
		void CheckClassFlagsCheckers()
		{
//			if (!bypassCheckedChecker)
			{
				int flags;
				if (ClassesChanged.ContainsKey(Id))
				{
					flags = ClassesChanged[Id].flags;
				}
				else
					flags = Classes[Id].flags;

				cf_HasFeatSpells.Checked = (flags & HENCH_CLASS_FEAT_SPELLS) != 0;
			}
//			else
//				bypassCheckedChecker = false; // TODO: conflict w/ CheckClassFeatsCheckers()
		}

		/// <summary>
		/// Sets the checkers on the ClassFeats pages to reflect the current
		/// feat value.
		/// </summary>
		/// <param name="tb"></param>
		void CheckClassFeatsCheckers(Control tb)
		{
//			if (!bypassCheckedChecker)
			{
				CheckBox cb;
				TextBox tb_feat, tb_spell;

				int feat;
				if (Int32.TryParse(tb.Text, out feat))
				{
					if (tb == ClassFeat1_text)
					{
						cb = cf1_cheatCast;
						tb_feat = cf1_FeatId;
						tb_spell = cf1_SpellId;
					}
					else if (tb == ClassFeat2_text)
					{
						cb = cf2_cheatCast;
						tb_feat = cf2_FeatId;
						tb_spell = cf2_SpellId;
					}
					else if (tb == ClassFeat3_text)
					{
						cb = cf3_cheatCast;
						tb_feat = cf3_FeatId;
						tb_spell = cf3_SpellId;
					}
					else if (tb == ClassFeat4_text)
					{
						cb = cf4_cheatCast;
						tb_feat = cf4_FeatId;
						tb_spell = cf4_SpellId;
					}
					else if (tb == ClassFeat5_text)
					{
						cb = cf5_cheatCast;
						tb_feat = cf5_FeatId;
						tb_spell = cf5_SpellId;
					}
					else if (tb == ClassFeat6_text)
					{
						cb = cf6_cheatCast;
						tb_feat = cf6_FeatId;
						tb_spell = cf6_SpellId;
					}
					else if (tb == ClassFeat7_text)
					{
						cb = cf7_cheatCast;
						tb_feat = cf7_FeatId;
						tb_spell = cf7_SpellId;
					}
					else if (tb == ClassFeat8_text)
					{
						cb = cf8_cheatCast;
						tb_feat = cf8_FeatId;
						tb_spell = cf8_SpellId;
					}
					else if (tb == ClassFeat9_text)
					{
						cb = cf9_cheatCast;
						tb_feat = cf9_FeatId;
						tb_spell = cf9_SpellId;
					}
					else if (tb == ClassFeat10_text)
					{
						cb = cf10_cheatCast;
						tb_feat = cf10_FeatId;
						tb_spell = cf10_SpellId;
					}
					else //if (tb == ClassFeat11_text)
					{
						cb = cf11_cheatCast;
						tb_feat = cf11_FeatId;
						tb_spell = cf11_SpellId;
					}

					cb.Checked = (feat & HENCH_FEAT_SPELL_CHEAT_CAST) != 0;

					int val = (feat & HENCH_FEAT_SPELL_MASK_FEAT);
					tb_feat.Text = val.ToString();

					val = (feat & HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb_spell.Text = val.ToString();
				}
			}
//			else
//				bypassCheckedChecker = false; // TODO: conflict w/ CheckClassFlagsCheckers()
		}
	}
}
