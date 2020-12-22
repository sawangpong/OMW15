namespace OMW15.Views.Productions
{
	partial class ERPPDList
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ERPPDList));
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.lbCount = new System.Windows.Forms.Label();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbJobType = new System.Windows.Forms.Label();
			this.rdoProject = new System.Windows.Forms.RadioButton();
			this.rdoTransform = new System.Windows.Forms.RadioButton();
			this.lgHeader = new System.Windows.Forms.Label();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.dgvProductionCode = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlTopRight = new System.Windows.Forms.Panel();
			this.btnFindData = new System.Windows.Forms.Button();
			this.cbxYearRequest = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRequestFilter = new System.Windows.Forms.TextBox();
			this.btnSearchRequest = new OMControls.OMFlatButton();
			this.pnlCommand.SuspendLayout();
			this.pnlTitle.SuspendLayout();
			this.panel2.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProductionCode)).BeginInit();
			this.pnlRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlTopRight.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.lbCount);
			this.pnlCommand.Controls.Add(this.btnSelect);
			this.pnlCommand.Controls.Add(this.btnCancel);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlCommand.Location = new System.Drawing.Point(4, 498);
			this.pnlCommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(5);
			this.pnlCommand.Size = new System.Drawing.Size(993, 51);
			this.pnlCommand.TabIndex = 0;
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbCount.Location = new System.Drawing.Point(5, 5);
			this.lbCount.Name = "lbCount";
			this.lbCount.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.lbCount.Size = new System.Drawing.Size(218, 41);
			this.lbCount.TabIndex = 3;
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// btnSelect
			// 
			this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSelect.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSelect.Location = new System.Drawing.Point(762, 5);
			this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(113, 41);
			this.btnSelect.TabIndex = 2;
			this.btnSelect.Text = "&Select";
			this.btnSelect.UseVisualStyleBackColor = true;
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(875, 5);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(113, 41);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// pnlTitle
			// 
			this.pnlTitle.Controls.Add(this.panel2);
			this.pnlTitle.Controls.Add(this.lgHeader);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(4, 4);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Padding = new System.Windows.Forms.Padding(3);
			this.pnlTitle.Size = new System.Drawing.Size(993, 46);
			this.pnlTitle.TabIndex = 10;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.lbJobType);
			this.panel2.Controls.Add(this.rdoProject);
			this.panel2.Controls.Add(this.rdoTransform);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(97, 3);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10, 3, 3, 3);
			this.panel2.Size = new System.Drawing.Size(893, 40);
			this.panel2.TabIndex = 7;
			// 
			// lbJobType
			// 
			this.lbJobType.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbJobType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbJobType.Location = new System.Drawing.Point(796, 3);
			this.lbJobType.Name = "lbJobType";
			this.lbJobType.Size = new System.Drawing.Size(94, 34);
			this.lbJobType.TabIndex = 2;
			this.lbJobType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// rdoProject
			// 
			this.rdoProject.Checked = true;
			this.rdoProject.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoProject.Location = new System.Drawing.Point(104, 3);
			this.rdoProject.Name = "rdoProject";
			this.rdoProject.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.rdoProject.Size = new System.Drawing.Size(224, 34);
			this.rdoProject.TabIndex = 1;
			this.rdoProject.TabStop = true;
			this.rdoProject.Tag = "PJ";
			this.rdoProject.Text = "ต้นแบบ หรือ โครงการ (project)";
			this.rdoProject.UseVisualStyleBackColor = true;
			this.rdoProject.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoTransform
			// 
			this.rdoTransform.AutoSize = true;
			this.rdoTransform.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoTransform.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoTransform.Location = new System.Drawing.Point(10, 3);
			this.rdoTransform.Name = "rdoTransform";
			this.rdoTransform.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.rdoTransform.Size = new System.Drawing.Size(94, 34);
			this.rdoTransform.TabIndex = 0;
			this.rdoTransform.Tag = "RM";
			this.rdoTransform.Text = "ใบขอแปร ";
			this.rdoTransform.UseVisualStyleBackColor = true;
			this.rdoTransform.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// lgHeader
			// 
			this.lgHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lgHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lgHeader.Location = new System.Drawing.Point(3, 3);
			this.lgHeader.Name = "lgHeader";
			this.lgHeader.Size = new System.Drawing.Size(94, 40);
			this.lgHeader.TabIndex = 0;
			this.lgHeader.Text = "ประเภทงาน :";
			this.lgHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.dgvProductionCode);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(4, 50);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(2);
			this.pnlLeft.Size = new System.Drawing.Size(315, 448);
			this.pnlLeft.TabIndex = 11;
			// 
			// dgvProductionCode
			// 
			this.dgvProductionCode.BackgroundColor = System.Drawing.Color.White;
			this.dgvProductionCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProductionCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvProductionCode.Location = new System.Drawing.Point(2, 2);
			this.dgvProductionCode.Name = "dgvProductionCode";
			this.dgvProductionCode.Size = new System.Drawing.Size(309, 442);
			this.dgvProductionCode.TabIndex = 8;
			this.dgvProductionCode.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductionCode_CellEnter);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(319, 50);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 448);
			this.splitter1.TabIndex = 13;
			this.splitter1.TabStop = false;
			// 
			// pnlRight
			// 
			this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRight.Controls.Add(this.dgv);
			this.pnlRight.Controls.Add(this.pnlTopRight);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRight.Location = new System.Drawing.Point(325, 50);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(2);
			this.pnlRight.Size = new System.Drawing.Size(672, 448);
			this.pnlRight.TabIndex = 14;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 36);
			this.dgv.MultiSelect = false;
			this.dgv.Name = "dgv";
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Yellow;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MidnightBlue;
			this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Yellow;
			this.dgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgv.Size = new System.Drawing.Size(666, 408);
			this.dgv.TabIndex = 10;
			this.dgv.VirtualMode = true;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
			// 
			// pnlTopRight
			// 
			this.pnlTopRight.Controls.Add(this.btnFindData);
			this.pnlTopRight.Controls.Add(this.cbxYearRequest);
			this.pnlTopRight.Controls.Add(this.label4);
			this.pnlTopRight.Controls.Add(this.label2);
			this.pnlTopRight.Controls.Add(this.txtRequestFilter);
			this.pnlTopRight.Controls.Add(this.btnSearchRequest);
			this.pnlTopRight.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTopRight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pnlTopRight.Location = new System.Drawing.Point(2, 2);
			this.pnlTopRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlTopRight.Name = "pnlTopRight";
			this.pnlTopRight.Padding = new System.Windows.Forms.Padding(2, 2, 10, 2);
			this.pnlTopRight.Size = new System.Drawing.Size(666, 34);
			this.pnlTopRight.TabIndex = 7;
			// 
			// btnFindData
			// 
			this.btnFindData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnFindData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindData.Location = new System.Drawing.Point(126, 2);
			this.btnFindData.Name = "btnFindData";
			this.btnFindData.Size = new System.Drawing.Size(106, 30);
			this.btnFindData.TabIndex = 23;
			this.btnFindData.Text = "เรียกข้อมูล";
			this.btnFindData.UseVisualStyleBackColor = true;
			this.btnFindData.Visible = false;
			this.btnFindData.Click += new System.EventHandler(this.btnFindData_Click);
			// 
			// cbxYearRequest
			// 
			this.cbxYearRequest.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYearRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYearRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbxYearRequest.FormattingEnabled = true;
			this.cbxYearRequest.Location = new System.Drawing.Point(37, 2);
			this.cbxYearRequest.Name = "cbxYearRequest";
			this.cbxYearRequest.Size = new System.Drawing.Size(89, 29);
			this.cbxYearRequest.TabIndex = 21;
			this.cbxYearRequest.Visible = false;
			this.cbxYearRequest.SelectedIndexChanged += new System.EventHandler(this.cbxYearRequest_SelectedIndexChanged);
			this.cbxYearRequest.SelectionChangeCommitted += new System.EventHandler(this.cbxYearRequest_SelectionChangeCommitted);
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Left;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(2, 2);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 30);
			this.label4.TabIndex = 20;
			this.label4.Text = "ปี :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.label4.Visible = false;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Right;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(293, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(171, 30);
			this.label2.TabIndex = 19;
			this.label2.Text = "ค้นหาเลขที่ใบขอแปร :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRequestFilter
			// 
			this.txtRequestFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRequestFilter.Dock = System.Windows.Forms.DockStyle.Right;
			this.txtRequestFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRequestFilter.Location = new System.Drawing.Point(464, 2);
			this.txtRequestFilter.MaxLength = 15;
			this.txtRequestFilter.Name = "txtRequestFilter";
			this.txtRequestFilter.Size = new System.Drawing.Size(162, 29);
			this.txtRequestFilter.TabIndex = 18;
			this.txtRequestFilter.TextChanged += new System.EventHandler(this.txtRequestFilter_TextChanged);
			this.txtRequestFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRequestFilter_KeyPress);
			// 
			// btnSearchRequest
			// 
			this.btnSearchRequest.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnSearchRequest.FlatAppearance.BorderSize = 0;
			this.btnSearchRequest.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchRequest.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearchRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchRequest.Image")));
			this.btnSearchRequest.Location = new System.Drawing.Point(626, 2);
			this.btnSearchRequest.Name = "btnSearchRequest";
			this.btnSearchRequest.Size = new System.Drawing.Size(30, 30);
			this.btnSearchRequest.TabIndex = 17;
			this.btnSearchRequest.UseVisualStyleBackColor = true;
			this.btnSearchRequest.Click += new System.EventHandler(this.btnSearchRequest_Click);
			// 
			// ERPPDList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1001, 553);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlTitle);
			this.Controls.Add(this.pnlCommand);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ERPPDList";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "ERP REF. DOCUMENTS";
			this.Load += new System.EventHandler(this.ERPPDList_Load);
			this.pnlCommand.ResumeLayout(false);
			this.pnlTitle.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvProductionCode)).EndInit();
			this.pnlRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlTopRight.ResumeLayout(false);
			this.pnlTopRight.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Label lgHeader;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlTopRight;
		private System.Windows.Forms.ComboBox cbxYearRequest;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRequestFilter;
		private OMControls.OMFlatButton btnSearchRequest;
		private System.Windows.Forms.Button btnFindData;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton rdoProject;
		private System.Windows.Forms.RadioButton rdoTransform;
		private System.Windows.Forms.Label lbJobType;
		private System.Windows.Forms.DataGridView dgvProductionCode;
	}
}