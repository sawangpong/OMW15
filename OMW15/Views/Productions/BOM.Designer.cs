namespace OMW15.Views.Productions
{
	partial class BOM
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
			this.lbSelectedItemId = new System.Windows.Forms.Label();
			this.lbNodeCount = new System.Windows.Forms.Label();
			this.pmlMessage = new System.Windows.Forms.Panel();
			this.lbNodeId = new System.Windows.Forms.Label();
			this.tvBom = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lvBom = new System.Windows.Forms.ListView();
			this.pnlList = new System.Windows.Forms.Panel();
			this.cbxModel = new System.Windows.Forms.ComboBox();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnClose = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pmlMessage.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlList.SuspendLayout();
			this.mainPanel.SuspendLayout();
			this.panel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbSelectedItemId
			// 
			this.lbSelectedItemId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbSelectedItemId.Location = new System.Drawing.Point(250, 0);
			this.lbSelectedItemId.Name = "lbSelectedItemId";
			this.lbSelectedItemId.Size = new System.Drawing.Size(375, 24);
			this.lbSelectedItemId.TabIndex = 2;
			this.lbSelectedItemId.Text = "0";
			this.lbSelectedItemId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lbNodeCount
			// 
			this.lbNodeCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbNodeCount.Location = new System.Drawing.Point(0, 0);
			this.lbNodeCount.Name = "lbNodeCount";
			this.lbNodeCount.Size = new System.Drawing.Size(157, 24);
			this.lbNodeCount.TabIndex = 0;
			this.lbNodeCount.Text = "count";
			this.lbNodeCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pmlMessage
			// 
			this.pmlMessage.Controls.Add(this.lbSelectedItemId);
			this.pmlMessage.Controls.Add(this.lbNodeId);
			this.pmlMessage.Controls.Add(this.lbNodeCount);
			this.pmlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pmlMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.pmlMessage.Location = new System.Drawing.Point(2, 494);
			this.pmlMessage.Name = "pmlMessage";
			this.pmlMessage.Size = new System.Drawing.Size(845, 24);
			this.pmlMessage.TabIndex = 1;
			// 
			// lbNodeId
			// 
			this.lbNodeId.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbNodeId.Location = new System.Drawing.Point(157, 0);
			this.lbNodeId.Name = "lbNodeId";
			this.lbNodeId.Size = new System.Drawing.Size(93, 24);
			this.lbNodeId.TabIndex = 1;
			this.lbNodeId.Text = "0";
			this.lbNodeId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tvBom
			// 
			this.tvBom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvBom.Location = new System.Drawing.Point(2, 2);
			this.tvBom.Name = "tvBom";
			this.tvBom.Size = new System.Drawing.Size(378, 488);
			this.tvBom.TabIndex = 0;
			this.tvBom.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvBom_NodeMouseClick);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(384, 2);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 492);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tvBom);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(2, 2);
			this.panel3.Name = "panel3";
			this.panel3.Padding = new System.Windows.Forms.Padding(2);
			this.panel3.Size = new System.Drawing.Size(382, 492);
			this.panel3.TabIndex = 2;
			// 
			// lvBom
			// 
			this.lvBom.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lvBom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvBom.FullRowSelect = true;
			this.lvBom.HideSelection = false;
			this.lvBom.HoverSelection = true;
			this.lvBom.Location = new System.Drawing.Point(0, 0);
			this.lvBom.MultiSelect = false;
			this.lvBom.Name = "lvBom";
			this.lvBom.Size = new System.Drawing.Size(457, 492);
			this.lvBom.TabIndex = 0;
			this.lvBom.UseCompatibleStateImageBehavior = false;
			this.lvBom.View = System.Windows.Forms.View.Details;
			// 
			// pnlList
			// 
			this.pnlList.Controls.Add(this.lvBom);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.Location = new System.Drawing.Point(390, 2);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(457, 492);
			this.pnlList.TabIndex = 4;
			// 
			// cbxModel
			// 
			this.cbxModel.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxModel.FormattingEnabled = true;
			this.cbxModel.Location = new System.Drawing.Point(106, 2);
			this.cbxModel.Name = "cbxModel";
			this.cbxModel.Size = new System.Drawing.Size(185, 25);
			this.cbxModel.TabIndex = 1;
			this.cbxModel.SelectionChangeCommitted += new System.EventHandler(this.cbxModel_SelectionChangeCommitted);
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.pnlList);
			this.mainPanel.Controls.Add(this.splitter1);
			this.mainPanel.Controls.Add(this.panel3);
			this.mainPanel.Controls.Add(this.pmlMessage);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 68);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(2);
			this.mainPanel.Size = new System.Drawing.Size(849, 520);
			this.mainPanel.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Left;
			this.label2.Location = new System.Drawing.Point(2, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 24);
			this.label2.TabIndex = 0;
			this.label2.Text = "Select Model : ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.cbxModel);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 40);
			this.panel2.Name = "panel2";
			this.panel2.Padding = new System.Windows.Forms.Padding(2);
			this.panel2.Size = new System.Drawing.Size(849, 28);
			this.panel2.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Left;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 36);
			this.label1.TabIndex = 0;
			this.label1.Text = "BOM";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnClose
			// 
			this.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnClose.Name = "tsbtnClose";
			this.tsbtnClose.Size = new System.Drawing.Size(52, 33);
			this.tsbtnClose.Text = "&Close";
			this.tsbtnClose.Click += new System.EventHandler(this.tsbtnClose_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.AutoSize = false;
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(70, 37);
			this.tsbtnEdit.Text = "Edit";
			this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnEdit,
            this.toolStripSeparator1,
            this.tsbtnClose,
            this.toolStripSeparator2});
			this.toolStrip1.Location = new System.Drawing.Point(79, 2);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(768, 36);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(155)))));
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(2);
			this.panel1.Size = new System.Drawing.Size(849, 40);
			this.panel1.TabIndex = 3;
			// 
			// BOM
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(849, 588);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "BOM";
			this.Text = "BOM";
			this.Load += new System.EventHandler(this.BOM_Load);
			this.pmlMessage.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.pnlList.ResumeLayout(false);
			this.mainPanel.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbSelectedItemId;
		private System.Windows.Forms.Label lbNodeCount;
		private System.Windows.Forms.Panel pmlMessage;
		private System.Windows.Forms.Label lbNodeId;
		private System.Windows.Forms.TreeView tvBom;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ListView lvBom;
		private System.Windows.Forms.Panel pnlList;
		private System.Windows.Forms.ComboBox cbxModel;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnClose;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Panel panel1;
	}
}