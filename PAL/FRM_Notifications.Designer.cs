namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Notifications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Notifications));
            this.imgListNotify = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.lblImage = new System.Windows.Forms.Label();
            this.rbtnInActivate = new System.Windows.Forms.RadioButton();
            this.rbtnDelete = new System.Windows.Forms.RadioButton();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblSubject = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListNotify
            // 
            this.imgListNotify.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListNotify.ImageStream")));
            this.imgListNotify.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListNotify.Images.SetKeyName(0, "Information.ico");
            this.imgListNotify.Images.SetKeyName(1, "Error.ico");
            this.imgListNotify.Images.SetKeyName(2, "Question.ico");
            this.imgListNotify.Images.SetKeyName(3, "Warning.ico");
            this.imgListNotify.Images.SetKeyName(4, "Hand.ico");
            this.imgListNotify.Images.SetKeyName(5, "SystemError.ico");
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
            this.pnlTop.Size = new System.Drawing.Size(380, 38);
            this.pnlTop.TabIndex = 2;
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
            this.btnClose.Location = new System.Drawing.Point(338, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 38);
            this.btnClose.TabIndex = 1;
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
            this.lblTitle.Size = new System.Drawing.Size(140, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "رسالة";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.SystemColors.Control;
            this.pnlControls.Controls.Add(this.lblImage);
            this.pnlControls.Controls.Add(this.rbtnInActivate);
            this.pnlControls.Controls.Add(this.rbtnDelete);
            this.pnlControls.Controls.Add(this.btnNo);
            this.pnlControls.Controls.Add(this.btnYes);
            this.pnlControls.Controls.Add(this.lblSubject);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 38);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(380, 142);
            this.pnlControls.TabIndex = 3;
            // 
            // lblImage
            // 
            this.lblImage.ImageIndex = 0;
            this.lblImage.ImageList = this.imgListNotify;
            this.lblImage.Location = new System.Drawing.Point(312, 3);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(65, 88);
            this.lblImage.TabIndex = 8;
            // 
            // rbtnInActivate
            // 
            this.rbtnInActivate.AutoSize = true;
            this.rbtnInActivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnInActivate.ForeColor = System.Drawing.Color.Black;
            this.rbtnInActivate.Location = new System.Drawing.Point(77, 56);
            this.rbtnInActivate.Name = "rbtnInActivate";
            this.rbtnInActivate.Size = new System.Drawing.Size(185, 24);
            this.rbtnInActivate.TabIndex = 7;
            this.rbtnInActivate.Text = "حذف السجل بشكل مؤقت";
            this.rbtnInActivate.UseVisualStyleBackColor = true;
            this.rbtnInActivate.Visible = false;
            // 
            // rbtnDelete
            // 
            this.rbtnDelete.AutoSize = true;
            this.rbtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnDelete.ForeColor = System.Drawing.Color.Black;
            this.rbtnDelete.Location = new System.Drawing.Point(79, 18);
            this.rbtnDelete.Name = "rbtnDelete";
            this.rbtnDelete.Size = new System.Drawing.Size(183, 24);
            this.rbtnDelete.TabIndex = 6;
            this.rbtnDelete.Text = "حذف السجل بشكل نهائى";
            this.rbtnDelete.UseVisualStyleBackColor = true;
            this.rbtnDelete.Visible = false;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNo.ForeColor = System.Drawing.Color.Black;
            this.btnNo.Location = new System.Drawing.Point(71, 101);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(102, 33);
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "خروج";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Visible = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnYes.FlatAppearance.BorderSize = 0;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnYes.ForeColor = System.Drawing.Color.Black;
            this.btnYes.Location = new System.Drawing.Point(139, 101);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(102, 33);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "نعم";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblSubject
            // 
            this.lblSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSubject.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSubject.ForeColor = System.Drawing.Color.Black;
            this.lblSubject.Location = new System.Drawing.Point(3, 3);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubject.Size = new System.Drawing.Size(303, 88);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "label1";
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FRM_Notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Notifications";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notifications";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRM_Notifications_FormClosed);
            this.pnlTop.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListNotify;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.RadioButton rbtnInActivate;
        private System.Windows.Forms.RadioButton rbtnDelete;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblImage;
    }
}