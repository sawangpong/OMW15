using System;

namespace OMW15.Models.CastingModel
{
	public class MaterialCardDataItems
	{
		public string Doc { get; set; }

		public DateTime DocDate { get; set; }

		public string Material { get; set; }

		public decimal In { get; set; }

		public decimal Out { get; set; }

		public decimal Balance { get; set; }

		public string Remark { get; set; }
	}
}