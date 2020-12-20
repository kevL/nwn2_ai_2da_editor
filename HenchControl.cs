using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	abstract class HenchControl
		: UserControl
	{
		internal abstract void SelectId();

		internal abstract string GetMasterText();
		internal abstract void   SetMasterText(string text);

		internal abstract void SelectResetButton();
		internal abstract void SetResetColor(Color color);

		internal virtual void SetDefaultGroupColors() // relevant only to 'tabcontrol_Spells'
		{}

		internal abstract void SetSpellLabelTexts();
		internal abstract void ClearSpellLabelTexts();
	}
}
