namespace OMW15.Views.ServiceView
{
	partial class MCTransfer
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCTransfer));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtSN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtLastOwner = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel15 = new System.Windows.Forms.Panel();
			this.rdoUsedMC = new System.Windows.Forms.RadioButton();
			this.rdoNewMC = new System.Windows.Forms.RadioButton();
			this.label15 = new System.Windows.Forms.Label();
			this.panel14 = new System.Windows.Forms.Panel();
			this.btnWarranty = new OMControls.OMFlatButton();
			this.txtWarranty = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.panel13 = new System.Windows.Forms.Panel();
			this.txtQty = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.dtpTransferDate = new System.Windows.Forms.DateTimePicker();
			this.lbTransferDate = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnNewCustomer = new OMControls.OMFlatButton();
			this.txtNewOwner = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(10, 341);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(601, 40);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(373, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(112, 32);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save Info";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(485, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(112, 32);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Controls.Add(this.panel3);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(10, 10);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(601, 113);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "เจ้าของเดิม";
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtSN);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(3, 77);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(595, 28);
			this.panel4.TabIndex = 7;
			// 
			// txtSN
			// 
			this.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtSN.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSN.Enabled = false;
			this.txtSN.Location = new System.Drawing.Point(108, 1);
			this.txtSN.MaxLength = 50;
			this.txtSN.Name = "txtSN";
			this.txtSN.ReadOnly = true;
			this.txtSN.Size = new System.Drawing.Size(190, 25);
			this.txtSN.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Location = new System.Drawing.Point(1, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 26);
			this.label4.TabIndex = 1;
			this.label4.Text = "หมายเลข :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtModel);
			this.panel3.Controls.Add(this.label3);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(3, 49);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(595, 28);
			this.panel3.TabIndex = 6;
			// 
			// txtModel
			// 
			this.txtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtModel.Location = new System.Drawing.Point(108, 1);
			this.txtModel.MaxLength = 50;
			this.txtModel.Name = "txtModel";
			this.txtModel.ReadOnly = true;
			this.txtModel.Size = new System.Drawing.Size(190, 25);
			this.txtModel.TabIndex = 3;
			this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "เครื่องจักร :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtLastOwner);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(3, 21);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(1);
			this.panel2.Size = new System.Drawing.Size(595, 28);
			this.panel2.TabIndex = 5;
			// 
			// txtLastOwner
			// 
			this.txtLastOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtLastOwner.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtLastOwner.Location = new System.Drawing.Point(108, 1);
			this.txtLastOwner.MaxLength = 150;
			this.txtLastOwner.Name = "txtLastOwner";
			this.txtLastOwner.ReadOnly = true;
			this.txtLastOwner.Size = new System.Drawing.Size(447, 25);
			this.txtLastOwner.TabIndex = 1;
			this.txtLastOwner.TextChanged += new System.EventHandler(this.txtLastOwner_TextChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "ชื่อ :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel6);
			this.groupBox2.Controls.Add(this.panel15);
			this.groupBox2.Controls.Add(this.panel14);
			this.groupBox2.Controls.Add(this.panel13);
			this.groupBox2.Controls.Add(this.panel10);
			this.groupBox2.Controls.Add(this.panel5);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(10, 123);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(601, 208);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "เจ้าของใหม่";
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.txtRemark);
			this.panel6.Controls.Add(this.label5);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(3, 161);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(2);
			this.panel6.Size = new System.Drawing.Size(595, 28);
			this.panel6.TabIndex = 15;
			// 
			// txtRemark
			// 
			this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemark.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtRemark.Location = new System.Drawing.Point(108, 2);
			this.txtRemark.MaxLength = 200;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(447, 25);
			this.txtRemark.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Location = new System.Drawing.Point(2, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(106, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "หมายเหตุ:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel15
			// 
			this.panel15.Controls.Add(this.rdoUsedMC);
			this.panel15.Controls.Add(this.rdoNewMC);
			this.panel15.Controls.Add(this.label15);
			this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel15.Location = new System.Drawing.Point(3, 133);
			this.panel15.Name = "panel15";
			this.panel15.Padding = new System.Windows.Forms.Padding(1);
			this.panel15.Size = new System.Drawing.Size(595, 28);
			this.panel15.TabIndex = 14;
			// 
			// rdoUsedMC
			// 
			this.rdoUsedMC.AutoSize = true;
			this.rdoUsedMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoUsedMC.Location = new System.Drawing.Point(225, 1);
			this.rdoUsedMC.Name = "rdoUsedMC";
			this.rdoUsedMC.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
			this.rdoUsedMC.Size = new System.Drawing.Size(129, 26);
			this.rdoUsedMC.TabIndex = 3;
			this.rdoUsedMC.TabStop = true;
			this.rdoUsedMC.Tag = "USED_MC";
			this.rdoUsedMC.Text = "เครื่องจักรใช้แล้ว";
			this.rdoUsedMC.UseVisualStyleBackColor = true;
			// 
			// rdoNewMC
			// 
			this.rdoNewMC.AutoSize = true;
			this.rdoNewMC.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoNewMC.Location = new System.Drawing.Point(108, 1);
			this.rdoNewMC.Name = "rdoNewMC";
			this.rdoNewMC.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
			this.rdoNewMC.Size = new System.Drawing.Size(117, 26);
			this.rdoNewMC.TabIndex = 2;
			this.rdoNewMC.TabStop = true;
			this.rdoNewMC.Tag = "NEW_MC";
			this.rdoNewMC.Text = "เครื่องจักรใหม่";
			this.rdoNewMC.UseVisualStyleBackColor = true;
			// 
			// label15
			// 
			this.label15.Dock = System.Windows.Forms.DockStyle.Left;
			this.label15.Location = new System.Drawing.Point(1, 1);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(107, 26);
			this.label15.TabIndex = 1;
			this.label15.Text = "สถานะเครื่องจักร :";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel14
			// 
			this.panel14.Controls.Add(this.btnWarranty);
			this.panel14.Controls.Add(this.txtWarranty);
			this.panel14.Controls.Add(this.label14);
			this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel14.Location = new System.Drawing.Point(3, 105);
			this.panel14.Name = "panel14";
			this.panel14.Padding = new System.Windows.Forms.Padding(1);
			this.panel14.Size = new System.Drawing.Size(595, 28);
			this.panel14.TabIndex = 13;
			// 
			// btnWarranty
			// 
			this.btnWarranty.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnWarranty.FlatAppearance.BorderSize = 0;
			this.btnWarranty.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnWarranty.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnWarranty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWarranty.Image = ((System.Drawing.Image)(resources.GetObject("btnWarranty.Image")));
			this.btnWarranty.Location = new System.Drawing.Point(555, 1);
			this.btnWarranty.Name = "btnWarranty";
			this.btnWarranty.Size = new System.Drawing.Size(26, 26);
			this.btnWarranty.TabIndex = 3;
			this.btnWarranty.UseVisualStyleBackColor = true;
			this.btnWarranty.Click += new System.EventHandler(this.btnWarranty_Click);
			// 
			// txtWarranty
			// 
			this.txtWarranty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtWarranty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtWarranty.Location = new System.Drawing.Point(108, 1);
			this.txtWarranty.MaxLength = 150;
			this.txtWarranty.Name = "txtWarranty";
			this.txtWarranty.Size = new System.Drawing.Size(447, 25);
			this.txtWarranty.TabIndex = 2;
			// 
			// label14
			// 
			this.label14.Dock = System.Windows.Forms.DockStyle.Left;
			this.label14.Location = new System.Drawing.Point(1, 1);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(107, 26);
			this.label14.TabIndex = 1;
			this.label14.Text = "เงื่อนไขรับประกัน :";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel13
			// 
			this.panel13.Controls.Add(this.txtQty);
			this.panel13.Controls.Add(this.label13);
			this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel13.Location = new System.Drawing.Point(3, 77);
			this.panel13.Name = "panel13";
			this.panel13.Padding = new System.Windows.Forms.Padding(1);
			this.panel13.Size = new System.Drawing.Size(595, 28);
			this.panel13.TabIndex = 12;
			// 
			// txtQty
			// 
			this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtQty.Location = new System.Drawing.Point(108, 1);
			this.txtQty.MaxLength = 3;
			this.txtQty.Name = "txtQty";
			this.txtQty.ReadOnly = true;
			this.txtQty.Size = new System.Drawing.Size(45, 25);
			this.txtQty.TabIndex = 5;
			this.txtQty.Text = "1";
			// 
			// label13
			// 
			this.label13.Dock = System.Windows.Forms.DockStyle.Left;
			this.label13.Location = new System.Drawing.Point(1, 1);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(107, 26);
			this.label13.TabIndex = 1;
			this.label13.Text = "จำนวน :";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.dtpTransferDate);
			this.panel10.Controls.Add(this.lbTransferDate);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(3, 49);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(1);
			this.panel10.Size = new System.Drawing.Size(595, 28);
			this.panel10.TabIndex = 11;
			// 
			// dtpTransferDate
			// 
			this.dtpTransferDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.dtpTransferDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpTransferDate.Location = new System.Drawing.Point(108, 1);
			this.dtpTransferDate.Name = "dtpTransferDate";
			this.dtpTransferDate.Size = new System.Drawing.Size(126, 25);
			this.dtpTransferDate.TabIndex = 6;
			// 
			// lbTransferDate
			// 
			this.lbTransferDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTransferDate.Location = new System.Drawing.Point(1, 1);
			this.lbTransferDate.Name = "lbTransferDate";
			this.lbTransferDate.Size = new System.Drawing.Size(107, 26);
			this.lbTransferDate.TabIndex = 5;
			this.lbTransferDate.Text = "วันที่โอน :";
			this.lbTransferDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnNewCustomer);
			this.panel5.Controls.Add(this.txtNewOwner);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(3, 21);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(1);
			this.panel5.Size = new System.Drawing.Size(595, 28);
			this.panel5.TabIndex = 6;
			// 
			// btnNewCustomer
			// 
			this.btnNewCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnNewCustomer.FlatAppearance.BorderSize = 0;
			this.btnNewCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnNewCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnNewCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCustomer.Image")));
			this.btnNewCustomer.Location = new System.Drawing.Point(555, 1);
			this.btnNewCustomer.Name = "btnNewCustomer";
			this.btnNewCustomer.Size = new System.Drawing.Size(26, 26);
			this.btnNewCustomer.TabIndex = 2;
			this.btnNewCustomer.UseVisualStyleBackColor = true;
			this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
			// 
			// txtNewOwner
			// 
			this.txtNewOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtNewOwner.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtNewOwner.Location = new System.Drawing.Point(108, 1);
			this.txtNewOwner.MaxLength = 150;
			this.txtNewOwner.Name = "txtNewOwner";
			this.txtNewOwner.ReadOnly = true;
			this.txtNewOwner.Size = new System.Drawing.Size(447, 25);
			this.txtNewOwner.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ชื่อ :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MCTransfer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(621, 391);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MCTransfer";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "MACHINE TRANSFER";
			this.Load += new System.EventHandler(this.MCTransfer_Load);
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.panel15.ResumeLayout(false);
			this.panel15.PerformLayout();
			this.panel14.ResumeLayout(false);
			this.panel14.PerformLayout();
			this.panel13.ResumeLayout(false);
			this.panel13.PerformLayout();
			this.panel10.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox txtSN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtLastOwner;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private OMControls.OMFlatButton btnNewCustomer;
		private System.Windows.Forms.TextBox txtNewOwner;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.DateTimePicker dtpTransferDate;
		private System.Windows.Forms.Label lbTransferDate;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.RadioButton rdoUsedMC;
		private System.Windows.Forms.RadioButton rdoNewMC;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Panel panel14;
		private OMControls.OMFlatButton btnWarranty;
		private System.Windows.Forms.TextBox txtWarranty;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.TextBox txtQty;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label label5;
	}
}