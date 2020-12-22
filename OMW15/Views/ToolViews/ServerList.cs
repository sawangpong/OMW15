using System;
using System.Windows.Forms;
using OMControls;
using OMW15.Models.ToolModel;

namespace OMW15.Views.ToolViews
{
	public partial class ServerList : Form
	{
		#region class field

		#endregion

		public ServerList()
		{
			InitializeComponent();
		}

		#region class property

		public string ServerName { get; set; } = string.Empty;

		#endregion

		private void ServerList_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			GetServerList();
			UpdateUI();
		}

		private void btnSelectServer_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			ServerName = string.Empty;
			Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			ServerName = dgv["SERVERNAME", e.RowIndex].Value.ToString();
		}

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetServerList()
		{
			dgv.SuspendLayout();
			dgv.DataSource = new DatabaseServerList().GetServerItems();
			dgv.ColumnHeadersVisible = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ResumeLayout();
		} // end GetServerList

		#endregion
	}
}