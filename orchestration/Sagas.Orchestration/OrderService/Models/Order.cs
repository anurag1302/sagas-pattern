using OrderService.Enumerations;

namespace OrderService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal? Price { get; set; }
        public OrderStatus Status { get; set; }
    }
}
