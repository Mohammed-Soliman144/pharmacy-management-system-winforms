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
using System.Globalization; // to Change Input Language or deal with Date or Time and NumberFormats

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Suppliers : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Suppliers Business Access Layer
        readonly BAL.CLS_Suppliers SuppliersClass = new BAL.CLS_Suppliers();
        //Create New Instance From BAL.CLS_SupplierAccount Business Access Layer
        readonly BAL.CLS_SupplierAccount SupAccountClass = new BAL.CLS_SupplierAccount();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Suppliers Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Suppliers SupAccessFRM;

        //Create SupAccess_FormClosed to recall it when close form
        private static void SupAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            SupAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Suppliers SupAccess_Property
        {
            //used getter to return value of FRM_Suppliers 
            get
            {
                //if created instance or field is null
                if (SupAccessFRM == null)
                {
                    //Create New Instance From FRM_Customers by initialize it to field
                    SupAccessFRM = new FRM_Suppliers();
                    //Generate Event of Form Closed and Delegate Method CustAccess_FormClosed to it
                    SupAccessFRM.FormClosed += new FormClosedEventHandler(SupAccess_FormClosed);
                }
                //Return the value of field
                return SupAccessFRM;
            }
        }

        #endregion

        //Constructor of FRM_Suppliers
        public FRM_Suppliers()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Suppliers to it 
            if (SupAccessFRM == null) SupAccessFRM = this;
            //Change Visible of pbSupStatus to False
            pbSupStatus.Visible = false;
            //Generate new Supplier ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = SuppliersClass.GenerateSupplierID();
            //Focus on txtFullName
            txtFullName.Focus();
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
            //loop in all controls of form in pnlInfoTab.Controls by foreach loop
            foreach (Control ctrl in this.pnlInfoTab.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl != txtCompany && ctrl != txtPhone2
                    && ctrl != txtPhone3 && ctrl != txtFax && ctrl != txtEmail && ctrl != txtResponsible)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderSuppliers.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }
            if (CountOfErrors > 0 && pnlExtraTab.Visible != false)
            {
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = btnExtraTab.BackColor;
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = btnExtraTab.ForeColor;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ControlText;
                //Send pnlExtraTab to Back
                pnlExtraTab.SendToBack();
                //Bring pnlInfoTab to Front
                pnlInfoTab.BringToFront();
                //Hide pnlExtraTab
                pnlExtraTab.Visible = false;
                //btnInfoTab_Click(sender, e);
                return CountOfErrors;
            }


            if (CountOfErrors > 0) pnlInfoTab.BringToFront();
            //loop in all controls of form in pnlExtraTab.Controls by foreach loop
            foreach (Control ctrl in this.pnlExtraTab.Controls)
            {
                //if Ctrl is ComboBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is ComboBox && ctrl.Text == string.Empty && ctrl == comboSupType)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderSuppliers.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }

            //Check if Info Tab Panel is Visible equal true ==> stop executing block code
            if (CountOfErrors > 0 && pnlExtraTab.Visible == false)
            {
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = btnInfoTab.BackColor;
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = btnInfoTab.ForeColor;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ControlText;
                //Send pnlInfoTab to Back
                pnlInfoTab.SendToBack();
                //Bring pnlExtraTab to Front
                pnlExtraTab.BringToFront();
                //Appears pnlExtraTab
                pnlExtraTab.Visible = true;
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
            errProviderSuppliers.Clear();
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlInfoTab.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
            }
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlExtraTab.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.gbSupBalance.Controls
            foreach (Control ctrl in this.gbSupBalance.Controls)
            {
                //Reset Textbox
                if (ctrl is TextBox) ctrl.ResetText();
                if (ctrl is TextBox && ctrl == txtBalance) txtBalance.ReadOnly = false;
                else if (ctrl is ComboBox) { ctrl.ResetText(); ctrl.Enabled = true; comboBalanceStatus.SelectedIndex = -1; }
            }
            //loop in all control in side this.pnlCustomers.Controls
            foreach (Control ctrl in this.pnlControls.Controls)
            {
                if (ctrl is Button && ctrl.Enabled == false) ctrl.Enabled = true;
            }
            //change visibility of pbCustomerStatus to false
            pbSupStatus.Visible = false;
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = SuppliersClass.GenerateSupplierID();
            //Focus on txtFullName
            txtFullName.Focus();
        }

        /// <summary>
        /// Method to Fill AutoCompleteCustomSource of Combobox
        /// After Create new instance From AutoCompleteStringCollection 
        /// </summary>
        /// <param name="combo">ComboboxName</param>
        /// <param name="listName">ListName</param>
        void AutoCompleteComboBox(ComboBox combo, List<string> listName)
        {
            //Create New Instance From AutoCompleteStringCollection to Make it CustomSource for ComboBox Area
            AutoCompleteStringCollection CustomArea = new AutoCompleteStringCollection();

            //Loop in items of Properties.Settings.Default.SettingsVariable.Cast<String>().ToList(); by foreah loop
            foreach (string item in listName)
            {
                //Add every Item to AutoCompleteStringCollection
                CustomArea.Add(item);
            }

            //Set AUtoCompleteSource of Combobox is AutoCompleteSource.CustomSource
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteCustomSource of combobox is AutoCompleteStringCollection
            combo.AutoCompleteCustomSource = CustomArea;
            //Set AutoCompleteSourceMode of Combobox is AUtoCompleteMode.Suggest / SuggestAppend
            combo.AutoCompleteMode = AutoCompleteMode.Suggest; 
        }

        /// <summary>
        /// void Method To Add Balance of Supplier To SuupplierAccount
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void AddBillToSupplierAccount(string iPPcName)
        {
            //Declare Decimal Variable to Calculate balance
            decimal balance = Convert.ToDecimal(txtBalance.Text);

            //if Customer Balance is Debit - (negative number)
            if (balance != 0 && comboBalanceStatus.SelectedIndex == 1)
            {
                //Change balnce to positive number 
                balance *= -1;

                //Add New Supplier to SupplierAccount Table
                SupAccountClass.SaveSupAccount(SupAccountClass.GenerateSupAccountID(), Convert.ToInt32(lblID.Text.Remove(0, 5)), 0, lblID.Text, "إضافة مورد", balance, 0, balance, "إنشاء مورد له رصيد سابق مدين", iPPcName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
            //if Customer Balance is Credit + (Positive number)
            else if (balance != 0 && comboBalanceStatus.SelectedIndex == 2)
            {
                //Add New Supplier to SupplierAccount Table
                SupAccountClass.SaveSupAccount(SupAccountClass.GenerateSupAccountID(), Convert.ToInt32(lblID.Text.Remove(0, 5)), 0, lblID.Text, "إضافة مورد", 0, balance, balance, "إنشاء مورد  له رصيد سابق دائن", iPPcName, Program.UsrID,
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

            //if user did not enter Digits and backspace and decimal point // && e.KeyChar !=  '-'
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != decChar && e.KeyChar != '-')
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //btnNew_Click Method To Clear Controls of Form
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                //Clear all Control by method ClearControls()
                ClearControls();
                //recall btnInfoTab_Click (object sender, EventArgs e) to back First Page
                btnInfoTab_Click(sender, e);
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
                if (SupAccessFRM != null) SupAccessFRM = null;
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

        //btnDelete_Click Method To Delet Supplier by Delete Record or Deactivate Supplier
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(SuppliersClass.GenerateSupplierID().ToString() New Customer ID) Do not modify
                if (lblID.Text.Contains(SuppliersClass.GenerateSupplierID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المورد لم يتم إضافته بعد", "تنبية",
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


                //if user select Yes Button and Select Delete Supplier From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Supplier From Database
                    SuppliersClass.DeleteSuppliers(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Delete All operations of Supplier Account From Database
                    SupAccountClass.DeleteSupAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف المورد بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Yes Button and Select InActivate Supplier From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Suppliers Table
                    SuppliersClass.DeactivateSuppliers(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Deactivate All operations of Supplier Account From Database
                    SupAccountClass.DeactivateSupAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف المورد بشكل مؤقت بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Exit Button
                else if (NotificationSMS.NotifyResult  == false)
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

        //btnModify_Click Method To Update Supplier
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(CustomersClass.GenerateCustomerID() New Customer ID) Do not modify
                if (lblID.Text.Contains(SuppliersClass.GenerateSupplierID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المورد لم يتم إضافته بعد", "تنبية",
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
                if (txtCreditLimit.Text == string.Empty || txtCreditLimit.Text == "0.000") txtCreditLimit.Text = "0";
                else
                {
                    //declare int variable then assign indexof("specific string"); which remove starts it 
                    int posOfCredit = txtCreditLimit.Text.IndexOf(" ج.م ");
                    //Remove start index
                    txtCreditLimit.Text = txtCreditLimit.Text.Remove(posOfCredit);
                }


                //Modify Suppliers Table
                SuppliersClass.UpdateSuppliers(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtFullName.Text, txtCompany.Text,
                                    txtResponsible.Text, txtPhone1.Text, txtPhone2.Text, txtPhone3.Text, txtFax.Text,
                                    txtAddress.Text, comboArea.Text, txtEmail.Text, comboSupType.Text,
                                    comboGroup.Text, comboSize.Text, Convert.ToDecimal(txtCreditLimit.Text),
                                    txtDiscount.Text, txtNotes.Text, IP_PCName, Program.UsrID);


                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل المورد بنجاح", "عملية التعديل",
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

        //btnSave_Click Method To Save New Supplier
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in Suppliers table + 1 
                //lblID.Text.Contains(SuppliersClass.GenerateSupplierID().ToString() New Supplier ID) Do not modify
                if (!lblID.Text.Contains(SuppliersClass.GenerateSupplierID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا المورد تم إضتافته من قبل", "تنبية",
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
                if (txtCreditLimit.Text == string.Empty || txtCreditLimit.Text == "0.000") txtCreditLimit.Text = "0";
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

                //Add New Supplier to Suppliers Table
                SuppliersClass.SaveSuppliers
                    (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, txtFullName.Text, txtCompany.Text, txtResponsible.Text, txtPhone1.Text,
                    txtPhone2.Text, txtPhone3.Text, txtFax.Text, txtAddress.Text, comboArea.Text,
                    txtEmail.Text, comboSupType.Text, comboGroup.Text, comboSize.Text,
                    Convert.ToDecimal(txtCreditLimit.Text), txtDiscount.Text, balance, txtNotes.Text, IP_PCName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));

                //Add Supplier Balance To Supplier Account Table
                AddBillToSupplierAccount(IP_PCName);

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ المورد بنجاح", "عملية الحفظ",
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

        //btnSearch_Click Method To Search in Suppliers Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_SupplierSearch
            FRM_SupplierSearch SearchForm = new FRM_SupplierSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        #endregion

        #region Validation Methods of Input Entry From User

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

        //txtFullName_TextChanged Method to hide error provider
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtFullName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderSuppliers.SetError(txtFullName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtFullName_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtCompany.Focus();
            }
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
                txtAddress.Focus();
            }
        }

        //txtAddress_TextChanged Method to hide error provider
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtAddress.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderSuppliers.SetError(txtAddress, "");
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
                txtResponsible.Focus();
            }
        }

        //txtResponsible_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtResponsible_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace and Space
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtResponsible_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtResponsible_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone1.Focus();
            }
        }

        //txtPhone1_TextChanged Method To hide error provider
        private void txtPhone1_TextChanged(object sender, EventArgs e)
        {
            // if txtPhone1 is equal Empty
            if (txtPhone1.Text != string.Empty && txtPhone1.Text.Length == 11)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderSuppliers.SetError(txtPhone1, "");
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
                txtPhone3.Focus();
            }
        }

        //txtPhone3_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtPhone3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtPhone3_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtPhone3_KeyDown(object sender, KeyEventArgs e)
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

        //txtEmail_Enter Method when Focus on txtEmail_Enter
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            //Information of Input Entry
            //SetError of errProviderSuppliers (controlName,"Info message")
            errProviderSuppliers.SetError(txtEmail, "Ex:- someone@gmail.com \n(Small Letters and English Letters)");
        }

        //txtEmail_Leave Method when left fromtxtEmail_Leave
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //Hide errProviderSuppliers (controlName,"")
            errProviderSuppliers.SetError(txtEmail, "");
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
                //Recall btnExtraTab Method (object sender,EventArgs e)
                btnExtraTab_Click(sender, e);
            }
        }

        //comboSupType_SelectedIndexChanged Method to check if Cash customer or postpaid
        private void comboSupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if user selectedIndex of comboSupplierType is cash customer
            if (comboSupType.SelectedIndex == 0)
            {
                //Clear txtCreditLimit
                txtCreditLimit.Clear();
                //disable txtCreditLimit
                txtCreditLimit.Enabled = false;
            }
            // if user selectedIndex of comboSupplierType is postpaid customer
            else if (comboSupType.SelectedIndex == 1 || comboSupType.SelectedIndex == -1)
            {
                //enable txtCreditLimit
                txtCreditLimit.Enabled = true;
            }
        }

        //comboSupType_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboSupType_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboArea.Focus();
            }
        }

        //comboSubArea_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboArea_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboGroup.Focus();
            }
        }

        //comboGroup_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboGroup_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboSize.Focus();
            }
        }

        //comboGroup_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboSize_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter && txtCreditLimit.Enabled != false)
            {
                //Move to Next Control by controlName.Focus();
                txtCreditLimit.Focus();
            }
            else if (e.KeyCode == Keys.Enter && txtCreditLimit.Enabled == false)
            {
                //Move to Next Control by controlName.Focus();
                txtDiscount.Focus();
            }
        }

        //txtCreditLimit_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Creadit limit its neccessary when you are selling Merchandise
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
            if (e.KeyCode == Keys.Enter && !txtCreditLimit.Text.Contains(" ج.م "))
            {
                //change format of txtCreditLimit after press on enter 2000 ج.م
                txtCreditLimit.Text = txtCreditLimit.Text + " ج.م ";
                //Move to Next Control by controlName.Focus();
                txtDiscount.Focus();
            }
            else if (e.KeyCode == Keys.Enter && txtCreditLimit.Text.Contains(" ج.م "))
            {
                //Move to Next Control by controlName.Focus();
                txtDiscount.Focus();
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
            if (e.KeyCode == Keys.Enter && !txtDiscount.Text.Contains(" %"))
            {
                //change format of txtdiscount after press on enter 12.52 %
                txtDiscount.Text = txtDiscount.Text + " %";
                //Move to Next Control by controlName.Focus();
                txtNotes.Focus();
            }
            else if (e.KeyCode == Keys.Enter && txtDiscount.Text.Contains(" %"))
            {
                //Move to Next Control by controlName.Focus();
                txtNotes.Focus();
            }
        }

        //txtBalance_KeyPress Method to Prevent user to press any characters except (- or backspace or digits)
        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Method to prevent user to press any characters except (- or backspace or digits) 
            //which Receive one Argument From KeyPressEventArgs e
            CheckInputForCurrency(e);
        }

        //txtBalance_Enter Method when Focus on txtBalance
        private void txtBalance_Enter(object sender, EventArgs e)
        {
            //Set Error of Error Provider to warn user to fill this field
            errProviderSuppliers.SetError(txtBalance, "يلزم ادخال رصيد المورد الدائن بالموجب\nاما رصيد المورد المدين بالسالب");
        }

        //btnInfoTab_Click Move to pnlInfoTab
        private void btnInfoTab_Click(object sender, EventArgs e)
        {
            //Check if Info Tab Panel is Visible equal true ==> stop executing block code
            if (pnlExtraTab.Visible == false) return;
            else
            {
                //Clear errProviderSuppliers
                errProviderSuppliers.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = btnExtraTab.BackColor;
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = btnExtraTab.ForeColor;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ControlText;
                //Send pnlExtraTab to Back
                pnlExtraTab.SendToBack();
                //Bring pnlInfoTab to Front
                pnlInfoTab.BringToFront();
                //Hide pnlExtraTab
                pnlExtraTab.Visible = false;
                //Focus on txtFullName
                txtFullName.Focus();
            }
        }

        //btnExtraTab_Click Move to pnlExtraTab
        private void btnExtraTab_Click(object sender, EventArgs e)
        {
            //Check if Info Tab Panel is Visible equal true ==> stop executing block code
            if (pnlExtraTab.Visible != false) return;
            else
            {
                //Clear errProviderSuppliers
                errProviderSuppliers.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = btnInfoTab.BackColor;
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = btnInfoTab.ForeColor;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ControlText;
                //Send pnlInfoTab to Back
                pnlInfoTab.SendToBack();
                //Bring pnlExtraTab to Front
                pnlExtraTab.BringToFront();
                //Appears pnlExtraTab
                pnlExtraTab.Visible = true;
                //Focus on comboSupType
                comboSupType.Focus();
            }
        }

        //btnAddArea_Click Method To add New area of supplier
        private void btnAddArea_Click(object sender, EventArgs e)
        {
            //Clear Text Of ComboBox
            comboArea.Text = null;
            //Create new instance from FRM_SupplierArea
            FRM_SupplierArea AreaForm = new FRM_SupplierArea();
            //Show this instance in mode ShowDialog to control it as first
            AreaForm.ShowDialog();
        }

        //btnAddGroup_Click Method To add New group of supplier
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            //Clear Text Of ComboBox
            comboGroup.Text = null;
            //Create new instance from FRM_SupplierGroup
            FRM_SupplierGroup GroupForm = new FRM_SupplierGroup();
            //Show this instance in mode ShowDialog to control it as first
            GroupForm.ShowDialog();
        }

        //btnAddSize_Click Method To add New Size of supplier
        private void btnAddSize_Click(object sender, EventArgs e)
        {
            //Clear Text Of ComboBox
            comboSize.Text = null;
            //Create new instance from FRM_SupplierSize
            FRM_SupplierSize SizeForm = new FRM_SupplierSize();
            //Show this instance in mode ShowDialog to control it as first
            SizeForm.ShowDialog();
        }

        //timerSuppliers_Tick Method when timer start ever 1200 tick Rotate image in picturebox
        private void timerSuppliers_Tick(object sender, EventArgs e)
        {
            //Declare image variable then assignment pbSupStatus.Image to ImgRotate
            Image ImgRotate = pbSupStatus.Image;
            //Initialize RotateFlip of Image like ==> Img.RotateFlip(RotateFlipType.Rotate(90-180-270)FlipXY
            //X Rotate image Horizantal or Y Rotate image Vertical
            ImgRotate.RotateFlip(RotateFlipType.Rotate90FlipXY);
            //Assign the rotate image to picture box
            pbSupStatus.Image = ImgRotate;
        }

        //pbSupStatus_MouseHover Method when user stop or hover on picturebox by mouse to stop rotateFlip image
        private void pbSupStatus_MouseHover(object sender, EventArgs e)
        {
            //Set Enable of timer is false
            timerSuppliers.Enabled = false;
            //stop timer
            timerSuppliers.Stop();
        }

        //pbCustomerStatus_MouseLeave Method when user mouse leave of picturebox to rotate image
        private void pbSupStatus_MouseLeave(object sender, EventArgs e)
        {
            //Enable of timer is true
            timerSuppliers.Enabled = true;
            //Start Timer
            timerSuppliers.Start();
        }

        //pbCustomerStatus_Click Method to Activate Supplier
        private void pbSupStatus_Click(object sender, EventArgs e)
        {
            try
            {
                //if picture box contains Enable_Client image so ==> stop to executing block code
                if (pbSupStatus.Image == Properties.Resources.Enable_Client) return;
                //else

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Update Status to true in Suppliers Table
                SuppliersClass.DeactivateSuppliers(Convert.ToInt32(lblID.Text.Remove(0, 5)), true, IP_PCName, Program.UsrID);

                //Activate All operations of Supplier Account From Database
                SupAccountClass.DeactivateSupAccount(Convert.ToInt32(lblID.Text.Remove(0, 5)), true, IP_PCName, Program.UsrID);

                //Alarm Success deactive Message Box 
                NotificationSMS.NotifyShow("تم تنشيط المورد بنجاح", "عملية التعديل",
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

        //comboArea_DropDown Method to Load Datasource of combobox in dropdown Event (Lazy Loading)
        private void comboArea_DropDown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SupplierAreas.Cast<string>().ToList().Count == 0)
            {
                btnAddArea_Click(sender, e);
            }
            /* After Convert System.Collections.Specialized.StringCollections to 
             * System.Collections.Generic.List<System.String> In Settings.cs file */
            //Set DataSource of Combobox is Properties.Settings.Default.SettingsVariableName.Cast<string>().ToList();
            comboArea.DataSource = Properties.Settings.Default.SupplierAreas.Cast<string>().ToList();
        }

        //comboGroup_DropDown Method to Load Datasource of combobox in dropdown Event (Lazy Loading)
        private void comboGroup_DropDown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SupplierGroups.Cast<string>().ToList().Count == 0)
            {
                btnAddGroup_Click(sender, e);
            }
            //if ()
            /* After Convert System.Collections.Specialized.StringCollections to 
             * System.Collections.Generic.List<System.String> In Settings.cs file */
            //Set DataSource of Combobox is Properties.Settings.Default.SettingsVariableName.Cast<string>().ToList();
            comboGroup.DataSource = Properties.Settings.Default.SupplierGroups.Cast<string>().ToList();
        }

        //comboSize_DropDown Method to Load Datasource of combobox in dropdown Event (Lazy Loading)
        private void comboSize_DropDown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SupplierSizes.Cast<string>().ToList().Count == 0)
            {
                btnAddSize_Click(sender, e);
            }
            /* After Convert System.Collections.Specialized.StringCollections to 
             * System.Collections.Generic.List<System.String> In Settings.cs file */
            //Set DataSource of Combobox is Properties.Settings.Default.SettingsVariableName.Cast<string>().ToList();
            comboSize.DataSource = Properties.Settings.Default.SupplierSizes.Cast<string>().ToList();
        }

        //FRM_Suppliers_Load Method to enable Auto complete Combobox 
        private void FRM_Suppliers_Load(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.SupplierAreas.Cast<string>().ToList().Count > 0)
                    //To enable AutoCompleteCustomSource
                    AutoCompleteComboBox(comboArea, Properties.Settings.Default.SupplierAreas.Cast<string>().ToList());
                if (Properties.Settings.Default.SupplierGroups.Cast<string>().ToList().Count > 0)
                    //To enable AutoCompleteCustomSource
                    AutoCompleteComboBox(comboGroup, Properties.Settings.Default.SupplierGroups.Cast<string>().ToList());
                if (Properties.Settings.Default.SupplierSizes.Cast<string>().ToList().Count > 0)
                    //To enable AutoCompleteCustomSource
                    AutoCompleteComboBox(comboSize, Properties.Settings.Default.SupplierSizes.Cast<string>().ToList());
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

        //comboBalanceStatus_Validated Method to check Validation Input Entry in comboBalanceStatus
        private void comboBalanceStatus_Validated(object sender, EventArgs e)
        {
            // if comboBalanceStatus is equal Empty
            if (comboBalanceStatus.SelectedIndex == -1 && txtBalance.Text != "0")
            {
                //Set Error of Error Provider to warn user to fill this field
                errProviderSuppliers.SetError(comboBalanceStatus, "هذا الحقل اجبارى");
                //Focus on the same field comboBalanceStatus
                comboBalanceStatus.Focus();
                //Increase Counter of error by one
                CountOfErrors += 1;
            }
        }

        #endregion

    }
}
