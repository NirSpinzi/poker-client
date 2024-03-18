using System;
using System.Drawing;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class Login_Form : Form
    {
        // Fields
        int captchaid;
        int count=0;
        int cooldownCount = 0;
        public Login_Form()
        {
            InitializeComponent();
            cooldown.Stop();
            if (Tikshoret._isTcpClientConnected == false)
            {
                Tikshoret.connect();
                Tikshoret.login = this;
            }
            else Tikshoret.BeginRead();
        }
        private void Login_button_Click(object sender, EventArgs e)
        {
            if (!Capthca_checkbox.Checked) 
            {
                MessageBox.Show("Please check the 'i'm not a robot' box");
                return;
            }
            // Get the user's login information.
            string username = username_box.Text;
            string password = password_box.Text;
            // Send the user's login information to the server.
            Tikshoret.SendMessage("login:" + username + ":" + password + ":" + captchaid + ":" + CaptchaTextBox.Text);
        }
        /// <summary>
        /// Reads a message from the server using the established TCP connection.
        /// </summary>
        /// <returns>The message received from the server as a string.</returns>

        private void Regist_button_1_Click(object sender, EventArgs e)
        {
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.regist = new Regist_Form();
            this.Invoke(new Action(() => Tikshoret.regist.ShowDialog()));
        }

        private void username_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_box_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetCaptchaImage(string info)
        {
            String[] parts = info.Split(':');
            captchaid = int.Parse(parts[1]);
            CaptchaImageBox.Image = Image.FromFile("D:\\projects\\projuct2\\projuct2\\picFolder\\CaptchaImage" + parts[1] + ".png");
        }
        public void LoginRequest(string info)
        {
            string[] parts = info.Split(':');
            if (parts[1].Equals("ok"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.GameMenu = new Game_Menu_Form(username_box.Text);
                this.Invoke(new Action(() => Tikshoret.GameMenu.ShowDialog()));
            }
            // If capthca is incorrect
            else if (parts[1].Equals("captchaIncorrect"))
            {
                MessageBox.Show("Captcha answer is incorrect");
                count++;
                if (count == 3)
                {
                    Login_button.Enabled = false;
                    cooldownCount = 30;
                    cooldownBox.Text = cooldownCount.ToString();
                    cooldown.Start();
                    count = 0;
                }
            }
            else
            {
                // If the login is not successful, show an error message.
                MessageBox.Show("The username or password is incorrect");
                count++;
                if (count == 3)
                {
                    Login_button.Enabled = false;
                    cooldownCount = 30;
                    cooldownBox.Text = cooldownCount.ToString();
                    cooldown.Start();
                    count = 0;
                }
            }
        }
        private void email_box_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
        private void CaptchaImageBox_Click(object sender, EventArgs e)
        {

        }
        private void cooldown_Tick(object sender, EventArgs e)
        {
            cooldownCount--;
            cooldownBox.Text = cooldownCount.ToString();
            if (cooldownCount == 0) 
            { 
                cooldown.Stop();
                Login_button.Enabled = true;
                cooldownBox.Text = "";
            }
        }
        private void Capthca_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(Capthca_checkbox.Checked)
                Tikshoret.SendMessage("getcaptcha:");
        }
        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.password_ = new Password_Reset_Form();
            this.Invoke(new Action(() => Tikshoret.password_.ShowDialog()));
        }
    }
}
