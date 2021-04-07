using OMW15.Models.ProductionModel;
using OMW15.Views.Productions.ProductionUserControl;
using System;
using System.Collections.Generic;
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
		private SqlTableDependency<PRODUCTIONJOBINFO> _notifier;
		private string _isState = string.Empty;
		private DataTable _data;

		#endregion


		#region class helper

		private void UpdatePanelData()
		{
			_data = new ProductionDashboardDAL().GetProductionJobInfoDataChanged();
			foreach (Control c in flp.Controls)
			{
				UpdatePanel p = (UpdatePanel)c;

				foreach (DataRow dr in _data.Rows)
				{
					if (Convert.ToInt32(p.Tag) == Convert.ToInt32(dr["MACHINE_GROUP"].ToString()))
					{

						p.TotalQty = Convert.ToDecimal(dr["REMAINQTY"].ToString());
						p.HourNeed = Convert.ToDecimal(dr["HOUR_NEED"].ToString());
						break;
					}
				}
			}
		}

		private void GetMachineGroup()
		{
			DataTable dtGroup = new ProductionMachineDAL().GetMachineGroup();
			List<Control> _panels = new List<Control>();

			foreach (DataRow dr in dtGroup.Rows)
			{
				var pnl = new UpdatePanel();
				pnl.Title = dr["MC_GROUPNAME"].ToString();
				pnl.Tag = dr["MC_GROUPID"].ToString();
				_panels.Add((Control)pnl);
			}

			flp.Controls.AddRange(_panels.ToArray());

			UpdatePanelData();
		}

		private void GetWorkerMissReport()
		{
			var _missReport = new MissReportControl();
			flp.Controls.Add((Control)_missReport);
		}

		#endregion

		public ProductionDashboard()
		{
			InitializeComponent();
		}

		private void ProductionDashboard_Load(object sender, System.EventArgs e)
		{
			_notifier = new SqlTableDependency<PRODUCTIONJOBINFO>(omglobal.SysConnectionString, "PRODUCTIONJOBINFO");
			_notifier.OnChanged += Changed;
			_notifier.Start();
			GetMachineGroup();
			//GetWorkerMissReport();
		}

		private void Changed(object sender, RecordChangedEventArgs<PRODUCTIONJOBINFO> e) => UpdatePanelData();

		private void btnClose_Click(object sender, EventArgs e)
		{
			_notifier.Stop();
			this.Close();
		}
	}
}
