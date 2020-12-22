using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Master.MasterView
{
	public partial class SelectProvince : Form
	{
		#region class field member

		private AddressSource _source = AddressSource.ProvinceCurrentAddress;


		#endregion

		#region class property

		public string SelectedResut
		{
			get;
			set;
		}


		#endregion

		#region class helper

		private void GetProvinceBySource(AddressSource Source)
		{
			switch (Source)
			{
				case AddressSource.ProvinceCurrentAddress:
					this.lstProvince.DataSource = new Master.MasterController.EmployeeDAL().GetCurrentProvice();
					break;

				case AddressSource.ProvinceFromCardId:
					this.lstProvince.DataSource = new Master.MasterController.EmployeeDAL().GetCardProvice();
					break;

				case AddressSource.CountryCurrentAddress:
					this.lstProvince.DataSource = new Master.MasterController.EmployeeDAL().GetCurrentCountry();
					break;

				case AddressSource.CountryFromCardId:
					this.lstProvince.DataSource = new Master.MasterController.EmployeeDAL().GetCardCountry();
					break;
			}

			this.lstProvince.DisplayMember = "VALUE";
			this.lstProvince.ValueMember = "KEY";
		}

		#endregion

		public SelectProvince(AddressSource SourceProvice)
		{
			InitializeComponent();
			_source = SourceProvice;

		}

		private void SelectProvince_Load(object sender, EventArgs e)
		{
			switch (_source)
			{
				case AddressSource.ProvinceCurrentAddress:
					this.Text = "CURRENT ADDRESS PROVICE";
					break;
				case AddressSource.ProvinceFromCardId:
					this.Text = "CARD ID PROVICE";
					break;
				case AddressSource.CountryCurrentAddress:
					this.Text = "CURRENT ADDRESS COUNTRY";
					break;
				case AddressSource.CountryFromCardId:
					this.Text = "CARD ID COUNTRY";
					break;
			}

			this.GetProvinceBySource(_source);

		}

		private void lstProvince_SelectedValueChanged(object sender, EventArgs e)
		{
			if (this.lstProvince.SelectedValue.GetType() == typeof(System.String))
			{
				this.SelectedResut = this.lstProvince.SelectedValue.ToString();
			}
			else
			{
				this.SelectedResut = string.Empty;
			}
		}
	}
}
