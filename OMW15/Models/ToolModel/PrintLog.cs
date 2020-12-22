using System.Linq;
using System.Transactions;

namespace OMW15.Models.ToolModel
{
	public class PrintLog
	{
		private readonly OLDMOONEF1 _om;


		// CONSTRUCTOR
		public PrintLog()
		{
			_om = new OLDMOONEF1();
		}

		public int UpdatePrintLog(PRINTLOG log)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.PRINTLOGS.Add(log);
					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch //(OptimisticConcurrencyException ex)
				{
				}
			}

			return _result;
		} // end UpdatePrintLog

		public int UpdatePrintLogForCastingSaleOrder(int OrderId)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.SALEORDERS.Where(x => x.SOSEQ == OrderId).ToList().ForEach(c => { c.ISPRINTED = true; });
					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch //(OptimisticConcurrencyException ex)
				{
				}
			}
			return _result;
		} // end UpdatePrintLogForCastingSaleOrder

		public int UpdatePrintLogForJobOrder(int JobNo)
		{
			var _result = 0;
			using (var scope = new TransactionScope())
			{
				try
				{
					_om.JOBORDERS.Where(x => x.JOBNO == JobNo).ToList().ForEach(c => { c.ISPRINTED = true; });
					_result += _om.SaveChanges();
					scope.Complete();
				}
				catch //(OptimisticConcurrencyException ex)
				{
				}
			}
			return _result;
		} // end UpdatePrintLogForJobOrder
	}
}