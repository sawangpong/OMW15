namespace OMW15.Views.CastingView
{
	partial class MonthYearOption
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
			this.btnShow = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gb = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlMaterialCategory = new System.Windows.Forms.Panel();
			this.lbOption = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.gb.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlMaterialCategory.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnShow);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(15, 176);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(378, 39);
			this.panel1.TabIndex = 0;
			// 
			// btnShow
			// 
			this.btnShow.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnShow.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnShow.Location = new System.Drawing.Point(5, 5);
			this.btnShow.Name = "btnShow";
			this.btnShow.Size = new System.Drawing.Size(124, 29);
			this.btnShow.TabIndex = 1;
			this.btnShow.Text = "&Show";
			this.btnShow.UseVisualStyleBackColor = true;
			this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(249, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(124, 29);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// gb
			// 
			this.gb.Controls.Add(this.panel4);
			this.gb.Controls.Add(this.panel3);
			this.gb.Controls.Add(this.pnlMaterialCategory);
			this.gb.Dock = System.Windows.Forms.DockStyle.Top;
			this.gb.Location = new System.Drawing.Point(15, 15);
			this.gb.Name = "gb";
			this.gb.Padding = new System.Windows.Forms.Padding(20);
			this.gb.Size = new System.Drawing.Size(378, 149);
			this.gb.TabIndex = 4;
			this.gb.TabStop = false;
			this.gb.Text = "Title";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.cbxMonth);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(20, 96);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(338, 28);
			this.panel4.TabIndex = 4;
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(129, 1);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(130, 25);
			this.cbxMonth.TabIndex = 3;
			this.cbxMonth.SelectedValueChanged += new System.EventHandler(this.cbxMonth_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "Month :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cbxYear);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(20, 68);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(338, 28);
			this.panel3.TabIndex = 3;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(129, 1);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(130, 25);
			this.cbxYear.TabIndex = 2;
			this.cbxYear.SelectedValueChanged += new System.EventHandler(this.cbxYear_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Year :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlMaterialCategory
			// 
			this.pnlMaterialCategory.Controls.Add(this.lbOption);
			this.pnlMaterialCategory.Controls.Add(this.label1);
			this.pnlMaterialCategory.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMaterialCategory.Location = new System.Drawing.Point(20, 38);
			this.pnlMaterialCategory.Name = "pnlMaterialCategory";
			this.pnlMaterialCategory.Padding = new System.Windows.Forms.Padding(1, 1, 10, 1);
			this.pnlMaterialCategory.Size = new System.Drawing.Size(338, 30);
			this.pnlMaterialCategory.TabIndex = 2;
			// 
			// lbOption
			// 
			this.lbOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbOption.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbOption.Location = new System.Drawing.Point(129, 1);
			this.lbOption.Name = "lbOption";
			this.lbOption.Size = new System.Drawing.Size(199, 28);
			this.lbOption.TabIndex = 1;
			this.lbOption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Mat. Category :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MonthYearOption
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(408, 230);
			this.Controls.Add(this.gb);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MonthYearOption";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Text = "OPTIONS";
			this.Load += new System.EventHandler(this.MonthYearOption_Load);
			this.panel1.ResumeLayout(false);
			this.gb.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlMaterialCategory.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnShow;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gb;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlMaterialCategory;
		private System.Windows.Forms.Label lbOption;
		private System.Windows.Forms.Label label1;
	}
}