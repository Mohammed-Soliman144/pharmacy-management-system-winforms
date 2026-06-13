
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_PointOfSales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvPOS = new System.Windows.Forms.DataGridView();
            this.POSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSCustomCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtPOSName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPOSBalance = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).BeginInit();
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
            this.pnlTop.Size = new System.Drawing.Size(426, 38);
            this.pnlTop.TabIndex = 6;
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
            this.btnClose.Location = new System.Drawing.Point(384, 0);
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
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(128, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "قائمة نقاط البيع";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPOS
            // 
            this.dgvPOS.AllowUserToAddRows = false;
            this.dgvPOS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPOS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POSID,
            this.POSCustomCode,
            this.POS,
            this.POSName,
            this.POSBalance,
            this.POSStatus,
            this.btnDelete});
            this.dgvPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPOS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPOS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvPOS.Location = new System.Drawing.Point(0, 136);
            this.dgvPOS.Name = "dgvPOS";
            this.dgvPOS.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPOS.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPOS.Size = new System.Drawing.Size(426, 254);
            this.dgvPOS.TabIndex = 2;
            this.dgvPOS.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPOS_CellContentClick);
            this.dgvPOS.VisibleChanged += new System.EventHandler(this.dgvPOS_VisibleChanged);
            this.dgvPOS.DoubleClick += new System.EventHandler(this.dgvPOS_DoubleClick);
            // 
            // POSID
            // 
            this.POSID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.POSID.DataPropertyName = "الكود الداخلى";
            this.POSID.HeaderText = "الكود الداخلى";
            this.POSID.Name = "POSID";
            this.POSID.ReadOnly = true;
            this.POSID.Visible = false;
            // 
            // POSCustomCode
            // 
            this.POSCustomCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.POSCustomCode.DataPropertyName = "كود نقطة البيع";
            this.POSCustomCode.HeaderText = "كود نقطة البيع";
            this.POSCustomCode.Name = "POSCustomCode";
            this.POSCustomCode.ReadOnly = true;
            this.POSCustomCode.Visible = false;
            // 
            // POS
            // 
            this.POS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.POS.HeaderText = "م";
            this.POS.Name = "POS";
            this.POS.ReadOnly = true;
            this.POS.ToolTipText = "مسلسل";
            this.POS.Width = 44;
            // 
            // POSName
            // 
            this.POSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.POSName.DataPropertyName = "اسم نقطة البيع";
            this.POSName.HeaderText = "اسم نقطة البيع";
            this.POSName.Name = "POSName";
            this.POSName.ReadOnly = true;
            this.POSName.ToolTipText = "اسم نقطة البيع";
            this.POSName.Width = 131;
            // 
            // POSBalance
            // 
            this.POSBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.POSBalance.DataPropertyName = "الرصيد الحالى";
            this.POSBalance.HeaderText = "الرصيد الحالى";
            this.POSBalance.Name = "POSBalance";
            this.POSBalance.ReadOnly = true;
            this.POSBalance.ToolTipText = "الرصيد الحالى";
            this.POSBalance.Width = 119;
            // 
            // POSStatus
            // 
            this.POSStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.POSStatus.DataPropertyName = "حالة نقطة البيع";
            this.POSStatus.HeaderText = "الحالة";
            this.POSStatus.Name = "POSStatus";
            this.POSStatus.ReadOnly = true;
            this.POSStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.POSStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.POSStatus.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.btnDelete.HeaderText = "حذف";
            this.btnDelete.Image = global::PharmacySystemV20._0._1.Properties.Resources.DeletePic;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.ToolTipText = "حذف";
            // 
            // txtPOSName
            // 
            this.txtPOSName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPOSName.Location = new System.Drawing.Point(132, 52);
            this.txtPOSName.Name = "txtPOSName";
            this.txtPOSName.Size = new System.Drawing.Size(282, 27);
            this.txtPOSName.TabIndex = 0;
            this.txtPOSName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPOSName_KeyDown);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(7, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 78;
            this.label1.Text = "اسم نقطة البيع :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.label2.Location = new System.Drawing.Point(7, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 28);
            this.label2.TabIndex = 80;
            this.label2.Text = "الرصيد الحالى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPOSBalance
            // 
            this.txtPOSBalance.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtPOSBalance.Location = new System.Drawing.Point(132, 85);
            this.txtPOSBalance.Name = "txtPOSBalance";
            this.txtPOSBalance.Size = new System.Drawing.Size(282, 27);
            this.txtPOSBalance.TabIndex = 1;
            this.txtPOSBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPOSBalance_KeyDown);
            // 
            // FRM_PointOfSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(426, 390);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPOSBalance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPOSName);
            this.Controls.Add(this.dgvPOS);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_PointOfSales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة إضافة المادة الفعالة";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvPOS;
        private System.Windows.Forms.TextBox txtPOSName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPOSBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSCustomCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn POS;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSBalance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn POSStatus;
        private System.Windows.Forms.DataGridViewImageColumn btnDelete;
    }
}