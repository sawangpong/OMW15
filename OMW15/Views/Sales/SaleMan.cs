using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class SaleMan : Form
	{
		#region class field members

		private readonly ActionMode _masterMode = ActionMode.Recording;

		#endregion

		public SaleMan(ActionMode Mode = ActionMode.Recording)
		{
			InitializeComponent();
			_masterMode = Mode;
		}

		private void SaleMan_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			SalePersonId = 0;
			tsbtnRefresh.PerformClick();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetSaleManList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			SalePersonId = Convert.ToInt32(dgv["SALEID", e.RowIndex].Value);
			SaleEmail = dgv["EMAIL", e.RowIndex].Value.ToString();
			SaleContactNumber = dgv["SALECONTACTNO", e.RowIndex].Value.ToString();
			SalePersonName = dgv["SAlEMAN", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			SalemanInfo(SalePersonId = 0);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			SalemanInfo(SalePersonId);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			if (_masterMode == ActionMode.Recording)
				tsbtnEdit.PerformClick();
			else if (_masterMode == ActionMode.Selection)
				btnSelect.PerformClick();
		}

		#region class property

		public int SalePersonId { get; set; }

		public string SalePersonName { get; set; }

		public string SaleContactNumber { get; set; }

		public string SaleEmail { get; set; }

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			pnlCommand.Visible = _masterMode == ActionMode.Selection;
			st.Visible = !pnlCommand.Visible;

			tsbtnEdit.Enabled = SalePersonId > 0;
		} // end UpdateUI

		private void GetSaleManList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SalemanDAL().GetSalePersonList();

			dgv.Columns["SALEID"].Visible = false;
			dgv.Columns["EMAIL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();

			UpdateUI();
		} // end GetSaleManList

		private void SalemanInfo(int Id)
		{
			using (var _info = new SalemanInfo(Id))
			{
				_info.StartPosition = FormStartPosition.CenterScreen;

				if (_info.ShowDialog(this) == DialogResult.OK)
				{
				}
			}

			tsbtnRefresh.PerformClick();
		} // end SalemanInfo

		#endregion
	}
}