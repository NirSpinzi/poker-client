using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the registration form in the application.
    /// </summary>
    public partial class Regist_Form : Form
    {
        /// <summary>
        /// Initializes a new instance of the Regist_Form class. Starts listening to messeges from the server.
        /// </summary>
        public Regist_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        /// <summary>
        /// Sends the server the registration details of the user - Regist reqeust.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registar2_button_Click(object sender, EventArgs e)
        {
            // Retrieve the entered username and password
            string username = username_box2.Text;
            string password = password_box2.Text;
            string email = email_box2.Text;
            // Send a registration request message to the server with the entered username and password
            Tikshoret.SendMessage("regist:" + username + ":" + password + ":" + email);
        }
        /// <summary>
        /// Handels the regist request answer of the server.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void RegistRequest(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("username_taken"))
            {
                // Display a message to the user that the entered username is already taken
                MessageBox.Show("There is already an account with that username");
            }
            else if (parts[1].Equals("password_taken"))
            {
                // Display a message to the user that the entered password is already taken
                MessageBox.Show("There is already an account with that password");
            }
            else if (parts[1].StartsWith("email"))
            {
                // Display a message to the user that the entered email is not valid
                MessageBox.Show("The email address is not valid");
            }
            else
            {
                if (parts[1].Equals("ok"))
                {
                    Hide();
                    Tikshoret.email = new Email_Ver_Form(); // Transfer user to email validation form.
                    this.Invoke(new Action(() => Tikshoret.email.ShowDialog()));
                    Close();
                }
                else
                    // Display an error message to the user with the server's response message
                    MessageBox.Show(parts[1]);
            }
        }
        private void username_box2_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Returns the user back to the login form. Closes Regist Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Picture_Button_Click(object sender, EventArgs e)
        {
            Hide();
            Tikshoret.login = new Login_Form();
            this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
            Close();
        }
    }
}
