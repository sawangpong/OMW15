namespace OMW15.Views.CastingView
{
	partial class CastingTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingTree));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ts = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.dtp = new OMControls.OMToolStripDateTimePicker();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnTotalLoss = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLossSign = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ts2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tslbTreeId = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnTreeRefress = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnWaxTreePrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvSum = new System.Windows.Forms.DataGridView();
            this.ts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.ts2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSum)).BeginInit();
            this.SuspendLayout();
            // 
            // ts
            // 
            this.ts.AutoSize = false;
            this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.dtp,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator6,
            this.tsbtnTotalLoss,
            this.toolStripSeparator8,
            this.tsbtnClose,
            this.toolStripSeparator3});
            this.ts.Location = new System.Drawing.Point(5, 5);
            this.ts.Name = "ts";
            this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ts.Size = new System.Drawing.Size(880, 41);
            this.ts.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 38);
            this.toolStripLabel1.Text = "วันทำงาน :";
            // 
            // dtp
            // 
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(100, 38);
            this.dtp.Text = "08/12/2015";
            this.dtp.Value = new System.DateTime(2015, 12, 8, 0, 0, 0, 0);
            this.dtp.DateSelected += new System.EventHandler(this.dtp_DateSelected);
            this.dtp.TextChanged += new System.EventHandler(this.dtp_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(23, 38);
            this.tsbtnRefresh.ToolTipText = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbtnTotalLoss
            // 
            this.tsbtnTotalLoss.AutoSize = false;
            this.tsbtnTotalLoss.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTotalLoss.Image")));
            this.tsbtnTotalLoss.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTotalLoss.Name = "tsbtnTotalLoss";
            this.tsbtnTotalLoss.Size = new System.Drawing.Size(100, 44);
            this.tsbtnTotalLoss.Text = "Total Loss";
            this.tsbtnTotalLoss.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbtnTotalLoss.Click += new System.EventHandler(this.tsbtnTotalLoss_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbtnClose
            // 
            this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnClose.AutoSize = false;
            this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
            this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnClose.Name = "tsbtnClose";
            this.tsbtnClose.Size = new System.Drawing.Size(70, 47);
            this.tsbtnClose.Text = "&Close";
            this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLossSign);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 503);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(880, 25);
            this.panel1.TabIndex = 1;
            // 
            // lbLossSign
            // 
            this.lbLossSign.AutoSize = true;
            this.lbLossSign.BackColor = System.Drawing.Color.Orange;
            this.lbLossSign.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbLossSign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLossSign.Location = new System.Drawing.Point(3, 3);
            this.lbLossSign.Name = "lbLossSign";
            this.lbLossSign.Size = new System.Drawing.Size(135, 17);
            this.lbLossSign.TabIndex = 0;
            this.lbLossSign.Text = "***Loss over limit***";
            this.lbLossSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 46);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(880, 457);
            this.panel2.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dgv);
            this.panel4.Controls.Add(this.ts2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 222);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(874, 232);
            this.panel4.TabIndex = 5;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(5, 50);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(862, 175);
            this.dgv.TabIndex = 7;
            this.dgv.VirtualMode = true;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // ts2
            // 
            this.ts2.AutoSize = false;
            this.ts2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.toolStripSeparator4,
            this.tsbtnEdit,
            this.toolStripSeparator5,
            this.tslbTreeId,
            this.tsbtnTreeRefress,
            this.toolStripSeparator7,
            this.tsbtnWaxTreePrint,
            this.toolStripSeparator1});
            this.ts2.Location = new System.Drawing.Point(5, 5);
            this.ts2.Name = "ts2";
            this.ts2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ts2.Size = new System.Drawing.Size(862, 45);
            this.ts2.TabIndex = 6;
            this.ts2.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.AutoSize = false;
            this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(70, 36);
            this.tsbtnAdd.Text = "&Add";
            this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.AutoSize = false;
            this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(70, 36);
            this.tsbtnEdit.Text = "&Edit";
            this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
            // 
            // tslbTreeId
            // 
            this.tslbTreeId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslbTreeId.AutoSize = false;
            this.tslbTreeId.Name = "tslbTreeId";
            this.tslbTreeId.Size = new System.Drawing.Size(86, 42);
            this.tslbTreeId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsbtnTreeRefress
            // 
            this.tsbtnTreeRefress.AutoSize = false;
            this.tsbtnTreeRefress.Image = global::OMW15.Properties.Resources.REFRESH;
            this.tsbtnTreeRefress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTreeRefress.Name = "tsbtnTreeRefress";
            this.tsbtnTreeRefress.Size = new System.Drawing.Size(70, 42);
            this.tsbtnTreeRefress.Text = "&Refress";
            this.tsbtnTreeRefress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnTreeRefress.Click += new System.EventHandler(this.tsbtnTreeRefress_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbtnWaxTreePrint
            // 
            this.tsbtnWaxTreePrint.AutoSize = false;
            this.tsbtnWaxTreePrint.Image = global::OMW15.Properties.Resources.PrintHS;
            this.tsbtnWaxTreePrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnWaxTreePrint.Name = "tsbtnWaxTreePrint";
            this.tsbtnWaxTreePrint.Size = new System.Drawing.Size(70, 42);
            this.tsbtnWaxTreePrint.Text = "&Print";
            this.tsbtnWaxTreePrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnWaxTreePrint.Click += new System.EventHandler(this.tsbtnWaxTreePrint_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 216);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(874, 6);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvSum);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(874, 213);
            this.panel3.TabIndex = 1;
            // 
            // dgvSum
            // 
            this.dgvSum.BackgroundColor = System.Drawing.Color.White;
            this.dgvSum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSum.GridColor = System.Drawing.Color.White;
            this.dgvSum.Location = new System.Drawing.Point(5, 5);
            this.dgvSum.Name = "dgvSum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSum.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSum.Size = new System.Drawing.Size(862, 201);
            this.dgvSum.TabIndex = 0;
            this.dgvSum.VirtualMode = true;
            // 
            // CastingTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 533);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ts);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CastingTree";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "CastingTree";
            this.Load += new System.EventHandler(this.CastingTree_Load);
            this.ts.ResumeLayout(false);
            this.ts.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ts2.ResumeLayout(false);
            this.ts2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSum)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private OMControls.OMToolStripDateTimePicker dtp;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgvSum;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolStrip ts2;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripLabel tslbTreeId;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton tsbtnTotalLoss;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton tsbtnTreeRefress;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tsbtnWaxTreePrint;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label lbLossSign;
	}
}