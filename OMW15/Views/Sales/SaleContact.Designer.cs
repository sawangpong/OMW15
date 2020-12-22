namespace OMW15.Views.Sales
{
	partial class SaleContact
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
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tslbCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlTopMenu = new System.Windows.Forms.Panel();
			this.ta = new System.Windows.Forms.ToolStrip();
			this.tsbtnSearch = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuALLContact = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuContactByName = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuContactByCompany = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSepSearch = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.tsSepRefresh = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsSepAdd = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.tsSepEdit = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.tsSepClose = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
			this.tsSepDelete = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.statusStrip1.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.pnlTopMenu.SuspendLayout();
			this.ta.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbCount});
			this.statusStrip1.Location = new System.Drawing.Point(2, 459);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(840, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tslbCount
			// 
			this.tslbCount.Name = "tslbCount";
			this.tslbCount.Size = new System.Drawing.Size(0, 17);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnClose);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(2, 420);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(5);
			this.pnlCommand.Size = new System.Drawing.Size(840, 39);
			this.pnlCommand.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(723, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(112, 29);
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
			this.btnSelect.Size = new System.Drawing.Size(112, 29);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// pnlTopMenu
			// 
			this.pnlTopMenu.Controls.Add(this.ta);
			this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTopMenu.Location = new System.Drawing.Point(2, 2);
			this.pnlTopMenu.Name = "pnlTopMenu";
			this.pnlTopMenu.Padding = new System.Windows.Forms.Padding(4);
			this.pnlTopMenu.Size = new System.Drawing.Size(840, 49);
			this.pnlTopMenu.TabIndex = 5;
			// 
			// ta
			// 
			this.ta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ta.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnSearch,
            this.tsSepSearch,
            this.tsbtnRefresh,
            this.tsSepRefresh,
            this.tsbtnAdd,
            this.tsSepAdd,
            this.tsbtnEdit,
            this.tsSepEdit,
            this.tsbtnClose,
            this.tsSepClose,
            this.tsbtnDelete,
            this.tsSepDelete});
			this.ta.Location = new System.Drawing.Point(4, 4);
			this.ta.Name = "ta";
			this.ta.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ta.Size = new System.Drawing.Size(832, 41);
			this.ta.TabIndex = 3;
			// 
			// tsbtnSearch
			// 
			this.tsbtnSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuALLContact,
            this.toolStripMenuItem1,
            this.mnuContactByName,
            this.mnuContactByCompany});
			this.tsbtnSearch.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearch.Name = "tsbtnSearch";
			this.tsbtnSearch.Size = new System.Drawing.Size(86, 38);
			this.tsbtnSearch.Text = "Sale Contact";
			this.tsbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			// 
			// mnuALLContact
			// 
			this.mnuALLContact.Name = "mnuALLContact";
			this.mnuALLContact.Size = new System.Drawing.Size(177, 22);
			this.mnuALLContact.Tag = "ALL";
			this.mnuALLContact.Text = "Show All Contacts";
			this.mnuALLContact.Click += new System.EventHandler(this.mnuContact_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
			// 
			// mnuContactByName
			// 
			this.mnuContactByName.Name = "mnuContactByName";
			this.mnuContactByName.Size = new System.Drawing.Size(177, 22);
			this.mnuContactByName.Tag = "NAM";
			this.mnuContactByName.Text = "By Contact Name";
			this.mnuContactByName.Click += new System.EventHandler(this.mnuContact_Click);
			// 
			// mnuContactByCompany
			// 
			this.mnuContactByCompany.Name = "mnuContactByCompany";
			this.mnuContactByCompany.Size = new System.Drawing.Size(177, 22);
			this.mnuContactByCompany.Tag = "COM";
			this.mnuContactByCompany.Text = "By Company Name";
			this.mnuContactByCompany.Click += new System.EventHandler(this.mnuContact_Click);
			// 
			// tsSepSearch
			// 
			this.tsSepSearch.Name = "tsSepSearch";
			this.tsSepSearch.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(65, 44);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// tsSepRefresh
			// 
			this.tsSepRefresh.Name = "tsSepRefresh";
			this.tsSepRefresh.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(65, 42);
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// tsSepAdd
			// 
			this.tsSepAdd.Name = "tsSepAdd";
			this.tsSepAdd.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(65, 42);
			this.tsbtnEdit.Text = "E&dit";
			this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// tsSepEdit
			// 
			this.tsSepEdit.Name = "tsSepEdit";
			this.tsSepEdit.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(65, 42);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// tsSepClose
			// 
			this.tsSepClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSepClose.Name = "tsSepClose";
			this.tsSepClose.Size = new System.Drawing.Size(6, 41);
			// 
			// tsbtnDelete
			// 
			this.tsbtnDelete.AutoSize = false;
			this.tsbtnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDelete.Name = "tsbtnDelete";
			this.tsbtnDelete.Size = new System.Drawing.Size(65, 38);
			this.tsbtnDelete.Text = "&Delete";
			this.tsbtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
			// 
			// tsSepDelete
			// 
			this.tsSepDelete.Name = "tsSepDelete";
			this.tsSepDelete.Size = new System.Drawing.Size(6, 41);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgv);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(2, 51);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(840, 369);
			this.panel1.TabIndex = 7;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(836, 365);
			this.dgv.TabIndex = 7;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// SaleContact
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(844, 483);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.pnlTopMenu);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.statusStrip1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "SaleContact";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Tag = "20100";
			this.Text = "SALE CONTACT";
			this.Load += new System.EventHandler(this.SaleContact_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			this.pnlTopMenu.ResumeLayout(false);
			this.pnlTopMenu.PerformLayout();
			this.ta.ResumeLayout(false);
			this.ta.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Panel pnlTopMenu;
		private System.Windows.Forms.ToolStrip ta;
		private System.Windows.Forms.ToolStripDropDownButton tsbtnSearch;
		private System.Windows.Forms.ToolStripMenuItem mnuALLContact;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuContactByName;
		private System.Windows.Forms.ToolStripMenuItem mnuContactByCompany;
		private System.Windows.Forms.ToolStripSeparator tsSepSearch;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator tsSepRefresh;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator tsSepAdd;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator tsSepEdit;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator tsSepClose;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.ToolStripButton tsbtnDelete;
		private System.Windows.Forms.ToolStripSeparator tsSepDelete;
		private System.Windows.Forms.ToolStripStatusLabel tslbCount;
	}
}