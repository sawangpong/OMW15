using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingView
{
	public partial class CastingCustomer : Form
	{
		#region class property

		public int CustomerId
		{
			get;
			set;
		}
		public string CustomerCode
		{
			get;
			set;
		}

		public string CustomerName
		{
			get;
			set;
		}

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			this.btnSelect.Enabled = !string.IsNullOrEmpty(this.CustomerCode);
		} // end UpdateUI

		private void CustomerList()
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Casting.CastingController.JobDAL().CastingCustomerList();
			this.dgv.ColumnHeadersVisible = false;
			this.dgv.Columns["CUSTID"].Visible = false;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.ResumeLayout();

		} // end CustomerList
		#endregion

		public CastingCustomer()
		{
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CastingCustomer_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.CustomerList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.CustomerId = Convert.ToInt32(this.dgv["CUSTID", e.RowIndex].Value);
			this.CustomerCode = this.dgv["CUSTCODE", e.RowIndex].Value.ToString();
			this.CustomerName = this.dgv["CUSTNAME", e.RowIndex].Value.ToString();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}
	}
}
