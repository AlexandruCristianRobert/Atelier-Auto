using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierAutov2
{
    [Serializable()]
    public abstract class Masina
    {
        public int Id { get; set; }
        public static int NextId;
        public int Kilometraj { get; set; }
        public int AnFabric { get; set; }
        public bool EsteDiesel { get; set; }
        public bool Discount { get; set; }

        public abstract void Adaugare();

        public void incrementare(int i)
        {
            NextId = i;
            Console.WriteLine(NextId + " este next id");
        }

    }
}
