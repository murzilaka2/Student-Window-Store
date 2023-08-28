using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controlles
{
    public class OrderController : Controller
    {
        private readonly IAllOrder allOrder;
        private readonly ShopCart cart;

        public OrderController(IAllOrder allOrder, ShopCart cart)
        {
            this.allOrder = allOrder;
            this.cart = cart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.ShopWindowItems = cart.GetShopItems();
            if (cart.ShopWindowItems.Count == 0)
            {
                ModelState.AddModelError("","Пустая корзина");
            }
            if (ModelState.IsValid)
            {
                allOrder.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            cart.ClearItems();
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
