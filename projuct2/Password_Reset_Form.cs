using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the password reset form in the application.
    /// </summary>
    public partial class Password_Reset_Form : Form
    {
        /// <summary>
        /// Initializes a new instance of the Password_Reset_Form class and starts listening to messages from the server.
        /// </summary>
        public Password_Reset_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        /// <summary>
        /// Sends the inserted email to the server - Email exist reqeust.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_Email_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:" + email_password_reset_box.Text);
        }
        /// <summary>
        /// Handles the server answers to the Email exist reqeust, Email code verification reqeust and the password reset reqeust.
        /// </summary>
        /// <param name="info">Server's answers</param>
        public void PasswordReseter(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("email"))
            {
                if (parts[2].Equals("verify"))
                {
                    email_verify_label.Visible = true;
                    email_code_textbox.Visible = true;
                    email_code_confirmation_button.Visible = true;
                }
                else
                {
                    MessageBox.Show("Email does not exist");
                }
            }
            else if (parts[1].Equals("vercode"))
            {
                if (parts[2].Equals("ok"))
                {
                    reset_password_label.Visible = true;
                    password_reset_box.Visible = true;
                    confirm_new_password_button.Visible = true;
                    PasswordRequirementsLabel.Visible = true;
                }
                else MessageBox.Show("The code you entered is incorrect");
            }
            else if (parts[1].Equals("successful"))
            {
                MessageBox.Show("Reset successful");
                Hide();
                Tikshoret.login = new Login_Form(); // closes current form, transfers the user back to the login form.
                this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
                Close();
            }
            else MessageBox.Show("Password does not meet the requirements.");
        }
        /// <summary>
        /// Sends the server the code - email code verification reqeust.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void email_code_confirmation_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:vercode:" + email_code_textbox.Text);
        }
        /// <summary>
        /// Sends the server the new password - password reset reqeust.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirm_new_password_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:password:"+ password_reset_box.Text);
        }
    }
}
