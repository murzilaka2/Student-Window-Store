namespace WebApplication1.ViewModels
{
    public class OrderDetailsViewModel
    {
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public decimal TotalSum { get; set; }
    }
}
