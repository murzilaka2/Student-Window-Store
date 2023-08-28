namespace WebApplication1.Data.Interfaces
{
    public interface IBooked
    {
        IEnumerable<Booked> Bookeds { get; }
        Booked GetById(int id);
        void AddBooked(Booked booked);
        void DeleteBooked(int id);
    }
}
