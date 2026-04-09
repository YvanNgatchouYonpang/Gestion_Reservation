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
            Chambre = ChambreService.obtnirSelonId(id.Value);
        }
    }
}
