using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class WindowRepository : IAllWindows
    {
        private readonly AppDbContext appDbContext;
        public WindowRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Window> Windows => appDbContext.Windows.Include(e => e.Category);

        public IEnumerable<Window> GetFavoriteWindows => appDbContext.Windows.Where(e => e.IsFavorite).Include(e => e.Category);

        public Window GetObjectWindow(int id)
        {
            return appDbContext.Windows.Include(e=>e.Category).FirstOrDefault(e => e.Id == id)!;
        }
        public Window GetObjectWindowWithFeedBacks(int id)
        {
            return appDbContext.Windows.Include(e => e.Category).Include(e=>e.FeedBacks).FirstOrDefault(e => e.Id == id)!;
        }
        public void AddWindow(Window window, Category category)
        {
            window.CategoryId = category.Id;
            appDbContext.Windows.Add(window);
            appDbContext.SaveChanges();
        }

        public void RemoveWindow(Window window)
        {
            appDbContext.Windows.Remove(window);
            appDbContext.SaveChanges();
        }

        public void UpdateWindow(Window window)
        {
            appDbContext.Windows.Update(window);
            appDbContext.SaveChanges();
        }
    }
}
