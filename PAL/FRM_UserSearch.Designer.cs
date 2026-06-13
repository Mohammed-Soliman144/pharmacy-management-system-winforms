namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_UserSearch
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbContainer = new System.Windows.Forms.GroupBox();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.UserCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserNatID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserJob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserForPro = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnPrintAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolTipUserSearch = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTop.SuspendLayout();
            this.gbContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlTop.Size = new System.Drawing.Size(584, 38);
            this.pnlTop.TabIndex = 4;
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
            this.btnClose.Location = new System.Drawing.Point(542, 0);
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
            this.lblTitle.Location = new System.Drawing.Point(219, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "قائمة المستخدمين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbContainer
            // 
            this.gbContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContainer.Controls.Add(this.dgvSearch);
            this.gbContainer.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbContainer.Location = new System.Drawing.Point(6, 44);
            this.gbContainer.Name = "gbContainer";
            this.gbContainer.Size = new System.Drawing.Size(572, 283);
            this.gbContainer.TabIndex = 5;
            this.gbContainer.TabStop = false;
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
            this.UserCode,
            this.UserFullName,
            this.UserGender,
            this.UserNatID,
            this.UserPhone,
            this.UserJob,
            this.UserAddress,
            this.UserForPro,
            this.UserStatus,
            this.UserName,
            this.UserPassword,
            this.UserImage});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvSearch.Location = new System.Drawing.Point(3, 25);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(566, 255);
            this.dgvSearch.TabIndex = 0;
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
            this.btnShow.ToolTipText = "عرض المستخدم";
            this.btnShow.Width = 50;
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
            this.btnPrint.Width = 60;
            // 
            // UserCode
            // 
            this.UserCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserCode.DataPropertyName = "كود المستخدم";
            this.UserCode.HeaderText = "كود المستخدم";
            this.UserCode.Name = "UserCode";
            this.UserCode.ReadOnly = true;
            this.UserCode.Width = 141;
            // 
            // UserFullName
            // 
            this.UserFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserFullName.DataPropertyName = "الاسم بالكامل";
            this.UserFullName.HeaderText = "الاسم بالكامل";
            this.UserFullName.Name = "UserFullName";
            this.UserFullName.ReadOnly = true;
            this.UserFullName.Width = 130;
            // 
            // UserGender
            // 
            this.UserGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserGender.DataPropertyName = "النوع";
            this.UserGender.HeaderText = "النوع";
            this.UserGender.Name = "UserGender";
            this.UserGender.ReadOnly = true;
            this.UserGender.Width = 72;
            // 
            // UserNatID
            // 
            this.UserNatID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserNatID.DataPropertyName = "الرقم القومى";
            this.UserNatID.HeaderText = "الرقم القومى";
            this.UserNatID.Name = "UserNatID";
            this.UserNatID.ReadOnly = true;
            this.UserNatID.Width = 132;
            // 
            // UserPhone
            // 
            this.UserPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserPhone.DataPropertyName = "رقم الهاتف";
            this.UserPhone.HeaderText = "رقم المحمول";
            this.UserPhone.Name = "UserPhone";
            this.UserPhone.ReadOnly = true;
            this.UserPhone.Width = 127;
            // 
            // UserJob
            // 
            this.UserJob.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserJob.DataPropertyName = "الوظيفة";
            this.UserJob.HeaderText = "الوظيفة";
            this.UserJob.Name = "UserJob";
            this.UserJob.ReadOnly = true;
            this.UserJob.Width = 94;
            // 
            // UserAddress
            // 
            this.UserAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserAddress.DataPropertyName = "العنوان";
            this.UserAddress.HeaderText = "العنوان";
            this.UserAddress.Name = "UserAddress";
            this.UserAddress.ReadOnly = true;
            this.UserAddress.Width = 84;
            // 
            // UserForPro
            // 
            this.UserForPro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserForPro.DataPropertyName = "نوع المستخدم";
            this.UserForPro.FalseValue = "غير مستخدم";
            this.UserForPro.HeaderText = "قابلية الاستخدام";
            this.UserForPro.Name = "UserForPro";
            this.UserForPro.ReadOnly = true;
            this.UserForPro.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserForPro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UserForPro.TrueValue = "مستخدم";
            this.UserForPro.Width = 152;
            // 
            // UserStatus
            // 
            this.UserStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UserStatus.DataPropertyName = "حالة المستخدم";
            this.UserStatus.FalseValue = "غير مفعل";
            this.UserStatus.HeaderText = "حالة المستخدم";
            this.UserStatus.Name = "UserStatus";
            this.UserStatus.ReadOnly = true;
            this.UserStatus.TrueValue = "مفعل";
            this.UserStatus.Width = 123;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "اسم المستخدم";
            this.UserName.HeaderText = "اسم المستخدم";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Visible = false;
            // 
            // UserPassword
            // 
            this.UserPassword.DataPropertyName = "الباسورد";
            this.UserPassword.HeaderText = "كلمة المرور";
            this.UserPassword.Name = "UserPassword";
            this.UserPassword.ReadOnly = true;
            this.UserPassword.Visible = false;
            // 
            // UserImage
            // 
            this.UserImage.DataPropertyName = "صورة المستخدم";
            this.UserImage.HeaderText = "صورة المستخدم";
            this.UserImage.Name = "UserImage";
            this.UserImage.ReadOnly = true;
            this.UserImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.UserImage.Visible = false;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.btnPrintAll);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gbSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbSearch.Location = new System.Drawing.Point(9, 333);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(566, 66);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "بحث المستخدمين";
            // 
            // btnPrintAll
            // 
            this.btnPrintAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.btnPrintAll.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Printer;
            this.btnPrintAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrintAll.FlatAppearance.BorderSize = 0;
            this.btnPrintAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintAll.Location = new System.Drawing.Point(6, 19);
            this.btnPrintAll.Name = "btnPrintAll";
            this.btnPrintAll.Size = new System.Drawing.Size(60, 43);
            this.btnPrintAll.TabIndex = 1;
            this.toolTipUserSearch.SetToolTip(this.btnPrintAll, "طباعة الكل");
            this.btnPrintAll.UseVisualStyleBackColor = false;
            this.btnPrintAll.Click += new System.EventHandler(this.btnPrintAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(80, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(476, 29);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // FRM_UserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(584, 411);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbContainer);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_UserSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTop.ResumeLayout(false);
            this.gbContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbContainer;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPrintAll;
        private System.Windows.Forms.ToolTip toolTipUserSearch;
        private System.Windows.Forms.DataGridViewImageColumn btnShow;
        private System.Windows.Forms.DataGridViewImageColumn btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserNatID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserJob;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UserForPro;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UserStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPassword;
        private System.Windows.Forms.DataGridViewImageColumn UserImage;
    }
}