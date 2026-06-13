
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_SupplierAccount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.lblDes = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.SupAccID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccSupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccOperationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccBillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccCustomID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupAccStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SupAccTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblPreviousStatus = new System.Windows.Forms.Label();
            this.lblPreBalance = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboOperations = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.comboSuppliers = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblCurrentBalance = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblOperCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlTop.Controls.Add(this.pbTitle);
            this.pnlTop.Controls.Add(this.lblDes);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(790, 70);
            this.pnlTop.TabIndex = 1;
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.Image = global::PharmacySystemV20._0._1.Properties.Resources.SupplierLedgerFRM;
            this.pbTitle.Location = new System.Drawing.Point(633, 3);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(154, 64);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 67;
            this.pbTitle.TabStop = false;
            // 
            // lblDes
            // 
            this.lblDes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDes.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblDes.Location = new System.Drawing.Point(88, 37);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(540, 24);
            this.lblDes.TabIndex = 66;
            this.lblDes.Text = "من خلال هذة النافذة يتم عرض جميع العمليات المرتبطة بحساب المورد";
            this.lblDes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(149, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(479, 30);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "كشف حساب الموردين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.pnlDgv);
            this.pnlContainer.Controls.Add(this.pnlSearch);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 70);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(790, 520);
            this.pnlContainer.TabIndex = 2;
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlDgv.Controls.Add(this.dgvSearch);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.pnlDgv.Location = new System.Drawing.Point(0, 133);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Size = new System.Drawing.Size(790, 387);
            this.pnlDgv.TabIndex = 1;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSearch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupAccID,
            this.SupAccSerial,
            this.SupAccDate,
            this.SupAccSupplierID,
            this.SupplierFullName,
            this.SupAccOperationName,
            this.SupAccBillID,
            this.SupAccCustomID,
            this.SupAccDebit,
            this.SupAccCredit,
            this.SupAccBalance,
            this.SupAccNotes,
            this.SupAccStatus,
            this.SupAccTime});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgvSearch.GridColor = System.Drawing.Color.Silver;
            this.dgvSearch.Location = new System.Drawing.Point(3, 6);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgvSearch.Size = new System.Drawing.Size(788, 273);
            this.dgvSearch.TabIndex = 166;
            // 
            // SupAccID
            // 
            this.SupAccID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccID.DataPropertyName = "رقم الحركة";
            this.SupAccID.HeaderText = "مسلسل";
            this.SupAccID.Name = "SupAccID";
            this.SupAccID.ReadOnly = true;
            this.SupAccID.Visible = false;
            // 
            // SupAccSerial
            // 
            this.SupAccSerial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccSerial.HeaderText = "مسلسل";
            this.SupAccSerial.Name = "SupAccSerial";
            this.SupAccSerial.ReadOnly = true;
            this.SupAccSerial.Width = 74;
            // 
            // SupAccDate
            // 
            this.SupAccDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccDate.DataPropertyName = "تاريخ إنشاء الحركة";
            this.SupAccDate.HeaderText = "التاريخ";
            this.SupAccDate.Name = "SupAccDate";
            this.SupAccDate.ReadOnly = true;
            this.SupAccDate.Width = 69;
            // 
            // SupAccSupplierID
            // 
            this.SupAccSupplierID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccSupplierID.DataPropertyName = "رقم المورد";
            this.SupAccSupplierID.HeaderText = "رقم المورد";
            this.SupAccSupplierID.Name = "SupAccSupplierID";
            this.SupAccSupplierID.ReadOnly = true;
            this.SupAccSupplierID.Visible = false;
            // 
            // SupplierFullName
            // 
            this.SupplierFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupplierFullName.DataPropertyName = "اسم المورد";
            this.SupplierFullName.HeaderText = "المورد";
            this.SupplierFullName.Name = "SupplierFullName";
            this.SupplierFullName.ReadOnly = true;
            this.SupplierFullName.Width = 64;
            // 
            // SupAccOperationName
            // 
            this.SupAccOperationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccOperationName.DataPropertyName = "نوع الحـركــــــــــة";
            this.SupAccOperationName.HeaderText = "نوع الحركة";
            this.SupAccOperationName.Name = "SupAccOperationName";
            this.SupAccOperationName.ReadOnly = true;
            this.SupAccOperationName.Width = 88;
            // 
            // SupAccBillID
            // 
            this.SupAccBillID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccBillID.DataPropertyName = "رقم الفاتورة";
            this.SupAccBillID.HeaderText = "رقم الفاتورة";
            this.SupAccBillID.Name = "SupAccBillID";
            this.SupAccBillID.ReadOnly = true;
            this.SupAccBillID.Visible = false;
            // 
            // SupAccCustomID
            // 
            this.SupAccCustomID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccCustomID.DataPropertyName = "رقم الفاتورة الداخلى";
            this.SupAccCustomID.HeaderText = "رقم الفاتورة الداخلى";
            this.SupAccCustomID.Name = "SupAccCustomID";
            this.SupAccCustomID.ReadOnly = true;
            this.SupAccCustomID.Visible = false;
            // 
            // SupAccDebit
            // 
            this.SupAccDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccDebit.DataPropertyName = "القيمة المدينة";
            this.SupAccDebit.HeaderText = "مدين";
            this.SupAccDebit.Name = "SupAccDebit";
            this.SupAccDebit.ReadOnly = true;
            this.SupAccDebit.Width = 60;
            // 
            // SupAccCredit
            // 
            this.SupAccCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccCredit.DataPropertyName = "القيمة الدائنة";
            this.SupAccCredit.HeaderText = "دائن";
            this.SupAccCredit.Name = "SupAccCredit";
            this.SupAccCredit.ReadOnly = true;
            this.SupAccCredit.Width = 56;
            // 
            // SupAccBalance
            // 
            this.SupAccBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccBalance.DataPropertyName = "الرصيد الحالى";
            this.SupAccBalance.HeaderText = "الرصيد";
            this.SupAccBalance.Name = "SupAccBalance";
            this.SupAccBalance.ReadOnly = true;
            this.SupAccBalance.Width = 70;
            // 
            // SupAccNotes
            // 
            this.SupAccNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SupAccNotes.DataPropertyName = "تفاصيل الحركة";
            this.SupAccNotes.HeaderText = "بـيــــــــــــــــــــــــان";
            this.SupAccNotes.Name = "SupAccNotes";
            this.SupAccNotes.ReadOnly = true;
            // 
            // SupAccStatus
            // 
            this.SupAccStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccStatus.DataPropertyName = "حالة الحركة";
            this.SupAccStatus.HeaderText = "الحالة";
            this.SupAccStatus.Name = "SupAccStatus";
            this.SupAccStatus.ReadOnly = true;
            this.SupAccStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SupAccStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SupAccStatus.Visible = false;
            // 
            // SupAccTime
            // 
            this.SupAccTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SupAccTime.DataPropertyName = "وقت إنشاء الحركة";
            this.SupAccTime.HeaderText = "الوقت";
            this.SupAccTime.Name = "SupAccTime";
            this.SupAccTime.ReadOnly = true;
            this.SupAccTime.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblPreviousStatus);
            this.pnlSearch.Controls.Add(this.lblPreBalance);
            this.pnlSearch.Controls.Add(this.label13);
            this.pnlSearch.Controls.Add(this.comboOperations);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.dtpDateTo);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.comboSuppliers);
            this.pnlSearch.Controls.Add(this.label18);
            this.pnlSearch.Controls.Add(this.dtpDateFrom);
            this.pnlSearch.Controls.Add(this.label16);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Controls.Add(this.splitter1);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(790, 133);
            this.pnlSearch.TabIndex = 0;
            // 
            // lblPreviousStatus
            // 
            this.lblPreviousStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviousStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviousStatus.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPreviousStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblPreviousStatus.Location = new System.Drawing.Point(368, 93);
            this.lblPreviousStatus.Name = "lblPreviousStatus";
            this.lblPreviousStatus.Size = new System.Drawing.Size(127, 27);
            this.lblPreviousStatus.TabIndex = 178;
            this.lblPreviousStatus.Text = "----";
            this.lblPreviousStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPreBalance
            // 
            this.lblPreBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblPreBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPreBalance.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPreBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblPreBalance.Location = new System.Drawing.Point(501, 93);
            this.lblPreBalance.Name = "lblPreBalance";
            this.lblPreBalance.Size = new System.Drawing.Size(170, 27);
            this.lblPreBalance.TabIndex = 176;
            this.lblPreBalance.Text = "0";
            this.lblPreBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(676, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 20);
            this.label13.TabIndex = 177;
            this.label13.Text = "الرصيد السابق :";
            // 
            // comboOperations
            // 
            this.comboOperations.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboOperations.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboOperations.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboOperations.BackColor = System.Drawing.SystemColors.Window;
            this.comboOperations.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboOperations.FormattingEnabled = true;
            this.comboOperations.Location = new System.Drawing.Point(118, 49);
            this.comboOperations.Name = "comboOperations";
            this.comboOperations.Size = new System.Drawing.Size(302, 28);
            this.comboOperations.TabIndex = 175;
            this.comboOperations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboOperations_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(426, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 174;
            this.label2.Text = "نوع الحركة :";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDateTo.CustomFormat = "yyyy-MM-dd";
            this.dtpDateTo.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(519, 49);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(134, 27);
            this.dtpDateTo.TabIndex = 172;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(657, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 173;
            this.label1.Text = "إلى تاريخ :";
            // 
            // comboSuppliers
            // 
            this.comboSuppliers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboSuppliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboSuppliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboSuppliers.BackColor = System.Drawing.SystemColors.Window;
            this.comboSuppliers.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comboSuppliers.FormattingEnabled = true;
            this.comboSuppliers.Location = new System.Drawing.Point(118, 16);
            this.comboSuppliers.Name = "comboSuppliers";
            this.comboSuppliers.Size = new System.Drawing.Size(302, 28);
            this.comboSuppliers.TabIndex = 169;
            this.comboSuppliers.TextChanged += new System.EventHandler(this.comboSuppliers_TextChanged);
            this.comboSuppliers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboSuppliers_KeyDown);
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label18.Location = new System.Drawing.Point(426, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 20);
            this.label18.TabIndex = 171;
            this.label18.Text = "اسم المورد :";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpDateFrom.CustomFormat = "yyyy-MM-dd";
            this.dtpDateFrom.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(519, 17);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(134, 27);
            this.dtpDateFrom.TabIndex = 168;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(657, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 20);
            this.label16.TabIndex = 170;
            this.label16.Text = "من تاريخ :";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Image = global::PharmacySystemV20._0._1.Properties.Resources.Search_Google;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(5, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 60);
            this.btnSearch.TabIndex = 149;
            this.btnSearch.Text = "بحث";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 83);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(788, 48);
            this.splitter1.TabIndex = 179;
            this.splitter1.TabStop = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblCurrentStatus);
            this.pnlBottom.Controls.Add(this.lblCurrentBalance);
            this.pnlBottom.Controls.Add(this.label4);
            this.pnlBottom.Controls.Add(this.label6);
            this.pnlBottom.Controls.Add(this.lblTotalCredit);
            this.pnlBottom.Controls.Add(this.lblTotalDebit);
            this.pnlBottom.Controls.Add(this.lblOperCount);
            this.pnlBottom.Controls.Add(this.label5);
            this.pnlBottom.Controls.Add(this.label7);
            this.pnlBottom.Controls.Add(this.label8);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnNew);
            this.pnlBottom.Controls.Add(this.btnExit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 488);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(790, 102);
            this.pnlBottom.TabIndex = 0;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCurrentStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentStatus.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblCurrentStatus.Location = new System.Drawing.Point(202, 38);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(182, 27);
            this.lblCurrentStatus.TabIndex = 176;
            this.lblCurrentStatus.Text = "----";
            this.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentBalance
            // 
            this.lblCurrentBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentBalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblCurrentBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCurrentBalance.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrentBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblCurrentBalance.Location = new System.Drawing.Point(202, 8);
            this.lblCurrentBalance.Name = "lblCurrentBalance";
            this.lblCurrentBalance.Size = new System.Drawing.Size(182, 27);
            this.lblCurrentBalance.TabIndex = 175;
            this.lblCurrentBalance.Text = "0";
            this.lblCurrentBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(387, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 174;
            this.label4.Text = "حالة الرصيد :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(387, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 173;
            this.label6.Text = "الرصيد الحالى :";
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotalCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalCredit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalCredit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblTotalCredit.Location = new System.Drawing.Point(501, 67);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(182, 27);
            this.lblTotalCredit.TabIndex = 169;
            this.lblTotalCredit.Text = "0";
            this.lblTotalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDebit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblTotalDebit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalDebit.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalDebit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblTotalDebit.Location = new System.Drawing.Point(501, 38);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(182, 27);
            this.lblTotalDebit.TabIndex = 168;
            this.lblTotalDebit.Text = "0";
            this.lblTotalDebit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOperCount
            // 
            this.lblOperCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblOperCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblOperCount.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOperCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblOperCount.Location = new System.Drawing.Point(501, 8);
            this.lblOperCount.Name = "lblOperCount";
            this.lblOperCount.Size = new System.Drawing.Size(182, 27);
            this.lblOperCount.TabIndex = 167;
            this.lblOperCount.Text = "0";
            this.lblOperCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(688, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 172;
            this.label5.Text = "اجمالى دائن :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(688, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 171;
            this.label7.Text = "اجمالى مدين :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(688, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 170;
            this.label8.Text = "عدد الحركات :";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnPrint.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.Printer;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(69, 50);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 47);
            this.btnPrint.TabIndex = 166;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNew.Image = global::PharmacySystemV20._0._1.Properties.Resources.Add;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 50);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(60, 47);
            this.btnNew.TabIndex = 150;
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Image = global::PharmacySystemV20._0._1.Properties.Resources.Exit;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(135, 50);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 47);
            this.btnExit.TabIndex = 151;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FRM_SupplierAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 590);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SupplierAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب الموردين";
            this.Load += new System.EventHandler(this.FRM_SupplierAccount_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        public System.Windows.Forms.Label lblCurrentStatus;
        public System.Windows.Forms.Label lblCurrentBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblTotalCredit;
        public System.Windows.Forms.Label lblTotalDebit;
        public System.Windows.Forms.Label lblOperCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboOperations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboSuppliers;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label lblPreviousStatus;
        public System.Windows.Forms.Label lblPreBalance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dgvSearch;
        public System.Windows.Forms.DateTimePicker dtpDateTo;
        public System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccSupplierID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccOperationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccBillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccCustomID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccNotes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SupAccStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupAccTime;
    }
}