namespace OMW15.Views.ServiceView
{
	partial class MCRegister
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCRegister));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnCustomer = new OMControls.OMFlatButton();
			this.txtCustomerName = new System.Windows.Forms.TextBox();
			this.txtCustCode = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnModel = new OMControls.OMFlatButton();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtSN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.grpTransfer = new System.Windows.Forms.GroupBox();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtTransferDate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtCurrentOwner = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lbISTransfer = new System.Windows.Forms.Label();
			this.btnTransferMC = new System.Windows.Forms.Button();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel15 = new System.Windows.Forms.Panel();
			this.rdoUsedMC = new System.Windows.Forms.RadioButton();
			this.rdoNewMC = new System.Windows.Forms.RadioButton();
			this.label15 = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.btnWarranty = new OMControls.OMFlatButton();
			this.txtWarranty = new System.Windows.Forms.TextBox();
			this.txtTerm = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbStatus = new System.Windows.Forms.Label();
			this.dtpExpire = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.dtpSaleDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.grpTransfer.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlHeader.Controls.Add(this.lbMode);
			this.pnlHeader.Controls.Add(this.lbTitle);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.ForeColor = System.Drawing.Color.White;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(631, 48);
			this.pnlHeader.TabIndex = 0;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(511, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(118, 44);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "MODE";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(330, 44);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "ระเบียนเครื่องจักร (Machine Record)";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 459);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 20);
			this.panel1.Size = new System.Drawing.Size(631, 58);
			this.panel1.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(433, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(97, 34);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(530, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(97, 34);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnCustomer);
			this.panel2.Controls.Add(this.txtCustomerName);
			this.panel2.Controls.Add(this.txtCustCode);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 48);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel2.Size = new System.Drawing.Size(631, 28);
			this.panel2.TabIndex = 2;
			// 
			// btnCustomer
			// 
			this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCustomer.FlatAppearance.BorderSize = 0;
			this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
			this.btnCustomer.Location = new System.Drawing.Point(576, 1);
			this.btnCustomer.Name = "btnCustomer";
			this.btnCustomer.Size = new System.Drawing.Size(26, 26);
			this.btnCustomer.TabIndex = 8;
			this.btnCustomer.UseVisualStyleBackColor = true;
			this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomerName.Location = new System.Drawing.Point(174, 1);
			this.txtCustomerName.MaxLength = 150;
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.ReadOnly = true;
			this.txtCustomerName.Size = new System.Drawing.Size(402, 25);
			this.txtCustomerName.TabIndex = 7;
			this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
			// 
			// txtCustCode
			// 
			this.txtCustCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustCode.Location = new System.Drawing.Point(87, 1);
			this.txtCustCode.MaxLength = 3;
			this.txtCustCode.Name = "txtCustCode";
			this.txtCustCode.ReadOnly = true;
			this.txtCustCode.Size = new System.Drawing.Size(87, 25);
			this.txtCustCode.TabIndex = 6;
			this.txtCustCode.Text = "1";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(20, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "ลูกค้า :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnModel);
			this.panel3.Controls.Add(this.txtModel);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 76);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel3.Size = new System.Drawing.Size(631, 28);
			this.panel3.TabIndex = 3;
			// 
			// btnModel
			// 
			this.btnModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnModel.FlatAppearance.BorderSize = 0;
			this.btnModel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnModel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModel.Image = ((System.Drawing.Image)(resources.GetObject("btnModel.Image")));
			this.btnModel.Location = new System.Drawing.Point(277, 1);
			this.btnModel.Name = "btnModel";
			this.btnModel.Size = new System.Drawing.Size(26, 26);
			this.btnModel.TabIndex = 4;
			this.btnModel.UseVisualStyleBackColor = true;
			this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
			// 
			// txtModel
			// 
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtModel.Location = new System.Drawing.Point(87, 1);
			this.txtModel.MaxLength = 50;
			this.txtModel.Name = "txtModel";
			this.txtModel.ReadOnly = true;
			this.txtModel.Size = new System.Drawing.Size(190, 25);
			this.txtModel.TabIndex = 3;
			this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(20, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "เครื่องจักร :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtSN);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 104);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel4.Size = new System.Drawing.Size(631, 28);
			this.panel4.TabIndex = 4;
			// 
			// txtSN
			// 
			this.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSN.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSN.Location = new System.Drawing.Point(87, 1);
			this.txtSN.MaxLength = 50;
			this.txtSN.Name = "txtSN";
			this.txtSN.Size = new System.Drawing.Size(190, 25);
			this.txtSN.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(20, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "หมายเลข :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.groupBox1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 132);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(10);
			this.panel5.Size = new System.Drawing.Size(631, 317);
			this.panel5.TabIndex = 5;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.grpTransfer);
			this.groupBox1.Controls.Add(this.panel9);
			this.groupBox1.Controls.Add(this.panel10);
			this.groupBox1.Controls.Add(this.panel15);
			this.groupBox1.Controls.Add(this.panel14);
			this.groupBox1.Controls.Add(this.panel13);
			this.groupBox1.Controls.Add(this.panel6);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
			this.groupBox1.Size = new System.Drawing.Size(611, 297);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "รายละเอียดการรับประกัน";
			// 
			// grpTransfer
			// 
			this.grpTransfer.Controls.Add(this.panel8);
			this.grpTransfer.Controls.Add(this.panel7);
			this.grpTransfer.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpTransfer.Location = new System.Drawing.Point(15, 203);
			this.grpTransfer.Name = "grpTransfer";
			this.grpTransfer.Size = new System.Drawing.Size(581, 80);
			this.grpTransfer.TabIndex = 15;
			this.grpTransfer.TabStop = false;
			this.grpTransfer.Text = "เจ้าของปัจจุบัน";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtTransferDate);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(3, 49);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel8.Size = new System.Drawing.Size(575, 28);
			this.panel8.TabIndex = 4;
			// 
			// txtTransferDate
			// 
			this.txtTransferDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTransferDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTransferDate.Location = new System.Drawing.Point(59, 1);
			this.txtTransferDate.MaxLength = 150;
			this.txtTransferDate.Name = "txtTransferDate";
			this.txtTransferDate.ReadOnly = true;
			this.txtTransferDate.Size = new System.Drawing.Size(138, 25);
			this.txtTransferDate.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(20, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 26);
			this.label7.TabIndex = 0;
			this.label7.Text = "วันที่ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtCurrentOwner);
			this.panel7.Controls.Add(this.label1);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(3, 21);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel7.Size = new System.Drawing.Size(575, 28);
			this.panel7.TabIndex = 3;
			// 
			// txtCurrentOwner
			// 
			this.txtCurrentOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCurrentOwner.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCurrentOwner.Location = new System.Drawing.Point(59, 1);
			this.txtCurrentOwner.MaxLength = 150;
			this.txtCurrentOwner.Name = "txtCurrentOwner";
			this.txtCurrentOwner.ReadOnly = true;
			this.txtCurrentOwner.Size = new System.Drawing.Size(488, 25);
			this.txtCurrentOwner.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(20, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ชื่อ :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.lbISTransfer);
			this.panel9.Controls.Add(this.btnTransferMC);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(15, 173);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(200, 1, 1, 1);
			this.panel9.Size = new System.Drawing.Size(581, 30);
			this.panel9.TabIndex = 14;
			// 
			// lbISTransfer
			// 
			this.lbISTransfer.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbISTransfer.Location = new System.Drawing.Point(452, 1);
			this.lbISTransfer.Name = "lbISTransfer";
			this.lbISTransfer.Size = new System.Drawing.Size(128, 28);
			this.lbISTransfer.TabIndex = 1;
			this.lbISTransfer.Text = "Transferring.....";
			this.lbISTransfer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.lbISTransfer.Visible = false;
			// 
			// btnTransferMC
			// 
			this.btnTransferMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnTransferMC.Location = new System.Drawing.Point(200, 1);
			this.btnTransferMC.Name = "btnTransferMC";
			this.btnTransferMC.Size = new System.Drawing.Size(142, 28);
			this.btnTransferMC.TabIndex = 0;
			this.btnTransferMC.Text = "โอนย้ายเครื่ิองจักร";
			this.btnTransferMC.UseVisualStyleBackColor = true;
			this.btnTransferMC.Click += new System.EventHandler(this.btnTransferMC_Click);
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtRemark);
			this.panel10.Controls.Add(this.label8);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(15, 145);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(581, 28);
			this.panel10.TabIndex = 13;
			// 
			// txtRemark
			// 
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtRemark.Location = new System.Drawing.Point(104, 1);
			this.txtRemark.MaxLength = 150;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(447, 25);
			this.txtRemark.TabIndex = 4;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 26);
			this.label8.TabIndex = 1;
			this.label8.Text = "หมายเหตุ :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.rdoUsedMC);
			this.panel15.Controls.Add(this.rdoNewMC);
			this.panel15.Controls.Add(this.label15);
			this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new System.Drawing.Point(15, 117);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new System.Windows.Forms.Padding(1);
			this.panel15.Size = new System.Drawing.Size(581, 28);
			this.panel15.TabIndex = 10;
			// 
			// rdoUsedMC
			// 
			this.rdoUsedMC.AutoSize = true;
			this.rdoUsedMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoUsedMC.Location = new System.Drawing.Point(221, 1);
			this.rdoUsedMC.Name = "rdoUsedMC";
			this.rdoUsedMC.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
			this.rdoUsedMC.Size = new System.Drawing.Size(129, 26);
			this.rdoUsedMC.TabIndex = 3;
			this.rdoUsedMC.TabStop = true;
			this.rdoUsedMC.Tag = "USED_MC";
			this.rdoUsedMC.Text = "เครื่องจักรใช้แล้ว";
			this.rdoUsedMC.UseVisualStyleBackColor = true;
			// 
			// rdoNewMC
			// 
			this.rdoNewMC.AutoSize = true;
			this.rdoNewMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoNewMC.Location = new System.Drawing.Point(104, 1);
			this.rdoNewMC.Name = "rdoNewMC";
			this.rdoNewMC.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
			this.rdoNewMC.Size = new System.Drawing.Size(117, 26);
			this.rdoNewMC.TabIndex = 2;
			this.rdoNewMC.TabStop = true;
			this.rdoNewMC.Tag = "NEW_MC";
			this.rdoNewMC.Text = "เครื่องจักรใหม่";
			this.rdoNewMC.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.Dock = System.Windows.Forms.DockStyle.Left;
			this.label15.Location = new System.Drawing.Point(1, 1);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(103, 26);
			this.label15.TabIndex = 1;
			this.label15.Text = "สถานะเครื่องจักร :";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.btnWarranty);
			this.panel14.Controls.Add(this.txtWarranty);
			this.panel14.Controls.Add(this.txtTerm);
			this.panel14.Controls.Add(this.label14);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(15, 89);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(1);
			this.panel14.Size = new System.Drawing.Size(581, 28);
			this.panel14.TabIndex = 9;
			// 
			// btnWarranty
			// 
			this.btnWarranty.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnWarranty.FlatAppearance.BorderSize = 0;
			this.btnWarranty.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnWarranty.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnWarranty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWarranty.Image = ((System.Drawing.Image)(resources.GetObject("btnWarranty.Image")));
			this.btnWarranty.Location = new System.Drawing.Point(550, 1);
			this.btnWarranty.Name = "btnWarranty";
			this.btnWarranty.Size = new System.Drawing.Size(26, 26);
			this.btnWarranty.TabIndex = 8;
			this.btnWarranty.UseVisualStyleBackColor = true;
			this.btnWarranty.Click += new System.EventHandler(this.btnWarranty_Click);
			// 
			// txtWarranty
			// 
			this.txtWarranty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtWarranty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtWarranty.Location = new System.Drawing.Point(149, 1);
			this.txtWarranty.MaxLength = 150;
			this.txtWarranty.Name = "txtWarranty";
			this.txtWarranty.Size = new System.Drawing.Size(401, 25);
			this.txtWarranty.TabIndex = 7;
			// 
			// txtTerm
			// 
			this.txtTerm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTerm.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTerm.Location = new System.Drawing.Point(104, 1);
			this.txtTerm.MaxLength = 3;
			this.txtTerm.Name = "txtTerm";
			this.txtTerm.ReadOnly = true;
			this.txtTerm.Size = new System.Drawing.Size(45, 25);
			this.txtTerm.TabIndex = 6;
			this.txtTerm.Text = "1";
			this.txtTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Left;
			this.label14.Location = new System.Drawing.Point(1, 1);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(103, 26);
			this.label14.TabIndex = 1;
			this.label14.Text = "เงื่อนไขรับประกัน :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.txtQty);
			this.panel13.Controls.Add(this.label13);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(15, 61);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(1);
			this.panel13.Size = new System.Drawing.Size(581, 28);
			this.panel13.TabIndex = 8;
			// 
			// txtQty
			// 
			this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtQty.Location = new System.Drawing.Point(104, 1);
			this.txtQty.MaxLength = 3;
			this.txtQty.Name = "txtQty";
			this.txtQty.ReadOnly = true;
			this.txtQty.Size = new System.Drawing.Size(45, 25);
			this.txtQty.TabIndex = 5;
			this.txtQty.Text = "1";
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Left;
			this.label13.Location = new System.Drawing.Point(1, 1);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(103, 26);
			this.label13.TabIndex = 1;
			this.label13.Text = "จำนวน :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbStatus);
			this.panel6.Controls.Add(this.dtpExpire);
			this.panel6.Controls.Add(this.label5);
			this.panel6.Controls.Add(this.dtpSaleDate);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(15, 33);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(581, 28);
			this.panel6.TabIndex = 7;
			// 
			// lbStatus
			// 
			this.lbStatus.BackColor = System.Drawing.Color.Yellow;
			this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStatus.Location = new System.Drawing.Point(455, 1);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(95, 26);
			this.lbStatus.TabIndex = 5;
			this.lbStatus.Text = "STATUS";
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dtpExpire
			// 
			this.dtpExpire.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpExpire.Location = new System.Drawing.Point(341, 1);
			this.dtpExpire.Name = "dtpExpire";
			this.dtpExpire.Size = new System.Drawing.Size(114, 25);
			this.dtpExpire.TabIndex = 4;
			this.dtpExpire.ValueChanged += new System.EventHandler(this.dtpExpire_ValueChanged);
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(228, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 26);
			this.label5.TabIndex = 3;
			this.label5.Text = "วันที่หมดประกัน :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpSaleDate
			// 
			this.dtpSaleDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpSaleDate.Location = new System.Drawing.Point(104, 1);
			this.dtpSaleDate.Name = "dtpSaleDate";
			this.dtpSaleDate.Size = new System.Drawing.Size(124, 25);
			this.dtpSaleDate.TabIndex = 2;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(103, 26);
			this.label6.TabIndex = 1;
			this.label6.Text = "วันที่ขาย :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MCRegister
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(631, 517);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MCRegister";
			this.Text = "ลงทะเบียนเครื่องจักร";
			this.Load += new System.EventHandler(this.MCRegister_Load);
			this.pnlHeader.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.grpTransfer.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel3;
		private OMControls.OMFlatButton btnModel;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtSN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.RadioButton rdoUsedMC;
		private System.Windows.Forms.RadioButton rdoNewMC;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.TextBox txtQty;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.DateTimePicker dtpExpire;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtpSaleDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.GroupBox grpTransfer;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.TextBox txtTransferDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtCurrentOwner;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label lbISTransfer;
		private System.Windows.Forms.Button btnTransferMC;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label label8;
		private OMControls.OMFlatButton btnWarranty;
		private System.Windows.Forms.TextBox txtWarranty;
		private System.Windows.Forms.TextBox txtTerm;
		private OMControls.OMFlatButton btnCustomer;
		private System.Windows.Forms.TextBox txtCustomerName;
		private System.Windows.Forms.TextBox txtCustCode;
	}
}