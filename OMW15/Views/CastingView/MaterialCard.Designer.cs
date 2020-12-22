namespace OMW15.Views.CastingView
{
	partial class MaterialCard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialCard));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSearchCustomer = new OMControls.OMFlatButton();
			this.txtCustomer = new System.Windows.Forms.TextBox();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlSummary = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.dtpStockDuration = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbxMaterialCategory = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnPrint = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCalStock = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.lbTotalDelivery = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.lbOpenBalance = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btnUpdateOpenBalance = new System.Windows.Forms.Button();
			this.pnlHeader.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlSummary.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.panel3);
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(5, 5);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(796, 78);
			this.pnlHeader.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Controls.Add(this.btnSearchCustomer);
			this.panel3.Controls.Add(this.txtCustomer);
			this.panel3.Controls.Add(this.lbCustomer);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 46);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(792, 30);
			this.panel3.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Location = new System.Drawing.Point(705, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(85, 26);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "ปิด";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSearchCustomer
			// 
			this.btnSearchCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
			this.btnSearchCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchCustomer.Image")));
			this.btnSearchCustomer.Location = new System.Drawing.Point(500, 2);
			this.btnSearchCustomer.Name = "btnSearchCustomer";
			this.btnSearchCustomer.Size = new System.Drawing.Size(26, 26);
			this.btnSearchCustomer.TabIndex = 4;
			this.btnSearchCustomer.UseVisualStyleBackColor = true;
			this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
			// 
			// txtCustomer
			// 
			this.txtCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomer.Location = new System.Drawing.Point(77, 2);
			this.txtCustomer.MaxLength = 150;
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.Size = new System.Drawing.Size(423, 25);
			this.txtCustomer.TabIndex = 3;
			this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomer_KeyPress);
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustomer.Location = new System.Drawing.Point(2, 2);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(75, 26);
			this.lbCustomer.TabIndex = 2;
			this.lbCustomer.Text = "ชื่อลูกค้า :";
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.RoyalBlue;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(792, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "ใบลงน้ำหนักที่ส่งและเนื้อโลหะที่คืน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlSummary
			// 
			this.pnlSummary.Controls.Add(this.panel2);
			this.pnlSummary.Controls.Add(this.panel5);
			this.pnlSummary.Controls.Add(this.panel1);
			this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlSummary.Location = new System.Drawing.Point(5, 83);
			this.pnlSummary.Name = "pnlSummary";
			this.pnlSummary.Padding = new System.Windows.Forms.Padding(4);
			this.pnlSummary.Size = new System.Drawing.Size(224, 405);
			this.pnlSummary.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(4, 60);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(216, 28);
			this.panel2.TabIndex = 4;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.dtpStockDuration);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(4, 32);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(216, 28);
			this.panel5.TabIndex = 3;
			// 
			// dtpStockDuration
			// 
			this.dtpStockDuration.CustomFormat = "yyyy/MM";
			this.dtpStockDuration.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpStockDuration.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpStockDuration.Location = new System.Drawing.Point(78, 1);
			this.dtpStockDuration.Name = "dtpStockDuration";
			this.dtpStockDuration.Size = new System.Drawing.Size(131, 25);
			this.dtpStockDuration.TabIndex = 8;
			this.dtpStockDuration.CloseUp += new System.EventHandler(this.dtpStockDuration_CloseUp);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 26);
			this.label2.TabIndex = 7;
			this.label2.Text = "ช่วงเวลา :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbxMaterialCategory);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(216, 28);
			this.panel1.TabIndex = 0;
			// 
			// cbxMaterialCategory
			// 
			this.cbxMaterialCategory.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterialCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterialCategory.FormattingEnabled = true;
			this.cbxMaterialCategory.Location = new System.Drawing.Point(78, 1);
			this.cbxMaterialCategory.Name = "cbxMaterialCategory";
			this.cbxMaterialCategory.Size = new System.Drawing.Size(131, 25);
			this.cbxMaterialCategory.TabIndex = 5;
			this.cbxMaterialCategory.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialCategory_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 26);
			this.label4.TabIndex = 4;
			this.label4.Text = "ประเภทวัสดุ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBody
			// 
			this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Controls.Add(this.panel4);
			this.pnlBody.Controls.Add(this.panel7);
			this.pnlBody.Controls.Add(this.panel6);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(229, 83);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(4);
			this.pnlBody.Size = new System.Drawing.Size(572, 405);
			this.pnlBody.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
			this.dgv.Location = new System.Drawing.Point(4, 71);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(562, 300);
			this.dgv.TabIndex = 10;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.btnPrint);
			this.panel4.Controls.Add(this.label6);
			this.panel4.Controls.Add(this.btnCalStock);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(4, 34);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(562, 37);
			this.panel4.TabIndex = 9;
			// 
			// btnPrint
			// 
			this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.Location = new System.Drawing.Point(472, 2);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(86, 31);
			this.btnPrint.TabIndex = 7;
			this.btnPrint.Text = "พิมพ์";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(132, 2);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 31);
			this.label6.TabIndex = 4;
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnCalStock
			// 
			this.btnCalStock.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnCalStock.Location = new System.Drawing.Point(2, 2);
			this.btnCalStock.Name = "btnCalStock";
			this.btnCalStock.Size = new System.Drawing.Size(130, 31);
			this.btnCalStock.TabIndex = 0;
			this.btnCalStock.Text = "คำนวนยอดประจำงวด";
			this.btnCalStock.UseVisualStyleBackColor = true;
			this.btnCalStock.Click += new System.EventHandler(this.btnCalStock_Click);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.label5);
			this.panel7.Controls.Add(this.lbTotalDelivery);
			this.panel7.Controls.Add(this.label3);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel7.Location = new System.Drawing.Point(4, 371);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(562, 28);
			this.panel7.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(209, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 26);
			this.label5.TabIndex = 6;
			this.label5.Text = "กรัม";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbTotalDelivery
			// 
			this.lbTotalDelivery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTotalDelivery.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTotalDelivery.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalDelivery.Location = new System.Drawing.Point(78, 1);
			this.lbTotalDelivery.Name = "lbTotalDelivery";
			this.lbTotalDelivery.Size = new System.Drawing.Size(131, 26);
			this.lbTotalDelivery.TabIndex = 5;
			this.lbTotalDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 26);
			this.label3.TabIndex = 4;
			this.label3.Text = "รวมยอดส่ง :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label7);
			this.panel6.Controls.Add(this.lbOpenBalance);
			this.panel6.Controls.Add(this.label9);
			this.panel6.Controls.Add(this.btnUpdateOpenBalance);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(4, 4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(562, 30);
			this.panel6.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(335, 2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 26);
			this.label7.TabIndex = 10;
			this.label7.Text = "กรัม";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbOpenBalance
			// 
			this.lbOpenBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbOpenBalance.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbOpenBalance.Location = new System.Drawing.Point(216, 2);
			this.lbOpenBalance.Name = "lbOpenBalance";
			this.lbOpenBalance.Size = new System.Drawing.Size(119, 26);
			this.lbOpenBalance.TabIndex = 9;
			this.lbOpenBalance.Text = "0.00";
			this.lbOpenBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(133, 2);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(83, 26);
			this.label9.TabIndex = 8;
			this.label9.Text = "ยอดยกมา :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnUpdateOpenBalance
			// 
			this.btnUpdateOpenBalance.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUpdateOpenBalance.Location = new System.Drawing.Point(2, 2);
			this.btnUpdateOpenBalance.Name = "btnUpdateOpenBalance";
			this.btnUpdateOpenBalance.Size = new System.Drawing.Size(131, 26);
			this.btnUpdateOpenBalance.TabIndex = 7;
			this.btnUpdateOpenBalance.Text = "ปรับปรุงยอดยกมา";
			this.btnUpdateOpenBalance.UseVisualStyleBackColor = true;
			this.btnUpdateOpenBalance.Click += new System.EventHandler(this.btnUpdateOpenBalance_Click);
			// 
			// MaterialCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(806, 493);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlSummary);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialCard";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "ใบลงน้ำหนักที่ส่งและเนื้อโลหะที่คืน (MATERIAL CARD)";
			this.Load += new System.EventHandler(this.MaterialCard_Load);
			this.pnlHeader.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.pnlSummary.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlSummary;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbCustomer;
		private OMControls.OMFlatButton btnSearchCustomer;
		private System.Windows.Forms.TextBox txtCustomer;
		private System.Windows.Forms.ComboBox cbxMaterialCategory;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.DateTimePicker dtpStockDuration;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lbOpenBalance;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btnUpdateOpenBalance;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lbTotalDelivery;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCalStock;
		private System.Windows.Forms.Button btnPrint;
	}
}