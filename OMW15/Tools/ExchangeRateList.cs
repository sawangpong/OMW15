using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Tools
{
	public partial class ExchangeRateList : Form
	{
		#region class field member
		private int _selectedCurrencyItemId = 0;
		private int _selectedFiscYear = DateTime.Today.Year;
		private string _selectedCurrency = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.tsbtnEdit.Enabled = (_selectedCurrencyItemId > 0);
		} // end UpdateUI

		private void GetYearExchange()
		{
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _exch = (from ex in _oldmoon.EXCHCURRs.AsParallel()
							 orderby ex.FISCYEAR ascending
							 select new
							 {
								 ex.FISCYEAR
							 }).Distinct().ToList();

				foreach (var item in _exch)
				{
					this.tscbxYearList.Items.Add(item.FISCYEAR.ToString());
				}
			} // end 

			this.tscbxYearList.SelectedIndex = this.tscbxYearList.Items.Count - 1;
			this.UpdateUI();

		} // end GetYearExchange

		private void GetTheCurrencyList(int FiscYear)
		{
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var _currencyList = (from cr in _oldmoon.EXCHCURRs.AsParallel()
									 orderby cr.FISCYEAR descending
									 where cr.FISCYEAR == FiscYear
									 select new
									 {
										 cr.CURRENCY
									 }).Distinct();

				this.lstCurrencyList.DataSource = _currencyList.ToList();
				this.lstCurrencyList.DisplayMember = "CURRENCY";
				this.lstCurrencyList.ValueMember = "CURRENCY";

				this.UpdateUI();
			} // end 

		} // end GetTheCurrencyList

		private void GetExchangeValueList(string Currency, int FiscYear)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = Tools.ToolController.ExchangeCurrencyController.GetCurrencyExchangeList(Currency, FiscYear);
			this.dgv.Columns["LINEID"].Visible = false;
			this.dgv.Columns["EFFECTIVE"].Visible = false;
			this.dgv.Columns["RATE"].HeaderText = "Exchange Rate";
			this.dgv.Columns["RATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dgv.Columns["RATE"].DefaultCellStyle.Format = "N4";
			this.dgv.Columns["DATEEFFECTIVE"].HeaderText = "Effective Date";
			this.dgv.Columns["DATEEXPIRE"].HeaderText = "Expire Date";
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.ResumeLayout();

			this.UpdateUI();

			// show average exchange rate by month
			this.GetMonthAvgExchangeRate(Currency, FiscYear);

			// show average exchange rate by year
			this.GetYearAvgExchangeRate(Currency, FiscYear);

		} // end GetExchangeValueList

		private void GetYearAvgExchangeRate(string Currency, int FiscYear)
		{
			this.grpAvgByYear.Text = string.Format("ค่าเฉลี่ยอัตราแลกเปลี่ยนประจำปี [{0}]", FiscYear);
			this.lbAVGRate.Text = string.Format("{0:N4}", Tools.ToolController.ExchangeCurrencyController.GetAvgExchangeRateByYear(Currency, FiscYear));

		} // end GetYearAvgExchangeRate

		private void GetMonthAvgExchangeRate(string Currency, int FiscYear)
		{
			this.grpAvgByMonth.Text = string.Format("ค่าเฉลี่ยอัตราแลกเปลี่ยนรายเดือน ประจำปี [{0}]", FiscYear);
			this.dgvAvgByMonth.SuspendLayout();
			this.dgvAvgByMonth.ColumnHeadersVisible = false;
			this.dgvAvgByMonth.DataSource = Tools.ToolController.ExchangeCurrencyController.GetAvgExchangeByMonth(Currency, FiscYear);
			this.dgvAvgByMonth.Columns["AVG"].DefaultCellStyle.Format = "N4";
			this.dgvAvgByMonth.Columns["AVG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			this.dgvAvgByMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			this.dgvAvgByMonth.ResumeLayout();

		} // end GetAvgExchangeRate

		private void ExchangeRateInfo(int Id)
		{
			Tools.ExchangeRate _exch = new ExchangeRate();
			_exch.Currency = _selectedCurrency;
			_exch.ExchangeRecordId = Id;
			_exch.StartPosition = FormStartPosition.CenterScreen;
			_exch.ShowDialog(this);

			// refresh UI
			this.tsbtnRefresh.PerformClick();
		}

		#endregion


		public ExchangeRateList()
		{
			InitializeComponent();
		}

		private void ExchangeRateList_Load(object sender, EventArgs e)
		{
			this.GetYearExchange();
			_selectedCurrencyItemId = 0;

			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			OMControls.OMUtils.SettingDataGridView(ref this.dgvAvgByMonth);
			this.dgvAvgByMonth.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tscbxYearList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedFiscYear = Convert.ToInt32(this.tscbxYearList.Text);
			}
			catch (Exception ex)
			{
				_selectedFiscYear = DateTime.Today.Year;
				throw new Exception("Binding Error !!!!", ex);
			}

			this.GetTheCurrencyList(_selectedFiscYear);
		}

		private void lstCurrencyList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedCurrency = this.lstCurrencyList.Text;
			}
			catch
			{
			}

			this.tsbtnRefresh.PerformClick();
		}

		private void lkAvgRateDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// code here
			this.GetMonthAvgExchangeRate(_selectedCurrency, _selectedFiscYear);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedCurrencyItemId = Convert.ToInt32(this.dgv["LINEID", e.RowIndex].Value);
			}
			catch
			{
				_selectedCurrencyItemId = 0;
			}
			this.UpdateUI();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.ExchangeRateInfo(_selectedCurrencyItemId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedCurrencyItemId = 0;
			this.ExchangeRateInfo(_selectedCurrencyItemId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetExchangeValueList(_selectedCurrency, _selectedFiscYear);

		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEdit.PerformClick();
		}
	}
}
