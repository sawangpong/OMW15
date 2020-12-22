namespace OMW15.Views.Productions
{
	partial class ItemStat
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tsTxtFilter = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.miniToolStrip = new System.Windows.Forms.StatusStrip();
			this.lbStdItems = new System.Windows.Forms.Label();
			this.sbstd = new System.Windows.Forms.StatusStrip();
			this.sbstdlbCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.tslbSelectedItemNo = new System.Windows.Forms.ToolStripStatusLabel();
			this.dgvSTD = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvProduction = new System.Windows.Forms.DataGridView();
			this.lbProductiontionJob = new System.Windows.Forms.Label();
			this.sbstat = new System.Windows.Forms.StatusStrip();
			this.tslbProductionHistoryFound = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dgvCompare = new System.Windows.Forms.DataGridView();
			this.lbJobCompare = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.sbstd.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSTD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProduction)).BeginInit();
			this.sbstat.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsTxtFilter,
            this.tsbtnSearch,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(996, 38);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.AutoSize = false;
			this.toolStripButton1.Image = global::OMW15.Properties.Resources.CLOSE;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(55, 35);
			this.toolStripButton1.Text = "&Close";
			this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.AutoSize = false;
			this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(50, 35);
			this.toolStripLabel1.Text = "ค้นหา:";
			// 
			// tsTxtFilter
			// 
			this.tsTxtFilter.AutoSize = false;
			this.tsTxtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tsTxtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tsTxtFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.tsTxtFilter.MaxLength = 25;
			this.tsTxtFilter.Name = "tsTxtFilter";
			this.tsTxtFilter.Size = new System.Drawing.Size(150, 25);
			this.tsTxtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tsTxtFilter_KeyPress);
			// 
			// tsbtnSearch
			// 
			this.tsbtnSearch.AutoSize = false;
			this.tsbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSearch.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearch.Name = "tsbtnSearch";
			this.tsbtnSearch.Size = new System.Drawing.Size(30, 35);
			this.tsbtnSearch.Text = "toolStripButton2";
			this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 38);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(50, 35);
			this.tsbtnRefresh.Text = "Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 290);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(996, 6);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// miniToolStrip
			// 
			this.miniToolStrip.AccessibleName = "New item selection";
			this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.Location = new System.Drawing.Point(1, 1);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Size = new System.Drawing.Size(439, 22);
			this.miniToolStrip.TabIndex = 2;
			// 
			// lbStdItems
			// 
			this.lbStdItems.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbStdItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbStdItems.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStdItems.ForeColor = System.Drawing.Color.White;
			this.lbStdItems.Location = new System.Drawing.Point(2, 2);
			this.lbStdItems.Name = "lbStdItems";
			this.lbStdItems.Size = new System.Drawing.Size(540, 35);
			this.lbStdItems.TabIndex = 0;
			this.lbStdItems.Text = "Standard items";
			this.lbStdItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sbstd
			// 
			this.sbstd.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.sbstd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbstdlbCount,
            this.tslbSelectedItemNo});
			this.sbstd.Location = new System.Drawing.Point(2, 226);
			this.sbstd.Name = "sbstd";
			this.sbstd.Size = new System.Drawing.Size(540, 22);
			this.sbstd.TabIndex = 1;
			this.sbstd.Text = "statusStrip1";
			// 
			// sbstdlbCount
			// 
			this.sbstdlbCount.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.sbstdlbCount.Name = "sbstdlbCount";
			this.sbstdlbCount.Size = new System.Drawing.Size(54, 17);
			this.sbstdlbCount.Text = "found : 0";
			// 
			// tslbSelectedItemNo
			// 
			this.tslbSelectedItemNo.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.tslbSelectedItemNo.Name = "tslbSelectedItemNo";
			this.tslbSelectedItemNo.Size = new System.Drawing.Size(11, 17);
			this.tslbSelectedItemNo.Text = "-";
			// 
			// dgvSTD
			// 
			this.dgvSTD.BackgroundColor = System.Drawing.Color.White;
			this.dgvSTD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSTD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSTD.Location = new System.Drawing.Point(2, 37);
			this.dgvSTD.Name = "dgvSTD";
			this.dgvSTD.Size = new System.Drawing.Size(540, 189);
			this.dgvSTD.TabIndex = 2;
			this.dgvSTD.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSTD_CellEnter);
			this.dgvSTD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSTD_MouseClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitContainer1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 38);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvSTD);
			this.splitContainer1.Panel1.Controls.Add(this.sbstd);
			this.splitContainer1.Panel1.Controls.Add(this.lbStdItems);
			this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.dgvProduction);
			this.splitContainer1.Panel2.Controls.Add(this.lbProductiontionJob);
			this.splitContainer1.Panel2.Controls.Add(this.sbstat);
			this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
			this.splitContainer1.Size = new System.Drawing.Size(996, 252);
			this.splitContainer1.SplitterDistance = 546;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 7;
			// 
			// dgvProduction
			// 
			this.dgvProduction.BackgroundColor = System.Drawing.Color.White;
			this.dgvProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProduction.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProduction.Location = new System.Drawing.Point(2, 37);
			this.dgvProduction.Name = "dgvProduction";
			this.dgvProduction.Size = new System.Drawing.Size(439, 189);
			this.dgvProduction.TabIndex = 4;
			this.dgvProduction.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduction_CellEnter);
			// 
			// lbProductiontionJob
			// 
			this.lbProductiontionJob.BackColor = System.Drawing.Color.Maroon;
			this.lbProductiontionJob.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbProductiontionJob.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbProductiontionJob.ForeColor = System.Drawing.Color.White;
			this.lbProductiontionJob.Location = new System.Drawing.Point(2, 2);
			this.lbProductiontionJob.Name = "lbProductiontionJob";
			this.lbProductiontionJob.Size = new System.Drawing.Size(439, 35);
			this.lbProductiontionJob.TabIndex = 3;
			this.lbProductiontionJob.Text = "Production histories";
			this.lbProductiontionJob.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// sbstat
			// 
			this.sbstat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbProductionHistoryFound});
			this.sbstat.Location = new System.Drawing.Point(2, 226);
			this.sbstat.Name = "sbstat";
			this.sbstat.Size = new System.Drawing.Size(439, 22);
			this.sbstat.TabIndex = 2;
			this.sbstat.Text = "statusStrip2";
			// 
			// tslbProductionHistoryFound
			// 
			this.tslbProductionHistoryFound.Name = "tslbProductionHistoryFound";
			this.tslbProductionHistoryFound.Size = new System.Drawing.Size(54, 17);
			this.tslbProductionHistoryFound.Text = "found : 0";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dgvCompare);
			this.panel2.Controls.Add(this.lbJobCompare);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 296);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(996, 283);
			this.panel2.TabIndex = 10;
			// 
			// dgvCompare
			// 
			this.dgvCompare.BackgroundColor = System.Drawing.Color.White;
			this.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCompare.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCompare.Location = new System.Drawing.Point(2, 37);
			this.dgvCompare.Name = "dgvCompare";
			this.dgvCompare.Size = new System.Drawing.Size(992, 244);
			this.dgvCompare.TabIndex = 9;
			// 
			// lbJobCompare
			// 
			this.lbJobCompare.BackColor = System.Drawing.SystemColors.HotTrack;
			this.lbJobCompare.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbJobCompare.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobCompare.ForeColor = System.Drawing.Color.White;
			this.lbJobCompare.Location = new System.Drawing.Point(2, 2);
			this.lbJobCompare.Name = "lbJobCompare";
			this.lbJobCompare.Size = new System.Drawing.Size(992, 35);
			this.lbJobCompare.TabIndex = 8;
			this.lbJobCompare.Text = "Job compare";
			this.lbJobCompare.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemStat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(996, 579);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "ItemStat";
			this.Text = "WORK HISTORY";
			this.Load += new System.EventHandler(this.ItemStat_Load);
			this.Resize += new System.EventHandler(this.ItemStat_Resize);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.sbstd.ResumeLayout(false);
			this.sbstd.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSTD)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProduction)).EndInit();
			this.sbstat.ResumeLayout(false);
			this.sbstat.PerformLayout();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox tsTxtFilter;
		private System.Windows.Forms.ToolStripButton tsbtnSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.StatusStrip miniToolStrip;
		private System.Windows.Forms.Label lbStdItems;
		private System.Windows.Forms.StatusStrip sbstd;
		private System.Windows.Forms.ToolStripStatusLabel sbstdlbCount;
		private System.Windows.Forms.ToolStripStatusLabel tslbSelectedItemNo;
		private System.Windows.Forms.DataGridView dgvSTD;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvProduction;
		private System.Windows.Forms.Label lbProductiontionJob;
		private System.Windows.Forms.StatusStrip sbstat;
		private System.Windows.Forms.ToolStripStatusLabel tslbProductionHistoryFound;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.DataGridView dgvCompare;
		private System.Windows.Forms.Label lbJobCompare;
	}
}