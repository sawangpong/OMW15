namespace OMW15.Views.CastingView
{
	partial class CastingPriceList
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
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSelectCustomer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbSelectedCustomer = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlPriceList = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbFileName = new System.Windows.Forms.Label();
			this.lbItemId = new System.Windows.Forms.Label();
			this.lbRowFound = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.pnlJobInfo = new System.Windows.Forms.Panel();
			this.pnlJobs = new System.Windows.Forms.Panel();
			this.dgvJobs = new System.Windows.Forms.DataGridView();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.btnOpenJob = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnJobHistory = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cbxFindItem = new System.Windows.Forms.ComboBox();
			this.lbHolder1 = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.cbxMaterials = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ts.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlPriceList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.pnlJobInfo.SuspendLayout();
			this.pnlJobs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
			this.pnlHeader.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.BackColor = System.Drawing.SystemColors.Control;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnSelectCustomer,
            this.toolStripSeparator2,
            this.tslbSelectedCustomer,
            this.toolStripSeparator3});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(965, 35);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.ForeColor = System.Drawing.SystemColors.InfoText;
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
			// tsbtnSelectCustomer
			// 
			this.tsbtnSelectCustomer.AutoSize = false;
			this.tsbtnSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnSelectCustomer.ForeColor = System.Drawing.SystemColors.InfoText;
			this.tsbtnSelectCustomer.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSelectCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnSelectCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSelectCustomer.Name = "tsbtnSelectCustomer";
			this.tsbtnSelectCustomer.Size = new System.Drawing.Size(100, 38);
			this.tsbtnSelectCustomer.Text = "เลือกลูกค้า";
			this.tsbtnSelectCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnSelectCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.tsbtnSelectCustomer.Click += new System.EventHandler(this.tsbtnSelectCustomer_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
			// 
			// tslbSelectedCustomer
			// 
			this.tslbSelectedCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tslbSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbSelectedCustomer.ForeColor = System.Drawing.SystemColors.InfoText;
			this.tslbSelectedCustomer.Name = "tslbSelectedCustomer";
			this.tslbSelectedCustomer.Size = new System.Drawing.Size(18, 32);
			this.tslbSelectedCustomer.Text = "--";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlPriceList);
			this.pnlMain.Controls.Add(this.panel2);
			this.pnlMain.Controls.Add(this.pnlJobInfo);
			this.pnlMain.Controls.Add(this.pnlTop);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 35);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlMain.Size = new System.Drawing.Size(965, 502);
			this.pnlMain.TabIndex = 1;
			// 
			// pnlPriceList
			// 
			this.pnlPriceList.Controls.Add(this.dgv);
			this.pnlPriceList.Controls.Add(this.panel3);
			this.pnlPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPriceList.Location = new System.Drawing.Point(4, 38);
			this.pnlPriceList.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPriceList.Name = "pnlPriceList";
			this.pnlPriceList.Padding = new System.Windows.Forms.Padding(4);
			this.pnlPriceList.Size = new System.Drawing.Size(781, 308);
			this.pnlPriceList.TabIndex = 4;
			// 
			// dgv
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HotTrack;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Margin = new System.Windows.Forms.Padding(4);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(773, 272);
			this.dgv.TabIndex = 4;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbFileName);
			this.panel3.Controls.Add(this.lbItemId);
			this.panel3.Controls.Add(this.lbRowFound);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel3.Location = new System.Drawing.Point(4, 276);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(4);
			this.panel3.Size = new System.Drawing.Size(773, 28);
			this.panel3.TabIndex = 2;
			// 
			// lbFileName
			// 
			this.lbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFileName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFileName.Location = new System.Drawing.Point(130, 4);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(551, 23);
			this.lbFileName.TabIndex = 6;
			this.lbFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbItemId
			// 
			this.lbItemId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbItemId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemId.Location = new System.Drawing.Point(681, 4);
			this.lbItemId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbItemId.Name = "lbItemId";
			this.lbItemId.Size = new System.Drawing.Size(88, 20);
			this.lbItemId.TabIndex = 5;
			this.lbItemId.Text = "0";
			this.lbItemId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbRowFound
			// 
			this.lbRowFound.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowFound.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowFound.Location = new System.Drawing.Point(4, 4);
			this.lbRowFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbRowFound.Name = "lbRowFound";
			this.lbRowFound.Size = new System.Drawing.Size(126, 20);
			this.lbRowFound.TabIndex = 4;
			this.lbRowFound.Text = "0/0";
			this.lbRowFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pic);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(785, 38);
			this.panel2.Margin = new System.Windows.Forms.Padding(4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
			this.panel2.Size = new System.Drawing.Size(176, 308);
			this.panel2.TabIndex = 2;
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Location = new System.Drawing.Point(10, 12);
			this.pic.Margin = new System.Windows.Forms.Padding(4);
			this.pic.Name = "pic";
			this.pic.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pic.Size = new System.Drawing.Size(156, 189);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// pnlJobInfo
			// 
			this.pnlJobInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlJobInfo.Controls.Add(this.pnlJobs);
			this.pnlJobInfo.Controls.Add(this.pnlHeader);
			this.pnlJobInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlJobInfo.Location = new System.Drawing.Point(4, 346);
			this.pnlJobInfo.Margin = new System.Windows.Forms.Padding(4);
			this.pnlJobInfo.Name = "pnlJobInfo";
			this.pnlJobInfo.Padding = new System.Windows.Forms.Padding(4);
			this.pnlJobInfo.Size = new System.Drawing.Size(957, 151);
			this.pnlJobInfo.TabIndex = 1;
			// 
			// pnlJobs
			// 
			this.pnlJobs.Controls.Add(this.dgvJobs);
			this.pnlJobs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlJobs.Location = new System.Drawing.Point(4, 38);
			this.pnlJobs.Name = "pnlJobs";
			this.pnlJobs.Size = new System.Drawing.Size(947, 107);
			this.pnlJobs.TabIndex = 1;
			// 
			// dgvJobs
			// 
			this.dgvJobs.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvJobs.Location = new System.Drawing.Point(0, 0);
			this.dgvJobs.Name = "dgvJobs";
			this.dgvJobs.Size = new System.Drawing.Size(947, 107);
			this.dgvJobs.TabIndex = 0;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlHeader.Controls.Add(this.btnOpenJob);
			this.pnlHeader.Controls.Add(this.label4);
			this.pnlHeader.Controls.Add(this.btnJobHistory);
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.ForeColor = System.Drawing.Color.White;
			this.pnlHeader.Location = new System.Drawing.Point(4, 4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHeader.Size = new System.Drawing.Size(947, 34);
			this.pnlHeader.TabIndex = 0;
			// 
			// btnOpenJob
			// 
			this.btnOpenJob.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnOpenJob.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnOpenJob.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnOpenJob.ForeColor = System.Drawing.Color.Black;
			this.btnOpenJob.Location = new System.Drawing.Point(276, 1);
			this.btnOpenJob.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpenJob.Name = "btnOpenJob";
			this.btnOpenJob.Size = new System.Drawing.Size(133, 32);
			this.btnOpenJob.TabIndex = 22;
			this.btnOpenJob.Text = "เปิดใบสั่งงาน";
			this.btnOpenJob.UseVisualStyleBackColor = false;
			this.btnOpenJob.Click += new System.EventHandler(this.btnOpenJob_Click);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(252, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(24, 32);
			this.label4.TabIndex = 2;
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnJobHistory
			// 
			this.btnJobHistory.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnJobHistory.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnJobHistory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnJobHistory.ForeColor = System.Drawing.Color.Black;
			this.btnJobHistory.Location = new System.Drawing.Point(129, 1);
			this.btnJobHistory.Name = "btnJobHistory";
			this.btnJobHistory.Size = new System.Drawing.Size(123, 32);
			this.btnJobHistory.TabIndex = 1;
			this.btnJobHistory.Text = "แสดงประวัติ";
			this.btnJobHistory.UseVisualStyleBackColor = false;
			this.btnJobHistory.Click += new System.EventHandler(this.btnJobHistory_Click);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "ประวัติใบงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel4);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(4, 5);
			this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(957, 33);
			this.pnlTop.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.cbxFindItem);
			this.panel4.Controls.Add(this.lbHolder1);
			this.panel4.Controls.Add(this.btnEdit);
			this.panel4.Controls.Add(this.btnNew);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.btnRefresh);
			this.panel4.Controls.Add(this.cbxMaterials);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(10, 2, 20, 2);
			this.panel4.Size = new System.Drawing.Size(957, 30);
			this.panel4.TabIndex = 1;
			// 
			// cbxFindItem
			// 
			this.cbxFindItem.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxFindItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFindItem.FormattingEnabled = true;
			this.cbxFindItem.Location = new System.Drawing.Point(609, 2);
			this.cbxFindItem.Name = "cbxFindItem";
			this.cbxFindItem.Size = new System.Drawing.Size(172, 25);
			this.cbxFindItem.TabIndex = 26;
			this.cbxFindItem.SelectedValueChanged += new System.EventHandler(this.cbxFindItem_SelectedValueChanged);
			// 
			// lbHolder1
			// 
			this.lbHolder1.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHolder1.Location = new System.Drawing.Point(534, 2);
			this.lbHolder1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbHolder1.Name = "lbHolder1";
			this.lbHolder1.Size = new System.Drawing.Size(75, 26);
			this.lbHolder1.TabIndex = 25;
			this.lbHolder1.Text = "ค้นหา :";
			this.lbHolder1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(440, 2);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(94, 26);
			this.btnEdit.TabIndex = 24;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnNew
			// 
			this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnNew.Image = global::OMW15.Properties.Resources.Add;
			this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNew.Location = new System.Drawing.Point(338, 2);
			this.btnNew.Margin = new System.Windows.Forms.Padding(4);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(102, 26);
			this.btnNew.TabIndex = 23;
			this.btnNew.Text = "&New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(316, 2);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 26);
			this.label3.TabIndex = 22;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefresh.Location = new System.Drawing.Point(214, 2);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(102, 26);
			this.btnRefresh.TabIndex = 16;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// cbxMaterials
			// 
			this.cbxMaterials.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterials.FormattingEnabled = true;
			this.cbxMaterials.Location = new System.Drawing.Point(52, 2);
			this.cbxMaterials.Name = "cbxMaterials";
			this.cbxMaterials.Size = new System.Drawing.Size(162, 25);
			this.cbxMaterials.TabIndex = 15;
			this.cbxMaterials.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterials_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(10, 2);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 26);
			this.label2.TabIndex = 14;
			this.label2.Text = "วัสดุ :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CastingPriceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(965, 537);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CastingPriceList";
			this.Text = "CASTING PRICE LIST";
			this.Load += new System.EventHandler(this.CastingPriceList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlPriceList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.pnlJobInfo.ResumeLayout(false);
			this.pnlJobs.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
			this.pnlHeader.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnlJobInfo;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.ToolStripButton tsbtnSelectCustomer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolStripLabel tslbSelectedCustomer;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlPriceList;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbRowFound;
		private System.Windows.Forms.Label lbItemId;
		private System.Windows.Forms.Label lbFileName;
		private System.Windows.Forms.Panel pnlJobs;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.DataGridView dgvJobs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnJobHistory;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ComboBox cbxMaterials;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxFindItem;
		private System.Windows.Forms.Label lbHolder1;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnOpenJob;
		private System.Windows.Forms.Label label4;
	}
}