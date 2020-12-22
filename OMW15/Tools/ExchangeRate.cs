using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using OMControls;
using OMW15.Shared;

namespace OMW15.Tools
{
	public partial class ExchangeRate : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.None;

		#endregion

		#region class property

		public int ExchangeRecordId
		{
			get;
			set;
		}

		public string Currency
		{
			get;
			set;
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end updateUI

		private void SetNewUI()
		{
			this.txtExchangeRate.Text = "0.0000";
			this.dtpEffective.Value = DateTime.Today;
			this.dtpExpire.Value = DateTime.Today.AddDays(1);

		} // end SetNewUI

		private void GetExchangeRateInfo(int RecordId)
		{
			using (OLDMOONEF _oldmoon = new OLDMOONEF())
			{
				var exch = (from ex in _oldmoon.EXCHCURRs 
							orderby ex.EFFECTIVEDT descending
							where ex.LINEID == RecordId
							select ex).FirstOrDefault();

				if (exch != null)
				{
					this.txtExchangeRate.Text = string.Format("{0:N4}", exch.EXCHANGERATE);
					this.dtpEffective.Value = OMControls.OMUtils.Num2Date(exch.EFFECTIVEDT);
					this.dtpExpire.Value = OMControls.OMUtils.Num2Date(exch.EXPIREDT);
				}
			} // end 

		} // end GetExchangeRateInfo

		private void AddNewExchangeRate()
		{
			using (var _scope = new System.Transactions.TransactionScope())
			{
				EXCHCURR exch = new EXCHCURR();
				exch.CURRENCY = this.Currency;
				exch.EFFECTIVEDT = OMControls.OMUtils.Date2Num(this.dtpEffective.Value);
				exch.EXCHANGERATE = Convert.ToDecimal(this.txtExchangeRate.Text);
				exch.EXPIREDT = OMControls.OMUtils.Date2Num(this.dtpExpire.Value);
				exch.FISCPERIOD = this.dtpEffective.Value.Month;
				exch.FISCYEAR = this.dtpEffective.Value.Year;
				
				OLDMOONEF _oldmoon = new OLDMOONEF();
				try
				{
					_oldmoon.EXCHCURRs.Add(exch);
					_oldmoon.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					//_scope.Dispose();
					throw new Exception("Add new Exchange Rate record failed....", ex);
				}
			} // end

		} // end AddNewExchangeRate

		private void UpdateExchangeRate(int Id)
		{
			using (var _scope = new System.Transactions.TransactionScope())
			{
				OLDMOONEF _oldmoon = new OLDMOONEF();

				var exch = (from ex in _oldmoon.EXCHCURRs
							where ex.LINEID == Id
							select ex).FirstOrDefault();

				try
				{
					exch.EXCHANGERATE = Convert.ToDecimal(this.txtExchangeRate.Text);
					exch.EFFECTIVEDT = OMControls.OMUtils.Date2Num(this.dtpEffective.Value);
					exch.EXPIREDT = OMControls.OMUtils.Date2Num(this.dtpExpire.Value);

					_oldmoon.SaveChanges();
					_scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					//_scope.Dispose();
					throw new Exception("Update Exchange rate record failed...", ex);
				}

			} // end

		} // end UpdateExchangeRate

		#endregion


		public ExchangeRate()
		{
			InitializeComponent();
		}

		private void ExchangeRate_Load(object sender, EventArgs e)
		{
			// setting mode
			_mode = (this.ExchangeRecordId > 0 ? ActionMode.Edit : ActionMode.Add);

			// display currency
			this.grpCurrency.Text = string.Format("Currency : [{0}]", this.Currency);

			// load data as of giving mode
			switch (_mode)
			{
				case ActionMode.Add:
					this.SetNewUI();
					break;
				case ActionMode.Edit:
					this.GetExchangeRateInfo(this.ExchangeRecordId);
					break;
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			switch (_mode)
			{
				case ActionMode.Add:
					this.AddNewExchangeRate();
					break;
				case ActionMode.Edit:
					this.UpdateExchangeRate(this.ExchangeRecordId);
					break;
			}
		}
	}
}
