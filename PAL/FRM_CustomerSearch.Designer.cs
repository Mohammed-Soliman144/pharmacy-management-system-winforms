namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_CustomerSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.toolTipCustomerSearch = new System.Windows.Forms.ToolTip(this.components);
            this.radBtnActive = new System.Windows.Forms.RadioButton();
            this.radBtnDeactive = new System.Windows.Forms.RadioButton();
            this.btnShow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerDebitStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CustomerNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlContainer.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlTop);
            this.pnlContainer.Controls.Add(this.dgvSearch);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(664, 441);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(664, 38);
            this.pnlTop.TabIndex = 5;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.CancelNew;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(622, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(259, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "قائمة العملاء";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnShow,
            this.btnPrint,
            this.CustomerID,
            this.CustomerCode,
            this.CustomerFullName,
            this.CustomerPhone1,
            this.CustomerPhone2,
            this.CustomerFax,
            this.CustomerAddress,
            this.CustomerEmail,
            this.CustomerType,
            this.CustomerCompany,
            this.CustomerCreditLimit,
            this.CustomerDiscount,
            this.CustomerDebit,
            this.CustomerCredit,
            this.CustomerBalance,
            this.CustomerDebitStatus,
            this.CustomerNotes,
            this.CustomerStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.Location = new System.Drawing.Point(3, 44);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(658, 301);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellContentClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.groupBox1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.pnlBottom.Location = new System.Drawing.Point(0, 351);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(664, 90);
            this.pnlBottom.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radBtnDeactive);
            this.groupBox1.Controls.Add(this.radBtnActive);
            this.groupBox1.Controls.Add(this.btnPrintAll);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.comboSearch);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 84);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بحث العملاء";
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnPrintAll.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Printer;
            this.btnPrintAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintAll.FlatAppearance.BorderSize = 0;
            this.btnPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAll.Location = new System.Drawing.Point(6, 26);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(60, 43);
            this.btnPrintAll.TabIndex = 77;
            this.toolTipCustomerSearch.SetToolTip(this.btnPrintAll, "طباعة كل العملاء");
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(72, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(389, 27);
            this.txtSearch.TabIndex = 76;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(467, 33);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(182, 28);
            this.comboSearch.TabIndex = 75;
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.comboSearch_SelectedIndexChanged);
            // 
            // radBtnActive
            // 
            this.radBtnActive.AutoSize = true;
            this.radBtnActive.ForeColor = System.Drawing.Color.Tomato;
            this.radBtnActive.Location = new System.Drawing.Point(300, 35);
            this.radBtnActive.Name = "radBtnActive";
            this.radBtnActive.Size = new System.Drawing.Size(98, 24);
            this.radBtnActive.TabIndex = 79;
            this.radBtnActive.TabStop = true;
            this.radBtnActive.Text = "حالة نشطة";
            this.radBtnActive.UseVisualStyleBackColor = true;
            this.radBtnActive.Visible = false;
            this.radBtnActive.CheckedChanged += new System.EventHandler(this.radBtnActive_CheckedChanged);
            // 
            // radBtnDeactive
            // 
            this.radBtnDeactive.AutoSize = true;
            this.radBtnDeactive.ForeColor = System.Drawing.Color.Tomato;
            this.radBtnDeactive.Location = new System.Drawing.Point(110, 35);
            this.radBtnDeactive.Name = "radBtnDeactive";
            this.radBtnDeactive.Size = new System.Drawing.Size(121, 24);
            this.radBtnDeactive.TabIndex = 80;
            this.radBtnDeactive.TabStop = true;
            this.radBtnDeactive.Text = "حالة غير نشطة";
            this.radBtnDeactive.UseVisualStyleBackColor = true;
            this.radBtnDeactive.Visible = false;
            this.radBtnDeactive.CheckedChanged += new System.EventHandler(this.radBtnDeactive_CheckedChanged);
            // 
            // btnShow
            // 
            this.btnShow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnShow.HeaderText = "عرض";
            this.btnShow.Image = global::PharmacySystemV20._0._1.Properties.Resources.Display;
            this.btnShow.Name = "btnShow";
            this.btnShow.ReadOnly = true;
            this.btnShow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnShow.ToolTipText = "عرض المستخدم";
            this.btnShow.Width = 45;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnPrint.HeaderText = "طباعة";
            this.btnPrint.Image = global::PharmacySystemV20._0._1.Properties.Resources.Printer;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ReadOnly = true;
            this.btnPrint.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnPrint.ToolTipText = "طباعة المستخدم";
            this.btnPrint.Width = 55;
            // 
            // CustomerID
            // 
            this.CustomerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerID.DataPropertyName = "الكود الداخلى";
            this.CustomerID.HeaderText = "الكود الداخلى";
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.ReadOnly = true;
            this.CustomerID.Visible = false;
            this.CustomerID.Width = 122;
            // 
            // CustomerCode
            // 
            this.CustomerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerCode.DataPropertyName = "كود العميل";
            this.CustomerCode.HeaderText = "كود العميل";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.ReadOnly = true;
            this.CustomerCode.Width = 105;
            // 
            // CustomerFullName
            // 
            this.CustomerFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerFullName.DataPropertyName = "اسم العميل";
            this.CustomerFullName.HeaderText = "اسم العميل";
            this.CustomerFullName.Name = "CustomerFullName";
            this.CustomerFullName.ReadOnly = true;
            this.CustomerFullName.Width = 106;
            // 
            // CustomerPhone1
            // 
            this.CustomerPhone1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerPhone1.DataPropertyName = "رقم الهاتف الاول";
            this.CustomerPhone1.HeaderText = "رقم الهاتف الاول";
            this.CustomerPhone1.Name = "CustomerPhone1";
            this.CustomerPhone1.ReadOnly = true;
            this.CustomerPhone1.Width = 136;
            // 
            // CustomerPhone2
            // 
            this.CustomerPhone2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerPhone2.DataPropertyName = "رقم الهاتف الثانى";
            this.CustomerPhone2.HeaderText = "رقم الهاتف الثانى";
            this.CustomerPhone2.Name = "CustomerPhone2";
            this.CustomerPhone2.ReadOnly = true;
            this.CustomerPhone2.Width = 144;
            // 
            // CustomerFax
            // 
            this.CustomerFax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerFax.DataPropertyName = "رقم الفاكس";
            this.CustomerFax.HeaderText = "رقم الفاكس";
            this.CustomerFax.Name = "CustomerFax";
            this.CustomerFax.ReadOnly = true;
            this.CustomerFax.Width = 110;
            // 
            // CustomerAddress
            // 
            this.CustomerAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerAddress.DataPropertyName = "العنوان";
            this.CustomerAddress.HeaderText = "العنوان";
            this.CustomerAddress.Name = "CustomerAddress";
            this.CustomerAddress.ReadOnly = true;
            this.CustomerAddress.Width = 79;
            // 
            // CustomerEmail
            // 
            this.CustomerEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerEmail.DataPropertyName = "البريد اليكترونى";
            this.CustomerEmail.HeaderText = "البريد اليكترونى";
            this.CustomerEmail.Name = "CustomerEmail";
            this.CustomerEmail.ReadOnly = true;
            this.CustomerEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerEmail.Width = 132;
            // 
            // CustomerType
            // 
            this.CustomerType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerType.DataPropertyName = "نوع العميل";
            this.CustomerType.HeaderText = "نوع العميل";
            this.CustomerType.Name = "CustomerType";
            this.CustomerType.ReadOnly = true;
            this.CustomerType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerType.Width = 103;
            // 
            // CustomerCompany
            // 
            this.CustomerCompany.DataPropertyName = "الشركة التابع لها";
            this.CustomerCompany.HeaderText = "الشركة التابع لها";
            this.CustomerCompany.Name = "CustomerCompany";
            this.CustomerCompany.ReadOnly = true;
            // 
            // CustomerCreditLimit
            // 
            this.CustomerCreditLimit.DataPropertyName = "حد المسحوبات";
            this.CustomerCreditLimit.HeaderText = "حد المسحوبات";
            this.CustomerCreditLimit.Name = "CustomerCreditLimit";
            this.CustomerCreditLimit.ReadOnly = true;
            // 
            // CustomerDiscount
            // 
            this.CustomerDiscount.DataPropertyName = "نسبة الخصم";
            this.CustomerDiscount.HeaderText = "نسبة الخصم";
            this.CustomerDiscount.Name = "CustomerDiscount";
            this.CustomerDiscount.ReadOnly = true;
            this.CustomerDiscount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDiscount.Visible = false;
            // 
            // CustomerDebit
            // 
            this.CustomerDebit.DataPropertyName = "القيمة المدينة";
            this.CustomerDebit.HeaderText = "القيمة المدينة";
            this.CustomerDebit.Name = "CustomerDebit";
            this.CustomerDebit.ReadOnly = true;
            this.CustomerDebit.Visible = false;
            // 
            // CustomerCredit
            // 
            this.CustomerCredit.DataPropertyName = "القيمة الدائنة";
            this.CustomerCredit.HeaderText = "القيمة الدائنة";
            this.CustomerCredit.Name = "CustomerCredit";
            this.CustomerCredit.ReadOnly = true;
            this.CustomerCredit.Visible = false;
            // 
            // CustomerBalance
            // 
            this.CustomerBalance.DataPropertyName = "رصيد العميل";
            this.CustomerBalance.HeaderText = "رصيد العميل";
            this.CustomerBalance.Name = "CustomerBalance";
            this.CustomerBalance.ReadOnly = true;
            // 
            // CustomerDebitStatus
            // 
            this.CustomerDebitStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerDebitStatus.DataPropertyName = "حالة المبيعات الآجلة";
            this.CustomerDebitStatus.HeaderText = "حالة المبيعات الآجلة";
            this.CustomerDebitStatus.Name = "CustomerDebitStatus";
            this.CustomerDebitStatus.ReadOnly = true;
            this.CustomerDebitStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerDebitStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CustomerDebitStatus.Width = 144;
            // 
            // CustomerNotes
            // 
            this.CustomerNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerNotes.DataPropertyName = "ملاحظات";
            this.CustomerNotes.HeaderText = "ملاحظات";
            this.CustomerNotes.Name = "CustomerNotes";
            this.CustomerNotes.ReadOnly = true;
            this.CustomerNotes.Width = 91;
            // 
            // CustomerStatus
            // 
            this.CustomerStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CustomerStatus.DataPropertyName = "حالة العميل";
            this.CustomerStatus.HeaderText = "حالة العميل";
            this.CustomerStatus.Name = "CustomerStatus";
            this.CustomerStatus.ReadOnly = true;
            this.CustomerStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CustomerStatus.Width = 98;
            // 
            // FRM_CustomerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(664, 441);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_CustomerSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContainer.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.ToolTip toolTipCustomerSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radBtnDeactive;
        private System.Windows.Forms.RadioButton radBtnActive;
        private System.Windows.Forms.DataGridViewImageColumn btnShow;
        private System.Windows.Forms.DataGridViewImageColumn btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCreditLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerBalance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CustomerDebitStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerNotes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CustomerStatus;
    }
}