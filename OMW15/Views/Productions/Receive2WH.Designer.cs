namespace OMW15.Views.Productions
{
	partial class Receive2WH
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
			this.ntxtReceiveQty = new OMControls.Controls.NumericTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtReceivedBy = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dtpReceiveDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(5, 117);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(443, 33);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(2, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(91, 29);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(350, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(91, 29);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.ntxtReceiveQty);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 20);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(443, 29);
			this.panel2.TabIndex = 1;
			// 
			// ntxtReceiveQty
			// 
			this.ntxtReceiveQty.AllowControl = true;
			this.ntxtReceiveQty.AllowDecimal = true;
			this.ntxtReceiveQty.AllowMultipleDecimals = true;
			this.ntxtReceiveQty.AllowNegation = true;
			this.ntxtReceiveQty.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.ntxtReceiveQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.ntxtReceiveQty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ntxtReceiveQty.IntegerValue = 0;
			this.ntxtReceiveQty.Location = new System.Drawing.Point(179, 2);
			this.ntxtReceiveQty.MaxLength = 15;
			this.ntxtReceiveQty.Name = "ntxtReceiveQty";
			this.ntxtReceiveQty.Size = new System.Drawing.Size(100, 23);
			this.ntxtReceiveQty.TabIndex = 1;
			this.ntxtReceiveQty.Text = "0";
			this.ntxtReceiveQty.TextChanged += new System.EventHandler(this.ntxtReceiveQty_TextChanged);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(177, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "จำนวนชิ้นงานที่รับเข้าคลังสินค้า :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtReceivedBy);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(5, 49);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(443, 29);
			this.panel3.TabIndex = 3;
			// 
			// txtReceivedBy
			// 
			this.txtReceivedBy.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtReceivedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtReceivedBy.Location = new System.Drawing.Point(179, 2);
			this.txtReceivedBy.MaxLength = 50;
			this.txtReceivedBy.Name = "txtReceivedBy";
			this.txtReceivedBy.Size = new System.Drawing.Size(187, 23);
			this.txtReceivedBy.TabIndex = 2;
			this.txtReceivedBy.TextChanged += new System.EventHandler(this.txtReceivedBy_TextChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(177, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "ผู้รับคลังสินค้า :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.dtpReceiveDate);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(5, 78);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(443, 29);
			this.panel4.TabIndex = 4;
			// 
			// dtpReceiveDate
			// 
			this.dtpReceiveDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpReceiveDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpReceiveDate.Location = new System.Drawing.Point(179, 2);
			this.dtpReceiveDate.Name = "dtpReceiveDate";
			this.dtpReceiveDate.Size = new System.Drawing.Size(187, 23);
			this.dtpReceiveDate.TabIndex = 2;
			this.dtpReceiveDate.CloseUp += new System.EventHandler(this.dtpReceiveDate_CloseUp);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(2, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 25);
			this.label3.TabIndex = 1;
			this.label3.Text = "วันที่รับ :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Receive2WH
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(453, 155);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Receive2WH";
			this.Padding = new System.Windows.Forms.Padding(5, 20, 5, 5);
			this.Text = "Receive";
			this.Load += new System.EventHandler(this.Receive2WH_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label3;
		private OMControls.Controls.NumericTextBox ntxtReceiveQty;
		private System.Windows.Forms.TextBox txtReceivedBy;
		private System.Windows.Forms.DateTimePicker dtpReceiveDate;
	}
}