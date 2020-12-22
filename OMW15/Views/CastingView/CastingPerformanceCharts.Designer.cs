namespace OMW15.Views.CastingView
{
	partial class CastingPerformanceCharts
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
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxYear = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxPeriod = new System.Windows.Forms.ToolStripComboBox();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlChartCategory = new System.Windows.Forms.Panel();
			this.grpStat = new System.Windows.Forms.GroupBox();
			this.lstStatisticCategory = new System.Windows.Forms.ListBox();
			this.pnlChart = new System.Windows.Forms.Panel();
			this.ts.SuspendLayout();
			this.pnlChartCategory.SuspendLayout();
			this.grpStat.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbxYear,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tscbxPeriod,
            this.tsbtnClose,
            this.toolStripSeparator2});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(935, 35);
			this.ts.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(40, 32);
			this.toolStripLabel1.Text = "Year:";
			// 
			// tscbxYear
			// 
			this.tscbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxYear.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tscbxYear.Name = "tscbxYear";
			this.tscbxYear.Size = new System.Drawing.Size(88, 35);
			this.tscbxYear.SelectedIndexChanged += new System.EventHandler(this.tscbxYear_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.AutoSize = false;
			this.toolStripLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(75, 30);
			this.toolStripLabel2.Text = "Month :";
			this.toolStripLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tscbxPeriod
			// 
			this.tscbxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxPeriod.Name = "tscbxPeriod";
			this.tscbxPeriod.Size = new System.Drawing.Size(88, 35);
			this.tscbxPeriod.SelectedIndexChanged += new System.EventHandler(this.tscbxPeriod_SelectedIndexChanged);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(63, 32);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// pnlChartCategory
			// 
			this.pnlChartCategory.BackColor = System.Drawing.Color.White;
			this.pnlChartCategory.Controls.Add(this.grpStat);
			this.pnlChartCategory.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlChartCategory.Location = new System.Drawing.Point(0, 35);
			this.pnlChartCategory.Name = "pnlChartCategory";
			this.pnlChartCategory.Padding = new System.Windows.Forms.Padding(4);
			this.pnlChartCategory.Size = new System.Drawing.Size(195, 522);
			this.pnlChartCategory.TabIndex = 1;
			// 
			// grpStat
			// 
			this.grpStat.Controls.Add(this.lstStatisticCategory);
			this.grpStat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpStat.Location = new System.Drawing.Point(4, 4);
			this.grpStat.Name = "grpStat";
			this.grpStat.Padding = new System.Windows.Forms.Padding(7);
			this.grpStat.Size = new System.Drawing.Size(187, 514);
			this.grpStat.TabIndex = 0;
			this.grpStat.TabStop = false;
			this.grpStat.Text = "Statistic";
			// 
			// lstStatisticCategory
			// 
			this.lstStatisticCategory.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstStatisticCategory.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstStatisticCategory.FormattingEnabled = true;
			this.lstStatisticCategory.IntegralHeight = false;
			this.lstStatisticCategory.ItemHeight = 17;
			this.lstStatisticCategory.Location = new System.Drawing.Point(7, 25);
			this.lstStatisticCategory.Name = "lstStatisticCategory";
			this.lstStatisticCategory.Size = new System.Drawing.Size(173, 482);
			this.lstStatisticCategory.TabIndex = 0;
			this.lstStatisticCategory.SelectedValueChanged += new System.EventHandler(this.lstStatisticCategory_SelectedValueChanged);
			// 
			// pnlChart
			// 
			this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlChart.Location = new System.Drawing.Point(195, 35);
			this.pnlChart.Name = "pnlChart";
			this.pnlChart.Padding = new System.Windows.Forms.Padding(4);
			this.pnlChart.Size = new System.Drawing.Size(740, 522);
			this.pnlChart.TabIndex = 3;
			// 
			// CastingPerformanceCharts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(935, 557);
			this.Controls.Add(this.pnlChart);
			this.Controls.Add(this.pnlChartCategory);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CastingPerformanceCharts";
			this.Text = "CastingPerformanceCharts";
			this.Load += new System.EventHandler(this.CastingPerformanceCharts_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlChartCategory.ResumeLayout(false);
			this.grpStat.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxYear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripComboBox tscbxPeriod;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel pnlChartCategory;
		private System.Windows.Forms.Panel pnlChart;
		private System.Windows.Forms.GroupBox grpStat;
		private System.Windows.Forms.ListBox lstStatisticCategory;
	}
}