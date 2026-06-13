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
    public partial class FRM_Notifications : Form
    {
        #region public Declarations
        //Create public string variable to check type of MessageBox 
        public string NotifyType;

        //bool Variable to check DialogResult of MessageBox
        public bool NotifyResult = false;

        //declare bool variable to check if user press on panel to move form
        bool pressOnMouseDown = false;

        //declare Point variable to define the last location
        Point lastLocation;

        //Create Private enumeration for NotifyIcons
        public enum NotifyIcons
        {
            Information = 0,
            Error = 1,
            Question = 2,
            Warning = 3,
            Hand = 4
        }

        //Create Private enumeration for NotifyButtons
        public enum NotifyButtons
        {
            YesNo = 0,
            Ok = 1
        }

        //Create Private enumeration for NotifyType
        public enum NotifyTypes
        {
            NotifyBtn = 0,
            NotifyRBtn = 1
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_Notifications
        /// </summary>
        public FRM_Notifications()
        {
            InitializeComponent();
        }

        #region Methods and Functions

        /// <summary>
        /// Method related by Error which generate from system
        /// </summary>
        /// <param name="subject"></param>
        public void NotifySystemShow(string subject)
        {
            /* Properties of message Box */
            this.rbtnDelete.Visible = false;
            this.rbtnInActivate.Visible = false;
            lblSubject.Visible = true;
            this.lblSubject.Font = new Font("LBC", 9, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            lblSubject.TextAlign = ContentAlignment.MiddleRight;
            lblImage.ImageIndex = 5;
            btnNo.Visible = false;
            btnYes.Text = "OK";
            btnYes.Location = new Point(139, 101);
            lblTitle.Text = "System";
            lblSubject.Text = subject;
        }

        /// <summary>
        /// Method to Show Notify SMS
        /// </summary>
        /// <param name="subject">subject of Message</param>
        public void NotifyShow(string subject)
        {
            /* Properties of message Box */
            this.rbtnDelete.Visible = false;
            this.rbtnInActivate.Visible = false;
            lblSubject.Visible = true;
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            lblSubject.TextAlign = ContentAlignment.MiddleLeft;
            btnNo.Visible = false;
            btnYes.Text = "موافق";
            btnYes.Location = new Point(139, 101);
            lblSubject.Text = subject;
        }

        /// <summary>
        /// Method to Show Notify SMS (overloading Method)
        /// </summary>
        /// <param name="title">title of Message</param>
        /// <param name="subject">subject of Message</param>
        public void NotifyShow(string subject, string title)
        {
            /* Properties of message Box */
            this.rbtnDelete.Visible = false;
            this.rbtnInActivate.Visible = false;
            lblSubject.Visible = true;
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            lblSubject.TextAlign = ContentAlignment.MiddleLeft;
            btnNo.Visible = false;
            btnYes.Text = "موافق";
            btnYes.Location = new Point(139, 101);
            lblTitle.Text = title;
            lblSubject.Text = subject;
        }

        /// <summary>
        /// Method to Show Notify SMS (overloading Method)
        /// </summary>
        /// <param name="title">title of Message</param>
        /// <param name="subject">subject of Message</param>
        /// <param name="btn">Type of buttons</param>
        /// <param name="ico">Type of Icons</param>
        /// <param name="type">Type of Message</param>
        public void NotifyShow (string subject, string title, NotifyButtons btn, NotifyIcons ico, NotifyTypes type)
        {
            /* Properties of message Box */
            lblSubject.Visible = true;
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            lblSubject.TextAlign = ContentAlignment.MiddleLeft;
            if (type == NotifyTypes.NotifyRBtn) 
            {
                rbtnDelete.Checked = false;
                rbtnInActivate.Checked = false;
                rbtnDelete.Visible = true; 
                rbtnInActivate.Visible = true; 
            }
            else { rbtnDelete.Visible = false; rbtnInActivate.Visible = false; }

            if (btn == NotifyButtons.YesNo) 
            { 
                btnYes.Visible = true; 
                btnYes.Text = "نعم";
                btnYes.Location = new Point(207, 101);

                btnNo.Visible = true;
                btnNo.Location = new Point(71, 101);
            }
            else if (btn == NotifyButtons.Ok)
            {
                btnNo.Visible = false;
                btnYes.Text = "موافق";
                btnYes.Location = new Point(139, 101);
            }
            
            lblImage.ImageIndex = (int)ico;
            lblTitle.Text = title;
            lblSubject.Text = subject;
        }

        /// <summary>
        /// Method to Show Notify SMS in Mode Radio button (overloading Method)
        /// </summary>
        /// <param name="title">title of Message</param>
        /// <param name="btn">Type of buttons</param>
        /// <param name="ico">Type of Icons</param>
        public void NotifyShow(string title, NotifyIcons ico, NotifyButtons btn)
        {
            /* Properties of message Box */
            lblTitle.TextAlign = ContentAlignment.MiddleRight;
            lblSubject.Visible = false;

            rbtnDelete.Checked = false;
            rbtnInActivate.Checked = false;
            this.rbtnDelete.Visible = true;
            this.rbtnInActivate.Visible = true;

            if (btn == NotifyButtons.YesNo)
            {
                btnYes.Visible = true;
                btnYes.Text = "نعم";
                btnYes.Location = new Point(207, 101);

                btnNo.Visible = true;
                btnNo.Location = new Point(71, 101);
            }
            else if (btn == NotifyButtons.Ok)
            {
                btnNo.Visible = false;
                btnYes.Text = "موافق";
                btnYes.Location = new Point(139, 101);
            }

            lblImage.ImageIndex = (int)ico;
            lblTitle.Text = title;
        }

        //btnClose_Click Method To Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }

        /// <summary>
        /// btnYes_Click Method to chech Notify Type of Message
        /// Make DialogResult of MessageBox is True
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            //if user check delete record
            if (rbtnDelete.Checked == true)
            {
                NotifyType = "Delete Record";
            }
            else //if user check InActivate record
            {
                NotifyType = "InActivate Record";
            }
            //Make DialogResult of MessageBox is True
            NotifyResult = true;
            //Close the form
            this.Close();
        }

        /// <summary>
        /// btnNo_Click Method to close form
        /// Make DialogResult of MessageBox is false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            //Make DialogResult of MessageBox is false
            NotifyResult = false;
            //Close the form
            this.Close();
        }

        /// <summary>
        /// Method to check if user press on the panel by MouseDown to Define last location
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseEventArgs</param>
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            //If User Press by Mouse Down on panel
            if (pressOnMouseDown == false)
            {
                //cheange pressOnMouseDown to true
                pressOnMouseDown = true;

                //last location equal location which generated by event
                lastLocation = e.Location; 
            }
        }

        /// <summary>
        /// Method to define if user left press on the panel
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseEventArgs</param>
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            //Change pressOnMouseDown to false when user Left mouse
            if (pressOnMouseDown == true) pressOnMouseDown = false;
        }

        /// <summary>
        /// Method to Define New Location of Form
        /// when user move by mouse move on the panel
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">MouseEventArgs</param>
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            //if pressOnMouseDown is true after user press on panel by Mouse down
            if (pressOnMouseDown == true)
            {
                // the new location of form equal = location Generated by event (this.Location.X - LastLocation.X ) + e.x , (this.Location.Y - LastLocation.Y) + e.Y
                this.Location = new Point((this.Location.X - lastLocation.X )+ e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        //FRM_Notifications_FormClosed Method to Initialize null value to form after close it
        private void FRM_Notifications_FormClosed(object sender, FormClosedEventArgs e)
        {
            //nitialize null value to form by use void method Close the Form
            this.Close();
        }

        #endregion

    }
}
