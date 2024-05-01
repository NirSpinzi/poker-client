using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the email verification form in the application.
    /// </summary>
    public partial class Email_Ver_Form : Form
    {
        /// <summary>
        /// Initializes a new instance of the Email_Ver_Form class and starts listening to messages from the server.
        /// </summary>
        public Email_Ver_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sends the server the inserted code - email verification request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ver_Code_Button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("vercode:"+Ver_Code_Box.Text+":");
        }
        /// <summary>
        /// Handels the email vierification reqeust answer.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void VerifyCode(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("ok"))
            {
                Hide();
                Tikshoret.login = new Login_Form(); // transfers user back to the login form. closes current form.
                this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
                Close();
            }
            else MessageBox.Show("The code you entered is incorrect");
        }
    }
}
