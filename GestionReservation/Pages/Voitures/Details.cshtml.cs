using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models;
using GestionReservations.Services;
using global::GestionReservations.Models;
using global::GestionReservations.Services;

namespace GestionReservation.Pages.Voitures
{

   

    namespace GestionReservations.Pages.Voitures
    {
        public class DetailsModel : PageModel
        {
            public Voiture Voiture { get; set; }
            private VoitureService service = new VoitureService();

            public IActionResult OnGet(int id)
            {
                Voiture = service.Get(id);

                if (Voiture == null)
                    return RedirectToPage("Index");

                return Page();
            }
        }
    }
}
