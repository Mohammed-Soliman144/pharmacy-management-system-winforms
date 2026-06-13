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
    public partial class FRM_Items : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_Items Business Access Layer
        readonly BAL.CLS_Items ItemsClass = new BAL.CLS_Items();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Items Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Items ItemAccessFRM;

        //Create CompAccess_FormClosed to recall it when close form
        private static void ItemAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            ItemAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Items ItemAccess_Property
        {
            //used getter to return value of FRM_Items 
            get
            {
                //if created instance or field is null
                if (ItemAccessFRM == null)
                {
                    //Create New Instance From FRM_Items by initialize it to field
                    ItemAccessFRM = new FRM_Items();
                    //Generate Event of Form Closed and Delegate Method ItemAccess_FormClosed to it
                    ItemAccessFRM.FormClosed += new FormClosedEventHandler(ItemAccess_FormClosed);
                }
                //Return the value of field
                return ItemAccessFRM;
            }
        }
        #endregion

        //Constructor of FRM_Items **Done**
        public FRM_Items()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Items to it 
            if (ItemAccessFRM == null) ItemAccessFRM = this;
            //Generate new Item ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = ItemsClass.GenerateItemID();
            //Focus on txtItemName
            txtItemName.Focus();
        }

        #region Methods And Functions

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //loop in all controls of form in pnlInfo.Controls by foreach loop Case ==> (1)
            foreach (Control ctrl in this.pnlInfo.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                else if (ctrl is ComboBox && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                if (CountOfErrors > 0)
                {
                    pnlInfo.BringToFront();
                    return CountOfErrors;
                }
            }
            //loop in all controls of form in pnlUnits.Controls by foreach loop Case ==> (2)
            foreach (Control ctrl in this.pnlUnits.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl != txtLargeUnitBuyPrice
                    && ctrl != txtMediumUnitBuyPrice && ctrl != txtSmallUnitBuyPrice
                    && ctrl != txtLargeUnitBalance && ctrl != txtMediumUnitBalance
                    && ctrl != txtSmallUnitBalance)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                else if (ctrl is ComboBox && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                if (CountOfErrors > 0)
                {
                    pnlUnits.BringToFront();
                    return CountOfErrors;
                }
            }
            //loop in all controls of form in pnlUnits.Controls by foreach loop Case ==> (3)
            foreach (Control ctrl in this.pnlItemBarcode.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl == txtItemBarcode1)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                if (CountOfErrors > 0)
                {
                    pnlItemBarcode.BringToFront();
                    return CountOfErrors;
                }
            }
            //loop in all controls of form in pnlItemExtra.Controls by foreach loop Case ==> (4)
            foreach (Control ctrl in this.pnlItemExtra.Controls)
            {
                //if dtpExpiryDate is equal date of today and dtpExpiryDate is equal dtpManuDate and visible is true
                if (ctrl is DateTimePicker && ctrl.Visible == true  && dtpExpiryDate.Value == dtpManuDate.Value)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderItems.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
                if (CountOfErrors > 0)
                {
                    pnlItemExtra.BringToFront();
                    return CountOfErrors;
                }
            }
            //Return CounterOfErrors
            return CountOfErrors;
        }

        /// <summary>
        /// Method to loop of controls and Reset it to Default Values
        /// </summary>
        void ClearControls()
        {
            //Clear Error Provider
            errProviderItems.Clear();
            //loop in all control in side this.pnlInfo.Controls
            foreach (Control ctrl in this.pnlInfo.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.pnlUnits.Controls
            foreach (Control ctrl in this.pnlUnits.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //loop in all control in side this.pnlItemBarcode.Controls
            foreach (Control ctrl in this.pnlItemBarcode.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
            }
            //loop in all control in side this.pnlItemExtra.Controls
            foreach (Control ctrl in this.pnlItemExtra.Controls)
            {
                if (ctrl is TextBox) ctrl.ResetText();
                if (ctrl is DateTimePicker)
                {
                    ctrl.ResetText();
                    ctrl.Visible = false;
                }
                //loop in all checkbox in checkedlistbox by for loop
                for (int i=0; i < checkListTypeItems.Items.Count; i++)
                {
                    //Use Method CheckedListBox.SetItemChecked(index of checkbox, bool checked false or true)
                    checkListTypeItems.SetItemChecked(i, false);
                }
            }
            //Set Text of txtItemLargeUnitNo equal is 1
            txtItemLargeUnitNo.Text = "1";
            //Generate new Item ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = ItemsClass.GenerateItemID();
            //Focus on txtItemName
            txtItemName.Focus();
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

        /// <summary>
        /// To Primit user to enter any digits except number Digits and backspace Only
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        void CheckInputForCount(KeyPressEventArgs e)
        {
            //Creadit limit its neccessary when you are selling Merchandise
            // if user did not enter Digits and backspace 
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                //e.Handled = true; prevent user to enter any characters except the above
                e.Handled = true;
            }
        }

        /// <summary>
        /// ResetDecimalFields void Method to reset Control in pnlUnits 
        /// which control is decimal fields to null or zero
        /// </summary>
        void ResetDecimalFields ()
        {
            foreach (Control ctrl in pnlUnits.Controls)
            {
                //if ctrl.text is empty initialize zero value "0"
                if (ctrl is TextBox && ctrl.Text == string.Empty && ctrl != txtLargeUnitSalePrice
                    && ctrl != txtMediumUnitSalePrice && ctrl != txtSmallUnitSalePrice
                    && ctrl != txtItemLargeUnitNo && ctrl != txtItemMediumUnitNo
                    && ctrl != txtItemSmallUnitNo) ctrl.Text = "0";
            }
        }

        //btnInfoTab_Click Method To Move to panel Info **Done**
        private void btnInfoTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if btnBarcodeTab is Visible equal true ==> stop executing block code
            if ((btnBarcodeTab.Visible == true && btnBarcodeTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemBarcode to Back
                pnlItemBarcode.SendToBack();
                //Bring pnlInfo to Front
                pnlInfo.BringToFront();
            }
            // Case ==> (2)
            //Check if  btnUnitsTab is Visible equal true ==> stop executing block code
            else if ((btnUnitsTab.Visible == true && btnUnitsTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ControlText;
                //Send pnlUnits to Back
                pnlUnits.SendToBack();
                //Bring pnlInfo to Front
                pnlInfo.BringToFront();
                //Focus on txtItemName
                txtItemName.Focus();
            }
            // Case ==> (3)
            //Check if  btnExtraTab is Visible equal true ==> stop executing block code
            else if ((btnExtraTab.Visible == true && btnExtraTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemExtra to Back
                pnlItemExtra.SendToBack();
                //Bring pnlInfo to Front
                pnlInfo.BringToFront();
                //Focus on txtItemName
                txtItemName.Focus();
            }
        }

        //btnNew_Click Method To Clear Controls of Form  **Done**
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

        //btnUnitsTab_Click Method To Move to panel Units **Done**
        private void btnUnitsTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if btnBarcodeTab is Visible equal true ==> stop executing block code
            if ((btnBarcodeTab.Visible == true && btnBarcodeTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemBarcode to Back
                pnlItemBarcode.SendToBack();
                //Bring pnlUnits to Front
                pnlUnits.BringToFront();
                //Focus on comboItemLargeUnit
                comboItemLargeUnit.Focus();
            }
            // Case ==> (2)
            //Check if  btnInfoTab is Visible equal true ==> stop executing block code
            else if ((btnInfoTab.Visible == true && btnInfoTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ControlText;
                //Send pnlInfo to Back
                pnlInfo.SendToBack();
                //Bring pnlUnits to Front
                pnlUnits.BringToFront();
                //Focus on comboItemLargeUnit
                comboItemLargeUnit.Focus();
            }
            // Case ==> (3)
            //Check if  btnExtraTab is Visible equal true ==> stop executing block code
            else if ((btnExtraTab.Visible == true && btnExtraTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemExtra to Back
                pnlItemExtra.SendToBack();
                //Bring pnlUnits to Front
                pnlUnits.BringToFront();
                //Focus on comboItemLargeUnit
                comboItemLargeUnit.Focus();
            }
        }

        //btnBarcodeTab_Click Method To Move to panel Units **Done**
        private void btnBarcodeTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if btnInfoTab is Visible equal true ==> stop executing block code
            if ((btnInfoTab.Visible == true && btnInfoTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ControlText;
                //Send pnlInfo to Back
                pnlInfo.SendToBack();
                //Bring pnlItemBarcode to Front
                pnlItemBarcode.BringToFront();
                //Focus on txtItemBarcode1
                txtItemBarcode1.Focus();
            }
            // Case ==> (2)
            //Check if  btnUnitsTab is Visible equal true ==> stop executing block code
            else if ((btnUnitsTab.Visible == true && btnUnitsTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ControlText;
                //Send pnlUnits to Back
                pnlUnits.SendToBack();
                //Bring pnlItemBarcode to Front
                pnlItemBarcode.BringToFront();
                //Focus on txtItemBarcode1
                txtItemBarcode1.Focus();
            }
            // Case ==> (3)
            //Check if  btnExtraTab is Visible equal true ==> stop executing block code
            else if ((btnExtraTab.Visible == true && btnExtraTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemExtra to Back
                pnlItemExtra.SendToBack();
                //Bring pnlItemBarcode to Front
                pnlItemBarcode.BringToFront();
                //Focus on txtItemBarcode1
                txtItemBarcode1.Focus();
            }
        }

        //btnExtraTab_Click Method To Move to panel Units **Done**
        private void btnExtraTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if btnInfoTab is Visible equal true ==> stop executing block code
            if ((btnInfoTab.Visible == true && btnInfoTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnInfoTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnInfoTab.ForeColor = SystemColors.ControlText;
                //Send pnlInfo to Back
                pnlInfo.SendToBack();
                //Bring pnlItemExtra to Front
                pnlItemExtra.BringToFront();
                //Focus on lblItemBarcode1
                txtItemLimit.Focus();
            }
            // Case ==> (2)
            //Check if  btnUnitsTab is Visible equal true ==> stop executing block code
            else if ((btnUnitsTab.Visible == true && btnUnitsTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnUnitsTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnUnitsTab.ForeColor = SystemColors.ControlText;
                //Send pnlUnits to Back
                pnlUnits.SendToBack();
                //Bring pnlItemExtra to Front
                pnlItemExtra.BringToFront();
                //Focus on lblItemBarcode1
                txtItemLimit.Focus();
            }
            // Case ==> (3)
            //Check if  btnBarcodeTab is Visible equal true ==> stop executing block code
            else if ((btnBarcodeTab.Visible == true && btnBarcodeTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderItems
                errProviderItems.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnExtraTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnExtraTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBarcodeTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBarcodeTab.ForeColor = SystemColors.ControlText;
                //Send pnlItemBarcode to Back
                pnlItemBarcode.SendToBack();
                //Bring pnlItemExtra to Front
                pnlItemExtra.BringToFront();
                //Focus on lblItemBarcode1
                txtItemLimit.Focus();
            }
        }

        //btnExit_Click Method To Close Form **Done**
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (ItemAccessFRM != null) ItemAccessFRM = null;
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

        //btnAddDosageForm_Click Method to Move ItemDosageForm Form **Done**
        private void btnAddDosageForm_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemDosageForm
            FRM_ItemDosageForm DosageFrm = new FRM_ItemDosageForm();
            //Show this instance in mode ShowDialog to control it as first
            DosageFrm.ShowDialog();
        }

        //btnAddGenerics_Click Method to Move FRM_ItemGenerics Form **Done**
        private void btnAddGenerics_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemGenerics
            FRM_ItemGenerics GenericFrm = new FRM_ItemGenerics();
            //Show this instance in mode ShowDialog to control it as first
            GenericFrm.ShowDialog();
        }

        //btnAddClassOfActions_Click Method to Move FRM_ItemClassOfActions Form **Done**
        private void btnAddClassOfActions_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemClassOfActions
            FRM_ItemClassOfActions ActionFrm = new FRM_ItemClassOfActions();
            //Show this instance in mode ShowDialog to control it as first
            ActionFrm.ShowDialog();
        }

        //btnAddGroups_Click Method to Move FRM_ItemGroups Form **Done**
        private void btnAddGroups_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemClassOfActions
            FRM_ItemGroups GroupFrm = new FRM_ItemGroups();
            //Show this instance in mode ShowDialog to control it as first
            GroupFrm.ShowDialog();
        }

        //btnAddCompanies_Click Method to Move FRM_ItemCompanies Form **Done**
        private void btnAddCompanies_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemCompanies
            FRM_ItemCompanies CompanyFrm = new FRM_ItemCompanies();
            //Show this instance in mode ShowDialog to control it as first
            CompanyFrm.ShowDialog();
        }

        //btnAddPlaces_Click Method to Move FRM_ItemPlaces Form **Done**
        private void btnAddPlaces_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemPlaces
            FRM_ItemPlaces PlaceFrm = new FRM_ItemPlaces();
            //Show this instance in mode ShowDialog to control it as first
            PlaceFrm.ShowDialog();
        }

        //btnAddClassOfActions_Click Method to Move FRM_ItemUnits Form **Done**
        private void lblAddUnits_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ItemUnits
            FRM_ItemUnits UnitFrm = new FRM_ItemUnits();
            //Show this instance in mode ShowDialog to control it as first
            UnitFrm.ShowDialog();
        }

        //checkListTypeItems_SelectedIndexChanged Method to enable Expiry And Manufacture Date **Done**
        public void checkListTypeItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CheckedListBox.GetItemChecked(index of checkbox) = true
            if (checkListTypeItems.GetItemChecked(4) == true)
            {
                //Visible of Controls is true
                dtpExpiryDate.Visible = true;
                dtpManuDate.Visible = true;
                label4.Visible = true;
                label20.Visible = true;
            }
            else if (checkListTypeItems.GetItemChecked(4) == false)
            {
                //Visible of Controls is false
                dtpExpiryDate.Visible = false;
                dtpManuDate.Visible = false;
                label4.Visible = false;
                label20.Visible = false;
            }
        }

        //btnSearch_Click Method To Search in Items Table **Done**
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_ItemSearch
            FRM_ItemSearch SearchForm = new FRM_ItemSearch();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //btnSave_Click Method To Save New Items
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in Items table + 1 
                //lblID.Text.Contains(ItemsClass.GenerateItemID().ToString() New Company ID) Do not modify
                if (!lblID.Text.Contains(ItemsClass.GenerateItemID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الصنف تم إضتافته من قبل", "تنبية",
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

                //ResetDecimalFields void Method to reset Control in pnlUnits is equal zero
                ResetDecimalFields();

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Save Items Table
                ItemsClass.SaveItems
                      (Convert.ToInt32(lblID.Text.Remove(0, 5)),lblID.Text, txtItemName.Text, txtItemEngName.Text, txtItemBarcode1.Text, txtItemBarcode2.Text,
                       txtItemBarcode3.Text, dtpManuDate.Value.ToString("yyyy-MM-dd"), dtpExpiryDate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(comboDosageForm.SelectedValue),
                       Convert.ToInt32(comboGenerics.SelectedValue), Convert.ToInt32(comboClassOfActions.SelectedValue), Convert.ToInt32(comboGroups.SelectedValue),
                       Convert.ToInt32(comboCompanies.SelectedValue), Convert.ToInt32(comboPlaces.SelectedValue), Convert.ToInt32(comboItemLargeUnit.SelectedValue),
                       Convert.ToInt32(txtItemLargeUnitNo.Text), Convert.ToDecimal(txtLargeUnitSalePrice.Text), Convert.ToDecimal(txtLargeUnitBuyPrice.Text), Convert.ToDecimal(txtLargeUnitBalance.Text),
                       Convert.ToInt32(comboItemMediumUnit.SelectedValue), Convert.ToInt32(txtItemMediumUnitNo.Text),
                       Convert.ToDecimal(txtMediumUnitSalePrice.Text), Convert.ToDecimal(txtMediumUnitBuyPrice.Text), Convert.ToDecimal(txtMediumUnitBalance.Text),
                       Convert.ToInt32(comboItemSmallUnit.SelectedValue), Convert.ToInt32(txtItemSmallUnitNo.Text), Convert.ToDecimal(txtSmallUnitSalePrice.Text),
                       Convert.ToDecimal(txtSmallUnitBuyPrice.Text), Convert.ToDecimal(txtSmallUnitBalance.Text), Convert.ToDecimal(txtItemLimit.Text), Convert.ToDecimal(txtItemDiscound.Text),
                       checkListTypeItems.GetItemChecked(0), checkListTypeItems.GetItemChecked(1), checkListTypeItems.GetItemChecked(2),
                       checkListTypeItems.GetItemChecked(3), checkListTypeItems.GetItemChecked(4), checkListTypeItems.GetItemChecked(5),
                       checkListTypeItems.GetItemChecked(6), checkListTypeItems.GetItemChecked(7),
                       IP_PCName, Program.UsrID, true, DateTime.Now.ToString("yyyy-MM-dd"),
                       DateTime.Now.ToString("MMM dd yyyy hh:mm:ss tt"));

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ الصنف بنجاح", "عملية الحفظ",
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

        //btnModify_Click Method To Update Items
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(ItemsClass.GenerateItemID() New Item ID) Do not modify
                if (lblID.Text.Contains(ItemsClass.GenerateItemID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الصنف لم يتم إضافته بعد", "تنبية",
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

                //ResetDecimalFields void Method to reset Control in pnlUnits is equal zero
                ResetDecimalFields();

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Modify Items Table
                ItemsClass.UpdateItems(Convert.ToInt32(lblID.Text.Remove(0, 5)), txtItemName.Text, txtItemEngName.Text, txtItemBarcode1.Text, txtItemBarcode2.Text,
                       txtItemBarcode3.Text, dtpManuDate.Value.ToString("yyyy-MM-dd"), dtpExpiryDate.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(comboDosageForm.SelectedValue),
                       Convert.ToInt32(comboGenerics.SelectedValue), Convert.ToInt32(comboClassOfActions.SelectedValue), Convert.ToInt32(comboGroups.SelectedValue),
                       Convert.ToInt32(comboCompanies.SelectedValue), Convert.ToInt32(comboPlaces.SelectedValue), Convert.ToInt32(comboItemLargeUnit.SelectedValue),
                       Convert.ToInt32(txtItemLargeUnitNo.Text), Convert.ToDecimal(txtLargeUnitSalePrice.Text), Convert.ToDecimal(txtLargeUnitBuyPrice.Text), Convert.ToDecimal(txtLargeUnitBalance.Text),
                       Convert.ToInt32(comboItemMediumUnit.SelectedValue), Convert.ToInt32(txtItemMediumUnitNo.Text),
                       Convert.ToDecimal(txtMediumUnitSalePrice.Text), Convert.ToDecimal(txtMediumUnitBuyPrice.Text), Convert.ToDecimal(txtMediumUnitBalance.Text),
                       Convert.ToInt32(comboItemSmallUnit.SelectedValue), Convert.ToInt32(txtItemSmallUnitNo.Text), Convert.ToDecimal(txtSmallUnitSalePrice.Text),
                       Convert.ToDecimal(txtSmallUnitBuyPrice.Text), Convert.ToDecimal(txtSmallUnitBalance.Text), Convert.ToDecimal(txtItemLimit.Text), Convert.ToDecimal(txtItemDiscound.Text),
                       checkListTypeItems.GetItemChecked(0), checkListTypeItems.GetItemChecked(1), checkListTypeItems.GetItemChecked(2),
                       checkListTypeItems.GetItemChecked(3), checkListTypeItems.GetItemChecked(4), checkListTypeItems.GetItemChecked(5),
                       checkListTypeItems.GetItemChecked(6), checkListTypeItems.GetItemChecked(7),
                       IP_PCName, Program.UsrID);

                //Show Notification of System Message Success Modify
                NotificationSMS.NotifyShow("تم تعديل الصنف بنجاح", "عملية التعديل",
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

        //btnDelete_Click Method To Delete Items by Delete Record or Deactivate Items **Done**
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //lblID.Text.Contains(ItemsClass.GenerateItemID().ToString() New Customer ID) Do not modify
                if (lblID.Text.Contains(ItemsClass.GenerateItemID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذا الصنف لم يتم إضافته بعد", "تنبية",
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


                //if user select Yes Button and Select Delete Items From Database
                if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "Delete Record")
                {
                    //Delete Items From Database
                    ItemsClass.DeleteItems(Convert.ToInt32(lblID.Text.Remove(0, 5)));

                    //Alarm Success Delete From database Message Box 
                    NotificationSMS.NotifyShow("تم حذف الصنف بشكل نهائى بنجاح", "عملية الحذف",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                }
                //if user select Yes Button and Select InActivate Items From Database
                else if (NotificationSMS.NotifyResult == true && NotificationSMS.NotifyType == "InActivate Record")
                {
                    //declare string variable to store pc name and ip address
                    string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                        Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                    //Update Status to False in Items Table
                    ItemsClass.DeactivateItems(Convert.ToInt32(lblID.Text.Remove(0, 5)), false, IP_PCName, Program.UsrID);

                    //Alarm Success deactive Message Box 
                    NotificationSMS.NotifyShow("تم حذف الصنف بشكل مؤقت بنجاح", "عملية الحذف",
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

        //comboDosageForm_DropDown Method To Fill ComboBox By Items of Dosage Form Table **Done**
        public void comboDosageForm_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemDosageForm
            BAL.CLS_ItemDosageForm DosageClass = new BAL.CLS_ItemDosageForm();
            //Initialize DataSource of combo is DosageClass.ShowItemDosageFormTable();
            comboDosageForm.DataSource = DosageClass.ShowItemDosageFormTable();
            //Initialize DisplayMember of combo is DosageFormName
            comboDosageForm.DisplayMember = "DosageFormName";
            //Initialize ValueMember of combo is DosageFormID
            comboDosageForm.ValueMember = "DosageFormID";
            //To Clear ComboBox of comboDosageForm by selected index equal -1  
            comboDosageForm.SelectedIndex = -1;
        }

        //comboGenerics_DropDown Method To Fill ComboBox By Items of Generics Table  **Done**
        public void comboGenerics_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemGenerics
            BAL.CLS_ItemGenerics GenericsClass = new BAL.CLS_ItemGenerics();
            //Initialize DataSource of combo is GenericsClass.ShowItemGenericTable();
            comboGenerics.DataSource = GenericsClass.ShowItemGenericTable();
            //Initialize DisplayMember of combo is GenericName
            comboGenerics.DisplayMember = "GenericName";
            //Initialize ValueMember of combo is GenericID
            comboGenerics.ValueMember = "GenericID";
            //To Clear ComboBox of comboGenerics by selected index equal -1  
            comboGenerics.SelectedIndex = -1;
        }

        //comboClassOfActions_DropDown Method To Fill ComboBox By Items of ClassOfActions Table  **Done**
        public void comboClassOfActions_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemClassOfActions
            BAL.CLS_ItemClassOfActions ActionsClass = new BAL.CLS_ItemClassOfActions();
            //Initialize DataSource of combo is ActionsClass.ShowItemClassTable();
            comboClassOfActions.DataSource = ActionsClass.ShowItemClassTable();
            //Initialize DisplayMember of combo is ClassOfActionName
            comboClassOfActions.DisplayMember = "ClassOfActionName";
            //Initialize ValueMember of combo is ClassOfActionID
            comboClassOfActions.ValueMember = "ClassOfActionID";
            //To Clear ComboBox of comboClassOfActions by selected index equal -1  
            comboClassOfActions.SelectedIndex = -1;
        }

        //comboGroups_DropDown Method To Fill ComboBox By Items of Groups Table  **Done**
        public void comboGroups_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemGroups
            BAL.CLS_ItemGroups GroupsClass = new BAL.CLS_ItemGroups();
            //Initialize DataSource of combo is GroupsClass.ShowItemGroupTable();
            comboGroups.DataSource = GroupsClass.ShowItemGroupTable();
            //Initialize DisplayMember of combo is GroupName
            comboGroups.DisplayMember = "GroupName";
            //Initialize ValueMember of combo is GroupID
            comboGroups.ValueMember = "GroupID";
            //To Clear ComboBox of comboGroups by selected index equal -1  
            comboGroups.SelectedIndex = -1;
        }

        //comboCompanies_DropDown Method To Fill ComboBox By Items of Companies Table  **Done**
        public void comboCompanies_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemCompanies
            BAL.CLS_ItemCompanies CompaniesClass = new BAL.CLS_ItemCompanies();
            //Initialize DataSource of combo is CompaniesClass.ShowItemCompanyTable();
            comboCompanies.DataSource = CompaniesClass.ShowItemCompanyTable();
            //Initialize DisplayMember of combo is CompanyName
            comboCompanies.DisplayMember = "CompanyName";
            //Initialize ValueMember of combo is CompanyID
            comboCompanies.ValueMember = "CompanyID";
            //To Clear ComboBox of comboCompanies by selected index equal -1  
            comboCompanies.SelectedIndex = -1;
        }

        //comboPlaces_DropDown Method To Fill ComboBox By Items of Places Table  **Done**
        public void comboPlaces_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemPlaces
            BAL.CLS_ItemPlaces PlacesClass = new BAL.CLS_ItemPlaces();
            //Initialize DataSource of combo is CompaniesClass.ShowItemCompanyTable();
            comboPlaces.DataSource = PlacesClass.ShowItemPlaceTable();
            //Initialize DisplayMember of combo is PlaceName
            comboPlaces.DisplayMember = "PlaceName";
            //Initialize ValueMember of combo is PlaceID
            comboPlaces.ValueMember = "PlaceID";
            //To Clear ComboBox of comboCompanies by selected index equal -1  
            comboPlaces.SelectedIndex = -1;
        }

        //comboItemLargeUnit_DropDown Method To Fill ComboBox By Items of Units Table  **Done**
        public void comboItemLargeUnit_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemUnits
            BAL.CLS_ItemUnits UnitsClass = new BAL.CLS_ItemUnits();
            //Initialize DataSource of combo is UnitsClass.ShowItemUnitTable();
            comboItemLargeUnit.DataSource = UnitsClass.ShowItemUnitTable();
            //Initialize DisplayMember of combo is UnitName
            comboItemLargeUnit.DisplayMember = "UnitName";
            //Initialize ValueMember of combo is UnitID
            comboItemLargeUnit.ValueMember = "UnitID";
            //To Clear ComboBox of comboCompanies by selected index equal -1  
            comboItemLargeUnit.SelectedIndex = -1;
        }

        //comboItemMediumUnit_DropDown Method To Fill ComboBox By Items of Units Table  **Done**
        public void comboItemMediumUnit_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemUnits
            BAL.CLS_ItemUnits UnitsClass = new BAL.CLS_ItemUnits();
            //Initialize DataSource of combo is UnitsClass.ShowItemUnitTable();
            comboItemMediumUnit.DataSource = UnitsClass.ShowItemUnitTable();
            //Initialize DisplayMember of combo is UnitName
            comboItemMediumUnit.DisplayMember = "UnitName";
            //Initialize ValueMember of combo is UnitID
            comboItemMediumUnit.ValueMember = "UnitID";
            //To Clear ComboBox of comboCompanies by selected index equal -1  
            comboItemMediumUnit.SelectedIndex = -1;
        }

        //comboItemSmallUnit_DropDown Method To Fill ComboBox By Items of Units Table  **Done**
        public void comboItemSmallUnit_DropDown(object sender, EventArgs e)
        {
            //Create New Instance From BAL.CLS_ItemUnits
            BAL.CLS_ItemUnits UnitsClass = new BAL.CLS_ItemUnits();
            //Initialize DataSource of combo is UnitsClass.ShowItemUnitTable();
            comboItemSmallUnit.DataSource = UnitsClass.ShowItemUnitTable();
            //Initialize DisplayMember of combo is UnitName
            comboItemSmallUnit.DisplayMember = "UnitName";
            //Initialize ValueMember of combo is UnitID
            comboItemSmallUnit.ValueMember = "UnitID";
            //To Clear ComboBox of comboCompanies by selected index equal -1  
            comboItemSmallUnit.SelectedIndex = -1;
        }

        //lblItemActivate_Click Method to Activate Item  **Done**
        private void lblItemActivate_Click(object sender, EventArgs e)
        {
            try
            {

                //Declare int variable to store current internal user id
                int CurrentID = Convert.ToInt32(lblID.Text.Remove(0, 5));

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //Update Status to true in Items Table
                ItemsClass.DeactivateItems(CurrentID, true, IP_PCName, Program.UsrID);

                //Initialize false Value to Visible of lblUserStatus
                lblItemStatus.Visible = false;
                //Initialize false Value to Visible of lblUserActivate
                lblItemActivate.Visible = false;
                //Initialize true Value to Enabled of btnDelete
                btnDelete.Enabled = true;
                //Initialize False true to Enabled of btnModify
                btnModify.Enabled = true;
                //Stop Timer
                timerItems.Stop();
                //Initialize false Value to Enabled of timerItems
                timerItems.Enabled = false;

                //Alarm Success activate Message Box 
                NotificationSMS.NotifyShow("تم تفعيل الصنف بنجاح", "تنبية",
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

        //timerUsers_Tick Method to Control Font Size of lblUserStatus with every tick of Timer.interval  **Done**
        private void timerItems_Tick(object sender, EventArgs e)
        {
            try
            {
                /* Set in Properties Interval of timer = 500 */
                //if visible of lblItemStatus is not equal true ==> stop to executing block code
                if (lblItemStatus.Visible != true) return;
                //if interval of timer equal 500
                if (timerItems.Interval == 500)
                {
                    //Change Font of lblItemStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblItemStatus.Font = new Font("LBC", 11, FontStyle.Bold);
                    //Change location of lblItemStatus by  initialize new point (x,y)
                    lblItemStatus.Location = new Point(14, 24);
                    //change interval of timer to 1000
                    timerItems.Interval = 1000;
                }
                //if interval of timer equal 1000
                else if (timerItems.Interval == 1000)
                {
                    //Change Font of lblItemStatus by initialize new font ("FontFamilyName", float FontSize,FontStyle)
                    lblItemStatus.Font = new Font("LBC", 14, FontStyle.Bold);
                    //Change location of lblItemStatus by  initialize new point (x,y)
                    lblItemStatus.Location = new Point(14, 19);
                    //change interval of timer to 500
                    timerItems.Interval = 500;
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

        #endregion

        #region Validation Methods of Input Entry From User

        //txtItemLargeUnitNo_KeyPress To Limit user Only Input Digits and BackSpace  **Done**
        private void txtItemLargeUnitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCount(KeyPressEventArgs e)
            CheckInputForCount(e);
        }

        //txtItemMediumUnitNo_KeyPress To Limit user Only Input Digits and BackSpace  **Done**
        private void txtItemMediumUnitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCount(KeyPressEventArgs e)
            CheckInputForCount(e);
        }

        //txtItemSmallUnitNo_KeyPress To Limit user Only Input Digits and BackSpace  **Done**
        private void txtItemSmallUnitNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCount(KeyPressEventArgs e)
            CheckInputForCount(e);
        }

        //txtLargeUnitSalePrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtLargeUnitSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e); 
        }

        //txtMediumUnitSalePrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtMediumUnitSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtSmallUnitSalePrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtSmallUnitSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtLargeUnitBuyPrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtLargeUnitBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtMediumUnitBuyPrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtMediumUnitBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtSmallUnitBuyPrice_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtSmallUnitBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtLargeUnitBalance_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtLargeUnitBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtMediumUnitBalance_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtMediumUnitBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtSmallUnitBalance_KeyPress To Limit user Only Input Digits and BackSpace and Decimal Point  **Done**
        private void txtSmallUnitBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCurrency(KeyPressEventArgs e)
            CheckInputForCurrency(e);
        }

        //txtItemName_KeyDown Method To Move Next Control txtItemEngName **Done**
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemEngName.Focus();
            }
        }

        //txtItemEngName_KeyDown Method To Move Next Control comboDosageForm **Done**
        private void txtItemEngName_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of DosageForm
                if (comboDosageForm.SelectedIndex == -1)
                {
                    //Recall comboDosageForm Method to DropDown list of Combobox
                    comboDosageForm_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboDosageForm.Items.Count > 0) comboDosageForm.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboDosageForm.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboDosageForm.Focus();
                }
            }
        }

        //txtItemEngName_KeyDown Method To Move Next Control comboGenerics **Done**
        private void comboDosageForm_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of Generics
                if (comboGenerics.SelectedIndex == -1)
                {
                    //Recall comboGenerics_DropDown Method to DropDown list of Combobox
                    comboGenerics_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboGenerics.Items.Count > 0) comboGenerics.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboGenerics.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboGenerics.Focus();
                }
            }
        }

        //comboGenerics_KeyDown Method To Move Next Control comboClassOfActions **Done**
        private void comboGenerics_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboClassOfActions
                if (comboClassOfActions.SelectedIndex == -1)
                {
                    //Recall comboClassOfActions_DropDown Method to DropDown list of Combobox
                    comboClassOfActions_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboClassOfActions.Items.Count > 0) comboClassOfActions.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboClassOfActions.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboClassOfActions.Focus();
                }
            }
        }

        //comboGenerics_KeyDown Method To Move Next Control comboGroups **Done**
        private void comboClassOfActions_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboClassOfActions
                if (comboGroups.SelectedIndex == -1)
                {
                    //Recall comboGroups_DropDown Method to DropDown list of Combobox
                    comboGroups_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboGroups.Items.Count > 0) comboGroups.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboGroups.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboGroups.Focus();
                }
            }
        }

        //comboGroups_KeyDown Method To Move Next Control comboCompanies **Done**
        private void comboGroups_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboCompanies
                if (comboCompanies.SelectedIndex == -1)
                {
                    //Recall comboCompanies_DropDown Method to DropDown list of Combobox
                    comboCompanies_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboCompanies.Items.Count > 0) comboCompanies.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboCompanies.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboCompanies.Focus();
                }
            }
        }

        //comboCompanies_KeyDown Method To Move Next Control comboPlaces **Done**
        private void comboCompanies_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboCompanies
                if (comboPlaces.SelectedIndex == -1)
                {
                    //Recall comboPlaces_DropDown Method to DropDown list of Combobox
                    comboPlaces_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboPlaces.Items.Count > 0) comboPlaces.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboPlaces.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboPlaces.Focus();
                }
            }
        }

        //comboPlaces_KeyDown Method To Move Next Control comboItemLargeUnit **Done**
        private void comboPlaces_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboCompanies
                if (comboItemLargeUnit.SelectedIndex == -1)
                {
                    //Recall btnUnitsTab_Click Method to Move Items Units Panel
                    btnUnitsTab_Click(sender, e);
                    //Recall comboItemLargeUnit_DropDown Method to DropDown list of Combobox
                    comboItemLargeUnit_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboItemLargeUnit.Items.Count > 0) comboItemLargeUnit.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboItemLargeUnit.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Recall btnUnitsTab_Click Method to Move Items Units Panel
                    btnUnitsTab_Click(sender, e);
                    //Move to Next Control by controlName.Focus();
                    comboItemLargeUnit.Focus();
                }
            }
        }

        //comboItemLargeUnit_KeyDown Method To Move Next Control comboItemMediumUnit **Done**
        private void comboItemLargeUnit_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboItemMediumUnit
                if (comboItemMediumUnit.SelectedIndex == -1)
                {
                    //Recall comboItemMediumUnit_DropDown Method to DropDown list of Combobox
                    comboItemMediumUnit_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboItemMediumUnit.Items.Count > 0) comboItemMediumUnit.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboItemMediumUnit.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboItemMediumUnit.Focus();
                }
            }
        }

        //comboItemMediumUnit_KeyDown Method To Move Next Control comboItemSmallUnit **Done**
        private void comboItemMediumUnit_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //If User in Mode Add new Item Load table of comboItemMediumUnit
                if (comboItemSmallUnit.SelectedIndex == -1)
                {
                    //Recall comboItemSmallUnit_DropDown Method to DropDown list of Combobox
                    comboItemSmallUnit_DropDown(sender, e);
                    //Select first Item of Combobox
                    if (comboItemSmallUnit.Items.Count > 0) comboItemSmallUnit.SelectedIndex = 0;
                    //Move to Next Control by controlName.Focus();
                    comboItemSmallUnit.Focus();
                }
                else //If User in Mode Modify Focus on ComboBox.SelectedIndex without change item of combo
                {
                    //Move to Next Control by controlName.Focus();
                    comboItemSmallUnit.Focus();
                }
            }
        }

        //comboItemSmallUnit_KeyDown Method To Move Next Control txtItemLargeUnitNo **Done**
        private void comboItemSmallUnit_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemLargeUnitNo.Focus();
            }
        }

        //txtItemLargeUnitNo_KeyDown Method To Move Next Control txtItemMediumUnitNo **Done**
        private void txtItemLargeUnitNo_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemMediumUnitNo.Focus();
            }
        }

        //txtItemMediumUnitNo_KeyDown Method To Move Next Control txtItemSmallUnitNo **Done**
        private void txtItemMediumUnitNo_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemSmallUnitNo.Focus();
            }
        }

        //txtItemSmallUnitNo_KeyDown Method To Move Next Control txtLargeUnitSalePrice **Done**
        private void txtItemSmallUnitNo_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtLargeUnitSalePrice.Focus();
            }
        }

        //txtLargeUnitSalePrice_KeyDown Method To Move Next Control txtMediumUnitSalePrice **Done**
        private void txtLargeUnitSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtMediumUnitSalePrice.Focus();
            }
        }

        //txtMediumUnitSalePrice_KeyDown Method To Move Next Control txtSmallUnitSalePrice **Done**
        private void txtMediumUnitSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtSmallUnitSalePrice.Focus();
            }
        }

        //txtSmallUnitSalePrice_KeyDown Method To Move Next Control txtLargeUnitBuyPrice **Done**
        private void txtSmallUnitSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtLargeUnitBuyPrice.Focus();
            }
        }

        //txtLargeUnitBuyPrice_KeyDown Method To Move Next Control txtMediumUnitBuyPrice **Done**
        private void txtLargeUnitBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtMediumUnitBuyPrice.Focus();
            }
        }

        //txtMediumUnitBuyPrice_KeyDown Method To Move Next Control txtSmallUnitBuyPrice **Done**
        private void txtMediumUnitBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtSmallUnitBuyPrice.Focus();
            }
        }

        //txtSmallUnitBuyPrice_KeyDown Method To Move Next Control txtLargeUnitBalance **Done**
        private void txtSmallUnitBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtLargeUnitBalance.Focus();
            }
        }

        //txtLargeUnitBalance_KeyDown Method To Move Next Control txtMediumUnitBalance **Done**
        private void txtLargeUnitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtMediumUnitBalance.Focus();
            }
        }

        //txtMediumUnitBalance_KeyDown Method To Move Next Control txtSmallUnitBalance **Done**
        private void txtMediumUnitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtSmallUnitBalance.Focus();
            }
        }

        //txtSmallUnitBalance_KeyDown Method To Move Next Control txtItemBarcode1 **Done**
        private void txtSmallUnitBalance_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Recall btnBarcodeTab_Click Method to Move Items Units Panel
                btnBarcodeTab_Click(sender, e);
                //Move to Next Control by controlName.Focus();
                txtItemBarcode1.Focus();
            }
        }

        //txtItemBarcode1_KeyDown Method To Move Next Control txtItemBarcode2 **Done**
        private void txtItemBarcode1_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemBarcode2.Focus();
            }
        }

        //txtItemBarcode2_KeyDown Method To Move Next Control txtItemBarcode3 **Done**
        private void txtItemBarcode2_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemBarcode3.Focus();
            }
        }

        //txtItemBarcode3_KeyDown Method To Move Next Control txtItemLimit **Done**
        private void txtItemBarcode3_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Recall btnBarcodeTab_Click Method to Move Items btnExtra Panel
                btnExtraTab_Click(sender, e);
                //Move to Next Control by controlName.Focus();
                txtItemLimit.Focus();
            }
        }

        //txtItemLimit_KeyDown Method To Move Next Control txtItemDiscound **Done**
        private void txtItemLimit_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                txtItemDiscound.Focus();
            }
        }

        //txtItemDiscound_KeyDown Method To Move Next Control checkListTypeItems **Done**
        private void txtItemDiscound_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                checkListTypeItems.Focus();
            }
        }

        //checkListTypeItems_KeyDown Method To Move Next Control dtpManuDate **Done**
        private void checkListTypeItems_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                dtpManuDate.Focus();
            }
        }

        //dtpManuDate_KeyDown Method To Move Next Control dtpExpiryDate **Done**
        private void dtpManuDate_KeyDown(object sender, KeyEventArgs e)
        {
            // if event generated from user press on enter key
            if (e.KeyCode == Keys.Enter)
            {
                //Move to Next Control by controlName.Focus();
                dtpExpiryDate.Focus();
            }
        }

        //txtLargeUnitSalePrice_TextChanged Method To Calcutate Sale Price of Medium and Small Unit **Done**
        private void txtLargeUnitSalePrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemMediumUnitNo.Text != string.Empty && txtItemSmallUnitNo.Text != string.Empty
                    && txtLargeUnitSalePrice.Text != string.Empty)
                {
                    //Calcutate Sale Price of Medium Unit
                    txtMediumUnitSalePrice.Text = ((Convert.ToDecimal(txtLargeUnitSalePrice.Text) / Convert.ToDecimal(txtItemMediumUnitNo.Text))).ToString("0.000");
                    //Calcutate Sale Price of Small Unit
                    txtSmallUnitSalePrice.Text = ((Convert.ToDecimal(txtMediumUnitSalePrice.Text) / Convert.ToDecimal(txtItemSmallUnitNo.Text))).ToString("0.000");

                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderItems.SetError(txtLargeUnitSalePrice, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;
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

        //txtItemMediumUnitNo_TextChanged Method To Calcutate Sale Price of Medium and Small Unit **Done**
        private void txtItemMediumUnitNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemMediumUnitNo.Text != string.Empty && txtItemSmallUnitNo.Text != string.Empty
                    && txtLargeUnitSalePrice.Text != string.Empty)
                {
                    //Calcutate Sale Price of Medium Unit
                    txtMediumUnitSalePrice.Text = ((Convert.ToDecimal(txtLargeUnitSalePrice.Text) / Convert.ToDecimal(txtItemMediumUnitNo.Text))).ToString("0.000");
                    //Calcutate Sale Price of Small Unit
                    txtSmallUnitSalePrice.Text = ((Convert.ToDecimal(txtMediumUnitSalePrice.Text) / Convert.ToDecimal(txtItemSmallUnitNo.Text))).ToString("0.000");
                   
                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderItems.SetError(txtItemMediumUnitNo, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;

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

        //txtItemSmallUnitNo_TextChanged Method To Calcutate Sale Price of Medium and Small Unit **Done**
        private void txtItemSmallUnitNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemMediumUnitNo.Text != string.Empty && txtItemSmallUnitNo.Text != string.Empty
                    && txtLargeUnitSalePrice.Text != string.Empty)
                {
                    //Calcutate Sale Price of Medium Unit
                    txtMediumUnitSalePrice.Text = ((Convert.ToDecimal(txtLargeUnitSalePrice.Text) / Convert.ToDecimal(txtItemMediumUnitNo.Text))).ToString("0.000");
                    //Calcutate Sale Price of Small Unit
                    txtSmallUnitSalePrice.Text = ((Convert.ToDecimal(txtMediumUnitSalePrice.Text) / Convert.ToDecimal(txtItemSmallUnitNo.Text))).ToString("0.000");
    
                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderItems.SetError(txtItemSmallUnitNo, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;

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

        //txtItemLimit_KeyPress To Limit user Only Input Digits and BackSpace **Done**
        private void txtItemLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCount(KeyPressEventArgs e)
            CheckInputForCount(e);
        }

        //txtItemDiscound_KeyPress To Limit user Only Input Digits and BackSpace **Done**
        private void txtItemDiscound_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Recall Method CheckInputForCount(KeyPressEventArgs e)
            CheckInputForCount(e);
        }

        //txtItemName_TextChanged Method to hide error provider
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtItemName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtItemName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtItemEngName_TextChanged Method to hide error provider
        private void txtItemEngName_TextChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (txtItemEngName.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtItemEngName, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboDosageForm_SelectedIndexChanged Method to hide error provider
        private void comboDosageForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (comboDosageForm.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboDosageForm, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboGenerics_SelectedIndexChanged Method to hide error provider
        private void comboGenerics_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if txtFullName is not equal Empty
            if (comboGenerics.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboGenerics, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboClassOfActions_SelectedIndexChanged Method to hide error provider
        private void comboClassOfActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboClassOfActions is not equal Empty
            if (comboClassOfActions.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboClassOfActions, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboGroups_SelectedIndexChanged Method to hide error provider
        private void comboGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboGroups is not equal Empty
            if (comboGroups.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboGroups, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboCompanies_SelectedIndexChanged Method to hide error provider
        private void comboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboCompanies is not equal Empty
            if (comboCompanies.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboCompanies, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboPlaces_SelectedIndexChanged Method to hide error provider
        private void comboPlaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboCompanies is not equal Empty
            if (comboPlaces.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboPlaces, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboItemLargeUnit_SelectedIndexChanged Method to hide error provider
        private void comboItemLargeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboCompanies is not equal Empty
            if (comboItemLargeUnit.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboItemLargeUnit, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboItemLargeUnit_SelectedIndexChanged Method to hide error provider
        private void comboItemMediumUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboItemMediumUnit is not equal Empty
            if (comboItemMediumUnit.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboItemMediumUnit, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //comboItemSmallUnit_SelectedIndexChanged Method to hide error provider
        private void comboItemSmallUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if comboItemSmallUnit is not equal Empty
            if (comboItemSmallUnit.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(comboItemSmallUnit, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtItemLargeUnitNo_TextChanged Method to hide error provider
        private void txtItemLargeUnitNo_TextChanged(object sender, EventArgs e)
        {
            // if txtItemLargeUnitNo is not equal Empty
            if (txtItemLargeUnitNo.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtItemLargeUnitNo, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtMediumUnitSalePrice_TextChanged Method to hide error provider
        private void txtMediumUnitSalePrice_TextChanged(object sender, EventArgs e)
        {
            // if txtItemLargeUnitNo is not equal Empty
            if (txtMediumUnitSalePrice.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtMediumUnitSalePrice, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtMediumUnitSalePrice_TextChanged Method to hide error provider
        private void txtSmallUnitSalePrice_TextChanged(object sender, EventArgs e)
        {
            // if txtSmallUnitSalePrice is not equal Empty
            if (txtSmallUnitSalePrice.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtSmallUnitSalePrice, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //txtItemBarcode1_TextChanged Method to hide error provider
        private void txtItemBarcode1_TextChanged(object sender, EventArgs e)
        {
            // if txtItemBarcode1 is not equal Empty
            if (txtItemBarcode1.Text != string.Empty)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(txtItemBarcode1, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //dtpManuDate_ValueChanged Method to hide error provider
        private void dtpManuDate_ValueChanged(object sender, EventArgs e)
        {
            // if txtSmallUnitSalePrice is not equal Empty
            if (dtpManuDate.Value != DateTime.Now.Date && dtpManuDate.Visible == true && dtpManuDate.Value != dtpExpiryDate.Value)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(dtpManuDate, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        //dtpExpiryDate_ValueChanged Method to hide error provider
        private void dtpExpiryDate_ValueChanged(object sender, EventArgs e)
        {
            // if txtSmallUnitSalePrice is not equal Empty
            if (dtpExpiryDate.Value != DateTime.Now.Date && dtpExpiryDate.Visible == true && dtpManuDate.Value != dtpExpiryDate.Value)
            {
                //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                errProviderItems.SetError(dtpExpiryDate, "");
                //if count of errors more than one less than couter by one
                if (CountOfErrors > 1) CountOfErrors -= 1;
                //else Iniatize Zeror value to counter
                else CountOfErrors = 0;
            }
        }

        #endregion

       
    }
}
