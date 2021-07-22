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
        public Client()
        {
            this.client = new UDP();
            client.Client("127.0.0.1", 27000);
        }
        public void ClientSend()
        {
            string message = Enkripto();
            client.Send(message);
        }
        public void merrCelesat()
        {
            StreamReader sr = new StreamReader("celesat.xml");
            string xmlParameters = sr.ReadToEnd();
            objRsa.FromXmlString(xmlParameters);
        }
        public string Enkripto()
        {
            Console.WriteLine("Shenoni mesazhin per enkriptim");
            String plainText = Console.ReadLine();
            byte[] ByteplainText = Encoding.UTF8.GetBytes(plainText);
            Console.WriteLine("Plain text : " + BitConverter.ToString(ByteplainText));
            objDes.GenerateIV();
            objDes.GenerateKey();
            InitialVector = objDes.IV;
            sharedKey = objDes.Key;
            objDes.Mode = CipherMode.CBC;
            objDes.Padding = PaddingMode.PKCS7;
            byte[] mesazhiEnkriptuar = objDes.CreateEncryptor().TransformFinalBlock(ByteplainText, 0, ByteplainText.Length);
            merrCelesat();
            byte[] encryptedKey = objRsa.Encrypt(sharedKey, true);
            Console.WriteLine("Celesi : " + BitConverter.ToString(sharedKey));
            StringBuilder sb = new StringBuilder();
            sb.Append(Convert.ToBase64String(InitialVector) + "*");
            sb.Append(Convert.ToBase64String(encryptedKey) + "*");
            sb.Append(Convert.ToBase64String(mesazhiEnkriptuar));
            return sb.ToString();
        }
        public void DekriptoPergjigjen()
        {
            DESCryptoServiceProvider desKlient = new DESCryptoServiceProvider();
            String response = client.Receive();
            string[] arr = response.Split('*');
            byte[] initialV = Convert.FromBase64String(arr[0]);
            desKlient.IV = initialV;
            desKlient.Key = objDes.Key;
            byte[] encryptedResponse = Convert.FromBase64String(arr[1]);
            byte[] decryptedResponse;
            decryptedResponse = desKlient.CreateDecryptor().TransformFinalBlock(encryptedResponse, 0, encryptedResponse.Length);
            String pergjigjaDekriptuar = Encoding.UTF8.GetString(decryptedResponse);
            Console.WriteLine("Pergjgja Dekriptuar : " + pergjigjaDekriptuar);
        }
    }
}