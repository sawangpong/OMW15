namespace OMW15.Casting.CastingView
{
	partial class CastingSaleOrderList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingSaleOrderList));
			this.tsCSO = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.btnAddOrder = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCustomerName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbSpace = new System.Windows.Forms.Label();
			this.lbStatus = new System.Windows.Forms.Label();
			this.pnlLower = new System.Windows.Forms.Panel();
			this.lbSOCount = new System.Windows.Forms.Label();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnEditOrder = new System.Windows.Forms.Button();
			this.btnSearchSObyCustomer = new OMControls.OMFlatButton();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.tsmnuSOStatus = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsmnuActiveSO = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmnuCompleteSO = new System.Windows.Forms.ToolStripMenuItem();
			this.tsCSO.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.pnlLower.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// tsCSO
			// 
			this.tsCSO.AutoSize = false;
			this.tsCSO.Font = new System.Drawing.Font("Leelawadee", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tsCSO.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsCSO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.tsmnuSOStatus,
            this.toolStripSeparator3});
			this.tsCSO.Location = new System.Drawing.Point(0, 0);
			this.tsCSO.Name = "tsCSO";
			this.tsCSO.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.tsCSO.Size = new System.Drawing.Size(798, 43);
			this.tsCSO.TabIndex = 0;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Leelawadee", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(124, 40);
			this.toolStripLabel1.Text = "ใบส่งสินค้า : SO";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 43);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 43);
			// 
			// pnlTop
			// 
			this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTop.Controls.Add(this.btnRefresh);
			this.pnlTop.Controls.Add(this.btnEditOrder);
			this.pnlTop.Controls.Add(this.btnAddOrder);
			this.pnlTop.Controls.Add(this.label2);
			this.pnlTop.Controls.Add(this.txtCustomerName);
			this.pnlTop.Controls.Add(this.btnSearchSObyCustomer);
			this.pnlTop.Controls.Add(this.label1);
			this.pnlTop.Controls.Add(this.lbSpace);
			this.pnlTop.Controls.Add(this.lbStatus);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 43);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(3);
			this.pnlTop.Size = new System.Drawing.Size(798, 35);
			this.pnlTop.TabIndex = 1;
			// 
			// btnAddOrder
			// 
			this.btnAddOrder.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAddOrder.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnAddOrder.Location = new System.Drawing.Point(538, 3);
			this.btnAddOrder.Name = "btnAddOrder";
			this.btnAddOrder.Size = new System.Drawing.Size(31, 27);
			this.btnAddOrder.TabIndex = 7;
			this.btnAddOrder.Text = "+";
			this.toolTip1.SetToolTip(this.btnAddOrder, "Add Casting Sale Order");
			this.btnAddOrder.UseVisualStyleBackColor = true;
			this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(528, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 27);
			this.label2.TabIndex = 6;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCustomerName
			// 
			this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomerName.Enabled = false;
			this.txtCustomerName.Location = new System.Drawing.Point(228, 3);
			this.txtCustomerName.MaxLength = 150;
			this.txtCustomerName.Name = "txtCustomerName";
			this.txtCustomerName.Size = new System.Drawing.Size(300, 23);
			this.txtCustomerName.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(116, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 27);
			this.label1.TabIndex = 3;
			this.label1.Text = "ค้นหา (ลูกค้า) :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbSpace
			// 
			this.lbSpace.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSpace.Location = new System.Drawing.Point(106, 3);
			this.lbSpace.Name = "lbSpace";
			this.lbSpace.Size = new System.Drawing.Size(10, 27);
			this.lbSpace.TabIndex = 2;
			this.lbSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbStatus
			// 
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbStatus.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbStatus.Location = new System.Drawing.Point(3, 3);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(103, 27);
			this.lbStatus.TabIndex = 1;
			this.lbStatus.Text = "----";
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlLower
			// 
			this.pnlLower.Controls.Add(this.lbSOCount);
			this.pnlLower.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLower.Location = new System.Drawing.Point(0, 408);
			this.pnlLower.Name = "pnlLower";
			this.pnlLower.Padding = new System.Windows.Forms.Padding(3);
			this.pnlLower.Size = new System.Drawing.Size(798, 41);
			this.pnlLower.TabIndex = 2;
			// 
			// lbSOCount
			// 
			this.lbSOCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSOCount.Location = new System.Drawing.Point(3, 3);
			this.lbSOCount.Name = "lbSOCount";
			this.lbSOCount.Size = new System.Drawing.Size(127, 35);
			this.lbSOCount.TabIndex = 0;
			this.lbSOCount.Text = "X : 0";
			this.lbSOCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlDetail
			// 
			this.pnlDetail.Controls.Add(this.dgv);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetail.Location = new System.Drawing.Point(0, 78);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(3);
			this.pnlDetail.Size = new System.Drawing.Size(798, 330);
			this.pnlDetail.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 3);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(792, 324);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.Location = new System.Drawing.Point(600, 3);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(31, 27);
			this.btnRefresh.TabIndex = 9;
			this.toolTip1.SetToolTip(this.btnRefresh, "Re-load Casting Sale Order");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnEditOrder
			// 
			this.btnEditOrder.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEditOrder.Font = new System.Drawing.Font("Leelawadee", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnEditOrder.Image = global::OMW15.Properties.Resources.WRENCH;
			this.btnEditOrder.Location = new System.Drawing.Point(569, 3);
			this.btnEditOrder.Name = "btnEditOrder";
			this.btnEditOrder.Size = new System.Drawing.Size(31, 27);
			this.btnEditOrder.TabIndex = 8;
			this.btnEditOrder.Text = "+";
			this.toolTip1.SetToolTip(this.btnEditOrder, "Edit Casting Sale Order");
			this.btnEditOrder.UseVisualStyleBackColor = true;
			this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
			// 
			// btnSearchSObyCustomer
			// 
			this.btnSearchSObyCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearchSObyCustomer.FlatAppearance.BorderSize = 0;
			this.btnSearchSObyCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchSObyCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnSearchSObyCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchSObyCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchSObyCustomer.Image")));
			this.btnSearchSObyCustomer.Location = new System.Drawing.Point(201, 3);
			this.btnSearchSObyCustomer.Name = "btnSearchSObyCustomer";
			this.btnSearchSObyCustomer.Size = new System.Drawing.Size(27, 27);
			this.btnSearchSObyCustomer.Style = OMControls.ButtonImageStyle.Find;
			this.btnSearchSObyCustomer.TabIndex = 4;
			this.btnSearchSObyCustomer.UseVisualStyleBackColor = true;
			this.btnSearchSObyCustomer.Click += new System.EventHandler(this.btnSearchSObyCustomer_Click);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(59, 40);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// tsmnuSOStatus
			// 
			this.tsmnuSOStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuSOStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuActiveSO,
            this.tsmnuCompleteSO});
			this.tsmnuSOStatus.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuSOStatus.Image")));
			this.tsmnuSOStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsmnuSOStatus.Name = "tsmnuSOStatus";
			this.tsmnuSOStatus.Size = new System.Drawing.Size(59, 40);
			this.tsmnuSOStatus.Text = "สถานะ :";
			// 
			// tsmnuActiveSO
			// 
			this.tsmnuActiveSO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuActiveSO.Name = "tsmnuActiveSO";
			this.tsmnuActiveSO.Size = new System.Drawing.Size(151, 22);
			this.tsmnuActiveSO.Tag = "Active";
			this.tsmnuActiveSO.Text = "Active SO";
			this.tsmnuActiveSO.Click += new System.EventHandler(this.tsmnu_Click);
			// 
			// tsmnuCompleteSO
			// 
			this.tsmnuCompleteSO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuCompleteSO.Name = "tsmnuCompleteSO";
			this.tsmnuCompleteSO.Size = new System.Drawing.Size(151, 22);
			this.tsmnuCompleteSO.Tag = "Complete";
			this.tsmnuCompleteSO.Text = "Complete SO";
			this.tsmnuCompleteSO.Click += new System.EventHandler(this.tsmnu_Click);
			// 
			// CastingSaleOrderList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 449);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.pnlLower);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.tsCSO);
			this.Font = new System.Drawing.Font("Leelawadee", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Name = "CastingSaleOrderList";
			this.Text = "CASTING SALE ORDER LIST";
			this.Load += new System.EventHandler(this.CastingSaleOrderList_Load);
			this.tsCSO.ResumeLayout(false);
			this.tsCSO.PerformLayout();
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.pnlLower.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsCSO;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton tsmnuSOStatus;
		private System.Windows.Forms.ToolStripMenuItem tsmnuActiveSO;
		private System.Windows.Forms.ToolStripMenuItem tsmnuCompleteSO;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlLower;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label lbSOCount;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Label lbSpace;
		private OMControls.OMFlatButton btnSearchSObyCustomer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCustomerName;
		private System.Windows.Forms.Button btnAddOrder;
		private System.Windows.Forms.Button btnEditOrder;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnRefresh;
	}
}