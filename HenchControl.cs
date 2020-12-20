using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A parent-class for 'tabcontrol_Spells', 'tabcontrol_Racial', and
	/// 'tabcontrol_Classes'. This allows the 'HenchControl' variable to call
	/// these functions (incl/ stuff in 'UserControl') without the need for
	/// explicit casts.
	/// @note Do not turn this into an abstract class since your designer will
	/// fuck up. thanks.
	/// </summary>
//	abstract class HenchControl
	class HenchControl
		: UserControl
	{
//		internal abstract void SelectId();
		internal virtual void SelectId(){}

//		internal abstract string GetMasterText();
//		internal abstract void   SetMasterText(string text);
		internal virtual string GetMasterText(){ return String.Empty; }
		internal virtual void   SetMasterText(string text){}

//		internal abstract void SelectResetButton();
//		internal abstract void SetResetColor(Color color);
		internal virtual void SelectResetButton(){}
		internal virtual void SetResetColor(Color color){}

		internal virtual void SetDefaultGroupColors(){} // relevant only to 'tabcontrol_Spells'

//		internal abstract void SetSpellLabelTexts();
//		internal abstract void ClearSpellLabelTexts();
		internal virtual void SetSpellLabelTexts(){}
		internal virtual void ClearSpellLabelTexts(){}

		internal virtual void SetFeatLabelTexts(){} // relevant only to 'tabcontrol_Racial' and 'tabcontrol_Classes'
		internal virtual void ClearFeatLabelTexts(){} // relevant only to 'tabcontrol_Racial' and 'tabcontrol_Classes'
	}
}
