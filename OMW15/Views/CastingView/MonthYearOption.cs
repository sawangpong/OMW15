using System;
using System.ComponentModel;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers.ToolController;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class MonthYearOption : Form
	{
		#region class field member

		public enum MonthYearOptionScope
		{
			None,
			DeliveryMaterial,
			ReturnMaterial,
			CastingMonthlyReport,
			CastingDeliveryReport,
			CastingSaleMaterialReport,
			SIReport
		}

		#endregion

		// CONSTRUCTOR
		public MonthYearOption()
		{
			InitializeComponent();
		}

		private void MonthYearOption_Load(object sender, EventArgs e)
		{
			CenterToParent();
			gb.Text = Title;
			lbOption.Text = MaterialCategory;
			GetYearList(MaterialCategory);

			UpdateUI();
		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				SelectedYear = Convert.ToInt32(cbxYear.SelectedValue);
			}
			catch
			{
			}

			GetMonthList(MaterialCategory, SelectedYear);
		}

		private void cbxMonth_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				SelectedMonth = Convert.ToInt32(cbxMonth.SelectedValue);
			}
			catch
			{
			}
		}

		#region class property

		[DefaultValue(MonthYearOptionScope.None)]
		public MonthYearOptionScope Option { get; set; }

		[DefaultValue("")]
		public string MaterialCategory { get; set; }


		//[DefaultValue(DateTime.Today.Year) ]
		public int SelectedYear { get; set; }

		//[DefaultValue(DateTime.Today.Month)]
		public int SelectedMonth { get; set; }

		[DefaultValue("Year & Month")]
		public string Title { get; set; }

		#endregion

		#region class helper

		private void UpdateUI()
		{
			pnlMaterialCategory.Visible = Option != MonthYearOptionScope.None;
		} // end UpdateUI


		private void CheckOptionScope()
		{
			switch (Option)
			{
				case MonthYearOptionScope.DeliveryMaterial:
					break;
				case MonthYearOptionScope.ReturnMaterial:
					break;
			}
		} // end CheckOptionScope

		private void GetYearList(string MaterialCategory)
		{
			switch (Option)
			{
				case MonthYearOptionScope.DeliveryMaterial:
					cbxYear.DataSource = new ReturnMaterialDAL().GetMaterialDeliveryYear(MaterialCategory);
					cbxYear.DisplayMember = "Y";
					cbxYear.ValueMember = "Y";
					break;
				case MonthYearOptionScope.ReturnMaterial:
					cbxYear.DataSource = new ReturnMaterialDAL().GetMaterialReciveYear(MaterialCategory);
					cbxYear.DisplayMember = "Y";
					cbxYear.ValueMember = "Y";
					break;

				default:
					cbxYear.DataSource = DataTableTools.GetGeneralYearList();
					cbxYear.DisplayMember = "Y";
					cbxYear.ValueMember = "Y";
					break;
			}
		} // end GetYearList

		private void GetMonthList(string MaterialCategory, int SelectedYear)
		{
			switch (Option)
			{
				case MonthYearOptionScope.DeliveryMaterial:
					cbxMonth.DataSource = new ReturnMaterialDAL().GetMaterialDeliveryMonth(MaterialCategory, SelectedYear);
					cbxMonth.DisplayMember = "MName";
					cbxMonth.ValueMember = "M";
					break;
				case MonthYearOptionScope.ReturnMaterial:
					cbxMonth.DataSource = new ReturnMaterialDAL().GetMaterialReciveMonth(MaterialCategory, SelectedYear);
					cbxMonth.DisplayMember = "MName";
					cbxMonth.ValueMember = "M";
					break;

				default:
					cbxMonth.DataSource = EnumWithName<MonthList>.ParseEnum();
					cbxMonth.DisplayMember = "Name";
					cbxMonth.ValueMember = "Value";
					cbxMonth.SelectedValue = DateTime.Today.Month;
					break;
			}
		} // end GetMonthList

		#endregion
	}
}