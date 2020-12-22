namespace OMW15.Casting.CastingView
{
	partial class ItemImageResize
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemImageResize));
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbImageLocationPath = new System.Windows.Forms.Label();
			this.btnSearchItemItemId = new OMControls.OMFlatButton();
			this.lbImageItemID = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lbValue = new System.Windows.Forms.Label();
			this.btnProcess = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel12 = new System.Windows.Forms.Panel();
			this.btnExportImage = new System.Windows.Forms.Button();
			this.btnScan = new System.Windows.Forms.Button();
			this.picOriginal = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lbDecoder = new System.Windows.Forms.Label();
			this.lbItemNo = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.panel10 = new System.Windows.Forms.Panel();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.lbQualityValue = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.picResult = new System.Windows.Forms.PictureBox();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.panel9 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lbExportFileName = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lbImageResultHeader = new System.Windows.Forms.Label();
			this.bgwork = new System.ComponentModel.BackgroundWorker();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel12.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.panel5.SuspendLayout();
			this.panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
			this.panel8.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbImageLocationPath);
			this.panel1.Controls.Add(this.btnSearchItemItemId);
			this.panel1.Controls.Add(this.lbImageItemID);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(740, 33);
			this.panel1.TabIndex = 0;
			// 
			// lbImageLocationPath
			// 
			this.lbImageLocationPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbImageLocationPath.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbImageLocationPath.Location = new System.Drawing.Point(337, 2);
			this.lbImageLocationPath.Name = "lbImageLocationPath";
			this.lbImageLocationPath.Size = new System.Drawing.Size(401, 29);
			this.lbImageLocationPath.TabIndex = 6;
			this.lbImageLocationPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSearchItemItemId
			// 
			this.btnSearchItemItemId.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnSearchItemItemId.FlatAppearance.BorderSize = 0;
			this.btnSearchItemItemId.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearchItemItemId.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
			this.btnSearchItemItemId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearchItemItemId.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchItemItemId.Image")));
			this.btnSearchItemItemId.Location = new System.Drawing.Point(308, 2);
			this.btnSearchItemItemId.Name = "btnSearchItemItemId";
			this.btnSearchItemItemId.Size = new System.Drawing.Size(29, 29);
			this.btnSearchItemItemId.TabIndex = 5;
			this.btnSearchItemItemId.UseVisualStyleBackColor = true;
			this.btnSearchItemItemId.Click += new System.EventHandler(this.btnSearchItemItemId_Click);
			// 
			// lbImageItemID
			// 
			this.lbImageItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbImageItemID.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbImageItemID.Location = new System.Drawing.Point(234, 2);
			this.lbImageItemID.Name = "lbImageItemID";
			this.lbImageItemID.Size = new System.Drawing.Size(74, 29);
			this.lbImageItemID.TabIndex = 4;
			this.lbImageItemID.Text = "0";
			this.lbImageItemID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select Image from Casting Item :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel11);
			this.panel2.Controls.Add(this.btnProcess);
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(4, 386);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(10);
			this.panel2.Size = new System.Drawing.Size(740, 65);
			this.panel2.TabIndex = 1;
			// 
			// panel11
			// 
			this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel11.Controls.Add(this.progressBar1);
			this.panel11.Controls.Add(this.lbValue);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel11.Location = new System.Drawing.Point(181, 10);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(3);
			this.panel11.Size = new System.Drawing.Size(416, 45);
			this.panel11.TabIndex = 2;
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.Color.DarkRed;
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new System.Drawing.Point(3, 3);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(408, 14);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 3;
			// 
			// lbValue
			// 
			this.lbValue.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbValue.Location = new System.Drawing.Point(3, 17);
			this.lbValue.Name = "lbValue";
			this.lbValue.Size = new System.Drawing.Size(408, 23);
			this.lbValue.TabIndex = 1;
			this.lbValue.Text = "0%";
			this.lbValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnProcess
			// 
			this.btnProcess.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnProcess.Location = new System.Drawing.Point(10, 10);
			this.btnProcess.Name = "btnProcess";
			this.btnProcess.Size = new System.Drawing.Size(171, 45);
			this.btnProcess.TabIndex = 1;
			this.btnProcess.Tag = "PROC";
			this.btnProcess.Text = "&Process Resize (All)";
			this.btnProcess.UseVisualStyleBackColor = true;
			this.btnProcess.Click += new System.EventHandler(this.btn_Click);
			// 
			// btnClose
			// 
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnClose.Location = new System.Drawing.Point(597, 10);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(133, 45);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.panel12);
			this.panel3.Controls.Add(this.picOriginal);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(4, 37);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(10);
			this.panel3.Size = new System.Drawing.Size(234, 349);
			this.panel3.TabIndex = 2;
			// 
			// panel12
			// 
			this.panel12.Controls.Add(this.btnExportImage);
			this.panel12.Controls.Add(this.btnScan);
			this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel12.Location = new System.Drawing.Point(10, 299);
			this.panel12.Name = "panel12";
			this.panel12.Padding = new System.Windows.Forms.Padding(5);
			this.panel12.Size = new System.Drawing.Size(214, 40);
			this.panel12.TabIndex = 2;
			// 
			// btnExportImage
			// 
			this.btnExportImage.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnExportImage.Location = new System.Drawing.Point(115, 5);
			this.btnExportImage.Name = "btnExportImage";
			this.btnExportImage.Size = new System.Drawing.Size(94, 30);
			this.btnExportImage.TabIndex = 1;
			this.btnExportImage.Tag = "EXPORT";
			this.btnExportImage.Text = "&Export";
			this.btnExportImage.UseVisualStyleBackColor = true;
			this.btnExportImage.Click += new System.EventHandler(this.btn_Click);
			// 
			// btnScan
			// 
			this.btnScan.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnScan.Location = new System.Drawing.Point(5, 5);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(94, 30);
			this.btnScan.TabIndex = 0;
			this.btnScan.Tag = "SCAN";
			this.btnScan.Text = "&Scan ";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new System.EventHandler(this.btn_Click);
			// 
			// picOriginal
			// 
			this.picOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picOriginal.Dock = System.Windows.Forms.DockStyle.Top;
			this.picOriginal.Location = new System.Drawing.Point(10, 41);
			this.picOriginal.Name = "picOriginal";
			this.picOriginal.Size = new System.Drawing.Size(214, 237);
			this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picOriginal.TabIndex = 1;
			this.picOriginal.TabStop = false;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(10, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(214, 31);
			this.label2.TabIndex = 0;
			this.label2.Text = "Original Image";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.btnCancel);
			this.panel4.Controls.Add(this.lbDecoder);
			this.panel4.Controls.Add(this.lbItemNo);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.panel10);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(238, 37);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(5);
			this.panel4.Size = new System.Drawing.Size(506, 349);
			this.panel4.TabIndex = 3;
			// 
			// btnCancel
			// 
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnCancel.Location = new System.Drawing.Point(5, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(157, 30);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Tag = "EXPORT";
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lbDecoder
			// 
			this.lbDecoder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbDecoder.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbDecoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbDecoder.Location = new System.Drawing.Point(5, 66);
			this.lbDecoder.Name = "lbDecoder";
			this.lbDecoder.Size = new System.Drawing.Size(157, 26);
			this.lbDecoder.TabIndex = 8;
			this.lbDecoder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbItemNo
			// 
			this.lbItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbItemNo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbItemNo.Location = new System.Drawing.Point(5, 40);
			this.lbItemNo.Name = "lbItemNo";
			this.lbItemNo.Size = new System.Drawing.Size(157, 26);
			this.lbItemNo.TabIndex = 7;
			this.lbItemNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(5, 5);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(157, 35);
			this.label3.TabIndex = 6;
			this.label3.Text = "Item No:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.trackBar1);
			this.panel10.Controls.Add(this.lbQualityValue);
			this.panel10.Controls.Add(this.label4);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel10.Location = new System.Drawing.Point(162, 5);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(4);
			this.panel10.Size = new System.Drawing.Size(55, 337);
			this.panel10.TabIndex = 5;
			// 
			// trackBar1
			// 
			this.trackBar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.trackBar1.Location = new System.Drawing.Point(4, 86);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(47, 202);
			this.trackBar1.TabIndex = 4;
			this.trackBar1.TickFrequency = 5;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// lbQualityValue
			// 
			this.lbQualityValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbQualityValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.lbQualityValue.Location = new System.Drawing.Point(4, 45);
			this.lbQualityValue.Name = "lbQualityValue";
			this.lbQualityValue.Size = new System.Drawing.Size(47, 41);
			this.lbQualityValue.TabIndex = 3;
			this.lbQualityValue.Text = "Q";
			this.lbQualityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(4, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 41);
			this.label4.TabIndex = 2;
			this.label4.Text = "Q";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Controls.Add(this.splitter2);
			this.panel5.Controls.Add(this.panel9);
			this.panel5.Controls.Add(this.splitter1);
			this.panel5.Controls.Add(this.panel8);
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel5.Location = new System.Drawing.Point(217, 5);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(282, 337);
			this.panel5.TabIndex = 0;
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.picResult);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel7.Location = new System.Drawing.Point(0, 41);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(2);
			this.panel7.Size = new System.Drawing.Size(154, 177);
			this.panel7.TabIndex = 6;
			// 
			// picResult
			// 
			this.picResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picResult.Location = new System.Drawing.Point(2, 2);
			this.picResult.Name = "picResult";
			this.picResult.Size = new System.Drawing.Size(150, 173);
			this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picResult.TabIndex = 2;
			this.picResult.TabStop = false;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(154, 41);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(6, 177);
			this.splitter2.TabIndex = 5;
			this.splitter2.TabStop = false;
			this.splitter2.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoving);
			this.splitter2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoving);
			// 
			// panel9
			// 
			this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel9.Location = new System.Drawing.Point(160, 41);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(122, 177);
			this.panel9.TabIndex = 4;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 218);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(282, 10);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoving);
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter_SplitterMoving);
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lbExportFileName);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel8.Location = new System.Drawing.Point(0, 228);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(282, 109);
			this.panel8.TabIndex = 2;
			// 
			// lbExportFileName
			// 
			this.lbExportFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbExportFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lbExportFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.lbExportFileName.Location = new System.Drawing.Point(0, 79);
			this.lbExportFileName.Name = "lbExportFileName";
			this.lbExportFileName.Size = new System.Drawing.Size(282, 30);
			this.lbExportFileName.TabIndex = 7;
			this.lbExportFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.lbImageResultHeader);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(282, 41);
			this.panel6.TabIndex = 0;
			// 
			// lbImageResultHeader
			// 
			this.lbImageResultHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbImageResultHeader.Location = new System.Drawing.Point(0, 0);
			this.lbImageResultHeader.Name = "lbImageResultHeader";
			this.lbImageResultHeader.Size = new System.Drawing.Size(282, 41);
			this.lbImageResultHeader.TabIndex = 1;
			this.lbImageResultHeader.Text = "Result Image : (W:0,H:0)";
			this.lbImageResultHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// bgwork
			// 
			this.bgwork.WorkerReportsProgress = true;
			this.bgwork.WorkerSupportsCancellation = true;
			this.bgwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwork_DoWork);
			this.bgwork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwork_ProgressChanged);
			this.bgwork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwork_RunWorkerCompleted);
			// 
			// ItemImageResize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 455);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ItemImageResize";
			this.Padding = new System.Windows.Forms.Padding(4);
			this.Text = "ITEM IMAGE RESIZE";
			this.Load += new System.EventHandler(this.ItemImageResize_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox picOriginal;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label lbImageResultHeader;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.PictureBox picResult;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label lbQualityValue;
		private System.Windows.Forms.Label label4;
		private OMControls.OMFlatButton btnSearchItemItemId;
		private System.Windows.Forms.Label lbImageItemID;
		private System.Windows.Forms.Button btnProcess;
		private System.ComponentModel.BackgroundWorker bgwork;
		private System.Windows.Forms.Label lbItemNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lbValue;
		private System.Windows.Forms.Label lbDecoder;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Button btnExportImage;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lbImageLocationPath;
		private System.Windows.Forms.Label lbExportFileName;
	}
}