namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Customers
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbCustomerStatus = new System.Windows.Forms.PictureBox();
            this.lblDes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pnlCustomers = new System.Windows.Forms.Panel();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.pnlLeftSide = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBalanceStatus = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCredit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDebit = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnStopWithdrawals = new System.Windows.Forms.RadioButton();
            this.rbtnAvailWithdrawals = new System.Windows.Forms.RadioButton();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboCustomerType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.errProviderCustomers = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipCustomers = new System.Windows.Forms.ToolTip(this.components);
            this.timerCustomers = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.pnlCustomers.SuspendLayout();
            this.pnlLeftSide.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pbCustomerStatus);
            this.pnlTop.Controls.Add(this.lblDes);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pbTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(750, 83);
            this.pnlTop.TabIndex = 0;
            // 
            // pbCustomerStatus
            // 
            this.pbCustomerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCustomerStatus.Image = global::PharmacySystemV20._0._1.Properties.Resources.Disable_Client;
            this.pbCustomerStatus.Location = new System.Drawing.Point(8, 12);
            this.pbCustomerStatus.Name = "pbCustomerStatus";
            this.pbCustomerStatus.Size = new System.Drawing.Size(90, 64);
            this.pbCustomerStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCustomerStatus.TabIndex = 78;
            this.pbCustomerStatus.TabStop = false;
            this.toolTipCustomers.SetToolTip(this.pbCustomerStatus, "عميل غير نشط\r\nيرجى الضغط على الصورة لإعادة تنشيط العميل");
            this.pbCustomerStatus.Click += new System.EventHandler(this.pbCustomerStatus_Click);
            this.pbCustomerStatus.MouseLeave += new System.EventHandler(this.pbCustomerStatus_MouseLeave);
            this.pbCustomerStatus.MouseHover += new System.EventHandler(this.pbCustomerStatus_MouseHover);
            // 
            // lblDes
            // 
            this.lblDes.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDes.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lblDes.Location = new System.Drawing.Point(108, 47);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(479, 24);
            this.lblDes.TabIndex = 66;
            this.lblDes.Text = "من خلال هذة النافذة يتم إضافة عميل جديد";
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
            this.lblTitle.Text = "بيانات العملاء";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.Image = global::PharmacySystemV20._0._1.Properties.Resources.ClientsPic;
            this.pbTitle.Location = new System.Drawing.Point(593, 5);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(154, 71);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTitle.TabIndex = 64;
            this.pbTitle.TabStop = false;
            // 
            // pnlCustomers
            // 
            this.pnlCustomers.Controls.Add(this.txtPhone1);
            this.pnlCustomers.Controls.Add(this.txtPhone2);
            this.pnlCustomers.Controls.Add(this.pnlLeftSide);
            this.pnlCustomers.Controls.Add(this.label11);
            this.pnlCustomers.Controls.Add(this.rbtnStopWithdrawals);
            this.pnlCustomers.Controls.Add(this.rbtnAvailWithdrawals);
            this.pnlCustomers.Controls.Add(this.txtDiscount);
            this.pnlCustomers.Controls.Add(this.label9);
            this.pnlCustomers.Controls.Add(this.txtCreditLimit);
            this.pnlCustomers.Controls.Add(this.label10);
            this.pnlCustomers.Controls.Add(this.comboCustomerType);
            this.pnlCustomers.Controls.Add(this.label8);
            this.pnlCustomers.Controls.Add(this.txtCompany);
            this.pnlCustomers.Controls.Add(this.label7);
            this.pnlCustomers.Controls.Add(this.txtEmail);
            this.pnlCustomers.Controls.Add(this.label6);
            this.pnlCustomers.Controls.Add(this.btnAdd);
            this.pnlCustomers.Controls.Add(this.lblID);
            this.pnlCustomers.Controls.Add(this.txtAddress);
            this.pnlCustomers.Controls.Add(this.label5);
            this.pnlCustomers.Controls.Add(this.txtFax);
            this.pnlCustomers.Controls.Add(this.label4);
            this.pnlCustomers.Controls.Add(this.label3);
            this.pnlCustomers.Controls.Add(this.txtFullName);
            this.pnlCustomers.Controls.Add(this.label2);
            this.pnlCustomers.Controls.Add(this.label1);
            this.pnlCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomers.Location = new System.Drawing.Point(0, 83);
            this.pnlCustomers.Name = "pnlCustomers";
            this.pnlCustomers.Size = new System.Drawing.Size(750, 467);
            this.pnlCustomers.TabIndex = 0;
            // 
            // txtPhone1
            // 
            this.txtPhone1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone1.Location = new System.Drawing.Point(298, 121);
            this.txtPhone1.MaxLength = 11;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(329, 27);
            this.txtPhone1.TabIndex = 2;
            this.txtPhone1.TextChanged += new System.EventHandler(this.txtPhone1_TextChanged);
            this.txtPhone1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone1_KeyDown);
            this.txtPhone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone1_KeyPress);
            this.txtPhone1.Validated += new System.EventHandler(this.txtPhone1_Validated);
            // 
            // txtPhone2
            // 
            this.txtPhone2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPhone2.Location = new System.Drawing.Point(298, 121);
            this.txtPhone2.MaxLength = 11;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(329, 27);
            this.txtPhone2.TabIndex = 84;
            this.txtPhone2.TextChanged += new System.EventHandler(this.txtPhone2_TextChanged);
            this.txtPhone2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone2_KeyDown);
            this.txtPhone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone2_KeyPress);
            this.txtPhone2.Validated += new System.EventHandler(this.txtPhone2_Validated);
            // 
            // pnlLeftSide
            // 
            this.pnlLeftSide.Controls.Add(this.label16);
            this.pnlLeftSide.Controls.Add(this.comboBalanceStatus);
            this.pnlLeftSide.Controls.Add(this.txtNotes);
            this.pnlLeftSide.Controls.Add(this.label15);
            this.pnlLeftSide.Controls.Add(this.txtBalance);
            this.pnlLeftSide.Controls.Add(this.label14);
            this.pnlLeftSide.Controls.Add(this.txtCredit);
            this.pnlLeftSide.Controls.Add(this.label13);
            this.pnlLeftSide.Controls.Add(this.txtDebit);
            this.pnlLeftSide.Controls.Add(this.label12);
            this.pnlLeftSide.Controls.Add(this.splitter1);
            this.pnlLeftSide.Location = new System.Drawing.Point(2, 6);
            this.pnlLeftSide.Name = "pnlLeftSide";
            this.pnlLeftSide.Size = new System.Drawing.Size(249, 393);
            this.pnlLeftSide.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(85, 220);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 20);
            this.label16.TabIndex = 78;
            this.label16.Text = "حالة الرصيد :";
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
            this.comboBalanceStatus.Location = new System.Drawing.Point(17, 247);
            this.comboBalanceStatus.Name = "comboBalanceStatus";
            this.comboBalanceStatus.Size = new System.Drawing.Size(222, 28);
            this.comboBalanceStatus.TabIndex = 77;
            this.comboBalanceStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBalanceStatus_KeyDown);
            this.comboBalanceStatus.Validated += new System.EventHandler(this.comboBalanceStatus_Validated);
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNotes.Location = new System.Drawing.Point(17, 306);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(222, 76);
            this.txtNotes.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 283);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 20);
            this.label15.TabIndex = 76;
            this.label15.Text = "ملاحظات اخرى :";
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBalance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBalance.Location = new System.Drawing.Point(17, 183);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(222, 27);
            this.txtBalance.TabIndex = 75;
            this.txtBalance.Text = "0";
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBalance_KeyDown);
            this.txtBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBalance_KeyPress);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(78, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 20);
            this.label14.TabIndex = 74;
            this.label14.Text = "الرصيد الحالى :";
            // 
            // txtCredit
            // 
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCredit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCredit.Location = new System.Drawing.Point(17, 114);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.ReadOnly = true;
            this.txtCredit.Size = new System.Drawing.Size(222, 27);
            this.txtCredit.TabIndex = 73;
            this.txtCredit.Text = "0";
            this.txtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(78, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 20);
            this.label13.TabIndex = 72;
            this.label13.Text = "القيمة الدائنة :";
            // 
            // txtDebit
            // 
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDebit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDebit.Location = new System.Drawing.Point(17, 48);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.ReadOnly = true;
            this.txtDebit.Size = new System.Drawing.Size(222, 27);
            this.txtDebit.TabIndex = 71;
            this.txtDebit.Text = "0";
            this.txtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(75, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 20);
            this.label12.TabIndex = 67;
            this.label12.Text = "القيمة المدينة :";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(101)))), ((int)(((byte)(132)))));
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(246, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 393);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(635, 366);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 20);
            this.label11.TabIndex = 82;
            this.label11.Text = "السحب بالآجل :";
            // 
            // rbtnStopWithdrawals
            // 
            this.rbtnStopWithdrawals.AutoSize = true;
            this.rbtnStopWithdrawals.Checked = true;
            this.rbtnStopWithdrawals.Location = new System.Drawing.Point(369, 364);
            this.rbtnStopWithdrawals.Name = "rbtnStopWithdrawals";
            this.rbtnStopWithdrawals.Size = new System.Drawing.Size(112, 24);
            this.rbtnStopWithdrawals.TabIndex = 81;
            this.rbtnStopWithdrawals.TabStop = true;
            this.rbtnStopWithdrawals.Text = "إيقاف السحب";
            this.rbtnStopWithdrawals.UseVisualStyleBackColor = true;
            // 
            // rbtnAvailWithdrawals
            // 
            this.rbtnAvailWithdrawals.AutoSize = true;
            this.rbtnAvailWithdrawals.Location = new System.Drawing.Point(516, 364);
            this.rbtnAvailWithdrawals.Name = "rbtnAvailWithdrawals";
            this.rbtnAvailWithdrawals.Size = new System.Drawing.Size(107, 24);
            this.rbtnAvailWithdrawals.TabIndex = 80;
            this.rbtnAvailWithdrawals.Text = "إتاحة السحب";
            this.rbtnAvailWithdrawals.UseVisualStyleBackColor = true;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Blue;
            this.txtDiscount.Location = new System.Drawing.Point(298, 326);
            this.txtDiscount.MaxLength = 4;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(329, 27);
            this.txtDiscount.TabIndex = 8;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDiscount_KeyDown);
            this.txtDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscount_KeyPress);
            this.txtDiscount.Validated += new System.EventHandler(this.txtDiscount_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(635, 329);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 79;
            this.label9.Text = "نسبة الخصم :";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCreditLimit.ForeColor = System.Drawing.Color.Blue;
            this.txtCreditLimit.Location = new System.Drawing.Point(298, 290);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(329, 27);
            this.txtCreditLimit.TabIndex = 7;
            this.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCreditLimit.TextChanged += new System.EventHandler(this.txtCreditLimit_TextChanged);
            this.txtCreditLimit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCreditLimit_KeyDown);
            this.txtCreditLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditLimit_KeyPress);
            this.txtCreditLimit.Validated += new System.EventHandler(this.txtCreditLimit_Validated);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(635, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 77;
            this.label10.Text = "حد المسحوبات :";
            // 
            // comboCustomerType
            // 
            this.comboCustomerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCustomerType.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboCustomerType.FormattingEnabled = true;
            this.comboCustomerType.Items.AddRange(new object[] {
            "عميل نقدى",
            "عميل آجل"});
            this.comboCustomerType.Location = new System.Drawing.Point(298, 256);
            this.comboCustomerType.Name = "comboCustomerType";
            this.comboCustomerType.Size = new System.Drawing.Size(329, 28);
            this.comboCustomerType.TabIndex = 6;
            this.comboCustomerType.SelectedIndexChanged += new System.EventHandler(this.comboCustomerType_SelectedIndexChanged);
            this.comboCustomerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCustomerType_KeyDown);
            this.comboCustomerType.Validated += new System.EventHandler(this.comboCustomerType_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(635, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 75;
            this.label8.Text = "نوع العميل :";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCompany.Location = new System.Drawing.Point(298, 223);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(329, 27);
            this.txtCompany.TabIndex = 5;
            this.txtCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompany_KeyDown);
            this.txtCompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompany_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(635, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 73;
            this.label7.Text = "شركة التابعة :";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtEmail.Location = new System.Drawing.Point(298, 190);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(329, 27);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(635, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 71;
            this.label6.Text = "الايميل :";
            // 
            // btnAdd
            // 
            this.btnAdd.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Select;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(250, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 28);
            this.btnAdd.TabIndex = 69;
            this.toolTipCustomers.SetToolTip(this.btnAdd, "إضافة رقم محمول اخر");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.ForeColor = System.Drawing.Color.Blue;
            this.lblID.Location = new System.Drawing.Point(298, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(329, 27);
            this.lblID.TabIndex = 68;
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAddress.Location = new System.Drawing.Point(298, 88);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(329, 27);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            this.txtAddress.Validated += new System.EventHandler(this.txtAddress_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(635, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 67;
            this.label5.Text = "العنوان :";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFax.Location = new System.Drawing.Point(298, 154);
            this.txtFax.MaxLength = 10;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(329, 27);
            this.txtFax.TabIndex = 3;
            this.txtFax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFax_KeyDown);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFax_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 66;
            this.label4.Text = "الفاكس :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(635, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "رقم المحمول :";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtFullName.Location = new System.Drawing.Point(298, 55);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(329, 27);
            this.txtFullName.TabIndex = 0;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            this.txtFullName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFullName_KeyDown);
            this.txtFullName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFullName_KeyPress);
            this.txtFullName.Validated += new System.EventHandler(this.txtFullName_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(635, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "الاسم بالكامل :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "كود العميل :";
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
            this.pnlControls.TabIndex = 1;
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
            this.toolTipCustomers.SetToolTip(this.btnSearch, "بحث");
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
            this.toolTipCustomers.SetToolTip(this.btnExit, "خروج");
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
            this.toolTipCustomers.SetToolTip(this.btnDelete, "حذف");
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
            this.toolTipCustomers.SetToolTip(this.btnSave, "حفظ");
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
            this.toolTipCustomers.SetToolTip(this.btnModify, "تعديل");
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
            this.toolTipCustomers.SetToolTip(this.btnNew, "إضافة");
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // errProviderCustomers
            // 
            this.errProviderCustomers.ContainerControl = this;
            this.errProviderCustomers.RightToLeft = true;
            // 
            // timerCustomers
            // 
            this.timerCustomers.Enabled = true;
            this.timerCustomers.Interval = 1200;
            this.timerCustomers.Tick += new System.EventHandler(this.timerCustomers_Tick);
            // 
            // FRM_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(750, 550);
            this.ControlBox = false;
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlCustomers);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Customers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة العملاء";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCustomerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.pnlCustomers.ResumeLayout(false);
            this.pnlCustomers.PerformLayout();
            this.pnlLeftSide.ResumeLayout(false);
            this.pnlLeftSide.PerformLayout();
            this.pnlControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errProviderCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCustomers;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbTitle;
        public System.Windows.Forms.Label lblID;
        public System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboCustomerType;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.RadioButton rbtnStopWithdrawals;
        public System.Windows.Forms.RadioButton rbtnAvailWithdrawals;
        private System.Windows.Forms.Panel pnlLeftSide;
        public System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtCredit;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtDebit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Splitter splitter1;
        public System.Windows.Forms.TextBox txtPhone2;
        public System.Windows.Forms.TextBox txtPhone1;
        public System.Windows.Forms.ErrorProvider errProviderCustomers;
        public System.Windows.Forms.PictureBox pbCustomerStatus;
        public System.Windows.Forms.Timer timerCustomers;
        public System.Windows.Forms.ToolTip toolTipCustomers;
        public System.Windows.Forms.ComboBox comboBalanceStatus;
        private System.Windows.Forms.Label label16;
    }
}