namespace OMW15.Views.ToolViews {
	partial class LoadAlert {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.panel1 = new System.Windows.Forms.Panel();
			this.pgb = new System.Windows.Forms.ProgressBar();
			this.lbMessage = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pgb);
			this.panel1.Controls.Add(this.lbMessage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(25, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(343, 50);
			this.panel1.TabIndex = 0;
			// 
			// pgb
			// 
			this.pgb.Dock = System.Windows.Forms.DockStyle.Top;
			this.pgb.Location = new System.Drawing.Point(0, 25);
			this.pgb.Name = "pgb";
			this.pgb.Size = new System.Drawing.Size(343, 21);
			this.pgb.TabIndex = 1;
			// 
			// lbMessage
			// 
			this.lbMessage.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbMessage.Location = new System.Drawing.Point(0, 0);
			this.lbMessage.Name = "lbMessage";
			this.lbMessage.Size = new System.Drawing.Size(343, 25);
			this.lbMessage.TabIndex = 0;
			this.lbMessage.Text = "Loading in process, please wait...";
			this.lbMessage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// LoadAlert
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 100);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "LoadAlert";
			this.Opacity = 0.65D;
			this.Padding = new System.Windows.Forms.Padding(25);
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Processing";
			this.Load += new System.EventHandler(this.LoadAlert_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ProgressBar pgb;
		private System.Windows.Forms.Label lbMessage;
	}
}