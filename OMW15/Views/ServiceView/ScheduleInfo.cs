using OMW15.Models.ServiceModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.ServiceView
{
	public partial class ScheduleInfo : Form
	{
		#region class field member

		private PMSCHEDULE sch = new PMSCHEDULE();


		#endregion

		#region class property

		public int ScheduleId
		{
			get; set;
		}

		public string Model
		{
			get; set;
		}

		#endregion

		#region class helper

		private void updateUI()
		{
		}

		private void getScheduleInfo(int scheduleId)
		{
			sch = new PMDal().getScheduleInfo(scheduleId);
			this.dtpPMDate.Value = sch.PMDate.Value;
		}

		#endregion


		public ScheduleInfo()
		{
			InitializeComponent();
		}

		private void ScheduleInfo_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();

			this.lbTitle.Text = $"กำหนดการซ่อมบำรุงของเครื่องรุ่น {this.Model} ({this.ScheduleId})";

			this.getScheduleInfo(this.ScheduleId);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			sch = new PMDal().getScheduleInfo(this.ScheduleId);
			sch.PMDate = this.dtpPMDate.Value;
			sch.LASTMODIFY = DateTime.Now;

			if (new PMDal().updatePMSchedule(sch) > 0)
			{
				MessageBox.Show("ปรับปรุงกำหนดการเรียบร้อย !!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

		}
	}
}
