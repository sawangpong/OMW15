using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using OMControls;
using OMControls.OMView;
using OMW15.Controllers.ToolController;
using OMW15.Models.ServiceModel;
using OMW15.Models.WarehouseModel;
using OMW15.Shared;
using OMW15.Views.CustomerView;
using OMW15.Views.WarehouseView;
using static OMW15.Shared.OMShareServiceEnums;
using OMW15.Models.ProductModel;

namespace OMW15.Views.ServiceView
{
	public partial class ServiceJobInfo : Form
	{
		#region class field member

		private ORDERMAINTENANCE _ord;

		private const string _AUTO_JOBORDER = "***AUTO***";
		private ActionMode _mode = ActionMode.None;

		private readonly int _jobId;
		private int _selectedCurrentOrderStatus = (int)OMShareServiceEnums.OrderStatusEnum.ACTIVE;
		private string _orderCode = string.Empty;
		private bool _needUpdateChange;
		private int _selectedOrderFixedItemId;
		private int _selectedERPCustomerId;
		private int _currentERPCustomerId;
		private int _selectedOrderPiority = 2; // 2=normal, 1=Emergency, 3=Appointment
		private int _spRowCount;
		private int _selectedIssueItem;

		#endregion

		#region class property
		public int ScheduleId
		{
			get; set;
		}

		public int ContractId
		{
			get; set;
		}

		public string ContractNo
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public string Customer
		{
			get; set;
		}

		public string MachineModel
		{
			get; set;
		}

		public string SerialNo
		{
			get; set;
		}

		public int PMNumber
		{
			get; set;
		}

		public DateTime PMDate
		{
			get; set;
		}

		public ServiceAppCallEnum AppCall
		{
			get; set;
		}

		#endregion

		//
		// form constructor with parameter
		//
		public ServiceJobInfo(int jobId, string orderCode = "")
		{
			InitializeComponent();
			_jobId = jobId;
			_orderCode = orderCode;
			txtModel.Text = "";
			txtModel.Tag = "";
			txtCustomerCode.Text = "";
			txtCustomerCode.Tag = 0;
			txtCustomerName.Text = "";
		}

		public ServiceJobInfo(int jobId, string orderCode, string modelId, string model, string serialNo, int customerId, string customerCode, string customerName)
		{
			InitializeComponent();

			_jobId = jobId;
			_orderCode = orderCode;
			txtCustomerCode.Text = customerCode;
			txtCustomerCode.Tag = customerId;
			txtCustomerName.Text = customerName;
			txtModel.Text = model;
			txtModel.Tag = modelId;
			txtSerial.Text = serialNo;
		}

		private void ServiceJobInfo_Load(object sender, EventArgs e)
		{

			this.CenterToScreen();

			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgvDateRepair);
			OMUtils.SettingDataGridView(ref dgvSP);

			// create list
			GetOrderPiorityList();
			GetStatusList();
			GetOrderErrorList();
			GetOrderCodes();

			// get datasource for JOBORDERs
			GetOrderDataSource(_jobId);

		}

		private void dgvDateRepair_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedOrderFixedItemId = Convert.ToInt32(dgvDateRepair["LINEID", e.RowIndex].Value);

			UpdateUI();
		}

		private void btnFinishDate_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				btnFinishDate.SelectedDate = Information.IsDate(txtDateFinish.Text)
					? Convert.ToDateTime(txtDateFinish.Text)
					: DateTime.Today;
			}
			catch
			{
				btnFinishDate.SelectedDate = DateTime.Today;
			}
		}

		private void btnFinishDate_DateSelected(object sender, EventArgs e)
		{
			txtDateFinish.Text = btnFinishDate.SelectedDate.ToShortDateString();
			UpdateUI();
		}

		private void cbxJobStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedCurrentOrderStatus = Convert.ToInt32(cbxJobStatus.SelectedValue);
			}
			catch
			{
				_selectedCurrentOrderStatus = (int)OMShareServiceEnums.OrderStatusEnum.ACTIVE;
			}

			// debug
			lbCurrentOrderStatus.Text = _selectedCurrentOrderStatus.ToString();
			// end debug

			UpdateUI();
		}

		private void btnCustomer_Click(object sender, EventArgs e)
		{
			GetCustomers();
		}

		private void btnModel_Click(object sender, EventArgs e)
		{
			GetMachineByCustomer(txtCustomerCode.Text);
		}

		private void chkAutoJobRunning_CheckedChanged(object sender, EventArgs e)
		{
			txtOrderNo.Text = chkAutoJobRunning.Checked ? _AUTO_JOBORDER : string.Empty;

			UpdateUI();
		}

		private void btnSerial_Click(object sender, EventArgs e)
		{
			GetMachineSerialNoByModel(txtCustomerCode.Text, txtModel.Text);
		}

		private void txtModel_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void txtCustomerCode_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}


		private void btnAddError_Click(object sender, EventArgs e)
		{
			using (var _err = new ErrList())
			{
				_err.StartPosition = FormStartPosition.CenterScreen;
				_err.ShowDialog(this);
			}
			GetOrderErrorList();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// mapping data
			SaveAddEditOrder();
		}

		private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
		{
			if (_mode == ActionMode.Add)
			{
				dtpDueDate.Value = dtpOrderDate.Value.AddDays(5);
			}
		}

		private void txtDateFinish_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void tsbtnRepairEdit_Click(object sender, EventArgs e)
		{
			GetOrderFixedItemInfo(_jobId, _orderCode, txtOrderNo.Text, _selectedOrderFixedItemId);
		}

		private void tsbtnRepairAdd_Click(object sender, EventArgs e)
		{
			_selectedOrderFixedItemId = 0;
			GetOrderFixedItemInfo(_jobId, _orderCode, txtOrderNo.Text, _selectedOrderFixedItemId);
		}

		private void tsbtnRepairRefresh_Click(object sender, EventArgs e)
		{
			// get job fixed details
			GetOrderFixedItems(_ord.orderCode, _ord.orderid);
		}

		private void dgvDateRepair_DoubleClick(object sender, EventArgs e)
		{
			tsbtnRepairEdit.PerformClick();
		}

		private void tsbtnIssueSelect_Click(object sender, EventArgs e)
		{
			// TAG of this button is "DRSV"
			var _btn = sender as ToolStripButton;
			var _issueCode = _btn.Tag.ToString().ToUpper();

			using (
				var _sp = new SPIssueList(omglobal.SeriveIssueCode, OMShareWarehouseEnums.WarehouseSPViewMode.Select, "SERVICE"))
			{
				_sp.OrderCode = _orderCode;
				_sp.OrderId = _jobId;
				_sp.OrderNumber = txtOrderNo.Text;
				_sp.StartPosition = FormStartPosition.CenterScreen;
				_sp.ShowDialog(this);
			}

			tsbtnIssueRefresh.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnIssueRefresh_Click(object sender, EventArgs e)
		{
			GetOrderIssueItems(_orderCode, _jobId);
		}

		private void dgvSP_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_spRowCount == dgvSP.Rows.Count)
			{
				_selectedIssueItem = Convert.ToInt32(dgvSP["SPLINE", e.RowIndex].Value);
			}

			UpdateUI();
		}

		private void tsbtnIssueDeleteItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต่้องการลบรายการที่เลือก?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
				DialogResult.Yes)
			{
				if (new IssueDAL().DeleteIssueItem(_selectedIssueItem) > 0)
					MessageBox.Show("Remove item successfully....", "Remove");
				tsbtnIssueRefresh.PerformClick();
			}
		}

		private void tsbtnRepairDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบรายการที่เลือก?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) ==
				DialogResult.Yes)
			{
				if (new ServiceJobDAL().DeleteOrderRepairItem(_selectedOrderFixedItemId, _jobId) > 0)
					MessageBox.Show("รายการที่เลือกได้ถูกลบออกจากระบบแล้ว.....", "Message", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				tsbtnRepairRefresh.PerformClick();
			}
		}

		private void tsbtnIssueEditItem_Click(object sender, EventArgs e)
		{
			AddEditIssueItem(_selectedIssueItem);
		}

		private void tsbtnIssueAddItem_Click(object sender, EventArgs e)
		{
			_selectedIssueItem = 0;
			AddEditIssueItem(_selectedIssueItem);
		}

		private void AddEditIssueItem(int IssueItemId)
		{
			using (var _spItemInfo = new JobSPItemInfo(IssueItemId, _jobId, _orderCode, txtOrderNo.Text))
			{
				_spItemInfo.StartPosition = FormStartPosition.CenterScreen;
				_spItemInfo.ShowDialog();
			}

			tsbtnIssueRefresh.PerformClick();
		}

		private void dgvSP_DoubleClick(object sender, EventArgs e)
		{
			tsbtnIssueEditItem.PerformClick();
		}

		private void cbxWorkPiority_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedOrderPiority = Convert.ToInt32(cbxWorkPiority.SelectedValue);
			}
			catch
			{
				_selectedOrderPiority = 2;
			}

			lbPiority.Text = _selectedOrderPiority.ToString();
		}

		private void cbxOrderType_SelectedValueChanged(object sender, EventArgs e)
		{

		}



		#region class helper method

		private string getLastJobOrder(string orderCode, DateTime openDate)
		{
			return (new ServiceJobDAL().getLastOrder(orderCode, openDate));
		}

		private void UpdateUI()
		{
			// when status = COMPLETE
			lbFinishDate.Visible = _selectedCurrentOrderStatus == (int)OMShareServiceEnums.OrderStatusEnum.CLOSED;
			txtDateFinish.Visible = lbFinishDate.Visible;
			btnFinishDate.Visible = lbFinishDate.Visible;

			// when Mode = Edit
			cbxJobStatus.Enabled = _mode == ActionMode.Edit;
			lbLastOrder.Visible = !cbxJobStatus.Enabled;
			txtLastOrder.Visible = lbLastOrder.Visible;

			// when pm-contract
			this.lbPMContractNo.Visible = (this.AppCall == ServiceAppCallEnum.PMAppointment);

			chkAutoJobRunning.Enabled = _mode == ActionMode.Add;
			txtOrderNo.Enabled = _mode == ActionMode.Edit ? false : (chkAutoJobRunning.Checked ? false : true);
			txtCustomerCode.ReadOnly = true;
			txtCustomerName.ReadOnly = txtCustomerCode.ReadOnly;

			btnCustomer.Enabled = _mode == ActionMode.Add ? true : false;
			btnModel.Enabled = !string.IsNullOrEmpty(txtCustomerCode.Text);
			btnSerial.Enabled = !string.IsNullOrEmpty(txtModel.Text);

			pnlFixAndSp.Enabled = _mode != ActionMode.Add;

			switch (_mode)
			{
				case ActionMode.Add:
					btnSave.Enabled = !string.IsNullOrEmpty(txtCustomerCode.Text)
									  && !string.IsNullOrEmpty(txtCustomerName.Text)
									  && !string.IsNullOrEmpty(txtModel.Text);
					break;
				case ActionMode.Edit:
					btnSave.Enabled = _needUpdateChange;
					btnSave.Enabled = !string.IsNullOrEmpty(txtCustomerCode.Text)
									  && !string.IsNullOrEmpty(txtCustomerName.Text)
									  && !string.IsNullOrEmpty(txtModel.Text);
					if (_selectedCurrentOrderStatus == (int)OMShareServiceEnums.OrderStatusEnum.CLOSED)
						btnSave.Enabled = !string.IsNullOrEmpty(txtDateFinish.Text);
					break;
			}


			// For order repair
			tsbtnRepairEdit.Enabled = _selectedOrderFixedItemId > 0;
			tsbtnRepairDelete.Enabled = tsbtnRepairEdit.Enabled;

			// For order spare part (Issue)
			tsbtnIssueEditItem.Enabled = _selectedIssueItem > 0;
			tsbtnIssueDeleteItem.Enabled = tsbtnIssueEditItem.Enabled;

		} // end UpdateUI

		private void GetOrderCodes()
		{
			cbxOrderType.DataSource = new ServiceJobDAL().GetOrderCodeList();
			cbxOrderType.DisplayMember = "CodeName";
			cbxOrderType.ValueMember = "Code";
		}


		private void GetStatusList()
		{
			cbxJobStatus.DataSource = EnumWithName<OMShareServiceEnums.OrderStatusEnum>.ParseEnum();
			cbxJobStatus.DisplayMember = "Name";
			cbxJobStatus.ValueMember = "Value";
		} // end GetStatusList

		private void GetOrderPiorityList()
		{
			cbxWorkPiority.DataSource = new ServiceJobDAL().GetJobPiorityList();
			cbxWorkPiority.DisplayMember = "KEY";
			cbxWorkPiority.ValueMember = "VALUE";
			cbxWorkPiority.SelectedIndex = 1;
		} // end GetOrderPiorityList

		private void GetOrderErrorList()
		{
			cbxError.DataSource = new ServiceJobDAL().GetJobErrorList();
			cbxError.DisplayMember = "KEY";
			cbxError.ValueMember = "VALUE";
		} // end GetOrderErrorList

		private void GetOrderFixedDetails()
		{
			var s = new StringBuilder();

			if (dgvDateRepair.Rows.Count > 0)
				foreach (DataGridViewRow dgr in dgvDateRepair.Rows)
				{
					s.AppendFormat("วันที่ซ่อม : {0}", Convert.ToDateTime(dgr.Cells["DATEFIXED"].Value).ToShortDateString());
					s.AppendLine();
					s.Append("รายละเอียดการซ่อม");
					s.AppendLine();
					s.AppendFormat("{0}", dgr.Cells["FIXEDDETAIL"].Value).ToString();
					s.AppendLine();

					// engineer 1
					if (string.IsNullOrEmpty(dgr.Cells["ENGINEER1"].Value.ToString()) == false)
					{
						s.AppendFormat("ช่างบริการ : {0}", dgr.Cells["ENGINEER1"].Value).ToString();
						s.AppendLine();
					}
					// engineer 2
					if (string.IsNullOrEmpty(dgr.Cells["ENGINEER2"].Value.ToString()) == false)
					{
						s.AppendFormat("ช่างบริการ : {0}", dgr.Cells["ENGINEER2"].Value).ToString();
						s.AppendLine();
					}

					// engineer 3
					if (string.IsNullOrEmpty(dgr.Cells["ENGINEER3"].Value.ToString()) == false)
					{
						s.AppendFormat("ช่างบริการ : {0}", dgr.Cells["ENGINEER3"].Value).ToString();
						s.AppendLine();
					}

					// engineer 4
					if (string.IsNullOrEmpty(dgr.Cells["ENGINEER4"].Value.ToString()) == false)
					{
						s.AppendFormat("ช่างบริการ : {0}", dgr.Cells["ENGINEER4"].Value).ToString();
						s.AppendLine();
					}
					s.Append("============================");
					s.AppendLine();
				}

			txtRepairInfo.Text = s.ToString();
		} // end GetOrderFixedDetails

		private void GetOrderIssueItems(string OrderCode, int OrderId)
		{
			// mapping data
			dgvSP.SuspendLayout();
			//var dt = new IssueDAL().GetSparePartItems(OrderCode, OrderId);
			dgvSP.DataSource = new IssueDAL().GetSparePartItems(OrderCode, OrderId);

			// hide columns
			dgvSP.Columns["SPLINE"].Visible = false;
			dgvSP.Columns["ORDERID"].Visible = false;
			dgvSP.Columns["ORDERCODE"].Visible = false;
			dgvSP.Columns["INDATABASE"].Visible = false;
			dgvSP.Columns["AUDIT"].Visible = false;
			dgvSP.Columns["MODIUSER"].Visible = false;
			dgvSP.Columns["LASTUPDATE"].Visible = false;
			dgvSP.Columns["ITEMREMARK"].Visible = false;
			dgvSP.Columns["UCOST"].Visible = false;

			// formatting columns
			dgvSP.Columns["ISSUENO"].HeaderText = "เลฃที่ใบเบิก";
			dgvSP.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgvSP.Columns["ITEMNAME"].HeaderText = "ชื่อสินค้า";
			dgvSP.Columns["UOM"].HeaderText = "หน่วยนับ";
			dgvSP.Columns["TOTALPRICE"].HeaderText = "รวมราคา";
			dgvSP.Columns["QTYNEED"].HeaderText = "จำนวนเบิก";
			dgvSP.Columns["UPRICE"].HeaderText = "ราคา/หน่วย";
			dgvSP.Columns["DISCOUNT"].HeaderText = "ส่วนลด";
			dgvSP.Columns["NETUPRICE"].HeaderText = "ราคาสุทธิ";

			foreach (DataGridViewColumn dgc in dgvSP.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}
			dgvSP.ResumeLayout();

			_spRowCount = dgvSP.Rows.Count;


			// display counter
			tslbCount.Text = $"{dgvSP.Rows.Count} รายการ";

			txtSparepartCost.Text = $"{UpdateSparePartValues():N2}";

			UpdateUI();
		} // end GetOrderSPItems

		private decimal UpdateSparePartValues()
		{
			_needUpdateChange = true;
			return ((DataTable)dgvSP.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("TotalPrice"));

		} // end UpdateSparePartValues

		private void GetCustomers()
		{
			using (var _cust = new CustomerSearch())
			{
				_cust.StartPosition = FormStartPosition.CenterParent;
				if (_cust.ShowDialog(this) == DialogResult.OK)
				{
					txtCustomerName.Text = _cust.CustomerName;
					txtCustomerCode.Text = _cust.ERPCustomerCode;
					txtCustomerCode.Tag = _cust.ERPCustomerId;
					_selectedERPCustomerId = _cust.ERPCustomerId;
				}
			}
		} // end GetCustomer

		private void GetMachineByCustomer(string CustomerCode)
		{
			using (var _model = new SearchField())
			{
				_model.StartPosition = FormStartPosition.CenterParent;
				_model.Title = "Select Machine" + "(" + CustomerCode + ")";
				_model.DataSource = new MachineDAL().GetMachineByCustomer(CustomerCode);
				if (_model.ShowDialog(this) == DialogResult.OK)
				{
					txtModel.Text = _model.SelectedKey;
					txtModel.Tag = _model.SelectedValue;
				}
			}
		} // end GetMachineByCustomer

		private void GetMachineSerialNoByModel(string CustomerCode, string Model)
		{
			using (var _sn = new SearchField())
			{
				_sn.StartPosition = FormStartPosition.CenterParent;
				_sn.Title = string.Format("[{0}]({1}) Select Serial-No.", CustomerCode, Model);
				_sn.DataSource = new MachineDAL().GetMachineSerialNoByModel(CustomerCode, Model);
				if (_sn.ShowDialog(this) == DialogResult.OK)
					txtSerial.Text = _sn.SelectedValue;
			}
		} // end GetMachineSerialNoByModel


		private void GetOrderDataSource(int JobId)
		{
			_mode = JobId == 0 ? ActionMode.Add : ActionMode.Edit;
			lbMode.Text = _mode.ToString();

				switch (_mode)
				{
					case ActionMode.Add:
						_ord = new ORDERMAINTENANCE();

						_selectedCurrentOrderStatus = (int) OMShareServiceEnums.OrderStatusEnum.ACTIVE;

						// add default value to object
						chkAutoJobRunning.Checked = true;
						if (this.AppCall == ServiceAppCallEnum.PMAppointment)
						{
							this.txtCustomerCode.Text = this.CustomerCode;
							this.txtCustomerName.Text = this.Customer;
							this.txtModel.Text = this.MachineModel;
							this.txtModel.Tag = new ProductDAL().getProductCodeFromProductName(this.MachineModel);
							this.txtSerial.Text = this.SerialNo;
							_ord.pmAppointDate = this.PMDate;
							_ord.isPM = true;
							_ord.pmmasterline = this.ContractId;
							_ord.pmschline = this.ScheduleId;
							_ord.orderTypeid = this.PMNumber;
							this.lbPMContractNo.Text = $"{this.ContractNo} \\ {this.PMNumber}";
						}

						_selectedOrderPiority = 2; // Normal priority
						_ord.actionpiority = _selectedOrderPiority;
						_ord.orderid = 0;
						_ord.orderCode = _orderCode;
						_ord.isdelete = false;
						_ord.nochargedetail = "";
						_ord.isnocharge = false;

						_ord.orderdate = DateTime.Today;
						_ord.duedate = _ord.orderdate.Value.AddDays(5).Date2Num();
						_ord.finishdate = null;
						_ord.s_no = txtSerial.Text;
						_ord.productid = string.IsNullOrEmpty(txtModel.Tag.ToString()) ? "" : txtModel.Tag.ToString();
						_ord.type = txtModel.Text;
						_ord.custid = string.IsNullOrEmpty(txtCustomerCode.Tag.ToString()) ? 0 : Convert.ToInt32(txtCustomerCode.Tag);
						_ord.acccustcode = txtCustomerCode.Text;
						_ord.cus_na = txtCustomerName.Text;
						_ord.pmAppointDate = DateTime.Today;
						_ord.status = _selectedCurrentOrderStatus;
						_ord.errorcode = "E0000";
						_ord.otherdetails = "";
						_ord.invoiceno = "";

						break;

					case ActionMode.Edit:
						_ord = new ServiceJobDAL().GetJobOrderInfo(JobId);
						_selectedOrderPiority = _ord.actionpiority;

						break;
				}

				lbPiority.Text = _selectedOrderPiority.ToString();
				cbxWorkPiority.SelectedValue = _selectedOrderPiority;
				cbxJobStatus.SelectedValue = _ord.status;
				cbxError.SelectedValue = _ord.errorcode;
				dtpOrderDate.Value = _ord.orderdate.Value;
				dtpDueDate.Value = OMUtils.Num2Date(_ord.duedate);
				cbxOrderType.SelectedValue = _ord.orderCode;
				chkNoCharge.Checked = _ord.isnocharge;
				txtNoChargeDetail.Text = _ord.nochargedetail;
				lbJobOrderType.Text = new ServiceJobDAL().GetOrderType(_ord.orderCode);
				_currentERPCustomerId = _ord.custid;

				lbOrderCode.Text = _ord.orderCode;
				txtOrderNo.Text = string.IsNullOrEmpty(_ord.s_order) ? _AUTO_JOBORDER : _ord.s_order;
				txtCustomerCode.Tag = _ord.custid;
				txtCustomerCode.Text = _ord.acccustcode;
				txtCustomerName.Text = _ord.cus_na;

				txtLastOrder.Text = this.getLastJobOrder(_ord.orderCode, _ord.orderdate.Value);

				txtModel.Text = _ord.type;
				txtModel.Tag = _ord.productid;
				txtSerial.Text = _ord.s_no;
				txtServiceCharge.Text = $"{_ord.servicecost:N2}";
				txtSparepartCost.Text = $"{_ord.sparepartcost:N2}";
				txtOtherCharge.Text = $"{_ord.othercost}";
				txtOtherDetail.Text = _ord.otherdetails;
				txtInv.Text = _ord.invoiceno;
				txtError.Text = _ord.error;
				txtDateFinish.Text = _ord.finishdate == (DateTime?) null ? string.Empty : _ord.finishdate.Value.ToShortDateString();

				// get job fixed details
				//MessageBox.Show($"Order Code = {_ord.orderCode} :: Order Id = {_ord.orderid}");

				if (_ord.orderid > 0)
				{
					GetOrderFixedItems(_ord.orderCode, _ord.orderid);

					// retrieve order spare part items
					GetOrderIssueItems(_ord.orderCode, _ord.orderid);
				}
			UpdateUI();

		} // end GetOrderDataSource

		private void GetOrderFixedItems(string OrderCode, int OrderId)
		{
			dgvDateRepair.SuspendLayout();
			dgvDateRepair.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvDateRepair.DataSource = new ServiceJobDAL().GetJobOrderFixedItems(OrderCode, OrderId);

			//MessageBox.Show($"Get Order fixed item = {this.dgvDateRepair.Rows.Count.ToString()}");


			foreach (DataGridViewColumn dgc in dgvDateRepair.Columns)
			{
				if (dgc.Name.ToUpper() != "DATEFIXED")
				{
					dgc.Visible = false;
				}
				else
				{
					dgc.Visible = true;
					dgc.HeaderText = "วันที่ซ่อม";
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				}
			}
			dgvDateRepair.ResumeLayout();

			// retrieve order fixed info
			GetOrderFixedDetails();

		} // end GetOrderFixedItems

		private void GetOrderFixedItemInfo(int JobId, string OrderCode, string OrderNumber, int LineId)
		{
			using (var _ordFix = new OrderFixInfo(LineId, JobId, OrderCode, OrderNumber))
			{
				_ordFix.StartPosition = FormStartPosition.CenterParent;
				_ordFix.ShowDialog(this);
			}
		} // end OrderFixedItemInfo


		// save the record
		private void SaveAddEditOrder()
		{
			switch (_mode)
			{
				case ActionMode.Add:
					// check the AUTO NUMBER IS CHECK
					if (chkAutoJobRunning.Checked)
					{
						_ord.s_order = new ServiceJobDAL().CreateServiceOrderNumber(_ord.orderCode, this.dtpOrderDate.Value);
						txtOrderNo.Text = _ord.s_order;
					}
					else
					{
						_ord.s_order = txtOrderNo.Text;
					}

					_ord.yearservice = int.Parse(this.dtpOrderDate.Value.GetThaiYearFormat());
					_ord.ordercountno = int.Parse(_ord.s_order.Substring(_ord.s_order.LastIndexOf("-") + 1));

					if (this.AppCall == ServiceAppCallEnum.PMAppointment)
					{
						_ord.isPM = true;
						_ord.pmschline = this.ScheduleId;
						_ord.pmmasterline = this.ContractId;
						_ord.orderTypeid = this.PMNumber;
					}
					else
					{
						_ord.isPM = (_ord.orderCode == "PM" ? true : false);
					}

					_ord.finishdate = null;
					_ord.auditdt = DateTime.Now;
					_ord.audituser = omglobal.UserInfo;
					break;

				case ActionMode.Edit:

					// check in case of spare part items are empty 
					// must be clear reference data in erp.transtkh.trh_refer_iref --> empty ("")

					if (this.dgvSP.Rows.Count == 0)
					{
						int result = new Models.ServiceModel.ServiceJobDAL().updateTransferSparePartItemInErp(_jobId);
						//if(result < 0)
						//{
						//	MessageBox.Show("Error update ERP....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						//}
					}

					if (_selectedCurrentOrderStatus == (int)OMShareServiceEnums.OrderStatusEnum.CLOSED)
					{
						if (OMUtils.IsDate(txtDateFinish.Text))
						{
							_ord.finishdate = Convert.ToDateTime(txtDateFinish.Text);
							_ord.year = Convert.ToDateTime(txtDateFinish.Text);
						}
					}
					else
					{
						_ord.year = _ord.orderdate.Value;
						_ord.finishdate = null;
					}

					break;
			}

			_ord.inWarrantyService = this.chkNoCharge.Checked;
			_ord.or_date = _ord.orderdate.Value.ToShortDateString();
			_ord.orderdate = dtpOrderDate.Value;
			_ord.year = _ord.orderdate.Value;
			_ord.duedate = dtpDueDate.Value.Date2Num();
			_ord.actionpiority = _selectedOrderPiority;
			_ord.status = _selectedCurrentOrderStatus;
			_ord.custid = _selectedERPCustomerId;
			_ord.acccustcode = txtCustomerCode.Text;
			_ord.cus_na = txtCustomerName.Text;
			_ord.productid = txtModel.Tag == null ? string.Empty : txtModel.Tag.ToString();
			_ord.type = txtModel.Text;
			_ord.s_no = txtSerial.Text;
			_ord.errorcode = cbxError.SelectedValue.ToString();
			_ord.error = txtError.Text;
			_ord.month = _ord.orderdate.Value.Month.ToString();
			_ord.period = _ord.orderdate.Value.Month;
			_ord.fiscyear = _ord.orderdate.Value.Year;
			_ord.inWarrantyService = false;
			_ord.servicecost = Convert.ToDecimal(txtServiceCharge.Text);
			_ord.sparepartcost = Convert.ToDecimal(txtSparepartCost.Text);
			_ord.othercost = Convert.ToDecimal(txtOtherCharge.Text);
			_ord.otherdetails = txtOtherDetail.Text;
			_ord.isnocharge = this.chkNoCharge.Checked;
			_ord.nochargedetail = this.txtNoChargeDetail.Text;
			_ord.invoiceno = txtInv.Text;
			_ord.modidt = DateTime.Now;
			_ord.modiuser = omglobal.UserInfo;

			if (new ServiceJobDAL().UpdateOrderInfo(_ord, _mode) > 0)
			{
				MessageBox.Show("Update Record successfully!!!!!!!!!!!!!");
			}

			if (this.AppCall == ServiceAppCallEnum.PMAppointment)
			{
				if (new PMDal().updateScheduleAfterTakeServiceJob(this.ScheduleId, $"{this.lbOrderCode.Text}-{this.txtOrderNo.Text}", _ord.orderdate.Value) <= 0)
				{
					MessageBox.Show("PM schedule can't update !!!!!!!!!!!!!!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		} // end SaveAddEditOrder

		#endregion

		private void txtOtherCharge_TextChanged(object sender, EventArgs e)
		{
			if (txtOtherCharge.Text == "")
			{
				txtOtherCharge.Text = "0.00";
			}
		}

		private void lbOrderCode_TextChanged(object sender, EventArgs e)
		{
			switch (this.lbOrderCode.Text)
			{
				case "AS":
				case "SW":
				case "SF":
					this.chkNoCharge.Checked = true;
					//this.txtNoChargeDetail.Text = this.cbxOrderType.Text;
					break;
				default:
					this.chkNoCharge.Checked = false;
					//this.txtNoChargeDetail.Text = "";
					break;
			}
		}

		private void chkNoCharge_CheckedChanged(object sender, EventArgs e)
		{
			this.txtNoChargeDetail.Enabled = this.chkNoCharge.Checked;
		}

		private void cbxOrderType_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				lbOrderCode.Text = cbxOrderType.SelectedValue.ToString();
				_ord.orderCode = lbOrderCode.Text;
				lbJobOrderType.Text = cbxOrderType.Text;

				// get job fixed details
				GetOrderFixedItems(_ord.orderCode, _mode == ActionMode.Add ? 0 : _ord.orderid);

				// retrieve order spare part items
				GetOrderIssueItems(_ord.orderCode, _mode == ActionMode.Add ? 0 : _ord.orderid);

				this.txtLastOrder.Text = this.getLastJobOrder(this.lbOrderCode.Text, this.dtpOrderDate.Value);
			}
			catch
			{
			}
		}
	}
}