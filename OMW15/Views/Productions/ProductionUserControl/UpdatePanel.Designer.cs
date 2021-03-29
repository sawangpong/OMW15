namespace OMW15.Views.Productions.ProductionUserControl
{
	partial class UpdatePanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbUnit = new System.Windows.Forms.Label();
			this.lbTotalQty = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.lbHourTitle = new System.Windows.Forms.Label();
			this.lbHourNeed = new System.Windows.Forms.Label();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.lbTitle);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(4, 4);
			this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(3);
			this.pnlTop.Size = new System.Drawing.Size(257, 38);
			this.pnlTop.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(3, 3);
			this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(185, 32);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Title";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbUnit);
			this.panel1.Controls.Add(this.lbTotalQty);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 102);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(257, 42);
			this.panel1.TabIndex = 1;
			// 
			// lbUnit
			// 
			this.lbUnit.BackColor = System.Drawing.Color.Transparent;
			this.lbUnit.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbUnit.ForeColor = System.Drawing.Color.White;
			this.lbUnit.Location = new System.Drawing.Point(43, 2);
			this.lbUnit.Name = "lbUnit";
			this.lbUnit.Size = new System.Drawing.Size(65, 38);
			this.lbUnit.TabIndex = 1;
			this.lbUnit.Text = "Unit";
			this.lbUnit.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbTotalQty
			// 
			this.lbTotalQty.BackColor = System.Drawing.Color.Transparent;
			this.lbTotalQty.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbTotalQty.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTotalQty.ForeColor = System.Drawing.Color.Yellow;
			this.lbTotalQty.Location = new System.Drawing.Point(108, 2);
			this.lbTotalQty.Name = "lbTotalQty";
			this.lbTotalQty.Size = new System.Drawing.Size(147, 38);
			this.lbTotalQty.TabIndex = 0;
			this.lbTotalQty.Text = "0";
			this.lbTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbHourNeed);
			this.panel2.Controls.Add(this.lbHourTitle);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(4, 42);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(257, 60);
			this.panel2.TabIndex = 2;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(208, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 56);
			this.label1.TabIndex = 3;
			this.label1.Text = "hrs.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbHourTitle
			// 
			this.lbHourTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbHourTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbHourTitle.ForeColor = System.Drawing.Color.White;
			this.lbHourTitle.Location = new System.Drawing.Point(2, 2);
			this.lbHourTitle.Name = "lbHourTitle";
			this.lbHourTitle.Size = new System.Drawing.Size(95, 56);
			this.lbHourTitle.TabIndex = 4;
			this.lbHourTitle.Text = "Hour need:";
			this.lbHourTitle.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbHourNeed
			// 
			this.lbHourNeed.BackColor = System.Drawing.Color.Transparent;
			this.lbHourNeed.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbHourNeed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHourNeed.ForeColor = System.Drawing.Color.Yellow;
			this.lbHourNeed.Location = new System.Drawing.Point(103, 2);
			this.lbHourNeed.Name = "lbHourNeed";
			this.lbHourNeed.Size = new System.Drawing.Size(105, 56);
			this.lbHourNeed.TabIndex = 5;
			this.lbHourNeed.Text = "0";
			this.lbHourNeed.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// UpdatePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkBlue;
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "UpdatePanel";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Size = new System.Drawing.Size(265, 148);
			this.Load += new System.EventHandler(this.UpdatePanel_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTotalQty;
		private System.Windows.Forms.Label lbUnit;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lbHourNeed;
		private System.Windows.Forms.Label lbHourTitle;
		private System.Windows.Forms.Label label1;
	}
}
