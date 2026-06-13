
namespace PharmacySystemV20._0._1.RPT
{
    partial class FRM_SupAccountViewerRpt
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
            this.crystalRptViewerSupAcc = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlTop.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalRptViewerSupAcc
            // 
            this.crystalRptViewerSupAcc.ActiveViewIndex = -1;
            this.crystalRptViewerSupAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalRptViewerSupAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalRptViewerSupAcc.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalRptViewerSupAcc.Location = new System.Drawing.Point(0, 42);
            this.crystalRptViewerSupAcc.Name = "crystalRptViewerSupAcc";
            this.crystalRptViewerSupAcc.ShowCloseButton = false;
            this.crystalRptViewerSupAcc.ShowCopyButton = false;
            this.crystalRptViewerSupAcc.ShowGroupTreeButton = false;
            this.crystalRptViewerSupAcc.ShowLogo = false;
            this.crystalRptViewerSupAcc.ShowParameterPanelButton = false;
            this.crystalRptViewerSupAcc.ShowTextSearchButton = false;
            this.crystalRptViewerSupAcc.Size = new System.Drawing.Size(534, 369);
            this.crystalRptViewerSupAcc.TabIndex = 2;
            this.crystalRptViewerSupAcc.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
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
            this.pnlTop.Size = new System.Drawing.Size(534, 42);
            this.pnlTop.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::PharmacySystemV20._0._1.Properties.Resources.CancelNew;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(492, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(174, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(187, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "تقارير حسابات الموردين";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.crystalRptViewerSupAcc);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(534, 411);
            this.pnlContainer.TabIndex = 15;
            // 
            // FRM_SupAccountViewerRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(534, 411);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_SupAccountViewerRpt";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlTop.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalRptViewerSupAcc;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContainer;
    }
}