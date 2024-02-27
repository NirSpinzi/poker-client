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
            Tikshoret.email = new Email_Ver_Form();
            this.Invoke(new Action(() => Tikshoret.email.ShowDialog()));
        }

        private void username_box2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Receives a messege from the server and acts in accordance to the messege that was received.
        /// </summary>
        /// <param name="ar"></param>
        /*private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string incommingData = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    MessageBox.Show(incommingData);
                }

                // continue reading
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }// end ReceiveMessage
        /// <summary>
        /// convert the message to ASCII code send message to the server
        /// </summary>
        /// <param name="message">the data to send</param>
        private void SendMessage(string message)
        {
            try
            {
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                //ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Reads a message from the server using the established TCP connection.
        /// </summary>
        /// <returns>The message received from the server as a string.</returns>
        private string ReadMessage()
        {
            try
            {
                // Define a buffer to hold the incoming data
                byte[] bytesFrom = new byte[1024];
                // Get the network stream from the TCP client
                NetworkStream ns = client.GetStream();
                // Read the incoming data into the buffer
                ns.Read(bytesFrom, 0, 32);
                // Convert the incoming data into a string
                string dataFromServer = Encoding.ASCII.GetString(bytesFrom);

                return (dataFromServer);
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs
                MessageBox.Show(ex.ToString());
                return "error";
            }
        }*/
    }
}
