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
    public partial class FRM_PointOfSales : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_ItemGenerics Business Access Layer
        readonly BAL.CLS_POS PointOfSaleClass = new BAL.CLS_POS();
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

        #region Using Object Oriented Programing to access Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_PointOfSales POSAccessFRM;

        //Create UserAccess_FormClosed to recall it when close form
        private static void POSAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            POSAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_PointOfSales POSAccess_Property
        {
            //used getter to return value of FRM_Users 
            get
            {
                //if created instance or field is null
                if (POSAccessFRM == null)
                {
                    //if field is null so Create New Instance From FRM_Users by initialize it to field
                    POSAccessFRM = new FRM_PointOfSales();
                    //Generate Event of Form Closed and Delegate Method UsersAccess_FormClosed to it
                    POSAccessFRM.FormClosed += new FormClosedEventHandler(POSAccess_FormClosed);
                }
                //Return the value of field
                return POSAccessFRM;
            }
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_PointOfSales
        /// </summary>
        public FRM_PointOfSales()
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
            dgvPOS.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvPOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvPOS.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvPOS.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvPOS.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvPOS.AllowUserToResizeColumns = false;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvPOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvPOS.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvPOS.AutoGenerateColumns = false;
            //Intialize DataSource of DGV is PointOfSaleClass.ShowPOSTable();
            dgvPOS.DataSource = PointOfSaleClass.ShowPOSTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //Intialize DataSource of DGV is PointOfSaleClass.ShowPOSTable();
            dgvPOS.DataSource = PointOfSaleClass.ShowPOSTable();
            //Add Auto Numeric to Serial of PointOfSales
            for (int i = 0; i < dgvPOS.Rows.Count; i++)
            {
                //dgvPOS.Rows[i].Cells[0].Value = i + 1
                dgvPOS.Rows[i].Cells["POS"].Value = i + 1;
            }
            //Clear Text Box
            txtPOSName.Clear();
            //Clear Text Box
            txtPOSBalance.Clear();
            //Focus Of Text Box
            txtPOSName.Focus();
        }

        /// <summary>
        /// bool Function to check any Form Openned except Form Main
        /// Return True if Argument form name is openned except Main Form
        /// Return False if Form Main Only is Openned
        /// <returns>Return true or false</returns>
        /// </summary>
        /// <param name="frmName">Form Name</param>
        /// <returns></returns>
        private bool CheckFormOpenned(string frmName)
        {
            //Loop in all forms in Application.OpenForms
            foreach (Form frm in Application.OpenForms)
            {
                // if Form.Name is not equal Main Form
                if (frm.Name != "FRM_Main" && frm.Name != "FRM_Intro")
                {
                    //Check if Purchases Form Opened
                    if (frm.Name == frmName)
                    {
                        //Return True
                        return true;
                    }
                }
            }
            // if Main Form is openned Only Return False
            return false;
        }

        //AddItemGenericForm Method To Add New Generic Form to ItemGenericForm Table
        private void AddPointOfSale()
        {
            try
            {
                //Check all required fields are filled or not
                if (txtPOSName.Text == string.Empty)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Focus on textbox
                    txtPOSName.Focus();

                    //Stop executing block code
                    return;
                }

                //check Duplicate of PointOfSale in datagridview by for loop
                for (int i = 0; i <= dgvPOS.Rows.Count - 1; i++)
                {
                    //if dgvGeneric.Rows[i].Cells[1].Value.ToString() is equal txtGenericName.Text
                    if (dgvPOS.Rows[i].Cells["POSName"].Value.ToString() == txtPOSName.Text)
                    {
                        //Warning Message Box
                        NotificationSMS.NotifyShow("هذة النقطة تم إضتافتها من قبل", "تنبية",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();

                        //Focus on textbox
                        txtPOSName.Focus();

                        //Stop to executing block code
                        return;
                    }
                }

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //if txtPOSBalance.text is empty initialize zero value "0"
                if (txtPOSBalance.Text == string.Empty) txtPOSBalance.Text = "0";

                //Save or Add new PointOfSale to Database ItemID.ToString("FormatName-000000")
                PointOfSaleClass.SavePOS(PointOfSaleClass.GeneratePOSID(), PointOfSaleClass.GeneratePOSID().ToString("POSI-000000"),txtPOSName.Text,
                    Convert.ToDecimal(txtPOSBalance.Text),IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"),
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
            try
            {
                if (CheckFormOpenned("FRM_Payment") == true)
                {
                    //Close Form
                    this.Close();
                }
                else
                {
                    //Used Method To Bring background image of Main form to Front
                    FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                    //check if field you are created is null when closed form if not Assign null value to field
                    if (POSAccessFRM != null) POSAccessFRM = null;
                    //Close Form
                    this.Close();
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

        //dgvGeneric_CellContentClick Method to Delete any record of POS Table
        private void dgvPOS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Delete btn is 3
                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    //Set Delete Radion Button in Message Box
                    NotificationSMS.NotifyShow("الحذف", FRM_Notifications.NotifyIcons.Question,
                        FRM_Notifications.NotifyButtons.YesNo);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();


                    //if user select Yes Button and Select Delete itemGeneric From Database
                    if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                    {
                        //Delete PointOfSale From Database
                        PointOfSaleClass.DeletePOS(Convert.ToInt32(dgvPOS.CurrentRow.Cells[0].Value));

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
                        //declare string variable to store pc name and ip address
                        string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                            Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                        //Update PointOfSale Status to False in POS Table
                        PointOfSaleClass.DeactivatePOS(Convert.ToInt32(dgvPOS.CurrentRow.Cells[0].Value), false, IP_PCName, Program.UsrID);

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
        private void txtPOSName_KeyDown(object sender, KeyEventArgs e)
        {
            //if e.KeyCode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Focus on txtPOSBalance
                txtPOSBalance.Focus();
            }
        }

        //txtPOSBalance_KeyDown to Recall Method btnSave_Click(sender, e); 
        private void txtPOSBalance_KeyDown(object sender, KeyEventArgs e)
        {
            //if e.KeyCode == Keys.Enter
            if (e.KeyCode == Keys.Enter)
            {
                //Add New AddPointOfSale to POS Table
                AddPointOfSale();
            }
        }

        //dgvPOS_VisibleChanged Method to InitializeDGV and Add Serial of PointOfSales
        private void dgvPOS_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //Set Properties OF DataGridView
                InitializeDGV();
                //ClearControls();
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

        //dgvPOS_DoubleClick Method to Show any record of POS Table
        private void dgvPOS_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Assign Value of dgvPOS.CurrentRow.Cells["POSName"].Value.ToString() to txtPOSName
                txtPOSName.Text = dgvPOS.CurrentRow.Cells["POSName"].Value.ToString();
                //Assign Value of dgvPOS.CurrentRow.Cells["POSBalance"].Value.ToString() to txtPOSBalance
                txtPOSBalance.Text = dgvPOS.CurrentRow.Cells["POSBalance"].Value.ToString();
                //Define the index of start selection is equal Zero
                txtPOSName.SelectionStart = 0;
                //Define the length of selection is equal txtPOSName.Text.Length
                txtPOSName.SelectionLength = txtPOSName.Text.Length;
                //Focus on txtPOSName
                txtPOSName.Focus();
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
