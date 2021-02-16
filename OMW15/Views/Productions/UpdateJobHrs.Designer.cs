namespace OMW15.Views.Productions
{
	partial class UpdateJobHrs
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgvWorker = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgvWorkInfo = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorker)).BeginInit();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Red;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(933, 50);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "ปรับปรุงชั่วโมงทำงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgvWorkInfo);
			this.panel2.Controls.Add(this.panel6);
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(933, 349);
			this.panel2.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.label3);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(223, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(708, 30);
			this.panel6.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(217, 2);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(6, 345);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgvWorker);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(2, 2);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(215, 345);
			this.panel4.TabIndex = 0;
			// 
			// dgvWorker
			// 
			this.dgvWorker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvWorker.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvWorker.Location = new System.Drawing.Point(2, 32);
			this.dgvWorker.Name = "dgvWorker";
			this.dgvWorker.Size = new System.Drawing.Size(211, 311);
			this.dgvWorker.TabIndex = 1;
			this.dgvWorker.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorker_CellEnter);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.cbxYear);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(211, 30);
			this.panel5.TabIndex = 0;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(32, 2);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(116, 25);
			this.cbxYear.TabIndex = 1;
			this.cbxYear.SelectionChangeCommitted += new System.EventHandler(this.cbxYear_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "ปี:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 399);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(933, 6);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 405);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(933, 194);
			this.panel3.TabIndex = 3;
			// 
			// dgvWorkInfo
			// 
			this.dgvWorkInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvWorkInfo.Location = new System.Drawing.Point(223, 32);
			this.dgvWorkInfo.Name = "dgvWorkInfo";
			this.dgvWorkInfo.Size = new System.Drawing.Size(708, 315);
			this.dgvWorkInfo.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(142, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "รายการทำงาน";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// UpdateJobHrs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(933, 599);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "UpdateJobHrs";
			this.Text = "Update Job Hours";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvWorker)).EndInit();
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvWorker;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.DataGridView dgvWorkInfo;
		private System.Windows.Forms.Label label3;
	}
}