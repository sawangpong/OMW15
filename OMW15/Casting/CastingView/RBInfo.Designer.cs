namespace OMW15.Casting.CastingView
{
	partial class RBInfo
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
			this.btnClose = new System.Windows.Forms.Button();
			this.grb = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.ntxtBaseWeight = new OMControls.Controls.NumericTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cbxBaseSize = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.chkInActive = new System.Windows.Forms.CheckBox();
			this.txtBaseNo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grb.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 170);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Size = new System.Drawing.Size(404, 43);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(197, 4);
			this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(102, 35);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(299, 4);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(102, 35);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Cancel";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// grb
			// 
			this.grb.Controls.Add(this.panel5);
			this.grb.Controls.Add(this.panel4);
			this.grb.Controls.Add(this.panel3);
			this.grb.Controls.Add(this.panel2);
			this.grb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grb.Location = new System.Drawing.Point(5, 5);
			this.grb.Name = "grb";
			this.grb.Padding = new System.Windows.Forms.Padding(10);
			this.grb.Size = new System.Drawing.Size(404, 165);
			this.grb.TabIndex = 1;
			this.grb.TabStop = false;
			this.grb.Text = "ข้อมูลฐานยาง";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtRemark);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 118);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(384, 30);
			this.panel5.TabIndex = 3;
			// 
			// txtRemark
			// 
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtRemark.Location = new System.Drawing.Point(107, 1);
			this.txtRemark.MaxLength = 150;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(258, 25);
			this.txtRemark.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(106, 28);
			this.label4.TabIndex = 0;
			this.label4.Text = "หมายเตุ :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.ntxtBaseWeight);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 88);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(384, 30);
			this.panel4.TabIndex = 2;
			// 
			// ntxtBaseWeight
			// 
			this.ntxtBaseWeight.Dock = System.Windows.Forms.DockStyle.Left;
			this.ntxtBaseWeight.Location = new System.Drawing.Point(107, 1);
			this.ntxtBaseWeight.MaxLength = 10;
			this.ntxtBaseWeight.Name = "ntxtBaseWeight";
			this.ntxtBaseWeight.Size = new System.Drawing.Size(100, 25);
			this.ntxtBaseWeight.TabIndex = 1;
			this.ntxtBaseWeight.Text = "0.00";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 28);
			this.label3.TabIndex = 0;
			this.label3.Text = "น.น. ฐานยาง :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cbxBaseSize);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 58);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(384, 30);
			this.panel3.TabIndex = 1;
			// 
			// cbxBaseSize
			// 
			this.cbxBaseSize.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxBaseSize.FormattingEnabled = true;
			this.cbxBaseSize.Location = new System.Drawing.Point(107, 1);
			this.cbxBaseSize.Name = "cbxBaseSize";
			this.cbxBaseSize.Size = new System.Drawing.Size(100, 25);
			this.cbxBaseSize.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 28);
			this.label2.TabIndex = 0;
			this.label2.Text = "ขนาดฐานยาง :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.chkInActive);
			this.panel2.Controls.Add(this.txtBaseNo);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(10, 28);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(384, 30);
			this.panel2.TabIndex = 0;
			// 
			// chkInActive
			// 
			this.chkInActive.AutoSize = true;
			this.chkInActive.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkInActive.Location = new System.Drawing.Point(207, 1);
			this.chkInActive.Name = "chkInActive";
			this.chkInActive.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
			this.chkInActive.Size = new System.Drawing.Size(147, 28);
			this.chkInActive.TabIndex = 2;
			this.chkInActive.Text = "ยกเลิกการใช้งาน";
			this.chkInActive.UseVisualStyleBackColor = true;
			// 
			// txtBaseNo
			// 
			this.txtBaseNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtBaseNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtBaseNo.Location = new System.Drawing.Point(107, 1);
			this.txtBaseNo.MaxLength = 10;
			this.txtBaseNo.Name = "txtBaseNo";
			this.txtBaseNo.Size = new System.Drawing.Size(100, 25);
			this.txtBaseNo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "หมายเลขฐานยาง :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RBInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 218);
			this.Controls.Add(this.grb);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "RBInfo";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "RUBBER BASE INFO";
			this.Load += new System.EventHandler(this.RBInfo_Load);
			this.panel1.ResumeLayout(false);
			this.grb.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox grb;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtBaseNo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private OMControls.Controls.NumericTextBox ntxtBaseWeight;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxBaseSize;
		private System.Windows.Forms.CheckBox chkInActive;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label label4;
	}
}