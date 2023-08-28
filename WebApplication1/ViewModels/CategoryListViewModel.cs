namespace WebApplication1.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> AllCategories { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
