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
using System.Globalization; // to Change Input Language or deal with Date or Time and NumberFormats

namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Sales : Form
    {

        #region Public Declaration
        //Create New Instance From BAL.CLS_SaleBill Business Access Layer
        readonly BAL.CLS_SaleBill SaleBillClass = new BAL.CLS_SaleBill();
        //Create New Instance From BAL.CLS_SaleDetails Business Access Layer
        readonly BAL.CLS_SaleDetails SaleDetailClass = new BAL.CLS_SaleDetails();
        //Create New Instance From BAL.CLS_Items Business Access Layer
        readonly BAL.CLS_Items ItemsClass = new BAL.CLS_Items();
        //Create New Instance From BAL.CLS_ItemOperations Business Access Layer
        readonly BAL.CLS_ItemOperations OperationsClass = new BAL.CLS_ItemOperations();
        //Create New Instance From BAL.CLS_Branches Business Access Layer
        readonly BAL.CLS_Branches BranchClass = new BAL.CLS_Branches();
        //Create New Instance From BAL.CLS_Stores Business Access Layer
        readonly BAL.CLS_Stores StoreClass = new BAL.CLS_Stores();
        //Create New Instance From BAL.CLS_Customers Business Access Layer
        readonly BAL.CLS_Customers CustomerClass = new BAL.CLS_Customers();
        //Create New Instance From BAL.CLS_CustomerAccount Business Access Layer
        readonly BAL.CLS_CustomerAccount CustomerAccountClass = new BAL.CLS_CustomerAccount();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;
        #endregion

        #region Using Object Oriented Programing to access FRM_Purchases Form from another Form

        //Create New Field from Form with the same Datatype
        private static FRM_Sales SalesAccessFRM;

        //Create SalesAccess_FormClosed to recall it when close form
        private static void SalesAccess_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Initialize null value to created field or Instance 
            //Disposed all resources of created field by initailize null value
            SalesAccessFRM = null;
        }

        //Create Encapsulation of Field or Property of field to Generate FormName.FormClosed event inside property
        public static FRM_Sales SalesAccess_Property
        {
            //used getter to return value of FRM_Sales 
            get
            {
                //if created instance or field is null
                if (SalesAccessFRM == null)
                {
                    //Create New Instance From FRM_Items by initialize it to field
                    SalesAccessFRM = new FRM_Sales();
                    //Generate Event of Form Closed and Delegate Method SalesAccess_FormClosed to it
                    SalesAccessFRM.FormClosed += new FormClosedEventHandler(SalesAccess_FormClosed);
                }
                //Return the value of field
                return SalesAccessFRM;
            }
        }

        #endregion

        //Constructor of FRM_Sales **Done**
        public FRM_Sales()
        {
            InitializeComponent();
            //Check if Field you are created is null so intialize value of FRM_Sales to it 
            if (SalesAccessFRM == null) SalesAccessFRM = this;
            //Set Properties OF dgvItemSearch
            InitializeDGV(dgvItemSearch);
            //Set Properties OF dgvSearch
            InitializeDGV(dgvSearch);
            //Generate new SaleBill ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = SaleBillClass.GenerateSaleBillID();
        }

        #region Methods And Functions

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //loop in all controls of form in pnlHead.Controls by foreach loop Case ==> (1)
            foreach (Control ctrl in this.pnlHead.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is ComboBox && ctrl.Text == string.Empty)
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderSales.SetError(ctrl, "هذا الحقل اجبارى");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }
            //loop in all controls of form in pnlDGV.Controls by foreach loop Case ==> (2)
            foreach (Control ctrl in this.pnlDGV.Controls)
            {
                //if Ctrl is TextBox and Ctrl is Enabled and Ctrl is Empty
                if (ctrl is DataGridView && dgvSearch.Rows.Count == 0)
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("يجب إضافه صنف واحد على الأقل", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }
            //loop in all controls of form in pnlBottom.Controls by foreach loop Case ==> (3) 
            foreach (Control ctrl in this.pnlBottom.Controls)
            { /* check if purchase paid on cash settlements */
                //if Ctrl is TextBox and Ctrl is Empty
                if (ctrl is Label && lblItemCount.Text == "0")
                {
                    //SetError of Error Provider(ctrlName, "message of error")
                    errProviderSales.SetError(ctrl, "يجب إضافه صنف على الأقل");
                    //Increase Counter of error by one
                    CountOfErrors += 1;
                }
            }

            //Return CounterOfErrors
            return CountOfErrors;
        }

        /// <summary>
        /// Method to loop of controls and Reset it to Default Values
        /// </summary>
        void ClearControls()
        {
            //Clear Error Provider
            errProviderSales.Clear();
            //loop in all control in side this.pnlHead.Controls
            foreach (Control ctrl in this.pnlHead.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
                else if (ctrl is ComboBox && ctrl != comboPayType)
                {
                    ctrl.Text = null;
                }
                else if (ctrl is ComboBox && ctrl == comboPayType) comboPayType.SelectedIndex = 0;
                else if (ctrl is DateTimePicker) dtpDate.Value = DateTime.Now;
            }
            //loop in all control in side this.pnlSearch.Controls
            foreach (Control ctrl in this.pnlSearch.Controls)
            {
                if (ctrl is TextBox) ctrl.Text = null;
                else if (ctrl is RadioButton) radBtnBarcode.Checked = true;
            }
            //loop in all control in side this.pnlItemBarcode.Controls
            foreach (Control ctrl in this.pnlDiscound.Controls)
            {
                if (ctrl is RadioButton) radBtnDiscoundPrecent.Checked = true;
            }
            //loop in all control in side this.pnlDGV.Controls
            foreach (Control ctrl in this.pnlDGV.Controls)
            {
                if (ctrl is DataGridView && dgvSearch.Rows.Count > 0) dgvSearch.Rows.Clear();
            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlBottom.Controls)
            {
                //if ctrl.text is empty initialize zero value "0"
                if ((ctrl is TextBox && ctrl.Text != string.Empty) &&
                    (ctrl == txtExpenses || ctrl == txtDiscound || ctrl == txtTotalPaid))
                {
                    ctrl.Text = "0";
                }
                if ((ctrl is Label && ctrl.Text != string.Empty) && (ctrl == lblNetSale || ctrl == lblTotalSale
                    || ctrl == lblTaxAddValue || ctrl == lblTotalAmount || ctrl == lblTotalRemain || ctrl == lblItemCount))
                {
                    ctrl.Text = "0";
                }
            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlCustomerInfo.Controls)
            {
                if (ctrl is Label && !ctrl.Name.StartsWith("label")) ctrl.ResetText();
            }
            //loop in all control in side this.pnlBottom.Controls
            foreach (Control ctrl in this.pnlItemInfo.Controls)
            {
                if (ctrl is Label && !ctrl.Name.StartsWith("label")) ctrl.ResetText();
            }
            //loop in all control in side this.pnlBillInfo.Controls
            foreach (Control ctrl in this.pnlBillInfo.Controls)
            {
                if (ctrl is Label && !ctrl.Name.StartsWith("label")) ctrl.ResetText();
            }

            //Hide DgvItemSearch
            dgvItemSearch.Visible = false;
            //Hide pnlSupplierInfo
            pnlCustomerInfo.Visible = false;
            //Hide pnlItemInfo
            pnlItemInfo.Visible = false;
            //Hide pnlBillInfo
            pnlBillInfo.Visible = false;
            //Generate new SaleBill ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblID.Text = SaleBillClass.GenerateSaleBillID();
        }

        //Set Properties OF DataGridView **Done**
        private void InitializeDGV(DataGridView dgv)
        {
            // Used Wizard of DataGridview To Set Columns of DGV And Set DataPropertyName by Alias Name in SP 
            // without Quation Mark 
            //Intialize MultiSelect of DGV is False
            dgv.MultiSelect = false;
            //Intialize SelectionMode of DGV is DataGridViewSelectionMode.FullRowSelect
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
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
        }

        /// <summary>
        /// void Method to add New Row to datagridview Search 
        /// use to search by ItemName or ItemBarcode
        /// </summary>
        /// <param name="columnName">Column Search Name</param>
        /// <param name="searchKey">KeyWord Search</param>
        /// <param name="txt">TextBox is Optional Argument</param>
        /// <param name="checkAddRows">checkAddRows is bool variable to check if need to add rows or not</param>
        public void AddRowToDgvSearch(string columnName, string searchKey, TextBox txt, bool checkAddRows)
        {
            //Create New Instance From DataTable
            DataTable dt = new DataTable();
            //Assign Value of search to DataTable
            dt = ItemsClass.SearchItems(columnName, searchKey);
            //Declare int Variable to get indexOfRowAdded
            int indexOfRowAdded = 0;

            //if Textbox equal null complete block code optional agrument
            if (txt != null)
            {
                //Clear TextBox
                txt.Clear();
                //Focus on TextBox
                txt.Focus();
            }
            //check if checkAddRows is equal true to add new row
            if (checkAddRows != false)
            {
                //Add New Row To DgvSearch
                dgvSearch.Rows.Add();
                //Declare int Variable to get indexOfRowAdded is equal (Count of Rows - 1)
                indexOfRowAdded = dgvSearch.Rows.Count - 1;
            }
            else //if checkAddRows is equal false 
            {
                //If dgvSearch.Rows.Count is equal Zero ==> Stop Execute Block Code
                if (dgvSearch.Rows.Count == 0) return;

                //else ==> dgvSearch.Rows.Count is Greater Than Zero When (Add Item By Barcode Item)
                //Use foreach loop of DataGridViewCell in dgvSearch.SelectedCells
                foreach (DataGridViewCell cell in dgvSearch.SelectedCells)
                {
                    //Initialize Index of SelectedCell of Row to indexOfRowAdded
                    indexOfRowAdded = dgvSearch.Rows[cell.RowIndex].Index;
                }
            }
            //Check if count of rows is greater than zero
            if (dt.Rows.Count > 0)
            {
                //Check Duplication Of Items
                //if rows of datagridview is more than 1
                if (dgvSearch.Rows.Count > 1)
                {
                    // Check Duplication of Items in BuyBill Invoice
                    for (int i = 0; i < dgvSearch.Rows.Count; i++)
                    {
                        if (Convert.ToString(dgvSearch.Rows[i].Cells["ItemID"].Value) == dt.Rows[0]["كود الداخلى"].ToString())
                        {
                            dgvSearch.Rows.RemoveAt(dgvSearch.Rows.Count - 1);

                            //Warning Message Box
                            NotificationSMS.NotifyShow("هذا الصنف تم إضتافته من قبل", "تنبية",
                                FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                                FRM_Notifications.NotifyTypes.NotifyBtn);
                            //Show Notification Message in Dialog Mode
                            NotificationSMS.ShowDialog();

                            //Increase Quantity of Item by One
                            dgvSearch.Rows[i].Cells["ItemQuantity"].Value = Convert.ToInt32(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) + 1;

                            //Focus in Cell ItemName
                            dgvSearch.CurrentCell = dgvSearch.Rows[i].Cells["ItemName"];

                            //Stop to executing block code
                            return;
                        }
                    }
                }
                //Assignment Value of Search to Columns of RowAdded
                //dt.Rows[0]["الباركود الأول"].ToString()
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemBarcode"].Value = null;//ItemBarcode
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemID"].Value = dt.Rows[0]["كود الداخلى"].ToString();//Item ID
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemName"].Value = dt.Rows[0]["اسم الصنف"].ToString();//ItemName
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemDosageForm"].Value = dt.Rows[0]["الشكل الدوائى"].ToString();//ItemDosage
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemBalance"].Value = dt.Rows[0]["رصيد الوحدات الكبرى"].ToString();//ItemBalance
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemSalePrice"].Value = dt.Rows[0]["سعر بيع الكبرى"].ToString();//ItemSalePrice
                //dgvSearch.Rows[indexOfRowAdded].Cells["ItemUnit"].Value = dt.Rows[0]["الوحدة الكبرى"].ToString();//ItemUnit
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemQuantity"].Value = 1;//ItemQuantity
                //dgvSearch.Rows[indexOfRowAdded].Cells["ItemExpiry"].Value = DateTime.Now.ToString("yyyy-MM");//ItemExpiry for buy
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemExpiryQuantity"].Value = 0;//ItemExpiryQuantity
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemTotalSalePrice"].Value = 0;//ItemTotalSalePrice
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemDiscound"].Value = 0;//ItemDiscound
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemNetSalePrice"].Value = 0;//ItemNetSalePrice
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemBuyPrice"].Value = dt.Rows[0]["سعر شراء الكبرى"].ToString();//ItemBuyPrice
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemTotalBuyPrice"].Value = 0;//ItemTotalBuyPrice
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemTax"].Value = 0;//ItemTax
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemTotalTax"].Value = 0;//ItemTotalTax
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemPlace"].Value = dt.Rows[0]["مكان التخزين"].ToString();//ItemPlace
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemCompany"].Value = dt.Rows[0]["الشركة المنتجة"].ToString();//ItemCompany
                dgvSearch.Rows[indexOfRowAdded].Cells["ItemNotes"].Value = "";//ItemNotes
            }
        }

        /// <summary>
        /// Method Used For
        /// Fill DataGridViewComboBoxCell By ItemUnit Name (LargeUnitName - MediumUnitName - SmallUnitName) /
        /// Get ItemBalance of ItemUnit /
        /// Get ItemSalePrice of ItemUnit /
        ///  Get ItemBuyPrice of ItemUnit
        /// </summary>
        void FillComboCellByItemUnit()
        {
            //Create New Intsance From DataTable
            DataTable dt = new DataTable();
            //Initialize Value of Search By ItemID to DataTable
            dt = ItemsClass.SearchItems("ItemID", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString());
            //Create New Instance From DataGridViewComboBoxCell then Explicit Conversion to dgvSearch.CurrentRow.Cells["ItemUnit"]
            DataGridViewComboBoxCell dgvComboCell = (DataGridViewComboBoxCell)dgvSearch.CurrentRow.Cells["ItemUnit"];
            //Clear Items of DataGridViewComboBoxCell before fill it
            dgvComboCell.Items.Clear();

            //Fill DataGridViewComboBoxCell by Items Via Using For Loop to LargeUnitName - MediumUnitName - SmallUnitName
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                //Add LargeUnitName
                dgvComboCell.Items.Add(dt.Rows[x]["الوحدة الكبرى"].ToString());
                //Add MediumUnitName
                dgvComboCell.Items.Add(dt.Rows[x]["الوحد الوسطى"].ToString());
                //Add SmallUnitName
                dgvComboCell.Items.Add(dt.Rows[x]["الوحدى الصغرى"].ToString());


                //Get ItemBalance of ItemUnit and ItemSalePrice of ItemUnit After User Selected Itemunit of Cell ComboBox
                //if ItemUnit of CurrentRow is Equal LargeUnitName
                if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == dt.Rows[x]["الوحدة الكبرى"].ToString())
                {
                    //Get ItemBalance of LargeItemUnit  
                    dgvSearch.CurrentRow.Cells["ItemBalance"].Value = dt.Rows[0]["رصيد الوحدات الكبرى"].ToString();
                    //Get ItemSalePrice of LargeItemUnit 
                    dgvSearch.CurrentRow.Cells["ItemSalePrice"].Value = dt.Rows[0]["سعر بيع الكبرى"].ToString();
                    //Get ItemBuyPrice of LargeItemUnit 
                    dgvSearch.CurrentRow.Cells["ItemBuyPrice"].Value = dt.Rows[0]["سعر شراء الكبرى"].ToString();
                }
                //else if ItemUnit of CurrentRow is Equal MediumUnitName
                else if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == dt.Rows[x]["الوحد الوسطى"].ToString())
                {
                    //Get ItemBalance of MediumItemUnit  
                    dgvSearch.CurrentRow.Cells["ItemBalance"].Value = dt.Rows[0]["رصيد الوحدات الوسطى"].ToString();
                    //Get ItemSalePrice of MediumItemUnit 
                    dgvSearch.CurrentRow.Cells["ItemSalePrice"].Value = dt.Rows[0]["سعر بيع الوسطى"].ToString();
                    //Get ItemBuyPrice of MediumItemUnit 
                    dgvSearch.CurrentRow.Cells["ItemBuyPrice"].Value = dt.Rows[0]["سعر شراء الوسطى"].ToString();
                }
                //else if ItemUnit of CurrentRow is Equal SmallUnitName
                else if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == dt.Rows[x]["الوحدى الصغرى"].ToString())
                {
                    //Get ItemBalance of SmallItemUnit  
                    dgvSearch.CurrentRow.Cells["ItemBalance"].Value = dt.Rows[0]["رصيد الوحدات الصغرى"].ToString();
                    //Get ItemSalePrice of SmallItemUnit 
                    dgvSearch.CurrentRow.Cells["ItemSalePrice"].Value = dt.Rows[0]["سعر بيع الصغرى"].ToString();
                    //Get ItemBuyPrice of SmallItemUnit
                    dgvSearch.CurrentRow.Cells["ItemBuyPrice"].Value = dt.Rows[0]["سعر شراء الصغرى"].ToString();
                }
            }
        }

        /// <summary>
        /// void Method To Fill DataGridViewComboBoxCell By ItemExpiry
        /// </summary>
        void FillComboCellByItemExpiry()
        {
            //Create New Intsance From DataTable
            DataTable itemUnitTable, itemExpiryTable = new DataTable();
            //Initialize Value of Search By ItemID to DataTable
            itemUnitTable = ItemsClass.SearchItems("ItemID", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString());
            //Initialize Value of Search By ItemOperations to DataTable
            itemExpiryTable = OperationsClass.SearchItemExpiry("ItemID", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString());

            //Create New Instance From DataGridViewComboBoxCell then Explicit Conversion to dgvSearch.CurrentRow.Cells["ItemUnit"]
            DataGridViewComboBoxCell dgvComboCell = (DataGridViewComboBoxCell)dgvSearch.CurrentRow.Cells["ItemExpiry"];
            //Clear Items of DataGridViewComboBoxCell before fill it
            dgvComboCell.Items.Clear();

            //Fill DataGridViewComboBoxCell by Items Via Using For Loop to LargeUnitName - MediumUnitName - SmallUnitName
            for (int i = 0; i < itemExpiryTable.Rows.Count; i++)
            {
                //Get ItemBalance of ItemUnit and ItemSalePrice of ItemUnit After User Selected Itemunit of Cell ComboBox
                //if ItemUnit of CurrentRow is Equal LargeUnitName
                if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == itemUnitTable.Rows[0]["الوحدة الكبرى"].ToString())
                {
                    dgvComboCell.Items.Add(itemExpiryTable.Rows[i]["ItemExpiry"].ToString());

                    if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemExpiry"].Value) == itemExpiryTable.Rows[i]["ItemExpiry"].ToString())
                    {
                        //Get ItemExpiryQuantity of LargeItemUnit  
                        dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value = itemExpiryTable.Rows[i]["TotalQtyLarge"].ToString();
                    }  
                }
                //else if ItemUnit of CurrentRow is Equal MediumUnitName
                else if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == itemUnitTable.Rows[0]["الوحد الوسطى"].ToString())
                {
                    dgvComboCell.Items.Add(itemExpiryTable.Rows[i]["ItemExpiry"].ToString());

                    if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemExpiry"].Value) == itemExpiryTable.Rows[i]["ItemExpiry"].ToString())
                    {
                        //Get ItemExpiryQuantity of LargeItemUnit  
                        dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value = itemExpiryTable.Rows[i]["TotalQtyMedium"].ToString();
                    }
                    
                }
                //else if ItemUnit of CurrentRow is Equal SmallUnitName
                else if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemUnit"].Value) == itemUnitTable.Rows[0]["الوحدى الصغرى"].ToString())
                {
                    dgvComboCell.Items.Add(itemExpiryTable.Rows[i]["ItemExpiry"].ToString());

                    if (Convert.ToString(dgvSearch.CurrentRow.Cells["ItemExpiry"].Value) == itemExpiryTable.Rows[i]["ItemExpiry"].ToString())
                    {
                        //Get ItemExpiryQuantity of LargeItemUnit  
                        dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value = itemExpiryTable.Rows[i]["TotalQtySmall"].ToString();
                    }
                    
                }
            }
        }

        /// <summary>
        /// void Method To Get All Calculation of Sale Bill
        /// TotalBuyofItem - TotalSaleofItem - TotalNetSaleofItem - TotalTaxofItem - discound (Deatials of buy bill)
        /// TotalBuy - TotalSale - NetSale - TotalTax - TotalAmount - TotalPaid - TotalRemain (Head of buy bill)
        /// </summary>
        public void SaleBillCalculations()
        {
            //Declare double Variables for Calcualtions in dgvSearch 
            //(اجمالى الجمهور - صافى الجمهور - اجمالى الشراء - الخصم - الضريبة - اجمالى ض - سعر الشراء)
            double totalGeneral, netGeneral, totalBuy, discound, tax, totalTax, totalEarn;
            //Declare double Variables for sumTotalG اجمالى الأصناف المشتراه بسعر البيع (اجمالى الجمهور) يعنى
            //sumTotalBuy اجمالى الأصناف المشتراه بسعر الشراء (اجمالى الشراء) يعنى - sumTotalTax اجمالى الضريبة
            //sumNetG اجمالى صافى الفاتورة بسعر البيع 
            double sumTotalG = 0, sumTotalBuy = 0, sumTotalTax = 0, sumNetG = 0;

            //Declare two double variables of Expenses and Discound to avoid System.FormatException
            double totExpenses, totDiscound;

            //use for loop in all rows of dgvSearch
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                //Calculate totalGeneral اجمالى الجمهور = كمية المباعة * سعر البيع
                totalGeneral = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemSalePrice"].Value) * Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);
                //record totalGeneral in ItemTotalSalePrice Cell of dgvSearch after Approximate by use class Math.Round( double value, int digits)
                dgvSearch.Rows[i].Cells["ItemTotalSalePrice"].Value = Math.Round(totalGeneral, 3);

                //Calculate totalBuy اجمالى الشراء =  كمية المشتراه * سعر الشراء
                totalBuy = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemBuyPrice"].Value) * Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);
                //record totalBuy in ItemTotalBuyPrice Cell of dgvSearch after Approximate by Math.Round(value, number of digits)
                dgvSearch.Rows[i].Cells["ItemTotalBuyPrice"].Value = Math.Round(totalBuy, 3);

                //Discound الخصم
                discound = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemDiscound"].Value);
                //record discound in ItemDiscound Cell of dgvSearch after Approximate by Math.Round(value, number of digits)
                dgvSearch.Rows[i].Cells["ItemDiscound"].Value = Math.Round(discound, 3);

                //if Sale Bill by Discound is percentage % Case ==> 1
                if (radBtnDiscoundPrecent.Checked == true)
                {
                    //Calculate netGeneral (صافى الجمهور =  اجمالى الجمهور - ((  اجمالى الجمهور * الخصم %) / 100 
                    netGeneral = totalGeneral - ((totalGeneral * discound) / 100);
                    //record netGeneral in ItemNetSalePrice Cell of dgvSearch after Approximate by Math.Round(value, number of digits)
                    dgvSearch.Rows[i].Cells["ItemNetSalePrice"].Value = Math.Round(netGeneral, 3);
                }
                //if Sale Bill by Discound is amount Case ==>2
                else
                {
                    //Calculate netGeneral صافى الجمهور =  اجمالى الجمهور - الخصم  
                    netGeneral = totalGeneral - discound;
                    //record netGeneral in ItemNetSalePrice Cell of dgvSearch after Approximate by Math.Round(value, number of digits)
                    dgvSearch.Rows[i].Cells["ItemNetSalePrice"].Value = Math.Round(netGeneral, 3);
                }

                //Calculate tax ضريبة الوحدة ==> user enter the tax manual
                tax = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemTax"].Value);

                //Calculate totalTax  اجمالى ضريبة = الكمية المشتراه * ضريبة الوحدة
                totalTax = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) * tax;
                //record totalTax in ItemTotalTax Cell of dgvSearch after Approximate by Math.Round(value, number of digits)
                dgvSearch.Rows[i].Cells["ItemTotalTax"].Value = Math.Round(totalTax, 3);

                //Calculate sumTotalG  اجمالى الفاتورة بسعر البيع = sumTotalG  + totalGeneral
                sumTotalG += totalGeneral;
                //Calculate sumNetG  اجمالى صافى الفاتورة بسعر البيع = sumNetG  + netGeneral
                sumNetG += netGeneral;
                //Calculate sumTotalBuy اجمالى الفاتورة بسعر الشراء = sumTotalG  + totalBuy
                sumTotalBuy += totalBuy;
                //Calculate sumTotalTax اجمالى الضريبة على الفاتورة = sumTotalTax  + totalTax
                sumTotalTax += totalTax;
            }

            //Calculate Count of Item عدد الاصناف = dgvSearch.Rows.Count.ToString();
            lblItemCount.Text = dgvSearch.Rows.Count.ToString();
            //Calculate sumTotalG  اجمالى الفاتورة بسعر البيع
            lblTotalSale.Text = Convert.ToString(Math.Round(sumTotalG,2));
            //Calculate sumNetG  اجمالى صافى الفاتورة بسعر البيع
            lblNetSale.Text = Convert.ToString(Math.Round(sumNetG, 2));
            //Calculate sumTotalBuy اجمالى الفاتورة بسعر الشراء
            lblTotalBuy.Text = Convert.ToString(Math.Round(sumTotalBuy, 2));
            //Calculate sumTotalTax اجمالى الضريبة المضافة على الفاتورة
            lblTaxAddValue.Text = Convert.ToString(Math.Round(sumTotalTax, 2));

            //if txtExpenses is empty
            if (txtExpenses.Text == string.Empty)
            {
                totExpenses = 0;
            }
            else
            {
                totExpenses = Convert.ToDouble(txtExpenses.Text);
            }

            //if txtDiscound is empty
            if (txtDiscound.Text == string.Empty)
            {
                totDiscound = 0;
            }
            else
            {
                totDiscound = Convert.ToDouble(txtDiscound.Text);
            }


            //Calculate Total Earn of Sale Bill  اجمالى الربح بفاتورة البيع 
            //اجمالى الربح = صافى المبيعات + اجمالى الضرائب + اجمالى المصروفات - (اجمالى الفاتورة بسعر الشراء + اجمالى الخصم الاضافى للعميل) 1
            totalEarn = ((Convert.ToDouble(lblNetSale.Text) + Convert.ToDouble(lblTaxAddValue.Text) + totExpenses) - (Convert.ToDouble(lblTotalBuy.Text) + totDiscound));
            lblTotalEarn.Text = Convert.ToString(Math.Round(totalEarn, 2));

            

            //if Sale Bill is Cash
            if (comboPayType.SelectedIndex == 0)
            {
                //ResetDecimalFields Method to reset Control in pnlBottom to Zero
                ResetDecimalFields();

                //Calculate lblTotalAmount of Sale Bill  اجمالى قيمةالفاتورة أو المطلوب = 
                //صافى الفاتورة بسعر الببع + اجمالى الضريبة على الفاتورة + اجمالى المصروفات - الخصم النقدى على الفاتورة
                lblTotalAmount.Text = (Double.Parse(lblNetSale.Text) + Double.Parse(lblTaxAddValue.Text) + totExpenses - totDiscound).ToString();

                //المدفوع = اجمالى قيمةالفاتورة أو المطلوب
                txtTotalPaid.Text = lblTotalAmount.Text;
                //Change ReadOnly of txtTotalPaid to true
                txtTotalPaid.ReadOnly = true;

                //Calculate lblTotalRemain of Sale Bill  المتبقى = 0
                lblTotalRemain.Text = "0";
            }
            //if Sale Bill is Postpone
            else if (comboPayType.SelectedIndex == 1)
            {
                //ResetDecimalFields Method to reset Control in pnlBottom to Zero
                ResetDecimalFields();

                //Calculate lblTotalAmount of Sale Bill  اجمالى قيمةالفاتورة أو المطلوب = 
                //صافى الفاتورة بسعر الببع + اجمالى الضريبة على الفاتورة + اجمالى المصروفات - الخصم النقدى على الفاتورة
                lblTotalAmount.Text = (Double.Parse(lblNetSale.Text) + Double.Parse(lblTaxAddValue.Text) + totExpenses - totDiscound).ToString();

                //Calculate txtTotalPaid of Sale Bill  المدفوع = 0
                txtTotalPaid.Text = "0";
                //Change ReadOnly of txtTotalPaid to true
                txtTotalPaid.ReadOnly = true;

                //Calculate lblTotalRemain of Sale Bill
                //المتبقى = اجمالى قيمةالفاتورة أو المطلوب
                lblTotalRemain.Text = lblTotalAmount.Text;
            }
            else if (comboPayType.SelectedIndex == 2) // if any other cases
            {
                //ResetDecimalFields Method to reset Control in pnlBottom to Zero
                ResetDecimalFields();

                //Calculate lblTotalAmount of Sale Bill  اجمالى قيمةالفاتورة أو المطلوب = 
                //صافى الفاتورة بسعر الببع + اجمالى الضريبة على الفاتورة + اجمالى المصروفات - الخصم النقدى على الفاتورة
                lblTotalAmount.Text = (Double.Parse(lblNetSale.Text) + Double.Parse(lblTaxAddValue.Text) + totExpenses - totDiscound).ToString();

                //Change ReadOnly of txtTotalPaid to false
                txtTotalPaid.ReadOnly = false;

                //Calculate lblTotalRemain of Sale Bill  المتبقى =
                //اجمالى قيمةالفاتورة أو المطلوب - المدفوع
                lblTotalRemain.Text = (Double.Parse(lblTotalAmount.Text) - Double.Parse(txtTotalPaid.Text)).ToString();
            }
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
            decimal itemEarn, totalItemEarn, itemNetSalePriceForUnit;

            //Case (1) ==> Calculate ItemEarn for all rows of dgv
            if (typeOfEarn == "ItemEarn")
            {
                //(A)==>Calculate itemNetSalePriceForUnit in two Cases
                //if Discound is Percentage اذا كان الخصم نسبة % مئوية
                if (radBtnDiscoundPrecent.Checked == true)
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع - (سعر البيع * الخصم) / 100
                    itemNetSalePriceForUnit = Convert.ToDecimal(Convert.ToDouble(dgvSearch.Rows[rowIndex].Cells["ItemSalePrice"].Value) - ((Convert.ToDouble(dgvSearch.Rows[rowIndex].Cells["ItemSalePrice"].Value) * Convert.ToDouble(dgvSearch.Rows[rowIndex].Cells["ItemDiscound"].Value)) / 100));
                }
                //if Discound is Amount اذا كان الخصم قيمة
                else
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع -  الخصم
                    itemNetSalePriceForUnit = Convert.ToDecimal(Convert.ToDouble(dgvSearch.Rows[rowIndex].Cells["ItemSalePrice"].Value) - Convert.ToDouble(dgvSearch.Rows[rowIndex].Cells["ItemDiscound"].Value));
                }

                //ItemEarn ربح الوحدة = صافى سعر بيع الوحدة + ضريبة الوحدة - سعر الشراء 
                itemEarn = (itemNetSalePriceForUnit + Convert.ToDecimal(dgvSearch.Rows[rowIndex].Cells["ItemTax"].Value)) - (Convert.ToDecimal(dgvSearch.Rows[rowIndex].Cells["ItemBuyPrice"].Value));

                //stop executing block code and return itemEarn
                return itemEarn;
            }
            //Case (2) ==> Calculate TotalItemEarn for all rows of dgv
            else if (typeOfEarn == "TotalItemEarn")
            {
                /* this case its happen when passing two arguments to function 
                   typeOfEarn == "TotalItemEarn" and rowIndex */

                //totalItemEarn اجمالى ربح الوحدة = صافى اجمالى سعر بيع للصنف + اجمالى ضريبة الصنف - اجمالى سعر الشراء
                totalItemEarn = (Convert.ToDecimal(dgvSearch.Rows[rowIndex].Cells["ItemNetSalePrice"].Value) + Convert.ToDecimal(dgvSearch.Rows[rowIndex].Cells["ItemTotalTax"].Value)) - (Convert.ToDecimal(dgvSearch.Rows[rowIndex].Cells["ItemTotalBuyPrice"].Value));

                //stop executing block code and return totalItemEarn
                return totalItemEarn;
            }

            //Case (3) ==> Calculate Total Earn of BuyBill

            /* this case its happen when passing two arguments to function 
                   typeOfEarn == null and rowIndex by any default value */

            //totalEarnOfBuyBill اجمالى الربح = صافى المبيعات + اجمالى الضرائب + اجمالى المصروفات - (اجمالى الفاتورة بسعر الشراء + اجمالى الخصم الاضافى للعميل)
            return Convert.ToDecimal(Convert.ToDouble(lblNetSale.Text) + Convert.ToDouble(lblTaxAddValue.Text) + Convert.ToDouble(txtExpenses.Text) - (Convert.ToDouble(lblTotalBuy.Text) + Convert.ToDouble(txtDiscound.Text)));
        }

        /// <summary>
        /// void Method to Save All item of SaleBill in SaleBill Table
        /// </summary>
        /// <param name="iPPcName">IP Address and Pc Name</param>
        void SaveSaleBillTable(string iPPcName)
        {
            //Save Head of SaleBill   (1)===> SaleBill Table
            SaleBillClass.SaveSaleBill
                    (Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, Convert.ToInt32(comboCustomer.SelectedValue),
                     comboPayType.Text, Convert.ToInt32(comboStore.SelectedValue), Convert.ToInt32(comboBranch.SelectedValue),
                     txtNotes.Text, dtpDate.Value.ToString("yyyy-MM-dd"), Convert.ToDecimal(lblTotalSale.Text), Convert.ToDecimal(lblNetSale.Text),
                     Convert.ToDecimal(lblTotalBuy.Text), Convert.ToInt32(lblItemCount.Text), EarnOfItem(0, null), Convert.ToDecimal(lblTaxAddValue.Text),
                     Convert.ToDecimal(txtDiscound.Text), Convert.ToDecimal(txtExpenses.Text), Convert.ToDecimal(lblTotalAmount.Text),
                     Convert.ToDecimal(txtTotalPaid.Text), Convert.ToDecimal(lblTotalRemain.Text), iPPcName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"),
                     DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
        }

        /// <summary>
        /// void Method to Save All item of SaleBill in SaleDetails Table
        /// </summary>
        /// <param name="iPPcName">IP Address and Pc Name</param>
        void SaveSaleDetailsTable(string iPPcName)
        {
            //(1)===>Calculate Balance of Item in any different unit
            //Declare Two double variable To Calculate Balance of Item in any different unit
            double itemBalance, itemNetSalePriceForUnit;

            //Save All item of SaleBill by use for loop  (2)===> SaleDetails Table
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                //(D)==>ItemBalance is record by QuantityItem in any different unit = Current Balance of item - Quantity Saled in any different unit
                itemBalance = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemBalance"].Value) - Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);

                //(F)==>Calculate itemNetSalePriceForUnit in two Cases
                //if Discound is Percentage اذا كان الخصم نسبة % مئوية
                if (radBtnDiscoundPrecent.Checked == true)
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع - (سعر البيع * الخصم) / 100
                    itemNetSalePriceForUnit = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemSalePrice"].Value) - ((Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemSalePrice"].Value) * Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemDiscound"].Value)) / 100); 
                }
                //if Discound is Amount اذا كان الخصم قيمة
                else
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع -  الخصم
                    itemNetSalePriceForUnit = Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemSalePrice"].Value) - Convert.ToDouble(dgvSearch.Rows[i].Cells["ItemDiscound"].Value);
                }
                
                //(2)===>Save Items in SaleDetails Table
                SaleDetailClass.SaveSaleDetail(SaleDetailClass.GenerateSaleDetailID(), Convert.ToInt32(lblID.Text.Remove(0, 5)), Convert.ToInt32(dgvSearch.Rows[i].Cells["ItemID"].Value), dgvSearch.Rows[i].Cells["ItemUnit"].Value.ToString(),
                    Convert.ToDecimal(itemBalance), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemSalePrice"].Value), Convert.ToDecimal(itemNetSalePriceForUnit),
                    Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemBuyPrice"].Value), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value), dgvSearch.Rows[i].Cells["ItemExpiry"].Value.ToString(),
                    Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemExpiryQuantity"].Value), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemTotalSalePrice"].Value),
                    Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemNetSalePrice"].Value), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemDiscound"].Value), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemTotalBuyPrice"].Value),
                    Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemTax"].Value), Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemTotalTax"].Value),
                    EarnOfItem(i, "ItemEarn"), EarnOfItem(i, "TotalItemEarn"), Convert.ToString(dgvSearch.Rows[i].Cells["ItemNotes"].Value), iPPcName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        /// <summary>
        /// void Method to Save All item of SaleBill in ItemOperations Table
        /// </summary>
        /// <param name="iPPcName">IP Address and Pc Name</param>
        void SaveItemOperationsTable(string iPPcName)
        {
            //(1)==>CalCulate Balance of Item in Large Unit and ItemQuantity by three different units(LargeUnit-MediumUnit-SmallUnit)
            //Declare Four double variable and intialize zero to it 
            double qtyLarge = 0, qtyMedium = 0, qtySmall = 0, itemBalance = 0, itemNetSalePriceForUnit;

            //Save All item of SaleBill by use for loop  (3)===> ItemOperations Table
            for (int x = 0; x < dgvSearch.Rows.Count; x++)
            {
                //All Quantity Are recorded by Minus For Large - Medium - Small in Sale Bill Case

                //ItemQuantity is Large ==>(A) Minus
                if (dgvSearch.Rows[x].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = المعطى
                    qtyLarge = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) * -1;
                    //الكمية بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                    qtyMedium = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) * Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]) * -1;
                    //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                    qtySmall = qtyMedium * Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                    //(D)==>ItemBalance is record by QuantityItemLargeUnit = Current Balance of item - Quantity Saled in Large Unit by Minus
                    itemBalance = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemBalance"].Value) - (qtyLarge * -1);

                    //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }
                //ItemQuantity is Medium ==>(B) Minus
                else if (dgvSearch.Rows[x].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                    qtyLarge = (Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) / Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                    //الكمية بالوحدة الوسطى = المعطى
                    qtyMedium = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) * -1;
                    //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                    qtySmall = qtyMedium * Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                    //(D)==>ItemBalance is record by QuantityItemMediumUnit = Current Balance of item - Quantity Saled in Medium Unit by Minus
                    itemBalance = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemBalance"].Value) - (qtyMedium * -1);
                    //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }
                //ItemQuantity is Small ==>(C) Minus
                else if (dgvSearch.Rows[x].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى /  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                    qtyLarge = ((Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) / Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"])) * -1;
                    //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى /  معامل تحويل الصغرى.2
                    qtyMedium = (Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) / Convert.ToDouble(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[x].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) * -1;
                    //الكمية بالوحدة الصغرى =  المعطى.3
                    qtySmall = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemQuantity"].Value) * -1;

                    //(D)==>ItemBalance is record by QuantityItemLargeUnit = Current Balance of item - Quantity Saled in Large Unit by Minus
                    itemBalance = Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemBalance"].Value) - (qtySmall * -1);
                    //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }


                //(F)==>Calculate itemNetSalePriceForUnit in two Cases
                //if Discound is Percentage اذا كان الخصم نسبة % مئوية
                if (radBtnDiscoundPrecent.Checked == true)
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع - (سعر البيع * الخصم) / 100
                    itemNetSalePriceForUnit = (Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemSalePrice"].Value) - ((Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemSalePrice"].Value) * Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemDiscound"].Value)) / 100));
                }
                //if Discound is Amount اذا كان الخصم قيمة
                else
                {
                    //itemNetSalePriceForUnit ==> صافى سعر البيع = سعر البيع -  الخصم
                    itemNetSalePriceForUnit = (Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemSalePrice"].Value) - Convert.ToDouble(dgvSearch.Rows[x].Cells["ItemDiscound"].Value));
                }


                //(2)==>Save Items in ItemOperations Table
                OperationsClass.SaveItemOperation(OperationsClass.GenerateItemOperationID(), this.Name.Remove(0, 4), 0, 0, Convert.ToInt32(lblID.Text.Remove(0, 5)), 0, Convert.ToInt32(comboCustomer.SelectedValue),
                    0, Convert.ToInt32(comboBranch.SelectedValue), Convert.ToInt32(comboStore.SelectedValue),
                    Convert.ToInt32(dgvSearch.Rows[x].Cells["ItemID"].Value), dgvSearch.Rows[x].Cells["ItemUnit"].Value.ToString(), Convert.ToDecimal(itemBalance),
                    Convert.ToDecimal(qtyLarge), Convert.ToDecimal(qtyMedium), Convert.ToDecimal(qtySmall), dgvSearch.Rows[x].Cells["ItemExpiry"].Value.ToString(),
                    Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemExpiryQuantity"].Value), Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemSalePrice"].Value), Convert.ToDecimal(itemNetSalePriceForUnit), Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemTotalSalePrice"].Value), Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemNetSalePrice"].Value),
                    Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemBuyPrice"].Value), Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemTotalBuyPrice"].Value),
                    Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemDiscound"].Value), EarnOfItem(x, "ItemEarn"), EarnOfItem(x, "TotalItemEarn"), Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemTax"].Value),
                    Convert.ToDecimal(dgvSearch.Rows[x].Cells["ItemTotalTax"].Value), Convert.ToString(dgvSearch.Rows[x].Cells["ItemNotes"].Value), iPPcName, Program.UsrID,
                    DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
            }
        }

        /// <summary>
        /// void Method To Update Balance of Customer
        /// if user select Postpone Case to pay purchase Bill or Cash Setlements
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateCustomerBalance(string iPPcName)
        {
            //if user select Postpone Case to pay Sale Bill or Cash Setlements
            if (comboPayType.SelectedIndex == 1 || comboPayType.SelectedIndex == 2)
            {
                //Declare decimal variable to get Current balance of Customer
                //currentBalance = PreviousBalance + lblTotalRemain.Text (Postpone Case - Cash Setlement)
                decimal currentBalance;

                //Get Current Customer Balance by Search in Customers Table with use CustomerID
                currentBalance = Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"]);

                //If currentBalance is Credit
                if (currentBalance >= 0)
                {
                    //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                    currentBalance -= Convert.ToDecimal(lblTotalRemain.Text);
                }
                //If currentBalance is Debit
                else if (currentBalance < 0)
                {
                    //currentBalance = currentBalance + Convert.ToDecimal(lblResaleRemain.Text);
                    currentBalance += Convert.ToDecimal(lblTotalRemain.Text);
                }

                //Update Balance of Customer
                CustomerClass.UpdateCustomers(Convert.ToInt32(comboCustomer.SelectedValue), currentBalance, iPPcName, Program.UsrID);
            }
        }

        /// <summary>
        /// void Method To Update Quantity of Items in Items Table
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void UpdateItemQuantity(string iPPcName)
        {
            //Declare Three decimal variable and intialize zero to it
            decimal qtyLarge = 0, qtyMedium = 0, qtySmall = 0;

            //Use for loop in All Rows of dgvSearch To Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit
            for (int i = 0; i < dgvSearch.Rows.Count; i++)
            {
                //(1)==> Get Current ItemQuantity of LargeUnit - MediumUnit - SmallUnit (ItemQuantity is Large)
                if (dgvSearch.Rows[i].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["الوحدة الكبرى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = المعطى
                    qtyLarge = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);
                    //الكمية بالوحدة الوسطى = الكمية الكبرى * معامل تحويل الوسطى
                    qtyMedium = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) * Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]);
                    //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى
                    qtySmall = qtyMedium * Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                    //MessageBox.Show("Large <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }
                //ItemQuantity is Medium
                else if (dgvSearch.Rows[i].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["الوحد الوسطى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = الكمية بالوحدة المتوسطة /  معامل تحويل الوسطى
                    qtyLarge = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) / Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]);
                    //الكمية بالوحدة الوسطى = المعطى
                    qtyMedium = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);
                    //الكمية بالوحدة الصغرى = الكمية بالوحدة الوسطى *  معامل تحويل الصغرى 
                    qtySmall = qtyMedium * Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);

                    //MessageBox.Show("Medium <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }
                //ItemQuantity is Small
                else if (dgvSearch.Rows[i].Cells["ItemUnit"].Value.ToString() == ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["الوحدى الصغرى"].ToString())
                {
                    //الكمية بالوحدة الكبرى = ((الكمية بالوحدة الصغرى *  معامل تحويل الصغرى) / معامل تحويل الوسطى).1
                    qtyLarge = ((Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) / Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"])) / Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الوسطى"]));
                    //الكمية بالوحدة الوسطى = الكمية بالوحدة الصغرى *  معامل تحويل الصغرى.2
                    qtyMedium = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value) / Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["معامل تحويل الصغرى"]);
                    //الكمية بالوحدة الصغرى =  المعطى.3
                    qtySmall = Convert.ToDecimal(dgvSearch.Rows[i].Cells["ItemQuantity"].Value);

                    //MessageBox.Show("Small <==> ||" + " atyL = " + qtyLarge + " atyM = " + qtyMedium + " atyS = " + qtySmall);
                }

                //(2)==> Balance of ItemQunatity = Sum Of ItemQuantity - Current ItemQuantity (Large/Medium/Small)
                qtyLarge = Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الكبرى"]) - qtyLarge;

                qtyMedium = Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الوسطى"]) - qtyMedium;

                qtySmall = Convert.ToDecimal(ItemsClass.SearchItems("ItemID", dgvSearch.Rows[i].Cells["ItemID"].Value.ToString()).Rows[0]["رصيد الوحدات الصغرى"]) - qtySmall;

                //MessageBox.Show("qtyLarge ==>" + " " + qtyLarge + "qtyMedium ==>" + " " + qtyMedium + "qtySmall ==>" + " " + qtySmall);

                //(3)==> Update Balance of Item Quantity in Items Table
                ItemsClass.UpdateItems(Convert.ToInt32(dgvSearch.Rows[i].Cells["ItemID"].Value), qtyLarge, qtyMedium, qtySmall, iPPcName, Program.UsrID);
            }


        }

        /// <summary>
        /// void Method To Add Postpone Sale Bill To CustomerAccount
        /// </summary>
        /// <param name="iPPcName">iPPcName</param>
        void AddBillToCustomerAccount(string iPPcName)
        {
            //if Sale Bill is Cash ==> Stop Executing Next Block Code
            if (comboPayType.SelectedIndex == 0) return;

            //Declare decimal variable to get Current balance of Customer
            //currentBalance = PreviousBalance + lblTotalRemain.Text (Postpone Case - Cash Setlement)
            decimal currentBalance;

            //Declare decimal variable to get Current balance of Customer
            //Get Current Customer Balance by Search in Customers Table with use CustomerID
            currentBalance = Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"]);

            //If currentBalance is Credit
            if (currentBalance >= 0)
            {
                //currentBalance = currentBalance - Convert.ToDecimal(lblResaleRemain.Text);
                currentBalance -= Convert.ToDecimal(lblTotalRemain.Text);
            }
            //If currentBalance is Debit
            else if (currentBalance < 0)
            {
                //currentBalance = currentBalance + Convert.ToDecimal(lblResaleRemain.Text);
                currentBalance += Convert.ToDecimal(lblTotalRemain.Text);
            }

            //Save Postpone SaleBill To CustomerAccount
            CustomerAccountClass.SaveCustAccount(CustomerAccountClass.GenerateCustAccountID(), Convert.ToInt32(comboCustomer.SelectedValue),
                Convert.ToInt32(lblID.Text.Remove(0, 5)), lblID.Text, "فاتورة مبيعات", (Convert.ToDecimal(lblTotalRemain.Text) * -1), 0, currentBalance, "مبيعات آجلة من العميل", iPPcName,
                Program.UsrID, dtpDate.Value.ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
        }

        /// <summary>
        /// ResetDecimalFields void Method to reset Control in pnlBottom 
        /// which control is decimal fields to null or zero
        /// </summary>
        void ResetDecimalFields()
        {
            foreach (Control ctrl in pnlBottom.Controls)
            {
                //if ctrl.text is empty initialize zero value "0"
                if ((ctrl is TextBox && ctrl.Text == string.Empty) &&
                    (ctrl == txtExpenses || ctrl == txtDiscound || ctrl == txtTotalPaid)) ctrl.Text = "0";
                if ((ctrl is Label && ctrl.Text == string.Empty) && (ctrl == lblTotalBuy || ctrl == lblTotalSale
                    || ctrl == lblTaxAddValue || ctrl == lblTotalAmount || ctrl == lblTotalRemain)) ctrl.Text = "0";
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
        /// void Method to Info OF Customer
        /// </summary>
        /// <param name="searchKey">Key word of Search</param>
        void GetCustomerInfo(string searchKey)
        {
            //loop in all control in side this.pnlBottom.Controls to clear Controls
            foreach (Control ctrl in this.pnlCustomerInfo.Controls)
            {
                if (ctrl is Label && !ctrl.Name.StartsWith("label")) ctrl.ResetText();
            }
            //Search in Customers Table by ComboPayMethod to Get Customer Information (for loop)
            for (int i = 0; i < CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows.Count; i++)
            {
                if (searchKey == CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows[i]["اسم العميل"].ToString())
                {
                    lblCustID.Text = CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows[i]["الكود الداخلى"].ToString();
                    lblCustCompany.Text = CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows[i]["الشركة التابع لها"].ToString();
                    lblCustPhone.Text = CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows[i]["رقم الهاتف الاول"].ToString();
                    lblCustAddress.Text = CustomerClass.SearchCustomers("CustomerFullName", searchKey).Rows[i]["العنوان"].ToString();
                }
            }

            //If currentBalance is Credit
            if (Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"]) >= 0)
            {
                //Get Customer Balance
                lblCustBalance.Text = CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"].ToString();
                //Get Customer Balance Status
                lblCustStatus.Text = "دائن";
            }
            //If currentBalance is Debit
            else if (Convert.ToDecimal(CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"]) < 0)
            {
                //Get Customer Balance
                lblCustBalance.Text = CustomerClass.SearchCustomers("CustomerID", comboCustomer.SelectedValue.ToString()).Rows[0]["رصيد العميل"].ToString();
                //Get Customer Balance Status
                lblCustStatus.Text = "مدين";
            }
        }

        /// <summary>
        /// Method Used To Get Info of Selected Item in dgvSearch
        /// Item Dosage Name - Item Generic Name - Item ClassOfAction Name
        /// </summary>
        void GetItemSelectedInfo()
        {
            if (dgvSearch.Rows.Count < 1)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("برجاء ادخال صنف واحد على الاقل للفاتورة اولاً", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Executing Block Code
                return;
            }
            //If User Selected one of cells in any row of dgvSearch and ItemID is not equal null
            else if (dgvSearch.CurrentRow.Cells["ItemName"].Selected == true && dgvSearch.CurrentRow.Cells["ItemID"].Value != null)
            {
                //Set true Value To Visibility of pnlItemInfo
                this.pnlItemInfo.Visible = true;

                //Change Location of pnlItemInfo =new Point (int X refers to ==> lblTotalAmount.Location.X - (pnlItemInfo.Width + 5), int y refers to ==> 2)
                pnlItemInfo.Location = new Point(lblTotalAmount.Location.X - (pnlItemInfo.Width + 5), 2);

                //Create New Instance From DataTable
                DataTable dt = new DataTable();
                //Assign Value of search to DataTable
                dt = ItemsClass.SearchItems("ItemID", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString());

                //Initialize Values to Labels of PnlItemInfo
                //DosageFormName
                lblDosageForm.Text = dt.Rows[0]["الشكل الدوائى"].ToString();
                //GenericName
                lblGeneric.Text = dt.Rows[0]["المادة الفعالة"].ToString();
                //ClassOfActionName
                lblClassOfAction.Text = dt.Rows[0]["القسم الطبى"].ToString();
            }
            //If User did not Select one of cells in any row of dgvSearch or ItemID is equal null
            else if (dgvSearch.CurrentRow.Cells["ItemName"].Selected == false || dgvSearch.CurrentRow.Cells["ItemID"].Value == null)
            {
                //Set true Value To Visibility of pnlItemInfo
                this.pnlItemInfo.Visible = false;
                //Warning Message Box
                NotificationSMS.NotifyShow("برجاء تحديد اسم الصنف اولاً", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Executing Block Code
                return;
            }
        }

        /// <summary>
        /// Method to Fill AutoCompleteCustomSource of Combobox
        /// After Create new instance From AutoCompleteStringCollection 
        /// </summary>
        /// <param name="combo">ComboboxName</param>
        /// <param name="listName">ListName</param>
        void AutoCompleteComboBox(ComboBox combo, DataTable dt, string display, string value)
        {
            //Initialize DataSource of combo is SupplierClass.ShowSuppliersTable();
            combo.DataSource = dt;
            //Initialize DisplayMember of combo is SupplierName
            combo.DisplayMember = display;
            //Initialize ValueMember of combo is SupplierID
            combo.ValueMember = value;
            ////Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
            //GetMaxWidthOfComboBox(combo, dt, display);
            //To Clear ComboBox of comboSupplier by selected index equal -1
            combo.SelectedIndex = -1;

            //Create New Instance From AutoCompleteStringCollection to Make it CustomSource for ComboBox Area
            AutoCompleteStringCollection CustomArea = new AutoCompleteStringCollection();

            //Loop in items of Properties.Settings.Default.SettingsVariable.Cast<String>().ToList(); by foreah loop
            foreach (DataRow row in dt.Rows)
            {
                //Add every Item to AutoCompleteStringCollection
                CustomArea.Add(row[display].ToString());
            }

            //Set AUtoCompleteSource of Combobox is AutoCompleteSource.CustomSource
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Set AutoCompleteCustomSource of combobox is AutoCompleteStringCollection
            combo.AutoCompleteCustomSource = CustomArea;
            //Set AutoCompleteSourceMode of Combobox is AUtoCompleteMode.Suggest / SuggestAppend
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;

        }

        /// <summary>
        /// void Method To Control Cell Movements when user press key down on Enter Key
        /// </summary>
        void ControlCellMovementsOfDgv(KeyEventArgs e)
        {
            ////Stop Executing Block Code if Count of rows is less than one
            //if (dgvSearch.Rows.Count < 1) return;

            //Declare Two Int variables 
            int indexCell, indexRow;

            //Set index value is equal Current Cell in Column of dgvSearch
            indexCell = dgvSearch.CurrentCell.ColumnIndex;
            //Set index value is equal Current Cell in Row of dgvSearch
            indexRow = dgvSearch.CurrentCell.RowIndex;

            //If User press on enter key execute block code
            if (e.KeyCode == Keys.Enter)
            {
                //Use Block Code to Stop any other key press or key down or key up except key down of enter 
                e.SuppressKeyPress = true;

                //if Current Cell is equal last cell in column
                if (indexCell == dgvSearch.Columns.Count - 1)
                {
                    //if Current row is less than last index row of dgv ==> move to next row and first cell
                    if (indexRow < dgvSearch.Rows.Count - 1)
                    {
                        //Set Current Cell of Dgv equal first cell at index of Current row + 1 of dgv
                        dgvSearch.CurrentCell = dgvSearch.Rows[indexRow + 1].Cells[0];
                    }
                }
                //if Current Cell is Not equal last cell in column and Next cell of Current Cell is Not Visible to avoid any errors
                else if (indexCell != dgvSearch.Columns.Count - 1 && dgvSearch.CurrentRow.Cells[indexCell + 1].Visible == false)
                {
                    //Set Current Cell of Dgv equal index of Current cell + 2 in the same row of dgv
                    dgvSearch.CurrentCell = dgvSearch.Rows[indexRow].Cells[indexCell + 2];
                }
                //if Current Cell is Not equal last cell in column
                else if (indexCell != dgvSearch.Columns.Count - 1)
                {
                    //Set Current Cell of Dgv equal index of Current cell + 1 in the same row of dgv
                    dgvSearch.CurrentCell = dgvSearch.Rows[indexRow].Cells[indexCell + 1];
                }
            }
        }

        /// <summary>
        /// void Method To Control ReadOnly Of Cells When Add New Item By Use ItemBarcode
        /// </summary>
        void ControlCellEditingOfDgv()
        {
            //Stop Executing Block Code if Count of rows is less than one
            if (dgvSearch.Rows.Count < 1) return;

            //Use Foreach loop To loop in all cells of columns for dgvSearch
            foreach (DataGridViewColumn col in dgvSearch.Columns)
            {
                //if Cell of ItemBarcode of current row is equal null and ItemID of current row is equal null and index of Column is not equal zero
                if (dgvSearch.CurrentRow.Cells["ItemBarcode"].Value == null && dgvSearch.CurrentRow.Cells["ItemID"].Value == null && col.Index != 0)
                {
                    //Set ReadOnly of All Columns Except ItemBarcode to true
                    col.ReadOnly = true;
                }
                else
                {
                    //Set ReadOnly of All Columns Except ItemBarcode to False
                    col.ReadOnly = false;
                }
            }
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

        //FRM_Sales_Load Method to Fill AutoCompleteStringCollection of Combobox Customers-Branches **Done**
        private void FRM_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                //To enable AutoCompleteCustomSource
                AutoCompleteComboBox(comboCustomer, CustomerClass.ShowCustomersTable(), "اسم العميل", "الكود الداخلى");
                //To enable AutoCompleteCustomSource
                AutoCompleteComboBox(comboBranch, BranchClass.ShowBranchesTable(), "اسم الفرع", "الكود الداخلى");
                //Clear Controls
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

        //btnSearch_Click Method To Open FRM_ItemSearch Form **Done**
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new instance from FRM_ItemSearch
                FRM_ItemSearch SearchForm = new FRM_ItemSearch();
                //Show this instance in mode ShowDialog to control it as first
                SearchForm.ShowDialog();
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

        #region Validation Methods of Input Entry From User

        //comboBranch_DropDown Method To Fill ComboBox By Branches Table **Done**
        private void comboBranch_DropDown(object sender, EventArgs e)
        {
            try
            {
                //Initialize DataSource of combo is BranchClass.ShowBranchesTable();
                comboBranch.DataSource = BranchClass.ShowBranchesTable();
                //Initialize DisplayMember of combo is BranchName
                comboBranch.DisplayMember = "اسم الفرع";
                //Initialize ValueMember of combo is BranchID
                comboBranch.ValueMember = "الكود الداخلى";
                //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                GetMaxWidthOfComboBox(comboBranch, BranchClass.ShowBranchesTable(), "اسم الفرع");
                //To Clear ComboBox of comboSupplier by selected index equal -1  
                comboBranch.SelectedIndex = -1;
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

        //comboBranch_SelectedIndexChanged Method to hide error provider **Done**
        private void comboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // if comboBranch.text is not equal Empty
                if (comboBranch.Text != string.Empty)
                {
                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderSales.SetError(comboBranch, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;
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

        //comboBranch_TextChanged Method To Fill Branch ComboBox By Branches Table **Done**
        private void comboBranch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBranch.Text != string.Empty && comboBranch.SelectedIndex >= 0)
                {
                    if (StoreClass.SearchStores("StoreBranch", Convert.ToString(comboBranch.SelectedValue)).Rows.Count > 0)
                    {
                        //To enable AutoCompleteCustomSource
                        AutoCompleteComboBox(comboStore, StoreClass.ShowStoresTable(), "اسم المخزن", "الكود الداخلى");
                        //Initialize DataSource of combo is StoreClass.ShowStoresTable();
                        comboStore.DataSource = StoreClass.ShowStoresTable();
                        //Initialize DisplayMember of combo is StoreName
                        comboStore.DisplayMember = "اسم المخزن";
                        //Initialize ValueMember of combo is StoreID
                        comboStore.ValueMember = "الكود الداخلى";
                        //To Clear ComboBox of comboBranch by selected index equal -1  
                        comboStore.SelectedIndex = -1;
                    }
                    else
                    {
                        if (comboStore.DataSource != null) comboStore.DataSource = null;
                        comboStore.Items.Clear();
                        comboStore.Items.Add("لايوجد");
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

        //comboStore_DropDown Method To Fill ComboBox By Stores Table **Done**
        private void comboStore_DropDown(object sender, EventArgs e)
        {
            try
            {
                //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                GetMaxWidthOfComboBox(comboStore, StoreClass.SearchStores("StoreBranch", Convert.ToString(comboBranch.SelectedValue)), "اسم المخزن");
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

        //comboStore_SelectedIndexChanged Method to hide error provider **Done**
        private void comboStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // if comboStore.text is not equal Empty
                if (comboStore.Text != string.Empty)
                {
                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderSales.SetError(comboStore, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;
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

        //comboCustomer_DropDown Method To Fill ComboBox By Customers Table **Done**
        private void comboCustomer_DropDown(object sender, EventArgs e)
        {
            try
            {
                //Initialize DataSource of combo is CustomerClass.ShowCustomersTable();
                comboCustomer.DataSource = CustomerClass.ShowCustomersTable();
                //Initialize DisplayMember of combo is CustomerName
                comboCustomer.DisplayMember = "اسم العميل";
                //Initialize ValueMember of combo is CustomerID
                comboCustomer.ValueMember = "الكود الداخلى";
                //Modify ComboBox.DropDownWidth to Max width of item (the heighest length item)
                GetMaxWidthOfComboBox(comboCustomer, CustomerClass.ShowCustomersTable(), "اسم العميل");
                //To Clear ComboBox of comboCustomer by selected index equal -1  
                comboCustomer.SelectedIndex = -1;
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

        //comboCustomer_SelectedIndexChanged Method to hide error provider  **Done**
        private void comboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // if comboCustomer.text is not equal Empty
                if (comboCustomer.Text != string.Empty)
                {
                    //Clear Set Error of ErrorProvider by initailize (controlname,empty Message "");
                    errProviderSales.SetError(comboCustomer, "");
                    //if count of errors more than one less than couter by one
                    if (CountOfErrors > 1) CountOfErrors -= 1;
                    //else Iniatize Zeror value to counter
                    else CountOfErrors = 0;
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

        // comboCustomer_TextChanged Method To Get Info of Customers **Done**
        private void comboCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // if comboCustomer.text is not equal Empty
                if (comboCustomer.SelectedIndex >= 0 && pnlCustomerInfo.Visible == true && comboCustomer.Text != string.Empty)
                {
                    //Get Customer Info
                    GetCustomerInfo(comboCustomer.Text);
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

        //معلوماتعنالعميلToolStripMenuItem_Click Method To Get Info of Customers **Done**
        private void معلوماتعنالعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboCustomer.SelectedIndex == -1)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("برجاء تحديد العميل اولاً", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
            else if (comboCustomer.SelectedIndex >= 0)
            {
                //Get Customer Info
                GetCustomerInfo(comboCustomer.Text);
                //Change Visibility of pnlCustomerInfo true
                pnlCustomerInfo.Visible = true;
                //Change Location of pnlCustomerInfo =new Point (int X refers to ==> comboBranch.Location.X - (pnlCustomerInfo.Width + 5), int y refers to ==> 2)
                pnlCustomerInfo.Location = new Point(comboBranch.Location.X - (pnlCustomerInfo.Width + 5), 2);
            }
        }

        //إضافةعميلToolStripMenuItem_Click Method to Add New Customer **Done**
        private void إضافةعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (SalesAccessFRM != null) SalesAccessFRM = null;
                //Close Form
                this.Close();
                //Used btnCustomers_Click Method To Move FRM_Customers by Encapsulation is FRM_Main.ObjectMain_Property
                FRM_Main.ObjectMain_Property.btnCustomers_Click(sender, e);
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
                if (SalesAccessFRM != null) SalesAccessFRM = null;
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

        //غلقشاشةالعملاءToolStripMenuItem_Click Method To change visible of pnlCustomerInfo to False **Done**
        private void غلقشاشةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Set False Value To Visibility of pnlCustomerInfo
                pnlCustomerInfo.Visible = false;
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

        //غلقشاشةالأصنافToolStripMenuItem_Click Method To change visible of pnlItemInfo to False **Done**
        private void غلقشاشةالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Set False Value To Visibility of pnlItemInfo
                pnlItemInfo.Visible = false;
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

        //معلوماتعنالصنفtoolStripMenuItem_Click To Get Info of Items **Done**
        private void معلوماتعنالصنفtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if pnlBillInfo is Open
                if (pnlBillInfo.Visible == true)
                {
                    pnlBillInfo.Visible = false;
                }
                //Get Info of Selected Item in dgvSearch
                GetItemSelectedInfo();
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

        //إضافةصنفtoolStripMenuItem_Click Method to Add New Item **Done**
        private void إضافةصنفtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (SalesAccessFRM != null) SalesAccessFRM = null;
                //Close Form
                this.Close();
                //Used btnItems_Click(sender, e) Method To Move FRM_Items by Encapsulation is FRM_Main.ObjectMain_Property
                FRM_Main.ObjectMain_Property.btnItems_Click(sender, e);
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

        //pnlCustomerInfo_LocationChanged Method To Change Anchor of pnlCustomerInfo when change location of pnlCustomerInfo
        private void pnlCustomerInfo_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                //Set Anchor of pnlCustomerInfo is AnchorStyles.Right
                pnlCustomerInfo.Anchor = AnchorStyles.Right;
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

        //pnlItemInfo_LocationChanged Method To Change Anchor of pnlItemInfo when change location of pnlItemInfo
        private void pnlItemInfo_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                //Set Anchor of pnlSupplierInfo is AnchorStyles.Right
                pnlItemInfo.Anchor = AnchorStyles.Right;
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

        //ContextMenuStripItems_Opening Method to change visible of غلقشاشةالأصنافToolStripMenuItem **Done**
        private void contextMenuStripItems_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                // if visible of pnlItemInfo equal true
                if (pnlItemInfo.Visible == true)
                {
                    //Set true Value To Visibility for items of contextMenuStripItems
                    contextMenuStripItems.Items["غلقشاشةالأصنافToolStripMenuItem"].Visible = true;
                }
                else
                {
                    //Set False Value To Visibility for items of contextMenuStripItems
                    contextMenuStripItems.Items["غلقشاشةالأصنافToolStripMenuItem"].Visible = false;
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

        //contextMenuStripCustomer_Opening Method to change visible of غلقشاشةالعملاءToolStripMenuItem **Done**
        private void contextMenuStripCustomer_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                // if visible of pnlCustomerInfo equal true
                if (pnlCustomerInfo.Visible == true)
                {
                    //Set true Value To Visibility for items of contextMenuStripCustomer
                    contextMenuStripCustomer.Items["غلقشاشةالعملاءToolStripMenuItem"].Visible = true;
                }
                else
                {
                    //Set false Value To Visibility for items of contextMenuStripCustomer
                    contextMenuStripCustomer.Items["غلقشاشةالعملاءToolStripMenuItem"].Visible = false;
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

        //معلوماتعنالفاتورةtoolStripMenuItem_Click Method To Get Info of Bill **Done**
        private void معلوماتعنالفاتورةtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If Count Rows Of dgvSearch is less than one
            if (dgvSearch.Rows.Count < 1)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("برجاء ادخال صنف واحد للفاتورة على الأقل", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }
            else
            {
                //Check if pnlItemInfo is Open
                if (pnlItemInfo.Visible == true)
                {
                    pnlItemInfo.Visible = false;
                }
                //Change Visibility of pnlBillInfo true
                pnlBillInfo.Visible = true;
                //Change Location of pnlBillInfo =new Point (int X refers to ==> lblTotalAmount.Location.X - (pnlBillInfo.Width + 5), int y refers to ==> 2)
                pnlBillInfo.Location = new Point(lblTotalAmount.Location.X - (pnlBillInfo.Width + 5), 2);
            }
        }

        //غلقtoolStripMenuItem_Click Method To change visible of pnlBillInfo to False **Done**
        private void غلقtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Set False Value To Visibility of pnlBillInfo
                pnlBillInfo.Visible = false;
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

        //contextMenuStripBill_Opening Method to change visible of غلقtoolStripMenuItem **Done**
        private void contextMenuStripBill_Opening(object sender, CancelEventArgs e)
        {
            try
            {
                // if visible of pnlBillInfo equal true
                if (pnlBillInfo.Visible == true)
                {
                    //Set true Value To Visibility for items of contextMenuStripBill
                    contextMenuStripBill.Items["غلقtoolStripMenuItem"].Visible = true;
                }
                else
                {
                    //Set False Value To Visibility for items of contextMenuStripBill
                    contextMenuStripBill.Items["غلقtoolStripMenuItem"].Visible = false;
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

        //pnlBillInfo_LocationChanged Method To Change Anchor of pnlBillInfo when change location of pnlBillInfo
        private void pnlBillInfo_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                //Set Anchor of pnlSupplierInfo is AnchorStyles.Right
                pnlBillInfo.Anchor = AnchorStyles.Right;
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

        //btnBillInfo_Click Method To Show pnlBillInfo
        private void btnBillInfo_Click(object sender, EventArgs e)
        {
            try
            {
                //Recall معلوماتعنالفاتورةtoolStripMenuItem_Click Method to Show pnlBillInfo
                معلوماتعنالفاتورةtoolStripMenuItem_Click(sender, e);
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

        //lblAddBranch_Click Method to Add New Branch **Done**
        private void lblAddBranch_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (SalesAccessFRM != null) SalesAccessFRM = null;
                //Close Form
                this.Close();
                //Used btnBranches_Click Method To Move FRM_Branches by Encapsulation is FRM_Main.ObjectMain_Property
                FRM_Main.ObjectMain_Property.btnBranches_Click(sender, e);
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

        //lblAddStore_Click Method to Add New Store **Done**
        private void lblAddStore_Click(object sender, EventArgs e)
        {
            try
            {
                //check if field you are created is null when closed form if not Assign null value to field
                if (SalesAccessFRM != null) SalesAccessFRM = null;
                //Close Form
                this.Close();
                //Used btnStores_Click Method To Move FRM_Stores by Encapsulation is FRM_Main.ObjectMain_Property
                FRM_Main.ObjectMain_Property.btnStores_Click(sender, e);
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

        //txtItemName_TextChanged Method to Appear DgvItemSearch **Done**
        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (radBtnItemName.Checked == true && txtItemName.Text != string.Empty && ItemsClass.SearchItems("ItemName&EnglishName", txtItemName.Text).Rows.Count > 0)
                {
                    //Appear DgvItemSearch
                    dgvItemSearch.Visible = true;
                    //Set DataTable is DataSource of DataGridView search by ItemName&EnglishName
                    dgvItemSearch.DataSource = ItemsClass.SearchItems("ItemName&EnglishName", txtItemName.Text);
                }
                else
                {
                    //Disappear DgvItemSearch
                    dgvItemSearch.Visible = false;
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

        //radBtnBarcode_CheckedChanged Method to Disappear DgvItemSearch **Done**
        private void radBtnBarcode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radBtnBarcode.Checked == true)
                {
                    //Disappear DgvItemSearch
                    dgvItemSearch.Visible = false;
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

        //radBtnItemName_CheckedChanged Method to Focus on txtItemName **Done**
        private void radBtnItemName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radBtnItemName.Checked == true)
                {
                    //Focus on txtItemName
                    txtItemName.Focus();
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

        //dgvItemSearch_CellDoubleClick Method to add new Row to dgvSearch by ItemName when user doubleclick on Cell of DGV **Done**
        private void dgvItemSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Add New Row To dgvSearch by ItemName
                AddRowToDgvSearch("ItemID", dgvItemSearch.CurrentRow.Cells["ItemSearchID"].Value.ToString(), txtItemName, true);
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

        //txtItemName_KeyDown Method to add new Row to dgvSearch by ItemName when user Press on Enter Key **Done**
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if e.KeyCode equal Enter or if user Press on Enter Key
                if (e.KeyCode == Keys.Enter && dgvItemSearch.Rows.Count > 0 && txtItemName.Text != string.Empty)
                {
                    //Add New Row To dgvSearch by ItemName
                    AddRowToDgvSearch("ItemID", dgvItemSearch.CurrentRow.Cells["ItemSearchID"].Value.ToString(), txtItemName, true);
                    //Get All Calculation of Sale Bill
                    SaleBillCalculations();
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

        //txtBarcode_KeyDown Method to add new Row to dgvSearch by ItemBarcode1 when user Press on Enter Key **Done**
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if e.KeyCode equal Enter or if user Press on Enter Key
                if (e.KeyCode == Keys.Enter && txtBarcode.Text != string.Empty)
                {
                    //Add New Row To dgvSearch by ItemBarcode1
                    AddRowToDgvSearch("ItemBarcode1", txtBarcode.Text, txtBarcode, true);
                    //Get All Calculation of Sale Bill
                    SaleBillCalculations();
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

        //btnAddItem_Click Method To Add new Empty Row to dgvSearch **Done**
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Add New Empty Row to dgvSearch
                dgvSearch.Rows.Add();
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

        //dgvSearch_CellEndEdit Method to Search by ItemBarcode1 when user End Editing of Cell of dgvSearch (DataGridViewCellEndEdit) **Done**
        private void dgvSearch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if Cell of ItemBarcode of current row is not equal null and if user selected Cell of ItemBarcode of current row
                if (dgvSearch.CurrentRow.Cells["ItemBarcode"].Value != null && dgvSearch.CurrentRow.Cells["ItemBarcode"].Selected == true)
                {
                    ////Add New Row To dgvSearch by ItemBarcode1
                    AddRowToDgvSearch("ItemBarcode1", dgvSearch.CurrentRow.Cells["ItemBarcode"].Value.ToString(), null, false);
                    //Initialize null value to Cell of ItemBarcode of current row
                    dgvSearch.CurrentRow.Cells["ItemBarcode"].Value = null;
                }
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemUnitName
                    FillComboCellByItemUnit();
                    ////Get All Calculation of Sale Bill
                    SaleBillCalculations();
                }
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null and ItemExpiry Cell Of Current Row is Selected equal true
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null && dgvSearch.CurrentRow.Cells["ItemUnit"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemUnitName
                    FillComboCellByItemExpiry();
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

        //dgvSearch_SelectionChanged Method to Get All Calculation of Sale Bill  **Done**
        private void dgvSearch_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null 
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemUnitName
                    FillComboCellByItemUnit();
                    //Get All Calculation of Sale Bill
                    SaleBillCalculations();
                }
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null and ItemExpiry Cell Of Current Row is Selected equal true
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null && dgvSearch.CurrentRow.Cells["ItemUnit"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemUnitName
                    FillComboCellByItemExpiry();
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

        //dgvSearch_DataError Method To Recover Error is generated from SelectionChanged and CellEndEdit **Done**
        private void dgvSearch_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        //dgvSearch_CellClick Method To Fill ComboBox Cell of DGV By ItemUnitName when User Click on Cell **Done**
        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null 
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemUnitName
                    FillComboCellByItemUnit();
                }
                //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null and ItemExpiry Cell Of Current Row is Selected equal true
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemID"].Value != null && dgvSearch.CurrentRow.Cells["ItemUnit"].Value != null)
                {
                    //Fill ComboBox Cell of DGV By ItemExpiry
                    FillComboCellByItemExpiry();
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

        //dgvSearch_CellValidated Method To Check Saled quantity is equal or less than ItemExpiryQuantity
        private void dgvSearch_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //if Rows of DGV Greater than Zero and ItemID Cell of CurrentRow is not equal null and ItemExpiry Cell Of Current Row is Selected equal true
            if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemExpiry"].Value != null
                 && dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value != null && dgvSearch.CurrentRow.Cells["ItemQuantity"].Selected == true)
            {
                if (Convert.ToDecimal(dgvSearch.CurrentRow.Cells["ItemQuantity"].Value) > Convert.ToDecimal(dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("الكمية المباعة أكبر من الكمية المتاحة وفقاً لصلاحية الصنف", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Increase Quantity of Item by One
                    dgvSearch.CurrentRow.Cells["ItemQuantity"].Value = dgvSearch.CurrentRow.Cells["ItemExpiryQuantity"].Value;
                    //Focus on Cell ItemQuantity
                    dgvSearch.CurrentCell = dgvSearch.CurrentRow.Cells["ItemQuantity"];
                }
            }
        }

        //txtExpenses_TextChanged Method To Get All Calculation of Salebill **Done**
        private void txtExpenses_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Recall comboPayType_SelectedIndexChanged(sender, e) Method To Get All Calculation of Salebill(Cash, Postpone, Settlement)
                comboPayType_SelectedIndexChanged(sender, e);
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

        //txtDiscound_TextChanged Method To Get All Calculation of Salebill **Done**
        private void txtDiscound_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Recall comboPayType_SelectedIndexChanged(sender, e) Method To Get All Calculation of Salebill(Cash, Postpone, Settlement)
                comboPayType_SelectedIndexChanged(sender, e);
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

        //txtTotalPaid_TextChanged Method To Get All Calculation of Salebill **Done**
        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Recall comboPayType_SelectedIndexChanged(sender, e) Method To Get All Calculation of Salebill(Cash, Postpone, Settlement)
                comboPayType_SelectedIndexChanged(sender, e);
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

        //comboPayType_SelectedIndexChanged Method To Get All Calculation of Salebill(Cash, Postpone, Settlement) **Done**
        private void comboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Get All Calculation of Sale Bill
                SaleBillCalculations();
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

        //btnSave_Click Method To Save New Sale Bill **Done**
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if lblID contains last record in SaleBill table + 1 
                //lblID.Text.Contains(ItemsClass.GenerateSaleBillID()) Do not Save
                if (!lblID.Text.Contains(SaleBillClass.GenerateSaleBillID()))
                {
                    //Warning Message Box
                    NotificationSMS.NotifyShow("هذة الفاتورة تم إضتافتها من قبل", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop to executing block code
                    return;
                }

                //catchEmptyFields Int Function to return number of errors
                //and to Set Error Provider and lanuch Alarm Message Box
                //if counter of error greater than zero
                if (CatchEmptyFields() > 0)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop executing block code
                    return;
                }

                //ResetDecimalFields void Method to reset Control in pnlUnits is equal zero
                ResetDecimalFields();

                //declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();

                //(1)==> Show Payment Form To Check if Collect Amount of ReSale Invoice (A) **Done** 
                // Save Payment Amount in POSDetailsTB (B) - Update Balance Of POSTB (C) 
                //Create new instance from FRM_Payment
                FRM_Payment PayFRM = new FRM_Payment();
                //Initialize Value To Payment Form 
                PayFRM.InitializePayment(comboPayType.Text, lblTitle.Text, lblID.Text, lblTotalAmount.Text, txtTotalPaid.Text,
                                          lblTotalRemain.Text);
                //Show this instance (PayFRM) in mode ShowDialog to control it as first
                PayFRM.ShowDialog();

                // (2)===>Save Sale Bill contains Three steps
                //Save Head of SaleBill - SaleBill Table ***Done***
                SaveSaleBillTable(IP_PCName);
                //(3)===>Save All item of SaleBill by use for loop   SaleDetails Table ***Done***
                SaveSaleDetailsTable(IP_PCName);
                //(4)===>Save All item of SaleBill by use for loop  (ItemOperations Table) ***Done***
                SaveItemOperationsTable(IP_PCName);
                //(5)===>Update Balance of ItemQuantity Update Items Table ***Done***
                UpdateItemQuantity(IP_PCName);
                //(6)===>Update Balance of Customer  Add Postpone SaleBill To CustomerAccount Table ***Done***
                AddBillToCustomerAccount(IP_PCName);
                //(7)===>Update Balance of Customer Update Customers Table ***Done***
                UpdateCustomerBalance(IP_PCName);
                
                

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ الفاتورة بنجاح", "عملية الحفظ",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();


                //(8) ==> Recall BtnPrint To Print ReSaleBill Invoice **Done** 
                //Show Notification of System Message Question Message To Print ReSaleBill Invoice - Question Message Box
                NotificationSMS.NotifyShow("هل تريد طباعة فاتورة الشراء ؟", "الطباعة",
                    FRM_Notifications.NotifyButtons.YesNo, FRM_Notifications.NotifyIcons.Question,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Check If User Press Yes To Print Sale Invoice **Done** 
                if (NotificationSMS.NotifyResult == true)
                {
                    //Recall BtnPrint To Print ReSaleBill Invoice
                    btnPrint_Click(sender, e);
                }
                //Recall Btn New to clear Controls
                btnNew_Click(sender, e);
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

        //dgvSearch_KeyDown Method To Increase/Decrease ItemQuantity by one if user key Down on F1/F3 **Done**
        private void dgvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Stop Executing block code if dgvSearch.Rows.Count less than 1
                if (dgvSearch.Rows.Count < 1) return;

                ////To Movement Next Cell of the Same Row in dgvSearch
                ControlCellMovementsOfDgv(e);

                //if user selected cell ItemQuantity is equal true and Count of Rows dgv is Greater than 0
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemQuantity"].Selected == true)
                {
                    //if User Key Down on F1
                    if (e.KeyCode == Keys.F1)
                    {
                        //Increase Quantity of Item by One
                        dgvSearch.CurrentRow.Cells["ItemQuantity"].Value = Convert.ToInt32(dgvSearch.CurrentRow.Cells["ItemQuantity"].Value) + 1;
                        //Focus on Cell ItemQuantity
                        dgvSearch.CurrentCell = dgvSearch.CurrentRow.Cells["ItemQuantity"];
                    }
                    //if User Key Down on F3
                    else if (e.KeyCode == Keys.F3)
                    {
                        //Stop Executing block code if ItemQuantity less than 2
                        if (Convert.ToInt32(dgvSearch.CurrentRow.Cells["ItemQuantity"].Value) < 2) return;
                        //Increase Quantity of Item by One
                        dgvSearch.CurrentRow.Cells["ItemQuantity"].Value = Convert.ToInt32(dgvSearch.CurrentRow.Cells["ItemQuantity"].Value) - 1;
                        //Focus on Cell ItemQuantity
                        dgvSearch.CurrentCell = dgvSearch.CurrentRow.Cells["ItemQuantity"];
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

        //dgvSearch_CellEnter Method To Set ReadOnly is true for Cells of dgvSearch when user add new item by ItemBarcode Way
        private void dgvSearch_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Control of ReadOnly is true for Cells of dgvSearch when user add new item by ItemBarcode Way
                ControlCellEditingOfDgv();
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

        //dgvSearch_CellContentClick To Delete Current Row of DGV or Item **Done**
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Stop Executing block code if dgvSearch.Rows.Count less than 1
                if (dgvSearch.Rows.Count < 1) return;
                //if user selected cell btnDgvDelete is equal true
                if (dgvSearch.CurrentRow.Cells["btnDgvDelete"].Selected == true)
                {
                    //Remove Current Row of dgv or item
                    dgvSearch.Rows.RemoveAt(dgvSearch.CurrentRow.Index);
                    //Get All Calculation of Sale Bill
                    SaleBillCalculations();
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

        //dgvSearch_KeyUp Method To Get Calculations if user key Up of F1/F3 and Focus on cell ItemQuantity **Done**
        private void dgvSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if user selected cell ItemQuantity is equal true and Count of Rows dgv is Greater than 0
                if (dgvSearch.Rows.Count > 0 && dgvSearch.CurrentRow.Cells["ItemQuantity"].Selected == true)
                {
                    //if User Key Down on F1
                    if (e.KeyCode == Keys.F1)
                    {
                        //Get All Calculation of Sale Bill
                        SaleBillCalculations();
                    }
                    //if User Key Down on F3
                    else if (e.KeyCode == Keys.F3)
                    {
                        //Get All Calculation of Sale Bill
                        SaleBillCalculations();
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

        //txtExpenses_KeyDown Method to Move Next Control
        private void txtExpenses_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if user press on enter key
                if (e.KeyCode == Keys.Enter)
                {
                    //Focus on txtDiscound
                    txtDiscound.Focus();
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

        //txtExpenses_KeyDown Method to Move Next Control
        private void txtDiscound_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if user press on enter key
                if (e.KeyCode == Keys.Enter && comboPayType.SelectedIndex != 1)
                {
                    //Focus on txtTotalPaid
                    txtTotalPaid.Focus();
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

        //btnPrint_Click Method To Print New Sales Bill **Done**
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ////Check if lblID.Text is Empty or Rows of dgvSearch is equal zero
                //if (lblID.Text == string.Empty || dgvSearch.Rows.Count == 0)
                //{
                //    //Warning Message Box
                //    NotificationSMS.NotifyShow("سيتم الانتقال الى بحث فواتير البيع لتحديد الفاتورة ثم طباعتها", "تنبية",
                //        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                //        FRM_Notifications.NotifyTypes.NotifyBtn);
                //    //Show Notification Message in Dialog Mode
                //    NotificationSMS.ShowDialog();

                //    //check if field you are created is null when closed form if not Assign null value to field
                //    if (SalesAccessFRM != null) SalesAccessFRM = null;
                //    //Close Form
                //    this.Close();
                //    //Used btnBranches_Click Method To Move SalesSearch by Encapsulation is FRM_Main.ObjectMain_Property
                //    FRM_Main.ObjectMain_Property.btnSalesSearch_Click(sender, e);
                //    //Stop to executing block code
                //    return;
                //}

                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_SalesViewerRpt is Form Viewer
                RPT.FRM_SalesViewerRpt SaleBillViewerFrm = new RPT.FRM_SalesViewerRpt();
                //Create New Instance From RPT.SalesRpt is Report
                RPT.SalesRpt SaleBillReport = new RPT.SalesRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                SaleBillViewerFrm.crystalRptViewerSales.ReportSource = SaleBillReport;
                ////Set Values to Parameters of Report
                //Initialize Value of Parameter field SearchKey is equal Convert.ToInt32(lblID.Text.Remove(0,5)))
                SaleBillReport.SetParameterValue("@SearchKey", Convert.ToInt32(lblID.Text.Remove(0, 5)));

                //Refresh crystalRptViewerSales
                SaleBillViewerFrm.crystalRptViewerSales.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                SaleBillViewerFrm.ShowDialog();
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

        //lblCustCompany_MouseHover Method To SetToolTip On Control when user Hover on Control **Done**
        private void lblCustCompany_MouseHover(object sender, EventArgs e)
        {
            //SetToolTip Of toolTipSales (Control, string Caption or tip)
            toolTipSales.SetToolTip(lblCustCompany, lblCustCompany.Text);
        }

        //lblCustAddress_MouseHover Method To SetToolTip On Control when user Hover on Control **Done**
        private void lblCustAddress_MouseHover(object sender, EventArgs e)
        {
            //SetToolTip Of toolTipSales (Control, string Caption or tip)
            toolTipSales.SetToolTip(lblCustAddress, lblCustAddress.Text);
        }

        #endregion
        
    }
}
