using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_CustomerSearch : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_Users Business Access Layer
        readonly BAL.CLS_Customers CustomersClass = new BAL.CLS_Customers();
        //Create New Instance From BAL.CLS_CustomerAccount Business Access Layer
        readonly BAL.CLS_CustomerAccount CustomerAccountClass = new BAL.CLS_CustomerAccount();
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

        //Constructor OF FRM_CustomerSearch
        public FRM_CustomerSearch()
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
            /* Used Wizard of DataGridview To Set Columns of DGV And Set DataPropertyName by Alias Name in SP 
             * without Quation Mark */
            //Intialize MultiSelect of DGV is False
            dgvSearch.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvSearch.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvSearch.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvSearch.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvSearch.AllowUserToResizeColumns = false;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvSearch.AutoGenerateColumns = false;
            //Intialize DataSource of DGV is CustomersClass.ShowCustomersTable();
            dgvSearch.DataSource = CustomersClass.ShowCustomersTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[] 
                    { "كود العميل", "اسم العميل", "رقم الهاتف",
                    "رقم الفاكس","العنوان","البريد اليكترونى","نوع العميل","الشركة التابع لها",
                    "نسبة الخصم","حالة المبيعات الآجلة","رصيد العميل","حالة العميل"};

            //Set DataSource of Combobox is strSearchItems array
            comboSearch.DataSource = strSearchItems;
            //Set SelectedIndex of item is -1 to show empty item
            comboSearch.SelectedIndex = -1;
            //Visible of radBtnActive is false
            radBtnActive.Visible = false;
            //Visible of radBtnDeactive is false
            radBtnDeactive.Visible = false;
            //Visible of txtSearch is true
            txtSearch.Visible = true;
            //Clear Text Box
            txtSearch.Clear();
        }

        /// <summary>
        /// Decimal Function to Sum of Customer Balance or Credit or Debit
        /// </summary>
        /// <param name="custID">custID</param>
        /// <param name="columnName">ColumnName Need to Get Sum of It</param>
        /// <returns>Sum of Customer Balance or Credit or Debit</returns>
        private decimal GetCustomerBalance(string custID, string columnName)
        {
            //Declare Decimal Variable to Get Sum of Customer Balance or Credit or Debit ==> depends on Argument columnName
            decimal sum = 0;

            //Initialize Result of DataTable Function To Search in CustomerAccount by Customer ID
            //this Function received three Arguments (ColumnName Mandatory, SearchKey Mandatory,SearchKey1 is Optional represents null or empty
            DataTable dt = CustomerAccountClass.SearchCustAccount("CustomerID", custID, "", "", "");

            //Use for loop to get Sum of Customer Balance or Credit or Debit
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //if the value of Credit or debit or Balance is not Equal Null
                if (dt.Rows[i][columnName] != DBNull.Value)
                {
                    //Initialize Value to Sum which depends on ColumnName
                    sum += Convert.ToDecimal(dt.Rows[i][columnName]);
                }
            }

            //return Sum
            return sum;
        }

        //btnClose_Click to Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close Form
            this.Close();
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

        //comboSearch_SelectedIndexChanged to clear textbox
        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if selected index of comboSearch greater than zero
            if (comboSearch.SelectedIndex >= 0 && comboSearch.SelectedIndex != 6 && comboSearch.SelectedIndex != 9 && comboSearch.SelectedIndex != 11)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Visible = false;
                    radBtnDeactive.Visible = false;
                    txtSearch.Visible = true;
                }
                //clear textbox
                txtSearch.Clear();
                //Focus on txtsearch
                txtSearch.Focus();
            }
            else if (comboSearch.SelectedIndex == 6)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Text = "عميل نقدى";
                    radBtnDeactive.Text = "عميل آجل";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;
                }
                else
                {
                    txtSearch.Visible = false;
                    radBtnActive.Text = "عميل نقدى";
                    radBtnDeactive.Text = "عميل آجل";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;
                }
            }
            else if (comboSearch.SelectedIndex != 9 || comboSearch.SelectedIndex != 11)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Text = "حالة نشطة";
                    radBtnDeactive.Text = "حالة غير نشطة";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;
                }
                else
                {
                    txtSearch.Visible = false;
                    radBtnActive.Text = "حالة نشطة";
                    radBtnDeactive.Text = "حالة غير نشطة";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;
                }
            }
        }

        //txtSearch_KeyDown Method to search in customers table Advance Way when user press enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //if txtSearch.Text is not equal string.Empty
                    if (txtSearch.Text != string.Empty)
                    {
                        //switch conditional statemenr (string) {Case "valueofstring": break;}
                        //Search based on ColumnName
                        switch (comboSearch.Text)
                        {
                            case "كود العميل":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustCustomCode
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustCustomCode", txtSearch.Text);
                                break;
                            case "اسم العميل":
                                //Set DataTable is DataSource of DataGridView search by CustCustomCode
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerFullName", txtSearch.Text);
                                break;
                            case "رقم الهاتف":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerPhoneN1
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerPhone", txtSearch.Text);
                                break;
                            case "رقم الفاكس":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerFax
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerFax", txtSearch.Text);
                                break;
                            case "العنوان":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustCustomCode
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerAddress", txtSearch.Text);
                                break;
                            case "البريد اليكترونى":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerEmail
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerEmail", txtSearch.Text);
                                break;
                            case "الشركة التابع لها":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerCompanyName
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerCompanyName", txtSearch.Text);
                                break;
                            case "نسبة الخصم":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerDiscount
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerDiscount", txtSearch.Text);
                                break;
                            case "رصيد العميل":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CustomerBalance
                                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerBalance", txtSearch.Text);
                                break;
                            default:
                                break;
                        }
                        //clear textbox
                        txtSearch.Clear();
                        //Focus on txtsearch
                        txtSearch.Focus();
                    }
                    //if txtSearch.Text is equal string.Empty
                    else
                    {
                        //Set ShowCustomersTable is DataSource of DataGridView (all Customers table)
                        dgvSearch.DataSource = CustomersClass.ShowCustomersTable();
                    }
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

        //btnPrintAll_Click Method To Print All Customers
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_CustomersViewerRpt is Form Viewer
                RPT.FRM_CustomersViewerRpt CustomerViewerFrm = new RPT.FRM_CustomersViewerRpt();
                //Create New Instance From RPT.CustomersRpt is Report
                RPT.CustomersRpt CustomerReport = new RPT.CustomersRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created CustomerReport
                CustomerViewerFrm.crystalRptViewerCustomers.ReportSource = CustomerReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all Customers
                CustomerReport.SetDataSource(CustomersClass.ShowCustomersTable());
                //Refresh Report
                CustomerReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                CustomerViewerFrm.ShowDialog();
                //Change Cursor to Default Cursor
                this.Cursor = Cursors.Default;
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

        //dgvSearch_CellContentClick Method to show selected Customer or print selected Customer CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Customers or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderCustomers by clear it 
                    FRM_Customers.CustAccess_Property.errProviderCustomers.Clear();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerCode"].Value to lblID.text
                    FRM_Customers.CustAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["CustomerCode"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerFullName"].Value to txtFullName.Text
                    FRM_Customers.CustAccess_Property.txtFullName.Text = dgvSearch.CurrentRow.Cells["CustomerFullName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerAddress"].Value to txtAddress.Text
                    FRM_Customers.CustAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["CustomerAddress"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerPhone1"].Value to txtPhone1.Text
                    FRM_Customers.CustAccess_Property.txtPhone1.Text = dgvSearch.CurrentRow.Cells["CustomerPhone1"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerPhone2"].Value to txtPhone2.Text
                    FRM_Customers.CustAccess_Property.txtPhone2.Text = dgvSearch.CurrentRow.Cells["CustomerPhone2"].Value.ToString();

                    //Set Value of Search gvSearch.CurrentRow.Cells["CustomerFax"].Value to txtFax.Text
                    FRM_Customers.CustAccess_Property.txtFax.Text = dgvSearch.CurrentRow.Cells["CustomerFax"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerEmail"].Value to txtEmail.Text
                    FRM_Customers.CustAccess_Property.txtEmail.Text = dgvSearch.CurrentRow.Cells["CustomerEmail"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerCompany"].Value to txtCompany.Text
                    FRM_Customers.CustAccess_Property.txtCompany.Text = dgvSearch.CurrentRow.Cells["CustomerCompany"].Value.ToString();


                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerType"].Value to comboCustomerType.Text
                    FRM_Customers.CustAccess_Property.comboCustomerType.Text = dgvSearch.CurrentRow.Cells["CustomerType"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerCreditLimit"].Value to txtCreditLimit.Text
                    FRM_Customers.CustAccess_Property.txtCreditLimit.Text = dgvSearch.CurrentRow.Cells["CustomerCreditLimit"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerDiscount"].Value to txtDiscount.Text
                    FRM_Customers.CustAccess_Property.txtDiscount.Text = dgvSearch.CurrentRow.Cells["CustomerDiscount"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerDebitStatus"].Value is true its available to cash withdrawals
                    if (dgvSearch.CurrentRow.Cells["CustomerDebitStatus"].Value.ToString() == "true")
                    {
                        //Set Value True to rbtnAvailWithdrawals.Checked radiobutton
                        FRM_Customers.CustAccess_Property.rbtnAvailWithdrawals.Checked = true;
                    }
                    else
                    {
                        //Set Value True to rbtnStopWithdrawals.Checked radiobutton
                        FRM_Customers.CustAccess_Property.rbtnStopWithdrawals.Checked = true;
                    }


                    //Set Value of GetCustomerBalance(dgvSearch.CurrentRow.Cells["CustomerID"].Value.ToString(), "القيمة المدينة").ToString();//المدينة
                    FRM_Customers.CustAccess_Property.txtDebit.Text = GetCustomerBalance(dgvSearch.CurrentRow.Cells["CustomerID"].Value.ToString(), "القيمة المدينة").ToString();//الدائنة

                    //Set Value of GetCustomerBalance(dgvSearch.CurrentRow.Cells["CustomerID"].Value.ToString(), "القيمة الدائنة").ToString();
                    FRM_Customers.CustAccess_Property.txtCredit.Text = GetCustomerBalance(dgvSearch.CurrentRow.Cells["CustomerID"].Value.ToString(), "القيمة الدائنة").ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerBalance"].Value to txtBalance.Text (CurrentBalance)
                    //if Customer Balance is Bebit (Negative Number) (balance * -1).ToString("{0:0.000;(0.000);0}") to input balance in Parentheses (balance)
                    FRM_Customers.CustAccess_Property.txtBalance.Text = dgvSearch.CurrentRow.Cells["CustomerBalance"].Value.ToString();

                    //Change Value of txtBalance.ReadOnly to true
                    FRM_Customers.CustAccess_Property.txtBalance.ReadOnly = true;

                    //Check if debit Amount of customer is not equal true
                    if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["CustomerBalance"].Value) > 0)
                    {
                        FRM_Customers.CustAccess_Property.comboBalanceStatus.SelectedIndex = 2;
                    }
                    //Check if debit Amount of customer is equal true
                    else if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["CustomerBalance"].Value) == 0)
                    {
                        FRM_Customers.CustAccess_Property.comboBalanceStatus.SelectedIndex = 0;
                    }
                    else if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["CustomerBalance"].Value) < 0)
                    {
                        FRM_Customers.CustAccess_Property.comboBalanceStatus.SelectedIndex = 1;
                    }

                    FRM_Customers.CustAccess_Property.comboBalanceStatus.Enabled = false;

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerNotes"].Value to txtNotes.Text
                    FRM_Customers.CustAccess_Property.txtNotes.Text = dgvSearch.CurrentRow.Cells["CustomerNotes"].Value.ToString();


                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerStatus"].Value is true is Activate Customer 
                    if (dgvSearch.CurrentRow.Cells["CustomerStatus"].Value.ToString() == "true")
                    {
                        //Set Value True to pbCustomerStatus.Visible radiobutton
                        FRM_Customers.CustAccess_Property.pbCustomerStatus.Visible = false;
                        //Set Value True to pbCustomerStatus.Image equal Enable_Client image
                        FRM_Customers.CustAccess_Property.pbCustomerStatus.Image = Properties.Resources.Enable_Client;
                        //Set Value of ToolTip is customer status active tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Customers.CustAccess_Property.toolTipCustomers.SetToolTip(FRM_Customers.CustAccess_Property.pbCustomerStatus, "عميل نشط");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Customers.CustAccess_Property.btnDelete.Enabled = true;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Customers.CustAccess_Property.btnModify.Enabled = true;
                    }
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerStatus"].Value is false is deactivate Customer 
                    else
                    {
                        //Set Value True to pbCustomerStatus.Visible radiobutton
                        FRM_Customers.CustAccess_Property.pbCustomerStatus.Visible = true;
                        //Set Value True to pbCustomerStatus.Image equal Enable_Client image
                        FRM_Customers.CustAccess_Property.pbCustomerStatus.Image = Properties.Resources.Disable_Client;
                        //Set Value of ToolTip is customer status active tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Customers.CustAccess_Property.toolTipCustomers.SetToolTip(FRM_Customers.CustAccess_Property.pbCustomerStatus, "عميل غير نشط\nيرجى الضغط على الصورة لإعادة تنشيط العميل");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Customers.CustAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Customers.CustAccess_Property.btnModify.Enabled = false;
                    }
                    //Close Form
                    this.Close();

                }
                //if the index of row greater than or equal zero and index of button column Print btn is 
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_CustomersViewerRpt is Form Viewer
                    RPT.FRM_CustomersViewerRpt CustomerViewerFrm = new RPT.FRM_CustomersViewerRpt();
                    //Create New Instance From RPT.CustomersRpt is Report
                    RPT.CustomersRpt CustomerReport = new RPT.CustomersRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created CustomerReport
                    CustomerViewerFrm.crystalRptViewerCustomers.ReportSource = CustomerReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "CustomerCode"  **if selected CustomerCode item from comboSearch
                    CustomerReport.SetDataSource(CustomersClass.SearchCustomers("CustCustomCode", dgvSearch.CurrentRow.Cells["CustomerCode"].Value.ToString()));
                    //Refresh Report
                    CustomerReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    CustomerViewerFrm.ShowDialog();
                    //Change Cursor to Default Cursor
                    this.Cursor = Cursors.Default;
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

        //radBtnActive_CheckedChanged Method to Search by CustomerDebitStatus or CustomerType or Customerstatus
        private void radBtnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerType", radBtnActive.Text);
            }
            else if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 9)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerDebitSatus", "1");
            }
            else if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 11)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerStatus", "1");
            }
        }

        //radBtnDeactive_CheckedChanged Method to Search by CustomerDebitStatus or CustomerType or Customerstatus
        private void radBtnDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerType", radBtnDeactive.Text);
            }
            //True is equal 1 and false is equal 0
            else if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 9)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerDebitSatus", "0");
            }
            else if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 11)
            {
                dgvSearch.DataSource = CustomersClass.SearchCustomers("CustomerStatus", "0");
            }
        }

        #endregion

    }
}
