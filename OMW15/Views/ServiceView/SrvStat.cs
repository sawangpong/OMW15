using OMW15.Controllers.ToolController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class SrvStat : Form
	{
		#region class field member

		private int selectStatYear = 0;
		private string selectedStatCode = "";
		#endregion

		#region class property

		#endregion

		#region class methods

		private void updateUI()
		{
		} // end updateUI

		private void getStatYear()
		{
			cbxYear.DataSource = new Models.ServiceModel.ServiceStat().getServiceStatYearList();
			cbxYear.DisplayMember = "Y";
			cbxYear.ValueMember = "Y";
			cbxYear.SelectedIndex = 0;
		}

		private void getStatType()
		{
			lstStatType.DataSource = new Models.ServiceModel.ServiceStat().getStatType();
			lstStatType.DisplayMember = "StatName";
			lstStatType.ValueMember = "StatCode";
		}


		private void loadStat(string StatCode, int fiscYear)
		{
			switch(StatCode)
			{
				case "SUM_WORKS":
					getStatForServiceOrderByYear(fiscYear);
					break;

				case "ORDER_PIORITY":
					getStatForActionServiceByYear(fiscYear);
					break;

				case "SUM_SERVICE_INCOME":
					getServiceIncome(fiscYear);
					break;

				case "SUM_SPAREPART_INCOME":
					getSparepartIncome(fiscYear);
					break;

				case "SUM_TOTAL_INCOME":
					getTotalServiceIncome(fiscYear);
					break;

				case "COM_SERVICE_INCOME":
					getComulatedServiceIncome(fiscYear);
					break;

				case "COM_SPAREPART_INCOME":
					getComulatedSparepartIncome(fiscYear);
					break;

				case "COM_TOTAL_INCOME":
					getComulatedIncome(fiscYear);
					break;

				case "SERVICE_INCOME_BY_CUSTOMER":
					getServiceIncomeByCustomer(fiscYear);
					break;

				case "SPARE_PART_INCOME_BY_CUSTOMER":
					getSparepartIncomeByCustomer(fiscYear);
					break;

				case "TOTAL_INCOME_BY_CUSTOMER":
					getTotalIncomeByCustomer(fiscYear);
					break;

				case "SUM_SERVICE_INCOME_BY_YEAR":
					getServiceIncomeByYear();
					break;

				case "SUM_SPAREPART_INCOME_BY_YEAR":
					getSparepartIncomeByYear();
					break;

				case "SUM_INCOME_BY_YEAR":
					getTotalIncomeByYear();
					break;


			}
		}

		private async void getStatForServiceOrderByYear(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getServiceStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getStatForServiceOrderByYear

		private async void getStatForActionServiceByYear(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getServiceActionStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getStatForActionServiceByYear


		private async void getTotalServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getTotalIncomeStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getTotalServiceIncome	

		private async void getSparepartIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getSparepartIncomeByCustomer(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomeByCustomer

		private async void getServiceIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getServiceIncomeByCustomer(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getServiceIncomeByCustomer

		private async void getTotalIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getTotalIncomeByCustomer(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getTotalIncomeByCustomer

		private async void getServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getServiceIncomeStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getServiceIncome


		private async void getSparepartIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getSparepartIncomeStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomev

		private async void getComulatedServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getCommulatedServiceIncomeByServiceCode(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomev

		private async void getComulatedSparepartIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getCommulatedSparepartIncomeByServiceCode(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getComulatedSparepartIncome

		private async void getComulatedIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getCommulatedIncomeStat(fiscYear);
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getComulatedIncome

		private async void getServiceIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getServiceIncomeByYear();
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if(dgc.Name != "Year")
					{
						dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
					}
				}
			}

			dgv.ResumeLayout();

		} // end getServiceIncomeByYear


		private async void getSparepartIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getSparepartIncomeByYear();
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if(dgc.Name != "Year")
					{
						dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
					}
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomeByYear


		private async void getTotalIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			DataTable dt = new Models.ServiceModel.ServiceStat().getTotalIncomeByYear();
			dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if(dgc.Name != "Year")
					{
						dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
					}
				}
			}

			dgv.ResumeLayout();

		} // end getTotalIncomeByYear


		#endregion

		public SrvStat()
		{
			InitializeComponent();

			CenterToParent();
		}

		private void SrvStat_Load(object sender, EventArgs e)
		{
			// setting datagridview
			OMControls.OMUtils.SettingDataGridView(ref dgv);

			// create stat year list
			getStatYear();

			getStatType();

		}

		private void cbxYear_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				selectStatYear = int.Parse(cbxYear.SelectedValue.ToString());
			}
			catch
			{
				selectStatYear = DateTime.Today.Year;
			}

			lbTitle.Text = $"{lstStatType.Text} - {selectStatYear}";

			if(selectedStatCode != "")
			{
				loadStat(selectedStatCode, selectStatYear);
			}
		}

		private void lstStatType_SelectedValueChanged(object sender, EventArgs e)
		{
			try
			{
				selectedStatCode = lstStatType.SelectedValue.ToString();
			}
			catch
			{
				selectedStatCode = "";
			}

			lbTitle.Text = $"{lstStatType.Text} - {selectStatYear}";

			if(selectedStatCode != "")
			{
				loadStat(selectedStatCode, selectStatYear);
			}
		}
	}
}
