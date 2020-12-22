namespace OMW15.Views.Productions
{
	partial class PDTimeRecord
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDTimeRecord));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbWorkMonth = new System.Windows.Forms.Label();
			this.lbWorkYear = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.pnlDetailLeft = new System.Windows.Forms.Panel();
			this.pnlData = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbRecordSelected = new System.Windows.Forms.Label();
			this.lbRecordCount = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.pnlDetailRight = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnFindData = new OMControls.OMFlatButton();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxWorker = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbCode = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlList = new System.Windows.Forms.Panel();
			this.pnlChart = new System.Windows.Forms.Panel();
			this.workerTimeRecord1 = new OMW15.Views.Productions.ProductionUserControl.WorkerTimeRecord();
			this.pnlHeader.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			this.pnlDetailLeft.SuspendLayout();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel6.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlList.SuspendLayout();
			this.pnlChart.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lbWorkMonth);
			this.pnlHeader.Controls.Add(this.lbWorkYear);
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlHeader.Size = new System.Drawing.Size(1133, 48);
			this.pnlHeader.TabIndex = 0;
			// 
			// lbWorkMonth
			// 
			this.lbWorkMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWorkMonth.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWorkMonth.Location = new System.Drawing.Point(334, 4);
			this.lbWorkMonth.Name = "lbWorkMonth";
			this.lbWorkMonth.Size = new System.Drawing.Size(96, 40);
			this.lbWorkMonth.TabIndex = 9;
			this.lbWorkMonth.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbWorkYear
			// 
			this.lbWorkYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWorkYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWorkYear.Location = new System.Drawing.Point(238, 4);
			this.lbWorkYear.Name = "lbWorkYear";
			this.lbWorkYear.Size = new System.Drawing.Size(96, 40);
			this.lbWorkYear.TabIndex = 8;
			this.lbWorkYear.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "บันทึกเวลาทำงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlDetail
			// 
			this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDetail.Controls.Add(this.pnlDetailLeft);
			this.pnlDetail.Controls.Add(this.pnlDetailRight);
			this.pnlDetail.Controls.Add(this.panel1);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlDetail.Location = new System.Drawing.Point(0, 48);
			this.pnlDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlDetail.Size = new System.Drawing.Size(1133, 364);
			this.pnlDetail.TabIndex = 2;
			// 
			// pnlDetailLeft
			// 
			this.pnlDetailLeft.Controls.Add(this.pnlData);
			this.pnlDetailLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetailLeft.Location = new System.Drawing.Point(3, 40);
			this.pnlDetailLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlDetailLeft.Name = "pnlDetailLeft";
			this.pnlDetailLeft.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlDetailLeft.Size = new System.Drawing.Size(921, 318);
			this.pnlDetailLeft.TabIndex = 4;
			// 
			// pnlData
			// 
			this.pnlData.Controls.Add(this.dgv);
			this.pnlData.Controls.Add(this.panel6);
			this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlData.Location = new System.Drawing.Point(3, 4);
			this.pnlData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlData.Name = "pnlData";
			this.pnlData.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlData.Size = new System.Drawing.Size(915, 310);
			this.pnlData.TabIndex = 5;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 43);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
			this.dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.Size = new System.Drawing.Size(909, 263);
			this.dgv.TabIndex = 4;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.panel2);
			this.panel6.Controls.Add(this.btnDelete);
			this.panel6.Controls.Add(this.btnEdit);
			this.panel6.Controls.Add(this.btnAdd);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 4);
			this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(4);
			this.panel6.Size = new System.Drawing.Size(909, 39);
			this.panel6.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbRecordSelected);
			this.panel2.Controls.Add(this.lbRecordCount);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(752, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(151, 29);
			this.panel2.TabIndex = 13;
			// 
			// lbRecordSelected
			// 
			this.lbRecordSelected.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbRecordSelected.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRecordSelected.ForeColor = System.Drawing.Color.DimGray;
			this.lbRecordSelected.Location = new System.Drawing.Point(1, 1);
			this.lbRecordSelected.Name = "lbRecordSelected";
			this.lbRecordSelected.Size = new System.Drawing.Size(149, 16);
			this.lbRecordSelected.TabIndex = 14;
			this.lbRecordSelected.Text = "id : 0 ";
			this.lbRecordSelected.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbRecordCount
			// 
			this.lbRecordCount.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbRecordCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRecordCount.ForeColor = System.Drawing.Color.DimGray;
			this.lbRecordCount.Location = new System.Drawing.Point(1, 12);
			this.lbRecordCount.Name = "lbRecordCount";
			this.lbRecordCount.Size = new System.Drawing.Size(149, 16);
			this.lbRecordCount.TabIndex = 13;
			this.lbRecordCount.Text = "found : 0 row";
			this.lbRecordCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnDelete
			// 
			this.btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btnDelete.FlatAppearance.BorderSize = 0;
			this.btnDelete.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
			this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDelete.Location = new System.Drawing.Point(194, 4);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 3, 4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Padding = new System.Windows.Forms.Padding(1);
			this.btnDelete.Size = new System.Drawing.Size(95, 29);
			this.btnDelete.TabIndex = 11;
			this.btnDelete.Text = "ลบ";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEdit.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btnEdit.FlatAppearance.BorderSize = 0;
			this.btnEdit.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
			this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(99, 4);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(5, 4, 3, 4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Padding = new System.Windows.Forms.Padding(1);
			this.btnEdit.Size = new System.Drawing.Size(95, 29);
			this.btnEdit.TabIndex = 10;
			this.btnEdit.Text = "แก้ไข";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btnAdd.FlatAppearance.BorderSize = 0;
			this.btnAdd.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
			this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(4, 4);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 3, 4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Padding = new System.Windows.Forms.Padding(1);
			this.btnAdd.Size = new System.Drawing.Size(95, 29);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "เพิ่ม";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlDetailRight
			// 
			this.pnlDetailRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDetailRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlDetailRight.Location = new System.Drawing.Point(924, 40);
			this.pnlDetailRight.Name = "pnlDetailRight";
			this.pnlDetailRight.Size = new System.Drawing.Size(204, 318);
			this.pnlDetailRight.TabIndex = 3;
			this.pnlDetailRight.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnFindData);
			this.panel1.Controls.Add(this.cbxMonth);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbxYear);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbxWorker);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.lbCode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(3, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(1125, 36);
			this.panel1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CadetBlue;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(1025, 3);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Padding = new System.Windows.Forms.Padding(2);
			this.btnClose.Size = new System.Drawing.Size(97, 30);
			this.btnClose.TabIndex = 12;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnFindData
			// 
			this.btnFindData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFindData.FlatAppearance.BorderSize = 0;
			this.btnFindData.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnFindData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnFindData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFindData.Image = ((System.Drawing.Image)(resources.GetObject("btnFindData.Image")));
			this.btnFindData.Location = new System.Drawing.Point(768, 3);
			this.btnFindData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnFindData.Name = "btnFindData";
			this.btnFindData.Size = new System.Drawing.Size(30, 30);
			this.btnFindData.TabIndex = 11;
			this.btnFindData.UseVisualStyleBackColor = true;
			this.btnFindData.Click += new System.EventHandler(this.btnFindData_Click);
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(633, 3);
			this.cbxMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(135, 28);
			this.cbxMonth.TabIndex = 10;
			this.cbxMonth.SelectedValueChanged += new System.EventHandler(this.cbxMonth_SelectedValueChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(576, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 30);
			this.label4.TabIndex = 9;
			this.label4.Text = "เดือน :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(486, 3);
			this.cbxYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(90, 28);
			this.cbxYear.TabIndex = 8;
			this.cbxYear.SelectedValueChanged += new System.EventHandler(this.cbxYear_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(429, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 30);
			this.label3.TabIndex = 7;
			this.label3.Text = "ปี :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxWorker
			// 
			this.cbxWorker.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorker.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxWorker.Location = new System.Drawing.Point(142, 3);
			this.cbxWorker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbxWorker.Name = "cbxWorker";
			this.cbxWorker.Size = new System.Drawing.Size(287, 28);
			this.cbxWorker.TabIndex = 4;
			this.cbxWorker.SelectionChangeCommitted += new System.EventHandler(this.cbxWorker_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(51, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 30);
			this.label2.TabIndex = 3;
			this.label2.Text = "ผู้ปฏิบัติงาน :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCode
			// 
			this.lbCode.BackColor = System.Drawing.SystemColors.Control;
			this.lbCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCode.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCode.Location = new System.Drawing.Point(3, 3);
			this.lbCode.Name = "lbCode";
			this.lbCode.Size = new System.Drawing.Size(48, 30);
			this.lbCode.TabIndex = 2;
			this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 412);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(1133, 6);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// pnlList
			// 
			this.pnlList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlList.Controls.Add(this.pnlChart);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.Location = new System.Drawing.Point(0, 418);
			this.pnlList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlList.Name = "pnlList";
			this.pnlList.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlList.Size = new System.Drawing.Size(1133, 246);
			this.pnlList.TabIndex = 4;
			// 
			// pnlChart
			// 
			this.pnlChart.Controls.Add(this.workerTimeRecord1);
			this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlChart.Location = new System.Drawing.Point(3, 4);
			this.pnlChart.Name = "pnlChart";
			this.pnlChart.Size = new System.Drawing.Size(1125, 236);
			this.pnlChart.TabIndex = 0;
			// 
			// workerTimeRecord1
			// 
			this.workerTimeRecord1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.workerTimeRecord1.Location = new System.Drawing.Point(0, 0);
			this.workerTimeRecord1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.workerTimeRecord1.Name = "workerTimeRecord1";
			this.workerTimeRecord1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
			this.workerTimeRecord1.Size = new System.Drawing.Size(1125, 236);
			this.workerTimeRecord1.TabIndex = 0;
			this.workerTimeRecord1.WorkerCode = null;
			this.workerTimeRecord1.WorkerName = null;
			this.workerTimeRecord1.WorkMonth = 0;
			this.workerTimeRecord1.WorkYear = 0;
			// 
			// PDTimeRecord
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1133, 664);
			this.Controls.Add(this.pnlList);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "PDTimeRecord";
			this.Text = "บันทึกเวลาทำงาน";
			this.Load += new System.EventHandler(this.PDTimeRecord_Load);
			this.Resize += new System.EventHandler(this.PDTimeRecord_Resize);
			this.pnlHeader.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			this.pnlDetailLeft.ResumeLayout(false);
			this.pnlData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlList.ResumeLayout(false);
			this.pnlChart.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbCode;
		private System.Windows.Forms.ComboBox cbxWorker;
		private System.Windows.Forms.Label label2;
		private OMControls.OMFlatButton btnFindData;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlDetailRight;
		private System.Windows.Forms.Panel pnlDetailLeft;
		private System.Windows.Forms.Panel pnlData;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbRecordSelected;
		private System.Windows.Forms.Label lbRecordCount;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlList;
		private System.Windows.Forms.Panel pnlChart;
		private ProductionUserControl.WorkerTimeRecord workerTimeRecord1;
		private System.Windows.Forms.Label lbWorkMonth;
		private System.Windows.Forms.Label lbWorkYear;
	}
}