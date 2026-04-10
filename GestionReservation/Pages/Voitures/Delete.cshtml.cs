using GestionReservation.Models;
using GestionReservation.Services;
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

        //public void OnGet(int id)
        //{
        //    voiture = VoitureService.Get(id);
        //}
        //public IActionResult Onpost(int id)
        //{
        //    VoitureService.
        //    return RedirectToPage("Index");
        //}
    }
}
