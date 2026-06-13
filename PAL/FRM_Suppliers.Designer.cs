namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Suppliers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Suppliers));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbSupStatus = new System.Windows.Forms.PictureBox();
            this.lblDes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.pnlSuppliers = new System.Windows.Forms.Panel();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnExtraTab = new System.Windows.Forms.Button();
            this.btnInfoTab = new System.Windows.Forms.Button();
            this.pnlInfoTab = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPhone3 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlExtraTab = new System.Windows.Forms.Panel();
            this.btnAddSize = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.comboSupType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboSize = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboGroup = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboArea = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbSupBalance = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBalanceStatus = new System.Windows.Forms.ComboBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.errProviderSuppliers = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipSuppliers = new System.Windows.Forms.ToolTip(this.components);
            this.timerSuppliers = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSupStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.pnlSuppliers.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlInfoTab.SuspendLayout();
            this.pnlExtraTab.SuspendLayout();
            this.gbSupBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pbSupStatus);
            this.pnlTop.Controls.Add(this.lblDes);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pbTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(750, 83);
            this.pnlTop.TabIndex = 0;
            // 
            // pbSupStatus
            // 
            this.pbSupStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSupStatus.Image = global::PharmacySystemV20._0._1.Properties.Resources.Disable_Client;
            this.pbSupStatus.Location = new System.Drawing.Point(8, 12);
            this.pbSupStatus.Name = "pbSupStatus";
            this.pbSupStatus.Size = new System.Drawing.Size(90, 64);
            this.pbSupStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSupStatus.TabIndex = 78;
            this.pbSupStatus.TabStop = false;
            this.pbSupStatus.Click += new System.EventHandler(this.pbSupStatus_Click);
            this.pbSupStatus.MouseLeave += new System.EventHandler(this.pbSupStatus_MouseLeave);
            this.pbSupStatus.MouseHover += new System.EventHandler(this.pbSupStatus_MouseHover);
            // 
            // lblDes
            // 
            this.lblDes.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDes.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblDes.Location = new System.Drawing.Point(108, 47);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(479, 24);
            this.lblDes.TabIndex = 66;
            this.lblDes.Text = "من خلال هذة النافذة يتم إضافة مورد جديد";
            this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(108, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(479, 35);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "بيانات الموردين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.Image = global::PharmacySystemV20._0._1.Properties.Resources.SuppliersPic;
            this.pbTitle.Location = new System.Drawing.Point(593, 5);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(154, 71);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTitle.TabIndex = 64;
            this.pbTitle.TabStop = false;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnSearch);
            this.pnlControls.Controls.Add(this.btnExit);
            this.pnlControls.Controls.Add(this.btnDelete);
            this.pnlControls.Controls.Add(this.btnSave);
            this.pnlControls.Controls.Add(this.btnModify);
            this.pnlControls.Controls.Add(this.btnNew);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 488);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(750, 62);
            this.pnlControls.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::PharmacySystemV20._0._1.Properties.Resources.Search_Google;
            this.btnSearch.Location = new System.Drawing.Point(298, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 48);
            this.btnSearch.TabIndex = 4;
            this.toolTipSuppliers.SetToolTip(this.btnSearch, "بحث");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::PharmacySystemV20._0._1.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(689, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 48);
            this.btnExit.TabIndex = 5;
            this.toolTipSuppliers.SetToolTip(this.btnExit, "خروج");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = global::PharmacySystemV20._0._1.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(227, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 48);
            this.btnDelete.TabIndex = 3;
            this.toolTipSuppliers.SetToolTip(this.btnDelete, "حذف");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = global::PharmacySystemV20._0._1.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(156, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 48);
            this.btnSave.TabIndex = 2;
            this.toolTipSuppliers.SetToolTip(this.btnSave, "حفظ");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.FlatAppearance.BorderSize = 0;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Image = global::PharmacySystemV20._0._1.Properties.Resources.Edit;
            this.btnModify.Location = new System.Drawing.Point(85, 7);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(48, 48);
            this.btnModify.TabIndex = 1;
            this.toolTipSuppliers.SetToolTip(this.btnModify, "تعديل");
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Image = global::PharmacySystemV20._0._1.Properties.Resources.Add;
            this.btnNew.Location = new System.Drawing.Point(14, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(48, 48);
            this.btnNew.TabIndex = 0;
            this.toolTipSuppliers.SetToolTip(this.btnNew, "إضافة");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // pnlSuppliers
            // 
            this.pnlSuppliers.Controls.Add(this.pnlTabs);
            this.pnlSuppliers.Controls.Add(this.pnlInfoTab);
            this.pnlSuppliers.Controls.Add(this.pnlExtraTab);
            this.pnlSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSuppliers.Location = new System.Drawing.Point(0, 83);
            this.pnlSuppliers.Name = "pnlSuppliers";
            this.pnlSuppliers.Size = new System.Drawing.Size(750, 405);
            this.pnlSuppliers.TabIndex = 0;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(84)))), ((int)(((byte)(96)))));
            this.pnlTabs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTabs.Controls.Add(this.btnExtraTab);
            this.pnlTabs.Controls.Add(this.btnInfoTab);
            this.pnlTabs.Location = new System.Drawing.Point(3, 6);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(744, 48);
            this.pnlTabs.TabIndex = 0;
            // 
            // btnExtraTab
            // 
            this.btnExtraTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(203)))), ((int)(((byte)(210)))));
            this.btnExtraTab.FlatAppearance.BorderSize = 0;
            this.btnExtraTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnExtraTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtraTab.Location = new System.Drawing.Point(366, 3);
            this.btnExtraTab.Name = "btnExtraTab";
            this.btnExtraTab.Size = new System.Drawing.Size(184, 38);
            this.btnExtraTab.TabIndex = 2;
            this.btnExtraTab.Text = "بيانات إضافية";
            this.btnExtraTab.UseVisualStyleBackColor = false;
            this.btnExtraTab.Click += new System.EventHandler(this.btnExtraTab_Click);
            // 
            // btnInfoTab
            // 
            this.btnInfoTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.btnInfoTab.FlatAppearance.BorderSize = 0;
            this.btnInfoTab.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btnInfoTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoTab.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInfoTab.Location = new System.Drawing.Point(556, 4);
            this.btnInfoTab.Name = "btnInfoTab";
            this.btnInfoTab.Size = new System.Drawing.Size(184, 38);
            this.btnInfoTab.TabIndex = 1;
            this.btnInfoTab.Text = "البيانات الاساسية";
            this.btnInfoTab.UseVisualStyleBackColor = false;
            this.btnInfoTab.Click += new System.EventHandler(this.btnInfoTab_Click);
            // 
            // pnlInfoTab
            // 
            this.pnlInfoTab.Controls.Add(this.txtEmail);
            this.pnlInfoTab.Controls.Add(this.label8);
            this.pnlInfoTab.Controls.Add(this.txtPhone3);
            this.pnlInfoTab.Controls.Add(this.txtPhone2);
            this.pnlInfoTab.Controls.Add(this.txtResponsible);
            this.pnlInfoTab.Controls.Add(this.txtAddress);
            this.pnlInfoTab.Controls.Add(this.label7);
            this.pnlInfoTab.Controls.Add(this.txtFax);
            this.pnlInfoTab.Controls.Add(this.label6);
            this.pnlInfoTab.Controls.Add(this.lblID);
            this.pnlInfoTab.Controls.Add(this.txtCompany);
            this.pnlInfoTab.Controls.Add(this.label5);
            this.pnlInfoTab.Controls.Add(this.txtPhone1);
            this.pnlInfoTab.Controls.Add(this.label4);
            this.pnlInfoTab.Controls.Add(this.label3);
            this.pnlInfoTab.Controls.Add(this.txtFullName);
            this.pnlInfoTab.Controls.Add(this.label2);
            this.pnlInfoTab.Controls.Add(this.label1);
            this.pnlInfoTab.Location = new System.Drawing.Point(3, 58);
            this.pnlInfoTab.Name = "pnlInfoTab";
            this.pnlInfoTab.Size = new System.Drawing.Size(740, 339);
            this.pnlInfoTab.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEmail.Location = new System.Drawing.Point(261, 257);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(340, 27);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(606, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 20);
            this.label8.TabIndex = 103;
            this.label8.Text = "الايميل :";
            // 
            // txtPhone3
            // 
            this.txtPhone3.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone3.Location = new System.Drawing.Point(85, 190);
            this.txtPhone3.MaxLength = 11;
            this.txtPhone3.Name = "txtPhone3";
            this.txtPhone3.Size = new System.Drawing.Size(164, 27);
            this.txtPhone3.TabIndex = 6;
            this.txtPhone3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone3_KeyDown);
            this.txtPhone3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone3_KeyPress);
            // 
            // txtPhone2
            // 
            this.txtPhone2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone2.Location = new System.Drawing.Point(261, 190);
            this.txtPhone2.MaxLength = 11;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(164, 27);
            this.txtPhone2.TabIndex = 5;
            this.txtPhone2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone2_KeyDown);
            this.txtPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone2_KeyPress);
            // 
            // txtResponsible
            // 
            this.txtResponsible.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtResponsible.Location = new System.Drawing.Point(85, 155);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(516, 27);
            this.txtResponsible.TabIndex = 3;
            this.txtResponsible.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResponsible_KeyDown);
            this.txtResponsible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResponsible_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Location = new System.Drawing.Point(85, 121);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(516, 27);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(606, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 98;
            this.label7.Text = "العنوان :";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFax.Location = new System.Drawing.Point(437, 223);
            this.txtFax.MaxLength = 10;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(164, 27);
            this.txtFax.TabIndex = 7;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFax_KeyDown);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(606, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 97;
            this.label6.Text = "الفاكس :";
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(85, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(516, 27);
            this.lblID.TabIndex = 1;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCompany.Location = new System.Drawing.Point(85, 87);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(516, 27);
            this.txtCompany.TabIndex = 1;
            this.txtCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompany_KeyDown);
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(606, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 95;
            this.label5.Text = "اسم الشركة :";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone1.Location = new System.Drawing.Point(437, 190);
            this.txtPhone1.MaxLength = 11;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(164, 27);
            this.txtPhone1.TabIndex = 4;
            this.txtPhone1.TextChanged += new System.EventHandler(this.txtPhone1_TextChanged);
            this.txtPhone1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone1_KeyDown);
            this.txtPhone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 94;
            this.label4.Text = "رقم المحمول :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = " مسئول التواصل :";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFullName.Location = new System.Drawing.Point(85, 53);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(516, 27);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 92;
            this.label2.Text = "الاسم بالكامل :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(606, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 91;
            this.label1.Text = "كود المورد :";
            // 
            // pnlExtraTab
            // 
            this.pnlExtraTab.Controls.Add(this.btnAddSize);
            this.pnlExtraTab.Controls.Add(this.btnAddGroup);
            this.pnlExtraTab.Controls.Add(this.btnAddArea);
            this.pnlExtraTab.Controls.Add(this.comboSupType);
            this.pnlExtraTab.Controls.Add(this.label9);
            this.pnlExtraTab.Controls.Add(this.comboSize);
            this.pnlExtraTab.Controls.Add(this.label12);
            this.pnlExtraTab.Controls.Add(this.comboGroup);
            this.pnlExtraTab.Controls.Add(this.label11);
            this.pnlExtraTab.Controls.Add(this.comboArea);
            this.pnlExtraTab.Controls.Add(this.label10);
            this.pnlExtraTab.Controls.Add(this.gbSupBalance);
            this.pnlExtraTab.Controls.Add(this.txtNotes);
            this.pnlExtraTab.Controls.Add(this.label15);
            this.pnlExtraTab.Controls.Add(this.txtDiscount);
            this.pnlExtraTab.Controls.Add(this.label13);
            this.pnlExtraTab.Controls.Add(this.txtCreditLimit);
            this.pnlExtraTab.Controls.Add(this.label14);
            this.pnlExtraTab.Location = new System.Drawing.Point(3, 58);
            this.pnlExtraTab.Name = "pnlExtraTab";
            this.pnlExtraTab.Size = new System.Drawing.Size(740, 339);
            this.pnlExtraTab.TabIndex = 0;
            this.pnlExtraTab.Visible = false;
            // 
            // btnAddSize
            // 
            this.btnAddSize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddSize.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Plus;
            this.btnAddSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSize.ForeColor = System.Drawing.Color.Gray;
            this.btnAddSize.Location = new System.Drawing.Point(598, 117);
            this.btnAddSize.Name = "btnAddSize";
            this.btnAddSize.Size = new System.Drawing.Size(14, 28);
            this.btnAddSize.TabIndex = 122;
            this.toolTipSuppliers.SetToolTip(this.btnAddSize, "إضافة تعامل جديد ");
            this.btnAddSize.UseVisualStyleBackColor = false;
            this.btnAddSize.Click += new System.EventHandler(this.btnAddSize_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddGroup.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Plus;
            this.btnAddGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroup.ForeColor = System.Drawing.Color.Gray;
            this.btnAddGroup.Location = new System.Drawing.Point(598, 83);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(14, 28);
            this.btnAddGroup.TabIndex = 121;
            this.toolTipSuppliers.SetToolTip(this.btnAddGroup, "إضافة تصنيف جديد ");
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddArea
            // 
            this.btnAddArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddArea.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Plus;
            this.btnAddArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddArea.ForeColor = System.Drawing.Color.Gray;
            this.btnAddArea.Location = new System.Drawing.Point(598, 48);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(14, 28);
            this.btnAddArea.TabIndex = 120;
            this.toolTipSuppliers.SetToolTip(this.btnAddArea, "إضافة منطقة جديدة \r\n");
            this.btnAddArea.UseVisualStyleBackColor = false;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // comboSupType
            // 
            this.comboSupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSupType.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboSupType.FormattingEnabled = true;
            this.comboSupType.Items.AddRange(new object[] {
            "مورد نقدى",
            "مورد آجل"});
            this.comboSupType.Location = new System.Drawing.Point(304, 13);
            this.comboSupType.Name = "comboSupType";
            this.comboSupType.Size = new System.Drawing.Size(308, 28);
            this.comboSupType.TabIndex = 0;
            this.comboSupType.SelectedIndexChanged += new System.EventHandler(this.comboSupType_SelectedIndexChanged);
            this.comboSupType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSupType_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(620, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "نوع المورد :";
            // 
            // comboSize
            // 
            this.comboSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSize.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboSize.FormattingEnabled = true;
            this.comboSize.Location = new System.Drawing.Point(304, 117);
            this.comboSize.Name = "comboSize";
            this.comboSize.Size = new System.Drawing.Size(294, 28);
            this.comboSize.TabIndex = 3;
            this.comboSize.DropDown += new System.EventHandler(this.comboSize_DropDown);
            this.comboSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSize_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("LBC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(620, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 20);
            this.label12.TabIndex = 117;
            this.label12.Text = "حجم التعامل :";
            this.toolTipSuppliers.SetToolTip(this.label12, "لإضافة تعامل جديد إضغط على (+) \r\n");
            // 
            // comboGroup
            // 
            this.comboGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboGroup.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboGroup.FormattingEnabled = true;
            this.comboGroup.Location = new System.Drawing.Point(304, 83);
            this.comboGroup.Name = "comboGroup";
            this.comboGroup.Size = new System.Drawing.Size(294, 28);
            this.comboGroup.TabIndex = 2;
            this.comboGroup.DropDown += new System.EventHandler(this.comboGroup_DropDown);
            this.comboGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboGroup_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(620, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 20);
            this.label11.TabIndex = 115;
            this.label11.Text = "تصنيف المورد :";
            this.toolTipSuppliers.SetToolTip(this.label11, "لإضافة مجموعة جديدة إضغط على (+) \r\n");
            // 
            // comboArea
            // 
            this.comboArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboArea.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboArea.FormattingEnabled = true;
            this.comboArea.Location = new System.Drawing.Point(304, 48);
            this.comboArea.Name = "comboArea";
            this.comboArea.Size = new System.Drawing.Size(294, 28);
            this.comboArea.TabIndex = 1;
            this.comboArea.DropDown += new System.EventHandler(this.comboArea_DropDown);
            this.comboArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboArea_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("LBC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(620, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 113;
            this.label10.Text = "المنطقة :";
            this.toolTipSuppliers.SetToolTip(this.label10, "لإضافة منطقة جديدة إضغط على (+) ");
            // 
            // gbSupBalance
            // 
            this.gbSupBalance.Controls.Add(this.label19);
            this.gbSupBalance.Controls.Add(this.comboBalanceStatus);
            this.gbSupBalance.Controls.Add(this.txtBalance);
            this.gbSupBalance.Controls.Add(this.label18);
            this.gbSupBalance.Controls.Add(this.label16);
            this.gbSupBalance.Controls.Add(this.txtDebit);
            this.gbSupBalance.Controls.Add(this.txtCredit);
            this.gbSupBalance.Controls.Add(this.label17);
            this.gbSupBalance.Location = new System.Drawing.Point(3, 9);
            this.gbSupBalance.Name = "gbSupBalance";
            this.gbSupBalance.Size = new System.Drawing.Size(253, 320);
            this.gbSupBalance.TabIndex = 7;
            this.gbSupBalance.TabStop = false;
            this.gbSupBalance.Text = "التعاملات مع المورد";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(88, 242);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 20);
            this.label19.TabIndex = 94;
            this.label19.Text = "حالة الرصيد :";
            // 
            // comboBalanceStatus
            // 
            this.comboBalanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBalanceStatus.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboBalanceStatus.FormattingEnabled = true;
            this.comboBalanceStatus.Items.AddRange(new object[] {
            "لا يوجد رصيد أول المدة",
            "رصيد مدين",
            "رصيد دائن"});
            this.comboBalanceStatus.Location = new System.Drawing.Point(20, 275);
            this.comboBalanceStatus.Name = "comboBalanceStatus";
            this.comboBalanceStatus.Size = new System.Drawing.Size(222, 28);
            this.comboBalanceStatus.TabIndex = 93;
            this.comboBalanceStatus.Validated += new System.EventHandler(this.comboBalanceStatus_Validated);
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBalance.Location = new System.Drawing.Point(20, 205);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(222, 27);
            this.txtBalance.TabIndex = 92;
            this.txtBalance.Text = "0";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipSuppliers.SetToolTip(this.txtBalance, "\r\n\r\n");
            this.txtBalance.Enter += new System.EventHandler(this.txtBalance_Enter);
            this.txtBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBalance_KeyDown);
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(78, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 20);
            this.label18.TabIndex = 87;
            this.label18.Text = "القيمة المدينة :";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(81, 174);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 20);
            this.label16.TabIndex = 91;
            this.label16.Text = "الرصيد الحالى :";
            // 
            // txtDebit
            // 
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDebit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDebit.Location = new System.Drawing.Point(20, 70);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(222, 27);
            this.txtDebit.TabIndex = 88;
            this.txtDebit.Text = "0";
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCredit
            // 
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCredit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCredit.Location = new System.Drawing.Point(20, 136);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(222, 27);
            this.txtCredit.TabIndex = 90;
            this.txtCredit.Text = "0";
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(81, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 20);
            this.label17.TabIndex = 89;
            this.label17.Text = "القيمة الدائنة :";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNotes.Location = new System.Drawing.Point(305, 221);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(306, 92);
            this.txtNotes.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(620, 257);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 20);
            this.label15.TabIndex = 85;
            this.label15.Text = "ملاحظات اخرى :";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Blue;
            this.txtDiscount.Location = new System.Drawing.Point(305, 187);
            this.txtDiscount.MaxLength = 4;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(306, 27);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(620, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 20);
            this.label13.TabIndex = 83;
            this.label13.Text = "نسبة الخصم :";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCreditLimit.ForeColor = System.Drawing.Color.Blue;
            this.txtCreditLimit.Location = new System.Drawing.Point(305, 153);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(306, 27);
            this.txtCreditLimit.TabIndex = 4;
            this.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCreditLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditLimit_KeyDown);
            this.txtCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditLimit_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(620, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 20);
            this.label14.TabIndex = 82;
            this.label14.Text = "حد المسحوبات :";
            // 
            // errProviderSuppliers
            // 
            this.errProviderSuppliers.ContainerControl = this;
            this.errProviderSuppliers.Icon = ((System.Drawing.Icon)(resources.GetObject("errProviderSuppliers.Icon")));
            this.errProviderSuppliers.RightToLeft = true;
            // 
            // timerSuppliers
            // 
            this.timerSuppliers.Enabled = true;
            this.timerSuppliers.Interval = 1200;
            this.timerSuppliers.Tick += new System.EventHandler(this.timerSuppliers_Tick);
            // 
            // FRM_Suppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pnlSuppliers);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Suppliers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الموردين";
            this.Load += new System.EventHandler(this.FRM_Suppliers_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSupStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlSuppliers.ResumeLayout(false);
            this.pnlTabs.ResumeLayout(false);
            this.pnlInfoTab.ResumeLayout(false);
            this.pnlInfoTab.PerformLayout();
            this.pnlExtraTab.ResumeLayout(false);
            this.pnlExtraTab.PerformLayout();
            this.gbSupBalance.ResumeLayout(false);
            this.gbSupBalance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderSuppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        public System.Windows.Forms.PictureBox pbSupStatus;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel pnlSuppliers;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnInfoTab;
        private System.Windows.Forms.Panel pnlInfoTab;
        private System.Windows.Forms.Button btnExtraTab;
        public System.Windows.Forms.TextBox txtResponsible;
        public System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtPhone1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtPhone3;
        public System.Windows.Forms.TextBox txtPhone2;
        public System.Windows.Forms.ErrorProvider errProviderSuppliers;
        public System.Windows.Forms.Timer timerSuppliers;
        public System.Windows.Forms.ToolTip toolTipSuppliers;
        private System.Windows.Forms.Panel pnlExtraTab;
        private System.Windows.Forms.Button btnAddSize;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddArea;
        public System.Windows.Forms.ComboBox comboSupType;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox comboSize;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ComboBox comboGroup;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox comboArea;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox gbSupBalance;
        public System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtDebit;
        public System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.ComboBox comboBalanceStatus;
    }
}