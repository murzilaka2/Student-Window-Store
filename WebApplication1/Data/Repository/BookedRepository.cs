namespace WebApplication1.Data.Repository
{
    public class BookedRepository : IBooked
    {
        private readonly AppDbContext appDbContext;

        public BookedRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Booked> Bookeds => appDbContext.Bookeds;

        public void AddBooked(Booked booked)
        {
            appDbContext.Bookeds.Add(booked);
            appDbContext.SaveChanges();
        }

        public void DeleteBooked(int id)
        {
            var currentBooked = GetById(id);
            if (currentBooked != null)
            {
                appDbContext.Bookeds.Remove(currentBooked);
                appDbContext.SaveChanges();
            }
        }
        public Booked GetById(int id)
        {
            return appDbContext.Bookeds.FirstOrDefault(e => e.Id == id);
        }
    }
}
