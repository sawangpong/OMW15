namespace OMW15.Views.CastingView
{
	partial class CastingMatList
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
			this.tsSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbxMatCategory = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lbCAT = new System.Windows.Forms.Label();
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
            this.tsbtnClose,
            this.tsSep3,
            this.toolStripLabel1,
            this.tscbxMatCategory,
            this.toolStripSeparator2,
            this.tsbtnRefresh,
            this.toolStripSeparator3,
            this.tsbtnAdd,
            this.tsSep1,
            this.tsbtnEdit,
            this.tsSep2});
			this.ts.Location = new System.Drawing.Point(0, 0);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.ts.Size = new System.Drawing.Size(632, 36);
			this.ts.TabIndex = 0;
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(60, 33);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// tsSep3
			// 
			this.tsSep3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsSep3.Name = "tsSep3";
			this.tsSep3.Size = new System.Drawing.Size(6, 36);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(56, 33);
			this.toolStripLabel1.Text = "กลุ่มวัสดุ :";
			// 
			// tscbxMatCategory
			// 
			this.tscbxMatCategory.AutoSize = false;
			this.tscbxMatCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscbxMatCategory.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
			this.tscbxMatCategory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tscbxMatCategory.Name = "tscbxMatCategory";
			this.tscbxMatCategory.Size = new System.Drawing.Size(140, 25);
			this.tscbxMatCategory.SelectedIndexChanged += new System.EventHandler(this.tscbxMatCategory_SelectedIndexChanged);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnRefresh
			// 
			this.tsbtnRefresh.Image = global::OMW15.Properties.Resources.REFRESH;
			this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnRefresh.Name = "tsbtnRefresh";
			this.tsbtnRefresh.Size = new System.Drawing.Size(72, 33);
			this.tsbtnRefresh.Text = "&Refresh";
			this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.Image = global::OMW15.Properties.Resources.Add;
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(56, 33);
			this.tsbtnAdd.Text = " Add";
			this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
			// 
			// tsSep1
			// 
			this.tsSep1.Name = "tsSep1";
			this.tsSep1.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.Image = global::OMW15.Properties.Resources.Edit;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(50, 33);
			this.tsbtnEdit.Text = "Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// tsSep2
			// 
			this.tsSep2.Name = "tsSep2";
			this.tsSep2.Size = new System.Drawing.Size(6, 36);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dgv);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 36);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(632, 327);
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
			this.dgv.Size = new System.Drawing.Size(628, 283);
			this.dgv.TabIndex = 1;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Controls.Add(this.btnSelect);
			this.panel2.Controls.Add(this.lbCAT);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(2, 285);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Size = new System.Drawing.Size(628, 40);
			this.panel2.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(516, 3);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(110, 34);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(152, 3);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(110, 34);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// lbCAT
			// 
			this.lbCAT.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCAT.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCAT.Location = new System.Drawing.Point(2, 3);
			this.lbCAT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbCAT.Name = "lbCAT";
			this.lbCAT.Size = new System.Drawing.Size(150, 34);
			this.lbCAT.TabIndex = 0;
			this.lbCAT.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// CastingMatList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 363);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.ts);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingMatList";
			this.Text = "CASTING MATERIAL";
			this.Load += new System.EventHandler(this.CastingMatList_Load);
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator tsSep3;
		private System.Windows.Forms.ToolStripButton tsbtnRefresh;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripComboBox tscbxMatCategory;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.Label lbCAT;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripSeparator tsSep1;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripSeparator tsSep2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSelect;
	}
}