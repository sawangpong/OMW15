﻿namespace OMW15.Views.Productions
{
	partial class ProductionFormula
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductionFormula));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSearch = new OMControls.OMFlatButton();
			this.txtFormulaFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lbTitle = new System.Windows.Forms.Label();
			this.panelLeft = new System.Windows.Forms.Panel();
			this.dgvFormula = new System.Windows.Forms.DataGridView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panelRight = new System.Windows.Forms.Panel();
			this.panelRightHeader = new System.Windows.Forms.Panel();
			this.btnCalBOM = new System.Windows.Forms.Button();
			this.txtProductionQty = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lbFormulaTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbBOMItem = new System.Windows.Forms.Label();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.panel1.SuspendLayout();
			this.panelLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).BeginInit();
			this.panelRight.SuspendLayout();
			this.panelRightHeader.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(68)))));
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.txtFormulaFilter);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.lbTitle);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.ForeColor = System.Drawing.Color.Gainsboro;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1164, 80);
			this.panel1.TabIndex = 0;
			this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
			// 
			// btnSearch
			// 
			this.btnSearch.FlatAppearance.BorderSize = 0;
			this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
			this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
			this.btnSearch.Location = new System.Drawing.Point(444, 44);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(23, 23);
			this.btnSearch.TabIndex = 4;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtFormulaFilter
			// 
			this.txtFormulaFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtFormulaFilter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtFormulaFilter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFormulaFilter.Location = new System.Drawing.Point(179, 44);
			this.txtFormulaFilter.MaxLength = 100;
			this.txtFormulaFilter.Name = "txtFormulaFilter";
			this.txtFormulaFilter.Size = new System.Drawing.Size(258, 22);
			this.txtFormulaFilter.TabIndex = 3;
			this.txtFormulaFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFormularFilter_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(142, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Master BOM  formula :";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Image = global::OMW15.Properties.Resources.clear_white_24;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(1062, 44);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(90, 25);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbTitle.Location = new System.Drawing.Point(3, 9);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(245, 32);
			this.lbTitle.TabIndex = 0;
			this.lbTitle.Text = "Bill of Material (BOM)";
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.dgvFormula);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 80);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Padding = new System.Windows.Forms.Padding(4);
			this.panelLeft.Size = new System.Drawing.Size(384, 544);
			this.panelLeft.TabIndex = 1;
			// 
			// dgvFormula
			// 
			this.dgvFormula.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFormula.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFormula.Location = new System.Drawing.Point(4, 4);
			this.dgvFormula.Name = "dgvFormula";
			this.dgvFormula.Size = new System.Drawing.Size(376, 536);
			this.dgvFormula.TabIndex = 1;
			this.dgvFormula.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFormular_CellEnter);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(384, 80);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 544);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.dgv);
			this.panelRight.Controls.Add(this.panel2);
			this.panelRight.Controls.Add(this.panelRightHeader);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRight.Location = new System.Drawing.Point(392, 80);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(772, 544);
			this.panelRight.TabIndex = 3;
			// 
			// panelRightHeader
			// 
			this.panelRightHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
			this.panelRightHeader.Controls.Add(this.btnCalBOM);
			this.panelRightHeader.Controls.Add(this.txtProductionQty);
			this.panelRightHeader.Controls.Add(this.label2);
			this.panelRightHeader.Controls.Add(this.lbFormulaTitle);
			this.panelRightHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelRightHeader.Location = new System.Drawing.Point(0, 0);
			this.panelRightHeader.Name = "panelRightHeader";
			this.panelRightHeader.Size = new System.Drawing.Size(772, 40);
			this.panelRightHeader.TabIndex = 0;
			// 
			// btnCalBOM
			// 
			this.btnCalBOM.FlatAppearance.BorderSize = 0;
			this.btnCalBOM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.btnCalBOM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(12)))), ((int)(((byte)(60)))));
			this.btnCalBOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCalBOM.ForeColor = System.Drawing.Color.Gainsboro;
			this.btnCalBOM.Location = new System.Drawing.Point(422, 9);
			this.btnCalBOM.Name = "btnCalBOM";
			this.btnCalBOM.Size = new System.Drawing.Size(101, 25);
			this.btnCalBOM.TabIndex = 5;
			this.btnCalBOM.Text = "Calculate";
			this.btnCalBOM.UseVisualStyleBackColor = true;
			this.btnCalBOM.Click += new System.EventHandler(this.btnCalBOM_Click);
			// 
			// txtProductionQty
			// 
			this.txtProductionQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtProductionQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtProductionQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtProductionQty.Location = new System.Drawing.Point(316, 11);
			this.txtProductionQty.MaxLength = 10;
			this.txtProductionQty.Name = "txtProductionQty";
			this.txtProductionQty.Size = new System.Drawing.Size(102, 22);
			this.txtProductionQty.TabIndex = 4;
			this.txtProductionQty.Text = "0";
			this.txtProductionQty.TextChanged += new System.EventHandler(this.txtProductionQty_TextChanged);
			this.txtProductionQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProductionQty_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Gainsboro;
			this.label2.Location = new System.Drawing.Point(138, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(172, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "Production require Qty:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbFormulaTitle
			// 
			this.lbFormulaTitle.AutoSize = true;
			this.lbFormulaTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbFormulaTitle.ForeColor = System.Drawing.Color.Gainsboro;
			this.lbFormulaTitle.Location = new System.Drawing.Point(12, 11);
			this.lbFormulaTitle.Name = "lbFormulaTitle";
			this.lbFormulaTitle.Size = new System.Drawing.Size(110, 21);
			this.lbFormulaTitle.TabIndex = 0;
			this.lbFormulaTitle.Text = "Formula items";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
			this.panel2.Controls.Add(this.lbBOMItem);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 524);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(772, 20);
			this.panel2.TabIndex = 3;
			// 
			// lbBOMItem
			// 
			this.lbBOMItem.AutoSize = true;
			this.lbBOMItem.Dock = System.Windows.Forms.DockStyle.Left;
			this.lbBOMItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbBOMItem.ForeColor = System.Drawing.Color.Gainsboro;
			this.lbBOMItem.Location = new System.Drawing.Point(0, 0);
			this.lbBOMItem.Name = "lbBOMItem";
			this.lbBOMItem.Size = new System.Drawing.Size(76, 13);
			this.lbBOMItem.TabIndex = 0;
			this.lbBOMItem.Text = "found: 0 item";
			// 
			// dgv
			// 
			this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.Location = new System.Drawing.Point(0, 40);
			this.dgv.Name = "dgv";
			this.dgv.Size = new System.Drawing.Size(772, 484);
			this.dgv.TabIndex = 4;
			// 
			// ProductionFormula
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(1164, 624);
			this.Controls.Add(this.panelRight);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panelLeft);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "ProductionFormula";
			this.Text = "BOM";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFormula)).EndInit();
			this.panelRight.ResumeLayout(false);
			this.panelRightHeader.ResumeLayout(false);
			this.panelRightHeader.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Button btnClose;
		private OMControls.OMFlatButton btnSearch;
		private System.Windows.Forms.TextBox txtFormulaFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.DataGridView dgvFormula;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Panel panelRightHeader;
		private System.Windows.Forms.Label lbFormulaTitle;
		private System.Windows.Forms.Button btnCalBOM;
		private System.Windows.Forms.TextBox txtProductionQty;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgv;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lbBOMItem;
	}
}