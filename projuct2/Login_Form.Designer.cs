namespace projuct2
{
    partial class Login_Form
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
            this.Login_label = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.username_box = new System.Windows.Forms.TextBox();
            this.password_box = new System.Windows.Forms.TextBox();
            this.Login_button = new System.Windows.Forms.Button();
            this.sign_up_here_label = new System.Windows.Forms.Label();
            this.Regist_button_1 = new System.Windows.Forms.Button();
            this.Capthca_checkbox = new System.Windows.Forms.CheckBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.CaptchaImageBox = new System.Windows.Forms.PictureBox();
            this.cooldown = new System.Windows.Forms.Timer(this.components);
            this.cooldownBox = new System.Windows.Forms.Label();
            this.ForgotPasswordButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_label
            // 
            this.Login_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Login_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Login_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Login_label.Location = new System.Drawing.Point(413, 40);
            this.Login_label.MaximumSize = new System.Drawing.Size(500, 500);
            this.Login_label.Name = "Login_label";
            this.Login_label.Size = new System.Drawing.Size(200, 90);
            this.Login_label.TabIndex = 1;
            this.Login_label.Text = "Login";
            // 
            // label_username
            // 
            this.label_username.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_username.Location = new System.Drawing.Point(74, 206);
            this.label_username.MaximumSize = new System.Drawing.Size(500, 500);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(150, 38);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username:";
            // 
            // label_password
            // 
            this.label_password.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_password.Location = new System.Drawing.Point(74, 284);
            this.label_password.MaximumSize = new System.Drawing.Size(500, 500);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(150, 38);
            this.label_password.TabIndex = 4;
            this.label_password.Text = "Password:";
            // 
            // username_box
            // 
            this.username_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.username_box.Location = new System.Drawing.Point(267, 206);
            this.username_box.Multiline = true;
            this.username_box.Name = "username_box";
            this.username_box.Size = new System.Drawing.Size(144, 38);
            this.username_box.TabIndex = 6;
            this.username_box.TextChanged += new System.EventHandler(this.username_box_TextChanged);
            // 
            // password_box
            // 
            this.password_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.password_box.Location = new System.Drawing.Point(267, 284);
            this.password_box.Multiline = true;
            this.password_box.Name = "password_box";
            this.password_box.Size = new System.Drawing.Size(144, 38);
            this.password_box.TabIndex = 7;
            this.password_box.TextChanged += new System.EventHandler(this.password_box_TextChanged);
            // 
            // Login_button
            // 
            this.Login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Login_button.Location = new System.Drawing.Point(439, 242);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(106, 54);
            this.Login_button.TabIndex = 9;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // sign_up_here_label
            // 
            this.sign_up_here_label.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sign_up_here_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.sign_up_here_label.Location = new System.Drawing.Point(181, 550);
            this.sign_up_here_label.MaximumSize = new System.Drawing.Size(500, 500);
            this.sign_up_here_label.Name = "sign_up_here_label";
            this.sign_up_here_label.Size = new System.Drawing.Size(214, 25);
            this.sign_up_here_label.TabIndex = 10;
            this.sign_up_here_label.Text = "Not registered? Sign up here ->";
            // 
            // Regist_button_1
            // 
            this.Regist_button_1.Location = new System.Drawing.Point(439, 550);
            this.Regist_button_1.Name = "Regist_button_1";
            this.Regist_button_1.Size = new System.Drawing.Size(106, 25);
            this.Regist_button_1.TabIndex = 11;
            this.Regist_button_1.Text = "Sign up";
            this.Regist_button_1.UseVisualStyleBackColor = true;
            this.Regist_button_1.Click += new System.EventHandler(this.Regist_button_1_Click);
            // 
            // Capthca_checkbox
            // 
            this.Capthca_checkbox.Location = new System.Drawing.Point(697, 179);
            this.Capthca_checkbox.Name = "Capthca_checkbox";
            this.Capthca_checkbox.Size = new System.Drawing.Size(212, 65);
            this.Capthca_checkbox.TabIndex = 13;
            this.Capthca_checkbox.Text = "i\'m not a robot";
            this.Capthca_checkbox.UseVisualStyleBackColor = true;
            this.Capthca_checkbox.CheckedChanged += new System.EventHandler(this.Capthca_checkbox_CheckedChanged);
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CaptchaTextBox.Location = new System.Drawing.Point(765, 368);
            this.CaptchaTextBox.Multiline = true;
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(144, 38);
            this.CaptchaTextBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(630, 377);
            this.label1.MaximumSize = new System.Drawing.Size(500, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "Enter word here:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(829, 179);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(80, 65);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 19;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // CaptchaImageBox
            // 
            this.CaptchaImageBox.Location = new System.Drawing.Point(697, 262);
            this.CaptchaImageBox.Name = "CaptchaImageBox";
            this.CaptchaImageBox.Size = new System.Drawing.Size(212, 80);
            this.CaptchaImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptchaImageBox.TabIndex = 14;
            this.CaptchaImageBox.TabStop = false;
            this.CaptchaImageBox.Click += new System.EventHandler(this.CaptchaImageBox_Click);
            // 
            // cooldown
            // 
            this.cooldown.Enabled = true;
            this.cooldown.Interval = 1000;
            this.cooldown.Tick += new System.EventHandler(this.cooldown_Tick);
            // 
            // cooldownBox
            // 
            this.cooldownBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cooldownBox.Location = new System.Drawing.Point(551, 255);
            this.cooldownBox.Name = "cooldownBox";
            this.cooldownBox.Size = new System.Drawing.Size(29, 30);
            this.cooldownBox.TabIndex = 22;
            // 
            // ForgotPasswordButton
            // 
            this.ForgotPasswordButton.Location = new System.Drawing.Point(184, 368);
            this.ForgotPasswordButton.Name = "ForgotPasswordButton";
            this.ForgotPasswordButton.Size = new System.Drawing.Size(110, 23);
            this.ForgotPasswordButton.TabIndex = 23;
            this.ForgotPasswordButton.Text = "Forgot my password";
            this.ForgotPasswordButton.UseVisualStyleBackColor = true;
            this.ForgotPasswordButton.Click += new System.EventHandler(this.ForgotPasswordButton_Click);
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 630);
            this.Controls.Add(this.ForgotPasswordButton);
            this.Controls.Add(this.cooldownBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.CaptchaImageBox);
            this.Controls.Add(this.Capthca_checkbox);
            this.Controls.Add(this.Regist_button_1);
            this.Controls.Add(this.sign_up_here_label);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.password_box);
            this.Controls.Add(this.username_box);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.Login_label);
            this.Name = "Login_Form";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login_label;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox username_box;
        private System.Windows.Forms.TextBox password_box;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Label sign_up_here_label;
        private System.Windows.Forms.Button Regist_button_1;
        private System.Windows.Forms.CheckBox Capthca_checkbox;
        private System.Windows.Forms.PictureBox CaptchaImageBox;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer cooldown;
        private System.Windows.Forms.Label cooldownBox;
        private System.Windows.Forms.Button ForgotPasswordButton;
    }
}

