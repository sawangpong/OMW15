namespace OMW15.Views.ToolViews
{
	partial class AppUpdate
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.downloadProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.lbDownloadStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbAppName = new System.Windows.Forms.Label();
			this.lbStatus = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadProgress,
            this.lbDownloadStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 172);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(501, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// downloadProgress
			// 
			this.downloadProgress.AutoSize = false;
			this.downloadProgress.Name = "downloadProgress";
			this.downloadProgress.Size = new System.Drawing.Size(300, 16);
			// 
			// lbDownloadStatus
			// 
			this.lbDownloadStatus.Name = "lbDownloadStatus";
			this.lbDownloadStatus.Size = new System.Drawing.Size(23, 17);
			this.lbDownloadStatus.Text = "0%";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbStatus);
			this.panel1.Controls.Add(this.lbAppName);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(30);
			this.panel1.Size = new System.Drawing.Size(501, 172);
			this.panel1.TabIndex = 2;
			// 
			// lbAppName
			// 
			this.lbAppName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbAppName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAppName.Location = new System.Drawing.Point(30, 30);
			this.lbAppName.Name = "lbAppName";
			this.lbAppName.Size = new System.Drawing.Size(441, 45);
			this.lbAppName.TabIndex = 0;
			this.lbAppName.Text = "App";
			this.lbAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbStatus
			// 
			this.lbStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbStatus.ForeColor = System.Drawing.Color.Navy;
			this.lbStatus.Location = new System.Drawing.Point(30, 75);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(441, 19);
			this.lbStatus.TabIndex = 1;
			this.lbStatus.Text = "Status : ";
			this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AppUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 194);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AppUpdate";
			this.Text = "APPLICATION UPDATE";
			this.Load += new System.EventHandler(this.AppUpdate_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar downloadProgress;
		private System.Windows.Forms.ToolStripStatusLabel lbDownloadStatus;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbAppName;
		private System.Windows.Forms.Label lbStatus;
	}
}