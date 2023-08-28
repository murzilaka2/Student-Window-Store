using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class SuppliersController : Controller
    {
        private readonly ISupplier _supplier;
        public SuppliersController(ISupplier supplier)
        {
            _supplier = supplier;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 9;
            var allSuppliers = _supplier.GetSuppliers;
            var count = allSuppliers.Count();
            var items = allSuppliers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            return View(new SupplierViewModel
            {
                Suppliers = items,
                PageViewModel = pageViewModel
            });
        }
        [HttpGet]
        public IActionResult DeleteSupplier(int id)
        {
            var currentSupplier = _supplier.GetObjectSupplier(id);
            if (currentSupplier != null)
            {
                _supplier.RemoveSupplier(currentSupplier);
            }
            return RedirectToAction("Index", "Suppliers");
        }
        [HttpGet]
        public IActionResult ViewSupplier(int id)
        {
            var currentSupplier = _supplier.GetObjectSupplier(id);
            if (currentSupplier != null)
            {
                return View("ViewSupplier", currentSupplier);
            }
            return RedirectToAction("Index", "Suppliers");
        }
        [HttpGet]
        public IActionResult EditSupplier(int id)
        {
            var currentSupplier = _supplier.GetObjectSupplier(id);
            if (currentSupplier != null)
            {
                return View("EditSupplier", new CurrentSupplierViewModel
                {
                    Id = currentSupplier.Id,
                    Name = currentSupplier.Name,
                    Description = currentSupplier.Description,
                    Phone = currentSupplier.Phone,
                    Image = currentSupplier.Image,
                    Address = currentSupplier.Address,
                    Email = currentSupplier.Email
                });
            }
            return RedirectToAction("Index", "Suppliers");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult EditSupplier(CurrentSupplierViewModel currentSupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                if (currentSupplierViewModel.Id != null)
                {
                    _supplier.UpdateSupplier(new Supplier
                    {
                        Id = (int)currentSupplierViewModel.Id,
                        Name = currentSupplierViewModel.Name!,
                        Description = currentSupplierViewModel.Description,
                        Address = currentSupplierViewModel.Address,
                        Email = currentSupplierViewModel.Email,
                        Image = currentSupplierViewModel.Image,
                        Phone = currentSupplierViewModel.Phone
                    });
                }
                return RedirectToAction("Index", "Suppliers");
            }
            return View(currentSupplierViewModel);
        }
        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddSupplier(CurrentSupplierViewModel currentSupplierViewModel)
        {
            if (ModelState.IsValid)
            {
                _supplier.AddSupplier(new Supplier
                {
                    Name = currentSupplierViewModel.Name!,
                    Description = currentSupplierViewModel.Description,
                    Address = currentSupplierViewModel.Address,
                    Email = currentSupplierViewModel.Email,
                    Image = currentSupplierViewModel.Image,
                    Phone = currentSupplierViewModel.Phone
                });
                return RedirectToAction("Index", "Suppliers");
            }
            return View(currentSupplierViewModel);
        }
    }
}
