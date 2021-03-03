namespace OMW15.Views.Productions.ProductionReports
{
	partial class ReportQuery
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
			this.pnlRight = new System.Windows.Forms.Panel();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pnlYear = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkMonth = new System.Windows.Forms.CheckBox();
			this.pnlMonth = new System.Windows.Forms.Panel();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnReport = new System.Windows.Forms.Button();
			this.lbYear = new System.Windows.Forms.Label();
			this.lbMonth = new System.Windows.Forms.Label();
			this.pnlRight.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pnlYear.SuspendLayout();
			this.pnlMonth.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.btnReport);
			this.pnlRight.Controls.Add(this.btnClose);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlRight.Location = new System.Drawing.Point(475, 0);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(10, 50, 10, 10);
			this.pnlRight.Size = new System.Drawing.Size(147, 221);
			this.pnlRight.TabIndex = 0;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.groupBox1);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(20);
			this.pnlLeft.Size = new System.Drawing.Size(475, 221);
			this.pnlLeft.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.pnlMonth);
			this.groupBox1.Controls.Add(this.pnlYear);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(20, 20);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
			this.groupBox1.Size = new System.Drawing.Size(435, 181);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Report Query parameters";
			// 
			// pnlYear
			// 
			this.pnlYear.Controls.Add(this.lbYear);
			this.pnlYear.Controls.Add(this.chkMonth);
			this.pnlYear.Controls.Add(this.cbxYear);
			this.pnlYear.Controls.Add(this.label1);
			this.pnlYear.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlYear.Location = new System.Drawing.Point(3, 33);
			this.pnlYear.Name = "pnlYear";
			this.pnlYear.Padding = new System.Windows.Forms.Padding(5);
			this.pnlYear.Size = new System.Drawing.Size(429, 35);
			this.pnlYear.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(5, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Year:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(61, 5);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(100, 25);
			this.cbxYear.TabIndex = 1;
			this.cbxYear.SelectionChangeCommitted += new System.EventHandler(this.cbxYear_SelectionChangeCommitted);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(10, 179);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(127, 32);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// chkMonth
			// 
			this.chkMonth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkMonth.Checked = true;
			this.chkMonth.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMonth.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkMonth.Location = new System.Drawing.Point(229, 5);
			this.chkMonth.Name = "chkMonth";
			this.chkMonth.Size = new System.Drawing.Size(195, 25);
			this.chkMonth.TabIndex = 2;
			this.chkMonth.Text = "Separate report by month";
			this.chkMonth.UseVisualStyleBackColor = true;
			this.chkMonth.CheckedChanged += new System.EventHandler(this.chkMonth_CheckedChanged);
			// 
			// pnlMonth
			// 
			this.pnlMonth.Controls.Add(this.lbMonth);
			this.pnlMonth.Controls.Add(this.cbxMonth);
			this.pnlMonth.Controls.Add(this.label2);
			this.pnlMonth.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMonth.Location = new System.Drawing.Point(3, 68);
			this.pnlMonth.Name = "pnlMonth";
			this.pnlMonth.Padding = new System.Windows.Forms.Padding(5);
			this.pnlMonth.Size = new System.Drawing.Size(429, 35);
			this.pnlMonth.TabIndex = 2;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(61, 5);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(100, 25);
			this.cbxMonth.TabIndex = 1;
			this.cbxMonth.SelectedValueChanged += new System.EventHandler(this.cbxMonth_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(5, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 25);
			this.label2.TabIndex = 0;
			this.label2.Text = "Month:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnReport
			// 
			this.btnReport.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReport.Location = new System.Drawing.Point(10, 50);
			this.btnReport.Name = "btnReport";
			this.btnReport.Size = new System.Drawing.Size(127, 37);
			this.btnReport.TabIndex = 1;
			this.btnReport.Text = "Report";
			this.btnReport.UseVisualStyleBackColor = true;
			this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
			// 
			// lbYear
			// 
			this.lbYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbYear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbYear.Location = new System.Drawing.Point(161, 5);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(62, 25);
			this.lbYear.TabIndex = 3;
			this.lbYear.Text = "0";
			this.lbYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbMonth
			// 
			this.lbMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMonth.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbMonth.Location = new System.Drawing.Point(161, 5);
			this.lbMonth.Name = "lbMonth";
			this.lbMonth.Size = new System.Drawing.Size(62, 25);
			this.lbMonth.TabIndex = 4;
			this.lbMonth.Text = "0";
			this.lbMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ReportQuery
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(622, 221);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlRight);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ReportQuery";
			this.Text = "Report Query";
			this.Load += new System.EventHandler(this.ReportQuery_Load);
			this.pnlRight.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.pnlYear.ResumeLayout(false);
			this.pnlMonth.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel pnlYear;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.CheckBox chkMonth;
		private System.Windows.Forms.Panel pnlMonth;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnReport;
		private System.Windows.Forms.Label lbMonth;
		private System.Windows.Forms.Label lbYear;
	}
}