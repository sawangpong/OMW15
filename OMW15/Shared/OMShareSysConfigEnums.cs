namespace OMW15.Shared
{
	public class OMShareSysConfigEnums
	{
		public enum UserPermission
		{
			None = 0,
			User = 1,
			PowerUser = 2,
			Accounting = 3,
			Admin = 4,
			Manager = 5,
			AccountManager = 6,
			SuperAdmin = 9
		}

		// used this enumerate for classify the group 
		// of work of each department for workGroup
		public enum WorkGroups
		{
			None,
			Accounting,
			Adminsupport,
			Casting,
			ICT,
			Production,
			Purchasing,
			Services,
			Sales,
			Warehouse,
			Management,
			SystemAdmin
		}
	}
}