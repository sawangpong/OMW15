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
using OMW15.Shared;

namespace OMW15.Casting.CastingView
{
	public partial class RBList : Form
	{
		#region class field member
		private ActionMode _mode = ActionMode.None;
		private string _selectedRBSize = string.Empty;
		private int _selectedBaseId = 0;

		#endregion

		#region class property
		public int BaseId
		{
			get;
			set;
		}
		public string BaseSize
		{
			get;
			set;
		}

		public string BaseNo
		{
			get;
			set;
		}

		public decimal BaseWeight
		{
			get;
			set;
		}
		#endregion

		#region class helper method

		private void UpdateUI()
		{
			this.tsbtnAddRB.Visible = (_mode != ActionMode.Selection);
			this.tsSep1.Visible = this.tsbtnAddRB.Visible;
			this.tsbtnEditRB.Visible = this.tsbtnAddRB.Visible;
			this.tsSep2.Visible = this.tsbtnAddRB.Visible;
			this.tsbtnClose.Visible = this.tsbtnAddRB.Visible;
			this.tsSep3.Visible = this.tsbtnAddRB.Visible;
			this.btnSelect.Visible = !this.tsbtnAddRB.Visible;
			this.btnClose.Visible = this.btnSelect.Visible;

			this.tsbtnEditRB.Enabled = (_selectedBaseId > 0);
		
		} // end UpdateUI

		private void GetRBSizeList()
		{
			this.tscbxRBSize.ComboBox.DataSource = Casting.CastingController.CastingRubberBase.GetRBSize();
			this.tscbxRBSize.ComboBox.DisplayMember = "BASESIZE";
			this.tscbxRBSize.ComboBox.ValueMember = "BASESIZE";
		
		} // end GetRBList

		private void LoadRBList(string RBSize)
		{
			this.dgv.SuspendLayout();
			this.dgv.DataSource = Casting.CastingController.CastingRubberBase.GetRBList(RBSize);
			this.dgv.Columns["BASEID"].Visible = false;
			this.dgv.Columns["INACTIVE"].Visible = false;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			this.dgv.ResumeLayout();

			this.UpdateUI();

		} // end LoadRBSize

		private void AddEditRB(int BaseId, string BaseSize)
		{
			using (Casting.CastingView.RBInfo _rbInfo = new RBInfo())
			{
				_rbInfo.BaseId = BaseId;
				_rbInfo.BaseSize = BaseSize;
				_rbInfo.StartPosition = FormStartPosition.CenterScreen;

				if(_rbInfo.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					// update & reload RBList
					tsbtnRefresh.PerformClick();
				}
			}
		} // end AddEditRB

		#endregion


		public RBList(ActionMode Mode = ActionMode.Recording)
		{
			InitializeComponent();
			_mode = Mode;
		}

		private void tsbtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void RBList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);

			this.GetRBSizeList();
			this.UpdateUI();
		}

		private void tscbxRBSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				_selectedRBSize = this.tscbxRBSize.ComboBox.SelectedValue.ToString();
			}
			catch
			{
				_selectedRBSize = string.Empty;
			}

			tsbtnRefresh.PerformClick();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectedBaseId = Convert.ToInt32(this.dgv["BASEID",e.RowIndex].Value);
			this.BaseId = _selectedBaseId;
			this.BaseSize = _selectedRBSize;
			this.BaseNo = this.dgv["BASENO", e.RowIndex].Value.ToString();
			this.BaseWeight = Convert.ToDecimal(this.dgv["WEIGHTGRAM", e.RowIndex].Value);
			this.lbId.Text = _selectedBaseId.ToString();
			this.UpdateUI();
		}

		private void RBList_ResizeEnd(object sender, EventArgs e)
		{
			this.Size = new Size(450, 370);
		}

		private void tsbtnAddRB_Click(object sender, EventArgs e)
		{
			_selectedBaseId = 0;
			this.AddEditRB(_selectedBaseId, _selectedRBSize);
		}

		private void tsbtnRefresh_Click(object sender, EventArgs e)
		{
			this.LoadRBList(_selectedRBSize);
		}

		private void tsbtnEditRB_Click(object sender, EventArgs e)
		{
			this.AddEditRB(_selectedBaseId, _selectedRBSize);
		}

		private void dgv_DoubleClick(object sender, EventArgs e)
		{
			this.tsbtnEditRB.PerformClick();
		}
	}
}
