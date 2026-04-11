using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }
        public ActionResult OnGet(int? id)
        {
            //On retourne une erreur HTTP 404 NOT Found si l'ID est nul
            if (id == null)
            {
                return NotFound();
            }
            var voiture = VoitureService.ObtnirSelonId(id.Value);
            //On retourne une erreur HTTP 404 NOT Found si on ne trouve pas d'etudiant correspondant à l'ID
            if (voiture == null)
            {
                return NotFound();
            }

            Voiture = voiture;
            return Page();
        }

        public ActionResult OnPost()
        {
            VoitureService.DeleteVoiture(Voiture.Id);

            //Avec le nouvel étudiant 
            return RedirectToPage("./Index");
        }
    }
}
