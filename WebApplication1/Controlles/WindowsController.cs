using Microsoft.AspNetCore.Mvc;


namespace WebApplication1.Controlles
{
    public class WindowsController : Controller
    {
        private readonly IAllWindows _allWindows;
        private readonly IWindowsCategory _windowsCategory;
        private readonly IFeedBack _feedBack;
        //устанавливает данные по интерефейсам, через которые мы будем получать все данные
        //за счет того, что в классе Program, выполнили следующие строки:
        //builder.Services.AddTransient<IAllWindows, WindowRepository>();
        //builder.Services.AddTransient<IWindowsCategory, CategoryRepository>();
        //мы связали интерефес и класс и теперь можем обращаться к интерефейсу
        //и по сути мы обращаемся так же к классу, который реализует данный интерефес
        //В итоге, когда мы будет передать сюда какие либо интерфейсы и вместе с нимим
        //будем передавать класс, которые его реализует, а вместе с классом, все 
        //объекты внутри него, в данном случае набор заполненных вручную объектов.
        public WindowsController(IAllWindows allWindows, IWindowsCategory windowsCategory, IFeedBack feedBack)
        {
            _allWindows = allWindows;
            _windowsCategory = windowsCategory;
            _feedBack = feedBack;
        }
        [Route("Windows/Index")]
        public IActionResult Index(int page = 1)
        {
            int pageSize = 9;
            string windowCategory = "Все окна";
            IEnumerable<Window> windows = _allWindows.Windows.OrderBy(e => e.Id);
            var count = windows.Count();
            var items = windows.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            WindowsListViewModel windowsListViewModel = new WindowsListViewModel()
            {
                AllWindows = items,
                CurrentCategory = windowCategory,
                AllCategories = windows.Select(e => e.Category).Distinct(),
                PageViewModel = pageViewModel,
            };
            return View(windowsListViewModel);
        }
        [Route("Windows/Index/{category}")]
        public IActionResult Index(string category, int page = 1)
        {
            int pageSize = 9;
            string windowCategory = category;
            IEnumerable<Window> windows = _allWindows.Windows.Where(e => e.Category.CategoryName.Equals(category)).OrderBy(e => e.Id);
            var count = windows.Count();
            var items = windows.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            WindowsListViewModel windowsListViewModel = new WindowsListViewModel()
            {
                AllWindows = items,
                CurrentCategory = windowCategory,
                AllCategories = windows.Select(e => e.Category).Distinct(),
                PageViewModel = pageViewModel,
            };
            return View(windowsListViewModel);
        }
        public IActionResult SearchWindows(string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                var selectedWindows = _allWindows.Windows.Where(e => e.Name.ToLower().Contains(value.ToLower()));
                return View(selectedWindows);
            }
            else
            {
                return Redirect("/Windows/Index");
            }

        }
        public IActionResult WindowView(int id)
        {
            var currentWindow = _allWindows.GetObjectWindowWithFeedBacks(id);
            if (currentWindow != null)
            {
                return View(new WindowViewModel
                {
                    Window = currentWindow
                });
            }
            return NotFound();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> FeedBack(WindowViewModel windowViewModel)
        {
            if (ModelState.IsValid)
            {
                _feedBack.AddFeedBack(new Data.Models.FeedBack
                {
                    WindowId = (int)windowViewModel.WindowId!,
                    Name = windowViewModel.FeedBackModel.Name,
                    Email = windowViewModel.FeedBackModel.Email,
                    Comment = windowViewModel.FeedBackModel.Comment
                });
                return PartialView("_FeedBackResult");     
            }
            var currentWindow = _allWindows.GetObjectWindow((int)windowViewModel.WindowId!);
            if (currentWindow != null)
            {
                windowViewModel.Window = currentWindow;
                return View("WindowView", windowViewModel);
            }
            return RedirectToAction("Index","Windows");
        }
    }
}
