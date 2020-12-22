namespace OMW15.Views.CastingView
{
	partial class SummaryMatReceive
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnShowData = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxMaterialCAT = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel3 = new System.Windows.Forms.Panel();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlTitle.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel1);
			this.pnlTop.Controls.Add(this.pnlTitle);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(1012, 80);
			this.pnlTop.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnShowData);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.cbxMonth);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.cbxYear);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbxMaterialCAT);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 44);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(1008, 28);
			this.panel1.TabIndex = 1;
			// 
			// btnShowData
			// 
			this.btnShowData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnShowData.Location = new System.Drawing.Point(529, 1);
			this.btnShowData.Name = "btnShowData";
			this.btnShowData.Size = new System.Drawing.Size(119, 26);
			this.btnShowData.TabIndex = 9;
			this.btnShowData.Text = "แสดงผล";
			this.btnShowData.UseVisualStyleBackColor = true;
			this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(505, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 26);
			this.label5.TabIndex = 8;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(390, 1);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(115, 25);
			this.cbxMonth.TabIndex = 6;
			this.cbxMonth.SelectionChangeCommitted += new System.EventHandler(this.cbxMonth_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(337, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 26);
			this.label4.TabIndex = 5;
			this.label4.Text = "เดือน : ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(228, 1);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(109, 25);
			this.cbxYear.TabIndex = 4;
			this.cbxYear.SelectionChangeCommitted += new System.EventHandler(this.cbxYear_SelectionChangeCommitted);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(175, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 26);
			this.label3.TabIndex = 3;
			this.label3.Text = "ปี : ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxMaterialCAT
			// 
			this.cbxMaterialCAT.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterialCAT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterialCAT.FormattingEnabled = true;
			this.cbxMaterialCAT.Location = new System.Drawing.Point(60, 1);
			this.cbxMaterialCAT.Name = "cbxMaterialCAT";
			this.cbxMaterialCAT.Size = new System.Drawing.Size(115, 25);
			this.cbxMaterialCAT.TabIndex = 2;
			this.cbxMaterialCAT.SelectionChangeCommitted += new System.EventHandler(this.cbxMaterialCAT_SelectionChangeCommitted);
			this.cbxMaterialCAT.SelectedValueChanged += new System.EventHandler(this.cbxMaterialCAT_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "กลุ่มวัสดุ : ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlTitle
			// 
			this.pnlTitle.Controls.Add(this.label1);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(2, 2);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Padding = new System.Windows.Forms.Padding(1);
			this.pnlTitle.Size = new System.Drawing.Size(1008, 42);
			this.pnlTitle.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(186, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "สรุปรายการรับวัสดุ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgv);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 80);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(1012, 450);
			this.panel2.TabIndex = 1;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
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
			this.dgv.Location = new System.Drawing.Point(5, 5);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(1002, 406);
			this.dgv.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(5, 411);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1002, 34);
			this.panel3.TabIndex = 0;
			// 
			// SummaryMatReceive
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1012, 530);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SummaryMatReceive";
			this.Text = "SUMMARY MATERIAL RECEIVE";
			this.Load += new System.EventHandler(this.SummaryMatReceive_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlTitle.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbxMaterialCAT;
		private System.Windows.Forms.Button btnShowData;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
	}
}