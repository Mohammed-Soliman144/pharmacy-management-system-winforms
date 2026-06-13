using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Intro : Form
    {

        #region Using Object Oriented Programing to access FRM_Intro Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Intro IntroAccessFRM;

        //Create IntroAccess_FormClosed to recall it when close form
        private static void IntroAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            IntroAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Intro IntroAccess_Property
        {
            //used getter to return value of FRM_Intro 
            get
            {
                //if created instance or field is null
                if (IntroAccessFRM == null)
                {
                    //Create New Instance From FRM_Intro by initialize it to field
                    IntroAccessFRM = new FRM_Intro();
                    //Generate Event of Form Closed and Delegate Method IntroAccess_FormClosed to it
                    IntroAccessFRM.FormClosed += new FormClosedEventHandler(IntroAccess_FormClosed);
                }
                //Return the value of field
                return IntroAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Intro()
        public FRM_Intro()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Intro to it 
            if (IntroAccessFRM == null) IntroAccessFRM = this;
            //Enable timer of Intro
            timerIntro.Enabled = true;
            //Start timer of intro
            timerIntro.Start();
        }

        //timerIntro_Tick Method which created with every tick of Timer 
        private void timerIntro_Tick(object sender, EventArgs e)
        {
            // If Value of Progressbar is less than from Maximum of Progressbar
            if (progressBarIntro.Value < progressBarIntro.Maximum)
            {
                //Increment Value of Progressbar by 30 with each tick
                progressBarIntro.Value += 25;
            }
            // If Value of Progressbar is equal Maximum of Progressbar
            else if (progressBarIntro.Value == progressBarIntro.Maximum)
            {
                // Stop the timer
                timerIntro.Stop();

                //Information Message Box
                MessageBox.Show("سيتم التوجة إلى تسجيل بيانات الشركة", "تنبية", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                //Create New Instance from FRM_Companies 
                FRM_Companies CompanyForm = new FRM_Companies();
                //Control buttons in form Companies by Encapsulation or Properties or Setter and Getter
                //Disable the Delete Companies Button
                FRM_Companies.CompAccess_Property.btnDelete.Enabled = false;
                //Disable the Modify Companies Button
                FRM_Companies.CompAccess_Property.btnModify.Enabled = false;
                //Disable the Search Companies Button
                FRM_Companies.CompAccess_Property.btnSearch.Enabled = false;
                //Hide the Exit Companies Button
                FRM_Companies.CompAccess_Property.btnExit.Visible = false;
                //Appearing the Close Companies Button
                FRM_Companies.CompAccess_Property.btnClose.Visible = true;
                //Show the User Form in mode ShowDialog to Control of it
                CompanyForm.ShowDialog();
            }
        }
    }
}
