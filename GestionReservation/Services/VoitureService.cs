using System.Text.Json;
using GestionReservations.Models;

namespace GestionReservations.Services
{
    public class VoitureService
    {
        private readonly string path = ".\\voitures.txt";

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
    }
}