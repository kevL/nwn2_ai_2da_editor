using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
/*	partial class MainForm
	{
		/// <summary>
		/// An inputbox.
		/// </summary>
		/// <param name="info">info text - keep it short</param>
		/// <param name="str">reference to the string input/output</param>
		/// <returns>dialog result</returns>
		static DialogResult InputBox(string info, ref string str)
		{
			var ib = new Form();

			ib.ClientSize = new Size(300, 100);
			ib.Text = "  InputBox";
			ib.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);
			ib.StartPosition = FormStartPosition.CenterParent;
			ib.FormBorderStyle = FormBorderStyle.FixedToolWindow;


			var infoText = new Label();
			infoText.Size = new Size(ib.ClientSize.Width - 20, 20);
			infoText.Location = new Point(10, 5);
			infoText.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			infoText.TextAlign = ContentAlignment.MiddleCenter;
			infoText.Text = info;
			ib.Controls.Add(infoText);

			var textBox = new TextBox();
			textBox.Size = new Size(ib.ClientSize.Width - 20, 20);
			textBox.Location = new Point(10, 30);
			textBox.Text = str;
			textBox.TextChanged += TextChanged_ib;
			ib.Controls.Add(textBox);


			var cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Text = "Cancel";
			cancelButton.Size = new Size(75, 25);
			cancelButton.Location = new Point(ib.ClientSize.Width / 2 + 10, 60);
			ib.Controls.Add(cancelButton);

			var okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Text = "Okay";
			okButton.Size = new Size(75, 25);
			okButton.Location = new Point(ib.ClientSize.Width / 2 - 85, 60);
			ib.Controls.Add(okButton);

			ib.AcceptButton = okButton;		// [Enter]
			ib.CancelButton = cancelButton;	// [Esc]

			DialogResult dr = ib.ShowDialog();

			str = textBox.Text;
			return dr;
		}

		/// <summary>
		/// Handles the textbox - text cannot contain " " or """ or "'".
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void TextChanged_ib(object sender, EventArgs e)
		{
			var tb = sender as TextBox;

			string text = tb.Text;
			if (text.Contains(" ") || text.Contains("\"") || text.Contains("\'"))
			{
				text = text.Replace(' ',  '_');
				text = text.Replace('"',  '_');
				text = text.Replace('\'', '_');

				tb.Text = text;
				tb.SelectionStart = tb.Text.Length;
			}

//			MessageBox.Show("Label cannot have spaces or quotes.",
//							"  are you sure you know what you're doing",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
		}
	} */
}
