using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	partial class Scripter
	{
		#region Designer
		SplitContainer splitContainer;
		TextBox tb_Fields;
		TextboxMasterSyncher tb_Script;
		TextBox tb_nos;

		/// <summary>
		/// 
		/// </summary>
		void InitializeComponent()
		{
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.tb_Fields = new System.Windows.Forms.TextBox();
			this.tb_Script = new nwn2_ai_2da_editor.TextboxMasterSyncher();
			this.tb_nos = new System.Windows.Forms.TextBox();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.tb_Fields);
			this.splitContainer.Panel1MinSize = 0;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.tb_Script);
			this.splitContainer.Panel2.Controls.Add(this.tb_nos);
			this.splitContainer.Panel2MinSize = 1;
			this.splitContainer.Size = new System.Drawing.Size(992, 774);
			this.splitContainer.SplitterDistance = 180;
			this.splitContainer.SplitterWidth = 3;
			this.splitContainer.TabIndex = 0;
			// 
			// tb_Fields
			// 
			this.tb_Fields.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_Fields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_Fields.Location = new System.Drawing.Point(0, 0);
			this.tb_Fields.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Fields.Multiline = true;
			this.tb_Fields.Name = "tb_Fields";
			this.tb_Fields.ReadOnly = true;
			this.tb_Fields.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.tb_Fields.Size = new System.Drawing.Size(180, 774);
			this.tb_Fields.TabIndex = 0;
			this.tb_Fields.WordWrap = false;
			// 
			// tb_Script
			// 
			this.tb_Script.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_Script.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_Script.Location = new System.Drawing.Point(35, 0);
			this.tb_Script.Margin = new System.Windows.Forms.Padding(0);
			this.tb_Script.Multiline = true;
			this.tb_Script.Name = "tb_Script";
			this.tb_Script.ReadOnly = true;
			this.tb_Script.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tb_Script.Size = new System.Drawing.Size(774, 774);
			this.tb_Script.Slave = this.tb_nos;
			this.tb_Script.TabIndex = 0;
			this.tb_Script.WordWrap = false;
			// 
			// tb_nos
			// 
			this.tb_nos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_nos.Dock = System.Windows.Forms.DockStyle.Left;
			this.tb_nos.Location = new System.Drawing.Point(0, 0);
			this.tb_nos.Margin = new System.Windows.Forms.Padding(0);
			this.tb_nos.Multiline = true;
			this.tb_nos.Name = "tb_nos";
			this.tb_nos.ReadOnly = true;
			this.tb_nos.Size = new System.Drawing.Size(35, 774);
			this.tb_nos.TabIndex = 1;
			this.tb_nos.TabStop = false;
			this.tb_nos.WordWrap = false;
			this.tb_nos.Enter += new System.EventHandler(this.enter_Nos);
			// 
			// Scripter
			// 
			this.ClientSize = new System.Drawing.Size(992, 774);
			this.Controls.Add(this.splitContainer);
			this.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Name = "Scripter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion Designer
	}
}
