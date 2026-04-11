using System.Text.Json;
using GestionReservation.Models;

namespace GestionReservation.Services
{
    public class VoitureService
    {
        private static readonly string _path = @".\voitures.txt";


        private static List<Voiture> _voitures = ChargerLaListe();

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
                        Marque = attributs[1],
                        Description = attributs[3],
                        PrixJournalier = int.Parse(attributs[2]),
                        AnneeFabrication = int.Parse(attributs[4])
                    };

                    _voitures.Add(v);

                }
            }
            return _voitures;
        }

        //ajouter les informations dans le fichier et dans la liste
        public static void AddVoiture(Voiture voiture)
        {
            //ajouter si la chambre n'existe pas
            //if (!_voitures.Any(v => v.Id == voiture.Id))
            //{
                SaveVoiture(voiture);
                _voitures.Add(voiture);
            //}
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
                //SaveVoiture(v);
                RefreshFile();
            }

        }

        //suppression d'une voiture
        public static void DeleteVoiture(int id)
        {
            Voiture voiture = ObtnirSelonId(id);
            _voitures.Remove(voiture);
            RefreshFile();
        }

        public static void RefreshFile()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                foreach (Voiture v in _voitures)
                {
                    sw.WriteLine(v.Id + ";" + v.Marque + ";" + v.PrixJournalier + ";" + v.Description + ";" + v.AnneeFabrication);
                }
            }

        }

      
    }
}