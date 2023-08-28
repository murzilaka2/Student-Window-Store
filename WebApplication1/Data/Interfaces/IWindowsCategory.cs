using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interfaces
{
    public interface IWindowsCategory
    {
        IEnumerable<Category> AllCategories { get; }
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
    }
}
