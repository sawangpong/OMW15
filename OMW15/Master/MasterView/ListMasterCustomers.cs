using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Master.MasterView
{
	public partial class ListMasterCustomers : UserControl
	{
		#region class field member
		
		#endregion

		#region class properties
		
		#endregion

		#region class helper

		private void UpdateUI()
		{

		} // end Update UI


		private void SettingGrid()
		{
			dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AllowUserToOrderColumns = false;
			dgv.AllowUserToResizeRows = false;
			dgv.ReadOnly = true;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
			dgv.RowHeadersVisible = false;
			dgv.MultiSelect = false;
			dgv.BorderStyle = BorderStyle.Fixed3D;
			dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
			dgv.BackgroundColor = SystemColors.Control;

		} // end SettingGrid

		#endregion


		public ListMasterCustomers()
		{
			InitializeComponent();
		}

		private void ListMasterCustomers_Load(object sender, EventArgs e)
		{
			// setting DataGridView
			this.SettingGrid();
		}
	}
}
