using System.Data.SqlClient;
using System.Windows.Forms;
using OMW15.Views.ToolViews;

namespace OMW15.Controllers.ToolController
{
	public class Alert
	{
		#region Alert and Display Popup dialog

		// overload method DisplayAlert
		public static void DisplayAlert(string Caption, string Title, SqlException Msg)
		{
			var edy = new ErrorDisplay(Caption, Title, Msg);
			edy.StartPosition = FormStartPosition.CenterScreen;
			edy.ShowDialog();
		} // end DisplayAlert

		public static void DisplayAlert(string Caption, string Title, object Msg)
		{
			var edy = new ErrorDisplay(Caption, Title, Msg);
			edy.StartPosition = FormStartPosition.CenterScreen;
			edy.ShowDialog();
		} // end DisplayAlert

		public static void DisplayAlert(string Title, string Msg)
		{
			var edy = new ErrorDisplay(Title, Msg);
			edy.StartPosition = FormStartPosition.CenterScreen;
			edy.ShowDialog();
		} // end DisplayAlert

		#endregion
	}
}