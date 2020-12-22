namespace OMW15.Views.ToolViews
{
	partial class SelectBox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectBox));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnSearch = new OMControls.OMFlatButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbSelected = new System.Windows.Forms.Label();
			this.lst = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSelect);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(4, 304);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
			this.panel1.Size = new System.Drawing.Size(345, 50);
			this.panel1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(210, 8);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 34);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(7, 8);
			this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(128, 34);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.White;
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.lbSelected);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(4, 5);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel2.Size = new System.Drawing.Size(345, 64);
			this.panel2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnSearch);
			this.panel3.Controls.Add(this.lbTitle);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Size = new System.Drawing.Size(341, 31);
			this.panel3.TabIndex = 4;
			// 
			// btnSearch
			// 
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(71, 5);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(21, 21);
			this.btnSearch.TabIndex = 3;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.White;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbTitle.Location = new System.Drawing.Point(4, 5);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(67, 21);
			this.lbTitle.TabIndex = 2;
			this.lbTitle.Text = "Select ?";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbSelected
			// 
			this.lbSelected.BackColor = System.Drawing.Color.White;
			this.lbSelected.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbSelected.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelected.Location = new System.Drawing.Point(2, 36);
			this.lbSelected.Name = "lbSelected";
			this.lbSelected.Size = new System.Drawing.Size(341, 26);
			this.lbSelected.TabIndex = 3;
			this.lbSelected.Text = "-----";
			this.lbSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lst
			// 
			this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lst.FormattingEnabled = true;
			this.lst.IntegralHeight = false;
			this.lst.ItemHeight = 17;
			this.lst.Location = new System.Drawing.Point(4, 69);
			this.lst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.lst.Name = "lst";
			this.lst.Size = new System.Drawing.Size(345, 235);
			this.lst.TabIndex = 4;
			this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
			this.lst.DoubleClick += new System.EventHandler(this.lst_DoubleClick);
			// 
			// SelectBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(353, 359);
			this.Controls.Add(this.lst);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SelectBox";
			this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Text = "SELECT ?";
			this.Load += new System.EventHandler(this.SelectBox_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListBox lst;
		private System.Windows.Forms.Label lbSelected;
		private System.Windows.Forms.Panel panel3;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.Label lbTitle;
	}
}