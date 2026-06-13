
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Server));
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBarBackup = new System.Windows.Forms.ProgressBar();
            this.comboBackupDelete = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnServerTab = new System.Windows.Forms.Button();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnRestoreTab = new System.Windows.Forms.Button();
            this.btnBackupTab = new System.Windows.Forms.Button();
            this.pnlConnections = new System.Windows.Forms.Panel();
            this.pnlServer = new System.Windows.Forms.Panel();
            this.btnVisible = new System.Windows.Forms.Button();
            this.progressBarServer = new System.Windows.Forms.ProgressBar();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radBtnSql = new System.Windows.Forms.RadioButton();
            this.radBtnWindows = new System.Windows.Forms.RadioButton();
            this.comboDatabase = new System.Windows.Forms.ComboBox();
            this.comboServer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBackupSave = new System.Windows.Forms.ComboBox();
            this.radBtnManualBackup = new System.Windows.Forms.RadioButton();
            this.radBtnAutoBackup = new System.Windows.Forms.RadioButton();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlRestore = new System.Windows.Forms.Panel();
            this.btnAutoRestore = new System.Windows.Forms.Button();
            this.txtAutoRestore = new System.Windows.Forms.TextBox();
            this.progressBarRestore = new System.Windows.Forms.ProgressBar();
            this.errProviderServer = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipServer = new System.Windows.Forms.ToolTip(this.components);
            this.timerServer = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlConnections.SuspendLayout();
            this.pnlServer.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderServer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDBName
            // 
            this.txtDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDBName.ForeColor = System.Drawing.Color.Blue;
            this.txtDBName.Location = new System.Drawing.Point(77, 110);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDBName.Size = new System.Drawing.Size(399, 29);
            this.txtDBName.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(486, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 24);
            this.label1.TabIndex = 133;
            this.label1.Text = "اسم النسخة الاحتياطية :";
            // 
            // progressBarBackup
            // 
            this.progressBarBackup.Location = new System.Drawing.Point(4, 6);
            this.progressBarBackup.Name = "progressBarBackup";
            this.progressBarBackup.RightToLeftLayout = true;
            this.progressBarBackup.Size = new System.Drawing.Size(732, 11);
            this.progressBarBackup.TabIndex = 132;
            // 
            // comboBackupDelete
            // 
            this.comboBackupDelete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBackupDelete.Enabled = false;
            this.comboBackupDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBackupDelete.FormattingEnabled = true;
            this.comboBackupDelete.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "15",
            "21",
            "30"});
            this.comboBackupDelete.Location = new System.Drawing.Point(316, 181);
            this.comboBackupDelete.Name = "comboBackupDelete";
            this.comboBackupDelete.Size = new System.Drawing.Size(160, 32);
            this.comboBackupDelete.TabIndex = 130;
            this.comboBackupDelete.SelectedIndexChanged += new System.EventHandler(this.comboBackupDelete_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(262, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 24);
            this.label4.TabIndex = 129;
            this.label4.Text = "دقيقة";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(514, 71);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(249, 24);
            this.label16.TabIndex = 137;
            this.label16.Text = "مسار استرجاع النسخة الاحتياطية :";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDes);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pbTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(750, 83);
            this.pnlTop.TabIndex = 11;
            // 
            // lblDes
            // 
            this.lblDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDes.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblDes.Location = new System.Drawing.Point(47, 47);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(540, 24);
            this.lblDes.TabIndex = 66;
            this.lblDes.Text = "من خلال هذة النافذة يتم التحكم فى طرق الاتصال وإنشاء واسترداد النسخ الاحتياطي";
            this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(108, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(479, 35);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "إدارة الاتصال بالسيرفير";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.Image = global::PharmacySystemV20._0._1.Properties.Resources.DatabasePic;
            this.pbTitle.Location = new System.Drawing.Point(593, 5);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(154, 71);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 64;
            this.pbTitle.TabStop = false;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnClose);
            this.pnlControls.Controls.Add(this.btnSaveSettings);
            this.pnlControls.Controls.Add(this.btnRestore);
            this.pnlControls.Controls.Add(this.btnBackup);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 388);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(750, 62);
            this.pnlControls.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Image = global::PharmacySystemV20._0._1.Properties.Resources.Exit;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(563, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 46);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnSaveSettings.FlatAppearance.BorderSize = 0;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveSettings.Location = new System.Drawing.Point(8, 9);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(180, 46);
            this.btnSaveSettings.TabIndex = 6;
            this.btnSaveSettings.Text = "حفظ إعدادات الاتصال";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRestore.Location = new System.Drawing.Point(7, 8);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(180, 46);
            this.btnRestore.TabIndex = 8;
            this.btnRestore.Text = "استرجاع نسخة احتياطية";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBackup.Location = new System.Drawing.Point(7, 8);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(180, 46);
            this.btnBackup.TabIndex = 7;
            this.btnBackup.Text = "انشاء نسخة احتياطية";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnServerTab
            // 
            this.btnServerTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.btnServerTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnServerTab.FlatAppearance.BorderSize = 0;
            this.btnServerTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnServerTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerTab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnServerTab.Image = global::PharmacySystemV20._0._1.Properties.Resources.SaveSettings;
            this.btnServerTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnServerTab.Location = new System.Drawing.Point(556, 4);
            this.btnServerTab.Name = "btnServerTab";
            this.btnServerTab.Size = new System.Drawing.Size(184, 38);
            this.btnServerTab.TabIndex = 1;
            this.btnServerTab.Text = "الاتصال بالسيرفير";
            this.btnServerTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServerTab.UseVisualStyleBackColor = false;
            this.btnServerTab.Click += new System.EventHandler(this.btnServerTab_Click);
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.btnRestoreTab);
            this.pnlTabs.Controls.Add(this.btnBackupTab);
            this.pnlTabs.Controls.Add(this.btnServerTab);
            this.pnlTabs.Location = new System.Drawing.Point(3, 87);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(744, 48);
            this.pnlTabs.TabIndex = 0;
            // 
            // btnRestoreTab
            // 
            this.btnRestoreTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(203)))), ((int)(((byte)(210)))));
            this.btnRestoreTab.FlatAppearance.BorderSize = 0;
            this.btnRestoreTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnRestoreTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoreTab.Image = global::PharmacySystemV20._0._1.Properties.Resources.RestorePic;
            this.btnRestoreTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestoreTab.Location = new System.Drawing.Point(176, 4);
            this.btnRestoreTab.Name = "btnRestoreTab";
            this.btnRestoreTab.Size = new System.Drawing.Size(184, 38);
            this.btnRestoreTab.TabIndex = 3;
            this.btnRestoreTab.Text = "إسترداد نسخة احتياطية";
            this.btnRestoreTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestoreTab.UseVisualStyleBackColor = false;
            this.btnRestoreTab.Click += new System.EventHandler(this.btnRestoreTab_Click);
            // 
            // btnBackupTab
            // 
            this.btnBackupTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(203)))), ((int)(((byte)(210)))));
            this.btnBackupTab.FlatAppearance.BorderSize = 0;
            this.btnBackupTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnBackupTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupTab.Image = global::PharmacySystemV20._0._1.Properties.Resources.BackupPic;
            this.btnBackupTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackupTab.Location = new System.Drawing.Point(366, 4);
            this.btnBackupTab.Name = "btnBackupTab";
            this.btnBackupTab.Size = new System.Drawing.Size(184, 38);
            this.btnBackupTab.TabIndex = 2;
            this.btnBackupTab.Text = "إنشاء نسخة احتياطية";
            this.btnBackupTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupTab.UseVisualStyleBackColor = false;
            this.btnBackupTab.Click += new System.EventHandler(this.btnBackupTab_Click);
            // 
            // pnlConnections
            // 
            this.pnlConnections.Controls.Add(this.pnlTabs);
            this.pnlConnections.Controls.Add(this.pnlServer);
            this.pnlConnections.Controls.Add(this.pnlBackup);
            this.pnlConnections.Controls.Add(this.pnlRestore);
            this.pnlConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConnections.Location = new System.Drawing.Point(0, 0);
            this.pnlConnections.Name = "pnlConnections";
            this.pnlConnections.Size = new System.Drawing.Size(750, 450);
            this.pnlConnections.TabIndex = 12;
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.btnVisible);
            this.pnlServer.Controls.Add(this.progressBarServer);
            this.pnlServer.Controls.Add(this.txtPassword);
            this.pnlServer.Controls.Add(this.label2);
            this.pnlServer.Controls.Add(this.txtUser);
            this.pnlServer.Controls.Add(this.label3);
            this.pnlServer.Controls.Add(this.radBtnSql);
            this.pnlServer.Controls.Add(this.radBtnWindows);
            this.pnlServer.Controls.Add(this.comboDatabase);
            this.pnlServer.Controls.Add(this.comboServer);
            this.pnlServer.Controls.Add(this.label5);
            this.pnlServer.Controls.Add(this.label10);
            this.pnlServer.Controls.Add(this.label11);
            this.pnlServer.Location = new System.Drawing.Point(6, 141);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(740, 248);
            this.pnlServer.TabIndex = 0;
            // 
            // btnVisible
            // 
            this.btnVisible.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Invisible;
            this.btnVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVisible.FlatAppearance.BorderSize = 0;
            this.btnVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisible.Location = new System.Drawing.Point(211, 211);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(39, 28);
            this.btnVisible.TabIndex = 131;
            this.btnVisible.UseVisualStyleBackColor = true;
            this.btnVisible.Click += new System.EventHandler(this.btnVisible_Click);
            // 
            // progressBarServer
            // 
            this.progressBarServer.Location = new System.Drawing.Point(4, 4);
            this.progressBarServer.MarqueeAnimationSpeed = 1;
            this.progressBarServer.Name = "progressBarServer";
            this.progressBarServer.RightToLeftLayout = true;
            this.progressBarServer.Size = new System.Drawing.Size(732, 11);
            this.progressBarServer.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.ForeColor = System.Drawing.Color.Blue;
            this.txtPassword.Location = new System.Drawing.Point(256, 212);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(344, 29);
            this.txtPassword.TabIndex = 128;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 130;
            this.label2.Text = "كلمة المرور :";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtUser.ForeColor = System.Drawing.Color.Blue;
            this.txtUser.Location = new System.Drawing.Point(256, 176);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(344, 29);
            this.txtUser.TabIndex = 127;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(608, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 129;
            this.label3.Text = " المستخدم :";
            // 
            // radBtnSql
            // 
            this.radBtnSql.AutoSize = true;
            this.radBtnSql.ForeColor = System.Drawing.Color.Blue;
            this.radBtnSql.Location = new System.Drawing.Point(380, 138);
            this.radBtnSql.Name = "radBtnSql";
            this.radBtnSql.Size = new System.Drawing.Size(277, 28);
            this.radBtnSql.TabIndex = 126;
            this.radBtnSql.TabStop = true;
            this.radBtnSql.Text = "SQL Server Authentication";
            this.radBtnSql.UseVisualStyleBackColor = true;
            // 
            // radBtnWindows
            // 
            this.radBtnWindows.AutoSize = true;
            this.radBtnWindows.ForeColor = System.Drawing.Color.Blue;
            this.radBtnWindows.Location = new System.Drawing.Point(397, 107);
            this.radBtnWindows.Name = "radBtnWindows";
            this.radBtnWindows.Size = new System.Drawing.Size(255, 28);
            this.radBtnWindows.TabIndex = 67;
            this.radBtnWindows.TabStop = true;
            this.radBtnWindows.Text = "Windows Authentication";
            this.radBtnWindows.UseVisualStyleBackColor = true;
            // 
            // comboDatabase
            // 
            this.comboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboDatabase.FormattingEnabled = true;
            this.comboDatabase.Location = new System.Drawing.Point(256, 66);
            this.comboDatabase.Name = "comboDatabase";
            this.comboDatabase.Size = new System.Drawing.Size(344, 32);
            this.comboDatabase.TabIndex = 125;
            // 
            // comboServer
            // 
            this.comboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboServer.FormattingEnabled = true;
            this.comboServer.Location = new System.Drawing.Point(256, 25);
            this.comboServer.Name = "comboServer";
            this.comboServer.Size = new System.Drawing.Size(344, 32);
            this.comboServer.TabIndex = 124;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 48);
            this.label5.TabIndex = 95;
            this.label5.Text = "طريقة\r\n الاتصال بالسيرفير :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(608, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 24);
            this.label10.TabIndex = 92;
            this.label10.Text = "قاعدة البيانات :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(608, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 24);
            this.label11.TabIndex = 91;
            this.label11.Text = "اسم السيرفير :";
            // 
            // pnlBackup
            // 
            this.pnlBackup.Controls.Add(this.txtDBName);
            this.pnlBackup.Controls.Add(this.label1);
            this.pnlBackup.Controls.Add(this.progressBarBackup);
            this.pnlBackup.Controls.Add(this.label6);
            this.pnlBackup.Controls.Add(this.comboBackupDelete);
            this.pnlBackup.Controls.Add(this.label4);
            this.pnlBackup.Controls.Add(this.comboBackupSave);
            this.pnlBackup.Controls.Add(this.radBtnManualBackup);
            this.pnlBackup.Controls.Add(this.radBtnAutoBackup);
            this.pnlBackup.Controls.Add(this.btnBackupPath);
            this.pnlBackup.Controls.Add(this.label9);
            this.pnlBackup.Controls.Add(this.label15);
            this.pnlBackup.Controls.Add(this.txtBackupPath);
            this.pnlBackup.Controls.Add(this.label13);
            this.pnlBackup.Controls.Add(this.label14);
            this.pnlBackup.Location = new System.Drawing.Point(5, 141);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(740, 248);
            this.pnlBackup.TabIndex = 4;
            this.pnlBackup.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(278, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 24);
            this.label6.TabIndex = 131;
            this.label6.Text = "يوم";
            // 
            // comboBackupSave
            // 
            this.comboBackupSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBackupSave.Enabled = false;
            this.comboBackupSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBackupSave.FormattingEnabled = true;
            this.comboBackupSave.Items.AddRange(new object[] {
            "15",
            "30",
            "60",
            "120",
            "180",
            "240"});
            this.comboBackupSave.Location = new System.Drawing.Point(316, 72);
            this.comboBackupSave.Name = "comboBackupSave";
            this.comboBackupSave.Size = new System.Drawing.Size(160, 32);
            this.comboBackupSave.TabIndex = 128;
            this.comboBackupSave.SelectedIndexChanged += new System.EventHandler(this.comboBackupSave_SelectedIndexChanged);
            // 
            // radBtnManualBackup
            // 
            this.radBtnManualBackup.AutoSize = true;
            this.radBtnManualBackup.Checked = true;
            this.radBtnManualBackup.ForeColor = System.Drawing.Color.Blue;
            this.radBtnManualBackup.Location = new System.Drawing.Point(372, 39);
            this.radBtnManualBackup.Name = "radBtnManualBackup";
            this.radBtnManualBackup.Size = new System.Drawing.Size(42, 28);
            this.radBtnManualBackup.TabIndex = 127;
            this.radBtnManualBackup.TabStop = true;
            this.radBtnManualBackup.Text = "لا";
            this.radBtnManualBackup.UseVisualStyleBackColor = true;
            this.radBtnManualBackup.CheckedChanged += new System.EventHandler(this.radBtnManualBackup_CheckedChanged);
            // 
            // radBtnAutoBackup
            // 
            this.radBtnAutoBackup.AutoSize = true;
            this.radBtnAutoBackup.ForeColor = System.Drawing.Color.Blue;
            this.radBtnAutoBackup.Location = new System.Drawing.Point(425, 39);
            this.radBtnAutoBackup.Name = "radBtnAutoBackup";
            this.radBtnAutoBackup.Size = new System.Drawing.Size(52, 28);
            this.radBtnAutoBackup.TabIndex = 126;
            this.radBtnAutoBackup.Text = "نعم";
            this.radBtnAutoBackup.UseVisualStyleBackColor = true;
            this.radBtnAutoBackup.CheckedChanged += new System.EventHandler(this.radBtnAutoBackup_CheckedChanged);
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.BackColor = System.Drawing.Color.Transparent;
            this.btnBackupPath.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Folder;
            this.btnBackupPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBackupPath.FlatAppearance.BorderSize = 0;
            this.btnBackupPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupPath.Location = new System.Drawing.Point(38, 146);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(32, 27);
            this.btnBackupPath.TabIndex = 124;
            this.btnBackupPath.UseVisualStyleBackColor = false;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(486, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 24);
            this.label9.TabIndex = 119;
            this.label9.Text = "تفعيل الحفظ التلقائى :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(486, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(275, 24);
            this.label15.TabIndex = 85;
            this.label15.Text = "حذف النسخ الاحتياطية التى مر عليها :";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBackupPath.ForeColor = System.Drawing.Color.Blue;
            this.txtBackupPath.Location = new System.Drawing.Point(77, 146);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBackupPath.Size = new System.Drawing.Size(399, 29);
            this.txtBackupPath.TabIndex = 5;
            this.txtBackupPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(486, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 24);
            this.label13.TabIndex = 83;
            this.label13.Text = "مسار حفظ البيانات :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(486, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 24);
            this.label14.TabIndex = 82;
            this.label14.Text = "أخذ نسخة احتياطية كل :";
            // 
            // pnlRestore
            // 
            this.pnlRestore.Controls.Add(this.btnAutoRestore);
            this.pnlRestore.Controls.Add(this.txtAutoRestore);
            this.pnlRestore.Controls.Add(this.label16);
            this.pnlRestore.Controls.Add(this.progressBarRestore);
            this.pnlRestore.Location = new System.Drawing.Point(6, 139);
            this.pnlRestore.Name = "pnlRestore";
            this.pnlRestore.Size = new System.Drawing.Size(740, 248);
            this.pnlRestore.TabIndex = 131;
            // 
            // btnAutoRestore
            // 
            this.btnAutoRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnAutoRestore.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Folder;
            this.btnAutoRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAutoRestore.FlatAppearance.BorderSize = 0;
            this.btnAutoRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoRestore.Location = new System.Drawing.Point(37, 109);
            this.btnAutoRestore.Name = "btnAutoRestore";
            this.btnAutoRestore.Size = new System.Drawing.Size(32, 27);
            this.btnAutoRestore.TabIndex = 141;
            this.btnAutoRestore.UseVisualStyleBackColor = false;
            this.btnAutoRestore.Click += new System.EventHandler(this.btnAutoRestore_Click);
            // 
            // txtAutoRestore
            // 
            this.txtAutoRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAutoRestore.ForeColor = System.Drawing.Color.Blue;
            this.txtAutoRestore.Location = new System.Drawing.Point(76, 109);
            this.txtAutoRestore.Name = "txtAutoRestore";
            this.txtAutoRestore.ReadOnly = true;
            this.txtAutoRestore.Size = new System.Drawing.Size(589, 29);
            this.txtAutoRestore.TabIndex = 135;
            this.txtAutoRestore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // progressBarRestore
            // 
            this.progressBarRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(87)))));
            this.progressBarRestore.Location = new System.Drawing.Point(4, 4);
            this.progressBarRestore.Name = "progressBarRestore";
            this.progressBarRestore.RightToLeftLayout = true;
            this.progressBarRestore.Size = new System.Drawing.Size(732, 11);
            this.progressBarRestore.TabIndex = 7;
            // 
            // errProviderServer
            // 
            this.errProviderServer.ContainerControl = this;
            this.errProviderServer.Icon = ((System.Drawing.Icon)(resources.GetObject("errProviderServer.Icon")));
            this.errProviderServer.RightToLeft = true;
            // 
            // timerServer
            // 
            this.timerServer.Interval = 300;
            this.timerServer.Tick += new System.EventHandler(this.timerServer_Tick);
            // 
            // FRM_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlConnections);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Server";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة إعدادات قواعد البيانات";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlConnections.ResumeLayout(false);
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            this.pnlRestore.ResumeLayout(false);
            this.pnlRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderServer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarBackup;
        public System.Windows.Forms.ComboBox comboBackupDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnServerTab;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnRestoreTab;
        private System.Windows.Forms.Button btnBackupTab;
        private System.Windows.Forms.Panel pnlConnections;
        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBackupSave;
        private System.Windows.Forms.RadioButton radBtnManualBackup;
        private System.Windows.Forms.RadioButton radBtnAutoBackup;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel pnlRestore;
        private System.Windows.Forms.Button btnAutoRestore;
        public System.Windows.Forms.TextBox txtAutoRestore;
        private System.Windows.Forms.ProgressBar progressBarRestore;
        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Button btnVisible;
        private System.Windows.Forms.ProgressBar progressBarServer;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radBtnSql;
        private System.Windows.Forms.RadioButton radBtnWindows;
        public System.Windows.Forms.ComboBox comboDatabase;
        public System.Windows.Forms.ComboBox comboServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ErrorProvider errProviderServer;
        public System.Windows.Forms.ToolTip toolTipServer;
        public System.Windows.Forms.Timer timerServer;
    }
}