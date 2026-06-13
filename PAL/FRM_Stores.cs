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
    public partial class FRM_Stores : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoresClass = new BAL.CLS_Stores();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Stores Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Stores StoreAccessFRM;

        //Create StoreAccess_FormClosed to recall it when close form
        private static void StoreAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            StoreAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Stores StoreAccess_Property
        {
            //used getter to return value of FRM_Stores 
            get
            {
                //if created instance or field is null
                if (StoreAccessFRM == null)
                {
                    //Create New Instance From FRM_Stores by initialize it to field
                    StoreAccessFRM = new FRM_Stores();
                    //Generate Event of Form Closed and Delegate Method StoreAccess_FormClosed to it
                    StoreAccessFRM.FormClosed += new FormClosedEventHandler(StoreAccess_FormClosed);
                }
                //Return the value of field
                return StoreAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Stores
        public FRM_Stores()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Stores to it 
            if (StoreAccessFRM == null) StoreAccessFRM = this;
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = StoresClass.GenerateStoreID();
            //Focus on txtName
            txtName.Focus();
        }

        #region Methods and Fuctions

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //loop in all controls of form in pnlStores.Controls by foreach loop
            foreach (Control ctrl in this.pnlStores.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl != txtAddress && ctrl != txtPhone
                    && ctrl != txtPassword && ctrl != txtCapacity)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderStores.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                //if Ctrl is ComboBox and Ctrl is Empty and ctrl is not equal comboManager
                else if (ctrl is ComboBox && ctrl.Text == string.Empty && ctrl != comboManager)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderStores.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }

            //Return Counter of error
            return CountOfErrors;
        }

        /// <summary>
        /// Method to loop of controls and Reset it to Default Values
        /// </summary>
        void ClearControls()
        {
            //Clear Error Provider
            errProviderStores.Clear();
            //loop in all control in side this.pnlStores.Controls
            foreach (Control ctrl in this.pnlStores.Controls)
            {
                //Clear Textbox
                if (ctrl is TextBox) ctrl.ResetText();
                //Clear ComboBox
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlControls.Controls)
            {
                if (ctrl is Button && ctrl.Enabled == false) ctrl.Enabled = true;
            } 
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = StoresClass.GenerateStoreID();
            //Focus on txtName
            txtName.Focus();
        }

        /// <summary>
        /// Void Method to Load Users Table
        /// </summary>
        void LoadComboBox(ComboBox combo, DataTable dt, string displayColName, string valueColName)
        {
            //Initialize DataSource of combo is DataTable;
            combo.DataSource = dt;
            //Initialize DisplayMember of combo is display Column Name like UserName
            combo.DisplayMember = displayColName;
            //Initialize ValueMember of combo is value Column Name like UserID
            combo.ValueMember = valueColName;

        }

        //btnNew_Click Method To Clear Controls of Form
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear all Control by method ClearControls()
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

        //btnModify_Click Method To Update Stores
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(StoresClass.GenerateStoreID() New Store ID) Do not modify
                if (lblID.Text.Contains(StoresClass.GenerateStoreID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المحزن لم يتم إضافته بعد", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                // catchEmptyFields Int Function to return number of errors 
                //and to Set Error Provider and lanuch Alarm Message Box
                //if counter of error greater than zero
                if (CatchEmptyFields() > 0)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop executing block code
                    return;
                }

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Modify Stores Table
                StoresClass.UpdateStores(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtName.Text, txtPhone.Text,
                                         txtAddress.Text, comboType.Text, txtPassword.Text,
                                         Convert.ToInt32(comboManager.SelectedValue),
                                         Convert.ToInt32(comboBranch.SelectedValue),
                                         Convert.ToInt32(txtCapacity.Text),
                                         IP_PCName, Program.UsrID);


                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم المخزن المورد بنجاح", "عملية التعديل",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Recall Btn New to clear Controls
                btnNew_Click(sender, e);
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

        //btnSave_Click Method To Save New Store
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in Stores table + 1 
                //lblID.Text.Contains(StoresClass.GenerateStoreID().ToString() New Store ID) Do not modify
                if (!lblID.Text.Contains(StoresClass.GenerateStoreID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المخزن تم إضتافته من قبل", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                //catchEmptyFields Int Function to return number of errors
                //and to Set Error Provider and lanuch Alarm Message Box
                //if counter of error greater than zero
                if (CatchEmptyFields() > 0)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop executing block code
                    return;
                }

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Add New Supplier to Stores Table
                StoresClass.SaveStores
                    (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, txtName.Text, txtPhone.Text, txtAddress.Text, comboType.Text,
                    txtPassword.Text, Convert.ToInt32(comboManager.SelectedValue),
                    Convert.ToInt32(comboBranch.SelectedValue),Convert.ToInt32(txtCapacity.Text), IP_PCName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ المخزن بنجاح", "عملية الحفظ",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Recall Btn New to clear Controls
                btnNew_Click(sender, e);

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

        //btnDelete_Click Method To Delet Store by Delete Record or Deactivate Store
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(StoresClass.GenerateStoreID().ToString() New Store ID) Do not modify
                if (lblID.Text.Contains(StoresClass.GenerateStoreID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المخزن لم يتم إضافته بعد", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                //Set Delete Radion Button in Message Box
                NotificationSMS.NotifyShow("الحذف", FRM_Notifications.NotifyIcons.Question,
                    FRM_Notifications.NotifyButtons.YesNo);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();


                //if user select Yes Button and Select Delete Store From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Store From Database
                    StoresClass.DeleteStores(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف المخزن بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Yes Button and Select InActivate Store From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Stores Table
                    StoresClass.DeactivateStores(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف المخزن بشكل مؤقت بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Exit Button
                else if (NotificationSMS.NotifyResult == false)
                {
                    //Stop Executing Block Code
                    return;
                }

                //Recall Btn New to clear Controls
                btnNew_Click(sender, e);
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

        //btnExit_Click Method To Close Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (StoreAccessFRM != null) StoreAccessFRM = null;
                //Close Form
                this.Close();
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

        //btnSearch_Click Method To Search in Stores Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Recall Method comboManager_DropDown (object sender, EvenArgs e) of Event ComboBox.DropDown
            comboManager_DropDown(sender, e);
            //index of any element starts from Zero
            //To Clear ComboBox of comboManager by selected index equal -1  
            comboManager.SelectedIndex = -1;
            //Recall Method comboBranch_DropDown (object sender, EvenArgs e) of Event ComboBox.DropDown
            comboBranch_DropDown(sender, e);
            //To Clear ComboBox of comboManager by selected index equal -1  
            comboBranch.SelectedIndex = -1;

            //Create new instance from FRM_StoreSearch
            FRM_StoreSearch SearchForm = new FRM_StoreSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //lblUserActivate_Click Method to Activate Store
        private void lblStoreActivate_Click(object sender, EventArgs e)
        {
            try
            {
                //Declare int variable to store current internal user id
                int CurrentID = Convert.ToInt32(lblID.Text.Remove(0, 5));

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Update Status to False in Stores Table
                StoresClass.DeactivateStores(CurrentID, false, IP_PCName, Program.UsrID);

                //Initialize false Value to Visible of lblStoreStatus
                lblStoreStatus.Visible = false;
                //Initialize false Value to Visible of lblStoreActivate
                lblStoreActivate.Visible = false;
                //Initialize true Value to Enabled of btnDelete
                btnDelete.Enabled = true;
                //Initialize False true to Enabled of btnModify
                btnModify.Enabled = true;
                //Stop Timer
                timerStores.Stop();
                //Initialize false Value to Enabled of timerStores
                timerStores.Enabled = false;

                //Alarm Success activate Message Box 
                NotificationSMS.NotifyShow("تم تفعيل المخزن بنجاح", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

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

        //timerUsers_Tick Method to Control Font Size of lblStoreStatus with every tick of Timer.interval
        private void timerStores_Tick(object sender, EventArgs e)
        {
            try
            {
                /* Set in Properties Interval of timer = 500 */
                //if visible of lblStoreStatus is not equal true ==> stop to executing block code
                if (lblStoreStatus.Visible != true) return;
                //if interval of timer equal 500
                if (timerStores.Interval == 500)
                {
                    //Change Font of lblStoreStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblStoreStatus.Font = new Font("LBC", 14, FontStyle.Bold);
                    //Change location of lblStoreStatus by  initialize new point (x,y)
                    lblStoreStatus.Location = new Point(4, 105);
                    //change interval of timer to 1000
                    timerStores.Interval = 1000;
                }
                //if interval of timer equal 1000
                else if (timerStores.Interval == 1000)
                {
                    //Change Font of lblStoreStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblStoreStatus.Font = new Font("LBC", 16, FontStyle.Bold);
                    //Change location of lblStoreStatus by  initialize new point (x,y)
                    lblStoreStatus.Location = new Point(4, 90);
                    //change interval of timer to 500
                    timerStores.Interval = 500;
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

        //btnVisible_Click Method To Visible passwordchar by set '\0' value or invisible '*'
        private void btnVisible_Click(object sender, EventArgs e)
        {
            //if txtpassword is not empty and txtPassword.PasswordChar == '*'
            if (txtPassword.Text != string.Empty && txtPassword.PasswordChar == '*')
            {
                //Initialize empty Value to PasswordChar empty in char datatype equal '\0'
                txtPassword.PasswordChar = '\0';
                //Change Background image of btnvisible
                btnVisible.BackgroundImage = Properties.Resources.Visiable;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipStores.SetToolTip(btnVisible, "إخفاء كلمة المرور"); //
            }
            //if txtpassword is not empty and txtPassword.PasswordChar != '*'
            else if (txtPassword.Text != string.Empty && txtPassword.PasswordChar != '*')
            {
                //Initialize '*' Value to PasswordChar
                txtPassword.PasswordChar = '*';
                //Change Background image of btnvisible
                btnVisible.BackgroundImage = Properties.Resources.Invisible;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipStores.SetToolTip(btnVisible, "عرض كلمة المرور");
            }
        }

        //txtName_TextChanged Method to hide error provider
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // if txtName is not equal Empty
            if (txtName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderStores.SetError(txtName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtName_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtAddress.Focus();
            }
        }

        //txtAddress_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone.Focus();
            }
        }

        //txtPhone_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtPhone_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboManager.Focus();
            }
        }

        //comboManager_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboManager_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboBranch.Focus();
            }
        }

        //comboType_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboType_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPassword.Focus();
            }
        }

        //comboType_SelectedIndexChanged Method to hide error provider
        private void comboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if txtName is not equal Empty
            if (comboType.SelectedIndex != -1)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderStores.SetError(comboType, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
            //if store is protected store
            if (comboType.SelectedIndex == 2)
            {
                //Set Enabled of txtPassword is true
                txtPassword.Enabled = true;
            }
            else
            {
                //Set Enabled of txtPassword is false
                txtPassword.Enabled = false;
            }
        }

        //comboManager_DropDown Method to Load Users Table
        private void comboManager_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_Users
            BAL.CLS_Users UserClass = new BAL.CLS_Users();
            //Load Users Table by Void Method LoadComboBox(ComboBoxName,DataTable,DisplayMember,ValueMember)
            LoadComboBox(comboManager, UserClass.ShowUsersTable(), "الاسم بالكامل", "كود الداخلى");
        }

        //comboBranch_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboBranch_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtCapacity.Focus();
            }
        }

        //comboBranch_SelectedIndexChanged Method to hide error provider
        private void comboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if txtName is not equal Empty
            if (comboType.SelectedIndex != -1)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderStores.SetError(comboType, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboBranch_DropDown Method to Load Branches Table 
        private void comboBranch_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_Branches
            BAL.CLS_Branches BranchClass = new BAL.CLS_Branches();
            //Load Users Table by Void Method LoadComboBox(ComboBoxName,DataTable,DisplayMember,ValueMember)
            LoadComboBox(comboBranch, BranchClass.ShowBranchesTable(), "اسم الفرع", "الكود الداخلى");
        }

        //txtCapacity_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCapacity_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboType.Focus();
            }
        }

        //btnClose_Click Method To Close FRM_Stores 
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Information Message Box
                MessageBox.Show("سيتم التوجة إلى شاشة تسجيل الدخول", "تنبية", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                //Create New Instance from FRM_Login() Derivation
                FRM_Login LoginForm = new FRM_Login();
                //Show Form Login is Dialog to Control of it as first
                LoginForm.ShowDialog();

                //check if field you are created is null when closed form if not Assign null value to field
                if (StoreAccessFRM != null) StoreAccessFRM = null;
                //Close Form
                this.Close();
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
