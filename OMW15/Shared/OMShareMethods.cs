using System;
using OMControls;

namespace OMW15.Shared
{
	public class OMShareMethods
	{
		public static string GetOMNumberThaiFormat(int Number)
		{
			return string.Format("{0}-{1}", DateTime.Today.GetThaiYearFormat(),
				"0000".Substring(0, 4 - Number.ToString().Length) + Number);
		} // end GetOMNumberThaiFormat


		public static string GetOMNumberENFormat(int Number)
		{
			return string.Format("{0}-{1}", DateTime.Today.GetGeneralYearFormat(),
				"0000".Substring(0, 4 - Number.ToString().Length) + Number);
		} // end GetOMNumberThaiFormat
	}
}