namespace OMW15.Views.Productions.ProductionReports
{
	partial class ProductionReportViewer
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
			this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			// 
			// crv
			// 
			this.crv.ActiveViewIndex = -1;
			this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crv.Cursor = System.Windows.Forms.Cursors.Default;
			this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crv.Location = new System.Drawing.Point(0, 0);
			this.crv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.crv.Name = "crv";
			this.crv.Size = new System.Drawing.Size(947, 626);
			this.crv.TabIndex = 0;
			this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			this.crv.ToolPanelWidth = 233;
			this.crv.Load += new System.EventHandler(this.ProductionReportViewer_Load);
			// 
			// ProductionReportViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 626);
			this.Controls.Add(this.crv);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProductionReportViewer";
			this.Text = "Production Report Viewer";
			this.Load += new System.EventHandler(this.ProductionReportViewer_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
	}
}