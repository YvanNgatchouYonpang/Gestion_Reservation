using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class IndexModel : PageModel
    {
        public List<Voiture> Voitures { get; set; }

        [BindProperty(SupportsGet = true)]

        public string  FiltreMarquePrix { get; set; }


        private VoitureService service = new VoitureService();
        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(FiltreMarquePrix)) { Voitures = VoitureService.ObtenirVoiture(); }
            else
            {
                Voitures = VoitureService.ObtenirSelonId(FiltreMarquePrix);
            }
            
            Voitures = service.GetAll();
            Voitures = VoitureService.ObtenirVoiture();
        }
    }
}
