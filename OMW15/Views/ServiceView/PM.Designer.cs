namespace OMW15.Views.ServiceView
{
	partial class PM
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
			this.pnlBody = new System.Windows.Forms.Panel();
			this.pnlMachine = new System.Windows.Forms.Panel();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.pnlMachineCommand = new System.Windows.Forms.Panel();
			this.pnlBottomBar = new System.Windows.Forms.Panel();
			this.lbMachineId = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnReloadPM = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.btnDeleteMachine = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnEditMachine = new System.Windows.Forms.Button();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.pnlSchedule = new System.Windows.Forms.Panel();
			this.dgvSchedule = new System.Windows.Forms.DataGridView();
			this.panel9 = new System.Windows.Forms.Panel();
			this.lbScheduleHeader = new System.Windows.Forms.Label();
			this.pnlScheduleCommand = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.btnMatchingJob = new System.Windows.Forms.Button();
			this.panel10 = new System.Windows.Forms.Panel();
			this.btnOpenServiceOrder = new System.Windows.Forms.Button();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnDeleteSchedule = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnEditSchedule = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btnAddSchedule = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlBody.SuspendLayout();
			this.pnlMachine.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.pnlMachineCommand.SuspendLayout();
			this.pnlBottomBar.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlSchedule.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
			this.panel9.SuspendLayout();
			this.pnlScheduleCommand.SuspendLayout();
			this.panel11.SuspendLayout();
			this.panel10.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBody
			// 
			this.pnlBody.Controls.Add(this.pnlMachine);
			this.pnlBody.Controls.Add(this.splitter1);
			this.pnlBody.Controls.Add(this.pnlSchedule);
			this.pnlBody.Controls.Add(this.panel1);
			this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBody.Location = new System.Drawing.Point(3, 3);
			this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlBody.Name = "pnlBody";
			this.pnlBody.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlBody.Size = new System.Drawing.Size(907, 506);
			this.pnlBody.TabIndex = 2;
			// 
			// pnlMachine
			// 
			this.pnlMachine.Controls.Add(this.dgv);
			this.pnlMachine.Controls.Add(this.pnlMachineCommand);
			this.pnlMachine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMachine.Location = new System.Drawing.Point(2, 48);
			this.pnlMachine.Name = "pnlMachine";
			this.pnlMachine.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMachine.Size = new System.Drawing.Size(903, 214);
			this.pnlMachine.TabIndex = 8;
			// 
			// dgv
			// 
			this.dgv.BackgroundColor = System.Drawing.Color.White;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(2, 2);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(759, 210);
			this.dgv.TabIndex = 7;
			this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
			// 
			// pnlMachineCommand
			// 
			this.pnlMachineCommand.Controls.Add(this.pnlBottomBar);
			this.pnlMachineCommand.Controls.Add(this.panel5);
			this.pnlMachineCommand.Controls.Add(this.panel4);
			this.pnlMachineCommand.Controls.Add(this.panel3);
			this.pnlMachineCommand.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlMachineCommand.Location = new System.Drawing.Point(761, 2);
			this.pnlMachineCommand.Name = "pnlMachineCommand";
			this.pnlMachineCommand.Padding = new System.Windows.Forms.Padding(2);
			this.pnlMachineCommand.Size = new System.Drawing.Size(140, 210);
			this.pnlMachineCommand.TabIndex = 0;
			// 
			// pnlBottomBar
			// 
			this.pnlBottomBar.Controls.Add(this.lbMachineId);
			this.pnlBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlBottomBar.Location = new System.Drawing.Point(2, 178);
			this.pnlBottomBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlBottomBar.Name = "pnlBottomBar";
			this.pnlBottomBar.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.pnlBottomBar.Size = new System.Drawing.Size(136, 30);
			this.pnlBottomBar.TabIndex = 7;
			// 
			// lbMachineId
			// 
			this.lbMachineId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbMachineId.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMachineId.Location = new System.Drawing.Point(2, 3);
			this.lbMachineId.Name = "lbMachineId";
			this.lbMachineId.Size = new System.Drawing.Size(117, 24);
			this.lbMachineId.TabIndex = 0;
			this.lbMachineId.Text = "machine id : 0";
			this.lbMachineId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnReloadPM);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(2, 82);
			this.panel5.Name = "panel5";
			this.panel5.Padding = new System.Windows.Forms.Padding(5);
			this.panel5.Size = new System.Drawing.Size(136, 40);
			this.panel5.TabIndex = 4;
			// 
			// btnReloadPM
			// 
			this.btnReloadPM.BackColor = System.Drawing.SystemColors.Control;
			this.btnReloadPM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnReloadPM.ForeColor = System.Drawing.Color.Black;
			this.btnReloadPM.Location = new System.Drawing.Point(5, 5);
			this.btnReloadPM.Name = "btnReloadPM";
			this.btnReloadPM.Size = new System.Drawing.Size(126, 30);
			this.btnReloadPM.TabIndex = 0;
			this.btnReloadPM.Text = "&Re-load";
			this.btnReloadPM.UseVisualStyleBackColor = false;
			this.btnReloadPM.Click += new System.EventHandler(this.btnReloadPM_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnDeleteMachine);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(2, 42);
			this.panel4.Name = "panel4";
			this.panel4.Padding = new System.Windows.Forms.Padding(5);
			this.panel4.Size = new System.Drawing.Size(136, 40);
			this.panel4.TabIndex = 3;
			// 
			// btnDeleteMachine
			// 
			this.btnDeleteMachine.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteMachine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDeleteMachine.ForeColor = System.Drawing.Color.Black;
			this.btnDeleteMachine.Location = new System.Drawing.Point(5, 5);
			this.btnDeleteMachine.Name = "btnDeleteMachine";
			this.btnDeleteMachine.Size = new System.Drawing.Size(126, 30);
			this.btnDeleteMachine.TabIndex = 0;
			this.btnDeleteMachine.Text = "&Delete";
			this.btnDeleteMachine.UseVisualStyleBackColor = false;
			this.btnDeleteMachine.Click += new System.EventHandler(this.btnDeleteMachine_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnEditMachine);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(5);
			this.panel3.Size = new System.Drawing.Size(136, 40);
			this.panel3.TabIndex = 2;
			// 
			// btnEditMachine
			// 
			this.btnEditMachine.BackColor = System.Drawing.SystemColors.Control;
			this.btnEditMachine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnEditMachine.ForeColor = System.Drawing.Color.Black;
			this.btnEditMachine.Location = new System.Drawing.Point(5, 5);
			this.btnEditMachine.Name = "btnEditMachine";
			this.btnEditMachine.Size = new System.Drawing.Size(126, 30);
			this.btnEditMachine.TabIndex = 0;
			this.btnEditMachine.Text = "E&dit";
			this.btnEditMachine.UseVisualStyleBackColor = false;
			this.btnEditMachine.Click += new System.EventHandler(this.btnEditMachine_Click);
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(2, 262);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(903, 6);
			this.splitter1.TabIndex = 7;
			this.splitter1.TabStop = false;
			// 
			// pnlSchedule
			// 
			this.pnlSchedule.Controls.Add(this.dgvSchedule);
			this.pnlSchedule.Controls.Add(this.panel9);
			this.pnlSchedule.Controls.Add(this.pnlScheduleCommand);
			this.pnlSchedule.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlSchedule.Location = new System.Drawing.Point(2, 268);
			this.pnlSchedule.Name = "pnlSchedule";
			this.pnlSchedule.Padding = new System.Windows.Forms.Padding(2);
			this.pnlSchedule.Size = new System.Drawing.Size(903, 235);
			this.pnlSchedule.TabIndex = 6;
			// 
			// dgvSchedule
			// 
			this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
			this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSchedule.Location = new System.Drawing.Point(2, 44);
			this.dgvSchedule.Name = "dgvSchedule";
			this.dgvSchedule.Size = new System.Drawing.Size(759, 189);
			this.dgvSchedule.TabIndex = 10;
			this.dgvSchedule.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellEnter);
			this.dgvSchedule.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSchedule_CellFormatting);
			this.dgvSchedule.DoubleClick += new System.EventHandler(this.dgvSchedule_DoubleClick);
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.panel9.Controls.Add(this.lbScheduleHeader);
			this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel9.Location = new System.Drawing.Point(2, 2);
			this.panel9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel9.Name = "panel9";
			this.panel9.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.panel9.Size = new System.Drawing.Size(759, 42);
			this.panel9.TabIndex = 9;
			// 
			// lbScheduleHeader
			// 
			this.lbScheduleHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.lbScheduleHeader.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbScheduleHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbScheduleHeader.ForeColor = System.Drawing.Color.White;
			this.lbScheduleHeader.Location = new System.Drawing.Point(2, 3);
			this.lbScheduleHeader.Name = "lbScheduleHeader";
			this.lbScheduleHeader.Size = new System.Drawing.Size(725, 36);
			this.lbScheduleHeader.TabIndex = 8;
			this.lbScheduleHeader.Text = "กำหนดการซ่อมบำรุง";
			this.lbScheduleHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlScheduleCommand
			// 
			this.pnlScheduleCommand.Controls.Add(this.panel11);
			this.pnlScheduleCommand.Controls.Add(this.panel10);
			this.pnlScheduleCommand.Controls.Add(this.panel8);
			this.pnlScheduleCommand.Controls.Add(this.panel7);
			this.pnlScheduleCommand.Controls.Add(this.panel6);
			this.pnlScheduleCommand.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlScheduleCommand.Location = new System.Drawing.Point(761, 2);
			this.pnlScheduleCommand.Name = "pnlScheduleCommand";
			this.pnlScheduleCommand.Padding = new System.Windows.Forms.Padding(2);
			this.pnlScheduleCommand.Size = new System.Drawing.Size(140, 231);
			this.pnlScheduleCommand.TabIndex = 1;
			// 
			// panel11
			// 
			this.panel11.Controls.Add(this.btnMatchingJob);
			this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel11.Location = new System.Drawing.Point(2, 162);
			this.panel11.Name = "panel11";
			this.panel11.Padding = new System.Windows.Forms.Padding(5);
			this.panel11.Size = new System.Drawing.Size(136, 40);
			this.panel11.TabIndex = 9;
			// 
			// btnMatchingJob
			// 
			this.btnMatchingJob.BackColor = System.Drawing.SystemColors.Control;
			this.btnMatchingJob.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMatchingJob.ForeColor = System.Drawing.Color.Black;
			this.btnMatchingJob.Location = new System.Drawing.Point(5, 5);
			this.btnMatchingJob.Name = "btnMatchingJob";
			this.btnMatchingJob.Size = new System.Drawing.Size(126, 30);
			this.btnMatchingJob.TabIndex = 0;
			this.btnMatchingJob.Text = "ค้นหางาน";
			this.btnMatchingJob.UseVisualStyleBackColor = false;
			this.btnMatchingJob.Click += new System.EventHandler(this.btnMatchingJob_Click);
			// 
			// panel10
			// 
			this.panel10.Controls.Add(this.btnOpenServiceOrder);
			this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel10.Location = new System.Drawing.Point(2, 122);
			this.panel10.Name = "panel10";
			this.panel10.Padding = new System.Windows.Forms.Padding(5);
			this.panel10.Size = new System.Drawing.Size(136, 40);
			this.panel10.TabIndex = 8;
			// 
			// btnOpenServiceOrder
			// 
			this.btnOpenServiceOrder.BackColor = System.Drawing.SystemColors.Control;
			this.btnOpenServiceOrder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnOpenServiceOrder.ForeColor = System.Drawing.Color.Black;
			this.btnOpenServiceOrder.Location = new System.Drawing.Point(5, 5);
			this.btnOpenServiceOrder.Name = "btnOpenServiceOrder";
			this.btnOpenServiceOrder.Size = new System.Drawing.Size(126, 30);
			this.btnOpenServiceOrder.TabIndex = 0;
			this.btnOpenServiceOrder.Text = "เปิดใบงาน";
			this.btnOpenServiceOrder.UseVisualStyleBackColor = false;
			this.btnOpenServiceOrder.Click += new System.EventHandler(this.btnOpenServiceOrder_Click);
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.btnDeleteSchedule);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(2, 82);
			this.panel8.Name = "panel8";
			this.panel8.Padding = new System.Windows.Forms.Padding(5);
			this.panel8.Size = new System.Drawing.Size(136, 40);
			this.panel8.TabIndex = 7;
			// 
			// btnDeleteSchedule
			// 
			this.btnDeleteSchedule.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDeleteSchedule.ForeColor = System.Drawing.Color.Black;
			this.btnDeleteSchedule.Location = new System.Drawing.Point(5, 5);
			this.btnDeleteSchedule.Name = "btnDeleteSchedule";
			this.btnDeleteSchedule.Size = new System.Drawing.Size(126, 30);
			this.btnDeleteSchedule.TabIndex = 0;
			this.btnDeleteSchedule.Text = "&Delete Schedule";
			this.btnDeleteSchedule.UseVisualStyleBackColor = false;
			this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
			// 
			// panel7
			// 
			this.panel7.Controls.Add(this.btnEditSchedule);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(2, 42);
			this.panel7.Name = "panel7";
			this.panel7.Padding = new System.Windows.Forms.Padding(5);
			this.panel7.Size = new System.Drawing.Size(136, 40);
			this.panel7.TabIndex = 6;
			// 
			// btnEditSchedule
			// 
			this.btnEditSchedule.BackColor = System.Drawing.SystemColors.Control;
			this.btnEditSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnEditSchedule.ForeColor = System.Drawing.Color.Black;
			this.btnEditSchedule.Location = new System.Drawing.Point(5, 5);
			this.btnEditSchedule.Name = "btnEditSchedule";
			this.btnEditSchedule.Size = new System.Drawing.Size(126, 30);
			this.btnEditSchedule.TabIndex = 0;
			this.btnEditSchedule.Text = "&Modify";
			this.btnEditSchedule.UseVisualStyleBackColor = false;
			this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btnAddSchedule);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel6.Location = new System.Drawing.Point(2, 2);
			this.panel6.Name = "panel6";
			this.panel6.Padding = new System.Windows.Forms.Padding(5);
			this.panel6.Size = new System.Drawing.Size(136, 40);
			this.panel6.TabIndex = 5;
			// 
			// btnAddSchedule
			// 
			this.btnAddSchedule.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnAddSchedule.ForeColor = System.Drawing.Color.Black;
			this.btnAddSchedule.Location = new System.Drawing.Point(5, 5);
			this.btnAddSchedule.Name = "btnAddSchedule";
			this.btnAddSchedule.Size = new System.Drawing.Size(126, 30);
			this.btnAddSchedule.TabIndex = 0;
			this.btnAddSchedule.Text = "&Add Schedule";
			this.btnAddSchedule.UseVisualStyleBackColor = false;
			this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.Color.White;
			this.panel1.Location = new System.Drawing.Point(2, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(903, 45);
			this.panel1.TabIndex = 5;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(761, 2);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(5);
			this.panel2.Size = new System.Drawing.Size(140, 41);
			this.panel2.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.SystemColors.Control;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnClose.ForeColor = System.Drawing.Color.Black;
			this.btnClose.Location = new System.Drawing.Point(5, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(130, 31);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(229, 41);
			this.label1.TabIndex = 0;
			this.label1.Text = "เครื่องจักรในสัญญา PM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(913, 512);
			this.Controls.Add(this.pnlBody);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "PM";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.Text = "สัญญางานบริการ (PM)";
			this.Load += new System.EventHandler(this.PM_Load);
			this.pnlBody.ResumeLayout(false);
			this.pnlMachine.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.pnlMachineCommand.ResumeLayout(false);
			this.pnlBottomBar.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlSchedule.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
			this.panel9.ResumeLayout(false);
			this.pnlScheduleCommand.ResumeLayout(false);
			this.panel11.ResumeLayout(false);
			this.panel10.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel pnlBody;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlMachine;
		private System.Windows.Forms.Panel pnlMachineCommand;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel pnlSchedule;
		private System.Windows.Forms.Panel pnlScheduleCommand;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnReloadPM;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button btnDeleteMachine;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnEditMachine;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button btnDeleteSchedule;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button btnEditSchedule;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btnAddSchedule;
		private System.Windows.Forms.Panel pnlBottomBar;
		private System.Windows.Forms.Label lbMachineId;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Label lbScheduleHeader;
		private System.Windows.Forms.DataGridView dgvSchedule;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Button btnOpenServiceOrder;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Button btnMatchingJob;
	}
}