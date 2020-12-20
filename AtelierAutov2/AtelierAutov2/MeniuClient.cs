using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace AtelierAutov2
{
    class MeniuClient
    {
        ManagementAngajati _manAng = new ManagementAngajati();
        ManagementMasini _manMas = new ManagementMasini();

        public void SalvareDictionare()
        {
            var LM = new FileStream("LocatieMasina.dat", FileMode.Create);
            var TR = new FileStream("TimpReparatie.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(LM, _manMas.LocatieMasina);
            formatter.Serialize(TR, _manMas.TimpReparatie);
            var AC = new FileStream("AngajatCamion.dat", FileMode.Create);
            var AA = new FileStream("AngajatAutobuz.dat", FileMode.Create);
            var AS = new FileStream("AngajatStandard.dat", FileMode.Create);
            formatter.Serialize(AC, _manAng.AngajatCamion);
            formatter.Serialize(AA, _manAng.AngajatAutobuz);
            formatter.Serialize(AS, _manAng.AngajatStandard);
        }
        public void IncarcareDictionare()
        {
            string filePath = "LocatieMasina.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manMas.LocatieMasina = (Dictionary<int,int>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
             filePath = "TimpReparatie.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manMas.TimpReparatie = (Dictionary<int, DateTime>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
             filePath = "AngajatCamion.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manAng.AngajatCamion = (Dictionary<int, int>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
             filePath = "AngajatAutobuz.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manAng.AngajatAutobuz = (Dictionary<int, int>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
             filePath = "AngajatStandard.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manAng.AngajatStandard = (Dictionary<int, int>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }

        }
        public MeniuClient()
        {
            incarcareMas();
            incarcareAng();

        }

        public void incarcareMas()
        {
            string filePath = "ListaMasini.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manMas.Masini = (List<Masina>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        public void incarcareAng()
        {
            string filePath = "ListaAngajati.dat";
            using (Stream fileStream = File.OpenRead(filePath))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                _manAng.Angajati = (List<Angajat>)deserializer.Deserialize(fileStream);
                fileStream.Close();
            }
        }
        public void AlegereAngajat(int IdMasina)
        {
           
            IdMasina = _manMas.VerificareIdMasina(IdMasina);
            Console.WriteLine("Introduceti id-ul angajatului:");
            int IdAngajat = int.Parse(Console.ReadLine());
            IdAngajat = _manAng.VerificareIdAng(IdAngajat);
            var masina = _manMas.Masini.FirstOrDefault(x => x.Id == IdMasina);
            var angajat = _manAng.Angajati.FirstOrDefault(x => x.Id == IdAngajat);
            if (masina.GetType()==typeof(Standard))
            {
                if (!_manAng.AngajatStandard.ContainsKey(angajat.Id))
                {
                    _manAng.AngajatStandard.Add(angajat.Id, 1);
                    _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                    _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                    Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                    Console.ReadKey();
                }
                else
                {
                    if (_manAng.AngajatStandard[angajat.Id] < 3)
                    {
                        _manAng.AngajatStandard[angajat.Id]++;
                        _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                        _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                        Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                        Console.ReadKey();
                    }
                    else
                    {
                        
                        DateTime minim = DateTime.Now.AddDays(5);

                        foreach (var value in _manMas.LocatieMasina)
                        {
                            if (value.Value == angajat.Id)
                                if (DateTime.Compare(minim, _manMas.TimpReparatie[value.Key]) > 0)
                                    minim = _manMas.TimpReparatie[value.Key];
            }
                        Console.WriteLine("angajatul nu poate primi momentan masini, acesta va fi liber la data de: "+minim);
                        Console.ReadKey();
                    }

                }
            }

            if (masina.GetType() == typeof(Camion))
            {

                if (!_manAng.AngajatCamion.ContainsKey(angajat.Id))
                {
                    _manAng.AngajatCamion.Add(angajat.Id, 1);
                    _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                    _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                    Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                    Console.ReadKey();
                }
                else
                {
                    DateTime final = _manMas.TimpReparatie[_manAng.AngajatCamion[angajat.Id]];

                    Console.WriteLine("angajatul nu poate primi momentan masini, acesta va fi liber la data de "+ final);
                    Console.ReadKey();
                }
            }

            if (masina.GetType() == typeof(Autobuz))
            {

                if (!_manAng.AngajatAutobuz.ContainsKey(angajat.Id))
                {
                    _manAng.AngajatAutobuz.Add(angajat.Id, 1);
                    _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                    _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                    Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                    Console.ReadKey();
                }
                else
                {
                    DateTime final = _manMas.TimpReparatie[_manAng.AngajatAutobuz[angajat.Id]];

                    Console.WriteLine("angajatul nu poate primi momentan masini, acesta va fi liber la data de "+ final);
                    Console.ReadKey();
                }
            }

               
        }

        public bool VerificareDisponibilitateAngajati(int IdMasina)
        {
            bool verif = false;
            IdMasina = _manMas.VerificareIdMasina(IdMasina);
            var masina = _manMas.Masini.FirstOrDefault(x => x.Id == IdMasina);
            foreach (var angajat in _manAng.Angajati)
            {
                if (masina.GetType() == typeof(Standard))
                {
                    if (!_manAng.AngajatStandard.ContainsKey(angajat.Id))
                    {
                        verif = true;
                        break;
                    }
                    else
                    {
                        int i;
                        _manAng.AngajatStandard.TryGetValue(angajat.Id, out i);
                        if (i < 3)
                        {
                            verif = true;
                            break;
                        }
                    }
                }

                if (masina.GetType() == typeof(Camion))
                {
                    if (!_manAng.AngajatCamion.ContainsKey(angajat.Id))
                    {
                        verif = true;
                    break;
                    }
                }

                if (masina.GetType() == typeof(Autobuz))
                {
                    if (!_manAng.AngajatAutobuz.ContainsKey(angajat.Id))
                    {
                        verif = true;
                        break;
                    }
                }

            }
            return verif;
        }

        public void AdaugareStandard(int IdMasina)
        {
            bool InLucru = false;
            IdMasina = _manMas.VerificareIdMasina(IdMasina);

            var masina = _manMas.Masini.FirstOrDefault(x => x.Id == IdMasina);
            foreach (var angajat in _manAng.Angajati)
            {
                if (!InLucru)
                {
                    if (masina.GetType() == typeof(Standard))
                    {

                        if (!_manAng.AngajatStandard.ContainsKey(angajat.Id))
                        {
                            _manAng.AngajatStandard.Add(angajat.Id, 1);
                            _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                            _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                            InLucru = true;
                            Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                            Console.ReadKey();
                        }
                        else
                        {
                          
                            
                            if (_manAng.AngajatStandard[angajat.Id] < 3)
                            {
                                _manAng.AngajatStandard[angajat.Id]++;
                                _manMas.LocatieMasina.Add(masina.Id,angajat.Id);
                                _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                                InLucru = true;
                                Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                                Console.ReadKey();
                            }

                        }

                    }
                    if (masina.GetType() == typeof(Camion))
                    {

                        if (!_manAng.AngajatCamion.ContainsKey(angajat.Id))
                        {
                            _manAng.AngajatCamion.Add(angajat.Id, 1);
                            _manMas.LocatieMasina.Add(masina.Id,angajat.Id);
                            _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                            Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                            Console.ReadKey();
                            InLucru = true;
                        }


                    }
                    if (masina.GetType() == typeof(Autobuz))
                    {

                        if (!_manAng.AngajatAutobuz.ContainsKey(angajat.Id))
                        {
                            _manAng.AngajatAutobuz.Add(angajat.Id, 1);
                            _manMas.LocatieMasina.Add(masina.Id, angajat.Id);
                            _manMas.TimpReparatie.Add(masina.Id, _manMas.DataReparatie(masina.Id));
                            Console.WriteLine("Masina a fost adaugata angajatului: " + angajat.Nume + " cu Id-ul:" + angajat.Id);
                            Console.ReadKey();
                            InLucru = true;
                        }


                    }
                }
            }

        }

      


    }
}
