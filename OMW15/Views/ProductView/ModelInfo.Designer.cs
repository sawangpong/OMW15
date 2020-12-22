namespace OMW15.Views.ProductView
{
	partial class ModelInfo
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
			if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMode = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.chkOwnProduct = new System.Windows.Forms.CheckBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.chkAfterSaleService = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbxProductGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtProductDetail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnFindPic = new OMControls.OMFlatButton();
            this.btnDeletePic = new OMControls.OMFlatButton();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.chkSpecialProduct = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.chkDiscontinue = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.chkBuyForTread = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 15);
            this.panel1.Size = new System.Drawing.Size(688, 47);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(494, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(590, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbMode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(688, 37);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Info.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbMode
            // 
            this.lbMode.BackColor = System.Drawing.Color.Red;
            this.lbMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMode.ForeColor = System.Drawing.Color.Yellow;
            this.lbMode.Location = new System.Drawing.Point(2, 2);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(90, 33);
            this.lbMode.TabIndex = 1;
            this.lbMode.Text = "Mode";
            this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(1);
            this.panel3.Size = new System.Drawing.Size(688, 171);
            this.panel3.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.chkOwnProduct);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(1, 141);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(1);
            this.panel10.Size = new System.Drawing.Size(562, 28);
            this.panel10.TabIndex = 9;
            // 
            // chkOwnProduct
            // 
            this.chkOwnProduct.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkOwnProduct.Location = new System.Drawing.Point(1, 1);
            this.chkOwnProduct.Name = "chkOwnProduct";
            this.chkOwnProduct.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.chkOwnProduct.Size = new System.Drawing.Size(470, 26);
            this.chkOwnProduct.TabIndex = 1;
            this.chkOwnProduct.Text = "เป็นสินค้าที่ผลิตเอง";
            this.chkOwnProduct.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.chkAfterSaleService);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(1, 113);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(1);
            this.panel9.Size = new System.Drawing.Size(562, 28);
            this.panel9.TabIndex = 8;
            // 
            // chkAfterSaleService
            // 
            this.chkAfterSaleService.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAfterSaleService.Location = new System.Drawing.Point(1, 1);
            this.chkAfterSaleService.Name = "chkAfterSaleService";
            this.chkAfterSaleService.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.chkAfterSaleService.Size = new System.Drawing.Size(470, 26);
            this.chkAfterSaleService.TabIndex = 0;
            this.chkAfterSaleService.Text = "มีบริการหลังการขาย";
            this.chkAfterSaleService.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cbxProductGroup);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(1, 85);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(1);
            this.panel7.Size = new System.Drawing.Size(562, 28);
            this.panel7.TabIndex = 7;
            // 
            // cbxProductGroup
            // 
            this.cbxProductGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbxProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProductGroup.FormattingEnabled = true;
            this.cbxProductGroup.Location = new System.Drawing.Point(120, 1);
            this.cbxProductGroup.Name = "cbxProductGroup";
            this.cbxProductGroup.Size = new System.Drawing.Size(270, 25);
            this.cbxProductGroup.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(1, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "กลุ่มสินค้า:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtProductDetail);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(1, 57);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(1);
            this.panel8.Size = new System.Drawing.Size(562, 28);
            this.panel8.TabIndex = 4;
            // 
            // txtProductDetail
            // 
            this.txtProductDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProductDetail.Location = new System.Drawing.Point(120, 1);
            this.txtProductDetail.MaxLength = 150;
            this.txtProductDetail.Name = "txtProductDetail";
            this.txtProductDetail.Size = new System.Drawing.Size(420, 25);
            this.txtProductDetail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "รายละเอียด:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtModel);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(1, 29);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(1);
            this.panel6.Size = new System.Drawing.Size(562, 28);
            this.panel6.TabIndex = 2;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtModel.Location = new System.Drawing.Point(120, 1);
            this.txtModel.MaxLength = 50;
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(268, 25);
            this.txtModel.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "รุ่นสินค้า:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtProductId);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(1, 1);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(1);
            this.panel5.Size = new System.Drawing.Size(562, 28);
            this.panel5.TabIndex = 1;
            // 
            // txtProductId
            // 
            this.txtProductId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProductId.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtProductId.Location = new System.Drawing.Point(120, 1);
            this.txtProductId.MaxLength = 4;
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(69, 25);
            this.txtProductId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "รหัส:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel14);
            this.panel4.Controls.Add(this.pic);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(563, 1);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(124, 169);
            this.panel4.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnFindPic);
            this.panel14.Controls.Add(this.btnDeletePic);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(2, 139);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(1);
            this.panel14.Size = new System.Drawing.Size(120, 28);
            this.panel14.TabIndex = 1;
            // 
            // btnFindPic
            // 
            this.btnFindPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFindPic.FlatAppearance.BorderSize = 0;
            this.btnFindPic.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFindPic.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFindPic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindPic.Image = ((System.Drawing.Image)(resources.GetObject("btnFindPic.Image")));
            this.btnFindPic.Location = new System.Drawing.Point(93, 1);
            this.btnFindPic.Name = "btnFindPic";
            this.btnFindPic.Size = new System.Drawing.Size(26, 26);
            this.btnFindPic.Style = OMControls.ButtonImageStyle.Find;
            this.btnFindPic.TabIndex = 3;
            this.btnFindPic.UseVisualStyleBackColor = true;
            this.btnFindPic.Click += new System.EventHandler(this.btnFindPic_Click);
            // 
            // btnDeletePic
            // 
            this.btnDeletePic.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDeletePic.FlatAppearance.BorderSize = 0;
            this.btnDeletePic.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDeletePic.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeletePic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePic.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePic.Image")));
            this.btnDeletePic.Location = new System.Drawing.Point(1, 1);
            this.btnDeletePic.Name = "btnDeletePic";
            this.btnDeletePic.Size = new System.Drawing.Size(26, 26);
            this.btnDeletePic.Style = OMControls.ButtonImageStyle.Delete;
            this.btnDeletePic.TabIndex = 2;
            this.btnDeletePic.UseVisualStyleBackColor = true;
            this.btnDeletePic.Click += new System.EventHandler(this.btnDeletePic_Click);
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pic.Location = new System.Drawing.Point(2, 2);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(120, 132);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.chkSpecialProduct);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 208);
            this.panel11.Name = "panel11";
            this.panel11.Padding = new System.Windows.Forms.Padding(1);
            this.panel11.Size = new System.Drawing.Size(688, 28);
            this.panel11.TabIndex = 10;
            // 
            // chkSpecialProduct
            // 
            this.chkSpecialProduct.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkSpecialProduct.Location = new System.Drawing.Point(1, 1);
            this.chkSpecialProduct.Name = "chkSpecialProduct";
            this.chkSpecialProduct.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.chkSpecialProduct.Size = new System.Drawing.Size(470, 26);
            this.chkSpecialProduct.TabIndex = 1;
            this.chkSpecialProduct.Text = "เป็นสินค้าสั่งผลิตพิเศษ";
            this.chkSpecialProduct.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.chkDiscontinue);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 236);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(1);
            this.panel12.Size = new System.Drawing.Size(688, 28);
            this.panel12.TabIndex = 11;
            // 
            // chkDiscontinue
            // 
            this.chkDiscontinue.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDiscontinue.Location = new System.Drawing.Point(1, 1);
            this.chkDiscontinue.Name = "chkDiscontinue";
            this.chkDiscontinue.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.chkDiscontinue.Size = new System.Drawing.Size(470, 26);
            this.chkDiscontinue.TabIndex = 1;
            this.chkDiscontinue.Text = "เลิกผลิตสินค้าชนิดนี้แล้ว";
            this.chkDiscontinue.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.chkBuyForTread);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 264);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(1);
            this.panel13.Size = new System.Drawing.Size(688, 28);
            this.panel13.TabIndex = 12;
            // 
            // chkBuyForTread
            // 
            this.chkBuyForTread.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkBuyForTread.Location = new System.Drawing.Point(1, 1);
            this.chkBuyForTread.Name = "chkBuyForTread";
            this.chkBuyForTread.Padding = new System.Windows.Forms.Padding(120, 0, 0, 0);
            this.chkBuyForTread.Size = new System.Drawing.Size(470, 26);
            this.chkBuyForTread.TabIndex = 1;
            this.chkBuyForTread.Text = "เป็นสินค้าซื้อมาเพื่อขายเท่านั้น";
            this.chkBuyForTread.UseVisualStyleBackColor = true;
            // 
            // ModelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(688, 345);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModelInfo";
            this.Text = "PRODUCT";
            this.Load += new System.EventHandler(this.ModelInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.PictureBox pic;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtProductId;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.ComboBox cbxProductGroup;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtProductDetail;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkAfterSaleService;
		private System.Windows.Forms.CheckBox chkOwnProduct;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.CheckBox chkSpecialProduct;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.CheckBox chkDiscontinue;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.CheckBox chkBuyForTread;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel14;
		private OMControls.OMFlatButton btnFindPic;
		private OMControls.OMFlatButton btnDeletePic;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Label label1;
	}
}