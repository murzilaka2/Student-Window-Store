using WebApplication1.Data.Helpers;

namespace WebApplication1.Data.Repository
{
    public class SiteSettingsRepository : ISiteSettings
    {
        //Используется для возможностей в будующем
        //Добавив логику в базу данных, сайта могут использовать 
        //на нескольких серверах, для каждой компании и т.д.
        static int siteId = 1;
        private readonly AppDbContext _context;
        public SiteSettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public string SiteName => _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)?.SiteName!;

        public int ProductCount => _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)!.ProductCount;

        public string SiteLogo => _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)?.LogoImage!;

        public SiteSettings SiteSetting => _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)!;

        public void ChangeFooter(SiteSettings siteSettings)
        {
            var currentSiteSettings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteSettings.SiteId);
            if (currentSiteSettings != null)
            {
                currentSiteSettings.PhoneNumber = siteSettings.PhoneNumber;
                currentSiteSettings.WorkTime = siteSettings.WorkTime;
                currentSiteSettings.Address = siteSettings.Address;
                currentSiteSettings.Email = siteSettings.Email;
                _context.SaveChanges();
            }
        }

        public void ChangeLogo(SiteSettings siteSettings)
        {
            var currentSiteSettings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteSettings.SiteId);
            if (currentSiteSettings != null)
            {
                currentSiteSettings.LogoImage = siteSettings.LogoImage;
                _context.SaveChanges();
            }
        }

        public void ChangePostEmail(SiteSettings siteSettings)
        {
            var currentSiteSettings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteSettings.SiteId);
            if (currentSiteSettings != null)
            {
                currentSiteSettings.FormEmail = siteSettings.FormEmail;
                currentSiteSettings.FormNotHashedPassword = siteSettings.FormNotHashedPassword;
                currentSiteSettings.FormSenderName = siteSettings.FormSenderName;
                _context.SaveChanges();
            }
        }

        public void ChangeProductCount(SiteSettings siteSettings)
        {
            var currentSiteSettings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteSettings.SiteId);
            if (currentSiteSettings != null)
            {
                currentSiteSettings.ProductCount = siteSettings.ProductCount;
                _context.SaveChanges();
            }
        }

        public void ChangeSiteName(SiteSettings siteSettings)
        {
            var currentSiteSettings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteSettings.SiteId);
            if (currentSiteSettings != null)
            {
                currentSiteSettings.SiteName = siteSettings.SiteName;
                _context.SaveChanges();
            }
        }

        public FooterViewModel GetFooter()
        {
            var settings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)!;
            if (settings != null)
            {
                return new FooterViewModel
                {
                    Address = settings.Address,
                    Email = settings.Email,
                    PhoneNumber = settings.PhoneNumber,
                    WorkTime = settings.WorkTime
                };
            }
            return null!;
        }
        public PostEmailViewModel GetPostEmail()
        {
            var settings = _context.SiteSettings.FirstOrDefault(e => e.SiteId == siteId)!;
            if (settings != null)
            {
                return new PostEmailViewModel { FormEmail = settings.FormEmail, FormSenderName = settings.FormSenderName };
            }
            return null!;
        }
    }
}
