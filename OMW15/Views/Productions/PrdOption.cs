using OMControls;
using OMW15.Shared;
using System;
using System.Data;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class PrdOption : Form
	{
		#region class field member

		private readonly OMShareProduction.ProductionOptionEnum _option = OMShareProduction.ProductionOptionEnum.None;
		private int _rowCount;

		#endregion

		#region class property

		public DataTable DataSource { get; set; }
		public bool IsEmptyItem { get; set; }
		public string SelectedItem { get; set; } = string.Empty;
		public int SelecedItemId { get; set; } = 0;

		#endregion

		#region class helper method

		private void GetOptionItem(DataTable DataSource)
		{
			_rowCount = DataSource.Rows.Count;

			dgv.SuspendLayout();
			dgv.DataSource = DataSource;

			dgv.ColumnHeadersVisible = false;

			if (_option == OMShareProduction.ProductionOptionEnum.Machine)
			{
				dgv.Columns["MC_GROUPID"].Visible = false;
			}

			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();

			UpdateUI();
		} // end GetOptionItem

		private void UpdateUI()
		{
			btnSelect.Enabled = !string.IsNullOrEmpty(SelectedItem);
		} // end UpdateUI

		#endregion

		public PrdOption(OMShareProduction.ProductionOptionEnum Option)
		{
			InitializeComponent();
			_option = Option;

			var _title = string.Empty;
			switch (_option)
			{
				case OMShareProduction.ProductionOptionEnum.ItemMaterial:
					_title = "Material";
					break;

				case OMShareProduction.ProductionOptionEnum.ItemUnit:
					_title = "Unit of Measurement";
					break;

				case OMShareProduction.ProductionOptionEnum.Machine:
					_title = "Machinery";
					break;
			}

			lbOptionTitle.Text = _title;
		}

		private void PrdOption_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			IsEmptyItem = true;
			GetOptionItem(DataSource);
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (_rowCount == dgv.Rows.Count)
			{
				if (_option == OMShareProduction.ProductionOptionEnum.Machine)
				{
					this.SelectedItem = dgv["MC_GROUPNAME", e.RowIndex].Value.ToString();
					this.SelecedItemId = Convert.ToInt32(dgv["MC_GROUPID", e.RowIndex].Value.ToString());
				}
				else
				{
					this.SelectedItem = dgv[0, e.RowIndex].Value.ToString();
				}
				IsEmptyItem = false;
			}

			UpdateUI();
		}

		private void dgv_DoubleClick(object sender, EventArgs e) => btnSelect.PerformClick();

	}
}