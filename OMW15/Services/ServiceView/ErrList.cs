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
	public partial class ErrList : Form
	{
		#region class field member
		private int _selectedErrorCat = 0;
		#endregion

		#region class property
		
		#endregion

		#region class helper

		private void UpdateUI()
		{
			this.tsbtnEdit.Enabled = (_selectedErrorCat > 0);

		} // end UpdateUI

		private void GetErrorList()
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = Services.ServiceController.ServiceJobListController.GetErrorList();
			this.dgv.Columns["ERRORCATID"].Visible = false;
			this.dgv.ColumnHeadersVisible = false;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.ResumeLayout();

			this.UpdateUI();

		} // end GetErrorList

		private void AddEditErrorInfo(int ErrorCatId)
		{
			using(Services.ServiceView.ErrorInfo _errInfo = new ErrorInfo(ErrorCatId))
			{
				_errInfo.StartPosition = FormStartPosition.CenterScreen;
				_errInfo.ShowDialog(this);
			}

			this.tsbtnRefresh.PerformClick();

		} // end AddEditErrorInfo


		#endregion

		public ErrList()
		{
			InitializeComponent();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ErrList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.GetErrorList();

		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				_selectedErrorCat = Convert.ToInt32(this.dgv["ERRORCATID",e.RowIndex].Value);
			}
			catch
			{
				_selectedErrorCat = 0;
			}
			this.UpdateUI();
		}

		private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			_selectedErrorCat = Convert.ToInt32(this.dgv["ERRORCATID",e.RowIndex].Value);

			this.tsbtnEdit.PerformClick();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			this.AddEditErrorInfo(_selectedErrorCat);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedErrorCat = 0;
			this.AddEditErrorInfo(_selectedErrorCat);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.GetErrorList();
		}
	}
}
