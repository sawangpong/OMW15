namespace OMW15.Views.CustomerView
{
	partial class MasterCustomers
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterCustomers));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tslbCustomer = new System.Windows.Forms.ToolStripLabel();
			this.tsSepMain = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.tsSepClose = new System.Windows.Forms.ToolStripSeparator();
			this.tsmnuView = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmnuListAllCustomers = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmnuSearchCustomerByName = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmnuSearchCustomerByCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSepView = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFilter = new System.Windows.Forms.ToolStripButton();
			this.tsSepSearch = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditCustomer = new System.Windows.Forms.ToolStripButton();
			this.tsSepEdit = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFindCustomer = new System.Windows.Forms.ToolStripButton();
			this.tsSepFind = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnUpdateLocalCustomeDB = new System.Windows.Forms.ToolStripButton();
			this.tsSepLocalUpdate = new System.Windows.Forms.ToolStripSeparator();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.pnlUpdateProgress = new System.Windows.Forms.Panel();
			this.lbProgressStatus = new System.Windows.Forms.Label();
			this.pgb = new System.Windows.Forms.ProgressBar();
			this.lb = new System.Windows.Forms.Label();
			this.lbCustomerRecords = new System.Windows.Forms.Label();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.bgw = new System.ComponentModel.BackgroundWorker();
			this.ts.SuspendLayout();
			this.pnlStatus.SuspendLayout();
			this.pnlUpdateProgress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbCustomer,
            this.tsSepMain,
            this.tsbtnClose,
            this.tsSepClose,
            this.tsmnuView,
            this.tsSepView,
            this.tsbtnFilter,
            this.tsSepSearch,
            this.tsbtnEditCustomer,
            this.tsSepEdit,
            this.tsbtnFindCustomer,
            this.tsSepFind,
            this.tsbtnUpdateLocalCustomeDB,
            this.tsSepLocalUpdate});
			this.ts.Location = new System.Drawing.Point(3, 4);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(999, 40);
			this.ts.TabIndex = 0;
			// 
			// tslbCustomer
			// 
			this.tslbCustomer.Enabled = false;
			this.tslbCustomer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbCustomer.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.tslbCustomer.Name = "tslbCustomer";
			this.tslbCustomer.Size = new System.Drawing.Size(133, 37);
			this.tslbCustomer.Text = "รายชื่อลูกค้า (ERP)";
			// 
			// tsSepMain
			// 
			this.tsSepMain.Name = "tsSepMain";
			this.tsSepMain.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(65, 48);
			this.tsbtnClose.Text = "&ปิด";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// tsSepClose
			// 
			this.tsSepClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSepClose.Name = "tsSepClose";
			this.tsSepClose.Size = new System.Drawing.Size(6, 40);
			// 
			// tsmnuView
			// 
			this.tsmnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuListAllCustomers,
            this.toolStripMenuItem1,
            this.tsmnuSearchCustomerByCategory,
            this.tsmnuSearchCustomerByName});
			this.tsmnuView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuView.ForeColor = System.Drawing.SystemColors.ControlText;
			this.tsmnuView.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuView.Image")));
			this.tsmnuView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsmnuView.Name = "tsmnuView";
			this.tsmnuView.Size = new System.Drawing.Size(106, 37);
			this.tsmnuView.Text = "[รายชื่อลูกค้า]";
			// 
			// tsmnuListAllCustomers
			// 
			this.tsmnuListAllCustomers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuListAllCustomers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuListAllCustomers.Name = "tsmnuListAllCustomers";
			this.tsmnuListAllCustomers.Size = new System.Drawing.Size(188, 22);
			this.tsmnuListAllCustomers.Tag = "ALL_CUST";
			this.tsmnuListAllCustomers.Text = "แสดงทั้งหมด";
			this.tsmnuListAllCustomers.Click += new System.EventHandler(this.tsmnuCustomers_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
			// 
			// tsmnuSearchCustomerByName
			// 
			this.tsmnuSearchCustomerByName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuSearchCustomerByName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuSearchCustomerByName.Name = "tsmnuSearchCustomerByName";
			this.tsmnuSearchCustomerByName.Size = new System.Drawing.Size(188, 22);
			this.tsmnuSearchCustomerByName.Tag = "BY_NAME";
			this.tsmnuSearchCustomerByName.Text = "ค้นหาจากชื่อลูกค้า";
			this.tsmnuSearchCustomerByName.Click += new System.EventHandler(this.tsmnuCustomers_Click);
			// 
			// tsmnuSearchCustomerByCategory
			// 
			this.tsmnuSearchCustomerByCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuSearchCustomerByCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuSearchCustomerByCategory.Name = "tsmnuSearchCustomerByCategory";
			this.tsmnuSearchCustomerByCategory.Size = new System.Drawing.Size(188, 22);
			this.tsmnuSearchCustomerByCategory.Tag = "BY_CAT";
			this.tsmnuSearchCustomerByCategory.Text = "ค้นหาจากประเภทลูกค้า";
			// 
			// tsSepView
			// 
			this.tsSepView.Name = "tsSepView";
			this.tsSepView.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnFilter
			// 
			this.tsbtnFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnFilter.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFilter.Name = "tsbtnFilter";
			this.tsbtnFilter.Size = new System.Drawing.Size(57, 37);
			this.tsbtnFilter.Text = "ค้นหา";
			this.tsbtnFilter.Click += new System.EventHandler(this.tsbtnFilter_Click);
			// 
			// tsSepSearch
			// 
			this.tsSepSearch.Name = "tsSepSearch";
			this.tsSepSearch.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnEditCustomer
			// 
			this.tsbtnEditCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnEditCustomer.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditCustomer.Name = "tsbtnEditCustomer";
			this.tsbtnEditCustomer.Size = new System.Drawing.Size(83, 37);
			this.tsbtnEditCustomer.Text = "แก้ไขข้อมูล";
			this.tsbtnEditCustomer.Click += new System.EventHandler(this.tsbtnEditCustomer_Click);
			// 
			// tsSepEdit
			// 
			this.tsSepEdit.Name = "tsSepEdit";
			this.tsSepEdit.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnFindCustomer
			// 
			this.tsbtnFindCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnFindCustomer.Image = global::OMW15.Properties.Resources.FindHS;
			this.tsbtnFindCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFindCustomer.Name = "tsbtnFindCustomer";
			this.tsbtnFindCustomer.Size = new System.Drawing.Size(112, 37);
			this.tsbtnFindCustomer.Text = "Find Customer";
			this.tsbtnFindCustomer.Click += new System.EventHandler(this.tsbtnFindCustomer_Click);
			// 
			// tsSepFind
			// 
			this.tsSepFind.Name = "tsSepFind";
			this.tsSepFind.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnUpdateLocalCustomeDB
			// 
			this.tsbtnUpdateLocalCustomeDB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnUpdateLocalCustomeDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnUpdateLocalCustomeDB.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnUpdateLocalCustomeDB.Name = "tsbtnUpdateLocalCustomeDB";
			this.tsbtnUpdateLocalCustomeDB.Size = new System.Drawing.Size(106, 37);
			this.tsbtnUpdateLocalCustomeDB.Text = "ปรับปรุงข้อมูลลูกค้า";
			this.tsbtnUpdateLocalCustomeDB.Click += new System.EventHandler(this.tsbtnUpdateLocalCustomeDB_Click);
			// 
			// tsSepLocalUpdate
			// 
			this.tsSepLocalUpdate.Name = "tsSepLocalUpdate";
			this.tsSepLocalUpdate.Size = new System.Drawing.Size(6, 40);
			// 
			// pnlStatus
			// 
			this.pnlStatus.Controls.Add(this.pnlUpdateProgress);
			this.pnlStatus.Controls.Add(this.lb);
			this.pnlStatus.Controls.Add(this.lbCustomerRecords);
			this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlStatus.Location = new System.Drawing.Point(3, 475);
			this.pnlStatus.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Padding = new System.Windows.Forms.Padding(2);
			this.pnlStatus.Size = new System.Drawing.Size(999, 40);
			this.pnlStatus.TabIndex = 1;
			// 
			// pnlUpdateProgress
			// 
			this.pnlUpdateProgress.Controls.Add(this.lbProgressStatus);
			this.pnlUpdateProgress.Controls.Add(this.pgb);
			this.pnlUpdateProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlUpdateProgress.Location = new System.Drawing.Point(120, 2);
			this.pnlUpdateProgress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlUpdateProgress.Name = "pnlUpdateProgress";
			this.pnlUpdateProgress.Padding = new System.Windows.Forms.Padding(2);
			this.pnlUpdateProgress.Size = new System.Drawing.Size(712, 36);
			this.pnlUpdateProgress.TabIndex = 2;
			// 
			// lbProgressStatus
			// 
			this.lbProgressStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbProgressStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbProgressStatus.Location = new System.Drawing.Point(2, 17);
			this.lbProgressStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbProgressStatus.Name = "lbProgressStatus";
			this.lbProgressStatus.Size = new System.Drawing.Size(708, 17);
			this.lbProgressStatus.TabIndex = 1;
			this.lbProgressStatus.Text = "found : 0 record";
			this.lbProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pgb
			// 
			this.pgb.Dock = System.Windows.Forms.DockStyle.Top;
			this.pgb.Location = new System.Drawing.Point(2, 2);
			this.pgb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pgb.Name = "pgb";
			this.pgb.Size = new System.Drawing.Size(708, 15);
			this.pgb.TabIndex = 0;
			// 
			// lb
			// 
			this.lb.Dock = System.Windows.Forms.DockStyle.Right;
			this.lb.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb.Location = new System.Drawing.Point(832, 2);
			this.lb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(165, 36);
			this.lb.TabIndex = 1;
			this.lb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCustomerRecords
			// 
			this.lbCustomerRecords.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomerRecords.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustomerRecords.Location = new System.Drawing.Point(2, 2);
			this.lbCustomerRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCustomerRecords.Name = "lbCustomerRecords";
			this.lbCustomerRecords.Size = new System.Drawing.Size(118, 36);
			this.lbCustomerRecords.TabIndex = 0;
			this.lbCustomerRecords.Text = "found : 0 record";
			this.lbCustomerRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgv
			// 
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 44);
			this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
			dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.MenuText;
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle9;
			this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.MenuText;
			this.dgv.Size = new System.Drawing.Size(999, 431);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// bgw
			// 
			this.bgw.WorkerReportsProgress = true;
			this.bgw.WorkerSupportsCancellation = true;
			this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
			this.bgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
			// 
			// MasterCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1005, 519);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.pnlStatus);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "MasterCustomers";
			this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Text = "MASTER CUSTOMERS";
			this.Load += new System.EventHandler(this.MasterCustomers_Load);
			this.Shown += new System.EventHandler(this.MasterCustomers_Shown);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlStatus.ResumeLayout(false);
			this.pnlUpdateProgress.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel tslbCustomer;
		private System.Windows.Forms.ToolStripSeparator tsSepMain;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator tsSepClose;
		private System.Windows.Forms.Panel pnlStatus;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolStripDropDownButton tsmnuView;
		private System.Windows.Forms.ToolStripMenuItem tsmnuListAllCustomers;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tsmnuSearchCustomerByCategory;
		private System.Windows.Forms.ToolStripMenuItem tsmnuSearchCustomerByName;
		private System.Windows.Forms.ToolStripSeparator tsSepView;
		private System.Windows.Forms.ToolStripButton tsbtnUpdateLocalCustomeDB;
		private System.Windows.Forms.ToolStripSeparator tsSepEdit;
		private System.Windows.Forms.Label lbCustomerRecords;
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.ToolStripButton tsbtnFilter;
		private System.Windows.Forms.ToolStripButton tsbtnEditCustomer;
		private System.Windows.Forms.ToolStripSeparator tsSepLocalUpdate;
		private System.Windows.Forms.ToolStripSeparator tsSepSearch;
		private System.Windows.Forms.ToolStripButton tsbtnFindCustomer;
		private System.ComponentModel.BackgroundWorker bgw;
		private System.Windows.Forms.Panel pnlUpdateProgress;
		private System.Windows.Forms.Label lbProgressStatus;
		private System.Windows.Forms.ProgressBar pgb;
		private System.Windows.Forms.ToolStripSeparator tsSepFind;
	}
}