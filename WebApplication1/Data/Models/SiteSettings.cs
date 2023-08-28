namespace WebApplication1.Data.Models
{
    public class SiteSettings : FooterViewModel
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public int ProductCount { get; set; }
        public string LogoImage { get; set; }

        public string FormEmail { get; set; }
        public string FormSenderName { get; set; }
        public string FormNotHashedPassword { get; set; }
    }
}
