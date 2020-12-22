namespace OMW15.Casting.CastingView
{
	partial class CastingPriceList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSelectCustomer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbSelectedCustomer = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlPriceList = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbItemId = new System.Windows.Forms.Label();
			this.lbRowFound = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbFileName = new System.Windows.Forms.Label();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnOpenJob = new System.Windows.Forms.Button();
			this.cbxFindItem = new System.Windows.Forms.ComboBox();
			this.lbHolder1 = new System.Windows.Forms.Label();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.ts.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.pnlPriceList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.panel1.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.BackColor = System.Drawing.SystemColors.Info;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnSelectCustomer,
            this.toolStripSeparator2,
            this.tslbSelectedCustomer,
            this.toolStripSeparator3});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(787, 39);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.ForeColor = System.Drawing.SystemColors.InfoText;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 36);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// tsbtnSelectCustomer
			// 
			this.tsbtnSelectCustomer.AutoSize = false;
			this.tsbtnSelectCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnSelectCustomer.ForeColor = System.Drawing.SystemColors.InfoText;
			this.tsbtnSelectCustomer.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSelectCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.tsbtnSelectCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSelectCustomer.Name = "tsbtnSelectCustomer";
			this.tsbtnSelectCustomer.Size = new System.Drawing.Size(100, 38);
			this.tsbtnSelectCustomer.Text = "เลือกลูกค้า";
			this.tsbtnSelectCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnSelectCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.tsbtnSelectCustomer.Click += new System.EventHandler(this.tsbtnSelectCustomer_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// tslbSelectedCustomer
			// 
			this.tslbSelectedCustomer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tslbSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbSelectedCustomer.ForeColor = System.Drawing.SystemColors.InfoText;
			this.tslbSelectedCustomer.Name = "tslbSelectedCustomer";
			this.tslbSelectedCustomer.Size = new System.Drawing.Size(18, 36);
			this.tslbSelectedCustomer.Text = "--";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlPriceList);
			this.pnlMain.Controls.Add(this.panel2);
			this.pnlMain.Controls.Add(this.panel1);
			this.pnlMain.Controls.Add(this.pnlTop);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 39);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlMain.Size = new System.Drawing.Size(787, 469);
			this.pnlMain.TabIndex = 1;
			// 
			// pnlPriceList
			// 
			this.pnlPriceList.Controls.Add(this.dgv);
			this.pnlPriceList.Controls.Add(this.panel3);
			this.pnlPriceList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlPriceList.Location = new System.Drawing.Point(4, 38);
			this.pnlPriceList.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPriceList.Name = "pnlPriceList";
			this.pnlPriceList.Padding = new System.Windows.Forms.Padding(4);
			this.pnlPriceList.Size = new System.Drawing.Size(603, 294);
			this.pnlPriceList.TabIndex = 4;
			// 
			// dgv
			// 
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.HotTrack;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.InactiveBorder;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Margin = new System.Windows.Forms.Padding(4);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(595, 258);
			this.dgv.TabIndex = 4;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbItemId);
			this.panel3.Controls.Add(this.lbRowFound);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel3.Location = new System.Drawing.Point(4, 262);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(4);
			this.panel3.Size = new System.Drawing.Size(595, 28);
			this.panel3.TabIndex = 2;
			// 
			// lbItemId
			// 
			this.lbItemId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbItemId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemId.Location = new System.Drawing.Point(503, 4);
			this.lbItemId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbItemId.Name = "lbItemId";
			this.lbItemId.Size = new System.Drawing.Size(88, 20);
			this.lbItemId.TabIndex = 5;
			this.lbItemId.Text = "0";
			this.lbItemId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbRowFound
			// 
			this.lbRowFound.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowFound.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowFound.Location = new System.Drawing.Point(4, 4);
			this.lbRowFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbRowFound.Name = "lbRowFound";
			this.lbRowFound.Size = new System.Drawing.Size(88, 20);
			this.lbRowFound.TabIndex = 4;
			this.lbRowFound.Text = "0/0";
			this.lbRowFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pic);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(607, 38);
			this.panel2.Margin = new System.Windows.Forms.Padding(4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10, 12, 10, 12);
			this.panel2.Size = new System.Drawing.Size(176, 294);
			this.panel2.TabIndex = 2;
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Location = new System.Drawing.Point(10, 12);
			this.pic.Margin = new System.Windows.Forms.Padding(4);
			this.pic.Name = "pic";
			this.pic.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pic.Size = new System.Drawing.Size(156, 189);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lbFileName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 332);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(779, 132);
			this.panel1.TabIndex = 1;
			// 
			// lbFileName
			// 
			this.lbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbFileName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFileName.Location = new System.Drawing.Point(4, 4);
			this.lbFileName.Name = "lbFileName";
			this.lbFileName.Size = new System.Drawing.Size(769, 23);
			this.lbFileName.TabIndex = 0;
			this.lbFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel4);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(4, 5);
			this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(779, 33);
			this.pnlTop.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnOpenJob);
			this.panel4.Controls.Add(this.cbxFindItem);
			this.panel4.Controls.Add(this.lbHolder1);
			this.panel4.Controls.Add(this.btnEdit);
			this.panel4.Controls.Add(this.btnNew);
			this.panel4.Controls.Add(this.btnRefresh);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(10, 2, 20, 2);
			this.panel4.Size = new System.Drawing.Size(779, 30);
			this.panel4.TabIndex = 1;
			// 
			// btnOpenJob
			// 
			this.btnOpenJob.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnOpenJob.Location = new System.Drawing.Point(472, 2);
			this.btnOpenJob.Margin = new System.Windows.Forms.Padding(4);
			this.btnOpenJob.Name = "btnOpenJob";
			this.btnOpenJob.Size = new System.Drawing.Size(133, 26);
			this.btnOpenJob.TabIndex = 13;
			this.btnOpenJob.Text = "เปิดใบสั่งงาน";
			this.btnOpenJob.UseVisualStyleBackColor = true;
			this.btnOpenJob.Click += new System.EventHandler(this.btnOpenJob_Click);
			// 
			// cbxFindItem
			// 
			this.cbxFindItem.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxFindItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFindItem.FormattingEnabled = true;
			this.cbxFindItem.Location = new System.Drawing.Point(368, 2);
			this.cbxFindItem.Name = "cbxFindItem";
			this.cbxFindItem.Size = new System.Drawing.Size(104, 25);
			this.cbxFindItem.TabIndex = 12;
			this.cbxFindItem.SelectedValueChanged += new System.EventHandler(this.cbxFindItem_SelectedValueChanged);
			// 
			// lbHolder1
			// 
			this.lbHolder1.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHolder1.Image = global::OMW15.Properties.Resources.FindHS;
			this.lbHolder1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lbHolder1.Location = new System.Drawing.Point(308, 2);
			this.lbHolder1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbHolder1.Name = "lbHolder1";
			this.lbHolder1.Size = new System.Drawing.Size(60, 26);
			this.lbHolder1.TabIndex = 10;
			this.lbHolder1.Text = "ค้นหา :";
			this.lbHolder1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(214, 2);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(94, 26);
			this.btnEdit.TabIndex = 6;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnNew
			// 
			this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnNew.Image = global::OMW15.Properties.Resources.Add;
			this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNew.Location = new System.Drawing.Point(112, 2);
			this.btnNew.Margin = new System.Windows.Forms.Padding(4);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(102, 26);
			this.btnNew.TabIndex = 5;
			this.btnNew.Text = "&New";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefresh.Location = new System.Drawing.Point(10, 2);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(102, 26);
			this.btnRefresh.TabIndex = 4;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
			// 
			// CastingPriceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(787, 508);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CastingPriceList";
			this.Text = "CASTING PRICE LIST";
			this.Load += new System.EventHandler(this.CastingPriceList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlMain.ResumeLayout(false);
			this.pnlPriceList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.panel1.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.ToolStripButton tsbtnSelectCustomer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ToolStripLabel tslbSelectedCustomer;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlPriceList;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbRowFound;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label lbItemId;
		private System.Windows.Forms.Label lbHolder1;
		private System.Windows.Forms.ComboBox cbxFindItem;
		private System.Windows.Forms.Button btnOpenJob;
		private System.Windows.Forms.Label lbFileName;
	}
}