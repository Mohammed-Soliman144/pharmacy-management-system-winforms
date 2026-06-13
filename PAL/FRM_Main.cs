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
    public partial class FRM_Main : Form
    {

        #region Public Declarations
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //To Control MessageBox and Customize in Properties of its
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        #endregion

        #region Object Oriented Program to control the panel of parent form when close any child form

        //Create field of class FRM_Main which datatype is FRM_Main with access modifier static
        static FRM_Main ObjectFrmMain;

        //Create Method of formclosed which delegate it to Event Form.FormClosed in property
        static void ObjectMain_FormClosed (object sender, FormClosedEventArgs e)
        {
            //Initialize a null value to field of class
            ObjectFrmMain = null;
        }

        /* Create Property of Field which create 
         * but with access modifier is public to control it from others forms
         */
        public static FRM_Main ObjectMain_Property
        {
            //Used get property to return value of field
            get
            {
                // If field of class is null
                if (ObjectFrmMain == null)
                {
                    //if field is null so Create New Instance From FRM_Users by initialize it to field
                    ObjectFrmMain = new FRM_Main();
                    //Create Event of form closed then delegate above method (+= assign Mark of delegate)
                    ObjectFrmMain.FormClosed += new FormClosedEventHandler(ObjectMain_FormClosed);
                }
                return ObjectFrmMain;
            }
        }

        #endregion

        /// <summary>
        /// Constructor of FRM_Main
        /// </summary>
        public FRM_Main()
        {
            InitializeComponent();
            //in constructor of form after Method InitializeComponent 
            //Check if Field of form is null so Initialize value of Frm_Main to it (this)
            if (ObjectFrmMain == null) ObjectFrmMain = this;

            //To Create Automatic Backup of DataBase 
            if (Properties.Settings.Default.BackupType == true)
            {
                //Create new instance from object Called sender
                object sender = new object();
                //Create new instance from EventArgs Called e
                EventArgs e = new EventArgs();
                //Recall Method timerDB_Tick(sender, e) to Control of Creation Automatic backup of Database
                FRM_Server.Property_Server.timerDB_Tick(sender, e);
            }
        }

        #region Method is related Movement on Main Form

        /// <summary>
        /// bool Function to check any Form Openned except Form Main
        /// Return True if any Form openned except Main Form
        /// Return False if Form Main Only is Openned
        /// </summary>
        /// <returns>Return true or false</returns>
        private bool CheckFormOpenned ()
        {
            //Loop in all forms in Application.OpenForms
            foreach (Form frm in Application.OpenForms)
            {
                // if Form.Name is not equal Main Form
                if (frm.Name != "FRM_Main" && frm.Name != "FRM_Intro")
                {
                    //Show Alarm Message
                    NotificationSMS.NotifyShow(" يرجى إغلاق " + frm.Text + " حتى تتمكن من فتح شاشة اخرى ", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    ////Show Form is openned in mode show Testing Message
                    //frm.Show();

                    //Return True
                    return true;
                }
            }
            // if Main Form is openned Only Return False
            return false;
        }

        /// <summary>
        /// CheckButtonMenu Method to Control of Visibility of GroupBox Menu
        /// </summary>
        /// <param name="ctrlName">Name of GroupBox Menu</param>
        private void CheckButtonMenu (string ctrlName)
        {
            foreach (Control ctrl in pnlHome.Controls)
            {
                if (ctrl.Name != ctrlName)
                {
                    //SendToBack the Panel Home
                    ctrl.Visible = false;
                    //ctrl.BringToFront();
                }
                else
                {
                    ctrl.Visible = true;
                    ctrl.BringToFront();
                    ctrl.Dock = DockStyle.Fill;
                }
            }
        }

        //btnMini_Click Method To Minimized Form
        private void btnMini_Click(object sender, EventArgs e)
        {
            //change the WindowState to Minimized
            this.WindowState = FormWindowState.Minimized;
        }

        //btnClose_Click Method To Close Form
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Exit of Application
            Application.Exit();
        }

        //btnMaxi_Click Method To Maximized Form
        private void btnMaxi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        //btnNevigate_Click To control visible of side bar
        private void btnNevigate_Click(object sender, EventArgs e)
        {
            //Normal Mode pnlLeft is visible = true
            if (pbUser.Visible == true) 
            {
                foreach (Control ctrl in this.pnlUser.Controls)
                {
                    if (ctrl.Name != "btnNevigate") ctrl.Visible = false;
                    ctrl.Location = new Point(0, 0);
                }
                foreach (Control ctrl in this.flpControl.Controls)
                {
                    ctrl.ResetText();
                    ctrl.Size = new Size(60, 42);
                }
                pnlLeft.Size = new Size(65, 768);
            }
            //Layout Mode pnlLeft is visible = false
            else if (pbUser.Visible == false)
            {
                foreach (Control ctrl in this.pnlUser.Controls)
                {
                    ctrl.Visible = true;
                    if (ctrl.Name == "btnNevigate")
                        ctrl.Location = new Point(144, 6);
                    else if (ctrl.Name == "lblUser")
                        ctrl.Location = new Point(41, 110);
                    else if (ctrl.Name == "pbUser")
                        ctrl.Location = new Point(3,3);
                }
                foreach (Control ctrl in this.flpControl.Controls)
                {
                    btnHome.Text = "الرئيسية";
                    btnCustomers.Text = "العملاء";
                    btnSalesMenu.Text = "المبيعات";
                    btnSuppliers.Text = "الموردين";
                    btnPurchasesMenu.Text = "المشتريات";
                    btnItems.Text = "الأصناف";
                    btnStores.Text = "المخازن";
                    btnAccounts.Text = "الحسابات";
                    btnReports.Text = "التقارير";
                    btnUsers.Text = "المستخدمين";
                    btnSettings.Text = "الإعدادات العامة";
                    ctrl.Size = new Size(194, 42);
                }
                pnlLeft.Size = new Size(203, 768);
            } 
        }

        //btnHome_Click Method To move to Panel Home which Contains others buttons
        private void btnHome_Click(object sender, EventArgs e)
        {
            // if visible of pictureboxContainer is true
            if (pbContainer.Visible == true)
            {
                //Show GroupBox of Purchases
                CheckButtonMenu("gbMain");

                //BringToFront the Panel Home
                pnlHome.BringToFront();
                //Set Visible of PictureBoxContainer is false
                pbContainer.Visible = false;
            }
            // if visible of pictureboxContainer is false
            else
            {
                //Set Visible of PictureBoxContainer is true
                pbContainer.Visible = true;
                //SendToBack the Panel Home
                pnlHome.SendToBack();
            }

        }

        //btnCustomers_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnCustomers_MouseHover(object sender, EventArgs e)
        {
            btnCustomers.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnCustomers_MouseHover Method to change backgroundcolor of button when mouse Leave on it
        private void btnCustomers_MouseLeave(object sender, EventArgs e)
        {
            btnCustomers.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnSales_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnSales_MouseHover(object sender, EventArgs e)
        {
            btnSalesMenu.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnSales_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnSales_MouseLeave(object sender, EventArgs e)
        {
            btnSalesMenu.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnSuppliers_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnSuppliers_MouseHover(object sender, EventArgs e)
        {
            btnSuppliers.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnSuppliers_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnSuppliers_MouseLeave(object sender, EventArgs e)
        {
            btnSuppliers.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnPurchases_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnPurchases_MouseHover(object sender, EventArgs e)
        {
            btnPurchasesMenu.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnPurchases_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnPurchases_MouseLeave(object sender, EventArgs e)
        {
            btnPurchasesMenu.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnItems_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnItems_MouseHover(object sender, EventArgs e)
        {
            btnItems.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnItems_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnItems_MouseLeave(object sender, EventArgs e)
        {
            btnItems.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnBranches_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnStores_MouseHover(object sender, EventArgs e)
        {
            btnStores.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnBranches_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnStores_MouseLeave(object sender, EventArgs e)
        {
            btnStores.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnAccounts_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnAccounts_MouseHover(object sender, EventArgs e)
        {
            btnAccounts.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnAccounts_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnAccounts_MouseLeave(object sender, EventArgs e)
        {
            btnAccounts.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnReports_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnReports_MouseHover(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnReports_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnReports_MouseLeave(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnUsers_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnUsers_MouseHover(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnUsers_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnUsers_MouseLeave(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnSettings_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnSettings_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnNevigate_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnNevigate_MouseHover(object sender, EventArgs e)
        {
            btnNevigate.BackColor = Color.FromArgb(165, 94, 234, 1);
        }

        //btnNevigate_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnNevigate_MouseLeave(object sender, EventArgs e)
        {
            btnNevigate.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnClose_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(165, 94, 234, 1);
        }

        //btnClose_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnMini_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnMini_MouseHover(object sender, EventArgs e)
        {
            btnMini.BackColor = Color.FromArgb(165, 94, 234, 1);
        }

        //btnMini_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnMini_MouseLeave(object sender, EventArgs e)
        {
            btnMini.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnMaxi_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnMaxi_MouseHover(object sender, EventArgs e)
        {
            btnMaxi.BackColor = Color.FromArgb(165, 94, 234, 1);
        }

        //btnMaxi_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnMaxi_MouseLeave(object sender, EventArgs e)
        {
            btnMaxi.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnHome_MouseHover Method to change backgroundcolor of button when mouse hover on it
        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(30, 144, 255, 1);
        }

        //btnHome_MouseLeave Method to change backgroundcolor of button when mouse Leave on it
        private void btnHome_MouseLeave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        //btnUsers_Click Method to move to FRM_Users
        public void btnUsers_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Users
            FRM_Users UserFRM = new FRM_Users();

            //Check if form Openned ==> So stop executing Block Code
            if (CheckFormOpenned() == true) return;

            //Check if FRM_Users is open stop to executing block code
            //if (User.ShowDialog() == DialogResult.OK) return;
            // to change backcolor of Parent Form use Foreach loop in controls of parent form
            foreach (Control frm in this.Controls)
            {
                /* mdiparent is form which contains another form 
                 * mdiclient is a container which add child form to it 
                 * and not MdiClient Class Can not inherited From it 
                 * mdiclient is apart of mdiparent (like controls)*/
                //Create new Instance As MdiClient which instance is frm (control)
                MdiClient client = frm as MdiClient;
                //if mdi client didnot equal null
                if (client != null)
                {
                    //change background color of Mdiclient or the container of multi-Document Interface MDI
                    client.BackColor = Color.FromArgb(241, 247, 247);//(81, 73, 73);
                    //Exit From loop if child form is not equal null
                    break;
                }
            }
            //Send pnlContainer to Back();
            this.pnlContainer.SendToBack();
            //Define MdiParent of Form is this
            UserFRM.MdiParent = this;
            //Show Form to control multi forms
            UserFRM.Show();
        }

        //btnCustomers_Click Method To move to FRM_Customers
        public void btnCustomers_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Customers (Step 1)
            FRM_Customers CustomerFRM = new FRM_Customers();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Customers (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Customers to this (Main Form) (Step 5)
                CustomerFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                CustomerFRM.Show();
            }
        }

        //btnSuppliers_Click Method To move to FRM_Suppliers
        public void btnSuppliers_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Suppliers (Step 1)
            FRM_Suppliers SupplierFRM = new FRM_Suppliers();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Suppliers (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Suppliers to this (Main Form) (Step 5)
                SupplierFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                SupplierFRM.Show();
            }
        }

        //btnStores_Click Method To move to FRM_Stores
        public void btnStores_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Stores (Step 1)
            FRM_Stores StoreFRM = new FRM_Stores();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Stores (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Stores to this (Main Form) (Step 5)
                StoreFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                StoreFRM.Show();
            }
        }

        //btnCompanies_Click Method To move to FRM_Companies
        private void btnCompanies_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Companies (Step 1)
            FRM_Companies CompanyFRM = new FRM_Companies();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Companies (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Companies to this (Main Form) (Step 5)
                CompanyFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                CompanyFRM.Show();
            }
        }

        //btnBranches_Click Method To move to FRM_Branches
        public void btnBranches_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Companies (Step 1)
            FRM_Branches BranchFRM = new FRM_Branches();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Branches (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Branches to this (Main Form) (Step 5)
                BranchFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                BranchFRM.Show();
            }
        }

        //btnDBServer_Click Method To move to FRM_ServerConnections
        private void btnDBServer_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Server (Step 1)
            FRM_Server ServerFRM = new FRM_Server();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_ServerConnections (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_ServerConnections to this (Main Form) (Step 5)
                ServerFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ServerFRM.Show();
            }
        }
         

        //btnItems_Click Method To move to FRM_Items
        public void btnItems_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Items (Step 1)
            FRM_Items ItemsFRM = new FRM_Items();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Items (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Items to this (Main Form) (Step 5)
                ItemsFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ItemsFRM.Show();
            }
        }

        //btnPOS_Click Method To move to FRM_PointOfSales
        private void btnPOS_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_PointOfSales (Step 1)
            FRM_PointOfSales POSFRM = new FRM_PointOfSales();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Branches (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Branches to this (Main Form) (Step 5)
                POSFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                POSFRM.Show();
            }
        }

        //btnSupplierAccount_Click Method To move to FRM_SupplierAccount
        private void btnSupplierAccount_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_SupplierAccount (Step 1)
            FRM_SupplierAccount SupAccountFRM = new FRM_SupplierAccount();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Branches (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Branches to this (Main Form) (Step 5)
                SupAccountFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                SupAccountFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                SupAccountFRM.Show();
            }
        }

        //btnPurchases_Click Method To move to FRM_Purchases
        public void btnPurchases_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Purchases (Step 1)
            FRM_Purchases PurchasesFRM = new FRM_Purchases();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of PurchasesFRM (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From PurchasesFRM to this (Main Form) (Step 5)
                PurchasesFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                PurchasesFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                PurchasesFRM.Show();
            }
        }

        #endregion

        //btnSales_Click To Move GroupBox Menu which related with Purchases
        private void btnSalesMenu_Click(object sender, EventArgs e)
        {
            //Recall btnHome_Click(sender, e);
            btnHome_Click(sender, e);
            //Show GroupBox of Purchases
            CheckButtonMenu("gbSalesMenu");
        }

        //btnPurchasesMenu_Click To Move GroupBox Menu which related with Purchases
        private void btnPurchasesMenu_Click(object sender, EventArgs e)
        {
            //Recall btnHome_Click(sender, e);
            btnHome_Click(sender, e);
            //Show GroupBox of Purchases
            CheckButtonMenu("gbPurchasesMenu");
        }

        //btnPurchasesSearch_Click Method To move to FRM_PurchasesSearch
        public void btnPurchasesSearch_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_PurchasesSearch (Step 1)
            FRM_PurchasesSearch PurSearchFRM = new FRM_PurchasesSearch();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_PurchasesSearch (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_PurchasesSearch to this (Main Form) (Step 5)
                PurSearchFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                PurSearchFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                PurSearchFRM.Show();
            }
        }

        //btnRepurchases_Click Method To move to FRM_Repurchases
        public void btnRepurchases_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Repurchases (Step 1)
            FRM_Repurchases RepurchaseFRM = new FRM_Repurchases();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Repurchases (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Repurchases to this (Main Form) (Step 5)
                RepurchaseFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                RepurchaseFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                RepurchaseFRM.Show();
            }
        }

        //btnRepurchasesSearch_Click Method To move to FRM_RepurchasesSearch
        public void btnRepurchasesSearch_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_RepurchasesSearch (Step 1)
            FRM_RepurchasesSearch RepurchaseSearchFRM = new FRM_RepurchasesSearch();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Repurchases (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Repurchases to this (Main Form) (Step 5)
                RepurchaseSearchFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                RepurchaseSearchFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                RepurchaseSearchFRM.Show();
            }
        }

        //btnSales_Click Method To move to FRM_Sales
        private void btnSales_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Sales (Step 1)
            FRM_Sales SalesFRM = new FRM_Sales();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Repurchases (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Repurchases to this (Main Form) (Step 5)
                SalesFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                SalesFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                SalesFRM.Show();
            }
        }

        //btnSalesSearch_Click Method To move to FRM_SalesSearch
        private void btnSalesSearch_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_SalesSearch (Step 1)
            FRM_SalesSearch SearchSalesFRM = new FRM_SalesSearch();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_SalesSearch (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_SalesSearch to this (Main Form) (Step 5)
                SearchSalesFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                SearchSalesFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                SearchSalesFRM.Show();
            }
        }

        //btnCustomerAccount_Click Method To move to FRM_CustomerAccount
        private void btnCustomerAccount_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_CustomerAccount (Step 1)
            FRM_CustomerAccount CustomerAccountFRM = new FRM_CustomerAccount();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_CustomerAccount (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_CustomerAccount to this (Main Form) (Step 5)
                CustomerAccountFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                CustomerAccountFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                CustomerAccountFRM.Show();
            }
        }

        //btnResales_Click Method To move to FRM_Resales
        private void btnResales_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Resales (Step 1)
            FRM_Resales ResaleFRM = new FRM_Resales();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Resales (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Resales to this (Main Form) (Step 5)
                ResaleFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                ResaleFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ResaleFRM.Show();
            }
        }

        //btnResalesSearch_Click Method To move to FRM_ResalesSearch
        public void btnResalesSearch_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_ResalesSearch (Step 1)
            FRM_ResalesSearch ResalesSearchFRM = new FRM_ResalesSearch();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_ResalesSearch (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_ResalesSearch to this (Main Form) (Step 5)
                ResalesSearchFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                ResalesSearchFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ResalesSearchFRM.Show();
            }
        }

        //btnSettings_Click Method To move to FRM_ServerConnections
        private void btnSettings_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Server (Step 1)
            FRM_Server ServerFRM = new FRM_Server();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(241, 247, 247);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_ServerConnections (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_ServerConnections to this (Main Form) (Step 5)
                ServerFRM.MdiParent = this;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ServerFRM.Show();
            }
        }


        private void btnReports_Click(object sender, EventArgs e)
        {
            //Create New Instance From FRM_Resales (Step 1)
            FRM_Rules ResaleFRM = new FRM_Rules();

            //check if any child Form openned (Step 2) [if any form openned stop executing block code]
            if (CheckFormOpenned() == true) return;

            //loop in all controls of parent form (Step 3)
            foreach (Control ctrl in this.Controls)
            {
                //Create new instance From Class MdiClient [MdiClient class Can not inheritance from it]
                //MdiClient is Container which contains child form in it
                MdiClient client = ctrl as MdiClient;

                //check if client or child form is not equal null
                if (client != null)
                {
                    //Change BackColor of childform
                    client.BackColor = Color.FromArgb(45, 52, 54);
                    //Exit from loop if child form is not equal null
                    break;
                }
                //Send Container panel to back of FRM_Resales (Step 4)
                this.pnlContainer.SendToBack();
                //Initialize MdiParent of Instance From FRM_Resales to this (Main Form) (Step 5)
                ResaleFRM.MdiParent = this;
                //Initialize Dock of Form to DockStyle.Fill
                ResaleFRM.Dock = DockStyle.Fill;
                //Show Instance From form in mode show to control multi forms (Step 6)
                ResaleFRM.Show();
            }
        }

    }
}
