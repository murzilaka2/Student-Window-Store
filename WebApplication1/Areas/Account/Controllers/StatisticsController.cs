using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IAllOrder _allOrder;
        private readonly IAllWindows _allWindows;
        private readonly IWindowsCategory _windowsCategory;
        public StatisticsController(IAllOrder allOrder, IAllWindows allWindows, IWindowsCategory windowsCategory)
        {
            _allOrder = allOrder;
            _allWindows = allWindows;
            _windowsCategory = windowsCategory;
        }
        public IActionResult Index()
        {
            var svm = new StatisticsViewModel();

            var allCategories = _windowsCategory.AllCategories.ToList();
            if (allCategories != null)
            {
                var allOrders = _allOrder.GetAllOrders();
                var allOrdersDetails = GetAllOrders(allCategories.FirstOrDefault().Id!);
                svm.OrderDetailsViewModel = new OrderDetailsViewModel
                {
                    OrderDetails = allOrdersDetails,
                    TotalSum = allOrdersDetails.Sum(e => e.Window.Price)
                };
                foreach (var category in allCategories)
                {
                    svm.CategoryStatistics.Add(new CategoryStatistics { Category = category });
                    foreach (var order in allOrders)
                    {
                        foreach (var orderdetail in order.OrderDetails)
                        {
                            if (orderdetail.Window.Category.CategoryName.Equals(category.CategoryName))
                            {
                                svm.CategoryStatistics[svm.CategoryStatistics.Count - 1].Windows.Add(orderdetail.Window);
                            }
                        }
                    }
                }
            }
            return View(svm);
        }
        public async Task<IActionResult> GetStatisticTable(int id)
        {
            var orders = GetAllOrders(id);
            var totalSum = orders.Sum(e => e.Window.Price);
            return PartialView("PartialsMaterial/_StatisticTable", new OrderDetailsViewModel
            {
                OrderDetails = orders,
                TotalSum = totalSum
            });
        }
        private IEnumerable<OrderDetail> GetAllOrders(int id)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            var currentCategory = _windowsCategory.GetCategory(id);
            if (currentCategory != null)
            {
                var allOrders = _allOrder.GetAllOrders();
                foreach (var order in allOrders)
                {
                    foreach (var orderdetail in order.OrderDetails)
                    {
                        if (orderdetail.Window.Category.CategoryName.Equals(currentCategory.CategoryName))
                        {
                            orderDetails.Add(orderdetail);
                        }
                    }
                }
            }
            return orderDetails;
        }
    }
}
