using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class FeedBackController : Controller
    {
        private readonly IFeedBack _feedBack;

        public FeedBackController(IFeedBack feedBack)
        {
            _feedBack = feedBack;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 9;
            var feedBacks = _feedBack.FeedBacks;
            var count = feedBacks.Count();
            var items = feedBacks.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            return View(new FeedBackViewModel
            {
                FeedBacks = items,
                PageViewModel = pageViewModel,
                Count = feedBacks.Count()
            });
        }
        public IActionResult Delete(int id)
        {
            var currentFeedback = _feedBack.FeedBacks.FirstOrDefault(e => e.Id == id);
            if (currentFeedback != null)
            {
                _feedBack.DeleteFeedBack(currentFeedback);
            }
            return RedirectToAction("Index", "FeedBack");
        }
        public IActionResult Accept(int id)
        {
            var currentFeedback = _feedBack.FeedBacks.FirstOrDefault(e => e.Id == id);
            if (currentFeedback != null)
            {
                _feedBack.AcceptFeedBack(currentFeedback);
            }
            return RedirectToAction("Index", "FeedBack");
        }
    }
}
