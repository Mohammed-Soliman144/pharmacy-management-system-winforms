using System;
using System.Drawing;
using System.IO; //to deal with directory/ directoryInfo / MemoryStream/Path/ BufferedStream/StreamWriter/StreamReader / FileStream
using System.Windows.Forms;


namespace PharmacySystemV20._0._1.PAL
{
    public partial class FRM_Server : Form
    {

        #region Public Declaration

        //Create New Instance From BAL.CLS_Databases Business Access Layer
        readonly BAL.CLS_Databases DatabasesClass = new BAL.CLS_Databases();
        //Create New Instance From  BAL.CLS_Exceptions Business Access Layer
        readonly BAL.CLS_Exceptions ErrHandlingClass = new BAL.CLS_Exceptions();
        //Create New Instance From FRM_Notifications Form in Presentation Access Layer  
        //Control MessageBox and Customize in Properties of it
        readonly FRM_Notifications NotificationSMS = new FRM_Notifications();
        //Create new bool Variable with access modifier public static
        public static bool TurnOnSMSAutoBackup;

        //Create new instance from timer access modifier public static
        public static Timer timerDB = new Timer();
        //create new int variable with access modifier public static
        public static int valueOfTimer;


        //declare string variable to string backup path with access modifier private
        string BackupFilePath = "";
        //declare int variable to check number of errors with access modifier private
        int CountOfErrors = 0;

        #endregion    

        #region Object Oriented Programming

        //create new field from form with access modifier is private static 
        private static FRM_Server FRM_SerConnection;

        //create Method to recall it if form closed with access modifier private static
        private static void FRMServer_Closed(object sender, FormClosedEventArgs e)
        {
            //when close form dispose all resources of form or destoryed it
            FRM_SerConnection = null;
        }

        //Create new Property of field or encupsulation or getter and setter
        public static FRM_Server Property_Server
        {
            get // use get to return of value of field
            {
                // if field is null
                if (FRM_SerConnection == null)
                {
                    //create new instance from form in this field ** 1 **
                    FRM_SerConnection = new FRM_Server();
                    //Create Event of field.FormClosed then delegate event by method of FRMServer_Closed ** 2 **
                    FRM_SerConnection.FormClosed += new FormClosedEventHandler(FRMServer_Closed);
                }
                //else return value of field
                return FRM_SerConnection;
            }
        }
        #endregion

        //Constructor of FRM_ServerConnections
        public FRM_Server()
        {
            InitializeComponent();

            //Field of form is null so initialize value of this form to field
            if (FRM_SerConnection == null) FRM_SerConnection = this;

            //Fill ComboBox
            FillComboBox();

            //enable the timer
            timerDB.Enabled = true;
            //Define the interval of timer 1000 milesecond == second
            timerDB.Interval = Properties.Settings.Default.BackupTimerValue;

            /* Create Delegate of the event (timer.Tick) 
             * then delegate Event to recall the method += new EventHandler (method);*/
            timerDB.Tick += new EventHandler(timerDB_Tick);
        }

        #region Methods and Functions

        //Method to fill combobox of server and databases
        void FillComboBox()
        {
            //Fill ComboBox of Servers
            comboServer.DataSource = DatabasesClass.GetAllServers();
            comboServer.DisplayMember = "NAME";

            //Fill ComboBox of Databases
            comboDatabase.DataSource = DatabasesClass.GetAllDatabases();
            comboDatabase.DisplayMember = "Name";
        }

        /// <summary>
        /// CatchEmptyFields int Function to Set Error Provider and Increase Counter of error by one
        /// use int function to get counter of errors
        /// </summary>
        int CatchEmptyFields()
        {
            //Clear errProviderServer
            errProviderServer.Clear();

            //To check Validation of Server Connections 
            if (btnServerTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                //loop in all controls of form in pnlServer.Controls by foreach loop
                foreach (Control ctrl in this.pnlServer.Controls)
                {
                    //if Ctrl is TextBox and Ctrl is Empty and radBtnSql.Checked is true
                    if (ctrl is TextBox && ctrl.Text == string.Empty && radBtnSql.Checked == true)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(ctrl, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                        return CountOfErrors;
                    }
                }
            }
            //To check Validation of Backup Database Tab
            else if (btnBackupTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                //Check Vaalidation Manual backup
                if (radBtnManualBackup.Checked == true)
                {
                    //if Ctrl is TextBox and Ctrl.enabled is false and Ctrl is Empty
                    if (txtDBName.Enabled == true && txtDBName.Text == string.Empty)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(txtDBName, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                    }
                }
                //Check Vaalidation Auto backup
                else if (radBtnAutoBackup.Checked == true)
                {
                    if (comboBackupSave.Enabled == true && comboBackupSave.SelectedIndex == -1)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(comboBackupSave, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                        //Stop executing block code and return CountOfErrors
                        return CountOfErrors;
                    }
                    else if (txtBackupPath.Text == string.Empty)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(txtBackupPath, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                        //Stop executing block code and return CountOfErrors
                        return CountOfErrors;
                    }
                    else if (comboBackupDelete.Enabled == true && comboBackupDelete.SelectedIndex == -1)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(comboBackupDelete, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                        //Stop executing block code and return CountOfErrors
                        return CountOfErrors;
                    }
                }
                return CountOfErrors;
            }
            //To check Validation of Restore Database Tab
            else if (btnRestoreTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                //loop in all controls of form in pnlRestore.Controls by foreach loop
                foreach (Control ctrl in this.pnlRestore.Controls)
                {
                    //if Ctrl is TextBox and Ctrl is Empty
                    if (ctrl is TextBox && ctrl.Text == string.Empty)
                    {
                        //SetError of Error Provider(ctrlName, "message of error")
                        errProviderServer.SetError(ctrl, "هذا الحقل اجبارى");
                        //Increase Counter of error by one
                        CountOfErrors += 1;
                        return CountOfErrors;
                    }
                }
            }
            //Return Counter of error
            return CountOfErrors;
        }

        //void method To Generate Automatic Backup of database **Done**
        public void GenerateAutoBackup()
        {
            // if user doses not need to Alarm Notification when create Auto backup
            if (TurnOnSMSAutoBackup == false)
            {
                //Create new backup from database
                DatabasesClass.BackupDB(Properties.Settings.Default.BackupPath, Properties.Settings.Default.DatabaseName);
            }
            // if user need to Alarm Notification when create Auto backup
            else
            {
                // Stop timer DB
                timerDB.Stop();
                //Create new backup from database
                DatabasesClass.BackupDB(Properties.Settings.Default.BackupPath, Properties.Settings.Default.DatabaseName);
                //Show Notification Message Success Backup
                NotificationSMS.NotifyShow(" تم انشاء نسخة احتياطية بنجاح! ", "النسخ الاحتياطى",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();

                //if User pressed on btn of notification message OK موافق
                if (NotificationSMS.NotifyResult == true)
                {
                    //Start timer DB
                    timerDB.Start();
                }
            }
        }

        //void method To delete older backup Versions **Done**
        private void DeleteOldBackupFiles()
        {
            //comboBox.SelectedIndexed > -1 and txt backup path is not equal empty
            if (comboBackupDelete.SelectedIndex > -1 && txtBackupPath.Text != string.Empty)
            {
                //declare string[] array which used to store name of files exist in txt backup path Directory.GetFiles(string path)
                //Class Directory to deal with folders
                string[] GroupFiles = Directory.GetFiles(txtBackupPath.Text);
                //use foreach loop to string all name of files in fileName
                foreach (string fileName in GroupFiles)
                {
                    //class FileInfo to deal with files
                    //declare new instance from Class FileInfo and assign the value of filename
                    FileInfo file = new FileInfo(fileName);
                    //test to clear backup files less than date of today use below MessageBox.Show()
                    //MessageBox.Show(DateTime.Now.AddDays(Convert.ToDouble(comboBackupDelete.Text) * -1).ToString());
                    //if extension of file is .bak and LastAccessTime of file is equal DateTime.Now.AddDays(- num days Double)
                    if (file.Extension == ".bak" && file.LastAccessTime <= DateTime.Now.AddDays(Convert.ToDouble(comboBackupDelete.Text) * -1))
                    {
                        //Delete the file
                        file.Delete();
                    }
                    else return; // else stop executing block code
                }
            }
        }

        //btnExit_Click Method To Close Form **Done**
        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                //Used Method To Bring background image of Main form to Front
                FRM_Main.ObjectMain_Property.pnlContainer.BringToFront();
                //check if field you are created is null when closed form if not Assign null value to field
                if (FRM_SerConnection != null) FRM_SerConnection = null;
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

        //btnSaveSettings_Click Method to Save All Settings of Server **Done**
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                //catchEmptyFields Int Function to return number of errors
                //and to Set Error Provider and lanuch Alarm Message Box
                //if counter of error greater than zero
                if (CatchEmptyFields() > 0)
                {
                    //Lanuch Alarm Message Box
                    //Show Notification of System Message Error Message in Input Entry
                    //NotificationSMS.ShowDialog();
                    NotificationSMS.NotifyShow("يرجى التأكد من إدخال جميع الحقول المطلوبة", "التحقق من البيانات",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();

                    //Stop executing block code
                    return;
                }

                //Save Setting to Connection with server in Settings of project
                Properties.Settings.Default.ServerName = comboServer.Text;
                Properties.Settings.Default.DatabaseName = comboDatabase.Text;
                if (radBtnWindows.Checked == true) Properties.Settings.Default.SecurityType = true;
                else if (radBtnSql.Checked == true) Properties.Settings.Default.SecurityType = false;
                Properties.Settings.Default.User_ID = txtUser.Text;
                Properties.Settings.Default.Password = txtPassword.Text;

                //Save Settings of project
                Properties.Settings.Default.Save();

                //Enable the timer
                timerServer.Enabled = true;
                //Start the timer
                timerServer.Start();

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

        //btnVisible_Click Method To Visible passwordchar by set '\0' value or invisible '*' **Done**
        private void btnVisible_Click(object sender, EventArgs e)
        {
            //if txtpassword is not empty and txtPassword.PasswordChar == '*'
            if (txtPassword.Text != string.Empty && txtPassword.PasswordChar == '*')
            {
                //Initialize empty Value to PasswordChar empty in char datatype equal '\0'
                txtPassword.PasswordChar = '\0';
                //Change Background image of btnvisible
                btnVisible.BackgroundImage = Properties.Resources.Visiable;
                //SetToolTip of toolTipServer (controlName,"string")
                toolTipServer.SetToolTip(btnVisible, "إخفاء كلمة المرور"); //
            }
            //if txtpassword is not empty and txtPassword.PasswordChar != '*'
            else if (txtPassword.Text != string.Empty && txtPassword.PasswordChar != '*')
            {
                //Initialize '*' Value to PasswordChar
                txtPassword.PasswordChar = '*';
                //Change Background image of btnvisible
                btnVisible.BackgroundImage = Properties.Resources.Invisible;
                //SetToolTip of toolTipUsers (controlName,"string")
                toolTipServer.SetToolTip(btnVisible, "عرض كلمة المرور");
            }
        }

        //btnServerTab_Click Method To Move to panel Server Tab **Done**
        private void btnServerTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if pnlBackup Panel is Visible equal true ==> stop executing block code
            if ((pnlBackup.Visible == true && btnBackupTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnServerTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnServerTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBackupTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBackupTab.ForeColor = SystemColors.ControlText;
                //Send pnlBackup to Back
                pnlBackup.SendToBack();
                //Bring pnlServer to Front
                pnlServer.BringToFront();
                //Send btnBackup to Back
                btnBackup.SendToBack();
                //Bring btnSaveSettings to Front
                btnSaveSettings.BringToFront();
                //Appears pnlServer
                pnlServer.Visible = true;
                //Focus on comboServer
                comboServer.Focus();
            }
            // Case ==> (2)
            //Check if  pnlRestore panel is Visible equal true ==> stop executing block code
            else if ((pnlRestore.Visible == true && btnRestoreTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnServerTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnServerTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnRestoreTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnRestoreTab.ForeColor = SystemColors.ControlText;
                //Send pnlRestore to Back
                pnlRestore.SendToBack();
                //Bring pnlServer to Front
                pnlServer.BringToFront();
                //Send btnRestore to Back
                btnRestore.SendToBack();
                //Bring btnSaveSettings to Front
                btnSaveSettings.BringToFront();
                //Appears pnlServer
                pnlServer.Visible = true;
                //Focus on comboServer
                comboServer.Focus();
            }
        }

        //btnBackupTab_Click Method To Move to panel Backup Tab **Done**
        private void btnBackupTab_Click(object sender, EventArgs e)
        {
            //Case ==> (1)
            //Check if pnlServer Panel is Visible equal true ==> stop executing block code
            if ((pnlServer.Visible == true && btnServerTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBackupTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBackupTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnServerTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnServerTab.ForeColor = SystemColors.ControlText;
                //Send pnlServer to Back
                pnlServer.SendToBack();
                //Bring pnlBackup to Front
                pnlBackup.BringToFront();
                //Send btnSaveSettings to Back
                btnSaveSettings.SendToBack();
                //Bring btnBackup to Front
                btnBackup.BringToFront();
                //Appears pnlBackup
                pnlBackup.Visible = true;
                //Focus on comboBackupSave
                comboBackupSave.Focus();
            }
            //Case ==> (2)
            //Check if pnlRestore panel is Visible equal true ==> stop executing block code
            else if ((pnlRestore.Visible == true && btnRestoreTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBackupTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBackupTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnRestoreTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnRestoreTab.ForeColor = SystemColors.ControlText;
                //Send pnlRestore to Back
                pnlRestore.SendToBack();
                //Bring pnlBackup to Front
                pnlBackup.BringToFront();
                //Send btnRestore to Back
                btnRestore.SendToBack();
                //Bring btnBackup to Front
                btnBackup.BringToFront();
                //Appears pnlBackup
                pnlBackup.Visible = true;
                //Focus on comboBackupSave
                comboBackupSave.Focus();
            }
        }

        //btnRestoreTab_Click Method To Move to panel Restore Tab **Done**
        private void btnRestoreTab_Click(object sender, EventArgs e)
        {
            // Case ==> (1)
            // Check if pnlBackup Panel is Visible equal true ==> stop executing block code
            if ((pnlBackup.Visible == true && btnBackupTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnRestoreTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnRestoreTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnBackupTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnBackupTab.ForeColor = SystemColors.ControlText;
                //Send pnlBackup to Back
                pnlBackup.SendToBack();
                //Bring pnlRestore to Front
                pnlRestore.BringToFront();
                //Send btnBackup to Back
                btnBackup.SendToBack();
                //Bring btnRestore to Front
                btnRestore.BringToFront();
                //Appears pnlRestore
                pnlRestore.Visible = true;
                //Focus on txtAutoRestore
                txtAutoRestore.Focus();
            }
            // Case ==> (2)
            // Check if  pnlServer panel is Visible equal true ==> stop executing block code
            else if ((pnlServer.Visible == true && btnServerTab.BackColor == Color.FromArgb(75, 101, 132)))
            {
                //Clear errProviderServer
                errProviderServer.Clear();
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnRestoreTab.BackColor = Color.FromArgb(75, 101, 132);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnRestoreTab.ForeColor = SystemColors.ButtonHighlight;
                //Change BackColor of Button to Color.FromArgb (75, 101, 132)
                btnServerTab.BackColor = Color.FromArgb(186, 203, 210);
                //Change ForeColor of Button to SystemColors.ButtonHighlight;
                btnServerTab.ForeColor = SystemColors.ControlText;
                //Send pnlServer to Back
                pnlServer.SendToBack();
                //Bring pnlRestore to Front
                pnlRestore.BringToFront();
                //Send btnSaveSettings to Back
                btnSaveSettings.SendToBack();
                //Bring btnRestore to Front
                btnRestore.BringToFront();
                //Appears pnlRestore
                pnlRestore.Visible = true;
                //Focus on txtAutoRestore
                txtAutoRestore.Focus();
            }
        }

        //btnBrowse_Click Method to select backup path or restore path **Done**
        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            //Clear text of txtBackupPath
            txtBackupPath.Clear();

            //Declare variable to store operating system in it Parition C
            string operPath = Path.GetPathRoot(Environment.SystemDirectory);

            //Declare FolderBrowseDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();


            if (fbd.ShowDialog() == DialogResult.OK && !fbd.SelectedPath.Contains(operPath) && fbd.SelectedPath != Path.GetPathRoot(fbd.SelectedPath))
            {
                txtBackupPath.Text = fbd.SelectedPath;
                Properties.Settings.Default.BackupPath = fbd.SelectedPath;
                //Assignment the value of Properties.Settings.Default.BackupPath if Automatic backup
                Properties.Settings.Default.BackupPath = fbd.SelectedPath + @"\" + Properties.Settings.Default.DatabaseName + "-" + DateTime.Now.ToString("dd-MM-yyyy && hh-mm-ss tt") + ".bak";
                //Save Changes on Variables of Properties by use Properties.Settings.Default.Save()
                Properties.Settings.Default.Save();
            }
            else if (fbd.SelectedPath.Contains(operPath))
            {
                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow(" " + " لايمكن عمل نسخة احتياطية داخل هذا القرص " + operPath, "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Execute next block code
                return;
            }
            else if (fbd.SelectedPath == string.Empty)
            {
                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow(" يلزم تحديد مسار لحفظ النسخة احتياطية ", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Execute next block code
                return;
            }
            else if (fbd.SelectedPath == Path.GetPathRoot(fbd.SelectedPath))
            {
                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow(" يلزم تحديد مجلد داخل القرص حتى يتم عمل نسخة احتياطية ", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Execute next block code
                return;
            }
        }

        //radBtnAutoBackup_CheckedChanged Method To change mode from Manual to Auto backup **Done**
        private void radBtnAutoBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnAutoBackup.Checked == true)
            {
                txtDBName.Enabled = false;
                comboBackupDelete.Enabled = true;
                comboBackupSave.Enabled = true;
                //Assign Value of BackupType is true automatic
                Properties.Settings.Default.BackupType = true;
                //Save Changes on Variables of Properties by use Properties.Settings.Default.Save()
                Properties.Settings.Default.Save();
            }
        }

        //radBtnAutoBackup_CheckedChanged Method To change mode from Auto to Manual backup **Done**
        private void radBtnManualBackup_CheckedChanged(object sender, EventArgs e)
        {
            if (radBtnManualBackup.Checked == true)
            {
                txtDBName.Enabled = true;
                comboBackupDelete.Enabled = false;
                comboBackupSave.Enabled = false;
                //Assign Value of BackupType is false Manual
                Properties.Settings.Default.BackupType = false;
                //Save Changes on Variables of Properties by use Properties.Settings.Default.Save()
                Properties.Settings.Default.Save();
            }
        }

        //comboBackupSave_SelectedIndexChanged method to assign value of timer create backup DB **Done**
        private void comboBackupSave_SelectedIndexChanged(object sender, EventArgs e)
        {
            //interval of timer works by milesecond (1 minute ==> 1 * 1000 * 60 in interval of timer)
            if (comboBackupSave.SelectedIndex > -1) // Minutes
            {
                timerServer.Interval = 300;
                timerDB.Interval = (Convert.ToInt32(comboBackupSave.Text) * 1000 * 60);
                valueOfTimer = (Convert.ToInt32(comboBackupSave.Text) * 1000 * 60);
                Properties.Settings.Default.BackupTimerValue = valueOfTimer;
            }
            //Save Changes on Variable of Properties by use Method Properties.Settings.Default.Save()
            Properties.Settings.Default.Save();
        }

        //comboBackupDelete_SelectedIndexChanged method to assign value of Days Timer to delete old backup files **Done**
        private void comboBackupDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBackupDelete.SelectedIndex > -1)
            {
                //Assigment the Value of BackupTimerDelete
                Properties.Settings.Default.BackupTimerDelete = Convert.ToInt32(comboBackupDelete.Text);
                //Save Changes on Variable of Properties by use Method Properties.Settings.Default.Save()
                Properties.Settings.Default.Save();
            }
        }

        //btnBackup_Click Method to create backup manual and Automatic **Done**
        private void btnBackup_Click(object sender, EventArgs e)
        {
            //Manual Backup Database
            if (radBtnManualBackup.Checked == true && txtDBName.Enabled == true)
            {
                //check validation of Input User if greater than one stop executing block code
                if (CatchEmptyFields() > 0) return;

                //check if txt DBName is empty or not
                if (txtDBName.Text == string.Empty)
                {
                    //Show Notification of System Message Success Save
                    NotificationSMS.NotifyShow(" يلزم تحديد اسم النسخة احتياطية ", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Focus on txtDBName
                    txtDBName.Focus();
                    //Stop Execute next block code
                    return;
                }
                else
                {
                    //Change Cursor of current form to Cursors.WaitCursor
                    this.Cursor = Cursors.WaitCursor;
                    //Start the timer
                    timerServer.Start();
                }
            }
            //Aumatic Backup Database
            else
            {
                MessageBox.Show(CatchEmptyFields().ToString());
                MessageBox.Show(Properties.Settings.Default.BackupTimerValue.ToString());
                MessageBox.Show(valueOfTimer.ToString());

                //check validation of Input User if greater than one stop executing block code
                if (CatchEmptyFields() > 0) return;



                if (Properties.Settings.Default.BackupTimerValue == valueOfTimer)
                {
                    //Change Cursor of current form to Cursors.WaitCursor
                    this.Cursor = Cursors.WaitCursor;
                    //Start the timer
                    timerServer.Start();
                    //Start the timerDB
                    timerDB.Start();
                }
            }
        }

        //timerServer_Tick Method to Create Manual Backup of database and fire Notification Messages
        private void timerServer_Tick(object sender, EventArgs e)
        {
            // to Save Settings of Server Tab
            if (btnServerTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                if (progressBarServer.Value < progressBarServer.Maximum)
                {
                    progressBarServer.Value += 1;
                }
                else if (progressBarServer.Value == 100)
                {
                    //Stop timerServer 
                    timerServer.Stop();
                    //Show Notification of System Message Success Save
                    NotificationSMS.NotifyShow("تم حفظ الاعدادات بنجاح", "إعدادات السيرفير",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                }
            }
            //to Save Backup Database Tab
            else if (btnBackupTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                if (progressBarBackup.Value < progressBarBackup.Maximum)
                {
                    progressBarBackup.Value += 1;
                }
                else if (progressBarBackup.Value == 100 && radBtnAutoBackup.Checked == false && txtDBName.Enabled == true)
                {
                    //Stop timerServer 
                    timerServer.Stop();

                    //void method To delete older backup Versions **Done**
                    DeleteOldBackupFiles();

                    //if user can not determine name of backup of database
                    BackupFilePath = txtBackupPath.Text + @"\" + txtDBName.Text + ".bak";

                    //Create new backup from database
                    DatabasesClass.BackupDB(BackupFilePath, Properties.Settings.Default.DatabaseName);
                    //Show Notification Message Success Backup
                    NotificationSMS.NotifyShow(" تم انشاء نسخة احتياطية بنجاح! ", "النسخ الاحتياطى",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Change Cursor of current form to Cursors.Default
                    this.Cursor = Cursors.Default;
                    //Reset Properties of path and progressBar
                    progressBarBackup.Value = 0;
                    //Reset Backup Path
                    BackupFilePath = "";
                }
                else if (progressBarBackup.Value == 100 && radBtnAutoBackup.Checked == true && txtDBName.Enabled == false)
                {
                    //Stop timerServer 
                    timerServer.Stop();
                    //Show Notification of System Message Success Save
                    NotificationSMS.NotifyShow(" سيتم انشاء نسخة احتياطية كل " + comboBackupSave.Text + " دقيقة ", "النسخ الاحتياطى",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Change Cursor of current form to Cursors.Default
                    this.Cursor = Cursors.Default;
                }
            }
            //to Save Restore Database Tab
            else if (btnRestoreTab.BackColor == Color.FromArgb(75, 101, 132))
            {
                //Check Validation of Restore Database
                if (txtAutoRestore.Text != string.Empty && File.Exists(txtAutoRestore.Text)
                        && Path.GetExtension(txtAutoRestore.Text) == ".bak")
                {
                    //Show Notification of System Message Success Save
                    NotificationSMS.NotifyShow(" يلزم تحديد ملف النسخة الاحتياطية بشكل صحيح! ", "تنبية",
                        FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                        FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Recall Btn Select Restore path
                    btnAutoRestore_Click(sender, e);
                    //Stop Execute next block code
                    return;
                }

                if (progressBarServer.Value < progressBarServer.Maximum)
                {
                    progressBarServer.Value += 1;
                }
                else if (progressBarServer.Value == 100)
                {
                    //Create new Restore database
                    DatabasesClass.RestoreDB(txtAutoRestore.Text);
                    //Show Notification Message Success Backup
                    NotificationSMS.NotifyShow(" تم استرجاع النسخة الاحتياطية بنجاح! ", "استرجاع البيانات",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                    //Show Notification Message in Dialog Mode
                    NotificationSMS.ShowDialog();
                    //Change Cursor of current form to Cursors.Default
                    this.Cursor = Cursors.Default;
                }
            }
        }

        //timerDB_Tick Method to Create Automatic Backup of database and fire Notification Messages
        public void timerDB_Tick(Object sender, EventArgs e)
        {
            
            if (timerDB.Interval == Properties.Settings.Default.BackupTimerValue && Properties.Settings.Default.DatabaseName != string.Empty && Properties.Settings.Default.BackupPath != string.Empty)
            {
                //Assignment the Index of String Properties.Settings.Default.DatabaseName in Backup File Path
                int i = Properties.Settings.Default.BackupPath.IndexOf(Properties.Settings.Default.DatabaseName);
                //Assignment the new value of BackupPath after remove string start from variable i to BackupPath
                Properties.Settings.Default.BackupPath = Properties.Settings.Default.BackupPath.Remove(i);
                //Assignment the value of Properties.Settings.Default.BackupPath after add DatabaseName + ateTime.Now.ToString("dd-MM-yyyy && hh-mm-ss tt") to BackupPath
                Properties.Settings.Default.BackupPath +=  Properties.Settings.Default.DatabaseName + "-" + DateTime.Now.ToString("dd-MM-yyyy && hh-mm-ss tt") + ".bak";
                //Save Changes on Variables of Properties by use Properties.Settings.Default.Save()
                Properties.Settings.Default.Save();
                //Recall Method of Automatic Backup database
                GenerateAutoBackup();
            }
        }

        //btnBrowse_Click Method to select Backup file path
        private void btnAutoRestore_Click(object sender, EventArgs e)
        {
            //Clear text of txtAutoRestore
            txtAutoRestore.Clear();

            //Declare variable to store operating system in it Parition C
            string operPath = Path.GetPathRoot(Environment.SystemDirectory);

            //Create new instance from OpenFileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            //define which files want to open it
            ofd.Filter = "Backup Files (*.bak)|*.bak";
            //index of Files which dispaly as first (Ofd.FilterIndex work with Negative Index or zero)
            ofd.FilterIndex = 0;

            if (ofd.ShowDialog() == DialogResult.OK && !ofd.FileName.Contains(operPath)
                && File.Exists(ofd.FileName) && Path.GetExtension(ofd.FileName) == ".bak")
            {
                //Assignment path of backup database or ofd.FileName to txtAutoRestore.Text
                txtAutoRestore.Text = ofd.FileName;
                //Stop Executing Block code
                return;
            }
            else if (ofd.FileName.Contains(operPath))
            {
                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow(" " + operPath + " لايمكن استرجاع نسخة احتياطية داخل هذا القرص ", "استرجاع البيانات",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Information,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
                //Stop Executing Block code
                return;
            }
            else
            {

                //Show Notification of System Message Success Save
                NotificationSMS.NotifyShow(" يلزم تحديد ملف استرجاع النسخة احتياطية ", "تنبية",
                    FRM_Notifications.NotifyButtons.Ok, FRM_Notifications.NotifyIcons.Warning,
                    FRM_Notifications.NotifyTypes.NotifyBtn);
                //Show Notification Message in Dialog Mode
                NotificationSMS.ShowDialog();
            }

        }

        //btnRestore_Click method To restore Database
        private void btnRestore_Click(object sender, EventArgs e)
        {
            //Start the timer
            timerServer.Start();
            //Change Cursor of current form to Wait Cursor
            this.Cursor = Cursors.WaitCursor;
        }
    }
    #endregion

}
