namespace GestionReservation.Models
{
    public interface IReservation
    {
        int Id { get; set; }
        DateTime DateDebut { get; set; }
        DateTime DateFin{ get; set; }   
        int Prix { get; }
    }
}
