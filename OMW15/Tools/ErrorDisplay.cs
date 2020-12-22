using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15
{
	public partial class ErrorDisplay : Form
	{
		#region Overload Contructor

		private string _title = "Message";
		private string _message = "Nothing to display";

		public ErrorDisplay()
		{
			InitializeComponent();
		}

		public ErrorDisplay(string Title, String Message)
		{
			InitializeComponent();
			_title = Title;
			_message = Message;
		}
		public ErrorDisplay(string Caption, string Title, Object Message)
		{
			InitializeComponent();
			this.Text = Caption;
			_title = Title;
			_message = Message.ToString();
		}

		public ErrorDisplay(string Caption,string Title, EntitySqlException Message)
		{
			InitializeComponent();
			this.Text = Caption;
			_title = Title;
			_message = Message.ToString();
		}

		#endregion


		private void ErrorDisplay_Load(object sender, EventArgs e)
		{
			this.lbTitle.Text = _title;
			this.txtMsg.Text = _message;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
