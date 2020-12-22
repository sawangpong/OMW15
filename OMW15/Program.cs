using OMW15.Models.ToolModel;
using OMW15.Shared;
using OMW15.Views.ToolViews;
using System;
using System.Windows.Forms;

namespace OMW15
{
	public class Program
	{
		// field
		private static CompanyProfileModel _profile;

		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			startup();

			if (omglobal.UserLogId > 0)
			{
				Application.Run(new OW15());
			}
		}

		private static void startup() => omglobal.UserLogId = GetUserLogin();


		private static int GetUserLogin()
		{
			int _id = 0;
			// start user logging
			using (var _login = new UserLogin())
			{
				_login.StartPosition = FormStartPosition.CenterScreen;
				_login.ShowDialog();

				if(_login.UserId > 0)
				{
					_id = _login.UserId;
				}
			} 

			// after received user id from the system
			// must loading company-profile for update the necessary variable
			if (_id > 0)
			{
				// create company profile object
				_profile = new CompanyProfileModel();

				if (_profile.CheckCompanyProfile(omglobal.COMPANY_ID) == false)
				{
					GetCompanyProfile(omglobal.COMPANY_ID);
				}
			}

			return _id;
		} // end GetUserLogin

		private static void GetCompanyProfile(string CompanyId)
		{
			// create Company profile
			var _companyprofile = new CompanyProfile();
			_companyprofile.Mode = ActionMode.Add;
			_companyprofile.CompanyId = CompanyId;
			_companyprofile.StartPosition = FormStartPosition.CenterScreen;
			_companyprofile.ShowDialog();

			var _profile = new CompanyProfileModel();

			_profile.ReadCurrentCompanyProfile(CompanyId);

		} // end GetCompanyProfile
	}
}