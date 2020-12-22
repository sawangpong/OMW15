namespace OMW15.Master.MasterView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSearch));
			this.ts = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsSp1 = new System.Windows.Forms.ToolStripSplitButton();
			this.tsmnuByCustName = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmnuByCustCode = new System.Windows.Forms.ToolStripMenuItem();
			this.tstxtSearchText = new System.Windows.Forms.ToolStripTextBox();
			this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tslbStatus = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbCustName = new System.Windows.Forms.Label();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.ts.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsSp1,
            this.tstxtSearchText,
            this.tsbtnSearch,
            this.tsbtnClose,
            this.toolStripSeparator3,
            this.tslbStatus,
            this.toolStripSeparator2});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.Size = new System.Drawing.Size(706, 31);
			this.ts.TabIndex = 0;
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(71, 28);
			this.toolStripLabel1.Text = "Customer :";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			// 
			// tsSp1
			// 
			this.tsSp1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsSp1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmnuByCustName,
            this.tsmnuByCustCode});
			this.tsSp1.Image = ((System.Drawing.Image)(resources.GetObject("tsSp1.Image")));
			this.tsSp1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSp1.Name = "tsSp1";
			this.tsSp1.Size = new System.Drawing.Size(73, 28);
			this.tsSp1.Text = "วิธีค้นหา :";
			// 
			// tsmnuByCustName
			// 
			this.tsmnuByCustName.Name = "tsmnuByCustName";
			this.tsmnuByCustName.Size = new System.Drawing.Size(124, 22);
			this.tsmnuByCustName.Tag = "BY_NAME";
			this.tsmnuByCustName.Text = "รายชื่อ";
			this.tsmnuByCustName.Click += new System.EventHandler(this.tsmnu_Click);
			// 
			// tsmnuByCustCode
			// 
			this.tsmnuByCustCode.Name = "tsmnuByCustCode";
			this.tsmnuByCustCode.Size = new System.Drawing.Size(124, 22);
			this.tsmnuByCustCode.Tag = "BY_CODE";
			this.tsmnuByCustCode.Text = "รหัสลูกค้า";
			this.tsmnuByCustCode.Click += new System.EventHandler(this.tsmnu_Click);
			// 
			// tstxtSearchText
			// 
			this.tstxtSearchText.AutoSize = false;
			this.tstxtSearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tstxtSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.tstxtSearchText.MaxLength = 50;
			this.tstxtSearchText.Name = "tstxtSearchText";
			this.tstxtSearchText.Size = new System.Drawing.Size(195, 24);
			this.tstxtSearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstxtSearchText_KeyPress);
			this.tstxtSearchText.TextChanged += new System.EventHandler(this.tstxtSearchText_TextChanged);
			// 
			// tsbtnSearch
			// 
			this.tsbtnSearch.AutoSize = false;
			this.tsbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSearch.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearch.Name = "tsbtnSearch";
			this.tsbtnSearch.Size = new System.Drawing.Size(30, 46);
			this.tsbtnSearch.Text = "toolStripButton1";
			this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(30, 30);
			this.tsbtnClose.ToolTipText = "Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			// 
			// tslbStatus
			// 
			this.tslbStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tslbStatus.Name = "tslbStatus";
			this.tslbStatus.Size = new System.Drawing.Size(107, 28);
			this.tslbStatus.Text = "match found : (0)";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgv);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 31);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(706, 342);
			this.panel1.TabIndex = 1;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.Size = new System.Drawing.Size(702, 296);
			this.dgv.TabIndex = 1;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbCustName);
			this.panel2.Controls.Add(this.lbCustCode);
			this.panel2.Controls.Add(this.btnSelect);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(2, 298);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel2.Size = new System.Drawing.Size(702, 42);
			this.panel2.TabIndex = 0;
			// 
			// lbCustName
			// 
			this.lbCustName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustName.Location = new System.Drawing.Point(163, 5);
			this.lbCustName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCustName.Name = "lbCustName";
			this.lbCustName.Size = new System.Drawing.Size(535, 32);
			this.lbCustName.TabIndex = 2;
			this.lbCustName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// CustomerSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 373);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
			this.Name = "CustomerSearch";
			this.Text = "SEARCH";
			this.Load += new System.EventHandler(this.CustomerSearch_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripTextBox tstxtSearchText;
		private System.Windows.Forms.ToolStripSplitButton tsSp1;
		private System.Windows.Forms.ToolStripMenuItem tsmnuByCustName;
		private System.Windows.Forms.ToolStripMenuItem tsmnuByCustCode;
		private System.Windows.Forms.ToolStripButton tsbtnSearch;
		private System.Windows.Forms.ToolStripLabel tslbStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label lbCustName;
		private System.Windows.Forms.Label lbCustCode;
	}
}