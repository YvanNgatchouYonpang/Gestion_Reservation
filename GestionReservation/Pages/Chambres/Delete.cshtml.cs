using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Chambres
{
    public class SuppModel : PageModel
    {
        [BindProperty]
        public Chambre Chambre { get; set; }
        public ActionResult OnGet(int? id)
        {
            //On retourne une erreur HTTP 404 NOT Found si l'ID est nul
            if (id == null)
            {
                return NotFound();
            }
            var chambre = ChambreService.ObtnirSelonId(id.Value);
            //On retourne une erreur HTTP 404 NOT Found si on ne trouve pas d'etudiant correspondant à l'ID
            if (chambre == null)
            {
                return NotFound();
            }

            Chambre = chambre;
            return Page();
        }

        public ActionResult OnPost()
        {
            ChambreService.DeleteChambre(Chambre.Id);

            //Avec le nouvel étudiant 
            return RedirectToPage("./Index");
        }
    }
}
