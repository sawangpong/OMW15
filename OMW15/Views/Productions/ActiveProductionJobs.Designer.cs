namespace OMW15.Views.Productions
{
	partial class ActiveProductionJobs
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveProductionJobs));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCencel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.btnSearch = new OMControls.OMFlatButton();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbSelectJobId = new System.Windows.Forms.Label();
			this.lbRows = new System.Windows.Forms.Label();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSelect);
			this.panel1.Controls.Add(this.btnCencel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 414);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3);
			this.panel1.Size = new System.Drawing.Size(641, 39);
			this.panel1.TabIndex = 0;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(3, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(109, 33);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnCencel
			// 
			this.btnCencel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCencel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCencel.Location = new System.Drawing.Point(529, 3);
			this.btnCencel.Name = "btnCencel";
			this.btnCencel.Size = new System.Drawing.Size(109, 33);
			this.btnCencel.TabIndex = 0;
			this.btnCencel.Text = "&Cancel";
			this.btnCencel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbTitle);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(641, 95);
			this.panel2.TabIndex = 1;
			// 
			// lbTitle
			// 
			this.lbTitle.BackColor = System.Drawing.Color.Black;
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.Yellow;
			this.lbTitle.Location = new System.Drawing.Point(2, 2);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(637, 51);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "รายจะแสดงเฉพาะงานที่ยังไม่เสร็จแล้วเท่านั้น";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel5);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(2, 53);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(637, 40);
			this.panel3.TabIndex = 0;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.label1);
			this.panel5.Controls.Add(this.txtFilter);
			this.panel5.Controls.Add(this.btnSearch);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(198, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(4);
			this.panel5.Size = new System.Drawing.Size(437, 36);
			this.panel5.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Right;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(42, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(180, 28);
			this.label1.TabIndex = 3;
			this.label1.Text = "ค้นหาหมายเลขใบขอแปร : ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtFilter
			// 
			this.txtFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFilter.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFilter.Location = new System.Drawing.Point(222, 4);
			this.txtFilter.MaxLength = 30;
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(183, 27);
			this.txtFilter.TabIndex = 2;
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
			this.btnSearch.Location = new System.Drawing.Point(405, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(28, 28);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbSelectJobId);
			this.panel4.Controls.Add(this.lbRows);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(2, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(96, 36);
			this.panel4.TabIndex = 4;
			// 
			// lbSelectJobId
			// 
			this.lbSelectJobId.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbSelectJobId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbSelectJobId.ForeColor = System.Drawing.Color.DimGray;
			this.lbSelectJobId.Location = new System.Drawing.Point(0, 0);
			this.lbSelectJobId.Name = "lbSelectJobId";
			this.lbSelectJobId.Size = new System.Drawing.Size(96, 15);
			this.lbSelectJobId.TabIndex = 5;
			this.lbSelectJobId.Text = "id # 0";
			this.lbSelectJobId.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbRows
			// 
			this.lbRows.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbRows.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRows.ForeColor = System.Drawing.Color.DimGray;
			this.lbRows.Location = new System.Drawing.Point(0, 21);
			this.lbRows.Name = "lbRows";
			this.lbRows.Size = new System.Drawing.Size(96, 15);
			this.lbRows.TabIndex = 4;
			this.lbRows.Text = "found # 0";
			this.lbRows.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlDetail
			// 
			this.pnlDetail.Controls.Add(this.dgv);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetail.Location = new System.Drawing.Point(2, 97);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(2);
			this.pnlDetail.Size = new System.Drawing.Size(641, 317);
			this.pnlDetail.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(637, 313);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// ActiveProductionJobs
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(645, 455);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ActiveProductionJobs";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Load += new System.EventHandler(this.ActiveProductionJobs_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCencel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbRows;
		private System.Windows.Forms.Label lbSelectJobId;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFilter;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.Label lbTitle;
	}
}