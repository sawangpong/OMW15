using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Master.MasterView
{
	public partial class MasterCustomers : Form
	{
		#region class field member

		private MasterCustomerAction _action = MasterCustomerAction.None;
		private DateTime _startTime = DateTime.Now;
		private bool _showProgressBar = false;
		private string _selectedCustomerName = string.Empty;
		private string _selectedCustomerCode = string.Empty;
		private string _recordMode = string.Empty;
		private int _selectedCustomerId = 0;
		private int _updateRowCount = 0;
		private int _maxProgress = 0;

		#endregion

		#region class properties

		public MasterCustomerAction Action
		{
			set
			{
				_action = value;
			}
		}

		public string SelectedCustomerCode
		{
			get
			{
				return _selectedCustomerCode;
			}
		}

		public string SelectedCustomerName
		{
			get
			{
				return _selectedCustomerName;
			}
		}

		public int SelectedCustomerId
		{
			get
			{
				return _selectedCustomerId;
			}

		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.pnlUpdateProgress.Visible = _showProgressBar;
			this.tsbtnUpdateLocalCustomeDB.Visible = (_action == MasterCustomerAction.None);
			this.tsSepLocalUpdate.Visible = this.tsbtnUpdateLocalCustomeDB.Visible;
			this.tsbtnEditCustomer.Visible = this.tsbtnUpdateLocalCustomeDB.Visible;
			this.tsbtnFilter.Visible = this.tsbtnUpdateLocalCustomeDB.Visible;
			this.tsSepSearch.Visible = this.tsbtnFilter.Visible;
			this.tsbtnFindCustomer.Visible = !this.tsbtnFilter.Visible;
			this.tsSepFind.Visible = this.tsbtnFindCustomer.Visible;

			switch (_action)
			{
				case MasterCustomerAction.None:
					this.tsbtnUpdateLocalCustomeDB.Enabled = (this.dgv.Rows.Count > 0);
					this.tsbtnFilter.Enabled = this.tsbtnUpdateLocalCustomeDB.Enabled;
					this.tsbtnEditCustomer.Enabled = !string.IsNullOrEmpty(_selectedCustomerCode);
					break;
				case MasterCustomerAction.SearchOnly:
					this.tsbtnFilter.Enabled = (this.dgv.Rows.Count > 0);
					break;
			}

		} // end UpdateUI


		private string GetCustomerFilter(string Title)
		{
			return OMControls.OMDataUtils.GetFilter<string>(Title);

		} // end GetFilter

		private void LoadCustomerCategoryMenuItem()
		{
			DataTable _dt = new Master.MasterController.SearchMasterCustomers().GetERPCustomerCategory();

			foreach (var item in _dt.AsEnumerable())
			{
				ToolStripMenuItem _mnu = new ToolStripMenuItem();
				_mnu.Tag = item.Field<int>("ARCAT_KEY");
				_mnu.Text = item.Field<string>("ARCAT_NAME");
				_mnu.Click += new System.EventHandler(tsmnuCustomerCategory_Click);
				this.tsmnuSearchCustomerByCategory.DropDownItems.Add(_mnu);
			}

		} // end LoadCustomerCategoryMenuItem

		private void tsmnuCustomerCategory_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _mnu = sender as ToolStripMenuItem;
			this.tsmnuView.Text = string.Format("View >>> {0}", _mnu.Text);
			int _catKey = Convert.ToInt32(_mnu.Tag);

			// load customer record as of sending parameter with type <int>
			this.GetCustomer(new Master.MasterController.SearchMasterCustomers().GetMasterCustomer<int>(_catKey), _action);

		} // end tsmnuCustomerCategory_Click

		private void GetCustomer(DataTable dt, MasterCustomerAction Mode)
		{
			this.dgv.SuspendLayout();
			if (dt != null)
			{
				this.dgv.DataSource = dt;
			}
			else
			{
				this.dgv.DataSource = null;
			}

			// formatting ColumnHeader
			switch (Mode)
			{
				case MasterCustomerAction.None:
					this.dgv.Columns["CATEGORYKEY"].Visible = false;
					this.dgv.Columns["CUSTOMERID"].Visible = false;
					this.dgv.Columns["CUSTOMERCATEGORYKEY"].Visible = false;
					this.dgv.Columns["CUSTOMERNAME"].HeaderText = "Customer Name";
					break;
				case MasterCustomerAction.SearchOnly:
					foreach (DataGridViewColumn dgc in this.dgv.Columns)
					{
						if (dgc.Name.ToUpper() == "CUSTOMERNAME")
						{
							dgc.Visible = true;
						}
						else
						{
							dgc.Visible = false;
						}
					}
					this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
					break;
			}

			this.dgv.ResumeLayout();

			// Updating UI
			this.lbCustomerRecords.Text = string.Format("found :{0} record{1}", this.dgv.Rows.Count, (this.dgv.Rows.Count > 1 ? "s" : ""));

			this.UpdateUI();

		} // end GetCustomer

		private void GetCustomerInfo(ActionMode Mode, string CustomerCode)
		{
			Master.MasterView.MasterCustomerInfo _custInfo = new Master.MasterView.MasterCustomerInfo();
			_custInfo.Mode = Mode;
			_custInfo.CustomerCode = CustomerCode;
			_custInfo.StartPosition = FormStartPosition.CenterScreen;
			_custInfo.ShowDialog(this);

		} // end GetCustomerInfo

		#endregion

		public MasterCustomers()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
		}

		private void MasterCustomers_Load(object sender, EventArgs e)
		{
			// format DataGridGiew
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			// Load Customer Category Menu
			this.LoadCustomerCategoryMenuItem();

			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsmnuCustomers_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem _tsmnu = sender as ToolStripMenuItem;
			this.tsmnuView.Text = string.Format("View >>> {0}", _tsmnu.Text);

			string _filter = string.Empty;

			switch (_tsmnu.Tag.ToString().ToUpper())
			{
				case "ALL_CUST":
					_filter = string.Empty;
					break;
				case "BY_NAME":
					_filter = this.GetCustomerFilter("กำหนดชื่อลูกค้าที่ต้องการค้นหา");
					break;
			}

			// load customer record as of sending parameter with type <string>
			this.GetCustomer(new Master.MasterController.SearchMasterCustomers().GetMasterCustomer<string>(_filter), _action);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// get selected customer row (key)
			_selectedCustomerCode = this.dgv["CUSTOMERCODE", e.RowIndex].Value.ToString();
			_selectedCustomerName = this.dgv["CUSTOMERNAME", e.RowIndex].Value.ToString();
			_selectedCustomerId = Convert.ToInt32(this.dgv["CUSTOMERID", e.RowIndex].Value);

			// updating UI
			this.lb.Text = string.Format("Id:{0}, Code:{1}", _selectedCustomerId, _selectedCustomerCode);
			this.UpdateUI();

		}

		private void tsbtnUpdateLocalCustomeDB_Click(object sender, EventArgs e)
		{
			_showProgressBar = true;
			_startTime = DateTime.Now;
			this.pgb.Maximum = 100;
			this.pgb.Minimum = 0;
			this.pgb.Step = 1;
			this.pgb.Value = 0;
			this.UpdateUI();
			this.bgw.RunWorkerAsync();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			// show CustomerInfo
			switch (_action)
			{
				case MasterCustomerAction.None:
					this.GetCustomerInfo(ActionMode.View, _selectedCustomerCode);
					break;

				case MasterCustomerAction.SearchOnly:
					this.DialogResult = System.Windows.Forms.DialogResult.OK;
					this.Close();
					break;
			}
		}

		private void tsbtnFilter_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			(this.dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "CUSTOMERNAME", OMControls.OMDataUtils.GetFilter<string>("กำหนดชื่อลูกค้าที่ต้องการค้นหา"));
		}

		private void tsbtnEditCustomer_Click(object sender, EventArgs e)
		{
			this.GetCustomerInfo(ActionMode.Edit, _selectedCustomerCode);
		}

		private void tsbtnFindCustomer_Click(object sender, EventArgs e)
		{
			Master.MasterView.CustomerSearch _cs = new CustomerSearch();
			_cs.StartPosition = FormStartPosition.CenterScreen;
			if (_cs.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				omglobal.DisplayAlert("Message", string.Format("Customer Id : {0}\n Customer Code :{1}\n CustomerName :{2}", _cs.CustomerId, _cs.CustomerCode, _cs.CustomerName));
			}
		}

		private void bgw_DoWork(object sender, DoWorkEventArgs e)
		{
			//this.InsertUpdateLocalCustomersDB();

			var b = sender as BackgroundWorker;

			_updateRowCount = 0;
			_maxProgress = this.dgv.Rows.Count;
			string _custCode = string.Empty;

			bool _foundCustomer = false;

			foreach (DataGridViewRow dgr in this.dgv.Rows)
			{
				// keep current customer code 
				_custCode = dgr.Cells["CUSTOMERCODE"].Value.ToString().Trim();

				_foundCustomer = Master.MasterController.SearchMasterCustomers.FindExistCustomerInLocalDB(_custCode);

				if (_foundCustomer == true)
				{
					// updating customer record in local db
					var cust = (from c in new OLDMOONEF().CUSTOMER1
								where c.CUSTCODE == _custCode
								select c).FirstOrDefault();
					cust.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
					cust.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
					cust.ADDRESS = string.Format("{0} {1}", dgr.Cells["ADDRESS1"].Value.ToString(), dgr.Cells["ADDRESS2"].Value.ToString());
					cust.POSTAL = dgr.Cells["POSTAL"].Value.ToString();
					cust.DISTRICT = dgr.Cells["DISTRICT"].Value.ToString();
					cust.PROVINCE = dgr.Cells["PROVINCE"].Value.ToString();
					cust.CUSTEMAIL = dgr.Cells["EMAIL"].Value.ToString();
					cust.CUSTWWW = dgr.Cells["WEB"].Value.ToString();
					cust.TEL = dgr.Cells["PHONE"].Value.ToString();
					cust.FAX = dgr.Cells["FAX"].Value.ToString();
					cust.MODIUSER = omglobal.UserName;
					cust.MODIDATE = DateTime.Now;

					_updateRowCount += Master.MasterController.SearchMasterCustomers.UpdateCustomerForLocalDB(cust, _custCode);
					_recordMode = "Update";
				}
				else
				{
					// add new customer record into local DB
					CUSTOMER1 customer = new CUSTOMER1();
					customer.ISDELETE = false;
					customer.ISWARNING = false;
					customer.CUSTTAXID = dgr.Cells["TAXID"].Value.ToString();
					customer.VATABLE = true;
					customer.VATRATE = omglobal.DEFAULT_SYSTEM_VAT;
					customer.CUSTTYPE = 0;
					customer.ISHEADQUARTERS = true;
					customer.BRANCHNUMBER = 0;
					customer.CUSTCODE = _custCode;
					customer.CUSTNAME = dgr.Cells["CUSTOMERNAME"].Value.ToString();
					customer.ADDRESS = string.Format("{0} {1}", dgr.Cells["ADDRESS1"].Value.ToString(), dgr.Cells["ADDRESS2"].Value.ToString());
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
					customer.AUDITUSER = omglobal.UserName;
					customer.AUDITDATE = DateTime.Now;
					customer.MODIUSER = omglobal.UserName;
					customer.MODIDATE = DateTime.Now;
					_updateRowCount += MasterController.SearchMasterCustomers.InsertCustomerForLocalDB(customer);
					_recordMode = "Insert";
				}

				b.ReportProgress((_updateRowCount * 100) / _maxProgress);

			} // end loop from DataGridView

			_showProgressBar = false;
			this.UpdateUI();
		}

		private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// set ProgressBar value
			this.pgb.Value = e.ProgressPercentage;

			// Calculate elapsed time
			TimeSpan _tp = (DateTime.Now - _startTime);
			string _elapsedTime = string.Format("{0:00}:{1:00}:{2:00}", _tp.Hours, _tp.Minutes, _tp.Seconds);

			// display status
			this.lbProgressStatus.Text = string.Format("[{0}] {1} of {2} :: {3}%  Elapsed time : {4}", _recordMode, _updateRowCount, _maxProgress, this.pgb.Value, _elapsedTime);
		}
	}
}
