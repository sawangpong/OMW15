using System;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;

namespace OMW15.Models.ToolModel
{
	public class LoginDAL
	{
		private readonly OLDMOONEF1 _om;

		public LoginDAL() => _om = new OLDMOONEF1();

		public LOGIN GetCurrentUserInformation(string UserName, string UserPassword)
		{
			return _om.LOGINs.FirstOrDefault(x => x.uname == UserName && x.password == UserPassword);
		} // end GetCurrentUserInformation

		public LOGIN CheckValidUserName(string userName)
		{
			var _login = _om.LOGINs.Find(userName);

			if (_login != null)
				return _login;
			
			return _login = null;
		}

		public int GetNewUserId(USERLOG UserInfo)
		{
			var _result = 0;
			try
			{
				_om.USERLOGs.Add(UserInfo);
				_om.SaveChanges();
				_result = _om.USERLOGs.Max(x => x.USERID);
			}
			catch (OptimisticConcurrencyException ex)
			{
				throw new Exception("ไม่สามารถลงชื่อเข้าใช้งานระบบได้....", ex);
			}

			return _result;
		}

		public DataTable GetMemberList()
		{
			var members = (from u in _om.LOGINs.AsEnumerable()
								select new
								{
									Active = u.islock ? "N" : "Y",
									u.id,
									UserName = u.uname,
									Password = u.password,
									PermisionId = u.permissionid,
									Class = u.auditclass,
									Group = Enum.GetName(typeof(Shared.OMShareSysConfigEnums.WorkGroups), u.DepartmentID.Value)
								}).OrderBy(o => o.Active).ThenBy(o => o.UserName);

			if (members != null) return members.ToDataTable();
			
			return null;
		}
	}
}