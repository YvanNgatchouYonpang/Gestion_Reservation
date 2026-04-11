using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class IndexModel : PageModel
    {
        public List<Voiture> Voitures { get; set; }

        [BindProperty(SupportsGet = true)]

        public int FiltreId { get; set; }


        private VoitureService service = new VoitureService();
        public void OnGet()
        {
            if (FiltreId !=0) 
            { 
                var Resultat = VoitureService.ObtnirSelonId(FiltreId);
                if (Resultat != null)
                {
                    Voitures = new List<Voiture> { Resultat };
                }
                else {
                    Voitures = VoitureService.ObtenirVoiture();
                }
            }
           
            
           // Voitures = service.GetAll();
            Voitures = VoitureService.ObtenirVoiture();
        }
    }
}
