using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
	public partial class CastingFGItems : Form
	{
		// CONSTRUCTOR
		public CastingFGItems()
		{
			InitializeComponent();
		}

		private void CastingFGItems_Load(object sender, EventArgs e)
		{
			// force this form to show to the center of the parent call
			CenterToParent();

			OMUtils.SettingDataGridView(ref dgv);
			dgv.MultiSelect = true;

			// display sending parameter
			lbMaterial.Text = $"Mat ({MaterialId}) {MaterialName}";
			lbRefSOId.Text = $"SO id : {this.RefSOId} SO GUID : {this.SOGuid.ToString()}";
			lbSONumber.Text = $"SO : {SONumber}";
			lbCustomer.Text = $"Customer ({CustomerId}) :[{CustomerCode}] {CustomerName}";
			lbSaleType.Text = SaleType.ToString();
			lbVATFactor.Text = $"V.Rate : {VATFactor:N2}";
			UpdateUI();

			// initial backgroudworker
			//bg.WorkerReportsProgress = true;
			//bg.WorkerSupportsCancellation = true;
			//bg.DoWork += bg_Dowork;
			//bg.ProgressChanged += bg_ProgressChanged;
			//bg.RunWorkerCompleted += bg_RunWorkerCompleted;

			//if (bg.IsBusy != true)
			//{
			//	alert = new LoadAlert();
			//	alert.StartPosition = FormStartPosition.CenterParent;
			//	alert.Show(this);
			//	dgv.SuspendLayout();
			//	bg.RunWorkerAsync();
			//	dgv.ResumeLayout();
			//}

			UpdateUI();

			// loading available items
			GetAvailableFGItem(CustomerCode, MaterialId, RefSOId, HasItem);

		}

		//private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		//{
		//	alert.Close();
		//}

		//private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
		//{
		//	alert.Message = $"Loading in progress, please wait...{e.ProgressPercentage} %";
		//	alert.ProgressValue = e.ProgressPercentage;
		//}

		//private void bg_Dowork(object sender, DoWorkEventArgs e)
		//{
		//	var _worker = sender as BackgroundWorker;

		//	for (var i = 1; i <= 100; i++)
		//		if (_worker.CancellationPending)
		//		{
		//			e.Cancel = true;
		//			break;
		//		}
		//		else
		//		{
		//			_worker.ReportProgress(i);
		//			Thread.Sleep(20);
		//		}
		//}

		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
			lbSelectedItemCount.Text = $"selected item(s) : {dgv.SelectedRows.Count}";
			var _totalQty = 0.00m;
			var _totalWeight = 0.00m;
			var _totalPrice = 0.00m;

			foreach (DataGridViewRow dgr in dgv.SelectedRows)
			{
				var _qty = Convert.ToDecimal(dgr.Cells["QTY"].Value);
				var _unitPrice = Convert.ToDecimal(dgr.Cells["UNITPRICE"].Value);
				var _weight = Convert.ToDecimal(dgr.Cells["WEIGHT"].Value);
				_totalQty += _qty;
				_totalWeight += _weight;
				_totalPrice += _qty * _unitPrice;
			}

			lbQtySelected.Text = $"selected Qty. : {_totalQty:N2}";
			lbWeightSeleted.Text = $"total weight : {_totalWeight:N2} (g)";
			lbTotalPrice.Text = $"total price : {_totalPrice:N2} (THB)";
		}

		private void btnSelect_Click(object sender, EventArgs e)
		{
			ConfirmSelectedFGItems();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			lbFGIndex.Text = $"FG : {dgv["FGSEQ", e.RowIndex].Value}";
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		#region class field member

		//private readonly BackgroundWorker bg = new BackgroundWorker();
		//private LoadAlert alert;
		private int _rowCount;

		#endregion

		#region class property

		public ActionMode SOHeaderMode
		{
			get; set;
		}

		public int MaterialId
		{
			get; set;
		}

		public string MaterialName
		{
			get; set;
		}

		public int CustomerId
		{
			get; set;
		}

		public string CustomerCode
		{
			get; set;
		}

		public string CustomerName
		{
			get; set;
		}

		public int RefSOId
		{
			get; set;
		}

		public Guid SOGuid
		{
			get; set;
		}

		public string SONumber
		{
			get; set;
		}

		public OMShareCastingEnums.SaleTypeEnum SaleType
		{
			get; set;
		}

		public decimal VATFactor
		{
			get; set;
		}

		public bool HasItem
		{
			get; set;
		}

		public DateTime ActualDeliveryDate
		{
			get; set;
		}

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSelect.Enabled = dgv.SelectedRows.Count > 0;
		} // end UpdateUI

		private async void GetAvailableFGItem(string CustomerCode, int MaterialId, int SOKey, bool HasItem)
		{
			DataTable dt = new DataTable();
			dgv.SuspendLayout();
			var _dal = new CastingSaleOrderDAL();
			dt = await _dal.GetAvailableFGItemsForSelectedCustomerAsync(CustomerCode, MaterialId, SOKey, HasItem, omglobal.SysConnectionString);
			_rowCount = dt.Rows.Count;
			lbRowCount.Text = $"found : {_rowCount}";

			dgv.DataSource = dt;

			dgv.Columns["MATID"].Visible = false;
			dgv.Columns["FGSEQ"].Visible = false;
			dgv.Columns["ITEMID"].Visible = false;
			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["CUSTCODE"].Visible = false;
			dgv.Columns["TOTALLINEWT"].Visible = false;
			dgv.Columns["TOTALDELIVERYWT"].Visible = false;

			dgv.Columns["JOBNO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dgv.Columns["PREFIX"].HeaderText = "ประเภท";
			dgv.Columns["ITEMNO"].HeaderText = "รหัสสินค้า";
			dgv.Columns["ITEMNAME"].HeaderText = "รายละเอียด";
			dgv.Columns["UNIT"].HeaderText = "หน่วยนับ";
			dgv.Columns["UNITPRICE"].HeaderText = "ราคาต่อหน่วย";
			dgv.Columns["QTY"].HeaderText = "จำนวน";
			dgv.Columns["UNITWEIGHT"].HeaderText = "น.น. ต่อหน่วย";
			dgv.Columns["WEIGHT"].HeaderText = "น.น. รวม (กรัม)";


			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					if (dgc.Name != "DOCDATE")
					{
						dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
					}
				}
				else if (dgc.ValueType == typeof(string))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.StringCellStyle();
				}
			}

			dgv.ResumeLayout();

			UpdateUI();

			//bg.WorkerSupportsCancellation = true;
			//bg.CancelAsync();
			//alert.Close();


		} // end GetAvailableFGItem

		private void ConfirmSelectedFGItems()
		{
			// cloning datatable structure for duplicate datatable
			var confirmDataSource = ((DataTable)dgv.DataSource).Clone();
			DataRow dr;

			// add row and value to confirmDataSource
			foreach (DataGridViewRow dgr in dgv.SelectedRows)
			{
				dr = confirmDataSource.NewRow();
				foreach (DataGridViewColumn dgc in dgv.Columns)
				{
					dr[dgc.Name] = dgr.Cells[dgc.Name].Value;
				}
				confirmDataSource.Rows.Add(dr);
			}

			using (var _cfg = new ConfirmSelectedFGItems(SOHeaderMode, confirmDataSource))
			{
				_cfg.VATFactor = VATFactor;
				_cfg.CustomerCode = CustomerCode;
				_cfg.CustomerId = CustomerId;
				_cfg.CustomerName = CustomerName;
				_cfg.RefSOId = this.RefSOId;
				_cfg.SOGuid = this.SOGuid;
				_cfg.SONumber = SONumber;
				_cfg.SaleType = SaleType;
				_cfg.ActualDeliveryDate = ActualDeliveryDate;

				_cfg.StartPosition = FormStartPosition.CenterParent;
				if (_cfg.ShowDialog(this) == DialogResult.OK)
				{
				}
			}
		} // end ConfirmSelectedFGItems

		#endregion
	}
}