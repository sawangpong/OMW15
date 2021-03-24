namespace OMW15.Views.Sales
{
	partial class PriceList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceList));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.cbxSearchType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.btnSearch = new OMControls.OMFlatButton();
			this.pnlToolBar = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsSepAdd = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.tsSepEdit = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.tsSepRefresh = new System.Windows.Forms.ToolStripSeparator();
			this.pnlGrid = new System.Windows.Forms.Panel();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlStatus = new System.Windows.Forms.Panel();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.pnlSelect = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlTop.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlToolBar.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.pnlGrid.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlStatus.SuspendLayout();
			this.pnlSelect.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel3);
			this.pnlTop.Controls.Add(this.pnlToolBar);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(942, 91);
			this.pnlTop.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel3.Controls.Add(this.lbMode);
			this.panel3.Controls.Add(this.pnlHeader);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(942, 52);
			this.panel3.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Gold;
			this.lbMode.Location = new System.Drawing.Point(845, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(95, 20);
			this.lbMode.TabIndex = 2;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.cbxSearchType);
			this.pnlHeader.Controls.Add(this.label2);
			this.pnlHeader.Controls.Add(this.txtFilter);
			this.pnlHeader.Controls.Add(this.btnSearch);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlHeader.Location = new System.Drawing.Point(2, 22);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(938, 28);
			this.pnlHeader.TabIndex = 1;
			// 
			// cbxSearchType
			// 
			this.cbxSearchType.Dock = System.Windows.Forms.DockStyle.Right;
			this.cbxSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSearchType.FormattingEnabled = true;
			this.cbxSearchType.Location = new System.Drawing.Point(552, 2);
			this.cbxSearchType.Name = "cbxSearchType";
			this.cbxSearchType.Size = new System.Drawing.Size(155, 25);
			this.cbxSearchType.TabIndex = 4;
			this.cbxSearchType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchType_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(154, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "ราคาขายสินค้า";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFilter
			// 
			this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtFilter.Location = new System.Drawing.Point(707, 2);
			this.txtFilter.MaxLength = 50;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(205, 25);
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
			this.btnSearch.Location = new System.Drawing.Point(912, 2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(24, 24);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// pnlToolBar
			// 
			this.pnlToolBar.Controls.Add(this.toolStrip1);
			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlToolBar.Location = new System.Drawing.Point(0, 52);
			this.pnlToolBar.Name = "pnlToolBar";
			this.pnlToolBar.Padding = new System.Windows.Forms.Padding(4);
			this.pnlToolBar.Size = new System.Drawing.Size(942, 39);
			this.pnlToolBar.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnAdd,
            this.tsSepAdd,
            this.tsbtnEdit,
            this.tsSepEdit,
            this.tsbtnRefresh,
            this.tsSepRefresh});
			this.toolStrip1.Location = new System.Drawing.Point(4, 4);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(934, 31);
			this.toolStrip1.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(80, 28);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(80, 28);
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// tsSepAdd
			// 
			this.tsSepAdd.Name = "tsSepAdd";
			this.tsSepAdd.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(80, 28);
			this.tsbtnEdit.Text = "&Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// tsSepEdit
			// 
			this.tsSepEdit.Name = "tsSepEdit";
			this.tsSepEdit.Size = new System.Drawing.Size(6, 31);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(80, 28);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// tsSepRefresh
			// 
			this.tsSepRefresh.Name = "tsSepRefresh";
			this.tsSepRefresh.Size = new System.Drawing.Size(6, 31);
			// 
			// pnlGrid
			// 
			this.pnlGrid.Controls.Add(this.pnlBody);
			this.pnlGrid.Controls.Add(this.pnlSelect);
			this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGrid.Location = new System.Drawing.Point(0, 91);
			this.pnlGrid.Name = "pnlGrid";
			this.pnlGrid.Padding = new System.Windows.Forms.Padding(2);
			this.pnlGrid.Size = new System.Drawing.Size(942, 422);
			this.pnlGrid.TabIndex = 2;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Controls.Add(this.pnlStatus);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(2, 2);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(938, 379);
			this.pnlBody.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(934, 344);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_CellFormatting);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlStatus
			// 
			this.pnlStatus.Controls.Add(this.lbRowCount);
			this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlStatus.Location = new System.Drawing.Point(2, 346);
			this.pnlStatus.Name = "pnlStatus";
			this.pnlStatus.Padding = new System.Windows.Forms.Padding(2);
			this.pnlStatus.Size = new System.Drawing.Size(934, 31);
			this.pnlStatus.TabIndex = 2;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowCount.Location = new System.Drawing.Point(2, 2);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(174, 27);
			this.lbRowCount.TabIndex = 0;
			this.lbRowCount.Text = "found : 0 item";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlSelect
			// 
			this.pnlSelect.Controls.Add(this.btnCancel);
			this.pnlSelect.Controls.Add(this.btnSelect);
			this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSelect.Location = new System.Drawing.Point(2, 381);
			this.pnlSelect.Name = "pnlSelect";
			this.pnlSelect.Padding = new System.Windows.Forms.Padding(3);
			this.pnlSelect.Size = new System.Drawing.Size(938, 39);
			this.pnlSelect.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(802, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(133, 33);
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
			this.btnSelect.Size = new System.Drawing.Size(133, 33);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// PriceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(942, 513);
			this.Controls.Add(this.pnlGrid);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PriceList";
			this.Text = "PRICE LIST";
			this.Load += new System.EventHandler(this.PriceList_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlHeader.PerformLayout();
			this.pnlToolBar.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.pnlGrid.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlStatus.ResumeLayout(false);
			this.pnlSelect.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel pnlToolBar;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.TextBox txtFilter;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.Panel pnlGrid;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator tsSepAdd;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator tsSepEdit;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator tsSepRefresh;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbxSearchType;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlStatus;
		private System.Windows.Forms.Label lbRowCount;
		private System.Windows.Forms.Panel pnlSelect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label lbMode;
	}
}