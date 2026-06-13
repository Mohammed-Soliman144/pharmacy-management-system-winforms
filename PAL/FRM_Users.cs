using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// to Get IP address of local pc Domain Name System (Dns) Dns.GetHostAddresses(Environment.MachineName)[0].ToString()
using System.Net;  


namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Users : Form
    {
        #region Public Declaration
        //Create New Instance From BAL.CLS_Users Business Access Layer
        readonly BAL.CLS_Users UsersClass = new BAL.CLS_Users();
        //Create New Instance From BAL.CLS_Rules Business Access Layer
        readonly BAL.CLS_Rules RulesClass = new BAL.CLS_Rules();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        //Declare Image Variable as access Modifier private
        readonly Image img;
        #endregion

        #region Using Object Oriented Programing to access Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Users UserAccessFRM;

        //Create UserAccess_FormClosed to recall it when close form
        private static void UsersAccess_FormClosed (object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            UserAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Users UserAccess_Property
        {
            //used getter to return value of FRM_Users 
            get
            {
                //if created instance or field is null
                if (UserAccessFRM == null)
                {
                    //if field is null so Create New Instance From FRM_Users by initialize it to field
                    UserAccessFRM = new FRM_Users();
                    //Generate Event of Form Closed and Delegate Method UsersAccess_FormClosed to it
                    UserAccessFRM.FormClosed += new FormClosedEventHandler(UsersAccess_FormClosed);
                }
                //Return the value of field
                return UserAccessFRM;
            }
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_Users()
        /// </summary>
        public FRM_Users()
        {
            InitializeComponent();
            /*After Method of InitializeComponent inside constructor of FRM_Users
             * Check if Field you are created is null so intialize value of FRM_Users to it
             */
            if (UserAccessFRM == null) UserAccessFRM = this;
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = UsersClass.GenerateUserID().ToString("User-000000");
            //Focus on txtFullName
            txtFullName.Focus();
            //Void Method To Load ComboBox or fill ComboGender
            LoadComboBox();
            //Store Image of Picture box in Image Variable
            img = pbUsers.Image;
        }

        #region Method and Fuctions

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //loop in all controls of form by foreach loop
            foreach (Control ctrl in this.pnlUsers.Controls) 
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Enabled == true && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderUsers.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                //if Ctrl is ComboBox and Ctrl is Enabled and Ctrl is Empty
                else if (ctrl is ComboBox && ctrl.Enabled == true && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderUsers.SetError(ctrl, "هذا الحقل اجبارى");
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
            errProviderUsers.Clear();
            //loop in all control in side this.pnlUsers.Controls
            foreach (Control ctrl in this.pnlUsers.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                else if (ctrl is ComboBox) ctrl.ResetText();
                else if (ctrl is RadioButton) { rbtnIsUser.Checked = false; rbtnNotUser.Checked = true; }
                else if (ctrl is PictureBox && pbUsers.Image != img) pbUsers.Image = img;
            }
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = UsersClass.GenerateUserID().ToString("User-000000");
            //Focus on txtFullName
            txtFullName.Focus();
        }

       //Void Method To Load ComboBox or fill ComboGender
        void LoadComboBox()
        {
            //declare array of string to fill combobox gender
            string[] strgender = new string[2] { "ذكر", "انثى" };
            //Initialize strgender array is Datasource of comboGender
            comboGender.DataSource = strgender;
            //Initialize -1 is Selected index of ComboGender to select empty cause no any item start index from -1
            comboGender.SelectedIndex = -1;
            comboJob.SelectedIndex = -1;
        }

        void FillComboRules()
        {
            if (RulesClass.ShowRulesTable().Rows.Count == 0)
            {
                comboRule.Items.Clear();
                comboRule.Items.Add("لا توجد صلاحيات");
            }
            else
            {
                //Initialize DataSource of combo is SupplierClass.ShowSuppliersTable();
                comboRule.DataSource = RulesClass.ShowRulesTable();
                //Initialize DisplayMember of combo is RuleName
                comboRule.DisplayMember = "RuleName";
                //Initialize ValueMember of combo is RuleID
                comboRule.ValueMember = "RuleID";
                //To Clear ComboBox of comboSupplier by selected index equal -1  
                comboRule.SelectedIndex = -1;
            }
        }

        //btnExit_Click Method To Close FRM_Users
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (UserAccessFRM != null) UserAccessFRM = null;
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

        //btnClose_Click Method To Close FRM_Users
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (UserAccessFRM != null) UserAccessFRM = null;
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

        //btnNew_Click Method To Clear Controls
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

        //txtFullName_KeyPress Method to allow user enter Alphabit Characters and backSpace
        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                /* Keypress deal with keychar but keyDown and KeyUp deal with keycode
                 * e.handled = true is permit but e.handled = false is allow*/
                //if Input entry is not equal leter and backspace and space permit user to edit 
                if (!Char.IsLetter(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != (char)Keys.Space)
                {
                    //do not allow user to enter any characters except alphabit characters and backSpace
                    e.Handled = true;
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

        //txtPhone_KeyPress Method to allow user enter numbers Characters and backSpace
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                //if input entry is not equal number and backspace permit user to edit it
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)Keys.Back)
                {
                    //permit user to edit it
                    e.Handled = true;
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

        //rbtnIsUser_CheckedChanged Method to define if user entered is user for program or not
        private void rbtnIsUser_CheckedChanged(object sender, EventArgs e)
        {
            //if new user is user for program
            if (rbtnIsUser.Checked == true)
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
            else //if new user is not user for program
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
        }

        //txtFullName_Validated Method To Validation Input entry 
        private void txtFullName_Validated(object sender, EventArgs e)
        {
            //if input entry is less than 7 index or 6 letters
            if (txtFullName.Text.Length < 7)
            {
                //Set Errors of Error Provider (controlName, ErrorMessage)
                errProviderUsers.SetError(txtFullName, "يجب إدخال اسم ثنائى على الأقل");
                //define index of SelectionStart
                txtFullName.SelectionStart = 0;
                //Define index of Selection Length = control.TextLength
                txtFullName.SelectionLength = txtFullName.TextLength;
                //Focus on control
                txtFullName.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            //if input entry is more than 7 index or 6 letters 
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(txtFullName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtAddress_Validated Method To Validation Input entry
        private void txtAddress_Validated(object sender, EventArgs e)
        {
            // if txtAddress is empty
            if (txtAddress.Text == string.Empty)
            {
                //Set Errors of Error Provider (controlName, ErrorMessage)
                errProviderUsers.SetError(txtAddress, "يجب ملأ هذا الحقل");
                //define index of SelectionStart
                txtAddress.SelectionStart = 0;
                //Define index of Selection Length = control.TextLength
                txtAddress.SelectionLength = txtAddress.TextLength;
                //Focus on control
                txtAddress.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(txtAddress, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtPhone_Validated Method To Validation Input entry
        private void txtPhone_Validated(object sender, EventArgs e)
        {
            // if txtPhone is less than 11 index or 10 count characters
            if (txtPhone.Text.Length < 11)
            {
                errProviderUsers.SetError(txtPhone, "يجب إدخال رقم مكون من 11 رقم");
                txtPhone.SelectionStart = 0;
                txtPhone.SelectionLength = txtPhone.TextLength;
                txtPhone.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                errProviderUsers.SetError(txtPhone, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtNatID_Validated Method To check validation input entry
        private void txtNatID_Validated(object sender, EventArgs e)
        {
            //if txtNatID less han 14 index or start with zero or startwith one
            if (txtNatID.Text.Length < 14 || txtNatID.Text.StartsWith("0") || txtNatID.Text.StartsWith("1"))
            {
                errProviderUsers.SetError(txtNatID, "يجب إدخال رقم مكون من 14 رقم");
                txtNatID.SelectionStart = 0;
                txtNatID.SelectionLength = txtNatID.TextLength;
                txtNatID.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(txtNatID, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboJob_Validated Method To check validation input entry
        private void comboJob_Validated(object sender, EventArgs e)
        {
            //comboJob.text is empty
            if (comboJob.Text == string.Empty)
            {
                errProviderUsers.SetError(comboJob, "يجب تحديد وظيفة المستخدم");
                comboJob.SelectionStart = 0;
                comboJob.SelectionLength = comboJob.SelectionLength;
                comboJob.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(comboJob, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboGender_Validated Method To check validation input entry
        private void comboGender_Validated(object sender, EventArgs e)
        {
            // if comboGender.text is empty
            if (comboGender.Text == string.Empty)
            {
                errProviderUsers.SetError(comboGender, "يجب تحديد نوع المستخدم");
                comboGender.SelectionStart = 0;
                comboGender.SelectionLength = comboGender.SelectionLength;
                comboGender.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(comboGender, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        // txtUserName_Validated Method To check validation input entry
        private void txtUserName_Validated(object sender, EventArgs e)
        {
            //if txtUserName.text is empty
            if (txtUserName.Text == string.Empty)
            {
                errProviderUsers.SetError(txtUserName, "يجب إدخال اسم المستخدم");
                txtUserName.SelectionStart = 0;
                txtUserName.SelectionLength = txtUserName.TextLength;
                txtUserName.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(txtUserName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtPassword_Validated Method To check validation input entry
        private void txtPassword_Validated(object sender, EventArgs e)
        {
            // txtPassword.text is empty or password is less than 4 index or three characters
            if (txtPassword.Text == string.Empty || txtPassword.Text.Length < 4)
            {
                errProviderUsers.SetError(txtPassword, "يجب إدخال رقم سرى مكون من 4 ارقام على الأقل");
                txtPassword.SelectionStart = 0;
                txtPassword.SelectionLength = txtPassword.TextLength;
                txtPassword.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else
            {
                //Initialize empty error message to error provider to hide it
                errProviderUsers.SetError(txtPassword, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtFullName_KeyDown Method to Move Next Control txtAddress
        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            // if user press on enter
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control
                txtAddress.Focus();
            }
        }

        //txtAddress_KeyDown Method to Move Next Control txtPhone
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        //txtPhone_KeyDown Method to Move Next Control txtNatID
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNatID.Focus();
            }
        }

        //txtNatID_KeyDown Method to Move Next Control comboJob
        private void txtNatID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboJob.Focus();
            }
        }

        //comboJob_KeyDown Method to Move Next Control comboGender
        private void comboJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboGender.Focus();
            }
        }

        //comboGender_KeyDown Method to Move Next Control txtUserName
        private void comboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && rbtnIsUser.Checked == true)
            {
                txtUserName.Focus();
            }
        }

        //txtUserName_KeyDown Method to Move Next Control txtPassword
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        //btnSelect_Click Method to Select Image
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new Instanc e From OpenFileDialog()
                OpenFileDialog ofd = new OpenFileDialog();
                //Define Extension of Images by OFD.Filter
                ofd.Filter = "JPG Files|*.JPG; *.JPE; *JPEG; *.JFIF; |PNG Files|*.PNG; |TIF Files|*.TIF; *.TIFF;" +
                                "|BMP Files|*.BMP; |GIF Files|*.GIF;";
                //Initialize Filter Index which need to Select as First
                ofd.FilterIndex = 1;
                //if user select image and press ok
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Set PictureBox.SizeMode = PictureSizeMode.StretchImage
                    pbUsers.SizeMode = PictureBoxSizeMode.StretchImage;
                    //load picturebox.Image = Image.FromFile(OFD.FileName)
                    pbUsers.Image = Image.FromFile(ofd.FileName);
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

        //bnClear_Click Method To Clear Image From PictureBox
        private void bnClear_Click(object sender, EventArgs e)
        {
            //if pbUsers.image is not equal img Default reset it
            if (pbUsers.Image != img)
            {
                pbUsers.Image = img;
            }
            else return;
        }

        //btnSave_Click Method To Save New User
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in users table + 1 
                //lblID.Text.Contains(UsersClass.GenerateUserID().ToString() New User ID) Do not modify
                if (!lblID.Text.Contains(UsersClass.GenerateUserID().ToString()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المستخدم تم إضتافته من قبل", "تنبية",
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

                
                // If User Add Image to current User if(pbUsers.Image != Default image)
                if (pbUsers.Image != img)
                {
                    //Create New Instance From MemoryStream
                    MemoryStream MemStream = new MemoryStream();
                    //Save Image in picture box in memorystream
                    pbUsers.Image.Save(MemStream, pbUsers.Image.RawFormat);
                    //Create new array of byte[] to store it in database with define length of it [] {}
                    byte[] ImgByte = new byte[] { };
                    //Initialize image in memory stream to byte array after convert memory stream to array
                    ImgByte = MemStream.ToArray();

                    //New User is user For Program is true or rbtnIsUser.Checked
                    if (rbtnIsUser.Checked == true)
                    {
                        UsersClass.SaveUsers(UsersClass.GenerateUserID(), comboRule.SelectedIndex, lblID.Text, txtFullName.Text,
                                        txtPhone.Text, comboJob.Text, comboGender.Text, txtAddress.Text,
                                        txtNatID.Text, rbtnIsUser.Checked, txtUserName.Text, txtPassword.Text,
                                        DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"), "WithImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                    //New User is not user For Program is false
                    else
                    {
                        //NULL in SQL Server equal "'NULL'" in c#
                        UsersClass.SaveUsers(UsersClass.GenerateUserID(), comboRule.SelectedIndex, lblID.Text, txtFullName.Text,
                                        txtPhone.Text, comboJob.Text, comboGender.Text, txtAddress.Text,
                                        txtNatID.Text, false, string.Empty, string.Empty,
                                        DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"),
                                        "WithImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                }
                // If User did not Add Image to current User
                else
                {
                    //Create new array of byte[] is Null byte without elements
                    byte[] ImgByte = new byte[] { };
                    //New User is user For Program
                    if (rbtnIsUser.Checked == true)
                    {
                        UsersClass.SaveUsers(UsersClass.GenerateUserID(),comboRule.SelectedIndex, lblID.Text, txtFullName.Text,
                                        txtPhone.Text, comboJob.Text, comboGender.Text, txtAddress.Text,
                                        txtNatID.Text, rbtnIsUser.Checked, txtUserName.Text, txtPassword.Text,
                                        DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"),
                                        "WithoutImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                    //New User is not user For Program
                    else
                    {
                        UsersClass.SaveUsers(UsersClass.GenerateUserID(), comboRule.SelectedIndex, lblID.Text, txtFullName.Text,
                                        txtPhone.Text, comboJob.Text, comboGender.Text, txtAddress.Text,
                                        txtNatID.Text, false, string.Empty, string.Empty,
                                        DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"),
                                        "WithoutImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                }
                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ المستخدم بنجاح", "عملية الحفظ",
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
                toolTipUsers.SetToolTip(btnVisible, "إخفاء كلمة المرور"); //
            }
            //if txtpassword is not empty and txtPassword.PasswordChar != '*'
            else if (txtPassword.Text != string.Empty && txtPassword.PasswordChar != '*')
            {
                //Initialize '*' Value to PasswordChar
                txtPassword.PasswordChar = '*';
                //Change Background image of btnvisible
                btnVisible.BackgroundImage = Properties.Resources.Invisible;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipUsers.SetToolTip(btnVisible, "عرض كلمة المرور");
            }
        }

        //btnAdd_Click Method To Add New Job From FRM_UserJob
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Initialize Empty Item to Combobox by selectedIndex -1
            comboJob.SelectedIndex = -1;
            //Create new Instance From FRM_UserJob();
            FRM_UserJob frmJob = new FRM_UserJob();
            //Show this instance in mode ShowDialog to control it as first
            frmJob.ShowDialog();
        }

        //comboJob_DropDown Method to load all item of Properties.Settings.Default.UserJobs.Cast<string>().ToList() to Combobox
        private void comboJob_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.UserJobs.Cast<string>().ToList().Count == 0)
                {
                    comboJob.Items.Clear();
                    comboJob.Items.Add("لا توجد وظائف");
                }
                else
                {
                    //Initialize Properties.Settings.Default.UserJobs is Datasource of comboJob after Cast<Generic string class>().Tolist();
                    comboJob.DataSource = Properties.Settings.Default.UserJobs.Cast<string>().ToList();
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

        //btnSearch_Click Method to Search In Users Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_UserSearch
            FRM_UserSearch SearchForm = new FRM_UserSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //btnModify_Click Method To Modify User
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(UsersClass.GenerateUserID().ToString() New User ID) Do not modify
                if (lblID.Text.Contains(UsersClass.GenerateUserID().ToString()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المستخدم لم يتم إضافته بعد", "تنبية",
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

                //Declare int Variable to store Current UserID
                /* Convert.ToInt32(lblID.Text.Remove(0, 5)) 
                    * Remove is String Function (startRemoveIndex, Count of Remove is 5 Characters equal "User-")
                    * Retuns string Value 000012 when convert.ToInt32(000012) = 12 
                    * zero on left without meaning in numbers */
                int CurrentID = Convert.ToInt32(lblID.Text.Remove(0, 5));


                // (pbUsers.Image != Default image)
                if (pbUsers.Image != img)
                {
                    //Create New Instance From MemoryStream
                    MemoryStream MemStream = new MemoryStream();
                    //Save Image in picture box in memorystream
                    pbUsers.Image.Save(MemStream, pbUsers.Image.RawFormat);
                    //Create new array of byte[] to store it in database with define length of it [] {}
                    byte[] ImgByte = new byte[] { };
                    //Initialize image in memory stream to byte array after convert memory stream to array
                    ImgByte = MemStream.ToArray();

                    //New User is user For Program is true or rbtnIsUser.Checked
                    if (rbtnIsUser.Checked == true)
                    {
                        //Modify Users Table
                        UsersClass.UpdateUsers(CurrentID, comboRule.SelectedIndex, txtFullName.Text, txtPhone.Text, comboJob.Text,
                                        comboGender.Text, txtAddress.Text, txtNatID.Text, true, txtUserName.Text,
                                        txtPassword.Text, "WithImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                    //New User is not user For Program is false
                    else
                    {
                        //Modify Users Table
                        UsersClass.UpdateUsers(CurrentID, comboRule.SelectedIndex, txtFullName.Text, txtPhone.Text, comboJob.Text,
                                        comboGender.Text, txtAddress.Text, txtNatID.Text, false, string.Empty,
                                        string.Empty, "WithImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                }
                // If User did not Add Image to current User
                else
                {
                    //Create new array of byte[] is Null byte without elements
                    byte[] ImgByte = new byte[] { };

                    //New User is user For Program
                    if (rbtnIsUser.Checked == true)
                    {
                        //Modify Users Table
                        UsersClass.UpdateUsers(CurrentID, comboRule.SelectedIndex, txtFullName.Text, txtPhone.Text, comboJob.Text,
                                        comboGender.Text, txtAddress.Text, txtNatID.Text, true, txtUserName.Text,
                                        txtPassword.Text, "WithoutImage", ImgByte, IP_PCName, Program.UsrID);

                    }
                    //New User is not user For Program
                    else
                    {
                        //Modify Users Table
                        UsersClass.UpdateUsers(CurrentID, comboRule.SelectedIndex, txtFullName.Text, txtPhone.Text, comboJob.Text,
                                        comboGender.Text, txtAddress.Text, txtNatID.Text, false, string.Empty,
                                        string.Empty, "WithoutImage", ImgByte, IP_PCName, Program.UsrID);
                    }
                }
                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل المستخدم بنجاح", "عملية التعديل",
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

        //btnDelete_Click Method to Delete User
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(UsersClass.GenerateUserID().ToString() New User ID) Do not modify
                if (lblID.Text.Contains(UsersClass.GenerateUserID().ToString()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المستخدم لم يتم إضافته بعد", "تنبية",
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

                //Declare int Variable to store Current UserID
                /* Convert.ToInt32(lblID.Text.Remove(0, 5)) 
                    * Remove is String Function (startRemoveIndex, Count of Remove is 5 Characters equal "User-")
                    * Retuns string Value 000012 when convert.ToInt32(000012) = 12 
                    * zero on left without meaning in numbers */
                int CurrentID = Convert.ToInt32(lblID.Text.Remove(0, 5));


                //if user select Yes Button and Select Delete User From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete User From Database
                    UsersClass.DeleteUsers(CurrentID);

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف المستخدم بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                }
                //if user select Yes Button and Select InActivate User From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Users Table
                    UsersClass.InActivateUsers(CurrentID, false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف المستخدم بشكل مؤقت بنجاح", "عملية الحذف",
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

        //timerUsers_Tick Method to Control Font Size of lblUserStatus with every tick of Timer.interval
        private void timerUsers_Tick(object sender, EventArgs e)
        {
            try
            {
                /* Set in Properties Interval of timer = 500 */
                //if visible of lblUserStatus is not equal true ==> stop to executing block code
                if (lblUserStatus.Visible != true) return;
                //if interval of timer equal 500
                if (timerUsers.Interval == 500)
                {
                    //Change Font of lblUserStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblUserStatus.Font = new Font("LBC", 14, FontStyle.Bold);
                    //Change location of lblUserStatus by  initialize new point (x,y)
                    lblUserStatus.Location = new Point(4, 105);
                    //change interval of timer to 1000
                    timerUsers.Interval = 1000;
                }
                //if interval of timer equal 1000
                else if (timerUsers.Interval == 1000)
                {
                    //Change Font of lblUserStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblUserStatus.Font = new Font("LBC", 16, FontStyle.Bold);
                    //Change location of lblUserStatus by  initialize new point (x,y)
                    lblUserStatus.Location = new Point(4, 90);
                    //change interval of timer to 500
                    timerUsers.Interval = 500;
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show(timerUsers.Interval.ToString()); test
                //Save Catching Exception in Exceptions Table
                ErrHandlingClass.SaveExceptions(err.Message.ToString(), err.GetType().ToString(), err.StackTrace.ToString());
                //Show Notification of System Message
                NotificationSMS.NotifySystemShow(err.Message);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
        }

        //lblUserActivate_Click Method to Activate User
        private void lblUserActivate_Click(object sender, EventArgs e)
        {
            try
            {

                //Declare int variable to store current internal user id
                int CurrentID = Convert.ToInt32(lblID.Text.Remove(0, 5));

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Update Status to False in Users Table
                UsersClass.InActivateUsers(CurrentID, false, IP_PCName, Program.UsrID);

                //Initialize false Value to Visible of lblUserStatus
                lblUserStatus.Visible = false;
                //Initialize false Value to Visible of lblUserActivate
                lblUserActivate.Visible = false;
                //Initialize true Value to Enabled of btnDelete
                btnDelete.Enabled = true;
                //Initialize False true to Enabled of btnModify
                btnModify.Enabled = true;
                //Stop Timer
                timerUsers.Stop();
                //Initialize false Value to Enabled of timerUsers
                timerUsers.Enabled = false;

                //Alarm Success activate Message Box 
                NotificationSMS.NotifyShow("تم تفعيل المستخدم بنجاح", "تنبية",
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

        //rbtnNotUser_CheckedChanged Method if User is not user for program
        private void rbtnNotUser_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if txtUserName or txtPassword is not equal empty and rbtnNotUser.checked is true
                if (txtUserName.Text != string.Empty || txtPassword.Text != string.Empty && rbtnNotUser.Checked == true)
                {
                    //clear txtUserName
                    txtUserName.Clear();
                    //clear txtPassword
                    txtPassword.Clear();
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

        private void comboRule_DropDown(object sender, EventArgs e)
        {
            try
            {
                FillComboRules();
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

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (UserAccessFRM != null) UserAccessFRM = null;
                //Close Form
                this.Close();
                ////Used btnCustomers_Click Method To Move FRM_Rules by Encapsulation is FRM_Main.ObjectMain_Property
                //FRM_Main.ObjectMain_Property.btnRules_Click(sender, e);
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
    }
}
