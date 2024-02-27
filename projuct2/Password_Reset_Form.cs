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
    public partial class Password_Reset_Form : Form
    {
        public Password_Reset_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        private void confirm_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:"+email_password_reset_box.Text);
        }
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
                }
                else MessageBox.Show("The code you entered is incorrect");
            }
            else if (parts[1].Equals("successful"))
            {
                MessageBox.Show("Reset successful");
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.login = new Login_Form();
                this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
            }
            else MessageBox.Show("An eror has occurred. Please try again later");
        }

        private void email_code_confirmation_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:vercode:" + email_code_textbox.Text);
        }

        private void confirm_new_password_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("reset:password:"+ password_reset_box.Text);
        }
    }
}
