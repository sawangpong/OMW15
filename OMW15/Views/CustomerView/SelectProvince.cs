using System;
using System.Windows.Forms;
using OMW15.Models.EmployeeModel;
using OMW15.Shared;

namespace OMW15.Views.CustomerView
{
	public partial class SelectProvince : Form
	{
		#region class field member

		private readonly OMShareCustomerEnums.AddressSource _source =
			OMShareCustomerEnums.AddressSource.ProvinceCurrentAddress;

		#endregion

		public SelectProvince(OMShareCustomerEnums.AddressSource SourceProvice)
		{
			InitializeComponent();
			CenterToScreen();

			_source = SourceProvice;
		}

		#region class property

		public string SelectedResut { get; set; }

		#endregion

		#region class helper

		private void GetProvinceBySource(OMShareCustomerEnums.AddressSource Source)
		{
			switch (Source)
			{
				case OMShareCustomerEnums.AddressSource.ProvinceCurrentAddress:
					lstProvince.DataSource = new EmployeeDAL().GetCurrentProvice();
					break;

				case OMShareCustomerEnums.AddressSource.ProvinceFromCardId:
					lstProvince.DataSource = new EmployeeDAL().GetCardProvice();
					break;

				case OMShareCustomerEnums.AddressSource.CountryCurrentAddress:
					lstProvince.DataSource = new EmployeeDAL().GetCurrentCountry();
					break;

				case OMShareCustomerEnums.AddressSource.CountryFromCardId:
					lstProvince.DataSource = new EmployeeDAL().GetCardCountry();
					break;
			}

			lstProvince.DisplayMember = "VALUE";
			lstProvince.ValueMember = "KEY";
		}

		#endregion

		private void SelectProvince_Load(object sender, EventArgs e)
		{
			switch (_source)
			{
				case OMShareCustomerEnums.AddressSource.ProvinceCurrentAddress:
					Text = "CURRENT ADDRESS PROVICE";
					break;
				case OMShareCustomerEnums.AddressSource.ProvinceFromCardId:
					Text = "CARD ID PROVICE";
					break;
				case OMShareCustomerEnums.AddressSource.CountryCurrentAddress:
					Text = "CURRENT ADDRESS COUNTRY";
					break;
				case OMShareCustomerEnums.AddressSource.CountryFromCardId:
					Text = "CARD ID COUNTRY";
					break;
			}

			GetProvinceBySource(_source);
		}

		private void lstProvince_SelectedValueChanged(object sender, EventArgs e)
		{
			if (lstProvince.SelectedValue.GetType() == typeof(string))
				SelectedResut = lstProvince.SelectedValue.ToString();
			else
				SelectedResut = string.Empty;
		}
	}
}