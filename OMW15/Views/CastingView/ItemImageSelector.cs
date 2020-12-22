using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using OMControls;

namespace OMW15.Views.CastingView
{
	public partial class ItemImageSelector : Form
	{
		#region class field members

		private int _selectImageId;

		#endregion

		public ItemImageSelector()
		{
			InitializeComponent();
		}

		private void ItemImageSelector_Load(object sender, EventArgs e)
		{
			OMUtils.SettingDataGridView(ref dgv);
			//LoadImageList();
		}

		private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			_selectImageId = Convert.ToInt32(dgv["ITEMPICID", e.RowIndex].Value);
			ShowSelectedImage(_selectImageId);
		}

		#region class property

		public int ItemImageId
		{
			get; set;
		}

		public Image SelectedImage
		{
			get; set;
		}

		#endregion

		#region class helper

		//private void LoadImageList()
		//{
		//	var _dt = new DataTable();

		//	using (var _om = new OLDMOONEF())
		//	{
		//		var imgList = (from cp in _om.CUSTPRICELISTs
		//					   join ci in _om.CUSTPRICEITEMPICs on cp.PRICESEQ equals ci.ITEMSEQ
		//					   orderby cp.ITEMNO
		//					   where cp.ISDELETE == false
		//					   select new
		//					   {
		//						   cp.PRICESEQ,
		//						   ci.ITEMPICID,
		//						   cp.ITEMNO,
		//						   cp.ITEMNAME
		//					   }).AsParallel();

		//		_dt = imgList.ToDataTable();
		//	}

		//	_dt.DefaultView.Sort = "ITEMNO";
		//	dgv.DataSource = _dt;
		//} // end LoadImageList

		private void ShowSelectedImage(int Id)
		{
			using (var _om = new OLDMOONEF1())
			{
				var img = (from ci in _om.CUSTPRICEITEMPICs
						   where ci.ITEMPICID == Id
						   select new
						   {
							   ci.ITEMPIC
						   }).FirstOrDefault();

				if (img != null)
				{
					var _idg = new OMImageDB();
					pic.Image = _idg.GetImageFromByte(img.ITEMPIC);
					SelectedImage = pic.Image;
				}
			}
		} // end ShowSelectedImage

		#endregion
	}
}