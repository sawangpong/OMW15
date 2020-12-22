using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace OMW15.Views.ToolViews
{
	public partial class TestLoadExcel : Form
	{
		private string _worksheetName = "";
		DataSet result = new DataSet();
		#region class method

		private void loadExcelFile()
		{
			OpenFileDialog ope = new OpenFileDialog();
			ope.Filter = "Excel Files |*.xlsx;*.xlsm";
			if(ope.ShowDialog() == DialogResult.Cancel)
			{
				return;
			}

			string _fileName = ope.FileName;
			this.textBox1.Text = @_fileName;

			// create list of excel sheets

			//using(FileStream fs = File.Open(@_fileName, FileMode.Open, FileAccess.Read))
			//{
			//	IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(fs);
			//	reader.IsFirstRowAsColumnNames = true;
			//	result = reader.AsDataSet();

			//	cbxWorkSheets.Items.Clear();

			//	if(result.Tables.Count > 0)
			//	{
			//		foreach(DataTable dt in result.Tables)
			//		{
			//			cbxWorkSheets.Items.Add(dt.TableName);
			//		}
			//	}
			//	reader.Close();
			//}
		}


		#endregion

		public TestLoadExcel()
		{
			InitializeComponent();
		}

		private void TestLoadExcel_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref dgv);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			loadExcelFile();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			dgv.DataSource = null;
			dgv.DataSource = result.Tables[cbxWorkSheets.SelectedIndex];
		}

		private void cbxWorkSheets_SelectedIndexChanged(object sender, EventArgs e)
		{
			_worksheetName = cbxWorkSheets.Text;
		}


	}
}
