using OMW15.Models.ProductionModel;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class TrackProductionOrder : Form
	{
		#region Singleton
		//private static TrackProductionOrder _instance;
		//public static TrackProductionOrder GetInstance
		//{
		//	get
		//	{
		//		if(_instance == null || _instance.IsDisposed)
		//		{
		//			_instance = new TrackProductionOrder();
		//		}
		//		return _instance;
		//	}
		//}

		#endregion

		#region class property
		private string _partNo = string.Empty;

		public string PartNo
		{
			get
			{
				return _partNo;
			}
			set
			{
				_partNo = value;
				this.lbTitle.Text = value;
				this.Invalidate();
			}
		}

		#endregion

		#region class helper

		private void UpdateUI()
		{

		}

		private void LoadTrackingOrderByPartNo(string partno)
		{
			DataTable _dt = new BOMDal().GetTrackingProductionOrder(partno);

			dgv.SuspendLayout();
			dgv.DataSource = _dt;

			dgv.Columns["ORDER_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["ORDER_QTY"].DefaultCellStyle.Format = "N2";
			dgv.Columns["ORDER_QTY"].DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
			dgv.Columns["ORDER_QTY"].DefaultCellStyle.ForeColor = Color.DarkBlue;

			dgv.Columns["BOM_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["BOM_QTY"].DefaultCellStyle.Format = "N2";
			dgv.Columns["BOM_QTY"].DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
			dgv.Columns["BOM_QTY"].DefaultCellStyle.ForeColor = Color.DarkGreen;

			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.Format = "N2";
			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
			dgv.Columns["DEMAND_QTY"].DefaultCellStyle.ForeColor = Color.DarkOrange;

			dgv.ResumeLayout();
		}

		#endregion

		public TrackProductionOrder()
		{
			InitializeComponent();
			OMControls.OMUtils.SettingDataGridView(ref dgv);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TrackProductionOrder_Load(object sender, EventArgs e)
		{
			LoadTrackingOrderByPartNo(_partNo);
		}
	}
}
