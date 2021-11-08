using System;
using System.IO;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	// Functions for the Recent menu.
	partial class he
	{
		/// <summary>
		/// Loads up to 8 recents from a textfile in the app-dir.
		/// </summary>
		void recent_init()
		{
			string pfe = Path.Combine(Application.StartupPath, RF_CFG);
			if (File.Exists(pfe))
			{
				ToolStripItemCollection recents = it_Recent.DropDownItems;

				string[] lines = File.ReadAllLines(pfe);
				foreach (string line in lines)
				{
					if (File.Exists(line))
					{
						var it = new ToolStripMenuItem(line);
						it.Click += Click_recent;
						recents.Add(it);

						if (recents.Count == 8) // up to 8 recents
							break;
					}
				}
			}
		}

		/// <summary>
		/// Adds a recent at the top of the dropdown collection. Deletes an old
		/// one if found. Limits count to 8 recents.
		/// </summary>
		void recent_add()
		{
			ToolStripItemCollection recents = it_Recent.DropDownItems;
			ToolStripItem it;

			bool found = false;

			for (int i = 0; i != recents.Count; ++i)
			{
				if ((it = recents[i]).Text == _pfe)
				{
					found = true;

					if (i != 0)
					{
						recents.Remove(it);
						recents.Insert(0, it);
					}
					break;
				}
			}

			if (!found)
			{
				it = new ToolStripMenuItem(_pfe);
				it.Click += Click_recent;
				recents.Insert(0, it);

				if (recents.Count > 8) // up to 8 recents
					recents.Remove(recents[recents.Count - 1]);
			}
		}

		/// <summary>
		/// Writes recents to a file 'recent.cfg' in the app-dir.
		/// </summary>
		/// <remarks>Recents will be tracked only if a file 'recent.cfg' already
		/// exists in the app-dir.</remarks>
		void recent_write()
		{
			string pfe = Path.Combine(Application.StartupPath, RF_CFG);
			if (File.Exists(pfe))
			{
				int i = -1;
				var recents = new string[it_Recent.DropDownItems.Count];
				foreach (ToolStripMenuItem recent in it_Recent.DropDownItems)
					recents[++i] = recent.Text;

				try
				{
					File.WriteAllLines(pfe, recents);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message); // is that worthwhile. Probly not.
				}
			}
		}
	}
}
