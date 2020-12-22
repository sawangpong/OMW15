using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class ExchangeRate : Form
	{
		#region class field member

		private ActionMode _mode = ActionMode.None;

		#endregion

		public ExchangeRate()
		{
			InitializeComponent();
		}

		private void ExchangeRate_Load(object sender, EventArgs e)
		{
			CenterToParent();
			// setting mode
			_mode = ExchangeRecordId > 0 ? ActionMode.Edit : ActionMode.Add;

			// display currency
			grpCurrency.Text = $"Currency : [{Currency}]";

			// load data as of giving mode
			switch (_mode)
			{
				case ActionMode.Add:
					SetNewUI();
					break;
				case ActionMode.Edit:
					GetExchangeRateInfo(ExchangeRecordId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					AddNewExchangeRate();
					break;
				case ActionMode.Edit:
					UpdateExchangeRate(ExchangeRecordId);
					break;
			}
		}

		#region class property

		public int ExchangeRecordId { get; set; }

		public string Currency { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end updateUI

		private void SetNewUI()
		{
			txtExchangeRate.Text = "0.0000";
			dtpEffective.Value = DateTime.Today;
			dtpExpire.Value = DateTime.Today.AddDays(1);
		} // end SetNewUI

		private void GetExchangeRateInfo(int RecordId)
		{
			using (var _oldmoon = new OLDMOONEF1())
			{
				var exch = (from ex in _oldmoon.EXCHCURRs
								where ex.LINEID == RecordId
								select ex).Single();

				//							orderby ex.EFFECTIVEDT descending

				if (exch != null)
				{
					txtExchangeRate.Text = $"{exch.EXCHANGERATE:N4}";
					dtpEffective.Value = exch.EFFECTIVEDT.Num2Date();
					dtpExpire.Value = exch.EXPIREDT.Num2Date();
				}
			} // end 
		} // end GetExchangeRateInfo

		private void AddNewExchangeRate()
		{
			var exch = new EXCHCURR();
			exch.CURRENCY = Currency;
			exch.EFFECTIVEDT = dtpEffective.Value.Date2Num();
			exch.EXCHANGERATE = decimal.Parse(txtExchangeRate.Text);
			exch.EXPIREDT = dtpExpire.Value.Date2Num();
			exch.FISCPERIOD = dtpEffective.Value.Month;
			exch.FISCYEAR = dtpEffective.Value.Year;

			var _oldmoon = new OLDMOONEF1();
			try
			{
				_oldmoon.EXCHCURRs.Add(exch);
				_oldmoon.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Add new Exchange Rate record failed....", ex);
			}
		} // end AddNewExchangeRate

		private void UpdateExchangeRate(int Id)
		{
			var _oldmoon = new OLDMOONEF1();

			var exch = (from ex in _oldmoon.EXCHCURRs
							where ex.LINEID == Id
							select ex).Single();
			try
			{
				exch.EXCHANGERATE = decimal.Parse(txtExchangeRate.Text);
				exch.EFFECTIVEDT = dtpEffective.Value.Date2Num();
				exch.EXPIREDT = dtpExpire.Value.Date2Num();

				_oldmoon.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				//_scope.Dispose();
				throw new Exception("Update Exchange rate record failed...", ex);
			}
		} // end UpdateExchangeRate

		#endregion
	}
}