
namespace Успішність
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginField = new System.Windows.Forms.TextBox();
            this.passField = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAutorization = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.RegisterlinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBoxvisible = new System.Windows.Forms.PictureBox();
            this.pictureAutorization = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxvisible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutorization)).BeginInit();
            this.SuspendLayout();
            // 
            // loginField
            // 
            this.loginField.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.loginField.Location = new System.Drawing.Point(127, 151);
            this.loginField.Name = "loginField";
            this.loginField.Size = new System.Drawing.Size(172, 32);
            this.loginField.TabIndex = 0;
            this.loginField.Enter += new System.EventHandler(this.loginField_Enter);
            this.loginField.Leave += new System.EventHandler(this.loginField_Leave);
            // 
            // passField
            // 
            this.passField.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.passField.Location = new System.Drawing.Point(127, 201);
            this.passField.Name = "passField";
            this.passField.Size = new System.Drawing.Size(172, 32);
            this.passField.TabIndex = 1;
            this.passField.Enter += new System.EventHandler(this.passField_Enter);
            this.passField.Leave += new System.EventHandler(this.passField_Leave);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin.Location = new System.Drawing.Point(30, 150);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(89, 33);
            this.labelLogin.TabIndex = 3;
            this.labelLogin.Text = "Логін:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(12, 200);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(109, 33);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Пароль:";
            // 
            // labelAutorization
            // 
            this.labelAutorization.AutoSize = true;
            this.labelAutorization.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAutorization.Location = new System.Drawing.Point(104, 56);
            this.labelAutorization.Name = "labelAutorization";
            this.labelAutorization.Size = new System.Drawing.Size(160, 33);
            this.labelAutorization.TabIndex = 5;
            this.labelAutorization.Text = "Авторизація";
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLogin.Location = new System.Drawing.Point(110, 264);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(154, 39);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Увійти";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.MouseEnter += new System.EventHandler(this.buttonLogin_MouseEnter);
            // 
            // RegisterlinkLabel
            // 
            this.RegisterlinkLabel.AutoSize = true;
            this.RegisterlinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterlinkLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.RegisterlinkLabel.Location = new System.Drawing.Point(220, 319);
            this.RegisterlinkLabel.Name = "RegisterlinkLabel";
            this.RegisterlinkLabel.Size = new System.Drawing.Size(126, 17);
            this.RegisterlinkLabel.TabIndex = 8;
            this.RegisterlinkLabel.TabStop = true;
            this.RegisterlinkLabel.Text = "Створити аккаунт";
            this.RegisterlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegister_LinkClicked);
            this.RegisterlinkLabel.MouseEnter += new System.EventHandler(this.RegisterlinkLabel_MouseEnter);
            // 
            // pictureBoxvisible
            // 
            this.pictureBoxvisible.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxvisible.Image")));
            this.pictureBoxvisible.Location = new System.Drawing.Point(305, 195);
            this.pictureBoxvisible.Name = "pictureBoxvisible";
            this.pictureBoxvisible.Size = new System.Drawing.Size(52, 44);
            this.pictureBoxvisible.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxvisible.TabIndex = 0;
            this.pictureBoxvisible.TabStop = false;
            this.pictureBoxvisible.Click += new System.EventHandler(this.pictureBoxvisible_Click);
            this.pictureBoxvisible.MouseEnter += new System.EventHandler(this.pictureBoxvisible_MouseEnter);
            // 
            // pictureAutorization
            // 
            this.pictureAutorization.Image = ((System.Drawing.Image)(resources.GetObject("pictureAutorization.Image")));
            this.pictureAutorization.Location = new System.Drawing.Point(110, 3);
            this.pictureAutorization.Name = "pictureAutorization";
            this.pictureAutorization.Size = new System.Drawing.Size(154, 50);
            this.pictureAutorization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureAutorization.TabIndex = 9;
            this.pictureAutorization.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(358, 345);
            this.Controls.Add(this.pictureBoxvisible);
            this.Controls.Add(this.RegisterlinkLabel);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelAutorization);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.pictureAutorization);
            this.Controls.Add(this.passField);
            this.Controls.Add(this.loginField);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(317, 380);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вікно авторизації";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxvisible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAutorization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginField;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.PictureBox pictureAutorization;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelAutorization;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.LinkLabel RegisterlinkLabel;
        private System.Windows.Forms.PictureBox pictureBoxvisible;
    }
}

