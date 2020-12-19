using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	sealed class infobox
		: Form
	{
		#region cTor
		internal infobox(string title, string info, bool showCancel)
		{
			InitializeComponent();

			Text = title;

			la_info.Text = info;

			bu_cancel.Visible = showCancel;

			bu_accept.Select();
		}
		#endregion cTor


		#region Events
		void click_Accept(object sender, EventArgs e)
		{
		}

		void click_Cancel(object sender, EventArgs e)
		{
		}
		#endregion Events


		#region Designer
		Label la_info;
		Button bu_accept;
		Button bu_cancel;

		void InitializeComponent()
		{
			this.la_info = new System.Windows.Forms.Label();
			this.bu_accept = new System.Windows.Forms.Button();
			this.bu_cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// la_info
			// 
			this.la_info.Dock = System.Windows.Forms.DockStyle.Top;
			this.la_info.Location = new System.Drawing.Point(0, 0);
			this.la_info.Margin = new System.Windows.Forms.Padding(0);
			this.la_info.Name = "la_info";
			this.la_info.Padding = new System.Windows.Forms.Padding(6, 8, 4, 3);
			this.la_info.Size = new System.Drawing.Size(394, 135);
			this.la_info.TabIndex = 0;
			this.la_info.Text = "la_info";
			// 
			// bu_accept
			// 
			this.bu_accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bu_accept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bu_accept.Location = new System.Drawing.Point(312, 142);
			this.bu_accept.Margin = new System.Windows.Forms.Padding(0);
			this.bu_accept.Name = "bu_accept";
			this.bu_accept.Size = new System.Drawing.Size(75, 25);
			this.bu_accept.TabIndex = 2;
			this.bu_accept.Text = "Yes";
			this.bu_accept.UseVisualStyleBackColor = true;
			this.bu_accept.Click += new System.EventHandler(this.click_Accept);
			// 
			// bu_cancel
			// 
			this.bu_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.bu_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.bu_cancel.Location = new System.Drawing.Point(232, 142);
			this.bu_cancel.Margin = new System.Windows.Forms.Padding(0);
			this.bu_cancel.Name = "bu_cancel";
			this.bu_cancel.Size = new System.Drawing.Size(75, 25);
			this.bu_cancel.TabIndex = 1;
			this.bu_cancel.Text = "no";
			this.bu_cancel.UseVisualStyleBackColor = true;
			this.bu_cancel.Click += new System.EventHandler(this.click_Cancel);
			// 
			// infobox
			// 
			this.AcceptButton = this.bu_accept;
			this.CancelButton = this.bu_cancel;
			this.ClientSize = new System.Drawing.Size(394, 171);
			this.Controls.Add(this.bu_cancel);
			this.Controls.Add(this.bu_accept);
			this.Controls.Add(this.la_info);
			this.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "infobox";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
