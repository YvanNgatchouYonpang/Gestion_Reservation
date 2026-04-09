using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models;

namespace GestionReservation.Pages.Chambres
{
    public class CreateModel : PageModel
    {
        public Chambre Chambre { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            return RedirectToPage("Index");
        }
    }
}
