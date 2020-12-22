namespace OMW15.Views.Sales
{
	partial class PriceListItem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceListItem));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlImg = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.v = new System.Windows.Forms.Panel();
			this.lbEnterFlag = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.panel12 = new System.Windows.Forms.Panel();
			this.btnPriceExpireDate = new OMControls.MonthPopup();
			this.txtExpireDate = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.btnPriceEffective = new OMControls.MonthPopup();
			this.txtEffective = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.txtPartForMC = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtUSDUnitPrice = new OMControls.Controls.NumericTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnExchangeRate = new OMControls.OMFlatButton();
			this.txtExchange = new OMControls.Controls.NumericTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtTHBUnitPrice = new OMControls.Controls.NumericTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtTHBCost = new OMControls.Controls.NumericTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnUnitSearch = new OMControls.OMFlatButton();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnItemSearch = new OMControls.OMFlatButton();
			this.txtItemNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.pnlImg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.panel3.SuspendLayout();
			this.v.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 358);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(627, 43);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(412, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(105, 33);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(517, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(105, 33);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlImg
			// 
			this.pnlImg.Controls.Add(this.pic);
			this.pnlImg.Controls.Add(this.panel3);
			this.pnlImg.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlImg.Location = new System.Drawing.Point(496, 0);
			this.pnlImg.Name = "pnlImg";
			this.pnlImg.Padding = new System.Windows.Forms.Padding(5);
			this.pnlImg.Size = new System.Drawing.Size(131, 358);
			this.pnlImg.TabIndex = 1;
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Location = new System.Drawing.Point(5, 44);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(121, 129);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 2;
			this.pic.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbMode);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 5);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(121, 39);
			this.panel3.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.BackColor = System.Drawing.Color.MidnightBlue;
			this.lbMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(2, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(117, 35);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// v
			// 
			this.v.Controls.Add(this.lbEnterFlag);
			this.v.Controls.Add(this.panel11);
			this.v.Controls.Add(this.panel12);
			this.v.Controls.Add(this.panel10);
			this.v.Controls.Add(this.panel9);
			this.v.Controls.Add(this.panel8);
			this.v.Controls.Add(this.panel7);
			this.v.Controls.Add(this.panel6);
			this.v.Controls.Add(this.panel5);
			this.v.Controls.Add(this.panel4);
			this.v.Controls.Add(this.panel2);
			this.v.Dock = System.Windows.Forms.DockStyle.Fill;
			this.v.Location = new System.Drawing.Point(0, 0);
			this.v.Name = "v";
			this.v.Padding = new System.Windows.Forms.Padding(5);
			this.v.Size = new System.Drawing.Size(496, 358);
			this.v.TabIndex = 2;
			// 
			// lbEnterFlag
			// 
			this.lbEnterFlag.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbEnterFlag.Location = new System.Drawing.Point(5, 330);
			this.lbEnterFlag.Name = "lbEnterFlag";
			this.lbEnterFlag.Size = new System.Drawing.Size(115, 23);
			this.lbEnterFlag.TabIndex = 11;
			this.lbEnterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.chkIsActive);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(5, 302);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(1);
			this.panel11.Size = new System.Drawing.Size(486, 28);
			this.panel11.TabIndex = 10;
			// 
			// chkIsActive
			// 
			this.chkIsActive.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkIsActive.Location = new System.Drawing.Point(1, 1);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
			this.chkIsActive.Size = new System.Drawing.Size(211, 26);
			this.chkIsActive.TabIndex = 0;
			this.chkIsActive.Text = "ใช้งาน";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.btnPriceExpireDate);
			this.panel12.Controls.Add(this.txtExpireDate);
			this.panel12.Controls.Add(this.label10);
			this.panel12.Controls.Add(this.btnPriceEffective);
			this.panel12.Controls.Add(this.txtEffective);
			this.panel12.Controls.Add(this.label8);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new System.Drawing.Point(5, 274);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(1);
			this.panel12.Size = new System.Drawing.Size(486, 28);
			this.panel12.TabIndex = 9;
			// 
			// btnPriceExpireDate
			// 
			this.btnPriceExpireDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnPriceExpireDate.Location = new System.Drawing.Point(444, 1);
			this.btnPriceExpireDate.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
			this.btnPriceExpireDate.Name = "btnPriceExpireDate";
			this.btnPriceExpireDate.SelectedDate = new System.DateTime(2016, 12, 19, 0, 0, 0, 0);
			this.btnPriceExpireDate.Size = new System.Drawing.Size(26, 26);
			this.btnPriceExpireDate.TabIndex = 13;
			this.btnPriceExpireDate.DateSelected += new System.EventHandler(this.btnPriceExpireDate_DateSelected);
			this.btnPriceExpireDate.ButtonClick += new System.EventHandler(this.btnPriceExpireDate_ButtonClick);
			// 
			// txtExpireDate
			// 
			this.txtExpireDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtExpireDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtExpireDate.Location = new System.Drawing.Point(348, 1);
			this.txtExpireDate.MaxLength = 10;
			this.txtExpireDate.Name = "txtExpireDate";
			this.txtExpireDate.ReadOnly = true;
			this.txtExpireDate.Size = new System.Drawing.Size(96, 25);
			this.txtExpireDate.TabIndex = 12;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(238, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 26);
			this.label10.TabIndex = 11;
			this.label10.Text = "วันครบกำหนด:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnPriceEffective
			// 
			this.btnPriceEffective.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnPriceEffective.Location = new System.Drawing.Point(212, 1);
			this.btnPriceEffective.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.btnPriceEffective.Name = "btnPriceEffective";
			this.btnPriceEffective.SelectedDate = new System.DateTime(2016, 12, 19, 0, 0, 0, 0);
			this.btnPriceEffective.Size = new System.Drawing.Size(26, 26);
			this.btnPriceEffective.TabIndex = 10;
			this.btnPriceEffective.DateSelected += new System.EventHandler(this.btnPriceEffective_DateSelected);
			this.btnPriceEffective.ButtonClick += new System.EventHandler(this.btnPriceEffective_ButtonClick);
			// 
			// txtEffective
			// 
			this.txtEffective.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtEffective.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtEffective.Location = new System.Drawing.Point(116, 1);
			this.txtEffective.MaxLength = 10;
			this.txtEffective.Name = "txtEffective";
			this.txtEffective.ReadOnly = true;
			this.txtEffective.Size = new System.Drawing.Size(96, 25);
			this.txtEffective.TabIndex = 9;
			this.txtEffective.TextChanged += new System.EventHandler(this.txtEffective_TextChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(115, 26);
			this.label8.TabIndex = 8;
			this.label8.Text = "วันที่เริ่มใช้:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.txtPartForMC);
			this.panel10.Controls.Add(this.label9);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(5, 212);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(486, 62);
			this.panel10.TabIndex = 7;
			// 
			// txtPartForMC
			// 
			this.txtPartForMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPartForMC.Location = new System.Drawing.Point(116, 1);
			this.txtPartForMC.MaxLength = 300;
			this.txtPartForMC.Multiline = true;
			this.txtPartForMC.Name = "txtPartForMC";
			this.txtPartForMC.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPartForMC.Size = new System.Drawing.Size(349, 60);
			this.txtPartForMC.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(1, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(115, 60);
			this.label9.TabIndex = 1;
			this.label9.Text = "เครื่องจักรที่ใช้ได้";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtUSDUnitPrice);
			this.panel9.Controls.Add(this.label7);
			this.panel9.Controls.Add(this.btnExchangeRate);
			this.panel9.Controls.Add(this.txtExchange);
			this.panel9.Controls.Add(this.label11);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(5, 184);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(486, 28);
			this.panel9.TabIndex = 6;
			// 
			// txtUSDUnitPrice
			// 
			this.txtUSDUnitPrice.AllowControl = true;
			this.txtUSDUnitPrice.AllowDecimal = true;
			this.txtUSDUnitPrice.AllowMultipleDecimals = true;
			this.txtUSDUnitPrice.AllowNegation = true;
			this.txtUSDUnitPrice.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtUSDUnitPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUSDUnitPrice.IntegerValue = 0;
			this.txtUSDUnitPrice.Location = new System.Drawing.Point(342, 1);
			this.txtUSDUnitPrice.MaxLength = 15;
			this.txtUSDUnitPrice.Name = "txtUSDUnitPrice";
			this.txtUSDUnitPrice.Size = new System.Drawing.Size(123, 25);
			this.txtUSDUnitPrice.TabIndex = 6;
			this.txtUSDUnitPrice.Tag = "US";
			this.txtUSDUnitPrice.Text = "0.00";
			this.txtUSDUnitPrice.TextChanged += new System.EventHandler(this.txt_TextChanged);
			this.txtUSDUnitPrice.Enter += new System.EventHandler(this.txtUSDUnitPrice_Enter);
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(220, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(122, 26);
			this.label7.TabIndex = 5;
			this.label7.Text = "ราคาขาย ($)";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnExchangeRate
			// 
			this.btnExchangeRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnExchangeRate.Enabled = false;
			this.btnExchangeRate.FlatAppearance.BorderSize = 0;
			this.btnExchangeRate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnExchangeRate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExchangeRate.Image = ((System.Drawing.Image)(resources.GetObject("btnExchangeRate.Image")));
			this.btnExchangeRate.Location = new System.Drawing.Point(194, 1);
			this.btnExchangeRate.Name = "btnExchangeRate";
			this.btnExchangeRate.Size = new System.Drawing.Size(26, 26);
			this.btnExchangeRate.TabIndex = 4;
			this.btnExchangeRate.UseVisualStyleBackColor = true;
			// 
			// txtExchange
			// 
			this.txtExchange.AllowControl = true;
			this.txtExchange.AllowDecimal = true;
			this.txtExchange.AllowMultipleDecimals = false;
			this.txtExchange.AllowNegation = true;
			this.txtExchange.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtExchange.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtExchange.IntegerValue = 0;
			this.txtExchange.Location = new System.Drawing.Point(116, 1);
			this.txtExchange.MaxLength = 9;
			this.txtExchange.Name = "txtExchange";
			this.txtExchange.Size = new System.Drawing.Size(78, 25);
			this.txtExchange.TabIndex = 3;
			this.txtExchange.Tag = "EX";
			this.txtExchange.Text = "0.00";
			this.txtExchange.WordWrap = false;
			this.txtExchange.TextChanged += new System.EventHandler(this.txt_TextChanged);
			this.txtExchange.Enter += new System.EventHandler(this.txtExchange_Enter);
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Left;
			this.label11.Location = new System.Drawing.Point(1, 1);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(115, 26);
			this.label11.TabIndex = 2;
			this.label11.Text = "อัตตราแลกเปลี่ยน (฿)";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtTHBUnitPrice);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(5, 156);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(486, 28);
			this.panel8.TabIndex = 5;
			// 
			// txtTHBUnitPrice
			// 
			this.txtTHBUnitPrice.AllowControl = true;
			this.txtTHBUnitPrice.AllowDecimal = true;
			this.txtTHBUnitPrice.AllowMultipleDecimals = true;
			this.txtTHBUnitPrice.AllowNegation = true;
			this.txtTHBUnitPrice.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtTHBUnitPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTHBUnitPrice.IntegerValue = 0;
			this.txtTHBUnitPrice.Location = new System.Drawing.Point(116, 1);
			this.txtTHBUnitPrice.MaxLength = 15;
			this.txtTHBUnitPrice.Name = "txtTHBUnitPrice";
			this.txtTHBUnitPrice.Size = new System.Drawing.Size(123, 25);
			this.txtTHBUnitPrice.TabIndex = 1;
			this.txtTHBUnitPrice.Text = "0.00";
			this.txtTHBUnitPrice.TextChanged += new System.EventHandler(this.txtTHBUnitPrice_TextChanged);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 26);
			this.label6.TabIndex = 0;
			this.label6.Text = "ราคาขาย (฿)";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtTHBCost);
			this.panel7.Controls.Add(this.label5);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(5, 128);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(486, 28);
			this.panel7.TabIndex = 4;
			// 
			// txtTHBCost
			// 
			this.txtTHBCost.AllowControl = true;
			this.txtTHBCost.AllowDecimal = true;
			this.txtTHBCost.AllowMultipleDecimals = true;
			this.txtTHBCost.AllowNegation = true;
			this.txtTHBCost.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtTHBCost.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTHBCost.IntegerValue = 0;
			this.txtTHBCost.Location = new System.Drawing.Point(116, 1);
			this.txtTHBCost.MaxLength = 15;
			this.txtTHBCost.Name = "txtTHBCost";
			this.txtTHBCost.Size = new System.Drawing.Size(123, 25);
			this.txtTHBCost.TabIndex = 1;
			this.txtTHBCost.Text = "0.00";
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(115, 26);
			this.label5.TabIndex = 0;
			this.label5.Text = "ต้นทุน (฿)";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnUnitSearch);
			this.panel6.Controls.Add(this.txtUnit);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(5, 100);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(486, 28);
			this.panel6.TabIndex = 3;
			// 
			// btnUnitSearch
			// 
			this.btnUnitSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUnitSearch.FlatAppearance.BorderSize = 0;
			this.btnUnitSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnUnitSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnUnitSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUnitSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitSearch.Image")));
			this.btnUnitSearch.Location = new System.Drawing.Point(212, 1);
			this.btnUnitSearch.Name = "btnUnitSearch";
			this.btnUnitSearch.Size = new System.Drawing.Size(26, 26);
			this.btnUnitSearch.TabIndex = 3;
			this.btnUnitSearch.UseVisualStyleBackColor = true;
			// 
			// txtUnit
			// 
			this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUnit.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUnit.Location = new System.Drawing.Point(116, 1);
			this.txtUnit.MaxLength = 10;
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(96, 25);
			this.txtUnit.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(115, 26);
			this.label4.TabIndex = 0;
			this.label4.Text = "หน่วยนับ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtItemName);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(5, 72);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(486, 28);
			this.panel5.TabIndex = 2;
			// 
			// txtItemName
			// 
			this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtItemName.Location = new System.Drawing.Point(116, 1);
			this.txtItemName.MaxLength = 150;
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.Size = new System.Drawing.Size(369, 25);
			this.txtItemName.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 26);
			this.label3.TabIndex = 0;
			this.label3.Text = "ชื่อสินค้า";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnItemSearch);
			this.panel4.Controls.Add(this.txtItemNo);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 44);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(486, 28);
			this.panel4.TabIndex = 1;
			// 
			// btnItemSearch
			// 
			this.btnItemSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnItemSearch.FlatAppearance.BorderSize = 0;
			this.btnItemSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnItemSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItemSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnItemSearch.Image")));
			this.btnItemSearch.Location = new System.Drawing.Point(309, 1);
			this.btnItemSearch.Name = "btnItemSearch";
			this.btnItemSearch.Size = new System.Drawing.Size(26, 26);
			this.btnItemSearch.TabIndex = 2;
			this.btnItemSearch.UseVisualStyleBackColor = true;
			this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
			// 
			// txtItemNo
			// 
			this.txtItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtItemNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtItemNo.Location = new System.Drawing.Point(116, 1);
			this.txtItemNo.MaxLength = 35;
			this.txtItemNo.Name = "txtItemNo";
			this.txtItemNo.ReadOnly = true;
			this.txtItemNo.Size = new System.Drawing.Size(193, 25);
			this.txtItemNo.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "รหัสสินค้า";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 5);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(486, 39);
			this.panel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.MediumBlue;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(214, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "รายละเอียดสินค้า";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// PriceListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(627, 401);
			this.Controls.Add(this.v);
			this.Controls.Add(this.pnlImg);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PriceListItem";
			this.Text = "PRICE ITEM INFO.";
			this.Load += new System.EventHandler(this.PriceListItem_Load);
			this.panel1.ResumeLayout(false);
			this.pnlImg.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.panel3.ResumeLayout(false);
			this.v.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel12.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
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
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlImg;
		private System.Windows.Forms.Panel v;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private OMControls.OMFlatButton btnItemSearch;
		private System.Windows.Forms.TextBox txtItemNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtItemName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel6;
		private OMControls.OMFlatButton btnUnitSearch;
		private System.Windows.Forms.TextBox txtUnit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private OMControls.Controls.NumericTextBox txtTHBUnitPrice;
		private System.Windows.Forms.Label label6;
		private OMControls.Controls.NumericTextBox txtTHBCost;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.TextBox txtPartForMC;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.Windows.Forms.Panel panel12;
		private OMControls.MonthPopup btnPriceEffective;
		private System.Windows.Forms.TextBox txtEffective;
		private System.Windows.Forms.Label label8;
		private OMControls.MonthPopup btnPriceExpireDate;
		private System.Windows.Forms.TextBox txtExpireDate;
		private System.Windows.Forms.Label label10;
		private OMControls.Controls.NumericTextBox txtUSDUnitPrice;
		private System.Windows.Forms.Label label7;
		private OMControls.OMFlatButton btnExchangeRate;
		private OMControls.Controls.NumericTextBox txtExchange;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lbEnterFlag;
	}
}