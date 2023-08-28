using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.ViewModels
{
    public class StatisticsViewModel
    {
        public StatisticsViewModel()
        {
            CategoryStatistics = new List<CategoryStatistics>();
        }

        public List<CategoryStatistics> CategoryStatistics { get; set; }
        public OrderDetailsViewModel OrderDetailsViewModel { get; set; }

    }
    public class CategoryStatistics
    {
        public CategoryStatistics()
        {
            Windows = new List<Window>();
        }

        public Category Category { get; set; }
        public List<Window> Windows { get; set; }

    }

}
