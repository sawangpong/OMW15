using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Products.ProductController
{
	public class ProductCore
	{
		#region static class method

		public static DataTable GetProdcutModelList()
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _mcs = (from mc in _srv.PRODUCTS
							orderby mc.type
							where mc.isdelete == false
							select new
							{
								Model = mc.type,
								ModelName = mc.products,
								ModelDisplay = mc.type + "-" + mc.products
							}).ToList();

				if (_mcs != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(_mcs);
				}
			}

			return _result;

		} // end GetProdcutModelList

		public static DataTable GetMachineSNbyModel(string MachineModel)
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				var _sns = (from sn in _srv.MIXes
							orderby sn.type, sn.s_no
							where sn.isdelete == false && sn.type == MachineModel
							select new
							{
								SerialNo = sn.s_no
							}).ToList();

				if (_sns != null)
				{
					_result = OMControls.OMDataUtils.ToDataTable(_sns);
				}
			}

			return _result;

		} // end GetMachineSNbyModel


		#endregion

		#region public class method

		public DataTable GetCustomerListByMachine(string MachineModel, string Serial)
		{
			DataTable _result = new DataTable();
			using (SERVICEEF _srv = new SERVICEEF())
			{
				try
				{
					var _custs = (from c in _srv.MIXes
								  orderby c.sale_date, c.cus_na
								  where c.type == MachineModel
								  select new
								  {
									  Active = c.isexpire == true ? "N" : "Y",
									  Expire = c.exp.Value,
									  OwnerCode = c.acccustcode,
									  Owner = c.cus_na,
									  Model = c.type,
									  SerialNo = c.s_no,
									  saledate = c.sale_date.Value,
									  ChangeOwner = (c.istransfer == true ? "Y" : "N"),
									  transfer = c.transferdate.Value
								  }).ToList();

					if (!string.IsNullOrEmpty(Serial))
					{
						var _mcList = (from mc in _custs
									   where mc.SerialNo == Serial
									   select mc).ToList();
						if (_mcList != null)
						{
							_result = OMControls.OMDataUtils.ToDataTable(_mcList);
						}
					}
					else
					{
						if (_custs != null)
						{
							_result = OMControls.OMDataUtils.ToDataTable(_custs);
						}
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Get record error", ex);
				}
			}

			return _result;

		} // end GetCustomerListByMachine

		#endregion

	}
}
