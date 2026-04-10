namespace GestionReservation.Models
{
    public class ReservationVoiture:IReservation
    {
        private static Random rand = new Random();
        private int _prix;
        public int Id { get; set; }
        public DateTime DateDebut { get; set;}
        public DateTime DateFin {  get; set;}
        public Produit Article { get; set;} 
        public int Prix 
        {
            get
            {
                TimeSpan duree =  this.DateFin - this.DateDebut;
                _prix = (int)Math.Ceiling(duree.TotalDays) * this.Article.PrixJournalier;
                return _prix;
            }
            set=>_prix = value;   
        }

        public ReservationVoiture()
        {
            this.Id=rand.Next(1,100);
        }

    }
}
