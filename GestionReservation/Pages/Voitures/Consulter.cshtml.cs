using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class ConsulterModel : PageModel
    {
        public Voiture Voiture { get; set; }
        private VoitureService service = new VoitureService();
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var voiture = VoitureService.ObtnirSelonId(id.Value);
            

            if (voiture == null)
            {
                return NotFound();
            }

            Voiture = voiture;
            return Page();
        }
    }
}
