namespace OMW15.Casting.CastingView
{
	partial class JobPrintViewer
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
			if(disposing && (components != null))
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
			this.components = new System.ComponentModel.Container();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			this.JobOrderDataItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.bgw = new System.ComponentModel.BackgroundWorker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			((System.ComponentModel.ISupportInitialize)(this.JobOrderDataItemBindingSource)).BeginInit();
			this.pnlTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// JobOrderDataItemBindingSource
			// 
			this.JobOrderDataItemBindingSource.DataSource = typeof(OMW15.Casting.CastingController.CastingJobOrderDataItem);
			// 
			// pnlTitle
			// 
			this.pnlTitle.BackColor = System.Drawing.SystemColors.HotTrack;
			this.pnlTitle.Controls.Add(this.lbTitle);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.ForeColor = System.Drawing.SystemColors.Info;
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTitle.Size = new System.Drawing.Size(743, 38);
			this.pnlTitle.TabIndex = 1;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(739, 34);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "TITLE";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bgw
			// 
			this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
			// 
			// panel1
			// 
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(543, 38);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 408);
			this.panel1.TabIndex = 3;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSet1";
			reportDataSource1.Value = this.JobOrderDataItemBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "";
			this.reportViewer1.Location = new System.Drawing.Point(0, 38);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ShowBackButton = false;
			this.reportViewer1.ShowCredentialPrompts = false;
			this.reportViewer1.ShowDocumentMapButton = false;
			this.reportViewer1.ShowParameterPrompts = false;
			this.reportViewer1.ShowProgress = false;
			this.reportViewer1.ShowPromptAreaButton = false;
			this.reportViewer1.Size = new System.Drawing.Size(543, 408);
			this.reportViewer1.TabIndex = 4;
			this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
			// 
			// JobPrintViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(743, 446);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlTitle);
			this.Name = "JobPrintViewer";
			this.Text = "JobPrintViewer";
			this.Load += new System.EventHandler(this.JobPrintViewer_Load);
			((System.ComponentModel.ISupportInitialize)(this.JobOrderDataItemBindingSource)).EndInit();
			this.pnlTitle.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.BindingSource JobOrderDataItemBindingSource;
		private System.Windows.Forms.Panel pnlTitle;
		private System.ComponentModel.BackgroundWorker bgw;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
	}
}