using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMW15.Models.ProductionModel
{
	public class ItemProcessInfo
	{
		public int Id { get; set; }
		public int RefStdItem { get; set; }
		public string RefStdItemNo { get; set; }
		public int Step { get; set; }
		public int RefProcess { get; set; }
		public string  ProcessName { get; set; }
		public decimal WorkMint { get; set; }
		public decimal StdHour { get; set; }
		public decimal StepCost { get; set; }
		public string CreateBy { get; set; }
		public DateTime? CreateDate { get; set; }
		public string ModifyBy { get; set; }
		public DateTime? ModifyDate { get; set; }

	}
}
