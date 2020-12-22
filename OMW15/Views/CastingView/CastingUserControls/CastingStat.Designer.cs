namespace OMW15.Views.CastingView.CastingUserControls
{
	partial class CastingStat
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.chkShowData = new System.Windows.Forms.CheckBox();
			this.pnlData = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.pnlMenu.SuspendLayout();
			this.pnlData.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMenu
			// 
			this.pnlMenu.Controls.Add(this.chkShowData);
			this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlMenu.Location = new System.Drawing.Point(5, 5);
			this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlMenu.Size = new System.Drawing.Size(860, 27);
			this.pnlMenu.TabIndex = 4;
			// 
			// chkShowData
			// 
			this.chkShowData.AutoSize = true;
			this.chkShowData.Checked = true;
			this.chkShowData.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkShowData.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkShowData.Location = new System.Drawing.Point(3, 4);
			this.chkShowData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.chkShowData.Name = "chkShowData";
			this.chkShowData.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.chkShowData.Size = new System.Drawing.Size(109, 19);
			this.chkShowData.TabIndex = 0;
			this.chkShowData.Text = "Show Data";
			this.chkShowData.UseVisualStyleBackColor = true;
			this.chkShowData.CheckedChanged += new System.EventHandler(this.chkShowData_CheckedChanged);
			// 
			// pnlData
			// 
			this.pnlData.Controls.Add(this.dgv);
			this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlData.Location = new System.Drawing.Point(5, 32);
			this.pnlData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlData.Name = "pnlData";
			this.pnlData.Padding = new System.Windows.Forms.Padding(5);
			this.pnlData.Size = new System.Drawing.Size(860, 139);
			this.pnlData.TabIndex = 5;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(5, 5);
			this.dgv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(850, 129);
			this.dgv.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(5, 171);
			this.splitter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(860, 8);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(223)))), ((int)(((byte)(193)))));
			this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(64)))), ((int)(((byte)(1)))));
			this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderlineWidth = 2;
			this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea3.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Lines;
			chartArea3.AxisX.Crossing = -1.7976931348623157E+308D;
			chartArea3.Name = "Default";
			this.chart1.ChartAreas.Add(chartArea3);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend3.Name = "Legend1";
			this.chart1.Legends.Add(legend3);
			this.chart1.Location = new System.Drawing.Point(5, 179);
			this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.chart1.Name = "chart1";
			series3.BorderWidth = 4;
			series3.ChartArea = "Default";
			series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series3.Legend = "Legend1";
			series3.Name = "Series1";
			this.chart1.Series.Add(series3);
			this.chart1.Size = new System.Drawing.Size(860, 457);
			this.chart1.TabIndex = 7;
			title3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title3.Name = "Title1";
			this.chart1.Titles.Add(title3);
			// 
			// CastingStat
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.pnlData);
			this.Controls.Add(this.pnlMenu);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "CastingStat";
			this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.Size = new System.Drawing.Size(870, 641);
			this.Load += new System.EventHandler(this.CastingStat_Load);
			this.pnlMenu.ResumeLayout(false);
			this.pnlMenu.PerformLayout();
			this.pnlData.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlMenu;
		private System.Windows.Forms.CheckBox chkShowData;
		private System.Windows.Forms.Panel pnlData;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}
