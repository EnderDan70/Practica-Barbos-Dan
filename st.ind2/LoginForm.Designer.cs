using System.Windows.Forms;
using System;

namespace st.ind2
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.LinkLabel linkClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void linkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkClear_Click(sender, e);
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {
            // Optional: Add logic or leave empty if not needed
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Optional: Add logic or leave empty if not needed
        }


        private void InitializeComponent()
        {
            this.labelLogin = new System.Windows.Forms.Label();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.labelRole = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.linkClear = new System.Windows.Forms.LinkLabel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.labelLogin.ForeColor = System.Drawing.Color.Orange;
            this.labelLogin.Location = new System.Drawing.Point(320, 30);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(80, 30);
            this.labelLogin.TabIndex = 1;
            this.labelLogin.Text = "LOGIN";
            // 
            // comboRole
            // 
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.Items.AddRange(new object[] {
            "Admin",
            "Seller"});
            this.comboRole.Location = new System.Drawing.Point(370, 78);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(180, 21);
            this.comboRole.TabIndex = 3;
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelRole.ForeColor = System.Drawing.Color.Orange;
            this.labelRole.Location = new System.Drawing.Point(280, 80);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(43, 19);
            this.labelRole.TabIndex = 2;
            this.labelRole.Text = "Role:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelUsername.ForeColor = System.Drawing.Color.Orange;
            this.labelUsername.Location = new System.Drawing.Point(280, 130);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(53, 19);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "Name:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelPassword.ForeColor = System.Drawing.Color.Orange;
            this.labelPassword.Location = new System.Drawing.Point(280, 180);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(77, 19);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password:";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(370, 128);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(180, 20);
            this.textUsername.TabIndex = 5;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(370, 178);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '●';
            this.textPassword.Size = new System.Drawing.Size(180, 20);
            this.textPassword.TabIndex = 7;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Orange;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(370, 230);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(180, 35);
            this.buttonLogin.TabIndex = 8;
            this.buttonLogin.Text = "LOGIN";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // linkClear
            // 
            this.linkClear.AutoSize = true;
            this.linkClear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkClear.LinkColor = System.Drawing.Color.Orange;
            this.linkClear.Location = new System.Drawing.Point(450, 275);
            this.linkClear.Name = "linkClear";
            this.linkClear.Size = new System.Drawing.Size(51, 19);
            this.linkClear.TabIndex = 9;
            this.linkClear.TabStop = true;
            this.linkClear.Text = "CLEAN";
            this.linkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClear_LinkClicked);
            this.linkClear.Click += new System.EventHandler(this.linkClear_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.BackColor = System.Drawing.Color.Orange;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelWelcome.Location = new System.Drawing.Point(-57, 117);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(274, 163);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome\nto the app\nMarket";
            this.labelWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWelcome.Click += new System.EventHandler(this.labelWelcome_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(-1, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "The project is done: Barbos Dan B-2231";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Orange;
            this.pictureBox1.Image = global::st.ind2.Properties.Resources.logo__1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.Orange;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(-137, -14);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(373, 424);
            this.guna2CirclePictureBox1.TabIndex = 11;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.linkClear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private PictureBox pictureBox1;
    }
}
