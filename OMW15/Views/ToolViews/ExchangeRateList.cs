using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ToolModel;

namespace OMW15.Views.ToolViews
{
	public partial class ExchangeRateList : Form
	{
		#region Singleton

		public static ExchangeRateList _instance;
		public static ExchangeRateList GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new ExchangeRateList();
				return _instance;
			}
		}
		#endregion

		public ExchangeRateList()
		{
			InitializeComponent();
		}

		private void ExchangeRateList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			GetYearExchange();
			_selectedCurrencyItemId = 0;

			OMUtils.SettingDataGridView(ref dgvCurr);
			dgvCurr.ColumnHeadersVisible = false;

			OMUtils.SettingDataGridView(ref dgv);
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			OMUtils.SettingDataGridView(ref dgvAvgByMonth);
			dgvAvgByMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxYearList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedFiscYear = int.Parse(tscbxYearList.Text);
			}
			catch (Exception ex)
			{
				_selectedFiscYear = DateTime.Today.Year;
				throw new Exception("Binding Error !!!!", ex);
			}

			GetTheCurrencyList(_selectedFiscYear);
		}

		//private void lstCurrencyList_SelectedIndexChanged(object sender, EventArgs e) {
		//	try {
		//		_selectedCurrency = lstCurrencyList.SelectedValue.ToString();
		//	}
		//	catch {
		//		_selectedCurrency = "USD";
		//	}

		//	tsbtnRefresh.PerformClick();
		//}

		private void lkAvgRateDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// code here
			GetMonthAvgExchangeRate(_selectedCurrency, _selectedFiscYear);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedCurrencyItemId = Convert.ToInt32(dgv["LINEID", e.RowIndex].Value);
			}
			catch
			{
				_selectedCurrencyItemId = 0;
			}
			UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			ExchangeRateInfo(_selectedCurrencyItemId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedCurrencyItemId = 0;
			ExchangeRateInfo(_selectedCurrencyItemId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetExchangeValueList(_selectedCurrency, _selectedFiscYear);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void dgvCurr_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedCurrency = dgvCurr["CURRENCY", e.RowIndex].Value.ToString();
			}
			catch
			{
				_selectedCurrency = "USD";
			}

			tsbtnRefresh.PerformClick();
		}

		#region class field member

		private int _selectedCurrencyItemId;
		private int _selectedFiscYear = DateTime.Today.Year;
		private string _selectedCurrency = "USD";

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedCurrencyItemId > 0;
		} // end UpdateUI

		private void GetYearExchange()
		{
			tscbxYearList.ComboBox.DataSource = new ExchangeCurrencyDAL().GetExchangeYearList();
			tscbxYearList.ComboBox.DisplayMember = "FISCYEAR";
			tscbxYearList.ComboBox.ValueMember = "FISCYEAR";
			tscbxYearList.ComboBox.SelectedIndex = 0;
			UpdateUI();
		} // end GetYearExchange

		private void GetTheCurrencyList(int FiscYear)
		{
			var dt = new ExchangeCurrencyDAL().GetCurrencyListByYear(FiscYear);

			//lstCurrencyList.DataSource = dt;
			//lstCurrencyList.DisplayMember = "CURRENCY";
			//lstCurrencyList.ValueMember = "CURRENCY";

			//dgvCurr.SuspendLayout();
			dgvCurr.DataSource = dt;
			dgvCurr.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			//dgvCurr.ResumeLayout();

			UpdateUI();
		} // end GetTheCurrencyList

		private void GetExchangeValueList(string Currency, int FiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ExchangeCurrencyDAL().GetCurrencyExchangeList(Currency, FiscYear);
			dgv.Columns["LINEID"].Visible = false;
			dgv.Columns["EFFECTIVE"].Visible = false;
			dgv.Columns["RATE"].HeaderText = "Exchange Rate";
			dgv.Columns["RATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["RATE"].DefaultCellStyle.Format = "N4";
			dgv.Columns["DATEEFFECTIVE"].HeaderText = "Effective Date";
			dgv.Columns["DATEEXPIRE"].HeaderText = "Expire Date";
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();

			// show average exchange rate by month
			GetMonthAvgExchangeRate(Currency, FiscYear);

			// show average exchange rate by year
			GetYearAvgExchangeRate(Currency, FiscYear);
		} // end GetExchangeValueList

		private void GetYearAvgExchangeRate(string Currency, int FiscYear)
		{
			grpAvgByYear.Text = $"ค่าเฉลี่ยอัตราแลกเปลี่ยนประจำปี [{FiscYear}]";
			lbAVGRate.Text = $"{new ExchangeCurrencyDAL().GetAvgExchangeRateByYear(Currency, FiscYear):N4}";
		} // end GetYearAvgExchangeRate

		private void GetMonthAvgExchangeRate(string Currency, int FiscYear)
		{
			grpAvgByMonth.Text = $"ค่าเฉลี่ยอัตราแลกเปลี่ยนรายเดือน ประจำปี [{FiscYear}]";
			dgvAvgByMonth.SuspendLayout();
			dgvAvgByMonth.ColumnHeadersVisible = false;
			dgvAvgByMonth.DataSource = new ExchangeCurrencyDAL().GetAvgExchangeByMonth(Currency, FiscYear);
			dgvAvgByMonth.Columns["AVG"].DefaultCellStyle.Format = "N4";
			dgvAvgByMonth.Columns["AVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgvAvgByMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvAvgByMonth.ResumeLayout();
		} // end GetAvgExchangeRate

		private void ExchangeRateInfo(int Id)
		{
			var _exch = new ExchangeRate();
			_exch.Currency = _selectedCurrency;
			_exch.ExchangeRecordId = Id;
			_exch.StartPosition = FormStartPosition.CenterParent;
			_exch.ShowDialog(this);

			// refresh UI
			tsbtnRefresh.PerformClick();
		}

		#endregion
	}
}