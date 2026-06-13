namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Users));
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlUsers = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblUserActivate = new System.Windows.Forms.Label();
            this.lblDes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblID = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnVisible = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbtnNotUser = new System.Windows.Forms.RadioButton();
            this.rbtnIsUser = new System.Windows.Forms.RadioButton();
            this.lblUserStatus = new System.Windows.Forms.Label();
            this.comboGender = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboJob = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNatID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.bnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbUsers = new System.Windows.Forms.PictureBox();
            this.toolTipUsers = new System.Windows.Forms.ToolTip(this.components);
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.errProviderUsers = new System.Windows.Forms.ErrorProvider(this.components);
            this.timerUsers = new System.Windows.Forms.Timer(this.components);
            this.comboRule = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlControls.Controls.Add(this.btnSearch);
            this.pnlControls.Controls.Add(this.btnExit);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.btnSave);
            this.pnlControls.Controls.Add(this.btnModify);
            this.pnlControls.Controls.Add(this.btnNew);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 444);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(734, 56);
            this.pnlControls.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::PharmacySystemV20._0._1.Properties.Resources.Search_Google;
            this.btnSearch.Location = new System.Drawing.Point(291, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 48);
            this.btnSearch.TabIndex = 4;
            this.toolTipUsers.SetToolTip(this.btnSearch, "بحث");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PharmacySystemV20._0._1.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(682, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 5;
            this.toolTipUsers.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::PharmacySystemV20._0._1.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(220, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.TabIndex = 3;
            this.toolTipUsers.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::PharmacySystemV20._0._1.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(149, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 48);
            this.btnSave.TabIndex = 2;
            this.toolTipUsers.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Image = global::PharmacySystemV20._0._1.Properties.Resources.Edit;
            this.btnModify.Location = new System.Drawing.Point(78, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(48, 48);
            this.btnModify.TabIndex = 1;
            this.toolTipUsers.SetToolTip(this.btnModify, "تعديل");
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::PharmacySystemV20._0._1.Properties.Resources.Add;
            this.btnNew.Location = new System.Drawing.Point(7, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(48, 48);
            this.btnNew.TabIndex = 0;
            this.toolTipUsers.SetToolTip(this.btnNew, "إضافة");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlUsers
            // 
            this.pnlUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.pnlUsers.Controls.Add(this.comboRule);
            this.pnlUsers.Controls.Add(this.label9);
            this.pnlUsers.Controls.Add(this.btnAddRule);
            this.pnlUsers.Controls.Add(this.btnClose);
            this.pnlUsers.Controls.Add(this.lblUserActivate);
            this.pnlUsers.Controls.Add(this.lblDes);
            this.pnlUsers.Controls.Add(this.lblTitle);
            this.pnlUsers.Controls.Add(this.pbTitle);
            this.pnlUsers.Controls.Add(this.splitter1);
            this.pnlUsers.Controls.Add(this.lblID);
            this.pnlUsers.Controls.Add(this.btnSelect);
            this.pnlUsers.Controls.Add(this.label8);
            this.pnlUsers.Controls.Add(this.btnVisible);
            this.pnlUsers.Controls.Add(this.txtPassword);
            this.pnlUsers.Controls.Add(this.label11);
            this.pnlUsers.Controls.Add(this.txtUserName);
            this.pnlUsers.Controls.Add(this.label10);
            this.pnlUsers.Controls.Add(this.rbtnNotUser);
            this.pnlUsers.Controls.Add(this.rbtnIsUser);
            this.pnlUsers.Controls.Add(this.lblUserStatus);
            this.pnlUsers.Controls.Add(this.comboGender);
            this.pnlUsers.Controls.Add(this.label7);
            this.pnlUsers.Controls.Add(this.comboJob);
            this.pnlUsers.Controls.Add(this.label6);
            this.pnlUsers.Controls.Add(this.txtAddress);
            this.pnlUsers.Controls.Add(this.label5);
            this.pnlUsers.Controls.Add(this.txtNatID);
            this.pnlUsers.Controls.Add(this.label4);
            this.pnlUsers.Controls.Add(this.txtPhone);
            this.pnlUsers.Controls.Add(this.label3);
            this.pnlUsers.Controls.Add(this.txtFullName);
            this.pnlUsers.Controls.Add(this.label2);
            this.pnlUsers.Controls.Add(this.btnAdd);
            this.pnlUsers.Controls.Add(this.bnClear);
            this.pnlUsers.Controls.Add(this.label1);
            this.pnlUsers.Controls.Add(this.pbUsers);
            this.pnlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUsers.Location = new System.Drawing.Point(0, 0);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(734, 444);
            this.pnlUsers.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::PharmacySystemV20._0._1.Properties.Resources.ClosePic;
            this.btnClose.Location = new System.Drawing.Point(2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(53, 48);
            this.btnClose.TabIndex = 65;
            this.toolTipUsers.SetToolTip(this.btnClose, "خروج");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblUserActivate
            // 
            this.lblUserActivate.AutoSize = true;
            this.lblUserActivate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserActivate.Font = new System.Drawing.Font("LBC", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserActivate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(101)))), ((int)(((byte)(116)))));
            this.lblUserActivate.Location = new System.Drawing.Point(17, 131);
            this.lblUserActivate.Name = "lblUserActivate";
            this.lblUserActivate.Size = new System.Drawing.Size(183, 16);
            this.lblUserActivate.TabIndex = 64;
            this.lblUserActivate.Text = "انقر هنا لإعادة تفعيل المستخدم";
            this.lblUserActivate.Visible = false;
            this.lblUserActivate.Click += new System.EventHandler(this.lblUserActivate_Click);
            // 
            // lblDes
            // 
            this.lblDes.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDes.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblDes.Location = new System.Drawing.Point(4, 53);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(575, 24);
            this.lblDes.TabIndex = 63;
            this.lblDes.Text = "من خلال هذة النافذة يتم تعريف مستخدم جديد للبرنامح";
            this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(4, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(575, 43);
            this.lblTitle.TabIndex = 62;
            this.lblTitle.Text = "بيانات المستخدمين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.Image = global::PharmacySystemV20._0._1.Properties.Resources.AdminPic;
            this.pbTitle.Location = new System.Drawing.Point(585, 6);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(145, 71);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTitle.TabIndex = 61;
            this.pbTitle.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.splitter1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(734, 83);
            this.splitter1.TabIndex = 60;
            this.splitter1.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(245, 116);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(358, 27);
            this.lblID.TabIndex = 58;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelect
            // 
            this.btnSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelect.BackgroundImage")));
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(151, 293);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(39, 28);
            this.btnSelect.TabIndex = 57;
            this.toolTipUsers.SetToolTip(this.btnSelect, "تحديد");
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(611, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 56;
            this.label8.Text = "الحالة :";
            // 
            // btnVisible
            // 
            this.btnVisible.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Invisible;
            this.btnVisible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVisible.FlatAppearance.BorderSize = 0;
            this.btnVisible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisible.Location = new System.Drawing.Point(11, 400);
            this.btnVisible.Name = "btnVisible";
            this.btnVisible.Size = new System.Drawing.Size(39, 28);
            this.btnVisible.TabIndex = 55;
            this.toolTipUsers.SetToolTip(this.btnVisible, "عرض كلمة المرور");
            this.btnVisible.UseVisualStyleBackColor = true;
            this.btnVisible.Click += new System.EventHandler(this.btnVisible_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPassword.Location = new System.Drawing.Point(69, 401);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(213, 27);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Validated += new System.EventHandler(this.txtPassword_Validated);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(290, 404);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "كلمة المرور :";
            // 
            // txtUserName
            // 
            this.txtUserName.Enabled = false;
            this.txtUserName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtUserName.Location = new System.Drawing.Point(390, 401);
            this.txtUserName.MaxLength = 35;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(213, 27);
            this.txtUserName.TabIndex = 8;
            this.txtUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserName_KeyDown);
            this.txtUserName.Validated += new System.EventHandler(this.txtUserName_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(611, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "اسم المستخدم :";
            // 
            // rbtnNotUser
            // 
            this.rbtnNotUser.AutoSize = true;
            this.rbtnNotUser.Checked = true;
            this.rbtnNotUser.Location = new System.Drawing.Point(350, 284);
            this.rbtnNotUser.Name = "rbtnNotUser";
            this.rbtnNotUser.Size = new System.Drawing.Size(106, 24);
            this.rbtnNotUser.TabIndex = 5;
            this.rbtnNotUser.TabStop = true;
            this.rbtnNotUser.Text = "غير مستخدم";
            this.rbtnNotUser.UseVisualStyleBackColor = true;
            this.rbtnNotUser.CheckedChanged += new System.EventHandler(this.rbtnNotUser_CheckedChanged);
            // 
            // rbtnIsUser
            // 
            this.rbtnIsUser.AutoSize = true;
            this.rbtnIsUser.Location = new System.Drawing.Point(517, 284);
            this.rbtnIsUser.Name = "rbtnIsUser";
            this.rbtnIsUser.Size = new System.Drawing.Size(83, 24);
            this.rbtnIsUser.TabIndex = 4;
            this.rbtnIsUser.Text = "مستخدم";
            this.rbtnIsUser.UseVisualStyleBackColor = true;
            this.rbtnIsUser.CheckedChanged += new System.EventHandler(this.rbtnIsUser_CheckedChanged);
            // 
            // lblUserStatus
            // 
            this.lblUserStatus.AutoSize = true;
            this.lblUserStatus.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.lblUserStatus.Location = new System.Drawing.Point(4, 90);
            this.lblUserStatus.Name = "lblUserStatus";
            this.lblUserStatus.Size = new System.Drawing.Size(108, 21);
            this.lblUserStatus.TabIndex = 47;
            this.lblUserStatus.Text = "مستخدم نشط";
            this.lblUserStatus.Visible = false;
            // 
            // comboGender
            // 
            this.comboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGender.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboGender.FormattingEnabled = true;
            this.comboGender.Location = new System.Drawing.Point(69, 359);
            this.comboGender.Name = "comboGender";
            this.comboGender.Size = new System.Drawing.Size(213, 28);
            this.comboGender.TabIndex = 7;
            this.comboGender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboGender_KeyDown);
            this.comboGender.Validated += new System.EventHandler(this.comboGender_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(290, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 45;
            this.label7.Text = "النوع :";
            // 
            // comboJob
            // 
            this.comboJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJob.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboJob.FormattingEnabled = true;
            this.comboJob.Location = new System.Drawing.Point(390, 359);
            this.comboJob.Name = "comboJob";
            this.comboJob.Size = new System.Drawing.Size(213, 28);
            this.comboJob.TabIndex = 6;
            this.comboJob.DropDown += new System.EventHandler(this.comboJob_DropDown);
            this.comboJob.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboJob_KeyDown);
            this.comboJob.Validated += new System.EventHandler(this.comboJob_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(611, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 20);
            this.label6.TabIndex = 43;
            this.label6.Text = "الوظيفة :";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Location = new System.Drawing.Point(245, 182);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(358, 27);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            this.txtAddress.Validated += new System.EventHandler(this.txtAddress_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(611, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "العنوان :";
            // 
            // txtNatID
            // 
            this.txtNatID.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNatID.Location = new System.Drawing.Point(245, 248);
            this.txtNatID.MaxLength = 14;
            this.txtNatID.Name = "txtNatID";
            this.txtNatID.Size = new System.Drawing.Size(358, 27);
            this.txtNatID.TabIndex = 3;
            this.txtNatID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNatID_KeyDown);
            this.txtNatID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtNatID.Validated += new System.EventHandler(this.txtNatID_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(611, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "الرقم القومى :";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone.Location = new System.Drawing.Point(245, 215);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(358, 27);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validated += new System.EventHandler(this.txtPhone_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "رقم المحمول :";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFullName.Location = new System.Drawing.Point(245, 149);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(358, 27);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            this.txtFullName.Validated += new System.EventHandler(this.txtFullName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "الاسم بالكامل :";
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Select;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(681, 361);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 28);
            this.btnAdd.TabIndex = 10;
            this.toolTipUsers.SetToolTip(this.btnAdd, "إضافة وظيفة اخرى");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // bnClear
            // 
            this.bnClear.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Erease;
            this.bnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bnClear.FlatAppearance.BorderSize = 0;
            this.bnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnClear.Location = new System.Drawing.Point(7, 293);
            this.bnClear.Name = "bnClear";
            this.bnClear.Size = new System.Drawing.Size(39, 28);
            this.bnClear.TabIndex = 32;
            this.toolTipUsers.SetToolTip(this.bnClear, "مسح");
            this.bnClear.UseVisualStyleBackColor = true;
            this.bnClear.Click += new System.EventHandler(this.bnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(611, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "كود المستخدم :";
            // 
            // pbUsers
            // 
            this.pbUsers.Image = global::PharmacySystemV20._0._1.Properties.Resources.User;
            this.pbUsers.Location = new System.Drawing.Point(4, 150);
            this.pbUsers.Name = "pbUsers";
            this.pbUsers.Size = new System.Drawing.Size(186, 137);
            this.pbUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsers.TabIndex = 30;
            this.pbUsers.TabStop = false;
            // 
            // toolTipUsers
            // 
            this.toolTipUsers.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(734, 500);
            this.pnlContainer.TabIndex = 2;
            // 
            // errProviderUsers
            // 
            this.errProviderUsers.ContainerControl = this;
            this.errProviderUsers.RightToLeft = true;
            // 
            // timerUsers
            // 
            this.timerUsers.Interval = 500;
            this.timerUsers.Tick += new System.EventHandler(this.timerUsers_Tick);
            // 
            // comboRule
            // 
            this.comboRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRule.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboRule.FormattingEnabled = true;
            this.comboRule.Location = new System.Drawing.Point(390, 317);
            this.comboRule.Name = "comboRule";
            this.comboRule.Size = new System.Drawing.Size(213, 28);
            this.comboRule.TabIndex = 66;
            this.comboRule.DropDown += new System.EventHandler(this.comboRule_DropDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(608, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 68;
            this.label9.Text = "الصلاحية :";
            // 
            // btnAddRule
            // 
            this.btnAddRule.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Select;
            this.btnAddRule.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddRule.FlatAppearance.BorderSize = 0;
            this.btnAddRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRule.Location = new System.Drawing.Point(681, 319);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(39, 28);
            this.btnAddRule.TabIndex = 67;
            this.toolTipUsers.SetToolTip(this.btnAddRule, "إضافة وظيفة اخرى");
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // FRM_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 500);
            this.Controls.Add(this.pnlUsers);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Users";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة المستخدمين";
            this.pnlControls.ResumeLayout(false);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlUsers;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolTip toolTipUsers;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnVisible;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button bnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.ComboBox comboJob;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtUserName;
        public System.Windows.Forms.RadioButton rbtnNotUser;
        public System.Windows.Forms.RadioButton rbtnIsUser;
        public System.Windows.Forms.ComboBox comboGender;
        public System.Windows.Forms.TextBox txtAddress;
        public System.Windows.Forms.TextBox txtNatID;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.TextBox txtFullName;
        public System.Windows.Forms.PictureBox pbUsers;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.ErrorProvider errProviderUsers;
        public System.Windows.Forms.Timer timerUsers;
        public System.Windows.Forms.Label lblUserStatus;
        public System.Windows.Forms.Button btnModify;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Label lblUserActivate;
        public System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ComboBox comboRule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddRule;
    }
}