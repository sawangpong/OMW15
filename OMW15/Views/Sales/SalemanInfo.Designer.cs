namespace OMW15.Views.Sales
{
	partial class SalemanInfo
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
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSalemanName = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEmail1 = new System.Windows.Forms.TextBox();
			this.txtEmail2 = new System.Windows.Forms.TextBox();
			this.txtMobile = new System.Windows.Forms.TextBox();
			this.chkActiveSaleman = new System.Windows.Forms.CheckBox();
			this.lbMode = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(10, 160);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(633, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(424, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(102, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(526, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(102, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbMode);
			this.panel3.Controls.Add(this.chkActiveSaleman);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 10);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(633, 26);
			this.panel3.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtSalemanName);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 36);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(633, 26);
			this.panel4.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtMobile);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 62);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(633, 26);
			this.panel5.TabIndex = 4;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtEmail1);
			this.panel6.Controls.Add(this.label3);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(10, 88);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(633, 26);
			this.panel6.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(129, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name / Surname :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtSalemanName
			// 
			this.txtSalemanName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSalemanName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSalemanName.Location = new System.Drawing.Point(129, 0);
			this.txtSalemanName.MaxLength = 150;
			this.txtSalemanName.Name = "txtSalemanName";
			this.txtSalemanName.Size = new System.Drawing.Size(357, 25);
			this.txtSalemanName.TabIndex = 2;
			this.txtSalemanName.TextChanged += new System.EventHandler(this.txtSalemanName_TextChanged);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtEmail2);
			this.panel2.Controls.Add(this.label5);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 114);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(633, 26);
			this.panel2.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(129, 26);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tel / Mobile :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(129, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "E-mail 1 :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(129, 26);
			this.label5.TabIndex = 3;
			this.label5.Text = "E-mail 2 :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEmail1
			// 
			this.txtEmail1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtEmail1.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtEmail1.Location = new System.Drawing.Point(129, 0);
			this.txtEmail1.MaxLength = 255;
			this.txtEmail1.Name = "txtEmail1";
			this.txtEmail1.Size = new System.Drawing.Size(488, 25);
			this.txtEmail1.TabIndex = 3;
			// 
			// txtEmail2
			// 
			this.txtEmail2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtEmail2.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtEmail2.Location = new System.Drawing.Point(129, 0);
			this.txtEmail2.MaxLength = 255;
			this.txtEmail2.Name = "txtEmail2";
			this.txtEmail2.Size = new System.Drawing.Size(488, 25);
			this.txtEmail2.TabIndex = 4;
			// 
			// txtMobile
			// 
			this.txtMobile.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMobile.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMobile.Location = new System.Drawing.Point(129, 0);
			this.txtMobile.MaxLength = 50;
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.Size = new System.Drawing.Size(275, 25);
			this.txtMobile.TabIndex = 3;
			// 
			// chkActiveSaleman
			// 
			this.chkActiveSaleman.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkActiveSaleman.Location = new System.Drawing.Point(0, 0);
			this.chkActiveSaleman.Name = "chkActiveSaleman";
			this.chkActiveSaleman.Padding = new System.Windows.Forms.Padding(127, 0, 0, 0);
			this.chkActiveSaleman.Size = new System.Drawing.Size(248, 26);
			this.chkActiveSaleman.TabIndex = 0;
			this.chkActiveSaleman.Text = "Active Person";
			this.chkActiveSaleman.UseVisualStyleBackColor = true;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.Location = new System.Drawing.Point(526, 0);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(107, 26);
			this.lbMode.TabIndex = 3;
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SalemanInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(653, 212);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SalemanInfo";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "SALE PERSON INFO";
			this.Load += new System.EventHandler(this.SalemanInfo_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.CheckBox chkActiveSaleman;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtSalemanName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtMobile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtEmail1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtEmail2;
		private System.Windows.Forms.Label label5;
	}
}