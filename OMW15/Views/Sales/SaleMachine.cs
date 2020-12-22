using OMControls;
using OMW15.Models.ProductModel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OMW15.Views.Sales
{
	public partial class SaleMachine : Form
	{
		#region Singleton
		public static SaleMachine _instance;

		public static SaleMachine GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new SaleMachine();
				}
				return _instance;
			}
		}

		#endregion


		#region class helper

		private void UpdateUI()
		{

		}

		private async void GetSaleMachines()
		{
			string _y = DateTime.Today.Year.ToString();
			dgv.SuspendLayout();

			dgv.DataSource = await new ProductDAL().GetSaleProductByYearAsync();
			dgv.Columns[2].Frozen = true;

			foreach (DataGridViewColumn dgc in dgv.Columns)
			{
				if (dgc.Name.ToUpper() != "Model".ToUpper())
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

					if (dgc.Name == _y)
					{
						dgc.DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
						dgc.DefaultCellStyle.ForeColor = Color.DarkBlue;
					}
					else if (dgc.Name.ToUpper() == "Total".ToUpper())
					{
						dgc.DefaultCellStyle.Font = new System.Drawing.Font(dgv.Font, System.Drawing.FontStyle.Bold);
					}
				}
				else
				{
					dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				}
			}
			dgv.ResumeLayout();
		}
		#endregion

		public SaleMachine()
		{
			InitializeComponent();

			OMUtils.SettingDataGridView(ref dgv);
			dgv.AlternatingRowsDefaultCellStyle.BackColor = dgv.BackgroundColor;

		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void SaleMachine_Load(object sender, EventArgs e)
		{
			GetSaleMachines();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			GetSaleMachines();

		}

		private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dgv.Columns[e.ColumnIndex].Name.ToUpper() == "Model".ToUpper())
			{
				if (e.Value.ToString().ToUpper() == "total".ToUpper())
				{
					dgv.Rows[e.RowIndex].DefaultCellStyle.Font= new Font(dgv.Font, FontStyle.Bold);
					dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Yellow;
					dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;
				}
			}
		}
	}
}
