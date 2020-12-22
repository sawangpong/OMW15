namespace OMW15.Views.Productions
{
	partial class STDParts
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
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsSepAdd = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.tsSepEdit = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnLock = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.st = new System.Windows.Forms.StatusStrip();
			this.tslbRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.sblbItemID = new System.Windows.Forms.ToolStripStatusLabel();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlL = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlR = new System.Windows.Forms.Panel();
			this.pic1 = new System.Windows.Forms.PictureBox();
			this.tsTitle = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ts.SuspendLayout();
			this.st.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.pnlL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlR.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic1)).BeginInit();
			this.SuspendLayout();
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTitle,
            this.toolStripSeparator2,
            this.tsbtnClose,
            this.toolStripSeparator1,
            this.tsbtnAdd,
            this.tsSepAdd,
            this.tsbtnEdit,
            this.tsSepEdit,
            this.tsbtnLock,
            this.toolStripSeparator4,
            this.tsbtnRefresh,
            this.toolStripSeparator5,
            this.tsbtnSearch,
            this.toolStripSeparator6});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(1042, 52);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.AutoSize = false;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 39);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.AutoSize = false;
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(60, 39);
			this.tsbtnAdd.Tag = "ADD";
			this.tsbtnAdd.Text = "&Add";
			this.tsbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// tsSepAdd
			// 
			this.tsSepAdd.Name = "tsSepAdd";
			this.tsSepAdd.Size = new System.Drawing.Size(6, 55);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(60, 39);
			this.tsbtnEdit.Tag = "EDIT";
			this.tsbtnEdit.Text = "&Edit";
			this.tsbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// tsSepEdit
			// 
			this.tsSepEdit.Name = "tsSepEdit";
			this.tsSepEdit.Size = new System.Drawing.Size(6, 55);
			// 
			// tsbtnLock
			// 
			this.tsbtnLock.AutoSize = false;
			this.tsbtnLock.Image = global::OMW15.Properties.Resources.LockSmall;
			this.tsbtnLock.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnLock.Name = "tsbtnLock";
			this.tsbtnLock.Size = new System.Drawing.Size(60, 39);
			this.tsbtnLock.Tag = "LOCK";
			this.tsbtnLock.Text = "&Lock";
			this.tsbtnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnLock.Click += new System.EventHandler(this.tsbtnLock_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.AutoSize = false;
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(60, 39);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
			// 
			// tsbtnSearch
			// 
			this.tsbtnSearch.AutoSize = false;
			this.tsbtnSearch.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSearch.Name = "tsbtnSearch";
			this.tsbtnSearch.Size = new System.Drawing.Size(60, 39);
			this.tsbtnSearch.Text = "&Search";
			this.tsbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
			// 
			// st
			// 
			this.st.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.st.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbRecordCount,
            this.sblbItemID});
			this.st.Location = new System.Drawing.Point(0, 556);
			this.st.Name = "st";
			this.st.Size = new System.Drawing.Size(1042, 22);
			this.st.TabIndex = 2;
			this.st.Text = "statusStrip1";
			// 
			// tslbRecordCount
			// 
			this.tslbRecordCount.ForeColor = System.Drawing.Color.DimGray;
			this.tslbRecordCount.Name = "tslbRecordCount";
			this.tslbRecordCount.Size = new System.Drawing.Size(54, 17);
			this.tslbRecordCount.Text = "found : 0";
			// 
			// sblbItemID
			// 
			this.sblbItemID.ForeColor = System.Drawing.Color.DimGray;
			this.sblbItemID.Name = "sblbItemID";
			this.sblbItemID.Size = new System.Drawing.Size(32, 17);
			this.sblbItemID.Text = "Id : 0";
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnCancel);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(0, 512);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(7);
			this.pnlCommand.Size = new System.Drawing.Size(1042, 44);
			this.pnlCommand.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(933, 7);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(102, 30);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(7, 7);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(102, 30);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlL);
			this.pnlBody.Controls.Add(this.pnlR);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 52);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(3);
			this.pnlBody.Size = new System.Drawing.Size(1042, 460);
			this.pnlBody.TabIndex = 5;
			// 
			// pnlL
			// 
			this.pnlL.Controls.Add(this.dgv);
			this.pnlL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlL.Location = new System.Drawing.Point(3, 3);
			this.pnlL.Name = "pnlL";
			this.pnlL.Padding = new System.Windows.Forms.Padding(4);
			this.pnlL.Size = new System.Drawing.Size(883, 454);
			this.pnlL.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(875, 446);
			this.dgv.TabIndex = 1;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlR
			// 
			this.pnlR.Controls.Add(this.pic1);
			this.pnlR.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlR.Location = new System.Drawing.Point(886, 3);
			this.pnlR.Name = "pnlR";
			this.pnlR.Padding = new System.Windows.Forms.Padding(4);
			this.pnlR.Size = new System.Drawing.Size(153, 454);
			this.pnlR.TabIndex = 1;
			// 
			// pic1
			// 
			this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic1.Location = new System.Drawing.Point(4, 4);
			this.pic1.Name = "pic1";
			this.pic1.Size = new System.Drawing.Size(145, 175);
			this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic1.TabIndex = 0;
			this.pic1.TabStop = false;
			// 
			// tsTitle
			// 
			this.tsTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsTitle.ForeColor = System.Drawing.Color.Blue;
			this.tsTitle.Name = "tsTitle";
			this.tsTitle.Size = new System.Drawing.Size(207, 52);
			this.tsTitle.Text = "รายการชิ้นส่วนมาตรฐาน";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
			// 
			// STDParts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1042, 578);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.st);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "STDParts";
			this.Text = "STANDARD PART";
			this.Load += new System.EventHandler(this.STDParts_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.st.ResumeLayout(false);
			this.st.PerformLayout();
			this.pnlCommand.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			this.pnlL.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlR.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.StatusStrip st;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator tsSepAdd;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator tsSepEdit;
		private System.Windows.Forms.ToolStripButton tsbtnLock;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripStatusLabel sblbItemID;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel pnlL;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlR;
		private System.Windows.Forms.PictureBox pic1;
		private System.Windows.Forms.ToolStripButton tsbtnSearch;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripStatusLabel tslbRecordCount;
		private System.Windows.Forms.ToolStripLabel tsTitle;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}