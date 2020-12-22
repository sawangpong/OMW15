using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Casting.CastingController
{
	public class CastingFG 
	{
		OLDMOONEF _om;

		#region constructor and destructor
		
		// Flag: Has Dispose already been called? 
		bool disposed = false;


		public CastingFG()
		{
			_om = new OLDMOONEF();
		}
		
		// Protected implementation of Dispose pattern. 
		//protected virtual void Dispose(bool disposing)
		//{
		//	if (disposed)
		//	{
		//		return;
		//	}

		//	if (disposing)
		//	{
		//		// Free any other managed objects here. 
		//		_om.Dispose();
		//	}

		//	// Free any unmanaged objects here. 
		//	//
		//	disposed = true;
		//}

		//public void Dispose()
		//{
		//	Dispose(true);
		//	GC.SuppressFinalize(this);
		//}

		//~CastingFG()
		//{
		//	//Dispose(true);
		//}

		#endregion

		public int UpdateFGItem(JOBINFO FG)
		{
			int _result = 0;

			using (var scope = new System.Transactions.TransactionScope())
			{
				try
				{
					if (FG.LINESEQ == 0)
					{
						_om.JOBINFOS.Add(FG);
						_result = _om.SaveChanges();
					}
					else
					{
						JOBINFO ji = _om.JOBINFOS.FirstOrDefault(x => x.LINESEQ == FG.LINESEQ);
						ji.ACCEPTQTY = FG.ACCEPTQTY;
						ji.AVGWEIGHT = FG.AVGWEIGHT;
						ji.BADSCORE = FG.BADSCORE;
						ji.CUSTCODE = FG.CUSTCODE;
						ji.CUSTID = FG.CUSTID;
						ji.ERRORID = FG.ERRORID;
						ji.FINISHDATE = FG.FINISHDATE;
						ji.FISCPERIOD = FG.FISCPERIOD;
						ji.FISCYEAR = FG.FISCYEAR;
						ji.GOODSCORE = FG.GOODSCORE;
						ji.GROUPCODE = FG.GROUPCODE;
						ji.ISDELETE = FG.ISDELETE;
						ji.ITEMID = FG.ITEMID;
						ji.ITEMNO = FG.ITEMNO;
						ji.ITEMPREFIX = FG.ITEMPREFIX;
						ji.JOBNO = FG.JOBNO;
						ji.MATERIALID = FG.MATERIALID;
						ji.MODIDATE = FG.MODIDATE;
						ji.MODIUSER = FG.MODIUSER;
						ji.OPERATORID = FG.OPERATORID;
						ji.OPERATORNAME = FG.OPERATORNAME;
						ji.RECORDDATE = FG.RECORDDATE;
						ji.RECORDEDBY = FG.RECORDEDBY;
						ji.REJECTQTY = FG.REJECTQTY;
						ji.TOTALQTY = FG.TOTALQTY;
						ji.TOTALWEIGHT = FG.TOTALWEIGHT;

						_result = _om.SaveChanges();
					}

					scope.Complete();
				}
				catch (OptimisticConcurrencyException ex)
				{
					MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			} // end scope

			return _result;
		} // end UpdateFGItem
	}
}
