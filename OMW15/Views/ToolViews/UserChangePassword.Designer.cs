namespace OMW15.Views.ToolViews
{
	partial class UserChangePassword
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAcceptChangePassword = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtConfirmPassword = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtNewPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtOldPassword = new System.Windows.Forms.TextBox();
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
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnAcceptChangePassword);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(9, 156);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(312, 38);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(216, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 34);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnAcceptChangePassword
			// 
			this.btnAcceptChangePassword.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAcceptChangePassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAcceptChangePassword.Location = new System.Drawing.Point(2, 2);
			this.btnAcceptChangePassword.Name = "btnAcceptChangePassword";
			this.btnAcceptChangePassword.Size = new System.Drawing.Size(179, 34);
			this.btnAcceptChangePassword.TabIndex = 0;
			this.btnAcceptChangePassword.Text = "Confirm Change Password";
			this.btnAcceptChangePassword.UseVisualStyleBackColor = true;
			this.btnAcceptChangePassword.Click += new System.EventHandler(this.btnAcceptChangePassword_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(9, 21);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.groupBox1.Size = new System.Drawing.Size(312, 135);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "User Password";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtConfirmPassword);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 84);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(302, 30);
			this.panel4.TabIndex = 2;
			// 
			// txtConfirmPassword
			// 
			this.txtConfirmPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtConfirmPassword.Location = new System.Drawing.Point(116, 2);
			this.txtConfirmPassword.MaxLength = 15;
			this.txtConfirmPassword.Name = "txtConfirmPassword";
			this.txtConfirmPassword.Size = new System.Drawing.Size(172, 25);
			this.txtConfirmPassword.TabIndex = 2;
			this.txtConfirmPassword.UseSystemPasswordChar = true;
			this.txtConfirmPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
			this.txtConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmPassword_KeyPress);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "Confirm Password :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtNewPassword);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 54);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(302, 30);
			this.panel3.TabIndex = 1;
			// 
			// txtNewPassword
			// 
			this.txtNewPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtNewPassword.Location = new System.Drawing.Point(116, 2);
			this.txtNewPassword.MaxLength = 15;
			this.txtNewPassword.Name = "txtNewPassword";
			this.txtNewPassword.Size = new System.Drawing.Size(172, 25);
			this.txtNewPassword.TabIndex = 2;
			this.txtNewPassword.UseSystemPasswordChar = true;
			this.txtNewPassword.TextChanged += new System.EventHandler(this.Password_TextChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "New Password :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtOldPassword);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 24);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(302, 30);
			this.panel2.TabIndex = 0;
			// 
			// txtOldPassword
			// 
			this.txtOldPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtOldPassword.Location = new System.Drawing.Point(116, 2);
			this.txtOldPassword.MaxLength = 15;
			this.txtOldPassword.Name = "txtOldPassword";
			this.txtOldPassword.Size = new System.Drawing.Size(172, 25);
			this.txtOldPassword.TabIndex = 1;
			this.txtOldPassword.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Old Password :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UserChangePassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(330, 205);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UserChangePassword";
			this.Padding = new System.Windows.Forms.Padding(9, 21, 9, 11);
			this.Text = "CHANGE PASSWORD";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserChangePassword_FormClosing);
			this.Load += new System.EventHandler(this.UserChangePassword_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAcceptChangePassword;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtConfirmPassword;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtNewPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtOldPassword;
		private System.Windows.Forms.Label label1;
	}
}