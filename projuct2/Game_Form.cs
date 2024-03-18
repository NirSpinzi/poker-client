using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projuct2
{
    public partial class Game_Form : Form
    {
        string username;
        string PicturePath = @"D:\\projects\\poker-client\\projuct2\\picFolder\\";
        /*public Game_Form()
        {
            InitializeComponent();
            Tikshoret.BeginRead();
            Tikshoret.SendMessage("isHost");
        }*/
        public Game_Form(string Nick)
        {
            InitializeComponent();
            Tikshoret.BeginRead();
            Tikshoret.SendMessage("isHost");
            username = Nick;
            Your_Name_label.Text = Nick;
        }
        public void IsHost(string info)
        {
            if (!info.Equals("true"))
            {
                start_game_button.Visible = false;
                start_game_button.Enabled = false;
            }
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
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:2");
                else
                Player2Name.Text = parts[2];
            }
            else if (parts[1].Equals("3"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:3");
                else
                    Player3Name.Text = parts[2];
            }
            else if (parts[1].Equals("4"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:4");
                else
                    Player4Name.Text = parts[2];
            }
            else if (parts[1].Equals("5"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:5");
                else
                    Player5Name.Text = parts[2];
            }
            else if (parts[1].Equals("6"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:6");
                else
                    Player6Name.Text = parts[2];
            }
            else if (parts[1].Equals("7"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:7");
                else
                    Player7Name.Text = parts[2];
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
                MainCard1.Image = Image.FromFile(PicturePath + "card." + parts[3] + "." + parts[4] + ".jpg");
                MainCard2.Image = Image.FromFile(PicturePath + "card." + parts[5] + "." + parts[6] + ".jpg");
            }
            else MessageBox.Show("You need at least 2 players to start a game");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
