namespace OMW15.Views.ServiceView
{
	partial class PMMatching
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
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.lbMatchFound = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.lbOrderId = new System.Windows.Forms.Label();
			this.pnlHeader.SuspendLayout();
			this.pnlCommand.SuspendLayout();
			this.pnlBody.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.pnlHeader.Controls.Add(this.lbTitle);
			this.pnlHeader.Controls.Add(this.lbMatchFound);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(726, 42);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.lbOrderId);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Controls.Add(this.btnCancel);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(0, 281);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(4);
			this.pnlCommand.Size = new System.Drawing.Size(726, 44);
			this.pnlCommand.TabIndex = 1;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSelect.Location = new System.Drawing.Point(4, 4);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(118, 36);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(604, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(118, 36);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.dgv);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 42);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(4);
			this.pnlBody.Size = new System.Drawing.Size(726, 239);
			this.pnlBody.TabIndex = 2;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(4, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(718, 231);
			this.dgv.TabIndex = 0;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// lbMatchFound
			// 
			this.lbMatchFound.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMatchFound.ForeColor = System.Drawing.Color.Yellow;
			this.lbMatchFound.Location = new System.Drawing.Point(583, 0);
			this.lbMatchFound.Name = "lbMatchFound";
			this.lbMatchFound.Size = new System.Drawing.Size(143, 42);
			this.lbMatchFound.TabIndex = 0;
			this.lbMatchFound.Text = "matched : 0";
			this.lbMatchFound.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(467, 42);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "Customer :";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lbOrderId
			// 
			this.lbOrderId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbOrderId.ForeColor = System.Drawing.Color.Black;
			this.lbOrderId.Location = new System.Drawing.Point(122, 4);
			this.lbOrderId.Name = "lbOrderId";
			this.lbOrderId.Size = new System.Drawing.Size(113, 36);
			this.lbOrderId.TabIndex = 2;
			this.lbOrderId.Text = "idx : 0";
			this.lbOrderId.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// PMMatching
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(726, 325);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlCommand);
			this.Controls.Add(this.pnlHeader);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PMMatching";
			this.Text = "PM Job Matching";
			this.Load += new System.EventHandler(this.PMMatching_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlCommand.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Label lbMatchFound;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbOrderId;
	}
}