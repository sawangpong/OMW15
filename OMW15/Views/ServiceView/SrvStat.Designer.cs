namespace OMW15.Views.ServiceView
{
	partial class SrvStat
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
			if(disposing && (components != null))
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
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.lbTag = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlBodyRight = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlBodyRightHeader = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlBodyLeft = new System.Windows.Forms.Panel();
			this.lstStatType = new System.Windows.Forms.ListBox();
			this.pnlBodyLeftHeader = new System.Windows.Forms.Panel();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlBodyRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlBodyRightHeader.SuspendLayout();
			this.pnlBodyLeft.SuspendLayout();
			this.pnlBodyLeftHeader.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlHeader.Controls.Add(this.label2);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(920, 45);
			this.pnlHeader.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(198, 39);
			this.label2.TabIndex = 2;
			this.label2.Text = "สถิติงานบริการ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.lbTag);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottom.Location = new System.Drawing.Point(0, 491);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBottom.Size = new System.Drawing.Size(920, 27);
			this.pnlBottom.TabIndex = 1;
			// 
			// lbTag
			// 
			this.lbTag.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTag.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTag.Location = new System.Drawing.Point(2, 2);
			this.lbTag.Name = "lbTag";
			this.lbTag.Size = new System.Drawing.Size(164, 23);
			this.lbTag.TabIndex = 0;
			this.lbTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlBodyRight);
			this.pnlBody.Controls.Add(this.splitter1);
			this.pnlBody.Controls.Add(this.pnlBodyLeft);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 45);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(920, 446);
			this.pnlBody.TabIndex = 2;
			// 
			// pnlBodyRight
			// 
			this.pnlBodyRight.Controls.Add(this.dgv);
			this.pnlBodyRight.Controls.Add(this.pnlBodyRightHeader);
			this.pnlBodyRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBodyRight.Location = new System.Drawing.Point(174, 2);
			this.pnlBodyRight.Name = "pnlBodyRight";
			this.pnlBodyRight.Size = new System.Drawing.Size(744, 442);
			this.pnlBodyRight.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(0, 30);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(744, 412);
			this.dgv.TabIndex = 2;
			// 
			// pnlBodyRightHeader
			// 
			this.pnlBodyRightHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBodyRightHeader.Controls.Add(this.lbTitle);
			this.pnlBodyRightHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBodyRightHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlBodyRightHeader.Name = "pnlBodyRightHeader";
			this.pnlBodyRightHeader.Padding = new System.Windows.Forms.Padding(1);
			this.pnlBodyRightHeader.Size = new System.Drawing.Size(744, 30);
			this.pnlBodyRightHeader.TabIndex = 1;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(1, 1);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(256, 26);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "Title";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(168, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 442);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// pnlBodyLeft
			// 
			this.pnlBodyLeft.Controls.Add(this.lstStatType);
			this.pnlBodyLeft.Controls.Add(this.pnlBodyLeftHeader);
			this.pnlBodyLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBodyLeft.Location = new System.Drawing.Point(2, 2);
			this.pnlBodyLeft.Name = "pnlBodyLeft";
			this.pnlBodyLeft.Size = new System.Drawing.Size(166, 442);
			this.pnlBodyLeft.TabIndex = 0;
			// 
			// lstStatType
			// 
			this.lstStatType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstStatType.FormattingEnabled = true;
			this.lstStatType.IntegralHeight = false;
			this.lstStatType.ItemHeight = 17;
			this.lstStatType.Location = new System.Drawing.Point(0, 30);
			this.lstStatType.Name = "lstStatType";
			this.lstStatType.Size = new System.Drawing.Size(166, 412);
			this.lstStatType.TabIndex = 3;
			this.lstStatType.SelectedValueChanged += new System.EventHandler(this.lstStatType_SelectedValueChanged);
			// 
			// pnlBodyLeftHeader
			// 
			this.pnlBodyLeftHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlBodyLeftHeader.Controls.Add(this.cbxYear);
			this.pnlBodyLeftHeader.Controls.Add(this.label3);
			this.pnlBodyLeftHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlBodyLeftHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlBodyLeftHeader.Name = "pnlBodyLeftHeader";
			this.pnlBodyLeftHeader.Padding = new System.Windows.Forms.Padding(1);
			this.pnlBodyLeftHeader.Size = new System.Drawing.Size(166, 30);
			this.pnlBodyLeftHeader.TabIndex = 2;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(51, 1);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(112, 25);
			this.cbxYear.TabIndex = 2;
			this.cbxYear.SelectedValueChanged += new System.EventHandler(this.cbxYear_SelectedValueChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "Year:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SrvStat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(920, 518);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SrvStat";
			this.Text = "งานบริการ";
			this.Load += new System.EventHandler(this.SrvStat_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlBottom.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			this.pnlBodyRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlBodyRightHeader.ResumeLayout(false);
			this.pnlBodyLeft.ResumeLayout(false);
			this.pnlBodyLeftHeader.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlBottom;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel pnlBodyRight;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlBodyRightHeader;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlBodyLeft;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlBodyLeftHeader;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox lstStatType;
		private System.Windows.Forms.Label lbTag;
	}
}