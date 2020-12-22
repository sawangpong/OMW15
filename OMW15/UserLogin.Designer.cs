namespace OMW15
{
	partial class UserLogin
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
				//_om.Dispose();
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
			this.btnLogin = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lklbChangeAppConfig = new System.Windows.Forms.LinkLabel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtERPDatabase = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtERPServer = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtSysDatabase = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtMainServer = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnLogin);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(15, 338);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(45, 5, 45, 5);
			this.panel1.Size = new System.Drawing.Size(339, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnCancel.Location = new System.Drawing.Point(186, 5);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(108, 32);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnLogin.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnLogin.Location = new System.Drawing.Point(45, 5);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(108, 32);
			this.btnLogin.TabIndex = 0;
			this.btnLogin.Text = "&Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(15, 17);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(339, 46);
			this.panel2.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(339, 46);
			this.label3.TabIndex = 0;
			this.label3.Text = "ลงชื่อใช้งาน";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Controls.Add(this.groupBox1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(15, 63);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(339, 267);
			this.panel3.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtPassword);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 229);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(335, 30);
			this.panel4.TabIndex = 12;
			// 
			// txtPassword
			// 
			this.txtPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPassword.Location = new System.Drawing.Point(107, 2);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtPassword.MaxLength = 15;
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(168, 25);
			this.txtPassword.TabIndex = 2;
			this.txtPassword.UseSystemPasswordChar = true;
			this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtUserName);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 199);
			this.panel6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(335, 30);
			this.panel6.TabIndex = 11;
			// 
			// txtUserName
			// 
			this.txtUserName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUserName.Location = new System.Drawing.Point(107, 2);
			this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtUserName.MaxLength = 50;
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(167, 25);
			this.txtUserName.TabIndex = 2;
			this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
			this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_KeyPress);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "User name :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Controls.Add(this.panel10);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Controls.Add(this.panel8);
			this.groupBox1.Controls.Add(this.panel7);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
			this.groupBox1.Size = new System.Drawing.Size(335, 197);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Current System Config";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lklbChangeAppConfig);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(9, 149);
			this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(30, 5, 30, 5);
			this.panel5.Size = new System.Drawing.Size(317, 40);
			this.panel5.TabIndex = 8;
			// 
			// lklbChangeAppConfig
			// 
			this.lklbChangeAppConfig.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lklbChangeAppConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lklbChangeAppConfig.Image = global::OMW15.Properties.Resources.WRENCH;
			this.lklbChangeAppConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lklbChangeAppConfig.Location = new System.Drawing.Point(30, 5);
			this.lklbChangeAppConfig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lklbChangeAppConfig.Name = "lklbChangeAppConfig";
			this.lklbChangeAppConfig.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.lklbChangeAppConfig.Size = new System.Drawing.Size(257, 30);
			this.lklbChangeAppConfig.TabIndex = 1;
			this.lklbChangeAppConfig.TabStop = true;
			this.lklbChangeAppConfig.Text = "Change Application Configuration....";
			this.lklbChangeAppConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lklbChangeAppConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklbChangeAppConfig_LinkClicked);
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtERPDatabase);
			this.panel10.Controls.Add(this.label7);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(9, 119);
			this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(2);
			this.panel10.Size = new System.Drawing.Size(317, 30);
			this.panel10.TabIndex = 7;
			// 
			// txtERPDatabase
			// 
			this.txtERPDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtERPDatabase.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPDatabase.Enabled = false;
			this.txtERPDatabase.Location = new System.Drawing.Point(99, 2);
			this.txtERPDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPDatabase.MaxLength = 15;
			this.txtERPDatabase.Name = "txtERPDatabase";
			this.txtERPDatabase.Size = new System.Drawing.Size(168, 25);
			this.txtERPDatabase.TabIndex = 2;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(2, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 26);
			this.label7.TabIndex = 1;
			this.label7.Text = "ERP DB:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtERPServer);
			this.panel9.Controls.Add(this.label6);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(9, 89);
			this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(317, 30);
			this.panel9.TabIndex = 6;
			// 
			// txtERPServer
			// 
			this.txtERPServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtERPServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPServer.Enabled = false;
			this.txtERPServer.Location = new System.Drawing.Point(99, 2);
			this.txtERPServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPServer.MaxLength = 15;
			this.txtERPServer.Name = "txtERPServer";
			this.txtERPServer.Size = new System.Drawing.Size(168, 25);
			this.txtERPServer.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(2, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(97, 26);
			this.label6.TabIndex = 1;
			this.label6.Text = "ERP Server:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtSysDatabase);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(9, 59);
			this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(2);
			this.panel8.Size = new System.Drawing.Size(317, 30);
			this.panel8.TabIndex = 5;
			// 
			// txtSysDatabase
			// 
			this.txtSysDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSysDatabase.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSysDatabase.Enabled = false;
			this.txtSysDatabase.Location = new System.Drawing.Point(99, 2);
			this.txtSysDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSysDatabase.MaxLength = 15;
			this.txtSysDatabase.Name = "txtSysDatabase";
			this.txtSysDatabase.Size = new System.Drawing.Size(168, 25);
			this.txtSysDatabase.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(2, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 26);
			this.label5.TabIndex = 1;
			this.label5.Text = "Default DB:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtMainServer);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(9, 29);
			this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(317, 30);
			this.panel7.TabIndex = 4;
			// 
			// txtMainServer
			// 
			this.txtMainServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMainServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMainServer.Enabled = false;
			this.txtMainServer.Location = new System.Drawing.Point(99, 2);
			this.txtMainServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtMainServer.MaxLength = 15;
			this.txtMainServer.Name = "txtMainServer";
			this.txtMainServer.Size = new System.Drawing.Size(168, 25);
			this.txtMainServer.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "Main Server :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// UserLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(369, 397);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "UserLogin";
			this.Padding = new System.Windows.Forms.Padding(15, 17, 15, 17);
			this.Text = "LOGIN";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserLogin_FormClosing);
			this.Load += new System.EventHandler(this.UserLogin_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtMainServer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.TextBox txtSysDatabase;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.TextBox txtERPDatabase;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TextBox txtERPServer;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.LinkLabel lklbChangeAppConfig;
	}
}