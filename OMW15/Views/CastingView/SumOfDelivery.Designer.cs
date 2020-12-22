namespace OMW15.Views.CastingView
{
	partial class SumOfDelivery
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.dgvReturn = new System.Windows.Forms.DataGridView();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbTotalReturn = new System.Windows.Forms.Label();
			this.lbBalance = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.dgvIssue = new System.Windows.Forms.DataGridView();
			this.pnlSelectedCustomerSummary = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.lbTotalDeliveryForSelectedCustomer = new System.Windows.Forms.Label();
			this.lbTotalSIForSelectedCustomer = new System.Windows.Forms.Label();
			this.lbSelectedCustomer = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbTotalDelivery = new System.Windows.Forms.Label();
			this.lbSI = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
			this.panel8.SuspendLayout();
			this.pnlDisplay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvIssue)).BeginInit();
			this.pnlSelectedCustomerSummary.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.DarkBlue;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(996, 81);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.Yellow;
			this.lbTitle.Location = new System.Drawing.Point(3, 3);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(344, 47);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "สรุป ยืม / คืน วัสดุ";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.Control;
			this.panel4.Controls.Add(this.cbxMonth);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Controls.Add(this.cbxYear);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(3, 50);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(20, 1, 1, 1);
			this.panel4.Size = new System.Drawing.Size(990, 28);
			this.panel4.TabIndex = 0;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(232, 1);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(94, 25);
			this.cbxMonth.TabIndex = 3;
			this.cbxMonth.SelectionChangeCommitted += new System.EventHandler(this.cbxMonth_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(157, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 26);
			this.label2.TabIndex = 2;
			this.label2.Text = "เดือน : ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(63, 1);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(94, 25);
			this.cbxYear.TabIndex = 1;
			this.cbxYear.SelectedValueChanged += new System.EventHandler(this.cbxYear_SelectedValueChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(20, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ปี : ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 518);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Size = new System.Drawing.Size(996, 34);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tableLayoutPanel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 81);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Size = new System.Drawing.Size(996, 437);
			this.panel3.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pnlDisplay, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 431);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.dgvReturn);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(499, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(3);
			this.panel7.Size = new System.Drawing.Size(490, 425);
			this.panel7.TabIndex = 1;
			// 
			// dgvReturn
			// 
			this.dgvReturn.BackgroundColor = System.Drawing.Color.White;
			this.dgvReturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReturn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvReturn.Location = new System.Drawing.Point(3, 36);
			this.dgvReturn.Name = "dgvReturn";
			this.dgvReturn.Size = new System.Drawing.Size(482, 384);
			this.dgvReturn.TabIndex = 1;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lbTotalReturn);
			this.panel8.Controls.Add(this.lbBalance);
			this.panel8.Controls.Add(this.label5);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(3);
			this.panel8.Size = new System.Drawing.Size(482, 33);
			this.panel8.TabIndex = 0;
			// 
			// lbTotalReturn
			// 
			this.lbTotalReturn.AutoSize = true;
			this.lbTotalReturn.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalReturn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalReturn.Location = new System.Drawing.Point(144, 3);
			this.lbTotalReturn.Name = "lbTotalReturn";
			this.lbTotalReturn.Size = new System.Drawing.Size(177, 25);
			this.lbTotalReturn.TabIndex = 4;
			this.lbTotalReturn.Text = "คืนทั้งหมด = 0.00 กรัม";
			this.lbTotalReturn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbBalance
			// 
			this.lbBalance.AutoSize = true;
			this.lbBalance.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbBalance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbBalance.Location = new System.Drawing.Point(321, 3);
			this.lbBalance.Name = "lbBalance";
			this.lbBalance.Size = new System.Drawing.Size(158, 25);
			this.lbBalance.TabIndex = 3;
			this.lbBalance.Text = "คงเหลือ = 0.00 กรัม";
			this.lbBalance.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(69, 25);
			this.label5.TabIndex = 2;
			this.label5.Text = "คืน วัสดุ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlDisplay.Controls.Add(this.dgvIssue);
			this.pnlDisplay.Controls.Add(this.pnlSelectedCustomerSummary);
			this.pnlDisplay.Controls.Add(this.panel6);
			this.pnlDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDisplay.Location = new System.Drawing.Point(3, 3);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Padding = new System.Windows.Forms.Padding(3);
			this.pnlDisplay.Size = new System.Drawing.Size(490, 425);
			this.pnlDisplay.TabIndex = 0;
			// 
			// dgvIssue
			// 
			this.dgvIssue.BackgroundColor = System.Drawing.Color.White;
			this.dgvIssue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvIssue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIssue.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvIssue.Location = new System.Drawing.Point(3, 36);
			this.dgvIssue.Name = "dgvIssue";
			this.dgvIssue.Size = new System.Drawing.Size(482, 323);
			this.dgvIssue.TabIndex = 3;
			this.dgvIssue.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssue_CellEnter);
			// 
			// pnlSelectedCustomerSummary
			// 
			this.pnlSelectedCustomerSummary.BackColor = System.Drawing.Color.DarkRed;
			this.pnlSelectedCustomerSummary.Controls.Add(this.panel10);
			this.pnlSelectedCustomerSummary.Controls.Add(this.lbSelectedCustomer);
			this.pnlSelectedCustomerSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSelectedCustomerSummary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlSelectedCustomerSummary.ForeColor = System.Drawing.Color.Yellow;
			this.pnlSelectedCustomerSummary.Location = new System.Drawing.Point(3, 359);
			this.pnlSelectedCustomerSummary.Name = "pnlSelectedCustomerSummary";
			this.pnlSelectedCustomerSummary.Padding = new System.Windows.Forms.Padding(3);
			this.pnlSelectedCustomerSummary.Size = new System.Drawing.Size(482, 61);
			this.pnlSelectedCustomerSummary.TabIndex = 2;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.lbTotalDeliveryForSelectedCustomer);
			this.panel10.Controls.Add(this.lbTotalSIForSelectedCustomer);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel10.Location = new System.Drawing.Point(3, 32);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(3);
			this.panel10.Size = new System.Drawing.Size(476, 26);
			this.panel10.TabIndex = 8;
			// 
			// lbTotalDeliveryForSelectedCustomer
			// 
			this.lbTotalDeliveryForSelectedCustomer.AutoSize = true;
			this.lbTotalDeliveryForSelectedCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTotalDeliveryForSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalDeliveryForSelectedCustomer.Location = new System.Drawing.Point(3, 3);
			this.lbTotalDeliveryForSelectedCustomer.Name = "lbTotalDeliveryForSelectedCustomer";
			this.lbTotalDeliveryForSelectedCustomer.Size = new System.Drawing.Size(0, 20);
			this.lbTotalDeliveryForSelectedCustomer.TabIndex = 8;
			this.lbTotalDeliveryForSelectedCustomer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbTotalSIForSelectedCustomer
			// 
			this.lbTotalSIForSelectedCustomer.AutoSize = true;
			this.lbTotalSIForSelectedCustomer.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalSIForSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalSIForSelectedCustomer.Location = new System.Drawing.Point(473, 3);
			this.lbTotalSIForSelectedCustomer.Name = "lbTotalSIForSelectedCustomer";
			this.lbTotalSIForSelectedCustomer.Size = new System.Drawing.Size(0, 20);
			this.lbTotalSIForSelectedCustomer.TabIndex = 7;
			this.lbTotalSIForSelectedCustomer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbSelectedCustomer
			// 
			this.lbSelectedCustomer.AutoSize = true;
			this.lbSelectedCustomer.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSelectedCustomer.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectedCustomer.Location = new System.Drawing.Point(3, 3);
			this.lbSelectedCustomer.Name = "lbSelectedCustomer";
			this.lbSelectedCustomer.Size = new System.Drawing.Size(0, 20);
			this.lbSelectedCustomer.TabIndex = 2;
			this.lbSelectedCustomer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbTotalDelivery);
			this.panel6.Controls.Add(this.lbSI);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 3);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(3);
			this.panel6.Size = new System.Drawing.Size(482, 33);
			this.panel6.TabIndex = 0;
			// 
			// lbTotalDelivery
			// 
			this.lbTotalDelivery.AutoSize = true;
			this.lbTotalDelivery.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalDelivery.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalDelivery.Location = new System.Drawing.Point(89, 3);
			this.lbTotalDelivery.Name = "lbTotalDelivery";
			this.lbTotalDelivery.Size = new System.Drawing.Size(215, 25);
			this.lbTotalDelivery.TabIndex = 7;
			this.lbTotalDelivery.Text = "ยืม (ส่ง) ทั้งหมด = 0.00 กรัม";
			this.lbTotalDelivery.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbSI
			// 
			this.lbSI.AutoSize = true;
			this.lbSI.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbSI.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSI.Location = new System.Drawing.Point(304, 3);
			this.lbSI.Name = "lbSI";
			this.lbSI.Size = new System.Drawing.Size(175, 25);
			this.lbSI.TabIndex = 6;
			this.lbSI.Text = "SI ทั้งหมด = 0.00 กรัม";
			this.lbSI.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(3, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 25);
			this.label4.TabIndex = 2;
			this.label4.Text = "ยืม วัสดุ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SumOfDelivery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 552);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SumOfDelivery";
			this.Text = "MATERIAL DELIVERY";
			this.Load += new System.EventHandler(this.SumOfDelivery_Load);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.pnlDisplay.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvIssue)).EndInit();
			this.pnlSelectedCustomerSummary.ResumeLayout(false);
			this.pnlSelectedCustomerSummary.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.DataGridView dgvReturn;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel pnlDisplay;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbBalance;
		private System.Windows.Forms.Label lbTotalReturn;
		private System.Windows.Forms.Label lbTotalDelivery;
		private System.Windows.Forms.Label lbSI;
		private System.Windows.Forms.DataGridView dgvIssue;
		private System.Windows.Forms.Panel pnlSelectedCustomerSummary;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Label lbTotalDeliveryForSelectedCustomer;
		private System.Windows.Forms.Label lbTotalSIForSelectedCustomer;
		private System.Windows.Forms.Label lbSelectedCustomer;
	}
}