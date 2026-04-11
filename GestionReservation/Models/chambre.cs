using GestionReservation.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionReservation.Models
{
    public class Chambre:Produit
    {
        private static int _id=0;

        public Chambre()
        {
            Id = ++_id;
        }

        public static void RefrechId()
        {
            _id--;
        }
    }
}