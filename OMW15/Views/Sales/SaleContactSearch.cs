using System;
using System.Windows.Forms;
using OMControls;
using OMControls.OMView;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class SaleContactSearch : Form
	{
		public SaleContactSearch()
		{
			InitializeComponent();
		}

		private void SaleContactSearch_Load(object sender, EventArgs e)
		{
			// format datagridview
			OMUtils.SettingDataGridView(ref dgv);
		}

		private void mnuContacts_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;
			var tag = _mnu.Tag.ToString().ToUpper();

			if (tag == "ALL")
			{
				_filterType = OMShareSaleEnum.SaleContactFilterType.AllSaleContact;
				_filterText = string.Empty;
			}
			else
			{
				switch (_mnu.Tag.ToString().ToUpper())
				{
					case "NAM":
						_filterType = OMShareSaleEnum.SaleContactFilterType.SaleContactByName;
						break;
					case "COM":
						_filterType = OMShareSaleEnum.SaleContactFilterType.SaleContactByCompany;
						break;
				}
				var ip =
					new InputBox(
						_filterType == OMShareSaleEnum.SaleContactFilterType.SaleContactByName ? "Input name" : "Input company name",
						InputTypeValue.Text);

				if (ip.ShowDialog(this) == DialogResult.OK)
					_filterText = ip.DefaultValue;
			}

			GetContactList(_filterType, _filterText);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetContactList(_filterType, _filterText);
		}

		#region class field member

		private OMShareSaleEnum.SaleContactFilterType _filterType = OMShareSaleEnum.SaleContactFilterType.None;

		private string _filterText = string.Empty;

		#endregion

		#region class property

		#endregion

		#region class helper method

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetContactList(OMShareSaleEnum.SaleContactFilterType SearchType, string Filter)
		{
			dgv.SuspendLayout();

			dgv.DataSource = new SaleDAL().GetSaleContactSearchList(SearchType, Filter);

			// hide columns
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["ADDRESS"].Visible = false;
			dgv.Columns["TEL"].Visible = false;
			dgv.Columns["FAX"].Visible = false;
			dgv.Columns["EMAIL"].Visible = false;

			dgv.ResumeLayout();
		} // end GetContactList

		#endregion
	}
}