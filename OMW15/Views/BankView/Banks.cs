using System;
using System.Text;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.SaleModel;

namespace OMW15.Views.BankView
{
	public partial class Banks : Form
	{
		public Banks()
		{
			InitializeComponent();
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			btnSelect.PerformClick();
		}

		private void Banks_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);

			GetBankList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			BankId = Convert.ToInt32(dgv["BANKID", e.RowIndex].Value);
			var s = new StringBuilder();
			s.AppendFormat("BANK NAME : {0}", dgv["BANKNAME", e.RowIndex].Value);
			s.AppendLine();
			s.AppendFormat("BRANCH : {0}", dgv["ACCOUNTBRANCH", e.RowIndex].Value);
			s.AppendLine();
			s.AppendFormat("ACCOUNT TYPE : {0}", dgv["ACCOUNTTYPE", e.RowIndex].Value);
			s.AppendLine();
			s.AppendFormat("ACCOUNT NAME : {0}", dgv["ACCOUNTNAME", e.RowIndex].Value);
			s.AppendLine();
			s.AppendFormat("ACCOUNT NO. : {0}", dgv["ACCOUNTNO", e.RowIndex].Value);
			s.AppendLine();
			s.AppendFormat("SWIFT CODE : {0}", dgv["SWIFTCODE", e.RowIndex].Value);
			s.AppendLine();
			BankCompleteInfo = s.ToString();
		}

		#region class field member

		#endregion

		#region class property

		public int BankId { get; set; }

		public string BankName { get; set; }

		public string BankCompleteInfo { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetBankList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SaleDAL().GetBankName();
			dgv.Columns["BANKID"].Visible = false;
			dgv.Columns["BANKNAME"].Visible = false;
			dgv.Columns["ACCOUNTBRANCH"].Visible = false;
			dgv.Columns["ACCOUNTTYPE"].Visible = false;
			dgv.Columns["ACCOUNTNAME"].Visible = false;
			dgv.Columns["ACCOUNTNO"].Visible = false;
			dgv.Columns["SWIFTCODE"].Visible = false;
			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();
		} // end GetBankList

		#endregion
	}
}