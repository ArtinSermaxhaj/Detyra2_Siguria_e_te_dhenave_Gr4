
using System;

namespace Detyra
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            s.ShtoCelesat();
            Client c1 = new Client();
            c1.ClientSend();
            s.Dekripto();
            
        }
    }
}
