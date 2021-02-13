namespace OMW15.Views.Productions
{
	partial class MissReportInfo
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.btnReload = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.dgvInfo = new System.Windows.Forms.DataGridView();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnTimeRecode = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(732, 50);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(478, 46);
			this.label1.TabIndex = 0;
			this.label1.Text = "รายชื่อพนักงานที่ไม่ลงรายงานการปฏิบัติงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 390);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(732, 22);
			this.statusStrip1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(732, 340);
			this.panel2.TabIndex = 2;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnTimeRecode);
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Controls.Add(this.btnReload);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(563, 5);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(10);
			this.panel3.Size = new System.Drawing.Size(164, 330);
			this.panel3.TabIndex = 0;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgvInfo);
			this.panel4.Controls.Add(this.splitter1);
			this.panel4.Controls.Add(this.dgv);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(5, 5);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(558, 330);
			this.panel4.TabIndex = 1;
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Left;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(275, 326);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// btnReload
			// 
			this.btnReload.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReload.Location = new System.Drawing.Point(10, 10);
			this.btnReload.Name = "btnReload";
			this.btnReload.Size = new System.Drawing.Size(144, 32);
			this.btnReload.TabIndex = 0;
			this.btnReload.Text = "Re-load";
			this.btnReload.UseVisualStyleBackColor = true;
			this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(277, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 326);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// dgvInfo
			// 
			this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvInfo.Location = new System.Drawing.Point(283, 2);
			this.dgvInfo.Name = "dgvInfo";
			this.dgvInfo.Size = new System.Drawing.Size(273, 326);
			this.dgvInfo.TabIndex = 2;
			this.dgvInfo.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInfo_CellEnter);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Location = new System.Drawing.Point(10, 288);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(144, 32);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnTimeRecode
			// 
			this.btnTimeRecode.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnTimeRecode.Location = new System.Drawing.Point(10, 42);
			this.btnTimeRecode.Name = "btnTimeRecode";
			this.btnTimeRecode.Size = new System.Drawing.Size(144, 32);
			this.btnTimeRecode.TabIndex = 2;
			this.btnTimeRecode.Text = "บันทึกเวลาทำงาน";
			this.btnTimeRecode.UseVisualStyleBackColor = true;
			this.btnTimeRecode.Click += new System.EventHandler(this.btnTimeRecode_Click);
			// 
			// MissReportInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(732, 412);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MissReportInfo";
			this.Text = "Production Miss Report Info";
			this.Load += new System.EventHandler(this.MissReportInfo_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnReload;
		private System.Windows.Forms.DataGridView dgvInfo;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnTimeRecode;
	}
}