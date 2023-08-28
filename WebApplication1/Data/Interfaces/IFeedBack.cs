namespace WebApplication1.Data.Interfaces
{
    public interface IFeedBack
    {
        IEnumerable<FeedBack> FeedBacks { get; }
        IEnumerable<FeedBack> GetFeedBacksByWindowId(int windowId);
        void AddFeedBack(FeedBack feedBack);
        void DeleteFeedBack(FeedBack feedBack);
        void AcceptFeedBack(FeedBack feedBack);
    }
}
