namespace OMW15.Views.BankView
{
	partial class BankInfo
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtBankCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtBankNameEn = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtBankNameTh = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtBranch = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.cbxACType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtACName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtACNo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtSwift = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.cbxAccountDisable = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel11.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 330);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(603, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(346, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(127, 36);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(473, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(127, 36);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbTitle);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(603, 50);
			this.panel2.TabIndex = 1;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(1, 1);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(601, 48);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Bank Account Info";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtBankCode);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 53);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(603, 28);
			this.panel3.TabIndex = 2;
			// 
			// txtBankCode
			// 
			this.txtBankCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBankCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBankCode.Location = new System.Drawing.Point(118, 1);
			this.txtBankCode.MaxLength = 10;
			this.txtBankCode.Name = "txtBankCode";
			this.txtBankCode.Size = new System.Drawing.Size(103, 25);
			this.txtBankCode.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bank Code :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtBankNameEn);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(3, 81);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(603, 28);
			this.panel4.TabIndex = 4;
			// 
			// txtBankNameEn
			// 
			this.txtBankNameEn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBankNameEn.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBankNameEn.Location = new System.Drawing.Point(118, 1);
			this.txtBankNameEn.MaxLength = 150;
			this.txtBankNameEn.Name = "txtBankNameEn";
			this.txtBankNameEn.Size = new System.Drawing.Size(457, 25);
			this.txtBankNameEn.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Bank Name (En) :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtBankNameTh);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(3, 109);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(603, 28);
			this.panel5.TabIndex = 5;
			// 
			// txtBankNameTh
			// 
			this.txtBankNameTh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBankNameTh.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBankNameTh.Location = new System.Drawing.Point(118, 1);
			this.txtBankNameTh.MaxLength = 150;
			this.txtBankNameTh.Name = "txtBankNameTh";
			this.txtBankNameTh.Size = new System.Drawing.Size(457, 25);
			this.txtBankNameTh.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "Bank Name (Th) :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtBranch);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 137);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(603, 28);
			this.panel6.TabIndex = 6;
			// 
			// txtBranch
			// 
			this.txtBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBranch.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBranch.Location = new System.Drawing.Point(118, 1);
			this.txtBranch.MaxLength = 50;
			this.txtBranch.Name = "txtBranch";
			this.txtBranch.Size = new System.Drawing.Size(278, 25);
			this.txtBranch.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "Branch :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.cbxACType);
			this.panel7.Controls.Add(this.label5);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(3, 165);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(603, 28);
			this.panel7.TabIndex = 7;
			// 
			// cbxACType
			// 
			this.cbxACType.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxACType.FormattingEnabled = true;
			this.cbxACType.Location = new System.Drawing.Point(118, 1);
			this.cbxACType.Name = "cbxACType";
			this.cbxACType.Size = new System.Drawing.Size(203, 25);
			this.cbxACType.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(117, 26);
			this.label5.TabIndex = 0;
			this.label5.Text = "Account Type :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtACName);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(3, 193);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(603, 28);
			this.panel8.TabIndex = 8;
			// 
			// txtACName
			// 
			this.txtACName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtACName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtACName.Location = new System.Drawing.Point(118, 1);
			this.txtACName.MaxLength = 50;
			this.txtACName.Name = "txtACName";
			this.txtACName.Size = new System.Drawing.Size(278, 25);
			this.txtACName.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(117, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "Account Name :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtACNo);
			this.panel9.Controls.Add(this.label7);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(3, 221);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(603, 28);
			this.panel9.TabIndex = 9;
			// 
			// txtACNo
			// 
			this.txtACNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtACNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtACNo.Location = new System.Drawing.Point(118, 1);
			this.txtACNo.MaxLength = 50;
			this.txtACNo.Name = "txtACNo";
			this.txtACNo.Size = new System.Drawing.Size(278, 25);
			this.txtACNo.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(117, 26);
			this.label7.TabIndex = 0;
			this.label7.Text = "Account No. :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtSwift);
			this.panel10.Controls.Add(this.label8);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(3, 249);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(603, 28);
			this.panel10.TabIndex = 10;
			// 
			// txtSwift
			// 
			this.txtSwift.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSwift.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSwift.Location = new System.Drawing.Point(118, 1);
			this.txtSwift.MaxLength = 50;
			this.txtSwift.Name = "txtSwift";
			this.txtSwift.Size = new System.Drawing.Size(278, 25);
			this.txtSwift.TabIndex = 1;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(117, 26);
			this.label8.TabIndex = 0;
			this.label8.Text = "SWIFT Code :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.cbxAccountDisable);
			this.panel11.Controls.Add(this.label10);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(3, 277);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(1);
			this.panel11.Size = new System.Drawing.Size(603, 28);
			this.panel11.TabIndex = 11;
			// 
			// cbxAccountDisable
			// 
			this.cbxAccountDisable.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxAccountDisable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxAccountDisable.FormattingEnabled = true;
			this.cbxAccountDisable.Items.AddRange(new object[] {
            "Yes",
            "No"});
			this.cbxAccountDisable.Location = new System.Drawing.Point(118, 1);
			this.cbxAccountDisable.Name = "cbxAccountDisable";
			this.cbxAccountDisable.Size = new System.Drawing.Size(103, 25);
			this.cbxAccountDisable.TabIndex = 2;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(1, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(117, 26);
			this.label10.TabIndex = 0;
			this.label10.Text = "Account Disable :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BankInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 375);
			this.Controls.Add(this.panel11);
			this.Controls.Add(this.panel10);
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BankInfo";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "BankInfo";
			this.Load += new System.EventHandler(this.BankInfo_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtBankCode;
		private System.Windows.Forms.TextBox txtBankNameEn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtBankNameTh;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtBranch;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.ComboBox cbxACType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.TextBox txtACName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TextBox txtACNo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.TextBox txtSwift;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.ComboBox cbxAccountDisable;
		private System.Windows.Forms.Label label10;
	}
}