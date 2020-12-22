namespace OMW15.Views.Productions
{
	partial class ProductionProcessInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionProcessInfo));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtProcessName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnMachine = new OMControls.OMFlatButton();
			this.txtMachine = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtScore = new OMControls.Controls.NumericTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 176);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(517, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(304, 5);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(104, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(408, 5);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.lbMode);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(5, 5);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
			this.pnlHeader.Size = new System.Drawing.Size(517, 31);
			this.pnlHeader.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.White;
			this.lbMode.Location = new System.Drawing.Point(2, 2);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(82, 27);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(5, 36);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(517, 22);
			this.panel5.TabIndex = 4;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtProcessName);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 58);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(517, 28);
			this.panel3.TabIndex = 5;
			// 
			// txtProcessName
			// 
			this.txtProcessName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProcessName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtProcessName.Location = new System.Drawing.Point(109, 1);
			this.txtProcessName.MaxLength = 50;
			this.txtProcessName.Name = "txtProcessName";
			this.txtProcessName.Size = new System.Drawing.Size(367, 25);
			this.txtProcessName.TabIndex = 1;
			this.txtProcessName.TextChanged += new System.EventHandler(this.txtProcessName_TextChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ขั้นตอนการผลิต :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnMachine);
			this.panel2.Controls.Add(this.txtMachine);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 86);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(517, 28);
			this.panel2.TabIndex = 7;
			// 
			// btnMachine
			// 
			this.btnMachine.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnMachine.FlatAppearance.BorderSize = 0;
			this.btnMachine.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnMachine.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMachine.Image = ((System.Drawing.Image)(resources.GetObject("btnMachine.Image")));
			this.btnMachine.Location = new System.Drawing.Point(447, 1);
			this.btnMachine.Name = "btnMachine";
			this.btnMachine.Size = new System.Drawing.Size(26, 26);
			this.btnMachine.TabIndex = 3;
			this.btnMachine.UseVisualStyleBackColor = true;
			this.btnMachine.Click += new System.EventHandler(this.btnMachine_Click);
			// 
			// txtMachine
			// 
			this.txtMachine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtMachine.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMachine.Location = new System.Drawing.Point(109, 1);
			this.txtMachine.MaxLength = 150;
			this.txtMachine.Name = "txtMachine";
			this.txtMachine.Size = new System.Drawing.Size(338, 25);
			this.txtMachine.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "เครื่องจักร :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtScore);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 114);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(517, 28);
			this.panel4.TabIndex = 8;
			// 
			// txtScore
			// 
			this.txtScore.AllowControl = true;
			this.txtScore.AllowDecimal = true;
			this.txtScore.AllowMultipleDecimals = true;
			this.txtScore.AllowNegation = true;
			this.txtScore.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtScore.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtScore.IntegerValue = 0;
			this.txtScore.Location = new System.Drawing.Point(109, 1);
			this.txtScore.MaxLength = 5;
			this.txtScore.Name = "txtScore";
			this.txtScore.Size = new System.Drawing.Size(84, 25);
			this.txtScore.TabIndex = 2;
			this.txtScore.Text = "0";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "ระดับคะแนน :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ProductionProcessInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(527, 223);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProductionProcessInfo";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "PRODUCTION PROCESS INFO";
			this.Load += new System.EventHandler(this.ProductionProcessInfo_Load);
			this.panel1.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtProcessName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private OMControls.OMFlatButton btnMachine;
		private System.Windows.Forms.TextBox txtMachine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel4;
		private OMControls.Controls.NumericTextBox txtScore;
		private System.Windows.Forms.Label label2;
	}
}