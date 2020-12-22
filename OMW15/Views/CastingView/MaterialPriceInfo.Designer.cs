namespace OMW15.Views.CastingView
{
	partial class MaterialPriceInfo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaterialPriceInfo));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grp = new System.Windows.Forms.GroupBox();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lbMatPrice = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbMatCost = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbExchangeDate = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnExchnageRate = new OMControls.OMFlatButton();
			this.txtExchangeRate = new OMControls.Controls.NumericTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbMarkup = new System.Windows.Forms.Label();
			this.txtMatCostUSD = new OMControls.Controls.NumericTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cbxMaterial = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbId = new System.Windows.Forms.Label();
			this.dtpPriceDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grp.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(8, 265);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Size = new System.Drawing.Size(402, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(208, 5);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(95, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "บันทึก";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(303, 5);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(95, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "ยกเลิก";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// grp
			// 
			this.grp.Controls.Add(this.panel8);
			this.grp.Controls.Add(this.panel9);
			this.grp.Controls.Add(this.panel6);
			this.grp.Controls.Add(this.panel7);
			this.grp.Controls.Add(this.panel5);
			this.grp.Controls.Add(this.panel4);
			this.grp.Controls.Add(this.panel3);
			this.grp.Controls.Add(this.panel2);
			this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grp.Location = new System.Drawing.Point(8, 9);
			this.grp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.grp.Name = "grp";
			this.grp.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.grp.Size = new System.Drawing.Size(402, 256);
			this.grp.TabIndex = 1;
			this.grp.TabStop = false;
			this.grp.Text = "คำนวนราคาขายวัสดุ (XXX)";
			// 
			// panel8
			// 
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(8, 209);
			this.panel8.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(386, 26);
			this.panel8.TabIndex = 7;
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.lbMatPrice);
			this.panel9.Controls.Add(this.label7);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(8, 183);
			this.panel9.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(386, 26);
			this.panel9.TabIndex = 6;
			// 
			// lbMatPrice
			// 
			this.lbMatPrice.BackColor = System.Drawing.Color.Red;
			this.lbMatPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMatPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMatPrice.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMatPrice.ForeColor = System.Drawing.Color.Yellow;
			this.lbMatPrice.Location = new System.Drawing.Point(153, 1);
			this.lbMatPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbMatPrice.Name = "lbMatPrice";
			this.lbMatPrice.Size = new System.Drawing.Size(117, 24);
			this.lbMatPrice.TabIndex = 9;
			this.lbMatPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(152, 24);
			this.label7.TabIndex = 8;
			this.label7.Text = "ราคาขายวัสดุ (บาท/กรัม) :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbMatCost);
			this.panel6.Controls.Add(this.label6);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(8, 157);
			this.panel6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(386, 26);
			this.panel6.TabIndex = 5;
			// 
			// lbMatCost
			// 
			this.lbMatCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbMatCost.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMatCost.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMatCost.Location = new System.Drawing.Point(153, 1);
			this.lbMatCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbMatCost.Name = "lbMatCost";
			this.lbMatCost.Size = new System.Drawing.Size(117, 24);
			this.lbMatCost.TabIndex = 8;
			this.lbMatCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 24);
			this.label6.TabIndex = 7;
			this.label6.Text = "ต้นทุนวัสดุ (บาท/กรัม) :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lbExchangeDate);
			this.panel7.Controls.Add(this.label5);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(8, 131);
			this.panel7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(386, 26);
			this.panel7.TabIndex = 4;
			// 
			// lbExchangeDate
			// 
			this.lbExchangeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbExchangeDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbExchangeDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbExchangeDate.Location = new System.Drawing.Point(153, 1);
			this.lbExchangeDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbExchangeDate.Name = "lbExchangeDate";
			this.lbExchangeDate.Size = new System.Drawing.Size(117, 24);
			this.lbExchangeDate.TabIndex = 7;
			this.lbExchangeDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 24);
			this.label5.TabIndex = 6;
			this.label5.Text = "วันที่ใช้อัตราแลกเปลี่ยน :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnExchnageRate);
			this.panel5.Controls.Add(this.txtExchangeRate);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(8, 105);
			this.panel5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(386, 26);
			this.panel5.TabIndex = 3;
			// 
			// btnExchnageRate
			// 
			this.btnExchnageRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnExchnageRate.FlatAppearance.BorderSize = 0;
			this.btnExchnageRate.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnExchnageRate.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnExchnageRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExchnageRate.Image = ((System.Drawing.Image)(resources.GetObject("btnExchnageRate.Image")));
			this.btnExchnageRate.Location = new System.Drawing.Point(271, 1);
			this.btnExchnageRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.btnExchnageRate.Name = "btnExchnageRate";
			this.btnExchnageRate.Size = new System.Drawing.Size(24, 24);
			this.btnExchnageRate.Style = OMControls.ButtonImageStyle.Find;
			this.btnExchnageRate.TabIndex = 7;
			this.btnExchnageRate.UseVisualStyleBackColor = true;
			this.btnExchnageRate.Click += new System.EventHandler(this.btnExchnageRate_Click);
			// 
			// txtExchangeRate
			// 
			this.txtExchangeRate.AllowControl = true;
			this.txtExchangeRate.AllowDecimal = true;
			this.txtExchangeRate.AllowMultipleDecimals = true;
			this.txtExchangeRate.AllowNegation = true;
			this.txtExchangeRate.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtExchangeRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtExchangeRate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtExchangeRate.IntegerValue = 0;
			this.txtExchangeRate.Location = new System.Drawing.Point(153, 1);
			this.txtExchangeRate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtExchangeRate.MaxLength = 10;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(118, 25);
			this.txtExchangeRate.TabIndex = 6;
			this.txtExchangeRate.Text = "0.00";
			this.txtExchangeRate.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "อัตราแลกเปลี่ยน (บาท/USD):";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbMarkup);
			this.panel4.Controls.Add(this.txtMatCostUSD);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(8, 79);
			this.panel4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(386, 26);
			this.panel4.TabIndex = 2;
			// 
			// lbMarkup
			// 
			this.lbMarkup.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMarkup.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMarkup.Location = new System.Drawing.Point(326, 1);
			this.lbMarkup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbMarkup.Name = "lbMarkup";
			this.lbMarkup.Size = new System.Drawing.Size(59, 24);
			this.lbMarkup.TabIndex = 6;
			this.lbMarkup.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// txtMatCostUSD
			// 
			this.txtMatCostUSD.AllowControl = true;
			this.txtMatCostUSD.AllowDecimal = true;
			this.txtMatCostUSD.AllowMultipleDecimals = true;
			this.txtMatCostUSD.AllowNegation = true;
			this.txtMatCostUSD.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
			this.txtMatCostUSD.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtMatCostUSD.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatCostUSD.IntegerValue = 0;
			this.txtMatCostUSD.Location = new System.Drawing.Point(153, 1);
			this.txtMatCostUSD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.txtMatCostUSD.MaxLength = 10;
			this.txtMatCostUSD.Name = "txtMatCostUSD";
			this.txtMatCostUSD.Size = new System.Drawing.Size(118, 25);
			this.txtMatCostUSD.TabIndex = 5;
			this.txtMatCostUSD.Text = "0.00";
			this.txtMatCostUSD.TextChanged += new System.EventHandler(this.txt_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "ราคาต้นทุน (USD) / oz:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.cbxMaterial);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(8, 53);
			this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(386, 26);
			this.panel3.TabIndex = 1;
			// 
			// cbxMaterial
			// 
			this.cbxMaterial.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaterial.FormattingEnabled = true;
			this.cbxMaterial.Location = new System.Drawing.Point(153, 1);
			this.cbxMaterial.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.cbxMaterial.Name = "cbxMaterial";
			this.cbxMaterial.Size = new System.Drawing.Size(184, 25);
			this.cbxMaterial.TabIndex = 4;
			this.cbxMaterial.SelectedIndexChanged += new System.EventHandler(this.cbxMaterial_SelectedIndexChanged);
			this.cbxMaterial.SelectedValueChanged += new System.EventHandler(this.cbxMaterial_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(152, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "ประเภทวัสดุ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbId);
			this.panel2.Controls.Add(this.dtpPriceDate);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(8, 27);
			this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(386, 26);
			this.panel2.TabIndex = 0;
			// 
			// lbId
			// 
			this.lbId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbId.Location = new System.Drawing.Point(326, 1);
			this.lbId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbId.Name = "lbId";
			this.lbId.Size = new System.Drawing.Size(59, 24);
			this.lbId.TabIndex = 4;
			this.lbId.Text = "id : (0)";
			this.lbId.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// dtpPriceDate
			// 
			this.dtpPriceDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpPriceDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpPriceDate.Location = new System.Drawing.Point(153, 1);
			this.dtpPriceDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.dtpPriceDate.Name = "dtpPriceDate";
			this.dtpPriceDate.Size = new System.Drawing.Size(118, 25);
			this.dtpPriceDate.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "วันที่คำนวนราคา";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MaterialPriceInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(418, 316);
			this.Controls.Add(this.grp);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MaterialPriceInfo";
			this.Padding = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.Text = "MATERIAL PRICE CALCULATION";
			this.Load += new System.EventHandler(this.MaterialPriceInfo_Load);
			this.panel1.ResumeLayout(false);
			this.grp.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox grp;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbxMaterial;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtpPriceDate;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbExchangeDate;
		private System.Windows.Forms.Label label5;
		private OMControls.OMFlatButton btnExchnageRate;
		private OMControls.Controls.NumericTextBox txtExchangeRate;
		private OMControls.Controls.NumericTextBox txtMatCostUSD;
		private System.Windows.Forms.Label lbMatPrice;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbMatCost;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbId;
		private System.Windows.Forms.Label lbMarkup;
	}
}