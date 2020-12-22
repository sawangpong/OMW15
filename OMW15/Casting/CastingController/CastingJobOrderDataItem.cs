using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Casting.CastingController
{
	public class CastingJobOrderDataItem
	{
		#region Class Property

		public string CustCode
		{
			get;
			set;
		}

		public string CustName
		{
			get;
			set;
		}

		public string WorkType
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}
		public string CustPO
		{
			get;
			set;
		}
		public int JobNo
		{
			get;
			set;
		}

		public DateTime JobDate
		{
			get;
			set;
		}

		public DateTime DueDate
		{
			get;
			set;
		}

		public string JobCat
		{
			get;
			set;
		}
		public string Material
		{
			get;
			set;
		}

		public string Prefix
		{
			get;
			set;
		}
		public string ItemNo
		{
			get;
			set;
		}
		public string ItemNumber
		{
			get;
			set;
		}

		public string ItemName
		{
			get;
			set;
		}

		public string OrderUnit
		{
			get;
			set;
		}

		public decimal OrderQty
		{
			get;
			set;
		}

		public string Remark
		{
			get;
			set;
		}

		public byte[] Picture
		{
			get;
			set;
		}

		#endregion //end Class Property

	}
}
