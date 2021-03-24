using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class ProductionDashboard : Form
	{
		#region Singleton
		private static ProductionDashboard _instance;
		public static ProductionDashboard GetInstance
		{
			get
			{
				if (_instance == null || _instance.IsDisposed)
				{
					_instance = new ProductionDashboard();
				}
				return _instance;
			}
		}

		#endregion


		public ProductionDashboard()
		{
			InitializeComponent();
		}
	}
}
