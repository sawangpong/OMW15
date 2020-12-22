namespace OMW15.Views.CastingView
{
	partial class CTJobs
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTJobs));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.chkShowInfo = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnLoadJobData = new OMControls.OMFlatButton();
			this.cbxJobCat = new System.Windows.Forms.ComboBox();
			this.lbJobCat = new System.Windows.Forms.Label();
			this.pnlClosingYear = new System.Windows.Forms.Panel();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.lbJobMonth = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.lbYear = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.cbxJobStatus = new System.Windows.Forms.ComboBox();
			this.lbStatus = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlPriority = new System.Windows.Forms.Panel();
			this.dgvPriority = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvActiveQty = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbSummaryHeader = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlJobInfo = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCast = new System.Windows.Forms.Label();
			this.lbTree = new System.Windows.Forms.Label();
			this.lbFinishing = new System.Windows.Forms.Label();
			this.lbWax = new System.Windows.Forms.Label();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFindJob = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuFindByJobNo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFindByCustomerName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnJobProgress = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnJobInfo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbJobOrder = new System.Windows.Forms.Label();
			this.lbJobInfo = new System.Windows.Forms.Label();
			this.lbCustomerCode = new System.Windows.Forms.Label();
			this.lbSelectedJobId = new System.Windows.Forms.Label();
			this.lbFoundRecords = new System.Windows.Forms.Label();
			this.tTip = new System.Windows.Forms.ToolTip(this.components);
			this.pnlHeader.SuspendLayout();
			this.pnlClosingYear.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPriority.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvPriority)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActiveQty)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlJobInfo.SuspendLayout();
			this.panel2.SuspendLayout();
			this.ts.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
			this.pnlHeader.Controls.Add(this.chkShowInfo);
			this.pnlHeader.Controls.Add(this.label2);
			this.pnlHeader.Controls.Add(this.btnLoadJobData);
			this.pnlHeader.Controls.Add(this.cbxJobCat);
			this.pnlHeader.Controls.Add(this.lbJobCat);
			this.pnlHeader.Controls.Add(this.pnlClosingYear);
			this.pnlHeader.Controls.Add(this.btnClose);
			this.pnlHeader.Controls.Add(this.cbxJobStatus);
			this.pnlHeader.Controls.Add(this.lbStatus);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(2, 2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
			this.pnlHeader.Size = new System.Drawing.Size(1068, 35);
			this.pnlHeader.TabIndex = 1;
			// 
			// chkShowInfo
			// 
			this.chkShowInfo.AutoSize = true;
			this.chkShowInfo.Checked = true;
			this.chkShowInfo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowInfo.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkShowInfo.ForeColor = System.Drawing.Color.Orange;
			this.chkShowInfo.Location = new System.Drawing.Point(877, 5);
			this.chkShowInfo.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
			this.chkShowInfo.Name = "chkShowInfo";
			this.chkShowInfo.Size = new System.Drawing.Size(87, 25);
			this.chkShowInfo.TabIndex = 21;
			this.chkShowInfo.Text = "Show Info.";
			this.chkShowInfo.UseVisualStyleBackColor = true;
			this.chkShowInfo.CheckedChanged += new System.EventHandler(this.chkShowInfo_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(803, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 25);
			this.label2.TabIndex = 20;
			// 
			// btnLoadJobData
			// 
			this.btnLoadJobData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadJobData.FlatAppearance.BorderSize = 0;
			this.btnLoadJobData.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnLoadJobData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnLoadJobData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadJobData.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadJobData.Image")));
			this.btnLoadJobData.Location = new System.Drawing.Point(778, 5);
			this.btnLoadJobData.Name = "btnLoadJobData";
			this.btnLoadJobData.Size = new System.Drawing.Size(25, 25);
			this.btnLoadJobData.TabIndex = 18;
			this.tTip.SetToolTip(this.btnLoadJobData, "Load Data");
			this.btnLoadJobData.UseVisualStyleBackColor = true;
			this.btnLoadJobData.Click += new System.EventHandler(this.btnLoadJobData_Click);
			// 
			// cbxJobCat
			// 
			this.cbxJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobCat.FormattingEnabled = true;
			this.cbxJobCat.Location = new System.Drawing.Point(653, 5);
			this.cbxJobCat.Name = "cbxJobCat";
			this.cbxJobCat.Size = new System.Drawing.Size(125, 25);
			this.cbxJobCat.TabIndex = 17;
			this.cbxJobCat.SelectionChangeCommitted += new System.EventHandler(this.cbxJobCat_SelectionChangeCommitted);
			// 
			// lbJobCat
			// 
			this.lbJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobCat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobCat.ForeColor = System.Drawing.Color.White;
			this.lbJobCat.Location = new System.Drawing.Point(506, 5);
			this.lbJobCat.Name = "lbJobCat";
			this.lbJobCat.Size = new System.Drawing.Size(147, 25);
			this.lbJobCat.TabIndex = 16;
			this.lbJobCat.Text = "ประเภทงานหล่อ [X] :";
			this.lbJobCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlClosingYear
			// 
			this.pnlClosingYear.Controls.Add(this.cbxMonth);
			this.pnlClosingYear.Controls.Add(this.lbJobMonth);
			this.pnlClosingYear.Controls.Add(this.cbxYear);
			this.pnlClosingYear.Controls.Add(this.lbYear);
			this.pnlClosingYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlClosingYear.Location = new System.Drawing.Point(191, 5);
			this.pnlClosingYear.Name = "pnlClosingYear";
			this.pnlClosingYear.Size = new System.Drawing.Size(315, 25);
			this.pnlClosingYear.TabIndex = 15;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(196, 0);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(102, 25);
			this.cbxMonth.TabIndex = 14;
			this.cbxMonth.SelectionChangeCommitted += new System.EventHandler(this.cbxMonth_SelectionChangeCommitted);
			// 
			// lbJobMonth
			// 
			this.lbJobMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobMonth.ForeColor = System.Drawing.Color.White;
			this.lbJobMonth.Location = new System.Drawing.Point(127, 0);
			this.lbJobMonth.Name = "lbJobMonth";
			this.lbJobMonth.Size = new System.Drawing.Size(69, 25);
			this.lbJobMonth.TabIndex = 13;
			this.lbJobMonth.Text = "เดือน :";
			this.lbJobMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(52, 0);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(75, 25);
			this.cbxYear.TabIndex = 12;
			this.cbxYear.SelectionChangeCommitted += new System.EventHandler(this.cbxYear_SelectionChangeCommitted);
			// 
			// lbYear
			// 
			this.lbYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbYear.ForeColor = System.Drawing.Color.White;
			this.lbYear.Location = new System.Drawing.Point(0, 0);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(52, 25);
			this.lbYear.TabIndex = 7;
			this.lbYear.Text = "ปี :";
			this.lbYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(964, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(94, 25);
			this.btnClose.TabIndex = 14;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// cbxJobStatus
			// 
			this.cbxJobStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobStatus.FormattingEnabled = true;
			this.cbxJobStatus.Location = new System.Drawing.Point(91, 5);
			this.cbxJobStatus.Name = "cbxJobStatus";
			this.cbxJobStatus.Size = new System.Drawing.Size(100, 25);
			this.cbxJobStatus.TabIndex = 11;
			this.cbxJobStatus.SelectionChangeCommitted += new System.EventHandler(this.cbxJobStatus_SelectionChangeCommitted);
			// 
			// lbStatus
			// 
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStatus.ForeColor = System.Drawing.Color.White;
			this.lbStatus.Location = new System.Drawing.Point(10, 5);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(81, 25);
			this.lbStatus.TabIndex = 10;
			this.lbStatus.Text = "Status [0]:";
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.pnlPriority);
			this.panel1.Controls.Add(this.dgvActiveQty);
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(879, 37);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(191, 516);
			this.panel1.TabIndex = 2;
			// 
			// pnlPriority
			// 
			this.pnlPriority.Controls.Add(this.dgvPriority);
			this.pnlPriority.Controls.Add(this.label1);
			this.pnlPriority.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlPriority.Location = new System.Drawing.Point(5, 339);
			this.pnlPriority.Name = "pnlPriority";
			this.pnlPriority.Padding = new System.Windows.Forms.Padding(2);
			this.pnlPriority.Size = new System.Drawing.Size(181, 142);
			this.pnlPriority.TabIndex = 11;
			// 
			// dgvPriority
			// 
			this.dgvPriority.BackgroundColor = System.Drawing.Color.White;
			this.dgvPriority.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPriority.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvPriority.Location = new System.Drawing.Point(2, 30);
			this.dgvPriority.Name = "dgvPriority";
			this.dgvPriority.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvPriority.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dgvPriority.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.dgvPriority.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.dgvPriority.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvPriority.Size = new System.Drawing.Size(177, 110);
			this.dgvPriority.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 28);
			this.label1.TabIndex = 1;
			this.label1.Text = "Priority";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvActiveQty
			// 
			this.dgvActiveQty.BackgroundColor = System.Drawing.Color.White;
			this.dgvActiveQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvActiveQty.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgvActiveQty.Location = new System.Drawing.Point(5, 218);
			this.dgvActiveQty.Name = "dgvActiveQty";
			this.dgvActiveQty.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvActiveQty.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dgvActiveQty.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.dgvActiveQty.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
			this.dgvActiveQty.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvActiveQty.Size = new System.Drawing.Size(181, 121);
			this.dgvActiveQty.TabIndex = 10;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.lbSummaryHeader);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(5, 188);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(181, 30);
			this.panel5.TabIndex = 1;
			// 
			// lbSummaryHeader
			// 
			this.lbSummaryHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbSummaryHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSummaryHeader.Location = new System.Drawing.Point(0, 0);
			this.lbSummaryHeader.Name = "lbSummaryHeader";
			this.lbSummaryHeader.Size = new System.Drawing.Size(179, 28);
			this.lbSummaryHeader.TabIndex = 0;
			this.lbSummaryHeader.Text = "Actie QTY. by CAT.";
			this.lbSummaryHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.pic);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 5);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(3);
			this.panel4.Size = new System.Drawing.Size(181, 183);
			this.panel4.TabIndex = 0;
			// 
			// pic
			// 
			this.pic.BackColor = System.Drawing.Color.White;
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pic.Location = new System.Drawing.Point(3, 3);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(173, 175);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Controls.Add(this.pnlJobInfo);
			this.panel3.Controls.Add(this.ts);
			this.panel3.Controls.Add(this.panel7);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(2, 37);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(5);
			this.panel3.Size = new System.Drawing.Size(877, 516);
			this.panel3.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 50);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(867, 385);
			this.dgv.TabIndex = 4;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlJobInfo
			// 
			this.pnlJobInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.pnlJobInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlJobInfo.Controls.Add(this.panel2);
			this.pnlJobInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlJobInfo.Location = new System.Drawing.Point(5, 435);
			this.pnlJobInfo.Name = "pnlJobInfo";
			this.pnlJobInfo.Padding = new System.Windows.Forms.Padding(5);
			this.pnlJobInfo.Size = new System.Drawing.Size(867, 46);
			this.pnlJobInfo.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCast);
			this.panel2.Controls.Add(this.lbTree);
			this.panel2.Controls.Add(this.lbFinishing);
			this.panel2.Controls.Add(this.lbWax);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.Location = new System.Drawing.Point(5, 5);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(855, 34);
			this.panel2.TabIndex = 0;
			// 
			// lbCast
			// 
			this.lbCast.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCast.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCast.ForeColor = System.Drawing.Color.Yellow;
			this.lbCast.Location = new System.Drawing.Point(538, 1);
			this.lbCast.Name = "lbCast";
			this.lbCast.Size = new System.Drawing.Size(179, 32);
			this.lbCast.TabIndex = 3;
			this.lbCast.Text = "หล่องาน : 0";
			this.lbCast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbTree
			// 
			this.lbTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTree.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTree.ForeColor = System.Drawing.Color.Yellow;
			this.lbTree.Location = new System.Drawing.Point(359, 1);
			this.lbTree.Name = "lbTree";
			this.lbTree.Size = new System.Drawing.Size(179, 32);
			this.lbTree.TabIndex = 2;
			this.lbTree.Text = "ติดต้น : 0";
			this.lbTree.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbFinishing
			// 
			this.lbFinishing.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbFinishing.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFinishing.ForeColor = System.Drawing.Color.Yellow;
			this.lbFinishing.Location = new System.Drawing.Point(180, 1);
			this.lbFinishing.Name = "lbFinishing";
			this.lbFinishing.Size = new System.Drawing.Size(179, 32);
			this.lbFinishing.TabIndex = 1;
			this.lbFinishing.Text = "แต่งเทียน  : 0";
			this.lbFinishing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbWax
			// 
			this.lbWax.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWax.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWax.ForeColor = System.Drawing.Color.Yellow;
			this.lbWax.Location = new System.Drawing.Point(1, 1);
			this.lbWax.Name = "lbWax";
			this.lbWax.Size = new System.Drawing.Size(179, 32);
			this.lbWax.TabIndex = 0;
			this.lbWax.Text = "ฉีดเทียน : 0";
			this.lbWax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbWax.Click += new System.EventHandler(this.lbWax_Click);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.BackColor = System.Drawing.SystemColors.Control;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.toolStripSeparator1,
            this.tsbtnEdit,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnFindJob,
            this.toolStripSeparator4,
            this.tsbtnPrint,
            this.toolStripSeparator5,
            this.tsbtnJobProgress,
            this.toolStripSeparator6,
            this.tsbtnJobInfo,
            this.toolStripSeparator7});
			this.ts.Location = new System.Drawing.Point(5, 5);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(867, 45);
			this.ts.TabIndex = 1;
			this.ts.Text = "toolStrip1";
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(90, 45);
			this.tsbtnAdd.Text = "เพิ่มงานใหม่";
			this.tsbtnAdd.ToolTipText = "Add job";
			this.tsbtnAdd.Visible = false;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			this.toolStripSeparator1.Visible = false;
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.WRENCH;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(90, 45);
			this.tsbtnEdit.Text = "แก้ไชใบงาน";
			this.tsbtnEdit.ToolTipText = "Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(45, 45);
			this.tsbtnRefresh.ToolTipText = "Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.btnLoadJobData_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnFindJob
			// 
			this.tsbtnFindJob.AutoSize = false;
			this.tsbtnFindJob.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindByJobNo,
            this.mnuFindByCustomerName});
			this.tsbtnFindJob.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.tsbtnFindJob.Image = global::OMW15.Properties.Resources.Filter2HS;
			this.tsbtnFindJob.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFindJob.Name = "tsbtnFindJob";
			this.tsbtnFindJob.Size = new System.Drawing.Size(100, 45);
			this.tsbtnFindJob.Text = "ค้นหา";
			this.tsbtnFindJob.ToolTipText = "Filter";
			// 
			// mnuFindByJobNo
			// 
			this.mnuFindByJobNo.Name = "mnuFindByJobNo";
			this.mnuFindByJobNo.Size = new System.Drawing.Size(152, 22);
			this.mnuFindByJobNo.Tag = "BY_JOB";
			this.mnuFindByJobNo.Text = "หมายเลขใบงาน";
			this.mnuFindByJobNo.Click += new System.EventHandler(this.mnuFindJob_Click);
			// 
			// mnuFindByCustomerName
			// 
			this.mnuFindByCustomerName.Name = "mnuFindByCustomerName";
			this.mnuFindByCustomerName.Size = new System.Drawing.Size(152, 22);
			this.mnuFindByCustomerName.Tag = "BY_CUS";
			this.mnuFindByCustomerName.Text = "ชื่อลูกค้า";
			this.mnuFindByCustomerName.Click += new System.EventHandler(this.mnuFindJob_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnPrint
			// 
			this.tsbtnPrint.AutoSize = false;
			this.tsbtnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.tsbtnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrint.Name = "tsbtnPrint";
			this.tsbtnPrint.Size = new System.Drawing.Size(100, 45);
			this.tsbtnPrint.Text = "Print Job";
			this.tsbtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnJobProgress
			// 
			this.tsbtnJobProgress.AutoSize = false;
			this.tsbtnJobProgress.Image = global::OMW15.Properties.Resources.graphhs;
			this.tsbtnJobProgress.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnJobProgress.Name = "tsbtnJobProgress";
			this.tsbtnJobProgress.Size = new System.Drawing.Size(140, 45);
			this.tsbtnJobProgress.Text = "งานค้าง (Progress)";
			this.tsbtnJobProgress.ToolTipText = "Job progress";
			this.tsbtnJobProgress.Click += new System.EventHandler(this.tsbtnJobProgress_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnJobInfo
			// 
			this.tsbtnJobInfo.AutoSize = false;
			this.tsbtnJobInfo.Image = global::OMW15.Properties.Resources.CommentHS;
			this.tsbtnJobInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnJobInfo.Name = "tsbtnJobInfo";
			this.tsbtnJobInfo.Size = new System.Drawing.Size(131, 42);
			this.tsbtnJobInfo.Text = "บันทึกรายละเอียดงาน";
			this.tsbtnJobInfo.ToolTipText = "Job Info.";
			this.tsbtnJobInfo.Click += new System.EventHandler(this.tsbtnJobInfo_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lbJobOrder);
			this.panel7.Controls.Add(this.lbJobInfo);
			this.panel7.Controls.Add(this.lbCustomerCode);
			this.panel7.Controls.Add(this.lbSelectedJobId);
			this.panel7.Controls.Add(this.lbFoundRecords);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(5, 481);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(867, 30);
			this.panel7.TabIndex = 0;
			// 
			// lbJobOrder
			// 
			this.lbJobOrder.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobOrder.Location = new System.Drawing.Point(548, 2);
			this.lbJobOrder.Name = "lbJobOrder";
			this.lbJobOrder.Size = new System.Drawing.Size(123, 26);
			this.lbJobOrder.TabIndex = 4;
			this.lbJobOrder.Text = "Job Order (0)";
			this.lbJobOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbJobInfo
			// 
			this.lbJobInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobInfo.Location = new System.Drawing.Point(425, 2);
			this.lbJobInfo.Name = "lbJobInfo";
			this.lbJobInfo.Size = new System.Drawing.Size(123, 26);
			this.lbJobInfo.TabIndex = 3;
			this.lbJobInfo.Text = "JobInfos(0)";
			this.lbJobInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbCustomerCode
			// 
			this.lbCustomerCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomerCode.Location = new System.Drawing.Point(263, 2);
			this.lbCustomerCode.Name = "lbCustomerCode";
			this.lbCustomerCode.Size = new System.Drawing.Size(162, 26);
			this.lbCustomerCode.TabIndex = 2;
			this.lbCustomerCode.Text = "(0) :: xxxxx";
			this.lbCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbSelectedJobId
			// 
			this.lbSelectedJobId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedJobId.Location = new System.Drawing.Point(140, 2);
			this.lbSelectedJobId.Name = "lbSelectedJobId";
			this.lbSelectedJobId.Size = new System.Drawing.Size(123, 26);
			this.lbSelectedJobId.TabIndex = 1;
			this.lbSelectedJobId.Text = "Job Id :: 0";
			this.lbSelectedJobId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbFoundRecords
			// 
			this.lbFoundRecords.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbFoundRecords.Location = new System.Drawing.Point(2, 2);
			this.lbFoundRecords.Name = "lbFoundRecords";
			this.lbFoundRecords.Size = new System.Drawing.Size(138, 26);
			this.lbFoundRecords.TabIndex = 0;
			this.lbFoundRecords.Text = "found :: 0";
			this.lbFoundRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CTJobs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1072, 555);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CTJobs";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "CASTING JOBS";
			this.Load += new System.EventHandler(this.CTJobs_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlClosingYear.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlPriority.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvPriority)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActiveQty)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlJobInfo.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label lbSummaryHeader;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.DataGridView dgvActiveQty;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.ComboBox cbxJobStatus;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.ToolStripSplitButton tsbtnFindJob;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnJobInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton tsbtnJobProgress;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem mnuFindByJobNo;
		private System.Windows.Forms.ToolStripMenuItem mnuFindByCustomerName;
		private System.Windows.Forms.Label lbJobOrder;
		private System.Windows.Forms.Label lbJobInfo;
		private System.Windows.Forms.Label lbCustomerCode;
		private System.Windows.Forms.Label lbSelectedJobId;
		private System.Windows.Forms.Label lbFoundRecords;
		private System.Windows.Forms.ToolTip tTip;
		private System.Windows.Forms.Button btnClose;
		private OMControls.OMFlatButton btnLoadJobData;
		private System.Windows.Forms.ComboBox cbxJobCat;
		private System.Windows.Forms.Label lbJobCat;
		private System.Windows.Forms.Panel pnlClosingYear;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label lbYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label lbJobMonth;
		private System.Windows.Forms.ToolStripButton tsbtnPrint;
        private System.Windows.Forms.CheckBox chkShowInfo;
        private System.Windows.Forms.Panel pnlJobInfo;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbTree;
        private System.Windows.Forms.Label lbFinishing;
        private System.Windows.Forms.Label lbWax;
        private System.Windows.Forms.Panel pnlPriority;
        private System.Windows.Forms.DataGridView dgvPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCast;
    }
}