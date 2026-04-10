using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Chambres
{
    public class EditModel : PageModel
    {
        public Chambre Chambre { get; set; }
        public void OnGet(int? id)
        {
            Chambre = ChambreService.ObtnirSelonId(id.Value);
        }

        public IActionResult OnPost()
        {
            //Validation des messages d'erreur
            //En cas d'erreur, on retourne l'utilisateur sur la page pour les corriger
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ChambreService.UpdateChambre(Chambre);

            //On retourne l'utilisateur vers Etudiants/Index pour afficher la liste 
            //Avec le nouvel étudiant 
            return RedirectToPage("Index");
        }
    }
}
