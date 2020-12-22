using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMW15.Tools;
using OMW15;

namespace OMW15.Services.ServiceView
{
	public partial class ServiceJobInfo : Form
	{

		#region class field member
		private BindingSource _bds = new BindingSource();
		private ORDERMAINTENANCE _ord = new ORDERMAINTENANCE();

		private const string _AUTO_JOBORDER = "***AUTO***";
		private ActionMode _mode = ActionMode.None;
		private int _jobId = 0;
		private int _selectedOrderFixedItemId = 0;
		private int _selectedCurrentOrderStatus = (int)OrderStatusEnum.ACTIVE;
		private int _selectedCustomerId = 0;
		private int _currentCustomerId = 0;
		private string _orderCode = string.Empty;
		private bool _needUpdateChange = false;

		private int _selectedIssueItem = 0;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			// when status = COMPLETE
			this.lbFinishDate.Visible = (_selectedCurrentOrderStatus == (int)OrderStatusEnum.COMPLETED);
			this.txtDateFinish.Visible = this.lbFinishDate.Visible;
			this.btnFinishDate.Visible = this.lbFinishDate.Visible;

			// when Mode = Edit
			this.cbxJobStatus.Enabled = (_mode == ActionMode.Edit);
			this.lbLastOrder.Visible = !this.cbxJobStatus.Enabled;
			this.txtLastOrder.Visible = this.lbLastOrder.Visible;

			this.chkAutoJobRunning.Enabled = (_mode == ActionMode.Add);
			this.txtOrderNo.Enabled = ((_mode == ActionMode.Edit) ? false : ((this.chkAutoJobRunning.Checked == true) ? false : true));
			this.txtCustomerCode.ReadOnly = true;
			this.txtCustomerName.ReadOnly = this.txtCustomerCode.ReadOnly;

			this.btnCustomer.Enabled = ((_mode == ActionMode.Add) ? true : false);
			this.btnModel.Enabled = !string.IsNullOrEmpty(this.txtCustomerCode.Text);
			this.btnSerial.Enabled = !string.IsNullOrEmpty(this.txtModel.Text);

			this.pnlFixAndSp.Enabled = (_mode != ActionMode.Add);

			switch (_mode)
			{
				case ActionMode.Add:
					this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtCustomerName.Text);
					this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtModel.Text);
					break;
				case ActionMode.Edit:
					this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtCustomerName.Text);
					this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtModel.Text);
					if (_selectedCurrentOrderStatus == (int)OrderStatusEnum.COMPLETED)
					{
						this.btnSave.Enabled = !string.IsNullOrEmpty(this.txtDateFinish.Text);
					}
					break;
			}
			this.btnSave.Enabled = _needUpdateChange;

			// For order repair
			this.tsbtnRepairEdit.Enabled = (_selectedOrderFixedItemId > 0);
			this.tsbtnRepairDelete.Enabled = this.tsbtnRepairEdit.Enabled;

			// For order spare part (Issue)
			this.tsbtnIssueEditItem.Enabled = (_selectedIssueItem > 0);
			this.tsbtnIssueDeleteItem.Enabled = this.tsbtnIssueEditItem.Enabled;

		} // end UpdateUI

		private void GetStatusList()
		{
			this.cbxJobStatus.DataSource = Services.ServiceController.ServiceJobStatus.GetJobStatusList();
			this.cbxJobStatus.DisplayMember = "KEY";
			this.cbxJobStatus.ValueMember = "VALUE";

		} // end GetStatusList

		private void GetOrderPiorityList()
		{
			this.cbxWorkPiority.DataSource = Services.ServiceController.ServiceJobInfoController.GetJobPiorityList();
			this.cbxWorkPiority.DisplayMember = "KEY";
			this.cbxWorkPiority.ValueMember = "VALUE";

		} // end GetOrderPiorityList

		private void GetOrderErrorList()
		{
			this.cbxError.DataSource = Services.ServiceController.ServiceJobInfoController.GetJobErrorList();
			this.cbxError.DisplayMember = "KEY";
			this.cbxError.ValueMember = "VALUE";

		} // end GetOrderErrorList

		private void GetOrderFixedDetails()
		{
			StringBuilder s = new StringBuilder();

			if (this.dgvDateRepair.Rows.Count > 0)
			{
				foreach (DataGridViewRow dgr in this.dgvDateRepair.Rows)
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
			}

			this.txtRepairInfo.Text = s.ToString();

		} // end GetOrderFixedDetails

		private void GetOrderIssueItems(string OrderCode, int OrderId)
		{
			// mapping data
			this.dgvSP.SuspendLayout();
			this.dgvSP.DataSource = new Warehouse.WarehouseContoller.IssueController().GetSparePartItems(OrderCode, OrderId);

			// hide columns
			this.dgvSP.Columns["SPLINE"].Visible = false;
			this.dgvSP.Columns["ORDERID"].Visible = false;
			this.dgvSP.Columns["ORDERCODE"].Visible = false;
			this.dgvSP.Columns["INDATABASE"].Visible = false;
			this.dgvSP.Columns["AUDIT"].Visible = false;
			this.dgvSP.Columns["MODIUSER"].Visible = false;
			this.dgvSP.Columns["LASTUPDATE"].Visible = false;
			this.dgvSP.Columns["ITEMREMARK"].Visible = false;
			this.dgvSP.Columns["UCOST"].Visible = false;

			// formatting columns
			this.dgvSP.Columns["ISSUENO"].HeaderText = "เลฃที่ใบเบิก";
			this.dgvSP.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			this.dgvSP.Columns["ITEMNAME"].HeaderText = "ชื่อสินค้า";
			this.dgvSP.Columns["UOM"].HeaderText = "หน่วยนับ";

			this.dgvSP.Columns["QTYNEED"].HeaderText = "จำนวนเบิก";
			this.dgvSP.Columns["QTYNEED"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvSP.Columns["QTYNEED"].DefaultCellStyle.Format = "N2";

			this.dgvSP.Columns["UPRICE"].HeaderText = "ราคา/หน่วย";
			this.dgvSP.Columns["UPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvSP.Columns["UPRICE"].DefaultCellStyle.Format = "N2";

			this.dgvSP.Columns["DISCOUNT"].HeaderText = "ส่วนลด";
			this.dgvSP.Columns["DISCOUNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvSP.Columns["DISCOUNT"].DefaultCellStyle.Format = "N2";

			this.dgvSP.Columns["NETUPRICE"].HeaderText = "ราคาสุทธิ";
			this.dgvSP.Columns["NETUPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvSP.Columns["NETUPRICE"].DefaultCellStyle.Format = "N2";

			this.dgvSP.Columns["TOTALPRICE"].HeaderText = "รวมราคา";
			this.dgvSP.Columns["TOTALPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgvSP.Columns["TOTALPRICE"].DefaultCellStyle.Format = "N2";


			this.dgvSP.ResumeLayout();

			// display counter
			this.tslbCount.Text = string.Format("{0} รายการ", this.dgvSP.Rows.Count);

			this.txtSparepartCost.Text = string.Format("{0:N2}", this.UpdateSparePartValues());

			this.UpdateUI();

		} // end GetOrderSPItems

		private decimal UpdateSparePartValues()
		{
			_needUpdateChange = true;
			return ((DataTable)this.dgvSP.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("TotalPrice"));

		} // end UpdateSparePartValues

		private void GetCustomer()
		{
			using (Master.MasterView.CustomerSearch _cust = new Master.MasterView.CustomerSearch())
			{
				if (_cust.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.txtCustomerName.Text = _cust.CustomerName;
					this.txtCustomerCode.Text = _cust.CustomerCode;
					this.txtCustomerCode.Tag = _cust.CustomerId;
					_selectedCustomerId = _cust.CustomerId;
				}
			}

		} // end GetCustomer

		private void GetMachineByCustomer(string CustomerCode)
		{
			using (OMControls.OMView.SearchField _model = new OMControls.OMView.SearchField())
			{
				_model.Title = "Select Machine";
				_model.DataSource = Services.ServiceController.MachineRecordController.GetMachineByCustomer(CustomerCode);
				if (_model.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.txtModel.Text = _model.SelectedKey;
					this.txtModel.Tag = _model.SelectedValue;
				}
			}
		} // end GetMachineByCustomer

		private void GetMachineSerialNoByModel(string CustomerCode, string Model)
		{
			using (OMControls.OMView.SearchField _sn = new OMControls.OMView.SearchField())
			{
				_sn.Title = "Select Serial-No.";
				_sn.DataSource = Services.ServiceController.MachineRecordController.GetMachineSerialNoByModel(CustomerCode, Model);
				if (_sn.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					this.txtSerial.Text = _sn.SelectedValue;
				}
			}
		} // end GetMachineSerialNoByModel


		private void GetOrderDataSource(ActionMode Mode, int JobId)
		{
			switch (Mode)
			{
				case ActionMode.Add:
					_ord = new ORDERMAINTENANCE();

					// add default value to object
					this.chkAutoJobRunning.Checked = true;
					_ord.isdelete = false;
					_ord.orderdate = DateTime.Today;
					_ord.duedate = OMControls.OMUtils.Date2Num(_ord.orderdate.Value.AddDays(5));
					_ord.finishdate = null;
					_ord.orderCode = _orderCode;
					_ord.pmAppointDate = DateTime.Today;
					_selectedCurrentOrderStatus = (int)OrderStatusEnum.ACTIVE;
					_ord.status = _selectedCurrentOrderStatus;
					_ord.actionpiority = 1;
					_ord.errorcode = "E0000";

					break;

				case ActionMode.Edit:
					_ord = new ServiceController.ServiceJobInfoController().GetJobOrderInfo(JobId);

					break;
			}

			this.cbxJobStatus.SelectedValue = _ord.status;
			this.cbxWorkPiority.SelectedValue = _ord.actionpiority;
			this.cbxError.SelectedValue = _ord.errorcode;
			this.dtpOrderDate.Value = _ord.orderdate.Value;
			this.dtpDueDate.Value = OMControls.OMUtils.Num2Date(_ord.duedate);
			this.lbJobOrderType.Text = Services.ServiceController.ServiceJobStatus.GetOrderType(_ord.orderCode);
			_currentCustomerId = _ord.custid;
			this.lbOrderCode.Text = _ord.orderCode;
			this.txtOrderNo.Text = (string.IsNullOrEmpty(_ord.s_order) ? _AUTO_JOBORDER : _ord.s_order);
			this.txtCustomerCode.Tag = _ord.custid;
			this.txtCustomerCode.Text = _ord.acccustcode;
			this.txtCustomerName.Text = _ord.cus_na;
			this.txtLastOrder.Text = Services.ServiceController.ServiceJobInfoController.GetLastServiceOrderByOrderType(_ord.orderCode);
			this.txtModel.Text = _ord.type;
			this.txtModel.Tag = _ord.productid;
			this.txtSerial.Text = _ord.s_no;
			this.txtServiceCharge.Text = string.Format("{0:N2}", _ord.servicecost);
			this.txtSparepartCost.Text = string.Format("{0:N2}", _ord.sparepartcost);
			this.txtError.Text = _ord.error;
			this.txtDateFinish.Text = _ord.finishdate == (DateTime?)null ? string.Empty : _ord.finishdate.Value.ToShortDateString();

			// get job fixed details
			this.GetOrderFixedItems(_ord.orderCode, _ord.orderid);

			// retrieve order spare part items
			this.GetOrderIssueItems(_ord.orderCode, _ord.orderid);


			this.UpdateUI();

		} // end GetOrderDataSource

		private void GetOrderFixedItems(string OrderCode, int OrderId)
		{
			this.dgvDateRepair.SuspendLayout();
			this.dgvDateRepair.DataSource = new Services.ServiceController.ServiceJobInfoController().GetJobOrderFixedItems(OrderCode, OrderId);

			foreach (DataGridViewColumn dgc in this.dgvDateRepair.Columns)
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
			this.dgvDateRepair.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDateRepair.ResumeLayout();

			// retrieve order fixed info
			this.GetOrderFixedDetails();

		} // end GetOrderFixedItems

		private void GetOrderFixedItemInfo(int JobId, string OrderCode, string OrderNumber, int LineId)
		{
			using (Services.ServiceView.OrderFixInfo _ordFix = new OrderFixInfo(LineId, JobId, OrderCode, OrderNumber))
			{
				_ordFix.StartPosition = FormStartPosition.CenterScreen;
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
					if (this.chkAutoJobRunning.Checked == true)
					{
						_ord.s_order = Services.ServiceController.ServiceJobInfoController.CreateServiceOrderNumber(_ord.orderCode);
						_ord.yearservice = Convert.ToInt32(_ord.s_order.Substring(0, _ord.s_order.LastIndexOf("-")));
						_ord.ordercountno = Convert.ToInt32(_ord.s_order.Substring(_ord.s_order.LastIndexOf("-") + 1));
						_ord.orderdate = this.dtpOrderDate.Value;
						_ord.year = _ord.orderdate.Value;
						_ord.finishdate = (DateTime?)null;
						_ord.duedate = OMControls.OMUtils.Date2Num(this.dtpDueDate.Value);
						_ord.or_date = _ord.orderdate.Value.ToShortDateString();
						_ord.auditdt = DateTime.Now;
						_ord.audituser = omglobal.UserName;
					}

					break;

				case ActionMode.Edit:

					if (_selectedCurrentOrderStatus == (int)OrderStatusEnum.COMPLETED)
					{
						if (OMControls.OMUtils.IsDate(this.txtDateFinish.Text))
						{
							_ord.finishdate = Convert.ToDateTime(this.txtDateFinish.Text);
							_ord.year = Convert.ToDateTime(this.txtDateFinish.Text);
						}
					}
					else
					{
						_ord.year = _ord.orderdate.Value;
						_ord.finishdate = (DateTime?)null;
					}

					break;
			}
			_ord.status = _selectedCurrentOrderStatus;
			_ord.custid = _selectedCustomerId;
			_ord.acccustcode = this.txtCustomerCode.Text;
			_ord.cus_na = this.txtCustomerName.Text;
			_ord.productid = ((this.txtModel.Tag == null) ? string.Empty : this.txtModel.Tag.ToString());
			_ord.type = this.txtModel.Text;
			_ord.s_no = this.txtSerial.Text;
			_ord.errorcode = this.cbxError.SelectedValue.ToString();
			_ord.error = this.txtError.Text;
			_ord.month = _ord.orderdate.Value.Month.ToString();
			_ord.period = _ord.orderdate.Value.Month;
			_ord.fiscyear = _ord.orderdate.Value.Year;
			_ord.inWarrantyService = false;
			_ord.servicecost = Convert.ToDecimal(this.txtServiceCharge.Text);
			_ord.sparepartcost = Convert.ToDecimal(this.txtSparepartCost.Text);
			_ord.modidt = DateTime.Now;
			_ord.modiuser = omglobal.UserName;

			if (new Services.ServiceController.ServiceJobInfoController().UpdateOrderInfo(_ord, _mode) > 0)
			{
				MessageBox.Show("Update Record successfully!!!!!!!!!!!!!");
			}


		} // end SaveAddEditOrder


		#endregion

		//
		// form constructor with parameter
		//
		public ServiceJobInfo(int JobId, string OrderCode = "")
		{
			InitializeComponent();
			_jobId = JobId;
			_orderCode = OrderCode;

			// setting mode by giving job-id
			_mode = (_jobId == 0 ? ActionMode.Add : ActionMode.Edit);

			// show mode
			this.lbMode.Text = _mode.ToString();

		}

		private void ServiceJobInfo_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgvDateRepair);
			OMControls.OMUtils.SettingDataGridView(ref this.dgvSP);

			// create list
			this.GetStatusList();
			this.GetOrderPiorityList();
			this.GetOrderErrorList();

			// get datasource for JOBORDERs
			this.GetOrderDataSource(_mode, _jobId);

		}

		private void dgvDateRepair_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedOrderFixedItemId = Convert.ToInt32(this.dgvDateRepair["LINEID", e.RowIndex].Value);

			this.UpdateUI();

		}

		private void btnFinishDate_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				this.btnFinishDate.SelectedDate = (Microsoft.VisualBasic.Information.IsDate(this.txtDateFinish.Text) ? Convert.ToDateTime(this.txtDateFinish.Text) : DateTime.Today);
			}
			catch
			{
				this.btnFinishDate.SelectedDate = DateTime.Today;
			}
		}

		private void btnFinishDate_DateSelected(object sender, EventArgs e)
		{
			this.txtDateFinish.Text = this.btnFinishDate.SelectedDate.ToShortDateString();
			this.UpdateUI();
		}

		private void cbxJobStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedCurrentOrderStatus = Convert.ToInt32(this.cbxJobStatus.SelectedValue);
			}
			catch
			{
				_selectedCurrentOrderStatus = (int)OrderStatusEnum.ACTIVE;
			}

			// debug
			this.lbCurrentOrderStatus.Text = _selectedCurrentOrderStatus.ToString();
			// end debug

			this.UpdateUI();
		}

		private void btnCustomer_Click(object sender, EventArgs e)
		{
			this.GetCustomer();
		}

		private void btnModel_Click(object sender, EventArgs e)
		{
			this.GetMachineByCustomer(this.txtCustomerCode.Text);
		}

		private void chkAutoJobRunning_CheckedChanged(object sender, EventArgs e)
		{
			this.txtOrderNo.Text = (this.chkAutoJobRunning.Checked == true ? _AUTO_JOBORDER : string.Empty);

			this.UpdateUI();
		}

		private void btnSerial_Click(object sender, EventArgs e)
		{
			this.GetMachineSerialNoByModel(this.txtCustomerCode.Text, this.txtModel.Text);
		}

		private void txtModel_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void txtCustomerCode_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnCreateNewOrderNo_Click(object sender, EventArgs e)
		{
			this.txtOrderNo.Text = Services.ServiceController.ServiceJobInfoController.CreateServiceOrderNumber(_orderCode);
		}

		private void btnAddError_Click(object sender, EventArgs e)
		{
			using (Services.ServiceView.ErrList _err = new ErrList())
			{
				_err.StartPosition = FormStartPosition.CenterScreen;
				_err.ShowDialog(this);
			}
			this.GetOrderErrorList();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// mapping data
			this.SaveAddEditOrder();
		}

		private void dtpOrderDate_ValueChanged(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.dtpDueDate.Value = this.dtpOrderDate.Value.AddDays(5);
					break;
			}
		}

		private void txtDateFinish_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void tsbtnRepairEdit_Click(object sender, EventArgs e)
		{
			this.GetOrderFixedItemInfo(_jobId, _orderCode, this.txtOrderNo.Text, _selectedOrderFixedItemId);
		}

		private void tsbtnRepairAdd_Click(object sender, EventArgs e)
		{
			_selectedOrderFixedItemId = 0;
			this.GetOrderFixedItemInfo(_jobId, _orderCode, this.txtOrderNo.Text, _selectedOrderFixedItemId);
		}

		private void tsbtnRepairRefresh_Click(object sender, EventArgs e)
		{
			// get job fixed details
			this.GetOrderFixedItems(_ord.orderCode, _ord.orderid);
		}

		private void dgvDateRepair_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnRepairEdit.PerformClick();
		}

		private void tsbtnIssueSelect_Click(object sender, EventArgs e)
		{
			// TAG of this button is "DRSV"
			ToolStripButton _btn = sender as ToolStripButton;
			string _issueCode = _btn.Tag.ToString().ToUpper();

			Warehouse.WarehouseView.SPIssueList _sp = new Warehouse.WarehouseView.SPIssueList(_issueCode, Warehouse.WarehouseContoller.WarehouseSPViewMode.Select);
			_sp.OrderCode = _orderCode;
			_sp.OrderId = _jobId;
			_sp.OrderNumber = this.txtOrderNo.Text;
			_sp.StartPosition = FormStartPosition.CenterScreen;
			_sp.ShowDialog(this);

			this.tsbtnIssueRefresh.PerformClick();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnIssueRefresh_Click(object sender, EventArgs e)
		{
			this.GetOrderIssueItems(_orderCode, _jobId);
		}

		private void dgvSP_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedIssueItem = Convert.ToInt32(this.dgvSP["SPLINE", e.RowIndex].Value);

			this.UpdateUI();
		}

		private void tsbtnIssueDeleteItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต่้องการลบรายการที่เลือก?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			{
				if (new Warehouse.WarehouseContoller.IssueController().DeleteIssueItem(_selectedIssueItem) > 0)
				{
					MessageBox.Show("Remove item successfully....", "Remove");
				}
				this.tsbtnIssueRefresh.PerformClick();
			}
		}

		private void tsbtnRepairDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("ต้องการลบรายการที่เลือก?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
			{
				if (Services.ServiceController.ServiceJobInfoController.DeleteOrderRepairItem(_selectedOrderFixedItemId, _jobId) > 0)
				{
					MessageBox.Show("รายการที่เลือกได้ถูกลบออกจากระบบแล้ว.....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				this.tsbtnRepairRefresh.PerformClick();
			}
		}

		private void tsbtnIssueEditItem_Click(object sender, EventArgs e)
		{
			this.AddEditIssueItem(_selectedIssueItem);
		}

		private void tsbtnIssueAddItem_Click(object sender, EventArgs e)
		{
			_selectedIssueItem = 0;
			this.AddEditIssueItem(_selectedIssueItem);
		}

		private void AddEditIssueItem(int IssueItemId)
		{
			using (Services.ServiceView.JobSPItemInfo _spItemInfo = new JobSPItemInfo(IssueItemId, _jobId, _orderCode, this.txtOrderNo.Text))
			{

				_spItemInfo.StartPosition = FormStartPosition.CenterScreen;
				_spItemInfo.ShowDialog();
			}

			this.tsbtnIssueRefresh.PerformClick();

		}

		private void dgvSP_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnIssueEditItem.PerformClick();
		}
	}
}
