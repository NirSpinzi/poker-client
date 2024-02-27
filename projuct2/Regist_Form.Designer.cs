namespace projuct2
{
    partial class Regist_Form
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_email = new System.Windows.Forms.Label();
            this.username_box2 = new System.Windows.Forms.TextBox();
            this.password_box2 = new System.Windows.Forms.TextBox();
            this.email_box2 = new System.Windows.Forms.TextBox();
            this.registar2_button = new System.Windows.Forms.Button();
            this.back_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(363, 32);
            this.label1.MaximumSize = new System.Drawing.Size(500, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 90);
            this.label1.TabIndex = 2;
            this.label1.Text = "Register";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(213, 232);
            this.label3.MaximumSize = new System.Drawing.Size(500, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(213, 309);
            this.label2.MaximumSize = new System.Drawing.Size(500, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password:";
            // 
            // label_email
            // 
            this.label_email.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_email.Location = new System.Drawing.Point(213, 384);
            this.label_email.MaximumSize = new System.Drawing.Size(500, 500);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(150, 38);
            this.label_email.TabIndex = 6;
            this.label_email.Text = "Email:";
            // 
            // username_box2
            // 
            this.username_box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.username_box2.Location = new System.Drawing.Point(408, 232);
            this.username_box2.Multiline = true;
            this.username_box2.Name = "username_box2";
            this.username_box2.Size = new System.Drawing.Size(144, 38);
            this.username_box2.TabIndex = 7;
            this.username_box2.TextChanged += new System.EventHandler(this.username_box2_TextChanged);
            // 
            // password_box2
            // 
            this.password_box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.password_box2.Location = new System.Drawing.Point(408, 309);
            this.password_box2.Multiline = true;
            this.password_box2.Name = "password_box2";
            this.password_box2.Size = new System.Drawing.Size(144, 38);
            this.password_box2.TabIndex = 8;
            // 
            // email_box2
            // 
            this.email_box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.email_box2.Location = new System.Drawing.Point(408, 384);
            this.email_box2.Multiline = true;
            this.email_box2.Name = "email_box2";
            this.email_box2.Size = new System.Drawing.Size(144, 38);
            this.email_box2.TabIndex = 9;
            // 
            // registar2_button
            // 
            this.registar2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.registar2_button.Location = new System.Drawing.Point(598, 309);
            this.registar2_button.Name = "registar2_button";
            this.registar2_button.Size = new System.Drawing.Size(133, 38);
            this.registar2_button.TabIndex = 10;
            this.registar2_button.Text = "Register";
            this.registar2_button.UseVisualStyleBackColor = true;
            this.registar2_button.Click += new System.EventHandler(this.registar2_button_Click);
            // 
            // back_button
            // 
            this.back_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            //this.back_button.Image = global::projuct2.Properties.Resources.Back_arrow;
            this.back_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.back_button.Location = new System.Drawing.Point(12, 12);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(44, 44);
            this.back_button.TabIndex = 11;
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // Regist_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 626);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.registar2_button);
            this.Controls.Add(this.email_box2);
            this.Controls.Add(this.password_box2);
            this.Controls.Add(this.username_box2);
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Regist_Form";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_email;
        private System.Windows.Forms.TextBox username_box2;
        private System.Windows.Forms.TextBox password_box2;
        private System.Windows.Forms.TextBox email_box2;
        private System.Windows.Forms.Button registar2_button;
        private System.Windows.Forms.Button back_button;
    }
}