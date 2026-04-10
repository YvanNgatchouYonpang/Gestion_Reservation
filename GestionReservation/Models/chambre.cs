using GestionReservation.Models;
using System.ComponentModel.DataAnnotations;

namespace GestionReservations.Models
{
    public class Chambre:Article
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