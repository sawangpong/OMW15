namespace OMW15.Views.CastingView
{
    partial class CastingWorkPerformance
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
			this.pnlTop = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlRight = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlContentRight = new System.Windows.Forms.Panel();
			this.dgvDayContents = new System.Windows.Forms.DataGridView();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.dgvContents = new System.Windows.Forms.DataGridView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lbMenuId = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.cbxMonth = new System.Windows.Forms.ComboBox();
			this.lbMonth = new System.Windows.Forms.Label();
			this.cbxWorkYear = new System.Windows.Forms.ComboBox();
			this.lbYear = new System.Windows.Forms.Label();
			this.cbxTopic = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbWorkerId = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.dgvJobs = new System.Windows.Forms.DataGridView();
			this.pnlTop.SuspendLayout();
			this.pnlRight.SuspendLayout();
			this.pnlContentRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvDayContents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvContents)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlTop
			// 
			this.pnlTop.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pnlTop.Controls.Add(this.btnClose);
			this.pnlTop.Controls.Add(this.label1);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Padding = new System.Windows.Forms.Padding(2);
			this.pnlTop.Size = new System.Drawing.Size(946, 44);
			this.pnlTop.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(854, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 40);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(275, 40);
			this.label1.TabIndex = 0;
			this.label1.Text = "Casting Performance";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlRight
			// 
			this.pnlRight.Controls.Add(this.dgvJobs);
			this.pnlRight.Controls.Add(this.panel1);
			this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlRight.Location = new System.Drawing.Point(679, 44);
			this.pnlRight.Name = "pnlRight";
			this.pnlRight.Padding = new System.Windows.Forms.Padding(2);
			this.pnlRight.Size = new System.Drawing.Size(267, 517);
			this.pnlRight.TabIndex = 5;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(673, 44);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 517);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// pnlContentRight
			// 
			this.pnlContentRight.Controls.Add(this.dgvDayContents);
			this.pnlContentRight.Controls.Add(this.splitter2);
			this.pnlContentRight.Controls.Add(this.dgvContents);
			this.pnlContentRight.Controls.Add(this.panel4);
			this.pnlContentRight.Controls.Add(this.panel3);
			this.pnlContentRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlContentRight.Location = new System.Drawing.Point(0, 44);
			this.pnlContentRight.Name = "pnlContentRight";
			this.pnlContentRight.Padding = new System.Windows.Forms.Padding(2);
			this.pnlContentRight.Size = new System.Drawing.Size(673, 517);
			this.pnlContentRight.TabIndex = 7;
			// 
			// dgvDayContents
			// 
			this.dgvDayContents.BackgroundColor = System.Drawing.Color.White;
			this.dgvDayContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDayContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDayContents.Location = new System.Drawing.Point(2, 315);
			this.dgvDayContents.Name = "dgvDayContents";
			this.dgvDayContents.Size = new System.Drawing.Size(669, 171);
			this.dgvDayContents.TabIndex = 6;
			this.dgvDayContents.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDayContents_CellEnter);
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(2, 309);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(669, 6);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			// 
			// dgvContents
			// 
			this.dgvContents.BackgroundColor = System.Drawing.Color.White;
			this.dgvContents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContents.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgvContents.Location = new System.Drawing.Point(2, 41);
			this.dgvContents.Name = "dgvContents";
			this.dgvContents.Size = new System.Drawing.Size(669, 268);
			this.dgvContents.TabIndex = 4;
			this.dgvContents.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContents_CellEnter);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.lbWorkerId);
			this.panel4.Controls.Add(this.lbMenuId);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel4.Location = new System.Drawing.Point(2, 486);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(2);
			this.panel4.Size = new System.Drawing.Size(669, 29);
			this.panel4.TabIndex = 3;
			// 
			// lbMenuId
			// 
			this.lbMenuId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMenuId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMenuId.Location = new System.Drawing.Point(2, 2);
			this.lbMenuId.Name = "lbMenuId";
			this.lbMenuId.Size = new System.Drawing.Size(54, 25);
			this.lbMenuId.TabIndex = 9;
			this.lbMenuId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel6);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(669, 39);
			this.panel3.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.btnLoadData);
			this.panel6.Controls.Add(this.cbxMonth);
			this.panel6.Controls.Add(this.lbMonth);
			this.panel6.Controls.Add(this.cbxWorkYear);
			this.panel6.Controls.Add(this.lbYear);
			this.panel6.Controls.Add(this.cbxTopic);
			this.panel6.Controls.Add(this.label2);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(2, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(4);
			this.panel6.Size = new System.Drawing.Size(665, 35);
			this.panel6.TabIndex = 0;
			// 
			// btnLoadData
			// 
			this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnLoadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnLoadData.Location = new System.Drawing.Point(541, 4);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(95, 25);
			this.btnLoadData.TabIndex = 14;
			this.btnLoadData.Text = "&Load data";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// cbxMonth
			// 
			this.cbxMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMonth.FormattingEnabled = true;
			this.cbxMonth.Location = new System.Drawing.Point(454, 4);
			this.cbxMonth.Name = "cbxMonth";
			this.cbxMonth.Size = new System.Drawing.Size(87, 25);
			this.cbxMonth.TabIndex = 13;
			this.cbxMonth.SelectionChangeCommitted += new System.EventHandler(this.cbxMonth_SelectionChangeCommitted);
			// 
			// lbMonth
			// 
			this.lbMonth.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMonth.Location = new System.Drawing.Point(395, 4);
			this.lbMonth.Name = "lbMonth";
			this.lbMonth.Size = new System.Drawing.Size(59, 25);
			this.lbMonth.TabIndex = 12;
			this.lbMonth.Text = "Month :";
			this.lbMonth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxWorkYear
			// 
			this.cbxWorkYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWorkYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorkYear.FormattingEnabled = true;
			this.cbxWorkYear.Location = new System.Drawing.Point(314, 4);
			this.cbxWorkYear.Name = "cbxWorkYear";
			this.cbxWorkYear.Size = new System.Drawing.Size(81, 25);
			this.cbxWorkYear.TabIndex = 11;
			this.cbxWorkYear.SelectedValueChanged += new System.EventHandler(this.cbxWorkYear_SelectedValueChanged);
			// 
			// lbYear
			// 
			this.lbYear.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbYear.Location = new System.Drawing.Point(259, 4);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(55, 25);
			this.lbYear.TabIndex = 10;
			this.lbYear.Text = "Year :";
			this.lbYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// cbxTopic
			// 
			this.cbxTopic.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxTopic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxTopic.FormattingEnabled = true;
			this.cbxTopic.Location = new System.Drawing.Point(54, 4);
			this.cbxTopic.Name = "cbxTopic";
			this.cbxTopic.Size = new System.Drawing.Size(205, 25);
			this.cbxTopic.TabIndex = 9;
			this.cbxTopic.SelectedValueChanged += new System.EventHandler(this.cbxTopic_SelectedValueChanged);
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(4, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 25);
			this.label2.TabIndex = 8;
			this.label2.Text = "Topic :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbWorkerId
			// 
			this.lbWorkerId.Dock = System.Windows.Forms.DockStyle.Right;
			this.lbWorkerId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbWorkerId.Location = new System.Drawing.Point(595, 2);
			this.lbWorkerId.Name = "lbWorkerId";
			this.lbWorkerId.Size = new System.Drawing.Size(72, 25);
			this.lbWorkerId.TabIndex = 10;
			this.lbWorkerId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(4);
			this.panel1.Size = new System.Drawing.Size(263, 35);
			this.panel1.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Left;
			this.label3.Location = new System.Drawing.Point(4, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(126, 25);
			this.label3.TabIndex = 13;
			this.label3.Text = "Job:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// dgvJobs
			// 
			this.dgvJobs.BackgroundColor = System.Drawing.Color.White;
			this.dgvJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvJobs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvJobs.Location = new System.Drawing.Point(2, 37);
			this.dgvJobs.Name = "dgvJobs";
			this.dgvJobs.Size = new System.Drawing.Size(263, 478);
			this.dgvJobs.TabIndex = 2;
			// 
			// CastingWorkPerformance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 561);
			this.Controls.Add(this.pnlContentRight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlRight);
			this.Controls.Add(this.pnlTop);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingWorkPerformance";
			this.Text = "CASTING PERFORMANCE";
			this.Load += new System.EventHandler(this.CastingPerformance_Load);
			this.pnlTop.ResumeLayout(false);
			this.pnlRight.ResumeLayout(false);
			this.pnlContentRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvDayContents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvContents)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvJobs)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlRight;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlContentRight;
		private System.Windows.Forms.DataGridView dgvDayContents;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.DataGridView dgvContents;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lbMenuId;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.ComboBox cbxMonth;
		private System.Windows.Forms.Label lbMonth;
		private System.Windows.Forms.ComboBox cbxWorkYear;
		private System.Windows.Forms.Label lbYear;
		private System.Windows.Forms.ComboBox cbxTopic;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbWorkerId;
		private System.Windows.Forms.DataGridView dgvJobs;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
	}
}