namespace WebApplication1.Data.Models
{
    public class ShopWindowItem
    {
        public int Id { get; set; }
        public string ShopCartId { get; set; }
        public Window Window { get; set; }
        public decimal Price { get; set; }
    }
}
