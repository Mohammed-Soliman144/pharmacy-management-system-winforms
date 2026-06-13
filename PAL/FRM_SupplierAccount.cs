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
    public partial class FRM_SupplierAccount : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Suppliers Business Access Layer
        readonly BAL.CLS_Suppliers SupplierClass = new BAL.CLS_Suppliers();
        //Create New Instance From BAL.CLS_SupplierAccount Business Access Layer
        readonly BAL.CLS_SupplierAccount SupAccountClass = new BAL.CLS_SupplierAccount();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Using Object Oriented Programing to access FRM_SupplierAccount Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_SupplierAccount SupAccountFRM;

        //Create SupAccountAccess_FormClosed to recall it when close form
        private static void SupAccountAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            SupAccountFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_SupplierAccount SupAccountAccess_Property
        {
            //used getter to return value of FRM_SupplierAccount 
            get
            {
                //if created instance or field is null
                if (SupAccountFRM == null)
                {
                    //Create New Instance From FRM_Items by initialize it to field
                    SupAccountFRM = new FRM_SupplierAccount();
                    //Generate Event of Form Closed and Delegate Method SupAccountAccess_FormClosed to it
                    SupAccountFRM.FormClosed += new FormClosedEventHandler(SupAccountAccess_FormClosed);
                }
                //Return the value of field
                return SupAccountFRM;
            }
        }
        #endregion

        //Constructor OF FRM_SupplierAccount
        public FRM_SupplierAccount()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_SupplierAccount to it 
            if (SupAccountFRM == null) SupAccountFRM = this;
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
            //To Control Of MinimumHeight of Rows in dgv
            dgvSearch.RowTemplate.MinimumHeight = 35;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvSearch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvSearch.AutoGenerateColumns = false;
            //Intialize DataSource of DGV is SupAccountClass.ShowSupAccountTable();
            //dgvSearch.DataSource = SupAccountClass.ShowSupAccountTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //loop in all control in side this.pnlSearch.Controls
            foreach (Control ctrl in this.pnlSearch.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
                else if (ctrl is DateTimePicker)
                {
                    dtpDateFrom.Value = DateTime.Now;
                    dtpDateTo.Value = DateTime.Now;
                }
                else if ((ctrl is Label && ctrl.Text != string.Empty) && (ctrl == lblPreBalance))
                {
                    ctrl.Text = "0";
                }
                else if ((ctrl is Label && ctrl.Text != string.Empty) && (ctrl == lblPreviousStatus))//----
                {
                    ctrl.Text = "----";
                }
            }
            //loop in all control in side this.pnlSearch.Controls
            foreach (Control ctrl in this.pnlDgv.Controls)
            {
                //if ctrl equal dgvSearch
                if (ctrl == dgvSearch)
                {
                    //Initialize null value to DataSource of dgvSearch
                    dgvSearch.DataSource = null;
                }
            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlBottom.Controls)
            {
                //if ctrl.text is empty initialize zero value "0"
                if ((ctrl is Label && ctrl.Text != string.Empty) && (ctrl == lblTotalDebit || ctrl == lblTotalCredit
                    || ctrl == lblOperCount || ctrl == lblCurrentBalance))
                {
                    ctrl.Text = "0";
                }
                else if ((ctrl is Label && ctrl.Text != string.Empty) && (ctrl == lblCurrentStatus))//----
                {
                    ctrl.Text = "----";
                }
            }
        }

        /// <summary>
        /// void Method to Fit Width of Combobox with the max length of items of combobox
        /// </summary>
        /// <param name="combo">Name of ComboBox</param>
        /// <param name="dt">DataSource of ComboBox</param>
        /// <param name="columnName">String Column Name</param>
        void GetMaxWidthOfComboBox(ComboBox combo, DataTable dt, string columnName)
        {
            //Use Class Graphics with method CreateGraphics to Modify width of Combobox.DropDownWidth
            Graphics graph = combo.CreateGraphics();
            //Use Class SizeF which contains two points of float xFloat, yFloat
            SizeF normalSize, maxSize;
            //Set Default value for maxSize (0f, 0f)
            maxSize = new SizeF(0f, 0f);

            //Use For Loop in each row of datatable is a datasource of combobox to get Max Length of item
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // Set Value of length item in normalSize by use Method graph.MeasureString(text,Font of control)
                normalSize = graph.MeasureString(dt.Rows[i][columnName].ToString(), combo.Font);

                if (normalSize.Width > maxSize.Width)
                {
                    //Initailize value of normalSize to maxSize
                    maxSize.Width = normalSize.Width;
                    //Modify Width of Combobox DropDow by  maxSize.Width after convert from SizeF to int Implicit Conversion
                    combo.DropDownWidth = (int)maxSize.Width;
                }
            }
        }

        /// <summary>
        /// void Method to Search in SupplierAccount by SupplierIDPreBalance 
        /// To Get Previous Balance of supplier before dtpDateFrom.Value
        /// Check if Balance is Debit or Credit
        /// </summary>
        void GetPreBalanceOfSupplier()
        {
            //Declare decimal Variable to Get Previous Balance before dtpDateFrom.Value
            decimal preBalance, totalDebit = 0, totalCredit = 0;

            //Declare DataTable and Initialize Result of Search in SupplierAccount by SupplierIDPreBalance
            DataTable dt = SupAccountClass.SearchSupAccount("SearchLessDate", Convert.ToString(comboSuppliers.SelectedValue)
                                                      , "", dtpDateFrom.Value.ToString("yyyy-MM-dd"), "");

            //Use for loop to Get Total of Previous Balance before dtpDateFrom.Value
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Get Total Debit Amount
                totalDebit += Convert.ToDecimal(dt.Rows[i]["القيمة المدينة"]);
                //Get Total Debit Amount
                totalCredit += Convert.ToDecimal(dt.Rows[i]["القيمة الدائنة"]);
                //MessageBox.Show(totalDebit.ToString() + "  Credit=  " + totalCredit.ToString());
            }

            //if Balance is greater Than or equal Zero is Credit Balance +
            if (totalCredit >= totalDebit)
            {
                //Get Previous Balance 
                preBalance = totalCredit - totalDebit;

                //Initialize Value of balance to lblPreBalance.Text
                lblPreBalance.Text = preBalance.ToString();

                //Previous Balance is Credit
                lblPreviousStatus.Text = "دائن";  
            }
            //else Balance is less Than is Debit Balance -
            else
            {
                //Get Previous Balance 
                preBalance = totalDebit - totalCredit;

                //Initialize Value of balance to lblPreBalance.Text
                lblPreBalance.Text = preBalance.ToString();

                //Previous Balance is Debit
                lblPreviousStatus.Text = "مدين";

            }
        }

        /// <summary>
        /// void Method To Get Calculations Total Debit - TotalCredit - CurrentBalance of Supplier
        /// </summary>
        void GetCalCulationOfSupplier()
        {
            //(1)==>Declare three decimal Variables To Get TotalDebit - TotalCredit - CurrentBalance
            decimal totalDebit = 0, totalCredit = 0, currentBalance;

            //(2)==>Use for loop To Get TotalDebit - TotalCredit - CurrentBalance
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                //Get Total Debit Amount
                totalDebit += Convert.ToDecimal(dgvSearch.Rows[i].Cells["SupAccDebit"].Value);
                //Get Total Crebit Amount
                totalCredit += Convert.ToDecimal(dgvSearch.Rows[i].Cells["SupAccCredit"].Value);
            }

            /*(3)==> Get Calculations of total Debit - Total Credit - Count Operations of Supplier */
            //Get Count of Operations of Supplier Account
            lblOperCount.Text = dgvSearch.Rows.Count.ToString();
            //Initialize Value of totalDebit to lblTotalDebit.Text
            lblTotalDebit.Text = Convert.ToString(totalDebit);
            //Initialize Value of totalCredit to lblTotalCredit.Text
            lblTotalCredit.Text = Convert.ToString(totalCredit);

            /*(4)==> Get Current Balance of supplier */
            //if Previous balance is Debit
            if (lblPreviousStatus.Text == "مدين")
            {
                //Get Total Debit Amount = Total Debit Amount + Previous balance
                totalDebit += Convert.ToDecimal(lblPreBalance.Text);
                //CurrentBalance = totalCredit - totalDebit;
                currentBalance = totalCredit - totalDebit;
            }
            else //if Previous balance is Credit
            {
                //Get Total Crebit Amount = Total Crebit Amount + Previous balance
                totalCredit += Convert.ToDecimal(lblPreBalance.Text);
                //CurrentBalance = totalCredit - totalDebit;
                currentBalance = totalCredit - totalDebit;
            }
            //lblTotalDebit.Text = Current Balance + Previous Balance 
            lblCurrentBalance.Text = Convert.ToString(currentBalance);

            /*(5)==> Get Status of Supplier Balance */
            //Check Status of Supplier Balance
            if (currentBalance >= 0)
            {
                //lblTotalDebit.Text = Current Balance + Previous Balance 
                lblCurrentStatus.Text = "دائن";
            }
            else
            {
                //lblTotalDebit.Text = Current Balance + Previous Balance 
                lblCurrentStatus.Text = "مدين";
            }
        }

        /// <summary>
        /// void Method to fill Operation Combobox
        /// </summary>
        void FillComboOperations()
        {
            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[]
                    {
                        "إضافة رصيد أول المدة","مشتريات","مرتجع المشتريات","صرف نقدية للمورد","استلام نقدية من المورد"
                    };

            if (comboSuppliers.SelectedIndex != -1)
            {
                //Set DataSource of Combobox is strSearchItems array
                comboOperations.DataSource = strSearchItems;
                //Set SelectedIndex of item is -1 to show empty item
                comboOperations.SelectedIndex = -1;
            }
            else
            {
                //Set DataSource of Combobox is empty or null 
                comboOperations.DataSource = null;
            }
        }

        /// <summary>
        /// string Function To Return Search Key 
        /// //Supplier (SUPP) - //INVOICE Purchase (INVP) - //INVOICE Returned Purchase (INRP)
        /// //INVOICE CASH OUT (INCO) - //INVOICE CASH IN (INCI)
        /// </summary>
        /// <returns>SearchKey</returns>
        public string GetSearchKey()
        {
            string searchKey;

            switch (comboOperations.Text)
            {
                case "إضافة رصيد أول المدة"://Supplier (SUPP)
                    searchKey = "SUPP";
                    break;
                case "مشتريات"://INVOICE Purchase (INVP)
                    searchKey = "INVP";
                    break;
                case "مرتجع المشتريات"://INVOICE Returned Purchase (INRP)
                    searchKey = "INRP";
                    break;
                case "صرف نقدية للمورد": //INVOICE CASH OUT (INCO)
                    searchKey = "INCO";
                    break;
                case "استلام نقدية من المورد": //INVOICE CASH IN (INCI)
                    searchKey = "INCI";
                    break;
                default:
                    searchKey = "";
                    break;
            }
            return searchKey;
        }

        //btnNew_Click Method To Clear Controls of Form  **Done**
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

        //btnExit_Click Method To Close Form **Done**
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (SupAccountFRM != null) SupAccountFRM = null;
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

        //FRM_SupplierAccount_Load Method To Fill ComboBox By Suppliers Table **Done**
        private void FRM_SupplierAccount_Load(object sender, EventArgs e)
        {
            try
            {
                //Initialize DataSource of combo is SupplierClass.ShowSuppliersTable();
                comboSuppliers.DataSource = SupplierClass.ShowSuppliersTable();
                //Initialize DisplayMember of combo is SupplierName
                comboSuppliers.DisplayMember = "اسم المورد";
                //Initialize ValueMember of combo is SupplierID
                comboSuppliers.ValueMember = "الكود الداخلى";
                //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                GetMaxWidthOfComboBox(comboSuppliers, SupplierClass.ShowSuppliersTable(), "اسم المورد");
                //To Clear ComboBox of comboSupplier by selected index equal -1  
                comboSuppliers.SelectedIndex = -1;
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

        //comboSuppliers_TextChanged Method To Fill Combobox Operations when user change selected text of comboSuppliers
        private void comboSuppliers_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //FillComboOperations
                FillComboOperations();
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

        //comboSuppliers_KeyDown Method To SearchSupplierAccount by ComboSupplier.SelectedValue 
        private void comboSuppliers_KeyDown(object sender, KeyEventArgs e)
        {
            //If User Press on Enter Key of Keyboard and comboSuppliers.SelectedIndex is not equal -1
            if (e.KeyCode == Keys.Enter && comboSuppliers.SelectedIndex != -1)
            {
                //Recall Method of btnSearch_Click (object sender, EventArgs e);
                btnSearch_Click(sender, e);
            }
        }

        //comboOperations_KeyDown Method To SearchSupplierAccount by ComboSupplier.SelectedValue **Done**  
        private void comboOperations_KeyDown(object sender, KeyEventArgs e)
        {
            //If User Press on Enter Key of Keyboard and comboSuppliers.SelectedIndex is not equal -1
            if (e.KeyCode == Keys.Enter && comboSuppliers.SelectedIndex != -1 && comboOperations.SelectedIndex != -1)
            {
                //Recall Method of btnSearch_Click (object sender, EventArgs e);
                btnSearch_Click(sender, e);
            }
        }

        //btnSearch_Click Method To SearchSupplierAccount by ComboSupplier.SelectedValue  **Done** 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //comboSuppliers.SelectedIndex is Equal empty stop executing block code
                if (comboSuppliers.SelectedIndex == -1)
                {
                    //Set DataSource of dgvSearch is Empty or null
                    dgvSearch.DataSource = null;

                    //Warning Message Box
                    NotificationSMS.NotifyShow("يلزم اختيار المورد اولاً", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Focus on comboSuppliers
                    comboSuppliers.Focus();

                    //stop executing block code
                    return;
                }
                //comboSuppliers.SelectedIndex is Not Equal empty 
                else
                {
                    //if end date of search is Less than start date
                    if (dtpDateTo.Value < dtpDateFrom.Value)
                    {
                        //Warning Message Box
                        NotificationSMS.NotifyShow("يلزم ان يكون تاريخ النهاية أكبر من تاريخ البداية عند البحث", "تنبية",
                            FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                            FRM_Notifications.NotifyTypes.NotifyBtn);
                        //Show Notification Message in Dialog Mode
                        NotificationSMS.ShowDialog();
                        //Focus On DateTimePicker
                        dtpDateTo.Focus();
                        //stop executing block code
                        return;
                    }

                    //if ComboOperations or Operation Name is Empty
                    if (comboOperations.SelectedIndex == -1)
                    {
                        //Get Previous Balance of Supplier ==> 1
                        GetPreBalanceOfSupplier();


                        //Recall DataTable Fucation from BAL (Business Access Layer) to SearchSupplierAccount by ComboSupplier.SelectedValue
                        //Set DataTable is DataSource of DataGridView search by SupplierIDBetweenDates ==>2
                        dgvSearch.DataSource = SupAccountClass.SearchSupAccount("SearchBetweenDates", Convert.ToString(comboSuppliers.SelectedValue)
                                                                                , "", dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));

                        //Add Auto Serial of Operation To Column SupAccSerial ==>3
                        for (int i = 0; i < dgvSearch.Rows.Count; i++)
                        {
                            dgvSearch.Rows[i].Cells["SupAccSerial"].Value = i + 1;
                        }

                        //Get Calculations Total Debit -TotalCredit - CurrentBalance of Supplier ==>4
                        GetCalCulationOfSupplier();
                    }
                    else //if ComboOperations or Operation Name is not Empty 
                    {
                        //Get Previous Balance of Supplier ==>1
                        GetPreBalanceOfSupplier();

                        //Recall DataTable Fucation from BAL (Business Access Layer) to SearchSupplierAccount by ComboSupplier.SelectedValue
                        //Set DataTable is DataSource of DataGridView search by SupplierIDBetweenDates ==>2
                        dgvSearch.DataSource = SupAccountClass.SearchSupAccount("SearchOperBetweenDates", Convert.ToString(comboSuppliers.SelectedValue)
                                                                                , GetSearchKey(), dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));

                        //Add Auto Serial of Operation To Column SupAccSerial ==>3
                        for (int i = 0; i < dgvSearch.Rows.Count; i++)
                        {
                            dgvSearch.Rows[i].Cells["SupAccSerial"].Value = i + 1;
                        }

                        //Get Calculations Total Debit -TotalCredit - CurrentBalance of Supplier ==>4
                        GetCalCulationOfSupplier();
                    }
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

        //btnPrint_Click Method To Print Report of SupplierAccount **Done**
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Count Rows of dgvSearch is less than one
                if (dgvSearch.Rows.Count < 1)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("لاتوجد اى حركة داخل كشف حساب العميل ", "الطباعة",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_SupAccountViewerRpt is Form Viewer
                RPT.FRM_SupAccountViewerRpt SupAccountViewerFrm = new RPT.FRM_SupAccountViewerRpt();
                //Create New Instance From RPT.ItemsRpt is Report
                RPT.SupAccountRpt AccountReport = new RPT.SupAccountRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                SupAccountViewerFrm.crystalRptViewerSupAcc.ReportSource = AccountReport;

                ////Set Values to Parameters of Report
                //Initialize Value of Parameter field SupplierName is equal comboSuppliers.Text
                AccountReport.SetParameterValue("SupplierName", Convert.ToString(comboSuppliers.Text));
                //Initialize Value of Parameter field SupplierPreBalance is equal lblPreBalance.Text
                AccountReport.SetParameterValue("SupplierPreBalance", Convert.ToDecimal(lblPreBalance.Text));
                //Initialize Value of Parameter field SupplierPreStatus is equal lblPreviousStatus.Text
                AccountReport.SetParameterValue("SupplierPreStatus", Convert.ToString(lblPreviousStatus.Text));
                //Initialize Value of Parameter field SupplierDebit is equal Convert.ToDecimal(lblTotalDebit.Text)
                AccountReport.SetParameterValue("SupplierDebit", Convert.ToDecimal(lblTotalDebit.Text));
                //Initialize Value of Parameter field SupplierCredit is equal Convert.ToDecimal(lblTotalCredit.Text)
                AccountReport.SetParameterValue("SupplierCredit", Convert.ToDecimal(lblTotalCredit.Text));
                //Initialize Value of Parameter field SupplierCurBalance is equal Convert.ToDecimal(lblCurrentBalance.Text)
                AccountReport.SetParameterValue("SupplierCurBalance", Convert.ToDecimal(lblCurrentBalance.Text));
                //Initialize Value of Parameter field SupplierCurStatus is equal lblCurrentStatus.Text
                AccountReport.SetParameterValue("SupplierCurStatus", Convert.ToString(lblCurrentStatus.Text));
                //Initialize Value of Parameter field SupplierID is equal Convert.ToInt32(comboSuppliers.SelectedValue)
                AccountReport.SetParameterValue("@SupplierID", Convert.ToInt32(comboSuppliers.SelectedValue));
                //Initialize Value of Parameter field SearchDate1 is equal dtpDateFrom.Value.ToString("yyyy-MM-dd")
                AccountReport.SetParameterValue("@SearchDate1", dtpDateFrom.Value.ToString("yyyy-MM-dd"));
                //Initialize Value of Parameter field SearchDate2 is equal dtpDateTo.Value.ToString("yyyy-MM-dd")
                AccountReport.SetParameterValue("@SearchDate2", dtpDateTo.Value.ToString("yyyy-MM-dd"));
                //Initialize Value of Parameter field SupplierCount is equal Convert.ToString(lblOperCount.Text)
                AccountReport.SetParameterValue("SupplierCount", Convert.ToString(lblOperCount.Text));

                //Refresh CrystalReportViewer When Used SetParameterValue Method 
                SupAccountViewerFrm.crystalRptViewerSupAcc.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                SupAccountViewerFrm.ShowDialog();
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
