using System.Text.Json;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class ChambreService
    {
        private readonly string path = ".\\chambres.txt";

        private static List<Chambre> _chambres = new List<Chambre>
        {
            new Chambre {Id=1,Description="desctription chambre 1",PrixJournalier=200 },
            new Chambre{Id=2,Description="desctription chambre 2",PrixJournalier=150 },
            new Chambre{Id=3,Description="desctription chambre 3",PrixJournalier=120 },
        };


        public static void ChargerLaListe()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }


        public List<Chambre> GetAll()
        {
            if (!File.Exists(path))
                return new List<Chambre>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Chambre>>(json) ?? new List<Chambre>();
        }

        public void Save(List<Chambre> list)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(list));
        }

        public void Add(Chambre c)
        {
            var list = GetAll();
            c.Id = list.Any() ? list.Max(x => x.Id) + 1 : 1;
            list.Add(c);
            Save(list);
        }

        public Chambre Get(int id) => GetAll().FirstOrDefault(x => x.Id == id);

        public void Update(Chambre c)
        {
            var list = GetAll();
            var index = list.FindIndex(x => x.Id == c.Id);
            if (index != -1)
            {
                list[index] = c;
                Save(list);
            }
        }

        public void Delete(int id)
        {
            var list = GetAll();
            list.RemoveAll(x => x.Id == id);
            Save(list);
        }

        public static List<Chambre> ObtenirChambre()
        {
            return _chambres;
        }

        public static Chambre? obtnirSelonId(int id)
        {
            return _chambres.SingleOrDefault(x => x.Id == id);
        }

    }
}
