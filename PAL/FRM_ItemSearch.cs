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
    public partial class FRM_ItemSearch : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_Items Business Access Layer
        readonly BAL.CLS_Items ItemsClass = new BAL.CLS_Items();
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

        //Constructor OF FRM_ItemSearch
        public FRM_ItemSearch()
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
            //Intialize DataSource of DGV is ItemsClass.ShowItemsTable();
            dgvSearch.DataSource = ItemsClass.ShowItemsTable();
        }

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //Declare new string [] array of Items Search
            string[] strSearchItems = new string[]
                    {
                        "كود الصنف","اسم الصنف", "الاسم بالانجليزى", "باركود الصنف","تاريخ الانتاج",
                        "تاريخ الصلاحية","الشكل الدوائى","المادة الفعالة","القسم الطبى",
                        "المجموعة العلمية","الشركة المنتجة","مكان التخزين", "حالة الصنف"
                    };

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

        /// <summary>
        /// bool Function to check any Form Openned except Form Main
        /// Return True if Argument form name is openned except Main Form
        /// Return False if Form Main Only is Openned
        /// <returns>Return true or false</returns>
        /// </summary>
        /// <param name="frmName">Form Name</param>
        /// <returns></returns>
        private bool CheckFormOpenned(string frmName)
        {
            //Loop in all forms in Application.OpenForms
            foreach (Form frm in Application.OpenForms)
            {
                // if Form.Name is not equal Main Form
                if (frm.Name != "FRM_Main" && frm.Name != "FRM_Intro")
                {
                    //Check if Purchases Form Opened
                    if (frm.Name == frmName)
                    {
                        //Return True
                        return true;
                    }
                }
            }
            // if Main Form is openned Only Return False
            return false;
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
            if (comboSearch.SelectedIndex >= 0 && comboSearch.SelectedIndex != 12)
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
            else if (comboSearch.SelectedIndex == 12)
            {
                if (txtSearch.Visible == false)
                {
                    radBtnActive.Text = "الأصناف النشطة";
                    radBtnDeactive.Text = "الأصناف الغير نشطة";
                }
                else
                {
                    txtSearch.Visible = false;
                    radBtnActive.Text = "الأصناف النشطة";
                    radBtnDeactive.Text = "الأصناف الغير نشطة";
                    radBtnActive.Visible = true;
                    radBtnDeactive.Visible = true;
                }
            }
        }

        //txtSearch_KeyDown Method to search in Companies table Advance Way when user press enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if user press on Enter Key of Keyboard
                if (e.KeyCode == Keys.Enter)
                {
                    //if txtSearch.Text is not equal string.Empty
                    if (txtSearch.Text != string.Empty)
                    {
                        //switch conditional statement (string) {Case "valueofstring": break;}
                        //Search based on ColumnName
                        switch (comboSearch.Text)
                        {
                            case "كود الصنف":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by ItemCustomCode
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemCustomCode", txtSearch.Text);
                                break;
                            case "اسم الصنف":
                                //Set DataTable is DataSource of DataGridView search by ItemName
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemName", txtSearch.Text);
                                break;
                            case "الاسم بالانجليزى":
                                //Set DataTable is DataSource of DataGridView search by ItemEnglishName
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemEnglishName", txtSearch.Text);
                                break;
                            case "باركود الصنف":
                                //Set DataTable is DataSource of DataGridView search by ItemBarcode1
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemBarcode1", txtSearch.Text);
                                break;
                            case "تاريخ الانتاج":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by ItemManufactureDate
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemManufactureDate", txtSearch.Text);
                                break;
                            case "تاريخ الصلاحية":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by ItemExpiryDate
                                dgvSearch.DataSource = ItemsClass.SearchItems("ItemExpiryDate", txtSearch.Text);
                                break;
                            case "الشكل الدوائى":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by DosageFormName
                                dgvSearch.DataSource = ItemsClass.SearchItems("DosageFormName", txtSearch.Text);
                                break;
                            case "المادة الفعالة":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by GenericName
                                dgvSearch.DataSource = ItemsClass.SearchItems("GenericName", txtSearch.Text);
                                break;
                            case "القسم الطبى":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by ClassOfActionName
                                dgvSearch.DataSource = ItemsClass.SearchItems("ClassOfActionName", txtSearch.Text);
                                break;
                            case "المجموعة العلمية":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by GroupName
                                dgvSearch.DataSource = ItemsClass.SearchItems("GroupName", txtSearch.Text);
                                break;
                            case "الشركة المنتجة":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by CompanyName
                                dgvSearch.DataSource = ItemsClass.SearchItems("CompanyName", txtSearch.Text);
                                break;
                            case "مكان التخزين":
                                //Recall DataTable Fucation from BAL (Business Access Layer) to SearchItems by txtSearch.Text
                                //Set DataTable is DataSource of DataGridView search by PlaceName
                                dgvSearch.DataSource = ItemsClass.SearchItems("PlaceName", txtSearch.Text);
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
                        //Set ShowCompaniesTable is DataSource of DataGridView (all Items table)
                        dgvSearch.DataSource = ItemsClass.ShowItemsTable();
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

        //dgvSearch_CellContentClick Method to show selected Company or print selected Company CellContentClick 
        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if the index of row greater than or equal zero and Purchase Form is Opened
                if (e.RowIndex >= 0 && e.ColumnIndex == 0 && CheckFormOpenned("FRM_Purchases"))
                {
                    //Add New Row To dgvSearch by ItemCustomCode
                    FRM_Purchases.PurchasesAccess_Property.AddRowToDgvSearch("ItemCustomCode", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString(), null, true);
                    //Get All Calculation of Purchase Bill
                    FRM_Purchases.PurchasesAccess_Property.BuyBillCalculations();
                    //Stop Executing Block Code
                    return;
                }

                //if the index of row greater than or equal zero and Sales Form is Opened
                if (e.RowIndex >= 0 && e.ColumnIndex == 0 && CheckFormOpenned("FRM_Sales"))
                {
                    //Add New Row To dgvSearch by ItemCustomCode
                    FRM_Sales.SalesAccess_Property.AddRowToDgvSearch("ItemCustomCode", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString(), null, true);
                    //Get All Calculation of Sales Bill
                    FRM_Sales.SalesAccess_Property.SaleBillCalculations();
                    //Stop Executing Block Code
                    return;
                }


                //if the index of row greater than or equal zero and index of button column Search btn is 0 ShowBtn 
                //and Purchase Form is Not Opened
                if (e.RowIndex >= 0 && e.ColumnIndex == 0 && !CheckFormOpenned("FRM_Purchases"))
                {
                    //Use Encapsulation of FRM_Stores or Property to control of all controls of FRM from anothor form
                    //Hide Icon of errProviderItems by clear it 
                    FRM_Items.ItemAccess_Property.errProviderItems.Clear();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemID"].Value to lblID.text
                    FRM_Items.ItemAccess_Property.lblID.Text = dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemName"].Value to txtName.txtItemName
                    FRM_Items.ItemAccess_Property.txtItemName.Text = dgvSearch.CurrentRow.Cells["ItemName"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemEngName"].Value to txtItemEngName.Text
                    FRM_Items.ItemAccess_Property.txtItemEngName.Text = dgvSearch.CurrentRow.Cells["ItemEngName"].Value.ToString();

                    //Recall Method to comboDosageForm_DropDown(object sender, EventArgs e) To Load DosageForm Table
                    FRM_Items.ItemAccess_Property.comboDosageForm_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemDosageFormID"].Value to comboDosageForm.SelectedText
                    FRM_Items.ItemAccess_Property.comboDosageForm.SelectedValue = dgvSearch.CurrentRow.Cells["ItemDosageFormID"].Value;

                    //Recall Method to comboGenerics_DropDown(object sender, EventArgs e) To Load Generics Table
                    FRM_Items.ItemAccess_Property.comboGenerics_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemGenericID"].Value to comboGenerics.SelectedText
                    FRM_Items.ItemAccess_Property.comboGenerics.SelectedValue = dgvSearch.CurrentRow.Cells["ItemGenericID"].Value;


                    //Recall Method to comboClassOfActions_DropDown(object sender, EventArgs e) To Load ClassOfActions Table
                    FRM_Items.ItemAccess_Property.comboClassOfActions_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemClassOfActionID"].Value to comboClassOfActions.SelectedValue
                    FRM_Items.ItemAccess_Property.comboClassOfActions.SelectedValue = dgvSearch.CurrentRow.Cells["ItemClassOfActionID"].Value;


                    //Recall Method to comboGroups_DropDown(object sender, EventArgs e) To Load Groups Table
                    FRM_Items.ItemAccess_Property.comboGroups_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemGroupID"].Value to comboGroups.SelectedText
                    FRM_Items.ItemAccess_Property.comboGroups.SelectedValue = dgvSearch.CurrentRow.Cells["ItemGroupID"].Value;


                    //Recall Method to comboPlaces_DropDown(object sender, EventArgs e) To Load Places Table
                    FRM_Items.ItemAccess_Property.comboPlaces_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemPlaceID"].Value to comboPlaces.SelectedText
                    FRM_Items.ItemAccess_Property.comboPlaces.SelectedValue = dgvSearch.CurrentRow.Cells["ItemPlaceID"].Value;


                    //Recall Method to comboCompanies_DropDown(object sender, EventArgs e) To Load Companies Table
                    FRM_Items.ItemAccess_Property.comboCompanies_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemCompanyID"].Value to comboCompanies.SelectedText
                    FRM_Items.ItemAccess_Property.comboCompanies.SelectedValue = dgvSearch.CurrentRow.Cells["ItemCompanyID"].Value;


                    //Recall Method to comboItemLargeUnit_DropDown(object sender, EventArgs e) To Load Units Table
                    FRM_Items.ItemAccess_Property.comboItemLargeUnit_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemLargeUnit"].Value to comboItemLargeUnit.SelectedText
                    FRM_Items.ItemAccess_Property.comboItemLargeUnit.SelectedValue = dgvSearch.CurrentRow.Cells["ItemLargeUnit"].Value;

                    //Recall Method to comboItemMediumUnit_DropDown(object sender, EventArgs e) To Load Units Table
                    FRM_Items.ItemAccess_Property.comboItemMediumUnit_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemMediumUnit"].Value to comboItemMediumUnit.SelectedText
                    FRM_Items.ItemAccess_Property.comboItemMediumUnit.SelectedValue = dgvSearch.CurrentRow.Cells["ItemMediumUnit"].Value.ToString();

                    //Recall Method to comboItemSmallUnit_DropDown(object sender, EventArgs e) To Load Units Table
                    FRM_Items.ItemAccess_Property.comboItemSmallUnit_DropDown(sender, e);
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemSmallUnit"].Value to comboItemSmallUnit.SelectedText
                    FRM_Items.ItemAccess_Property.comboItemSmallUnit.SelectedValue = dgvSearch.CurrentRow.Cells["ItemSmallUnit"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemLargeUnitNo"].Value to txtItemLargeUnitNo.Text
                    FRM_Items.ItemAccess_Property.txtItemLargeUnitNo.Text = dgvSearch.CurrentRow.Cells["ItemLargeUnitNo"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemMediumUnitNo"].Value to txtItemMediumUnitNo.Text
                    FRM_Items.ItemAccess_Property.txtItemMediumUnitNo.Text = dgvSearch.CurrentRow.Cells["ItemMediumUnitNo"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemSmallUnitNo"].Value to txtItemSmallUnitNo.Text
                    FRM_Items.ItemAccess_Property.txtItemSmallUnitNo.Text = dgvSearch.CurrentRow.Cells["ItemSmallUnitNo"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemLargeUnitSale"].Value to txtLargeUnitSalePrice.Text
                    FRM_Items.ItemAccess_Property.txtLargeUnitSalePrice.Text = dgvSearch.CurrentRow.Cells["ItemLargeUnitSale"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemMediumUnitSale"].Value to txtMediumUnitSalePrice.Text
                    FRM_Items.ItemAccess_Property.txtMediumUnitSalePrice.Text = dgvSearch.CurrentRow.Cells["ItemMediumUnitSale"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemSmallUnitSale"].Value to txtSmallUnitSalePrice.Text
                    FRM_Items.ItemAccess_Property.txtSmallUnitSalePrice.Text = dgvSearch.CurrentRow.Cells["ItemSmallUnitSale"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemLargeUnitBuy"].Value to txtLargeUnitBuyPrice.Text
                    FRM_Items.ItemAccess_Property.txtLargeUnitBuyPrice.Text = dgvSearch.CurrentRow.Cells["ItemLargeUnitBuy"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemMediumUnitBuy"].Value to txtMediumUnitBuyPrice.Text
                    FRM_Items.ItemAccess_Property.txtMediumUnitBuyPrice.Text = dgvSearch.CurrentRow.Cells["ItemMediumUnitBuy"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemSmallUnitBuy"].Value to txtSmallUnitBuyPrice.Text
                    FRM_Items.ItemAccess_Property.txtSmallUnitBuyPrice.Text = dgvSearch.CurrentRow.Cells["ItemSmallUnitBuy"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemLargeUnitBal"].Value to txtLargeUnitBalance.Text
                    FRM_Items.ItemAccess_Property.txtLargeUnitBalance.Text = dgvSearch.CurrentRow.Cells["ItemLargeUnitBal"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemMediumUnitBal"].Value to txtMediumUnitBalance.Text
                    FRM_Items.ItemAccess_Property.txtMediumUnitBalance.Text = dgvSearch.CurrentRow.Cells["ItemMediumUnitBal"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemSmallUnitBal"].Value to txtSmallUnitBalance.Text
                    FRM_Items.ItemAccess_Property.txtSmallUnitBalance.Text = dgvSearch.CurrentRow.Cells["ItemSmallUnitBal"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemBarcode1"].Value to txtItemBarcode1.Text
                    FRM_Items.ItemAccess_Property.txtItemBarcode1.Text = dgvSearch.CurrentRow.Cells["ItemBarcode1"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemBarcode2"].Value to txtItemBarcode2.Text
                    FRM_Items.ItemAccess_Property.txtItemBarcode2.Text = dgvSearch.CurrentRow.Cells["ItemBarcode2"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemBarcode3"].Value to txtItemBarcode3.Text
                    FRM_Items.ItemAccess_Property.txtItemBarcode3.Text = dgvSearch.CurrentRow.Cells["ItemBarcode3"].Value.ToString();

                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemDemandLimit"].Value to txtItemLimit.Text
                    FRM_Items.ItemAccess_Property.txtItemLimit.Text = dgvSearch.CurrentRow.Cells["ItemDemandLimit"].Value.ToString();
                    //Set Value of Search dgvSearch.CurrentRow.Cells["ItemDiscound"].Value to .txtItemDiscound.Text
                    FRM_Items.ItemAccess_Property.txtItemDiscound.Text = dgvSearch.CurrentRow.Cells["ItemDiscound"].Value.ToString();


                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemMedicine"].Value) to checkedlistbox ==> checkboxMedicine
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(0, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemMedicine"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemAccessories"].Value) to checkedlistbox ==> checkboxAccessories
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(1, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemAccessories"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemLocal"].Value) to checkedlistbox ==> checkboxLocal
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(2, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemLocal"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemImported"].Value) to checkedlistbox ==> checkboxImported
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(3, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemImported"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemExpiry"].Value) to checkedlistbox ==> checkboxExpiry
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(4, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemExpiry"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemDrug"].Value) to checkedlistbox ==> checkboxDrug
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(5, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemDrug"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemRefragated"].Value) to checkedlistbox ==> checkboxRefragated
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(6, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemRefragated"].Value));
                    //Set Value of Search Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemUncommon"].Value) to checkedlistbox ==> checkboxUncommon
                    FRM_Items.ItemAccess_Property.checkListTypeItems.SetItemChecked(7, Convert.ToBoolean(dgvSearch.CurrentRow.Cells["ItemUncommon"].Value));


                    //Check if ItemExpiry is checked is true
                    if (FRM_Items.ItemAccess_Property.checkListTypeItems.GetItemChecked(4) == true)
                    {
                        //Recall checkListTypeItems_SelectedIndexChanged Method to Set Date of Expiry
                        FRM_Items.ItemAccess_Property.checkListTypeItems_SelectedIndexChanged(sender, e);
                        //Set Value of Search dgvSearch.CurrentRow.Cells["ItemManufactureDate"].Value to dtpManuDate.Value
                        FRM_Items.ItemAccess_Property.dtpManuDate.Value = Convert.ToDateTime(dgvSearch.CurrentRow.Cells["ItemManufactureDate"].Value);
                        //Set Value of Search dgvSearch.CurrentRow.Cells["ItemExpiryDate"].Value to dtpExpiryDate.Value
                        FRM_Items.ItemAccess_Property.dtpExpiryDate.Value = Convert.ToDateTime(dgvSearch.CurrentRow.Cells["ItemExpiryDate"].Value);
                    }



                    //if User Status is deactivate or dgvSearch.CurrentRow.Cells["ItemStatus"].Value is false
                    if (dgvSearch.CurrentRow.Cells["ItemStatus"].Value.ToString() == "false")
                    {
                        //Initialize True Value to Visible of lblItemStatus
                        FRM_Items.ItemAccess_Property.lblItemStatus.Visible = true;
                        //Initialize True Value to Visible of lblItemActivate
                        FRM_Items.ItemAccess_Property.lblItemActivate.Visible = true;
                        //Initialize Text Value of lblUserStatus
                        FRM_Items.ItemAccess_Property.lblItemStatus.Text = "صنف غير نشط";
                        //Initialize False Value to Enabled of btnDelete
                        FRM_Items.ItemAccess_Property.btnDelete.Enabled = false;
                        //Initialize False Value to Enabled of btnModify
                        FRM_Items.ItemAccess_Property.btnModify.Enabled = false;
                        //Fire Timer or Lanuch timer to start
                        FRM_Items.ItemAccess_Property.timerItems.Start();
                        //Initialize True Value to Enabled of timerUsers
                        FRM_Items.ItemAccess_Property.timerItems.Enabled = true;
                        //Close Search Form
                        this.Close();
                    }
                    else //if User Status is Activate or dgvSearch.CurrentRow.Cells["UserStatus"].Value is true
                    {
                        //Initialize false Value to Visible of lblItemStatus
                        FRM_Items.ItemAccess_Property.lblItemStatus.Visible = false;
                        //Initialize false Value to Visible of lblItemActivate
                        FRM_Items.ItemAccess_Property.lblItemActivate.Visible = false;
                        //Initialize true Value to Enabled of btnDelete
                        FRM_Items.ItemAccess_Property.btnDelete.Enabled = true;
                        //Initialize False true to Enabled of btnModify
                        FRM_Items.ItemAccess_Property.btnModify.Enabled = true;
                        //Stop Timer
                        FRM_Items.ItemAccess_Property.timerItems.Stop();
                        //Initialize false Value to Enabled of timerItems
                        FRM_Items.ItemAccess_Property.timerItems.Enabled = false;
                        //Close Search Form
                        this.Close();
                    }
                }
                //if the index of row greater than or equal zero and index of Image column Print btn is 1
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    //Change Cursor to wait Cursor
                    this.Cursor = Cursors.WaitCursor;
                    //Create New Instance From  RPT.FRM_ItemsViewerRpt is Form Viewer
                    RPT.FRM_ItemsViewerRpt ItemViewerFrm = new RPT.FRM_ItemsViewerRpt();
                    //Create New Instance From RPT.ItemsRpt is Report
                    RPT.ItemsRpt ItemReport = new RPT.ItemsRpt();
                    //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                    ItemViewerFrm.crystalRptViewerItems.ReportSource = ItemReport;
                    //Initialize SetDataSource of Report (DataSet or DataTable) Search by selected Row "ItemID" 
                    ItemReport.SetDataSource(ItemsClass.SearchItems("ItemCustomCode", dgvSearch.CurrentRow.Cells["ItemID"].Value.ToString()));
                    //Refresh of Report
                    ItemReport.Refresh();
                    //Show Form Report Viewer in mode Dialog to control it as first
                    ItemViewerFrm.ShowDialog();
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

        //btnPrintAll_Click Method To Print All Companies
        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                //Change Cursor to wait Cursor
                this.Cursor = Cursors.WaitCursor;
                //Create New Instance From  RPT.FRM_ItemsViewerRpt is Form Viewer
                RPT.FRM_ItemsViewerRpt ItemViewerFrm = new RPT.FRM_ItemsViewerRpt();
                //Create New Instance From RPT.ItemsRpt is Report
                RPT.ItemsRpt ItemReport = new RPT.ItemsRpt();
                //Initialize ReportSource of CrystalReportViewer is Instance which you are created ItemReport
                ItemViewerFrm.crystalRptViewerItems.ReportSource = ItemReport;
                //Initialize SetDataSource of Report (DataSet or DataTable) Search by (empty value) to prints all Companies
                ItemReport.SetDataSource(ItemsClass.ShowItemsTable());
                //Refresh Report
                ItemReport.Refresh();
                //Show Form Report Viewer in mode Dialog to control it as first
                ItemViewerFrm.ShowDialog();
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

        //radBtnActive_CheckedChanged Method to Search by CompanyStatus
        private void radBtnActive_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnActive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = ItemsClass.SearchItems("ItemStatus", "1");
            }
        }

        //radBtnDeactive_CheckedChanged Method to Search by CompanyStatus
        private void radBtnDeactive_CheckedChanged(object sender, EventArgs e)
        {
            //True is equal 1 and false is equal 0
            if (radBtnDeactive.Checked == true && comboSearch.SelectedIndex == 6)
            {
                dgvSearch.DataSource = ItemsClass.SearchItems("ItemStatus", "0");
            }
        }

        #endregion
    }
}
