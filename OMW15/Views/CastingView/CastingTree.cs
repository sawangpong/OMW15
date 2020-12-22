using System;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingTree : Form
	{
		public CastingTree()
		{
			InitializeComponent();
		}

		#region class property

		public DateTime CurrentDate
		{
			get; set;
		}

		#endregion

		private void CastingTree_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			OMUtils.SettingDataGridView(ref dgvSum);
			dtp.Value = DateTime.Today;
		}

		private void dtp_DateSelected(object sender, EventArgs e)
		{
			_selectedCurrentDate = dtp.Value;
			DisplayData(_selectedCurrentDate);
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if(Convert.ToDecimal(dgv.Rows[e.RowIndex].Cells["RealLoss"].Value) > omglobal.DEFAULT_AVG_MAT_LOSS)
			{
				e.CellStyle.BackColor = Color.Orange;
				e.CellStyle.ForeColor = Color.Black;
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
			}
		}

		private void dtp_TextChanged(object sender, EventArgs e)
		{
			_selectedCurrentDate = dtp.Value;
			DisplayData(_selectedCurrentDate);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedWaxTreeId = Convert.ToInt32(dgv["TREEID", e.RowIndex].Value);

			tslbTreeId.Text = _selectedWaxTreeId.ToString();

			UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetWaxTreeInfo(_selectedWaxTreeId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedWaxTreeId = 0;
			GetWaxTreeInfo(_selectedWaxTreeId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnTotalLoss_Click(object sender, EventArgs e)
		{
			var _cl = new CastingLoss();
			_cl.MdiParent = ParentForm;
			_cl.StartPosition = FormStartPosition.CenterScreen;
			_cl.Show();
		}

		private void tsbtnTreeRefress_Click(object sender, EventArgs e)
		{
			ShowSummaryDailyCast(dtp.Value);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			DisplayData(dtp.Value);
		}

		private void tsbtnWaxTreePrint_Click(object sender, EventArgs e)
		{
			var _vrpt = new CastingReportView();
			_vrpt.PrintWhat = PrintDocumentType.WaxTreeWeight;
			_vrpt.CurrentDate = _selectedCurrentDate;

			_vrpt.MdiParent = ParentForm;
			_vrpt.Show();
		}

		#region class field member

		private DateTime _selectedCurrentDate = DateTime.Today;
		private int _selectedWaxTreeId;

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedWaxTreeId > 0;
		} // end UpdateUI

		private /*async*/ void ShowCastingTrees(DateTime SelectDate)
		{
			dgv.DataSource = null;
			var _dal = new CastingTreeController();
			var _dt = /*await*/ _dal.GetAsyncCastingTrees(SelectDate);

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			dgv.Columns["MATNAME"].Frozen = true;
			dgv.Columns["BuildWaxDate"].Visible = false;
			dgv.Columns["TREEID"].Visible = false;
			dgv.Columns["MatId"].Visible = false;
			dgv.Columns["REALLOSS"].Visible = false;

			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if(dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = dgc.Name == "Loss" ? "P2" : "N2";
				}
			}
			dgv.ResumeLayout();

		} // end ShowCastingTrees

		private /*async*/ void ShowSummaryDailyCast(DateTime CurrentDate)
		{
			dgvSum.DataSource = null;
			var _dal = new CastingTreeController();
			var _dt = /*await*/ _dal.GetAsyncDailySummaryCastingInfo(CurrentDate);

			dgvSum.SuspendLayout();
			dgvSum.DataSource = _dt;
			dgvSum.Columns["Material"].Frozen = true;

			// format column header text
			foreach(DataGridViewColumn dgc in dgvSum.Columns)
			{
				switch(dgc.Name)
				{
					case "QFlask":
						dgc.HeaderText = "จำนวนเบ้า";
						break;
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

				if(dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = dgc.Name == "Loss" ? "P2" : "N2";
				}
			}

			dgvSum.AlternatingRowsDefaultCellStyle.BackColor = dgvSum.BackgroundColor;

			dgvSum.ResumeLayout();

		} // end ShowSummaryDailyCast

		private void DisplayData(DateTime CurrentDate)
		{
			// display all cast trees
			ShowCastingTrees(CurrentDate);

			// show only summary casting
			ShowSummaryDailyCast(CurrentDate);

		} // end DisplayData

		private void GetWaxTreeInfo(int TreeId)
		{
			var _treeInfo = new CastingTreeInfo();
			_treeInfo.TreeId = TreeId;
			_treeInfo.StartPosition = FormStartPosition.CenterParent;
			if(_treeInfo.ShowDialog(this) == DialogResult.OK)
			{
				tsbtnRefresh.PerformClick();
			}

		} // end GetWaxTreeInfo

		#endregion
	}
}