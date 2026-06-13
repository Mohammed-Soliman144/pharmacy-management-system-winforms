
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_CompanySearch
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.toolTipStoreSearch = new System.Windows.Forms.ToolTip(this.components);
            this.pnlShow = new System.Windows.Forms.Panel();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.CompanyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCustomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompaniesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyPhoneN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyPhoneN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyPhoneN3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyWebsite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyLogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCommericalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyTaxNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyFinStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyFinEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CompanyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlContainer.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlShow);
            this.pnlContainer.Controls.Add(this.pnlTop);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(664, 441);
            this.pnlContainer.TabIndex = 7;
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
            this.lblTitle.Text = "قائمة الشركات";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlShow
            // 
            this.pnlShow.Controls.Add(this.dgvSearch);
            this.pnlShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShow.Location = new System.Drawing.Point(0, 38);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(664, 403);
            this.pnlShow.TabIndex = 6;
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
            this.dgvSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnShow,
            this.btnPrint,
            this.CompanyID,
            this.CompanyCustomID,
            this.CompaniesName,
            this.CompanyPhoneN1,
            this.CompanyPhoneN2,
            this.CompanyPhoneN3,
            this.CompanyAddress,
            this.CompanyManager,
            this.CompanyFax,
            this.CompanyEmail,
            this.CompanyWebsite,
            this.CompanyLogo,
            this.CompanyType,
            this.CompanyCategory,
            this.CompanyCommericalNo,
            this.CompanyTaxNo,
            this.CompanyCity,
            this.CompanyCountry,
            this.CompanyFinStartDate,
            this.CompanyFinEndDate,
            this.CompanyStatus,
            this.CompanyDate,
            this.CompanyTime});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.Location = new System.Drawing.Point(0, 0);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(664, 403);
            this.dgvSearch.TabIndex = 2;
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
            this.btnShow.ToolTipText = "عرض المخزن";
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
            this.btnPrint.ToolTipText = "طباعة المخزن";
            this.btnPrint.Width = 55;
            // 
            // CompanyID
            // 
            this.CompanyID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyID.DataPropertyName = "الكود الداخلى";
            this.CompanyID.HeaderText = "الكود الداخلى";
            this.CompanyID.Name = "CompanyID";
            this.CompanyID.ReadOnly = true;
            this.CompanyID.Visible = false;
            // 
            // CompanyCustomID
            // 
            this.CompanyCustomID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyCustomID.DataPropertyName = "كود الشركة";
            this.CompanyCustomID.HeaderText = "كود الشركة";
            this.CompanyCustomID.Name = "CompanyCustomID";
            this.CompanyCustomID.ReadOnly = true;
            this.CompanyCustomID.Width = 109;
            // 
            // CompaniesName
            // 
            this.CompaniesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompaniesName.DataPropertyName = "اسم الشركة";
            this.CompaniesName.HeaderText = "اسم الشركة";
            this.CompaniesName.Name = "CompaniesName";
            this.CompaniesName.ReadOnly = true;
            this.CompaniesName.Width = 110;
            // 
            // CompanyPhoneN1
            // 
            this.CompanyPhoneN1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyPhoneN1.DataPropertyName = "رقم المحمول الاول";
            this.CompanyPhoneN1.HeaderText = "رقم الهاتف";
            this.CompanyPhoneN1.Name = "CompanyPhoneN1";
            this.CompanyPhoneN1.ReadOnly = true;
            this.CompanyPhoneN1.Width = 103;
            // 
            // CompanyPhoneN2
            // 
            this.CompanyPhoneN2.DataPropertyName = "رقم المحمول الثانى";
            this.CompanyPhoneN2.HeaderText = "رقم المحمول الثانى";
            this.CompanyPhoneN2.Name = "CompanyPhoneN2";
            this.CompanyPhoneN2.ReadOnly = true;
            this.CompanyPhoneN2.Visible = false;
            // 
            // CompanyPhoneN3
            // 
            this.CompanyPhoneN3.DataPropertyName = "رقم المحمول الثالث";
            this.CompanyPhoneN3.HeaderText = "رقم المحمول الثالث";
            this.CompanyPhoneN3.Name = "CompanyPhoneN3";
            this.CompanyPhoneN3.ReadOnly = true;
            this.CompanyPhoneN3.Visible = false;
            // 
            // CompanyAddress
            // 
            this.CompanyAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyAddress.DataPropertyName = "العنوان";
            this.CompanyAddress.HeaderText = "العنوان";
            this.CompanyAddress.Name = "CompanyAddress";
            this.CompanyAddress.ReadOnly = true;
            this.CompanyAddress.Width = 79;
            // 
            // CompanyManager
            // 
            this.CompanyManager.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyManager.DataPropertyName = "مدير الشركة";
            this.CompanyManager.HeaderText = "مدير الشركة";
            this.CompanyManager.Name = "CompanyManager";
            this.CompanyManager.ReadOnly = true;
            this.CompanyManager.Visible = false;
            // 
            // CompanyFax
            // 
            this.CompanyFax.DataPropertyName = "الفاكس";
            this.CompanyFax.HeaderText = "الفاكس";
            this.CompanyFax.Name = "CompanyFax";
            this.CompanyFax.ReadOnly = true;
            // 
            // CompanyEmail
            // 
            this.CompanyEmail.DataPropertyName = "الايميل";
            this.CompanyEmail.HeaderText = "الايميل";
            this.CompanyEmail.Name = "CompanyEmail";
            this.CompanyEmail.ReadOnly = true;
            // 
            // CompanyWebsite
            // 
            this.CompanyWebsite.DataPropertyName = "موقع الشركة";
            this.CompanyWebsite.HeaderText = "موقع الشركة";
            this.CompanyWebsite.Name = "CompanyWebsite";
            this.CompanyWebsite.ReadOnly = true;
            // 
            // CompanyLogo
            // 
            this.CompanyLogo.DataPropertyName = "شعار الشركة";
            this.CompanyLogo.HeaderText = "شعار الشركة";
            this.CompanyLogo.Name = "CompanyLogo";
            this.CompanyLogo.ReadOnly = true;
            this.CompanyLogo.Visible = false;
            // 
            // CompanyType
            // 
            this.CompanyType.DataPropertyName = "نوع الشركة";
            this.CompanyType.HeaderText = "نوع الشركة";
            this.CompanyType.Name = "CompanyType";
            this.CompanyType.ReadOnly = true;
            // 
            // CompanyCategory
            // 
            this.CompanyCategory.DataPropertyName = "نشاط الشركة";
            this.CompanyCategory.HeaderText = "نشاط الشركة";
            this.CompanyCategory.Name = "CompanyCategory";
            this.CompanyCategory.ReadOnly = true;
            this.CompanyCategory.Visible = false;
            // 
            // CompanyCommericalNo
            // 
            this.CompanyCommericalNo.DataPropertyName = "رقم السجل التجارى";
            this.CompanyCommericalNo.HeaderText = "السجل التجارى";
            this.CompanyCommericalNo.Name = "CompanyCommericalNo";
            this.CompanyCommericalNo.ReadOnly = true;
            this.CompanyCommericalNo.Visible = false;
            // 
            // CompanyTaxNo
            // 
            this.CompanyTaxNo.DataPropertyName = "رقم البطاقة الضريبية";
            this.CompanyTaxNo.HeaderText = "البطاقة الضريبية";
            this.CompanyTaxNo.Name = "CompanyTaxNo";
            this.CompanyTaxNo.ReadOnly = true;
            this.CompanyTaxNo.Visible = false;
            // 
            // CompanyCity
            // 
            this.CompanyCity.DataPropertyName = "المدينة";
            this.CompanyCity.HeaderText = "المدينة";
            this.CompanyCity.Name = "CompanyCity";
            this.CompanyCity.ReadOnly = true;
            this.CompanyCity.Visible = false;
            // 
            // CompanyCountry
            // 
            this.CompanyCountry.DataPropertyName = "الدولة";
            this.CompanyCountry.HeaderText = "الدولة";
            this.CompanyCountry.Name = "CompanyCountry";
            this.CompanyCountry.ReadOnly = true;
            // 
            // CompanyFinStartDate
            // 
            this.CompanyFinStartDate.DataPropertyName = "بداية السنة المالية";
            this.CompanyFinStartDate.HeaderText = "بداية السنة المالية";
            this.CompanyFinStartDate.Name = "CompanyFinStartDate";
            this.CompanyFinStartDate.ReadOnly = true;
            this.CompanyFinStartDate.Visible = false;
            // 
            // CompanyFinEndDate
            // 
            this.CompanyFinEndDate.DataPropertyName = "نهاية السنة المالية";
            this.CompanyFinEndDate.HeaderText = "نهاية السنة المالية";
            this.CompanyFinEndDate.Name = "CompanyFinEndDate";
            this.CompanyFinEndDate.ReadOnly = true;
            this.CompanyFinEndDate.Visible = false;
            // 
            // CompanyStatus
            // 
            this.CompanyStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyStatus.DataPropertyName = "حالة الشركة";
            this.CompanyStatus.HeaderText = "حالة الشركة";
            this.CompanyStatus.Name = "CompanyStatus";
            this.CompanyStatus.ReadOnly = true;
            this.CompanyStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CompanyStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CompanyStatus.Width = 111;
            // 
            // CompanyDate
            // 
            this.CompanyDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CompanyDate.DataPropertyName = "التاريخ";
            this.CompanyDate.HeaderText = "تاريخ الاضافة";
            this.CompanyDate.Name = "CompanyDate";
            this.CompanyDate.ReadOnly = true;
            this.CompanyDate.Visible = false;
            // 
            // CompanyTime
            // 
            this.CompanyTime.DataPropertyName = "الوقت";
            this.CompanyTime.HeaderText = "وقت الاضافة";
            this.CompanyTime.Name = "CompanyTime";
            this.CompanyTime.ReadOnly = true;
            this.CompanyTime.Visible = false;
            // 
            // FRM_CompanySearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(664, 441);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_CompanySearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlContainer.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolTip toolTipStoreSearch;
        private System.Windows.Forms.Panel pnlShow;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.DataGridViewImageColumn btnShow;
        private System.Windows.Forms.DataGridViewImageColumn btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCustomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompaniesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyPhoneN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyPhoneN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyPhoneN3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyWebsite;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyLogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCommericalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyTaxNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyFinStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyFinEndDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CompanyStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyTime;
    }
}