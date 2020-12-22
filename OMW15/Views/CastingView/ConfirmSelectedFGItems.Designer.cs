namespace OMW15.Views.CastingView
{
	partial class ConfirmSelectedFGItems
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnConfirmFG = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlHeaderSub2 = new System.Windows.Forms.Panel();
			this.lbVATFactor = new System.Windows.Forms.Label();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.pnlHeaderSub1 = new System.Windows.Forms.Panel();
			this.lbCustomer = new System.Windows.Forms.Label();
			this.lbSOId = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlHeaderSub2.SuspendLayout();
			this.pnlHeaderSub1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnConfirmFG);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 299);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(1038, 40);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(938, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(95, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnConfirmFG
			// 
			this.btnConfirmFG.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnConfirmFG.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnConfirmFG.Image = global::OMW15.Properties.Resources.apply;
			this.btnConfirmFG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnConfirmFG.Location = new System.Drawing.Point(5, 5);
			this.btnConfirmFG.Name = "btnConfirmFG";
			this.btnConfirmFG.Size = new System.Drawing.Size(226, 30);
			this.btnConfirmFG.TabIndex = 0;
			this.btnConfirmFG.Text = "Confirm Selected FG Items";
			this.btnConfirmFG.UseVisualStyleBackColor = true;
			this.btnConfirmFG.Click += new System.EventHandler(this.btnConfirmFG_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.IndianRed;
			this.pnlHeader.Controls.Add(this.pnlHeaderSub2);
			this.pnlHeader.Controls.Add(this.pnlHeaderSub1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(4, 4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(3);
			this.pnlHeader.Size = new System.Drawing.Size(1038, 67);
			this.pnlHeader.TabIndex = 1;
			// 
			// pnlHeaderSub2
			// 
			this.pnlHeaderSub2.Controls.Add(this.lbVATFactor);
			this.pnlHeaderSub2.Controls.Add(this.lbRowCount);
			this.pnlHeaderSub2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlHeaderSub2.Location = new System.Drawing.Point(3, 38);
			this.pnlHeaderSub2.Name = "pnlHeaderSub2";
			this.pnlHeaderSub2.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHeaderSub2.Size = new System.Drawing.Size(1032, 26);
			this.pnlHeaderSub2.TabIndex = 5;
			// 
			// lbVATFactor
			// 
			this.lbVATFactor.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbVATFactor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbVATFactor.ForeColor = System.Drawing.Color.Yellow;
			this.lbVATFactor.Location = new System.Drawing.Point(934, 1);
			this.lbVATFactor.Name = "lbVATFactor";
			this.lbVATFactor.Size = new System.Drawing.Size(97, 24);
			this.lbVATFactor.TabIndex = 4;
			this.lbVATFactor.Text = "rate : 0";
			this.lbVATFactor.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowCount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRowCount.ForeColor = System.Drawing.Color.Yellow;
			this.lbRowCount.Location = new System.Drawing.Point(1, 1);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(97, 24);
			this.lbRowCount.TabIndex = 1;
			this.lbRowCount.Text = "found : 0";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlHeaderSub1
			// 
			this.pnlHeaderSub1.Controls.Add(this.lbCustomer);
			this.pnlHeaderSub1.Controls.Add(this.lbSOId);
			this.pnlHeaderSub1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeaderSub1.Location = new System.Drawing.Point(3, 3);
			this.pnlHeaderSub1.Name = "pnlHeaderSub1";
			this.pnlHeaderSub1.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHeaderSub1.Size = new System.Drawing.Size(1032, 35);
			this.pnlHeaderSub1.TabIndex = 4;
			// 
			// lbCustomer
			// 
			this.lbCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCustomer.ForeColor = System.Drawing.Color.Yellow;
			this.lbCustomer.Location = new System.Drawing.Point(1, 1);
			this.lbCustomer.Name = "lbCustomer";
			this.lbCustomer.Size = new System.Drawing.Size(595, 33);
			this.lbCustomer.TabIndex = 5;
			this.lbCustomer.Text = "customer : ";
			this.lbCustomer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbSOId
			// 
			this.lbSOId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbSOId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSOId.ForeColor = System.Drawing.Color.Yellow;
			this.lbSOId.Location = new System.Drawing.Point(629, 1);
			this.lbSOId.Name = "lbSOId";
			this.lbSOId.Size = new System.Drawing.Size(402, 33);
			this.lbSOId.TabIndex = 4;
			this.lbSOId.Text = "id : 0";
			this.lbSOId.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(4, 71);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(4);
			this.panel3.Size = new System.Drawing.Size(1038, 228);
			this.panel3.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(1030, 220);
			this.dgv.TabIndex = 0;
			// 
			// ConfirmSelectedFGItems
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1046, 343);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ConfirmSelectedFGItems";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "SELECT FG ITEMS";
			this.Load += new System.EventHandler(this.ConfirmSelectedFGItems_Load);
			this.panel1.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeaderSub2.ResumeLayout(false);
			this.pnlHeaderSub1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnConfirmFG;
		private System.Windows.Forms.Panel pnlHeaderSub2;
		private System.Windows.Forms.Label lbVATFactor;
		private System.Windows.Forms.Label lbRowCount;
		private System.Windows.Forms.Panel pnlHeaderSub1;
		private System.Windows.Forms.Label lbSOId;
		private System.Windows.Forms.Label lbCustomer;
	}
}