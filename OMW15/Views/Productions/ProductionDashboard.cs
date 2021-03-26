using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace OMW15.Views.Productions
{
	public partial class ProductionDashboard : Form
	{
		#region Singleton
		private static ProductionDashboard _instance;
		public static ProductionDashboard GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionDashboard();
				}
				return _instance;
			}
		}

		#endregion


		#region class field

		private bool _isUpdate = false;
		private SqlTableDependency<PRODUCTIONJOBINFO> dep;


		#endregion


		#region class helper

		private void UpdateData1()
		{
			DataTable _dt = new ProductionDashboardDAL().GetProductionJobInfoDataChanged();
			decimal _q1 = 0m;
			decimal _q2 = 0m;

			//lbG1Unit.Text = $"ชิ้น";
			//lbMachineGroup1.Text = $"งานตัด";

			foreach (DataRow dr in _dt.Rows)
			{
				switch(Convert.ToInt32(dr["MACHINE_GROUP"].ToString()))
				{
					case 1:
						_q1 += Convert.ToDecimal(dr["Q_REMAIN"].ToString());
						lbMachineGroup1.Text = $"{dr["MC_GROUPNAME"].ToString()}";
						lbG1Unit.Text = $"{dr["UNITORDER"].ToString()}";
						break;
					case 2:
						_q2 += Convert.ToDecimal(dr["Q_REMAIN"].ToString());
						lbMachineGroup2.Text = $"{dr["MC_GROUPNAME"].ToString()}";
						lbG2Unit.Text = $"{dr["UNITORDER"].ToString()}";
						break;
				}
			}

			lbQG1.Text = $"{_q1:N0}";
			lbQG2.Text = $"{_q2:N0}";
		}


		#endregion


		public ProductionDashboard()
		{
			InitializeComponent();
		}

		private void ProductionDashboard_Load(object sender, System.EventArgs e)
		{
			UpdateData1();
			dep = new SqlTableDependency<PRODUCTIONJOBINFO>(omglobal.SysConnectionString, "PRODUCTIONJOBINFO");
			dep.OnChanged += Changed;
			dep.Start();

		}

		private void Changed(object sender, RecordChangedEventArgs<PRODUCTIONJOBINFO> e)
		{
			var changedEntity = e.Entity;

			_isUpdate = true;

			if (_isUpdate)
			{
				UpdateData1();
			}

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			dep.Stop();
			this.Close();
		}
	}
}
