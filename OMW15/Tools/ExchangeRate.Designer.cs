namespace OMW15.Tools
{
	partial class ExchangeRate
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
			this.grpCurrency = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtExchangeRate = new OMControls.Controls.NumericTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.dtpExpire = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.dtpEffective = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.grpCurrency.SuspendLayout();
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
			this.panel1.Location = new System.Drawing.Point(19, 149);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(390, 34);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(128, 0);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(131, 34);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(259, 0);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(131, 34);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// grpCurrency
			// 
			this.grpCurrency.Controls.Add(this.panel4);
			this.grpCurrency.Controls.Add(this.panel3);
			this.grpCurrency.Controls.Add(this.panel2);
			this.grpCurrency.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpCurrency.Location = new System.Drawing.Point(19, 18);
			this.grpCurrency.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.grpCurrency.Name = "grpCurrency";
			this.grpCurrency.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
			this.grpCurrency.Size = new System.Drawing.Size(390, 131);
			this.grpCurrency.TabIndex = 1;
			this.grpCurrency.TabStop = false;
			this.grpCurrency.Text = "Currency [XXX]";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtExchangeRate);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(19, 91);
			this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel4.Size = new System.Drawing.Size(352, 28);
			this.panel4.TabIndex = 2;
			// 
			// txtExchangeRate
			// 
			this.txtExchangeRate.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtExchangeRate.Location = new System.Drawing.Point(169, 2);
			this.txtExchangeRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtExchangeRate.MaxLength = 10;
			this.txtExchangeRate.Name = "txtExchangeRate";
			this.txtExchangeRate.Size = new System.Drawing.Size(162, 24);
			this.txtExchangeRate.TabIndex = 1;
			this.txtExchangeRate.Text = "0.00";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(3, 2);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(166, 24);
			this.label3.TabIndex = 0;
			this.label3.Text = "อัตราแลกเปลี่ยน (THB)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.dtpExpire);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(19, 63);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Size = new System.Drawing.Size(352, 28);
			this.panel3.TabIndex = 1;
			// 
			// dtpExpire
			// 
			this.dtpExpire.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpExpire.Location = new System.Drawing.Point(169, 2);
			this.dtpExpire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtpExpire.Name = "dtpExpire";
			this.dtpExpire.Size = new System.Drawing.Size(162, 24);
			this.dtpExpire.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(3, 2);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(166, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "วันที่สิ้นสุด";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.dtpEffective);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(19, 35);
			this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Size = new System.Drawing.Size(352, 28);
			this.panel2.TabIndex = 0;
			// 
			// dtpEffective
			// 
			this.dtpEffective.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpEffective.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpEffective.Location = new System.Drawing.Point(169, 2);
			this.dtpEffective.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.dtpEffective.Name = "dtpEffective";
			this.dtpEffective.Size = new System.Drawing.Size(162, 24);
			this.dtpEffective.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(3, 2);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "วันที่เริ่มใช้";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ExchangeRate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(428, 201);
			this.Controls.Add(this.grpCurrency);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "ExchangeRate";
			this.Padding = new System.Windows.Forms.Padding(19, 18, 19, 18);
			this.Text = "EXCHANGE RATE";
			this.Load += new System.EventHandler(this.ExchangeRate_Load);
			this.panel1.ResumeLayout(false);
			this.grpCurrency.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox grpCurrency;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel4;
		private OMControls.Controls.NumericTextBox txtExchangeRate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtpExpire;
		private System.Windows.Forms.DateTimePicker dtpEffective;
	}
}