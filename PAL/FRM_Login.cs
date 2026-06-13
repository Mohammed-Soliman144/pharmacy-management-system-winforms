using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;//To Deal with Domain Name System to Get IP Address Dns.GetHostAddresses(Environment.MachineName)[0].ToString()

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Login : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Users Business Access Layer
        readonly BAL.CLS_Users UsersClass = new BAL.CLS_Users();
        //Create New Instance From CLS_Register Business Access Layer
        readonly BAL.CLS_Register RegClass = new BAL.CLS_Register();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //Declare Point Variable to set Last Location to control move Form in any location (with private modifier)
        private Point LastLocation;
        //Declare bool Variable to check if user Press on Panel to move From  by Mouse Dwon Event (with private modifier)
        private bool PressOnMouseDown;
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        /// <summary>
        /// Method to loop of controls and Reset it to Default Values
        /// </summary>
        void ClearControls()
        {
            //Clear Error Provider
            errProviderLogin.Clear();
            //Reset Controls of textbox
            txtUser.Text = "ادخل اسم المستخدم";
            txtPassword.Text = "ادخل كلمة المرور";
            txtPhone.Text = "يرجى ادخال رقم الهاتف";
        }

        //Void Method To Remember Save Settings of Login (username and password)
        void RememberOfLogin()
        {
            //declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
            //Check if PCName and IP Address Login to Software before or not
            if (RegClass.SearchUserRegister(IP_PCName).Rows.Count > 0)
            {
                txtUser.Text = RegClass.SearchUserRegister(IP_PCName).Rows[0]["UserName"].ToString();
                txtPassword.Text = RegClass.SearchUserRegister(IP_PCName).Rows[0]["UserPassword"].ToString();
            }
        }

        //Constructor of Login Form
        public FRM_Login()
        {
            InitializeComponent();
            //Hide the Intro Form
            FRM_Intro.IntroAccess_Property.Hide();
            //Method to loop of controls and Reset it to Default Values
            ClearControls();
            //Void Method To Remember Save Settings of Login (username and password)
            RememberOfLogin();
        }

        #region Methods and Fuctions are Finsihed

        //btnClose_Click to Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Exit of Application
            Application.Exit();
        }

        //btnDisplay_Click Method To Visible passwordchar by set '\0' value or invisible '*'
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            //if txtpassword is not empty and txtPassword.PasswordChar == '*'
            if (txtPassword.Text != "ادخل كلمة المرور" && txtPassword.PasswordChar == '*')
            {
                //Initialize empty Value to PasswordChar empty in char datatype equal '\0'
                txtPassword.PasswordChar = '\0';
                //Change Background image of btnvisible
                btnDisplay.BackgroundImage = Properties.Resources.EyeVisiblePic;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipLogin.SetToolTip(btnDisplay, "إخفاء كلمة المرور"); //
            }
            //if txtpassword is not empty and txtPassword.PasswordChar != '*'
            else if (txtPassword.Text != "ادخل كلمة المرور" && txtPassword.PasswordChar != '*')
            {
                //Initialize '*' Value to PasswordChar
                txtPassword.PasswordChar = '*';
                //Change Background image of btnvisible
                btnDisplay.BackgroundImage = Properties.Resources.EyeInvisiblePic;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipLogin.SetToolTip(btnDisplay, "عرض كلمة المرور");
            }
        }

        //txtUser_Enter Method to Clear txtUser
        private void txtUser_Enter(object sender, EventArgs e)
        {
            //if user Focus on textbox change Properties of textbox
            if (txtUser.Text == "ادخل اسم المستخدم")
            {
                //Clear textbox
                txtUser.Clear();
                //Change Properties of font
                txtUser.Font = new Font("LBC", 14, FontStyle.Regular);
            }
        }

        //txtPassword_Enter Method to Clear txtPassword
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            //if user Focus on textbox change Properties of textbox
            if (txtPassword.Text == "ادخل كلمة المرور")
            {
                //Clear textbox
                txtPassword.Clear();
                //Change Properties of font
                txtPassword.Font = new Font("LBC", 14, FontStyle.Regular);
            }
        }

        //txtUser_Leave Method to Reset Properties of txtUser
        private void txtUser_Leave(object sender, EventArgs e)
        {
            //if txtUser is equal empty
            if (txtUser.Text == string.Empty)
            {
                //Change text of txtUser is equal "ادخل اسم المستخدم"
                txtUser.Text = "ادخل اسم المستخدم";
            }
        }

        //txtPassword_Enter Method to Clear txtPassword
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            //if txtPassword is equal empty
            if (txtPassword.Text == string.Empty)
            {
                //Change text of txtPassword is equal "ادخل كلمة المرور"
                txtPassword.Text = "ادخل كلمة المرور";
            }
        }

        //txtPassword_TextChanged Method to change Properties of txtbox password
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            //if txtbox password is equal "ادخل كلمة المرور"
            if (txtPassword.Text == "ادخل كلمة المرور")
            {
                //Appearing characters in textbox
                txtPassword.PasswordChar = '\0';
                //Change Properties of font Underline
                txtPassword.Font = new Font("LBC", 14, FontStyle.Underline);
            }
            else if (CountOfErrors > 0 && txtPassword.Text != "ادخل كلمة المرور")
            {
                CountOfErrors -= 1;
            }
            else if (txtPassword.Text != "ادخل كلمة المرور")
            {
                //Change txtbox passwordchar to = '*'
                txtPassword.PasswordChar = '*';
            }
        }

        //txtUser_TextChanged Method to change Properties of txtbox user name
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            //if txtbox password is equal "ادخل اسم المستخدم"
            if (txtUser.Text == "ادخل اسم المستخدم")
            {
                //Change Properties of font Underline
                txtUser.Font = new Font("LBC", 14, FontStyle.Underline);
            }
            else if (CountOfErrors > 0 && txtUser.Text != "ادخل اسم المستخدم")
            {
                CountOfErrors -= 1;
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

        //btnNewUser_Click Method to Add New User
        private void btnNewUser_Click(object sender, EventArgs e)
        {
            //Information Message Box
            MessageBox.Show("سيتم التوجة إلى شاشة تسجيل المستخدمين", "تنبية", MessageBoxButtons.OK,
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            //Create New Instance from FRM_Users 
            FRM_Users UserForm = new FRM_Users();
            //Control buttons in form users by Encapsulation or Properties or Setter and Getter
            //Disable the Delete Users Button
            FRM_Users.UserAccess_Property.btnDelete.Enabled = false;
            //Disable the Modify Users Button
            FRM_Users.UserAccess_Property.btnModify.Enabled = false;
            //Disable the Search Users Button
            FRM_Users.UserAccess_Property.btnSearch.Enabled = false;
            //Hide the Exit Users Button
            FRM_Users.UserAccess_Property.btnExit.Visible = false;
            //Appearing the Close Users Button
            FRM_Users.UserAccess_Property.btnClose.Visible = true;
            //Show the User Form in mode ShowDialog to Control of it
            UserForm.ShowDialog();
        }

        //txtPhone_TextChanged Method to change Properties of txtbox Phone name
        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            //if txtbox password is equal "ادخل اسم المستخدم"
            if (txtPhone.Text == "يرجى ادخال رقم الهاتف")
            {
                //Change Properties of font Underline
                txtPhone.Font = new Font("LBC", 14, FontStyle.Underline);
            }
            else if (CountOfErrors > 0 && txtPhone.Visible != true && txtPhone.Text != "يرجى ادخال رقم الهاتف")
            {
                CountOfErrors -= 1;
            }
        }

        //txtPhone_Enter Method to Clear txtPhone
        private void txtPhone_Enter(object sender, EventArgs e)
        {
            //if phone Focus on textbox change Properties of textbox
            if (txtPhone.Text == "يرجى ادخال رقم الهاتف")
            {
                //Clear textbox
                txtPhone.Clear();
                //Change Properties of font
                txtPhone.Font = new Font("LBC", 14, FontStyle.Regular);
            }
        }

        //txtPhone_Leave Method to Reset Properties of txtPhone
        private void txtPhone_Leave(object sender, EventArgs e)
        {
            //if txtPhone is equal empty
            if (txtPhone.Text == string.Empty)
            {
                //Change text of txtPhone is equal "يرجى ادخال رقم الهاتف"
                txtPhone.Text = "يرجى ادخال رقم الهاتف";
            }
        }

        //btnLogin_Click Method To Check UserName And password and Save Settings of Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // catchEmptyFields Int Function to return number of errors 
                if (CountOfErrors > 0)
                {
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop executing block code
                    return;
                }
                // if the user and password is correct so datatable load one row
                if (UsersClass.CheckLogin(txtUser.Text, txtPassword.Text).Rows.Count > 0 && UsersClass.CheckLogin(txtUser.Text, txtPassword.Text).Rows[0]["UserPassword"].ToString().Equals(txtPassword.Text, StringComparison.Ordinal))
                {
                    //Check Premission of Users Login ==>1

                    
                    //Check if user Checked the Save Settings of login to remember it ==>2
                    if (cbSaveSettings.Checked == true)
                    {
                        //ReCall cbSaveSettings_CheckedChanged Method To Save Settings of login
                        cbSaveSettings_CheckedChanged(sender, e);
                    }

                    //Save User ID when user login to System ==>3
                    Program.UsrID = Convert.ToInt32(UsersClass.CheckLogin(txtUser.Text, txtPassword.Text).Rows[0]["UserID"].ToString());

                    //Show Notification of System Message Info Message Successful Login
                    NotificationSMS.NotifyShow("تم تسجيل الدخول بنجاح!", "تسجيل الدخول",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Create New Instance from FRM_Main
                    FRM_Main mainForm = new FRM_Main();
                    //Show the form main
                    mainForm.Show();

                    //Close The Form
                    this.Close();
                }
                else
                {
                    //Show Notification of System Message Error Message in User login
                    NotificationSMS.NotifyShow("كلمة المرور واسم المستخدم غير صحيح", "تسجيل الدخول",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Error,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    ////clear controls of current form
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

        //btnRecovery_Click to Recovery Username And Password
        private void btnRecovery_Click(object sender, EventArgs e)
        {

            // catchEmptyFields Int Function to return number of errors 
            if (txtUser.Text == "ادخل اسم المستخدم" || txtPhone.Text == "يرجى ادخال رقم الهاتف")
            {
                //Show Notification of System Message Error Message in Input Entry
                NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Stop executing block code
                return;
            }

            //if user Search by phone number with results
            if (UsersClass.RecoveryUser(txtPhone.Text).Rows.Count > 0)
            {
                //Show Notification of System Message Error Message in Input Entry
                NotificationSMS.NotifyShow("تم استرجاع البيانات بنجاح!", "تسجيل الدخول",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Recovery UserName
                txtUser.Text = UsersClass.RecoveryUser(txtPhone.Text).Rows[0]["UserName"].ToString();
                //Recovery Password
                txtPassword.Text = UsersClass.RecoveryUser(txtPhone.Text).Rows[0]["UserPassword"].ToString();

                //Recall lblRecovery_Click Method
                lblRecovery_Click(sender, e);

            }
            else
            {
                //Show Notification of System Message Error Message in Input Entry
                NotificationSMS.NotifyShow("يرجى التحقق من رقم الهاتف!", "التحقق من البيانات",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }

        }

        //cbSaveSettings_CheckedChanged Method To Save Login username and password in Register Table
        private void cbSaveSettings_CheckedChanged(object sender, EventArgs e)
        {
            //Declare int Variable to record UserID
            int ID = Convert.ToInt32(UsersClass.CheckLogin(txtUser.Text, txtPassword.Text).Rows[0]["UserID"].ToString());
            //declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
            //Save Register Process To remember username and password again in Register Table
            RegClass.SaveUserRegister(RegClass.GenerateRegisterID(), ID, IP_PCName, DateTime.Now.ToString("yyyy-MM-dd"),
                DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));
        }

        //lblRecovery_Click Method To show Required fields to recover password
        private void lblRecovery_Click(object sender, EventArgs e)
        {
            //if txtUser and txtPassword is Appearing
            if (txtUser.Visible != false && txtPassword.Visible != false)
            {
                pBoxUser.Visible = true;
                txtUser.Visible = true;
                pBoxPassword.Visible = false;
                txtPassword.Visible = false;
                btnDisplay.Visible = false;
                pBoxPhone.Visible = true;
                txtPhone.Visible = true;
                cbSaveSettings.Visible = false;
                btnRecovery.Visible = true;
                lblRecovery.Visible = false;
                //Disable Login Button
                btnLogin.Enabled = false;
                //Change Back Color of button
                btnLogin.BackColor = Color.FromArgb(44, 62, 80);
            }
            //if txtUser and txtPassword is disappearing
            else if (txtPassword.Visible == false)
            {
                pBoxUser.Visible = true;
                txtUser.Visible = true;
                pBoxPassword.Visible = true;
                txtPassword.Visible = true;
                btnDisplay.Visible = true;
                pBoxPhone.Visible = false;
                txtPhone.Visible = false;
                cbSaveSettings.Visible = true;
                btnRecovery.Visible = false;
                lblRecovery.Visible = true;
                //Enable Login Button
                btnLogin.Enabled = true;
                //Change Back Color of button
                btnLogin.BackColor = Color.FromArgb(116, 185, 255);
            }
        }

        //txtUser_Validated Method to check validation of Control and Set Error Provider
        private void txtUser_Validated(object sender, EventArgs e)
        {
            if (txtUser.Text == "ادخل اسم المستخدم" )
            {
                errProviderLogin.SetError(txtUser, "هذا الحقل اجبارى");
                CountOfErrors += 1;
            }
        }

        //txtPhone_Validated Method to check validation of Control and Set Error Provider
        private void txtPhone_Validated(object sender, EventArgs e)
        {
            if (txtPhone.Visible == true && txtPhone.Text == "يرجى ادخال رقم الهاتف")
            {
                errProviderLogin.SetError(txtPhone, "هذا الحقل اجبارى");
                CountOfErrors += 1;
            }
        }

        //txtPassword_Validated Method to check validation of Control and Set Error Provider
        private void txtPassword_Validated(object sender, EventArgs e)
        {
            if (txtPassword.Text == "ادخل كلمة المرور")
            {
                errProviderLogin.SetError(txtPassword, "هذا الحقل اجبارى");
                CountOfErrors += 1;
            }
        }

        #endregion
    }
}
