namespace OMW15.Views.CustomerView
{
	partial class CustomerSearch
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlCommandTop = new System.Windows.Forms.Panel();
			this.searchBox1 = new OMControls.Controls.searchBox();
			this.rdoSearchByCode = new System.Windows.Forms.RadioButton();
			this.rdoSearchByName = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCustName = new System.Windows.Forms.Label();
			this.lbMatch = new System.Windows.Forms.Label();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlCommandTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgv);
			this.panel1.Controls.Add(this.pnlCommandTop);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(791, 363);
			this.panel1.TabIndex = 1;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 32);
			this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(787, 287);
			this.dgv.TabIndex = 3;
			this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlCommandTop
			// 
			this.pnlCommandTop.Controls.Add(this.searchBox1);
			this.pnlCommandTop.Controls.Add(this.rdoSearchByCode);
			this.pnlCommandTop.Controls.Add(this.rdoSearchByName);
			this.pnlCommandTop.Controls.Add(this.label1);
			this.pnlCommandTop.Controls.Add(this.button1);
			this.pnlCommandTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCommandTop.Location = new System.Drawing.Point(2, 2);
			this.pnlCommandTop.Name = "pnlCommandTop";
			this.pnlCommandTop.Padding = new System.Windows.Forms.Padding(1);
			this.pnlCommandTop.Size = new System.Drawing.Size(787, 30);
			this.pnlCommandTop.TabIndex = 2;
			// 
			// searchBox1
			// 
			this.searchBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.searchBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.searchBox1.Location = new System.Drawing.Point(281, 1);
			this.searchBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.searchBox1.Name = "searchBox1";
			this.searchBox1.Padding = new System.Windows.Forms.Padding(1);
			this.searchBox1.Size = new System.Drawing.Size(353, 28);
			this.searchBox1.TabIndex = 4;
			this.searchBox1.TextFilter = null;
			this.searchBox1.OnSendingFiler += new OMControls.Controls.SendingFilter(this.searchBox1_OnSendingFiler);
			this.searchBox1.Load += new System.EventHandler(this.searchBox1_Load);
			// 
			// rdoSearchByCode
			// 
			this.rdoSearchByCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoSearchByCode.Location = new System.Drawing.Point(187, 1);
			this.rdoSearchByCode.Name = "rdoSearchByCode";
			this.rdoSearchByCode.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rdoSearchByCode.Size = new System.Drawing.Size(94, 28);
			this.rdoSearchByCode.TabIndex = 3;
			this.rdoSearchByCode.TabStop = true;
			this.rdoSearchByCode.Tag = "BY_CODE";
			this.rdoSearchByCode.Text = "รหัสลูกค้า";
			this.rdoSearchByCode.UseVisualStyleBackColor = true;
			this.rdoSearchByCode.Visible = false;
			this.rdoSearchByCode.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
			// 
			// rdoSearchByName
			// 
			this.rdoSearchByName.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoSearchByName.Location = new System.Drawing.Point(93, 1);
			this.rdoSearchByName.Name = "rdoSearchByName";
			this.rdoSearchByName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rdoSearchByName.Size = new System.Drawing.Size(94, 28);
			this.rdoSearchByName.TabIndex = 2;
			this.rdoSearchByName.TabStop = true;
			this.rdoSearchByName.Tag = "BY_NAME";
			this.rdoSearchByName.Text = "รายชื่อ";
			this.rdoSearchByName.UseVisualStyleBackColor = true;
			this.rdoSearchByName.Visible = false;
			this.rdoSearchByName.CheckedChanged += new System.EventHandler(this.rdoSearch_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 28);
			this.label1.TabIndex = 1;
			this.label1.Text = "ค้นหาลูกค้า :: ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Right;
			this.button1.Image = global::OMW15.Properties.Resources.CLOSE;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(703, 1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(83, 28);
			this.button1.TabIndex = 0;
			this.button1.Text = "&Close";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCustName);
			this.panel2.Controls.Add(this.lbMatch);
			this.panel2.Controls.Add(this.lbCustCode);
			this.panel2.Controls.Add(this.btnSelect);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(2, 319);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel2.Size = new System.Drawing.Size(787, 42);
			this.panel2.TabIndex = 0;
			// 
			// lbCustName
			// 
			this.lbCustName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustName.Location = new System.Drawing.Point(163, 5);
			this.lbCustName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCustName.Name = "lbCustName";
			this.lbCustName.Size = new System.Drawing.Size(471, 32);
			this.lbCustName.TabIndex = 5;
			this.lbCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMatch
			// 
			this.lbMatch.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMatch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMatch.Location = new System.Drawing.Point(634, 5);
			this.lbMatch.Name = "lbMatch";
			this.lbMatch.Size = new System.Drawing.Size(149, 32);
			this.lbMatch.TabIndex = 4;
			this.lbMatch.Text = "match found :: (0) ";
			this.lbMatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCustCode
			// 
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustCode.Location = new System.Drawing.Point(93, 5);
			this.lbCustCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(70, 32);
			this.lbCustCode.TabIndex = 1;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(4, 5);
			this.btnSelect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(89, 32);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// CustomerSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(801, 373);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
			this.Name = "CustomerSearch";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "CUSTOMER SEARCH";
			this.Load += new System.EventHandler(this.CustomerSearch_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlCommandTop.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label lbCustCode;
		private System.Windows.Forms.Panel pnlCommandTop;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton rdoSearchByCode;
		private System.Windows.Forms.RadioButton rdoSearchByName;
		private OMControls.Controls.searchBox searchBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbCustName;
		private System.Windows.Forms.Label lbMatch;
		private System.Windows.Forms.DataGridView dgv;
	}
}