using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1.Data.Helpers;
using SiteSet = WebApplication1.Data.Models.SiteSettings;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    public class SettingsController : Controller
    {
        private readonly IAllUser _allUser;
        private readonly ISiteSettings _siteSettings;
        private readonly IInvitation _invitation;
        public SettingsController(ISiteSettings siteSettings, IAllUser allUser, IInvitation invitation)
        {
            _siteSettings = siteSettings;
            _allUser = allUser;
            _invitation = invitation;
        }
        public IActionResult Index(int page = 1)
        {
            var currentUser = GetSessionUser();
            if (currentUser == null)
            {
                return NotFound();
            }
            return View(new UserSettingsViewModel { Email = currentUser.Email, Name = currentUser.Name, MemberShipStatisticsViewModel = GetMonthStatistics(page) });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(UserSettingsViewModel userSettings)
        {
            var currentUser = GetSessionUser();
            if (currentUser == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (!_allUser.IsEmailExists(userSettings.Email, currentUser.Email))
                {
                    string salt = currentUser.Salt;
                    string hashedPassword = SecurityHelper.HashPassword(userSettings.Password, salt, 10101, 70);
                    if (!currentUser.HashedPassword.Equals(hashedPassword))
                    {
                        currentUser.HashedPassword = hashedPassword;
                    }
                    currentUser.Email = userSettings.Email;
                    currentUser.Name = userSettings.Name;
                    _allUser.UpdateUser(currentUser);
                    return Redirect("settings/index");
                }
                else
                {
                    ModelState.AddModelError("", "Такой E-Mail адрес уже используется");
                }
            }
            return View(userSettings);
        }
        [HttpGet]
        public IActionResult SiteSettings()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult SiteSettings(FooterViewModel footerViewModel)
        {
            if (ModelState.IsValid)
            {
                _siteSettings.ChangeFooter(new SiteSet
                {
                    SiteId = 1,
                    Email = footerViewModel.Email,
                    Address = footerViewModel.Address,
                    PhoneNumber = footerViewModel.PhoneNumber,
                    WorkTime = footerViewModel.WorkTime,
                });
                return View();
            }
            else
            {
                return View(footerViewModel);
            }
        }
        public IActionResult ChangeFormEmail(string formEmail, string formPassword, string formName)
        {
            if (SIO(formEmail) && SIO(formPassword) && SIO(formName))
            {
                _siteSettings.ChangePostEmail(new SiteSet
                {
                    SiteId = 1,
                    FormEmail = formEmail,
                    FormNotHashedPassword = formPassword,
                    FormSenderName = formName
                });
            }
            return View("sitesettings");
        }
        public IActionResult ChangeSiteName(string siteName)
        {
            if (SIO(siteName))
            {
                _siteSettings.ChangeSiteName(new SiteSet { SiteId = 1, SiteName = siteName });
            }
            return View("sitesettings");
        }
        public IActionResult ChangeProductCount(int productCount)
        {
            if (productCount >= 0 && productCount < 100)
            {
                _siteSettings.ChangeProductCount(new SiteSet { SiteId = 1, ProductCount = productCount });
            }
            return View("sitesettings");
        }
        public IActionResult ChangeSiteLogo(string siteLogo)
        {
            if (SIO(siteLogo))
            {
                _siteSettings.ChangeLogo(new SiteSet { SiteId = 1, LogoImage = siteLogo });
            }
            return View("sitesettings");
        }

        private bool SIO(string str)
        {
            return !String.IsNullOrWhiteSpace(str);
        }
        private User GetSessionUser()
        {
            int id = -1;
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            foreach (Claim item in principal.Claims)
            {
                if (item.Type.Equals("Id"))
                {
                    id = int.Parse(item.Value);
                    break;
                }
            }
            return _allUser.GetObjectUser(id);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GenerateInvitation()
        {
            var currentInvitation = _invitation.GenerateInvitation();
            return PartialView("_InvitationGenerator", currentInvitation.Href);
        }
        private MemberShipStatisticsViewModel GetMonthStatistics(int page = 1)
        {
            List<string> months = new List<string>(6);
            List<int> counts = new List<int> { -1, -1, -1, -1, -1, -1 };

            var currentInvitations = _invitation.Invitations.Where(e => e.GeneratedDate >= DateTime.Now.AddMonths(-6)).ToList();
            foreach (var item in currentInvitations)
            {
                string curentMonth = item.GeneratedDate.ToString("MMMM");
                if (!months.Contains(curentMonth))
                {
                    months.Add(curentMonth);
                }
                int index = months.IndexOf(curentMonth);
                counts[index] += counts[index] == -1 ? 2 : 1;
            }
            counts = counts.Where(e => e != -1).ToList();


            int pageSize = 5;
            var invitations = _invitation.Invitations;
            var count = invitations.Count();
            var items = invitations.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            InvitationsListViewModel ilvm = new InvitationsListViewModel()
            {
                Invitations = items,
                PageViewModel = pageViewModel
            };


            return new MemberShipStatisticsViewModel { Months = months, Counts = counts, InvitationsListViewModel = ilvm };
        }
    }
}
