namespace OMW15.Casting.CastingView

{
	partial class CastingFGItem
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
				_om.Dispose();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingFGItem));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.lbGroup = new System.Windows.Forms.Label();
			this.lbHeader = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.btnWorker = new OMControls.OMFlatButton();
			this.txtOperator = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtAvgWeight = new OMControls.Controls.NumericTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTotalWeight = new OMControls.Controls.NumericTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtTotalQty = new OMControls.Controls.NumericTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.cbxError = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtBadQty = new OMControls.Controls.NumericTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtScore = new OMControls.Controls.NumericTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtGoodQty = new OMControls.Controls.NumericTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnFinishDate = new OMControls.MonthPopup();
			this.txtFinishDate = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtItemNo = new System.Windows.Forms.TextBox();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.lbMode);
			this.panel1.Controls.Add(this.lbGroup);
			this.panel1.Controls.Add(this.lbHeader);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(506, 45);
			this.panel1.TabIndex = 0;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.Location = new System.Drawing.Point(226, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(100, 41);
			this.lbMode.TabIndex = 2;
			this.lbMode.Text = "---";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbGroup
			// 
			this.lbGroup.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbGroup.ForeColor = System.Drawing.Color.SteelBlue;
			this.lbGroup.Location = new System.Drawing.Point(326, 2);
			this.lbGroup.Name = "lbGroup";
			this.lbGroup.Size = new System.Drawing.Size(178, 41);
			this.lbGroup.TabIndex = 1;
			this.lbGroup.Text = "---";
			this.lbGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbHeader
			// 
			this.lbHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.Location = new System.Drawing.Point(2, 2);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(178, 41);
			this.lbHeader.TabIndex = 0;
			this.lbHeader.Text = "---";
			this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 323);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(506, 48);
			this.panel2.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(241, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(130, 38);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(371, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(130, 38);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlDetail
			// 
			this.pnlDetail.Controls.Add(this.panel11);
			this.pnlDetail.Controls.Add(this.panel10);
			this.pnlDetail.Controls.Add(this.panel9);
			this.pnlDetail.Controls.Add(this.panel8);
			this.pnlDetail.Controls.Add(this.panel7);
			this.pnlDetail.Controls.Add(this.panel6);
			this.pnlDetail.Controls.Add(this.panel5);
			this.pnlDetail.Controls.Add(this.panel4);
			this.pnlDetail.Controls.Add(this.panel3);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetail.Location = new System.Drawing.Point(0, 45);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
			this.pnlDetail.Size = new System.Drawing.Size(506, 278);
			this.pnlDetail.TabIndex = 2;
			// 
			// panel11
			// 
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(10, 236);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(2);
			this.panel11.Size = new System.Drawing.Size(486, 28);
			this.panel11.TabIndex = 8;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.btnWorker);
			this.panel10.Controls.Add(this.txtOperator);
			this.panel10.Controls.Add(this.label11);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(10, 208);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(2);
			this.panel10.Size = new System.Drawing.Size(486, 28);
			this.panel10.TabIndex = 7;
			// 
			// btnWorker
			// 
			this.btnWorker.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnWorker.FlatAppearance.BorderSize = 0;
			this.btnWorker.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnWorker.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWorker.Image = ((System.Drawing.Image)(resources.GetObject("btnWorker.Image")));
			this.btnWorker.Location = new System.Drawing.Point(366, 2);
			this.btnWorker.Name = "btnWorker";
			this.btnWorker.Size = new System.Drawing.Size(24, 24);
			this.btnWorker.TabIndex = 9;
			this.btnWorker.UseVisualStyleBackColor = true;
			this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
			// 
			// txtOperator
			// 
			this.txtOperator.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtOperator.Location = new System.Drawing.Point(90, 2);
			this.txtOperator.MaxLength = 35;
			this.txtOperator.Name = "txtOperator";
			this.txtOperator.Size = new System.Drawing.Size(276, 25);
			this.txtOperator.TabIndex = 8;
			this.txtOperator.TextChanged += new System.EventHandler(this.txtOperator_TextChanged);
			// 
			// label11
			// 
			this.label11.Dock = System.Windows.Forms.DockStyle.Left;
			this.label11.Location = new System.Drawing.Point(2, 2);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(88, 24);
			this.label11.TabIndex = 7;
			this.label11.Text = "ผู้ปฏิบัติงาน";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtAvgWeight);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Controls.Add(this.txtTotalWeight);
			this.panel9.Controls.Add(this.label9);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(10, 180);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(486, 28);
			this.panel9.TabIndex = 6;
			// 
			// txtAvgWeight
			// 
			this.txtAvgWeight.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtAvgWeight.Enabled = false;
			this.txtAvgWeight.Location = new System.Drawing.Point(285, 2);
			this.txtAvgWeight.MaxLength = 5;
			this.txtAvgWeight.Name = "txtAvgWeight";
			this.txtAvgWeight.Size = new System.Drawing.Size(81, 25);
			this.txtAvgWeight.TabIndex = 9;
			this.txtAvgWeight.Text = "0.00";
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(171, 2);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(114, 24);
			this.label10.TabIndex = 8;
			this.label10.Text = "น้ำหนักเฉลี่ย (g)  ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotalWeight
			// 
			this.txtTotalWeight.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTotalWeight.Location = new System.Drawing.Point(90, 2);
			this.txtTotalWeight.MaxLength = 10;
			this.txtTotalWeight.Name = "txtTotalWeight";
			this.txtTotalWeight.Size = new System.Drawing.Size(81, 25);
			this.txtTotalWeight.TabIndex = 7;
			this.txtTotalWeight.Text = "0.00";
			this.txtTotalWeight.TextChanged += new System.EventHandler(this.txtTotalWeight_TextChanged);
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(2, 2);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 24);
			this.label9.TabIndex = 6;
			this.label9.Text = "น้ำหนักงานรวม (g)";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtTotalQty);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(10, 152);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(2);
			this.panel8.Size = new System.Drawing.Size(486, 28);
			this.panel8.TabIndex = 5;
			// 
			// txtTotalQty
			// 
			this.txtTotalQty.BackColor = System.Drawing.Color.White;
			this.txtTotalQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtTotalQty.Location = new System.Drawing.Point(90, 2);
			this.txtTotalQty.MaxLength = 10;
			this.txtTotalQty.Name = "txtTotalQty";
			this.txtTotalQty.ReadOnly = true;
			this.txtTotalQty.Size = new System.Drawing.Size(81, 25);
			this.txtTotalQty.TabIndex = 6;
			this.txtTotalQty.Text = "0.00";
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(2, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(88, 24);
			this.label7.TabIndex = 5;
			this.label7.Text = "จำนวนงานรวม";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.cbxError);
			this.panel7.Controls.Add(this.label8);
			this.panel7.Controls.Add(this.txtBadQty);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(10, 124);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(486, 28);
			this.panel7.TabIndex = 4;
			// 
			// cbxError
			// 
			this.cbxError.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxError.FormattingEnabled = true;
			this.cbxError.Location = new System.Drawing.Point(285, 2);
			this.cbxError.Name = "cbxError";
			this.cbxError.Size = new System.Drawing.Size(191, 25);
			this.cbxError.TabIndex = 7;
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(171, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(114, 24);
			this.label8.TabIndex = 6;
			this.label8.Text = "สาเหตุงานเสีย  ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtBadQty
			// 
			this.txtBadQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBadQty.Location = new System.Drawing.Point(90, 2);
			this.txtBadQty.MaxLength = 10;
			this.txtBadQty.Name = "txtBadQty";
			this.txtBadQty.Size = new System.Drawing.Size(81, 25);
			this.txtBadQty.TabIndex = 5;
			this.txtBadQty.Text = "0.00";
			this.txtBadQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(2, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 24);
			this.label6.TabIndex = 4;
			this.label6.Text = "จำนวนงานเสีย";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtScore);
			this.panel6.Controls.Add(this.label5);
			this.panel6.Controls.Add(this.txtGoodQty);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(10, 96);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(486, 28);
			this.panel6.TabIndex = 3;
			// 
			// txtScore
			// 
			this.txtScore.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtScore.Enabled = false;
			this.txtScore.Location = new System.Drawing.Point(285, 2);
			this.txtScore.MaxLength = 10;
			this.txtScore.Name = "txtScore";
			this.txtScore.Size = new System.Drawing.Size(82, 25);
			this.txtScore.TabIndex = 6;
			this.txtScore.Text = "0.00";
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(171, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 24);
			this.label5.TabIndex = 5;
			this.label5.Text = "ระดับคะแนน  ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtGoodQty
			// 
			this.txtGoodQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtGoodQty.Location = new System.Drawing.Point(90, 2);
			this.txtGoodQty.MaxLength = 10;
			this.txtGoodQty.Name = "txtGoodQty";
			this.txtGoodQty.Size = new System.Drawing.Size(81, 25);
			this.txtGoodQty.TabIndex = 4;
			this.txtGoodQty.Text = "0.00";
			this.txtGoodQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 24);
			this.label4.TabIndex = 3;
			this.label4.Text = "จำนวนงานดี";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnFinishDate);
			this.panel5.Controls.Add(this.txtFinishDate);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 68);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(486, 28);
			this.panel5.TabIndex = 2;
			// 
			// btnFinishDate
			// 
			this.btnFinishDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFinishDate.Location = new System.Drawing.Point(261, 2);
			this.btnFinishDate.Name = "btnFinishDate";
			this.btnFinishDate.SelectedDate = new System.DateTime(2015, 2, 17, 0, 0, 0, 0);
			this.btnFinishDate.Size = new System.Drawing.Size(24, 24);
			this.btnFinishDate.TabIndex = 4;
			this.btnFinishDate.DateSelected += new System.EventHandler(this.btnFinishDate_DateSelected);
			this.btnFinishDate.ButtonClick += new System.EventHandler(this.btnFinishDate_ButtonClick);
			// 
			// txtFinishDate
			// 
			this.txtFinishDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtFinishDate.Enabled = false;
			this.txtFinishDate.Location = new System.Drawing.Point(90, 2);
			this.txtFinishDate.MaxLength = 10;
			this.txtFinishDate.Name = "txtFinishDate";
			this.txtFinishDate.Size = new System.Drawing.Size(171, 25);
			this.txtFinishDate.TabIndex = 3;
			this.txtFinishDate.TextChanged += new System.EventHandler(this.txtFinishDate_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "วันที่ทำงาน";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtItemName);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 40);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(486, 28);
			this.panel4.TabIndex = 1;
			// 
			// txtItemName
			// 
			this.txtItemName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemName.Enabled = false;
			this.txtItemName.Location = new System.Drawing.Point(90, 2);
			this.txtItemName.MaxLength = 35;
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.Size = new System.Drawing.Size(386, 25);
			this.txtItemName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "ชื่อสินค้า";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtItemNo);
			this.panel3.Controls.Add(this.txtPrefix);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 12);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(486, 28);
			this.panel3.TabIndex = 0;
			// 
			// txtItemNo
			// 
			this.txtItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemNo.Enabled = false;
			this.txtItemNo.Location = new System.Drawing.Point(113, 2);
			this.txtItemNo.MaxLength = 35;
			this.txtItemNo.Name = "txtItemNo";
			this.txtItemNo.Size = new System.Drawing.Size(112, 25);
			this.txtItemNo.TabIndex = 3;
			// 
			// txtPrefix
			// 
			this.txtPrefix.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPrefix.Enabled = false;
			this.txtPrefix.Location = new System.Drawing.Point(90, 2);
			this.txtPrefix.MaxLength = 2;
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(23, 25);
			this.txtPrefix.TabIndex = 2;
			this.txtPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัสสินค้า";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CastingFGItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(506, 371);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CastingFGItem";
			this.Text = "FG-ITEM";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CastingFGItem_FormClosing);
			this.Load += new System.EventHandler(this.CastingFGItem_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
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
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtItemName;
		private System.Windows.Forms.Label label2;
		private OMControls.MonthPopup btnFinishDate;
		private System.Windows.Forms.TextBox txtFinishDate;
		private System.Windows.Forms.Label label3;
		private OMControls.Controls.NumericTextBox txtGoodQty;
		private System.Windows.Forms.Label label4;
		private OMControls.Controls.NumericTextBox txtScore;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbMode;
		private OMControls.Controls.NumericTextBox txtBadQty;
		private System.Windows.Forms.Label label6;
		private OMControls.Controls.NumericTextBox txtTotalQty;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbxError;
		private System.Windows.Forms.Label label8;
		private OMControls.Controls.NumericTextBox txtTotalWeight;
		private System.Windows.Forms.Label label9;
		private OMControls.Controls.NumericTextBox txtAvgWeight;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtOperator;
		private System.Windows.Forms.Label label11;
		private OMControls.OMFlatButton btnWorker;
		private System.Windows.Forms.TextBox txtPrefix;
		private System.Windows.Forms.TextBox txtItemNo;
	}
}