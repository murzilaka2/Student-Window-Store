namespace WebApplication1.Data.Repository
{
    public class FeedBackRepository : IFeedBack
    {
        private readonly AppDbContext appDbContext;

        public FeedBackRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<FeedBack> FeedBacks => appDbContext.FeedBacks;

        public void AcceptFeedBack(FeedBack feedBack)
        {
            feedBack.IsAccepted = true;
            appDbContext.FeedBacks.Update(feedBack);
            appDbContext.SaveChanges();
        }

        public void AddFeedBack(FeedBack feedBack)
        {
            appDbContext.FeedBacks.Add(feedBack);
            appDbContext.SaveChanges();
        }

        public void DeleteFeedBack(FeedBack feedBack)
        {
            appDbContext.FeedBacks.Remove(feedBack);
            appDbContext.SaveChanges();
        }

        public IEnumerable<FeedBack> GetFeedBacksByWindowId(int windowId)
        {
            return appDbContext.FeedBacks.Where(e => e.WindowId == windowId);
        }
    }
}
