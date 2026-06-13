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
    public partial class FRM_SalesViewerRpt : Form
    {
        public FRM_SalesViewerRpt()
        {
            InitializeComponent();
        }

        //btnClose_Click Method To close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
