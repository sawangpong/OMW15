using System.Windows.Forms;

namespace OMW15.Controllers.ToolController
{
	public static class DataGridViewSettingStyle
	{
		public static DataGridViewCellStyle NumericCellStyle()
		{
			var numericCellStyle = new DataGridViewCellStyle();
			numericCellStyle.Format = "N2";
			numericCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			return numericCellStyle;
		} // end NumericCellStyle

		public static DataGridViewCellStyle GeneralNumericCellStyle()
		{
			var generalNumericCellStyle = new DataGridViewCellStyle();
			generalNumericCellStyle.Format = "N0";
			generalNumericCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			return generalNumericCellStyle;

		} // end GeneralNumericCellStyle

		public static DataGridViewCellStyle StringCellStyle()
		{
			var stringCellStyle = new DataGridViewCellStyle();
			stringCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			return stringCellStyle;
		} // end StringCellStyle

		public static DataGridViewCellStyle DateCellStyle()
		{
			var dateCellStyle = new DataGridViewCellStyle();
			dateCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dateCellStyle.Format = "d";
			return dateCellStyle;
		} // end dateCellStyle

		public static DataGridViewCellStyle PercentCellStyle()
		{
			var percentCellStyle = new DataGridViewCellStyle();
			percentCellStyle.Format = "P2";
			percentCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			return percentCellStyle;
		} // end PercentCellStyle
	}
}