using System;
using System.Data;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Views.ServiceView
{
	public partial class MachineOwnerList : Form
	{
		private readonly DataTable _source;

		public MachineOwnerList(DataTable Source)
		{
			InitializeComponent();
			_source = Source;
		}

		public string OwnerCode { get; set; }

		public string OwnerName { get; set; }

		public string SerialNo { get; set; }

		private void UpdateUI()
		{
			tsbtnSelect.Enabled = !string.IsNullOrEmpty(OwnerCode);
		} // end UpdateUI

		private void GetOwnerList(DataTable Source)
		{
			dgv.SuspendLayout();
			dgv.DataSource = Source;

			dgv.Columns["ACTIVE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["CHANGEOWNER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.ResumeLayout();
		} // end DisplayOwnerList

		private void MachineOwnerList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// formatting DataGridView
			OMUtils.SettingDataGridView(ref dgv);

			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			OwnerCode = dgv["OWNERCODE", e.RowIndex].Value.ToString();
			OwnerName = dgv["OWNER", e.RowIndex].Value.ToString();
			SerialNo = dgv["SERIALNO", e.RowIndex].Value.ToString();
			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			OwnerCode = string.Empty;
			OwnerName = string.Empty;
			SerialNo = string.Empty;
			Close();
		}

		private void tsbtnSelect_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnSelect.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetOwnerList(_source);
		}
	}
}