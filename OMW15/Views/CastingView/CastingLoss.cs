using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class CastingLoss : Form
	{
		public CastingLoss()
		{
			InitializeComponent();
		}

		private void CastingLoss_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetYearList();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxFiscYear_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selecedFiscYear = Convert.ToInt32(tscbxFiscYear.ComboBox.SelectedValue);
			}
			catch
			{
				_selecedFiscYear = DateTime.Today.Year;
			}

			ShowLossData(_selecedFiscYear);
		}

		#region class field member

		private string _matCatName = string.Empty;
		private int _selecedFiscYear = DateTime.Today.Year;

		#endregion

		#region class helper

		private void UpdateUI()
		{
		}


		private void GetYearList()
		{
			tscbxFiscYear.ComboBox.DataSource = new CastingTreeController().GetYearCastingWaxTree();
			tscbxFiscYear.ComboBox.DisplayMember = "FY";
			tscbxFiscYear.ComboBox.ValueMember = "FY";
		} // end GetYearList

		private async void ShowLossData(int Fiscyear)
		{
			var _dal = new CastingTreeController();
			var _dt = await _dal.GetAsyncYearSummaryLossCasting(Fiscyear);

			dgv.SuspendLayout();
			dgv.DataSource = _dt;
			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
					dgc.DefaultCellStyle.Format = "P2";
				}

			dgv.ResumeLayout();
		} // end ShowLossData

		#endregion
	}
}