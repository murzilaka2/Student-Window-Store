namespace WebApplication1.ViewModels
{
    public class FeedBackViewModel
    {
        public IEnumerable<FeedBack> FeedBacks { get; set; }
        public int Count { get; set; }

        public PageViewModel? PageViewModel { get; set; }
    }
}
