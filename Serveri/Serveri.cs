using System.Net.Security;
using System.Security.Cryptography;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace Serveri
{
    public class Server
    {
        private UdpClient udpClient;
        static RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();
        static DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
        public static string test;
        public Server()
        {
            udpClient = new UdpClient(8000);
            Task.Run(serverThread);
        }
        public void ShtoCelesat()
        {
            var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var keyPath = Path.Combine(myDocs, "keys", "celesat.xml");
            if (File.Exists(keyPath)) return;

            string parametratXml = objRsa.ToXmlString(true);
            StreamWriter sw = new StreamWriter(keyPath);
            sw.Write(parametratXml);
            sw.Close();
        }
        public string Dekripto(string kerkesa)
        {
            string[] vargu = kerkesa.Split('*');
            //Console.WriteLine("IV = " + (vargu[0]) + ", gjatesia e vargut " + vargu.Length);
            byte[] initV = Convert.FromBase64String(vargu[0]);
            objDes.IV = initV;
            byte[] encryptedKey = Convert.FromBase64String(vargu[1]);
            merrCelesat();
            byte[] desKey = objRsa.Decrypt(encryptedKey, true);
            //Console.WriteLine("Key after decryption : " + BitConverter.ToString(desKey));
            objDes.Key = desKey;
            objDes.Mode = CipherMode.CBC;
            objDes.Padding = PaddingMode.PKCS7;
            byte[] encryptedMessage = Convert.FromBase64String(vargu[2]);
            //MemoryStream ms = new MemoryStream(encryptedMessage);
            byte[] decryptedMessage;
            decryptedMessage = objDes.CreateDecryptor().TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);
            //Console.WriteLine("mesazhi i dekriptuar " + Encoding.UTF8.GetString(decryptedMessage));
            return Encoding.UTF8.GetString(decryptedMessage);
        }
        public string EnkriptoPergjigjjen(string response)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] byteResponse = Encoding.UTF8.GetBytes(response);
            des.GenerateIV();
            des.Key = objDes.Key;
            byte[] mesazhiEnkriptuar = des.CreateEncryptor().TransformFinalBlock(byteResponse, 0, byteResponse.Length);
            StringBuilder sb = new StringBuilder();
            sb.Append(Convert.ToBase64String(des.IV) + "*");
            sb.Append(Convert.ToBase64String(mesazhiEnkriptuar) + "*");
            return sb.ToString();
        }
        public void merrCelesat() {
                        var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var keyPath = Path.Combine(myDocs, "keys", "celesat.xml");
                StreamReader sr = new StreamReader(keyPath);
                string xmlParameters = sr.ReadToEnd();
                objRsa.FromXmlString(xmlParameters);
        }
        
        public void serverThread()
        {
            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string base64 = Encoding.UTF8.GetString(receiveBytes);
                string mesazhi = Dekripto(base64);
                if(mesazhi != null)
                {
                    String msg = EnkriptoPergjigjjen(checkFunction(mesazhi));
                    udpClient.Send(Encoding.UTF8.GetBytes(msg), Encoding.UTF8.GetBytes(msg).Length,RemoteIpEndPoint);
                }

            }
        }
        public String checkFunction(string kerkesa) {
            string [] arr = kerkesa.Split('?');
            switch(arr[0]) {
                case "Login":
                    if(arr.Length == 3) {
                        string username = arr[1];
                        string password = arr[2];
                        if (DatabaseManipulation.checkIfUserAlreadyExists(username)) {
                            User user = DatabaseManipulation.getUserBills(username);
                            SessionManager.user = user;
                            string hashedPassword = GenerateHash(password, user.salt);
                            if (hashedPassword.Equals(user.password)) {
                                return "OK";
                            }else {
                                return "Error";
                            }
                        }
                        else
                        {
                            return "Error";
                        }
                   
                    }
                    else
                    {
                        return "Error";
                    }
                         break;
                case "Regjistro":
                    if (arr.Length == 6) {
                        string firstName = arr[1];
                        string lastName = arr[2];
                        string userName = arr[3];
                        string mosha = arr[4];
                        string password = arr[5];
                        if (!DatabaseManipulation.checkIfUserAlreadyExists(userName)) {
                            string salt = CreateSalt();
                            string hashedPassword = GenerateHash(password, salt);
                            User user = new User(firstName, lastName, userName, mosha, hashedPassword, salt);
                            SessionManager.user = user;
                            DatabaseManipulation.addUser(user);
                            return "OK";
                        }
                        else {
                            return "Error";
                        }
                    }
                    else
                    {
                        return "Error";
                    }
                    break;
                case "fatura" :
                    if (arr.Length == 5) {
                                string lloji = arr[1];
                                int viti = Int32.Parse(arr[2]);
                                int muaji = Int32.Parse(arr[3]);
                                double cmimi = Double.Parse(arr[4]);
                                Fatura f = new Fatura(lloji, viti, muaji, cmimi);
                                DatabaseManipulation.addFatura(f);
                                return "OK";
                    }else {
                        return "Error";
                    }
                    break;

                case "merrfaturat":
                    string bill = "";
                    foreach (Fatura f in SessionManager.user.faturat)
                    {
                        bill += f.llojiFatures + "*" + f.viti + "*" + f.muaji + "*" + f.vleraEuro+ "?";

                    }
                    return bill;
                    break;
                    

                default: return "Error";
            }
        } 
        public string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed SHA256String = new SHA256Managed();
            byte[] hash = SHA256String.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

    }
}