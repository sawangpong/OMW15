namespace OMW15.Views.Productions
{
	partial class Production
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.mnu = new System.Windows.Forms.MenuStrip();
			this.mnuProduction = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProductionTasks = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMCToolsPlan = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBOM = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuStandardItems = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuTimeRecord = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWorkHistory = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuWorkStat = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuProductionProcess = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuProductionMembers = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCheckWorkTime = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuIssueMap = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuCascadeWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuVerticalWindowList = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHorizontalWindowList = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.ts = new System.Windows.Forms.ToolStrip();
			this.tsbtnProductionTask = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnSTDTime = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnBOM = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnTimeRecord = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnStat = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnReport = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnWorkHistory = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnProduction2Plan = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.mnu.SuspendLayout();
			this.ts.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 613);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1155, 22);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// mnu
			// 
			this.mnu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProduction,
            this.mnuTools,
            this.mnuWindow,
            this.mnuClose});
			this.mnu.Location = new System.Drawing.Point(0, 0);
			this.mnu.MdiWindowListItem = this.mnuWindow;
			this.mnu.Name = "mnu";
			this.mnu.Size = new System.Drawing.Size(1155, 25);
			this.mnu.TabIndex = 5;
			this.mnu.Text = "menuStrip1";
			// 
			// mnuProduction
			// 
			this.mnuProduction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductionTasks,
            this.mnuMCToolsPlan,
            this.toolStripMenuItem1,
            this.mnuBOM,
            this.mnuStandardItems,
            this.toolStripMenuItem2,
            this.mnuTimeRecord,
            this.mnuWorkHistory,
            this.toolStripMenuItem6,
            this.mnuWorkStat,
            this.toolStripMenuItem4,
            this.mnuReports,
            this.mnuExit});
			this.mnuProduction.Name = "mnuProduction";
			this.mnuProduction.Size = new System.Drawing.Size(83, 21);
			this.mnuProduction.Text = "Production";
			// 
			// mnuProductionTasks
			// 
			this.mnuProductionTasks.Image = global::OMW15.Properties.Resources.otheroptions;
			this.mnuProductionTasks.Name = "mnuProductionTasks";
			this.mnuProductionTasks.Size = new System.Drawing.Size(234, 22);
			this.mnuProductionTasks.Text = "ใบสั่งผลิต (Production order)";
			this.mnuProductionTasks.Click += new System.EventHandler(this.mnuProductionTasks_Click);
			// 
			// mnuMCToolsPlan
			// 
			this.mnuMCToolsPlan.Name = "mnuMCToolsPlan";
			this.mnuMCToolsPlan.Size = new System.Drawing.Size(234, 22);
			this.mnuMCToolsPlan.Text = "Machine && Tools Plan";
			this.mnuMCToolsPlan.Click += new System.EventHandler(this.mnuMCToolsPlan_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
			// 
			// mnuBOM
			// 
			this.mnuBOM.Name = "mnuBOM";
			this.mnuBOM.Size = new System.Drawing.Size(234, 22);
			this.mnuBOM.Text = "Bill of Material (BOM)";
			this.mnuBOM.Click += new System.EventHandler(this.mnuBOM_Click);
			// 
			// mnuStandardItems
			// 
			this.mnuStandardItems.Image = global::OMW15.Properties.Resources.clock;
			this.mnuStandardItems.Name = "mnuStandardItems";
			this.mnuStandardItems.Size = new System.Drawing.Size(234, 22);
			this.mnuStandardItems.Text = "Standard Item master";
			this.mnuStandardItems.Click += new System.EventHandler(this.mnuStandardItems_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(231, 6);
			// 
			// mnuTimeRecord
			// 
			this.mnuTimeRecord.Image = global::OMW15.Properties.Resources.EditTableHS;
			this.mnuTimeRecord.Name = "mnuTimeRecord";
			this.mnuTimeRecord.Size = new System.Drawing.Size(234, 22);
			this.mnuTimeRecord.Text = "บันทึกเวลาทำงาน";
			this.mnuTimeRecord.Click += new System.EventHandler(this.mnuTimeRecord_Click);
			// 
			// mnuWorkHistory
			// 
			this.mnuWorkHistory.Name = "mnuWorkHistory";
			this.mnuWorkHistory.Size = new System.Drawing.Size(234, 22);
			this.mnuWorkHistory.Text = "Work History";
			this.mnuWorkHistory.Click += new System.EventHandler(this.mnuWorkHistory_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(231, 6);
			// 
			// mnuWorkStat
			// 
			this.mnuWorkStat.Image = global::OMW15.Properties.Resources.graphhs;
			this.mnuWorkStat.Name = "mnuWorkStat";
			this.mnuWorkStat.Size = new System.Drawing.Size(234, 22);
			this.mnuWorkStat.Text = "สถิติการทำงาน";
			this.mnuWorkStat.Visible = false;
			this.mnuWorkStat.Click += new System.EventHandler(this.mnuWorkStat_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(231, 6);
			this.toolStripMenuItem4.Visible = false;
			// 
			// mnuReports
			// 
			this.mnuReports.Image = global::OMW15.Properties.Resources.CommentHS;
			this.mnuReports.Name = "mnuReports";
			this.mnuReports.Size = new System.Drawing.Size(234, 22);
			this.mnuReports.Text = "Reports";
			this.mnuReports.Click += new System.EventHandler(this.mnuReports_Click);
			// 
			// mnuExit
			// 
			this.mnuExit.Image = global::OMW15.Properties.Resources.CLOSE;
			this.mnuExit.Name = "mnuExit";
			this.mnuExit.Size = new System.Drawing.Size(234, 22);
			this.mnuExit.Text = "&Close";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProductionProcess,
            this.toolStripMenuItem3,
            this.mnuProductionMembers,
            this.mnuCheckWorkTime,
            this.toolStripMenuItem5,
            this.mnuIssueMap});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(51, 21);
			this.mnuTools.Text = "Tools";
			// 
			// mnuProductionProcess
			// 
			this.mnuProductionProcess.Name = "mnuProductionProcess";
			this.mnuProductionProcess.Size = new System.Drawing.Size(166, 22);
			this.mnuProductionProcess.Text = "ขั้นตอนการทำงาน";
			this.mnuProductionProcess.Click += new System.EventHandler(this.mnuProductionProcess_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 6);
			// 
			// mnuProductionMembers
			// 
			this.mnuProductionMembers.Name = "mnuProductionMembers";
			this.mnuProductionMembers.Size = new System.Drawing.Size(166, 22);
			this.mnuProductionMembers.Text = "สมาชิก (ฝ่ายผลิต)";
			this.mnuProductionMembers.Click += new System.EventHandler(this.mnuProductionMembers_Click);
			// 
			// mnuCheckWorkTime
			// 
			this.mnuCheckWorkTime.Name = "mnuCheckWorkTime";
			this.mnuCheckWorkTime.Size = new System.Drawing.Size(166, 22);
			this.mnuCheckWorkTime.Text = "ตรวจสอบเวลางาน";
			this.mnuCheckWorkTime.Click += new System.EventHandler(this.mnuCheckWorkTime_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(163, 6);
			// 
			// mnuIssueMap
			// 
			this.mnuIssueMap.Name = "mnuIssueMap";
			this.mnuIssueMap.Size = new System.Drawing.Size(166, 22);
			this.mnuIssueMap.Text = "ใบแปร (issue)";
			this.mnuIssueMap.Click += new System.EventHandler(this.mnuIssueMap_Click);
			// 
			// mnuWindow
			// 
			this.mnuWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCascadeWindows,
            this.mnuVerticalWindowList,
            this.mnuHorizontalWindowList});
			this.mnuWindow.Name = "mnuWindow";
			this.mnuWindow.Size = new System.Drawing.Size(67, 21);
			this.mnuWindow.Text = "Window";
			// 
			// mnuCascadeWindows
			// 
			this.mnuCascadeWindows.Name = "mnuCascadeWindows";
			this.mnuCascadeWindows.Size = new System.Drawing.Size(193, 22);
			this.mnuCascadeWindows.Text = "Cascade Windows";
			this.mnuCascadeWindows.Click += new System.EventHandler(this.mnuCascadeWindows_Click);
			// 
			// mnuVerticalWindowList
			// 
			this.mnuVerticalWindowList.Name = "mnuVerticalWindowList";
			this.mnuVerticalWindowList.Size = new System.Drawing.Size(193, 22);
			this.mnuVerticalWindowList.Text = "Vertical Windows";
			this.mnuVerticalWindowList.Click += new System.EventHandler(this.mnuVerticalWindowList_Click);
			// 
			// mnuHorizontalWindowList
			// 
			this.mnuHorizontalWindowList.Name = "mnuHorizontalWindowList";
			this.mnuHorizontalWindowList.Size = new System.Drawing.Size(193, 22);
			this.mnuHorizontalWindowList.Text = "Horizontal Windows";
			this.mnuHorizontalWindowList.Click += new System.EventHandler(this.mnuHorizontalWindowList_Click);
			// 
			// mnuClose
			// 
			this.mnuClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.mnuClose.Image = global::OMW15.Properties.Resources.CLOSE;
			this.mnuClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mnuClose.Name = "mnuClose";
			this.mnuClose.Size = new System.Drawing.Size(68, 21);
			this.mnuClose.Text = "&Close";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// ts
			// 
			this.ts.AutoSize = false;
			this.ts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ts.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnProductionTask,
            this.toolStripSeparator1,
            this.tsbtnSTDTime,
            this.toolStripSeparator2,
            this.tsbtnBOM,
            this.toolStripSeparator3,
            this.tsbtnTimeRecord,
            this.toolStripSeparator4,
            this.tsbtnStat,
            this.toolStripSeparator5,
            this.tsbtnReport,
            this.toolStripSeparator7,
            this.tsbtnWorkHistory,
            this.toolStripSeparator6,
            this.tsbtnProduction2Plan,
            this.toolStripSeparator8});
			this.ts.Location = new System.Drawing.Point(0, 25);
			this.ts.Name = "ts";
			this.ts.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ts.Size = new System.Drawing.Size(1155, 45);
			this.ts.TabIndex = 7;
			// 
			// tsbtnProductionTask
			// 
			this.tsbtnProductionTask.AutoSize = false;
			this.tsbtnProductionTask.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnProductionTask.Image = global::OMW15.Properties.Resources.otheroptions;
			this.tsbtnProductionTask.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnProductionTask.Name = "tsbtnProductionTask";
			this.tsbtnProductionTask.Size = new System.Drawing.Size(100, 45);
			this.tsbtnProductionTask.Text = "ใบงานฝ่ายผลิต";
			this.tsbtnProductionTask.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnProductionTask.Click += new System.EventHandler(this.tsbtnProductionTask_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnSTDTime
			// 
			this.tsbtnSTDTime.AutoSize = false;
			this.tsbtnSTDTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsbtnSTDTime.Image = global::OMW15.Properties.Resources.clock;
			this.tsbtnSTDTime.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSTDTime.Name = "tsbtnSTDTime";
			this.tsbtnSTDTime.Size = new System.Drawing.Size(100, 42);
			this.tsbtnSTDTime.Text = "Standard Time";
			this.tsbtnSTDTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnSTDTime.Click += new System.EventHandler(this.tsbtnSTDTime_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnBOM
			// 
			this.tsbtnBOM.AutoSize = false;
			this.tsbtnBOM.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBOM.Image")));
			this.tsbtnBOM.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnBOM.Name = "tsbtnBOM";
			this.tsbtnBOM.Size = new System.Drawing.Size(100, 42);
			this.tsbtnBOM.Text = "BOM";
			this.tsbtnBOM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnBOM.Click += new System.EventHandler(this.tsbtnBOM_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnTimeRecord
			// 
			this.tsbtnTimeRecord.AutoSize = false;
			this.tsbtnTimeRecord.Image = global::OMW15.Properties.Resources.EditTableHS;
			this.tsbtnTimeRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnTimeRecord.Name = "tsbtnTimeRecord";
			this.tsbtnTimeRecord.Size = new System.Drawing.Size(120, 42);
			this.tsbtnTimeRecord.Text = "บันทึกเวลาทำงาน";
			this.tsbtnTimeRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnTimeRecord.Click += new System.EventHandler(this.tsbtnTimeRecord_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 45);
			this.toolStripSeparator4.Visible = false;
			// 
			// tsbtnStat
			// 
			this.tsbtnStat.AutoSize = false;
			this.tsbtnStat.Image = global::OMW15.Properties.Resources.graphhs;
			this.tsbtnStat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnStat.Name = "tsbtnStat";
			this.tsbtnStat.Size = new System.Drawing.Size(100, 42);
			this.tsbtnStat.Text = "สถิติการทำงาน";
			this.tsbtnStat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnStat.Visible = false;
			this.tsbtnStat.Click += new System.EventHandler(this.tsbtnStat_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnReport
			// 
			this.tsbtnReport.AutoSize = false;
			this.tsbtnReport.Image = global::OMW15.Properties.Resources.CommentHS;
			this.tsbtnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnReport.Name = "tsbtnReport";
			this.tsbtnReport.Size = new System.Drawing.Size(100, 42);
			this.tsbtnReport.Text = "&Reports";
			this.tsbtnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnReport.Click += new System.EventHandler(this.tsbtnReport_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnWorkHistory
			// 
			this.tsbtnWorkHistory.AutoSize = false;
			this.tsbtnWorkHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnWorkHistory.Image")));
			this.tsbtnWorkHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnWorkHistory.Name = "tsbtnWorkHistory";
			this.tsbtnWorkHistory.Size = new System.Drawing.Size(100, 42);
			this.tsbtnWorkHistory.Text = "Work History";
			this.tsbtnWorkHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnWorkHistory.Click += new System.EventHandler(this.tsbtnWorkHistory_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 45);
			// 
			// tsbtnProduction2Plan
			// 
			this.tsbtnProduction2Plan.AutoSize = false;
			this.tsbtnProduction2Plan.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnProduction2Plan.Image")));
			this.tsbtnProduction2Plan.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnProduction2Plan.Name = "tsbtnProduction2Plan";
			this.tsbtnProduction2Plan.Size = new System.Drawing.Size(100, 42);
			this.tsbtnProduction2Plan.Text = "M/C Plan";
			this.tsbtnProduction2Plan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.tsbtnProduction2Plan.Click += new System.EventHandler(this.tsbtnProduction2Plan_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 45);
			// 
			// Production
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1155, 635);
			this.Controls.Add(this.ts);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.mnu);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mnu;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "Production";
			this.Text = "Production";
			this.Load += new System.EventHandler(this.Production_Load);
			this.mnu.ResumeLayout(false);
			this.mnu.PerformLayout();
			this.ts.ResumeLayout(false);
			this.ts.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.MenuStrip mnu;
		private System.Windows.Forms.ToolStripMenuItem mnuProduction;
		private System.Windows.Forms.ToolStripMenuItem mnuProductionTasks;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuStandardItems;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.ToolStripMenuItem mnuTools;
		private System.Windows.Forms.ToolStripMenuItem mnuProductionProcess;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem mnuProductionMembers;
		private System.Windows.Forms.ToolStripMenuItem mnuClose;
		private System.Windows.Forms.ToolStrip ts;
		private System.Windows.Forms.ToolStripButton tsbtnProductionTask;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnSTDTime;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuWindow;
		private System.Windows.Forms.ToolStripMenuItem mnuCascadeWindows;
		private System.Windows.Forms.ToolStripMenuItem mnuVerticalWindowList;
		private System.Windows.Forms.ToolStripMenuItem mnuHorizontalWindowList;
		private System.Windows.Forms.ToolStripMenuItem mnuReports;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem mnuBOM;
		private System.Windows.Forms.ToolStripButton tsbtnBOM;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbtnStat;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem mnuWorkStat;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem mnuIssueMap;
		private System.Windows.Forms.ToolStripButton tsbtnTimeRecord;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuTimeRecord;
		  private System.Windows.Forms.ToolStripMenuItem mnuWorkHistory;
		  private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		  private System.Windows.Forms.ToolStripButton tsbtnWorkHistory;
		  private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton tsbtnReport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem mnuCheckWorkTime;
		private System.Windows.Forms.ToolStripMenuItem mnuMCToolsPlan;
		private System.Windows.Forms.ToolStripButton tsbtnProduction2Plan;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
	}
}