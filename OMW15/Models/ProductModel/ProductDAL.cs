using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ProductModel
{
	public class ProductDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public ProductDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region class method

		public string getProductCodeFromProductName(string productName)
		{
			return _om.PRODUCTS.Find(productName).id;
		}

		public DataTable GetProdcutModelList()
		{
			var _result = new DataTable();
			var _mcs = (from mc in _om.PRODUCTS
						orderby mc.type
						where mc.isdelete == false
						select new
						{
							ModelId = mc.id,
							Model = mc.type,
							ModelName = mc.products,
							ModelDisplay = mc.type + "-" + mc.products
						}).AsParallel();

			if (_mcs != null)
				_result = _mcs.ToDataTable();

			return _result;
		} // end GetProdcutModelList

		public DataTable getProductWithDetailList()
		{
			var _result = new DataTable();
			var _mcs = (from mc in _om.PRODUCTS
						join pg in _om.PRODUCTGROUPS on mc.productGroupID equals pg.PRODUCTGROUPID
						where mc.isdelete == false
						select new
						{
							ModelId = mc.id,
							ProductGroupId = mc.productGroupID,
							ProductGroup = pg.PRODUCTGROUPNAME,
							Model = mc.type,
							ModelName = mc.products,
							OldmoonProduct = mc.isOwnProduct == true ? "Y" : "N",
							Discontinue = mc.isOffProduction == true ? "Y" : "N",
							SpecialProduct = mc.isSpecialProduct == true ? "Y" : "N",
							TradingProduct = mc.isBuyForTread == true ? "Y" : "N"
						}).AsParallel();

			if (_mcs != null)
			{
				_result = _mcs.OrderBy(o => o.ProductGroup).ThenBy(o => o.Model).AsParallel().ToDataTable();
			}

			return _result;

		} // end getProductWithDetailList

		public int deleteProduct(string productId)
		{
			int result = 0;

			// find product in machine register was used
			bool isRegistered = _om.MIXes.Any(x => x.productid == productId);

			// registered machine record must be empty -> [isRegistered = false]
			// then, delete the record from database
			if (isRegistered == false)
			{
				using (var scope = new System.Transactions.TransactionScope())
				{
					try
					{
						_om.PRODUCTS.Remove(_om.PRODUCTS.Single(x => x.id == productId));
						result = _om.SaveChanges();
						scope.Complete();
					}
					catch (OptimisticConcurrencyException ex)
					{
						throw new Exception("The selected record can't delete......", ex);
					}
				}
			}

			return result;
		} // deleteProduct

		public DataTable GetMachineSNbyModel(string MachineModel)
		{
			var _result = new DataTable();
			var _sns = (from sn in _om.MIXes
						orderby sn.type, sn.s_no
						where sn.isdelete == false
							  && sn.type == MachineModel
						select new
						{
							SerialNo = sn.s_no
						}).AsParallel();

			if (_sns != null)
				_result = _sns.ToDataTable();

			return _result;
		} // end GetMachineSNbyModel

		public DataTable GetCustomerListByMachine(string MachineModel, string Serial)
		{
			var _result = new DataTable();
			try
			{
				var _custs = (from c in _om.MIXes
							  orderby c.sale_date, c.cus_na
							  where c.type == MachineModel
							  select new
							  {
								  Active = c.isexpire ? "N" : "Y",
								  Expire = c.exp.Value,
								  OwnerCode = c.acccustcode,
								  Owner = c.cus_na,
								  Model = c.type,
								  SerialNo = c.s_no,
								  saledate = c.sale_date.Value,
								  ChangeOwner = c.istransfer ? "Y" : "N",
								  transfer = c.transferdate.Value
							  }).AsParallel();

				if (!string.IsNullOrEmpty(Serial))
				{
					var _mcList = from mc in _custs
								  where mc.SerialNo == Serial
								  select mc;
					if (_mcList != null)
						_result = _mcList.ToDataTable();
				}
				else
				{
					if (_custs != null)
						_result = _custs.ToDataTable();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Get record error", ex);
			}

			return _result;

		} // end GetCustomerListByMachine

		public DataTable GetMachineListByCustomer(string CustomerCode)
		{
			var _result = new DataTable();

			var _mc = (from m in _om.MIXes
					   orderby m.sale_date.Value, m.type
					   where m.isdelete == false
							 && m.acccustcode == CustomerCode
					   select new
					   {
						   MIXID = m.mix_id,
						   MachineCondition = m.isnewproduct ? "New" : "Used",
						   Status = m.isexpire ? "Expire" : "Active",
						   Model = m.type,
						   SerialNo = m.s_no,
						   FirstOwner = m.istransfer ? "No" : "Yes",
						   CurrentOwner = m.cus_na,
						   SaleDate = m.sale_date.Value,
						   ExpireDate = m.exp.Value,
						   m.remark
					   }).AsParallel();

			if (_mc != null)
				_result = _mc.ToDataTable();

			return _result;
		} // end GetMachineListByCustomer

		public DataTable GetWarrantyTermList()
		{
			return _om.WARRANTIES.OrderBy(o => o.WARRANTYNAME).ToDataTable();
		} // end GetWarrantyTermList

		public string GetWarrantyName(int WarrantyId)
		{
			var _result = "";

			try
			{
				_result = _om.WARRANTIES.Single(x => x.WARRANTYID == WarrantyId).WARRANTYNAME;
			}
			catch
			{
			}

			return _result;
		} // end GetWarrantyName


		public string GetProductId(string ProductModel)
		{
			return _om.PRODUCTS.Single(x => x.type == ProductModel).id;
		} // end GetProductId

		public PRODUCT getProductInfo(string productId)
		{
			return _om.PRODUCTS.Single(x => x.id == productId);
		}


		public DataTable getProductGroups()
		{
			DataTable dt = new DataTable();
			var pg = _om.PRODUCTGROUPS.OrderBy(o => o.PRODUCTGROUPNAME).ToDataTable();

			if (pg != null)
				return pg;
			else
				return dt;
		}

		public int updateProductInfo(PRODUCT product)
		{
			int result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					if (product.id == null)
					{
						// get running product id
						product.id = getRunningProductId();
						_om.PRODUCTS.Add(product);
					}
					else
					{
						PRODUCT p = _om.PRODUCTS.Single(x => x.id == product.id);
						p.productGroupID = product.productGroupID;
						p.hasAfterSaleService = product.hasAfterSaleService;
						p.isBuyForTread = product.isBuyForTread;
						p.isOffProduction = product.isOffProduction;
						p.isOwnProduct = product.isOwnProduct;
						p.isSpecialProduct = product.isSpecialProduct;
						p.products = product.products;
						p.productpic = product.productpic;

					}
					result = _om.SaveChanges();
					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Update Product Info. has an error !!!!!", ex);
				}
			}

			return result;
		}

		private string getRunningProductId()
		{
			//throw new NotImplementedException();

			string maxid = _om.PRODUCTS.Max(x => x.id);

			return $"{ (int.Parse(maxid) + 1):000#}";

		} // end getRunningProductId

		public System.Drawing.Image getProductImage(string productId)
		{
			PRODUCT p = _om.PRODUCTS.Single(x => x.id == productId);

			if (p.productpic == null)
			{
				return null;
			}
			else
			{
				byte[] img = p.productpic;
				return img.ToImageFromByte();
			}

		} // end getProductImage


		public async Task<DataTable> GetSaleProductByYearAsync()
		{
			return await Task.Run(() =>
			{
				StringBuilder s = new StringBuilder();
				s.AppendLine("EXEC dbo.usp_OM_SALE_MACHINES");
				return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;
			});
		}


		//public async Task<DataTable> GetProductionSummaryForNormalTimeAsync(int y, int m, string connectionString)
		//{
		//	return await Task.Run(() =>
		//	{
		//		StringBuilder s = new StringBuilder();
		//		s.AppendLine($" EXEC dbo.usp_summary_production_hours {y},{m}");
		//		return new DataConnect(s.ToString(), connectionString).ToDataTable;
		//	});
		//}
		#endregion
	}
}