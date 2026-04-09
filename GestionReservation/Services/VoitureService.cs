using System.Text.Json;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class VoitureService
    {
        private readonly string path = ".\\voitures.txt";

        private static List<Voiture> _voitures = new List<Voiture>
        {

            new Voiture { Id = 1, Marque= Marque.Kia,  PrixJournalier = 150, Description = "description voiture1", AnneeFabrication = 2010 },
            new Voiture { Id = 2, Marque = Marque.Toyota, PrixJournalier = 25, Description = "description voiture2", AnneeFabrication = 2020},
             new Voiture { Id = 3, Marque = Marque.Ford, PrixJournalier = 70, Description = "description voiture3", AnneeFabrication = 2022 },
        };
        public List<Voiture> GetAll()
        {
            if (!File.Exists(path))
                return new List<Voiture>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Voiture>>(json) ?? new List<Voiture>();
        }

        public void Save(List<Voiture> list)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(list));
        }

        public void Add(Voiture v)
        {
            var list = GetAll();
            v.Id = list.Any() ? list.Max(x => x.Id) + 1 : 1;
            list.Add(v);
            Save(list);
        }

        public Voiture Get(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public void Update(Voiture v)
        {
            var list = GetAll();
            var index = list.FindIndex(x => x.Id == v.Id);
            if (index != -1)
            {
                list[index] = v;
                Save(list);
            }
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            Save(list);
        }

       /* public void Afficher(Voiture v)
        {
            if (!File.Exists(".\\voitures.txt"))
            {
                File.Create(".\\voitures.txt").Close();
            }
        }*/
       public static List<Voiture> ObtenirVoiture()
        {
            return _voitures;
        }
       public static Voiture? ObtenirSelonId(int id)
        {
            return _voitures.FirstOrDefault(x => x.Id == id);
        }
    }
}