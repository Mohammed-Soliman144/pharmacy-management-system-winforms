using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // To Deal With MemoryStream

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_CompanySearch : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Companies Business Access Layer
        readonly BAL.CLS_Companies CompaniesClass = new BAL.CLS_Companies();
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

        //Constructor OF FRM_CompanySearch
        public FRM_CompanySearch()
        {
            InitializeComponent();
            //Set Properties OF DataGridView
            InitializeDGV();
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
            //Intialize DataSource of DGV is CompaniesClass.ShowCompaniesTable();
            dgvSearch.DataSource = CompaniesClass.ShowCompaniesTable();
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

        //dgvSearch_CellContentClick Method to show selected Company or print selected Company CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Stores or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderCompanies by clear it 
                    FRM_Companies.CompAccess_Property.errProviderCompanies.Clear();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyCustomID"].Value to lblID.text
                    FRM_Companies.CompAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["CompanyCustomID"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyName"].Value to txtName.Text
                    FRM_Companies.CompAccess_Property.txtName.Text = dgvSearch.CurrentRow.Cells["CompaniesName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyCategory"].Value to txtComCategory.Text
                    FRM_Companies.CompAccess_Property.txtComCategory.Text = dgvSearch.CurrentRow.Cells["CompanyCategory"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyAddress"].Value to txtAddress.Text
                    FRM_Companies.CompAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["CompanyAddress"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyCity"].Value to txtCity.Text
                    FRM_Companies.CompAccess_Property.txtCity.Text = dgvSearch.CurrentRow.Cells["CompanyCity"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyCountry"].Value to txtCountry.Text
                    FRM_Companies.CompAccess_Property.txtCountry.Text = dgvSearch.CurrentRow.Cells["CompanyCountry"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyPhoneN1"].Value to txtPhone1.Text
                    FRM_Companies.CompAccess_Property.txtPhone1.Text = dgvSearch.CurrentRow.Cells["CompanyPhoneN1"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyPhoneN2"].Value to txtPhone2.Text
                    FRM_Companies.CompAccess_Property.txtPhone2.Text = dgvSearch.CurrentRow.Cells["CompanyPhoneN2"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyPhoneN3"].Value to txtPhone3.Text
                    FRM_Companies.CompAccess_Property.txtPhone3.Text = dgvSearch.CurrentRow.Cells["CompanyPhoneN3"].Value.ToString();


                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyFax"].Value to txtFax.Text
                    FRM_Companies.CompAccess_Property.txtFax.Text = dgvSearch.CurrentRow.Cells["CompanyFax"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyEmail"].Value to txtEmail.Text
                    FRM_Companies.CompAccess_Property.txtEmail.Text = dgvSearch.CurrentRow.Cells["CompanyEmail"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyWebsite"].Value to txtWebsite.Text
                    FRM_Companies.CompAccess_Property.txtWebsite.Text = dgvSearch.CurrentRow.Cells["CompanyWebsite"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyType"].Value to comboCompType.SelectedText
                    FRM_Companies.CompAccess_Property.comboCompType.Text = dgvSearch.CurrentRow.Cells["CompanyType"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyCommericalNo"].Value to txtCommerical.Text
                    FRM_Companies.CompAccess_Property.txtCommerical.Text = dgvSearch.CurrentRow.Cells["CompanyCommericalNo"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyTaxNo"].Value to txtTax.Text
                    FRM_Companies.CompAccess_Property.txtTax.Text = dgvSearch.CurrentRow.Cells["CompanyTaxNo"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyFinStartDate"].Value to dtpStartFinancial.Value
                    FRM_Companies.CompAccess_Property.dtpStartFinancial.Value = Convert.ToDateTime(dgvSearch.CurrentRow.Cells["CompanyFinStartDate"].Value);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyFinEndDate"].Value to dtpEndFinancial.Value
                    FRM_Companies.CompAccess_Property.dtpEndFinancial.Value = Convert.ToDateTime(dgvSearch.CurrentRow.Cells["CompanyFinEndDate"].Value);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["CompanyManager"].Value to comboManager.SelectedValue
                    FRM_Companies.CompAccess_Property.comboManager.SelectedValue = dgvSearch.CurrentRow.Cells["CompanyManager"].Value.ToString();

                    //if dgvSearch.CurrentRow.Cells["CompanyLogo"].Value is DBNull.Value empty image
                    if (dgvSearch.CurrentRow.Cells["CompanyLogo"].Value == DBNull.Value)
                    {
                        //Set Default Image from Properties.Resources.ImageName To pbLogo.Image 
                        FRM_Companies.CompAccess_Property.pbLogo.Image = Properties.Resources.User;
                        //Close Search Form
                        this.Close();
                    }
                    //if dgvSearch.CurrentRow.Cells["CompanyLogo"].Value is not DBNull.Value
                    else
                    {
                        //Declare Variable from MemoryStream without value
                        MemoryStream MStream;
                        //Create new instance from byte[] array to store image from database in it
                        //After Convert Image in db to (byte []) dgvSearch.CurrentRow.Cells["CompanyLogo"].Value
                        byte[] imgByte = (byte[])dgvSearch.CurrentRow.Cells["CompanyLogo"].Value;
                        //Initialize Value of byte array to Instance which created from MemoryStream
                        MStream = new MemoryStream(imgByte);
                        //Initialize Value of MemoryStream to pbLogo.Image (Image.FromStream(MStream);
                        FRM_Companies.CompAccess_Property.pbLogo.Image = Image.FromStream(MStream);
                        //Close Search Form
                        this.Close();
                    }
                }
                //if the index of row greater than or equal zero and index of Image column Print btn is 1
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1) 
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_SuppliersViewerRpt is Form Viewer
                    RPT.FRM_CompaniesViewerRpt CompanyViewerFrm = new RPT.FRM_CompaniesViewerRpt();
                    //Create New Instance From RPT.StoreSelectedRpt is Report
                    RPT.CompanySelectedRpt CompanyReport = new RPT.CompanySelectedRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created SupplierReport
                    CompanyViewerFrm.crystalRptViewerCompanies.ReportSource = CompanyReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "CompanyCustomID" 
                    CompanyReport.SetDataSource(CompaniesClass.SearchCompanies("CompanyCustomID", dgvSearch.CurrentRow.Cells["CompanyCustomID"].Value.ToString()));
                    //Refresh of Report
                    CompanyReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    CompanyViewerFrm.ShowDialog();
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
       
        #endregion
    }
}
