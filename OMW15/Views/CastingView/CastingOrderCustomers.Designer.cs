namespace OMW15.Views.CastingView
{
	partial class CastingOrderCustomers
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFilterCustomer = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlBodyTop = new System.Windows.Forms.Panel();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.ts.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlBodyTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSelect);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 301);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(584, 41);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(483, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(96, 31);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(5, 5);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(96, 31);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRefresh,
            this.toolStripSeparator1,
            this.tsbtnFilterCustomer,
            this.toolStripSeparator2});
			this.ts.Location = new System.Drawing.Point(2, 2);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(584, 45);
			this.ts.TabIndex = 1;
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(65, 42);
			this.tsbtnRefresh.Text = "&Refesh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnFilterCustomer
			// 
			this.tsbtnFilterCustomer.AutoSize = false;
			this.tsbtnFilterCustomer.Image = global::OMW15.Properties.Resources.Filter2HS;
			this.tsbtnFilterCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFilterCustomer.Name = "tsbtnFilterCustomer";
			this.tsbtnFilterCustomer.Size = new System.Drawing.Size(65, 42);
			this.tsbtnFilterCustomer.Text = "&ค้นหา";
			this.tsbtnFilterCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnFilterCustomer.Click += new System.EventHandler(this.tsbtnFilterCustomer_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// pnlBody
			// 
			this.pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Controls.Add(this.pnlBodyTop);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(2, 47);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(3);
			this.pnlBody.Size = new System.Drawing.Size(584, 254);
			this.pnlBody.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 31);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(576, 218);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlBodyTop
			// 
			this.pnlBodyTop.Controls.Add(this.lbRowCount);
			this.pnlBodyTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBodyTop.Location = new System.Drawing.Point(3, 3);
			this.pnlBodyTop.Name = "pnlBodyTop";
			this.pnlBodyTop.Padding = new System.Windows.Forms.Padding(1);
			this.pnlBodyTop.Size = new System.Drawing.Size(576, 28);
			this.pnlBodyTop.TabIndex = 0;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbRowCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowCount.Location = new System.Drawing.Point(477, 1);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(98, 26);
			this.lbRowCount.TabIndex = 0;
			this.lbRowCount.Text = "found : 0";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CastingOrderCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 344);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingOrderCustomers";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "CUSTOMERS";
			this.Load += new System.EventHandler(this.CastingOrderCustomers_Load);
			this.panel1.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlBodyTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnFilterCustomer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlBodyTop;
		private System.Windows.Forms.Label lbRowCount;
	}
}