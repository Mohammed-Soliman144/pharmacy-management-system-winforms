using System;
using System.Collections.Generic;
using System.Collections; //To Deal With Hashtable and ArrayList
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_ResalesSearch : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_Customers Business Access Layer
        readonly BAL.CLS_Customers CustomerClass = new BAL.CLS_Customers();
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchClass = new BAL.CLS_Branches();
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoreClass = new BAL.CLS_Stores();
        //Create New Instance From BAL.CLS_ReSaleBill Business Access Layer
        readonly BAL.CLS_ReSaleBill ResaleBillClass = new BAL.CLS_ReSaleBill();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Using Object Oriented Programing to access FRM_SalesSearch Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_ResalesSearch ResaleSearchFRM;

        //Create ResaleSearchAccess_FormClosed to recall it when close form
        private static void ResaleSearchAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            ResaleSearchFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_ResalesSearch ResaleSearchAccess_Property
        {
            //used getter to return value of FRM_ResalesSearch 
            get
            {
                //if created instance or field is null
                if (ResaleSearchFRM == null)
                {
                    //Create New Instance From FRM_Items by initialize it to field
                    ResaleSearchFRM = new FRM_ResalesSearch();
                    //Generate Event of Form Closed and Delegate Method SaleSearchAccess_FormClosed to it
                    ResaleSearchFRM.FormClosed += new FormClosedEventHandler(ResaleSearchAccess_FormClosed);
                }
                //Return the value of field
                return ResaleSearchFRM;
            }
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_SalesSearch Form
        /// which is first methods are executed when open form and after InitializeComponent for Visual Design
        /// </summary>
        public FRM_ResalesSearch()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_ResalesSearch to it 
            if (ResaleSearchFRM == null) ResaleSearchFRM = this;
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
            //To Control MinimumHeight of Rows in dgv
            dgv.RowTemplate.MinimumHeight = 35;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgv.AutoGenerateColumns = false;
            ////Intialize DataSource of DGV is SupAccountClass.ShowSupAccountTable();
            //dgvHeadSearch.DataSource = SaleBillClass.ShowSaleBillTable();
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
        /// FillComboBox by Pay Methods
        /// FillComboBox by Customers
        /// FillComboBox by Branches
        /// FillComboBox by Stores
        /// </summary>
        private void FillComboBox()
        {
            try
            {
                if (comboSearchWay.SelectedIndex == 1) //نوع الفاتورة
                {
                    comboSearchKey.Items.Clear();

                    string[] comboItems = new string[] { "نقدى", "آجل", "دفعات نقدية" };

                    comboSearchKey.Items.AddRange(comboItems);
                }
                else if (comboSearchWay.SelectedIndex == 3) //اسم المخزن
                {
                    //Initialize DataSource of combo is CustomerClass.ShowCustomersTable();
                    comboSearchKey.DataSource = StoreClass.ShowStoresTable();
                    //Initialize DisplayMember of combo is CustomerName
                    comboSearchKey.DisplayMember = "اسم المخزن";
                    //Initialize ValueMember of combo is CustomerID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, StoreClass.ShowStoresTable(), "اسم المخزن");
                    //To Clear ComboBox of comboCustomer by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 4) //اسم الفرع
                {
                    //Initialize DataSource of combo is CustomerClass.ShowCustomersTable();
                    comboSearchKey.DataSource = BranchClass.ShowBranchesTable();
                    //Initialize DisplayMember of combo is CustomerName
                    comboSearchKey.DisplayMember = "اسم الفرع";
                    //Initialize ValueMember of combo is CustomerID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, BranchClass.ShowBranchesTable(), "اسم الفرع");
                    //To Clear ComboBox of comboCustomer by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 5) //اسم العميل
                {
                    //Initialize DataSource of combo is CustomerClass.ShowCustomersTable();
                    comboSearchKey.DataSource = CustomerClass.ShowCustomersTable();
                    //Initialize DisplayMember of combo is CustomerName
                    comboSearchKey.DisplayMember = "اسم العميل";
                    //Initialize ValueMember of combo is CustomerID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, CustomerClass.ShowCustomersTable(), "اسم العميل");
                    //To Clear ComboBox of comboCustomer by selected index equal -1  
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
                //Initialize null value to datasource of datagridview
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
        /// void method to Get Calculations of Sales
        /// </summary>
        private void GetCalculations()
        {
            double totalG = 0, totalTax = 0;
            //Use for Loop To Get Calculations
            for (int i = 0; i < dgvDetailsSearch.Rows.Count; i++)
            {
                //Get ItemTotalSalePrice
                totalG += Convert.ToDouble(dgvDetailsSearch.Rows[i].Cells["SaleDetailReSaleTotalSale"].Value);
                //Get ItemTotalTax
                totalTax += Convert.ToDouble(dgvDetailsSearch.Rows[i].Cells["SaleDetailTotalTax"].Value);
            }
            //Get Count of SaleBill Invoice
            lblSaleBillCount.Text = dgvHeadSearch.Rows.Count.ToString();
            //Get Count of items in SaleBill Invoice
            lblItemCount.Text = dgvDetailsSearch.Rows.Count.ToString();

            lblSaleBillTotalG.Text = totalG.ToString();
            lblTotalTax.Text = totalTax.ToString();
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
                if (ResaleSearchFRM != null) ResaleSearchFRM = null;
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

        //btnSearch_Click Method To SearchCustomerAccount by ComboCustomer.SelectedValue  **Done** 
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

                        case "نوع الفاتورة":
                            //Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            //Set DataTable is DataSource of DataGridView search by SaleBillPayType
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("SaleBillPayType", comboSearchKey.Text, false, "", ""), "كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("StoreName", comboSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("BranchName", comboSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم العميل":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CustomerFullName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("CustomerFullName", comboSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ItemBarcode1", txtSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم الصنف":
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ItemName", txtSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "الشركة المنتجة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CompanyName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("CompanyName", txtSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "المجموعة العلمية":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by GroupName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("GroupName", txtSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;
                            //الشركة المنتجة
                           //لمجموعة العلمية
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
                        case "نوع الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SaleBillPayType
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("SaleBillPayType", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "تاريخ الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by SaleBillInvoiceDate
                            // Set DataTable is DataSource of DataGridView search by SaleBillInvoiceDate
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ReSaleDate", "", true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("StoreName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("BranchName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم العميل":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CustomerFullName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("CustomerFullName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ItemBarcode1", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ItemName", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "الشركة المنتجة"://+dtp
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CompanyName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("CompanyName", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
                            break;

                        case "المجموعة العلمية"://+dtp
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by GroupName
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("GroupName", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd")),"كود الداخلى للفاتورة المرتجع");
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
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SaleBillCustomID
                            dgvHeadSearch.DataSource = RemoveDuplicatedRows(ResaleBillClass.SearchReSaleBill("ReSaleCustomID", txtSearchKey.Text, false, "", ""),"كود الداخلى للفاتورة المرتجع");
                            break;

                        default:
                            break;
                    }
                    //clear textbox
                    txtSearchKey.Clear();
                    //Focus on txtSearchKey
                    txtSearchKey.Focus();
                }

                AddNewRows(dgvHeadSearch, "ResaleSerial");

                //If No any results in dgv
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

                    lblItemCount.Text = "0";
                    lblSaleBillCount.Text = "0";
                    lblSaleBillTotalG.Text = "0";
                    lblTotalTax.Text = "0";

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

        //btnPrint_Click Method To Print Report of CustomerAccount 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //If No any results in dgv
                if (dgvHeadSearch.Rows.Count  == 0)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("لا توجد اى نتائج حتى يتم طباعتها !!!!", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_ResalesViewerRpt is Form Viewer
                RPT.FRM_ResalesViewerRpt ResalePillViewerFrm = new RPT.FRM_ResalesViewerRpt();
                //Create New Instance From RPT.ResalesRpt is Report
                RPT.ResalesRpt ResalePillReport = new RPT.ResalesRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                ResalePillViewerFrm.crystalRptViewerResales.ReportSource = ResalePillReport;
                ////Set Values to Parameters of Report
                //Initialize Value of Parameter field SearchKey is equal Convert.ToInt32(lblTotalSale.Text.Remove(0,5)))
                ResalePillReport.SetParameterValue("@SearchKey", Convert.ToInt32(dgvHeadSearch.CurrentRow.Cells["ReSaleID"].Value));

                //Refresh crystalRptViewerResales
                ResalePillViewerFrm.crystalRptViewerResales.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                ResalePillViewerFrm.ShowDialog();
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
            if (comboSearchWay.SelectedIndex == 0 || comboSearchWay.SelectedIndex == 6)
            {
                if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                chBoxSearchDate.Visible = false;
                lblStartDate.Visible = false;
                chBoxSearchDate.Visible = false;
                dtpDateFrom.Visible = false;
                lblEndDate.Visible = false;
                dtpDateTo.Visible = false;
            }
            else if (comboSearchWay.SelectedIndex == 2)
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

                case 1: //نوع الفاتورة
                    //Set null Value to DataSource of comboSearchKey
                    if (comboSearchKey.Visible == false) comboSearchKey.Visible = true;
                    comboSearchKey.DataSource = null;
                    comboSearchKey.BringToFront();
                    FillComboBox();
                    break;

                case 3: //اسم المخزن
                    //Set null Value to DataSource of comboSearchKey
                    if (comboSearchKey.Visible == false) comboSearchKey.Visible = true;
                    comboSearchKey.DataSource = null;
                    comboSearchKey.BringToFront();
                    FillComboBox();
                    break;

                case 4: //اسم الفرع
                    //Set null Value to DataSource of comboSearchKey
                    if (comboSearchKey.Visible == false) comboSearchKey.Visible = true;
                    comboSearchKey.DataSource = null;
                    comboSearchKey.BringToFront();
                    FillComboBox();
                    break;

                case 5: //اسم المورد
                    //Set null Value to DataSource of comboSearchKey
                    if (comboSearchKey.Visible == false) comboSearchKey.Visible = true;
                    comboSearchKey.DataSource = null;
                    comboSearchKey.BringToFront();
                    FillComboBox();
                    break;

                case 6: //رقم فاتورة المورد
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    comboSearchKey.Visible = false;
                    dtpDateFrom.Enabled = false;
                    dtpDateTo.Enabled = false;
                    break;

                case 7: //باركود الصنف
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 8: //اسم الصنف
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 9: //الشركة المنتجة
                    if (txtSearchKey.Visible == false) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 10: //المجموعة العلمية
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

        //dgvSearch_CellContentClick Method to show selected SaleBill or print selected Customer CellContentClick **Done**
        private void dgvHeadSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and index of button column Show btn is 0
                if (e.RowIndex >= 0 && e.ColumnIndex == 14)
                {
                    // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                    // Set DataTable is DataSource of DataGridView search by ReSaleID
                    dgvDetailsSearch.DataSource = ResaleBillClass.SearchReSaleBill("ReSaleID", dgvHeadSearch.CurrentRow.Cells["ReSaleID"].Value.ToString(), false, "", "");

                    //Add Serial To SaleDetailSerial of dgvDetailsSearch
                    AddNewRows(dgvDetailsSearch, "ReSaleDetailSerial");
                    //GetCalculations
                    GetCalculations();
                }
                //if the index of row greater than or equal zero and index of button column Print btn is 
                else if (e.RowIndex >= 0 && e.ColumnIndex == 15)
                {
                    //Recall Event btnPrint_Click To Print Resale Report
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

        //dgvHeadSearch_ColumnHeaderMouseClick Method used to re order rows of dgvDetailsSearch if user arrange by clik on column
        private void dgvHeadSearch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Add Serial Number to column SaleBillSerial of dgvHeadSearch
                if (dgvHeadSearch.Rows.Count > 0)
                {
                    AddNewRows(dgvHeadSearch, "ResaleSerial");
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
       
        //dgvDetailsSearch_ColumnHeaderMouseClick Method used to re order rows of dgvDetailsSearch if user arrange by clik on column
        private void dgvDetailsSearch_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //Add Serial Number to column SaleDetailID of dgvDetailsSearch
                if (dgvDetailsSearch.Rows.Count > 0)
                {
                    AddNewRows(dgvDetailsSearch, "ReSaleDetailSerial");
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
