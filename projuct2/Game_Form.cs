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
        public Game_Form(string Nick)
        {
            InitializeComponent();
            Tikshoret.SendMessage("isHost");
            Your_Name_label.Text = Nick;
            //if (isHost())
            //    start_game_button.Visible = true;
        }
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
        public void JoinGame(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("2"))
            {
                Player2Name.Text = parts[2];
            }
            else if (parts[1].Equals("3"))
            {

            }
            else if (parts[1].Equals("4"))
            {

            }
            else if (parts[1].Equals("5"))
            {

            }
            else if (parts[1].Equals("6"))
            {

            }
            else if (parts[1].Equals("7"))
            {

            }
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
