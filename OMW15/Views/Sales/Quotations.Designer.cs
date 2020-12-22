namespace OMW15.Views.Sales
{
	partial class Quotations
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
			this.st = new System.Windows.Forms.StatusStrip();
			this.stlbStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsmnuQTView = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuAllQT = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMasterQT = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuInboundQT = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuOutboundQT = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrintQT = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.st.SuspendLayout();
			this.ts.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// st
			// 
			this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlbStatus});
			this.st.Location = new System.Drawing.Point(2, 496);
			this.st.Name = "st";
			this.st.Size = new System.Drawing.Size(904, 22);
			this.st.TabIndex = 0;
			this.st.Text = "statusStrip1";
			// 
			// stlbStatus
			// 
			this.stlbStatus.Name = "stlbStatus";
			this.stlbStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuQTView,
            this.toolStripSeparator1,
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnAdd,
            this.toolStripSeparator4,
            this.tsbtnEdit,
            this.toolStripSeparator5,
            this.tsbtnPrintQT,
            this.toolStripSeparator6});
			this.ts.Location = new System.Drawing.Point(2, 2);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(904, 54);
			this.ts.TabIndex = 1;
			this.ts.Text = "toolStrip1";
			// 
			// tsmnuQTView
			// 
			this.tsmnuQTView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.tsmnuQTView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMasterQT,
            this.mnuSep1,
            this.mnuAllQT,
            this.mnuOutboundQT,
            this.mnuInboundQT});
			this.tsmnuQTView.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuQTView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsmnuQTView.Name = "tsmnuQTView";
			this.tsmnuQTView.Size = new System.Drawing.Size(86, 51);
			this.tsmnuQTView.Tag = "ALL";
			this.tsmnuQTView.Text = "Quotation :";
			this.tsmnuQTView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// mnuAllQT
			// 
			this.mnuAllQT.Name = "mnuAllQT";
			this.mnuAllQT.Size = new System.Drawing.Size(152, 22);
			this.mnuAllQT.Tag = "ALL";
			this.mnuAllQT.Text = "All Quotation";
			this.mnuAllQT.Click += new System.EventHandler(this.mnuQT_Click);
			// 
			// mnuSep1
			// 
			this.mnuSep1.Name = "mnuSep1";
			this.mnuSep1.Size = new System.Drawing.Size(149, 6);
			// 
			// mnuMasterQT
			// 
			this.mnuMasterQT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnuMasterQT.Name = "mnuMasterQT";
			this.mnuMasterQT.Size = new System.Drawing.Size(152, 22);
			this.mnuMasterQT.Tag = "MASTER";
			this.mnuMasterQT.Text = "Master";
			this.mnuMasterQT.Click += new System.EventHandler(this.mnuQT_Click);
			// 
			// mnuInboundQT
			// 
			this.mnuInboundQT.Name = "mnuInboundQT";
			this.mnuInboundQT.Size = new System.Drawing.Size(152, 22);
			this.mnuInboundQT.Tag = "LOCAL";
			this.mnuInboundQT.Text = "Local";
			this.mnuInboundQT.Click += new System.EventHandler(this.mnuQT_Click);
			// 
			// mnuOutboundQT
			// 
			this.mnuOutboundQT.Name = "mnuOutboundQT";
			this.mnuOutboundQT.Size = new System.Drawing.Size(152, 22);
			this.mnuOutboundQT.Tag = "INTER";
			this.mnuOutboundQT.Text = "International";
			this.mnuOutboundQT.Click += new System.EventHandler(this.mnuQT_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(55, 42);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(60, 42);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 54);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(60, 42);
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 54);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(60, 42);
			this.tsbtnEdit.Text = "&Edit";
			this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 54);
			// 
			// tsbtnPrintQT
			// 
			this.tsbtnPrintQT.AutoSize = false;
			this.tsbtnPrintQT.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrintQT.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrintQT.Name = "tsbtnPrintQT";
			this.tsbtnPrintQT.Size = new System.Drawing.Size(60, 51);
			this.tsbtnPrintQT.Text = "&Print";
			this.tsbtnPrintQT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPrintQT.Click += new System.EventHandler(this.tsbtnPrintQT_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 54);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.dgv);
			this.panel1.Controls.Add(this.pnlHeader);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(2, 56);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(904, 440);
			this.panel1.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 36);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(892, 397);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(5, 5);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(892, 31);
			this.pnlHeader.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Blue;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Quotation List ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Quotations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 520);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.st);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Quotations";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "QUOTATIONS";
			this.Load += new System.EventHandler(this.Quotations_Load);
			this.st.ResumeLayout(false);
			this.st.PerformLayout();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlHeader.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip st;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripStatusLabel stlbStatus;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripButton tsbtnPrintQT;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripDropDownButton tsmnuQTView;
		private System.Windows.Forms.ToolStripMenuItem mnuAllQT;
		private System.Windows.Forms.ToolStripSeparator mnuSep1;
		private System.Windows.Forms.ToolStripMenuItem mnuMasterQT;
		private System.Windows.Forms.ToolStripMenuItem mnuInboundQT;
		private System.Windows.Forms.ToolStripMenuItem mnuOutboundQT;
	}
}