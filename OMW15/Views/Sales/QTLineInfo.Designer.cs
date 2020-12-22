namespace OMW15.Views.Sales
{
	partial class QTLineInfo
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QTLineInfo));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gb = new System.Windows.Forms.GroupBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.txtLineTotal = new OMControls.Controls.NumericTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.txtQty = new OMControls.Controls.NumericTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbCurrency = new System.Windows.Forms.Label();
			this.txtUnitPrice = new OMControls.Controls.NumericTextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlItemInfo = new System.Windows.Forms.Panel();
			this.txtItemInfo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnItemInfo = new OMControls.OMFlatButton();
			this.txtItemName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lnklbFindInQTMasterItems = new System.Windows.Forms.LinkLabel();
			this.btnItemNo = new OMControls.OMFlatButton();
			this.txtItemNo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.lbHIndex = new System.Windows.Forms.Label();
			this.lbLineIndex = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ttip = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.gb.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.pnlItemInfo.SuspendLayout();
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
			this.panel1.Location = new System.Drawing.Point(15, 461);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(674, 35);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(486, 2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(93, 31);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(579, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(93, 31);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// gb
			// 
			this.gb.Controls.Add(this.panel9);
			this.gb.Controls.Add(this.panel8);
			this.gb.Controls.Add(this.panel7);
			this.gb.Controls.Add(this.panel6);
			this.gb.Controls.Add(this.pnlItemInfo);
			this.gb.Controls.Add(this.panel4);
			this.gb.Controls.Add(this.panel3);
			this.gb.Controls.Add(this.panel2);
			this.gb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gb.Location = new System.Drawing.Point(15, 15);
			this.gb.Name = "gb";
			this.gb.Padding = new System.Windows.Forms.Padding(10);
			this.gb.Size = new System.Drawing.Size(674, 446);
			this.gb.TabIndex = 1;
			this.gb.TabStop = false;
			this.gb.Text = "Item Information [Mode]";
			// 
			// panel9
			// 
			this.panel9.Controls.Add(this.txtLineTotal);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel9.Location = new System.Drawing.Point(10, 398);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(1);
			this.panel9.Size = new System.Drawing.Size(654, 28);
			this.panel9.TabIndex = 7;
			// 
			// txtLineTotal
			// 
			this.txtLineTotal.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtLineTotal.Location = new System.Drawing.Point(127, 1);
			this.txtLineTotal.MaxLength = 15;
			this.txtLineTotal.Name = "txtLineTotal";
			this.txtLineTotal.Size = new System.Drawing.Size(121, 25);
			this.txtLineTotal.TabIndex = 8;
			this.txtLineTotal.Text = "0.00";
			// 
			// label10
			// 
			this.label10.Dock = System.Windows.Forms.DockStyle.Left;
			this.label10.Location = new System.Drawing.Point(1, 1);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(126, 26);
			this.label10.TabIndex = 7;
			this.label10.Text = "Total Amount : ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.txtQty);
			this.panel8.Controls.Add(this.label9);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel8.Location = new System.Drawing.Point(10, 370);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(654, 28);
			this.panel8.TabIndex = 6;
			// 
			// txtQty
			// 
			this.txtQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtQty.Location = new System.Drawing.Point(127, 1);
			this.txtQty.MaxLength = 10;
			this.txtQty.Name = "txtQty";
			this.txtQty.Size = new System.Drawing.Size(121, 25);
			this.txtQty.TabIndex = 7;
			this.txtQty.Text = "0.00";
			this.txtQty.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
			// 
			// label9
			// 
			this.label9.Dock = System.Windows.Forms.DockStyle.Left;
			this.label9.Location = new System.Drawing.Point(1, 1);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(126, 26);
			this.label9.TabIndex = 6;
			this.label9.Text = "Qty : ";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lbCurrency);
			this.panel7.Controls.Add(this.txtUnitPrice);
			this.panel7.Controls.Add(this.label8);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel7.Location = new System.Drawing.Point(10, 342);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(654, 28);
			this.panel7.TabIndex = 5;
			// 
			// lbCurrency
			// 
			this.lbCurrency.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCurrency.Location = new System.Drawing.Point(248, 1);
			this.lbCurrency.Name = "lbCurrency";
			this.lbCurrency.Size = new System.Drawing.Size(50, 26);
			this.lbCurrency.TabIndex = 7;
			this.lbCurrency.Text = "USD";
			this.lbCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtUnitPrice
			// 
			this.txtUnitPrice.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnitPrice.Location = new System.Drawing.Point(127, 1);
			this.txtUnitPrice.MaxLength = 15;
			this.txtUnitPrice.Name = "txtUnitPrice";
			this.txtUnitPrice.Size = new System.Drawing.Size(121, 25);
			this.txtUnitPrice.TabIndex = 6;
			this.txtUnitPrice.Text = "0.00";
			this.txtUnitPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
			// 
			// label8
			// 
			this.label8.Dock = System.Windows.Forms.DockStyle.Left;
			this.label8.Location = new System.Drawing.Point(1, 1);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 26);
			this.label8.TabIndex = 5;
			this.label8.Text = "Unit Price : ";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtUnit);
			this.panel6.Controls.Add(this.label7);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel6.Location = new System.Drawing.Point(10, 314);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(1);
			this.panel6.Size = new System.Drawing.Size(654, 28);
			this.panel6.TabIndex = 4;
			// 
			// txtUnit
			// 
			this.txtUnit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtUnit.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtUnit.Location = new System.Drawing.Point(127, 1);
			this.txtUnit.MaxLength = 10;
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(67, 25);
			this.txtUnit.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(126, 26);
			this.label7.TabIndex = 4;
			this.label7.Text = "Unit : ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlItemInfo
			// 
			this.pnlItemInfo.Controls.Add(this.txtItemInfo);
			this.pnlItemInfo.Controls.Add(this.label6);
			this.pnlItemInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlItemInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlItemInfo.Location = new System.Drawing.Point(10, 112);
			this.pnlItemInfo.Name = "pnlItemInfo";
			this.pnlItemInfo.Padding = new System.Windows.Forms.Padding(1);
			this.pnlItemInfo.Size = new System.Drawing.Size(654, 202);
			this.pnlItemInfo.TabIndex = 3;
			// 
			// txtItemInfo
			// 
			this.txtItemInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemInfo.Location = new System.Drawing.Point(127, 1);
			this.txtItemInfo.MaxLength = 2000;
			this.txtItemInfo.Multiline = true;
			this.txtItemInfo.Name = "txtItemInfo";
			this.txtItemInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtItemInfo.Size = new System.Drawing.Size(485, 200);
			this.txtItemInfo.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(126, 200);
			this.label6.TabIndex = 3;
			this.label6.Text = "Item Info : ";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnItemInfo);
			this.panel4.Controls.Add(this.txtItemName);
			this.panel4.Controls.Add(this.label5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel4.Location = new System.Drawing.Point(10, 84);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(654, 28);
			this.panel4.TabIndex = 2;
			// 
			// btnItemInfo
			// 
			this.btnItemInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnItemInfo.FlatAppearance.BorderSize = 0;
			this.btnItemInfo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnItemInfo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnItemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItemInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnItemInfo.Image")));
			this.btnItemInfo.Location = new System.Drawing.Point(612, 1);
			this.btnItemInfo.Name = "btnItemInfo";
			this.btnItemInfo.Size = new System.Drawing.Size(26, 26);
			this.btnItemInfo.Style = OMControls.ButtonImageStyle.AddItem;
			this.btnItemInfo.TabIndex = 4;
			this.btnItemInfo.Tag = "OFF";
			this.ttip.SetToolTip(this.btnItemInfo, "Add / Edit Item Info");
			this.btnItemInfo.UseVisualStyleBackColor = true;
			this.btnItemInfo.Click += new System.EventHandler(this.btnItemInfo_Click);
			// 
			// txtItemName
			// 
			this.txtItemName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemName.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemName.Location = new System.Drawing.Point(127, 1);
			this.txtItemName.MaxLength = 150;
			this.txtItemName.Name = "txtItemName";
			this.txtItemName.Size = new System.Drawing.Size(485, 25);
			this.txtItemName.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(1, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(126, 26);
			this.label5.TabIndex = 2;
			this.label5.Text = "Item Name : ";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lnklbFindInQTMasterItems);
			this.panel3.Controls.Add(this.btnItemNo);
			this.panel3.Controls.Add(this.txtItemNo);
			this.panel3.Controls.Add(this.label4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel3.Location = new System.Drawing.Point(10, 56);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(654, 28);
			this.panel3.TabIndex = 1;
			// 
			// lnklbFindInQTMasterItems
			// 
			this.lnklbFindInQTMasterItems.Dock = System.Windows.Forms.DockStyle.Left;
			this.lnklbFindInQTMasterItems.Image = global::OMW15.Properties.Resources.FindHS;
			this.lnklbFindInQTMasterItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lnklbFindInQTMasterItems.Location = new System.Drawing.Point(352, 1);
			this.lnklbFindInQTMasterItems.Name = "lnklbFindInQTMasterItems";
			this.lnklbFindInQTMasterItems.Size = new System.Drawing.Size(243, 26);
			this.lnklbFindInQTMasterItems.TabIndex = 4;
			this.lnklbFindInQTMasterItems.TabStop = true;
			this.lnklbFindInQTMasterItems.Text = "Find from Master Quotation Item";
			this.lnklbFindInQTMasterItems.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnklbFindInQTMasterItems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklbFindInQTMasterItems_LinkClicked);
			// 
			// btnItemNo
			// 
			this.btnItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnItemNo.FlatAppearance.BorderSize = 0;
			this.btnItemNo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnItemNo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnItemNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnItemNo.Image = ((System.Drawing.Image)(resources.GetObject("btnItemNo.Image")));
			this.btnItemNo.Location = new System.Drawing.Point(326, 1);
			this.btnItemNo.Name = "btnItemNo";
			this.btnItemNo.Size = new System.Drawing.Size(26, 26);
			this.btnItemNo.TabIndex = 3;
			this.ttip.SetToolTip(this.btnItemNo, "Select Item from Stock Item");
			this.btnItemNo.UseVisualStyleBackColor = true;
			this.btnItemNo.Click += new System.EventHandler(this.btnItemNo_Click);
			// 
			// txtItemNo
			// 
			this.txtItemNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtItemNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtItemNo.Location = new System.Drawing.Point(127, 1);
			this.txtItemNo.MaxLength = 30;
			this.txtItemNo.Name = "txtItemNo";
			this.txtItemNo.Size = new System.Drawing.Size(199, 25);
			this.txtItemNo.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(126, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "Item No. : ";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.lbHIndex);
			this.panel2.Controls.Add(this.lbLineIndex);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel2.Location = new System.Drawing.Point(10, 28);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(654, 28);
			this.panel2.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Right;
			this.label3.Location = new System.Drawing.Point(538, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 26);
			this.label3.TabIndex = 4;
			this.label3.Text = "Hdx : ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbHIndex
			// 
			this.lbHIndex.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbHIndex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHIndex.Location = new System.Drawing.Point(581, 1);
			this.lbHIndex.Name = "lbHIndex";
			this.lbHIndex.Size = new System.Drawing.Size(72, 26);
			this.lbHIndex.TabIndex = 3;
			this.lbHIndex.Text = "0";
			this.lbHIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbLineIndex
			// 
			this.lbLineIndex.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbLineIndex.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbLineIndex.Location = new System.Drawing.Point(44, 1);
			this.lbLineIndex.Name = "lbLineIndex";
			this.lbLineIndex.Size = new System.Drawing.Size(72, 26);
			this.lbLineIndex.TabIndex = 1;
			this.lbLineIndex.Text = "0";
			this.lbLineIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Idx : ";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// QTLineInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(704, 511);
			this.Controls.Add(this.gb);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "QTLineInfo";
			this.Padding = new System.Windows.Forms.Padding(15);
			this.Text = "Quotation Line Info";
			this.Load += new System.EventHandler(this.QTLineInfo_Load);
			this.panel1.ResumeLayout(false);
			this.gb.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel7.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.pnlItemInfo.ResumeLayout(false);
			this.pnlItemInfo.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gb;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel pnlItemInfo;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lbHIndex;
		private System.Windows.Forms.Label lbLineIndex;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private OMControls.Controls.NumericTextBox txtLineTotal;
		private System.Windows.Forms.Label label10;
		private OMControls.Controls.NumericTextBox txtQty;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbCurrency;
		private OMControls.Controls.NumericTextBox txtUnitPrice;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtItemName;
		private OMControls.OMFlatButton btnItemNo;
		private System.Windows.Forms.TextBox txtItemNo;
		private System.Windows.Forms.TextBox txtUnit;
		private System.Windows.Forms.TextBox txtItemInfo;
		private OMControls.OMFlatButton btnItemInfo;
		private System.Windows.Forms.ToolTip ttip;
		private System.Windows.Forms.LinkLabel lnklbFindInQTMasterItems;
	}
}