using OMW15.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class PMMCList : Form
	{
		#region class field
		private string _customerCode = string.Empty;
		private string _customer = string.Empty;

		#endregion

		#region class property

		public string Model { get; set; }
		public string SN { get; set; }

		#endregion


		#region class methods

		private async void getMCList(string customerCode)
		{
			dgv.DataSource = null;

			var _dal = new MachineDAL();
			var _dt = await _dal.GetAsyncMachineList(customerCode);

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			dgv.Columns["ID"].Visible = false;
			dgv.Columns["Transfer"].Visible = false;
			dgv.Columns["ModelId"].Visible = false;
			dgv.Columns["CustomerCode"].Visible = false;
			dgv.Columns["SellDate"].Visible = false;
			dgv.Columns["Expire"].Visible = false;

			dgv.ResumeLayout();

		}

		#endregion


		public PMMCList(string customerCode,string customer)
		{
			InitializeComponent();
			_customerCode = customerCode;
			_customer = customer;
			this.lbTitle.BackColor = omglobal.FB_BLUE;
		}

		private void PMMCList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.lbTitle.Text = $"รายการเครื่องจักร :: {_customer}";

			this.getMCList(_customerCode);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.Model = this.dgv["Model", e.RowIndex].Value.ToString();
			this.SN = this.dgv["SerialNo", e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}
	}
}
