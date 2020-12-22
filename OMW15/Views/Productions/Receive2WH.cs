using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.Productions
{
	public partial class Receive2WH : Form
	{
		#region class properties
		public decimal ReceiveQty { get; set; }
		public string ReceivedBy { get; set; }
		public DateTime ReceivedDate { get; set; }

		#endregion

		#region class helper
		private void UpdateUI()
		{

			btnSave.Enabled = (!String.IsNullOrEmpty(txtReceivedBy.Text) 
								&& dtpReceiveDate.Value != null
								&& Convert.ToDecimal(ntxtReceiveQty.Text) > 0);
		}

		#endregion

		public Receive2WH()
		{
			InitializeComponent();
		}

		private void Receive2WH_Load(object sender, EventArgs e)
		{
			txtReceivedBy.Text = this.ReceivedBy;
			ntxtReceiveQty.Text = $"{this.ReceiveQty:N2}";
			dtpReceiveDate.Value = this.ReceivedDate;

		}

		private void txtReceivedBy_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void dtpReceiveDate_CloseUp(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void ntxtReceiveQty_TextChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.ReceivedBy = txtReceivedBy.Text;
			this.ReceivedDate = dtpReceiveDate.Value;
			this.ReceiveQty = decimal.Parse(ntxtReceiveQty.Text);
		}
	}
}
