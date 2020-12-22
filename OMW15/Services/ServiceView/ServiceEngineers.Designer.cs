namespace OMW15.Services.ServiceView
{
	partial class ServiceEngineers
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlRight = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.lbSEQ = new System.Windows.Forms.Label();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnAddEngineer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditEngineer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.pnlRight.SuspendLayout();
			this.pnlMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlCommand.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.btnClose);
			this.pnlRight.Controls.Add(this.btnSelect);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlRight.Location = new System.Drawing.Point(295, 0);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(2, 40, 2, 20);
			this.pnlRight.Size = new System.Drawing.Size(131, 361);
			this.pnlRight.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(2, 305);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(127, 36);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnSelect.Location = new System.Drawing.Point(2, 40);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(127, 36);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.dgv);
			this.pnlMain.Controls.Add(this.pnlCommand);
			this.pnlMain.Controls.Add(this.ts);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(4);
			this.pnlMain.Size = new System.Drawing.Size(295, 361);
			this.pnlMain.TabIndex = 4;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 39);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(287, 279);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.lbSEQ);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(4, 318);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(3);
			this.pnlCommand.Size = new System.Drawing.Size(287, 39);
			this.pnlCommand.TabIndex = 2;
			// 
			// lbSEQ
			// 
			this.lbSEQ.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSEQ.Location = new System.Drawing.Point(3, 3);
			this.lbSEQ.Name = "lbSEQ";
			this.lbSEQ.Size = new System.Drawing.Size(60, 33);
			this.lbSEQ.TabIndex = 0;
			this.lbSEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddEngineer,
            this.toolStripSeparator1,
            this.tsbtnEditEngineer,
            this.toolStripSeparator2,
            this.tsbtnClose,
            this.toolStripSeparator3,
            this.tsbtnRefresh});
			this.ts.Location = new System.Drawing.Point(4, 4);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(287, 35);
			this.ts.TabIndex = 1;
			// 
			// tsbtnAddEngineer
			// 
			this.tsbtnAddEngineer.AutoSize = false;
			this.tsbtnAddEngineer.AutoToolTip = false;
			this.tsbtnAddEngineer.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddEngineer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddEngineer.Name = "tsbtnAddEngineer";
			this.tsbtnAddEngineer.Size = new System.Drawing.Size(75, 32);
			this.tsbtnAddEngineer.Text = "&Add";
			this.tsbtnAddEngineer.Click += new System.EventHandler(this.tsbtnAddEngineer_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnEditEngineer
			// 
			this.tsbtnEditEngineer.AutoSize = false;
			this.tsbtnEditEngineer.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditEngineer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditEngineer.Name = "tsbtnEditEngineer";
			this.tsbtnEditEngineer.Size = new System.Drawing.Size(75, 32);
			this.tsbtnEditEngineer.Text = "&Edit";
			this.tsbtnEditEngineer.Click += new System.EventHandler(this.tsbtnEditEngineer_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(35, 32);
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(23, 32);
			this.tsbtnRefresh.ToolTipText = "Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// ServiceEngineers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 361);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlRight);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ServiceEngineers";
			this.Text = "ช่างบริการ";
			this.Load += new System.EventHandler(this.ServiceEngineers_Load);
			this.pnlRight.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlCommand.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Label lbSEQ;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnAddEngineer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEditEngineer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;

	}
}