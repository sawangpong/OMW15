namespace OMW15.Views.ServiceView
{
	partial class ServiceJobs
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceJobs));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.btnLoadData = new OMControls.OMFlatButton();
			this.cbxJobCat = new System.Windows.Forms.ComboBox();
			this.lbJobCAT = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxJobYear = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxJobStatus = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbStatus = new System.Windows.Forms.Label();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.lbSelectYear = new System.Windows.Forms.Label();
			this.lbSelectedOrderId = new System.Windows.Forms.Label();
			this.lbCount = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlBodyLeft = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtFixed = new System.Windows.Forms.TextBox();
			this.lbFixed = new System.Windows.Forms.Label();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtError = new System.Windows.Forms.TextBox();
			this.lbError = new System.Windows.Forms.Label();
			this.pnlBodyLeftTop = new System.Windows.Forms.Panel();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFind = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlBodyRight = new System.Windows.Forms.Panel();
			this.dgvByModel = new System.Windows.Forms.DataGridView();
			this.label4 = new System.Windows.Forms.Label();
			this.dgvByOrderCode = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlStatus.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlBodyLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlBodyLeftTop.SuspendLayout();
			this.ts.SuspendLayout();
			this.pnlBodyRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvByModel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvByOrderCode)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(90)))), ((int)(((byte)(101)))));
			this.pnlHeader.Controls.Add(this.btnLoadData);
			this.pnlHeader.Controls.Add(this.cbxJobCat);
			this.pnlHeader.Controls.Add(this.lbJobCAT);
			this.pnlHeader.Controls.Add(this.label3);
			this.pnlHeader.Controls.Add(this.cbxJobYear);
			this.pnlHeader.Controls.Add(this.label2);
			this.pnlHeader.Controls.Add(this.cbxJobStatus);
			this.pnlHeader.Controls.Add(this.btnClose);
			this.pnlHeader.Controls.Add(this.lbStatus);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(6);
			this.pnlHeader.Size = new System.Drawing.Size(941, 38);
			this.pnlHeader.TabIndex = 0;
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.FlatAppearance.BorderSize = 0;
			this.btnLoadData.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnLoadData.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnLoadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoadData.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadData.Image")));
			this.btnLoadData.Location = new System.Drawing.Point(729, 6);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(26, 26);
			this.btnLoadData.TabIndex = 10;
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// cbxJobCat
			// 
			this.cbxJobCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobCat.FormattingEnabled = true;
			this.cbxJobCat.Location = new System.Drawing.Point(540, 6);
			this.cbxJobCat.Name = "cbxJobCat";
			this.cbxJobCat.Size = new System.Drawing.Size(189, 25);
			this.cbxJobCat.TabIndex = 9;
			this.cbxJobCat.SelectionChangeCommitted += new System.EventHandler(this.cbxJobCat_SelectionChangeCommitted);
			// 
			// lbJobCAT
			// 
			this.lbJobCAT.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbJobCAT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobCAT.ForeColor = System.Drawing.Color.White;
			this.lbJobCAT.Location = new System.Drawing.Point(406, 6);
			this.lbJobCAT.Name = "lbJobCAT";
			this.lbJobCAT.Size = new System.Drawing.Size(134, 26);
			this.lbJobCAT.TabIndex = 8;
			this.lbJobCAT.Text = "รหัสใบงาน  [X] :";
			this.lbJobCAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(401, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(5, 26);
			this.label3.TabIndex = 6;
			// 
			// cbxJobYear
			// 
			this.cbxJobYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobYear.FormattingEnabled = true;
			this.cbxJobYear.Location = new System.Drawing.Point(313, 6);
			this.cbxJobYear.Name = "cbxJobYear";
			this.cbxJobYear.Size = new System.Drawing.Size(88, 25);
			this.cbxJobYear.TabIndex = 4;
			this.cbxJobYear.SelectedValueChanged += new System.EventHandler(this.cbxJobYear_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(210, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 26);
			this.label2.TabIndex = 3;
			this.label2.Text = "Select Year :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxJobStatus
			// 
			this.cbxJobStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxJobStatus.FormattingEnabled = true;
			this.cbxJobStatus.Location = new System.Drawing.Point(86, 6);
			this.cbxJobStatus.Name = "cbxJobStatus";
			this.cbxJobStatus.Size = new System.Drawing.Size(124, 25);
			this.cbxJobStatus.TabIndex = 2;
			this.cbxJobStatus.SelectedValueChanged += new System.EventHandler(this.cbxJobStatus_SelectedValueChanged);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(851, 6);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(84, 26);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbStatus
			// 
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStatus.ForeColor = System.Drawing.Color.White;
			this.lbStatus.Location = new System.Drawing.Point(6, 6);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(80, 26);
			this.lbStatus.TabIndex = 0;
			this.lbStatus.Text = "Status [X] :";
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlStatus
			// 
			this.pnlStatus.Controls.Add(this.lbSelectYear);
			this.pnlStatus.Controls.Add(this.lbSelectedOrderId);
			this.pnlStatus.Controls.Add(this.lbCount);
			this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlStatus.Location = new System.Drawing.Point(0, 557);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Padding = new System.Windows.Forms.Padding(4);
			this.pnlStatus.Size = new System.Drawing.Size(941, 30);
			this.pnlStatus.TabIndex = 1;
			// 
			// lbSelectYear
			// 
			this.lbSelectYear.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbSelectYear.Location = new System.Drawing.Point(855, 4);
			this.lbSelectYear.Name = "lbSelectYear";
			this.lbSelectYear.Size = new System.Drawing.Size(82, 22);
			this.lbSelectYear.TabIndex = 3;
			this.lbSelectYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbSelectedOrderId
			// 
			this.lbSelectedOrderId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedOrderId.Location = new System.Drawing.Point(106, 4);
			this.lbSelectedOrderId.Name = "lbSelectedOrderId";
			this.lbSelectedOrderId.Size = new System.Drawing.Size(153, 22);
			this.lbSelectedOrderId.TabIndex = 2;
			this.lbSelectedOrderId.Text = "ord-index :: ";
			this.lbSelectedOrderId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Location = new System.Drawing.Point(4, 4);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(102, 22);
			this.lbCount.TabIndex = 0;
			this.lbCount.Text = "found : 0";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlBodyLeft);
			this.pnlBody.Controls.Add(this.splitter1);
			this.pnlBody.Controls.Add(this.pnlBodyRight);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 38);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(941, 519);
			this.pnlBody.TabIndex = 2;
			// 
			// pnlBodyLeft
			// 
			this.pnlBodyLeft.Controls.Add(this.dgv);
			this.pnlBodyLeft.Controls.Add(this.splitter2);
			this.pnlBodyLeft.Controls.Add(this.panel1);
			this.pnlBodyLeft.Controls.Add(this.pnlBodyLeftTop);
			this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBodyLeft.Location = new System.Drawing.Point(2, 2);
			this.pnlBodyLeft.Name = "pnlBodyLeft";
			this.pnlBodyLeft.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBodyLeft.Size = new System.Drawing.Size(733, 515);
			this.pnlBodyLeft.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 49);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(729, 263);
			this.dgv.TabIndex = 17;
			this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(2, 312);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(729, 6);
			this.splitter2.TabIndex = 16;
			this.splitter2.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtFixed);
			this.panel1.Controls.Add(this.lbFixed);
			this.panel1.Controls.Add(this.splitter3);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 318);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(729, 195);
			this.panel1.TabIndex = 15;
			// 
			// txtFixed
			// 
			this.txtFixed.BackColor = System.Drawing.Color.White;
			this.txtFixed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtFixed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFixed.Location = new System.Drawing.Point(333, 34);
			this.txtFixed.Multiline = true;
			this.txtFixed.Name = "txtFixed";
			this.txtFixed.ReadOnly = true;
			this.txtFixed.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFixed.Size = new System.Drawing.Size(396, 161);
			this.txtFixed.TabIndex = 10;
			// 
			// lbFixed
			// 
			this.lbFixed.BackColor = System.Drawing.Color.ForestGreen;
			this.lbFixed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbFixed.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFixed.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFixed.ForeColor = System.Drawing.Color.White;
			this.lbFixed.Location = new System.Drawing.Point(333, 0);
			this.lbFixed.Name = "lbFixed";
			this.lbFixed.Size = new System.Drawing.Size(396, 34);
			this.lbFixed.TabIndex = 9;
			this.lbFixed.Text = "การแก้ไข";
			this.lbFixed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitter3
			// 
			this.splitter3.Location = new System.Drawing.Point(327, 0);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(6, 195);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtError);
			this.panel2.Controls.Add(this.lbError);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(327, 195);
			this.panel2.TabIndex = 0;
			// 
			// txtError
			// 
			this.txtError.BackColor = System.Drawing.Color.White;
			this.txtError.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtError.Location = new System.Drawing.Point(2, 36);
			this.txtError.Multiline = true;
			this.txtError.Name = "txtError";
			this.txtError.ReadOnly = true;
			this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtError.Size = new System.Drawing.Size(323, 157);
			this.txtError.TabIndex = 8;
			// 
			// lbError
			// 
			this.lbError.BackColor = System.Drawing.Color.Red;
			this.lbError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbError.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbError.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbError.ForeColor = System.Drawing.Color.White;
			this.lbError.Location = new System.Drawing.Point(2, 2);
			this.lbError.Name = "lbError";
			this.lbError.Size = new System.Drawing.Size(323, 34);
			this.lbError.TabIndex = 7;
			this.lbError.Text = "อาการที่เสีย";
			this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlBodyLeftTop
			// 
			this.pnlBodyLeftTop.Controls.Add(this.ts);
			this.pnlBodyLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBodyLeftTop.Location = new System.Drawing.Point(2, 2);
			this.pnlBodyLeftTop.Name = "pnlBodyLeftTop";
			this.pnlBodyLeftTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBodyLeftTop.Size = new System.Drawing.Size(729, 47);
			this.pnlBodyLeftTop.TabIndex = 12;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.toolStripSeparator1,
            this.tsbtnEdit,
            this.toolStripSeparator2,
            this.tsbtnDelete,
            this.toolStripSeparator3,
            this.tsbtnFind,
            this.toolStripSeparator4,
            this.tsbtnPrint,
            this.toolStripSeparator5,
            this.tsbtnRefresh,
            this.toolStripSeparator6});
			this.ts.Location = new System.Drawing.Point(2, 2);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(725, 43);
			this.ts.TabIndex = 0;
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(60, 40);
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(60, 40);
			this.tsbtnEdit.Text = "E&dit";
			this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.AutoSize = false;
			this.tsbtnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(60, 40);
			this.tsbtnDelete.Text = "De&lete";
			this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
			// 
			// tsbtnFind
			// 
			this.tsbtnFind.AutoSize = false;
			this.tsbtnFind.Image = global::OMW15.Properties.Resources.FindHS;
			this.tsbtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFind.Name = "tsbtnFind";
			this.tsbtnFind.Size = new System.Drawing.Size(60, 40);
			this.tsbtnFind.Text = "Find";
			this.tsbtnFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnFind.Click += new System.EventHandler(this.tsbtnFind_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
			// 
			// tsbtnPrint
			// 
			this.tsbtnPrint.AutoSize = false;
			this.tsbtnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrint.Name = "tsbtnPrint";
			this.tsbtnPrint.Size = new System.Drawing.Size(60, 40);
			this.tsbtnPrint.Text = "&Print";
			this.tsbtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(60, 40);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 43);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(735, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 515);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// pnlBodyRight
			// 
			this.pnlBodyRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBodyRight.Controls.Add(this.dgvByModel);
			this.pnlBodyRight.Controls.Add(this.label4);
			this.pnlBodyRight.Controls.Add(this.dgvByOrderCode);
			this.pnlBodyRight.Controls.Add(this.label1);
			this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlBodyRight.Location = new System.Drawing.Point(741, 2);
			this.pnlBodyRight.Name = "pnlBodyRight";
			this.pnlBodyRight.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBodyRight.Size = new System.Drawing.Size(198, 515);
			this.pnlBodyRight.TabIndex = 0;
			// 
			// dgvByModel
			// 
			this.dgvByModel.BackgroundColor = System.Drawing.Color.White;
			this.dgvByModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvByModel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvByModel.Location = new System.Drawing.Point(2, 294);
			this.dgvByModel.Name = "dgvByModel";
			this.dgvByModel.Size = new System.Drawing.Size(192, 217);
			this.dgvByModel.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(2, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(192, 46);
			this.label4.TabIndex = 10;
			this.label4.Text = "สรุปงาน (Active) by เครื่่องจักร";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvByOrderCode
			// 
			this.dgvByOrderCode.BackgroundColor = System.Drawing.Color.White;
			this.dgvByOrderCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvByOrderCode.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgvByOrderCode.Location = new System.Drawing.Point(2, 48);
			this.dgvByOrderCode.Name = "dgvByOrderCode";
			this.dgvByOrderCode.Size = new System.Drawing.Size(192, 200);
			this.dgvByOrderCode.TabIndex = 9;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 46);
			this.label1.TabIndex = 8;
			this.label1.Text = "สรุปงาน (Active) by รหัส";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ServiceJobs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(941, 587);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlStatus);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ServiceJobs";
			this.Text = "ServiceJobs";
			this.Load += new System.EventHandler(this.ServiceJobs_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlStatus.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			this.pnlBodyLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnlBodyLeftTop.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlBodyRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvByModel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvByOrderCode)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Panel pnlStatus;
		private System.Windows.Forms.ComboBox cbxJobStatus;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ComboBox cbxJobYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel pnlBodyRight;
		private System.Windows.Forms.Panel pnlBodyLeft;
		private System.Windows.Forms.Splitter splitter1;
		private OMControls.OMFlatButton btnLoadData;
		private System.Windows.Forms.ComboBox cbxJobCat;
		private System.Windows.Forms.Label lbJobCAT;
		private System.Windows.Forms.Panel pnlBodyLeftTop;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnFind;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnPrint;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Label lbSelectedOrderId;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Label lbSelectYear;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtFixed;
		private System.Windows.Forms.Label lbFixed;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtError;
		private System.Windows.Forms.Label lbError;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvByOrderCode;
		private System.Windows.Forms.DataGridView dgvByModel;
		private System.Windows.Forms.Label label4;
	}
}