using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }

        private VoitureService service = new VoitureService();

        public void OnGet(int id)
        {
            Voiture = VoitureService.ObtnirSelonId(id);

        }

        public IActionResult OnPost()
        {
            if (Voiture.AnneeFabrication < DateTime.Now.Year - 10)
            {
                ModelState.AddModelError("", "La voiture doit avoir moins de 10 ans");
            }

            if (!ModelState.IsValid)
                return Page();

            VoitureService.UpdateVoiture(Voiture);
            return RedirectToPage("Index");
        }
    }
}

