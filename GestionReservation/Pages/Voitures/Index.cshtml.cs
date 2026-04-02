using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class IndexModel : PageModel
    {
        public List<Voiture> Voitures { get; set; }
        private VoitureService service = new VoitureService();
        public void OnGet()
        {
            Voitures = service.GetAll();
        }
    }
}
