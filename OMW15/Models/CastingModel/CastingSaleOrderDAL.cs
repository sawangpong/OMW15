using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.ToolModel;
using OMW15.Shared;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Models.CastingModel
{
	public class CastingSaleOrderDAL
	{
		#region class constructor

		private readonly OLDMOONEF1 _om;

		public CastingSaleOrderDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region SO_FOR_BILLING

		public async Task<DataTable> GetAvailableSOForBillingAsync(string CustomerCode, int SaleType,
			bool OnlyForLabourCharge = true)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _so = (from so in _om.SALEORDERS.AsEnumerable()
							join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							join m in _om.SYSDATAs on so.DELIVERMAT.ToString() equals m.KEYVALUE
							where so.ISCOMPLETE == false
								 && so.ISDELETE == false
								 && so.ISCANCEL == false
								 && so.BILLSEQ == 0
								 && so.CUSTCODE == CustomerCode
								 && m.GROUPTITLE == "MATERIAL"
							select new
							{
								so.SOSEQ,
								so.BILLSEQ,
								so.SALETYPE,
								so.SONO,
								ORDERDATE = so.SODATE.Num2Date(),
								so.TOTALVALUE,
								so.DISCOUNT,
								so.NETVALUE,
								TOTALVAT = so.VATVALUE,
								so.TOTALAMOUNT
							}).OrderBy(x => x.SONO).AsParallel();

				if (OnlyForLabourCharge)
					_result = _so.Where(x => x.SALETYPE != SaleType).AsParallel().ToDataTable();
				else
					_result = _so.Where(x => x.SALETYPE == SaleType).AsParallel().ToDataTable();

				return _result;
			});
		} // end GetAsyncAvailableSOForBilling

		#endregion

		#region class helper methods

		public DataTable CalVATMethods()
		{
			var _result = new DataTable();
			_result.Columns.Add(new DataColumn("METHOD_ID", typeof(int)));
			_result.Columns.Add(new DataColumn("METHOD_NAME", typeof(string)));

			// add data
			var _dr = _result.NewRow();
			_dr["METHOD_ID"] = 0;
			_dr["METHOD_NAME"] = "0 - ไม่คิด VAT";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["METHOD_ID"] = 1;
			_dr["METHOD_NAME"] = "1 - แยก VAT";
			_result.Rows.Add(_dr);

			_dr = _result.NewRow();
			_dr["METHOD_ID"] = 2;
			_dr["METHOD_NAME"] = "2 - รวม VAT";
			_result.Rows.Add(_dr);

			return _result;

		} // end CalVATMethods

		public bool FindJobItemWasIssueToSaleOrderItem(int JobNo)
		{
			return _om.SOLINES.Where(x => x.JOBNO == JobNo).Count() > 0 ? true : false;
		} // end FindJobItemWasIssueToSaleOrderItem

		public bool GetAvailableReferenceSOKey1(int RefKey)
		{
			return _om.SOLINES.Where(x => x.REFSOKEY == RefKey).Distinct().Count() > 0 ? false : true;
		} // end GetAvailableReferenceSOKey1

		public CUSTOMER GetAvailableCustomerInfoForCastingSaleOrder(string CustomerCode)
		{
			return _om.CUSTOMERS.Single(x => x.CUSTCODE == CustomerCode);
		} // end GetAvailableCustomerInfoForCastingSaleOrder

		public string GetLatestCastingOrderNumber(DateTime SODate, bool IsVAT, OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _codeFormat = IsVAT ? SODate.GetThaiCodeFormat() : SODate.GetGeneralCodeFormat();
			var _result = string.Empty;

			try
			{
				var ln = _om.SALEORDERS.Where(x => x.FISCYEAR == SODate.Year
						&& x.FISCPERIOD == SODate.Month
						&& x.ISVAT == IsVAT
						&& x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
						&& x.SONO.Substring(2, 4) == _codeFormat)
						.Select(s => new
						{
							s.RUNNINGNO,
							s.SONO
						});

				if (ln.ToList().Count > 0)
				{
					if (IsVAT == true)
					{
						_result = ln.Single(f => f.RUNNINGNO == (ln.Max(x => x.RUNNINGNO))).SONO;
					}
					else
					{
						_result = "";
					}
				}
			}
			catch
			{
				_result = "";
			}

			return _result;
		} // end GetLatestCastingOrderNumber

		public int GetLastRunningCastingSaleOrder(DateTime SODate, bool IsVAT, OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _result = 0;
			var _codeFormat = IsVAT ? SODate.GetThaiCodeFormat() : SODate.GetGeneralCodeFormat();

			try
			{
				var ln = _om.SALEORDERS.Where(x => x.FISCYEAR == SODate.Year && x.FISCPERIOD == SODate.Month && x.ISVAT == IsVAT && x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial && x.SONO.Substring(2, 4) == _codeFormat).Max(x => x.RUNNINGNO);

				if (ln != 0)
				{
					_result = int.Parse(ln.ToString());
				}
				else
				{
					_result = 0;
				}
			}
			catch
			{
				_result = 0;
			}
			return _result;

		} // end GetLastRunningCastingSaleOrder

		public int GetLastRunningSaleMaterialOrder(string MasterOrderNo, DateTime SODate, bool IsVAT,
			OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _result = 0;
			var sn = from s in _om.SALEORDERS
					 where s.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
							&& s.SONO.StartsWith(MasterOrderNo)
					 select new
					 {
						 s.RUNNINGNO,
						 s.SONO
					 };

			if (sn.ToList().Count > 0)
				_result = sn.Max(x => x.RUNNINGNO);
			else
				_result = 0;

			return _result;
		} // end GetLastRunningSaleMaterialOrder

		public string GetLatestSaleMaterialOrder(string MasterOrderNumber, DateTime SODate, bool IsVAT,
			OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _result = string.Empty;
			var sn = from s in _om.SALEORDERS
					 where s.FISCYEAR == SODate.Year
							&& s.FISCPERIOD == SODate.Month
							&& s.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
							&& s.SONO.StartsWith(MasterOrderNumber)
					 select new
					 {
						 s.RUNNINGNO,
						 s.SONO
					 };

			if (sn.Count() > 0)
			{
				var _max = sn.Max(x => x.RUNNINGNO);
				var _lastNumber = sn.First(x => x.RUNNINGNO == _max);
				_result = _lastNumber.SONO;
			}
			else
			{
				_result = string.Empty;
			}

			return _result;
		} // end GetLatestCastingOrderNumber

		public int GetMissingMaterialIdForSaleMaterialOrder(string SaleOrderNumber)
		{
			return _om.SALEORDERS.Single(x => x.SONO == SaleOrderNumber).DELIVERMAT;
		} // end GetMissingMaterialIdForSaleMaterialOrder

		public DataTable GetAvailableMaterialForCastingOrderByCustomer(string CustomerCode)
		{
			var _result = new DataTable();
			var mats = (from m in _om.JOBORDERS
						join sysmat in _om.SYSDATAs on m.MATERIALTYPE.ToString() equals sysmat.KEYVALUE
						where m.CUSTCODE == CustomerCode
							  && sysmat.GROUPTITLE == "MATERIAL"
						select new
						{
							MatId = m.MATERIALTYPE,
							MatName = sysmat.THKEYNAME
						}).Distinct().OrderBy(o => o.MatName).AsParallel();
			if (mats != null)
				_result = mats.ToDataTable();

			return _result;
		} // end GetAvailableMaterialForCastingOrderByCustomer

		public async Task<DataTable> GetAvailableCustomerForMaterialBalanceAsync(string FilterText = "")
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var custs = (from so in _om.SALEORDERS
							 join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							 orderby c.CUSTNAME
							 where so.ISCANCEL == false
									&& so.ISDELETE == false
							 select new
							 {
								 so.CUSTID,
								 so.CUSTCODE,
								 c.CUSTNAME
							 }).Distinct().AsParallel();

				if (custs != null)
					if (string.IsNullOrEmpty(FilterText))
						_result = custs.ToDataTable();
					else
						_result = custs.Where(x => x.CUSTNAME.Contains(FilterText)).ToDataTable();

				return _result;
			});
		} // end GetAvailableCustomerForMaterialBalance

		public async Task<DataTable> GetAvailableCustomerForCastingOrderAsync(string FilterText = "")
		{
				return await Task.Run(() =>
			{
				var _result = new DataTable();
				var custs = (from jc in _om.JOBORDERS
							 join c in _om.CUSTOMERS on jc.CUSTCODE equals c.CUSTCODE
							 orderby c.CUSTNAME
							 where jc.ISCANCEL == false
									&& c.CUSTID > 0
							 select new
							 {
								 c.CUSTID,
								 jc.CUSTCODE,
								 c.CUSTNAME
							 }).Distinct().AsParallel();

					 if (custs != null)
					 {
						  if (string.IsNullOrEmpty(FilterText))
						  {
								_result = custs.ToDataTable();
						  }
						  else
						  {
								_result = custs.Where(x => x.CUSTNAME.Contains(FilterText)).ToDataTable();
						  }
					 }
					 return _result;
				});
		} // end GetAvailableCustomerForCastingOrders

		public async Task<DataTable> GetCastingSaleOrderListAsync(string connectionString,
									OMShareCastingEnums.CastingOrderStatus status,
									string customerCode,
									bool onlyAvailableCastingOrderForSellingMaterial = false,
									OMShareCastingEnums.CastingOrderCallType callType = OMShareCastingEnums.CastingOrderCallType.None,
									bool showNonVATOnly = false
									)
		{
			return await Task.Run(() =>
			{
				int _status = (int)status;
				int _saleMat = onlyAvailableCastingOrderForSellingMaterial ? 1 : 0;
				int _vatOnly = showNonVATOnly ? 0 : 1;
				int _callType = (int)callType;

				StringBuilder s = new StringBuilder();
				s.AppendLine($" EXEC dbo.usp_OM_CASTING_SALEORDER ");
				s.AppendLine($" @Status = {_status},");
				s.AppendLine($" @CustCode = '{customerCode}',");
				s.AppendLine($" @AvailableOrderForSaleMaterial = {_saleMat},");
				s.AppendLine($" @CallType = {_callType},");
				s.AppendLine($" @VATOnly = {_vatOnly}");

				return new DataConnect(s.ToString(), connectionString).ToDataTable;
			});

		} // end 


		public async Task<DataTable> GetCastingSaleOrderListAsync(OMShareCastingEnums.CastingOrderStatus Status,
									string CustomerCode,
									bool OnlyAvailableCastingOrderForSellingMaterial = false,
									OMShareCastingEnums.CastingOrderCallType CallType = OMShareCastingEnums.CastingOrderCallType.None)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _sor = (from so in _om.SALEORDERS.AsEnumerable()
							join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							join m in _om.SYSDATAs on so.DELIVERMAT.ToString() equals m.KEYVALUE
							where so.ISDELETE == false
								  && so.ISCANCEL == false
								  && m.GROUPTITLE == "MATERIAL"
							select new
							{
								Pnt = so.ISPRINTED == false ? "N" : "Y",
								so.ISVAT,
								so.CUSTID,
								so.SOSEQ,
								so.SALEMATID,
								so.BILLSEQ,
								Status =
								so.BILLSEQ == 0
									? (int)OMShareCastingEnums.CastingOrderStatus.Active
									: (int)OMShareCastingEnums.CastingOrderStatus.Closed,
								StatusName =
								so.BILLSEQ == 0
									? OMShareCastingEnums.CastingOrderStatus.Active.ToString()
									: OMShareCastingEnums.CastingOrderStatus.Closed.ToString(),
								so.SONO,
								so.SALETYPE,
								TYPE = so.SALETYPE == (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ ? "MATERIAL" : "CASTING",
								so.CUSTCODE,
								CUSTOMER = c.CUSTNAME,
								ORDERDATE = so.SODATE.Num2Date(),
								ORDERDUE = so.DUEDATE.Num2Date(),
								so.TOTALVALUE,
								so.DISCOUNT,
								NETORDERVALUE = so.NETVALUE,
								so.VATVALUE,
								so.TOTALAMOUNT,
								so.DELIVERMAT,
								m.THKEYNAME,
								so.DELIVERWEIGHT,
								RemainWeight = so.OUTSTANDWEIGHT
							}).AsParallel();

				var _so = (omglobal.NONVAT_DISPLAY ? _sor : _sor.Where(v => v.ISVAT == true).AsParallel());

				if (CallType == OMShareCastingEnums.CastingOrderCallType.AvailableOrderForSell)
				{
					var _grv = _om.MATRECEIVEs.Select(x => x.CUSTDOCNO).ToArray();
					_so.Where(x => !_grv.Contains(x.SONO)).AsParallel();
				}

				if (_so != null)
					if (string.IsNullOrEmpty(CustomerCode)) // ALL CUSTOMERS
					{
						switch (Status)
						{
							case OMShareCastingEnums.CastingOrderStatus.All:
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _so.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _so.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();

								break;

							case OMShareCastingEnums.CastingOrderStatus.Active:
								var _orderActive = _so.Where(active => active.Status == (int)OMShareCastingEnums.CastingOrderStatus.Active);
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _orderActive.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _orderActive.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();

								break;

							case OMShareCastingEnums.CastingOrderStatus.Closed:
								var _orderClosed = _so.Where(closed => closed.Status == (int)OMShareCastingEnums.CastingOrderStatus.Closed);
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _orderClosed.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _orderClosed.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();

								break;
						}
					}
					else // specify CUSTOMER ID
					{
						var _s = _so.ToList().Where(x => x.CUSTCODE == CustomerCode).AsParallel();
						switch (Status)
						{
							case OMShareCastingEnums.CastingOrderStatus.All:
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _s.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _s.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();

								break;

							case OMShareCastingEnums.CastingOrderStatus.Active:
								var _sa = _s.Where(x => x.Status == (int)OMShareCastingEnums.CastingOrderStatus.Active);
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _sa.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _sa.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();
								break;

							case OMShareCastingEnums.CastingOrderStatus.Closed:
								var _sc = _s.Where(x => x.Status == (int)OMShareCastingEnums.CastingOrderStatus.Closed);
								_result = OnlyAvailableCastingOrderForSellingMaterial == false
									? _sc.OrderByDescending(x => x.SONO).AsParallel().ToDataTable()
									: _sc.Where(x => x.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
										.OrderByDescending(x => x.SONO)
										.AsParallel()
										.ToDataTable();
								break;
						}
					}
				return _result;
			});
		} // end GetCastingSaleOrderList

		public DataTable GetCastingSaleOrderListForClearing(string CustomerCode, string MaterialCategory)
		{
			var _result = new DataTable();
			var _so = (from so in _om.SALEORDERS.AsEnumerable()
						join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
						join m in _om.SYSDATAs on so.DELIVERMAT.ToString() equals m.KEYVALUE
						orderby so.SODATE, so.MATDOCNO
						where so.ISCOMPLETE == false
							 && so.ISDELETE == false
							 && so.ISCANCEL == false
							 && so.CUSTCODE == CustomerCode
							 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
							 && so.OUTSTANDWEIGHT > 0.00m
							 && m.GROUPTITLE == "MATERIAL"
							 && m.CATEGORY == MaterialCategory
						select new
						{
							so.SOSEQ,
							so.CUSTID,
							so.CUSTCODE,
							SCNumber = so.SONO,
							IssueNo = so.MATDOCNO,
							IssueDate = so.SODATE.Num2Date(),
							MatId = so.DELIVERMAT,
							Material = m.THKEYNAME,
							IssueQty = so.DELIVERWEIGHT,
							Remain = so.OUTSTANDWEIGHT,
							Clearing = 0.00m,
							Balance = 0.00m
						}).AsParallel();

			if (_so != null)
				_result = _so.ToDataTable();

			return _result;
		} // end GetCastingSaleOrderListForClearing

		public async Task<DataTable> GetAsyncCastingSaleOrderListForClearing(string CustomerCode, string MaterialCategory)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _so = (from so in _om.SALEORDERS.AsEnumerable()
							join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							join m in _om.SYSDATAs on so.DELIVERMAT.ToString() equals m.KEYVALUE
							orderby so.SODATE, so.MATDOCNO
							where so.ISDELETE == false
								 && so.ISCANCEL == false
								 && so.CUSTCODE == CustomerCode
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
								 && so.OUTSTANDWEIGHT > 0.00m
								 && m.GROUPTITLE == "MATERIAL"
								 && m.CATEGORY == MaterialCategory
							select new
							{
								so.SOSEQ,
								so.CUSTID,
								so.CUSTCODE,
								SCNumber = so.SONO,
								IssueNo = so.MATDOCNO,
								IssueDate = so.SODATE.Num2Date(),
								MatId = so.DELIVERMAT,
								Material = m.THKEYNAME,
								IssueQty = so.DELIVERWEIGHT,
								Remain = so.OUTSTANDWEIGHT,
								Clearing = 0.00m,
								Balance = 0.00m
							}).AsParallel();

				if (_so != null)
					_result = _so.ToDataTable();

				return _result;
			});
		} // end GetAsyncCastingSaleOrderListForClearing

		public async Task<DataTable> GetAsyncCastingSaleOrderListForClearing(string CustomerCode, string MaterialCategory,
			string SaleOrderNumber)
		{
			var _masterSaleOrder = string.Empty;
			try
			{
				_masterSaleOrder = SaleOrderNumber.Substring(0, SaleOrderNumber.IndexOf("-"));
			}
			catch
			{
				_masterSaleOrder = SaleOrderNumber;
			}

			var _dt = await GetAsyncCastingSaleOrderListForClearing(CustomerCode, MaterialCategory);
			var _dv = _dt.DefaultView;
			_dv.RowFilter = $"[SCNumber] = '{_masterSaleOrder}'";

			return _dv.ToTable();
		} // end GetAsyncCastingSaleOrderListForClearing

		public SALEORDER GetSaleCastingOrderHeaderInfo(int SaleCastingOrderId)
		{
			return _om.SALEORDERS.Single(x => x.SOSEQ == SaleCastingOrderId);
		} // end GetSaleCastingOrderHeaderInfo

		public DataTable GetSaleCastingItems(int SaleCastingOrderId)
		{
			var _result = new DataTable();
			var soItems = (from s in _om.SOLINES
							orderby s.ITEMNO
							where s.ISDELETE == false
								 && s.SOSEQ == SaleCastingOrderId
							select new
							{
								s.SOLINESEQ,
								s.FGLINESEQ,
								s.SALETYPE,
								s.SO_GUID,
								s.REFSOKEY,
								s.SOSEQ,
								s.PO,
								s.ITEMID,
								s.PREFIX,
								s.ITEMNO,
								s.ITEMNAME,
								s.UNIT,
								s.ISMATINCLUDE,
								QTY = s.DELIVEREDQTY,
								s.UNITPRICE,
								TOTALVALUE = s.DELIVEREDQTY * s.UNITPRICE,
								s.TOTALWEIGHT,
								s.AVGUNITWEIGHT,
								s.AVGPRICEUNITWEIGHT,
								s.JOBNO
							}).OrderBy(o => o.SOLINESEQ).AsParallel();

			if (soItems != null) _result = soItems.ToDataTable();

			return _result;

		} // end GetSaleCastingItems

		public async Task<DataTable> GetAsyncSaleCastingItems(int SaleCastingOrderId)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var soItems = (from s in _om.SOLINES
								orderby s.ITEMNO
								where s.ISDELETE == false
									 && s.SOSEQ == SaleCastingOrderId
								select new
								{
									s.SOLINESEQ,
									s.FGLINESEQ,
									s.SALETYPE,
									s.SO_GUID,
									s.REFSOKEY,
									s.SOSEQ,
									s.PO,
									s.ITEMID,
									s.PREFIX,
									s.ITEMNO,
									s.ITEMNAME,
									s.UNIT,
									QTY = s.DELIVEREDQTY,
									s.UNITPRICE,
									TOTALVALUE = s.DELIVEREDQTY * s.UNITPRICE,
									s.TOTALWEIGHT,
									s.AVGUNITWEIGHT,
									s.AVGPRICEUNITWEIGHT,
									s.JOBNO
								}).OrderBy(o => o.SOLINESEQ).AsParallel();

				if (soItems != null) _result = soItems.ToDataTable();

				return _result;
			});
		} // end GetAsyncSaleCastingItems

		public int RemoveAllSOLinesWhenCancelInAddMode(int RefSOId)
		{
			var _result = 0;
			// find the list of SOLines
			var sl = _om.SOLINES.Where(x => x.REFSOKEY == RefSOId).ToList();

			try
			{
				_om.SOLINES.RemoveRange(sl);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't remove item(s).....", ex);
			}

			return _result;
		} // end RemoveAllSOLinesWhenCancelInAddMode

		public async Task<DataTable> GetAvailableFGItemsForSelectedCustomerAsync(string CustomerCode, int MaterialId, int SOKey, bool HasItem, string connectionString)
		{
			return await Task.Run(() =>
			{
				int _hasItem = HasItem == true ? 1 : 0;
				StringBuilder s = new StringBuilder();
				s.AppendLine($" EXEC dbo.usp_OM_CASTING_FG_ITEMS ");
				s.AppendLine($" @CustomerCode ='{CustomerCode}',");
				s.AppendLine($" @MaterialId ={MaterialId},");
				s.AppendLine($" @SOKey ={SOKey},");
				s.AppendLine($" @HasItem ={_hasItem}");
				return new DataConnect(s.ToString(), connectionString).ToDataTable;
			});
		} // end GetAvailableFGItemsForSelectedCustomer

		public int InsertCastingSaleOrderItem(ref DataGridView Source, int SOKey, Guid soGuid, string SONumber, int SaleType,
			decimal VATFactor, DateTime ActualDeliveryDate)
		{
			var _result = 0;
			var _fgKey = 0;

			// insert FG data into SOLine Table
			// 1. must check the previous data had existed in the table before?
			//    none:			insert 
			//    has record :	edit record
			//
			// 2. if flag IsVATIncl is 'true' the calculate unit price must be apply 
			//    by which flag change (remove VAT from original unit price)
			//
			foreach (DataGridViewRow dgr in Source.Rows)
			{
				_fgKey = Convert.ToInt32(dgr.Cells["FGSEQ"].Value);

				var sl = new SOLINE();
				sl.AUDITUSER = omglobal.UserInfo;
				sl.AUDITDATE = DateTime.Now;
				sl.MODIDATE = DateTime.Now;
				sl.MODIUSER = omglobal.UserInfo;

				sl.ISCOMPLETE = false;
				sl.ISDELETE = false;

				sl.CUSTCODE = dgr.Cells["CUSTCODE"].Value.ToString();
				sl.CUSTID = Convert.ToInt32(dgr.Cells["CUSTID"].Value);

				sl.DELIVERDATE = ActualDeliveryDate.Date2Num();
				sl.FGLINESEQ = Convert.ToInt32(dgr.Cells["FGSEQ"].Value);
				sl.PO = "";
				sl.SALETYPE = SaleType;
				sl.SO_GUID = soGuid;
				sl.REFSOKEY = SOKey;
				sl.SOSEQ = SOKey;
				sl.SONO = SONumber;
				sl.MATTYPE = Convert.ToInt32(dgr.Cells["MATID"].Value);

				sl.JOBNO = Convert.ToInt32(dgr.Cells["JOBNO"].Value);
				sl.ITEMID = Convert.ToInt32(dgr.Cells["ITEMID"].Value);
				sl.PREFIX = dgr.Cells["PREFIX"].Value.ToString();
				sl.ITEMNO = dgr.Cells["ITEMNO"].Value.ToString();
				sl.ITEMNAME = dgr.Cells["ITEMNAME"].Value.ToString();
				sl.UNIT = dgr.Cells["UNIT"].Value.ToString();
				sl.DELIVEREDQTY = Convert.ToDecimal(dgr.Cells["QTY"].Value);
				sl.UNITPRICE = 0.00m; //Convert.ToDecimal(dgr.Cells["UNITPRICE"].Value);
				sl.UNITDISCOUNT = 0.00m;
				sl.NETTUNITVALUE = sl.UNITPRICE - sl.UNITDISCOUNT;
				sl.TOTALVALUE = sl.DELIVEREDQTY * sl.NETTUNITVALUE;
				sl.VATFACTOR = VATFactor;
				sl.VATVALUE = VATFactor * sl.TOTALVALUE;
				sl.LINEAMOUNT = sl.TOTALVALUE + sl.VATVALUE;
				sl.TOTALWEIGHT = Convert.ToDecimal(dgr.Cells["WEIGHT"].Value);
				sl.AVGUNITWEIGHT = sl.TOTALWEIGHT / (sl.DELIVEREDQTY == 0.00m ? 1.00m : sl.DELIVEREDQTY);
				sl.AVGPRICEUNITWEIGHT = sl.TOTALVALUE / (sl.TOTALWEIGHT == 0.00m ? 1.00m : sl.TOTALWEIGHT);
				sl.SOLINEREMARK = "";

				try
				{
					_om.SOLINES.Add(sl);
					_result = _om.SaveChanges();

					// add FG-Stock log
					string _matname = new MaterialDAL().GetMaterialNameById(sl.MATTYPE);
					FGLogInfo _log = new FGLogInfo();
					_log.type = "SO Item";
					_log.recordid = sl.SOLINESEQ;
					_log.action = "Insert SOLine";
					_log.jobno = sl.JOBNO;
					_log.logdate = DateTime.Now;
					_log.material = $"{sl.MATTYPE} : {_matname}";
					_log.matweight = sl.TOTALWEIGHT;
					_log.modulename = "CASTING SALE";
					_log.partname = sl.ITEMNAME;
					_log.partno = sl.ITEMNO;
					_log.qty = sl.DELIVEREDQTY;
					_log.unit = sl.UNIT;
					_log.woker = omglobal.UserName;
					_log.workstation = omglobal.WorkStation;

					_result = new JobDAL().saveFGLog(_log);
				}
				catch (OptimisticConcurrencyException ex)
				{
					throw new Exception("Can't update item...", ex);
				}
			}


			return _result;
		} // end InsertCastingSaleOrderItem

		public int RemoveCastingSaleOrderItem(int SOLineItemId)
		{
			var _result = 0;
			try
			{
				_om.SOLINES.Remove(_om.SOLINES.Single(x => x.SOLINESEQ == SOLineItemId));
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't remove the selected Item...", ex);
			}

			return _result;

		} // end RemoveCastingSaleOrderItem

		public int UpdateCastingSaleOrderHeader(SALEORDER so, int SOKey)
		{
			var _result = 0;
			var _latestSOSEQ = 0;
			var _orderNumber = string.Empty;
			var _mode = so.SOSEQ == 0 ? ActionMode.Add : ActionMode.Edit;
			var _saleType =
				(OMShareCastingEnums.SaleTypeEnum)Enum.Parse(typeof(OMShareCastingEnums.SaleTypeEnum), so.SALETYPE.ToString());

			try
			{
				if (_mode == ActionMode.Add)
				{
					_orderNumber = so.SONO;
					_om.SALEORDERS.Add(so);
					_result = _om.SaveChanges();
				}
				else
				{
					var s = _om.SALEORDERS.Single(x => x.SOSEQ == so.SOSEQ);

					// ADD CODE FOR UPDATE HERE ???????
					// 2016.04.05 - 16:26
					_latestSOSEQ = so.SOSEQ;
					s.MODIFYTIME = so.MODIFYTIME;
					s.MODIUSER = so.MODIUSER;
					s.SOLINECOUNT = so.SOLINECOUNT;
					s.DUEDATE = so.DUEDATE;
					s.ACTUALDELIVERDT = so.ACTUALDELIVERDT;
					s.DELIVERMAT = so.DELIVERMAT;
					s.DELIVERWEIGHT = so.DELIVERWEIGHT;
					s.SALEDETAILS = so.SALEDETAILS;
					s.CONTACT_PERSON = so.CONTACT_PERSON;
					s.REMARK = so.REMARK;
					s.ISVAT = so.ISVAT;
					s.VATCAL = so.VATCAL;
					s.SIWEIGHT = so.SIWEIGHT;
					s.TOTALVALUE = so.TOTALVALUE;
					s.DISCOUNT = so.DISCOUNT;
					s.NETVALUE = so.NETVALUE;
					s.VATPERCENT = so.VATPERCENT;
					s.VATVALUE = so.VATVALUE;
					s.TOTALAMOUNT = so.TOTALAMOUNT;
					s.TOTALAMOUNTTEXT = so.TOTALAMOUNTTEXT;
					s.OUTSTANDWEIGHT = so.OUTSTANDWEIGHT;
					s.RECEIVEWEIGHT = so.RECEIVEWEIGHT;

					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update Casting Sale Order.....", ex);
			}

			// result must turn value > 0, mean insert or update SALEORDERS (header) success
			// otherwise, error...
			// updating SO-LINES & FG-STOCK
			if (_mode == ActionMode.Add)
			{
				// re-create SO SEQ
				_latestSOSEQ = GetLatestCastingSaleOrderId(_saleType);
				if (UpdateSOSEQInSOLines(_latestSOSEQ, _orderNumber, SOKey) > 0)
				{
					if (so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
					{
						if (UpdateFGStockForIssueSOLines(_latestSOSEQ, _mode) > 0)
						{
						}
					}
				}
			}
			else if (_mode == ActionMode.Edit)
			{
				// update FG-Stock value;
				if (so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
				{
					UpdateFGStockForIssueSOLines(_latestSOSEQ, _mode);
				}
			}

			return _result;
		} // end UpdateCastingSaleOrderHeader

		public int MarkDeleteCastingSaleOrder(int SaleOrderId)
		{
			var _result = 0;
			var _rowForSellingMaterial = 0;
			var _rowForCastingLabour = 0;

			var _saleType = OMShareCastingEnums.SaleTypeEnum.ไม่ระบุ;

			var so = _om.SALEORDERS.Single(x => x.SOSEQ == SaleOrderId);

			// get master sale-type from master casting sale order...
			_saleType = (OMShareCastingEnums.SaleTypeEnum)Enum.ToObject(typeof(OMShareCastingEnums.SaleTypeEnum), so.SALETYPE);

			// find SO-Lines records according with MasterSaleOrderId
			// in case of sale-type = "SaleMaterial", delete the SO-Line record
			// otherwise, update FG-Stock and then delete SO-Line Record.

			var _sl = _om.SOLINES.Where(x => x.SOSEQ == SaleOrderId).ToList();

			try
			{
				foreach (var _slItem in _sl)
					if (_saleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
						_rowForSellingMaterial += RemoveCastingSaleOrderItem(_slItem.SOLINESEQ);
					else // ค่าแรง
						_rowForCastingLabour += UpdateFGStockForRemoveSOLines(_slItem.SOLINESEQ);

				// mark deletion in Master CastingSaleOrder
				so.ISDELETE = true;
				so.TOTALVALUE = 0.00m;
				so.DISCOUNT = 0.00m;
				so.NETVALUE = 0.00m;
				so.VATVALUE = 0.00m;
				so.TOTALAMOUNT = 0.00m;
				so.TOTALAMOUNTTEXT = "";
				so.DELIVERMAT = 0;
				so.DELIVERWEIGHT = 0.00m;
				so.OUTSTANDWEIGHT = 0.00m;
				so.SIWEIGHT = 0.00m;
				so.REMARK = "RECORE WAS DELETED BY USER : " + omglobal.UserName + "@ " + DateTime.Now;
				so.MODIUSER = omglobal.UserInfo;
				so.MODIFYTIME = DateTime.Now;
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("ERROR DELETE SALE ORDER", ex.ToString());
			}

			return _result;

		} // end MarkDeleteCastingSaleOrder

		public int GetLatestCastingSaleOrderId(OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			return _om.SALEORDERS.Where(x => x.SALETYPE == (int)SaleType).Max(x => x.SOSEQ);
		} // end GetLatestQuotationHeaderId

		public int UpdateSOSEQInSOLines(int SaleOrderId, string SaleOrderNumber, int SOKey)
		{
			var _result = 0;
			try
			{
				_om.SOLINES.Where(x => x.REFSOKEY == SOKey).ToList().ForEach(c =>
				{
					c.REFSOKEY = SaleOrderId;
					c.SOSEQ = SaleOrderId;
					c.SONO = SaleOrderNumber;
					c.MODIUSER = omglobal.UserInfo;
					c.MODIDATE = DateTime.Now;
				});
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update the reference Quotation Header Index", ex);
			}
			return _result;
		} // end UpdateSOSEQInSOLines

		public int UpdateFGStockForIssueSOLines(int SaleOrderId, ActionMode Mode)
		{
			var _result = 0;

			// select only FG record that belong to SALE-ORDER
			var fgList = from s in _om.SOLINES
						 where s.SOSEQ == SaleOrderId
						 select new
						 {
							 s.FGLINESEQ
						 };
			var _fgl = fgList.Select(x => x.FGLINESEQ).ToArray();

			// generate SO-LINES main list for update from SOLine
			// in Add Mode

			var sl = (from s in _om.SOLINES
					  orderby s.SOSEQ, s.SOLINESEQ
					  where s.ISDELETE == false
							&& s.ISCOMPLETE == false
							&& s.SONO != omglobal.AUTO_SI_NUMBER
							&& _fgl.Contains(s.FGLINESEQ)
					  group s by new
					  {
						  s.FGLINESEQ
					  }
				into slsum
					  select new
					  {
						  FGID = slsum.Key.FGLINESEQ,
						  TotalDeliveryFG = slsum.Sum(x => x.DELIVEREDQTY),
						  TotalDeliveryWT = slsum.Sum(x => x.TOTALWEIGHT)
					  }).AsParallel();

			// when supply mode as 'EDIT' 
			// must filtering only freely SOSEQ (in FG-STOCK table)
			// for available for updating

			// processing update the FG-STOCK as the giving the SO-LINES list item(s)

			decimal _matIssueWeight = 0;
			decimal _qtyIssue = 0;

			try
			{
				foreach (var l in sl.ToList())
				{
					_om.FGSTOCKs.Where(x => x.FGSEQ == l.FGID).ToList().ForEach(c =>
					{
						_qtyIssue = l.TotalDeliveryFG;
						_matIssueWeight = l.TotalDeliveryWT;

						c.DELIVERYQTY = l.TotalDeliveryFG;
						c.REMAINFG = c.QTY - c.DELIVERYQTY;
						c.TOTALDELIVERYWT = l.TotalDeliveryWT;
						c.REMAINWEIGHT = c.TOTALLINEWT - c.TOTALDELIVERYWT;
						c.ISCOMPLETION = c.REMAINFG.Value > 0.00m ? false : true;
						c.MODIUSER = omglobal.UserInfo;
						c.MODIDATE = DateTime.Now;
					});
					_result += _om.SaveChanges();

					if (_result > 0)
					{
						FGSTOCK _fg = _om.FGSTOCKs.Single(x => x.FGSEQ == l.FGID);
						string _matname = new MaterialDAL().GetMaterialNameById(_fg.MATID);
						FGLogInfo _log = new FGLogInfo();
						_log.type = "FG Item";
						_log.recordid = _fg.FGSEQ;
						_log.action = "Issue FG";
						_log.jobno = _fg.DOCNO;
						_log.logdate = DateTime.Now;
						_log.material = $"{_fg.MATID} : {_matname}";
						_log.matweight = _matIssueWeight;
						_log.modulename = "CASTING SALE";
						_log.partname = _fg.ITEMNAME;
						_log.partno = _fg.ITEMNO;
						_log.qty = _qtyIssue;
						_log.unit = _fg.UNIT;
						_log.woker = omglobal.UserName;
						_log.workstation = omglobal.WorkStation;
						_result = new JobDAL().saveFGLog(_log);
					}
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update FG-Stock....", ex);
			}

			return _result;

		} // end UpdateFGStockForIssueSOLines

		public int UpdateFGStockForRemoveSOLines(int SOLineItemId)
		{
			var _result = 0;
			decimal _matReturnWeight = 0;
			decimal _qtyReturn = 0;

			// Get the SO-Line item that want to return value
			var sl = _om.SOLINES.Find(SOLineItemId);

			// updating FG-Stock

			try
			{
				_om.FGSTOCKs.Where(x => x.FGSEQ == sl.FGLINESEQ).ToList().ForEach(c =>
				{
					_matReturnWeight = sl.TOTALWEIGHT;
					_qtyReturn = sl.DELIVEREDQTY;

					c.DELIVERYQTY -= sl.DELIVEREDQTY;
					c.TOTALDELIVERYWT -= sl.TOTALWEIGHT;
					c.ISCOMPLETION = false;
					c.MODIUSER = omglobal.UserInfo;
					c.MODIDATE = DateTime.Now;
				});
				_result = _om.SaveChanges();

				// when success update (return) value in FG-Stock item
				// now can delete (remove) item from SO-Line
				if (_result > 0)
				{
					_om.SOLINES.Remove(_om.SOLINES.Find(SOLineItemId));
					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update (return) the FG-Stock item....", ex);
			}

			// add FG-Stock log
			if (_result > 0)
			{
				// delete SO-Line --> log
				string _matname = new MaterialDAL().GetMaterialNameById(sl.MATTYPE);
				FGLogInfo _log = new FGLogInfo();
				_log.type = "SO Item";
				_log.recordid = sl.SOLINESEQ;
				_log.action = "Delete SOLine";
				_log.jobno = sl.JOBNO;
				_log.logdate = DateTime.Now;
				_log.material = $"{sl.MATTYPE} : {_matname}";
				_log.matweight = _matReturnWeight;
				_log.modulename = "CASTING SALE";
				_log.partname = sl.ITEMNAME;
				_log.partno = sl.ITEMNO;
				_log.qty = _qtyReturn;
				_log.unit = sl.UNIT;
				_log.woker = omglobal.UserName;
				_log.workstation = omglobal.WorkStation;
				_result = new JobDAL().saveFGLog(_log);


				// update FG --> log

				FGSTOCK _fg = _om.FGSTOCKs.Single(x => x.FGSEQ == sl.FGLINESEQ);
				_matname = new MaterialDAL().GetMaterialNameById(_fg.MATID);
				_log = new FGLogInfo();
				_log.type = "FG Item";
				_log.recordid = _fg.FGSEQ;
				_log.action = "Return FG";
				_log.jobno = _fg.DOCNO;
				_log.logdate = DateTime.Now;
				_log.material = $"{_fg.MATID} : {_matname}";
				_log.matweight = _matReturnWeight;
				_log.modulename = "CASTING SALE";
				_log.partname = _fg.ITEMNAME;
				_log.partno = _fg.ITEMNO;
				_log.qty = _qtyReturn;
				_log.unit = _fg.UNIT;
				_log.woker = omglobal.UserName;
				_log.workstation = omglobal.WorkStation;
				_result = new JobDAL().saveFGLog(_log);
			}

			return _result;
		} // end UpdateFGStockForRemoveSOLines


		public SOLINE GetSOLineItemInfo(int Id)
		{
			return _om.SOLINES.Single(x => x.SOLINESEQ == Id);
		} // end GetSOLineItemInfo

		public int UpdateSOLineItem(SOLINE SOLineItem, ActionMode SOHeaderMode)
		{
			var _result = 0;

			// in case of SOHeaderMode == Add, no need to keep log detail
			// otherwise keep modify information in log detail
			try
			{
				switch (SOHeaderMode)
				{
					case ActionMode.Add:
						_om.SOLINES.Add(SOLineItem);
						_result = _om.SaveChanges();

						break;

					case ActionMode.Edit:
						var sl = _om.SOLINES.Single(x => x.SOLINESEQ == SOLineItem.SOLINESEQ);
						sl.MODIDATE = SOLineItem.MODIDATE;
						sl.MODIUSER = SOLineItem.MODIUSER;
						sl.AVGPRICEUNITWEIGHT = SOLineItem.AVGPRICEUNITWEIGHT;
						sl.AVGUNITWEIGHT = SOLineItem.AVGUNITWEIGHT;
						sl.MATTYPE = SOLineItem.MATTYPE;
						sl.SL_CPT = SOLineItem.SL_CPT;
						sl.ITEMID = SOLineItem.ITEMID;
						sl.ITEMNAME = SOLineItem.ITEMNAME;
						sl.UNIT = SOLineItem.UNIT;
						sl.DELIVERDATE = SOLineItem.DELIVERDATE;
						sl.DELIVEREDQTY = SOLineItem.DELIVEREDQTY;
						sl.LINEAMOUNT = SOLineItem.LINEAMOUNT;
						sl.NETTUNITVALUE = SOLineItem.NETTUNITVALUE;
						sl.TOTALVALUE = SOLineItem.TOTALVALUE;
						sl.TOTALWEIGHT = SOLineItem.TOTALWEIGHT;
						sl.UNITDISCOUNT = SOLineItem.UNITDISCOUNT;
						sl.ISMATINCLUDE = SOLineItem.ISMATINCLUDE;
						sl.UNITPRICE = SOLineItem.UNITPRICE;
						sl.VATVALUE = SOLineItem.VATVALUE;
						sl.SOLINEREMARK = SOLineItem.SOLINEREMARK;
						_result = _om.SaveChanges();
						break;
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("Error", "Can't update information for SO Item....", ex);
			}

			return _result;
		} // end UpdateSOLineItem

		public decimal GetAvailableQtyFGStock(int FGItemId)
		{
			return _om.FGSTOCKs.Single(x => x.FGSEQ == FGItemId).REMAINFG.Value;
		} // end GetAvailableQtyFGStock

		#endregion

		#region Summary Casting Material

		// CREATE PIVOT TABLE
		public async Task<DataTable> GetAsyncMaterialSummaryForCastingSaleOrder(string MaterialCategory)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var cat = (from cl in _om.SYSDATAs
							orderby cl.ENKEYNAME
							where cl.CATEGORY == MaterialCategory
							select new
							{
								cl.KEYVALUE,
								cl.THKEYNAME
							}).Distinct().AsParallel();

				var mat = (from so in _om.SALEORDERS.AsEnumerable()
							join c in _om.CUSTOMERS on so.CUSTCODE equals c.CUSTCODE
							join mtype in cat.ToList() on so.DELIVERMAT.ToString() equals mtype.KEYVALUE
							where so.ISCANCEL == false
								 && so.ISDELETE == false
								 && so.OUTSTANDWEIGHT > 0.00m
								 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnumEN.SaleMaterial
							group so by new
							{
								so.CUSTCODE,
								c.CUSTNAME,
								mtype.THKEYNAME
							}
					into matsum
							select new
							{
								matsum.Key.CUSTCODE,
								Customer = matsum.Key.CUSTNAME,
								Material = matsum.Key.THKEYNAME,
								Total = matsum.Sum(x => x.OUTSTANDWEIGHT)
							}).OrderBy(x => x.Material).AsParallel();

				var m = mat.ToDataTable();

					// copy data table
					var _tbl = m.Copy();

					// remove column(s)
					_tbl.Columns.Remove("Material");
				_tbl.Columns.Remove("Total");

					// create string array for new column
					var pkCol = _tbl.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray();
				_result = _tbl.DefaultView.ToTable(true, pkCol).Copy();
				_result.PrimaryKey = _result.Columns.Cast<DataColumn>().ToArray();

					// add Total column to result data table
					// as the first column for pivot
					_result.Columns.Add("Total", typeof(decimal));

				m.AsEnumerable()
					.Select(r => r["Material"].ToString())
					.Distinct()
					.ToList()
					.ForEach(c => _result.Columns.Add(c, typeof(decimal)));

					//
					// load data into result data table
					// and add zero "0.00" to field that no data (only field that valueType is 'decimal'
					//
					foreach (DataRow dr in m.Rows)
				{
					var _totalWeight = 0.00m;
					var _r = _result.Rows.Find(pkCol.Select(c => dr[c]).ToArray());
					_r[dr["Material"].ToString()] = dr["Total"];

					foreach (DataColumn dc in _result.Columns)
					{
						if (dc.DataType == typeof(decimal)
							&& dc.ColumnName != "Total")
						{
							if (Convert.IsDBNull(_r[dc.ColumnName]) == false)
							{
								_totalWeight += Convert.ToDecimal(_r[dc.ColumnName]);
							}
							else
							{
								_r[dc.ColumnName] = 0.00m;
							}
						}
					}
					_r["Total"] = _totalWeight;
				}

					// add summary row
					var _sumRow = _result.NewRow();

				foreach (DataColumn dc in _result.Columns)
				{
					var _sumWeight = 0.00m;
					if (dc.ColumnName == "Customer" || dc.ColumnName == "CUSTCODE")
					{
						if (dc.ColumnName == "CUSTCODE")
							_sumRow[dc.ColumnName] = "";
						else
							_sumRow[dc.ColumnName] = "Total Weight";
					}
					else
					{
						foreach (DataRow dr in _result.Rows)
							_sumWeight += Convert.ToDecimal(dr[dc.ColumnName]);
						_sumRow[dc.ColumnName] = _sumWeight;
					}
				}

				_result.Rows.Add(_sumRow);
				_result.DefaultView.Sort = "Total";

				return _result;
			});
		} // end GetAsyncMaterialSummaryForCastingSaleOrder


		public DataTable GetPendingReturnMaterialByCustomer(string CustomerCode, string MaterialCategory)
		{
			var _result = new DataTable();

			var _mp = (from so in _om.SALEORDERS.AsEnumerable()
						join m in _om.SYSDATAs on so.DELIVERMAT.ToString() equals m.KEYVALUE
						orderby so.SONO
						where so.ISCANCEL == false
							 && so.ISDELETE == false
							 && so.OUTSTANDWEIGHT > 0.00m
							 && so.CUSTCODE == CustomerCode
							 && so.SALETYPE != (int)OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ
							 && m.CATEGORY == MaterialCategory
						select new
						{
							so.SOSEQ,
							so.SONO,
							OrderDate = so.SODATE.Num2Date(),
							m.THKEYNAME,
							so.DELIVERWEIGHT,
							so.RECEIVEWEIGHT,
							so.OUTSTANDWEIGHT
						}).AsParallel();

			if (_mp != null)
				_result = _mp.ToDataTable();

			return _result;
		} // end GetPendingReturnMaterialByCustomer

		#endregion

		#region GRV-Material Receive

		public async Task<DataTable> GetAsyncGRVList(string CustomerCode = "")
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();

				var _mr = (from m in _om.MATRECEIVEs.AsEnumerable()
							join c in _om.CUSTOMERS on m.CUSTCODE equals c.CUSTCODE
							join mat in _om.SYSDATAs on m.MATTYPE.ToString() equals mat.KEYVALUE
							join u in _om.SYSDATAs on m.RECEIVEUNIT.ToString() equals u.KEYVALUE
							where m.ISDELETE == false
								 && mat.GROUPTITLE == "MATERIAL"
								 && u.GROUPTITLE == "UNITCOUNT"
							select new
							{
								m.ISFORSALE,
								GRV = m.GRVSEQ,
								DATE = m.RECEIVEDATE.Num2Date(),
								m.CUSTCODE,
								CUSTOMER = c.CUSTNAME,
								DOCUMENT = m.CUSTDOCNO,
								MATERIAL = mat.THKEYNAME,
								UNIT = u.THKEYNAME,
								Receive = m.RECEIVEWEIGHT,
								Clearing = m.TOTALCLEARING,
								Balance = m.BALANCEWEIGHT,
								remark = m.ISFORSALE ? "SALE" : "RETURN",
								m.MATTYPE,
								m.REFSONUMBER,
								m.SOSEQ
							}).OrderByDescending(x => x.GRV).ThenBy(x => x.DATE).AsParallel();

				if (CustomerCode == "")
					_result = _mr.ToDataTable();
				else
					_result = _mr.Where(x => x.CUSTCODE == CustomerCode).ToDataTable();

				return _result;
			});
		} // end GetAsyncGRVList

		public MATRECEIVE GetGRVInfo(int GRVId)
		{
			return _om.MATRECEIVEs.Single(x => x.GRVSEQ == GRVId);
		} // end GetGRVInfo

		public int UpdateGRVInfo(MATRECEIVE GRV)
		{
			var _result = 0;
			try
			{
				if (GRV.GRVSEQ == 0)
				{
					_om.MATRECEIVEs.Add(GRV);
					_result = _om.SaveChanges();
				}
				else
				{
					var _grv = _om.MATRECEIVEs.Single(x => x.GRVSEQ == GRV.GRVSEQ);
					_grv.ISCOMPLETE = GRV.ISCOMPLETE;
					_grv.BALANCEWEIGHT = GRV.BALANCEWEIGHT;
					_grv.CUSTDOCNO = GRV.CUSTDOCNO;
					_grv.DESCRIPTION = GRV.DESCRIPTION;
					_grv.ISFORSALE = GRV.ISFORSALE;
					_grv.MATTYPE = GRV.MATTYPE;
					_grv.MODIDATE = GRV.MODIDATE;
					_grv.MODIUSER = GRV.MODIUSER;
					_grv.RECEIVEDATE = GRV.RECEIVEDATE;
					_grv.RECEIVERNAME = GRV.RECEIVERNAME;
					_grv.RECEIVEUNIT = GRV.RECEIVEUNIT;
					_grv.RECEIVEWEIGHT = GRV.RECEIVEWEIGHT;
					_grv.REFSONUMBER = GRV.REFSONUMBER;
					_grv.SENDERNAME = GRV.SENDERNAME;
					_grv.SENDINGDATE = GRV.SENDINGDATE;
					_grv.SOSEQ = GRV.SOSEQ;
					_grv.TOTALCLEARING = GRV.TOTALCLEARING;

					_result = _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("Error Insert/Update GRV", ex.ToString());
			}

			return _result;
		} // end UpdateGRVInfo

		public int ConfirmClearingMaterial(ref DataGridView MatClearingList, int GRVNumber, DateTime ReceiveDate,
			string Document, int MaterialId)
		{
			var _result = 0;
			var _matId = 0;
			var _returnWeight = 0.00m;
			var _matFactor = 0.00m;
			var _siPercent = 0.00m;
			var _siFactor = 0.00m;
			var _returnMatFactor = 0.00m;
			var _returnSIPercent = 0.00m;

			var _matDAL = new MaterialDAL();
			var _matReturn = new CUSTMATRETURN();

			try
			{
				foreach (DataGridViewRow dgr in MatClearingList.Rows)
					if (Convert.ToDecimal(dgr.Cells["CLEARING"].Value) > 0.00m)
					{
						_matReturn.CUSTMATSEQ = 0;
						_matReturn.ISDELETE = false;
						_matReturn.SOSEQ = Convert.ToInt32(dgr.Cells["SOSEQ"].Value);
						_matReturn.REFSONO = dgr.Cells["SCNUMBER"].Value.ToString();
						_matReturn.CUSTCODE = dgr.Cells["CUSTCODE"].Value.ToString();
						_matReturn.CUSTID = Convert.ToInt32(dgr.Cells["CUSTID"].Value);
						_matReturn.RETURNDATE = Convert.ToDateTime(dgr.Cells["ISSUEDATE"].Value).Date2Num();
						_matReturn.FISCPERIOD = ReceiveDate.Month;
						_matReturn.FISCYEAR = ReceiveDate.Year;
						_matReturn.GRVNO = GRVNumber;
						_matReturn.REFCUSTDOC = Document;
						_matReturn.REFMATDOC = dgr.Cells["ISSUENO"].Value.ToString();
						_matReturn.RETURNMATTYPE = MaterialId;
						_returnWeight = Convert.ToDecimal(dgr.Cells["CLEARING"].Value);
						_matReturn.RETURNWEIGHT = _returnWeight;

						// finding mat factor of returning material
						_matDAL.GetMaterialInfoByMaterialId(MaterialId, ref _returnSIPercent, ref _returnMatFactor);

						// cal si - QTY from return qty.
						_matId = Convert.ToInt32(dgr.Cells["MATID"].Value);
						_matDAL.GetMaterialInfoByMaterialId(_matId, ref _siPercent, ref _matFactor);
						_matReturn.DELIVERMATID = _matId;
						_matReturn.MATFACTOR = _matFactor;
						_matReturn.MAT_SI_PERCENT = _siPercent;

						if (MaterialId == _matId)
						{
							_matReturn.SI_QTY = 0.00m;
						}
						else if (_returnMatFactor == _matFactor)
						{
							_matReturn.SI_QTY = 0.00m;
						}
						else if (_returnMatFactor < _matFactor)
						{
							_matReturn.SI_QTY = 0.00m;
						}
						else if (_returnMatFactor > _matFactor)
						{
							_siFactor = _siPercent / (_siPercent + _matFactor * 100 > 0.00m ? _siPercent + _matFactor * 100 : 1.00m);
							_matReturn.SI_QTY = _returnWeight * _siFactor;
						}
						_matReturn.AUDITUSER = omglobal.UserInfo;
						_matReturn.AUDITDATE = DateTime.Now;
						_matReturn.MODIUSER = omglobal.UserInfo;
						_matReturn.MODIFYDATE = DateTime.Now;

						_om.CUSTMATRETURNs.Add(_matReturn);
						_result += _om.SaveChanges();
					}

				// update total clearing and balance of mat receive table 
				var _totalClearing =
					Convert.ToDecimal(((DataTable)MatClearingList.DataSource).AsEnumerable().Sum(x => x.Field<decimal>("CLEARING")));

				_om.MATRECEIVEs.Where(x => x.GRVSEQ == GRVNumber).ToList().ForEach(x =>
				{
					x.TOTALCLEARING += _totalClearing;
					x.BALANCEWEIGHT = x.RECEIVEWEIGHT - x.TOTALCLEARING;
					x.ISCOMPLETE = x.BALANCEWEIGHT <= 0.00m ? true : false;
				});
				_om.SaveChanges();

				// update SALEORDERS for outstanding and receive material weight 
				var _soSeq = 0;
				foreach (DataGridViewRow dgr in MatClearingList.Rows)
				{
					_soSeq = Convert.ToInt32(dgr.Cells["SOSEQ"].Value);
					_om.SALEORDERS.Where(x => x.SOSEQ == _soSeq).ToList().ForEach(c =>
					{
						c.RECEIVEWEIGHT += Convert.ToDecimal(dgr.Cells["CLEARING"].Value);
						c.OUTSTANDWEIGHT = c.DELIVERWEIGHT - c.RECEIVEWEIGHT;
					});

					_result += _om.SaveChanges();
				}
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update clearing material !!", ex);
			}

			return _result;
		} // end ConfirmClearingMaterial

		public DataTable GetCustomerClearingList(int GRVNo)
		{
			return _om.CUSTMATRETURNs.Where(x => x.MATRECEIVE.GRVSEQ == GRVNo).AsEnumerable().Select(r => new
			{
				r.REFSONO,
				ClearingDate = r.RETURNDATE.Num2Date(),
				r.RETURNWEIGHT
			}).OrderBy(o => o.REFSONO).AsParallel().ToDataTable();
		} // end GetCustomerClearingList

		#endregion
	}
}