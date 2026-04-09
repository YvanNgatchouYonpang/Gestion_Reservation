using System.ComponentModel.DataAnnotations;

namespace GestionReservations.Models
{
    public class Voiture
    {
        public int Id { get; set; }

        [Required]
        public Marque Marque { get; set; }

        [Range(0, 500)]
        public int PrixJournalier { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int AnneeFabrication { get; set; }
    }
}
