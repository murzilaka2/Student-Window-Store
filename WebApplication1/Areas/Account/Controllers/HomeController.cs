using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication1.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAllUser allUser;
        private readonly IAllOrder allOrder;
        public HomeController(IAllUser allUser, IAllOrder allOrder)
        {
            this.allUser = allUser;
            this.allOrder = allOrder;
        }

        public async Task<IActionResult> Index(string? orderStatus)
        {
            if (orderStatus != null)
            {
                var currentStatusOrders = allOrder.GetAllCurrentStatusOrders((OrderStatus)Enum.Parse(typeof(OrderStatus), orderStatus));
                return View(currentStatusOrders);
            }
            var allOrders = allOrder.GetAllOrders();
            return View(allOrders);
        }
        public IActionResult Update(OrderStatus orderStatus, int orderId)
        {
            var selectedOrder = allOrder.GetOrder(orderId);
            selectedOrder.OrderStatus = orderStatus.ToString();
            allOrder.UpdateOrder(selectedOrder);
            return Redirect("/account/Home");
        }
        public IActionResult Delete(int Id)
        {
            var selectedOrder = allOrder.GetOrder(Id);
            allOrder.DeleteOrder(selectedOrder);
            return Redirect("/account/Home");
        }
    }
}
