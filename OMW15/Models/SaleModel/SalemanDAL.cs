using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Transactions;
using OMControls;

namespace OMW15.Models.SaleModel
{
	public class SalemanDAL
	{
		#region class field member

		private readonly OLDMOONEF1 _om;

		#endregion

		#region constructor

		public SalemanDAL()
		{
			_om = new OLDMOONEF1();
		} // end 

		#endregion

		#region class property

		#endregion

		#region class methods

		public DataTable GetSalePersonList()
		{
			var _result = new DataTable();

			var c = (from sl in _om.SALE_PERSON_PROFILE
				orderby sl.SALE_PERSON
				select new
				{
					sl.SALEID,
					SaleMan = sl.SALE_PERSON,
					SaleContactNo = sl.MOBILE,
					Email = sl.EMAIL1
				}).Distinct();

			if (c != null)
				_result = c.ToDataTable();

			return _result;
		} // end GetSalePersonList


		public SALE_PERSON_PROFILE GetSalePersonInfo(int Id)
		{
			return _om.SALE_PERSON_PROFILE.Single(x => x.SALEID == Id);
		}

		public int UpdateSaleMan(SALE_PERSON_PROFILE Saleman)
		{
			var _result = 0;

			using (var scope = new TransactionScope())
			{
				try
				{
					if (Saleman.SALEID == 0)
					{
						_om.SALE_PERSON_PROFILE.Add(Saleman);
						_result = _om.SaveChanges();
					}
					else
					{
						var _sale = _om.SALE_PERSON_PROFILE.FirstOrDefault(x => x.SALEID == Saleman.SALEID);
						_sale.SALE_PERSON = Saleman.SALE_PERSON;
						_sale.ISACTIVE = Saleman.ISACTIVE;
						_sale.EMAIL1 = Saleman.EMAIL1;
						_sale.EMAIL2 = Saleman.EMAIL2;
						_sale.MOBILE = Saleman.MOBILE;

						_result = _om.SaveChanges();
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Sale Person failed......", ex);
				}
			}

			return _result;
		} // end UpdateSaleMan

		#endregion
	}
}