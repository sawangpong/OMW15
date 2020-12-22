namespace OMW15.Views.WarehouseView
{
	partial class WHMonitor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHMonitor));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlRightBottom = new System.Windows.Forms.Panel();
			this.dgvOnHand = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbId = new System.Windows.Forms.Label();
			this.lbOnHandRowCount = new System.Windows.Forms.Label();
			this.lbItemId = new System.Windows.Forms.Label();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.lbCatCode = new System.Windows.Forms.Label();
			this.cbxSearchType = new System.Windows.Forms.ComboBox();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.btnSearch = new OMControls.OMFlatButton();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.pnlRightTop = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pic1 = new System.Windows.Forms.PictureBox();
			this.pnlHolder = new System.Windows.Forms.Panel();
			this.pnlTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlRightBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvOnHand)).BeginInit();
			this.panel1.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			this.pnlRightTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.Color.Gray;
			this.pnlTop.Controls.Add(this.label1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(930, 42);
			this.pnlTop.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(201, 38);
			this.label1.TabIndex = 1;
			this.label1.Text = "STOCK MONITOR";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pnlRightBottom);
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.pnlRightTop);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.pnlLeft);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 42);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(930, 492);
			this.panel2.TabIndex = 3;
			// 
			// pnlRightBottom
			// 
			this.pnlRightBottom.Controls.Add(this.dgvOnHand);
			this.pnlRightBottom.Controls.Add(this.panel1);
			this.pnlRightBottom.Controls.Add(this.pnlSearch);
			this.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRightBottom.Location = new System.Drawing.Point(138, 208);
			this.pnlRightBottom.Name = "pnlRightBottom";
			this.pnlRightBottom.Size = new System.Drawing.Size(788, 280);
			this.pnlRightBottom.TabIndex = 5;
			// 
			// dgvOnHand
			// 
			this.dgvOnHand.BackgroundColor = System.Drawing.Color.White;
			this.dgvOnHand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvOnHand.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvOnHand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOnHand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvOnHand.GridColor = System.Drawing.Color.White;
			this.dgvOnHand.Location = new System.Drawing.Point(0, 30);
			this.dgvOnHand.Name = "dgvOnHand";
			this.dgvOnHand.Size = new System.Drawing.Size(788, 223);
			this.dgvOnHand.TabIndex = 7;
			this.dgvOnHand.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOnHand_CellEnter);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbId);
			this.panel1.Controls.Add(this.lbOnHandRowCount);
			this.panel1.Controls.Add(this.lbItemId);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(0, 253);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(788, 27);
			this.panel1.TabIndex = 6;
			// 
			// lbId
			// 
			this.lbId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbId.Location = new System.Drawing.Point(583, 1);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(102, 25);
			this.lbId.TabIndex = 2;
			this.lbId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbOnHandRowCount
			// 
			this.lbOnHandRowCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbOnHandRowCount.Location = new System.Drawing.Point(1, 1);
			this.lbOnHandRowCount.Name = "lbOnHandRowCount";
			this.lbOnHandRowCount.Size = new System.Drawing.Size(144, 25);
			this.lbOnHandRowCount.TabIndex = 1;
			this.lbOnHandRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbItemId
			// 
			this.lbItemId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbItemId.Location = new System.Drawing.Point(685, 1);
			this.lbItemId.Name = "lbItemId";
			this.lbItemId.Size = new System.Drawing.Size(102, 25);
			this.lbItemId.TabIndex = 0;
			this.lbItemId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.label2);
			this.pnlSearch.Controls.Add(this.lbCatCode);
			this.pnlSearch.Controls.Add(this.cbxSearchType);
			this.pnlSearch.Controls.Add(this.txtFilter);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlSearch.Location = new System.Drawing.Point(0, 0);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Padding = new System.Windows.Forms.Padding(2);
			this.pnlSearch.Size = new System.Drawing.Size(788, 30);
			this.pnlSearch.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(337, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = "ค้นหา : ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbCatCode
			// 
			this.lbCatCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCatCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCatCode.Location = new System.Drawing.Point(2, 2);
			this.lbCatCode.Name = "lbCatCode";
			this.lbCatCode.Size = new System.Drawing.Size(157, 26);
			this.lbCatCode.TabIndex = 3;
			this.lbCatCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbxSearchType
			// 
			this.cbxSearchType.Dock = System.Windows.Forms.DockStyle.Right;
			this.cbxSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSearchType.FormattingEnabled = true;
			this.cbxSearchType.Location = new System.Drawing.Point(412, 2);
			this.cbxSearchType.Name = "cbxSearchType";
			this.cbxSearchType.Size = new System.Drawing.Size(115, 25);
			this.cbxSearchType.TabIndex = 2;
			this.cbxSearchType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchType_SelectedIndexChanged);
			// 
			// txtFilter
			// 
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtFilter.Location = new System.Drawing.Point(527, 2);
			this.txtFilter.MaxLength = 50;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(233, 25);
			this.txtFilter.TabIndex = 1;
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
			// 
			// btnSearch
			// 
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(760, 2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(26, 26);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(138, 202);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(788, 6);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// pnlRightTop
			// 
			this.pnlRightTop.Controls.Add(this.dgv);
			this.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlRightTop.Location = new System.Drawing.Point(138, 2);
			this.pnlRightTop.Name = "pnlRightTop";
			this.pnlRightTop.Size = new System.Drawing.Size(788, 200);
			this.pnlRightTop.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
			this.dgv.Location = new System.Drawing.Point(0, 0);
			this.dgv.Name = "dgv";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgv.Size = new System.Drawing.Size(788, 200);
			this.dgv.TabIndex = 6;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(132, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 486);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.pic1);
			this.pnlLeft.Controls.Add(this.pnlHolder);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(2, 2);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(4);
			this.pnlLeft.Size = new System.Drawing.Size(130, 486);
			this.pnlLeft.TabIndex = 1;
			// 
			// pic1
			// 
			this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic1.Location = new System.Drawing.Point(4, 199);
			this.pic1.Name = "pic1";
			this.pic1.Size = new System.Drawing.Size(120, 136);
			this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic1.TabIndex = 1;
			this.pic1.TabStop = false;
			// 
			// pnlHolder
			// 
			this.pnlHolder.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHolder.Location = new System.Drawing.Point(4, 4);
			this.pnlHolder.Name = "pnlHolder";
			this.pnlHolder.Size = new System.Drawing.Size(120, 195);
			this.pnlHolder.TabIndex = 0;
			// 
			// WHMonitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(930, 534);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "WHMonitor";
			this.Text = "WAREHOUSE ANALISYS";
			this.Load += new System.EventHandler(this.WHMonitor_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlRightBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvOnHand)).EndInit();
			this.panel1.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.pnlRightTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlRightBottom;
		private System.Windows.Forms.Panel pnlSearch;
		private System.Windows.Forms.ComboBox cbxSearchType;
		private System.Windows.Forms.TextBox txtFilter;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel pnlRightTop;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.DataGridView dgvOnHand;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbItemId;
		private System.Windows.Forms.Label lbOnHandRowCount;
		private System.Windows.Forms.Label lbCatCode;
		private System.Windows.Forms.Label lbId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlHolder;
		private System.Windows.Forms.PictureBox pic1;
	}
}