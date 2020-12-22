namespace OMW15.Views.ServiceView
{
	partial class PMInfo
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMInfo));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label9 = new System.Windows.Forms.Label();
			this.lbContractStatus = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbMode = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbGuid = new System.Windows.Forms.Label();
			this.dtpPMContractDate = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.txtPMContractNo = new System.Windows.Forms.TextBox();
			this.chkAutoContractNo = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnRefresh = new OMControls.OMFlatButton();
			this.btnDeleteMC = new OMControls.OMFlatButton();
			this.btnEditMC = new OMControls.OMFlatButton();
			this.btnAddMC = new OMControls.OMFlatButton();
			this.panel5 = new System.Windows.Forms.Panel();
			this.pnlMCList = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.dgvMC = new System.Windows.Forms.DataGridView();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbItemGuid = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnCustomer = new OMControls.OMFlatButton();
			this.txtCustName = new System.Windows.Forms.TextBox();
			this.txtCustCode = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnlMCList.SuspendLayout();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMC)).BeginInit();
			this.panel8.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.lbContractStatus);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.lbMode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(829, 43);
			this.panel1.TabIndex = 0;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Right;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.ForeColor = System.Drawing.Color.LightBlue;
			this.label9.Location = new System.Drawing.Point(590, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(105, 41);
			this.label9.TabIndex = 11;
			this.label9.Text = "สถานะ :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbContractStatus
			// 
			this.lbContractStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.lbContractStatus.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbContractStatus.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbContractStatus.ForeColor = System.Drawing.Color.Yellow;
			this.lbContractStatus.Location = new System.Drawing.Point(695, 1);
			this.lbContractStatus.Name = "lbContractStatus";
			this.lbContractStatus.Size = new System.Drawing.Size(133, 41);
			this.lbContractStatus.TabIndex = 10;
			this.lbContractStatus.Text = "status";
			this.lbContractStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(116, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(346, 41);
			this.label1.TabIndex = 2;
			this.label1.Text = "สัญญาบริการบำรุงรักษาเครื่องจักร (PM)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMode
			// 
			this.lbMode.BackColor = System.Drawing.Color.Red;
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(1, 1);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(115, 41);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(5, 437);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(829, 48);
			this.panel2.TabIndex = 1;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(622, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(101, 38);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(723, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(101, 38);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbGuid);
			this.panel3.Controls.Add(this.dtpPMContractDate);
			this.panel3.Controls.Add(this.label7);
			this.panel3.Controls.Add(this.txtPMContractNo);
			this.panel3.Controls.Add(this.chkAutoContractNo);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 48);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(829, 28);
			this.panel3.TabIndex = 2;
			// 
			// lbGuid
			// 
			this.lbGuid.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbGuid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbGuid.Location = new System.Drawing.Point(577, 1);
			this.lbGuid.Name = "lbGuid";
			this.lbGuid.Size = new System.Drawing.Size(251, 26);
			this.lbGuid.TabIndex = 13;
			this.lbGuid.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// dtpPMContractDate
			// 
			this.dtpPMContractDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpPMContractDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPMContractDate.Location = new System.Drawing.Point(433, 1);
			this.dtpPMContractDate.Name = "dtpPMContractDate";
			this.dtpPMContractDate.Size = new System.Drawing.Size(109, 25);
			this.dtpPMContractDate.TabIndex = 12;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(321, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 26);
			this.label7.TabIndex = 11;
			this.label7.Text = "วันที่สัญญา :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPMContractNo
			// 
			this.txtPMContractNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtPMContractNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPMContractNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPMContractNo.Location = new System.Drawing.Point(200, 1);
			this.txtPMContractNo.MaxLength = 10;
			this.txtPMContractNo.Name = "txtPMContractNo";
			this.txtPMContractNo.Size = new System.Drawing.Size(121, 25);
			this.txtPMContractNo.TabIndex = 2;
			// 
			// chkAutoContractNo
			// 
			this.chkAutoContractNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkAutoContractNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkAutoContractNo.Location = new System.Drawing.Point(87, 1);
			this.chkAutoContractNo.Name = "chkAutoContractNo";
			this.chkAutoContractNo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.chkAutoContractNo.Size = new System.Drawing.Size(113, 26);
			this.chkAutoContractNo.TabIndex = 1;
			this.chkAutoContractNo.Text = "Auto number";
			this.chkAutoContractNo.UseVisualStyleBackColor = true;
			this.chkAutoContractNo.CheckedChanged += new System.EventHandler(this.chkAutoContractNo_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "เลขที่สัญญา:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.dtpEndDate);
			this.panel7.Controls.Add(this.label4);
			this.panel7.Controls.Add(this.dtpStartDate);
			this.panel7.Controls.Add(this.label3);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(5, 76);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(829, 28);
			this.panel7.TabIndex = 6;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEndDate.Location = new System.Drawing.Point(253, 1);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(109, 25);
			this.dtpEndDate.TabIndex = 10;
			this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(200, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 26);
			this.label4.TabIndex = 9;
			this.label4.Text = "สิ้นสุด:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpStartDate
			// 
			this.dtpStartDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpStartDate.Location = new System.Drawing.Point(87, 1);
			this.dtpStartDate.Name = "dtpStartDate";
			this.dtpStartDate.Size = new System.Drawing.Size(113, 25);
			this.dtpStartDate.TabIndex = 8;
			this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 26);
			this.label3.TabIndex = 7;
			this.label3.Text = "เริ่ม:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.FlatAppearance.BorderSize = 0;
			this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.Location = new System.Drawing.Point(288, 1);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(26, 26);
			this.btnRefresh.Style = OMControls.ButtonImageStyle.Refresh;
			this.btnRefresh.TabIndex = 11;
			this.toolTip1.SetToolTip(this.btnRefresh, "reload machine....");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnDeleteMC
			// 
			this.btnDeleteMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnDeleteMC.FlatAppearance.BorderSize = 0;
			this.btnDeleteMC.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnDeleteMC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnDeleteMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteMC.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteMC.Image")));
			this.btnDeleteMC.Location = new System.Drawing.Point(262, 1);
			this.btnDeleteMC.Name = "btnDeleteMC";
			this.btnDeleteMC.Size = new System.Drawing.Size(26, 26);
			this.btnDeleteMC.Style = OMControls.ButtonImageStyle.Delete;
			this.btnDeleteMC.TabIndex = 8;
			this.toolTip1.SetToolTip(this.btnDeleteMC, "ลบเครื่องจักร");
			this.btnDeleteMC.UseVisualStyleBackColor = true;
			this.btnDeleteMC.Click += new System.EventHandler(this.btnDeleteMC_Click);
			// 
			// btnEditMC
			// 
			this.btnEditMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEditMC.FlatAppearance.BorderSize = 0;
			this.btnEditMC.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnEditMC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnEditMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEditMC.Image = ((System.Drawing.Image)(resources.GetObject("btnEditMC.Image")));
			this.btnEditMC.Location = new System.Drawing.Point(236, 1);
			this.btnEditMC.Name = "btnEditMC";
			this.btnEditMC.Size = new System.Drawing.Size(26, 26);
			this.btnEditMC.Style = OMControls.ButtonImageStyle.Edit;
			this.btnEditMC.TabIndex = 7;
			this.toolTip1.SetToolTip(this.btnEditMC, "แก้ไข");
			this.btnEditMC.UseVisualStyleBackColor = true;
			this.btnEditMC.Click += new System.EventHandler(this.btnEditMC_Click);
			// 
			// btnAddMC
			// 
			this.btnAddMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAddMC.FlatAppearance.BorderSize = 0;
			this.btnAddMC.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnAddMC.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAddMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddMC.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMC.Image")));
			this.btnAddMC.Location = new System.Drawing.Point(210, 1);
			this.btnAddMC.Name = "btnAddMC";
			this.btnAddMC.Size = new System.Drawing.Size(26, 26);
			this.btnAddMC.Style = OMControls.ButtonImageStyle.Add;
			this.btnAddMC.TabIndex = 6;
			this.toolTip1.SetToolTip(this.btnAddMC, "เพิ่มเครื่องจักร");
			this.btnAddMC.UseVisualStyleBackColor = true;
			this.btnAddMC.Click += new System.EventHandler(this.btnAddMC_Click);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.pnlMCList);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(5, 132);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(829, 294);
			this.panel5.TabIndex = 8;
			// 
			// pnlMCList
			// 
			this.pnlMCList.Controls.Add(this.panel10);
			this.pnlMCList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMCList.Location = new System.Drawing.Point(5, 5);
			this.pnlMCList.Name = "pnlMCList";
			this.pnlMCList.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMCList.Size = new System.Drawing.Size(819, 284);
			this.pnlMCList.TabIndex = 7;
			// 
			// panel10
			// 
			this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel10.Controls.Add(this.dgvMC);
			this.panel10.Controls.Add(this.panel8);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel10.Location = new System.Drawing.Point(2, 2);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(4);
			this.panel10.Size = new System.Drawing.Size(815, 280);
			this.panel10.TabIndex = 12;
			// 
			// dgvMC
			// 
			this.dgvMC.BackgroundColor = System.Drawing.Color.White;
			this.dgvMC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMC.Location = new System.Drawing.Point(4, 32);
			this.dgvMC.Name = "dgvMC";
			this.dgvMC.Size = new System.Drawing.Size(805, 242);
			this.dgvMC.TabIndex = 11;
			this.dgvMC.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMC_CellEnter);
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.btnRefresh);
			this.panel8.Controls.Add(this.lbItemGuid);
			this.panel8.Controls.Add(this.btnDeleteMC);
			this.panel8.Controls.Add(this.btnEditMC);
			this.panel8.Controls.Add(this.btnAddMC);
			this.panel8.Controls.Add(this.label6);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(4, 4);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(805, 28);
			this.panel8.TabIndex = 10;
			// 
			// lbItemGuid
			// 
			this.lbItemGuid.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbItemGuid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemGuid.Location = new System.Drawing.Point(573, 1);
			this.lbItemGuid.Name = "lbItemGuid";
			this.lbItemGuid.Size = new System.Drawing.Size(231, 26);
			this.lbItemGuid.TabIndex = 10;
			this.lbItemGuid.Text = "0";
			this.lbItemGuid.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(209, 26);
			this.label6.TabIndex = 2;
			this.label6.Text = "รายการเครื่องจักรในสัญญา:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnCustomer);
			this.panel4.Controls.Add(this.txtCustName);
			this.panel4.Controls.Add(this.txtCustCode);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 104);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(829, 28);
			this.panel4.TabIndex = 7;
			// 
			// btnCustomer
			// 
			this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCustomer.FlatAppearance.BorderSize = 0;
			this.btnCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.Image")));
			this.btnCustomer.Location = new System.Drawing.Point(653, 1);
			this.btnCustomer.Name = "btnCustomer";
			this.btnCustomer.Size = new System.Drawing.Size(26, 26);
			this.btnCustomer.TabIndex = 8;
			this.btnCustomer.UseVisualStyleBackColor = true;
			this.btnCustomer.Visible = false;
			// 
			// txtCustName
			// 
			this.txtCustName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustName.Location = new System.Drawing.Point(200, 1);
			this.txtCustName.MaxLength = 10;
			this.txtCustName.Name = "txtCustName";
			this.txtCustName.ReadOnly = true;
			this.txtCustName.Size = new System.Drawing.Size(453, 25);
			this.txtCustName.TabIndex = 7;
			// 
			// txtCustCode
			// 
			this.txtCustCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustCode.Location = new System.Drawing.Point(87, 1);
			this.txtCustCode.MaxLength = 10;
			this.txtCustCode.Name = "txtCustCode";
			this.txtCustCode.ReadOnly = true;
			this.txtCustCode.Size = new System.Drawing.Size(113, 25);
			this.txtCustCode.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 26);
			this.label5.TabIndex = 1;
			this.label5.Text = "ชื่อคู่สัญญา:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// PMInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(839, 490);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PMInfo";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "PM Information";
			this.Load += new System.EventHandler(this.PMInfo_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.pnlMCList.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMC)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtPMContractNo;
		private System.Windows.Forms.CheckBox chkAutoContractNo;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.DateTimePicker dtpPMContractDate;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpStartDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel pnlMCList;
		private System.Windows.Forms.Panel panel4;
		private OMControls.OMFlatButton btnCustomer;
		private System.Windows.Forms.TextBox txtCustName;
		private System.Windows.Forms.TextBox txtCustCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.DataGridView dgvMC;
		private System.Windows.Forms.Panel panel8;
		private OMControls.OMFlatButton btnRefresh;
		private System.Windows.Forms.Label lbItemGuid;
		private OMControls.OMFlatButton btnDeleteMC;
		private OMControls.OMFlatButton btnEditMC;
		private OMControls.OMFlatButton btnAddMC;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbGuid;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbContractStatus;
	}
}