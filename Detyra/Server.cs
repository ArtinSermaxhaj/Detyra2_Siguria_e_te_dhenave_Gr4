using System.Net.Security;
namespace Detyra
{
    public class Server
    {
        private UDP server;
        public Server(){
            UDP server = new UDP();
            server.Server("127.0.0.1", 27000);
        }
        public void ServerSend(String message){
            server.Send(message);
        }
    }
}