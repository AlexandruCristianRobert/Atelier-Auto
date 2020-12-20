using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierAutov2
{
    class Program
    {
        static void Main(string[] args)
        {

            var _ManAng = new ManagementAngajati();
            var Meniu = new MeniuClient();
            var _ManMas = new ManagementMasini();
            _ManAng.incarcare();
            _ManMas.incarcare();
            Meniu.IncarcareDictionare();
            while (true)
            {
                bool InchidereProgram = true;
                Console.Clear();
                Console.WriteLine("\n----------Meniu Principal----------");
                Console.WriteLine("1 Management Angajati");
                Console.WriteLine("2 Vezi daca este deschis");
                Console.WriteLine("3 Pentru a iesi");
                var optiune1 = Console.ReadLine();
                int.TryParse(optiune1, out var result1);

                switch (result1)
                {
                    case 1:
                        while (true)
                        {
                            bool repetare = true;
                            Console.Clear();
                            Console.WriteLine("1.Logare");
                            Console.WriteLine("2.Revenire la meniul principal");
                            string option = Console.ReadLine();
                            int.TryParse(option, out var raspuns);
                            string parola = "parola";
                            switch (raspuns)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.Write("Introduceti parola:");
                                    string introducere = Console.ReadLine();
                                    if (introducere == parola)
                                    {
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n----------Meniu Angajati----------");
                                            Console.WriteLine("1 - Adaugare Angajat");
                                            Console.WriteLine("2 - Afisare Angajat");
                                            Console.WriteLine("3 - Editare Angajat");
                                            Console.WriteLine("4 - Stergere Angajat");
                                            Console.WriteLine("5 - Afisare Salariu Angajat");
                                            Console.WriteLine("6 - Revenine la meniul principal");
                                            var optiune2 = Console.ReadLine();
                                            int.TryParse(optiune2, out var result2);
                                            bool inchidere = false;
                                            switch (result2)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    Console.WriteLine("\nAlegere tip angajat:");
                                                    Console.WriteLine("1 - Director");
                                                    Console.WriteLine("2 - Mecanic");
                                                    Console.WriteLine("3 - Asistent");
                                                    var optiune3 = Console.ReadLine();
                                                    int.TryParse(optiune3, out var result3);
                                                    switch (result3)
                                                    {
                                                        case 1:
                                                            var director = new Director();
                                                            director.Adaugare();
                                                            _ManAng.AdaugaAngajat(director);
                                                            break;
                                                        case 2:
                                                            var mecanic = new Mecanic();
                                                            mecanic.Adaugare();
                                                            _ManAng.AdaugaAngajat(mecanic);
                                                            break;
                                                        case 3:
                                                            var asistent = new Asistent();
                                                            asistent.Adaugare();
                                                            _ManAng.AdaugaAngajat(asistent);
                                                            break;
                                                        default:
                                                            break;
                                                    }
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    Console.WriteLine("\nIntrodu ID-ul angajatului:");
                                                    int IDselectat = int.Parse(Console.ReadLine());
                                                    _ManAng.AfisareAngajat(IDselectat);
                                                    Console.WriteLine("Apasati pentru a continua");
                                                    Console.ReadKey();
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    Console.WriteLine("\nIntrodu ID-ul angajatului:");
                                                    int IDselectat1 = int.Parse(Console.ReadLine());
                                                    _ManAng.EditareAngajat(IDselectat1);
                                                    Console.WriteLine("Apasati pentru a continua");
                                                    Console.ReadKey();
                                                    break;
                                                case 4:
                                                    Console.Clear();
                                                    Console.WriteLine("\nIntrodu ID-ul angajatului:");
                                                    int IDselectat2 = int.Parse(Console.ReadLine());
                                                    _ManAng.StergereAngajat(IDselectat2);
                                                    Console.WriteLine("Apasati pentru a continua");
                                                    Console.ReadKey();
                                                    break;
                                                case 5:
                                                    Console.Clear();
                                                    Console.WriteLine("\nIntrodu ID-l angajatului:");
                                                    int IDselectat3 = int.Parse(Console.ReadLine());
                                                    _ManAng.CalculSalarial(IDselectat3);
                                                    Console.WriteLine("Apasati pentru a continua");
                                                    Console.ReadKey();
                                                    break;
                                                case 6:
                                                    inchidere = true;
                                                    repetare = false;
                                                    break;
                                                default:
                                                    break;
                                            }
                                            if (inchidere)
                                                break;
                                        }
                                    }
                                    else
                                    {

                                        Console.WriteLine("Parola introdusa e gresita");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    repetare = false;
                                    break;
                                default:
                                    break;
                            }
                            if (!repetare)
                                break;
                        }
                        break;

                    case 2:
                        Console.Clear();
                        int ProgramDeLucru = 0;
                        if (_ManAng.EsteDeschis())
                        {

                            ProgramDeLucru = 1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("\n---------Atelierul auto este inchis---------");
                            Console.WriteLine("Apasati pentru a continua");
                            Console.ReadKey();
                            ProgramDeLucru = 0;
                        }
                        switch (ProgramDeLucru)
                        {
                            case 1:
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("---------Atelierul auto este deschis---------");
                                    bool rulare = true;
                                    Console.WriteLine("\n---------Optiuni---------");
                                    Console.WriteLine("1 Adaugare Masina");
                                    Console.WriteLine("2 Afisare Masina");
                                    Console.WriteLine("3 Vezi cat costa polita masinii");
                                    Console.WriteLine("4 Verificare disponibilitate angajati");
                                    Console.WriteLine("5 Adauga la un angajat specific");
                                    Console.WriteLine("6 Adauga la primul angajat disponibil");
                                    Console.WriteLine("7 Revenire la meniul principal");
                                    var optiune5 = Console.ReadLine();
                                    int.TryParse(optiune5, out var result5);
                                    switch (result5)
                                    {
                                        case 1:
                                            Console.Clear();
                                            Console.WriteLine("Alege tipul de masina");
                                            Console.WriteLine("1 - Masina Standard");
                                            Console.WriteLine("2 - Masina Autobuz");
                                            Console.WriteLine("3 - Masina Camion");
                                            var optiune4 = Console.ReadLine();
                                            int.TryParse(optiune4, out var result4);
                                            switch (result4)
                                            {
                                                case 1:
                                                    Console.Clear();
                                                    var standard = new Standard();
                                                    standard.Adaugare();
                                                    _ManMas.AdaugareMasina(standard);
                                                    break;
                                                case 2:
                                                    Console.Clear();
                                                    var autobuz = new Autobuz();
                                                    autobuz.Adaugare();
                                                    _ManMas.AdaugareMasina(autobuz);
                                                    break;
                                                case 3:
                                                    Console.Clear();
                                                    var camion = new Camion();
                                                    camion.Adaugare();
                                                    _ManMas.AdaugareMasina(camion);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Console.WriteLine("Introdu ID-ul masinii");
                                            int idMasina3 = int.Parse(Console.ReadLine());
                                            _ManMas.AfisareMasina(idMasina3);
                                            Console.WriteLine("Apasati pentru a continua");
                                            Console.ReadKey();
                                            break;

                                        case 3:
                                            Console.Clear();
                                            Console.WriteLine("Introdu ID-ul masinii");
                                            int idMasina2 = int.Parse(Console.ReadLine());
                                            _ManMas.CalculPolita(idMasina2);
                                            Console.WriteLine("Apasati pentru a continua");
                                            Console.ReadKey();
                                            break;
                                        case 4:
                                            Console.Clear();
                                            Console.WriteLine("Masina trebuie inscrisa prima data pentru a cunoaste ID-ul");
                                            Console.WriteLine("Daca nu ati introdus masina tastati 1 pentru a CONTINUA si 0 pentru a IESI");
                                            int verificare = int.Parse(Console.ReadLine());
                                            if (verificare == 0)
                                                break;
                                            Console.WriteLine("Introduceti id-ul masinii:");
                                            int idMasina4 = int.Parse(Console.ReadLine());
                                            if (!Meniu.VerificareDisponibilitateAngajati(idMasina4))
                                            {
                                                Console.WriteLine("Atelierul este plin, puteti astepta pana maine cand se va elibera un loc sau puteti sa scoateti masina");
                                                Console.ReadKey();
                                            }
                                            else
                                                Console.WriteLine("Mai sunt locuri libere.");
                                            Console.ReadKey();
                                            break;
                                        case 5:
                                            Console.Clear();

                                            Console.WriteLine("introdu ID-ul masinii");
                                            int idMasina5 = int.Parse(Console.ReadLine());
                                            Meniu.AlegereAngajat(idMasina5);

                                            break;

                                        case 6:
                                            Console.Clear();

                                            Console.WriteLine("introdu ID-ul masinii");
                                            int idMasina6 = int.Parse(Console.ReadLine());
                                            Meniu.AdaugareStandard(idMasina6);

                                            break;

                                        case 7:
                                            rulare = false;
                                            break;


                                        default:
                                            break;

                                    }
                                    if (!rulare)
                                        break;
                                }
                                break;
                        }
                        break;
                    case 3:
                        InchidereProgram = false;
                        break;
                    default:
                        break;

                }
                if (!InchidereProgram)
                {
                    Console.Clear();
                    Console.WriteLine("O zi frumoasa");
                    Console.WriteLine("Apasati o tasta pentru a inchide");
                    Console.ReadKey();
                    break;
                }

            }

            _ManAng.Salvare();
            _ManMas.Salvare();

            Meniu.SalvareDictionare();


        }
    }
}
