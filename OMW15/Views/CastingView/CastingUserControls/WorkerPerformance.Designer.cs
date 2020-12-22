namespace OMW15.Views.CastingView.CastingUserControls
{
	partial class WorkerPerformance
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
			this.pnlOption = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cbxWorker = new System.Windows.Forms.ComboBox();
			this.lbWorker = new System.Windows.Forms.Label();
			this.chkExploded = new System.Windows.Forms.CheckBox();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.pnlOption.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlOption
			// 
			this.pnlOption.Controls.Add(this.panel1);
			this.pnlOption.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlOption.Location = new System.Drawing.Point(5, 5);
			this.pnlOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlOption.Name = "pnlOption";
			this.pnlOption.Size = new System.Drawing.Size(489, 62);
			this.pnlOption.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cbxWorker);
			this.panel1.Controls.Add(this.lbWorker);
			this.panel1.Controls.Add(this.chkExploded);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(1);
			this.panel1.Size = new System.Drawing.Size(489, 28);
			this.panel1.TabIndex = 1;
			// 
			// cbxWorker
			// 
			this.cbxWorker.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWorker.FormattingEnabled = true;
			this.cbxWorker.Location = new System.Drawing.Point(187, 1);
			this.cbxWorker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbxWorker.Name = "cbxWorker";
			this.cbxWorker.Size = new System.Drawing.Size(247, 25);
			this.cbxWorker.TabIndex = 4;
			this.cbxWorker.SelectedIndexChanged += new System.EventHandler(this.cbxWorker_SelectedIndexChanged);
			// 
			// lbWorker
			// 
			this.lbWorker.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbWorker.Location = new System.Drawing.Point(125, 1);
			this.lbWorker.Name = "lbWorker";
			this.lbWorker.Size = new System.Drawing.Size(62, 26);
			this.lbWorker.TabIndex = 3;
			this.lbWorker.Text = "Worker :";
			this.lbWorker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkExploded
			// 
			this.chkExploded.AutoSize = true;
			this.chkExploded.Dock = System.Windows.Forms.DockStyle.Left;
			this.chkExploded.Location = new System.Drawing.Point(1, 1);
			this.chkExploded.Name = "chkExploded";
			this.chkExploded.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
			this.chkExploded.Size = new System.Drawing.Size(124, 26);
			this.chkExploded.TabIndex = 2;
			this.chkExploded.Text = "All Exploded ";
			this.chkExploded.UseVisualStyleBackColor = true;
			this.chkExploded.CheckedChanged += new System.EventHandler(this.chkExploded_CheckedChanged);
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.Moccasin;
			this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
			this.chart1.BackSecondaryColor = System.Drawing.Color.WhiteSmoke;
			this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
			this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderlineWidth = 2;
			this.chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
			chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
			chartArea1.Area3DStyle.Enable3D = true;
			chartArea1.Area3DStyle.IsRightAngleAxes = false;
			chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
			chartArea1.Area3DStyle.Perspective = 50;
			chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
			chartArea1.AxisY.MaximumAutoSize = 25F;
			chartArea1.BackColor = System.Drawing.Color.Transparent;
			chartArea1.BorderColor = System.Drawing.Color.Transparent;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Alignment = System.Drawing.StringAlignment.Far;
			legend1.BackColor = System.Drawing.Color.Transparent;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			legend1.HeaderSeparator = System.Windows.Forms.DataVisualization.Charting.LegendSeparatorStyle.Line;
			legend1.IsDockedInsideChartArea = false;
			legend1.IsEquallySpacedItems = true;
			legend1.IsTextAutoFit = false;
			legend1.MaximumAutoSize = 100F;
			legend1.Name = "Legend1";
			legend1.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
			legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(5, 67);
			this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.chart1.Name = "chart1";
			series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(489, 317);
			this.chart1.TabIndex = 2;
			this.chart1.Text = "Monthly Performance";
			title1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title1.ForeColor = System.Drawing.Color.RoyalBlue;
			title1.Name = "Title1";
			title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.chart1.Titles.Add(title1);
			// 
			// WorkerPerformance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.pnlOption);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "WorkerPerformance";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(499, 389);
			this.Load += new System.EventHandler(this.WorkerPerformance_Load);
			this.pnlOption.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlOption;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ComboBox cbxWorker;
		private System.Windows.Forms.Label lbWorker;
		private System.Windows.Forms.CheckBox chkExploded;
	}
}
