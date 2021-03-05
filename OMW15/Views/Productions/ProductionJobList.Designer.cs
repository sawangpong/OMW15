namespace OMW15.Views.Productions
{
	partial class ProductionJobList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionJobList));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbHeader = new System.Windows.Forms.Label();
			this.pnlToolMenu = new System.Windows.Forms.Panel();
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.btnUpdateAllJobs = new System.Windows.Forms.Button();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxProductionYear = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxStatus = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnTask = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddProductionTask = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditTask = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDeleteTask = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbCount = new System.Windows.Forms.ToolStripLabel();
			this.tsbtnReport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbJobId = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlToolMenu.SuspendLayout();
			this.pnlMenu.SuspendLayout();
			this.pnlStatus.SuspendLayout();
			this.pnlGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.ts.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.Orange;
			this.pnlHeader.Controls.Add(this.lbHeader);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(2, 2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Size = new System.Drawing.Size(978, 37);
			this.pnlHeader.TabIndex = 3;
			// 
			// lbHeader
			// 
			this.lbHeader.AutoSize = true;
			this.lbHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.ForeColor = System.Drawing.Color.Yellow;
			this.lbHeader.Location = new System.Drawing.Point(4, 4);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(79, 25);
			this.lbHeader.TabIndex = 0;
			this.lbHeader.Text = "ใบสั่งผลิต";
			this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlToolMenu
			// 
			this.pnlToolMenu.Controls.Add(this.pnlMenu);
			this.pnlToolMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlToolMenu.Location = new System.Drawing.Point(2, 39);
			this.pnlToolMenu.Name = "pnlToolMenu";
			this.pnlToolMenu.Padding = new System.Windows.Forms.Padding(4);
			this.pnlToolMenu.Size = new System.Drawing.Size(978, 45);
			this.pnlToolMenu.TabIndex = 4;
			// 
			// pnlMenu
			// 
			this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMenu.Controls.Add(this.btnUpdateAllJobs);
			this.pnlMenu.Controls.Add(this.btnLoadData);
			this.pnlMenu.Controls.Add(this.pnlStatus);
			this.pnlMenu.Controls.Add(this.btnClose);
			this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMenu.Location = new System.Drawing.Point(4, 4);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Padding = new System.Windows.Forms.Padding(1);
			this.pnlMenu.Size = new System.Drawing.Size(970, 37);
			this.pnlMenu.TabIndex = 3;
			// 
			// btnUpdateAllJobs
			// 
			this.btnUpdateAllJobs.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUpdateAllJobs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpdateAllJobs.Location = new System.Drawing.Point(676, 1);
			this.btnUpdateAllJobs.Name = "btnUpdateAllJobs";
			this.btnUpdateAllJobs.Size = new System.Drawing.Size(188, 33);
			this.btnUpdateAllJobs.TabIndex = 8;
			this.btnUpdateAllJobs.Text = "ปรับปรุงข้อมูลทั้งหมด";
			this.btnUpdateAllJobs.UseVisualStyleBackColor = true;
			this.btnUpdateAllJobs.Visible = false;
			this.btnUpdateAllJobs.Click += new System.EventHandler(this.btnUpdateAllJobs_Click);
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadData.Location = new System.Drawing.Point(557, 1);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(119, 33);
			this.btnLoadData.TabIndex = 7;
			this.btnLoadData.Text = "เรียกข้อมูล";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// pnlStatus
			// 
			this.pnlStatus.Controls.Add(this.txtFilter);
			this.pnlStatus.Controls.Add(this.label3);
			this.pnlStatus.Controls.Add(this.cbxProductionYear);
			this.pnlStatus.Controls.Add(this.label2);
			this.pnlStatus.Controls.Add(this.cbxStatus);
			this.pnlStatus.Controls.Add(this.label1);
			this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlStatus.Location = new System.Drawing.Point(1, 1);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Padding = new System.Windows.Forms.Padding(2);
			this.pnlStatus.Size = new System.Drawing.Size(556, 33);
			this.pnlStatus.TabIndex = 3;
			// 
			// txtFilter
			// 
			this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFilter.Location = new System.Drawing.Point(376, 2);
			this.txtFilter.MaxLength = 25;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(178, 29);
			this.txtFilter.TabIndex = 7;
			this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(309, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 29);
			this.label3.TabIndex = 6;
			this.label3.Text = "ค้นหา :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxProductionYear
			// 
			this.cbxProductionYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxProductionYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxProductionYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxProductionYear.FormattingEnabled = true;
			this.cbxProductionYear.Location = new System.Drawing.Point(225, 2);
			this.cbxProductionYear.Name = "cbxProductionYear";
			this.cbxProductionYear.Size = new System.Drawing.Size(84, 28);
			this.cbxProductionYear.TabIndex = 5;
			this.cbxProductionYear.SelectedValueChanged += new System.EventHandler(this.cbxProductionYear_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(187, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 29);
			this.label2.TabIndex = 4;
			this.label2.Text = "ปี:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxStatus
			// 
			this.cbxStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxStatus.FormattingEnabled = true;
			this.cbxStatus.Location = new System.Drawing.Point(86, 2);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(101, 28);
			this.cbxStatus.TabIndex = 3;
			this.cbxStatus.SelectedValueChanged += new System.EventHandler(this.cbxStatus_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 29);
			this.label1.TabIndex = 2;
			this.label1.Text = "สถานะงาน :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(872, 1);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(95, 33);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&ปิด";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// pnlGrid
			// 
			this.pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGrid.Controls.Add(this.dgv);
			this.pnlGrid.Controls.Add(this.ts);
			this.pnlGrid.Controls.Add(this.panel1);
			this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGrid.Location = new System.Drawing.Point(2, 84);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Padding = new System.Windows.Forms.Padding(5);
			this.pnlGrid.Size = new System.Drawing.Size(978, 487);
			this.pnlGrid.TabIndex = 5;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 44);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			this.dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.Size = new System.Drawing.Size(966, 406);
			this.dgv.TabIndex = 6;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			this.dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseClick);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnTask,
            this.toolStripSeparator1,
            this.tsbtnAddProductionTask,
            this.toolStripSeparator3,
            this.tsbtnEditTask,
            this.toolStripSeparator4,
            this.tsbtnDeleteTask,
            this.toolStripSeparator5,
            this.tslbCount,
            this.tsbtnReport,
            this.toolStripSeparator2});
			this.ts.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.ts.Location = new System.Drawing.Point(5, 5);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(966, 39);
			this.ts.TabIndex = 5;
			// 
			// tsbtnTask
			// 
			this.tsbtnTask.AutoSize = false;
			this.tsbtnTask.Enabled = false;
			this.tsbtnTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnTask.Name = "tsbtnTask";
			this.tsbtnTask.Size = new System.Drawing.Size(135, 39);
			this.tsbtnTask.Text = "รายการใบขอแปร";
			this.tsbtnTask.Click += new System.EventHandler(this.tsbtnTask_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// tsbtnAddProductionTask
			// 
			this.tsbtnAddProductionTask.AutoSize = false;
			this.tsbtnAddProductionTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnAddProductionTask.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddProductionTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnAddProductionTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddProductionTask.Name = "tsbtnAddProductionTask";
			this.tsbtnAddProductionTask.Size = new System.Drawing.Size(120, 39);
			this.tsbtnAddProductionTask.Tag = "ADD";
			this.tsbtnAddProductionTask.Text = "เพิ่มใบแปร";
			this.tsbtnAddProductionTask.Click += new System.EventHandler(this.tsbtn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// tsbtnEditTask
			// 
			this.tsbtnEditTask.AutoSize = false;
			this.tsbtnEditTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnEditTask.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnEditTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditTask.Name = "tsbtnEditTask";
			this.tsbtnEditTask.Size = new System.Drawing.Size(110, 39);
			this.tsbtnEditTask.Tag = "EDIT";
			this.tsbtnEditTask.Text = "แก้ไข";
			this.tsbtnEditTask.Click += new System.EventHandler(this.tsbtn_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
			// 
			// tsbtnDeleteTask
			// 
			this.tsbtnDeleteTask.AutoSize = false;
			this.tsbtnDeleteTask.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnDeleteTask.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDeleteTask.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteTask.Name = "tsbtnDeleteTask";
			this.tsbtnDeleteTask.Size = new System.Drawing.Size(110, 39);
			this.tsbtnDeleteTask.Tag = "DEL";
			this.tsbtnDeleteTask.Text = "ลบรายการ";
			this.tsbtnDeleteTask.Click += new System.EventHandler(this.tsbtn_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 39);
			// 
			// tslbCount
			// 
			this.tslbCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tslbCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbCount.ForeColor = System.Drawing.Color.DimGray;
			this.tslbCount.Name = "tslbCount";
			this.tslbCount.Size = new System.Drawing.Size(57, 36);
			this.tslbCount.Text = "found :: 0";
			this.tslbCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// tsbtnReport
			// 
			this.tsbtnReport.AutoSize = false;
			this.tsbtnReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReport.Image")));
			this.tsbtnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnReport.Name = "tsbtnReport";
			this.tsbtnReport.Size = new System.Drawing.Size(110, 36);
			this.tsbtnReport.Text = "รายงาน";
			this.tsbtnReport.Click += new System.EventHandler(this.tsbtnReport_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbJobId);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.ForeColor = System.Drawing.Color.DimGray;
			this.panel1.Location = new System.Drawing.Point(5, 450);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(966, 30);
			this.panel1.TabIndex = 3;
			// 
			// lbJobId
			// 
			this.lbJobId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobId.ForeColor = System.Drawing.Color.DimGray;
			this.lbJobId.Location = new System.Drawing.Point(2, 2);
			this.lbJobId.Name = "lbJobId";
			this.lbJobId.Size = new System.Drawing.Size(185, 26);
			this.lbJobId.TabIndex = 0;
			this.lbJobId.Text = "id:0";
			this.lbJobId.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// ProductionJobList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 573);
			this.Controls.Add(this.pnlGrid);
			this.Controls.Add(this.pnlToolMenu);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProductionJobList";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "PRODUCTION TASK LIST";
			this.Load += new System.EventHandler(this.ProductionJobList_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlToolMenu.ResumeLayout(false);
			this.pnlMenu.ResumeLayout(false);
			this.pnlStatus.ResumeLayout(false);
			this.pnlStatus.PerformLayout();
			this.pnlGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlToolMenu;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Panel pnlMenu;
		private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnAddProductionTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnEditTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbJobId;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlStatus;
		private System.Windows.Forms.ComboBox cbxStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripLabel tslbCount;
		private System.Windows.Forms.ComboBox cbxProductionYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Button btnUpdateAllJobs;
		private System.Windows.Forms.ToolStripButton tsbtnReport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label label3;
	}
}