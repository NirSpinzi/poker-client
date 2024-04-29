using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace projuct2
{
    public partial class Regist_Form : Form
    {
        TcpClient client;//client Socket
        byte[] data;//store the data that send to & from the server
        /// <summary>
        /// Initializes a new instance of the Form2 class with a pre-existing TcpClient object.
        /// </summary>
        /// <param name="Client">The TcpClient object representing the client socket.</param>
        public Regist_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        private void registar2_button_Click(object sender, EventArgs e)
        {
            // Retrieve the entered username and password
            string username = username_box2.Text;
            string password = password_box2.Text;
            string email = email_box2.Text;
            // Send a registration request message to the server with the entered username and password
            Tikshoret.SendMessage("regist:" + username + ":" + password + ":" + email);
        }
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
                    // Create a new instance of Form1 and display it to the user
                    Hide();
                    // Create a new instance of Form2 and pass the client object to it.
                    Tikshoret.email = new Email_Ver_Form();
                    this.Invoke(new Action(() => Tikshoret.email.ShowDialog()));
                }
                else
                    // Display an error message to the user with the server's response message
                    MessageBox.Show(parts[1]);
            }
        }
        private void back_button_Click(object sender, EventArgs e)
        {
            // Create a new instance of Form1 and display it to the user
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.login = new Login_Form();
            this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
        }

        private void username_box2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
