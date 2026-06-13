namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_SupplierArea
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
            this.listBoxAreas = new System.Windows.Forms.ListBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtEdit = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxAreas
            // 
            this.listBoxAreas.BackColor = System.Drawing.SystemColors.Control;
            this.listBoxAreas.FormattingEnabled = true;
            this.listBoxAreas.ItemHeight = 20;
            this.listBoxAreas.Location = new System.Drawing.Point(3, 35);
            this.listBoxAreas.Name = "listBoxAreas";
            this.listBoxAreas.ScrollAlwaysVisible = true;
            this.listBoxAreas.Size = new System.Drawing.Size(278, 184);
            this.listBoxAreas.TabIndex = 6;
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
            this.pnlTop.Size = new System.Drawing.Size(284, 38);
            this.pnlTop.TabIndex = 7;
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
            this.btnClose.Location = new System.Drawing.Point(242, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 38);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "إضافة منطقة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(25, 234);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 33);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Location = new System.Drawing.Point(157, 234);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 33);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "إضافة";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBoxAreas);
            this.panel1.Controls.Add(this.txtEdit);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 275);
            this.panel1.TabIndex = 6;
            // 
            // txtEdit
            // 
            this.txtEdit.Location = new System.Drawing.Point(3, 4);
            this.txtEdit.Name = "txtEdit";
            this.txtEdit.Size = new System.Drawing.Size(278, 27);
            this.txtEdit.TabIndex = 0;
            this.txtEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdit_KeyDown);
            // 
            // FRM_SupplierArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.ControlBox = false;
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SupplierArea";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRM_SupplierArea_FormClosing);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAreas;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtEdit;
    }
}