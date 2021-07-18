using System.Net.Http;
namespace Detyra
{
    public class Client
    {
        private UDP client;
        public Client(){
            UDP client = new UDP();
            client.Client("127.0.0.1", 27000);
        }
        public void ClientSend(String message){
            client.Send(message);
        }
    }
}