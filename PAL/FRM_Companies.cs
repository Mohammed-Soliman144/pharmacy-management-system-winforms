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
using System.IO;

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Companies : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Companies Business Access Layer
        readonly BAL.CLS_Companies CompaniesClass = new BAL.CLS_Companies();
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

        #region Using Object Oriented Programing to access FRM_Companies Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Companies CompAccessFRM;

        //Create CompAccess_FormClosed to recall it when close form
        private static void CompAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            CompAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Companies CompAccess_Property
        {
            //used getter to return value of FRM_Companies 
            get
            {
                //if created instance or field is null
                if (CompAccessFRM == null)
                {
                    //Create New Instance From FRM_Companies by initialize it to field
                    CompAccessFRM = new FRM_Companies();
                    //Generate Event of Form Closed and Delegate Method CompAccess_FormClosed to it
                    CompAccessFRM.FormClosed += new FormClosedEventHandler(CompAccess_FormClosed);
                }
                //Return the value of field
                return CompAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Suppliers
        public FRM_Companies()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Companies to it 
            if (CompAccessFRM == null) CompAccessFRM = this;
            //Load Users Table and fill combobox by UserName
            LoadComboBox();
            //Set Default value of DateTimePicker is first day of Current year
            //by Initialize new DateTime (year,Month,Day) for datetimepicker
            dtpStartFinancial.Value = new DateTime(dtpStartFinancial.Value.Year, 1, 1);
            //Set Default value of DateTimePicker is End day of Current year
            //by Initialize new DateTime (year,Month,Day) for datetimepicker
            dtpEndFinancial.Value = new DateTime(dtpEndFinancial.Value.Year, 12, 31);
            // if count of companies save more than one enabled btnSave is false
            if (Convert.ToInt32(CompaniesClass.GenerateCompanyID().Remove(0, 5)) == 2) btnSave.Enabled = false;
            //Generate new Company ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = CompaniesClass.GenerateCompanyID();
            //if (CompaniesClass.GenerateCompanyID())
            //Focus on txtName
            txtName.Focus();
            //Store Image of Picture box in Image Variable
            img = pbLogo.Image;
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
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl == txtName)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderCompanies.SetError(ctrl, "هذا الحقل اجبارى");
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
            }
            //if CountOfErrors > 0 ==>  pnlInfoTab.BringToFront()
            if (CountOfErrors > 0) pnlInfoTab.BringToFront();
            //Return CounterOfErrors
            return CountOfErrors;
        }

        /// <summary>
        /// Method to loop of controls and Reset it to Default Values
        /// </summary>
        void ClearControls()
        {
            //Clear Error Provider
            errProviderCompanies.Clear();
            //loop in all control in side this.pnlInfoTab.Controls
            foreach (Control ctrl in this.pnlInfoTab.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                else if (ctrl is PictureBox && pbLogo.Image != img) pbLogo.Image = img;
            }
            //loop in all control in side this.pnlExtraTab.Controls
            foreach (Control ctrl in this.pnlExtraTab.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.pnlControls.Controls
            foreach (Control ctrl in this.pnlControls.Controls)
            {
                //Reset Enabled of buttons except btnsave
                if (ctrl is Button && ctrl.Enabled == false && ctrl != btnSave) ctrl.Enabled = true;
                // if count of companies save more than one enabled btnSave is false
                if (Convert.ToInt32(CompaniesClass.GenerateCompanyID().Remove(0, 5)) == 2)
                {
                    btnSave.Enabled = false;
                }
                else if (Convert.ToInt32(CompaniesClass.GenerateCompanyID().Remove(0, 5)) <= 1)
                {
                    btnSave.Enabled = true;
                }
            }
            //Set Default value of DateTimePicker is first day of Current year
            //by Initialize new DateTime (year,Month,Day) for datetimepicker
            dtpStartFinancial.Value = new DateTime(dtpStartFinancial.Value.Year, 1, 1);
            //Set Default value of DateTimePicker is End day of Current year
            //by Initialize new DateTime (year,Month,Day) for datetimepicker
            dtpEndFinancial.Value = new DateTime(dtpEndFinancial.Value.Year, 12, 31);
            //Generate new User ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = CompaniesClass.GenerateCompanyID();
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

        /// <summary>
        /// Private AutoCompleteStringCollection Function to support user to fill textbox
        /// </summary>
        /// <param name="txt">TextBox</param>
        /// <returns>AutoCompleteStringCollection (list of string)</returns>
        AutoCompleteStringCollection AutoCompleteFromDB (TextBox txt)
        {
            //Create New instance from AutoCompleteStringCollection
            AutoCompleteStringCollection colDB = new AutoCompleteStringCollection();
            //Declare of DataTable and initialize Companies Records of table in database to it
            DataTable dt = CompaniesClass.ShowCompaniesTable();
            // if rows of datatable greater than one 
            if (dt.Rows.Count >= 1)
            {
                //Loop in all rows of datatable to fill AutoCompleteStringCollection ColDB
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    if (txt == txtCity)
                    {
                        colDB.Add(dt.Rows[i]["المدينة"].ToString());
                    }
                    else if (txt == txtCountry)
                    {
                        colDB.Add(dt.Rows[i]["الدولة"].ToString());
                    }
                    else if (txt == txtComCategory)
                    {
                        colDB.Add(dt.Rows[i]["نشاط الشركة"].ToString());
                    }
                }
            }
            //AutoCompleteStringCollection ColDB
            return colDB;
        }

        /// <summary>
        /// Private Void Method to Set AutoCompleteSource of Textbox
        /// </summary>
        /// <param name="collect">AutoCompleteStringCollection</param>
        /// <param name="txt">TextBox</param>
        void SetSourceOfTextBox (AutoCompleteStringCollection collect, TextBox txt)
        {
            //Set AUtoCompleteCustomSource of TextBox is AutoCompleteStringCollection
            txt.AutoCompleteCustomSource = collect;
            //Set AutoCompleteMode of Textbox is AutoCompleteMode.Suggest
            txt.AutoCompleteMode = AutoCompleteMode.Suggest;
            //Set AutoCompleteSource of Textbox is AutoCompleteSource.CustomSource (Enumeration enum)
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
                if (CompAccessFRM != null) CompAccessFRM = null;
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

        //btnDelete_Click Method To Delete Company by Delete Record or Deactivate Companies
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(CompaniesClass.GenerateCompanyID().ToString() New Customer ID) Do not modify
                if (lblID.Text.Contains(CompaniesClass.GenerateCompanyID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذة الشركة لم يتم إضافتها بعد", "تنبية",
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


                //if user select Yes Button and Select Delete Company From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Company From Database
                    CompaniesClass.DeleteCompanies(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف الشركة بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Yes Button and Select InActivate Company From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("لا يمكن ايقاف بيانات الشركة الرئيسية بشكل مؤقت", "تنبية",
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

        //btnModify_Click Method To Update Companies
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(CompaniesClass.GenerateCompanyID() New Company ID) Do not modify
                if (lblID.Text.Contains(CompaniesClass.GenerateCompanyID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذة الشركة لم يتم إضافتها بعد", "تنبية",
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

                // (pbLogo.Image != Default image)
                if (pbLogo.Image != img)
                {
                    //Create New Instance From MemoryStream
                    MemoryStream MemStream = new MemoryStream();
                    //Save Image in picture box in memorystream
                    pbLogo.Image.Save(MemStream, pbLogo.Image.RawFormat);
                    //Create new array of byte[] to store it in database with define length of it [] {}
                    byte[] ImgByte = new byte[] { };
                    //Initialize image in memory stream to byte array after convert memory stream to array
                    ImgByte = MemStream.ToArray();

                    //Modify Companies Table
                    CompaniesClass.UpdateCompanies(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtName.Text, txtPhone1.Text,
                                                 txtPhone2.Text, txtPhone3.Text, txtFax.Text,
                                    txtEmail.Text, txtWebsite.Text, txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue),
                                    ImgByte, "WithImage",comboCompType.Text,txtComCategory.Text,txtCommerical.Text,
                                    txtTax.Text,txtCity.Text,txtCountry.Text, dtpStartFinancial.Value.ToString("yyyy-MM-dd"), 
                                    dtpEndFinancial.Value.ToString("yyyy-MM-dd"), IP_PCName, Program.UsrID);
                }
                // If User did not Add Image to current Company
                else
                {
                    //Create new array of byte[] is Null byte without elements
                    byte[] ImgByte = new byte[] { };

                    //Modify Companies Table
                    CompaniesClass.UpdateCompanies(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtName.Text, txtPhone1.Text,
                                                 txtPhone2.Text, txtPhone3.Text, txtFax.Text,
                                    txtEmail.Text, txtWebsite.Text, txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue),
                                    ImgByte, "WithoutImage", comboCompType.Text, txtComCategory.Text, txtCommerical.Text,
                                    txtTax.Text, txtCity.Text, txtCountry.Text, dtpStartFinancial.Value.ToString("yyyy-MM-dd"),
                                    dtpEndFinancial.Value.ToString("yyyy-MM-dd"), IP_PCName, Program.UsrID);
                }

                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل الشركة بنجاح", "عملية التعديل",
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

        //btnSave_Click Method To Save New Companies
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in Companies table + 1 
                //lblID.Text.Contains(CompaniesClass.GenerateCompanyID().ToString() New Company ID) Do not modify
                if (!lblID.Text.Contains(CompaniesClass.GenerateCompanyID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذة الشركة تم إضتافتها من قبل", "تنبية",
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
                // (pbLogo.Image != Default image)
                if (pbLogo.Image != img)
                {
                    //Create New Instance From MemoryStream
                    MemoryStream MemStream = new MemoryStream();
                    //Save Image in picture box in memorystream
                    pbLogo.Image.Save(MemStream, pbLogo.Image.RawFormat);
                    //Create new array of byte[] to store it in database with define length of it [] {}
                    byte[] ImgByte = new byte[] { };
                    //Initialize image in memory stream to byte array after convert memory stream to array
                    ImgByte = MemStream.ToArray();

                    //Save Companies Table
                    CompaniesClass.SaveCompanies
                        (lblID.Text, txtName.Text, txtPhone1.Text, txtPhone2.Text, txtPhone3.Text,
                         txtFax.Text, txtEmail.Text, txtWebsite.Text, txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue),
                         ImgByte, "WithImage", comboCompType.Text, txtComCategory.Text, txtCommerical.Text,
                         txtTax.Text, txtCity.Text, txtCountry.Text, dtpStartFinancial.Value.ToString("yyyy-MM-dd"),
                         dtpEndFinancial.Value.ToString("yyyy-MM-dd"), IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), 
                         DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));
                }
                // If User did not Add Image to current Company
                else
                {
                    //Create new array of byte[] is Null byte without elements
                    byte[] ImgByte = new byte[] { };

                    //Save Companies Table
                    CompaniesClass.SaveCompanies
                        (lblID.Text, txtName.Text, txtPhone1.Text, txtPhone2.Text, txtPhone3.Text,
                         txtFax.Text, txtEmail.Text, txtWebsite.Text, txtAddress.Text, Convert.ToInt32(comboManager.SelectedValue),
                         ImgByte, "WithoutImage", comboCompType.Text, txtComCategory.Text, txtCommerical.Text,
                         txtTax.Text, txtCity.Text, txtCountry.Text, dtpStartFinancial.Value.ToString("yyyy-MM-dd"),
                         dtpEndFinancial.Value.ToString("yyyy-MM-dd"), IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"),
                         DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));
                }

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ الشركة بنجاح", "عملية الحفظ",
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

        //btnSearch_Click Method To Search in Companies Table
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_CompanySearch
            FRM_CompanySearch SearchForm = new FRM_CompanySearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
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
                                "|BMP Files|*.BMP; |Icons Files|*.ICO;";
                //Initialize Filter Index which need to Select as First
                ofd.FilterIndex = 1;
                //if user select image and press ok
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //Set PictureBox.SizeMode = PictureSizeMode.StretchImage
                    pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                    //load picturebox.Image = Image.FromFile(OFD.FileName)
                    pbLogo.Image = Image.FromFile(ofd.FileName);
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
            //if pbLogo.image is not equal img Default reset it
            if (pbLogo.Image != img)
            {
                pbLogo.Image = img;
            }
            else return;
        }

        //btnInfoTab_Click Method To Move to pnlInfoTab
        private void btnInfoTab_Click(object sender, EventArgs e)
        {
            //Check if Info Tab Panel is Visible equal true ==> stop executing block code
            if (pnlExtraTab.Visible == false) return;
            else
            {
                //Clear errProviderCompanies
                errProviderCompanies.Clear();
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
                //Focus on txtName
                txtName.Focus();
            }
        }

        //btnExtraTab_Click Method To Move to pnlExtraTab
        private void btnExtraTab_Click(object sender, EventArgs e)
        {
            //Check if Info Tab Panel is Visible equal true ==> stop executing block code
            if (pnlExtraTab.Visible != false) return;
            else
            {
                //Clear errProviderCompanies
                errProviderCompanies.Clear();
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
                //Focus on comboCompType
                comboCompType.Focus();
            }
        }

        //FRM_Companies_Load Method to Set AutoCompleteSource of TextBox
        private void FRM_Companies_Load(object sender, EventArgs e)
        {
            //Set AutoCompleteSource of txtCity by Recall void Method SetSourceOfTextBox();
            SetSourceOfTextBox(AutoCompleteFromDB(txtCity), txtCity);
            //Set AutoCompleteSource of txtCountry by Recall void Method SetSourceOfTextBox();
            SetSourceOfTextBox(AutoCompleteFromDB(txtCountry), txtCountry);
            //Set AutoCompleteSource of txtComCategory by Recall void Method SetSourceOfTextBox();
            SetSourceOfTextBox(AutoCompleteFromDB(txtComCategory), txtComCategory);
        }

        //btnClose_Click Method To Close FRM_Companies
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Information Message Box
                MessageBox.Show("سيتم التوجة إلى تسجيل بيانات الفروع", "تنبية", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                //Create New Instance from FRM_Branches 
                FRM_Branches BranchForm = new FRM_Branches();
                //Control buttons in form Branches by Encapsulation or Properties or Setter and Getter
                //Disable the Delete Branches Button
                FRM_Branches.BranchAccess_Property.btnDelete.Enabled = false;
                //Disable the Modify Branches Button
                FRM_Branches.BranchAccess_Property.btnModify.Enabled = false;
                //Disable the Search Branches Button
                FRM_Branches.BranchAccess_Property.btnSearch.Enabled = false;
                //Hide the Exit Branches Button
                FRM_Branches.BranchAccess_Property.btnExit.Visible = false;
                //Appearing the Close Branches Button
                FRM_Branches.BranchAccess_Property.btnClose.Visible = true;
                //Show the User Form in mode ShowDialog to Control of it
                BranchForm.ShowDialog();

                //check if field you are created is null when closed form if not Assign null value to field
                if (CompAccessFRM != null) CompAccessFRM = null;
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

        #region Validation Methods of Input Entry From User

        //txtName_TextChanged Method to check Valadation of User Inputs
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderCompanies.SetError(txtName, "");
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
                txtComCategory.Focus();
            }
        }

        //txtComCategory_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtComCategory_KeyDown(object sender, KeyEventArgs e)
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
                txtCity.Focus();
            }
        }

        //txtCity_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtCountry.Focus();
            }
        }

        //txtCountry_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtPhone1.Focus();
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

        //txtEmail_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtWebsite.Focus();
            }
        }

        //txtWebsite_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Recall Method of btnExtraTab_Click (object sender, EventArgs e) 
                btnExtraTab_Click(sender, e);
            }
        }

        //comboCompType_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void comboCompType_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtCommerical.Focus();
            }
        }

        //txtCommerical_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtCommerical_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtTax.Focus();
            }
        }

        //txtTax_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void txtTax_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                dtpStartFinancial.Focus();
            }
        }

        //dtpStartFinancial_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void dtpStartFinancial_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                dtpEndFinancial.Focus();
            }
        }

        //dtpEndFinancial_KeyDown Method to Move Next Control (KeyDown and KeyUp deal with KeyCode)
        private void dtpEndFinancial_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                comboManager.Focus();
            }
        }

        //btnAddManager_Click Method To Move FRM_Users 
        private void btnAddManager_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (CompAccessFRM != null) CompAccessFRM = null;
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

        //txtCommerical_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtCommerical_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtTax_KeyPress Method to check Validation of Input Entry from user (keyPress deal with keychar)
        private void txtTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        //txtEmail_KeyPress Method to check Validation of email
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if input entry is not equal characters in bool function like ValidationOfEmail.contains (e.keyChar)
            //or input entry is not equal backspace  so e.handled = true; prevent user to ener characters
            if (!ValidationOfEmail(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        //txtWebsite_KeyPress Method to check Validation of Website
        private void txtWebsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if input entry is not equal characters in bool function like ValidationOfEmail.contains (e.keyChar)
            //or input entry is not equal backspace  so e.handled = true; prevent user to ener characters
            if (!ValidationOfEmail(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        #endregion
  
    }
}
