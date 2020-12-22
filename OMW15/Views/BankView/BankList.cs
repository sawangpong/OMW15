using OMControls;
using OMW15.Models.BankModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.BankView
{
	public partial class BankList : Form
	{
		#region Singleton

		public static BankList _instance;
		public static BankList GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed) _instance = new BankList();
				return _instance;
			}
		}

		#endregion

		#region class field member

		private int _selectedBankId;

		#endregion

		public BankList()
		{
			InitializeComponent();
		}

		private void BankList_Load(object sender, EventArgs e)
		{
			// setting datagridview
			OMUtils.SettingDataGridView(ref dgv);

			// loading the list by performed the refresh button
			tsbtnRefresh.PerformClick();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedBankId = Convert.ToInt32(dgv["BANKID", e.RowIndex].Value);
			stlbBankId.Text = $"id:{_selectedBankId}";
			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEdit.PerformClick();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetBankList();
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetBankInfo(_selectedBankId);
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			_selectedBankId = 0;
			GetBankInfo(_selectedBankId);
		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["INACTIVE"].Value))
			{
				e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Italic);
				e.CellStyle.BackColor = Color.Coral;
				e.CellStyle.ForeColor = Color.Yellow;
			}
		}

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			tsbtnEdit.Enabled = _selectedBankId > 0;
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
		} // end UpdateUI


		private void GetBankList()
		{
			dgv.SuspendLayout();

			// load Bank Data
			dgv.DataSource = new BankDAL().GetBankList();

			dgv.ResumeLayout();
			dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
			dgv.Columns["INACTIVE"].Visible = false;
			dgv.Columns["BANKID"].Visible = false;

			dgv.Columns["BANKNAME"].HeaderText = "Bank Name";
			dgv.Columns["ACCOUNTNAME"].HeaderText = "Account Holder Name";
			dgv.Columns["ACTYPE"].HeaderText = "Account Type";
			dgv.Columns["ACCOUNTNO"].HeaderText = "Account Number";
			dgv.Columns["SWIFT"].HeaderText = "Swift Code";

			UpdateUI();
		} // end GetBankList

		private void GetBankInfo(int BankId)
		{
			// load from
			var _binfo = new BankInfo(BankId);
			_binfo.StartPosition = FormStartPosition.CenterParent;
			_binfo.ShowDialog(this);

			// update list
			tsbtnRefresh.PerformClick();
		} // end GetBankInfo

		#endregion
	}
}