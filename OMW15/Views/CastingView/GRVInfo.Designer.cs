namespace OMW15.Views.CastingView
{
	partial class GRVInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRVInfo));
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.lbMode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtpGRVDate = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.lbGRVId = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.chkReturnForSale = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSelectedSaleMaterialOrder = new OMControls.OMFlatButton();
			this.txtRefDocument = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtRecever = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnSendingDate = new OMControls.MonthPopup();
			this.txtSendingDate = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtSender = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnMaterial = new OMControls.OMFlatButton();
			this.txtMaterial = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.cbxUnit = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtReceiveWeight = new OMControls.Controls.NumericTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.pnlCommand.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnSave);
			this.pnlCommand.Controls.Add(this.btnCancel);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(2, 314);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(5);
			this.pnlCommand.Size = new System.Drawing.Size(593, 40);
			this.pnlCommand.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(382, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(103, 30);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(485, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(103, 30);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.pnlHeader.Controls.Add(this.lbCustomer);
			this.pnlHeader.Controls.Add(this.lbMode);
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(2, 2);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(593, 39);
			this.pnlHeader.TabIndex = 1;
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustomer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustomer.ForeColor = System.Drawing.Color.White;
			this.lbCustomer.Location = new System.Drawing.Point(151, 2);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(358, 35);
			this.lbCustomer.TabIndex = 2;
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(509, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(82, 35);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "ใบสำคัญรับวัสดุ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dtpGRVDate);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.lbGRVId);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 41);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(593, 28);
			this.panel1.TabIndex = 2;
			// 
			// dtpGRVDate
			// 
			this.dtpGRVDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpGRVDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpGRVDate.Location = new System.Drawing.Point(344, 1);
			this.dtpGRVDate.Name = "dtpGRVDate";
			this.dtpGRVDate.Size = new System.Drawing.Size(104, 25);
			this.dtpGRVDate.TabIndex = 4;
			this.dtpGRVDate.CloseUp += new System.EventHandler(this.dtpGRVDate_CloseUp);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(290, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 26);
			this.label4.TabIndex = 3;
			this.label4.Text = "วันที่รับ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbGRVId
			// 
			this.lbGRVId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbGRVId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbGRVId.Location = new System.Drawing.Point(151, 1);
			this.lbGRVId.Name = "lbGRVId";
			this.lbGRVId.Size = new System.Drawing.Size(139, 26);
			this.lbGRVId.TabIndex = 1;
			this.lbGRVId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(150, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "เลขที่ใบสำคัญรับ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.chkReturnForSale);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 69);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(593, 28);
			this.panel2.TabIndex = 3;
			// 
			// chkReturnForSale
			// 
			this.chkReturnForSale.AutoSize = true;
			this.chkReturnForSale.Checked = true;
			this.chkReturnForSale.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkReturnForSale.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkReturnForSale.Location = new System.Drawing.Point(1, 1);
			this.chkReturnForSale.Name = "chkReturnForSale";
			this.chkReturnForSale.Padding = new System.Windows.Forms.Padding(150, 0, 0, 0);
			this.chkReturnForSale.Size = new System.Drawing.Size(273, 26);
			this.chkReturnForSale.TabIndex = 0;
			this.chkReturnForSale.Text = "รับจากใบสั่งขายวัสดุ";
			this.chkReturnForSale.UseVisualStyleBackColor = true;
			this.chkReturnForSale.CheckedChanged += new System.EventHandler(this.chkReturnForSale_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnSelectedSaleMaterialOrder);
			this.panel3.Controls.Add(this.txtRefDocument);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 97);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(593, 28);
			this.panel3.TabIndex = 4;
			// 
			// btnSelectedSaleMaterialOrder
			// 
			this.btnSelectedSaleMaterialOrder.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelectedSaleMaterialOrder.FlatAppearance.BorderSize = 0;
			this.btnSelectedSaleMaterialOrder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSelectedSaleMaterialOrder.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSelectedSaleMaterialOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectedSaleMaterialOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectedSaleMaterialOrder.Image")));
			this.btnSelectedSaleMaterialOrder.Location = new System.Drawing.Point(358, 1);
			this.btnSelectedSaleMaterialOrder.Name = "btnSelectedSaleMaterialOrder";
			this.btnSelectedSaleMaterialOrder.Size = new System.Drawing.Size(26, 26);
			this.btnSelectedSaleMaterialOrder.TabIndex = 6;
			this.btnSelectedSaleMaterialOrder.UseVisualStyleBackColor = true;
			this.btnSelectedSaleMaterialOrder.Click += new System.EventHandler(this.btnSelectedSaleMaterialOrder_Click);
			// 
			// txtRefDocument
			// 
			this.txtRefDocument.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRefDocument.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtRefDocument.Location = new System.Drawing.Point(151, 1);
			this.txtRefDocument.MaxLength = 50;
			this.txtRefDocument.Name = "txtRefDocument";
			this.txtRefDocument.Size = new System.Drawing.Size(207, 25);
			this.txtRefDocument.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "เลขที่เอกสารอ้างอิง";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtRecever);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 125);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(593, 28);
			this.panel5.TabIndex = 6;
			// 
			// txtRecever
			// 
			this.txtRecever.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRecever.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtRecever.Location = new System.Drawing.Point(151, 1);
			this.txtRecever.MaxLength = 50;
			this.txtRecever.Name = "txtRecever";
			this.txtRecever.Size = new System.Drawing.Size(207, 25);
			this.txtRecever.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(150, 26);
			this.label5.TabIndex = 3;
			this.label5.Text = "ผู้รับวัสดุ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnSendingDate);
			this.panel6.Controls.Add(this.txtSendingDate);
			this.panel6.Controls.Add(this.label12);
			this.panel6.Controls.Add(this.txtSender);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 153);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(593, 28);
			this.panel6.TabIndex = 7;
			// 
			// btnSendingDate
			// 
			this.btnSendingDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSendingDate.Location = new System.Drawing.Point(513, 1);
			this.btnSendingDate.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnSendingDate.Name = "btnSendingDate";
			this.btnSendingDate.SelectedDate = new System.DateTime(2016, 5, 10, 0, 0, 0, 0);
			this.btnSendingDate.Size = new System.Drawing.Size(26, 26);
			this.btnSendingDate.TabIndex = 7;
			this.btnSendingDate.DateSelected += new System.EventHandler(this.btnSendingDate_DateSelected);
			this.btnSendingDate.ButtonClick += new System.EventHandler(this.btnSendingDate_ButtonClick);
			// 
			// txtSendingDate
			// 
			this.txtSendingDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSendingDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSendingDate.Location = new System.Drawing.Point(412, 1);
			this.txtSendingDate.MaxLength = 10;
			this.txtSendingDate.Name = "txtSendingDate";
			this.txtSendingDate.Size = new System.Drawing.Size(101, 25);
			this.txtSendingDate.TabIndex = 6;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Left;
			this.label12.Location = new System.Drawing.Point(358, 1);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(54, 26);
			this.label12.TabIndex = 5;
			this.label12.Text = "วันที่ส่ง";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSender
			// 
			this.txtSender.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSender.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSender.Location = new System.Drawing.Point(151, 1);
			this.txtSender.MaxLength = 50;
			this.txtSender.Name = "txtSender";
			this.txtSender.Size = new System.Drawing.Size(207, 25);
			this.txtSender.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(150, 26);
			this.label6.TabIndex = 3;
			this.label6.Text = "ผู้ส่งวัสดุ (ลูกค้า)";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtDescription);
			this.panel7.Controls.Add(this.label7);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(2, 181);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(593, 28);
			this.panel7.TabIndex = 8;
			// 
			// txtDescription
			// 
			this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDescription.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtDescription.Location = new System.Drawing.Point(151, 1);
			this.txtDescription.MaxLength = 200;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(362, 25);
			this.txtDescription.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(150, 26);
			this.label7.TabIndex = 3;
			this.label7.Text = "รายละเอียด";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.btnMaterial);
			this.panel8.Controls.Add(this.txtMaterial);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(2, 209);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(593, 28);
			this.panel8.TabIndex = 9;
			// 
			// btnMaterial
			// 
			this.btnMaterial.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnMaterial.FlatAppearance.BorderSize = 0;
			this.btnMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMaterial.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterial.Image")));
			this.btnMaterial.Location = new System.Drawing.Point(358, 1);
			this.btnMaterial.Name = "btnMaterial";
			this.btnMaterial.Size = new System.Drawing.Size(26, 26);
			this.btnMaterial.TabIndex = 5;
			this.btnMaterial.UseVisualStyleBackColor = true;
			this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
			// 
			// txtMaterial
			// 
			this.txtMaterial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMaterial.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMaterial.Location = new System.Drawing.Point(151, 1);
			this.txtMaterial.MaxLength = 50;
			this.txtMaterial.Name = "txtMaterial";
			this.txtMaterial.Size = new System.Drawing.Size(207, 25);
			this.txtMaterial.TabIndex = 4;
			this.txtMaterial.TextChanged += new System.EventHandler(this.txtMaterial_TextChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 26);
			this.label8.TabIndex = 3;
			this.label8.Text = "ประเภทวัสดุ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.cbxUnit);
			this.panel9.Controls.Add(this.label9);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(2, 237);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(593, 28);
			this.panel9.TabIndex = 10;
			// 
			// cbxUnit
			// 
			this.cbxUnit.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxUnit.FormattingEnabled = true;
			this.cbxUnit.Location = new System.Drawing.Point(151, 1);
			this.cbxUnit.Name = "cbxUnit";
			this.cbxUnit.Size = new System.Drawing.Size(114, 25);
			this.cbxUnit.TabIndex = 5;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(1, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(150, 26);
			this.label9.TabIndex = 3;
			this.label9.Text = "หน่วย";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtReceiveWeight);
			this.panel10.Controls.Add(this.label10);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(2, 265);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(593, 28);
			this.panel10.TabIndex = 11;
			// 
			// txtReceiveWeight
			// 
			this.txtReceiveWeight.AllowControl = true;
			this.txtReceiveWeight.AllowDecimal = true;
			this.txtReceiveWeight.AllowMultipleDecimals = true;
			this.txtReceiveWeight.AllowNegation = true;
			this.txtReceiveWeight.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtReceiveWeight.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtReceiveWeight.IntegerValue = 0;
			this.txtReceiveWeight.Location = new System.Drawing.Point(151, 1);
			this.txtReceiveWeight.MaxLength = 15;
			this.txtReceiveWeight.Name = "txtReceiveWeight";
			this.txtReceiveWeight.Size = new System.Drawing.Size(114, 25);
			this.txtReceiveWeight.TabIndex = 4;
			this.txtReceiveWeight.Text = "0.00";
			this.txtReceiveWeight.TextChanged += new System.EventHandler(this.txtReceiveWeight_TextChanged);
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(1, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(150, 26);
			this.label10.TabIndex = 3;
			this.label10.Text = "ปริมาณที่รับ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// GRVInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 356);
			this.Controls.Add(this.panel10);
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.pnlCommand);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GRVInfo";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "MATERIAL RECEIVE INFO";
			this.Load += new System.EventHandler(this.GRVInfo_Load);
			this.pnlCommand.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label lbGRVId;
		private System.Windows.Forms.CheckBox chkReturnForSale;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtpGRVDate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRefDocument;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtRecever;
		private OMControls.MonthPopup btnSendingDate;
		private System.Windows.Forms.TextBox txtSendingDate;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtSender;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ComboBox cbxUnit;
		private OMControls.Controls.NumericTextBox txtReceiveWeight;
		private OMControls.OMFlatButton btnMaterial;
		private System.Windows.Forms.TextBox txtMaterial;
		private System.Windows.Forms.Label lbMode;
		private OMControls.OMFlatButton btnSelectedSaleMaterialOrder;
		private System.Windows.Forms.Label lbCustomer;
	}
}