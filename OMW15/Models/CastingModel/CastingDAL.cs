using System.Data;
using System.Linq;

namespace OMW15.Models.CastingModel
{
	public class CastingDAL
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public CastingDAL()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		#region class method

		//public DataTable GetMaterialSI()
		//{
		//	DataTable _result = null;
		//	var _matsi = from m in _om.SYSDATAs.AsParallel()
		//					 where m.GROUPTITLE == "MATERIAL"
		//					 orderby m.KEYVALUE
		//					 select new
		//					 {
		//						 Key = m.KEYVALUE,
		//						 Value = m.SI
		//					 };
		//	_result = _matsi.ToDataTable();

		//	return _result;
		//} // end GetMaterialSI

		public decimal GetMaterialSI(string MaterialCode)
		{
			return _om.SYSDATAs.Single(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MaterialCode).SI;
		} // end GetMaterialSI

		public decimal GetMaterialSI(int MaterialId)
		{
			return _om.SYSDATAs.Single(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MaterialId.ToString()).SI;
		} // end GetMaterialSI

		public DataTable GetMaterialData(string Category)
		{
			if (string.IsNullOrEmpty(Category))
				return _om.SYSDATAs
						.Where(x => x.GROUPTITLE == "MATERIAL"
									&& x.CATEGORY != Category
									&& x.Inused == true)
						.Select(c => new
						{
							Key = c.KEYVALUE,
							Value = c.THKEYNAME
						}).ToDataTable();


			return _om.SYSDATAs
					.Where(x => x.GROUPTITLE == "MATERIAL" 
								&& x.CATEGORY == Category
								&& x.Inused == true)
					.Select(c => new
					{
						Key = c.KEYVALUE,
						Value = c.THKEYNAME
					}).ToDataTable();
		} // end GetMaterialData

		public DataTable GetMaterialData()
		{
			return _om.SYSDATAs
				.Where(
						x => x.GROUPTITLE == "MATERIAL"
						&& x.Inused == true
						&& x.CATEGORY != "")
				.Select(c => new
				{
					Key = c.KEYVALUE,
					Value = c.THKEYNAME
				}).ToDataTable();
		} // end GetMaterialData

		public string GetMaterialName(int MaterialId)
		{
			return _om.SYSDATAs.Single(x => x.GROUPTITLE == "MATERIAL" && x.KEYVALUE == MaterialId.ToString()).THKEYNAME;
		} // end GetMaterialName

		#endregion

		#region Casting Sale Order

		#endregion
	}
}