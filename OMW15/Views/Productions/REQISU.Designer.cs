namespace OMW15.Views.Productions
{
	partial class REQISU
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlIssues = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlIssueItem = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.dgvIssueItems = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.lb = new System.Windows.Forms.Label();
			this.cbxDocYear = new System.Windows.Forms.ComboBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.lbIssueItemCount = new System.Windows.Forms.Label();
			this.btnLoadIssueItems = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			this.pnlIssues.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlIssueItem.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIssueItems)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(910, 42);
			this.panel1.TabIndex = 0;
			this.panel1.Visible = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pnlIssueItem);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.pnlIssues);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 45);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel2.Size = new System.Drawing.Size(910, 439);
			this.panel2.TabIndex = 2;
			// 
			// pnlIssues
			// 
			this.pnlIssues.Controls.Add(this.dgv);
			this.pnlIssues.Controls.Add(this.panel3);
			this.pnlIssues.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlIssues.Location = new System.Drawing.Point(4, 4);
			this.pnlIssues.Name = "pnlIssues";
			this.pnlIssues.Padding = new System.Windows.Forms.Padding(5);
			this.pnlIssues.Size = new System.Drawing.Size(402, 431);
			this.pnlIssues.TabIndex = 5;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnLoad);
			this.panel3.Controls.Add(this.cbxDocYear);
			this.panel3.Controls.Add(this.lb);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 5);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(5);
			this.panel3.Size = new System.Drawing.Size(392, 38);
			this.panel3.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(406, 4);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(9, 431);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// pnlIssueItem
			// 
			this.pnlIssueItem.Controls.Add(this.dgvIssueItems);
			this.pnlIssueItem.Controls.Add(this.panel5);
			this.pnlIssueItem.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlIssueItem.Location = new System.Drawing.Point(415, 4);
			this.pnlIssueItem.Name = "pnlIssueItem";
			this.pnlIssueItem.Padding = new System.Windows.Forms.Padding(2);
			this.pnlIssueItem.Size = new System.Drawing.Size(491, 431);
			this.pnlIssueItem.TabIndex = 7;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnLoadIssueItems);
			this.panel5.Controls.Add(this.lbIssueItemCount);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(487, 38);
			this.panel5.TabIndex = 0;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 43);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(392, 383);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// dgvIssueItems
			// 
			this.dgvIssueItems.BackgroundColor = System.Drawing.Color.White;
			this.dgvIssueItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIssueItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvIssueItems.Location = new System.Drawing.Point(2, 40);
			this.dgvIssueItems.Name = "dgvIssueItems";
			this.dgvIssueItems.Size = new System.Drawing.Size(487, 389);
			this.dgvIssueItems.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "ปี:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lb
			// 
			this.lb.Dock = System.Windows.Forms.DockStyle.Right;
			this.lb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb.Location = new System.Drawing.Point(261, 5);
			this.lb.Name = "lb";
			this.lb.Size = new System.Drawing.Size(126, 28);
			this.lb.TabIndex = 2;
			this.lb.Text = "0 รายการ";
			this.lb.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// cbxDocYear
			// 
			this.cbxDocYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxDocYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDocYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxDocYear.FormattingEnabled = true;
			this.cbxDocYear.Location = new System.Drawing.Point(43, 5);
			this.cbxDocYear.Name = "cbxDocYear";
			this.cbxDocYear.Size = new System.Drawing.Size(83, 28);
			this.cbxDocYear.TabIndex = 3;
			this.cbxDocYear.SelectionChangeCommitted += new System.EventHandler(this.cbxDocYear_SelectionChangeCommitted);
			// 
			// btnLoad
			// 
			this.btnLoad.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoad.Location = new System.Drawing.Point(126, 5);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(129, 28);
			this.btnLoad.TabIndex = 4;
			this.btnLoad.Text = "ใบแปร";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// lbIssueItemCount
			// 
			this.lbIssueItemCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbIssueItemCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbIssueItemCount.Location = new System.Drawing.Point(356, 5);
			this.lbIssueItemCount.Name = "lbIssueItemCount";
			this.lbIssueItemCount.Size = new System.Drawing.Size(126, 28);
			this.lbIssueItemCount.TabIndex = 3;
			this.lbIssueItemCount.Text = "0 รายการ";
			this.lbIssueItemCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnLoadIssueItems
			// 
			this.btnLoadIssueItems.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadIssueItems.Location = new System.Drawing.Point(5, 5);
			this.btnLoadIssueItems.Name = "btnLoadIssueItems";
			this.btnLoadIssueItems.Size = new System.Drawing.Size(157, 28);
			this.btnLoadIssueItems.TabIndex = 5;
			this.btnLoadIssueItems.Text = "Load [xxxx]";
			this.btnLoadIssueItems.UseVisualStyleBackColor = true;
			this.btnLoadIssueItems.Click += new System.EventHandler(this.btnLoadIssueItems_Click);
			// 
			// REQISU
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(916, 487);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "REQISU";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "REQISU";
			this.Load += new System.EventHandler(this.REQISU_Load);
			this.panel2.ResumeLayout(false);
			this.pnlIssues.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlIssueItem.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIssueItems)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnlIssueItem;
		private System.Windows.Forms.DataGridView dgvIssueItems;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlIssues;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox cbxDocYear;
		private System.Windows.Forms.Label lb;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label lbIssueItemCount;
		private System.Windows.Forms.Button btnLoadIssueItems;
	}
}