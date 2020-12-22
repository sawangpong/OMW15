namespace OMW15.Casting.CastingView
{
	partial class CastingOrderPrintForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.crv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(786, 55);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(786, 55);
			this.label1.TabIndex = 0;
			this.label1.Text = "ใบงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// crv
			// 
			this.crv.ActiveViewIndex = -1;
			this.crv.AutoScroll = true;
			this.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.crv.Cursor = System.Windows.Forms.Cursors.Default;
			this.crv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crv.Location = new System.Drawing.Point(0, 55);
			this.crv.Margin = new System.Windows.Forms.Padding(4);
			this.crv.Name = "crv";
			this.crv.ShowCloseButton = false;
			this.crv.ShowCopyButton = false;
			this.crv.ShowGotoPageButton = false;
			this.crv.ShowGroupTreeButton = false;
			this.crv.ShowLogo = false;
			this.crv.ShowParameterPanelButton = false;
			this.crv.ShowTextSearchButton = false;
			this.crv.Size = new System.Drawing.Size(786, 464);
			this.crv.TabIndex = 1;
			this.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			this.crv.ToolPanelWidth = 300;
			// 
			// CastingOrderPrintForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(786, 519);
			this.Controls.Add(this.crv);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CastingOrderPrintForm";
			this.Text = "CastingOrderPrintForm";
			this.Load += new System.EventHandler(this.CastingOrderPrintForm_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crv;
		private System.Windows.Forms.Label label1;
	}
}