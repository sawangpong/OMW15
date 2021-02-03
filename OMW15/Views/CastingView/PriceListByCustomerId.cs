using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.CastingView
{
	public partial class PriceListByCustomerId : Form
	{
		public PriceListByCustomerId()
		{
			InitializeComponent();
			pnlTop.BackColor = omglobal.OM_GREEN_COLOR;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			// search by string input for customer name
			(dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format(
				"[{0}] LIKE '%{1}%'", "ItemNo", OMDataUtils.GetFilter<string>("Select Item-No."));
		}

		private void PriceListByCustomerId_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv);

			// display header
			lbCustomer.Text = string.Format("({0})-[{1}] :: {2}", _customerId, _customerCode, _customerName);
			lbTitle.Text = _title;

			// loading Data by sending parameter - _customerCode (string)
			GetData(_customerCode);

			// update-UI
			UpdateUI();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
				try
				{
					ItemId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
					ItemPrefix = dgv["ITEMCODE", e.RowIndex].Value.ToString();
					ItemCategory = dgv["ITEMTYPE", e.RowIndex].Value.ToString();
					ItemNo = dgv["ITEMNO", e.RowIndex].Value.ToString();
					ItemName = dgv["ITEMNAME", e.RowIndex].Value.ToString();
					Unit = dgv["UNIT", e.RowIndex].Value.ToString();
					ItemScore = Convert.ToDecimal(dgv["SCORE", e.RowIndex].Value);
					ItemMaterial = Convert.ToInt32(dgv["MATERIALID", e.RowIndex].Value);
					ItemMaterialName = dgv["MATERIAL", e.RowIndex].Value.ToString();
					ItemStyle = Convert.ToInt32(dgv["STYLEID", e.RowIndex].Value);
					ItemStyleName = dgv["STYLE", e.RowIndex].Value.ToString();
					CastingUnitPrice = Convert.ToDecimal(dgv["CASTINGPRICE", e.RowIndex].Value);
					UnitPrice = Convert.ToDecimal(dgv["UNITPRICE", e.RowIndex].Value);
					FlaskTemp = dgv["FALSK_TEMP", e.RowIndex].Value.ToString();
					CastTemp = dgv["CAST_TEMP", e.RowIndex].Value.ToString();
					ItemPictureLocation = dgv["ImageLocation", e.RowIndex].Value.ToString();
				}
				catch
				{
					UnitPrice = 0.00m;
					Unit = string.Empty;
					ItemStyle = 0;
					ItemScore = 0.00m;
					ItemPrefix = string.Empty;
					ItemNo = string.Empty;
					ItemName = string.Empty;
					ItemMaterial = 0;
					ItemId = 0;
					CastingUnitPrice = 0.00m;
					FlaskTemp = "";
					CastTemp = "";
					ItemPictureLocation = "";
				}
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		#region class field member

		private int _customerId;
		private string _customerCode = string.Empty;
		private string _customerName = string.Empty;
		private string _title = "Select ? -->";
#pragma warning disable CS0649 // Field 'PriceListByCustomerId._rowCount' is never assigned to, and will always have its default value 0
		private int _rowCount;
#pragma warning restore CS0649 // Field 'PriceListByCustomerId._rowCount' is never assigned to, and will always have its default value 0

		#endregion

		#region class property

		//
		// =================================================================
		// ========================= SET PROPERTY
		public int CustomerId
		{
			set { _customerId = value; }
		}

		public string CustomerCode
		{
			set { _customerCode = value; }
		}

		public string CustomerName
		{
			set { _customerName = value; }
		}

		public string Title
		{
			set { _title = value; }
		}

		//
		// =================================================================
		// ========================= GET PROPERTY
		public int ItemMaterial { get; private set; }

		public string ItemMaterialName { get; private set; } = string.Empty;

		public int ItemStyle { get; private set; }

		public string ItemStyleName { get; private set; } = string.Empty;

		public int ItemId { get; private set; }

		public string ItemPrefix { get; private set; } = string.Empty;

		public string ItemCategory { get; private set; } = string.Empty;

		public string ItemNo { get; private set; } = string.Empty;

		public string ItemName { get; private set; } = string.Empty;

		public string Unit { get; private set; } = string.Empty;

		public decimal CastingUnitPrice { get; private set; }

		public decimal UnitPrice { get; private set; }

		public decimal ItemScore { get; private set; }

		public string CastTemp { get; private set; } = string.Empty;

		public string FlaskTemp { get; private set; } = string.Empty;

		public string ItemPictureLocation { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			btnSelect.Enabled = dgv.Rows.Count > 1;
			btnSearch.Visible = dgv.Rows.Count >= 20;
		} // end UpdateUI


		//private async Task<DataTable> GetPriceListItemData(string CustomerCode)
		//{
		//	return await Task.Run(() =>
		//	{
		//		var dal = new PriceListDAL();
		//		return dal.GetPriceListByCustomerAsync(CustomerCode, 0);
		//	});
		//} // end GetPriceListItemData


#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
		private async void GetData(string CustomerCode)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
		{
			// update control
			dgv.SuspendLayout();

			// binding data
			//var dt = await GetPriceListItemData(CustomerCode);
			//_rowCount = dt.Rows.Count;
			//dgv.DataSource = dt;

			//// formatting DataGridView
			//dgv.Columns["ID"].Visible = false;
			//dgv.Columns["CUSTOMERCODE"].Visible = false;
			//dgv.Columns["MATERIALID"].Visible = false;
			//dgv.Columns["STYLEID"].Visible = false;
			//dgv.Columns["SCORE"].Visible = false;
			//dgv.Columns["HASIMAGE"].Visible = false;
			//dgv.Columns["WEIGHT"].Visible = false;

			//dgv.Columns["UNIT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//dgv.Columns["MATERIAL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//dgv.Columns["STYLE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

			//dgv.Columns["CASTINGPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["CASTINGPRICE"].DefaultCellStyle.Format = "N2";

			//dgv.Columns["UNITPRICE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["UNITPRICE"].DefaultCellStyle.Format = "N2";


			//
			dgv.ResumeLayout();

			// update-UI
			UpdateUI();
		} // end GetData

		#endregion
	}
}