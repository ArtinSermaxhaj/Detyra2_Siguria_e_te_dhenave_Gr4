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
        public Server(){
            this.server = new UDP();
            server.Server("127.0.0.1", 27000);
        }
        public void ServerSend(string message){
            server.Send(message);
        }
        //public void ServerRecv() {
          //  server.Receive();
        //}
        public void ShtoCelesat() {
            string parametratXml = objRsa.ToXmlString(true);
            StreamWriter sw = new StreamWriter("celesat.xml");
            sw.Write(parametratXml);
            sw.Close();
        }
        public string Dekripto() {
            string kerkesa = server.ReceiveText();
            string[] vargu = kerkesa.Split('*');
            Console.WriteLine("IV = " + (vargu[0]) + ", gjatesia e vargut " + vargu.Length);
            byte[] initV = Convert.FromBase64String(vargu[0]);
            objDes.Key = initV;
            byte[] encryptedKey = Convert.FromBase64String(vargu[1]);
            c1.merrCelesat();
            byte[] desKey = objRsa.Decrypt(encryptedKey, true);
            objDes.Key = desKey;
            objDes.Mode = CipherMode.CBC;
            objDes.Padding = PaddingMode.PKCS7;
            byte[] encryptedMessage = Convert.FromBase64String(vargu[2]);
            MemoryStream ms = new MemoryStream(encryptedMessage);
            byte[] decryptedMessage = new byte[ms.Length];
            CryptoStream cs = new CryptoStream(ms, objDes.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(decryptedMessage, 0, decryptedMessage.Length);
            string mesazhi = BitConverter.ToString(decryptedMessage);
            Console.WriteLine(mesazhi);
            return mesazhi;
        }



    }
}