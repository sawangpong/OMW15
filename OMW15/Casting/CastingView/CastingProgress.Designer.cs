namespace OMW15.Casting.CastingView
{
	partial class CastingProgress
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
			if(disposing && (components != null))
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingProgress));
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tslbLoadData = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tscbxWorkYear = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.lbWorkDetailsByMonth = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dgv2 = new System.Windows.Forms.DataGridView();
			this.lbWorkDetailByDay = new System.Windows.Forms.Label();
			this.dgvAVG = new System.Windows.Forms.DataGridView();
			this.lbSummary = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.dgvYearSum = new System.Windows.Forms.DataGridView();
			this.lbSummaryByYear = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbWorkSummaryByYWorker = new System.Windows.Forms.Label();
			this.dgvWorkSum = new System.Windows.Forms.DataGridView();
			this.btnChart =  new OMControls.OMFlatButton();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.ts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAVG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvYearSum)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorkSum)).BeginInit();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbLoadData,
            this.toolStripSeparator1,
            this.tscbxWorkYear,
            this.toolStripSeparator2,
            this.tsbtnClose,
            this.toolStripSeparator3});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(778, 38);
			this.ts.TabIndex = 0;
			this.ts.Text = "toolStrip1";
			// 
			// tslbLoadData
			// 
			this.tslbLoadData.Name = "tslbLoadData";
			this.tslbLoadData.Size = new System.Drawing.Size(43, 35);
			this.tslbLoadData.Text = "Year :";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// tscbxWorkYear
			// 
			this.tscbxWorkYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxWorkYear.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxWorkYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tscbxWorkYear.Name = "tscbxWorkYear";
			this.tscbxWorkYear.Size = new System.Drawing.Size(75, 38);
			this.tscbxWorkYear.SelectedIndexChanged += new System.EventHandler(this.tscbxWorkYear_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainer1.Location = new System.Drawing.Point(0, 38);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgv);
			this.splitContainer1.Panel1.Controls.Add(this.lbWorkDetailsByMonth);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer1.Panel1MinSize = 200;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer1.Panel2MinSize = 200;
			this.splitContainer1.Size = new System.Drawing.Size(778, 370);
			this.splitContainer1.SplitterDistance = 400;
			this.splitContainer1.SplitterWidth = 6;
			this.splitContainer1.TabIndex = 8;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 32);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(394, 334);
			this.dgv.TabIndex = 11;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting_1);
			// 
			// lbWorkDetailsByMonth
			// 
			this.lbWorkDetailsByMonth.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbWorkDetailsByMonth.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbWorkDetailsByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbWorkDetailsByMonth.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbWorkDetailsByMonth.Location = new System.Drawing.Point(2, 2);
			this.lbWorkDetailsByMonth.Name = "lbWorkDetailsByMonth";
			this.lbWorkDetailsByMonth.Size = new System.Drawing.Size(394, 30);
			this.lbWorkDetailsByMonth.TabIndex = 8;
			this.lbWorkDetailsByMonth.Text = "Details";
			this.lbWorkDetailsByMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitContainer2
			// 
			this.splitContainer2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(2, 2);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.dgv2);
			this.splitContainer2.Panel1.Controls.Add(this.lbWorkDetailByDay);
			this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer2.Panel1MinSize = 50;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.dgvAVG);
			this.splitContainer2.Panel2.Controls.Add(this.lbSummary);
			this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer2.Panel2MinSize = 50;
			this.splitContainer2.Size = new System.Drawing.Size(368, 366);
			this.splitContainer2.SplitterDistance = 193;
			this.splitContainer2.SplitterWidth = 6;
			this.splitContainer2.TabIndex = 0;
			// 
			// dgv2
			// 
			this.dgv2.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv2.Location = new System.Drawing.Point(2, 32);
			this.dgv2.Name = "dgv2";
			this.dgv2.Size = new System.Drawing.Size(362, 157);
			this.dgv2.TabIndex = 16;
			// 
			// lbWorkDetailByDay
			// 
			this.lbWorkDetailByDay.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbWorkDetailByDay.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbWorkDetailByDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbWorkDetailByDay.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbWorkDetailByDay.Location = new System.Drawing.Point(2, 2);
			this.lbWorkDetailByDay.Name = "lbWorkDetailByDay";
			this.lbWorkDetailByDay.Size = new System.Drawing.Size(362, 30);
			this.lbWorkDetailByDay.TabIndex = 15;
			this.lbWorkDetailByDay.Text = "Summary by Worker";
			this.lbWorkDetailByDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvAVG
			// 
			this.dgvAVG.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvAVG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvAVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAVG.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAVG.Location = new System.Drawing.Point(2, 32);
			this.dgvAVG.Name = "dgvAVG";
			this.dgvAVG.Size = new System.Drawing.Size(362, 131);
			this.dgvAVG.TabIndex = 15;
			// 
			// lbSummary
			// 
			this.lbSummary.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbSummary.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbSummary.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbSummary.Location = new System.Drawing.Point(2, 2);
			this.lbSummary.Name = "lbSummary";
			this.lbSummary.Size = new System.Drawing.Size(362, 30);
			this.lbSummary.TabIndex = 13;
			this.lbSummary.Text = "Summary by Worker (ทำก้อน / ฉีด / แต่ง)";
			this.lbSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 408);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(778, 6);
			this.splitter1.TabIndex = 9;
			this.splitter1.TabStop = false;
			// 
			// splitContainer3
			// 
			this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 414);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.dgvYearSum);
			this.splitContainer3.Panel1.Controls.Add(this.lbSummaryByYear);
			this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(2);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.dgvWorkSum);
			this.splitContainer3.Panel2.Controls.Add(this.panel1);
			this.splitContainer3.Panel2.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer3.Size = new System.Drawing.Size(778, 157);
			this.splitContainer3.SplitterDistance = 433;
			this.splitContainer3.SplitterWidth = 6;
			this.splitContainer3.TabIndex = 10;
			// 
			// dgvYearSum
			// 
			this.dgvYearSum.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvYearSum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvYearSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvYearSum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvYearSum.Location = new System.Drawing.Point(2, 32);
			this.dgvYearSum.Name = "dgvYearSum";
			this.dgvYearSum.Size = new System.Drawing.Size(427, 121);
			this.dgvYearSum.TabIndex = 4;
			this.dgvYearSum.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYearSum_CellEnter);
			// 
			// lbSummaryByYear
			// 
			this.lbSummaryByYear.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbSummaryByYear.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSummaryByYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbSummaryByYear.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbSummaryByYear.Location = new System.Drawing.Point(2, 2);
			this.lbSummaryByYear.Name = "lbSummaryByYear";
			this.lbSummaryByYear.Size = new System.Drawing.Size(427, 30);
			this.lbSummaryByYear.TabIndex = 3;
			this.lbSummaryByYear.Text = "Summary by Year (only casting)";
			this.lbSummaryByYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
			this.panel1.Controls.Add(this.lbWorkSummaryByYWorker);
			this.panel1.Controls.Add(this.btnChart);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(333, 30);
			this.panel1.TabIndex = 14;
			// 
			// lbWorkSummaryByYWorker
			// 
			this.lbWorkSummaryByYWorker.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbWorkSummaryByYWorker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbWorkSummaryByYWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbWorkSummaryByYWorker.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbWorkSummaryByYWorker.Location = new System.Drawing.Point(30, 0);
			this.lbWorkSummaryByYWorker.Name = "lbWorkSummaryByYWorker";
			this.lbWorkSummaryByYWorker.Size = new System.Drawing.Size(303, 30);
			this.lbWorkSummaryByYWorker.TabIndex = 5;
			this.lbWorkSummaryByYWorker.Text = "ยอดสะสม  (ทำก้อน / ฉีด / แต่ง) in Year : [xxxx]";
			this.lbWorkSummaryByYWorker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvWorkSum
			// 
			this.dgvWorkSum.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvWorkSum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvWorkSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvWorkSum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvWorkSum.Location = new System.Drawing.Point(2, 32);
			this.dgvWorkSum.Name = "dgvWorkSum";
			this.dgvWorkSum.Size = new System.Drawing.Size(333, 121);
			this.dgvWorkSum.TabIndex = 15;
			// 
			// btnChart
			// 
			this.btnChart.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnChart.FlatAppearance.BorderSize = 0;
			this.btnChart.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnChart.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnChart.Image = ((System.Drawing.Image)(resources.GetObject("btnChart.Image")));
			this.btnChart.Location = new System.Drawing.Point(0, 0);
			this.btnChart.Name = "btnChart";
			this.btnChart.Size = new System.Drawing.Size(30, 30);
			this.btnChart.Style = OMControls.ButtonImageStyle.Chart;
			this.btnChart.TabIndex = 0;
			this.btnChart.UseVisualStyleBackColor = true;
			this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(23, 35);
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// CastingProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(778, 571);
			this.Controls.Add(this.splitContainer3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Name = "CastingProgress";
			this.Text = "CASTING JOB PROGRESS";
			this.Load += new System.EventHandler(this.CastingProgress_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvAVG)).EndInit();
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvYearSum)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvWorkSum)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel tslbLoadData;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripComboBox tscbxWorkYear;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Label lbWorkDetailsByMonth;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.DataGridView dgvYearSum;
		private System.Windows.Forms.Label lbSummaryByYear;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.DataGridView dgv2;
		private System.Windows.Forms.Label lbWorkDetailByDay;
		private System.Windows.Forms.DataGridView dgvAVG;
		private System.Windows.Forms.Label lbSummary;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbWorkSummaryByYWorker;
		private OMControls.OMFlatButton btnChart;
		private System.Windows.Forms.DataGridView dgvWorkSum;
	}
}