using WebApplication1.Data.Models;

namespace WebApplication1.ViewModels
{
    public class WindowsListViewModel
    {
        public IEnumerable<Window>? AllWindows { get; set; }
        public IEnumerable<Category>? AllCategories { get; set; }
        public PageViewModel? PageViewModel { get; set; }
        public string? CurrentCategory { get; set; }
    }
}
