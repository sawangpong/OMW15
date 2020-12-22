namespace OMW15.Views.CastingView
{
	partial class PrintJobQCOption
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintJobQCOption));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnFindJobQC = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbSelectedJobs = new System.Windows.Forms.Label();
			this.rdoOnlySelectedJobs = new System.Windows.Forms.RadioButton();
			this.rdoAllJobs = new System.Windows.Forms.RadioButton();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnCustomerSearch = new OMControls.OMFlatButton();
			this.lbCustomerName = new System.Windows.Forms.Label();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.chkPrintAllCustomers = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbTotalRows = new System.Windows.Forms.Label();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbxJobCat = new System.Windows.Forms.ComboBox();
			this.lbJobCat = new System.Windows.Forms.Label();
			this.chkPrintAllJobCat = new System.Windows.Forms.CheckBox();
			this.lbCAT = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnPrint);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 234);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(589, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnPrint
			// 
			this.btnPrint.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.Location = new System.Drawing.Point(4, 4);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(127, 34);
			this.btnPrint.TabIndex = 1;
			this.btnPrint.Text = "พิมพ์ใบ Q.C.";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(481, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 34);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Controls.Add(this.panel6);
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
			this.groupBox1.Size = new System.Drawing.Size(589, 227);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Print Q. C. Option";
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.btnFindJobQC);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(10, 168);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(150, 5, 150, 5);
			this.panel7.Size = new System.Drawing.Size(569, 46);
			this.panel7.TabIndex = 5;
			// 
			// btnFindJobQC
			// 
			this.btnFindJobQC.AutoSize = true;
			this.btnFindJobQC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnFindJobQC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnFindJobQC.Location = new System.Drawing.Point(150, 5);
			this.btnFindJobQC.Name = "btnFindJobQC";
			this.btnFindJobQC.Size = new System.Drawing.Size(269, 36);
			this.btnFindJobQC.TabIndex = 3;
			this.btnFindJobQC.Text = "ค้นหารายการ";
			this.btnFindJobQC.UseVisualStyleBackColor = true;
			this.btnFindJobQC.Click += new System.EventHandler(this.bthFindJobQC_Click);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lbSelectedJobs);
			this.panel5.Controls.Add(this.rdoOnlySelectedJobs);
			this.panel5.Controls.Add(this.rdoAllJobs);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 140);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(569, 28);
			this.panel5.TabIndex = 4;
			// 
			// lbSelectedJobs
			// 
			this.lbSelectedJobs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbSelectedJobs.Location = new System.Drawing.Point(306, 1);
			this.lbSelectedJobs.Name = "lbSelectedJobs";
			this.lbSelectedJobs.Size = new System.Drawing.Size(262, 26);
			this.lbSelectedJobs.TabIndex = 2;
			this.lbSelectedJobs.Text = "จำนวนรายการที่ต้องพิมพ์ = 0 รายการ";
			this.lbSelectedJobs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rdoOnlySelectedJobs
			// 
			this.rdoOnlySelectedJobs.AutoSize = true;
			this.rdoOnlySelectedJobs.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoOnlySelectedJobs.Location = new System.Drawing.Point(130, 1);
			this.rdoOnlySelectedJobs.Name = "rdoOnlySelectedJobs";
			this.rdoOnlySelectedJobs.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.rdoOnlySelectedJobs.Size = new System.Drawing.Size(176, 26);
			this.rdoOnlySelectedJobs.TabIndex = 1;
			this.rdoOnlySelectedJobs.TabStop = true;
			this.rdoOnlySelectedJobs.Tag = "SELECT";
			this.rdoOnlySelectedJobs.Text = "พิมพ์เฉพาะรายการที่เลือก";
			this.rdoOnlySelectedJobs.UseVisualStyleBackColor = true;
			this.rdoOnlySelectedJobs.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
			// 
			// rdoAllJobs
			// 
			this.rdoAllJobs.AutoSize = true;
			this.rdoAllJobs.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoAllJobs.Location = new System.Drawing.Point(1, 1);
			this.rdoAllJobs.Name = "rdoAllJobs";
			this.rdoAllJobs.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
			this.rdoAllJobs.Size = new System.Drawing.Size(129, 26);
			this.rdoAllJobs.TabIndex = 0;
			this.rdoAllJobs.TabStop = true;
			this.rdoAllJobs.Tag = "ALL";
			this.rdoAllJobs.Text = "พิมพ์ทุกรายการ";
			this.rdoAllJobs.UseVisualStyleBackColor = true;
			this.rdoAllJobs.CheckedChanged += new System.EventHandler(this.rdoCheckedChanged);
			// 
			// panel6
			// 
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(10, 112);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(569, 28);
			this.panel6.TabIndex = 3;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnCustomerSearch);
			this.panel4.Controls.Add(this.lbCustomerName);
			this.panel4.Controls.Add(this.lbCustomer);
			this.panel4.Controls.Add(this.chkPrintAllCustomers);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 84);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(569, 28);
			this.panel4.TabIndex = 2;
			// 
			// btnCustomerSearch
			// 
			this.btnCustomerSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCustomerSearch.FlatAppearance.BorderSize = 0;
			this.btnCustomerSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnCustomerSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCustomerSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerSearch.Image")));
			this.btnCustomerSearch.Location = new System.Drawing.Point(526, 1);
			this.btnCustomerSearch.Name = "btnCustomerSearch";
			this.btnCustomerSearch.Size = new System.Drawing.Size(26, 26);
			this.btnCustomerSearch.TabIndex = 7;
			this.btnCustomerSearch.UseVisualStyleBackColor = true;
			this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
			// 
			// lbCustomerName
			// 
			this.lbCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomerName.Location = new System.Drawing.Point(209, 1);
			this.lbCustomerName.Name = "lbCustomerName";
			this.lbCustomerName.Size = new System.Drawing.Size(317, 26);
			this.lbCustomerName.TabIndex = 2;
			this.lbCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomer.Location = new System.Drawing.Point(105, 1);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(104, 26);
			this.lbCustomer.TabIndex = 1;
			this.lbCustomer.Text = "เลือกลูกค้า : ";
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkPrintAllCustomers
			// 
			this.chkPrintAllCustomers.AutoSize = true;
			this.chkPrintAllCustomers.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkPrintAllCustomers.Location = new System.Drawing.Point(1, 1);
			this.chkPrintAllCustomers.Name = "chkPrintAllCustomers";
			this.chkPrintAllCustomers.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.chkPrintAllCustomers.Size = new System.Drawing.Size(104, 26);
			this.chkPrintAllCustomers.TabIndex = 0;
			this.chkPrintAllCustomers.Text = "พิมพ์ทุกลูกค้า";
			this.chkPrintAllCustomers.UseVisualStyleBackColor = true;
			this.chkPrintAllCustomers.CheckedChanged += new System.EventHandler(this.chkPrintAllCustomers_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbTotalRows);
			this.panel3.Controls.Add(this.lbCustCode);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 56);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(569, 28);
			this.panel3.TabIndex = 1;
			// 
			// lbTotalRows
			// 
			this.lbTotalRows.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTotalRows.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalRows.Location = new System.Drawing.Point(1, 1);
			this.lbTotalRows.Name = "lbTotalRows";
			this.lbTotalRows.Size = new System.Drawing.Size(104, 26);
			this.lbTotalRows.TabIndex = 3;
			this.lbTotalRows.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbCustCode
			// 
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbCustCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustCode.Location = new System.Drawing.Point(464, 1);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(104, 26);
			this.lbCustCode.TabIndex = 2;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCAT);
			this.panel2.Controls.Add(this.cbxJobCat);
			this.panel2.Controls.Add(this.lbJobCat);
			this.panel2.Controls.Add(this.chkPrintAllJobCat);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 28);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(569, 28);
			this.panel2.TabIndex = 0;
			// 
			// cbxJobCat
			// 
			this.cbxJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobCat.FormattingEnabled = true;
			this.cbxJobCat.Location = new System.Drawing.Point(257, 1);
			this.cbxJobCat.Name = "cbxJobCat";
			this.cbxJobCat.Size = new System.Drawing.Size(136, 25);
			this.cbxJobCat.TabIndex = 18;
			this.cbxJobCat.SelectionChangeCommitted += new System.EventHandler(this.cbxJobCat_SelectionChangeCommitted);
			// 
			// lbJobCat
			// 
			this.lbJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobCat.Location = new System.Drawing.Point(133, 1);
			this.lbJobCat.Name = "lbJobCat";
			this.lbJobCat.Size = new System.Drawing.Size(124, 26);
			this.lbJobCat.TabIndex = 1;
			this.lbJobCat.Text = "เลือกประเภทงาน [-] : ";
			this.lbJobCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkPrintAllJobCat
			// 
			this.chkPrintAllJobCat.AutoSize = true;
			this.chkPrintAllJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkPrintAllJobCat.Location = new System.Drawing.Point(1, 1);
			this.chkPrintAllJobCat.Name = "chkPrintAllJobCat";
			this.chkPrintAllJobCat.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.chkPrintAllJobCat.Size = new System.Drawing.Size(132, 26);
			this.chkPrintAllJobCat.TabIndex = 0;
			this.chkPrintAllJobCat.Text = "พิมพ์ทุกประเภทงาน";
			this.chkPrintAllJobCat.UseVisualStyleBackColor = true;
			this.chkPrintAllJobCat.CheckedChanged += new System.EventHandler(this.chkPrintAllJobCat_CheckedChanged);
			// 
			// lbCAT
			// 
			this.lbCAT.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbCAT.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCAT.Location = new System.Drawing.Point(464, 1);
			this.lbCAT.Name = "lbCAT";
			this.lbCAT.Size = new System.Drawing.Size(104, 26);
			this.lbCAT.TabIndex = 19;
			this.lbCAT.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.lbCAT.Visible = false;
			// 
			// PrintJobQCOption
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(599, 281);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PrintJobQCOption";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "Q.C. Option";
			this.Load += new System.EventHandler(this.PrintJobQCOption_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbJobCat;
		private System.Windows.Forms.CheckBox chkPrintAllJobCat;
		private System.Windows.Forms.ComboBox cbxJobCat;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbCustomerName;
		private System.Windows.Forms.Label lbCustomer;
		private System.Windows.Forms.CheckBox chkPrintAllCustomers;
		private System.Windows.Forms.Panel panel3;
		private OMControls.OMFlatButton btnCustomerSearch;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.RadioButton rdoOnlySelectedJobs;
		private System.Windows.Forms.RadioButton rdoAllJobs;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label lbSelectedJobs;
		private System.Windows.Forms.Label lbCustCode;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button btnFindJobQC;
		private System.Windows.Forms.Label lbTotalRows;
		private System.Windows.Forms.Label lbCAT;
	}
}