namespace WebApplication1.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int WindowId { get; set; }
        public Window Window { get; set; }
        public Order Order { get; set; }
    }
}
