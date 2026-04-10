using System.Text.Json;
using GestionReservation.Models;

namespace GestionReservation.Services
{
    public class VoitureService
    {
        private static readonly string _path = @".\voitures.txt";


        private static List<Voiture> _voitures = ChargerLaListe();
        //private static List<Voiture> _voitures = new List<Voiture>
        //{

        //    new Voiture { Id = 1, Marque= Marque.Kia,  PrixJournalier = 150, Description = "description voiture1", AnneeFabrication = 2010 },
        //    new Voiture { Id = 2, Marque = Marque.Toyota, PrixJournalier = 25, Description = "description voiture2", AnneeFabrication = 2020},
        //     new Voiture { Id = 3, Marque = Marque.Ford, PrixJournalier = 70, Description = "description voiture3", AnneeFabrication = 2022 },
        //};

        public static List<Voiture> ChargerLaListe()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
            _voitures = new List<Voiture>();
            using (StreamReader sr = new StreamReader(_path))
            {
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    string[] attributs = ligne.Split(";");

                    Voiture v = new Voiture()
                    {
                        Id = int.Parse(attributs[0]),
                        Marque = (Marque)int.Parse(attributs[1]),
                        Description = attributs[2],
                        PrixJournalier = int.Parse(attributs[3]),
                        AnneeFabrication = int.Parse(attributs[4])
                    };

                    _voitures.Add(v);

                }
            }
            return _voitures;
        }

        //ajouter les informations dans le fichier et dans la liste
        public static void AddVoiture(Voiture v)
        {
            //ajouter si la chambre n'existe pas
            if (!_voitures.Any(v => v.Id == v.Id))
            {
                SaveVoiture(v);
                _voitures.Add(v);
            }
        }

        //enregistrer une chambre dans le fichier
        public static void SaveVoiture(Voiture v)
        {
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(v.Id + ";" + v.Marque + ";" + v.PrixJournalier + ";" + v.Description + ";" + v.AnneeFabrication);
            }
        }
        public static List<Voiture> ObtenirVoiture()
        {
            return _voitures.ToList();
        }

        public static Voiture ObtnirSelonId(int id)
        {
            return _voitures.SingleOrDefault(x => x.Id == id);
        }


        public static void UpdateVoiture(Voiture v)
        {
            Voiture? voit = ObtnirSelonId(v.Id);
            if (voit != null)
            {
                voit.Id = v.Id;
                voit.Marque = v.Marque;
                voit.Description = v.Description;
                voit.PrixJournalier = v.PrixJournalier;
                voit.AnneeFabrication = v.AnneeFabrication;
                SaveVoiture(v);
            }

        }
    }
}