using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Repository;

namespace WebApplication1.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContext appDbContext;

        public ShopCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public string ShopCartId { get; set; }
        public List<ShopWindowItem> ShopWindowItems { get; set; }
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Window window)
        {
            appDbContext.ShopWindowItems.Add(new ShopWindowItem
            {
                ShopCartId = ShopCartId,
                Window = window,
                Price = window.Price
            });
            appDbContext.SaveChanges();
        }
        public void DeleteFromCart(ShopWindowItem shopWindowItem)
        {
            appDbContext.ShopWindowItems.Remove(shopWindowItem);
            appDbContext.SaveChanges();
        }
        public void ClearItems()
        {
            foreach (var item in appDbContext.ShopWindowItems)
            {
                if (item.ShopCartId == ShopCartId)
                {
                    appDbContext.ShopWindowItems.Remove(item);
                }
            }
            appDbContext.SaveChanges();
        }
        //Отображение всех товаров из корзины
        public List<ShopWindowItem> GetShopItems() => appDbContext.ShopWindowItems.Where(e=>e.ShopCartId == ShopCartId).Include(e=>e.Window).ThenInclude(e=>e.Category).ToList();
    }
}
