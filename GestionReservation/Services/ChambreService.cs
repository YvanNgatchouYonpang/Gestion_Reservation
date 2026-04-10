using System.Text.Json;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class ChambreService
    {
        private static readonly string _path = @".\chambres.txt";

        private static List<Chambre> _chambres = ChargerLaListe();

        //{
        //    new Chambre {Id=1,Description="desctription chambre 1",PrixJournalier=200 },
        //    new Chambre{Id=2,Description="desctription chambre 2",PrixJournalier=150 },
        //    new Chambre{Id=3,Description="desctription chambre 3",PrixJournalier=120 },
        //};


        public static List<Chambre> ChargerLaListe()
        {
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
            _chambres = new List<Chambre>();
            using(StreamReader sr = new StreamReader(_path))
            {
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    string[] attributs = ligne.Split(";");

                    Chambre chambre = new Chambre()
                    {
                        Id = int.Parse(attributs[0]),
                        Description = attributs[1],
                        PrixJournalier = int.Parse(attributs[2])
                    };

                    _chambres.Add(chambre);                      

                }
            }
            return _chambres;
        }

        //ajouter les informations dans le fichier et dans la liste
        public static void AddChambre(Chambre chambre)
        {
            //ajouter si la chambre n'existe pas
            if (!_chambres.Any(c => c.Id == chambre.Id))
            {
                SaveChambre(chambre);
                _chambres.Add(chambre);
            }
        }

        //enregistrer une chambre dans le fichier
        public static void SaveChambre(Chambre chambre)
        {
            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(chambre.Id+";"+chambre.Description+";"+chambre.PrixJournalier);
            }
        }
        public static List<Chambre> ObtenirChambre()
        {
            return _chambres.ToList();
        }

        public static Chambre ObtnirSelonId(int id)
        {
            return _chambres.SingleOrDefault(x => x.Id == id);
        }


        public static void UpdateChambre(Chambre chambre)
        {
            Chambre? chamb = ObtnirSelonId(chambre.Id);
            if (chamb != null)
            {
                chamb.Description= chambre.Description;
                chamb.PrixJournalier=chambre.PrixJournalier;
                SaveChambre(chambre);
            }

        }
    }
}
