using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A parent-class inherited by <c><see cref="control_Spells"/></c>,
	/// <c><see cref="control_Racial"/></c>, and
	/// <c><see cref="control_Classes"/></c>. This allows the
	/// <c><see cref="he.HenchControl">he.HenchControl</see></c> variable to
	/// call these functions (incl/ the stuff in
	/// <c><see cref="UserControl"/></c>) without the need for explicit casts.
	/// </summary>
	/// <remarks>Do not turn this into an <c>abstract class</c> since the
	/// <c>control_*</c> designers will fuck up. thanks.
	/// 
	/// 
	/// Do not turn this into an <c>interface</c> either since
	/// <c>control_Spells</c> does not override the last two functs. (read:
	/// it doesn't need to, so don't. your wel)</remarks>
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

		// these two are relevant only to 'control_Racial' and 'control_Classes'
		internal virtual void SetFeatLabelTexts(){}
		internal virtual void ClearFeatLabelTexts(){}
	}
}
