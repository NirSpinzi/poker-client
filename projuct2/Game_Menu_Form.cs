using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projuct2
{
    /// <summary>
    /// Represents the game menu form in the application.
    /// </summary>
    public partial class Game_Menu_Form : Form
    {
        string Username;
        /// <summary>
        /// Initializes a new instance of the Game_Menu_Form class with the specified username and starts listening to messages from the server.
        /// </summary>
        /// <param name="username">The username of the player.</param>
        public Game_Menu_Form(string username)
        {
            Username = username;
            InitializeComponent();
            Tikshoret.BeginRead();
        }
        private void Menu_label_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sends the server a request to join a lobby.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Find_Match_button_Click(object sender, EventArgs e)
        {
            Find_Match_button.Enabled = false;
            Tikshoret.SendMessage("game:join");
        }
        /// <summary>
        /// Sends the server a reqeust to host a lobby.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Host_Game_button_Click(object sender, EventArgs e)
        {
            Host_Game_button.Enabled = false;
            Tikshoret.SendMessage("game:host");
        }
        /// <summary>
        /// Handels the the join lobby request answer from the server.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void JoinRequest(string info)
        {
            Find_Match_button.Enabled = true;
            string[] parts = info.Split(':');
            if (parts[1].Equals("valid"))
            {
                Hide();
                Tikshoret.Game = new Game_Form(Username + ":" + parts[2]);
                this.Invoke(new Action(() => Tikshoret.Game.ShowDialog())); // Transfers the user to the game form. closes current form.
                Close();
            }
            else MessageBox.Show("There are no available lobbys");
        }
        /// <summary>
        /// Handels the the host lobby request answer from the server.
        /// </summary>
        /// <param name="info">Server's answer</param>
        public void HostRequest(string info)
        {
            Host_Game_button.Enabled = true;
            string[] parts = info.Split(':');
            if (parts[1].Equals("hosted"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.Game = new Game_Form(parts[2] + ":" + parts[3]);
                this.Invoke(new Action(() => Tikshoret.Game.ShowDialog()));
                Close();
            }
        }
        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_Game_Button_Click(object sender, EventArgs e)
        {
            Close();           
        }
    }
}
