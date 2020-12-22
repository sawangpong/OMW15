namespace OMW15.Views.WarehouseView
{
	partial class FOCIssueParts
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
			this.lbTitle = new System.Windows.Forms.Label();
			this.pnlTopCommand = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnlButtomBar = new System.Windows.Forms.Panel();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.pnlSpareParts = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlItemOption = new System.Windows.Forms.Panel();
			this.rdoSelectItem = new System.Windows.Forms.RadioButton();
			this.rdoAllItems = new System.Windows.Forms.RadioButton();
			this.panel7 = new System.Windows.Forms.Panel();
			this.chlOrderCode = new System.Windows.Forms.CheckedListBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.lbCount = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.cbxYear = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.rpv = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnDisplayReport = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.pnlTopCommand.SuspendLayout();
			this.pnlLeft.SuspendLayout();
			this.pnlSpareParts.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlItemOption.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Controls.Add(this.pnlTopCommand);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel1.Size = new System.Drawing.Size(908, 50);
			this.panel1.TabIndex = 0;
			// 
			// lbTitle
			// 
			this.lbTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(2, 3);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(315, 44);
			this.lbTitle.TabIndex = 1;
			this.lbTitle.Text = "รายงานจ่ายอะไหล่โดยไม่คิดมูลค่า";
			this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlTopCommand
			// 
			this.pnlTopCommand.Controls.Add(this.btnClose);
			this.pnlTopCommand.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlTopCommand.Location = new System.Drawing.Point(798, 3);
			this.pnlTopCommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlTopCommand.Name = "pnlTopCommand";
			this.pnlTopCommand.Padding = new System.Windows.Forms.Padding(8);
			this.pnlTopCommand.Size = new System.Drawing.Size(108, 44);
			this.pnlTopCommand.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnClose.Location = new System.Drawing.Point(8, 8);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(92, 28);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// pnlButtomBar
			// 
			this.pnlButtomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlButtomBar.Location = new System.Drawing.Point(4, 579);
			this.pnlButtomBar.Name = "pnlButtomBar";
			this.pnlButtomBar.Padding = new System.Windows.Forms.Padding(2);
			this.pnlButtomBar.Size = new System.Drawing.Size(908, 25);
			this.pnlButtomBar.TabIndex = 5;
			// 
			// pnlLeft
			// 
			this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeft.Controls.Add(this.pnlSpareParts);
			this.pnlLeft.Controls.Add(this.panel7);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(4, 54);
			this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(5);
			this.pnlLeft.Size = new System.Drawing.Size(230, 525);
			this.pnlLeft.TabIndex = 6;
			// 
			// pnlSpareParts
			// 
			this.pnlSpareParts.Controls.Add(this.dgv);
			this.pnlSpareParts.Controls.Add(this.pnlItemOption);
			this.pnlSpareParts.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSpareParts.Location = new System.Drawing.Point(5, 256);
			this.pnlSpareParts.Name = "pnlSpareParts";
			this.pnlSpareParts.Padding = new System.Windows.Forms.Padding(1);
			this.pnlSpareParts.Size = new System.Drawing.Size(218, 262);
			this.pnlSpareParts.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(1, 31);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(216, 230);
			this.dgv.TabIndex = 3;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// pnlItemOption
			// 
			this.pnlItemOption.Controls.Add(this.rdoSelectItem);
			this.pnlItemOption.Controls.Add(this.rdoAllItems);
			this.pnlItemOption.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlItemOption.Location = new System.Drawing.Point(1, 1);
			this.pnlItemOption.Name = "pnlItemOption";
			this.pnlItemOption.Padding = new System.Windows.Forms.Padding(2);
			this.pnlItemOption.Size = new System.Drawing.Size(216, 30);
			this.pnlItemOption.TabIndex = 0;
			// 
			// rdoSelectItem
			// 
			this.rdoSelectItem.AutoSize = true;
			this.rdoSelectItem.Dock = System.Windows.Forms.DockStyle.Right;
			this.rdoSelectItem.Location = new System.Drawing.Point(121, 2);
			this.rdoSelectItem.Name = "rdoSelectItem";
			this.rdoSelectItem.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.rdoSelectItem.Size = new System.Drawing.Size(93, 26);
			this.rdoSelectItem.TabIndex = 1;
			this.rdoSelectItem.TabStop = true;
			this.rdoSelectItem.Tag = "ITEM";
			this.rdoSelectItem.Text = "เลือกรายการ";
			this.rdoSelectItem.UseVisualStyleBackColor = true;
			this.rdoSelectItem.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// rdoAllItems
			// 
			this.rdoAllItems.AutoSize = true;
			this.rdoAllItems.Dock = System.Windows.Forms.DockStyle.Left;
			this.rdoAllItems.Location = new System.Drawing.Point(2, 2);
			this.rdoAllItems.Name = "rdoAllItems";
			this.rdoAllItems.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
			this.rdoAllItems.Size = new System.Drawing.Size(90, 26);
			this.rdoAllItems.TabIndex = 0;
			this.rdoAllItems.TabStop = true;
			this.rdoAllItems.Tag = "ALL";
			this.rdoAllItems.Text = "เลือกทั้งหมด";
			this.rdoAllItems.UseVisualStyleBackColor = true;
			this.rdoAllItems.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.chlOrderCode);
			this.panel7.Controls.Add(this.panel9);
			this.panel7.Controls.Add(this.panel8);
			this.panel7.Controls.Add(this.panel5);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(5, 5);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(218, 251);
			this.panel7.TabIndex = 1;
			// 
			// chlOrderCode
			// 
			this.chlOrderCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chlOrderCode.FormattingEnabled = true;
			this.chlOrderCode.Location = new System.Drawing.Point(2, 62);
			this.chlOrderCode.Name = "chlOrderCode";
			this.chlOrderCode.Size = new System.Drawing.Size(214, 152);
			this.chlOrderCode.TabIndex = 8;
			this.chlOrderCode.SelectedIndexChanged += new System.EventHandler(this.chlOrderCode_SelectedIndexChanged);
			// 
			// panel9
			// 
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Controls.Add(this.btnLoadData);
			this.panel9.Controls.Add(this.lbCount);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel9.Location = new System.Drawing.Point(2, 214);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2);
			this.panel9.Size = new System.Drawing.Size(214, 35);
			this.panel9.TabIndex = 7;
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.Location = new System.Drawing.Point(2, 2);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(85, 29);
			this.btnLoadData.TabIndex = 2;
			this.btnLoadData.Text = "เรียกข้อมูล";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// lbCount
			// 
			this.lbCount.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCount.Location = new System.Drawing.Point(112, 2);
			this.lbCount.Name = "lbCount";
			this.lbCount.Size = new System.Drawing.Size(98, 29);
			this.lbCount.TabIndex = 1;
			this.lbCount.Text = "found : 0";
			this.lbCount.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.label2);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(2, 32);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(2);
			this.panel8.Size = new System.Drawing.Size(214, 30);
			this.panel8.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 26);
			this.label2.TabIndex = 0;
			this.label2.Text = "เลือกรหัสงาน :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.cbxYear);
			this.panel5.Controls.Add(this.label1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 2);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(2);
			this.panel5.Size = new System.Drawing.Size(214, 30);
			this.panel5.TabIndex = 4;
			// 
			// cbxYear
			// 
			this.cbxYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxYear.FormattingEnabled = true;
			this.cbxYear.Location = new System.Drawing.Point(63, 2);
			this.cbxYear.Name = "cbxYear";
			this.cbxYear.Size = new System.Drawing.Size(117, 25);
			this.cbxYear.TabIndex = 1;
			this.cbxYear.SelectionChangeCommitted += new System.EventHandler(this.cbxYear_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "ปีบัญชี :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(234, 54);
			this.splitter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 525);
			this.splitter1.TabIndex = 7;
			this.splitter1.TabStop = false;
			// 
			// pnlRight
			// 
			this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRight.Controls.Add(this.rpv);
			this.pnlRight.Controls.Add(this.panel2);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRight.Location = new System.Drawing.Point(240, 54);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
			this.pnlRight.Size = new System.Drawing.Size(672, 525);
			this.pnlRight.TabIndex = 8;
			// 
			// rpv
			// 
			this.rpv.ActiveViewIndex = -1;
			this.rpv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rpv.Cursor = System.Windows.Forms.Cursors.Default;
			this.rpv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rpv.Location = new System.Drawing.Point(5, 40);
			this.rpv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rpv.Name = "rpv";
			this.rpv.ShowGroupTreeButton = false;
			this.rpv.ShowParameterPanelButton = false;
			this.rpv.Size = new System.Drawing.Size(660, 478);
			this.rpv.TabIndex = 9;
			this.rpv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
			this.rpv.ToolPanelWidth = 233;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.btnDisplayReport);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(5, 5);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(660, 35);
			this.panel2.TabIndex = 8;
			// 
			// btnDisplayReport
			// 
			this.btnDisplayReport.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnDisplayReport.Location = new System.Drawing.Point(2, 2);
			this.btnDisplayReport.Name = "btnDisplayReport";
			this.btnDisplayReport.Size = new System.Drawing.Size(102, 29);
			this.btnDisplayReport.TabIndex = 2;
			this.btnDisplayReport.Text = "แสดงรายงาน";
			this.btnDisplayReport.UseVisualStyleBackColor = true;
			this.btnDisplayReport.Click += new System.EventHandler(this.btnDisplayReport_Click);
			// 
			// FOCIssueParts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(916, 608);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.pnlButtomBar);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FOCIssueParts";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "FOC Parts";
			this.Load += new System.EventHandler(this.FOCIssueParts_Load);
			this.panel1.ResumeLayout(false);
			this.pnlTopCommand.ResumeLayout(false);
			this.pnlLeft.ResumeLayout(false);
			this.pnlSpareParts.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlItemOption.ResumeLayout(false);
			this.pnlItemOption.PerformLayout();
			this.panel7.ResumeLayout(false);
			this.panel9.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlTopCommand;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Panel pnlButtomBar;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.CheckedListBox chlOrderCode;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.Label lbCount;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ComboBox cbxYear;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Panel pnlSpareParts;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel pnlItemOption;
		private System.Windows.Forms.RadioButton rdoSelectItem;
		private System.Windows.Forms.RadioButton rdoAllItems;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer rpv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDisplayReport;
	}
}