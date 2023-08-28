using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IAllWindows _allWindows;
        private readonly IWindowsCategory _windowsCategory;
        public ItemController(IAllWindows allWindows, IWindowsCategory windowsCategory)
        {
            _allWindows = allWindows;
            _windowsCategory = windowsCategory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddCategory(Category? category)
        {
            if (category.CategoryName == null)
            {
                return PartialView("PartialsMaterial/_AddCategory");
            }
            try
            {
                _windowsCategory.AddCategory(category);
            }
            catch (Exception ex)
            {
                return Content($"<html><body><h3>Такая категория уже есть!</h3><br /><p>Детальная информация: {ex.Message}</p>" +
                    $"<br /><p><a href=\"/account/item\">Вернутся назад</a></p></body></html>", "text/html", System.Text.Encoding.UTF8);
            }
            return Redirect("/account/item");

        }
        public async Task<IActionResult> AddProduct(ProductViewModel? productViewModel)
        {
            if (productViewModel.Window == null)
            {
                ViewBag.Categories = _windowsCategory.AllCategories;
                return PartialView("PartialsMaterial/_AddProduct", productViewModel);
            }
            _allWindows.AddWindow(productViewModel.Window, productViewModel.Category);
            return Redirect("/account/item");
        }
        public async Task<IActionResult> AllCategories(string? categoryName, int page = 1)
        {
            int pageSize = 9;
            var categories = categoryName != null
                ? _windowsCategory.AllCategories.Where(e => e.CategoryName.Contains(categoryName, StringComparison.OrdinalIgnoreCase))
                : _windowsCategory.AllCategories;
            var count = categories.Count();
            var items = categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel()
            {
                AllCategories = items,
                PageViewModel = pageViewModel
            };
            return View(categoryListViewModel);
        }
        public async Task<IActionResult> AllItems(string? itemName, int page = 1)
        {
            int pageSize = 9;
            var windows = itemName != null
               ? _allWindows.Windows.Where(e => e.Name.Contains(itemName, StringComparison.OrdinalIgnoreCase))
               : _allWindows.Windows;
            var count = windows.Count();
            var items = windows.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            WindowsListViewModel windowsListViewModel = new WindowsListViewModel()
            {
                AllWindows = items,
                PageViewModel = pageViewModel,
            };
            return View(windowsListViewModel);
        }
        public IActionResult DeleteCategory(int Id)
        {
            var selectedCategory = _windowsCategory.GetCategory(Id);
            if (selectedCategory != null)
            {
                _windowsCategory.RemoveCategory(selectedCategory);
                return Redirect("/account/item/allcategories");
            }
            else
            {
                return Content("Категория отсутствует");
            }
        }
        public IActionResult DeleteProduct(int Id)
        {
            var selectedItem = _allWindows.GetObjectWindow(Id);
            if (selectedItem != null)
            {
                _allWindows.RemoveWindow(selectedItem);
                return Redirect("/account/item/allitems");
            }
            else
            {
                return Content("Товар отсутствует");
            }
        }
        public IActionResult EditCategory(int Id)
        {
            var selectedCategory = _windowsCategory.GetCategory(Id);
            if (selectedCategory != null)
            {
                return View(selectedCategory);
            }
            else
            {
                return Content("Категория отсутствует");
            }
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _windowsCategory.UpdateCategory(category);
            return Redirect("/account/item/allcategories");
        }
        public IActionResult EditProduct(int Id)
        {
            var selectedWindow = _allWindows.GetObjectWindow(Id);
            if (selectedWindow != null)
            {
                ViewBag.Categories = _windowsCategory.AllCategories;
                return View(selectedWindow);
            }
            else
            {
                return Content("Товар отсутствует");
            }
        }
        [HttpPost]
        public IActionResult EditProduct(Window window)
        {
            var currentCategory = _windowsCategory.GetCategory(window.Category.Id);
            window.Category = currentCategory;
            _allWindows.UpdateWindow(window);
            return Redirect("/account/item/allitems");
        }
    }
}
