﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Models.ProductionModel
{
	public class BOMDal
	{
		private readonly OLDMOONEF1 _om;

		public BOMDal()
		{
			_om = new OLDMOONEF1();
		}

		#region class helper

		public DataTable GetTopBomItem(string model)
		{
			return _om.MCBOMs.Where(m => m.MODEL == model
									   && m.LEVEL == 0
									   && m.ISACTIVE == true)
									   .Select(s => new
									   {
										   s.ID,
										   s.LEVEL,
										   s.PARENT_ID,
										   s.REF_NO,
										   s.REF_REV,
										   s.PARTNO,
										   s.PART_REV,
										   s.ITEMNAME,
										   s.UNIT,
										   s.Qty,
										   s.UNITCOST
									   }).AsParallel().ToDataTable();
		}

		public DataTable GetBomItems(string model, string partno, int partRev, int parentId)
		{
			return _om.MCBOMs.Where(x => x.MODEL == model
									   && x.ISACTIVE == true
									   && x.PARENT_ID == parentId
									   && x.REF_NO == partno
									   && x.REF_REV == partRev
									   && x.LEVEL > 0)
									   .Select(s => new
									   {
										   s.ID,
										   s.LEVEL,
										   s.PARENT_ID,
										   s.REF_NO,
										   s.REF_REV,
										   s.PARTNO,
										   s.PART_REV,
										   s.ITEMNAME,
										   s.UNIT,
										   s.Qty,
										   s.UNITCOST
									   }).OrderBy(o => o.ID).ToDataTable();
		}


		public bool GetNodeAvailable(string model, string parentno)
		{
			return (_om.MCBOMs.Where(x => x.MODEL == model && x.REF_NO == parentno).Any());
		}

		public MCBOM GetBomItem(int itemId)
		{
			return _om.MCBOMs.Find(itemId);
		}

		public DataTable GetBomModel()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.MODEL
			}).Distinct().AsParallel().ToDataTable();
		}

		public DataTable getPartCategoryFromBOM()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.CATEGORY
			}).Distinct().AsParallel().ToDataTable();
		}

		public DataTable getUnit()
		{
			return (_om.MCBOMs.Select(x => new
			{
				x.UNIT
			}).Distinct().AsParallel().ToDataTable());
		}


		public DataTable getMaker()
		{
			return _om.MCBOMs.Select(x => new
			{
				x.MAKER
			}).Distinct().AsParallel().ToDataTable();
		}
		#endregion

	}
}