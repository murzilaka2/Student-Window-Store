using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class CategoryRepository : IWindowsCategory
    {
        private readonly AppDbContext appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Category> AllCategories => appDbContext.Categories;

        public void AddCategory(Category category)
        {
            try
            {
                appDbContext.Categories.Add(category);
                appDbContext.SaveChanges();
            }
            catch { throw; }
        }

        public Category GetCategory(int id)
        {
            return appDbContext.Categories.FirstOrDefault(e => e.Id == id)!;
        }

        public void RemoveCategory(Category category)
        {
            appDbContext.Categories.Remove(category);
            appDbContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            appDbContext.Categories.Update(category);
            appDbContext.SaveChanges();
        }
    }
}
