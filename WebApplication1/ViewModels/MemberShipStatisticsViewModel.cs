namespace WebApplication1.ViewModels
{
    public class MemberShipStatisticsViewModel
    {
        public InvitationsListViewModel InvitationsListViewModel { get; set; }
        public IEnumerable<string> Months { get; set; }
        public IEnumerable<int> Counts { get; set; }
    }
}
