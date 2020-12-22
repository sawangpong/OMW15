using OMControls;
using OMW15.Models.ServiceModel;
using OMW15.Shared;
using System;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class ServiceEngineers : Form
	{

		#region class field member

		private readonly OMShareServiceEnums.EngineerViewState _viewMode = OMShareServiceEnums.EngineerViewState.Normal;
		private int _selectedEngineerId;
		private int _selectedEngineerStatus = (int)OMShareServiceEnums.EngineerStatusEnum.All;

		#endregion

		#region class property

		public string EngineerName { get; set; }

		public string EngineerCode { get; set; }

		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			tsbtnEditEngineer.Enabled = _selectedEngineerId > 0;
			pnlRight.Visible = _viewMode == OMShareServiceEnums.EngineerViewState.Select;

			tsbtnClose.Visible = !pnlRight.Visible;
			tsbtnAddEngineer.Visible = tsbtnClose.Visible;
			tsbtnEditEngineer.Visible = tsbtnClose.Visible;
			tsSep1.Visible = tsbtnClose.Visible;
			tsSep2.Visible = tsbtnClose.Visible;
			tsSep3.Visible = tsbtnClose.Visible;

			pnlCommand.Visible = ts.Visible;

			btnSelect.Enabled = !string.IsNullOrEmpty(EngineerCode);
		} // end UpdateUI

		private void GetEngineerList(int EngineerStatus)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ServiceJobDAL().GetSeviceEngineerList(EngineerStatus);

			dgv.Columns["ENGISEQ"].Visible = false;
			dgv.Columns["STATUSID"].Visible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();
			lbCount.Text = string.Format("found : {0} records", dgv.Rows.Count);
			UpdateUI();
		} // end GetEngineerList

		private void GetEngineerInfo(int Id)
		{
			using (var _engInfo = new ServiceEngineerInfo(Id))
			{
				_engInfo.StartPosition = FormStartPosition.CenterScreen;
				if (_engInfo.ShowDialog(this) == DialogResult.OK)
					MessageBox.Show("Update successfully");
			}

			tsbtnRefresh.PerformClick();
		} // end GetEngineerInfo


		private void GetEngineerStatusList()
		{
			tscbxEngStatus.ComboBox.DataSource = EnumWithName< OMShareServiceEnums.EngineerStatusEnum>.ParseEnum();
			tscbxEngStatus.ComboBox.DisplayMember = "Name";
			tscbxEngStatus.ComboBox.ValueMember = "Value";
			tscbxEngStatus.ComboBox.SelectedValue = _selectedEngineerStatus;
		}

		#endregion


		// CONSTRUCTOR
		public ServiceEngineers(OMShareServiceEnums.EngineerViewState ViewMode)
		{
			InitializeComponent();
			_viewMode = ViewMode;

			// setting DataGridView
			OMUtils.SettingDataGridView(ref dgv); WindowState = FormWindowState.Normal;
		}

		private void ServiceEngineers_Load(object sender, EventArgs e)
		{
			GetEngineerStatusList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// used for viewstate = "Normal"
			_selectedEngineerId = Convert.ToInt32(dgv["ENGISEQ", e.RowIndex].Value);

			// used for viewstate = "Select"
			EngineerCode = dgv["ID", e.RowIndex].Value.ToString();
			EngineerName = dgv["ENGINEER", e.RowIndex].Value.ToString();

			// debug
			lbSEQ.Text = $"idx:{_selectedEngineerId}";
			// end debug

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnEditEngineer_Click(object sender, EventArgs e)
		{
			GetEngineerInfo(_selectedEngineerId);
		}

		private void tsbtnAddEngineer_Click(object sender, EventArgs e)
		{
			_selectedEngineerId = 0;
			GetEngineerInfo(_selectedEngineerId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetEngineerList(_selectedEngineerStatus);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			switch (_viewMode)
			{
				case OMShareServiceEnums.EngineerViewState.Normal:
					tsbtnEditEngineer.PerformClick();
					break;

				case OMShareServiceEnums.EngineerViewState.Select:
					btnSelect.PerformClick();
					break;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tscbxEngStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedEngineerStatus = (int)tscbxEngStatus.ComboBox.SelectedValue;
			}
			catch
			{
				_selectedEngineerStatus = -1;
			}

			tsbtnRefresh.PerformClick();
		}
	}
}