using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A parent-class inherited by <see cref="tabcontrol_Spells"/>,
	/// <see cref="tabcontrol_Racial"/>, and <see cref="tabcontrol_Classes"/>.
	/// This allows the 'he.HenchControl' variable to call these functions
	/// (incl/ the stuff in <see cref="UserControl"/>) without the need for
	/// explicit casts.
	/// @note Do not turn this into an abstract class since the 'tabcontrol_*'
	/// designers will fuck up. thanks.
	/// @note Do not turn this into an interface either since 'tabcontrol_Spells'
	/// does not override the last two functs. (read: it doesn't need to, so
	/// don't. your wel)
	/// </summary>
	class HenchControl
		: UserControl
	{
		internal virtual void SelectId(){}

		internal virtual string GetMasterText(){ return String.Empty; }
		internal virtual void   SetMasterText(string text){}

		internal virtual void SelectResetButton(){}
		internal virtual void SetResetColor(Color color){}

		internal virtual void SetSpellLabelTexts(){}
		internal virtual void ClearSpellLabelTexts(){}

		// these two are relevant only to 'tabcontrol_Racial' and 'tabcontrol_Classes'
		internal virtual void SetFeatLabelTexts(){}
		internal virtual void ClearFeatLabelTexts(){}
	}
}
