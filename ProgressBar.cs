using System;
using System.Windows.Forms;


namespace nwn2_ai_2da_editor
{
	sealed class ProgBarF
		:
			Form
	{
		ProgressBar _bar;
		Label _info;

		#region Fields & Properties
		static ProgBarF _instance;
		internal static ProgBarF Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ProgBarF();

				_instance._bar.Value = 0;
				_instance.Show();

				return _instance;
			}
		}
		#endregion


		#region cTor
		/// <summary>
		/// cTor.
		/// </summary>
		internal ProgBarF()
		{
			InitializeComponent();
		}
		#endregion


		#region Methods
		internal void SetInfo(string info)
		{
			_info.Text = info;
			Refresh();
		}

		internal void SetTotal(int total)
		{
			_bar.Maximum = total;
		}

		internal void Step()
		{
			if (++_bar.Value == _bar.Maximum)
				Hide();
		}
		#endregion


		#region Windows Form Designer generated code
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();

			base.Dispose(disposing);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify the contents of
		/// this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._bar = new System.Windows.Forms.ProgressBar();
			this._info = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _bar
			// 
			this._bar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._bar.Location = new System.Drawing.Point(0, 16);
			this._bar.Name = "_bar";
			this._bar.Size = new System.Drawing.Size(312, 21);
			this._bar.TabIndex = 0;
			// 
			// _info
			// 
			this._info.Dock = System.Windows.Forms.DockStyle.Top;
			this._info.Location = new System.Drawing.Point(0, 0);
			this._info.Name = "_info";
			this._info.Size = new System.Drawing.Size(312, 15);
			this._info.TabIndex = 1;
			this._info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProgBarF
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(312, 37);
			this.ControlBox = false;
			this.Controls.Add(this._info);
			this.Controls.Add(this._bar);
			this.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(320, 45);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(320, 45);
			this.Name = "ProgBarF";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion
	}
}
