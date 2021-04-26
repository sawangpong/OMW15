namespace OMW15.Views.Productions
{
	partial class ProductionRequireParts
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionRequireParts));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panelBody = new System.Windows.Forms.Panel();
			this.dgv = new OMControls.Controls.ProgressDataGridView();
			this.panelCommand = new System.Windows.Forms.Panel();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbCount = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnCalParts = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnViewParentOrder = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1.SuspendLayout();
			this.panelBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panelCommand.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(933, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(244, 50);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Production Require Parts";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Location = new System.Drawing.Point(0, 566);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(933, 22);
			this.statusStrip1.TabIndex = 1;
			// 
			// panelBody
			// 
			this.panelBody.Controls.Add(this.dgv);
			this.panelBody.Controls.Add(this.panelCommand);
			this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBody.Location = new System.Drawing.Point(0, 50);
			this.panelBody.Name = "panelBody";
			this.panelBody.Padding = new System.Windows.Forms.Padding(3);
			this.panelBody.Size = new System.Drawing.Size(933, 516);
			this.panelBody.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(3, 39);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(927, 474);
			this.dgv.TabIndex = 1;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panelCommand
			// 
			this.panelCommand.Controls.Add(this.ts);
			this.panelCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelCommand.Location = new System.Drawing.Point(3, 3);
			this.panelCommand.Name = "panelCommand";
			this.panelCommand.Size = new System.Drawing.Size(927, 36);
			this.panelCommand.TabIndex = 0;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tslbCount,
            this.toolStripSeparator2,
            this.tsbtnCalParts,
            this.toolStripSeparator3,
            this.tsbtnViewParentOrder,
            this.toolStripSeparator4});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(927, 34);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(56, 31);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
			// 
			// tslbCount
			// 
			this.tslbCount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.tslbCount.Name = "tslbCount";
			this.tslbCount.Size = new System.Drawing.Size(51, 31);
			this.tslbCount.Text = "found: 0";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
			// 
			// tsbtnCalParts
			// 
			this.tsbtnCalParts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnCalParts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnCalParts.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCalParts.Image")));
			this.tsbtnCalParts.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnCalParts.Name = "tsbtnCalParts";
			this.tsbtnCalParts.Size = new System.Drawing.Size(98, 31);
			this.tsbtnCalParts.Text = "Calculate parts";
			this.tsbtnCalParts.Click += new System.EventHandler(this.tsbtnCalParts_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
			// 
			// tsbtnViewParentOrder
			// 
			this.tsbtnViewParentOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbtnViewParentOrder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnViewParentOrder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnViewParentOrder.Image")));
			this.tsbtnViewParentOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnViewParentOrder.Name = "tsbtnViewParentOrder";
			this.tsbtnViewParentOrder.Size = new System.Drawing.Size(145, 31);
			this.tsbtnViewParentOrder.Text = "View parent Job Order";
			this.tsbtnViewParentOrder.Click += new System.EventHandler(this.tsbtnViewParentOrder_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 34);
			// 
			// ProductionRequireParts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 588);
			this.Controls.Add(this.panelBody);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProductionRequireParts";
			this.Text = "Production Require Parts";
			this.Load += new System.EventHandler(this.ProductionRequireParts_Load);
			this.panel1.ResumeLayout(false);
			this.panelBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panelCommand.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panelBody;
		private OMControls.Controls.ProgressDataGridView dgv;
		private System.Windows.Forms.Panel panelCommand;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tslbCount;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnCalParts;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnViewParentOrder;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}