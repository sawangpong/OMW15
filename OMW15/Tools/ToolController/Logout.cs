using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Transactions;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Tools.Controller
{
	public class Logout
	{
		public static bool UpdateUserLogoutTime(int UserId,DateTime LogoutTime)
		{
			bool _logoutSuccess = false;
			using(System.Transactions.TransactionScope _scope = new TransactionScope())
			{
				OLDMOONEF _oldmoon = new OLDMOONEF();
				try
				{

					var _ul = (from u in _oldmoon.USERLOGs
							   where u.USERID == UserId
							   select u).FirstOrDefault();

					_ul.LOGOUTDT = LogoutTime;
					_oldmoon.SaveChanges();
					_scope.Complete();
					_logoutSuccess = true;
				}
				catch
				{
					_logoutSuccess = false;
				}
			}

			return _logoutSuccess;

		} // end UpdateUserLogoutTime

		public Logout()
		{
			
		}
	}
}
