namespace OMW15.Views.WarehouseView
{
	partial class Warehouse
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Warehouse));
			this.ms = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStockMaster = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStockMonitor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuIssueFOCParts = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCascade = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHorizontal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVertical = new System.Windows.Forms.ToolStripMenuItem();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnStockMaster = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnStockMonitor = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ss = new System.Windows.Forms.StatusStrip();
			this.ms.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// ms
			// 
			this.ms.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuClose,
            this.mnuReport,
            this.mnuWindow});
			this.ms.Location = new System.Drawing.Point(0, 0);
			this.ms.MdiWindowListItem = this.mnuWindow;
			this.ms.Name = "ms";
			this.ms.Size = new System.Drawing.Size(892, 25);
			this.ms.TabIndex = 1;
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStockMaster,
            this.toolStripMenuItem1});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(39, 21);
			this.mnuFile.Text = "&File";
			// 
			// mnuStockMaster
			// 
			this.mnuStockMaster.Name = "mnuStockMaster";
			this.mnuStockMaster.Size = new System.Drawing.Size(152, 22);
			this.mnuStockMaster.Text = "Stock &Master";
			this.mnuStockMaster.Click += new System.EventHandler(this.mnuStockMaster_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// mnuClose
			// 
			this.mnuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.mnuClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.mnuClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.Size = new System.Drawing.Size(68, 21);
			this.mnuClose.Text = "&Close";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// mnuReport
			// 
			this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStockMonitor,
            this.toolStripMenuItem2,
            this.mnuIssueFOCParts});
			this.mnuReport.Name = "mnuReport";
			this.mnuReport.Size = new System.Drawing.Size(60, 21);
			this.mnuReport.Text = "&Report";
			// 
			// mnuStockMonitor
			// 
			this.mnuStockMonitor.Name = "mnuStockMonitor";
			this.mnuStockMonitor.Size = new System.Drawing.Size(235, 22);
			this.mnuStockMonitor.Text = "Stock Monitor";
			this.mnuStockMonitor.Click += new System.EventHandler(this.mnuStockMonitor_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
			// 
			// mnuIssueFOCParts
			// 
			this.mnuIssueFOCParts.Name = "mnuIssueFOCParts";
			this.mnuIssueFOCParts.Size = new System.Drawing.Size(235, 22);
			this.mnuIssueFOCParts.Text = "รายงานจ่ายอะไหล่โดยไม่คิดมูลค่า";
			this.mnuIssueFOCParts.Click += new System.EventHandler(this.mnuIssueFOCParts_Click);
			// 
			// mnuWindow
			// 
			this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascade,
            this.mnuHorizontal,
            this.mnuVertical});
			this.mnuWindow.Name = "mnuWindow";
			this.mnuWindow.Size = new System.Drawing.Size(67, 21);
			this.mnuWindow.Text = "Window";
			// 
			// mnuCascade
			// 
			this.mnuCascade.Name = "mnuCascade";
			this.mnuCascade.Size = new System.Drawing.Size(187, 22);
			this.mnuCascade.Text = "Arrange Cadcade";
			this.mnuCascade.Click += new System.EventHandler(this.mnuCascade_Click);
			// 
			// mnuHorizontal
			// 
			this.mnuHorizontal.Name = "mnuHorizontal";
			this.mnuHorizontal.Size = new System.Drawing.Size(187, 22);
			this.mnuHorizontal.Text = "Arrange Horizontal";
			this.mnuHorizontal.Click += new System.EventHandler(this.mnuHorizontal_Click);
			// 
			// mnuVertical
			// 
			this.mnuVertical.Name = "mnuVertical";
			this.mnuVertical.Size = new System.Drawing.Size(187, 22);
			this.mnuVertical.Text = "Arrange Vertical";
			this.mnuVertical.Click += new System.EventHandler(this.mnuVertical_Click);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnStockMaster,
            this.toolStripSeparator1,
            this.tsbtnStockMonitor,
            this.toolStripSeparator2});
			this.ts.Location = new System.Drawing.Point(0, 25);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(892, 45);
			this.ts.TabIndex = 2;
			// 
			// tsbtnStockMaster
			// 
			this.tsbtnStockMaster.AutoSize = false;
			this.tsbtnStockMaster.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStockMaster.Image")));
			this.tsbtnStockMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnStockMaster.Name = "tsbtnStockMaster";
			this.tsbtnStockMaster.Size = new System.Drawing.Size(130, 45);
			this.tsbtnStockMaster.Text = "Item Master (ERP)";
			this.tsbtnStockMaster.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnStockMaster.Click += new System.EventHandler(this.tsbtnStockMaster_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnStockMonitor
			// 
			this.tsbtnStockMonitor.AutoSize = false;
			this.tsbtnStockMonitor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStockMonitor.Image")));
			this.tsbtnStockMonitor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnStockMonitor.Name = "tsbtnStockMonitor";
			this.tsbtnStockMonitor.Size = new System.Drawing.Size(130, 42);
			this.tsbtnStockMonitor.Text = "Stock Monitor (ERP)";
			this.tsbtnStockMonitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnStockMonitor.Click += new System.EventHandler(this.tsbtnStockMonitor_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// ss
			// 
			this.ss.Location = new System.Drawing.Point(0, 494);
			this.ss.Name = "ss";
			this.ss.Size = new System.Drawing.Size(892, 22);
			this.ss.TabIndex = 4;
			// 
			// Warehouse
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(892, 516);
			this.Controls.Add(this.ss);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.ms);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.ms;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Warehouse";
			this.Text = "Warehouse";
			this.Load += new System.EventHandler(this.Warehouse_Load);
			this.ms.ResumeLayout(false);
			this.ms.PerformLayout();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip ms;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuStockMaster;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnStockMaster;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuClose;
		private System.Windows.Forms.StatusStrip ss;
		private System.Windows.Forms.ToolStripMenuItem mnuReport;
		private System.Windows.Forms.ToolStripMenuItem mnuStockMonitor;
		private System.Windows.Forms.ToolStripButton tsbtnStockMonitor;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuWindow;
		private System.Windows.Forms.ToolStripMenuItem mnuCascade;
		private System.Windows.Forms.ToolStripMenuItem mnuVertical;
		private System.Windows.Forms.ToolStripMenuItem mnuHorizontal;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuIssueFOCParts;
	}
}