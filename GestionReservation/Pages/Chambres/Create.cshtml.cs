using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models;
using GestionReservations.Services;

namespace GestionReservation.Pages.Chambres
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Chambre Chambre { get; set; }
        //ChambreService service = new ChambreService();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            //Validation des messages d'erreur
            //En cas d'erreur, on retourne l'utilisateur sur la page pour les corriger
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ChambreService.AddChambre(Chambre);

            //On retourne l'utilisateur vers Etudiants/Index pour afficher la liste 
            //Avec le nouvel étudiant 
            return RedirectToPage("Index");
        }
    }
}
