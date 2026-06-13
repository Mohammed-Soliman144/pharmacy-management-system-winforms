using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; //To Deal with Domain Name System to Get IP Address Dns.GetHostAddresses(Environment.MachineName)[0].ToString()


namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_ItemGenerics : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_ItemGenerics Business Access Layer
        readonly BAL.CLS_ItemGenerics GenericFormClass = new BAL.CLS_ItemGenerics();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //Declare Point Variable to set Last Location to control move Form in any location (with private modifier)
        private Point LastLocation;
        //Declare bool Variable to check if user Press on Panel to move From  by Mouse Dwon Event (with private modifier)
        private bool PressOnMouseDown;
        #endregion

        public FRM_ItemGenerics()
        {
            InitializeComponent();
            //Set Properties OF DataGridView
            InitializeDGV();
            //ClearControls();
            ClearControls();
        }

        #region Methods and Functions

        //Set Properties OF DataGridView
        private void InitializeDGV()
        {
            // Used Wizard of DataGridview To Set Columns of DGV And Set DataPropertyName by Alias Name in SP 
            // without Quation Mark 
            //Intialize MultiSelect of DGV is False
            dgvGeneric.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvGeneric.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvGeneric.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvGeneric.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvGeneric.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvGeneric.AllowUserToResizeColumns = false;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvGeneric.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvGeneric.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvGeneric.AutoGenerateColumns = false;
            //Intialize DataSource of DGV is GenericFormClass.ShowItemGenericTable();
            dgvGeneric.DataSource = GenericFormClass.ShowItemGenericTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //Intialize DataSource of DGV is GenericFormClass.ShowItemGenericTable();
            dgvGeneric.DataSource = GenericFormClass.ShowItemGenericTable();
            //Clear Text Box
            txtGenericName.Clear();
            //Focus Of Text Box
            txtGenericName.Focus();
        }

        //AddItemGenericForm Method To Add New Generic Form to ItemGenericForm Table
        private void AddItemGenericForm()
        {
            try
            {
                //Check all required fields are filled or not
                if (txtGenericName.Text == string.Empty)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Focus on textbox
                    txtGenericName.Focus();

                    //Stop executing block code
                    return;
                }

                //check Duplicate of item Generic Form in datagridview by for loop
                for (int i = 0; i <= dgvGeneric.Rows.Count - 1; i++)
                {
                    //if dgvGeneric.Rows[i].Cells[1].Value.ToString() is equal txtGenericName.Text
                    if (dgvGeneric.Rows[i].Cells[1].Value.ToString() == txtGenericName.Text)
                    {
                        //Warning Message Box
                        NotificationSMS.NotifyShow("هذة المادة تم إضتافتها من قبل", "تنبية",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();

                        //Stop to executing block code
                        return;
                    }
                }

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
                //Save or Add new Item dosage Form to Database
                GenericFormClass.SaveGeneric(txtGenericName.Text, IP_PCName, Program.UsrID, true, DateTime.Now.ToString("yyyy-MM-dd"),
                         DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ بنجاح", "عملية الحفظ",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Clear Controls
                ClearControls();
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

        //pnlTop_MouseDown method to check if User Press on Mouse Down on the panel
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            //check if User Press on Mouse Down on the panel
            if (PressOnMouseDown == false)
            {
                //Intialize True value to PressOnMouseDown variable
                PressOnMouseDown = true;

                //Set Location which generate by event Mouse Down is the location of LastLocation
                LastLocation = e.Location;
            }
        }

        //pnlTop_MouseMove Method to define the new location of form = this.location - lastlocation
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            //check if user press down on panel so is true
            if (PressOnMouseDown == true)
            {
                //Set current location (this.location - lastlocation)
                this.Location = new Point((this.Location.X - LastLocation.X) + e.X, (this.Location.Y - LastLocation.Y) + e.Y);
            }
        }

        //pnlTop_MouseUp Method to if user left mouse or mouse up on the panel
        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            //If PressOnMouseDown is true
            if (PressOnMouseDown == true)
            {
                //Initialize False value to PressOnMouseDown
                PressOnMouseDown = false;
            }
        }

        //btnClose_Click to Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close Form
            this.Close();
        }

        //dgvGeneric_CellContentClick Method to Delete any record of ItemGeneric Table
        private void dgvGeneric_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Delete btn is 3
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    //Set Delete Radion Button in Message Box
                    NotificationSMS.NotifyShow("الحذف", FRM_Notifications.NotifyIcons.Question,
                        FRM_Notifications.NotifyButtons.YesNo);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();


                    //if user select Yes Button and Select Delete itemGeneric From Database
                    if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                    {
                        //Delete itemGeneric From Database
                        GenericFormClass.DeleteGeneric(Convert.ToInt32(dgvGeneric.CurrentRow.Cells[0].Value));

                        //Alarm Success Delete From database Message Box 
                        NotificationSMS.NotifyShow("تم حذف بنجاح", "عملية الحذف",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();

                    }
                    //if user select Yes Button and Select InActivate itemGenericForm From Database
                    else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                    {

                        //Update Status to False in itemGeneric Table
                        GenericFormClass.DeactivateGeneric(Convert.ToInt32(dgvGeneric.CurrentRow.Cells[0].Value), false);

                        //Alarm Success deactive Message Box 
                        NotificationSMS.NotifyShow("تم حذف بنجاح", "عملية الحذف",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();

                    }
                    //if user select Exit Button
                    else if (NotificationSMS.NotifyResult == false)
                    {
                        //Clear Controls
                        ClearControls();
                        //Stop Executing Block Code
                        return;
                    }

                    //Clear Controls
                    ClearControls();
                }
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

        //txtGenericName_KeyDown to Recall Method btnSave_Click(sender, e); 
        private void txtGenericName_KeyDown(object sender, KeyEventArgs e)
        {
            //if e.KeyCode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Add New Generic Form to ItemGenericForm Table
                AddItemGenericForm();
            }
        }

        #endregion
    }
}
