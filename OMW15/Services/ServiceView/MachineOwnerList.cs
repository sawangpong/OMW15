using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Services.ServiceView
{
	public partial class MachineOwnerList : Form
	{
		private DataTable _source;

		public string OwnerCode
		{
			get;
			set;
		}

		public string OwnerName
		{
			get;
			set;
		}

		public string SerialNo
		{
			get;
			set;
		}

		private void UpdateUI()
		{
			this.tsbtnSelect.Enabled = !string.IsNullOrEmpty(this.OwnerCode);

		} // end UpdateUI

		private void GetOwnerList(DataTable Source)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = Source;

			this.dgv.Columns["ACTIVE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.Columns["CHANGEOWNER"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			this.dgv.ResumeLayout();

		} // end DisplayOwnerList

		public MachineOwnerList(DataTable Source)
		{
			InitializeComponent();
			_source = Source;
		}

		private void MachineOwnerList_Load(object sender, EventArgs e)
		{
			// formatting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			this.tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.OwnerCode = this.dgv["OWNERCODE", e.RowIndex].Value.ToString();
			this.OwnerName = this.dgv["OWNER", e.RowIndex].Value.ToString();
			this.SerialNo = this.dgv["SERIALNO", e.RowIndex].Value.ToString();
			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OwnerCode = string.Empty;
			this.OwnerName = string.Empty;
			this.SerialNo = string.Empty;
			this.Close();
		}

		private void tsbtnSelect_Click(object sender, EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Close();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnSelect.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetOwnerList(_source);
		}
	}
}
