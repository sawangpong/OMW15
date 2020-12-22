namespace OMW15.Views.CastingView
{
	partial class JobOrderProgressStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobOrderProgressStatus));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lb80 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbCount = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtJobNo = new System.Windows.Forms.TextBox();
			this.btnSearchJob = new OMControls.OMFlatButton();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsmnuJobStatus = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbCloseYear = new System.Windows.Forms.ToolStripLabel();
			this.tscbxCloseYear = new System.Windows.Forms.ToolStripComboBox();
			this.tsSepCloseYear = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnLoadData = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.ts.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 372);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(899, 62);
			this.panel1.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lb80);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Controls.Add(this.lbCount);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(4, 4);
			this.panel5.Margin = new System.Windows.Forms.Padding(4);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(891, 28);
			this.panel5.TabIndex = 0;
			// 
			// lb80
			// 
			this.lb80.BackColor = System.Drawing.Color.DarkBlue;
			this.lb80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lb80.Dock = System.Windows.Forms.DockStyle.Left;
			this.lb80.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lb80.ForeColor = System.Drawing.Color.Yellow;
			this.lb80.Location = new System.Drawing.Point(513, 0);
			this.lb80.Name = "lb80";
			this.lb80.Size = new System.Drawing.Size(128, 28);
			this.lb80.TabIndex = 4;
			this.lb80.Text = "Progress > 80%";
			this.lb80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.White;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(344, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(169, 28);
			this.label3.TabIndex = 3;
			this.label3.Text = "Progress > 10% & <= 80%";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Red;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Yellow;
			this.label2.Location = new System.Drawing.Point(216, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "Progress <= 10%";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Location = new System.Drawing.Point(0, 0);
			this.lbCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(216, 28);
			this.lbCount.TabIndex = 0;
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.ts);
			this.panel2.Controls.Add(this.pnlHeader);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(4);
			this.panel2.Size = new System.Drawing.Size(899, 108);
			this.panel2.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtJobNo);
			this.panel4.Controls.Add(this.btnSearchJob);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(4, 40);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(891, 28);
			this.panel4.TabIndex = 3;
			// 
			// txtJobNo
			// 
			this.txtJobNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtJobNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtJobNo.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtJobNo.Location = new System.Drawing.Point(713, 1);
			this.txtJobNo.MaxLength = 15;
			this.txtJobNo.Name = "txtJobNo";
			this.txtJobNo.Size = new System.Drawing.Size(151, 25);
			this.txtJobNo.TabIndex = 1;
			this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
			this.txtJobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
			// 
			// btnSearchJob
			// 
			this.btnSearchJob.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchJob.FlatAppearance.BorderSize = 0;
			this.btnSearchJob.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchJob.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchJob.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchJob.Image")));
			this.btnSearchJob.Location = new System.Drawing.Point(864, 1);
			this.btnSearchJob.Name = "btnSearchJob";
			this.btnSearchJob.Size = new System.Drawing.Size(26, 26);
			this.btnSearchJob.TabIndex = 0;
			this.btnSearchJob.UseVisualStyleBackColor = true;
			this.btnSearchJob.Click += new System.EventHandler(this.btnSearchJob_Click);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuJobStatus,
            this.toolStripSeparator3,
            this.tslbCloseYear,
            this.tscbxCloseYear,
            this.tsSepCloseYear,
            this.tsbtnLoadData,
            this.toolStripSeparator4,
            this.tsbtnClose,
            this.toolStripSeparator2});
			this.ts.Location = new System.Drawing.Point(4, 73);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(891, 31);
			this.ts.TabIndex = 2;
			// 
			// tsmnuJobStatus
			// 
			this.tsmnuJobStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsmnuJobStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsmnuJobStatus.Image = ((System.Drawing.Image)(resources.GetObject("tsmnuJobStatus.Image")));
			this.tsmnuJobStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsmnuJobStatus.Name = "tsmnuJobStatus";
			this.tsmnuJobStatus.Size = new System.Drawing.Size(81, 28);
			this.tsmnuJobStatus.Text = "Job Status";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// tslbCloseYear
			// 
			this.tslbCloseYear.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tslbCloseYear.Name = "tslbCloseYear";
			this.tslbCloseYear.Size = new System.Drawing.Size(52, 28);
			this.tslbCloseYear.Text = "ปีที่ปิด :";
			// 
			// tscbxCloseYear
			// 
			this.tscbxCloseYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxCloseYear.Name = "tscbxCloseYear";
			this.tscbxCloseYear.Size = new System.Drawing.Size(121, 31);
			this.tscbxCloseYear.SelectedIndexChanged += new System.EventHandler(this.tscbxCloseYear_SelectedIndexChanged);
			// 
			// tsSepCloseYear
			// 
			this.tsSepCloseYear.Name = "tsSepCloseYear";
			this.tsSepCloseYear.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnLoadData
			// 
			this.tsbtnLoadData.Image = global::OMW15.Properties.Resources.otheroptions;
			this.tsbtnLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnLoadData.Name = "tsbtnLoadData";
			this.tsbtnLoadData.Size = new System.Drawing.Size(88, 28);
			this.tsbtnLoadData.Text = "Load Data";
			this.tsbtnLoadData.Click += new System.EventHandler(this.tsbtnLoadData_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 28);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.DarkRed;
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.ForeColor = System.Drawing.Color.Salmon;
			this.pnlHeader.Location = new System.Drawing.Point(4, 4);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(891, 36);
			this.pnlHeader.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Yellow;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 36);
			this.label1.TabIndex = 1;
			this.label1.Text = "JOB ORDER PROGRESS";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 108);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(5);
			this.panel3.Size = new System.Drawing.Size(899, 264);
			this.panel3.TabIndex = 2;
			// 
			// dgv
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 5);
			this.dgv.Margin = new System.Windows.Forms.Padding(4);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.Size = new System.Drawing.Size(889, 254);
			this.dgv.TabIndex = 0;
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			// 
			// JobOrderProgressStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(899, 434);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "JobOrderProgressStatus";
			this.Text = "JOB ORDER PROGRESS STATUS";
			this.Load += new System.EventHandler(this.JobOrderUpdateStatus_Load);
			this.Resize += new System.EventHandler(this.JobOrderUpdateStatus_Resize);
			this.panel1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlHeader.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripButton tsbtnLoadData;
		private System.Windows.Forms.ToolStripSeparator tsSepCloseYear;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.ToolStripDropDownButton tsmnuJobStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripLabel tslbCloseYear;
		private System.Windows.Forms.ToolStripComboBox tscbxCloseYear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.Panel panel4;
		private OMControls.OMFlatButton btnSearchJob;
		private System.Windows.Forms.TextBox txtJobNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lb80;
		private System.Windows.Forms.Label label3;
	}
}