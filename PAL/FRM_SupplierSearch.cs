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
    public partial class FRM_SupplierSearch : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Suppliers Business Access Layer
        readonly BAL.CLS_Suppliers SuppliersClass = new BAL.CLS_Suppliers();
        //Create New Instance From BAL.CLS_SupplierAccount Business Access Layer
        readonly BAL.CLS_SupplierAccount SupplierAccountClass = new BAL.CLS_SupplierAccount();
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

        //Constructor OF FRM_SupplierSearch
        public FRM_SupplierSearch()
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
            //Intialize DataSource of DGV is SuppliersClass.ShowSuppliersTable();
            dgvSearch.DataSource = SuppliersClass.ShowSuppliersTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {

            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[]
                    { "كود المورد", "اسم المورد", "اسم الشركة", "اسم المسئول", "رقم الهاتف",
                      "رقم الفاكس","العنوان","منطقة المورد","البريد اليكترونى","نوع المورد",
                      "تصنيف المورد","حجم التعامل","اقصى حد للمسحوبات","الخصم الثابت على الاجمالى","رصيد المورد","حالة المورد"};

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
        /// Decimal Function to Sum of Supplier Balance or Credit or Debit
        /// </summary>
        /// <param name="supID">supID</param>
        /// <param name="columnName">ColumnName Need to Get Sum of It</param>
        /// <returns>Sum of Supplier Balance or Credit or Debit</returns>
        private decimal GetSupplierBalance(string supID, string columnName)
        {
            //Declare Decimal Variable to Get Sum of Supplier Balance or Credit or Debit ==> depends on Argument columnName
            decimal sum = 0;

            //Initialize Result of DataTable Function To Search in SupplierAccount by Supplier ID
            //this Function received three Arguments (ColumnName Mandatory, SearchKey Mandatory,SearchKey1 is Optional represents null or empty
            DataTable dt = SupplierAccountClass.SearchSupAccount("SupplierID", supID, "", "", "");

            //Use for loop to get Sum of Supplier Balance or Credit or Debit
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
            if (comboSearch.SelectedIndex >= 0 && comboSearch.SelectedIndex != 9 && comboSearch.SelectedIndex != 15)
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
            else if (comboSearch.SelectedIndex == 9)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Text = "مورد نقدى";
                    radBtnDeactive.Text = "مورد آجل";
                }
                else
                {

                    txtSearch.Visible = false;
                    radBtnActive.Text = "مورد نقدى";
                    radBtnDeactive.Text = "مورد آجل";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;

                }
            }
            else if (comboSearch.SelectedIndex == 15)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Text = "حالة نشطة";
                    radBtnDeactive.Text = "حالة غير نشطة";
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

        //txtSearch_KeyDown Method to search in Suppliers table Advance Way when user press enter
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
                            case "كود المورد":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupCustomCode
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupCustomCode", txtSearch.Text);
                                break;
                            case "اسم المورد":
                                //Set DataTable is DataSource of DataGridView search by SupplierFullName
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierFullName", txtSearch.Text);
                                break;
                            case "اسم الشركة":
                                //Set DataTable is DataSource of DataGridView search by SupplierCompanyName
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierCompanyName", txtSearch.Text);
                                break;
                            case "اسم المسئول":
                                //Set DataTable is DataSource of DataGridView search by SupplierResponsibleName
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierResponsibleName", txtSearch.Text);
                                break;
                            case "رقم الهاتف":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierPhoneN1
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierPhoneN1", txtSearch.Text);
                                break;
                            case "رقم الفاكس":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchSuppliers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierFax
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierFax", txtSearch.Text);
                                break;
                            case "العنوان":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierAddress
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierAddress", txtSearch.Text);
                                break;
                            case "منطقة المورد":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierArea
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierArea", txtSearch.Text);
                                break;
                            case "البريد اليكترونى":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierEmail
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierEmail", txtSearch.Text);
                                break;
                            case "تصنيف المورد":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierClassGroup
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierClassGroup", txtSearch.Text);
                                break;
                            case "حجم التعامل":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierClassSize
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierClassSize", txtSearch.Text);
                                break;
                            case "اقصى حد للمسحوبات":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierCreditLimit
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierCreditLimit", txtSearch.Text);
                                break;
                            case "الخصم الثابت على الاجمالى":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierDiscount
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierDiscount", txtSearch.Text);
                                break;
                            case "رصيد المورد":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by SupplierBalance
                                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierBalance", txtSearch.Text);
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
                        //Set ShowSuppliersTable is DataSource of DataGridView (all Customers table)
                        dgvSearch.DataSource = SuppliersClass.ShowSuppliersTable();
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

        //btnPrintAll_Click Method To Print All Suppliers
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_SuppliersViewerRpt is Form Viewer
                RPT.FRM_SuppliersViewerRpt SupplierViewerFrm = new RPT.FRM_SuppliersViewerRpt();
                //Create New Instance From RPT.CustomersRpt is Report
                RPT.SuppliersRpt SupplierReport = new RPT.SuppliersRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created CustomerReport
                SupplierViewerFrm.crystalRptViewerSuppliers.ReportSource = SupplierReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all Customers
                SupplierReport.SetDataSource(SuppliersClass.ShowSuppliersTable());
                //Refresh Report
                SupplierReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                SupplierViewerFrm.ShowDialog();
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

        //dgvSearch_CellContentClick Method to show selected Supplier or print selected Supplier CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Suppliers or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderCustomers by clear it 
                    FRM_Suppliers.SupAccess_Property.errProviderSuppliers.Clear();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierCode"].Value to lblID.text
                    FRM_Suppliers.SupAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["SupplierCode"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierFullName"].Value to txtFullName.Text
                    FRM_Suppliers.SupAccess_Property.txtFullName.Text = dgvSearch.CurrentRow.Cells["SupplierFullName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierAddress"].Value to txtAddress.Text
                    FRM_Suppliers.SupAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["SupplierAddress"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierResponsible"].Value to txtResponsible.Text
                    FRM_Suppliers.SupAccess_Property.txtResponsible.Text = dgvSearch.CurrentRow.Cells["SupplierResponsible"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierPhone1"].Value to txtPhone1.Text
                    FRM_Suppliers.SupAccess_Property.txtPhone1.Text = dgvSearch.CurrentRow.Cells["SupplierPhone1"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierPhone2"].Value to txtPhone2.Text
                    FRM_Suppliers.SupAccess_Property.txtPhone2.Text = dgvSearch.CurrentRow.Cells["SupplierPhone2"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierPhone2"].Value to txtPhone2.Text
                    FRM_Suppliers.SupAccess_Property.txtPhone3.Text = dgvSearch.CurrentRow.Cells["SupplierPhone3"].Value.ToString();

                    //Set Value of Search gvSearch.CurrentRow.Cells["SupplierFax"].Value to txtFax.Text
                    FRM_Suppliers.SupAccess_Property.txtFax.Text = dgvSearch.CurrentRow.Cells["SupplierFax"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierEmail"].Value to txtEmail.Text
                    FRM_Suppliers.SupAccess_Property.txtEmail.Text = dgvSearch.CurrentRow.Cells["SupplierEmail"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierCompany"].Value to txtCompany.Text
                    FRM_Suppliers.SupAccess_Property.txtCompany.Text = dgvSearch.CurrentRow.Cells["SupplierCompany"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierType"].Value to comboSupType.Text
                    FRM_Suppliers.SupAccess_Property.comboSupType.Text = dgvSearch.CurrentRow.Cells["SupplierType"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierGroup"].Value to comboGroup.Text
                    FRM_Suppliers.SupAccess_Property.comboGroup.Text = dgvSearch.CurrentRow.Cells["SupplierGroup"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierArea"].Value to comboArea.Text
                    FRM_Suppliers.SupAccess_Property.comboArea.Text = dgvSearch.CurrentRow.Cells["SupplierArea"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierSize"].Value to comboSize.Text
                    FRM_Suppliers.SupAccess_Property.comboSize.Text = dgvSearch.CurrentRow.Cells["SupplierSize"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierCreditLimit"].Value to txtCreditLimit.Text
                    FRM_Suppliers.SupAccess_Property.txtCreditLimit.Text = dgvSearch.CurrentRow.Cells["SupplierCreditLimit"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierDiscount"].Value to txtDiscount.Text
                    FRM_Suppliers.SupAccess_Property.txtDiscount.Text = dgvSearch.CurrentRow.Cells["SupplierDiscount"].Value.ToString();


                    //Set Value of GetSupplierBalance(dgvSearch.CurrentRow.Cells["SupplierID"].Value.ToString(), "القيمة المدينة").ToString();
                    FRM_Suppliers.SupAccess_Property.txtDebit.Text = GetSupplierBalance(dgvSearch.CurrentRow.Cells["SupplierID"].Value.ToString(), "القيمة المدينة").ToString();

                    //Set Value of GetSupplierBalance(dgvSearch.CurrentRow.Cells["SupplierID"].Value.ToString(), "القيمة الدائنة").ToString();
                    FRM_Suppliers.SupAccess_Property.txtCredit.Text = GetSupplierBalance(dgvSearch.CurrentRow.Cells["SupplierID"].Value.ToString(), "القيمة الدائنة").ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CustomerBalance"].Value to txtBalance.Text (CurrentBalance)
                    //if Customer Balance is Bebit (Negative Number) (balance * -1).ToString("{0:0.000;(0.000);0}") to input balance in Parentheses (balance)
                    FRM_Suppliers.SupAccess_Property.txtBalance.Text = dgvSearch.CurrentRow.Cells["SupplierBalance"].Value.ToString();
                    
                    //Change Value of txtBalance.ReadOnly to true
                    FRM_Suppliers.SupAccess_Property.txtBalance.ReadOnly = true;

                    //Check if debit Amount of customer is not equal true
                    if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["SupplierBalance"].Value) > 0)
                    {
                        FRM_Suppliers.SupAccess_Property.comboBalanceStatus.SelectedIndex = 2;
                    }
                    //Check if debit Amount of customer is equal true
                    else if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["SupplierBalance"].Value) == 0)
                    {
                        FRM_Suppliers.SupAccess_Property.comboBalanceStatus.SelectedIndex = 0;
                    }
                    else if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["SupplierBalance"].Value) < 0)
                    {
                        FRM_Suppliers.SupAccess_Property.comboBalanceStatus.SelectedIndex = 1;
                    }

                    FRM_Suppliers.SupAccess_Property.comboBalanceStatus.Enabled = false;

                    
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierNotes"].Value to txtNotes.Text
                    FRM_Suppliers.SupAccess_Property.txtNotes.Text = dgvSearch.CurrentRow.Cells["SupplierNotes"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierStatus"].Value is true is Activate Supplier 
                    if (dgvSearch.CurrentRow.Cells["SupplierStatus"].Value.ToString() == "true")
                    {
                        //Set Value True to pbSupStatus.Visible radiobutton
                        FRM_Suppliers.SupAccess_Property.pbSupStatus.Visible = false;
                        //Set Value True to pbSupStatus.Image equal Enable_Client image
                        FRM_Suppliers.SupAccess_Property.pbSupStatus.Image = Properties.Resources.Enable_Client;
                        //Set Value of ToolTip is Supplier status active tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Suppliers.SupAccess_Property.toolTipSuppliers.SetToolTip(FRM_Suppliers.SupAccess_Property.pbSupStatus, "مورد نشط");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Suppliers.SupAccess_Property.btnDelete.Enabled = true;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Suppliers.SupAccess_Property.btnModify.Enabled = true;
                    }
                    //Set Value of Search dgvSearch.CurrentRow.Cells["SupplierStatus"].Value is false is deactivate Supplier 
                    else
                    {
                        //Set Value True to pbSupStatus.Visible radiobutton
                        FRM_Suppliers.SupAccess_Property.pbSupStatus.Visible = true;
                        //Set Value True to pbSupStatus.Image equal Enable_Client image
                        FRM_Suppliers.SupAccess_Property.pbSupStatus.Image = Properties.Resources.Disable_Client;
                        //Set Value of ToolTip is Supplier status active tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Suppliers.SupAccess_Property.toolTipSuppliers.SetToolTip(FRM_Suppliers.SupAccess_Property.pbSupStatus, "مورد غير نشط\nيرجى الضغط على الصورة لإعادة تنشيط المورد");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Suppliers.SupAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Suppliers.SupAccess_Property.btnModify.Enabled = false;
                    }
                    //Close Form
                    this.Close();

                }
                //if the index of row greater than or equal zero and index of button column Print btn is 
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_SuppliersViewerRpt is Form Viewer
                    RPT.FRM_SuppliersViewerRpt SupplierViewerFrm = new RPT.FRM_SuppliersViewerRpt();
                    //Create New Instance From RPT.SupplierSelectedRpt is Report
                    RPT.SupplierSelectedRpt SupplierReport = new RPT.SupplierSelectedRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created SupplierReport
                    SupplierViewerFrm.crystalRptViewerSuppliers.ReportSource = SupplierReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "SupCustomCode"  **if selected SupplierCode item from comboSearch
                    SupplierReport.SetDataSource(SuppliersClass.SearchSuppliers("SupCustomCode", dgvSearch.CurrentRow.Cells["SupplierCode"].Value.ToString()));
                    //Refresh Report
                    SupplierReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    SupplierViewerFrm.ShowDialog();
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

        //radBtnActive_CheckedChanged Method to Search by SupplierType or Supplierstatus
        private void radBtnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 9)
            {
                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierType", radBtnActive.Text);
            }
            else if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 15)
            {
                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierStatus", "1");
            }
        }

        //radBtnDeactive_CheckedChanged Method to Search by SupplierType or Supplierstatus
        private void radBtnDeactive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 9)
            {
                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierType", radBtnDeactive.Text);
            }
            //True is equal 1 and false is equal 0
            else if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 15)
            {
                dgvSearch.DataSource = SuppliersClass.SearchSuppliers("SupplierStatus", "0");
            }
        }

        #endregion

    }
}
