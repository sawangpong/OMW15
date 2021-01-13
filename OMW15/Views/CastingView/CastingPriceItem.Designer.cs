namespace OMW15.Views.CastingView
{
	partial class CastingPriceItem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CastingPriceItem));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.pnlBody = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnUnitName = new OMControls.OMFlatButton();
			this.txtUnitName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtPriceYear = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtUnitPriceWithMat = new OMControls.Controls.NumericTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtUnitPrice = new OMControls.Controls.NumericTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbxMaterial = new System.Windows.Forms.ComboBox();
			this.panel1.SuspendLayout();
			this.pnlTop.SuspendLayout();
			this.pnlBody.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(0, 232);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(337, 48);
			this.panel1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(248, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(79, 28);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSave.Location = new System.Drawing.Point(10, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(79, 28);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlTop.Controls.Add(this.lbMode);
			this.pnlTop.Controls.Add(this.lbTitle);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(337, 40);
			this.pnlTop.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(248, 0);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(89, 40);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "x";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(0, 0);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(156, 40);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "ราคาค่าหล่อชิ้นงาน";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.panel4);
			this.pnlBody.Controls.Add(this.panel5);
			this.pnlBody.Controls.Add(this.panel7);
			this.pnlBody.Controls.Add(this.panel6);
			this.pnlBody.Controls.Add(this.panel3);
			this.pnlBody.Controls.Add(this.panel2);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(0, 40);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2);
			this.pnlBody.Size = new System.Drawing.Size(337, 192);
			this.pnlBody.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnUnitName);
			this.panel6.Controls.Add(this.txtUnitName);
			this.panel6.Controls.Add(this.label4);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 43);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(333, 30);
			this.panel6.TabIndex = 4;
			// 
			// btnUnitName
			// 
			this.btnUnitName.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnUnitName.FlatAppearance.BorderSize = 0;
			this.btnUnitName.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnUnitName.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnUnitName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnUnitName.Image = ((System.Drawing.Image)(resources.GetObject("btnUnitName.Image")));
			this.btnUnitName.Location = new System.Drawing.Point(252, 2);
			this.btnUnitName.Name = "btnUnitName";
			this.btnUnitName.Size = new System.Drawing.Size(26, 26);
			this.btnUnitName.TabIndex = 3;
			this.btnUnitName.UseVisualStyleBackColor = true;
			this.btnUnitName.Click += new System.EventHandler(this.btnUnitName_Click);
			// 
			// txtUnitName
			// 
			this.txtUnitName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnitName.Location = new System.Drawing.Point(136, 2);
			this.txtUnitName.MaxLength = 10;
			this.txtUnitName.Name = "txtUnitName";
			this.txtUnitName.Size = new System.Drawing.Size(116, 25);
			this.txtUnitName.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(134, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "หน่วย :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtPriceYear);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 13);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(333, 30);
			this.panel3.TabIndex = 1;
			// 
			// txtPriceYear
			// 
			this.txtPriceYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPriceYear.Location = new System.Drawing.Point(136, 2);
			this.txtPriceYear.MaxLength = 4;
			this.txtPriceYear.Name = "txtPriceYear";
			this.txtPriceYear.Size = new System.Drawing.Size(69, 25);
			this.txtPriceYear.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ปี :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(2, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(333, 11);
			this.panel2.TabIndex = 0;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.cbxMaterial);
			this.panel7.Controls.Add(this.label5);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(2, 73);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(333, 30);
			this.panel7.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(2, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 26);
			this.label5.TabIndex = 1;
			this.label5.Text = "วัสดุ :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtUnitPriceWithMat);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 133);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(333, 30);
			this.panel4.TabIndex = 9;
			// 
			// txtUnitPriceWithMat
			// 
			this.txtUnitPriceWithMat.AllowControl = true;
			this.txtUnitPriceWithMat.AllowDecimal = true;
			this.txtUnitPriceWithMat.AllowMultipleDecimals = true;
			this.txtUnitPriceWithMat.AllowNegation = true;
			this.txtUnitPriceWithMat.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtUnitPriceWithMat.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnitPriceWithMat.IntegerValue = 0;
			this.txtUnitPriceWithMat.Location = new System.Drawing.Point(136, 2);
			this.txtUnitPriceWithMat.MaxLength = 10;
			this.txtUnitPriceWithMat.Name = "txtUnitPriceWithMat";
			this.txtUnitPriceWithMat.Size = new System.Drawing.Size(116, 25);
			this.txtUnitPriceWithMat.TabIndex = 6;
			this.txtUnitPriceWithMat.Text = "0";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(134, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "ราคารวมวัสดุ  (บาท) :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtUnitPrice);
			this.panel5.Controls.Add(this.label3);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 103);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(333, 30);
			this.panel5.TabIndex = 8;
			// 
			// txtUnitPrice
			// 
			this.txtUnitPrice.AllowControl = true;
			this.txtUnitPrice.AllowDecimal = true;
			this.txtUnitPrice.AllowMultipleDecimals = true;
			this.txtUnitPrice.AllowNegation = true;
			this.txtUnitPrice.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.txtUnitPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnitPrice.IntegerValue = 0;
			this.txtUnitPrice.Location = new System.Drawing.Point(136, 2);
			this.txtUnitPrice.MaxLength = 10;
			this.txtUnitPrice.Name = "txtUnitPrice";
			this.txtUnitPrice.Size = new System.Drawing.Size(116, 25);
			this.txtUnitPrice.TabIndex = 5;
			this.txtUnitPrice.Text = "0";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(134, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "ราคา (บาท) :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxMaterial
			// 
			this.cbxMaterial.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterial.FormattingEnabled = true;
			this.cbxMaterial.Location = new System.Drawing.Point(136, 2);
			this.cbxMaterial.Margin = new System.Windows.Forms.Padding(4);
			this.cbxMaterial.Name = "cbxMaterial";
			this.cbxMaterial.Size = new System.Drawing.Size(151, 25);
			this.cbxMaterial.TabIndex = 8;
			this.cbxMaterial.SelectedValueChanged += new System.EventHandler(this.cbxMaterial_SelectedValueChanged);
			// 
			// CastingPriceItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(337, 280);
			this.Controls.Add(this.pnlBody);
			this.Controls.Add(this.pnlTop);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingPriceItem";
			this.Text = "Casting Price Item";
			this.Load += new System.EventHandler(this.CastingPriceItem_Load);
			this.panel1.ResumeLayout(false);
			this.pnlTop.ResumeLayout(false);
			this.pnlBody.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel pnlTop;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtPriceYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtUnitName;
		private System.Windows.Forms.Label label4;
		private OMControls.OMFlatButton btnUnitName;
		private System.Windows.Forms.Panel panel4;
		private OMControls.Controls.NumericTextBox txtUnitPriceWithMat;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private OMControls.Controls.NumericTextBox txtUnitPrice;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbxMaterial;
	}
}