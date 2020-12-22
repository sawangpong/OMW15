namespace OMW15.Views.CastingView
{
	partial class CastingJobOrderSearch
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
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbRowCount = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnJobInfo = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnShowData = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.rdoByCustomerName = new System.Windows.Forms.RadioButton();
			this.rdoByJobNo = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(875, 42);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "ค้นหาใบงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbRowCount);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 344);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(875, 31);
			this.panel2.TabIndex = 1;
			// 
			// lbRowCount
			// 
			this.lbRowCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRowCount.Location = new System.Drawing.Point(1, 1);
			this.lbRowCount.Name = "lbRowCount";
			this.lbRowCount.Size = new System.Drawing.Size(159, 29);
			this.lbRowCount.TabIndex = 0;
			this.lbRowCount.Text = "Row found : 0 ";
			this.lbRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.btnJobInfo);
			this.panel3.Controls.Add(this.btnEdit);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.btnShowData);
			this.panel3.Controls.Add(this.btnClose);
			this.panel3.Controls.Add(this.rdoByCustomerName);
			this.panel3.Controls.Add(this.rdoByJobNo);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 42);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3);
			this.panel3.Size = new System.Drawing.Size(875, 41);
			this.panel3.TabIndex = 2;
			// 
			// btnJobInfo
			// 
			this.btnJobInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnJobInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnJobInfo.Image = global::OMW15.Properties.Resources.CommentHS;
			this.btnJobInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnJobInfo.Location = new System.Drawing.Point(526, 3);
			this.btnJobInfo.Name = "btnJobInfo";
			this.btnJobInfo.Size = new System.Drawing.Size(117, 33);
			this.btnJobInfo.TabIndex = 9;
			this.btnJobInfo.Text = "&Job Info...";
			this.btnJobInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnJobInfo.UseVisualStyleBackColor = true;
			this.btnJobInfo.Click += new System.EventHandler(this.btnJobInfo_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEdit.Location = new System.Drawing.Point(425, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(101, 33);
			this.btnEdit.TabIndex = 8;
			this.btnEdit.Text = "&Edit";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(406, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 33);
			this.label3.TabIndex = 6;
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnShowData
			// 
			this.btnShowData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnShowData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnShowData.Image = global::OMW15.Properties.Resources.ZoomHS;
			this.btnShowData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnShowData.Location = new System.Drawing.Point(310, 3);
			this.btnShowData.Name = "btnShowData";
			this.btnShowData.Size = new System.Drawing.Size(96, 33);
			this.btnShowData.TabIndex = 4;
			this.btnShowData.Text = "ค้นหา";
			this.btnShowData.UseVisualStyleBackColor = true;
			this.btnShowData.Click += new System.EventHandler(this.btnShowData_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(768, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(102, 33);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// rdoByCustomerName
			// 
			this.rdoByCustomerName.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoByCustomerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoByCustomerName.Location = new System.Drawing.Point(204, 3);
			this.rdoByCustomerName.Name = "rdoByCustomerName";
			this.rdoByCustomerName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rdoByCustomerName.Size = new System.Drawing.Size(106, 33);
			this.rdoByCustomerName.TabIndex = 2;
			this.rdoByCustomerName.TabStop = true;
			this.rdoByCustomerName.Tag = "CUSTOMER";
			this.rdoByCustomerName.Text = "ชื่อลูกค้า";
			this.rdoByCustomerName.UseVisualStyleBackColor = true;
			this.rdoByCustomerName.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoByJobNo
			// 
			this.rdoByJobNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoByJobNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoByJobNo.Location = new System.Drawing.Point(85, 3);
			this.rdoByJobNo.Name = "rdoByJobNo";
			this.rdoByJobNo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.rdoByJobNo.Size = new System.Drawing.Size(119, 33);
			this.rdoByJobNo.TabIndex = 1;
			this.rdoByJobNo.TabStop = true;
			this.rdoByJobNo.Tag = "JOBNO";
			this.rdoByJobNo.Text = "เลขที่ใบงาน";
			this.rdoByJobNo.UseVisualStyleBackColor = true;
			this.rdoByJobNo.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(3, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 33);
			this.label2.TabIndex = 0;
			this.label2.Text = "ค้นหาโดย :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dgv);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(0, 83);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(4);
			this.panel4.Size = new System.Drawing.Size(875, 261);
			this.panel4.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(867, 253);
			this.dgv.TabIndex = 0;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// CastingJobOrderSearch
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(875, 375);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingJobOrderSearch";
			this.Text = "ค้นหาใบงาน";
			this.Load += new System.EventHandler(this.CastingJobOrderSearch_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton rdoByCustomerName;
		private System.Windows.Forms.RadioButton rdoByJobNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Button btnShowData;
		private System.Windows.Forms.Label lbRowCount;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnJobInfo;
		private System.Windows.Forms.Button btnEdit;
	}
}