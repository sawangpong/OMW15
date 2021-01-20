using System;
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

			switch (StatCode)
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
					GetServiceIncomeByCustomer(fiscYear);
					break;

				case "SPARE_PART_INCOME_BY_CUSTOMER":
					GetSparepartIncomeByCustomer(fiscYear);
					break;

				case "TOTAL_INCOME_BY_CUSTOMER":
					GetTotalIncomeByCustomer(fiscYear);
					break;

				case "SUM_SERVICE_INCOME_BY_YEAR":
					GetServiceIncomeByYear();
					break;

				case "SUM_SPAREPART_INCOME_BY_YEAR":
					GetSparepartIncomeByYear();
					break;

				case "SUM_INCOME_BY_YEAR":
					GetTotalIncomeByYear();
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}
			dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.ResumeLayout();

		} // end getTotalServiceIncome	

		private void GetSparepartIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getSparepartIncomeByCustomer(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomeByCustomer

		private void GetServiceIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getServiceIncomeByCustomer(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getServiceIncomeByCustomer

		private void GetTotalIncomeByCustomer(int fiscYear)
		{
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getTotalIncomeByCustomer(fiscYear);
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
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
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
				}
			}

			dgv.ResumeLayout();

		} // end getComulatedIncome

		private void GetServiceIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getServiceIncomeByYear();
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if (dgc.Name != "Year")
					{
						dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
					}
				}
			}

			dgv.ResumeLayout();

		} // end getServiceIncomeByYear


		private void GetSparepartIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getSparepartIncomeByYear();
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if (dgc.Name != "Year")
					{
						dgc.DefaultCellStyle = Controllers.ToolController.DataGridViewSettingStyle.GeneralNumericCellStyle();
					}
				}
			}

			dgv.ResumeLayout();

		} // end getSparepartIncomeByYear


		private void GetTotalIncomeByYear()
		{
			lbTitle.Text = $"{lstStatType.Text}";
			dgv.SuspendLayout();
			dgv.DataSource = null;
			dgv.DataSource = new Models.ServiceModel.ServiceStat().getTotalIncomeByYear();
			//dgv.DataSource = await DataTableTools.AsyncAddRollup(dt);

			// formatting column 
			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if ((dgc.ValueType == typeof(System.Int32))
					|| (dgc.ValueType == typeof(System.Decimal)))
				{
					if (dgc.Name != "Year")
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

			if (selectedStatCode != "")
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

			if (selectedStatCode != "")
			{
				loadStat(selectedStatCode, selectStatYear);
			}
		}
	}
}
