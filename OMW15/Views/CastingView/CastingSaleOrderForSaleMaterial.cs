using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class CastingSaleOrderForSaleMaterial : Form
	{
		// CONSTRUCTOR
		public CastingSaleOrderForSaleMaterial(string CustomerCode, string CustomerName)
		{
			InitializeComponent();
			_customerCode = CustomerCode;
			_customerName = CustomerName;
			lbHeader.Text = string.Format("Casting Order List for Customer : {0}", _customerName);
		}

		private void CastingSaleOrderForSaleMaterial_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);
			lbCustCode.Text = _customerCode;
			GetCastingOrderList(_customerCode);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dgv.Rows.Count > 0)
			{
				RowSource = dgv.Rows[e.RowIndex];
				DeliveredMaterialWeight = Convert.ToDecimal(dgv["REMAINWEIGHT", e.RowIndex].Value);
				DeliveredMaterialId = Convert.ToInt32(dgv["DELIVERMAT", e.RowIndex].Value);
				MasterSaleOrderNumber = dgv["SONO", e.RowIndex].Value.ToString();
			}
		}

		#region class field member

		private readonly string _customerCode = string.Empty;
		private readonly string _customerName = string.Empty;

		#endregion

		#region class property

		public DataGridViewRow RowSource { get; set; }

		public int DeliveredMaterialId { get; set; }

		public decimal DeliveredMaterialWeight { get; set; }

		public string MasterSaleOrderNumber { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI


		private async void GetCastingOrderList(string CustomerCode)
		{
			var _dal = new CastingSaleOrderDAL();
			//var dt = await _dal.GetCastingSaleOrderListAsync(OMShareCastingEnums.CastingOrderStatus.Active, CustomerCode, true);

			var dt = await _dal.GetCastingSaleOrderListAsync(omglobal.SysConnectionString,OMShareCastingEnums.CastingOrderStatus.Active, CustomerCode, true, OMShareCastingEnums.CastingOrderCallType.None, omglobal.NONVAT_DISPLAY);

			// filter for have remaining weight only
			dt.DefaultView.RowFilter = "RemainWeight > 0.00";

			dgv.SuspendLayout();

			try
			{
				dgv.DataSource = dt;
				dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
				dgv.Columns["CUSTID"].Visible = false;
				dgv.Columns["ISVAT"].Visible = false;
				dgv.Columns["SALETYPE"].Visible = false;
				dgv.Columns["TYPE"].Visible = false;
				dgv.Columns["ORDERDATE"].Visible = false;
				dgv.Columns["Status"].Visible = false;
				dgv.Columns["TOTALVALUE"].Visible = false;
				dgv.Columns["DISCOUNT"].Visible = false;
				dgv.Columns["NETORDERVALUE"].Visible = false;
				dgv.Columns["VATVALUE"].Visible = false;

				dgv.Columns["SOSEQ"].Visible = dgv.Columns["CUSTID"].Visible;
				dgv.Columns["SALEMATID"].Visible = dgv.Columns["CUSTID"].Visible;
				dgv.Columns["BILLSEQ"].Visible = dgv.Columns["CUSTID"].Visible;
				dgv.Columns["DELIVERMAT"].Visible = dgv.Columns["CUSTID"].Visible;
				dgv.Columns["DELIVERWEIGHT"].Visible = dgv.Columns["CUSTID"].Visible;

				dgv.Columns["StatusName"].HeaderText = "สถานะ";
				dgv.Columns["THKEYNAME"].HeaderText = "MATERIAL";
				dgv.Columns["REMAINWEIGHT"].HeaderText = "WEIGHT (g)";
				dgv.Columns["CUSTCODE"].HeaderText = "CODE";
				dgv.Columns["SONO"].HeaderText = "ORDER NO.";
				dgv.Columns["ORDERDATE"].HeaderText = "DATE";
				dgv.Columns["TOTALAMOUNT"].HeaderText = "TOTAL AMOUNT";

				foreach (DataGridViewColumn dgc in dgv.Columns)
				{
					if (dgc.ValueType == typeof(decimal))
					{
						dgc.DefaultCellStyle = DataGridViewSettingStyle.NumericCellStyle();
					}
				}
				dgv.Columns["CUSTOMER"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}

			dgv.ResumeLayout();
		} // end GetCastingOrderList

		#endregion
	}
}