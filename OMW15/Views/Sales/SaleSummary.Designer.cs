namespace OMW15.Views.Sales
{
	partial class SaleSummary
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxSaleYear = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxSaleGroup = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlSales = new System.Windows.Forms.Panel();
			this.dgvByGroup = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tsslbYearSale = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslbRows = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlSales.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvByGroup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(960, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(265, 50);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Controls.Add(this.btnLoadData);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.cbxSaleYear);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.cbxSaleGroup);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(960, 30);
			this.panel2.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(865, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(93, 26);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.Location = new System.Drawing.Point(403, 2);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(93, 26);
			this.btnLoadData.TabIndex = 7;
			this.btnLoadData.Text = "Load data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.label4.Location = new System.Drawing.Point(383, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 26);
			this.label4.TabIndex = 6;
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxSaleYear
			// 
			this.cbxSaleYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxSaleYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSaleYear.FormattingEnabled = true;
			this.cbxSaleYear.Location = new System.Drawing.Point(285, 2);
			this.cbxSaleYear.Name = "cbxSaleYear";
			this.cbxSaleYear.Size = new System.Drawing.Size(98, 25);
			this.cbxSaleYear.TabIndex = 3;
			this.cbxSaleYear.SelectedValueChanged += new System.EventHandler(this.cbxSaleYear_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(233, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "Year:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbxSaleGroup
			// 
			this.cbxSaleGroup.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxSaleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSaleGroup.FormattingEnabled = true;
			this.cbxSaleGroup.Location = new System.Drawing.Point(84, 2);
			this.cbxSaleGroup.Name = "cbxSaleGroup";
			this.cbxSaleGroup.Size = new System.Drawing.Size(149, 25);
			this.cbxSaleGroup.TabIndex = 1;
			this.cbxSaleGroup.Visible = false;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Sale group :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Visible = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.pnlBody);
			this.panel3.Controls.Add(this.statusStrip1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 80);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(960, 378);
			this.panel3.TabIndex = 2;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlSales);
			this.pnlBody.Controls.Add(this.splitter1);
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(2, 2);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(3);
			this.pnlBody.Size = new System.Drawing.Size(956, 352);
			this.pnlBody.TabIndex = 2;
			// 
			// pnlSales
			// 
			this.pnlSales.Controls.Add(this.dgvByGroup);
			this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSales.Location = new System.Drawing.Point(3, 160);
			this.pnlSales.Name = "pnlSales";
			this.pnlSales.Padding = new System.Windows.Forms.Padding(2);
			this.pnlSales.Size = new System.Drawing.Size(950, 189);
			this.pnlSales.TabIndex = 3;
			// 
			// dgvByGroup
			// 
			this.dgvByGroup.AllowUserToAddRows = false;
			this.dgvByGroup.AllowUserToDeleteRows = false;
			this.dgvByGroup.BackgroundColor = System.Drawing.Color.White;
			this.dgvByGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvByGroup.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvByGroup.Location = new System.Drawing.Point(2, 2);
			this.dgvByGroup.Name = "dgvByGroup";
			this.dgvByGroup.ReadOnly = true;
			this.dgvByGroup.Size = new System.Drawing.Size(946, 185);
			this.dgvByGroup.TabIndex = 2;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(3, 154);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(950, 6);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgv.Location = new System.Drawing.Point(3, 3);
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.Size = new System.Drawing.Size(950, 151);
			this.dgv.TabIndex = 1;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbYearSale,
            this.tsslbRows});
			this.statusStrip1.Location = new System.Drawing.Point(2, 354);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(956, 22);
			this.statusStrip1.TabIndex = 1;
			// 
			// tsslbYearSale
			// 
			this.tsslbYearSale.Name = "tsslbYearSale";
			this.tsslbYearSale.Size = new System.Drawing.Size(0, 17);
			// 
			// tsslbRows
			// 
			this.tsslbRows.Name = "tsslbRows";
			this.tsslbRows.Size = new System.Drawing.Size(0, 17);
			// 
			// SaleSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 458);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleSummary";
			this.Text = "SALE SUMMARY";
			this.Load += new System.EventHandler(this.SaleSummary_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			this.pnlSales.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvByGroup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox cbxSaleYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxSaleGroup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tsslbYearSale;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolStripStatusLabel tsslbRows;
		private System.Windows.Forms.Panel pnlSales;
		private System.Windows.Forms.DataGridView dgvByGroup;
		private System.Windows.Forms.Splitter splitter1;
	}
}