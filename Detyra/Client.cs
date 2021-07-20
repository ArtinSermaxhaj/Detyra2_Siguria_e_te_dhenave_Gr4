using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
namespace Detyra
{
    public class Client
    {
        static RSACryptoServiceProvider objRsa = new RSACryptoServiceProvider();
        static DESCryptoServiceProvider objDes = new DESCryptoServiceProvider();
        byte[] InitialVector;
        byte[] sharedKey;
        private UDP client;
        public Client(){
            this.client = new UDP();
            client.Client("127.0.0.1", 27000);
        }
        public void ClientSend(){
            string message = Enkripto();
            client.Send(message);
        }
        public void merrCelesat() {
            StreamReader sr = new StreamReader("celesat.xml");
            string xmlParameters = sr.ReadToEnd();
            objRsa.FromXmlString(xmlParameters);
        }
        public string Enkripto() {
            Console.WriteLine("Shenoni mesazhin per enkriptim");
            String plainText = Console.ReadLine();
            byte[] ByteplainText = Encoding.UTF8.GetBytes(plainText);
            objDes.GenerateIV();
            objDes.GenerateKey();
            InitialVector = objDes.IV;
            sharedKey = objDes.Key;
            objDes.Mode = CipherMode.CBC;
            objDes.Padding = PaddingMode.PKCS7;
            byte[] mesazhiEnkriptuar = objDes.CreateEncryptor().TransformFinalBlock(ByteplainText, 0, ByteplainText.Length);
            merrCelesat();
            byte[] encryptedKey = objRsa.Encrypt(sharedKey, true);
            StringBuilder sb = new StringBuilder();
            sb.Append(Convert.ToBase64String(InitialVector) + "*");
            sb.Append(Convert.ToBase64String(encryptedKey) + "*");
            sb.Append(Convert.ToBase64String(mesazhiEnkriptuar));
            return sb.ToString();
        }
    }
}