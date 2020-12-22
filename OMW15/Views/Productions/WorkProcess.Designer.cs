namespace OMW15.Views.Productions
{
	partial class WorkProcess
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnAddProcess = new System.Windows.Forms.Button();
			this.lbItemNo = new System.Windows.Forms.Label();
			this.lbHeader = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSelect);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 276);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(402, 38);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(278, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(121, 32);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(3, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(121, 32);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnAddProcess);
			this.panel2.Controls.Add(this.lbItemNo);
			this.panel2.Controls.Add(this.lbHeader);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(3);
			this.panel2.Size = new System.Drawing.Size(402, 65);
			this.panel2.TabIndex = 1;
			// 
			// btnAddProcess
			// 
			this.btnAddProcess.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnAddProcess.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddProcess.Location = new System.Drawing.Point(307, 37);
			this.btnAddProcess.Name = "btnAddProcess";
			this.btnAddProcess.Size = new System.Drawing.Size(92, 25);
			this.btnAddProcess.TabIndex = 2;
			this.btnAddProcess.Text = "Add Process";
			this.btnAddProcess.UseVisualStyleBackColor = true;
			this.btnAddProcess.Visible = false;
			this.btnAddProcess.Click += new System.EventHandler(this.btnAddProcess_Click);
			// 
			// lbItemNo
			// 
			this.lbItemNo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbItemNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbItemNo.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbItemNo.Location = new System.Drawing.Point(3, 37);
			this.lbItemNo.Name = "lbItemNo";
			this.lbItemNo.Size = new System.Drawing.Size(396, 25);
			this.lbItemNo.TabIndex = 1;
			this.lbItemNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbHeader
			// 
			this.lbHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbHeader.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHeader.Location = new System.Drawing.Point(3, 3);
			this.lbHeader.Name = "lbHeader";
			this.lbHeader.Size = new System.Drawing.Size(396, 34);
			this.lbHeader.TabIndex = 0;
			this.lbHeader.Text = "ขั้นตอนการผลิตของชิ้นงาน";
			this.lbHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 65);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(4);
			this.panel3.Size = new System.Drawing.Size(402, 211);
			this.panel3.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(394, 203);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// WorkProcess
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 314);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "WorkProcess";
			this.Text = "WORKING PROCESS";
			this.Load += new System.EventHandler(this.WorkProcess_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbItemNo;
		private System.Windows.Forms.Label lbHeader;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnAddProcess;
	}
}