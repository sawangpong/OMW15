using OMW15.Controllers.ToolController;
using OMW15.Models.ServiceModel;
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
			lbTag.Text = StatCode;

			switch(StatCode)
			{
				case "SUM_WORKS":
					GetStatForServiceOrderByYear(fiscYear);
					break;

				case "ORDER_PIORITY":
					GetStatForActionPiorityServiceByYear(fiscYear);
					break;

				case "SUM_SERVICE_INCOME":
					GetServiceIncome(fiscYear);
					break;

				case "SUM_SPAREPART_INCOME":
					GetSparepartIncome(fiscYear);
					break;

				case "SUM_TOTAL_INCOME":
					GetTotalServiceIncome(fiscYear);
					break;

				case "COM_SERVICE_INCOME":
					GetComulatedServiceIncome(fiscYear);
					break;

				case "COM_SPAREPART_INCOME":
					GetComulatedSparepartIncome(fiscYear);
					break;

				case "COM_TOTAL_INCOME":
					GetComulatedIncome(fiscYear);
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

		//private async void getStatForServiceOrderByYear(int fiscYear)
		private void GetStatForServiceOrderByYear(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getServiceStat(fiscYear);
			//DataTable dt = new Models.ServiceModel.ServiceStat().getServiceStat(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();

		} // end getStatForServiceOrderByYear

		private void GetStatForActionPiorityServiceByYear(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getServiceActionStat(fiscYear);
			//DataTable dt = 
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();

		} // end getStatForActionServiceByYear


		private void GetTotalServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getTotalIncomeStat(fiscYear);
			//DataTable dt = new 
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach(DataGridViewColumn dgc in dgv.Columns)
			{
				if((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

		private void GetServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getServiceLaborIncomeStat(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

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


		private void GetSparepartIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getSparepartIncomeStat(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

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

		private void GetComulatedServiceIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().GetCommulatedServiceIncomeByServiceCode(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

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

		private void GetComulatedSparepartIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().GetCommulatedSparepartIncomeByServiceCode(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

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

		private void GetComulatedIncome(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().GetCommulatedIncomeStat(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

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

			// setting datagridview
			OMControls.OMUtils.SettingDataGridView(ref dgv);

			CenterToParent();
		}

		private void SrvStat_Load(object sender, EventArgs e)
		{
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
