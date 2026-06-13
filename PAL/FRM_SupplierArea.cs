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
    public partial class FRM_SupplierArea : Form
    {

        #region Public Declarations
        //declare private bool variable to check if user press on Panel to Move it
        private bool PressOnMouseDown = false;
        //declare private point to define last location when user press by mouse down on panel
        private Point LastLocation;
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications with acces Modifier readonly to minimize space from memory
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        //Constructor of FRM_SupplierArea
        public FRM_SupplierArea()
        {
            InitializeComponent();
            //Focus Indicator on txtEdit.text
            txtEdit.Focus();
            //Set DataSource of Listbox (in constructor)
            SetDataSourceOfListBox();
        }

        #region Methods and Functions

        /// <summary>
        /// Method To Set Properties.Settings.Default.SupplierAreas Is DataSource of Listbox 
        /// Variable Settings datatye is open settings.xml in any xml editor
        /// <settings>System.Collections.Generic.List&lt;System.String&gt;</settings>
        /// its Equal datatype System.Collections.Generic.List<System.String>
        /// </summary>
        void SetDataSourceOfListBox()
        {
            //if Properties.Settings.Default.SupplierAreas is empty ==> stop to executing block code
            if (Properties.Settings.Default.SupplierAreas == null) return;
            //if Settings Variable is not Empty
            //Set DataSource of listbox is Settings Variable after casting it to list of Generic string class
            //Properties.Settings.Default.SupplierAreas.Cast<Generic Class Name is string >.ToList();
            listBoxAreas.DataSource = Properties.Settings.Default.SupplierAreas.Cast<string>().ToList();
            //Set Selected Index of item in listbox if zero select first item if -1 no any element selecting equal empty
            listBoxAreas.SelectedIndex = -1;
        }

        //btnAdd_Click Method to add items to listbox
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check if user duplicate any data entry (add same item for twice) or textbox is empty
                if (txtEdit.Text != string.Empty && !listBoxAreas.Items.Contains(txtEdit.Text))
                {
                    //If Settings Variable equal null
                    if (Properties.Settings.Default.SupplierAreas == null)
                    {
                        //So add items to listbox for first time
                        listBoxAreas.Items.Add(txtEdit.Text);
                        //clear textbox
                        txtEdit.Clear();
                        //Focus on textbox
                        txtEdit.Focus();
                        //stop to executing block code
                        return;
                    }
                    else // else if settings variable is filled 
                    {
                        //add items to settings variable
                        Properties.Settings.Default.SupplierAreas.Add(txtEdit.Text);
                        //clear textbox
                        txtEdit.Clear();
                        //Focus on textbox
                        txtEdit.Focus();
                    }
                }
                //Alarm Message if User Duplicate data entry
                else
                {
                    NotificationSMS.NotifyShow("تم إضافة هذة المنطقة من قبل", "تنبية",
                                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                }
                //Save any edit to Settings Variable ==> its necessary
                Properties.Settings.Default.Save();
                //Set DataSource of listbox (refresh after editing) ==> its necessary
                SetDataSourceOfListBox();
            }
            catch (Exception err)
            {
                //Save Catching Exception in Exceptions Table
                ErrHandlingClass.SaveExceptions(err.Message.ToString(), err.GetType().ToString(), err.StackTrace.ToString());
                //Show Notification of System Message
                NotificationSMS.NotifySystemShow(err.Message);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
        }

        //txtEdit_KeyDown Method when user key down on btn enter
        private void txtEdit_KeyDown(object sender, KeyEventArgs e)
        {
            // if text box is empty stop executing block code
            if (txtEdit.Text == string.Empty) return;
            //if e.Keycode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                //recall btnAdd_Click Method (object sender, EventArgs e);
                btnAdd_Click(sender, e);
            }
        }

        //btnDelete_Click Method to delete items from listbox
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //if count items of listbox equal zero so stop executing block code
                if (listBoxAreas.Items.Count == 0) return;

                //loop by for in all items in listbox
                for (int i = 0; i <= listBoxAreas.Items.Count - 1; i++)
                {
                    //if listbox.selectedIndex equal index of loop
                    if (listBoxAreas.SelectedIndex == i)
                    {
                        //if Delete for first time delete from listbox
                        if (Properties.Settings.Default.SupplierAreas == null) listBoxAreas.Items.RemoveAt(i);
                        //for second time Delete from Settings Variable
                        else Properties.Settings.Default.SupplierAreas.RemoveAt(i);
                    }
                }
                //Save any edit to Settings Variable ==> its necessary
                Properties.Settings.Default.Save();
                //Set DataSource of listbox (refresh after editing) ==> its necessary
                SetDataSourceOfListBox();
            }
            catch (Exception err)
            {
                //Save Catching Exception in Exceptions Table
                ErrHandlingClass.SaveExceptions(err.Message.ToString(), err.GetType().ToString(), err.StackTrace.ToString());
                //Show Notification of System Message
                NotificationSMS.NotifySystemShow(err.Message);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
        }

        //btnClose_Click Method To Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Focus On comboArea
            FRM_Suppliers.SupAccess_Property.comboArea.Focus();
            //Close Form
            this.Close();
        }

        //pnlTop_MouseDown Method if user mouse down on panel
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            //if user first for first time on panel
            if (PressOnMouseDown == false)
            {
                //Change PressOnMouseDown to true
                PressOnMouseDown = true;
                //Iniliaze value of Last location = Event MouseDown e.Location
                LastLocation = e.Location;
            }
        }

        //pnlTop_MouseMove if user move form to other location by mouse moving of panel
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            // if PressOnMouseDown is true
            if (PressOnMouseDown == true)
            {
                //Initialize new Value of Form Location = new Point(this.Location.X - LastLocation.X)+e.X , (this.Location.Y - LastLocation.Y) + e.Y)
                this.Location = new Point((this.Location.X - LastLocation.X) + e.X, (this.Location.Y - LastLocation.Y) + e.Y);
            }
        }

        //if user left panel or raise mouseUp of Panel
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            // Reset bool variable to false to store a new value in last location when user mouseDown of panel
            if (PressOnMouseDown == true) PressOnMouseDown = false;
        }

        //FRM_SupplierArea_FormClosing Method to Save Settings Variable before Closed form in event form.FormClosing
        private void FRM_SupplierArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //fill items of listbox in Settings Variable
                //Properties.Settings.Default.SupplierAreas = casting items in listbox <string>().ToList();
                Properties.Settings.Default.SupplierAreas = listBoxAreas.Items.Cast<string>().ToList();
                //Save any edit to Settings Variable
                Properties.Settings.Default.Save();
            }
            catch (Exception err)
            {
                //Save Catching Exception in Exceptions Table
                ErrHandlingClass.SaveExceptions(err.Message.ToString(), err.GetType().ToString(), err.StackTrace.ToString());
                //Show Notification of System Message
                NotificationSMS.NotifySystemShow(err.Message);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
        }

        #endregion

        
    }
}
