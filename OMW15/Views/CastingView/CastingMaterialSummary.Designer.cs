namespace OMW15.Views.CastingView
{
	partial class CastingMaterialSummary
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTotalWeightForSelectedCustomer = new System.Windows.Forms.Label();
			this.lbTotalPendingWT = new System.Windows.Forms.Label();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnMatCard = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnDeliverySummary = new System.Windows.Forms.Button();
			this.btnReceiveMat = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxMaterialCAT = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvListSO = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCustomerName = new System.Windows.Forms.Label();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbMatSum = new System.Windows.Forms.Label();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel1.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvListSO)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlTop.Controls.Add(this.btnClose);
			this.pnlTop.Controls.Add(this.label3);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(4, 4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(4);
			this.pnlTop.Size = new System.Drawing.Size(1039, 40);
			this.pnlTop.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(933, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(100, 30);
			this.btnClose.TabIndex = 10;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(4, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(203, 30);
			this.label3.TabIndex = 9;
			this.label3.Text = "รายการสรุปยอดค้างวัสดุ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(4, 44);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgv);
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			this.splitContainer1.Panel1.Controls.Add(this.pnlCommand);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainer1.Panel1MinSize = 100;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvListSO);
			this.splitContainer1.Panel2.Controls.Add(this.panel2);
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(1039, 508);
			this.splitContainer1.SplitterDistance = 290;
			this.splitContainer1.TabIndex = 8;
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
			this.dgv.Location = new System.Drawing.Point(5, 35);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(1029, 220);
			this.dgv.TabIndex = 8;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.lbTotalWeightForSelectedCustomer);
			this.panel1.Controls.Add(this.lbTotalPendingWT);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 255);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(1029, 30);
			this.panel1.TabIndex = 7;
			// 
			// lbTotalWeightForSelectedCustomer
			// 
			this.lbTotalWeightForSelectedCustomer.AutoSize = true;
			this.lbTotalWeightForSelectedCustomer.BackColor = System.Drawing.Color.RoyalBlue;
			this.lbTotalWeightForSelectedCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTotalWeightForSelectedCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalWeightForSelectedCustomer.ForeColor = System.Drawing.Color.Yellow;
			this.lbTotalWeightForSelectedCustomer.Location = new System.Drawing.Point(2, 2);
			this.lbTotalWeightForSelectedCustomer.Name = "lbTotalWeightForSelectedCustomer";
			this.lbTotalWeightForSelectedCustomer.Size = new System.Drawing.Size(200, 21);
			this.lbTotalWeightForSelectedCustomer.TabIndex = 4;
			this.lbTotalWeightForSelectedCustomer.Text = "Pending Weight (g) = 0.00";
			this.lbTotalWeightForSelectedCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTotalPendingWT
			// 
			this.lbTotalPendingWT.AutoSize = true;
			this.lbTotalPendingWT.BackColor = System.Drawing.Color.RoyalBlue;
			this.lbTotalPendingWT.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalPendingWT.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalPendingWT.ForeColor = System.Drawing.Color.Yellow;
			this.lbTotalPendingWT.Location = new System.Drawing.Point(849, 2);
			this.lbTotalPendingWT.Name = "lbTotalPendingWT";
			this.lbTotalPendingWT.Size = new System.Drawing.Size(176, 21);
			this.lbTotalPendingWT.TabIndex = 3;
			this.lbTotalPendingWT.Text = "Total Weight (g) = 0.00";
			this.lbTotalPendingWT.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnMatCard);
			this.pnlCommand.Controls.Add(this.btnPrint);
			this.pnlCommand.Controls.Add(this.btnDeliverySummary);
			this.pnlCommand.Controls.Add(this.btnReceiveMat);
			this.pnlCommand.Controls.Add(this.btnRefresh);
			this.pnlCommand.Controls.Add(this.label2);
			this.pnlCommand.Controls.Add(this.cbxMaterialCAT);
			this.pnlCommand.Controls.Add(this.label1);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCommand.Location = new System.Drawing.Point(5, 5);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(2);
			this.pnlCommand.Size = new System.Drawing.Size(1029, 30);
			this.pnlCommand.TabIndex = 1;
			// 
			// btnMatCard
			// 
			this.btnMatCard.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnMatCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnMatCard.Location = new System.Drawing.Point(524, 2);
			this.btnMatCard.Name = "btnMatCard";
			this.btnMatCard.Size = new System.Drawing.Size(111, 26);
			this.btnMatCard.TabIndex = 10;
			this.btnMatCard.Text = "Material Card";
			this.btnMatCard.UseVisualStyleBackColor = true;
			this.btnMatCard.Visible = false;
			this.btnMatCard.Click += new System.EventHandler(this.btnMatCard_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnPrint.Image = global::OMW15.Properties.Resources.PrintHS;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.Location = new System.Drawing.Point(948, 2);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(79, 26);
			this.btnPrint.TabIndex = 9;
			this.btnPrint.Text = "พิมพ์";
			this.btnPrint.UseVisualStyleBackColor = true;
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnDeliverySummary
			// 
			this.btnDeliverySummary.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnDeliverySummary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDeliverySummary.Location = new System.Drawing.Point(362, 2);
			this.btnDeliverySummary.Name = "btnDeliverySummary";
			this.btnDeliverySummary.Size = new System.Drawing.Size(162, 26);
			this.btnDeliverySummary.TabIndex = 8;
			this.btnDeliverySummary.Text = "สรุปรายการยืม / คืนวัสดุ";
			this.btnDeliverySummary.UseVisualStyleBackColor = true;
			this.btnDeliverySummary.Click += new System.EventHandler(this.btnDeliverySummary_Click);
			// 
			// btnReceiveMat
			// 
			this.btnReceiveMat.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnReceiveMat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReceiveMat.Location = new System.Drawing.Point(270, 2);
			this.btnReceiveMat.Name = "btnReceiveMat";
			this.btnReceiveMat.Size = new System.Drawing.Size(92, 26);
			this.btnReceiveMat.TabIndex = 6;
			this.btnReceiveMat.Text = "รับคืนวัสดุ";
			this.btnReceiveMat.UseVisualStyleBackColor = true;
			this.btnReceiveMat.Click += new System.EventHandler(this.btnReceiveMat_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefresh.Location = new System.Drawing.Point(180, 2);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(90, 26);
			this.btnRefresh.TabIndex = 5;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(175, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(5, 26);
			this.label2.TabIndex = 4;
			// 
			// cbxMaterialCAT
			// 
			this.cbxMaterialCAT.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterialCAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterialCAT.FormattingEnabled = true;
			this.cbxMaterialCAT.Location = new System.Drawing.Point(60, 2);
			this.cbxMaterialCAT.Name = "cbxMaterialCAT";
			this.cbxMaterialCAT.Size = new System.Drawing.Size(115, 25);
			this.cbxMaterialCAT.TabIndex = 1;
			this.cbxMaterialCAT.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialCAT_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "กลุ่่มวัสดุ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvListSO
			// 
			this.dgvListSO.BackgroundColor = System.Drawing.Color.White;
			this.dgvListSO.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvListSO.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgvListSO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvListSO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvListSO.Location = new System.Drawing.Point(5, 35);
			this.dgvListSO.Name = "dgvListSO";
			this.dgvListSO.Size = new System.Drawing.Size(1029, 144);
			this.dgvListSO.TabIndex = 8;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.lbCustomerName);
			this.panel2.Controls.Add(this.lbCustCode);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 5);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(1029, 30);
			this.panel2.TabIndex = 7;
			// 
			// lbCustomerName
			// 
			this.lbCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustomerName.Location = new System.Drawing.Point(93, 2);
			this.lbCustomerName.Name = "lbCustomerName";
			this.lbCustomerName.Size = new System.Drawing.Size(932, 24);
			this.lbCustomerName.TabIndex = 8;
			this.lbCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCustCode
			// 
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustCode.Location = new System.Drawing.Point(2, 2);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(91, 24);
			this.lbCustCode.TabIndex = 7;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.RoyalBlue;
			this.panel3.Controls.Add(this.lbMatSum);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.ForeColor = System.Drawing.Color.Yellow;
			this.panel3.Location = new System.Drawing.Point(5, 179);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(1029, 30);
			this.panel3.TabIndex = 6;
			// 
			// lbMatSum
			// 
			this.lbMatSum.AutoSize = true;
			this.lbMatSum.BackColor = System.Drawing.Color.RoyalBlue;
			this.lbMatSum.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMatSum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMatSum.ForeColor = System.Drawing.Color.Yellow;
			this.lbMatSum.Location = new System.Drawing.Point(2, 2);
			this.lbMatSum.Name = "lbMatSum";
			this.lbMatSum.Size = new System.Drawing.Size(176, 21);
			this.lbMatSum.TabIndex = 0;
			this.lbMatSum.Text = "Total Weight (g) = 0.00";
			this.lbMatSum.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// CastingMaterialSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1047, 556);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingMaterialSummary";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "SUMMARY CASTING MATERIAL";
			this.Load += new System.EventHandler(this.CastingMaterialSummary_Load);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvListSO)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnReceiveMat;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxMaterialCAT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvListSO;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbCustomerName;
		private System.Windows.Forms.Label lbCustCode;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbMatSum;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbTotalPendingWT;
		private System.Windows.Forms.Label lbTotalWeightForSelectedCustomer;
		private System.Windows.Forms.Button btnDeliverySummary;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Button btnMatCard;
		private System.Windows.Forms.Button btnClose;
	}
}