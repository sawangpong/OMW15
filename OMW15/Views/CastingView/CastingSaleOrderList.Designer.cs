namespace OMW15.Views.CastingView
{
	partial class CastingSaleOrderList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingSaleOrderList));
			this.pnlLower = new System.Windows.Forms.Panel();
			this.lbBilled = new System.Windows.Forms.Label();
			this.lbSOId = new System.Windows.Forms.Label();
			this.lbSOCount = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbHeader = new System.Windows.Forms.Label();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnBilling = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrintSO = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSearchSI = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlToolBar = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.btnCustomerSearch = new OMControls.OMFlatButton();
			this.txtCustomer = new System.Windows.Forms.TextBox();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.chkShowAllCustomers = new System.Windows.Forms.CheckBox();
			this.cbxStatus = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.pnlLower.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.ts.SuspendLayout();
			this.pnlToolBar.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlLower
			// 
			this.pnlLower.Controls.Add(this.lbBilled);
			this.pnlLower.Controls.Add(this.lbSOId);
			this.pnlLower.Controls.Add(this.lbSOCount);
			this.pnlLower.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLower.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlLower.Location = new System.Drawing.Point(2, 484);
			this.pnlLower.Name = "pnlLower";
			this.pnlLower.Padding = new System.Windows.Forms.Padding(3);
			this.pnlLower.Size = new System.Drawing.Size(1015, 23);
			this.pnlLower.TabIndex = 2;
			// 
			// lbBilled
			// 
			this.lbBilled.BackColor = System.Drawing.Color.Orange;
			this.lbBilled.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBilled.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbBilled.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbBilled.Location = new System.Drawing.Point(185, 3);
			this.lbBilled.Name = "lbBilled";
			this.lbBilled.Size = new System.Drawing.Size(103, 17);
			this.lbBilled.TabIndex = 2;
			this.lbBilled.Text = "Billed..";
			this.lbBilled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbSOId
			// 
			this.lbSOId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSOId.Location = new System.Drawing.Point(94, 3);
			this.lbSOId.Name = "lbSOId";
			this.lbSOId.Size = new System.Drawing.Size(91, 17);
			this.lbSOId.TabIndex = 1;
			this.lbSOId.Text = "X : 0";
			this.lbSOId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbSOCount
			// 
			this.lbSOCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSOCount.Location = new System.Drawing.Point(3, 3);
			this.lbSOCount.Name = "lbSOCount";
			this.lbSOCount.Size = new System.Drawing.Size(91, 17);
			this.lbSOCount.TabIndex = 0;
			this.lbSOCount.Text = "X : 0";
			this.lbSOCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.Orange;
			this.pnlHeader.Controls.Add(this.lbHeader);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(2, 2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(1015, 36);
			this.pnlHeader.TabIndex = 4;
			// 
			// lbHeader
			// 
			this.lbHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.ForeColor = System.Drawing.Color.Yellow;
			this.lbHeader.Location = new System.Drawing.Point(2, 2);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(191, 32);
			this.lbHeader.TabIndex = 0;
			this.lbHeader.Text = "ใบส่งสินค้า (SI)";
			this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlDetail
			// 
			this.pnlDetail.AutoSize = true;
			this.pnlDetail.Controls.Add(this.panel2);
			this.pnlDetail.Controls.Add(this.pnlToolBar);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetail.Location = new System.Drawing.Point(2, 38);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(5);
			this.pnlDetail.Size = new System.Drawing.Size(1015, 446);
			this.pnlDetail.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dgv);
			this.panel2.Controls.Add(this.ts);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(5, 43);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(1005, 398);
			this.panel2.TabIndex = 5;
			// 
			// dgv
			// 
			this.dgv.AllowUserToResizeColumns = false;
			this.dgv.AllowUserToResizeRows = false;
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
			this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
			this.dgv.Location = new System.Drawing.Point(5, 50);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.RowHeadersVisible = false;
			this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgv.Size = new System.Drawing.Size(993, 341);
			this.dgv.TabIndex = 6;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			this.dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgv_CellPainting);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.toolStripSeparator1,
            this.tsbtnEdit,
            this.toolStripSeparator2,
            this.tsbtnDelete,
            this.toolStripSeparator3,
            this.tsbtnRefresh,
            this.toolStripSeparator4,
            this.tsbtnClose,
            this.toolStripSeparator6,
            this.tsbtnBilling,
            this.toolStripSeparator5,
            this.tsbtnPrintSO,
            this.toolStripSeparator7,
            this.tsbtnSearchSI,
            this.toolStripSeparator8});
			this.ts.Location = new System.Drawing.Point(5, 5);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(993, 45);
			this.ts.TabIndex = 5;
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(65, 42);
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(65, 42);
			this.tsbtnEdit.Text = "E&dit";
			this.tsbtnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.AutoSize = false;
			this.tsbtnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(65, 42);
			this.tsbtnDelete.Text = "&Delete";
			this.tsbtnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(65, 42);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(75, 42);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnBilling
			// 
			this.tsbtnBilling.AutoSize = false;
			this.tsbtnBilling.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBilling.Image")));
			this.tsbtnBilling.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnBilling.Name = "tsbtnBilling";
			this.tsbtnBilling.Size = new System.Drawing.Size(65, 44);
			this.tsbtnBilling.Text = "วางบิล";
			this.tsbtnBilling.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnBilling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnBilling.Click += new System.EventHandler(this.tsbtnBilling_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnPrintSO
			// 
			this.tsbtnPrintSO.AutoSize = false;
			this.tsbtnPrintSO.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrintSO.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrintSO.Name = "tsbtnPrintSO";
			this.tsbtnPrintSO.Size = new System.Drawing.Size(65, 42);
			this.tsbtnPrintSO.Text = "&Print";
			this.tsbtnPrintSO.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnPrintSO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPrintSO.Click += new System.EventHandler(this.tsbtnPrintSO_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnSearchSI
			// 
			this.tsbtnSearchSI.AutoSize = false;
			this.tsbtnSearchSI.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearchSI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearchSI.Name = "tsbtnSearchSI";
			this.tsbtnSearchSI.Size = new System.Drawing.Size(65, 42);
			this.tsbtnSearchSI.Text = "ค้นหา SI";
			this.tsbtnSearchSI.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnSearchSI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnSearchSI.Click += new System.EventHandler(this.tsbtnSearchSI_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 45);
			// 
			// pnlToolBar
			// 
			this.pnlToolBar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.pnlToolBar.Controls.Add(this.panel1);
			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlToolBar.Location = new System.Drawing.Point(5, 5);
			this.pnlToolBar.Name = "pnlToolBar";
			this.pnlToolBar.Size = new System.Drawing.Size(1005, 38);
			this.pnlToolBar.TabIndex = 2;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btnLoadData);
			this.panel1.Controls.Add(this.btnCustomerSearch);
			this.panel1.Controls.Add(this.txtCustomer);
			this.panel1.Controls.Add(this.lbCustomer);
			this.panel1.Controls.Add(this.chkShowAllCustomers);
			this.panel1.Controls.Add(this.cbxStatus);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(1005, 33);
			this.panel1.TabIndex = 3;
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLoadData.Location = new System.Drawing.Point(710, 3);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(120, 25);
			this.btnLoadData.TabIndex = 7;
			this.btnLoadData.Text = "เรียกดูข้อมูล";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// btnCustomerSearch
			// 
			this.btnCustomerSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCustomerSearch.FlatAppearance.BorderSize = 0;
			this.btnCustomerSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnCustomerSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCustomerSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerSearch.Image")));
			this.btnCustomerSearch.Location = new System.Drawing.Point(685, 3);
			this.btnCustomerSearch.Name = "btnCustomerSearch";
			this.btnCustomerSearch.Size = new System.Drawing.Size(25, 25);
			this.btnCustomerSearch.TabIndex = 6;
			this.btnCustomerSearch.UseVisualStyleBackColor = true;
			this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
			// 
			// txtCustomer
			// 
			this.txtCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomer.Location = new System.Drawing.Point(335, 3);
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.Size = new System.Drawing.Size(350, 25);
			this.txtCustomer.TabIndex = 5;
			this.txtCustomer.TextChanged += new System.EventHandler(this.txtCustomer_TextChanged);
			this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomer.Location = new System.Drawing.Point(282, 3);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(53, 25);
			this.lbCustomer.TabIndex = 4;
			this.lbCustomer.Text = "ลูกค้า :";
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkShowAllCustomers
			// 
			this.chkShowAllCustomers.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkShowAllCustomers.Location = new System.Drawing.Point(141, 3);
			this.chkShowAllCustomers.Name = "chkShowAllCustomers";
			this.chkShowAllCustomers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.chkShowAllCustomers.Size = new System.Drawing.Size(141, 25);
			this.chkShowAllCustomers.TabIndex = 3;
			this.chkShowAllCustomers.Text = "แสดงลูกค้าทั้งหมด";
			this.chkShowAllCustomers.UseVisualStyleBackColor = true;
			this.chkShowAllCustomers.CheckedChanged += new System.EventHandler(this.chkShowAllCustomers_CheckedChanged);
			// 
			// cbxStatus
			// 
			this.cbxStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStatus.FormattingEnabled = true;
			this.cbxStatus.Location = new System.Drawing.Point(56, 3);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(85, 25);
			this.cbxStatus.TabIndex = 2;
			this.cbxStatus.SelectedValueChanged += new System.EventHandler(this.cbxStatus_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(3, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 25);
			this.label3.TabIndex = 1;
			this.label3.Text = "สถานะ :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// imgList
			// 
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			this.imgList.Images.SetKeyName(0, "apply.png");
			this.imgList.Images.SetKeyName(1, "PrintHS.png");
			// 
			// CastingSaleOrderList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1019, 509);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlLower);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "CastingSaleOrderList";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "CASTING SALE ORDER LIST";
			this.Load += new System.EventHandler(this.CastingSaleOrderList_Load);
			this.pnlLower.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlToolBar.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlLower;
		private System.Windows.Forms.Label lbSOCount;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.Panel pnlToolBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chkShowAllCustomers;
		private System.Windows.Forms.ComboBox cbxStatus;
		private System.Windows.Forms.Label label3;
		private OMControls.OMFlatButton btnCustomerSearch;
		private System.Windows.Forms.TextBox txtCustomer;
		private System.Windows.Forms.Label lbCustomer;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnPrintSO;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.Label lbSOId;
		private System.Windows.Forms.ToolStripButton tsbtnBilling;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.Label lbBilled;
		private System.Windows.Forms.ToolStripButton tsbtnSearchSI;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ImageList imgList;
	}
}