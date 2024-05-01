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
    /// <summary>
    /// Represents the game form where poker game actions are displayed.
    /// </summary>
    public partial class Game_Form : Form
    {
        // The username of the client
        string username;
        // The string path of the picture folder.
        string PicturePath = @"D:\\projects\\poker-client\\projuct2\\picFolder\\";
        // A flag indicating wether the client is the host or not.
        bool isHost = false;
        /// <summary>
        /// Initializes a new instance of the Game_Form class. Also asks the server wether he is the host - isHost Request.
        /// </summary>
        /// <param name="info">Information about the user.</param>
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
        /// <summary>
        /// Handels the isHost request answer of the server.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void IsHost(string info)
        {
            if (info.Equals("true"))
            {
                start_game_button.Visible = true;
                start_game_button.Enabled = true;
                isHost = true;
            }
        }
        /// <summary>
        /// Opens the form to see all the hand strengths of poker.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void poker_hands_button_Click(object sender, EventArgs e)
        {
            Form form= new poker_hands_form();
            form.Show();
        }
        /// <summary>
        /// Handels the server telling the client that another player is joining the lobby.
        /// </summary>
        /// <param name="info">Info from the server about the joining player</param>
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
        /// <summary>
        /// Sends the server a request to start the game - start game request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_game_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("game:start");
        }
        /// <summary>
        /// Handels the server's answer to the start game request.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void startGame(string info)
        {
            string[] parts = info.Split(':');
            if (parts[2].Equals("ok")) // Server approves of the reqeust - start the game.
            {
                resetTable();
                TableBetLabel.Visible = true;
                start_game_button.Enabled = false;
                LeaveButton.Enabled = false;
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
            } // Server does not approve because there are not enough players.
            else MessageBox.Show("You need at least 2 players to start a game");
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Enabels the user to raise by making the insert raise box and the confirm raise button visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Sends the server a request to call - call request. Ends your turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("call:");
            CallButton.Enabled=false;
            FoldButton.Enabled=false;
            RaiseButton.Enabled=false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false; ;
        }
        /// <summary>
        /// Sends the server a fold request. Ends your turn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoldButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("fold:");
            CallButton.Enabled = false;
            FoldButton.Enabled = false;
            RaiseButton.Enabled = false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false; ;
        }
        /// <summary>
        /// Handels the server's answer to the call request.
        /// </summary>
        /// <param name="info">Server's answer</param>
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
        /// <summary>
        /// Handels the server's answer to the fold request.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void FoldBet(string info)
        {
            string[] parts = info.Split(':');
            CallButton.Enabled = false;
            FoldButton.Enabled = false;
            RaiseButton.Enabled = false;
            ConfirmRaiseButton.Visible = false;
            RaiseInsertBox.Visible = false;
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
        /// <summary>
        /// Handels the server's answer to the raise request.
        /// </summary>
        /// <param name="info">Server's answer</param>
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
                MinRaiseLabel.Visible = false;
                CallButton.Enabled = false;
                FoldButton.Enabled = false;
                RaiseButton.Enabled = false;
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
        /// <summary>
        /// Enables you to play on your turn.
        /// </summary>
        public void RunTurn()
        {
            RaiseButton.Enabled = true;
            CallButton.Enabled = true;
            FoldButton.Enabled = true;
        }
        /// <summary>
        /// Handels the server's message to go to the next round.
        /// </summary>
        /// <param name="info">info about the current round</param>
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
        private void TableCard1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sends the number you inserted in the raise insert box to the server for a raise request.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmRaiseButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("raise:"+ RaiseInsertBox.Text);
        }
        /// <summary>
        /// Sends the server a message telling it you're leaving the lobby and transfers you back to the Game menu form. Closes current form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("leave:");
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.GameMenu = new Game_Menu_Form(username);
            this.Invoke(new Action(() => Tikshoret.GameMenu.ShowDialog()));
            Close();
        }
        /// <summary>
        /// Handels the server's message about the rearrangements of the sits when a player leaves the lobby.
        /// </summary>
        /// <param name="info">Info about which player left</param>
        public void Switch(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("0"))
            {
                Player1Money.Text = Player2Money.Text;
                Player2Money.Visible = false;
                Player2Name.Text = "";
            }
            else if (parts[1].Equals("1"))
            {
                Player2Money.Text = Player3Money.Text;
                Player2Name.Text = Player3Name.Text;
                Player2Money.Visible = true;
                Player3Money.Visible = false;
                Player3Name.Text = "";
            }
            else if (parts[1].Equals("2"))
            {
                Player3Money.Text = Player4Money.Text;
                Player3Name.Text = Player4Name.Text;
                Player3Money.Visible = true;
                Player4Money.Visible = false;
                Player4Name.Text = "";
            }
            else if (parts[1].Equals("3"))
            {
                Player4Money.Text = Player5Money.Text;
                Player4Name.Text = Player5Name.Text;
                Player4Money.Visible = true;
                Player5Money.Visible = false;
                Player5Name.Text = "";
            }
            else if (parts[1].Equals("4"))
            {
                Player5Money.Text = Player6Money.Text;
                Player5Name.Text = Player6Name.Text;
                Player5Money.Visible = true;
                Player6Money.Visible = false;
                Player6Name.Text = "";
            }
            else if (parts[1].Equals("5"))
            {
                Player6Money.Text = Player7Money.Text;
                Player6Name.Text = Player7Name.Text;
                Player6Money.Visible = true;
                Player7Money.Visible = false;
                Player7Name.Text = "";
            }
            else if (parts[1].Equals("6"))
            {
                Player7Money.Visible = false;
                Player7Name.Text = "";
            }
        }
        /// <summary>
        /// Handels the server's message about the winner of the game or the players who tied.
        /// </summary>
        /// <param name="info">Info about which player won or which players tied</param>
        public void WinnerAnnouncement(string info)
        {
            string[] parts = info.Split(':');
            if (parts[0].Equals("winners"))
            {
                switch (parts[1])
                {
                    case "2": // a tie between 2 players
                        {
                            WinnerAnnouncementLabel.Text = "A tie between " + parts[2] + " and " + parts[4];                           
                            break;
                        }
                    case "3":// a tie between 3 players
                        {
                            WinnerAnnouncementLabel.Text = "A tie between " + parts[2] + ", " + parts[4] + " and " + parts[6];
                            break;
                        }
                    case "4":// a tie between 4 players
                        {
                            WinnerAnnouncementLabel.Text = "A tie between " + parts[2] + ", " + parts[4] + ", " + parts[6] + " and " + parts[8];
                            break;
                        }
                }
            } // a single winner.
            else WinnerAnnouncementLabel.Text = "The Winner is " + parts[1];
            WinnerAnnouncementLabel.Visible = true;
            CallButton.Enabled = false;
            FoldButton.Enabled = false;
            RaiseButton.Enabled = false;
            LeaveButton.Enabled = true;
            ConfirmRaiseButton.Visible= false;
            MinRaiseLabel.Visible= false;
            RaiseInsertBox.Visible= false;
            if (isHost)
            {
                PlayAgainButton.Visible = true;
                PlayAgainButton.Enabled = true;
            }
        }
        /// <summary>
        /// Handels the server's message about the money of the winner of the game or the players who tied.
        /// </summary>
        /// <param name="info">Info about the money of player who won or the players that tied</param>
        public void UpdateWinnerMoney(string info)
        {
            string[] parts = info.Split(':');
            if (parts[0].Equals("winners"))
            {
                switch (parts[1])
                {
                    case "2": // a tie between 2 players
                        {
                            UpdateMoney(parts[2], parts[3]);
                            UpdateMoney(parts[4], parts[5]);
                            break;
                        }
                    case "3": // a tie between 3 players
                        {
                            UpdateMoney(parts[2], parts[3]);
                            UpdateMoney(parts[4], parts[5]);
                            UpdateMoney(parts[6], parts[7]);
                            break;
                        }
                    case "4": // a tie between 4 players
                        {
                            UpdateMoney(parts[2], parts[3]);
                            UpdateMoney(parts[4], parts[5]);
                            UpdateMoney(parts[6], parts[7]);
                            UpdateMoney(parts[8], parts[9]);
                            break;
                        }
                }
            } // a single winner.
            else UpdateMoney(parts[1], parts[2]);
        }
        /// <summary>
        /// Updates the amount of money a player has.
        /// </summary>
        /// <param name="username">The username of the player</param>
        /// <param name="money">The money you want to set to that player</param>
        private void UpdateMoney(string username, string money)
        {
            if (username.Equals(Your_Name_label.Text))
            {
                Player1Money.Text = money + "$";
            }
            if (username.Equals(Player2Name.Text))
            {
                Player2Money.Text = money + "$";
            }
            if (username.Equals(Player3Name.Text))
            {
                Player3Money.Text = money + "$";
            }
            if (username.Equals(Player4Name.Text))
            {
                Player4Money.Text = money + "$";
            }
            if (username.Equals(Player5Name.Text))
            {
                Player5Money.Text = money + "$";
            }
            if (username.Equals(Player6Name.Text))
            {
                Player6Money.Text = money + "$";
            }
            if (username.Equals(Player7Name.Text))
            {
                Player7Money.Text = money + "$";
            }
        }
        /// <summary>
        /// Handels the server's message about which cards to reveal at the end of the game and what are those cards. Reveals the cards.
        /// </summary>
        /// <param name="info">info from the server about the cards to reveal</param>
        public void RevealCards(string info)
        {
            string[] parts = info.Split(':');
            if (parts[6].Equals(username)) // You already see your own cards.
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
        /// <summary>
        /// Sends the server a  request to Play again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("new_game:");
        }
        /// <summary>
        /// Handels the server's approval of the play again request. Resets the table to the start of the game state.
        /// </summary>
        /// <param name="info">info the player's cards</param>
        public void PlayAgain(string info)
        {
            PlayAgainButton.Enabled = false;
            string[] parts = info.Split(':');
            MainCard1.Image = Image.FromFile(PicturePath + "card." + parts[2] + "." + parts[3] + ".jpg");
            MainCard2.Image = Image.FromFile(PicturePath + "card." + parts[4] + "." + parts[5] + ".jpg");
            resetTable();
            MainCard1.Visible = true;
            MainCard2.Visible = true;
            Player2Card1.Visible = true;
            Player2Card2.Visible = true;
            if (Player3Money.Visible)
            {
                Player3Card1.Visible = true;
                Player3Card2.Visible = true;
            }
            if (Player4Money.Visible)
            {
                Player4Card1.Visible = true;
                Player4Card2.Visible = true;
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
        /// <summary>
        /// Resets the table for the start of the game.
        /// </summary>
        private void resetTable()
        {
            Player1Bet.Text = "";
            Player2Bet.Text = "";
            Player3Bet.Text = "";
            Player4Bet.Text = "";
            Player5Bet.Text = "";
            Player6Bet.Text = "";
            Player7Bet.Text = "";
            TableCard1.Visible = false;
            TableCard2.Visible = false;
            TableCard3.Visible = false;
            TableCard4.Visible = false;
            TableCard5.Visible = false;
            WinnerAnnouncementLabel.Visible = false;
            Player2Card1.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player2Card2.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player3Card1.Image = Image.FromFile(PicturePath + "bakc_scard34 - sideways.jpg");
            Player3Card2.Image = Image.FromFile(PicturePath + "bakc_scard34 - sideways.jpg");
            Player4Card1.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player4Card2.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player5Card1.Image = Image.FromFile(PicturePath + "bakc_scard34 - sideways.jpg");
            Player5Card2.Image = Image.FromFile(PicturePath + "bakc_scard34 - sideways.jpg");
            Player6Card1.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player6Card2.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player7Card1.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
            Player7Card2.Image = Image.FromFile(PicturePath + "bakc_scard34.jpg");
        }
        /// <summary>
        /// Handels the server's message about which player left and removes that player from the table.
        /// </summary>
        /// <param name="info">info about the player who left.</param>
        public void PlayerLeft(string info)
        {
            string[] parts = info.Split(':');
            switch(parts[1]) 
            {
                case "0":
                    {
                        Tikshoret.SendMessage("table:leave");
                        break;
                    }
                case "1": 
                    {
                        Player2Bet.Visible = false;
                        Player2Name.Text = "";
                        Player2Card1.Visible = false;
                        Player2Card2.Visible = false;
                        Player2Money.Visible = false;
                        break;
                    }
                case "2":
                    {
                        Player3Bet.Visible = false;
                        Player3Name.Text = "";
                        Player3Card1.Visible = false;
                        Player3Card2.Visible = false;
                        Player3Money.Visible = false;
                        break;
                    }
                case "3":
                    {
                        Player4Bet.Visible = false;
                        Player4Name.Text = "";
                        Player4Card1.Visible = false;
                        Player4Card2.Visible = false;
                        Player4Money.Visible = false;
                        break;
                    }
                case "4":
                    {
                        Player5Bet.Visible = false;
                        Player5Name.Text = "";
                        Player5Card1.Visible = false;
                        Player5Card2.Visible = false;
                        Player5Money.Visible = false;
                        break;
                    }
                case "5":
                    {
                        Player6Bet.Visible = false;
                        Player6Name.Text = "";
                        Player6Card1.Visible = false;
                        Player6Card2.Visible = false;
                        Player6Money.Visible = false;
                        break;
                    }
                case "6":
                    {
                        Player7Bet.Visible = false;
                        Player7Name.Text = "";
                        Player7Card1.Visible = false;
                        Player7Card2.Visible = false;
                        Player7Money.Visible = false;
                        break;
                    }
            }
            
        }
        private void Player2Name_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Opens the Rules form where you read all of the rules to Poker Texas Hold'em.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_Rules_Button_Click(object sender, EventArgs e)
        {
            Form form = new Rules_Form();
            form.Show();
        }
    }
}
