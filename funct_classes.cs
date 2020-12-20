using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// Functions for the Classes pages.
	/// </summary>
	partial class tabcontrol_Classes
	{
		const int HENCH_FEAT_SPELL_SHIFT_SPELL  = 16;

		const int HENCH_CLASS_BUFF_OTHERS_SHIFT = 10;
		const int HENCH_CLASS_ATTACK_SHIFT      = 12;

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

				bool isFlags = (tb == ClassFlags_text);

				if (isFlags)
				{
//					if (InfoVersionChange_class(ref val)) // TonyAI 2.3+ allow class InfoVersion to be 0.
//					{
//						ClassFlags_text.Text = val.ToString();
//						return; // refire this funct.
//					}

					btn    = ClassFlags_reset;
					tb_hex = ClassFlags_hex;
					tb_bin = ClassFlags_bin;
					bit    = bit_flags;
				}
				else if (tb == ClassFeat1_text)
				{
					btn    = ClassFeat1_reset;
					tb_hex = ClassFeat1_hex;
					tb_bin = ClassFeat1_bin;
					bit    = bit_feat1;
				}
				else if (tb == ClassFeat2_text)
				{
					btn    = ClassFeat2_reset;
					tb_hex = ClassFeat2_hex;
					tb_bin = ClassFeat2_bin;
					bit    = bit_feat2;
				}
				else if (tb == ClassFeat3_text)
				{
					btn    = ClassFeat3_reset;
					tb_hex = ClassFeat3_hex;
					tb_bin = ClassFeat3_bin;
					bit    = bit_feat3;
				}
				else if (tb == ClassFeat4_text)
				{
					btn    = ClassFeat4_reset;
					tb_hex = ClassFeat4_hex;
					tb_bin = ClassFeat4_bin;
					bit    = bit_feat4;
				}
				else if (tb == ClassFeat5_text)
				{
					btn    = ClassFeat5_reset;
					tb_hex = ClassFeat5_hex;
					tb_bin = ClassFeat5_bin;
					bit    = bit_feat5;
				}
				else if (tb == ClassFeat6_text)
				{
					btn    = ClassFeat6_reset;
					tb_hex = ClassFeat6_hex;
					tb_bin = ClassFeat6_bin;
					bit    = bit_feat6;
				}
				else if (tb == ClassFeat7_text)
				{
					btn    = ClassFeat7_reset;
					tb_hex = ClassFeat7_hex;
					tb_bin = ClassFeat7_bin;
					bit    = bit_feat7;
				}
				else if (tb == ClassFeat8_text)
				{
					btn    = ClassFeat8_reset;
					tb_hex = ClassFeat8_hex;
					tb_bin = ClassFeat8_bin;
					bit    = bit_feat8;
				}
				else if (tb == ClassFeat9_text)
				{
					btn    = ClassFeat9_reset;
					tb_hex = ClassFeat9_hex;
					tb_bin = ClassFeat9_bin;
					bit    = bit_feat9;
				}
				else if (tb == ClassFeat10_text)
				{
					btn    = ClassFeat10_reset;
					tb_hex = ClassFeat10_hex;
					tb_bin = ClassFeat10_bin;
					bit    = bit_feat10;
				}
				else //if (tb == ClassFeat11_text)
				{
					btn    = ClassFeat11_reset;
					tb_hex = ClassFeat11_hex;
					tb_bin = ClassFeat11_bin;
					bit    = bit_feat11;
				}

				int differ;

				if (!he.BypassDiffer)
				{
					Class @class = he.Classes[he.Id];

					ClassChanged classchanged;

					if (@class.differ != bit_clear)
					{
						classchanged = he.ClassesChanged[he.Id];
					}
					else
					{
						classchanged = new ClassChanged();

						classchanged.flags  = @class.flags;
						classchanged.feat1  = @class.feat1;
						classchanged.feat2  = @class.feat2;
						classchanged.feat3  = @class.feat3;
						classchanged.feat4  = @class.feat4;
						classchanged.feat5  = @class.feat5;
						classchanged.feat6  = @class.feat6;
						classchanged.feat7  = @class.feat7;
						classchanged.feat8  = @class.feat8;
						classchanged.feat9  = @class.feat9;
						classchanged.feat10 = @class.feat10;
						classchanged.feat11 = @class.feat11;
					}

					if (isFlags)
					{
						classchanged.flags = val;
					}
					else if (tb == ClassFeat1_text)
					{
						classchanged.feat1 = val;
					}
					else if (tb == ClassFeat2_text)
					{
						classchanged.feat2 = val;
					}
					else if (tb == ClassFeat3_text)
					{
						classchanged.feat3 = val;
					}
					else if (tb == ClassFeat4_text)
					{
						classchanged.feat4 = val;
					}
					else if (tb == ClassFeat5_text)
					{
						classchanged.feat5 = val;
					}
					else if (tb == ClassFeat6_text)
					{
						classchanged.feat6 = val;
					}
					else if (tb == ClassFeat7_text)
					{
						classchanged.feat7 = val;
					}
					else if (tb == ClassFeat8_text)
					{
						classchanged.feat8 = val;
					}
					else if (tb == ClassFeat9_text)
					{
						classchanged.feat9 = val;
					}
					else if (tb == ClassFeat10_text)
					{
						classchanged.feat10 = val;
					}
					else //if (tb == ClassFeat11_text)
					{
						classchanged.feat11 = val;
					}

					// check it
					differ = ClassDiffer(@class, classchanged);
					@class.differ = differ;
					he.Classes[he.Id] = @class;

					Color color;
					if (differ != bit_clear)
					{
						he.ClassesChanged[he.Id] = classchanged;
						color = Color.Crimson;
					}
					else
					{
						he.ClassesChanged.Remove(he.Id);

						if (@class.isChanged) color = Color.Blue;
						else                  color = DefaultForeColor;
					}
					_he.SetNodeColor(color);
				}

				he.PrintCurrent(val, tb_hex, tb_bin);

				differ = he.Classes[he.Id].differ;

				if ((differ & bit) != 0)
				{
					btn.ForeColor = Color.Crimson;
				}
				else
					btn.ForeColor = DefaultForeColor;

				if (isFlags)
				{
					CheckClassFlagsCheckers(val);
//					PrintInfoVersion_class(val);
				}
				else
					state_ClassFeats(tb);


				_he.EnableApplys(differ != bit_clear);
			}
			// else TODO: error dialog here.
		}

//		/// <summary>
//		/// Updates InfoVersion for the current class.
//		/// </summary>
//		/// <param name="val"></param>
//		/// <returns></returns>
//		bool InfoVersionChange_class(ref int val)
//		{
//			// ensure that class-flags has a CoreAI version
//			// NOTE that ClassFlags always has a Version (unlike spellinfo)
//			if ((val & hc.HENCH_SPELL_INFO_VERSION_MASK) == 0)
//			{
//				val |= hc.HENCH_SPELL_INFO_VERSION; // insert the default version #
//
//				Class @class = he.Classes[he.Id];
//
//				ClassChanged classchanged;
//
//				if (@class.differ != bit_clear)
//				{
//					classchanged = he.ClassesChanged[he.Id];
//				}
//				else
//				{
//					classchanged = new ClassChanged();
//
//					classchanged.feat1  = @class.feat1;
//					classchanged.feat2  = @class.feat2;
//					classchanged.feat3  = @class.feat3;
//					classchanged.feat4  = @class.feat4;
//					classchanged.feat5  = @class.feat5;
//					classchanged.feat6  = @class.feat6;
//					classchanged.feat7  = @class.feat7;
//					classchanged.feat8  = @class.feat8;
//					classchanged.feat9  = @class.feat9;
//					classchanged.feat10 = @class.feat10;
//					classchanged.feat11 = @class.feat11;
//				}
//
//				classchanged.flags = val;
//
//				// check it
//				int differ = ClassDiffer(@class, classchanged);
//				@class.differ = differ;
//				he.Classes[he.Id] = @class;
//
//				Color color;
//				if (differ != bit_clear)
//				{
//					he.ClassesChanged[he.Id] = classchanged;
//					color = Color.Crimson;
//				}
//				else
//				{
//					he.ClassesChanged.Remove(he.Id);
//
//					if (@class.isChanged) color = Color.Blue;
//					else                  color = DefaultForeColor;
//				}
//				_he.SetNodeColor(color);
//
//				return true;
//			}
//			return false;
//		}

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
			if (he.ClassesChanged.ContainsKey(he.Id))
			{
				int bit, info;
				TextBox tb;

				Class @class = he.Classes[he.Id];

				var btn = sender as Button;
				if (btn == ClassFlags_reset)
				{
					bit  = bit_flags;
					info = @class.flags;
					tb   = ClassFlags_text;
				}
				else if (btn == ClassFeat1_reset)
				{
					bit  = bit_feat1;
					info = @class.feat1;
					tb   = ClassFeat1_text;
				}
				else if (btn == ClassFeat2_reset)
				{
					bit  = bit_feat2;
					info = @class.feat2;
					tb   = ClassFeat2_text;
				}
				else if (btn == ClassFeat3_reset)
				{
					bit  = bit_feat3;
					info = @class.feat3;
					tb   = ClassFeat3_text;
				}
				else if (btn == ClassFeat4_reset)
				{
					bit  = bit_feat4;
					info = @class.feat4;
					tb   = ClassFeat4_text;
				}
				else if (btn == ClassFeat5_reset)
				{
					bit  = bit_feat5;
					info = @class.feat5;
					tb   = ClassFeat5_text;
				}
				else if (btn == ClassFeat6_reset)
				{
					bit  = bit_feat6;
					info = @class.feat6;
					tb   = ClassFeat6_text;
				}
				else if (btn == ClassFeat7_reset)
				{
					bit  = bit_feat7;
					info = @class.feat7;
					tb   = ClassFeat7_text;
				}
				else if (btn == ClassFeat8_reset)
				{
					bit  = bit_feat8;
					info = @class.feat8;
					tb   = ClassFeat8_text;
				}
				else if (btn == ClassFeat9_reset)
				{
					bit  = bit_feat9;
					info = @class.feat9;
					tb   = ClassFeat9_text;
				}
				else if (btn == ClassFeat10_reset)
				{
					bit  = bit_feat10;
					info = @class.feat10;
					tb   = ClassFeat10_text;
				}
				else //if (btn == ClassFeat11_reset)
				{
					bit  = bit_feat11;
					info = @class.feat11;
					tb   = ClassFeat11_text;
				}

				@class.differ &= ~bit;
				he.Classes[he.Id] = @class;

				if (@class.differ == bit_clear)
				{
					he.ClassesChanged.Remove(he.Id);

					Color color;
					if (@class.isChanged) color = Color.Blue;
					else                  color = DefaultForeColor;

					_he.SetNodeColor(color);
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
				int bit;

				var cb = sender as CheckBox;
				if (cb != null)
				{
					if (cb == cf_HasFeatSpells)
					{
						bit = hc.HENCH_CLASS_FEAT_SPELLS;
					}
					else if (cb == cf_isPrestigeClass)
					{
						bit = hc.HENCH_CLASS_PRC_FLAG;
					}
					else if (cb == cf_DcBonus)
					{
						bit = hc.HENCH_CLASS_DC_BONUS_FLAG;
					}
					else //if (cb == cf_L4Required)
					{
						bit = hc.HENCH_CLASS_FOURTH_LEVEL_NEEDED;
					}

					if (cb.Checked)
					{
						flags |= bit;
					}
					else
						flags &= ~bit;
				}
				else
				{
					var rb = sender as RadioButton;
					if (rb == cf_rbDivine)
					{
						flags |= hc.HENCH_CLASS_DIVINE_FLAG;
					}
					else //if (rb == cf_rbArcane)
					{
						flags &= ~hc.HENCH_CLASS_DIVINE_FLAG;
					}
				}

				ClassFlags_text.Text = flags.ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the ClassFlags page - caster ability.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_cf_cbo_CasterAbility(object sender, EventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				flags &= ~hc.HENCH_CLASS_ABILITY_MODIFIER_MASK; // 0x00000300
				int val = cbo_cf_Ability.SelectedIndex << hc.HENCH_CLASS_ABILITY_MODIFIER_SHIFT;
				ClassFlags_text.Text = (flags | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the ClassFlags page - buff others.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_cf_cbo_BuffOthers(object sender, EventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				flags &= ~hc.HENCH_CLASS_BUFF_OTHERS_LOW; // 0x00000c00 - acts as the mask also.
				int val = cbo_cf_BuffOthers.SelectedIndex << HENCH_CLASS_BUFF_OTHERS_SHIFT;
				ClassFlags_text.Text = (flags | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the ClassFlags page - attack.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_cf_cbo_Attack(object sender, EventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				flags &= ~hc.HENCH_CLASS_ATTACK_LOW; // 0x00003000 - acts as the mask also.
				int val = cbo_cf_Attack.SelectedIndex << HENCH_CLASS_ATTACK_SHIFT;
				ClassFlags_text.Text = (flags | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the ClassFlags page - spell progression.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_cf_cbo_SpellProg(object sender, EventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				flags &= ~hc.HENCH_FULL_SPELL_PROGRESSION; // 0x00000007 - acts as the mask also.
				int val = cbo_cf_SpellProg.SelectedIndex;
				ClassFlags_text.Text = (flags | val).ToString();
			}
		}

		/// <summary>
		/// Handles toggling bits by combobox on the ClassFlags page - sneak attack.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void SelectionChangeCommitted_cf_cbo_SneakAttack(object sender, EventArgs e)
		{
			int flags;
			if (Int32.TryParse(ClassFlags_text.Text, out flags))
			{
				flags &= ~hc.HENCH_CLASS_SA_EVERY_FORTH; // 0x0001c000 - acts as the mask also.

				int val;
				switch (cbo_cf_SneakAttack.SelectedIndex)
				{
					default: val = hc.HENCH_CLASS_SA_NONE;                   break;
					case 1:  val = hc.HENCH_CLASS_SA_EVERY_OTHER_ODD;        break;
					case 2:  val = hc.HENCH_CLASS_SA_EVERY_OTHER_EVEN;       break;
					case 3:  val = hc.HENCH_CLASS_SA_EVERY_THIRD_SKIP_FIRST; break;
					case 4:  val = hc.HENCH_CLASS_SA_EVERY_THIRD;            break;
					case 5:  val = hc.HENCH_CLASS_SA_EVERY_THIRD_FROM_TWO;   break;
					case 6:  val = hc.HENCH_CLASS_SA_EVERY_THIRD_FROM_ONE;   break;
					case 7:  val = hc.HENCH_CLASS_SA_EVERY_FORTH;            break;
				}
				ClassFlags_text.Text = (flags | val).ToString();
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
					feat |= hc.HENCH_FEAT_SPELL_CHEAT_CAST;
				}
				else
					feat &= ~hc.HENCH_FEAT_SPELL_CHEAT_CAST;

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
			var tb = sender as TextBox;

			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				if (feat < 0)
				{
					tb.Text = "0"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else if (feat > 65535) // 16 bits
				{
					tb.Text = "65535"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else
				{
					TextBox tb_feat;
					if (tb == cf1_FeatId)
					{
						tb_feat = ClassFeat1_text;
					}
					else if (tb == cf2_FeatId)
					{
						tb_feat = ClassFeat2_text;
					}
					else if (tb == cf3_FeatId)
					{
						tb_feat = ClassFeat3_text;
					}
					else if (tb == cf4_FeatId)
					{
						tb_feat = ClassFeat4_text;
					}
					else if (tb == cf5_FeatId)
					{
						tb_feat = ClassFeat5_text;
					}
					else if (tb == cf6_FeatId)
					{
						tb_feat = ClassFeat6_text;
					}
					else if (tb == cf7_FeatId)
					{
						tb_feat = ClassFeat7_text;
					}
					else if (tb == cf8_FeatId)
					{
						tb_feat = ClassFeat8_text;
					}
					else if (tb == cf9_FeatId)
					{
						tb_feat = ClassFeat9_text;
					}
					else if (tb == cf10_FeatId)
					{
						tb_feat = ClassFeat10_text;
					}
					else //if (tb_feat == cf11_FeatId)
					{
						tb_feat = ClassFeat11_text;
					}

					int feaT = Int32.Parse(tb_feat.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_FEAT;

					tb_feat.Text = (feaT | feat).ToString();
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
			var tb = sender as TextBox;

			int spell;
			if (Int32.TryParse(tb.Text, out spell))
			{
				if (spell < 0)
				{
					tb.Text = "0"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else if (spell > 16383) // 14 bits
				{
					tb.Text = "16383"; // recurse this funct.
					tb.SelectionStart = tb.Text.Length;
				}
				else
				{
					TextBox tb_feat;
					if (tb == cf1_SpellId)
					{
						tb_feat = ClassFeat1_text;
					}
					else if (tb == cf2_SpellId)
					{
						tb_feat = ClassFeat2_text;
					}
					else if (tb == cf3_SpellId)
					{
						tb_feat = ClassFeat3_text;
					}
					else if (tb == cf4_SpellId)
					{
						tb_feat = ClassFeat4_text;
					}
					else if (tb == cf5_SpellId)
					{
						tb_feat = ClassFeat5_text;
					}
					else if (tb == cf6_SpellId)
					{
						tb_feat = ClassFeat6_text;
					}
					else if (tb == cf7_SpellId)
					{
						tb_feat = ClassFeat7_text;
					}
					else if (tb == cf8_SpellId)
					{
						tb_feat = ClassFeat8_text;
					}
					else if (tb == cf9_SpellId)
					{
						tb_feat = ClassFeat9_text;
					}
					else if (tb == cf10_SpellId)
					{
						tb_feat = ClassFeat10_text;
					}
					else //if (tb_spell == cf11_SpellId)
					{
						tb_feat = ClassFeat11_text;
					}

					int feaT = Int32.Parse(tb_feat.Text);
					feaT &= ~hc.HENCH_FEAT_SPELL_MASK_SPELL;

					spell <<= HENCH_FEAT_SPELL_SHIFT_SPELL;
					tb_feat.Text = (feaT | spell).ToString();
				}
			}
		}

		internal override void SetSpellLabelTexts()
		{
			Class @class = he.Classes[he.Id];

			int id;
			id = (@class.feat1 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf1_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf1_SpellLabel.Text = String.Empty;

			id = (@class.feat2 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf2_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf2_SpellLabel.Text = String.Empty;

			id = (@class.feat3 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf3_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf3_SpellLabel.Text = String.Empty;

			id = (@class.feat4 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf4_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf4_SpellLabel.Text = String.Empty;

			id = (@class.feat5 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf5_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf5_SpellLabel.Text = String.Empty;

			id = (@class.feat6 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf6_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf6_SpellLabel.Text = String.Empty;

			id = (@class.feat7 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf7_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf7_SpellLabel.Text = String.Empty;

			id = (@class.feat8 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf8_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf8_SpellLabel.Text = String.Empty;

			id = (@class.feat9 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf9_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf9_SpellLabel.Text = String.Empty;

			id = (@class.feat10 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf10_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf10_SpellLabel.Text = String.Empty;

			id = (@class.feat11 & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
			if (id < he.spellLabels.Count)
			{
				cf11_SpellLabel.Text = he.spellLabels[id];
			}
			else
				cf11_SpellLabel.Text = String.Empty;
		}

		internal override void ClearSpellLabelTexts()
		{
			cf1_SpellLabel .Text =
			cf2_SpellLabel .Text =
			cf3_SpellLabel .Text =
			cf4_SpellLabel .Text =
			cf5_SpellLabel .Text =
			cf6_SpellLabel .Text =
			cf7_SpellLabel .Text =
			cf8_SpellLabel .Text =
			cf9_SpellLabel .Text =
			cf10_SpellLabel.Text =
			cf11_SpellLabel.Text = String.Empty;
		}

		internal override void SetFeatLabelTexts()
		{
			Class @class = he.Classes[he.Id];

			int id;
			id = (@class.feat1 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf1_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf1_FeatLabel.Text = String.Empty;

			id = (@class.feat2 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf2_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf2_FeatLabel.Text = String.Empty;

			id = (@class.feat3 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf3_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf3_FeatLabel.Text = String.Empty;

			id = (@class.feat4 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf4_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf4_FeatLabel.Text = String.Empty;

			id = (@class.feat5 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf5_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf5_FeatLabel.Text = String.Empty;

			id = (@class.feat6 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf6_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf6_FeatLabel.Text = String.Empty;

			id = (@class.feat7 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf7_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf7_FeatLabel.Text = String.Empty;

			id = (@class.feat8 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf8_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf8_FeatLabel.Text = String.Empty;

			id = (@class.feat9 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf9_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf9_FeatLabel.Text = String.Empty;

			id = (@class.feat10 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf10_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf10_FeatLabel.Text = String.Empty;

			id = (@class.feat11 & hc.HENCH_FEAT_SPELL_MASK_FEAT);
			if (id < he.featLabels.Count)
			{
				cf11_FeatLabel.Text = he.featLabels[id];
			}
			else
				cf11_FeatLabel.Text = String.Empty;
		}

		internal override void ClearFeatLabelTexts()
		{
			cf1_FeatLabel .Text =
			cf2_FeatLabel .Text =
			cf3_FeatLabel .Text =
			cf4_FeatLabel .Text =
			cf5_FeatLabel .Text =
			cf6_FeatLabel .Text =
			cf7_FeatLabel .Text =
			cf8_FeatLabel .Text =
			cf9_FeatLabel .Text =
			cf10_FeatLabel.Text =
			cf11_FeatLabel.Text = String.Empty;
		}


//		/// <summary>
//		/// Prints the info-version of the currently selected class ID.
//		/// </summary>
//		/// <param name="flags"></param>
//		void PrintInfoVersion_class(int flags)
//		{
//			flags &= hc.HENCH_SPELL_INFO_VERSION_MASK;
//			flags >>= he.HENCH_SPELL_INFO_VERSION_SHIFT;
//
//			cf_infoversion.Text = flags.ToString();
//		}


		/// <summary>
		/// Sets the checkers on the ClassFlags page to reflect the current
		/// flags value.
		/// </summary>
		void CheckClassFlagsCheckers(int flags)
		{
			cf_HasFeatSpells  .Checked = (flags & hc.HENCH_CLASS_FEAT_SPELLS)         != 0;
			cf_isPrestigeClass.Checked = (flags & hc.HENCH_CLASS_PRC_FLAG)            != 0;
			cf_DcBonus        .Checked = (flags & hc.HENCH_CLASS_DC_BONUS_FLAG)       != 0;
			cf_L4Required     .Checked = (flags & hc.HENCH_CLASS_FOURTH_LEVEL_NEEDED) != 0;

			bool divine = (flags & hc.HENCH_CLASS_DIVINE_FLAG) != 0;
			cf_rbDivine.Checked =  divine;
			cf_rbArcane.Checked = !divine;

// Caster Ability dropdown-list
			int val = flags;
			val &= hc.HENCH_CLASS_ABILITY_MODIFIER_MASK; // 0x00000300
			val >>= hc.HENCH_CLASS_ABILITY_MODIFIER_SHIFT;
			if (val >= cbo_cf_Ability.Items.Count)
			{
				val = -1;
				cbo_cf_Ability.ForeColor = Color.Crimson;
			}
			else
				cbo_cf_Ability.ForeColor = DefaultForeColor;

			cbo_cf_Ability.SelectedIndex = val;

// Buff Others dropdown-list
			val = flags;
			val &= hc.HENCH_CLASS_BUFF_OTHERS_LOW; // 0x00000c00 - acts as the mask also.
			val >>= HENCH_CLASS_BUFF_OTHERS_SHIFT;
			if (val >= cbo_cf_BuffOthers.Items.Count)
			{
				val = -1;
				cbo_cf_BuffOthers.ForeColor = Color.Crimson;
			}
			else
				cbo_cf_BuffOthers.ForeColor = DefaultForeColor;

			cbo_cf_BuffOthers.SelectedIndex = val;

// Attack dropdown-list
			val = flags;
			val &= hc.HENCH_CLASS_ATTACK_LOW; // 0x00003000 - acts as the mask also.
			val >>= HENCH_CLASS_ATTACK_SHIFT;
			if (val >= cbo_cf_Attack.Items.Count)
			{
				val = -1;
				cbo_cf_Attack.ForeColor = Color.Crimson;
			}
			else
				cbo_cf_Attack.ForeColor = DefaultForeColor;

			cbo_cf_Attack.SelectedIndex = val;

// Spell Progression dropdown-list
			val = flags;
			val &= hc.HENCH_FULL_SPELL_PROGRESSION; // 0x00000007 - acts as the mask also.
			if (val >= cbo_cf_SpellProg.Items.Count)
			{
				val = -1;
				cbo_cf_SpellProg.ForeColor = Color.Crimson;
			}
			else
				cbo_cf_SpellProg.ForeColor = DefaultForeColor;

			cbo_cf_SpellProg.SelectedIndex = val;

// Sneak Attack dropdown-list
			cbo_cf_SneakAttack.ForeColor = DefaultForeColor;

			switch (flags & hc.HENCH_CLASS_SA_EVERY_FORTH) // 0x0001c000 - acts as flag also.
			{
				case hc.HENCH_CLASS_SA_NONE:                   val = 0; break; // 0x00000000
				case hc.HENCH_CLASS_SA_EVERY_OTHER_ODD:        val = 1; break; // 0x00004000
				case hc.HENCH_CLASS_SA_EVERY_OTHER_EVEN:       val = 2; break; // 0x00008000
				case hc.HENCH_CLASS_SA_EVERY_THIRD_SKIP_FIRST: val = 3; break; // 0x0000c000
				case hc.HENCH_CLASS_SA_EVERY_THIRD:            val = 4; break; // 0x00010000
				case hc.HENCH_CLASS_SA_EVERY_THIRD_FROM_TWO:   val = 5; break; // 0x00014000
				case hc.HENCH_CLASS_SA_EVERY_THIRD_FROM_ONE:   val = 6; break; // 0x00018000
				case hc.HENCH_CLASS_SA_EVERY_FORTH:            val = 7; break; // 0x0001c000

				default:
					val = -1;
					cbo_cf_SneakAttack.ForeColor = Color.Crimson;
					break;
			}
			cbo_cf_SneakAttack.SelectedIndex = val;
		}

		/// <summary>
		/// Sets the checkers on the ClassFeats pages to reflect the current
		/// feat value.
		/// </summary>
		/// <param name="tb"></param>
		void state_ClassFeats(Control tb)
		{
			int feat;
			if (Int32.TryParse(tb.Text, out feat))
			{
				CheckBox cb;
				TextBox tb_feat, tb_spell;
				Label lbl_feat, lbl_spell;

				if (tb == ClassFeat1_text)
				{
					cb        = cf1_cheatCast;
					tb_feat   = cf1_FeatId;
					tb_spell  = cf1_SpellId;
					lbl_feat  = cf1_FeatLabel;
					lbl_spell = cf1_SpellLabel;
				}
				else if (tb == ClassFeat2_text)
				{
					cb        = cf2_cheatCast;
					tb_feat   = cf2_FeatId;
					tb_spell  = cf2_SpellId;
					lbl_feat  = cf2_FeatLabel;
					lbl_spell = cf2_SpellLabel;
				}
				else if (tb == ClassFeat3_text)
				{
					cb        = cf3_cheatCast;
					tb_feat   = cf3_FeatId;
					tb_spell  = cf3_SpellId;
					lbl_feat  = cf3_FeatLabel;
					lbl_spell = cf3_SpellLabel;
				}
				else if (tb == ClassFeat4_text)
				{
					cb        = cf4_cheatCast;
					tb_feat   = cf4_FeatId;
					tb_spell  = cf4_SpellId;
					lbl_feat  = cf4_FeatLabel;
					lbl_spell = cf4_SpellLabel;
				}
				else if (tb == ClassFeat5_text)
				{
					cb        = cf5_cheatCast;
					tb_feat   = cf5_FeatId;
					tb_spell  = cf5_SpellId;
					lbl_feat  = cf5_FeatLabel;
					lbl_spell = cf5_SpellLabel;
				}
				else if (tb == ClassFeat6_text)
				{
					cb        = cf6_cheatCast;
					tb_feat   = cf6_FeatId;
					tb_spell  = cf6_SpellId;
					lbl_feat  = cf6_FeatLabel;
					lbl_spell = cf6_SpellLabel;
				}
				else if (tb == ClassFeat7_text)
				{
					cb        = cf7_cheatCast;
					tb_feat   = cf7_FeatId;
					tb_spell  = cf7_SpellId;
					lbl_feat  = cf7_FeatLabel;
					lbl_spell = cf7_SpellLabel;
				}
				else if (tb == ClassFeat8_text)
				{
					cb        = cf8_cheatCast;
					tb_feat   = cf8_FeatId;
					tb_spell  = cf8_SpellId;
					lbl_feat  = cf8_FeatLabel;
					lbl_spell = cf8_SpellLabel;
				}
				else if (tb == ClassFeat9_text)
				{
					cb        = cf9_cheatCast;
					tb_feat   = cf9_FeatId;
					tb_spell  = cf9_SpellId;
					lbl_feat  = cf9_FeatLabel;
					lbl_spell = cf9_SpellLabel;
				}
				else if (tb == ClassFeat10_text)
				{
					cb        = cf10_cheatCast;
					tb_feat   = cf10_FeatId;
					tb_spell  = cf10_SpellId;
					lbl_feat  = cf10_FeatLabel;
					lbl_spell = cf10_SpellLabel;
				}
				else //if (tb == ClassFeat11_text)
				{
					cb        = cf11_cheatCast;
					tb_feat   = cf11_FeatId;
					tb_spell  = cf11_SpellId;
					lbl_feat  = cf11_FeatLabel;
					lbl_spell = cf11_SpellLabel;
				}

				cb.Checked = (feat & hc.HENCH_FEAT_SPELL_CHEAT_CAST) != 0;

				int val = (feat & hc.HENCH_FEAT_SPELL_MASK_FEAT);
				tb_feat.Text = val.ToString();

				if (he.featLabels.Count != 0
					&& val < he.featLabels.Count)
				{
					lbl_feat.Text = he.featLabels[val];
				}

				val = (feat & hc.HENCH_FEAT_SPELL_MASK_SPELL) >> HENCH_FEAT_SPELL_SHIFT_SPELL;
				tb_spell.Text = val.ToString();

				if (he.spellLabels.Count != 0
					&& val < he.spellLabels.Count)
				{
					lbl_spell.Text = he.spellLabels[val];
				}
			}
		}
	}
}
