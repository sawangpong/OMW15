using System.Windows.Forms;
using OMW15.Views.CastingView;

namespace OMW15.Controllers.CastingController
{
	public class MaterialDeliveryController
	{
		// CONSTRUCTOR

		#region class property

		public string MaterialCategory { get; set; }

		#endregion

		#region class helper method

		public void ViewDeliveryMaterialSummary(string MaterialCategory)
		{
			var _sumIssueMat = new SumOfDelivery(MaterialCategory);
			_sumIssueMat.Show();
		} // end ViewDeliveryMaterialSummary


		public void ViewMaterialDeliveryCard()
		{
			var _mcard = new MaterialCard();
			_mcard.StartPosition = FormStartPosition.CenterParent;
			_mcard.Show();
		} // end ViewDeliveryMaterialSummary

		#endregion
	}
}