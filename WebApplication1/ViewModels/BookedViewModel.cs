namespace WebApplication1.ViewModels
{
    public class BookedViewModel
    {
        public IEnumerable<Booked>? AllBookeds{ get; set; }
        public PageViewModel? PageViewModel { get; set; }
        public int Count { get; set; }
    }
}
