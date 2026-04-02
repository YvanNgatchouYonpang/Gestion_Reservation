using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models;
using GestionReservations.Services;

namespace GestionReservations.Pages.Voitures
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }

        private VoitureService service = new VoitureService();

        public IActionResult OnGet(int id)
        {
            Voiture = service.Get(id);

            if (Voiture == null)
                return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            if (Voiture.AnneeFabrication < DateTime.Now.Year - 10)
            {
                ModelState.AddModelError("", "La voiture doit avoir moins de 10 ans");
            }

            if (!ModelState.IsValid)
                return Page();

            service.Update(Voiture);
            return RedirectToPage("Index");
        }
    }
}
