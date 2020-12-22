using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.BankView;

namespace OMW15.Controllers.SaleController
{
	public class BankController
	{
		public BankController(ActionMode Mode = ActionMode.View)
		{
			IsEmptyResult = true;
			GetBankInfo(Mode);
		}

		public bool IsEmptyResult { get; set; }

		public string BankInfo { get; set; }

		private void GetBankInfo(ActionMode Mode)
		{
			using (var _b = new Banks())
			{
				_b.StartPosition = FormStartPosition.CenterScreen;

				if (_b.ShowDialog() == DialogResult.OK)
				{
					BankInfo = _b.BankCompleteInfo;
					IsEmptyResult = false;
				}
				else
				{
					IsEmptyResult = true;
				}
			}
		}
	}
}