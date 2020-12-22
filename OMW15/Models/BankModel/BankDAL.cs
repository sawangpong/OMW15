using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;

namespace OMW15.Models.BankModel
{
	public class BankDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public BankDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region class method

		public DataTable GetBankList()
		{
			var _result = new DataTable();

			var _blst = (from b in _om.BANKS
						 orderby b.BANKNAME
						 select new
						 {
							 b.INACTIVE,
							 b.BANKID,
							 Code = b.BANKCODE,
							 b.BANKNAME,
							 Branch = b.ACCOUNTBRANCH,
							 ACType = b.ACCOUNTTYPE,
							 b.ACCOUNTNAME,
							 b.ACCOUNTNO,
							 Swift = b.SWIFTCODE
						 }).AsNoTracking().AsParallel();

			if (_blst != null)
				_result = _blst.ToDataTable();

			return _result;
		} // end GetBankList

		public BANK GetBankInfo(int BankId)
		{
			return _om.BANKS.Single(x => x.BANKID == BankId);

		} // end GetBankInfo


		public DataTable GetBankAccountTypeList()
		{
			var _result = new DataTable();
			var _act = (from b in _om.BANKS
						where b.ACCOUNTTYPE != null
						select new
						{
							b.ACCOUNTTYPE
						}).AsNoTracking().Distinct().OrderBy(x => x.ACCOUNTTYPE);

			if (_act != null)
				_result = _act.ToDataTable();

			return _result;

		} // end GetBankAccountTypeList


		public int UpdateBankInfo(BANK BankInfo)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					if (BankInfo.BANKID == 0)
					{
						_om.BANKS.Add(BankInfo);
						_result = _om.SaveChanges();
					}
					else
					{
						var _b = _om.BANKS.FirstOrDefault(x => x.BANKID == BankInfo.BANKID);
						_b.ACCOUNTBRANCH = BankInfo.ACCOUNTBRANCH;
						_b.ACCOUNTNAME = BankInfo.ACCOUNTNAME;
						_b.ACCOUNTNO = BankInfo.ACCOUNTNO;
						_b.ACCOUNTTYPE = BankInfo.ACCOUNTTYPE;
						_b.BANKNAME = BankInfo.BANKNAME;
						_b.BANKTHNAME = BankInfo.BANKTHNAME;
						_b.INACTIVE = BankInfo.INACTIVE;
						_b.SWIFTCODE = BankInfo.SWIFTCODE;

						_result = _om.SaveChanges();
					}
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't update Bank Info....", ex);
				}
			}

			return _result;

		} // end UpdateBankInfo

		#endregion
	}
}