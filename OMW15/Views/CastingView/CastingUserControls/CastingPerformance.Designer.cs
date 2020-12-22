namespace OMW15.Views.CastingView.CastingUserControls
{
	partial class CastingPerformance
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.pnlCommand = new System.Windows.Forms.Panel();
			this.cbxWorkCat = new System.Windows.Forms.ComboBox();
			this.lbWorkCat = new System.Windows.Forms.Label();
			this.chkShowData = new System.Windows.Forms.CheckBox();
			this.pnlData = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlLeft = new System.Windows.Forms.Panel();
			this.grp = new System.Windows.Forms.GroupBox();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.pnlCommand.SuspendLayout();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlCommand
			// 
			this.pnlCommand.Controls.Add(this.cbxWorkCat);
			this.pnlCommand.Controls.Add(this.lbWorkCat);
			this.pnlCommand.Controls.Add(this.chkShowData);
			this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCommand.Location = new System.Drawing.Point(4, 4);
			this.pnlCommand.Name = "pnlCommand";
			this.pnlCommand.Padding = new System.Windows.Forms.Padding(1);
			this.pnlCommand.Size = new System.Drawing.Size(903, 28);
			this.pnlCommand.TabIndex = 2;
			// 
			// cbxWorkCat
			// 
			this.cbxWorkCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWorkCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorkCat.FormattingEnabled = true;
			this.cbxWorkCat.Location = new System.Drawing.Point(228, 1);
			this.cbxWorkCat.Name = "cbxWorkCat";
			this.cbxWorkCat.Size = new System.Drawing.Size(150, 25);
			this.cbxWorkCat.TabIndex = 7;
			this.cbxWorkCat.SelectedIndexChanged += new System.EventHandler(this.cbxWorkCat_SelectedIndexChanged_1);
			// 
			// lbWorkCat
			// 
			this.lbWorkCat.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWorkCat.Location = new System.Drawing.Point(132, 1);
			this.lbWorkCat.Name = "lbWorkCat";
			this.lbWorkCat.Size = new System.Drawing.Size(96, 26);
			this.lbWorkCat.TabIndex = 6;
			this.lbWorkCat.Text = "ประเภทงาน :";
			this.lbWorkCat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// chkShowData
			// 
			this.chkShowData.AutoSize = true;
			this.chkShowData.Checked = true;
			this.chkShowData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowData.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkShowData.Location = new System.Drawing.Point(1, 1);
			this.chkShowData.Name = "chkShowData";
			this.chkShowData.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.chkShowData.Size = new System.Drawing.Size(131, 26);
			this.chkShowData.TabIndex = 0;
			this.chkShowData.Text = "แสดงตารางข้อมูล";
			this.chkShowData.UseVisualStyleBackColor = true;
			this.chkShowData.CheckedChanged += new System.EventHandler(this.chkShowData_CheckedChanged);
			// 
			// pnlData
			// 
			this.pnlData.Controls.Add(this.dgv);
			this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlData.Location = new System.Drawing.Point(4, 32);
			this.pnlData.Name = "pnlData";
			this.pnlData.Padding = new System.Windows.Forms.Padding(3);
			this.pnlData.Size = new System.Drawing.Size(903, 118);
			this.pnlData.TabIndex = 3;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Enabled = false;
			this.dgv.GridColor = System.Drawing.Color.CadetBlue;
			this.dgv.Location = new System.Drawing.Point(3, 3);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(897, 112);
			this.dgv.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(4, 150);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(903, 6);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// pnlLeft
			// 
			this.pnlLeft.Controls.Add(this.grp);
			this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlLeft.Location = new System.Drawing.Point(4, 156);
			this.pnlLeft.Name = "pnlLeft";
			this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
			this.pnlLeft.Size = new System.Drawing.Size(196, 343);
			this.pnlLeft.TabIndex = 7;
			// 
			// grp
			// 
			this.grp.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grp.Location = new System.Drawing.Point(10, 10);
			this.grp.Name = "grp";
			this.grp.Padding = new System.Windows.Forms.Padding(20, 3, 3, 3);
			this.grp.Size = new System.Drawing.Size(176, 323);
			this.grp.TabIndex = 0;
			this.grp.TabStop = false;
			this.grp.Text = "รูปแบบงาน";
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.chart1.BorderlineColor = System.Drawing.Color.DimGray;
			this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderlineWidth = 2;
			this.chart1.BorderSkin.BackColor = System.Drawing.Color.Black;
			this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderSkin.BorderWidth = 3;
			this.chart1.BorderSkin.PageColor = System.Drawing.Color.WhiteSmoke;
			this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.Name = "Default";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(200, 156);
			this.chart1.Name = "chart1";
			this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			series1.ChartArea = "Default";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(707, 343);
			this.chart1.TabIndex = 8;
			title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title1.Name = "Title1";
			this.chart1.Titles.Add(title1);
			// 
			// CastingPerformance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.pnlLeft);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.pnlCommand);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingPerformance";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Size = new System.Drawing.Size(911, 503);
			this.Load += new System.EventHandler(this.CastingPerformance_Load);
			this.pnlCommand.ResumeLayout(false);
			this.pnlCommand.PerformLayout();
			this.pnlData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlCommand;
		private System.Windows.Forms.CheckBox chkShowData;
		private System.Windows.Forms.Panel pnlData;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlLeft;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.GroupBox grp;
		private System.Windows.Forms.Label lbWorkCat;
		private System.Windows.Forms.ComboBox cbxWorkCat;

	}
}
