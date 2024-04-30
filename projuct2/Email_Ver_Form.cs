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
        public void VerifyCode(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("ok"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.login = new Login_Form();
                this.Invoke(new Action(() => Tikshoret.login.ShowDialog()));
                Close();
            }
            else MessageBox.Show("The code you entered is incorrect");
        }
    }
}
