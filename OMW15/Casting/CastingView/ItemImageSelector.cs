using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Casting.CastingView
{
	public partial class ItemImageSelector : Form
	{
		#region class field members
		int _selectImageId = 0;

		#endregion

		#region class property

		public int ItemImageId
		{
			get;
			set;
		}

		public Image SelectedImage
		{
			get;
			set;
		}
		#endregion


		#region class helper

		private void LoadImageList()
		{
			DataTable _dt = new DataTable();

			using(OLDMOONEF _om = new OLDMOONEF())
			{
				var imgList = (from cp in _om.CUSTPRICELISTs 
							  join ci in _om.CUSTPRICEITEMPICs on cp.PRICESEQ equals ci.ITEMSEQ
							  orderby cp.ITEMNO 
							  where cp.ISDELETE == false
							  select new
							  {
								  cp.PRICESEQ,
								  ci.ITEMPICID,
								  cp.ITEMNO,
								  cp.ITEMNAME
							  }).AsParallel().ToList();
				_dt = OMControls.OMDataUtils.ToDataTable(imgList);
			}

			_dt.DefaultView.Sort = "ITEMNO";
			this.dgv.DataSource = _dt;

		} // end LoadImageList

		private void ShowSelectedImage(int Id)
		{
			using(OLDMOONEF _om = new OLDMOONEF())
			{
				var img = (from ci in _om.CUSTPRICEITEMPICs
						  where ci.ITEMPICID == Id
						  select new
						  {
							  ci.ITEMPIC
						  }).FirstOrDefault();

				if(img != null)
				{
					OMControls.OMImageDB _idg = new OMControls.OMImageDB();
					this.pic.Image = _idg.GetImageFromByte(img.ITEMPIC);
					this.SelectedImage = this.pic.Image;
				}
			}

		} // end ShowSelectedImage


		#endregion


		public ItemImageSelector()
		{
			InitializeComponent();
		}

		private void ItemImageSelector_Load(object sender, EventArgs e)
		{
			OMControls.OMUtils.SettingDataGridView(ref this.dgv);
			this.LoadImageList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectImageId = Convert.ToInt32(this.dgv["ITEMPICID",e.RowIndex].Value);
			this.ShowSelectedImage(_selectImageId);
		}
	}
}
