namespace OMW15.Casting.CastingView
{
	partial class MaterialCost
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxMaterial = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgvMatPrice = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbId = new System.Windows.Forms.Label();
			this.lbRecordCount = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlAVGByMonth = new System.Windows.Forms.Panel();
			this.dgvAVGPrice = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbYearAVGMatPrice = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tsAvg = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxYearSale = new System.Windows.Forms.ToolStripComboBox();
			this.ts.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMatPrice)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlAVGByMonth.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvAVGPrice)).BeginInit();
			this.panel2.SuspendLayout();
			this.tsAvg.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbxMaterial,
            this.toolStripSeparator1,
            this.tsbtnClose,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnAdd,
            this.toolStripSeparator4,
            this.tsbtnEdit,
            this.toolStripSeparator5});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(605, 40);
			this.ts.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(35, 37);
			this.toolStripLabel1.Text = "วัสดุ :";
			// 
			// tscbxMaterial
			// 
			this.tscbxMaterial.AutoSize = false;
			this.tscbxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxMaterial.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tscbxMaterial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscbxMaterial.Name = "tscbxMaterial";
			this.tscbxMaterial.Size = new System.Drawing.Size(125, 25);
			this.tscbxMaterial.SelectedIndexChanged += new System.EventHandler(this.tscbxMaterial_SelectedIndexChanged);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 37);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(72, 37);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(47, 37);
			this.tsbtnAdd.Text = "เพิ่ม";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(54, 37);
			this.tsbtnEdit.Text = "แก้ไข";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
			// 
			// pnlBody
			// 
			this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBody.Controls.Add(this.dgvMatPrice);
			this.pnlBody.Controls.Add(this.panel3);
			this.pnlBody.Controls.Add(this.lbTitle);
			this.pnlBody.Controls.Add(this.panel1);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 40);
			this.pnlBody.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlBody.Size = new System.Drawing.Size(605, 415);
			this.pnlBody.TabIndex = 1;
			// 
			// dgvMatPrice
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvMatPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvMatPrice.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgvMatPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMatPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMatPrice.Location = new System.Drawing.Point(3, 38);
			this.dgvMatPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgvMatPrice.Name = "dgvMatPrice";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvMatPrice.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvMatPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvMatPrice.Size = new System.Drawing.Size(351, 343);
			this.dgvMatPrice.TabIndex = 4;
			this.dgvMatPrice.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatPrice_CellEnter);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbId);
			this.panel3.Controls.Add(this.lbRecordCount);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(3, 381);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Size = new System.Drawing.Size(351, 28);
			this.panel3.TabIndex = 3;
			// 
			// lbId
			// 
			this.lbId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbId.Location = new System.Drawing.Point(274, 3);
			this.lbId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(75, 22);
			this.lbId.TabIndex = 3;
			this.lbId.Text = "id : (0)";
			this.lbId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbRecordCount
			// 
			this.lbRecordCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRecordCount.Location = new System.Drawing.Point(2, 3);
			this.lbRecordCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbRecordCount.Name = "lbRecordCount";
			this.lbRecordCount.Size = new System.Drawing.Size(175, 22);
			this.lbRecordCount.TabIndex = 2;
			this.lbRecordCount.Text = "fount : (0)";
			this.lbRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.SystemColors.Highlight;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.lbTitle.Location = new System.Drawing.Point(3, 4);
			this.lbTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(351, 34);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "ราคาขาย";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pnlAVGByMonth);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.tsAvg);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(354, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Size = new System.Drawing.Size(246, 405);
			this.panel1.TabIndex = 0;
			// 
			// pnlAVGByMonth
			// 
			this.pnlAVGByMonth.Controls.Add(this.dgvAVGPrice);
			this.pnlAVGByMonth.Controls.Add(this.label2);
			this.pnlAVGByMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlAVGByMonth.Location = new System.Drawing.Point(3, 64);
			this.pnlAVGByMonth.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlAVGByMonth.Name = "pnlAVGByMonth";
			this.pnlAVGByMonth.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlAVGByMonth.Size = new System.Drawing.Size(238, 335);
			this.pnlAVGByMonth.TabIndex = 4;
			// 
			// dgvAVGPrice
			// 
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAVGPrice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvAVGPrice.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvAVGPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.dgvAVGPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAVGPrice.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvAVGPrice.Location = new System.Drawing.Point(3, 38);
			this.dgvAVGPrice.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgvAVGPrice.Name = "dgvAVGPrice";
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAVGPrice.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvAVGPrice.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvAVGPrice.Size = new System.Drawing.Size(232, 293);
			this.dgvAVGPrice.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.SystemColors.Highlight;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.label2.Location = new System.Drawing.Point(3, 4);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(232, 34);
			this.label2.TabIndex = 5;
			this.label2.Text = "ราคาขายเฉลี่ยรายเดือน (บาท/กรัม)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbYearAVGMatPrice);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 38);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(238, 26);
			this.panel2.TabIndex = 1;
			// 
			// lbYearAVGMatPrice
			// 
			this.lbYearAVGMatPrice.BackColor = System.Drawing.Color.Red;
			this.lbYearAVGMatPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbYearAVGMatPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYearAVGMatPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbYearAVGMatPrice.ForeColor = System.Drawing.Color.Yellow;
			this.lbYearAVGMatPrice.Location = new System.Drawing.Point(92, 1);
			this.lbYearAVGMatPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbYearAVGMatPrice.Name = "lbYearAVGMatPrice";
			this.lbYearAVGMatPrice.Size = new System.Drawing.Size(91, 24);
			this.lbYearAVGMatPrice.TabIndex = 1;
			this.lbYearAVGMatPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "บาท / กรัม :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tsAvg
			// 
			this.tsAvg.AutoSize = false;
			this.tsAvg.BackColor = System.Drawing.SystemColors.Highlight;
			this.tsAvg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tsAvg.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsAvg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tscbxYearSale});
			this.tsAvg.Location = new System.Drawing.Point(3, 4);
			this.tsAvg.Name = "tsAvg";
			this.tsAvg.Size = new System.Drawing.Size(238, 34);
			this.tsAvg.TabIndex = 0;
			this.tsAvg.Text = "toolStrip1";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripLabel2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(120, 31);
			this.toolStripLabel2.Text = "ราคาขายเฉลี่ย (ปี) :";
			// 
			// tscbxYearSale
			// 
			this.tscbxYearSale.AutoSize = false;
			this.tscbxYearSale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxYearSale.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.tscbxYearSale.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscbxYearSale.Name = "tscbxYearSale";
			this.tscbxYearSale.Size = new System.Drawing.Size(91, 25);
			this.tscbxYearSale.SelectedIndexChanged += new System.EventHandler(this.tscbxYearSale_SelectedIndexChanged);
			// 
			// MaterialCost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 455);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialCost";
			this.Text = "MATERIAL PRICE";
			this.Load += new System.EventHandler(this.MaterialCost_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMatPrice)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlAVGByMonth.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvAVGPrice)).EndInit();
			this.panel2.ResumeLayout(false);
			this.tsAvg.ResumeLayout(false);
			this.tsAvg.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxMaterial;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip tsAvg;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripComboBox tscbxYearSale;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbYearAVGMatPrice;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.DataGridView dgvMatPrice;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbRecordCount;
		private System.Windows.Forms.Label lbId;
		private System.Windows.Forms.Panel pnlAVGByMonth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvAVGPrice;
	}
}