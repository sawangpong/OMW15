namespace OMW15.Views.Sales
{
	partial class SaleWorks
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleWorks));
			this.mnu = new System.Windows.Forms.MenuStrip();
			this.mnuSales = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaleContact = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSalePerson = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmnuSTDPriceList = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMachinePriceList = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuQT = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPI = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSellInv = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuPackingList = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMachineRecords = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaleMachines = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaleReport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSaleSummary = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProductList = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCascadeWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVerticalWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHorizontalWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.st = new System.Windows.Forms.StatusStrip();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnSaleContact = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnQT = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPI = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPriceList = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMCRecord = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnu.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnu
			// 
			this.mnu.AutoSize = false;
			this.mnu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSales,
            this.mnuSaleReport,
            this.mnuSetting,
            this.mnuWindows,
            this.mnuClose});
			this.mnu.Location = new System.Drawing.Point(1, 1);
			this.mnu.MdiWindowListItem = this.mnuWindows;
			this.mnu.Name = "mnu";
			this.mnu.Size = new System.Drawing.Size(967, 35);
			this.mnu.TabIndex = 1;
			// 
			// mnuSales
			// 
			this.mnuSales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaleContact,
            this.mnuSalePerson,
            this.toolStripMenuItem1,
            this.tsmnuSTDPriceList,
            this.mnuMachinePriceList,
            this.toolStripMenuItem2,
            this.mnuQT,
            this.mnuPI,
            this.mnuSellInv,
            this.mnuPackingList,
            this.toolStripMenuItem4,
            this.mnuMachineRecords,
            this.mnuSaleMachines});
			this.mnuSales.Name = "mnuSales";
			this.mnuSales.Size = new System.Drawing.Size(60, 31);
			this.mnuSales.Text = "งานขาย";
			// 
			// mnuSaleContact
			// 
			this.mnuSaleContact.Name = "mnuSaleContact";
			this.mnuSaleContact.Size = new System.Drawing.Size(258, 22);
			this.mnuSaleContact.Text = "รายชื่อติดต่อ (Contact)";
			this.mnuSaleContact.Click += new System.EventHandler(this.mnuSaleContact_Click);
			// 
			// mnuSalePerson
			// 
			this.mnuSalePerson.Name = "mnuSalePerson";
			this.mnuSalePerson.Size = new System.Drawing.Size(258, 22);
			this.mnuSalePerson.Text = "พนักงานขาย";
			this.mnuSalePerson.Click += new System.EventHandler(this.mnuSalePerson_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(255, 6);
			// 
			// tsmnuSTDPriceList
			// 
			this.tsmnuSTDPriceList.Name = "tsmnuSTDPriceList";
			this.tsmnuSTDPriceList.Size = new System.Drawing.Size(258, 22);
			this.tsmnuSTDPriceList.Text = "ราคามาตรฐาน (ERP)";
			this.tsmnuSTDPriceList.Click += new System.EventHandler(this.mnuSTDPriceList_Click);
			// 
			// mnuMachinePriceList
			// 
			this.mnuMachinePriceList.Name = "mnuMachinePriceList";
			this.mnuMachinePriceList.Size = new System.Drawing.Size(258, 22);
			this.mnuMachinePriceList.Text = "ราคาขายสินค้า (เครื่องจักร + อะไหล่)";
			this.mnuMachinePriceList.Click += new System.EventHandler(this.mnuMachinePriceList_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(255, 6);
			// 
			// mnuQT
			// 
			this.mnuQT.Name = "mnuQT";
			this.mnuQT.Size = new System.Drawing.Size(258, 22);
			this.mnuQT.Text = "ใบเสนอราคา";
			this.mnuQT.Click += new System.EventHandler(this.mnuQT_Click);
			// 
			// mnuPI
			// 
			this.mnuPI.Name = "mnuPI";
			this.mnuPI.Size = new System.Drawing.Size(258, 22);
			this.mnuPI.Text = "Proforma Invoice";
			this.mnuPI.Click += new System.EventHandler(this.mnuPI_Click);
			// 
			// mnuSellInv
			// 
			this.mnuSellInv.Name = "mnuSellInv";
			this.mnuSellInv.Size = new System.Drawing.Size(258, 22);
			this.mnuSellInv.Text = "Sell Invoice";
			// 
			// mnuPackingList
			// 
			this.mnuPackingList.Name = "mnuPackingList";
			this.mnuPackingList.Size = new System.Drawing.Size(258, 22);
			this.mnuPackingList.Text = "Packing List";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(255, 6);
			// 
			// mnuMachineRecords
			// 
			this.mnuMachineRecords.Name = "mnuMachineRecords";
			this.mnuMachineRecords.Size = new System.Drawing.Size(258, 22);
			this.mnuMachineRecords.Text = "บันทึกเครื่องจักร";
			// 
			// mnuSaleMachines
			// 
			this.mnuSaleMachines.Name = "mnuSaleMachines";
			this.mnuSaleMachines.Size = new System.Drawing.Size(258, 22);
			this.mnuSaleMachines.Text = "สรุปยอดขายเครื่องจักร";
			this.mnuSaleMachines.Click += new System.EventHandler(this.mnuSaleMachines_Click);
			// 
			// mnuSaleReport
			// 
			this.mnuSaleReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSaleSummary});
			this.mnuSaleReport.Name = "mnuSaleReport";
			this.mnuSaleReport.Size = new System.Drawing.Size(58, 31);
			this.mnuSaleReport.Text = "รายงาน";
			// 
			// mnuSaleSummary
			// 
			this.mnuSaleSummary.Name = "mnuSaleSummary";
			this.mnuSaleSummary.Size = new System.Drawing.Size(180, 22);
			this.mnuSaleSummary.Text = "สรุปยอดขายตามกลุ่ม";
			this.mnuSaleSummary.Click += new System.EventHandler(this.mnuSaleSummary_Click);
			// 
			// mnuSetting
			// 
			this.mnuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductList});
			this.mnuSetting.Name = "mnuSetting";
			this.mnuSetting.Size = new System.Drawing.Size(45, 31);
			this.mnuSetting.Text = "ตั้งค่า";
			// 
			// mnuProductList
			// 
			this.mnuProductList.Name = "mnuProductList";
			this.mnuProductList.Size = new System.Drawing.Size(142, 22);
			this.mnuProductList.Text = "รายการสินค้า";
			this.mnuProductList.Click += new System.EventHandler(this.mnuProductList_Click);
			// 
			// mnuWindows
			// 
			this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascadeWindows,
            this.mnuVerticalWindows,
            this.mnuHorizontalWindows});
			this.mnuWindows.Name = "mnuWindows";
			this.mnuWindows.Size = new System.Drawing.Size(60, 31);
			this.mnuWindows.Text = "หน้าต่าง";
			// 
			// mnuCascadeWindows
			// 
			this.mnuCascadeWindows.Name = "mnuCascadeWindows";
			this.mnuCascadeWindows.Size = new System.Drawing.Size(193, 22);
			this.mnuCascadeWindows.Text = "Cascade Windows";
			this.mnuCascadeWindows.Click += new System.EventHandler(this.mnuCascadeWindows_Click);
			// 
			// mnuVerticalWindows
			// 
			this.mnuVerticalWindows.Name = "mnuVerticalWindows";
			this.mnuVerticalWindows.Size = new System.Drawing.Size(193, 22);
			this.mnuVerticalWindows.Text = "Vertical Windows";
			this.mnuVerticalWindows.Click += new System.EventHandler(this.mnuVerticalWindows_Click);
			// 
			// mnuHorizontalWindows
			// 
			this.mnuHorizontalWindows.Name = "mnuHorizontalWindows";
			this.mnuHorizontalWindows.Size = new System.Drawing.Size(193, 22);
			this.mnuHorizontalWindows.Text = "Horizontal Windows";
			this.mnuHorizontalWindows.Click += new System.EventHandler(this.mnuHorizontalWindows_Click);
			// 
			// mnuClose
			// 
			this.mnuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.mnuClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.mnuClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.Size = new System.Drawing.Size(92, 31);
			this.mnuClose.Text = "ปิดโปรแกรม";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// st
			// 
			this.st.Location = new System.Drawing.Point(1, 540);
			this.st.Name = "st";
			this.st.Size = new System.Drawing.Size(967, 22);
			this.st.TabIndex = 3;
			this.st.Text = "statusStrip1";
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSaleContact,
            this.toolStripSeparator1,
            this.tsbtnQT,
            this.toolStripSeparator2,
            this.tsbtnPI,
            this.toolStripSeparator3,
            this.tsbtnPriceList,
            this.toolStripSeparator4,
            this.tsMCRecord,
            this.toolStripSeparator5});
			this.ts.Location = new System.Drawing.Point(1, 36);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(967, 45);
			this.ts.TabIndex = 4;
			this.ts.Text = "toolStrip1";
			// 
			// tsbtnSaleContact
			// 
			this.tsbtnSaleContact.AutoSize = false;
			this.tsbtnSaleContact.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaleContact.Image")));
			this.tsbtnSaleContact.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSaleContact.Name = "tsbtnSaleContact";
			this.tsbtnSaleContact.Size = new System.Drawing.Size(80, 39);
			this.tsbtnSaleContact.Text = "Sale Contact";
			this.tsbtnSaleContact.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnSaleContact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnSaleContact.Click += new System.EventHandler(this.tsbtnSaleContact_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnQT
			// 
			this.tsbtnQT.AutoSize = false;
			this.tsbtnQT.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnQT.Image")));
			this.tsbtnQT.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnQT.Name = "tsbtnQT";
			this.tsbtnQT.Size = new System.Drawing.Size(80, 39);
			this.tsbtnQT.Text = "ใบเสนอราคา";
			this.tsbtnQT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnQT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnQT.Click += new System.EventHandler(this.tsbtnQT_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnPI
			// 
			this.tsbtnPI.AutoSize = false;
			this.tsbtnPI.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPI.Image")));
			this.tsbtnPI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPI.Name = "tsbtnPI";
			this.tsbtnPI.Size = new System.Drawing.Size(100, 39);
			this.tsbtnPI.Text = "Proforma Inv.";
			this.tsbtnPI.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnPI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnPriceList
			// 
			this.tsbtnPriceList.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPriceList.Image")));
			this.tsbtnPriceList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPriceList.Name = "tsbtnPriceList";
			this.tsbtnPriceList.Size = new System.Drawing.Size(86, 42);
			this.tsbtnPriceList.Text = "ราคาขายสินค้า";
			this.tsbtnPriceList.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.tsbtnPriceList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnPriceList.Click += new System.EventHandler(this.tsbtnPriceList_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			// 
			// tsMCRecord
			// 
			this.tsMCRecord.AutoSize = false;
			this.tsMCRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsMCRecord.Image")));
			this.tsMCRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsMCRecord.Name = "tsMCRecord";
			this.tsMCRecord.Size = new System.Drawing.Size(90, 42);
			this.tsMCRecord.Text = "M/C Record";
			this.tsMCRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsMCRecord.Click += new System.EventHandler(this.tsMCRecord_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
			// 
			// SaleWorks
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(969, 563);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.st);
			this.Controls.Add(this.mnu);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mnu;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleWorks";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.Tag = "20000";
			this.Text = "SALE DEPT";
			this.Load += new System.EventHandler(this.SaleWorks_Load);
			this.mnu.ResumeLayout(false);
			this.mnu.PerformLayout();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnu;
		private System.Windows.Forms.StatusStrip st;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripMenuItem mnuSales;
		private System.Windows.Forms.ToolStripMenuItem mnuSaleContact;
		private System.Windows.Forms.ToolStripMenuItem mnuSalePerson;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuMachinePriceList;
		private System.Windows.Forms.ToolStripMenuItem mnuMachineRecords;
		private System.Windows.Forms.ToolStripMenuItem mnuQT;
		private System.Windows.Forms.ToolStripMenuItem mnuPI;
		private System.Windows.Forms.ToolStripMenuItem mnuSellInv;
		private System.Windows.Forms.ToolStripMenuItem mnuPackingList;
		private System.Windows.Forms.ToolStripMenuItem mnuSetting;
		private System.Windows.Forms.ToolStripMenuItem mnuWindows;
		private System.Windows.Forms.ToolStripMenuItem mnuClose;
		private System.Windows.Forms.ToolStripButton tsbtnSaleContact;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnQT;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnPI;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem mnuCascadeWindows;
		private System.Windows.Forms.ToolStripMenuItem mnuVerticalWindows;
		private System.Windows.Forms.ToolStripMenuItem mnuHorizontalWindows;
		private System.Windows.Forms.ToolStripButton tsbtnPriceList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem tsmnuSTDPriceList;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem mnuProductList;
        private System.Windows.Forms.ToolStripButton tsMCRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuSaleMachines;
		private System.Windows.Forms.ToolStripMenuItem mnuSaleReport;
		private System.Windows.Forms.ToolStripMenuItem mnuSaleSummary;
	}
}