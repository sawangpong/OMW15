using System;
using System.Windows.Forms;

namespace OMW15.Views.ToolViews
{
	public partial class LoadAlert : Form
	{
		//public event EventHandler<EventArgs> Canceled;

		public LoadAlert()
		{
			InitializeComponent();
		}


		public string Message
		{
			set { lbMessage.Text = value; }
		}

		public int ProgressValue
		{
			set { pgb.Value = value; }
		}

		private void LoadAlert_Load(object sender, EventArgs e)
		{
			CenterToParent();
		}
	}
}