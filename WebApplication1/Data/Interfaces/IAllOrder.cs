namespace WebApplication1.Data.Interfaces
{
    public interface IAllOrder
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllCurrentStatusOrders(OrderStatus orderStatus);
        Order GetOrder(int id);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
