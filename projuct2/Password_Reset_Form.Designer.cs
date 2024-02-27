namespace projuct2
{
    partial class Password_Reset_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.email_password_reset_box = new System.Windows.Forms.TextBox();
            this.confirm_button = new System.Windows.Forms.Button();
            this.email_verify_label = new System.Windows.Forms.Label();
            this.email_code_textbox = new System.Windows.Forms.TextBox();
            this.email_code_confirmation_button = new System.Windows.Forms.Button();
            this.reset_password_label = new System.Windows.Forms.Label();
            this.password_reset_box = new System.Windows.Forms.TextBox();
            this.confirm_new_password_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(111, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter your email so we can verify your account.";
            // 
            // email_password_reset_box
            // 
            this.email_password_reset_box.Location = new System.Drawing.Point(166, 76);
            this.email_password_reset_box.Name = "email_password_reset_box";
            this.email_password_reset_box.Size = new System.Drawing.Size(185, 20);
            this.email_password_reset_box.TabIndex = 1;
            // 
            // confirm_button
            // 
            this.confirm_button.Location = new System.Drawing.Point(377, 76);
            this.confirm_button.Name = "confirm_button";
            this.confirm_button.Size = new System.Drawing.Size(75, 23);
            this.confirm_button.TabIndex = 2;
            this.confirm_button.Text = "confirm";
            this.confirm_button.UseVisualStyleBackColor = true;
            this.confirm_button.Click += new System.EventHandler(this.confirm_button_Click);
            // 
            // email_verify_label
            // 
            this.email_verify_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.email_verify_label.Location = new System.Drawing.Point(111, 115);
            this.email_verify_label.Name = "email_verify_label";
            this.email_verify_label.Size = new System.Drawing.Size(299, 75);
            this.email_verify_label.TabIndex = 4;
            this.email_verify_label.Text = "We have sent an email with a verification code to your address. pleas enter the c" +
    "ode ";
            this.email_verify_label.Visible = false;
            // 
            // email_code_textbox
            // 
            this.email_code_textbox.Location = new System.Drawing.Point(166, 193);
            this.email_code_textbox.Name = "email_code_textbox";
            this.email_code_textbox.Size = new System.Drawing.Size(185, 20);
            this.email_code_textbox.TabIndex = 5;
            this.email_code_textbox.Visible = false;
            // 
            // email_code_confirmation_button
            // 
            this.email_code_confirmation_button.Location = new System.Drawing.Point(377, 190);
            this.email_code_confirmation_button.Name = "email_code_confirmation_button";
            this.email_code_confirmation_button.Size = new System.Drawing.Size(75, 23);
            this.email_code_confirmation_button.TabIndex = 6;
            this.email_code_confirmation_button.Text = "confirm";
            this.email_code_confirmation_button.UseVisualStyleBackColor = true;
            this.email_code_confirmation_button.Visible = false;
            this.email_code_confirmation_button.Click += new System.EventHandler(this.email_code_confirmation_button_Click);
            // 
            // reset_password_label
            // 
            this.reset_password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.reset_password_label.Location = new System.Drawing.Point(111, 234);
            this.reset_password_label.Name = "reset_password_label";
            this.reset_password_label.Size = new System.Drawing.Size(299, 64);
            this.reset_password_label.TabIndex = 7;
            this.reset_password_label.Text = "Enter your new password in the box bellow.";
            this.reset_password_label.Visible = false;
            // 
            // password_reset_box
            // 
            this.password_reset_box.Location = new System.Drawing.Point(166, 301);
            this.password_reset_box.Name = "password_reset_box";
            this.password_reset_box.Size = new System.Drawing.Size(185, 20);
            this.password_reset_box.TabIndex = 8;
            this.password_reset_box.Visible = false;
            // 
            // confirm_new_password_button
            // 
            this.confirm_new_password_button.Location = new System.Drawing.Point(377, 298);
            this.confirm_new_password_button.Name = "confirm_new_password_button";
            this.confirm_new_password_button.Size = new System.Drawing.Size(75, 23);
            this.confirm_new_password_button.TabIndex = 9;
            this.confirm_new_password_button.Text = "confirm";
            this.confirm_new_password_button.UseVisualStyleBackColor = true;
            this.confirm_new_password_button.Visible = false;
            this.confirm_new_password_button.Click += new System.EventHandler(this.confirm_new_password_button_Click);
            // 
            // Password_Reset_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 405);
            this.Controls.Add(this.confirm_new_password_button);
            this.Controls.Add(this.password_reset_box);
            this.Controls.Add(this.reset_password_label);
            this.Controls.Add(this.email_code_confirmation_button);
            this.Controls.Add(this.email_code_textbox);
            this.Controls.Add(this.email_verify_label);
            this.Controls.Add(this.confirm_button);
            this.Controls.Add(this.email_password_reset_box);
            this.Controls.Add(this.label1);
            this.Name = "Password_Reset_Form";
            this.Text = "Password_Reset_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox email_password_reset_box;
        private System.Windows.Forms.Button confirm_button;
        private System.Windows.Forms.Label email_verify_label;
        private System.Windows.Forms.TextBox email_code_textbox;
        private System.Windows.Forms.Button email_code_confirmation_button;
        private System.Windows.Forms.Label reset_password_label;
        private System.Windows.Forms.TextBox password_reset_box;
        private System.Windows.Forms.Button confirm_new_password_button;
    }
}