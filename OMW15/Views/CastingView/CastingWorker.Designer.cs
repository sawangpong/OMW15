namespace OMW15.Views.CastingView
{
	partial class CastingWorker
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.chkShowAllWorker = new System.Windows.Forms.CheckBox();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlTop.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.label1);
			this.pnlTop.Controls.Add(this.panel1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(2, 2);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(359, 68);
			this.pnlTop.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 38);
			this.label1.TabIndex = 1;
			this.label1.Text = "รายชื่อพนักงาน";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.chkShowAllWorker);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(2, 40);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(355, 26);
			this.panel1.TabIndex = 0;
			// 
			// chkShowAllWorker
			// 
			this.chkShowAllWorker.Checked = true;
			this.chkShowAllWorker.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowAllWorker.Dock = System.Windows.Forms.DockStyle.Right;
			this.chkShowAllWorker.Location = new System.Drawing.Point(215, 0);
			this.chkShowAllWorker.Name = "chkShowAllWorker";
			this.chkShowAllWorker.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.chkShowAllWorker.Size = new System.Drawing.Size(140, 26);
			this.chkShowAllWorker.TabIndex = 0;
			this.chkShowAllWorker.Text = "แสดงรายชื่อทั้งหมด";
			this.chkShowAllWorker.UseVisualStyleBackColor = true;
			this.chkShowAllWorker.CheckedChanged += new System.EventHandler(this.chkShowAllWorker_CheckedChanged);
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.btnCancel);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(2, 298);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(4);
			this.pnlCommand.Size = new System.Drawing.Size(359, 43);
			this.pnlCommand.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(217, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(138, 35);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "ยกเลิก";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(4, 4);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(138, 35);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "เลือก";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 70);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(359, 228);
			this.dgv.TabIndex = 2;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// CastingWorker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(363, 343);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingWorker";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.Text = "พนักงาน";
			this.Load += new System.EventHandler(this.CastingWorker_Load);
			this.pnlTop.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlCommand.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox chkShowAllWorker;
		private System.Windows.Forms.Label label1;
	}
}