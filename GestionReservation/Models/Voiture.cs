using System.ComponentModel.DataAnnotations;

namespace GestionReservation.Models
{
    public class Voiture:Produit
    {
        private static int _id=0;
        [Required]
        public string Marque { get; set; }

        [Required]
        public int AnneeFabrication { get; set; }

        public Voiture()
        {
            Id = ++_id;
        }

        public static void RefrechId()
        {
            _id--;
        }
    }
}
