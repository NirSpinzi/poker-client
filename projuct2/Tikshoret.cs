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
    internal class Tikshoret
    {
        private static RSAServiceProvider Rsa;
        private static string ServerPublicKey;
        private static string PrivateKey;
        private static int portNo = 1500;
        private const string ipAddress = "127.0.0.1";
        public static TcpClient client;//client Socket
        private static byte[] data;//store the data that send to & from the server
        public static string SymmetricKey;
        public static Login_Form login;
        public static Regist_Form regist;
        public static Email_Ver_Form email;
        public static Password_Reset_Form password_;
        public static Game_Menu_Form GameMenu;
        public static Game_Form Game;
        static public bool _isTcpClientConnected = false;

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
        public static void BeginRead()
        {
            client.GetStream().BeginRead(data,0,System.Convert.ToInt32(client.ReceiveBufferSize),ReceiveMessage,null);
        }
        public static void StopRead()
        {
            ;
        }
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
                        ServerPublicKey = incommingData; //maybe i should make the publickey as bytes and not string and then do the switch to string just after that...
                    }
                    else if (incommingData.StartsWith("YavulS"))//gets Symmetrical Key
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
                    }
                }

                // continue reading
                client.GetStream().BeginRead(data, 0, System.Convert.ToInt32(client.ReceiveBufferSize), ReceiveMessage, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }// end ReceiveMessage
        /// <summary>
        /// convert the message to ASCII code send message to the server
        /// </summary>
        /// <param name="message">the data to send</param>
        public static void SendMessage(string message)
        {
            try
            {
                if (!(message.StartsWith("Pogur")))
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
                //ns.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }




















    internal class RSAServiceProvider
    {
        private string PrivateKey;
        private string PublicKey;
        private UnicodeEncoding Encoder;
        private RSACryptoServiceProvider RSA;

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
        /// <summary>
        /// Encrypt the data by public key
        /// </summary>
        /// <param name="Data">data to encrypt</param>
        /// <param name="PublicKey"></param>
        /// <returns>encripted data</returns>
        public string Encrypt(string Data, string PublicKey)
        {
            var Rsa = new RSACryptoServiceProvider();
            Rsa.FromXmlString(PublicKey);
            var DataToEncrypt = Encoder.GetBytes(Data);
            var EncryptedByteArray = Rsa.Encrypt(DataToEncrypt, false);
            var Length = EncryptedByteArray.Length;
            var Item = 0;
            var StringBuilder = new StringBuilder();
            foreach (var EncryptedByte in EncryptedByteArray)
            {
                Item++;
                StringBuilder.Append(EncryptedByte);

                if (Item < Length)
                    StringBuilder.Append(",");
            }

            return StringBuilder.ToString();
        }
    }
    internal class AESServiceProvider
    {
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
        public static byte[] EncryptToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

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
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted string from the memory stream.
            return encrypted;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns>Decrypt String</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string DecryptFromByte(byte[] cipherText, byte[] Key, byte[] IV)
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

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
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
