namespace OMW15.Tools
{
	partial class ConfigManager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigManager));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnUpdateConfig = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.tc = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.panel14 = new System.Windows.Forms.Panel();
			this.cbxWorkGroup = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.btnImgLocationPath = new OMControls.OMFlatButton();
			this.txtImgLocationPath = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel12 = new System.Windows.Forms.Panel();
			this.txtCompanyId = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tpMain = new System.Windows.Forms.TabPage();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtSysPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtSystemAdmin = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtSysDatabase = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSysServer = new System.Windows.Forms.Button();
			this.txtSysServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tpERP = new System.Windows.Forms.TabPage();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtERPPassword = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtERPUser = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtERPDatabase = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.btnERPServer = new System.Windows.Forms.Button();
			this.txtERPServer = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.pnlTitle.SuspendLayout();
			this.pnlDetails.SuspendLayout();
			this.tc.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel12.SuspendLayout();
			this.tpMain.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tpERP.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnUpdateConfig);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 360);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.panel1.Size = new System.Drawing.Size(576, 59);
			this.panel1.TabIndex = 0;
			// 
			// btnUpdateConfig
			// 
			this.btnUpdateConfig.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnUpdateConfig.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUpdateConfig.Location = new System.Drawing.Point(10, 11);
			this.btnUpdateConfig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnUpdateConfig.Name = "btnUpdateConfig";
			this.btnUpdateConfig.Size = new System.Drawing.Size(257, 37);
			this.btnUpdateConfig.TabIndex = 1;
			this.btnUpdateConfig.Text = "Update System Configuration";
			this.btnUpdateConfig.UseVisualStyleBackColor = true;
			this.btnUpdateConfig.Click += new System.EventHandler(this.btnUpdateConfig_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(452, 11);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(114, 37);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlTitle
			// 
			this.pnlTitle.BackColor = System.Drawing.Color.White;
			this.pnlTitle.Controls.Add(this.lbTitle);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTitle.Size = new System.Drawing.Size(576, 59);
			this.pnlTitle.TabIndex = 1;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.SystemColors.Highlight;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(572, 55);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "System Configuration Manager";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlDetails
			// 
			this.pnlDetails.Controls.Add(this.tc);
			this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetails.Location = new System.Drawing.Point(0, 59);
			this.pnlDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.pnlDetails.Size = new System.Drawing.Size(576, 301);
			this.pnlDetails.TabIndex = 2;
			// 
			// tc
			// 
			this.tc.Controls.Add(this.tpGeneral);
			this.tc.Controls.Add(this.tpMain);
			this.tc.Controls.Add(this.tpERP);
			this.tc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tc.Location = new System.Drawing.Point(10, 11);
			this.tc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tc.Name = "tc";
			this.tc.SelectedIndex = 0;
			this.tc.Size = new System.Drawing.Size(556, 279);
			this.tc.TabIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.panel14);
			this.tpGeneral.Controls.Add(this.panel13);
			this.tpGeneral.Controls.Add(this.panel12);
			this.tpGeneral.Location = new System.Drawing.Point(4, 26);
			this.tpGeneral.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.tpGeneral.Size = new System.Drawing.Size(548, 249);
			this.tpGeneral.TabIndex = 2;
			this.tpGeneral.Text = "General Information";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.cbxWorkGroup);
			this.panel14.Controls.Add(this.label2);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(10, 71);
			this.panel14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(2);
			this.panel14.Size = new System.Drawing.Size(528, 30);
			this.panel14.TabIndex = 3;
			// 
			// cbxWorkGroup
			// 
			this.cbxWorkGroup.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorkGroup.FormattingEnabled = true;
			this.cbxWorkGroup.Location = new System.Drawing.Point(112, 2);
			this.cbxWorkGroup.Name = "cbxWorkGroup";
			this.cbxWorkGroup.Size = new System.Drawing.Size(379, 25);
			this.cbxWorkGroup.TabIndex = 1;
			this.cbxWorkGroup.SelectedIndexChanged += new System.EventHandler(this.cbxWorkGroup_SelectedIndexChanged);
			this.cbxWorkGroup.SelectedValueChanged += new System.EventHandler(this.cbxWorkGroup_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(110, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "กลุ่มงาน :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.btnImgLocationPath);
			this.panel13.Controls.Add(this.txtImgLocationPath);
			this.panel13.Controls.Add(this.label1);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(10, 41);
			this.panel13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(2);
			this.panel13.Size = new System.Drawing.Size(528, 30);
			this.panel13.TabIndex = 2;
			// 
			// btnImgLocationPath
			// 
			this.btnImgLocationPath.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnImgLocationPath.FlatAppearance.BorderSize = 0;
			this.btnImgLocationPath.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnImgLocationPath.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnImgLocationPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImgLocationPath.Image = ((System.Drawing.Image)(resources.GetObject("btnImgLocationPath.Image")));
			this.btnImgLocationPath.Location = new System.Drawing.Point(491, 2);
			this.btnImgLocationPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnImgLocationPath.Name = "btnImgLocationPath";
			this.btnImgLocationPath.Size = new System.Drawing.Size(26, 26);
			this.btnImgLocationPath.TabIndex = 3;
			this.btnImgLocationPath.UseVisualStyleBackColor = true;
			this.btnImgLocationPath.Click += new System.EventHandler(this.btnImgLocationPath_Click);
			// 
			// txtImgLocationPath
			// 
			this.txtImgLocationPath.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtImgLocationPath.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtImgLocationPath.Location = new System.Drawing.Point(112, 2);
			this.txtImgLocationPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtImgLocationPath.MaxLength = 255;
			this.txtImgLocationPath.Name = "txtImgLocationPath";
			this.txtImgLocationPath.Size = new System.Drawing.Size(379, 25);
			this.txtImgLocationPath.TabIndex = 2;
			this.txtImgLocationPath.TextChanged += new System.EventHandler(this.txtImgLocationPath_TextChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(110, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ที่เก็บไฟล์รูปภาพ :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.txtCompanyId);
			this.panel12.Controls.Add(this.label11);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new System.Drawing.Point(10, 11);
			this.panel12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(2);
			this.panel12.Size = new System.Drawing.Size(528, 30);
			this.panel12.TabIndex = 1;
			// 
			// txtCompanyId
			// 
			this.txtCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCompanyId.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCompanyId.Location = new System.Drawing.Point(112, 2);
			this.txtCompanyId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtCompanyId.MaxLength = 15;
			this.txtCompanyId.Name = "txtCompanyId";
			this.txtCompanyId.Size = new System.Drawing.Size(95, 25);
			this.txtCompanyId.TabIndex = 2;
			this.txtCompanyId.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Left;
			this.label11.Location = new System.Drawing.Point(2, 2);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(110, 26);
			this.label11.TabIndex = 0;
			this.label11.Text = "รหัสบริษัท :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tpMain
			// 
			this.tpMain.Controls.Add(this.panel6);
			this.tpMain.Controls.Add(this.panel5);
			this.tpMain.Controls.Add(this.panel4);
			this.tpMain.Controls.Add(this.panel3);
			this.tpMain.Controls.Add(this.panel2);
			this.tpMain.Location = new System.Drawing.Point(4, 26);
			this.tpMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpMain.Name = "tpMain";
			this.tpMain.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.tpMain.Size = new System.Drawing.Size(548, 249);
			this.tpMain.TabIndex = 0;
			this.tpMain.Text = "System Information";
			this.tpMain.UseVisualStyleBackColor = true;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtSysPassword);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(10, 133);
			this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(528, 30);
			this.panel6.TabIndex = 4;
			// 
			// txtSysPassword
			// 
			this.txtSysPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSysPassword.Location = new System.Drawing.Point(198, 2);
			this.txtSysPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSysPassword.MaxLength = 15;
			this.txtSysPassword.Name = "txtSysPassword";
			this.txtSysPassword.Size = new System.Drawing.Size(184, 25);
			this.txtSysPassword.TabIndex = 2;
			this.txtSysPassword.UseSystemPasswordChar = true;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(2, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(196, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "System Admin Password :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtSystemAdmin);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 103);
			this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(528, 30);
			this.panel5.TabIndex = 3;
			// 
			// txtSystemAdmin
			// 
			this.txtSystemAdmin.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSystemAdmin.Location = new System.Drawing.Point(198, 2);
			this.txtSystemAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSystemAdmin.MaxLength = 35;
			this.txtSystemAdmin.Name = "txtSystemAdmin";
			this.txtSystemAdmin.Size = new System.Drawing.Size(184, 25);
			this.txtSystemAdmin.TabIndex = 2;
			this.txtSystemAdmin.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(2, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(196, 26);
			this.label5.TabIndex = 0;
			this.label5.Text = "System Database Admin User :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtSysDatabase);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 73);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(528, 30);
			this.panel4.TabIndex = 2;
			// 
			// txtSysDatabase
			// 
			this.txtSysDatabase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSysDatabase.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSysDatabase.Location = new System.Drawing.Point(198, 2);
			this.txtSysDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSysDatabase.MaxLength = 50;
			this.txtSysDatabase.Name = "txtSysDatabase";
			this.txtSysDatabase.Size = new System.Drawing.Size(295, 25);
			this.txtSysDatabase.TabIndex = 2;
			this.txtSysDatabase.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(196, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "System Database Name :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnSysServer);
			this.panel3.Controls.Add(this.txtSysServer);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 43);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(528, 30);
			this.panel3.TabIndex = 1;
			// 
			// btnSysServer
			// 
			this.btnSysServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSysServer.FlatAppearance.BorderSize = 0;
			this.btnSysServer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
			this.btnSysServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnSysServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSysServer.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.btnSysServer.Location = new System.Drawing.Point(493, 2);
			this.btnSysServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSysServer.Name = "btnSysServer";
			this.btnSysServer.Size = new System.Drawing.Size(28, 26);
			this.btnSysServer.TabIndex = 3;
			this.btnSysServer.UseVisualStyleBackColor = true;
			this.btnSysServer.Click += new System.EventHandler(this.btnSysServer_Click);
			// 
			// txtSysServer
			// 
			this.txtSysServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSysServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSysServer.Location = new System.Drawing.Point(198, 2);
			this.txtSysServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtSysServer.MaxLength = 100;
			this.txtSysServer.Name = "txtSysServer";
			this.txtSysServer.Size = new System.Drawing.Size(295, 25);
			this.txtSysServer.TabIndex = 2;
			this.txtSysServer.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(196, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "System Server Name :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 11);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(528, 32);
			this.panel2.TabIndex = 0;
			// 
			// tpERP
			// 
			this.tpERP.Controls.Add(this.panel7);
			this.tpERP.Controls.Add(this.panel8);
			this.tpERP.Controls.Add(this.panel9);
			this.tpERP.Controls.Add(this.panel10);
			this.tpERP.Controls.Add(this.panel11);
			this.tpERP.Location = new System.Drawing.Point(4, 26);
			this.tpERP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpERP.Name = "tpERP";
			this.tpERP.Padding = new System.Windows.Forms.Padding(10, 11, 10, 11);
			this.tpERP.Size = new System.Drawing.Size(548, 249);
			this.tpERP.TabIndex = 1;
			this.tpERP.Text = "ERP Information";
			this.tpERP.UseVisualStyleBackColor = true;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtERPPassword);
			this.panel7.Controls.Add(this.label7);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(10, 133);
			this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(528, 30);
			this.panel7.TabIndex = 9;
			// 
			// txtERPPassword
			// 
			this.txtERPPassword.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPPassword.Location = new System.Drawing.Point(198, 2);
			this.txtERPPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPPassword.MaxLength = 15;
			this.txtERPPassword.Name = "txtERPPassword";
			this.txtERPPassword.Size = new System.Drawing.Size(184, 25);
			this.txtERPPassword.TabIndex = 2;
			this.txtERPPassword.UseSystemPasswordChar = true;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(2, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(196, 26);
			this.label7.TabIndex = 0;
			this.label7.Text = "ERP Admin Password :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtERPUser);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(10, 103);
			this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(2);
			this.panel8.Size = new System.Drawing.Size(528, 30);
			this.panel8.TabIndex = 8;
			// 
			// txtERPUser
			// 
			this.txtERPUser.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPUser.Location = new System.Drawing.Point(198, 2);
			this.txtERPUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPUser.MaxLength = 35;
			this.txtERPUser.Name = "txtERPUser";
			this.txtERPUser.Size = new System.Drawing.Size(184, 25);
			this.txtERPUser.TabIndex = 2;
			this.txtERPUser.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(2, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(196, 26);
			this.label8.TabIndex = 0;
			this.label8.Text = "ERP Database Admin User :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtERPDatabase);
			this.panel9.Controls.Add(this.label9);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(10, 73);
			this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(528, 30);
			this.panel9.TabIndex = 7;
			// 
			// txtERPDatabase
			// 
			this.txtERPDatabase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtERPDatabase.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPDatabase.Location = new System.Drawing.Point(198, 2);
			this.txtERPDatabase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPDatabase.MaxLength = 50;
			this.txtERPDatabase.Name = "txtERPDatabase";
			this.txtERPDatabase.Size = new System.Drawing.Size(299, 25);
			this.txtERPDatabase.TabIndex = 2;
			this.txtERPDatabase.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(2, 2);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(196, 26);
			this.label9.TabIndex = 0;
			this.label9.Text = "ERP Database Name :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.btnERPServer);
			this.panel10.Controls.Add(this.txtERPServer);
			this.panel10.Controls.Add(this.label10);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(10, 43);
			this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(2);
			this.panel10.Size = new System.Drawing.Size(528, 30);
			this.panel10.TabIndex = 6;
			// 
			// btnERPServer
			// 
			this.btnERPServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnERPServer.FlatAppearance.BorderSize = 0;
			this.btnERPServer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
			this.btnERPServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
			this.btnERPServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnERPServer.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.btnERPServer.Location = new System.Drawing.Point(497, 2);
			this.btnERPServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnERPServer.Name = "btnERPServer";
			this.btnERPServer.Size = new System.Drawing.Size(28, 26);
			this.btnERPServer.TabIndex = 3;
			this.btnERPServer.UseVisualStyleBackColor = true;
			this.btnERPServer.Click += new System.EventHandler(this.btnERPServer_Click);
			// 
			// txtERPServer
			// 
			this.txtERPServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtERPServer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtERPServer.Location = new System.Drawing.Point(198, 2);
			this.txtERPServer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtERPServer.MaxLength = 100;
			this.txtERPServer.Name = "txtERPServer";
			this.txtERPServer.Size = new System.Drawing.Size(299, 25);
			this.txtERPServer.TabIndex = 2;
			this.txtERPServer.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(2, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(196, 26);
			this.label10.TabIndex = 0;
			this.label10.Text = "ERP Server Name :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel11
			// 
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(10, 11);
			this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(2);
			this.panel11.Size = new System.Drawing.Size(528, 32);
			this.panel11.TabIndex = 5;
			// 
			// ConfigManager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(576, 419);
			this.Controls.Add(this.pnlDetails);
			this.Controls.Add(this.pnlTitle);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ConfigManager";
			this.Text = "SYSTEM CONFIGURATION MANAGER";
			this.Load += new System.EventHandler(this.ConfigManage_Load);
			this.panel1.ResumeLayout(false);
			this.pnlTitle.ResumeLayout(false);
			this.pnlDetails.ResumeLayout(false);
			this.tc.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			this.tpMain.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.tpERP.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnUpdateConfig;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.TabControl tc;
		private System.Windows.Forms.TabPage tpMain;
		private System.Windows.Forms.TabPage tpERP;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtSysPassword;
		private System.Windows.Forms.TextBox txtSystemAdmin;
		private System.Windows.Forms.TextBox txtSysDatabase;
		private System.Windows.Forms.TextBox txtSysServer;
		private System.Windows.Forms.Button btnSysServer;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtERPPassword;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.TextBox txtERPUser;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.TextBox txtERPDatabase;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Button btnERPServer;
		private System.Windows.Forms.TextBox txtERPServer;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtCompanyId;
		private System.Windows.Forms.Panel panel13;
		private OMControls.OMFlatButton btnImgLocationPath;
		private System.Windows.Forms.TextBox txtImgLocationPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.ComboBox cbxWorkGroup;
		private System.Windows.Forms.Label label2;
	}
}