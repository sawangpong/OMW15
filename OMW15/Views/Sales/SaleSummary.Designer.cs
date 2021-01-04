namespace OMW15.Views.Sales
{
	partial class SaleSummary
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
			this.label2 = new System.Windows.Forms.Label();
			this.cbxSaleGroup = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxSaleYear = new System.Windows.Forms.ComboBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.lbSaleGroup = new System.Windows.Forms.Label();
			this.lbYR = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.lbYR);
			this.panel1.Controls.Add(this.lbSaleGroup);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(960, 50);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(695, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(265, 50);
			this.label1.TabIndex = 0;
			this.label1.Text = "สรุปยอดขาย";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnLoadData);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.cbxSaleYear);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.cbxSaleGroup);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(960, 30);
			this.panel2.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "Sale group :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbxSaleGroup
			// 
			this.cbxSaleGroup.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxSaleGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSaleGroup.FormattingEnabled = true;
			this.cbxSaleGroup.Location = new System.Drawing.Point(84, 2);
			this.cbxSaleGroup.Name = "cbxSaleGroup";
			this.cbxSaleGroup.Size = new System.Drawing.Size(149, 25);
			this.cbxSaleGroup.TabIndex = 1;
			this.cbxSaleGroup.SelectedIndexChanged += new System.EventHandler(this.cbxSaleGroup_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(233, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(86, 26);
			this.label3.TabIndex = 2;
			this.label3.Text = "Year:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxSaleYear
			// 
			this.cbxSaleYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxSaleYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSaleYear.FormattingEnabled = true;
			this.cbxSaleYear.Location = new System.Drawing.Point(319, 2);
			this.cbxSaleYear.Name = "cbxSaleYear";
			this.cbxSaleYear.Size = new System.Drawing.Size(98, 25);
			this.cbxSaleYear.TabIndex = 3;
			this.cbxSaleYear.SelectionChangeCommitted += new System.EventHandler(this.cbxSaleYear_SelectionChangeCommitted);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dgv);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 80);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(960, 378);
			this.panel3.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.label4.Location = new System.Drawing.Point(417, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 26);
			this.label4.TabIndex = 6;
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.Location = new System.Drawing.Point(437, 2);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(93, 26);
			this.btnLoadData.TabIndex = 7;
			this.btnLoadData.Text = "Load data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(956, 374);
			this.dgv.TabIndex = 0;
			// 
			// lbSaleGroup
			// 
			this.lbSaleGroup.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSaleGroup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSaleGroup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lbSaleGroup.Location = new System.Drawing.Point(0, 0);
			this.lbSaleGroup.Name = "lbSaleGroup";
			this.lbSaleGroup.Size = new System.Drawing.Size(27, 50);
			this.lbSaleGroup.TabIndex = 5;
			this.lbSaleGroup.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbYR
			// 
			this.lbYR.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYR.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbYR.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.lbYR.Location = new System.Drawing.Point(27, 0);
			this.lbYR.Name = "lbYR";
			this.lbYR.Size = new System.Drawing.Size(57, 50);
			this.lbYR.TabIndex = 6;
			this.lbYR.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SaleSummary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 458);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleSummary";
			this.Text = "SALE SUMMARY";
			this.Load += new System.EventHandler(this.SaleSummary_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox cbxSaleYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxSaleGroup;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label lbSaleGroup;
		private System.Windows.Forms.Label lbYR;
	}
}