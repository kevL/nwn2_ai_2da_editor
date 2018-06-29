using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// An inputbox with which to set CoreAI version information.
	/// </summary>
	partial class MainForm
	{
		static DialogResult InfoVersion(Type2da type,
										ref string input)
		{
			string title;
			string text_1;
			string text_2;
			string text_3;

			switch (type)
			{
				default:
//				case Type2da.TYPE_SPELLS:
					title = "  Spell Info version";
					text_1 = "current spell only";
					text_2 = "any changed spells";
					text_3 = "all spells in 2da";
					break;

				case Type2da.TYPE_RACIAL:
					title = "  Racial Info version";
					text_1 = "current race only";
					text_2 = "any changed race";
					text_3 = "all races in 2da";
					break;

				case Type2da.TYPE_CLASSES:
					title = "  Class Info version";
					text_1 = "current class only";
					text_2 = "any changed class";
					text_3 = "all races in 2da";
					break;
			}


			var ib = new Form();

			var size = new Size(350, 125);

			ib.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			ib.StartPosition = FormStartPosition.CenterParent;
			ib.ClientSize = size;
			ib.Text = title;
			ib.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);


			const int pad  = 5;

			var infoText = new Label();
			infoText.Size = new Size(size.Width - pad * 2, 20);
			infoText.Location = new Point(pad, pad + 2);
			infoText.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			infoText.ForeColor = Color.Crimson;
			infoText.TextAlign = ContentAlignment.TopCenter;
			infoText.Text = "Do NOT change this.";
			ib.Controls.Add(infoText);

			var textBox = new TextBox();
			textBox.Size = new Size(size.Width - pad * 10, 20);
			textBox.Location = new Point(pad * 5, 30);
			textBox.Text = input;
			ib.Controls.Add(textBox);

			const int wBtn = 80;
			const int hBtn = 55;
			int yBtn = size.Height - hBtn - pad;


			var cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(wBtn, hBtn);
			cancelButton.Text = "&Cancel";
			cancelButton.Location = new Point((size.Width - pad) * 4 / 4 - wBtn, yBtn);
			ib.Controls.Add(cancelButton);

			var okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Size = new Size(wBtn, hBtn);
			okButton.Text = text_1;
			okButton.Location = new Point((size.Width - pad) * 3 / 4 - wBtn, yBtn);
			ib.Controls.Add(okButton);

			var anyButton = new Button();
			anyButton.DialogResult = DialogResult.Yes;
			anyButton.Name = "anyButton";
			anyButton.Size = new Size(wBtn, hBtn);
			anyButton.Text = text_2;
			anyButton.Location = new Point((size.Width - pad) * 2 / 4 - wBtn, yBtn);
			ib.Controls.Add(anyButton);

			var allButton = new Button();
			allButton.DialogResult = DialogResult.Retry;
			allButton.Name = "allButton";
			allButton.Size = new Size(wBtn, hBtn);
			allButton.Text = text_3;
			allButton.Location = new Point((size.Width - pad) * 1 / 4 - wBtn, yBtn);
			ib.Controls.Add(allButton);


			ib.AcceptButton = okButton;		// [Enter]
			ib.CancelButton = cancelButton;	// [Esc]

			DialogResult result = ib.ShowDialog();
			input = textBox.Text;
			return result;
		}
	}
}
