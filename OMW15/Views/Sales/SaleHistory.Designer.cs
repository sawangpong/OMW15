namespace OMW15.Views.Sales
{
	partial class SaleHistory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleHistory));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnCustomerSearch = new OMControls.OMFlatButton();
			this.txtCustomerFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtItemSearch = new System.Windows.Forms.TextBox();
			this.btnSearchItem = new OMControls.OMFlatButton();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.sst = new System.Windows.Forms.StatusStrip();
			this.sstlbRowFound = new System.Windows.Forms.ToolStripStatusLabel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.sst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlTop.Controls.Add(this.label2);
			this.pnlTop.Controls.Add(this.panel1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(947, 83);
			this.pnlTop.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(704, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(241, 46);
			this.label2.TabIndex = 1;
			this.label2.Text = "ประวัติการซื้อ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnCustomerSearch);
			this.panel1.Controls.Add(this.txtCustomerFilter);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 48);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(943, 33);
			this.panel1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(858, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(83, 29);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnCustomerSearch
			// 
			this.btnCustomerSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCustomerSearch.FlatAppearance.BorderSize = 0;
			this.btnCustomerSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnCustomerSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCustomerSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerSearch.Image")));
			this.btnCustomerSearch.Location = new System.Drawing.Point(359, 2);
			this.btnCustomerSearch.Name = "btnCustomerSearch";
			this.btnCustomerSearch.Size = new System.Drawing.Size(29, 29);
			this.btnCustomerSearch.TabIndex = 2;
			this.btnCustomerSearch.UseVisualStyleBackColor = true;
			this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
			// 
			// txtCustomerFilter
			// 
			this.txtCustomerFilter.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomerFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomerFilter.Location = new System.Drawing.Point(67, 2);
			this.txtCustomerFilter.MaxLength = 100;
			this.txtCustomerFilter.Name = "txtCustomerFilter";
			this.txtCustomerFilter.Size = new System.Drawing.Size(292, 27);
			this.txtCustomerFilter.TabIndex = 1;
			this.txtCustomerFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerFilter_KeyPress);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "ลูกค้า :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Controls.Add(this.sst);
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 83);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(947, 402);
			this.panel3.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLoadData);
			this.panel2.Controls.Add(this.lbCustCode);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.txtItemSearch);
			this.panel2.Controls.Add(this.btnSearchItem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(943, 33);
			this.panel2.TabIndex = 2;
			// 
			// lbCustCode
			// 
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustCode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustCode.ForeColor = System.Drawing.Color.Black;
			this.lbCustCode.Location = new System.Drawing.Point(2, 2);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(65, 29);
			this.lbCustCode.TabIndex = 6;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(490, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 29);
			this.label3.TabIndex = 5;
			this.label3.Text = "ค้นหารายการซื้อ :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtItemSearch
			// 
			this.txtItemSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemSearch.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtItemSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtItemSearch.Location = new System.Drawing.Point(620, 2);
			this.txtItemSearch.MaxLength = 100;
			this.txtItemSearch.Name = "txtItemSearch";
			this.txtItemSearch.Size = new System.Drawing.Size(292, 27);
			this.txtItemSearch.TabIndex = 4;
			this.txtItemSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemSearch_KeyPress);
			// 
			// btnSearchItem
			// 
			this.btnSearchItem.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchItem.FlatAppearance.BorderSize = 0;
			this.btnSearchItem.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchItem.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchItem.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchItem.Image")));
			this.btnSearchItem.Location = new System.Drawing.Point(912, 2);
			this.btnSearchItem.Name = "btnSearchItem";
			this.btnSearchItem.Size = new System.Drawing.Size(29, 29);
			this.btnSearchItem.TabIndex = 2;
			this.btnSearchItem.UseVisualStyleBackColor = true;
			this.btnSearchItem.Click += new System.EventHandler(this.btnSearchItem_Click);
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadData.Location = new System.Drawing.Point(67, 2);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(103, 29);
			this.btnLoadData.TabIndex = 7;
			this.btnLoadData.Text = "Load Data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// sst
			// 
			this.sst.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.sst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sstlbRowFound});
			this.sst.Location = new System.Drawing.Point(2, 378);
			this.sst.Name = "sst";
			this.sst.Size = new System.Drawing.Size(943, 22);
			this.sst.TabIndex = 4;
			// 
			// sstlbRowFound
			// 
			this.sstlbRowFound.Name = "sstlbRowFound";
			this.sstlbRowFound.Size = new System.Drawing.Size(117, 17);
			this.sstlbRowFound.Text = "toolStripStatusLabel1";
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 35);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(943, 343);
			this.dgv.TabIndex = 5;
			// 
			// SaleHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 485);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleHistory";
			this.Text = "Sale History";
			this.Load += new System.EventHandler(this.SaleHistory_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.sst.ResumeLayout(false);
			this.sst.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private OMControls.OMFlatButton btnCustomerSearch;
		private System.Windows.Forms.TextBox txtCustomerFilter;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private OMControls.OMFlatButton btnSearchItem;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtItemSearch;
		private System.Windows.Forms.Label lbCustCode;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.StatusStrip sst;
		private System.Windows.Forms.ToolStripStatusLabel sstlbRowFound;
	}
}