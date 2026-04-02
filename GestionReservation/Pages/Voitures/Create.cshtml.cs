using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models;
using GestionReservations.Services;

namespace GestionReservation.Pages.Voitures
{
    
   

    public class CreateModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }

        private VoitureService service = new VoitureService();

        public IActionResult OnPost()
        {
            if (Voiture.AnneeFabrication < DateTime.Now.Year - 10)
            {
                ModelState.AddModelError("", "Voiture trop ancienne");
            }

            if (!ModelState.IsValid)
                return Page();

            service.Add(Voiture);
            return RedirectToPage("Index");
        }
    }
}
