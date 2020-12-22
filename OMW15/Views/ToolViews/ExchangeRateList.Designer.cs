namespace OMW15.Views.ToolViews
{
	partial class ExchangeRateList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxYearList = new System.Windows.Forms.ToolStripComboBox();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grpDailyRate = new System.Windows.Forms.GroupBox();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.grpAvgByMonth = new System.Windows.Forms.GroupBox();
			this.dgvAvgByMonth = new System.Windows.Forms.DataGridView();
			this.grpAvgByYear = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbAVGRate = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvCurr = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.ts.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.grpDailyRate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.grpAvgByMonth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAvgByMonth)).BeginInit();
			this.grpAvgByYear.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCurr)).BeginInit();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbxYearList,
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.tsbtnAdd,
            this.toolStripSeparator3,
            this.tsbtnEdit,
            this.toolStripSeparator4,
            this.tsbtnRefresh,
            this.toolStripSeparator5});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(604, 35);
			this.ts.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.AutoSize = false;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(41, 31);
			this.toolStripLabel1.Text = "ปี :";
			// 
			// tscbxYearList
			// 
			this.tscbxYearList.AutoSize = false;
			this.tscbxYearList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxYearList.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tscbxYearList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscbxYearList.Name = "tscbxYearList";
			this.tscbxYearList.Size = new System.Drawing.Size(85, 25);
			this.tscbxYearList.SelectedIndexChanged += new System.EventHandler(this.tscbxYearList_SelectedIndexChanged);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 32);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(54, 32);
			this.tsbtnAdd.Text = "&New";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(50, 32);
			this.tsbtnEdit.Text = "&Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(72, 32);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 35);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Size = new System.Drawing.Size(604, 429);
			this.panel1.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grpDailyRate);
			this.panel3.Controls.Add(this.grpAvgByMonth);
			this.panel3.Controls.Add(this.grpAvgByYear);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(130, 4);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(471, 421);
			this.panel3.TabIndex = 1;
			// 
			// grpDailyRate
			// 
			this.grpDailyRate.Controls.Add(this.dgv);
			this.grpDailyRate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpDailyRate.Location = new System.Drawing.Point(2, 2);
			this.grpDailyRate.Name = "grpDailyRate";
			this.grpDailyRate.Padding = new System.Windows.Forms.Padding(10);
			this.grpDailyRate.Size = new System.Drawing.Size(467, 204);
			this.grpDailyRate.TabIndex = 5;
			this.grpDailyRate.TabStop = false;
			this.grpDailyRate.Text = "อัตราแลกเปลี่ยนรายวัน";
			// 
			// dgv
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(10, 28);
			this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(447, 166);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// grpAvgByMonth
			// 
			this.grpAvgByMonth.Controls.Add(this.dgvAvgByMonth);
			this.grpAvgByMonth.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpAvgByMonth.Location = new System.Drawing.Point(2, 206);
			this.grpAvgByMonth.Name = "grpAvgByMonth";
			this.grpAvgByMonth.Padding = new System.Windows.Forms.Padding(10);
			this.grpAvgByMonth.Size = new System.Drawing.Size(467, 151);
			this.grpAvgByMonth.TabIndex = 4;
			this.grpAvgByMonth.TabStop = false;
			this.grpAvgByMonth.Text = "ค่าเฉลี่ยอัตราแลกเปลี่ยนรายเดือน ประจำปี [xxxx]";
			// 
			// dgvAvgByMonth
			// 
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAvgByMonth.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvAvgByMonth.BackgroundColor = System.Drawing.Color.White;
			this.dgvAvgByMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAvgByMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAvgByMonth.Location = new System.Drawing.Point(10, 28);
			this.dgvAvgByMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgvAvgByMonth.Name = "dgvAvgByMonth";
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAvgByMonth.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvAvgByMonth.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAvgByMonth.Size = new System.Drawing.Size(447, 113);
			this.dgvAvgByMonth.TabIndex = 3;
			// 
			// grpAvgByYear
			// 
			this.grpAvgByYear.Controls.Add(this.panel4);
			this.grpAvgByYear.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpAvgByYear.Location = new System.Drawing.Point(2, 357);
			this.grpAvgByYear.Name = "grpAvgByYear";
			this.grpAvgByYear.Padding = new System.Windows.Forms.Padding(10);
			this.grpAvgByYear.Size = new System.Drawing.Size(467, 62);
			this.grpAvgByYear.TabIndex = 3;
			this.grpAvgByYear.TabStop = false;
			this.grpAvgByYear.Text = "ค่าเฉลี่ยอัตราแลกเปลี่ยนประจำปี [xxxx]";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbAVGRate);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(10, 23);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(447, 29);
			this.panel4.TabIndex = 2;
			// 
			// lbAVGRate
			// 
			this.lbAVGRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbAVGRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbAVGRate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAVGRate.Location = new System.Drawing.Point(166, 2);
			this.lbAVGRate.Name = "lbAVGRate";
			this.lbAVGRate.Size = new System.Drawing.Size(97, 25);
			this.lbAVGRate.TabIndex = 2;
			this.lbAVGRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "Year Average rate (THB):";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dgvCurr);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(3, 4);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(127, 421);
			this.panel2.TabIndex = 0;
			// 
			// dgvCurr
			// 
			this.dgvCurr.BackgroundColor = System.Drawing.Color.White;
			this.dgvCurr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCurr.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCurr.Location = new System.Drawing.Point(2, 32);
			this.dgvCurr.Name = "dgvCurr";
			this.dgvCurr.Size = new System.Drawing.Size(121, 385);
			this.dgvCurr.TabIndex = 2;
			this.dgvCurr.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurr_CellEnter);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "Currency";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ExchangeRateList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(604, 464);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExchangeRateList";
			this.Text = "EXCHANGE RATE";
			this.Load += new System.EventHandler(this.ExchangeRateList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.grpDailyRate.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.grpAvgByMonth.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAvgByMonth)).EndInit();
			this.grpAvgByYear.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCurr)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxYearList;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.GroupBox grpAvgByYear;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbAVGRate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox grpAvgByMonth;
		private System.Windows.Forms.DataGridView dgvAvgByMonth;
		private System.Windows.Forms.GroupBox grpDailyRate;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.DataGridView dgvCurr;
	}
}