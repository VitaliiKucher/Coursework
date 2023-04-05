
namespace Успішність
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelAutorization = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.passField = new System.Windows.Forms.TextBox();
            this.loginField = new System.Windows.Forms.TextBox();
            this.AutorizationlinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBoxvisible = new System.Windows.Forms.PictureBox();
            this.pictureAutorization = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxvisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutorization)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.Transparent;
            this.buttonRegister.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegister.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRegister.Location = new System.Drawing.Point(92, 263);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(262, 39);
            this.buttonRegister.TabIndex = 13;
            this.buttonRegister.Text = "Зареєструватися";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            this.buttonRegister.MouseEnter += new System.EventHandler(this.buttonRegister_MouseEnter);
            // 
            // labelAutorization
            // 
            this.labelAutorization.AutoSize = true;
            this.labelAutorization.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAutorization.Location = new System.Drawing.Point(146, 70);
            this.labelAutorization.Name = "labelAutorization";
            this.labelAutorization.Size = new System.Drawing.Size(141, 33);
            this.labelAutorization.TabIndex = 12;
            this.labelAutorization.Text = "Реєстрація";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(22, 213);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(109, 33);
            this.labelPassword.TabIndex = 11;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(40, 159);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(89, 33);
            this.labelLogin.TabIndex = 10;
            this.labelLogin.Text = "Логін:";
            // 
            // passField
            // 
            this.passField.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.passField.Location = new System.Drawing.Point(137, 214);
            this.passField.Name = "passField";
            this.passField.Size = new System.Drawing.Size(188, 32);
            this.passField.TabIndex = 8;
            this.passField.Enter += new System.EventHandler(this.passField_Enter);
            this.passField.Leave += new System.EventHandler(this.passField_Leave);
            // 
            // loginField
            // 
            this.loginField.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.loginField.Location = new System.Drawing.Point(137, 160);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(188, 32);
            this.loginField.TabIndex = 7;
            this.loginField.Enter += new System.EventHandler(this.loginField_Enter);
            this.loginField.Leave += new System.EventHandler(this.loginField_Leave);
            // 
            // AutorizationlinkLabel
            // 
            this.AutorizationlinkLabel.AutoSize = true;
            this.AutorizationlinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutorizationlinkLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.AutorizationlinkLabel.Location = new System.Drawing.Point(272, 332);
            this.AutorizationlinkLabel.Name = "AutorizationlinkLabel";
            this.AutorizationlinkLabel.Size = new System.Drawing.Size(114, 17);
            this.AutorizationlinkLabel.TabIndex = 14;
            this.AutorizationlinkLabel.TabStop = true;
            this.AutorizationlinkLabel.Text = "Авторизуватися";
            this.AutorizationlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AutorizationlinkLabel_LinkClicked);
            this.AutorizationlinkLabel.MouseEnter += new System.EventHandler(this.AutorizationlinkLabel_MouseEnter);
            // 
            // pictureBoxvisible
            // 
            this.pictureBoxvisible.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxvisible.Image")));
            this.pictureBoxvisible.Location = new System.Drawing.Point(331, 213);
            this.pictureBoxvisible.Name = "pictureBoxvisible";
            this.pictureBoxvisible.Size = new System.Drawing.Size(52, 33);
            this.pictureBoxvisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxvisible.TabIndex = 0;
            this.pictureBoxvisible.TabStop = false;
            this.pictureBoxvisible.Click += new System.EventHandler(this.pictureBoxvisible_Click);
            this.pictureBoxvisible.MouseEnter += new System.EventHandler(this.pictureBoxvisible_MouseEnter);
            // 
            // pictureAutorization
            // 
            this.pictureAutorization.Image = ((System.Drawing.Image)(resources.GetObject("pictureAutorization.Image")));
            this.pictureAutorization.Location = new System.Drawing.Point(150, 13);
            this.pictureAutorization.Name = "pictureAutorization";
            this.pictureAutorization.Size = new System.Drawing.Size(135, 54);
            this.pictureAutorization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAutorization.TabIndex = 15;
            this.pictureAutorization.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 358);
            this.Controls.Add(this.pictureBoxvisible);
            this.Controls.Add(this.AutorizationlinkLabel);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.labelAutorization);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.pictureAutorization);
            this.Controls.Add(this.passField);
            this.Controls.Add(this.loginField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(343, 393);
            this.Name = "RegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вікно реєстрації";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxvisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutorization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelAutorization;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.PictureBox pictureAutorization;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.LinkLabel AutorizationlinkLabel;
        private System.Windows.Forms.PictureBox pictureBoxvisible;
    }
}