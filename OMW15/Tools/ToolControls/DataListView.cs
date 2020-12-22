using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OMControls;
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Tools.ToolControls
{
	public class DataListView : ListView
	{
		#region class field member
		public enum ShowDataSetName
		{
			MasterCustomer,
			PriceList
		}

		private ShowDataSetName _dataSetName = ShowDataSetName.MasterCustomer;
		private DataTable _dataSource = null;

		#endregion

		#region class properties

		[Description("Setting DataSetName to Control"), DefaultValue(ShowDataSetName.MasterCustomer)]
		public ShowDataSetName DataSetName
		{
			get
			{
				return _dataSetName;
			}
			set
			{
				_dataSetName = value;
			}
		}

		public DataTable DataSource
		{
			get
			{
				return _dataSource;
			}
			set
			{
				_dataSource = value;
			}
		}

		#endregion

		#region class method

		private void CreateListViewColumns(DataTable dt)
		{
			this.SuspendLayout();

			foreach (DataColumn _dc in dt.Columns)
			{
				ColumnHeader _col = new ColumnHeader();
				_col.Name = _dc.ColumnName;
				_col.Text = _dc.ColumnName;

				if (_dc.DataType == typeof(System.String))
				{
					_col.TextAlign = HorizontalAlignment.Left;
				}
				else if (_dc.DataType == typeof(System.DateTime))
				{
					_col.TextAlign = HorizontalAlignment.Center;
				}
				else if (_dc.DataType == typeof(System.Boolean))
				{
					_col.TextAlign = HorizontalAlignment.Center;
				}
				else
				{
					_col.TextAlign = HorizontalAlignment.Right;
				}

				this.Columns.Add(_col);
			}

			this.ResumeLayout();
		}

		private void DisplayDataSetByDataSetName(ShowDataSetName SetName)
		{
			this.SuspendLayout();
			if (_dataSource == null)
			{
				// get Data
				_dataSource = new Controllers.CustomerController.SearchMasterCustomers().GetMasterCustomer<string>(string.Empty);
			}

			// create listview column
			this.CreateListViewColumns(_dataSource);

			// bindling data
			ListViewItem _lst = new ListViewItem();
			if (_dataSource.Rows.Count > 0)
			{
				foreach (DataRow _dr in _dataSource.Rows)
				{
					foreach (DataColumn _dc in _dataSource.Columns)
					{
						if (_dc.Ordinal == 0)
						{
							_lst = new ListViewItem(_dr[_dc.Ordinal].ToString());
							_lst.Tag = _dr[_dataSource.Columns.Count - 1].ToString();
						}
						else
						{
							_lst.SubItems.Add(_dr[_dc.Ordinal].ToString());
						}
					}
					this.Items.Add(_lst);
				}
				this.Update();
			}
			else
			{
				throw new Exception("No Data found....");
			}

			this.ResumeLayout();

		} // end DisplayDataSetByDataSetName


		public void GetData()
		{
			// clear content
			//this.SuspendLayout();
			if (this.Items.Count > 0)
			{
				this.Items.Clear();
			}
			if (this.Columns.Count > 0)
			{
				this.Columns.Clear();
			}
			//this.ResumeLayout();

			// binding new data from datasource
			this.DisplayDataSetByDataSetName(_dataSetName);
		}

		#endregion

		// Constructor
		public DataListView()
		{
			this.View = System.Windows.Forms.View.Details;
			this.FullRowSelect = true;
			this.GridLines = true;

		} //

	}
}
