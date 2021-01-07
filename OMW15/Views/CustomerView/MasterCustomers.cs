using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CustomerModel;
using OMW15.Shared;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static OMW15.Shared.OMShareCustomerEnums;

namespace OMW15.Views.CustomerView
{
	public partial class MasterCustomers : Form
	{
		#region Singleton
		public static MasterCustomers _instance;
		public static MasterCustomers GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new MasterCustomers();
				return _instance;
			}
		}

		#endregion

		#region class field member

		private enum _CustomerUpdate
		{
			UpdateFromEntry,
			UpdateByRequested
		}

		private _CustomerUpdate _customerUpdateMode = _CustomerUpdate.UpdateByRequested;
		private OMShareCustomerEnums.MasterCustomerAction _action = OMShareCustomerEnums.MasterCustomerAction.None;
		private DataTable _customerTable = new DataTable();
		private DateTime _startTime = DateTime.Now;
		private bool _showProgressBar;
		private string _recordMode = string.Empty;
		private int _updateRowCount;
		private int _maxProgress;
		private int _rowCount;

		#endregion


		// CONSTRUCTOR
		public MasterCustomers()
		{
			InitializeComponent();
			SetStyle(ControlStyles.AllPaintingInWmPaint
					| ControlStyles.OptimizedDoubleBuffer
					| ControlStyles.ResizeRedraw
					| ControlStyles.UserPaint, true);
		}

		private void MasterCustomers_Load(object sender, EventArgs e)
		{
			// format DataGridGiew
			OMUtils.SettingDataGridView(ref dgv);

			// Load Customer Category Menu
			LoadCustomerCategoryMenuItem();

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsmnuCustomers_Click(object sender, EventArgs e)
		{
			var _tsmnu = sender as ToolStripMenuItem;
			tsmnuView.Text = $"[รายชื่อลูกค้า] >>> {_tsmnu.Text}";

			var _filter = string.Empty;

			switch (_tsmnu.Tag.ToString().ToUpper())
			{
				case "ALL_CUST":
					_filter = "";
					break;
				case "BY_NAME":
					_filter = GetCustomerFilter("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
					break;
			}

			getMasterCustomerAsync(_filter, _action);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// get selected customer row (key)
			//if (_rowCount == dgv.Rows.Count)
			//{
			SelectedCustomerCode = dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
			SelectedCustomerName = dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();
			SelectedCustomerId = Convert.ToInt32(dgv["CUSTOMERID", e.RowIndex].Value);
			//}
			// updating UI
			lb.Text = $"Id:{SelectedCustomerId}, Code:{SelectedCustomerCode}";
			UpdateUI();
		}

		private void tsbtnUpdateLocalCustomeDB_Click(object sender, EventArgs e)
		{
			// specify customer update mode
			_customerUpdateMode = _CustomerUpdate.UpdateByRequested;

			_showProgressBar = true;
			_startTime = DateTime.Now;
			pgb.Maximum = 100;
			pgb.Minimum = 0;
			pgb.Step = 1;
			pgb.Value = 0;
			UpdateUI();
			bgw.RunWorkerAsync();

			//updateLocalCustomer();
		}

		#region update local customer

		//private void updateLocalCustomer()
		//{
		//	var _custCode = string.Empty;
		//	var _foundCustomer = false;

		//	//var b = sender as BackgroundWorker;

		//	CUSTOMER cust;
		//	var _custDAL = new CustomerDAL();
		//	_updateRowCount = 0;

		//	// select method update by update mode
		//	switch (_customerUpdateMode)
		//	{
		//		case _CustomerUpdate.UpdateByRequested:
		//			_maxProgress = dgv.Rows.Count;

		//			foreach (DataGridViewRow dgr in dgv.Rows)
		//			{
		//				// keep current customer code 
		//				_custCode = dgr.Cells["CUSTOMERCODE"].Value.ToString().Trim();

		//				_foundCustomer = _custDAL.FindExistCustomerInLocalDB(_custCode);

		//				if (_foundCustomer)
		//				{
		//					cust = _custDAL.GetLocalCustomerRecord(_custCode);

		//					cust.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
		//					cust.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
		//					cust.ADDRESS = string.Format("{0} {1}", dgr.Cells["ADDRESS1"].Value, dgr.Cells["ADDRESS2"].Value);
		//					cust.POSTAL = dgr.Cells["POSTAL"].Value.ToString();
		//					cust.DISTRICT = dgr.Cells["DISTRICT"].Value.ToString();
		//					cust.PROVINCE = dgr.Cells["PROVINCE"].Value.ToString();
		//					cust.CUSTWWW = dgr.Cells["WEB"].Value.ToString();
		//					cust.MODIUSER = omglobal.UserInfo;
		//					cust.MODIDATE = DateTime.Now;

		//					_updateRowCount += _custDAL.UpdateCustomerForLocalDB(cust, _custCode);
		//					_recordMode = "Update";
		//				}
		//				else
		//				{
		//					// add new customer record into local DB
		//					var customer = new CUSTOMER();
		//					customer.ISDELETE = false;
		//					customer.ISWARNING = false;
		//					customer.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
		//					customer.VATABLE = true;
		//					customer.VATRATE = omglobal.DEFAULT_SYSTEM_VAT;
		//					customer.CUSTGROUPKEY = "";
		//					customer.ISHEADQUARTERS = true;
		//					customer.BRANCHNUMBER = 0;
		//					customer.CUSTCODE = _custCode;
		//					customer.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
		//					customer.ADDRESS = $"{dgr.Cells["ADDRESS1"].Value} { dgr.Cells["ADDRESS2"].Value}";
		//					customer.DISTRICT = dgr.Cells["DISTRICT"].Value.ToString();
		//					customer.PROVINCE = dgr.Cells["PROVINCE"].Value.ToString();
		//					customer.POSTAL = dgr.Cells["POSTAL"].Value.ToString();
		//					customer.COUNTRY = string.Empty;
		//					customer.TEL = dgr.Cells["PHONE"].Value.ToString();
		//					customer.FAX = dgr.Cells["FAX"].Value.ToString();
		//					customer.CUSTEMAIL = dgr.Cells["EMAIL"].Value.ToString();
		//					customer.CUSTWWW = dgr.Cells["WEB"].Value.ToString();
		//					customer.CONTACTPERSON = string.Empty;
		//					customer.CELLPHONE1 = string.Empty;
		//					customer.SALEPERSON = "OFFICE";
		//					customer.MATERIALLIMIT = 0.00m;
		//					customer.CREDITLIMIT = 0.00m;
		//					customer.CURRENCY = "THB";
		//					customer.CREDITCODE = "COD";
		//					customer.DATEBILL = 1;
		//					customer.DATEPAY = 1;
		//					customer.BILLINGPOINT = string.Empty;
		//					customer.PAYMENTPOINT = string.Empty;
		//					customer.AUDITUSER = omglobal.UserInfo;
		//					customer.AUDITDATE = DateTime.Now;
		//					customer.MODIUSER = omglobal.UserInfo;
		//					customer.MODIDATE = DateTime.Now;
		//					_updateRowCount += _custDAL.InsertCustomerForLocalDB(customer);
		//					_recordMode = "Insert";
		//				}

		//				//b.ReportProgress(_updateRowCount * 100 / _maxProgress);
		//			} // end loop from DataGridView
		//			break;

		//		case _CustomerUpdate.UpdateFromEntry:
		//			_maxProgress = _customerTable.Rows.Count;

		//			foreach (DataRow dr in _customerTable.Rows)
		//			{
		//				// add new customer record into local DB
		//				var customer = new CUSTOMER();
		//				customer.ISDELETE = false;
		//				customer.ISWARNING = false;
		//				customer.CUSTTAXID = dr["TAXID"].ToString();
		//				customer.VATABLE = true;
		//				customer.VATRATE = omglobal.DEFAULT_SYSTEM_VAT;
		//				customer.CUSTGROUPKEY = "";
		//				customer.ISHEADQUARTERS = true;
		//				customer.BRANCHNUMBER = 0;
		//				customer.CUSTCODE = dr["CUSTOMERCODE"].ToString();
		//				customer.CUSTNAME = dr["CUSTOMERNAME"].ToString();
		//				customer.ADDRESS = string.Format("{0} {1}", dr["ADDRESS1"], dr["ADDRESS2"]);
		//				customer.DISTRICT = dr["DISTRICT"].ToString();
		//				customer.PROVINCE = dr["PROVINCE"].ToString();
		//				customer.POSTAL = dr["POSTAL"].ToString();
		//				customer.COUNTRY = string.Empty;
		//				customer.TEL = dr["PHONE"].ToString();
		//				customer.FAX = dr["FAX"].ToString();
		//				customer.CUSTEMAIL = dr["EMAIL"].ToString();
		//				customer.CUSTWWW = dr["WEB"].ToString();
		//				customer.CONTACTPERSON = string.Empty;
		//				customer.CELLPHONE1 = string.Empty;
		//				customer.SALEPERSON = "OFFICE";
		//				customer.MATERIALLIMIT = 0.00m;
		//				customer.CREDITLIMIT = 0.00m;
		//				customer.CURRENCY = "THB";
		//				customer.CREDITCODE = "COD";
		//				customer.DATEBILL = 1;
		//				customer.DATEPAY = 1;
		//				customer.BILLINGPOINT = string.Empty;
		//				customer.PAYMENTPOINT = string.Empty;
		//				customer.AUDITUSER = omglobal.UserInfo;
		//				customer.AUDITDATE = DateTime.Now;
		//				customer.MODIUSER = omglobal.UserInfo;
		//				customer.MODIDATE = DateTime.Now;
		//				_updateRowCount += _custDAL.InsertCustomerForLocalDB(customer);
		//				_recordMode = "Insert";

		//				//b.ReportProgress(_updateRowCount * 100 / _maxProgress);
		//			}

		//			break;
		//	}

		//	_showProgressBar = false;
		//	UpdateUI();
		//}

		#endregion

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			// show CustomerInfo
			switch (_action)
			{
				case OMShareCustomerEnums.MasterCustomerAction.None:
					GetCustomerInfo(ActionMode.View, SelectedCustomerCode);
					break;

				case OMShareCustomerEnums.MasterCustomerAction.SearchOnly:
					DialogResult = DialogResult.OK;
					Close();
					break;
			}
		}

		private void tsbtnFilter_Click(object sender, EventArgs e)
		{
			string _filter = GetCustomerFilter("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
			getMasterCustomerAsync(_filter, _action = MasterCustomerAction.None);
 
		}

		private void tsbtnEditCustomer_Click(object sender, EventArgs e)
		{
			GetCustomerInfo(ActionMode.Edit, SelectedCustomerCode);
		}

		private void tsbtnFindCustomer_Click(object sender, EventArgs e)
		{
			var _cs = new CustomerSearch();
			_cs.StartPosition = FormStartPosition.CenterScreen;
			if (_cs.ShowDialog(this) == DialogResult.OK)
			{
				Alert.DisplayAlert("Message",
									$"Customer Id : {_cs.ERPCustomerId} \n" +
									$"Customer Code :{_cs.ERPCustomerCode} \n " +
									$"CustomerName :{_cs.CustomerName}");
			}
		}

		private void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			var _custCode = string.Empty;
			var _foundCustomer = false;
			var b = sender as BackgroundWorker;
			CUSTOMER cust;
			var _custDAL = new CustomerDAL();
			_updateRowCount = 0;

			// select method update by update mode
			switch (_customerUpdateMode)
			{
				case _CustomerUpdate.UpdateByRequested:
					_maxProgress = dgv.Rows.Count;

					foreach (DataGridViewRow dgr in dgv.Rows)
					{
						// keep current customer code 
						_custCode = dgr.Cells["CUSTOMERCODE"].Value.ToString().Trim();

						_foundCustomer = _custDAL.FindExistCustomerInLocalDB(_custCode);

						if (_foundCustomer)
						{
							cust = _custDAL.GetLocalCustomerRecord(_custCode);

							cust.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
							cust.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
							cust.ADDRESS = string.Format("{0} {1}", dgr.Cells["ADDRESS1"].Value, dgr.Cells["ADDRESS2"].Value);
							cust.POSTAL = dgr.Cells["POSTAL"].Value.ToString();
							cust.DISTRICT = dgr.Cells["DISTRICT"].Value.ToString();
							cust.PROVINCE = dgr.Cells["PROVINCE"].Value.ToString();
							cust.CUSTWWW = dgr.Cells["WEB"].Value.ToString();
							cust.MODIUSER = omglobal.UserInfo;
							cust.MODIDATE = DateTime.Now;

							_updateRowCount += _custDAL.UpdateCustomerForLocalDB(cust, _custCode);
							_recordMode = "Update";
						}
						else
						{
							// add new customer record into local DB
							var customer = new CUSTOMER();
							customer.ISDELETE = false;
							customer.ISWARNING = false;
							customer.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
							customer.VATABLE = true;
							customer.VATRATE = omglobal.DEFAULT_SYSTEM_VAT;
							customer.CUSTGROUPKEY = "";
							customer.ISHEADQUARTERS = true;
							customer.BRANCHNUMBER = 0;
							customer.CUSTCODE = _custCode;
							customer.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
							customer.ADDRESS = $"{dgr.Cells["ADDRESS1"].Value} { dgr.Cells["ADDRESS2"].Value}";
							customer.DISTRICT = dgr.Cells["DISTRICT"].Value.ToString();
							customer.PROVINCE = dgr.Cells["PROVINCE"].Value.ToString();
							customer.POSTAL = dgr.Cells["POSTAL"].Value.ToString();
							customer.COUNTRY = string.Empty;
							customer.TEL = dgr.Cells["PHONE"].Value.ToString();
							customer.FAX = dgr.Cells["FAX"].Value.ToString();
							customer.CUSTEMAIL = dgr.Cells["EMAIL"].Value.ToString();
							customer.CUSTWWW = dgr.Cells["WEB"].Value.ToString();
							customer.CONTACTPERSON = string.Empty;
							customer.CELLPHONE1 = string.Empty;
							customer.SALEPERSON = "OFFICE";
							customer.MATERIALLIMIT = 0.00m;
							customer.CREDITLIMIT = 0.00m;
							customer.CURRENCY = "THB";
							customer.CREDITCODE = "COD";
							customer.DATEBILL = 1;
							customer.DATEPAY = 1;
							customer.BILLINGPOINT = string.Empty;
							customer.PAYMENTPOINT = string.Empty;
							customer.AUDITUSER = omglobal.UserInfo;
							customer.AUDITDATE = DateTime.Now;
							customer.MODIUSER = omglobal.UserInfo;
							customer.MODIDATE = DateTime.Now;
							_updateRowCount += _custDAL.InsertCustomerForLocalDB(customer);
							_recordMode = "Insert";
						}

						b.ReportProgress(_updateRowCount * 100 / _maxProgress);
					} // end loop from DataGridView
					break;

				case _CustomerUpdate.UpdateFromEntry:
					_maxProgress = _customerTable.Rows.Count;

					foreach (DataRow dr in _customerTable.Rows)
					{
						// add new customer record into local DB
						var customer = new CUSTOMER();
						customer.ISDELETE = false;
						customer.ISWARNING = false;
						customer.CUSTTAXID = dr["TAXID"].ToString();
						customer.VATABLE = true;
						customer.VATRATE = omglobal.DEFAULT_SYSTEM_VAT;
						customer.CUSTGROUPKEY = "";
						customer.ISHEADQUARTERS = true;
						customer.BRANCHNUMBER = 0;
						customer.CUSTCODE = dr["CUSTOMERCODE"].ToString();
						customer.CUSTNAME = dr["CUSTOMERNAME"].ToString();
						customer.ADDRESS = string.Format("{0} {1}", dr["ADDRESS1"], dr["ADDRESS2"]);
						customer.DISTRICT = dr["DISTRICT"].ToString();
						customer.PROVINCE = dr["PROVINCE"].ToString();
						customer.POSTAL = dr["POSTAL"].ToString();
						customer.COUNTRY = string.Empty;
						customer.TEL = dr["PHONE"].ToString();
						customer.FAX = dr["FAX"].ToString();
						customer.CUSTEMAIL = dr["EMAIL"].ToString();
						customer.CUSTWWW = dr["WEB"].ToString();
						customer.CONTACTPERSON = string.Empty;
						customer.CELLPHONE1 = string.Empty;
						customer.SALEPERSON = "OFFICE";
						customer.MATERIALLIMIT = 0.00m;
						customer.CREDITLIMIT = 0.00m;
						customer.CURRENCY = "THB";
						customer.CREDITCODE = "COD";
						customer.DATEBILL = 1;
						customer.DATEPAY = 1;
						customer.BILLINGPOINT = string.Empty;
						customer.PAYMENTPOINT = string.Empty;
						customer.AUDITUSER = omglobal.UserInfo;
						customer.AUDITDATE = DateTime.Now;
						customer.MODIUSER = omglobal.UserInfo;
						customer.MODIDATE = DateTime.Now;
						_updateRowCount += _custDAL.InsertCustomerForLocalDB(customer);
						_recordMode = "Insert";

						b.ReportProgress(_updateRowCount * 100 / _maxProgress);
					}

					break;
			}

			_showProgressBar = false;
			UpdateUI();
		}

		private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// set ProgressBar value
			pgb.Value = e.ProgressPercentage;

			// Calculate elapsed time
			var _tp = DateTime.Now - _startTime;
			var _elapsedTime = $"{_tp.Hours:00}:{_tp.Minutes:00}:{_tp.Seconds:00}";

			// display status
			lbProgressStatus.SuspendLayout();
			lbProgressStatus.Text = $"[{_recordMode}] {_updateRowCount} of {_maxProgress} :: {pgb.Value}%  Elapsed time : {_elapsedTime}";
			lbProgressStatus.ResumeLayout();
		}

		private void MasterCustomers_Shown(object sender, EventArgs e)
		{
			// Find none exist local customer
			FindNoneExistLocalCustomers();

		}



		#region class properties

		public OMShareCustomerEnums.MasterCustomerAction Action
		{
			set { _action = value; }
		}

		public string SelectedCustomerCode { get; private set; } = string.Empty;

		public string SelectedCustomerName { get; private set; } = string.Empty;

		public int SelectedCustomerId { get; private set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			pnlUpdateProgress.Visible = _showProgressBar;
			tsbtnUpdateLocalCustomeDB.Visible = _action == OMShareCustomerEnums.MasterCustomerAction.None;
			tsSepLocalUpdate.Visible = tsbtnUpdateLocalCustomeDB.Visible;
			tsbtnEditCustomer.Visible = tsbtnUpdateLocalCustomeDB.Visible;
			tsbtnFilter.Visible = tsbtnUpdateLocalCustomeDB.Visible;
			tsSepSearch.Visible = tsbtnFilter.Visible;
			tsbtnFindCustomer.Visible = !tsbtnFilter.Visible;
			tsSepFind.Visible = tsbtnFindCustomer.Visible;

			switch (_action)
			{
				case OMShareCustomerEnums.MasterCustomerAction.None:
					tsbtnUpdateLocalCustomeDB.Enabled = dgv.Rows.Count > 0;
					tsbtnEditCustomer.Enabled = !string.IsNullOrEmpty(SelectedCustomerCode);
					break;
				case OMShareCustomerEnums.MasterCustomerAction.SearchOnly:
					break;
			}
		} // end UpdateUI


		private string GetCustomerFilter(string Title)
		{
			return OMDataUtils.GetFilter<string>(Title);

		} // end GetFilter

		private void LoadCustomerCategoryMenuItem()
		{
			var _dt = new CustomerDAL().GetERPCustomerCategory();

			foreach (var item in _dt.AsEnumerable())
			{
				var _mnu = new ToolStripMenuItem();
				_mnu.Tag = item.Field<int>("ARCAT_KEY");
				_mnu.Text = item.Field<string>("ARCAT_NAME");
				_mnu.Click += tsmnuCustomerCategory_Click;
				tsmnuSearchCustomerByCategory.DropDownItems.Add(_mnu);
			}

		} // end LoadCustomerCategoryMenuItem

		private void tsmnuCustomerCategory_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			tsmnuView.Text = $"[รายชื่อลูกค้า] >>> {_mnu.Text}";
			var _catKey = Convert.ToInt32(_mnu.Tag);

			// load customer record as of sending parameter with type <int>
			//GetCustomer(_catKey, _action);

			SelectedCustomerCode = "";
			UpdateUI();

			getMasterCustomerAsync(_catKey.ToString(), _action);


		} // end tsmnuCustomerCategory_Click


		private async void getMasterCustomerAsync(string filter, OMShareCustomerEnums.MasterCustomerAction mode)
		{
			var _c = new CustomerDAL();
			var _dt = await _c.GetMasterCustomerAsync(omglobal.SysConnectionString, filter);//, CustomerSearchOptions.SearchByCustomerName);

			_rowCount = _dt.Rows.Count;

			dgv.SuspendLayout();
			if (_dt != null)
				dgv.DataSource = _dt;
			else
				dgv.DataSource = null;

			// formatting ColumnHeader
			switch (mode)
			{
				case OMShareCustomerEnums.MasterCustomerAction.None:
					dgv.Columns["CATEGORYKEY"].Visible = false;
					dgv.Columns["CUSTOMERID"].Visible = false;
					dgv.Columns["CUSTOMERCATEGORYKEY"].Visible = false;
					dgv.Columns["CUSTOMERNAME"].HeaderText = "Customer Name";
					break;

				case OMShareCustomerEnums.MasterCustomerAction.SearchOnly:
					foreach (DataGridViewColumn dgc in dgv.Columns)
						dgc.Visible = dgc.Name.ToUpper() == "CUSTOMERNAME";
					dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
					break;
			}

			dgv.ResumeLayout();

			// Updating UI
			lbCustomerRecords.Text = string.Format("found :{0} record{1}", dgv.Rows.Count, dgv.Rows.Count > 1 ? "s" : "");
			UpdateUI();
		}


		private void GetCustomerInfo(ActionMode Mode, string CustomerCode)
		{
			var _custInfo = new MasterCustomerInfo();
			_custInfo.Mode = Mode;
			_custInfo.CustomerCode = CustomerCode;
			_custInfo.StartPosition = FormStartPosition.CenterScreen;
			_custInfo.ShowDialog(this);

		} // end GetCustomerInfo

		private void FindNoneExistLocalCustomers()
		{
			_customerTable = new CustomerDAL().FindNoneExistLocalCustomers(omglobal.SysConnectionString);
			if (_customerTable.Rows.Count > 0)
			{
				_customerUpdateMode = _CustomerUpdate.UpdateFromEntry;
				_showProgressBar = true;
				_startTime = DateTime.Now;
				pgb.Maximum = 100;
				pgb.Minimum = 0;
				pgb.Step = 1;
				pgb.Value = 0;
				UpdateUI();
				bgw.RunWorkerAsync();
			}
		} // end FindNoneExistLocalCustomers

		#endregion
	}
}