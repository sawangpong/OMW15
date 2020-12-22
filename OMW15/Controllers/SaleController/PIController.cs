using System;
using OMW15.Models.SaleModel;

namespace OMW15.Controllers.SaleController
{
	public class PIController
	{
		// constructor

		#region class helper method

		public int GetMaxPINumber()
		{
			return new SaleDAL().GetMaxPINumber(DateTime.Today.Year);
		} // end UpdatePI

		public int ClearUnPostedPIRecords(int PIHeaderId)
		{
			return new SaleDAL().DeleteMultiplePILineItems(PIHeaderId);
		} // end ClearUnPostedPIRecords

		#endregion
	}
}