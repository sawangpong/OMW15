namespace OMW15.Views.Productions
{
	partial class ProductionMachineGroup
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pnlMCMemberCommand = new System.Windows.Forms.Panel();
			this.btnDeleteMember = new System.Windows.Forms.Button();
			this.btnEditMember = new System.Windows.Forms.Button();
			this.btnAddMember = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgvMember = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlMCMemberCommand.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(556, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(220, 50);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "กลุ่มเครื่องจักร";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// panel3
			// 
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 371);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(556, 26);
			this.panel3.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pnlMCMemberCommand);
			this.panel2.Controls.Add(this.btnRefresh);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.btnDelete);
			this.panel2.Controls.Add(this.btnEdit);
			this.panel2.Controls.Add(this.btnAdd);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(403, 50);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(153, 321);
			this.panel2.TabIndex = 4;
			// 
			// pnlMCMemberCommand
			// 
			this.pnlMCMemberCommand.Controls.Add(this.btnDeleteMember);
			this.pnlMCMemberCommand.Controls.Add(this.btnEditMember);
			this.pnlMCMemberCommand.Controls.Add(this.btnAddMember);
			this.pnlMCMemberCommand.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMCMemberCommand.Location = new System.Drawing.Point(10, 140);
			this.pnlMCMemberCommand.Name = "pnlMCMemberCommand";
			this.pnlMCMemberCommand.Padding = new System.Windows.Forms.Padding(0, 20, 0, 5);
			this.pnlMCMemberCommand.Size = new System.Drawing.Size(133, 141);
			this.pnlMCMemberCommand.TabIndex = 7;
			// 
			// btnDeleteMember
			// 
			this.btnDeleteMember.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnDeleteMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDeleteMember.Location = new System.Drawing.Point(0, 80);
			this.btnDeleteMember.Name = "btnDeleteMember";
			this.btnDeleteMember.Size = new System.Drawing.Size(133, 30);
			this.btnDeleteMember.TabIndex = 2;
			this.btnDeleteMember.Text = "Delete Member";
			this.btnDeleteMember.UseVisualStyleBackColor = true;
			this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click);
			// 
			// btnEditMember
			// 
			this.btnEditMember.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnEditMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEditMember.Location = new System.Drawing.Point(0, 50);
			this.btnEditMember.Name = "btnEditMember";
			this.btnEditMember.Size = new System.Drawing.Size(133, 30);
			this.btnEditMember.TabIndex = 1;
			this.btnEditMember.Text = "Edit Member";
			this.btnEditMember.UseVisualStyleBackColor = true;
			this.btnEditMember.Click += new System.EventHandler(this.btnEditMember_Click);
			// 
			// btnAddMember
			// 
			this.btnAddMember.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAddMember.Location = new System.Drawing.Point(0, 20);
			this.btnAddMember.Name = "btnAddMember";
			this.btnAddMember.Size = new System.Drawing.Size(133, 30);
			this.btnAddMember.TabIndex = 0;
			this.btnAddMember.Text = "Add Member";
			this.btnAddMember.UseVisualStyleBackColor = true;
			this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRefresh.Location = new System.Drawing.Point(10, 110);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(133, 30);
			this.btnRefresh.TabIndex = 6;
			this.btnRefresh.Text = "&Refresh";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(10, 100);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 10);
			this.label1.TabIndex = 5;
			// 
			// btnDelete
			// 
			this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnDelete.Image = global::OMW15.Properties.Resources.DeleteHS;
			this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDelete.Location = new System.Drawing.Point(10, 70);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(133, 30);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "&Delete Group";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(10, 40);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(133, 30);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "&Edit Group";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(10, 10);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(133, 30);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "&Add Group";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(10, 281);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(133, 30);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgvMember);
			this.panel4.Controls.Add(this.splitter1);
			this.panel4.Controls.Add(this.dgv);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 50);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(3);
			this.panel4.Size = new System.Drawing.Size(403, 321);
			this.panel4.TabIndex = 6;
			// 
			// dgvMember
			// 
			this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMember.Location = new System.Drawing.Point(3, 146);
			this.dgvMember.Name = "dgvMember";
			this.dgvMember.Size = new System.Drawing.Size(397, 172);
			this.dgvMember.TabIndex = 0;
			this.dgvMember.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMember_CellEnter);
			this.dgvMember.DoubleClick += new System.EventHandler(this.dgvMember_DoubleClick);
			this.dgvMember.Enter += new System.EventHandler(this.dgvMember_Enter);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(3, 140);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(397, 6);
			this.splitter1.TabIndex = 7;
			this.splitter1.TabStop = false;
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgv.Location = new System.Drawing.Point(3, 3);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(397, 137);
			this.dgv.TabIndex = 6;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			this.dgv.Enter += new System.EventHandler(this.dgv_Enter);
			// 
			// ProductionMachineGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 397);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProductionMachineGroup";
			this.Text = "Production Machine Group";
			this.Load += new System.EventHandler(this.ProductionMachineGroup_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.pnlMCMemberCommand.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlMCMemberCommand;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnDeleteMember;
		private System.Windows.Forms.Button btnEditMember;
		private System.Windows.Forms.Button btnAddMember;
		private System.Windows.Forms.DataGridView dgvMember;
	}
}