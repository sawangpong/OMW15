using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMW15.Views.CastingView
{
    public partial class SpeedInput : Form
    {
        #region class field member
        private int _selectedItemId = 0;

        #endregion


        #region class property
        public string AppCode
        {
            get; set;
        }


        #endregion

        #region class helper

        private void updateUI()
        {
            this.btnEdit.Enabled = (_selectedItemId >0);
            this.btnDelete.Enabled = this.btnEdit.Enabled;
        }


        #endregion



        public SpeedInput()
        {
            InitializeComponent();

        }

        private void SpeedInput_Load(object sender, EventArgs e)
        {
            this.lbAppCode.Text = this.AppCode;

            OMControls.OMUtils.SettingDataGridView(ref this.dgv);


            this.updateUI();
        }
    }
}
