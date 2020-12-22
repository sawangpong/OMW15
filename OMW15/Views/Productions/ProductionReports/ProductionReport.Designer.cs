namespace OMW15.Views.Productions.ProductionReports
{
	partial class ProductionReport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionReport));
			this.pnlReport = new System.Windows.Forms.Panel();
			this.pnlReportBody = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnShowReport = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlCondition2 = new System.Windows.Forms.Panel();
			this.pnlJobSearch = new System.Windows.Forms.Panel();
			this.txtProductionJob = new System.Windows.Forms.TextBox();
			this.rdoSelectJob = new System.Windows.Forms.RadioButton();
			this.rdoAllJob = new System.Windows.Forms.RadioButton();
			this.btnSearchJob = new OMControls.OMFlatButton();
			this.pnlCondition = new System.Windows.Forms.Panel();
			this.pnlJobStatus = new System.Windows.Forms.Panel();
			this.cbxStatus = new System.Windows.Forms.ComboBox();
			this.lbJobStatus = new System.Windows.Forms.Label();
			this.pnlMonthWork = new System.Windows.Forms.Panel();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlWorkYear = new System.Windows.Forms.Panel();
			this.cbxYearReport = new System.Windows.Forms.ComboBox();
			this.lbYear = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbReportName = new System.Windows.Forms.Label();
			this.tsReport = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tscbxReport = new System.Windows.Forms.ToolStripDropDownButton();
			this.tscbxItemHourByProcess = new System.Windows.Forms.ToolStripMenuItem();
			this.tscbxItemHourByWorker = new System.Windows.Forms.ToolStripMenuItem();
			this.tscbxItemProductionJob = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlReport.SuspendLayout();
			this.pnlReportBody.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlCondition2.SuspendLayout();
			this.pnlJobSearch.SuspendLayout();
			this.pnlCondition.SuspendLayout();
			this.pnlJobStatus.SuspendLayout();
			this.pnlMonthWork.SuspendLayout();
			this.pnlWorkYear.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tsReport.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlReport
			// 
			this.pnlReport.Controls.Add(this.pnlReportBody);
			this.pnlReport.Controls.Add(this.tsReport);
			this.pnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlReport.Location = new System.Drawing.Point(0, 0);
			this.pnlReport.Name = "pnlReport";
			this.pnlReport.Padding = new System.Windows.Forms.Padding(3);
			this.pnlReport.Size = new System.Drawing.Size(760, 387);
			this.pnlReport.TabIndex = 1;
			// 
			// pnlReportBody
			// 
			this.pnlReportBody.BackColor = System.Drawing.Color.White;
			this.pnlReportBody.Controls.Add(this.panel3);
			this.pnlReportBody.Controls.Add(this.panel2);
			this.pnlReportBody.Controls.Add(this.panel1);
			this.pnlReportBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlReportBody.Location = new System.Drawing.Point(3, 48);
			this.pnlReportBody.Name = "pnlReportBody";
			this.pnlReportBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlReportBody.Size = new System.Drawing.Size(754, 336);
			this.pnlReportBody.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnShowReport);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(2, 179);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(300, 50, 50, 50);
			this.panel3.Size = new System.Drawing.Size(750, 155);
			this.panel3.TabIndex = 5;
			this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
			// 
			// btnShowReport
			// 
			this.btnShowReport.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnShowReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnShowReport.Location = new System.Drawing.Point(300, 50);
			this.btnShowReport.Name = "btnShowReport";
			this.btnShowReport.Size = new System.Drawing.Size(158, 55);
			this.btnShowReport.TabIndex = 7;
			this.btnShowReport.Text = "Show Report";
			this.btnShowReport.UseVisualStyleBackColor = true;
			this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pnlCondition2);
			this.panel2.Controls.Add(this.pnlCondition);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 52);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(20);
			this.panel2.Size = new System.Drawing.Size(750, 116);
			this.panel2.TabIndex = 3;
			// 
			// pnlCondition2
			// 
			this.pnlCondition2.Controls.Add(this.pnlJobSearch);
			this.pnlCondition2.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCondition2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlCondition2.Location = new System.Drawing.Point(20, 58);
			this.pnlCondition2.Name = "pnlCondition2";
			this.pnlCondition2.Padding = new System.Windows.Forms.Padding(2);
			this.pnlCondition2.Size = new System.Drawing.Size(710, 38);
			this.pnlCondition2.TabIndex = 6;
			this.pnlCondition2.Visible = false;
			// 
			// pnlJobSearch
			// 
			this.pnlJobSearch.Controls.Add(this.txtProductionJob);
			this.pnlJobSearch.Controls.Add(this.rdoSelectJob);
			this.pnlJobSearch.Controls.Add(this.rdoAllJob);
			this.pnlJobSearch.Controls.Add(this.btnSearchJob);
			this.pnlJobSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlJobSearch.Location = new System.Drawing.Point(2, 2);
			this.pnlJobSearch.Name = "pnlJobSearch";
			this.pnlJobSearch.Padding = new System.Windows.Forms.Padding(2);
			this.pnlJobSearch.Size = new System.Drawing.Size(525, 34);
			this.pnlJobSearch.TabIndex = 4;
			// 
			// txtProductionJob
			// 
			this.txtProductionJob.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProductionJob.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtProductionJob.Location = new System.Drawing.Point(278, 2);
			this.txtProductionJob.MaxLength = 20;
			this.txtProductionJob.Name = "txtProductionJob";
			this.txtProductionJob.Size = new System.Drawing.Size(215, 27);
			this.txtProductionJob.TabIndex = 8;
			this.txtProductionJob.TextChanged += new System.EventHandler(this.txtProductionJob_TextChanged);
			this.txtProductionJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductionJob_KeyPress);
			// 
			// rdoSelectJob
			// 
			this.rdoSelectJob.AutoSize = true;
			this.rdoSelectJob.Checked = true;
			this.rdoSelectJob.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoSelectJob.Location = new System.Drawing.Point(120, 2);
			this.rdoSelectJob.Name = "rdoSelectJob";
			this.rdoSelectJob.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
			this.rdoSelectJob.Size = new System.Drawing.Size(158, 30);
			this.rdoSelectJob.TabIndex = 7;
			this.rdoSelectJob.TabStop = true;
			this.rdoSelectJob.Tag = "S";
			this.rdoSelectJob.Text = "Select Job no.";
			this.rdoSelectJob.UseVisualStyleBackColor = true;
			this.rdoSelectJob.CheckedChanged += new System.EventHandler(this.rdoJob_CheckedChanged);
			// 
			// rdoAllJob
			// 
			this.rdoAllJob.AutoSize = true;
			this.rdoAllJob.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoAllJob.Location = new System.Drawing.Point(2, 2);
			this.rdoAllJob.Name = "rdoAllJob";
			this.rdoAllJob.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
			this.rdoAllJob.Size = new System.Drawing.Size(118, 30);
			this.rdoAllJob.TabIndex = 6;
			this.rdoAllJob.TabStop = true;
			this.rdoAllJob.Tag = "A";
			this.rdoAllJob.Text = "All Jobs";
			this.rdoAllJob.UseVisualStyleBackColor = true;
			this.rdoAllJob.CheckedChanged += new System.EventHandler(this.rdoJob_CheckedChanged);
			// 
			// btnSearchJob
			// 
			this.btnSearchJob.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchJob.FlatAppearance.BorderSize = 0;
			this.btnSearchJob.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchJob.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchJob.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchJob.Image")));
			this.btnSearchJob.Location = new System.Drawing.Point(493, 2);
			this.btnSearchJob.Name = "btnSearchJob";
			this.btnSearchJob.Size = new System.Drawing.Size(30, 30);
			this.btnSearchJob.TabIndex = 4;
			this.btnSearchJob.UseVisualStyleBackColor = true;
			this.btnSearchJob.Click += new System.EventHandler(this.btnSearchJob_Click);
			// 
			// pnlCondition
			// 
			this.pnlCondition.Controls.Add(this.pnlJobStatus);
			this.pnlCondition.Controls.Add(this.pnlMonthWork);
			this.pnlCondition.Controls.Add(this.pnlWorkYear);
			this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCondition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlCondition.Location = new System.Drawing.Point(20, 20);
			this.pnlCondition.Name = "pnlCondition";
			this.pnlCondition.Padding = new System.Windows.Forms.Padding(2);
			this.pnlCondition.Size = new System.Drawing.Size(710, 38);
			this.pnlCondition.TabIndex = 5;
			this.pnlCondition.Visible = false;
			// 
			// pnlJobStatus
			// 
			this.pnlJobStatus.Controls.Add(this.cbxStatus);
			this.pnlJobStatus.Controls.Add(this.lbJobStatus);
			this.pnlJobStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlJobStatus.Location = new System.Drawing.Point(377, 2);
			this.pnlJobStatus.Name = "pnlJobStatus";
			this.pnlJobStatus.Padding = new System.Windows.Forms.Padding(2);
			this.pnlJobStatus.Size = new System.Drawing.Size(308, 34);
			this.pnlJobStatus.TabIndex = 25;
			// 
			// cbxStatus
			// 
			this.cbxStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStatus.FormattingEnabled = true;
			this.cbxStatus.Location = new System.Drawing.Point(102, 2);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(185, 28);
			this.cbxStatus.TabIndex = 21;
			this.cbxStatus.SelectedValueChanged += new System.EventHandler(this.cbxStatus_SelectedValueChanged);
			// 
			// lbJobStatus
			// 
			this.lbJobStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobStatus.Location = new System.Drawing.Point(2, 2);
			this.lbJobStatus.Name = "lbJobStatus";
			this.lbJobStatus.Size = new System.Drawing.Size(100, 30);
			this.lbJobStatus.TabIndex = 19;
			this.lbJobStatus.Text = "สถานะงาน  :";
			this.lbJobStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlMonthWork
			// 
			this.pnlMonthWork.Controls.Add(this.cbxMonth);
			this.pnlMonthWork.Controls.Add(this.label1);
			this.pnlMonthWork.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlMonthWork.Location = new System.Drawing.Point(172, 2);
			this.pnlMonthWork.Name = "pnlMonthWork";
			this.pnlMonthWork.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMonthWork.Size = new System.Drawing.Size(205, 34);
			this.pnlMonthWork.TabIndex = 24;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(68, 2);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(131, 28);
			this.cbxMonth.TabIndex = 16;
			this.cbxMonth.SelectionChangeCommitted += new System.EventHandler(this.cbxMonth_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 30);
			this.label1.TabIndex = 1;
			this.label1.Text = "เดือน :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlWorkYear
			// 
			this.pnlWorkYear.Controls.Add(this.cbxYearReport);
			this.pnlWorkYear.Controls.Add(this.lbYear);
			this.pnlWorkYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlWorkYear.Location = new System.Drawing.Point(2, 2);
			this.pnlWorkYear.Name = "pnlWorkYear";
			this.pnlWorkYear.Padding = new System.Windows.Forms.Padding(2);
			this.pnlWorkYear.Size = new System.Drawing.Size(170, 34);
			this.pnlWorkYear.TabIndex = 23;
			// 
			// cbxYearReport
			// 
			this.cbxYearReport.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYearReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYearReport.FormattingEnabled = true;
			this.cbxYearReport.Location = new System.Drawing.Point(44, 2);
			this.cbxYearReport.Name = "cbxYearReport";
			this.cbxYearReport.Size = new System.Drawing.Size(97, 28);
			this.cbxYearReport.TabIndex = 16;
			this.cbxYearReport.SelectedValueChanged += new System.EventHandler(this.cbxYearReport_SelectedValueChanged);
			// 
			// lbYear
			// 
			this.lbYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbYear.Location = new System.Drawing.Point(2, 2);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(42, 30);
			this.lbYear.TabIndex = 1;
			this.lbYear.Text = "ปี :";
			this.lbYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DimGray;
			this.panel1.Controls.Add(this.lbReportName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(750, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbReportName
			// 
			this.lbReportName.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbReportName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbReportName.ForeColor = System.Drawing.Color.White;
			this.lbReportName.Location = new System.Drawing.Point(3, 3);
			this.lbReportName.Name = "lbReportName";
			this.lbReportName.Size = new System.Drawing.Size(394, 44);
			this.lbReportName.TabIndex = 0;
			this.lbReportName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tsReport
			// 
			this.tsReport.AutoSize = false;
			this.tsReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsReport.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tscbxReport,
            this.toolStripSeparator1});
			this.tsReport.Location = new System.Drawing.Point(3, 3);
			this.tsReport.Name = "tsReport";
			this.tsReport.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.tsReport.Size = new System.Drawing.Size(754, 45);
			this.tsReport.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(80, 42);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tscbxReport
			// 
			this.tscbxReport.AutoSize = false;
			this.tscbxReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tscbxReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbxItemHourByProcess,
            this.tscbxItemHourByWorker,
            this.tscbxItemProductionJob});
			this.tscbxReport.Image = ((System.Drawing.Image)(resources.GetObject("tscbxReport.Image")));
			this.tscbxReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tscbxReport.Name = "tscbxReport";
			this.tscbxReport.Size = new System.Drawing.Size(120, 42);
			this.tscbxReport.Text = "รายงาน";
			// 
			// tscbxItemHourByProcess
			// 
			this.tscbxItemHourByProcess.Name = "tscbxItemHourByProcess";
			this.tscbxItemHourByProcess.Size = new System.Drawing.Size(327, 24);
			this.tscbxItemHourByProcess.Tag = "1";
			this.tscbxItemHourByProcess.Text = "ชั่วโมงทำงาน - แยกตามกระบวนการผลิต";
			this.tscbxItemHourByProcess.Click += new System.EventHandler(this.mnu_Click);
			// 
			// tscbxItemHourByWorker
			// 
			this.tscbxItemHourByWorker.Name = "tscbxItemHourByWorker";
			this.tscbxItemHourByWorker.Size = new System.Drawing.Size(327, 24);
			this.tscbxItemHourByWorker.Tag = "2";
			this.tscbxItemHourByWorker.Text = "ชั่วโมงทำงาน - แยกตามพนักงาน (รายเดือน)";
			this.tscbxItemHourByWorker.Click += new System.EventHandler(this.mnu_Click);
			// 
			// tscbxItemProductionJob
			// 
			this.tscbxItemProductionJob.Name = "tscbxItemProductionJob";
			this.tscbxItemProductionJob.Size = new System.Drawing.Size(327, 24);
			this.tscbxItemProductionJob.Tag = "3";
			this.tscbxItemProductionJob.Text = "ชั่วโมงทำงาน - แยกตามใบแปร";
			this.tscbxItemProductionJob.Click += new System.EventHandler(this.mnu_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// ProductionReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(760, 387);
			this.Controls.Add(this.pnlReport);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProductionReport";
			this.Text = "Production Reports";
			this.Load += new System.EventHandler(this.ProductionReport_Load);
			this.pnlReport.ResumeLayout(false);
			this.pnlReportBody.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlCondition2.ResumeLayout(false);
			this.pnlJobSearch.ResumeLayout(false);
			this.pnlJobSearch.PerformLayout();
			this.pnlCondition.ResumeLayout(false);
			this.pnlJobStatus.ResumeLayout(false);
			this.pnlMonthWork.ResumeLayout(false);
			this.pnlWorkYear.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tsReport.ResumeLayout(false);
			this.tsReport.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel pnlReport;
		private System.Windows.Forms.ToolStrip tsReport;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton tscbxReport;
		private System.Windows.Forms.ToolStripMenuItem tscbxItemHourByProcess;
		private System.Windows.Forms.ToolStripMenuItem tscbxItemHourByWorker;
		private System.Windows.Forms.Panel pnlReportBody;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbReportName;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripMenuItem tscbxItemProductionJob;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnShowReport;
		private System.Windows.Forms.Panel pnlCondition;
		private System.Windows.Forms.Panel pnlCondition2;
		private System.Windows.Forms.Panel pnlJobSearch;
		private OMControls.OMFlatButton btnSearchJob;
		private System.Windows.Forms.Panel pnlWorkYear;
		private System.Windows.Forms.ComboBox cbxYearReport;
		private System.Windows.Forms.Label lbYear;
		private System.Windows.Forms.TextBox txtProductionJob;
		private System.Windows.Forms.RadioButton rdoSelectJob;
		private System.Windows.Forms.RadioButton rdoAllJob;
		private System.Windows.Forms.Panel pnlJobStatus;
		private System.Windows.Forms.ComboBox cbxStatus;
		private System.Windows.Forms.Label lbJobStatus;
		private System.Windows.Forms.Panel pnlMonthWork;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label1;
	}
}