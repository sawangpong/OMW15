namespace OMW15.Views.CustomerView
{
	partial class CustomerGroupList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerGroupList));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlMaster = new System.Windows.Forms.Panel();
			this.dgvMaster = new System.Windows.Forms.DataGridView();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnAddGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEditGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnDeleteGroup = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbMasterCount = new System.Windows.Forms.Label();
			this.btnFindMasterCustomer = new OMControls.OMFlatButton();
			this.label2 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlMember = new System.Windows.Forms.Panel();
			this.dgvMember = new System.Windows.Forms.DataGridView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnDeleteMember = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefreshMember = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbMemberCount = new System.Windows.Forms.Label();
			this.lbMemberTitle = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.pnlMaster.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).BeginInit();
			this.ts.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnlMember.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(802, 36);
			this.panel1.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(192, 36);
			this.panel3.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(162, 30);
			this.label1.TabIndex = 0;
			this.label1.Text = "กลุ่มลูกค้า";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
			this.pictureBox1.Image = global::OMW15.Properties.Resources.People;
			this.pictureBox1.Location = new System.Drawing.Point(762, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Padding = new System.Windows.Forms.Padding(3);
			this.pictureBox1.Size = new System.Drawing.Size(40, 36);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.pnlMaster);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.pnlMember);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 36);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(802, 404);
			this.panel2.TabIndex = 1;
			// 
			// pnlMaster
			// 
			this.pnlMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMaster.Controls.Add(this.dgvMaster);
			this.pnlMaster.Controls.Add(this.ts);
			this.pnlMaster.Controls.Add(this.panel5);
			this.pnlMaster.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMaster.Location = new System.Drawing.Point(5, 5);
			this.pnlMaster.Name = "pnlMaster";
			this.pnlMaster.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMaster.Size = new System.Drawing.Size(452, 370);
			this.pnlMaster.TabIndex = 6;
			// 
			// dgvMaster
			// 
			this.dgvMaster.BackgroundColor = System.Drawing.Color.White;
			this.dgvMaster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMaster.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMaster.Location = new System.Drawing.Point(2, 74);
			this.dgvMaster.Name = "dgvMaster";
			this.dgvMaster.Size = new System.Drawing.Size(446, 292);
			this.dgvMaster.TabIndex = 14;
			this.dgvMaster.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaster_CellEnter);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAddGroup,
            this.toolStripSeparator1,
            this.tsbtnEditGroup,
            this.toolStripSeparator3,
            this.tsbtnDeleteGroup,
            this.toolStripSeparator4,
            this.tsbtnRefresh,
            this.toolStripSeparator5});
			this.ts.Location = new System.Drawing.Point(2, 41);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(446, 33);
			this.ts.TabIndex = 13;
			// 
			// tsbtnAddGroup
			// 
			this.tsbtnAddGroup.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAddGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddGroup.Name = "tsbtnAddGroup";
			this.tsbtnAddGroup.Size = new System.Drawing.Size(47, 30);
			this.tsbtnAddGroup.Text = "เพิ่ม";
			this.tsbtnAddGroup.Click += new System.EventHandler(this.tsbtnAddGroup_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
			// 
			// tsbtnEditGroup
			// 
			this.tsbtnEditGroup.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEditGroup.Name = "tsbtnEditGroup";
			this.tsbtnEditGroup.Size = new System.Drawing.Size(54, 30);
			this.tsbtnEditGroup.Text = "แก้ไข";
			this.tsbtnEditGroup.Click += new System.EventHandler(this.tsbtnEditGroup_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
			// 
			// tsbtnDeleteGroup
			// 
			this.tsbtnDeleteGroup.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteGroup.Name = "tsbtnDeleteGroup";
			this.tsbtnDeleteGroup.Size = new System.Drawing.Size(63, 30);
			this.tsbtnDeleteGroup.Text = "ลบกลุ่ม";
			this.tsbtnDeleteGroup.Click += new System.EventHandler(this.tsbtnDeleteGroup_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(72, 30);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lbMasterCount);
			this.panel5.Controls.Add(this.btnFindMasterCustomer);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(446, 39);
			this.panel5.TabIndex = 11;
			// 
			// lbMasterCount
			// 
			this.lbMasterCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMasterCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMasterCount.Location = new System.Drawing.Point(317, 2);
			this.lbMasterCount.Name = "lbMasterCount";
			this.lbMasterCount.Size = new System.Drawing.Size(127, 35);
			this.lbMasterCount.TabIndex = 12;
			this.lbMasterCount.Text = "found : 0";
			this.lbMasterCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnFindMasterCustomer
			// 
			this.btnFindMasterCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFindMasterCustomer.FlatAppearance.BorderSize = 0;
			this.btnFindMasterCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnFindMasterCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnFindMasterCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFindMasterCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnFindMasterCustomer.Image")));
			this.btnFindMasterCustomer.Location = new System.Drawing.Point(83, 2);
			this.btnFindMasterCustomer.Name = "btnFindMasterCustomer";
			this.btnFindMasterCustomer.Size = new System.Drawing.Size(35, 35);
			this.btnFindMasterCustomer.TabIndex = 11;
			this.btnFindMasterCustomer.UseVisualStyleBackColor = true;
			this.btnFindMasterCustomer.Click += new System.EventHandler(this.btnFindMasterCustomer_Click);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 35);
			this.label2.TabIndex = 10;
			this.label2.Text = "Master";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(457, 5);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 370);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// pnlMember
			// 
			this.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMember.Controls.Add(this.dgvMember);
			this.pnlMember.Controls.Add(this.toolStrip1);
			this.pnlMember.Controls.Add(this.panel6);
			this.pnlMember.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlMember.Location = new System.Drawing.Point(463, 5);
			this.pnlMember.Name = "pnlMember";
			this.pnlMember.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMember.Size = new System.Drawing.Size(332, 370);
			this.pnlMember.TabIndex = 4;
			// 
			// dgvMember
			// 
			this.dgvMember.BackgroundColor = System.Drawing.Color.White;
			this.dgvMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMember.Location = new System.Drawing.Point(2, 74);
			this.dgvMember.Name = "dgvMember";
			this.dgvMember.Size = new System.Drawing.Size(326, 292);
			this.dgvMember.TabIndex = 15;
			this.dgvMember.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellEnter);
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnDeleteMember,
            this.toolStripSeparator7,
            this.tsbtnRefreshMember,
            this.toolStripSeparator8});
			this.toolStrip1.Location = new System.Drawing.Point(2, 41);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.toolStrip1.Size = new System.Drawing.Size(326, 33);
			this.toolStrip1.TabIndex = 14;
			// 
			// tsbtnDeleteMember
			// 
			this.tsbtnDeleteMember.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.tsbtnDeleteMember.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteMember.Name = "tsbtnDeleteMember";
			this.tsbtnDeleteMember.Size = new System.Drawing.Size(77, 30);
			this.tsbtnDeleteMember.Text = "ลบสมาชิก";
			this.tsbtnDeleteMember.Click += new System.EventHandler(this.tsbtnDeleteMember_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
			// 
			// tsbtnRefreshMember
			// 
			this.tsbtnRefreshMember.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefreshMember.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefreshMember.Name = "tsbtnRefreshMember";
			this.tsbtnRefreshMember.Size = new System.Drawing.Size(72, 30);
			this.tsbtnRefreshMember.Text = "&Refresh";
			this.tsbtnRefreshMember.Click += new System.EventHandler(this.tsbtnRefreshMember_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 33);
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbMemberCount);
			this.panel6.Controls.Add(this.lbMemberTitle);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(326, 39);
			this.panel6.TabIndex = 12;
			// 
			// lbMemberCount
			// 
			this.lbMemberCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMemberCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMemberCount.Location = new System.Drawing.Point(197, 2);
			this.lbMemberCount.Name = "lbMemberCount";
			this.lbMemberCount.Size = new System.Drawing.Size(127, 35);
			this.lbMemberCount.TabIndex = 13;
			this.lbMemberCount.Text = "found : 0";
			this.lbMemberCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbMemberTitle
			// 
			this.lbMemberTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMemberTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMemberTitle.Location = new System.Drawing.Point(2, 2);
			this.lbMemberTitle.Name = "lbMemberTitle";
			this.lbMemberTitle.Size = new System.Drawing.Size(88, 35);
			this.lbMemberTitle.TabIndex = 9;
			this.lbMemberTitle.Text = "Member";
			this.lbMemberTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel4.Location = new System.Drawing.Point(5, 375);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(790, 22);
			this.panel4.TabIndex = 2;
			// 
			// CustomerGroupList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(802, 440);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CustomerGroupList";
			this.Text = "CUSTOMER GROUP LIST";
			this.Load += new System.EventHandler(this.CustomerGroupList_Load);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.pnlMaster.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMaster)).EndInit();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.pnlMember.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel pnlMaster;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlMember;
		private System.Windows.Forms.Panel panel5;
		private OMControls.OMFlatButton btnFindMasterCustomer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbMasterCount;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lbMemberCount;
		private System.Windows.Forms.Label lbMemberTitle;
		private System.Windows.Forms.DataGridView dgvMaster;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnAddGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEditGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteGroup;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.DataGridView dgvMember;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteMember;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton tsbtnRefreshMember;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
	}
}