namespace WebApplication1.Data.Models
{
    //Сервис для информации о корзинке
    public class CartInfo : ICartService
    {
        private readonly ShopCart shopCart;
        public CartInfo(ShopCart shopCart)
        {
            this.shopCart = shopCart;
        }
        public int ItemsCount => shopCart.GetShopItems().Count;
    }
}
