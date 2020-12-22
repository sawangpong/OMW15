namespace OMW15.Views.CastingView
{
	partial class SCCollection
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
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grpBillCollection = new System.Windows.Forms.GroupBox();
			this.panel10 = new System.Windows.Forms.Panel();
			this.lbTotalCollectionText = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtTotalCollection = new OMControls.Controls.NumericTextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtWHTaxValue = new OMControls.Controls.NumericTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbxWHTaxRate = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.btnCollectDate = new OMControls.MonthPopup();
			this.lbCollectDate = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnInvoiceDate = new OMControls.MonthPopup();
			this.lbInvoiceDate = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtInvoiceNo = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.grpBillHeader = new System.Windows.Forms.GroupBox();
			this.panel13 = new System.Windows.Forms.Panel();
			this.lbBillingTotalAmount = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.panel12 = new System.Windows.Forms.Panel();
			this.lbVATValue = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.panel11 = new System.Windows.Forms.Panel();
			this.lbNetValue = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbBillDueDate = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbBillDate = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lbBillNo = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.grpBillCollection.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel7.SuspendLayout();
			this.grpBillHeader.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(470, 37);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "เก็บเงิน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 425);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(470, 52);
			this.panel2.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(226, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(117, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(343, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(117, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grpBillCollection);
			this.panel3.Controls.Add(this.grpBillHeader);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 37);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(7);
			this.panel3.Size = new System.Drawing.Size(470, 388);
			this.panel3.TabIndex = 2;
			// 
			// grpBillCollection
			// 
			this.grpBillCollection.Controls.Add(this.panel10);
			this.grpBillCollection.Controls.Add(this.panel9);
			this.grpBillCollection.Controls.Add(this.panel6);
			this.grpBillCollection.Controls.Add(this.panel14);
			this.grpBillCollection.Controls.Add(this.panel7);
			this.grpBillCollection.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpBillCollection.Location = new System.Drawing.Point(7, 178);
			this.grpBillCollection.Name = "grpBillCollection";
			this.grpBillCollection.Size = new System.Drawing.Size(456, 206);
			this.grpBillCollection.TabIndex = 1;
			this.grpBillCollection.TabStop = false;
			this.grpBillCollection.Text = "รายการชำระ";
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.lbTotalCollectionText);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(3, 174);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(450, 28);
			this.panel10.TabIndex = 10;
			// 
			// lbTotalCollectionText
			// 
			this.lbTotalCollectionText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTotalCollectionText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTotalCollectionText.Location = new System.Drawing.Point(1, 1);
			this.lbTotalCollectionText.Name = "lbTotalCollectionText";
			this.lbTotalCollectionText.Size = new System.Drawing.Size(448, 26);
			this.lbTotalCollectionText.TabIndex = 4;
			this.lbTotalCollectionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtTotalCollection);
			this.panel9.Controls.Add(this.label11);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(3, 146);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(450, 28);
			this.panel9.TabIndex = 9;
			// 
			// txtTotalCollection
			// 
			this.txtTotalCollection.AllowControl = true;
			this.txtTotalCollection.AllowDecimal = true;
			this.txtTotalCollection.AllowMultipleDecimals = true;
			this.txtTotalCollection.AllowNegation = true;
			this.txtTotalCollection.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtTotalCollection.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTotalCollection.IntegerValue = 0;
			this.txtTotalCollection.Location = new System.Drawing.Point(302, 1);
			this.txtTotalCollection.MaxLength = 15;
			this.txtTotalCollection.Name = "txtTotalCollection";
			this.txtTotalCollection.Size = new System.Drawing.Size(110, 25);
			this.txtTotalCollection.TabIndex = 5;
			this.txtTotalCollection.Text = "0.00";
			this.txtTotalCollection.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Left;
			this.label11.Location = new System.Drawing.Point(1, 1);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(301, 26);
			this.label11.TabIndex = 0;
			this.label11.Text = "ยอดชำระทั้งสิ้น :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.groupBox1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 77);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(15, 5, 15, 5);
			this.panel6.Size = new System.Drawing.Size(450, 69);
			this.panel6.TabIndex = 8;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel8);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(15, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(420, 59);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "รายการหัก";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtWHTaxValue);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Controls.Add(this.cbxWHTaxRate);
			this.panel8.Controls.Add(this.label8);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(3, 21);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(414, 28);
			this.panel8.TabIndex = 3;
			// 
			// txtWHTaxValue
			// 
			this.txtWHTaxValue.AllowControl = true;
			this.txtWHTaxValue.AllowDecimal = true;
			this.txtWHTaxValue.AllowMultipleDecimals = true;
			this.txtWHTaxValue.AllowNegation = true;
			this.txtWHTaxValue.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtWHTaxValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtWHTaxValue.IntegerValue = 0;
			this.txtWHTaxValue.Location = new System.Drawing.Point(284, 1);
			this.txtWHTaxValue.MaxLength = 15;
			this.txtWHTaxValue.Name = "txtWHTaxValue";
			this.txtWHTaxValue.Size = new System.Drawing.Size(110, 25);
			this.txtWHTaxValue.TabIndex = 4;
			this.txtWHTaxValue.Text = "0.00";
			this.txtWHTaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(174, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(110, 26);
			this.label5.TabIndex = 3;
			this.label5.Text = "จำนวนที่หัก :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxWHTaxRate
			// 
			this.cbxWHTaxRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWHTaxRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWHTaxRate.FormattingEnabled = true;
			this.cbxWHTaxRate.Location = new System.Drawing.Point(97, 1);
			this.cbxWHTaxRate.Name = "cbxWHTaxRate";
			this.cbxWHTaxRate.Size = new System.Drawing.Size(77, 25);
			this.cbxWHTaxRate.TabIndex = 1;
			this.cbxWHTaxRate.SelectionChangeCommitted += new System.EventHandler(this.cbxWHTaxRate_SelectionChangeCommitted);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 26);
			this.label8.TabIndex = 0;
			this.label8.Text = "ภาษี ณ. ที่จ่าย :";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.btnCollectDate);
			this.panel14.Controls.Add(this.lbCollectDate);
			this.panel14.Controls.Add(this.label6);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(3, 49);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(1);
			this.panel14.Size = new System.Drawing.Size(450, 28);
			this.panel14.TabIndex = 7;
			// 
			// btnCollectDate
			// 
			this.btnCollectDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCollectDate.Location = new System.Drawing.Point(412, 1);
			this.btnCollectDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCollectDate.Name = "btnCollectDate";
			this.btnCollectDate.SelectedDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
			this.btnCollectDate.Size = new System.Drawing.Size(26, 26);
			this.btnCollectDate.TabIndex = 5;
			this.btnCollectDate.DateSelected += new System.EventHandler(this.btnCollectDate_DateSelected);
			this.btnCollectDate.ButtonClick += new System.EventHandler(this.btnCollectDate_ButtonClick);
			// 
			// lbCollectDate
			// 
			this.lbCollectDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCollectDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCollectDate.Location = new System.Drawing.Point(302, 1);
			this.lbCollectDate.Name = "lbCollectDate";
			this.lbCollectDate.Size = new System.Drawing.Size(110, 26);
			this.lbCollectDate.TabIndex = 4;
			this.lbCollectDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(301, 26);
			this.label6.TabIndex = 3;
			this.label6.Text = "วันที่ชำระ :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.btnInvoiceDate);
			this.panel7.Controls.Add(this.lbInvoiceDate);
			this.panel7.Controls.Add(this.label10);
			this.panel7.Controls.Add(this.txtInvoiceNo);
			this.panel7.Controls.Add(this.label13);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(3, 21);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(450, 28);
			this.panel7.TabIndex = 2;
			// 
			// btnInvoiceDate
			// 
			this.btnInvoiceDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnInvoiceDate.Location = new System.Drawing.Point(412, 1);
			this.btnInvoiceDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnInvoiceDate.Name = "btnInvoiceDate";
			this.btnInvoiceDate.SelectedDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
			this.btnInvoiceDate.Size = new System.Drawing.Size(26, 26);
			this.btnInvoiceDate.TabIndex = 5;
			this.btnInvoiceDate.DateSelected += new System.EventHandler(this.btnInvoiceDate_DateSelected);
			this.btnInvoiceDate.ButtonClick += new System.EventHandler(this.btnInvoiceDate_ButtonClick);
			// 
			// lbInvoiceDate
			// 
			this.lbInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbInvoiceDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbInvoiceDate.Location = new System.Drawing.Point(302, 1);
			this.lbInvoiceDate.Name = "lbInvoiceDate";
			this.lbInvoiceDate.Size = new System.Drawing.Size(110, 26);
			this.lbInvoiceDate.TabIndex = 4;
			this.lbInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(237, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(65, 26);
			this.label10.TabIndex = 3;
			this.label10.Text = "วันที่ :";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtInvoiceNo
			// 
			this.txtInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtInvoiceNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtInvoiceNo.Location = new System.Drawing.Point(115, 1);
			this.txtInvoiceNo.MaxLength = 15;
			this.txtInvoiceNo.Name = "txtInvoiceNo";
			this.txtInvoiceNo.Size = new System.Drawing.Size(122, 25);
			this.txtInvoiceNo.TabIndex = 1;
			this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Left;
			this.label13.Location = new System.Drawing.Point(1, 1);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(114, 26);
			this.label13.TabIndex = 0;
			this.label13.Text = "เลขที่ใบกำกับภาษี :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grpBillHeader
			// 
			this.grpBillHeader.Controls.Add(this.panel13);
			this.grpBillHeader.Controls.Add(this.panel12);
			this.grpBillHeader.Controls.Add(this.panel11);
			this.grpBillHeader.Controls.Add(this.panel5);
			this.grpBillHeader.Controls.Add(this.panel4);
			this.grpBillHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpBillHeader.Location = new System.Drawing.Point(7, 7);
			this.grpBillHeader.Name = "grpBillHeader";
			this.grpBillHeader.Padding = new System.Windows.Forms.Padding(7);
			this.grpBillHeader.Size = new System.Drawing.Size(456, 171);
			this.grpBillHeader.TabIndex = 0;
			this.grpBillHeader.TabStop = false;
			this.grpBillHeader.Text = "ใบวางบิล";
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.lbBillingTotalAmount);
			this.panel13.Controls.Add(this.label20);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(7, 137);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(1);
			this.panel13.Size = new System.Drawing.Size(442, 28);
			this.panel13.TabIndex = 4;
			// 
			// lbBillingTotalAmount
			// 
			this.lbBillingTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbBillingTotalAmount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBillingTotalAmount.Location = new System.Drawing.Point(298, 1);
			this.lbBillingTotalAmount.Name = "lbBillingTotalAmount";
			this.lbBillingTotalAmount.Size = new System.Drawing.Size(110, 26);
			this.lbBillingTotalAmount.TabIndex = 4;
			this.lbBillingTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Dock = System.Windows.Forms.DockStyle.Left;
			this.label20.Location = new System.Drawing.Point(1, 1);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(297, 26);
			this.label20.TabIndex = 2;
			this.label20.Text = "ยอดรวมทั้งสิ้น :";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.lbVATValue);
			this.panel12.Controls.Add(this.label16);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel12.Location = new System.Drawing.Point(7, 109);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(1);
			this.panel12.Size = new System.Drawing.Size(442, 28);
			this.panel12.TabIndex = 3;
			// 
			// lbVATValue
			// 
			this.lbVATValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbVATValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbVATValue.Location = new System.Drawing.Point(298, 1);
			this.lbVATValue.Name = "lbVATValue";
			this.lbVATValue.Size = new System.Drawing.Size(110, 26);
			this.lbVATValue.TabIndex = 3;
			this.lbVATValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label16
			// 
			this.label16.Dock = System.Windows.Forms.DockStyle.Left;
			this.label16.Location = new System.Drawing.Point(1, 1);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(297, 26);
			this.label16.TabIndex = 2;
			this.label16.Text = "ภาษีมูลค่าเพิ่ม :";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.lbNetValue);
			this.panel11.Controls.Add(this.label14);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(7, 81);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(1);
			this.panel11.Size = new System.Drawing.Size(442, 28);
			this.panel11.TabIndex = 2;
			// 
			// lbNetValue
			// 
			this.lbNetValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbNetValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbNetValue.Location = new System.Drawing.Point(298, 1);
			this.lbNetValue.Name = "lbNetValue";
			this.lbNetValue.Size = new System.Drawing.Size(110, 26);
			this.lbNetValue.TabIndex = 1;
			this.lbNetValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Left;
			this.label14.Location = new System.Drawing.Point(1, 1);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(297, 26);
			this.label14.TabIndex = 0;
			this.label14.Text = "ยอดก่อนภาษีมูลค่าเพิ่ม :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lbBillDueDate);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(7, 53);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(442, 28);
			this.panel5.TabIndex = 1;
			// 
			// lbBillDueDate
			// 
			this.lbBillDueDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbBillDueDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBillDueDate.Location = new System.Drawing.Point(298, 1);
			this.lbBillDueDate.Name = "lbBillDueDate";
			this.lbBillDueDate.Size = new System.Drawing.Size(110, 26);
			this.lbBillDueDate.TabIndex = 1;
			this.lbBillDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(297, 26);
			this.label7.TabIndex = 0;
			this.label7.Text = "วันครบกำหนด :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbBillDate);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.lbBillNo);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(7, 25);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(442, 28);
			this.panel4.TabIndex = 0;
			// 
			// lbBillDate
			// 
			this.lbBillDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbBillDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBillDate.Location = new System.Drawing.Point(298, 1);
			this.lbBillDate.Name = "lbBillDate";
			this.lbBillDate.Size = new System.Drawing.Size(110, 26);
			this.lbBillDate.TabIndex = 3;
			this.lbBillDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(204, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "วันที่ :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbBillNo
			// 
			this.lbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbBillNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBillNo.Location = new System.Drawing.Point(94, 1);
			this.lbBillNo.Name = "lbBillNo";
			this.lbBillNo.Size = new System.Drawing.Size(110, 26);
			this.lbBillNo.TabIndex = 1;
			this.lbBillNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "เลขที่ใบวางบิล :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SCCollection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 477);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SCCollection";
			this.Text = "COLLECTION";
			this.Load += new System.EventHandler(this.SCCollection_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.grpBillCollection.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel14.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.grpBillHeader.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox grpBillCollection;
		private System.Windows.Forms.Panel panel7;
		private OMControls.MonthPopup btnInvoiceDate;
		private System.Windows.Forms.Label lbInvoiceDate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtInvoiceNo;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.GroupBox grpBillHeader;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label lbBillDueDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbBillDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbBillNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Label lbBillingTotalAmount;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Label lbVATValue;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Label lbNetValue;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label lbTotalCollectionText;
		private System.Windows.Forms.Panel panel9;
		private OMControls.Controls.NumericTextBox txtTotalCollection;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel8;
		private OMControls.Controls.NumericTextBox txtWHTaxValue;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbxWHTaxRate;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel panel14;
		private OMControls.MonthPopup btnCollectDate;
		private System.Windows.Forms.Label lbCollectDate;
		private System.Windows.Forms.Label label6;
	}
}