namespace OMW15.Services.ServiceView
{
	partial class ServiceJobList
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
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxJobYear = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddJob = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditJob = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnStatistic = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnJobFilter = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrintOrder = new System.Windows.Forms.ToolStripButton();
			this.pnl = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtFixed = new System.Windows.Forms.TextBox();
			this.lbFixed = new System.Windows.Forms.Label();
			this.txtError = new System.Windows.Forms.TextBox();
			this.lbError = new System.Windows.Forms.Label();
			this.pnlJobListHeader = new System.Windows.Forms.Panel();
			this.lbStatus = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbSelectedOrderId = new System.Windows.Forms.Label();
			this.lbJobCount = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnLoadJobs = new System.Windows.Forms.Button();
			this.pnlJobType = new System.Windows.Forms.Panel();
			this.lst = new System.Windows.Forms.ListBox();
			this.lbSelectedYear = new System.Windows.Forms.Label();
			this.pnlJobStatus = new System.Windows.Forms.Panel();
			this.rdoComplete = new System.Windows.Forms.RadioButton();
			this.rdoActive = new System.Windows.Forms.RadioButton();
			this.rdoALL = new System.Windows.Forms.RadioButton();
			this.ts.SuspendLayout();
			this.pnl.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel5.SuspendLayout();
			this.pnlJobListHeader.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlJobType.SuspendLayout();
			this.pnlJobStatus.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscbxJobYear,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator6,
            this.tsbtnAddJob,
            this.toolStripSeparator3,
            this.tsbtnEditJob,
            this.toolStripSeparator4,
            this.tsbtnDelete,
            this.toolStripSeparator7,
            this.tsbtnStatistic,
            this.toolStripSeparator5,
            this.tsbtnJobFilter,
            this.toolStripSeparator8,
            this.tsbtnPrintOrder});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(777, 38);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(45, 43);
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.ForeColor = System.Drawing.Color.Black;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.toolStripLabel1.ForeColor = System.Drawing.Color.Black;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(52, 35);
			this.toolStripLabel1.Text = "เลือกปี :";
			// 
			// tscbxJobYear
			// 
			this.tscbxJobYear.AutoSize = false;
			this.tscbxJobYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxJobYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tscbxJobYear.Name = "tscbxJobYear";
			this.tscbxJobYear.Size = new System.Drawing.Size(80, 26);
			this.tscbxJobYear.SelectedIndexChanged += new System.EventHandler(this.tscbxJobYear_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(23, 35);
			this.tsbtnRefresh.ToolTipText = "Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnAddJob
			// 
			this.tsbtnAddJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tsbtnAddJob.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddJob.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddJob.Name = "tsbtnAddJob";
			this.tsbtnAddJob.Size = new System.Drawing.Size(79, 35);
			this.tsbtnAddJob.Text = "&Add Job";
			this.tsbtnAddJob.Click += new System.EventHandler(this.tsbtnAddJob_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnEditJob
			// 
			this.tsbtnEditJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tsbtnEditJob.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditJob.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditJob.Name = "tsbtnEditJob";
			this.tsbtnEditJob.Size = new System.Drawing.Size(77, 35);
			this.tsbtnEditJob.Text = "E&dit Job";
			this.tsbtnEditJob.Click += new System.EventHandler(this.tsbtnEditJob_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(70, 35);
			this.tsbtnDelete.Text = "&Delete";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnStatistic
			// 
			this.tsbtnStatistic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnStatistic.Image = global::OMW15.Properties.Resources.Graph;
			this.tsbtnStatistic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnStatistic.Name = "tsbtnStatistic";
			this.tsbtnStatistic.Size = new System.Drawing.Size(23, 35);
			this.tsbtnStatistic.ToolTipText = "สถิติการทำงาน";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnJobFilter
			// 
			this.tsbtnJobFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnJobFilter.Image = global::OMW15.Properties.Resources.Filter2HS;
			this.tsbtnJobFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnJobFilter.Name = "tsbtnJobFilter";
			this.tsbtnJobFilter.Size = new System.Drawing.Size(23, 35);
			this.tsbtnJobFilter.Text = "Filter";
			this.tsbtnJobFilter.Click += new System.EventHandler(this.tsbtnJobFilter_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnPrintOrder
			// 
			this.tsbtnPrintOrder.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrintOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrintOrder.Name = "tsbtnPrintOrder";
			this.tsbtnPrintOrder.Size = new System.Drawing.Size(93, 35);
			this.tsbtnPrintOrder.Text = "พิมพ์ใบงาน";
			this.tsbtnPrintOrder.Click += new System.EventHandler(this.tsbtnPrintOrder_Click);
			// 
			// pnl
			// 
			this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnl.Controls.Add(this.panel4);
			this.pnl.Controls.Add(this.pnlJobListHeader);
			this.pnl.Controls.Add(this.panel3);
			this.pnl.Controls.Add(this.splitter1);
			this.pnl.Controls.Add(this.panel1);
			this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl.Location = new System.Drawing.Point(0, 38);
			this.pnl.Name = "pnl";
			this.pnl.Padding = new System.Windows.Forms.Padding(2);
			this.pnl.Size = new System.Drawing.Size(777, 579);
			this.pnl.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgv);
			this.panel4.Controls.Add(this.splitter2);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(201, 36);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(4);
			this.panel4.Size = new System.Drawing.Size(572, 506);
			this.panel4.TabIndex = 11;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.dgv.Size = new System.Drawing.Size(341, 498);
			this.dgv.TabIndex = 13;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(345, 4);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(6, 498);
			this.splitter2.TabIndex = 12;
			this.splitter2.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.txtFixed);
			this.panel5.Controls.Add(this.lbFixed);
			this.panel5.Controls.Add(this.txtError);
			this.panel5.Controls.Add(this.lbError);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(351, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(217, 498);
			this.panel5.TabIndex = 0;
			// 
			// txtFixed
			// 
			this.txtFixed.BackColor = System.Drawing.Color.White;
			this.txtFixed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.txtFixed.Location = new System.Drawing.Point(2, 197);
			this.txtFixed.Multiline = true;
			this.txtFixed.Name = "txtFixed";
			this.txtFixed.ReadOnly = true;
			this.txtFixed.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFixed.Size = new System.Drawing.Size(211, 297);
			this.txtFixed.TabIndex = 5;
			// 
			// lbFixed
			// 
			this.lbFixed.BackColor = System.Drawing.Color.LimeGreen;
			this.lbFixed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbFixed.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFixed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbFixed.Location = new System.Drawing.Point(2, 165);
			this.lbFixed.Name = "lbFixed";
			this.lbFixed.Size = new System.Drawing.Size(211, 32);
			this.lbFixed.TabIndex = 4;
			this.lbFixed.Text = "การแก้ไข";
			this.lbFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.Color.White;
			this.txtError.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtError.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.txtError.Location = new System.Drawing.Point(2, 34);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.ReadOnly = true;
			this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtError.Size = new System.Drawing.Size(211, 131);
			this.txtError.TabIndex = 3;
			// 
			// lbError
			// 
			this.lbError.BackColor = System.Drawing.Color.Red;
			this.lbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbError.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbError.ForeColor = System.Drawing.Color.White;
			this.lbError.Location = new System.Drawing.Point(2, 2);
			this.lbError.Name = "lbError";
			this.lbError.Size = new System.Drawing.Size(211, 32);
			this.lbError.TabIndex = 2;
			this.lbError.Text = "อาการที่เสีย";
			this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlJobListHeader
			// 
			this.pnlJobListHeader.Controls.Add(this.lbStatus);
			this.pnlJobListHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlJobListHeader.Location = new System.Drawing.Point(201, 2);
			this.pnlJobListHeader.Name = "pnlJobListHeader";
			this.pnlJobListHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlJobListHeader.Size = new System.Drawing.Size(572, 34);
			this.pnlJobListHeader.TabIndex = 9;
			// 
			// lbStatus
			// 
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbStatus.Location = new System.Drawing.Point(2, 2);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(126, 30);
			this.lbStatus.TabIndex = 1;
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbSelectedOrderId);
			this.panel3.Controls.Add(this.lbJobCount);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(201, 542);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(572, 33);
			this.panel3.TabIndex = 4;
			// 
			// lbSelectedOrderId
			// 
			this.lbSelectedOrderId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedOrderId.Location = new System.Drawing.Point(128, 2);
			this.lbSelectedOrderId.Name = "lbSelectedOrderId";
			this.lbSelectedOrderId.Size = new System.Drawing.Size(64, 29);
			this.lbSelectedOrderId.TabIndex = 1;
			this.lbSelectedOrderId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbJobCount
			// 
			this.lbJobCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobCount.Location = new System.Drawing.Point(2, 2);
			this.lbJobCount.Name = "lbJobCount";
			this.lbJobCount.Size = new System.Drawing.Size(126, 29);
			this.lbJobCount.TabIndex = 0;
			this.lbJobCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(195, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 573);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.pnlJobType);
			this.panel1.Controls.Add(this.pnlJobStatus);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(193, 573);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLoadJobs);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 347);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(185, 53);
			this.panel2.TabIndex = 8;
			// 
			// btnLoadJobs
			// 
			this.btnLoadJobs.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnLoadJobs.Location = new System.Drawing.Point(10, 10);
			this.btnLoadJobs.Name = "btnLoadJobs";
			this.btnLoadJobs.Size = new System.Drawing.Size(165, 33);
			this.btnLoadJobs.TabIndex = 3;
			this.btnLoadJobs.Text = "Load Data";
			this.btnLoadJobs.UseVisualStyleBackColor = true;
			this.btnLoadJobs.Click += new System.EventHandler(this.btnLoadJobs_Click);
			// 
			// pnlJobType
			// 
			this.pnlJobType.Controls.Add(this.lst);
			this.pnlJobType.Controls.Add(this.lbSelectedYear);
			this.pnlJobType.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlJobType.Location = new System.Drawing.Point(3, 87);
			this.pnlJobType.Name = "pnlJobType";
			this.pnlJobType.Padding = new System.Windows.Forms.Padding(4);
			this.pnlJobType.Size = new System.Drawing.Size(185, 260);
			this.pnlJobType.TabIndex = 7;
			// 
			// lst
			// 
			this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lst.FormattingEnabled = true;
			this.lst.IntegralHeight = false;
			this.lst.ItemHeight = 18;
			this.lst.Location = new System.Drawing.Point(4, 34);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(177, 222);
			this.lst.TabIndex = 2;
			this.lst.SelectedValueChanged += new System.EventHandler(this.lst_SelectedValueChanged);
			this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
			// 
			// lbSelectedYear
			// 
			this.lbSelectedYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbSelectedYear.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSelectedYear.Location = new System.Drawing.Point(4, 4);
			this.lbSelectedYear.Name = "lbSelectedYear";
			this.lbSelectedYear.Size = new System.Drawing.Size(177, 30);
			this.lbSelectedYear.TabIndex = 1;
			this.lbSelectedYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlJobStatus
			// 
			this.pnlJobStatus.Controls.Add(this.rdoComplete);
			this.pnlJobStatus.Controls.Add(this.rdoActive);
			this.pnlJobStatus.Controls.Add(this.rdoALL);
			this.pnlJobStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlJobStatus.Location = new System.Drawing.Point(3, 3);
			this.pnlJobStatus.Name = "pnlJobStatus";
			this.pnlJobStatus.Padding = new System.Windows.Forms.Padding(4);
			this.pnlJobStatus.Size = new System.Drawing.Size(185, 84);
			this.pnlJobStatus.TabIndex = 6;
			// 
			// rdoComplete
			// 
			this.rdoComplete.Dock = System.Windows.Forms.DockStyle.Top;
			this.rdoComplete.Location = new System.Drawing.Point(4, 56);
			this.rdoComplete.Name = "rdoComplete";
			this.rdoComplete.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoComplete.Size = new System.Drawing.Size(177, 26);
			this.rdoComplete.TabIndex = 8;
			this.rdoComplete.TabStop = true;
			this.rdoComplete.Tag = "COMPLETED";
			this.rdoComplete.Text = "Complete Order";
			this.rdoComplete.UseVisualStyleBackColor = true;
			this.rdoComplete.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoActive
			// 
			this.rdoActive.Dock = System.Windows.Forms.DockStyle.Top;
			this.rdoActive.Location = new System.Drawing.Point(4, 30);
			this.rdoActive.Name = "rdoActive";
			this.rdoActive.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoActive.Size = new System.Drawing.Size(177, 26);
			this.rdoActive.TabIndex = 7;
			this.rdoActive.TabStop = true;
			this.rdoActive.Tag = "ACTIVE";
			this.rdoActive.Text = "Active Order";
			this.rdoActive.UseVisualStyleBackColor = true;
			this.rdoActive.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoALL
			// 
			this.rdoALL.Dock = System.Windows.Forms.DockStyle.Top;
			this.rdoALL.Location = new System.Drawing.Point(4, 4);
			this.rdoALL.Name = "rdoALL";
			this.rdoALL.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoALL.Size = new System.Drawing.Size(177, 26);
			this.rdoALL.TabIndex = 6;
			this.rdoALL.TabStop = true;
			this.rdoALL.Tag = "ALL";
			this.rdoALL.Text = "ALL";
			this.rdoALL.UseVisualStyleBackColor = true;
			this.rdoALL.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// ServiceJobList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(777, 617);
			this.Controls.Add(this.pnl);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ServiceJobList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SERVICE JOB LIST";
			this.Load += new System.EventHandler(this.ServiceJobList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnl.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.pnlJobListHeader.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlJobType.ResumeLayout(false);
			this.pnlJobStatus.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel pnl;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxJobYear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbJobCount;
		private System.Windows.Forms.Panel pnlJobStatus;
		private System.Windows.Forms.RadioButton rdoComplete;
		private System.Windows.Forms.RadioButton rdoActive;
		private System.Windows.Forms.RadioButton rdoALL;
		private System.Windows.Forms.Panel pnlJobType;
		private System.Windows.Forms.ListBox lst;
		private System.Windows.Forms.Label lbSelectedYear;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnLoadJobs;
		private System.Windows.Forms.Panel pnlJobListHeader;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.ToolStripButton tsbtnAddJob;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnEditJob;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Label lbSelectedOrderId;
		private System.Windows.Forms.ToolStripButton tsbtnJobFilter;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtFixed;
		private System.Windows.Forms.Label lbFixed;
		private System.Windows.Forms.TextBox txtError;
		private System.Windows.Forms.Label lbError;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tsbtnStatistic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton tsbtnPrintOrder;
	}
}