using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the login form of the application.
    /// </summary>
    public partial class Login_Form : Form
    {
        // The random captcha number.
        int captchaID;
        // The captcha image file path.
        string CaptchaPath = @"D:\\projects\\poker-client\\projuct2\\picFolder\\CaptchaImage";
        /// <summary>
        /// Represents the login form of the application. Initilizes the connection to the server and begins listening to messeges from the server.
        /// </summary>
        public Login_Form()
        {
            InitializeComponent();
            if (Tikshoret._isTcpClientConnected == false)
            {
                Tikshoret.connect();
                Tikshoret.login = this;
            }
            else Tikshoret.BeginRead();
        }
        /// <summary>
        /// Handles the click event of the login button. Sends the server the login data and the captcha answer - login request.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Login_button_Click(object sender, EventArgs e)
        {
            if (!Capthca_checkbox.Checked) 
            {
                MessageBox.Show("Please check the 'I'm not a robot' box");
                return;
            }
            Login_button.Enabled = false;
            // Get the user's login information.
            string username = username_box.Text;
            string password = password_box.Text;
            // Send the user's login information to the server.
            Tikshoret.SendMessage("login:" + username + ":" + password + ":" + captchaID + ":" + CaptchaTextBox.Text);
        }
        /// <summary>
        /// Handles the click event of the registration button. Transfers the user to the Regist form and closes the login form.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void Regist_button_1_Click(object sender, EventArgs e)
        {
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.regist = new Regist_Form();
            this.Invoke(new Action(() => Tikshoret.regist.ShowDialog()));
            Close();
        }
        private void username_box_TextChanged(object sender, EventArgs e)
        {

        }
        private void password_box_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles Displaying the time the user has left of their timeout.
        /// </summary>
        /// <param name="info"></param>
        public void Timeout(string info)
        {
            string[] parts = info.Split(':');
            Login_button.Enabled = false;
            cooldownBox.Text = parts[1];
            if (parts[1].Equals("0"))
            {
                cooldownBox.Text = "";
                Login_button.Enabled = true;
            }
        }
        /// <summary>
        /// Sets the captcha image to match the one sent by the server.
        /// </summary>
        /// <param name="info">A random Captcha number sent by the server</param>
        public void SetCaptchaImage(string info)
        {
            String[] parts = info.Split(':');
            captchaID = int.Parse(parts[1]);
            CaptchaImageBox.Image = Image.FromFile(CaptchaPath + parts[1] + ".png");
        }
        /// <summary>
        /// Handels the login request answer of the server.
        /// </summary>
        /// <param name="info">Server's messege</param>
        public void LoginRequest(string info)
        {
            Login_button.Enabled = true;
            string[] parts = info.Split(':');
            if (parts[1].Equals("ok"))
            {
                Hide();
                // Create a new instance of Form2 and pass the client object to it.
                Tikshoret.GameMenu = new Game_Menu_Form(username_box.Text);
                this.Invoke(new Action(() => Tikshoret.GameMenu.ShowDialog()));
                Close();
            }
            // If capthca is incorrect
            else if (parts[1].Equals("captchaIncorrect"))
            {
                MessageBox.Show("Captcha answer is incorrect");
            }
            else if (parts[1].StartsWith("user")) // if the user is already logged in.
            {
                MessageBox.Show("The user is already logged in");
            }
            else
            {
                // If the login is not successful, show an error message.
                MessageBox.Show("The username or password is incorrect");
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void CaptchaImageBox_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sends the server a reqeust for a random capthca.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Capthca_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if(Capthca_checkbox.Checked)
                Tikshoret.SendMessage("getcaptcha:");
        }
        /// <summary>
        /// Transfers the user to a ForgotPassword form to renew his passoword. Closes login form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForgotPasswordButton_Click(object sender, EventArgs e)
        {
            Hide();
            // Create a new instance of Form2 and pass the client object to it.
            Tikshoret.password_ = new Password_Reset_Form();
            this.Invoke(new Action(() => Tikshoret.password_.ShowDialog()));
            Close();
        }
    }
}
