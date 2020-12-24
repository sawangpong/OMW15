using OMW15.Controllers.ToolController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;

namespace OMW15.Models.ServiceModel
{
	public class MachineDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public MachineDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region public class helper method

		public bool existMachine(string serial, string model, string customerCode)
		{
			// true = found
			// false = not found

			return (_om.MIXes.Any(x => x.type == model && x.s_no == serial && x.acccustcode == customerCode));

		} // end existMachine

		public int deleteMachine(int machineId, string model, string serialno, string customerCode)
		{
			int result = 0;

			bool isDoService = _om.ORDERMAINTENANCEs.Any(x => x.type == model && x.s_no == serialno && x.acccustcode == customerCode);

			if (isDoService == false)
			{
				try
				{
					_om.MIXes.Remove(_om.MIXes.Single(x => x.mix_id == machineId));
					result = _om.SaveChanges();
				}
				catch (OptimisticConcurrencyException ex)
				{
					Alert.DisplayAlert("Can't delete selected machine record....", ex.ToString());
				}
			}
			else
			{
				throw new Exception("ไม่สามารถลบรายการที่เลือกได้ เนื่องจากมีข้อมูลบันทึกอยู่ในการบริการเครื่องจักร...");
			}
			return result;

		} // end deleteMachine

		public DataTable GetMachineModels()
		{
			return _om.MIXes.Where(x => x.isdelete == false).Select(s => new
			{
				Model = s.type.Trim()
			}).Distinct().OrderBy(o => o.Model).AsParallel().ToDataTable();
		} // end GetMachineModels

		public async Task<DataTable> GetAsyncMachineList(string Model, string SNFilter, string CustomerFilter, List<string> modelList)
		{
			DataTable dt = await this.GetAsyncMachineList(Model, SNFilter, CustomerFilter);

			if (modelList != null)
			{
				// create reject list
				return await Task.Run(() =>
				{
					var _rejectlist = dt.AsEnumerable().Where(x => modelList.Contains(x.Field<string>("model")));
					return dt.AsEnumerable().Except(_rejectlist).ToDataTable();
				});
			}

			return await Task.Run(() => dt);
		}

		public async Task<DataTable> GetAsyncMachineList(string customerCode)
		{
			return await Task.Run(() =>
			{
				return (from m in _om.MIXes
						where m.isdelete == false
						&& m.acccustcode == customerCode
						select new
						{
							id = m.mix_id,
							Status = m.isexpire ? "Expired" : "Active",
							Transfer = m.istransfer ? "Y" : "N",
							ModelId = m.productid,
							Model = m.type,
							SerialNo = m.s_no,
							CustomerCode = m.acccustcode,
							Customer = m.cus_na,
							SellDate = m.sale_date.Value,
							Expire = m.exp.Value,
							m.remark
						}).Distinct()
						   .OrderBy(model => model.Model)
						   .ThenBy(s => s.SerialNo)
						   .AsParallel()
						   .ToDataTable();
			});
		}

		public async Task<DataTable> GetAsyncMachineList(string Model, string SNFilter, string CustomerFilter)
		{
			return await Task.Run(() =>
			{
				var _result = new DataTable();
				var _ml = (from m in _om.MIXes
						   join c in _om.CUSTOMERS on m.acccustcode equals c.CUSTCODE
						   where m.isdelete == false
						   select new
						   {
							   id = m.mix_id,
							   Status = m.isexpire ? "Expired" : "Active",
							   Transfer = m.istransfer ? "Y" : "N",
							   NewMC = m.isnewproduct ? "Y" : "N",
							   ModelId = m.productid,
							   Model = m.type,
							   SerialNo = m.s_no,
							   c.CUSTID,
							   CustomerCode = m.acccustcode,
							   Customer = c.CUSTNAME,
							   SellDate = m.sale_date.Value,
							   Expire = m.exp.Value,
							   m.remark
						   }).Distinct().AsParallel();

				if (Model == "" && SNFilter == "" && CustomerFilter == "")
					_result =
						_ml.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model != "" && SNFilter != "" && CustomerFilter != "")
					_result =
						_ml.Where(x => x.Model.ToLower() == Model.ToLower()
								&& x.SerialNo.ToLower().Contains(SNFilter.ToLower())
								&& x.Customer.Contains(CustomerFilter))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model != "" && SNFilter != "" && CustomerFilter == "")
					_result =
						_ml.Where(x => x.Model.ToLower() == Model.ToLower()
								&& x.SerialNo.ToLower().Contains(SNFilter.ToLower()))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model != "" && SNFilter == "" && CustomerFilter != "")
					_result =
						_ml.Where(x => x.Model.ToLower() == Model.ToLower()
								&& x.Customer.ToLower().Contains(CustomerFilter.ToLower()))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model != "" && SNFilter == "" && CustomerFilter == "")
					_result =
						_ml.Where(x => x.Model.ToLower() == Model.ToLower())
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model == "" && SNFilter != "" && CustomerFilter != "")
					_result =
						_ml.Where(x => x.SerialNo.ToLower().Contains(SNFilter.ToLower())
							&& x.Customer.ToLower().Contains(CustomerFilter.ToLower()))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model == "" && SNFilter == "" && CustomerFilter != "")
					_result =
						_ml.Where(x => x.Customer.ToLower().Contains(CustomerFilter.ToLower()))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();
				else if (Model == "" && SNFilter != "" && CustomerFilter == "")
					_result =
						_ml.Where(x => x.SerialNo.ToLower().Contains(SNFilter.ToLower()))
							.OrderBy(o => o.Status)
							.ThenBy(o => o.Customer)
							.ThenBy(o => o.Model)
							.ThenBy(o => o.SerialNo)
							.AsParallel()
							.ToDataTable();

				return _result;
			});
		} // end GetAsyncMachineList

		public DataTable GetCurrentMachineOwner(string Model, string SN)
		{
			var m = (from mc in _om.MIXes
					 where mc.istransfer == false
						   && mc.type == Model
						   && mc.s_no == SN
						   && mc.isdelete == false
					 group new
					 {
						 mc
					 } by new
					 {
						 mc.cus_na
					 }
				into mg
					 select new
					 {
						 CurrentOwner = mg.Key.cus_na,
						 Date = mg.Max(x => x.mc.transferdate.Value)
					 }).AsParallel().Take(1);

			return m.ToDataTable();
		} // end GetCurrentMachineOwner


		public int UpdateTransferMachine(MIX MC)
		{
			var _result = 0;
			try
			{
				_om.MIXes.Add(MC);
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("Error Transfer Machine", ex.ToString());
			}

			return _result;
		} // end UpdateTransferMachine

		public int UpdateMachineRecord(MIX MC)
		{
			var _result = 0;

			try
			{
				if (MC.mix_id == 0) // add machine record
				{
					_om.MIXes.Add(MC);
				}
				else // update
				{
					var m = _om.MIXes.Single(x => x.mix_id == MC.mix_id);
					m.acccustcode = MC.acccustcode;
					m.custid = MC.custid;
					m.cus_na = MC.cus_na;
					m.type = MC.type;
					m.s_no = MC.s_no;
					m.sale_date = MC.sale_date;
					m.exp = MC.exp;
					m.isexpire = MC.isexpire;
					m.istransfer = MC.istransfer;
					m.isnewproduct = MC.isnewproduct;
					m.warrantyterm = MC.warrantyterm;
					m.monthfactor = MC.monthfactor;
					m.remark = MC.remark;
					m.modidt = MC.modidt;
					m.modiuser = MC.modiuser;
				}

				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("Can't update machine record", ex.ToString());
			}

			return _result;
		} // end UpdateMachineRecord

		public int UpdateLastOwnerBeforeTransferMachine(int MachineId, DateTime TransferDate)
		{
			var _result = 0;

			try
			{
				_om.MIXes.Where(x => x.mix_id == MachineId).ToList().ForEach(c =>
				{
					c.transferdate = TransferDate;
					c.istransfer = true;
				});
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				Alert.DisplayAlert("Can't update machine record", ex.ToString());
			}

			return _result;
		} // end UpdateLastOwnerBeforeTransferMachine


		public DataTable GetMachineListByOwner(string CustomerCode)
		{
			var _result = new DataTable();

			var _mc = (from m in _om.MIXes
					   where m.isdelete == false
							 && m.acccustcode == CustomerCode
					   orderby m.cus_na
					   select new
					   {
						   id = m.mix_id,
						   productCode = m.productid,
						   CustomerCode = m.acccustcode,
						   Model = m.type,
						   Serial = m.s_no,
						   CustomerName = m.cus_na,
						   SaleDate = m.sale_date.Value,
						   ExpireDate = m.exp.Value
					   }).AsParallel();

			if (_mc != null)
				_result = _mc.ToDataTable();

			return _result;
		} // end GetMachineListByOwner

		public DataTable GetMachineByCustomer(string CustomerCode)
		{
			var _result = new DataTable();

			var _m = (from m in _om.MIXes
					  orderby m.type
					  where m.isdelete == false
							&& m.acccustcode == CustomerCode
					  select new
					  {
						  KEY = m.type,
						  VALUE = m.productid
					  }).Distinct().AsParallel();

			_result = _m.ToDataTable();

			return _result;
		} // end GetMachineByCustomer


		public DataTable GetMachineSerialNoByModel(string CustomerCode, string Model)
		{
			var _result = new DataTable();

			var _m = (from m in _om.MIXes
					  orderby m.type
					  where m.isdelete == false
							&& m.acccustcode == CustomerCode
							&& m.type == Model
					  select new
					  {
						  VALUE = m.s_no,
						  KEY = m.s_no
					  }).Distinct().AsParallel();

			_result = _m.ToDataTable();

			return _result;
		} // end GetMachineByCustomer

		public MIX GetMachineRegisterInfo(int MachineRegisterId)
		{
			return _om.MIXes.Single(x => x.mix_id == MachineRegisterId);
		} // end GetMachineRegisterInfo

		#endregion
	}
}