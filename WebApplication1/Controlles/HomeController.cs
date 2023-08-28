using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Helpers;

namespace WebApplication1.Controlles
{
    public class HomeController : Controller
    {
        private readonly IAllWindows _allWindows;
        private readonly IWindowsCategory _windowsCategory;
        private readonly ISiteSettings _siteSettings;
        //устанавливает данные по интерефейсам, через которые мы будем получать все данные
        //за счет того, что в классе Program, выполнили следующие строки:
        //builder.Services.AddTransient<IAllWindows, WindowRepository>();
        //builder.Services.AddTransient<IWindowsCategory, CategoryRepository>();
        //мы связали интерефес и класс и теперь можем обращаться к интерефейсу
        //и по сути мы обращаемся так же к классу, который реализует данный интерефес
        //В итоге, когда мы будет передать сюда какие либо интерфейсы и вместе с нимим
        //будем передавать класс, которые его реализует, а вместе с классом, все 
        //объекты внутри него, в данном случае набор заполненных вручную объектов.
        public HomeController(IAllWindows allWindows, IWindowsCategory windowsCategory, ISiteSettings siteSettings)
        {
            _allWindows = allWindows;
            _windowsCategory = windowsCategory;
            _siteSettings = siteSettings;
        }
        public IActionResult Index()
        {
            string windowCategory = "Избранные окна";
            IEnumerable<Window> windows = _allWindows.Windows.Where(e => e.IsFavorite).OrderBy(e => e.Id);
            WindowsListViewModel windowsListViewModel = new WindowsListViewModel()
            {
                AllWindows = windows,
                CurrentCategory = windowCategory
            };
            return View(windowsListViewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(SendMessage sendMessage)
        {
            if (ModelState.IsValid)
            {
                SmtpMessage smtpMessage = new SmtpMessage(_siteSettings);
                smtpMessage.Send(sendMessage);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult MakeDeal(string name, string phone)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(phone))
            {
                SmtpMessage smtpMessage = new SmtpMessage(_siteSettings);
                smtpMessage.SendShort(name, phone);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }       
    }
}
