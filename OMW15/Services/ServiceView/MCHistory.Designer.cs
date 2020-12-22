namespace OMW15.Services.ServiceView
{
	partial class MCHistory
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
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tscbxModel = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSN = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnSN = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnFindMachine = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.pnlCustomer = new System.Windows.Forms.Panel();
			this.btnPrintHTMLReport = new System.Windows.Forms.Button();
			this.lbOwnerName = new System.Windows.Forms.Label();
			this.lbOwnerCode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.ts.SuspendLayout();
			this.pnlCustomer.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tscbxModel,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tstxtSN,
            this.tsbtnSN,
            this.toolStripSeparator3,
            this.tsbtnFindMachine,
            this.toolStripSeparator4,
            this.tsbtnClose,
            this.toolStripSeparator5});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(873, 31);
			this.ts.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(77, 28);
			this.toolStripLabel1.Text = "รุ่นเครื่องจักร :";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// tscbxModel
			// 
			this.tscbxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxModel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxModel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscbxModel.Name = "tscbxModel";
			this.tscbxModel.Size = new System.Drawing.Size(300, 31);
			this.tscbxModel.SelectedIndexChanged += new System.EventHandler(this.tscbxModel_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(121, 28);
			this.toolStripLabel2.Text = "หมายเลขเครื่องจักร:";
			// 
			// tstxtSN
			// 
			this.tstxtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstxtSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tstxtSN.Name = "tstxtSN";
			this.tstxtSN.Size = new System.Drawing.Size(121, 31);
			this.tstxtSN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstxtSN_KeyPress);
			// 
			// tsbtnSN
			// 
			this.tsbtnSN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSN.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSN.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSN.Name = "tsbtnSN";
			this.tsbtnSN.Size = new System.Drawing.Size(23, 28);
			this.tsbtnSN.Text = "toolStripButton2";
			this.tsbtnSN.Click += new System.EventHandler(this.tsbtnSN_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnFindMachine
			// 
			this.tsbtnFindMachine.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnFindMachine.Image = global::OMW15.Properties.Resources.apply;
			this.tsbtnFindMachine.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnFindMachine.Name = "tsbtnFindMachine";
			this.tsbtnFindMachine.Size = new System.Drawing.Size(91, 28);
			this.tsbtnFindMachine.Text = "แสดงรายการ";
			this.tsbtnFindMachine.Click += new System.EventHandler(this.tsbtnFindMachine_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(23, 28);
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
			// 
			// pnlCustomer
			// 
			this.pnlCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlCustomer.Controls.Add(this.btnPrintHTMLReport);
			this.pnlCustomer.Controls.Add(this.lbOwnerName);
			this.pnlCustomer.Controls.Add(this.lbOwnerCode);
			this.pnlCustomer.Controls.Add(this.label1);
			this.pnlCustomer.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCustomer.Location = new System.Drawing.Point(0, 31);
			this.pnlCustomer.Name = "pnlCustomer";
			this.pnlCustomer.Padding = new System.Windows.Forms.Padding(2);
			this.pnlCustomer.Size = new System.Drawing.Size(873, 34);
			this.pnlCustomer.TabIndex = 1;
			// 
			// btnPrintHTMLReport
			// 
			this.btnPrintHTMLReport.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnPrintHTMLReport.Location = new System.Drawing.Point(543, 2);
			this.btnPrintHTMLReport.Name = "btnPrintHTMLReport";
			this.btnPrintHTMLReport.Size = new System.Drawing.Size(147, 28);
			this.btnPrintHTMLReport.TabIndex = 3;
			this.btnPrintHTMLReport.Text = "Print Report";
			this.btnPrintHTMLReport.UseVisualStyleBackColor = true;
			this.btnPrintHTMLReport.Click += new System.EventHandler(this.btnPrintHTMLReport_Click);
			// 
			// lbOwnerName
			// 
			this.lbOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbOwnerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbOwnerName.Location = new System.Drawing.Point(136, 2);
			this.lbOwnerName.Name = "lbOwnerName";
			this.lbOwnerName.Size = new System.Drawing.Size(407, 28);
			this.lbOwnerName.TabIndex = 2;
			this.lbOwnerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbOwnerCode
			// 
			this.lbOwnerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbOwnerCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbOwnerCode.Location = new System.Drawing.Point(50, 2);
			this.lbOwnerCode.Name = "lbOwnerCode";
			this.lbOwnerCode.Size = new System.Drawing.Size(86, 28);
			this.lbOwnerCode.TabIndex = 1;
			this.lbOwnerCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "ลูกค้า:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.dgv);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(0, 65);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(2);
			this.pnlLeft.Size = new System.Drawing.Size(244, 446);
			this.pnlLeft.TabIndex = 2;
			// 
			// dgv
			// 
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Yellow;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			this.dgv.Size = new System.Drawing.Size(240, 442);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(244, 65);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 446);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.webBrowser1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(247, 65);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(626, 446);
			this.panel1.TabIndex = 4;
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(2, 2);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScriptErrorsSuppressed = true;
			this.webBrowser1.Size = new System.Drawing.Size(622, 442);
			this.webBrowser1.TabIndex = 1;
			this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
			this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			// 
			// MCHistory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 511);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlCustomer);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MCHistory";
			this.Text = "MACHINE HISTORIES";
			this.Load += new System.EventHandler(this.MCHistory_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.pnlCustomer.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripComboBox tscbxModel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnFindMachine;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.Panel pnlCustomer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbOwnerCode;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label lbOwnerName;
		private System.Windows.Forms.ToolStripTextBox tstxtSN;
		private System.Windows.Forms.ToolStripButton tsbtnSN;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button btnPrintHTMLReport;
	}
}