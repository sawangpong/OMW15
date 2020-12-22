using System.Windows.Forms;
using OMW15.Shared;
using OMW15.Views.ToolViews;

namespace OMW15.Controllers.ToolController
{
	public class ToolGetData
	{
		#region Overload Method GetData

		public static void GetData(SelectTypeOption Option, ref string Name, ref string Code, ref int Id)
		{
			GetData(Option, 0, ref Name, ref Code, ref Id);
		} // end 

		public static void GetData(SelectTypeOption Option, int FilterId, ref string Name, ref string Code, ref int Id)
		{
			var _selectBox = new SelectBox();
			_selectBox.SelectOption = Option;
			_selectBox.FilterId = FilterId;
			_selectBox.StartPosition = FormStartPosition.CenterScreen;
			if (_selectBox.ShowDialog() == DialogResult.OK)
			{
				Name = _selectBox.SelectedName;
				Code = _selectBox.SelectedCode;
				Id = _selectBox.SelectedId;
			}
		}

		#endregion // Overload Method GetData
	}
}