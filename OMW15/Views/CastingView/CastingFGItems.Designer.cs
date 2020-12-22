namespace OMW15.Views.CastingView
{
	partial class CastingFGItems
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbRefSOId = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.lbFGIndex = new System.Windows.Forms.Label();
			this.lbSaleType = new System.Windows.Forms.Label();
			this.lbMaterial = new System.Windows.Forms.Label();
			this.lbSONumber = new System.Windows.Forms.Label();
			this.pnlSubHeader = new System.Windows.Forms.Panel();
			this.lbVATFactor = new System.Windows.Forms.Label();
			this.lbTotalPrice = new System.Windows.Forms.Label();
			this.lbWeightSeleted = new System.Windows.Forms.Label();
			this.lbQtySelected = new System.Windows.Forms.Label();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.lbSelectedItemCount = new System.Windows.Forms.Label();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlSubHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbRefSOId);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnSelect);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(7, 297);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(935, 40);
			this.panel1.TabIndex = 0;
			// 
			// lbRefSOId
			// 
			this.lbRefSOId.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbRefSOId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRefSOId.ForeColor = System.Drawing.Color.Black;
			this.lbRefSOId.Location = new System.Drawing.Point(122, 3);
			this.lbRefSOId.Name = "lbRefSOId";
			this.lbRefSOId.Size = new System.Drawing.Size(691, 34);
			this.lbRefSOId.TabIndex = 3;
			this.lbRefSOId.Text = "SO Key : 0";
			this.lbRefSOId.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(813, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(119, 34);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(3, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(119, 34);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.panel2);
			this.pnlHeader.Controls.Add(this.pnlSubHeader);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(7, 7);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(935, 61);
			this.pnlHeader.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.lbCustomer);
			this.panel2.Controls.Add(this.lbFGIndex);
			this.panel2.Controls.Add(this.lbSaleType);
			this.panel2.Controls.Add(this.lbMaterial);
			this.panel2.Controls.Add(this.lbSONumber);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.ForeColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(931, 28);
			this.panel2.TabIndex = 3;
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustomer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustomer.ForeColor = System.Drawing.Color.Black;
			this.lbCustomer.Location = new System.Drawing.Point(315, 1);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(431, 24);
			this.lbCustomer.TabIndex = 9;
			this.lbCustomer.Text = "Customer (xx) : (xx)";
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbFGIndex
			// 
			this.lbFGIndex.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbFGIndex.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFGIndex.ForeColor = System.Drawing.Color.Black;
			this.lbFGIndex.Location = new System.Drawing.Point(746, 1);
			this.lbFGIndex.Name = "lbFGIndex";
			this.lbFGIndex.Size = new System.Drawing.Size(93, 24);
			this.lbFGIndex.TabIndex = 8;
			this.lbFGIndex.Text = "FG : 0";
			this.lbFGIndex.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbSaleType
			// 
			this.lbSaleType.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbSaleType.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSaleType.ForeColor = System.Drawing.Color.Black;
			this.lbSaleType.Location = new System.Drawing.Point(839, 1);
			this.lbSaleType.Name = "lbSaleType";
			this.lbSaleType.Size = new System.Drawing.Size(89, 24);
			this.lbSaleType.TabIndex = 7;
			this.lbSaleType.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbMaterial
			// 
			this.lbMaterial.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMaterial.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMaterial.ForeColor = System.Drawing.Color.Black;
			this.lbMaterial.Location = new System.Drawing.Point(150, 1);
			this.lbMaterial.Name = "lbMaterial";
			this.lbMaterial.Size = new System.Drawing.Size(165, 24);
			this.lbMaterial.TabIndex = 5;
			this.lbMaterial.Text = "Mat (0) xxx";
			this.lbMaterial.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbSONumber
			// 
			this.lbSONumber.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSONumber.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSONumber.ForeColor = System.Drawing.Color.Black;
			this.lbSONumber.Location = new System.Drawing.Point(1, 1);
			this.lbSONumber.Name = "lbSONumber";
			this.lbSONumber.Size = new System.Drawing.Size(149, 24);
			this.lbSONumber.TabIndex = 4;
			this.lbSONumber.Text = "SO : 0";
			this.lbSONumber.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlSubHeader
			// 
			this.pnlSubHeader.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlSubHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlSubHeader.Controls.Add(this.lbVATFactor);
			this.pnlSubHeader.Controls.Add(this.lbTotalPrice);
			this.pnlSubHeader.Controls.Add(this.lbWeightSeleted);
			this.pnlSubHeader.Controls.Add(this.lbQtySelected);
			this.pnlSubHeader.Controls.Add(this.lbRowCount);
			this.pnlSubHeader.Controls.Add(this.lbSelectedItemCount);
			this.pnlSubHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSubHeader.ForeColor = System.Drawing.Color.White;
			this.pnlSubHeader.Location = new System.Drawing.Point(2, 31);
			this.pnlSubHeader.Name = "pnlSubHeader";
			this.pnlSubHeader.Padding = new System.Windows.Forms.Padding(1);
			this.pnlSubHeader.Size = new System.Drawing.Size(931, 28);
			this.pnlSubHeader.TabIndex = 2;
			// 
			// lbVATFactor
			// 
			this.lbVATFactor.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbVATFactor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbVATFactor.Location = new System.Drawing.Point(725, 1);
			this.lbVATFactor.Name = "lbVATFactor";
			this.lbVATFactor.Size = new System.Drawing.Size(97, 24);
			this.lbVATFactor.TabIndex = 7;
			this.lbVATFactor.Text = "rate : 0";
			this.lbVATFactor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbTotalPrice
			// 
			this.lbTotalPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTotalPrice.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalPrice.Location = new System.Drawing.Point(508, 1);
			this.lbTotalPrice.Name = "lbTotalPrice";
			this.lbTotalPrice.Size = new System.Drawing.Size(205, 24);
			this.lbTotalPrice.TabIndex = 6;
			this.lbTotalPrice.Text = "Total price : 0 (THB)";
			this.lbTotalPrice.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbWeightSeleted
			// 
			this.lbWeightSeleted.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWeightSeleted.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWeightSeleted.Location = new System.Drawing.Point(315, 1);
			this.lbWeightSeleted.Name = "lbWeightSeleted";
			this.lbWeightSeleted.Size = new System.Drawing.Size(193, 24);
			this.lbWeightSeleted.TabIndex = 5;
			this.lbWeightSeleted.Text = "Total weight : 0 (g)";
			this.lbWeightSeleted.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbQtySelected
			// 
			this.lbQtySelected.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbQtySelected.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbQtySelected.Location = new System.Drawing.Point(150, 1);
			this.lbQtySelected.Name = "lbQtySelected";
			this.lbQtySelected.Size = new System.Drawing.Size(165, 24);
			this.lbQtySelected.TabIndex = 4;
			this.lbQtySelected.Text = "Total Qty : 0";
			this.lbQtySelected.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbRowCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowCount.Location = new System.Drawing.Point(822, 1);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(106, 24);
			this.lbRowCount.TabIndex = 3;
			this.lbRowCount.Text = "found : 0";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbSelectedItemCount
			// 
			this.lbSelectedItemCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedItemCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectedItemCount.Location = new System.Drawing.Point(1, 1);
			this.lbSelectedItemCount.Name = "lbSelectedItemCount";
			this.lbSelectedItemCount.Size = new System.Drawing.Size(149, 24);
			this.lbSelectedItemCount.TabIndex = 2;
			this.lbSelectedItemCount.Text = "Selected Item(s) : 0";
			this.lbSelectedItemCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(7, 68);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(935, 229);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
			// 
			// CastingFGItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(949, 344);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingFGItems";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.Text = "CASTING FG ITEMS";
			this.Load += new System.EventHandler(this.CastingFGItems_Load);
			this.panel1.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlSubHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlSubHeader;
		private System.Windows.Forms.Label lbRowCount;
		private System.Windows.Forms.Label lbSelectedItemCount;
		private System.Windows.Forms.Label lbTotalPrice;
		private System.Windows.Forms.Label lbWeightSeleted;
		private System.Windows.Forms.Label lbQtySelected;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbMaterial;
		private System.Windows.Forms.Label lbSONumber;
		private System.Windows.Forms.Label lbSaleType;
		private System.Windows.Forms.Label lbVATFactor;
		private System.Windows.Forms.Label lbFGIndex;
		private System.Windows.Forms.Label lbCustomer;
		private System.Windows.Forms.Label lbRefSOId;
	}
}