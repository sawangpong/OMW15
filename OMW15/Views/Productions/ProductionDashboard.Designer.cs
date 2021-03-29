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
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
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
			this.flp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flp.Location = new System.Drawing.Point(5, 5);
			this.flp.Name = "flp";
			this.flp.Padding = new System.Windows.Forms.Padding(3);
			this.flp.Size = new System.Drawing.Size(745, 551);
			this.flp.TabIndex = 2;
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
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.FlowLayoutPanel flp;
	}
}