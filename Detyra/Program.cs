
using System;

namespace Detyra
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseManipulation db = new DatabaseManipulation();
            User user = db.getUserBills();
            foreach(var fatura in user.faturat){
                Console.WriteLine(fatura.llojiFatures + "  " + fatura.viti + " " + fatura.vleraEuro);
            }
        }
    }
}
