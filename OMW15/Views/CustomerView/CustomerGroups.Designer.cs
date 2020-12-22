namespace OMW15.Views.CustomerView
{
	partial class CustomerGroups
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerGroups));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.grp = new System.Windows.Forms.GroupBox();
			this.pnlMember = new System.Windows.Forms.Panel();
			this.dgvMember = new System.Windows.Forms.DataGridView();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbMemberName = new System.Windows.Forms.Label();
			this.btnFindMember = new OMControls.OMFlatButton();
			this.lbMemberCode = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbCustName = new System.Windows.Forms.Label();
			this.lbCustCode = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.grp.SuspendLayout();
			this.pnlMember.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(15, 304);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(639, 37);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(459, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(89, 33);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(548, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(89, 33);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.ForeColor = System.Drawing.Color.White;
			this.panel2.Location = new System.Drawing.Point(15, 15);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(639, 32);
			this.panel2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Customer Group Manager";
			// 
			// grp
			// 
			this.grp.Controls.Add(this.pnlMember);
			this.grp.Controls.Add(this.panel3);
			this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grp.Location = new System.Drawing.Point(15, 47);
			this.grp.Name = "grp";
			this.grp.Padding = new System.Windows.Forms.Padding(10);
			this.grp.Size = new System.Drawing.Size(639, 257);
			this.grp.TabIndex = 2;
			this.grp.TabStop = false;
			this.grp.Text = "Group Info";
			// 
			// pnlMember
			// 
			this.pnlMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMember.Controls.Add(this.dgvMember);
			this.pnlMember.Controls.Add(this.panel5);
			this.pnlMember.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMember.Location = new System.Drawing.Point(10, 56);
			this.pnlMember.Name = "pnlMember";
			this.pnlMember.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMember.Size = new System.Drawing.Size(619, 191);
			this.pnlMember.TabIndex = 1;
			// 
			// dgvMember
			// 
			this.dgvMember.BackgroundColor = System.Drawing.Color.White;
			this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMember.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvMember.Location = new System.Drawing.Point(2, 32);
			this.dgvMember.Name = "dgvMember";
			this.dgvMember.Size = new System.Drawing.Size(613, 155);
			this.dgvMember.TabIndex = 1;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.lbMemberName);
			this.panel5.Controls.Add(this.btnFindMember);
			this.panel5.Controls.Add(this.lbMemberCode);
			this.panel5.Controls.Add(this.btnAdd);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(613, 30);
			this.panel5.TabIndex = 0;
			// 
			// lbMemberName
			// 
			this.lbMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMemberName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbMemberName.Location = new System.Drawing.Point(185, 2);
			this.lbMemberName.Name = "lbMemberName";
			this.lbMemberName.Size = new System.Drawing.Size(400, 26);
			this.lbMemberName.TabIndex = 7;
			this.lbMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnFindMember
			// 
			this.btnFindMember.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnFindMember.FlatAppearance.BorderSize = 0;
			this.btnFindMember.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnFindMember.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnFindMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFindMember.Image = ((System.Drawing.Image)(resources.GetObject("btnFindMember.Image")));
			this.btnFindMember.Location = new System.Drawing.Point(585, 2);
			this.btnFindMember.Name = "btnFindMember";
			this.btnFindMember.Size = new System.Drawing.Size(26, 26);
			this.btnFindMember.TabIndex = 6;
			this.btnFindMember.UseVisualStyleBackColor = true;
			this.btnFindMember.Click += new System.EventHandler(this.btnFindMember_Click);
			// 
			// lbMemberCode
			// 
			this.lbMemberCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMemberCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMemberCode.Location = new System.Drawing.Point(106, 2);
			this.lbMemberCode.Name = "lbMemberCode";
			this.lbMemberCode.Size = new System.Drawing.Size(79, 26);
			this.lbMemberCode.TabIndex = 5;
			this.lbMemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAdd
			// 
			this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnAdd.Location = new System.Drawing.Point(2, 2);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(104, 26);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "เพิ่มรายชื่อ";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbCustName);
			this.panel3.Controls.Add(this.lbCustCode);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 28);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(619, 28);
			this.panel3.TabIndex = 0;
			// 
			// lbCustName
			// 
			this.lbCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCustName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCustName.Location = new System.Drawing.Point(188, 1);
			this.lbCustName.Name = "lbCustName";
			this.lbCustName.Size = new System.Drawing.Size(430, 26);
			this.lbCustName.TabIndex = 4;
			this.lbCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCustCode
			// 
			this.lbCustCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCustCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCustCode.Location = new System.Drawing.Point(109, 1);
			this.lbCustCode.Name = "lbCustCode";
			this.lbCustCode.Size = new System.Drawing.Size(79, 26);
			this.lbCustCode.TabIndex = 1;
			this.lbCustCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "ลูกค้าผู้นำกลุ่ม :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// CustomerGroups
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(669, 356);
			this.Controls.Add(this.grp);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CustomerGroups";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Text = "CUSTOMER GROUPS";
			this.Load += new System.EventHandler(this.CustomerGroups_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.grp.ResumeLayout(false);
			this.pnlMember.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.GroupBox grp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label lbCustName;
		private System.Windows.Forms.Label lbCustCode;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlMember;
		private System.Windows.Forms.DataGridView dgvMember;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lbMemberName;
		private OMControls.OMFlatButton btnFindMember;
		private System.Windows.Forms.Label lbMemberCode;
	}
}