using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AtelierAutov2
{
    class ManagementMasini
    {
        public List<Masina> Masini { get; set; }

        public Dictionary<int, int> LocatieMasina = new Dictionary<int, int>();  // id masina, id ang
        public Dictionary<int, DateTime> TimpReparatie = new Dictionary<int, DateTime>();  //id masina, data final reparatie

        public ManagementMasini()
        {
            Masini = new List<Masina>();
            incarcare();
            incrementare();

        }

        public void AdaugareMasina(Masina masina)
        {
            Masini.Add(masina);
        }

        public void AfisareMasina(int idMasina)
        {
            idMasina = VerificareIdMasina(idMasina);
            var masina = Masini.FirstOrDefault(x => x.Id == idMasina);
            if(masina.GetType()==typeof(Standard))
                Console.WriteLine("\nTip masina: Standard");
            if (masina.GetType() == typeof(Camion))
                Console.WriteLine("\nTip masina: Camion");
            if (masina.GetType() == typeof(Autobuz))
                Console.WriteLine("\nTip masina: Autobuz");
            Console.WriteLine("Masina cu ID: " + masina.Id);
            Console.WriteLine("Kilometraj: " + masina.Kilometraj);
            Console.WriteLine("Anul fabricatiei: " + masina.AnFabric);
            Console.WriteLine("Este diesel? " + masina.EsteDiesel);

            if (masina.GetType() == typeof(Standard))
            {
                var masina1 = Masini.OfType<Standard>().FirstOrDefault(x => x.Id == idMasina);
                if (masina1.EsteManual)
                    Console.WriteLine("Masina are transmisie manuala");
                else
                    Console.WriteLine("Masina are transmisie automata");
            }

            if (masina.GetType() == typeof(Autobuz))
            {
                var masina1 = Masini.OfType<Autobuz>().FirstOrDefault(x => x.Id == idMasina);
                Console.WriteLine("Nr locuri: " + masina1.NrLocuri);
            }
            if (masina.GetType() == typeof(Camion))
            {
                var masina1 = Masini.OfType<Camion>().FirstOrDefault(x => x.Id == idMasina);
                Console.WriteLine("Tonaj: " + masina1.Tonaj);
            }
        }

        public void StergereMasina(int idMasina)
        {
            Masini.RemoveAll(x =>
            {
                if (x.Id == idMasina)
                    return true;
                else
                    return false;
            });
        }

        public int VerificareIdMasina(int idMasina) // verifica daca ID-ul e corect
        {
            var masini = Masini.FirstOrDefault(x => x.Id == idMasina);
            if (masini == null)
                while (masini == null)
                {
                    Console.WriteLine("ID-ul introdus e gresit.");
                    Console.Write("Introdu alt ID: ");
                    var nr = Console.ReadLine();
                    int.TryParse(nr, out idMasina);
                    masini = Masini.FirstOrDefault(x => x.Id == idMasina);
                }
            return idMasina;
        }

        public void CalculPolita(int idMasina)
        {
            idMasina = VerificareIdMasina(idMasina);
            var masina = Masini.FirstOrDefault(x => x.Id == idMasina);
            if (masina.GetType() == typeof(Autobuz))
            {
                var masina1 = Masini.OfType<Autobuz>().FirstOrDefault(x => x.Id == idMasina);
                Double Valoare = (DateTime.Now.Year - masina1.AnFabric) * 200;
                Valoare += (masina1.EsteDiesel ? 500 : 0);
                Valoare += masina1.Kilometraj > 100000 && masina1.Kilometraj < 200000 ? 500 : 0;
                Valoare += masina1.Kilometraj > 200000 ? 100 : 0;
                Console.WriteLine(Valoare);
                if (masina1.Discount)
                    Valoare *= 0.9D;
                Console.WriteLine("Polita masinii cu ID-ul " + idMasina + " este in valoare de " + Valoare);
            }
            if (masina.GetType() == typeof(Standard))
            {
                var masina1 = Masini.OfType<Standard>().FirstOrDefault(x => x.Id == idMasina);
                Double Valoare = (DateTime.Now.Year - masina1.AnFabric) * 100;
                Valoare += (masina1.EsteDiesel ? 500 : 0);
                Valoare += masina1.Kilometraj > 200000 ? 500 : 0;

                if (masina1.Discount)
                    Valoare *= 0.95D;
                Console.WriteLine("Polita masinii cu ID-ul " + idMasina + " este in valoare de " + Valoare);
            }
            if (masina.GetType() == typeof(Camion))
            {
                var masina1 = Masini.OfType<Camion>().FirstOrDefault(x => x.Id == idMasina);
                Double Valoare = (DateTime.Now.Year - masina1.AnFabric) * 300;
                Valoare += masina1.Kilometraj > 200000 ? 700 : 0;
                Console.WriteLine(Valoare);
                if (masina1.Discount)
                    Valoare *= 0.85D;
                Console.WriteLine("Polita masinii cu ID-ul " + idMasina + " este in valoare de " + Valoare);

            }
        }

        public void incrementare()
        {
            var x = new Camion();
            x.incrementare(Masini.Count);

        }


        public DateTime DataReparatie(int IdMasina)
        {
            IdMasina = VerificareIdMasina(IdMasina);
            var rand = new Random();
            DateTime TimpDeReparatie = DateTime.Now;
            TimpDeReparatie.AddDays(rand.Next(1, 4));

            return TimpDeReparatie;

        }

        public void incarcare()
        {
            string filePath = "ListaMasini.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                Masini = (List<Masina>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        public void Salvare()
        {
            string filePath = "ListaMasini.dat";
            Serializator.Serialize(filePath, Masini);
        }


    }




}
