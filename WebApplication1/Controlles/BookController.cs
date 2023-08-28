using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controlles
{
    public class BookController : Controller
    {
        private readonly IBooked _booked;
        public BookController(IBooked booked)
        {
            _booked = booked;
        }
        public IActionResult Booking()
        {
            DateTime dateTime = DateTime.Now;
            var end = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return View(new BookingViewModel { TotalDays = end, CurrentMonth = dateTime });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Booking(BookingViewModel bookingViewModel)
        {
            DateTime dateTime = bookingViewModel.CurrentMonth.AddMonths(bookingViewModel.Subtrahend);
            var end = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            return View(new BookingViewModel { TotalDays = end, CurrentMonth = dateTime });
        }
        [HttpGet]
        public async Task<IActionResult> GetBooked(int day, DateTime CurrentMonth, int currentMonthNumber)
        {
            return PartialView("_BookedInfo", new BookingPersonViewModel { DateTime = new DateTime(DateTime.Now.Year, currentMonthNumber, day) });
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> GetBooked(BookingPersonViewModel bookingPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _booked.AddBooked(new Booked
                {
                    ClientName = bookingPersonViewModel.Name,
                    ClientPhone = bookingPersonViewModel.Phone,
                    CreatedDate = bookingPersonViewModel.DateTime
                });
                return PartialView("_Success");
            }
            return PartialView("_BookedInfo", bookingPersonViewModel);
        }
    }
}
