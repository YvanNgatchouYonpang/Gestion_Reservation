using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Chambres
{
    public class IndexModel : PageModel
    {
        public List<Chambre> Chambres { get; set; }
        public void OnGet()
        {
            Chambres = ChambreService.ObtenirChambre();
        }
    }
}
