using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data.Repository
{
    public class OrderRepository:IAllOrder
    {
        private readonly AppDbContext appDbContext;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDbContext appDbContext, ShopCart shopCart)
        {
            this.appDbContext = appDbContext;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            appDbContext.Orders.Add(order);
            appDbContext.SaveChanges();
            //получение всех заказов из корзинки покупателя
            var items = shopCart.ShopWindowItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail
                {
                    WindowId = item.Window.Id,
                    OrderId = order.Id
                };
                appDbContext.OrderDetails.Add(orderDetail);
            }
            appDbContext.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            appDbContext.Remove(order);
            appDbContext.SaveChanges();
        }

        public IEnumerable<Order> GetAllCurrentStatusOrders(OrderStatus orderStatus)
        {
            return appDbContext.Orders.Include(e => e.OrderDetails).ThenInclude(e => e.Window).ThenInclude(e => e.Category).Where(e=>e.OrderStatus == orderStatus.ToString());
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return appDbContext.Orders.Include(e=>e.OrderDetails).ThenInclude(e=>e.Window).ThenInclude(e=>e.Category);
        }

        public Order GetOrder(int id)
        {
            var currentOrder = appDbContext.Orders.FirstOrDefault(e => e.Id == id);
            if (currentOrder != null)
            {
                return currentOrder;
            }
            throw new Exception("Заказ не найден!");
        }

        public void UpdateOrder(Order order)
        {
            appDbContext.Orders.Update(order);
            appDbContext.SaveChanges();
        }
    }
}
