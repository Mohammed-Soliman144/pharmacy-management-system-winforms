namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_BranchSearch
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
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radBtnDeactive = new System.Windows.Forms.RadioButton();
            this.radBtnActive = new System.Windows.Forms.RadioButton();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolTipBranchSearch = new System.Windows.Forms.ToolTip(this.components);
            this.btnShow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchCustomCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchPhoneN1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchPhoneN2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchManager = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BranchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.pnlContainer.Size = new System.Drawing.Size(664, 351);
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
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            this.pnlTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(PharmacySystemV20._0._1.Properties.Resources.CancelNew));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(622, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 38);
            this.btnClose.TabIndex = 0;
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
            this.lblTitle.Text = "قائمة الفروع";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.BranchID,
            this.BranchCustomCode,
            this.BranchName,
            this.BranchPhoneN1,
            this.BranchPhoneN2,
            this.BranchFax,
            this.BranchEmail,
            this.BranchAddress,
            this.BranchManager,
            this.BranchStatus,
            this.BranchDate,
            this.BranchTime});
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
            this.dgvSearch.TabIndex = 0;
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
            this.pnlBottom.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.groupBox1.Controls.Add(this.radBtnDeactive);
            this.groupBox1.Controls.Add(this.radBtnActive);
            this.groupBox1.Controls.Add(this.btnPrintAll);
            this.groupBox1.Controls.Add(this.comboSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بحث الفروع";
            // 
            // radBtnDeactive
            // 
            this.radBtnDeactive.AutoSize = true;
            this.radBtnDeactive.ForeColor = System.Drawing.Color.Tomato;
            this.radBtnDeactive.Location = new System.Drawing.Point(110, 35);
            this.radBtnDeactive.Name = "radBtnDeactive";
            this.radBtnDeactive.Size = new System.Drawing.Size(121, 24);
            this.radBtnDeactive.TabIndex = 3;
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
            this.radBtnActive.TabIndex = 2;
            this.radBtnActive.TabStop = true;
            this.radBtnActive.Text = "حالة نشطة";
            this.radBtnActive.UseVisualStyleBackColor = true;
            this.radBtnActive.Visible = false;
            this.radBtnActive.CheckedChanged += new System.EventHandler(this.radBtnActive_CheckedChanged);
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
            this.btnPrintAll.TabIndex = 0;
            this.toolTipBranchSearch.SetToolTip(this.btnPrintAll, "طباعة كل الموردين");
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // comboSearch
            // 
            this.comboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSearch.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Location = new System.Drawing.Point(467, 33);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(182, 28);
            this.comboSearch.TabIndex = 0;
            this.comboSearch.SelectedIndexChanged += new System.EventHandler(this.comboSearch_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(72, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(389, 27);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            // BranchID
            // 
            this.BranchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchID.DataPropertyName = "الكود الداخلى";
            this.BranchID.HeaderText = "الكود الداخلى";
            this.BranchID.Name = "BranchID";
            this.BranchID.ReadOnly = true;
            this.BranchID.Visible = false;
            this.BranchID.Width = 122;
            // 
            // BranchCustomCode
            // 
            this.BranchCustomCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchCustomCode.DataPropertyName = "كود الفرع";
            this.BranchCustomCode.HeaderText = "كود الفرع";
            this.BranchCustomCode.Name = "BranchCustomCode";
            this.BranchCustomCode.ReadOnly = true;
            this.BranchCustomCode.ToolTipText = "كود الفرع";
            this.BranchCustomCode.Width = 96;
            // 
            // BranchName
            // 
            this.BranchName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchName.DataPropertyName = "اسم الفرع";
            this.BranchName.HeaderText = "اسم الفرع";
            this.BranchName.Name = "BranchName";
            this.BranchName.ReadOnly = true;
            this.BranchName.ToolTipText = "اسم الفرع";
            this.BranchName.Width = 97;
            // 
            // BranchPhoneN1
            // 
            this.BranchPhoneN1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchPhoneN1.DataPropertyName = "رقم المحمول الاول";
            this.BranchPhoneN1.HeaderText = "رقم الهاتف";
            this.BranchPhoneN1.Name = "BranchPhoneN1";
            this.BranchPhoneN1.ReadOnly = true;
            this.BranchPhoneN1.ToolTipText = "رقم الهاتف";
            this.BranchPhoneN1.Width = 103;
            // 
            // BranchPhoneN2
            // 
            this.BranchPhoneN2.DataPropertyName = "رقم المحمول الثانى";
            this.BranchPhoneN2.HeaderText = "رقم الهاتف الثانى";
            this.BranchPhoneN2.Name = "BranchPhoneN2";
            this.BranchPhoneN2.ReadOnly = true;
            this.BranchPhoneN2.ToolTipText = "رقم الهاتف الثانى";
            this.BranchPhoneN2.Visible = false;
            // 
            // BranchFax
            // 
            this.BranchFax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchFax.DataPropertyName = "الفاكس";
            this.BranchFax.HeaderText = "الفاكس";
            this.BranchFax.Name = "BranchFax";
            this.BranchFax.ReadOnly = true;
            this.BranchFax.ToolTipText = "الفاكس";
            this.BranchFax.Width = 84;
            // 
            // BranchEmail
            // 
            this.BranchEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchEmail.DataPropertyName = "الايميل";
            this.BranchEmail.HeaderText = "الايميل";
            this.BranchEmail.Name = "BranchEmail";
            this.BranchEmail.ReadOnly = true;
            this.BranchEmail.ToolTipText = "الايميل";
            this.BranchEmail.Visible = false;
            this.BranchEmail.Width = 76;
            // 
            // BranchAddress
            // 
            this.BranchAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchAddress.DataPropertyName = "العنوان";
            this.BranchAddress.HeaderText = "العنوان";
            this.BranchAddress.Name = "BranchAddress";
            this.BranchAddress.ReadOnly = true;
            this.BranchAddress.ToolTipText = "العنوان";
            this.BranchAddress.Width = 79;
            // 
            // BranchManager
            // 
            this.BranchManager.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchManager.DataPropertyName = "مدير الفرع";
            this.BranchManager.HeaderText = "مدير الفرع";
            this.BranchManager.Name = "BranchManager";
            this.BranchManager.ReadOnly = true;
            this.BranchManager.ToolTipText = "مدير الفرع";
            this.BranchManager.Visible = false;
            this.BranchManager.Width = 99;
            // 
            // BranchStatus
            // 
            this.BranchStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchStatus.DataPropertyName = "حالة الفرع";
            this.BranchStatus.HeaderText = "حالة الفرع";
            this.BranchStatus.Name = "BranchStatus";
            this.BranchStatus.ReadOnly = true;
            this.BranchStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BranchStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BranchStatus.ToolTipText = "حالة الفرع";
            this.BranchStatus.Width = 98;
            // 
            // BranchDate
            // 
            this.BranchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.BranchDate.DataPropertyName = "التاريخ";
            this.BranchDate.HeaderText = "تاريخ الاضافة";
            this.BranchDate.Name = "BranchDate";
            this.BranchDate.ReadOnly = true;
            this.BranchDate.Visible = false;
            this.BranchDate.Width = 114;
            // 
            // BranchTime
            // 
            this.BranchTime.DataPropertyName = "الوقت";
            this.BranchTime.HeaderText = "وقت الاضافة";
            this.BranchTime.Name = "BranchTime";
            this.BranchTime.ReadOnly = true;
            this.BranchTime.Visible = false;
            // 
            // FRM_BranchSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(664, 441);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_BranchSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radBtnDeactive;
        private System.Windows.Forms.RadioButton radBtnActive;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.ToolTip toolTipBranchSearch;
        public System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewImageColumn btnShow;
        private System.Windows.Forms.DataGridViewImageColumn btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchCustomCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchPhoneN1;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchPhoneN2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchFax;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchManager;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BranchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BranchTime;
    }
}