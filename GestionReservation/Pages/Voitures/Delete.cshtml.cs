using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{
  
    public class DeleteModel : PageModel
    {
        private readonly VoitureService service;
        public DeleteModel()
        {
            service = new VoitureService();
        }

        public void OnGet()
        {
        }
    }
}
