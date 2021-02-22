namespace OMW15.Views.Productions
{
	partial class ProductionSendStock
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
			this.st = new System.Windows.Forms.StatusStrip();
			this.stlbRow = new System.Windows.Forms.ToolStripStatusLabel();
			this.stlbTotalCost = new System.Windows.Forms.ToolStripStatusLabel();
			this.stlbTotalQty = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnReload = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAddIssue = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.st.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(687, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(463, 46);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "ใบแปร";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// st
			// 
			this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stlbRow,
            this.stlbTotalCost,
            this.stlbTotalQty});
			this.st.Location = new System.Drawing.Point(0, 334);
			this.st.Name = "st";
			this.st.Size = new System.Drawing.Size(687, 22);
			this.st.TabIndex = 1;
			// 
			// stlbRow
			// 
			this.stlbRow.Name = "stlbRow";
			this.stlbRow.Size = new System.Drawing.Size(36, 17);
			this.stlbRow.Text = "0 row";
			// 
			// stlbTotalCost
			// 
			this.stlbTotalCost.Name = "stlbTotalCost";
			this.stlbTotalCost.Size = new System.Drawing.Size(68, 17);
			this.stlbTotalCost.Text = "total cost: 0";
			// 
			// stlbTotalQty
			// 
			this.stlbTotalQty.Name = "stlbTotalQty";
			this.stlbTotalQty.Size = new System.Drawing.Size(63, 17);
			this.stlbTotalQty.Text = "total qty: 0";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnReload);
			this.panel3.Controls.Add(this.btnDelete);
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Controls.Add(this.btnEdit);
			this.panel3.Controls.Add(this.btnAddIssue);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(532, 50);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(10);
			this.panel3.Size = new System.Drawing.Size(155, 284);
			this.panel3.TabIndex = 3;
			// 
			// btnReload
			// 
			this.btnReload.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReload.Location = new System.Drawing.Point(10, 100);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(135, 30);
			this.btnReload.TabIndex = 4;
			this.btnReload.Text = "เรียกข้อมูล";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnDelete.Location = new System.Drawing.Point(10, 70);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(135, 30);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "ลบใบแปร";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(10, 244);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(135, 30);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "ปิด";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnEdit.Location = new System.Drawing.Point(10, 40);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(135, 30);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "แก้ไข";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAddIssue
			// 
			this.btnAddIssue.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAddIssue.Location = new System.Drawing.Point(10, 10);
			this.btnAddIssue.Name = "btnAddIssue";
			this.btnAddIssue.Size = new System.Drawing.Size(135, 30);
			this.btnAddIssue.TabIndex = 0;
			this.btnAddIssue.Text = "เพิ่มใบแปรรูป";
			this.btnAddIssue.UseVisualStyleBackColor = true;
			this.btnAddIssue.Click += new System.EventHandler(this.btnAddIssue_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgv);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(532, 284);
			this.panel2.TabIndex = 4;
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(528, 280);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// ProductionSendStock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 356);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.st);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MinimizeBox = false;
			this.Name = "ProductionSendStock";
			this.Text = "ProductionSendStock";
			this.Load += new System.EventHandler(this.ProductionSendStock_Load);
			this.panel1.ResumeLayout(false);
			this.st.ResumeLayout(false);
			this.st.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.StatusStrip st;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAddIssue;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ToolStripStatusLabel stlbRow;
		private System.Windows.Forms.ToolStripStatusLabel stlbTotalCost;
		private System.Windows.Forms.ToolStripStatusLabel stlbTotalQty;
	}
}