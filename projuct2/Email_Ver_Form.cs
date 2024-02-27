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
    public partial class Email_Ver_Form : Form
    {
        TcpClient client;//client Socket
        byte[] data;//store the data that send to & from the server
        /// <summary>
        /// Initializes a new instance of the Form2 class with a pre-existing TcpClient object.
        /// </summary>
        /// <param name="Client">The TcpClient object representing the client socket.</param>
        public Email_Ver_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Ver_Code_Button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("vercode:"+Ver_Code_Box.Text+":");
        }
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
                    //MessageBox.Show(incommingData);
                    if (incommingData.StartsWith("vercode:ok"))
                    {
                        Form form1 = new Login_Form(client);
                        Hide();
                        form1.Show();
                    }
                    else MessageBox.Show("The code you entered is incorrect");
                }
                // continue reading
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }// end ReceiveMessage*/
        /// <summary>
        /// convert the message to ASCII code send message to the server
        /// </summary>
        /// <param name="message">the data to send</param>
        public void VerifyCode(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("ok"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.login = new Login_Form();
                this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
            }
            else MessageBox.Show("The code you entered is incorrect");
        }
        /*private void SendMessage(string message)
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
        }*/
    }
}
