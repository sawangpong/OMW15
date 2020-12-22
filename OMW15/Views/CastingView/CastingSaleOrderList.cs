using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Properties;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingSaleOrderList : Form
	{
		// CONSTRUCTOR
		public CastingSaleOrderList()
		{
			InitializeComponent();
			WindowState = FormWindowState.Maximized;
			pnlHeader.BackColor = omglobal.OM_ORANGE_COLOR;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CastingSaleOrderList_Load(object sender, EventArgs e)
		{
			CenterToParent();

			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv);

			chkShowAllCustomers.Checked = true;

			GetOrderStatusList();
			// initial variable value
			_castingOrderStatus = OMShareCastingEnums.CastingOrderStatus.Active;
			_customerCode = string.Empty;
			_customerId = 0;
			_customerName = string.Empty;
			_selectedCustomerFromTheList = string.Empty;


			// Updating UI
			UpdateUI();
		}

		private void chkShowAllCustomers_CheckedChanged(object sender, EventArgs e)
		{
			_customerCode = chkShowAllCustomers.Checked ? "" : _customerCode;
			lbCustomer.Visible = chkShowAllCustomers.Checked == false;
			txtCustomer.Visible = lbCustomer.Visible;
			btnCustomerSearch.Visible = lbCustomer.Visible;

			UpdateUI();
		}

		private void btnCustomerSearch_Click(object sender, EventArgs e)
		{
			using (
				var customers = new CastingOrderCustomers(txtCustomer.Text,
					OMShareCastingEnums.CustomerList.OnlyForCastingSaleOrders))
			{
				customers.StartPosition = FormStartPosition.CenterScreen;
				if (customers.ShowDialog(this) == DialogResult.OK)
				{
					txtCustomer.Text = customers.CustomerName;
					_customerCode = customers.CustomerCode;
					_customerId = customers.CustomerId;

					if (chkShowAllCustomers.Checked == false)
						_selectedCustomerFromTheList = _customerCode;
				}
			}

			UpdateUI();
		}


		private void tsbtnClose_Click_1(object sender, EventArgs e)
		{
			Close();
		}

		private void cbxStatus_SelectedValueChanged(object sender, EventArgs e)
		{
			_castingOrderStatus =
				(OMShareCastingEnums.CastingOrderStatus)Enum.Parse(typeof(OMShareCastingEnums.CastingOrderStatus), cbxStatus.Text);

			lbBilled.Visible = _castingOrderStatus == OMShareCastingEnums.CastingOrderStatus.All;
		}

		private void txtCustomer_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			// refresh Casting Sale Order as selected Customer Code
			GetCastingOrderList(_castingOrderStatus, _customerCode, "");
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetCastingSaleOrderInfo(_selectedSOId = 0, _selectedCustomerFromTheList);
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetCastingSaleOrderInfo(_selectedSOId, _selectedCustomerFromTheList);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgv.Rows.Count == _rowCount)
			{
				_selectedSOId = Convert.ToInt32(dgv["SOSEQ", e.RowIndex].Value);
				_selectedCustomerFromTheList = dgv["CUSTCODE", e.RowIndex].Value.ToString();
				_selectedCustomerNameFromTheList = dgv["CUSTOMER", e.RowIndex].Value.ToString();
				_selectedSaleType =
					(OMShareCastingEnums.SaleTypeEnum)
					Enum.ToObject(typeof(OMShareCastingEnums.SaleTypeEnum), Convert.ToInt32(dgv["SALETYPE", e.RowIndex].Value));
				_isVAT = Convert.ToBoolean(dgv["ISVAT", e.RowIndex].Value);
				_remainWeight = Convert.ToDecimal(dgv["REMAINWEIGHT", e.RowIndex].Value);
				_selectedOrderStatus = Convert.ToInt32(dgv["STATUS", e.RowIndex].Value);
			}

			lbSOId.Text = $"id :: {_selectedSOId}";
			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			btnLoadData.PerformClick();
		}

		private void txtCustomer_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
				btnCustomerSearch.PerformClick();
		}

		private void tsbtnPrintSO_Click(object sender, EventArgs e)
		{
			var _rpt = new CastingReportView();
			if (_isVAT)
			{
				if (_selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
					_rpt.PrintWhat = PrintDocumentType.SaleMaterialWithVAT;
				else
					_rpt.PrintWhat = PrintDocumentType.SaleOrderWithVAT;
			}
			else
			{
				if (_selectedSaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
					_rpt.PrintWhat = PrintDocumentType.SaleMaterialNoVAT;
				else
					_rpt.PrintWhat = PrintDocumentType.SaleOrderNoVAT;
			}
			_rpt.WindowState = FormWindowState.Maximized;
			_rpt.SaleOrderId = _selectedSOId;
			_rpt.Show();
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Do you want to delete the selected Sale Order?", "Delete Sale Order", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				if (new CastingSaleOrderDAL().MarkDeleteCastingSaleOrder(_selectedSOId) > 0)
					MessageBox.Show("Delete Sale Order Complete....", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

			tsbtnRefresh.PerformClick();
		}

		private void tsbtnBilling_Click(object sender, EventArgs e)
		{
			using (var _bl = new CastingOrderBilling(_selectedCustomerFromTheList, _selectedCustomerNameFromTheList))
			{
				_bl.StartPosition = FormStartPosition.CenterScreen;
				_bl.ShowDialog(this);
			}

			btnLoadData.PerformClick();
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (_castingOrderStatus == (int)OMShareCastingEnums.CastingOrderStatus.All)
				if (Convert.ToInt32(dgv["BILLSEQ", e.RowIndex].Value) > 0)
				{
					e.CellStyle.BackColor = Color.Orange;
					e.CellStyle.ForeColor = Color.DarkBlue;
				}
		}

		private void tsbtnSearchSI_Click(object sender, EventArgs e)
		{
			GetCastingOrderList(_castingOrderStatus, _customerCode,
				OMDataUtils.GetFilter<string>("กำหนดหมายใบส่งสินค้า (SI) ที่ต้องการค้นหา"));
		}

		private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1 && e.ColumnIndex == 0)
			{
				e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
				e.Graphics.DrawIcon(Resources.printer, new Rectangle(e.CellBounds.X + 1,
					e.CellBounds.Y + 1, e.CellBounds.Width - 30,
					e.CellBounds.Height - 4));
				e.Handled = true;
			}
		}

		#region class field member

		private OMShareCastingEnums.CastingOrderStatus _castingOrderStatus = OMShareCastingEnums.CastingOrderStatus.Active;
		private int _selectedSOId;
		private OMShareCastingEnums.SaleTypeEnum _selectedSaleType = OMShareCastingEnums.SaleTypeEnum.ไม่ระบุ;
		private string _selectedStatusTextMenu = string.Empty;
		private string _selectedSONumber = string.Empty;
		private string _customerCode = string.Empty;
		private string _selectedCustomerFromTheList = string.Empty;
		private string _selectedCustomerNameFromTheList = string.Empty;
		private string _customerName = string.Empty;
		private int _selectedOrderStatus = (int)OMShareCastingEnums.CastingOrderStatus.Active;
		private int _customerId;
		private bool _isVAT;
		private int _rowCount;
		private decimal _remainWeight;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnAdd.Enabled = !string.IsNullOrEmpty(_selectedCustomerFromTheList);
			tsbtnEdit.Enabled = (_rowCount > 0
								&& _selectedSOId > 0
								&& _selectedOrderStatus == (int)OMShareCastingEnums.CastingOrderStatus.Active
								&& _remainWeight > 0.00m);
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
			tsbtnPrintSO.Enabled = (_selectedSOId > 0);
			tsbtnRefresh.Enabled = tsbtnEdit.Enabled;
			btnLoadData.Enabled = chkShowAllCustomers.Checked ? true : txtCustomer.Text != "";
			tsbtnSearchSI.Enabled = dgv.Rows.Count > 0;
			tsbtnBilling.Enabled = tsbtnAdd.Enabled;

		} // end UpdateUI

		private void GetOrderStatusList()
		{
			cbxStatus.DataSource = OMDataUtils.GetValueList<OMShareCastingEnums.CastingOrderStatus>();
			cbxStatus.DisplayMember = "VALUE";
			cbxStatus.ValueMember = "KEY";
		} // end GetOrderStatusList


		private async void GetCastingOrderList(OMShareCastingEnums.CastingOrderStatus Status, string CustomerCode,
			string SIFilter)
		{
			var _dal = new CastingSaleOrderDAL();
			//var dt = await _dal.GetCastingSaleOrderListAsync(Status, CustomerCode);
			var dt = await _dal.GetCastingSaleOrderListAsync(omglobal.SysConnectionString,OMShareCastingEnums.CastingOrderStatus.Active, CustomerCode,false, OMShareCastingEnums.CastingOrderCallType.None, omglobal.NONVAT_DISPLAY);


			if (!string.IsNullOrEmpty(SIFilter))
			{
				dt.DefaultView.RowFilter = $"SONO LIKE '%{SIFilter}%'";
			}

			dgv.SuspendLayout();
			dgv.DataSource = dt;
			dgv.Columns["STATUS"].Visible = false;
			dgv.Columns["ISVAT"].Visible = false;
			dgv.Columns["SALETYPE"].Visible = false;
			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["SOSEQ"].Visible = false;
			dgv.Columns["BILLSEQ"].Visible = false;
			dgv.Columns["SALEMATID"].Visible = false;
			dgv.Columns["DELIVERMAT"].Visible = false;
			dgv.Columns["CATEGORY"].Visible = false;


			dgv.Columns["PNT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgv.Columns["TYPE"].Frozen = true;

			dgv.Columns["StatusName"].HeaderText = "สถานะ";
			dgv.Columns["TYPE"].HeaderText = "ประเภทงานขาย";
			dgv.Columns["CUSTCODE"].HeaderText = "รหัสลูกค้า";
			dgv.Columns["CUSTOMER"].HeaderText = "ชื่อลูกค้า";
			dgv.Columns["SONO"].HeaderText = "หมายเลขใบส่งสินค้า";
			dgv.Columns["ORDERDATE"].HeaderText = "วันที่";
			dgv.Columns["ORDERDUE"].HeaderText = "วันครบกำหนด";
			dgv.Columns["TOTALVALUE"].HeaderText = "ราคารวม (บาท)";
			dgv.Columns["DISCOUNT"].HeaderText = "ส่วนลด (บาท)";
			dgv.Columns["NETORDERVALUE"].HeaderText = "ราคาสุทธิ (บาท)";
			dgv.Columns["VATVALUE"].HeaderText = "ภาษีมูลค่าเพิ่ม (บาท)";
			dgv.Columns["TOTALAMOUNT"].HeaderText = "ราคารวมท้งหมด (บาท)";
			dgv.Columns["THKEYNAME"].HeaderText = "ประเภทวัสดุ";
			dgv.Columns["DELIVERWEIGHT"].HeaderText = "น.น.รวม (กรัม)";
			dgv.Columns["REMAINWEIGHT"].HeaderText = "น.น. คงค้าง (กรัม)";


			foreach (DataGridViewColumn dgc in dgv.Columns)
				if (dgc.ValueType == typeof(decimal))
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();

			lbSOCount.Text = $"found : {_rowCount = dgv.Rows.Count}";

			dgv.ResumeLayout();

			UpdateUI();
		} // end GetCastingOrderListByStatus

		private void GetCastingSaleOrderInfo(int CastingSaleOrderId, string CustomerCode)
		{
			using (var _cinfo = new CastingSaleOrderInfo(CastingSaleOrderId, CustomerCode))
			{
				_cinfo.StartPosition = FormStartPosition.CenterScreen;
				_cinfo.ShowDialog(this);
			}

			// refresh Casting Sale Order list
			tsbtnRefresh.PerformClick();
		} // end GetCastingSaleOrderInfo

		#endregion
	}
}