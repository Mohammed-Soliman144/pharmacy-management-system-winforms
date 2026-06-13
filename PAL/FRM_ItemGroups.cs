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
    public partial class FRM_ItemGroups : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_ItemGroups Business Access Layer
        readonly BAL.CLS_ItemGroups GroupClass = new BAL.CLS_ItemGroups();
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

        public FRM_ItemGroups()
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
            dgvGroup.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvGroup.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvGroup.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvGroup.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvGroup.AllowUserToResizeColumns = false;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvGroup.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvGroup.AutoGenerateColumns = false;
            //Intialize DataSource of DGV is GroupFormClass.ShowItemGroupTable();
            dgvGroup.DataSource = GroupClass.ShowItemGroupTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //Intialize DataSource of DGV is GroupFormClass.ShowItemGroupTable();
            dgvGroup.DataSource = GroupClass.ShowItemGroupTable();
            //Clear Text Box
            txtGroupName.Clear();
            //Focus Of Text Box
            txtGroupName.Focus();
        }

        //AddItemGroupForm Method To Add New Group Form to ItemGroupForm Table
        private void AddItemGroupForm()
        {
            try
            {
                //Check all required fields are filled or not
                if (txtGroupName.Text == string.Empty)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Focus on textbox
                    txtGroupName.Focus();

                    //Stop executing block code
                    return;
                }

                //check Duplicate of item Group Form in datagridview by for loop
                for (int i = 0; i <= dgvGroup.Rows.Count - 1; i++)
                {
                    //if dgvGroup.Rows[i].Cells[1].Value.ToString() is equal txtGroupName.Text
                    if (dgvGroup.Rows[i].Cells[1].Value.ToString() == txtGroupName.Text)
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
                GroupClass.SaveGroup(txtGroupName.Text, IP_PCName, Program.UsrID, true, DateTime.Now.ToString("yyyy-MM-dd"),
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

        //dgvGroup_CellContentClick Method to Delete any record of ItemGroup Table
        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


                    //if user select Yes Button and Select Delete itemGroup From Database
                    if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                    {
                        //Delete itemGroup From Database
                        GroupClass.DeleteGroup(Convert.ToInt32(dgvGroup.CurrentRow.Cells[0].Value));

                        //Alarm Success Delete From database Message Box 
                        NotificationSMS.NotifyShow("تم حذف بنجاح", "عملية الحذف",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();

                    }
                    //if user select Yes Button and Select InActivate itemGroupForm From Database
                    else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                    {

                        //Update Status to False in itemGroup Table
                        GroupClass.DeactivateGroup(Convert.ToInt32(dgvGroup.CurrentRow.Cells[0].Value), false);

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

        //txtGroupName_KeyDown to Recall Method btnSave_Click(sender, e); 
        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            //if e.KeyCode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Add New Group Form to ItemGroupForm Table
                AddItemGroupForm();
            }
        }

        #endregion
    }
}
