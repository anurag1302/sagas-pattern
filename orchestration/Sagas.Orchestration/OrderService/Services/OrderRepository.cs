using OrderService.Models;

namespace OrderService.Services
{
    public class OrderRepository
    {
        public Guid CreateOrder(Order order)
        {
            return order.Id;
        }
    }
}
