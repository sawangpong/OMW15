using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ProductionModel;
using WPFControls.Views;

namespace OMW15.Views.Productions
{
	public partial class ProductionRequireParts : Form
	{
		#region Singleton
		private static ProductionRequireParts _instance;
		public static ProductionRequireParts GetInstance
		{
			get {
				if(_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionRequireParts();
				}
				return _instance;
			}
		}
		#endregion

		#region fields

		private string _selectedPartNo = string.Empty;

		#endregion

		#region Helper Methods

		private async void getProductionPartDemandAsync()
		{
			DataTable _dt = await new BOMDal().GetTotalProductionRequirePartsAsync();
			tslbCount.Text = $"found:{_dt.Rows.Count}";

			dgv.SuspendLayout();
			dgv.Invoke(new MethodInvoker(() => dgv.DataSource = _dt));

			// dgv.LoadData(omglobal.SysConnectionString, $"EXEC dbo.usp_PRODUCTION_DEMAND_PARTS", false);
			// dgv.DataSource = _dt;
			// dgv.DataSource = new BOMDal().GetTotalProductionRequireParts();

			dgv.Columns["PART_ID"].Visible = false;

			dgv.Columns["ON_HAND"].HeaderText = "จำนวนคงคลัง";
			dgv.Columns["ON_HAND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["ON_HAND"].DefaultCellStyle.Format = "N2";
			dgv.Columns["ON_HAND"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			dgv.Columns["ON_HAND"].DefaultCellStyle.ForeColor = Color.DarkBlue;

			dgv.Columns["TOTAL_DEMAND"].HeaderText = "จำนวนที่ต้องการทั้งหมด";
			dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Format = "N2";
			dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);

			dgv.Columns["AVAILABLE"].HeaderText = "จำนวนที่ใช้ได้";
			dgv.Columns["AVAILABLE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["AVAILABLE"].DefaultCellStyle.Format = "N2";
			dgv.Columns["AVAILABLE"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			dgv.Columns["AVAILABLE"].DefaultCellStyle.ForeColor = Color.Red;

			dgv.Columns["ON_PRODUCE"].HeaderText = "จำนวนระหว่างผลิต";
			dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Format = "N2";
			dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			dgv.Columns["ON_PRODUCE"].DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;

			dgv.Columns["ON_PO"].HeaderText = "จำนวนที่สั่งซื้อ";
			dgv.Columns["ON_PO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.Columns["ON_PO"].DefaultCellStyle.Format = "N2";
			dgv.Columns["ON_PO"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			dgv.Columns["ON_PO"].DefaultCellStyle.ForeColor = SystemColors.ActiveCaption;

			dgv.Columns["PART NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.ResumeLayout();
		}

		private void getProductionPartDemand()
		{
			//DataTable _dt = new BOMDal().GetTotalProductionRequireParts();
			//dgv.Invoke(new MethodInvoker(() => dgv.DataSource = _dt));

			dgv.VirtualMode = true;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			dgv.SuspendLayout();
			dgv.LoadData(omglobal.SysConnectionString, $"EXEC dbo.usp_PRODUCTION_DEMAND_PARTS", false);

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			dgv.ResumeLayout(false);
	
			//dgv.ResumeLayout();

		}

		private void SettingColumnsStyle()
		{
			//dgv.Columns

			dgv.Columns["PART_ID"].Visible = false;

			dgv.Columns["ON_HAND"].HeaderText = "จำนวนคงคลัง";
			//dgv.Columns["ON_HAND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["ON_HAND"].DefaultCellStyle.Format = "N2";
			//dgv.Columns["ON_HAND"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			//dgv.Columns["ON_HAND"].DefaultCellStyle.ForeColor = Color.DarkBlue;
			//dgv.Columns["TOTAL_DEMAND"].HeaderText = "จำนวนที่ต้องการทั้งหมด";
			//dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Format = "N2";
			//dgv.Columns["TOTAL_DEMAND"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);

			dgv.Columns["AVAILABLE"].HeaderText = "จำนวนที่ใช้ได้";
			//dgv.Columns["AVAILABLE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["AVAILABLE"].DefaultCellStyle.Format = "N2";
			//dgv.Columns["AVAILABLE"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			//dgv.Columns["AVAILABLE"].DefaultCellStyle.ForeColor = Color.Red;

			dgv.Columns["ON_PRODUCE"].HeaderText = "จำนวนระหว่างผลิต";
			//dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Format = "N2";
			//dgv.Columns["ON_PRODUCE"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			//dgv.Columns["ON_PRODUCE"].DefaultCellStyle.ForeColor = SystemColors.ControlDarkDark;

			dgv.Columns["ON_PO"].HeaderText = "จำนวนที่สั่งซื้อ";
			//dgv.Columns["ON_PO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			//dgv.Columns["ON_PO"].DefaultCellStyle.Format = "N2";
			//dgv.Columns["ON_PO"].DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
			//dgv.Columns["ON_PO"].DefaultCellStyle.ForeColor = SystemColors.ActiveCaption;

			//dgv.Columns["PART NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		private void UpdateUI()
		{
			tsbtnViewParentOrder.Enabled = !String.IsNullOrEmpty(_selectedPartNo);
		}

		private void ViewOrderTracking(string partno)
		{
			TrackProductionOrder _trackOrder = new TrackProductionOrder();
			_trackOrder.StartPosition = FormStartPosition.CenterScreen;
			_trackOrder.PartNo = partno;
			_trackOrder.MdiParent = this.ParentForm;
			_trackOrder.Show();
		}


		#endregion

		public ProductionRequireParts()
		{
			InitializeComponent();
			OMUtils.SettingProgressDataGridView(ref dgv);

			_selectedPartNo = string.Empty;	


			dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ProductionRequireParts_Load(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void tsbtnCalParts_Click(object sender, EventArgs e)
		{
			//_selectedPartNo = string.Empty;
			//tslbCount.Text = $"found:0";
			//getProductionPartDemand();
			//tslbCount.Text = $"found:{dgv.Rows.Count}";

			DemandPart demandPart = new DemandPart();
			demandPart.ConnectionString = omglobal.SysConnectionString;
			elementHost1.Child = demandPart;


			UpdateUI();
		}

		private void tsbtnViewParentOrder_Click(object sender, EventArgs e)
		{
			//ViewOrderTracking(_selectedPartNo);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			//_selectedPartNo = dgv["PART NO.", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			//ViewOrderTracking(_selectedPartNo);
		}
	}
}
