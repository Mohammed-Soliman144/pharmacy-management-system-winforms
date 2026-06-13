
namespace PharmacySystemV20._0._1.PAL
{
    partial class FRM_Intro
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBarIntro = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.timerIntro = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PharmacySystemV20._0._1.Properties.Resources.Microdata_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(4, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // progressBarIntro
            // 
            this.progressBarIntro.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarIntro.Location = new System.Drawing.Point(0, 100);
            this.progressBarIntro.Maximum = 500;
            this.progressBarIntro.Name = "progressBarIntro";
            this.progressBarIntro.Size = new System.Drawing.Size(200, 12);
            this.progressBarIntro.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(92)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "Pharmacy Ver 20.0.1";
            // 
            // timerIntro
            // 
            this.timerIntro.Enabled = true;
            this.timerIntro.Interval = 1000;
            this.timerIntro.Tick += new System.EventHandler(this.timerIntro_Tick);
            // 
            // FRM_Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(200, 112);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarIntro);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("LBC", 12.75F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_Intro";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_Intro";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBarIntro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timerIntro;
    }
}