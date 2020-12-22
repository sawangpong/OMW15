namespace OMW15.Views.CastingView
{
	partial class SCBilling
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCBilling));
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgvBL = new System.Windows.Forms.DataGridView();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddBL = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditBL = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDeleteBL = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrint = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnInvoice = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.lbTotalAmount = new System.Windows.Forms.Label();
			this.lbCount = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBL)).BeginInit();
			this.ts.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(981, 37);
			this.pnlHeader.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "ใบวางบิล";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBody
			// 
			this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBody.Controls.Add(this.dgvBL);
			this.pnlBody.Controls.Add(this.ts);
			this.pnlBody.Controls.Add(this.pnlBottom);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 37);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(3);
			this.pnlBody.Size = new System.Drawing.Size(981, 468);
			this.pnlBody.TabIndex = 1;
			// 
			// dgvBL
			// 
			this.dgvBL.BackgroundColor = System.Drawing.Color.White;
			this.dgvBL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvBL.Location = new System.Drawing.Point(3, 48);
			this.dgvBL.Name = "dgvBL";
			this.dgvBL.Size = new System.Drawing.Size(973, 387);
			this.dgvBL.TabIndex = 2;
			this.dgvBL.VirtualMode = true;
			this.dgvBL.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBL_CellEnter);
			this.dgvBL.DoubleClick += new System.EventHandler(this.dgvBL_DoubleClick);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tsbtnAddBL,
            this.toolStripSeparator6,
            this.tsbtnEditBL,
            this.toolStripSeparator4,
            this.tsbtnDeleteBL,
            this.toolStripSeparator5,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnPrint,
            this.toolStripSeparator1,
            this.tsbtnInvoice,
            this.toolStripSeparator7});
			this.ts.Location = new System.Drawing.Point(3, 3);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(973, 45);
			this.ts.TabIndex = 1;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(50, 42);
			this.tsbtnClose.Text = "&ปิด";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnAddBL
			// 
			this.tsbtnAddBL.AutoSize = false;
			this.tsbtnAddBL.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddBL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddBL.Name = "tsbtnAddBL";
			this.tsbtnAddBL.Size = new System.Drawing.Size(75, 42);
			this.tsbtnAddBL.Text = "เพิ่ม";
			this.tsbtnAddBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAddBL.Click += new System.EventHandler(this.tsbtnAddBL_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnEditBL
			// 
			this.tsbtnEditBL.AutoSize = false;
			this.tsbtnEditBL.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditBL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditBL.Name = "tsbtnEditBL";
			this.tsbtnEditBL.Size = new System.Drawing.Size(75, 42);
			this.tsbtnEditBL.Text = "แก้ไข";
			this.tsbtnEditBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEditBL.Click += new System.EventHandler(this.tsbtnEditBL_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnDeleteBL
			// 
			this.tsbtnDeleteBL.AutoSize = false;
			this.tsbtnDeleteBL.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDeleteBL.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteBL.Name = "tsbtnDeleteBL";
			this.tsbtnDeleteBL.Size = new System.Drawing.Size(75, 42);
			this.tsbtnDeleteBL.Text = "ลบ";
			this.tsbtnDeleteBL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnDeleteBL.Click += new System.EventHandler(this.tsbtnDeleteBL_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(75, 42);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnPrint
			// 
			this.tsbtnPrint.AutoSize = false;
			this.tsbtnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrint.Name = "tsbtnPrint";
			this.tsbtnPrint.Size = new System.Drawing.Size(75, 42);
			this.tsbtnPrint.Text = "พิมพ์ใบวางบิล";
			this.tsbtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPrint.Click += new System.EventHandler(this.tsbtnPrint_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnInvoice
			// 
			this.tsbtnInvoice.AutoSize = false;
			this.tsbtnInvoice.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInvoice.Image")));
			this.tsbtnInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnInvoice.Name = "tsbtnInvoice";
			this.tsbtnInvoice.Size = new System.Drawing.Size(75, 42);
			this.tsbtnInvoice.Text = "เก็บเงิน";
			this.tsbtnInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnInvoice.Click += new System.EventHandler(this.tsbtnInvoice_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.lbTotalAmount);
			this.pnlBottom.Controls.Add(this.lbCount);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(3, 435);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBottom.Size = new System.Drawing.Size(973, 28);
			this.pnlBottom.TabIndex = 0;
			// 
			// lbTotalAmount
			// 
			this.lbTotalAmount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalAmount.Location = new System.Drawing.Point(735, 2);
			this.lbTotalAmount.Name = "lbTotalAmount";
			this.lbTotalAmount.Size = new System.Drawing.Size(236, 24);
			this.lbTotalAmount.TabIndex = 1;
			this.lbTotalAmount.Text = "Total amount : 0.00";
			this.lbTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.Location = new System.Drawing.Point(2, 2);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(153, 24);
			this.lbCount.TabIndex = 0;
			this.lbCount.Text = "found : 0 record(s)";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SCBilling
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(981, 505);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SCBilling";
			this.Text = "BILLING";
			this.Load += new System.EventHandler(this.SCBilling_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvBL)).EndInit();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgvBL;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnAddBL;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton tsbtnEditBL;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteBL;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Label lbTotalAmount;
		private System.Windows.Forms.ToolStripButton tsbtnPrint;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnInvoice;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
	}
}