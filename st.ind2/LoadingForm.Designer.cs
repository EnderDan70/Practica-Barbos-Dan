using System;
using System.Windows.Forms;

namespace st.ind2
{
    partial class LoadingForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelProgressContainer;
        private System.Windows.Forms.PictureBox pictureBoxCart;
        private RoundedProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelLoading;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingForm));
            this.panelProgressContainer = new System.Windows.Forms.Panel();
            this.labelLoading = new System.Windows.Forms.Label();
            this.pictureBoxCart = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new st.ind2.RoundedProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelProgressContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCart)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProgressContainer
            // 
            this.panelProgressContainer.BackColor = System.Drawing.Color.Orange;
            this.panelProgressContainer.Controls.Add(this.labelLoading);
            this.panelProgressContainer.Controls.Add(this.pictureBoxCart);
            this.panelProgressContainer.Controls.Add(this.progressBar1);
            this.panelProgressContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgressContainer.Location = new System.Drawing.Point(0, 0);
            this.panelProgressContainer.Name = "panelProgressContainer";
            this.panelProgressContainer.Size = new System.Drawing.Size(400, 220);
            this.panelProgressContainer.TabIndex = 0;
            // 
            // labelLoading
            // 
            this.labelLoading.AutoSize = true;
            this.labelLoading.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.labelLoading.ForeColor = System.Drawing.Color.Transparent;
            this.labelLoading.Location = new System.Drawing.Point(98, 123);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(202, 45);
            this.labelLoading.TabIndex = 2;
            this.labelLoading.Text = "Download...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoading.Click += new System.EventHandler(this.labelLoading_Click);
            // 
            // pictureBoxCart
            // 
            this.pictureBoxCart.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCart.ErrorImage")));
            this.pictureBoxCart.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxCart.Image")));
            this.pictureBoxCart.Location = new System.Drawing.Point(129, 0);
            this.pictureBoxCart.Name = "pictureBoxCart";
            this.pictureBoxCart.Size = new System.Drawing.Size(120, 120);
            this.pictureBoxCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCart.TabIndex = 0;
            this.pictureBoxCart.TabStop = false;
            this.pictureBoxCart.Click += new System.EventHandler(this.pictureBoxCart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.BarColor = System.Drawing.Color.MintCream;
            this.progressBar1.BorderColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(50, 180);
            this.progressBar1.MinimumSize = new System.Drawing.Size(30, 10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 14);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.TrackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 220);
            this.Controls.Add(this.panelProgressContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Загрузка";
            this.panelProgressContainer.ResumeLayout(false);
            this.panelProgressContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCart)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
