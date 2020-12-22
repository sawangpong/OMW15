namespace OMW15.Views.EmployeeView
{
	partial class MasterEmployee
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterEmployee));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEmpDepartment = new System.Windows.Forms.ToolStripSplitButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddEmployee = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditEmployeeInfo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnHourCost = new System.Windows.Forms.ToolStripButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbCount = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dgvStatus = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbDepartment = new System.Windows.Forms.Label();
			this.ts.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tsbtnEmpDepartment,
            this.toolStripSeparator7,
            this.tsbtnAddEmployee,
            this.toolStripSeparator4,
            this.tsbtnEditEmployeeInfo,
            this.toolStripSeparator5,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnHourCost});
			this.ts.Location = new System.Drawing.Point(5, 5);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(795, 38);
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
			this.tsbtnClose.Size = new System.Drawing.Size(37, 37);
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnEmpDepartment
			// 
			this.tsbtnEmpDepartment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnEmpDepartment.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEmpDepartment.Image")));
			this.tsbtnEmpDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEmpDepartment.Name = "tsbtnEmpDepartment";
			this.tsbtnEmpDepartment.Size = new System.Drawing.Size(111, 35);
			this.tsbtnEmpDepartment.Text = "รายชื่อแผนก (xx)";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnAddEmployee
			// 
			this.tsbtnAddEmployee.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddEmployee.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddEmployee.Name = "tsbtnAddEmployee";
			this.tsbtnAddEmployee.Size = new System.Drawing.Size(90, 35);
			this.tsbtnAddEmployee.Text = "เพิ่มพนักงาน";
			this.tsbtnAddEmployee.Click += new System.EventHandler(this.tsbtnAddEmployee_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnEditEmployeeInfo
			// 
			this.tsbtnEditEmployeeInfo.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditEmployeeInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditEmployeeInfo.Name = "tsbtnEditEmployeeInfo";
			this.tsbtnEditEmployeeInfo.Size = new System.Drawing.Size(83, 35);
			this.tsbtnEditEmployeeInfo.Text = "แก้ไขข้อมูล";
			this.tsbtnEditEmployeeInfo.Click += new System.EventHandler(this.tsbtnEditEmployeeInfo_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(72, 35);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnHourCost
			// 
			this.tsbtnHourCost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnHourCost.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHourCost.Image")));
			this.tsbtnHourCost.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnHourCost.Name = "tsbtnHourCost";
			this.tsbtnHourCost.Size = new System.Drawing.Size(69, 35);
			this.tsbtnHourCost.Text = "Hour cost";
			this.tsbtnHourCost.Click += new System.EventHandler(this.tsbtnHourCost_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbCount);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(5, 476);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(795, 30);
			this.panel1.TabIndex = 1;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Location = new System.Drawing.Point(2, 2);
			this.lbCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(255, 26);
			this.lbCount.TabIndex = 1;
			this.lbCount.Text = "found : 0";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.dgvStatus);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(641, 43);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(159, 433);
			this.panel2.TabIndex = 2;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.pictureBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(10);
			this.panel5.Size = new System.Drawing.Size(153, 177);
			this.panel5.TabIndex = 2;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(10, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(133, 157);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// dgvStatus
			// 
			this.dgvStatus.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStatus.ColumnHeadersVisible = false;
			this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvStatus.Location = new System.Drawing.Point(2, 278);
			this.dgvStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgvStatus.Name = "dgvStatus";
			this.dgvStatus.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvStatus.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dgvStatus.Size = new System.Drawing.Size(153, 151);
			this.dgvStatus.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(5, 43);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(636, 433);
			this.panel3.TabIndex = 3;
			// 
			// dgv
			// 
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 37);
			this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.Size = new System.Drawing.Size(632, 394);
			this.dgv.TabIndex = 1;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.lbDepartment);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 2);
			this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(632, 35);
			this.panel4.TabIndex = 0;
			// 
			// lbDepartment
			// 
			this.lbDepartment.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbDepartment.Location = new System.Drawing.Point(1, 1);
			this.lbDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbDepartment.Name = "lbDepartment";
			this.lbDepartment.Size = new System.Drawing.Size(184, 31);
			this.lbDepartment.TabIndex = 0;
			this.lbDepartment.Text = "Department : ";
			this.lbDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MasterEmployee
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 511);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MasterEmployee";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "MASTER EMPLOYEE";
			this.Load += new System.EventHandler(this.MasterEmployee_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbDepartment;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnAddEmployee;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnEditEmployeeInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.DataGridView dgvStatus;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripSplitButton tsbtnEmpDepartment;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tsbtnHourCost;
	}
}