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
    public partial class FRM_Branches : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchesClass = new BAL.CLS_Branches();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Branches Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Branches BranchAccessFRM;

        //Create BranchAccess_FormClosed to recall it when close form
        private static void BranchAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            BranchAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Branches BranchAccess_Property
        {
            //used getter to return value of FRM_Branches 
            get
            {
                //if created instance or field is null
                if (BranchAccessFRM == null)
                {
                    //Create New Instance From FRM_Branches by initialize it to field
                    BranchAccessFRM = new FRM_Branches();
                    //Generate Event of Form Closed and Delegate Method BranchAccess_FormClosed to it
                    BranchAccessFRM.FormClosed += new FormClosedEventHandler(BranchAccess_FormClosed);
                }
                //Return the value of field
                return BranchAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Branches
        public FRM_Branches()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Branches to it 
            if (BranchAccessFRM == null) BranchAccessFRM = this;
            //Load Users Table and fill combobox by UserName
            LoadComboBox();
            //Generate new Branch ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = BranchesClass.GenerateBranchID();
            //Focus on txtName
            txtName.Focus();
        }

        #region Methods and Functions

        /// <summary>
        /// list of char function to check validation characters of email
        /// </summary>
        /// <returns>list of char which contains all character of email </returns>
        bool ValidationOfEmail(char ch)
        {
            //Create New Instance From List<Char> to add all english characters
            List<char> EmailCharacters
                = new List<char> { '@', '_', '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            //ASCII CODE A(Cap) is 65 to Z(cap) is 90 or a(small) is 97 to z(small) is 122
            //Use For loop by char (char i = 'A' Captalize letter; i <='Z'; i++) but in email all small i= 'a'; i <='z'
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                //Add letter to list of char
                EmailCharacters.Add(letter);
            }

            //check if list of char contains ch argument received to function
            if (EmailCharacters.Contains(ch))
            {
                //Retrun true
                return true;
            }
            //else return false
            else return false;
        }

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //loop in all controls of form in pnlBranches.Controls by foreach loop
            foreach (Control ctrl in this.pnlBranches.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl == txtName)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderBranches.SetError(ctrl, "هذا الحقل اجبارى");
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
            errProviderBranches.Clear();
            //loop in all control in side this.pnlBranches.Controls
            foreach (Control ctrl in this.pnlBranches.Controls)
            {
                if (ctrl is TextBox && ctrl != txtEmail) ctrl.ResetText();
                else if (ctrl is TextBox && ctrl == txtEmail)
                {
                    //Set Value of txtEmail.Text is "someone@gmail.com"
                    txtEmail.Text = "someone@gmail.com";
                    //change ForeColor to ButtonShadow
                    txtEmail.ForeColor = SystemColors.ButtonShadow;
                }
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.pnlControls.Controls
            foreach (Control ctrl in this.pnlControls.Controls)
            {
                if (ctrl is Button && ctrl.Enabled == false) ctrl.Enabled = true;
            }
            //loop in all control in side this.pnlTop.Controls
            foreach (Control ctrl in this.pnlTop.Controls)
            {
                if (ctrl is Label && ctrl == lblBranchActivate || ctrl == lblBranchStatus) ctrl.Visible = false;
            }

            //Generate new Branch ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = BranchesClass.GenerateBranchID();
            //Focus on txtName
            txtName.Focus();
        }

        //Void LoadComboBox() Method to Load Users Table and fill combobox by UserName
        void LoadComboBox()
        {
            //Create New Instance From BAL.CLS_Users
            BAL.CLS_Users UserClass = new BAL.CLS_Users();
            //Initialize DataSource of combo is UserClass.ShowUsersTable();
            comboManager.DataSource = UserClass.ShowUsersTable();
            //Initialize DisplayMember of combo is UserName
            comboManager.DisplayMember = "الاسم بالكامل";
            //Initialize ValueMember of combo is UserID
            comboManager.ValueMember = "كود الداخلى";
            //index of any element starts from Zero
            //To Clear ComboBox of comboManager by selected index equal -1  
            comboManager.SelectedIndex = -1;
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
                //To Control of NotificationSMS as first
                NotificationSMS.ShowDialog();
            }
        }

        //btnModify_Click Method To Update Branch
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(BranchesClass.GenerateBranchID() New Branch ID) Do not modify
                if (lblID.Text.Contains(BranchesClass.GenerateBranchID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الفرع لم يتم إضافته بعد", "تنبية",
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

                //Check if txtEmail is equal "someone@gmail.com" change to null
                if (txtEmail.Text == "someone@gmail.com") txtEmail.Text = "";

                //Modify Branches Table
                BranchesClass.UpdateBranches
                    (Convert.ToInt32(lblID.Text.Remove(0, 5)), txtName.Text, txtPhone1.Text,
                                     txtPhone2.Text, txtFax.Text, txtEmail.Text,
                                     txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue),
                                     IP_PCName, Program.UsrID);


                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل الفرع بنجاح", "عملية التعديل",
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

        //btnSave_Click Method To Save New Branch
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in Branches table + 1 
                //lblID.Text.Contains(BranchesClass.GenerateBranchID().ToString() New Branch ID) Do not modify
                if (!lblID.Text.Contains(BranchesClass.GenerateBranchID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الفرع تم إضتافته من قبل", "تنبية",
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

                //Check if txtEmail is equal "someone@gmail.com" change to null
                if (txtEmail.Text == "someone@gmail.com") txtEmail.Text = "";

                //Add New Branch to Branches Table  
                BranchesClass.SaveBranches
                    (Convert.ToInt32(lblID.Text.Remove(0,5)), lblID.Text, txtName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                    txtEmail.Text, txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue), IP_PCName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));


                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ الفرع بنجاح", "عملية الحفظ",
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

        //btnDelete_Click Method To Delet Supplier by Delete Record or Deactivate Branches
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(BranchesClass.GenerateBranchID().ToString() New Customer ID) Do not modify
                if (lblID.Text.Contains(BranchesClass.GenerateBranchID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الفرع لم يتم إضافته بعد", "تنبية",
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

                //if user select Yes Button and Select Delete Branch From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Branches From Database
                    BranchesClass.DeleteBranches(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف الفرع بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                }
                //if user select Yes Button and Select InActivate Branch From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Branches Table
                    BranchesClass.DeactivateBranches(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف الفرع بشكل مؤقت بنجاح", "عملية الحذف",
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

        //btnSearch_Click Method To Search in Branches Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_BranchSearch
            FRM_BranchSearch SearchForm = new FRM_BranchSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //btnExit_Click Method To Close Form
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (BranchAccessFRM != null) BranchAccessFRM = null;
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

        //txtName_TextChanged Method to hide error provider
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // if txtName is not equal Empty
            if (txtName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderBranches.SetError(txtName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtAddress_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone1.Focus();
            }
        }

        //txtPhone1_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtPhone1_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtPhone1_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone2.Focus();
            }
        }

        //txtPhone2_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtPhone2_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtPhone2_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtFax.Focus();
            }
        }

        //txtFax_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtFax_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtEmail.Focus();
            }
        }

        //txtEmail_KeyPress Method to check Validation of email
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if input entry is not equal characters in bool function like ValidationOfEmail.contains (e.keyChar)
            //or input entry is not equal backspace  so e.handled = true; prevent user to ener characters
            if (!ValidationOfEmail(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        //txtEmail_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboManager.Focus();
            }
        }

        //txtEmail_Enter Method To Clear txtEmail
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            //if txtEmail is equal empty or "someone@gmail.com"
            if (txtEmail.Text == "someone@gmail.com")
            {
                //Clear txtEmail
                txtEmail.Clear();
            } 
        }

        //txtEmail_TextChanged Method To reset fore color of txtEmail
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            //if txtEmail is not equal empty
            if (txtEmail.Text != "someone@gmail.com")
            {
                //change ForeColor to black
                txtEmail.ForeColor = Color.Black;
            }
        }

        //txtEmail_Leave Method To Check if txtEmail is Empty
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //if txtEmail is empty
            if (txtEmail.Text == string.Empty)
            {
                //Set Value of txtEmail.Text is "someone@gmail.com"
                txtEmail.Text = "someone@gmail.com";
                //change ForeColor to ButtonShadow
                txtEmail.ForeColor = SystemColors.ButtonShadow;
            }
        }

        //btnAdd_Click Method To Move FRM_Users 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (BranchAccessFRM != null) BranchAccessFRM = null;
                //Close Form
                this.Close();
                //Used btnUsers_Click Method To Move FRM_Users by Encapsulation is FRM_Main.ObjectMain_Property
                FRM_Main.ObjectMain_Property.btnUsers_Click(sender, e);
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

        //lblBranchActivate_Click Method to Activate Branch
        private void lblBranchActivate_Click(object sender, EventArgs e)
        {
            //if picture box contains Active image so ==> stop to executing block code
            if (lblBranchActivate.Visible == false) return;
            //else

            //declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            //Update Status to true in Branches Table
            BranchesClass.DeactivateBranches(Convert.ToInt32(lblID.Text.Remove(0, 5)), true, IP_PCName, Program.UsrID);

            //Alarm Success deactive Message Box 
            NotificationSMS.NotifyShow("تم تنشيط الفرع بنجاح", "عملية التعديل",
                FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //Recall Btn New to clear Controls
            btnNew_Click(sender, e);
        }

        //timerSuppliers_Tick Method when timer start ever 1200 tick Rotate image in picturebox
        private void timerBranches_Tick(object sender, EventArgs e)
        {
            try
            {
                /* Set in Properties Interval of timer = 500 */
                //if visible of lblBranchStatus is not equal true ==> stop to executing block code
                if (lblBranchStatus.Visible != true) return;
                //if interval of timer equal 500
                if (timerBranches.Interval == 500)
                {
                    //Change Font of lblBranchStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblBranchStatus.Font = new Font("LBC", 14, FontStyle.Bold);
                    //Change location of lblUserStatus by  initialize new point (x,y)
                    lblBranchStatus.Location = new Point(5, 11);
                    //change interval of timer to 1000
                    timerBranches.Interval = 1000;
                }
                //if interval of timer equal 1000
                else if (timerBranches.Interval == 1000)
                {
                    //Change Font of lblBranchStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblBranchStatus.Font = new Font("LBC", 16, FontStyle.Bold);
                    //Change location of lblBranchStatus by  initialize new point (x,y)
                    lblBranchStatus.Location = new Point(5, 28);
                    //change interval of timer to 500
                    timerBranches.Interval = 500;
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

        //btnClose_Click Method To Close FRM_Branches
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Information Message Box
                MessageBox.Show("سيتم التوجة إلى تسجيل بيانات المخازن", "تنبية", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                //Create New Instance from FRM_Stores 
                FRM_Stores StoreForm = new FRM_Stores();
                //Control buttons in form Stores  by Encapsulation or Properties or Setter and Getter
                //Disable the Delete Stores  Button
                FRM_Stores.StoreAccess_Property.btnDelete.Enabled = false;
                //Disable the Modify Stores  Button
                FRM_Stores.StoreAccess_Property.btnModify.Enabled = false;
                //Disable the Search Stores  Button
                FRM_Stores.StoreAccess_Property.btnSearch.Enabled = false;
                //Hide the Exit Stores  Button
                FRM_Stores.StoreAccess_Property.btnExit.Visible = false;
                //Appearing the Close Stores  Button
                FRM_Stores.StoreAccess_Property.btnClose.Visible = true;
                //Show the User Form in mode ShowDialog to Control of it
                StoreForm.ShowDialog();

                //check if field you are created is null when closed form if not Assign null value to field
                if (BranchAccessFRM != null) BranchAccessFRM = null;
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
