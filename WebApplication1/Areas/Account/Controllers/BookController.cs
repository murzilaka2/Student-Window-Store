using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBooked _booked;
        public BookController(IBooked booked)
        {
            _booked = booked;
        }
        public IActionResult Index(string? phoneNumber, int page = 1)
        {
            int pageSize = 9;
            var allbookeds = phoneNumber != null ? _booked.Bookeds.Where(e=>e.ClientPhone.Contains(phoneNumber)) : _booked.Bookeds;
            var count = allbookeds.Count();
            var items = allbookeds.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            return View(new BookedViewModel
            {
                AllBookeds = items,
                PageViewModel = pageViewModel,
                Count = allbookeds.Count()
            });
        }
        public IActionResult Delete(int id)
        {
           _booked.DeleteBooked(id);
            return RedirectToAction("Index");
        }
    }
}
