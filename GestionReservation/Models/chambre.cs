using System.ComponentModel.DataAnnotations;

namespace GestionReservations.Models
{
    public class Chambre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, 500)]
        public int PrixJournalier { get; set; }
    }
}