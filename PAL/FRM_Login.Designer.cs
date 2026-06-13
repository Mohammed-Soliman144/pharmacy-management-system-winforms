
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Login));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.pBoxLogo = new System.Windows.Forms.PictureBox();
            this.errProviderLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblRecovery = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.pBoxUser = new System.Windows.Forms.PictureBox();
            this.cbSaveSettings = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.pBoxPassword = new System.Windows.Forms.PictureBox();
            this.pBoxPhone = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPhone)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(461, 38);
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
            this.btnClose.Location = new System.Drawing.Point(419, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("LBC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(157, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(146, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "تسجيل الدخول";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(321, 234);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(132, 43);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "دخول";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnNewUser
            // 
            this.btnNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnNewUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewUser.FlatAppearance.BorderSize = 0;
            this.btnNewUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.btnNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUser.ForeColor = System.Drawing.Color.White;
            this.btnNewUser.Location = new System.Drawing.Point(8, 234);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(132, 43);
            this.btnNewUser.TabIndex = 13;
            this.btnNewUser.Text = "مستخدم جديد";
            this.btnNewUser.UseVisualStyleBackColor = false;
            this.btnNewUser.Click += new System.EventHandler(this.btnNewUser_Click);
            // 
            // btnRecovery
            // 
            this.btnRecovery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.btnRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecovery.FlatAppearance.BorderSize = 0;
            this.btnRecovery.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(222)))), ((int)(((byte)(129)))));
            this.btnRecovery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecovery.ForeColor = System.Drawing.Color.White;
            this.btnRecovery.Location = new System.Drawing.Point(146, 234);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(169, 43);
            this.btnRecovery.TabIndex = 14;
            this.btnRecovery.Text = "استرجاع كلمة المرور";
            this.btnRecovery.UseVisualStyleBackColor = false;
            this.btnRecovery.Visible = false;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // pBoxLogo
            // 
            this.pBoxLogo.Image = global::PharmacySystemV20._0._1.Properties.Resources.SecurityPic;
            this.pBoxLogo.Location = new System.Drawing.Point(393, 0);
            this.pBoxLogo.Name = "pBoxLogo";
            this.pBoxLogo.Size = new System.Drawing.Size(68, 78);
            this.pBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBoxLogo.TabIndex = 19;
            this.pBoxLogo.TabStop = false;
            // 
            // errProviderLogin
            // 
            this.errProviderLogin.ContainerControl = this;
            this.errProviderLogin.Icon = ((System.Drawing.Icon)(resources.GetObject("errProviderLogin.Icon")));
            // 
            // lblRecovery
            // 
            this.lblRecovery.AutoSize = true;
            this.lblRecovery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecovery.Font = new System.Drawing.Font("LBC", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecovery.ForeColor = System.Drawing.Color.Tomato;
            this.lblRecovery.Location = new System.Drawing.Point(155, 245);
            this.lblRecovery.Name = "lblRecovery";
            this.lblRecovery.Size = new System.Drawing.Size(151, 20);
            this.lblRecovery.TabIndex = 22;
            this.lblRecovery.Text = "هل نسيت كلمة المرور !";
            this.lblRecovery.Click += new System.EventHandler(this.lblRecovery_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.btnDisplay.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.EyeInvisiblePic;
            this.btnDisplay.FlatAppearance.BorderSize = 0;
            this.btnDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplay.ForeColor = System.Drawing.Color.White;
            this.btnDisplay.Location = new System.Drawing.Point(422, 152);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(32, 27);
            this.btnDisplay.TabIndex = 28;
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // pBoxUser
            // 
            this.pBoxUser.Image = global::PharmacySystemV20._0._1.Properties.Resources.UserinfoPic;
            this.pBoxUser.Location = new System.Drawing.Point(7, 70);
            this.pBoxUser.Name = "pBoxUser";
            this.pBoxUser.Size = new System.Drawing.Size(48, 48);
            this.pBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBoxUser.TabIndex = 26;
            this.pBoxUser.TabStop = false;
            // 
            // cbSaveSettings
            // 
            this.cbSaveSettings.AutoSize = true;
            this.cbSaveSettings.Checked = true;
            this.cbSaveSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSaveSettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbSaveSettings.Location = new System.Drawing.Point(299, 193);
            this.cbSaveSettings.Name = "cbSaveSettings";
            this.cbSaveSettings.Size = new System.Drawing.Size(152, 24);
            this.cbSaveSettings.TabIndex = 25;
            this.cbSaveSettings.Text = "حفظ اعدادت الدخول";
            this.cbSaveSettings.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Font = new System.Drawing.Font("LBC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtUser.Location = new System.Drawing.Point(61, 84);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(339, 34);
            this.txtUser.TabIndex = 23;
            this.txtUser.Text = "ادخل اسم المستخدم";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            this.txtUser.Validated += new System.EventHandler(this.txtUser_Validated);
            // 
            // pBoxPassword
            // 
            this.pBoxPassword.Image = global::PharmacySystemV20._0._1.Properties.Resources.PasswordPic;
            this.pBoxPassword.Location = new System.Drawing.Point(7, 131);
            this.pBoxPassword.Name = "pBoxPassword";
            this.pBoxPassword.Size = new System.Drawing.Size(48, 48);
            this.pBoxPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBoxPassword.TabIndex = 27;
            this.pBoxPassword.TabStop = false;
            // 
            // pBoxPhone
            // 
            this.pBoxPhone.Image = global::PharmacySystemV20._0._1.Properties.Resources.CellPhonePic;
            this.pBoxPhone.Location = new System.Drawing.Point(8, 131);
            this.pBoxPhone.Name = "pBoxPhone";
            this.pBoxPhone.Size = new System.Drawing.Size(48, 48);
            this.pBoxPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pBoxPhone.TabIndex = 30;
            this.pBoxPhone.TabStop = false;
            this.pBoxPhone.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("LBC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPassword.Location = new System.Drawing.Point(61, 145);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(339, 34);
            this.txtPassword.TabIndex = 24;
            this.txtPassword.Text = "ادخل كلمة المرور";
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.Validated += new System.EventHandler(this.txtPassword_Validated);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPhone.Font = new System.Drawing.Font("LBC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPhone.Location = new System.Drawing.Point(61, 145);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(339, 34);
            this.txtPhone.TabIndex = 29;
            this.txtPhone.Text = "يرجى ادخال رقم الهاتف";
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.Visible = false;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.Enter += new System.EventHandler(this.txtPhone_Enter);
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            this.txtPhone.Validated += new System.EventHandler(this.txtPhone_Validated);
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(461, 287);
            this.ControlBox = false;
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.pBoxUser);
            this.Controls.Add(this.cbSaveSettings);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.pBoxPhone);
            this.Controls.Add(this.pBoxLogo);
            this.Controls.Add(this.lblRecovery);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.btnNewUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pBoxPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtPassword);
            this.Font = new System.Drawing.Font("LBC", 11.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة تسجيل الدخول";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errProviderLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxPhone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.PictureBox pBoxLogo;
        private System.Windows.Forms.ErrorProvider errProviderLogin;
        private System.Windows.Forms.Label lblRecovery;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.PictureBox pBoxUser;
        private System.Windows.Forms.CheckBox cbSaveSettings;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.PictureBox pBoxPassword;
        private System.Windows.Forms.PictureBox pBoxPhone;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPhone;
    }
}