using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projuct2
{
    /// <summary>
    /// Represents the core functionality for managing client-server communication.
    /// </summary>
    internal class Tikshoret
    {
        // RSA service provider for encryption
        private static RSAServiceProvider Rsa;
        // Public key of the server
        private static string ServerPublicKey;
        // Private key of the client
        private static string PrivateKey;
        // Port number for the TCP connection
        private static int portNo = 1500;
        // IP address of the server
        private const string ipAddress = "127.0.0.1";
        // Client socket for communication with the server
        public static TcpClient client;
        // Data buffer for sending and receiving messages
        private static byte[] data;
        // Symmetric key for encryption
        public static string SymmetricKey;
        // Reference to the login form
        public static Login_Form login;
        // Reference to the registration form
        public static Regist_Form regist;
        // Reference to the email verification form
        public static Email_Ver_Form email;
        // Reference to the password reset form
        public static Password_Reset_Form password_;
        // Reference to the game menu form
        public static Game_Menu_Form GameMenu;
        // Reference to the game form
        public static Game_Form Game;
        // Flag indicating if the TCP client is connected to the server
        static public bool _isTcpClientConnected = false;
        /// <summary>
        /// Connects the client to the server using TCP.
        /// </summary>
        public static void connect()
        {
            client = new TcpClient();
            client.Connect(ipAddress, portNo);
            _isTcpClientConnected = true;
            data = new byte[client.ReceiveBufferSize];
            client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            Rsa = new RSAServiceProvider();
            PrivateKey = Rsa.GetPrivateKey();
            SendMessage("PogurC" + Rsa.GetPublicKey());
        }
        /// <summary>
        /// Initiates reading data from the server.
        /// </summary>
        public static void BeginRead()
        {
            client.GetStream().BeginRead(data,0,System.Convert.ToInt32(client.ReceiveBufferSize),ReceiveMessage,null);
        }
        /// <summary>
        /// Handles the asynchronous reception of messages from the server - passes the messege to the form that has the appropriate response function to handel it.
        /// </summary>
        /// <param name = "ar" > The asynchronous result containing state information about the receive operation.</param>
        private static void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;

                // read the data from the server
                bytesRead = client.GetStream().EndRead(ar);

                if (bytesRead < 1)
                {
                    return;
                }
                else
                {
                    // invoke the delegate to display the recived data
                    string incommingData = System.Text.Encoding.ASCII.GetString(data, 0, bytesRead);
                    //MessageBox.Show(incommingData);
                    if (incommingData.StartsWith("PogurS"))
                    {
                        incommingData = incommingData.Substring(6);
                        ServerPublicKey = incommingData;
                    }
                    else if (incommingData.StartsWith("YavulS")) //gets Symmetrical Key
                    {
                        incommingData = incommingData.Substring(6);
                        incommingData = Rsa.Decrypt(incommingData, PrivateKey);
                        SymmetricKey = incommingData;
                    }
                    else 
                    {
                        byte[] Key = Encoding.UTF8.GetBytes(SymmetricKey);
                        byte[] IV = new byte[16];
                        incommingData = AESServiceProvider.Decrypt(incommingData, Key, IV);
                        if (incommingData.StartsWith("captcha"))
                        {
                            login.Invoke((Action)delegate { login.SetCaptchaImage(incommingData); });
                        }
                        else if (incommingData.StartsWith("login"))
                        {
                            login.Invoke((Action)delegate { login.LoginRequest(incommingData); });
                        }
                        else if (incommingData.StartsWith("regist"))
                        {
                            regist.Invoke((Action)delegate { regist.RegistRequest(incommingData); });
                        }
                        else if (incommingData.StartsWith("vercode"))
                        {
                            email.Invoke((Action)delegate { email.VerifyCode(incommingData); });
                        }
                        else if (incommingData.StartsWith("reset"))
                        {
                            password_.Invoke((Action)delegate { password_.PasswordReseter(incommingData); });
                        }
                        else if (incommingData.StartsWith("game"))
                        {
                            string[] parts = incommingData.Split(':');
                            if (parts[1].Equals("hosted"))
                            {
                                GameMenu.Invoke((Action)delegate { GameMenu.HostRequest(incommingData); });
                            }
                            else if (parts[1].Equals("start"))
                            {
                                Game.Invoke((Action)delegate { Game.startGame(incommingData); });
                            }
                            else if (parts[1].Equals("play_again"))
                            {
                                Game.Invoke((Action)delegate { Game.PlayAgain(incommingData); });
                            }
                        }
                        else if (incommingData.StartsWith("Host"))
                        {
                            string[] parts = incommingData.Split(':');
                            Game.Invoke((Action)delegate { Game.IsHost(parts[1]); });
                        }
                        else if (incommingData.StartsWith("join"))
                        {
                            string[] parts = incommingData.Split(':');
                            if (parts[1].Equals("invalid")|| parts[1].Equals("valid"))
                            {
                                GameMenu.Invoke((Action)delegate { GameMenu.JoinRequest(incommingData); });
                            }
                            else Game.Invoke((Action)delegate { Game.JoinGame(incommingData); });
                        }
                        else if (incommingData.StartsWith("table_"))
                        {
                            Game.Invoke((Action)delegate { Game.JoinGame(incommingData); });
                        }
                        else if (incommingData.StartsWith("call"))
                        {
                            Game.Invoke((Action)delegate { Game.CallBet(incommingData); });
                        }
                        else if (incommingData.StartsWith("fold"))
                        {
                            Game.Invoke((Action)delegate { Game.FoldBet(incommingData); });
                        }
                        else if (incommingData.StartsWith("raise"))
                        {
                            Game.Invoke((Action)delegate { Game.RaiseBet(incommingData); });
                        }
                        else if (incommingData.StartsWith("turn"))
                        {
                            Game.Invoke((Action)delegate { Game.RunTurn(); });
                        }
                        else if (incommingData.StartsWith("round"))
                        {
                            Game.Invoke((Action)delegate { Game.RoundEnd(incommingData); });
                        }
                        else if (incommingData.StartsWith("timeout"))
                        {
                            login.Invoke((Action)delegate { login.Timeout(incommingData); });
                        }
                        else if (incommingData.StartsWith("switch"))
                        {
                            Game.Invoke((Action)delegate { Game.Switch(incommingData); });
                        }
                        else if (incommingData.StartsWith("winner"))
                        {
                            Game.Invoke((Action)delegate { Game.WinnerAnnouncement(incommingData); });
                            Game.Invoke((Action)delegate { Game.UpdateWinnerMoney(incommingData); });
                        }
                        else if (incommingData.StartsWith("reveal"))
                        {
                            Game.Invoke((Action)delegate { Game.RevealCards(incommingData); });
                        }
                        else if (incommingData.StartsWith("leave"))
                        {
                            Game.Invoke((Action)delegate { Game.PlayerLeft(incommingData); });
                        }
                    }
                }

                // continue reading
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public static void SendMessage(string message)
        {
            try
            {
                if (!(message.StartsWith("Pogur"))) // Encrypt the message.
                {
                    byte[] Key = Encoding.UTF8.GetBytes(SymmetricKey);
                    byte[] IV = new byte[16];
                    message = AESServiceProvider.Encrypt(message, Key, IV);
                }
                // send message to the server
                NetworkStream ns = client.GetStream();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // send the text
                ns.Write(data, 0, data.Length);
                ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    /// <summary>
    /// Provides RSA encryption services.
    /// </summary>
    internal class RSAServiceProvider
    {
        private string PrivateKey;
        private string PublicKey;
        private UnicodeEncoding Encoder;
        private RSACryptoServiceProvider RSA;
        /// <summary>
        /// Initializes a new instance of the RSAServiceProvider class.
        /// </summary>
        public RSAServiceProvider()
        {
            Encoder = new UnicodeEncoding();
            RSA = new RSACryptoServiceProvider();

            PrivateKey = RSA.ToXmlString(true);
            PublicKey = RSA.ToXmlString(false);
        }
        /// <summary>
        /// return PrivateKey
        /// </summary>
        /// <returns>PrivateKey</returns>
        public string GetPrivateKey()
        {
            return this.PrivateKey;
        }
        /// <summary>
        /// return PublicKey
        /// </summary>
        /// <returns>PublicKey</returns>
        public string GetPublicKey()
        {
            return this.PublicKey;
        }
        /// <summary>
        /// decript data by privateKey
        /// </summary>
        /// <param name="Data">data to decript</param>
        /// /// <param name="PrivateKey">privateKey</param>
        /// <returns>decripted data</returns>
        public string Decrypt(string Data, string PrivateKey)
        {

            var DataArray = Data.Split(new char[] { ',' });
            byte[] DataByte = new byte[DataArray.Length];
            for (int i = 0; i < DataArray.Length; i++)
            {
                DataByte[i] = Convert.ToByte(DataArray[i]);
            }

            RSA.FromXmlString(PrivateKey);
            var DecryptedByte = RSA.Decrypt(DataByte, false);
            return Encoder.GetString(DecryptedByte);
        }
    }
    /// <summary>
    /// Provides AES encryption and decryption services.
    /// </summary>
    internal class AESServiceProvider
    {
        /// <summary>
        /// Encrypts the specified plain text using AES encryption.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <param name="Key">The encryption key.</param>
        /// <param name="IV">The initialization vector.</param>
        /// <returns>The encrypted text.</returns>
        public static string Encrypt(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }

            // Return the encrypted string from the memory stream.
            return encrypted;
        }
        /// <summary>
        /// Decrypts the specified cipher text using AES decryption.
        /// </summary>
        /// <param name="cipherText">The cipher text to decrypt.</param>
        /// <param name="Key">The decryption key.</param>
        /// <param name="IV">The initialization vector.</param>
        /// <returns>The decrypted text.</returns>
        public static string Decrypt(string cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            byte[] buffer = Convert.FromBase64String(cipherText);
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(buffer))
                {
                    using (CryptoStream csDecrypt = new CryptoStream((Stream)msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader((Stream)csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
    }
}
