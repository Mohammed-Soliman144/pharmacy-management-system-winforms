using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystemV20._0._1.RPT
{
    public partial class FRM_CustAccountViewerRpt : Form
    {

        /// <summary>
        /// Constructor of Class FRM_CustAccountViewerRpt
        /// </summary>
        public FRM_CustAccountViewerRpt()
        {
            InitializeComponent();
        }

        //btnClose_Click Method To close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close Form
            this.Close();
        }
    }
}
