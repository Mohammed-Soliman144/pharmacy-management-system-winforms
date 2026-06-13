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
    public partial class FRM_StoreSearch : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoresClass = new BAL.CLS_Stores();
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

        //Constructor OF FRM_StoreSearch
        public FRM_StoreSearch()
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
            //Intialize DataSource of DGV is StoresClass.ShowStoresTable();
            dgvSearch.DataSource = StoresClass.ShowStoresTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {

            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[]
                    { "كود المخزن", "اسم المخزن", "رقم الهاتف", "عنوان المخزن", 
                        "نوع المخزن", "مدير المخزن","حالة المخزن","الفرع التابع له"};

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
            if (comboSearch.SelectedIndex >= 0 && comboSearch.SelectedIndex != 6)
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

        //txtSearch_KeyDown Method to search in Stores table Advance Way when user press enter
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
                            case "كود المخزن":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchStores by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by StoreCustomCode
                                dgvSearch.DataSource = StoresClass.SearchStores("StoreCustomCode", txtSearch.Text);
                                break;
                            case "اسم المخزن":
                                //Set DataTable is DataSource of DataGridView search by StoreName
                                dgvSearch.DataSource = StoresClass.SearchStores("StoreName", txtSearch.Text);
                                break;
                            case "رقم الهاتف":
                                //Set DataTable is DataSource of DataGridView search by StorePhone
                                dgvSearch.DataSource = StoresClass.SearchStores("StorePhone", txtSearch.Text);
                                break;
                            case "عنوان المخزن":
                                //Set DataTable is DataSource of DataGridView search by StoreAddress
                                dgvSearch.DataSource = StoresClass.SearchStores("StoreAddress", txtSearch.Text);
                                break;
                            case "نوع المخزن":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchStoress by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by StoreType
                                dgvSearch.DataSource = StoresClass.SearchStores("StoreType", txtSearch.Text);
                                break;
                            case "الفرع التابع له":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchStores by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by StoreBranch
                                dgvSearch.DataSource = StoresClass.SearchStores("StoreBranch", txtSearch.Text);
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
                        //Set ShowSuppliersTable is DataSource of DataGridView (all Stores table)
                        dgvSearch.DataSource = StoresClass.ShowStoresTable();
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

        //dgvSearch_CellContentClick Method to show selected Supplier or print selected Supplier CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Stores or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderStores by clear it 
                    FRM_Stores.StoreAccess_Property.errProviderStores.Clear();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreCode"].Value to lblID.text
                    FRM_Stores.StoreAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["StoreCode"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreName"].Value to txtName.Text
                    FRM_Stores.StoreAccess_Property.txtName.Text = dgvSearch.CurrentRow.Cells["StoreName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreAddress"].Value to txtAddress.Text
                    FRM_Stores.StoreAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["StoreAddress"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StorePhone"].Value to txtPhone.Text
                    FRM_Stores.StoreAccess_Property.txtPhone.Text = dgvSearch.CurrentRow.Cells["StorePhone"].Value.ToString();

                    
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreManager"].Value to comboManager.Text
                    FRM_Stores.StoreAccess_Property.comboManager.SelectedValue = dgvSearch.CurrentRow.Cells["StoreManager"].Value.ToString();
                    
                    //if StoreBranch is equal Not Null 
                    if (dgvSearch.CurrentRow.Cells["StoreBranch"].Value.ToString() != "")
                    {
                        //Set Value of Search dgvSearch.CurrentRow.Cells["StoreManager"].Value to comboBranch.Text
                        FRM_Stores.StoreAccess_Property.comboBranch.SelectedValue = dgvSearch.CurrentRow.Cells["StoreBranch"].Value.ToString();
                    }

                    
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreManager"].Value to txtCapacity.Text
                    FRM_Stores.StoreAccess_Property.txtCapacity.Text = dgvSearch.CurrentRow.Cells["StoreCapacity"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["StoreType"].Value to comboType.Text
                    FRM_Stores.StoreAccess_Property.comboType.Text = dgvSearch.CurrentRow.Cells["StoreType"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["StorePassword"].Value to txtPassword.Text
                    FRM_Stores.StoreAccess_Property.txtPassword.Text = dgvSearch.CurrentRow.Cells["StorePassword"].Value.ToString();


                    //if User Status is deactivate or dgvSearch.CurrentRow.Cells["StoreStatus"].Value is false
                    if (dgvSearch.CurrentRow.Cells["StoreStatus"].Value.ToString() == "false")
                    {
                        //Initialize True Value to Visible of lblStoreStatus
                        FRM_Stores.StoreAccess_Property.lblStoreStatus.Visible = true;
                        //Initialize True Value to Visible of lblStoreActivate
                        FRM_Stores.StoreAccess_Property.lblStoreActivate.Visible = true;
                        //Initialize Text Value of lblStoreStatus
                        FRM_Stores.StoreAccess_Property.lblStoreStatus.Text = "ملف المخزن غير نشط";
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Stores.StoreAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Stores.StoreAccess_Property.btnModify.Enabled = false;
                        //Fire Timer or Lanuch timer to start
                        FRM_Stores.StoreAccess_Property.timerStores.Start();
                        //Initialize True Value to Enabled of timerStores
                        FRM_Stores.StoreAccess_Property.timerStores.Enabled = true;
                    }
                    else //if User Status is Activate or dgvSearch.CurrentRow.Cells["StoreStatus"].Value is true
                    {
                        //Initialize false Value to Visible of lblStoreStatus
                        FRM_Stores.StoreAccess_Property.lblStoreStatus.Visible = false;
                        //Initialize false Value to Visible of lblStoreActivate
                        FRM_Stores.StoreAccess_Property.lblStoreActivate.Visible = false;
                        //Initialize true Value to Enabled of btnDelete
                        FRM_Stores.StoreAccess_Property.btnDelete.Enabled = true;
                        //Initialize False true to Enabled of btnModify
                        FRM_Stores.StoreAccess_Property.btnModify.Enabled = true;
                        //Stop Timer
                        FRM_Stores.StoreAccess_Property.timerStores.Stop();
                        //Initialize false Value to Enabled of timerStores
                        FRM_Stores.StoreAccess_Property.timerStores.Enabled = false;
                    }
                    //Close Form
                    this.Close();

                }
                //if the index of row greater than or equal zero and index of Image column Print btn is 1
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_SuppliersViewerRpt is Form Viewer
                    RPT.FRM_StoresViewerRpt StoreViewerFrm = new RPT.FRM_StoresViewerRpt();
                    //Create New Instance From RPT.StoreSelectedRpt is Report
                    RPT.StoreSelectedRpt SupplierReport = new RPT.StoreSelectedRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created SupplierReport
                    StoreViewerFrm.crystalRptViewerStores.ReportSource = SupplierReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "SupCustomCode"  **if selected SupplierCode item from comboSearch
                    SupplierReport.SetDataSource(StoresClass.SearchStores("StoreCustomCode", dgvSearch.CurrentRow.Cells["StoreCode"].Value.ToString()));
                    SupplierReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    StoreViewerFrm.ShowDialog();
                    //Change Cursor to Default Cursor
                    this.Cursor = Cursors.Default;
                }
                //if the index of row greater than or equal zero and index of Image column Print btn is 2
                //To Show Items of Store
                else if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    //To Show Items of Store
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

        //btnPrintAll_Click Method To Print All Stores
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_StoresViewerRpt is Form Viewer
                RPT.FRM_StoresViewerRpt StoreViewerFrm = new RPT.FRM_StoresViewerRpt();
                //Create New Instance From RPT.StoresRpt is Report
                RPT.StoresRpt StoreReport = new RPT.StoresRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created StoreReport
                StoreViewerFrm.crystalRptViewerStores.ReportSource = StoreReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all Stores
                StoreReport.SetDataSource(StoresClass.ShowStoresTable());
                //Refresh Report
                StoreReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                StoreViewerFrm.ShowDialog();
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

        //radBtnActive_CheckedChanged Method to Search by StoreStatus
        private void radBtnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = StoresClass.SearchStores("StoreStatus", "1");
            }
        }

        //radBtnDeactive_CheckedChanged Method to Search by StoreStatus
        private void radBtnDeactive_CheckedChanged(object sender, EventArgs e)
        {
            //True is equal 1 and false is equal 0
            if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = StoresClass.SearchStores("StoreStatus", "0");
            }
        }

        #endregion
    }
}
