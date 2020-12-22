namespace OMW15.Views.ServiceView
{
	partial class ContractMC
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lbMode = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlDetail = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbDuration = new System.Windows.Forms.Label();
			this.lbFactor = new System.Windows.Forms.Label();
			this.txtPMQty = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lbPMTypeId = new System.Windows.Forms.Label();
			this.cbxPMType = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.txtSN = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtModel = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnMCList = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtCustomer = new System.Windows.Forms.TextBox();
			this.txtCustomerCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.txtHeaderMode = new System.Windows.Forms.TextBox();
			this.txtContractNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlDetail.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 226);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(700, 58);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSave.Location = new System.Drawing.Point(478, 10);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(106, 38);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Location = new System.Drawing.Point(584, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(106, 38);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "C&ancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.pnlHeader.Controls.Add(this.lbMode);
			this.pnlHeader.Controls.Add(this.label1);
			this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlHeader.Location = new System.Drawing.Point(0, 0);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Padding = new System.Windows.Forms.Padding(1);
			this.pnlHeader.Size = new System.Drawing.Size(700, 43);
			this.pnlHeader.TabIndex = 1;
			// 
			// lbMode
			// 
			this.lbMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbMode.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMode.ForeColor = System.Drawing.Color.Yellow;
			this.lbMode.Location = new System.Drawing.Point(584, 1);
			this.lbMode.Name = "lbMode";
			this.lbMode.Size = new System.Drawing.Size(115, 41);
			this.lbMode.TabIndex = 1;
			this.lbMode.Text = "Mode";
			this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(1, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(383, 41);
			this.label1.TabIndex = 0;
			this.label1.Text = "เครื่องจักรในสัญญาบริการ (Contract Machine)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlDetail
			// 
			this.pnlDetail.Controls.Add(this.panel8);
			this.pnlDetail.Controls.Add(this.panel7);
			this.pnlDetail.Controls.Add(this.panel5);
			this.pnlDetail.Controls.Add(this.panel4);
			this.pnlDetail.Controls.Add(this.panel3);
			this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetail.Location = new System.Drawing.Point(0, 43);
			this.pnlDetail.Name = "pnlDetail";
			this.pnlDetail.Padding = new System.Windows.Forms.Padding(10);
			this.pnlDetail.Size = new System.Drawing.Size(700, 183);
			this.pnlDetail.TabIndex = 2;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lbDuration);
			this.panel8.Controls.Add(this.lbFactor);
			this.panel8.Controls.Add(this.txtPMQty);
			this.panel8.Controls.Add(this.label7);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(10, 129);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(1);
			this.panel8.Size = new System.Drawing.Size(680, 28);
			this.panel8.TabIndex = 5;
			// 
			// lbDuration
			// 
			this.lbDuration.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbDuration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbDuration.Location = new System.Drawing.Point(617, 1);
			this.lbDuration.Name = "lbDuration";
			this.lbDuration.Size = new System.Drawing.Size(31, 26);
			this.lbDuration.TabIndex = 9;
			this.lbDuration.Text = "0";
			this.lbDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbFactor
			// 
			this.lbFactor.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbFactor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFactor.Location = new System.Drawing.Point(648, 1);
			this.lbFactor.Name = "lbFactor";
			this.lbFactor.Size = new System.Drawing.Size(31, 26);
			this.lbFactor.TabIndex = 8;
			this.lbFactor.Text = "0";
			this.lbFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtPMQty
			// 
			this.txtPMQty.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtPMQty.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPMQty.Location = new System.Drawing.Point(115, 1);
			this.txtPMQty.MaxLength = 10;
			this.txtPMQty.Name = "txtPMQty";
			this.txtPMQty.ReadOnly = true;
			this.txtPMQty.Size = new System.Drawing.Size(85, 25);
			this.txtPMQty.TabIndex = 7;
			this.txtPMQty.TextChanged += new System.EventHandler(this.txtPMQty_TextChanged);
			// 
			// label7
			// 
			this.label7.Dock = System.Windows.Forms.DockStyle.Left;
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(114, 26);
			this.label7.TabIndex = 6;
			this.label7.Text = "จำนวนครั้งที่บริการ :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.lbPMTypeId);
			this.panel7.Controls.Add(this.cbxPMType);
			this.panel7.Controls.Add(this.label6);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(10, 101);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(1);
			this.panel7.Size = new System.Drawing.Size(680, 28);
			this.panel7.TabIndex = 4;
			// 
			// lbPMTypeId
			// 
			this.lbPMTypeId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbPMTypeId.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPMTypeId.Location = new System.Drawing.Point(648, 1);
			this.lbPMTypeId.Name = "lbPMTypeId";
			this.lbPMTypeId.Size = new System.Drawing.Size(31, 26);
			this.lbPMTypeId.TabIndex = 5;
			this.lbPMTypeId.Text = "0";
			this.lbPMTypeId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbxPMType
			// 
			this.cbxPMType.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxPMType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPMType.FormattingEnabled = true;
			this.cbxPMType.Location = new System.Drawing.Point(115, 1);
			this.cbxPMType.Name = "cbxPMType";
			this.cbxPMType.Size = new System.Drawing.Size(496, 25);
			this.cbxPMType.TabIndex = 4;
			this.cbxPMType.SelectedValueChanged += new System.EventHandler(this.cbxPMType_SelectedValueChanged);
			// 
			// label6
			// 
			this.label6.Dock = System.Windows.Forms.DockStyle.Left;
			this.label6.Location = new System.Drawing.Point(1, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(114, 26);
			this.label6.TabIndex = 3;
			this.label6.Text = "ประเภทสัญญา :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.txtSN);
			this.panel5.Controls.Add(this.label5);
			this.panel5.Controls.Add(this.txtModel);
			this.panel5.Controls.Add(this.label4);
			this.panel5.Controls.Add(this.btnMCList);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(10, 66);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(680, 35);
			this.panel5.TabIndex = 2;
			// 
			// txtSN
			// 
			this.txtSN.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSN.Location = new System.Drawing.Point(437, 5);
			this.txtSN.MaxLength = 25;
			this.txtSN.Name = "txtSN";
			this.txtSN.ReadOnly = true;
			this.txtSN.Size = new System.Drawing.Size(174, 25);
			this.txtSN.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Dock = System.Windows.Forms.DockStyle.Left;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(374, 5);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 25);
			this.label5.TabIndex = 5;
			this.label5.Text = "SN :";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtModel
			// 
			this.txtModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtModel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtModel.Location = new System.Drawing.Point(199, 5);
			this.txtModel.MaxLength = 25;
			this.txtModel.Name = "txtModel";
			this.txtModel.ReadOnly = true;
			this.txtModel.Size = new System.Drawing.Size(175, 25);
			this.txtModel.TabIndex = 4;
			this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(130, 5);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 25);
			this.label4.TabIndex = 3;
			this.label4.Text = "Model :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnMCList
			// 
			this.btnMCList.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnMCList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMCList.Location = new System.Drawing.Point(5, 5);
			this.btnMCList.Name = "btnMCList";
			this.btnMCList.Size = new System.Drawing.Size(125, 25);
			this.btnMCList.TabIndex = 0;
			this.btnMCList.Text = "List Machine  :::>";
			this.btnMCList.UseVisualStyleBackColor = true;
			this.btnMCList.Click += new System.EventHandler(this.btnMCList_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.txtCustomer);
			this.panel4.Controls.Add(this.txtCustomerCode);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(10, 38);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(1);
			this.panel4.Size = new System.Drawing.Size(680, 28);
			this.panel4.TabIndex = 1;
			// 
			// txtCustomer
			// 
			this.txtCustomer.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomer.Location = new System.Drawing.Point(200, 1);
			this.txtCustomer.MaxLength = 150;
			this.txtCustomer.Name = "txtCustomer";
			this.txtCustomer.ReadOnly = true;
			this.txtCustomer.Size = new System.Drawing.Size(460, 25);
			this.txtCustomer.TabIndex = 3;
			// 
			// txtCustomerCode
			// 
			this.txtCustomerCode.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtCustomerCode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCustomerCode.Location = new System.Drawing.Point(115, 1);
			this.txtCustomerCode.MaxLength = 10;
			this.txtCustomerCode.Name = "txtCustomerCode";
			this.txtCustomerCode.ReadOnly = true;
			this.txtCustomerCode.Size = new System.Drawing.Size(85, 25);
			this.txtCustomerCode.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(1, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 26);
			this.label3.TabIndex = 1;
			this.label3.Text = "ลูกค้า :";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.txtHeaderMode);
			this.panel3.Controls.Add(this.txtContractNo);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(10, 10);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(1);
			this.panel3.Size = new System.Drawing.Size(680, 28);
			this.panel3.TabIndex = 0;
			// 
			// txtHeaderMode
			// 
			this.txtHeaderMode.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtHeaderMode.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHeaderMode.Location = new System.Drawing.Point(644, 1);
			this.txtHeaderMode.MaxLength = 1;
			this.txtHeaderMode.Name = "txtHeaderMode";
			this.txtHeaderMode.ReadOnly = true;
			this.txtHeaderMode.Size = new System.Drawing.Size(35, 25);
			this.txtHeaderMode.TabIndex = 3;
			this.txtHeaderMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtContractNo
			// 
			this.txtContractNo.Dock = System.Windows.Forms.DockStyle.Left;
			this.txtContractNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtContractNo.Location = new System.Drawing.Point(115, 1);
			this.txtContractNo.MaxLength = 15;
			this.txtContractNo.Name = "txtContractNo";
			this.txtContractNo.ReadOnly = true;
			this.txtContractNo.Size = new System.Drawing.Size(121, 25);
			this.txtContractNo.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "เลขที่ศัญญา :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ContractMC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(700, 284);
			this.Controls.Add(this.pnlDetail);
			this.Controls.Add(this.pnlHeader);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ContractMC";
			this.Text = "CONTRACT MACHINE";
			this.Load += new System.EventHandler(this.PMMC_Load);
			this.panel1.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlDetail.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Label lbMode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlDetail;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.TextBox txtCustomer;
		private System.Windows.Forms.TextBox txtCustomerCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtContractNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPMQty;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbxPMType;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnMCList;
		private System.Windows.Forms.Label lbPMTypeId;
		private System.Windows.Forms.Label lbFactor;
		private System.Windows.Forms.TextBox txtSN;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtModel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbDuration;
		private System.Windows.Forms.TextBox txtHeaderMode;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}