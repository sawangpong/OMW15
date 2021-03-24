namespace OMW15.Views.Sales
{
	partial class STDPriceList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STDPriceList));
			this.pnlTop = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCount = new System.Windows.Forms.Label();
			this.btnSearch = new OMControls.OMFlatButton();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.cbxSearchCat = new System.Windows.Forms.ComboBox();
			this.lbSearchTitle = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.tsSepClose = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnLoad = new System.Windows.Forms.ToolStripButton();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlTop.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.pnlRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.panel2);
			this.pnlTop.Controls.Add(this.toolStrip1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(4, 4);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(3);
			this.pnlTop.Size = new System.Drawing.Size(821, 74);
			this.pnlTop.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCount);
			this.panel2.Controls.Add(this.btnSearch);
			this.panel2.Controls.Add(this.txtFilter);
			this.panel2.Controls.Add(this.cbxSearchCat);
			this.panel2.Controls.Add(this.lbSearchTitle);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 41);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(815, 29);
			this.panel2.TabIndex = 1;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbCount.Location = new System.Drawing.Point(701, 2);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(112, 25);
			this.lbCount.TabIndex = 7;
			this.lbCount.Text = "found : 0";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnSearch
			// 
			this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(379, 2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(25, 25);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtFilter
			// 
			this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtFilter.Location = new System.Drawing.Point(228, 2);
			this.txtFilter.MaxLength = 50;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(151, 25);
			this.txtFilter.TabIndex = 4;
			this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
			this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
			// 
			// cbxSearchCat
			// 
			this.cbxSearchCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxSearchCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSearchCat.FormattingEnabled = true;
			this.cbxSearchCat.Location = new System.Drawing.Point(68, 2);
			this.cbxSearchCat.Name = "cbxSearchCat";
			this.cbxSearchCat.Size = new System.Drawing.Size(160, 25);
			this.cbxSearchCat.TabIndex = 3;
			this.cbxSearchCat.Visible = false;
			// 
			// lbSearchTitle
			// 
			this.lbSearchTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSearchTitle.Location = new System.Drawing.Point(2, 2);
			this.lbSearchTitle.Name = "lbSearchTitle";
			this.lbSearchTitle.Size = new System.Drawing.Size(66, 25);
			this.lbSearchTitle.TabIndex = 0;
			this.lbSearchTitle.Text = "ค้นหา : ";
			this.lbSearchTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnClose,
            this.tsSepClose,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.tsbtnLoad});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(815, 38);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "ts";
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(40, 35);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// tsSepClose
			// 
			this.tsSepClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSepClose.Name = "tsSepClose";
			this.tsSepClose.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(233, 35);
			this.toolStripLabel1.Text = "ERP Standard Cost && Price";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnLoad
			// 
			this.tsbtnLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLoad.Image")));
			this.tsbtnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnLoad.Name = "tsbtnLoad";
			this.tsbtnLoad.Size = new System.Drawing.Size(37, 35);
			this.tsbtnLoad.Text = "Load";
			this.tsbtnLoad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnLoad.Visible = false;
			this.tsbtnLoad.Click += new System.EventHandler(this.tsbtnLoad_Click);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnClose);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(4, 457);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(5);
			this.pnlCommand.Size = new System.Drawing.Size(821, 44);
			this.pnlCommand.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(717, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(99, 34);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(5, 5);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(99, 34);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.pic);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlRight.Location = new System.Drawing.Point(688, 78);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(2);
			this.pnlRight.Size = new System.Drawing.Size(137, 379);
			this.pnlRight.TabIndex = 3;
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Location = new System.Drawing.Point(2, 2);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(133, 146);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.dgv);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlLeft.Location = new System.Drawing.Point(4, 78);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(2);
			this.pnlLeft.Size = new System.Drawing.Size(684, 379);
			this.pnlLeft.TabIndex = 4;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(680, 375);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// STDPriceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(829, 505);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "STDPriceList";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "STANDARD PRICELIST";
			this.Load += new System.EventHandler(this.STDPriceList_Load);
			this.pnlTop.ResumeLayout(false);
			this.pnlTop.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator tsSepClose;
		private System.Windows.Forms.ToolStripButton tsbtnLoad;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbSearchTitle;
		private System.Windows.Forms.ComboBox cbxSearchCat;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;
	}
}