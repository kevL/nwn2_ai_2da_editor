using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A bitwise editor for TonyK's Companion and Monster AI 2.3+ CoreAI 2das
	/// in Neverwinter Nights 2.
	/// </summary>
	sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new he());
		}
	}
}
