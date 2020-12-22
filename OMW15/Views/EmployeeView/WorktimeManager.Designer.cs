namespace OMW15.Views.EmployeeView
{
	partial class WorktimeManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorktimeManager));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbEmpCode = new System.Windows.Forms.Label();
			this.btnSearchEmp = new OMControls.OMFlatButton();
			this.txtEmpName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnSearchWorkDate = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.monthPopup1 = new OMControls.MonthPopup();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkAllRecordInMonth = new System.Windows.Forms.CheckBox();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlTop.Controls.Add(this.lbTitle);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(608, 50);
			this.pnlTop.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(419, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(187, 46);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Work-time Manager";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbEmpCode);
			this.panel1.Controls.Add(this.btnSearchEmp);
			this.panel1.Controls.Add(this.txtEmpName);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(604, 30);
			this.panel1.TabIndex = 2;
			// 
			// lbEmpCode
			// 
			this.lbEmpCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbEmpCode.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.lbEmpCode.Location = new System.Drawing.Point(363, 2);
			this.lbEmpCode.Name = "lbEmpCode";
			this.lbEmpCode.Size = new System.Drawing.Size(49, 26);
			this.lbEmpCode.TabIndex = 3;
			this.lbEmpCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSearchEmp
			// 
			this.btnSearchEmp.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearchEmp.FlatAppearance.BorderSize = 0;
			this.btnSearchEmp.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchEmp.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchEmp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchEmp.Image")));
			this.btnSearchEmp.Location = new System.Drawing.Point(337, 2);
			this.btnSearchEmp.Name = "btnSearchEmp";
			this.btnSearchEmp.Size = new System.Drawing.Size(26, 26);
			this.btnSearchEmp.TabIndex = 2;
			this.btnSearchEmp.UseVisualStyleBackColor = true;
			this.btnSearchEmp.Click += new System.EventHandler(this.btnSearchEmp_Click);
			// 
			// txtEmpName
			// 
			this.txtEmpName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtEmpName.Location = new System.Drawing.Point(110, 2);
			this.txtEmpName.MaxLength = 50;
			this.txtEmpName.Name = "txtEmpName";
			this.txtEmpName.Size = new System.Drawing.Size(227, 25);
			this.txtEmpName.TabIndex = 1;
			this.txtEmpName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpName_KeyPress);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "พนักงาน :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgv);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(608, 224);
			this.panel2.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 120);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(604, 102);
			this.dgv.TabIndex = 6;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 32);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(604, 88);
			this.panel3.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnSearchWorkDate);
			this.panel5.Controls.Add(this.btnClose);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(3, 49);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(598, 36);
			this.panel5.TabIndex = 7;
			// 
			// btnSearchWorkDate
			// 
			this.btnSearchWorkDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearchWorkDate.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.btnSearchWorkDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnSearchWorkDate.Location = new System.Drawing.Point(5, 5);
			this.btnSearchWorkDate.Name = "btnSearchWorkDate";
			this.btnSearchWorkDate.Size = new System.Drawing.Size(102, 26);
			this.btnSearchWorkDate.TabIndex = 7;
			this.btnSearchWorkDate.Text = "&ค้นหา";
			this.btnSearchWorkDate.UseVisualStyleBackColor = true;
			this.btnSearchWorkDate.Click += new System.EventHandler(this.btnSearchWorkDate_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(506, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(87, 26);
			this.btnClose.TabIndex = 6;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.chkAllRecordInMonth);
			this.panel4.Controls.Add(this.monthPopup1);
			this.panel4.Controls.Add(this.txtDate);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(3, 3);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(598, 30);
			this.panel4.TabIndex = 4;
			// 
			// monthPopup1
			// 
			this.monthPopup1.Dock = System.Windows.Forms.DockStyle.Left;
			this.monthPopup1.Location = new System.Drawing.Point(254, 2);
			this.monthPopup1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.monthPopup1.Name = "monthPopup1";
			this.monthPopup1.SelectedDate = new System.DateTime(2020, 8, 7, 0, 0, 0, 0);
			this.monthPopup1.Size = new System.Drawing.Size(26, 26);
			this.monthPopup1.TabIndex = 4;
			this.monthPopup1.DateSelected += new System.EventHandler(this.monthPopup1_DateSelected);
			this.monthPopup1.ButtonClick += new System.EventHandler(this.monthPopup1_ButtonClick);
			// 
			// txtDate
			// 
			this.txtDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDate.Location = new System.Drawing.Point(107, 2);
			this.txtDate.MaxLength = 10;
			this.txtDate.Name = "txtDate";
			this.txtDate.Size = new System.Drawing.Size(147, 25);
			this.txtDate.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "วันที่ทำงาน :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkAllRecordInMonth
			// 
			this.chkAllRecordInMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkAllRecordInMonth.Location = new System.Drawing.Point(280, 2);
			this.chkAllRecordInMonth.Name = "chkAllRecordInMonth";
			this.chkAllRecordInMonth.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
			this.chkAllRecordInMonth.Size = new System.Drawing.Size(166, 26);
			this.chkAllRecordInMonth.TabIndex = 5;
			this.chkAllRecordInMonth.Text = "แสดงข้อมูลทั้งเดือน";
			this.chkAllRecordInMonth.UseVisualStyleBackColor = true;
			// 
			// WorktimeManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(608, 274);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorktimeManager";
			this.Text = "WorktimeManager";
			this.Load += new System.EventHandler(this.WorktimeManager_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private OMControls.OMFlatButton btnSearchEmp;
		private System.Windows.Forms.TextBox txtEmpName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbEmpCode;
		private System.Windows.Forms.Panel panel4;
		private OMControls.MonthPopup monthPopup1;
		private System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnSearchWorkDate;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkAllRecordInMonth;
	}
}