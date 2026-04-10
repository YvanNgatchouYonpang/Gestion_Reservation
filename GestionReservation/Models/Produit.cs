using System.ComponentModel.DataAnnotations;

namespace GestionReservation.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, 500)]
        public int PrixJournalier { get; set; }
    }
}
