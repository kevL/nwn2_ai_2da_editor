using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	/// <summary>
	/// A generic dialog to display info or request confirmation.
	/// </summary>
	sealed class infobox
		: Form
	{
		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="info"></param>
		/// <param name="textokay"></param>
		/// <param name="textcancel"></param>
		/// <param name="textretry"></param>
		internal infobox(
				string title,
				string info,
				string textokay = "okay",
				string textcancel = null,
				string textretry = null)
		{
			InitializeComponent();

			Text = title;

			la_info.Text = info;

			bu_accept.Text = textokay;

			if (textcancel != null)
			{
				bu_cancel.Visible = true;
				bu_cancel.Text = textcancel;
			}

			if (textretry != null)
			{
				bu_retry.Visible = true;
				bu_retry.Text = textretry;
			}

			bu_accept.Select();
		}
		#endregion cTor


		#region Events (override)
		/// <summary>
		/// Requires 'KeyPreview' true.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Enter:
					if (   !bu_accept.Focused
						&& !bu_cancel.Focused
						&& !bu_retry .Focused)
					{
						// else let .net handle the input on those buttons
						DialogResult = DialogResult.OK;
					}
					break;

				case Keys.Escape:
					DialogResult = DialogResult.Cancel;
					break;
			}
		}
		#endregion Events (override)


		#region Events
		/// <summary>
		/// Closes this infobox and returns 'DialogResult.OK'.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void click_Okay(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		/// <summary>
		/// Closes this infobox and returns 'DialogResult.Cancel'.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void click_Cancel(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Closes this infobox and returns 'DialogResult.Retry'.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void click_Retry(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Retry;
		}
		#endregion Events


		#region Designer
		Label la_info;
		Button bu_accept;
		Button bu_cancel;
		Button bu_retry;

		void InitializeComponent()
		{
			this.la_info = new System.Windows.Forms.Label();
			this.bu_accept = new System.Windows.Forms.Button();
			this.bu_cancel = new System.Windows.Forms.Button();
			this.bu_retry = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// la_info
			// 
			this.la_info.Dock = System.Windows.Forms.DockStyle.Top;
			this.la_info.Location = new System.Drawing.Point(0, 0);
			this.la_info.Margin = new System.Windows.Forms.Padding(0);
			this.la_info.Name = "la_info";
			this.la_info.Padding = new System.Windows.Forms.Padding(6, 8, 4, 3);
			this.la_info.Size = new System.Drawing.Size(384, 125);
			this.la_info.TabIndex = 0;
			this.la_info.Text = "la_info";
			// 
			// bu_accept
			// 
			this.bu_accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bu_accept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bu_accept.Location = new System.Drawing.Point(271, 128);
			this.bu_accept.Margin = new System.Windows.Forms.Padding(0);
			this.bu_accept.Name = "bu_accept";
			this.bu_accept.Size = new System.Drawing.Size(100, 25);
			this.bu_accept.TabIndex = 3;
			this.bu_accept.Text = "okay";
			this.bu_accept.UseVisualStyleBackColor = true;
			this.bu_accept.Click += new System.EventHandler(this.click_Okay);
			// 
			// bu_cancel
			// 
			this.bu_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bu_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bu_cancel.Location = new System.Drawing.Point(13, 128);
			this.bu_cancel.Margin = new System.Windows.Forms.Padding(0);
			this.bu_cancel.Name = "bu_cancel";
			this.bu_cancel.Size = new System.Drawing.Size(100, 25);
			this.bu_cancel.TabIndex = 1;
			this.bu_cancel.Text = "cancel";
			this.bu_cancel.UseVisualStyleBackColor = true;
			this.bu_cancel.Visible = false;
			this.bu_cancel.Click += new System.EventHandler(this.click_Cancel);
			// 
			// bu_retry
			// 
			this.bu_retry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.bu_retry.DialogResult = System.Windows.Forms.DialogResult.Retry;
			this.bu_retry.Location = new System.Drawing.Point(142, 128);
			this.bu_retry.Margin = new System.Windows.Forms.Padding(0);
			this.bu_retry.Name = "bu_retry";
			this.bu_retry.Size = new System.Drawing.Size(100, 25);
			this.bu_retry.TabIndex = 2;
			this.bu_retry.Text = "retry";
			this.bu_retry.UseVisualStyleBackColor = true;
			this.bu_retry.Visible = false;
			this.bu_retry.Click += new System.EventHandler(this.click_Retry);
			// 
			// infobox
			// 
			this.ClientSize = new System.Drawing.Size(384, 156);
			this.Controls.Add(this.bu_retry);
			this.Controls.Add(this.bu_cancel);
			this.Controls.Add(this.bu_accept);
			this.Controls.Add(this.la_info);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "infobox";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
