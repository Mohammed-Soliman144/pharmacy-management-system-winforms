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


namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Repurchases : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_Suppliers Business Access Layer
        readonly BAL.CLS_Suppliers SupplierClass = new BAL.CLS_Suppliers();
        //Create New Instance From BAL.CLS_SupplierAccount Business Access Layer
        readonly BAL.CLS_SupplierAccount SupplierAccountClass = new BAL.CLS_SupplierAccount();
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchClass = new BAL.CLS_Branches();
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoreClass = new BAL.CLS_Stores();
        //Create New Instance From BAL.CLS_Items Business Access Layer
        readonly BAL.CLS_Items ItemClass = new BAL.CLS_Items();
        //Create New Instance From BAL.CLS_ItemOperations Business Access Layer
        readonly BAL.CLS_ItemOperations OperationClass = new BAL.CLS_ItemOperations();
        //Create New Instance From BAL.CLS_BuyBill Business Access Layer
        readonly BAL.CLS_BuyBill BuyBillClass = new BAL.CLS_BuyBill();
        //Create New Instance From BAL.CLS_BuyDetails Business Access Layer
        readonly BAL.CLS_BuyDetails BuyDetailsClass = new BAL.CLS_BuyDetails();
        //Create New Instance From BAL.CLS_ReBuyBill Business Access Layer
        readonly BAL.CLS_ReBuyBill ReBuyBillClass = new BAL.CLS_ReBuyBill();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Using Object Oriented Programing to access FRM_Repurchases Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Repurchases RepurchaseFRM;

        //Create RepurchaseAccess_FormClosed to recall it when close form
        private static void RepurchaseAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            RepurchaseFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Repurchases RepurchaseAccess_Property
        {
            //used getter to return value of FRM_Repurchases 
            get
            {
                //if created instance or field is null
                if (RepurchaseFRM == null)
                {
                    //Create New Instance From FRM_Repurchases by initialize it to field
                    RepurchaseFRM = new FRM_Repurchases();
                    //Generate Event of Form Closed and Delegate Method RepurchaseAccess_FormClosed to it
                    RepurchaseFRM.FormClosed += new FormClosedEventHandler(RepurchaseAccess_FormClosed);
                }
                //Return the value of field
                return RepurchaseFRM;
            }
        }
        #endregion

        /// <summary>
        /// Constructor of FRM_Repurchases Form
        /// which is first methods are executed when open form and after InitializeComponent for Visual Design
        /// </summary>
        public FRM_Repurchases()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Repurchases to it 
            if (RepurchaseFRM == null) RepurchaseFRM = this;
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
            dgvRepurchases.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvRepurchases.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvRepurchases.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvRepurchases.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvRepurchases.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvRepurchases.AllowUserToResizeColumns = false;
            //To Control Of MinimumHeight of Rows in dgv
            dgvRepurchases.RowTemplate.MinimumHeight = 35;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvRepurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvRepurchases.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvRepurchases.AutoGenerateColumns = false;
            ////Intialize DataSource of DGV is BuyBillClass.ShowBuyBillTable();
            //dgvRepurchases.DataSource = BuyBillClass.ShowBuyBillTable();
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
        /// FillComboBox by Suppliers
        /// FillComboBox by Branches
        /// FillComboBox by Stores
        /// FillComboBox by Items
        /// </summary>
        private void FillComboBox()
        {
            try
            {
                if (comboSearchWay.SelectedIndex == 1) //نوع الفاتورة
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Clear Items of comboBox
                    comboSearchKey.Items.Clear();

                    string[] comboItems = new string[] { "نقدى", "آجل", "دفعات نقدية" };

                    comboSearchKey.Items.AddRange(comboItems);
                }
                else if (comboSearchWay.SelectedIndex == 3) //اسم المخزن
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is StoreClass.ShowStoresTable();
                    comboSearchKey.DataSource = StoreClass.ShowStoresTable();
                    //Initialize DisplayMember of combo is  StoreName
                    comboSearchKey.DisplayMember = "اسم المخزن";
                    //Initialize ValueMember of combo is  StoreID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, StoreClass.ShowStoresTable(), "اسم المخزن");
                    //To Clear ComboBox of comboSearchKey by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 4) //اسم الفرع
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is BranchClass.ShowBranchesTable();
                    comboSearchKey.DataSource = BranchClass.ShowBranchesTable();
                    //Initialize DisplayMember of combo is BranchName
                    comboSearchKey.DisplayMember = "اسم الفرع";
                    //Initialize ValueMember of combo is BranchID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, BranchClass.ShowBranchesTable(), "اسم الفرع");
                    //To Clear ComboBox of comboSearchKey by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 6) //اسم المورد
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is SupplierClass.ShowSuppliersTable();
                    comboSearchKey.DataSource = SupplierClass.ShowSuppliersTable();
                    //Initialize DisplayMember of combo is SupplierName
                    comboSearchKey.DisplayMember = "اسم المورد";
                    //Initialize ValueMember of combo is SupplierID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, SupplierClass.ShowSuppliersTable(), "اسم المورد");
                    //To Clear ComboBox of comboSearchKey by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 8) //اسم الصنف
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is SupplierClass.ShowItemsTable();
                    comboSearchKey.DataSource = ItemClass.ShowItemsTable();
                    //Initialize DisplayMember of combo is ItemName
                    comboSearchKey.DisplayMember = "اسم الصنف";
                    //Initialize ValueMember of combo is ItemID
                    comboSearchKey.ValueMember = "كود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, ItemClass.ShowItemsTable(), "اسم الصنف");
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
                dgvRepurchases.DataSource = null;
            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlBottom.Controls)
            {
                if (ctrl is Label && ctrl.Name.StartsWith("lbl"))
                {
                    ctrl.Text = "0";
                }
                else if (ctrl is TextBox && ctrl.Name.StartsWith("txt"))
                {
                    ctrl.Text = "0";
                    txtRebuyPaid.ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// Void Method To Add Serial Number to dgvRepurchases with using for loop
        /// </summary>
        private void AddNewRows()
        {
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                dgvRepurchases.Rows[i].Cells["BuyDetailSerial"].Value = i + 1;
                dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value = 0;//ItemBarcode
                dgvRepurchases.Rows[i].Cells["RepurchaseBuyPrice"].Value = dgvRepurchases.Rows[i].Cells["BuyDetailItemBuyPrice"].Value; //RepurchaseBuyPrice
                dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Value = 0;//RepurchaseTotalBuyPrice
                dgvRepurchases.Rows[i].Cells["RepurchaseNotes"].Value = "لا توجد";//RepurchaseNotes
            }
        }

        /// <summary>
        /// void method to check validation of datetimepicker when user is searching.
        /// </summary>
        private void CheckDateOfSearchValidation()
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
        /// void method to Get Calculations of Repurchases.
        /// </summary>
        private void GetCalculations()
        {
            double totalB = 0, totalG = 0;
            int countOfReturnItems = 0;

            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                // IF ReBuyBillID of Item is equal DBNull.Value Item Rebuy Quantity from it or ReBuyItemStatus is false
                if (dgvRepurchases.Rows[i].Cells["ReBuyBillID"].Value == DBNull.Value && (Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //Get Count Rebuy Items
                        countOfReturnItems += 1;
                        //Get RepurchaseTotalBuyPrice
                        dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Value = Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseBuyPrice"].Value) * Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value);
                        //Get RebuytotalBuyPrice
                        totalB += Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseBuyPrice"].Value) * Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value);
                        //Get RebuytotalSalePrice
                        totalG += Convert.ToDouble(dgvRepurchases.Rows[i].Cells["BuyDetailItemSalePrice"].Value) * Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value);
                    }
                }
            }

            lblRebuyItemCount.Text = countOfReturnItems.ToString();
            lblRebuyTotalBuyPrice.Text = totalB.ToString();
            lblRebuyTotalSalePrice.Text = totalG.ToString();
            lblRebuyRequired.Text = totalB.ToString();
            lblRebuyRemain.Text = (totalB - Convert.ToDouble(txtRebuyPaid.Text)).ToString();
        }

        /// <summary>
        /// Check if RepurchaseQty is Less Than or Equal BuyDetailBuyQuantity
        /// CheckValidation of RebuyItems To Permit user To use it
        /// </summary>
        private void CheckRebuyQtyValidation()
        {
            // IF Item Rebuy Quantity from it or ReBuyItemStatus is true
            if ((Boolean)dgvRepurchases.CurrentRow.Cells["ReBuyItemStatus"].Value == true)
            {
                // Warning Message Box
                NotificationSMS.NotifyShow("هذا الصنف تم ارجاعة من قبل", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Get RebuyItems
                //Initialize Value Of RepurchaseQty by Search in BuyBillDetails Table
                dgvRepurchases.CurrentRow.Cells["RepurchaseQty"].Value = Convert.ToInt32(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.CurrentRow.Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["الكمية المرتجعة من الصنف"]);
                //Initialize Value Of RepurchaseTotalBuyPrice by Search in BuyBillDetails Table
                dgvRepurchases.CurrentRow.Cells["RepurchaseTotalBuyPrice"].Value = Convert.ToInt32(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.CurrentRow.Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["اجمالى الصنف المرتجع بسعر الشراء"]);
                //Initialize Value Of RepurchaseNotes by Search in BuyBillDetails Table
                dgvRepurchases.CurrentRow.Cells["RepurchaseNotes"].Value = Convert.ToString(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.CurrentRow.Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["ملاحظات الصنف المرتجع"]);

                //Stop Execute Block Code
                return;
            }
            // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
            else
            {
                if (Convert.ToInt32(dgvRepurchases.CurrentRow.Cells["RepurchaseQty"].Value) > Convert.ToInt32(dgvRepurchases.CurrentRow.Cells["BuyDetailBuyQuantity"].Value))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("يلزم ان تكون الكمية المرتجعة أقل من او تساوى الكمية المشتراة", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Change Rebuy Qty is equal or less than BuyDetailBuyQuantity
                    dgvRepurchases.CurrentRow.Cells["RepurchaseQty"].Value = dgvRepurchases.CurrentRow.Cells["BuyDetailBuyQuantity"].Value;

                    //Stop Execute Block Code
                    return;
                }
            }
        }

        /// <summary>
        /// GetRebuyItems To Check If Item Rebuy Quantity from it
        /// Then Get RepurchaseQty - RepurchaseTotalBuyPrice - RepurchaseNotes
        /// </summary>
        private void GetRebuyQtyItems()
        {
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                //Use Casting or Explicit Conversion التحويل غير ضمنى او صريح (DataType want which is need variable convert to it)
                /// IF ReBuyBillID of Item is Not equal DBNull.Value Item Rebuy Quantity from it or ReBuyItemStatus is true
                if (dgvRepurchases.Rows[i].Cells["ReBuyBillID"].Value != DBNull.Value && (Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == true)
                {
                    //Initialize Value Of RepurchaseQty by Search in BuyBillDetails Table
                    dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value = Convert.ToInt32(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.Rows[i].Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["الكمية المرتجعة من الصنف"]);
                    //Initialize Value Of RepurchaseTotalBuyPrice by Search in BuyBillDetails Table
                    dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Value = Convert.ToInt32(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.Rows[i].Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["اجمالى الصنف المرتجع بسعر الشراء"]);
                    //Initialize Value Of RepurchaseNotes by Search in BuyBillDetails Table
                    dgvRepurchases.Rows[i].Cells["RepurchaseNotes"].Value = Convert.ToString(BuyDetailsClass.SearchBuyBillDetails("BuyDetailID", dgvRepurchases.Rows[i].Cells["BuyDetailID"].Value.ToString(), false, "", "").Rows[0]["ملاحظات الصنف المرتجع"]);
                }
            }
        }

        /// <summary>
        /// Use For loop in all rows of datagridview to change color of all columns
        /// if use dgv.Columns["ColumnName"].DefaultCellStyle.BackColor Or ForeColor = Color.Yellow Change Color of Columns For Some Rows 
        /// if use dgv.AlternativeRowsDefaultCellStyleBackColor Or ForeColor = Color.Yellow Change Color of All Rows
        /// So Use For loop to change color of columns on level all rows
        /// dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Style.BackColor / ForeColor
        /// then Use Event dgv_CellFormatting
        /// </summary>
        private void ChangeColoringColumns()
        {
            //Use For Loop to Change Color of all Column on all rows of dgv
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    //Change BackColor of Columns for all rows in dgv
                    dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvRepurchases.Rows[i].Cells["RepurchaseBuyPrice"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvRepurchases.Rows[i].Cells["RepurchaseNotes"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvRepurchases.Rows[i].Cells["BuyDetailBuyQuantity"].Style.BackColor = Color.YellowGreen;


                    //Change ForeColor of Columns for all rows in dgv
                    dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Style.ForeColor = Color.Yellow;
                    dgvRepurchases.Rows[i].Cells["RepurchaseBuyPrice"].Style.ForeColor = Color.Yellow;
                    dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Style.ForeColor = Color.Yellow;
                    dgvRepurchases.Rows[i].Cells["RepurchaseNotes"].Style.ForeColor = Color.Yellow;
                    dgvRepurchases.Rows[i].Cells["BuyDetailBuyQuantity"].Style.ForeColor = Color.OrangeRed;
                }
            }
        }

        /// <summary>
        /// ChangeColoringOfReBuyRows Method To Check if any Record which ReBuy Quantity Previous and Coloring Row 
        /// (BackColor and ForeColor)
        /// </summary>
        private void ChangeColoringOfReBuyRows()
        {
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                //Use Casting or Explicit Conversion التحويل غير ضمنى او صريح (DataType want which is need variable convert to it)
                /// IF ReBuyBillID of Item is Not equal DBNull.Value Item Rebuy Quantity from it or ReBuyItemStatus is true
                if (dgvRepurchases.Rows[i].Cells["ReBuyBillID"].Value != DBNull.Value && (Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == true)
                {
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //MessageBox.Show(dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value.ToString());
                        //Change BackColor of Rows which ReBuy Quantity //DefaultCellStyle
                        dgvRepurchases.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        //Change ForeColor of Rows which ReBuy Quantity
                        dgvRepurchases.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// void Method to Save All ReBuy item of ReBuyBill in ReBuyBill Table
        /// </summary>
        /// <param name="iPPcName">IP Address and PC Name</param>
        private void SaveReBuyBillTable(string iPPcName)
        {
            //Save Rebuy Items In RebuyBill TB
            ReBuyBillClass.SaveReBuyBill
                        (Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)), ReBuyBillClass.GenerateReBuyBillID(),
                         Convert.ToDecimal(lblRebuyTotalSalePrice.Text), Convert.ToDecimal(lblRebuyTotalBuyPrice.Text),
                         Convert.ToInt32(lblRebuyItemCount.Text), Convert.ToString(txtRebuyNotes.Text),
                         Convert.ToDecimal(lblRebuyRequired.Text), Convert.ToDecimal(txtRebuyPaid.Text),
                         Convert.ToDecimal(lblRebuyRemain.Text), iPPcName, Program.UsrID,
                         DateTime.Now.ToString("yyyy-MM-dd"),
                         DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
        }

        /// <summary>
        /// void Method to Update All ReBuy items in BuyDetails Table
        /// </summary>
        /// <param name="iPPcName">IP Address and PC Name</param>
        private void UpdateBuyDetailsByReBuyBill(string iPPcName)
        {
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        BuyDetailsClass.UpdateBuyDetail
                            (true, Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1, Convert.ToInt32(dgvRepurchases.Rows[i].Cells["BuyDetailID"].Value), Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value),
                             Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["BuyDetailItemBuyPrice"].Value), Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseTotalBuyPrice"].Value),
                             Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["BuyDetailItemSalePrice"].Value),
                             Convert.ToString(dgvRepurchases.Rows[i].Cells["RepurchaseNotes"].Value), iPPcName, Program.UsrID);
                    }
                }
            }
        }

        /// <summary>
        /// void Method To Get All Calculation of Purchase Bill
        /// TotalBuyofItem - TotalSaleofItem - TotalTaxofItem - discound (Deatials of buy bill)
        /// TotalBuy - TotalSale - TotalTax - TotalAmount - TotalPaid - TotalRemain (Head of buy bill)
        /// </summary>
        double BuyBillCalculations(string typeOfResult)
        {
            //Declare double Variables for Calcualtions in dgvSearch 
            //(اجمالى الجمهور - اجمالى الشراء - الخصم - الضريبة - اجمالى ض - سعر الشراء)
            double totalGeneral, totalBuy, tax, totalTax;
            //Declare double Variables for sumTotalG اجمالى الأصناف المشتراه بسعر البيع (اجمالى الجمهور) يعنى
            //sumTotalBuy اجمالى الأصناف المشتراه بسعر الشراء (اجمالى الشراء) يعنى - sumTotalTax اجمالى الضريبة
            double sumTotalG = 0, sumTotalBuy = 0, sumTotalTax = 0;

            //use for loop in all rows of dgvRepurchases
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                {
                    //Calculate totalGeneral اجمالى الجمهور = كمية المرتجعة * سعر البيع
                    totalGeneral = Convert.ToDouble(dgvRepurchases.Rows[i].Cells["BuyDetailItemSalePrice"].Value) * Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value);

                    //Calculate tax ضريبة الوحدة ==> user enter the tax manual
                    tax = Convert.ToDouble(dgvRepurchases.Rows[i].Cells["BuyDetailItemTax"].Value);
                    //Calculate totalTax  اجمالى ضريبة = الكمية المشتراه * ضريبة الوحدة
                    totalTax = Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * tax;

                    //Calculate totalBuy اجمالى الشراء = كمية المرتجعة * سعر الشراء
                    totalBuy = Convert.ToDouble(dgvRepurchases.Rows[i].Cells["BuyDetailItemBuyPrice"].Value) * Convert.ToDouble(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value);

                    //Calculate sumTotalG  اجمالى الفاتورة بسعر البيع = sumTotalG  + totalGeneral
                    sumTotalG += totalGeneral;
                    //Calculate sumTotalBuy اجمالى الفاتورة بسعر الشراء = sumTotalG  + totalBuy
                    sumTotalBuy += totalBuy;
                    //Calculate sumTotalTax اجمالى الضريبة على الفاتورة = sumTotalTax  + totalTax
                    sumTotalTax += totalTax;
                }
            }

            if (typeOfResult == "TotalBuy")
            {
                return sumTotalBuy;
            }
            else if (typeOfResult == "TotalSale")
            {
                return sumTotalG;
            }

            return sumTotalTax;
        }

        /// <summary>
        /// decimal Function To Calculate Earns by three steps
        /// Case (1) ==> Calculate ItemEarn for all rows of dgv by passing typeOfEarn equal "ItemEarn" and rowIndex
        /// Case (2) ==> Calculate TotalItemEarn for all rows of dgv by passing typeOfEarn equal "TotalItemEarn" and rowIndex 
        /// Case (3) ==> Calculate Total Earn of BuyBill by passing  typeOfEarn equal null and rowIndex by any default value 
        /// </summary>
        /// <param name="rowIndex">Index of row</param>
        /// <param name="typeOfEarn">typeOfEarn (ItemEarn or TotalItemEarn or null)</param>
        /// <returns></returns>
        decimal EarnOfItem(int rowIndex, string typeOfEarn)
        {
            //Declare two decimal Variables 
            decimal itemEarn, totalItemEarn;

            //Case (1) ==> Calculate ItemEarn for all rows of dgv
            if (typeOfEarn == "ItemEarn")
            {
                //ItemEarn ربح الوحدة = سعر بيع الوحدة - سعر الشراء + ضريبة الوحدة
                itemEarn = Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemSalePrice"].Value) - (Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemBuyPrice"].Value) + Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemTax"].Value));

                //stop executing block code and return itemEarn
                return itemEarn;
            }
            //Case (2) ==> Calculate TotalItemEarn for all rows of dgv
            else if (typeOfEarn == "TotalItemEarn")
            {
                /* this case its happen when passing two arguments to function 
                   typeOfEarn == "TotalItemEarn" and rowIndex */

                //ItemEarn ربح الوحدة = سعر بيع الوحدة - سعر الشراء + ضريبة الوحدة
                itemEarn = Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemSalePrice"].Value) - (Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemBuyPrice"].Value) + Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["BuyDetailItemTax"].Value));
                //totalItemEarn اجمالى ربح الوحدة = الكمية المشتراة * ربح الوحدة
                totalItemEarn = Convert.ToDecimal(dgvRepurchases.Rows[rowIndex].Cells["RepurchaseQty"].Value) * itemEarn;

                //stop executing block code and return totalItemEarn
                return totalItemEarn;
            }

            //Case (3) ==> Calculate Total Earn of BuyBill

            /* this case its happen when passing two arguments to function 
                   typeOfEarn == null and rowIndex by any default value */

            //totalEarnOfBuyBill اجمالى ربح الفاتورة = اجمالى الجمهور - اجمالى الشراء + اجمالى الضرائب
            return Convert.ToDecimal(BuyBillCalculations("TotalSale")) - Convert.ToDecimal(BuyBillCalculations("TotalBuy")) + Convert.ToDecimal(BuyBillCalculations(""));
        }

        /// <summary>
        /// void Method to Save All item of BuyBill in ItemOperations Table
        /// </summary>
        /// <param name="iPPcName">IP Address and Pc Name</param>
        void SaveReBuyItemOperationsTB(string iPPcName)
        {
            //(1)==>CalCulate Balance of Item in Large Unit and ItemQuantity by three different units(LargeUnit-MediumUnit-SmallUnit)
            //Declare Four double variable and intialize zero to it 
            double qtyLarge = 0, qtyMedium = 0, qtySmall = 0, itemBalance;

            //Save All item of BuyBill by use for loop  (3)===> ItemOperations Table
            for (int x = 0; x < dgvRepurchases.Rows.Count; x++)
            {
                // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
                if ((Boolean)dgvRepurchases.Rows[x].Cells["ReBuyItemStatus"].Value == false)
                {
                    // IF Repurchase Quantity is greater than Zero
                    if (Convert.ToInt32(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //ItemQuantity is Large ==>(A)
                        if (dgvRepurchases.Rows[x].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                        {
                            //الكمية المرتجعة بالوحدة الكبرى = المعطى تسجل بالسالب لتخصم من رصيد الصنف
                            qtyLarge = Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) * -1;
                            //الكمية المرتجعة بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                            qtyMedium = Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]) * -1;
                            //الكمية المرتجعة بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                            qtySmall = qtyMedium * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //RepurchaseQty is Medium ==>(B)
                        else if (dgvRepurchases.Rows[x].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                            qtyLarge = (Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                            //الكمية بالوحدة الوسطى = المعطى
                            qtyMedium = Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) * -1;
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                            qtySmall = qtyMedium * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //RepurchaseQty is Small ==>(C)
                        else if (dgvRepurchases.Rows[x].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى /  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                            qtyLarge = ((Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                            //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى /  معامل تحويل الصغرى.2
                            qtyMedium = (Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) * -1;
                            //الكمية بالوحدة الصغرى =  المعطى.3
                            qtySmall = Convert.ToDouble(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value) * -1;

                            //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }

                        //(D)==>ItemBalance is record by QuantityItemLargeUnit = Current Balance of item in Large Unit
                        itemBalance = Convert.ToDouble(dgvRepurchases.Rows[x].Cells["BuyDetailItemBalance"].Value);

                        //(2)==>Save Items in ItemOperations Table
                        OperationClass.SaveItemOperation(OperationClass.GenerateItemOperationID(), this.Name.Remove(0, 4), Convert.ToInt32(dgvRepurchases.Rows[x].Cells["BuyBillID"].Value), Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1, 0, 0, 0,
                            Convert.ToInt32(dgvRepurchases.Rows[x].Cells["BuyBillSupplier"].Value), Convert.ToInt32(dgvRepurchases.Rows[x].Cells["BuyBillBranch"].Value), Convert.ToInt32(dgvRepurchases.Rows[x].Cells["BuyBillStore"].Value),
                            Convert.ToInt32(dgvRepurchases.Rows[x].Cells["BuyDetailItemID"].Value), dgvRepurchases.Rows[x].Cells["UnitName"].Value.ToString(), Convert.ToDecimal(itemBalance),
                            Convert.ToDecimal(qtyLarge), Convert.ToDecimal(qtyMedium), Convert.ToDecimal(qtySmall), dgvRepurchases.Rows[x].Cells["BuyDetailBuyExpiry"].Value.ToString(),
                            0, Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailItemSalePrice"].Value), 0, Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailTotalSale"].Value), 0,
                            Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailItemBuyPrice"].Value), Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["RepurchaseTotalBuyPrice"].Value),
                            Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailDiscound"].Value), EarnOfItem(x, "ItemEarn"), EarnOfItem(x, "TotalItemEarn"), Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailItemTax"].Value),
                            (Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["BuyDetailItemTax"].Value) * Convert.ToDecimal(dgvRepurchases.Rows[x].Cells["RepurchaseQty"].Value)), Convert.ToString(dgvRepurchases.Rows[x].Cells["RepurchaseNotes"].Value), iPPcName, Program.UsrID,
                            DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        //MessageBox.Show("Done");
                    }

                }
            }
        }

        /// <summary>
        /// void Method To Update Balance of Supplier
        /// if user rebuy any items of purchases (RepurchaseQty > 0)
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateSupplierBalance(string iPPcName)
        {
            //Declare decimal variable to get Current balance of supplier
            decimal currentBalance = 0;
            //Declare int variable to get ID of supplier
            int supplierID = 0;

            //Use For Loop To Current Balance of Supplier
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    // IF Repurchase Quantity is greater than Zero
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //Get Supplier ID 
                        supplierID = Convert.ToInt32(dgvRepurchases.Rows[i].Cells["BuyBillSupplier"].Value);

                        //Declare decimal variable to get Current balance of supplier
                        //Get Current Supplier Balance by Search in Suppliers Table with use SupplierID
                        currentBalance = Convert.ToDecimal(SupplierClass.SearchSuppliers("SupplierID", supplierID.ToString()).Rows[0]["رصيد المورد"]);

                        //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                        currentBalance -= Convert.ToDecimal(lblRebuyRemain.Text);
                    }
                }
            }
            //Update Balance of Supplier by Current Supplier Balance
            SupplierClass.UpdateSuppliers(supplierID, currentBalance, iPPcName, Program.UsrID);
        }

        /// <summary>
        /// void Method To Update Quantity of Items in Items Table
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateItemQuantity(string iPPcName)
        {
            //Declare Three decimal variable and intialize zero to it
            decimal qtyLarge = 0, qtyMedium = 0, qtySmall = 0;

            //Use for loop in All Rows of dgvRepurchases To Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    // IF Repurchase Quantity is greater than Zero
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //(1)==> Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit (ItemQuantity is Large)
                        if (dgvRepurchases.Rows[i].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = المعطى
                            qtyLarge = Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * -1;
                            //الكمية بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                            qtyMedium = Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]) * -1;
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                            qtySmall = qtyMedium * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ItemQuantity is Medium
                        else if (dgvRepurchases.Rows[i].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                            qtyLarge = (Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                            //الكمية بالوحدة الوسطى = المعطى
                            qtyMedium = Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * -1;
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                            qtySmall = qtyMedium * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ItemQuantity is Small
                        else if (dgvRepurchases.Rows[i].Cells["UnitName"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى *  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                            qtyLarge = ((Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                            //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى *  معامل تحويل الصغرى.2
                            qtyMedium = (Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) * -1;
                            //الكمية بالوحدة الصغرى =  المعطى.3
                            qtySmall = Convert.ToDecimal(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) * -1;

                            //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }

                        //(2)==> Balance of ItemQunatity = Sum Of ItemQuantity + Current ItemQuantity (Large/Medium/Small)
                        qtyLarge += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الكبرى"]);

                        qtyMedium += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الوسطى"]);

                        qtySmall += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الصغرى"]);

                        //MessageBox.Show("qtyLarge ==>" + " " + qtyLarge + "qtyMedium ==>" + " " + qtyMedium + "qtySmall ==>" + " " + qtySmall);

                        //(3)==> Update Balance of Item Quantity in Items Table
                        ItemClass.UpdateItems(Convert.ToInt32(dgvRepurchases.Rows[i].Cells["BuyDetailItemID"].Value), qtyLarge, qtyMedium, qtySmall, iPPcName, Program.UsrID);
                    }
                }
            }
        }

        /// <summary>
        /// void Method To RePurchase Bill To SuupplierAccount
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void AddBillToSupplierAccount(string iPPcName)
        {
            //if RePurchase Bill is Cash ==> Stop Executing Next Block Code
            if (Convert.ToDecimal(lblRebuyRemain.Text) == 0) return;
            //Declare Decimal Variable To get SupplierBalance
            decimal currentBalance;
            //Declare int variable to get ID of supplier
            int supplierID, rebuyID = Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1;

            //Use for loop in All Rows of dgvRepurchases To Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                // IF Item Donot Rebuy Quantity from it or ReBuyItemStatus is False
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    // IF Repurchase Quantity is greater than Zero
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0)
                    {
                        //Get Supplier ID 
                        supplierID = Convert.ToInt32(dgvRepurchases.Rows[i].Cells["BuyBillSupplier"].Value);

                        //Declare decimal variable to get Current balance of supplier
                        //Get Current Supplier Balance by Search in Suppliers Table with use SupplierID
                        currentBalance = Convert.ToDecimal(SupplierClass.SearchSuppliers("SupplierID", dgvRepurchases.Rows[i].Cells["BuyBillSupplier"].Value.ToString()).Rows[0]["رصيد المورد"]);

                        //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                        currentBalance -= Convert.ToDecimal(lblRebuyRemain.Text);

                        //Save RePurchaseBill To SupplierAccount
                        SupplierAccountClass.SaveSupAccount(SupplierAccountClass.GenerateSupAccountID(), supplierID,
                            rebuyID, rebuyID.ToString("INRP-000000"), "فاتورة مرتجع المشتريات", (Convert.ToDecimal(lblRebuyRemain.Text) * -1), 0, currentBalance, "خصم رصيد من حساب المورد من مرتجع المشتريات رقم " + rebuyID.ToString("INRP-000000"), iPPcName,
                            Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));

                        //Stop Executing Next Block Code (to avoid recording the operation by the same count of items)
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Void Method To check if Rebuy Bill related by One Buy Bill
        /// 
        /// </summary>
        bool CheckValidationOfRebuyBill() //Not Completed Idea
        {
            //Create New Instance From List<string> To store duplicated ReBuyID in it
            List<string> rebuyList = new List<string>();
            //Use for Loop in Rows of dgvRepurchases
            for (int i = 0; i < dgvRepurchases.Rows.Count; i++)
            {
                //Create String Variable and assign Value of dgvHeadSearch.Rows[i].Cells["BuyBillID"].Value.ToString()
                string duplicatedValue = dgvRepurchases.Rows[i].Cells["BuyBillID"].Value.ToString();

                //if ReBuyItemStatus of Item is equal false (its means the item not rebuy from it before)
                if ((Boolean)dgvRepurchases.Rows[i].Cells["ReBuyItemStatus"].Value == false)
                {
                    //if RepurchaseQty of item > 0 and count of list elements is equal zero
                    if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0 && rebuyList.Count == 0)
                    {
                        //add duplicatedValue to list
                        rebuyList.Add(dgvRepurchases.Rows[i].Cells["BuyBillID"].Value.ToString());
                    }
                    //if RepurchaseQty of item > 0 and count of list elements is greater than zero
                    else if (Convert.ToInt32(dgvRepurchases.Rows[i].Cells["RepurchaseQty"].Value) > 0 && rebuyList.Count > 0)
                    {
                        //rebuyList does not contains (duplicatedValue)
                        if (!rebuyList.Contains(duplicatedValue))
                        {
                            //Return true
                            return true;
                        }
                    }
                }
            }
            //else return false
            return false;
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
                if (RepurchaseFRM != null) RepurchaseFRM = null;
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

        //btnSearch_Click Method To SearchBuyBillDetails  **Done** 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //check validation of datetimepicker when user is searching.
                CheckDateOfSearchValidation();

                // if chBoxSearchDate.Visible is true and chBoxSearchDate.Checked is false ==> 1
                if (chBoxSearchDate.Visible == true && chBoxSearchDate.Checked == false)
                {
                    //switch conditional statement(string) { Case "valueofstring": break; }
                    //Search based on ColumnName
                    switch (comboSearchWay.Text)
                    {
                        case "نوع الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BuyBillPayType
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BuyBillPayType", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("StoreName", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BranchName", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم المورد":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SupplierFullName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("SupplierFullName", comboSearchKey.Text, false, "", "");
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("ItemBarcode1", txtSearchKey.Text, false, "", "");
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("ItemName", comboSearchKey.Text, false, "", "");
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
                        case "نوع الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BuyBillPayType
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BuyBillPayType", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "تاريخ الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BuyBillInvoiceDate
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BuyBillInvoiceDate", "", true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("StoreName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BranchName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم المورد":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search BuyBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SupplierFullName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("SupplierFullName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("ItemBarcode1", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("ItemName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
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
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BuyBillCustomID", txtSearchKey.Text, false, "", "");
                            break;

                        case "رقم فاتورة المورد":
                            //Set DataTable is DataSource of DataGridView search by BuyBillSupplierNo
                            dgvRepurchases.DataSource = BuyDetailsClass.SearchBuyBillDetails("BuyBillSupplierNo", txtSearchKey.Text, false, "", "");
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
                AddNewRows();

                //GetRebuyQtyItems Method used To Calculate RepurchaseQty - RepurchaseTotalBuyPrice - RepurchaseNotes for all items
                GetRebuyQtyItems();

                //If dgvRepurchases.Rows.Count is equal Zero
                if (dgvRepurchases.Rows.Count == 0)
                {
                    //Show Notification of System Message Success Save
                    NotificationSMS.NotifyShow("لا توجد اى نتائج", "عملية البحث",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
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

        /* Review All Methods in btnSave_Click are Approved */
        /// <summary>
        /// Save ReBuy Quantity in ReBuyBill TB
        /// Update BuyDetails By ReBuyBill Invoice
        /// Save Rebuy Quantity in ItemOperations TB
        /// Update Balance of Quantity ReBuy Item in Items TB
        /// Update Balance of Supplier
        /// Add New Record To SupplierAccount
        /// Save Payment Amount in POSDetailsTB and Update Balance Of POSTB
        /// Recall BtnPrint To Print ReBuyBill Invoice
        /// </summary>
        /// <param name="sender">object is Sender</param>
        /// <param name="e">EventArgs is e</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //(1) ==> declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            //(2) ==> Show Payment Form To Check if Collect Amount of ReBuy Invoice (A) **Done** 
            // Save Payment Amount in POSDetailsTB (B) - Update Balance Of POSTB (C) 
            //Create new instance from FRM_Payment
            FRM_Payment PayFRM = new FRM_Payment();
            //Initialize Value To Payment Form 
            PayFRM.InitializePayment("", lblTitle.Text, (Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1).ToString("INRP-000000"), lblRebuyRequired.Text, txtRebuyPaid.Text,
                                      lblRebuyRemain.Text);
            //Show this instance (PayFRM) in mode ShowDialog to control it as first
            PayFRM.ShowDialog();

            //(3) ==> Save ReBuy Quantity in ReBuyBill TB **Done** 
            SaveReBuyBillTable(IP_PCName);
            //(4) ==> Update BuyDetails By ReBuyBill Invoice  **Done** 
            UpdateBuyDetailsByReBuyBill(IP_PCName);
            //(5) ==> Save Rebuy Quantity in ItemOperations TB(Negative Qty)
            SaveReBuyItemOperationsTB(IP_PCName);
            //(6) ==> Update Balance of Quantity ReBuy Item in Items TB(Negative Qty)
            UpdateItemQuantity(IP_PCName);
            //(7) ==> Add New Record To SupplierAccount By ReBuy Item in SupplierAccount TB **Done** 
            AddBillToSupplierAccount(IP_PCName);
            //(8) ==> Update Balance of Supplier By ReBuy Item in Suppliers TB (Negative Qty) **Done** 
            UpdateSupplierBalance(IP_PCName);


            //(9) ==> Show Notification of System Message Success Save
            NotificationSMS.NotifyShow("تم حفظ فاتورة مرتجع الشراء رقم " + (Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1).ToString("INRP-000000") + " بنجاح ", "عملية الحفظ",
                FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //(10) ==> Recall BtnPrint To Print ReBuyBill Invoice **Done** 
            //Show Notification of System Message Question Message To Print ReBuyBill Invoice - Question Message Box
            NotificationSMS.NotifyShow("هل تريد طباعة فاتورة مرتجع الشراء ؟", "الطباعة",
                FRM_Notifications.NotifyButtons.YesNo, FRM_Notifications.NotifyIcons.Question,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //Check If User Press Yes To Print ReBuy Invoice **Done** 
            if (NotificationSMS.NotifyResult == true)
            {
                //Recall BtnPrint To Print ReBuyBill Invoice
                btnPrint_Click(sender, e);
            }
            //Recall btnNew To Clear Controls ReBuyBill Invoice **Done** 
            btnNew_Click(sender, e);
        }

        //btnPrint_Click Method To Print Report of SupplierAccount 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if Rebuy Items is equal zero
                if (dgvRepurchases.Rows.Count == 0)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("سيتم الانتقال الى بحث فواتير مرتجعات الشراء لتحديد الفاتورة ثم طباعتها", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //check if field you are created is null when closed form if not Assign null value to field
                    if (RepurchaseFRM != null) RepurchaseFRM = null;
                    //Close Form
                    this.Close();
                    //Used btnBranches_Click Method To Move RepurchasesSearch by Encapsulation is FRM_Main.ObjectMain_Property
                    FRM_Main.ObjectMain_Property.btnRepurchasesSearch_Click(sender, e);
                    //Stop to executing block code
                    return;
                }

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
                ReBuyPillReport.SetParameterValue("@SearchKey", Convert.ToInt32(ReBuyBillClass.GenerateReBuyBillID().Remove(0, 5)) - 1);

                //Refresh crystalRptViewerPurchases
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
            if (comboSearchWay.SelectedIndex == 0 || comboSearchWay.SelectedIndex == 5)
            {
                chBoxSearchDate.Visible = false;
                lblStartDate.Visible = false;
                dtpDateFrom.Visible = false;
                lblEndDate.Visible = false;
                dtpDateTo.Visible = false;
            }
            else if (comboSearchWay.SelectedIndex == 2)
            {
                txtSearchKey.Visible = false;
                comboSearchKey.Visible = false;

                if (!chBoxSearchDate.Visible == true)
                {
                    chBoxSearchDate.Visible = true;
                    lblStartDate.Visible = true;
                    dtpDateFrom.Visible = true;
                    lblEndDate.Visible = true;
                    dtpDateTo.Visible = true;
                }
            }
            else
            {
                txtSearchKey.Visible = true;
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
                    if (!txtSearchKey.Visible == true) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 1: //نوع الفاتورة
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                case 3: //اسم المخزن
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                case 4: //اسم الفرع
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                case 5: //رقم فاتورة المورد
                    if (!txtSearchKey.Visible == true) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 6: //اسم المورد
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                case 7: //باركود الصنف
                    if (!txtSearchKey.Visible == true) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 8: //اسم الصنف
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                default:
                    txtSearchKey.BringToFront();
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

        //dgvRepurchases_CellEndEdit Method To Check Validation of Rebuy Qunatity and Get Calculation of RebuyBill
        private void dgvRepurchases_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Check if user try related one rebuy bill more than one buybill
                if (CheckValidationOfRebuyBill() == true)
                {
                    // Warning Message Box
                    NotificationSMS.NotifyShow("لا يمكن ربط المرتجع بأكثر من فاتورة شراء", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Change Value of RepurchaseQty is equal Zero
                    dgvRepurchases.CurrentRow.Cells["RepurchaseQty"].Value = 0;
                    //Stop Executing block code
                    return;
                }
                //Check Validatio of Rebuy Qty and Check if Item is Rebuy Qty from it
                CheckRebuyQtyValidation();
                //Get Calculation of TotalRebuyBuyPrice - TotalRebuySalePrice - Required and Remained Amount
                GetCalculations();
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

        //dgvRepurchases_DataError Method To Recover Error is generated from SelectionChanged and CellEndEdit
        private void dgvRepurchases_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                //if Catches Any Error and e.ThrowException = true (e refers to behavior generated from Event)
                if (e.ThrowException == true)
                {
                    //Change e.ThrowException = false
                    e.ThrowException = false;
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

        //dgvRepurchases_CellFormatting Method To Change Color of all Column on all rows of dgv **Done**
        private void dgvRepurchases_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //(1) ==> Change Color of all Column on all rows of dgv
                ChangeColoringColumns();

                //(2) ==> Change Coloring of Row ReBuy Quantity Befor
                ChangeColoringOfReBuyRows();
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

        //txtRebuyPaid_TextChanged Method To Calculate lblRebuyRemain Of RebuyBill
        private void txtRebuyPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if lblRebuyRequired is not contains is equal Zero
                if (lblRebuyRequired.Text != "0")
                {
                    lblRebuyRemain.Text = (Convert.ToDouble(lblRebuyRequired.Text) - Convert.ToDouble(txtRebuyPaid.Text)).ToString("0.00");
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
