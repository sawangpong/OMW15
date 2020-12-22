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

namespace OMW15.Services.ServiceView
{
	public partial class ServiceEngineers : Form
	{
		#region class field member

		private ServiceController.EngineerViewState _viewMode = ServiceController.EngineerViewState.Normal;
		private int _selectedEngineerId = 0;

		#endregion

		#region class property
		public string EngineerName
		{
			get;
			set;
		}

		public string EngineerCode
		{
			get;
			set;
		}
		#endregion

		#region class helper methods

		private void UpdateUI()
		{
			this.tsbtnEditEngineer.Enabled = (_selectedEngineerId > 0);
			this.pnlRight.Visible = (_viewMode == ServiceController.EngineerViewState.Select);

			this.ts.Visible = (!this.pnlRight.Visible);
			this.pnlCommand.Visible = this.ts.Visible;

			this.btnSelect.Enabled = !string.IsNullOrEmpty(this.EngineerCode);

		} // end UpdateUI


		private void GetEngineerList()
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = new Services.ServiceController.ServiceEngineerController().GetSeviceEngineerList();

			this.dgv.Columns["ENGISEQ"].Visible = false;
			//this.dgv.Columns["EMPCODE"].Visible = false;
			//this.dgv.Columns["STATUS"].Visible = false;
			//this.dgv.Columns["RESIGNDATE"].Visible = false;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.ResumeLayout();


			this.UpdateUI();

		} // end GetEngineerList

		private void GetEngineerInfo(int Id)
		{
			using (Services.ServiceView.ServiceEngineerInfo _engInfo = new ServiceEngineerInfo(Id))
			{
				_engInfo.StartPosition = FormStartPosition.CenterScreen;
				if (_engInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					MessageBox.Show("Update successfully");
				}
			}

			this.tsbtnRefresh.PerformClick();

		} // end GetEngineerInfo


		#endregion


		public ServiceEngineers(ServiceController.EngineerViewState ViewMode)
		{
			InitializeComponent();
			_viewMode = ViewMode;
		}

		private void ServiceEngineers_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			this.tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			// used for viewstate = "Normal"
			_selectedEngineerId = Convert.ToInt32(this.dgv["ENGISEQ",e.RowIndex].Value);

			// used for viewstate = "Select"
			this.EngineerCode = this.dgv["ID", e.RowIndex].Value.ToString();
			this.EngineerName = this.dgv["ENGINEER", e.RowIndex].Value.ToString();

			// debug
			this.lbSEQ.Text = _selectedEngineerId.ToString();
			// end debug

			this.UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tsbtnEditEngineer_Click(object sender, EventArgs e)
		{
			this.GetEngineerInfo(_selectedEngineerId);
		}

		private void tsbtnAddEngineer_Click(object sender, EventArgs e)
		{
			_selectedEngineerId = 0;
			this.GetEngineerInfo(_selectedEngineerId);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetEngineerList();

		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			switch (_viewMode)
			{
				case ServiceController.EngineerViewState.Normal:
					this.tsbtnEditEngineer.PerformClick();
					break;

				case ServiceController.EngineerViewState.Select:
					this.btnSelect.PerformClick();
					break;
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
