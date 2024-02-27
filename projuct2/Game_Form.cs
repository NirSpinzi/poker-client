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
    public partial class Game_Form : Form
    {
        public Game_Form()
        {
            InitializeComponent();
            Tikshoret.SendMessage("isHost");
            //if (isHost())
            //    start_game_button.Visible = true;
        }
        /*private bool isHost()
        {
            Tikshoret.SendMessage("isHost");
            if (ReadMessage().Equals("true"))
                return true;
            else return false;
        }
        private string ReadMessage()
        {
            try
            {
                // Define a buffer to hold the incoming data
                byte[] bytesFrom = new byte[1024];
                // Get the network stream from the TCP client
                NetworkStream ns = Tikshoret.client.GetStream();
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
        public void IsHost(string info)
        {
            if (!info.Equals("true"))
                start_game_button.Visible = false;
        }
        private void poker_hands_button_Click(object sender, EventArgs e)
        {
            Form form= new poker_hands_form();
            form.Show();
        }

        private void start_game_button_Click(object sender, EventArgs e)
        {
                Tikshoret.SendMessage("game:start");
        }
        public void startGame(string info)
        {
            string[] parts = info.Split(':');
            if (parts[2].Equals("ok"))
            {
                
            }
            else MessageBox.Show("You need at least 2 players to start a game");
        }
    }
}
