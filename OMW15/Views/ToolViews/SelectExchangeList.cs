using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;

namespace OMW15.Views.ToolViews
{
	public partial class SelectExchangeList : Form
	{
		public SelectExchangeList(string Currency, int FiscYear, int FiscPeriod)
		{
			InitializeComponent();

			this.Currency = Currency;
			this.FiscYear = FiscYear;
			this.FiscPeriod = FiscPeriod;
		}

		private void SelectExchangeList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetExchangeList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			ExchangeRate = Convert.ToDecimal(dgv["EXCHANGERATE", e.RowIndex].Value);
			ExchangeDate = Convert.ToDateTime(dgv["EFFECTDATE", e.RowIndex].Value);
		}

		#region class field member

		#endregion

		#region class property

		public string Currency { get; set; }

		public int FiscYear { get; set; }

		public int FiscPeriod { get; set; }

		public DateTime ExchangeDate { get; set; }

		public decimal ExchangeRate { get; set; }

		#endregion

		#region class methods

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetExchangeList()
		{
			dgv.DataSource = new MaterialDAL().GetExchangeRateList(Currency, FiscYear, FiscPeriod);

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			UpdateUI();
		} // end GetExchangeList

		#endregion
	}
}