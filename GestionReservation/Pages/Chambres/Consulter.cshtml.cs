using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Chambres
{
    public class ConsulterModel : PageModel
    {
        public Chambre Chambre { get; set; }
        public void OnGet(int? id)
        {
            Chambre = ChambreService.ObtnirSelonId(id.Value);
        }
    }
}
