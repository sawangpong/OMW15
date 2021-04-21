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

		#region Helper Methods

		private async void getProductionPartDemandAsync()
		{
			dgv.SuspendLayout();
			dgv.DataSource = await new BOMDal().GetTotalProductionRequirePartsAsync();
			dgv.DataSource = new BOMDal().GetTotalProductionRequireParts();

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
			dgv.SuspendLayout();
			dgv.DataSource = new BOMDal().GetTotalProductionRequireParts();

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


		#endregion



		public ProductionRequireParts()
		{
			InitializeComponent();
			OMUtils.SettingDataGridView(ref dgv);

		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ProductionRequireParts_Load(object sender, EventArgs e)
		{
			getProductionPartDemandAsync();
		}
	}
}
