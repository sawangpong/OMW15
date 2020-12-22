namespace OMW15.Tools
{
	partial class CompanyProfile
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyProfile));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtPostal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtCountry = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtProvince = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtAdddress = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtCompanyName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbCompanyId = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.panel15 = new System.Windows.Forms.Panel();
			this.btnImageLocation = new OMControls.OMFlatButton();
			this.txtImageLocation = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.txtHomeCurrency = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.txtMaterialMarkupFactor = new OMControls.Controls.NumericTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel12 = new System.Windows.Forms.Panel();
			this.txtVATRate = new OMControls.Controls.NumericTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.txtNonVATRate = new OMControls.Controls.NumericTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtTaxId = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel10.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 408);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(6);
			this.panel1.Size = new System.Drawing.Size(729, 50);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Font = new System.Drawing.Font("Leelawadee", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnSave.Location = new System.Drawing.Point(423, 6);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(150, 38);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "บันทึก";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Font = new System.Drawing.Font("Leelawadee", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnCancel.Location = new System.Drawing.Point(573, 6);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(150, 38);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "ยกเลิก";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.DimGray;
			this.panel2.Controls.Add(this.lbMode);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(6, 6);
			this.panel2.Margin = new System.Windows.Forms.Padding(4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(6);
			this.panel2.Size = new System.Drawing.Size(729, 51);
			this.panel2.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Leelawadee", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(573, 6);
			this.lbMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(150, 39);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Leelawadee", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.label1.ForeColor = System.Drawing.Color.Yellow;
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(373, 39);
			this.label1.TabIndex = 0;
			this.label1.Text = "Company Profile";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(6, 57);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(729, 351);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel9);
			this.tabPage1.Controls.Add(this.panel8);
			this.tabPage1.Controls.Add(this.panel7);
			this.tabPage1.Controls.Add(this.panel6);
			this.tabPage1.Controls.Add(this.panel5);
			this.tabPage1.Controls.Add(this.panel4);
			this.tabPage1.Controls.Add(this.panel3);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.tabPage1.Size = new System.Drawing.Size(721, 320);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "ข้อมูลทั่วไปของบริษัท";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel9
			// 
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(13, 253);
			this.panel9.Margin = new System.Windows.Forms.Padding(4);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(695, 28);
			this.panel9.TabIndex = 6;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtPostal);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(13, 225);
			this.panel8.Margin = new System.Windows.Forms.Padding(4);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(695, 28);
			this.panel8.TabIndex = 5;
			// 
			// txtPostal
			// 
			this.txtPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPostal.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPostal.Location = new System.Drawing.Point(154, 1);
			this.txtPostal.Margin = new System.Windows.Forms.Padding(4);
			this.txtPostal.MaxLength = 10;
			this.txtPostal.Name = "txtPostal";
			this.txtPostal.Size = new System.Drawing.Size(152, 24);
			this.txtPostal.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(153, 26);
			this.label7.TabIndex = 4;
			this.label7.Text = "รหัสไปรษณีย์ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtCountry);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(13, 197);
			this.panel7.Margin = new System.Windows.Forms.Padding(4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(695, 28);
			this.panel7.TabIndex = 4;
			// 
			// txtCountry
			// 
			this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCountry.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCountry.Location = new System.Drawing.Point(154, 1);
			this.txtCountry.Margin = new System.Windows.Forms.Padding(4);
			this.txtCountry.MaxLength = 50;
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.Size = new System.Drawing.Size(244, 24);
			this.txtCountry.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(153, 26);
			this.label6.TabIndex = 3;
			this.label6.Text = "ประเทศ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtProvince);
			this.panel6.Controls.Add(this.label5);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(13, 169);
			this.panel6.Margin = new System.Windows.Forms.Padding(4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(695, 28);
			this.panel6.TabIndex = 3;
			// 
			// txtProvince
			// 
			this.txtProvince.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProvince.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtProvince.Location = new System.Drawing.Point(154, 1);
			this.txtProvince.Margin = new System.Windows.Forms.Padding(4);
			this.txtProvince.MaxLength = 50;
			this.txtProvince.Name = "txtProvince";
			this.txtProvince.Size = new System.Drawing.Size(244, 24);
			this.txtProvince.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(153, 26);
			this.label5.TabIndex = 2;
			this.label5.Text = "จังหวัด :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtAdddress);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(13, 68);
			this.panel5.Margin = new System.Windows.Forms.Padding(4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(695, 101);
			this.panel5.TabIndex = 2;
			// 
			// txtAdddress
			// 
			this.txtAdddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtAdddress.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtAdddress.Location = new System.Drawing.Point(154, 1);
			this.txtAdddress.Margin = new System.Windows.Forms.Padding(4);
			this.txtAdddress.MaxLength = 300;
			this.txtAdddress.Multiline = true;
			this.txtAdddress.Name = "txtAdddress";
			this.txtAdddress.Size = new System.Drawing.Size(525, 99);
			this.txtAdddress.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 99);
			this.label4.TabIndex = 2;
			this.label4.Text = "ที่อยู่ :";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtCompanyName);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(13, 40);
			this.panel4.Margin = new System.Windows.Forms.Padding(4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(695, 28);
			this.panel4.TabIndex = 1;
			// 
			// txtCompanyName
			// 
			this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCompanyName.Location = new System.Drawing.Point(154, 1);
			this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4);
			this.txtCompanyName.MaxLength = 150;
			this.txtCompanyName.Name = "txtCompanyName";
			this.txtCompanyName.Size = new System.Drawing.Size(525, 24);
			this.txtCompanyName.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(153, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "ชื่อบริษัท :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbCompanyId);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(13, 12);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(695, 28);
			this.panel3.TabIndex = 0;
			// 
			// lbCompanyId
			// 
			this.lbCompanyId.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.lbCompanyId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCompanyId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCompanyId.Location = new System.Drawing.Point(154, 1);
			this.lbCompanyId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbCompanyId.Name = "lbCompanyId";
			this.lbCompanyId.Size = new System.Drawing.Size(152, 26);
			this.lbCompanyId.TabIndex = 1;
			this.lbCompanyId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(153, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "รหัสบริษัท :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel15);
			this.tabPage2.Controls.Add(this.panel14);
			this.tabPage2.Controls.Add(this.panel13);
			this.tabPage2.Controls.Add(this.panel12);
			this.tabPage2.Controls.Add(this.panel11);
			this.tabPage2.Controls.Add(this.panel10);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
			this.tabPage2.Size = new System.Drawing.Size(721, 320);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "ข้อมูลสำหรับระบบ";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.btnImageLocation);
			this.panel15.Controls.Add(this.txtImageLocation);
			this.panel15.Controls.Add(this.label13);
			this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new System.Drawing.Point(13, 152);
			this.panel15.Margin = new System.Windows.Forms.Padding(4);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new System.Windows.Forms.Padding(1);
			this.panel15.Size = new System.Drawing.Size(695, 28);
			this.panel15.TabIndex = 6;
			// 
			// btnImageLocation
			// 
			this.btnImageLocation.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnImageLocation.FlatAppearance.BorderSize = 0;
			this.btnImageLocation.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnImageLocation.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnImageLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImageLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnImageLocation.Image")));
			this.btnImageLocation.Location = new System.Drawing.Point(662, 1);
			this.btnImageLocation.Name = "btnImageLocation";
			this.btnImageLocation.Size = new System.Drawing.Size(26, 26);
			this.btnImageLocation.TabIndex = 2;
			this.btnImageLocation.UseVisualStyleBackColor = true;
			this.btnImageLocation.Click += new System.EventHandler(this.btnImageLocation_Click);
			// 
			// txtImageLocation
			// 
			this.txtImageLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtImageLocation.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtImageLocation.Location = new System.Drawing.Point(202, 1);
			this.txtImageLocation.MaxLength = 255;
			this.txtImageLocation.Name = "txtImageLocation";
			this.txtImageLocation.Size = new System.Drawing.Size(460, 24);
			this.txtImageLocation.TabIndex = 1;
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Left;
			this.label13.Location = new System.Drawing.Point(1, 1);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(201, 26);
			this.label13.TabIndex = 0;
			this.label13.Text = "ที่เก็บไฟล์รูปภาพ :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.txtHomeCurrency);
			this.panel14.Controls.Add(this.label12);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(13, 124);
			this.panel14.Margin = new System.Windows.Forms.Padding(4);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(1);
			this.panel14.Size = new System.Drawing.Size(695, 28);
			this.panel14.TabIndex = 5;
			// 
			// txtHomeCurrency
			// 
			this.txtHomeCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtHomeCurrency.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtHomeCurrency.Location = new System.Drawing.Point(202, 1);
			this.txtHomeCurrency.MaxLength = 5;
			this.txtHomeCurrency.Name = "txtHomeCurrency";
			this.txtHomeCurrency.Size = new System.Drawing.Size(86, 24);
			this.txtHomeCurrency.TabIndex = 1;
			// 
			// label12
			// 
			this.label12.Dock = System.Windows.Forms.DockStyle.Left;
			this.label12.Location = new System.Drawing.Point(1, 1);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(201, 26);
			this.label12.TabIndex = 0;
			this.label12.Text = "สกุลเงินหลัก (Home Currency) :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.txtMaterialMarkupFactor);
			this.panel13.Controls.Add(this.label11);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(13, 96);
			this.panel13.Margin = new System.Windows.Forms.Padding(4);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(1);
			this.panel13.Size = new System.Drawing.Size(695, 28);
			this.panel13.TabIndex = 4;
			// 
			// txtMaterialMarkupFactor
			// 
			this.txtMaterialMarkupFactor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMaterialMarkupFactor.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMaterialMarkupFactor.Location = new System.Drawing.Point(202, 1);
			this.txtMaterialMarkupFactor.Margin = new System.Windows.Forms.Padding(4);
			this.txtMaterialMarkupFactor.MaxLength = 8;
			this.txtMaterialMarkupFactor.Name = "txtMaterialMarkupFactor";
			this.txtMaterialMarkupFactor.Size = new System.Drawing.Size(86, 24);
			this.txtMaterialMarkupFactor.TabIndex = 2;
			this.txtMaterialMarkupFactor.Text = "0.00";
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Left;
			this.label11.Location = new System.Drawing.Point(1, 1);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(201, 26);
			this.label11.TabIndex = 0;
			this.label11.Text = "ตัวคูณราคาขายวัสดุ :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.txtVATRate);
			this.panel12.Controls.Add(this.label10);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new System.Drawing.Point(13, 68);
			this.panel12.Margin = new System.Windows.Forms.Padding(4);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(1);
			this.panel12.Size = new System.Drawing.Size(695, 28);
			this.panel12.TabIndex = 3;
			// 
			// txtVATRate
			// 
			this.txtVATRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVATRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtVATRate.Location = new System.Drawing.Point(202, 1);
			this.txtVATRate.Margin = new System.Windows.Forms.Padding(4);
			this.txtVATRate.MaxLength = 3;
			this.txtVATRate.Name = "txtVATRate";
			this.txtVATRate.Size = new System.Drawing.Size(86, 24);
			this.txtVATRate.TabIndex = 2;
			this.txtVATRate.Text = "0.00";
			this.txtVATRate.TextChanged += new System.EventHandler(this.txtVATRate_TextChanged);
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(1, 1);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(201, 26);
			this.label10.TabIndex = 0;
			this.label10.Text = "อัตราภาษีมูลค่าเพิ่ม (%):";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.txtNonVATRate);
			this.panel11.Controls.Add(this.label8);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(13, 40);
			this.panel11.Margin = new System.Windows.Forms.Padding(4);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(1);
			this.panel11.Size = new System.Drawing.Size(695, 28);
			this.panel11.TabIndex = 2;
			// 
			// txtNonVATRate
			// 
			this.txtNonVATRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNonVATRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtNonVATRate.Location = new System.Drawing.Point(202, 1);
			this.txtNonVATRate.Margin = new System.Windows.Forms.Padding(4);
			this.txtNonVATRate.MaxLength = 3;
			this.txtNonVATRate.Name = "txtNonVATRate";
			this.txtNonVATRate.Size = new System.Drawing.Size(86, 24);
			this.txtNonVATRate.TabIndex = 1;
			this.txtNonVATRate.Text = "0.00";
			this.txtNonVATRate.TextChanged += new System.EventHandler(this.txtNonVATRate_TextChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(201, 26);
			this.label8.TabIndex = 0;
			this.label8.Text = "Non-VAT Rate (%):";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtTaxId);
			this.panel10.Controls.Add(this.label9);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(13, 12);
			this.panel10.Margin = new System.Windows.Forms.Padding(4);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(695, 28);
			this.panel10.TabIndex = 1;
			// 
			// txtTaxId
			// 
			this.txtTaxId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtTaxId.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTaxId.Location = new System.Drawing.Point(202, 1);
			this.txtTaxId.Margin = new System.Windows.Forms.Padding(4);
			this.txtTaxId.MaxLength = 13;
			this.txtTaxId.Name = "txtTaxId";
			this.txtTaxId.Size = new System.Drawing.Size(190, 24);
			this.txtTaxId.TabIndex = 4;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(1, 1);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(201, 26);
			this.label9.TabIndex = 0;
			this.label9.Text = "หมายเลขผู้เสียภาษี:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CompanyProfile
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(741, 464);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CompanyProfile";
			this.Padding = new System.Windows.Forms.Padding(6);
			this.Text = "COMPANY PROFILE";
			this.Load += new System.EventHandler(this.CompanyProfile_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			this.panel11.ResumeLayout(false);
			this.panel11.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtCompanyName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbCompanyId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAdddress;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtPostal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtCountry;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtProvince;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTaxId;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Label label8;
		private OMControls.Controls.NumericTextBox txtVATRate;
		private OMControls.Controls.NumericTextBox txtNonVATRate;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Panel panel13;
		private OMControls.Controls.NumericTextBox txtMaterialMarkupFactor;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtHomeCurrency;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.TextBox txtImageLocation;
		private System.Windows.Forms.Label label13;
		private OMControls.OMFlatButton btnImageLocation;
	}
}