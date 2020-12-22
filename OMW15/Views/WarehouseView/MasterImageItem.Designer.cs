namespace OMW15.Views.WarehouseView
{
	partial class MasterImageItem
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.pic = new System.Windows.Forms.PictureBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtItemNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnLoadImage = new System.Windows.Forms.Button();
			this.btnClearImage = new System.Windows.Forms.Button();
			this.lbRefId = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 203);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.panel1.Size = new System.Drawing.Size(607, 50);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(347, 7);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(127, 36);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(474, 7);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(127, 36);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "C&ancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.pic);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(6, 7);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
			this.panel2.Size = new System.Drawing.Size(165, 196);
			this.panel2.TabIndex = 1;
			// 
			// pic
			// 
			this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pic.Dock = System.Windows.Forms.DockStyle.Top;
			this.pic.Location = new System.Drawing.Point(12, 13);
			this.pic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pic.Name = "pic";
			this.pic.Size = new System.Drawing.Size(141, 170);
			this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pic.TabIndex = 0;
			this.pic.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lbRefId);
			this.panel3.Controls.Add(this.lbMode);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(171, 7);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(442, 38);
			this.panel3.TabIndex = 2;
			// 
			// lbMode
			// 
			this.lbMode.BackColor = System.Drawing.Color.Red;
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(346, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(94, 34);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtItemNo);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(171, 45);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(442, 28);
			this.panel4.TabIndex = 3;
			// 
			// txtItemNo
			// 
			this.txtItemNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemNo.Location = new System.Drawing.Point(95, 1);
			this.txtItemNo.MaxLength = 20;
			this.txtItemNo.Name = "txtItemNo";
			this.txtItemNo.ReadOnly = true;
			this.txtItemNo.Size = new System.Drawing.Size(165, 25);
			this.txtItemNo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Item-No. :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtItemName);
			this.panel5.Controls.Add(this.label2);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(171, 73);
			this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(442, 28);
			this.panel5.TabIndex = 4;
			// 
			// txtItemName
			// 
			this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemName.Location = new System.Drawing.Point(95, 1);
			this.txtItemName.MaxLength = 50;
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.ReadOnly = true;
			this.txtItemName.Size = new System.Drawing.Size(323, 25);
			this.txtItemName.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(94, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Description :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(171, 101);
			this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(442, 28);
			this.panel6.TabIndex = 5;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.btnLoadImage);
			this.panel7.Controls.Add(this.btnClearImage);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(171, 129);
			this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(5);
			this.panel7.Size = new System.Drawing.Size(442, 41);
			this.panel7.TabIndex = 6;
			// 
			// btnLoadImage
			// 
			this.btnLoadImage.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnLoadImage.Location = new System.Drawing.Point(310, 5);
			this.btnLoadImage.Name = "btnLoadImage";
			this.btnLoadImage.Size = new System.Drawing.Size(127, 31);
			this.btnLoadImage.TabIndex = 1;
			this.btnLoadImage.Text = "&Load Picture";
			this.btnLoadImage.UseVisualStyleBackColor = true;
			this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
			// 
			// btnClearImage
			// 
			this.btnClearImage.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnClearImage.Location = new System.Drawing.Point(5, 5);
			this.btnClearImage.Name = "btnClearImage";
			this.btnClearImage.Size = new System.Drawing.Size(104, 31);
			this.btnClearImage.TabIndex = 0;
			this.btnClearImage.Text = "&Clear";
			this.btnClearImage.UseVisualStyleBackColor = true;
			this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
			// 
			// lbRefId
			// 
			this.lbRefId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbRefId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRefId.Location = new System.Drawing.Point(2, 2);
			this.lbRefId.Name = "lbRefId";
			this.lbRefId.Size = new System.Drawing.Size(93, 34);
			this.lbRefId.TabIndex = 2;
			this.lbRefId.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// MasterImageItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(619, 260);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MasterImageItem";
			this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
			this.Text = "STOCK MASTER IMAGE UPDATER ";
			this.Load += new System.EventHandler(this.MasterImageItem_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtItemNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtItemName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button btnLoadImage;
		private System.Windows.Forms.Button btnClearImage;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Label lbRefId;
	}
}