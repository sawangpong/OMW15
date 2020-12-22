using System;
using System.Windows.Forms;
using OMControls;
using OMControls.OMView;
using OMW15.Models.SaleModel;
using OMW15.Shared;

namespace OMW15.Views.Sales
{
	public partial class SaleContact : Form
	{
		public SaleContact(ActionMode ViewMode = ActionMode.Recording)
		{
			InitializeComponent();
			_viewMode = ViewMode;
		}

		private void SaleContact_Load(object sender, EventArgs e)
		{
			// formatting datagridview
			OMUtils.SettingDataGridView(ref dgv);

			UpdateUI();
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnAdd_Click(object sender, EventArgs e)
		{
			GetSaleContactInfo(ContactId = 0);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			ContactId = Convert.ToInt32(dgv["ID", e.RowIndex].Value);
			CustomerId = Convert.ToInt32(dgv["CUSTID", e.RowIndex].Value);
			CustomerCode = dgv["CUSTCODE", e.RowIndex].Value.ToString();
			TheCompanyName = dgv["COMPANY", e.RowIndex].Value.ToString();
			ContactPerson = dgv["PERSON", e.RowIndex].Value.ToString();
			Phone = dgv["TEL", e.RowIndex].Value.ToString();
			Fax = dgv["FAX", e.RowIndex].Value.ToString();
			Email = dgv["EMAIL", e.RowIndex].Value.ToString();
			Mobile = dgv["MOBILE", e.RowIndex].Value.ToString();
			Address = dgv["ADDRESS", e.RowIndex].Value.ToString();
			Country = dgv["COUNTRY", e.RowIndex].Value.ToString();

			UpdateUI();
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			GetSaleContactList(_filterType, _filterText);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			switch (_viewMode)
			{
				case ActionMode.Recording:
					tsbtnEdit.PerformClick();
					break;

				case ActionMode.Selection:
					btnSelect.PerformClick();
					break;
			}
		}

		private void tsbtnEdit_Click(object sender, EventArgs e)
		{
			GetSaleContactInfo(ContactId);
		}

		private void mnuContact_Click(object sender, EventArgs e)
		{
			var _mnu = sender as ToolStripMenuItem;

			var _tag = _mnu.Tag.ToString().ToUpper();

			if (_tag == "ALL")
			{
				_filterType = OMShareSaleEnum.SaleContactFilterType.AllSaleContact;
				_filterText = string.Empty;
			}
			else
			{
				switch (_tag)
				{
					case "NAM":
						_filterType = OMShareSaleEnum.SaleContactFilterType.SaleContactByName;
						break;
					case "COM":
						_filterType = OMShareSaleEnum.SaleContactFilterType.SaleContactByCompany;
						break;
				}

				// get filter
				using (
					var _ip =
						new InputBox(
							_filterType == OMShareSaleEnum.SaleContactFilterType.SaleContactByName ? "Input name" : "Input company name",
							InputTypeValue.Text))
				{
					_ip.StartPosition = FormStartPosition.CenterScreen;
					if (_ip.ShowDialog(this) == DialogResult.OK) _filterText = _ip.DefaultValue;
				}
			}

			// get contact
			GetSaleContactList(_filterType, _filterText);
		}

		private void tsbtnDelete_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Do you want to delete selected contact?", "Delete Contact", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				if (new SaleDAL().DeleteContact(ContactId) > 0)
				{
					MessageBox.Show("Delete contact successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tsbtnRefresh.PerformClick();
				}
		}

		#region class field member

		private readonly ActionMode _viewMode = ActionMode.None;
		private OMShareSaleEnum.SaleContactFilterType _filterType = OMShareSaleEnum.SaleContactFilterType.None;
		private string _filterText = string.Empty;

		#endregion

		#region class property

		public int ContactId { get; set; }

		public string TheCompanyName { get; set; }

		public string Address { get; set; }

		public string Country { get; set; }

		public string Phone { get; set; }

		public string Fax { get; set; }

		public string Mobile { get; set; }

		public int CustomerId { get; set; }

		public string CustomerCode { get; set; }

		public string ContactPerson { get; set; }

		public string Email { get; set; }

		#endregion

		#region class helper Method

		private void UpdateUI()
		{
			FormBorderStyle = _viewMode == ActionMode.Selection ? FormBorderStyle.SizableToolWindow : FormBorderStyle.Sizable;

			tsbtnRefresh.Enabled = dgv.Rows.Count > 0;
			tsbtnEdit.Enabled = ContactId > 0 && dgv.Rows.Count > 0;
			tsbtnDelete.Enabled = tsbtnEdit.Enabled;
			btnSelect.Enabled = ContactId > 0 && dgv.Rows.Count > 0;
			pnlCommand.Visible = _viewMode == ActionMode.Selection;
			statusStrip1.Visible = !pnlCommand.Visible;

			tsbtnClose.Visible = statusStrip1.Visible;
			tsSepClose.Visible = statusStrip1.Visible;
			tsbtnAdd.Visible = statusStrip1.Visible;
			tsbtnEdit.Visible = statusStrip1.Visible;
			tsSepAdd.Visible = statusStrip1.Visible;
			tsSepEdit.Visible = statusStrip1.Visible;
			tsSepDelete.Visible = statusStrip1.Visible;
		} // end UpdateUI

		private void GetSaleContactList(OMShareSaleEnum.SaleContactFilterType FilterType, string FilterText)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new SaleDAL().GetSaleContactSearchList(FilterType, FilterText);

			dgv.Columns["ADDRESS"].Visible = false;
			dgv.Columns["POSTAL"].Visible = false;
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["FAX"].Visible = false;
			dgv.Columns["EMAIL"].Visible = false;

			dgv.ResumeLayout();

			tslbCount.Text = string.Format("found : {0}", dgv.Rows.Count);

			UpdateUI();
		} // end GetSaleContactList

		private void GetSaleContactInfo(int ContactId)
		{
			var _contact = new SaleContactInfo(ContactId);
			_contact.StartPosition = FormStartPosition.CenterParent;
			//_contact.MdiParent = this.ParentForm;

			if (_contact.ShowDialog() == DialogResult.OK)
			{
			} // end 


			// re-load the Sale Contact list
			tsbtnRefresh.PerformClick();
		} // end GetSaleContactInfo

		#endregion
	}
}