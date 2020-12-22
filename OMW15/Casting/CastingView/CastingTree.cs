using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class CastingTree : Form
	{
		#region class field member
		private DateTime _selectedCurrentDate = DateTime.Today;
		private int _selectedWaxTreeId = 0;

		#endregion

		#region class property
		public DateTime CurrentDate
		{
			get;
			set;
		}

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			this.tsbtnEdit.Enabled = (_selectedWaxTreeId > 0);

		} // end UpdateUI

		private void ShowCastingTrees(DateTime SelectDate)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Casting.CastingController.CastingTreeController().GetCastingTrees(SelectDate);
			this.dgv.Columns["MATNAME"].Frozen = true;
			this.dgv.Columns["DATE"].Visible = false;
			this.dgv.Columns["TREEID"].Visible = false;
			this.dgv.Columns["MATID"].Visible = false;
			this.dgv.Columns["REALLOSS"].Visible = false;

			foreach (DataGridViewColumn dgc in this.dgv.Columns)
			{
				if (dgc.ValueType == typeof(System.Decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format =  (dgc.Name == "Loss") ? "P2": "N2";
				}
			}

			this.dgv.ResumeLayout();
		
		} // end ShowCastingTrees

		private void ShowSummaryDailyCast(DateTime CurrentDate)
		{
			this.dgvSum.SuspendLayout();
			this.dgvSum.DataSource = new Casting.CastingController.CastingTreeController().GetDailySummaryCastingInfo(CurrentDate);
			this.dgvSum.Columns["Material"].Frozen = true;

			foreach (DataGridViewColumn dgc in this.dgvSum.Columns)
			{
				switch (dgc.Name)
				{
					case "Material":
						dgc.HeaderText = "วัสดุ";
						break;
					case "TotalAlloy":
						dgc.HeaderText = "น.น.รวม Alloy (g)";
						break;
					case "OtherMaterial":
						dgc.HeaderText = "วัสดุอื่น";
						break;
					case "TotalOtherMat":
						dgc.HeaderText = "น.น.รวมวัสดุอื่น (g)";
						break;
					case "TotalWeightBF":
						dgc.HeaderText = "น.น.รวมก่อนหล่อ (g)";
						break;
					case "TotalActualWeight":
						dgc.HeaderText = "น.น.จริงก่อนหล่อ (g)";
						break;
					case "TotalWeightAF":
						dgc.HeaderText = "น.น.รวมหลังหล่อ (g)";
						break;
					case "WTLoss":
						dgc.HeaderText = "สูญเสีย (g)";
						break;
					case "Slag":
						dgc.HeaderText = "ขี้เบ้า (g)";
						break;
					case "Loss":
						dgc.HeaderText = "สูญเสีย %";
						break;
				}

				if (dgc.ValueType == typeof(System.Decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = (dgc.Name == "Loss") ? "P2" : "N2";
				}

				//dgc.HeaderText = dgc.Name;
			}
			this.dgvSum.AlternatingRowsDefaultCellStyle.BackColor = this.dgvSum.BackgroundColor;

			this.dgvSum.ResumeLayout();

		} // end ShowSummaryDailyCast

		private void DisplayData(DateTime CurrentDate)
		{
			// display all cast trees
			this.ShowCastingTrees(CurrentDate);

			// show only summary casting
			this.ShowSummaryDailyCast(CurrentDate);

		} // end DisplayData

		private void GetWaxTreeInfo(int TreeId)
		{
			Casting.CastingView.CastingTreeInfo _treeInfo = new CastingTreeInfo();
			_treeInfo.TreeId = TreeId;
			_treeInfo.StartPosition = FormStartPosition.CenterScreen;
			if (_treeInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.tsbtnRefresh.PerformClick();
			}
		} // end GetWaxTreeInfo

		#endregion

		public CastingTree()
		{
			InitializeComponent();
		}

		private void CastingTree_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvSum);
			this.dtp.Value = DateTime.Today;
		}

		private void dtp_DateSelected(object sender, EventArgs e)
		{
			this.tslb.Text = this.dtp.Value.ToShortDateString();
			_selectedCurrentDate = this.dtp.Value;
			this.DisplayData(_selectedCurrentDate);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (Convert.ToDecimal(this.dgv.Rows[e.RowIndex].Cells["RealLoss"].Value) > omglobal.DEFAULT_AVG_MAT_LOSS)
			{
				e.CellStyle.BackColor = Color.Orange;
				e.CellStyle.ForeColor = Color.Black;

				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
			}
		}

		private void dtp_TextChanged(object sender, EventArgs e)
		{
			_selectedCurrentDate = this.dtp.Value;
			this.DisplayData(_selectedCurrentDate);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedWaxTreeId = Convert.ToInt32(this.dgv["TREEID",e.RowIndex].Value);

			this.tslbTreeId.Text = _selectedWaxTreeId.ToString();

			this.UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.GetWaxTreeInfo(_selectedWaxTreeId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedWaxTreeId = 0;
			this.GetWaxTreeInfo(_selectedWaxTreeId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEdit.PerformClick();
		}

		private void tsbtnTotalLoss_Click(object sender, EventArgs e)
		{
			Casting.CastingView.CastingLoss _cl = new CastingLoss();
			_cl.MdiParent = this.ParentForm;
			_cl.StartPosition = FormStartPosition.CenterScreen;
			_cl.Show();
		}
	
	}
}
