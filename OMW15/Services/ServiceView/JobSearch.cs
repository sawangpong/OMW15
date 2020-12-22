using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Services.ServiceView
{
	public partial class JobSearch : Form
	{
		private string _selectedField = string.Empty;

		#region class property

		public string FilterResult
		{
			get;
			set;
		}

		#endregion

		#region class Helper Method

		private void UpdateUI()
		{
			this.btnSearch.Enabled = !string.IsNullOrEmpty(this.txtFilter.Text);
		} // end UpdateUI


		#endregion


		public JobSearch()
		{
			InitializeComponent();
		}

		private void JobSearch_Load(object sender, EventArgs e)
		{
			this.rdoJobNo.Checked = true;
		}

		private void rdo_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton _rdo = sender as RadioButton;
			if (_rdo.Checked == true)
			{
				_selectedField = _rdo.Tag.ToString().ToUpper();
				this.grp2.Text = string.Format("[Search from : {0}]", _selectedField);
			}
			
		}

		private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				this.btnSearch.PerformClick();
			}
		}

		private void txtFilter_TextChanged(object sender, EventArgs e)
		{
			this.UpdateUI();
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			if (this.chkFixSearch.Checked == true)
			{
				this.FilterResult = string.Format("[{0}] = '{1}'", _selectedField, this.txtFilter.Text);
			}
			else
			{
				this.FilterResult = string.Format("[{0}] LIKE '%{1}%'", _selectedField, this.txtFilter.Text);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.FilterResult = string.Empty;
		}
	}
}
