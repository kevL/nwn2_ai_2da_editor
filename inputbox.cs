using System;
using System.Drawing;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A generic input-box. Based on:
	/// https://stackoverflow.com/questions/97097/what-is-the-c-sharp-version-of-vb-nets-inputdialog#answer-17546909
	/// </summary>
	partial class MainForm
	{
		static DialogResult ShowInputDialog(string title,
											ref string input,
											string textOk,
											string textThird,
											string textInfo)
		{
			var ib = new Form();

			var size = new Size(345, 125);

			ib.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			ib.StartPosition = FormStartPosition.CenterParent;
			ib.ClientSize = size;
			ib.Text = title;
			ib.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)0);

			const int pad  = 5;

			var infoText = new Label();
			infoText.Size = new Size(size.Width - pad * 2, 32);
			infoText.Location = new Point(pad, pad);
			infoText.Font = new Font("Courier New", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			infoText.ForeColor = Color.Crimson;
			infoText.TextAlign = ContentAlignment.TopCenter;
			infoText.Text = textInfo;
			ib.Controls.Add(infoText);

			var textBox = new TextBox();
			textBox.Size = new Size(size.Width - pad * 2, 20);
			textBox.Location = new Point(pad, infoText.Height + pad);
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
			cancelButton.Location = new Point(size.Width - wBtn - pad * 2, yBtn);
			ib.Controls.Add(cancelButton);

			var okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Size = new Size(wBtn, hBtn);
			okButton.Text = textOk;
			okButton.Location = new Point(size.Width / 2 - wBtn / 2, yBtn);
			ib.Controls.Add(okButton);

			if (!String.IsNullOrEmpty(textThird))
			{
				var thirdButton = new Button();
				thirdButton.DialogResult = DialogResult.Retry;
				thirdButton.Name = "retryButton";
				thirdButton.Size = new Size(wBtn, hBtn);
				thirdButton.Text = textThird;
				thirdButton.Location = new Point(pad * 2, yBtn);
				ib.Controls.Add(thirdButton);
			}

			ib.AcceptButton = okButton;		// [Enter]
			ib.CancelButton = cancelButton;	// [Esc]

			DialogResult result = ib.ShowDialog();
			input = textBox.Text;
			return result;
		}
	}
}
