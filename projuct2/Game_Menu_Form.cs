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
    //hello
    public partial class Game_Menu_Form : Form
    {
        string Username;
        public Game_Menu_Form(string username)
        {
            Username = username;
            InitializeComponent();
            Tikshoret.BeginRead();
        }

        private void Menu_label_Click(object sender, EventArgs e)
        {

        }

        private void Find_Match_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("game:join");
        }

        private void Host_Game_button_Click(object sender, EventArgs e)
        {
            Tikshoret.SendMessage("game:host");
        }
        public void JoinRequest(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("valid"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.Game = new Game_Form(Username + ":" + parts[2]);
                this.Invoke(new Action(() => Tikshoret.Game.ShowDialog()));
            }
            else MessageBox.Show("There are no available lobbys");
        }
        public void HostRequest(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("hosted"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.Game = new Game_Form(parts[2] + ":" + parts[3]);
                this.Invoke(new Action(() => Tikshoret.Game.ShowDialog()));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
