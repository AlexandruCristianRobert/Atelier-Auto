using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AtelierAutov2
{
    public class ManagementAngajati : ISerializable
    {
        public List<Angajat> Angajati { get; set; }

        public Dictionary<int, int> AngajatCamion = new Dictionary<int, int>(); // ID ang, id masina
        public Dictionary<int, int> AngajatAutobuz = new Dictionary<int, int>();// ID ang, id masina
        public Dictionary<int, int> AngajatStandard = new Dictionary<int, int>();// ID ang, nr de masini standard


        public ManagementAngajati()
        {
            Angajati = new List<Angajat>();
            incarcare();
            incrementare();
        }

        public void incrementare()
        {
            var x = new Director();
            x.incrementare(Angajati.Count);

        }
        public bool EsteDeschis()
        {
            return Angajati.Count > 0;
        }

        public void AdaugaAngajat(Angajat angajat)
        {
            Angajati.Add(angajat);
        }

        public void AfisareAngajat(int idAngajat)
        {
            idAngajat = VerificareIdAng(idAngajat);
            var angajati = Angajati.FirstOrDefault(x => x.Id == idAngajat);
            Console.WriteLine("\nAngajatul cu ID: " + angajati.Id);
            Console.WriteLine("Nume: " + angajati.Nume);
            Console.WriteLine("Prenume: " + angajati.Prenume);
            Console.WriteLine("Data nasterii: " + angajati.DataNasterii);
            Console.WriteLine("Data angajarii: " + angajati.DataAngajarii + "\n");

        }

        public void StergereAngajat(int idAngajat)
        {
            idAngajat = VerificareIdAng(idAngajat);
            Angajati.RemoveAll(x =>
            {
                if (x.Id == idAngajat)
                    return true;
                else
                    return false;
            });
        }

        public void EditareAngajat(int idAngajat)
        {
            idAngajat = VerificareIdAng(idAngajat);
            var angajati = Angajati.FirstOrDefault(x => x.Id == idAngajat);
            Console.WriteLine("\nOptiuni de editare: ");
            Console.WriteLine("1.Nume:");
            Console.WriteLine("2.Prenume:");
            var optiune = Console.ReadLine();
            int.TryParse(optiune, out var result);
            switch (result)
            {
                case 1:
                    Console.WriteLine("Introdu numele angajatului: ");
                    angajati.Nume = Console.ReadLine();
                    if (!angajati.VerificareNume(angajati.Nume))
                    {
                        while (!angajati.VerificareNume(angajati.Nume))
                        {
                            Console.WriteLine("Numele introdus e gresit, te rugam sa introduci alt nume: ");
                            angajati.Nume = Console.ReadLine();
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Introdu prenumele angajatului: ");
                    angajati.Prenume = Console.ReadLine();
                    if (!angajati.VerificareNume(angajati.Prenume))
                    {
                        while (!angajati.VerificareNume(angajati.Prenume))
                        {
                            Console.WriteLine("Prenumele introdus e gresit, te rugam sa introduci alt prenume: ");
                            angajati.Prenume = Console.ReadLine();
                        }
                    }
                    break;
                default:
                    break;
            }

        }


        public void CalculSalarial(int idAngajat)
        {
            idAngajat = VerificareIdAng(idAngajat);
            var angajati = Angajati.FirstOrDefault(x => x.Id == idAngajat);
            Console.WriteLine("Salariul angajatului " + idAngajat + " este de : " + (angajati.Vechime() * 1000 * angajati.CoefAng) + " RON");
        }

        public int VerificareIdAng(int idAngajat)// verifica daca ID-ul e corect
        {
            var angajati = Angajati.FirstOrDefault(x => x.Id == idAngajat);
            if (angajati == null)
                while (angajati == null)
                {
                    Console.WriteLine("ID-ul introdus e gresit.");
                    Console.Write("Introdu alt ID: ");
                    var nr = Console.ReadLine();
                    int.TryParse(nr, out idAngajat);
                    angajati = Angajati.FirstOrDefault(x => x.Id == idAngajat);
                }
            return idAngajat;
        }

        public void Afisare()
        {
            Console.WriteLine(Angajati.Count);
        }
        public void incarcare()
        {
            string filePath = "ListaAngajati.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                Angajati = (List<Angajat>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        public void Salvare()
        {
            string filePath = "ListaAngajati.dat";
            Serializator.Serialize(filePath, Angajati);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
