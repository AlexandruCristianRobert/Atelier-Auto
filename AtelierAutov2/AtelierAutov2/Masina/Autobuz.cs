using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AtelierAutov2
{
    [Serializable()]
    public class Autobuz : Masina
    {
        public int NrLocuri;
        
        public Autobuz()
        {
            Id = Interlocked.Increment(ref NextId);
        }


        public override void Adaugare()
        {
            Console.WriteLine("Introdu kilometrajul masinii: ");
            Kilometraj = int.Parse(Console.ReadLine());

            Console.WriteLine("Introdu anul in care a fost facuta masina:");
            AnFabric = int.Parse(Console.ReadLine());

            Console.WriteLine("Masina este Diesel? Da sau nu");

            var raspuns = Console.ReadLine();
            EsteDiesel = raspuns.ToLower() == "da";

            Console.WriteLine("Cate locuri are autobuzul?");
            NrLocuri = int.Parse(Console.ReadLine());

            Console.WriteLine("Masina are discout?");
            raspuns = Console.ReadLine();
            Discount = raspuns.ToLower() == "da";

        }


    }
}
