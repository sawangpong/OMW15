using OMControls;
using OMW15.Models.SaleModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{

	public enum SaleGroups
	{
		ALL = 0,
		EXPORT = 1,
		LOCAL = 2
	}


	public partial class SaleSummary : Form
	{

		#region Singleton
		private static SaleSummary _instance;

		public static SaleSummary GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new SaleSummary();
				}
				return _instance;
			}
		}
		#endregion

		#region class field

		private int _saleGroup = (int)SaleGroups.ALL;
		private int _saleYear = DateTime.Today.Year;

		#endregion

		#region class properties

		#endregion

		#region class helper

		private void UpdateUI()
		{
			lbSaleGroup.Text = _saleGroup.ToString();

		}

		private void GetSaleGroups()
		{
			cbxSaleGroup.DataSource = OMDataUtils.GetValueList<SaleGroups>().ToDataTable();
			cbxSaleGroup.DisplayMember = "VALUE";
			cbxSaleGroup.ValueMember = "KEY";
		}

		private void GetYearSaleBySaleGroup(int saleGroup)
		{
			cbxSaleYear.DataSource = new SaleDAL().GetYearSaleByGroup(saleGroup);
			cbxSaleYear.DisplayMember = "YR";
			cbxSaleYear.ValueMember = "YR";

		}

		private void GetSaleSummary(int saleGroup, int saleYear)
		{
			dgv.DataSource = new SaleDAL().GetSaleSummaryByGroup(saleGroup, saleYear);
		}
		#endregion


		public SaleSummary()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);

			GetSaleGroups();
		}

		private void SaleSummary_Load(object sender, EventArgs e)
		{
			cbxSaleGroup.SelectedIndex = 0;
			_saleGroup = Convert.ToInt32(cbxSaleGroup.SelectedValue.ToString());
			GetYearSaleBySaleGroup(_saleGroup);

		}

		private void cbxSaleGroup_SelectedIndexChanged(object sender, EventArgs e)
		{
			_saleGroup = Convert.ToInt32(cbxSaleGroup.SelectedValue.ToString());

			GetYearSaleBySaleGroup(_saleGroup);
			UpdateUI();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			GetSaleSummary(_saleGroup, _saleYear);
		}

		private void cbxSaleYear_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_saleYear = Convert.ToInt32(cbxSaleYear.SelectedValue.ToString());
			lbYR.Text = _saleYear.ToString();
		}
	}
}
