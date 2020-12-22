namespace OMW15.Views.WarehouseView
{
	partial class WHStockCard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHStockCard));
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.grpItemInfo = new System.Windows.Forms.GroupBox();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtOnHand = new OMControls.Controls.NumericTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtUOM = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnItemNoSearch = new OMControls.OMFlatButton();
			this.txtItemNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnReload = new System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel3.SuspendLayout();
			this.grpItemInfo.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 384);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(5);
			this.panel4.Size = new System.Drawing.Size(731, 43);
			this.panel4.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(621, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(105, 33);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.grpItemInfo);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(15);
			this.panel1.Size = new System.Drawing.Size(731, 384);
			this.panel1.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.dgv);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(15, 130);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(701, 239);
			this.panel2.TabIndex = 1;
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
			this.dgv.Location = new System.Drawing.Point(5, 60);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(689, 172);
			this.dgv.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbRowCount);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 5);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(689, 55);
			this.panel3.TabIndex = 0;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowCount.Location = new System.Drawing.Point(3, 28);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(120, 24);
			this.lbRowCount.TabIndex = 2;
			this.lbRowCount.Text = "found : 0 รายการ";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Top;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(683, 25);
			this.label5.TabIndex = 1;
			this.label5.Text = "รายละเอียดการเคลื่อนไหว";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// grpItemInfo
			// 
			this.grpItemInfo.Controls.Add(this.panel8);
			this.grpItemInfo.Controls.Add(this.panel7);
			this.grpItemInfo.Controls.Add(this.panel6);
			this.grpItemInfo.Controls.Add(this.panel5);
			this.grpItemInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpItemInfo.ForeColor = System.Drawing.Color.MediumBlue;
			this.grpItemInfo.Location = new System.Drawing.Point(15, 15);
			this.grpItemInfo.Name = "grpItemInfo";
			this.grpItemInfo.Padding = new System.Windows.Forms.Padding(5);
			this.grpItemInfo.Size = new System.Drawing.Size(701, 115);
			this.grpItemInfo.TabIndex = 0;
			this.grpItemInfo.TabStop = false;
			this.grpItemInfo.Text = "Item Information";
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtOnHand);
			this.panel8.Controls.Add(this.label4);
			this.panel8.Controls.Add(this.txtUOM);
			this.panel8.Controls.Add(this.label3);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(5, 79);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(549, 28);
			this.panel8.TabIndex = 3;
			// 
			// txtOnHand
			// 
			this.txtOnHand.BackColor = System.Drawing.Color.DeepSkyBlue;
			this.txtOnHand.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtOnHand.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOnHand.Location = new System.Drawing.Point(265, 1);
			this.txtOnHand.MaxLength = 15;
			this.txtOnHand.Name = "txtOnHand";
			this.txtOnHand.ReadOnly = true;
			this.txtOnHand.Size = new System.Drawing.Size(105, 25);
			this.txtOnHand.TabIndex = 4;
			this.txtOnHand.Text = "0.00";
			this.txtOnHand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(164, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 26);
			this.label4.TabIndex = 3;
			this.label4.Text = "จำนวนคงหเลือ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtUOM
			// 
			this.txtUOM.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUOM.Location = new System.Drawing.Point(73, 1);
			this.txtUOM.MaxLength = 15;
			this.txtUOM.Name = "txtUOM";
			this.txtUOM.ReadOnly = true;
			this.txtUOM.Size = new System.Drawing.Size(91, 25);
			this.txtUOM.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "หน่วยนับ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.txtItemName);
			this.panel7.Controls.Add(this.label2);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(5, 51);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(549, 28);
			this.panel7.TabIndex = 2;
			// 
			// txtItemName
			// 
			this.txtItemName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemName.Location = new System.Drawing.Point(73, 1);
			this.txtItemName.MaxLength = 150;
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.ReadOnly = true;
			this.txtItemName.Size = new System.Drawing.Size(382, 25);
			this.txtItemName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "ชื่อค้า ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnItemNoSearch);
			this.panel6.Controls.Add(this.txtItemNo);
			this.panel6.Controls.Add(this.label1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(5, 23);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(549, 28);
			this.panel6.TabIndex = 1;
			// 
			// btnItemNoSearch
			// 
			this.btnItemNoSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnItemNoSearch.Enabled = false;
			this.btnItemNoSearch.FlatAppearance.BorderSize = 0;
			this.btnItemNoSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnItemNoSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnItemNoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItemNoSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnItemNoSearch.Image")));
			this.btnItemNoSearch.Location = new System.Drawing.Point(209, 1);
			this.btnItemNoSearch.Name = "btnItemNoSearch";
			this.btnItemNoSearch.Size = new System.Drawing.Size(26, 26);
			this.btnItemNoSearch.TabIndex = 2;
			this.btnItemNoSearch.UseVisualStyleBackColor = true;
			// 
			// txtItemNo
			// 
			this.txtItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemNo.Location = new System.Drawing.Point(73, 1);
			this.txtItemNo.MaxLength = 25;
			this.txtItemNo.Name = "txtItemNo";
			this.txtItemNo.ReadOnly = true;
			this.txtItemNo.Size = new System.Drawing.Size(136, 25);
			this.txtItemNo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "รหัสสินค้า ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnReload);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(554, 23);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(142, 87);
			this.panel5.TabIndex = 0;
			// 
			// btnReload
			// 
			this.btnReload.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReload.Location = new System.Drawing.Point(5, 5);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(132, 29);
			this.btnReload.TabIndex = 0;
			this.btnReload.Text = "&Re-load";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// WHStockCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(731, 427);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel4);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "WHStockCard";
			this.Text = "STOCK CARD";
			this.Load += new System.EventHandler(this.WHStockCard_Load);
			this.panel4.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel3.ResumeLayout(false);
			this.grpItemInfo.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.GroupBox grpItemInfo;
		private System.Windows.Forms.Panel panel8;
		private OMControls.Controls.NumericTextBox txtOnHand;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtUOM;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.TextBox txtItemName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel6;
		private OMControls.OMFlatButton btnItemNoSearch;
		private System.Windows.Forms.TextBox txtItemNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.Label lbRowCount;
		private System.Windows.Forms.Label label5;
	}
}