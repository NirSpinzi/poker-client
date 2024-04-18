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
        public Game_Form(string info)
        {
            string[] parts = info.Split(':');
            InitializeComponent();
            TableBetLabel.Parent = PokerTable;
            Player1Bet.Parent = PokerTable;
            Player2Bet.Parent = PokerTable;
            Player3Bet.Parent = PokerTable;
            Player4Bet.Parent = PokerTable;
            Player5Bet.Parent = PokerTable;
            Player6Bet.Parent = PokerTable;
            Player7Bet.Parent = PokerTable;
            WinnerAnnouncementLabel.Parent = PokerTable;
            Tikshoret.BeginRead();
            Tikshoret.SendMessage("isHost");
            username = parts[0];
            Your_Name_label.Text = parts[0];
            Player1Money.Text = parts[1] + "$";
        }
        public void IsHost(string info)
        {
            if (info.Equals("true"))
            {
                start_game_button.Visible = true;
                start_game_button.Enabled = true;
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
                {
                    Player2Name.Text = parts[2];
                    Player2Money.Text = parts[3] + "$";
                    Player2Money.Visible = true;
                }
            }
            else if (parts[1].Equals("3"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:3");
                else
                {
                    Player3Name.Text = parts[2];
                    Player3Money.Text = parts[3] + "$";
                    Player3Money.Visible = true;
                }
            }
            else if (parts[1].Equals("4"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:4");
                else
                {
                    Player4Name.Text = parts[2];
                    Player4Money.Text = parts[3] + "$";
                    Player4Money.Visible = true;
                }
            }
            else if (parts[1].Equals("5"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:5");
                else
                {
                    Player5Name.Text = parts[2];
                    Player5Money.Text = parts[3] + "$";
                    Player5Money.Visible = true;
                }
            }
            else if (parts[1].Equals("6"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:6");
                else
                {
                    Player6Name.Text = parts[2];
                    Player6Money.Text = parts[3] + "$";
                    Player6Money.Visible = true;
                }
            }
            else if (parts[1].Equals("7"))
            {
                if (parts[2].Equals(username))
                    Tikshoret.SendMessage("table:names:7");
                else
                {
                    Player7Name.Text = parts[2];
                    Player7Money.Text = parts[3] + "$";
                    Player7Money.Visible = true;
                }
            }
        }
        private void start_game_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("game:start");
            TableBetLabel.Visible= true;
        }
        public void startGame(string info)
        {
            string[] parts = info.Split(':');
            if (parts[2].Equals("ok"))
            {
                TableBetLabel.Visible= true;
                start_game_button.Enabled = false;
                MainCard1.Image = Image.FromFile(PicturePath + "card." + parts[3] + "." + parts[4] + ".jpg");
                MainCard2.Image = Image.FromFile(PicturePath + "card." + parts[5] + "." + parts[6] + ".jpg");
                MainCard1.Visible= true;
                MainCard2.Visible= true;
                Player2Card1.Visible= true;
                Player2Card2.Visible= true;
                if(Player3Money.Visible)
                {
                    Player3Card1.Visible= true;
                    Player3Card2.Visible= true;
                }
                if(Player4Money.Visible)
                {
                    Player4Card1.Visible= true;
                    Player4Card2.Visible= true;
                }
                if (Player5Money.Visible)
                {
                    Player5Card1.Visible = true;
                    Player5Card2.Visible = true;
                }
                if (Player6Money.Visible)
                {
                    Player6Card1.Visible = true;
                    Player6Card2.Visible = true;
                }
                if (Player7Money.Visible)
                {
                    Player7Card1.Visible = true;
                    Player7Card2.Visible = true;
                }
            }
            else MessageBox.Show("You need at least 2 players to start a game");
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }
        private void RaiseButton_Click(object sender, EventArgs e)
        {
            if (RaiseInsertBox.Visible)
            {
                RaiseInsertBox.Visible = false;
                ConfirmRaiseButton.Visible = false;
                MinRaiseLabel.Visible = false;
            }
            else
            {
                RaiseInsertBox.Visible = true;
                ConfirmRaiseButton.Visible = true;
                MinRaiseLabel.Visible = true;
            }
        }
        private void CallButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("call:");
            CallButton.Enabled=false;
            FoldButton.Enabled=false;
            RaiseButton.Enabled=false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false; ;
            TimeForTurnLabel.Visible = false;
        }
        private void FoldButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("fold:");
            CallButton.Enabled = false;
            FoldButton.Enabled = false;
            RaiseButton.Enabled = false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false; ;
            TimeForTurnLabel.Visible = false;
        }
        public void CallBet(string info)
        {
            string[]parts = info.Split(':');
            if (parts[4].Equals(username))
            {
                Player1Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                Player1Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
            }
            else
            {
                if (parts[3].Equals("0"))
                {
                        Tikshoret.SendMessage("table:bets:" + parts[4] + ":" + parts[2] + ":" + parts[1]);
                }
                if (parts[3].Equals("1"))
                {
                        Player2Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player2Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
                if (parts[3].Equals("2"))
                {
                        Player3Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player3Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
                if (parts[3].Equals("3"))
                {
                        Player4Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player4Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
                if (parts[3].Equals("4"))
                {
                        Player5Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player5Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
                if (parts[3].Equals("5"))
                {
                        Player6Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player6Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
                if (parts[3].Equals("6"))
                {
                        Player7Bet.Text = int.Parse(parts[5]) + int.Parse(parts[1]) + "$";
                        Player7Money.Text = (int.Parse(parts[2]) - int.Parse(parts[1])).ToString() + "$";
                }
            }
        }
        public void FoldBet(string info)
        {
            string[] parts = info.Split(':');
            CallButton.Enabled = false;
            FoldButton.Enabled = false;
            RaiseButton.Enabled = false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false;
            TimeForTurnLabel.Visible = false;
            if (parts[2].Equals(username))
            {
                Player1Bet.Text += "Folded";
            }
            else
            {
                if (parts[1].Equals("0"))
                {
                    Tikshoret.SendMessage("table:folds" + parts[2]);
                }
                if (parts[1].Equals("1"))
                {
                    Player2Bet.Text += "Folded";
                }
                if (parts[1].Equals("2"))
                {
                    Player3Bet.Text += "Folded";
                }
                if (parts[1].Equals("3"))
                {
                    Player4Bet.Text += "Folded";
                }
                if (parts[1].Equals("4"))
                {
                    Player5Bet.Text += "Folded";
                }
                if (parts[1].Equals("5"))
                {
                    Player6Bet.Text += "Folded";
                }
                if (parts[1].Equals("6"))
                {
                    Player7Bet.Text += "Folded";
                }
            }
        }
        public void RaiseBet(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].StartsWith("nothing") || parts[1].StartsWith("not_a"))
                MessageBox.Show("Please insert a Number");
            else if (parts[1].StartsWith("not_e"))
                MessageBox.Show("You dont have enough money to place this bet");
            else if (parts[1].StartsWith("min"))
                MessageBox.Show("Min raise is 5000");
            else
            {
                ConfirmRaiseButton.Visible = false;
                RaiseInsertBox.Visible = false; ;
                CallButton.Enabled = false;
                FoldButton.Enabled = false;
                RaiseButton.Enabled = false;
                TimeForTurnLabel.Visible = false;
                TableBetLabel.Text = "Current Bet:" + parts[1] + "$";
                if (parts[3].Equals(username))
                {
                    Player1Bet.Text = parts[1] + "$";
                    Player1Money.Text = parts[4] + "$";
                }
                else
                {
                    if (parts[2].Equals("0"))
                    {
                        Tikshoret.SendMessage("table:raise:" + parts[1] + ":" + parts[3]);
                    }
                    if (parts[2].Equals("1"))
                    {
                        Player2Bet.Text = parts[1] + "$";
                        Player2Money.Text = parts[4] + "$";
                    }
                    if (parts[2].Equals("2"))
                    {
                        Player3Bet.Text = parts[1] + "$";
                        Player3Money.Text = parts[4] + "$";
                    }
                    if (parts[2].Equals("3"))
                    {
                        Player4Bet.Text = parts[1] + "$";
                        Player4Money.Text = parts[4] + "$";
                    }
                    if (parts[2].Equals("4"))
                    {
                        Player5Bet.Text = parts[1] + "$";
                        Player5Money.Text = parts[4] + "$";
                    }
                    if (parts[2].Equals("5"))
                    {
                        Player6Bet.Text = parts[1] + "$";
                        Player6Money.Text = parts[4] + "$";
                    }
                    if (parts[2].Equals("6"))
                    {
                        Player7Bet.Text = parts[1] + "$";
                        Player7Money.Text = parts[4] + "$";
                    }
                }
            }
        }
        public void RunTurn()
        {
            RaiseButton.Enabled = true;
            CallButton.Enabled = true;
            FoldButton.Enabled = true;
            TimeForTurnLabel.Visible = true;
        }
        public void RoundEnd(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("1")) 
            {
                TableCard1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                TableCard2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                TableCard3.Image = Image.FromFile(PicturePath + "card." + parts[6] + "." + parts[7] + ".jpg");
                TableCard1.Visible= true;
                TableCard2.Visible= true;
                TableCard3.Visible= true;
            }
            if (parts[1].Equals("2"))
            {
                TableCard4.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                TableCard4.Visible= true;
            }
            if (parts[1].Equals("3"))
            {
                TableCard5.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                TableCard5.Visible= true;
            }
        }
        private void Game_Form_Load(object sender, EventArgs e)
        {

        }
        public void GameTimerTick(string info)
        {
            string[] parts = info.Split(':');
            TimeForTurnLabel.Text = parts[1];
        }
        private void TableCard1_Click(object sender, EventArgs e)
        {

        }
        private void ConfirmRaiseButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("raise:"+ RaiseInsertBox.Text);
        }
        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("leave:");
            Hide();
            //this.Close();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.GameMenu = new Game_Menu_Form(username);
            this.Invoke(new Action(() => Tikshoret.GameMenu.ShowDialog()));
        }
        public void Switch(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("0"))
            {
                Player1Bet.Text = Player2Bet.Text;
                Player1Money.Text = Player2Money.Text;
                Player1Box.Text = Player2Box.Text;
                MainCard1.Image = Player2Card1.Image;
                MainCard2.Image= Player2Card2.Image;
                Player2Bet.Visible = false;
                Player2Money.Visible = false;
                Player2Box.Visible = false;
                Player2Card1.Visible = false;
                Player2Card2.Visible = false;
            }
            else if (parts[1].Equals("1"))
            {
                Player2Bet.Text = Player3Bet.Text;
                Player2Money.Text = Player3Money.Text;
                Player2Box.Text = Player3Box.Text;
                Player2Card1.Image = Player3Card1.Image;
                Player2Card2.Image = Player3Card2.Image;
                Player2Bet.Visible = true;
                Player2Money.Visible = true;
                Player2Box.Visible = true;
                Player2Card1.Visible = true;
                Player2Card2.Visible = true;
                Player3Bet.Visible = false;
                Player3Money.Visible = false;
                Player3Box.Visible = false;
                Player3Card1.Visible = false;
                Player3Card2.Visible = false;
            }
            else if (parts[1].Equals("2"))
            {
                Player3Bet.Text = Player4Bet.Text;
                Player3Money.Text = Player4Money.Text;
                Player3Box.Text = Player4Box.Text;
                Player3Card1.Image = Player4Card1.Image;
                Player3Card2.Image = Player4Card2.Image;
                Player3Bet.Visible = true;
                Player3Money.Visible = true;
                Player3Box.Visible = true;
                Player3Card1.Visible = true;
                Player3Card2.Visible = true;
                Player4Bet.Visible = false;
                Player4Money.Visible = false;
                Player4Box.Visible = false;
                Player4Card1.Visible = false;
                Player4Card2.Visible = false;
            }
            else if (parts[1].Equals("3"))
            {
                Player4Bet.Text = Player5Bet.Text;
                Player4Money.Text = Player5Money.Text;
                Player4Box.Text = Player5Box.Text;
                Player4Card1.Image = Player5Card1.Image;
                Player4Card2.Image = Player5Card2.Image;
                Player4Bet.Visible = true;
                Player4Money.Visible = true;
                Player4Box.Visible = true;
                Player4Card1.Visible = true;
                Player4Card2.Visible = true;
                Player5Bet.Visible = false;
                Player5Money.Visible = false;
                Player5Box.Visible = false;
                Player5Card1.Visible = false;
                Player5Card2.Visible = false;
            }
            else if (parts[1].Equals("4"))
            {
                Player5Bet.Text = Player6Bet.Text;
                Player5Money.Text = Player6Money.Text;
                Player5Box.Text = Player6Box.Text;
                Player5Card1.Image = Player6Card1.Image;
                Player5Card2.Image = Player6Card2.Image;
                Player5Bet.Visible = true;
                Player5Money.Visible = true;
                Player5Box.Visible = true;
                Player5Card1.Visible = true;
                Player5Card2.Visible = true;
                Player6Bet.Visible = false;
                Player6Money.Visible = false;
                Player6Box.Visible = false;
                Player6Card1.Visible = false;
                Player6Card2.Visible = false;
            }
            else if (parts[1].Equals("5"))
            {
                Player6Bet.Text = Player7Bet.Text;
                Player6Money.Text = Player7Money.Text;
                Player6Box.Text = Player7Box.Text;
                Player6Card1.Image = Player7Card1.Image;
                Player6Card2.Image = Player7Card2.Image;
                Player6Bet.Visible = true;
                Player6Money.Visible = true;
                Player6Box.Visible = true;
                Player6Card1.Visible = true;
                Player6Card2.Visible = true;
                Player7Bet.Visible = false;
                Player7Money.Visible = false;
                Player7Box.Visible = false;
                Player7Card1.Visible = false;
                Player7Card2.Visible = false;
            }
            else if (parts[1].Equals("6"))
            {
                Player7Bet.Visible = false;
                Player7Money.Visible = false;
                Player7Box.Visible = false;
                Player7Card1.Visible = false;
                Player7Card2.Visible = false;
            }
        }
        public void WinnerAnnouncement(string info)
        {
            string[] parts = info.Split(':');
            WinnerAnnouncementLabel.Text = "The Winner is " + parts[2];
            WinnerAnnouncementLabel.Visible = true;
            PlayAgainButton.Visible = true;
        }
        public void UpdateWinnerMoney(string info)
        {
            string[] parts = info.Split(':');
            if (parts[2].Equals(username))
            {
                Player1Money.Text = parts[3] + "$";
            }
            else
            {
                if (parts[1].Equals("0"))
                {
                    Tikshoret.SendMessage("table:update_money:");
                }
                if (parts[1].Equals("1"))
                {
                    Player2Money.Text = parts[3] + "$";
                }
                if (parts[1].Equals("2"))
                {
                    Player3Money.Text = parts[3] + "$";
                }
                if (parts[1].Equals("3"))
                {
                    Player4Money.Text = parts[3] + "$";
                }
                if (parts[1].Equals("4"))
                {
                    Player5Money.Text = parts[3] + "$";
                }
                if (parts[1].Equals("5"))
                {
                    Player6Money.Text = parts[3] + "$";
                }
                if (parts[1].Equals("6"))
                {
                    Player7Money.Text = parts[3] + "$";
                }
            }
        }
        public void RevealCards(string info)
        {
            string[] parts = info.Split(':');
            if (parts[6].Equals(username))
            {
                return;
            }
            else
            {
                if (parts[1].Equals("0"))
                {
                    Tikshoret.SendMessage("table:reveal:");
                }
                if (parts[1].Equals("1"))
                {
                    Player2Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player2Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
                if (parts[1].Equals("2"))
                {
                    Player3Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player3Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
                if (parts[1].Equals("3"))
                {
                    Player4Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player4Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
                if (parts[1].Equals("4"))
                {
                    Player5Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player5Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
                if (parts[1].Equals("5"))
                {
                    Player6Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player6Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
                if (parts[1].Equals("6"))
                {
                    Player7Card1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
                    Player7Card2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
                }
            }
        }
        private void PlayAgainButton_Click(object sender, EventArgs e)
        {

        }
    }
}
