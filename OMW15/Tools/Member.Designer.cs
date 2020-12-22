namespace OMW15.Tools
{
	partial class Member
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
				_om.Dispose();
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
			this.lbMode = new System.Windows.Forms.Label();
			this.lbHeader = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cbxPermission = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnShowPassword = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.chkActiveUser = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 213);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.panel1.Size = new System.Drawing.Size(382, 49);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(177, 6);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 37);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(277, 6);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 37);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.lbMode);
			this.panel2.Controls.Add(this.lbHeader);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 6);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(382, 53);
			this.panel2.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Blue;
			this.lbMode.Location = new System.Drawing.Point(301, 2);
			this.lbMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(79, 49);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbHeader
			// 
			this.lbHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.Location = new System.Drawing.Point(2, 2);
			this.lbHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(163, 49);
			this.lbHeader.TabIndex = 0;
			this.lbHeader.Text = "Member Properties";
			this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtUserName);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 59);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(22, 2, 2, 2);
			this.panel3.Size = new System.Drawing.Size(382, 30);
			this.panel3.TabIndex = 2;
			// 
			// txtUserName
			// 
			this.txtUserName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUserName.Location = new System.Drawing.Point(139, 2);
			this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtUserName.MaxLength = 50;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(217, 25);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(22, 2);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.cbxPermission);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 89);
			this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(22, 2, 2, 2);
			this.panel4.Size = new System.Drawing.Size(382, 30);
			this.panel4.TabIndex = 3;
			// 
			// cbxPermission
			// 
			this.cbxPermission.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPermission.FormattingEnabled = true;
			this.cbxPermission.Location = new System.Drawing.Point(139, 2);
			this.cbxPermission.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cbxPermission.Name = "cbxPermission";
			this.cbxPermission.Size = new System.Drawing.Size(217, 25);
			this.cbxPermission.TabIndex = 1;
			this.cbxPermission.SelectedValueChanged += new System.EventHandler(this.cbxPermission_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(22, 2);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Permission Class :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnShowPassword);
			this.panel5.Controls.Add(this.txtPassword);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(5, 119);
			this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(22, 2, 2, 2);
			this.panel5.Size = new System.Drawing.Size(382, 30);
			this.panel5.TabIndex = 4;
			// 
			// btnShowPassword
			// 
			this.btnShowPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnShowPassword.FlatAppearance.BorderSize = 0;
			this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnShowPassword.Image = global::OMW15.Properties.Resources.key;
			this.btnShowPassword.Location = new System.Drawing.Point(282, 2);
			this.btnShowPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnShowPassword.Name = "btnShowPassword";
			this.btnShowPassword.Size = new System.Drawing.Size(23, 26);
			this.btnShowPassword.TabIndex = 3;
			this.btnShowPassword.UseVisualStyleBackColor = true;
			this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
			// 
			// txtPassword
			// 
			this.txtPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPassword.Location = new System.Drawing.Point(139, 2);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtPassword.MaxLength = 15;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(143, 25);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(22, 2);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(117, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "Password :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtConfirmPassword);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(5, 149);
			this.panel6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(22, 2, 2, 2);
			this.panel6.Size = new System.Drawing.Size(382, 30);
			this.panel6.TabIndex = 5;
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtConfirmPassword.Location = new System.Drawing.Point(139, 2);
			this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtConfirmPassword.MaxLength = 15;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Size = new System.Drawing.Size(143, 25);
			this.txtConfirmPassword.TabIndex = 3;
			this.txtConfirmPassword.UseSystemPasswordChar = true;
			this.txtConfirmPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(22, 2);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "Confirm Password :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.chkActiveUser);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(5, 179);
			this.panel7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(22, 2, 2, 2);
			this.panel7.Size = new System.Drawing.Size(382, 30);
			this.panel7.TabIndex = 6;
			// 
			// chkActiveUser
			// 
			this.chkActiveUser.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkActiveUser.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkActiveUser.Image = global::OMW15.Properties.Resources.LockSmall;
			this.chkActiveUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkActiveUser.Location = new System.Drawing.Point(22, 2);
			this.chkActiveUser.Margin = new System.Windows.Forms.Padding(26, 3, 2, 3);
			this.chkActiveUser.Name = "chkActiveUser";
			this.chkActiveUser.Size = new System.Drawing.Size(131, 26);
			this.chkActiveUser.TabIndex = 0;
			this.chkActiveUser.Text = "User Lock ?:";
			this.chkActiveUser.UseVisualStyleBackColor = true;
			// 
			// Member
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(392, 268);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Member";
			this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.Text = "MEMBER";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Member_FormClosing);
			this.Load += new System.EventHandler(this.Member_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.CheckBox chkActiveUser;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.ComboBox cbxPermission;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Button btnShowPassword;
	}
}