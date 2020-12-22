namespace OMW15.Views.ServiceView
{
	partial class MCInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCInfo));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSearch = new System.Windows.Forms.Button();
			this.pnlCustomer = new System.Windows.Forms.Panel();
			this.txtCustomerFilter = new System.Windows.Forms.TextBox();
			this.chkCustomer = new System.Windows.Forms.CheckBox();
			this.pnlSerial = new System.Windows.Forms.Panel();
			this.txtSNFilter = new System.Windows.Forms.TextBox();
			this.chkSN = new System.Windows.Forms.CheckBox();
			this.pnlModel = new System.Windows.Forms.Panel();
			this.cbxModel = new System.Windows.Forms.ComboBox();
			this.chkModel = new System.Windows.Forms.CheckBox();
			this.pnlInfo = new System.Windows.Forms.Panel();
			this.pnlMCList = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.lbSN = new System.Windows.Forms.Label();
			this.lbModel = new System.Windows.Forms.Label();
			this.lbMCId = new System.Windows.Forms.Label();
			this.lbFound = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlJobHistory = new System.Windows.Forms.Panel();
			this.dgvJobs = new System.Windows.Forms.DataGridView();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbCountJobs = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlToolBar = new System.Windows.Forms.Panel();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnMCRegister = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDeleteMCRecord = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnMCInfo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnMCHistory = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuJobHistory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAllJobHistories = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPM = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnOpenServiceJob = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnProduct = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlCustomer.SuspendLayout();
			this.pnlSerial.SuspendLayout();
			this.pnlModel.SuspendLayout();
			this.pnlInfo.SuspendLayout();
			this.pnlMCList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel5.SuspendLayout();
			this.pnlJobHistory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
			this.panel7.SuspendLayout();
			this.pnlToolBar.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTop.Controls.Add(this.panel2);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(3, 3);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(1145, 44);
			this.pnlTop.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSearch);
			this.panel2.Controls.Add(this.pnlCustomer);
			this.panel2.Controls.Add(this.pnlSerial);
			this.panel2.Controls.Add(this.pnlModel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(1139, 37);
			this.panel2.TabIndex = 0;
			// 
			// btnSearch
			// 
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSearch.Location = new System.Drawing.Point(825, 2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(96, 33);
			this.btnSearch.TabIndex = 6;
			this.btnSearch.Text = "ค้นหา";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// pnlCustomer
			// 
			this.pnlCustomer.Controls.Add(this.txtCustomerFilter);
			this.pnlCustomer.Controls.Add(this.chkCustomer);
			this.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlCustomer.Location = new System.Drawing.Point(527, 2);
			this.pnlCustomer.Name = "pnlCustomer";
			this.pnlCustomer.Padding = new System.Windows.Forms.Padding(3);
			this.pnlCustomer.Size = new System.Drawing.Size(298, 33);
			this.pnlCustomer.TabIndex = 5;
			// 
			// txtCustomerFilter
			// 
			this.txtCustomerFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCustomerFilter.Location = new System.Drawing.Point(86, 3);
			this.txtCustomerFilter.MaxLength = 50;
			this.txtCustomerFilter.Name = "txtCustomerFilter";
			this.txtCustomerFilter.Size = new System.Drawing.Size(209, 25);
			this.txtCustomerFilter.TabIndex = 2;
			this.txtCustomerFilter.TextChanged += new System.EventHandler(this.txtCustomerFilter_TextChanged);
			this.txtCustomerFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
			// 
			// chkCustomer
			// 
			this.chkCustomer.AutoSize = true;
			this.chkCustomer.Checked = true;
			this.chkCustomer.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkCustomer.Location = new System.Drawing.Point(3, 3);
			this.chkCustomer.Name = "chkCustomer";
			this.chkCustomer.Size = new System.Drawing.Size(83, 27);
			this.chkCustomer.TabIndex = 1;
			this.chkCustomer.Text = "Customer";
			this.chkCustomer.UseVisualStyleBackColor = true;
			this.chkCustomer.CheckedChanged += new System.EventHandler(this.chkCustomer_CheckedChanged);
			// 
			// pnlSerial
			// 
			this.pnlSerial.Controls.Add(this.txtSNFilter);
			this.pnlSerial.Controls.Add(this.chkSN);
			this.pnlSerial.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSerial.Location = new System.Drawing.Point(305, 2);
			this.pnlSerial.Name = "pnlSerial";
			this.pnlSerial.Padding = new System.Windows.Forms.Padding(3);
			this.pnlSerial.Size = new System.Drawing.Size(222, 33);
			this.pnlSerial.TabIndex = 4;
			// 
			// txtSNFilter
			// 
			this.txtSNFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSNFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSNFilter.Location = new System.Drawing.Point(87, 3);
			this.txtSNFilter.MaxLength = 25;
			this.txtSNFilter.Name = "txtSNFilter";
			this.txtSNFilter.Size = new System.Drawing.Size(132, 25);
			this.txtSNFilter.TabIndex = 2;
			this.txtSNFilter.TextChanged += new System.EventHandler(this.txtSNFilter_TextChanged);
			this.txtSNFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
			// 
			// chkSN
			// 
			this.chkSN.AutoSize = true;
			this.chkSN.Checked = true;
			this.chkSN.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSN.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkSN.Location = new System.Drawing.Point(3, 3);
			this.chkSN.Name = "chkSN";
			this.chkSN.Size = new System.Drawing.Size(84, 27);
			this.chkSN.TabIndex = 1;
			this.chkSN.Text = "Serial No.";
			this.chkSN.UseVisualStyleBackColor = true;
			this.chkSN.CheckedChanged += new System.EventHandler(this.chkSN_CheckedChanged);
			// 
			// pnlModel
			// 
			this.pnlModel.Controls.Add(this.cbxModel);
			this.pnlModel.Controls.Add(this.chkModel);
			this.pnlModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlModel.Location = new System.Drawing.Point(2, 2);
			this.pnlModel.Name = "pnlModel";
			this.pnlModel.Padding = new System.Windows.Forms.Padding(3);
			this.pnlModel.Size = new System.Drawing.Size(303, 33);
			this.pnlModel.TabIndex = 3;
			// 
			// cbxModel
			// 
			this.cbxModel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxModel.FormattingEnabled = true;
			this.cbxModel.Location = new System.Drawing.Point(121, 3);
			this.cbxModel.Name = "cbxModel";
			this.cbxModel.Size = new System.Drawing.Size(179, 25);
			this.cbxModel.TabIndex = 2;
			this.cbxModel.SelectionChangeCommitted += new System.EventHandler(this.cbxModel_SelectionChangeCommitted);
			// 
			// chkModel
			// 
			this.chkModel.AutoSize = true;
			this.chkModel.Checked = true;
			this.chkModel.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkModel.Location = new System.Drawing.Point(3, 3);
			this.chkModel.Name = "chkModel";
			this.chkModel.Size = new System.Drawing.Size(118, 27);
			this.chkModel.TabIndex = 1;
			this.chkModel.Text = "Machine Model";
			this.chkModel.UseVisualStyleBackColor = true;
			this.chkModel.CheckedChanged += new System.EventHandler(this.chkModel_CheckedChanged);
			// 
			// pnlInfo
			// 
			this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlInfo.Controls.Add(this.pnlMCList);
			this.pnlInfo.Controls.Add(this.splitter1);
			this.pnlInfo.Controls.Add(this.pnlJobHistory);
			this.pnlInfo.Controls.Add(this.pnlToolBar);
			this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlInfo.Location = new System.Drawing.Point(3, 47);
			this.pnlInfo.Name = "pnlInfo";
			this.pnlInfo.Padding = new System.Windows.Forms.Padding(2);
			this.pnlInfo.Size = new System.Drawing.Size(1145, 514);
			this.pnlInfo.TabIndex = 1;
			// 
			// pnlMCList
			// 
			this.pnlMCList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMCList.Controls.Add(this.dgv);
			this.pnlMCList.Controls.Add(this.panel5);
			this.pnlMCList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMCList.Location = new System.Drawing.Point(2, 47);
			this.pnlMCList.Name = "pnlMCList";
			this.pnlMCList.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMCList.Size = new System.Drawing.Size(583, 463);
			this.pnlMCList.TabIndex = 5;
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
			this.dgv.Location = new System.Drawing.Point(2, 34);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(577, 425);
			this.dgv.TabIndex = 5;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.panel5.Controls.Add(this.lbCustCode);
			this.panel5.Controls.Add(this.lbSN);
			this.panel5.Controls.Add(this.lbModel);
			this.panel5.Controls.Add(this.lbMCId);
			this.panel5.Controls.Add(this.lbFound);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.ForeColor = System.Drawing.Color.White;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(577, 32);
			this.panel5.TabIndex = 4;
			// 
			// lbCustCode
			// 
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustCode.Location = new System.Drawing.Point(452, 2);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(104, 28);
			this.lbCustCode.TabIndex = 5;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lbSN
			// 
			this.lbSN.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSN.Location = new System.Drawing.Point(348, 2);
			this.lbSN.Name = "lbSN";
			this.lbSN.Size = new System.Drawing.Size(104, 28);
			this.lbSN.TabIndex = 4;
			this.lbSN.Text = "SN:";
			this.lbSN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lbModel
			// 
			this.lbModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbModel.Location = new System.Drawing.Point(225, 2);
			this.lbModel.Name = "lbModel";
			this.lbModel.Size = new System.Drawing.Size(123, 28);
			this.lbModel.TabIndex = 3;
			this.lbModel.Text = "Model:";
			this.lbModel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lbMCId
			// 
			this.lbMCId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMCId.Location = new System.Drawing.Point(155, 2);
			this.lbMCId.Name = "lbMCId";
			this.lbMCId.Size = new System.Drawing.Size(70, 28);
			this.lbMCId.TabIndex = 2;
			this.lbMCId.Text = "idx = 0";
			this.lbMCId.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lbFound
			// 
			this.lbFound.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbFound.Location = new System.Drawing.Point(451, 2);
			this.lbFound.Name = "lbFound";
			this.lbFound.Size = new System.Drawing.Size(124, 28);
			this.lbFound.TabIndex = 1;
			this.lbFound.Text = "match = 0";
			this.lbFound.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "รายการเครื่องจักร";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(585, 47);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 463);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			// 
			// pnlJobHistory
			// 
			this.pnlJobHistory.Controls.Add(this.dgvJobs);
			this.pnlJobHistory.Controls.Add(this.panel7);
			this.pnlJobHistory.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlJobHistory.Location = new System.Drawing.Point(591, 47);
			this.pnlJobHistory.Name = "pnlJobHistory";
			this.pnlJobHistory.Padding = new System.Windows.Forms.Padding(2);
			this.pnlJobHistory.Size = new System.Drawing.Size(550, 463);
			this.pnlJobHistory.TabIndex = 3;
			// 
			// dgvJobs
			// 
			this.dgvJobs.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvJobs.Location = new System.Drawing.Point(2, 34);
			this.dgvJobs.Name = "dgvJobs";
			this.dgvJobs.Size = new System.Drawing.Size(546, 427);
			this.dgvJobs.TabIndex = 6;
			this.dgvJobs.VirtualMode = true;
			this.dgvJobs.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJobs_CellEnter);
			this.dgvJobs.DoubleClick += new System.EventHandler(this.dgvJobs_DoubleClick);
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.lbCountJobs);
			this.panel7.Controls.Add(this.label3);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.ForeColor = System.Drawing.Color.White;
			this.panel7.Location = new System.Drawing.Point(2, 2);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(546, 32);
			this.panel7.TabIndex = 5;
			// 
			// lbCountJobs
			// 
			this.lbCountJobs.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbCountJobs.Location = new System.Drawing.Point(437, 2);
			this.lbCountJobs.Name = "lbCountJobs";
			this.lbCountJobs.Size = new System.Drawing.Size(105, 26);
			this.lbCountJobs.TabIndex = 2;
			this.lbCountJobs.Text = "found = 0";
			this.lbCountJobs.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "ประวัติงานซ่อม";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlToolBar
			// 
			this.pnlToolBar.Controls.Add(this.ts);
			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlToolBar.Location = new System.Drawing.Point(2, 2);
			this.pnlToolBar.Name = "pnlToolBar";
			this.pnlToolBar.Padding = new System.Windows.Forms.Padding(2);
			this.pnlToolBar.Size = new System.Drawing.Size(1139, 45);
			this.pnlToolBar.TabIndex = 0;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnMCRegister,
            this.toolStripSeparator2,
            this.tsbtnDeleteMCRecord,
            this.toolStripSeparator3,
            this.tsbtnMCInfo,
            this.toolStripSeparator5,
            this.tsbtnMCHistory,
            this.toolStripSeparator4,
            this.tsbtnPM,
            this.toolStripSeparator8,
            this.tsbtnOpenServiceJob,
            this.toolStripSeparator6,
            this.tsbtnProduct,
            this.toolStripSeparator7,
            this.tsbtnClose,
            this.toolStripSeparator1});
			this.ts.Location = new System.Drawing.Point(2, 2);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(1135, 41);
			this.ts.TabIndex = 0;
			// 
			// tsbtnMCRegister
			// 
			this.tsbtnMCRegister.AutoSize = false;
			this.tsbtnMCRegister.Image = global::OMW15.Properties.Resources.PushpinHS;
			this.tsbtnMCRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnMCRegister.Name = "tsbtnMCRegister";
			this.tsbtnMCRegister.Size = new System.Drawing.Size(65, 44);
			this.tsbtnMCRegister.Text = "ลงทะเบียน";
			this.tsbtnMCRegister.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnMCRegister.Click += new System.EventHandler(this.tsbtnMCRegister_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnDeleteMCRecord
			// 
			this.tsbtnDeleteMCRecord.AutoSize = false;
			this.tsbtnDeleteMCRecord.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDeleteMCRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteMCRecord.Name = "tsbtnDeleteMCRecord";
			this.tsbtnDeleteMCRecord.Size = new System.Drawing.Size(65, 38);
			this.tsbtnDeleteMCRecord.Text = "ลบระเบียน";
			this.tsbtnDeleteMCRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnDeleteMCRecord.Click += new System.EventHandler(this.tsbtnDeleteMCRecord_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnMCInfo
			// 
			this.tsbtnMCInfo.AutoSize = false;
			this.tsbtnMCInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMCInfo.Image")));
			this.tsbtnMCInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnMCInfo.Name = "tsbtnMCInfo";
			this.tsbtnMCInfo.Size = new System.Drawing.Size(85, 44);
			this.tsbtnMCInfo.Text = "ข้อมูลเครื่องจักร";
			this.tsbtnMCInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnMCInfo.Click += new System.EventHandler(this.tsbtnMCInfo_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnMCHistory
			// 
			this.tsbtnMCHistory.AutoSize = false;
			this.tsbtnMCHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJobHistory,
            this.mnuAllJobHistories});
			this.tsbtnMCHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMCHistory.Image")));
			this.tsbtnMCHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnMCHistory.Name = "tsbtnMCHistory";
			this.tsbtnMCHistory.Size = new System.Drawing.Size(100, 44);
			this.tsbtnMCHistory.Text = "ประวัติเครื่องจักร";
			this.tsbtnMCHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// mnuJobHistory
			// 
			this.mnuJobHistory.Name = "mnuJobHistory";
			this.mnuJobHistory.Size = new System.Drawing.Size(172, 22);
			this.mnuJobHistory.Text = "เฉพาะใบงานที่เลือก";
			this.mnuJobHistory.Click += new System.EventHandler(this.mnuJobHistory_Click);
			// 
			// mnuAllJobHistories
			// 
			this.mnuAllJobHistories.Name = "mnuAllJobHistories";
			this.mnuAllJobHistories.Size = new System.Drawing.Size(172, 22);
			this.mnuAllJobHistories.Text = "แสดงทั้งหมดทุกใบงาน";
			this.mnuAllJobHistories.Click += new System.EventHandler(this.mnuAllJobHistories_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnPM
			// 
			this.tsbtnPM.AutoSize = false;
			this.tsbtnPM.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPM.Image")));
			this.tsbtnPM.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPM.Name = "tsbtnPM";
			this.tsbtnPM.Size = new System.Drawing.Size(90, 38);
			this.tsbtnPM.Text = "สัญญางานบริการ";
			this.tsbtnPM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPM.Click += new System.EventHandler(this.tsbtnPM_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnOpenServiceJob
			// 
			this.tsbtnOpenServiceJob.AutoSize = false;
			this.tsbtnOpenServiceJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenServiceJob.Image")));
			this.tsbtnOpenServiceJob.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnOpenServiceJob.Name = "tsbtnOpenServiceJob";
			this.tsbtnOpenServiceJob.Size = new System.Drawing.Size(70, 38);
			this.tsbtnOpenServiceJob.Text = "เปิดใบงาน";
			this.tsbtnOpenServiceJob.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnOpenServiceJob.Click += new System.EventHandler(this.tsbtnOpenServiceJob_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnProduct
			// 
			this.tsbtnProduct.AutoSize = false;
			this.tsbtnProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnProduct.Image")));
			this.tsbtnProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnProduct.Name = "tsbtnProduct";
			this.tsbtnProduct.Size = new System.Drawing.Size(75, 38);
			this.tsbtnProduct.Text = "รายการสินค้า";
			this.tsbtnProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnProduct.Click += new System.EventHandler(this.tsbtnProduct_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(65, 44);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
			// 
			// MCInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1151, 564);
			this.Controls.Add(this.pnlInfo);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MCInfo";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "MACHINES";
			this.Load += new System.EventHandler(this.MCInfo_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlCustomer.ResumeLayout(false);
			this.pnlCustomer.PerformLayout();
			this.pnlSerial.ResumeLayout(false);
			this.pnlSerial.PerformLayout();
			this.pnlModel.ResumeLayout(false);
			this.pnlModel.PerformLayout();
			this.pnlInfo.ResumeLayout(false);
			this.pnlMCList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel5.ResumeLayout(false);
			this.pnlJobHistory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
			this.panel7.ResumeLayout(false);
			this.pnlToolBar.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel pnlCustomer;
		private System.Windows.Forms.CheckBox chkCustomer;
		private System.Windows.Forms.Panel pnlSerial;
		private System.Windows.Forms.CheckBox chkSN;
		private System.Windows.Forms.Panel pnlModel;
		private System.Windows.Forms.CheckBox chkModel;
		private System.Windows.Forms.Panel pnlInfo;
		private System.Windows.Forms.Panel pnlToolBar;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnMCInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnMCRegister;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Panel pnlMCList;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlJobHistory;
		private System.Windows.Forms.DataGridView dgvJobs;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbCountJobs;
		private System.Windows.Forms.Label lbFound;
		private System.Windows.Forms.ToolStripSplitButton tsbtnMCHistory;
		private System.Windows.Forms.ToolStripMenuItem mnuJobHistory;
		private System.Windows.Forms.ToolStripMenuItem mnuAllJobHistories;
		private System.Windows.Forms.Label lbMCId;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteMCRecord;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnOpenServiceJob;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbtnProduct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tsbtnPM;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.TextBox txtCustomerFilter;
		private System.Windows.Forms.TextBox txtSNFilter;
		private System.Windows.Forms.ComboBox cbxModel;
        private System.Windows.Forms.Label lbSN;
        private System.Windows.Forms.Label lbModel;
        private System.Windows.Forms.Label lbCustCode;
    }
}