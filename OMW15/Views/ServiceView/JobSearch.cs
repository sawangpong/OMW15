using System;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class JobSearch : Form
	{
		private string _selectedField = string.Empty;


		public JobSearch()
		{
			InitializeComponent();
		}

		#region class property

		public string FilterResult { get; set; }

		#endregion

		#region class Helper Method

		private void UpdateUI()
		{
			btnSearch.Enabled = !string.IsNullOrEmpty(txtFilter.Text);
		} // end UpdateUI

		#endregion

		private void JobSearch_Load(object sender, EventArgs e)
		{
			CenterToParent();
			rdoJobNo.Checked = true;
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			var _rdo = sender as RadioButton;
			if (_rdo.Checked)
			{
				_selectedField = _rdo.Tag.ToString().ToUpper();
				grp2.Text = $"[Search from : {_selectedField}]";
			}
		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char) Keys.Enter) btnSearch.PerformClick();
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (chkFixSearch.Checked) FilterResult = string.Format("[{0}] = '{1}'", _selectedField, txtFilter.Text);
			else FilterResult = string.Format("[{0}] LIKE '%{1}%'", _selectedField, txtFilter.Text);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			FilterResult = string.Empty;
		}
	}
}