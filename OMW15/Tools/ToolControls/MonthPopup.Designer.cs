namespace OMW15.Tools.ToolControls
{
	partial class MonthPopup
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
			this.btnMonth = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnMonth
			// 
			this.btnMonth.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnMonth.Font = new System.Drawing.Font("Leelawadee", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.btnMonth.Image = global::OMW15.Properties.Resources.MonthlyViewHS;
			this.btnMonth.Location = new System.Drawing.Point(0, 0);
			this.btnMonth.Name = "btnMonth";
			this.btnMonth.Size = new System.Drawing.Size(34, 30);
			this.btnMonth.TabIndex = 0;
			this.btnMonth.UseVisualStyleBackColor = true;
			this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
			// 
			// MonthPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnMonth);
			this.Name = "MonthPopup";
			this.Size = new System.Drawing.Size(34, 30);
			this.Load += new System.EventHandler(this.MonthPopup_Load);
			this.SizeChanged += new System.EventHandler(this.MonthPopup_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnMonth;
	}
}
