using OMW15.Models.ProductionModel;
using System;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class MissReportInfo : Form
	{
		#region Singleton
		private static MissReportInfo _instance;
		public static MissReportInfo GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new MissReportInfo();
				}
				return _instance;
			}
		}
		#endregion

		#region class field
		private string _selectedEmpId = string.Empty;
		private DateTime _selectedMissingDate = DateTime.Today.Date;
		#endregion


		#region class helper
		private void UpdateUI()
		{
			btnTimeRecode.Enabled = !string.IsNullOrEmpty(_selectedEmpId);
		}

		private void GetMissReportList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ProductionDAL().GetProductionMissReport();
			dgv.Columns["EMPCODE"].Visible = false;
			dgv.Columns["fname"].HeaderText = "ชื่อพนักงาน";
			dgv.Columns["fname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgv.Columns["nday"].HeaderText = "จำนวนวัน";
			dgv.Columns["nday"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			dgv.ResumeLayout();
		
		}

		private void GetMissReportInfoList(string empId)
		{
			dgvInfo.SuspendLayout();
			dgvInfo.DataSource = new ProductionDAL().GetProductionMissReportDetails(empId);
			dgvInfo.Columns["EMPCODE"].Visible = false;
			dgvInfo.Columns["fname"].HeaderText = "ชื่อพนักงาน";
			dgvInfo.Columns["fname"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			dgvInfo.Columns["MISS_DATE"].HeaderText = "วันที่ไม่ลงรายงาน";
			dgvInfo.Columns["MISS_DATE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dgvInfo.ResumeLayout();
		}

		#endregion

		public MissReportInfo()
		{
			InitializeComponent();

			OMControls.OMUtils.SettingDataGridView(ref dgv);
			OMControls.OMUtils.SettingDataGridView(ref dgvInfo);

		}

		private void btnReload_Click(object sender, System.EventArgs e)
		{
			GetMissReportList();
		}

		private void MissReportInfo_Load(object sender, System.EventArgs e)
		{
			GetMissReportList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedEmpId = dgv["EMPCODE", e.RowIndex].Value.ToString();
				if (!string.IsNullOrEmpty(_selectedEmpId))
				{
					GetMissReportInfoList(_selectedEmpId);
				}
			}
			catch { }
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnTimeRecode_Click(object sender, System.EventArgs e)
		{
			PDTimeRecord timeRecord = new PDTimeRecord();
			timeRecord.Empcode = _selectedEmpId;
			timeRecord.MissingDate = _selectedMissingDate;
			timeRecord.StartPosition = FormStartPosition.CenterScreen;
			timeRecord.MdiParent = this.ParentForm;
			timeRecord.Show();
		}

		private void dgvInfo_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedMissingDate = Convert.ToDateTime(dgvInfo["MISS_DATE",e.RowIndex].Value);

			UpdateUI();

		}
	}
}
