using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ServiceModel;

namespace OMW15.Views.ServiceView
{
	public partial class ErrList : Form
	{
		#region class field member

		private int _selectedErrorCat;

		#endregion

		public ErrList()
		{
			InitializeComponent();
			WindowState = FormWindowState.Normal;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void ErrList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetErrorList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedErrorCat = Convert.ToInt32(dgv["ERRORCATID", e.RowIndex].Value);
			}
			catch
			{
				_selectedErrorCat = 0;
			}
			UpdateUI();
		}

		private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			_selectedErrorCat = Convert.ToInt32(dgv["ERRORCATID", e.RowIndex].Value);

			tsbtnEdit.PerformClick();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			AddEditErrorInfo(_selectedErrorCat);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedErrorCat = 0;
			AddEditErrorInfo(_selectedErrorCat);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetErrorList();
		}

		#region class property

		#endregion

		#region class helper

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedErrorCat > 0;
		} // end UpdateUI

		private void GetErrorList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new ServiceJobDAL().GetErrorList();
			dgv.Columns["ERRORCATID"].Visible = false;
			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();
		} // end GetErrorList

		private void AddEditErrorInfo(int ErrorCatId)
		{
			using (var _errInfo = new ErrorInfo(ErrorCatId))
			{
				_errInfo.StartPosition = FormStartPosition.CenterScreen;
				_errInfo.ShowDialog(this);
			}

			tsbtnRefresh.PerformClick();
		} // end AddEditErrorInfo

		#endregion
	}
}