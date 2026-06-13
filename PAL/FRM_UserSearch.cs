using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //To Deal With MemoryStream

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_UserSearch : Form
    {
        #region Public Declaration
        //Create New Instance From BAL.CLS_Users Business Access Layer
        readonly BAL.CLS_Users UsersClass = new BAL.CLS_Users();
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

        //Constructor of FRM_UserSearch
        public FRM_UserSearch()
        {
            InitializeComponent();
            //Set Properties OF DataGridView
            InitializeDGV();
            //Focus on txtSearch
            txtSearch.Focus();
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
            //Intialize DataSource of DGV is UsersClass.ShowUsersTable();
            dgvSearch.DataSource = UsersClass.ShowUsersTable();
        }

        //btnClose_Click to Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close Form
            this.Close();
        }

        //txtSearch_TextChanged To Search in Users Advance Way
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if txtSearch.Text is not equal string.Empty
                if (txtSearch.Text != string.Empty)
                {
                    //Recall DataTable Fucation from BAL (Business Access Layer) to SearchUsers by txtSearch.Text
                    //Set DataTable is DataSource of DataGridView
                    dgvSearch.DataSource = UsersClass.SearchUsers(txtSearch.Text);
                }
                //if txtSearch.Text is equal string.Empty
                else
                {
                    //Set ShowUsersTable is DataSource of DataGridView (all users table)
                    dgvSearch.DataSource = UsersClass.ShowUsersTable();
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

        //dgvSearch_CellContentClick Method to show selected user or print selected user CellContentClick
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Search btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 0)
                {
                    //Use Encapsulation of FRM_Users or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderUsers by clear it 
                    FRM_Users.UserAccess_Property.errProviderUsers.Clear();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserCode"].Value to lblID.text
                    FRM_Users.UserAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["UserCode"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserFullName"].Value to txtFullName.Text
                    FRM_Users.UserAccess_Property.txtFullName.Text = dgvSearch.CurrentRow.Cells["UserFullName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserGender"].Value to comboGender.Text
                    FRM_Users.UserAccess_Property.comboGender.Text = dgvSearch.CurrentRow.Cells["UserGender"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserNatID"].Value to txtNatID.Text
                    FRM_Users.UserAccess_Property.txtNatID.Text = dgvSearch.CurrentRow.Cells["UserNatID"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserPhone"].Value to txtPhone.Text
                    FRM_Users.UserAccess_Property.txtPhone.Text = dgvSearch.CurrentRow.Cells["UserPhone"].Value.ToString();
                    //Initialize Properties.Settings.Default.UserJobs is Datasource of comboJob after Cast<Generic string class>().Tolist();
                    FRM_Users.UserAccess_Property.comboJob.DataSource = Properties.Settings.Default.UserJobs.Cast<string>().ToList();
                    //Set Value of Search gvSearch.CurrentRow.Cells["UserJob"].Value to comboJob.Text
                    FRM_Users.UserAccess_Property.comboJob.SelectedItem = dgvSearch.CurrentRow.Cells["UserJob"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserAddress"].Value to txtAddress.Text
                    FRM_Users.UserAccess_Property.txtAddress.Text = dgvSearch.CurrentRow.Cells["UserAddress"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserForPro"].Value is true is User for Program
                    if (dgvSearch.CurrentRow.Cells["UserForPro"].Value.ToString() == "true")
                    {
                        //Set Value True to rbtnIsUser.Checked radiobutton
                        FRM_Users.UserAccess_Property.rbtnIsUser.Checked = true;
                        //Set Value of Search dgvSearch.CurrentRow.Cells["UserName"].Value to txtUserName.Text
                        FRM_Users.UserAccess_Property.txtUserName.Text = dgvSearch.CurrentRow.Cells["UserName"].Value.ToString();
                        //Set Value of Search gvSearch.CurrentRow.Cells["UserPassword"].Value to txtPassword.Text
                        FRM_Users.UserAccess_Property.txtPassword.Text = dgvSearch.CurrentRow.Cells["UserPassword"].Value.ToString();
                    }
                    //Set Value of Search dgvSearch.CurrentRow.Cells["UserForPro"].Value is false is User for Program
                    else
                    {
                        //Set Value True to rbtnNotUser.Checked radiobutton
                        FRM_Users.UserAccess_Property.rbtnNotUser.Checked = true;
                        //Clear Text of FRM_Users.UserAccess_Property.txtUserName
                        FRM_Users.UserAccess_Property.txtUserName.Clear();
                        //Clear Text of FRM_Users.UserAccess_Property.txtPassword
                        FRM_Users.UserAccess_Property.txtPassword.Clear();
                    }

                    //if User Status is deactivate or dgvSearch.CurrentRow.Cells["UserStatus"].Value is false
                    if (dgvSearch.CurrentRow.Cells["UserStatus"].Value.ToString() == "")
                    {
                        //Initialize True Value to Visible of lblUserStatus
                        FRM_Users.UserAccess_Property.lblUserStatus.Visible = true;
                        //Initialize True Value to Visible of lblUserActivate
                        FRM_Users.UserAccess_Property.lblUserActivate.Visible = true;
                        //Initialize Text Value of lblUserStatus
                        FRM_Users.UserAccess_Property.lblUserStatus.Text = "ملف المستخدم غير نشط";
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Users.UserAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Users.UserAccess_Property.btnModify.Enabled = false;
                        //Fire Timer or Lanuch timer to start
                        FRM_Users.UserAccess_Property.timerUsers.Start();
                        //Initialize True Value to Enabled of timerUsers
                        FRM_Users.UserAccess_Property.timerUsers.Enabled = true;
                    }
                    else //if User Status is Activate or dgvSearch.CurrentRow.Cells["UserStatus"].Value is true
                    {
                        //Initialize false Value to Visible of lblUserStatus
                        FRM_Users.UserAccess_Property.lblUserStatus.Visible = false;
                        //Initialize false Value to Visible of lblUserActivate
                        FRM_Users.UserAccess_Property.lblUserActivate.Visible = false;
                        //Initialize true Value to Enabled of btnDelete
                        FRM_Users.UserAccess_Property.btnDelete.Enabled = true;
                        //Initialize False true to Enabled of btnModify
                        FRM_Users.UserAccess_Property.btnModify.Enabled = true;
                        //Stop Timer
                        FRM_Users.UserAccess_Property.timerUsers.Stop();
                        //Initialize false Value to Enabled of timerUsers
                        FRM_Users.UserAccess_Property.timerUsers.Enabled = false;
                    }

                    //if dgvSearch.CurrentRow.Cells["UserImage"].Value is DBNull.Value empty image
                    if (dgvSearch.CurrentRow.Cells["UserImage"].Value == DBNull.Value)
                    {
                        //Set Default Image from Properties.Resources.ImageName To pbUsers.Image 
                        FRM_Users.UserAccess_Property.pbUsers.Image = Properties.Resources.User;
                        //Close Search Form
                        this.Close();
                    }
                    //if dgvSearch.CurrentRow.Cells["UserImage"].Value is not DBNull.Value
                    else
                    {
                        //Declare Variable from MemoryStream without value
                        MemoryStream MStream;
                        //Create new instance from byte[] array to store image from database in it
                        //After Convert Image in db to (byte []) dgvSearch.CurrentRow.Cells["UserImage"].Value
                        byte[] imgByte = (byte[])dgvSearch.CurrentRow.Cells["UserImage"].Value;
                        //Initialize Value of byte array to Instance which created from MemoryStream
                        MStream = new MemoryStream(imgByte);
                        //Initialize Value of MemoryStream to pbUsers.Image (Image.FromStream(MStream);
                        FRM_Users.UserAccess_Property.pbUsers.Image = Image.FromStream(MStream);
                        //Close Search Form
                        this.Close();
                    }
                }
                //if the index of row greater than or equal zero and index of button column Print btn is 
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_UsersViewerRpt is Form Viewer
                    RPT.FRM_UsersViewerRpt UserViewerFrm = new RPT.FRM_UsersViewerRpt();
                    //Create New Instance From RPT.UserSelectedRpt is Report
                    RPT.UserSelectedRpt UserReport = new RPT.UserSelectedRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created UserReport
                    UserViewerFrm.crystalRptViewerUsers.ReportSource = UserReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "UserCode"
                    UserReport.SetDataSource(UsersClass.SearchUsers(dgvSearch.CurrentRow.Cells["UserCode"].Value.ToString()));
                    //Refresh Report
                    UserReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    UserViewerFrm.ShowDialog();
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
        //btnPrintAll_Click Method To Print All Users
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_UsersViewerRpt is Form Viewer
                RPT.FRM_UsersViewerRpt UserViewerFrm = new RPT.FRM_UsersViewerRpt();
                //Create New Instance From RPT.UsersRpt is Report
                RPT.UsersRpt UserReport = new RPT.UsersRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created UserReport
                UserViewerFrm.crystalRptViewerUsers.ReportSource = UserReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all users
                UserReport.SetDataSource(UsersClass.SearchUsers(""));
                //Refresh Report
                UserReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                UserViewerFrm.ShowDialog();
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
        #endregion

    }
}
