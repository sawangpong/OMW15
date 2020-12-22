namespace OMW15.Views.CastingView
{
	partial class CastingWebReport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingWebReport));
			this.panel1 = new System.Windows.Forms.Panel();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnLoadReport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.panel2 = new System.Windows.Forms.Panel();
			this.wb = new System.Windows.Forms.WebBrowser();
			this.panel1.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.ts);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(772, 45);
			this.panel1.TabIndex = 0;
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnLoadReport,
            this.toolStripSeparator3});
			this.ts.Location = new System.Drawing.Point(3, 3);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(766, 45);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(70, 40);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnLoadReport
			// 
			this.tsbtnLoadReport.AutoSize = false;
			this.tsbtnLoadReport.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLoadReport.Image")));
			this.tsbtnLoadReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnLoadReport.Name = "tsbtnLoadReport";
			this.tsbtnLoadReport.Size = new System.Drawing.Size(75, 42);
			this.tsbtnLoadReport.Text = "Re-Load";
			this.tsbtnLoadReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnLoadReport.Click += new System.EventHandler(this.tsbtnLoadReport_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(2, 589);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(772, 28);
			this.panel2.TabIndex = 2;
			// 
			// wb
			// 
			this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wb.Location = new System.Drawing.Point(2, 47);
			this.wb.MinimumSize = new System.Drawing.Size(20, 20);
			this.wb.Name = "wb";
			this.wb.ScriptErrorsSuppressed = true;
			this.wb.Size = new System.Drawing.Size(772, 542);
			this.wb.TabIndex = 3;
			// 
			// CastingWebReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 619);
			this.Controls.Add(this.wb);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingWebReport";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "REPORT";
			this.Load += new System.EventHandler(this.CastingWebReport_Load);
			this.panel1.ResumeLayout(false);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.WebBrowser wb;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnLoadReport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
	}
}