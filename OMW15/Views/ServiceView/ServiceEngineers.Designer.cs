namespace OMW15.Views.ServiceView
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.lbCount = new System.Windows.Forms.Label();
			this.lbSEQ = new System.Windows.Forms.Label();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxEngStatus = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddEngineer = new System.Windows.Forms.ToolStripButton();
			this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditEngineer = new System.Windows.Forms.ToolStripButton();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.tsSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
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
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlRight.Location = new System.Drawing.Point(0, 303);
			this.pnlRight.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
			this.pnlRight.Size = new System.Drawing.Size(458, 38);
			this.pnlRight.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(354, 5);
			this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(99, 28);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(5, 5);
			this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(99, 28);
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
			this.pnlMain.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlMain.Size = new System.Drawing.Size(458, 303);
			this.pnlMain.TabIndex = 4;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 37);
			this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(452, 231);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.lbCount);
			this.pnlCommand.Controls.Add(this.lbSEQ);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlCommand.Location = new System.Drawing.Point(3, 268);
			this.pnlCommand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlCommand.Size = new System.Drawing.Size(452, 31);
			this.pnlCommand.TabIndex = 2;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Location = new System.Drawing.Point(79, 3);
			this.lbCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(146, 25);
			this.lbCount.TabIndex = 1;
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbSEQ
			// 
			this.lbSEQ.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSEQ.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.lbSEQ.Location = new System.Drawing.Point(2, 3);
			this.lbSEQ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbSEQ.Name = "lbSEQ";
			this.lbSEQ.Size = new System.Drawing.Size(77, 25);
			this.lbSEQ.TabIndex = 0;
			this.lbSEQ.Text = "0";
			this.lbSEQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbxEngStatus,
            this.toolStripSeparator5,
            this.tsbtnRefresh,
            this.toolStripSeparator2,
            this.tsbtnAddEngineer,
            this.tsSep1,
            this.tsbtnEditEngineer,
            this.tsbtnClose,
            this.tsSep3,
            this.tsSep2});
			this.ts.Location = new System.Drawing.Point(3, 4);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(452, 33);
			this.ts.TabIndex = 1;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(50, 30);
			this.toolStripLabel1.Text = "Status :";
			// 
			// tscbxEngStatus
			// 
			this.tscbxEngStatus.AutoSize = false;
			this.tscbxEngStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxEngStatus.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxEngStatus.Name = "tscbxEngStatus";
			this.tscbxEngStatus.Size = new System.Drawing.Size(100, 23);
			this.tscbxEngStatus.SelectedIndexChanged += new System.EventHandler(this.tscbxEngStatus_SelectedIndexChanged);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(23, 30);
			this.tsbtnRefresh.ToolTipText = "Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
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
			// tsSep1
			// 
			this.tsSep1.Name = "tsSep1";
			this.tsSep1.Size = new System.Drawing.Size(6, 33);
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
			// tsSep3
			// 
			this.tsSep3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSep3.Name = "tsSep3";
			this.tsSep3.Size = new System.Drawing.Size(6, 33);
			// 
			// tsSep2
			// 
			this.tsSep2.Name = "tsSep2";
			this.tsSep2.Size = new System.Drawing.Size(6, 33);
			// 
			// ServiceEngineers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(458, 341);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.pnlRight);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
		private System.Windows.Forms.ToolStripSeparator tsSep1;
		private System.Windows.Forms.ToolStripButton tsbtnEditEngineer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator tsSep3;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ToolStripSeparator tsSep2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxEngStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Label lbCount;

	}
}