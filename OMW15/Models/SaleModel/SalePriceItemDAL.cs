using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using OMControls;
using OMW15;

namespace OMW15.Models.SaleModel
{
	public class SalePriceItemDAL
	{
		private readonly OLDMOONEF1 _om;


		// CONSTRUCTOR
		public SalePriceItemDAL()
		{
			_om = new OLDMOONEF1();				
		}

		#region class helper

		public async Task<DataTable> GetPriceListItems()
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var pl = (from ipl in _om.ITEMSPRICELISTs.AsEnumerable()
					orderby ipl.ITEMID
					select new
					{
						ipl.SPID,
						ipl.ISACTIVE,
						Status = ipl.ISACTIVE==true ? (ipl.EXPIRE.Num2Date() < DateTime.Today ? "Expire" : "Active")  : "NOT USED",
						ipl.EFFECTIVE,
						ipl.ITEMID,
						ipl.ITEMNAME,
						ipl.UNIT,
						ipl.THB_UNITCOST,
						ipl.THB_UNITPRICE,
						ipl.USD_UNITPRICE,
						ipl.FOR_MACHINE
					}).AsParallel();

				if (pl != null)
					_result = pl.ToDataTable();

				return _result;
			});

		} // end GetPriceListItems

		public ITEMSPRICELIST GetPriceListItem(string ItemId)
		{
			return _om.ITEMSPRICELISTs.Single(o => o.ITEMID == ItemId);

		} // end GetPriceListItem

		public int UpdatePriceListItem(ITEMSPRICELIST item)
		{
			var result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					if (item.SPID == 0) // add mode
					{
						_om.ITEMSPRICELISTs.Add(item);
					}
					else // edit mode
					{
						var itm = _om.ITEMSPRICELISTs.FirstOrDefault(o => o.SPID == item.SPID);
						itm.FOR_MACHINE = item.FOR_MACHINE;
						itm.ITEMNAME = item.ITEMNAME;
						itm.UNIT = item.UNIT;
						itm.THB_UNITCOST = item.THB_UNITCOST;
						itm.THB_UNITPRICE = item.THB_UNITPRICE;
						itm.SOURCE_FACTOR = item.SOURCE_FACTOR;
						itm.USD_UNITPRICE = item.USD_UNITPRICE;
						itm.ISACTIVE = item.ISACTIVE;
						itm.LASTUPDATE = item.LASTUPDATE;
						itm.MODIUSER = item.MODIUSER;
					}

					result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Error update data", ex);
				}
			}


			return result;
		} // end UpdatePriceListItem

		#endregion
	}
}