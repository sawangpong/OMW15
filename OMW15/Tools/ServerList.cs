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

namespace OMW15
{
	public partial class ServerList : Form
	{
		#region class field

		private string _serverName = string.Empty;

		#endregion

		#region class property

		public string ServerName
		{
			get
			{
				return _serverName;
			}
			set
			{
				_serverName = value;
			}
		}
		#endregion

		#region class helper

		private void UpdateUI()
		{
		} // end UpdateUI

		private void GetServerList()
		{
			this.dgv.DataSource = new DatabaseServerList().GetServerItems();
			this.dgv.ColumnHeadersVisible = false;
			this.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

		} // end GetServerList

		#endregion


		public ServerList()
		{
			InitializeComponent();
		}

		private void ServerList_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.GetServerList();
			this.UpdateUI();
		}

		private void btnSelectServer_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			_serverName = string.Empty;
			this.Close();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_serverName = this.dgv["SERVERNAME", e.RowIndex].Value.ToString();

		}
	}
}
