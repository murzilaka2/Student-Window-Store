namespace WebApplication1.Data.Interfaces
{
    public interface ISiteSettings
    {
        void ChangePostEmail(SiteSettings siteSettings);
        void ChangeSiteName(SiteSettings siteSettings);
        void ChangeProductCount(SiteSettings siteSettings);
        void ChangeFooter(SiteSettings siteSettings);
        void ChangeLogo(SiteSettings siteSettings);
        SiteSettings SiteSetting { get; }
        string SiteName { get; }
        int ProductCount { get; }
        string SiteLogo { get; }
        FooterViewModel GetFooter();
        PostEmailViewModel GetPostEmail();
    }
}
