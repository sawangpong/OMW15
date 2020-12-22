﻿namespace OMW15.Warehouse.WarehouseView
{
	partial class SPIssueList
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbTitle = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbOrderNo = new System.Windows.Forms.ToolStripLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbSelectIssueDate = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvDocH = new System.Windows.Forms.DataGridView();
			this.grpRemark = new System.Windows.Forms.GroupBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.cbxPeriod = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbDI_KEY = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel5 = new System.Windows.Forms.Panel();
			this.dgvIssueItems = new System.Windows.Forms.DataGridView();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel13 = new System.Windows.Forms.Panel();
			this.lbWorkStation = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.lbLastUpdate = new System.Windows.Forms.Label();
			this.panel15 = new System.Windows.Forms.Panel();
			this.lbUpdateBy = new System.Windows.Forms.Label();
			this.pnlSummary = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.txtGrandTotal = new System.Windows.Forms.TextBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.txtVAT = new System.Windows.Forms.TextBox();
			this.panel12 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnPostToOrder = new System.Windows.Forms.Button();
			this.lbProject = new System.Windows.Forms.Label();
			this.btnRefresh = new OMControls.OMFlatButton();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDocH)).BeginInit();
			this.grpRemark.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIssueItems)).BeginInit();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel15.SuspendLayout();
			this.pnlSummary.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tslbTitle,
            this.toolStripSeparator1,
            this.tslbOrderNo});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(889, 38);
			this.toolStrip1.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(67, 35);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tslbTitle
			// 
			this.tslbTitle.Name = "tslbTitle";
			this.tslbTitle.Size = new System.Drawing.Size(0, 35);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// tslbOrderNo
			// 
			this.tslbOrderNo.Name = "tslbOrderNo";
			this.tslbOrderNo.Size = new System.Drawing.Size(0, 35);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbSelectIssueDate);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 437);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(889, 32);
			this.panel1.TabIndex = 1;
			// 
			// lbSelectIssueDate
			// 
			this.lbSelectIssueDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectIssueDate.Location = new System.Drawing.Point(4, 4);
			this.lbSelectIssueDate.Name = "lbSelectIssueDate";
			this.lbSelectIssueDate.Size = new System.Drawing.Size(174, 24);
			this.lbSelectIssueDate.TabIndex = 0;
			this.lbSelectIssueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dgvDocH);
			this.panel2.Controls.Add(this.grpRemark);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 38);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(275, 399);
			this.panel2.TabIndex = 2;
			// 
			// dgvDocH
			// 
			this.dgvDocH.BackgroundColor = System.Drawing.Color.White;
			this.dgvDocH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDocH.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDocH.Location = new System.Drawing.Point(2, 66);
			this.dgvDocH.Name = "dgvDocH";
			this.dgvDocH.Size = new System.Drawing.Size(269, 185);
			this.dgvDocH.TabIndex = 4;
			this.dgvDocH.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocH_CellEnter);
			// 
			// grpRemark
			// 
			this.grpRemark.Controls.Add(this.txtRemark);
			this.grpRemark.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.grpRemark.Location = new System.Drawing.Point(2, 251);
			this.grpRemark.Name = "grpRemark";
			this.grpRemark.Size = new System.Drawing.Size(269, 144);
			this.grpRemark.TabIndex = 3;
			this.grpRemark.TabStop = false;
			this.grpRemark.Text = "หมายเหตุ";
			// 
			// txtRemark
			// 
			this.txtRemark.BackColor = System.Drawing.Color.White;
			this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtRemark.Location = new System.Drawing.Point(3, 20);
			this.txtRemark.MaxLength = 1000;
			this.txtRemark.Multiline = true;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.ReadOnly = true;
			this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRemark.Size = new System.Drawing.Size(263, 121);
			this.txtRemark.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel11);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(269, 64);
			this.panel3.TabIndex = 1;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.cbxPeriod);
			this.panel11.Controls.Add(this.label6);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(2, 32);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(2);
			this.panel11.Size = new System.Drawing.Size(265, 30);
			this.panel11.TabIndex = 3;
			// 
			// cbxPeriod
			// 
			this.cbxPeriod.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPeriod.FormattingEnabled = true;
			this.cbxPeriod.Location = new System.Drawing.Point(76, 2);
			this.cbxPeriod.Name = "cbxPeriod";
			this.cbxPeriod.Size = new System.Drawing.Size(141, 26);
			this.cbxPeriod.TabIndex = 1;
			this.cbxPeriod.SelectedValueChanged += new System.EventHandler(this.cbxPeriod_SelectedValueChanged);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(2, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "เลือกเดือน :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbDI_KEY);
			this.panel4.Controls.Add(this.cbxYear);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 2);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(265, 30);
			this.panel4.TabIndex = 2;
			// 
			// lbDI_KEY
			// 
			this.lbDI_KEY.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbDI_KEY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbDI_KEY.Location = new System.Drawing.Point(190, 2);
			this.lbDI_KEY.Name = "lbDI_KEY";
			this.lbDI_KEY.Size = new System.Drawing.Size(73, 26);
			this.lbDI_KEY.TabIndex = 6;
			this.lbDI_KEY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(76, 2);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(81, 26);
			this.cbxYear.TabIndex = 1;
			this.cbxYear.SelectedValueChanged += new System.EventHandler(this.cbxYear_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "เลือกปี :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(275, 38);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 399);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.dgvIssueItems);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(281, 38);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(608, 399);
			this.panel5.TabIndex = 5;
			// 
			// dgvIssueItems
			// 
			this.dgvIssueItems.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvIssueItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvIssueItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIssueItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvIssueItems.Location = new System.Drawing.Point(2, 35);
			this.dgvIssueItems.Name = "dgvIssueItems";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvIssueItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvIssueItems.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.dgvIssueItems.Size = new System.Drawing.Size(604, 268);
			this.dgvIssueItems.TabIndex = 8;
			this.dgvIssueItems.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssueItems_CellEnter);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.pnlSummary);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(2, 303);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(604, 94);
			this.panel7.TabIndex = 7;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.panel13);
			this.panel8.Controls.Add(this.panel14);
			this.panel8.Controls.Add(this.panel15);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(223, 94);
			this.panel8.TabIndex = 7;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.lbWorkStation);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(0, 56);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(2);
			this.panel13.Size = new System.Drawing.Size(223, 28);
			this.panel13.TabIndex = 4;
			// 
			// lbWorkStation
			// 
			this.lbWorkStation.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWorkStation.Location = new System.Drawing.Point(2, 2);
			this.lbWorkStation.Name = "lbWorkStation";
			this.lbWorkStation.Size = new System.Drawing.Size(200, 24);
			this.lbWorkStation.TabIndex = 1;
			this.lbWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.lbLastUpdate);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(0, 28);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(2);
			this.panel14.Size = new System.Drawing.Size(223, 28);
			this.panel14.TabIndex = 3;
			// 
			// lbLastUpdate
			// 
			this.lbLastUpdate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbLastUpdate.Location = new System.Drawing.Point(2, 2);
			this.lbLastUpdate.Name = "lbLastUpdate";
			this.lbLastUpdate.Size = new System.Drawing.Size(200, 24);
			this.lbLastUpdate.TabIndex = 1;
			this.lbLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.lbUpdateBy);
			this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new System.Drawing.Point(0, 0);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new System.Windows.Forms.Padding(2);
			this.panel15.Size = new System.Drawing.Size(223, 28);
			this.panel15.TabIndex = 2;
			// 
			// lbUpdateBy
			// 
			this.lbUpdateBy.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbUpdateBy.Location = new System.Drawing.Point(2, 2);
			this.lbUpdateBy.Name = "lbUpdateBy";
			this.lbUpdateBy.Size = new System.Drawing.Size(200, 24);
			this.lbUpdateBy.TabIndex = 1;
			this.lbUpdateBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlSummary
			// 
			this.pnlSummary.Controls.Add(this.panel10);
			this.pnlSummary.Controls.Add(this.panel9);
			this.pnlSummary.Controls.Add(this.panel12);
			this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlSummary.Location = new System.Drawing.Point(297, 0);
			this.pnlSummary.Name = "pnlSummary";
			this.pnlSummary.Size = new System.Drawing.Size(307, 94);
			this.pnlSummary.TabIndex = 6;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.label4);
			this.panel10.Controls.Add(this.txtGrandTotal);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(0, 56);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(2);
			this.panel10.Size = new System.Drawing.Size(307, 28);
			this.panel10.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Right;
			this.label4.Location = new System.Drawing.Point(5, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(143, 24);
			this.label4.TabIndex = 1;
			this.label4.Text = "ยอดรวมทั้งสิ้น (บาท)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGrandTotal
			// 
			this.txtGrandTotal.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtGrandTotal.Location = new System.Drawing.Point(148, 2);
			this.txtGrandTotal.MaxLength = 15;
			this.txtGrandTotal.Name = "txtGrandTotal";
			this.txtGrandTotal.ReadOnly = true;
			this.txtGrandTotal.Size = new System.Drawing.Size(157, 24);
			this.txtGrandTotal.TabIndex = 0;
			this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.label3);
			this.panel9.Controls.Add(this.txtVAT);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(0, 28);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(307, 28);
			this.panel9.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Location = new System.Drawing.Point(5, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 24);
			this.label3.TabIndex = 1;
			this.label3.Text = "VAT (บาท)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtVAT
			// 
			this.txtVAT.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtVAT.Location = new System.Drawing.Point(148, 2);
			this.txtVAT.MaxLength = 15;
			this.txtVAT.Name = "txtVAT";
			this.txtVAT.ReadOnly = true;
			this.txtVAT.Size = new System.Drawing.Size(157, 24);
			this.txtVAT.TabIndex = 0;
			this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.label2);
			this.panel12.Controls.Add(this.txtTotal);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new System.Drawing.Point(0, 0);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(2);
			this.panel12.Size = new System.Drawing.Size(307, 28);
			this.panel12.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Location = new System.Drawing.Point(5, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "ยอดรวม (บาท)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotal
			// 
			this.txtTotal.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtTotal.Location = new System.Drawing.Point(148, 2);
			this.txtTotal.MaxLength = 15;
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(157, 24);
			this.txtTotal.TabIndex = 0;
			this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.btnRefresh);
			this.panel6.Controls.Add(this.btnPostToOrder);
			this.panel6.Controls.Add(this.lbProject);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(604, 33);
			this.panel6.TabIndex = 3;
			// 
			// btnPostToOrder
			// 
			this.btnPostToOrder.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnPostToOrder.Location = new System.Drawing.Point(405, 2);
			this.btnPostToOrder.Name = "btnPostToOrder";
			this.btnPostToOrder.Size = new System.Drawing.Size(195, 27);
			this.btnPostToOrder.TabIndex = 6;
			this.btnPostToOrder.Text = "บันทึกรายการไปที่ใบงาน";
			this.btnPostToOrder.UseVisualStyleBackColor = true;
			this.btnPostToOrder.Click += new System.EventHandler(this.btnPostToOrder_Click);
			// 
			// lbProject
			// 
			this.lbProject.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbProject.Location = new System.Drawing.Point(2, 2);
			this.lbProject.Name = "lbProject";
			this.lbProject.Size = new System.Drawing.Size(322, 27);
			this.lbProject.TabIndex = 5;
			this.lbProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnRefresh.FlatAppearance.BorderSize = 0;
			this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.Location = new System.Drawing.Point(378, 2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(27, 27);
			this.btnRefresh.Style = OMControls.ButtonImageStyle.Refresh;
			this.btnRefresh.TabIndex = 7;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// SPIssueList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(889, 469);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "SPIssueList";
			this.Text = "WARE HOUSE DOCUMENT LIST";
			this.Load += new System.EventHandler(this.SPIssueList_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDocH)).EndInit();
			this.grpRemark.ResumeLayout(false);
			this.grpRemark.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvIssueItems)).EndInit();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.pnlSummary.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbSelectIssueDate;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lbProject;
		private System.Windows.Forms.Label lbDI_KEY;
		private System.Windows.Forms.ToolStripLabel tslbTitle;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.ComboBox cbxPeriod;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridView dgvIssueItems;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel pnlSummary;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtGrandTotal;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtVAT;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.GroupBox grpRemark;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.DataGridView dgvDocH;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Label lbWorkStation;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label lbLastUpdate;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Label lbUpdateBy;
		private System.Windows.Forms.Button btnPostToOrder;
		private System.Windows.Forms.ToolStripLabel tslbOrderNo;
		private OMControls.OMFlatButton btnRefresh;
	}
}