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
    public partial class FRM_Resales : Form
    {

        #region Public Declarations
        //Create New Instance From BAL.CLS_Customers Business Access Layer
        readonly BAL.CLS_Customers CustomerClass = new BAL.CLS_Customers();
        //Create New Instance From BAL.CLS_CustomerAccount Business Access LayerBuyBill
        readonly BAL.CLS_CustomerAccount CustomerAccountClass = new BAL.CLS_CustomerAccount();
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchClass = new BAL.CLS_Branches();
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoreClass = new BAL.CLS_Stores();
        //Create New Instance From BAL.CLS_Items Business Access Layer
        readonly BAL.CLS_Items ItemClass = new BAL.CLS_Items();
        //Create New Instance From BAL.CLS_ItemOperations Business Access Layer
        readonly BAL.CLS_ItemOperations OperationClass = new BAL.CLS_ItemOperations();
        //Create New Instance From BAL.CLS_SaleBill Business Access Layer
        readonly BAL.CLS_SaleBill SaleBillClass = new BAL.CLS_SaleBill();
        //Create New Instance From BAL.CLS_SaleDetails Business Access Layer
        readonly BAL.CLS_SaleDetails SaleDetailsClass = new BAL.CLS_SaleDetails();
        //Create New Instance From BAL.CLS_ReSaleBill Business Access Layer
        readonly BAL.CLS_ReSaleBill ResaleBillClass = new BAL.CLS_ReSaleBill();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Using Object Oriented Programing to access FRM_Resales Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Resales ResaleFRM;

        //Create ResaleAccess_FormClosed to recall it when close form
        private static void ResaleAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            ResaleFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Resales ResaleAccess_Property
        {
            //used getter to return value of FRM_Resales 
            get
            {
                //if created instance or field is null
                if (ResaleFRM == null)
                {
                    //Create New Instance From FRM_Resales by initialize it to field
                    ResaleFRM = new FRM_Resales();
                    //Generate Event of Form Closed and Delegate Method ResaleAccess_FormClosed to it
                    ResaleFRM.FormClosed += new FormClosedEventHandler(ResaleAccess_FormClosed);
                }
                //Return the value of field
                return ResaleFRM;
            }
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_Resales Form
        /// which is first methods are executed when open form and after InitializeComponent for Visual Design
        /// </summary>
        public FRM_Resales()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Resales to it 
            if (ResaleFRM == null) ResaleFRM = this;
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
            dgvResales.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgvResales.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //Intialize AllowUserToAddRows of DGV is False
            dgvResales.AllowUserToAddRows = false;
            //Intialize AllowUserToDeleteRows of DGV is False
            dgvResales.AllowUserToDeleteRows = false;
            //Intialize AllowUserToOrderColumns of DGV is False
            dgvResales.AllowUserToOrderColumns = false;
            //Intialize AllowUserToResizeColumns of DGV is False
            dgvResales.AllowUserToResizeColumns = false;
            //To Control MinimumHeight of Rows in dgv
            dgvResales.RowTemplate.MinimumHeight = 35;
            //Intialize AutoSizeColumnsMode of DGV is DataGridViewAutoSizeColumnsMode.DisplayCells
            dgvResales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //Intialize AutoSizeRowsMode of DGV is DataGridviewAutoSizeRowsMode.DisplayedCells
            dgvResales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Intialize AutoGenerateColumns of DGV is False
            dgvResales.AutoGenerateColumns = false;
            ////Intialize DataSource of DGV is SaleBillClass.ShowSaleBillTable();
            //dgvResales.DataSource = SaleBillClass.ShowSaleBillTable();
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
                else if (comboSearchWay.SelectedIndex == 5) //اسم العميل
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is CustomerClass.ShowCustomersTable();
                    comboSearchKey.DataSource = CustomerClass.ShowCustomersTable();
                    //Initialize DisplayMember of combo is CustomerName
                    comboSearchKey.DisplayMember = "اسم العميل";
                    //Initialize ValueMember of combo is CustomerID
                    comboSearchKey.ValueMember = "الكود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, CustomerClass.ShowCustomersTable(), "اسم العميل");
                    //To Clear ComboBox of comboSearchKey by selected index equal -1  
                    comboSearchKey.SelectedIndex = -1;
                }
                else if (comboSearchWay.SelectedIndex == 7) //اسم الصنف
                {
                    //Clear DataSource of comboBox
                    comboSearchKey.DataSource = null;
                    //Initialize DataSource of combo is CustomerClass.ShowItemsTable();
                    comboSearchKey.DataSource = ItemClass.ShowItemsTable();
                    //Initialize DisplayMember of combo is ItemName
                    comboSearchKey.DisplayMember = "اسم الصنف";
                    //Initialize ValueMember of combo is ItemID
                    comboSearchKey.ValueMember = "كود الداخلى";
                    //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                    GetMaxWidthOfComboBox(comboSearchKey, ItemClass.ShowItemsTable(), "اسم الصنف");
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
                dgvResales.DataSource = null;
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
                    txtResalePaid.ReadOnly = false;
                }
            }
        }

        /// <summary>
        /// Void Method To Add Serial Number to dgvResales with using for loop
        /// </summary>
        private void AddNewRows()
        {
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                dgvResales.Rows[i].Cells["SaleDetailSerial"].Value = i + 1;
                dgvResales.Rows[i].Cells["ResaleQty"].Value = 0;//ResaleQty
                dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Value = dgvResales.Rows[i].Cells["SaleDetailItemFreeSalePrice"].Value; //SaleDetailItemFreeSalePrice
                dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Value = 0;//ResaleNetSalePrice
                dgvResales.Rows[i].Cells["ResaleNotes"].Value = "لا توجد";//ResaleNotes
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
        /// void method to Get Calculations of Resales.
        /// </summary>
        private void GetCalculations()
        {
            double totalB = 0, netG = 0;
            int countOfReturnItems = 0;

            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                // IF ResaleBillID of Item is equal DBNull.Value Item Resale Quantity from it or ResaleItemStatus is false
                if (dgvResales.Rows[i].Cells["SaleDetailReSaleID"].Value == DBNull.Value && (Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        //Get Count Resale Items
                        countOfReturnItems += 1;
                        //Get ResaleNetSalePrice
                        dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Value = Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Value) * Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value);
                        //Get ResaletotalBuyPrice
                        totalB += Convert.ToDouble(dgvResales.Rows[i].Cells["SaleDetailItemBuyPrice"].Value) * Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value);
                        //Get ResaleNetSalePrice
                        netG += Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Value) * Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value);
                    }
                }
            }

            lblResaleItemCount.Text = countOfReturnItems.ToString();
            lblResaleTotalBuyPrice.Text = totalB.ToString();
            lblResaleTotalSalePrice.Text = netG.ToString();
            lblResaleRequired.Text = netG.ToString();
            lblResaleRemain.Text = (netG - Convert.ToDouble(txtResalePaid.Text)).ToString();
        }

        /// <summary>
        /// Check if ResaleQty is Less Than or Equal SaleDetailBuyQuantity
        /// CheckValidation of ResaleItems To Permit user To use it
        /// </summary>
        private void CheckResaleQtyValidation()
        {
            // IF Item Resale Quantity from it or SaleDetailReSaleItem is true
            if ((Boolean)dgvResales.CurrentRow.Cells["SaleDetailReSaleItem"].Value == true)
            {
                // Warning Message Box
                NotificationSMS.NotifyShow("هذا الصنف تم ارجاعة من قبل", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Get ResaleItems
                //Initialize Value Of ResaleQty by Search in SaleBillDetails Table
                dgvResales.CurrentRow.Cells["ResaleQty"].Value = Convert.ToInt32(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.CurrentRow.Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["الكمية المرتجعة من الصنف"]);
                //Initialize Value Of ResaleNetSalePrice by Search in SaleBillDetails Table
                dgvResales.CurrentRow.Cells["ResaleNetSalePrice"].Value = Convert.ToInt32(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.CurrentRow.Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["اجمالى المرتجع بسعر البيع"]);
                //Initialize Value Of ResaleNotes by Search in SaleBillDetails Table
                dgvResales.CurrentRow.Cells["ResaleNotes"].Value = Convert.ToString(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.CurrentRow.Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["ملاحظات المرتجع"]);

                //Stop Execute Block Code
                return;
            }
            // IF Item Donot Resale Quantity from it or ResaleItemStatus is False
            else
            {
                if (Convert.ToInt32(dgvResales.CurrentRow.Cells["ResaleQty"].Value) > Convert.ToInt32(dgvResales.CurrentRow.Cells["SaleDetailSaleQuantity"].Value))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("يلزم ان تكون الكمية المرتجعة أقل من او تساوى الكمية المباعة", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Change Resale Qty is equal or less than SaleDetailSaleQuantity
                    dgvResales.CurrentRow.Cells["ResaleQty"].Value = dgvResales.CurrentRow.Cells["SaleDetailSaleQuantity"].Value;

                    //Stop Execute Block Code
                    return;
                }
            }
        }

        /// <summary>
        /// GetResaleItems To Check If Item Resale Quantity from it
        /// Then Get ResaleQty - ResaleTotalBuyPrice - ResaleNotes
        /// </summary>
        private void GetResaleQtyItems()
        {
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                //Use Casting or Explicit Conversion التحويل غير ضمنى او صريح (DataType want which is need variable convert to it)
                /// IF SaleDetailReSaleID of Item is Not equal DBNull.Value Item Resale Quantity from it or SaleDetailReSaleItem is true
                if (dgvResales.Rows[i].Cells["SaleDetailReSaleID"].Value != DBNull.Value && (Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == true)
                {
                    //Initialize Value Of ResaleQty by Search in SaleBillDetails Table
                    dgvResales.Rows[i].Cells["ResaleQty"].Value = Convert.ToInt32(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.Rows[i].Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["الكمية المرتجعة من الصنف"]);
                    //Initialize Value Of ResaleNetSalePrice by Search in SaleBillDetails Table
                    dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Value = Convert.ToInt32(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.Rows[i].Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["اجمالى المرتجع بسعر البيع"]);
                    //Initialize Value Of ResaleNotes by Search in SaleBillDetails Table
                    dgvResales.Rows[i].Cells["ResaleNotes"].Value = Convert.ToString(SaleDetailsClass.SearchSaleBillDetails("SaleDetailID", dgvResales.Rows[i].Cells["SaleDetailID"].Value.ToString(), false, "", "").Rows[0]["ملاحظات المرتجع"]);
                }
            }
        }

        /// <summary>
        /// Use For loop in all rows of datagridview to change color of all columns
        /// if use dgv.Columns["ColumnName"].DefaultCellStyle.BackColor Or ForeColor = Color.Yellow Change Color of Columns For Some Rows 
        /// if use dgv.AlternativeRowsDefaultCellStyleBackColor Or ForeColor = Color.Yellow Change Color of All Rows
        /// So Use For loop to change color of columns on level all rows
        /// dgvResales.Rows[i].Cells["ResaleQty"].Style.BackColor / ForeColor
        /// then Use Event dgv_CellFormatting
        /// </summary>
        private void ChangeColoringColumns()
        {
            //Use For Loop to Change Color of all Column on all rows of dgv
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    //Change BackColor of Columns for all rows in dgv
                    dgvResales.Rows[i].Cells["ResaleQty"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvResales.Rows[i].Cells["ResaleNotes"].Style.BackColor = Color.FromArgb(45, 52, 54);
                    dgvResales.Rows[i].Cells["SaleDetailSaleQuantity"].Style.BackColor = Color.YellowGreen;


                    //Change ForeColor of Columns for all rows in dgv
                    dgvResales.Rows[i].Cells["ResaleQty"].Style.ForeColor = Color.Yellow;
                    dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Style.ForeColor = Color.Yellow;
                    dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Style.ForeColor = Color.Yellow;
                    dgvResales.Rows[i].Cells["ResaleNotes"].Style.ForeColor = Color.Yellow;
                    dgvResales.Rows[i].Cells["SaleDetailSaleQuantity"].Style.ForeColor = Color.OrangeRed;
                }
            }
        }

        /// <summary>
        /// ChangeColoringOfResaleRows Method To Check if any Record which Resale Quantity Previous and Coloring Row 
        /// (BackColor and ForeColor)
        /// </summary>
        private void ChangeColoringOfResaleRows()
        {
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                //Use Casting or Explicit Conversion التحويل غير ضمنى او صريح (DataType want which is need variable convert to it)
                /// IF ReBuyBillID of Item is Not equal DBNull.Value Item Rebuy Quantity from it or ReBuyItemStatus is true
                if (dgvResales.Rows[i].Cells["SaleDetailReSaleID"].Value != DBNull.Value && (Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == true)
                {
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        //MessageBox.Show(dgvResales.Rows[i].Cells["ReBuyItemStatus"].Value.ToString());
                        //Change BackColor of Rows which ReBuy Quantity //DefaultCellStyle
                        dgvResales.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        //Change ForeColor of Rows which ReBuy Quantity
                        dgvResales.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        /// <summary>
        /// Change Format of BuyPrice if equal null to zero "0"
        /// </summary>
        private void ChangeFormatofBuyPrice()
        {
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                /// IF SaleDetailItemBuyPrice of Item is equal DBNull.Value
                if (dgvResales.Rows[i].Cells["SaleDetailItemBuyPrice"].Value == DBNull.Value)
                {
                    //Change value of SaleDetailItemBuyPric for all items to equal zero "0"
                    dgvResales.Rows[i].Cells["SaleDetailItemBuyPrice"].Value = "0";
                }
            }
        }

        /// <summary>
        /// void Method to Save All Resale item of ResaleBill in ResaleBill Table
        /// </summary>
        /// <param name="iPPcName">IP Address and PC Name</param>
        private void SaveResaleBillTable(string iPPcName)
        {
            //Save Resale Items In ResaleBill TB
            ResaleBillClass.SaveReSaleBill
                        (Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)), ResaleBillClass.GenerateReSaleBillID(),
                         Convert.ToDecimal(lblResaleTotalSalePrice.Text), Convert.ToDecimal(lblResaleTotalBuyPrice.Text),
                         Convert.ToInt32(lblResaleItemCount.Text), Convert.ToString(txtResaleNotes.Text),
                         Convert.ToDecimal(lblResaleRequired.Text), Convert.ToDecimal(txtResalePaid.Text),
                         Convert.ToDecimal(lblResaleRemain.Text), iPPcName, Program.UsrID,
                         DateTime.Now.ToString("yyyy-MM-dd"),
                         DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
        }

        /// <summary>
        /// void Method to Update All Resale items in SaleDetails Table
        /// </summary>
        /// <param name="iPPcName">IP Address and PC Name</param>
        private void UpdateSaleDetailsByResaleBill(string iPPcName)
        {
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                // IF Item Donot Resale Quantity from it or ResaleItemStatus is False
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        SaleDetailsClass.UpdatesaleDetail
                            (true, Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1, Convert.ToInt32(dgvResales.Rows[i].Cells["SaleDetailID"].Value), Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value),
                             Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Value), Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleNetSalePrice"].Value),
                             Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value) * Convert.ToDecimal(dgvResales.Rows[i].Cells["SaleDetailItemBuyPrice"].Value),
                             Convert.ToString(dgvResales.Rows[i].Cells["ResaleNotes"].Value), iPPcName, Program.UsrID);
                    }
                }
            }
        }

        /// <summary>
        /// void Method To Get All Calculation of Purchase Bill
        /// TotalBuyofItem - TotalSaleofItem - TotalTaxofItem - discound (Deatials of buy bill)
        /// TotalBuy - TotalSale - TotalTax - TotalAmount - TotalPaid - TotalRemain (Head of buy bill)
        /// </summary>
        double SaleBillCalculations(string typeOfResult)
        {
            //Declare double Variables for Calcualtions in dgvSearch 
            //(اجمالى الجمهور - اجمالى الشراء - الخصم - الضريبة - اجمالى ض - سعر الشراء)
            double totalGeneral, totalBuy, tax, totalTax;
            //Declare double Variables for sumTotalG اجمالى الأصناف المشتراه بسعر البيع (اجمالى الجمهور) يعنى
            //sumTotalBuy اجمالى الأصناف المشتراه بسعر الشراء (اجمالى الشراء) يعنى - sumTotalTax اجمالى الضريبة
            double sumTotalG = 0, sumTotalBuy = 0, sumTotalTax = 0;

            //use for loop in all rows of dgvResales
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                {
                    //Calculate totalGeneral اجمالى الجمهور = كمية المرتجعة * سعر البيع
                    totalGeneral = Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleFreeSalePrice"].Value) * Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value);

                    //Calculate tax ضريبة الوحدة ==> user enter the tax manual
                    tax = Convert.ToDouble(dgvResales.Rows[i].Cells["SaleDetailUnitTax"].Value);
                    //Calculate totalTax  اجمالى ضريبة = الكمية المشتراه * ضريبة الوحدة
                    totalTax = Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value) * tax;

                    //Calculate totalBuy اجمالى الشراء = كمية المرتجعة * سعر الشراء
                    totalBuy = Convert.ToDouble(dgvResales.Rows[i].Cells["SaleDetailItemBuyPrice"].Value) * Convert.ToDouble(dgvResales.Rows[i].Cells["ResaleQty"].Value);

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
        /// Case (3) ==> Calculate Total Earn of SaleBill by passing  typeOfEarn equal null and rowIndex by any default value 
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
                itemEarn = Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["ResaleFreeSalePrice"].Value) - (Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["SaleDetailItemBuyPrice"].Value) + Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["SaleDetailUnitTax"].Value));

                //stop executing block code and return itemEarn
                return itemEarn;
            }
            //Case (2) ==> Calculate TotalItemEarn for all rows of dgv
            else if (typeOfEarn == "TotalItemEarn")
            {
                /* this case its happen when passing two arguments to function 
                   typeOfEarn == "TotalItemEarn" and rowIndex */

                //ItemEarn ربح الوحدة = سعر بيع الوحدة - سعر الشراء + ضريبة الوحدة
                itemEarn = Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["ResaleFreeSalePrice"].Value) - (Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["SaleDetailItemBuyPrice"].Value) + Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["SaleDetailUnitTax"].Value));
                //totalItemEarn اجمالى ربح الوحدة = الكمية المشتراة * ربح الوحدة
                totalItemEarn = Convert.ToDecimal(dgvResales.Rows[rowIndex].Cells["ResaleQty"].Value) * itemEarn;

                //stop executing block code and return totalItemEarn
                return totalItemEarn;
            }

            //Case (3) ==> Calculate Total Earn of SaleBill

            /* this case its happen when passing two arguments to function 
                   typeOfEarn == null and rowIndex by any default value */

            //totalEarnOfSaleBill اجمالى ربح الفاتورة = اجمالى الجمهور + اجمالى الضرائب - اجمالى الشراء 
            return Convert.ToDecimal(SaleBillCalculations("TotalSale")) + Convert.ToDecimal(SaleBillCalculations("")) - Convert.ToDecimal(SaleBillCalculations("TotalBuy"));
        }

        /// <summary>
        /// void Method to Save All item of ReSaleBill in ItemOperations Table
        /// </summary>
        /// <param name="iPPcName">IP Address and Pc Name</param>
        void SaveResaleItemOperationsTB(string iPPcName)
        {
            //(1)==>CalCulate Balance of Item in Large Unit and ItemQuantity by three different units(LargeUnit-MediumUnit-SmallUnit)
            //Declare Four double variable and intialize zero to it 
            double qtyLarge = 0, qtyMedium = 0, qtySmall = 0, itemBalance;

            //Save All item of SaleBill by use for loop  (3)===> ItemOperations Table
            for (int x = 0; x < dgvResales.Rows.Count; x++)
            {
                // IF Item Donot Resale Quantity from it or SaleDetailReSaleItem is False
                if ((Boolean)dgvResales.Rows[x].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    // IF Resale Quantity is greater than Zero
                    if (Convert.ToInt32(dgvResales.Rows[x].Cells["ResaleQty"].Value) > 0)
                    {
                        //ItemQuantity is Large ==>(A)
                        if (dgvResales.Rows[x].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                        {
                            //الكمية المرتجعة بالوحدة الكبرى = المعطى تسجل بالموجب لتخصم من رصيد الصنف
                            qtyLarge = Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value);
                            //الكمية المرتجعة بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                            qtyMedium = Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value) * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]);
                            //الكمية المرتجعة بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                            qtySmall = qtyMedium * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ResaleQty is Medium ==>(B)
                        else if (dgvResales.Rows[x].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                            qtyLarge = (Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]));
                            //الكمية بالوحدة الوسطى = المعطى
                            qtyMedium = Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value);
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                            qtySmall = qtyMedium * Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ResaleQty is Small ==>(C)
                        else if (dgvResales.Rows[x].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى /  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                            qtyLarge = ((Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]));
                            //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى /  معامل تحويل الصغرى.2
                            qtyMedium = (Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value) / Convert.ToDouble(ItemClass.SearchItems("ItemID", dgvResales.Rows[x].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]));
                            //الكمية بالوحدة الصغرى =  المعطى.3
                            qtySmall = Convert.ToDouble(dgvResales.Rows[x].Cells["ResaleQty"].Value);

                            //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }

                        //(D)==>ItemBalance is record by QuantityItemLargeUnit = Current Balance of item in Large Unit
                        itemBalance = Convert.ToDouble(dgvResales.Rows[x].Cells["SaleDetailItemBalance"].Value);

                        //(2)==>Save Items in ItemOperations Table
                        OperationClass.SaveItemOperation(OperationClass.GenerateItemOperationID(), this.Name.Remove(0, 4), 0, 0, Convert.ToInt32(dgvResales.Rows[x].Cells["SaleBillID"].Value), Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1,
                            Convert.ToInt32(dgvResales.Rows[x].Cells["SaleBillCustomer"].Value), 0, Convert.ToInt32(dgvResales.Rows[x].Cells["SaleBillBranch"].Value), Convert.ToInt32(dgvResales.Rows[x].Cells["SaleBillStore"].Value),
                            Convert.ToInt32(dgvResales.Rows[x].Cells["SaleDetailItemID"].Value), dgvResales.Rows[x].Cells["SaleDetailItemUnit"].Value.ToString(), Convert.ToDecimal(itemBalance),
                            Convert.ToDecimal(qtyLarge), Convert.ToDecimal(qtyMedium), Convert.ToDecimal(qtySmall), dgvResales.Rows[x].Cells["SaleDetailSaleExpiryDate"].Value.ToString(),
                            Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailSaleExpiryQuantity"].Value), Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailItemSalePrice"].Value), Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailItemFreeSalePrice"].Value), (Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailItemSalePrice"].Value) * Convert.ToDecimal(dgvResales.Rows[x].Cells["ResaleQty"].Value)), Convert.ToDecimal(dgvResales.Rows[x].Cells["ResaleNetSalePrice"].Value), 
                            Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailItemBuyPrice"].Value), (Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailItemBuyPrice"].Value) * Convert.ToDecimal(dgvResales.Rows[x].Cells["ResaleQty"].Value)),
                            Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailDiscound"].Value), EarnOfItem(x, "ItemEarn"), EarnOfItem(x, "TotalItemEarn"), Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailUnitTax"].Value),
                            (Convert.ToDecimal(dgvResales.Rows[x].Cells["SaleDetailUnitTax"].Value) * Convert.ToDecimal(dgvResales.Rows[x].Cells["ResaleQty"].Value)), Convert.ToString(dgvResales.Rows[x].Cells["ResaleNotes"].Value), iPPcName, Program.UsrID,
                            DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                       
                    }

                }
            }
        }

        /// <summary>
        /// void Method To Update Balance of Customer
        /// if user Resale any items of purchases (ResaleQty > 0)
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateCustomerBalance(string iPPcName)
        {
            //Declare decimal variable to get Current balance of Customer
            //currentBalance = PreviousBalance + lblTotalRemain.Text (Postpone Case - Cash Setlement)
            decimal currentBalance = 0;

            //Declare int variable to get ID of Customer
            int CustomerID = 0;

            //Use For Loop To Current Balance of Customer
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                // IF Item Donot Resale Quantity from it or SaleDetailReSaleItem is False
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    // IF Resale Quantity is greater than Zero
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        //Get Customer ID 
                        CustomerID = Convert.ToInt32(dgvResales.Rows[i].Cells["SaleBillCustomer"].Value);

                        //Declare decimal variable to get Current balance of Customer
                        //Get Current Customer Balance by Search in Customers Table with use CustomerID
                        currentBalance = Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", CustomerID.ToString()).Rows[0]["رصيد العميل"]);

                        //If currentBalance is Credit
                        if (currentBalance >= 0)
                        {
                            //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                            currentBalance -= Convert.ToDecimal(lblResaleRemain.Text);
                        }
                        //If currentBalance is Debit
                        else if (currentBalance < 0)
                        {
                            //currentBalance = currentBalance + Convert.ToDecimal(lblResaleRemain.Text);
                            currentBalance += Convert.ToDecimal(lblResaleRemain.Text);
                        }
                    }
                }
            }
            //MessageBox.Show(currentBalance.ToString());
            //Update Balance of Customer by Current Customer Balance
            CustomerClass.UpdateCustomers(CustomerID, currentBalance, iPPcName, Program.UsrID); 
        }

        /// <summary>
        /// void Method To Update Quantity of Items in Items Table
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateItemQuantity(string iPPcName)
        {
            //Declare Three decimal variable and intialize zero to it
            decimal qtyLarge = 0, qtyMedium = 0, qtySmall = 0;

            //Use for loop in All Rows of dgvResales To Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                // IF Item Donot Resale Quantity from it or SaleDetailReSaleItem is False
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    // IF Resale Quantity is greater than Zero
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        //(1)==> Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit (ItemQuantity is Large)
                        if (dgvResales.Rows[i].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = المعطى
                            qtyLarge = Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value);
                            //الكمية بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                            qtyMedium = Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value) * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]);
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                            qtySmall = qtyMedium * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ItemQuantity is Medium
                        else if (dgvResales.Rows[i].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                            qtyLarge = (Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]));
                            //الكمية بالوحدة الوسطى = المعطى
                            qtyMedium = Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value);
                            //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                            qtySmall = qtyMedium * Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                            //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }
                        //ItemQuantity is Small
                        else if (dgvResales.Rows[i].Cells["SaleDetailItemUnit"].Value.ToString() == ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                        {
                            //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى *  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                            qtyLarge = ((Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]));
                            //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى *  معامل تحويل الصغرى.2
                            qtyMedium = (Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value) / Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]));
                            //الكمية بالوحدة الصغرى =  المعطى.3
                            qtySmall = Convert.ToDecimal(dgvResales.Rows[i].Cells["ResaleQty"].Value);

                            //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                        }

                        //(2)==> Balance of ItemQunatity = Sum Of ItemQuantity + Current ItemQuantity (Large/Medium/Small)
                        qtyLarge += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الكبرى"]);

                        qtyMedium += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الوسطى"]);

                        qtySmall += Convert.ToDecimal(ItemClass.SearchItems("ItemID", dgvResales.Rows[i].Cells["SaleDetailItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الصغرى"]);

                        //MessageBox.Show("qtyLarge ==>" + " " + qtyLarge + "qtyMedium ==>" + " " + qtyMedium + "qtySmall ==>" + " " + qtySmall);

                        //(3)==> Update Balance of Item Quantity in Items Table
                        ItemClass.UpdateItems(Convert.ToInt32(dgvResales.Rows[i].Cells["SaleDetailItemID"].Value), qtyLarge, qtyMedium, qtySmall, iPPcName, Program.UsrID);
                    }
                }
            }
        }

        /// <summary>
        /// void Method To Resale Bill To CustomerAccount
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void AddBillToCustomerAccount(string iPPcName)
        {
            //if Resale Bill is Cash ==> Stop Executing Next Block Code
            if (Convert.ToDecimal(lblResaleRemain.Text) == 0) return;
            //Declare Decimal Variable To get CustomerBalance
            decimal currentBalance;
            //Declare int variable to get ID of Customer
            int CustomerID, ResaleID = Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1;

            //Use for loop in All Rows of dgvResales To Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                // IF Item Donot Resale Quantity from it or SaleDetailReSaleItem is False
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    // IF Resale Quantity is greater than Zero
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0)
                    {
                        //Get Customer ID 
                        CustomerID = Convert.ToInt32(dgvResales.Rows[i].Cells["SaleBillCustomer"].Value);

                        //Declare decimal variable to get Current balance of Customer
                        //Get Current Customer Balance by Search in Customers Table with use CustomerID
                        currentBalance = Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", CustomerID.ToString()).Rows[0]["رصيد العميل"]);

                        //If currentBalance is Credit
                        if (currentBalance >= 0)
                        {
                            //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                            currentBalance -= Convert.ToDecimal(lblResaleRemain.Text);
                        }
                        //If currentBalance is Debit
                        else if (currentBalance < 0)
                        {
                            //currentBalance = currentBalance + Convert.ToDecimal(lblResaleRemain.Text);
                            currentBalance += Convert.ToDecimal(lblResaleRemain.Text);
                        }
                        //Save ResaleBill To CustomerAccount
                        CustomerAccountClass.SaveCustAccount(CustomerAccountClass.GenerateCustAccountID(), CustomerID,
                            ResaleID, ResaleID.ToString("INRS-000000"), "فاتورة مرتجع المبيعات", 0, Convert.ToDecimal(lblResaleRemain.Text), currentBalance, "خصم رصيد من حساب المورد من مرتجع المبيعات رقم " + ResaleID.ToString("INRS-000000"), iPPcName,
                            Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                        //Stop Executing Next Block Code (to avoid recording the operation by the same count of items)
                        return;
                    }
                }
            } 
        }

        /// <summary>
        /// Void Method To check if Resale Bill related by One Buy Bill
        /// </summary>
        bool CheckValidationOfResaleBill() //Not Completed Idea
        {
            //Create New Instance From List<string> To store duplicated ResaleID in it
            List<string> ResaleList = new List<string>();
            //Use for Loop in Rows of dgvResales
            for (int i = 0; i < dgvResales.Rows.Count; i++)
            {
                //Create String Variable and assign Value of dgvHeadSearch.Rows[i].Cells["SaleBillID"].Value.ToString()
                string duplicatedValue = dgvResales.Rows[i].Cells["SaleBillID"].Value.ToString();

                //if SaleDetailReSaleItem of Item is equal false (its means the item not Resale from it before)
                if ((Boolean)dgvResales.Rows[i].Cells["SaleDetailReSaleItem"].Value == false)
                {
                    //if ResaleQty of item > 0 and count of list elements is equal zero
                    if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0 && ResaleList.Count == 0)
                    {
                        //add duplicatedValue to list
                        ResaleList.Add(dgvResales.Rows[i].Cells["SaleBillID"].Value.ToString());
                    }
                    //if ResaleQty of item > 0 and count of list elements is greater than zero
                    else if (Convert.ToInt32(dgvResales.Rows[i].Cells["ResaleQty"].Value) > 0 && ResaleList.Count > 0)
                    {
                        //ResaleList does not contains (duplicatedValue)
                        if (!ResaleList.Contains(duplicatedValue))
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
                if (ResaleFRM != null) ResaleFRM = null;
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

        //btnSearch_Click Method To SearchSaleBillDetails  **Done** 
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
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SaleBillPayType
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("SaleBillPayType", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("StoreName", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("BranchName", comboSearchKey.Text, false, "", "");
                            break;

                        case "اسم العميل":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CustomerFullName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("CustomerFullName", comboSearchKey.Text, false, "", "");
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("ItemBarcode1", txtSearchKey.Text, false, "", "");
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("ItemName", comboSearchKey.Text, false, "", "");
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
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SaleBillPayType
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("SaleBillPayType", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "تاريخ الفاتورة":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by SaleBillInvoiceDate
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("SaleBillInvoiceDate", "", true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم المخزن":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by StoreName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("StoreName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم الفرع":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by BranchName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("BranchName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم العميل":
                            // Recall DataTable Fucation from BAL(Business Access Layer) to Search SaleBill by txtSearch.Text
                            // Set DataTable is DataSource of DataGridView search by CustomerFullName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("CustomerFullName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "باركود الصنف": //+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemBarcode1
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("ItemBarcode1", txtSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
                            break;

                        case "اسم الصنف"://+dtp
                            // Set DataTable is DataSource of DataGridView search by ItemName
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("ItemName", comboSearchKey.Text, true, dtpDateFrom.Value.ToString("yyyy-MM-dd"), dtpDateTo.Value.ToString("yyyy-MM-dd"));
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
                            dgvResales.DataSource = SaleDetailsClass.SearchSaleBillDetails("SaleBillCustomID", txtSearchKey.Text, false, "", "");
                            break;

                        default:
                            break;
                    }
                    //clear textbox
                    txtSearchKey.Clear();
                    //Focus on txtSearchKey
                    txtSearchKey.Focus();
                }
                //Add Serial Number to dgvResales with using for loop
                AddNewRows();

                ////GetResaleQtyItems Method used To Calculate ResaleQty - ResaleTotalBuyPrice - ResaleNotes for all items
                GetResaleQtyItems();

                //If dgvResales.Rows.Count is equal Zero
                if (dgvResales.Rows.Count == 0)
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

        /// <summary>
        /// Save Resale Quantity in ResaleBill TB
        /// Update SaleDetails By ResaleBill Invoice
        /// Save Resale Quantity in ItemOperations TB
        /// Update Balance of Quantity Resale Item in Items TB
        /// Update Balance of Customer
        /// Add New Record To CustomerAccount
        /// Save Payment Amount in POSDetailsTB and Update Balance Of POSTB
        /// Recall BtnPrint To Print ResaleBill Invoice
        /// </summary>
        /// <param name="sender">object is Sender</param>
        /// <param name="e">EventArgs is e</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //(1) ==> declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

            //(2) ==> Show Payment Form To Check if Collect Amount of Resale Invoice (A) **Done** 
            // Save Payment Amount in POSDetailsTB (B) - Update Balance Of POSTB (C) 
            //Create new instance from FRM_Payment
            FRM_Payment PayFRM = new FRM_Payment();
            //Initialize Value To Payment Form 
            PayFRM.InitializePayment("", lblTitle.Text, (Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1).ToString("INRS-000000"), lblResaleRequired.Text, txtResalePaid.Text,
                                      lblResaleRemain.Text);
            //Show this instance (PayFRM) in mode ShowDialog to control it as first
            PayFRM.ShowDialog();

            //(3) ==> Save Resale Quantity in ResaleBill TB **Done** 
            SaveResaleBillTable(IP_PCName);
            //(4) ==> Update SaleDetails By ResaleBill Invoice  **Done** 
            UpdateSaleDetailsByResaleBill(IP_PCName);
            //(5) ==> Save Resale Quantity in ItemOperations TB(Negative Qty)
            SaveResaleItemOperationsTB(IP_PCName);
            //(6) ==> Update Balance of Quantity Resale Item in Items TB(Negative Qty)
            UpdateItemQuantity(IP_PCName);
            //(7) ==> Add New Record To CustomerAccount By Resale Item in CustomerAccount TB **Done** 
            AddBillToCustomerAccount(IP_PCName);
            //(8) ==> Update Balance of Customer By Resale Item in Customers TB (Negative Qty) **Done** 
            UpdateCustomerBalance(IP_PCName);

            //(9) ==> Show Notification of System Message Success Save
            NotificationSMS.NotifyShow("تم حفظ فاتورة مرتجع البيع رقم " + (Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1).ToString("INRS-000000") + " بنجاح ", "عملية الحفظ",
                FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //(10) ==> Recall BtnPrint To Print ResaleBill Invoice **Done** 
            //Show Notification of System Message Question Message To Print ResaleBill Invoice - Question Message Box
            NotificationSMS.NotifyShow("هل تريد طباعة فاتورة مرتجع البيع ؟", "الطباعة",
                FRM_Notifications.NotifyButtons.YesNo, FRM_Notifications.NotifyIcons.Question,
                FRM_Notifications.NotifyTypes.NotifyBtn);
            //Show Notification Message in Dialog Mode
            NotificationSMS.ShowDialog();

            //Check If User Press Yes To Print Resale Invoice **Done** 
            if (NotificationSMS.NotifyResult == true)
            {
                //Recall BtnPrint To Print ResaleBill Invoice
                btnPrint_Click(sender, e);
            }
            //Recall btnNew To Clear Controls ResaleBill Invoice **Done** 
            btnNew_Click(sender, e);
        }

        //btnPrint_Click Method To Print Report of CustomerAccount 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if Resale Items is equal zero
                if (dgvResales.Rows.Count == 0)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("سيتم الانتقال الى بحث فواتير مرتجعات البيع لتحديد الفاتورة ثم طباعتها", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //check if field you are created is null when closed form if not Assign null value to field
                    if (ResaleFRM != null) ResaleFRM = null;
                    //Close Form
                    this.Close();
                    //Used btnBranches_Click Method To Move ResalesSearch by Encapsulation is FRM_Main.ObjectMain_Property
                    FRM_Main.ObjectMain_Property.btnResalesSearch_Click(sender, e);
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
                ResalePillReport.SetParameterValue("@SearchKey", Convert.ToInt32(ResaleBillClass.GenerateReSaleBillID().Remove(0, 5)) - 1);

                //Refresh crystalRptViewerPurchases
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
            if (comboSearchWay.SelectedIndex == 0)
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

                case 5: //اسم hguldg
                    txtSearchKey.SendToBack();
                    FillComboBox();
                    break;

                case 6: //باركود الصنف
                    if (!txtSearchKey.Visible == true) txtSearchKey.Visible = true;
                    txtSearchKey.BringToFront();
                    break;

                case 7: //اسم الصنف
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

        //dgvResales_CellEndEdit Method To Check Validation of Resale Qunatity and Get Calculation of ResaleBill
        private void dgvResales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Check if user try related one Resale bill more than one SaleBill
                if (CheckValidationOfResaleBill() == true)
                {
                    // Warning Message Box
                    NotificationSMS.NotifyShow("لا يمكن ربط المرتجع بأكثر من فاتورة بيع", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Change Value of ResaleQty is equal Zero
                    dgvResales.CurrentRow.Cells["ResaleQty"].Value = 0;
                    //Stop Executing block code
                    return;
                }
                //Check Validatio of Resale Qty and Check if Item is Resale Qty from it
                CheckResaleQtyValidation();
                //Get Calculation of TotalResaleBuyPrice - TotalResaleSalePrice - Required and Remained Amount
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

        //dgvResales_DataError Method To Recover Error is generated from SelectionChanged and CellEndEdit
        private void dgvResales_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        //dgvResales_CellFormatting Method To Change Color of all Column on all rows of dgv **Done**
        private void dgvResales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //(1) ==> Change Color of all Column on all rows of dgv
                ChangeColoringColumns();

                //(2) ==> Change Coloring of Row Resale Quantity Befor
                ChangeColoringOfResaleRows();

                //(3) ==> Change Format of BuyPrice
                ChangeFormatofBuyPrice();
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

        //txtResalePaid_TextChanged Method To Calculate lblResaleRemain Of ResaleBill
        private void txtResalePaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if lblResaleRequired is not contains is equal Zero
                if (lblResaleRequired.Text != "0")
                {
                    lblResaleRemain.Text = (Convert.ToDouble(lblResaleRequired.Text) - Convert.ToDouble(txtResalePaid.Text)).ToString("0.00");
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
