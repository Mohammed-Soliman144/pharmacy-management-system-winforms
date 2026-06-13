
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_ItemGenerics
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvGeneric = new System.Windows.Forms.DataGridView();
            this.txtGenericName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemGenericID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGenericName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGenericStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneric)).BeginInit();
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
            this.lblTitle.Text = "قائمة المواد الفعالة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvGeneric
            // 
            this.dgvGeneric.AllowUserToAddRows = false;
            this.dgvGeneric.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeneric.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGeneric.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.dgvGeneric.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneric.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemGenericID,
            this.ItemGenericName,
            this.ItemGenericStatus,
            this.btnDelete});
            this.dgvGeneric.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGeneric.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGeneric.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGeneric.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvGeneric.Location = new System.Drawing.Point(0, 135);
            this.dgvGeneric.Name = "dgvGeneric";
            this.dgvGeneric.ReadOnly = true;
            this.dgvGeneric.Size = new System.Drawing.Size(426, 255);
            this.dgvGeneric.TabIndex = 2;
            this.dgvGeneric.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGeneric_CellContentClick);
            // 
            // txtGenericName
            // 
            this.txtGenericName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGenericName.Location = new System.Drawing.Point(46, 89);
            this.txtGenericName.Name = "txtGenericName";
            this.txtGenericName.Size = new System.Drawing.Size(368, 27);
            this.txtGenericName.TabIndex = 0;
            this.txtGenericName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGenericName_KeyDown);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(42)))));
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 28);
            this.label1.TabIndex = 78;
            this.label1.Text = "المادة الفعالة :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemGenericID
            // 
            this.ItemGenericID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemGenericID.DataPropertyName = "GenericID";
            this.ItemGenericID.HeaderText = "مسلسل";
            this.ItemGenericID.Name = "ItemGenericID";
            this.ItemGenericID.ReadOnly = true;
            this.ItemGenericID.Visible = false;
            this.ItemGenericID.Width = 86;
            // 
            // ItemGenericName
            // 
            this.ItemGenericName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemGenericName.DataPropertyName = "GenericName";
            this.ItemGenericName.HeaderText = "المادة الفعالة";
            this.ItemGenericName.Name = "ItemGenericName";
            this.ItemGenericName.ReadOnly = true;
            // 
            // ItemGenericStatus
            // 
            this.ItemGenericStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemGenericStatus.DataPropertyName = "GenericStatus";
            this.ItemGenericStatus.HeaderText = "الحالة";
            this.ItemGenericStatus.Name = "ItemGenericStatus";
            this.ItemGenericStatus.ReadOnly = true;
            this.ItemGenericStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemGenericStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // FRM_ItemGenerics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(426, 390);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGenericName);
            this.Controls.Add(this.dgvGeneric);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_ItemGenerics";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة إضافة المادة الفعالة";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGeneric;
        private System.Windows.Forms.TextBox txtGenericName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGenericID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGenericName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemGenericStatus;
        private System.Windows.Forms.DataGridViewImageColumn btnDelete;
    }
}