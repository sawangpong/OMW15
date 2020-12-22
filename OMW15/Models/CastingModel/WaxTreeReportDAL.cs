using System;

namespace OMW15.Models.CastingModel
{
	public class WaxTreeReportDAL
	{
		public DateTime BuildWaxDate { get; set; }

		public int MatId { get; set; }

		public string MatName { get; set; }

		public decimal MatFactor { get; set; }

		public string RubberBaseNo { get; set; }

		public decimal RubberBaseWeight { get; set; }

		public decimal RbaseWithWax { get; set; }

		public decimal NetWaxWeight { get; set; }

		public decimal WeightNeed { get; set; }

		public decimal WeightAdd { get; set; }

		public decimal TotalWeight { get; set; }

		public decimal GoldWeight { get; set; }

		public string AlloyName { get; set; }

		public decimal AlloyWeight { get; set; }

		public decimal SV100Weight { get; set; }

		public decimal SV95Weight { get; set; }

		public decimal SV94Weight { get; set; }

		public string OtherMat { get; set; }

		public decimal OtherMatWeight { get; set; }

		public decimal WeightBeforeCast { get; set; }

		public decimal WeightAfterCast { get; set; }

		public string LossWeight { get; set; }

		public decimal PercentLoss { get; set; }
	}
}