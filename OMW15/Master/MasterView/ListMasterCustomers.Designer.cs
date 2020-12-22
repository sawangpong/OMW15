namespace OMW15.Master.MasterView
{
	partial class ListMasterCustomers
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlSearchCustomer = new System.Windows.Forms.Panel();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.rdoFilter = new System.Windows.Forms.RadioButton();
			this.rdoAllCustomers = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlLower = new System.Windows.Forms.Panel();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlSearchCustomer.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel1);
			this.pnlTop.Controls.Add(this.pnlSearchCustomer);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(2, 2);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(666, 74);
			this.pnlTop.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 30);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(662, 34);
			this.panel1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 30);
			this.label2.TabIndex = 0;
			this.label2.Text = "Search :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlSearchCustomer
			// 
			this.pnlSearchCustomer.Controls.Add(this.txtSearch);
			this.pnlSearchCustomer.Controls.Add(this.rdoFilter);
			this.pnlSearchCustomer.Controls.Add(this.rdoAllCustomers);
			this.pnlSearchCustomer.Controls.Add(this.label1);
			this.pnlSearchCustomer.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearchCustomer.Location = new System.Drawing.Point(2, 2);
			this.pnlSearchCustomer.Name = "pnlSearchCustomer";
			this.pnlSearchCustomer.Padding = new System.Windows.Forms.Padding(2);
			this.pnlSearchCustomer.Size = new System.Drawing.Size(662, 28);
			this.pnlSearchCustomer.TabIndex = 2;
			// 
			// txtSearch
			// 
			this.txtSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSearch.Location = new System.Drawing.Point(342, 2);
			this.txtSearch.MaxLength = 50;
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(159, 23);
			this.txtSearch.TabIndex = 3;
			// 
			// rdoFilter
			// 
			this.rdoFilter.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoFilter.Location = new System.Drawing.Point(243, 2);
			this.rdoFilter.Name = "rdoFilter";
			this.rdoFilter.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.rdoFilter.Size = new System.Drawing.Size(99, 24);
			this.rdoFilter.TabIndex = 2;
			this.rdoFilter.TabStop = true;
			this.rdoFilter.Tag = "FILTER";
			this.rdoFilter.Text = "Filter";
			this.rdoFilter.UseVisualStyleBackColor = true;
			// 
			// rdoAllCustomers
			// 
			this.rdoAllCustomers.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoAllCustomers.Location = new System.Drawing.Point(106, 2);
			this.rdoAllCustomers.Name = "rdoAllCustomers";
			this.rdoAllCustomers.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.rdoAllCustomers.Size = new System.Drawing.Size(137, 24);
			this.rdoAllCustomers.TabIndex = 1;
			this.rdoAllCustomers.TabStop = true;
			this.rdoAllCustomers.Tag = "ALL";
			this.rdoAllCustomers.Text = "All Customers";
			this.rdoAllCustomers.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "View Customer :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlLower
			// 
			this.pnlLower.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlLower.Location = new System.Drawing.Point(2, 381);
			this.pnlLower.Name = "pnlLower";
			this.pnlLower.Padding = new System.Windows.Forms.Padding(2);
			this.pnlLower.Size = new System.Drawing.Size(666, 34);
			this.pnlLower.TabIndex = 1;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(2, 76);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(666, 305);
			this.pnlBody.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(662, 301);
			this.dgv.TabIndex = 0;
			// 
			// ListMasterCustomers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlLower);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Leelawadee", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.Name = "ListMasterCustomers";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Size = new System.Drawing.Size(670, 417);
			this.Load += new System.EventHandler(this.ListMasterCustomers_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlSearchCustomer.ResumeLayout(false);
			this.pnlSearchCustomer.PerformLayout();
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlLower;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlSearchCustomer;
		private System.Windows.Forms.RadioButton rdoFilter;
		private System.Windows.Forms.RadioButton rdoAllCustomers;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSearch;
	}
}
