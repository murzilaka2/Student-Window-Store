namespace WebApplication1.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCart { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                if (this.ShopCart != null)
                {
                    foreach (var item in ShopCart.ShopWindowItems)
                    {
                        total += item.Price;
                    }
                }
                return total;
            }
        }
    }
}
