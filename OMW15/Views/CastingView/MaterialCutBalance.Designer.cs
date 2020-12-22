namespace OMW15.Views.CastingView
{
	partial class MaterialCutBalance
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnLoadCustomer = new System.Windows.Forms.Button();
			this.lbSelectedCustomer = new System.Windows.Forms.Label();
			this.cbxMatCategory = new System.Windows.Forms.ComboBox();
			this.lbMatCat = new System.Windows.Forms.Label();
			this.chkAllMatCategory = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.customerSearch = new OMControls.Controls.searchBox();
			this.chkUpdateOpenBalanceForAllCustomers = new System.Windows.Forms.CheckBox();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.dgvCustomers = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTotalCustomerFound = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cbxOpenYear = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbProgress = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.pnlRightBottom = new System.Windows.Forms.Panel();
			this.dgvBalance = new System.Windows.Forms.DataGridView();
			this.pnlUpdateCommand = new System.Windows.Forms.Panel();
			this.btnUpdateOpenBalance = new System.Windows.Forms.Button();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnlRightTop = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txt = new System.Windows.Forms.TextBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.btnOpenBalance = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbCalCount = new System.Windows.Forms.Label();
			this.pnlProgress = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.cpb = new OMControls.Controls.CircularProgressBar();
			this.pnlTop.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.pnlRightBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).BeginInit();
			this.pnlUpdateCommand.SuspendLayout();
			this.pnlRightTop.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.pnlProgress.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel4);
			this.pnlTop.Controls.Add(this.panel3);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(3, 3);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(936, 68);
			this.pnlTop.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnLoadCustomer);
			this.panel4.Controls.Add(this.lbSelectedCustomer);
			this.panel4.Controls.Add(this.cbxMatCategory);
			this.panel4.Controls.Add(this.lbMatCat);
			this.panel4.Controls.Add(this.chkAllMatCategory);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 33);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(932, 30);
			this.panel4.TabIndex = 2;
			// 
			// btnLoadCustomer
			// 
			this.btnLoadCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadCustomer.Location = new System.Drawing.Point(762, 2);
			this.btnLoadCustomer.Name = "btnLoadCustomer";
			this.btnLoadCustomer.Size = new System.Drawing.Size(93, 26);
			this.btnLoadCustomer.TabIndex = 9;
			this.btnLoadCustomer.Text = "Load Info.";
			this.btnLoadCustomer.UseVisualStyleBackColor = true;
			this.btnLoadCustomer.Click += new System.EventHandler(this.btnLoadCustomer_Click);
			// 
			// lbSelectedCustomer
			// 
			this.lbSelectedCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbSelectedCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedCustomer.Location = new System.Drawing.Point(357, 2);
			this.lbSelectedCustomer.Name = "lbSelectedCustomer";
			this.lbSelectedCustomer.Size = new System.Drawing.Size(405, 26);
			this.lbSelectedCustomer.TabIndex = 8;
			this.lbSelectedCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbxMatCategory
			// 
			this.cbxMatCategory.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMatCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMatCategory.FormattingEnabled = true;
			this.cbxMatCategory.Location = new System.Drawing.Point(199, 2);
			this.cbxMatCategory.Name = "cbxMatCategory";
			this.cbxMatCategory.Size = new System.Drawing.Size(158, 25);
			this.cbxMatCategory.TabIndex = 7;
			this.cbxMatCategory.SelectionChangeCommitted += new System.EventHandler(this.cbxMatCategory_SelectionChangeCommitted);
			// 
			// lbMatCat
			// 
			this.lbMatCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMatCat.Location = new System.Drawing.Point(109, 2);
			this.lbMatCat.Name = "lbMatCat";
			this.lbMatCat.Size = new System.Drawing.Size(90, 26);
			this.lbMatCat.TabIndex = 6;
			this.lbMatCat.Text = "เลือกกลุ่มวัสดุ";
			this.lbMatCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkAllMatCategory
			// 
			this.chkAllMatCategory.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkAllMatCategory.Location = new System.Drawing.Point(2, 2);
			this.chkAllMatCategory.Name = "chkAllMatCategory";
			this.chkAllMatCategory.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.chkAllMatCategory.Size = new System.Drawing.Size(107, 26);
			this.chkAllMatCategory.TabIndex = 5;
			this.chkAllMatCategory.Text = "ทุกกลุ่มวัสดุ";
			this.chkAllMatCategory.UseVisualStyleBackColor = true;
			this.chkAllMatCategory.CheckedChanged += new System.EventHandler(this.chkAllMatCategory_CheckedChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Controls.Add(this.customerSearch);
			this.panel3.Controls.Add(this.chkUpdateOpenBalanceForAllCustomers);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(932, 31);
			this.panel3.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(843, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(87, 27);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// customerSearch
			// 
			this.customerSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.customerSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.customerSearch.Location = new System.Drawing.Point(199, 2);
			this.customerSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.customerSearch.Name = "customerSearch";
			this.customerSearch.Padding = new System.Windows.Forms.Padding(1);
			this.customerSearch.Size = new System.Drawing.Size(338, 27);
			this.customerSearch.TabIndex = 1;
			this.customerSearch.TextFilter = null;
			this.customerSearch.OnSendingFiler += new OMControls.Controls.SendingFilter(this.customerSearch_OnSendingFiler);
			// 
			// chkUpdateOpenBalanceForAllCustomers
			// 
			this.chkUpdateOpenBalanceForAllCustomers.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkUpdateOpenBalanceForAllCustomers.Location = new System.Drawing.Point(2, 2);
			this.chkUpdateOpenBalanceForAllCustomers.Name = "chkUpdateOpenBalanceForAllCustomers";
			this.chkUpdateOpenBalanceForAllCustomers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.chkUpdateOpenBalanceForAllCustomers.Size = new System.Drawing.Size(197, 27);
			this.chkUpdateOpenBalanceForAllCustomers.TabIndex = 0;
			this.chkUpdateOpenBalanceForAllCustomers.Text = "ปรับปรุงยอดของลูกค้าทั้งหมด";
			this.chkUpdateOpenBalanceForAllCustomers.UseVisualStyleBackColor = true;
			this.chkUpdateOpenBalanceForAllCustomers.CheckedChanged += new System.EventHandler(this.chkUpdateOpenBalanceForAllCustomers_CheckedChanged);
			// 
			// pnlLeft
			// 
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.dgvCustomers);
			this.pnlLeft.Controls.Add(this.panel1);
			this.pnlLeft.Controls.Add(this.panel2);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(3, 71);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(4);
			this.pnlLeft.Size = new System.Drawing.Size(309, 481);
			this.pnlLeft.TabIndex = 1;
			// 
			// dgvCustomers
			// 
			this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
			this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCustomers.Location = new System.Drawing.Point(4, 34);
			this.dgvCustomers.Name = "dgvCustomers";
			this.dgvCustomers.Size = new System.Drawing.Size(299, 413);
			this.dgvCustomers.TabIndex = 4;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbTotalCustomerFound);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 447);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(299, 28);
			this.panel1.TabIndex = 3;
			// 
			// lbTotalCustomerFound
			// 
			this.lbTotalCustomerFound.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalCustomerFound.Location = new System.Drawing.Point(194, 1);
			this.lbTotalCustomerFound.Name = "lbTotalCustomerFound";
			this.lbTotalCustomerFound.Size = new System.Drawing.Size(104, 26);
			this.lbTotalCustomerFound.TabIndex = 1;
			this.lbTotalCustomerFound.Text = "found :: ";
			this.lbTotalCustomerFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.cbxOpenYear);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.lbProgress);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(4, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(299, 30);
			this.panel2.TabIndex = 1;
			// 
			// cbxOpenYear
			// 
			this.cbxOpenYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxOpenYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOpenYear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxOpenYear.FormattingEnabled = true;
			this.cbxOpenYear.Location = new System.Drawing.Point(62, 2);
			this.cbxOpenYear.Name = "cbxOpenYear";
			this.cbxOpenYear.Size = new System.Drawing.Size(102, 25);
			this.cbxOpenYear.TabIndex = 9;
			this.cbxOpenYear.SelectedValueChanged += new System.EventHandler(this.cbxOpenYear_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 26);
			this.label1.TabIndex = 8;
			this.label1.Text = "ปีคำนวน :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbProgress
			// 
			this.lbProgress.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbProgress.Location = new System.Drawing.Point(213, 2);
			this.lbProgress.Name = "lbProgress";
			this.lbProgress.Size = new System.Drawing.Size(84, 26);
			this.lbProgress.TabIndex = 1;
			this.lbProgress.Text = "0%";
			this.lbProgress.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(312, 71);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 481);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// pnlRight
			// 
			this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRight.Controls.Add(this.pnlRightBottom);
			this.pnlRight.Controls.Add(this.splitter2);
			this.pnlRight.Controls.Add(this.pnlRightTop);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRight.Location = new System.Drawing.Point(318, 71);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(4);
			this.pnlRight.Size = new System.Drawing.Size(621, 481);
			this.pnlRight.TabIndex = 3;
			// 
			// pnlRightBottom
			// 
			this.pnlRightBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRightBottom.Controls.Add(this.dgvBalance);
			this.pnlRightBottom.Controls.Add(this.pnlUpdateCommand);
			this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRightBottom.Location = new System.Drawing.Point(4, 171);
			this.pnlRightBottom.Name = "pnlRightBottom";
			this.pnlRightBottom.Padding = new System.Windows.Forms.Padding(4);
			this.pnlRightBottom.Size = new System.Drawing.Size(611, 304);
			this.pnlRightBottom.TabIndex = 6;
			// 
			// dgvBalance
			// 
			this.dgvBalance.BackgroundColor = System.Drawing.Color.White;
			this.dgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBalance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBalance.Location = new System.Drawing.Point(4, 37);
			this.dgvBalance.Name = "dgvBalance";
			this.dgvBalance.Size = new System.Drawing.Size(601, 261);
			this.dgvBalance.TabIndex = 4;
			// 
			// pnlUpdateCommand
			// 
			this.pnlUpdateCommand.Controls.Add(this.btnUpdateOpenBalance);
			this.pnlUpdateCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlUpdateCommand.Location = new System.Drawing.Point(4, 4);
			this.pnlUpdateCommand.Name = "pnlUpdateCommand";
			this.pnlUpdateCommand.Padding = new System.Windows.Forms.Padding(1);
			this.pnlUpdateCommand.Size = new System.Drawing.Size(601, 33);
			this.pnlUpdateCommand.TabIndex = 3;
			// 
			// btnUpdateOpenBalance
			// 
			this.btnUpdateOpenBalance.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUpdateOpenBalance.Location = new System.Drawing.Point(1, 1);
			this.btnUpdateOpenBalance.Name = "btnUpdateOpenBalance";
			this.btnUpdateOpenBalance.Size = new System.Drawing.Size(177, 31);
			this.btnUpdateOpenBalance.TabIndex = 0;
			this.btnUpdateOpenBalance.Text = ":: Update Open Balance ::";
			this.btnUpdateOpenBalance.UseVisualStyleBackColor = true;
			this.btnUpdateOpenBalance.Click += new System.EventHandler(this.btnUpdateOpenBalance_Click);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(4, 165);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(611, 6);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			// 
			// pnlRightTop
			// 
			this.pnlRightTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRightTop.Controls.Add(this.panel5);
			this.pnlRightTop.Controls.Add(this.pnlProgress);
			this.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlRightTop.Location = new System.Drawing.Point(4, 4);
			this.pnlRightTop.Name = "pnlRightTop";
			this.pnlRightTop.Size = new System.Drawing.Size(611, 161);
			this.pnlRightTop.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(3);
			this.panel5.Size = new System.Drawing.Size(474, 159);
			this.panel5.TabIndex = 1;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txt);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(3, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(468, 153);
			this.panel7.TabIndex = 2;
			// 
			// txt
			// 
			this.txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txt.Location = new System.Drawing.Point(2, 35);
			this.txt.Multiline = true;
			this.txt.Name = "txt";
			this.txt.ReadOnly = true;
			this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txt.Size = new System.Drawing.Size(464, 96);
			this.txt.TabIndex = 2;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.btnOpenBalance);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(2, 2);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(464, 33);
			this.panel9.TabIndex = 1;
			// 
			// btnOpenBalance
			// 
			this.btnOpenBalance.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnOpenBalance.Location = new System.Drawing.Point(328, 1);
			this.btnOpenBalance.Name = "btnOpenBalance";
			this.btnOpenBalance.Size = new System.Drawing.Size(135, 31);
			this.btnOpenBalance.TabIndex = 9;
			this.btnOpenBalance.Text = "Cal Open Balance";
			this.btnOpenBalance.UseVisualStyleBackColor = true;
			this.btnOpenBalance.Click += new System.EventHandler(this.btnOpenBalance_Click);
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lbCalCount);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel8.Location = new System.Drawing.Point(2, 131);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(464, 20);
			this.panel8.TabIndex = 0;
			// 
			// lbCalCount
			// 
			this.lbCalCount.AutoSize = true;
			this.lbCalCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCalCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCalCount.Location = new System.Drawing.Point(1, 1);
			this.lbCalCount.Name = "lbCalCount";
			this.lbCalCount.Size = new System.Drawing.Size(66, 13);
			this.lbCalCount.TabIndex = 0;
			this.lbCalCount.Text = "Cal = 0 row";
			this.lbCalCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlProgress
			// 
			this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlProgress.Controls.Add(this.panel6);
			this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlProgress.Location = new System.Drawing.Point(474, 0);
			this.pnlProgress.Name = "pnlProgress";
			this.pnlProgress.Padding = new System.Windows.Forms.Padding(5);
			this.pnlProgress.Size = new System.Drawing.Size(135, 159);
			this.pnlProgress.TabIndex = 0;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.cpb);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(5, 5);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(123, 104);
			this.panel6.TabIndex = 1;
			// 
			// cpb
			// 
			this.cpb.BarWidth = 25;
			this.cpb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cpb.Dock = System.Windows.Forms.DockStyle.Left;
			this.cpb.Location = new System.Drawing.Point(2, 2);
			this.cpb.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cpb.Name = "cpb";
			this.cpb.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
			this.cpb.ProgressBarColor = System.Drawing.Color.Red;
			this.cpb.Size = new System.Drawing.Size(100, 100);
			this.cpb.TabIndex = 1;
			// 
			// MaterialCutBalance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(942, 555);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialCutBalance";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "MATERIAL CUT BALANCE";
			this.Load += new System.EventHandler(this.MaterialCutBalance_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.pnlRightBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).EndInit();
			this.pnlUpdateCommand.ResumeLayout(false);
			this.pnlRightTop.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.pnlProgress.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Panel pnlRightBottom;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pnlRightTop;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel pnlProgress;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbProgress;
		private System.Windows.Forms.Panel panel3;
		private OMControls.Controls.searchBox customerSearch;
		private System.Windows.Forms.CheckBox chkUpdateOpenBalanceForAllCustomers;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private OMControls.Controls.CircularProgressBar cpb;
		private System.Windows.Forms.Button btnLoadCustomer;
		private System.Windows.Forms.Label lbSelectedCustomer;
		private System.Windows.Forms.ComboBox cbxMatCategory;
		private System.Windows.Forms.Label lbMatCat;
		private System.Windows.Forms.CheckBox chkAllMatCategory;
		private System.Windows.Forms.Panel pnlUpdateCommand;
		private System.Windows.Forms.Button btnUpdateOpenBalance;
		private System.Windows.Forms.DataGridView dgvBalance;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txt;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lbCalCount;
		private System.Windows.Forms.Button btnOpenBalance;
		private System.Windows.Forms.DataGridView dgvCustomers;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTotalCustomerFound;
		private System.Windows.Forms.ComboBox cbxOpenYear;
		private System.Windows.Forms.Label label1;
	}
}