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
    public partial class FRM_Payment : Form
    {
        #region Public Declarations
        //Create New Instance From BAL.CLS_POS Business Access Layer
        readonly BAL.CLS_POS PointOfSaleClass = new BAL.CLS_POS();
        //Create New Instance From BAL.CLS_POSDetails Business Access Layer
        readonly BAL.CLS_POSDetails POSDetailsClass = new BAL.CLS_POSDetails();
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
        public FRM_Payment()
        {
            InitializeComponent();
            //ClearControls();
            ClearControls();
        }

        #region Methods and Functions

        /// <summary>
        /// Void Method To Clear Controls
        /// </summary>
        private void ClearControls()
        {
            //loop in all control in side this.gbContainer.Controls
            foreach (Control ctrl in gbContainer.Controls)
            {
                if (ctrl is Label && !ctrl.Text.Contains(":"))
                {
                    ctrl.Text = "0";
                }
                else if (ctrl is TextBox)
                {
                    ctrl.Text = "0";
                }
                else if (ctrl is ComboBox)
                {
                    ctrl.Text = null;
                }
            }
            //Generate new POSDetail ID by use Fuction ToString ("strFormat-0000 every zero represents number)
            lblPOSDetailCode.Text = POSDetailsClass.GeneratePOSDetailID().ToString("POSD-000000");
            //Initialize Value DateTime.Now To lblPOSDetailDate
            lblPOSDetailDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        /// <summary>
        /// Initialize Values To Payment Form
        /// </summary>
        /// <param name="billType">billType</param>
        /// <param name="billName">billName</param>
        /// <param name="billID">billID</param>
        /// <param name="requiredAmount">requiredAmount</param>
        /// <param name="paidAmount">paidAmount</param>
        /// <param name="remainAmount">remainAmount</param>
        public void InitializePayment(string billType,string billName, string billID, string requiredAmount,
                                      string paidAmount, string remainAmount)
        {
            comboPayType.Text = billType;
            lblPOSDetailBillType.Text = billName.Remove(0,5);
            lblPOSDetailBillID.Text = billID;
            lblPOSDetailRequired.Text = requiredAmount;
            txtPOSDetailPaid.Text = paidAmount;
            lblPOSDetailRemain.Text = remainAmount;
        }

        /// <summary>
        /// Update Balance oF POS in PointOfSale Table
        /// </summary>
        private void UpdateBalanceOfPOS()
        {
            //(1)===> declare string variable to store pc name and ip address
            string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
            //(2)===> declare decimal variable to store Current Balance of POS (PointOfSale)
            decimal posBalance = 0;

            //(3)===> Check Type of Payment or Bill To Get Current Balance of POS (PointOfSale)
            //IF Invoice Is PurchasesBill
            if (lblPOSDetailBillType.Text == "المشتريات")
            {
                //IF Invoice Is PurchasesBill you will pay amount of Invoice
                // الرصيد الحالى للخزينة - المبلغ المدفوع مقابل الشراء = رصيد الخزينة
                posBalance = Convert.ToDecimal(lblPOSBalance.Text) - Convert.ToDecimal(txtPOSDetailPaid.Text);
            }
            //IF Invoice Is RepurchasesBill
            else if (lblPOSDetailBillType.Text == "مرتجع المشتريات")
            {
                //IF Invoice Is RepurchasesBill you will pay amount of Invoice
                // الرصيد الحالى للخزينة + المبلغ المحصل مقابل مرتجع الشراء = رصيد الخزينة
                posBalance = Convert.ToDecimal(lblPOSBalance.Text) + Convert.ToDecimal(txtPOSDetailPaid.Text);
            }
            //IF Invoice Is SalesBill
            else if (lblPOSDetailBillType.Text == "المبيعات")
            {
                //IF Invoice Is SalesBill you will pay amount of Invoice
                // الرصيد الحالى للخزينة + المبلغ المحصل مقابل مرتجع الشراء = رصيد الخزينة
                posBalance = Convert.ToDecimal(lblPOSBalance.Text) + Convert.ToDecimal(txtPOSDetailPaid.Text);
            }
            //IF Invoice Is ReSalesBill
            else if (lblPOSDetailBillType.Text == "مرتجع المبيعات")
            {
                //IF Invoice Is ReSalesBill you will pay amount of Invoice
                // الرصيد الحالى للخزينة - المبلغ المحصل مقابل مرتجع الشراء = رصيد الخزينة
                posBalance = Convert.ToDecimal(lblPOSBalance.Text) - Convert.ToDecimal(txtPOSDetailPaid.Text);
            }

            //(4)===> Update Balance oF POS in PointOfSale Table
            PointOfSaleClass.UpdatePOS(Convert.ToInt32(comboPOSName.SelectedValue), comboPOSName.Text, posBalance, IP_PCName, Program.UsrID);
        }

        /// <summary>
        /// Fill ComboBox By Point of sales Table
        /// </summary>
        private void FillComboByPOSTB()
        {
            //Initialize DataSource of combo is PointOfSaleClass.ShowPOSTable();
            comboPOSName.DataSource = PointOfSaleClass.ShowPOSTable();
            //Initialize DisplayMember of combo is POSName
            comboPOSName.DisplayMember = "اسم نقطة البيع";
            //Initialize ValueMember of combo is POSID
            comboPOSName.ValueMember = "الكود الداخلى";
            //To Clear ComboBox of comboPOSName by selected index equal -1  
            comboPOSName.SelectedIndex = -1;
        }

        /// <summary>
        /// CheckValidationOfPayment Method To Check Validation of comboPayType And comboPOSName
        /// </summary>
        private bool CheckValidationOfPayment()
        {
            if (comboPayType.SelectedIndex == -1)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("يلزم تحديد طريقة الدفع", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Focus On comboPayType
                comboPayType.Focus();

                //Return true If Catch error
                return true;
            }
            else if (comboPOSName.SelectedIndex == -1)
            {
                //Warning Message Box
                NotificationSMS.NotifyShow("يلزم تحديد نقطة البيع أو الخزينة", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Focus On comboPayType
                comboPOSName.Focus();

                //Return true If Catch error
                return true;
            }
            //Return false If Not Catch error
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

        //comboPOSName_SelectedIndexChanged Method to Get POS Balance  **Done**
        private void comboPOSName_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                // if comboPOSName.SelectedIndex is not equal Empty
                if (comboPOSName.SelectedIndex != -1)
                {
                    //Get POS Balance
                    lblPOSBalance.Text = PointOfSaleClass.SearchPOS("POSID", comboPOSName.SelectedValue.ToString()).Rows[0]["الرصيد الحالى"].ToString();
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

        //lblAddPOSName_Click Method To Open FRM_PointOfSales Form **Done**
        private void lblAddPOSName_Click(object sender, EventArgs e)
        {
            //Create new instance from FRM_PointOfSales
            FRM_PointOfSales SearchForm = new FRM_PointOfSales();
            //Show this instance in mode ShowDialog to control it as first
            SearchForm.ShowDialog();
        }

        //btnSave_Click Method To Save Payment or Financial Deposit For any Bill In POSDetails Table and Update Balance oF POS in PointOfSale Table
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Check Validation if Catch any error stop executing block code
                if (CheckValidationOfPayment() == true) return;
                //(1)===> declare string variable to store pc name and ip address
                string IP_PCName = "PC Name- " + Environment.MachineName + " IP- " +
                    Dns.GetHostAddresses(Environment.MachineName)[0].ToString();
                //(2)===> Save Payment or Financial Deposit IF Paid or Collect For any Bill In POSDetails Table
                //(PurchasesBill - RepurchasesBill - SalesBill - ReSalesBill)
                POSDetailsClass.SavePOSDetail(POSDetailsClass.GeneratePOSDetailID(), Convert.ToInt32(lblPOSDetailBillID.Text.Remove(0, 5)), lblPOSDetailBillType.Text, lblPOSDetailCode.Text, Convert.ToInt32(comboPOSName.SelectedValue), comboPayType.Text, Convert.ToDecimal(lblPOSDetailRequired.Text), Convert.ToDecimal(txtPOSDetailPaid.Text),
                    Convert.ToDecimal(lblPOSDetailRemain.Text), IP_PCName, Program.UsrID, DateTime.Now.ToString("yyyy-MM-dd"),
                         DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"));
                //(3)===> Update Balance oF POS in PointOfSale Table
                UpdateBalanceOfPOS();

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow("تم حفظ عملية السداد او التحصيل بنجاح", "عملية الحفظ",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //Recall btnClose_Click (sender, e) To Close Program
                btnClose_Click(sender, e);
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

        //FRM_Payment_Load Method To Fill ComboBox By Point of sales Table
        private void FRM_Payment_Load(object sender, EventArgs e)
        {
            try
            {
                //Fill ComboBox By Point of sales Table
                FillComboByPOSTB();
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

        //txtPOSDetailPaid_TextChanged Method To Get lblPOSDetailRemain
        private void txtPOSDetailPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if lblPOSDetailRequired is not contains is equal Zero
                if (!lblPOSDetailRequired.Text.Contains("0"))
                {
                    //lblPOSDetailRemain.Text = lblPOSDetailRequired.Text - txtPOSDetailPaid.Text
                    lblPOSDetailRemain.Text = (Convert.ToDouble(lblPOSDetailRequired.Text) - Convert.ToDouble(txtPOSDetailPaid.Text)).ToString();
                    //txtRebuyPaid Amount in Repurchases Invoice is equal POS Details
                    FRM_Repurchases.RepurchaseAccess_Property.txtRebuyPaid.Text = txtPOSDetailPaid.Text;
                    //txtRebuyPaid is ReadOnly equal true
                    FRM_Repurchases.RepurchaseAccess_Property.txtRebuyPaid.ReadOnly = true;
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

        //comboPayType_SelectedIndexChanged To Get All Calculation of Rebuybill(Cash, Postpone, Settlement)
        private void comboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if Purchase/Repurchase/Sale/Resale bill is Cash
                if (comboPayType.SelectedIndex == 0)
                {
                    //المدفوع = اجمالى قيمةالفاتورة أو المطلوب
                    txtPOSDetailPaid.Text = lblPOSDetailRequired.Text;

                    //Change ReadOnly of txtTotalPaid to true
                    txtPOSDetailPaid.ReadOnly = true;

                    //Calculate lblTotalRemain of Repurchase bill  المتبقى = 0
                    lblPOSDetailRemain.Text = "0";
                }
                //if Purchase/Repurchase/Sale/Resale bill is Postpone
                else if (comboPayType.SelectedIndex == 1)
                {
                    //Calculate txtTotalPaid of Repurchase bill  المدفوع = 0
                    txtPOSDetailPaid.Text = "0";
                    //Change ReadOnly of txtTotalPaid to true
                    txtPOSDetailPaid.ReadOnly = true;

                    //Calculate lblTotalRemain of Repurchase bill
                    //المتبقى = اجمالى قيمةالفاتورة أو المطلوب
                    lblPOSDetailRemain.Text = lblPOSDetailRequired.Text;
                }
                // //if Purchase/Repurchase/Sale/Resale bill is Cash Settlement
                else if (comboPayType.SelectedIndex == 2) // if any other cases
                {
                    //Change ReadOnly of txtTotalPaid to false
                    txtPOSDetailPaid.ReadOnly = false;

                    //Calculate lblTotalRemain of Purchase bill  المتبقى =
                    //اجمالى قيمةالفاتورة أو المطلوب - المدفوع
                    lblPOSDetailRemain.Text = (Double.Parse(lblPOSDetailRequired.Text) - Double.Parse(txtPOSDetailPaid.Text)).ToString();
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
