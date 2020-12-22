namespace OMW15.Views.CastingView
{
	partial class MaterialClearing
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialClearing));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.btnFindCustomer = new OMControls.OMFlatButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCustomerName = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbCustomerCode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgvMatchIssue = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnConfirmClearing = new System.Windows.Forms.Button();
			this.btnMatch = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbTotalClearing = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlGRVMain = new System.Windows.Forms.Panel();
			this.pnlGRVList = new System.Windows.Forms.Panel();
			this.dgvGRV = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbMatchItems = new System.Windows.Forms.Label();
			this.lbRefSO = new System.Windows.Forms.Label();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnMatReceive = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbStockRemainWeight = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbPendingWeight = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnTotalReceiveMat = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnlClearingList = new System.Windows.Forms.Panel();
			this.dgvClearList = new System.Windows.Forms.DataGridView();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbTotalReturnWeight = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlTop.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMatchIssue)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlGRVMain.SuspendLayout();
			this.pnlGRVList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGRV)).BeginInit();
			this.panel5.SuspendLayout();
			this.ts.SuspendLayout();
			this.pnlClearingList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClearList)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.pnlBody);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(5);
			this.pnlTop.Size = new System.Drawing.Size(1024, 40);
			this.pnlTop.TabIndex = 0;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.btnFindCustomer);
			this.pnlBody.Controls.Add(this.label2);
			this.pnlBody.Controls.Add(this.txtCustomerName);
			this.pnlBody.Controls.Add(this.btnClose);
			this.pnlBody.Controls.Add(this.lbCustomerCode);
			this.pnlBody.Controls.Add(this.label1);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBody.Location = new System.Drawing.Point(5, 5);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(1014, 30);
			this.pnlBody.TabIndex = 0;
			// 
			// btnFindCustomer
			// 
			this.btnFindCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFindCustomer.FlatAppearance.BorderSize = 0;
			this.btnFindCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnFindCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnFindCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFindCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnFindCustomer.Image")));
			this.btnFindCustomer.Location = new System.Drawing.Point(553, 2);
			this.btnFindCustomer.Name = "btnFindCustomer";
			this.btnFindCustomer.Size = new System.Drawing.Size(26, 26);
			this.btnFindCustomer.TabIndex = 10;
			this.btnFindCustomer.UseVisualStyleBackColor = true;
			this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(543, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 26);
			this.label2.TabIndex = 9;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomerName.Location = new System.Drawing.Point(157, 2);
			this.txtCustomerName.MaxLength = 100;
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(386, 25);
			this.txtCustomerName.TabIndex = 7;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(912, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(100, 26);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbCustomerCode
			// 
			this.lbCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCustomerCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomerCode.Location = new System.Drawing.Point(75, 2);
			this.lbCustomerCode.Name = "lbCustomerCode";
			this.lbCustomerCode.Size = new System.Drawing.Size(82, 26);
			this.lbCustomerCode.TabIndex = 3;
			this.lbCustomerCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Customer :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dgvMatchIssue);
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 377);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(1024, 178);
			this.panel1.TabIndex = 1;
			// 
			// dgvMatchIssue
			// 
			this.dgvMatchIssue.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvMatchIssue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMatchIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMatchIssue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMatchIssue.Location = new System.Drawing.Point(2, 36);
			this.dgvMatchIssue.Name = "dgvMatchIssue";
			this.dgvMatchIssue.Size = new System.Drawing.Size(1018, 110);
			this.dgvMatchIssue.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnConfirmClearing);
			this.panel3.Controls.Add(this.btnMatch);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1018, 34);
			this.panel3.TabIndex = 1;
			// 
			// btnConfirmClearing
			// 
			this.btnConfirmClearing.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnConfirmClearing.Location = new System.Drawing.Point(174, 0);
			this.btnConfirmClearing.Name = "btnConfirmClearing";
			this.btnConfirmClearing.Size = new System.Drawing.Size(137, 34);
			this.btnConfirmClearing.TabIndex = 1;
			this.btnConfirmClearing.Text = "ยืนยัน";
			this.btnConfirmClearing.UseVisualStyleBackColor = true;
			this.btnConfirmClearing.Click += new System.EventHandler(this.btnConfirmClearing_Click);
			// 
			// btnMatch
			// 
			this.btnMatch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnMatch.Location = new System.Drawing.Point(0, 0);
			this.btnMatch.Name = "btnMatch";
			this.btnMatch.Size = new System.Drawing.Size(174, 34);
			this.btnMatch.TabIndex = 0;
			this.btnMatch.Text = "กระทบยอดค้างวัสดุ";
			this.btnMatch.UseVisualStyleBackColor = true;
			this.btnMatch.Click += new System.EventHandler(this.btnMatch_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbTotalClearing);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(2, 146);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(1018, 28);
			this.panel2.TabIndex = 0;
			// 
			// lbTotalClearing
			// 
			this.lbTotalClearing.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTotalClearing.Location = new System.Drawing.Point(1, 1);
			this.lbTotalClearing.Name = "lbTotalClearing";
			this.lbTotalClearing.Size = new System.Drawing.Size(200, 26);
			this.lbTotalClearing.TabIndex = 0;
			this.lbTotalClearing.Text = "Total Clearing : 0.00";
			this.lbTotalClearing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 371);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1024, 6);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// pnlGRVMain
			// 
			this.pnlGRVMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGRVMain.Controls.Add(this.pnlGRVList);
			this.pnlGRVMain.Controls.Add(this.splitter2);
			this.pnlGRVMain.Controls.Add(this.pnlClearingList);
			this.pnlGRVMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGRVMain.Location = new System.Drawing.Point(0, 40);
			this.pnlGRVMain.Name = "pnlGRVMain";
			this.pnlGRVMain.Padding = new System.Windows.Forms.Padding(2);
			this.pnlGRVMain.Size = new System.Drawing.Size(1024, 331);
			this.pnlGRVMain.TabIndex = 3;
			// 
			// pnlGRVList
			// 
			this.pnlGRVList.Controls.Add(this.dgvGRV);
			this.pnlGRVList.Controls.Add(this.panel5);
			this.pnlGRVList.Controls.Add(this.ts);
			this.pnlGRVList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGRVList.Location = new System.Drawing.Point(2, 2);
			this.pnlGRVList.Name = "pnlGRVList";
			this.pnlGRVList.Padding = new System.Windows.Forms.Padding(1);
			this.pnlGRVList.Size = new System.Drawing.Size(698, 325);
			this.pnlGRVList.TabIndex = 5;
			// 
			// dgvGRV
			// 
			this.dgvGRV.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvGRV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvGRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGRV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGRV.Location = new System.Drawing.Point(1, 36);
			this.dgvGRV.Name = "dgvGRV";
			this.dgvGRV.Size = new System.Drawing.Size(696, 260);
			this.dgvGRV.TabIndex = 7;
			this.dgvGRV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGRV_CellEnter);
			this.dgvGRV.SelectionChanged += new System.EventHandler(this.dgvGRV_SelectionChanged);
			this.dgvGRV.DoubleClick += new System.EventHandler(this.dgvGRV_DoubleClick);
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.lbMatchItems);
			this.panel5.Controls.Add(this.lbRefSO);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(1, 296);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(696, 28);
			this.panel5.TabIndex = 6;
			// 
			// lbMatchItems
			// 
			this.lbMatchItems.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMatchItems.Location = new System.Drawing.Point(96, 1);
			this.lbMatchItems.Name = "lbMatchItems";
			this.lbMatchItems.Size = new System.Drawing.Size(95, 24);
			this.lbMatchItems.TabIndex = 2;
			this.lbMatchItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbRefSO
			// 
			this.lbRefSO.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRefSO.Location = new System.Drawing.Point(1, 1);
			this.lbRefSO.Name = "lbRefSO";
			this.lbRefSO.Size = new System.Drawing.Size(95, 24);
			this.lbRefSO.TabIndex = 1;
			this.lbRefSO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.toolStripSeparator1,
            this.tsbtnMatReceive,
            this.toolStripSeparator2,
            this.tsbtnEdit,
            this.toolStripSeparator3,
            this.tslbStockRemainWeight,
            this.toolStripSeparator4,
            this.tslbPendingWeight,
            this.toolStripSeparator5,
            this.tsbtnTotalReceiveMat,
            this.toolStripSeparator6});
			this.ts.Location = new System.Drawing.Point(1, 1);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(696, 35);
			this.ts.TabIndex = 5;
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(75, 29);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.AutoSize = false;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnMatReceive
			// 
			this.tsbtnMatReceive.AutoSize = false;
			this.tsbtnMatReceive.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMatReceive.Image")));
			this.tsbtnMatReceive.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnMatReceive.Name = "tsbtnMatReceive";
			this.tsbtnMatReceive.Size = new System.Drawing.Size(75, 32);
			this.tsbtnMatReceive.Text = "รับวัสดุ";
			this.tsbtnMatReceive.Click += new System.EventHandler(this.tsbtnMatReceive_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.AutoSize = false;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEdit.Image")));
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(75, 32);
			this.tsbtnEdit.Text = "แก้ไข";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// tslbStockRemainWeight
			// 
			this.tslbStockRemainWeight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbStockRemainWeight.Name = "tslbStockRemainWeight";
			this.tslbStockRemainWeight.Size = new System.Drawing.Size(106, 32);
			this.tslbStockRemainWeight.Text = "Stock (กรัม) : 0.00";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 35);
			// 
			// tslbPendingWeight
			// 
			this.tslbPendingWeight.Name = "tslbPendingWeight";
			this.tslbPendingWeight.Size = new System.Drawing.Size(81, 32);
			this.tslbPendingWeight.Text = "Pending : 0.00";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 35);
			// 
			// tsbtnTotalReceiveMat
			// 
			this.tsbtnTotalReceiveMat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnTotalReceiveMat.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTotalReceiveMat.Image")));
			this.tsbtnTotalReceiveMat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnTotalReceiveMat.Name = "tsbtnTotalReceiveMat";
			this.tsbtnTotalReceiveMat.Size = new System.Drawing.Size(80, 32);
			this.tsbtnTotalReceiveMat.Text = "Total Receive";
			this.tsbtnTotalReceiveMat.Click += new System.EventHandler(this.tsbtnTotalReceiveMat_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(700, 2);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(6, 325);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// pnlClearingList
			// 
			this.pnlClearingList.Controls.Add(this.dgvClearList);
			this.pnlClearingList.Controls.Add(this.panel7);
			this.pnlClearingList.Controls.Add(this.panel6);
			this.pnlClearingList.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlClearingList.Location = new System.Drawing.Point(706, 2);
			this.pnlClearingList.Name = "pnlClearingList";
			this.pnlClearingList.Padding = new System.Windows.Forms.Padding(1);
			this.pnlClearingList.Size = new System.Drawing.Size(314, 325);
			this.pnlClearingList.TabIndex = 2;
			// 
			// dgvClearList
			// 
			this.dgvClearList.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvClearList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvClearList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClearList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvClearList.Location = new System.Drawing.Point(1, 36);
			this.dgvClearList.Name = "dgvClearList";
			this.dgvClearList.Size = new System.Drawing.Size(312, 260);
			this.dgvClearList.TabIndex = 8;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.lbTotalReturnWeight);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(1, 296);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(312, 28);
			this.panel7.TabIndex = 7;
			// 
			// lbTotalReturnWeight
			// 
			this.lbTotalReturnWeight.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalReturnWeight.Location = new System.Drawing.Point(101, 1);
			this.lbTotalReturnWeight.Name = "lbTotalReturnWeight";
			this.lbTotalReturnWeight.Size = new System.Drawing.Size(208, 24);
			this.lbTotalReturnWeight.TabIndex = 0;
			this.lbTotalReturnWeight.Text = "รวมน้ำหนักที่คืน (กรัม) : 0.00";
			this.lbTotalReturnWeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel6.Controls.Add(this.label3);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel6.ForeColor = System.Drawing.Color.White;
			this.panel6.Location = new System.Drawing.Point(1, 1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(312, 35);
			this.panel6.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(312, 35);
			this.label3.TabIndex = 0;
			this.label3.Text = "รายการใบส่งของที่คืนวัสดุ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaterialClearing
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 555);
			this.Controls.Add(this.pnlGRVMain);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialClearing";
			this.Text = "MATERIAL RECEIVE";
			this.Load += new System.EventHandler(this.MaterialClearing_Load);
			this.pnlTop.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			this.pnlBody.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMatchIssue)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlGRVMain.ResumeLayout(false);
			this.pnlGRVList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGRV)).EndInit();
			this.panel5.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlClearingList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvClearList)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlGRVMain;
		private System.Windows.Forms.Panel pnlGRVList;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pnlClearingList;
		private System.Windows.Forms.DataGridView dgvGRV;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label lbCustomerCode;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridView dgvClearList;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.ToolStripButton tsbtnMatReceive;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripLabel tslbStockRemainWeight;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.DataGridView dgvMatchIssue;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnConfirmClearing;
		private System.Windows.Forms.Button btnMatch;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbRefSO;
		private OMControls.OMFlatButton btnFindCustomer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCustomerName;
		private System.Windows.Forms.Label lbMatchItems;
		private System.Windows.Forms.Label lbTotalClearing;
		private System.Windows.Forms.Label lbTotalReturnWeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolStripLabel tslbPendingWeight;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnTotalReceiveMat;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	}
}