
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_ItemGroups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ItemGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemGroupStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
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
            this.lblTitle.Location = new System.Drawing.Point(115, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(197, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "قائمة المجموعات العلمية";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemGroupID,
            this.ItemGroupName,
            this.ItemGroupStatus,
            this.btnDelete});
            this.dgvGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvGroup.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(96)))), ((int)(((byte)(111)))));
            this.dgvGroup.Location = new System.Drawing.Point(0, 135);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.Size = new System.Drawing.Size(426, 255);
            this.dgvGroup.TabIndex = 2;
            this.dgvGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellContentClick);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtGroupName.Location = new System.Drawing.Point(46, 89);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(368, 27);
            this.txtGroupName.TabIndex = 0;
            this.txtGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGroupName_KeyDown);
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
            this.label1.Text = "المجموعة العلمية :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ItemGroupID
            // 
            this.ItemGroupID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemGroupID.DataPropertyName = "GroupID";
            this.ItemGroupID.HeaderText = "مسلسل";
            this.ItemGroupID.Name = "ItemGroupID";
            this.ItemGroupID.ReadOnly = true;
            this.ItemGroupID.Visible = false;
            this.ItemGroupID.Width = 86;
            // 
            // ItemGroupName
            // 
            this.ItemGroupName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemGroupName.DataPropertyName = "GroupName";
            this.ItemGroupName.HeaderText = "المجموعة العلمية";
            this.ItemGroupName.Name = "ItemGroupName";
            this.ItemGroupName.ReadOnly = true;
            // 
            // ItemGroupStatus
            // 
            this.ItemGroupStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemGroupStatus.DataPropertyName = "GroupStatus";
            this.ItemGroupStatus.HeaderText = "الحالة";
            this.ItemGroupStatus.Name = "ItemGroupStatus";
            this.ItemGroupStatus.ReadOnly = true;
            this.ItemGroupStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemGroupStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // FRM_ItemGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(86)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(426, 390);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.dgvGroup);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_ItemGroups";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة إضافة المجموعات العلمية";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemGroupName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemGroupStatus;
        private System.Windows.Forms.DataGridViewImageColumn btnDelete;
    }
}