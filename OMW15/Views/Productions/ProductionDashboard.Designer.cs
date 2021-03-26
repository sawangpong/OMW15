namespace OMW15.Views.Productions
{
	partial class ProductionDashboard
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.flp = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlGroup1 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbQG1 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbMachineGroup1 = new System.Windows.Forms.Label();
			this.lbG1Unit = new System.Windows.Forms.Label();
			this.pnlGroup2 = new System.Windows.Forms.Panel();
			this.lbMachineGroup2 = new System.Windows.Forms.Label();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lbG2Unit = new System.Windows.Forms.Label();
			this.lbQG2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.flp.SuspendLayout();
			this.pnlGroup1.SuspendLayout();
			this.panel8.SuspendLayout();
			this.pnlGroup2.SuspendLayout();
			this.panel9.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(908, 50);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Image = global::OMW15.Properties.Resources.dashboard;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox1.Size = new System.Drawing.Size(49, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(652, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(256, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "Production Dashboard";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.ForeColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(153, 561);
			this.panel2.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
			this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(10, 522);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(133, 29);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.flp);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(153, 50);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(5);
			this.panel3.Size = new System.Drawing.Size(755, 561);
			this.panel3.TabIndex = 2;
			// 
			// flp
			// 
			this.flp.AutoScroll = true;
			this.flp.AutoSize = true;
			this.flp.Controls.Add(this.pnlGroup1);
			this.flp.Controls.Add(this.panel7);
			this.flp.Controls.Add(this.panel6);
			this.flp.Controls.Add(this.panel5);
			this.flp.Controls.Add(this.pnlGroup2);
			this.flp.Dock = System.Windows.Forms.DockStyle.Top;
			this.flp.Location = new System.Drawing.Point(5, 5);
			this.flp.Name = "flp";
			this.flp.Padding = new System.Windows.Forms.Padding(3);
			this.flp.Size = new System.Drawing.Size(745, 258);
			this.flp.TabIndex = 0;
			// 
			// pnlGroup1
			// 
			this.pnlGroup1.BackColor = System.Drawing.Color.Red;
			this.pnlGroup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGroup1.Controls.Add(this.lbMachineGroup1);
			this.pnlGroup1.Controls.Add(this.panel8);
			this.pnlGroup1.Location = new System.Drawing.Point(6, 6);
			this.pnlGroup1.Name = "pnlGroup1";
			this.pnlGroup1.Padding = new System.Windows.Forms.Padding(3);
			this.pnlGroup1.Size = new System.Drawing.Size(200, 120);
			this.pnlGroup1.TabIndex = 0;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lbG1Unit);
			this.panel8.Controls.Add(this.lbQG1);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(3, 3);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(2);
			this.panel8.Size = new System.Drawing.Size(192, 73);
			this.panel8.TabIndex = 0;
			// 
			// lbQG1
			// 
			this.lbQG1.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbQG1.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbQG1.ForeColor = System.Drawing.Color.White;
			this.lbQG1.Location = new System.Drawing.Point(58, 2);
			this.lbQG1.Name = "lbQG1";
			this.lbQG1.Size = new System.Drawing.Size(132, 69);
			this.lbQG1.TabIndex = 0;
			this.lbQG1.Text = "0";
			this.lbQG1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel7
			// 
			this.panel7.Location = new System.Drawing.Point(212, 6);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(200, 120);
			this.panel7.TabIndex = 3;
			// 
			// panel6
			// 
			this.panel6.Location = new System.Drawing.Point(418, 6);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(200, 120);
			this.panel6.TabIndex = 2;
			// 
			// panel5
			// 
			this.panel5.Location = new System.Drawing.Point(6, 132);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(200, 120);
			this.panel5.TabIndex = 1;
			// 
			// lbMachineGroup1
			// 
			this.lbMachineGroup1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbMachineGroup1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMachineGroup1.ForeColor = System.Drawing.Color.Yellow;
			this.lbMachineGroup1.Location = new System.Drawing.Point(3, 79);
			this.lbMachineGroup1.Name = "lbMachineGroup1";
			this.lbMachineGroup1.Size = new System.Drawing.Size(192, 36);
			this.lbMachineGroup1.TabIndex = 1;
			this.lbMachineGroup1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbG1Unit
			// 
			this.lbG1Unit.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbG1Unit.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbG1Unit.ForeColor = System.Drawing.Color.Yellow;
			this.lbG1Unit.Location = new System.Drawing.Point(2, 2);
			this.lbG1Unit.Name = "lbG1Unit";
			this.lbG1Unit.Size = new System.Drawing.Size(56, 69);
			this.lbG1Unit.TabIndex = 3;
			this.lbG1Unit.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// pnlGroup2
			// 
			this.pnlGroup2.BackColor = System.Drawing.Color.Red;
			this.pnlGroup2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGroup2.Controls.Add(this.lbMachineGroup2);
			this.pnlGroup2.Controls.Add(this.panel9);
			this.pnlGroup2.Location = new System.Drawing.Point(212, 132);
			this.pnlGroup2.Name = "pnlGroup2";
			this.pnlGroup2.Padding = new System.Windows.Forms.Padding(3);
			this.pnlGroup2.Size = new System.Drawing.Size(200, 120);
			this.pnlGroup2.TabIndex = 4;
			// 
			// lbMachineGroup2
			// 
			this.lbMachineGroup2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbMachineGroup2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMachineGroup2.ForeColor = System.Drawing.Color.Yellow;
			this.lbMachineGroup2.Location = new System.Drawing.Point(3, 79);
			this.lbMachineGroup2.Name = "lbMachineGroup2";
			this.lbMachineGroup2.Size = new System.Drawing.Size(192, 36);
			this.lbMachineGroup2.TabIndex = 1;
			this.lbMachineGroup2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.lbG2Unit);
			this.panel9.Controls.Add(this.lbQG2);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(3, 3);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(192, 73);
			this.panel9.TabIndex = 0;
			// 
			// lbG2Unit
			// 
			this.lbG2Unit.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbG2Unit.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbG2Unit.ForeColor = System.Drawing.Color.Yellow;
			this.lbG2Unit.Location = new System.Drawing.Point(2, 2);
			this.lbG2Unit.Name = "lbG2Unit";
			this.lbG2Unit.Size = new System.Drawing.Size(56, 69);
			this.lbG2Unit.TabIndex = 3;
			this.lbG2Unit.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbQG2
			// 
			this.lbQG2.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbQG2.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbQG2.ForeColor = System.Drawing.Color.White;
			this.lbQG2.Location = new System.Drawing.Point(58, 2);
			this.lbQG2.Name = "lbQG2";
			this.lbQG2.Size = new System.Drawing.Size(132, 69);
			this.lbQG2.TabIndex = 0;
			this.lbQG2.Text = "0";
			this.lbQG2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// ProductionDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 611);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ProductionDashboard";
			this.Text = "Production Dashboard";
			this.Load += new System.EventHandler(this.ProductionDashboard_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.flp.ResumeLayout(false);
			this.pnlGroup1.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.pnlGroup2.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FlowLayoutPanel flp;
		private System.Windows.Forms.Panel pnlGroup1;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label lbQG1;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lbMachineGroup1;
		private System.Windows.Forms.Label lbG1Unit;
		private System.Windows.Forms.Panel pnlGroup2;
		private System.Windows.Forms.Label lbMachineGroup2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label lbG2Unit;
		private System.Windows.Forms.Label lbQG2;
	}
}