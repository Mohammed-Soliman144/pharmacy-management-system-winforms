using System;
using System.Collections;
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
    public partial class FRM_RepurchasesSearch : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_Suppliers Business Access Layer
        readonly BAL.CLS_Suppliers SupplierClass = new BAL.CLS_Suppliers();
        //Create New Instance From BAL.CLS_ReBuyBill Business Access Layer
        readonly BAL.CLS_ReBuyBill ReBuyBillClass = new BAL.CLS_ReBuyBill();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Using Object Oriented Programing to access FRM_SupplierAccount Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_RepurchasesSearch RepurchaseSearchFRM;

        //Create SupAccountAccess_FormClosed to recall it when close form
        private static void SupAccountAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            RepurchaseSearchFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_RepurchasesSearch RepurchaseSearchAccess_Property
        {
            //used getter to return value of FRM_SupplierAccount 
            get
            {
                //if created instance or field is null
                if (RepurchaseSearchFRM == null)
                {
                    //Create New Instance From FRM_Items by initialize it to field
                    RepurchaseSearchFRM = new FRM_RepurchasesSearch();
                    //Generate Event of Form Closed and Delegate Method SupAccountAccess_FormClosed to it
                    RepurchaseSearchFRM.FormClosed += new FormClosedEventHandler(SupAccountAccess_FormClosed);
                }
                //Return the value of field
                return RepurchaseSearchFRM;
            }
        }
        #endregion

        /// <summary>
        /// Constructor of FRM_RepurchasesSearch Form
        /// which is first methods are executed when open form and after InitializeComponent for Visual Design
        /// </summary>
        public FRM_RepurchasesSearch()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_RepurchasesSearch to it 
            if (RepurchaseSearchFRM == null) RepurchaseSearchFRM = this;
            //Set Properties OF DataGridView of dgvHeadSearch (receiving one Argument)
            InitializeDGV(dgvHeadSearch);
            //Set Properties OF DataGridView of dgvDetailsSearch (receiving one Argument)
            InitializeDGV(dgvDetailsSearch);
            //ClearControls();
            ClearControls();
        }

        #region Methods and Functions

        //Set Properties OF DataGridView
        private void InitializeDGV(DataGridView dgv)
        {
            // Used Wizard of DataGridview To Set Columns of DGV And Set DataPropertyName by Alias Name in SP 
            // without Quation Mark 
            //Intialize MultiSelect of DGV is False
            dgv.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgv.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgv.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgv.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgv.AllowUserToResizeColumns = false;
            //To Control Of MinimumHeight of Rows in dgv
            dgv.RowTemplate.MinimumHeight = 35;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgv.AutoGenerateColumns = false;
            ////Intialize DataSource of DGV is SupAccountClass.ShowSupAccountTable();
            //dgvHeadSearch.DataSource = BuyBillClass.ShowBuyBillTable();
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
        /// FillComboBox by Suppliers
        /// </summary>
        private void FillComboBox()
        {
            try
            {
                if (comboSearchWay.SelectedIndex == 2) //اسم المورد
                {
                    //Initialize DataSource of combo is SupplierClass.ShowSuppliersTable();
                    comboSearchKey.DataSource = SupplierClass.ShowSuppliersTable();
                    //Initialize DisplayMember of combo is SupplierName
                    comboSearchKey.DisplayMember = "اسم المورد";
                    //Initialize ValueMember of combo is SupplierID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, SupplierClass.ShowSuppliersTable(), "اسم المورد");
                    //To Clear ComboBox of comboSupplier by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
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

        /// <summary>
        /// DataTable Function To Remove All Duplicated Rows From DataTable Search
        /// </summary>
        /// <param name="dt">DataTable Search</param>
        /// <param name="colName">Unique colName</param>
        /// <returns></returns>
        private DataTable RemoveDuplicatedRows(DataTable dt, string colName)
        {
            //Declare Hashtable to check if unique columnName (id) is duplicated or not
            //Using System.Collection To Create New Instance from Hashtable and ArrayList
            //So Add all unique column to Hashtable
            Hashtable uniqueTable = new Hashtable();

            //Using System.Collection To Create new instance from ArrayList to add all duplicated rows
            ArrayList duplicatedList = new ArrayList();

            //Use Foreach loop to search in row of DataTabe dt
            foreach (DataRow drow in dt.Rows)
            {
                //If Hashtable is not contains DataRow[columnName] so is unique row
                if (!uniqueTable.Contains(drow[colName]))
                {
                    //Add unique Column to Hashtable.Add(Object is Key => DataRow[columnName], Object is Value => null)
                    uniqueTable.Add(drow[colName], string.Empty);
                }
                //else is duplicated row so Add to ArrayList
                else duplicatedList.Add(drow);
            }


            //Use Foreach loop To Remove All Duplicated rows in ArrayList from dt
            foreach (DataRow row in duplicatedList)
            {
                //Remove All Duplicated Rows In ArrayList From dt
                dt.Rows.Remove(row);
            }

            //Return DataTable After Remove Duplicated Rows
            return dt;
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //loop in all control in side this.pnlSearch.Controls
            foreach (Control ctrl in this.pnlSearch.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
                else if (ctrl is DateTimePicker)
                {
                    dtpDateFrom.Value = DateTime.Now;
                    dtpDateTo.Value = DateTime.Now;
                }
                else if (ctrl is CheckBox) chBoxSearchDate.Checked = false;
            }
            //loop in all control in side this.pnlDgv.Controls
            foreach (Control ctrl in this.pnlDgv.Controls)
            {

                dgvHeadSearch.DataSource = null;
                dgvDetailsSearch.DataSource = null;

            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlBottom.Controls)
            {
                if (ctrl is Label && ctrl.Name.StartsWith("lbl"))
                {
                    ctrl.Text = "0";
                }
            }
        }

        /// <summary>
        /// Add Serial Number to datagridview
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="colName">ColumnName</param>
        private void AddNewRows(DataGridView dgv, string colName)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[colName].Value = i + 1;
            }
        }

        /// <summary>
        /// void method to check validation of datetimepicker when user is searching.
        /// </summary>
        private void CheckValidation()
        {
            if (chBoxSearchDate.Checked == true && dtpDateTo.Value < dtpDateFrom.Value)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("يلزم ان يكون تاريخ البداية أقل من او يساوى تاريخ النهاية", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Focus on DataTimePicker
                dtpDateFrom.Focus();

                //Stop to executing block code
                return;
            }
        }

        /// <summary>
        /// void method to Get Calculations of Purchases
        /// </summary>
        private void GetCalculations()
        {
            double totalB = 0, totalG = 0;
            //Use for Loop To Get Calculations
            for (int i = 0; i < dgvDetailsSearch.Rows.Count; i++)
            {
                //Get BuyBillTotalBuyPrice
                totalB += Convert.ToDouble(dgvDetailsSearch.Rows[i].Cells["BuyDetailReBuyTotalBuy"].Value);
                //Get BuyBillTotalSalePrice
                totalG += Convert.ToDouble(dgvDetailsSearch.Rows[i].Cells["BuyDetailReBuyTotalSale"].Value);
            }
            //Get Count of BuyBill Invoice
            lblReBuyBillCount.Text = dgvHeadSearch.Rows.Count.ToString();
            //Get Count of items in BuyBill Invoice
            lblReBuyItemCount.Text = dgvDetailsSearch.Rows.Count.ToString();

            lblReBuyBillTotalB.Text = totalB.ToString();
            lblReBuyBillTotalG.Text = totalG.ToString();

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
                if (RepurchaseSearchFRM != null) RepurchaseSearchFRM = null;
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

        //btnSearch_Click Method To SearchSupplierAccount by ComboSupplier.SelectedValue  **Done** 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // check validation of datetimepicker when user is searching.
                CheckValidation();

                // if chBoxSearchDate.Visible is true and chBoxSearchDate.Checked is false ==> 1
                if (chBoxSearchDate.Visible == true && chBoxSearchDate.Checked == false)
                {
                    //switch conditional statement(string) { Case "valueofstring": break; }
                    //Search based on ColumnName
                    switch (comboSearchWay.Text)
                    {
                        case "اسم المورد":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SupplierFullName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("SupplierFullName", comboSearchKey.Text, false, "", ""), "رقم الفاتورة مرتجع الشراء");
    
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("ItemBarcode1", txtSearchKey.Text, false, "", ""), "رقم الفاتورة مرتجع الشراء");
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("ItemName", txtSearchKey.Text, false, "", ""), "رقم الفاتورة مرتجع الشراء");
                            break;

                        default:
                            break;
                    }
                    //clear textbox
                    txtSearchKey.Clear();
                    //Focus on txtSearchKey
                    txtSearchKey.Focus();
                }
               // if chBoxSearchDate.Visible is true and chBoxSearchDate.Checked is true ==> 2
               else if (chBoxSearchDate.Visible == true && chBoxSearchDate.Checked == true)
               {
                    //switch conditional statement(string) { Case "valueofstring": break; }
                    //Search based on ColumnName
                    switch (comboSearchWay.Text)
                    {
                        case "اسم المورد":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search ReBuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SupplierFullName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("SupplierFullName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")), "رقم الفاتورة مرتجع الشراء");

                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("ItemBarcode1", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")), "رقم الفاتورة مرتجع الشراء");
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("ItemName", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")), "رقم الفاتورة مرتجع الشراء");
                            break;

                        case "تاريخ الفاتورة"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("RebuyDate", "", true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")), "رقم الفاتورة مرتجع الشراء");
                            break;

                        default:
                            break;
                    }
                    //clear textbox
                    txtSearchKey.Clear();
                    //Focus on txtSearchKey
                    txtSearchKey.Focus();
               }
               // if chBoxSearchDate.Visible is false ==> 3
               else if (chBoxSearchDate.Visible == false)
               {
                    //switch conditional statement(string) { Case "valueofstring": break; }
                    //Search based on ColumnName
                    switch (comboSearchWay.Text)
                    {
                        case "كود الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BuyBillCustomID
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ReBuyBillClass.SearchReBuyBill("ReBuyCustomID", txtSearchKey.Text, false, "", ""), "رقم الفاتورة مرتجع الشراء");
                            break;

                      

                        default:
                            break;
                    }
                    //clear textbox
                    txtSearchKey.Clear();
                    //Focus on txtSearchKey
                    txtSearchKey.Focus();
                }

                //Add Serial Number to dgvRepurchases with using for loop
                AddNewRows(dgvHeadSearch, "ReBuySerial");

                //If dgvRepurchases.Rows.Count is equal Zero
                if (dgvHeadSearch.Rows.Count == 0)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("لا توجد اى نتائج متطابقة", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Initialize null value to dgvHeadSearch
                    dgvHeadSearch.DataSource = null;
                    //Initialize null value to dgvDetailsSearch
                    dgvDetailsSearch.DataSource = null;

                    lblReBuyBillCount.Text = "0";
                    lblReBuyItemCount.Text = "0";
                    lblReBuyBillTotalG.Text = "0";
                    lblReBuyBillTotalB.Text = "0";

                    //Stop to executing block code
                    return;
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

        //btnPrint_Click Method To Print Report of RepurchaseBill
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_RepurchasesViewerRpt is Form Viewer
                RPT.FRM_RepurchasesViewerRpt ReBuyPillViewerFrm = new RPT.FRM_RepurchasesViewerRpt();
                //Create New Instance From RPT.RepurchasesRpt is Report
                RPT.RepurchasesRpt ReBuyPillReport = new RPT.RepurchasesRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                ReBuyPillViewerFrm.crystalRptViewerRepurchases.ReportSource = ReBuyPillReport;
                ////Set Values to Parameters of Report
                //Initialize Value of Parameter field SearchKey is equal Convert.ToInt32(lblTotalSale.Text.Remove(0,5)))
                ReBuyPillReport.SetParameterValue("@SearchKey", Convert.ToInt32(dgvHeadSearch.CurrentRow.Cells["ReBuyID"].Value));

                //Refresh crystalRptViewerRepurchases
                ReBuyPillViewerFrm.crystalRptViewerRepurchases.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                ReBuyPillViewerFrm.ShowDialog();
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

        //chBoxSearchDate_CheckedChanged Method To Change enabled of DateTimePicker **Done**
        private void chBoxSearchDate_CheckedChanged(object sender, EventArgs e)
        {
            //Checked of chBoxSearchDate equal true
            if (chBoxSearchDate.Checked == true)
            {
                dtpDateFrom.Enabled = true;
                dtpDateTo.Enabled = true;
            }
            else //Checked of chBoxSearchDate equal false
            {
                dtpDateFrom.Enabled = false;
                dtpDateTo.Enabled = false;
            }
        }

        //comboSearchWay_SelectedIndexChanged Method To determine the way of search **Done**
        private void comboSearchWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSearchWay.SelectedIndex == 0 || comboSearchWay.SelectedIndex == 3)
            {
                if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                chBoxSearchDate.Visible = false;
                lblStartDate.Visible = false;
                chBoxSearchDate.Visible = false;
                dtpDateFrom.Visible = false;
                lblEndDate.Visible = false;
                dtpDateTo.Visible = false;
            }
            else if (comboSearchWay.SelectedIndex == 1)
            {
                txtSearchKey.Visible = false;
                comboSearchKey.Visible = false;
                chBoxSearchDate.Visible = true;
                dtpDateFrom.Visible = true;
                lblEndDate.Visible = true;
                dtpDateTo.Visible = true;
            }
            else
            {
                //txtSearchKey.Visible = true;
                comboSearchKey.Visible = true;
                chBoxSearchDate.Visible = true;
                lblStartDate.Visible = true;
                dtpDateFrom.Visible = true;
                lblEndDate.Visible = true;
                dtpDateTo.Visible = true;
            }
            //Use Switch Statement (certeria which are evaulated equal comboSearchWay.SelectedIndex)
            switch (comboSearchWay.SelectedIndex)
            {
                case 0: //كود الفاتورة
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 2: //اسم المخزن
                    //Set null Value to DataSource of comboSearchKey
                    if (comboSearchKey.Visible == false) comboSearchKey.Visible = true;
                    comboSearchKey.DataSource = null;
                    comboSearchKey.BringToFront();
                    FillComboBox();
                    break;

                case 3: //باركود الصنف
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 4: //اسم الصنف
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                default:
                    break;
            }
        }

        //comboSearchKey_KeyDown Method To Recall Method of btnSearch_Click(sender, e) **Done**
        private void comboSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if e.KeyCode equal Enter or if user Press on Enter Key
                if (e.KeyCode == Keys.Enter && comboSearchKey.SelectedIndex != -1)
                {
                    //Recall Method of btnSearch_Click(sender, e)
                    btnSearch_Click(sender, e);
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

        //txtSearchKey_KeyDown Method To Recall Method of btnSearch_Click(sender, e) **Done**
        private void txtSearchKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if e.KeyCode equal Enter or if user Press on Enter Key
                if (e.KeyCode == Keys.Enter && txtSearchKey.Text != string.Empty)
                {
                    //Recall Method of btnSearch_Click(sender, e)
                    btnSearch_Click(sender, e);
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

        //dgvSearch_CellContentClick Method to show selected BuyBill or print selected Supplier CellContentClick **Done**
        private void dgvHeadSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Show btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 10)
                {
                    // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                    // Set DataTable is DataSource of DataGridView search by ReBuyID
                    dgvDetailsSearch.DataSource = ReBuyBillClass.SearchReBuyBill("ReBuyID", dgvHeadSearch.CurrentRow.Cells["ReBuyID"].Value.ToString(), false, "", "");
                    //Add Serial Number to dgvRepurchases with using for loop
                    AddNewRows(dgvDetailsSearch, "BuyDetailSerial");
                    //Get Calculations of Rebuy Bill
                    GetCalculations();
                }
                //if the index of row greater than or equal zero and index of button column Print btn is 
                else if (e.RowIndex >= 0 && e.ColumnIndex == 11)
                {
                    //Recall btnPrint_Click (sender, e); To Print RepurchaseBill
                    btnPrint_Click(sender, e);
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
