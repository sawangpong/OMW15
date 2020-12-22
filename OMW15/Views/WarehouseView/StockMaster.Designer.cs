namespace OMW15.Views.WarehouseView
{
	partial class StockMaster
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
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tslbAppCall = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSearchItem = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuAllItems = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmnuSearchByItemNo = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmnuSearchByItemName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlStock = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.stb = new System.Windows.Forms.StatusStrip();
			this.stbCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslbId = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlStockCategory = new System.Windows.Forms.Panel();
			this.btnUpdatePicture = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pic1 = new System.Windows.Forms.PictureBox();
			this.ts.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlStock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.stb.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.pnlStockCategory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbAppCall,
            this.toolStripSeparator1,
            this.tsbtnRefresh,
            this.toolStripSeparator2,
            this.tsbtnClose,
            this.toolStripSeparator3,
            this.tsbtnSearchItem,
            this.toolStripSeparator4});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(812, 45);
			this.ts.TabIndex = 0;
			// 
			// tslbAppCall
			// 
			this.tslbAppCall.AutoSize = false;
			this.tslbAppCall.BackColor = System.Drawing.Color.Yellow;
			this.tslbAppCall.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tslbAppCall.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbAppCall.Name = "tslbAppCall";
			this.tslbAppCall.Size = new System.Drawing.Size(145, 42);
			this.tslbAppCall.Text = "Item Master (ERP)";
			this.tslbAppCall.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(60, 43);
			this.tsbtnRefresh.Text = "Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 43);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnSearchItem
			// 
			this.tsbtnSearchItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAllItems,
            this.toolStripMenuItem1,
            this.tsmnuSearchByItemNo,
            this.tsmnuSearchByItemName});
			this.tsbtnSearchItem.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearchItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearchItem.Name = "tsbtnSearchItem";
			this.tsbtnSearchItem.Size = new System.Drawing.Size(63, 42);
			this.tsbtnSearchItem.Text = "Search";
			this.tsbtnSearchItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// mnuAllItems
			// 
			this.mnuAllItems.Name = "mnuAllItems";
			this.mnuAllItems.Size = new System.Drawing.Size(152, 22);
			this.mnuAllItems.Tag = "ALL";
			this.mnuAllItems.Text = "All Items";
			this.mnuAllItems.Click += new System.EventHandler(this.tsmnuSearchChild_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// tsmnuSearchByItemNo
			// 
			this.tsmnuSearchByItemNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuSearchByItemNo.Name = "tsmnuSearchByItemNo";
			this.tsmnuSearchByItemNo.Size = new System.Drawing.Size(152, 22);
			this.tsmnuSearchByItemNo.Tag = "ID";
			this.tsmnuSearchByItemNo.Text = "Part No";
			this.tsmnuSearchByItemNo.Click += new System.EventHandler(this.tsmnuSearchChild_Click);
			// 
			// tsmnuSearchByItemName
			// 
			this.tsmnuSearchByItemName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuSearchByItemName.Name = "tsmnuSearchByItemName";
			this.tsmnuSearchByItemName.Size = new System.Drawing.Size(152, 22);
			this.tsmnuSearchByItemName.Tag = "NAME";
			this.tsmnuSearchByItemName.Text = "Part Name";
			this.tsmnuSearchByItemName.Click += new System.EventHandler(this.tsmnuSearchChild_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlStock);
			this.pnlBody.Controls.Add(this.pnlCommand);
			this.pnlBody.Controls.Add(this.pnlStockCategory);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 45);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(4);
			this.pnlBody.Size = new System.Drawing.Size(812, 410);
			this.pnlBody.TabIndex = 2;
			// 
			// pnlStock
			// 
			this.pnlStock.Controls.Add(this.dgv);
			this.pnlStock.Controls.Add(this.stb);
			this.pnlStock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlStock.Location = new System.Drawing.Point(149, 4);
			this.pnlStock.Name = "pnlStock";
			this.pnlStock.Padding = new System.Windows.Forms.Padding(2);
			this.pnlStock.Size = new System.Drawing.Size(659, 364);
			this.pnlStock.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(655, 338);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// stb
			// 
			this.stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbCount,
            this.tsslbId});
			this.stb.Location = new System.Drawing.Point(2, 340);
			this.stb.Name = "stb";
			this.stb.Size = new System.Drawing.Size(655, 22);
			this.stb.TabIndex = 1;
			this.stb.Text = "statusStrip1";
			// 
			// stbCount
			// 
			this.stbCount.Name = "stbCount";
			this.stbCount.Size = new System.Drawing.Size(0, 17);
			// 
			// tsslbId
			// 
			this.tsslbId.Name = "tsslbId";
			this.tsslbId.Size = new System.Drawing.Size(26, 17);
			this.tsslbId.Text = "Id:0";
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Controls.Add(this.btnClose);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(149, 368);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(4);
			this.pnlCommand.Size = new System.Drawing.Size(659, 38);
			this.pnlCommand.TabIndex = 2;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(4, 4);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(111, 30);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(544, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(111, 30);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// pnlStockCategory
			// 
			this.pnlStockCategory.Controls.Add(this.btnUpdatePicture);
			this.pnlStockCategory.Controls.Add(this.label1);
			this.pnlStockCategory.Controls.Add(this.pic1);
			this.pnlStockCategory.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlStockCategory.Location = new System.Drawing.Point(4, 4);
			this.pnlStockCategory.Name = "pnlStockCategory";
			this.pnlStockCategory.Padding = new System.Windows.Forms.Padding(2);
			this.pnlStockCategory.Size = new System.Drawing.Size(145, 402);
			this.pnlStockCategory.TabIndex = 0;
			// 
			// btnUpdatePicture
			// 
			this.btnUpdatePicture.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnUpdatePicture.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnUpdatePicture.Location = new System.Drawing.Point(2, 169);
			this.btnUpdatePicture.Name = "btnUpdatePicture";
			this.btnUpdatePicture.Size = new System.Drawing.Size(141, 56);
			this.btnUpdatePicture.TabIndex = 3;
			this.btnUpdatePicture.Text = "Add / Change / Remove Picture\r\n";
			this.btnUpdatePicture.UseVisualStyleBackColor = true;
			this.btnUpdatePicture.Click += new System.EventHandler(this.btnUpdatePicture_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(2, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 10);
			this.label1.TabIndex = 2;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pic1
			// 
			this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic1.Location = new System.Drawing.Point(2, 2);
			this.pic1.Name = "pic1";
			this.pic1.Padding = new System.Windows.Forms.Padding(3);
			this.pic1.Size = new System.Drawing.Size(141, 157);
			this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic1.TabIndex = 0;
			this.pic1.TabStop = false;
			// 
			// StockMaster
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(812, 455);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "StockMaster";
			this.Text = "STOCK MASTER";
			this.Load += new System.EventHandler(this.StockMaster_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			this.pnlStock.ResumeLayout(false);
			this.pnlStock.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.stb.ResumeLayout(false);
			this.stb.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			this.pnlStockCategory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel tslbAppCall;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.ToolStripSplitButton tsbtnSearchItem;
		private System.Windows.Forms.ToolStripMenuItem tsmnuSearchByItemNo;
		private System.Windows.Forms.ToolStripMenuItem tsmnuSearchByItemName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Panel pnlStockCategory;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlStock;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.StatusStrip stb;
		private System.Windows.Forms.ToolStripStatusLabel stbCount;
		private System.Windows.Forms.ToolStripMenuItem mnuAllItems;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.ToolStripStatusLabel tsslbId;
		private System.Windows.Forms.Button btnUpdatePicture;
		private System.Windows.Forms.Label label1;
	}
}