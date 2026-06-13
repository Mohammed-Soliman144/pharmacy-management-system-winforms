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
using System.Globalization; // To Deal with Input Language and Number Formats 

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Customers : Form
    {
        #region Public Declaration
        //Create New Instance From BAL.CustomersClass Business Access Layer
        readonly BAL.CLS_Customers CustomersClass = new BAL.CLS_Customers();
        //Create New Instance From BAL.CLS_CustomerAccount Business Access Layer
        readonly BAL.CLS_CustomerAccount CustAccountClass = new BAL.CLS_CustomerAccount();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Customers Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Customers CustAccessFRM;

        //Create CustAccess_FormClosed to recall it when close form
        private static void CustAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            CustAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Customers CustAccess_Property
        {
            //used getter to return value of FRM_Customers 
            get
            {
                //if created instance or field is null
                if (CustAccessFRM == null)
                {
                    //Create New Instance From FRM_Customers by initialize it to field
                    CustAccessFRM = new FRM_Customers();
                    //Generate Event of Form Closed and Delegate Method CustAccess_FormClosed to it
                    CustAccessFRM.FormClosed += new FormClosedEventHandler(CustAccess_FormClosed);
                }
                //Return the value of field
                return CustAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Customers
        public FRM_Customers()
        {
            InitializeComponent();
            /*After Method of InitializeComponent inside constructor of FRM_Customers
             * Check if Field you are created is null so intialize value of FRM_Customers to it */
            if (CustAccessFRM == null) CustAccessFRM = this;
            //Change Visible of pbCustomerStatus to False
            pbCustomerStatus.Visible = false;
            //Generate new Customer ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = CustomersClass.GenerateCustomerID();
            //Focus on txtFullName
            txtFullName.Focus();
        }

        #region Method and Fuctions

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
            //loop in all controls of form by foreach loop
            foreach (Control ctrl in this.pnlCustomers.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl.Enabled == true &&
                    ctrl != txtEmail && ctrl != txtFax && ctrl != txtCompany && ctrl != txtNotes && ctrl != txtPhone2)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderCustomers.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                //if Ctrl is ComboBox and Ctrl is Enabled and Ctrl is Empty
                else if (ctrl is ComboBox && ctrl.Enabled == true && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderCustomers.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }

            foreach (Control ctrl in this.pnlLeftSide.Controls)
            {
                //if Ctrl is ComboBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is ComboBox && ctrl.Text == string.Empty && txtBalance.Text != "0")
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderCustomers.SetError(ctrl, "هذا الحقل اجبارى");
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
            errProviderCustomers.Clear();
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlCustomers.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                else if (ctrl is ComboBox) { ctrl.ResetText(); comboCustomerType.SelectedIndex = -1; }
                else if (ctrl is RadioButton) { rbtnAvailWithdrawals.Checked = false; rbtnStopWithdrawals.Checked = true; }
            }
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlLeftSide.Controls)
            {
                if (ctrl is TextBox && ctrl.Name == "txtNotes") ctrl.ResetText();
                else if (ctrl is TextBox && ctrl.Name != "txtNotes") ctrl.Text = "0";
                else if (ctrl is ComboBox) { ctrl.ResetText(); ctrl.Enabled = true; comboBalanceStatus.SelectedIndex = -1;  }
                if (ctrl is TextBox && ctrl == txtBalance) txtBalance.ReadOnly = false;
            }
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlControls.Controls)
            {
                if (ctrl is Button && ctrl.Enabled == false) ctrl.Enabled = true;
            }
            //change visibility of pbCustomerStatus to false
            pbCustomerStatus.Visible = false;
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = CustomersClass.GenerateCustomerID();
            //Focus on txtFullName
            txtFullName.Focus();
        }

        /// <summary>
        /// void Method To Add Balance of Customer To CustomerAccount
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void AddBillToCustomerAccount(string iPPcName)
        {
            //Declare Decimal Variable to Calculate balance
            decimal balance = Convert.ToDecimal(txtBalance.Text);

            //if Customer Balance is Debit - (negative number)
            if (balance != 0  && comboBalanceStatus.SelectedIndex == 1)
            {
                //Change balnce to positive number 
                balance *= - 1;

                //Add New Customer to CustomerAccount Table
                CustAccountClass.SaveCustAccount(CustAccountClass.GenerateCustAccountID(), Convert.ToInt32(lblID.Text.Remove(0, 5)), 0, lblID.Text, "إضافة عميل", balance, 0, balance, "إنشاء عميل له رصيد سابق مدين", iPPcName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            //if Customer Balance is Credit + (Positive number)
            else if (balance != 0 && comboBalanceStatus.SelectedIndex == 2)
            {
                //Add New Customer to CustomerAccount Table
                CustAccountClass.SaveCustAccount(CustAccountClass.GenerateCustAccountID(), Convert.ToInt32(lblID.Text.Remove(0, 5)), 0, lblID.Text, "إضافة عميل", 0, balance, balance, "إنشاء عميل له رصيد سابق دائن", iPPcName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        /// <summary>
        /// To Primit user to enter any digits except number Digits and backspace and decimal point
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        void CheckInputForCurrency(KeyPressEventArgs e)
        {
            //Declare char variable then assign decimal sign after using System.Globalization
            //get decimal sign from CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.tostring();
            char decChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

            //if user did not enter Digits and backspace and decimal point 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != decChar)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //btnExit_Click Method To Close FRM_Customers
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (CustAccessFRM != null) CustAccessFRM = null;
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

        //btnSave_Click Method To Save New Customer
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in users table + 1 
                //lblID.Text.Contains(CustomersClass.GenerateCustomerID().ToString() New User ID) Do not modify
                if (!lblID.Text.Contains(CustomersClass.GenerateCustomerID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا العميل تم إضتافته من قبل", "تنبية",
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

                //if txtCreditLimit.text is empty initialize zero value "0"
                if (txtCreditLimit.Text == string.Empty || txtCreditLimit.Enabled == false || txtCreditLimit.Text == "0.000") txtCreditLimit.Text = "0";
                else
                {
                    //declare int variable then assign indexof("specific string"); which remove starts it 
                    int posOfCredit = txtCreditLimit.Text.IndexOf(" ج.م ");
                    //Remove start index
                    txtCreditLimit.Text = txtCreditLimit.Text.Remove(posOfCredit);
                }

                //declare int variable then assign indexof("specific string"); which remove starts it 
                int posOfDiscount = txtDiscount.Text.IndexOf(" %");

                //Declare Decimal Variable to Calculate balance
                decimal balance = Convert.ToDecimal(txtBalance.Text);

                //if Customer Balance is Debit - (negative number)
                if (balance != 0 && comboBalanceStatus.SelectedIndex == 1)
                {
                    //Change balnce to positive number 
                    balance *= -1;
                }
                else if (comboBalanceStatus.SelectedIndex == 0) 
                { 
                    balance = 0; 
                }

                //Add New Customer is Available Cash withdrawals
                if (rbtnAvailWithdrawals.Checked == true)
                {
                    CustomersClass.SaveCustomers
                        (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, txtFullName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                         txtAddress.Text, txtEmail.Text, comboCustomerType.Text, txtCompany.Text, Convert.ToDecimal(txtCreditLimit.Text),
                         txtDiscount.Text.Remove(posOfDiscount), true, balance, txtNotes.Text, IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
                //Add New Customer is Not Available Cash withdrawals 
                else if (rbtnStopWithdrawals.Checked == true)
                {
                    CustomersClass.SaveCustomers
                        (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, txtFullName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                         txtAddress.Text, txtEmail.Text, comboCustomerType.Text, txtCompany.Text, Convert.ToDecimal(txtCreditLimit.Text),
                         txtDiscount.Text.Remove(posOfDiscount), false, balance, txtNotes.Text, IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }
                else // if Client is Cash and rbtnStopWithdrawals is disabled and rbtnAvailWithdrawals is disabled
                {
                    CustomersClass.SaveCustomers
                       (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, txtFullName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                        txtAddress.Text, txtEmail.Text, comboCustomerType.Text, txtCompany.Text, Convert.ToDecimal(txtCreditLimit.Text),
                        txtDiscount.Text.Remove(posOfDiscount), false, balance, txtNotes.Text, IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                }

                //Add Customer Balance To Customer Account Table
                AddBillToCustomerAccount(IP_PCName);

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ العميل بنجاح", "عملية الحفظ",
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

        //btnModify_Click Method To Modify Customers
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(CustomersClass.GenerateCustomerID() New Customer ID) Do not modify
                if (lblID.Text.Contains(CustomersClass.GenerateCustomerID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا العميل لم يتم إضافته بعد", "تنبية",
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

                //if txtCreditLimit.text is empty initialize zero value "0"
                if (txtCreditLimit.Text == string.Empty || txtCreditLimit.Enabled == false || txtCreditLimit.Text == "0.000") txtCreditLimit.Text = "0";
                else
                {
                    //declare int variable then assign indexof("specific string"); which remove starts it 
                    int posOfCredit = txtCreditLimit.Text.IndexOf(" ج.م ");
                    //Remove start index
                    txtCreditLimit.Text = txtCreditLimit.Text.Remove(posOfCredit);
                }

                //Add New Customer is Available Cash withdrawals
                if (rbtnAvailWithdrawals.Checked == true)
                {
                    //Modify Customers Table
                    CustomersClass.UpdateCustomers(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtFullName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                         txtAddress.Text, txtEmail.Text, comboCustomerType.Text, txtCompany.Text, Convert.ToDecimal(txtCreditLimit.Text),
                         txtDiscount.Text.Replace(" %",""), true, txtNotes.Text, IP_PCName, Program.UsrID);
                }
                //Add New Customer is Not Available Cash withdrawals
                else
                {
                    //Modify Customers Table
                    CustomersClass.UpdateCustomers(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtFullName.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text,
                         txtAddress.Text, txtEmail.Text, comboCustomerType.Text, txtCompany.Text, Convert.ToDecimal(txtCreditLimit.Text),
                         txtDiscount.Text.Replace(" %", ""), false, txtNotes.Text, IP_PCName, Program.UsrID);
                }

                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل العميل بنجاح", "عملية التعديل",
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

        //btnDelete_Click Method to Delete Customers
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(CustomersClass.GenerateCustomerID().ToString() New Customer ID) Do not modify
                if (lblID.Text.Contains(CustomersClass.GenerateCustomerID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا العميل لم يتم إضافته بعد", "تنبية",
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

                //if user select Yes Button and Select Delete Customer From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Customer From Database
                    CustomersClass.DeleteCustomers(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Delete All operations of Customer Account From Database
                    CustAccountClass.DeleteCustAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف العميل بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                }
                //if user select Yes Button and Select InActivate Customer From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Customers Table
                    CustomersClass.DeactivateCustomers(Convert.ToInt32(lblID.Text.Remove(0, 5)),false, IP_PCName, Program.UsrID);

                    //Deactivate All operations of Customer Account From Database
                    CustAccountClass.DeactivateCustAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف العميل بشكل مؤقت بنجاح", "عملية الحذف",
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

        //btnSearch_Click Method to Search In Customers Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_CustomerSearch
            FRM_CustomerSearch SearchForm = new FRM_CustomerSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //btnAdd_Click Method to Add Second Phone Number
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //txtPhone1 is not equal empty and txtPhone2 is equal empty
            if (txtPhone1.Text != string.Empty && txtPhone2.Text == string.Empty)
            {
                //hide txtPhone1
                txtPhone1.Visible = false;
                //Focus on txtPhone2
                txtPhone2.Focus();
            }
            // if visible of txtPhone1 equal false (move to txtphone1)
            else if (txtPhone1.Visible == false)
            {
                //hide txtPhone2
                txtPhone2.Visible = false;
                //Appears txtPhone1
                txtPhone1.Visible = true;
                //Initialize SelectionStart of txtPhone1 equal 0
                txtPhone1.SelectionStart = 0;
                //Initialize SelectionLength of txtPhone1 equal textlength of txtPhone1
                txtPhone1.SelectionLength = txtPhone1.TextLength;
                //Focus on txtPhone1
                txtPhone1.Focus();
            }
            //if visible of txtPhone2 equal false (move to txtphone2)
            else if (txtPhone2.Visible == false)
            {
                //hide txtPhone1
                txtPhone1.Visible = false;
                //Appears txtPhone2
                txtPhone2.Visible = true;
                //Initialize SelectionStart of txtPhone2 equal 0
                txtPhone2.SelectionStart = 0;
                //Initialize SelectionLength of txtPhone2 equal textlength of txtPhone1
                txtPhone2.SelectionLength = txtPhone2.TextLength;
                //Focus on txtPhone2
                txtPhone2.Focus();
            }
        }

        //txtFullName_Validated Method to check Validation Input Entry in txtFullName
        private void txtFullName_Validated(object sender, EventArgs e)
        {
            // if txtFullName is equal Empty
            if (txtFullName.Text == string.Empty)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtFullName, "هذا الحقل اجبارى");
                //Focus on the same field txtFullName
                txtFullName.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtFullName_TextChanged Method to hide error provider
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtFullName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtFullName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtFullName_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key and txtFullName is not equal empty
            if (e.KeyCode == Keys.Enter && txtFullName.Text != string.Empty)
            {
                //Move to Next Control by controlName.Focus();
                txtAddress.Focus();
            }
        }

        //txtFullName_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter letters and backspace and space
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtAddress_Validated Method to check Validation Input Entry in txtAddress
        private void txtAddress_Validated(object sender, EventArgs e)
        {
            // if txtFullName is equal Empty
            if (txtAddress.Text == string.Empty)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtAddress, "هذا الحقل اجبارى");
                //Focus on the same field txtAddress
                txtAddress.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtAddress_TextChanged Method to hide error provider
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtAddress.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtAddress, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtAddress_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key and txtAddress is not equal empty
            if (e.KeyCode == Keys.Enter && txtAddress.Text != string.Empty)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone1.Focus();
            }
        }

        //txtPhone1_Validated Method to check Validation Input Entry in txtPhone1
        private void txtPhone1_Validated(object sender, EventArgs e)
        {
            // if txtPhone1 is equal Empty
            if (txtPhone1.Text == string.Empty || txtPhone1.Text.Length < 11)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtPhone1, "يجب إدخال رقم مكون من 11 رقم");
                //Focus on the same field txtPhone1
                txtPhone1.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtPhone1_TextChanged Method To hide error provider
        private void txtPhone1_TextChanged(object sender, EventArgs e)
        {
            // if txtPhone1 is equal Empty
            if (txtPhone1.Text != string.Empty && txtPhone1.Text.Length == 11)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtPhone1, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
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
            // if event generated from user press on enter key and txtPhone1 is not equal empty
            if (e.KeyCode == Keys.Enter && txtPhone1.Text != string.Empty && txtPhone1.Text.Length == 11)
            {
                //Move to Next Control by controlName.Focus();
                txtFax.Focus();
            }
        }

        //txtPhone2_Validated Method to check Validation Input Entry in txtPhone2
        private void txtPhone2_Validated(object sender, EventArgs e)
        {
            // if txtPhone1 is equal Empty
            if (txtPhone2.Text == string.Empty || txtPhone2.Text.Length < 11)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtPhone2, "يجب إدخال رقم مكون من 11 رقم");
                //Focus on the same field txtPhone1
                txtPhone2.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtPhone2_TextChanged Method To hide error provider
        private void txtPhone2_TextChanged(object sender, EventArgs e)
        {
            // if txtPhone1 is equal Empty
            if (txtPhone2.Text != string.Empty && txtPhone2.Text.Length == 11)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtPhone2, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
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
            // if event generated from user press on enter key and txtPhone2 is not equal empty
            if (e.KeyCode == Keys.Enter && txtPhone1.Text != string.Empty && txtPhone2.Text.Length == 11)
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
                txtCompany.Focus();
            }
        }

        //txtEmail_Enter Method when Focus on txtEmail_Enter
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            //Information of Input Entry
            //SetError of errProviderCustomers (controlName,"Info message")
            errProviderCustomers.SetError(txtEmail, "Ex:- someone@gmail.com \n(Small Letters and English Letters)");
        }

        //txtEmail_Leave Method when left fromtxtEmail_Leave
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //Hide errProviderCustomers (controlName,"")
            errProviderCustomers.SetError(txtEmail, "");
        }

        //txtCompany_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Letters and backspace and space
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtCompany_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCompany_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboCustomerType.Focus();
            }
        }

        //comboCustomerType_SelectedIndexChanged Method to check if Cash customer or postpaid
        private void comboCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if user selectedIndex of comboCustomerType is cash customer
            if (comboCustomerType.SelectedIndex == 0)
            {
                //disable txtCreditLimit
                txtCreditLimit.Enabled = false;
                //disable rbtnAvailWithdrawals
                rbtnAvailWithdrawals.Enabled = false;
                //disable rbtnStopWithdrawals
                rbtnStopWithdrawals.Enabled = false;
            }
            // if user selectedIndex of comboCustomerType is postpaid customer
            else if (comboCustomerType.SelectedIndex == 1 || comboCustomerType.SelectedIndex == -1)
            {
                //enable txtCreditLimit
                txtCreditLimit.Enabled = true;
                //enable rbtnAvailWithdrawals
                rbtnAvailWithdrawals.Enabled = true;
                //enable rbtnStopWithdrawals
                rbtnStopWithdrawals.Enabled = true;
            }
        }

        //comboCustomerType_Validated Method to check Validation Input Entry in comboCustomerType
        private void comboCustomerType_Validated(object sender, EventArgs e)
        {
            // if comboCustomerType is equal Empty
            if (comboCustomerType.Text == string.Empty && comboCustomerType.Enabled != false)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(comboCustomerType, "هذا الحقل اجبارى");
                //Focus on the same field comboCustomerType
                comboCustomerType.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
            else // if comboCustomerType is not equal Empty
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(comboCustomerType, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboCustomerType_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboCustomerType_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter && comboCustomerType.SelectedIndex == 0)
            {
                //Move to Next Control by controlName.Focus();
                txtDiscount.Focus();
            }
            else if (e.KeyCode == Keys.Enter && comboCustomerType.SelectedIndex == 1)
            {
                //Move to Next Control by controlName.Focus();
                txtCreditLimit.Focus();
            }
        }

        //txtCreditLimit_Validated Method to check Validation Input Entry in txtCreditLimit
        private void txtCreditLimit_Validated(object sender, EventArgs e)
        {
            // if txtCreditLimit is equal Empty
            if (txtCreditLimit.Text == string.Empty && txtCreditLimit.Enabled == true)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtCreditLimit, "هذا الحقل اجبارى");
                //Focus on the same field txtCreditLimit
                txtCreditLimit.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtCreditLimit_TextChanged Method to hide error provider
        private void txtCreditLimit_TextChanged(object sender, EventArgs e)
        {
            // if txtPhone1 is not equal Empty
            if (txtCreditLimit.Text != string.Empty && txtCreditLimit.Enabled == true)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtCreditLimit, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtCreditLimit_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtCreditLimit_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCreditLimit_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter && txtCreditLimit.Text  != string.Empty)
            {
                //change format of txtCreditLimit after press on enter 2000 ج.م
                txtCreditLimit.Text = txtCreditLimit.Text + " ج.م ";
                //Move to Next Control by controlName.Focus();
                txtDiscount.Focus();
            }
        }

        //txtDiscount_Validated Method to check Validation Input Entry in txtDiscount
        private void txtDiscount_Validated(object sender, EventArgs e)
        {
            // if txtDiscount is equal Empty
            if (txtDiscount.Text == string.Empty)
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(txtDiscount, "مثال:-  % 15.25");
                //Focus on the same field txtCreditLimit
                txtDiscount.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //txtDiscount_TextChanged Method to hide error Provider
        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            // if txtPhone1 is not equal Empty
            if (txtDiscount.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCustomers.SetError(txtDiscount, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtDiscount_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Declare char variable then assign decimal sign after using System.Globalization
            //get decimal sign from CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.tostring();
            char decChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

            //if user did not enter Digits and backspace and decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != decChar)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtDiscount_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //change format of txtdiscount after press on enter 12.52 %
                txtDiscount.Text = txtDiscount.Text + " %";
                //Move to Next Control by controlName.Focus(); 
                txtBalance.Focus();
            }
        }

        //txtBalance_KeyPress Method to Prevent user to press any characters except (- or backspace or digits)
        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Method to prevent user to press any characters except (- or backspace or digits) 
            //which Receive one Argument From KeyPressEventArgs e
            CheckInputForCurrency(e);
        }

        //txtBalance_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtBalance_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus(); 
                comboBalanceStatus.Focus();
            }
        }

        //comboBalanceStatus_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboBalanceStatus_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter && comboBalanceStatus.SelectedIndex != -1)
            {
                //Move to Next Control by controlName.Focus(); 
                txtNotes.Focus();
            }
        }

        //comboBalanceStatus_Validated Method to check Validation Input Entry in comboBalanceStatus
        private void comboBalanceStatus_Validated(object sender, EventArgs e)
        {
            // if comboBalanceStatus is equal Empty
            if (comboBalanceStatus.SelectedIndex == -1 && txtBalance.Text != "0")
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderCustomers.SetError(comboBalanceStatus, "هذا الحقل اجبارى");
                //Focus on the same field comboBalanceStatus
                comboBalanceStatus.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        //pbCustomerStatus_Click Method to Activate Customer
        private void pbCustomerStatus_Click(object sender, EventArgs e)
        {
            //if picture box contains Enable_Client image so ==> stop to executing block code
            if (pbCustomerStatus.Image == Properties.Resources.Enable_Client) return;
            //else

            //declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            //Update Status to true in Customers Table
            CustomersClass.DeactivateCustomers(Convert.ToInt32(lblID.Text.Remove(0, 5)), true, IP_PCName, Program.UsrID);

            //Activate All operations of Customer Account From Database
            CustAccountClass.DeactivateCustAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)), true, IP_PCName, Program.UsrID);

            //Alarm Success deactive Message Box 
            NotificationSMS.NotifyShow("تم تنشيط العميل بنجاح", "عملية التعديل",
                FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //Recall Btn New to clear Controls
            btnNew_Click(sender, e);

        }

        //timerCustomers_Tick Method when timer start ever 1200 tick Rotate image in picturebox
        private void timerCustomers_Tick(object sender, EventArgs e)
        {
            //Declare image variable then assignment pbCustomerStatus.Image to ImgRotate
            Image ImgRotate = pbCustomerStatus.Image;
            //Initialize RotateFlip of Image like ==> Img.RotateFlip(RotateFlipType.Rotate(90-180-270)FlipXY
            //X Rotate image Horizantal or Y Rotate image Vertical
            ImgRotate.RotateFlip(RotateFlipType.Rotate90FlipXY);
            //Assign the rotate image to picture box
            pbCustomerStatus.Image = ImgRotate;
        }

        //pbCustomerStatus_MouseHover Method when user stop or hover on picturebox by mouse to stop rotateFlip image
        private void pbCustomerStatus_MouseHover(object sender, EventArgs e)
        {
            //Set Enable of timer is false
            timerCustomers.Enabled = false;
            //stop timer
            timerCustomers.Stop();
        }

        //pbCustomerStatus_MouseLeave Method when user mouse leave of picturebox to rotate image
        private void pbCustomerStatus_MouseLeave(object sender, EventArgs e)
        {
            //Enable of timer is true
            timerCustomers.Enabled = true;
            //Start Timer
            timerCustomers.Start();
        }

        #endregion
        
    }
}
