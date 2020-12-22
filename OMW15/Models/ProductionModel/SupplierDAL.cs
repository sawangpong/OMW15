using OMW15.Models.ToolModel;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;

namespace OMW15.Models.ProductionModel
{
	public class SupplierDAL
	{
		private readonly OLDMOONEF1 _om;

		public SupplierDAL()
		{
			_om = new OLDMOONEF1();
		}

		public DataTable GetProductionOutsourceList(string erpOrder)
		{
			return _om.PRODUCTION_OUTSOURCE
					.Where(x => x.ERP_ORDER == erpOrder)
					.OrderBy(o => o.DATESTART)
					.ToDataTable();

		}

		public PRODUCTION_OUTSOURCE GetOutsourceItem(int id) => _om.PRODUCTION_OUTSOURCE.Find(id);


		public int UpdateProductionOutSource(PRODUCTION_OUTSOURCE outSource)
		{
			var _result = 0;
			try
			{
				if (outSource.Id == 0)
				{
					_om.PRODUCTION_OUTSOURCE.Add(outSource);
				}
				else
				{
					var p = _om.PRODUCTION_OUTSOURCE.Find(outSource.Id);
					p.AP_CODE = outSource.AP_CODE;
					p.AP_NAME = outSource.AP_NAME;
					p.BUILD_DETAIL = outSource.BUILD_DETAIL;
					p.BUILD_QTY = outSource.BUILD_QTY;
					p.DATEFINISH = outSource.DATEFINISH;
					p.DATESTART = outSource.DATESTART;
					p.LABOR_COST = outSource.LABOR_COST;
					p.MATERIAL_COST = outSource.MATERIAL_COST;
					p.OTHER_COST = outSource.OTHER_COST;
					p.TOTAL_COST = outSource.TOTAL_COST;
					p.UNIT = outSource.UNIT;
					p.DRAWINGNO = outSource.DRAWINGNO;
					p.DRAWING_REV = outSource.DRAWING_REV;
					p.ITEMNAME = outSource.ITEMNAME;
					p.ITEMNO = outSource.ITEMNO;
					p.STEP = outSource.STEP;

				}
				_result = _om.SaveChanges();
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("Can't update Standard process !!!!!!", ex);
			}

			return _result;

		}

		public int DeleteOutsourceItem(int id)
		{
			_om.PRODUCTION_OUTSOURCE.Remove(GetOutsourceItem(id));
			return _om.SaveChanges();
		}


		public DataTable GetSupplierList(string filter = "")
		{
			StringBuilder s = new StringBuilder();
			s.AppendLine($" EXEC dbo.usp_OM_ERP_SUPPLIER ");
			s.AppendLine($" @Filter = '{filter}'");
			return new DataConnect(s.ToString(), omglobal.SysConnectionString).ToDataTable;

		}
	}
}
