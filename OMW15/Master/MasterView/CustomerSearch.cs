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

namespace OMW15.Master.MasterView
{
	public partial class CustomerSearch : Form
	{
		#region class Field member

		private CustomerSearchOptions _option = CustomerSearchOptions.SearchNone;

		#endregion

		#region class property

		public int SysCustomerId
		{
			get;
			set;
		}

		public string CustomerCode
		{
			get;
			set;
		}

		public int CustomerId
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


		#region class method

		private void UpdateUI()
		{
			this.tstxtSearchText.Enabled = ( _option != CustomerSearchOptions.SearchNone);
			this.tsbtnSearch.Enabled = !string.IsNullOrEmpty(this.tstxtSearchText.Text);
		
		} // end UpdateUI


		private void GetCustomerList(CustomerSearchOptions Option,string Key)
		{
			this.dgv.SuspendLayout();

			this.dgv.DataSource = new Master.MasterController.CustomerSearch().GetCustomerList(Option, Key);

			// formating ColumnHeader
			this.dgv.Columns["CATEGORYKEY"].Visible = false;
			this.dgv.Columns["CUSTOMERID"].Visible = false;
			this.dgv.Columns["CUSTOMERCATEGORYKEY"].Visible = false;
			this.dgv.Columns["CUSTID"].Visible = false;
			this.dgv.Columns["CUSTOMERNAME"].HeaderText = "Customer Name";


			this.dgv.ResumeLayout();
			this.tslbStatus.Text = string.Format("match found : {0}", this.dgv.Rows.Count);
		}

		#endregion

		public CustomerSearch()
		{
			InitializeComponent();
		}

		private void tsmnu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			
			// display selected menuitem on master menu
			this.tsSp1.Text = string.Format("วิธีค้นหา : {0}", _mnu.Text);

			switch(_mnu.Tag.ToString())
			{
				case "BY_NAME":
					_option = CustomerSearchOptions.SearchByCustomerName;
					break;
				case "BY_CODE":
					_option = CustomerSearchOptions.SearchByCustomerCode;
					break;
			}
			this.UpdateUI();
			this.GetCustomerList(_option, this.tstxtSearchText.Text);
		}

		private void CustomerSearch_Load(object sender, EventArgs e)
		{
			// format DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			this.UpdateUI();
		}

		private void tstxtSearchText_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)Keys.Enter)
			{
				this.tsbtnSearch.PerformClick();
			}
		}

		private void tstxtSearchText_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnSearch_Click(object sender, EventArgs e)
		{
			this.GetCustomerList(_option, this.tstxtSearchText.Text);

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.CustomerCode = this.dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
			this.CustomerName = this.dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();
			this.CustomerId = Convert.ToInt32(this.dgv["CUSTOMERID", e.RowIndex].Value);
			this.SysCustomerId = Convert.ToInt32(this.dgv["CUSTID", e.RowIndex].Value);

			this.lbCustCode.Text = this.CustomerCode;
			this.lbCustName.Text = this.CustomerName;
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect.PerformClick();
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{

		}
	}
}
