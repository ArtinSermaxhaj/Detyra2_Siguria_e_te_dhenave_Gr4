using System.Net.Security;
using System.Security.Cryptography;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Detyra
{
    public class Server
    {
        private UDP server;
        Client c1 = new Client();
        static RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();
        static DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
        public Server()
        {
            this.server = new UDP();
            server.Server("127.0.0.1", 27000);
        }
        public void ServerSend(string message)
        {
            server.ServerSend(EnkriptoPergjigjien(message));
        }
        public void ShtoCelesat()
        {
            string parametratXml = objRsa.ToXmlString(true);
            StreamWriter sw = new StreamWriter("celesat.xml");
            sw.Write(parametratXml);
            sw.Close();
        }
        public void Dekripto()
        {
            string kerkesa = server.Receive();
            string[] vargu = kerkesa.Split('*');
            Console.WriteLine("IV = " + (vargu[0]) + ", gjatesia e vargut " + vargu.Length);
            byte[] initV = Convert.FromBase64String(vargu[0]);
            objDes.IV = initV;
            byte[] encryptedKey = Convert.FromBase64String(vargu[1]);
            c1.merrCelesat();
            byte[] desKey = objRsa.Decrypt(encryptedKey, true);
            Console.WriteLine("Key after decryption : " + BitConverter.ToString(desKey));
            objDes.Key = desKey;
            objDes.Mode = CipherMode.CBC;
            objDes.Padding = PaddingMode.PKCS7;
            byte[] encryptedMessage = Convert.FromBase64String(vargu[2]);
            //MemoryStream ms = new MemoryStream(encryptedMessage);
            byte[] decryptedMessage;
            decryptedMessage = objDes.CreateDecryptor().TransformFinalBlock(encryptedMessage, 0, encryptedMessage.Length);
            Console.WriteLine("mesazhi i dekriptuar " + Encoding.UTF8.GetString(decryptedMessage));
        }
        public string EnkriptoPergjigjien(string response)
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

    }
}