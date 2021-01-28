namespace OMW15.Views.Productions
{
	partial class MCToolsPlan
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.dgvJobInfo = new System.Windows.Forms.DataGridView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tslbJobNo = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbRows = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cbxItemNo = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxJobYear = new System.Windows.Forms.ComboBox();
			this.lbYear = new System.Windows.Forms.Label();
			this.cbxJobStatus = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvJobInfo)).BeginInit();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(955, 50);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(720, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "Machine && Tools Plan";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.Location = new System.Drawing.Point(0, 499);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(955, 30);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.splitter1);
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 50);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(955, 449);
			this.panel3.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.dgvJobInfo);
			this.panel6.Controls.Add(this.toolStrip1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(2, 261);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(3);
			this.panel6.Size = new System.Drawing.Size(951, 186);
			this.panel6.TabIndex = 7;
			// 
			// dgvJobInfo
			// 
			this.dgvJobInfo.BackgroundColor = System.Drawing.Color.White;
			this.dgvJobInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJobInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvJobInfo.Location = new System.Drawing.Point(3, 38);
			this.dgvJobInfo.Name = "dgvJobInfo";
			this.dgvJobInfo.Size = new System.Drawing.Size(945, 145);
			this.dgvJobInfo.TabIndex = 2;
			this.dgvJobInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobInfo_CellEnter);
			this.dgvJobInfo.DoubleClick += new System.EventHandler(this.dgvJobInfo_DoubleClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbJobNo,
            this.toolStripSeparator1,
            this.tslbRows,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(945, 35);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tslbJobNo
			// 
			this.tslbJobNo.Name = "tslbJobNo";
			this.tslbJobNo.Size = new System.Drawing.Size(0, 32);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// tslbRows
			// 
			this.tslbRows.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tslbRows.Name = "tslbRows";
			this.tslbRows.Size = new System.Drawing.Size(36, 32);
			this.tslbRows.Text = "0 row";
			this.tslbRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
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
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(2, 251);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(951, 10);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgv.Location = new System.Drawing.Point(2, 60);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(951, 191);
			this.dgv.TabIndex = 1;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 2);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(951, 58);
			this.panel4.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(2, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(83, 24);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.cbxItemNo);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.cbxJobYear);
			this.panel5.Controls.Add(this.lbYear);
			this.panel5.Controls.Add(this.cbxJobStatus);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(2, 26);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2, 2, 20, 2);
			this.panel5.Size = new System.Drawing.Size(947, 30);
			this.panel5.TabIndex = 1;
			// 
			// cbxItemNo
			// 
			this.cbxItemNo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxItemNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxItemNo.FormattingEnabled = true;
			this.cbxItemNo.Location = new System.Drawing.Point(410, 2);
			this.cbxItemNo.Name = "cbxItemNo";
			this.cbxItemNo.Size = new System.Drawing.Size(515, 25);
			this.cbxItemNo.TabIndex = 6;
			this.cbxItemNo.SelectionChangeCommitted += new System.EventHandler(this.cbxItemNo_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(330, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "Item-no.: ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxJobYear
			// 
			this.cbxJobYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobYear.FormattingEnabled = true;
			this.cbxJobYear.Location = new System.Drawing.Point(240, 2);
			this.cbxJobYear.Name = "cbxJobYear";
			this.cbxJobYear.Size = new System.Drawing.Size(90, 25);
			this.cbxJobYear.TabIndex = 4;
			this.cbxJobYear.SelectionChangeCommitted += new System.EventHandler(this.cbxJobYear_SelectionChangeCommitted);
			// 
			// lbYear
			// 
			this.lbYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYear.Location = new System.Drawing.Point(185, 2);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(55, 24);
			this.lbYear.TabIndex = 3;
			this.lbYear.Text = "year: ";
			this.lbYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxJobStatus
			// 
			this.cbxJobStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobStatus.FormattingEnabled = true;
			this.cbxJobStatus.Location = new System.Drawing.Point(82, 2);
			this.cbxJobStatus.Name = "cbxJobStatus";
			this.cbxJobStatus.Size = new System.Drawing.Size(103, 25);
			this.cbxJobStatus.TabIndex = 2;
			this.cbxJobStatus.SelectedIndexChanged += new System.EventHandler(this.cbxJobStatus_SelectedIndexChanged);
			this.cbxJobStatus.SelectionChangeCommitted += new System.EventHandler(this.cbxJobStatus_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Job status: ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MCToolsPlan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(955, 529);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MCToolsPlan";
			this.Text = "Machine & Tools Plan";
			this.Load += new System.EventHandler(this.MCToolsPlan_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvJobInfo)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ComboBox cbxJobStatus;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxJobYear;
		private System.Windows.Forms.Label lbYear;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ComboBox cbxItemNo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.DataGridView dgvJobInfo;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel tslbJobNo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tslbRows;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}