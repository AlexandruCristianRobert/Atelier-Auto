using System;

namespace AtelierAutov2
{
    [Serializable]
    public abstract class Angajat
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNasterii { get; set; }
        public DateTime DataAngajarii { get; set; }
        public double CoefAng { get; set; }

        public static int NextId;
        public void Adaugare()
        {
            Console.WriteLine("Introdu numele angajatului: ");
            Nume = Console.ReadLine();
            if (!VerificareNume(Nume))
            {
                while (!VerificareNume(Nume))
                {
                    Console.WriteLine("Numele introdus e gresit, te rugam sa introduci alt nume: ");
                    Nume = Console.ReadLine();
                }
            }

            Console.WriteLine("Introdu prenumele angajatului: ");
            Prenume = Console.ReadLine();
            if (!VerificareNume(Prenume))
            {
                while (!VerificareNume(Prenume))
                {
                    Console.WriteLine("Prenumele introdus e gresit, te rugam sa introduci alt prenume: ");
                    Prenume = Console.ReadLine();
                }
            }

            Console.WriteLine("Introdu data nasterii: ");
            DataNasterii = DateTime.Parse(Console.ReadLine());
            if (!VerifVarsta(DataNasterii, DateTime.Now))
            {
                Console.WriteLine(Nume + " " + Prenume + " nu a implinit inca 18 ani si nu poate fi angajat");

                // stergere 
            }
            else
            {
                Console.WriteLine("Introdu data angajarii: ");
                DataAngajarii = DateTime.Parse(Console.ReadLine());
                if (VerifDataViitor(DataAngajarii, DateTime.Now))
                {
                    while (!VerifDataViitor(DataAngajarii, DateTime.Now) || !VerifVarsta(DataNasterii, DataAngajarii))
                    {
                        Console.WriteLine("Data angajarii nu poate fi in viitor si angajatul trebuie sa aiba  18 ani in momentul angajarii, introdu alta data ");
                        DataAngajarii = DateTime.Parse(Console.ReadLine());
                    }
                }

            }

        }

        public bool VerificareNume(string Nume)
        {
            if (Nume == "" || Nume.Length > 30)
                return false;
            return true;
        }

        public bool VerifVarsta(DateTime TimpNastere, DateTime Prezent)
        {
            if ((Prezent - TimpNastere).TotalDays < 6570)
                return false;
            return true;
        }

        public bool VerifDataViitor(DateTime Prezent, DateTime Viitor)
        {
            if (DateTime.Compare(Prezent, Viitor) > 0)
                return false;
            return true;
        }

        public double Vechime()
        {
            var Vechime = (DateTime.Now - DataAngajarii).TotalDays / 365;
            return Vechime;
        }

        public void incrementare(int i)
        {
            NextId = i;
            Console.WriteLine(NextId+" este next id");
        }
    }
}
