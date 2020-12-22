using System;
using System.Text;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CustomerModel;
using OMW15.Shared;

namespace OMW15.Views.CustomerView
{
	public partial class CustomerSearch : Form
	{
		private void CustomerSearch_Load(object sender, EventArgs e)
		{
			// format DataGridView
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			rdoSearchByName.Checked = true;
			UpdateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				var _add = new StringBuilder();
				ERPCustomerCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
				CustomerName = dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();
				ERPCustomerId = Convert.ToInt32(dgv["ERPCUSTOMERID", e.RowIndex].Value);
				Phone = dgv["PHONE", e.RowIndex].Value.ToString();
				Fax = dgv["FAX", e.RowIndex].Value.ToString();
				Email = dgv["EMAIL", e.RowIndex].Value.ToString();
				Postal = dgv["POSTAL", e.RowIndex].Value.ToString();
				InternalCustomerId = Convert.ToInt32(dgv["CUSTOMERID", e.RowIndex].Value);

				_add.AppendLine(dgv["ADDRESS1", e.RowIndex].Value.ToString());
				_add.AppendLine(dgv["ADDRESS2", e.RowIndex].Value.ToString());
				_add.AppendLine($"{ dgv["DISTRICT", e.RowIndex].Value}, {dgv["PROVINCE", e.RowIndex].Value}, {dgv["POSTAL", e.RowIndex].Value}");
				_add.AppendLine(dgv["PHONE", e.RowIndex].Value.ToString());
				CustomerAddress = _add.ToString();
				lbCustCode.Text = ERPCustomerCode;
				lbCustName.Text = CustomerName;
			}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void searchBox1_OnSendingFiler(string FilterString)
		{
			GetCustomerListAsync(_option, FilterString);
		}

		private void rdoSearch_CheckedChanged(object sender, EventArgs e)
		{
			var rdo = sender as RadioButton;
			if (rdo.Checked)
				switch (rdo.Tag.ToString())
				{
					case "BY_CODE":
						_option = OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerCode;
						break;
					case "BY_NAME":
						_option = OMShareCustomerEnums.CustomerSearchOptions.SearchByCustomerName;
						break;
				}

			UpdateUI();
		}

		#region class Field member

		private int _rowCount;
		private OMShareCustomerEnums.CustomerSearchOptions _option = OMShareCustomerEnums.CustomerSearchOptions.SearchNone;

		private readonly string _filterText = string.Empty;

		#endregion

		#region class property

		public int InternalCustomerId { get; set; }

		public string ERPCustomerCode { get; set; }

		public int ERPCustomerId { get; set; }

		public string CustomerName { get; set; }

		public string CustomerAddress { get; set; }

		public string Country { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Postal { get; set; }

		#endregion

		#region class method

		private void UpdateUI()
		{
		} // end UpdateUI


		private async void GetCustomerListAsync(OMShareCustomerEnums.CustomerSearchOptions Option, string Key)
		{
			var _dal = new CustomerDAL();
			//var dt = await _dal.GetCustomerListAsync(Option, Key);
			var dt = await _dal.GetMasterCustomerAsync(omglobal.SysConnectionString, Key, Option);
			_rowCount = dt.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = dt;

			// formating ColumnHeader
			dgv.Columns["CATEGORYKEY"].Visible = false;
			dgv.Columns["CUSTOMERID"].Visible = false;
			dgv.Columns["ERPCUSTOMERID"].Visible = false;
			dgv.Columns["CUSTOMERCATEGORYKEY"].Visible = false;
			dgv.Columns["CUSTOMERNAME"].HeaderText = "Customer Name";

			dgv.ResumeLayout();

			lbMatch.Text = $"match found:: {dgv.Rows.Count}";
		}

		#endregion

		#region constructor

		public CustomerSearch()
		{
			InitializeComponent();
		}


		public CustomerSearch(string Filter, OMShareCustomerEnums.CustomerSearchOptions SearchOption)
		{
			CenterToParent();
			InitializeComponent();

			_filterText = string.IsNullOrEmpty(Filter) ? string.Empty : Filter;

			searchBox1.TextFilter = _filterText;
			_option = SearchOption;
		}

		#endregion

	}
}