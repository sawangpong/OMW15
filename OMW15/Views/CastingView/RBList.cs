using System;
using System.Drawing;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.CastingModel;
using OMW15.Shared;

namespace OMW15.Views.CastingView
{
	public partial class RBList : Form
	{
		public RBList(ActionMode Mode = ActionMode.Recording)
		{
			InitializeComponent();
			_mode = Mode;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void RBList_Load(object sender, EventArgs e)
		{
			CenterToParent();
			OMUtils.SettingDataGridView(ref dgv);

			GetRBSizeList();
			UpdateUI();
		}

		private void tscbxRBSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedRBSize = tscbxRBSize.ComboBox.SelectedValue.ToString();
			}
			catch
			{
				_selectedRBSize = string.Empty;
			}

			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedBaseId = Convert.ToInt32(dgv["BASEID", e.RowIndex].Value);
			BaseId = _selectedBaseId;
			BaseSize = _selectedRBSize;
			BaseNo = dgv["BASENO", e.RowIndex].Value.ToString();
			BaseWeight = Convert.ToDecimal(dgv["WEIGHTGRAM", e.RowIndex].Value);
			lbId.Text = _selectedBaseId.ToString();
			UpdateUI();
		}

		private void RBList_ResizeEnd(object sender, EventArgs e)
		{
			Size = new Size(450, 370);
		}

		private void tsbtnAddRB_Click(object sender, EventArgs e)
		{
			_selectedBaseId = 0;
			AddEditRB(_selectedBaseId, _selectedRBSize);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			LoadRBList(_selectedRBSize);
		}

		private void tsbtnEditRB_Click(object sender, EventArgs e)
		{
			AddEditRB(_selectedBaseId, _selectedRBSize);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			tsbtnEditRB.PerformClick();
		}

		#region class field member

		private readonly ActionMode _mode = ActionMode.None;
		private string _selectedRBSize = string.Empty;
		private int _selectedBaseId;

		#endregion

		#region class property

		public int BaseId { get; set; }

		public string BaseSize { get; set; }

		public string BaseNo { get; set; }

		public decimal BaseWeight { get; set; }

		#endregion

		#region class helper method

		private void UpdateUI()
		{
			tsbtnAddRB.Visible = _mode != ActionMode.Selection;
			tsSep1.Visible = tsbtnAddRB.Visible;
			tsbtnEditRB.Visible = tsbtnAddRB.Visible;
			tsSep2.Visible = tsbtnAddRB.Visible;
			tsbtnClose.Visible = tsbtnAddRB.Visible;
			tsSep3.Visible = tsbtnAddRB.Visible;
			btnSelect.Visible = !tsbtnAddRB.Visible;
			btnClose.Visible = btnSelect.Visible;
			tsbtnEditRB.Enabled = _selectedBaseId > 0;
		} // end UpdateUI

		private void GetRBSizeList()
		{
			tscbxRBSize.ComboBox.DataSource = new CastingRubberBase().GetRBSize();
			tscbxRBSize.ComboBox.DisplayMember = "BASESIZE";
			tscbxRBSize.ComboBox.ValueMember = "BASESIZE";
		} // end GetRBList

		private void LoadRBList(string RBSize)
		{
			dgv.SuspendLayout();
			dgv.DataSource = new CastingRubberBase().GetRBList(RBSize);
			dgv.Columns["BASEID"].Visible = false;
			dgv.Columns["INACTIVE"].Visible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();
		} // end LoadRBSize

		private void AddEditRB(int BaseId, string BaseSize)
		{
			using (var _rbInfo = new RBInfo())
			{
				_rbInfo.BaseId = BaseId;
				_rbInfo.BaseSize = BaseSize;
				_rbInfo.StartPosition = FormStartPosition.CenterScreen;

				if (_rbInfo.ShowDialog(this) == DialogResult.OK) tsbtnRefresh.PerformClick();
			}
		} // end AddEditRB

		#endregion
	}
}