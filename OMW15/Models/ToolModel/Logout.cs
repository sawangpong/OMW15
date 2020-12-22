using System;
using System.Linq;
using System.Transactions;

namespace OMW15.Models.ToolModel
{
	public class Logout
	{
		private readonly OLDMOONEF1 _om;

		#region constructor

		public Logout()
		{
			_om = new OLDMOONEF1();
		}

		#endregion

		public bool UpdateUserLogoutTime(int UserId, DateTime LogoutTime)
		{
			var _logoutSuccess = false;
			using (var _scope = new TransactionScope())
			{
				try
				{
					var _ul = (from u in _om.USERLOGs
						where u.USERID == UserId
						select u).Single();

					_ul.LOGOUTDT = LogoutTime;
					_om.SaveChanges();
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
	}
}