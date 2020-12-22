using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace OMW15.Views.ToolViews
{
	public partial class TestInput : Form
	{
		public TestInput()
		{
			InitializeComponent();
		}

		private void TestInput_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Information.IsNumeric(textBox1.Text))
				MessageBox.Show("Input is numeric");
			else
				MessageBox.Show("Input is not numeric");
		}

		#region class helper

		#endregion
	}
}