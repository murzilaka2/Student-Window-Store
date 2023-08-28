using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controlles
{
    [AllowAnonymous]
    public class ShopCartController : Controller
    {
        private readonly IAllWindows allWindows;
        private readonly ShopCart shopCart;
        public ShopCartController(IAllWindows allWindows, ShopCart shopCart)
        {
            this.allWindows = allWindows;
            this.shopCart = shopCart;
        }
        //отображение корзины
        public IActionResult Index()
        {
            //получение всех товаров
            var items = shopCart.GetShopItems();
            //если товаров нет, не пускаем на корзину
            if (items.Count < 1)
            {
                return Redirect("~/Home/Index");
            }
            shopCart.ShopWindowItems = items;
            //ViewModel ждя передачи нескольких частей на страницу
            var obj = new ShopCartViewModel
            {
                ShopCart = shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = allWindows.Windows.FirstOrDefault(e => e.Id == id)!;
            if (item != null)
            {
                shopCart.AddToCart(item);
            }
            //когда нажимаем на кнопку добавления товара, отправляемся на страницу с корзиной
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int id)
        {
            var shopWindowItem = shopCart.GetShopItems().FirstOrDefault(e => e.Id == id);
            if (shopWindowItem != null)
            {
                shopCart.DeleteFromCart(shopWindowItem);
            }
            return RedirectToAction("Index");
        }
    }
}
