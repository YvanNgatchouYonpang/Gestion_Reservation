using GestionReservations.Models;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservation.Pages.Voitures
{

    public class DeleteModel : PageModel
    {
        private readonly VoitureService service;
        public Voiture voiture { get; set; }
        public DeleteModel()
        {
            service = new VoitureService();
        }

        public void OnGet(int id)
        {
            voiture = service.Get(id);
        }
        public IActionResult Onpost(int id)
        {
            service.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
