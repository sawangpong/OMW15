namespace OMW15.Views.EmployeeView
{
	partial class EmpSala
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pnlEmpList = new System.Windows.Forms.Panel();
			this.dgvSal = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbFullname = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlEmpDetails = new System.Windows.Forms.Panel();
			this.pnlResign = new System.Windows.Forms.Panel();
			this.lbResignDate = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbEmpStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbDepartment = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEmployee = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.panel3.SuspendLayout();
			this.pnlEmpList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSal)).BeginInit();
			this.panel2.SuspendLayout();
			this.pnlEmpDetails.SuspendLayout();
			this.pnlResign.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(926, 80);
			this.panel1.TabIndex = 0;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(2, 520);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(926, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.pnlEmpList);
			this.panel3.Controls.Add(this.splitter1);
			this.panel3.Controls.Add(this.pnlEmpDetails);
			this.panel3.Controls.Add(this.toolStrip1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(2, 82);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(926, 438);
			this.panel3.TabIndex = 3;
			// 
			// pnlEmpList
			// 
			this.pnlEmpList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlEmpList.Controls.Add(this.dgvSal);
			this.pnlEmpList.Controls.Add(this.panel2);
			this.pnlEmpList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlEmpList.Location = new System.Drawing.Point(3, 45);
			this.pnlEmpList.Name = "pnlEmpList";
			this.pnlEmpList.Padding = new System.Windows.Forms.Padding(2);
			this.pnlEmpList.Size = new System.Drawing.Size(609, 390);
			this.pnlEmpList.TabIndex = 3;
			// 
			// dgvSal
			// 
			this.dgvSal.BackgroundColor = System.Drawing.Color.White;
			this.dgvSal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSal.Location = new System.Drawing.Point(2, 41);
			this.dgvSal.Name = "dgvSal";
			this.dgvSal.Size = new System.Drawing.Size(603, 345);
			this.dgvSal.TabIndex = 3;
			this.dgvSal.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSal_CellEnter);
			this.dgvSal.DoubleClick += new System.EventHandler(this.dgvSal_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbFullname);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(603, 39);
			this.panel2.TabIndex = 2;
			// 
			// lbFullname
			// 
			this.lbFullname.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbFullname.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFullname.Location = new System.Drawing.Point(2, 2);
			this.lbFullname.Name = "lbFullname";
			this.lbFullname.Size = new System.Drawing.Size(514, 35);
			this.lbFullname.TabIndex = 1;
			this.lbFullname.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(612, 45);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 390);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// pnlEmpDetails
			// 
			this.pnlEmpDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlEmpDetails.Controls.Add(this.pnlResign);
			this.pnlEmpDetails.Controls.Add(this.panel4);
			this.pnlEmpDetails.Controls.Add(this.panel6);
			this.pnlEmpDetails.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlEmpDetails.Location = new System.Drawing.Point(618, 45);
			this.pnlEmpDetails.Name = "pnlEmpDetails";
			this.pnlEmpDetails.Padding = new System.Windows.Forms.Padding(2);
			this.pnlEmpDetails.Size = new System.Drawing.Size(305, 390);
			this.pnlEmpDetails.TabIndex = 1;
			// 
			// pnlResign
			// 
			this.pnlResign.Controls.Add(this.lbResignDate);
			this.pnlResign.Controls.Add(this.label3);
			this.pnlResign.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlResign.Location = new System.Drawing.Point(2, 58);
			this.pnlResign.Name = "pnlResign";
			this.pnlResign.Padding = new System.Windows.Forms.Padding(1);
			this.pnlResign.Size = new System.Drawing.Size(299, 28);
			this.pnlResign.TabIndex = 4;
			// 
			// lbResignDate
			// 
			this.lbResignDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbResignDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbResignDate.Location = new System.Drawing.Point(111, 1);
			this.lbResignDate.Name = "lbResignDate";
			this.lbResignDate.Size = new System.Drawing.Size(173, 26);
			this.lbResignDate.TabIndex = 1;
			this.lbResignDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(110, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "วันที่ลาออก";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbEmpStatus);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 30);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(299, 28);
			this.panel4.TabIndex = 3;
			// 
			// lbEmpStatus
			// 
			this.lbEmpStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbEmpStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbEmpStatus.Location = new System.Drawing.Point(111, 1);
			this.lbEmpStatus.Name = "lbEmpStatus";
			this.lbEmpStatus.Size = new System.Drawing.Size(173, 26);
			this.lbEmpStatus.TabIndex = 1;
			this.lbEmpStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "สถานะการจ้างงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbDepartment);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(299, 28);
			this.panel6.TabIndex = 2;
			// 
			// lbDepartment
			// 
			this.lbDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbDepartment.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbDepartment.Location = new System.Drawing.Point(111, 1);
			this.lbDepartment.Name = "lbDepartment";
			this.lbDepartment.Size = new System.Drawing.Size(173, 26);
			this.lbDepartment.TabIndex = 1;
			this.lbDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "แผนก";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnEmployee,
            this.toolStripSeparator2,
            this.tsbtnAdd,
            this.toolStripSeparator3,
            this.tsbtnEdit,
            this.toolStripSeparator4,
            this.tsbtnDelete,
            this.toolStripSeparator5,
            this.tsbtnRefresh,
            this.toolStripSeparator6});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.Size = new System.Drawing.Size(920, 42);
			this.toolStrip1.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(80, 42);
			this.tsbtnClose.Text = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnEmployee
			// 
			this.tsbtnEmployee.AutoSize = false;
			this.tsbtnEmployee.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnEmployee.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbtnEmployee.Name = "tsbtnEmployee";
			this.tsbtnEmployee.Size = new System.Drawing.Size(110, 33);
			this.tsbtnEmployee.Text = "รายชื่อพนักงาน";
			this.tsbtnEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.tsbtnEmployee.Click += new System.EventHandler(this.tsbtnEmployee_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(60, 33);
			this.tsbtnAdd.Text = "เพิ่ม";
			this.tsbtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(60, 33);
			this.tsbtnEdit.Text = "แก้ไข";
			this.tsbtnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.AutoSize = false;
			this.tsbtnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(60, 33);
			this.tsbtnDelete.Text = "ลบ";
			this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(80, 33);
			this.tsbtnRefresh.Text = "ปรับปรุง";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 36);
			// 
			// EmpSala
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(930, 544);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EmpSala";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "Employee Salary";
			this.Load += new System.EventHandler(this.EmpSala_Load);
			this.panel3.ResumeLayout(false);
			this.pnlEmpList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSal)).EndInit();
			this.panel2.ResumeLayout(false);
			this.pnlEmpDetails.ResumeLayout(false);
			this.pnlResign.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel pnlEmpList;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlEmpDetails;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEmployee;
		private System.Windows.Forms.Panel pnlResign;
		private System.Windows.Forms.Label lbResignDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbEmpStatus;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lbDepartment;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.DataGridView dgvSal;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbFullname;
	}
}