using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Tools
{
	public partial class SelectExchangeList : Form
	{
		#region class field member
		
		#endregion

		#region class property
		public string Currency
		{
			get;
			set;
		}

		public int FiscYear
		{
			get;
			set;
		}

		public int FiscPeriod
		{
			get;
			set;
		}

		public DateTime ExchangeDate
		{
			get;
			set;
		}

		public decimal  ExchangeRate
		{
			get;
			set;
		}


		#endregion

		#region class methods

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetExchangeList()
		{
			this.dgv.DataSource = new OMW15.Casting.CastingController.MaterialDAL().GetExchangeRateList(this.Currency, this.FiscYear, this.FiscPeriod);

			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			this.UpdateUI();

		} // end GetExchangeList


		#endregion


		public SelectExchangeList(string Currency,int FiscYear, int FiscPeriod)
		{
			InitializeComponent();

			this.Currency = Currency;
			this.FiscYear = FiscYear;
			this.FiscPeriod = FiscPeriod;
		}

		private void SelectExchangeList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.GetExchangeList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			this.ExchangeRate = Convert.ToDecimal(this.dgv["EXCHANGERATE", e.RowIndex].Value);
			this.ExchangeDate = Convert.ToDateTime(this.dgv["EFFECTDATE", e.RowIndex].Value);
		}
	}
}
