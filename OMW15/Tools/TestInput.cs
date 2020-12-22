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
using OMW15.Controllers;
using OMW15.Models;
using OMW15.Shared;
using OMW15.Views;

namespace OMW15.Tools
{
	public partial class TestInput : Form
	{
		public TestInput()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.textBox1.Text = OMControls.OMDataUtils.GetFilter<Int32>("Test - Input - Numeric").ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.textBox2.Text = OMControls.OMDataUtils.GetFilter<string>("Test - Input - String").ToString();

		}

		private void btnGetData_Click(object sender, EventArgs e)
		{
			this.dataListView1.DataSource = new Controllers.CustomerController.SearchMasterCustomers().GetMasterCustomer<string>(string.Empty);
			this.dataListView1.GetData();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			this.dataListView1.DataSource = SelectOptions.GetDataByOption(SelectTypeOption.Province);
			this.dataListView1.GetData();

		}
	}
}
