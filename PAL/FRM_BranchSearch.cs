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
    public partial class FRM_BranchSearch : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchesClass = new BAL.CLS_Branches();
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

        //Constructor OF FRM_BranchSearch
        public FRM_BranchSearch()
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
            //Intialize DataSource of DGV is BranchesClass.ShowBranchesTable();
            dgvSearch.DataSource = BranchesClass.ShowBranchesTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {

            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[]
                    { "كود الفرع", "اسم الفرع", "رقم الهاتف", "عنوان الفرع",
                        "الفاكس", "مدير الفرع","حالة الفرع"};

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
            //Focus on Text Box
            txtSearch.Focus();
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

        //txtSearch_KeyDown Method to search in Branches table Advance Way when user press enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                /* { "كود الفرع", "اسم الفرع", "رقم الهاتف", "عنوان الفرع",
                        "الفاكس", "مدير الفرع","حالة الفرع"};*/
                if (e.KeyCode == Keys.Enter)
                {
                    //if txtSearch.Text is not equal string.Empty
                    if (txtSearch.Text != string.Empty)
                    {
                        //switch conditional statemenr (string) {Case "valueofstring": break;}
                        //Search based on ColumnName
                        switch (comboSearch.Text)
                        {
                            case "كود الفرع":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchBranches by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by BranchCustomCode
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchCustomCode", txtSearch.Text);
                                break;
                            case "اسم الفرع":
                                //Set DataTable is DataSource of DataGridView search by BranchName
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchName", txtSearch.Text);
                                break;
                            case "رقم الهاتف":
                                //Set DataTable is DataSource of DataGridView search by BranchPhoneN1
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchPhoneN1", txtSearch.Text);
                                break;
                            case "الفاكس":
                                //Set DataTable is DataSource of DataGridView search by BranchFax
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchFax", txtSearch.Text);
                                break;
                            case "مدير الفرع":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchBranches by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by BranchManager
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchManager", txtSearch.Text);
                                break;
                            case "عنوان الفرع":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchBranches by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by BranchAddress
                                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchAddress", txtSearch.Text);
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
                        //Set ShowSuppliersTable is DataSource of DataGridView (all Branches table)
                        dgvSearch.DataSource = BranchesClass.ShowBranchesTable();
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

        //dgvSearch_CellContentClick Method to show selected Branch or print selected Branch CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Stores or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderBranches by clear it 
                    FRM_Branches.BranchAccess_Property.errProviderBranches.Clear();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchCustomCode"].Value to lblID.text
                    FRM_Branches.BranchAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["BranchCustomCode"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchName"].Value to txtName.Text
                    FRM_Branches.BranchAccess_Property.txtName.Text = dgvSearch.CurrentRow.Cells["BranchName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchAddress"].Value to txtAddress.Text
                    FRM_Branches.BranchAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["BranchAddress"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchPhoneN1"].Value to txtPhone1.Text
                    FRM_Branches.BranchAccess_Property.txtPhone1.Text = dgvSearch.CurrentRow.Cells["BranchPhoneN1"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchPhoneN2"].Value to txtPhone2.Text
                    FRM_Branches.BranchAccess_Property.txtPhone2.Text = dgvSearch.CurrentRow.Cells["BranchPhoneN2"].Value.ToString();

                    //if BranchEmail is not null or dgvSearch.CurrentRow.Cells["BranchEmail"].Value is not null
                    if (dgvSearch.CurrentRow.Cells["BranchEmail"].Value.ToString() != "")
                    {
                        //Set Value of Search dgvSearch.CurrentRow.Cells["BranchEmail"].Value to txtEmail.Text
                        FRM_Branches.BranchAccess_Property.txtEmail.Text = dgvSearch.CurrentRow.Cells["BranchEmail"].Value.ToString();
                    }
                    else // txtemail is null
                    {
                        //Set Value of Search dgvSearch.CurrentRow.Cells["BranchEmail"].Value to txtEmail.Text
                        FRM_Branches.BranchAccess_Property.txtEmail.Text = "someone@gmail.com";
                    }

                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchFax"].Value to txtFax.Text
                    FRM_Branches.BranchAccess_Property.txtFax.Text = dgvSearch.CurrentRow.Cells["BranchFax"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["BranchManager"].Value to comboManager.Text
                    FRM_Branches.BranchAccess_Property.comboManager.SelectedValue = dgvSearch.CurrentRow.Cells["BranchManager"].Value.ToString();

                    //if Branch Status is Activate or dgvSearch.CurrentRow.Cells["StoreStatus"].Value is true
                    if (dgvSearch.CurrentRow.Cells["BranchStatus"].Value.ToString() == "true")
                    {
                        //Initialize false Value to Visible of lblBranchStatus
                        FRM_Branches.BranchAccess_Property.lblBranchStatus.Visible = false;
                        //Initialize false Value to Visible of lblBranchActivate
                        FRM_Branches.BranchAccess_Property.lblBranchActivate.Visible = false;
                        //Initialize Text Value of lblBranchStatus
                        FRM_Branches.BranchAccess_Property.lblBranchStatus.Text = "فرع نشط";
                        //Set Value of ToolTip is branch status active tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Branches.BranchAccess_Property.toolTipBranches.SetToolTip(FRM_Branches.BranchAccess_Property.lblBranchStatus, "فرع نشط");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Branches.BranchAccess_Property.btnDelete.Enabled = true;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Branches.BranchAccess_Property.btnModify.Enabled = true;
                    }
                    else //if Branch Status is deactivate or dgvSearch.CurrentRow.Cells["BranchStatus"].Value is false
                    {
                        //Initialize True Value to Visible of lblBranchStatus
                        FRM_Branches.BranchAccess_Property.lblBranchStatus.Visible = true;
                        //Initialize True Value to Visible of lblBranchActivate
                        FRM_Branches.BranchAccess_Property.lblBranchActivate.Visible = true;
                        //Initialize Text Value of lblBranchStatus
                        FRM_Branches.BranchAccess_Property.lblBranchStatus.Text = "فرع غير نشط";
                        //Set Value of ToolTip is branch status deactivate tooltip.SetToolTip(ControlName,"strMessage")
                        FRM_Branches.BranchAccess_Property.toolTipBranches.SetToolTip(FRM_Branches.BranchAccess_Property.lblBranchStatus, "فرع غير نشط");
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Branches.BranchAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Branches.BranchAccess_Property.btnModify.Enabled = false;
                    }
                    //Close Form
                    this.Close();
                }
                //if the index of row greater than or equal zero and index of Image column Print btn is 1
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_BranchesViewerRpt is Form Viewer
                    RPT.FRM_BranchesViewerRpt BranchViewerFrm = new RPT.FRM_BranchesViewerRpt();
                    //Create New Instance From RPT.BranchSelectedRpt is Report
                    RPT.BranchSelectedRpt BranchReport = new RPT.BranchSelectedRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created BranchReport
                    BranchViewerFrm.crystalRptViewerBranches.ReportSource = BranchReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "BranchCustomCode"  **if selected BranchCustomCode item from comboSearch
                    BranchReport.SetDataSource(BranchesClass.SearchBranches("BranchCustomCode", dgvSearch.CurrentRow.Cells["BranchCustomCode"].Value.ToString()));
                    //Refresh Report
                    BranchReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    BranchViewerFrm.ShowDialog();
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

        //btnPrintAll_Click Method To Print All Branches
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_BranchesViewerRpt is Form Viewer
                RPT.FRM_BranchesViewerRpt BranchViewerFrm = new RPT.FRM_BranchesViewerRpt();
                //Create New Instance From RPT.BranchesRpt is Report
                RPT.BranchesRpt BranchReport = new RPT.BranchesRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created StoreReport
                BranchViewerFrm.crystalRptViewerBranches.ReportSource = BranchReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all Branches
                BranchReport.SetDataSource(BranchesClass.ShowBranchesTable());
                //Refresh Report
                BranchReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                BranchViewerFrm.ShowDialog();
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

        //radBtnActive_CheckedChanged Method to Search by BranchStatus true equal 1
        private void radBtnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchStatus", "1");
            }
        }

        //radBtnDeactive_CheckedChanged Method to Search by BranchStatus
        private void radBtnDeactive_CheckedChanged(object sender, EventArgs e)
        {
            //True is equal 1 and false is equal 0
            if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = BranchesClass.SearchBranches("BranchStatus", "0");
            }
        }

        #endregion
    }
}
