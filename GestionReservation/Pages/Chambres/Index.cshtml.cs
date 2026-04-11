using GestionReservation.Models;
using GestionReservation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Chambres
{
    public class IndexModel : PageModel
    {
        public List<Chambre> Chambres { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Prix {  get; set; }
        
        public void OnGet()
        {
            if (Prix != 0)
            {
                Chambres = ChambreService.Recherche(Prix);
            }
            else
            {
                Chambres = ChambreService.ObtenirChambre();
            }
        }
    }
}
