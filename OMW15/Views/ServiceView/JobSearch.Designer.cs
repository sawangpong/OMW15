namespace OMW15.Views.ServiceView
{
	partial class JobSearch
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.grp2 = new System.Windows.Forms.GroupBox();
			this.rdoSerial = new System.Windows.Forms.RadioButton();
			this.rdoModel = new System.Windows.Forms.RadioButton();
			this.rdoCustomer = new System.Windows.Forms.RadioButton();
			this.rdoJobNo = new System.Windows.Forms.RadioButton();
			this.chkFixSearch = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grp2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 200);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(514, 45);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(378, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(131, 35);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearch.Location = new System.Drawing.Point(5, 5);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(131, 35);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "&Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(514, 200);
			this.panel2.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkFixSearch);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Controls.Add(this.grp2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.groupBox1.Size = new System.Drawing.Size(494, 180);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtFilter);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(3, 73);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(488, 57);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "ข้อความที่ค้นหา";
			// 
			// txtFilter
			// 
			this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFilter.Location = new System.Drawing.Point(3, 20);
			this.txtFilter.MaxLength = 50;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(482, 24);
			this.txtFilter.TabIndex = 0;
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
			// 
			// grp2
			// 
			this.grp2.Controls.Add(this.rdoSerial);
			this.grp2.Controls.Add(this.rdoModel);
			this.grp2.Controls.Add(this.rdoCustomer);
			this.grp2.Controls.Add(this.rdoJobNo);
			this.grp2.Dock = System.Windows.Forms.DockStyle.Top;
			this.grp2.Location = new System.Drawing.Point(3, 17);
			this.grp2.Name = "grp2";
			this.grp2.Size = new System.Drawing.Size(488, 56);
			this.grp2.TabIndex = 0;
			this.grp2.TabStop = false;
			this.grp2.Text = "[หาจาก]";
			// 
			// rdoSerial
			// 
			this.rdoSerial.AutoSize = true;
			this.rdoSerial.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoSerial.Location = new System.Drawing.Point(344, 20);
			this.rdoSerial.Name = "rdoSerial";
			this.rdoSerial.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoSerial.Size = new System.Drawing.Size(136, 33);
			this.rdoSerial.TabIndex = 3;
			this.rdoSerial.TabStop = true;
			this.rdoSerial.Tag = "SERIAL";
			this.rdoSerial.Text = "ซีเรียลเครื่องจักร";
			this.rdoSerial.UseVisualStyleBackColor = true;
			this.rdoSerial.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoModel
			// 
			this.rdoModel.AutoSize = true;
			this.rdoModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoModel.Location = new System.Drawing.Point(227, 20);
			this.rdoModel.Name = "rdoModel";
			this.rdoModel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoModel.Size = new System.Drawing.Size(117, 33);
			this.rdoModel.TabIndex = 2;
			this.rdoModel.TabStop = true;
			this.rdoModel.Tag = "MODEL";
			this.rdoModel.Text = "รุ่นเครื่องจักร";
			this.rdoModel.UseVisualStyleBackColor = true;
			this.rdoModel.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoCustomer
			// 
			this.rdoCustomer.AutoSize = true;
			this.rdoCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoCustomer.Location = new System.Drawing.Point(136, 20);
			this.rdoCustomer.Name = "rdoCustomer";
			this.rdoCustomer.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoCustomer.Size = new System.Drawing.Size(91, 33);
			this.rdoCustomer.TabIndex = 1;
			this.rdoCustomer.TabStop = true;
			this.rdoCustomer.Tag = "CUSTOMER";
			this.rdoCustomer.Text = "ชื่อลูกค้า";
			this.rdoCustomer.UseVisualStyleBackColor = true;
			this.rdoCustomer.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoJobNo
			// 
			this.rdoJobNo.AutoSize = true;
			this.rdoJobNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoJobNo.Location = new System.Drawing.Point(3, 20);
			this.rdoJobNo.Name = "rdoJobNo";
			this.rdoJobNo.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.rdoJobNo.Size = new System.Drawing.Size(133, 33);
			this.rdoJobNo.TabIndex = 0;
			this.rdoJobNo.TabStop = true;
			this.rdoJobNo.Tag = "JOBNO";
			this.rdoJobNo.Text = "หมายเลขใบงาน";
			this.rdoJobNo.UseVisualStyleBackColor = true;
			this.rdoJobNo.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// chkFixSearch
			// 
			this.chkFixSearch.AutoSize = true;
			this.chkFixSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.chkFixSearch.Location = new System.Drawing.Point(3, 130);
			this.chkFixSearch.Name = "chkFixSearch";
			this.chkFixSearch.Padding = new System.Windows.Forms.Padding(10);
			this.chkFixSearch.Size = new System.Drawing.Size(488, 42);
			this.chkFixSearch.TabIndex = 2;
			this.chkFixSearch.Text = "ค้นหาเฉพาะเงื่อนไขที่กำหนดเท่านั้น";
			this.chkFixSearch.UseVisualStyleBackColor = true;
			// 
			// JobSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(514, 245);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "JobSearch";
			this.Text = "Job Order Search";
			this.Load += new System.EventHandler(this.JobSearch_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grp2.ResumeLayout(false);
			this.grp2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox grp2;
		private System.Windows.Forms.RadioButton rdoSerial;
		private System.Windows.Forms.RadioButton rdoModel;
		private System.Windows.Forms.RadioButton rdoCustomer;
		private System.Windows.Forms.RadioButton rdoJobNo;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.CheckBox chkFixSearch;
	}
}