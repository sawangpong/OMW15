using System;

namespace OMW15.Models.CastingModel
{
	public class CastingJobOrderDataItem
	{
		#region Class Property

		public bool IsReWorks
		{
			get; set;
		}

		public string CustCode
		{
			get; set;
		}

		public string CustName
		{
			get; set;
		}

		public string WorkType
		{
			get; set;
		}

		public string PriorityClass
		{
			get; set;
		}
		public string Status
		{
			get; set;
		}

		public string CustPO
		{
			get; set;
		}

		public int JobNo
		{
			get; set;
		}

		public DateTime JobDate
		{
			get; set;
		}

		public DateTime DueDate
		{
			get; set;
		}

		public string JobCat
		{
			get; set;
		}

		public string Material
		{
			get; set;
		}

		public bool IsPriceWithMat
		{
			get; set;
		}

		public string Prefix
		{
			get; set;
		}

		public string ItemNo
		{
			get; set;
		}

		public string ItemNumber
		{
			get; set;
		}

		public string ItemName
		{
			get; set;
		}

		public string OrderUnit
		{
			get; set;
		}

		public decimal OrderQty
		{
			get; set;
		}

		public string Remark
		{
			get; set;
		}

		public byte[] Picture
		{
			get; set;
		}

		public byte[] BarCode
		{
			get; set;
		}

		public string FlaskTemp
		{
			get; set;
		}

		public string CastTemp
		{
			get; set;
		}

		#endregion //end Class Property
	}
}