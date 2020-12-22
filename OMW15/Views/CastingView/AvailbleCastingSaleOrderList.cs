using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class AvailbleCastingSaleOrderList : Form
	{
		// CONSTRUCTOR
		public AvailbleCastingSaleOrderList(string CustomerCode, string CustomerName,
			OMShareCastingEnums.SaleTypeEnum SaleType = OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
		{
			InitializeComponent();
			_customerCode = CustomerCode;
			_customerName = CustomerName;
			_saleType = SaleType;
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			CustomerId = Convert.ToInt32(dgv["CUSTID", e.RowIndex].Value);
			SaleOrderId = Convert.ToInt32(dgv["SOSEQ", e.RowIndex].Value);
			SaleOrderNo = dgv["SONO", e.RowIndex].Value.ToString();
			MaterialId = Convert.ToInt32(dgv["DELIVERMAT", e.RowIndex].Value);
			MaterialName = dgv["THKEYNAME", e.RowIndex].Value.ToString();
			TotalWeight = Convert.ToDecimal(dgv["REMAINWEIGHT", e.RowIndex].Value);
			lbCustomer.Text = dgv["CUSTOMER", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void AvailbleCastingSaleOrderList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetSaleOrderList(_customerCode, _saleType);
		}

		#region class field member

		private readonly OMShareCastingEnums.SaleTypeEnum _saleType = OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ;
		private readonly string _customerCode = string.Empty;
		private string _customerName = string.Empty;

		#endregion

		#region class properties

		public int CustomerId { get; set; }

		public int SaleOrderId { get; set; }

		public string SaleOrderNo { get; set; }

		public string MaterialCategory { get; set; }

		public int MaterialId { get; set; }

		public string MaterialName { get; set; }

		public decimal TotalWeight { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			btnSelect.Enabled = SaleOrderId > 0;
		} // end UpdateUI

		private async void GetSaleOrderList(string CustomerCode, OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _dal = new CastingSaleOrderDAL();

			//var _dt = await _dal.GetCastingSaleOrderListAsync(OMShareCastingEnums.CastingOrderStatus.All, CustomerCode, false,
			//	OMShareCastingEnums.CastingOrderCallType.AvailableOrderForSell);

			var _dt = await _dal.GetCastingSaleOrderListAsync(omglobal.SysConnectionString,
										OMShareCastingEnums.CastingOrderStatus.All, 
										CustomerCode, 
										false,
										OMShareCastingEnums.CastingOrderCallType.AvailableOrderForSell,
										omglobal.NONVAT_DISPLAY);

			dgv.SuspendLayout();

			dgv.DataSource =
				_dt.DefaultView.RowFilter =
					string.Format("[SALETYPE] = {0} AND [CATEGORY] = '{1}'", (int) Enum.Parse(typeof(OMShareCastingEnums.SaleTypeEnum), SaleType.ToString()), this.MaterialCategory);

			dgv.DataSource = _dt;

			// formatting dataGridViewColumns
			dgv.Columns["ISVAT"].Visible = false;
			dgv.Columns["CUSTCODE"].Visible = false;
			dgv.Columns["CUSTID"].Visible = false;
			dgv.Columns["SOSEQ"].Visible = false;
			dgv.Columns["SALEMATID"].Visible = false;
			dgv.Columns["BILLSEQ"].Visible = false;
			dgv.Columns["SALETYPE"].Visible = false;
			dgv.Columns["TYPE"].Visible = false;
			dgv.Columns["ORDERDUE"].Visible = false;
			dgv.Columns["TOTALVALUE"].Visible = false;
			dgv.Columns["DISCOUNT"].Visible = false;
			dgv.Columns["NETORDERVALUE"].Visible = false;
			dgv.Columns["VATVALUE"].Visible = false;
			dgv.Columns["TOTALAMOUNT"].Visible = false;
			dgv.Columns["DELIVERMAT"].Visible = false;
			dgv.Columns["DELIVERWEIGHT"].Visible = false;

			dgv.Columns["Status"].Visible = false;
			dgv.Columns["StatusName"].HeaderText = "สถานะ";

			dgv.Columns["CUSTOMER"].HeaderText = "ลูกค้า";
			dgv.Columns["SONO"].HeaderText = "หมายเลขใบส่งสินค้า";
			dgv.Columns["ORDERDATE"].HeaderText = "วันที่";
			dgv.Columns["THKEYNAME"].HeaderText = "วัสดุ";
			dgv.Columns["REMAINWEIGHT"].HeaderText = "น้ำหนักที่ค้าง (กรัม)";

			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.ValueType == typeof(decimal))
				{
					dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
				}
			}
			if (dgv.Rows.Count > 0)
			{
				lbTotalWT.Text = string.Format("Total weight (g) : {0:N2}",
					(dgv.DataSource as DataTable).AsEnumerable().Sum(x => x.Field<decimal>("REMAINWEIGHT")));
			}
			dgv.ResumeLayout();
		} // end GetSaleOrderList

		#endregion
	}
}