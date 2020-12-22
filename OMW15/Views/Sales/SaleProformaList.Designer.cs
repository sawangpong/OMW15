namespace OMW15.Views.Sales
{
	partial class SaleProformaList
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
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxYearSale = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnPrintPI = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbPIIndex = new System.Windows.Forms.Label();
			this.ts.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscbxYearSale,
            this.toolStripSeparator4,
            this.tsbtnRefresh,
            this.toolStripSeparator5,
            this.tsbtnAdd,
            this.toolStripSeparator2,
            this.tsbtnEdit,
            this.toolStripSeparator3,
            this.tsbtnPrintPI,
            this.toolStripSeparator6});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(897, 38);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(35, 35);
			this.tsbtnClose.Tag = "CLO";
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(63, 35);
			this.toolStripLabel1.Text = "Year Sale :";
			// 
			// tscbxYearSale
			// 
			this.tscbxYearSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxYearSale.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxYearSale.Name = "tscbxYearSale";
			this.tscbxYearSale.Size = new System.Drawing.Size(121, 38);
			this.tscbxYearSale.SelectedIndexChanged += new System.EventHandler(this.tscbxYearSale_SelectedIndexChanged);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(35, 35);
			this.tsbtnRefresh.ToolTipText = "Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(35, 35);
			this.tsbtnAdd.Tag = "ADD";
			this.tsbtnAdd.ToolTipText = "Add";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(35, 35);
			this.tsbtnEdit.Tag = "EDT";
			this.tsbtnEdit.ToolTipText = "Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnPrintPI
			// 
			this.tsbtnPrintPI.AutoSize = false;
			this.tsbtnPrintPI.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnPrintPI.Image = global::OMW15.Properties.Resources.PrintHS;
			this.tsbtnPrintPI.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnPrintPI.Name = "tsbtnPrintPI";
			this.tsbtnPrintPI.Size = new System.Drawing.Size(35, 35);
			this.tsbtnPrintPI.ToolTipText = "Print PI";
			this.tsbtnPrintPI.Click += new System.EventHandler(this.tsbtnPrintPI_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
			// 
			// pnlRight
			// 
			this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlRight.Location = new System.Drawing.Point(706, 38);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(3);
			this.pnlRight.Size = new System.Drawing.Size(191, 399);
			this.pnlRight.TabIndex = 1;
			this.pnlRight.Visible = false;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(700, 38);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 399);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			this.splitter1.Visible = false;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.dgv);
			this.pnlLeft.Controls.Add(this.panel2);
			this.pnlLeft.Controls.Add(this.panel1);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeft.Location = new System.Drawing.Point(0, 38);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(3);
			this.pnlLeft.Size = new System.Drawing.Size(700, 399);
			this.pnlLeft.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 36);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(692, 331);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(692, 33);
			this.panel2.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbPIIndex);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 367);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(692, 27);
			this.panel1.TabIndex = 0;
			// 
			// lbPIIndex
			// 
			this.lbPIIndex.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbPIIndex.Location = new System.Drawing.Point(2, 2);
			this.lbPIIndex.Name = "lbPIIndex";
			this.lbPIIndex.Size = new System.Drawing.Size(85, 23);
			this.lbPIIndex.TabIndex = 0;
			this.lbPIIndex.Text = "idx : 0";
			this.lbPIIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SaleProformaList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(897, 437);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleProformaList";
			this.Text = "PROFORMA INVOICE LIST";
			this.Load += new System.EventHandler(this.SaleProformaList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxYearSale;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Label lbPIIndex;
		private System.Windows.Forms.ToolStripButton tsbtnPrintPI;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
	}
}