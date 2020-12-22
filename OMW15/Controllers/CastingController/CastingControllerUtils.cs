using System;
using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Shared;
using System.Windows.Forms;

namespace OMW15.Controllers.CastingController
{
	public class CastingControllerUtils
	{
		public int GetAvailableReferenceSOKey(int CustomerId)
		{
			var _result = 0;
			do
			{
				_result = OMUtils.CreateRandomNumber(CustomerId);
			} while (new CastingSaleOrderDAL().GetAvailableReferenceSOKey1(_result) == false);

			return _result;
		} // end GetValidReferenceSOKey

		public int GetLastRunningNo(DateTime SODate, bool IsVAT, OMShareCastingEnums.SaleTypeEnum SaleType,
			string MasterOrderNo = "")
		{
			if (SaleType == OMShareCastingEnums.SaleTypeEnum.ขายวัสดุ)
				return new CastingSaleOrderDAL().GetLastRunningSaleMaterialOrder(MasterOrderNo, SODate, IsVAT, SaleType);
			return new CastingSaleOrderDAL().GetLastRunningCastingSaleOrder(SODate, IsVAT, SaleType);

		} // end GetLastRunningNo

		public string GetNewCastingOrderNumber(DateTime SODate, bool IsVAT, OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			var _codeFormat = IsVAT ? SODate.GetThaiCodeFormat() : SODate.GetGeneralCodeFormat();
			var _lastRunningNo = GetLastRunningNo(SODate, IsVAT, SaleType, "");
			var _nextNumber = (_lastRunningNo + 1);

			return $"{_codeFormat}{_nextNumber:000#}";

		} // end GetNewCastingOrderNumber

		public string GetNewSaleMaterialOrderNumber(string MasterCastingSaleOrderNumber, DateTime SODate, bool IsVAT,
			OMShareCastingEnums.SaleTypeEnum SaleType)
		{
			// for debug
			var _lastRunningNo = GetLastRunningNo(SODate, IsVAT, SaleType, MasterCastingSaleOrderNumber);
			return $"{MasterCastingSaleOrderNumber}-{_lastRunningNo + 1}";

		} // end GetNewSaleMaterialOrderNumber
	}
}