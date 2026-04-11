using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public Voiture Voiture { get; set; }
        public List <Marque> Marques { get; set; } = new ();

        private VoitureService service = new VoitureService();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Voiture.AnneeFabrication < DateTime.Now.Year - 10)
            {
                ModelState.AddModelError("", "Voiture trop ancienne");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            VoitureService.AddVoiture(Voiture);

            return RedirectToPage("./Index");
        }
    }
}
