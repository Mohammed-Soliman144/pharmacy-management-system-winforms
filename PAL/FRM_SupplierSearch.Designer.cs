namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_SupplierSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolTipSupSearch = new System.Windows.Forms.ToolTip(this.components);
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.radBtnDeactive = new System.Windows.Forms.RadioButton();
            this.radBtnActive = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierResponsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPhone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPhone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPhone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierCreditLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
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
            this.toolTipSupSearch.SetToolTip(this.btnPrintAll, "طباعة كل الموردين");
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(72, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(389, 27);
            this.txtSearch.TabIndex = 76;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.radBtnDeactive);
            this.groupBox1.Controls.Add(this.radBtnActive);
            this.groupBox1.Controls.Add(this.btnPrintAll);
            this.groupBox1.Controls.Add(this.comboSearch);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 84);
            this.groupBox1.TabIndex = 76;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بحث الموردين";
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
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.groupBox1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.pnlBottom.Location = new System.Drawing.Point(0, 351);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(664, 90);
            this.pnlBottom.TabIndex = 4;
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
            this.lblTitle.Text = "قائمة الموردين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlTop);
            this.pnlContainer.Controls.Add(this.dgvSearch);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(664, 441);
            this.pnlContainer.TabIndex = 3;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnShow,
            this.btnPrint,
            this.SupplierID,
            this.SupplierCode,
            this.SupplierFullName,
            this.SupplierCompany,
            this.SupplierResponsible,
            this.SupplierPhone1,
            this.SupplierPhone2,
            this.SupplierPhone3,
            this.SupplierFax,
            this.SupplierAddress,
            this.SupplierArea,
            this.SupplierEmail,
            this.SupplierType,
            this.SupplierGroup,
            this.SupplierSize,
            this.SupplierCreditLimit,
            this.SupplierDiscount,
            this.SupplierBalance,
            this.SupplierNotes,
            this.SupplierStatus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.Location = new System.Drawing.Point(3, 44);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(658, 301);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellContentClick);
            // 
            // btnShow
            // 
            this.btnShow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.btnShow.HeaderText = "عرض";
            this.btnShow.Image = global::PharmacySystemV20._0._1.Properties.Resources.Display;
            this.btnShow.Name = "btnShow";
            this.btnShow.ReadOnly = true;
            this.btnShow.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnShow.ToolTipText = "عرض المورد";
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
            this.btnPrint.ToolTipText = "طباعة المورد";
            this.btnPrint.Width = 55;
            // 
            // SupplierID
            // 
            this.SupplierID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierID.DataPropertyName = "الكود الداخلى";
            this.SupplierID.HeaderText = "الكود الداخلى";
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.ReadOnly = true;
            this.SupplierID.Visible = false;
            this.SupplierID.Width = 122;
            // 
            // SupplierCode
            // 
            this.SupplierCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierCode.DataPropertyName = "الكود المورد";
            this.SupplierCode.HeaderText = "كود المورد";
            this.SupplierCode.Name = "SupplierCode";
            this.SupplierCode.ReadOnly = true;
            this.SupplierCode.Width = 102;
            // 
            // SupplierFullName
            // 
            this.SupplierFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierFullName.DataPropertyName = "اسم المورد";
            this.SupplierFullName.HeaderText = "اسم المورد";
            this.SupplierFullName.Name = "SupplierFullName";
            this.SupplierFullName.ReadOnly = true;
            this.SupplierFullName.Width = 103;
            // 
            // SupplierCompany
            // 
            this.SupplierCompany.DataPropertyName = "اسم الشركة";
            this.SupplierCompany.HeaderText = "اسم الشركة";
            this.SupplierCompany.Name = "SupplierCompany";
            this.SupplierCompany.ReadOnly = true;
            // 
            // SupplierResponsible
            // 
            this.SupplierResponsible.DataPropertyName = "اسم المسئول";
            this.SupplierResponsible.HeaderText = "اسم المسئول";
            this.SupplierResponsible.Name = "SupplierResponsible";
            this.SupplierResponsible.ReadOnly = true;
            // 
            // SupplierPhone1
            // 
            this.SupplierPhone1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierPhone1.DataPropertyName = "رقم الهاتف الاول";
            this.SupplierPhone1.HeaderText = "رقم الهاتف الاول";
            this.SupplierPhone1.Name = "SupplierPhone1";
            this.SupplierPhone1.ReadOnly = true;
            this.SupplierPhone1.Width = 124;
            // 
            // SupplierPhone2
            // 
            this.SupplierPhone2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierPhone2.DataPropertyName = "رقم الهاتف الثانى";
            this.SupplierPhone2.HeaderText = "رقم الهاتف الثانى";
            this.SupplierPhone2.Name = "SupplierPhone2";
            this.SupplierPhone2.ReadOnly = true;
            this.SupplierPhone2.Width = 132;
            // 
            // SupplierPhone3
            // 
            this.SupplierPhone3.DataPropertyName = "رقم الهاتف الثالث";
            this.SupplierPhone3.HeaderText = "رقم الهاتف الثالث";
            this.SupplierPhone3.Name = "SupplierPhone3";
            this.SupplierPhone3.ReadOnly = true;
            // 
            // SupplierFax
            // 
            this.SupplierFax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierFax.DataPropertyName = "رقم الفاكس";
            this.SupplierFax.HeaderText = "رقم الفاكس";
            this.SupplierFax.Name = "SupplierFax";
            this.SupplierFax.ReadOnly = true;
            this.SupplierFax.Width = 101;
            // 
            // SupplierAddress
            // 
            this.SupplierAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierAddress.DataPropertyName = "العنوان";
            this.SupplierAddress.HeaderText = "العنوان";
            this.SupplierAddress.Name = "SupplierAddress";
            this.SupplierAddress.ReadOnly = true;
            this.SupplierAddress.Width = 79;
            // 
            // SupplierArea
            // 
            this.SupplierArea.DataPropertyName = "منطقة المورد";
            this.SupplierArea.HeaderText = "منطقة المورد";
            this.SupplierArea.Name = "SupplierArea";
            this.SupplierArea.ReadOnly = true;
            // 
            // SupplierEmail
            // 
            this.SupplierEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierEmail.DataPropertyName = "البريد اليكترونى";
            this.SupplierEmail.HeaderText = "البريد اليكترونى";
            this.SupplierEmail.Name = "SupplierEmail";
            this.SupplierEmail.ReadOnly = true;
            this.SupplierEmail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierEmail.Width = 121;
            // 
            // SupplierType
            // 
            this.SupplierType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierType.DataPropertyName = "نوع المورد";
            this.SupplierType.HeaderText = "نوع المورد";
            this.SupplierType.Name = "SupplierType";
            this.SupplierType.ReadOnly = true;
            this.SupplierType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierType.Width = 92;
            // 
            // SupplierGroup
            // 
            this.SupplierGroup.DataPropertyName = "تصنيف المورد";
            this.SupplierGroup.HeaderText = "تصنيف المورد";
            this.SupplierGroup.Name = "SupplierGroup";
            this.SupplierGroup.ReadOnly = true;
            // 
            // SupplierSize
            // 
            this.SupplierSize.DataPropertyName = "حجم التعامل";
            this.SupplierSize.HeaderText = "حجم التعامل";
            this.SupplierSize.Name = "SupplierSize";
            this.SupplierSize.ReadOnly = true;
            // 
            // SupplierCreditLimit
            // 
            this.SupplierCreditLimit.DataPropertyName = "اقصى حد للمسحوبات";
            this.SupplierCreditLimit.HeaderText = "اقصى حد للمسحوبات";
            this.SupplierCreditLimit.Name = "SupplierCreditLimit";
            this.SupplierCreditLimit.ReadOnly = true;
            // 
            // SupplierDiscount
            // 
            this.SupplierDiscount.DataPropertyName = "الخصم الثابت على الاجمالى";
            this.SupplierDiscount.HeaderText = "الخصم الثابت على الاجمالى";
            this.SupplierDiscount.Name = "SupplierDiscount";
            this.SupplierDiscount.ReadOnly = true;
            this.SupplierDiscount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierDiscount.Visible = false;
            // 
            // SupplierBalance
            // 
            this.SupplierBalance.DataPropertyName = "رصيد المورد";
            this.SupplierBalance.HeaderText = "رصيد المورد";
            this.SupplierBalance.Name = "SupplierBalance";
            this.SupplierBalance.ReadOnly = true;
            // 
            // SupplierNotes
            // 
            this.SupplierNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierNotes.DataPropertyName = "ملاحظات";
            this.SupplierNotes.HeaderText = "ملاحظات";
            this.SupplierNotes.Name = "SupplierNotes";
            this.SupplierNotes.ReadOnly = true;
            this.SupplierNotes.Width = 91;
            // 
            // SupplierStatus
            // 
            this.SupplierStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierStatus.DataPropertyName = "حالة المورد";
            this.SupplierStatus.HeaderText = "حالة المورد";
            this.SupplierStatus.Name = "SupplierStatus";
            this.SupplierStatus.ReadOnly = true;
            this.SupplierStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupplierStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SupplierStatus.Width = 96;
            // 
            // FRM_SupplierSearch
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
            this.Name = "FRM_SupplierSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTipSupSearch;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.RadioButton radBtnDeactive;
        private System.Windows.Forms.RadioButton radBtnActive;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.DataGridViewImageColumn btnShow;
        private System.Windows.Forms.DataGridViewImageColumn btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierResponsible;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPhone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPhone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPhone3;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierCreditLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierNotes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupplierStatus;
    }
}