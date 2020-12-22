namespace OMW15.Views.ServiceView
{
	partial class ServiceEngineerInfo
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dtpResignDate = new System.Windows.Forms.DateTimePicker();
			this.lbResignDate = new System.Windows.Forms.Label();
			this.cbxStatus = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbStatus = new System.Windows.Forms.Label();
			this.txtEngId = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(8, 143);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Size = new System.Drawing.Size(396, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(212, 5);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(90, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(302, 5);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(90, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(8, 9);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.groupBox1.Size = new System.Drawing.Size(396, 134);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "ช่างบริการ";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dtpResignDate);
			this.panel4.Controls.Add(this.lbResignDate);
			this.panel4.Controls.Add(this.cbxStatus);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(8, 87);
			this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(380, 30);
			this.panel4.TabIndex = 2;
			// 
			// dtpResignDate
			// 
			this.dtpResignDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpResignDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpResignDate.Location = new System.Drawing.Point(239, 2);
			this.dtpResignDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dtpResignDate.Name = "dtpResignDate";
			this.dtpResignDate.Size = new System.Drawing.Size(114, 25);
			this.dtpResignDate.TabIndex = 4;
			// 
			// lbResignDate
			// 
			this.lbResignDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbResignDate.Location = new System.Drawing.Point(181, 2);
			this.lbResignDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbResignDate.Name = "lbResignDate";
			this.lbResignDate.Size = new System.Drawing.Size(58, 26);
			this.lbResignDate.TabIndex = 3;
			this.lbResignDate.Text = "วันที่ออก:";
			this.lbResignDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxStatus
			// 
			this.cbxStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxStatus.FormattingEnabled = true;
			this.cbxStatus.Location = new System.Drawing.Point(46, 2);
			this.cbxStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cbxStatus.Name = "cbxStatus";
			this.cbxStatus.Size = new System.Drawing.Size(135, 25);
			this.cbxStatus.TabIndex = 1;
			this.cbxStatus.SelectedValueChanged += new System.EventHandler(this.cbxStatus_SelectedValueChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "สถานะ:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtLastName);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.txtName);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(8, 57);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(380, 30);
			this.panel3.TabIndex = 1;
			// 
			// txtLastName
			// 
			this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLastName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtLastName.Location = new System.Drawing.Point(239, 2);
			this.txtLastName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtLastName.MaxLength = 50;
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(135, 25);
			this.txtLastName.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(181, 2);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "นามสกุล:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtName
			// 
			this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtName.Location = new System.Drawing.Point(46, 2);
			this.txtName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtName.MaxLength = 50;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(135, 25);
			this.txtName.TabIndex = 1;
			this.txtName.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "ชื่อ:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbStatus);
			this.panel2.Controls.Add(this.txtEngId);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(8, 27);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(380, 30);
			this.panel2.TabIndex = 0;
			// 
			// lbStatus
			// 
			this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbStatus.Location = new System.Drawing.Point(334, 2);
			this.lbStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(44, 26);
			this.lbStatus.TabIndex = 2;
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtEngId
			// 
			this.txtEngId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEngId.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtEngId.Location = new System.Drawing.Point(46, 2);
			this.txtEngId.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtEngId.MaxLength = 4;
			this.txtEngId.Name = "txtEngId";
			this.txtEngId.Size = new System.Drawing.Size(55, 25);
			this.txtEngId.TabIndex = 1;
			this.txtEngId.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัส:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ServiceEngineerInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(412, 194);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ServiceEngineerInfo";
			this.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.Text = "Engineer Info";
			this.Load += new System.EventHandler(this.ServiceEngineerInfo_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DateTimePicker dtpResignDate;
		private System.Windows.Forms.Label lbResignDate;
		private System.Windows.Forms.ComboBox cbxStatus;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEngId;
		private System.Windows.Forms.Label lbStatus;
	}
}